Namespace DTO.Employee

    Public Class ExpenseReport

        Public Property ApprovedBy As String
        Public Property ApprovedDate As Date?
        Public Property ApproverNotes As String
        Public Property BatchDate As Date?
        Public Property CreatedBy As String
        Public Property CreatedDate As Date?
        Public Property DateFrom As Date?
        Public Property DateTo As Date?
        Public Property Description As String
        Public Property Details As String
        Public Property EmployeeCode As String
        Public Property EmployeeName As String
        Public Property InvoiceAmount As Decimal?
        Public Property InvoiceDate As Date?
        Public Property InvoiceNumber As Integer
        Public Property IsApproved As Short?
        Public Property IsSubmitted As Short?
        Public Property ModifiedBy As String
        Public Property ModifiedDate As Date?
        Public Property Status As Integer?
        Public ReadOnly Property StatusCode As String

            Get
                If Not Status.HasValue Then
                    Return ""
                Else
                    Return [Enum].GetName(GetType(AdvantageFramework.ExpenseReports.ExpenseReportStatus), AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(Status, IsSubmitted, IsApproved)) '[Enum].GetName(GetType(AdvantageFramework.ExpenseReports.ExpenseReportStatus), CType(Status, Int32))
                End If

            End Get

        End Property
        Public Property SubmittedTo As String
        Public Property VendorCode As String
        Public Property TotalNonBillable As Decimal?
        Public Property TotalBillable As Decimal?
        Public Property TotalAmount As Decimal?
        Public Property Paid As Boolean
        Public Property ExpenseReportDetails As Generic.List(Of ExpenseReportDetail)

        Public Sub New()

        End Sub

        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.ExpenseReport

            'objects
            Dim ExpenseReportEntity As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            If DbContext IsNot Nothing Then

                ExpenseReportEntity = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, Me.InvoiceNumber)
            End If

            If ExpenseReportEntity Is Nothing Then

                ExpenseReportEntity = New Database.Entities.ExpenseReport

            End If

            With ExpenseReportEntity
                .ApprovedBy = Me.ApprovedBy
                .ApprovedDate = Me.ApprovedDate
                .ApproverNotes = Me.ApproverNotes
                .BatchDate = Me.BatchDate
                .CreatedBy = Me.CreatedBy
                .CreatedDate = Me.CreatedDate
                .DateFrom = Me.DateFrom
                .DateTo = Me.DateTo
                .Description = Me.Description
                .Details = Me.Details
                .EmployeeCode = Me.EmployeeCode
                .InvoiceAmount = Me.InvoiceAmount
                .InvoiceDate = Me.InvoiceDate
                .InvoiceNumber = Me.InvoiceNumber
                .IsApproved = Me.IsApproved
                .IsSubmitted = Me.IsSubmitted
                .ModifiedBy = Me.ModifiedBy
                .ModifiedDate = Me.ModifiedDate
                .Status = Me.Status
                .ApproverNotes = Me.ApproverNotes
                .IsSubmitted = Me.IsSubmitted
                .SubmittedTo = Me.SubmittedTo
                .IsApproved = Me.IsApproved
                .VendorCode = Me.VendorCode

                '.TotalNonBillable = Me.TotalNonBillable
                '.TotalBillable = Me.TotalBillable
                '.TotalAmount = Me.TotalAmount
                '.Paid = Me.Paid

            End With


            Return ExpenseReportEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.ExpenseReport) As ExpenseReport

            'objects
            Dim ExpenseReport As AdvantageFramework.DTO.Employee.ExpenseReport = Nothing

            ExpenseReport = New AdvantageFramework.DTO.Employee.ExpenseReport

            With ExpenseReport

                .ApprovedBy = Entity.ApprovedBy
                .ApprovedDate = Entity.ApprovedDate
                .ApproverNotes = Entity.ApproverNotes
                .BatchDate = Entity.BatchDate
                .CreatedBy = Entity.CreatedBy
                .CreatedDate = Entity.CreatedDate
                .DateFrom = Entity.DateFrom
                .DateTo = Entity.DateTo
                .Description = Entity.Description
                .Details = Entity.Details
                .EmployeeCode = Entity.EmployeeCode
                .InvoiceAmount = Entity.InvoiceAmount
                .InvoiceDate = Entity.InvoiceDate
                .InvoiceNumber = Entity.InvoiceNumber
                .IsApproved = Entity.IsApproved
                .IsSubmitted = Entity.IsSubmitted
                .ModifiedBy = Entity.ModifiedBy
                .ModifiedDate = Entity.ModifiedDate
                .Status = Entity.Status
                .SubmittedTo = Entity.SubmittedTo
                .VendorCode = Entity.VendorCode
                '.TotalNonBillable = Entity.TotalNonBillable
                '.TotalBillable = Entity.TotalBillable
                '.TotalAmount = Entity.TotalAmount
                '.Paid = Entity.Paid
            End With

            Return ExpenseReport

        End Function

        Public Shared Function FromClass(ByVal Entity As AdvantageFramework.Database.Classes.ExpenseReport) As ExpenseReport

            'objects
            Dim ExpenseReport As AdvantageFramework.DTO.Employee.ExpenseReport = Nothing

            ExpenseReport = New AdvantageFramework.DTO.Employee.ExpenseReport

            With ExpenseReport

                .ApprovedBy = Entity.ApprovedBy
                .ApprovedDate = Entity.ApprovedDate
                .ApproverNotes = Entity.ApproverNotes
                '.BatchDate = Entity.BatchDate
                '.CreatedBy = Entity.CreatedBy
                .CreatedDate = Entity.CreatedDate
                .DateFrom = Entity.DateFrom
                .DateTo = Entity.DateTo
                .Description = Entity.Description
                .Details = Entity.Details
                .EmployeeCode = Entity.EmployeeCode
                .InvoiceAmount = Entity.InvoiceAmount
                .InvoiceDate = Entity.InvoiceDate
                .InvoiceNumber = Entity.InvoiceNumber
                .IsApproved = Entity.IsApproved
                .IsSubmitted = Entity.IsSubmitted
                '.ModifiedBy = Entity.ModifiedBy
                '.ModifiedDate = Entity.ModifiedDate
                .Status = Entity.Status
                .SubmittedTo = Entity.SubmittedTo
                .VendorCode = Entity.VendorCode
                .TotalNonBillable = Entity.TotalNonBillable
                .TotalBillable = Entity.TotalBillable
                .TotalAmount = Entity.TotalAmount
                .Paid = Entity.Paid
            End With

            Return ExpenseReport


        End Function

    End Class

End Namespace


