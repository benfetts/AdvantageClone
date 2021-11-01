Namespace ViewModels.Maintenance.Media

    Public Class DemographicSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaDemographics As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel)
        Public Property SelectedMediaDemographic As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel
        Public Property Type As String
        Public Property DemoSources As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property SelectedDemoSource As AdvantageFramework.Database.Entities.MediaDemoSourceID

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaDemographics = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel)
            Me.SelectedMediaDemographic = Nothing
            Me.Type = "T"
            Me.DemoSources = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.SelectedDemoSource = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen

        End Sub

#End Region

    End Class

End Namespace

