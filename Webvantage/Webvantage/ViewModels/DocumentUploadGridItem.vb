Namespace ViewModels

    Public Class DocumentUploadGridItem

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

        Private _documentId As String
        Private _Level As String
        Private _fileName As String
        Private _description As String
        Private _documentTypeDesc As String
        Private _file_size As Integer
        Private _user_code As String
        Private _uploadedDate As DateTime
        Private _privateFlag As Boolean
        Private _proofHQURL As String
        Private _MIME_TYPE As String
        Private _REPOSITORY_FILENAME As String
        Private _THUMBNAIL As Byte()

#End Region

#Region " Properties "

        Public Property DOCUMENT_ID() As Integer
            Get
                Return _documentId
            End Get
            Set(ByVal value As Integer)
                _documentId = value
            End Set
        End Property


        Public Property LEVEL() As String
            Get
                Return _Level
            End Get
            Set(ByVal value As String)
                _Level = value
            End Set
        End Property


        Public Property FILENAME() As String
            Get
                Return _fileName
            End Get
            Set(ByVal value As String)
                _fileName = value
            End Set
        End Property

        Public Property DESCRIPTION() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                _description = value
            End Set
        End Property

        Public Property DOCUMENT_TYPE_DESC() As String
            Get
                Return _documentTypeDesc
            End Get
            Set(ByVal value As String)
                _documentTypeDesc = value
            End Set
        End Property

        Public Property FILE_SIZE() As Integer
            Get
                Return _file_size
            End Get
            Set(ByVal value As Integer)
                _file_size = value
            End Set
        End Property


        Public Property USER_CODE() As String
            Get
                Return _user_code
            End Get
            Set(ByVal value As String)
                _user_code = value
            End Set
        End Property


        Public Property UPLOADED_DATE() As DateTime
            Get
                Return _uploadedDate
            End Get
            Set(ByVal value As DateTime)
                _uploadedDate = value
            End Set
        End Property


        Public Property PRIVATE_FLAG() As Boolean
            Get
                Return _privateFlag
            End Get
            Set(ByVal value As Boolean)
                _privateFlag = value
            End Set
        End Property

        Public Property PROOFHQ_URL() As String
            Get
                Return _proofHQURL
            End Get
            Set(ByVal value As String)
                _proofHQURL = value
            End Set
        End Property

        Public Property MIME_TYPE() As String
            Get
                Return _MIME_TYPE
            End Get
            Set(ByVal value As String)
                _MIME_TYPE = value
            End Set
        End Property

        Public Property REPOSITORY_FILENAME() As String
            Get
                Return _REPOSITORY_FILENAME
            End Get
            Set(ByVal value As String)
                _REPOSITORY_FILENAME = value
            End Set
        End Property

        Public Property THUMBNAIL As Byte()
            Get
                Return _THUMBNAIL
            End Get
            Set(value As Byte())
                _THUMBNAIL = value
            End Set
        End Property
#End Region

#Region " Methods "

        Public Sub New()

        End Sub

        Public Sub New(model As AdvantageFramework.Database.Entities.Document, level As String)

            Me.DOCUMENT_ID = model.ID
            Me.LEVEL = level
            Me.FILENAME = model.FileName
            Me.FILE_SIZE = model.FileSize
            Me.DESCRIPTION = model.Description

            If (IsNothing(model.DocumentType) = False) Then

                Me.DOCUMENT_TYPE_DESC = model.DocumentType.Description

            End If

            Me.USER_CODE = model.UserCode
            Me.UPLOADED_DATE = model.UploadedDate
            Me.PRIVATE_FLAG = model.IsPrivate
            Me.PROOFHQ_URL = model.ProofHQUrl
            Me.MIME_TYPE = model.MIMEType

            If (Me.MIME_TYPE = "URL") Then

                Me.DESCRIPTION = FILENAME

            End If

            Me.REPOSITORY_FILENAME = model.FileSystemFileName
            Me.THUMBNAIL = model.Thumbnail

        End Sub
#End Region

    End Class

End Namespace


