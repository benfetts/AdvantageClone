Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports Telerik.Web.UI
Imports Webvantage.cGlobals

Partial Public Class SupervisorApproval_Timesheet
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Protected WithEvents DropMarkAllINSTR As Telerik.Web.UI.RadComboBox

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private IsExport As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("bm") Is Nothing Then
            Me.PageTitle = "Timesheet Approval"
        End If
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_TimesheetApproval)
        Me.DropMarkAllINSTR = CType(Me.RadToolbarSuperAppr.FindItemByValue("RadToolBarButtonDropMarkAllINSTR").FindControl("DropMarkAllINSTR"), Telerik.Web.UI.RadComboBox)

        If Not Me.IsPostBack Then

            If Request.QueryString("sedate") IsNot Nothing AndAlso IsDate(Request.QueryString("sedate")) Then

                Dim startDate As Date
                startDate = CType(LoGlo.FormatDate(Request.QueryString("sedate")), Date)
                Me.RadDatePickerStartDate.SelectedDate = startDate

                Try
                    If Request.QueryString("doweek") IsNot Nothing AndAlso CType(Request.QueryString("doweek"), Integer) = 1 Then

                        Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(startDate.ToShortDateString())
                        Me.RadDatePickerEndDate.SelectedDate = LoGlo.FormatDate(DateAdd(DateInterval.Day, 6, startDate))

                    Else

                        Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(startDate.ToShortDateString())
                        Me.RadDatePickerEndDate.SelectedDate = LoGlo.FormatDate(startDate.ToShortDateString())

                    End If
                Catch ex As Exception
                    Me.RadDatePickerEndDate.SelectedDate = startDate
                End Try

            Else

                Dim startDate, endDate As String
                Dim oAppVars As New cAppVars(cAppVars.Application.SUPR_APPR_TS)

                oAppVars.getAllAppVars()
                startDate = oAppVars.getAppVar("StartDate")
                endDate = oAppVars.getAppVar("EndDate")

                If startDate <> "" Then

                    Me.RadDatePickerStartDate.SelectedDate = CDate(LoGlo.FormatDate(startDate))
                    Me.RadDatePickerEndDate.SelectedDate = CDate(LoGlo.FormatDate(endDate))

                Else

                    Me.RadDatePickerStartDate.SelectedDate = Today()
                    Me.RadDatePickerEndDate.SelectedDate = Today()

                End If

            End If

            Session("STARTDATE_SuperAppr") = Me.RadDatePickerStartDate.SelectedDate
            Session("ENDDATE_SuperAppr") = Me.RadDatePickerEndDate.SelectedDate

            Me.BindEmployeeDrop()

            Dim empCode As String = String.Empty
            If Request.QueryString("empcode") IsNot Nothing Then

                empCode = Request.QueryString("empcode")
                MiscFN.RadComboBoxSetIndex(ddEmployee, empCode, False)

            End If

            If String.IsNullOrWhiteSpace(empCode) = False AndAlso Request.QueryString("sedate") IsNot Nothing Then

                RadGridTimesheetApproval.Rebind()

            End If

        Else
            Select Case Me.EventArgument
                Case "Search"
                    RadGridTimesheetApproval.Rebind()
                Case "Save"
                    SaveGrid()
            End Select
        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub CheckBoxNotSubmitted_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxNotSubmitted.CheckedChanged

        Me.SetCheckboxes()
        Me.BindEmployeeDrop()
        Me.RadGridTimesheetApproval.Rebind()

    End Sub

    Private Sub ChkApproved_CheckedChanged(sender As Object, e As EventArgs) Handles ChkApproved.CheckedChanged

        Me.RadGridTimesheetApproval.Rebind()

    End Sub

    Private Sub ChkDenied_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDenied.CheckedChanged

        Me.RadGridTimesheetApproval.Rebind()

    End Sub

    Private Sub ChkPending_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPending.CheckedChanged

        Me.RadGridTimesheetApproval.Rebind()

    End Sub

    Private Sub ddEmployee_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddEmployee.SelectedIndexChanged

        Me.RadGridTimesheetApproval.Rebind()

    End Sub

    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged

        Me.RadGridTimesheetApproval.Rebind()

    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged

        Me.RadGridTimesheetApproval.Rebind()

    End Sub

    Private Sub RadGridTimesheetApproval_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridTimesheetApproval.DetailTableDataBind
        Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim arParams(0) As SqlParameter
        Dim ET_ID As Integer = dataItem.GetDataKeyValue("ET_ID")

        Dim parameterETID As New SqlParameter("@ET_ID", SqlDbType.Int)
        parameterETID.Value = ET_ID
        arParams(0) = parameterETID

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_get_super_appr_dtl", arParams)
        Catch
            Err.Raise(Err.Number, "Class:SupervisorApproval Routine:RadGridTimesheetApproval_DetailTableDataBind", Err.Description)
        End Try

        e.DetailTableView.DataSource = dr

    End Sub
    Private Sub RadGridTimesheetApproval_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTimesheetApproval.ItemCommand
        If e.CommandName.Contains("Export") Then
            IsExport = True
            RadGridTimesheetApproval.MasterTableView.HierarchyDefaultExpanded = True
            RadGridTimesheetApproval.MasterTableView.DetailTables(0).HierarchyDefaultExpanded = True
            With RadGridTimesheetApproval.ExportSettings
                .FileName = "Timesheet_Approval_for_" & Me.ddEmployee.SelectedItem.Text & "_" & CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString() & "-" &
                    CType(Me.RadDatePickerEndDate.SelectedDate, Date).ToShortDateString() & AdvantageFramework.StringUtilities.GUID_Date()
            End With
        End If
    End Sub
    Private Sub RadGridTimesheetApproval_ItemCreated(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTimesheetApproval.ItemCreated
        If Me.IsExport = True Or Me.CheckBoxNotSubmitted.Checked = True Then
            Me.RadGridTimesheetApproval.MasterTableView.Columns.FindByUniqueName("ColumnSelect").Visible = False
            'If TypeOf e.Item Is GridHeaderItem = True Then
            '    e.Item.OwnerTableView.BackColor = System.Drawing.Color.LightGray
            'End If
        End If
    End Sub

    Private StandardHoursTotal As Decimal = 0
    Private HoursTotal As Decimal = 0
    Private Sub RadGridTimesheetApproval_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTimesheetApproval.ItemDataBound
        'Set selected index:
        Try
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo()

            If e.Item.ItemType = GridItemType.Header Then


            ElseIf e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                MiscFN.RadComboBoxSetIndex(CType(e.Item.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox), e.Item.DataItem("STATUS"), False)
                MiscFN.LimitTextbox(CType(e.Item.FindControl("TxtAPPR_NOTES"), TextBox), 254)


                Dim MissingCommentsIndicatorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivMissingCommentsIndicator")
                Dim MissingCommentsIndicatorImage As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("ImageMissingCommentsIndicator"), System.Web.UI.WebControls.Image)

                If CType(e.Item.DataItem("MISSING_COMMENTS"), Boolean) = True Then

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(MissingCommentsIndicatorDiv, "standard-red")
                    MissingCommentsIndicatorImage.ToolTip = "Day is missing comment(s)"

                Else

                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(MissingCommentsIndicatorDiv, "standard-light-green")
                    MissingCommentsIndicatorImage.ToolTip = "Day has comment(s)"

                End If

                Dim di As GridDataItem = e.Item

                e.Item.Cells(5).Text = String.Format(c, "{0:ddd}", CDate(di.GetDataKeyValue("EMP_DATE")))


                e.Item.Cells(4).Text = LoGlo.FormatDate(e.Item.Cells(4).Text)

                Try

                    If IsNumeric(e.Item.Cells(8).Text) = True Then

                        e.Item.Cells(8).Text = LoGlo.FormatDecimal(e.Item.Cells(8).Text)
                        StandardHoursTotal += CType(e.Item.Cells(8).Text, Decimal)

                    End If

                Catch ex As Exception
                End Try
                Try

                    If IsNumeric(e.Item.Cells(9).Text) = True Then

                        e.Item.Cells(9).Text = LoGlo.FormatDecimal(e.Item.Cells(9).Text)
                        HoursTotal += CType(e.Item.Cells(9).Text, Decimal)

                    End If

                Catch ex As Exception
                End Try

            ElseIf e.Item.ItemType = GridItemType.Footer Then

                Try

                    'e.Item.Cells(8).Text = LoGlo.FormatDecimal(StandardHoursTotal)
                    e.Item.Cells(8).Text = "Total Hours"

                Catch ex As Exception
                End Try
                Try

                    e.Item.Cells(9).Text = LoGlo.FormatDecimal(HoursTotal)

                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadGridTimesheetApproval_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTimesheetApproval.NeedDataSource

        If validateData() = 1 Then

            Me.RadToolbarSuperAppr.FindItemByValue("Save").Enabled = Not Me.CheckBoxNotSubmitted.Checked
            Me.RadToolbarSuperAppr.FindItemByValue("Alert").Enabled = Not Me.CheckBoxNotSubmitted.Checked
            Me.RadToolbarSuperAppr.FindItemByValue("MarkAll").Enabled = Not Me.CheckBoxNotSubmitted.Checked
            Me.RadToolbarSuperAppr.FindItemByValue("MarkChecked").Enabled = Not Me.CheckBoxNotSubmitted.Checked
            Me.DropMarkAllINSTR.Enabled = Not Me.CheckBoxNotSubmitted.Checked

            Me.RadGridTimesheetApproval.MasterTableView.GetColumn("STATUSDD").Visible = Not Me.CheckBoxNotSubmitted.Checked
            Me.RadGridTimesheetApproval.MasterTableView.GetColumn("APPR_NOTES").Visible = Not Me.CheckBoxNotSubmitted.Checked

            If Me.CheckBoxNotSubmitted.Checked = True Then
                Me.RadGridTimesheetApproval.MasterTableView.Caption = "Not Submitted Time"
            Else
                Dim sb As New System.Text.StringBuilder
                With sb
                    If Me.ChkPending.Checked Then
                        .Append("Pending, ")
                    End If
                    If Me.ChkDenied.Checked Then
                        .Append("Denied, ")
                    End If
                    If Me.ChkApproved.Checked Then
                        .Append("Approved, ")
                    End If
                End With
                Dim str As String = sb.ToString()
                str = RTrim(str)
                str = MiscFN.RemoveTrailingDelimiter(str, ",")
                str &= " Time"
                Me.RadGridTimesheetApproval.MasterTableView.Caption = str
            End If

            'Save Start/End date range
            Dim startDate, endDate As String
            Dim oAppVars As New cAppVars(cAppVars.Application.SUPR_APPR_TS)
            startDate = Me.RadDatePickerStartDate.SelectedDate
            endDate = Me.RadDatePickerEndDate.SelectedDate
            oAppVars.setAppVarDB("StartDate", startDate)
            oAppVars.setAppVarDB("EndDate", endDate)

            Dim oSQL As SqlHelper
            Dim dr As SqlDataReader
            Dim arParams(7) As SqlParameter
            Dim checked As Boolean
            Dim emp As String = ""

            Dim parmeterUserID As New SqlParameter("@user_id", SqlDbType.VarChar, 100)
            parmeterUserID.Value = Session("UserCode")
            arParams(0) = parmeterUserID

            Dim parmetersuperCode As New SqlParameter("@superCode", SqlDbType.VarChar, 6)
            parmetersuperCode.Value = Session("EmpCode")
            arParams(1) = parmetersuperCode

            Dim parameterEmpCode As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
            emp = Me.ddEmployee.SelectedValue
            If emp = "All" Then
                emp = ""
            End If
            parameterEmpCode.Value = emp
            arParams(2) = parameterEmpCode

            If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = False Then
                Me.ShowMessage("Invalid Start date")
                Exit Sub
            Else
                Dim parameterStart As New SqlParameter("@start_date", SqlDbType.SmallDateTime)
                parameterStart.Value = wvCDate(Me.RadDatePickerStartDate.SelectedDate)
                arParams(3) = parameterStart
            End If

            If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = False Then
                Me.ShowMessage("Invalid End date")
                Exit Sub
            Else
                Dim parameterEnd As New SqlParameter("@end_date", SqlDbType.SmallDateTime)
                parameterEnd.Value = wvCDate(Me.RadDatePickerEndDate.SelectedDate)
                arParams(4) = parameterEnd
            End If

            Dim parameterApproved As New SqlParameter("@APPR_FLAG", SqlDbType.Int)
            If Me.ChkApproved.Checked = True Then
                parameterApproved.Value = 1
            Else
                parameterApproved.Value = 0
            End If
            arParams(5) = parameterApproved

            Dim parameterPending As New SqlParameter("@APPR_PENDING", SqlDbType.Int)
            If Me.ChkPending.Checked = True Then
                parameterPending.Value = 1
            Else
                parameterPending.Value = 0
            End If
            arParams(6) = parameterPending

            Dim parameterDenied As New SqlParameter("@APPR_DENIED", SqlDbType.Int)
            If Me.ChkDenied.Checked = True Then
                parameterDenied.Value = 1
            Else
                parameterDenied.Value = 0
            End If
            arParams(7) = parameterDenied

            Try

                Me.RadGridTimesheetApproval.DataSource = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_get_super_appr_hdr", "dtData", arParams)

            Catch ex As Exception

                Me.ShowMessage(ex.Message.ToString())

            End Try

            Try

                Dim Show As Boolean = False
                Dim m As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))

                If m.AgencyCommentsRequired() Or m.CommentsRequiredWhenSubmittingForApproval() = True Then

                    Show = True

                End If

                Me.RadGridTimesheetApproval.MasterTableView.GetColumn("GridBoundColumnMissingComments").Visible = Show

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub RadToolbarSuperAppr_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSuperAppr.ButtonClick
        Select Case e.Item.Value
            Case "Search"
                Me.RadGridTimesheetApproval.Rebind()
            Case "Save"
                SaveGrid()
                RadGridTimesheetApproval.Rebind()
            Case "Alert"
                SaveGrid()
                SendAlerts()
            Case "MarkAll" 'Approved/Pending/Denied
                MarkAll()
            Case "MarkChecked"
                MarkChecked()
            Case "Print"

            Case "Expand"
                Dim expanded As Boolean
                Dim tlbrButton As Telerik.Web.UI.RadToolBarButton = CType(RadToolbarSuperAppr.FindItemByValue("Expand"), Telerik.Web.UI.RadToolBarButton)
                If tlbrButton.Text = "Expand" Then
                    tlbrButton.Text = "Collapse"
                    tlbrButton.ToolTip = "Collapse"
                    expanded = True
                Else
                    tlbrButton.Text = "Expand"
                    tlbrButton.ToolTip = "Expand"
                    expanded = False
                End If
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetApproval.MasterTableView.Items
                    gridDataItem.Expanded = expanded
                Next
            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()
                qs.Page = "SupervisorApproval_Timesheet.aspx"
                qs.Add("bm", "1")

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_TimesheetApproval
                    .UserCode = Session("UserCode")
                    .Name = "Timesheet Approval"
                    .Description = "Timesheet Approval"
                    .PageURL = qs.ToString(True)
                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                End If
        End Select

    End Sub

