Namespace ViewModels.Maintenance.Media

    Public Class PlanEstimateTemplateViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RateEntryEnabled As Boolean
        Public Property PercentEntryEnabled As Boolean
        Public Property HasPercentsDefined As Boolean

        Public Property SelectedPlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate

        Public Property RepositoryMediaTypes As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

        Public Property PlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)
        Public Property Tactics As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic)
        Public Property Vendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor)
        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market)
        Public Property Dayparts As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart)
        Public Property SpotLengths As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength)
        Public Property Demographics As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic)
        Public Property Quarters As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter)
        Public Property OutdoorTypes As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType)
        Public Property AdSizes As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize)
        Public Property RateTypes As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType)

#End Region

#Region " Methods "

        Public Sub New()

            Me.RateEntryEnabled = False
            Me.PercentEntryEnabled = False
            Me.HasPercentsDefined = False

            Me.SelectedPlanEstimateTemplate = Nothing

            RepositoryMediaTypes = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            PlanEstimateTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)
            Tactics = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic)
            Vendors = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor)
            Markets = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market)
            Dayparts = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart)
            SpotLengths = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength)
            Demographics = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic)
            Quarters = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter)
            OutdoorTypes = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType)
            AdSizes = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize)
            RateTypes = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType)

        End Sub

#End Region

    End Class

End Namespace
