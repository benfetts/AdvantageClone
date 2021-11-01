Namespace Media.Presentation

    Public Class MediaTrafficResponseDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficResponseViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaTrafficController = Nothing
        Protected _Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor) = Nothing
        Protected _AllowNewComments As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor), AllowNewComments As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _Vendors = Vendors

            _AllowNewComments = AllowNewComments

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Response_Load(_Vendors)

            ConvertAlertCommentToText()

            DataGridViewPanel_Vendors.DataSource = (From Entity In _ViewModel.Vendors.OrderBy(Function(Entity) Entity.VendorCode)
                                                    Select New With {.VendorCode = Entity.VendorCode,
                                                                     .VendorName = Entity.VendorName}).ToList

            DataGridViewPanel_Vendors.CurrentView.BestFitColumns()

        End Sub
        Private Sub ConvertAlertCommentToText()

            Dim RepositoryItemRichTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit = Nothing

            RepositoryItemRichTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit
            RepositoryItemRichTextEdit.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Html

            For Each AlertComment In _ViewModel.AlertComments

                AlertComment.Comment = RepositoryItemRichTextEdit.ConvertEditValueToPlainText(AlertComment.Comment)

            Next

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_NewComment.Enabled = DataGridViewPanel_Vendors.HasOnlyOneSelectedRow AndAlso DataGridViewTop_Responses.HasRows AndAlso _AllowNewComments

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor), AllowNewComments As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficResponseDialog As MediaTrafficResponseDialog = Nothing

            MediaTrafficResponseDialog = New MediaTrafficResponseDialog(Vendors, AllowNewComments)

            ShowFormDialog = MediaTrafficResponseDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficResponseDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_NewComment.Image = AdvantageFramework.My.Resources.EmailNewImage

            DataGridViewPanel_Vendors.OptionsBehavior.Editable = False
            DataGridViewPanel_Vendors.SetBookmarkColumnIndex(0)

            _Controller = New AdvantageFramework.Controller.Media.MediaTrafficController(Me.Session)

        End Sub
        Private Sub MediaTrafficResponseDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_NewComment_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_NewComment.Click

            If AdvantageFramework.Media.Presentation.MediaTrafficProcessGenerateDialog.ShowFormDialog(_ViewModel.Vendors.Where(Function(V) V.VendorCode = DataGridViewPanel_Vendors.GetFirstSelectedRowBookmarkValue).First.AlertID) = Windows.Forms.DialogResult.OK Then

                LoadViewModel()

            End If

        End Sub
        Private Sub DataGridViewPanel_Vendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPanel_Vendors.SelectionChangedEvent

            'objects
            Dim VendorCodes As IEnumerable(Of Object) = Nothing

            If DataGridViewPanel_Vendors.HasASelectedRow Then

                VendorCodes = DataGridViewPanel_Vendors.GetAllSelectedRowsBookmarkValues()

                DataGridViewTop_Responses.DataSource = _ViewModel.AlertComments.Where(Function(AC) VendorCodes.Contains(AC.VendorCode)).OrderBy(Function(AC) AC.VendorCode).ThenByDescending(Function(AC) AC.CommentID).ToList

            Else

                DataGridViewTop_Responses.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.AlertComment)

            End If

            DataGridViewTop_Responses.CurrentView.BestFitColumns()

            If DataGridViewTop_Responses.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.AlertComment.Properties.Comment.ToString) IsNot Nothing Then

                DataGridViewTop_Responses.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.AlertComment.Properties.Comment.ToString).Width = 400

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewTop_Responses_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewTop_Responses.CellValueChangingEvent

            DataGridViewTop_Responses.CurrentView.CloseEditor()

        End Sub
        Private Sub DataGridViewTop_Responses_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewTop_Responses.ShowingEditorEvent

            If DataGridViewTop_Responses.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.Traffic.AlertComment.Properties.Comment.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
