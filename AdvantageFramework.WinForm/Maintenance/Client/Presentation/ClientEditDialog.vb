Namespace Maintenance.Client.Presentation

    Public Class ClientEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Private ReadOnly Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(FromMaintenance As Boolean, ByRef ClientCode As String, ByRef IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _IsCopy = IsCopy
            _FromMaintenance = FromMaintenance

        End Sub
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            ClientControlForm_Client.LoadRequiredNonGridControlsForValidation()

            If Me.Validator Then

                Me.ShowWaitForm("Saving...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If ClientControlForm_Client.Save() Then

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
        Private Sub EnableOrDisableActions()

            If ClientControlForm_Client.SelectedTab Is ClientControlForm_Client.TabItemClientDetails_DivisionProductTab Then

                RibbonControlForm_MainRibbon.SelectedRibbonTabItem = RibbonTabItemMainRibbon_DivisionProduct

            Else

                RibbonControl.SelectedRibbonTabItem = RibbonTabItemMainRibbon_File

            End If

            RibbonBarOptions_Website.Visible = False
            RibbonBarOptions_Documents.Visible = False
            RibbonBarOptions_SortKeys.Visible = False
            RibbonBarOptions_Contacts.Visible = False
            RibbonBarOptions_Contracts.Visible = False

            RibbonBarOptions_Website.Visible = If(ClientControlForm_Client.SelectedTab Is ClientControlForm_Client.TabItemClientDetails_WebsitesTab, True, False)
            RibbonBarOptions_Documents.Visible = If(ClientControlForm_Client.SelectedTab Is ClientControlForm_Client.TabItemClientDetails_DocumentsTab, True, False)
            RibbonBarOptions_SortKeys.Visible = If(ClientControlForm_Client.SelectedTab Is ClientControlForm_Client.TabItemClientDetails_GeneralTab, True, False)
            RibbonBarOptions_Contacts.Visible = If(ClientControlForm_Client.SelectedTab Is ClientControlForm_Client.TabItemClientDetails_ContactsTab, True, False)
            RibbonBarOptions_Contracts.Visible = If(ClientControlForm_Client.SelectedTab Is ClientControlForm_Client.TabItemClientDetails_ContractsTab, True, False)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemDivision_CopyFrom.Enabled = ClientControlForm_Client.HasASelectedDivision
            ButtonItemDivision_CopyTo.Enabled = ClientControlForm_Client.HasASelectedDivision
            ButtonItemDivision_Delete.Enabled = ClientControlForm_Client.HasASelectedDivision
            ButtonItemDivision_Edit.Enabled = ClientControlForm_Client.HasASelectedDivision

            ButtonItemProduct_CopyFrom.Enabled = ClientControlForm_Client.HasASelectedProduct
            ButtonItemProduct_CopyTo.Enabled = ClientControlForm_Client.HasASelectedProduct
            ButtonItemProduct_Delete.Enabled = ClientControlForm_Client.HasASelectedProduct
            ButtonItemProduct_Edit.Enabled = ClientControlForm_Client.HasASelectedProduct

            If ClientControlForm_Client.IsCRMUser AndAlso ClientControlForm_Client.CheckBoxRightColumn_NewBusiness.Checked = False Then

                ButtonItemDivision_Add.Enabled = False
                ButtonItemDivision_Edit.Enabled = False
                ButtonItemDivision_CopyFrom.Enabled = False
                ButtonItemDivision_CopyTo.Enabled = False
                ButtonItemDivision_Delete.Enabled = False

                ButtonItemProduct_Add.Enabled = False
                ButtonItemProduct_Edit.Enabled = False
                ButtonItemProduct_CopyFrom.Enabled = False
                ButtonItemProduct_CopyTo.Enabled = False
                ButtonItemProduct_Delete.Enabled = False

            End If

            ButtonItemDocuments_Delete.Enabled = If(RibbonBarOptions_Documents.Visible, ClientControlForm_Client.DocumentManagerControlDocuments_ClientDocuments.HasASelectedDocument, False)
            ButtonItemDocuments_Download.Enabled = If(RibbonBarOptions_Documents.Visible, ClientControlForm_Client.DocumentManagerControlDocuments_ClientDocuments.HasASelectedDocument, False)

            If RibbonBarOptions_SortKeys.Visible Then

                ButtonItemSortKeys_Cancel.Enabled = ClientControlForm_Client.DataGridViewClientSortKeys.IsNewItemRow(ClientControlForm_Client.DataGridViewClientSortKeys.CurrentView.FocusedRowHandle)
                ButtonItemSortKeys_Delete.Enabled = ClientControlForm_Client.DataGridViewClientSortKeys.HasOnlyOneSelectedRow

            Else

                ButtonItemSortKeys_Cancel.Enabled = False
                ButtonItemSortKeys_Delete.Enabled = False

            End If

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = ClientControlForm_Client.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(ClientControlForm_Client.DocumentManager.HasOnlyOneSelectedDocument, Not ClientControlForm_Client.DocumentManager.IsSelectedDocumentAURL, ClientControlForm_Client.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(ClientControlForm_Client.DocumentManager.HasOnlyOneSelectedDocument, ClientControlForm_Client.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = ClientControlForm_Client.DocumentManager.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            If RibbonBarOptions_Contacts.Visible Then

                ButtonItemContacts_Edit.Enabled = ClientControlForm_Client.ClientContactManagerControlContacts_ClientContacts.HasOnlyOneSelectedContact
                ButtonItemContacts_Delete.Enabled = ClientControlForm_Client.ClientContactManagerControlContacts_ClientContacts.HasOnlyOneSelectedContact

            End If

            If RibbonBarOptions_Contracts.Visible Then

                ButtonItemContracts_Edit.Enabled = ClientControlForm_Client.ContractManagerControlContractTab_Contracts.HasOnlyOneSelectedContract
                ButtonItemContracts_Delete.Enabled = ClientControlForm_Client.ContractManagerControlContractTab_Contracts.HasOnlyOneSelectedContract
                ButtonItemContracts_Copy.Enabled = ClientControlForm_Client.ContractManagerControlContractTab_Contracts.HasOnlyOneSelectedContract

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(FromMaintenance As Boolean, Optional ByRef ClientCode As String = Nothing, Optional ByRef IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientEditDialog As AdvantageFramework.Maintenance.Client.Presentation.ClientEditDialog = Nothing

            ClientEditDialog = New AdvantageFramework.Maintenance.Client.Presentation.ClientEditDialog(FromMaintenance, ClientCode, IsCopy)

            ShowFormDialog = ClientEditDialog.ShowDialog()

            ClientCode = ClientEditDialog.ClientCode
            IsCopy = ClientEditDialog.IsCopy

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            RibbonBarOptions_Website.Visible = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemDivision_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemDivision_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDivision_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDivision_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemDivision_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDivision_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemDivision_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage

            ButtonItemProduct_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemProduct_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemProduct_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemProduct_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemProduct_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemProduct_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProduct_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage

            ButtonItemWebsite_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemWebsite_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

			ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            ButtonItemSortKeys_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemSortKeys_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemContacts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContacts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContacts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemContracts_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemContracts_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemContracts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemContracts_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemActions_Add.SecurityEnabled = ClientControlForm_Client.CanUserAdd

            ButtonItemContacts_Add.SecurityEnabled = ClientControlForm_Client.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Edit.SecurityEnabled = ClientControlForm_Client.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Delete.SecurityEnabled = ClientControlForm_Client.DoesUserHaveAccessToClientContactMaintenance

            Me.ShowUnsavedChangesOnFormClosing = ClientControlForm_Client.CanUserUpdate

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemDocuments_Upload.SplitButton = False

				End If

			End Using

			If _ClientCode <> "" Then

                ButtonItemActions_Add.Visible = _IsCopy
                ButtonItemActions_Save.Visible = Not _IsCopy
                ButtonItemActions_Delete.Visible = Not _IsCopy
                ButtonItemActions_Print.Visible = Not _IsCopy

                RibbonTabItemMainRibbon_DivisionProduct.Visible = True

                If Not _IsCopy Then

                    ButtonItemActions_Delete.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemActions_Save.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDivision_Add.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDivision_CopyFrom.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDivision_CopyTo.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDivision_Delete.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    'ButtonItemDivision_Edit.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemProduct_Add.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemProduct_CopyFrom.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemProduct_CopyTo.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemProduct_Delete.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    'ButtonItemProduct_Edit.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemContracts_Add.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemContracts_Copy.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemContracts_Delete.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemContracts_Edit.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDocuments_Delete.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDocuments_Download.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDocuments_OpenURL.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemDocuments_Upload.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemSortKeys_Cancel.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemSortKeys_Delete.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemText_CheckSpelling.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemWebsite_Cancel.SecurityEnabled = ClientControlForm_Client.CanUserUpdate
                    ButtonItemWebsite_Delete.SecurityEnabled = ClientControlForm_Client.CanUserUpdate

                    ButtonItemActions_Print.SecurityEnabled = ClientControlForm_Client.CanUserPrint
                    ButtonItemDivision_Print.SecurityEnabled = ClientControlForm_Client.CanUserPrint
                    ButtonItemDivision_PrintFiltered.SecurityEnabled = ClientControlForm_Client.CanUserPrint
                    ButtonItemProduct_Print.SecurityEnabled = ClientControlForm_Client.CanUserPrint
                    ButtonItemProduct_PrintFiltered.SecurityEnabled = ClientControlForm_Client.CanUserPrint

                    Me.ShowUnsavedChangesOnFormClosing = ClientControlForm_Client.CanUserUpdate

                End If

            Else

                ButtonItemActions_Add.Visible = True
                ButtonItemActions_Save.Visible = False
                ButtonItemActions_Delete.Visible = False
                ButtonItemActions_Print.Visible = False

                RibbonTabItemMainRibbon_DivisionProduct.Visible = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            If ClientControlForm_Client.LoadControl(_ClientCode, _IsCopy, _FromMaintenance) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The client you are trying to edit does not exist anymore.")
                Me.Close()

            Else

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientEditDialog_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                ClientControlForm_Client.TextBoxGeneral_Code.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ClientCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    If ClientControlForm_Client.Insert(ClientCode) Then

                        _ClientCode = ClientCode

                        Me.ClearChanged()

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
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            ClientControlForm_Client.LoadRequiredNonGridControlsForValidation()

            If Me.Validator Then

                Me.ShowWaitForm("Saving...")
                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If ClientControlForm_Client.Save() Then

                        Me.ClearChanged()

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
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If _ClientCode <> "" Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                    Try

                        If ClientControlForm_Client.Delete() Then

                            Me.ClearChanged()

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a client to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Print.Click

            ' objects
            Dim SelectedClientCodes() As String = Nothing

            If ClientControlForm_Client.Enabled Then

                SelectedClientCodes = New String() {_ClientCode}

            End If

            AdvantageFramework.Maintenance.Client.Presentation.ClientReportsDialog.ShowFormDialog(Nothing, SelectedClientCodes)

        End Sub
        Private Sub ClientControlForm_Client_AddClientWebsiteInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ClientControlForm_Client.AddClientWebsiteInitNewRowEvent

            ButtonItemWebsite_Cancel.Enabled = ClientControlForm_Client.DataGridViewWebsitesIsNewItemRow
            ButtonItemWebsite_Delete.Enabled = Not ClientControlForm_Client.DataGridViewWebsitesIsNewItemRow

        End Sub
        Private Sub ClientControlForm_Client_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles ClientControlForm_Client.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso _
                    _ClientCode IsNot Nothing AndAlso Not _IsCopy AndAlso ClientControlForm_Client.CanUserUpdate Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub ClientControlForm_Client_ClientWebsiteSelectionChangedEvent(sender As Object, e As System.EventArgs) Handles ClientControlForm_Client.ClientWebsiteSelectionChangedEvent

            ButtonItemWebsite_Cancel.Enabled = ClientControlForm_Client.DataGridViewWebsitesIsNewItemRow
            ButtonItemWebsite_Delete.Enabled = Not ClientControlForm_Client.DataGridViewWebsitesIsNewItemRow

        End Sub
        Private Sub ClientControlForm_Client_SelectedDivisionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlForm_Client.SelectedDivisionChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlForm_Client_SelectedProductChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlForm_Client.SelectedProductChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlForm_Client_SelectedTabChanged() Handles ClientControlForm_Client.SelectedTabChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemDivision_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_Add.Click

            ClientControlForm_Client.ButtonLeftSection_Add.PerformClick()

        End Sub
        Private Sub ButtonItemDivision_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_Edit.Click

            ClientControlForm_Client.ButtonLeftSection_Edit.PerformClick()

        End Sub
        Private Sub ButtonItemDivision_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_CopyFrom.Click

            ClientControlForm_Client.ButtonItemDivisionCopy_From.RaiseClick()

        End Sub
        Private Sub ButtonItemDivision_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemDivision_Print.Click

            ' objects
            Dim SelectedDivisionCodes() As String = Nothing

            If ClientControlForm_Client.Enabled Then

                SelectedDivisionCodes = {ClientControlForm_Client.DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue}

                AdvantageFramework.Maintenance.Client.Presentation.DivisionReportsDialog.ShowFormDialog(_ClientCode, Nothing, SelectedDivisionCodes)

            End If

        End Sub
        Private Sub ButtonItemDivision_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemDivision_PrintFiltered.Click

            'objects
            Dim SelectedAndAvailableDivisionCodes() As String = Nothing

            Try

                SelectedAndAvailableDivisionCodes = (From Entity In ClientControlForm_Client.DataGridViewLeftSection_Divisions.GetAllRowsBookmarkValues.OfType(Of String)() _
                                                     Select Entity).ToArray

            Catch ex As Exception
                SelectedAndAvailableDivisionCodes = Nothing
            End Try

            AdvantageFramework.Maintenance.Client.Presentation.DivisionReportsDialog.ShowFormDialog(_ClientCode, SelectedAndAvailableDivisionCodes, SelectedAndAvailableDivisionCodes)

        End Sub
        Private Sub ButtonItemProduct_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_Add.Click

            ClientControlForm_Client.ButtonRightSection_Add.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_Edit.Click

            ClientControlForm_Client.ButtonRightSection_Edit.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_CopyFrom.Click

            ClientControlForm_Client.ButtonItemProductCopy_From.RaiseClick()

        End Sub
        Private Sub ButtonItemProduct_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_Delete.Click

            ClientControlForm_Client.ButtonRightSection_Delete.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Print.Click

            ' objects
            Dim SelectedProductCodes() As String = Nothing
            Dim DivisionCode As String = Nothing

            If ClientControlForm_Client.Enabled Then

                DivisionCode = ClientControlForm_Client.DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                SelectedProductCodes = {ClientControlForm_Client.DataGridViewRightSection_Products.GetFirstSelectedRowBookmarkValue}

                AdvantageFramework.Maintenance.Client.Presentation.ProductReportsDialog.ShowFormDialog(_ClientCode, DivisionCode, Nothing, SelectedProductCodes)

            End If

        End Sub
        Private Sub ButtonItemProduct_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_PrintFiltered.Click

            'objects
            Dim SelectedAndAvailableProductCodes() As String = Nothing
            Dim DivisionCode As String = Nothing

            DivisionCode = ClientControlForm_Client.DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

            Try

                SelectedAndAvailableProductCodes = (From Entity In ClientControlForm_Client.DataGridViewRightSection_Products.GetAllRowsBookmarkValues.OfType(Of String)() _
                                                    Select Entity).ToArray

            Catch ex As Exception
                SelectedAndAvailableProductCodes = Nothing
            End Try

            AdvantageFramework.Maintenance.Client.Presentation.ProductReportsDialog.ShowFormDialog(_ClientCode, DivisionCode, SelectedAndAvailableProductCodes, SelectedAndAvailableProductCodes)

        End Sub
        Private Sub ButtonItemDivision_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_Delete.Click

            ClientControlForm_Client.ButtonLeftSection_Delete.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_CopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_CopyTo.Click

            ClientControlForm_Client.ButtonItemProductCopy_To.RaiseClick()

        End Sub
        Private Sub ButtonItemDivision_CopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_CopyTo.Click

            ClientControlForm_Client.ButtonItemDivisionCopy_To.RaiseClick()

        End Sub
        Private Sub ButtonItemWebsite_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemWebsite_Cancel.Click

            ClientControlForm_Client.CancelAddNewClientWebsite()

        End Sub
        Private Sub ButtonItemWebsite_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemWebsite_Delete.Click

            ClientControlForm_Client.DeleteSelectedClientWebsite()

        End Sub
        Private Sub ClientControlForm_Client_SelectedDocumentChanged() Handles ClientControlForm_Client.SelectedDocumentChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlForm_Client_ARCommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlForm_Client.ARCommentGotFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ClientControlForm_Client_ARCommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlForm_Client.ARCommentLostFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf ClientControlForm_Client.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(ClientControlForm_Client.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub ButtonItemSortKeys_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortKeys_Delete.Click

            ClientControlForm_Client.DeleteSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortKeys_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortKeys_Cancel.Click

            ClientControlForm_Client.CancelAddSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ClientControlForm_Client_ClientSortKeysSelectionChangedEvent() Handles ClientControlForm_Client.ClientSortKeysSelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlForm_Client_ClientSortKeysInitNewRowEvent() Handles ClientControlForm_Client.ClientSortKeysInitNewRowEvent

            ButtonItemSortKeys_Delete.Enabled = False
            ButtonItemSortKeys_Cancel.Enabled = True

        End Sub
		Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

			ClientControlForm_Client.UploadDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			ClientControlForm_Client.SendASPUploadEmail()

		End Sub
		Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            ClientControlForm_Client.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            ClientControlForm_Client.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            ClientControlForm_Client.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Add.Click

            ClientControlForm_Client.AddContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Edit.Click

            ClientControlForm_Client.EditContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Delete.Click

            ClientControlForm_Client.DeleteContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Add.Click

            ClientControlForm_Client.AddContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Copy.Click

            ClientControlForm_Client.CopyContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Delete.Click

            ClientControlForm_Client.DeleteContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Edit.Click

            ClientControlForm_Client.EditContract()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace