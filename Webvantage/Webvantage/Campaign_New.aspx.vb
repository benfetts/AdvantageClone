Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Imports Webvantage.cGlobals

Partial Public Class Campaign_New
    Inherits Webvantage.BaseChildPage

    Private CmpCode As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

        Me.PageTitle = "New Campaign"

        If Page.IsPostBack = False Then

            SetLookups()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CAMP_AUTO_GEN_CODE.ToString)

                    If Setting IsNot Nothing AndAlso Setting.Value = 1 Then

                        If AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Any = False Then

                            txtCampaignCode.Text = "1"

                        Else

                            txtCampaignCode.Text = AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Select(Function(Entity) Entity.ID).Max + 1

                        End If

                    End If

                End Using

            End Using

        End If

    End Sub

    Private Sub SetLookups()
        Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=client&control=" & Me.txtClient.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value);return false;")

        Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=campaignnew&type=division&control=" & Me.txtDivision.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

        Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=campaignnew&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

        Me.hlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtOffice.ClientID & "&type=office');return false;")


        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With DDAlertGrp
            .DataSource = oDD.ddAlertGroups()
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
            .Text = "[None]"
        End With

    End Sub

    Private Sub SendAlerts()
        CmpCode = Me.txtCmp_ID.Text

        Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CType(Me.txtCmp_ID.Text, Integer))
        Dim NowDate As Date = Now
        Dim url As String
        Dim catID As Integer
        Dim empCode, subject As String
        Dim dr As SqlDataReader
        Dim IsAgencyAutoEmail As Boolean = cmp.IsAgencyAutoEmail()
        Dim bool As Boolean
        Dim body, bodyHTML As String

        If cmp.ALERT_GROUP <> "" Then
            subject = "New Campaign - " & CmpCode & " - " & Me.txtCampaignCodeDesc.Text & " for client " & txtClient.Text & " created by " & cmp.getUserFullEmpName(Session("UserCode"))
            catID = 6

            url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath
            bodyHTML = cmp.CreateBody(subject, url, cmp)   '"<a href='" & url & "/Campaign.aspx?CmpCode=" & txtCampaignCode.Text & "&Mode=open" & " '> </a><br /><br />"
            body = cmp.CreateBodyString(subject, url, cmp)

            If IsAgencyAutoEmail = True Then
                Dim IsCategoryPrompt As Boolean = cmp.IsAlertCategoryPrompt(catID)
                'Dim IsCategoryPrompt As Boolean = True
                If IsCategoryPrompt = True Then
                    'Open prompt window
                    Dim sbQSVars As System.Text.StringBuilder = New System.Text.StringBuilder
                    Dim emailGrp As String = Me.DDAlertGrp.Text
                    If emailGrp = "[None]" Then
                        emailGrp = ""
                    End If

                    Try
                        With sbQSVars
                            .Append("?")
                            .Append("EmailGroup=" & emailGrp)
                            .Append("&Recipients=" & "")
                            .Append("&IsHTML=True")
                            .Append("&New=1")
                            .Append("&CmpCode=" & CmpCode)
                            .Append("&ClientCode=" & Me.txtClient.Text)
                            .Append("&DivCode=" & Me.txtDivision.Text)
                            .Append("&ProdCode=" & Me.txtProduct.Text)
                            .Append("&OfficeCode=" & Me.txtOffice.Text)
                            .Append("&f=")
                            .Append(MiscFN.SourceApp_ToInt(Source_App.Campaign))
                        End With

                        Session("AlertPopUp_Title") = subject
                        Session("AlertPopUp_Body") = body
                        Session("AlertPopUp_BodyHTML") = bodyHTML
                        Dim str_PopEmail As String = Server.UrlDecode("window.open('popup_email_alert.aspx" & sbQSVars.ToString() & "','','screenX=150,left=150,screenY=150,top=150,width=310,height=575,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
                        Session("JobSpecsEmailPopup") = "CMP"
                        PageLoadJS(str_PopEmail)
                        'Session("str_PopEmail") = True

                    Catch ex As Exception
                        Me.ShowMessage("Error setting sbQSVars: " & ex.Message.ToString())
                    End Try

                Else


                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                        'just send to default group, if exists, without prompting
                        dr = cmp.GetEmailAddressFromGroup(cmp.ALERT_GROUP)
                        If dr.HasRows Then

                            Dim wsEmail As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
                            Dim Employee As New cEmployee(CStr(Session("ConnString")))
                            Dim EmailFlag As Integer
                            Dim emailAddress As String

                            With FxAlert
                                .AlertTypeID = 2
                                .AlertCategoryID = catID
                                .Subject = subject
                                .Body = body
                                .EmailBody = bodyHTML
                                .GeneratedDate = NowDate
                                .LastUpdated = .GeneratedDate
                                .PriorityLevel = 3
                                .EmployeeCode = Session("EmpCode")
                                .AlertLevel = "CM"
                                .UserCode = Session("UserCode")
                                .ClientCode = txtClient.Text
                                .DivisionCode = txtDivision.Text
                                .ProductCode = txtProduct.Text
                                .CampaignCode = CmpCode
                                .OfficeCode = txtOffice.Text
                                .CampaignID = cmp.CMP_IDENTIFIER
                            End With

                            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                                Dim Alert As New Alert(Session("ConnString"))
                                Alert.LoadByPrimaryKey(FxAlert.ID)

                                Do While dr.Read
                                    empCode = dr.GetString(0)
                                    emailAddress = dr.GetString(1)
                                    EmailFlag = Employee.GetAlertEmailFlag(empCode)

                                    Select Case EmailFlag
                                        Case 0 'no alerts or email
                                        Case 1  'email only
                                            bool = wsEmail.SendEmail("", emailAddress, subject, bodyHTML, "", "", True)
                                            'If bool = False Then
                                            '    Me.ShowMessage(wsEmail.getErrMsg)
                                            'End If

                                        Case 2  'alert only
                                            Alert.AddAlertRecipient(empCode)

                                        Case 3  'both alert and email
                                            Alert.AddAlertRecipient(empCode)
                                            bool = wsEmail.SendEmail("", emailAddress, subject, bodyHTML, "", "", True)
                                            'If bool = False Then
                                            '    Me.ShowMessage(wsEmail.getErrMsg)
                                            'End If
                                            'AlertFlag = True
                                    End Select
                                Loop

                                Me.CheckForAsyncMessage()

                                'If AlertFlag = True Then
                                '    SendEmailAlert(Alert.ALERT_ID)
                                'End If

                            Else

                                Me.ShowMessage("Alert failed to save")

                            End If


                        End If

                    End Using




                End If
            End If
        End If
    End Sub

    Private Sub PageLoadJS(ByVal str As String)
        Dim strTmp As String = String.Empty
        strTmp = "<script type=""text/javascript"">function init() { " & str & " } window.onload = init;</script>"
        'Session("str_PopEmail") = True

        If Not Page.IsStartupScriptRegistered("CMPNewAlert" & Now.Millisecond) Then
            Page.RegisterStartupScript("CMPNewAlert", strTmp)
        End If
    End Sub

    Private Sub butCreateJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butCreateJob.Click
        SaveCampaign()
    End Sub

    Private Sub SaveCampaign(Optional ByVal manual As Boolean = False)

        'Validate campaign
        If ValidateCampaign() = False Then Exit Sub

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim Campaign As New AdvantageFramework.Database.Entities.Campaign

            Campaign.DbContext = DbContext

            With Campaign

                If Me.txtOffice.Text.Trim() <> "" Then .OfficeCode = Me.txtOffice.Text.Trim()
                If Me.txtClient.Text.Trim() <> "" Then .ClientCode = Me.txtClient.Text.Trim()
                If Me.txtDivision.Text.Trim() <> "" Then .DivisionCode = Me.txtDivision.Text.Trim()
                If Me.txtProduct.Text.Trim() <> "" Then .ProductCode = Me.txtProduct.Text.Trim()
                If Me.txtCampaignCode.Text.Trim() <> "" Then .Code = Me.txtCampaignCode.Text.Trim()
                If Me.txtCampaignCodeDesc.Text.Trim() <> "" Then .Name = Me.txtCampaignCodeDesc.Text.Trim()
                If Me.DDAlertGrp.SelectedIndex > -1 Then .AlertGroupCode = DDAlertGrp.SelectedValue
                If Me.rbType.SelectedIndex > -1 Then .CampaignType = Me.rbType.SelectedValue

                If AdvantageFramework.Database.Procedures.Campaign.Insert(DbContext, Campaign) = True Then

                    Session("newCampaign") = True
                    If Me.CurrentQuerystring.IsJobDashboard = True Then
                        MiscFN.ResponseRedirect("Campaign.aspx?cmp=" & Campaign.ID & "&New=1", True)
                    Else
                        Me.CloseThisWindowAndOpenNewWindow("Campaign.aspx?cmp=" & Campaign.ID & "&New=1", True)
                    End If

                Else

                    Me.ShowMessage("Error saving campaign to database")

                End If

            End With

        End Using

    End Sub

    Private Function ValidateCampaign() As Boolean

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"))

        InvalidOffice.Visible = False
        InvalidClient.Visible = False
        InvalidDivision.Visible = False
        InvalidProduct.Visible = False
        InvalidCampaign.Visible = False
        InvalidCampaignDesc.Visible = False

        InvalidOffice.Text = "Invalid Office"
        InvalidClient.Text = "Invalid Client"
        InvalidDivision.Text = "Invalid Division"
        InvalidProduct.Text = "Invalid Product"
        InvalidCampaign.Text = "Campaign is required."

        If Me.txtCampaignCode.Text = "" Then
            InvalidCampaign.Visible = True
            MiscFN.SetFocus(txtCampaignCode)
            Return False
        End If

        If Me.txtCampaignCodeDesc.Text = "" Then
            InvalidCampaignDesc.Visible = True
            MiscFN.SetFocus(txtCampaignCodeDesc)
            Return False
        End If

        'See if already exists for client
        If cmp.CampaignCDPExists(Me.txtCampaignCode.Text, Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = True Then
            InvalidCampaign.Text = "Campaign already exists."
            InvalidCampaign.Visible = True
            Return -1
        End If

        'If Me.txtOffice.Text = "" Then
        '    InvalidOffice.Text = "Office is required"
        '    InvalidOffice.Visible = True
        '    MiscFN.SetFocus(txtOffice)
        '    Return -1
        'End If
        If Me.txtOffice.Text <> "" Then
            If myVal.ValidateOffice(Me.txtOffice.Text.Trim, True) = False Then
                InvalidOffice.Visible = True
                MiscFN.SetFocus(txtOffice)
                Return False
            End If
        End If

        'Validate Client (required)
        If Me.txtClient.Text = "" Then
            InvalidClient.Text = "Client is required."
            InvalidClient.Visible = True
            MiscFN.SetFocus(txtClient)
            Return False
        End If
        If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then
            InvalidClient.Visible = True
            MiscFN.SetFocus(txtClient)
            Return False
        End If
        If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
            InvalidClient.Text = "Access to this client is denied."
            InvalidClient.Visible = True
            MiscFN.SetFocus(txtClient)
            Return False
        End If

        'Validate Division if exists (not required for campaigns)
        If Me.txtClient.Text.Trim <> "" And Me.txtDivision.Text.Trim <> "" Then
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "", True) = False Then
                InvalidDivision.Text = "Invalid Division"
                InvalidDivision.Visible = True
                MiscFN.SetFocus(txtDivision)
                Return False
            End If
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then
                InvalidDivision.Visible = True
                InvalidDivision.Text = "Access to this division is denied."
                MiscFN.SetFocus(txtDivision)
                Return False
            End If
        End If

        'Validate Product if exists (not required for campaigns)
        If Me.txtProduct.Text.Trim <> "" Then
            'Product cannot exist without cl/div
            If Me.txtDivision.Text.Trim = "" Then
                InvalidDivision.Text = "Division is required."
                InvalidDivision.Visible = True
                MiscFN.SetFocus(txtDivision)
                Return False
            End If
            If Me.txtClient.Text.Trim <> "" And Me.txtDivision.Text.Trim <> "" And Me.txtProduct.Text.Trim <> "" Then
                If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, True) = False Then
                    InvalidProduct.Text = "Invalid Product"
                    InvalidProduct.Visible = True
                    MiscFN.SetFocus(txtProduct)
                    Return False
                End If
                If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                    InvalidProduct.Text = "Access to this product is denied."
                    InvalidProduct.Visible = True
                    MiscFN.SetFocus(txtProduct)
                    Return False
                End If
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                        InvalidProduct.Text = "Access to this product is denied."
                        InvalidProduct.Visible = True
                        MiscFN.SetFocus(txtProduct)
                        Return False
                    End If
                End Using

            End If
        End If
        Return True
    End Function

    Private Sub butCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.CloseThisWindow()
    End Sub
End Class