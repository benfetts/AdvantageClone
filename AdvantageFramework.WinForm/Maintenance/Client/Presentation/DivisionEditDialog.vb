Namespace Maintenance.Client.Presentation

    Public Class DivisionEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Private ReadOnly Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        Private ReadOnly Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(FromMaintenance As Boolean, ByRef ClientCode As String, ByRef DivisionCode As String, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _IsCopy = IsCopy
            _FromMaintenance = FromMaintenance

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            RibbonBarOptions_Product.Visible = If(DivisionControlForm_Division.SelectedTab Is DivisionControlForm_Division.TabItemDivisionDetails_ProductsTab, True, False)

            RibbonBarOptions_Documents.Visible = If(DivisionControlForm_Division.SelectedTab Is DivisionControlForm_Division.TabItemDivisionDetails_DocumentsTab, True, False)

            RibbonBarOptions_Contracts.Visible = If(DivisionControlForm_Division.SelectedTab Is DivisionControlForm_Division.TabItemDivisionDetails_ContractsTab, True, False)

            RibbonBarOptions_Contacts.Visible = If(DivisionControlForm_Division.SelectedTab Is DivisionControlForm_Division.TabItemDivisionDetails_ContactsTab, True, False)

            If RibbonBarOptions_Contacts.Visible Then

                ButtonItemContacts_Edit.Enabled = DivisionControlForm_Division.ClientContactManagerControlContacts_DivisionContacts.HasOnlyOneSelectedContact
                ButtonItemContacts_Delete.Enabled = DivisionControlForm_Division.ClientContactManagerControlContacts_DivisionContacts.HasOnlyOneSelectedContact

            End If

            If DivisionControlForm_Division.SelectedTab Is DivisionControlForm_Division.TabItemDivisionDetails_GeneralTab Then

                If DivisionControlForm_Division.TabControlGeneral_General.SelectedTab Is DivisionControlForm_Division.TabItemGeneral_OptionsTab Then

                    RibbonBarOptions_SortOptions.Visible = True
                    ButtonItemSortOptions_Cancel.Enabled = DivisionControlForm_Division.DataGridViewOptions_SortOptions.IsNewItemRow
                    ButtonItemSortOptions_Delete.Enabled = DivisionControlForm_Division.DataGridViewOptions_SortOptions.HasOnlyOneSelectedRow

                Else

                    RibbonBarOptions_SortOptions.Visible = False
                    ButtonItemSortOptions_Cancel.Enabled = False
                    ButtonItemSortOptions_Delete.Enabled = False

                End If

            Else

                RibbonBarOptions_SortOptions.Visible = False
                ButtonItemSortOptions_Cancel.Enabled = False
                ButtonItemSortOptions_Delete.Enabled = False

            End If

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = DivisionControlForm_Division.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(DivisionControlForm_Division.DocumentManager.HasOnlyOneSelectedDocument, Not DivisionControlForm_Division.DocumentManager.IsSelectedDocumentAURL, DivisionControlForm_Division.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(DivisionControlForm_Division.DocumentManager.HasOnlyOneSelectedDocument, DivisionControlForm_Division.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = DivisionControlForm_Division.DocumentManager.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            If RibbonBarOptions_Contracts.Visible Then

                ButtonItemContracts_Copy.Enabled = DivisionControlForm_Division.ContractManager.HasOnlyOneSelectedContract
                ButtonItemContracts_Edit.Enabled = DivisionControlForm_Division.ContractManager.HasOnlyOneSelectedContract
                ButtonItemContracts_Delete.Enabled = DivisionControlForm_Division.ContractManager.HasOnlyOneSelectedContract

            End If

            If RibbonBarOptions_Product.Visible Then

                ButtonItemProduct_Delete.Enabled = DivisionControlForm_Division.DataGridViewProducts_Products.HasOnlyOneSelectedRow
                ButtonItemProduct_Edit.Enabled = DivisionControlForm_Division.DataGridViewProducts_Products.HasOnlyOneSelectedRow

            End If

            If DivisionControlForm_Division.IsCRMUser AndAlso DivisionControlForm_Division.CheckBoxGeneral_NewBusiness.Checked = False Then

                ButtonItemProduct_Add.Enabled = False
                ButtonItemActions_Copy.Enabled = False

            Else

                ButtonItemProduct_Add.Enabled = True
                ButtonItemActions_Copy.Enabled = True

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

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = DivisionControlForm_Division.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.CloseWaitForm()
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

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

                Me.ShowWaitForm("Saving...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If DivisionControlForm_Division.Save() Then

                        Me.ClearChanged()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                If ErrorMessage = "" Then

                    Saved = True

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(FromMaintenance As Boolean, Optional ByRef ClientCode As String = Nothing, Optional ByRef DivisionCode As String = Nothing, Optional ByVal IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim DivisionEditDialog As AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog = Nothing

            DivisionEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog(FromMaintenance, ClientCode, DivisionCode, IsCopy)

            ShowFormDialog = DivisionEditDialog.ShowDialog()

            ClientCode = DivisionEditDialog.ClientCode
            DivisionCode = DivisionEditDialog.DivisionCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DivisionEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DivisionEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemProduct_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemProduct_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemProduct_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemProduct_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemProduct_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

			ButtonItemSortOptions_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemSortOptions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemContacts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContacts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContacts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemContracts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContracts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContracts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemContracts_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            '============================================================================
            ButtonItemActions_Add.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance

            ButtonItemContacts_Add.SecurityEnabled = DivisionControlForm_Division.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Edit.SecurityEnabled = DivisionControlForm_Division.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Delete.SecurityEnabled = DivisionControlForm_Division.DoesUserHaveAccessToClientContactMaintenance

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemDocuments_Upload.SplitButton = False

				End If

			End Using

			If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

                ButtonItemActions_Add.Visible = _IsCopy
                ButtonItemActions_Save.Visible = Not _IsCopy
                ButtonItemActions_Delete.Visible = Not _IsCopy
                ButtonItemActions_Copy.Visible = Not _IsCopy

                If Not _IsCopy Then

                    ButtonItemActions_Save.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemActions_Delete.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemActions_Copy.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemContracts_Add.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemContracts_Copy.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemContracts_Delete.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemContracts_Edit.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemDocuments_Delete.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemDocuments_Download.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemDocuments_OpenURL.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemDocuments_Upload.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemSortOptions_Delete.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemSortOptions_Cancel.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemProduct_Add.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemProduct_CopyFrom.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemProduct_CopyTo.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance
                    ButtonItemProduct_Delete.SecurityEnabled = DivisionControlForm_Division.CanUserUpdateInClientMaintenance

                    Me.ShowUnsavedChangesOnFormClosing = DivisionControlForm_Division.CanUserUpdateInClientMaintenance

                End If

            ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False
                ButtonItemActions_Copy.Visible = False

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False
                ButtonItemActions_Copy.Visible = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            If DivisionControlForm_Division.LoadControl(_ClientCode, _DivisionCode, _IsCopy, _FromMaintenance) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The division you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                DivisionControlForm_Division.TextBoxGeneral_Code.Focus()

            End If

        End Sub
        Private Sub DivisionEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    If DivisionControlForm_Division.Insert(ClientCode, DivisionCode) Then

                        _ClientCode = ClientCode
                        _DivisionCode = DivisionCode

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

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

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ContinueCopy As Boolean = Nothing

            ContinueCopy = CheckForUnsavedChanges()

            If ContinueCopy Then

                ClientCode = _ClientCode
                DivisionCode = _DivisionCode

                If AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(_FromMaintenance, ClientCode, DivisionCode, True) = Windows.Forms.DialogResult.OK Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Deleting...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                Try

                    If DivisionControlForm_Division.Delete Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If Save() = True Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub DivisionControlForm_Division_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles DivisionControlForm_Division.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso _
                    _DivisionCode IsNot Nothing AndAlso Not _IsCopy AndAlso DivisionControlForm_Division.CanUserUpdateInClientMaintenance Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub DivisionControlForm_Division_DivisionSortKeysInitNewRowEvent() Handles DivisionControlForm_Division.DivisionSortKeysInitNewRowEvent

            ButtonItemSortOptions_Delete.Enabled = False
            ButtonItemSortOptions_Cancel.Enabled = True

        End Sub
        Private Sub DivisionControlForm_Division_DivisionSortKeysSelectionChangedEvent() Handles DivisionControlForm_Division.DivisionSortKeysSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlForm_Division_SelectedDetailTabChangedEvent() Handles DivisionControlForm_Division.SelectedDetailTabChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlForm_Division_SelectedDocumentChanged() Handles DivisionControlForm_Division.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlForm_Division_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles DivisionControlForm_Division.SelectedTabChanging

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortOptions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemSortOptions_Cancel.Click

            DivisionControlForm_Division.CancelAddSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortOptions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemSortOptions_Delete.Click

            DivisionControlForm_Division.DeleteSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            DivisionControlForm_Division.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            DivisionControlForm_Division.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            DivisionControlForm_Division.DownloadDocument()

            EnableOrDisableActions()

        End Sub
		Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

			DivisionControlForm_Division.UploadDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			DivisionControlForm_Division.SendASPUploadEmail()

		End Sub
		Private Sub ButtonItemContacts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Add.Click

            DivisionControlForm_Division.AddContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Edit.Click

            DivisionControlForm_Division.EditContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Delete.Click

            DivisionControlForm_Division.DeleteContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Add.Click

            DivisionControlForm_Division.AddContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Copy.Click

            DivisionControlForm_Division.CopyContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Delete.Click

            DivisionControlForm_Division.DeleteContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Edit.Click

            DivisionControlForm_Division.EditContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemProduct_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Add.Click

            DivisionControlForm_Division.AddProduct()

        End Sub
        Private Sub ButtonItemProduct_CopyFrom_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_CopyFrom.Click

            DivisionControlForm_Division.CopyProductFrom()

        End Sub
        Private Sub ButtonItemProduct_CopyTo_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_CopyTo.Click

            DivisionControlForm_Division.CopyProductTo()

        End Sub
        Private Sub ButtonItemProduct_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Edit.Click

            DivisionControlForm_Division.EditProduct()

        End Sub
        Private Sub ButtonItemProduct_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Delete.Click

            DivisionControlForm_Division.DeleteProduct()

        End Sub

#End Region

#End Region

    End Class

End Namespace