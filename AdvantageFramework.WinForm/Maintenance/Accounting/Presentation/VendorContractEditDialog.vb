Namespace Maintenance.Accounting.Presentation

    Public Class VendorContractEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ContractID As Integer = 0
        Private _VendorCode As String = Nothing
        Private _IsCopy As Boolean = Nothing

#End Region

#Region " Properties "

        Public Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        Public Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
            Set(value As Boolean)
                _IsCopy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef VendorCode As String, ByRef ContractID As Integer, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ContractID = ContractID
            _VendorCode = VendorCode
            _IsCopy = IsCopy

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If _IsCopy = True OrElse _ContractID = 0 Then

                ButtonItemActions_Copy.Visible = False

            End If

            RibbonBarOptions_Documents.Visible = If(VendorContractControlForm_Contract.SelectedTab Is VendorContractControlForm_Contract.TabItemContractSetup_DocumentsTab, True, False)

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = VendorContractControlForm_Contract.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(VendorContractControlForm_Contract.DocumentManager.HasOnlyOneSelectedDocument, Not VendorContractControlForm_Contract.DocumentManager.IsSelectedDocumentAURL, VendorContractControlForm_Contract.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(VendorContractControlForm_Contract.DocumentManager.HasOnlyOneSelectedDocument, VendorContractControlForm_Contract.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = VendorContractControlForm_Contract.DocumentManager.CanUpload

            End If

            RibbonBarOptions_Contacts.Visible = If(VendorContractControlForm_Contract.SelectedTab Is VendorContractControlForm_Contract.TabItemContractSetup_InternalContactsTab, True, False)

            If RibbonBarOptions_Contacts.Visible Then

                ButtonItemInternalContacts_Cancel.Enabled = VendorContractControlForm_Contract.DataGridViewInternalContacts_Contacts.IsNewItemRow
                ButtonItemInternalContacts_Delete.Enabled = VendorContractControlForm_Contract.DataGridViewInternalContacts_Contacts.HasOnlyOneSelectedRow

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

                            IsOkay = VendorContractControlForm_Contract.Save()

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
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If VendorContractControlForm_Contract.Save() Then

                        Me.ClearChanged()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If ErrorMessage = "" Then

                    Saved = True

                End If

            Else

                For Each LastFailedValidationResult In SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function
        Private Sub ShowSpellChecker(Visible As Boolean)

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = Visible

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef VendorCode As String, Optional ByVal ContractID As Integer = 0, Optional ByVal IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim VendorContractEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.VendorContractEditDialog = Nothing

            VendorContractEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorContractEditDialog(VendorCode, ContractID, IsCopy)

            ShowFormDialog = VendorContractEditDialog.ShowDialog()

            VendorCode = VendorContractEditDialog.VendorCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorContractEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorContractEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

			ButtonItemInternalContacts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemInternalContacts_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemDocuments_Upload.SplitButton = False

				End If

			End Using

			If _IsCopy OrElse _ContractID = 0 Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False

            ElseIf _ContractID <> 0 Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True
                ButtonItemActions_Delete.Visible = True

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False

            End If

            ButtonItemActions_Add.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance
            ButtonItemActions_Save.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance
            ButtonItemActions_Delete.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance
            ButtonItemActions_Copy.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance

            ButtonItemDocuments_Delete.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance
            ButtonItemDocuments_Upload.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance

            ButtonItemInternalContacts_Delete.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance

            ButtonItemText_CheckSpelling.SecurityEnabled = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance

            Me.ShowUnsavedChangesOnFormClosing = VendorContractControlForm_Contract.CanUserUpdateInVendorMaintenance

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    ButtonItemDocuments_OpenURL.SecurityEnabled = False

                Else

                    ButtonItemDocuments_OpenURL.SecurityEnabled = True

                End If

            End Using

            If VendorContractControlForm_Contract.LoadControl(_VendorCode, _ContractID, _IsCopy) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The contract you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub VendorContractEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _ContractID = 0 Then

                VendorContractControlForm_Contract.TextBoxGeneral_Code.Focus()

            End If

        End Sub
        Private Sub VendorContractEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Dim VendorCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If VendorContractControlForm_Contract.Insert(VendorCode) Then

                        _VendorCode = VendorCode

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            Dim ContractID As Integer = 0
            Dim VendorCode As String = Nothing
            Dim ContinueCopy As Boolean = Nothing

            ContinueCopy = CheckForUnsavedChanges()

            If ContinueCopy Then

                VendorCode = _VendorCode
                ContractID = _ContractID

                If AdvantageFramework.Maintenance.Accounting.Presentation.VendorContractEditDialog.ShowFormDialog(VendorCode, ContractID, True) = Windows.Forms.DialogResult.OK Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                Try

                    If VendorContractControlForm_Contract.Delete Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            VendorContractControlForm_Contract.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            VendorContractControlForm_Contract.DownloadDocument()

            EnableOrDisableActions()

        End Sub
		Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

			VendorContractControlForm_Contract.UploadDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			VendorContractControlForm_Contract.SendASPUploadEmail()

		End Sub
		Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            VendorContractControlForm_Contract.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub VendorContractControlForm_Contract_ContractContactInitNewRowEvent() Handles VendorContractControlForm_Contract.ContractContactInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub VendorContractControlForm_Contract_ContractContactSelectionChangedEvent() Handles VendorContractControlForm_Contract.ContractContactSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub VendorContractControlForm_Contract_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles VendorContractControlForm_Contract.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso _ContractID <> 0 AndAlso Not _IsCopy Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub VendorContractControlForm_Contract_SelectedDocumentChanged() Handles VendorContractControlForm_Contract.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub VendorContractControlForm_Contract_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles VendorContractControlForm_Contract.SelectedTabChanging

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemInternalContacts_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemInternalContacts_Cancel.Click

            VendorContractControlForm_Contract.CancelAddNewContractContact()

        End Sub
        Private Sub ButtonItemInternalContacts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemInternalContacts_Delete.Click

            VendorContractControlForm_Contract.DeleteSelectedContractContact()

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf VendorContractControlForm_Contract.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(VendorContractControlForm_Contract.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub VendorContractControlForm_Contract_CommentsGotFocusEvent(sender As Object, e As EventArgs) Handles VendorContractControlForm_Contract.CommentsGotFocusEvent

            ShowSpellChecker(True)

        End Sub
        Private Sub VendorContractControlForm_Contract_CommentsLostFocusEvent(sender As Object, e As EventArgs) Handles VendorContractControlForm_Contract.CommentsLostFocusEvent

            ShowSpellChecker(False)

        End Sub

#End Region

#End Region

    End Class

End Namespace