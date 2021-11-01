Namespace DTO.Desktop

    <Serializable()> Public Class AlertAttachment

#Region " Constants "



#End Region

#Region " Enum "
        'Public Enum Properties

        '    ID
        '    AlertID
        '    FileName
        '    Generated
        '    EmployeeFullName
        '    MIMEType
        '    RepositoryFileName
        '    DocumentID
        '    FileSize
        '    FileSizeKB
        '    UserCode
        '    PrivateFlag
        '    IsPrivate
        '    ProofHQUrl
        '    HistoryCount
        '    FileTypeLabel
        '    FileType
        '    AllowComments
        '    CssClass
        '    FileSizeDisplay
        '    JobNumber
        '    JobComponentNumber
        '    SequenceNumber
        '    IsTaskDocument
        '    ProofingURL
        '    ThumbnailSource
        '    Thumbnail
        '    VersionNumber
        '    SelectedCSS
        '    IsDefaultSelected

        'End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Public Property ID As Integer = 0
        Public Property DocumentID As Integer = 0
        Public Property AlertID As Integer = 0
        Public Property FileName As String = String.Empty
        Public Property Generated As Date? = Nothing
        Public Property EmployeeFullName As String = String.Empty
        Public Property MIMEType As String = String.Empty
        Public Property RepositoryFileName As String = String.Empty
        Public Property FileSize As Integer = 0
        Public Property FileSizeKB As Integer = 0
        Public Property Description As String = String.Empty
        Public Property UserCode As String = String.Empty
        Public Property PrivateFlag As Integer = 0
        Public Property IsPrivate As String = String.Empty
        Public Property ProofHQUrl As String = String.Empty
        Public Property HistoryCount As Nullable(Of Integer) = 0
        Public Property FileTypeLabel As String = String.Empty
        Public Property FileType As String = String.Empty
        Public Property AllowComments As Boolean = False
        Public Property CssClass As String = String.Empty
        Public Property FileSizeDisplay As String = String.Empty
        Public Property JobNumber As Nullable(Of Integer) = 0
        Public Property JobComponentNumber As Nullable(Of Short) = 0
        Public Property SequenceNumber As Nullable(Of Short) = 0
        Public Property IsTaskDocument As Boolean = False
        Public Property UploadedToDocumentManager As Boolean = False
        Public Property ProofingURL As String = String.Empty
        Public Property ThumbnailSource As Byte()
        Public Property Thumbnail As String = String.Empty
        Public Property VersionNumber As Short? = 0
        Public Property RawVersionNumber As Short? = 0
        Public Property IsDefaultSelected As Boolean? = False
        Public Property SelectedCSS As String = String.Empty
        Public Property TotalVersions As Integer? = 0
        Public Property TotalVersionsForAlertID As Integer? = 0
        Public Property TotalApproved As Integer? = 0
        Public Property TotalRejected As Integer? = 0
        Public Property TotalDeferred As Integer? = 0
        Public Property TotalMarkups As Integer? = 0
        Public Property IsLatest As Boolean? = False
        Public Property LastMarkupDate As DateTime? = Nothing
        Public Property LastMarkupFullName As String = String.Empty
        Public ReadOnly Property GeneratedString As String
            Get
                If Generated IsNot Nothing Then
                    Return CDate(Generated).ToShortDateString & " " & CDate(Generated).ToShortTimeString
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Public ReadOnly Property LastMarkupDateString As String
            Get
                If LastMarkupDate IsNot Nothing Then
                    Return CDate(LastMarkupDate).ToShortDateString & " " & CDate(LastMarkupDate).ToShortTimeString
                Else
                    Return String.Empty
                End If
            End Get
        End Property

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class

End Namespace
