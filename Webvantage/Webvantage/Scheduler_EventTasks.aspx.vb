Imports System.Data.SqlClient

Public Class Scheduler_EventTasks
    Inherits Webvantage.BaseChildPage

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property



    Protected WithEvents RadDatePickerStartDate As Telerik.Web.UI.RadDatePicker
    Protected WithEvents RadDatePickerEndDate As Telerik.Web.UI.RadDatePicker
    Protected WithEvents RadComboBoxTrafficRoles As Telerik.Web.UI.RadComboBox

    Private StartDate As Date = Nothing
    Private EndDate As Date = Nothing
    Private NavDisplay As String = ""

    Private MaxDays As Integer = 7

    Private Function ValidateDates() As Boolean
        Try
            If Me.RadDatePickerStartDate.SelectedDate.HasValue = False Then
                Me.RadDatePickerStartDate.DateInput.Focus()
                Me.ShowMessage("Invalid Start Date")
                Return False
            End If
        Catch ex As Exception
            Me.RadDatePickerStartDate.DateInput.Focus()
            Me.ShowMessage("Invalid Start Date")
            Return False
        End Try
        Try
            If Me.RadDatePickerEndDate.SelectedDate.HasValue = False Then
                Me.RadDatePickerEndDate.DateInput.Focus()
                Me.ShowMessage("Invalid End Date")
                Return False
            End If
        Catch ex As Exception
            Me.RadDatePickerEndDate.DateInput.Focus()
            Me.ShowMessage("Invalid End Date")
            Return False
        End Try
        Return True
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Events_EventTasksScheduler)

        Me.RadDatePickerStartDate = CType(Me.RadToolbarEventTasksScheduler.Items(2).FindControl("RadDatePickerStartDate"), Telerik.Web.UI.RadDatePicker)
        Me.RadDatePickerEndDate = CType(Me.RadToolbarEventTasksScheduler.Items(4).FindControl("RadDatePickerEndDate"), Telerik.Web.UI.RadDatePicker)
        Me.RadComboBoxTrafficRoles = CType(Me.RadToolbarEventTasksScheduler.Items(7).FindControl("RadComboBoxTrafficRoles"), Telerik.Web.UI.RadComboBox)
        Me.MaxDays = MaxDays - 1

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(Now)
            Me.EndDate = DateAdd(DateInterval.Day, Me.MaxDays, Me.StartDate)
            Me.RadDatePickerStartDate.SelectedDate = Me.StartDate
            Me.RadDatePickerEndDate.SelectedDate = Me.EndDate
        Else
            If MiscFN.StartIsBeforeEnd(cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate), cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)) = False Then
                Me.StartDate = cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)
                Me.EndDate = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate)
            End If
            Me.StartDate = Me.RadDatePickerStartDate.SelectedDate
            Me.EndDate = Me.RadDatePickerEndDate.SelectedDate
            Select Case Me.EventArgument
                Case "RefreshCurrent"
                    Me.HiddenFieldMoveDirection.Value = ""
                    Me.RadGridEventTasksScheduler.Rebind()
            End Select
        End If

    End Sub

    Private Sub RadGridEventTasksScheduler_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEventTasksScheduler.ItemCommand
        Select Case e.CommandName
            Case "PreviousRecord"
                Me.HiddenFieldMoveDirection.Value = "previous"
                Me.RadGridEventTasksScheduler.Rebind()
            Case "NextRecord"
                Me.HiddenFieldMoveDirection.Value = "next"
                Me.RadGridEventTasksScheduler.Rebind()
            Case "ViewEventDetails"
                Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim q As New AdvantageFramework.Web.QueryString()
                With q
                    .Page = "Event_Detail.aspx"
                    .JobNumber = CurrentGridDataItem.GetDataKeyValue("JOB_NUMBER")
                    .JobComponentNumber = CurrentGridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    .EventID = CType(e.CommandArgument, Integer)
                    .Add("from", "3")
                    .Build()
                End With
                Me.OpenWindow("Event Detail", q.ToString(True))
            Case "ViewEventsView"
                Try
                    Dim ar() As String
                    ar = e.CommandArgument.ToString().Split("|")
                    Dim q As New AdvantageFramework.Web.QueryString()
                    With q
                        '.Page = "Event_View.aspx"
                        .ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Events
                        .Page = "Content.aspx"
                        .JobNumber = ar(0)
                        .JobComponentNumber = ar(1)
                        .ClientCode = ar(2)
                        .Add("cli", ar(2))
                        .Add("from", "3")
                        .Build()
                    End With
                    Dim StrTitle As String = "Events for Job/Comp " & ar(0).ToString().PadLeft(6, "0") & "/" & ar(1).ToString.PadLeft(2, "0")
                    Me.OpenWindow("", q.ToString(True))
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private HeaderIsSet As Boolean = False
    Private Sub RadGridEventTasksScheduler_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEventTasksScheduler.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridCommandItem Then
            Dim lb As New System.Web.UI.WebControls.Label
            Try
                If cGlobals.wvIsDate(NavDisplay) = True And HeaderIsSet = False Then
                    NavDisplay = cGlobals.wvCDate(NavDisplay).ToLongDateString()
                    HeaderIsSet = True
                End If
                lb = DirectCast(e.Item.FindControl("LabelCurrentRecordDisplay"), Label)
                lb.Text = NavDisplay
            Catch ex As Exception
                If Not lb Is Nothing Then
                    lb.Text = ex.Message.ToString()
                End If
            End Try
        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridHeaderItem Then
        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim RowEventId As Integer = 0
                Dim RowEventTypeId As Integer = 0
                Try
                    RowEventId = CType(dataItem.GetDataKeyValue("EVENT_ID"), Integer)
                Catch ex As Exception
                    RowEventId = 0
                End Try
                Dim RowEventTaskId As Integer = 0
                Try
                    RowEventTaskId = CType(dataItem.GetDataKeyValue("EVENT_TASK_ID"), Integer)
                Catch ex As Exception
                    RowEventTaskId = 0
                End Try

                Try
                    If Not IsDBNull(dataItem.DataItem("EVENT_TYPE_ID")) Then
                        RowEventTypeId = CType(dataItem.DataItem("EVENT_TYPE_ID"), Integer)
                    End If
                Catch ex As Exception
                End Try
                Try
                    Dim ctrl As System.Web.UI.Control = Page.LoadControl("Event_Type.ascx")
                    Dim RowEventTypeControl As Webvantage.Event_Type = DirectCast(ctrl, Webvantage.Event_Type)
                    RowEventTypeControl = dataItem.FindControl("UcEventType")
                    With RowEventTypeControl
                        .EventId = RowEventId
                        .EventTypeId = RowEventTypeId
                    End With
                Catch ex As Exception
                End Try


                If RowEventTaskId > 0 Then

                    Dim tb As New System.Web.UI.WebControls.TextBox
                    Try
                        tb = DirectCast(dataItem("GridTemplateColumnEventInfo").FindControl("TxtEMP_CODE"), TextBox)
                        If Not tb Is Nothing Then
                            tb.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & tb.ClientID & "&type=empcode');this.focus();return false;")
                            tb.Attributes.Add("onblur", "DataChangeAutoSaveTaskEmployee('" & RowEventTaskId.ToString() & "',this.name,this.value);")
                        End If
                    Catch ex As Exception
                    End Try
                    'Try
                    '    If RowEventId > 0 Then
                    '        tb = DirectCast(dataItem("GridTemplateColumnEventInfo").FindControl("TxtEVENT_DESC_LONG"), TextBox)
                    '        If Not tb Is Nothing Then
                    '            tb.Attributes.Add("onblur", "DataChangeAutoSaveComment('" & RowEventId & "',this.value);")
                    '        End If
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    Try
                        tb = DirectCast(dataItem("GridTemplateColumnEventInfo").FindControl("TxtTaskCOMMENTS"), TextBox)
                        If Not tb Is Nothing Then
                            tb.Attributes.Add("onblur", "DataChangeAutoSaveTaskComment('" & RowEventTaskId & "',this.value);")
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        Dim LBtn As New System.Web.UI.WebControls.LinkButton
                        LBtn = DirectCast(dataItem("GridTemplateColumnEventInfo").FindControl("LinkButtonJob"), LinkButton)
                        LBtn.Text = e.Item.DataItem("JOB_NUMBER").ToString().PadLeft(6, "0") & "/" & e.Item.DataItem("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0") & " - " & e.Item.DataItem("JOB_COMP_DESC")
                        LBtn.CommandArgument = e.Item.DataItem("JOB_NUMBER").ToString() & "|" & e.Item.DataItem("JOB_COMPONENT_NBR").ToString() & "|" & e.Item.DataItem("CL_CODE").ToString()
                    Catch ex As Exception
                    End Try

                End If
            Catch ex As Exception
            End Try

        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridFooterItem Then
        End If


    End Sub

    Private Sub RadGridEventTasksScheduler_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEventTasksScheduler.NeedDataSource
        Me.RadGridEventTasksScheduler.DataSource = Me.SetDatasource()
    End Sub

    Private Function SetDatasource() As DataView
        If Not Me.StartDate = Nothing And Not Me.EndDate = Nothing Then
            Dim evt As New cEvents()
            Dim DsData As New DataSet
            DsData = evt.GetEventTasks(Me.StartDate, Me.EndDate)

            Dim NavString As String = ""
            If DsData.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To DsData.Tables(0).Rows.Count - 1
                    If IsDBNull(DsData.Tables(0).Rows(i)(0)) = False Then
                        If cGlobals.wvIsDate(DsData.Tables(0).Rows(i)(0)) = True Then
                            NavString &= cGlobals.wvCDate(DsData.Tables(0).Rows(i)(0)).ToShortDateString() & ","
                        End If
                    End If
                Next
            End If

            Me.RadComboBoxTrafficRoles.Items.Clear()
            If DsData.Tables(1).Rows.Count > 0 Then
                With Me.RadComboBoxTrafficRoles
                    .DataSource = DsData.Tables(1)
                    .DataTextField = "ROLE_DESC"
                    .DataValueField = "TRF_ROLE_CODES"
                    .DataBind()
                    .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                End With
                Me.RadToolBarButtonRole.Enabled = True
                Me.RadToolbarButtonFindEmployees.Enabled = True
            Else
                Me.RadToolBarButtonRole.Enabled = False
                Me.RadToolbarButtonFindEmployees.Enabled = False
            End If

            Dim dv As New DataView
            dv = DsData.Tables(2).DefaultView

            NavString = MiscFN.CleanStringForSplit(NavString, ",")
            If NavString <> "" Then
                If NavString.IndexOf(",") > -1 Then
                    Dim ar() As String
                    ar = NavString.Split(",")
                    If Me.HiddenFieldCurrentRecord.Value = "" Then 'initialize pager
                        Me.NavDisplay = ar(0).ToString()
                        dv.RowFilter = "NORMALIZED_EVENT_TASK_DATE = '" & CType(ar(0), System.DateTime) & "'"
                        Me.HiddenFieldCurrentRecord.Value = ar(0).ToString()
                    Else
                        Dim CurrentRecordIndex As Integer = 0
                        For i As Integer = 0 To ar.Length - 1
                            If ar(i).ToString() = Me.HiddenFieldCurrentRecord.Value Then
                                CurrentRecordIndex = i
                                Exit For
                            End If
                        Next
                        Dim NextRecordIndex As Integer = 0
                        If Me.HiddenFieldMoveDirection.Value = "next" Then
                            NextRecordIndex = CurrentRecordIndex + 1
                        ElseIf Me.HiddenFieldMoveDirection.Value = "previous" Then
                            NextRecordIndex = CurrentRecordIndex - 1
                        Else
                            NextRecordIndex = CurrentRecordIndex
                        End If
                        If NextRecordIndex < 0 Then
                            NextRecordIndex = ar.Length - 1
                        End If
                        If NextRecordIndex > ar.Length - 1 Then
                            NextRecordIndex = 0
                        End If
                        Me.NavDisplay = ar(NextRecordIndex).ToString()
                        dv.RowFilter = "NORMALIZED_EVENT_TASK_DATE = '" & CType(ar(NextRecordIndex), System.DateTime) & "'"
                        Me.HiddenFieldCurrentRecord.Value = ar(NextRecordIndex).ToString()
                    End If
                Else 'only one record
                    Me.NavDisplay = NavString
                End If
            End If
            Return dv
        End If

    End Function

    Private Sub RadToolbarEventTasksScheduler_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEventTasksScheduler.ButtonClick
        Select Case e.Item.Value
            Case "Refresh"
                Me.Refresh("end")
            Case "FindEmployees"
                Me.FindEmployees()
                Me.HiddenFieldMoveDirection.Value = ""
                Me.RadGridEventTasksScheduler.Rebind()

        End Select
    End Sub

    Private Sub Refresh(ByVal ChangeStartOrEndToFitRange As String)
        If Me.ValidateDates() = False Then
            Exit Sub
        End If
        ChangeStartOrEndToFitRange = ChangeStartOrEndToFitRange.ToLower()

        If MiscFN.StartIsBeforeEnd(cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate), cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)) = False Then
            Me.StartDate = cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)
            Me.EndDate = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate)
        End If

        Me.StartDate = Me.RadDatePickerStartDate.SelectedDate
        Me.EndDate = Me.RadDatePickerEndDate.SelectedDate

        If DateDiff(DateInterval.Day, Me.StartDate, Me.EndDate) > Me.MaxDays Or DateDiff(DateInterval.Day, Me.StartDate, Me.EndDate) < 0 Then
            'Me.ShowMessage("Filter is limited to seven days at a time"))
            'Exit Sub
            Select Case ChangeStartOrEndToFitRange
                Case "start"
                    Me.StartDate = DateAdd(DateInterval.Day, -Me.MaxDays, Me.EndDate)
                    Me.RadDatePickerStartDate.SelectedDate = Me.StartDate
                Case "end"
                    Me.EndDate = DateAdd(DateInterval.Day, Me.MaxDays, Me.StartDate)
                    Me.RadDatePickerEndDate.SelectedDate = Me.EndDate
            End Select
        End If

        Me.HiddenFieldCurrentRecord.Value = ""
        Me.RadGridEventTasksScheduler.Rebind()
    End Sub

    Private Sub FindEmployees()
        If Me.RadComboBoxTrafficRoles.SelectedIndex = 0 Then
            Me.ShowMessage("Please select a Role")
            Exit Sub
        End If
        Dim UseAsStartDate As Date
        Dim UseAsEndDate As Date

        If cGlobals.wvIsDate(Me.HiddenFieldCurrentRecord.Value) = True Then
            UseAsStartDate = cGlobals.wvCDate(Me.HiddenFieldCurrentRecord.Value)
            UseAsEndDate = UseAsStartDate
        Else
            UseAsStartDate = Me.StartDate
            UseAsEndDate = Me.EndDate
        End If
        Dim r As New cResources()
        Dim i As Integer = -1
        Try
            i = r.FindAvailableEmployees(2, Me.RadComboBoxTrafficRoles.SelectedValue, 0, 0, UseAsStartDate, UseAsEndDate, True).Tables(0).Rows(0)(0)
        Catch ex As Exception
            i = -1
        End Try
        If i > -1 Then
            Me.ShowMessage(i.ToString() & " employee(s) found and applied")
        Else
            Me.ShowMessage("Error running Employee Finder")
        End If
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Shared Function AutoSaveTaskEmployee(ByVal RowEventTaskIdString As String, ByVal TextboxEmployeeClientId As String, ByVal EmpCode As String) As String
        Return Webvantage.Scheduler_Events.AutoSaveTaskEmployee(RowEventTaskIdString, TextboxEmployeeClientId, EmpCode)
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function AutoSaveComment(ByVal RowEventIdString As String, ByVal CommentString As String) As String
        Return Webvantage.Scheduler_Events.AutoSaveComment(RowEventIdString, CommentString)
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function AutoSaveTaskComment(ByVal RowEventTaskIdString As String, ByVal CommentString As String) As String
        Return Webvantage.Scheduler_Events.AutoSaveTaskComment(RowEventTaskIdString, CommentString)
    End Function

    Private Sub RadDatePickerStartDate_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged
        Me.Refresh("end")
    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged
        Me.Refresh("start")
    End Sub

End Class