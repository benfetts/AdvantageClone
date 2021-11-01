Namespace Maintenance.Management.Presentation

    Public Class OverheadAccountSetupForm

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

            'objects
            Dim GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                DataGridViewLeftSection_OverheadAccounts.DataSource = (From Entity In AdvantageFramework.Database.Procedures.OverheadAccount.Load(DbContext).ToList
                                                                       Where GeneralLedgerAccounts.Any(Function(GLA) GLA.Code >= Entity.FromGLACode AndAlso GLA.Code <= Entity.ToGLACode) = True
                                                                       Select Entity).GroupBy(Function(Entity) Entity.Code).Select(Of AdvantageFramework.Database.Entities.OverheadAccount)(Function(GEntity) GEntity.FirstOrDefault).ToList

            End Using

            DataGridViewLeftSection_OverheadAccounts.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            OverheadAccountControlRightSection_OverheadAccount.ClearControl()

            OverheadAccountControlRightSection_OverheadAccount.Enabled = DataGridViewLeftSection_OverheadAccounts.HasOnlyOneSelectedRow

            If OverheadAccountControlRightSection_OverheadAccount.Enabled Then

                OverheadAccountControlRightSection_OverheadAccount.Enabled = OverheadAccountControlRightSection_OverheadAccount.LoadControl(DataGridViewLeftSection_OverheadAccounts.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            OverheadAccountControlRightSection_OverheadAccount.Enabled = (DataGridViewLeftSection_OverheadAccounts.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_OverheadAccounts.HasOnlyOneSelectedRow AndAlso OverheadAccountControlRightSection_OverheadAccount.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemDetails_Cancel.Enabled = (OverheadAccountControlRightSection_OverheadAccount.Enabled AndAlso OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsIsNewItemRow(OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsFocusedRowHandle))

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = OverheadAccountControlRightSection_OverheadAccount.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If Not IsOkay AndAlso AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                            IsOkay = False

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
            Dim OverheadAccountSetupForm As AdvantageFramework.Maintenance.Management.Presentation.OverheadAccountSetupForm = Nothing

            OverheadAccountSetupForm = New AdvantageFramework.Maintenance.Management.Presentation.OverheadAccountSetupForm

            OverheadAccountSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub OverheadAccountSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_OverheadAccounts.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub OverheadAccountSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub OverheadAccountSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub OverheadAccountSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_OverheadAccounts.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_OverheadAccounts_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_OverheadAccounts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_OverheadAccounts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_OverheadAccounts.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If DataGridViewLeftSection_OverheadAccounts.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If OverheadAccountControlRightSection_OverheadAccount.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_OverheadAccounts.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an Overhead Account to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim OverheadAccountCode As String = Nothing
            Dim CanAdd As Boolean = True

            If DataGridViewLeftSection_OverheadAccounts.HasOnlyOneSelectedRow Then

                CanAdd = CheckForUnsavedChanges()

            End If

            If CanAdd Then

                If AdvantageFramework.Maintenance.Management.Presentation.OverheadAccountEditDialog.ShowFormDialog(OverheadAccountCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_OverheadAccounts.SelectRow(OverheadAccountCode)

                Else

                    LoadSelectedItemDetails()

                End If

            End If


        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_OverheadAccounts.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If OverheadAccountControlRightSection_OverheadAccount.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an Overhead Account to delete.")

            End If

        End Sub
        Private Sub OverheadAccountControlRightSection_OverheadAccount_OverheadDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsInitNewRowEvent

            ButtonItemDetails_Cancel.Enabled = True
            ButtonItemDetails_Delete.Enabled = False

        End Sub
        Private Sub OverheadAccountControlRightSection_OverheadAccount_OverheadDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsSelectionChangedEvent

            If OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsHasOnlyOneSelectedRow(False) Then

                If OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsIsNewItemRow(OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsFocusedRowHandle) Then

                    ButtonItemDetails_Cancel.Enabled = True
                    ButtonItemDetails_Delete.Enabled = False

                Else

                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Delete.Enabled = True

                End If

            Else

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsHasRows

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            OverheadAccountControlRightSection_OverheadAccount.OverheadAccountDetailsCancelNewItemRow()

            If OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsHasOnlyOneSelectedRow() = True Then

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsHasRows

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            OverheadAccountControlRightSection_OverheadAccount.DeleteOverheadAccountDetails()

            If OverheadAccountControlRightSection_OverheadAccount.OverheadDetailsHasRows = False Then

                LoadGrid()

                LoadSelectedItemDetails()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace