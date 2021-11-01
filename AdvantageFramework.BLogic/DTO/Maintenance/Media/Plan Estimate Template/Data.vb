Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class Data
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanEstimateTemplateID
            MediaPlanEstimateTemplateVendorID
            VendorCode
            VendorName
            SuggestedVendorName
            MediaPlanEstimateTemplateMediaTacticID
            MediaTacticID
            TacticDescription
            SuggestedTacticDescription
            PercentageOrRate
            MediaPlanEstimateTemplateDaypartID
            Daypart
            DaypartPercent
            DaypartDescription
            DaypartID
            MediaPlanEstimateTemplateDemographicID
            Demographic
            MediaDemographicID
            MediaPlanEstimateTemplateMarketID
            Market
            MarketCode
            MediaPlanEstimateTemplateSpotLengthID
            SpotLength
            MediaPlanEstimateTemplateQuarterID
            Quarter
            MediaPlanEstimateTemplateAdSizeID
            AdSize
            AdSizeCode
            MediaPlanEstimateTemplateOutdoorTypeID
            OutOfHomeType
            OutOfHomeTypeCode
            MediaPlanEstimateTemplateRateTypeID
            RateTypeDescription
            RateTypeID
            InternetTypeCode
            InternetTypeName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanEstimateTemplateID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateVendorID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property SuggestedVendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateMediaTacticID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaTacticID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property TacticDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property SuggestedTacticDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property PercentageOrRate() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateDaypartID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Daypart() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property DaypartPercent As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property DaypartDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property DaypartID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateDemographicID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Demographic() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaDemographicID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateMarketID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Market() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateSpotLengthID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property SpotLength() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateQuarterID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Quarter() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateAdSizeID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property AdSize() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property AdSizeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateOutdoorTypeID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property OutOfHomeType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property OutOfHomeTypeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaPlanEstimateTemplateRateTypeID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property RateTypeDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property RateTypeID() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property InternetTypeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property InternetTypeName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
