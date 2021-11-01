Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMakegoodResponseDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheetMakegoodResponseViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
        Protected _MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetMarketDetailIDs = MediaBroadcastWorksheetMarketDetailIDs

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Response_Load(_MediaBroadcastWorksheetMarketDetailIDs)

            ConvertAlertCommentToText()

            DataGridViewPanel_Vendors.DataSource = (From Entity In _ViewModel.OrderAlertComments.OrderBy(Function(Entity) Entity.VendorCode)
                                                    Select Entity.VendorCode, Entity.VendorName).Distinct.ToList

            DataGridViewPanel_Vendors.CurrentView.BestFitColumns()

        End Sub
        Private Sub ConvertAlertCommentToText()

            Dim RepositoryItemRichTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit = Nothing

            RepositoryItemRichTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit
            RepositoryItemRichTextEdit.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Html

            For Each OrderAlertComment In _ViewModel.OrderAlertComments

                OrderAlertComment.Comment = RepositoryItemRichTextEdit.ConvertEditValueToPlainText(OrderAlertComment.Comment)

            Next

        End Sub
        Private Sub LoadDocuments()

            'objects
            Dim SelectedVendorCodes As IEnumerable(Of String) = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SelectedVendorCodes = DataGridViewPanel_Vendors.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                DocumentManagerControlBottom_AlertDocuments.ClearControl()

                DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                If _ViewModel.OrderAlertComments IsNot Nothing AndAlso _ViewModel.OrderAlertComments.Count > 0 Then

                    For Each AlertID In _ViewModel.OrderAlertComments.Where(Function(AC) SelectedVendorCodes.Contains(AC.VendorCode)).Select(Function(AC) AC.AlertID)

                        DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AlertAttachment) With {.AlertID = AlertID})

                    Next

                    DocumentManagerControlBottom_AlertDocuments.Enabled = DocumentManagerControlBottom_AlertDocuments.LoadControl(Database.Entities.DocumentLevel.AlertAttachment, DocumentLevelSettings,
                                                                                                                                  AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl.Type.HideHistoryEnableActions,
                                                                                                                                  Database.Entities.DocumentSubLevel.Default)

                End If

                For Each GridColumn In DocumentManagerControlBottom_AlertDocuments.DataGridViewForm_Documents.Columns

                    If GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.FileType.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.Keywords.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.UserCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.IsPrivate.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQFileID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.ProofHQUrl.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.DocumentTypeID.ToString Then

                        GridColumn.Visible = False

                    ElseIf GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.UploadedDate.ToString Then

                        GridColumn.Caption = "Received Date"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.Description.ToString Then

                        GridColumn.Caption = "Vendor Name"

                    End If

                Next

                For Each GridColumn In DocumentManagerControlBottom_AlertDocuments.DataGridViewForm_Documents.Columns

                    If GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.Description.ToString Then

                        GridColumn.VisibleIndex = 1

                    ElseIf GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.FileName.ToString Then

                        GridColumn.VisibleIndex = 2

                    ElseIf GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.FileSize.ToString Then

                        GridColumn.VisibleIndex = 3

                    ElseIf GridColumn.FieldName = AdvantageFramework.DocumentManager.Classes.Document.Properties.UploadedDate.ToString Then

                        GridColumn.VisibleIndex = 4

                    End If

                Next

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Download.Enabled = DocumentManagerControlBottom_AlertDocuments.HasOnlyOneSelectedDocument
            ButtonItemActions_Import.Enabled = DocumentManagerControlBottom_AlertDocuments.HasASelectedDocument
            ButtonItemActions_NewComment.Enabled = DataGridViewPanel_Vendors.HasOnlyOneSelectedRow AndAlso DataGridViewTop_Responses.HasRows

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMakegoodResponseDialog As MediaBroadcastWorksheetMakegoodResponseDialog = Nothing

            MediaBroadcastWorksheetMakegoodResponseDialog = New MediaBroadcastWorksheetMakegoodResponseDialog(MediaBroadcastWorksheetMarketDetailIDs)

            ShowFormDialog = MediaBroadcastWorksheetMakegoodResponseDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMakegoodResponseDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemActions_NewComment.Image = AdvantageFramework.My.Resources.EmailNewImage

            DataGridViewPanel_Vendors.OptionsBehavior.Editable = False
            DataGridViewPanel_Vendors.SetBookmarkColumnIndex(0)

            _Controller = New AdvantageFramework.Controller.Media.MakegoodDeliveryController(Me.Session)

        End Sub
        Private Sub MediaBroadcastWorksheetMakegoodResponseDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            LoadDocuments()

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

        End Sub
        Private Sub ButtonItemActions_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Download.Click

            DocumentManagerControlBottom_AlertDocuments.DownloadSelectedDocument()

        End Sub
        Private Sub ButtonItemActions_NewComment_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_NewComment.Click

            If AdvantageFramework.Media.Presentation.MediaRequestForProposalProcessGenerateRFPDialog.ShowFormDialog(_ViewModel.OrderAlertComments.Where(Function(H) H.VendorCode = DataGridViewPanel_Vendors.GetFirstSelectedRowBookmarkValue).First.AlertID) = Windows.Forms.DialogResult.OK Then

                LoadViewModel()

            End If

        End Sub
        Private Sub DataGridViewPanel_Vendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPanel_Vendors.SelectionChangedEvent

            'objects
            Dim VendorCodes As IEnumerable(Of Object) = Nothing

            If DataGridViewPanel_Vendors.HasASelectedRow Then

                VendorCodes = DataGridViewPanel_Vendors.GetAllSelectedRowsBookmarkValues()

                DataGridViewTop_Responses.DataSource = _ViewModel.OrderAlertComments.Where(Function(AC) VendorCodes.Contains(AC.VendorCode)).OrderBy(Function(AC) AC.VendorCode).ThenByDescending(Function(AC) AC.CommentID).ToList

            Else

                DataGridViewTop_Responses.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.AlertComment)

            End If

            If DataGridViewTop_Responses.CurrentView.Columns(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.CommentDateString.ToString) IsNot Nothing Then

                DataGridViewTop_Responses.CurrentView.Columns(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.CommentDateString.ToString).Visible = False

            End If

            DataGridViewTop_Responses.CurrentView.BestFitColumns()

            If DataGridViewTop_Responses.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.AlertComment.Properties.Comment.ToString) IsNot Nothing Then

                DataGridViewTop_Responses.CurrentView.Columns(AdvantageFramework.DTO.Media.RFP.AlertComment.Properties.Comment.ToString).Width = 400

            End If

            LoadDocuments()

        End Sub
        Private Sub DataGridViewTop_Responses_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewTop_Responses.CellValueChangingEvent

            DataGridViewTop_Responses.CurrentView.CloseEditor()

        End Sub
        Private Sub DataGridViewTop_Responses_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewTop_Responses.ShowingEditorEvent

            If DataGridViewTop_Responses.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.RFP.AlertComment.Properties.Comment.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
