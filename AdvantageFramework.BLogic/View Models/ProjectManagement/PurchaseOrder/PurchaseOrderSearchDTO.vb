Namespace ViewModels.ProjectManagement.PurchaseOrder

    Public Class PurchaseOrderSearchDTO
        Public Property PONumber As Integer
        Public Property DisplayPONumber As String
        Public Property CreateDate As Date?
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property IssuedByCode As String
        Public Property PODate As Date?
        Public Property DueDate As Date?
        Public Property Description As String
        Public Property Voided As Short?
        Public Property VoidDate As Date?
        Public Property Revision As Short?
        Public Property Approved As Short?
        Public Property Printed As Short?
        Public Property FirstName As String
        Public Property LastName As String
        Public Property MiddleInitial As String
        Public ReadOnly Property IssuedBy As String
            Get
                Return FirstName & " " & MiddleInitial & ". " & LastName
            End Get
        End Property

    End Class

End Namespace
