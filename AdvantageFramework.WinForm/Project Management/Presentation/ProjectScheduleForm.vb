Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleForm

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum ScheduleViewLayout
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "By Project Schedule")>
            ByProjectSchedule = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "My Project Tasks")>
            ByProjectTasks = 1
        End Enum

#End Region

#Region " Variables "

        Private _LoadCounter As Short = 0
        Private _LastSearchedPhase As Integer? = Nothing
        Private _LastSearchedRole As String = Nothing
        Private _LastSearchedTask As String = Nothing
        Private _LastSearchedEmployee As String = Nothing
        Private _LastSearchedDateCutoff As Date? = Nothing
        Private _LastSearchedOnlyPendingTasks As Boolean? = Nothing
        Private _LastSearchedExcludeProjectedTasks As Boolean? = Nothing
        Private _LastSearchedIncludeCompletedTasks As Boolean? = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ItemContainerActions_SearchBy.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            ItemContainerTasks_Add.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            ItemContainerTasks_Tasks.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            DataGridViewRightSection_MutliView.AllowExtraItemsInGridLookupEdits = False
            DataGridViewLeftSection_JobTraffic.MultiSelect = True
            DataGridViewRightSection_MutliView.Visible = False

        End Sub
        Private Function LoadGrid(ByVal SetInitialSearchCriteria As Boolean) As Boolean

            Dim PhaseID As Object = Nothing
            Dim RoleCode As Object = Nothing
            Dim TaskCode As Object = Nothing
            Dim EmployeeCode As Object = Nothing
            Dim DateCutoff As Object = Nothing
            Dim OnlyPendingTasks As Object = Nothing
            Dim ExcludeProjectedTasks As Object = Nothing
            Dim IncludeCompletedTasks As Object = Nothing
            Dim CancelLoad As Boolean = False

            If ComboBoxItemActions_SearchBy.SelectedIndex = 1 Then

                If SetInitialSearchCriteria Then

                    If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleInitialLoadingDialog.ShowFormDialog(PhaseID, RoleCode, TaskCode, EmployeeCode, DateCutoff, OnlyPendingTasks, ExcludeProjectedTasks, IncludeCompletedTasks) = Windows.Forms.DialogResult.OK Then

                        _LastSearchedPhase = PhaseID
                        _LastSearchedRole = RoleCode
                        _LastSearchedTask = TaskCode
                        _LastSearchedEmployee = EmployeeCode
                        _LastSearchedDateCutoff = DateCutoff
                        _LastSearchedOnlyPendingTasks = OnlyPendingTasks
                        _LastSearchedExcludeProjectedTasks = ExcludeProjectedTasks
                        _LastSearchedIncludeCompletedTasks = IncludeCompletedTasks

                    Else

                        CancelLoad = True

                    End If

                End If

            Else

                _LastSearchedPhase = Nothing
                _LastSearchedRole = Nothing
                _LastSearchedTask = Nothing
                _LastSearchedEmployee = Nothing
                _LastSearchedDateCutoff = Nothing
                _LastSearchedOnlyPendingTasks = Nothing
                _LastSearchedExcludeProjectedTasks = Nothing
                _LastSearchedIncludeCompletedTasks = True

            End If

            If CancelLoad = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_JobTraffic.ItemDescription = "Project Schedule(s)"

                    If _LastSearchedPhase.HasValue Then

                        If _LastSearchedPhase.Value < -1 Then

                            _LastSearchedPhase = Nothing

                        End If

                    End If

                    PhaseID = _LastSearchedPhase
                    RoleCode = _LastSearchedRole
                    TaskCode = _LastSearchedTask
                    EmployeeCode = _LastSearchedEmployee
                    DateCutoff = _LastSearchedDateCutoff
                    OnlyPendingTasks = _LastSearchedOnlyPendingTasks
                    ExcludeProjectedTasks = _LastSearchedExcludeProjectedTasks
                    IncludeCompletedTasks = _LastSearchedIncludeCompletedTasks

                    DataGridViewLeftSection_JobTraffic.DataSource = From Entity In AdvantageFramework.Database.Procedures.ScheduleHeaderComplex.Load(DbContext, Me.Session.UserCode, PhaseID,
                                                                                                                                                     RoleCode, TaskCode, EmployeeCode, OnlyPendingTasks,
                                                                                                                                                     ExcludeProjectedTasks, IncludeCompletedTasks, True, DateCutoff)
                                                                    Order By Entity.JobNumber Descending, Entity.JobComponentNumber Ascending
                                                                    Select Entity


                End Using

            End If

            DataGridViewLeftSection_JobTraffic.CurrentView.BestFitColumns()

            LoadGrid = Not CancelLoad

        End Function
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                ProjectScheduleControlRightSection_ProjectSchedule.ClearControl()

                ProjectScheduleControlRightSection_ProjectSchedule.Enabled = DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow

                If ProjectScheduleControlRightSection_ProjectSchedule.Enabled Then

                    ProjectScheduleControlRightSection_ProjectSchedule.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.LoadControl(DataGridViewLeftSection_JobTraffic.GetFirstSelectedRowBookmarkValue, False)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub LoadSelectedItems()

            'objects
            Dim ScheduleHeaders As Generic.List(Of AdvantageFramework.Database.Entities.ScheduleHeader) = Nothing
            Dim ScheduleIDs As Integer() = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    ScheduleIDs = DataGridViewLeftSection_JobTraffic.GetAllSelectedRowsBookmarkValues.OfType(Of Integer)().ToArray

                    DataGridViewRightSection_MutliView.DataSource = From Entity In AdvantageFramework.Database.Procedures.ScheduleHeaderComplex.Load(DbContext, Me.Session.UserCode)
                                                                    Where ScheduleIDs.Contains(Entity.ScheduleID)
                                                                    Select Entity

                Catch ex As Exception

                End Try

                DataGridViewRightSection_MutliView.CurrentView.BestFitColumns()

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions(Optional ByVal IsResetting As Boolean = False)

            If IsResetting = False Then

                ProjectScheduleControlRightSection_ProjectSchedule.Enabled = (DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow AndAlso Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None)

            End If

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If DataGridViewLeftSection_JobTraffic.HasASelectedRow Then

                If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                    ProjectScheduleControlRightSection_ProjectSchedule.Visible = True
                    DataGridViewRightSection_MutliView.Visible = False

                    EnableOrDisableActions_SingleProjectSchedule()

                Else

                    ProjectScheduleControlRightSection_ProjectSchedule.Visible = False
                    DataGridViewRightSection_MutliView.Visible = True

                    EnableOrDisableActions_MultiView()

                End If

            Else

                ButtonItemActions_Save.Enabled = False

            End If

            ResetRibbonBar(RibbonBarOptions_Actions)
            ResetRibbonBar(RibbonBarOptions_Spelling)
            ResetRibbonBar(RibbonBarOptions_TaskOptions)

        End Sub
        Private Sub ResetRibbonBar(ByVal RibbonBar As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar)

            RibbonBar.ResetCachedContentSize()
            RibbonBar.Refresh()
            RibbonBar.Width = RibbonBar.GetAutoSizeWidth
            RibbonBar.Refresh()

        End Sub
        Private Sub EnableOrDisableActions_MultiView()

            'visiblity
            ButtonItemActions_Add.Visible = True
            ButtonItemActions_Copy.Visible = False
            ButtonItemActions_Settings.Visible = False
            RibbonBarOptions_Spelling.Visible = False
            ButtonItemTasks_Details.Visible = False
            ButtonItemTasks_Add.Visible = False
            ButtonItemTasks_AddFromTemplate.Visible = False
            ButtonItemTasks_AddFromEstimate.Visible = False
            ButtonItemTasks_AddFromSchedule.Visible = False
            ButtonItemTasks_Delete.Visible = False
            ButtonItemTasks_Team.Visible = True
            ButtonItemTasks_Employees.Visible = False
            ButtonItemTasks_TempComplete.Visible = True
            ButtonItemTasks_ClearAssignments.Visible = True
            ButtonItemTasks_Replace.Visible = True
            ButtonItemTasks_MoveDown.Visible = False
            ButtonItemTasks_MoveUp.Visible = False

            'enabled
            ButtonItemActions_Add.Visible = True
            ButtonItemTasks_Team.Enabled = DataGridViewRightSection_MutliView.HasASelectedRow
            ButtonItemTasks_TempComplete.Enabled = DataGridViewRightSection_MutliView.HasASelectedRow
            ButtonItemTasks_ClearAssignments.Enabled = DataGridViewRightSection_MutliView.HasASelectedRow
            ButtonItemTasks_Replace.Enabled = DataGridViewRightSection_MutliView.HasASelectedRow

        End Sub
        Private Sub EnableOrDisableActions_SingleProjectSchedule()

            'visiblity
            ButtonItemActions_Add.Visible = True
            ButtonItemActions_Copy.Visible = True
            ButtonItemActions_Settings.Visible = True
            RibbonBarOptions_Spelling.Visible = True
            ButtonItemTasks_Details.Visible = True
            ButtonItemTasks_Add.Visible = True
            ButtonItemTasks_AddFromTemplate.Visible = True
            ButtonItemTasks_AddFromEstimate.Visible = True
            ButtonItemTasks_AddFromSchedule.Visible = True
            ButtonItemTasks_Delete.Visible = True
            ButtonItemTasks_Team.Visible = True
            ButtonItemTasks_Employees.Visible = False
            ButtonItemTasks_TempComplete.Visible = True
            ButtonItemTasks_ClearAssignments.Visible = True
            ButtonItemTasks_Replace.Visible = True
            ButtonItemTasks_MoveDown.Visible = True
            ButtonItemTasks_MoveUp.Visible = True

            'enabled
            If ProjectScheduleControlRightSection_ProjectSchedule.Enabled Then

                ButtonItemActions_Copy.Enabled = True
                ButtonItemSpelling_CheckSpelling.Enabled = True

                ButtonItemTasks_Details.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasOnlyOneSelectedRow
                ButtonItemTasks_Add.Enabled = True
                ButtonItemTasks_AddFromSchedule.Enabled = True
                ButtonItemTasks_AddFromTemplate.Enabled = True
                ButtonItemTasks_AddFromEstimate.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.HasApprovedEstimate
                ButtonItemTasks_Delete.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasASelectedRow
                ButtonItemTasks_Calculate.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasRows
                ButtonItemTasks_Team.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasRows
                ButtonItemTasks_TempComplete.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasRows
                ButtonItemTasks_ClearAssignments.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasRows
                ButtonItemTasks_Replace.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasRows
                ButtonItemTasks_MoveUp.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasOnlyOneSelectedRow AndAlso
                                                 ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.CurrentView.IsFirstRow = False
                ButtonItemTasks_MoveDown.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasOnlyOneSelectedRow AndAlso
                                                   ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.CurrentView.IsLastRow = False
                ButtonItemTasks_Employees.Enabled = ProjectScheduleControlRightSection_ProjectSchedule.TasksDataGridView.HasOnlyOneSelectedRow

            Else

                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Copy.Enabled = False
                ButtonItemSpelling_CheckSpelling.Enabled = False

                ButtonItemTasks_Details.Enabled = False
                ButtonItemTasks_Add.Enabled = False
                ButtonItemTasks_AddFromSchedule.Enabled = False
                ButtonItemTasks_AddFromTemplate.Enabled = False
                ButtonItemTasks_AddFromEstimate.Enabled = False
                ButtonItemTasks_Delete.Enabled = False
                ButtonItemTasks_Calculate.Enabled = False
                ButtonItemTasks_Team.Enabled = False
                ButtonItemTasks_TempComplete.Enabled = False
                ButtonItemTasks_ClearAssignments.Enabled = False
                ButtonItemTasks_Replace.Enabled = False
                ButtonItemTasks_MoveUp.Enabled = False
                ButtonItemTasks_MoveDown.Enabled = False
                ButtonItemTasks_Employees.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges(ByVal ForceReloadOnFail As Boolean) As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            'IsOkay = ProjectScheduleControlRightSection_ProjectSchedule.Save()

                        Catch ex As Exception
                            IsOkay = False
                        End Try

                        If IsOkay = False AndAlso AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Would you like to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            If ForceReloadOnFail Then

                                LoadSelectedItemDetails()

                            End If

                            IsOkay = True

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                Else

                    If ForceReloadOnFail Then

                        LoadSelectedItemDetails()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False

            If ProjectScheduleControlRightSection_ProjectSchedule.Visible Then

                Saved = SaveSingleSchedule()

            ElseIf DataGridViewRightSection_MutliView.Visible Then

                Saved = SaveMultipleSchedules()

            End If

            Save = Saved

        End Function
        Private Function SaveSingleSchedule() As Boolean

            SaveSingleSchedule = False

        End Function
        Private Function SaveMultipleSchedules() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            Try

                DataGridViewRightSection_MutliView.CurrentView.CloseEditorForUpdating()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ScheduleHeaderComplex In DataGridViewRightSection_MutliView.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ScheduleHeaderComplex)()

                        JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, ScheduleHeaderComplex.JobNumber, ScheduleHeaderComplex.JobComponentNumber)

                        If JobTraffic IsNot Nothing Then

                            JobTraffic.TrafficCode = ScheduleHeaderComplex.StatusCode
                            JobTraffic.CompletedDate = ScheduleHeaderComplex.CompletedDate
                            JobTraffic.TrafficComments = ScheduleHeaderComplex.Comments
                            JobTraffic.PercentComplete = ScheduleHeaderComplex.GutPercentComplete

                            If AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, JobTraffic) Then

                                Saved = True

                            End If

                        End If

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, ScheduleHeaderComplex.JobNumber, ScheduleHeaderComplex.JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            JobComponent.StartDate = ScheduleHeaderComplex.StartDate
                            JobComponent.DueDate = ScheduleHeaderComplex.JobFirstUseDate

                            If AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent) Then

                                Saved = True

                            End If

                        End If

                    Next

                End Using

            Catch ex As Exception
                Saved = False
            Finally
                SaveMultipleSchedules = Saved
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ProjectScheduleForm As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleForm = Nothing

            ProjectScheduleForm = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleForm()

            ProjectScheduleForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim CanUserUpdate As Boolean = False
            Dim CanUserAdd As Boolean = False

            ComboBoxItemActions_SearchBy.Items.AddRange((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleForm.ScheduleViewLayout)) _
                                                         Select Entity.Description).ToArray)

            CanUserAdd = AdvantageFramework.Security.CanUserAddInModule(Me.Session, Security.Modules.ProjectManagement_ProjectSchedule)
            CanUserUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, Security.Modules.ProjectManagement_ProjectSchedule)

            ButtonItemActions_Add.SecurityEnabled = CanUserAdd
            ButtonItemActions_Copy.SecurityEnabled = CanUserAdd
            ButtonItemActions_Save.SecurityEnabled = CanUserUpdate

            ButtonItemSpelling_CheckSpelling.SecurityEnabled = CanUserUpdate

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Settings.Image = AdvantageFramework.My.Resources.MaintenanceImage

            ButtonItemSpelling_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemTasks_AddFromEstimate.ImageFixedSize = New System.Drawing.Size(16, 16)
            ButtonItemTasks_AddFromSchedule.ImageFixedSize = New System.Drawing.Size(16, 16)
            ButtonItemTasks_AddFromTemplate.ImageFixedSize = New System.Drawing.Size(16, 16)

            ButtonItemTasks_AddFromEstimate.Icon = AdvantageFramework.My.Resources.CalculatorIcon
            ButtonItemTasks_AddFromSchedule.Icon = AdvantageFramework.My.Resources.CalendarMonthIcon
            ButtonItemTasks_AddFromTemplate.Icon = AdvantageFramework.My.Resources.JobTemplateIcon
            ButtonItemTasks_Employees.Image = AdvantageFramework.My.Resources.EmployeesImage
            ButtonItemTasks_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemTasks_MoveDown.Image = AdvantageFramework.My.Resources.DownImage
            ButtonItemTasks_TempComplete.Image = AdvantageFramework.My.Resources.SmallCheckMarkImage
            ButtonItemTasks_ClearAssignments.Image = AdvantageFramework.My.Resources.SmallDeleteImage
            ButtonItemTasks_Replace.Icon = AdvantageFramework.My.Resources.ViewIcon
            ButtonItemTasks_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemTasks_Details.Image = AdvantageFramework.My.Resources.DataViewImage
            ButtonItemTasks_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemTasks_Team.Image = AdvantageFramework.My.Resources.DepartmentTeamImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ComboBoxItemActions_SearchBy.SelectedIndex = 0

            Try

                LoadGrid(False)

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_JobTraffic.CurrentView.AFActiveFilterString = "[Completed] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ProjectScheduleForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProjectScheduleForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProjectScheduleForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_JobTraffic.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

