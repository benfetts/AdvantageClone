Namespace DTO.Employee

    Public Class ExpenseReportDetail

        Public Property ID() As Integer
        Public Property InvoiceNumber() As Integer
        Public Property LineNumber() As Integer
        Public Property ItemDate() As Nullable(Of Date)
        Public Property Description() As String
        Public Property CreditCardFlag() As Nullable(Of Boolean)
        Public Property ClientCode() As String
        Public Property DivisionCode() As String
        Public Property ProductCode() As String
        Public Property JobNumber() As Nullable(Of Integer)
        Public Property JobDescription() As String
        Public Property JobComponentNumber() As Nullable(Of Short)
        Public Property JobComponentDescription As String
        Public Property JobComponent As String
        Public Property FunctionCode() As String
        Public Property Quantity() As Nullable(Of Integer)
        Public Property Rate() As Nullable(Of Decimal)
        Public Property CreditCardAmount() As Nullable(Of Decimal)
        Public Property Amount() As Nullable(Of Decimal)
        Public Property APComment() As String
        Public Property CreatedBy() As String
        Public Property ModifiedBy() As String
        Public Property ModifiedDate() As Nullable(Of Date)
        Public Property PaymentType() As Nullable(Of Short)
        Public Property IsImported() As Boolean
        Public Property NonBillable() As Boolean

        Public Sub New()

        End Sub

        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.ExpenseReportDetail

            'objects
            Dim ExpenseReportDetailEntity As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing

            If DbContext IsNot Nothing Then

                ExpenseReportDetailEntity = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByID(DbContext, Me.ID)
            End If

            If ExpenseReportDetailEntity Is Nothing Then

                ExpenseReportDetailEntity = New AdvantageFramework.Database.Entities.ExpenseReportDetail

            End If

            With ExpenseReportDetailEntity
                .Amount = Me.Amount
                .APComment = Me.APComment
                .ClientCode = Me.ClientCode
                .CreatedBy = Me.CreatedBy
                .CreditCardAmount = Me.CreditCardAmount
                .CreditCardFlag = Me.CreditCardFlag
                .DivisionCode = Me.DivisionCode
                .Description = Me.Description
                .FunctionCode = Me.FunctionCode
                .ID = Me.ID
                .InvoiceNumber = Me.InvoiceNumber
                .IsImported = Me.IsImported
                .ItemDate = Me.ItemDate
                .JobComponentNumber = Me.JobComponentNumber
                .JobNumber = Me.JobNumber
                .LineNumber = Me.LineNumber
                .ModifiedBy = Me.ModifiedBy
                .ModifiedDate = Me.ModifiedDate
                .PaymentType = Me.PaymentType
                .ProductCode = Me.ProductCode
                .Quantity = Me.Quantity
                .Rate = Me.Rate

            End With


            Return ExpenseReportDetailEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.ExpenseReportDetail, DBContext As AdvantageFramework.Database.DbContext) As ExpenseReportDetail

            'objects
            Dim ExpenseReportDetail As AdvantageFramework.DTO.Employee.ExpenseReportDetail = Nothing
            Dim JobDescription As String = String.Empty
            Dim JobComponentDescription As String = String.Empty
            Dim JobComponent As String = String.Empty

            'Get the job description
            If Entity.JobNumber.HasValue Then

                If Entity.JobNumber > 0 Then
                    JobDescription = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DBContext, Entity.JobNumber).Description
                End If

            Else
                JobDescription = ""

            End If

            'Get the job componet description
            If Entity.JobNumber.HasValue And Entity.JobComponentNumber.HasValue Then

                If Entity.JobNumber > 0 And Entity.JobComponentNumber > 0 Then
                    JobComponentDescription = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DBContext, Entity.JobNumber, Entity.JobComponentNumber).Description
                    JobComponent = Entity.JobNumber.ToString & "|" & Entity.JobComponentNumber.ToString & " - " & JobComponentDescription
                End If

            Else
                JobComponentDescription = ""

            End If

            ExpenseReportDetail = New AdvantageFramework.DTO.Employee.ExpenseReportDetail

            With ExpenseReportDetail

                .Amount = Entity.Amount
                .APComment = Entity.APComment
                .ClientCode = Entity.ClientCode
                .CreatedBy = Entity.CreatedBy
                .CreditCardAmount = Entity.CreditCardAmount
                .CreditCardFlag = Entity.CreditCardFlag
                .DivisionCode = Entity.DivisionCode
                .Description = Entity.Description
                .FunctionCode = Entity.FunctionCode
                .ID = Entity.ID
                .InvoiceNumber = Entity.InvoiceNumber
                .IsImported = Entity.IsImported
                .ItemDate = Entity.ItemDate
                .JobComponentNumber = Entity.JobComponentNumber
                .JobComponentDescription = JobComponentDescription
                .JobComponent = JobComponent
                .JobNumber = Entity.JobNumber
                .JobDescription = JobDescription
                .LineNumber = Entity.LineNumber
                .ModifiedBy = Entity.ModifiedBy
                .ModifiedDate = Entity.ModifiedDate
                .PaymentType = Entity.PaymentType
                .ProductCode = Entity.ProductCode
                .Quantity = Entity.Quantity
                .Rate = Entity.Rate

            End With

            Return ExpenseReportDetail

        End Function



    End Class

End Namespace


