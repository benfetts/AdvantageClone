Namespace Security.Classes

    <Serializable()>
    Public Class StopUpdate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SQL
            Message
            ReleaseVersion
        End Enum

#End Region

#Region " Variables "

        Private _SQL As String = Nothing
        Private _Message As String = Nothing
        Private _ReleaseVersion As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SQL() As String
            Get
                SQL = _SQL
            End Get
            Set(ByVal value As String)
                _SQL = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Message() As String
            Get
                Message = _Message
            End Get
            Set(ByVal value As String)
                _Message = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReleaseVersion() As String
            Get
                ReleaseVersion = _ReleaseVersion
            End Get
            Set(ByVal value As String)
                _ReleaseVersion = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

