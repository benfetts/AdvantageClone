Namespace Desktop.Presentation

    Public Class AdvancedDocumentSearchDialog

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


        End Sub
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim AdvancedDocumentSearchDialog As AdvantageFramework.Desktop.Presentation.AdvancedDocumentSearchDialog = Nothing

            AdvancedDocumentSearchDialog = New AdvantageFramework.Desktop.Presentation.AdvancedDocumentSearchDialog()

            ShowFormDialog = AdvancedDocumentSearchDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AdvancedDocumentSearchDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                DocumentManagerControlForm_DocumentManager.LoadControlForAdvancedDocumentSearch()

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Search_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Search.Click

            DocumentManagerControlForm_DocumentManager.AdvancedFilterDocuments(TextBoxForm_SearchCriteria.Text)

        End Sub

        Private Sub ButtonForm_Export_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Export.Click

            DocumentManagerControlForm_DocumentManager.DataGridViewForm_Documents.Print(DefaultLookAndFeel.LookAndFeel, "Advanced Document Search")

        End Sub

#End Region

#End Region

    End Class

End Namespace