Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GLReportAccountGroupSetupForm

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

                DataGridViewLeftSection_AccountGroups.DataSource = AdvantageFramework.Database.Procedures.AccountGroup.Load(DbContext)

            End Using

            DataGridViewLeftSection_AccountGroups.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                AccountGroupControlRightSection_AccountGroup.ClearControl()

                AccountGroupControlRightSection_AccountGroup.Enabled = DataGridViewLeftSection_AccountGroups.HasOnlyOneSelectedRow

                If AccountGroupControlRightSection_AccountGroup.Enabled Then

                    AccountGroupControlRightSection_AccountGroup.Enabled = AccountGroupControlRightSection_AccountGroup.LoadControl(DataGridViewLeftSection_AccountGroups.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            AccountGroupControlRightSection_AccountGroup.Enabled = (DataGridViewLeftSection_AccountGroups.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_AccountGroups.HasOnlyOneSelectedRow AndAlso AccountGroupControlRightSection_AccountGroup.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Print.Enabled = (DataGridViewLeftSection_AccountGroups.HasASelectedRow AndAlso Me.FormShown)
            ButtonItemActions_PrintFiltered.Enabled = DataGridViewLeftSection_AccountGroups.HasRows

            ButtonItemDetails_Cancel.Enabled = AccountGroupControlRightSection_AccountGroup.DataGridViewControl_AccountGroupDetails.IsNewItemRow
            ButtonItemDetails_Delete.Enabled = AccountGroupControlRightSection_AccountGroup.DataGridViewControl_AccountGroupDetails.HasASelectedRow

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim DetailsValid As Boolean = True
            Dim ErrorMessage As String = ""

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    ErrorMessage = AccountGroupControlRightSection_AccountGroup.ValidateDetails(DetailsValid)

                    IsOkay = Me.Validator AndAlso DetailsValid

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = AccountGroupControlRightSection_AccountGroup.Save()

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

                    Else

                        If ErrorMessage <> "" Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage, WinForm.MessageBox.MessageBoxButtons.OK)

                        End If

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""
            Dim DetailsValid As Boolean = True

            If DataGridViewLeftSection_AccountGroups.HasOnlyOneSelectedRow Then

                ErrorMessage = AccountGroupControlRightSection_AccountGroup.ValidateDetails(DetailsValid)

                If Me.Validator AndAlso DetailsValid Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If AccountGroupControlRightSection_AccountGroup.Save() Then

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

                        DataGridViewLeftSection_AccountGroups.FocusToFindPanel(False)

                        DataGridViewLeftSection_AccountGroups.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an account group to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim GLReportAccountGroupSetupForm As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportAccountGroupSetupForm = Nothing

            GLReportAccountGroupSetupForm = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportAccountGroupSetupForm()

            GLReportAccountGroupSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub GLReportAccountGroupSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage

            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemFilter_ShowInactive.Image = AdvantageFramework.My.Resources.FilterImage

            DataGridViewLeftSection_AccountGroups.MultiSelect = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub GLReportAccountGroupSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub GLReportAccountGroupSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub GLReportAccountGroupSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_AccountGroups.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_AccountGroups_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_AccountGroups.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AccountGroups_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_AccountGroups.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim AccountGroupCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_AccountGroups.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportAccountGroupEditDialog.ShowFormDialog(AccountGroupCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_AccountGroups.SelectRow(AccountGroupCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_AccountGroups.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_AccountGroups.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this group?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If AccountGroupControlRightSection_AccountGroup.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_AccountGroups.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an account group to delete.")

            End If

        End Sub
        Private Sub AccountGroupControlRightSection_AccountGroup_SelectedAccountGroupDetailChangedEvent() Handles AccountGroupControlRightSection_AccountGroup.SelectedAccountGroupDetailChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Cancel.Click

            AccountGroupControlRightSection_AccountGroup.DetailsDataGridView.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            AccountGroupControlRightSection_AccountGroup.DeleteSelectedDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim SelectedAccoungGroupCodes() As String = Nothing

            Try

                If DataGridViewLeftSection_AccountGroups.HasASelectedRow Then

                    SelectedAccoungGroupCodes = DataGridViewLeftSection_AccountGroups.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Database.Procedures.AccountGroup.Load(DbContext)
                                                             Where SelectedAccoungGroupCodes.Contains(Entity.Code)
                                                             Select Entity).ToList

                    End Using

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.GLAccountGroup, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemActions_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintFiltered.Click

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim AccoungGroupCodes() As String = Nothing

            Try

                If DataGridViewLeftSection_AccountGroups.HasASelectedRow Then

                    AccoungGroupCodes = DataGridViewLeftSection_AccountGroups.GetAllRowsBookmarkValues.OfType(Of String).ToArray

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Database.Procedures.AccountGroup.Load(DbContext)
                                                             Where AccoungGroupCodes.Contains(Entity.Code)
                                                             Select Entity).ToList

                    End Using

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.GLAccountGroup, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemFilter_ShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_ShowInactive.CheckedChanged

            AccountGroupControlRightSection_AccountGroup.ShowInactiveAccounts = ButtonItemFilter_ShowInactive.Checked

        End Sub

#End Region

#End Region

    End Class

End Namespace
