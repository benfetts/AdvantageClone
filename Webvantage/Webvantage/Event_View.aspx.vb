'http://demos.telerik.com/aspnet-ajax/calendar/examples/datetimepicker/sharedtimeviews/defaultcs.aspx
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class Event_View
    Inherits Webvantage.BaseChildPage

    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Private CliCode As String = ""
    Private FromPage As Integer = 0    'FromPage = 1 is the calendar, 2 is Events Scheduler, 3 is the Event Tasks Scheduler
    Private FilterDateCutoff As Date = Nothing
    Private FilterGenId As Integer = 0
    Private FilterAdNbr As String = ""
    Protected WithEvents DropGroupBy As Global.Telerik.Web.UI.RadComboBox
    Private _LoadingDatasource As Boolean = False

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        Me.SetQSVars()

    End Sub

    Private Sub SetQSVars()
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
            If Not Request.QueryString("cli") Is Nothing Then

                CliCode = Request.QueryString("cli").ToString()

            End If
        Catch ex As Exception

            CliCode = ""

        End Try

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNumber = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobComponentNbr = qs.JobComponentNumber
        If qs.ClientCode <> "" Then Me.CliCode = qs.ClientCode

        Try
            If CliCode = "" And JobNumber > 0 Then
                CliCode = SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, "SELECT ISNULL(JOB_LOG.CL_CODE,'') AS CL_CODE FROM JOB_LOG WITH(NOLOCK) WHERE JOB_LOG.JOB_NUMBER = " & JobNumber.ToString() & ";")
            End If
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
        If JobNumber > 0 And JobComponentNbr > 0 Then
            Me.PageTitle = "Events for Job/Comp " & MiscFN.PadJobNum(Me.JobNumber) & "/" & MiscFN.PadJobCompNum(Me.JobComponentNbr)
        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try
                If cGlobals.wvIsDate(Request.QueryString("cod")) = True Then
                    Me.FilterDateCutoff = cGlobals.wvCDate(Request.QueryString("cod"))
                    Me.RadDatePickerDateCutoff.SelectedDate = Me.FilterDateCutoff
                End If
            Catch ex As Exception
                Me.FilterDateCutoff = Nothing
            End Try
            Try
                If IsNumeric(Request.QueryString("g")) = True Then
                    Me.FilterGenId = CType(Request.QueryString("g"), Integer)
                End If
            Catch ex As Exception
                Me.FilterGenId = 0
            End Try
            Try
                If Me.FilterGenId > 0 And Me.DropEventGenerators.Items.Count > 0 Then
                    MiscFN.RadComboBoxSetIndex(Me.DropEventGenerators, Me.FilterGenId.ToString(), False)
                End If
            Catch ex As Exception
            End Try
        Else
            Try
                If MiscFN.ValidDate(Me.RadDatePickerDateCutoff) = True Then
                    Me.FilterDateCutoff = Me.RadDatePickerDateCutoff.SelectedDate
                Else
                    Me.FilterDateCutoff = Nothing
                End If
            Catch ex As Exception
                Me.FilterDateCutoff = Nothing
            End Try
            Try
                If Me.DropEventGenerators.Items.Count > 0 Then
                    If Me.DropEventGenerators.SelectedIndex > 0 Then
                        Me.FilterGenId = CType(Me.DropEventGenerators.SelectedValue, Integer)
                    Else
                        Me.FilterGenId = 0
                    End If
                End If
            Catch ex As Exception
                Me.FilterGenId = 0
            End Try
            Try
                If Me.DropDownListAdNumbers.Items.Count > 0 Then
                    If Me.DropDownListAdNumbers.SelectedIndex > 0 Then
                        Me.FilterAdNbr = Me.DropDownListAdNumbers.SelectedValue
                    End If
                End If
            Catch ex As Exception
                Me.FilterAdNbr = ""
            End Try
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Select Case Me.FromPage
            Case 0
            Case 1
                Me.RadToolbarButtonClose.Text = "Close"
            Case 2, 3
                Me.RadToolbarButtonClose.Text = "Close"
                Me.RadToolbarButtonAddEvent.Enabled = False
                Me.RadToolbarButtonGenerate.Enabled = False
                Me.RadGridEvents.MasterTableView.Columns.FindByUniqueName("ColDetails").Display = False
        End Select

        Session("EVENT_TASKS_DT") = Nothing
        Dim CutOffDate As DateTime = Nothing
        Dim GenId As Integer = 0

        Me.DropGroupBy = CType(Me.RadToolbarJobComponentEvents.Items(18).FindControl("DropGroupBy"), Telerik.Web.UI.RadComboBox)
        If Me.Page.IsPostBack Or Me.Page.IsCallback Then
            Select Case Me.EventArgument
                Case "CloseWindow"
                    Me.CloseAndRefresh()
                Case "Refresh"
                    Me.RadGridEvents.Rebind()
            End Select
        Else 'not a postback/callback
            'MiscFN.RadWindowsClose(Me.RadWindowManagerEvents)
            Try
                Session("SelectedEventsForResource") = Nothing
            Catch ex As Exception
            End Try

            Me.BindDropDownLists()

        End If
    End Sub

    Private Sub BindDropDownLists()
        Dim evt As New cEvents()
        Dim dt As New DataTable
        dt = evt.EventGenGetList(Me.JobNumber, Me.JobComponentNbr)
        With Me.DropEventGenerators
            .Items.Clear()
            Dim itm As New Telerik.Web.UI.RadComboBoxItem
            With itm
                .Text = "[Show all]"
                .Value = "-1"
            End With
            .Items.Insert(0, itm)
            If dt.Rows.Count > 0 Then
                .DataValueField = "EVENT_GEN_ID"
                .DataTextField = "EVENT_GEN_LABEL"
                .DataSource = dt
                .DataBind()
            Else
                .SelectedIndex = 0
                .Enabled = False
            End If
        End With
        dt = Nothing
        dt = evt.GetDistinctAdNumbersByJobComp(Me.JobNumber, Me.JobComponentNbr)
        With Me.DropDownListAdNumbers
            .Items.Clear()
            Dim itm As New Telerik.Web.UI.RadComboBoxItem
            With itm
                .Text = "[Show all]"
                .Value = ""
            End With
            .Items.Insert(0, itm)
            If dt.Rows.Count > 0 Then
                .DataValueField = "AD_NBR"
                .DataTextField = "AD_NBR_DESC"
                .DataSource = dt
                .DataBind()
            Else
                .SelectedIndex = 0
                .Enabled = False
            End If
        End With

    End Sub

    Private Sub SaveEventsGrid(ByVal ShowMessages As Boolean)
        Dim RowCount As Integer = Me.RadGridEvents.MasterTableView.Items.Count
        Dim BookedCounter As Integer = 0
        Dim ArrayListOverbookedRows As New ArrayList()
        Dim NullEventTypeIdSetToDefault As Boolean = False
        Dim RowIsMissingDescription As Boolean = False
        If RowCount > 0 Then
            For i As Integer = 0 To RowCount - 1
                Dim NeedToCheckForOverbooking As Boolean = False
                Dim ThisResourceIsBooked As Boolean = False
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridEvents.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                'CType(CurrentGridRow.FindControl("HfREC_ID"), HiddenField
                Try
                    Dim RowHasChange As Boolean = False

                    Dim RowEventId As Integer = 0
                    Dim RowAdNumber As String = ""
                    Dim RowEventDescription As String = ""
                    Dim RowEventComment As String = ""
                    Dim RowEventDate As DateTime = Nothing
                    Dim sRowEventDate As String = ""
                    Dim RowStartTime As DateTime = Nothing
                    Dim RowEndTime As DateTime = Nothing
                    Dim RowHours As Decimal = CType(0, Decimal)
                    Dim RowResourceCode As String = ""
                    Dim RowIncomeOnlyId As Integer = -1
                    Dim RowEventTypeId As Integer = 0

                    Dim RowAdNumber_Original As String = ""
                    Dim RowEventDescription_Original As String = ""
                    Dim RowEventComment_Original As String = ""
                    Dim RowEventDate_Original As DateTime = Nothing
                    Dim RowStartTime_Original As DateTime = Nothing
                    Dim RowEndTime_Original As DateTime = Nothing
                    Dim RowHours_Original As Decimal = CType(0, Decimal)
                    Dim RowResourceCode_Original As String = ""
                    Dim RowHasResourceChange As Boolean = False
                    Dim RowEventTypeId_Original As Integer = 0

                    Try
                        RowEventId = CType(CurrentGridRow.GetDataKeyValue("EVENT_ID"), Integer)
                    Catch ex As Exception
                        RowEventId = 0
                    End Try

                    If RowEventId > 0 Then
                        Try
                            RowAdNumber = CType(CurrentGridRow.FindControl("TxtAD_NUMBER"), TextBox).Text
                            RowAdNumber_Original = CType(CurrentGridRow.FindControl("HfAD_NUMBER"), HiddenField).Value
                            If RowAdNumber.Trim() <> RowAdNumber_Original.Trim() Then
                                RowHasChange = True
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            RowEventDescription = CType(CurrentGridRow.FindControl("TxtEVENT_LABEL"), TextBox).Text
                            RowEventDescription_Original = CType(CurrentGridRow.FindControl("HfEVENT_LABEL"), HiddenField).Value
                            If (RowEventDescription.Trim() <> RowEventDescription_Original.Trim()) And RowEventDescription.Trim() <> "" Then
                                RowHasChange = True
                            End If
                            If RowEventDescription.Trim() = "" Then
                                'RowHasChange = False
                                'RowIsMissingDescription = True
                                If ShowMessages = True Then
                                    Me.ShowMessage("Event Description is required\nNo rows were saved")
                                    CType(CurrentGridRow.FindControl("TxtEVENT_LABEL"), TextBox).Focus()
                                End If
                                Exit Sub
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            RowEventComment = CType(CurrentGridRow.FindControl("TxtEVENT_DESC_LONG"), TextBox).Text
                            RowEventComment_Original = CType(CurrentGridRow.FindControl("HfEVENT_DESC_LONG"), HiddenField).Value
                            If (RowEventComment.Trim() <> RowEventComment_Original.Trim()) Then
                                RowHasChange = True
                            End If
                        Catch ex As Exception
                        End Try

                        'Make sure there is a valid date
                        RowEventDate_Original = CType(CType(CurrentGridRow.FindControl("HfEVENT_DATE"), HiddenField).Value, DateTime)
                        Try
                            Dim rdp As Telerik.Web.UI.RadDatePicker
                            rdp = CType(CurrentGridRow.FindControl("RadDatePickerEVENT_DATE"), Telerik.Web.UI.RadDatePicker)
                            If Not rdp Is Nothing Then
                                If MiscFN.ValidDate(rdp) = True Then
                                    sRowEventDate = CType(rdp.SelectedDate, Date).ToShortDateString()
                                Else
                                    sRowEventDate = RowEventDate_Original
                                End If
                            End If
                            RowEventDate = cGlobals.wvCDate(sRowEventDate)
                            If RowEventDate.ToShortDateString() <> RowEventDate_Original.ToShortDateString() Then
                                RowHasChange = True
                                NeedToCheckForOverbooking = True
                            End If
                        Catch ex As Exception
                            RowEventDate = RowEventDate_Original
                        End Try



                        RowStartTime_Original = CType(CType(CurrentGridRow.FindControl("HfSTART_TIME"), HiddenField).Value, DateTime)
                        Try
                            Dim BuildStartDateTime As String = RowEventDate.ToShortDateString() & " " & CType(CType(CurrentGridRow.FindControl("RadTimePickerStartTime"), Telerik.Web.UI.RadTimePicker).SelectedDate, DateTime).ToShortTimeString()
                            RowStartTime = Convert.ToDateTime(BuildStartDateTime)
                            If RowStartTime.ToShortTimeString() <> RowStartTime_Original.ToShortTimeString() Then
                                RowHasChange = True
                                NeedToCheckForOverbooking = True
                            End If
                        Catch ex As Exception
                            RowStartTime = RowStartTime_Original
                        End Try


                        RowEndTime_Original = CType(CType(CurrentGridRow.FindControl("HfEND_TIME"), HiddenField).Value, DateTime)
                        Try
                            Dim s As String = CType(CType(CurrentGridRow.FindControl("RadTimePickerEndTime"), Telerik.Web.UI.RadTimePicker).SelectedDate, DateTime).ToShortTimeString()
                            Dim BuildEndDateTime As String = ""
                            If s = "12:00 AM" Then
                                BuildEndDateTime = RowEventDate.ToShortDateString() & " " & " 11:59:00 PM"
                            Else
                                BuildEndDateTime = RowEventDate.ToShortDateString() & " " & s
                            End If
                            RowEndTime = Convert.ToDateTime(BuildEndDateTime)
                            If RowEndTime.ToShortTimeString() <> RowEndTime_Original.ToShortTimeString() Then
                                RowHasChange = True
                                NeedToCheckForOverbooking = True
                            End If
                        Catch ex As Exception
                            RowEndTime = RowEndTime_Original
                        End Try

                        Dim RowHasManualHoursChange As Boolean = False
                        Try
                            RowHours = CType(CType(CurrentGridRow.FindControl("TxtQTY_HRS"), TextBox).Text, Decimal)
                            RowHours_Original = CType(CType(CurrentGridRow.FindControl("HfQTY_HRS"), HiddenField).Value, Decimal)
                            If RowHours <> RowHours_Original Then
                                RowHasChange = True
                                RowHasManualHoursChange = True
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                            RowResourceCode = CType(CurrentGridRow.FindControl("TxtRESOURCE_CODE"), TextBox).Text
                            RowResourceCode_Original = CType(CurrentGridRow.FindControl("HfRESOURCE_CODE"), HiddenField).Value
                            If RowResourceCode.Trim() <> RowResourceCode_Original.Trim() Then
                                RowHasChange = True
                                RowHasResourceChange = True
                                NeedToCheckForOverbooking = True
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                            If IsNumeric(CType(CurrentGridRow.FindControl("HfEVENT_TYPE_ID"), HiddenField).Value) = True Then
                                RowEventTypeId_Original = CType(CType(CurrentGridRow.FindControl("HfEVENT_TYPE_ID"), HiddenField).Value, Integer)
                            End If
                            Dim ctrl As System.Web.UI.Control = Page.LoadControl("Event_Type.ascx")
                            Dim RowUcEventType As Webvantage.Event_Type = DirectCast(ctrl, Webvantage.Event_Type)
                            RowUcEventType = CurrentGridRow.FindControl("UcEventType")
                            RowEventTypeId = RowUcEventType.EventTypeId
                            If RowEventTypeId <> RowEventTypeId_Original Then
                                RowHasChange = True
                            End If
                            If RowEventTypeId = 0 Then
                                RowHasChange = True
                                RowEventTypeId = 1
                                NullEventTypeIdSetToDefault = True
                            ElseIf RowEventTypeId > 0 And RowEventTypeId_Original = 0 Then
                                RowHasChange = True
                            End If
                        Catch ex As Exception
                        End Try

                        If NeedToCheckForOverbooking = True Then
                            Dim rsc As New cResources()
                            If rsc.ResourceIsBooked(RowResourceCode.Trim(), RowEventId, RowEventDate, RowStartTime, RowEndTime) = True Then
                                ThisResourceIsBooked = True
                                RowResourceCode = RowResourceCode_Original.Trim()

                                ArrayListOverbookedRows.Add(RowEventId.ToString())

                                'Changing color has issues since the grid is not refreshed at all....
                                'CType(CurrentGridRow.FindControl("TxtRESOURCE_CODE"), TextBox).BackColor = Drawing.Color.Red
                                BookedCounter += 1
                            End If
                        End If


                        'set correct hours:
                        If RowHasManualHoursChange = False Then 'recalculate hours based on start and end time
                            Try
                                Dim ts As TimeSpan
                                ts = RowEndTime.Subtract(RowStartTime)
                                RowHours = CType(ts.TotalHours, Decimal)
                            Catch ex As Exception
                            End Try
                        Else 'recalculate end time based on hours
                        End If

                        '''Force true to test
                        ''RowHasChange = True

                        If RowHours <= 0 Then
                            'RowHours = RowHours + 24
                            'RowEndTime = DateAdd(DateInterval.Day, 1, RowEndTime)
                            'new req, don't allow
                            'Me.LblMSG.Text = "Events cannot cross days"
                            'Exit Sub
                            RowHasChange = False
                        End If

                        Dim evt As New cEvents
                        If RowHasChange = True And ThisResourceIsBooked = False Then
                            'validate:

                            'get the qty type:
                            Dim QtyType As Integer = 0
                            Try
                                QtyType = CType(CType(CurrentGridRow.FindControl("HfQTY_TYPE"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                QtyType = 1
                            End Try
                            'save the detail:
                            If RowEventTypeId = 0 Then RowEventTypeId = 1

                            evt.EventUpdate(RowEventId, RowEventDescription, RowEventComment, RowEventDate, RowHours, RowStartTime,
                                            RowEndTime, RowResourceCode, RowAdNumber, "", -1, QtyType, RowEventTypeId)
                        End If
                        If RowHasChange = True And RowHasResourceChange = True And ThisResourceIsBooked = False Then ' And RowIsMissingDescription = False Then
                            evt.EventUpdateResource(RowEventId, RowResourceCode, True, True, False)
                        End If
                    End If

                Catch ex As Exception
                    'error saving a row
                End Try
            Next

            If BookedCounter > 0 Then
                Session("OVERBOOKED_ROWS") = ArrayListOverbookedRows
                If ShowMessages = True Then
                    Me.ShowMessage("Overbooked resources were not updated")
                End If
            Else
                Session("OVERBOOKED_ROWS") = Nothing
            End If
            If NullEventTypeIdSetToDefault = True And ShowMessages = True Then
                Me.ShowMessage("Events without an Event Type were defaulted to Fixed")
            End If
            'If RowIsMissingDescription = True Then
            '    Me.ShowMessage("Event Description is required\nRows without an Event Description were not saved")
            'End If
            Me.RadGridEvents.Rebind()

        End If

    End Sub

    Private Function RowHasChange(ByVal TheRow As Telerik.Web.UI.GridDataItem) As Boolean
        Return True
    End Function


    'tooltip:
    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub

    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        'Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Approval_Tooltip.ascx")
        'panel.ContentTemplateContainer.Controls.Add(ctrl)

        'Dim t As BillingApproval_Approval_Tooltip = DirectCast(ctrl, BillingApproval_Approval_Tooltip)
        'With t
        '    .BatchID = ArguementValue
        'End With
    End Sub

    Private Sub RadGridEvents_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEvents.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "EditEvent"
                Me.OpenWindow("", "Event_Detail.aspx?j=" & JobNumber & "&jc=" & JobComponentNbr & "&evt=" & e.CommandArgument.ToString() & "&cli=" & Me.CliCode & "&cod=" & Me.FilterDateCutoff & "&g=" & Me.FilterGenId)
                'MiscFN.ResponseRedirect("Event_Detail.aspx?j=" & JobNumber & "&jc=" & JobComponentNbr & "&evt=" & e.CommandArgument.ToString() & "&cli=" & Me.CliCode & "&cod=" & Me.FilterDateCutoff & "&g=" & Me.FilterGenId)
        End Select
    End Sub

    Private Sub RadGridEvents_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEvents.ItemDataBound
        Me.SetQSVars()
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                'Set GridDataItem
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim Tb As System.Web.UI.WebControls.TextBox
                Dim CurrEvtId As String = dataItem.GetDataKeyValue("EVENT_ID")
                Dim rdp As Telerik.Web.UI.RadDatePicker
                Dim rtp As Telerik.Web.UI.RadTimePicker
                Dim hf As System.Web.UI.WebControls.HiddenField

                'set date textbox
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerEVENT_DATE"), Telerik.Web.UI.RadDatePicker)
                    hf = CType(dataItem.FindControl("HfEVENT_DATE"), HiddenField)
                    If Not rdp Is Nothing Then
                        If Not hf Is Nothing Then
                            If cGlobals.wvIsDate(hf.Value) = True Then
                                rdp.SelectedDate = CType(hf.Value, Date)
                            End If
                        End If
                    End If
                    rdp.SharedCalendar = Me.RadCalendarShared
                Catch ex As Exception
                End Try
                Try
                    rtp = CType(dataItem.FindControl("RadTimePickerStartTime"), Telerik.Web.UI.RadTimePicker)
                    hf = CType(dataItem.FindControl("HfSTART_TIME"), HiddenField)
                    If Not rtp Is Nothing Then
                        If Not hf Is Nothing Then
                            If cGlobals.wvIsDate(hf.Value) = True Then
                                rtp.SelectedDate = CType(hf.Value, Date)
                            End If
                        End If
                    End If
                    rtp.SharedTimeView = Me.RadTimeViewShared
                Catch ex As Exception
                End Try
                Try
                    rtp = CType(dataItem.FindControl("RadTimePickerEndTime"), Telerik.Web.UI.RadTimePicker)
                    hf = CType(dataItem.FindControl("HfEND_TIME"), HiddenField)
                    If Not rtp Is Nothing Then
                        If Not hf Is Nothing Then
                            If cGlobals.wvIsDate(hf.Value) = True Then
                                rtp.SelectedDate = CType(hf.Value, Date)
                            End If
                        End If
                    End If
                    rtp.SharedTimeView = Me.RadTimeViewShared
                Catch ex As Exception
                End Try

                'set resource code textbox
                Try
                    Tb = CType(dataItem.FindControl("TxtRESOURCE_CODE"), TextBox)
                    Tb.Attributes.Add("ondblclick", Me.HookUpOpenWindow("", "Resources.aspx?evt=" & CurrEvtId & "&textbox=" & Tb.ClientID & "&resc=' + document.forms[0]." & Tb.ClientID & ".value"))
                Catch ex As Exception
                End Try

                'set ad number
                Try
                    Tb = CType(dataItem.FindControl("TxtAD_NUMBER"), TextBox)
                    Tb.Attributes.Add("ondblclick", "OpenRadWindow('', 'LookUp_AdNumber.aspx?form=evt_view&ctrl=" & Tb.ClientID & "&cli=" & Me.CliCode & "'); return false;")
                Catch ex As Exception
                End Try

                '''format times:
                ''Try
                ''    Tb = CType(dataItem.FindControl("TxtSTART_TIME"), TextBox)
                ''    If Tb.Text.Trim() <> "" Then
                ''        Tb.Text = Convert.ToDateTime(Tb.Text).ToShortTimeString()
                ''    End If
                ''Catch ex As Exception
                ''End Try
                ''Try
                ''    Tb = CType(dataItem.FindControl("TxtEND_TIME"), TextBox)
                ''    If Tb.Text.Trim() <> "" Then
                ''        Tb.Text = Convert.ToDateTime(Tb.Text).ToShortTimeString()
                ''    End If
                ''Catch ex As Exception
                ''End Try
                Try
                    If Not Session("OVERBOOKED_ROWS") Is Nothing Then
                        Dim ArrayListOverbookedEventIds As New ArrayList()
                        ArrayListOverbookedEventIds = CType(Session("OVERBOOKED_ROWS"), ArrayList)
                        ArrayListOverbookedEventIds.Sort()
                        If ArrayListOverbookedEventIds.BinarySearch(CurrEvtId.ToString()) > -1 Then
                            'CType(dataItem.FindControl("TxtRESOURCE_CODE"), TextBox).BackColor = Drawing.Color.Red
                            dataItem("ColumnClientSelect").BackColor = Drawing.Color.Red
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    Dim ctrl As System.Web.UI.Control = Page.LoadControl("Event_Type.ascx")
                    Dim RowUcEventType As Webvantage.Event_Type = DirectCast(ctrl, Webvantage.Event_Type)
                    RowUcEventType = dataItem.FindControl("UcEventType")
                    Dim ThisEventTypeId As Integer = 0
                    Try
                        If IsNumeric(CType(dataItem.FindControl("HfEVENT_TYPE_ID"), HiddenField).Value) = True Then
                            ThisEventTypeId = CType(CType(dataItem.FindControl("HfEVENT_TYPE_ID"), HiddenField).Value, Integer)
                        End If

                    Catch ex As Exception
                        ThisEventTypeId = 0
                    End Try
                    RowUcEventType.EventTypeId = ThisEventTypeId
                Catch ex As Exception
                End Try

            Catch ex As Exception
                'all encompassing try/catch
            End Try
        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridGroupHeaderItem Then
            Select Case Me.DropGroupBy.SelectedValue
                Case "fnc"
                    e.Item.Cells(1).Text = "Function Code" & e.Item.Cells(1).Text.Replace("Function-Code", "")
                Case "ad"
                    e.Item.Cells(1).Text = "Ad Number" & e.Item.Cells(1).Text.Replace("Ad-Number", "")
                Case "resc"
                    e.Item.Cells(1).Text = "Resource Code" & e.Item.Cells(1).Text.Replace("Resource-Code", "")
            End Select
        End If
    End Sub

    Private Sub RadGridEvents_ItemDeleted(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDeletedEventArgs) Handles RadGridEvents.ItemDeleted

    End Sub

    Private Sub RadGridEvents_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEvents.NeedDataSource

        _LoadingDatasource = True

        Dim evt As New cEvents()
        Dim dt As DataTable = evt.EventGetDetails(Me.JobNumber, Me.JobComponentNbr, Me.FilterDateCutoff, Me.FilterGenId, Me.FilterAdNbr)
        Me.RadGridEvents.DataSource = dt
        If dt.Rows.Count > 0 Then
            Me.RadCalendarShared.Visible = True
        Else
            Me.RadCalendarShared.Visible = False
        End If
        Me.RadGridEvents.PageSize = MiscFN.LoadPageSize(Me.RadGridEvents.ID)

        Me.VerifyCliCode()

        _LoadingDatasource = False

    End Sub

    Private Sub VerifyCliCode()
        If CliCode = "" And JobNumber > 0 Then
            Try
                Using MyConn As New SqlConnection(Session("ConnString"))
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand("SELECT CL_CODE FROM JOB_LOG WITH(NOLOCK) WHERE JOB_NUMBER = " & Me.JobNumber.ToString() & ";", MyConn, MyTrans)
                    Try
                        Me.CliCode = MyCmd.ExecuteScalar()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using

            Catch ex As Exception
                Me.CliCode = ""
            End Try
        Else
            Me.CliCode = ""
        End If
    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("")
    End Sub

    Private Sub DropGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropGroupBy.SelectedIndexChanged
        Me.SetGrouping()
    End Sub

    Private Sub SetGrouping()
        Try
            Select Case Me.DropGroupBy.SelectedIndex
                Case 0
                    Me.RadGridEvents.MasterTableView.GroupByExpressions.Clear()
                Case 1 'function code
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("FNC_CODE Function-Code Group By FNC_CODE")
                    With Me.RadGridEvents
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case 2 'ad number
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("AD_NUMBER Ad-Number Group By AD_NUMBER")
                    With Me.RadGridEvents
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case 3 'date
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("EVENT_DATE_NO_TIME Date Group By EVENT_DATE")
                    With Me.RadGridEvents
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case 4 'day
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("FULL_DAY_OF_WEEK Day Group By FULL_DAY_OF_WEEK")
                    With Me.RadGridEvents
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case 5 'resource code
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("RESOURCE_CODE Resource-Code Group By RESOURCE_CODE")
                    With Me.RadGridEvents
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
            End Select
            Me.RadGridEvents.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Event_View_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim i As Integer = -1
        Try
            i = Me.RadGridEvents.MasterTableView.Items.Count
        Catch ex As Exception
            i = -1
        End Try
        If i = 0 Then
            Me.RadToolbarButtonDelete.Enabled = False
            Me.RadToolbarButtonFindResources.Enabled = False
            Me.RadToolbarButtonClearResources.Enabled = False
            Me.RadToolbarButtonFindEmps.Enabled = False
            Me.RadToolbarButtonBillEvents.Enabled = False
            Me.RadToolbarButtonPrint.Enabled = False
            Me.DropGroupBy.Enabled = False
        ElseIf i > 0 Then
            Me.RadToolbarButtonDelete.Enabled = True
            Me.RadToolbarButtonFindResources.Enabled = True
            Me.RadToolbarButtonClearResources.Enabled = True
            Me.RadToolbarButtonFindEmps.Enabled = True
            'Me.RadToolbarButtonBillEvents.Enabled = True
            Me.RadToolbarButtonPrint.Enabled = True
            Me.DropGroupBy.Enabled = True
        End If
    End Sub

    Private Sub RadGridEvents_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridEvents.PageIndexChanged
        Me.SaveEventsGrid(False)
    End Sub

    Private Sub BtnApplyFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnApplyFilter.Click
        If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, True) = False Then
            Me.ShowMessage("Invalid Date Cutoff")
            Exit Sub
        Else
            Me.FilterDateCutoff = Me.RadDatePickerDateCutoff.SelectedDate
        End If
        Try
            If Me.DropEventGenerators.SelectedIndex > 0 Then
                Me.FilterGenId = Me.DropEventGenerators.SelectedValue
            End If
        Catch ex As Exception
            Me.FilterGenId = 0
        End Try
        Try
            If Me.DropDownListAdNumbers.SelectedIndex > 0 Then
                Me.FilterAdNbr = Me.DropDownListAdNumbers.SelectedValue
            End If
        Catch ex As Exception
            Me.FilterAdNbr = ""
        End Try
        Me.RadGridEvents.Rebind()
    End Sub

    Private Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Me.RadDatePickerDateCutoff.SelectedDate = Nothing
        Me.RadDatePickerDateCutoff.DateInput.Text = ""
        If Me.DropEventGenerators.Items.Count > 0 Then
            Me.DropEventGenerators.SelectedIndex = 0
        End If
        Me.RadGridEvents.Rebind()
    End Sub

    Private Sub RadToolbarJobComponentEvents_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobComponentEvents.ButtonClick
        Select Case e.Item.Value
            Case "Refresh"

                Me.RadGridEvents.Rebind()

            Case "AddEvent"
                Me.SaveEventsGrid(True)
                'MiscFN.ResponseRedirect("Event_Detail.aspx?j=" & JobNumber & "&jc=" & JobComponentNbr & "&evt=-1" & "&cod=" & Me.FilterDateCutoff & "&g=" & Me.FilterGenId)
                Me.OpenWindow("", "Event_Detail.aspx?j=" & JobNumber & "&jc=" & JobComponentNbr & "&evt=-1" & "&cod=" & Me.FilterDateCutoff & "&g=" & Me.FilterGenId & "&cli=" & Me.CliCode)
            Case "GenerateEvent"
                Me.SaveEventsGrid(True)
                Dim StrURL1 As String = ""
                StrURL1 = "Event_Generator.aspx?f=1&e=0&ec=0&eq=0&er=0&j=" & JobNumber & "&jc=" & JobComponentNbr
                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerEvents, "WinEventGenerator", "Generate Event(s)", StrURL1, 650, 650, False)
                Me.OpenWindow("", StrURL1, 650, 650, False, True)
            Case "SaveEvents"
                Me.SaveEventsGrid(True)
                Me.RadGridEvents.Rebind()
                Me.BindDropDownLists()
            Case "DeleteEvents"
                Dim RowCount As Integer = Me.RadGridEvents.MasterTableView.Items.Count
                Dim z As Integer = 0
                If RowCount > 0 Then
                    Dim SbTasks As New System.Text.StringBuilder
                    Dim StrTasks As String = ""
                    SbTasks.Append("DELETE FROM [EVENT_TASK] WITH(ROWLOCK) WHERE EVENT_ID IN (")
                    Dim SbDelete As New System.Text.StringBuilder
                    Dim StrDelete As String = ""
                    SbDelete.Append("DELETE FROM [EVENT] WITH(ROWLOCK) WHERE EVENT_ID IN (")
                    Dim chk As CheckBox
                    Dim DoDelete As Boolean = False
                    For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridEvents.MasterTableView.Items
                        chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            z += 1
                            If IsNumeric(CurrentGridRow.GetDataKeyValue("EVENT_ID")) Then
                                SbTasks.Append(CType(CurrentGridRow.GetDataKeyValue("EVENT_ID"), Integer).ToString())
                                SbTasks.Append(",")
                                SbDelete.Append(CType(CurrentGridRow.GetDataKeyValue("EVENT_ID"), Integer).ToString())
                                SbDelete.Append(",")
                                DoDelete = True
                            End If
                        End If
                    Next
                    StrTasks = SbTasks.ToString()
                    StrTasks = MiscFN.RemoveTrailingDelimiter(StrTasks, ",")
                    StrTasks &= ");"

                    StrDelete = SbDelete.ToString()
                    StrDelete = MiscFN.RemoveTrailingDelimiter(StrDelete, ",")
                    StrDelete &= ");"

                    If z = 0 Then
                        Me.ShowMessage("No rows were selected for deletion")
                        Exit Sub
                    End If
                    If DoDelete = True Then
                        Using MyConn As New SqlConnection(Session("ConnString"))
                            MyConn.Open()
                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(StrTasks & StrDelete, MyConn, MyTrans)
                            Try
                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                        Me.RadGridEvents.Rebind()
                    End If
                End If
            Case "FindResources"
                Me.SaveEventsGrid(True)
                Dim RecCount As Integer = 0
                Dim ds As New DataSet
                Dim i As Integer = 0
                Dim SbSelected As New System.Text.StringBuilder
                Dim StrSelected As String = ""
                Dim evt As New cEvents()
                Dim MinDate As DateTime
                Dim MaxDate As DateTime

                ds = evt.EventGetEventsThatNeedResources(Me.JobNumber, Me.JobComponentNbr, Me.FilterDateCutoff, Me.FilterGenId)
                Try
                    If Not ds.Tables(0) Is Nothing Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            If IsDBNull(ds.Tables(0).Rows(0)("MIN_EVENT_DATE")) = False Then
                                MinDate = CType(ds.Tables(0).Rows(0)("MIN_EVENT_DATE"), DateTime)
                            End If
                            If IsDBNull(ds.Tables(0).Rows(0)("MAX_EVENT_DATE")) = False Then
                                MaxDate = CType(ds.Tables(0).Rows(0)("MAX_EVENT_DATE"), DateTime)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Error getting events date range.")
                    Exit Sub
                End Try
                Try
                    If Not ds.Tables(1) Is Nothing Then
                        i = ds.Tables(1).Rows.Count
                    End If
                Catch ex As Exception
                    i = 0
                End Try
                If i > 0 Then
                    For j As Integer = 0 To i - 1
                        With SbSelected
                            .Append(ds.Tables(1).Rows(j)("EVENT_ID"))
                            .Append(",")
                        End With
                    Next
                    StrSelected = SbSelected.ToString()
                    StrSelected = MiscFN.RemoveTrailingDelimiter(StrSelected, ",")
                    Session("SelectedEventsForResource") = StrSelected
                    Dim StrURL1 As String = ""
                    StrURL1 = "Resources_Find.aspx?min=" & MinDate.ToShortDateString() & "&max=" & MaxDate.ToShortDateString()
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerEvents, "WinResourceFinder", "Resource Finder", StrURL1, 640, 675, False)
                    Me.OpenWindow("", StrURL1, 640, 675, False, True)
                Else
                    Me.ShowMessage("No events need the Resource Finder.")
                End If

            Case "ClearResources"
                Dim RowCount As Integer = Me.RadGridEvents.MasterTableView.Items.Count
                If RowCount > 0 Then
                    For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridEvents.MasterTableView.Items
                        CType(CurrentGridRow.FindControl("TxtRESOURCE_CODE"), TextBox).Text = ""
                    Next
                End If
            Case "Print"
                Dim str As String = "<script language=""javascript"" type=""text/javascript"">window.open('Event_QuickPrint.aspx?j=" & Me.JobNumber & "&jc=" & Me.JobComponentNbr & "&cod=" & Me.FilterDateCutoff & "&g=" & Me.FilterGenId & " &adnbr=" & Me.FilterAdNbr & "', 'PopEvtQuickPrint','screenX=150,left=150,screenY=150,top=150,width=900,height=800,scrollbars=yes,resizable=no,menubar=no,maximazable=no');</script>"
                'Dim str1 As String = "window.open('Event_QuickPrint.aspx?j=" & Me.JobNumber & "&jc=" & Me.JobComponentNbr & "&cod=" & Me.FilterDateCutoff & "&g=" & Me.FilterGenId & "', 'PopEvtQuickPrint','screenX=150,left=150,screenY=150,top=150,width=900,height=800,scrollbars=yes,resizable=no,menubar=no,maximazable=no');"
                If Not Page.IsStartupScriptRegistered("EvtQuickPrint") Then
                    Page.RegisterStartupScript("EvtQuickPrint", str)
                End If
            Case "FindEmps"
                'MiscFN.ResponseRedirect("Resources_Emps_Find.aspx?from=0&j=" & JobNumber & "&jc=" & JobComponentNbr & "&cli=" & CliCode)
                Me.OpenWindow("", "Resources_Emps_Find.aspx?from=0&j=" & JobNumber & "&jc=" & JobComponentNbr & "&cli=" & CliCode)
            Case "CloseWindow"
                Me.CloseAndRefresh()

        End Select

    End Sub

    Private Sub RadGridEvents_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridEvents.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridEvents.ID, e.NewPageSize)

        End If

    End Sub
End Class
