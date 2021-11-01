Namespace Database.Entities

    <Table("MEDIA_PLAN_TEMPLATE_DETAIL")>
    Public Class MediaPlanTemplateDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanTemplateHeaderID
            MediaPlanEstimateTemplateID
            Percentage
            SalesClassCode
            PeriodType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_TEMPLATE_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_TEMPLATE_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaPlanTemplateHeaderID() As Integer
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateID() As Integer
        <Required>
        <Column("PERCENTAGE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(5, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property Percentage() As Decimal
        <MaxLength(6)>
        <Column("SC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SalesClassCode() As String
        <Column("PERIOD_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PeriodType() As Nullable(Of Integer)

        <ForeignKey("SalesClassCode")>
        Public Overridable Property SalesClass As Database.Entities.SalesClass
        <ForeignKey("MediaPlanTemplateHeaderID")>
        Public Overridable Property MediaPlanTemplateHeader As Database.Entities.MediaPlanTemplateHeader
        <ForeignKey("MediaPlanEstimateTemplateID")>
        Public Overridable Property MediaPlanEstimateTemplate As Database.Entities.MediaPlanEstimateTemplate

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