#End Region

#Region " Methods "

    Private Function BindEmployeeDrop()

        Dim AppFilter As String = ""

        If Me.CheckBoxNotSubmitted.Checked = True Then

            AppFilter = "ts_appr"

        Else

            AppFilter = ""

        End If

        Me.ddEmployee.Items.Clear()

        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.ddEmployee

            .DataSource = oDD.GetEmployeesBySupervisor(Session("UserCode"), Session("EmpCode"), AppFilter)
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))

        End With

    End Function

    Private Sub MarkAll()
        Dim RowCount As Integer = Me.RadGridTimesheetApproval.MasterTableView.Items.Count
        Dim MarkValue As String
        Dim checked As Boolean
        MarkValue = DropMarkAllINSTR.SelectedValue

        For i As Integer = 0 To RowCount - 1
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetApproval.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
            Dim dropdwn As Telerik.Web.UI.RadComboBox = DirectCast(CurrentGridRow.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)
            dropdwn.SelectedValue = MarkValue
        Next
    End Sub
    Private Sub MarkChecked()
        'Dim RowCount As Integer = Me.RadGridTimesheetApproval.MasterTableView.Items.Count
        Dim MarkValue As String
        Dim checked As Boolean
        Dim idx As Integer = 0

        MarkValue = DropMarkAllINSTR.SelectedValue

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetApproval.MasterTableView.Items
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetApproval.MasterTableView.Items(idx), Telerik.Web.UI.GridDataItem)
            Dim chkbx As CheckBox = CType(gridDataItem("ColumnSelect").Controls(0), CheckBox)

            If chkbx.Checked Then
                Dim dropdwn As Telerik.Web.UI.RadComboBox = DirectCast(CurrentGridRow.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)
                dropdwn.SelectedValue = MarkValue
            End If
            idx += 1
        Next

    End Sub
    Private Sub SaveGrid(Optional ByVal RebindGrid As Boolean = True, Optional ByVal SaveUserRows As Boolean = True)
        Dim ET_ID, appr_flag, appr_pending_flag As Integer
        Dim ApprNotes, status As String
        Dim RowCount As Integer = Me.RadGridTimesheetApproval.MasterTableView.Items.Count
        If RowCount > 0 Then
            For i As Integer = 0 To RowCount - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetApproval.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Dim ddstatus As Telerik.Web.UI.RadComboBox = DirectCast(CurrentGridRow.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)

                status = ddstatus.SelectedValue
                Select Case status
                    Case "1"
                        appr_flag = 1
                        appr_pending_flag = 0

                    Case "2"
                        appr_flag = 0
                        appr_pending_flag = 1

                    Case "3"
                        appr_flag = 0
                        appr_pending_flag = 2
                End Select

                Try
                    ET_ID = CType(CurrentGridRow.GetDataKeyValue("ET_ID"), Integer)
                    ApprNotes = DirectCast(CurrentGridRow.FindControl("TxtAPPR_NOTES"), TextBox).Text
                Catch ex As Exception
                    ET_ID = -1
                End Try

                If ET_ID > 0 Then
                    Dim arP(6) As SqlParameter

                    Dim pAPPR_NOTES As New SqlParameter("@APPR_NOTES", SqlDbType.VarChar, 254)
                    pAPPR_NOTES.Value = ApprNotes
                    arP(0) = pAPPR_NOTES

                    Dim pAPPR_FLAG As New SqlParameter("@APPR_FLAG", SqlDbType.SmallInt)
                    pAPPR_FLAG.Value = appr_flag
                    arP(1) = pAPPR_FLAG

                    Dim pAPPR_PENDING As New SqlParameter("@APPR_PENDING", SqlDbType.SmallInt)
                    pAPPR_PENDING.Value = appr_pending_flag
                    arP(2) = pAPPR_PENDING

                    Dim pAPPR_USER As New SqlParameter("@APPR_USER", SqlDbType.VarChar, 100)
                    If appr_flag = 1 Then
                        pAPPR_USER.Value = HttpContext.Current.Session("UserCode").ToString()
                    Else
                        pAPPR_USER.Value = DBNull.Value
                    End If
                    arP(3) = pAPPR_USER

                    Dim pAPPR_DATE As New SqlParameter("@APPR_DATE", SqlDbType.SmallDateTime)
                    If appr_flag = 1 Then
                        pAPPR_DATE.Value = Now.Date
                    Else
                        pAPPR_DATE.Value = DBNull.Value
                    End If
                    arP(4) = pAPPR_DATE

                    Dim pET_ID As New SqlParameter("@ET_ID", SqlDbType.Int)
                    pET_ID.Value = ET_ID
                    arP(5) = pET_ID

                    Dim SQL As New System.Text.StringBuilder

                    If appr_flag = 1 Then

                        With SQL
                            .Append(" UPDATE ")
                            .Append(" 	EMP_TIME WITH(ROWLOCK) ")
                            .Append(" SET  ")
                            .Append(" 	APPR_NOTES = @APPR_NOTES, ")
                            .Append(" 	APPR_FLAG = @APPR_FLAG, ")
                            .Append(" 	APPR_PENDING = @APPR_PENDING, ")
                            .Append(" 	APPR_USER = CASE WHEN ISNULL(APPR_FLAG,0) = 0 THEN @APPR_USER ELSE APPR_USER END, ")
                            .Append(" 	APPR_DATE = CASE WHEN ISNULL(APPR_FLAG,0) = 0 THEN @APPR_DATE ELSE APPR_DATE END ")
                            .Append(" WHERE  ")
                            .Append(" 	ET_ID = @ET_ID; ")
                            .Append(" SELECT EMP_CODE, EMP_DATE FROM EMP_TIME WITH(NOLOCK) WHERE ET_ID = @ET_ID; ")
                        End With

                    Else

                        With SQL
                            .Append(" UPDATE ")
                            .Append(" 	EMP_TIME WITH(ROWLOCK) ")
                            .Append(" SET  ")
                            .Append(" 	APPR_NOTES = @APPR_NOTES, ")
                            .Append(" 	APPR_FLAG = @APPR_FLAG, ")
                            .Append(" 	APPR_PENDING = @APPR_PENDING, ")
                            .Append(" 	APPR_USER = @APPR_USER, ")
                            .Append(" 	APPR_DATE = @APPR_DATE ")
                            .Append(" WHERE  ")
                            .Append(" 	ET_ID = @ET_ID; ")
                            .Append(" SELECT EMP_CODE, EMP_DATE FROM EMP_TIME WITH(NOLOCK) WHERE ET_ID = @ET_ID; ")
                        End With

                    End If

                    'Save:
                    Dim EmpCode As String = ""
                    Dim EmpDate As String = ""
                    Dim dt As New DataTable
                    Try
                        dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, SQL.ToString(), "DtEmpTime", arP)
                        Try
                            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                                EmpCode = dt.Rows(0)("EMP_CODE").ToString()
                                EmpDate = CType(dt.Rows(0)("EMP_DATE"), Date).ToShortDateString()
                            End If
                        Catch ex As Exception
                        End Try
                    Catch ex As Exception
                        Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
                    End Try
                    Try
                        If EmpCode <> "" And EmpDate <> "" Then
                            Dim SessionKeySuffix As String = EmpCode & EmpDate
                            HttpContext.Current.Session("SetSubmitLabel" & SessionKeySuffix) = Nothing
                            HttpContext.Current.Session("CheckApprovalStatus" & SessionKeySuffix) = Nothing
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not dt Is Nothing Then dt.Dispose()
                    Catch ex As Exception
                    End Try
                End If


            Next
        End If

        'Save Start/End date range
        Dim oAppVars As New cAppVars(cAppVars.Application.SUPR_APPR_TS)
        oAppVars.setAppVarDB("StartDate", Me.RadDatePickerStartDate.SelectedDate)
        oAppVars.setAppVarDB("EndDate", Me.RadDatePickerEndDate.SelectedDate)
    End Sub

    Private Sub SendAlerts()

        Dim NowDate As Date = Now
        Dim DateDate As Date
        Dim url, ApprNotes As String
        Dim RowCount As Integer = Me.RadGridTimesheetApproval.MasterTableView.Items.Count
        Dim MarkValue As String
        Dim checked As Boolean
        Dim idx As Integer = 0
        Dim empCode, empName, DateStr, status As String

        url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetApproval.MasterTableView.Items

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetApproval.MasterTableView.Items(idx), Telerik.Web.UI.GridDataItem)
                Dim chkbx As CheckBox = CType(gridDataItem("ColumnSelect").Controls(0), CheckBox)

                If chkbx.Checked Then

                    Dim FxAlert As New AdvantageFramework.Database.Entities.Alert

                    empCode = CurrentGridRow.GetDataKeyValue("EMP_CODE")
                    empName = CurrentGridRow("colemp").Text
                    DateStr = CurrentGridRow("colempdate").Text
                    DateDate = CType(DateStr, Date)
                    status = CurrentGridRow.GetDataKeyValue("STATUS")

                    Select Case status
                        Case "1"
                            status = "Approved"
                        Case "2"
                            status = "Pending"
                        Case "3"
                            status = "Denied"
                    End Select

                    ApprNotes = DirectCast(CurrentGridRow.FindControl("TxtAPPR_NOTES"), TextBox).Text

                    With FxAlert

                        .AlertTypeID = 3
                        .AlertCategoryID = 44
                        .Subject = "Timesheet Approval Updated (" & DateStr & ") - " & status
                        .Body = "<a href='" & url & "/Timesheet.aspx?TSdate=" & DateStr & "&empcode=" & empCode & " '> Link to timesheet for " & empName & " (" & DateDate.ToString("d") & ").</a><br /><br />" & ApprNotes
                        .EmailBody = .Body
                        .GeneratedDate = NowDate
                        .LastUpdated = NowDate
                        .PriorityLevel = 3
                        .EmployeeCode = Session("EmpCode")
                        .UserCode = Session("UserCode")

                    End With

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                        Dim Alert As New Alert(Session("ConnString"))
                        Alert.LoadByPrimaryKey(FxAlert.ID)
                        Alert.AddAlertRecipient(empCode)
                        SendEmailAlert(Alert.ALERT_ID, ApprNotes)

                    Else

                        Me.ShowMessage("Alert failed to save")

                    End If

                End If

                idx += 1

            Next

        End Using
    End Sub

    Private Function SendEmailAlert(ByVal AlertID As Integer, Optional ByVal comment As String = "") As Boolean
        Try

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                              HttpContext.Current.Session("UserCode"),
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID
                .Subject = "[New Alert]"
                .AppName = "SupervisorApproval"
                .SupervisorApprovalComment = comment
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

            Return True

        Catch ex As Exception

            Me.ShowMessage("Alert Email not Sent.  " & ex.Message.ToString())
            SendEmailAlert = False

        End Try
    End Function

    Private Function SetCheckboxes()

        If Me.CheckBoxNotSubmitted.Checked = True Then

            Me.ChkPending.Checked = False
            Me.ChkDenied.Checked = False
            Me.ChkApproved.Checked = False
            Me.ChkPending.Enabled = False
            Me.ChkDenied.Enabled = False
            Me.ChkApproved.Enabled = False

        Else

            Me.ChkPending.Enabled = True
            Me.ChkDenied.Enabled = True
            Me.ChkApproved.Enabled = True

        End If

        If Me.ChkPending.Checked = False And
            Me.ChkDenied.Checked = False And
            Me.ChkApproved.Checked = False And
            Me.CheckBoxNotSubmitted.Checked = False Then

            Me.ChkPending.Checked = True
            Me.ChkDenied.Checked = True

        End If


    End Function

    Private Function validateData() As Integer
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Dim startDateStr, endDateStr As String
        Dim startDate, endDate As DateTime

        startDateStr = CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString()
        endDateStr = CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString()

        If startDateStr = Nothing Or startDateStr = "" Or cGlobals.wvIsDate(startDateStr) = False Then
            Me.ShowMessage("Please enter valid Start Date.")
            Me.RadDatePickerStartDate.DateInput.Focus()
            Return -1
        Else
            startDate = wvCDate(Me.RadDatePickerStartDate.SelectedDate)
        End If

        If endDateStr = Nothing Or endDateStr = "" Or cGlobals.wvIsDate(endDateStr) = False Then
            Me.ShowMessage("Please enter valid End Date.")
            Me.RadDatePickerEndDate.DateInput.Focus()
            Return -1
        Else
            endDate = wvCDate(Me.RadDatePickerEndDate.SelectedDate)
        End If

        Dim dtStart As DateTime = LoGlo.FormatDateTime(Convert.ToDateTime("1/1/1900 12:00:00 AM"))
        Dim dtEnd As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("12/31/2100 11:59:59 PM"))

        If startDate < dtStart Or startDate > dtEnd Then
            Me.ShowMessage("Start Date is invalid.")
            Return -1
        End If
        If endDate < dtStart Or endDate > dtEnd Then
            Me.ShowMessage("End Date is invalid.")
            Return -1
        End If

        If startDate > endDate Then
            Me.ShowMessage("End Date must be greater than Start Date")
            Me.RadDatePickerStartDate.SelectedDate = CDate(Session("STARTDATE_SuperAppr"))
            Me.RadDatePickerEndDate.SelectedDate = CDate(Session("ENDDATE_SuperAppr"))
            Return -1
        End If

        'Add validation for 1 month or less 

        Session("STARTDATE_SuperAppr") = startDate
        Session("ENDDATE_SuperAppr") = endDate

        Return 1

    End Function


#End Region

End Class
