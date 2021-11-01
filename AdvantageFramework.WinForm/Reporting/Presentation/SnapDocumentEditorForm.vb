Namespace Reporting.Presentation

    Public Class SnapDocumentEditorForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _IsAgencyASP As Boolean = False
        Private _DataSource As Object = Nothing
        Private _DocumentLayout() As Byte = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property DocumentLayout As Byte()
            Get
                DocumentLayout = _DocumentLayout
            End Get
        End Property
        Private ReadOnly Property DocumentChanged As Boolean
            Get
                DocumentChanged = SnapControl.Modified
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal DataSource As Object, ByVal DocumentLayout() As Byte)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Session = Session
            _DataSource = DataSource
            _DocumentLayout = DocumentLayout

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, ByVal DataSource As Object, ByRef DocumentLayout() As Byte, ByRef DocumentChanged As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim SnapDocumentEditorForm As SnapDocumentEditorForm = Nothing

            SnapDocumentEditorForm = New SnapDocumentEditorForm(Session, DataSource, DocumentLayout)

            ShowFormDialog = SnapDocumentEditorForm.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                DocumentLayout = SnapDocumentEditorForm.DocumentLayout
                DocumentChanged = SnapDocumentEditorForm.DocumentChanged

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub SnapDocumentEditorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing


            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            MemoryStream = New System.IO.MemoryStream

            MemoryStream.Write(_DocumentLayout, 0, _DocumentLayout.Length)
            MemoryStream.Seek(0, IO.SeekOrigin.Begin)

            Try

                SnapControl.LoadDocument(MemoryStream, DevExpress.XtraRichEdit.DocumentFormat.Rtf)

            Catch ex As Exception

            End Try

            MemoryStream.Flush()
            MemoryStream.Close()

            If SnapControl.Document IsNot Nothing Then

                If SnapControl.Document.DataSources.Count = 0 Then

                    SnapControl.Document.DataSources.Add("DataSource", _DataSource)

                Else

                    SnapControl.Document.DataSources(0).DataSource = _DataSource

                End If

                SnapControl.Refresh()

            End If

        End Sub
        Private Sub SnapDocumentEditorForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream

            SnapControl.ExportDocument(MemoryStream, DevExpress.XtraRichEdit.DocumentFormat.Rtf)

            _DocumentLayout = MemoryStream.ToArray

            Try

                MemoryStream.Flush()
                MemoryStream.Close()

            Catch ex As Exception

            End Try

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace