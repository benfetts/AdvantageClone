Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_CRM_CLIENT_CONTRACTS")>
    Public Class CRMClientContractsReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            NewBusiness
            Code
            Description
            ContractStartDate
            ContractEndDate
            BlendedBillingRate
            FeeRetainer
            FeeHours
            FeeIncentiveBonus
            FeeRoyalty
            ProjectHourlyTotal
            ProjectHours
            MediaCommission
            ProductionCommission
            TotalValue
            MonthlyValue
            MonthlyHours
            ReportingRequirements
            ValueAdded
            DefaultAECode
            DefaultAEName
            ValueAddedAmountTotal
            Industry
            Specialty
            RegionCode
            Region
            Revenue
            NumberOfEmployees
            CaseStudyDone
            UseAsReference
            TurnoverPercent
            ClientType1Code
            ClientType1Description
            ClientType2Code
            ClientType2Description
            ClientType3Code
            ClientType3Description
            Notes

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
        <MaxLength(6)>
        <Column("DivisionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <Column("DivisionName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
        <MaxLength(6)>
        <Column("ProductCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <Column("ProductName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductName() As String
        <Required>
        <MaxLength(1)>
        <Column("NewBusiness", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewBusiness() As String
        <Required>
        <MaxLength(6)>
        <Column("Code", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String
        <MaxLength(100)>
        <Column("Description", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Column("ContractStartDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractStartDate() As Nullable(Of Date)
        <Column("ContractEndDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractEndDate() As Nullable(Of Date)
        <Column("BlendedBillingRate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BlendedBillingRate() As Nullable(Of Decimal)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("FeeRetainer")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeRetainer() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(38, 2)>
        <Column("FeeHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeHours() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("FeeIncentiveBonus")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeIncentiveBonus() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("FeeRoyalty")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeRoyalty() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("ProjectHourlyTotal")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectHourlyTotal() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("ProjectHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectHours() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("MediaCommission")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaCommission() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("ProductionCommission")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductionCommission() As Decimal
        <Column("TotalValue")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalValue() As Nullable(Of Decimal)
        <Column("MonthlyValue")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthlyValue() As Nullable(Of Decimal)
        <Column("MonthlyHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthlyHours() As Nullable(Of Decimal)
        <Required>
        <MaxLength(1)>
        <Column("ReportingRequirements", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReportingRequirements() As String
        <Required>
        <MaxLength(1)>
        <Column("ValueAdded", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ValueAdded() As String
        <MaxLength(6)>
        <Column("DefaultAECode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAECode() As String
        <MaxLength(64)>
        <Column("DefaultAEName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAEName() As String
        <Column("ValueAddedAmountTotal")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ValueAddedAmountTotal() As Nullable(Of Decimal)


        <MaxLength(100)>
        <Column("Industry")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Industry() As String

        <MaxLength(100)>
        <Column("Specialty")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Specialty() As String

        <MaxLength(100)>
        <Column("RegionCode")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RegionCode() As String

        <MaxLength(100)>
        <Column("Region")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Region() As String

        <Column("Revenue")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Revenue() As Nullable(Of Decimal)

        <Column("NumberOfEmployees")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NumberOfEmployees() As Nullable(Of Integer)

        <MaxLength(1)>
        <Column("CaseStudyDone")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CaseStudyDone() As String

        <MaxLength(1)>
        <Column("UseAsReference")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseAsReference() As String

        <Column("TurnoverPercent")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TurnoverPercent() As Nullable(Of Decimal)

        <Column("ClientType1Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Code")>
        Public Property ClientType1Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType1Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Description")>
        Public Property ClientType1Description() As String

        <Column("ClientType2Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Code")>
        Public Property ClientType2Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType2Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Description")>
        Public Property ClientType2Description() As String

        <Column("ClientType3Code")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Code")>
        Public Property ClientType3Code() As Nullable(Of Integer)

        <MaxLength(100)>
        <Column("ClientType3Description")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Description")>
        Public Property ClientType3Description() As String

        <Column("Notes")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Notes() As String



#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
