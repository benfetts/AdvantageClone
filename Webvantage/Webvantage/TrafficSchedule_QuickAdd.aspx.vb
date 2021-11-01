Public Class TrafficSchedule_QuickAdd
    Inherits Webvantage.BaseChildPage

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0
    Private _IsRush As Boolean = False
    Private _SchedDueDate As String
    Private _RushApproved As Boolean = False

#End Region

#Region " Methods "

    Private Sub SetRushColumns()

        With Me.RadGridQuickAdd.MasterTableView

            .GetColumn("colTRF_PRESET_DAYS").Display = Not _IsRush
            .GetColumn("colTRF_PRESET_HRS").Display = Not _IsRush
            .GetColumn("colRUSH_DAYS").Display = _IsRush
            .GetColumn("colRUSH_HOURS").Display = _IsRush

        End With

        Me.RblStandardRush.Items(0).Selected = Not _IsRush
        Me.RblStandardRush.Items(1).Selected = _IsRush

    End Sub
    Private Sub BindDropPresets()

        'objects
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
    Private Sub CloseAndRefresh()

        'Dim FunctionName As String = "RefreshGrid"
        'Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
        'Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx")
        Me.CloseThisWindow()

    End Sub
    Private Sub SetRushData()

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing
        Dim WorkingDays As Integer = Nothing
        Dim RecommendedString As String = Nothing
        Dim Standard As Integer = Nothing
        Dim Rush As Integer = Nothing

        WorkingDays = MiscFN.GetWorkingDays(Now.ToShortDateString(), _SchedDueDate)
        RecommendedString = " (Recommended)"

        If Me.DropPreset.SelectedIndex > 1 Then

            Schedule = New Webvantage.cSchedule(Session("ConnString"), Session("EmpCode"))

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, Me.DropPreset.SelectedValue)

                    If TaskTemplate IsNot Nothing Then

                        Rush = Format(AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalRushDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code), "d")
                        Standard = Format(AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalStandardDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code), "d")

                    End If

                End Using

            End Using

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

