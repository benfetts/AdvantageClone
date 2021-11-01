Namespace Controller.Maintenance.Media

    Public Class DemographicSetupController
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


#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel

            Dim DemographicSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel = Nothing

            DemographicSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel

            DemographicSetupViewModel.DemoSources = (From MediaDemoSource In [Enum].GetValues(GetType(AdvantageFramework.Database.Entities.MediaDemoSourceID))
                                                     Where MediaDemoSource <> 1 AndAlso
                                                           MediaDemoSource <> 3
                                                     Select New AdvantageFramework.DTO.ComboBoxItem(CType(MediaDemoSource, AdvantageFramework.Database.Entities.MediaDemoSourceID))).ToList

            DemographicSetupViewModel.Type = "T"
            DemographicSetupViewModel.SelectedDemoSource = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen

            RefreshDemos(DemographicSetupViewModel)

            Load = DemographicSetupViewModel

        End Function
        Public Sub RefreshDemos(ByRef DemographicSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel)

            'objects
            Dim Type As String = String.Empty
            Dim MediaDemoSourceID As Integer = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen

            Type = DemographicSetupViewModel.Type
            MediaDemoSourceID = DemographicSetupViewModel.SelectedDemoSource

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DemographicSetupViewModel.MediaDemographics = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel)

                DemographicSetupViewModel.MediaDemographics.AddRange(From MediaDemographic In DbContext.GetQuery(Of Database.Entities.MediaDemographic).Include("MediaDemographicDetails").Where(Function(MD) MD.MediaDemoSourceID = MediaDemoSourceID AndAlso
                                                                                                                                                                                                              MD.Type = Type AndAlso
                                                                                                                                                                                                              MD.IsSystem = False).OrderBy(Function(MD) MD.Code).ToList
                                                                     Select New AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel(MediaDemographic))

                DemographicSetupViewModel.SelectedMediaDemographic = New AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel

            End Using

        End Sub
        Public Sub TypeChanged(ByRef DemographicSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel,
                               Type As String)

            DemographicSetupViewModel.Type = Type

            RefreshDemos(DemographicSetupViewModel)

        End Sub
        Public Sub MediaDemoSourceChanged(ByRef DemographicSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel,
                                          MediaDemoSourceID As Integer)

            DemographicSetupViewModel.SelectedDemoSource = MediaDemoSourceID

            RefreshDemos(DemographicSetupViewModel)

            If MediaDemoSourceID = Database.Entities.Methods.MediaDemoSourceID.Numeris Then


            End If

        End Sub
        Public Sub DemographicSelectionChanged(ByRef DemographicSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel,
                                               SelectedDemographic As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel)

            DemographicSetupViewModel.SelectedMediaDemographic = SelectedDemographic

        End Sub

#End Region

#End Region

    End Class

End Namespace
