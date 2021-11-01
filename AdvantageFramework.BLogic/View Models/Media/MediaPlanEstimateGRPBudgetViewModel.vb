Namespace ViewModels.Media

    Public Class MediaPlanEstimateGRPBudgetViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaPlanDetailID As Integer
        Public Property MediaPlanDetailGRPBudgets As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)
        Public Property HasSpotLengths As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            MediaPlanDetailGRPBudgets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)
            HasSpotLengths = False

        End Sub

#End Region

    End Class

End Namespace
