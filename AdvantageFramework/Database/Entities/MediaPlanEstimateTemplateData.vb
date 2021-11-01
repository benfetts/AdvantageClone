Namespace Database.Entities

    <Table("MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA")>
    Public Class MediaPlanEstimateTemplateData
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanEstimateTemplateID
            MediaPlanEstimateTemplateVendorID
            MediaPlanEstimateTemplateTacticID
            MediaPlanEstimateTemplateMarketID
            MediaPlanEstimateTemplateDaypartID
            MediaPlanEstimateTemplateSpotLengthID
            MediaPlanEstimateTemplateDemographicID
            MediaPlanEstimateTemplateQuarterID
            MediaPlanEstimateTemplateOutdoorTypeID
            MediaPlanEstimateTemplateAdSizeID
            MediaPlanEstimateTemplateRateTypeID
            InternetTypeCode
            Percentage
            Rate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateID() As Integer
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateVendorID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateTacticID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateMarketID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateDaypartID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateSpotLengthID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateDemographicID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateQuarterID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateOutdoorTypeID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateAdSizeID() As Nullable(Of Integer)
        <Column("MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanEstimateTemplateRateTypeID() As Nullable(Of Integer)
        <Column("INTERNET_TYPE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetTypeCode() As String
        <Required>
        <Column("PERCENTAGE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Percentage() As Decimal
        <Required>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Rate() As Decimal

        <ForeignKey("MediaPlanEstimateTemplateID")>
        Public Overridable Property MediaPlanEstimateTemplate As Database.Entities.MediaPlanEstimateTemplate
        <ForeignKey("MediaPlanEstimateTemplateVendorID")>
        Public Overridable Property MediaPlanEstimateTemplateVendor As Database.Entities.MediaPlanEstimateTemplateVendor
        <ForeignKey("MediaPlanEstimateTemplateTacticID")>
        Public Overridable Property MediaPlanEstimateTemplateTactic As Database.Entities.MediaPlanEstimateTemplateTactic
        <ForeignKey("MediaPlanEstimateTemplateMarketID")>
        Public Overridable Property MediaPlanEstimateTemplateMarket As Database.Entities.MediaPlanEstimateTemplateMarket
        <ForeignKey("MediaPlanEstimateTemplateDaypartID")>
        Public Overridable Property MediaPlanEstimateTemplateDaypart As Database.Entities.MediaPlanEstimateTemplateDaypart
        <ForeignKey("MediaPlanEstimateTemplateSpotLengthID")>
        Public Overridable Property MediaPlanEstimateTemplateSpotLength As Database.Entities.MediaPlanEstimateTemplateSpotLength
        <ForeignKey("MediaPlanEstimateTemplateDemographicID")>
        Public Overridable Property MediaPlanEstimateTemplateDemographic As Database.Entities.MediaPlanEstimateTemplateDemographic
        <ForeignKey("MediaPlanEstimateTemplateQuarterID")>
        Public Overridable Property MediaPlanEstimateTemplateQuarter As Database.Entities.MediaPlanEstimateTemplateQuarter
        <ForeignKey("MediaPlanEstimateTemplateOutdoorTypeID")>
        Public Overridable Property MediaPlanEstimateTemplateOutdoorType As Database.Entities.MediaPlanEstimateTemplateOutdoorType
        <ForeignKey("MediaPlanEstimateTemplateAdSizeID")>
        Public Overridable Property MediaPlanEstimateTemplateAdSize As Database.Entities.MediaPlanEstimateTemplateAdSize
        <ForeignKey("MediaPlanEstimateTemplateRateTypeID")>
        Public Overridable Property MediaPlanEstimateTemplateRateType As Database.Entities.MediaPlanEstimateTemplateRateType
        <ForeignKey("InternetTypeCode")>
        Public Overridable Property InternetType As Database.Entities.InternetType

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
