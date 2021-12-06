Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class StandardInvoiceDetail

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
            FunctionType
            FunctionOrder
            OriginalFunctionCode
            FunctionCode
            FunctionDescription
            FunctionHeading
            FunctionHeadingOrder
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
            TotalAmount
            BillingJobComment
            BillingDetailComment
            CampaignID
            CampaignCode
            CampaignName
            Campaign
            CampaignComment
            DiscountAmount
            VATNumber
            EstimateHours
            TTDHoursBilled
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _InvoiceSequenceNumber As Nullable(Of Short) = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _InvoiceType As String = Nothing
        Private _FullInvoiceNumber As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Nullable(Of Short) = Nothing
        Private _ComponentDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _SCType As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionOrder As Nullable(Of Short) = Nothing
        Private _OriginalFunctionCode As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionHeading As String = Nothing
        Private _FunctionHeadingOrder As Nullable(Of Integer) = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _CommissionAmount As Nullable(Of Decimal) = Nothing
        Private _NonResaleTax As Nullable(Of Decimal) = Nothing
        Private _CityTax As Nullable(Of Decimal) = Nothing
        Private _CountyTax As Nullable(Of Decimal) = Nothing
        Private _StateTax As Nullable(Of Decimal) = Nothing
        Private _TotalTax As Nullable(Of Decimal) = Nothing
        Private _BillingComment As String = Nothing
        Private _JobComment As String = Nothing
        Private _BillingApprovalClientComment As String = Nothing
        Private _BillingApprovalFunctionComment As String = Nothing
        Private _JobComponentComment As String = Nothing
        Private _EstimateComment As String = Nothing
        Private _EstimateComponentComment As String = Nothing
        Private _EstimateQuoteComment As String = Nothing
        Private _EstimateRevisionComment As String = Nothing
        Private _EstimateFunctionComment As String = Nothing
        Private _InvoiceDueDate As Nullable(Of Date) = Nothing
        Private _ClientReference As String = Nothing
        Private _ClientPO As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _Address As String = Nothing
        Private _InvoiceCategory As String = Nothing
        Private _InvoiceFooterComment As String = Nothing
        Private _InvoiceFooterCommentFontSize As Integer = Nothing
        Private _InsideDescription As String = Nothing
        Private _OutsideDescription As String = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _BillingJobComment As String = Nothing
        Private _BillingDetailComment As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _Campaign As String = Nothing
        Private _CampaignComment As String = Nothing
        Private _DiscountAmount As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceSequenceNumber() As Nullable(Of Short)
            Get
                InvoiceSequenceNumber = _InvoiceSequenceNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InvoiceSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceType() As String
            Get
                InvoiceType = _InvoiceType
            End Get
            Set(ByVal value As String)
                _InvoiceType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FullInvoiceNumber() As String
            Get
                FullInvoiceNumber = _FullInvoiceNumber
            End Get
            Set(ByVal value As String)
                _FullInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComponentNumber() As Nullable(Of Short)
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SCType() As String
            Get
                SCType = _SCType
            End Get
            Set(ByVal value As String)
                _SCType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionOrder() As Nullable(Of Short)
            Get
                FunctionOrder = _FunctionOrder
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FunctionOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OriginalFunctionCode() As String
            Get
                OriginalFunctionCode = _OriginalFunctionCode
            End Get
            Set(ByVal value As String)
                _OriginalFunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(ByVal value As String)
                _FunctionHeading = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionHeadingOrder() As Nullable(Of Integer)
            Get
                FunctionHeadingOrder = _FunctionHeadingOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonResaleTax() As Nullable(Of Decimal)
            Get
                NonResaleTax = _NonResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTax() As Nullable(Of Decimal)
            Get
                CityTax = _CityTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTax() As Nullable(Of Decimal)
            Get
                CountyTax = _CountyTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTax() As Nullable(Of Decimal)
            Get
                StateTax = _StateTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalTax() As Nullable(Of Decimal)
            Get
                TotalTax = _TotalTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillingComment() As String
            Get
                BillingComment = _BillingComment
            End Get
            Set(ByVal value As String)
                _BillingComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComment() As String
            Get
                JobComment = _JobComment
            End Get
            Set(ByVal value As String)
                _JobComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillingApprovalClientComment() As String
            Get
                BillingApprovalClientComment = _BillingApprovalClientComment
            End Get
            Set(ByVal value As String)
                _BillingApprovalClientComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillingApprovalFunctionComment() As String
            Get
                BillingApprovalFunctionComment = _BillingApprovalFunctionComment
            End Get
            Set(ByVal value As String)
                _BillingApprovalFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentComment() As String
            Get
                JobComponentComment = _JobComponentComment
            End Get
            Set(ByVal value As String)
                _JobComponentComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComment() As String
            Get
                EstimateComment = _EstimateComment
            End Get
            Set(ByVal value As String)
                _EstimateComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentComment() As String
            Get
                EstimateComponentComment = _EstimateComponentComment
            End Get
            Set(ByVal value As String)
                _EstimateComponentComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateQuoteComment() As String
            Get
                EstimateQuoteComment = _EstimateQuoteComment
            End Get
            Set(ByVal value As String)
                _EstimateQuoteComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionComment() As String
            Get
                EstimateRevisionComment = _EstimateRevisionComment
            End Get
            Set(ByVal value As String)
                _EstimateRevisionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateFunctionComment() As String
            Get
                EstimateFunctionComment = _EstimateFunctionComment
            End Get
            Set(ByVal value As String)
                _EstimateFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDueDate() As Nullable(Of Date)
            Get
                InvoiceDueDate = _InvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Address() As String
            Get
                Address = _Address
            End Get
            Set(ByVal value As String)
                _Address = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceCategory() As String
            Get
                InvoiceCategory = _InvoiceCategory
            End Get
            Set(ByVal value As String)
                _InvoiceCategory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterComment() As String
            Get
                InvoiceFooterComment = _InvoiceFooterComment
            End Get
            Set(ByVal value As String)
                _InvoiceFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterCommentFontSize() As Integer
            Get
                InvoiceFooterCommentFontSize = _InvoiceFooterCommentFontSize
            End Get
            Set(ByVal value As Integer)
                _InvoiceFooterCommentFontSize = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InsideDescription() As String
            Get
                InsideDescription = _InsideDescription
            End Get
            Set(ByVal value As String)
                _InsideDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutsideDescription() As String
            Get
                OutsideDescription = _OutsideDescription
            End Get
            Set(ByVal value As String)
                _OutsideDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillingJobComment() As String
            Get
                BillingJobComment = _BillingJobComment
            End Get
            Set(ByVal value As String)
                _BillingJobComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillingDetailComment() As String
            Get
                BillingDetailComment = _BillingDetailComment
            End Get
            Set(ByVal value As String)
                _BillingDetailComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Campaign() As String
            Get
                Campaign = _Campaign
            End Get
            Set(ByVal value As String)
                _Campaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignComment() As String
            Get
                CampaignComment = _CampaignComment
            End Get
            Set(ByVal value As String)
                _CampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VATNumber() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateHours() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TTDHoursBilled() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

        End Function
        Public Function GetJobDescriptionOnly() As String

            Dim JobDescriptionOnly As String = String.Empty

            If String.IsNullOrWhiteSpace(Me.JobDescription) = False Then

                JobDescriptionOnly = Me.JobDescription.Substring(9)

            Else

                JobDescriptionOnly = String.Empty

            End If

            GetJobDescriptionOnly = JobDescriptionOnly

        End Function

#End Region

    End Class

End Namespace
