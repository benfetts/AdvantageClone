Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_RESOURCE")>
    Public Class RevenueResourcePlanResource
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            ClientCode
            EmployeeCode
            Notes
            RevenueResourcePlan
            Client
            RevenueResourcePlanResourceRevisions
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_RESOURCE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeCode() As String
        <Column("NOTES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String

        Public Overridable Property RevenueResourcePlan As Database.Entities.RevenueResourcePlan
        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property RevenueResourcePlanResourceRevisions As ICollection(Of Database.Entities.RevenueResourcePlanResourceRevision)
        Public Overridable Property Employee As Database.Views.Employee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
