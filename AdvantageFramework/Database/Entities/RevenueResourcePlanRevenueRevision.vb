Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_REVENUE_REVISION")>
    Public Class RevenueResourcePlanRevenueRevision
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanRevenueID
            RevisionNumber
            Approved
            ApprovedByEmployeeCode
            ApprovedDate
            Notes
            RevenueResourcePlanRevenue
            ApprovedByEmployee
            RevenueResourcePlanRevenueDetails
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_REVISION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanRevenueID() As Integer
        <Required>
        <Column("REVISION_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevisionNumber() As Integer
        <Required>
        <Column("APPROVED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Approved() As Boolean
        <MaxLength(6)>
        <Column("APPROVED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ApprovedByEmployeeCode() As String
        <Column("APPROVED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ApprovedDate() As Nullable(Of Date)
        <Column("NOTES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String

        Public Overridable Property RevenueResourcePlanRevenue As Database.Entities.RevenueResourcePlanRevenue
        <ForeignKey("ApprovedByEmployeeCode")>
        Public Overridable Property ApprovedByEmployee As Database.Views.Employee
        Public Overridable Property RevenueResourcePlanRevenueDetails As ICollection(Of Database.Entities.RevenueResourcePlanRevenueDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
