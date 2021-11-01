Imports Webvantage.cGlobals.Globals

Public Class OpenJobs_Settings
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_OpenJobsRTP)

        If Me.IsPostBack = True Then

        Else
            If Not Request.QueryString("nodata") Is Nothing Then
                Me.ShowMessage("No Data Found For Selected Inputs")
                Me.lbReports.Focus()
            End If
            LoadClientList()
            LoadOfficeList()

        End If
        ddClientList.Attributes.Add("onclick", "checkIndex(document.getElementById(""" & Me.ddClientList.ClientID & """));")
        lbOffice.Attributes.Add("onclick", "checkIndex(document.getElementById(""" & Me.lbOffice.ClientID & """));")

        If Me.IsClientPortal = True Then
            Me.PanelOffice.Visible = False
            Me.PanelClient.Visible = False
        End If
    End Sub
    Private Sub LoadClientList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.ddClientList.DataSource = oDropDowns.GetClientList(Session("UserCode"))
        Me.ddClientList.DataTextField = "Description"
        Me.ddClientList.DataValueField = "Code"
        Me.ddClientList.DataBind()
        Me.ddClientList.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Clients", "%"))
        If Me.ddClientList.Items.Count > 0 Then
            Me.ddClientList.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadOfficeList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.lbOffice.DataSource = oDropDowns.GetOfficesEmp(Session("UserCode"))
        Me.lbOffice.DataTextField = "Description"
        Me.lbOffice.DataValueField = "Code"
        Me.lbOffice.DataBind()
        Me.lbOffice.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Offices", "%"))
        If Me.lbOffice.Items.Count > 0 Then
            Me.lbOffice.SelectedIndex = 0
        End If
    End Sub

    Private Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click
        Dim ddl As Telerik.Web.UI.RadComboBox
        Dim strURL As String
        ddl = reporttype.FindControl("RadComboBoxReportType")
        Dim i As Integer
        Dim OfficeCodes As String
        Dim ClientCodes As String
        Dim IsSchedIncluded As Boolean = False


        If Me.IsClientPortal = True Then
            ClientCodes = Session("CL_CODE")
        Else
            If Me.ddClientList.Items(0).Selected Then
                ClientCodes = ""
            Else
                For i = 0 To Me.ddClientList.Items.Count - 1
                    If Me.ddClientList.Items(i).Selected Then
                        ClientCodes &= Me.ddClientList.Items(i).Value & ","

                    End If
                Next
            End If
            If Me.lbOffice.Items(0).Selected Then
                OfficeCodes = ""
            Else
                For i = 0 To Me.lbOffice.Items.Count - 1
                    If Me.lbOffice.Items(i).Selected Then
                        OfficeCodes &= Me.lbOffice.Items(i).Value & ","
                    End If
                Next
            End If
        End If

        If Me.cbCompSchedule.Checked Then
            IsSchedIncluded = True
        End If

        Dim StartDate As Date = Nothing
        Dim EndDate As Date = Nothing
        If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = True Then
            If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing Then
                StartDate = Me.RadDatePickerStartDate.SelectedDate
            Else
                StartDate = LoGlo.FormatDate("01/01/1950")
            End If
        Else
            Me.ShowMessage("Invalid Start Date")
            Exit Sub
        End If
        If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = True Then
            If Not Me.RadDatePickerEndDate.SelectedDate Is Nothing Then
                EndDate = Me.RadDatePickerEndDate.SelectedDate
            Else
                EndDate = LoGlo.FormatDate("01/01/2050")
            End If
        Else
            Me.ShowMessage("Invalid End Date")
            Exit Sub
        End If

        If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing And Not Me.RadDatePickerEndDate.SelectedDate Is Nothing Then
            If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("Invalid Date Range")
                Exit Sub
            End If
        End If

        strURL = "popReportViewer.aspx?UserID=" & CStr(Session("UserCode")) & "&ClientCode=" & ClientCodes & "&Type=" & ddl.SelectedItem.Value & "&Report=" & lbReports.SelectedItem.Value & "&Office=" & OfficeCodes & "&sdate=" & StartDate.ToShortDateString() & "&edate=" & EndDate.ToShortDateString() & "&schedincld=" & IsSchedIncluded.ToString() & "&cp=" & Me.IsClientPortal
        Response.Redirect(strURL)

    End Sub

End Class