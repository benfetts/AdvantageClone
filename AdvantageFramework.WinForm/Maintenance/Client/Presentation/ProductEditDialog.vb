Namespace Maintenance.Client.Presentation

    Public Class ProductEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
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

        Private Sub New(FromMaintenance As Boolean, ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _IsCopy = IsCopy
            _FromMaintenance = FromMaintenance

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If ButtonItemActions_Copy.Visible AndAlso ProductControlForm_Product.IsCRMUser AndAlso ProductControlForm_Product.CheckBoxGeneral_NewBusiness.Checked = False Then

                ButtonItemActions_Copy.Visible = False

            End If

            RibbonBarMergeContainerForm_Documents.Visible = If(ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_DocumentsTab, True, False)

            RibbonBarMergeContainerForm_Contracts.Visible = If(ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_ContractsTab, True, False)

            RibbonBarOptions_Affiliations.Visible = If(ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_CompanyProfileTab, True, False)

            If RibbonBarOptions_Affiliations.Visible Then

                ButtonItemAffiliations_Cancel.Enabled = ProductControlForm_Product.CompanyProfileAffiliationsIsNewItemRow
                ButtonItemAffiliations_Delete.Enabled = ProductControlForm_Product.CompanyProfileAffiliationsHasOnlyOneSelectedRow

            End If

            RibbonBarOptions_Competitors.Visible = If(ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_ActivitySummaryTab, True, False)
            RibbonBarOptions_Diary.Visible = If(_ProductCode IsNot Nothing AndAlso ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_ActivitySummaryTab, True, False)

            If RibbonBarOptions_Diary.Visible Then

                ButtonItemDiary_Edit.Enabled = If(ProductControlForm_Product.ActivitySummarySelectedActivitySummaryIsDiaryEntry, True, False)

            End If

            If RibbonBarOptions_Competitors.Visible Then

                ButtonItemCompetitors_Cancel.Enabled = ProductControlForm_Product.ActivitySummaryCompetitorsIsNewItemRow
                ButtonItemCompetitors_Delete.Enabled = ProductControlForm_Product.ActivitySummaryCompetitorsHasOnlyOneSelectedRow

            End If

            RibbonBarOptions_Contacts.Visible = If(ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_ContactsTab, True, False)

            If RibbonBarOptions_Contacts.Visible Then

                ButtonItemContacts_Edit.Enabled = ProductControlForm_Product.ClientContactManagerControlContacts_ProductContacts.HasOnlyOneSelectedContact
                ButtonItemContacts_Delete.Enabled = ProductControlForm_Product.ClientContactManagerControlContacts_ProductContacts.HasOnlyOneSelectedContact

            End If

            If ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_GeneralTab Then

                If ProductControlForm_Product.TabControlGeneral_General.SelectedTab Is ProductControlForm_Product.TabItemGeneral_OptionsTab Then

                    RibbonBarOptions_SortOptions.Visible = True
                    ButtonItemSortOptions_Cancel.Enabled = ProductControlForm_Product.DataGridViewRightColumn_SortOptions.IsNewItemRow
                    ButtonItemSortOptions_Delete.Enabled = ProductControlForm_Product.DataGridViewRightColumn_SortOptions.HasOnlyOneSelectedRow

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

            If RibbonBarMergeContainerForm_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = ProductControlForm_Product.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(ProductControlForm_Product.DocumentManager.HasOnlyOneSelectedDocument, Not ProductControlForm_Product.DocumentManager.IsSelectedDocumentAURL, ProductControlForm_Product.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(ProductControlForm_Product.DocumentManager.HasOnlyOneSelectedDocument, ProductControlForm_Product.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = ProductControlForm_Product.DocumentManager.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            If RibbonBarMergeContainerForm_Contracts.Visible Then

                ButtonItemContracts_Copy.Enabled = ProductControlForm_Product.ContractManager.HasOnlyOneSelectedContract
                ButtonItemContracts_Edit.Enabled = ProductControlForm_Product.ContractManager.HasOnlyOneSelectedContract
                ButtonItemContracts_Delete.Enabled = ProductControlForm_Product.ContractManager.HasOnlyOneSelectedContract

            End If

            If ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_BroadcastMedia OrElse
                    ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_PrintMedia OrElse
                    ProductControlForm_Product.SelectedTab Is ProductControlForm_Product.TabItemProductSetup_OutOfHomeInternetMedia Then

                RibbonBarOptions_MediaOverrides.Visible = (ButtonItemActions_Add.Visible = False)

            Else

                RibbonBarOptions_MediaOverrides.Visible = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    ProductControlForm_Product.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = ProductControlForm_Product.Save()

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

            ProductControlForm_Product.LoadRequiredNonGridControlsForValidation()

            If Me.Validator Then

                Me.ShowWaitForm("Saving...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If ProductControlForm_Product.Save() Then

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

                For Each LastFailedValidationResult In SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(FromMaintenance As Boolean, Optional ByRef ClientCode As String = "", Optional ByRef DivisionCode As String = "", Optional ByRef ProductCode As String = "", Optional IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim ProductEditDialog As AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog = Nothing

            ProductEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog(FromMaintenance, ClientCode, DivisionCode, ProductCode, IsCopy)

            ShowFormDialog = ProductEditDialog.ShowDialog()

            ClientCode = ProductEditDialog.ClientCode
            DivisionCode = ProductEditDialog.DivisionCode
            ProductCode = ProductEditDialog.ProductCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProductEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProductEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

			ButtonItemSortOptions_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemSortOptions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemAffiliations_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemAffiliations_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemContacts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContacts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContacts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemContracts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContracts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContracts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemContracts_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemCompetitors_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemCompetitors_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDiary_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemDiary_Edit.Image = AdvantageFramework.My.Resources.EditImage

            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemMediaOverrides_Edit.Image = AdvantageFramework.My.Resources.PercentageSmallerImage
            '============================================================================
            ButtonItemActions_Add.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance

            ButtonItemContacts_Add.SecurityEnabled = ProductControlForm_Product.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Edit.SecurityEnabled = ProductControlForm_Product.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Delete.SecurityEnabled = ProductControlForm_Product.DoesUserHaveAccessToClientContactMaintenance

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemDocuments_Upload.SplitButton = False

				End If

			End Using

			If _IsCopy AndAlso _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False
                ButtonItemActions_Copy.Visible = False

            ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                ButtonItemActions_Add.Visible = False
                ButtonItemActions_Save.Visible = True
                ButtonItemActions_Delete.Visible = True
                ButtonItemActions_Copy.Visible = True

                ButtonItemActions_Save.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemActions_Delete.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemActions_Copy.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemContracts_Add.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemContracts_Copy.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemContracts_Delete.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemContracts_Edit.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemDocuments_Delete.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemDocuments_Download.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemDocuments_OpenURL.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemDocuments_Upload.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemText_CheckSpelling.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemSortOptions_Delete.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemSortOptions_Cancel.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemAffiliations_Delete.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemAffiliations_Cancel.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemCompetitors_Delete.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemCompetitors_Cancel.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemDiary_Add.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance
                ButtonItemDiary_Edit.SecurityEnabled = ProductControlForm_Product.CanUserUpdateInClientMaintenance

                Me.ShowUnsavedChangesOnFormClosing = ProductControlForm_Product.CanUserUpdateInClientMaintenance

            ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False
                ButtonItemActions_Copy.Visible = False

            ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

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

            If ProductControlForm_Product.LoadControl(_ClientCode, _DivisionCode, _ProductCode, _IsCopy, _FromMaintenance) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The product you are trying to edit does not exist anymore.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ProductEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                ProductControlForm_Product.TextBoxGeneral_Code.Focus()

            End If

        End Sub
        Private Sub ProductEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    If ProductControlForm_Product.Insert(ClientCode, DivisionCode, ProductCode) Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.CloseWaitForm()
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

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
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ContinueCopy As Boolean = Nothing

            ContinueCopy = CheckForUnsavedChanges()

            If ContinueCopy Then

                ClientCode = _ClientCode
                DivisionCode = _DivisionCode
                ProductCode = _ProductCode

                If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(_FromMaintenance, ClientCode, DivisionCode, ProductCode, True) = Windows.Forms.DialogResult.OK Then

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

                    If ProductControlForm_Product.Delete Then

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
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf ProductControlForm_Product.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(ProductControlForm_Product.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub ProductControlForm_Product_ActivitySummaryCRMActivitySelectionChangedEvent() Handles ProductControlForm_Product.ActivitySummaryCRMActivitySelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlRightSection_Product_CompanyProfileAffiliationInitNewRowEvent() Handles ProductControlForm_Product.CompanyProfileAffiliationInitNewRowEvent

            ButtonItemAffiliations_Delete.Enabled = False
            ButtonItemAffiliations_Cancel.Enabled = True

        End Sub
        Private Sub ProductControlRightSection_Product_CompanyProfileAffiliationSelectionChangedEvent() Handles ProductControlForm_Product.CompanyProfileAffiliationSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlForm_Product_ClientContactManagerRowCountChanged() Handles ProductControlForm_Product.ClientContactManagerRowCountChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlForm_Product_CompanyProfileNotesGotFocusEvent(sender As Object, e As EventArgs) Handles ProductControlForm_Product.CompanyProfileNotesGotFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ProductControlForm_Product_CompanyProfileNotesLostFocusEvent(sender As Object, e As EventArgs) Handles ProductControlForm_Product.CompanyProfileNotesLostFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ProductControlForm_Product_ActivitySummaryCompetitorInitNewRowEvent() Handles ProductControlForm_Product.ActivitySummaryCompetitorInitNewRowEvent

            ButtonItemCompetitors_Delete.Enabled = False
            ButtonItemCompetitors_Cancel.Enabled = True

        End Sub
        Private Sub ProductControlForm_Product_ActivitySummaryCompetitorSelectionChangedEvent() Handles ProductControlForm_Product.ActivitySummaryCompetitorSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlForm_Product_ContractManagerRowCountChanged() Handles ProductControlForm_Product.ContractManagerRowCountChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlForm_Product_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles ProductControlForm_Product.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso _
                    _ProductCode IsNot Nothing AndAlso Not _IsCopy AndAlso ProductControlForm_Product.CanUserUpdateInClientMaintenance Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub ProductControlForm_Product_ProductSortKeysInitNewRowEvent() Handles ProductControlForm_Product.ProductSortKeysInitNewRowEvent

            ButtonItemSortOptions_Delete.Enabled = False
            ButtonItemSortOptions_Cancel.Enabled = True

        End Sub
        Private Sub ProductControlForm_Product_ProductSortKeysSelectionChangedEvent() Handles ProductControlForm_Product.ProductSortKeysSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlForm_Product_SelectedDetailChangedEvent() Handles ProductControlForm_Product.SelectedDetailChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlForm_Product_SelectedDocumentChanged() Handles ProductControlForm_Product.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlForm_Product_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles ProductControlForm_Product.SelectedTabChanging

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortOptions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemSortOptions_Cancel.Click

            ProductControlForm_Product.CancelAddSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortOptions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemSortOptions_Delete.Click

            ProductControlForm_Product.DeleteSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDiary_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemDiary_Add.Click

            If AdvantageFramework.Maintenance.Client.Presentation.DiaryAddDialog.ShowFormDialog(11, 58, _ClientCode, _DivisionCode, _ProductCode) = Windows.Forms.DialogResult.OK Then

                ProductControlForm_Product.RefreshActivitySummary()

            End If

        End Sub
        Private Sub ButtonItemDiary_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDiary_Edit.Click

            If AdvantageFramework.Maintenance.Client.Presentation.DiaryAddDialog.ShowFormDialog(ProductControlForm_Product.ActivitySummarySelectedCRMActivityAlertID) = Windows.Forms.DialogResult.OK Then

                ProductControlForm_Product.RefreshActivitySummary()

            End If

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            ProductControlForm_Product.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            ProductControlForm_Product.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            ProductControlForm_Product.DownloadDocument()

            EnableOrDisableActions()

        End Sub
		Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

			ProductControlForm_Product.UploadDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			ProductControlForm_Product.SendASPUploadEmail()

		End Sub
		Private Sub ButtonItemAffiliations_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemAffiliations_Cancel.Click

            ProductControlForm_Product.CancelAddNewCompanyProfileAffiliation()

        End Sub
        Private Sub ButtonItemAffiliations_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemAffiliations_Delete.Click

            ProductControlForm_Product.DeleteSelectedCompanyProfileAffiliation()

        End Sub
        Private Sub ButtonItemCompetitors_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemCompetitors_Cancel.Click

            ProductControlForm_Product.CancelAddNewActivityCompetitor()

        End Sub
        Private Sub ButtonItemCompetitors_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemCompetitors_Delete.Click

            ProductControlForm_Product.DeleteSelectedActivityCompetitor()

        End Sub
        Private Sub ButtonItemContacts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Add.Click

            ProductControlForm_Product.AddContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Edit.Click

            ProductControlForm_Product.EditContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Delete.Click

            ProductControlForm_Product.DeleteContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Add.Click

            ProductControlForm_Product.AddContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Copy.Click

            ProductControlForm_Product.CopyContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Delete.Click

            ProductControlForm_Product.DeleteContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Edit.Click

            ProductControlForm_Product.EditContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMediaOverrides_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaOverrides_Edit.Click

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                AdvantageFramework.Maintenance.Client.Presentation.ProductMediaOverridesDialog.ShowFormDialog(_ClientCode, _DivisionCode, _ProductCode)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace