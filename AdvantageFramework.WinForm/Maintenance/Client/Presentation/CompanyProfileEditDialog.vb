Namespace Maintenance.Client.Presentation

    Public Class CompanyProfileEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemAffiliations_Cancel.Enabled = CompanyProfileControlForm_CompanyProfile.AffiliationsIsNewItemRow
            ButtonItemAffiliations_Delete.Enabled = CompanyProfileControlForm_CompanyProfile.AffiliationsHasOnlyOneSelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim CompanyProfileEditDialog As AdvantageFramework.Maintenance.Client.Presentation.CompanyProfileEditDialog = Nothing

            CompanyProfileEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.CompanyProfileEditDialog(ClientCode, DivisionCode, ProductCode)

            ShowFormDialog = CompanyProfileEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CompanyProfileEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemAffiliations_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemAffiliations_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemActions_Save.SecurityEnabled = CompanyProfileControlForm_CompanyProfile.CanUserUpdateInClientMaintenance
            ButtonItemAffiliations_Delete.SecurityEnabled = CompanyProfileControlForm_CompanyProfile.CanUserUpdateInClientMaintenance
            ButtonItemText_CheckSpelling.SecurityEnabled = CompanyProfileControlForm_CompanyProfile.CanUserUpdateInClientMaintenance

            Me.ShowUnsavedChangesOnFormClosing = CompanyProfileControlForm_CompanyProfile.CanUserUpdateInClientMaintenance

            CompanyProfileControlForm_CompanyProfile.LoadControl(_ClientCode, _DivisionCode, _ProductCode)

            EnableOrDisableActions()

        End Sub
        Private Sub CompanyProfileEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CompanyProfileControlForm_CompanyProfile.SearchableComboBoxCompanyProfile_Industry.Focus()

        End Sub
        Private Sub CompanyProfileEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CompanyProfileEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm("Saving...")

                Try

                    If CompanyProfileControlForm_CompanyProfile.Save() Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemAffiliations_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemAffiliations_Cancel.Click

            CompanyProfileControlForm_CompanyProfile.CancelAddNewCompanyProfileAffiliation()

        End Sub
        Private Sub ButtonItemAffiliations_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemAffiliations_Delete.Click

            CompanyProfileControlForm_CompanyProfile.DeleteSelectedCompanyProfileAffiliation()

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf CompanyProfileControlForm_CompanyProfile.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(CompanyProfileControlForm_CompanyProfile.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub CompanyProfileControlForm_CompanyProfile_AffiliationInitNewRowEvent() Handles CompanyProfileControlForm_CompanyProfile.AffiliationInitNewRowEvent

            ButtonItemAffiliations_Delete.Enabled = False
            ButtonItemAffiliations_Cancel.Enabled = True

        End Sub
        Private Sub CompanyProfileControlForm_CompanyProfile_AffiliationSelectionChangedEvent() Handles CompanyProfileControlForm_CompanyProfile.AffiliationSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub CompanyProfileControlForm_CompanyProfile_NotesGotFocusEvent(sender As Object, e As EventArgs) Handles CompanyProfileControlForm_CompanyProfile.NotesGotFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub CompanyProfileControlForm_CompanyProfile_NotesLostFocusEvent(sender As Object, e As EventArgs) Handles CompanyProfileControlForm_CompanyProfile.NotesLostFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace