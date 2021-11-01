Namespace InvoicePrinting.Classes

    <Serializable>
    Public Class JobFunctionInvoiceDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceSequenceNumber
            InvoiceDate
            InvoiceType
            FullInvoiceNumber
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            SCType
            OriginalFunctionCode
            FunctionHeading
            FunctionHeadingOrder
            BillingComment
            JobComment
            BillingApprovalClientComment
            BillingApprovalFunctionComment
            JobComponentComment
            EstimateComment
            EstimateComponentComment
            EstimateQuoteComment
            EstimateRevisionComment
            EstimateFunctionComment
            InvoiceDueDate
            ClientReference
            ClientPO
            AccountExecutive
            SalesClassCode
            SalesClassDescription
            Address
            InvoiceCategory
            InvoiceFooterComment
            InvoiceFooterCommentFontSize
            InsideDescription
            OutsideDescription
            BillingJobComment
            BillingDetailComment
            CampaignID
            CampaignCode
            CampaignName
            Campaign
            CampaignComment
            DiscountAmount
            FunctionTotalQuantity
            FunctionTotalHours
            FunctionTotalRate
            FunctionTotalNetAmount
            FunctionTotalCommissionAmount
            FunctionTotalNonResaleTax
            FunctionTotalCityTax
            FunctionTotalCountyTax
            FunctionTotalStateTax
            FunctionTotalTotalTax
            FunctionTotalAmount
            FunctionOrder
            FunctionCode
            FunctionDescription
            FunctionType
            Type
            Item
            ItemDate
            Quantity
            Hours
            Rate
            NetAmount
            CommissionAmount
            NonResaleTax
            CityTax
            CountyTax
            StateTax
            TotalTax
            TotalAmount
            Comment
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property InvoiceNumber As Nullable(Of Integer)
        Public Property InvoiceSequenceNumber As Nullable(Of Short)
        Public Property InvoiceDate As Nullable(Of Date)
        Public Property InvoiceType As String
        Public Property FullInvoiceNumber As String
        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobDescription As String
        Public Property ComponentNumber As Nullable(Of Short)
        Public Property ComponentDescription As String
        Public Property ClientCode As String
        Public Property ClientName As String
        Public Property DivisionCode As String
        Public Property DivisionName As String
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property SCType As String
        Public Property OriginalFunctionCode As String
        Public Property FunctionHeading As String
        Public Property FunctionHeadingOrder As Nullable(Of Integer)
        Public Property BillingComment As String
        Public Property JobComment As String
        Public Property BillingApprovalClientComment As String
        Public Property BillingApprovalFunctionComment As String
        Public Property JobComponentComment As String
        Public Property EstimateComment As String
        Public Property EstimateComponentComment As String
        Public Property EstimateQuoteComment As String
        Public Property EstimateRevisionComment As String
        Public Property EstimateFunctionComment As String
        Public Property InvoiceDueDate As Nullable(Of Date)
        Public Property ClientReference As String
        Public Property ClientPO As String
        Public Property AccountExecutive As String
        Public Property SalesClassCode As String
        Public Property SalesClassDescription As String
        Public Property Address As String
        Public Property InvoiceCategory As String
        Public Property InvoiceFooterComment As String
        Public Property InvoiceFooterCommentFontSize As Integer
        Public Property InsideDescription As String
        Public Property OutsideDescription As String
        Public Property BillingJobComment As String
        Public Property BillingDetailComment As String
        Public Property CampaignID As Nullable(Of Integer)
        Public Property CampaignCode As String
        Public Property CampaignName As String
        Public Property Campaign As String
        Public Property CampaignComment As String
        Public Property DiscountAmount As Nullable(Of Decimal)
        Public Property FunctionTotalQuantity As Nullable(Of Decimal)
        Public Property FunctionTotalHours As Nullable(Of Decimal)
        Public Property FunctionTotalRate As Nullable(Of Decimal)
        Public Property FunctionTotalNetAmount As Nullable(Of Decimal)
        Public Property FunctionTotalCommissionAmount As Nullable(Of Decimal)
        Public Property FunctionTotalNonResaleTax As Nullable(Of Decimal)
        Public Property FunctionTotalCityTax As Nullable(Of Decimal)
        Public Property FunctionTotalCountyTax As Nullable(Of Decimal)
        Public Property FunctionTotalStateTax As Nullable(Of Decimal)
        Public Property FunctionTotalTotalTax As Nullable(Of Decimal)
        Public Property FunctionTotalAmount As Nullable(Of Decimal)
        Public ReadOnly Property JobDescriptionOnly As String
            Get

                If String.IsNullOrWhiteSpace(Me.JobDescription) = False Then

                    JobDescriptionOnly = Me.JobDescription.Substring(9)

                Else

                    JobDescriptionOnly = String.Empty

                End If
            End Get
        End Property
        Public Property FunctionOrder As Nullable(Of Short)
        Public Property FunctionCode As String
        Public Property FunctionDescription As String
        Public Property FunctionType As String
        Public Property Type As String
        Public Property Item As String
        Public Property ItemDate As Nullable(Of Date)
        Public Property Quantity As Nullable(Of Decimal)
        Public Property Hours As Nullable(Of Decimal)
        Public Property Rate As Nullable(Of Decimal)
        Public Property NetAmount As Nullable(Of Decimal)
        Public Property CommissionAmount As Nullable(Of Decimal)
        Public Property NonResaleTax As Nullable(Of Decimal)
        Public Property CityTax As Nullable(Of Decimal)
        Public Property CountyTax As Nullable(Of Decimal)
        Public Property StateTax As Nullable(Of Decimal)
        Public Property TotalTax As Nullable(Of Decimal)
        Public Property TotalAmount As Nullable(Of Decimal)
        Public Property Comment As String

