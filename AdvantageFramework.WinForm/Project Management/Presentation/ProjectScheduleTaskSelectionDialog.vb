Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleTaskSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum FormTypes
            Tasks
            Templates
            Estimates
        End Enum

#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _DueDate As Date = Nothing
        Private _FormType As ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Public ReadOnly Property JobComponentNumber As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property
        Public ReadOnly Property DueDate As Date
            Get
                DueDate = _DueDate
            End Get
        End Property
        Public Property FormType As ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes
            Get
                FormType = _FormType
            End Get
            Set(value As ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes)
                _FormType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal FormType As ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, Optional ByVal DueDate As Date = Nothing)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _FormType = FormType
            _DueDate = DueDate

            RadioButtonControlTemplates_Rush.MinimumSize = New System.Drawing.Size(71, 20)
            RadioButtonControlTemplates_Standard.MinimumSize = New System.Drawing.Size(71, 20)
            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub EnableOrDisableActions()


        End Sub
        Private Sub LoadDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If TabItem Is Nothing Then

                For Each TabItem In TabControlForm_Tasks.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                TabItem = TabControlForm_Tasks.SelectedTab

            End If

            If TabItem.Tag = False Then

                If TabItem Is TabItemTasks_AvailableTasksTab Then

                    LoadAvailableTasksTab()

                ElseIf TabItem Is TabItemTasks_TaskTemplatesTab Then

                    LoadTaskTemplatesTab()

                ElseIf TabItem Is TabItemTasks_EstimatesTab Then

                    LoadEstimatesTab()

                End If

            End If

        End Sub
        Private Sub LoadAvailableTasksTab()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewTasks_Tasks.DataSource = AdvantageFramework.ProjectSchedule.LoadAvailableTasks(DbContext, False).ToList

            End Using

            DataGridViewTasks_Tasks.CurrentView.BestFitColumns()

            TabItemTasks_AvailableTasksTab.Tag = True

        End Sub
        Private Sub LoadTaskTemplatesTab()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewTemplates_TaskTemplates.DataSource = From Entity In AdvantageFramework.Database.Procedures.TaskTemplate.Load(DbContext)
                                                                 Where Entity.IsInactive Is Nothing OrElse
                                                                         Entity.IsInactive = 0
                                                                 Select Entity

            End Using

            DataGridViewTemplates_TaskTemplates.CurrentView.BestFitColumns()

            LoadTaskTemplateTasks()

            TabItemTasks_TaskTemplatesTab.Tag = True

        End Sub
        Private Sub LoadEstimatesTab()

            'objects
            Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    EstimateApproval = (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                        Where Entity.JobNumber = _JobNumber AndAlso
                                              Entity.JobComponentNumber = _JobComponentNumber
                                        Select Entity).SingleOrDefault

                Catch ex As Exception
                    EstimateApproval = Nothing
                End Try

                If EstimateApproval IsNot Nothing Then

                    DataGridViewEstimate_Tasks.DataSource = AdvantageFramework.Database.Procedures.EstimateTaskComplexType.Load(DbContext, EstimateApproval.EstimateNumber, EstimateApproval.EstimateComponentNumber, EstimateApproval.EstimateRevisionNumber, EstimateApproval.EstimateQuoteNumber).ToList

                End If

            End Using

            DataGridViewEstimate_Tasks.CurrentView.BestFitColumns()

            TabItemTasks_EstimatesTab.Tag = True

        End Sub
        Private Sub LoadTaskTemplateTasks()

            'objects
            Dim TemplateCodes As String() = Nothing
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing
            Dim WorkingDays As Integer = Nothing
            Dim StandardDifference As Integer = Nothing
            Dim RushDifference As Integer = Nothing
            Dim RushText As String = Nothing
            Dim StandardText As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    TemplateCodes = DataGridViewTemplates_TaskTemplates.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                Catch ex As Exception
                    TemplateCodes = {""}
                End Try

                DataGridViewTemplates_Tasks.DataSource = (From Entity In AdvantageFramework.ProjectSchedule.LoadAvailableTasks(DbContext, True)
                                                          Where TemplateCodes.Contains(Entity.TaskTemplateCode)
                                                          Select Entity).ToList

                If TemplateCodes.Count = 1 Then

                    RushText = "Rush Schedule"
                    StandardText = "Standard Schedule"

                    TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, TemplateCodes.FirstOrDefault)

                    If TaskTemplate IsNot Nothing Then

                        If TaskTemplate.TotalRushDays.HasValue Then

                            RushText &= ": " & TaskTemplate.TotalRushDays.Value.ToString & " days "

                        End If

                        If TaskTemplate.TotalStandardDays.HasValue Then

                            StandardText &= ": " & TaskTemplate.TotalStandardDays.Value.ToString & " days "

                        End If

                        If TaskTemplate.TotalStandardDays.HasValue AndAlso TaskTemplate.TotalRushDays.HasValue Then

                            If LabelTop_WorkingDaysLbl.Text <> "" Then

                                WorkingDays = CInt(LabelTop_WorkingDaysLbl.Text)

                                StandardDifference = TaskTemplate.TotalStandardDays.Value - WorkingDays

                                RushDifference = TaskTemplate.TotalRushDays.Value - WorkingDays

                                If StandardDifference < 0 Then

                                    StandardDifference = StandardDifference * -1

                                End If

                                If RushDifference < 0 Then

                                    RushDifference = RushDifference * -1

                                End If

                                If RushDifference < StandardDifference Then

                                    RushText &= "(Recommended)"

                                Else

                                    StandardText &= "(Recommended)"

                                End If

                            End If

                        End If

                    End If

                Else

                    RushText = "Rush"
                    StandardText = "Standard"

                End If

                RadioButtonControlTemplates_Rush.Text = RushText
                RadioButtonControlTemplates_Standard.Text = StandardText

            End Using

            DataGridViewTemplates_Tasks.CurrentView.BestFitColumns()

        End Sub
        Private Sub ArrageTemplateTaskColumns()

            'objects
            Dim VisibleIndex As Integer = 0

            For Each GridColumn In DataGridViewTasks_Tasks.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                GridColumn.Visible = False
                GridColumn.VisibleIndex = -1

            Next

            HideOrShowTemplateTaskColumn("Quantity", False, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.PhaseDescription.ToString, True, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.TaskCode.ToString, True, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.TaskDescription.ToString, True, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.ProcessOrderNumber.ToString, True, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.DaysToComplete.ToString, RadioButtonControlTemplates_Standard.Checked, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.RushDaysToComplete.ToString, RadioButtonControlTemplates_Rush.Checked, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.HoursAllowed.ToString, RadioButtonControlTemplates_Standard.Checked, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.RushHoursToComplete.ToString, RadioButtonControlTemplates_Rush.Checked, VisibleIndex)
            HideOrShowTemplateTaskColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.IsMilestone.ToString, True, VisibleIndex)

            DataGridViewTemplates_Tasks.CurrentView.BestFitColumns()

        End Sub
        Private Sub HideOrShowTemplateTaskColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer)

            If DataGridViewTemplates_Tasks.Columns(FieldName) IsNot Nothing Then

                If Visible Then

                    DataGridViewTemplates_Tasks.Columns(FieldName).VisibleIndex = VisibleIndex
                    DataGridViewTemplates_Tasks.Columns(FieldName).Visible = True
                    VisibleIndex = VisibleIndex + 1

                Else

                    DataGridViewTemplates_Tasks.Columns(FieldName).Visible = False

                End If

            End If

        End Sub
        Private Sub ArrageEstimateTaskColumns()

            'objects
            Dim VisibleIndex As Integer = 0

            For Each GridColumn In DataGridViewEstimate_Tasks.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                GridColumn.Visible = False
                GridColumn.VisibleIndex = -1

            Next

            HideOrShowEstimateTaskColumn(AdvantageFramework.Database.Classes.EstimateTask.Properties.TaskCode.ToString, True, VisibleIndex)
            HideOrShowEstimateTaskColumn(AdvantageFramework.Database.Classes.EstimateTask.Properties.TaskDescription.ToString, True, VisibleIndex)
            HideOrShowEstimateTaskColumn(AdvantageFramework.Database.Classes.EstimateTask.Properties.EmployeeCode.ToString, CheckBoxEstimate_IncludeEmployees.Checked, VisibleIndex)
            HideOrShowEstimateTaskColumn(AdvantageFramework.Database.Classes.EstimateTask.Properties.EmployeeName.ToString, CheckBoxEstimate_IncludeEmployees.Checked, VisibleIndex)
            HideOrShowEstimateTaskColumn(AdvantageFramework.Database.Classes.EstimateTask.Properties.HoursAllowed.ToString, CheckBoxEstimate_IncludeHours.Checked, VisibleIndex)

            DataGridViewEstimate_Tasks.CurrentView.BestFitColumns()

        End Sub
        Private Sub HideOrShowEstimateTaskColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer)

            If DataGridViewEstimate_Tasks.Columns(FieldName) IsNot Nothing Then

                If Visible Then

                    DataGridViewEstimate_Tasks.Columns(FieldName).VisibleIndex = VisibleIndex
                    DataGridViewEstimate_Tasks.Columns(FieldName).Visible = True
                    VisibleIndex = VisibleIndex + 1

                Else

                    DataGridViewEstimate_Tasks.Columns(FieldName).Visible = False

                End If

            End If

        End Sub
        Private Function LoadSyncWithOutlook() As Boolean

            'objects
            Dim SyncWithOutlook As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)

                Catch ex As Exception
                    SyncWithOutlook = False
                End Try

            End Using

            LoadSyncWithOutlook = SyncWithOutlook

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal FormType As ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, Optional ByVal DueDate As Date = Nothing) As Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleTaskSelectionDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog = Nothing

            ProjectScheduleTaskSelectionDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog(FormType, JobNumber, JobComponentNumber, DueDate)

            ShowFormDialog = ProjectScheduleTaskSelectionDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleTaskSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim DayCounter As Integer = 0

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemTemplates_Add.Image = AdvantageFramework.My.Resources.TemplateAdd
            RadioButtonControlTemplates_Standard.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobComponentNumber)

                If JobComponent IsNot Nothing Then

                    If (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                        Where Entity.JobNumber = JobComponent.JobNumber AndAlso
                              Entity.JobComponentNumber = JobComponent.Number
                        Select Entity).Any = False Then

                        TabItemTasks_EstimatesTab.Visible = False

                    End If

                    LabelTop_WorkingDaysLbl.Text = ""
                    LabelTop_JobDueDateLbl.Text = ""

                    If _DueDate <> Nothing Then

                        LabelTop_JobDueDateLbl.Text = _DueDate.ToShortDateString

                        For DayNumber = 0 To _DueDate.Subtract(System.DateTime.Now).Days + 1

                            If System.DateTime.Now.AddDays(DayNumber).DayOfWeek <> DayOfWeek.Saturday AndAlso System.DateTime.Now.AddDays(DayNumber).DayOfWeek <> DayOfWeek.Sunday Then

                                DayCounter = DayCounter + 1

                            End If

                        Next

                        LabelTop_WorkingDaysLbl.Text = DayCounter.ToString

                    End If

                    If _FormType = FormTypes.Estimates Then

                        If TabItemTasks_EstimatesTab.Visible = False Then

                            _FormType = FormTypes.Tasks

                        End If

                    End If

                    Select Case _FormType

                        Case FormTypes.Templates

                            TabControlForm_Tasks.SelectedTab = TabItemTasks_TaskTemplatesTab

                        Case FormTypes.Tasks

                            TabControlForm_Tasks.SelectedTab = TabItemTasks_AvailableTasksTab

                        Case FormTypes.Estimates

                            TabControlForm_Tasks.SelectedTab = TabItemTasks_EstimatesTab

                    End Select

                    LoadDetails(Nothing)

                Else

                    Loaded = False

                End If

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("Error loading job information!")
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

