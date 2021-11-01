Namespace DTO

    <Serializable()>
    Public Class Application

        Public Property MainMenuItems As Generic.List(Of MenuItem)
        Public Property QuickAccessMenuItems As Generic.List(Of MenuItem)
        Public Property ProductivityMenuItems As Generic.List(Of MenuItem)
        Public Property SearchMenuItems As Generic.List(Of MenuItem)
        Public Property Employee As Object
        Public Property DeepLink As String = String.Empty
        Public Property IsClientPortal As Boolean = False
        Public Property IsProofingActive As Boolean = False
        Public Property DatabaseName As String = String.Empty

        Public Sub New()

            Me.MainMenuItems = New Generic.List(Of MenuItem)
            Me.QuickAccessMenuItems = New Generic.List(Of MenuItem)
            Me.ProductivityMenuItems = New Generic.List(Of MenuItem)
            Me.SearchMenuItems = New Generic.List(Of MenuItem)

        End Sub

        <Serializable()>
        Public Class MenuItem

            Public Property Text As String
            Public Property Value As String

        End Class

        <Serializable()>
        Public Class ApplicationMenuItem
            Inherits MenuItem

            Public Property Url As String
            Public Property IsReport As Boolean
            Public Property UseIframe As Boolean

        End Class

        <Serializable()>
        Public Class CategoryMenuItem
            Inherits MenuItem

            Public Property MenuItems As Generic.List(Of MenuItem)

            Public Sub New()

                Me.MenuItems = New List(Of MenuItem)

            End Sub

        End Class

    End Class

End Namespace


