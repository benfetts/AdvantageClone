Namespace Database.Entities

    <Table("AP_PRODUCTION")>
    Public Class AccountPayableProduction
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            AccountPayableSequenceNumber
            LineNumber
            JobNumber
            JobComponentNumber
            FunctionCode
            Quantity
            Rate
            ExtendedAmount
            SalesTaxCode
            CommissionPercent
            StateTaxPercent
            CountyTaxPercent
            CityTaxPercent
            IsNonBillable
            PODetailLineNumber
            AccountReceivableInvoiceNumber
            AccountReceivableInvoiceSequenceNumber
            AccountReceivableType
            GLACode
            IsResaleTax
            GLTransaction
            GLSequenceNumber
            GLTransactionBill
            GLSequenceNumberSales
            GLSequenceNumberCOS
            GLSequenceNumberState
            GLSequenceNumberCounty
            GLSequenceNumberCity
            GLSequenceNumberWIP
            GLACodeSales
            GLACodeCOS
            GLACodeState
            GLACodeCounty
            GLACodeCity
            DepartmentTeamCode
            IsPOComplete
            ExtendedMarkupAmount
            ExtendedNonResaleTax
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            LineTotal
            PostPeriodCode
            PONumber
            OfficeCode
            GLACodeDueFrom
            GLACodeDueTo
            GLSequenceNumberDueFrom
            GLSequenceNumberDueTo
            IsDeleted
            IsWriteOff
            ModifyDelete
            IsAdvanceBilling
            TaxCommissions
            TaxCommissionsOnly
            BillHoldFlag
            TransferFromJobNumber
            TransferFromJobComponentNumber
            TransferFromFunctionCode
            TransferFromAccountPayableID
            TransferFromLineNumber
            TransferAdjustmentUserCode
            TransferAdjustmentDate
            TransferFromAccountPayableSequenceNumber
            ExtendedAmountForeign
            RateForeign
            NonResidentTaxForeign
            AmountExchange
            BillingUserCode
            CreatedBy
            CreateDate
            ModifiedBy
            ModifyDate
            AdjustmentComments
            AdvanceBillingID
            BillingApprovalID
            BillingCommandCenterID
            ExpenseReportDetailID
            CurrencyCode
            CurrencyCodeHome
            CurrencyRate
            IsBilledReversal
            AccountPayable
            DepartmentTeam
            [Function]
            GeneralLedgerAccount
            JobComponent
            SalesTax
            GeneralLedger
            Job

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AccountPayableID() As Integer
        <Key>
        <Required>
        <Column("AP_SEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AccountPayableSequenceNumber() As Short
        <Key>
        <Required>
        <Column("LINE_NUMBER", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Short
        <Required>
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Integer
        <Required>
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber() As Short
        <Required>
        <MaxLength(6)>
        <Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AP_PROD_QUANTITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 4)>
        <Column("AP_PROD_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AP_PROD_EXT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedAmount() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property SalesTaxCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <Column("AP_PROD_COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxPercent() As Nullable(Of Decimal)
        <Column("AP_PROD_NOBILL_FLG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNonBillable() As Nullable(Of Short)
        <Column("PO_LINE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PODetailLineNumber() As Nullable(Of Short)
        <Column("AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountReceivableInvoiceNumber() As Nullable(Of Integer)
        <Column("AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountReceivableInvoiceSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountReceivableType() As String
        <Required>
        <MaxLength(30)>
        <Column("GLACODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        <ForeignKey("GeneralLedgerAccount")>
        Public Property GLACode() As String
        <Column("TAX_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsResaleTax() As Nullable(Of Short)
        <Column("GLEXACT")>
        <ForeignKey("GeneralLedger")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLTransaction() As Nullable(Of Integer)
        <Column("GLESEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumber() As Nullable(Of Short)
        <Column("GLEXACT_BILL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLTransactionBill() As Nullable(Of Integer)
        <Column("GLESEQ_SALES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberSales() As Nullable(Of Short)
        <Column("GLESEQ_COS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberCOS() As Nullable(Of Short)
        <Column("GLESEQ_STATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberState() As Nullable(Of Short)
        <Column("GLESEQ_CNTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberCounty() As Nullable(Of Short)
        <Column("GLESEQ_CITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberCity() As Nullable(Of Short)
        <Column("GLESEQ_WIP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberWIP() As Nullable(Of Short)
        <MaxLength(30)>
        <Column("GLACODE_SALES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeSales() As String
        <MaxLength(30)>
        <Column("GLACODE_COS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeCOS() As String
        <MaxLength(30)>
        <Column("GLACODE_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeState() As String
        <MaxLength(30)>
        <Column("GLACODE_CNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeCounty() As String
        <MaxLength(30)>
        <Column("GLACODE_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeCity() As String
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String
        <Column("PO_COMPLETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsPOComplete() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_MARKUP_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_NONRESALE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedNonResaleTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_STATE_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedStateResale() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_COUNTY_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedCountyResale() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXT_CITY_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedCityResale() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineTotal() As Nullable(Of Decimal)
        <MaxLength(8)>
        <Column("POST_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property PostPeriodCode() As String
        <Column("PO_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PONumber() As Nullable(Of Integer)
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("GLACODE_DUE_FROM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeDueFrom() As String
        <MaxLength(30)>
        <Column("GLACODE_DUE_TO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeDueTo() As String
        <Column("GLESEQ_DUE_FROM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDueFrom() As Nullable(Of Short)
        <Column("GLESEQ_DUE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDueTo() As Nullable(Of Short)
        <Column("DELETE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As Nullable(Of Short)
        <Required>
        <Column("WRITE_OFF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsWriteOff() As Short
        <Column("MODIFY_DELETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifyDelete() As Nullable(Of Short)
        <Column("AB_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsAdvanceBilling() As Nullable(Of Short)
        <Column("TAX_COMMISSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommissions() As Nullable(Of Short)
        <Column("TAX_COMM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommissionsOnly() As Nullable(Of Short)
        <Column("AP_PROD_BILL_HOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillHoldFlag() As Nullable(Of Short)
        <Column("XFER_FROM_JOB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobNumber)>
        Public Property TransferFromJobNumber() As Nullable(Of Integer)
        <Column("XFER_FROM_JOB_COMP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.JobComponent)>
        Public Property TransferFromJobComponentNumber() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("XFER_FROM_FNC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
        Public Property TransferFromFunctionCode() As String
        <Column("XFER_FROM_AP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromAccountPayableID() As Nullable(Of Integer)
        <Column("XFER_FROM_LINE_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromLineNumber() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("XFER_ADJ_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferAdjustmentUserCode() As String
        <Column("XFER_ADJ_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferAdjustmentDate() As Nullable(Of Date)
        <Column("XFER_FROM_AP_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromAccountPayableSequenceNumber() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AP_PRD_EXT_AMT_FRN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedAmountForeign() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 3)>
        <Column("AP_PRD_RATE_FRN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RateForeign() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 3)>
        <Column("AP_NONRES_TAX_FRN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonResidentTaxForeign() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 3)>
        <Column("AP_PRD_AMT_XCHG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AmountExchange() As Nullable(Of Decimal)
        <MaxLength(100)>
        <Column("BILLING_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingUserCode() As String
        <MaxLength(100)>
        <Column("CREATED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedBy() As String
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreateDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("MODIFIED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedBy() As String
        <Column("MODIFY_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifyDate() As Nullable(Of Date)
		<Column("ADJ_COMMENTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdjustmentComments() As String
        <Column("AB_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillingID() As Nullable(Of Integer)
        <Column("BA_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalID() As Nullable(Of Integer)
        <Column("BCC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
        <Column("EXPDETAILID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpenseReportDetailID() As Nullable(Of Integer)
        <Column("IS_BILLED_REVERSAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsBilledReversal() As Nullable(Of Boolean)

        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property [Function] As Database.Entities.Function
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        <ForeignKey("SalesTaxCode")>
        Public Overridable Property SalesTax As Database.Entities.SalesTax
        Public Overridable Property GeneralLedger As Database.Entities.GeneralLedger
        Public Overridable Property Job As Database.Entities.Job

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.AccountPayableProduction

            Dim EntityCopy As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.AccountPayableProduction

            With EntityCopy
                .AccountPayableID = Me.AccountPayableID
                .AccountPayableSequenceNumber = Me.AccountPayableSequenceNumber
                .LineNumber = Me.LineNumber
                .JobNumber = Me.JobNumber
                .JobComponentNumber = Me.JobComponentNumber
                .FunctionCode = Me.FunctionCode
                .Quantity = Me.Quantity
                .Rate = Me.Rate
                .ExtendedAmount = Me.ExtendedAmount
                .SalesTaxCode = Me.SalesTaxCode
                .CommissionPercent = Me.CommissionPercent
                .StateTaxPercent = Me.StateTaxPercent
                .CountyTaxPercent = Me.CountyTaxPercent
                .CityTaxPercent = Me.CityTaxPercent
                .IsNonBillable = Me.IsNonBillable
                .PODetailLineNumber = Me.PODetailLineNumber
                .AccountReceivableInvoiceNumber = Me.AccountReceivableInvoiceNumber
                .AccountReceivableInvoiceSequenceNumber = Me.AccountReceivableInvoiceSequenceNumber
                .AccountReceivableType = Me.AccountReceivableType
                .GLACode = Me.GLACode
                .IsResaleTax = Me.IsResaleTax
                .GLTransaction = Me.GLTransaction
                .GLSequenceNumber = Me.GLSequenceNumber
                .GLTransactionBill = Me.GLTransactionBill
                .GLSequenceNumberSales = Me.GLSequenceNumberSales
                .GLSequenceNumberCOS = Me.GLSequenceNumberCOS
                .GLSequenceNumberState = Me.GLSequenceNumberState
                .GLSequenceNumberCounty = Me.GLSequenceNumberCounty
                .GLSequenceNumberCity = Me.GLSequenceNumberCity
                .GLSequenceNumberWIP = Me.GLSequenceNumberWIP
                .GLACodeSales = Me.GLACodeSales
                .GLACodeCOS = Me.GLACodeCOS
                .GLACodeState = Me.GLACodeState
                .GLACodeCounty = Me.GLACodeCounty
                .GLACodeCity = Me.GLACodeCity
                .DepartmentTeamCode = Me.DepartmentTeamCode
                .IsPOComplete = Me.IsPOComplete
                .ExtendedMarkupAmount = Me.ExtendedMarkupAmount
                .ExtendedNonResaleTax = Me.ExtendedNonResaleTax.GetValueOrDefault(0)
                .ExtendedStateResale = Me.ExtendedStateResale
                .ExtendedCountyResale = Me.ExtendedCountyResale
                .ExtendedCityResale = Me.ExtendedCityResale
                .LineTotal = Me.LineTotal
                .PostPeriodCode = Me.PostPeriodCode
                .PONumber = Me.PONumber
                .OfficeCode = Me.OfficeCode
                .GLACodeDueFrom = Me.GLACodeDueFrom
                .GLACodeDueTo = Me.GLACodeDueTo
                .GLSequenceNumberDueFrom = Me.GLSequenceNumberDueFrom
                .GLSequenceNumberDueTo = Me.GLSequenceNumberDueTo
                .IsDeleted = Me.IsDeleted
                .IsWriteOff = Me.IsWriteOff
                .ModifyDelete = Me.ModifyDelete
                .IsAdvanceBilling = Me.IsAdvanceBilling
                .TaxCommissions = Me.TaxCommissions
                .TaxCommissionsOnly = Me.TaxCommissionsOnly
                .BillHoldFlag = Me.BillHoldFlag
                .TransferFromJobNumber = Me.TransferFromJobNumber
                .TransferFromJobComponentNumber = Me.TransferFromJobComponentNumber
                .TransferFromFunctionCode = Me.TransferFromFunctionCode
                .TransferFromAccountPayableID = Me.TransferFromAccountPayableID
                .TransferFromLineNumber = Me.TransferFromLineNumber
                .TransferAdjustmentUserCode = Me.TransferAdjustmentUserCode
                .TransferAdjustmentDate = Me.TransferAdjustmentDate
                .TransferFromAccountPayableSequenceNumber = Me.TransferFromAccountPayableSequenceNumber
                .ExtendedAmountForeign = Me.ExtendedAmountForeign
                .RateForeign = Me.RateForeign
                .NonResidentTaxForeign = Me.NonResidentTaxForeign
                .AmountExchange = Me.AmountExchange
                .BillingUserCode = Me.BillingUserCode
                .CreatedBy = Me.CreatedBy
                .CreateDate = Me.CreateDate
                .ModifiedBy = Me.ModifiedBy
                .ModifyDate = Me.ModifyDate
                .ExpenseReportDetailID = Me.ExpenseReportDetailID
                .AdjustmentComments = Me.AdjustmentComments
                .AdvanceBillingID = Me.AdvanceBillingID
                .BillingApprovalID = Me.BillingApprovalID
                .BillingCommandCenterID = Me.BillingCommandCenterID
            End With

            Copy = EntityCopy

        End Function
        Public Sub SetLineTotal()

            Me.LineTotal = Me.ExtendedAmount.GetValueOrDefault(0) + Me.ExtendedMarkupAmount.GetValueOrDefault(0) + Me.ExtendedNonResaleTax.GetValueOrDefault(0) +
                           Me.ExtendedCityResale.GetValueOrDefault(0) + Me.ExtendedCountyResale.GetValueOrDefault(0) + Me.ExtendedStateResale.GetValueOrDefault(0)

        End Sub

#End Region

    End Class

End Namespace
