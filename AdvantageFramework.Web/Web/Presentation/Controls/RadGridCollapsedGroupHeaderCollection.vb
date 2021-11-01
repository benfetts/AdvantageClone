Namespace Web.Presentation.Controls

    <Serializable()>
    Public Class RadGridCollapsedGroupHeaderCollection

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "
        Private _GroupName As String = Nothing
        Private _GroupCaptions As List(Of String) = Nothing
#End Region

#Region " Properties "
        Public Property GroupName() As String
            Get
                Return _GroupName
            End Get
            Set(value As String)
                _GroupName = value
            End Set
        End Property

        Public Property GroupCaptions() As List(Of String)
            Get
                Return _GroupCaptions
            End Get
            Set(value As List(Of String))
                _GroupCaptions = value
            End Set
        End Property
#End Region

#Region " Methods "
        Public Sub New()
            Me.GroupName = String.Empty
            Me.GroupCaptions = New List(Of String)()
        End Sub
#End Region

    End Class

End Namespace
