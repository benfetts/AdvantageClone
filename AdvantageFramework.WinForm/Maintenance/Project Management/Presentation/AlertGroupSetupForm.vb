Namespace Maintenance.ProjectManagement.Presentation

    Public Class AlertGroupSetupForm

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
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_AlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.LoadDistinctAlertGroups(DbContext).ToList.OrderBy(Function(Entity) Entity.Code).ToList

            End Using

            DataGridViewLeftSection_AlertGroup.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Dim AlertGroupCode As String = Nothing
            Dim AlertGroupList As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim AvailableEmployeeList As Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee) = Nothing
            Dim AlertGroupEmployeeList As Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee) = Nothing
            Dim AGE = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AvailableEmployeeList = New Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee)
                AlertGroupEmployeeList = New Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee)

                If DataGridViewLeftSection_AlertGroup.HasOnlyOneSelectedRow Then

                    AlertGroupCode = DataGridViewLeftSection_AlertGroup.GetFirstSelectedRowBookmarkValue

                    AlertGroupList = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroupCode).ToList

                    If AlertGroupList IsNot Nothing AndAlso AlertGroupList.Any Then

                        TextBoxTopSection_AlertGroup.Text = (From Entity In AlertGroupList
                                                             Select Entity.Code).FirstOrDefault

                        CheckBoxTopSection_Inactive.Checked = Convert.ToBoolean((From Entity In AlertGroupList
                                                                                 Select Entity.IsInactive.GetValueOrDefault(0)).FirstOrDefault)
                    End If

                    For Each AlertGroupEmployee In (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Include("Role").Include("Function")
                                                    Select New With {.EmployeeCode = Entity.Code,
                                                                     .FirstName = Entity.FirstName,
                                                                     .MiddleInitial = Entity.MiddleInitial,
                                                                     .LastName = Entity.LastName,
                                                                     .Email = Entity.Email,
                                                                     .TerminationDate = Entity.TerminationDate,
                                                                     .DefaultFunctionCode = Entity.Function.Code,
                                                                     .DefaultFunctionDescription = Entity.Function.Description,
                                                                     .DefaultRoleCode = Entity.Role.Code,
                                                                     .DefaultRoleDescription = Entity.Role.Description}).ToList

                        AGE = AlertGroupEmployee

                        If AlertGroupList.Any(Function(Entity) Entity.EmployeeCode = AGE.EmployeeCode) Then

                            Try

                                AlertGroup = AlertGroupList.Where(Function(Entity) Entity.EmployeeCode = AGE.EmployeeCode).SingleOrDefault

                            Catch ex As Exception
                                AlertGroup = Nothing
                            End Try

                            If AlertGroup IsNot Nothing Then

                                AlertGroupEmployeeList.Add(New AdvantageFramework.Database.Classes.AlertGroupEmployee(AlertGroup.Code, AlertGroupEmployee.EmployeeCode, AlertGroupEmployee.FirstName, AlertGroupEmployee.MiddleInitial,
                                                                                                                      AlertGroupEmployee.LastName, AlertGroupEmployee.Email, AlertGroupEmployee.DefaultFunctionCode, AlertGroupEmployee.DefaultFunctionDescription,
                                                                                                                      AlertGroupEmployee.DefaultRoleCode, AlertGroupEmployee.DefaultRoleDescription, Convert.ToBoolean(AlertGroup.IncludeOnSchedule.GetValueOrDefault(0))))

                            End If

                        Else

                            If AlertGroupEmployee.TerminationDate Is Nothing Then

                                AvailableEmployeeList.Add(New AdvantageFramework.Database.Classes.AlertGroupEmployee(Nothing, AlertGroupEmployee.EmployeeCode, AlertGroupEmployee.FirstName, AlertGroupEmployee.MiddleInitial,
                                                                                                                     AlertGroupEmployee.LastName, AlertGroupEmployee.Email, AlertGroupEmployee.DefaultFunctionCode, AlertGroupEmployee.DefaultFunctionDescription,
                                                                                                                     AlertGroupEmployee.DefaultRoleCode, AlertGroupEmployee.DefaultRoleDescription, False))

                            End If

                        End If

                    Next

                End If

                DataGridViewRightSection_AlertGroupEmployees.DataSource = AlertGroupEmployeeList
                DataGridViewLeftSection_Employees.DataSource = AvailableEmployeeList

                If DataGridViewLeftSection_Employees.Columns("AlertGroupCode") IsNot Nothing Then

                    DataGridViewLeftSection_Employees.Columns("AlertGroupCode").Visible = False

                End If

                If DataGridViewLeftSection_Employees.Columns("IncludeOnSchedule") IsNot Nothing Then

                    DataGridViewLeftSection_Employees.Columns("IncludeOnSchedule").Visible = False

                End If

                DataGridViewRightSection_AlertGroupEmployees.CurrentView.BestFitColumns()
                DataGridViewLeftSection_Employees.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewLeftSection_AlertGroup.HasOnlyOneSelectedRow Then

                ButtonRightSection_AddEmployeeToGroup.Enabled = DataGridViewLeftSection_Employees.HasASelectedRow
                ButtonRightSection_RemoveFromAlertGroup.Enabled = DataGridViewRightSection_AlertGroupEmployees.HasASelectedRow
                CheckBoxTopSection_Inactive.Enabled = True

            Else

                ButtonRightSection_AddEmployeeToGroup.Enabled = False
                ButtonRightSection_RemoveFromAlertGroup.Enabled = False
                CheckBoxTopSection_Inactive.Enabled = False

            End If

            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_AlertGroup.HasOnlyOneSelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AlertGroupSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupSetupForm = Nothing

            AlertGroupSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupSetupForm()

            AlertGroupSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertGroupSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TextBoxTopSection_AlertGroup.Enabled = False
            TextBoxTopSection_AlertGroup.ReadOnly = True

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            DataGridViewLeftSection_AlertGroup.MultiSelect = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxTopSection_AlertGroup.SetPropertySettings(AdvantageFramework.Database.Entities.AlertGroup.Properties.Code)

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_AlertGroup.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

            If DataGridViewLeftSection_AlertGroup IsNot Nothing Then

                If DataGridViewLeftSection_AlertGroup.Columns("EmployeeCode") IsNot Nothing Then

                    DataGridViewLeftSection_AlertGroup.Columns("EmployeeCode").Visible = False

                End If

                If DataGridViewLeftSection_AlertGroup.Columns("IncludeOnSchedule") IsNot Nothing Then

                    DataGridViewLeftSection_AlertGroup.Columns("IncludeOnSchedule").Visible = False

                End If

            End If

            DataGridViewRightSection_AlertGroupEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee)
            DataGridViewLeftSection_Employees.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee)

            If DataGridViewLeftSection_Employees.Columns("AlertGroupCode") IsNot Nothing Then

                DataGridViewLeftSection_Employees.Columns("AlertGroupCode").Visible = False

            End If

            If DataGridViewLeftSection_Employees.Columns("IncludeOnSchedule") IsNot Nothing Then

                DataGridViewLeftSection_Employees.Columns("IncludeOnSchedule").Visible = False

            End If

            DataGridViewRightSection_AlertGroupEmployees.CurrentView.BestFitColumns()
            DataGridViewLeftSection_Employees.CurrentView.BestFitColumns()

            CheckBoxTopSection_Inactive.Enabled = False

        End Sub
        Private Sub AlertGroupSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_AlertGroup.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemExport_All_Click(sender As Object, e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim AllAlertGroupEmployeeList As Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee) = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim CodesList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AllAlertGroupEmployeeList = New Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupEmployee)

                CodesList = DataGridViewLeftSection_AlertGroup.GetAllRowsBookmarkValues.OfType(Of String).ToList

                EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Include("Role").Include("Function").ToList

                For Each AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.Load(DbContext).ToList.Where(Function(Entity) CodesList.Contains(Entity.Code) = True).OrderBy(Function(AGrp) AGrp.Code).OrderBy(Function(AGrp) AGrp.EmployeeCode).ToList()

                    Try

                        Employee = EmployeeList.SingleOrDefault(Function(Emp) Emp.Code = AlertGroup.EmployeeCode)

                    Catch ex As Exception
                        Employee = Nothing
                    End Try

                    If Employee IsNot Nothing Then

                        AllAlertGroupEmployeeList.Add(New AdvantageFramework.Database.Classes.AlertGroupEmployee(AlertGroup, Employee))

                    End If

                Next

                DataGridViewRightSection_AllAlertGroupEmployees.DataSource = AllAlertGroupEmployeeList.OrderBy(Function(AlertGrp) AlertGrp.AlertGroupCode).ThenBy(Function(AlertGrp) AlertGrp.EmployeeCode).ToList

                DataGridViewRightSection_AllAlertGroupEmployees.CurrentView.BestFitColumns()

                DataGridViewRightSection_AllAlertGroupEmployees.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(sender As Object, e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            DataGridViewRightSection_AlertGroupEmployees.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub DataGridViewLeftSection_AlertGroup_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_AlertGroup.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewRightSection_AlertGroupEmployees_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_AlertGroupEmployees.CellValueChangingEvent

            'objects
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim AlertGroupCode As String = Nothing
            Dim IsInactive As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim AlertGroupEmployee As AdvantageFramework.Database.Classes.AlertGroupEmployee = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.AlertGroupEmployee.Properties.IncludeOnSchedule.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        EmployeeCode = DataGridViewRightSection_AlertGroupEmployees.CurrentView.GetRowCellValue(DataGridViewRightSection_AlertGroupEmployees.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.AlertGroupEmployee.Properties.EmployeeCode.ToString)

                        AlertGroupCode = DataGridViewLeftSection_AlertGroup.GetFirstSelectedRowBookmarkValue

                        AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCodeAndEmployeeCode(DbContext, AlertGroupCode, EmployeeCode)

                    Catch ex As Exception
                        AlertGroup = Nothing
                    End Try

                    If AlertGroup IsNot Nothing Then

                        AlertGroup.IncludeOnSchedule = Convert.ToInt16(e.Value)

                        Saved = AdvantageFramework.Database.Procedures.AlertGroup.Update(DbContext, AlertGroup)

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonRightSection_AddEmployeeToGroup_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddEmployeeToGroup.Click

            'objects
            Dim AlertGroupCode As String = Nothing
            Dim AlertGroupIsInActive As Boolean = Nothing
            Dim EmployeeCodeList As IEnumerable(Of Object) = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing

            If DataGridViewLeftSection_AlertGroup.IsNewItemOrAutoFilterRow = False AndAlso DataGridViewLeftSection_AlertGroup.HasOnlyOneSelectedRow AndAlso DataGridViewLeftSection_Employees.HasASelectedRow Then

                AlertGroupCode = DataGridViewLeftSection_AlertGroup.CurrentView.GetRowCellValue(DataGridViewLeftSection_AlertGroup.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.AlertGroup.Properties.Code.ToString)
                AlertGroupIsInActive = DataGridViewLeftSection_AlertGroup.CurrentView.GetRowCellValue(DataGridViewLeftSection_AlertGroup.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.AlertGroup.Properties.IsInactive.ToString)
                EmployeeCodeList = DataGridViewLeftSection_Employees.CurrentView.GetSelectedRows.Select(Function(RowHandle) DataGridViewLeftSection_Employees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.AlertGroupEmployee.Properties.EmployeeCode.ToString)).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each EmployeeCode In EmployeeCodeList.OfType(Of String)()

                            AlertGroup = New AdvantageFramework.Database.Entities.AlertGroup
                            AlertGroup.DbContext = DbContext
                            AlertGroup.Code = AlertGroupCode
                            AlertGroup.IsInactive = Convert.ToInt16(AlertGroupIsInActive)
                            AlertGroup.EmployeeCode = EmployeeCode

                            AdvantageFramework.Database.Procedures.AlertGroup.Insert(DbContext, AlertGroup)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadSelectedItemDetails()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveFromAlertGroup_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveFromAlertGroup.Click

            'objects
            Dim AlertGroupCode As String = Nothing
            Dim EmployeeCodeList As IEnumerable(Of Object) = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing

            If DataGridViewLeftSection_AlertGroup.HasOnlyOneSelectedRow AndAlso DataGridViewRightSection_AlertGroupEmployees.HasASelectedRow Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AlertGroupCode = DataGridViewLeftSection_AlertGroup.CurrentView.GetRowCellValue(DataGridViewLeftSection_AlertGroup.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.AlertGroup.Properties.Code.ToString)

                    EmployeeCodeList = DataGridViewRightSection_AlertGroupEmployees.CurrentView.GetSelectedRows.Select(Function(RowHandle) DataGridViewRightSection_AlertGroupEmployees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.AlertGroupEmployee.Properties.EmployeeCode.ToString)).ToList

                    For Each EmployeeCode In EmployeeCodeList.OfType(Of String)()

                        AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCodeAndEmployeeCode(DbContext, AlertGroupCode, EmployeeCode)

                        If AlertGroup IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.AlertGroup.Delete(DbContext, AlertGroup)

                        End If

                    Next

                    LoadSelectedItemDetails()

                    If DataGridViewRightSection_AlertGroupEmployees.HasRows = False Then

                        LoadGrid()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRightSection_AlertGroupEmployees_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_AlertGroupEmployees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_Employees_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_Employees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim AlertGroupCode As String = Nothing

            If AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupEditDialog.ShowFormDialog(AlertGroupCode) = Windows.Forms.DialogResult.OK Then

                LoadGrid()

                DataGridViewLeftSection_AlertGroup.SelectRow(AlertGroupCode)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            Dim AlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
            Dim AlertGroupCode As String = Nothing

            If DataGridViewLeftSection_AlertGroup.HasASelectedRow Then

                DataGridViewLeftSection_AlertGroup.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this group entirely?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AlertGroupCode = DataGridViewLeftSection_AlertGroup.GetFirstSelectedRowBookmarkValue

                        AlertGroups = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroupCode).ToList

                        If AlertGroups IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.AlertGroup.DeleteAll(DbContext, AlertGroupCode)

                        End If

                        Try
                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                                AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString, AlertGroupCode)
                            End Using
                        Catch ex As Exception

                        End Try

                    End Using

                    LoadGrid()

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub CheckBoxTopSection_Inactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxTopSection_Inactive.CheckedChanged

            'objects
            Dim AlertGroupCode As String = Nothing
            Dim AlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
            Dim IsInactive As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If Me.FormShown AndAlso DataGridViewLeftSection_AlertGroup.HasASelectedRow Then

                AlertGroupCode = DataGridViewLeftSection_AlertGroup.GetFirstSelectedRowBookmarkValue

                Me.ShowWaitForm("Processing...")

                Try

                    IsInactive = CheckBoxTopSection_Inactive.Checked

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AlertGroups = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroupCode).ToList

                        For Each AlertGroup In AlertGroups

                            AlertGroup.IsInactive = Convert.ToInt16(IsInactive)

                            AdvantageFramework.Database.Procedures.AlertGroup.Update(DbContext, AlertGroup)

                        Next

                    End Using

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Try

                            If IsInactive = True Then

                                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString)

                                If Setting IsNot Nothing Then

                                    If Setting.Value <> AlertGroupCode Then

                                        AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString, AlertGroupCode)

                                    End If

                                End If

                            Else

                                If AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString).Any(Function(Entity) Entity.Value.ToString() = AlertGroupCode) = False Then

                                    SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                                    SettingValue.DataContext = DataContext

                                    SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString
                                    SettingValue.DisplayText = AlertGroupCode
                                    SettingValue.Value = AlertGroupCode

                                    AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    End Using

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace