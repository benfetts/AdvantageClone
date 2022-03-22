Namespace Quickbooks.Classes

    Public Class APDetail

        Public Property OrderNumber As Nullable(Of Integer)
        Public Property OrderLineNumber As Nullable(Of Short)
        Public Property Description As String
        Public Property Amount As Decimal
        Public Property IsOrder As Boolean
        Public Property IsProduction As Boolean
        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobComponentNumber As Nullable(Of Short)
        Public Property QuickBooksClientID As String

    End Class

End Namespace
