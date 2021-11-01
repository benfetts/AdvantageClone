Namespace Reporting.Presentation.Classes
    Public Class VendorElem
        Public Property MarketCode As String
        Public Property MarketDescription As String
        Public Property VendorCode As String
        Public Property VendorName As String

        Public Property IsCable As Boolean

        Public Sub New(ByVal MarketCode As String, ByVal MarketDescription As String, ByVal VendorCode As String, ByVal VendorName As String, ByVal IsCable As Boolean)
            Me.MarketCode = MarketCode
            Me.MarketDescription = MarketDescription
            Me.VendorCode = VendorCode
            Me.VendorName = VendorName
            Me.IsCable = IsCable
        End Sub
    End Class
End Namespace

