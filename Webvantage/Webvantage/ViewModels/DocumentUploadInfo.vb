Namespace ViewModels
    Public Class DocumentUploadInfo

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property AuthorName As String = String.Empty
        Public Property DatabaseInsertSuccessful As Boolean = False
        Public Property Description As String = String.Empty
        Public Property DocumentId As Integer = -1
        Public Property DocumentLinkSuccessful As Boolean = False
        Public Property DocumentTypeId As Integer = 2
        Public Property ForeignKey As String = String.Empty
        Public Property FileBytes As Byte()
        Public Property FileName As String = String.Empty
        Public Property FilePrefix As String = String.Empty
        Public Property FileSize As Integer = 0
        Public Property FileSystemCreateSuccessful As Boolean = False
        Public Property FinalLevelDescription As String = String.Empty
        Public Property FinalLevelID As String = String.Empty
        Public Property ImpersonateUser As Boolean = False
        Public Property ImpersonatingUserDomain As String = String.Empty
        Public Property ImpersonatingUserName As String = String.Empty
        Public Property ImpersonatingUserPassword As String = String.Empty
        Public Property Keywords As String = String.Empty
        Public Property LastUploadException As System.Exception = Nothing
        Public Property Level As String = String.Empty
        Public Property MimeType As String = String.Empty
        Public Property Path As String = String.Empty
        Public Property PrivateFlag As Integer = 0
        Public Property RepositoryFilename As String = String.Empty
        Public Property UserCode As String = String.Empty
#End Region

#Region " Methods "

#End Region

    End Class

End Namespace
