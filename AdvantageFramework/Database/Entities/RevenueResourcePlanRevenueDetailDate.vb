Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_REVENUE_DETAIL_DATE")>
    Public Class RevenueResourcePlanRevenueDetailDate
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanRevenueDetailID
            [Date]
            Revenue
            RevenueResourcePlanRevenueDetail
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_DETAIL_DATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanRevenueDetailID() As Integer
        <Required>
        <Column("DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property [Date]() As Date
        <Required>
        <Column("REVENUE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(19, 2)>
        Public Property Revenue() As Decimal

        Public Overridable Property RevenueResourcePlanRevenueDetail As Database.Entities.RevenueResourcePlanRevenueDetail

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
