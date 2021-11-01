Namespace Controller.Maintenance.Media

    Public Class MediaPlanTemplateSetupController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel

            'objects
            Dim MediaPlanTemplateSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel = Nothing

            MediaPlanTemplateSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel

            LoadMediaPlanTemplates(MediaPlanTemplateSetupViewModel)

            Load = MediaPlanTemplateSetupViewModel

        End Function
        Public Sub LoadMediaPlanTemplates(ByRef MediaPlanTemplateSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaPlanTemplateSetupViewModel.PlanTemplates = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate(Entity)).ToList

            End Using

        End Sub
        Public Sub SelectedDiscountChanged(ByRef MediaPlanTemplateSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel,
                                           PlanTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)

            MediaPlanTemplateSetupViewModel.SelectedPlanTemplate = PlanTemplate

            MediaPlanTemplateSetupViewModel.DeleteEnabled = MediaPlanTemplateSetupViewModel.HasASelectedPlanTemplate

        End Sub
        Public Sub UserEntryChanged(ByRef MediaPlanTemplateSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel)

            MediaPlanTemplateSetupViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef MediaPlanTemplateSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateSetupViewModel)

            MediaPlanTemplateSetupViewModel.SaveEnabled = False

        End Sub

#End Region

    End Class

End Namespace
