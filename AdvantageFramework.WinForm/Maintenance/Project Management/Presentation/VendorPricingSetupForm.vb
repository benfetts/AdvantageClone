Namespace Maintenance.ProjectManagement.Presentation

    Public Class VendorPricingSetupForm

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

                DataGridViewLeftSection_Vendors.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadActiveByCategoryWithOfficeLimits(DbContext, Me.Session, "P")

            End Using

            DataGridViewLeftSection_Vendors.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim VendorCode As String = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                VendorPricingControlRightSection_VendorPricing.ClearControl()

                VendorPricingControlRightSection_VendorPricing.Enabled = DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow

                If VendorPricingControlRightSection_VendorPricing.Enabled Then

                    VendorCode = DataGridViewLeftSection_Vendors.CurrentView.GetRowCellValue(DataGridViewLeftSection_Vendors.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Vendor.Properties.Code.ToString)

                    VendorPricingControlRightSection_VendorPricing.Enabled = VendorPricingControlRightSection_VendorPricing.LoadControl(VendorCode)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            VendorPricingControlRightSection_VendorPricing.Enabled = (DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If VendorPricingControlRightSection_VendorPricing.Enabled Then

                ButtonItemActions_Delete.Enabled = VendorPricingControlRightSection_VendorPricing.HasASelectedPricing
                ButtonItemActions_Cancel.Enabled = VendorPricingControlRightSection_VendorPricing.IsNewItemRow

            Else

                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False
                ButtonItemActions_Cancel.Enabled = False

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

                            IsOkay = VendorPricingControlRightSection_VendorPricing.Save()

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

            If DataGridViewLeftSection_Vendors.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If VendorPricingControlRightSection_VendorPricing.Save() Then

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

                        DataGridViewLeftSection_Vendors.FocusToFindPanel(False)

                        DataGridViewLeftSection_Vendors.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VendorPricingSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.VendorPricingSetupForm = Nothing

            VendorPricingSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.VendorPricingSetupForm

            VendorPricingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorPricingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_Vendors.MultiSelect = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Vendors.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub VendorPricingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorPricingSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorPricingSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Vendors.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            VendorPricingControlRightSection_VendorPricing.Delete()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            VendorPricingControlRightSection_VendorPricing.CancelAddVendorPricing()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_Vendors_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Vendors.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Vendors_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Vendors.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub VendorPricingControlRightSection_VendorPricing_VendorPricingSelectionChangedEvent() Handles VendorPricingControlRightSection_VendorPricing.VendorPricingSelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