#Region "   Ribbonbar Buttons "

        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim ContinueCopy As Boolean = False
            Dim JobTrafficID As String = Nothing

            If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges(False)

                If ContinueCopy Then

                    JobTrafficID = DataGridViewLeftSection_JobTraffic.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleEditDialog.ShowFormDialog(JobTrafficID, True) = Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid(False)

                            DataGridViewLeftSection_JobTraffic.SelectRow(JobTrafficID)

                        Catch ex As Exception

                        End Try

                        DataGridViewLeftSection_JobTraffic.CurrentView.GridViewSelectionChanged()

                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a project schedule to copy.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ContinueAdd As Boolean = True
            Dim JobTrafficID As String = Nothing

            If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges(False)

            End If

            If ContinueAdd Then

                If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleEditDialog.ShowFormDialog(JobTrafficID, False) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid(False)

                        DataGridViewLeftSection_JobTraffic.SelectRow(JobTrafficID)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_JobTraffic.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_JobTraffic.HasASelectedRow Then

                If Me.Validator Then

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If Save() Then

                            Me.ClearChanged()

                            'LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_JobTraffic.FocusToFindPanel(False)

                        DataGridViewLeftSection_JobTraffic.CurrentView.GridViewSelectionChanged()

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a project schedule to save.")

            End If

        End Sub
        Private Sub ButtonItemTasks_Employees_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_Employees.Click

            ProjectScheduleControlRightSection_ProjectSchedule.PickEmployeesForTask()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_Add.Click

            ProjectScheduleControlRightSection_ProjectSchedule.AddTasks()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_AddFromTemplate_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_AddFromTemplate.Click

            ProjectScheduleControlRightSection_ProjectSchedule.AddTasksByTemplate()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_AddFromEstimate_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_AddFromEstimate.Click

            ProjectScheduleControlRightSection_ProjectSchedule.AddTasksByEstimate()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTeam_ApplyByFunction_Click(sender As Object, e As EventArgs) Handles ButtonItemTeam_ApplyByFunction.Click

            ProjectScheduleControlRightSection_ProjectSchedule.ApplyTeam(True)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTeam_ApplyByRole_Click(sender As Object, e As EventArgs) Handles ButtonItemTeam_ApplyByRole.Click

            ProjectScheduleControlRightSection_ProjectSchedule.ApplyTeam(False)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_TempComplete_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_TempComplete.Click

            ProjectScheduleControlRightSection_ProjectSchedule.MarkTempComplete()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_Delete.Click

            ProjectScheduleControlRightSection_ProjectSchedule.DeleteSelectedTasks()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_Replace_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_Replace.Click

            'objects
            Dim JobTrafficIDs As Integer() = Nothing

            If DataGridViewLeftSection_JobTraffic.HasASelectedRow Then

                If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                    ProjectScheduleControlRightSection_ProjectSchedule.FindAndReplaceInTasks()

                Else

                    JobTrafficIDs = DataGridViewLeftSection_JobTraffic.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToArray

                    If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleFindAndReplaceDialog.ShowFormDialog(JobTrafficIDs) = Windows.Forms.DialogResult.OK Then

                        LoadSelectedItems()

                    End If

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_MoveUp.Click

            ProjectScheduleControlRightSection_ProjectSchedule.MoveTask(True)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_MoveDown.Click

            ProjectScheduleControlRightSection_ProjectSchedule.MoveTask(False)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Settings.Click

            ProjectScheduleControlRightSection_ProjectSchedule.OpenSettings()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTasks_Details_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_Details.Click

            ProjectScheduleControlRightSection_ProjectSchedule.OpenTaskDetailDialog()

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxItemActions_SearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemActions_SearchBy.SelectedIndexChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If CheckForUnsavedChanges(True) Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    If LoadGrid(True) Then

                        DataGridViewLeftSection_JobTraffic.FocusToFindPanel(True)
                        ProjectScheduleControlRightSection_ProjectSchedule.ClearControl()
                        ProjectScheduleControlRightSection_ProjectSchedule.Enabled = False

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    EnableOrDisableActions(True)

                End If

            End If

        End Sub
        Private Sub ButtonItemTasks_ClearAssignments_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_ClearAssignments.Click

            'objects
            Dim ContinueClear As Boolean = False
            Dim JobTrafficID As String = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                ContinueClear = CheckForUnsavedChanges(False)

                If ContinueClear Then

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If ProjectScheduleControlRightSection_ProjectSchedule.ClearEmployeeAssignments() Then

                            Me.ClearChanged()

                            'LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_JobTraffic.FocusToFindPanel(False)

                        DataGridViewLeftSection_JobTraffic.CurrentView.GridViewSelectionChanged()

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a project schedule.")

            End If

        End Sub
        Private Sub ButtonItemTasks_Calculate_Click(sender As Object, e As EventArgs) Handles ButtonItemTasks_Calculate.Click

            'objects
            Dim ContinueCalculate As Boolean = False
            Dim JobTrafficID As String = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                ContinueCalculate = CheckForUnsavedChanges(False)

                If ContinueCalculate Then

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If ProjectScheduleControlRightSection_ProjectSchedule.CalculateDueDates() Then

                            Me.ClearChanged()

                            'LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_JobTraffic.FocusToFindPanel(False)

                        DataGridViewLeftSection_JobTraffic.CurrentView.GridViewSelectionChanged()

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a project schedule.")

            End If

        End Sub

