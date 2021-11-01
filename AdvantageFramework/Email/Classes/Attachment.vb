Namespace Email.Classes

    <Serializable()>
    Public Class Attachment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AttachmentName
            File
            FileBytes
        End Enum

#End Region

#Region " Variables "

        Private _AttachmentName As String = ""
        Private _File As String = ""
        Private _FileBytes() As Byte = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AttachmentName() As String
            Get
                AttachmentName = _AttachmentName
            End Get
            Set(ByVal value As String)
                _AttachmentName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property File() As String
            Get
                File = _File
            End Get
            Set(ByVal value As String)
                _File = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FileBytes() As Byte()
            Get
                FileBytes = _FileBytes
            End Get
            Set(ByVal value As Byte())
                _FileBytes = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal File As String)

            _File = File

        End Sub
        Public Sub New(ByVal AttachmentName As String, ByVal File As String)

            _AttachmentName = AttachmentName
            _File = File

        End Sub
        Public Sub New(ByVal AttachmentName As String, ByVal FileBytes() As Byte)

            _AttachmentName = AttachmentName
            _FileBytes = FileBytes

        End Sub

#End Region

    End Class

End Namespace