#Region "  Tasks Tab "

        Private Sub DataGridViewTasks_Tasks_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTasks_Tasks.DataSourceChangedEvent

            If DataGridViewTasks_Tasks.Columns.Count > 0 Then

                DataGridViewTasks_Tasks.HideOrShowColumn("Quantity", True)
                DataGridViewTasks_Tasks.HideOrShowColumn(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.PhaseDescription.ToString, False)

                For Each GridColumn In DataGridViewEstimate_Tasks.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.EstimateTask.Properties.HoursAllowed.ToString Then

                        GridColumn.OptionsColumn.AllowEdit = True

                    Else

                        GridColumn.OptionsColumn.AllowEdit = False

                    End If

                Next

            End If

        End Sub

#End Region

#Region "  Templates Tab "

        Private Sub DataGridViewTemplates_Tasks_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewTemplates_Tasks.CustomDrawGroupRowEvent

            'objects
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim TaskTemplateDescription As String = Nothing

            Try

                GridGroupRowInfo = e.Info

            Catch ex As Exception

            End Try

            If GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.IsGroupRow Then

                    If GridGroupRowInfo.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.TaskTemplateCode.ToString Then

                        If GridGroupRowInfo.EditValue IsNot Nothing Then

                            For Each SelectedRowHandle In DataGridViewTemplates_TaskTemplates.CurrentView.GetSelectedRows

                                If DataGridViewTemplates_TaskTemplates.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.TaskTemplate.Properties.Code.ToString) = GridGroupRowInfo.EditValue Then

                                    TaskTemplateDescription = DataGridViewTemplates_TaskTemplates.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Entities.TaskTemplate.Properties.Description.ToString)

                                    Exit For

                                End If

                            Next

                            GridGroupRowInfo.GroupText = "Template: " & TaskTemplateDescription

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewTemplates_Tasks_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTemplates_Tasks.DataSourceChangedEvent

            'objects
            Dim GroupByTemplate As Boolean = False

            If DataGridViewTemplates_Tasks.Columns.Count > 0 Then

                ArrageTemplateTaskColumns()

                If DataGridViewTemplates_Tasks.HasRows Then

                    If DataGridViewTemplates_TaskTemplates.HasRows Then

                        If DataGridViewTemplates_TaskTemplates.CurrentView.SelectedRowsCount > 1 Then

                            GroupByTemplate = True

                        End If

                    End If

                End If

                If GroupByTemplate Then

                    DataGridViewTemplates_Tasks.Columns(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.TaskTemplateCode.ToString).Group()
                    DataGridViewTemplates_Tasks.CurrentView.ExpandAllGroups()

                Else

                    DataGridViewTemplates_Tasks.Columns(AdvantageFramework.ProjectSchedule.Classes.TaskDetail.Properties.TaskTemplateCode.ToString).UnGroup()

                End If

            End If

        End Sub
        Private Sub DataGridViewTemplates_TaskTemplates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTemplates_TaskTemplates.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadTaskTemplateTasks()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonControlTemplates_Rush_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlTemplates_Rush.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If RadioButtonControlTemplates_Rush.Checked Then

                    ArrageTemplateTaskColumns()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlTemplates_Rush_TextChanged(sender As Object, e As EventArgs) Handles RadioButtonControlTemplates_Rush.TextChanged

            If String.IsNullOrEmpty(RadioButtonControlTemplates_Standard.Text) = False Then

                RadioButtonControlTemplates_Rush.Width = System.Windows.Forms.TextRenderer.MeasureText(RadioButtonControlTemplates_Rush.Text, RadioButtonControlTemplates_Rush.Font, System.Drawing.Size.Empty, Windows.Forms.TextFormatFlags.Left).Width + 25

            End If

        End Sub
        Private Sub RadioButtonControlTemplates_Standard_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlTemplates_Standard.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If RadioButtonControlTemplates_Standard.Checked Then

                    ArrageTemplateTaskColumns()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlTemplates_Standard_TextChanged(sender As Object, e As EventArgs) Handles RadioButtonControlTemplates_Standard.TextChanged

            If String.IsNullOrEmpty(RadioButtonControlTemplates_Standard.Text) = False Then

                RadioButtonControlTemplates_Standard.Width = System.Windows.Forms.TextRenderer.MeasureText(RadioButtonControlTemplates_Standard.Text, RadioButtonControlTemplates_Standard.Font, System.Drawing.Size.Empty, Windows.Forms.TextFormatFlags.Left).Width + 25
                RadioButtonControlTemplates_Rush.Location = New System.Drawing.Point(RadioButtonControlTemplates_Standard.Location.X + RadioButtonControlTemplates_Standard.Size.Width + 6, RadioButtonControlTemplates_Standard.Location.Y)

            End If

        End Sub

