Imports Webvantage.cGlobals.Globals

Partial Public Class Campaign_Print
    Inherits Webvantage.BasePrintSendPage

    Private _CmpIdentifier As Integer = 0

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        If Not Request.QueryString("cmp") Is Nothing AndAlso IsNumeric(Request.QueryString("cmp")) = True Then
            Me._CmpIdentifier = Request.QueryString("cmp")
        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.CampaignIdentifier > 0 Then Me._CmpIdentifier = qs.CampaignIdentifier

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Print Campaign"
        If Not IsPostBack Then

            Me.ddlFormat.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("PDF"), CStr("1")))
            FillLocationDropDown()
            LoadCampaign()
            LoadSettings()
        End If
    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.CurrentPageMode
            Case PageMode.Print

                Me.Print()
                Me.CloseThisWindow()

            Case PageMode.SendAlert

                Me.SendAlert()
                Me.CloseThisWindow()

            Case PageMode.SendAssignment

                Me.SendAlert(False, True)
                Me.CloseThisWindow()

            Case PageMode.SendEmail

                Me.SendAlert(True, False)
                'Me.CloseThisWindow()

            Case Else

        End Select

    End Sub

    Private Sub LoadCampaign()

        'objects
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me._CmpIdentifier)

            If Campaign IsNot Nothing Then

                Me.TxtOffice.Text = Campaign.OfficeCode
                Me.TxtOfficeDescription.Text = If(Campaign.Office IsNot Nothing, Campaign.Office.Name, "")
                Me.TxtClientCode.Text = Campaign.ClientCode
                Me.TxtClientDescription.Text = Campaign.Client.Name
                Me.TxtDivisionCode.Text = Campaign.DivisionCode
                Me.TxtDivisionDescription.Text = If(Campaign.Division IsNot Nothing, Campaign.Division.Name, "")
                Me.TxtProductCode.Text = Campaign.ProductCode
                Me.TxtProductDescription.Text = If(Campaign.Product IsNot Nothing, Campaign.Product.Name, "")
                Me.TxtCmpNum.Text = Campaign.Code
                Me.TxtCmpDescription.Text = Campaign.Name

                If Campaign.StartDate.HasValue Then

                    Me.RadDatePickerStartDate.SelectedDate = Campaign.StartDate

                End If

                If Campaign.EndDate.HasValue Then

                    Me.RadDatePickerEndDate.SelectedDate = Campaign.EndDate

                End If

            End If

        End Using

    End Sub

    Private Sub FillLocationDropDown()
        Me.dl_location.Items.Clear()
        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
        Me.dl_location.DataSource = oReports.GetLocationPO
        Me.dl_location.DataTextField = "ID"
        Me.dl_location.DataValueField = "LOGO_PATH"
        Me.dl_location.DataBind()
        Me.dl_location.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
    End Sub

    Private Sub SaveSettings()
        Dim oAppVars As New cAppVars(cAppVars.Application.CAMPAIGN_PRINT)
        oAppVars.getAllAppVars() 'All may not be in database

        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Try
            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                Me.ShowMessage("Invalid Start Date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                Me.ShowMessage("Invalid End Date")
                Exit Sub
            End If
            If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("Invalid date range")
                Exit Sub
            End If
            If wvCDate(Me.RadDatePickerEndDate.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStartDate.SelectedDate)).Days > 365 Then
                Me.ShowMessage("Date range must be less than year.")
                Exit Sub
            End If

            oAppVars.setAppVar("startdate", CStr(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), "Date")
            oAppVars.setAppVar("enddate", CStr(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), "Date")
            oAppVars.setAppVar("startperiod", Me.TxtStartPeriod.Text)
            oAppVars.setAppVar("endperiod", Me.TxtEndPeriod.Text)

            'Save all vars to database
            oAppVars.SaveAllAppVars()

        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

    End Sub

    Private Sub LoadSettings()
        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.CAMPAIGN_PRINT)
            oAppVars.getAllAppVars()

            Me.RadDatePickerStartDate.SelectedDate = CType(oAppVars.getAppVar("startdate"), Date)
            Me.RadDatePickerEndDate.SelectedDate = CType(oAppVars.getAppVar("enddate"), Date)
            Me.TxtStartPeriod.Text = oAppVars.getAppVar("startperiod")
            Me.TxtEndPeriod.Text = oAppVars.getAppVar("endperiod")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadToolbarCampaignPrint_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCampaignPrint.ButtonClick
        Select Case e.Item.Value
            Case "Print"

                Me.Print()

            Case "Save"

                SaveSettings()

            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "Back"

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub Print()

        SaveSettings()

        Dim ar() As String
        Try
            If Me.dl_location.SelectedItem.Text = "None" Then
                Session("CampaignLogoLocation") = ""
                Session("CampaignLogoLocationID") = "None"
            Else
                ar = dl_location.SelectedValue.ToString.Split("|")
                Session("CampaignLogoLocation") = ar(1)
                Session("CampaignLogoLocationID") = ar(0)
            End If
        Catch ex As Exception
            Session("CampaignLogoLocation") = ""
        End Try

        Dim strURL As String = "popReportViewer.aspx?cmp=" & Me._CmpIdentifier & "&StartPeriod=" & TxtStartPeriod.Text & "&EndPeriod=" & TxtEndPeriod.Text & "StartDate=" & CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString() & "EndDate=" & CType(Me.RadDatePickerEndDate.SelectedDate, Date).ToShortDateString() & "&Report=Campaign" & "&Type=" & ddReportFormat.SelectedValue
        Response.Redirect(strURL.ToString())

    End Sub
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)

        SaveSettings()

        Dim ar() As String

        Try
            If Me.dl_location.SelectedItem.Text = "None" Then
                Session("CampaignLogoLocation") = ""
                Session("CampaignLogoLocationID") = "None"
            Else
                ar = dl_location.SelectedValue.ToString.Split("|")
                Session("CampaignLogoLocationID") = ar(0)
                Session("CampaignLogoLocation") = ar(1)
            End If
        Catch ex As Exception
            Session("CampaignLogoLocation") = ""
            Session("CampaignLogoLocationID") = "None"
        End Try

        Dim EmailSwitch As String = ""

        If AsEmail = True Then

            EmailSwitch = "eml=1&"

        Else

            EmailSwitch = "eml=0&"

        End If
        If IsAssignment = True Then 'assignment switch overrides email switch

            EmailSwitch = "eml=0&assn=1&"

        End If
        Try

            Dim strURL As String = "Alert_New.aspx?caller=CampaignPrint&" & EmailSwitch & "send=1&cmp=" & Me._CmpIdentifier & "&pagetype=cmp" & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.Campaign)

            If IsAssignment = True Then

                strURL = strURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")
                Me.OpenWindow("New Assignment", strURL)

            Else

                Me.OpenWindow("New Alert", strURL)

            End If

        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try

    End Sub

End Class
