'' ''Public Class UIHelper

'' ''    Public Shared Function GetDocumentIconFromMimeType(ByVal mimeType As String, Optional ByRef AddCommentsButtonVisible As Boolean = False, Optional ByRef FileName As String = "") As String
'' ''        Dim iconPath As String

'' ''        Select Case mimeType
'' ''            Case "application/msword", _
'' ''                 "application/vnd.openxmlformats-officedocument.word", _
'' ''                 "application/vnd.openxmlformats-officedocument.wordprocessingml.document"

'' ''                iconPath = "document_word.png"
'' ''                AddCommentsButtonVisible = True

'' ''            Case "application/mspowerpoint", "application/vnd.ms-powerpoint"
'' ''                iconPath = "document_powerpoint.png"
'' ''            Case "application/msproject", "application/vnd.ms-msproject"
'' ''                iconPath = "document_project.png"
'' ''            Case "application/pdf"
'' ''                iconPath = "document_pdf.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case "application/msexcel", "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spre"
'' ''                iconPath = "document_excel.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case "image/bmp"
'' ''                iconPath = "document_image.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case "image/gif"
'' ''                iconPath = "document_image.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case "image/jpeg", "image/pjpeg"
'' ''                iconPath = "document_jpg.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case "image/x-png", "image/png"
'' ''                iconPath = "document_png.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case "image/tiff"
'' ''                iconPath = "document_tif.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case "text/plain"
'' ''                iconPath = "document_text.png"
'' ''            Case "image/x-photoshop"
'' ''                iconPath = "document_photoshop.png"
'' ''            Case "application/illustrator"
'' ''                iconPath = "document_illustrator.png"
'' ''            Case "URL"
'' ''                iconPath = "document_url.png"
'' ''            Case "application/x-zip-compressed", "application/zip"
'' ''                iconPath = "document_zip.png"
'' ''            Case "application/vnd.ms-outlook"
'' ''                iconPath = "MicrosoftOutlookImage.png"
'' ''                AddCommentsButtonVisible = True
'' ''            Case Else
'' ''                iconPath = "document_generic.png"
'' ''        End Select

'' ''        If iconPath = "document_generic.png" AndAlso FileName <> "" Then

'' ''            If FileName.ToUpper.EndsWith(".MSG") Then

'' ''                iconPath = "MicrosoftOutlookImage.png"
'' ''                AddCommentsButtonVisible = True

'' ''            End If

'' ''        End If

'' ''        Return iconPath

'' ''    End Function

'' ''End Class
