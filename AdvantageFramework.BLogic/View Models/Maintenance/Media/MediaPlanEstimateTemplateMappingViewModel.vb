Namespace ViewModels.Maintenance.Media

    Public Class MediaPlanEstimateTemplateMappingViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RepositoryVendors As Generic.List(Of AdvantageFramework.DTO.Vendor)
        Public Property RepositoryMediaTactics As Generic.List(Of AdvantageFramework.DTO.MediaTactic)

        Public Property VendorMappings As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.VendorMapping)
        Public Property TacticMappings As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping)

#End Region

#Region " Methods "

        Public Sub New()

            RepositoryVendors = New Generic.List(Of AdvantageFramework.DTO.Vendor)
            RepositoryMediaTactics = New Generic.List(Of AdvantageFramework.DTO.MediaTactic)

            VendorMappings = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.VendorMapping)
            TacticMappings = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping)

        End Sub

#End Region

    End Class

End Namespace
