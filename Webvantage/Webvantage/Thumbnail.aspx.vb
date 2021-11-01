Imports System.IO
Imports System.Drawing

Partial Public Class Thumbnail
    Inherits System.Web.UI.Page

    Private DocumentId As Integer = 0
    Private DocumentMimeType As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            DocumentId = CType(Request.QueryString("docid"), Integer)
        Catch ex As Exception
            DocumentId = 0
        End Try
        If DocumentId > 0 Then
            Me.GenerateThumbnail()
        End If
    End Sub

    Private Sub GenerateThumbnail()
        Dim objImage As System.Drawing.Image
        Dim strServerPath As String

        Try
            Dim objThumbnail As System.Drawing.Image
            Dim strFilename As String
            Dim shtWidth As Short
            Dim shtHeight As Short

            strServerPath = Server.MapPath("Images\")

            'Get the document:
            Dim Document As New Document(Session("ConnString"))
            Dim DocumentRepository As New DocumentRepository(Session("ConnString"))
            Document.LoadByPrimaryKey(DocumentId)
            Select Case Document.MIME_TYPE
                Case "image/bmp"
                    DocumentMimeType = Document.MIME_TYPE
                Case "image/gif"
                    DocumentMimeType = Document.MIME_TYPE
                Case "image/jpeg", "image/pjpeg"
                    DocumentMimeType = "image/jpeg"
                Case "image/x-png", "image/png"
                    DocumentMimeType = Document.MIME_TYPE
                Case Else
                    'not an image
            End Select

            Dim FileBytes() As Byte = DocumentRepository.GetDocument(DocumentId)

            Dim StreamImage As New MemoryStream(FileBytes)


            '''' Retrieve file, or error.gif if not available
            '''Try
            '''    '''objImage = objImage.FromFile(strFilename)

            objImage = objImage.FromStream(StreamImage)
            '''Catch
            '''    objImage = objImage.FromFile(strServerPath & "error.gif")
            '''End Try

            ' Retrieve width from query string
            If Request.QueryString("w") = Nothing Then
                'shtWidth = objImage.Width
                shtWidth = 70
            ElseIf Request.QueryString("w") < 70 Then
                shtWidth = 70
            Else
                shtWidth = Request.QueryString("w")
            End If

            ' Work out a proportionate height from width
            shtHeight = objImage.Height / (objImage.Width / shtWidth)

            ' Create thumbnail
            objThumbnail = objImage.GetThumbnailImage(shtWidth, shtHeight, Nothing, System.IntPtr.Zero)
            'objThumbna

            ' Send down to client
            Response.ContentType = Me.DocumentMimeType
            Dim ThisFormat As Imaging.ImageFormat
            Select Case Me.DocumentMimeType
                Case "image/bmp"
                    ThisFormat = Imaging.ImageFormat.Bmp
                Case "image/gif"
                    ThisFormat = Imaging.ImageFormat.Gif
                Case "image/jpeg", "image/pjpeg"
                    ThisFormat = Imaging.ImageFormat.Jpeg
                Case "image/x-png", "image/png"
                    ThisFormat = Imaging.ImageFormat.Png
                Case Else
                    'not an image
            End Select

            Select Case Me.DocumentMimeType
                Case "image/x-png", "image/png", "image/bmp"
                    Dim mem As New MemoryStream()
                    objThumbnail.Save(mem, Imaging.ImageFormat.Png)
                    mem.WriteTo(Response.OutputStream)
                    mem.Dispose()
                Case Else
                    objThumbnail.Save(Response.OutputStream, ThisFormat)
            End Select

            ' Tidy up
            objImage.Dispose()
            objThumbnail.Dispose()

        Catch ex As Exception
            objImage = objImage.FromFile(strServerPath & "error.gif")
        End Try
    End Sub

End Class