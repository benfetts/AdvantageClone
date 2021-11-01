Namespace Maintenance.Accounting.Presentation

    Public Class OfficeSetupForm

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

                DataGridViewLeftSection_Offices.DataSource = AdvantageFramework.Database.Procedures.Office.LoadCore(AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Me.Session)).ToList

            End Using

            DataGridViewLeftSection_Offices.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            OfficeControlRightSection_Office.ClearControl()

            OfficeControlRightSection_Office.Enabled = DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow

            If OfficeControlRightSection_Office.Enabled Then

                OfficeControlRightSection_Office.Enabled = OfficeControlRightSection_Office.LoadControl(DataGridViewLeftSection_Offices.GetFirstSelectedRowBookmarkValue, False, False, False, False, False, False, False, False, False)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            OfficeControlRightSection_Office.Enabled = (DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Copy.Enabled = (DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow AndAlso OfficeControlRightSection_Office.Enabled)
            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow AndAlso OfficeControlRightSection_Office.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Export.Enabled = (DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow AndAlso OfficeControlRightSection_Office.Enabled)

            RibbonBarMergeContainerForm_FunctionAccounts.Visible = If(OfficeControlRightSection_Office.SelectedTab Is OfficeControlRightSection_Office.TabItemOffice_FunctionAccountsTab, True, False)
            RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Visible = If(OfficeControlRightSection_Office.SelectedTab Is OfficeControlRightSection_Office.TabItemOffice_SalesClassFunctionAccountsTab, True, False)
            RibbonBarMergeContainerForm_SalesTaxAccounts.Visible = If(OfficeControlRightSection_Office.SelectedTab Is OfficeControlRightSection_Office.TabItemOffice_SalesTaxAccountsTab, True, False)
            RibbonBarMergeContainerForm_OverheadSets.Visible = If(OfficeControlRightSection_Office.SelectedTab Is OfficeControlRightSection_Office.TabItemOffice_OverheadSetsTab, True, False)
            RibbonBarOptions_Documents.Visible = If(OfficeControlRightSection_Office.SelectedTab Is OfficeControlRightSection_Office.TabItemOffice_DocumentsTab, True, False)

            ButtonItemFunctionAccounts_Cancel.Enabled = OfficeControlRightSection_Office.DataGridViewOfficeFunctionAccountsIsNewItemRow
            ButtonItemFunctionAccounts_Delete.Enabled = (Not OfficeControlRightSection_Office.DataGridViewOfficeFunctionAccountsIsNewItemRow) AndAlso OfficeControlRightSection_Office.DataGridViewOfficeFunctionAccountsHasRows
            ButtonItemFunctionAccounts_Copy.Enabled = OfficeControlRightSection_Office.CanCopyGLFunctionAccounts

            ButtonItemSalesClassFunctionAccounts_Cancel.Enabled = OfficeControlRightSection_Office.DataGridViewOfficeSalesClassFunctionAccountsIsNewItemRow
            ButtonItemSalesClassFunctionAccounts_Delete.Enabled = Not (OfficeControlRightSection_Office.DataGridViewOfficeSalesClassFunctionAccountsIsNewItemRow) AndAlso OfficeControlRightSection_Office.DataGridViewOfficeSalesClassFunctionAccountsHasRows
            ButtonItemSalesClassFunctionAccounts_Copy.Enabled = OfficeControlRightSection_Office.CanCopyGLSalesClassFunctionAccounts

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = OfficeControlRightSection_Office.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(OfficeControlRightSection_Office.DocumentManager.HasOnlyOneSelectedDocument, Not OfficeControlRightSection_Office.DocumentManager.IsSelectedDocumentAURL, OfficeControlRightSection_Office.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(OfficeControlRightSection_Office.DocumentManager.HasOnlyOneSelectedDocument, OfficeControlRightSection_Office.DocumentManager.IsSelectedDocumentAURL, False)
                ButtonItemDocuments_Upload.Enabled = OfficeControlRightSection_Office.DocumentManager.CanUpload

            Else

                ButtonItemDocuments_Upload.Enabled = False
                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            ButtonItemSalesTaxAccounts_Cancel.Enabled = OfficeControlRightSection_Office.DataGridViewSalesTaxAccountsIsNewItemRow
            ButtonItemSalesTaxAccounts_Delete.Enabled = (Not OfficeControlRightSection_Office.DataGridViewSalesTaxAccountsIsNewItemRow) AndAlso OfficeControlRightSection_Office.DataGridViewSalesTaxAccountsHasRows

            ButtonItemOverheadSets_Cancel.Enabled = OfficeControlRightSection_Office.DataGridViewOverheadSetsIsNewItemRow
            ButtonItemOverheadSets_Delete.Enabled = (Not OfficeControlRightSection_Office.DataGridViewOverheadSetsIsNewItemRow) AndAlso OfficeControlRightSection_Office.DataGridViewOverheadSetsHasRows

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    OfficeControlRightSection_Office.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = OfficeControlRightSection_Office.Save()

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

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim OfficeSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.OfficeSetupForm = Nothing

            OfficeSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.OfficeSetupForm()

            OfficeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub OfficeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemFunctionAccounts_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemFunctionAccounts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemFunctionAccounts_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemSalesClassFunctionAccounts_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemSalesClassFunctionAccounts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemSalesClassFunctionAccounts_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemSalesTaxAccounts_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemSalesTaxAccounts_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemOverheadSets_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemOverheadSets_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

			DataGridViewLeftSection_Offices.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemDocuments_Upload.SplitButton = False

				End If

			End Using

			Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Offices.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub OfficeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub OfficeSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Offices.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Offices_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Offices.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Offices_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Offices.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub OfficeControlRightSection_Office_FunctionAccountsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OfficeControlRightSection_Office.FunctionAccountsInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_FunctionAccountsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfficeControlRightSection_Office.FunctionAccountsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_OfficeInActiveChanged() Handles OfficeControlRightSection_Office.OfficeInActiveChanged

            LoadGrid()

            LoadSelectedItemDetails()

        End Sub
        Private Sub OfficeControlRightSection_Office_OverheadSetsInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OfficeControlRightSection_Office.OverheadSetsInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_OverheadSetsSelectionChangedEvent(sender As Object, e As EventArgs) Handles OfficeControlRightSection_Office.OverheadSetsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_SalesClassAccountsComboboxChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfficeControlRightSection_Office.SalesClassAccountsComboboxChanged

            Me.SuperValidator.Validate(OfficeControlRightSection_Office.SearchableComboBoxSalesClassAccounts_MediaCOS)
            Me.SuperValidator.Validate(OfficeControlRightSection_Office.SearchableComboBoxSalesClassAccounts_MediaSales)
            Me.SuperValidator.Validate(OfficeControlRightSection_Office.SearchableComboBoxSalesClassAccounts_ProductionCOS)
            Me.SuperValidator.Validate(OfficeControlRightSection_Office.SearchableComboBoxSalesClassAccounts_ProductionSales)

        End Sub
        Private Sub OfficeControlRightSection_Office_SalesClassFunctionAccountsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OfficeControlRightSection_Office.SalesClassFunctionAccountsInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_SalesClassFunctionAccountsSalesClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfficeControlRightSection_Office.SalesClassFunctionAccountsSalesClassSelectedIndexChanged

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_SalesClassFunctionAccountsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfficeControlRightSection_Office.SalesClassFunctionAccountsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow Then

                OfficeControlRightSection_Office.LoadRequiredNonGridControlsForValidation()

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If OfficeControlRightSection_Office.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Offices.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an office to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim OfficeCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.OfficeEditDialog.ShowFormDialog(OfficeCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Offices.SelectRow(OfficeCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Offices.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then
                    'Are you sure you want to delete this office including all sales class and sales tax associated with it?
                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If OfficeControlRightSection_Office.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an office to delete.")

            End If

        End Sub
        Private Sub ButtonItemFunctionAccounts_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFunctionAccounts_Cancel.Click

            OfficeControlRightSection_Office.CancelAddNewFunctionAccount()

        End Sub
        Private Sub ButtonItemFunctionAccounts_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemFunctionAccounts_Copy.Click

            Dim OfficeCode As String = Nothing

            If DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow Then

                OfficeCode = DataGridViewLeftSection_Offices.GetFirstSelectedRowBookmarkValue

                If OfficeControlRightSection_Office.CanCopyGLFunctionAccounts Then

                    If AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeFunctionGLAccountsDialog.ShowFormDialog(OfficeCode) = System.Windows.Forms.DialogResult.OK Then

                        OfficeControlRightSection_Office.RefreshFunctionAccountsTab()

                        EnableOrDisableActions()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemFunctionAccounts_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemFunctionAccounts_Delete.Click

            OfficeControlRightSection_Office.DeleteSelectedFunctionAccount()

        End Sub
        Private Sub ButtonItemColorCharges_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSalesClassFunctionAccounts_Cancel.Click

            OfficeControlRightSection_Office.CancelAddNewSalesClassFunctionAccount()

        End Sub
        Private Sub ButtonItemColorCharges_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSalesClassFunctionAccounts_Delete.Click

            OfficeControlRightSection_Office.DeleteSelectedSalesClassFunctionAccount()
            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_SalesTaxAccountsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OfficeControlRightSection_Office.SalesTaxAccountsInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_SalesTaxAccountsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfficeControlRightSection_Office.SalesTaxAccountsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_SelectedDocumentChanged() Handles OfficeControlRightSection_Office.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub OfficeControlRightSection_Office_SelectedTabChanged() Handles OfficeControlRightSection_Office.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            Dim OfficeCode As String = Nothing
            Dim CopyDefaultAccts As Boolean = False
            Dim CopyDefaultProductionAccts As Boolean = False
            Dim CopyDefaultMediaAccts As Boolean = False
            Dim CopyProductionSalesClassFunctionAccts As Boolean = False
            Dim CopyProductionFunctionAccts As Boolean = False
            Dim CopyMediaSalesClassAccts As Boolean = False
            Dim CopySalesTaxAccts As Boolean = False
            Dim ReplaceOfficeSegment As Boolean = False
            Dim ContinueCopy As Boolean = True

            If DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    OfficeCode = DataGridViewLeftSection_Offices.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeGLAccountsDialog.ShowFormDialog(CopyDefaultAccts, CopyDefaultProductionAccts, CopyDefaultMediaAccts, CopyProductionSalesClassFunctionAccts, CopyProductionFunctionAccts, CopyMediaSalesClassAccts, CopySalesTaxAccts, ReplaceOfficeSegment) = System.Windows.Forms.DialogResult.OK Then

                        If AdvantageFramework.Maintenance.Accounting.Presentation.OfficeEditDialog.ShowFormDialog(OfficeCode, True, CopyDefaultAccts, CopyDefaultProductionAccts, CopyDefaultMediaAccts, CopyProductionSalesClassFunctionAccts, CopyProductionFunctionAccts, CopyMediaSalesClassAccts, CopySalesTaxAccts, ReplaceOfficeSegment) = System.Windows.Forms.DialogResult.OK Then

                            LoadGrid()

                            DataGridViewLeftSection_Offices.SelectRow(OfficeCode)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSalesClassFunctionAccounts_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemSalesClassFunctionAccounts_Copy.Click

            Dim OfficeCode As String = Nothing
            Dim SalesClassCode As String = Nothing

            If DataGridViewLeftSection_Offices.HasOnlyOneSelectedRow Then

                OfficeCode = DataGridViewLeftSection_Offices.GetFirstSelectedRowBookmarkValue
                SalesClassCode = OfficeControlRightSection_Office.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.GetSelectedValue

                If OfficeControlRightSection_Office.CanCopyGLSalesClassFunctionAccounts Then

                    If AdvantageFramework.Maintenance.Accounting.Presentation.CopyOfficeSalesClassGLAccountsDialog.ShowFormDialog(OfficeCode, SalesClassCode) = System.Windows.Forms.DialogResult.OK Then

                        OfficeControlRightSection_Office.RefreshSalesClassTab()

                        EnableOrDisableActions()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSalesTaxAccounts_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSalesTaxAccounts_Cancel.Click

            OfficeControlRightSection_Office.CancelAddNewSalesTaxAccount()

        End Sub
        Private Sub ButtonItemSalesTaxAccounts_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSalesTaxAccounts_Delete.Click

            OfficeControlRightSection_Office.DeleteSelectedSalesTaxAccount()

        End Sub
		Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

			OfficeControlRightSection_Office.DocumentManager.UploadNewDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			OfficeControlRightSection_Office.DocumentManager.SendASPUploadEmail()

		End Sub
		Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            OfficeControlRightSection_Office.DocumentManager.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            OfficeControlRightSection_Office.DocumentManager.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            OfficeControlRightSection_Office.DocumentManager.DeleteSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim OfficeCode As String = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            Try

                If DataGridViewLeftSection_Offices.HasASelectedRow Then

                    OfficeCode = DataGridViewLeftSection_Offices.GetFirstSelectedRowBookmarkValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DataTable = New System.Data.DataTable

                        SqlConnection = DbContext.Database.Connection
                        SqlCommand = New System.Data.SqlClient.SqlCommand("[dbo].[advsp_office_rpt]", SqlConnection)
                        SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

                        Using SqlCommand

                            SqlCommand.CommandType = CommandType.StoredProcedure
                            SQLParameter = New System.Data.SqlClient.SqlParameter("OFFICE_CODE", System.Data.SqlDbType.VarChar) With {.Value = OfficeCode}
                            SqlCommand.Parameters.Add(SQLParameter)

                            SqlDataAdapter.Fill(DataTable)

                        End Using

                    End Using

                End If

                DataGridView = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView

                DataGridView.OptionsView.ShowViewCaption = False
                DataGridView.OptionsPrint.AutoWidth = False
                DataGridView.DataSource = DataTable
                DataGridView.CurrentView.BestFitColumns()

                DataGridView.Print(Me.Session, DefaultLookAndFeel.LookAndFeel, "Office Report")

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemOverheadSets_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemOverheadSets_Cancel.Click

            OfficeControlRightSection_Office.CancelAddNewOverheadSet()

        End Sub
        Private Sub ButtonItemOverheadSets_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemOverheadSets_Delete.Click

            OfficeControlRightSection_Office.DeleteSelectedOverheadSet()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Processing...")

                Try

                    OfficeControlRightSection_Office.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Offices.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace