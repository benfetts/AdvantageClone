Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Drawing

Partial Public Class Event_Detail
    Inherits Webvantage.BaseChildPage

    'passe in minus 1 or zero to set form to "add new"
    Private EventId As Integer = -1
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private IsEdit As Boolean = False
    Private CliCode As String = ""
    Private FromPage As Integer = 0 '0 = job, 1 = calendar, 2 = event scheduler, 3 = event task scheduler
    Private TasksLocked As Boolean = False

    Private CutOff As DateTime = Nothing
    Private GenId As Integer = 0

    Public Property DtEventTasks() As DataTable
        Get
            Try
                Dim o As Object = Session("EVENT_TASKS_DT")
                If o Is Nothing Then
                    Dim evt As New cEvents
                    Return evt.EventTasksDatatable(Me.EventId)
                Else
                    Return CType(Session("EVENT_TASKS_DT"), DataTable)
                End If
            Catch ex As Exception
            End Try
        End Get
        Set(ByVal value As DataTable)
            Session("EVENT_TASKS_DT") = value
        End Set
    End Property

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.SetQSVars()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oSec As New cSecurity(Session("ConnString"))

        Me.TasksLocked = Not Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) = 1 '(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True) = False)

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Session("EVENT_TASKS_DT") = Nothing
            If IsEdit = True Then
                'load the event detail
                Me.LoadEvent()
            Else 'it is a new entry for an event
                Me.RblQuantityType.Items(1).Selected = True
                Try
                    Dim StrSQL As String = ""
                    StrSQL = "SELECT RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_COMPONENT_NBR), 3) "
                    StrSQL += " + '  ' + ISNULL(JOB_LOG.JOB_DESC, '') + ' / ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') AS JOB_AND_COMP"
                    StrSQL += " FROM JOB_COMPONENT WITH(NOLOCK) INNER JOIN"
                    StrSQL += " JOB_LOG WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER"
                    StrSQL += " WHERE"
                    StrSQL += " JOB_COMPONENT.JOB_NUMBER = " & Me.JobNumber.ToString()
                    StrSQL += " AND JOB_COMPONENT.JOB_COMPONENT_NBR = " & Me.JobComponentNbr.ToString() & ";"
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyCmd As New SqlCommand(StrSQL, MyConn)
                        Try
                            Me.LblJobComp.Text = MyCmd.ExecuteScalar
                        Catch ex As Exception
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                Catch ex As Exception
                End Try
                Me.UcEventType.EventTypeId = 1
            End If
            Me.LblFunctionCodeLabel.Visible = IsEdit
            Me.HlFunctionCode.Visible = Not IsEdit
            Me.TxtFunctionCode.Visible = Not IsEdit
            Me.TxtFunctionCodeDescription.Visible = Not IsEdit
            Me.LoadLookups()
            Me.RbTime.Checked = True
            Me.RbHours.Checked = False
        Else 'it's posting

        End If

    End Sub

    Private Sub RadToolbarEventDetails_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEventDetails.ButtonClick
        Select Case e.Item.Value
            Case "SaveEvent"
                Dim v As New cValidations(Session("ConnString"))
                Dim evt As New cEvents
                Dim TheStartDate As DateTime = Nothing
                Dim TheEventTypeId As Integer = 1
                'validate:
                '======================================================================================================================
                If Me.TxtShortDesc.Text.Replace(" ", "").Trim() = "" Then
                    Me.ShowMessage("Event Description is required")
                    Me.TxtShortDesc.Focus()
                    Exit Sub
                End If
                If Me.UcEventType.SelectedIndex = 0 Then
                    'Me.ShowMessage("Event Type is required")
                    'Me.UcEventType.Focus()
                    'Exit Sub
                    TheEventTypeId = 1
                Else
                    TheEventTypeId = Me.UcEventType.EventTypeId
                End If

                If Me.TxtFunctionCode.Text.Trim() = "" Then
                    Me.ShowMessage("Function Code is required")
                    Me.TxtFunctionCode.Focus()
                    Exit Sub
                Else
                    'validate function code
                    If v.ValidateFunctionCodeEst(Me.TxtFunctionCode.Text) = False Then
                        Me.ShowMessage("Function Code invalid")
                        Exit Sub
                    End If
                End If

                'validate ad number
                If Me.TxtAdNumber.Text.Trim() <> "" Then
                    If v.ValidateAdNumber(Me.TxtAdNumber.Text) = False Then
                        Me.ShowMessage("Ad Number invalid")
                        Exit Sub
                    End If
                End If

                If Me.RadDatePickerEventDate.SelectedDate = Nothing Or Me.RadDatePickerEventDate.DateInput.Text = "" Then
                    Me.ShowMessage("Event Date is required")
                    Exit Sub
                End If

                If MiscFN.ValidDate(Me.RadDatePickerEventDate) = False Then
                    Me.ShowMessage("Event Date invalid")
                    Exit Sub
                Else
                    TheStartDate = Me.RadDatePickerEventDate.SelectedDate
                End If

                If Me.RbHours.Checked = True Then
                    If Me.TxtHours.Text.Trim() = "" Then
                        Me.ShowMessage("Number of Hours is required")
                        Exit Sub
                    End If
                    If IsNumeric(Me.TxtHours.Text) = False Then
                        Me.ShowMessage("Hours invalid")
                        Exit Sub
                    End If
                    If IsNumeric(Me.TxtHours.Text) = True Then
                        Dim n As Decimal = CType(Me.TxtHours.Text, Decimal)
                        If n > 23.98 Then
                            n = 23.98
                        End If
                        Me.TxtHours.Text = n
                    End If
                End If



                'set stuff
                '======================================================================================================================

                Dim TheStartTime As DateTime = Nothing 'Convert.ToDateTime(Me.RadTimePickerStart.SelectedDate)
                Dim TheEndTime As DateTime = Nothing 'Convert.ToDateTime(Me.RadTimePickerEnd.SelectedDate)

                'need to clean up the start and end time here!?
                If Me.RadTimePickerStartTime.SelectedDate = Nothing Or Me.RadTimePickerStartTime.DateInput.Text = "" Then
                    TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
                Else
                    Try
                        TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerStartTime.SelectedDate, DateTime).ToShortTimeString())
                    Catch ex As Exception
                        TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
                    End Try
                End If
                Me.RadTimePickerStartTime.SelectedDate = TheStartTime

                If Me.RadTimePickerEndTime.SelectedDate = Nothing Or Me.RadTimePickerEndTime.DateInput.Text = "" Then
                    TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                Else
                    Try
                        Dim s As String = CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString()
                        If s = "12:00 AM" Then
                            TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                        Else
                            TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString())
                        End If
                    Catch ex As Exception
                        TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                    End Try
                End If
                Me.RadTimePickerEndTime.SelectedDate = TheEndTime


                'Set qty hours:
                Dim TheHours As Decimal = 0.0
                If IsNumeric(Me.TxtHours.Text) = True And Me.RbHours.Checked = True Then 'set to recalc the end time, everything ok
                    TheHours = CType(Me.TxtHours.Text, Decimal)
                    If TheHours <= 0 Then
                        Try
                            Dim ts As TimeSpan
                            ts = TheEndTime.Subtract(TheStartTime)
                            TheHours = CType(ts.TotalHours, Decimal)
                        Catch ex As Exception
                            TheHours = CType(0.0, Decimal)
                        End Try
                    Else
                        TheEndTime = DateAdd(DateInterval.Minute, TheHours * 60, TheStartTime)
                        Me.RadTimePickerEndTime.SelectedDate = TheEndTime
                    End If
                ElseIf IsNumeric(Me.TxtHours.Text) = False And Me.RbHours.Checked = True Then 'set to recalc the end time, invalid hours
                    Me.ShowMessage("Hours invalid")
                    Exit Sub
                ElseIf Me.RbTime.Checked = True Then 'set to recalc the hours...the start/end time auto-fix above
                    Try
                        Dim ts As TimeSpan
                        ts = TheEndTime.Subtract(TheStartTime)
                        TheHours = CType(ts.TotalHours, Decimal)
                    Catch ex As Exception
                        TheHours = CType(0.0, Decimal)
                    End Try
                End If

                Dim QtyType As Integer = 0
                Try
                    QtyType = CType(Me.RblQuantityType.SelectedValue, Integer)
                Catch ex As Exception
                    QtyType = 0
                End Try

                If Me.TxtHours.Text = "23.98" And Me.RbHours.Checked = True Then
                    TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                    'make sure hours in range...it should only be 23.98 if event started at midnight..
                    Try
                        Dim ts As TimeSpan
                        ts = TheEndTime.Subtract(TheStartTime)
                        TheHours = CType(ts.TotalHours, Decimal)
                    Catch ex As Exception
                        TheHours = CType(0.0, Decimal)
                    End Try
                    Me.TxtHours.Text = TheHours
                End If

                If TheHours <= 0 Then 'end time needs to go to next day:
                    'TheHours = TheHours + 24
                    'TheEndTime = DateAdd(DateInterval.Day, 1, TheEndTime)
                    'new req, don't allow
                    Me.ShowMessage("Events cannot cross days")
                    Exit Sub
                End If
                Try
                    If TheStartTime.ToShortDateString() <> TheEndTime.ToShortDateString() Then
                        Me.ShowMessage("Events cannot cross days")
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try

                Me.TxtHours.Text = Math.Round(TheHours, 2, MidpointRounding.AwayFromZero)


                ''Dim DeleteGeneratedEventTasks As Boolean = False 'if updating a resource, delete any previously generated tasks
                Dim UpdateSucceeded As Boolean = True

                Try
                    Dim rsc As New cResources()
                    If rsc.ResourceIsBooked(Me.UcResources.ResourceCode, Me.EventId, Me.RadDatePickerEventDate.SelectedDate, TheStartTime, TheEndTime) = True Then
                        Me.ShowMessage("The selected resource is booked on a different event for this time period")
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try

                If IsEdit = True Then 'update event
                    'If (Me.HfResource.Value.Trim() = Me.UcResources.ResourceCode.Trim()) Then
                    UpdateSucceeded = Me.SaveTasksGrid()
                    'End If
                    evt.EventUpdate(Me.EventId, Me.TxtShortDesc.Text, Me.TxtLongDesc.Text, Me.RadDatePickerEventDate.SelectedDate, TheHours, TheStartTime, TheEndTime, _
                                    Me.UcResources.ResourceCode, Me.TxtAdNumber.Text, Me.TxtLongDesc.Text, 0, QtyType, TheEventTypeId)
                    evt.EventUpdateResource(Me.EventId, Me.UcResources.ResourceCode, True, False, Me.UcResources.DeleteAutoTasks)
                Else 'insert event
                    Dim i As String = ""
                    i = evt.EventAddNew(Me.TxtShortDesc.Text, Me.TxtLongDesc.Text, "EJC", Me.RadDatePickerEventDate.SelectedDate, True, TheHours, TheStartTime, TheEndTime, _
                                        Me.UcResources.ResourceCode, Me.JobNumber, Me.JobComponentNbr, Me.TxtFunctionCode.Text, Me.TxtAdNumber.Text, _
                                        Me.TxtLongDesc.Text, 0, 0, Now, Session("UserCode"), QtyType, TheEventTypeId)
                    If IsNumeric(i) = True Then
                        Me.EventId = CType(i, Integer)
                    End If
                    If Me.EventId > 0 Then
                        evt.EventUpdateResource(Me.EventId, Me.UcResources.ResourceCode, True, False, Me.UcResources.DeleteAutoTasks)
                    End If
                End If

                If UpdateSucceeded = False Then Exit Sub

                'If IsEdit = False And Me.EventId > 0 Then

                Session("EVENT_TASKS_DT") = Nothing
                Me.RadGridEventTasks.Rebind()
                'MiscFN.ResponseRedirect("Event_Detail.aspx?j=" & Me.JobNumber & "&jc=" & Me.JobComponentNbr & "&evt=" & Me.EventId & "&cli=" & Me.CliCode & "&cod=" & Me.CutOff & "&g=" & Me.GenId & "&from=" & Me.FromPage.ToString())

                'Else
                '    Me.LoadEvent()
                '    Session("EVENT_TASKS_DT") = Nothing
                '    Me.RadGridEventTasks.Rebind()
                'End If
            Case "GoBack"
                '' Me.GoBackAction()
                'Dim qs As New AdvantageFramework.Web.QueryString()
                'With qs
                '    'Select Case FromPage
                '    '    Case 0
                '    '        .Page = "Event_View.aspx"
                '    '    Case 1
                '    '        .Page = "Calendar_MonthView.aspx"
                '    '    Case 2
                '    '        .Page = "Scheduler_Events.aspx"
                '    '    Case 3
                '    '        .Page = "Scheduler_EventTasks.aspx"
                '    'End Select
                '    .Page = "Event_View.aspx"
                '    .JobNumber = Me.JobNumber
                '    .JobComponentNbr = Me.JobComponentNbr
                '    .CutOffDate = Me.CutOff
                '    .Add("g", Me.GenId)
                'End With
                'Me.OpenWindow("", qs.ToString(True))
                ''me.CloseThisWindowAndRefreshCaller(qs.ToString(True), False, False)
                Me.CloseThisWindowAndRefreshCaller("Event_View.aspx")

            Case "DeleteEvent"
                If Me.EventId > 0 Then
                    Dim SbDelete As New System.Text.StringBuilder
                    With SbDelete
                        .Append("DELETE FROM [EVENT_TASK] WITH(ROWLOCK) WHERE EVENT_ID = ")
                        .Append(Me.EventId.ToString())
                        .Append(";")
                        .Append("DELETE FROM [EVENT] WITH(ROWLOCK) WHERE EVENT_ID = ")
                        .Append(Me.EventId.ToString())
                        .Append(";")
                    End With
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand(SbDelete.ToString(), MyConn, MyTrans)
                        Try
                            MyCmd.ExecuteNonQuery()
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                    '    Me.GoBackAction()
                    Me.CloseThisWindowAndRefreshCaller("Event_View.aspx")
                End If
        End Select
    End Sub

    Private Sub RadToolbarEventTasks_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEventTasks.ButtonClick
        Select Case e.Item.Value
            Case "AddTask"
                If EventId = -1 Then
                    Me.ShowMessage("Please save the event before adding tasks")
                    Exit Sub
                End If
                Me.SaveTasksDatatable()
                Dim evt As New cEvents
                Dim TheStartDate As DateTime = Nothing
                'validate:
                '======================================================================================================================
                If MiscFN.ValidDate(Me.RadDatePickerEventDate) = True Then
                    TheStartDate = Me.RadDatePickerEventDate.SelectedDate
                Else
                    TheStartDate = Now()
                End If
                Dim TheStartTime As DateTime = Nothing 'Convert.ToDateTime(Me.RadTimePickerStart.SelectedDate)
                Dim TheEndTime As DateTime = Nothing 'Convert.ToDateTime(Me.RadTimePickerEnd.SelectedDate)

            'need to clean up the start and end time here!?
                If Me.RadTimePickerStartTime.SelectedDate = Nothing Or Me.RadTimePickerStartTime.DateInput.Text = "" Then
                    TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
                Else
                    Try
                        TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerStartTime.SelectedDate, DateTime).ToShortTimeString())
                    Catch ex As Exception
                        TheStartTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 12:00:00 AM")
                    End Try
                End If

                If Me.RadTimePickerEndTime.SelectedDate = Nothing Or Me.RadTimePickerEndTime.DateInput.Text = "" Then
                    TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                Else
                    Try
                        Dim s As String = CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString()
                        If s = "12:00 AM" Then
                            TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                        Else
                            TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " " & CType(Me.RadTimePickerEndTime.SelectedDate, DateTime).ToShortTimeString())
                        End If
                    Catch ex As Exception
                        TheEndTime = Convert.ToDateTime(TheStartDate.ToShortDateString() & " 11:59:00 PM")
                    End Try
                End If
                Me.RadTimePickerEndTime.SelectedDate = TheEndTime


                Dim TheHrs As Decimal = 0.0
                If Me.RbHours.Checked = True Then
                    Try
                        If IsNumeric(Me.TxtHours.Text) = True Then
                            TheHrs = CType(Me.TxtHours.Text, Decimal)
                            TheEndTime = DateAdd(DateInterval.Minute, TheHrs * 60, TheStartTime)
                        End If
                    Catch ex As Exception
                        TheHrs = 0.0
                    End Try
                ElseIf Me.RbTime.Checked = True Then
                    Try
                        Dim ts As TimeSpan
                        ts = TheEndTime.Subtract(TheStartTime)
                        TheHrs = CType(ts.TotalMinutes / 60, Decimal)
                    Catch ex As Exception
                        TheHrs = 0.0
                    End Try
                End If
                TheHrs = CType(Math.Round(CType(TheHrs, Double), 2), Decimal)
                evt.EventTasksDatatable_AddRow(Me.DtEventTasks, -1, Me.EventId, "", "", Me.RadDatePickerEventDate.SelectedDate, TheStartTime, TheEndTime, Nothing, TheHrs, "", "", True) 'change the zero
                Me.RadGridEventTasks.Rebind()
            Case "SaveTasks"
                If Me.SaveTasksGrid() = True Then
                    Session("EVENT_TASKS_DT") = Nothing
                    Me.RadGridEventTasks.Rebind()
                End If
            Case "DeleteTasks"
                Dim RowCount As Integer = Me.RadGridEventTasks.MasterTableView.Items.Count
                'delete db records selected
                Dim z As Integer = 0
                If RowCount > 0 Then
                    Dim DoDelete As Boolean = False
                    Dim SbDelete As New System.Text.StringBuilder
                    Dim StrDelete As String = ""
                    SbDelete.Append("DELETE FROM [EVENT_TASK] WITH(ROWLOCK) WHERE EVENT_TASK_ID IN (")
                    Dim chk As CheckBox
                    For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridEventTasks.MasterTableView.Items
                        chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                        Dim ThisEventTaskId As Integer = CType(CType(CurrentGridRow.FindControl("HfEVENT_TASK_ID"), HiddenField).Value, Integer)
                        If chk.Checked = True And ThisEventTaskId > 0 Then
                            DoDelete = True
                            SbDelete.Append(ThisEventTaskId.ToString())
                            SbDelete.Append(",")
                            z += 1
                        End If
                    Next
                    StrDelete = SbDelete.ToString()
                    StrDelete = MiscFN.RemoveTrailingDelimiter(StrDelete, ",")
                    StrDelete &= ");"
                    If z = 0 Then
                        Me.ShowMessage("No rows were selected for deletion")
                    End If
                    If DoDelete = True Then
                        Using MyConn As New SqlConnection(Session("ConnString"))
                            MyConn.Open()
                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(StrDelete, MyConn, MyTrans)
                            Try
                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                    End If
                    Session("EVENT_TASKS_DT") = Nothing
                    Me.RadGridEventTasks.Rebind()
                End If
        End Select
    End Sub

    Private Sub LoadLookups()
        If IsEdit = False Then
            Me.HlFunctionCode.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=evt_gen_fnc&control=" & Me.TxtFunctionCode.ClientID & "&type=evt_gen_fnc');return false;")
        End If
        Me.HlAdNumber.Attributes.Add("onclick", "ClearTB('" & Me.TxtAdNumber.ClientID & "');ClearTB('" & Me.TxtAdNumberDescription.ClientID & "');OpenRadWindow('', 'LookUp_AdNumber.aspx?form=evt_dtl&cli=" & Me.CliCode & "&opener=" & Me.PageFilename() & "');return false;")

    End Sub

    Private Sub LoadEvent()
        If EventId > 0 Then
            Dim DsEvent As New DataSet
            Dim DtHeader As New DataTable
            Dim DtRelatedEvents As New DataTable
            Dim DtTasks As New DataTable

            Dim evt As New cEvents
            DsEvent = evt.EventGetDetails(EventId)
            DtHeader = DsEvent.Tables(0)
            DtRelatedEvents = DsEvent.Tables(1)
            'DtEventTasks = DsEvent.Tables(2)

            'Header info:
            If DtHeader.Rows.Count > 0 Then
                Me.LblEventID.Text = MiscFN.PadJobNum(EventId)

                If IsDBNull(DtHeader.Rows(0)("JOB_AND_COMP")) = False Then
                    Me.LblJobComp.Text = DtHeader.Rows(0)("JOB_AND_COMP")
                End If
                If IsDBNull(DtHeader.Rows(0)("EVENT_LABEL")) = False Then
                    Me.TxtShortDesc.Text = DtHeader.Rows(0)("EVENT_LABEL")
                End If
                If IsDBNull(DtHeader.Rows(0)("EVENT_DESC_LONG")) = False Then
                    Me.TxtLongDesc.Text = DtHeader.Rows(0)("EVENT_DESC_LONG")
                End If
                If IsDBNull(DtHeader.Rows(0)("EVENT_DATE")) = False Then
                    Me.RadDatePickerEventDate.SelectedDate = CType(DtHeader.Rows(0)("EVENT_DATE"), Date)
                End If
                If IsDBNull(DtHeader.Rows(0)("START_TIME")) = False Then
                    Me.RadTimePickerStartTime.SelectedDate = Convert.ToDateTime(DtHeader.Rows(0)("START_TIME"))
                End If
                If IsDBNull(DtHeader.Rows(0)("END_TIME")) = False Then
                    Me.RadTimePickerEndTime.SelectedDate = Convert.ToDateTime(DtHeader.Rows(0)("END_TIME"))
                End If
                If IsDBNull(DtHeader.Rows(0)("QTY_HRS")) = False Then
                    If IsNumeric(DtHeader.Rows(0)("QTY_HRS")) = True Then
                        Me.TxtHours.Text = CType(DtHeader.Rows(0)("QTY_HRS"), Decimal)
                    End If
                End If
                '''If IsDBNull(DtHeader.Rows(0)("RESOURCE_CODE")) = False Then
                '''    'Me.lblr = DtHeader.Rows(0)("RESOURCE_CODE")
                '''End If
                '''If IsDBNull(DtHeader.Rows(0)("")) = False Then
                '''    ' = DtHeader.Rows(0)("")
                '''End If
                '''If IsDBNull(DtHeader.Rows(0)("")) = False Then
                '''    ' = DtHeader.Rows(0)("")
                '''End If
                '''If IsDBNull(DtHeader.Rows(0)("")) = False Then
                '''    ' = DtHeader.Rows(0)("")
                '''End If
                'If IsDBNull(DtHeader.Rows(0)("JOB_NUMBER")) = False And IsDBNull(DtHeader.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                '    Me.LblJobAndComponent.Text = MiscFN.PadJobNum(DtHeader.Rows(0)("JOB_NUMBER")) & "/" & MiscFN.PadJobCompNum(DtHeader.Rows(0)("JOB_COMPONENT_NBR"))
                'End If
                If IsDBNull(DtHeader.Rows(0)("AD_NUMBER")) = False Then
                    Me.TxtAdNumber.Text = DtHeader.Rows(0)("AD_NUMBER")
                End If
                If IsDBNull(DtHeader.Rows(0)("AD_NBR_DESC")) = False Then
                    Me.TxtAdNumberDescription.Text = DtHeader.Rows(0)("AD_NBR_DESC")
                End If
                Try
                    If IsDBNull(DtHeader.Rows(0)("AD_NBR_COLOR")) = False Then
                        'Me.TxtAdNumberDescription.Text = DtHeader.Rows(0)("AD_NBR_COLOR")
                        With Me.TxtAdNumberColor
                            .Visible = True
                            .BackColor = ColorTranslator.FromHtml(DtHeader.Rows(0)("AD_NBR_COLOR").ToString())
                        End With
                    Else
                        Me.TxtAdNumberColor.Visible = False
                    End If
                Catch ex As Exception
                    Me.TxtAdNumberColor.Visible = False
                End Try
                If IsDBNull(DtHeader.Rows(0)("FNC_CODE_DESC")) = False Then
                    Me.LblFunctionCode.Text = DtHeader.Rows(0)("FNC_CODE_DESC")
                End If
                If IsDBNull(DtHeader.Rows(0)("FNC_CODE")) = False Then
                    Me.TxtFunctionCode.Text = DtHeader.Rows(0)("FNC_CODE")
                End If
                If IsDBNull(DtHeader.Rows(0)("FNC_DESCRIPTION")) = False Then
                    Me.TxtFunctionCodeDescription.Text = DtHeader.Rows(0)("FNC_DESCRIPTION")
                End If
                If IsDBNull(DtHeader.Rows(0)("INCOME_ONLY_ID")) = False Then
                    If IsNumeric(DtHeader.Rows(0)("INCOME_ONLY_ID")) = True Then
                        Dim IncID As Integer = CType(DtHeader.Rows(0)("INCOME_ONLY_ID"), Integer)
                        If IncID > 0 Then
                            Me.LblIncomeOnly.Text = "Yes (" & IncID.ToString() & ")"
                        Else
                            Me.LblIncomeOnly.Text = "No"
                        End If
                    Else
                        Me.LblIncomeOnly.Text = "No"
                    End If
                Else
                    Me.LblIncomeOnly.Text = "No"
                End If
                Try
                    If IsDBNull(DtHeader.Rows(0)("RESOURCE_CODE")) = False Then
                        Me.UcResources.ResourceCode = DtHeader.Rows(0)("RESOURCE_CODE")
                        Me.HfResource.Value = DtHeader.Rows(0)("RESOURCE_CODE")
                    Else
                        Me.HfResource.Value = ""
                    End If
                Catch ex As Exception
                End Try
                Me.UcResources.EventId = Me.EventId
                Try
                    If IsDBNull(DtHeader.Rows(0)("QTY_TYPE")) = False Then
                        For i As Integer = 0 To Me.RblQuantityType.Items.Count - 1
                            If Me.RblQuantityType.Items(i).Value = DtHeader.Rows(0)("QTY_TYPE") Then
                                Me.RblQuantityType.Items(i).Selected = True
                            End If
                        Next
                    Else
                        Me.RblQuantityType.Items(1).Selected = True
                    End If
                Catch ex As Exception
                End Try
                If IsDBNull(DtHeader.Rows(0)("EVENT_TYPE_ID")) = False Then
                    Me.UcEventType.EventTypeId = CType(DtHeader.Rows(0)("EVENT_TYPE_ID"), Integer)
                End If
            End If
        End If
    End Sub

    Private Sub SetQSVars()
        Try
            If IsNumeric(Request.QueryString("evt")) = True Then
                EventId = CType(Request.QueryString("evt"), Integer)
                If EventId > 0 Then
                    IsEdit = True
                Else
                    IsEdit = False
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If IsNumeric(Request.QueryString("j")) = True Then
                JobNumber = CType(Request.QueryString("j"), Integer)
            End If
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("jc")) = True Then
                JobComponentNbr = CType(Request.QueryString("jc"), Integer)
            End If
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            CliCode = Request.QueryString("cli").ToString()
        Catch ex As Exception
            CliCode = ""
        End Try
        Try
            If IsNumeric(Request.QueryString("from")) = True Then
                FromPage = CType(Request.QueryString("from"), Integer)
            End If
        Catch ex As Exception
            FromPage = 0
        End Try
        Try
            CutOff = CType(Request.QueryString("cod"), DateTime)
        Catch ex As Exception
            CutOff = Nothing
        End Try
        Try
            If IsNumeric(Request.QueryString("g")) = True Then
                GenId = CType(Request.QueryString("g"), Integer)
            End If
        Catch ex As Exception
            GenId = 0
        End Try

    End Sub

    Private Sub RadGridEventTasks_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEventTasks.ItemDataBound
        Dim Read_Only As Boolean = Me.TasksLocked
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim tb As System.Web.UI.WebControls.TextBox
                Dim rdp As Telerik.Web.UI.RadDatePicker
                Dim hf As System.Web.UI.WebControls.HiddenField
                'format task date:
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerEVENT_TASK_DATE"), Telerik.Web.UI.RadDatePicker)
                    hf = CType(dataItem.FindControl("HfSTART_DATE"), HiddenField)
                    If Not rdp Is Nothing Then
                        rdp.Enabled = Not Read_Only
                        If Not hf Is Nothing Then
                            If cGlobals.wvIsDate(hf.Value) = True Then
                                rdp.SelectedDate = CType(hf.Value, Date)
                            End If
                        End If
                        rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try

                'format temp complete date:
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerTEMP_COMP_DATE"), Telerik.Web.UI.RadDatePicker)
                    hf = CType(dataItem.FindControl("HfTEMP_COMP_DATE"), HiddenField)
                    If Not rdp Is Nothing Then
                        rdp.Enabled = Not Read_Only
                        If Not hf Is Nothing Then
                            If cGlobals.wvIsDate(hf.Value) = True Then
                                rdp.SelectedDate = CType(hf.Value, Date)
                            End If
                        End If
                        rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try


                'task code lookup:
                Try
                    tb = CType(dataItem.FindControl("TxtTASK_CODE"), TextBox)
                    Try
                        If tb.Text.Trim() = "" Then
                            tb.Focus()
                        End If
                    Catch ex As Exception
                    End Try
                    tb.ReadOnly = Read_Only
                    If Read_Only = False Then
                        tb.Attributes.Add("ondblclick", "Javascript:OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & tb.ClientID & "&type=task');return false;")
                    End If
                Catch ex As Exception
                End Try
                Try
                    Dim ib As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("ImgBtnTASK_CODE_LOOKUP"), ImageButton)
                    If Read_Only = False Then
                        ib.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & tb.ClientID & "&type=task');return false;")
                    Else
                        ib.Attributes.Add("onclick", "return false;")
                    End If
                Catch ex As Exception
                End Try

                'emp code lookup:
                Try
                    tb = CType(dataItem.FindControl("TxtEMP_CODE"), TextBox)
                    tb.ReadOnly = Read_Only
                    If Read_Only = False Then
                        tb.Attributes.Add("ondblclick", "Javascript:OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & tb.ClientID & "&type=empcode');return false;")
                    End If
                Catch ex As Exception
                End Try


                '''start time
                ''Try
                ''    If cGlobals.wvIsDate(dataItem.DataItem("START_TIME")) = True Then
                ''        CType(dataItem.FindControl("RadTimePickerStartTime"), Telerik.Web.UI.RadTimePicker).SelectedDate = Convert.ToDateTime(dataItem.DataItem("START_TIME"))
                ''    End If
                ''Catch ex As Exception
                ''End Try
                '''end time
                ''Try
                ''    If cGlobals.wvIsDate(dataItem.DataItem("END_TIME")) = True Then
                ''        CType(dataItem.FindControl("RadTimePickerEndTime"), Telerik.Web.UI.RadTimePicker).SelectedDate = Convert.ToDateTime(dataItem.DataItem("END_TIME"))
                ''    End If
                ''Catch ex As Exception
                ''End Try

                'test
                Try
                    tb = CType(dataItem.FindControl("TxtSTART_TIME"), TextBox)
                    If cGlobals.wvIsDate(tb.Text) = True Then
                        tb.Text = cGlobals.wvCDate(tb.Text).ToShortTimeString()
                    Else
                        tb.Text = ""
                    End If
                Catch ex As Exception
                End Try
                tb.ReadOnly = Read_Only
                Try
                    tb = CType(dataItem.FindControl("TxtEND_TIME"), TextBox)
                    If cGlobals.wvIsDate(tb.Text) = True Then
                        tb.Text = cGlobals.wvCDate(tb.Text).ToShortTimeString()
                    Else
                        tb.Text = ""
                    End If
                Catch ex As Exception
                End Try
                tb.ReadOnly = Read_Only

                Try
                    tb = CType(dataItem.FindControl("TxtHOURS_ALLOWED"), TextBox)
                    tb.ReadOnly = Read_Only
                Catch ex As Exception
                End Try
                Try
                    tb = CType(dataItem.FindControl("TxtCOMMENTS"), TextBox)
                    tb.ReadOnly = Read_Only
                Catch ex As Exception
                End Try
                Try
                    tb = CType(dataItem.FindControl("TxtCOMPLETED_COMMENTS"), TextBox)
                    tb.ReadOnly = Read_Only
                Catch ex As Exception
                End Try

            Catch ex As Exception
                'main try
            End Try
        End If
    End Sub

    Private Function SaveTasksGrid() As Boolean
        Dim GridNoErrors As Boolean = True

        If Me.TasksLocked = True Then
            Return True
            Exit Function
        End If

        Me.LblMSG_Grid.Text = ""
        If EventId = -1 Then
            Me.ShowMessage("Please save the event before adding tasks")
            Exit Function
        End If

        Dim RowCount As Integer = Me.RadGridEventTasks.MasterTableView.Items.Count
        Dim evt As New cEvents()
        If RowCount > 0 Then
            For i As Integer = 0 To RowCount - 1
                Dim RowNoErrors As Boolean = True
                Dim EmpIsBooked As Boolean = False
                Dim CurrGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEventTasks.Items(i), Telerik.Web.UI.GridDataItem)
                Dim CurrEventTaskId As Integer = 0
                Try
                    CurrEventTaskId = CType(CType(CurrGridRow.FindControl("HfEVENT_TASK_ID"), HiddenField).Value, Integer)
                Catch ex As Exception
                    CurrEventTaskId = 0
                End Try

                If CurrEventTaskId <> 0 Then
                    'get data:
                    Dim CurrTaskCode As String = ""
                    Dim CurrEmpCode As String = ""
                    Dim CurrEventTaskDate As DateTime = Nothing
                    Dim CurrEventStartTime As DateTime = Nothing
                    Dim CurrEventEndTime As DateTime = Nothing
                    Dim CurrEventTempCompleteDate As DateTime = Nothing
                    Dim CurrHrsAllowed As Decimal = CType(0, Decimal)
                    Dim CurrComments As String = ""
                    Dim CurrCompletedComments As String = ""
                    Dim TxtBxEmpCode As New System.Web.UI.WebControls.TextBox
                    Try
                        CurrTaskCode = CType(CurrGridRow.FindControl("TxtTASK_CODE"), TextBox).Text.Trim()
                    Catch ex As Exception
                        CurrTaskCode = ""
                    End Try
                    Try
                        If MiscFN.ValidDate(CType(CurrGridRow.FindControl("RadDatePickerEVENT_TASK_DATE"), Telerik.Web.UI.RadDatePicker)) = True Then
                            CurrEventTaskDate = CType(CurrGridRow.FindControl("RadDatePickerEVENT_TASK_DATE"), Telerik.Web.UI.RadDatePicker).SelectedDate
                        Else
                            CurrEventTaskDate = Me.RadDatePickerEventDate.SelectedDate
                        End If
                    Catch ex As Exception
                        CurrEventTaskDate = Nothing
                    End Try

                    'Try
                    '    If CurrEventTaskDate = Nothing Then
                    '        CurrEventTaskDate = cGlobals.wvCDate(Me.TxtEventDate.Text)
                    '    End If
                    'Catch ex As Exception
                    '    CurrEventTaskDate = Nothing
                    'End Try

                    If CurrEventTaskDate = Nothing Then
                        Me.LblMSG_Grid.Text = "Event Date invalid"
                        Return False
                        Exit Function
                    End If

                    Try
                        CurrEventStartTime = evt.FixDate(CurrEventTaskDate.ToShortDateString(), CType(CurrGridRow.FindControl("TxtSTART_TIME"), TextBox).Text)
                    Catch ex As Exception
                        CurrEventStartTime = Nothing
                    End Try
                    Try
                        CurrEventEndTime = evt.FixDate(CurrEventTaskDate.ToShortDateString(), CType(CurrGridRow.FindControl("TxtEND_TIME"), TextBox).Text)
                    Catch ex As Exception
                        CurrEventEndTime = Nothing
                    End Try

                    Try
                        If CurrEventEndTime.ToShortTimeString() = "12:00 AM" Then
                            CurrEventEndTime = Convert.ToDateTime(CurrEventEndTime.ToShortDateString() & " 11:59 PM")
                        End If
                    Catch ex As Exception
                    End Try

                    Dim OldEmpCode As String = ""
                    Try
                        OldEmpCode = CType(CurrGridRow.FindControl("HfEMP_CODE"), HiddenField).Value.Trim()
                    Catch ex As Exception
                        OldEmpCode = ""
                    End Try
                    TxtBxEmpCode = CType(CurrGridRow.FindControl("TxtEMP_CODE"), TextBox)
                    Try
                        CurrEmpCode = TxtBxEmpCode.Text.Trim()
                    Catch ex As Exception
                        CurrEmpCode = ""
                    End Try

                    If CurrEmpCode <> "" And (OldEmpCode <> CurrEmpCode) Then
                        Dim vv As New cValidations(Session("ConnString"))
                        If vv.ValidateEmpCodetd(CurrEmpCode) = False Then
                            Me.LblMSG_Grid.Text = "Employee invalid"
                            TxtBxEmpCode.Focus()
                            Return False
                        End If
                    End If

                    Try
                        If MiscFN.ValidDate(CType(CurrGridRow.FindControl("RadDatePickerTEMP_COMP_DATE"), Telerik.Web.UI.RadDatePicker)) = True Then
                            CurrEventTempCompleteDate = CType(CurrGridRow.FindControl("RadDatePickerTEMP_COMP_DATE"), Telerik.Web.UI.RadDatePicker).SelectedDate
                        End If
                    Catch ex As Exception
                        CurrEventTaskDate = Nothing
                    End Try


                    Try
                        If IsNumeric(CType(CurrGridRow.FindControl("TxtHOURS_ALLOWED"), TextBox).Text.Trim()) = True Then
                            CurrHrsAllowed = CType(CType(CurrGridRow.FindControl("TxtHOURS_ALLOWED"), TextBox).Text.Trim(), Decimal)
                        End If
                    Catch ex As Exception
                        CurrHrsAllowed = CType(0, Decimal)
                    End Try
                    Try
                        CurrComments = CType(CurrGridRow.FindControl("TxtCOMMENTS"), TextBox).Text.Trim()
                    Catch ex As Exception
                        CurrComments = ""
                    End Try
                    Try
                        CurrCompletedComments = CType(CurrGridRow.FindControl("TxtCOMPLETED_COMMENTS"), TextBox).Text.Trim()
                    Catch ex As Exception
                        CurrCompletedComments = ""
                    End Try

                    'validate row data
                    Dim RowIsValid As Boolean = True
                    Dim v As cValidations = New cValidations(CStr(Session("ConnString")))
                    If CurrTaskCode.Trim() = "" Then
                        RowIsValid = False
                    End If
                    If RowIsValid = True Then
                        RowIsValid = v.ValidateTaskCode(CurrTaskCode)
                    End If
                    If RowIsValid = True And CurrEmpCode.Trim() <> "" Then
                        RowIsValid = v.ValidateEmpCode(CurrEmpCode)
                    End If
                    If RowIsValid = True And CurrEventTaskDate = Nothing Then
                        RowIsValid = False
                    End If

                    're-calculate the hours (?)
                    If Me.RbTime.Checked = True Then 'recalc the hours
                        Try
                            Dim ts As TimeSpan
                            ts = CurrEventEndTime.Subtract(CurrEventStartTime)
                            CurrHrsAllowed = CType(ts.TotalHours, Decimal)
                        Catch ex As Exception
                            CurrHrsAllowed = CType(0.0, Decimal)
                        End Try
                    End If
                    If Me.RbHours.Checked = True Then 'recalc the end time
                        CurrEventEndTime = DateAdd(DateInterval.Minute, CurrHrsAllowed * 60, CurrEventStartTime)
                    End If




                    If CurrHrsAllowed <= 0 Then 'end time needs to go to next day:
                        'new req, don't allow
                        Me.ShowMessage("Event tasks cannot cross days")
                        Exit Function
                    End If

                    Try
                        If CurrEventStartTime.ToShortDateString() <> CurrEventEndTime.ToShortDateString() Then
                            Me.ShowMessage("Event tasks cannot cross days")
                            Exit Function
                        End If
                    Catch ex As Exception
                    End Try

                    ''TxtBxEmpCode
                    Dim r As New cResources()
                    EmpIsBooked = r.EmployeeIsBooked(CurrEmpCode, CurrEventTaskId, CurrEventTaskDate, CurrEventStartTime, CurrEventEndTime, )
                    If EmpIsBooked = True Then
                        Me.LblMSG_Grid.Text = "Employee is booked"
                        TxtBxEmpCode.Focus()
                        TxtBxEmpCode.BackColor = Color.Red
                        RowNoErrors = False
                        Return False
                    End If
                    'insert/update
                    If RowIsValid = True And RowNoErrors = True Then
                        If CurrEventTaskId = -1 Then 'new row, insert into database
                            evt.TaskAddNew(Me.EventId, CurrTaskCode, CurrEmpCode, CurrEventTaskDate, CurrEventTaskDate, CurrEventStartTime, CurrEventEndTime, CurrEventTempCompleteDate, CurrHrsAllowed, CurrComments, CurrCompletedComments)
                        ElseIf CurrEventTaskId > 0 Then 'existing row, update
                            evt.TaskUpdate(CurrEventTaskId, Me.EventId, CurrTaskCode, CurrEmpCode, CurrEventTaskDate, CurrEventTaskDate, CurrEventStartTime, CurrEventEndTime, CurrEventTempCompleteDate, CurrHrsAllowed, CurrComments, CurrCompletedComments)
                        End If
                    End If
                End If
            Next
            Return True
        Else
            Return True
        End If
    End Function

    Private Sub SaveTasksDatatable()
        Dim RowCount As Integer = Me.RadGridEventTasks.MasterTableView.Items.Count
        Dim evt As New cEvents()
        If RowCount > 0 Then
            For i As Integer = 0 To RowCount - 1
                Dim CurrGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridEventTasks.Items(i), Telerik.Web.UI.GridDataItem)
                Dim CurrPK As Integer = 0
                Try
                    CurrPK = CType(CurrGridRow.GetDataKeyValue("INDEX"), Integer)
                Catch ex As Exception
                    CurrPK = 0
                End Try
                If CurrPK > 0 Then
                    Dim CurrTaskCode As String = ""
                    Dim CurrEmpCode As String = ""
                    Dim CurrEventTaskDate As DateTime = Nothing
                    Dim CurrEventStartTime As DateTime = Nothing
                    Dim CurrEventEndTime As DateTime = Nothing
                    Dim CurrEventTempCompleteDate As DateTime = Nothing
                    Dim CurrHrsAllowed As Decimal = CType(0, Decimal)
                    Dim CurrComments As String = ""
                    Dim CurrCompletedComments As String = ""
                    Try
                        CurrTaskCode = CType(CurrGridRow.FindControl("TxtTASK_CODE"), TextBox).Text.Trim()
                    Catch ex As Exception
                        CurrTaskCode = ""
                    End Try
                    Try
                        CurrEventTaskDate = cGlobals.wvCDate(CType(CurrGridRow.FindControl("TxtEVENT_TASK_DATE"), TextBox).Text.Trim())
                    Catch ex As Exception
                        CurrEventTaskDate = Nothing
                    End Try
                    Try
                        'CurrEventStartTime = Convert.ToDateTime(ctype(CurrGridRow.FindControl("RadTimePickerStartTime"), TextBox).Text.Trim())
                        'CurrEventStartTime = MiscFN.FixRadTimePickerDate(CType(CurrGridRow.FindControl("TxtEVENT_TASK_DATE"), TextBox), CType(CurrGridRow.FindControl("RadTimePickerStartTime"), Telerik.Web.UI.RadTimePicker))
                        CurrEventStartTime = evt.FixDate(CType(CurrGridRow.FindControl("TxtEVENT_TASK_DATE"), TextBox).Text, CType(CurrGridRow.FindControl("TxtSTART_TIME"), TextBox).Text)
                    Catch ex As Exception
                        CurrEventStartTime = Nothing
                    End Try
                    Try
                        'CurrEventEndTime = Convert.ToDateTime(DirectCast(CurrGridRow.FindControl("RadTimePickerEndTime"), TextBox).Text.Trim())
                        'CurrEventEndTime = MiscFN.FixRadTimePickerDate(CType(CurrGridRow.FindControl("TxtEVENT_TASK_DATE"), TextBox), CType(CurrGridRow.FindControl("RadTimePickerEndTime"), Telerik.Web.UI.RadTimePicker))
                        CurrEventEndTime = evt.FixDate(CType(CurrGridRow.FindControl("TxtEVENT_TASK_DATE"), TextBox).Text, CType(CurrGridRow.FindControl("TxtEND_TIME"), TextBox).Text)
                    Catch ex As Exception
                        CurrEventEndTime = Nothing
                    End Try
                    Try
                        CurrEmpCode = CType(CurrGridRow.FindControl("TxtEMP_CODE"), TextBox).Text.Trim()
                    Catch ex As Exception
                        CurrEmpCode = ""
                    End Try
                    'Try
                    '    CurrEventTempCompleteDate = cGlobals.wvCDate(CType(CurrGridRow.FindControl("TxtEVENT_TASK_DATE"), TextBox).Text.Trim())
                    'Catch ex As Exception
                    '    CurrEventTempCompleteDate = Nothing
                    'End Try
                    Try
                        CurrHrsAllowed = CType(CType(CurrGridRow.FindControl("TxtHOURS_ALLOWED"), TextBox).Text.Trim(), Decimal)
                    Catch ex As Exception
                        CurrHrsAllowed = CType(0, Decimal)
                    End Try
                    Try
                        CurrComments = CType(CurrGridRow.FindControl("TxtCOMMENTS"), TextBox).Text.Trim()
                    Catch ex As Exception
                        CurrComments = ""
                    End Try
                    Try
                        CurrCompletedComments = CType(CurrGridRow.FindControl("TxtCOMPLETED_COMMENTS"), TextBox).Text.Trim()
                    Catch ex As Exception
                        CurrCompletedComments = ""
                    End Try

                    evt.EventTaskDatatable_UpdateRow(Me.DtEventTasks, CurrPK, CurrTaskCode, CurrEmpCode, CurrEventTaskDate, CurrEventStartTime, CurrEventEndTime, CurrEventTempCompleteDate, CurrHrsAllowed, CurrComments, CurrCompletedComments)
                End If
            Next
        End If
    End Sub

    Private Sub RadGridEventTasks_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEventTasks.NeedDataSource
        Try
            Dim dv As New DataView
            dv = Me.DtEventTasks.DefaultView
            dv.Sort = "START_TIME,END_TIME"
            If Me.DtEventTasks.Rows.Count > 0 Then
                Me.RadCalendarShared.Visible = True
            Else
                Me.RadCalendarShared.Visible = False
            End If
            Me.RadGridEventTasks.DataSource = dv
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Event_Detail_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Dim oSec As New cSecurity(Session("ConnString"))
            Me.SetPageAccess(Me.TasksLocked)
        End If
        If Me.LblMSG_Grid.Text = "" Then
            Me.LblMSG_Grid.Visible = False
        Else
            Me.LblMSG_Grid.Visible = True
        End If
    End Sub

    Private Sub SetPageAccess(ByVal allowed As Boolean)
        'the Task Edit - Block Edit Details is a "double negative" so flip the setting
        allowed = Not allowed

        'Dim IsEventTask As Boolean = False
        'Dim IsEvent As Boolean = False
        Dim i As Integer = -1

        Try
            If IsNumeric(Request.QueryString("et")) = True Then
                i = CType(Request.QueryString("et"), Integer)
            End If
        Catch ex As Exception
            i = -1
        End Try

        ''if no access, don't show the back to event button?
        'Me.BtnGoToJob.Visible = allowed

        ''If allowed = False Then
        ''    Select Case i
        ''        Case 0 'clicked an event

        ''        Case 1 'clicked an event task

        ''    End Select
        ''End If

        'hide the tasks grid
        'Me.CollapsablePanelTasks.Visible = allowed
        Me.TrTasksToolbar.Visible = allowed
        'hide the checkbox row
        Me.RadGridEventTasks.MasterTableView.GetColumn("ColumnClientSelect").Display = allowed
        With Me.UcResources
            .EnableForm = allowed
            .CheckDelAutoTasks.Enabled = allowed
            .DropDownListResourceType.Enabled = allowed
            .DropDownListResource.Enabled = allowed
        End With

        'disable resource change


    End Sub

    Private Sub BtnPnlGridSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPnlGridSave.Click
        Me.SaveTasksGrid()
    End Sub

End Class