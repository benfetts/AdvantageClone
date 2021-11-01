Imports Webvantage.cGlobals
Imports System.Drawing

Partial Public Class TrafficSchedule_TaskEmployees
    Inherits Webvantage.BaseChildPage

    Private CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
    Private ThisTask_JobNum As Integer = 0
    Private ThisTask_JobComp As Integer = 0
    Private ThisTask_SeqNum As Integer = 0
    Private dtTaskDetails As DataTable
    Private ThisTask_StartDate As Date
    Private ThisTask_DueDate As Date
    Private ThisTask_TaskCode As String = ""
    Public ThisTask_DefaultHours As String = "0.00"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            ThisTask_JobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            ThisTask_JobNum = 0
        End Try
        Try
            ThisTask_JobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            ThisTask_JobComp = 0
        End Try
        Try
            ThisTask_SeqNum = CType(Request.QueryString("SeqNum"), Integer)
        Catch ex As Exception
            ThisTask_SeqNum = -1
        End Try

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.ThisTask_JobNum = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.ThisTask_JobComp = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.TaskSequenceNumber > 0 Then Me.ThisTask_SeqNum = Me.CurrentQuerystring.TaskSequenceNumber

        'Try
        '    ThisTask_TaskCode = Request.QueryString("TaskCode")
        'Catch ex As Exception
        '    ThisTask_TaskCode = ""
        'End Try
        Dim HeaderText As String = ""
        If Not Me.IsPostBack Then

            Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            dtTaskDetails = oSchedule.GetScheduleTask(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum)

            Dim AppVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
            AppVars.getAllAppVars()

            If AppVars.HasAppVar("LimitRoleList") = True Then

                Me.RadToolBarButtonChkLimitToRole.Checked = AppVars.getAppVar("LimitRoleList").ToString

            End If

            If IsDBNull(dtTaskDetails.Rows(0)("TASK_CODE")) = False Then
                ThisTask_TaskCode = dtTaskDetails.Rows(0)("TASK_CODE")
                HeaderText = dtTaskDetails.Rows(0)("TASK_CODE") & " - "
            End If

            If ThisTask_TaskCode <> "" Then
                'Me.RadToolBarButtonChkLimitToRole.Text &= " - " & ThisTask_TaskCode
                'Me.ChkLimitToRole.Text &= ThisTask_TaskCode
            Else
                Me.RadToolBarButtonChkLimitToRole.Enabled = False
                'Me.ChkLimitToRole.Enabled = False
            End If

            If IsDBNull(dtTaskDetails.Rows(0)("TASK_DESCRIPTION")) = False Then
                HeaderText &= dtTaskDetails.Rows(0)("TASK_DESCRIPTION")
            End If

            ' Me.LblHeader.Text = "Task:  " & HeaderText
            Me.Title = "Employees (" & HeaderText & ")"
            If IsDBNull(dtTaskDetails.Rows(0)("TASK_START_DATE")) = False Then
                If cGlobals.wvIsDate(dtTaskDetails.Rows(0)("TASK_START_DATE")) Then
                    ThisTask_StartDate = cGlobals.wvCDate(dtTaskDetails.Rows(0)("TASK_START_DATE"))
                    Me.RadDatePickerStartDate.SelectedDate = ThisTask_StartDate
                End If
            End If
            If IsDBNull(dtTaskDetails.Rows(0)("JOB_REVISED_DATE")) = False Then
                If cGlobals.wvIsDate(dtTaskDetails.Rows(0)("JOB_REVISED_DATE")) Then
                    ThisTask_DueDate = cGlobals.wvCDate(dtTaskDetails.Rows(0)("JOB_REVISED_DATE"))
                    Me.RadDatePickerDueDate.SelectedDate = ThisTask_DueDate
                End If
            End If
            If IsDBNull(dtTaskDetails.Rows(0)("DUE_TIME")) = False Then
                LblTimeDue.Text = dtTaskDetails.Rows(0)("DUE_TIME")
            End If
            If IsDBNull(dtTaskDetails.Rows(0)("JOB_HRS")) = False Then
                LblDefaultHours.Text = dtTaskDetails.Rows(0)("JOB_HRS")
                Try
                    ThisTask_DefaultHours = CType(dtTaskDetails.Rows(0)("JOB_HRS"), Double).ToString
                Catch ex As Exception
                    ThisTask_DefaultHours = "0.00"
                End Try
            End If
            'Quick default:
            Session("TaskDefaultHours") = ThisTask_DefaultHours

            Me.SetLimitToRole()

            Try
                If Request.QueryString("From") IsNot Nothing AndAlso Request.QueryString("From") = "pb" Then

                    Me.TableDates.Visible = False

                End If
            Catch ex As Exception
            End Try

        Else

            Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As New DataTable

            dt = oSchedule.GetScheduleTask(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum)

            If IsDBNull(dt.Rows(0)("TASK_CODE")) = False Then

                ThisTask_TaskCode = dt.Rows(0)("TASK_CODE")
                HeaderText = dt.Rows(0)("TASK_CODE") & " - "

            End If
            If IsDBNull(dt.Rows(0)("TASK_DESCRIPTION")) = False Then

                HeaderText &= dt.Rows(0)("TASK_DESCRIPTION")

            End If

            Me.Title = "Employees (" & HeaderText & ")"


        End If

    End Sub

    Private Sub RadGridTaskEmployees_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTaskEmployees.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim tb As System.Web.UI.WebControls.TextBox
                Try
                    tb = CType(dataItem("colHOURS_ALLOWED").FindControl("TxtTHOURS_ALLOWED"), TextBox)
                    tb.Attributes.Add("onclick", "SetDefaultHours('" & tb.ClientID & "','" & ThisTask_DefaultHours.ToString() & "')")
                Catch ex As Exception

                End Try

                If Me.RadToolBarButtonChkAvailability.Checked = True Then
                    Dim ThisEmpCode As String = ""
                    Try
                        ThisEmpCode = CType(dataItem.OwnerTableView.DataKeyValues(dataItem.ItemIndex)("EMP_CODE"), String)
                    Catch ex As Exception
                        ThisEmpCode = ""
                    End Try
                    If ThisEmpCode <> "" Then
                        Try
                            Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                            Dim ds As New DataSet
                            Dim DtTotals As New DataTable
                            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                                ThisTask_StartDate = Me.RadDatePickerStartDate.SelectedDate
                            End If
                            If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
                                ThisTask_DueDate = Me.RadDatePickerDueDate.SelectedDate
                            End If

                            'ds = oTasks.GetWorkloadEmployee(CStr(Session("UserCode")), ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, "", "", "", "", "", "", "", "", False, "", "", 0, 0, "", "", True)
                            Dim r As New cResources
                            Dim ThisLevel As cResources.SummaryLevel
                            ThisLevel = cResources.SummaryLevel.Day
                            ds = r.GetAvailabilityDataSet(ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, ThisLevel, "", "", True)
                            DtTotals = ds.Tables(1)
                            ''Dim totalavailable As Decimal = CType(dt.Rows(0)("TOTAL_AVAIL_WORKING_HOURS"), Decimal)
                            ''Dim totalallocated As Decimal = CType(dt.Rows(0)("TOT_ADJ_JOB_HRS"), Decimal)
                            ''If totalallocated > totalavailable Then
                            ''    CType(dataItem.FindControl("TxtTHOURS_ALLOWED"), TextBox).BackColor = Color.Red
                            ''End If
                            Dim StdHrsAvail As Decimal = CType(0.0, Decimal)
                            Dim HrsOff As Decimal = CType(0.0, Decimal)
                            Dim ApptHrs As Decimal = CType(0.0, Decimal)
                            Dim HrsAssignedToTasks As Decimal = CType(0.0, Decimal)
                            Dim TotalAssignmentsHours As Decimal = CType(0.0, Decimal)
                            Dim Variance As Decimal = CType(0.0, Decimal)
                            If Not IsDBNull(DtTotals.Rows(0)("STD_HRS_AVAIL")) Then
                                If IsNumeric(DtTotals.Rows(0)("STD_HRS_AVAIL")) = True Then
                                    StdHrsAvail = CType(DtTotals.Rows(0)("STD_HRS_AVAIL"), Decimal)
                                End If
                            End If
                            If Not IsDBNull(DtTotals.Rows(0)("HRS_APPTS")) Then
                                If IsNumeric(DtTotals.Rows(0)("HRS_APPTS")) = True Then
                                    ApptHrs = CType(DtTotals.Rows(0)("HRS_APPTS"), Decimal)
                                End If
                            End If
                            If Not IsDBNull(DtTotals.Rows(0)("HRS_USED_NON_TASK")) Then
                                If IsNumeric(DtTotals.Rows(0)("HRS_USED_NON_TASK")) = True Then
                                    HrsOff = CType(DtTotals.Rows(0)("HRS_USED_NON_TASK"), Decimal)
                                End If
                            End If
                            If Not IsDBNull(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) Then
                                If IsNumeric(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) = True Then
                                    TotalAssignmentsHours = CType(DtTotals.Rows(0)("HRS_ASSIGNED_TASK"), Decimal)
                                End If
                            End If
                            Variance = StdHrsAvail - HrsOff - TotalAssignmentsHours - ApptHrs
                            If Variance < 0 Then
                                CType(dataItem.FindControl("TxtTHOURS_ALLOWED"), TextBox).BackColor = Color.Red
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridTaskEmployees_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTaskEmployees.NeedDataSource
        Try

            Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Me.RadGridTaskEmployees.DataSource = oSchedule.GetTaskEmpList(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridTaskEmployees_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridTaskEmployees.DetailTableDataBind
        Try
            Dim parentItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)
            If Not parentItem.Edit Then
                Dim ThisEmpCode As String = parentItem.GetDataKeyValue("EMP_CODE").ToString()
                Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                    ThisTask_StartDate = Me.RadDatePickerStartDate.SelectedDate
                Else
                    ThisTask_StartDate = Now
                End If
                If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
                    ThisTask_DueDate = Me.RadDatePickerDueDate.SelectedDate
                Else
                    ThisTask_DueDate = Now
                End If

                Dim ds As New DataSet
                ThisLevel = cResources.SummaryLevel.Day
                'ds = oTasks.GetWorkloadEmployee(Session("UserCode"), ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, , , , , , , , , False, , , , , , , True)
                ds = r.GetActualizationDataSet(ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, ThisLevel, "", "", True, "", "", "", "", "", "", "", "", False, "", "", 0, 0, "", False, True)
                Select Case e.DetailTableView.Name
                    Case "AssignmentsGrid"
                        Try
                            e.DetailTableView.DataSource = ds.Tables(4).DefaultView 'oTasks.GetWorkloadEmployee(Session("UserCode"), ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, , , , , , , , , False).Tables(0).DefaultView
                        Catch ex As Exception
                            e.DetailTableView.Visible = False
                        End Try
                    Case "WorkloadGrid"
                        Try
                            Dim dt As New DataTable
                            'dt = ds.Tables(1) 'oTasks.GetWorkload(Session("UserCode"), ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, , , , , , , , , False, , , )
                            'ds = r.GetAvailabilityDataSet(ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, ThisLevel, "", "", True)
                            'e.DetailTableView.DataSource = BuildWorkloadDT(dt)
                            e.DetailTableView.DataSource = BuildWorkloadDTAvail(ds.Tables(1))
                        Catch ex As Exception
                            e.DetailTableView.Visible = False
                        End Try
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridTaskEmployees_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTaskEmployees.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim index As Integer = e.Item.ItemIndex
            Dim CurrRecordID As Integer = 0
            Try
                CurrRecordID = e.Item.OwnerTableView.DataKeyValues(index)("ID")
            Catch ex As Exception
                CurrRecordID = 0
            End Try
            Select Case e.CommandName
                Case "RemoveEmpFromTask"

                    If CurrRecordID > 0 Then

                        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                        oSchedule.RemoveEmployeeFromTask(CurrRecordID)

                    End If

                    RebindGrids()

                Case "UpdateRow"
                    If CurrRecordID > 0 Then
                        Dim ThisDaysAllowed As Integer
                        Dim ThisHoursAllowed As Decimal
                        Dim ThisStartDate As Date
                        Dim ThisDueDate As Date
                        If ValidateRow(e, ThisDaysAllowed, ThisHoursAllowed, ThisStartDate, ThisDueDate) = True Then
                            Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                            oSchedule.UpdateTaskEmployee(CurrRecordID, ThisHoursAllowed)
                        End If
                    End If
                Case "RemoveSelectedEmpsFromTask"

                    Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim HasSelected As Boolean = False
                    For Each row As Telerik.Web.UI.GridDataItem In Me.RadGridTaskEmployees.MasterTableView.Items

                        If row.Selected = True Then

                            HasSelected = True
                            oSchedule.RemoveEmployeeFromTask(row.GetDataKeyValue("ID"))

                        End If

                    Next

                    If HasSelected = True Then RebindGrids()

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddDTRows(ByVal TheDT As DataTable, ByVal TextData As String, ByVal DataData As String, Optional ByVal NumAfterDec As Integer = 2)
        Try
            Dim r As DataRow
            r = TheDT.NewRow
            If IsNumeric(DataData) = True Then
                DataData = FormatNumber(DataData, NumAfterDec, True, True, True)
            End If
            With r
                .Item("TextColumn") = TextData
                .Item("DataColumn") = DataData
            End With
            TheDT.Rows.Add(r)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEmployeesList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEmployeesList.ItemDataBound

    End Sub

    Private Sub RadGridEmployeesList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEmployeesList.NeedDataSource
        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Me.RadGridEmployeesList.DataSource = oSchedule.GetAvailableEmpList(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, Me.RadToolBarButtonChkLimitToRole.Checked, ThisTask_TaskCode, Session("UserCode"))
    End Sub

    Private Sub RadGridEmployeesList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEmployeesList.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim index As Integer = e.Item.ItemIndex
            Dim CurrEmpCode As String = ""
            Dim currdefhrs As Decimal = 0.0
            Try
                CurrEmpCode = e.Item.OwnerTableView.DataKeyValues(index)("EMPCODE")
            Catch ex As Exception
                CurrEmpCode = ""
            End Try
            Select Case e.CommandName
                Case "AddEmpToTask"
                    If CurrEmpCode <> "" Then
                        If Not Session("TaskDefaultHours") Is Nothing Then
                            If IsNumeric(Session("TaskDefaultHours")) Then
                                currdefhrs = CType(Session("TaskDefaultHours"), Decimal)
                            End If
                        End If
                        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                        If oSchedule.CheckJobComponentTaskEmployee(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, CurrEmpCode) = False Then
                            oSchedule.AddEmployeeToTask(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, CurrEmpCode, , , currdefhrs)
                        End If
                        RebindGrids()
                    End If
                Case "AddSelectedEmpsToTask"

                    Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim HasSelected As Boolean = False


                    If Not Session("TaskDefaultHours") Is Nothing Then
                        If IsNumeric(Session("TaskDefaultHours")) Then
                            currdefhrs = CType(Session("TaskDefaultHours"), Decimal)
                        End If
                    End If

                    For Each row As Telerik.Web.UI.GridDataItem In Me.RadGridEmployeesList.MasterTableView.Items

                        If row.Selected = True Then

                            CurrEmpCode = ""
                            CurrEmpCode = row.GetDataKeyValue("EMPCODE")

                            If CurrEmpCode <> "" Then

                                If oSchedule.CheckJobComponentTaskEmployee(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, CurrEmpCode) = False Then

                                    oSchedule.AddEmployeeToTask(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, CurrEmpCode, , , currdefhrs)
                                    HasSelected = True

                                End If

                            End If

                        End If

                    Next

                    If HasSelected = True Then RebindGrids()

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEmployeesList_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridEmployeesList.DetailTableDataBind

        Try
            Dim parentItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)
            If Not parentItem.Edit Then
                Dim ThisEmpCode As String = parentItem.GetDataKeyValue("EMPCODE").ToString()
                Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                    ThisTask_StartDate = Me.RadDatePickerStartDate.SelectedDate
                Else
                    ThisTask_StartDate = Now
                End If
                If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
                    ThisTask_DueDate = Me.RadDatePickerDueDate.SelectedDate
                Else
                    ThisTask_DueDate = Now
                End If
                Dim ds As New DataSet
                ThisLevel = cResources.SummaryLevel.Day
                'ds = oTasks.GetWorkloadEmployee(Session("UserCode"), ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, , , , , , , , , False, , , , , , , True)
                ds = r.GetAvailabilityDataSet(ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, ThisLevel, "", "", True)
                Select Case e.DetailTableView.Name
                    Case "AssignmentsGrid"
                        Try
                            e.DetailTableView.DataSource = ds.Tables(4).DefaultView 'oTasks.GetWorkloadEmployee(Session("UserCode"), ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, , , , , , , , , False).Tables(0).DefaultView
                        Catch ex As Exception
                            e.DetailTableView.Visible = False
                        End Try
                    Case "WorkloadGrid"
                        Try
                            Dim dt As New DataTable
                            'dt = ds.Tables(1) ' oTasks.GetWorkload(Session("UserCode"), ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, , , , , , , , , False, , , )
                            'ThisLevel = cResources.SummaryLevel.Day
                            'ds = r.GetAvailabilityDataSet(ThisEmpCode, ThisTask_StartDate, ThisTask_DueDate, ThisLevel, "", "", True)
                            'e.DetailTableView.DataSource = BuildWorkloadDT(dt)
                            e.DetailTableView.DataSource = BuildWorkloadDTAvail(ds.Tables(1))
                        Catch ex As Exception
                            e.DetailTableView.Visible = False
                        End Try
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ValidateRow(ByVal e As Telerik.Web.UI.GridCommandEventArgs, ByRef DaysAllowed As Integer, ByRef HoursAllowed As Decimal, ByRef SDate As Date, ByRef DDate As Date) As Boolean
        Dim IsValidRow As Boolean = True
        Dim RowDaysAllowed As String
        Dim RowHoursAllowed As String
        Dim RowStartDate As String
        Dim RowDueDate As String
        Dim ValidationMessage As String = ""
        Dim breaktype As MiscFN.DisplayMedium = MiscFN.DisplayMedium.javascript

        'Try
        '    RowDaysAllowed = CType(e.Item.FindControl("TxtTDAYS_ALLOWED"), TextBox).Text
        '    If RowDaysAllowed <> "" Then
        '        If IsNumeric(RowDaysAllowed) = False Then
        '            ValidationMessage = "Days Allowed is not a number." & MiscFN.LineBreak(breaktype)
        '            IsValidRow = False
        '        Else
        '            DaysAllowed = CType(RowDaysAllowed, Integer)
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
        Try
            RowHoursAllowed = CType(e.Item.FindControl("TxtTHOURS_ALLOWED"), TextBox).Text
            If RowHoursAllowed <> "" Then
                If IsNumeric(RowHoursAllowed) = False Then
                    ValidationMessage &= "Hours Allowed is not a number." & MiscFN.LineBreak(breaktype)
                    IsValidRow = False
                Else
                    HoursAllowed = CType(RowHoursAllowed, Decimal)
                End If
            End If
        Catch ex As Exception
        End Try
        If IsValidRow = False And ValidationMessage <> "" Then
            'FIX: MiscFN.ShowRadAjaxMessage(Me.RadAjaxManager1, ValidationMessage, "Row invalid")
        End If
        Return IsValidRow

    End Function

    Private Function SaveTaskRow(ByVal ThisRowID As Integer, ByVal ThisDaysAllowed As Integer, ByVal ThisHoursAllowed As Decimal, ByVal ThisStartDate As String, ByVal ThisDueDate As String) As String
        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        oSchedule.UpdateTaskEmployee(ThisRowID, ThisHoursAllowed)
    End Function

    Private Function SaveTaskGrid()
        Try
            Dim RowCount As Integer = Me.RadGridTaskEmployees.MasterTableView.Items.Count
            Dim ThisRowID As Integer = 0
            Dim ThisHoursAllowed As Decimal = 0
            Dim ThisJob As Integer = 0
            Dim ThisComp As Integer = 0
            Dim ThisSeq As Integer = 0
            Dim ThisEmp As String = ""
            Dim RecType As String = ""
            Dim AlertID As Integer = 0

            If RowCount > 0 Then
                Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                For i As Integer = 0 To RowCount - 1
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTaskEmployees.Items(i), Telerik.Web.UI.GridDataItem)
                    Try
                        ThisRowID = CurrentGridRow.GetDataKeyValue("ID")
                    Catch ex As Exception
                        ThisRowID = 0
                    End Try
                    Try
                        ThisHoursAllowed = CType(DirectCast(CurrentGridRow.FindControl("TxtTHOURS_ALLOWED"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        ThisHoursAllowed = 0.0
                    End Try
                    If ThisRowID > 0 Then
                        oSchedule.UpdateTaskEmployee(ThisRowID, ThisHoursAllowed)
                    End If
                Next
            End If

            Dim gtv As Telerik.Web.UI.GridTableView
            For i As Integer = 0 To Me.RadGridTaskEmployees.MasterTableView.Items.Count - 1
                ThisEmp = Me.RadGridTaskEmployees.MasterTableView.Items(i).GetDataKeyValue("EMP_CODE")
                For j As Integer = 0 To Me.RadGridTaskEmployees.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                    gtv = CType(Me.RadGridTaskEmployees.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                    If gtv.Items.Count > 0 Then
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                            If gridDataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or gridDataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                Try
                                    ThisJob = gridDataItem.GetDataKeyValue("JOB_NUMBER")
                                Catch ex As Exception
                                    ThisJob = 0
                                End Try
                                Try
                                    ThisComp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                                Catch ex As Exception
                                    ThisComp = 0
                                End Try
                                Try
                                    ThisSeq = gridDataItem.GetDataKeyValue("SEQ_NBR")
                                Catch ex As Exception
                                    ThisSeq = 0
                                End Try
                                Try
                                    RecType = gridDataItem.GetDataKeyValue("REC_TYPE")
                                Catch ex As Exception
                                    RecType = ""
                                End Try
                                Try
                                    AlertID = gridDataItem.GetDataKeyValue("ALERT_ID")
                                Catch ex As Exception
                                    AlertID = 0
                                End Try
                                Try
                                    ThisHoursAllowed = CType(DirectCast(gridDataItem.FindControl("TxtJOB_HRS"), TextBox).Text, Decimal)
                                Catch ex As Exception
                                    ThisHoursAllowed = 0.0
                                End Try

                                If RecType = "T" Then
                                    If ThisJob > 0 Then
                                        Dim jt As New JOB_TRAFFIC_DET_EMPS(Session("ConnString"))
                                        jt.Where.JOB_NUMBER.Value = ThisJob
                                        jt.Where.JOB_COMPONENT_NBR.Value = ThisComp
                                        jt.Where.SEQ_NBR.Value = ThisSeq
                                        jt.Where.EMP_CODE.Value = ThisEmp
                                        If jt.Query.Load Then
                                            With jt
                                                .HOURS_ALLOWED = ThisHoursAllowed
                                                .Save()
                                            End With
                                        End If
                                    End If
                                End If
                                If RecType = "A" Then
                                    Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                                        alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                                        With alert
                                            .HoursAllowed = ThisHoursAllowed
                                        End With

                                        AdvantageFramework.Database.Procedures.Alert.Update(DbContext, alert)

                                    End Using
                                End If

                            End If
                        Next
                    End If
                Next
            Next

            For i As Integer = 0 To Me.RadGridEmployeesList.MasterTableView.Items.Count - 1
                ThisEmp = Me.RadGridEmployeesList.MasterTableView.Items(i).GetDataKeyValue("EMPCODE")
                For j As Integer = 0 To Me.RadGridEmployeesList.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                    gtv = CType(Me.RadGridEmployeesList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                    If gtv.Items.Count > 0 Then
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                            If gridDataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or gridDataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                Try
                                    ThisJob = gridDataItem.GetDataKeyValue("JOB_NUMBER")
                                Catch ex As Exception
                                    ThisJob = 0
                                End Try
                                Try
                                    ThisComp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                                Catch ex As Exception
                                    ThisComp = 0
                                End Try
                                Try
                                    ThisSeq = gridDataItem.GetDataKeyValue("SEQ_NBR")
                                Catch ex As Exception
                                    ThisSeq = 0
                                End Try
                                Try
                                    RecType = gridDataItem.GetDataKeyValue("REC_TYPE")
                                Catch ex As Exception
                                    RecType = ""
                                End Try
                                Try
                                    AlertID = gridDataItem.GetDataKeyValue("ALERT_ID")
                                Catch ex As Exception
                                    AlertID = 0
                                End Try
                                Try
                                    ThisHoursAllowed = CType(DirectCast(gridDataItem.FindControl("TxtJOB_HRS"), TextBox).Text, Decimal)
                                Catch ex As Exception
                                    ThisHoursAllowed = 0.0
                                End Try
                                If RecType = "T" Then
                                    If ThisJob > 0 Then
                                        Dim jt As New JOB_TRAFFIC_DET_EMPS(Session("ConnString"))
                                        jt.Where.JOB_NUMBER.Value = ThisJob
                                        jt.Where.JOB_COMPONENT_NBR.Value = ThisComp
                                        jt.Where.SEQ_NBR.Value = ThisSeq
                                        jt.Where.EMP_CODE.Value = ThisEmp
                                        If jt.Query.Load Then
                                            With jt
                                                .HOURS_ALLOWED = ThisHoursAllowed
                                                .Save()
                                            End With
                                        End If
                                    End If
                                End If
                                If RecType = "A" Then
                                    Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                                    If AlertID > 0 Then
                                        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                                            alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                                            With alert
                                                .HoursAllowed = ThisHoursAllowed
                                            End With

                                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, alert)

                                        End Using
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
            Next

        Catch ex As Exception

        End Try
    End Function

    Private Sub RebindGrids()
        RadGridEmployeesList.Rebind()
        RadGridTaskEmployees.Rebind()
    End Sub

    Private Function BuildWorkloadDT(ByVal dtv As DataTable) As DataTable
        ''variance calc
        'Dim totalavailable As Decimal = 0.0
        'Dim total As Decimal = 0.0
        'Try
        '    totalavailable = Convert.ToDecimal(dtv.Rows(0).Item(4)) - Convert.ToDecimal(dtv.Rows(0).Item(7))
        '    total = totalavailable - (Convert.ToDecimal(dtv.Rows(0).Item(5)) + Convert.ToDecimal(dtv.Rows(0).Item(6)))
        '    total = total - Convert.ToDecimal(dtv.Rows(0).Item(3).ToString())
        'Catch ex As Exception

        'End Try

        'Dim dt As New DataTable

        'dt = MiscFN.PivotTable(dtv.Copy())
        Try
            Dim dtDisplay As New DataTable
            Dim DtTextCol As DataColumn = New DataColumn("TextColumn")
            DtTextCol.DataType = System.Type.GetType("System.String")
            dtDisplay.Columns.Add(DtTextCol)

            Dim DtDataCol As DataColumn = New DataColumn("DataColumn")
            DtDataCol.DataType = System.Type.GetType("System.String")
            dtDisplay.Columns.Add(DtDataCol)

            'Dim StrText As String = ""
            'Dim HrsAllocated As Decimal = 0.0
            'Dim HrsAvailable As Decimal = 0.0
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    StrText = dt.Rows(i)(0).ToString()
            '    Select Case StrText
            '        Case "TOTAL_HOURS_AVAILABLE"
            '            StrText = "Standard Hours Available:"
            '            AddDTRows(dtDisplay, StrText, dt.Rows(i)(1).ToString())
            '            If IsNumeric(dt.Rows(i)(1)) = True Then
            '                HrsAvailable = CType(dt.Rows(i)(1), Decimal)
            '            End If
            '        Case "HOURS_ALLOCATED"
            '            StrText = "Hours Assigned to Tasks:"
            '            AddDTRows(dtDisplay, StrText, dt.Rows(i)(1).ToString())
            '            If IsNumeric(dt.Rows(i)(1)) = True Then
            '                HrsAllocated = CType(dt.Rows(i)(1), Decimal)
            '            End If
            '        Case "HOURS_OFF"
            '            StrText = "Hours Off:"
            '            AddDTRows(dtDisplay, StrText, dt.Rows(i)(1).ToString())
            '    End Select
            'Next
            Dim totalavailable As Decimal = CType(dtv.Rows(0)("TOTAL_WORKING_HOURS"), Decimal) 'Convert.ToDecimal(dtv.Rows(0)("TOTAL_WORKING_HOURS")) - Convert.ToDecimal(dtv.Rows(0)("TOTAL_APPT_HRS")) 'Convert.ToDecimal(dtv.Rows(0).Item(4)) - Convert.ToDecimal(dtv.Rows(0).Item(7))
            AddDTRows(dtDisplay, "Standard Hours Available:", FormatNumber(totalavailable, 2, True, False, True))
            AddDTRows(dtDisplay, "Hours Off:", FormatNumber(CType(dtv.Rows(0)("TOTAL_APPT_HRS"), Decimal), 2, True, False, True))
            AddDTRows(dtDisplay, "Hours Assigned to Tasks:", FormatNumber(CType(dtv.Rows(0)("TOTAL_ADJ_JOB_HRS"), Decimal), 2, True, False, True))

            Dim variance As Decimal
            variance = totalavailable - CType(dtv.Rows(0)("TOTAL_APPT_HRS"), Decimal) - CType(dtv.Rows(0)("TOTAL_ADJ_JOB_HRS"), Decimal)
            'total = totalavailable - (Convert.ToDecimal(dtv.Rows(0).Item(5)) + Convert.ToDecimal(dtv.Rows(0).Item(6)))
            If variance < 0.0 Then
                AddDTRows(dtDisplay, "Variance:", "<span style=""warning"">" & FormatNumber(variance, 2, True, False, True) & "</span>")
            Else
                AddDTRows(dtDisplay, "Variance:", FormatNumber(variance, 2, True, False, True))
                '    AddDTRows(dtDisplay, "Variance:", "N/A")
            End If

            Return dtDisplay
        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWorkloadDTAvail(ByVal dtv As DataTable) As DataTable
        ''variance calc
        'Dim totalavailable As Decimal = 0.0
        'Dim total As Decimal = 0.0
        'Try
        '    totalavailable = Convert.ToDecimal(dtv.Rows(0).Item(4)) - Convert.ToDecimal(dtv.Rows(0).Item(7))
        '    total = totalavailable - (Convert.ToDecimal(dtv.Rows(0).Item(5)) + Convert.ToDecimal(dtv.Rows(0).Item(6)))
        '    total = total - Convert.ToDecimal(dtv.Rows(0).Item(3).ToString())
        'Catch ex As Exception

        'End Try

        'Dim dt As New DataTable

        'dt = MiscFN.PivotTable(dtv.Copy())
        Try
            Dim dtDisplay As New DataTable
            Dim DtTextCol As DataColumn = New DataColumn("TextColumn")
            DtTextCol.DataType = System.Type.GetType("System.String")
            dtDisplay.Columns.Add(DtTextCol)

            Dim DtDataCol As DataColumn = New DataColumn("DataColumn")
            DtDataCol.DataType = System.Type.GetType("System.String")
            dtDisplay.Columns.Add(DtDataCol)

            'Dim StrText As String = ""
            'Dim HrsAllocated As Decimal = 0.0
            'Dim HrsAvailable As Decimal = 0.0
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    StrText = dt.Rows(i)(0).ToString()
            '    Select Case StrText
            '        Case "TOTAL_HOURS_AVAILABLE"
            '            StrText = "Standard Hours Available:"
            '            AddDTRows(dtDisplay, StrText, dt.Rows(i)(1).ToString())
            '            If IsNumeric(dt.Rows(i)(1)) = True Then
            '                HrsAvailable = CType(dt.Rows(i)(1), Decimal)
            '            End If
            '        Case "HOURS_ALLOCATED"
            '            StrText = "Hours Assigned to Tasks:"
            '            AddDTRows(dtDisplay, StrText, dt.Rows(i)(1).ToString())
            '            If IsNumeric(dt.Rows(i)(1)) = True Then
            '                HrsAllocated = CType(dt.Rows(i)(1), Decimal)
            '            End If
            '        Case "HOURS_OFF"
            '            StrText = "Hours Off:"
            '            AddDTRows(dtDisplay, StrText, dt.Rows(i)(1).ToString())
            '    End Select
            'Next
            Dim totalavailable As Decimal = CType(dtv.Rows(0)("STD_HRS_AVAIL"), Decimal) 'Convert.ToDecimal(dtv.Rows(0)("TOTAL_WORKING_HOURS")) - Convert.ToDecimal(dtv.Rows(0)("TOTAL_APPT_HRS")) 'Convert.ToDecimal(dtv.Rows(0).Item(4)) - Convert.ToDecimal(dtv.Rows(0).Item(7))
            AddDTRows(dtDisplay, "Standard Hours Available:", FormatNumber(totalavailable, 2, True, False, True))
            AddDTRows(dtDisplay, "Appointment Hours:", FormatNumber(CType(dtv.Rows(0)("HRS_APPTS"), Decimal), 2, True, False, True))
            AddDTRows(dtDisplay, "Hours Off:", FormatNumber(CType(dtv.Rows(0)("HRS_USED_NON_TASK"), Decimal), 2, True, False, True))
            AddDTRows(dtDisplay, "Hours Assigned to Tasks:", FormatNumber(CType(dtv.Rows(0)("HRS_ASSIGNED_TASK"), Decimal), 2, True, False, True))

            Dim variance As Decimal
            variance = totalavailable - CType(dtv.Rows(0)("HRS_USED_NON_TASK"), Decimal) - CType(dtv.Rows(0)("HRS_ASSIGNED_TASK"), Decimal) - CType(dtv.Rows(0)("HRS_APPTS"), Decimal)
            'total = totalavailable - (Convert.ToDecimal(dtv.Rows(0).Item(5)) + Convert.ToDecimal(dtv.Rows(0).Item(6)))
            If variance < 0.0 Then
                AddDTRows(dtDisplay, "Variance:", "<span style=""warning"">" & FormatNumber(variance, 2, True, False, True) & "</span>")
            Else
                AddDTRows(dtDisplay, "Variance:", FormatNumber(variance, 2, True, False, True))
                '    AddDTRows(dtDisplay, "Variance:", "N/A")
            End If

            Return dtDisplay
        Catch ex As Exception

        End Try
    End Function

    'Private Sub BtnUpdateTaskEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdateTaskEmployees.Click
    '    'Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
    '    SaveTaskGrid()
    '    If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
    '        ThisTask_StartDate = Me.RadDatePickerStartDate.SelectedDate
    '    End If
    '    If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
    '        ThisTask_DueDate = Me.RadDatePickerDueDate.SelectedDate
    '    End If
    '    Me.RebindGrids()
    '    'Me.CloseAndRefresh()
    'End Sub

    'Private Sub ChkLimitToRole_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLimitToRole.CheckedChanged
    '    Me.SetLimitToRole()
    '    Me.RadGridEmployeesList.Rebind()
    'End Sub
    Private Sub SetLimitToRole()
        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))

        If Me.RadToolBarButtonChkLimitToRole.Checked = True And ThisTask_TaskCode <> "" Then
            Try
                With Me.DataListRoles
                    .DataSource = oSchedule.GetRolesDT(ThisTask_TaskCode)
                    .DataBind()
                End With
                Me.FieldsetRoles.Visible = True
            Catch ex As Exception

            End Try
        Else
            Me.FieldsetRoles.Visible = False
        End If

    End Sub
    Private Sub CloseAndRefresh()

        If Request.QueryString("From") IsNot Nothing Then

            Dim GotoPage As String = String.Empty

            Select Case Request.QueryString("From")
                Case "cal"

                    GotoPage = "Calendar_MonthView.aspx?FromApp=" & Request.QueryString("FromApp") & "&JobNum=" & Me.ThisTask_JobNum & "&JobCompNum=" & Me.ThisTask_JobComp
                    Me.CloseThisWindowAndRefreshCaller(GotoPage, True)

                Case "ts"

                    Me.CloseThisWindowAndRefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")

                Case "pb"

                    Me.CloseThisWindowAndRefreshCaller(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "ProjectBoard")

                Case Else

                    Me.CloseThisWindow()

            End Select

        Else

            Me.CloseThisWindow()

        End If


    End Sub

    Private Sub GetStartDueFromHeader(ByRef StartDate As String, ByRef DueDate As String)

    End Sub

    'Private Sub ChkAvailability_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAvailability.CheckedChanged

    'End Sub

    Private Sub RadToolbarEmployees_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEmployees.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Save"
                    SaveTaskGrid()
                    If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                        ThisTask_StartDate = Me.RadDatePickerStartDate.SelectedDate
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
                        ThisTask_DueDate = Me.RadDatePickerDueDate.SelectedDate
                    End If
                    'Me.RebindGrids()
                    'Me.CloseThisWindowAndRefreshCaller("Content")
                    Me.RefreshCaller("Content")
                Case "Refresh"
                    If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                        ThisTask_StartDate = Me.RadDatePickerStartDate.SelectedDate
                    End If
                    If MiscFN.ValidDate(Me.RadDatePickerDueDate) = True Then
                        ThisTask_DueDate = Me.RadDatePickerDueDate.SelectedDate
                    End If
                    Me.RebindGrids()
                Case "Role"
                    Me.SetLimitToRole()

                    Dim AppVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
                    AppVars.getAllAppVars()
                    AppVars.setAppVar("LimitRoleList", Me.RadToolBarButtonChkLimitToRole.Checked)
                    AppVars.SaveAllAppVars()


                    Me.RadGridEmployeesList.Rebind()
                Case "Availability"
                    Me.RadGridTaskEmployees.Rebind()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Sub UpdateHoursAllowed(ByVal ID As Integer, ByVal EmployeeCode As String, ByVal HoursAllowed As String)

        'objects
        Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByID(DbContext, ID)

                If JobComponentTaskEmployee IsNot Nothing AndAlso JobComponentTaskEmployee.EmployeeCode = EmployeeCode Then

                    If Not String.IsNullOrWhiteSpace(HoursAllowed) Then

                        JobComponentTaskEmployee.Hours = CDec(HoursAllowed)

                    Else

                        JobComponentTaskEmployee.Hours = Nothing

                    End If

                    AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee)

                End If

            End Using

        Catch ex As Exception

        End Try

    End Sub

End Class