#End Region

#Region "  Estimates Tab "

        Private Sub DataGridViewEstimate_Tasks_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEstimate_Tasks.DataSourceChangedEvent

            If DataGridViewEstimate_Tasks.Columns.Count > 0 Then

                ArrageEstimateTaskColumns()

            End If

        End Sub
        Private Sub CheckBoxEstimate_IncludeEmployees_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxEstimate_IncludeEmployees.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                ArrageEstimateTaskColumns()

            End If

        End Sub
        Private Sub CheckBoxEstimate_IncludeHours_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxEstimate_IncludeHours.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                ArrageEstimateTaskColumns()

            End If

        End Sub

#End Region

        Private Sub ButtonItemOptions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim AnyAdded As Boolean = False
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                If TabControlForm_Tasks.SelectedTab Is TabItemTasks_AvailableTasksTab Then

                    AnyAdded = AvailableTasks_Add(ErrorMessage)

                ElseIf TabControlForm_Tasks.SelectedTab Is TabItemTasks_TaskTemplatesTab Then

                    AnyAdded = TemplateTasks_Add(ErrorMessage)

                ElseIf TabControlForm_Tasks.SelectedTab Is TabItemTasks_EstimatesTab Then

                    AnyAdded = EstimateTasks_Add(ErrorMessage)

                End If

                If AnyAdded = True Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    If String.IsNullOrEmpty(ErrorMessage) Then

                        ErrorMessage = "No tasks were added!"

                    End If

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemSystem_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemTemplates_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplates_Add.Click

            'objects
            Dim TaskTemplateCode As String = ""

            If AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateEditDialog.ShowFormDialog(TaskTemplateCode) = Windows.Forms.DialogResult.OK Then

                AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateEditDialog.ShowFormDialog(TaskTemplateCode)

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                TabItemTasks_TaskTemplatesTab.Tag = False

                TabControlForm_Tasks.SelectedTab = TabItemTasks_TaskTemplatesTab

                LoadDetails(TabItemTasks_TaskTemplatesTab)

                DataGridViewTemplates_TaskTemplates.SelectRow(TaskTemplateCode)

                Me.FormAction = WinForm.Presentation.FormActions.None

                DataGridViewTemplates_TaskTemplates.GridViewSelectionChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TabControlForm_Tasks_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_Tasks.SelectedTabChanging

            If Me.FormShown Then

                If Me.FormAction = WinForm.Presentation.FormActions.None Then

                    LoadDetails(e.NewTab)

                End If

            End If

        End Sub

