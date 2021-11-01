Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Public Class DesktopMyDirectTime
    Inherits Webvantage.BaseDesktopObject

    Public strTaskStatus As String
    Public strShow As String = ""
    Public dDateStart As Date
    Public dDateEnd As Date

    Private Property CurrentNumberOfPages As Integer = 0
    Private Property CurrentPageNumber() As Integer
        Get

            Try

                If ViewState("RadGridDirectTimeMyDOCurrentPageNumber") Is Nothing Then ViewState("RadGridDirectTimeMyDOCurrentPageNumber") = 0
                Return CInt(ViewState("RadGridDirectTimeMyDOCurrentPageNumber"))

            Catch ex As Exception
                Return 0
            End Try

        End Get
        Set(ByVal value As Integer)
            ViewState("RadGridDirectTimeMyDOCurrentPageNumber") = value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.CurrentPageNumber = 0
            'Me.butPrint.Attributes.Add("onclick", "window.open('dtp_directtime.aspx?DesktopObject=My', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1100,height=800,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            If Me.IsFloating = False Then
                Me.butExport.Attributes.Add("onclick", "window.open('dtp_directtime.aspx?export=1&DesktopObject=My', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            End If

            If Not Page.IsPostBack Then
                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim taskVar As String

                dDateStart = Date.Today
                'RadDatePickerStart.SelectedDate = dDateStart
                'RadDatePickerDue.SelectedDate = dDateStart.AddMonths(1)

                Me.RadDatePickerStart.SelectedDate = LoGlo.FirstOfMonth()
                Me.RadDatePickerDue.SelectedDate = LoGlo.LastOfMonth()

                If Session("MyDirectTime_StartDate") IsNot Nothing Then
                    Me.RadDatePickerStart.SelectedDate = Session("MyDirectTime_StartDate")
                End If

                If Session("MyDirectTime_EndDate") IsNot Nothing Then
                    Me.RadDatePickerDue.SelectedDate = Session("MyDirectTime_EndDate")
                End If

                If wvCDate(Me.RadDatePickerDue.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStart.SelectedDate)).Days > 365 Then
                    Me.RadDatePickerStart.SelectedDate = LoGlo.FirstOfMonth()
                    Me.RadDatePickerDue.SelectedDate = LoGlo.LastOfMonth()
                End If

                'If otask.getAppVars(Session("UserCode"), "MyDirectTime", "dDateStart") <> "" Then
                '    Me.RadDatePickerStart.SelectedDate = otask.getAppVars(Session("UserCode"), "MyDirectTime", "dDateStart")
                'Else
                '    otask.setAppVars(Session("UserCode"), "MyDirectTime", "dDateStart", "", CStr(RadDatePickerStart.SelectedDate))
                'End If
                'If otask.getAppVars(Session("UserCode"), "MyDirectTime", "dDateDue") <> "" Then
                '    Me.RadDatePickerDue.SelectedDate = otask.getAppVars(Session("UserCode"), "MyDirectTime", "dDateDue")
                'Else
                '    otask.setAppVars(Session("UserCode"), "MyDirectTime", "dDateDue", "", CStr(RadDatePickerDue.SelectedDate))
                'End If

                LoadClientDropdownlist()
                LoadJobCompList()

                LoadRequests()
                Session("TasksDOSortOrder") = ""
                Session("TasksDOSortExp") = ""
                Me.RadGridDirectTimeDO.MasterTableView.GroupsDefaultExpanded = False
            Else

                Select Case Me.EventTarget
                    Case "RebindGrid", "UpdatePanelRadDock"
                        Me.RadGridDirectTimeDO.Rebind()

                End Select

            End If

            Try
                Me.RadGridDirectTimeDO.CurrentPageIndex = Me.CurrentPageNumber
            Catch ex As Exception
                Me.RadGridDirectTimeDO.CurrentPageIndex = 0
            End Try

        Catch ex As Exception

        End Try

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridDirectTimeDO)

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridDirectTimeDO)
        If Me.IsClientPortal = True Then
            AddHandler RadGridDirectTimeDO.HeaderContextMenu.ItemCreated, AddressOf HeaderContextMenuItemCreated
        End If

        Try
            Dim head As GridHeaderItem
            Try
                If Not Me.RadGridDirectTimeDO.MasterTableView.GetItems(GridItemType.Header) Is Nothing Then
                    head = TryCast(Me.RadGridDirectTimeDO.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
                End If
            Catch ex As Exception
                head = Nothing
            End Try
            'Me.HideIconHeaderLabels(head)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Me.ResetPageIndex()
        LoadRequests()
    End Sub

    Private Sub TaskRadGrid_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDirectTimeDO.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub
            Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim ar() As String
            Dim commandParm As String
            Dim jv As New JobVersion(Session("ConnString"))
            Dim dr As SqlDataReader

            Select Case e.CommandName
                Case "Detail"
                    If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                        CurrentGridDataItem = RadGridDirectTimeDO.Items(e.Item.ItemIndex)

                    End If

                    If CurrentGridDataItem.GetDataKeyValue("JOB_NUMBER") > 0 Then
                        Dim qs As New AdvantageFramework.Web.QueryString
                        qs.Page = "Content.aspx"
                        qs.JobNumber = CurrentGridDataItem.GetDataKeyValue("JOB_NUMBER")
                        qs.JobComponentNumber = CurrentGridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                        Me.OpenWindow("", qs.ToString(True))
                    Else
                        dr = jv.GetJVRequestDescriptions(CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"))
                        If dr.HasRows Then
                            dr.Read()
                            If IsDBNull(dr("CL_CODE")) = True Then
                                Me.OpenWindow("Add New", "jobVerTmplt.aspx?mode=request&JobVerHdrID=" & CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"), 600, 1100)
                            Else
                                Me.OpenWindow("Add New", "jobVerTmplt.aspx?mode=requesttoform&JobVerHdrID=" & CurrentGridDataItem.GetDataKeyValue("JOB_VER_HDR_ID"), 600, 1100)
                            End If
                            dr.Close()
                        End If
                    End If

            End Select
        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Sub
    Private Sub RadGridDirectTimeDO_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDirectTimeDO.ItemDataBound

        Try

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)

                'Dim job As Integer = e.Item.DataItem("JOB_NUMBER")
                'Dim comp As Integer = e.Item.DataItem("JOB_COMPONENT_NBR")

                'If job = 0 Then
                '    GridRow("JobNumber").Text = ""
                'Else
                '    GridRow("JobNumber").Text = job.ToString().PadLeft(6, "0")
                'End If

                'If comp = 0 Then
                '    GridRow("ComponentNumber").Text = ""
                'Else
                '    GridRow("ComponentNumber").Text = comp.ToString().PadLeft(2, "0")
                'End If

                Try
                    If IsDate(GridRow("Date").Text) = True Then
                        GridRow("Date").Text = LoGlo.FormatDate(CType(GridRow("Date").Text, Date).ToShortDateString)
                    End If
                Catch ex As Exception
                End Try

            End If
            If e.Item.ItemType = GridItemType.GroupHeader Then

                Dim item As GridGroupHeaderItem = CType(e.Item, GridGroupHeaderItem)
                Dim groupDataRow As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim lab As Label

                'lab = e.Item.FindControl("LabelClient")
                'lab.Text = groupDataRow.Row(0)
                'lab = e.Item.FindControl("LabelJob")
                'lab.Text = groupDataRow.Row(1) & ", " & groupDataRow.Row(2)
                'lab = e.Item.FindControl("LabelEmployee")
                'lab.Text = groupDataRow.Row(3)
                'lab = e.Item.FindControl("LabelFunction")
                'lab.Text = groupDataRow.Row(4)

            End If

            If e.Item.ItemType = GridItemType.GroupFooter Then

                Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then
                    If GrpFtr.GroupIndex.Length >= 5 Then
                        GrpFtr("Date").Text = "Total for Function:"
                        GrpFtr("Hours").Text = GrpFtr("Hours").Text.Replace("Sum : ", "")
                        GrpFtr("Amount").Text = GrpFtr("Amount").Text.Replace("Sum : ", "")
                        'GrpFtr.HorizontalAlign = HorizontalAlign.Left
                    End If
                    If GrpFtr.GroupIndex.Length >= 3 And GrpFtr.GroupIndex.Length <= 4 Then
                        GrpFtr("Date").Text = "Total for Employee:"
                        GrpFtr("Hours").Text = GrpFtr("Hours").Text.Replace("Sum : ", "")
                        GrpFtr("Amount").Text = GrpFtr("Amount").Text.Replace("Sum : ", "")
                    End If
                    If GrpFtr.GroupIndex.Length >= 1 And GrpFtr.GroupIndex.Length <= 2 Then
                        GrpFtr("Date").Text = "Total for Job Component:"
                        GrpFtr("Hours").Text = GrpFtr("Hours").Text.Replace("Sum : ", "")
                        GrpFtr("Amount").Text = GrpFtr("Amount").Text.Replace("Sum : ", "")
                    End If
                End If



            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadGridDirectTimeDO_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDirectTimeDO.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim jv As New JobVersion(Session("ConnString"))
            Dim DirectTime As AdvantageFramework.Database.Classes.DirectTime
            Dim job As Integer = 0
            Dim comp As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If Me.RadComboBoxJob.SelectedValue <> "" Then
                    Dim jc() As String = RadComboBoxJob.SelectedValue.Split("-")
                    job = jc(0)
                    comp = jc(1)
                End If

                RadGridDirectTimeDO.DataSource = AdvantageFramework.Database.Procedures.DirectTime.LoadByEmployee(DbContext, Me.RadDatePickerStart.SelectedDate.Value, Me.RadDatePickerDue.SelectedDate.Value, _Session.User.EmployeeCode, Me.RadComboBoxClient.SelectedValue, job, comp, _Session.UserCode)

            End Using

            SetGridSort()
            Me.CurrentNumberOfPages = Me.RadGridDirectTimeDO.PageCount
            If Me.CurrentPageNumber <= Me.CurrentNumberOfPages Then

                Me.RadGridDirectTimeDO.CurrentPageIndex = Me.CurrentPageNumber

            End If
            ' Me.RadGridJobRequestsDO.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridDirectTimeDO.PageSize = MiscFN.LoadPageSize(Me.RadGridDirectTimeDO.ID)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadGridDirectTimeDO_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridDirectTimeDO.PageIndexChanged
        Me.CurrentPageNumber = e.NewPageIndex
        LoadRequests()
    End Sub
    Private Sub RadGridDirectTimeDO_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridDirectTimeDO.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridDirectTimeDO.ID, e.NewPageSize)
    End Sub
    Private Sub RadGridDirectTimeDO_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGridDirectTimeDO.SortCommand

        Me.RadGridDirectTimeDO.MasterTableView.GroupsDefaultExpanded = True
        LoadRequests()

    End Sub

    Private Sub LoadClientDropdownlist()
        Try
            Me.RadComboBoxClient.Items.Clear()
            Dim cli As String
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            Me.RadComboBoxClient.DataSource = oDD.GetClientList(Session("UserCode"))
            Me.RadComboBoxClient.DataTextField = "Description"
            Me.RadComboBoxClient.DataValueField = "Code"
            Me.RadComboBoxClient.DataBind()
            Me.RadComboBoxClient.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("No Clients", ""))
            Me.RadComboBoxClient.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem("All Clients", "%"))

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "MyDirectTime", "DTClient")
            If taskVar <> "" Then
                Me.RadComboBoxClient.SelectedValue = taskVar
            Else
                Me.RadComboBoxClient.SelectedValue = ""
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadComboBoxClient_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxClient.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyDirectTime", "DTClient", "", Me.RadComboBoxClient.SelectedValue)
        LoadJobCompList()
        LoadRequests()
    End Sub

    Private Sub ResetPageIndex()

        Me.CurrentPageNumber = 0
        Me.RadGridDirectTimeDO.CurrentPageIndex = 0

    End Sub
    Private Sub LoadJobCompList()
        Try
            Dim dt As DataTable
            Dim oSQL As SqlHelper


            '*** Create Parameters
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = Session("UserCode")

            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsJJ", "dt", parameterUserID)

            If Me.RadComboBoxClient.SelectedValue <> "" Then
                dt.DefaultView.RowFilter = "CL_CODE = '" & Me.RadComboBoxClient.SelectedValue & "'"
            End If

            Me.RadComboBoxJob.Items.Clear()
            Me.RadComboBoxJob.DataSource = dt.DefaultView
            Me.RadComboBoxJob.DataTextField = "Description"
            Me.RadComboBoxJob.DataValueField = "Code"
            Me.RadComboBoxJob.DataBind()
            Me.RadComboBoxJob.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Jobs", ""))

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "MyDirectTime", "DTJob")
            If taskVar <> "" Then
                Me.RadComboBoxJob.SelectedValue = taskVar
            Else
                Me.RadComboBoxJob.SelectedValue = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxJob_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxJob.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        'otask.setAppVars(Session("UserCode"), "MyDirectTime", "DTJob", "", Me.RadComboBoxJob.SelectedValue)
        Session("MyDirectTime_Job") = Me.RadComboBoxJob.SelectedValue
        LoadRequests()
    End Sub

    Private Sub HeaderContextMenuItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
        Try
            If e.Item.Controls.Count > 0 Then
                If e.Item.Text = "Add Time" Then
                    e.Item.Visible = False
                End If
                If e.Item.Text = "Mark Complete" Then
                    e.Item.Visible = False
                End If
                If e.Item.Text = "Start Stopwatch" Then
                    e.Item.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadRequests()

        If Me.RadDatePickerStart.SelectedDate Is Nothing Then
            'Me.ShowMessage("Start Date is required.")
            Exit Sub
        End If

        If Me.RadDatePickerDue.SelectedDate Is Nothing Then
            'Me.ShowMessage("End Date is required.")
            Exit Sub
        End If

        If wvCDate(Me.RadDatePickerDue.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStart.SelectedDate)).Days > 365 Then
            ' Me.ShowMessage("Date range is limited to 1 year.")
            Exit Sub
        End If

        If wvCDate(Me.RadDatePickerDue.SelectedDate) < wvCDate(Me.RadDatePickerStart.SelectedDate) Then
            Me.ShowMessage("End date cannot be less than start date.")
            Exit Sub
        End If

        Me.RadGridDirectTimeDO.Rebind()

    End Sub
    Public Function SetStyle(ByVal PValue As String) As String
        If PValue = "" Then
            Return "calendarNormal"
        Else
            Return "calendarPending"
        End If
    End Function

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = RadGridDirectTimeDO.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = RadGridDirectTimeDO.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

    End Sub

    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub RadDatePickerDue_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerDue.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        If Me.RadDatePickerStart.SelectedDate Is Nothing Then
            Me.ShowMessage("Start Date is required.")
            Exit Sub
        End If

        If Me.RadDatePickerDue.SelectedDate Is Nothing Then
            Me.ShowMessage("End Date is required.")
            Exit Sub
        End If

        If wvCDate(Me.RadDatePickerDue.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStart.SelectedDate)).Days > 365 Then
            Me.ShowMessage("Date range is limited to 1 year.")
            'Exit Sub
        End If

        If Me.RadDatePickerStart.SelectedDate IsNot Nothing Then
            If wvCDate(Me.RadDatePickerDue.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStart.SelectedDate)).Days > 365 Then
                Me.RadDatePickerDue.SelectedDate = Nothing
            End If
        End If

        If Me.RadDatePickerDue.SelectedDate IsNot Nothing Then
            Session("MyDirectTime_EndDate") = Me.RadDatePickerDue.SelectedDate.Value
        Else
            Session("MyDirectTime_EndDate") = LoGlo.FirstOfMonth()
        End If

        'otask.setAppVars(Session("UserCode"), "MyDirectTime", "dDateDue", "", CStr(dDateEnd))

        LoadRequests()
    End Sub

    Private Sub RadDatePickerStart_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStart.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        If Me.RadDatePickerStart.SelectedDate Is Nothing Then
            Me.ShowMessage("Start Date is required.")
            Exit Sub
        End If

        If Me.RadDatePickerDue.SelectedDate Is Nothing Then
            Me.ShowMessage("End Date is required.")
            Exit Sub
        End If

        If wvCDate(Me.RadDatePickerDue.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStart.SelectedDate)).Days > 365 Then
            Me.ShowMessage("Date range is limited to 1 year.")
            'Exit Sub
        End If

        If Me.RadDatePickerStart.SelectedDate IsNot Nothing Then
            Session("MyDirectTime_StartDate") = Me.RadDatePickerStart.SelectedDate.Value
            If wvCDate(Me.RadDatePickerDue.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStart.SelectedDate)).Days > 365 Then
                Me.RadDatePickerDue.SelectedDate = Nothing
            End If
        Else
            Session("MyDirectTime_StartDate") = LoGlo.LastOfMonth
        End If

        'otask.setAppVars(Session("UserCode"), "MyDirectTime", "dDateStart", "", CStr(dDateStart))

        LoadRequests()
    End Sub

    Private Sub SetGridSort()
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim gbf As Telerik.Web.UI.GridGroupByField

            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "CDPName"
            gbf.FieldAlias = "Client"
            gbf.HeaderText = ""
            GrpExpr.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "JobComponent"
            gbf.FieldAlias = "Job"
            gbf.HeaderText = ""
            GrpExpr.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "Grouping"
            gbf.FieldAlias = "Grouping"
            gbf.HeaderText = ""
            GrpExpr.GroupByFields.Add(gbf)


            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "Employee"
            gbf.FieldAlias = "Employee"
            gbf.HeaderText = ""
            GrpExpr2.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "Employee"
            gbf.FieldAlias = "Employee"
            gbf.HeaderText = ""
            GrpExpr2.GroupByFields.Add(gbf)


            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "FunctionDescription"
            gbf.FieldAlias = "Function"
            gbf.HeaderText = ""
            GrpExpr3.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "FunctionDescription"
            gbf.FieldAlias = "Function"
            gbf.HeaderText = ""
            GrpExpr3.GroupByFields.Add(gbf)
            With Me.RadGridDirectTimeDO
                .MasterTableView.GroupByExpressions.Clear()
                .MasterTableView.GroupByExpressions.Add(GrpExpr)
                .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                .MasterTableView.GroupByExpressions.Add(GrpExpr3)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub butPrint_Click(sender As Object, e As ImageClickEventArgs) Handles butPrint.Click
        Try

            Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim job As Integer = 0
            Dim comp As Integer = 0

            Report = AdvantageFramework.Reporting.ReportTypes.DirectTime

            Session("DirectTime_StartDate") = Me.RadDatePickerStart.SelectedDate.Value
            Session("DirectTime_EndDate") = Me.RadDatePickerDue.SelectedDate.Value
            Session("DirectTime_ClientCode") = Me.RadComboBoxClient.SelectedValue
            Session("DirectTime_EmployeeCode") = _Session.User.EmployeeCode
            Session("DirectTime_PageBreak") = Me.CheckboxPageBreak.Checked

            If Me.RadComboBoxJob.SelectedValue <> "" Then
                Dim jc() As String = RadComboBoxJob.SelectedValue.Split("-")
                job = jc(0)
                comp = jc(1)
            End If

            Session("DirectTime_JobNumber") = job
            Session("DirectTime_ComponentNumber") = comp

            Me.OpenWindow("", "Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), Report) & "")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub butExport_Click(sender As Object, e As ImageClickEventArgs) Handles butExport.Click

        Dim str As String = ""
        str = "DirectTime" & AdvantageFramework.StringUtilities.GUID_Date()
        Me.RadGridDirectTimeDO.MasterTableView.Caption = "Direct Time for " & Session("EmpCode") & " - " & "Date Range: " & Me.RadDatePickerStart.SelectedDate.Value & " - " & Me.RadDatePickerDue.SelectedDate.Value
        If Me.IsFloating = True Then
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridDirectTimeDO, str, False, True)
            'RadGridDirectTimeDO.ExportSettings.IgnorePaging = True
            RadGridDirectTimeDO.MasterTableView.GroupsDefaultExpanded = True
            RadGridDirectTimeDO.MasterTableView.ExportToExcel()
        Else

        End If


    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_MyDirectTime
                .UserCode = Session("UserCode")
                .Name = "Direct Time (My)"
                .Description = "Direct Time (My)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
