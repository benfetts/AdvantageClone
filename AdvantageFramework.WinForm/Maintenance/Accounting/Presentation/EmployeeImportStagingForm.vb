Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeImportStagingForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
        Private _ValidatingAllRows As Boolean = False
        Private _Properties As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _DepartmentTeams As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing
        Private _Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Office) = Nothing
        Private _Employees As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing
        Private _Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing
        Private _Roles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Role) = Nothing
        Private _PurchaseOrderApprovalRules As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) = Nothing
        Private _EmployeeTitles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTitle) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            _DbContext.Database.Connection.Open()

            Try

                DataGridViewForm_ImportedEmployees.DataSource = AdvantageFramework.Database.Procedures.ImportEmployeeStaging.Load(_DbContext).ToList

            Catch ex As Exception
                DataGridViewForm_ImportedEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ImportEmployeeStaging)
            End Try

            DataGridViewForm_ImportedEmployees.CurrentView.BestFitColumns()

            _ValidatingAllRows = True

            LoadCacheData()

            Try

                DataGridViewForm_ImportedEmployees.ValidateAllRowsAndClearChanged()

            Catch ex As Exception

            End Try

            ClearCacheData()

            _ValidatingAllRows = False

            _DbContext.Database.Connection.Close()

        End Sub
        Private Sub LoadCacheData()

            Try

                _DepartmentTeams = AdvantageFramework.Database.Procedures.DepartmentTeam.Load(_DbContext).ToList
                _Offices = AdvantageFramework.Database.Procedures.Office.LoadCore(AdvantageFramework.Database.Procedures.Office.Load(_DbContext)).ToList
                _Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(AdvantageFramework.Database.Procedures.EmployeeView.Load(_DbContext)).ToList
                _Functions = AdvantageFramework.Database.Procedures.Function.LoadCore(AdvantageFramework.Database.Procedures.Function.Load(_DbContext)).ToList
                _Roles = AdvantageFramework.Database.Procedures.Role.Load(_DbContext).ToList
                _PurchaseOrderApprovalRules = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Load(_DbContext).ToList
                _EmployeeTitles = AdvantageFramework.Database.Procedures.EmployeeTitle.Load(_DbContext).ToList

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ClearCacheData()

            Try

                _DepartmentTeams = Nothing
                _Offices = Nothing
                _Employees = Nothing
                _Functions = Nothing
                _Roles = Nothing
                _PurchaseOrderApprovalRules = Nothing
                _EmployeeTitles = Nothing

            Catch ex As Exception

            End Try

        End Sub
        Private Sub Save()

            For Each ImportEmployeeStaging In DataGridViewForm_ImportedEmployees.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.ImportEmployeeStaging).ToList

                Try

                    If (ImportEmployeeStaging.MiddleInitial IsNot Nothing OrElse ImportEmployeeStaging.MiddleInitial <> Nothing) AndAlso
                            ImportEmployeeStaging.MiddleInitial.Trim = "" Then

                        ImportEmployeeStaging.MiddleInitial = Nothing

                    End If

                Catch ex As Exception

                End Try

                _DbContext.UpdateObject(ImportEmployeeStaging)

            Next

            _DbContext.SaveChanges()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Import.Enabled = DataGridViewForm_ImportedEmployees.HasASelectedRow
            ButtonItemActions_Delete.Enabled = DataGridViewForm_ImportedEmployees.HasASelectedRow
            ButtonItemActions_Refresh.Enabled = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeImportStagingForm As EmployeeImportStagingForm = Nothing

            EmployeeImportStagingForm = New EmployeeImportStagingForm()

            EmployeeImportStagingForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeImportStagingForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewForm_ImportedEmployees.RunStandardValidation = False

            _DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
            _DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
            _Properties = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ImportEmployeeStaging)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

        End Sub
        Private Sub EmployeeImportStagingForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            LoadGrid()

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            If DataGridViewForm_ImportedEmployees.HasRows = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There are no employee records to import.")

            End If

        End Sub
        Private Sub EmployeeImportStagingForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeImportStagingForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            If DataGridViewForm_ImportedEmployees.HasRows Then

                DataGridViewForm_ImportedEmployees.CurrentView.CloseEditorForUpdating()

                Me.FormAction = WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm("Saving...")

                Try

                    Save()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                DataGridViewForm_ImportedEmployees.ClearChanged()
                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Import.Click

            'objects
            Dim IsValid As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeCore As AdvantageFramework.Database.Core.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim Role As AdvantageFramework.Database.Entities.Role = Nothing
            Dim EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle = Nothing
            Dim EmployeeImported As Boolean = False
            Dim ImportEmployeeStaging As AdvantageFramework.Database.Entities.ImportEmployeeStaging = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim EmployeeDepartments As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeDepartment) = Nothing
            Dim EmployeeRoles As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRole) = Nothing
            Dim EmployeeOnlyBillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing
            Dim BillingRateDetails As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateDetail) = Nothing

            If DataGridViewForm_ImportedEmployees.HasRows Then

                Me.FormAction = WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm("Importing...")

                DataGridViewForm_ImportedEmployees.CurrentView.CloseEditorForUpdating()

                RowHandlesAndDataBoundItems = DataGridViewForm_ImportedEmployees.GetAllRowsRowHandlesAndDataBoundItems

                _DbContext.Database.Connection.Open()

                LoadCacheData()

                Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(_DbContext).ToList
                EmployeeDepartments = AdvantageFramework.Database.Procedures.EmployeeDepartment.Load(_DbContext).ToList
                EmployeeRoles = AdvantageFramework.Database.Procedures.EmployeeRole.Load(_DbContext).ToList
                EmployeeOnlyBillingRateLevel = AdvantageFramework.Database.Procedures.BillingRateLevel.LoadEmployeeOnlyBillingRateLevel(_DbContext)

                If EmployeeOnlyBillingRateLevel IsNot Nothing Then

                    BillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(_DbContext, EmployeeOnlyBillingRateLevel.ID).ToList

                End If

                For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                    Try

                        If TypeOf RowHandleAndDataBoundItem.Value Is AdvantageFramework.Database.Entities.ImportEmployeeStaging Then

                            ImportEmployeeStaging = RowHandleAndDataBoundItem.Value

                        End If

                    Catch ex As Exception
                        ImportEmployeeStaging = Nothing
                    End Try

                    If ImportEmployeeStaging IsNot Nothing AndAlso ImportEmployeeStaging.HasError = False Then

                        IsValid = True
                        EmployeeImported = False
                        EmployeeTitle = Nothing
                        EmployeeCore = Nothing
                        DepartmentTeam = Nothing
                        Role = Nothing
                        BillingRateDetail = Nothing

                        ImportEmployeeStaging.DbContext = _DbContext

                        If ImportEmployeeStaging.IsOnHold = False Then

                            ImportEmployeeStaging.ValidateEntity(IsValid, _Properties, _DepartmentTeams, _Offices, _Employees, _Functions, _Roles, _PurchaseOrderApprovalRules, _EmployeeTitles)

                            If IsValid Then

                                Try

                                    EmployeeTitle = _EmployeeTitles.FirstOrDefault(Function(Entity) Entity.Description = ImportEmployeeStaging.Title)

                                Catch ex As Exception

                                End Try

                                If EmployeeTitle IsNot Nothing Then

                                    ImportEmployeeStaging.Title = EmployeeTitle.ID

                                Else

                                    If ImportEmployeeStaging.Title <> "*" AndAlso ImportEmployeeStaging.Title <> "" Then

                                        ImportEmployeeStaging.Title = Nothing

                                    End If

                                End If

                                If ImportEmployeeStaging.IsNew Then

                                    Try

                                        If (ImportEmployeeStaging.MiddleInitial IsNot Nothing OrElse ImportEmployeeStaging.MiddleInitial <> Nothing) AndAlso
                                                ImportEmployeeStaging.MiddleInitial.Trim = "" Then

                                            ImportEmployeeStaging.MiddleInitial = Nothing

                                        End If

                                    Catch ex As Exception

                                    End Try

                                    If AdvantageFramework.Database.Procedures.ImportEmployeeStaging.Update(_DbContext, ImportEmployeeStaging) Then

                                        If AdvantageFramework.EmployeeUtilities.ImportEmployeeFromImportEmployeeStaging(_DbContext, ImportEmployeeStaging.ID, _DbContext.UserCode, False) Then

                                            If ImportEmployeeStaging.DepartmentTeamCode <> "" Then

                                                If EmployeeDepartments.Any(Function(Entity) Entity.EmployeeCode = ImportEmployeeStaging.EmployeeCode AndAlso Entity.DepartmentTeamCode = ImportEmployeeStaging.DepartmentTeamCode) = False Then

                                                    Try

                                                        DepartmentTeam = _DepartmentTeams.SingleOrDefault(Function(Entity) Entity.Code = ImportEmployeeStaging.DepartmentTeamCode)

                                                    Catch ex As Exception
                                                        DepartmentTeam = Nothing
                                                    End Try

                                                    If DepartmentTeam IsNot Nothing Then

                                                        AdvantageFramework.Database.Procedures.EmployeeDepartment.Insert(_DbContext, ImportEmployeeStaging.EmployeeCode, ImportEmployeeStaging.DepartmentTeamCode, DepartmentTeam.Description, Nothing)

                                                    End If

                                                End If

                                            End If

                                            If ImportEmployeeStaging.BillRate <> 0 Then

                                                If EmployeeOnlyBillingRateLevel IsNot Nothing Then

                                                    If BillingRateDetails.Any(Function(Entity) Entity.EmployeeCode = ImportEmployeeStaging.EmployeeCode) = False Then

                                                        AdvantageFramework.Database.Procedures.BillingRateDetail.Insert(_DbContext, EmployeeOnlyBillingRateLevel.ID, ImportEmployeeStaging.EmployeeCode, Nothing, Nothing,
                                                                                                                        Nothing, Nothing, Nothing, Nothing, ImportEmployeeStaging.BillRate, 0, Nothing, Nothing, Nothing,
                                                                                                                        Nothing, Nothing, Nothing, Nothing, Nothing)

                                                    End If

                                                End If

                                            End If

                                            If ImportEmployeeStaging.RoleCode <> "" Then

                                                If EmployeeRoles.Any(Function(Entity) Entity.EmployeeCode = ImportEmployeeStaging.EmployeeCode AndAlso Entity.RoleCode = ImportEmployeeStaging.RoleCode) = False Then

                                                    Try

                                                        Role = _Roles.SingleOrDefault(Function(Entity) Entity.Code = ImportEmployeeStaging.RoleCode)

                                                    Catch ex As Exception
                                                        Role = Nothing
                                                    End Try

                                                    If Role IsNot Nothing Then

                                                        AdvantageFramework.Database.Procedures.EmployeeRole.Insert(_DbContext, ImportEmployeeStaging.EmployeeCode, Role.Code, Nothing)

                                                    End If

                                                End If

                                            End If

                                            EmployeeImported = AdvantageFramework.Database.Procedures.ImportEmployeeStaging.Delete(_DbContext, ImportEmployeeStaging)

                                            Try

                                                EmployeeCore = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(_DbContext).SingleOrDefault(Function(Entity) Entity.Code = ImportEmployeeStaging.EmployeeCode)

                                            Catch ex As Exception
                                                EmployeeCore = Nothing
                                            End Try

                                            If EmployeeCore IsNot Nothing Then

                                                _Employees.Add(EmployeeCore)

                                            End If

                                        End If

                                    End If

                                Else

                                    Try

                                        Employee = Employees.SingleOrDefault(Function(Entity) Entity.Code = ImportEmployeeStaging.EmployeeCode)

                                    Catch ex As Exception
                                        Employee = Nothing
                                    End Try

                                    If Employee IsNot Nothing Then

                                        ImportEmployeeStaging.DepartmentTeamCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.DepartmentTeamCode, ImportEmployeeStaging.DepartmentTeamCode)
                                        ImportEmployeeStaging.LastName = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.LastName, ImportEmployeeStaging.LastName)
                                        ImportEmployeeStaging.FirstName = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.FirstName, ImportEmployeeStaging.FirstName)
                                        ImportEmployeeStaging.MiddleInitial = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.MiddleInitial, ImportEmployeeStaging.MiddleInitial)
                                        ImportEmployeeStaging.CostRate = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.CostRate, ImportEmployeeStaging.CostRate)
                                        ImportEmployeeStaging.Address = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.Address, ImportEmployeeStaging.Address)
                                        ImportEmployeeStaging.Address2 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.Address2, ImportEmployeeStaging.Address2)
                                        ImportEmployeeStaging.City = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.City, ImportEmployeeStaging.City)
                                        ImportEmployeeStaging.County = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.County, ImportEmployeeStaging.County)
                                        ImportEmployeeStaging.PhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.PhoneNumber, ImportEmployeeStaging.PhoneNumber)
                                        ImportEmployeeStaging.State = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.State, ImportEmployeeStaging.State)
                                        ImportEmployeeStaging.OtherInfo = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.OtherInfo, ImportEmployeeStaging.OtherInfo)
                                        ImportEmployeeStaging.Zip = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.Zip, ImportEmployeeStaging.Zip)
                                        ImportEmployeeStaging.Title = AdvantageFramework.Importing.LoadImportedDataToUpdate(If(Employee.EmployeeTitleID Is Nothing, Nothing, CStr(Employee.EmployeeTitleID)), ImportEmployeeStaging.Title)
                                        ImportEmployeeStaging.StartDate = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.StartDate, ImportEmployeeStaging.StartDate)
                                        ImportEmployeeStaging.TerminationDate = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.TerminationDate, ImportEmployeeStaging.TerminationDate)
                                        ImportEmployeeStaging.BirthDate = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.BirthDate, ImportEmployeeStaging.BirthDate)
                                        ImportEmployeeStaging.LastIncrease = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.LastIncrease, ImportEmployeeStaging.LastIncrease)
                                        ImportEmployeeStaging.NextReview = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.NextReview, ImportEmployeeStaging.NextReview)
                                        ImportEmployeeStaging.AnnualSalary = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.AnnualSalary, ImportEmployeeStaging.AnnualSalary)
                                        ImportEmployeeStaging.MonthlySalary = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.MonthlySalary, ImportEmployeeStaging.MonthlySalary)
                                        ImportEmployeeStaging.Email = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.Email, ImportEmployeeStaging.Email)
                                        ImportEmployeeStaging.MonthHoursGoal = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.MonthHoursGoal, ImportEmployeeStaging.MonthHoursGoal)
                                        ImportEmployeeStaging.OfficeCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.OfficeCode, ImportEmployeeStaging.OfficeCode)
                                        ImportEmployeeStaging.SupervisorEmployeeCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.SupervisorEmployeeCode, ImportEmployeeStaging.SupervisorEmployeeCode)
                                        ImportEmployeeStaging.FunctionCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.FunctionCode, ImportEmployeeStaging.FunctionCode)
                                        ImportEmployeeStaging.PurchaseOrderLimit = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.PurchaseOrderLimit, ImportEmployeeStaging.PurchaseOrderLimit)
                                        ImportEmployeeStaging.AccountNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.AccountNumber, ImportEmployeeStaging.AccountNumber)
                                        ImportEmployeeStaging.WorkPhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.WorkPhoneNumber, ImportEmployeeStaging.WorkPhoneNumber)
                                        ImportEmployeeStaging.CellPhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.CellPhoneNumber, ImportEmployeeStaging.CellPhoneNumber)
                                        ImportEmployeeStaging.AlternatePhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.AlternatePhoneNumber, ImportEmployeeStaging.AlternatePhoneNumber)
                                        ImportEmployeeStaging.WorkPhoneNumberExtension = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.WorkPhoneNumberExtension, ImportEmployeeStaging.WorkPhoneNumberExtension)
                                        ImportEmployeeStaging.AnnualHours = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.AnnualHours, ImportEmployeeStaging.AnnualHours)
                                        ImportEmployeeStaging.DirectHours = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.DirectHours, ImportEmployeeStaging.DirectHours)
                                        ImportEmployeeStaging.RoleCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.RoleCode, ImportEmployeeStaging.RoleCode)
                                        ImportEmployeeStaging.PurchaseOrderApprovalRuleCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Employee.PurchaseOrderApprovalRuleCode, ImportEmployeeStaging.PurchaseOrderApprovalRuleCode)

                                        Try

                                            If (ImportEmployeeStaging.MiddleInitial IsNot Nothing OrElse ImportEmployeeStaging.MiddleInitial <> Nothing) AndAlso
                                                    ImportEmployeeStaging.MiddleInitial.Trim = "" Then

                                                ImportEmployeeStaging.MiddleInitial = Nothing

                                            End If

                                        Catch ex As Exception

                                        End Try

                                        If AdvantageFramework.Database.Procedures.ImportEmployeeStaging.Update(_DbContext, ImportEmployeeStaging) Then

                                            If AdvantageFramework.EmployeeUtilities.ImportEmployeeFromImportEmployeeStaging(_DbContext, ImportEmployeeStaging.ID, _DbContext.UserCode, True) Then

                                                If ImportEmployeeStaging.DepartmentTeamCode <> "" Then

                                                    If AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByEmployeeCodeAndDepartmentTeamCode(_DbContext, ImportEmployeeStaging.EmployeeCode, ImportEmployeeStaging.DepartmentTeamCode) Is Nothing Then

                                                        DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(_DbContext, ImportEmployeeStaging.DepartmentTeamCode)

                                                        If DepartmentTeam IsNot Nothing Then

                                                            AdvantageFramework.Database.Procedures.EmployeeDepartment.Insert(_DbContext, ImportEmployeeStaging.EmployeeCode, ImportEmployeeStaging.DepartmentTeamCode, DepartmentTeam.Description, Nothing)

                                                        End If

                                                    End If

                                                End If

                                                If EmployeeOnlyBillingRateLevel IsNot Nothing Then

                                                    Try

                                                        BillingRateDetail = BillingRateDetails.FirstOrDefault(Function(Entity) Entity.EmployeeCode = ImportEmployeeStaging.EmployeeCode)

                                                    Catch ex As Exception
                                                        BillingRateDetail = Nothing
                                                    End Try

                                                    If BillingRateDetail Is Nothing AndAlso ImportEmployeeStaging.BillRate.HasValue AndAlso ImportEmployeeStaging.BillRate <> 0 Then

                                                        AdvantageFramework.Database.Procedures.BillingRateDetail.Insert(_DbContext, EmployeeOnlyBillingRateLevel.ID, ImportEmployeeStaging.EmployeeCode, Nothing, Nothing,
                                                                                                                        Nothing, Nothing, Nothing, Nothing, ImportEmployeeStaging.BillRate, 0, Nothing, Nothing, Nothing,
                                                                                                                        Nothing, Nothing, Nothing, Nothing, Nothing)

                                                    ElseIf BillingRateDetail IsNot Nothing Then

                                                        BillingRateDetail.RateAmount = ImportEmployeeStaging.BillRate

                                                        AdvantageFramework.Database.Procedures.BillingRateDetail.Update(_DbContext, BillingRateDetail)

                                                    End If

                                                End If

                                                If ImportEmployeeStaging.RoleCode <> "" Then

                                                    If EmployeeRoles.Any(Function(Entity) Entity.EmployeeCode = ImportEmployeeStaging.EmployeeCode AndAlso Entity.RoleCode = ImportEmployeeStaging.RoleCode) = False Then

                                                        Try

                                                            Role = _Roles.SingleOrDefault(Function(Entity) Entity.Code = ImportEmployeeStaging.RoleCode)

                                                        Catch ex As Exception
                                                            Role = Nothing
                                                        End Try

                                                        If Role IsNot Nothing Then

                                                            AdvantageFramework.Database.Procedures.EmployeeRole.Insert(_DbContext, ImportEmployeeStaging.EmployeeCode, Role.Code, Nothing)

                                                        End If

                                                    End If

                                                End If

                                                EmployeeImported = AdvantageFramework.Database.Procedures.ImportEmployeeStaging.Delete(_DbContext, ImportEmployeeStaging)

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                        If EmployeeImported = False Then

                            If EmployeeTitle IsNot Nothing Then

                                ImportEmployeeStaging.Title = EmployeeTitle.Description

                                AdvantageFramework.Database.Procedures.ImportEmployeeStaging.Update(_DbContext, ImportEmployeeStaging)

                            End If

                        Else

                            DataGridViewForm_ImportedEmployees.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                        End If

                    End If

                Next

                _DbContext.Database.Connection.Close()

                ClearCacheData()

                If DataGridViewForm_ImportedEmployees.CheckForModifiedRows = False Then

                    Me.ClearChanged()

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ImportEmployeeStaging As AdvantageFramework.Database.Entities.ImportEmployeeStaging = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ImportEmployeeStagingIDs As Generic.List(Of Integer) = Nothing

            If DataGridViewForm_ImportedEmployees.HasASelectedRow Then

                DataGridViewForm_ImportedEmployees.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Deleting
                    Me.ShowWaitForm("Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ImportedEmployees.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        ImportEmployeeStagingIDs = RowHandlesAndDataBoundItems.Select(Function(KeyValue) KeyValue.Value).OfType(Of AdvantageFramework.Database.Entities.ImportEmployeeStaging).Select(Function(Entity) Entity.ID).ToList

                        If AdvantageFramework.Database.Procedures.ImportEmployeeStaging.DeleteByImportEmployeeStagingIDs(_DbContext, ImportEmployeeStagingIDs.ToArray) Then

                            DataGridViewForm_ImportedEmployees.CurrentView.BeginDataUpdate()

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                DataGridViewForm_ImportedEmployees.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                            Next

                            DataGridViewForm_ImportedEmployees.CurrentView.EndDataUpdate()

                        End If

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If DataGridViewForm_ImportedEmployees.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim ContinueRefreshing As Boolean = True

            DataGridViewForm_ImportedEmployees.CurrentView.CloseEditorForUpdating()

            If DataGridViewForm_ImportedEmployees.CheckForModifiedRows Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    Me.ShowWaitForm("Saving...")

                    Try

                        Save()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    DataGridViewForm_ImportedEmployees.ClearChanged()
                    Me.ClearChanged()

                Else

                    ContinueRefreshing = False

                End If

            End If

            If ContinueRefreshing Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                LoadGrid()

                EnableOrDisableActions()

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedEmployees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ImportedEmployees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ImportedEmployees_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_ImportedEmployees.ValidateRowEvent

            If TypeOf e.Row Is AdvantageFramework.Database.Entities.ImportEmployeeStaging Then

                If _ValidatingAllRows Then

                    CType(e.Row, AdvantageFramework.Database.Entities.ImportEmployeeStaging).DbContext = _DbContext
                    CType(e.Row, AdvantageFramework.Database.Entities.ImportEmployeeStaging).DataContext = _DataContext

                    e.ErrorText = CType(e.Row, AdvantageFramework.Database.Entities.ImportEmployeeStaging).ValidateEntity(e.Valid, _Properties, _DepartmentTeams, _Offices, _Employees, _Functions, _Roles, _PurchaseOrderApprovalRules, _EmployeeTitles)

                    e.Valid = True

                Else

                    CType(e.Row, AdvantageFramework.Database.Entities.ImportEmployeeStaging).DbContext = _DbContext
                    CType(e.Row, AdvantageFramework.Database.Entities.ImportEmployeeStaging).DataContext = _DataContext

                    e.ErrorText = CType(e.Row, AdvantageFramework.Database.Entities.ImportEmployeeStaging).ValidateEntity(e.Valid, _Properties)

                    e.Valid = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedEmployees_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_ImportedEmployees.ValidatingEditorEvent

            'objects
            Dim ImportEmployeeStaging As AdvantageFramework.Database.Entities.ImportEmployeeStaging = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                ImportEmployeeStaging = DataGridViewForm_ImportedEmployees.CurrentView.GetFocusedRow

            Catch ex As Exception
                ImportEmployeeStaging = Nothing
            End Try

            Try

                PropertyDescriptor = _Properties.SingleOrDefault(Function(PD) PD.Name = DataGridViewForm_ImportedEmployees.CurrentView.FocusedColumn.FieldName)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If ImportEmployeeStaging IsNot Nothing AndAlso PropertyDescriptor IsNot Nothing Then

                ImportEmployeeStaging.DbContext = _DbContext
                ImportEmployeeStaging.DataContext = _DataContext

                e.ErrorText = ImportEmployeeStaging.ValidateEntityProperty(PropertyDescriptor, e.Valid, e.Value)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
