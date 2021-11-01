Namespace DTO.Desktop

    Public Class Document

        Public Property ID As Integer
        Public Property FileName As String
        Public Property FileSystemFileName As String
        Public Property MIMEType As String
        Public Property Description As String
        Public Property Keywords As String
        Public Property UploadedDate As Date
        Public Property UserCode As String
        Public Property FileSize As Integer
        Public Property IsPrivate As Boolean
        Public Property DocumentTypeID As Integer?
        Public Property ProofHQUrl As String
        Public Property ProofHQFileID As Integer?
        Public Property Thumbnail As Byte()
        Public Property CssClass As String
        Public Property FileTypeLabel As String
        Public Property FileType As String
        Public Property FileSizeDisplay As String
        Public Property AllowComments As Boolean
        Public ReadOnly Property LongDescription As String
            Get

                Try

                    Return String.Format("{0}, added by {1} @ {2}", Me.FileName, Me.UserCode, Me.UploadedDate)

                Catch ex As Exception
                    Return ""
                End Try

            End Get
        End Property

        Public Sub New()



        End Sub

        Public Shared Function FromEntity(ByVal DocumentEntity As AdvantageFramework.Database.Entities.Document) As AdvantageFramework.DTO.Desktop.Document

            'objects
            Dim Document As AdvantageFramework.DTO.Desktop.Document = Nothing

            Document = New AdvantageFramework.DTO.Desktop.Document

            With Document

                .ID = DocumentEntity.ID
                .FileName = DocumentEntity.FileName
                .FileSystemFileName = DocumentEntity.FileSystemFileName
                .MIMEType = DocumentEntity.MIMEType
                .Description = DocumentEntity.Description
                .Keywords = DocumentEntity.Keywords
                .UploadedDate = DocumentEntity.UploadedDate
                .UserCode = DocumentEntity.UserCode
                .FileSize = DocumentEntity.FileSize
                .IsPrivate = CBool(DocumentEntity.IsPrivate.GetValueOrDefault(0))
                .DocumentTypeID = DocumentEntity.DocumentTypeID
                .ProofHQUrl = DocumentEntity.ProofHQUrl
                .ProofHQFileID = DocumentEntity.ProofHQFileID
                .Thumbnail = DocumentEntity.Thumbnail

            End With

            Return Document

        End Function

    End Class

End Namespace