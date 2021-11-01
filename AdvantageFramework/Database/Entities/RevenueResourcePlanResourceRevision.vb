Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_RESOURCE_REVISION")>
    Public Class RevenueResourcePlanResourceRevision
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanResourceID
            RevisionNumber
            Approved
            ApprovedByEmployeeCode
            ApprovedDate
            Notes
            RevenueResourcePlanResource
            ApprovedByEmployee
            RevenueResourcePlanResourceDetails
        End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_RESOURCE_REVISION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_RESOURCE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanResourceID() As Integer
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

        Public Overridable Property RevenueResourcePlanResource As Database.Entities.RevenueResourcePlanResource
        <ForeignKey("ApprovedByEmployeeCode")>
        Public Overridable Property ApprovedByEmployee As Database.Views.Employee
        Public Overridable Property RevenueResourcePlanResourceDetails As ICollection(Of Database.Entities.RevenueResourcePlanResourceDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
