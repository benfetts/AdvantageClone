Public Class Schedule_QuickAdd
    Inherits Webvantage.BaseChildPage

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNbr As Integer = 0
    Private _IsRush As Boolean = False
    Private _SchedDueDate As String
    Private _RushApproved As Boolean = False
    Private _PageMode As Integer = 0  '  0 = Template Add,  1 = New Quick Add
    Private _LoadingDatasource As Boolean = False

#End Region

#Region " Methods "

    Private Sub SetPage()

        Select Case _PageMode

            Case 0

                Me.TrPresetInfo.Visible = True

            Case 1

                Me.TrPresetInfo.Visible = False

        End Select

    End Sub
    Private Sub SetRushColumns()

        With Me.RadGridQuickAdd.MasterTableView

            .GetColumn("ColTRF_PRESET_DAYS").Display = Not _IsRush
            .GetColumn("ColTRF_PRESET_HRS").Display = Not _IsRush
            .GetColumn("ColRUSH_DAYS").Display = _IsRush
            .GetColumn("ColRUSH_HOURS").Display = _IsRush

        End With

        Me.RblStandardRush.Items(0).Selected = Not _IsRush
        Me.RblStandardRush.Items(1).Selected = _IsRush

    End Sub
    Private Sub BindDropPresets()

        Dim DropDowns As Webvantage.cDropDowns = Nothing

        DropDowns = New Webvantage.cDropDowns(_Session.ConnectionString)

        With Me.DropPreset

            .DataSource = DropDowns.GetTrafficPresets()
            .DataTextField = "CodeAndDescription"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Select Template]", "[Select Template]"))
            .Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem("[All Templates]", "[All Templates]"))

        End With

    End Sub
    Private Sub ClearRushLabels()

        Me.RblStandardRush.Items(0).Text = "Standard Days"
        Me.RblStandardRush.Items(1).Text = "Rush Days"

    End Sub
    Private Sub SetRushData()

        'objects
        Dim Schedule As Webvantage.cSchedule = New Webvantage.cSchedule(Session("ConnString"), Session("EmpCode"))
        Dim RecommendedString As String = " (Recommended)"
        Dim Standard As Integer = Nothing
        Dim Rush As Integer = Nothing
        Dim WorkingDays As Integer = Nothing

        WorkingDays = MiscFN.GetWorkingDays(Now.ToShortDateString(), _SchedDueDate)

        If Me.DropPreset.SelectedIndex > 1 Then

            Schedule = New Webvantage.cSchedule(Session("ConnString"), Session("EmpCode"))

            Schedule.GetPresetDays(Me.DropPreset.SelectedValue, Standard, Rush)

            If Standard > WorkingDays Then

                If Rush = 0 Then

                    RecommendedString = " (Recommended, but no days set.)"

                End If

                Me.RblStandardRush.Items(0).Text = "Standard Schedule: " & Standard.ToString() & " days"
                Me.RblStandardRush.Items(1).Text = "Rush Schedule: " & Rush.ToString() & " days" & RecommendedString

            Else

                If Standard = 0 Then

                    RecommendedString = " (Recommended, but no days set.)"

                End If

                Me.RblStandardRush.Items(0).Text = "Standard Schedule: " & Standard.ToString() & " days" & RecommendedString
                Me.RblStandardRush.Items(1).Text = "Rush Schedule: " & Rush.ToString() & " days"

            End If

        ElseIf Me.DropPreset.SelectedIndex = 1 Then

            Me.RblStandardRush.Items(0).Text = "Standard"
            Me.RblStandardRush.Items(1).Text = "Rush"

        End If

        'add as final override if rush is approved:
        If _RushApproved = True Then

            Me.RblStandardRush.Items(0).Text = "Standard Schedule: " & Standard.ToString() & " days"
            Me.RblStandardRush.Items(1).Text = "Rush Schedule: " & Rush.ToString() & " days (Rush Charges approved!)"

        End If

    End Sub
    Private Sub CloseAndRefresh()

        'If Me.CurrentQuerystring.IsJobDashboard = True Then
        '    Me.CloseThisWindowAndRefreshCaller("Content.aspx")
        'Else
        '    Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx")
        'End If
        'Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx")
        Me.CloseThisWindow()

    End Sub
    Private Sub AddSelectedTasks()

        'objects
        Dim NewTaskStatus As String = ""
        Dim NewPhaseDesc As String = ""
        Dim NewPhaseID As Integer = 0
        Dim NewJobOrder As Integer = 0
        Dim NewPredessorString As String = ""
        Dim NewTaskCode As String = ""
        Dim NewTaskDescription As String = ""
        Dim NewMilestone As Boolean = False
        Dim NewJobDays As Integer = 0
        Dim NewJobHours As Decimal = 0.0
        Dim NewStartDate As String = ""
        Dim NewRevisedDate As String = ""
        Dim NewDueTime As String = ""
        Dim NewJobDueDate As String = ""
        Dim NewJobCompletedDate As String = ""
        Dim NewEmpCodeString As String = ""
        Dim NewClientCodeString As String = ""
        Dim NewEstimateFunction As String = ""
        Dim NewFunctionComment As String = ""
        Dim NewDueDateComment As String = ""
        Dim NewRevisedDateComment As String = ""
        Dim NewDefRoleCode As String = ""
        Dim JobComponentTaskSequenceNumber As String = ""
        Dim NumberOfRowsToAdd As Integer = 1
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim NewSequenceNumberList As Generic.List(Of Short) = Nothing

        NewSequenceNumberList = New Generic.List(Of Short)

        If Me.ChkBlankTasks.Checked = False And Me.RadGridQuickAdd.Visible = True Then

            Dim chk As CheckBox

            'Dim SyncWithOutlook As Boolean = False
            'Try
            '    Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())
            '        SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)
            '    End Using
            'Catch ex As Exception
            '    SyncWithOutlook = False
            'End Try

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuickAdd.MasterTableView.Items

                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)

                If chk.Checked = True Then

                    Dim HasFunctionData As Boolean = False

                    Try

                        Dim s As String = CType(gridDataItem("ColROW_QTY").FindControl("TxtROW_QTY"), TextBox).Text

                        If IsNumeric(s) = True Then

                            NumberOfRowsToAdd = CType(s, Integer)

                        Else

                            NumberOfRowsToAdd = 1

                        End If

                    Catch ex As Exception
                        NumberOfRowsToAdd = 1
                    End Try

                    'Set variables:
                    Try

                        NewJobOrder = CType(CType(gridDataItem("ColTRF_PRESET_ORDER").FindControl("TxtTRF_PRESET_ORDER"), TextBox).Text, Integer)

                    Catch ex As Exception
                        NewJobOrder = 0
                    End Try

                    Try

                        NewPhaseID = CType(CType(gridDataItem("ColTRF_PRESET_ORDER").FindControl("HFPhaseID"), HiddenField).Value, Integer)

                    Catch ex As Exception
                        NewPhaseID = 0
                    End Try

                    NewTaskCode = gridDataItem("ColFNC_CODE").Text.Trim().Replace("&nbsp;", "")
                    NewTaskDescription = gridDataItem("ColTRF_DESC").Text.Trim().Replace("&nbsp;", "")
                    HasFunctionData = True

                    If NewTaskDescription = "[Enter Task Description]" Or NewTaskDescription = "" Then

                        NewTaskCode = ""
                        NewTaskDescription = "[Blank]"

                    End If

                    Try

                        NewMilestone = CType(gridDataItem("ColMILESTONE").FindControl("ChkMILESTONE"), CheckBox).Checked

                    Catch ex As Exception
                        NewMilestone = False
                    End Try

                    NewEstimateFunction = CType(gridDataItem("ColMILESTONE").FindControl("HfEstimateFunction"), HiddenField).Value

                    _IsRush = Me.RblStandardRush.Items(1).Selected

                    If _IsRush = True Then

                        Try

                            NewJobDays = CType(CType(gridDataItem("ColRUSH_DAYS").FindControl("TxtRUSH_DAYS"), TextBox).Text, Integer)

                        Catch ex As Exception
                            NewJobDays = 0
                        End Try

                        Try

                            NewJobHours = CType(CType(gridDataItem("ColRUSH_HOURS").FindControl("TxtRUSH_HOURS"), TextBox).Text, Decimal)

                        Catch ex As Exception
                            NewJobHours = 0
                        End Try

                    Else

                        Try

                            NewJobDays = CType(CType(gridDataItem("ColTRF_PRESET_DAYS").FindControl("TxtTRF_PRESET_DAYS"), TextBox).Text, Integer)

                        Catch ex As Exception
                            NewJobDays = 0
                        End Try

                        Try

                            NewJobHours = CType(CType(gridDataItem("ColTRF_PRESET_HRS").FindControl("TxtTRF_PRESET_HRS"), TextBox).Text, Decimal)

                        Catch ex As Exception
                            NewJobHours = 0
                        End Try

                    End If

                    Try

                        NewDefRoleCode = CType(gridDataItem("ColTRF_PRESET_ORDER").FindControl("HFRoleCode"), HiddenField).Value

                    Catch ex As Exception
                        NewDefRoleCode = ""
                    End Try

                    Try

                        NewEmpCodeString = CType(gridDataItem("ColMILESTONE").FindControl("HfDEFAULT_EMP"), HiddenField).Value

                    Catch ex As Exception
                        NewEmpCodeString = ""
                    End Try

                    'Save:
                    Try
                        'straighten out the phaseID and description! (also on quick add)
                        For i As Integer = 0 To NumberOfRowsToAdd - 1

                            If HasFunctionData = True Then

                                JobComponentTaskSequenceNumber = oTrafficSchedule.AddNewTask(_JobNumber, _JobComponentNbr, NewJobOrder, NewPhaseID, NewPredessorString, NewTaskCode, NewTaskDescription, NewMilestone, NewJobDays,
                                                                                             NewJobHours, NewStartDate, NewRevisedDate, NewDueTime, NewJobDueDate, False, NewJobCompletedDate,
                                                                                             NewEmpCodeString, NewEstimateFunction, NewFunctionComment, NewDueDateComment, NewRevisedDateComment, NewDefRoleCode, NewClientCodeString, "")

                                If IsNumeric(JobComponentTaskSequenceNumber) Then

                                    NewSequenceNumberList.Add(CShort(JobComponentTaskSequenceNumber))

                                End If

                                'If SyncWithOutlook AndAlso IsNumeric(JobComponentTaskSequenceNumber) Then

                                '    AdvantageFramework.Calendar.Outlook.SyncJobComponentTask(Session("ConnString").ToString(), Session("UserCode").ToString, JobNumber, JobComponentNbr, CInt(JobComponentTaskSequenceNumber), False)

                                'End If

                            End If

                        Next

                    Catch ex As Exception

                    End Try

                End If

            Next

        ElseIf Me.ChkBlankTasks.Checked = True And Me.TblBlankTasks.Visible = True Then

            If IsNumeric(Me.TxtBlankROW_QTY.Text.Trim()) = True Then

                NumberOfRowsToAdd = CType(Me.TxtBlankROW_QTY.Text.Trim(), Integer)

            End If

            If Me.TxtBlankTASK_DESCRIPTION.Text.Trim() = "" Then

                NewTaskDescription = ""

            Else

                NewTaskDescription = Me.TxtBlankTASK_DESCRIPTION.Text.Trim()

            End If

            If IsNumeric(Me.TxtBlankTRF_PRESET_ORDER.Text.Trim()) = True Then

                NewJobOrder = CType(Me.TxtBlankTRF_PRESET_ORDER.Text.Trim(), Integer)

            End If

            If IsNumeric(Me.TxtBlankTRF_PRESET_DAYS.Text.Trim()) = True Then

                NewJobDays = CType(Me.TxtBlankTRF_PRESET_DAYS.Text.Trim(), Integer)

            End If

            If IsNumeric(Me.TxtBlankTRF_PRESET_HRS.Text.Trim()) = True Then

                NewJobHours = CType(Me.TxtBlankTRF_PRESET_HRS.Text.Trim(), Decimal)

            End If

            NewMilestone = Me.ChkBlankMILESTONE.Checked

            For j As Integer = 0 To NumberOfRowsToAdd - 1

                JobComponentTaskSequenceNumber = oTrafficSchedule.AddNewTask(_JobNumber, _JobComponentNbr, NewJobOrder, NewPhaseID, NewPredessorString, NewTaskCode, NewTaskDescription, NewMilestone, NewJobDays,
                                                                             NewJobHours, NewStartDate, NewRevisedDate, NewDueTime, NewJobDueDate, False, NewJobCompletedDate,
                                                                             NewEmpCodeString, NewEstimateFunction, NewFunctionComment, NewDueDateComment, NewRevisedDateComment, NewDefRoleCode, NewClientCodeString, "")

                If IsNumeric(JobComponentTaskSequenceNumber) Then

                    NewSequenceNumberList.Add(CShort(JobComponentTaskSequenceNumber))

                End If

            Next

        End If

        If NewSequenceNumberList IsNot Nothing AndAlso NewSequenceNumberList.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each NewSequenceNumber In NewSequenceNumberList

                    DbContext.Database.ExecuteSqlCommand(String.Format("exec [dbo].[advsp_traffic_schedule_CreateDefaultPredecessor] {0}, {1}, {2}", _JobNumber, _JobComponentNbr, NewSequenceNumber))

                Next

            End Using

        End If

    End Sub

