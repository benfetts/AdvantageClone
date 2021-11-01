Imports Webvantage.cGlobals.Globals
Imports System.Data.SqlClient

Partial Public Class ProjectHoursUsed_Settings
    Inherits Webvantage.BaseChildPage

    Dim intClient As Int32
    Dim intDiv As Int32

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_ProjectHoursRTP)
        lbl_msg.Text = ""
        Dim oReports As New cReports(Session("ConnString"))
        If Page.IsPostBack = False Then
            'If Not Request.QueryString("nodata") Is Nothing Then
            '    lbl_msg.Text = "No Data Found For Selected Inputs"
            'End If

            InitSelection()
            InitFilter()
            LoadTrafficStatus()
            LoadManagers()
            LoadJobs()
            Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
            If str <> "" Or Not str Is Nothing Then
                Me.lblManager.Text = str & ":"
            End If
            Me.pnlClient.Visible = False
            Me.pnlDivision.Visible = False
            Me.pnlProduct.Visible = False
            Me.lstClient.ClearSelection()
            Me.lstDivision.ClearSelection()
            Me.lstProduct.ClearSelection()
            'If Not Request.Cookies("projectusedhours") Is Nothing Then
            LoadSettings()
            'End If
        Else

        End If
    End Sub
    Private Sub LoadTrafficStatus()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("Connstring"))
        Me.lbStatus.DataSource = oDropDowns.GetTrafficCodes()
        Me.lbStatus.DataTextField = "Description"
        Me.lbStatus.DataValueField = "Code"
        Me.lbStatus.DataBind()
        Me.lbStatus.SelectionMode = ListSelectionMode.Multiple
        Me.lbStatus.Enabled = False
    End Sub
    Private Sub LoadManagers()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.ddManager
            .DataSource = odd.GetManagers(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

    End Sub
    Private Sub LoadJobs()
        Dim oReport As cReports = New cReports(CStr(Session("ConnString")))
        Dim ds As DataSet
        Dim JobSQL As String
        Dim strWhereClient As String
        Dim strWhereDivision As String
        Dim strWhereProduct As String
        Dim FirstPass As Boolean
        Dim strsplit As String() = Nothing
        JobSQL = "	SELECT DISTINCT JOB_LOG.JOB_NUMBER as Code, str(JOB_LOG.JOB_NUMBER) + ' - ' + isnull(JOB_LOG.JOB_DESC, '') as Description FROM JOB_LOG INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER "
        strWhereClient = ""
        strWhereDivision = ""
        strWhereProduct = ""

        Dim sy As New cSecurity(Session("ConnString"))
        Try
            If sy.UserHasOfficeRestrictions(Session("EmpCode")) = True Then
                JobSQL &= " INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & Session("EmpCode") & "' "
            End If
            If sy.HasClientRestrictions(Session("UserCode")) = True Then
                JobSQL &= " INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE "
            End If
        Catch ex As Exception
        End Try

        Select Case Me.optCDP.SelectedValue
            Case "c"
                If Not Me.lstClient.SelectedItem Is Nothing Then
                    strWhereClient = "[CL_CODE] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstClient.Items
                        If ThisItem.Selected = True Then
                            If FirstPass = True Then
                                strWhereClient &= "'" & ThisItem.Value & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & ThisItem.Value & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                End If
            Case "d"
                If Not Me.lstDivision.SelectedItem Is Nothing Then
                    strWhereClient = "[CL_CODE] IN ("
                    'Another misspelling that has always existed in previouse 1.x version of webv
                    'strWhereDivision = "[DIV_CODEe] IN ("
                    strWhereDivision = "[DIV_CODE] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstDivision.Items
                        If ThisItem.Selected = True Then
                            strsplit = ThisItem.Value.Split(":")
                            If FirstPass = True Then
                                strWhereClient &= "'" & strsplit(0) & "'"
                                strWhereDivision &= "'" & strsplit(1) & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & strsplit(0) & "'"
                                strWhereDivision &= ",'" & strsplit(1) & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                    strWhereDivision &= ")"
                End If

            Case "p"
                If Not Me.lstProduct.SelectedItem Is Nothing Then
                    strWhereClient = "[CL_CODE] IN ("
                    strWhereDivision = "[DIV_CODE] IN ("
                    strWhereProduct = "[PRD_CODE] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstProduct.Items
                        If ThisItem.Selected = True Then
                            strsplit = ThisItem.Value.Split(":")
                            If FirstPass = True Then
                                strWhereClient &= "'" & strsplit(0) & "'"
                                strWhereDivision &= "'" & strsplit(1) & "'"
                                strWhereProduct &= "'" & strsplit(2) & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & strsplit(0) & "'"
                                strWhereDivision &= ",'" & strsplit(1) & "'"
                                strWhereProduct &= ",'" & strsplit(2) & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                    strWhereDivision &= ")"
                    strWhereProduct &= ")"
                End If
        End Select

        JobSQL &= " Where (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (0)) AND (JOB_LOG.COMP_OPEN = 1) "

        If sy.HasClientRestrictions(Session("UserCode")) = True Then
            JobSQL &= " AND (UPPER(SEC_CLIENT.USER_ID) = UPPER('" & Session("UserCode") & "')) "
        End If

        If strWhereClient <> "" Or strWhereDivision <> "" Or strWhereProduct <> "" Then
            If strWhereClient <> "" Then
                JobSQL &= " AND " & strWhereClient
                If strWhereDivision <> "" Then
                    JobSQL &= " AND " & strWhereDivision
                    If strWhereProduct <> "" Then
                        JobSQL &= " AND " & strWhereProduct
                    End If
                End If
            End If
        End If

        ds = oReport.GetDSfromSQL(JobSQL & " Order By JOB_LOG.JOB_NUMBER DESC")
        With Me.lbJobs
            .DataSource = ds
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            '.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With
        Me.lbJobs.Enabled = False
    End Sub
    Private Sub InitFilter()
        'Date Range
        Me.RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday
        Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday
    End Sub
    Private Sub InitSelection()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))


        Me.optCDP.Items(0).Selected = True
        Me.pnlClient.Visible = False
        Me.pnlDivision.Visible = False
        Me.pnlProduct.Visible = False
        'Me.txtStartDate.Enabled = false
        'Me.txtEndDate.Enabled = False


        Me.lstClient.DataSource = oDD.GetClientList(Session("UserCode"))
        Me.lstClient.DataTextField = "Description"
        Me.lstClient.DataValueField = "Code"
        Me.lstClient.DataBind()
        Me.lstDivision.DataSource = oDD.GetDivisionsAll(Session("UserCode"))
        Me.lstDivision.DataTextField = "Description"
        Me.lstDivision.DataValueField = "Code"
        Me.lstDivision.DataBind()
        Me.lstProduct.DataSource = oDD.GetProductsAll(Session("UserCode"))
        Me.lstProduct.DataTextField = "Description"
        Me.lstProduct.DataValueField = "Code"
        Me.lstProduct.DataBind()

    End Sub

    Private Sub optCDP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCDP.SelectedIndexChanged
        Select Case Me.optCDP.SelectedValue
            Case "a"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = False
                Me.lstClient.ClearSelection()
                Me.lstDivision.ClearSelection()
                Me.lstProduct.ClearSelection()
                Me.optCDP.Focus()
            Case "c"
                Me.pnlClient.Visible = True
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = False
                Me.lstDivision.ClearSelection()
                Me.lstProduct.ClearSelection()
                Me.lstClient.Focus()
            Case "d"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = True
                Me.pnlProduct.Visible = False
                Me.lstClient.ClearSelection()
                Me.lstProduct.ClearSelection()
                Me.lstDivision.Focus()
            Case "p"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = True
                Me.lstClient.ClearSelection()
                Me.lstDivision.ClearSelection()
                Me.lstProduct.Focus()
        End Select
        LoadJobs()
        'ChangeFilterSettings()
    End Sub
    Private Sub rdlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlStatus.SelectedIndexChanged
        Dim i As Integer
        If Me.rdlStatus.Items(0).Selected = True Then
            For i = 0 To Me.lbStatus.Items.Count - 1
                If Me.lbStatus.Items(i).Selected = True Then
                    Me.lbStatus.Items(i).Selected = False
                End If
            Next
            lbStatus.Enabled = False
            rdlStatus.Focus()
        Else
            lbStatus.Enabled = True
            lbStatus.Focus()
        End If
    End Sub
    Private Sub rblJobs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblJobs.SelectedIndexChanged
        Try
            Dim i As Integer
            If Me.rblJobs.Items(0).Selected = True Then
                For i = 0 To Me.lbJobs.Items.Count - 1
                    If Me.lbJobs.Items(i).Selected = True Then
                        Me.lbJobs.Items(i).Selected = False
                    End If
                Next
                lbJobs.Enabled = False
                rblJobs.Focus()
            Else
                lbJobs.Enabled = True
                lbJobs.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click
        Dim strURL As String
        Dim I As Integer
        Dim strFilter As String
        Dim sort As String
        Dim openonly As Integer
        Dim group As Integer
        Try
            Try

                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                    Me.ShowMessage("Invalid Start Date")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then
                    Me.ShowMessage("Invalid End Date")
                    Exit Sub
                End If
                If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                    Me.ShowMessage("Invalid date range")
                End If
            Catch ex As Exception
                Me.ShowMessage("Error validating date: " & ex.Message.ToString())
            End Try
            strFilter = MakeSql()

            If rbNone.Checked = True Then
                sort = "1"
            End If
            If rbJC.Checked = True Then
                sort = "2"
            End If
            If rbEmp.Checked = True Then
                sort = "3"
            End If
            If rbCDPC.Checked = True Then
                sort = "4"
            End If

            If Me.cbIncludeOpenJobOnly.Checked = True Then
                openonly = 1
            Else
                openonly = 0
            End If

            If Me.CheckBoxGroup.Checked = True Then
                group = 1
            ElseIf Me.CheckBoxGroupCampaign.Checked = True Then
                group = 2
            Else
                group = 0
            End If
            Dim AEParm As String
            'AEParm = "&AECodes="

            Dim oReports As New cReports(Session("ConnString"))
            Dim dt As DataTable
            'If Me.txtStartDate.Text = "" And Me.txtEndDate.Text = "" Then
            '    dt = oReports.GetProjectHoursUsed(Session("UserCode"), "01/01/1950", "01/01/2050", sort, openonly, group)
            'Else
            dt = oReports.GetProjectHoursUsed(Session("UserCode"), wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString, wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString, sort, openonly, group)
            'End If
            Dim MainDView As DataView
            MainDView = New DataView(dt)
            MainDView.RowFilter = strFilter
            If MainDView.Count = 0 Then
                'If rdlDueDate.Items(0).Selected Then
                'InitFilter()
                'End If
                Me.lbl_msg.Text = "No Data Found For Selected Inputs"
                Exit Sub
            End If
            Try
                If Me.chkSaveSettings.Checked = True Then
                    SaveSettings()
                End If

            Catch ex As Exception
                Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
            End Try


            'If Me.CheckBoxGroup.Checked = True Then
            Session("rptProjectHoursStrFilter") = strFilter

            strURL = "ProjectHoursUsed_Render.aspx?export=1&From=projecthours&sort=" & sort & "&openonly=" & openonly
            'If Me.CheckBoxGroup.Checked = False Then
            strURL &= "&group=" & group
            'End If
            strURL &= "&StartDate=" & wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString
            strURL &= "&EndDate=" & wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString
            strURL &= "&" & Me.chkClient.ID & "=" & CInt(Me.chkClient.Checked).ToString
            strURL &= "&" & Me.chkClientName.ID & "=" & CInt(Me.chkClientName.Checked).ToString
            strURL &= "&" & Me.chkDivision.ID & "=" & CInt(Me.chkDivision.Checked).ToString
            strURL &= "&" & Me.chkDivisionName.ID & "=" & CInt(Me.chkDivisionName.Checked).ToString
            strURL &= "&" & Me.chkProduct.ID & "=" & CInt(Me.chkProduct.Checked).ToString
            strURL &= "&" & Me.chkProductName.ID & "=" & CInt(Me.chkProductName.Checked).ToString
            strURL &= "&" & Me.chkJob.ID & "=" & CInt(Me.chkJob.Checked).ToString
            strURL &= "&" & Me.chkJobDesc.ID & "=" & CInt(Me.chkJobDesc.Checked).ToString
            strURL &= "&" & Me.chkComponent.ID & "=" & CInt(Me.chkComponent.Checked).ToString
            strURL &= "&" & Me.chkJobCompDesc.ID & "=" & CInt(Me.chkJobCompDesc.Checked).ToString
            strURL &= "&" & Me.chkEmp.ID & "=" & CInt(Me.chkEmp.Checked).ToString
            strURL &= "&" & Me.chkHoursPosted.ID & "=" & CInt(Me.chkHoursPosted.Checked).ToString
            strURL &= "&" & Me.chkHoursAssigned.ID & "=" & CInt(Me.chkHoursAssigned.Checked).ToString
            strURL &= "&" & Me.chkTotalHoursPosted.ID & "=" & CInt(Me.chkTotalHoursPosted.Checked).ToString
            strURL &= "&" & Me.chkCampaign.ID & "=" & CInt(Me.chkCampaign.Checked).ToString
            strURL &= "&" & Me.chkCampaignName.ID & "=" & CInt(Me.chkCampaignName.Checked).ToString

            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=no,resizable=no,menubar=no,maximazable=yes')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            RegisterStartupScript("newpage", strBuilder.ToString())
            'Response.Redirect(strURL.ToString())
            'Else
            'dt = MainDView.ToTable
            'If Me.chkJob.Checked = False Then
            '    dt.Columns.Remove("Job Number")
            'End If
            'If Me.chkJobDesc.Checked = False Then
            '    dt.Columns.Remove("Job Name")
            'End If
            'If Me.chkComponent.Checked = False Then
            '    dt.Columns.Remove("Component Number")
            'End If
            'If Me.chkJobCompDesc.Checked = False Then
            '    dt.Columns.Remove("Component Name")
            'End If
            'If Me.chkClient.Checked = False Then
            '    dt.Columns.Remove("Client Code")
            'End If
            'If Me.chkClientName.Checked = False Then
            '    dt.Columns.Remove("Client Name")
            'End If
            'If Me.chkDivision.Checked = False Then
            '    dt.Columns.Remove("Division Code")
            'End If
            'If Me.chkDivisionName.Checked = False Then
            '    dt.Columns.Remove("Division Name")
            'End If
            'If Me.chkProduct.Checked = False Then
            '    dt.Columns.Remove("Product Code")
            'End If
            'If Me.chkProductName.Checked = False Then
            '    dt.Columns.Remove("Product Name")
            'End If
            'If Me.chkEmp.Checked = False Then
            '    dt.Columns.Remove("Employee Name")
            'End If
            'If Me.chkHoursPosted.Checked = False Then
            '    dt.Columns.Remove("Hours Posted")
            'End If
            'If Me.chkHoursAssigned.Checked = False Then
            '    dt.Columns.Remove("Hours Assigned")
            'End If
            'If Me.chkTotalHoursPosted.Checked = False Then
            '    dt.Columns.Remove("Total Hours Posted")
            'End If
            'dt.Columns.Remove("Employee Code")
            'dt.Columns.Remove("Hours Allowed")
            'dt.Columns.Remove("TRF_CODE")
            'dt.Columns.Remove("MGR_EMP_CODE")
            'dt.Columns.Remove("JOBPAD")
            'dt.Columns.Remove("COMPPAD")
            'Convertds(dt)
            'End If


        Catch ex As Exception

        End Try


        'If Me.rbJC.Checked = True Then
        '    strURL = "popReportViewer.aspx?Report=SumRepByClientSalesClass"
        'Else
        '    strURL = "popReportViewer.aspx?Report=SumRepByClient"
        'End If
        'strURL &= "&UserID=" & Session("UserCode")
        ''strURL &= "&Filter=" & Me.Me.Sanitize(strFilter)
        'Session("ProjectSummaryRPT") = strFilter
        '' If rdlDueDate.Items(1).Selected Then
        'strURL &= "&StartDate=" & wvCDate(Me.txtStartDate.Text).ToShortDateString
        'strURL &= "&EndDate=" & wvCDate(Me.txtEndDate.Text).ToShortDateString
        ''Else
        ''    strURL &= "&StartDate=" & "01/01/1950"
        ''    strURL &= "&EndDate=" & "01/01/2050"
        ''End If

        'strURL &= "&division=" & Me.chkDivision.Checked
        'strURL &= "&product=" & Me.chkProduct.Checked
        'strURL &= "&jobdesc=" & Me.chkJobDesc.Checked
        'strURL &= "&component=" & Me.chkComponent.Checked
        'strURL &= "&jobcompdesc=" & Me.chkJobCompDesc.Checked
        'strURL &= "&title=" & Me.txtReportTitle.Text
        'Dim ddl As Telerik.Web.UI.RadComboBox
        'ddl = reporttype.FindControl("ddlReportType")
        'strURL &= "&Type=" & ddl.SelectedValue
        'Response.Redirect(strURL)


    End Sub
    Private Sub SaveSettings()
        'Report Options
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_HRS_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                    .setAppVar("StartDate", Me.RadDatePickerStartDate.SelectedDate)
                Else
                    .setAppVar("StartDate", "")
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                    .setAppVar("EndDate", Me.RadDatePickerEndDate.SelectedDate)
                Else
                    .setAppVar("EndDate", "")
                End If

                .setAppVar("client", Me.chkClient.Checked)
                .setAppVar("clientname", Me.chkClientName.Checked)
                .setAppVar("division", Me.chkDivision.Checked)
                .setAppVar("divisionname", Me.chkDivisionName.Checked)
                .setAppVar("product", Me.chkProduct.Checked)
                .setAppVar("productname", Me.chkProductName.Checked)
                .setAppVar("campaign", Me.chkCampaign.Checked)
                .setAppVar("campaignname", Me.chkCampaignName.Checked)
                .setAppVar("job", Me.chkJob.Checked)
                .setAppVar("jobdesc", Me.chkJobDesc.Checked)
                .setAppVar("component", Me.chkComponent.Checked)
                .setAppVar("jobcompdesc", Me.chkJobCompDesc.Checked)
                .setAppVar("hoursassigned", Me.chkHoursAssigned.Checked)
                .setAppVar("totalhours", Me.chkTotalHoursPosted.Checked)
                .setAppVar("openjobsonly", Me.cbIncludeOpenJobOnly.Checked)
                .setAppVar("groupjc", Me.CheckBoxGroup.Checked)
                .setAppVar("groupcmp", Me.CheckBoxGroupCampaign.Checked)
                .SaveAllAppVars()
            End With
            'Response.Cookies("projectusedhours").Expires = Now.AddYears(1)

            'Response.Cookies("projectusedhours")("division") = Me.chkDivision.Checked

            'If Me.txtStartDate.Text <> "" AndAlso Me.txtStartDate.Text <> "01/01/1950" Then
            '    Response.Cookies("projectusedhours")("StartDate") = wvCDate(Me.txtStartDate.Text)
            'Else
            '    Response.Cookies("projectusedhours")("StartDate") = ""
            'End If
            'If Me.txtEndDate.Text <> "" AndAlso Me.txtEndDate.Text <> "01/01/2050" Then
            '    Response.Cookies("projectusedhours")("EndDate") = wvCDate(Me.txtEndDate.Text)
            'Else
            '    Response.Cookies("projectusedhours")("EndDate") = ""
            'End If
            'Response.Cookies("projectusedhours")("client") = Me.chkClient.Checked
            'Response.Cookies("projectusedhours")("clientname") = Me.chkClientName.Checked
            'Response.Cookies("projectusedhours")("division") = Me.chkDivision.Checked
            'Response.Cookies("projectusedhours")("divisionname") = Me.chkDivisionName.Checked
            'Response.Cookies("projectusedhours")("product") = Me.chkProduct.Checked
            'Response.Cookies("projectusedhours")("productname") = Me.chkProductName.Checked
            'Response.Cookies("projectusedhours")("job") = Me.chkJob.Checked
            'Response.Cookies("projectusedhours")("jobdesc") = Me.chkJobDesc.Checked
            'Response.Cookies("projectusedhours")("component") = Me.chkComponent.Checked
            'Response.Cookies("projectusedhours")("jobcompdesc") = Me.chkJobCompDesc.Checked
            ''Response.Cookies("projectusedhours")("title") = Me.txtReportTitle.Text
            ''Response.Cookies("projectusedhours")("emp") = Me.chkEmp.Checked
            ''Response.Cookies("projectusedhours")("hoursposted") = Me.chkHoursPosted.Checked
            'Response.Cookies("projectusedhours")("hoursassigned") = Me.chkHoursAssigned.Checked
            'Response.Cookies("projectusedhours")("totalhours") = Me.chkTotalHoursPosted.Checked
            'Response.Cookies("projectusedhours")("openjobsonly") = Me.cbIncludeOpenJobOnly.Checked
            'Response.Cookies("projectusedhours")("groupjc") = Me.CheckBoxGroup.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadSettings()

        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_HRS_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("StartDate")
            If s <> "" Then
                Me.RadDatePickerStartDate.SelectedDate = CType(s, Date)
            End If
            s = oAppVars.getAppVar("EndDate")
            If s <> "" Then
                Me.RadDatePickerEndDate.SelectedDate = CType(s, Date)
            End If
            s = oAppVars.getAppVar("client")
            If s <> "" Then
                Me.chkClient.Checked = s
            End If
            s = oAppVars.getAppVar("clientname")
            If s <> "" Then
                Me.chkClientName.Checked = s
            End If
            s = oAppVars.getAppVar("division")
            If s <> "" Then
                Me.chkDivision.Checked = s
            End If
            s = oAppVars.getAppVar("divisionname")
            If s <> "" Then
                Me.chkDivisionName.Checked = s
            End If
            s = oAppVars.getAppVar("product")
            If s <> "" Then
                Me.chkProduct.Checked = s
            End If
            s = oAppVars.getAppVar("productname")
            If s <> "" Then
                Me.chkProductName.Checked = s
            End If
            s = oAppVars.getAppVar("campaign")
            If s <> "" Then
                Me.chkCampaign.Checked = s
            End If
            s = oAppVars.getAppVar("campaignname")
            If s <> "" Then
                Me.chkCampaignName.Checked = s
            End If
            s = oAppVars.getAppVar("job")
            If s <> "" Then
                Me.chkJob.Checked = s
            End If
            s = oAppVars.getAppVar("jobdesc")
            If s <> "" Then
                Me.chkJobDesc.Checked = s
            End If
            s = oAppVars.getAppVar("component")
            If s <> "" Then
                Me.chkComponent.Checked = s
            End If
            s = oAppVars.getAppVar("jobcompdesc")
            If s <> "" Then
                Me.chkJobCompDesc.Checked = s
            End If
            s = oAppVars.getAppVar("hoursassigned")
            If s <> "" Then
                Me.chkHoursAssigned.Checked = s
            End If
            s = oAppVars.getAppVar("totalhours")
            If s <> "" Then
                Me.chkTotalHoursPosted.Checked = s
            End If
            s = oAppVars.getAppVar("openjobsonly")
            If s <> "" Then
                Me.cbIncludeOpenJobOnly.Checked = s
            End If
            s = oAppVars.getAppVar("groupjc")
            If s <> "" Then
                Me.CheckBoxGroup.Checked = s
            End If
            s = oAppVars.getAppVar("groupcmp")
            If s <> "" Then
                Me.CheckBoxGroupCampaign.Checked = s
            End If

            'If Request.Cookies("projectusedhours")("StartDate") <> "" Then
            '    Me.txtStartDate.Text = LoGlo.FormatDate(Request.Cookies("projectusedhours")("StartDate"))
            'End If
            'If Request.Cookies("projectusedhours")("EndDate") <> "" Then
            '    Me.txtEndDate.Text = LoGlo.FormatDate(Request.Cookies("projectusedhours")("EndDate"))
            'End If

            'Me.chkClient.Checked = Request.Cookies("projectusedhours")("client")
            'Me.chkClientName.Checked = Request.Cookies("projectusedhours")("clientname")
            'Me.chkDivision.Checked = Request.Cookies("projectusedhours")("division")
            'Me.chkDivisionName.Checked = Request.Cookies("projectusedhours")("divisionname")
            'Me.chkProduct.Checked = Request.Cookies("projectusedhours")("product")
            'Me.chkProductName.Checked = Request.Cookies("projectusedhours")("productname")
            'Me.chkJob.Checked = Request.Cookies("projectusedhours")("job")
            'Me.chkJobDesc.Checked = Request.Cookies("projectusedhours")("jobdesc")
            'Me.chkComponent.Checked = Request.Cookies("projectusedhours")("component")
            'Me.chkJobCompDesc.Checked = Request.Cookies("projectusedhours")("jobcompdesc")
            ''Me.chkEmp.Checked = Request.Cookies("projectusedhours")("emp")
            ''Me.chkHoursPosted.Checked = Request.Cookies("projectusedhours")("hoursposted")
            'Me.chkHoursAssigned.Checked = Request.Cookies("projectusedhours")("hoursassigned")
            'Me.chkTotalHoursPosted.Checked = Request.Cookies("projectusedhours")("totalhours")
            ''Me.txtReportTitle.Text = Request.Cookies("projectusedhours")("title")

            'Me.cbIncludeOpenJobOnly.Checked = Request.Cookies("projectusedhours")("openjobsonly")
            'Me.CheckBoxGroup.Checked = Request.Cookies("projectusedhours")("groupjc")
        Catch ex As Exception
            'Me.lbl_msg.Text = "Error in loading settings"
        End Try

    End Sub

    Private Function MakeSql() As String
        Dim ds As DataSet
        Dim strWhereStatus As String = ""
        Dim strWhereClient As String
        Dim strWhereDivision As String
        Dim strWhereProduct As String
        Dim strWhereManager As String
        Dim strWhereSalesClass As String = ""
        Dim strWhereJob As String = ""
        Dim strsplit As String() = Nothing
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim strWhereOffice As String = ""
        Dim FirstPass As Boolean
        Dim SumRepSql As String = ""


        'SumRepSql = "SELECT PROD_CAT_CODE as Code, PROD_CAT_CODE + ' - ' + PROD_CAT_DESC as Description FROM PRODUCT_CATEGORY"

        Select Case Me.optCDP.SelectedValue
            Case "c"
                If Not Me.lstClient.SelectedItem Is Nothing Then
                    strWhereClient = "[Client Code] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstClient.Items
                        If ThisItem.Selected = True Then
                            If FirstPass = True Then
                                strWhereClient &= "'" & ThisItem.Value & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & ThisItem.Value & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                End If
            Case "d"
                If Not Me.lstDivision.SelectedItem Is Nothing Then
                    strWhereClient = "[Client Code] IN ("
                    'this miss-spelling has been in webv since the beginning and never caught by QA
                    'strWhereDivision = "[DIV_CODEe] IN ("
                    strWhereDivision = "[Division Code] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstDivision.Items
                        If ThisItem.Selected = True Then
                            strsplit = ThisItem.Value.Split(":")
                            If FirstPass = True Then
                                strWhereClient &= "'" & strsplit(0) & "'"
                                strWhereDivision &= "'" & strsplit(1) & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & strsplit(0) & "'"
                                strWhereDivision &= ",'" & strsplit(1) & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                    strWhereDivision &= ")"
                End If

            Case "p"
                If Not Me.lstProduct.SelectedItem Is Nothing Then
                    strWhereClient = "[Client Code] IN ("
                    strWhereDivision = "[Division Code] IN ("
                    strWhereProduct = "[Product Code] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstProduct.Items
                        If ThisItem.Selected = True Then
                            strsplit = ThisItem.Value.Split(":")
                            If FirstPass = True Then
                                strWhereClient &= "'" & strsplit(0) & "'"
                                strWhereDivision &= "'" & strsplit(1) & "'"
                                strWhereProduct &= "'" & strsplit(2) & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & strsplit(0) & "'"
                                strWhereDivision &= ",'" & strsplit(1) & "'"
                                strWhereProduct &= ",'" & strsplit(2) & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                    strWhereDivision &= ")"
                    strWhereProduct &= ")"
                End If
        End Select
        FirstPass = True
        For Each ThisItem In Me.lbStatus.Items
            If ThisItem.Selected = True Then
                If FirstPass = True Then
                    strWhereStatus &= "'" & ThisItem.Value & "'"
                    FirstPass = False
                Else
                    strWhereStatus &= ",'" & ThisItem.Value & "'"
                End If
            End If
        Next
        If strWhereStatus.Trim <> "" Then
            If SumRepSql.Trim <> "" Then
                SumRepSql = " AND [TRF_CODE] IN(" & strWhereStatus & ")"
            Else
                SumRepSql = "[TRF_CODE] IN(" & strWhereStatus & ")"
            End If
        End If
        FirstPass = True
        For Each ThisItem In Me.lbJobs.Items
            If ThisItem.Selected = True Then
                If FirstPass = True Then
                    strWhereJob &= "" & ThisItem.Value & ""
                    FirstPass = False
                Else
                    strWhereJob &= "," & ThisItem.Value & ""
                End If
            End If
        Next
        If Me.CheckBoxGroup.Checked = True Or Me.CheckBoxGroupCampaign.Checked = True Then
            If strWhereJob.Trim <> "" Then
                If SumRepSql.Trim <> "" Then
                    SumRepSql &= " AND [JobNum] IN(" & strWhereJob & ")"
                Else
                    SumRepSql &= "[JobNum] IN(" & strWhereJob & ")"
                End If
            End If
        Else
            If strWhereJob.Trim <> "" Then
                If SumRepSql.Trim <> "" Then
                    SumRepSql &= " AND [Job Number] IN(" & strWhereJob & ")"
                Else
                    SumRepSql &= "[Job Number] IN(" & strWhereJob & ")"
                End If
            End If
        End If
        If Me.ddManager.SelectedValue <> "All" Then
            If SumRepSql.Trim <> "" Then
                SumRepSql &= " AND [MGR_EMP_CODE] IN('" & Me.ddManager.SelectedValue & "')"
            Else
                SumRepSql &= "[MGR_EMP_CODE] IN('" & Me.ddManager.SelectedValue & "')"
            End If
        End If
        If strWhereClient <> "" Or strWhereDivision <> "" Or strWhereProduct <> "" Then
            If strWhereClient <> "" Then
                If strWhereOffice <> "" Or strWhereStatus <> "" Or strWhereSalesClass <> "" Or Me.ddManager.SelectedValue <> "All" Or strWhereJob <> "" Then
                    SumRepSql &= " AND " & strWhereClient
                Else
                    SumRepSql &= strWhereClient
                End If
                If strWhereDivision <> "" Then
                    SumRepSql &= " AND " & strWhereDivision
                    If strWhereProduct <> "" Then
                        SumRepSql &= " AND " & strWhereProduct
                    End If
                End If
            End If
        End If



        Return SumRepSql
    End Function

    Private Sub gridReport_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridReport.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim i As Integer
                Dim j As Integer

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstClient.SelectedIndexChanged
        Try
            LoadJobs()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstDivision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDivision.SelectedIndexChanged
        Try
            LoadJobs()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstProduct.SelectedIndexChanged
        Try
            LoadJobs()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxGroup_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroup.CheckedChanged
        Try
            If Me.CheckBoxGroup.Checked = True Then
                Me.CheckBoxGroupCampaign.Checked = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxGroupCampaign_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupCampaign.CheckedChanged
        Try
            If Me.CheckBoxGroupCampaign.Checked = True Then
                Me.CheckBoxGroup.Checked = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
