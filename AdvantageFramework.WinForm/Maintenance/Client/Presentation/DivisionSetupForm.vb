Namespace Maintenance.Client.Presentation

    Public Class DivisionSetupForm

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

                    DataGridViewLeftSection_Divisions.DataSource = AdvantageFramework.Database.Procedures.Division.LoadByUserCode(ObjectContext, SecurityObjectContext, Me.Session.UserCode).Include("Client")

                    DataGridViewLeftSection_Divisions.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim DivisionCode As String = Nothing
            Dim ClientCode As String = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                DivisionControlRightSection_Division.ClearControl()

                DivisionControlRightSection_Division.Enabled = DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow

                If DivisionControlRightSection_Division.Enabled Then

                    DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue
                    ClientCode = DataGridViewLeftSection_Divisions.CurrentView.GetRowCellValue(DataGridViewLeftSection_Divisions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Division.Properties.ClientCode.ToString)

                    DivisionControlRightSection_Division.Enabled = DivisionControlRightSection_Division.LoadControl(ClientCode, DivisionCode, False)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            DivisionControlRightSection_Division.Enabled = (DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            RibbonBarMergeContainerForm_ProductActions.Visible = If(DivisionControlRightSection_Division.SelectedTab Is DivisionControlRightSection_Division.TabItemDivisionDetails_ProductsTab, True, False)
            RibbonBarMergeContainerForm_Documents.Visible = If(DivisionControlRightSection_Division.SelectedTab Is DivisionControlRightSection_Division.TabItemDivisionDetails_DocumentsTab, True, False)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow AndAlso DivisionControlRightSection_Division.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If DivisionControlRightSection_Division.SelectedTab Is DivisionControlRightSection_Division.TabItemDivisionDetails_GeneralTab Then

                If DivisionControlRightSection_Division.TabControlGeneral_General.SelectedTab Is DivisionControlRightSection_Division.TabItemGeneral_OptionsTab Then

                    RibbonBarOptions_SortOptions.Visible = True
                    ButtonItemSortOptions_Cancel.Enabled = DivisionControlRightSection_Division.DataGridViewOptions_SortOptions.IsNewItemRow
                    ButtonItemSortOptions_Delete.Enabled = DivisionControlRightSection_Division.DataGridViewOptions_SortOptions.HasOnlyOneSelectedRow

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

                ButtonItemDocuments_Delete.Enabled = DivisionControlRightSection_Division.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(DivisionControlRightSection_Division.DocumentManager.HasOnlyOneSelectedDocument, Not DivisionControlRightSection_Division.DocumentManager.IsSelectedDocumentAURL, DivisionControlRightSection_Division.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(DivisionControlRightSection_Division.DocumentManager.HasOnlyOneSelectedDocument, DivisionControlRightSection_Division.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = DivisionControlRightSection_Division.DocumentManager.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            ButtonItemProductActions_Delete.Enabled = DivisionControlRightSection_Division.HasASelectedProduct
            ButtonItemProductActions_Edit.Enabled = DivisionControlRightSection_Division.HasASelectedProduct
            

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            DivisionControlRightSection_Division.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

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

            If DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If DivisionControlRightSection_Division.Save() Then

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

                        DataGridViewLeftSection_Divisions.FocusToFindPanel(False)

                        DataGridViewLeftSection_Divisions.CurrentView.GridViewSelectionChanged()

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
            Dim DivisionSetupForm As AdvantageFramework.Maintenance.Client.Presentation.DivisionSetupForm = Nothing

            DivisionSetupForm = New AdvantageFramework.Maintenance.Client.Presentation.DivisionSetupForm()

            DivisionSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DivisionSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim UserDefinedLabelList As Generic.List(Of AdvantageFramework.Database.Entities.UserDefinedLabel) = Nothing
            Dim UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel = Nothing

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemProduct_Actions.Image = AdvantageFramework.My.Resources.ProductImage
            ButtonItemProductActions_Delete.Icon = AdvantageFramework.My.Resources.DeleteIcon
            ButtonItemProductActions_Edit.Icon = AdvantageFramework.My.Resources.EditIcon
            ButtonItemProductActions_Add.Icon = AdvantageFramework.My.Resources.AddIcon
            ButtonItemAddProduct_New.Icon = AdvantageFramework.My.Resources.AddIcon
            ButtonItemAddProduct_CopyFrom.Icon = AdvantageFramework.My.Resources.CopyIcon
            ButtonItemAddProduct_CopyTo.Icon = AdvantageFramework.My.Resources.CopyIcon

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemSortOptions_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemSortOptions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_Divisions.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Divisions.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DivisionSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Classes.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DivisionSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Divisions.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Divisions_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Divisions.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Divisions_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Divisions.SelectionChangedEvent

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
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(ClientCode, DivisionCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_Divisions.SelectRow(0, ClientCode & "|" & DivisionCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Divisions.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ContinueCopy As Boolean = True

            If DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    ClientCode = DataGridViewLeftSection_Divisions.CurrentView.GetRowCellValue(DataGridViewLeftSection_Divisions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Division.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(ClientCode, DivisionCode, True) = System.Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid()

                            DataGridViewLeftSection_Divisions.SelectRow(0, ClientCode & "|" & DivisionCode)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_Divisions.CurrentView.GridViewSelectionChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Divisions.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                    Try

                        If DivisionControlRightSection_Division.Delete() Then



                        End If

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.Cursor = Windows.Forms.Cursors.Default
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a division to delete.")

            End If

        End Sub
        Private Sub DivisionControlRightSection_Division_DivisionSortKeysInitNewRowEvent() Handles DivisionControlRightSection_Division.DivisionSortKeysInitNewRowEvent

            ButtonItemSortOptions_Delete.Enabled = False
            ButtonItemSortOptions_Cancel.Enabled = True

        End Sub
        Private Sub DivisionControlRightSection_Division_DivisionSortKeysSelectionChangedEvent() Handles DivisionControlRightSection_Division.DivisionSortKeysSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlRightSection_Division_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles DivisionControlRightSection_Division.InactiveChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub DivisionControlRightSection_Division_ProductOptionsChanged() Handles DivisionControlRightSection_Division.ProductOptionsChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlRightSection_Division_SelectedDetailTabChangedEvent() Handles DivisionControlRightSection_Division.SelectedDetailTabChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlRightSection_Division_SelectedDocumentChanged() Handles DivisionControlRightSection_Division.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlRightSection_Division_SelectedProductChanged(sender As Object, e As System.EventArgs) Handles DivisionControlRightSection_Division.SelectedProductChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DivisionControlRightSection_Division_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles DivisionControlRightSection_Division.SelectedTabChanging

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemAddProduct_New_Click(sender As Object, e As System.EventArgs) Handles ButtonItemAddProduct_New.Click

            DivisionControlRightSection_Division.AddProduct()

        End Sub
        Private Sub ButtonItemAddProduct_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemAddProduct_CopyFrom.Click

            DivisionControlRightSection_Division.CopyProductFrom()

        End Sub
        Private Sub ButtonItemAddProduct_CopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemAddProduct_CopyTo.Click

            DivisionControlRightSection_Division.CopyProductTo()

        End Sub
        Private Sub ButtonItemProductActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemProductActions_Delete.Click

            DivisionControlRightSection_Division.DeleteProduct()

        End Sub
        Private Sub ButtonItemProductActions_Edit_Click(sender As Object, e As System.EventArgs) Handles ButtonItemProductActions_Edit.Click

            DivisionControlRightSection_Division.EditProduct()

        End Sub
        Private Sub ButtonItemSortOptions_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortOptions_Cancel.Click

            DivisionControlRightSection_Division.CancelAddSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSortOptions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortOptions_Delete.Click

            DivisionControlRightSection_Division.DeleteSelectedSortKey()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            DivisionControlRightSection_Division.UploadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            DivisionControlRightSection_Division.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            DivisionControlRightSection_Division.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            DivisionControlRightSection_Division.DeleteDocument()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace