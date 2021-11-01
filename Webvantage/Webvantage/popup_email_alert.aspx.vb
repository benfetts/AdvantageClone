Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports Webvantage.cGlobals

Public Class popup_email_alert
    Inherits Webvantage.BaseChildPage

    Private ddEmailGroup As String = ""
    Private strDivCode As String = ""
    Private strJobCompNo As String = ""
    Private strJobNo As String = ""
    Private strProdCode As String = ""
    Private strRecipients As String = ""
    Private strClientCode As String = ""
    Private strCmpID As String = ""
    Private strOfficeCode As String = ""

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private CmpIdentifier As Integer = 0
    Private FromApp As MiscFN.Source_App = MiscFN.Source_App.JobJacket
    Public currentWindowsIdentity As System.Security.Principal.WindowsIdentity

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Try
                        'set vars from querystring
                        If Not Request.QueryString("EmailGroup") Is Nothing Then
                            ddEmailGroup = Request.QueryString("EmailGroup")
                        End If

                        If Not Request.QueryString("OfficeCode") Is Nothing Then
                            strOfficeCode = Request.QueryString("OfficeCode").ToString
                        End If

                        If Not Request.QueryString("DivCode") Is Nothing Then
                            strDivCode = Request.QueryString("DivCode").ToString
                        End If


                        If Not Request.QueryString("ProdCode") Is Nothing Then
                            strProdCode = Request.QueryString("ProdCode").ToString
                        End If

                        If Not Request.QueryString("JobNo") Is Nothing Then
                            strJobNo = Request.QueryString("JobNo").ToString
                            ViewState("curJobNo") = Request.QueryString("JobNo").ToString
                            Try
                                If IsNumeric(Request.QueryString("JobNo")) = True Then
                                    Me.JobNumber = CType(Request.QueryString("JobNo"), Integer)
                                End If
                            Catch ex As Exception
                                Me.JobNumber = 0
                            End Try
                        End If

                        If Not Request.QueryString("JobCompNo") Is Nothing Then
                            strJobCompNo = Request.QueryString("JobCompNo").ToString
                            ViewState("currJobCompNo") = Request.QueryString("JobCompNo").ToString

                            Try
                                If IsNumeric(Request.QueryString("JobCompNo")) = True Then
                                    Me.JobComponentNbr = CType(Request.QueryString("JobCompNo"), Integer)
                                End If
                            Catch ex As Exception
                                Me.JobComponentNbr = 0
                            End Try

                        End If

                        'ST: Is this where the convert to numeric errr is coming from?
                        If Not Request.QueryString("Recipients") Is Nothing Then
                            strRecipients = Request.QueryString("Recipients").ToString
                        End If

                        If Not Request.QueryString("ClientCode") Is Nothing Then
                            strClientCode = Request.QueryString("ClientCode").ToString
                        End If

                        If Not Request.QueryString("cmp") Is Nothing Then
                            strCmpID = Request.QueryString("cmp").ToString

                            Try
                                If IsNumeric(Request.QueryString("cmp")) = True Then
                                    Me.CmpIdentifier = CType(Request.QueryString("cmp"), Integer)
                                End If
                            Catch ex As Exception
                                Me.CmpIdentifier = 0
                            End Try

                        End If

                        Try
                            If Not Request.QueryString("f") Is Nothing Then
                                Me.FromApp = MiscFN.SourceApp_FromInt(CType(Request.QueryString("f"), Integer))
                            End If
                        Catch ex As Exception
                            Me.FromApp = MiscFN.Source_App.JobJacket
                        End Try

                        If Not IsPostBack Then

                            Dim HTML_Body As String = ""

                            If Me.FromApp = MiscFN.Source_App.JobSpecs Then

                                If Session("AlertPopUpJS_Body") IsNot Nothing Then HTML_Body = Session("AlertPopUpJS_Body").ToString().Replace(Environment.NewLine, "<br/>")
                                AlertPopup(Session("AlertPopUpJS_Title"), HTML_Body)

                            Else

                                If Session("AlertPopUp_Body") IsNot Nothing Then HTML_Body = Session("AlertPopUp_Body").ToString().Replace(Environment.NewLine, "<br/>")
                                AlertPopup(Session("AlertPopUp_Title"), HTML_Body)

                            End If

                        End If

                        'Modified by Sam Tran on 2006/05/31
                        'butSendAlert.Attributes.Add("OnClick", "document.frmAlertEmail.txtRecipients.value=ob_t2_list_checked();")

                        'butCancelAlert.Attributes.Add("OnClick", "Javascript:window.close();")

                        Dim strJS As String = ""
                        'Modified by Sam Tran on 2006/06/21
                        '	added this to prevent saving components over and over
                        'Dim strJS As String = Server.UrlDecode("Javascript:opener.location.href=""jobjacket.aspx?job=" & strJobNo & "&jobcomp=" & strJobCompNo & """")
                        If Me.FromApp = MiscFN.Source_App.JobSpecs Then
                            strJS = Server.UrlDecode("Javascript:opener.location.href=""jobspecs.aspx?JobNum=" & strJobNo & "&JobCompNum=" & strJobCompNo & "&new=0" & "&Version=" & Request.QueryString("Version") & "&Revision=" & Request.QueryString("Revision") & """")
                        ElseIf Me.FromApp = MiscFN.Source_App.Campaign Then
                            'strJS = Server.UrlDecode("Javascript:opener.location.href=""Campaign.aspx?cmp=" & strCmpID & """")
                            'strJS = Server.UrlDecode("Javascript:opener.location.href=""Campaign.aspx?PopEmail=true&cmp=" & strCmpID & """")
                            'strJS = strJS + "Javascript:window.close();"
                        Else
                            strJS = Server.UrlDecode("Javascript:opener.location.href=""Content.aspx?PageMode=Edit&JobNum=" & strJobNo & "&JobCompNum=" & strJobCompNo & "&NewComp=0" & """")
                        End If

                        If strJS <> "" Then
                            Me.BodyTag.Attributes("OnLoad") = strJS
                        End If

                    Catch ex As Exception
                        Me.ShowMessage("Error!<BR />" & ex.Message.ToString())
                    Finally

                    End Try

                    'butCancelAlert.Attributes.Add("OnClick", "Javascript:if (confirm('Are you sure you want to cancel the email alert?')) window.close()")

                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub AlertPopup(ByVal Subject As String, ByVal Body As String)
        Dim oAlerts As cAlerts = New cAlerts(Session("ConnString"))
        Dim oEmp As cEmployee = New cEmployee(CStr(Session("ConnString")))
        Dim TheseGroups As New wvEmailGroups
        Dim ThisGroup As New wvEmailGroup
        Dim ThisEmployee As New wvEmployee
        'Dim otree As New obout_ASPTreeView_2_NET.Tree
        Dim DefaultGroup As String = ""
        Dim DefaultChecked As String

        If ddEmailGroup <> "" Then
            DefaultGroup = ddEmailGroup
        End If
        Dim AutoGroup As Boolean = False
        If IsNumeric(strJobNo) = True And IsNumeric(strJobCompNo) = True Then
            AutoGroup = True
        End If
        Try
            If strJobNo.Trim() = "" Or IsNumeric(strJobNo.Trim()) = False Then
                strJobNo = "0"
            End If
            JobNumber = CType(strJobNo, Integer)
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            If strJobCompNo.Trim() = "" Or IsNumeric(strJobCompNo.Trim()) = False Then
                strJobCompNo = "0"
            End If
            JobComponentNbr = CType(strJobCompNo, Integer)
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            oAlerts.LoadEmailGroupsWebUI(DefaultGroup, Me.RadTreeView1, strClientCode, strDivCode, strProdCode, "JC", JobNumber, JobComponentNbr, AutoGroup, CmpIdentifier)
            'Me.RadTreeView1.Width = New Unit(350, UnitType.Pixel)
            'Me.RadTreeView1.Height = New Unit(320, UnitType.Pixel)
        Catch
        End Try

        Me.txtAlertSubject.Text = Subject

        Me.BodyRadEditor.Content = Body.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")

        'CallJavaScript(Me, "loadalertwindow();", "LoadAlertWindow")
    End Sub

    'ST: register a js on the page
    Public Sub CallJavaScript(ByRef aspxPage As System.Web.UI.Page, ByVal pScript As String, ByVal strKey As String)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">"
        strScript &= pScript & "</script>"
        If (Not aspxPage.IsStartupScriptRegistered(strKey)) Then
            aspxPage.RegisterStartupScript(strKey, strScript)
        End If
    End Sub

    'ST: returns substring of string passed in based on first position of a "space"
    '       used to build the tree
    Private Function FPart(ByVal pString As String)
        If pString.IndexOf(" ") > 0 Then
            Return pString.Substring(0, pString.IndexOf(" "))
        Else
            Return pString
        End If
    End Function

    'ST: Loops through the treeview to get the email recipients, then sends the mail
    Private SelectedGroups As String = ""
    Private SelectedGroupMembers As String = ""

    Private Sub SetSelected()
        For Each node As Telerik.Web.UI.RadTreeNode In Me.RadTreeView1.Nodes
            For Each AlertGroup As Telerik.Web.UI.RadTreeNode In node.Nodes
                If AlertGroup.Checked = True Then
                    If AlertGroup.Value.Contains("(CC)") Then
                        SelectedGroupMembers &= AlertGroup.Value & ","
                    Else
                        SelectedGroups &= AlertGroup.Value & ","
                    End If
                End If
                For Each GroupEmp As Telerik.Web.UI.RadTreeNode In AlertGroup.Nodes
                    If GroupEmp.Checked = True Then
                        SelectedGroupMembers &= GroupEmp.Value & ","
                    End If
                Next
            Next
        Next

        SelectedGroups = MiscFN.CleanStringForSplit(SelectedGroups, ",")
        SelectedGroupMembers = MiscFN.CleanStringForSplit(SelectedGroupMembers, ",")


    End Sub

    'ST: Adds alerts to database
    Private Function SendAlert() As Integer
        Try
            Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
            Dim AlertId As Integer = 0

            If strJobNo = "" Then strJobNo = ViewState("currJobNo")
            If strJobCompNo = "" Then strJobCompNo = ViewState("currJobNo")

            Dim alertBody As String = Me.BodyRadEditor.Content

            Dim IsHTML As Boolean = False
            If Not Request.QueryString("IsHTML") Is Nothing Then
                IsHTML = Request.QueryString("IsHTML")
            End If
            Dim alertBodyHTML As String = Me.BodyRadEditor.Content
            If IsHTML = True Then
                alertBodyHTML = Session("AlertPopUp_BodyHTML")
            End If


            Dim lcQSNew As String
            Dim lnQSNew As Integer
            lcQSNew = Request.QueryString("new")
            If IsNumeric(lcQSNew) Then
                lnQSNew = CType(lcQSNew, Integer)
            Else
                lnQSNew = 0
            End If


            Try

            Catch ex As Exception
            End Try
            If Request.QueryString("NewJS") <> "" Then
                If lnQSNew = 1 And Request.QueryString("NewJS") = 1 Then
                    AlertId = oAlert.AddAlerts(2, 15, Me.txtAlertSubject.Text, alertBody, Now, "", strClientCode, strDivCode, strProdCode, "",
                        strJobNo, strJobCompNo, Session("EmpCode"), "JC", Session("UserCode"))
                ElseIf lnQSNew = 1 Then
                    AlertId = oAlert.AddAlerts(2, 16, Me.txtAlertSubject.Text, alertBody, Now, "", strClientCode, strDivCode, strProdCode, "",
                        strJobNo, strJobCompNo, Session("EmpCode"), "JC", Session("UserCode"))
                Else
                    AlertId = oAlert.AddAlerts(2, 22, Me.txtAlertSubject.Text, alertBody, Now, "", strClientCode, strDivCode, strProdCode, "",
                        strJobNo, strJobCompNo, Session("EmpCode"), "JC", Session("UserCode"))
                End If
            Else
                If Me.FromApp = MiscFN.Source_App.Campaign Then
                    If lnQSNew = 1 Then
                        AlertId = oAlert.AddAlerts(2, 6, Me.txtAlertSubject.Text, alertBody, Now, strOfficeCode, strClientCode, strDivCode, strProdCode, strCmpID,
                            0, 0, Session("EmpCode"), "CM", Session("UserCode"), alertBodyHTML)
                    Else
                        AlertId = oAlert.AddAlerts(2, 7, Me.txtAlertSubject.Text, alertBody, Now, strOfficeCode, strClientCode, strDivCode, strProdCode, strCmpID,
                            0, 0, Session("EmpCode"), "CM", Session("UserCode"), alertBodyHTML)
                    End If

                Else
                    If lnQSNew = 1 Then
                        AlertId = oAlert.AddAlerts(2, 3, Me.txtAlertSubject.Text, alertBody, Now, "", strClientCode, strDivCode, strProdCode, "",
                            strJobNo, strJobCompNo, Session("EmpCode"), "JC", Session("UserCode"))
                    Else
                        AlertId = oAlert.AddAlerts(2, 4, Me.txtAlertSubject.Text, alertBody, Now, "", strClientCode, strDivCode, strProdCode, "",
                            strJobNo, strJobCompNo, Session("EmpCode"), "JC", Session("UserCode"))
                    End If
                End If

            End If

            SignalR.Classes.NotificationHub.NotifyRecipients(AlertId, Session("ConnString"), Session("UserCode"))

            Return AlertId

        Catch ex As Exception
        Finally
        End Try
    End Function

    Private Sub RadToolbarAlert_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarAlert.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Cancel"

                    Me.CloseThisWindow()

                Case "Send"

                    Try
                        Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
                        Dim oEmp As cEmployee = New cEmployee(CStr(Session("ConnString")))
                        Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
                        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                        Dim ws As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
                        Dim boolMisc As Boolean

                        boolMisc = ws.GetSMPTSettingsByUser()
                        If boolMisc = False Then
                            Me.ShowMessage(ws.getErrMsg())
                            Exit Sub
                        End If

                        Dim strUsername As String = ws.oSMTPSettings.EMAIL_USERNAME
                        Dim strPassword As String = ws.oSMTPSettings.EMAIL_PWD
                        Dim strSMTPServer As String = ws.oSMTPSettings.SMTP_SERVER
                        Dim strSMTPFromAddress As String = ws.oSMTPSettings.SMTP_SENDER
                        Dim filename As String = ""
                        Dim exclude As Boolean = False

                        Dim DefaultGroup As String
                        Dim AlertId As Integer = 0
                        Dim EmpList() As String
                        Dim i As Integer

                        Dim lcMailError As String = String.Empty

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                            If Request.QueryString("New") = 1 Then
                                AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, 2, "Job Created")
                            Else
                                AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, 2, "Job Modified")
                            End If
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                        End Using

                        If Agency.IncludeAttachmentsWithAlerts = 1 Then
                            exclude = True
                        End If

                        If AlertCategory IsNot Nothing Then
                            If AlertCategory.HasPDFAttachment = 1 AndAlso Agency.ExcludeAttachmentByDefault = 0 Then
                                filename = OutputReportFileJT()
                            End If
                        End If

                        AlertId = SendAlert()

                        Dim Document As New Document(Session("ConnString"))
                        Dim Repository As New DocumentRepository(Session("ConnString"))
                        Dim Alert As New Alert(Session("ConnString"))
                        Alert.LoadByPrimaryKey(AlertId)

                        Dim f As IO.FileInfo
                        Dim fjs As IO.FileInfo
                        If filename <> "" Then
                            f = New IO.FileInfo(filename)
                            If f.Exists Then
                                Dim realFilename As String = f.Name
                                Dim MIMEType As String
                                Select Case f.Extension.ToLower()
                                    Case ".pdf"
                                        MIMEType = "application/pdf"
                                    Case ".xls"
                                        MIMEType = "application/msexcel"
                                    Case ".txt"
                                        MIMEType = "text/plain"
                                    Case ".tiff"
                                        MIMEType = "image/tiff"
                                    Case ".rtf"
                                        MIMEType = "application/rtf"
                                    Case ".zip"
                                        MIMEType = "application/zip"
                                    Case Else
                                        MIMEType = "application/pdf"
                                End Select
                                Dim FileLength As Integer = f.Length
                                Dim FileBytes(FileLength) As Byte
                                Dim ff As IO.FileStream = f.OpenRead
                                ff.Read(FileBytes, 0, FileLength)

                                Dim RepositoryFilename As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")

                                RepositoryFilename = "a_" & Guid.NewGuid.ToString()
                                Dim DocumentId As Integer = 0
                                Try
                                    Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                    If IsNTAuth = True Then ' And HasMultipleUploads = True Then
                                        Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                    End If
                                    'db stuff here
                                    Try
                                        DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")
                                        If IsClientPortal = True Then
                                            Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                        Else
                                            Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                        End If
                                    Catch ex As Exception
                                    End Try
                                    If IsNTAuth = True Then ' And HasMultipleUploads = True Then
                                        impersonationContext.Undo()
                                    End If
                                Catch ex As Exception
                                End Try
                                Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilename)
                                ff.Close()
                            End If
                        End If

                        Me.SetSelected()

                        If SelectedGroupMembers <> "" Then
                            EmpList = SelectedGroupMembers.Split(",")
                            'jtg 2/16/10 - Added ability to print HTML body - but displays String not HTML
                            Dim IsHTML As Boolean = True

                            Dim alertBody As String = Me.BodyRadEditor.Content

                            If ddEmailGroup = String.Empty Then
                                Dim oA As Alert = New Alert(CStr(Session("ConnString")))
                                DefaultGroup = oA.GetDefaultGroup(strClientCode, strDivCode, strProdCode)
                            Else
                                DefaultGroup = ddEmailGroup
                            End If

                            If AlertId > 0 Then

                                alertBody = alertBody & AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertId, False)

                            End If

                            Dim emp As New cEmployee(Session("ConnString"))

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                                    Dim EmployeeList As New Generic.List(Of String)

                                    For i = 0 To EmpList.Length - 1
                                        Dim code As Integer
                                        Dim EmailFlag As Integer
                                        Dim ThisEmpEmail As String
                                        If EmpList(i).Contains("(CC)") Then
                                            code = oAlert.CPGetContactCodeID(EmpList(i).Replace("(CC)", ""), strClientCode)
                                            EmailFlag = oAlert.GetCPAlertEmailFlag(code)
                                            ThisEmpEmail = oAlert.GetEmail(code)
                                            oAlert.AddAlertCPRecipient(AlertId, code, ThisEmpEmail)
                                            If EmailFlag = 1 Then ' Email Only or Both 

                                                EmployeeList.Add(ThisEmpEmail)
                                                'lcMailError = Me.PopSendMail(ThisEmpEmail, Me.txtAlertSubject.Text, alertBody, filename, DbContext, SecurityDbContext, Me._Session)

                                            End If
                                        Else
                                            ThisEmpEmail = emp.GetEmail(EmpList(i))
                                            Select Case CType(emp.GetAlertEmailFlag(EmpList(i)), AlertEmailFlag)
                                                Case AlertEmailFlag.JustEmail
                                                    If Not IsDBNull(ThisEmpEmail) And ThisEmpEmail <> "" Then

                                                        EmployeeList.Add(ThisEmpEmail)
                                                        'lcMailError = Me.PopSendMail(ThisEmpEmail, Me.txtAlertSubject.Text, alertBody, filename, DbContext, SecurityDbContext, Me._Session)

                                                    End If
                                                Case AlertEmailFlag.JustAlert
                                                    oAlert.AddAlertRecipient(AlertId, EmpList(i), ThisEmpEmail)
                                                Case AlertEmailFlag.BothAlertEmail
                                                    oAlert.AddAlertRecipient(AlertId, EmpList(i), ThisEmpEmail)
                                                    If Not IsDBNull(ThisEmpEmail) And ThisEmpEmail <> "" Then

                                                        EmployeeList.Add(ThisEmpEmail)
                                                        'lcMailError = Me.PopSendMail(ThisEmpEmail, Me.txtAlertSubject.Text, alertBody, filename, DbContext, SecurityDbContext, Me._Session)

                                                    End If
                                            End Select
                                        End If
                                    Next

                                    If EmployeeList.Count > 0 Then

                                        lcMailError = Me.PopSendMail(String.Join(",", EmployeeList),
                                                                     Me.txtAlertSubject.Text,
                                                                     alertBody,
                                                                     filename,
                                                                     DbContext,
                                                                     SecurityDbContext,
                                                                     Me._Session)

                                        If String.IsNullOrWhiteSpace(lcMailError) = False Then

                                            Me.ShowMessage(lcMailError)

                                        End If

                                    End If

                                End Using

                            End Using

                        Else
                            'reselect default
                            Try
                                If Me.ddEmailGroup.Trim() <> "" Then
                                    For Each node As Telerik.Web.UI.RadTreeNode In Me.RadTreeView1.Nodes
                                        For Each AlertGroup As Telerik.Web.UI.RadTreeNode In node.Nodes
                                            If AlertGroup.Value = ddEmailGroup.Trim() Then
                                                AlertGroup.Checked = True
                                                For Each GroupEmp As Telerik.Web.UI.RadTreeNode In AlertGroup.Nodes
                                                    GroupEmp.Checked = True
                                                Next
                                                Exit Try
                                            End If
                                        Next
                                    Next
                                End If
                            Catch ex As Exception
                            End Try

                            Dim txt As String
                            If Me.FromApp = MiscFN.Source_App.Campaign Then
                                txt = "Please select at least one email address before trying to send an email alert.\nIf this campaign has a default email group, it has been re-selected."
                            Else
                                txt = "Please select at least one email address before trying to send an email alert.\nIf this component has a default email group, it has been re-selected."
                            End If

                            Me.ShowMessage(MiscFN.JavascriptSafe(txt))
                            Exit Sub

                        End If

                        Me.RefreshAlertWindows(False, True, False)

                        If lcMailError = String.Empty Or InStr(lcMailError, "Client host rejected") > 0 Or lcMailError = "" Then

                            Me.CloseThisWindow()

                        Else

                            Me.ShowMessage(MiscFN.JavascriptSafe(lcMailError))
                            Exit Sub

                        End If

                    Catch ex As Exception
                        If InStr(ex.Message.ToString(), "Client host rejected") > 0 Then 'unavoidable smtp spam guard on some servers when too many emails sent

                            Me.CloseThisWindow()

                        Else

                            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString))

                        End If
                    Finally

                    End Try

                    If Not Request.QueryString("IsHTML") Is Nothing Then

                        Session("AlertPopUp_BodyHTML") = ""
                        Session("IsHTML") = False

                    End If

                Case "Diary"

                    Try

                        Dim i As Integer = SendAlert()
                        If i > 0 Then

                            Me.CloseThisWindow()

                        End If

                    Catch ex As Exception

                        Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))

                    Finally

                    End Try

            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Function PopSendMail(ByVal [strTo] As String,
                                 ByVal [Subject] As String,
                                 ByVal [Body] As String,
                                 ByVal [strAttachment] As String,
                                 ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                 ByVal Session As AdvantageFramework.Security.Session) As String

        Dim Completed As Boolean = False
        Dim AttachmentFiles As New Generic.List(Of String)
        Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
        Dim ExceptionMessage As String = String.Empty

        AttachmentFiles.Add(strAttachment)

        Try

            Completed = AdvantageFramework.Email.Send(DbContext,
                                                      SecurityDbContext,
                                                      strTo,
                                                      Subject,
                                                      Body,
                                                      3,
                                                      AttachmentFiles.ToArray,
                                                      SendingEmailStatus,
                                                      ExceptionMessage,
                                                      "",
                                                      "",
                                                      Session.User.EmployeeCode)

        Catch ex As Exception
            Completed = False
            If String.IsNullOrWhiteSpace(ExceptionMessage) = True Then
                ExceptionMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End If
        End Try

        If Completed = True Then

            ExceptionMessage = String.Empty

        End If

        Return ExceptionMessage

    End Function
    Private Function OutputReportFileJT() As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder
            Dim location As AdvantageFramework.Database.Entities.Location = Nothing

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append("JobOrder_")
            sb1.Append(Me.JobNumber)
            sb1.Append("_")
            sb1.Append(Me.JobComponentNbr)
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            sbReportName.Append(Request.QueryString("Report"))

            Dim oReports As New cReports(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim i As Integer
            Dim s As String
            Dim li As New Telerik.Web.UI.RadComboBoxItem
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            dr = oReports.GetJobOrderFormSettings(Session("UserCode"))
            If dr.HasRows = True Then
                Do While dr.Read
                    Try
                        If dr("LOCATION_ID") <> "" And dr("LOCATION_ID") <> "None" Then
                            Using DbContext = New AdvantageFramework.Database.DataContext(Session("ConnString"), Session("UserCode"))
                                location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DbContext, dr("LOCATION_ID"))
                            End Using
                            Session("JobOrderFormLogoLocation") = location.LogoPath
                            Session("JobOrderFormLogoLocationID") = dr("LOCATION_ID")
                        Else
                            Session("JobOrderFormLogoLocation") = ""
                            Session("JobOrderFormLogoLocationID") = "None"
                        End If

                    Catch ex As Exception

                    End Try

                    s = dr.GetString(11)
                    If s = "0" Then
                        Session("JobOrderFormLogoPlacement") = 1
                    ElseIf s = "1" Then
                        Session("JobOrderFormLogoPlacement") = 3
                    ElseIf s = "2" Then
                        Session("JobOrderFormLogoPlacement") = 2
                    Else
                        Session("JobOrderFormLogoPlacement") = 1
                    End If

                    i = dr.GetInt16(6)
                    If i = 1 Then
                        Session("OmitEFReport") = True
                    End If
                    i = dr.GetInt16(17)
                    If i = 1 Then
                        Session("IncludeTAReport") = True
                    End If
                    Session("TASectionTitle") = dr.GetString(18)
                    i = dr.GetInt16(2)
                    If i = 1 Then
                        Session("IncludeTSReport") = True
                    End If
                    Session("TSSectionTitle") = dr.GetString(7)
                    i = dr.GetInt16(4)
                    If i = 1 Then
                        Session("TSDueDatesOnly") = True
                    End If
                    i = dr.GetInt16(3)
                    If i = 1 Then
                        Session("TSMilestonesOnly") = True
                    End If
                    i = dr.GetInt16(5)
                    If i = 1 Then
                        Session("TSEmpAssignments") = True
                    End If
                    Session("TSMilestoneTitle") = dr.GetString(8)

                    i = dr.GetInt16(15)
                    If i = 1 Then
                        Session("JSPrintSpecs") = True
                    End If
                    i = dr.GetInt16(16)
                    If i = 1 Then
                        Session("JSApproveOnly") = True
                    End If
                    Session("JSReportTitle") = dr.GetString(10)

                    i = dr.GetInt16(20)
                    If i = 1 Then
                        Session("JSIncludeVS") = True
                    End If

                    i = dr.GetInt16(21)
                    If i = 1 Then
                        Session("JSIncludeMS") = True
                    End If

                Loop
            End If
            dr.Close()

            Session("JobOrderFormJobNum") = Me.JobNumber
            Session("JobOrderFormJobCompNum") = Me.JobComponentNbr
            Session("IncludeJOFReport") = True

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), "joborder", "", "", "", "", "", 1, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function

End Class
