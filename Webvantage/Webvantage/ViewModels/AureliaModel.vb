Namespace ViewModels

    Public Class AureliaModel

        Public Property App As String
        Public Property Parameters As Generic.Dictionary(Of String, Object)

        Public Sub New()

            Me.Parameters = New Generic.Dictionary(Of String, Object)

        End Sub

    End Class

End Namespace


