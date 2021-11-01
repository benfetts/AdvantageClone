Imports System.Data.SqlClient

Public Class Scheduler_Events
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

    Private StartDate As Date = Nothing
    Private EndDate As Date = Nothing

    Private Sub Event_Scheduler_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Events Scheduler"
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Events_EventsScheduler)
        Me.RadDatePickerStartDate = CType(Me.RadToolbarEventScheduler.Items(1).FindControl("RadDatePickerStartDate"), Telerik.Web.UI.RadDatePicker)
        Me.RadDatePickerEndDate = CType(Me.RadToolbarEventScheduler.Items(2).FindControl("RadDatePickerEndDate"), Telerik.Web.UI.RadDatePicker)

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(Now)
            Me.EndDate = DateAdd(DateInterval.Day, 6, Me.StartDate)
            Me.RadDatePickerStartDate.SelectedDate = Me.StartDate
            Me.RadDatePickerEndDate.SelectedDate = Me.EndDate
            Me.LoadLookups()
        Else
            If Me.RadDatePickerStartDate.SelectedDate.HasValue = False Then
                Me.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(Now)
                Me.RadDatePickerStartDate.SelectedDate = Me.StartDate
            Else
                Me.StartDate = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate)
            End If

            If Me.RadDatePickerEndDate.SelectedDate.HasValue = False Then
                Me.EndDate = DateAdd(DateInterval.Day, 6, Me.StartDate)
                Me.RadDatePickerEndDate.SelectedDate = Me.EndDate
            Else
                Me.EndDate = cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)
            End If

            If MiscFN.StartIsBeforeEnd(cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate), cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)) = False Then
                Me.StartDate = cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)
                Me.EndDate = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate)
                Me.RadDatePickerStartDate.SelectedDate = Me.StartDate
                Me.RadDatePickerEndDate.SelectedDate = Me.EndDate
            End If
        End If
        Me.CollapsablePanelResourceFinder.Visible = Me.RadToolBarButtonViewByJobComponent.Checked

    End Sub

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
    End Function

    Private Sub RadToolbarEventScheduler_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEventScheduler.ButtonClick
        Select Case e.Item.Value
            Case "Refresh"
                Me.Refresh()
            Case "UpdateResources"
                Me.UpdateResources()
                Me.HiddenFieldMoveDirection.Value = ""
                Me.RadGridEventScheduler.Rebind()
            Case "ViewByJobComponent", "ViewbyDate"
                Try
                    Session("SCHEDULER_EVENTS_GRID_ROW_INDEX") = Nothing
                Catch ex As Exception
                End Try
                Me.HiddenFieldCurrentRecord.Value = ""
                Me.RadGridEventScheduler.Rebind()
        End Select
    End Sub

    Private Sub Refresh()
        Try
            Session("SCHEDULER_EVENTS_GRID_ROW_INDEX") = Nothing
        Catch ex As Exception
        End Try

        Me.LoadAdNumberFilter()
        Me.LoadGeneratorFilter()
        Me.LoadResourceTypesFinder()

        Me.HiddenFieldCurrentRecord.Value = ""
        Me.HiddenFieldMoveDirection.Value = ""
        Me.RadGridEventScheduler.Rebind()
    End Sub

    Private Sub RadGridEventScheduler_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridEventScheduler.DataBound
        Try
            If Not Session("SCHEDULER_EVENTS_GRID_ROW_INDEX") = Nothing Then
                If IsNumeric(Session("SCHEDULER_EVENTS_GRID_ROW_INDEX")) = True Then
                    RadGridEventScheduler.Items(CType(Session("SCHEDULER_EVENTS_GRID_ROW_INDEX"), Integer)).Expanded = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridEventScheduler_DetailTableDataBind(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridEventScheduler.DetailTableDataBind
        Try

            Dim parentItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)
            If Not parentItem.Edit Then
                Dim ParentEventId As Integer = 0
                Try
                    ParentEventId = CType(parentItem.GetDataKeyValue("EVENT_ID"), Integer)
                Catch ex As Exception
                    ParentEventId = 0
                End Try
                If ParentEventId > 0 Then
                    If e.DetailTableView.Name = "EventTasks" Then
                        Dim evt As New cEvents
                        Dim dv As New DataView
                        dv = evt.EventTasksDatatable(ParentEventId).DefaultView
                        dv.Sort = "START_TIME,END_TIME"
                        e.DetailTableView.DataSource = dv
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEventScheduler_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEventScheduler.ItemCommand
        Session("SCHEDULER_EVENTS_GRID_ROW_INDEX") = Nothing
        Select Case e.CommandName
            Case Telerik.Web.UI.RadGrid.ExpandCollapseCommandName
                If e.Item.Expanded = True Then
                    Session("SCHEDULER_EVENTS_GRID_ROW_INDEX") = e.Item.ItemIndex
                End If
            Case "PreviousRecord"
                Me.HiddenFieldMoveDirection.Value = "previous"
                Me.RadGridEventScheduler.Rebind()
            Case "NextRecord"
                Me.HiddenFieldMoveDirection.Value = "next"
                Me.RadGridEventScheduler.Rebind()
            Case "RefreshTaskGrid"
                Session("SCHEDULER_EVENTS_GRID_ROW_INDEX") = e.Item.ItemIndex
                Me.HiddenFieldMoveDirection.Value = ""
                Me.RadGridEventScheduler.Rebind()
        End Select
    End Sub

    Private NavDisplay As String = ""

    Private Sub RadGridEventScheduler_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEventScheduler.NeedDataSource

        Me.RadGridEventScheduler.DataSource = Me.SetDatasource()
        Me.RadGridEventScheduler.MasterTableView.GetColumn("GridTemplateColumnThumbNail").Visible = Me.CheckBoxShowAdNumberImage.Checked

    End Sub

    Private Function SetDatasource() As DataTable
        If Not StartDate = Nothing And Not EndDate = Nothing Then
            Me.SetGrouping()

            Dim NavString As String = ""

            Dim evt As New cEvents()
            Dim dt As New DataTable
            Dim dv As New DataView
            Dim ReturnType As String = "jc"
            If Me.RadToolBarButtonViewByJobComponent.Checked = True Then
                ReturnType = "jc"
            ElseIf Me.RadToolBarButtonViewbyDate.Checked = True Then
                ReturnType = "date"
            End If
            dt = evt.EventGetDetails(Me.StartDate.ToShortDateString(), Me.EndDate.ToShortDateString(), ReturnType, Me.CheckBoxOnlyEventsWithoutResource.Checked, Me.DropDownListEventGenerators.SelectedValue, Me.DropDownListAdNumbersFilter.SelectedValue, NavString)
            dv = dt.DefaultView

            If NavString <> "" Then

                If Me.HiddenFieldCurrentRecord.Value = "" Then 'initialize
                    Dim ar() As String
                    If NavString.IndexOf(",") > -1 Then 'more than one
                        ar = NavString.Split(",")
                        If Me.RadToolBarButtonViewByJobComponent.Checked = True Then
                            Dim ArJobComp() As String
                            ArJobComp = ar(0).Split("|")
                            Me.NavDisplay = ArJobComp(0).ToString().PadLeft(6, "0") & "/" & ArJobComp(1).ToString().PadLeft(2, "0")
                            dv.RowFilter = "JOB_NUMBER = " & ArJobComp(0) & " AND JOB_COMPONENT_NBR = " & ArJobComp(1)
                        ElseIf Me.RadToolBarButtonViewbyDate.Checked = True Then
                            Me.NavDisplay = ar(0).ToString()
                            dv.RowFilter = "EVENT_DATE = '" & CType(ar(0), System.DateTime) & "'"
                        End If
                        Me.HiddenFieldCurrentRecord.Value = ar(0).ToString()

                    Else 'only one record
                        If Me.RadToolBarButtonViewByJobComponent.Checked = True Then
                            ar = NavString.Split("|")
                            Me.NavDisplay = ar(0).ToString().PadLeft(6, "0") & "/" & ar(1).ToString().PadLeft(2, "0")
                        ElseIf Me.RadToolBarButtonViewbyDate.Checked = True Then
                            Me.NavDisplay = NavString
                        End If
                        Me.HiddenFieldCurrentRecord.Value = NavString
                        '''Me.ButtonNext.Visible = False
                        '''Me.ButtonPrevious.Visible = False
                    End If
                Else
                    Dim ArRecords() As String
                    ArRecords = NavString.Split(",")
                    Dim CurrentRecordIndex As Integer = 0
                    For i As Integer = 0 To ArRecords.Length - 1
                        If ArRecords(i).ToString() = Me.HiddenFieldCurrentRecord.Value Then
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
                        NextRecordIndex = ArRecords.Length - 1
                    End If
                    If NextRecordIndex > ArRecords.Length - 1 Then
                        NextRecordIndex = 0
                    End If

                    If Me.RadToolBarButtonViewByJobComponent.Checked = True Then
                        Dim ArJobComp() As String
                        ArJobComp = ArRecords(NextRecordIndex).Split("|")
                        Me.NavDisplay = ArJobComp(0).ToString().PadLeft(6, "0") & "/" & ArJobComp(1).ToString().PadLeft(2, "0")
                        dv.RowFilter = "JOB_NUMBER = " & ArJobComp(0) & " AND JOB_COMPONENT_NBR = " & ArJobComp(1)
                    ElseIf Me.RadToolBarButtonViewbyDate.Checked = True Then
                        Me.NavDisplay = ArRecords(NextRecordIndex).ToString()
                        dv.RowFilter = "EVENT_DATE = '" & CType(ArRecords(NextRecordIndex), System.DateTime) & "'"
                    End If
                    Me.HiddenFieldCurrentRecord.Value = ArRecords(NextRecordIndex).ToString()

                End If

            End If
            Return dv.ToTable()
        End If

    End Function

    Private HeaderIsSet As Boolean = False
    Private Sub RadGridEventScheduler_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEventScheduler.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridCommandItem Then
            Dim lb As New System.Web.UI.WebControls.Label
            Try
                If Me.RadToolBarButtonViewByJobComponent.Checked = True Then
                    NavDisplay = NavDisplay
                ElseIf Me.RadToolBarButtonViewbyDate.Checked = True Then
                    If cGlobals.wvIsDate(NavDisplay) = True And HeaderIsSet = False Then
                        NavDisplay = cGlobals.wvCDate(NavDisplay).ToLongDateString()
                        HeaderIsSet = True
                    End If
                End If
                lb = DirectCast(e.Item.FindControl("LabelCurrentRecordDisplay"), Label)
                lb.Text = NavDisplay
            Catch ex As Exception
                If Not lb Is Nothing Then
                    lb.Text = ex.Message.ToString()
                End If
            End Try
        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridHeaderItem Then
            ''Try
            ''    Select Case Me.DropDownListShowBy.SelectedValue
            ''        Case "fnc"
            ''            e.Item.Cells(1).Text = "Function Code" & e.Item.Cells(1).Text.Replace("Function-Code", "")
            ''        Case "ad"
            ''            e.Item.Cells(1).Text = "Ad Number" & e.Item.Cells(1).Text.Replace("Ad-Number", "")
            ''        Case "resc"
            ''            e.Item.Cells(1).Text = "Resource Code" & e.Item.Cells(1).Text.Replace("Resource-Code", "")
            ''        Case "jc"
            ''            e.Item.Cells(1).Text = "Job/Component" & e.Item.Cells(1).Text.Replace("Job-Component", "")
            ''    End Select
            ''Catch ex As Exception
            ''End Try

        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim RowEventId As Integer = 0
                Dim RowEventTypeId As Integer = 0
                RowEventId = dataItem.GetDataKeyValue("EVENT_ID")
                Dim RowResourceCode As String = ""

                Try
                    If Not IsDBNull(dataItem.DataItem("RESOURCE_CODE")) Then
                        RowResourceCode = dataItem.DataItem("RESOURCE_CODE")
                    End If
                Catch ex As Exception
                End Try

                Try
                    Dim ctrl As System.Web.UI.Control = Page.LoadControl("Resources.ascx")
                    Dim RowResourceControl As Webvantage.ResourcesUC = DirectCast(ctrl, Webvantage.ResourcesUC)
                    RowResourceControl = dataItem.FindControl("UcResources")
                    With RowResourceControl
                        .EventId = RowEventId
                        .ResourceCode = RowResourceCode
                        .Rebind = True
                    End With
                    AddHandler RowResourceControl.DropResourcesSelectedIndexChanged, AddressOf UcResources_DropResourcesSelectedIndexChanged
                Catch ex As Exception
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


                Try
                    If Me.CheckBoxShowAdNumberImage.Checked = True Then
                        Dim DocId As Integer = 0
                        Try
                            If IsNumeric(CType(dataItem.FindControl("HfDocumentId"), HiddenField).Value) = True Then
                                DocId = CType(CType(dataItem.FindControl("HfDocumentId"), HiddenField).Value, Integer)
                            End If
                        Catch ex As Exception
                            DocId = 0
                        End Try
                        Dim AdNumberThumbnail As System.Web.UI.WebControls.Image
                        If DocId > 0 Then
                            AdNumberThumbnail = CType(dataItem.FindControl("ImageThumbnail"), System.Web.UI.WebControls.Image)
                            AdNumberThumbnail.ImageUrl = "Thumbnail.aspx?docid=" & DocId.ToString() & "&w=30"
                        Else
                            AdNumberThumbnail.ImageUrl = "~/Images/spacer.gif"
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    DirectCast(dataItem("GridTemplateColumnEventInfo").FindControl("TxtEVENT_DESC_LONG"), TextBox).Attributes.Add("onblur", "DataChangeAutoSaveComment('" & RowEventId & "',this.value);")

                Catch ex As Exception

                End Try
            Catch ex As Exception
            End Try
        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridFooterItem Then
            Try
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub RadGridEventScheduler_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridEventScheduler.PreRender
        Dim gtv As Telerik.Web.UI.GridTableView

        For i As Integer = 0 To Me.RadGridEventScheduler.MasterTableView.Items.Count - 1
            For j As Integer = 0 To Me.RadGridEventScheduler.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                gtv = CType(Me.RadGridEventScheduler.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                If gtv.Items.Count > 0 Then
                    For Each dataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                        If dataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or dataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then


                            Dim EventTaskId As Integer = 0
                            Try
                                EventTaskId = CType(dataItem.GetDataKeyValue("EVENT_TASK_ID"), Integer)
                            Catch ex As Exception
                                EventTaskId = 0
                            End Try
                            If EventTaskId > 0 Then
                                Try
                                    DirectCast(dataItem("GridTemplateColumnTaskEditableInfo").FindControl("TxtTaskCOMMENTS"), TextBox).Attributes.Add("onblur", "DataChangeAutoSaveTaskComment('" & EventTaskId & "',this.value);")
                                Catch ex As Exception
                                End Try
                                Try
                                    Dim tb As New System.Web.UI.WebControls.TextBox
                                    tb = DirectCast(dataItem("GridTemplateColumnTaskEditableInfo").FindControl("TxtEMP_CODE"), TextBox)
                                    tb.Attributes.Add("ondblclick", "Javascript:OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & tb.ClientID & "&type=empcode');return false;")
                                    tb.Attributes.Add("onblur", "DataChangeAutoSaveTaskEmployee('" & EventTaskId & "',this.name,this.value);")
                                Catch ex As Exception
                                End Try
                            End If


                        End If
                    Next
                End If
            Next
        Next

    End Sub

    Private Sub SetGrouping()
        Me.RadGridEventScheduler.MasterTableView.GroupByExpressions.Clear()
    End Sub

    Private Sub LoadLookups()
        Me.LoadAdNumberFilter()
        Me.LoadGeneratorFilter()
        Me.LoadResourceTypesFinder()
    End Sub

    Private Sub LoadAdNumberFilter()
        Dim evt As New cEvents()
        Dim dt As New DataTable
        dt = Nothing
        dt = evt.GetAdNumbers(Me.StartDate, Me.EndDate, 0, 0)
        With Me.DropDownListAdNumbersFilter
            .Items.Clear()
            If dt.Rows.Count > 0 Then
                .Enabled = True
                .DataValueField = "AD_NUMBER"
                .DataTextField = "AD_NBR_DESC"
                .DataSource = dt
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Show all]", ""))
            Else
                .SelectedIndex = -1
                ' .Enabled = False
            End If
        End With
        With Me.DropDownListAdNumbers
            .Items.Clear()
            If dt.Rows.Count > 0 Then
                .Enabled = True
                .DataValueField = "AD_NUMBER"
                .DataTextField = "AD_NBR_DESC"
                .DataSource = dt
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            Else
                .SelectedIndex = -1
                '.Enabled = False
            End If
        End With

    End Sub

    Private Sub LoadGeneratorFilter()
        Dim evt As New cEvents()
        Dim dt As New DataTable
        dt = evt.EventGenGetListByDate(Me.StartDate, Me.EndDate)
        With Me.DropDownListEventGenerators
            .Items.Clear()
            Dim itm As New Telerik.Web.UI.RadComboBoxItem
            With itm
                .Text = "[Show all]"
                .Value = "-1"
            End With
            .Items.Insert(0, itm)
            If dt.Rows.Count > 0 Then
                .Enabled = True
                .DataValueField = "EVENT_GEN_ID"
                .DataTextField = "EVENT_GEN_LABEL"
                .DataSource = dt
                .DataBind()
            Else
                .SelectedIndex = 0
                .Enabled = False
            End If
        End With

    End Sub

    Private Sub LoadResourceTypesFinder()
        Dim evt As New cEvents()
        Dim dt As New DataTable
        dt = Nothing
        Dim rsc As New cResources()
        dt = rsc.GetResourceTypes(Me.StartDate, Me.EndDate)
        With Me.DropDownListResourceType
            .Items.Clear()
            Dim itm As New Telerik.Web.UI.RadComboBoxItem
            With itm
                .Text = "[Please select]"
                .Value = ""
            End With
            .Items.Insert(0, itm)
            If dt.Rows.Count > 0 Then
                .Enabled = True
                .DataValueField = "RESOURCE_TYPE_CODE"
                .DataTextField = "RESOURCE_TYPE_DESC"
                .DataSource = dt
                .DataBind()
            Else
                .SelectedIndex = 0
                .Enabled = False
            End If
        End With
    End Sub

    Private Sub DropDownListResourceType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListResourceType.SelectedIndexChanged

    End Sub

    Private Sub ButtonResourcesFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonResourcesFind.Click
        If Me.DropDownListResourceType.SelectedIndex = 0 Then
            Me.ShowMessage("Please select a Resource Type")
            Exit Sub
        End If
        If Me.DropDownListAdNumbers.SelectedIndex = 0 Then
            Me.ShowMessage("Please select an Ad Number option")
            Exit Sub
        End If
        Me.HiddenFieldMoveDirection.Value = ""
        Me.UpdateResources()
        Me.RadGridEventScheduler.Rebind()
    End Sub

    Private Sub UpdateResources()
        Dim RowCount As Integer = Me.RadGridEventScheduler.MasterTableView.Items.Count
        Dim z As Integer = 0
        If RowCount > 0 Then
            Dim EventIds As New System.Text.StringBuilder
            '''Dim chk As CheckBox
            For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridEventScheduler.MasterTableView.Items
                '''chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                '''If chk.Checked = True Then
                With EventIds
                    .Append(CType(CurrentGridRow.GetDataKeyValue("EVENT_ID"), Integer).ToString())
                    .Append(",")
                End With
                '''End If
            Next
            Dim EventIdString As String = EventIds.ToString()
            EventIdString = MiscFN.CleanStringForSplit(EventIdString, ",")
            Dim rsc As New cResources()
            Dim evt As New cEvents()
            Dim dt As New DataTable
            Dim DtRowCount As Integer = 0

            dt = rsc.FindAvailableResources(EventIdString, Me.DropDownListResourceType.SelectedValue, Me.DropDownListAdNumbers.SelectedValue, _
                                            True, Me.CheckBoxOverrideExistingResources.Checked).Tables(0)
            Dim NoData As Boolean = False
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    DtRowCount = dt.Rows.Count
                    For x As Integer = 0 To dt.Rows.Count - 1
                        Dim EventId As Integer = 0
                        Dim ResourceCode As String = ""
                        If Not IsDBNull(dt.Rows(x)("EVENT_ID")) Then
                            EventId = CType(dt.Rows(x)("EVENT_ID"), Integer)
                        End If
                        If Not IsDBNull(dt.Rows(x)("FIRST_CHOICE")) Then
                            ResourceCode = dt.Rows(x)("FIRST_CHOICE").ToString()
                        End If
                        If EventId > 0 Then
                            evt.EventUpdateResource(EventId, ResourceCode, True, False, Me.CheckBoxDeleteAutomaticTasks.Checked)
                        End If
                    Next
                Else
                    NoData = True
                End If
            Else
                NoData = True
            End If
            If NoData = True Then
                Me.ShowMessage("All events have a resource or there are no resources available")
            Else
                Me.ShowMessage("Resources updated for " & DtRowCount.ToString() & " events")
            End If
            '''Me.RadGridEventScheduler.Rebind()
            '''Dim evt As New cEvents()
            '''For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridEventScheduler.MasterTableView.Items
            '''    '''chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
            '''    '''If chk.Checked = True Then
            '''    Dim CurrResourceCode As String = CType(CurrentGridRow.FindControl("HiddenFieldResourceCode"), HiddenField).Value
            '''    evt.EventUpdateResource(CType(CurrentGridRow.GetDataKeyValue("EVENT_ID"), Integer), CurrResourceCode, True, False, Me.CheckBoxDeleteAutomaticTasks.Checked)
            '''    '''End If
            '''Next
        End If
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Shared Function AutoSaveComment(ByVal RowEventIdString As String, ByVal CommentString As String) As String
        Try
            Dim RowEventId As Integer = 0
            If IsNumeric(RowEventIdString) = True Then
                RowEventId = CType(RowEventIdString, Integer)
            End If
            If RowEventId > 0 Then
                Dim SQL As New System.Text.StringBuilder
                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                    Dim MyTrans As SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand()

                    With SQL
                        .Append("UPDATE [EVENT] WITH(ROWLOCK) SET EVENT_DESC_LONG = @EVENT_DESC_LONG WHERE [EVENT].EVENT_ID = @EVENT_ID;")
                    End With

                    Dim pEVENT_ID As New SqlParameter("@EVENT_ID", SqlDbType.Int)
                    pEVENT_ID.Value = RowEventId
                    MyCmd.Parameters.Add(pEVENT_ID)

                    Dim pEVENT_DESC_LONG As New SqlParameter
                    With pEVENT_DESC_LONG
                        .ParameterName = "@EVENT_DESC_LONG"
                        .SqlDbType = SqlDbType.Text
                        If CommentString.Trim() = "" Then
                            .Value = System.DBNull.Value
                        Else
                            .Value = CommentString.Trim()
                        End If
                    End With
                    MyCmd.Parameters.Add(pEVENT_DESC_LONG)
                    Try
                        With MyCmd
                            .CommandText = SQL.ToString()
                            .CommandType = CommandType.Text
                            .Connection = MyConn
                            .Transaction = MyTrans
                            .ExecuteNonQuery()
                        End With
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If
        Catch ex As Exception
        End Try

    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function AutoSaveTaskComment(ByVal RowEventTaskIdString As String, ByVal CommentString As String) As String
        Try
            Dim RowEventTaskId As Integer = 0
            If IsNumeric(RowEventTaskIdString) = True Then
                RowEventTaskId = CType(RowEventTaskIdString, Integer)
            End If
            If RowEventTaskId > 0 Then
                Dim SQL As New System.Text.StringBuilder
                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                    Dim MyTrans As SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand()

                    With SQL
                        .Append("UPDATE [EVENT_TASK] WITH(ROWLOCK) SET COMMENTS = @COMMENTS WHERE [EVENT_TASK].EVENT_TASK_ID = @EVENT_TASK_ID;")
                    End With

                    Dim pEVENT_TASK_ID As New SqlParameter("@EVENT_TASK_ID", SqlDbType.Int)
                    pEVENT_TASK_ID.Value = RowEventTaskId
                    MyCmd.Parameters.Add(pEVENT_TASK_ID)

                    Dim pCOMMENTS As New SqlParameter
                    With pCOMMENTS
                        .ParameterName = "@COMMENTS"
                        .SqlDbType = SqlDbType.Text
                        If CommentString.Trim() = "" Then
                            .Value = System.DBNull.Value
                        Else
                            .Value = CommentString.Trim()
                        End If
                    End With
                    MyCmd.Parameters.Add(pCOMMENTS)
                    Try
                        With MyCmd
                            .CommandText = SQL.ToString()
                            .CommandType = CommandType.Text
                            .Connection = MyConn
                            .Transaction = MyTrans
                            .ExecuteNonQuery()
                        End With
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If
        Catch ex As Exception
        End Try

    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function AutoSaveTaskEmployee(ByVal RowEventTaskIdString As String, ByVal TextboxEmployeeClientId As String, ByVal EmpCode As String) As String
        Try
            Dim ReturnMessage As String = ""
            Dim RowEventTaskId As Integer = 0
            If IsNumeric(RowEventTaskIdString) = True Then
                RowEventTaskId = CType(RowEventTaskIdString, Integer)
            End If
            If RowEventTaskId > 0 Then
                Dim DoUpdate As Boolean = True
                Dim SQL As New System.Text.StringBuilder
                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                    Dim MyTrans As SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand()

                    With SQL
                        .Append("UPDATE [EVENT_TASK] WITH(ROWLOCK) SET EMP_CODE = @EMP_CODE WHERE [EVENT_TASK].EVENT_TASK_ID = @EVENT_TASK_ID;")
                    End With

                    Dim pEVENT_TASK_ID As New SqlParameter("@EVENT_TASK_ID", SqlDbType.Int)
                    pEVENT_TASK_ID.Value = RowEventTaskId
                    MyCmd.Parameters.Add(pEVENT_TASK_ID)

                    Dim pEMP_CODE As New SqlParameter
                    With pEMP_CODE
                        .ParameterName = "@EMP_CODE"
                        .SqlDbType = SqlDbType.VarChar
                        .Size = 6
                        If EmpCode.Trim() = "" Then
                            .Value = System.DBNull.Value
                        Else
                            'validate employee here!
                            Dim val As New cValidations(HttpContext.Current.Session("ConnString"))
                            If val.ValidateEmpCode(EmpCode) = False Then
                                DoUpdate = False
                                ReturnMessage = "Invalid Employee Code:  " & EmpCode
                            End If
                            Dim rsc As New cResources()
                            If rsc.EmployeeIsBooked(EmpCode, RowEventTaskId) = True Then
                                DoUpdate = False
                                ReturnMessage = "The selected employee is booked on a different event task for this time period"
                            End If
                            .Value = EmpCode.Trim()
                        End If
                    End With
                    MyCmd.Parameters.Add(pEMP_CODE)
                    Try
                        If DoUpdate = True Then
                            With MyCmd
                                .CommandText = SQL.ToString()
                                .CommandType = CommandType.Text
                                .Connection = MyConn
                                .Transaction = MyTrans
                                .ExecuteNonQuery()
                            End With
                            MyTrans.Commit()
                            ReturnMessage = ""
                        End If
                    Catch ex As Exception
                        MyTrans.Rollback()
                        ReturnMessage = ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If
            Return ReturnMessage
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

    Public Sub UcResources_DropResourcesSelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.HiddenFieldMoveDirection.Value = ""
        Me.RadGridEventScheduler.Rebind()
    End Sub

    Private Sub DropDownListAdNumbersFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListAdNumbersFilter.SelectedIndexChanged
        Me.HiddenFieldMoveDirection.Value = ""
        Me.RadGridEventScheduler.Rebind()
    End Sub

    Private Sub DropDownListEventGenerators_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListEventGenerators.SelectedIndexChanged
        Me.HiddenFieldMoveDirection.Value = ""
        Me.RadGridEventScheduler.Rebind()
    End Sub

    Private Sub CheckBoxOnlyEventsWithoutResource_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxOnlyEventsWithoutResource.CheckedChanged
        Me.HiddenFieldMoveDirection.Value = ""
        Me.RadGridEventScheduler.Rebind()
    End Sub

    Private Sub CheckBoxShowAdNumberImage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowAdNumberImage.CheckedChanged
        Me.HiddenFieldMoveDirection.Value = ""
        Me.RadGridEventScheduler.Rebind()
    End Sub

End Class