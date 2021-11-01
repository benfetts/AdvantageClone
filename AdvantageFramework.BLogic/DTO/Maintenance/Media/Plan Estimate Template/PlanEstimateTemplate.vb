Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class PlanEstimateTemplate
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Type
            MediaTypeDescription
            Description
            Goals
            IsInactive
            IsSystem
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaPlanEstimateTemplateMediaType)>
        Public Property Type() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Media Type")>
        Public Property MediaTypeDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Goals() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSystem() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsMissingMappings As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasAdSizes() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasDayparts() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasDemographics() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasMarkets() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasOutdoorTypes() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasQuarters() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasSpotLengths() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasTactics() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasVendors() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasRateTypes() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasDatas() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Type = String.Empty
            Me.Description = String.Empty
            Me.Goals = String.Empty
            Me.IsInactive = False
            Me.IsSystem = False
            Me.MediaTypeDescription = String.Empty
            Me.IsMissingMappings = False

        End Sub
        Public Sub New(MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)

            Me.ID = MediaPlanEstimateTemplate.ID
            Me.Type = MediaPlanEstimateTemplate.Type
            Me.Description = MediaPlanEstimateTemplate.Description
            Me.Goals = MediaPlanEstimateTemplate.Goals
            Me.IsInactive = MediaPlanEstimateTemplate.IsInactive
            Me.IsSystem = MediaPlanEstimateTemplate.IsSystem

            Me.HasAdSizes = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes.Count > 0
            Me.HasDayparts = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts.Count > 0
            Me.HasDemographics = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDemographics IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDemographics.Count > 0
            Me.HasMarkets = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets.Count > 0
            Me.HasOutdoorTypes = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes.Count > 0
            Me.HasQuarters = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateQuarters IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateQuarters.Count > 0
            Me.HasSpotLengths = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths.Count > 0
            Me.HasTactics = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics.Count > 0
            Me.HasVendors = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0
            Me.HasRateTypes = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateRateTypes IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateRateTypes.Count > 0
            Me.HasDatas = MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDatas IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDatas.Count > 0

            Select Case Me.Type
                Case "I"
                    Me.MediaTypeDescription = "Internet"
                Case "M"
                    Me.MediaTypeDescription = "Magazine"
                Case "N"
                    Me.MediaTypeDescription = "Newspaper"
                Case "O"
                    Me.MediaTypeDescription = "Out of Home"
                Case "R"
                    Me.MediaTypeDescription = "Radio"
                Case "T"
                    Me.MediaTypeDescription = "Television"
            End Select

        End Sub
        Public Sub SaveToEntity(MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)

            MediaPlanEstimateTemplate.Type = Me.Type
            MediaPlanEstimateTemplate.Description = Me.Description
            MediaPlanEstimateTemplate.Goals = Me.Goals
            MediaPlanEstimateTemplate.IsInactive = Me.IsInactive
            MediaPlanEstimateTemplate.IsSystem = Me.IsSystem

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
