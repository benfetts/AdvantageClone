Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_RESOURCE_DETAIL")>
    Public Class RevenueResourcePlanResourceDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanResourceRevisionID
            RevenueResourcePlanStaffID
            Notes
            RevenueResourcePlanResourceRevision
            RevenueResourcePlanStaff
            RevenueResourcePlanResourceDetailDates
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_RESOURCE_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_RESOURCE_REVISION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanResourceRevisionID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_STAFF_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanStaffID() As Integer
        <Column("NOTES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String

        Public Overridable Property RevenueResourcePlanResourceRevision As Database.Entities.RevenueResourcePlanResourceRevision
        Public Overridable Property RevenueResourcePlanStaff As Database.Entities.RevenueResourcePlanStaff
        Public Overridable Property RevenueResourcePlanResourceDetailDates As ICollection(Of Database.Entities.RevenueResourcePlanResourceDetailDate)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
