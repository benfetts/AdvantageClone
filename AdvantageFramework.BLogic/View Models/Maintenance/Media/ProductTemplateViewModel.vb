Namespace ViewModels.Maintenance.Media

    Public Class ProductTemplateViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum TemplateLevel
            Estimate
            Plan
        End Enum

#End Region

#Region " Variables "

        Private _TemplateLevel As TemplateLevel

#End Region

#Region " Properties "

        Public ReadOnly Property Level As TemplateLevel
            Get
                Level = _TemplateLevel
            End Get
        End Property

        Public ReadOnly Property FormCaption As String
            Get
                FormCaption = If(Me.Level = TemplateLevel.Estimate, "Estimate Level Product Templates", "Media Plan Product Templates")
            End Get
        End Property

        Public Property Products As Generic.List(Of AdvantageFramework.DTO.Product)

        Public Property SelectedProducts As Generic.List(Of AdvantageFramework.DTO.Product)

        Public Property PlanTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
        Public Property PlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)

        Public Property SelectedPlanTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
        Public Property SelectedPlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)

        Public Property ProductPlanTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product)
        Public Property ProductPlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product)

        Public Property SelectedProductPlanTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product)
        Public Property SelectedProductPlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product)

#End Region

#Region " Methods "

        Public Sub New(TemplateLevel As TemplateLevel)

            _TemplateLevel = TemplateLevel

            Me.Products = New Generic.List(Of AdvantageFramework.DTO.Product)
            Me.SelectedProducts = New Generic.List(Of AdvantageFramework.DTO.Product)

            PlanTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
            PlanEstimateTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)

            SelectedPlanTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
            SelectedPlanEstimateTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)

            ProductPlanTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product)
            ProductPlanEstimateTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product)

            SelectedProductPlanTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.Product)
            SelectedProductPlanEstimateTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Product)

        End Sub

#End Region

    End Class

End Namespace
