Namespace Maintenance.Accounting.Presentation

    Public Class VendorContactSetupForm

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
            Dim VendorContactsList As Generic.List(Of AdvantageFramework.Database.Entities.VendorContact) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                VendorContactsList = AdvantageFramework.Database.Procedures.VendorContact.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                DataGridViewLeftSection_VendorContacts.DataSource = VendorContactsList
                DataGridViewLeftSection_ExportVendorContacts.DataSource = VendorContactsList.Select(Function(Entity) New AdvantageFramework.Database.Classes.VendorContactExport(DbContext, Entity)).ToList

                DataGridViewLeftSection_VendorContacts.CurrentView.BestFitColumns()
                DataGridViewLeftSection_ExportVendorContacts.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            Dim VendorContactCode As String = Nothing
            Dim VendorCode As String = Nothing
            Dim VendorAndVendorContactCode As String = Nothing

            VendorContactControlRightSection_VendorContact.ClearControl()

            VendorContactControlRightSection_VendorContact.Enabled = DataGridViewLeftSection_VendorContacts.HasOnlyOneSelectedRow

            If VendorContactControlRightSection_VendorContact.Enabled Then

                VendorAndVendorContactCode = DataGridViewLeftSection_VendorContacts.GetFirstSelectedRowBookmarkValue

                For Each Code In VendorAndVendorContactCode.Split("|")

                    If VendorCode Is Nothing Then

                        VendorCode = Code

                    Else

                        VendorContactCode = Code

                    End If

                Next

                VendorContactControlRightSection_VendorContact.Enabled = VendorContactControlRightSection_VendorContact.LoadControl(VendorCode, VendorContactCode)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            VendorContactControlRightSection_VendorContact.Enabled = (DataGridViewLeftSection_VendorContacts.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_VendorContacts.HasOnlyOneSelectedRow AndAlso VendorContactControlRightSection_VendorContact.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            VendorContactControlRightSection_VendorContact.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

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
            Dim VendorContactSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactSetupForm = Nothing

            VendorContactSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactSetupForm()

            VendorContactSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorContactSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewLeftSection_VendorContacts.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_VendorContacts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub VendorContactSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorContactSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorContactSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_VendorContacts.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_VendorContacts_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_VendorContacts.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorContacts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_VendorContacts.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_VendorContacts.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        VendorContactControlRightSection_VendorContact.Save()

                        Me.ClearChanged()

                        LoadGrid()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_VendorContacts.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor contact to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_VendorContacts.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        VendorContactControlRightSection_VendorContact.Delete()

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor contact to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim VendorCode As String = Nothing
            Dim VendorContactCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_VendorContacts.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If DataGridViewLeftSection_VendorContacts.HasASelectedRow Then

                    Try

                        VendorCode = DataGridViewLeftSection_VendorContacts.GetFirstSelectedRowDataBoundItem.VendorCode

                    Catch ex As Exception
                        VendorCode = Nothing
                    End Try

                End If

                If AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactEditDialog.ShowFormDialog(VendorCode, VendorContactCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_VendorContacts.SelectRow(VendorCode & "|" & VendorContactCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            DataGridViewLeftSection_ExportVendorContacts.CurrentView.AFActiveFilterString = DataGridViewLeftSection_VendorContacts.CurrentView.AFActiveFilterString
            DataGridViewLeftSection_ExportVendorContacts.CurrentView.ApplyFindFilter(DataGridViewLeftSection_VendorContacts.CurrentView.FindFilterText)

            DataGridViewLeftSection_ExportVendorContacts.CurrentView.BestFitColumns()

            DataGridViewLeftSection_ExportVendorContacts.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            Dim VendorContactCode As String = Nothing

            If DataGridViewLeftSection_VendorContacts.HasOnlyOneSelectedRow Then

                VendorContactCode = DataGridViewLeftSection_VendorContacts.GetFirstSelectedRowBookmarkValue

                DataGridViewLeftSection_ExportVendorContacts.CurrentView.AFActiveFilterString = "[ID] = '" & VendorContactCode & "'"

                DataGridViewLeftSection_ExportVendorContacts.CurrentView.BestFitColumns()

                DataGridViewLeftSection_ExportVendorContacts.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Processing...")

                Try

                    VendorContactControlRightSection_VendorContact.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_VendorContacts.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