#End Region

#Region " Add Methods "

        Private Function AvailableTasks_Add(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim AnyAdded As Boolean = False
            Dim Quantity As Integer = Nothing
            Dim SyncWithOutlook As Boolean = False
            Dim TaskDetail As AdvantageFramework.ProjectSchedule.Classes.TaskDetail = Nothing
            Dim SelectedRowsRowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            Try

                If DataGridViewTasks_Tasks.HasASelectedRow Then

                    SyncWithOutlook = LoadSyncWithOutlook()

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        SelectedRowsRowHandlesAndDataBoundItems = DataGridViewTasks_Tasks.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        For Each SelectedRowsRowHandlesAndDataBoundItem In SelectedRowsRowHandlesAndDataBoundItems

                            Try

                                TaskDetail = SelectedRowsRowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                TaskDetail = Nothing
                            End Try

                            If TaskDetail IsNot Nothing Then

                                Try

                                    Quantity = CInt(DataGridViewTasks_Tasks.CurrentView.GetRowCellValue(SelectedRowsRowHandlesAndDataBoundItem.Key, "Quantity"))

                                Catch ex As Exception
                                    Quantity = 0
                                End Try

                                For Item = 1 To Quantity

                                    If AdvantageFramework.ProjectSchedule.AddTaskToSchedule(DbContext, TaskDetail, _JobNumber, _JobComponentNumber, False, SyncWithOutlook) Then

                                        AnyAdded = True

                                    End If

                                Next

                            End If

                        Next

                    End Using

                Else

                    ErrorMessage = "Please select at least one task."

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem adding the selected task(s). Please contact software support."
            End Try

            AvailableTasks_Add = AnyAdded

        End Function
        Private Function TemplateTasks_Add(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim AnyAdded As Boolean = False
            Dim Quantity As Integer = Nothing
            Dim SyncWithOutlook As Boolean = False
            Dim TaskDetail As AdvantageFramework.ProjectSchedule.Classes.TaskDetail = Nothing
            Dim SelectedRowsRowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            Try

                If DataGridViewTemplates_Tasks.HasASelectedRow Then

                    SyncWithOutlook = LoadSyncWithOutlook()

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        SelectedRowsRowHandlesAndDataBoundItems = DataGridViewTemplates_Tasks.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        For Each SelectedRowsRowHandlesAndDataBoundItem In SelectedRowsRowHandlesAndDataBoundItems

                            Try

                                TaskDetail = SelectedRowsRowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                TaskDetail = Nothing
                            End Try

                            If TaskDetail IsNot Nothing Then

                                If AdvantageFramework.ProjectSchedule.AddTaskToSchedule(DbContext, TaskDetail, _JobNumber, _JobComponentNumber, RadioButtonControlTemplates_Rush.Checked, SyncWithOutlook) Then

                                    AnyAdded = True

                                End If

                            End If

                        Next

                    End Using

                Else

                    ErrorMessage = "Please select at least one task."

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem adding the selected task(s). Please contact software support."
            End Try

            TemplateTasks_Add = AnyAdded

        End Function
        Private Function EstimateTasks_Add(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim AnyAdded As Boolean = False
            Dim SyncWithOutlook As Boolean = False

            Try

                If DataGridViewEstimate_Tasks.HasASelectedRow Then

                    SyncWithOutlook = LoadSyncWithOutlook()

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each EstimateTask In DataGridViewEstimate_Tasks.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EstimateTask)()

                            If AdvantageFramework.ProjectSchedule.AddTaskToSchedule(DbContext, EstimateTask, _JobNumber, _JobComponentNumber, CheckBoxEstimate_IncludeEmployees.Checked, CheckBoxEstimate_IncludeHours.Checked, SyncWithOutlook) Then

                                AnyAdded = True

                            End If

                        Next

                    End Using

                Else

                    ErrorMessage = "Please select at least one task."

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem adding the selected task(s). Please contact software support."
            End Try

            EstimateTasks_Add = AnyAdded

        End Function

#End Region

#End Region

    End Class

End Namespace