#Region "  Event Handlers "

    Private Sub Schedule_QuickAdd_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        With QueryString

            _JobNumber = .JobNumber
            _JobComponentNbr = .JobComponentNumber
            _SchedDueDate = .DueDate
            _IsRush = .Rush
            _PageMode = .GetValue("mode")

        End With

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.SetPage()

        If Not Me.IsPostBack And Not Me.IsCallback Then

            BindDropPresets()
            Me.TblBlankTasks.Visible = False

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RblStandardRush_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblStandardRush.SelectedIndexChanged

        If Me.RblStandardRush.SelectedIndex = 0 Then

            _IsRush = False

        Else

            _IsRush = True

        End If

        Me.RadGridQuickAdd.Rebind()

    End Sub
    Private Sub RadGridQuickAdd_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuickAdd.ItemDataBound

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ColumnClientSelectClientId As String = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

            Try

                If GridDataItem.DataItem("MILESTONE") = "1" Then

                    CType(GridDataItem.FindControl("chkMILESTONE"), System.Web.UI.WebControls.CheckBox).Checked = True

                End If

            Catch ex As Exception

            End Try

            Try

                CType(GridDataItem.FindControl("TxtSTART_DATE"), System.Web.UI.WebControls.TextBox).Text = Now.Date.ToShortDateString()

            Catch ex As Exception

            End Try

            Try

                ColumnClientSelectClientId = DirectCast(GridDataItem("ColumnClientSelect").Controls(0), System.Web.UI.WebControls.CheckBox).ClientID

                Using TextBox = DirectCast(GridDataItem.FindControl("TxtROW_QTY"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using TextBox = DirectCast(GridDataItem.FindControl("TxtTaskCode"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using TextBox = DirectCast(GridDataItem.FindControl("TxtTASK_DESCRIPTION"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using TextBox = DirectCast(GridDataItem.FindControl("TxtTRF_PRESET_ORDER"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using TextBox = DirectCast(GridDataItem.FindControl("TxtTRF_PRESET_DAYS"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using TextBox = DirectCast(GridDataItem.FindControl("TxtTRF_PRESET_HRS"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using CheckBox = DirectCast(GridDataItem.FindControl("ChkMILESTONE"), System.Web.UI.WebControls.CheckBox)

                    CheckBox.Attributes.Add("onclick", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub RadGridQuickAdd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuickAdd.NeedDataSource

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim GridGroupByExpression As Telerik.Web.UI.GridGroupByExpression = Nothing
        Dim DataView As System.Data.DataView = Nothing

        _LoadingDatasource = True

        Schedule = New Webvantage.cSchedule(Session("ConnString"), Session("EmpCode"))

        Select Case _PageMode

            Case 0

                Using DataTable = Schedule.GetQuickAddDT(True)

                    DataView = DataTable.DefaultView

                    If Me.DropPreset.SelectedIndex > 0 Then

                        If Me.DropPreset.SelectedIndex > 1 Then

                            DataView.RowFilter = "TRF_PRESET_CODE = '" & Me.DropPreset.SelectedValue.ToString() & "'"

                        End If

                    End If

                End Using

                SetRushData()
                SetRushColumns()

                GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("TRF_PRESET_DESC Template Group By TRF_PRESET_DESC")

                With Me.RadGridQuickAdd

                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GridGroupByExpression)
                    .MasterTableView.GroupsDefaultExpanded = True
                    .MasterTableView.GetColumn("ColTRF_PRESET_DESC").Display = False

                End With

                With Me.RadGridQuickAdd.MasterTableView

                    .GetColumn("ColROW_QTY").Display = False
                    .GetColumn("ColFNC_CODE").Display = True
                    .GetColumn("ColTRF_DESC").Display = True

                End With

            Case 1

                Using DataTable = Schedule.GetQuickAddDT(False)

                    DataView = DataTable.DefaultView

                End Using

        End Select

        Me.RadGridQuickAdd.DataSource = DataView
        Me.RadGridQuickAdd.PageSize = MiscFN.LoadPageSize(Me.RadGridQuickAdd.ID)
        _LoadingDatasource = False

    End Sub
    Private Sub RadGridQuickAdd_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridQuickAdd.PageIndexChanged

        Me.AddSelectedTasks()

    End Sub
    Private Sub RadGridQuickAdd_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridQuickAdd.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridQuickAdd.ID, e.NewPageSize)

        End If

    End Sub
    Private Sub BtnAddTasks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddTasks.Click

        AddSelectedTasks()
        CloseAndRefresh()

    End Sub
    Private Sub DropPreset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropPreset.SelectedIndexChanged

        Select Case Me.DropPreset.SelectedIndex

            Case 0

                ClearRushLabels()

            Case 1

                ClearRushLabels()
                Me.RadGridQuickAdd.Rebind()

            Case Else

                Me.RadGridQuickAdd.Visible = True
                Me.RadGridQuickAdd.Rebind()

        End Select

        If _RushApproved = True Then

            Me.RblStandardRush.SelectedIndex = 1
            _IsRush = True
            SetRushColumns()

        End If

    End Sub
    Private Sub ChkBlankTasks_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBlankTasks.CheckedChanged

        Me.TblBlankTasks.Visible = Me.ChkBlankTasks.Checked
        Me.RadGridQuickAdd.Visible = Not Me.ChkBlankTasks.Checked

        If Me.ChkBlankTasks.Checked = True Then

            Me.TxtBlankROW_QTY.Focus()

        End If

    End Sub

#End Region

#End Region

End Class
