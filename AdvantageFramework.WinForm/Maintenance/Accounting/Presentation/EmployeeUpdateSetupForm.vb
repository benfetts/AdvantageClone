Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeUpdateSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeRowSelectionChanging As Boolean = False
        Private _DefaultFunctions As Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing
        Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Private _DataContext As AdvantageFramework.Database.DataContext = Nothing

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

            'objects
            Dim EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()
                    SecurityDbContext.Database.Connection.Open()

                    EmployeesList = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(Me.Session, DbContext, SecurityDbContext).Include("DepartmentTeam").Include("Office").ToList

                    If ButtonItemSort_Code.Checked Then

                        EmployeesList = EmployeesList.OrderBy(Function(Entity) Entity.Code).ToList

                    ElseIf ButtonItemSort_FirstName.Checked Then

                        EmployeesList = EmployeesList.OrderBy(Function(Entity) Entity.FirstName).ToList

                    ElseIf ButtonItemSort_LastName.Checked Then

                        EmployeesList = EmployeesList.OrderBy(Function(Entity) Entity.LastName).ToList

                    End If

                    DataGridViewLeftSection_Employees.DataSource = (From Employee In EmployeesList
                                                                    Select Employee.Code,
                                                                           Employee.FirstName,
                                                                           Employee.LastName,
                                                                           Employee.MiddleInitial,
                                                                           Employee.OfficeCode,
                                                                           [OfficeName] = If(Employee.Office Is Nothing, "", Employee.Office.Name),
                                                                           Employee.DepartmentTeamCode,
                                                                           [DepartmentTeamName] = If(Employee.DepartmentTeam Is Nothing, "", Employee.DepartmentTeam.Description),
                                                                           Employee.TerminationDate,
                                                                           Employee.Freelance,
                                                                           Employee.IsActiveFreelance).ToList _
                                                               .Select(Function(Employee) New AdvantageFramework.Database.Classes.Employee With {.Code = Employee.Code,
                                                                                                                                                 .Name = Employee.FirstName & " " &
                                                                                                                                                         If(String.IsNullOrWhiteSpace(Employee.MiddleInitial) = False, Employee.MiddleInitial & ". ", "") &
                                                                                                                                                         Employee.LastName,
                                                                                                                                                 .OfficeCode = Employee.OfficeCode,
                                                                                                                                                 .OfficeName = Employee.OfficeName,
                                                                                                                                                 .DepartmentTeamCode = Employee.DepartmentTeamCode,
                                                                                                                                                 .DepartmentTeamName = Employee.DepartmentTeamName,
                                                                                                                                                 .Terminated = If(Employee.TerminationDate Is Nothing, False, True),
                                                                                                                                                 .Freelance = CBool(Employee.Freelance.GetValueOrDefault(0)),
                                                                                                                                                 .IsActiveFreelance = Employee.IsActiveFreelance}).ToList

                    DataGridViewGeneralInformation_GeneralInformation.DataSource = (From Employee In EmployeesList
                                                                                    Select New AdvantageFramework.Database.Classes.EmployeeGeneralInformation(Employee)).ToList

                    DataGridViewEmployeeSettings_EmployeeSettings.DataSource = (From Employee In EmployeesList
                                                                                Select New AdvantageFramework.Database.Classes.EmployeeSetting(Employee)).ToList

                    DataGridViewHRInformation_HRInformation.DataSource = (From Employee In EmployeesList
                                                                          Select New AdvantageFramework.Database.Classes.EmployeeHRInformation(Employee)).ToList

                    DataGridViewNotes_Notes.DataSource = (From Employee In EmployeesList
                                                          Select New AdvantageFramework.Database.Classes.EmployeeNotes(Employee)).ToList

                    SecurityDbContext.Database.Connection.Close()
                    DbContext.Database.Connection.Close()

                End Using

            End Using

            For Each GridColumn In DataGridViewNotes_Notes.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.MinWidth = 300
                GridColumn.Width = 300

            Next

            DataGridViewNotes_Notes.CurrentView.BestFitColumns()
            DataGridViewHRInformation_HRInformation.CurrentView.BestFitColumns()
            DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.BestFitColumns()
            DataGridViewGeneralInformation_GeneralInformation.CurrentView.BestFitColumns()
            DataGridViewLeftSection_Employees.CurrentView.BestFitColumns()

        End Sub
        Private Sub SetupDataGridViews(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            DataGridView.CurrentView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
            DataGridView.CurrentView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never

            DataGridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            DataGridView.OptionsView.ColumnAutoWidth = False
            DataGridView.OptionsView.ShowFooter = False
            DataGridView.OptionsView.ShowGroupPanel = False
            DataGridView.OptionsView.ShowViewCaption = False

            DataGridView.OptionsMenu.EnableColumnMenu = False
            DataGridView.OptionsMenu.ShowGroupSortSummaryItems = False
            DataGridView.OptionsMenu.ShowDateTimeGroupIntervalItems = False
            DataGridView.OptionsMenu.ShowGroupSummaryEditorItem = False
            DataGridView.OptionsMenu.ShowAutoFilterRowItem = False
            DataGridView.OptionsMenu.ShowAddNewSummaryItem = False
            DataGridView.OptionsMenu.EnableFooterMenu = False
            DataGridView.OptionsMenu.EnableGroupPanelMenu = False

            DataGridView.OptionsCustomization.AllowFilter = False
            DataGridView.OptionsCustomization.AllowQuickHideColumns = False
            DataGridView.OptionsCustomization.AllowGroup = False
            DataGridView.OptionsCustomization.AllowSort = False

            DataGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never

            DataGridView.MultiSelect = False

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        If _DbContext Is Nothing Then

                            _DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        End If

                        If _DataContext Is Nothing Then

                            _DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        End If

                        Try

                            IsOkay = Me.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Try

                            If _DbContext IsNot Nothing Then

                                _DbContext.Dispose()

                                _DbContext = Nothing

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            If _DataContext IsNot Nothing Then

                                _DataContext.Dispose()

                                _DataContext = Nothing

                            End If

                        Catch ex As Exception

                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim OldEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim OldEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EmployeeNote As AdvantageFramework.Database.Classes.EmployeeNotes = Nothing
            Dim EmployeeHRInformation As AdvantageFramework.Database.Classes.EmployeeHRInformation = Nothing
            Dim EmployeeSetting As AdvantageFramework.Database.Classes.EmployeeSetting = Nothing
            Dim EmployeeGeneralInformation As AdvantageFramework.Database.Classes.EmployeeGeneralInformation = Nothing
            Dim Saved As Boolean = True
            Dim ErrorMessage As String = ""

            Try

                Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(_DbContext).ToList
                OldEmployees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(_DbContext).ToList

                For Each Employee In Employees

                    EmployeeNote = Nothing
                    EmployeeHRInformation = Nothing
                    EmployeeSetting = Nothing
                    EmployeeGeneralInformation = Nothing

                    Try

                        OldEmployee = OldEmployees.SingleOrDefault(Function(Entity) Entity.Code = Employee.Code)

                    Catch ex As Exception
                        OldEmployee = Nothing
                    End Try

                    Try

                        EmployeeNote = DataGridViewNotes_Notes.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Classes.EmployeeNotes).SingleOrDefault(Function(Entity) Entity.Code = Employee.Code)

                    Catch ex As Exception
                        EmployeeNote = Nothing
                    End Try

                    If EmployeeNote IsNot Nothing Then

                        Employee.Comments = EmployeeNote.Comments

                    End If

                    Try

                        EmployeeHRInformation = DataGridViewHRInformation_HRInformation.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Classes.EmployeeHRInformation).SingleOrDefault(Function(Entity) Entity.Code = Employee.Code)

                    Catch ex As Exception
                        EmployeeHRInformation = Nothing
                    End Try

                    If EmployeeHRInformation IsNot Nothing Then

                        Employee.StartDate = EmployeeHRInformation.StartDate
                        Employee.BirthDate = EmployeeHRInformation.BirthDate
                        Employee.LastIncrease = EmployeeHRInformation.LastIncrease
                        Employee.NextReview = EmployeeHRInformation.NextReview
                        Employee.TerminationDate = EmployeeHRInformation.TerminationDate
                        Employee.AnnualSalary = EmployeeHRInformation.AnnualSalary
                        Employee.MonthlySalary = EmployeeHRInformation.MonthlySalary
                        Employee.AnnualHours = EmployeeHRInformation.AnnualHours
                        Employee.MonthHoursGoal = EmployeeHRInformation.MonthHoursGoal
                        Employee.DirectHours = EmployeeHRInformation.DirectHours
                        Employee.Status = EmployeeHRInformation.Status
                        Employee.BillRate = EmployeeHRInformation.BillRate
                        Employee.CostRate = EmployeeHRInformation.CostRate
                        Employee.EmployeeVendorCode = EmployeeHRInformation.EmployeeVendorCode
                        Employee.CreditCardNumber = EmployeeHRInformation.CreditCardNumber
                        Employee.CreditCardDescription = EmployeeHRInformation.CreditCardDescription
                        Employee.CreditCardGLAccount = EmployeeHRInformation.CreditCardGLAccount
                        Employee.OtherInfo = EmployeeHRInformation.OtherInfo
                        Employee.VacationHours = EmployeeHRInformation.VacationHours
                        Employee.VacationDateFrom = EmployeeHRInformation.VacationDateFrom
                        Employee.VacationDateTo = EmployeeHRInformation.VacationDateTo
                        Employee.SickHours = EmployeeHRInformation.SickHours
                        Employee.SickDateFrom = EmployeeHRInformation.SickDateFrom
                        Employee.SickDateTo = EmployeeHRInformation.SickDateTo
                        Employee.PersonalHours = EmployeeHRInformation.PersonalHours
                        Employee.PersonalHoursDateFrom = EmployeeHRInformation.PersonalHoursDateFrom
                        Employee.PersonalHoursDateTo = EmployeeHRInformation.PersonalHoursDateTo
                        Employee.PurchaseOrderLimit = EmployeeHRInformation.PurchaseOrderLimit
                        Employee.PurchaseOrderApprovalRuleCode = EmployeeHRInformation.PurchaseOrderApprovalRuleCode
                        Employee.SupervisorApprovalRequired = EmployeeHRInformation.SupervisorApprovalRequired
                        Employee.AlternateApproverCode = EmployeeHRInformation.AlternateApproverCode
                        Employee.BillableHoursGoal = EmployeeHRInformation.BillableHoursGoal

                    End If

                    Try

                        EmployeeSetting = DataGridViewEmployeeSettings_EmployeeSettings.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Classes.EmployeeSetting).SingleOrDefault(Function(Entity) Entity.Code = Employee.Code)

                    Catch ex As Exception
                        EmployeeSetting = Nothing
                    End Try

                    If EmployeeSetting IsNot Nothing Then

                        Employee.Email = EmployeeSetting.Email
                        Employee.TimeAlert = EmployeeSetting.TimeAlert
                        Employee.WeeklyTimeType = EmployeeSetting.WeeklyTimeType
                        Employee.AlertNotificationType = EmployeeSetting.AlertNotificationType
                        Employee.Seniority = EmployeeSetting.Seniority
                        Employee.AllowPOGLSelection = EmployeeSetting.AllowPOGLSelection
                        Employee.LimitPOGLSelectionOffice = EmployeeSetting.LimitPOGLSelectionOffice
                        Employee.OmitFromMissingTimeTracking = EmployeeSetting.OmitFromMissingTimeTracking

                    End If

                    Try

                        EmployeeGeneralInformation = DataGridViewGeneralInformation_GeneralInformation.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Classes.EmployeeGeneralInformation).SingleOrDefault(Function(Entity) Entity.Code = Employee.Code)

                    Catch ex As Exception
                        EmployeeGeneralInformation = Nothing
                    End Try

                    If EmployeeGeneralInformation IsNot Nothing Then

                        Employee.EmployeeTitleID = EmployeeGeneralInformation.EmployeeTitleID
                        Employee.Freelance = EmployeeGeneralInformation.Freelance
                        Employee.IsActiveFreelance = EmployeeGeneralInformation.IsActiveFreelance
                        Employee.FunctionCode = EmployeeGeneralInformation.FunctionCode
                        Employee.OfficeCode = EmployeeGeneralInformation.OfficeCode
                        Employee.DepartmentTeamCode = EmployeeGeneralInformation.DepartmentTeamCode
                        Employee.SupervisorEmployeeCode = EmployeeGeneralInformation.SupervisorEmployeeCode
                        Employee.RoleCode = EmployeeGeneralInformation.RoleCode
                        Employee.AccountNumber = EmployeeGeneralInformation.AccountNumber
                        Employee.PhoneNumber = EmployeeGeneralInformation.PhoneNumber
                        Employee.WorkPhoneNumber = EmployeeGeneralInformation.WorkPhoneNumber
                        Employee.WorkPhoneNumberExtension = EmployeeGeneralInformation.WorkPhoneNumberExtension
                        Employee.CellPhoneNumber = EmployeeGeneralInformation.CellPhoneNumber
                        Employee.AlternatePhoneNumber = EmployeeGeneralInformation.AlternatePhoneNumber
                        Employee.Address = EmployeeGeneralInformation.Address
                        Employee.Address2 = EmployeeGeneralInformation.Address2
                        Employee.City = EmployeeGeneralInformation.City
                        Employee.Country = EmployeeGeneralInformation.Country
                        Employee.County = EmployeeGeneralInformation.County
                        Employee.State = EmployeeGeneralInformation.State
                        Employee.Zip = EmployeeGeneralInformation.Zip
                        Employee.PayToAddress = EmployeeGeneralInformation.PayToAddress
                        Employee.PayToAddress2 = EmployeeGeneralInformation.PayToAddress2
                        Employee.PayToCity = EmployeeGeneralInformation.PayToCity
                        Employee.PayToCountry = EmployeeGeneralInformation.PayToCountry
                        Employee.PayToCounty = EmployeeGeneralInformation.PayToCounty
                        Employee.PayToState = EmployeeGeneralInformation.PayToState
                        Employee.PayToZip = EmployeeGeneralInformation.PayToZip
                        Employee.MiddleInitial = EmployeeGeneralInformation.MiddleInitial
                        Employee.LastName = EmployeeGeneralInformation.LastName
                        Employee.FirstName = EmployeeGeneralInformation.FirstName

                    End If

                    If EmployeeGeneralInformation IsNot Nothing OrElse EmployeeHRInformation IsNot Nothing OrElse EmployeeNote IsNot Nothing OrElse EmployeeSetting IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.EmployeeView.Update(_DbContext, _DataContext, Employee) = False Then

                            Saved = False

                        Else

                            If OldEmployee IsNot Nothing Then

                                If OldEmployee.DepartmentTeamCode <> Employee.DepartmentTeamCode OrElse OldEmployee.EmployeeTitleID <> Employee.EmployeeTitleID OrElse
                                                OldEmployee.AnnualSalary <> Employee.AnnualSalary OrElse OldEmployee.MonthlySalary <> Employee.MonthlySalary OrElse
                                                OldEmployee.CostRate <> Employee.CostRate Then

                                    If AdvantageFramework.WinForm.MessageBox.Show("Would you like to create a rate history record for this employee?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                        AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeHRHistoryDialog.ShowFormDialog(0, Employee.Code, OldEmployee)

                                    End If

                                End If

                            End If

                        End If

                    End If

                Next

                ValidateAllRowsAndClearChanged(DataGridViewNotes_Notes)
                ValidateAllRowsAndClearChanged(DataGridViewHRInformation_HRInformation)
                ValidateAllRowsAndClearChanged(DataGridViewEmployeeSettings_EmployeeSettings)
                ValidateAllRowsAndClearChanged(DataGridViewGeneralInformation_GeneralInformation)

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                Saved = False
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Private Function LoadDefaultFunctions(ByVal SelectedEmployeeCode As String) As Generic.List(Of AdvantageFramework.Database.Core.Function)

            'objects
            Dim FunctionCodes() As String = Nothing
            Dim Functions As Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing
            Dim Users As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim DoesEmployeeHaveLimitedFunctions As Boolean = False

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Users = AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, SelectedEmployeeCode).ToList

                End Using

            Catch ex As Exception
                Users = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)
            End Try

            For Each User In Users

                If AdvantageFramework.Security.LoadUserSetting(Me.Session, User.ID, Security.UserSettings.EMP_TS_FNC) = True Then

                    DoesEmployeeHaveLimitedFunctions = True

                End If

            Next

            If DoesEmployeeHaveLimitedFunctions Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    FunctionCodes = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, SelectedEmployeeCode)
                                     Select Entity.FunctionCode).ToArray

                End Using

                Functions = _DefaultFunctions.Where(Function(Entity) FunctionCodes.Contains(Entity.Code)).ToList

            Else

                Functions = _DefaultFunctions

            End If

            LoadDefaultFunctions = Functions

        End Function
        Private Sub ValidateAllRowsAndClearChanged(DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            If _DbContext Is Nothing Then

                _DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            End If

            If _DataContext Is Nothing Then

                _DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

            End If

            DataGridView.RunStandardValidation = False

            DataGridView.ValidateAllRowsAndClearChanged()

            DataGridView.RunStandardValidation = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeUpdateSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateSetupForm = Nothing

            EmployeeUpdateSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateSetupForm()

            EmployeeUpdateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeUpdateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            SetupDataGridViews(DataGridViewGeneralInformation_GeneralInformation)
            SetupDataGridViews(DataGridViewEmployeeSettings_EmployeeSettings)
            SetupDataGridViews(DataGridViewHRInformation_HRInformation)
            SetupDataGridViews(DataGridViewNotes_Notes)

            TabItemEmployeeDetails_HRInformationTab.Visible = Not AdvantageFramework.Security.CanUserCustom1InModule(Me.Session, Security.Modules.Maintenance_Accounting_Employee)
            ButtonItemActions_CostAndDepartmentUpdate.Visible = TabItemEmployeeDetails_HRInformationTab.Visible

            ButtonItemActions_Save.SecurityEnabled = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee)
            ButtonItemText_CheckSpelling.SecurityEnabled = ButtonItemActions_Save.SecurityEnabled
            ButtonItemActions_AccruePaidTimeOff.SecurityEnabled = ButtonItemActions_Save.SecurityEnabled
            ButtonItemActions_CostAndDepartmentUpdate.SecurityEnabled = ButtonItemActions_Save.SecurityEnabled
            ButtonItemActions_UpdateDates.SecurityEnabled = ButtonItemActions_Save.SecurityEnabled

            DataGridViewGeneralInformation_GeneralInformation.CurrentView.OptionsBehavior.Editable = ButtonItemActions_Save.SecurityEnabled
            DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.OptionsBehavior.Editable = ButtonItemActions_Save.SecurityEnabled
            DataGridViewHRInformation_HRInformation.CurrentView.OptionsBehavior.Editable = ButtonItemActions_Save.SecurityEnabled
            DataGridViewNotes_Notes.CurrentView.OptionsBehavior.Editable = ButtonItemActions_Save.SecurityEnabled

            ButtonItemActions_Print.SecurityEnabled = AdvantageFramework.Security.CanUserPrintInModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee)
            ButtonItemActions_PrintFiltered.SecurityEnabled = ButtonItemActions_Print.SecurityEnabled

            DataGridViewLeftSection_Employees.CurrentView.Appearance.ViewCaption.Font = New System.Drawing.Font(DataGridViewLeftSection_Employees.CurrentView.Appearance.ViewCaption.Font.Name, 7)

            DataGridViewLeftSection_Employees.OptionsView.ShowFooter = False

            DataGridViewLeftSection_Employees.CurrentView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always

            DataGridViewLeftSection_Employees.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never

            DataGridViewLeftSection_Employees.OptionsMenu.EnableColumnMenu = False
            DataGridViewLeftSection_Employees.OptionsMenu.ShowGroupSortSummaryItems = False
            DataGridViewLeftSection_Employees.OptionsMenu.ShowDateTimeGroupIntervalItems = False
            DataGridViewLeftSection_Employees.OptionsMenu.ShowGroupSummaryEditorItem = False
            DataGridViewLeftSection_Employees.OptionsMenu.ShowAutoFilterRowItem = True
            DataGridViewLeftSection_Employees.OptionsMenu.ShowAddNewSummaryItem = False
            DataGridViewLeftSection_Employees.OptionsMenu.EnableFooterMenu = False
            DataGridViewLeftSection_Employees.OptionsMenu.EnableGroupPanelMenu = False

            DataGridViewLeftSection_Employees.OptionsCustomization.AllowFilter = True
            DataGridViewLeftSection_Employees.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewLeftSection_Employees.OptionsCustomization.AllowGroup = False
            DataGridViewLeftSection_Employees.OptionsCustomization.AllowSort = False

            ButtonItemActions_ImportHours.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_UpdateDates.Image = AdvantageFramework.My.Resources.CalendarMonthRefresh
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage
            ButtonItemActions_CostAndDepartmentUpdate.Image = AdvantageFramework.My.Resources.EmployeeCostRateImage
            ButtonItemActions_AccruePaidTimeOff.Image = AdvantageFramework.My.Resources.ClockEdit

            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemHRHistory_View.Image = AdvantageFramework.My.Resources.EmployeeInfoImage

            DataGridViewLeftSection_Employees.MultiSelect = False

            LoadGrid()

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    _DefaultFunctions = AdvantageFramework.Database.Procedures.Function.LoadCore(AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeFunctions(DbContext)).ToList

                End Using

            Catch ex As Exception
                _DefaultFunctions = New Generic.List(Of AdvantageFramework.Database.Core.Function)
            End Try

        End Sub
        Private Sub EmployeeUpdateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeUpdateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_ImportHours_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ImportHours.Click

            AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.Employee)

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim SelectedTabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim AllGridsValid As Boolean = True
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            DataGridViewNotes_Notes.CurrentView.CloseEditorForUpdating()
            DataGridViewHRInformation_HRInformation.CurrentView.CloseEditorForUpdating()
            DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.CloseEditorForUpdating()
            DataGridViewGeneralInformation_GeneralInformation.CurrentView.CloseEditorForUpdating()

            _DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
            _DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

            For Each TabItem In TabControRightSection_EmployeeDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                Try

                    DataGridView = TabItem.AttachedControl.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.DataGridView).FirstOrDefault

                Catch ex As Exception
                    DataGridView = Nothing
                End Try

                If DataGridView IsNot Nothing Then

                    DataGridView.RunStandardValidation = False

                    DataGridView.ValidateAllRows()

                    DataGridView.RunStandardValidation = True

                    If DataGridView.HasAnyInvalidRows Then

                        AllGridsValid = False

                        If SelectedTabItem Is Nothing OrElse TabItem Is TabControRightSection_EmployeeDetails.SelectedTab Then

                            SelectedTabItem = TabItem

                        End If

                    End If

                End If

            Next

            If AllGridsValid Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If Me.Save() Then

                        Me.ClearChanged()

                        LoadGrid()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                TabControRightSection_EmployeeDetails.SelectedTab = SelectedTabItem

                ErrorMessage = "Please fix invalid row(s)."

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Try

                If _DbContext IsNot Nothing Then

                    _DbContext.Dispose()

                    _DbContext = Nothing

                End If

            Catch ex As Exception

            End Try

            Try

                If _DataContext IsNot Nothing Then

                    _DataContext.Dispose()

                    _DataContext = Nothing

                End If

            Catch ex As Exception

            End Try

        End Sub
        'Private Sub DataGridViewLeftSection_Employees_CustomColumnSortEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewLeftSection_Employees.CustomColumnSortEvent

        '    DataGridViewNotes_Notes.Columns(e.Column.FieldName).SortOrder = e.SortOrder
        '    DataGridViewHRInformation_HRInformation.Columns(e.Column.FieldName).SortOrder = e.SortOrder
        '    DataGridViewEmployeeSettings_EmployeeSettings.Columns(e.Column.FieldName).SortOrder = e.SortOrder
        '    DataGridViewGeneralInformation_GeneralInformation.Columns(e.Column.FieldName).SortOrder = e.SortOrder

        'End Sub
        Private Sub DataGridViewLeftSection_Employees_ColumnFilterChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Employees.ColumnFilterChangedEvent

            'objects
            Dim EmployeeCodes() As String = Nothing
            Dim FilterString As String = Nothing

            Try

                EmployeeCodes = (From Entity In DataGridViewLeftSection_Employees.GetAllRowsBookmarkValues.OfType(Of String)()
                                 Select Entity).ToArray

                FilterString = "[Code] In ('" & String.Join("','", EmployeeCodes) & "')"

            Catch ex As Exception
                EmployeeCodes = Nothing
            End Try

            DataGridViewNotes_Notes.CurrentView.AFActiveFilterString = FilterString
            DataGridViewHRInformation_HRInformation.CurrentView.AFActiveFilterString = FilterString
            DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.AFActiveFilterString = FilterString
            DataGridViewGeneralInformation_GeneralInformation.CurrentView.AFActiveFilterString = FilterString

        End Sub
        Private Sub DataGridViewLeftSection_Employees_TopRowChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Employees.TopRowChangedEvent

            DataGridViewNotes_Notes.CurrentView.TopRowIndex = DataGridViewLeftSection_Employees.CurrentView.TopRowIndex
            DataGridViewHRInformation_HRInformation.CurrentView.TopRowIndex = DataGridViewLeftSection_Employees.CurrentView.TopRowIndex
            DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.TopRowIndex = DataGridViewLeftSection_Employees.CurrentView.TopRowIndex
            DataGridViewGeneralInformation_GeneralInformation.CurrentView.TopRowIndex = DataGridViewLeftSection_Employees.CurrentView.TopRowIndex

        End Sub
        Private Sub DataGridViewLeftSection_Employees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Employees.SelectionChangedEvent

            If _EmployeeRowSelectionChanging = False Then

                _EmployeeRowSelectionChanging = True

                Try

                    DataGridViewNotes_Notes.CurrentView.FocusedRowHandle = DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle
                    DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle = DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle
                    DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.FocusedRowHandle = DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle
                    DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle = DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle

                Catch ex As Exception

                End Try

                _EmployeeRowSelectionChanging = False

            End If

        End Sub
        Private Sub DataGridViewNotes_Notes_HiddenEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewNotes_Notes.HiddenEditorEvent

            If Me.FormShown AndAlso RibbonBarOptions_Text.Visible Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub DataGridViewNotes_Notes_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewNotes_Notes.SelectionChangedEvent

            If _EmployeeRowSelectionChanging = False Then

                _EmployeeRowSelectionChanging = True

                Try

                    DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle = DataGridViewNotes_Notes.CurrentView.FocusedRowHandle
                    DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.FocusedRowHandle = DataGridViewNotes_Notes.CurrentView.FocusedRowHandle
                    DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle = DataGridViewNotes_Notes.CurrentView.FocusedRowHandle
                    DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle = DataGridViewNotes_Notes.CurrentView.FocusedRowHandle

                Catch ex As Exception

                End Try

                _EmployeeRowSelectionChanging = False

            End If

        End Sub
        Private Sub DataGridViewHRInformation_HRInformation_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewHRInformation_HRInformation.CellValueChangedEvent

            'objects
            Dim EmployeeHRInformation As AdvantageFramework.Database.Classes.EmployeeHRInformation = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeHRInformation.Properties.AnnualSalary.ToString Then

                Try

                    EmployeeHRInformation = DataGridViewHRInformation_HRInformation.CurrentView.GetRow(DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle)

                Catch ex As Exception
                    EmployeeHRInformation = Nothing
                End Try

                If EmployeeHRInformation IsNot Nothing Then

                    Try

                        EmployeeHRInformation.MonthlySalary = Math.Round(e.Value / 12, 2)

                    Catch ex As Exception
                        EmployeeHRInformation.MonthlySalary = Nothing
                    End Try

                    Try

                        EmployeeHRInformation.CostRate = Math.Round(e.Value / EmployeeHRInformation.AnnualHours.GetValueOrDefault(0), 2)

                    Catch ex As Exception
                        EmployeeHRInformation.CostRate = Nothing
                    End Try

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeHRInformation.Properties.MonthlySalary.ToString Then

                Try

                    EmployeeHRInformation = DataGridViewHRInformation_HRInformation.CurrentView.GetRow(DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle)

                Catch ex As Exception
                    EmployeeHRInformation = Nothing
                End Try

                If EmployeeHRInformation IsNot Nothing Then

                    Try

                        EmployeeHRInformation.AnnualSalary = Math.Round(e.Value * 12, 2)

                    Catch ex As Exception
                        EmployeeHRInformation.AnnualSalary = Nothing
                    End Try

                    Try

                        EmployeeHRInformation.CostRate = Math.Round(EmployeeHRInformation.AnnualSalary.GetValueOrDefault(0) / EmployeeHRInformation.AnnualHours.GetValueOrDefault(0), 2)

                    Catch ex As Exception
                        EmployeeHRInformation.CostRate = Nothing
                    End Try

                End If

            End If

        End Sub
        Private Sub DataGridViewHRInformation_HRInformation_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewHRInformation_HRInformation.SelectionChangedEvent

            If _EmployeeRowSelectionChanging = False Then

                _EmployeeRowSelectionChanging = True

                Try

                    DataGridViewNotes_Notes.CurrentView.FocusedRowHandle = DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle
                    DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.FocusedRowHandle = DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle
                    DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle = DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle
                    DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle = DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle

                Catch ex As Exception

                End Try

                _EmployeeRowSelectionChanging = False

            End If

        End Sub
        Private Sub DataGridViewHRInformation_HRInformation_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewHRInformation_HRInformation.QueryPopupNeedDatasourceEvent

            If DataGridViewLeftSection_Employees.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If FieldName = AdvantageFramework.Database.Classes.EmployeeHRInformation.Properties.AlternateApproverCode.ToString Then

                            OverrideDefaultDatasource = True
                            Datasource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(Me.Session, DbContext).Include("DepartmentTeam").Include("Office").ToList

                        ElseIf FieldName = AdvantageFramework.Database.Classes.EmployeeHRInformation.Properties.EmployeeVendorCode.ToString Then

                            OverrideDefaultDatasource = True
                            Datasource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveEmployeeVendorsWithOfficeLimits(Me.Session, DbContext).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Classes.EmployeeHRInformation.Properties.CreditCardGLAccount.ToString Then

                            OverrideDefaultDatasource = True
                            Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList

                        End If

                    End Using

                End Using

            End If

        End Sub
        Private Sub DataGridViewEmployeeSettings_EmployeeSettings_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewEmployeeSettings_EmployeeSettings.CellValueChangingEvent

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim EmployeeSetting As AdvantageFramework.Database.Classes.EmployeeSetting = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.ReceivesEmail.ToString AndAlso e.Value = 1 Then

                DirectCast(DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.EmployeeSetting).ReceivesAlerts = 1

                DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.RefreshRow(e.RowHandle)

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.ReceivesAlerts.ToString AndAlso e.Value = 0 Then

                DirectCast(DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.EmployeeSetting).ReceivesEmail = 0

                DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.RefreshRow(e.RowHandle)

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.Email.ToString Then

                EmployeeSetting = DirectCast(DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.EmployeeSetting)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If AdvantageFramework.ConceptShare.IsConceptShareEnabled(DataContext) Then

                            If EmployeeSetting IsNot Nothing AndAlso EmployeeSetting.ConceptShareUserID.GetValueOrDefault(0) > 0 Then

                                If String.IsNullOrWhiteSpace(e.Value) AndAlso String.IsNullOrWhiteSpace(EmployeeSetting.Email) = False Then

                                    If AdvantageFramework.WinForm.MessageBox.Show("Removing the email address from this employee will remove the employee from ConceptShare." &
                                                                                  System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?",
                                                                                  AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "ConceptShare") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Removing User...")

                                        APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, EmployeeSetting.Code, EmployeeSetting.ConceptShareUserID.Value)

                                        If APIReponse.CompletedSuccessfully Then

                                            AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

                                        Else

                                            AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                                            DirectCast(DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.EmployeeSetting).Email = EmployeeSetting.Email

                                        End If

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                                        If APIReponse.CompletedSuccessfully = False Then

                                            DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.RefreshRow(e.RowHandle)

                                        End If

                                    Else

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing, "Refeshing...")

                                        DirectCast(DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.EmployeeSetting).Email = EmployeeSetting.Email

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                                        DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.RefreshRow(e.RowHandle)

                                    End If

                                ElseIf e.Value <> EmployeeSetting.Email Then

                                    If AdvantageFramework.WinForm.MessageBox.Show("Changing the email address for this employee will remove the employee from ConceptShare." &
                                                                                  System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?",
                                                                                  AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "ConceptShare") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Removing User...")

                                        APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, EmployeeSetting.Code, EmployeeSetting.ConceptShareUserID.Value)

                                        If APIReponse.CompletedSuccessfully Then

                                            AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

                                        Else

                                            AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                                            DirectCast(DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.EmployeeSetting).Email = EmployeeSetting.Email

                                        End If

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                                        If APIReponse.CompletedSuccessfully = False Then

                                            DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.RefreshRow(e.RowHandle)

                                        End If

                                    Else

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing, "Refeshing...")

                                        DirectCast(DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.EmployeeSetting).Email = EmployeeSetting.Email

                                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                                        DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.RefreshRow(e.RowHandle)

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

            End If

        End Sub
        Private Sub DataGridViewEmployeeSettings_EmployeeSettings_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewEmployeeSettings_EmployeeSettings.SelectionChangedEvent

            If _EmployeeRowSelectionChanging = False Then

                _EmployeeRowSelectionChanging = True

                Try

                    DataGridViewNotes_Notes.CurrentView.FocusedRowHandle = DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.FocusedRowHandle
                    DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle = DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.FocusedRowHandle
                    DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle = DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.FocusedRowHandle
                    DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle = DataGridViewEmployeeSettings_EmployeeSettings.CurrentView.FocusedRowHandle

                Catch ex As Exception

                End Try

                _EmployeeRowSelectionChanging = False

            End If

        End Sub
        Private Sub DataGridViewGeneralInformation_GeneralInformation_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewGeneralInformation_GeneralInformation.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeGeneralInformation.Properties.Freelance.ToString Then

                CType(DataGridViewGeneralInformation_GeneralInformation.CurrentView.GetFocusedRow, AdvantageFramework.Database.Classes.EmployeeGeneralInformation).IsActiveFreelance = Convert.ToBoolean(e.Value)

                DataGridViewGeneralInformation_GeneralInformation.CurrentView.RefreshRow(DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle)

            End If

        End Sub
        Private Sub DataGridViewGeneralInformation_GeneralInformation_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewGeneralInformation_GeneralInformation.QueryPopupNeedDatasourceEvent

            'objects
            Dim EmployeeDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing
            Dim SelectedEmployeeCode As String = Nothing

            If DataGridViewLeftSection_Employees.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        SelectedEmployeeCode = DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue

                        If FieldName = AdvantageFramework.Database.Classes.EmployeeGeneralInformation.Properties.DepartmentTeamCode.ToString Then

                            Try

                                EmployeeDepartmentTeams = AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByEmployeeCode(DbContext, SelectedEmployeeCode).Include("DepartmentTeam").Select(Function(Entity) Entity.DepartmentTeam).ToList

                            Catch ex As Exception
                                EmployeeDepartmentTeams = Nothing
                            End Try

                            OverrideDefaultDatasource = True
                            Datasource = EmployeeDepartmentTeams

                        ElseIf FieldName = AdvantageFramework.Database.Classes.EmployeeGeneralInformation.Properties.FunctionCode.ToString Then

                            OverrideDefaultDatasource = True
                            Datasource = LoadDefaultFunctions(SelectedEmployeeCode)

                        ElseIf FieldName = AdvantageFramework.Database.Classes.EmployeeGeneralInformation.Properties.SupervisorEmployeeCode.ToString Then

                            OverrideDefaultDatasource = True
                            Datasource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(Me.Session, DbContext).Include("DepartmentTeam").Include("Office").ToList

                        ElseIf FieldName = AdvantageFramework.Database.Classes.EmployeeGeneralInformation.Properties.OfficeCode.ToString Then

                            OverrideDefaultDatasource = True
                            Datasource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList

                        End If

                    End Using

                End Using

            End If

        End Sub
        Private Sub DataGridViewGeneralInformation_GeneralInformation_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewGeneralInformation_GeneralInformation.SelectionChangedEvent

            If _EmployeeRowSelectionChanging = False Then

                _EmployeeRowSelectionChanging = True

                Try

                    DataGridViewNotes_Notes.CurrentView.FocusedRowHandle = DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle
                    DataGridViewHRInformation_HRInformation.CurrentView.FocusedRowHandle = DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle
                    DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle = DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle
                    DataGridViewLeftSection_Employees.CurrentView.FocusedRowHandle = DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedRowHandle

                Catch ex As Exception

                End Try

                _EmployeeRowSelectionChanging = False

            End If

        End Sub
        Private Sub DataGridViewGeneralInformation_GeneralInformation_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewGeneralInformation_GeneralInformation.ShowingEditorEvent

            If DataGridViewGeneralInformation_GeneralInformation.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeGeneralInformation.Properties.IsActiveFreelance.ToString Then

                If CType(DataGridViewGeneralInformation_GeneralInformation.CurrentView.GetFocusedRow, AdvantageFramework.Database.Classes.EmployeeGeneralInformation).Freelance.GetValueOrDefault(0) <> 1 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_AccruePaidTimeOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_AccruePaidTimeOff.Click

            'objects
            Dim ContinueOn As Boolean = True

            ContinueOn = CheckForUnsavedChanges()

            If ContinueOn Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.AccruePaidTimeOffDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_UpdateDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_UpdateDates.Click

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EmployeeHRInformation As AdvantageFramework.Database.Classes.EmployeeHRInformation = Nothing
            Dim AnyInformationChanged As Boolean = False
            Dim DatesChanged As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeesList = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

            End Using

            If AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateDatesDialog.ShowFormDialog(EmployeesList) = System.Windows.Forms.DialogResult.OK Then

                For Each EmployeeHRInformation In DataGridViewHRInformation_HRInformation.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeHRInformation)()

                    DatesChanged = False

                    Try

                        Employee = EmployeesList.SingleOrDefault(Function(Entity) Entity.Code = EmployeeHRInformation.Code)

                    Catch ex As Exception
                        Employee = Nothing
                    End Try

                    If Employee IsNot Nothing Then

                        If EmployeeHRInformation.SickDateTo.Equals(Employee.SickDateTo) = False OrElse
                                    EmployeeHRInformation.SickDateFrom.Equals(Employee.SickDateFrom) = False OrElse
                                    EmployeeHRInformation.VacationDateTo.Equals(Employee.VacationDateTo) = False OrElse
                                    EmployeeHRInformation.VacationDateFrom.Equals(Employee.VacationDateFrom) = False OrElse
                                    EmployeeHRInformation.PersonalHoursDateTo.Equals(Employee.PersonalHoursDateTo) = False OrElse
                                    EmployeeHRInformation.PersonalHoursDateFrom.Equals(Employee.PersonalHoursDateFrom) = False Then

                            AnyInformationChanged = True
                            DatesChanged = True

                        End If

                        EmployeeHRInformation.SickDateTo = Employee.SickDateTo
                        EmployeeHRInformation.SickDateFrom = Employee.SickDateFrom

                        EmployeeHRInformation.VacationDateTo = Employee.VacationDateTo
                        EmployeeHRInformation.VacationDateFrom = Employee.VacationDateFrom

                        EmployeeHRInformation.PersonalHoursDateTo = Employee.PersonalHoursDateTo
                        EmployeeHRInformation.PersonalHoursDateFrom = Employee.PersonalHoursDateFrom

                        If DatesChanged Then

                            DataGridViewHRInformation_HRInformation.AddToModifiedRows(EmployeeHRInformation)

                        End If

                    End If

                Next

                DataGridViewHRInformation_HRInformation.CurrentView.RefreshData()

                If AnyInformationChanged Then

                    DataGridViewHRInformation_HRInformation.SetUserEntryChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_CostAndDepartmentUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_CostAndDepartmentUpdate.Click

            AdvantageFramework.Maintenance.Accounting.Presentation.CostRateForm.ShowFormDialog()

        End Sub
        Private Sub ButtonItemActions_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Print.Click

            ' objects
            Dim SelectedEmployeeCodes() As String = Nothing

            If DataGridViewLeftSection_Employees.HasASelectedRow Then

                SelectedEmployeeCodes = {DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue}

            End If

            AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeReportsDialog.ShowFormDialog(Nothing, SelectedEmployeeCodes)

        End Sub
        Private Sub ButtonItemActions_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintFiltered.Click

            'objects
            Dim SelectedAndAvailableEmployeeCodes() As String = Nothing

            Try

                SelectedAndAvailableEmployeeCodes = (From Entity In DataGridViewLeftSection_Employees.GetAllRowsBookmarkValues.OfType(Of String)()
                                                     Select Entity).ToArray

            Catch ex As Exception
                SelectedAndAvailableEmployeeCodes = Nothing
            End Try

            AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeReportsDialog.ShowFormDialog(SelectedAndAvailableEmployeeCodes, SelectedAndAvailableEmployeeCodes)

        End Sub
        Private Sub DataGridViewNotes_Notes_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewNotes_Notes.ShownEditorEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf DataGridViewNotes_Notes.CurrentView.ActiveEditor Is DevExpress.XtraEditors.MemoExEdit Then

                Try

                    DirectCast(DataGridViewNotes_Notes.CurrentView.ActiveEditor, DevExpress.XtraEditors.MemoExEdit).Text = DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SpellChecker.Check(DirectCast(DataGridViewNotes_Notes.CurrentView.ActiveEditor, DevExpress.XtraEditors.MemoExEdit).Text)

                Catch ex As Exception
                    DirectCast(DataGridViewNotes_Notes.CurrentView.ActiveEditor, DevExpress.XtraEditors.MemoExEdit).Text = DirectCast(DataGridViewNotes_Notes.CurrentView.ActiveEditor, DevExpress.XtraEditors.MemoExEdit).Text
                End Try

            End If

        End Sub
        Private Sub TabControRightSection_EmployeeDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControRightSection_EmployeeDetails.SelectedTabChanged

            If TabControRightSection_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_HRInformationTab Then

                RibbonBarOptions_HRHistory.Visible = True

            Else

                RibbonBarOptions_HRHistory.Visible = False

            End If

        End Sub
        Private Sub ButtonItemHRHistory_View_Click(sender As Object, e As EventArgs) Handles ButtonItemHRHistory_View.Click

            'objects
            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing

            ParameterDictionary = New Dictionary(Of String, Object)

            ParameterDictionary("EmployeeCode") = DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue

            AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.EmployeeHRHistory, False, True, ParameterDictionary:=ParameterDictionary)

        End Sub
        Private Sub ButtonItemSort_Code_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSort_Code.CheckedChanged

            'objects
            Dim ContinueOn As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemSort_Code.Checked Then

                    ContinueOn = CheckForUnsavedChanges()

                    If ContinueOn Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()
                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSort_FirstName_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSort_FirstName.CheckedChanged

            'objects
            Dim ContinueOn As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemSort_FirstName.Checked Then

                    ContinueOn = CheckForUnsavedChanges()

                    If ContinueOn Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()
                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSort_LastName_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSort_LastName.CheckedChanged

            'objects
            Dim ContinueOn As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemSort_LastName.Checked Then

                    ContinueOn = CheckForUnsavedChanges()

                    If ContinueOn Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()
                        Me.FormAction = WinForm.Presentation.FormActions.None

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewNotes_Notes_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewNotes_Notes.ValidateRowEvent

            If DataGridViewNotes_Notes.RunStandardValidation = False Then

                If TypeOf e.Row Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                    If TypeOf e.Row Is AdvantageFramework.BaseClasses.Entity Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.EntityBase Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DataContext = _DataContext
                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.BaseClass Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).ValidateEntity(e.Valid)

                    Else

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntity(e.Valid)

                    End If

                    If DataGridViewNotes_Notes.IsNewItemRow(e.RowHandle) = False Then

                        e.Valid = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewEmployeeSettings_EmployeeSettings_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewEmployeeSettings_EmployeeSettings.ValidateRowEvent

            If DataGridViewEmployeeSettings_EmployeeSettings.RunStandardValidation = False Then

                If TypeOf e.Row Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                    If TypeOf e.Row Is AdvantageFramework.BaseClasses.Entity Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.EntityBase Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DataContext = _DataContext
                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.BaseClass Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).ValidateEntity(e.Valid)

                    Else

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntity(e.Valid)

                    End If

                    If DataGridViewEmployeeSettings_EmployeeSettings.IsNewItemRow(e.RowHandle) = False Then

                        e.Valid = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewGeneralInformation_GeneralInformation_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewGeneralInformation_GeneralInformation.ValidateRowEvent

            If DataGridViewGeneralInformation_GeneralInformation.RunStandardValidation = False Then

                If TypeOf e.Row Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                    If TypeOf e.Row Is AdvantageFramework.BaseClasses.Entity Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.EntityBase Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DataContext = _DataContext
                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.BaseClass Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).ValidateEntity(e.Valid)

                    Else

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntity(e.Valid)

                    End If

                    If DataGridViewGeneralInformation_GeneralInformation.IsNewItemRow(e.RowHandle) = False Then

                        e.Valid = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewHRInformation_HRInformation_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewHRInformation_HRInformation.ValidateRowEvent

            If DataGridViewHRInformation_HRInformation.RunStandardValidation = False Then

                If TypeOf e.Row Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                    If TypeOf e.Row Is AdvantageFramework.BaseClasses.Entity Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Entity).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.EntityBase Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DataContext = _DataContext
                        DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.EntityBase).ValidateEntity(e.Valid)

                    ElseIf TypeOf e.Row Is AdvantageFramework.BaseClasses.BaseClass Then

                        DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).DbContext = _DbContext

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).ValidateEntity(e.Valid)

                    Else

                        e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntity(e.Valid)

                    End If

                    If DataGridViewHRInformation_HRInformation.IsNewItemRow(e.RowHandle) = False Then

                        e.Valid = True

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
