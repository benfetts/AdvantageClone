Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_REVENUE_DETAIL")>
    Public Class RevenueResourcePlanRevenueDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanRevenueRevisionID
            RevenueResourcePlanRevenueTypeID
            RevenueResourcePlanRevenueStatusID
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobComponentNumber
            Notes
            RevenueResourcePlanRevenueRevision
            RevenueResourcePlanRevenueType
            RevenueResourcePlanRevenueStatus
            Client
            Division
            Product
            Job
            JobComponent
            RevenueResourcePlanRevenueDetailDates
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_REVISION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanRevenueRevisionID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanRevenueTypeID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_REVENUE_STATUS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanRevenueStatusID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
        <Column("NOTES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String

        Public Overridable Property RevenueResourcePlanRevenueRevision As Database.Entities.RevenueResourcePlanRevenueRevision
        Public Overridable Property RevenueResourcePlanRevenueType As Database.Entities.RevenueResourcePlanRevenueType
        Public Overridable Property RevenueResourcePlanRevenueStatus As Database.Entities.RevenueResourcePlanRevenueStatus
        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property Job As Database.Entities.Job
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property RevenueResourcePlanRevenueDetailDates As ICollection(Of Database.Entities.RevenueResourcePlanRevenueDetailDate)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
