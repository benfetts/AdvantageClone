Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_CLIENTS")>
    Public Class ClientReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            Address
            Address2
            City
            County
            State
            Zip
            Country
            NewBusiness
            SortName
            BillingAddress
            BillingAddress2
            BillingCity
            BillingCounty
            BillingState
            BillingZip
            BillingCountry
            StatementAddress
            StatementAddress2
            StatementCity
            StatementCounty
            StatementState
            StatementZip
            StatementCountry
            FiscalStart
            CreditLimit
            ARComment
            AssignProductionInvoicesBy
            ProductionInvoiceType
            ProductionInvoiceFormat
            ProductionAttentionLine
            ProductionFooterComments
            ProductionDaysToPay
            AssignMediaInvoicesBy
            MediaAttentionLine
            MediaFooterComments
            MediaDaysToPay
            MagazineInvoiceType
            MagazineInvoiceFormat
            NewspaperInvoiceType
            NewspaperInvoiceFormat
            InternetInvoiceType
            InternetInvoiceFormat
            OutOfHomeInvoiceType
            OutOfHomeInvoiceFormat
            RadioInvoiceType
            RadioInvoiceFormat
            TelevisionInvoiceType
            TelevisionInvoiceFormat
            OverrideAgencySettings
            AccountNumberRequired
            AdNumberRequired
            AlertGroupRequired
            Blackplate1Required
            Blackplate2Required
            ComponentBudgetRequired
            ClientReferenceRequired
            ComplexityCodeRequired
            ProductContactRequired
            CoopBillingCodeRequired
            DateOpenedRequired
            DepartmentCodeRequired
            DueDateRequired
            FormatRequired
            JobTypeRequired
            MarketCodeRequired
            PromotionRequired
            SCFormatRequired
            ServiceFeeTypeRequired
            TaxFlagRequired
            JobLogCustom1
            JobLogCustom2
            JobLogCustom3
            JobLogCustom4
            JobLogCustom5
            JobCustomComponent1Required
            JobCustomComponent2Required
            JobCustomComponent3Required
            JobCustomComponent4Required
            JobCustomComponent5Required
            CampaignCodeRequired
            FiscalPeriodRequired
            ProductCategoryInTimesheetRequired
            RequireTimeComment
            IsActive
            ClientDiscountCode
            ClientDiscountDescription
            Biller
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Required>
        <MaxLength(6)>
        <Column("ClientCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <Column("ClientName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
        <MaxLength(40)>
        <Column("Address", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address() As String
        <MaxLength(40)>
        <Column("Address2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address2() As String
        <MaxLength(30)>
        <Column("City", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property City() As String
        <MaxLength(20)>
        <Column("County", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property County() As String
        <MaxLength(10)>
        <Column("State", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
        <MaxLength(10)>
        <Column("Zip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Zip() As String
        <MaxLength(20)>
        <Column("Country", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Country() As String
        <Required>
        <MaxLength(1)>
        <Column("NewBusiness", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewBusiness() As String
        <MaxLength(20)>
        <Column("SortName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortName() As String
        <MaxLength(40)>
        <Column("BillingAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress() As String
        <MaxLength(40)>
        <Column("BillingAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingAddress2() As String
        <MaxLength(30)>
        <Column("BillingCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCity() As String
        <MaxLength(20)>
        <Column("BillingCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCounty() As String
        <MaxLength(10)>
        <Column("BillingState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingState() As String
        <MaxLength(10)>
        <Column("BillingZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingZip() As String
        <MaxLength(20)>
        <Column("BillingCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCountry() As String
        <MaxLength(40)>
        <Column("StatementAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementAddress() As String
        <MaxLength(40)>
        <Column("StatementAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementAddress2() As String
        <MaxLength(30)>
        <Column("StatementCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCity() As String
        <MaxLength(20)>
        <Column("StatementCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCounty() As String
        <MaxLength(10)>
        <Column("StatementState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementState() As String
        <MaxLength(10)>
        <Column("StatementZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementZip() As String
        <MaxLength(20)>
        <Column("StatementCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatementCountry() As String
        <MaxLength(9)>
        <Column("FiscalStart", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalStart() As String
        <Column("CreditLimit")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreditLimit() As Nullable(Of Decimal)
		<Column("ARComment")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARComment() As String
        <MaxLength(21)>
        <Column("AssignProductionInvoicesBy", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignProductionInvoicesBy() As String
        <Required>
        <MaxLength(14)>
        <Column("ProductionInvoiceType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionInvoiceType() As String
        <MaxLength(100)>
        <Column("ProductionInvoiceFormat", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionInvoiceFormat() As String
        <MaxLength(40)>
        <Column("ProductionAttentionLine", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionAttentionLine() As String
        <MaxLength(60)>
        <Column("ProductionFooterComments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionFooterComments() As String
        <Column("ProductionDaysToPay")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionDaysToPay() As Nullable(Of Short)
        <MaxLength(11)>
        <Column("AssignMediaInvoicesBy", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignMediaInvoicesBy() As String
        <MaxLength(40)>
        <Column("MediaAttentionLine", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaAttentionLine() As String
        <MaxLength(60)>
        <Column("MediaFooterComments", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaFooterComments() As String
        <Column("MediaDaysToPay")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaDaysToPay() As Nullable(Of Short)
        <Required>
        <MaxLength(14)>
        <Column("MagazineInvoiceType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineInvoiceType() As String
        <MaxLength(100)>
        <Column("MagazineInvoiceFormat", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MagazineInvoiceFormat() As String
        <Required>
        <MaxLength(14)>
        <Column("NewspaperInvoiceType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperInvoiceType() As String
        <MaxLength(100)>
        <Column("NewspaperInvoiceFormat", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewspaperInvoiceFormat() As String
        <Required>
        <MaxLength(14)>
        <Column("InternetInvoiceType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetInvoiceType() As String
        <MaxLength(100)>
        <Column("InternetInvoiceFormat", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetInvoiceFormat() As String
        <Required>
        <MaxLength(14)>
        <Column("OutOfHomeInvoiceType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeInvoiceType() As String
        <MaxLength(100)>
        <Column("OutOfHomeInvoiceFormat", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeInvoiceFormat() As String
        <Required>
        <MaxLength(14)>
        <Column("RadioInvoiceType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioInvoiceType() As String
        <MaxLength(100)>
        <Column("RadioInvoiceFormat", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioInvoiceFormat() As String
        <Required>
        <MaxLength(14)>
        <Column("TelevisionInvoiceType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionInvoiceType() As String
        <MaxLength(100)>
        <Column("TelevisionInvoiceFormat", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TelevisionInvoiceFormat() As String
        <Required>
        <MaxLength(1)>
        <Column("OverrideAgencySettings", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OverrideAgencySettings() As String
        <Required>
        <MaxLength(1)>
        <Column("AccountNumberRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumberRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("AdNumberRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumberRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("AlertGroupRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertGroupRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("Blackplate1Required", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Blackplate1Required() As String
        <Required>
        <MaxLength(1)>
        <Column("Blackplate2Required", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Blackplate2Required() As String
        <Required>
        <MaxLength(1)>
        <Column("ComponentBudgetRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentBudgetRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("ClientReferenceRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReferenceRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("ComplexityCodeRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComplexityCodeRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("ProductContactRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductContactRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("CoopBillingCodeRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CoopBillingCodeRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("DateOpenedRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateOpenedRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("DepartmentCodeRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentCodeRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("DueDateRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDateRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("FormatRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FormatRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("JobTypeRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("MarketCodeRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCodeRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("PromotionRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PromotionRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("SCFormatRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SCFormatRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("ServiceFeeTypeRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceFeeTypeRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("TaxFlagRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxFlagRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("JobLogCustom1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobLogCustom1() As String
        <Required>
        <MaxLength(1)>
        <Column("JobLogCustom2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobLogCustom2() As String
        <Required>
        <MaxLength(1)>
        <Column("JobLogCustom3", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobLogCustom3() As String
        <Required>
        <MaxLength(1)>
        <Column("JobLogCustom4", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobLogCustom4() As String
        <Required>
        <MaxLength(1)>
        <Column("JobLogCustom5", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobLogCustom5() As String
        <Required>
        <MaxLength(1)>
        <Column("JobCustomComponent1Required", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCustomComponent1Required() As String
        <Required>
        <MaxLength(1)>
        <Column("JobCustomComponent2Required", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCustomComponent2Required() As String
        <Required>
        <MaxLength(1)>
        <Column("JobCustomComponent3Required", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCustomComponent3Required() As String
        <Required>
        <MaxLength(1)>
        <Column("JobCustomComponent4Required", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCustomComponent4Required() As String
        <Required>
        <MaxLength(1)>
        <Column("JobCustomComponent5Required", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCustomComponent5Required() As String
        <Required>
        <MaxLength(1)>
        <Column("CampaignCodeRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCodeRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("FiscalPeriodRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalPeriodRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("ProductCategoryInTimesheetRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCategoryInTimesheetRequired() As String
        <Required>
        <MaxLength(1)>
        <Column("RequireTimeComment", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RequireTimeComment() As String
        <Required>
        <MaxLength(1)>
        <Column("IsActive", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActive() As String
        <MaxLength(6)>
        <Column("ClientDiscountCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDiscountCode() As String
        <MaxLength(100)>
        <Column("ClientDiscountDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDiscountDescription() As String
        <MaxLength(100)>
        <Column("Biller", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Biller() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
