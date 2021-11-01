Namespace Database.Entities

    <Table("INCOME_ONLY")>
    Public Class IncomeOnly
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            ReferenceNumber
            JobNumber
            JobComponentNumber
            FunctionCode
            InvoiceDate
            Amount
            Description
            CommissionPercent
            TaxCode
            BillHoldFlag
            ARInvoiceNumber
            ARInvoiceSequence
            ARType
            BillingUser
            TaxStatePercent
            TaxCountyPercent
            TaxCityPercent
            TaxCommission
            TaxCommissionOnly
            TaxResale
            AdjusterComments
            GeneralLedgerBilling
            GeneralLedgerSales
            GeneralLedgerState
            GeneralLedgerCounty
            GeneralLedgerCity
            GeneralLedgerAccountSales
            GeneralLedgerAccountState
            GeneralLedgerAccountCounty
            GeneralLedgerAccountCity
            AdvanceBillFlag
            DepartmentTeamCode
            ExtendedMarkupAmount
            ExtendedStateResale
            ExtendedCountyResale
            ExtendedCityResale
            Quantity
            Rate
            LineTotal
            NonBillable
            IsModified
            ModifiedBy
            ModifiedDate
            DeleteFlag
            DeletedBy
            DeletedDate
            PostPeriod
            AdvanceBillID
            Comment
            CampaignUpdatedInvoiceDate
            CampaignUpdatedPostPeriod
            TransferFromJob
            TransferFromJobComponent
            TransferFromFunction
            TransferFromIncomeOnlyID
            TransferFromSequenceNumber
            TransferAdjustedUser
            TransferAdjustedDate
            FeeInvoice
            IsArchived
            BillingApprovalID
            BillingCommandCenterID
            JobServiceFeeID
            OrderNumber
            LineNumber
            IsBilledReversal
            AccountReceivable
            DepartmentTeam
            [Function]
            JobComponent
            SalesTax
            JobServiceFee

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("IO_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Key>
        <Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
        <MaxLength(26)>
        <Column("IO_INV_NBR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReferenceNumber() As String
        <Required>
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Integer
        <Required>
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Short
        <Required>
        <MaxLength(6)>
        <Column("FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <Column("IO_INV_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("IO_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Amount() As Nullable(Of Decimal)
        <MaxLength(100)>
        <Column("IO_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <Column("IO_COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCode() As String
        <Column("BILL_HOLD_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillHoldFlag() As Nullable(Of Short)
        <Column("AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
        <Column("AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceSequence() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARType() As String
        <MaxLength(100)>
        <Column("BILLING_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingUser() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        <Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxStatePercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        <Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCountyPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        <Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCityPercent() As Nullable(Of Decimal)
        <Column("TAX_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommission() As Nullable(Of Short)
        <Column("TAX_COMM_ONLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCommissionOnly() As Nullable(Of Short)
        <Column("TAX_RESALE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxResale() As Nullable(Of Short)
		<Column("ADJ_COMMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdjusterComments() As String
		<Column("GLEXACT_BILL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerBilling() As Nullable(Of Integer)
		<Column("GLESEQ_SALES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerSales() As Nullable(Of Short)
		<Column("GLESEQ_STATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerState() As Nullable(Of Short)
		<Column("GLESEQ_CNTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerCounty() As Nullable(Of Short)
		<Column("GLESEQ_CITY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerCity() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("GLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerAccountSales() As String
		<MaxLength(30)>
		<Column("GLACODE_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerAccountState() As String
		<MaxLength(30)>
		<Column("GLACODE_CNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerAccountCounty() As String
		<MaxLength(30)>
		<Column("GLACODE_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneralLedgerAccountCity() As String
		<Column("AB_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdvanceBillFlag() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("DP_TM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DepartmentTeamCode() As String
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<Column("EXT_MARKUP_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
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
		<Column("IO_QTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Quantity() As Nullable(Of Decimal)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 4)>
		<Column("IO_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Rate() As Nullable(Of Decimal)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<Column("LINE_TOTAL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineTotal() As Nullable(Of Decimal)
		<Column("NON_BILL_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NonBillable() As Nullable(Of Short)
		<Column("MODIFY_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsModified() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("MODIFIED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<Column("MODIFY_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Column("DELETE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeleteFlag() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("DELETED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeletedBy() As String
		<Column("DELETE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeletedDate() As Nullable(Of Date)
		<MaxLength(8)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriod() As String
		<Column("AB_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdvanceBillID() As Nullable(Of Integer)
		<Column("IO_COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <Column("CMP_UPD_INV_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignUpdatedInvoiceDate() As Nullable(Of Short)
        <Column("CMP_UPD_PP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignUpdatedPostPeriod() As Nullable(Of Short)
        <Column("XFER_FROM_JOB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromJob() As Nullable(Of Integer)
        <Column("XFER_FROM_JOB_COMP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromJobComponent() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("XFER_FROM_FNC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromFunction() As String
        <Column("XFER_FROM_IO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromIncomeOnlyID() As Nullable(Of Integer)
        <Column("XFER_FROM_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferFromSequenceNumber() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("XFER_ADJ_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferAdjustedUser() As String
        <Column("XFER_ADJ_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransferAdjustedDate() As Nullable(Of Date)
        <Column("FEE_INVOICE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeInvoice() As Nullable(Of Short)
        <Column("ARCHIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsArchived() As Nullable(Of Short)
        <Column("BA_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalID() As Nullable(Of Integer)
        <Column("BCC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
        <Column("JOB_SERVICE_FEE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobServiceFeeID() As Nullable(Of Integer)
        <Column("ORDER_NBR")>
        Public Property OrderNumber() As Nullable(Of Integer)
        <Column("LINE_NBR")>
        Public Property LineNumber() As Nullable(Of Short)
        <Column("IS_BILLED_REVERSAL")>
        Public Property IsBilledReversal() As Nullable(Of Boolean)

        <ForeignKey("ARInvoiceNumber, ARInvoiceSequence, ARType")>
        Public Overridable Property AccountReceivable As Database.Entities.AccountReceivable
        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property [Function] As Database.Entities.Function
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property SalesTax As Database.Entities.SalesTax
        Public Overridable Property JobServiceFee As Database.Entities.JobServiceFee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
