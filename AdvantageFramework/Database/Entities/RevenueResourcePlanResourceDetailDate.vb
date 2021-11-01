Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_RESOURCE_DETAIL_DATE")>
    Public Class RevenueResourcePlanResourceDetailDate
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanResourceDetailID
            [Date]
            Hours
            RevenueResourcePlanResourceDetail
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_RESOURCE_DETAIL_DATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_RESOURCE_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanResourceDetailID() As Integer
        <Required>
        <Column("DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property [Date]() As Date
        <Required>
        <Column("HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(19, 1)>
        Public Property Hours() As Decimal

        Public Overridable Property RevenueResourcePlanResourceDetail As Database.Entities.RevenueResourcePlanResourceDetail

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Date.ToShortDateString

        End Function

#End Region

    End Class

End Namespace
