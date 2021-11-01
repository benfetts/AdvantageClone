Namespace Maintenance.Client.Presentation

    Public Class ClientSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CRMAddEditViewNewBusinessClientsOnly As Boolean = False

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

                If _CRMAddEditViewNewBusinessClientsOnly Then

                    DataGridViewLeftSection_Clients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, Me.Session)
                                                                  Where Entity.IsNewBusiness = 1
                                                                  Select Entity).ToList

                Else

                    DataGridViewLeftSection_Clients.DataSource = AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, Me.Session)

                End If

                DataGridViewLeftSection_Clients.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                ClientControlRightSection_Client.ClearControl()

                ClientControlRightSection_Client.Enabled = DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow

                If ClientControlRightSection_Client.Enabled Then

                    ClientControlRightSection_Client.Enabled = ClientControlRightSection_Client.LoadControl(DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue, False, True)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim RibbonControl As DevComponents.DotNetBar.RibbonControl = Nothing

            Try

                RibbonControl = Me.MdiParent.Controls("RibbonControlForm_MainRibbon")

            Catch ex As Exception
                RibbonControl = Nothing
            End Try

            If ClientControlRightSection_Client.SelectedTab Is ClientControlRightSection_Client.TabItemClientDetails_DivisionProductTab Then

                If RibbonBarMergeContainerForm_DivisionProduct.RibbonTabItem IsNot Nothing Then

                    If RibbonControl IsNot Nothing Then

                        RibbonBarMergeContainerForm_DivisionProduct.RibbonTabItem.Visible = True
                        RibbonControl.SelectedRibbonTabItem = RibbonBarMergeContainerForm_DivisionProduct.RibbonTabItem

                    End If

                End If

            Else

                If RibbonBarMergeContainerForm_Options.RibbonTabItem IsNot Nothing Then

                    If RibbonControl IsNot Nothing Then

                        RibbonBarMergeContainerForm_Options.RibbonTabItem.Visible = True
                        RibbonControl.SelectedRibbonTabItem = RibbonBarMergeContainerForm_Options.RibbonTabItem

                    End If

                End If

            End If

            RibbonBarOptions_Website.Visible = False
            RibbonBarOptions_Documents.Visible = False
            RibbonBarOptions_SortKeys.Visible = False
            RibbonBarOptions_Contacts.Visible = False
            RibbonBarOptions_Contracts.Visible = False

            RibbonBarOptions_Website.Visible = If(ClientControlRightSection_Client.SelectedTab Is ClientControlRightSection_Client.TabItemClientDetails_WebsitesTab, True, False)
            RibbonBarOptions_Documents.Visible = If(ClientControlRightSection_Client.SelectedTab Is ClientControlRightSection_Client.TabItemClientDetails_DocumentsTab, True, False)
            RibbonBarOptions_SortKeys.Visible = If(ClientControlRightSection_Client.SelectedTab Is ClientControlRightSection_Client.TabItemClientDetails_GeneralTab, True, False)
            RibbonBarOptions_Contacts.Visible = If(ClientControlRightSection_Client.SelectedTab Is ClientControlRightSection_Client.TabItemClientDetails_ContactsTab, True, False)
            RibbonBarOptions_Contracts.Visible = If(ClientControlRightSection_Client.SelectedTab Is ClientControlRightSection_Client.TabItemClientDetails_ContractsTab, True, False)

            ClientControlRightSection_Client.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso ClientControlRightSection_Client.Enabled)
            ButtonItemActions_Copy.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso ClientControlRightSection_Client.Enabled)

            ButtonItemDivision_Add.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso ClientControlRightSection_Client.Enabled)
            ButtonItemDivision_CopyFrom.Enabled = ClientControlRightSection_Client.HasASelectedDivision
            ButtonItemDivision_CopyTo.Enabled = ClientControlRightSection_Client.HasASelectedDivision
            ButtonItemDivision_Delete.Enabled = ClientControlRightSection_Client.HasASelectedDivision
            ButtonItemDivision_Edit.Enabled = ClientControlRightSection_Client.HasASelectedDivision

            ButtonItemProduct_Add.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso ClientControlRightSection_Client.Enabled)
            ButtonItemProduct_CopyFrom.Enabled = ClientControlRightSection_Client.HasASelectedProduct
            ButtonItemProduct_CopyTo.Enabled = ClientControlRightSection_Client.HasASelectedProduct
            ButtonItemProduct_Delete.Enabled = ClientControlRightSection_Client.HasASelectedProduct
            ButtonItemProduct_Edit.Enabled = ClientControlRightSection_Client.HasASelectedProduct

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                If ClientControlRightSection_Client.IsCRMUser AndAlso DataGridViewLeftSection_Clients.CurrentView.GetRowCellValue(DataGridViewLeftSection_Clients.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Client.Properties.IsNewBusiness.ToString) = False Then

                    ButtonItemActions_Copy.Enabled = False

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

            ElseIf ClientControlRightSection_Client.IsCRMUser Then

                ButtonItemActions_Copy.Enabled = False

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

            ButtonItemDocuments_Delete.Enabled = If(RibbonBarOptions_Documents.Visible, ClientControlRightSection_Client.DocumentManagerControlDocuments_ClientDocuments.HasASelectedDocument, False)
            ButtonItemDocuments_Download.Enabled = If(RibbonBarOptions_Documents.Visible, ClientControlRightSection_Client.DocumentManagerControlDocuments_ClientDocuments.HasASelectedDocument, False)

            If RibbonBarOptions_SortKeys.Visible Then

                ButtonItemSortKeys_Cancel.Enabled = ClientControlRightSection_Client.DataGridViewClientSortKeys.IsNewItemRow(ClientControlRightSection_Client.DataGridViewClientSortKeys.CurrentView.FocusedRowHandle)
                ButtonItemSortKeys_Delete.Enabled = ClientControlRightSection_Client.DataGridViewClientSortKeys.HasOnlyOneSelectedRow

            Else

                ButtonItemSortKeys_Cancel.Enabled = False
                ButtonItemSortKeys_Delete.Enabled = False

            End If

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = ClientControlRightSection_Client.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(ClientControlRightSection_Client.DocumentManager.HasOnlyOneSelectedDocument, Not ClientControlRightSection_Client.DocumentManager.IsSelectedDocumentAURL, ClientControlRightSection_Client.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(ClientControlRightSection_Client.DocumentManager.HasOnlyOneSelectedDocument, ClientControlRightSection_Client.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = ClientControlRightSection_Client.DocumentManager.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            If RibbonBarOptions_Contacts.Visible Then

                ButtonItemContacts_Edit.Enabled = ClientControlRightSection_Client.ClientContactManagerControlContacts_ClientContacts.HasOnlyOneSelectedContact
                ButtonItemContacts_Delete.Enabled = ClientControlRightSection_Client.ClientContactManagerControlContacts_ClientContacts.HasOnlyOneSelectedContact

            End If

            If RibbonBarOptions_Contracts.Visible Then

                ButtonItemContracts_Edit.Enabled = ClientControlRightSection_Client.ContractManagerControlContractTab_Contracts.HasOnlyOneSelectedContract
                ButtonItemContracts_Delete.Enabled = ClientControlRightSection_Client.ContractManagerControlContractTab_Contracts.HasOnlyOneSelectedContract
                ButtonItemContracts_Copy.Enabled = ClientControlRightSection_Client.ContractManagerControlContractTab_Contracts.HasOnlyOneSelectedContract

            End If

            RibbonBarOptions_QuickBooks.Visible = ClientControlRightSection_Client.IsQuickbooksEnabled

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    ClientControlRightSection_Client.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = ClientControlRightSection_Client.Save()

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

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                ClientControlRightSection_Client.LoadRequiredNonGridControlsForValidation()

                If Me.Validator Then

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If ClientControlRightSection_Client.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_Clients.FocusToFindPanel(False)

                        DataGridViewLeftSection_Clients.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a client to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientSetupForm As AdvantageFramework.Maintenance.Client.Presentation.ClientSetupForm = Nothing

            ClientSetupForm = New AdvantageFramework.Maintenance.Client.Presentation.ClientSetupForm()

            ClientSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            RibbonBarOptions_Website.Visible = False

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemDivision_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemDivision_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemDivision_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDivision_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDivision_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemDivision_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDivision_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemDivision_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage
            ButtonItemDivision_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemProduct_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemProduct_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemProduct_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemProduct_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemProduct_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemProduct_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemProduct_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemProduct_PrintFiltered.Image = AdvantageFramework.My.Resources.PrinterViewImage
            ButtonItemProduct_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

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

            ButtonItemQuickBooks_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewLeftSection_Clients.MultiSelect = False

            ButtonItemActions_Import.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientImport)
            ButtonItemActions_Add.SecurityEnabled = ClientControlRightSection_Client.CanUserAdd
            ButtonItemActions_Copy.SecurityEnabled = ClientControlRightSection_Client.CanUserAdd

            ButtonItemActions_Delete.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemActions_Save.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate

            ButtonItemDivision_Import.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_DivisionImport)
            ButtonItemDivision_Add.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemDivision_CopyFrom.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemDivision_CopyTo.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemDivision_Delete.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            'ButtonItemDivision_Edit.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate

            ButtonItemProduct_Import.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Client_ProductImport)
            ButtonItemProduct_Add.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemProduct_CopyFrom.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemProduct_CopyTo.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemProduct_Delete.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            'ButtonItemProduct_Edit.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate

            ButtonItemContacts_Add.SecurityEnabled = ClientControlRightSection_Client.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Edit.SecurityEnabled = ClientControlRightSection_Client.DoesUserHaveAccessToClientContactMaintenance
            ButtonItemContacts_Delete.SecurityEnabled = ClientControlRightSection_Client.DoesUserHaveAccessToClientContactMaintenance

            ButtonItemContracts_Add.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemContracts_Copy.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemContracts_Delete.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemContracts_Edit.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemDocuments_Delete.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemDocuments_Download.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemDocuments_OpenURL.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemDocuments_Upload.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemSortKeys_Cancel.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemSortKeys_Delete.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemText_CheckSpelling.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemWebsite_Cancel.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate
            ButtonItemWebsite_Delete.SecurityEnabled = ClientControlRightSection_Client.CanUserUpdate

            ButtonItemActions_Print.SecurityEnabled = ClientControlRightSection_Client.CanUserPrint
            ButtonItemActions_PrintFiltered.SecurityEnabled = ClientControlRightSection_Client.CanUserPrint
            ButtonItemDivision_Print.SecurityEnabled = ClientControlRightSection_Client.CanUserPrint
            ButtonItemDivision_PrintFiltered.SecurityEnabled = ClientControlRightSection_Client.CanUserPrint
            ButtonItemProduct_Print.SecurityEnabled = ClientControlRightSection_Client.CanUserPrint
            ButtonItemProduct_PrintFiltered.SecurityEnabled = ClientControlRightSection_Client.CanUserPrint

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

                _CRMAddEditViewNewBusinessClientsOnly = AdvantageFramework.Security.LoadUserSetting(Me.Session, Me.Session.User.ID, Security.UserSettings.CRMAddEditViewNewBusinessClientsOnly)

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                If ClientControlRightSection_Client.IsCRMUser Then

                    DataGridViewLeftSection_Clients.CurrentView.AFActiveFilterString = "[IsInactive] = False AND [IsNewBusiness] = True"

                Else

                    DataGridViewLeftSection_Clients.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                End If

            Catch ex As Exception

            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ClientSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Clients.FocusToFindPanel(True)

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Try

                    ClientControlRightSection_Client.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Clients.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemDivision_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemDivision_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.ShowWaitForm()

                Try

                    LoadSelectedItemDetails()

                Catch ex As Exception

                End Try

                Me.ClientControlRightSection_Client.RefreshDivisionsProducts()

                Me.CloseWaitForm()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemProduct_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.ShowWaitForm()

                Try

                    LoadSelectedItemDetails()

                Catch ex As Exception

                End Try

                Me.ClientControlRightSection_Client.RefreshDivisionsProducts()

                Me.CloseWaitForm()

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Clients_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Clients.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Clients_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Clients.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ClientCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Client.Presentation.ClientEditDialog.ShowFormDialog(True, ClientCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_Clients.SelectRow(ClientCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Clients.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            Dim ClientCode As String = Nothing
            Dim ContinueCopy As Boolean = True

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.Client.Presentation.ClientEditDialog.ShowFormDialog(True, ClientCode, True) = Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid()

                            DataGridViewLeftSection_Clients.SelectRow(ClientCode)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_Clients.CurrentView.GridViewSelectionChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Clients.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                    Try

                        If ClientControlRightSection_Client.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Clients.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a client to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Print.Click

            ' objects
            Dim SelectedClientCodes() As String = Nothing

            If ClientControlRightSection_Client.Enabled Then

                SelectedClientCodes = {DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue}

            End If

            AdvantageFramework.Maintenance.Client.Presentation.ClientReportsDialog.ShowFormDialog(Nothing, SelectedClientCodes)

        End Sub
        Private Sub ButtonItemActions_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintFiltered.Click

            'objects
            Dim SelectedAndAvailableClientCodes() As String = Nothing

            Try

                SelectedAndAvailableClientCodes = (From Entity In DataGridViewLeftSection_Clients.GetAllRowsBookmarkValues.OfType(Of String)()
                                                   Select Entity).ToArray

            Catch ex As Exception
                SelectedAndAvailableClientCodes = Nothing
            End Try

            AdvantageFramework.Maintenance.Client.Presentation.ClientReportsDialog.ShowFormDialog(SelectedAndAvailableClientCodes, SelectedAndAvailableClientCodes)

        End Sub
        Private Sub ClientControlRightSection_Client_AddClientWebsiteInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ClientControlRightSection_Client.AddClientWebsiteInitNewRowEvent

            ButtonItemWebsite_Cancel.Enabled = ClientControlRightSection_Client.DataGridViewWebsitesIsNewItemRow
            ButtonItemWebsite_Delete.Enabled = Not ClientControlRightSection_Client.DataGridViewWebsitesIsNewItemRow

        End Sub
        Private Sub ClientControlRightSection_Client_ClientWebsiteSelectionChangedEvent(sender As Object, e As System.EventArgs) Handles ClientControlRightSection_Client.ClientWebsiteSelectionChangedEvent

            ButtonItemWebsite_Cancel.Enabled = ClientControlRightSection_Client.DataGridViewWebsitesIsNewItemRow
            ButtonItemWebsite_Delete.Enabled = Not ClientControlRightSection_Client.DataGridViewWebsitesIsNewItemRow

        End Sub
        Private Sub ClientControlRightSection_Client_SelectedDivisionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlRightSection_Client.SelectedDivisionChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlRightSection_Client_SelectedProductChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlRightSection_Client.SelectedProductChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlRightSection_Client_SelectedTabChanged() Handles ClientControlRightSection_Client.SelectedTabChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemDivision_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_Add.Click

            ClientControlRightSection_Client.ButtonLeftSection_Add.PerformClick()

        End Sub
        Private Sub ButtonItemDivision_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_Edit.Click

            ClientControlRightSection_Client.ButtonLeftSection_Edit.PerformClick()

        End Sub
        Private Sub ButtonItemDivision_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_CopyFrom.Click

            ClientControlRightSection_Client.ButtonItemDivisionCopy_From.RaiseClick()

        End Sub
        Private Sub ButtonItemDivision_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemDivision_Print.Click

            ' objects
            Dim SelectedDivisionCodes() As String = Nothing
            Dim ClientCode As String = Nothing

            ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue

            If ClientControlRightSection_Client.Enabled Then

                SelectedDivisionCodes = {ClientControlRightSection_Client.DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue}

                AdvantageFramework.Maintenance.Client.Presentation.DivisionReportsDialog.ShowFormDialog(ClientCode, Nothing, SelectedDivisionCodes)

            End If

        End Sub
        Private Sub ButtonItemDivision_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemDivision_PrintFiltered.Click

            'objects
            Dim SelectedAndAvailableDivisionCodes() As String = Nothing
            Dim ClientCode As String = Nothing

            ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue

            Try

                SelectedAndAvailableDivisionCodes = (From Entity In ClientControlRightSection_Client.DataGridViewLeftSection_Divisions.GetAllRowsBookmarkValues.OfType(Of String)()
                                                     Select Entity).ToArray

            Catch ex As Exception
                SelectedAndAvailableDivisionCodes = Nothing
            End Try

            AdvantageFramework.Maintenance.Client.Presentation.DivisionReportsDialog.ShowFormDialog(ClientCode, SelectedAndAvailableDivisionCodes, SelectedAndAvailableDivisionCodes)

        End Sub
        Private Sub ButtonItemProduct_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_Add.Click

            ClientControlRightSection_Client.ButtonRightSection_Add.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_Edit.Click

            ClientControlRightSection_Client.ButtonRightSection_Edit.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_CopyFrom.Click

            ClientControlRightSection_Client.ButtonItemProductCopy_From.RaiseClick()

        End Sub
        Private Sub ButtonItemProduct_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_Delete.Click

            ClientControlRightSection_Client.ButtonRightSection_Delete.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Print.Click

            ' objects
            Dim SelectedProductCodes() As String = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue

            If ClientControlRightSection_Client.Enabled Then

                DivisionCode = ClientControlRightSection_Client.DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                SelectedProductCodes = {ClientControlRightSection_Client.DataGridViewRightSection_Products.GetFirstSelectedRowBookmarkValue}

                AdvantageFramework.Maintenance.Client.Presentation.ProductReportsDialog.ShowFormDialog(ClientCode, DivisionCode, Nothing, SelectedProductCodes)

            End If

        End Sub
        Private Sub ButtonItemProduct_PrintFiltered_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_PrintFiltered.Click

            'objects
            Dim SelectedAndAvailableProductCodes() As String = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue
            DivisionCode = ClientControlRightSection_Client.DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

            Try

                SelectedAndAvailableProductCodes = (From Entity In ClientControlRightSection_Client.DataGridViewRightSection_Products.GetAllRowsBookmarkValues.OfType(Of String)()
                                                    Select Entity).ToArray

            Catch ex As Exception
                SelectedAndAvailableProductCodes = Nothing
            End Try

            AdvantageFramework.Maintenance.Client.Presentation.ProductReportsDialog.ShowFormDialog(ClientCode, DivisionCode, SelectedAndAvailableProductCodes, SelectedAndAvailableProductCodes)

        End Sub
        Private Sub ButtonItemDivision_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_Delete.Click

            ClientControlRightSection_Client.ButtonLeftSection_Delete.PerformClick()

        End Sub
        Private Sub ButtonItemProduct_CopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduct_CopyTo.Click

            ClientControlRightSection_Client.ButtonItemProductCopy_To.RaiseClick()

        End Sub
        Private Sub ButtonItemDivision_CopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivision_CopyTo.Click

            ClientControlRightSection_Client.ButtonItemDivisionCopy_To.RaiseClick()

        End Sub
        Private Sub ButtonItemWebsite_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemWebsite_Cancel.Click

            ClientControlRightSection_Client.CancelAddNewClientWebsite()

        End Sub
        Private Sub ButtonItemWebsite_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemWebsite_Delete.Click

            ClientControlRightSection_Client.DeleteSelectedClientWebsite()

        End Sub
        Private Sub ClientControlRightSection_Client_SelectedDocumentChanged() Handles ClientControlRightSection_Client.SelectedDocumentChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlRightSection_Client_ARCommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlRightSection_Client.ARCommentGotFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = True

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ClientControlRightSection_Client_ARCommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientControlRightSection_Client.ARCommentLostFocusEvent

            If Me.FormShown Then

                RibbonBarOptions_Text.Visible = False

                RibbonBarOptions_Text.Refresh()

                Me.Refresh()

            End If

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemText_CheckSpelling.Click

            If TypeOf ClientControlRightSection_Client.ActiveControl Is AdvantageFramework.WinForm.Presentation.Controls.TextBox Then

                DirectCast(ClientControlRightSection_Client.ActiveControl, AdvantageFramework.WinForm.Presentation.Controls.TextBox).CheckSpelling()

            End If

        End Sub
        Private Sub ButtonItemSortKeys_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortKeys_Delete.Click

            ClientControlRightSection_Client.DeleteSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortKeys_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortKeys_Cancel.Click

            ClientControlRightSection_Client.CancelAddSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ClientControlRightSection_Client_ClientSortKeysSelectionChangedEvent() Handles ClientControlRightSection_Client.ClientSortKeysSelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ClientControlRightSection_Client_ClientSortKeysInitNewRowEvent() Handles ClientControlRightSection_Client.ClientSortKeysInitNewRowEvent

            ButtonItemSortKeys_Delete.Enabled = False
            ButtonItemSortKeys_Cancel.Enabled = True

        End Sub
        Private Sub ClientControlRightSection_Client_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles ClientControlRightSection_Client.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            ClientControlRightSection_Client.UploadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            ClientControlRightSection_Client.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            ClientControlRightSection_Client.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            ClientControlRightSection_Client.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            ClientControlRightSection_Client.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Add.Click

            ClientControlRightSection_Client.AddContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Edit.Click

            ClientControlRightSection_Client.EditContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContacts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContacts_Delete.Click

            ClientControlRightSection_Client.DeleteContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Add.Click

            ClientControlRightSection_Client.AddContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Copy.Click

            ClientControlRightSection_Client.CopyContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Delete.Click

            ClientControlRightSection_Client.DeleteContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemContracts_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemContracts_Edit.Click

            ClientControlRightSection_Client.EditContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.Maintenance_Client_ClientImport)

            End If

        End Sub
        Private Sub ButtonItemDivision_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemDivision_Import.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.Maintenance_Client_DivisionImport)

            End If

        End Sub
        Private Sub ButtonItemProduct_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemProduct_Import.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.Maintenance_Client_ProductImport)

            End If

        End Sub
        Private Sub ClientControlRightSection_Client_ClearChangedEvent() Handles ClientControlRightSection_Client.ClearChangedEvent

            Me.ClearChanged()

        End Sub
        Private Sub ButtonItemQuickBooks_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickBooks_Refresh.Click

            ClientControlRightSection_Client.RefreshQuickbooksCustomer()

        End Sub

#End Region

#End Region

    End Class

End Namespace
