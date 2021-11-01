Namespace Reporting.Presentation.Classes
    Public Class MarketElem

        Public Property MarketCode As String
        Public Property IsCable As Boolean
        Public Property MarketDescription As String

        Public Sub New(ByVal MarketCode As String, ByVal IsCable As Boolean, ByVal MarketDescription As String)
            Me.MarketCode = MarketCode
            Me.IsCable = IsCable
            Me.MarketDescription = MarketDescription
        End Sub
    End Class
End Namespace

