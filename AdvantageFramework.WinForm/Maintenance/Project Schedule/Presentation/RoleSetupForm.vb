Namespace Maintenance.ProjectSchedule.Presentation

    Public Class RoleSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid(ByVal ShowInactive As Boolean, Optional ByVal ComboBoxOnly As Boolean = False)

            'objects
            Dim Roles As IEnumerable(Of AdvantageFramework.Database.Entities.Role) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Roles = (From Role In AdvantageFramework.Database.Procedures.Role.Load(DbContext)
                         Select Role
                         Order By Role.Code).ToList

                If ComboBoxOnly = False Then

                    DataGridViewRoles_Role.DataSource = Roles

                    DataGridViewRoles_Role.CurrentView.BestFitColumns()

                End If

                If ShowInactive Then

                    Roles = (From Role In AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                             Select Role
                             Order By Role.Code).ToList

                End If

                SearchableComboBoxRoleDetails_Roles.DataSource = Roles.OrderBy(Function(Role) Role.Description)

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim RoleCode As String = ""
            Dim AvailableEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EmployeeRolesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRole) = Nothing
            Dim EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim AvailableTasksList As Generic.List(Of AdvantageFramework.Database.Entities.Task) = Nothing
            Dim TaskRolesList As Generic.List(Of AdvantageFramework.Database.Entities.TaskRole) = Nothing
            Dim TasksList As Generic.List(Of AdvantageFramework.Database.Entities.Task) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing
            Dim UserEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            EmployeesList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
            AvailableEmployeesList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

            TasksList = New Generic.List(Of AdvantageFramework.Database.Entities.Task)
            AvailableTasksList = New Generic.List(Of AdvantageFramework.Database.Entities.Task)

            If SearchableComboBoxRoleDetails_Roles.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            RoleCode = SearchableComboBoxRoleDetails_Roles.GetSelectedValue

                            EmployeeRolesList = AdvantageFramework.Database.Procedures.EmployeeRole.LoadByRoleCode(DbContext, RoleCode).ToList
                            UserEmployeesList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                            For Each Employee In (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Include("Office")
                                                  Select Entity
                                                  Order By Entity.FirstName,
                                                           Entity.MiddleInitial,
                                                           Entity.LastName).ToList

                                If (From EmployeeRole In EmployeeRolesList
                                    Where EmployeeRole.EmployeeCode = Employee.Code
                                    Select EmployeeRole).Any Then

                                    If Employee.TerminationDate Is Nothing Then

                                        EmployeesList.Add(Employee)

                                    Else

                                        Employee.LastName &= "*"

                                        EmployeesList.Add(Employee)

                                    End If

                                Else

                                    If Employee.TerminationDate Is Nothing Then

                                        If (From UserEmployee In UserEmployeesList
                                            Where UserEmployee.Code = Employee.Code
                                            Select UserEmployee).Any Then

                                            AvailableEmployeesList.Add(Employee)

                                        End If

                                    End If

                                End If

                            Next

                            TaskRolesList = AdvantageFramework.Database.Procedures.TaskRole.LoadByRoleCode(DataContext, RoleCode).ToList

                            For Each Task In (From Entity In AdvantageFramework.Database.Procedures.Task.Load(DbContext)
                                              Select Entity
                                              Order By Entity.Description).ToList

                                If (From TaskRole In TaskRolesList.AsQueryable
                                    Where TaskRole.TaskCode = Task.Code
                                    Select TaskRole).Any Then

                                    If Task.IsInactive.GetValueOrDefault(0) = 0 Then

                                        TasksList.Add(Task)

                                    Else

                                        Task.Description &= "*"

                                        TasksList.Add(Task)

                                    End If

                                Else

                                    If Task.IsInactive.GetValueOrDefault(0) = 0 Then

                                        AvailableTasksList.Add(Task)

                                    End If

                                End If

                            Next

                        End Using

                    End Using

                End Using

            End If

            DataGridViewRoleDetails_AvailableTasks.DataSource = AvailableTasksList
            DataGridViewRoleDetails_SelectedTasks.DataSource = TasksList

            DataGridViewRoleDetails_AvailableEmployees.DataSource = AvailableEmployeesList
            DataGridViewRoleDetails_SelectedEmployees.DataSource = EmployeesList

            DataGridViewRoleDetails_AvailableTasks.CurrentView.BestFitColumns()
            DataGridViewRoleDetails_SelectedTasks.CurrentView.BestFitColumns()

            DataGridViewRoleDetails_AvailableEmployees.CurrentView.BestFitColumns()
            DataGridViewRoleDetails_SelectedEmployees.CurrentView.BestFitColumns()

            UpdateTaskButtons()
            UpdateEmployeeButtons()

            ButtonItemExport_CurrentView.Enabled = SearchableComboBoxRoleDetails_Roles.HasASelectedValue

        End Sub
        Private Sub UpdateTaskButtons()

            ButtonRoleDetails_AddTasks.Enabled = DataGridViewRoleDetails_AvailableTasks.HasRows
            ButtonRoleDetails_AddAllTasks.Enabled = DataGridViewRoleDetails_AvailableTasks.HasRows
            ButtonRoleDetails_RemoveTasks.Enabled = DataGridViewRoleDetails_SelectedTasks.HasRows
            ButtonRoleDetails_RemoveAllTasks.Enabled = DataGridViewRoleDetails_SelectedTasks.HasRows

        End Sub
        Private Sub UpdateEmployeeButtons()

            ButtonRoleDetails_AddEmployees.Enabled = DataGridViewRoleDetails_AvailableEmployees.HasRows
            ButtonRoleDetails_AddAllEmployees.Enabled = DataGridViewRoleDetails_AvailableEmployees.HasRows
            ButtonRoleDetails_RemoveEmployees.Enabled = DataGridViewRoleDetails_SelectedEmployees.HasRows
            ButtonRoleDetails_RemoveAllEmployees.Enabled = DataGridViewRoleDetails_SelectedEmployees.HasRows

        End Sub
        Private Sub AddSelectedTasks(ByVal SelectedTasks As IEnumerable)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each SelectedTask In SelectedTasks

                        AdvantageFramework.Database.Procedures.TaskRole.Insert(DataContext, DbContext, SelectedTask.Code, SearchableComboBoxRoleDetails_Roles.GetSelectedValue, Nothing)

                    Next

                End Using

            End Using

        End Sub
        Private Sub RemoveSelectedTasks(ByVal SelectedTasks As IEnumerable)

            'objects
            Dim TaskRole As AdvantageFramework.Database.Entities.TaskRole = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each SelectedTask In SelectedTasks

                    TaskRole = AdvantageFramework.Database.Procedures.TaskRole.LoadByTaskCodeAndRoleCode(DataContext, SelectedTask.Code, SearchableComboBoxRoleDetails_Roles.GetSelectedValue)

                    If TaskRole IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.TaskRole.Delete(DataContext, TaskRole)

                    End If

                Next

            End Using

        End Sub
        Private Sub AddSelectedEmployees(ByRef SelectedEmployees As IEnumerable)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each SelectedEmployee In SelectedEmployees

                    AdvantageFramework.Database.Procedures.EmployeeRole.Insert(DbContext, SelectedEmployee.Code, SearchableComboBoxRoleDetails_Roles.GetSelectedValue, Nothing)

                Next

            End Using

        End Sub
        Private Sub RemoveSelectedEmployees(ByRef SelectedEmployees As IEnumerable)

            'objects
            Dim EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each SelectedEmployee In SelectedEmployees

                    EmployeeRole = AdvantageFramework.Database.Procedures.EmployeeRole.LoadByEmployeeCodeAndRoleCode(DbContext, SelectedEmployee.Code, SearchableComboBoxRoleDetails_Roles.GetSelectedValue)

                    If EmployeeRole IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.EmployeeRole.Delete(DbContext, EmployeeRole)

                    End If

                Next

            End Using

        End Sub
        Private Sub ExportRoleDetails(ByVal AllRoles As Boolean)

            'objects
            Dim DataTable As DataTable = Nothing
            Dim Role As AdvantageFramework.Database.Entities.Role = Nothing
            Dim RolesList As Generic.List(Of AdvantageFramework.Database.Entities.Role) = Nothing
            Dim NewDataRow As DataRow = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataTable = New DataTable

                DataTable.Columns.Add("Task/Employee")
                DataTable.Columns.Add("Code")
                DataTable.Columns.Add("Description/Name")

                If AllRoles Then

                    If ButtonItemActions_Inactive.Checked Then

                        RolesList = AdvantageFramework.Database.Procedures.Role.Load(DbContext).ToList

                    Else

                        RolesList = AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext).ToList

                    End If

                    For Each Role In RolesList

                        CreateExportRoleDetails(DataTable, Role)

                        NewDataRow = DataTable.Rows.Add()

                        NewDataRow(0) = ""
                        NewDataRow(1) = ""
                        NewDataRow(2) = ""

                    Next

                Else

                    If SearchableComboBoxRoleDetails_Roles.HasASelectedValue Then

                        Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, SearchableComboBoxRoleDetails_Roles.GetSelectedValue)

                        CreateExportRoleDetails(DataTable, Role)

                    End If

                End If

                DataGridViewForm_RoleDetailsExport.ItemDescription = ""
                DataGridViewForm_RoleDetailsExport.CurrentView.ViewCaption = ""
                DataGridViewForm_RoleDetailsExport.CurrentView.ViewCaptionHeight = 0
                DataGridViewForm_RoleDetailsExport.CurrentView.OptionsView.ShowViewCaption = False

                DataGridViewForm_RoleDetailsExport.DataSource = DataTable

                DataGridViewForm_RoleDetailsExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub CreateExportRoleDetails(ByRef DataTable As DataTable, ByVal Role As AdvantageFramework.Database.Entities.Role)

            'objects
            Dim NewDataRow As DataRow = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing

            If Role IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        NewDataRow = DataTable.Rows.Add()

                        NewDataRow(0) = "Role: " & Role.ToString

                        If Role.IsInactive = 1 Then

                            NewDataRow(1) = "Active:  NO"

                        Else

                            NewDataRow(1) = "Active:  YES"

                        End If

                        NewDataRow(2) = ""

                        NewDataRow = DataTable.Rows.Add()

                        NewDataRow(0) = ""
                        NewDataRow(1) = ""
                        NewDataRow(2) = ""

                        NewDataRow = DataTable.Rows.Add()

                        NewDataRow(0) = "Tasks"
                        NewDataRow(1) = ""
                        NewDataRow(2) = ""

                        For Each TaskRole In AdvantageFramework.Database.Procedures.TaskRole.LoadByRoleCode(DataContext, Role.Code)

                            Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, TaskRole.TaskCode)

                            NewDataRow = DataTable.Rows.Add()

                            NewDataRow(0) = ""
                            NewDataRow(1) = TaskRole.TaskCode

                            If Task IsNot Nothing Then

                                NewDataRow(2) = Task.Description

                            End If

                        Next

                        NewDataRow = DataTable.Rows.Add()

                        NewDataRow(0) = "Employees"
                        NewDataRow(1) = ""
                        NewDataRow(2) = ""

                        For Each EmployeeRole In AdvantageFramework.Database.Procedures.EmployeeRole.LoadByRoleCode(DbContext, Role.Code)

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeRole.EmployeeCode)

                            NewDataRow = DataTable.Rows.Add()

                            NewDataRow(0) = ""
                            NewDataRow(1) = EmployeeRole.EmployeeCode

                            If Employee IsNot Nothing Then

                                If Employee.MiddleInitial Is Nothing OrElse Employee.MiddleInitial.Trim = "" Then

                                    NewDataRow(2) = Employee.FirstName & " " & Employee.LastName

                                Else

                                    NewDataRow(2) = Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName

                                End If

                            End If

                        Next

                    End Using

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewRoles_Role.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = DataGridViewRoles_Role.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewRoles_Role.HasASelectedRow

            End If

        End Sub
        Private Sub LoadSelectedTab()

            If TabControlForm_RoleMaintenance.SelectedTab Is TabItemRoleMaintenance_RoleDetailTab Then

                ButtonItemActions_Inactive.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

                ButtonItemExport_All.Enabled = True
                ButtonItemExport_CurrentView.Enabled = SearchableComboBoxRoleDetails_Roles.HasASelectedValue

            Else

                ButtonItemActions_Inactive.Enabled = False

                EnableOrDisableActions()

                ButtonItemExport_All.Enabled = True
                ButtonItemExport_CurrentView.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Roles As Generic.List(Of AdvantageFramework.Database.Entities.Role) = Nothing
            Dim Saved As Boolean = False

            If DataGridViewRoles_Role.HasRows Then

                DataGridViewRoles_Role.CurrentView.CloseEditorForUpdating()

                Roles = DataGridViewRoles_Role.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Role)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Role In Roles

                            AdvantageFramework.Database.Procedures.Role.Update(DbContext, Role)

                        Next

                    End Using

                    Saved = True

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewRoles_Role.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

                LoadGrid(ButtonItemActions_Inactive.Checked, True)

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RoleSetupForm As AdvantageFramework.Maintenance.ProjectSchedule.Presentation.RoleSetupForm = Nothing

            RoleSetupForm = New AdvantageFramework.Maintenance.ProjectSchedule.Presentation.RoleSetupForm()

            RoleSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RoleSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Inactive.Image = AdvantageFramework.My.Resources.ShowInactiveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            SearchableComboBoxRoleDetails_Roles.ByPassUserEntryChanged = True
            SearchableComboBoxRoleDetails_Roles.ExtraComboBoxItem = WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect

            LoadGrid(ButtonItemActions_Inactive.Checked, False)

            DataGridViewRoles_Role.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            TabControlForm_RoleMaintenance.SelectedTab = TabItemRoleMaintenance_RolesTab

            ButtonItemExport_All.Enabled = True
            ButtonItemExport_CurrentView.Enabled = False
            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub RoleSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = DataGridViewRoles_Role.UserEntryChanged

        End Sub
        Private Sub RoleSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = DataGridViewRoles_Role.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            If TabControlForm_RoleMaintenance.SelectedTab Is TabItemRoleMaintenance_RoleDetailTab Then

                ExportRoleDetails(True)

            Else

                DataGridViewRoles_Role.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End If

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            ExportRoleDetails(False)

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Role As AdvantageFramework.Database.Entities.Role = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewRoles_Role.HasASelectedRow Then

                DataGridViewRoles_Role.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewRoles_Role.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                    Try

                                        Role = RowHandleAndDataBoundItem.Value

                                    Catch ex As Exception
                                        Role = Nothing
                                    End Try

                                    If Role IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.Role.Delete(DbContext, DataContext, Role) Then

                                            DataGridViewRoles_Role.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                        End If

                                    End If

                                Next

                            End Using

                        End Using

                    Catch ex As Exception

                    End Try

                    Try

                        SearchableComboBoxRoleDetails_Roles.DataSource = DirectCast(DataGridViewRoles_Role.DataSource, System.Windows.Forms.BindingSource).DataSource

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewRoles_Role.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewRoles_Role.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRoles_Role_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRoles_Role.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRoles_Role_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewRoles_Role.AddNewRowEvent

            'objects
            Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Role Then

                Me.ShowWaitForm()

                Role = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Role.IsEntityBeingAdded() Then

                        Role.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.Role.Insert(DbContext, Role) Then

                            LoadGrid(ButtonItemActions_Inactive.Checked, True)

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRoles_Role_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRoles_Role.CellValueChangingEvent

            'objects
            Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.Role.Properties.IsInactive.ToString Then

                Try

                    Role = DataGridViewRoles_Role.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Role = Nothing
                End Try

                If Role IsNot Nothing Then

                    Try

                        Role.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        Role.IsInactive = Role.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Role.Update(DbContext, Role)

                        End Using

                    Catch ex As Exception

                    End Try

                    If Saved Then

                        LoadGrid(ButtonItemActions_Inactive.Checked, True)

                    End If

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewRoles_Role_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRoles_Role.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_RoleMaintenance_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_RoleMaintenance.SelectedTabChanged

            If Me.HasLoaded Then

                LoadSelectedTab()

            End If

        End Sub
        Private Sub ButtonRoleDetails_AddTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_AddTasks.Click

            Me.ShowWaitForm()

            AddSelectedTasks(DataGridViewRoleDetails_AvailableTasks.GetAllSelectedRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonRoleDetails_AddAllTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_AddAllTasks.Click

            Me.ShowWaitForm()

            AddSelectedTasks(DataGridViewRoleDetails_AvailableTasks.GetAllRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonRoleDetails_RemoveTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_RemoveTasks.Click

            Me.ShowWaitForm()

            RemoveSelectedTasks(DataGridViewRoleDetails_SelectedTasks.GetAllSelectedRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonRoleDetails_RemoveAllTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_RemoveAllTasks.Click

            Me.ShowWaitForm()

            RemoveSelectedTasks(DataGridViewRoleDetails_SelectedTasks.GetAllRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonRoleDetails_AddEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_AddEmployees.Click

            Me.ShowWaitForm()

            AddSelectedEmployees(DataGridViewRoleDetails_AvailableEmployees.GetAllSelectedRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonRoleDetails_AddAllEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_AddAllEmployees.Click

            Me.ShowWaitForm()

            AddSelectedEmployees(DataGridViewRoleDetails_AvailableEmployees.GetAllRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonRoleDetails_RemoveEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_RemoveEmployees.Click

            Me.ShowWaitForm()

            RemoveSelectedEmployees(DataGridViewRoleDetails_SelectedEmployees.GetAllSelectedRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonRoleDetails_RemoveAllEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRoleDetails_RemoveAllEmployees.Click

            Me.ShowWaitForm()

            RemoveSelectedEmployees(DataGridViewRoleDetails_SelectedEmployees.GetAllRowsDataBoundItems())

            LoadSelectedItemDetails()

            Me.CloseWaitForm()

        End Sub
        Private Sub SearchableComboBoxRoleDetails_Roles_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxRoleDetails_Roles.EditValueChanged

            If Me.HasLoaded Then

                Me.ShowWaitForm()

                LoadSelectedItemDetails()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Inactive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Inactive.CheckedChanged

            If Me.HasLoaded Then

                Me.ShowWaitForm()

                LoadGrid(ButtonItemActions_Inactive.Checked, True)

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRoleDetails_AvailableTasks_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRoleDetails_AvailableTasks.SelectionChangedEvent

            If Me.HasLoaded Then

                UpdateTaskButtons()

            End If

        End Sub
        Private Sub DataGridViewRoleDetails_SelectedTasks_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRoleDetails_SelectedTasks.SelectionChangedEvent

            If Me.HasLoaded Then

                UpdateTaskButtons()

            End If

        End Sub
        Private Sub DataGridViewRoleDetails_AvailableEmployees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRoleDetails_AvailableEmployees.SelectionChangedEvent

            If Me.HasLoaded Then

                UpdateEmployeeButtons()

            End If

        End Sub
        Private Sub DataGridViewRoleDetails_SelectedEmployees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRoleDetails_SelectedEmployees.SelectionChangedEvent

            If Me.HasLoaded Then

                UpdateEmployeeButtons()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    LoadGrid(ButtonItemActions_Inactive.Checked, False)

                Catch ex As Exception

                End Try

                Try

                    LoadSelectedTab()

                Catch ex As Exception

                End Try

                Try

                    LoadSelectedItemDetails()

                Catch ex As Exception

                End Try

                Me.ClearChanged()

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace