Namespace Maintenance.Accounting.Presentation

    Public Class BankSetupForm

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

                DataGridViewLeftSection_Banks.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadWithOfficeLimits(DbContext, Me.Session)

            End Using

            DataGridViewLeftSection_Banks.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                BankControlRightSection_Bank.ClearControl()

                BankControlRightSection_Bank.Enabled = DataGridViewLeftSection_Banks.HasOnlyOneSelectedRow

                If BankControlRightSection_Bank.Enabled Then

                    BankControlRightSection_Bank.Enabled = BankControlRightSection_Bank.LoadControl(DataGridViewLeftSection_Banks.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            BankControlRightSection_Bank.Enabled = (DataGridViewLeftSection_Banks.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Banks.HasOnlyOneSelectedRow AndAlso BankControlRightSection_Bank.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    BankControlRightSection_Bank.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = BankControlRightSection_Bank.Save()

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
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing

            If DataGridViewLeftSection_Banks.HasOnlyOneSelectedRow Then

                BankControlRightSection_Bank.LoadRequiredNonGridControlsForValidation()

                TabItem = BankControlRightSection_Bank.TabControlControl_BankDetails.SelectedTab

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If BankControlRightSection_Bank.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_Banks.FocusToFindPanel(False)

                        DataGridViewLeftSection_Banks.CurrentView.GridViewSelectionChanged()

                        If TabItem Is BankControlRightSection_Bank.TabItemBankDetails_PaymentManager AndAlso BankControlRightSection_Bank.TabItemBankDetails_PaymentManager.Visible Then

                            If BankControlRightSection_Bank.TabControlControl_BankDetails.SelectedTab IsNot TabItem Then

                                BankControlRightSection_Bank.TabControlControl_BankDetails.SelectedTab = BankControlRightSection_Bank.TabItemBankDetails_PaymentManager

                            End If

                        End If

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a bank to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim BankSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.BankSetupForm = Nothing

            BankSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.BankSetupForm()

            BankSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BankSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewLeftSection_Banks.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Banks.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub BankSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub BankSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub BankSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Banks.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Banks_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Banks.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Banks_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Banks.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim Codes As Generic.List(Of String) = Nothing
            Dim Banks As Generic.List(Of AdvantageFramework.Database.Entities.Bank) = Nothing

            Codes = DataGridViewLeftSection_Banks.GetAllRowsBookmarkValues().OfType(Of String).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Banks = AdvantageFramework.Database.Procedures.Bank.Load(DbContext).ToList.Where(Function(Entity) Codes.Contains(Entity.Code) = True).ToList

                DataGridViewLeftSection_BankExport.DataSource = (From Entity In Banks
                                                                 Select New With {.Code = Entity.Code,
                                                                                  .Description = Entity.Description,
                                                                                  .CurrencyCode = Entity.CurrencyCode,
                                                                                  .AccountNumber = Entity.AccountNumber,
                                                                                  .RoutingNumber = Entity.RoutingNumber,
                                                                                  .ACHCompanyID = Entity.ACHCompanyID,
                                                                                  .LastComputerCheck = Entity.LastComputerCheck,
                                                                                  .LastManualCheck = Entity.LastManualCheck,
                                                                                  .ARCashAccount = Entity.ARCashAccount,
                                                                                  .APCashAccount = Entity.APCashAccount,
                                                                                  .APDiscAccount = Entity.APDiscAccount,
                                                                                  .ServiceChargeAccount = Entity.ServiceChargeGLAccount,
                                                                                  .InterestEarnedAccount = Entity.InterestEarnedGLAccount}).ToList

            End Using

            If DataGridViewLeftSection_BankExport.Columns("ACHCompanyID") IsNot Nothing Then

                DataGridViewLeftSection_BankExport.Columns("ACHCompanyID").Caption = "ACH Company ID"

            End If

            If DataGridViewLeftSection_BankExport.Columns("ARCashAccount") IsNot Nothing Then

                DataGridViewLeftSection_BankExport.Columns("ARCashAccount").Caption = "AR Cash Account"

            End If

            If DataGridViewLeftSection_BankExport.Columns("APCashAccount") IsNot Nothing Then

                DataGridViewLeftSection_BankExport.Columns("APCashAccount").Caption = "AP Cash Account"

            End If

            If DataGridViewLeftSection_BankExport.Columns("APDiscAccount") IsNot Nothing Then

                DataGridViewLeftSection_BankExport.Columns("APDiscAccount").Caption = "AP Disc Account"

            End If

            DataGridViewLeftSection_BankExport.CurrentView.BestFitColumns()

            DataGridViewLeftSection_BankExport.Print(Me.DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim BankCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Banks.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.BankEditDialog.ShowFormDialog(BankCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_Banks.SelectRow(BankCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Banks.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Banks.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If BankControlRightSection_Bank.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_Banks.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a bank to delete.")

            End If

        End Sub
        Private Sub BankControlRightSection_Bank_InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean) Handles BankControlRightSection_Bank.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Processing...")

                Try

                    BankControlRightSection_Bank.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Banks.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace