Namespace Reporting.Database.Classes

    <Serializable>
    Public Class IncomeOnlyReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            CampaignID
            CampaignCode
            CampaignName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            SalesClassCode
            SalesClassDescription
            ReferenceNumber
            InvoiceDate
            Description
            FunctionCode
            FunctionDescription
            Quantity
            Rate
            Amount
            MarkupAmount
            Total
            ResaleTaxAmount
            TotalWithResaleTax
            Comments
            ARInvoiceNumber
            ARInvoiceType
            ARInvoiceDate
            BillingUserCode
            GLTransactionBill
            GLAccountSales
            GLAccountSalesDescription
            NonBillFlag
            BillHoldFlag
            ModifiedByUserCode
            ModifiedDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _ReferenceNumber As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _Description As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _Total As Decimal = Nothing
        Private _ResaleTaxAmount As Decimal = Nothing
        Private _TotalWithResaleTax As Nullable(Of Decimal) = Nothing
        Private _Comments As String = Nothing
        Private _ARInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _ARInvoiceType As String = Nothing
        Private _ARInvoiceDate As Nullable(Of Date) = Nothing
        Private _BillingUserCode As String = Nothing
        Private _GLTransactionBill As Nullable(Of Integer) = Nothing
        Private _GLAccountSales As String = Nothing
        Private _GLAccountSalesDescription As String = Nothing
        Private _NonBillFlag As String = Nothing
        Private _BillHoldFlag As String = Nothing
        Private _ModifiedByUserCode As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of System.Guid))
                _ID = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
		Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
		Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
		Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        Public Property ReferenceNumber() As String
            Get
                ReferenceNumber = _ReferenceNumber
            End Get
            Set(value As String)
                _ReferenceNumber = value
            End Set
        End Property
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property Total() As Decimal
            Get
                Total = _Total
            End Get
            Set(value As Decimal)
                _Total = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property ResaleTaxAmount() As Decimal
            Get
                ResaleTaxAmount = _ResaleTaxAmount
            End Get
            Set(value As Decimal)
                _ResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property TotalWithResaleTax() As Nullable(Of Decimal)
            Get
                TotalWithResaleTax = _TotalWithResaleTax
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalWithResaleTax = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Comments = _Comments
            End Get
            Set(value As String)
                _Comments = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
		Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ARInvoiceNumber = value
            End Set
        End Property
        Public Property ARInvoiceType() As String
            Get
                ARInvoiceType = _ARInvoiceType
            End Get
            Set(value As String)
                _ARInvoiceType = value
            End Set
        End Property
        Public Property ARInvoiceDate() As Nullable(Of Date)
            Get
                ARInvoiceDate = _ARInvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _ARInvoiceDate = value
            End Set
        End Property
        Public Property BillingUserCode() As String
            Get
                BillingUserCode = _BillingUserCode
            End Get
            Set(value As String)
                _BillingUserCode = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
		Public Property GLTransactionBill() As Nullable(Of Integer)
            Get
                GLTransactionBill = _GLTransactionBill
            End Get
            Set(value As Nullable(Of Integer))
                _GLTransactionBill = value
            End Set
        End Property
        Public Property GLAccountSales() As String
            Get
                GLAccountSales = _GLAccountSales
            End Get
            Set(value As String)
                _GLAccountSales = value
            End Set
        End Property
        Public Property GLAccountSalesDescription() As String
            Get
                GLAccountSalesDescription = _GLAccountSalesDescription
            End Get
            Set(value As String)
                _GLAccountSalesDescription = value
            End Set
        End Property
        Public Property NonBillFlag() As String
            Get
                NonBillFlag = _NonBillFlag
            End Get
            Set(value As String)
                _NonBillFlag = value
            End Set
        End Property
        Public Property BillHoldFlag() As String
            Get
                BillHoldFlag = _BillHoldFlag
            End Get
            Set(value As String)
                _BillHoldFlag = value
            End Set
        End Property
        Public Property ModifiedByUserCode() As String
            Get
                ModifiedByUserCode = _ModifiedByUserCode
            End Get
            Set(value As String)
                _ModifiedByUserCode = value
            End Set
        End Property
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