#Region "  Page Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim GridGroupByExpression As Telerik.Web.UI.GridGroupByExpression = Nothing
        Dim WorkingDays As Integer = Nothing

        Try

            If IsNumeric(Request.QueryString("JobNum")) = True Then

                _JobNumber = CType(Request.QueryString("JobNum"), Integer)

            Else

                _JobNumber = 0

            End If

        Catch ex As Exception
            _JobNumber = 0
        End Try

        Try
            If IsNumeric(Request.QueryString("JobComp")) = True Then

                _JobComponentNumber = CType(Request.QueryString("JobComp"), Integer)

            Else

                _JobComponentNumber = 0

            End If

        Catch ex As Exception
            _JobComponentNumber = 0
        End Try

        Try
            If cGlobals.wvIsDate(Request.QueryString("DueDate")) = True Then

                _SchedDueDate = cGlobals.wvCDate(Request.QueryString("DueDate")).ToShortDateString

            Else

                _SchedDueDate = ""

            End If

        Catch ex As Exception
            _SchedDueDate = ""
        End Try

        Try

            If Not Request.QueryString("Rush") = Nothing Then

                Dim r As Integer = CType(Request.QueryString("Rush"), Integer)

                If r = 1 Then

                    _RushApproved = True

                Else

                    _RushApproved = False

                End If

            End If

        Catch ex As Exception
            _RushApproved = False
        End Try

        'Me.RadGridQuickAdd.Skin = MiscFN.SetRadGridSkin()
        If Not Me.IsPostBack Then

            ClearRushLabels()
            BindDropPresets()

            If _RushApproved = True Then

                Me.RblStandardRush.SelectedIndex = 1
                _IsRush = True

            End If

            Me.LblJobDueDate.Text = _SchedDueDate
            Me.LblTodaysDate.Text = String.Format("{0:d}", cEmployee.TimeZoneToday)

            WorkingDays = MiscFN.GetWorkingDays(Me.LblTodaysDate.Text, _SchedDueDate)

            Me.LblWorkingDays.Text = WorkingDays.ToString

            If IsDate(_SchedDueDate) = False Then

                Me.RblStandardRush.SelectedIndex = 0

            End If

            'group:
            GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("TRF_PRESET_DESC Template Group By TRF_PRESET_DESC")

            With Me.RadGridQuickAdd

                .MasterTableView.GroupByExpressions.Clear()
                .MasterTableView.GroupByExpressions.Add(GridGroupByExpression)
                .MasterTableView.GroupsDefaultExpanded = True
                .Rebind()
                .MasterTableView.GetColumn("colTRF_PRESET_DESC").Display = False

            End With
        Else
            If (EventArgument = "Refresh") Then
                BindDropPresets()

                ClearRushLabels()
                Me.RadGridQuickAdd.Rebind()
            End If
        End If
    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub BtnAddTasks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddTasks.Click

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
        Dim NewSequenceNumberList As Generic.List(Of Short) = Nothing
        ' Dim SyncWithOutlook As Boolean = False
        Dim chk As CheckBox

        'Try

        '    Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

        '        SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)

        '    End Using

        'Catch ex As Exception
        '    SyncWithOutlook = False
        'End Try

        NewSequenceNumberList = New Generic.List(Of Short)

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuickAdd.MasterTableView.Items
            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
            If chk.Checked = True Then
                'Set variables:
                Try
                    NewJobOrder = CType(CType(gridDataItem("colTRF_PRESET_ORDER").FindControl("TxtTRF_PRESET_ORDER"), TextBox).Text, Integer)
                Catch ex As Exception
                    NewJobOrder = 0
                End Try
                Try
                    NewPhaseID = CType(CType(gridDataItem("colTRF_PRESET_ORDER").FindControl("HFPhaseID"), HiddenField).Value, Integer)
                Catch ex As Exception
                    NewPhaseID = 0
                End Try
                NewTaskCode = gridDataItem("colFNC_CODE").Text.Replace("&nbsp;", "")
                NewTaskDescription = gridDataItem("colTRF_DESC").Text.Replace("&nbsp;", "")
                Try
                    NewMilestone = CType(gridDataItem("colMILESTONE").FindControl("ChkMILESTONE"), CheckBox).Checked
                Catch ex As Exception
                    NewMilestone = False
                End Try

                NewEstimateFunction = CType(gridDataItem("colMILESTONE").FindControl("HfEstimateFunction"), HiddenField).Value

                _IsRush = Me.RblStandardRush.Items(1).Selected
                If _IsRush = True Then
                    Try
                        NewJobDays = CType(CType(gridDataItem("colRUSH_DAYS").FindControl("TxtRUSH_DAYS"), TextBox).Text, Integer)
                    Catch ex As Exception
                        NewJobDays = 0
                    End Try
                    Try
                        NewJobHours = CType(CType(gridDataItem("colRUSH_HOURS").FindControl("TxtRUSH_HOURS"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        NewJobHours = 0
                    End Try
                Else
                    Try
                        NewJobDays = CType(CType(gridDataItem("colTRF_PRESET_DAYS").FindControl("TxtTRF_PRESET_DAYS"), TextBox).Text, Integer)
                    Catch ex As Exception
                        NewJobDays = 0
                    End Try
                    Try
                        NewJobHours = CType(CType(gridDataItem("colTRF_PRESET_HRS").FindControl("TxtTRF_PRESET_HRS"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        NewJobHours = 0
                    End Try
                End If

                Try
                    NewDefRoleCode = CType(gridDataItem("colTRF_PRESET_ORDER").FindControl("HFRoleCode"), HiddenField).Value
                Catch ex As Exception
                    NewDefRoleCode = ""
                End Try

                Try
                    NewEmpCodeString = CType(gridDataItem("colMILESTONE").FindControl("HfDEFAULT_EMP"), HiddenField).Value
                Catch ex As Exception
                    NewEmpCodeString = ""
                End Try

                'Try
                '    NewStartDate = CType(gridDataItem("colSTART_DATE").FindControl("TxtSTART_DATE"), TextBox).Text
                '    If cGlobals.wvIsDate(NewStartDate) = True Then
                '        NewStartDate = cGlobals.wvCDate(NewStartDate).ToShortDateString
                '    Else
                '        NewStartDate = ""
                '    End If
                'Catch ex As Exception
                '    NewStartDate = ""
                'End Try
                'Save:
                Try
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    'straighten out the phaseID and description! (also on quick add)
                    JobComponentTaskSequenceNumber = oTrafficSchedule.AddNewTask(_JobNumber, _JobComponentNumber, NewJobOrder, NewPhaseID, NewPredessorString, NewTaskCode, NewTaskDescription, NewMilestone, NewJobDays,
                                                                     NewJobHours, NewStartDate, NewRevisedDate, NewDueTime, NewJobDueDate, False, NewJobCompletedDate,
                                                                     NewEmpCodeString, NewEstimateFunction, NewFunctionComment, NewDueDateComment, NewRevisedDateComment, NewDefRoleCode, NewClientCodeString, "")
                Catch ex As Exception
                    JobComponentTaskSequenceNumber = ""
                Finally

                    If IsNumeric(JobComponentTaskSequenceNumber) Then

                        NewSequenceNumberList.Add(CShort(JobComponentTaskSequenceNumber))

                    End If

                    'If SyncWithOutlook Then

                    '    If IsNumeric(JobComponentTaskID) Then

                    '        AdvantageFramework.Calendar.Outlook.SyncJobComponentTask(Session("ConnString").ToString(), Session("UserCode").ToString, CInt(JobComponentTaskID), False)

                    '    End If

                    'End If

                End Try

            End If

        Next

        If NewSequenceNumberList IsNot Nothing AndAlso NewSequenceNumberList.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each NewSequenceNumber In NewSequenceNumberList

                    DbContext.Database.ExecuteSqlCommand(String.Format("exec [dbo].[advsp_traffic_schedule_CreateDefaultPredecessor] {0}, {1}, {2}", _JobNumber, _JobComponentNumber, NewSequenceNumber))

                Next

            End Using

        End If

        CloseAndRefresh()

    End Sub
    Private Sub RblStandardRush_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblStandardRush.SelectedIndexChanged

        If Me.RblStandardRush.SelectedIndex = 0 Then

            _IsRush = False

        Else

            _IsRush = True

        End If

        Me.RadGridQuickAdd.Rebind()

    End Sub
    Private Sub ButtonSaveAsTemplate_Click(sender As Object, e As EventArgs) Handles ButtonSaveAsTemplate.Click

        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        With QueryString

            .Page = "TrafficScheduleTemplate_New.aspx"
            .JobNumber = _JobNumber
            .JobComponentNumber = _JobComponentNumber
            .Add("tmplt_type", CType(TrafficScheduleTemplate_New.TemplateType.Task, Integer).ToString())

        End With

        Me.OpenWindow(QueryString, "", 0, 0, False, False, "RefreshPage")

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
    Private Sub RadGridQuickAdd_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuickAdd.ItemDataBound

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            Try

                If e.Item.DataItem("MILESTONE") = "1" Then

                    CType(e.Item.FindControl("chkMILESTONE"), CheckBox).Checked = True

                End If

            Catch ex As Exception

            End Try

            Try

                CType(e.Item.FindControl("TxtSTART_DATE"), TextBox).Text = Now.Date.ToShortDateString()

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub RadGridQuickAdd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuickAdd.NeedDataSource

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing

        If Me.DropPreset.SelectedIndex > 0 Then

            Schedule = New Webvantage.cSchedule(Session("ConnString"), Session("EmpCode"))

            Using DataTable = Schedule.GetQuickAddDT(True)

                If Me.DropPreset.SelectedIndex > 1 Then

                    DataTable.DefaultView.RowFilter = "TRF_PRESET_CODE = '" & Me.DropPreset.SelectedValue.ToString() & "'"

                End If

                Me.RadGridQuickAdd.DataSource = DataTable.DefaultView

            End Using

            SetRushData()
            SetRushColumns()

        End If

    End Sub

#End Region

#End Region

End Class
