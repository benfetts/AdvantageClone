Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.W_AR_FUNCTION")>
    Public Class WorkARFunction
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BillingUserCode
            ARInvoiceNumber
            DraftInvoiceNumber
            ARInvoiceSequence
            CoOpCode
            CoOpPercent
            IsManual
            OrderNumber
            OrderLineNumber
            MediaType
            JobNumber
            JobComponentNumber
            JobAdvanceBillingFlag
            ARDescription
            ClientCode
            DivisionCode
            ProductCode
            OfficeCode
            SalesClassCode
            CampaignID
            ClientPO
            FunctionCode
            FunctionType
            SalePostPeriodCode
            SalesTaxCode
            ApplyTaxFlag
            InvByFlag
            BillCommissionNetFlag
            AdvanceBillRecFlag
            MedRecFlag
            HoursQuantity
            MarketCode
            MediaMonth
            MediaYear
            StartDate
            EndDate
            EmployeeTimeAmount
            IncomeOnlyAmount
            MarkupAmount
            RebateAmount
            CostAmount
            NetChargeAmount
            VendorTaxAmount
            DiscountAmount
            AdditionalAmount
            AdvanceBillCostAmount
            AdvanceBillIncomeAmount
            AdvanceBillMarkupAmount
            AdvanceBillSaleAmount
            CityTaxAmount
            CountyTaxAmount
            StateTaxAmount
            TotalBillAmount
            StateTaxPercent
            CountyTaxPercent
            CityTaxPercent
            TaxCommission
            TaxCommissionOnly
            IsReconciled
            IsSummary
            IsModified
            IsRejectedByOffice
            AdvanceBillVendorTaxAmount
            SummaryRowID
            AvaTaxCalculated
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _BillingUserCode As String = ""
        Private _ARInvoiceNumber As System.Nullable(Of Long) = 0
        Private _DraftInvoiceNumber As String = ""
        Private _ARInvoiceSequence As System.Nullable(Of Long) = 0
        Private _CoOpCode As String = ""
        Private _CoOpPercent As System.Nullable(Of Decimal) = 0
        Private _IsManual As Long = 0
        Private _OrderNumber As System.Nullable(Of Long) = 0
        Private _OrderLineNumber As System.Nullable(Of Long) = 0
        Private _MediaType As String = ""
        Private _JobNumber As System.Nullable(Of Long) = 0
        Private _JobComponentNumber As System.Nullable(Of Long) = 0
        Private _JobAdvanceBillingFlag As System.Nullable(Of Long) = 0
        Private _ARDescription As String = ""
        Private _ClientCode As String = ""
        Private _DivisionCode As String = ""
        Private _ProductCode As String = ""
        Private _OfficeCode As String = ""
        Private _SalesClassCode As String = ""
        Private _CampaignID As System.Nullable(Of Long) = 0
        Private _ClientPO As String = ""
        Private _FunctionCode As String = ""
        Private _FunctionType As String = ""
        Private _SalePostPeriodCode As String = ""
        Private _SalesTaxCode As String = ""
        Private _ApplyTaxFlag As System.Nullable(Of Long) = 0
        Private _InvByFlag As System.Nullable(Of Long) = 0
        Private _BillCommissionNetFlag As System.Nullable(Of Long) = 0
        Private _AdvanceBillRecFlag As System.Nullable(Of Long) = 0
        Private _MedRecFlag As System.Nullable(Of Long) = 0
        Private _HoursQuantity As System.Nullable(Of Decimal) = 0
        Private _MarketCode As String = ""
        Private _MediaMonth As System.Nullable(Of Long) = 0
        Private _MediaYear As System.Nullable(Of Long) = 0
        Private _StartDate As System.Nullable(Of DateTime) = "1/1/1900"
        Private _EndDate As System.Nullable(Of DateTime) = "1/1/1900"
        Private _EmployeeTimeAmount As System.Nullable(Of Decimal) = 0
        Private _IncomeOnlyAmount As System.Nullable(Of Decimal) = 0
        Private _MarkupAmount As System.Nullable(Of Decimal) = 0
        Private _RebateAmount As System.Nullable(Of Decimal) = 0
        Private _CostAmount As System.Nullable(Of Decimal) = 0
        Private _NetChargeAmount As System.Nullable(Of Decimal) = 0
        Private _VendorTaxAmount As System.Nullable(Of Decimal) = 0
        Private _DiscountAmount As System.Nullable(Of Decimal) = 0
        Private _AdditionalAmount As System.Nullable(Of Decimal) = 0
        Private _AdvanceBillCostAmount As System.Nullable(Of Decimal) = 0
        Private _AdvanceBillIncomeAmount As System.Nullable(Of Decimal) = 0
        Private _AdvanceBillMarkupAmount As System.Nullable(Of Decimal) = 0
        Private _AdvanceBillSaleAmount As System.Nullable(Of Decimal) = 0
        Private _CityTaxAmount As System.Nullable(Of Decimal) = 0
        Private _CountyTaxAmount As System.Nullable(Of Decimal) = 0
        Private _StateTaxAmount As System.Nullable(Of Decimal) = 0
        Private _TotalBillAmount As System.Nullable(Of Decimal) = 0
        Private _StateTaxPercent As System.Nullable(Of Decimal) = 0
        Private _CountyTaxPercent As System.Nullable(Of Decimal) = 0
        Private _CityTaxPercent As System.Nullable(Of Decimal) = 0
        Private _TaxCommission As System.Nullable(Of Long) = 0
        Private _TaxCommissionOnly As System.Nullable(Of Long) = 0
        Private _IsReconciled As System.Nullable(Of Long) = 0
        Private _IsSummary As Long = 0
        Private _IsModified As System.Nullable(Of Long) = 0
        Private _IsRejectedByOffice As System.Nullable(Of Long) = 0
        Private _AdvanceBillVendorTaxAmount As System.Nullable(Of Decimal) = 0
        Private _SummaryRowID As System.Nullable(Of Long) = 0
        Private _AvaTaxCalculated As System.Nullable(Of Long) = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AR_FUNCTION_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BILLING_USER", Storage:="_BillingUserCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("BillingUserCode"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property BillingUserCode() As String
			Get
				BillingUserCode = _BillingUserCode
			End Get
			Set(ByVal value As String)
				_BillingUserCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AR_INV_NBR", Storage:="_ARInvoiceNumber", DbType:="int"),
		System.ComponentModel.DisplayName("ARInvoiceNumber")>
		Public Property ARInvoiceNumber() As System.Nullable(Of Long)
			Get
				ARInvoiceNumber = _ARInvoiceNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ARInvoiceNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DRAFT_INV_NBR", Storage:="_DraftInvoiceNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("DraftInvoiceNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(110)>
		Public Property DraftInvoiceNumber() As String
			Get
				DraftInvoiceNumber = _DraftInvoiceNumber
			End Get
			Set(ByVal value As String)
				_DraftInvoiceNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AR_INV_SEQ", Storage:="_ARInvoiceSequence", DbType:="smallint"),
		System.ComponentModel.DisplayName("ARInvoiceSequence")>
		Public Property ARInvoiceSequence() As System.Nullable(Of Long)
			Get
				ARInvoiceSequence = _ARInvoiceSequence
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ARInvoiceSequence = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COOP_CODE", Storage:="_CoOpCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("CoOpCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property CoOpCode() As String
			Get
				CoOpCode = _CoOpCode
			End Get
			Set(ByVal value As String)
				_CoOpCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COOP_PCT", Storage:="_CoOpPercent", DbType:="decimal"),
		System.ComponentModel.DisplayName("CoOpPercent")>
		Public Property CoOpPercent() As System.Nullable(Of Decimal)
			Get
				CoOpPercent = _CoOpPercent
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_CoOpPercent = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MANUAL_FLAG", Storage:="_IsManual", DbType:="bit"),
		System.ComponentModel.DisplayName("IsManual")>
		Public Property IsManual() As Long
			Get
				IsManual = _IsManual
			End Get
			Set(ByVal value As Long)
				_IsManual = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_NBR", Storage:="_OrderNumber", DbType:="int"),
		System.ComponentModel.DisplayName("OrderNumber")>
		Public Property OrderNumber() As System.Nullable(Of Long)
			Get
				OrderNumber = _OrderNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_OrderNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_LINE_NBR", Storage:="_OrderLineNumber", DbType:="smallint"),
		System.ComponentModel.DisplayName("OrderLineNumber")>
		Public Property OrderLineNumber() As System.Nullable(Of Long)
			Get
				OrderLineNumber = _OrderLineNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_OrderLineNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_TYPE", Storage:="_MediaType", DbType:="varchar"),
		System.ComponentModel.DisplayName("MediaType"),
		System.ComponentModel.DataAnnotations.MaxLength(1)>
		Public Property MediaType() As String
			Get
				MediaType = _MediaType
			End Get
			Set(ByVal value As String)
				_MediaType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_NUMBER", Storage:="_JobNumber", DbType:="int"),
		System.ComponentModel.DisplayName("JobNumber")>
		Public Property JobNumber() As System.Nullable(Of Long)
			Get
				JobNumber = _JobNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_JobNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMPONENT_NBR", Storage:="_JobComponentNumber", DbType:="smallint"),
		System.ComponentModel.DisplayName("JobComponentNumber")>
		Public Property JobComponentNumber() As System.Nullable(Of Long)
			Get
				JobComponentNumber = _JobComponentNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_JobComponentNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_AB_FLAG", Storage:="_JobAdvanceBillingFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("JobAdvanceBillingFlag")>
		Public Property JobAdvanceBillingFlag() As System.Nullable(Of Long)
			Get
				JobAdvanceBillingFlag = _JobAdvanceBillingFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_JobAdvanceBillingFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AR_DESCRIPTION", Storage:="_ARDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("ARDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(75)>
		Public Property ARDescription() As String
			Get
				ARDescription = _ARDescription
			End Get
			Set(ByVal value As String)
				_ARDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_CODE", Storage:="_ClientCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(ByVal value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DIV_CODE", Storage:="_DivisionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("DivisionCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRD_CODE", Storage:="_ProductCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ProductCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(ByVal value As String)
				_ProductCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OFFICE_CODE", Storage:="_OfficeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("OfficeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property OfficeCode() As String
			Get
				OfficeCode = _OfficeCode
			End Get
			Set(ByVal value As String)
				_OfficeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SC_CODE", Storage:="_SalesClassCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SalesClassCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SalesClassCode() As String
			Get
				SalesClassCode = _SalesClassCode
			End Get
			Set(ByVal value As String)
				_SalesClassCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CMP_IDENTIFIER", Storage:="_CampaignID", DbType:="int"),
		System.ComponentModel.DisplayName("CampaignID")>
		Public Property CampaignID() As System.Nullable(Of Long)
			Get
				CampaignID = _CampaignID
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_CampaignID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLIENT_PO", Storage:="_ClientPO", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientPO"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property ClientPO() As String
			Get
				ClientPO = _ClientPO
			End Get
			Set(ByVal value As String)
				_ClientPO = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_CODE", Storage:="_FunctionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("FunctionCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property FunctionCode() As String
			Get
				FunctionCode = _FunctionCode
			End Get
			Set(ByVal value As String)
				_FunctionCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_TYPE", Storage:="_FunctionType", DbType:="varchar"),
		System.ComponentModel.DisplayName("FunctionType"),
		System.ComponentModel.DataAnnotations.MaxLength(1)>
		Public Property FunctionType() As String
			Get
				FunctionType = _FunctionType
			End Get
			Set(ByVal value As String)
				_FunctionType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SALE_POST_PERIOD", Storage:="_SalePostPeriodCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SalePostPeriodCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SalePostPeriodCode() As String
			Get
				SalePostPeriodCode = _SalePostPeriodCode
			End Get
			Set(ByVal value As String)
				_SalePostPeriodCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_CODE", Storage:="_SalesTaxCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SalesTaxCode"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property SalesTaxCode() As String
			Get
				SalesTaxCode = _SalesTaxCode
			End Get
			Set(ByVal value As String)
				_SalesTaxCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INV_TAX_FLAG", Storage:="_ApplyTaxFlag", DbType:="bit"),
		System.ComponentModel.DisplayName("ApplyTaxFlag")>
		Public Property ApplyTaxFlag() As System.Nullable(Of Long)
			Get
				ApplyTaxFlag = _ApplyTaxFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ApplyTaxFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INV_BY", Storage:="_InvByFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("InvByFlag")>
		Public Property InvByFlag() As System.Nullable(Of Long)
			Get
				InvByFlag = _InvByFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_InvByFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BILL_COMM_NET", Storage:="_BillCommissionNetFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("BillCommissionNetFlag")>
		Public Property BillCommissionNetFlag() As System.Nullable(Of Long)
			Get
				BillCommissionNetFlag = _BillCommissionNetFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_BillCommissionNetFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AB_REC_FLAG", Storage:="_AdvanceBillRecFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("AdvanceBillRecFlag")>
		Public Property AdvanceBillRecFlag() As System.Nullable(Of Long)
			Get
				AdvanceBillRecFlag = _AdvanceBillRecFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_AdvanceBillRecFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MED_REC_FLAG", Storage:="_MedRecFlag", DbType:="smallint"),
		System.ComponentModel.DisplayName("MedRecFlag")>
		Public Property MedRecFlag() As System.Nullable(Of Long)
			Get
				MedRecFlag = _MedRecFlag
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_MedRecFlag = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HRS_QTY", Storage:="_HoursQuantity", DbType:="decimal"),
		System.ComponentModel.DisplayName("HoursQuantity")>
		Public Property HoursQuantity() As System.Nullable(Of Decimal)
			Get
				HoursQuantity = _HoursQuantity
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_HoursQuantity = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MARKET_CODE", Storage:="_MarketCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("MarketCode"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(ByVal value As String)
                _MarketCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_MONTH", Storage:="_MediaMonth", DBType:="tinyint"), _
        System.ComponentModel.DisplayName("MediaMonth")> _
        Public Property MediaMonth() As System.Nullable(Of Long)
            Get
                MediaMonth = _MediaMonth
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MediaMonth = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_YEAR", Storage:="_MediaYear", DBType:="smallint"), _
        System.ComponentModel.DisplayName("MediaYear")> _
        Public Property MediaYear() As System.Nullable(Of Long)
            Get
                MediaYear = _MediaYear
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MediaYear = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_DATE", Storage:="_StartDate", DBType:="smalldatetime"), _
        System.ComponentModel.DisplayName("StartDate")> _
        Public Property StartDate() As System.Nullable(Of DateTime)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _StartDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_DATE", Storage:="_EndDate", DBType:="smalldatetime"), _
        System.ComponentModel.DisplayName("EndDate")> _
        Public Property EndDate() As System.Nullable(Of DateTime)
            Get
                EndDate = _EndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EndDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_TIME_AMT", Storage:="_EmployeeTimeAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("EmployeeTimeAmount")> _
        Public Property EmployeeTimeAmount() As System.Nullable(Of Decimal)
            Get
                EmployeeTimeAmount = _EmployeeTimeAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _EmployeeTimeAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INC_ONLY_AMT", Storage:="_IncomeOnlyAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("IncomeOnlyAmount")> _
        Public Property IncomeOnlyAmount() As System.Nullable(Of Decimal)
            Get
                IncomeOnlyAmount = _IncomeOnlyAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _IncomeOnlyAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COMMISSION_AMT", Storage:="_MarkupAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("MarkupAmount")> _
        Public Property MarkupAmount() As System.Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REBATE_AMT", Storage:="_RebateAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("RebateAmount")> _
        Public Property RebateAmount() As System.Nullable(Of Decimal)
            Get
                RebateAmount = _RebateAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _RebateAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COST_AMT", Storage:="_CostAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("CostAmount")> _
        Public Property CostAmount() As System.Nullable(Of Decimal)
            Get
                CostAmount = _CostAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _CostAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NET_CHARGE_AMT", Storage:="_NetChargeAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("NetChargeAmount")> _
        Public Property NetChargeAmount() As System.Nullable(Of Decimal)
            Get
                NetChargeAmount = _NetChargeAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _NetChargeAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NON_RESALE_AMT", Storage:="_VendorTaxAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("VendorTaxAmount")> _
        Public Property VendorTaxAmount() As System.Nullable(Of Decimal)
            Get
                VendorTaxAmount = _VendorTaxAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _VendorTaxAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DISCOUNT_AMT", Storage:="_DiscountAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("DiscountAmount")> _
        Public Property DiscountAmount() As System.Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADDITIONAL_AMT", Storage:="_AdditionalAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("AdditionalAmount")> _
        Public Property AdditionalAmount() As System.Nullable(Of Decimal)
            Get
                AdditionalAmount = _AdditionalAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _AdditionalAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AB_COST_AMT", Storage:="_AdvanceBillCostAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("AdvanceBillCostAmount")> _
        Public Property AdvanceBillCostAmount() As System.Nullable(Of Decimal)
            Get
                AdvanceBillCostAmount = _AdvanceBillCostAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _AdvanceBillCostAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AB_INC_AMT", Storage:="_AdvanceBillIncomeAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("AdvanceBillIncomeAmount")> _
        Public Property AdvanceBillIncomeAmount() As System.Nullable(Of Decimal)
            Get
                AdvanceBillIncomeAmount = _AdvanceBillIncomeAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _AdvanceBillIncomeAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AB_COMMISSION_AMT", Storage:="_AdvanceBillMarkupAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("AdvanceBillMarkupAmount")> _
        Public Property AdvanceBillMarkupAmount() As System.Nullable(Of Decimal)
            Get
                AdvanceBillMarkupAmount = _AdvanceBillMarkupAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _AdvanceBillMarkupAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AB_SALE_AMT", Storage:="_AdvanceBillSaleAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("AdvanceBillSaleAmount")> _
        Public Property AdvanceBillSaleAmount() As System.Nullable(Of Decimal)
            Get
                AdvanceBillSaleAmount = _AdvanceBillSaleAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _AdvanceBillSaleAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CITY_TAX_AMT", Storage:="_CityTaxAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("CityTaxAmount")> _
        Public Property CityTaxAmount() As System.Nullable(Of Decimal)
            Get
                CityTaxAmount = _CityTaxAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _CityTaxAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CNTY_TAX_AMT", Storage:="_CountyTaxAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("CountyTaxAmount")> _
        Public Property CountyTaxAmount() As System.Nullable(Of Decimal)
            Get
                CountyTaxAmount = _CountyTaxAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _CountyTaxAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="STATE_TAX_AMT", Storage:="_StateTaxAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("StateTaxAmount")> _
        Public Property StateTaxAmount() As System.Nullable(Of Decimal)
            Get
                StateTaxAmount = _StateTaxAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _StateTaxAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TOTAL_BILL", Storage:="_TotalBillAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("TotalBillAmount")> _
        Public Property TotalBillAmount() As System.Nullable(Of Decimal)
            Get
                TotalBillAmount = _TotalBillAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _TotalBillAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_STATE_PCT", Storage:="_StateTaxPercent", DBType:="decimal"), _
        System.ComponentModel.DisplayName("StateTaxPercent")> _
        Public Property StateTaxPercent() As System.Nullable(Of Decimal)
            Get
                StateTaxPercent = _StateTaxPercent
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _StateTaxPercent = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_COUNTY_PCT", Storage:="_CountyTaxPercent", DBType:="decimal"), _
        System.ComponentModel.DisplayName("CountyTaxPercent")> _
        Public Property CountyTaxPercent() As System.Nullable(Of Decimal)
            Get
                CountyTaxPercent = _CountyTaxPercent
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _CountyTaxPercent = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_CITY_PCT", Storage:="_CityTaxPercent", DBType:="decimal"), _
        System.ComponentModel.DisplayName("CityTaxPercent")> _
        Public Property CityTaxPercent() As System.Nullable(Of Decimal)
            Get
                CityTaxPercent = _CityTaxPercent
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _CityTaxPercent = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_COMM", Storage:="_TaxCommission", DBType:="bit"), _
        System.ComponentModel.DisplayName("TaxCommission")> _
        Public Property TaxCommission() As System.Nullable(Of Long)
            Get
                TaxCommission = _TaxCommission
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _TaxCommission = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_COMM_ONLY", Storage:="_TaxCommissionOnly", DBType:="bit"), _
        System.ComponentModel.DisplayName("TaxCommissionOnly")> _
        Public Property TaxCommissionOnly() As System.Nullable(Of Long)
            Get
                TaxCommissionOnly = _TaxCommissionOnly
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _TaxCommissionOnly = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RECONCILE_ROW", Storage:="_IsReconciled", DBType:="bit"), _
        System.ComponentModel.DisplayName("IsReconciled")> _
        Public Property IsReconciled() As System.Nullable(Of Long)
            Get
                IsReconciled = _IsReconciled
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsReconciled = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUMMARY_FLAG", Storage:="_IsSummary", DBType:="bit"), _
        System.ComponentModel.DisplayName("IsSummary")> _
        Public Property IsSummary() As Long
            Get
                IsSummary = _IsSummary
            End Get
            Set(ByVal value As Long)
                _IsSummary = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MODIFIED_FLAG", Storage:="_IsModified", DBType:="bit"), _
        System.ComponentModel.DisplayName("IsModified")> _
        Public Property IsModified() As System.Nullable(Of Long)
            Get
                IsModified = _IsModified
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsModified = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REJECTED_BY_OFFICE", Storage:="_IsRejectedByOffice", DBType:="bit"), _
        System.ComponentModel.DisplayName("IsRejectedByOffice")> _
        Public Property IsRejectedByOffice() As System.Nullable(Of Long)
            Get
                IsRejectedByOffice = _IsRejectedByOffice
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsRejectedByOffice = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AB_NONRESALE_AMT", Storage:="_AdvanceBillVendorTaxAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("AdvanceBillVendorTaxAmount")> _
        Public Property AdvanceBillVendorTaxAmount() As System.Nullable(Of Decimal)
            Get
                AdvanceBillVendorTaxAmount = _AdvanceBillVendorTaxAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _AdvanceBillVendorTaxAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUMMARY_ROW_ID", Storage:="_SummaryRowID", DBType:="int"), _
        System.ComponentModel.DisplayName("SummaryRowID")> _
        Public Property SummaryRowID() As System.Nullable(Of Long)
            Get
                SummaryRowID = _SummaryRowID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SummaryRowID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AVATAX_CALCULATED", Storage:="_AvaTaxCalculated", DBType:="bit"), _
        System.ComponentModel.DisplayName("AvaTaxCalculated")> _
        Public Property AvaTaxCalculated() As System.Nullable(Of Long)
            Get
                AvaTaxCalculated = _AvaTaxCalculated
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _AvaTaxCalculated = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
