Namespace ViewModels.Maintenance.Media

    Public Class MediaPlanTemplateSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property SaveEnabled As Boolean
        Public Property DeleteEnabled As Boolean

        Public Property PlanTemplates As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
        Public Property SelectedPlanTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate

        Public ReadOnly Property HasASelectedPlanTemplate As Boolean
            Get
                HasASelectedPlanTemplate = (Me.SelectedPlanTemplate IsNot Nothing)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.SaveEnabled = False
            Me.DeleteEnabled = False

            Me.PlanTemplates = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
            Me.SelectedPlanTemplate = Nothing

        End Sub

#End Region

    End Class

End Namespace
