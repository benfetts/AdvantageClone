Namespace Desktop.Presentation

    Public Class DocumentManagerEditForm

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            UploadAndDownloadOnly
        End Enum

#End Region

#Region " Variables "

        Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
        Private _DocumentManagerType As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl.Type = Nothing
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing
        Private _CanDelete As Boolean = False
        'Private _CanAdd As Boolean = False
        Private _CanUpload As Boolean = False
        Private _UploadButtonVisible As Boolean = True
        Private _DownloadButtonVisible As Boolean = True
        Private _DeleteButtonVisible As Boolean = True

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, _
                        ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting, _
                        ByVal DocumentManagerType As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl.Type, _
                        ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel, _
                        ByVal UploadButtonVisible As Boolean, ByVal DownloadButtonVisible As Boolean, ByVal DeleteButtonVisible As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _DocumentLevel = DocumentLevel
            _DocumentLevelSetting = DocumentLevelSetting
            _DocumentManagerType = DocumentManagerType
            _DocumentSubLevel = DocumentSubLevel
            _UploadButtonVisible = UploadButtonVisible
            _DownloadButtonVisible = DownloadButtonVisible
            _DeleteButtonVisible = DeleteButtonVisible

        End Sub
        Private Sub LoadDocuments()

            DocumentManagerControlMain_Documents.ClearControl()

            DocumentManagerControlMain_Documents.Enabled = (_DocumentLevelSetting IsNot Nothing)

            If DocumentManagerControlMain_Documents.Enabled Then

                DocumentManagerControlMain_Documents.Enabled = DocumentManagerControlMain_Documents.LoadControl(_DocumentLevel, _DocumentLevelSetting, _DocumentManagerType, _DocumentSubLevel)

            End If
        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Delete.Enabled = _CanDelete AndAlso DocumentManagerControlMain_Documents.HasASelectedDocument
            ButtonItemActions_Download.Enabled = DocumentManagerControlMain_Documents.HasASelectedDocument
            ButtonItemActions_Add.Enabled = _CanUpload
            ButtonItemActions_Upload.Enabled = DocumentManagerControlMain_Documents.CanUpload AndAlso _CanUpload
            ButtonItemActions_OpenURL.Enabled = If(DocumentManagerControlMain_Documents.HasOnlyOneSelectedDocument, DocumentManagerControlMain_Documents.IsSelectedDocumentAURL, False)

        End Sub
        Private Function LoadBookmarkValue()

            'objects
            Dim BookmarkValue As Object = Nothing

            Select Case _DocumentLevel

                Case Database.Entities.DocumentLevel.ExpenseReceipts

                    If String.IsNullOrEmpty(_DocumentLevelSetting.ExpenseDetailID) = False Then

                        BookmarkValue = _DocumentLevelSetting.ExpenseDetailID

                    Else

                        BookmarkValue = _DocumentLevelSetting.ExpenseReportInvoiceNumber

                    End If

                Case Else

                    BookmarkValue = Nothing

            End Select

            LoadBookmarkValue = BookmarkValue

        End Function
        Private Sub LoadButtons()

            ButtonItemActions_Add.Visible = False

            ButtonItemActions_Delete.Visible = _DeleteButtonVisible
            ButtonItemActions_Upload.Visible = _UploadButtonVisible
            ButtonItemActions_Download.Visible = _DownloadButtonVisible

            Select Case _DocumentLevel

                Case Database.Entities.DocumentLevel.ExpenseReceipts

                    LoadExpenseReceiptsButtonActions()

                    If _DocumentSubLevel = Database.Entities.DocumentSubLevel.ExpenseDetailDocument Then

                        ButtonItemActions_Add.Visible = True

                    End If

                Case Database.Entities.DocumentLevel.JournalEntry

                    _CanDelete = True
                    _CanUpload = True

                Case Else

                    _CanDelete = False
                    _CanUpload = False

            End Select

        End Sub
        Private Sub LoadExpenseReceiptsButtonActions()

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _DocumentLevelSetting.ExpenseReportInvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    If AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport) = ExpenseReports.ExpenseReportStatus.Open Then

                        _CanUpload = True
                        _CanDelete = True

                    End If

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                              ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                                              Optional ByVal DocumentManagerType As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl.Type = WinForm.Presentation.Controls.DocumentManagerControl.Type.Default,
                                              Optional ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Database.Entities.DocumentSubLevel.Default,
                                              Optional ByVal UploadButtonVisible As Boolean = True, Optional ByVal DownloadButtonVisible As Boolean = True, Optional ByVal DeleteButtonVisible As Boolean = True) As System.Windows.Forms.DialogResult

            'objects
            Dim DocumentManagerEditForm As AdvantageFramework.Desktop.Presentation.DocumentManagerEditForm = Nothing

            DocumentManagerEditForm = New AdvantageFramework.Desktop.Presentation.DocumentManagerEditForm(DocumentLevel, DocumentLevelSetting, DocumentManagerType, DocumentSubLevel, UploadButtonVisible, DownloadButtonVisible, DeleteButtonVisible)

            ShowFormDialog = DocumentManagerEditForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentManagerEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemActions_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
			ButtonItemActions_OpenURL.Image = AdvantageFramework.My.Resources.Link
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemActions_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemActions_Upload.SplitButton = False

				End If

			End Using

			Try

                LoadDocuments()

            Catch ex As Exception

            End Try

            Try

                LoadButtons()

            Catch ex As Exception

            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemActions_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub DocumentManagerEditForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            'ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DocumentManagerEditForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            'ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument = Nothing
            Dim SelectedDocuments As IEnumerable = Nothing

            If _DocumentLevel = Database.Entities.DocumentLevel.ExpenseReceipts Then

                DocumentLevelSetting = _DocumentLevelSetting

                If AdvantageFramework.Desktop.Presentation.DocumentCRUDDialog.ShowFormDialog(_DocumentLevel, DocumentLevelSetting, True, False, True, SelectedDocuments, Database.Entities.DocumentSubLevel.Default) = Windows.Forms.DialogResult.OK Then

                    If SelectedDocuments IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each Document In SelectedDocuments

                                Try

                                    ExpenseDetailDocument = New AdvantageFramework.Database.Entities.ExpenseDetailDocument

                                    ExpenseDetailDocument.ExpenseDetailID = _DocumentLevelSetting.ExpenseDetailID
                                    ExpenseDetailDocument.DocumentID = Document.ID

                                Catch ex As Exception
                                    ExpenseDetailDocument = Nothing
                                End Try

                                If ExpenseDetailDocument IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Insert(DbContext, ExpenseDetailDocument) = False Then

                                        Try

                                            DbContext.DeleteEntityObject(ExpenseDetailDocument)

                                        Catch ex As Exception

                                        End Try

                                    End If

                                End If

                            Next

                        End Using

                        LoadDocuments()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Upload.Click

            DocumentManagerControlMain_Documents.UploadNewDocument()

        End Sub
        Private Sub DocumentManagerControlMain_Documents_SelectedDocumentChanged() Handles DocumentManagerControlMain_Documents.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Download.Click

            DocumentManagerControlMain_Documents.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_OpenURL.Click

            DocumentManagerControlMain_Documents.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
		Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            If _DocumentLevel = Database.Entities.Methods.DocumentLevel.ExpenseReceipts Then

                If _DocumentSubLevel = Database.Entities.Methods.DocumentSubLevel.ExpenseDetailDocument Then

                    DocumentManagerControlMain_Documents.DeleteSelectedDocument(True)

                Else

                    DocumentManagerControlMain_Documents.DeleteSelectedDocument(False)

                End If

            Else

                DocumentManagerControlMain_Documents.DeleteSelectedDocument(False)

            End If

            EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			DocumentManagerControlMain_Documents.SendASPUploadEmail()

		End Sub

#End Region

#End Region

	End Class

End Namespace