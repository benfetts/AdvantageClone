Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PowerUsersQuantity As Integer = 0
        Private _WVOnlyUsersQuantity As Integer = 0
        Private _IsAgencyASP As Boolean = False

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

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_Employees.DataSource = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("DepartmentTeam").Include("Office").ToList
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
                                                                           Employee.IsActiveFreelance
                                                                    Order By Code).ToList _
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

                    DataGridViewLeftSection_Employees.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            EmployeeControlRightSection_Employee.ClearControl()

            EmployeeControlRightSection_Employee.Enabled = DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow

            If EmployeeControlRightSection_Employee.Enabled Then

                EmployeeControlRightSection_Employee.Enabled = EmployeeControlRightSection_Employee.LoadControl(DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            If EmployeeControlRightSection_Employee.Enabled Then

                EmployeeControlRightSection_Employee.Enabled = (DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            End If

            ButtonItemActions_Terminate.Enabled = (DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow AndAlso EmployeeControlRightSection_Employee.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow AndAlso EmployeeControlRightSection_Employee.Enabled)

            RibbonBarOptions_NotesActions.Visible = EmployeeControlRightSection_Employee.IsNotesTabSelected
            RibbonBarOptions_SecurityActions.Visible = EmployeeControlRightSection_Employee.IsSecurityAndPasswordsTabSelected

            If EmployeeControlRightSection_Employee.IsHRAndRateInformationTabSelected Then

                RibbonBarOptions_BillingRatesActions.Visible = True
                RibbonBarOptions_HRHistory.Visible = True
                RibbonBarOptions_CostRateAndDepartmentTeam.Visible = True

            Else

                RibbonBarOptions_CostRateAndDepartmentTeam.Visible = False
                RibbonBarOptions_HRHistory.Visible = False
                RibbonBarOptions_BillingRatesActions.Visible = False

            End If

            RibbonBarOptions_Office.Visible = EmployeeControlRightSection_Employee.IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeOfficeLimits
            RibbonBarOptions_Employee.Visible = EmployeeControlRightSection_Employee.IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeLimits
            RibbonBarOptions_CDP.Visible = EmployeeControlRightSection_Employee.IsSecurityAndPasswordsTabSelectedAndAlsoCDPLimits
            RibbonBarOptions_TimesheetFunction.Visible = EmployeeControlRightSection_Employee.IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeTSFunctionLimits
            RibbonBarOptions_Documents.Visible = EmployeeControlRightSection_Employee.IsDocumentsTabSelected

            ButtonItemActions_Print.Enabled = EmployeeControlRightSection_Employee.Enabled
            ButtonItemActions_PrintFiltered.Enabled = DataGridViewLeftSection_Employees.HasRows

            RibbonBarOptions_NotesActions.Enabled = EmployeeControlRightSection_Employee.Enabled
            RibbonBarOptions_SecurityActions.Enabled = EmployeeControlRightSection_Employee.Enabled

            ButtonItemBillingRatesActions_Delete.Enabled = (EmployeeControlRightSection_Employee.RateFlagEntryControl.HasASelectedBillingRateDetail AndAlso EmployeeControlRightSection_Employee.Enabled)
            ButtonItemBillingRatesActions_Cancel.Enabled = (EmployeeControlRightSection_Employee.RateFlagEntryControl.IsSelectedDetailNewItemRow AndAlso EmployeeControlRightSection_Employee.Enabled)

            RibbonBarOptions_Office.Enabled = EmployeeControlRightSection_Employee.Enabled
            ButtonItemOfficeCopy_CopyTo.Enabled = EmployeeControlRightSection_Employee.EmployeeOfficeLimitControl.HasLimitedOffices

            RibbonBarOptions_Documents.Enabled = EmployeeControlRightSection_Employee.Enabled

            If RibbonBarOptions_Documents.Visible AndAlso RibbonBarOptions_Documents.Enabled Then

                ButtonItemDocuments_Upload.Enabled = EmployeeControlRightSection_Employee.DocumentManager.CanUpload
                ButtonItemDocuments_Delete.Enabled = EmployeeControlRightSection_Employee.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(EmployeeControlRightSection_Employee.DocumentManager.HasOnlyOneSelectedDocument, Not EmployeeControlRightSection_Employee.DocumentManager.IsSelectedDocumentAURL, EmployeeControlRightSection_Employee.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(EmployeeControlRightSection_Employee.DocumentManager.HasOnlyOneSelectedDocument, EmployeeControlRightSection_Employee.DocumentManager.IsSelectedDocumentAURL, False)

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            RibbonBarOptions_Employee.Enabled = EmployeeControlRightSection_Employee.Enabled
            ButtonItemEmployeeCopy_CopyTo.Enabled = EmployeeControlRightSection_Employee.UserEmployeeLimitControl.HasLimitedEmployees

            RibbonBarOptions_CDP.Enabled = EmployeeControlRightSection_Employee.Enabled
            ButtonItemCDPCopy_CopyTo.Enabled = EmployeeControlRightSection_Employee.UserCDPLimitControl.HasLimitedCDPs

            RibbonBarOptions_TimesheetFunction.Enabled = EmployeeControlRightSection_Employee.Enabled
            ButtonItemTimesheetFunctionCopy_CopyTo.Enabled = EmployeeControlRightSection_Employee.EmployeeTimesheetFunctionLimitsControl.HasLimitedFunctions

            RibbonBarOptions_HRHistory.Enabled = EmployeeControlRightSection_Employee.Enabled
            RibbonBarOptions_CostRateAndDepartmentTeam.Enabled = EmployeeControlRightSection_Employee.Enabled

            RibbonBarOptions_AdditionalEmails.Visible = EmployeeControlRightSection_Employee.IsAlertsAndSettingsTabSelectedAndAlsoAdditionalEmailsTab
            ButtonItemAdditionalEmails_Add.Enabled = EmployeeControlRightSection_Employee.Enabled
            ButtonItemAdditionalEmails_Delete.Enabled = EmployeeControlRightSection_Employee.Enabled AndAlso EmployeeControlRightSection_Employee.HasASelectedAdditionalEmail

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    EmployeeControlRightSection_Employee.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = EmployeeControlRightSection_Employee.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
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

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeSetupForm = Nothing

            EmployeeSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeSetupForm()

            EmployeeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim LicenseKey As String = ""
            Dim AgencyLicenseKey As String = ""
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim DatabaseID As Integer = 0
            Dim ErrorMessage As String = String.Empty

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Terminate.Image = AdvantageFramework.My.Resources.EmployeeTerminateImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemNotesActions_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage
            ButtonItemSecurityActions_AddUser.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemSecurityActions_ChangePassword.Image = AdvantageFramework.My.Resources.ChangePasswordImage

            ButtonItemBillingRatesActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemBillingRatesActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            ButtonItemHRHistory_View.Image = AdvantageFramework.My.Resources.EmployeeInfoImage

            ButtonItemCostRateAndDepartmentTeam_Update.Image = AdvantageFramework.My.Resources.EmployeeCostRateImage

            ButtonItemOffice_OfficeCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemOfficeCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemOfficeCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemEmployee_EmployeeCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemEmployeeCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemEmployeeCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemTimesheetFunction_TimesheetFunctionCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemTimesheetFunctionCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemTimesheetFunctionCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemCDP_CDPCopy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemCDPCopy_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemCDPCopy_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemImport_Wizard.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemImport_PendingRecords.Image = AdvantageFramework.My.Resources.DatabaseStagingImage

            ButtonItemAdditionalEmails_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemAdditionalEmails_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            DataGridViewLeftSection_Employees.MultiSelect = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                AgencyLicenseKey = AdvantageFramework.Database.Procedures.Agency.LoadLicenseKey(DbContext)

                If AgencyLicenseKey <> "" Then

                    LicenseKey = AdvantageFramework.Security.LicenseKey.Read(AgencyLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                             PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName,
                                                                             DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                    _PowerUsersQuantity = PowerUsersQuantity
                    _WVOnlyUsersQuantity = WVOnlyUsersQuantity

                    If _WVOnlyUsersQuantity <> -1 AndAlso APIUsersQuantity <> 0 Then

                        _WVOnlyUsersQuantity += 1

                    End If

                Else

                    _PowerUsersQuantity = 0
                    _WVOnlyUsersQuantity = 0
                    ButtonItemSecurityActions_AddUser.SecurityEnabled = False

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ButtonItemActions_Add.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserAdd

                    ButtonItemActions_Save.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemActions_Delete.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemActions_Terminate.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemNotesActions_CheckSpelling.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemSecurityActions_AddUser.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemSecurityActions_ChangePassword.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemEmployee_EmployeeCopy.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemCDP_CDPCopy.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemOffice_OfficeCopy.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemTimesheetFunction_TimesheetFunctionCopy.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemDocuments_Delete.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemDocuments_Download.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemDocuments_OpenURL.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemDocuments_Upload.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemBillingRatesActions_Delete.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate
                    ButtonItemBillingRatesActions_Cancel.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserUpdate

                    ButtonItemActions_Print.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserPrint
                    ButtonItemActions_PrintFiltered.SecurityEnabled = EmployeeControlRightSection_Employee.CanUserPrint

                    ButtonItemImport_Wizard.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Me.Session.Application, AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeImport.ToString, Me.Session.User.ID)
                    ButtonItemImport_PendingRecords.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Me.Session.Application, AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeImport.ToString, Me.Session.User.ID)

                End Using

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            If ButtonItemImport_PendingRecords.SecurityEnabled = False AndAlso ButtonItemImport_Wizard.SecurityEnabled = False Then

                RibbonBarMergeContainerForm_Import.AllowMerge = False

            End If

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Employees.CurrentView.AFActiveFilterString = "[Terminated] = False"

            Catch ex As Exception

            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EmployeeSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Employees.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Employees_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Employees.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Employees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Employees.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

                Try

                    LoadSelectedItemDetails()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow Then

                EmployeeControlRightSection_Employee.LoadRequiredNonGridControlsForValidation()

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If EmployeeControlRightSection_Employee.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Employees.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an employee to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim EmployeeCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeEditDialog.ShowFormDialog(EmployeeCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Employees.SelectRow(EmployeeCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If EmployeeControlRightSection_Employee.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                        'DataGridViewLeftSection_Employees.SetBookmarks()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an employee to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Terminate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Terminate.Click

            If DataGridViewLeftSection_Employees.HasOnlyOneSelectedRow Then

                If CheckForUnsavedChanges() Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying, "Modifying...")

                    Try

                        If EmployeeControlRightSection_Employee.Terminate() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an employee to terminate.")

            End If

        End Sub
        Private Sub EmployeeControlRightSection_Employee_BillingRateDetailInitNewRowEvent() Handles EmployeeControlRightSection_Employee.BillingRateDetailInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_EmployeeOfficesChangedEvent() Handles EmployeeControlRightSection_Employee.EmployeeOfficesChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_EmployeesChangedEvent() Handles EmployeeControlRightSection_Employee.EmployeesChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_CDPsChangedEvent() Handles EmployeeControlRightSection_Employee.CDPsChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_TimesheetFunctionsChangedEvent() Handles EmployeeControlRightSection_Employee.TimesheetFunctionsChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_SelectedBillingRateDetailChanged() Handles EmployeeControlRightSection_Employee.SelectedBillingRateDetailChanged

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_SelectedBillingRateLevelChanged() Handles EmployeeControlRightSection_Employee.SelectedBillingRateLevelChanged

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_SelectedDocumentChanged() Handles EmployeeControlRightSection_Employee.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles EmployeeControlRightSection_Employee.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub EmployeeControlRightSection_Employee_AdditionalEmailsSelectionChangedEvent() Handles EmployeeControlRightSection_Employee.AdditionalEmailsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemNotesActions_CheckSpelling_Click(sender As Object, e As System.EventArgs) Handles ButtonItemNotesActions_CheckSpelling.Click

            EmployeeControlRightSection_Employee.CheckNotesSpelling()

        End Sub
        Private Sub ButtonItemSecurityActions_ChangePassword_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSecurityActions_ChangePassword.Click

            'objects
            Dim UserID As Integer = 0

            Try

                UserID = EmployeeControlRightSection_Employee.SelectedUserID

            Catch ex As Exception
                UserID = 0
            End Try

            If UserID <> 0 Then

                AdvantageFramework.Security.Presentation.ChangePasswordDialog.ShowFormDialog(Me.Session, Security.Presentation.ChangePasswordDialog.PasswordType.All, UserID)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a valid user.")

            End If

        End Sub
        Private Sub ButtonItemSecurityActions_AddUser_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSecurityActions_AddUser.Click

            If _IsAgencyASP = False OrElse AdvantageFramework.Security.LicenseKey.CheckAvailableUsers(Me.Session, AdvantageFramework.Security.LicenseKey.Types.All, _PowerUsersQuantity, _WVOnlyUsersQuantity) Then

                If AdvantageFramework.Security.Setup.Presentation.UserEditDialog.ShowFormDialog(0) = System.Windows.Forms.DialogResult.OK Then

                    EmployeeControlRightSection_Employee.LoadEmployeeUsers()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("There are not enough licenses to add a new user. Please contact software support.")

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Print.Click

            ' objects
            Dim SelectedEmployeeCodes() As String = Nothing

            If EmployeeControlRightSection_Employee.Enabled Then

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
        Private Sub ButtonItemBillingRatesActions_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemBillingRatesActions_Cancel.Click

            EmployeeControlRightSection_Employee.CancelAddBillingRateDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemBillingRatesActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemBillingRatesActions_Delete.Click

            EmployeeControlRightSection_Employee.DeleteBillingRateDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            EmployeeControlRightSection_Employee.DocumentManager.UploadNewDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            EmployeeControlRightSection_Employee.DocumentManager.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            EmployeeControlRightSection_Employee.DocumentManager.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            EmployeeControlRightSection_Employee.DocumentManager.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            EmployeeControlRightSection_Employee.DocumentManager.DeleteSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemImport_Wizard_Click(sender As Object, e As EventArgs) Handles ButtonItemImport_Wizard.Click

            If AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeImportWizardDialog.ShowWizardDialog() = Windows.Forms.DialogResult.OK Then

                Try

                    If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeImportStagingForm)) = False Then

                        AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeImportStagingForm.ShowForm()

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ButtonItemImport_PendingRecords_Click(sender As Object, e As EventArgs) Handles ButtonItemImport_PendingRecords.Click

            Try

                If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeImportStagingForm)) = False Then

                    AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeImportStagingForm.ShowForm()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemOfficeCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemOfficeCopy_CopyFrom.Click

            EmployeeControlRightSection_Employee.EmployeeOfficeLimitControl.CopyOfficeLimits(False)

        End Sub
        Private Sub ButtonItemOfficeCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemOfficeCopy_CopyTo.Click

            EmployeeControlRightSection_Employee.EmployeeOfficeLimitControl.CopyOfficeLimits(True)

        End Sub
        Private Sub ButtonItemCDPCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemCDPCopy_CopyFrom.Click

            EmployeeControlRightSection_Employee.UserCDPLimitControl.CopyCDPLimits(False)

        End Sub
        Private Sub ButtonItemCDPCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemCDPCopy_CopyTo.Click

            EmployeeControlRightSection_Employee.UserCDPLimitControl.CopyCDPLimits(True)

        End Sub
        Private Sub ButtonItemEmployeeCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemEmployeeCopy_CopyFrom.Click

            EmployeeControlRightSection_Employee.UserEmployeeLimitControl.CopyEmployeeLimits(False)

        End Sub
        Private Sub ButtonItemEmployeeCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemEmployeeCopy_CopyTo.Click

            EmployeeControlRightSection_Employee.UserEmployeeLimitControl.CopyEmployeeLimits(True)

        End Sub
        Private Sub ButtonItemTimesheetFunctionCopy_CopyFrom_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemTimesheetFunctionCopy_CopyFrom.Click

            EmployeeControlRightSection_Employee.EmployeeTimesheetFunctionLimitsControl.CopyFunctionLimits(False)

        End Sub
        Private Sub ButtonItemTimesheetFunctionCopy_CopyTo_Click(sender As Object, e As System.EventArgs) Handles ButtonItemTimesheetFunctionCopy_CopyTo.Click

            EmployeeControlRightSection_Employee.EmployeeTimesheetFunctionLimitsControl.CopyFunctionLimits(True)

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm()

                Try

                    EmployeeControlRightSection_Employee.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                DataGridViewLeftSection_Employees.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemHRHistory_View_Click(sender As Object, e As EventArgs) Handles ButtonItemHRHistory_View.Click

            'objects
            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing

            ParameterDictionary = New Dictionary(Of String, Object)

            ParameterDictionary("EmployeeCode") = DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue

            AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.EmployeeHRHistory, False, True, ParameterDictionary:=ParameterDictionary)

        End Sub
        Private Sub ButtonItemCostRateAndDepartmentTeam_Update_Click(sender As Object, e As EventArgs) Handles ButtonItemCostRateAndDepartmentTeam_Update.Click

            AdvantageFramework.Maintenance.Accounting.Presentation.CostRateForm.ShowFormDialog(DataGridViewLeftSection_Employees.GetFirstSelectedRowBookmarkValue)

        End Sub
        Private Sub ButtonItemAdditionalEmails_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemAdditionalEmails_Add.Click

            EmployeeControlRightSection_Employee.AddAdditionalEmail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemAdditionalEmails_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemAdditionalEmails_Delete.Click

            EmployeeControlRightSection_Employee.DeleteAdditionalEmail()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
