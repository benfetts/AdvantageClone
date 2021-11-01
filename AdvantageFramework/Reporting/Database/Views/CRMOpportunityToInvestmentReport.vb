Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_CRM_OPPORTUNITY_TO_INVESTMENT")>
    Public Class CRMOpportunityToInvestmentReport
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
            LastActivityDate
            LastContactDate
            Probability
            RatingDescription
            TotalFeeRetainer
            TotalFeeHours
            TotalFeeIncentiveBonus
            TotalFeeRoyalty
            TotalProjectHourlyTotal
            TotalProjectHours
            TotalMediaCommission
            TotalProductionCommission
            TotalOpportunityValue
            TotalMonthlyValue
            TotalInvestment
            RecoupMonths
            ContractEndDate
            DefaultAECode
            DefaultAEName
            SoldDate
            LostDate

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
        <Column("LastActivityDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastActivityDate() As Nullable(Of Date)
        <Column("LastContactDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastContactDate() As Nullable(Of Date)
        <Column("Probability")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Probability() As Nullable(Of Byte)
        <MaxLength(100)>
        <Column("RatingDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RatingDescription() As String
        <Column("TotalFeeRetainer")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalFeeRetainer() As Nullable(Of Decimal)
        <Column("TotalFeeHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalFeeHours() As Nullable(Of Decimal)
        <Column("TotalFeeIncentiveBonus")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalFeeIncentiveBonus() As Nullable(Of Decimal)
        <Column("TotalFeeRoyalty")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalFeeRoyalty() As Nullable(Of Decimal)
        <Column("TotalProjectHourlyTotal")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalProjectHourlyTotal() As Nullable(Of Decimal)
        <Column("TotalProjectHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalProjectHours() As Nullable(Of Decimal)
        <Column("TotalMediaCommission")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalMediaCommission() As Nullable(Of Decimal)
        <Column("TotalProductionCommission")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalProductionCommission() As Nullable(Of Decimal)
        <Column("TotalOpportunityValue")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalOpportunityValue() As Nullable(Of Decimal)
        <Column("TotalMonthlyValue")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalMonthlyValue() As Nullable(Of Decimal)
        <Column("TotalInvestment")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalInvestment() As Nullable(Of Decimal)
        <Column("RecoupMonths")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RecoupMonths() As Nullable(Of Decimal)
        <Column("ContractEndDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContractEndDate() As Nullable(Of Date)
        <MaxLength(6)>
        <Column("DefaultAECode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAECode() As String
        <MaxLength(64)>
        <Column("DefaultAEName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAEName() As String
        <Column("SoldDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SoldDate() As Nullable(Of Date)
        <Column("LostDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LostDate() As Nullable(Of Date)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