#End Region

#Region " Methods "

        Private Sub New()



        End Sub
        Public Sub New(StandardInvoiceDetail As StandardInvoiceDetail, InvoiceFunctionDetail As InvoiceFunctionDetail)

            Me.InvoiceNumber = StandardInvoiceDetail.InvoiceNumber
            Me.InvoiceSequenceNumber = StandardInvoiceDetail.InvoiceSequenceNumber
            Me.InvoiceDate = StandardInvoiceDetail.InvoiceDate
            Me.InvoiceType = StandardInvoiceDetail.InvoiceType
            Me.FullInvoiceNumber = StandardInvoiceDetail.FullInvoiceNumber
            Me.JobNumber = StandardInvoiceDetail.JobNumber
            Me.JobDescription = StandardInvoiceDetail.JobDescription
            Me.ComponentNumber = StandardInvoiceDetail.ComponentNumber
            Me.ComponentDescription = StandardInvoiceDetail.ComponentDescription
            Me.ClientCode = StandardInvoiceDetail.ClientCode
            Me.ClientName = StandardInvoiceDetail.ClientName
            Me.DivisionCode = StandardInvoiceDetail.DivisionCode
            Me.DivisionName = StandardInvoiceDetail.DivisionName
            Me.ProductCode = StandardInvoiceDetail.ProductCode
            Me.ProductName = StandardInvoiceDetail.ProductName
            Me.SCType = StandardInvoiceDetail.SCType
            Me.OriginalFunctionCode = StandardInvoiceDetail.OriginalFunctionCode
            Me.FunctionHeading = StandardInvoiceDetail.FunctionHeading
            Me.FunctionHeadingOrder = StandardInvoiceDetail.FunctionHeadingOrder
            Me.BillingComment = StandardInvoiceDetail.BillingComment
            Me.JobComment = StandardInvoiceDetail.JobComment
            Me.BillingApprovalClientComment = StandardInvoiceDetail.BillingApprovalClientComment
            Me.BillingApprovalFunctionComment = StandardInvoiceDetail.BillingApprovalFunctionComment
            Me.JobComponentComment = StandardInvoiceDetail.JobComponentComment
            Me.EstimateComment = StandardInvoiceDetail.EstimateComment
            Me.EstimateComponentComment = StandardInvoiceDetail.EstimateComponentComment
            Me.EstimateQuoteComment = StandardInvoiceDetail.EstimateQuoteComment
            Me.EstimateRevisionComment = StandardInvoiceDetail.EstimateRevisionComment
            Me.EstimateFunctionComment = StandardInvoiceDetail.EstimateFunctionComment
            Me.InvoiceDueDate = StandardInvoiceDetail.InvoiceDueDate
            Me.ClientReference = StandardInvoiceDetail.ClientReference
            Me.ClientPO = StandardInvoiceDetail.ClientPO
            Me.AccountExecutive = StandardInvoiceDetail.AccountExecutive
            Me.SalesClassCode = StandardInvoiceDetail.SalesClassCode
            Me.SalesClassDescription = StandardInvoiceDetail.SalesClassDescription
            Me.Address = StandardInvoiceDetail.Address
            Me.InvoiceCategory = StandardInvoiceDetail.InvoiceCategory
            Me.InvoiceFooterComment = StandardInvoiceDetail.InvoiceFooterComment
            Me.InvoiceFooterCommentFontSize = StandardInvoiceDetail.InvoiceFooterCommentFontSize
            Me.InsideDescription = StandardInvoiceDetail.InsideDescription
            Me.OutsideDescription = StandardInvoiceDetail.OutsideDescription
            Me.BillingJobComment = StandardInvoiceDetail.BillingJobComment
            Me.BillingDetailComment = StandardInvoiceDetail.BillingDetailComment
            Me.CampaignID = StandardInvoiceDetail.CampaignID
            Me.CampaignCode = StandardInvoiceDetail.CampaignCode
            Me.CampaignName = StandardInvoiceDetail.CampaignName
            Me.Campaign = StandardInvoiceDetail.Campaign
            Me.CampaignComment = StandardInvoiceDetail.CampaignComment
            Me.DiscountAmount = StandardInvoiceDetail.DiscountAmount
            Me.FunctionTotalQuantity = StandardInvoiceDetail.Quantity
            Me.FunctionTotalHours = StandardInvoiceDetail.Hours
            Me.FunctionTotalRate = StandardInvoiceDetail.Rate
            Me.FunctionTotalNetAmount = StandardInvoiceDetail.NetAmount
            Me.FunctionTotalCommissionAmount = StandardInvoiceDetail.CommissionAmount
            Me.FunctionTotalNonResaleTax = StandardInvoiceDetail.NonResaleTax
            Me.FunctionTotalCityTax = StandardInvoiceDetail.CityTax
            Me.FunctionTotalCountyTax = StandardInvoiceDetail.CountyTax
            Me.FunctionTotalStateTax = StandardInvoiceDetail.StateTax
            Me.FunctionTotalTotalTax = StandardInvoiceDetail.TotalTax
            Me.FunctionTotalAmount = StandardInvoiceDetail.TotalAmount

            Me.FunctionOrder = StandardInvoiceDetail.FunctionOrder
            Me.FunctionCode = StandardInvoiceDetail.FunctionCode
            Me.FunctionDescription = StandardInvoiceDetail.FunctionDescription
            Me.FunctionType = InvoiceFunctionDetail.FunctionType
            Me.Type = InvoiceFunctionDetail.Type
            Me.Item = InvoiceFunctionDetail.Item
            Me.ItemDate = InvoiceFunctionDetail.ItemDate
            Me.Quantity = InvoiceFunctionDetail.Quantity
            Me.Hours = InvoiceFunctionDetail.Hours
            Me.Rate = InvoiceFunctionDetail.Rate
            Me.NetAmount = InvoiceFunctionDetail.NetAmount
            Me.CommissionAmount = InvoiceFunctionDetail.CommissionAmount
            Me.NonResaleTax = InvoiceFunctionDetail.NonResaleTax
            Me.CityTax = InvoiceFunctionDetail.CityTax
            Me.CountyTax = InvoiceFunctionDetail.CountyTax
            Me.StateTax = InvoiceFunctionDetail.StateTax
            Me.TotalTax = InvoiceFunctionDetail.TotalTax
            Me.TotalAmount = InvoiceFunctionDetail.TotalAmount
            Me.Comment = InvoiceFunctionDetail.Comment

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Item & Me.Item

        End Function

#End Region

    End Class

End Namespace