#End Region

#Region "   Project Schedule Control Events "

        Private Sub ProjectScheduleControlRightSection_ProjectSchedule_SelectedDetailChangedEvent() Handles ProjectScheduleControlRightSection_ProjectSchedule.SelectedDetailChangedEvent

            EnableOrDisableActions(False)

        End Sub

#End Region

#Region "   Grids "

        Private Sub DataGridViewLeftSection_JobTraffic_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_JobTraffic.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If DataGridViewLeftSection_JobTraffic.Columns.Count > 0 Then

                DataGridViewLeftSection_JobTraffic.HideOrShowColumn(AdvantageFramework.Database.Views.JobComponentView.Properties.IsOpen.ToString, False)

                If DataGridViewLeftSection_JobTraffic.Columns("Completed") IsNot Nothing Then

                    GridColumn = DataGridViewLeftSection_JobTraffic.Columns("Completed")

                    If GridColumn.ColumnEdit Is Nothing Then

                        RepositoryItemCheckEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

                        DataGridViewLeftSection_JobTraffic.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

                        GridColumn.ColumnEdit = RepositoryItemCheckEdit

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobTraffic_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_JobTraffic.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges(False)

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobTraffic_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_JobTraffic.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                    LoadSelectedItemDetails()

                Else

                    LoadSelectedItems()

                End If

                Me.CloseWaitForm()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewRightSection_MutliView_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_MutliView.DataSourceChangedEvent

            'objects
            Dim VisibleIndex As Integer = 0

            If DataGridViewRightSection_MutliView.Columns.Count > 0 Then

                DataGridViewRightSection_MutliView.HideAllColumns()

                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.OfficeCode.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.OfficeName.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.ClientCode.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.ClientName.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.DivisionCode.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.DivisionName.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.ProductCode.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.ProductDescription.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.JobNumber.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.JobDescription.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.JobComponentNumber.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.JobComponentDescription.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.AccountExecutiveEmployeeCode.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.AccountExecutiveEmployeeName.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.StatusCode.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.StartDate.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.JobFirstUseDate.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.CompletedDate.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.GutPercentComplete.ToString, True, VisibleIndex)
                DataGridViewRightSection_MutliView.HideOrShowColumn(AdvantageFramework.Database.Classes.ScheduleHeaderComplex.Properties.Comments.ToString, True, VisibleIndex)

            End If

        End Sub

#End Region

#End Region

#End Region
        
        
        Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

            'objects
            Dim JobTrafficID As Integer = Nothing

            If DataGridViewLeftSection_JobTraffic.HasOnlyOneSelectedRow Then

                JobTrafficID = DataGridViewLeftSection_JobTraffic.GetFirstSelectedRowBookmarkValue

                If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleGanttViewDialog2.ShowFormDialog(JobTrafficID) = Windows.Forms.DialogResult.OK Then



                End If

            End If

        End Sub

    End Class

End Namespace