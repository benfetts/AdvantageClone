Namespace Desktop.Presentation

    Public Class DocumentCRUDDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing
        Private _DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Nothing
        Private _DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
        Private _IsSelecting As Boolean = False
        Private _SelectedDocuments As IEnumerable = Nothing
        Private _ShowAddDeleteButtons As Boolean = False
        Private _AllowMultiSelect As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property SelectedDocuments() As IEnumerable
            Get
                SelectedDocuments = _SelectedDocuments
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, _
                        ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting, _
                        ByVal IsSelecting As Boolean, ByVal ShowAddDeleteButtons As Boolean, ByVal AllowMultiSelect As Boolean, _
                        ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel)

            ' This call is required by the designer.
            InitializeComponent()

            _DocumentLevel = DocumentLevel
            _DocumentSubLevel = DocumentSubLevel
            _DocumentLevelSetting = DocumentLevelSetting
            _IsSelecting = IsSelecting
            _ShowAddDeleteButtons = ShowAddDeleteButtons
            _AllowMultiSelect = AllowMultiSelect

        End Sub
        Private Sub LoadDocuments()

            If _DocumentLevelSetting IsNot Nothing Then

                DocumentManagerControlForm_Documents.ClearControl()

                DocumentManagerControlForm_Documents.Enabled = DocumentManagerControlForm_Documents.LoadControl(_DocumentLevel, _DocumentLevelSetting, WinForm.Presentation.Controls.DocumentManagerControl.Type.ViewOnly, _DocumentSubLevel)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, _
                                              ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting, _
                                              ByVal IsSelecting As Boolean, ByVal ShowAddDeleteButtons As Boolean, ByVal AllowMultiSelect As Boolean, _
                                              Optional ByRef SelectedDocuments As IEnumerable = Nothing, _
                                              Optional ByVal DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel = Database.Entities.DocumentSubLevel.Default) As System.Windows.Forms.DialogResult

            'objects
            Dim DocumentCRUDDialog As AdvantageFramework.Desktop.Presentation.DocumentCRUDDialog = Nothing

            DocumentCRUDDialog = New AdvantageFramework.Desktop.Presentation.DocumentCRUDDialog(DocumentLevel, DocumentLevelSetting, IsSelecting, ShowAddDeleteButtons, AllowMultiSelect, DocumentSubLevel)

            ShowFormDialog = DocumentCRUDDialog.ShowDialog()

            If IsSelecting Then

                SelectedDocuments = DocumentCRUDDialog.SelectedDocuments

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentCRUDDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonForm_Add.Visible = _ShowAddDeleteButtons
            ButtonForm_Delete.Visible = _ShowAddDeleteButtons
            ButtonForm_Select.Visible = _IsSelecting

            Try

                LoadDocuments()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Select_Click(sender As Object, e As EventArgs) Handles ButtonForm_Select.Click

            If DocumentManagerControlForm_Documents.HasASelectedDocument Then

                _SelectedDocuments = DocumentManagerControlForm_Documents.DocumentsDataGridView.GetAllSelectedRowsDataBoundItems

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace