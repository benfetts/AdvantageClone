Namespace ViewModels.Employee
    Public Class ExpenseReportHeaderDTO
        Public Property InvoiceNumber As Integer?
        Public Property EmployeeCode As String
        Public Property VendorCode As String
        Public Property InvoiceDate As DateTime
        Public Property Description As String
        Public Property Details As String
        Public Property DateFrom As DateTime?
        Public Property DateTo As DateTime?
        Public Property InvoiceAmount As Decimal?
        Public Property ApprovedBy As String
        Public Property ApprovedDate As DateTime?
        Public Property Status As Integer?
        Public Property StatusCode As String
        Public Property ApproverNotes As String
        Public Property IsSubmitted As Short?
        Public Property IsApproved As Short?
        Public Property CreatedBy As String
        Public Property CreatedDate As DateTime?
        Public Property ModifiedBy As String
        Public Property ModifiedDate As DateTime?
        Public Property SubmittedTo As String
        Public Property BatchDate As DateTime?
        Public Property TotalNonBillable As Decimal?
        Public Property TotalBillable As Decimal?
        Public Property TotalAmount As Decimal?
        Public Property Paid As Integer?
        Public Property HasDocuments As Boolean?
        Public Property AttachmentCount As Integer?
    End Class
End Namespace
