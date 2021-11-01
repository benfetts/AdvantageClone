Namespace ViewModels.Media.DigitalCampaignManager

    Public Class ViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IncludeInternet As Boolean
        Public Property IncludeMagazine As Boolean
        Public Property IncludeNewspaper As Boolean
        Public Property IncludeOutOfHome As Boolean
        'Public Property IncludeRadio As Boolean
        'Public Property IncludeTV As Boolean

        Public Property OpenPlanEstimates As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)
        Public Property OpenPlanEstimateGridLayout As AdvantageFramework.DTO.GridAdvantage
        Public Property IsAgencyASP As Boolean
        Public Property HostedPath As String

        Public Property DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)
        Public Property EstimateDetailByFlightGridLayout As AdvantageFramework.DTO.GridAdvantage
        Public Property EstimateDetailByPeriodGridLayout As AdvantageFramework.DTO.GridAdvantage

        Public Property CDPDescription As String

        Public Property MediaPlanActualizeDialogText As String
        Public Property AllowActualizationToVaryFromLastPlan As Boolean

        Public Property RepositoryCostTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()

            Me.OpenPlanEstimates = New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)
            Me.OpenPlanEstimateGridLayout = Nothing

            Me.DigitalEstimateDetails = New Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)
            Me.EstimateDetailByFlightGridLayout = Nothing
            Me.EstimateDetailByPeriodGridLayout = Nothing

            Me.CDPDescription = String.Empty
            Me.MediaPlanActualizeDialogText = String.Empty
            Me.AllowActualizationToVaryFromLastPlan = False

            Me.RepositoryCostTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            Me.RepositoryCostTypes.Add(New AdvantageFramework.DTO.ComboBoxItem("CPI", "CPI"))
            Me.RepositoryCostTypes.Add(New AdvantageFramework.DTO.ComboBoxItem("CPC", "CPC"))
            Me.RepositoryCostTypes.Add(New AdvantageFramework.DTO.ComboBoxItem("CPA", "CPA"))
            Me.RepositoryCostTypes.Add(New AdvantageFramework.DTO.ComboBoxItem("NA", "NA"))

        End Sub

#End Region

    End Class

End Namespace
