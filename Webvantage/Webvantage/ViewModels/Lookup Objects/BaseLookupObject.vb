Namespace ViewModels.LookupObjects

    Public MustInherit Class BaseLookupObject

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "


#End Region

#Region " Properties "

        Public Property ExtraData As Generic.Dictionary(Of String, Object)
        Public Overridable ReadOnly Property SearchText As String
            Get
                Return ""
            End Get
        End Property
        Public Overridable ReadOnly Property ObjectName As String
            Get
                ObjectName = Me.GetType.Name
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.ExtraData = New Generic.Dictionary(Of String, Object)

        End Sub

#End Region

    End Class

End Namespace
