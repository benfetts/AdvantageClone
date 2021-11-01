Namespace DocumentManager.Classes

    <Serializable()>
    Public Class DocumentIcon

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Abbreviation As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property WebDivButtonCssClass As String = String.Empty
        Public Property WebLinkButtonCssClass As String = String.Empty
        Public Property AddCommentsButtonVisible As Boolean = False

        Private Property _MimeType As String = String.Empty
        Private Property _Filename As String = String.Empty

#End Region

#Region " Methods "

        Private Sub Load()

            Select Case _MimeType
                Case "application/msword",
                     "application/vnd.openxmlformats-officedocument.word",
                     "application/vnd.openxmlformats-officedocument.wordprocessingml.document"

                    WebDivButtonCssClass = "document-ms-word"
                    Abbreviation = "W"
                    WebLinkButtonCssClass = "icon-text"
                    Description = "Microsoft Word"

                    AddCommentsButtonVisible = True

                Case "application/mspowerpoint", "application/vnd.ms-powerpoint"

                    WebDivButtonCssClass = "document-ms-powerpoint"
                    Abbreviation = "PP"
                    WebLinkButtonCssClass = "icon-text-two"
                    Description = "Microsoft Powerpoint"

                Case "application/msproject", "application/vnd.ms-msproject"

                    WebDivButtonCssClass = "document-ms-project"
                    Abbreviation = "PR"
                    WebLinkButtonCssClass = "icon-text-two"
                    Description = "Microsoft Project"

                Case "application/pdf"

                    WebDivButtonCssClass = "document-adobe-pdf"
                    Abbreviation = "PDF"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Adobe PDF"

                    AddCommentsButtonVisible = True

                Case "application/msexcel", "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spre"

                    WebDivButtonCssClass = "document-ms-excel"
                    Abbreviation = "XL"
                    WebLinkButtonCssClass = "icon-text-two"
                    Description = "Microsoft Excel"

                    AddCommentsButtonVisible = True

                Case "image/bmp"

                    WebDivButtonCssClass = "document-image"
                    Abbreviation = "BMP"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Bitmap Image"

                    AddCommentsButtonVisible = True

                Case "image/gif"

                    WebDivButtonCssClass = "document-image"
                    Abbreviation = "GIF"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Gif Image"

                    AddCommentsButtonVisible = True

                Case "image/jpeg", "image/pjpeg"

                    WebDivButtonCssClass = "document-image"
                    Abbreviation = "JPG"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Jpeg Image"

                    AddCommentsButtonVisible = True

                Case "image/x-png", "image/png"

                    WebDivButtonCssClass = "document-image"
                    Abbreviation = "PNG"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Png Image"

                    AddCommentsButtonVisible = True

                Case "image/tiff"

                    WebDivButtonCssClass = "document-image"
                    Abbreviation = "TIF"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Tiff Image"

                    AddCommentsButtonVisible = True

                Case "text/plain"

                    WebDivButtonCssClass = "document-text"
                    Abbreviation = "TXT"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Text file"

                Case "image/x-photoshop"

                    WebDivButtonCssClass = "document-adobe-photoshop"
                    Abbreviation = "PSD"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Adobe Photoshop"

                Case "application/illustrator"

                    WebDivButtonCssClass = "document-adobe-illustrator"
                    Abbreviation = "AI"
                    WebLinkButtonCssClass = "icon-text-two"
                    Description = "Adobe Illustrator"

                Case "url"

                    WebDivButtonCssClass = "document-url"
                    Abbreviation = "URL"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "URL hyperlink"

                Case "application/x-zip-compressed", "application/zip"

                    WebDivButtonCssClass = "document-zip"
                    Abbreviation = "ZIP"
                    WebLinkButtonCssClass = "icon-text-three"
                    Description = "Zip file"

                Case "application/vnd.ms-outlook"

                    WebDivButtonCssClass = "document-ms-outlook"
                    Abbreviation = "O"
                    WebLinkButtonCssClass = "icon-text"
                    Description = "Microsoft Outlook"

                    AddCommentsButtonVisible = True

                Case Else

                    If String.IsNullOrWhiteSpace(Me._Filename) = False Then

                        If Me._Filename.ToLower.EndsWith("pdf") Then

                            WebDivButtonCssClass = "document-adobe-pdf"
                            Abbreviation = "PDF"
                            WebLinkButtonCssClass = "icon-text-three"
                            Description = "Adobe PDF"

                            AddCommentsButtonVisible = True

                        ElseIf Me._Filename.ToLower.EndsWith("docx") OrElse Me._Filename.ToLower.EndsWith("doc") Then

                            WebDivButtonCssClass = "document-ms-word"
                            Abbreviation = "W"
                            WebLinkButtonCssClass = "icon-text"
                            Description = "Microsoft Word"

                            AddCommentsButtonVisible = True

                        ElseIf Me._Filename.ToLower.EndsWith("sql") Then

                            Abbreviation = "SQL"
                            Description = "SQL Script"
                            WebLinkButtonCssClass = "icon-text-three"

                        ElseIf Me._Filename.ToLower.EndsWith("xlsx") OrElse Me._Filename.ToLower.EndsWith("xls") Then

                            WebDivButtonCssClass = "document-ms-excel"
                            Abbreviation = "XL"
                            WebLinkButtonCssClass = "icon-text-two"
                            Description = "Microsoft Excel"

                            AddCommentsButtonVisible = True

                        End If

                    Else

                        Abbreviation = "DOC"
                        Description = "Document"
                        WebLinkButtonCssClass = "icon-text-three"

                    End If

            End Select

        End Sub

#End Region

        Public Sub New(ByVal MimeType As String, ByVal Filename As String)

            Me._MimeType = MimeType.ToLower
            Me._Filename = Filename.ToLower
            Me.Load()

        End Sub

    End Class

End Namespace
