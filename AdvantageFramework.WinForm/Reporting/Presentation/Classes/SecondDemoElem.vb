Namespace Reporting.Presentation.Classes
    Public Class SecondDemoElem
        Public Property MarketCode As String
        Public Property SecondaryMediaDemoID As Integer
        Public Property SecondaryMediaCode As String
        Public Property SecondaryMediaDescription As String

        Public Sub New(ByVal MarketCode As String, ByVal SecondaryMediaDemoID As Integer, ByVal SecondaryMediaCode As String, ByVal SecondaryMediaDescription As String)
            Me.MarketCode = MarketCode
            Me.SecondaryMediaDemoID = SecondaryMediaDemoID
            Me.SecondaryMediaCode = SecondaryMediaCode
            Me.SecondaryMediaDescription = SecondaryMediaDescription
        End Sub
    End Class
End Namespace

