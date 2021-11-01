Namespace ViewModels.Maintenance.Media

    Public Class MediaPlanTemplateViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property UpdateEnabled As Boolean
        Public Property DeleteEnabled As Boolean

        Public Property PlanEstimateTemplates_IsNewRow As Boolean
        Public Property PlanEstimateTemplates_DeleteEnabled As Boolean
        Public Property PlanEstimateTemplates_CancelEnabled As Boolean

        Public Property PlanTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate
        Public Property TemplateDetails As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)
        Public Property SelectedTemplateDetails As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)

        Public ReadOnly Property HasASelectedPlanEstimateTemplate As Boolean
            Get
                HasASelectedPlanEstimateTemplate = (Me.SelectedTemplateDetails IsNot Nothing AndAlso Me.SelectedTemplateDetails.Count > 0)
            End Get
        End Property

        Public Property RepositoryPlanEstimateTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)
        Public Property RepositorySalesClasses As Generic.List(Of AdvantageFramework.DTO.SalesClass)
        Public Property RepositoryPeriodTypes As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = False
            Me.UpdateEnabled = False
            Me.DeleteEnabled = False

            Me.PlanEstimateTemplates_IsNewRow = False
            Me.PlanEstimateTemplates_DeleteEnabled = False
            Me.PlanEstimateTemplates_CancelEnabled = False

            Me.PlanTemplate = Nothing
            Me.TemplateDetails = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)
            Me.SelectedTemplateDetails = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)

            Me.RepositoryPlanEstimateTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)
            Me.RepositorySalesClasses = New Generic.List(Of AdvantageFramework.DTO.SalesClass)
            Me.RepositoryPeriodTypes = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

        End Sub

#End Region

    End Class

End Namespace
