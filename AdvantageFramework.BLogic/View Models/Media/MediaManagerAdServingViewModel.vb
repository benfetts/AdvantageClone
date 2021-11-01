Namespace ViewModels.Media

    Public Class MediaManagerAdServingViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property CreateAdvertisersEnabled As Boolean
            Get
                If Me.SelectedMediaManagerAdServingDetailViewModelList IsNot Nothing Then

                    CreateAdvertisersEnabled = Me.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.AdServerAdvertiserID.HasValue = False).Any


                Else

                    CreateAdvertisersEnabled = False

                End If
            End Get
        End Property
		Public ReadOnly Property CreateCampaignsEnabled As Boolean
            Get
                If Me.SelectedMediaManagerAdServingDetailViewModelList IsNot Nothing Then

                    CreateCampaignsEnabled = Me.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.AdServerAdvertiserID.HasValue AndAlso
                                                                                                                        Entity.AdServerCampaignID.HasValue = False AndAlso
                                                                                                                        Entity.CampaignID.HasValue AndAlso
                                                                                                                        Entity.CampaignStartDate.HasValue AndAlso
                                                                                                                        Entity.CampaignEndDate.HasValue AndAlso
                                                                                                                        Not String.IsNullOrWhiteSpace(Entity.LandingPageURL) AndAlso
                                                                                                                        Not String.IsNullOrWhiteSpace(Entity.LandingPageName) AndAlso
                                                                                                                        Entity.AdServerPlacementManual = False).Any

                Else

                    CreateCampaignsEnabled = False

                End If
            End Get
        End Property
		Public ReadOnly Property CreatePlacementsEnabled As Boolean
            Get
                If Me.SelectedMediaManagerAdServingDetailViewModelList IsNot Nothing Then

                    CreatePlacementsEnabled = Me.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.CreatePlacementEnabled).Any AndAlso
                            SelectedMediaManagerAdServingDetailViewModelList.Any(Function(Entity) Entity.HasError) = False

                Else

                    CreatePlacementsEnabled = False

                End If
            End Get
        End Property
        Public ReadOnly Property UpdatePlacementsEnabled As Boolean
            Get
                If Me.SelectedMediaManagerAdServingDetailViewModelList IsNot Nothing Then

                    UpdatePlacementsEnabled = Me.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.UpdatePlacementEnabled).Any AndAlso
                            SelectedMediaManagerAdServingDetailViewModelList.Any(Function(Entity) Entity.HasError) = False

                Else

                    UpdatePlacementsEnabled = False

                End If
            End Get
        End Property
        Public ReadOnly Property ClearPlacementsEnabled As Boolean
            Get
                If Me.SelectedMediaManagerAdServingDetailViewModelList IsNot Nothing Then

                    ClearPlacementsEnabled = Me.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.ClearPlacementEnabled).Any

                Else

                    ClearPlacementsEnabled = False

                End If
            End Get
        End Property

        Public Property SelectedMediaManagerAdServingDetailViewModelList As Generic.List(Of AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel)
		Public Property MediaManagerAdServingDetailViewModelList As Generic.List(Of AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel)

		Public ReadOnly Property HasASelectedMediaManagerAdServingDetailViewModel As Boolean
			Get
				HasASelectedMediaManagerAdServingDetailViewModel = (SelectedMediaManagerAdServingDetailViewModelList IsNot Nothing AndAlso SelectedMediaManagerAdServingDetailViewModelList.Count = 1)
			End Get
		End Property

		Public ReadOnly Property SelectedMediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel
			Get
				If Me.HasASelectedMediaManagerAdServingDetailViewModel Then
					SelectedMediaManagerAdServingDetailViewModel = SelectedMediaManagerAdServingDetailViewModelList(0)
				Else
					SelectedMediaManagerAdServingDetailViewModel = Nothing
				End If
			End Get
		End Property

		Public Property AdSizeList As Generic.List(Of AdvantageFramework.Database.Entities.AdSize)
		Public Property InternetTypeList As Generic.List(Of AdvantageFramework.Database.Entities.InternetType)
		Public Property CampaignList As Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

		Public Property DictionaryAdServerAdvertiserID As Dictionary(Of Long, String)
        Public Property DictionaryAdServerSiteID As Dictionary(Of Long, String)
        Public Property AdServerCampaignDataTable As System.Data.DataTable

        Public Property SelectedMediaManagerAdServingDetailAdServerCampaignDataTable As System.Data.DataTable

        Public Property DoubleClickAPIErrorString As String
        Public Property DictionaryAdServerPlacementID As Dictionary(Of Long, Boolean)
        Public Property DictionaryAdServerPlacementIDNames As Dictionary(Of Long, String)

        Public Property AdServerReportID As Long?

        Public Property ReportCriteria As AdvantageFramework.DoubleClick.Classes.ReportCriteria

        Public Property DCProfileID As Long

#End Region

#Region " Methods "

        Public Sub New()

		End Sub

#End Region

	End Class

End Namespace

