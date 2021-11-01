Namespace Database.Entities

    <Table("MEDIA_PLAN_ESTIMATE_TEMPLATE")>
    Public Class MediaPlanEstimateTemplate
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Type
            Description
            Goals
            IsInactive
            IsSystem
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(1)>
        <Column("TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Type() As String
        <Required>
        <MaxLength(100)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <MaxLength(250)>
        <Column("GOALS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Goals() As String
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
        <Required>
        <Column("IS_SYSTEM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsSystem As Boolean

        Public Overridable Property MediaPlanEstimateTemplateAdSizes As ICollection(Of Database.Entities.MediaPlanEstimateTemplateAdSize)
        Public Overridable Property MediaPlanEstimateTemplateDatas As ICollection(Of Database.Entities.MediaPlanEstimateTemplateData)
        Public Overridable Property MediaPlanEstimateTemplateDayparts As ICollection(Of Database.Entities.MediaPlanEstimateTemplateDaypart)
        Public Overridable Property MediaPlanEstimateTemplateDemographics As ICollection(Of Database.Entities.MediaPlanEstimateTemplateDemographic)
        Public Overridable Property MediaPlanEstimateTemplateMarkets As ICollection(Of Database.Entities.MediaPlanEstimateTemplateMarket)
        Public Overridable Property MediaPlanEstimateTemplateOutdoorTypes As ICollection(Of Database.Entities.MediaPlanEstimateTemplateOutdoorType)
        Public Overridable Property MediaPlanEstimateTemplateQuarters As ICollection(Of Database.Entities.MediaPlanEstimateTemplateQuarter)
        Public Overridable Property MediaPlanEstimateTemplateRateTypes As ICollection(Of Database.Entities.MediaPlanEstimateTemplateRateType)
        Public Overridable Property MediaPlanEstimateTemplateSpotLengths As ICollection(Of Database.Entities.MediaPlanEstimateTemplateSpotLength)
        Public Overridable Property MediaPlanEstimateTemplateTactics As ICollection(Of Database.Entities.MediaPlanEstimateTemplateTactic)
        Public Overridable Property MediaPlanEstimateTemplateVendors As ICollection(Of Database.Entities.MediaPlanEstimateTemplateVendor)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
