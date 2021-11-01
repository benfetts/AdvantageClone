Namespace Reporting.Database.Classes

    <Serializable>
    Public Class ARPaymentHistoryReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            ClientBillingAddress1
            ClientBillingAddress2
            ClientBillingCity
            ClientBillingState
            ClientBillingZip
            ClientBillingCounty
            ClientBillingCountry
            ClientStatementAddress1
            ClientStatementAddress2
            ClientStatementCity
            ClientStatementState
            ClientStatementZip
            ClientStatementCounty
            ClientStatementCountry
            ClientProductionContact
            ClientMediaContact
            ClientARComment
            DivisionCode
            DivisionName
            DivisionBillingAddress1
            DivisionBillingAddress2
            DivisionBillingCity
            DivisionBillingState
            DivisionBillingZip
            DivisionBillingCounty
            DivisionBillingCountry
            DivisionStatementAddress1
            DivisionStatementAddress2
            DivisionStatementCity
            DivisionStatementState
            DivisionStatementZip
            DivisionStatementCounty
            DivisionStatementCountry
            DivisionContact
            ProductCode
            ProductDescription
            ProductBillingAddress1
            ProductBillingAddress2
            ProductBillingCity
            ProductBillingState
            ProductBillingZip
            ProductBillingCounty
            ProductBillingCountry
            ProductStatementAddress1
            ProductStatementAddress2
            ProductStatementCity
            ProductStatementState
            ProductStatementZip
            ProductStatementCounty
            ProductStatementCountry
            ProductContact
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            ARInvoiceNumber
            ARInvoiceSequence
            ARInvoiceType
            ARInvoiceDate
            ARInvoiceDueDate
            ARCoopCode
            ARCoopPercentage
            ARManualInvoiceFlag
            ARInvoiceCategory
            ARDescription
            ARCollectionNotes
            ARType
            MediaType
            TransactionType
            PostingPeriod
            SalesPostingPeriod
            CampaignCode
            CampaignName
            ClientPO
            AccountExecutiveCode
            AccountExecutiveName
            JobNumber
            JobDescription
            ClientReference
            JobComponentNumber
            JobComponentDescription
            JobTypeDescription
            JobAccountExecutiveCode
            JobAccountExecutiveName
            OrderNumber
            OrderDescription
            VendorCode
            VendorName
            MediaMarket
            MediaDates
            ABIncomeRecognition
            ARHoursQuantity
            AREmployeeTimeAmount
            ARIncomeOnlyAmount
            ARCommissionAmount
            ARRebateAmount
            ARAdditionalCharges
            ARCostAmount
            ARAdvanceCostAmount
            ARAdvanceIncomeAmount
            ARAdvanceCommissionAmount
            ARAdvanceRetained
            ARCityTaxAmount
            ARCountyTaxAmount
            ARStateTaxAmount
            ARInvoiceAmount
            CheckNumber
            CheckDate
            CheckDepositDate
            CheckAmount
            CheckAdjustmentAmount
            BalanceAmount
            Paid
            DaysToPay
            CashReceiptPaymentType
            BankCode
            BankDescription
            IsCleared
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName As String
        Public Property ClientBillingAddress1 As String
        Public Property ClientBillingAddress2 As String
        Public Property ClientBillingCity As String
        Public Property ClientBillingState As String
        Public Property ClientBillingZip As String
        Public Property ClientBillingCounty As String
        Public Property ClientBillingCountry As String
        Public Property ClientStatementAddress1 As String
        Public Property ClientStatementAddress2 As String
        Public Property ClientStatementCity As String
        Public Property ClientStatementState As String
        Public Property ClientStatementZip As String
        Public Property ClientStatementCounty As String
        Public Property ClientStatementCountry As String
        Public Property ClientProductionContact As String
        Public Property ClientMediaContact As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientARComment As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName As String
        Public Property DivisionBillingAddress1 As String
        Public Property DivisionBillingAddress2 As String
        Public Property DivisionBillingCity As String
        Public Property DivisionBillingState As String
        Public Property DivisionBillingZip As String
        Public Property DivisionBillingCounty As String
        Public Property DivisionBillingCountry As String
        Public Property DivisionStatementAddress1 As String
        Public Property DivisionStatementAddress2 As String
        Public Property DivisionStatementCity As String
        Public Property DivisionStatementState As String
        Public Property DivisionStatementZip As String
        Public Property DivisionStatementCounty As String
        Public Property DivisionStatementCountry As String
        Public Property DivisionContact As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription As String
        Public Property ProductBillingAddress1 As String
        Public Property ProductBillingAddress2 As String
        Public Property ProductBillingCity As String
        Public Property ProductBillingState As String
        Public Property ProductBillingZip As String
        Public Property ProductBillingCounty As String
        Public Property ProductBillingCountry As String
        Public Property ProductStatementAddress1 As String
        Public Property ProductStatementAddress2 As String
        Public Property ProductStatementCity As String
        Public Property ProductStatementState As String
        Public Property ProductStatementZip As String
        Public Property ProductStatementCounty As String
        Public Property ProductStatementCountry As String
        Public Property ProductContact As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF1 As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF2 As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF3 As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF4 As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F0")>
        Public Property ARInvoiceNumber As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceSequence As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceType As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceDate As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceDueDate As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARCoopCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARCoopPercentage As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARManualInvoiceFlag As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceCategory As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARDescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARCollectionNotes As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARType As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TransactionType As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostingPeriod As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesPostingPeriod As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F0")>
        Public Property JobNumber As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReference As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeDescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobAccountExecutiveCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobAccountExecutiveName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F0")>
        Public Property OrderNumber As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderDescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMarket As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaDates As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ABIncomeRecognition As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARHoursQuantity As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AREmployeeTimeAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARIncomeOnlyAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARCommissionAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARRebateAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARAdditionalCharges As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARCostAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARAdvanceCostAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARAdvanceIncomeAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARAdvanceCommissionAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARAdvanceRetained As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARCityTaxAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARCountyTaxAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARStateTaxAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARInvoiceAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CheckNumber As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CheckDate As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CheckDepositDate As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CheckAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CheckAdjustmentAmount As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BalanceAmount As Nullable(Of Decimal)

        Public Property Paid As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F0")>
        Public Property DaysToPay As Nullable(Of Integer)

        Public Property CashReceiptPaymentType As String
        Public Property BankCode As String
        Public Property BankDescription As String
        Public Property IsCleared As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
