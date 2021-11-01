Namespace Maintenance.Client.Presentation

    Public Class ProductSetupForm

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

            Using SecurityObjectContext = New AdvantageFramework.Security.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_Products.DataSource = AdvantageFramework.Database.Procedures.Product.LoadByUserCode(ObjectContext, SecurityObjectContext, Me.Session.UserCode, True)

                End Using

            End Using

            DataGridViewLeftSection_Products.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim DivisionCode As String = Nothing
            Dim ClientCode As String = Nothing
            Dim ProductCode As String = Nothing

            ProductControlRightSection_Product.ClearControl()

            ProductControlRightSection_Product.Enabled = DataGridViewLeftSection_Products.HasOnlyOneSelectedRow

            If ProductControlRightSection_Product.Enabled Then

                ProductCode = DataGridViewLeftSection_Products.GetFirstSelectedRowBookmarkValue
                ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString)

                ProductControlRightSection_Product.Enabled = ProductControlRightSection_Product.LoadControl(ClientCode, DivisionCode, ProductCode, False)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_Products.HasOnlyOneSelectedRow
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            RibbonBarMergeContainerForm_Documents.Visible = If(ProductControlRightSection_Product.SelectedTab Is ProductControlRightSection_Product.TabItemProductSetup_DocumentsTab, True, False)

            RibbonBarOptions_Affiliations.Visible = If(ProductControlRightSection_Product.SelectedTab Is ProductControlRightSection_Product.TabItemProductSetup_CompanyProfileTab, True, False)

            If RibbonBarOptions_Affiliations.Visible Then

                ButtonItemAffiliations_Cancel.Enabled = ProductControlRightSection_Product.DataGridViewCompanyProfile_Affiliations.IsNewItemRow
                ButtonItemAffiliations_Delete.Enabled = ProductControlRightSection_Product.DataGridViewCompanyProfile_Affiliations.HasOnlyOneSelectedRow

            End If

            If ProductControlRightSection_Product.SelectedTab Is ProductControlRightSection_Product.TabItemProductSetup_GeneralTab Then

                If ProductControlRightSection_Product.TabControlGeneral_General.SelectedTab Is ProductControlRightSection_Product.TabItemGeneral_OptionsTab Then

                    RibbonBarOptions_SortOptions.Visible = True
                    ButtonItemSortOptions_Cancel.Enabled = ProductControlRightSection_Product.DataGridViewRightColumn_SortOptions.IsNewItemRow
                    ButtonItemSortOptions_Delete.Enabled = ProductControlRightSection_Product.DataGridViewRightColumn_SortOptions.HasOnlyOneSelectedRow

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

                ButtonItemDocuments_Delete.Enabled = ProductControlRightSection_Product.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(ProductControlRightSection_Product.DocumentManager.HasOnlyOneSelectedDocument, Not ProductControlRightSection_Product.DocumentManager.IsSelectedDocumentAURL, ProductControlRightSection_Product.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(ProductControlRightSection_Product.DocumentManager.HasOnlyOneSelectedDocument, ProductControlRightSection_Product.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = ProductControlRightSection_Product.DocumentManager.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            ProductControlRightSection_Product.Enabled = (DataGridViewLeftSection_Products.HasOnlyOneSelectedRow AndAlso Me.FormShown)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    ProductControlRightSection_Product.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = ProductControlRightSection_Product.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.Cursor = Windows.Forms.Cursors.Default
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

            If DataGridViewLeftSection_Products.HasOnlyOneSelectedRow Then

                ProductControlRightSection_Product.LoadRequiredNonGridControlsForValidation()

                If Me.Validator Then

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If ProductControlRightSection_Product.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.Cursor = Windows.Forms.Cursors.Default
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_Products.FocusToFindPanel(False)

                        DataGridViewLeftSection_Products.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a product to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ProductSetupForm As AdvantageFramework.Maintenance.Client.Presentation.ProductSetupForm = Nothing

            ProductSetupForm = New AdvantageFramework.Maintenance.Client.Presentation.ProductSetupForm()

            ProductSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ProductSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim UserDefinedLabelList As Generic.List(Of AdvantageFramework.Database.Entities.UserDefinedLabel) = Nothing
            Dim UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel = Nothing

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemSortOptions_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemSortOptions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemAffiliations_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemAffiliations_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_Products.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Products.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ProductSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProductSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Classes.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProductSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Products.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Products_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Products.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Products_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Products.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Products.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(ClientCode, DivisionCode, ProductCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_Products.SelectRow(0, ClientCode & "|" & DivisionCode & "|" & ProductCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Products.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ContinueCopy As Boolean = Nothing

            If DataGridViewLeftSection_Products.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewLeftSection_Products.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(ClientCode, DivisionCode, ProductCode, True) = Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid()

                            DataGridViewLeftSection_Products.SelectRow(0, ClientCode & "|" & DivisionCode & "|" & ProductCode)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_Products.CurrentView.GridViewSelectionChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Products.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                    Try

                        If ProductControlRightSection_Product.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.Cursor = Windows.Forms.Cursors.Default
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Products.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a product to delete.")

            End If

        End Sub
        Private Sub ProductControlRightSection_Product_AffiliationInitNewRowEvent() Handles ProductControlRightSection_Product.AffiliationInitNewRowEvent

            ButtonItemAffiliations_Delete.Enabled = False
            ButtonItemAffiliations_Cancel.Enabled = True

        End Sub
        Private Sub ProductControlRightSection_Product_AffiliationSelectionChangedEvent() Handles ProductControlRightSection_Product.AffiliationSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlRightSection_Product_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles ProductControlRightSection_Product.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub ProductControlRightSection_Product_SelectedDocumentChanged() Handles ProductControlRightSection_Product.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlRightSection_Product_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles ProductControlRightSection_Product.SelectedTabChanging

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlRightSection_Product_SelectedDetailChangedEvent() Handles ProductControlRightSection_Product.SelectedDetailChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlRightSection_Product_ProductSortKeysSelectionChangedEvent() Handles ProductControlRightSection_Product.ProductSortKeysSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductControlRightSection_Product_ProductSortKeysInitNewRowEvent() Handles ProductControlRightSection_Product.ProductSortKeysInitNewRowEvent

            ButtonItemSortOptions_Delete.Enabled = False
            ButtonItemSortOptions_Cancel.Enabled = True

        End Sub
        Private Sub ButtonItemSortOptions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSortOptions_Cancel.Click

            ProductControlRightSection_Product.CancelAddSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortOptions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSortOptions_Delete.Click

            ProductControlRightSection_Product.DeleteSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click_1(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            ProductControlRightSection_Product.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            ProductControlRightSection_Product.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click_1(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            ProductControlRightSection_Product.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click_1(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            ProductControlRightSection_Product.UploadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemAffiliations_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemAffiliations_Cancel.Click

            ProductControlRightSection_Product.CancelAddNewCompanyProfileAffiliation()

        End Sub
        Private Sub ButtonItemAffiliations_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemAffiliations_Delete.Click

            ProductControlRightSection_Product.DeleteSelectedCompanyProfileAffiliation()

        End Sub

#End Region

#End Region

    End Class

End Namespace