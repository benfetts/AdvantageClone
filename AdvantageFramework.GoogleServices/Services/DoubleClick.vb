Namespace Services

    Public Class DoubleClick
        Inherits Base.ServiceBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Shared ReadOnly Property Scope As IEnumerable(Of String)
            Get
                Return {Google.Apis.Dfareporting.v3_5.DfareportingService.Scope.Dfatrafficking, Google.Apis.Dfareporting.v3_5.DfareportingService.Scope.Dfareporting}
            End Get
        End Property

#End Region

#Region " Methods "

#Region "  -- Authorization -- "

        Private Function IsServiceAuthorized(DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService, ProfileID As Long) As Boolean

            'objects
            Dim IsAuthorized As Boolean = False
            Dim UserProfile As Google.Apis.Dfareporting.v3_5.Data.UserProfile = Nothing

            Try

                UserProfile = DfareportingService.UserProfiles.Get(ProfileID).Execute() 'call errors if not authorized

                IsAuthorized = True

            Catch ex As Exception
                IsAuthorized = False
            Finally
                IsServiceAuthorized = IsAuthorized
            End Try

        End Function
        Private Function LoadService(ProfileID As Long, DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                     ByRef ErrorMessage As String) As Google.Apis.Dfareporting.v3_5.DfareportingService

            'objects
            Dim Initializer As Google.Apis.Services.BaseClientService.Initializer = Nothing
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim IsAuthorized As Boolean = False

            Try

                Initializer = CreateInitializerDoubleClick(ProfileID, DataContext, ErrorMessage)

                If Initializer IsNot Nothing Then

                    DfareportingService = New Google.Apis.Dfareporting.v3_5.DfareportingService(Initializer)

                    IsAuthorized = IsServiceAuthorized(DfareportingService, ProfileID)

                End If

                If IsAuthorized = False AndAlso String.IsNullOrWhiteSpace(ErrorMessage) Then

                    ErrorMessage = "Advantage is not authorized to access your DoubleClick account."

                End If

            Catch ex As Exception
                If String.IsNullOrWhiteSpace(ErrorMessage) Then
                    ErrorMessage = "Could not access DoubleClick. Please contact software support."
                End If
                DfareportingService = Nothing
            Finally
                LoadService = DfareportingService
            End Try

        End Function

#End Region

        Private Function CampaignUpdate(ProfileID As Long, DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService,
                                        AdServerCampaignID As Long, CampaignName As String, StartDate As Date, EndDate As Date,
                                        ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Campaign As Google.Apis.Dfareporting.v3_5.Data.Campaign = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.Campaign = Nothing
            Dim Updated As Boolean = False

            Try

                Campaign = DfareportingService.Campaigns.Get(ProfileID, AdServerCampaignID).Execute

                If Campaign IsNot Nothing Then

                    Campaign.Name = CampaignName
                    Campaign.Archived = False
                    Campaign.StartDate = StartDate.ToString("yyyy-MM-dd")
                    Campaign.EndDate = EndDate.ToString("yyyy-MM-dd")

                    Result = DfareportingService.Campaigns.Update(Campaign, ProfileID).Execute

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                CampaignUpdate = Updated
            End Try

        End Function
        Private Sub GetAdvertisers(ProfileID As Long, DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService,
                                   ByRef DictionaryAdvertisers As Dictionary(Of Long, String))

            Dim ListRequest As Google.Apis.Dfareporting.v3_5.AdvertisersResource.ListRequest = Nothing
            Dim NextPageToken As String = Nothing
            Dim AdvertisersListResponse As Google.Apis.Dfareporting.v3_5.Data.AdvertisersListResponse = Nothing

            DictionaryAdvertisers = New Dictionary(Of Long, String)

            Do

                ListRequest = DfareportingService.Advertisers.List(ProfileID)
                ListRequest.Status = Google.Apis.Dfareporting.v3_5.AdvertisersResource.ListRequest.StatusEnum.APPROVED
                ListRequest.PageToken = NextPageToken

                AdvertisersListResponse = ListRequest.Execute

                For Each Advertiser In AdvertisersListResponse.Advertisers

                    DictionaryAdvertisers.Add(Advertiser.Id.Value, Advertiser.Name)

                Next

                NextPageToken = AdvertisersListResponse.NextPageToken

            Loop While AdvertisersListResponse.Advertisers.Any AndAlso Not String.IsNullOrWhiteSpace(NextPageToken)

        End Sub
        Private Sub GetCampaigns(ProfileID As Long, DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService,
                                 ByRef DataTable As System.Data.DataTable)

            Dim ListRequest As Google.Apis.Dfareporting.v3_5.CampaignsResource.ListRequest = Nothing
            Dim NextPageToken As String = Nothing
            Dim CampaignsListResponse As Google.Apis.Dfareporting.v3_5.Data.CampaignsListResponse = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            Do

                ListRequest = DfareportingService.Campaigns.List(ProfileID)
                ListRequest.Archived = False
                ListRequest.PageToken = NextPageToken

                CampaignsListResponse = ListRequest.Execute

                For Each Campaign In CampaignsListResponse.Campaigns

                    DataRow = DataTable.NewRow

                    DataRow("Name") = Mid(Campaign.Name, 1, 128)
                    DataRow("ID") = Campaign.Id
                    DataRow("StartDate") = Campaign.StartDate
                    DataRow("EndDate") = Campaign.EndDate
                    DataRow("AdvertiserID") = Campaign.AdvertiserId
                    DataRow("DefaultLandingPageId") = Campaign.DefaultLandingPageId

                    DataTable.Rows.Add(DataRow)

                Next

                NextPageToken = CampaignsListResponse.NextPageToken

            Loop While CampaignsListResponse.Campaigns.Any AndAlso Not String.IsNullOrWhiteSpace(NextPageToken)

        End Sub
        Private Sub GetSites(ProfileID As Long, DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService,
                             ByRef DictionarySites As Dictionary(Of Long, String))

            Dim ListRequest As Google.Apis.Dfareporting.v3_5.SitesResource.ListRequest = Nothing
            Dim SitesListResponse As Google.Apis.Dfareporting.v3_5.Data.SitesListResponse = Nothing
            Dim NextPageToken As String = Nothing

            DictionarySites = New Dictionary(Of Long, String)

            Do

                ListRequest = DfareportingService.Sites.List(ProfileID)
                ListRequest.Approved = True
                ListRequest.PageToken = NextPageToken

                SitesListResponse = ListRequest.Execute

                For Each Site In SitesListResponse.Sites

                    DictionarySites.Add(Site.Id.Value, Site.Name)

                Next

                NextPageToken = SitesListResponse.NextPageToken

            Loop While SitesListResponse.Sites.Any AndAlso Not String.IsNullOrWhiteSpace(NextPageToken)

        End Sub
        Private Sub GetPlacements(ProfileID As Long, DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService,
                                  AdServerPlacementIDs As IEnumerable(Of String),
                                  ByRef DictionaryPlacements As Dictionary(Of Long, Boolean))

            Dim ListRequest As Google.Apis.Dfareporting.v3_5.PlacementsResource.ListRequest = Nothing
            Dim NextPageToken As String = Nothing
            Dim PlacementsListResponse As Google.Apis.Dfareporting.v3_5.Data.PlacementsListResponse = Nothing

            DictionaryPlacements = New Dictionary(Of Long, Boolean)

            Do

                ListRequest = DfareportingService.Placements.List(ProfileID)
                ListRequest.Ids = New Google.Apis.Util.Repeatable(Of String)(AdServerPlacementIDs)
                ListRequest.PageToken = NextPageToken

                PlacementsListResponse = ListRequest.Execute

                For Each Placement In PlacementsListResponse.Placements

                    DictionaryPlacements.Add(Placement.Id.Value, Placement.Archived.Value)

                Next

                NextPageToken = PlacementsListResponse.NextPageToken

            Loop While PlacementsListResponse.Placements.Any AndAlso Not String.IsNullOrWhiteSpace(NextPageToken)

        End Sub
        Private Function GetAdvertiserLandingPages(ProfileID As Long, DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService, AdvertiserId As Long) As Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.LandingPage)

            Dim ListRequest As Google.Apis.Dfareporting.v3_5.AdvertiserLandingPagesResource.ListRequest = Nothing
            Dim NextPageToken As String = Nothing
            Dim AdvertiserLandingPagesListResponse As Google.Apis.Dfareporting.v3_5.Data.AdvertiserLandingPagesListResponse = Nothing
            Dim LandingPageList As Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.LandingPage) = Nothing

            LandingPageList = New Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.LandingPage)

            Do

                ListRequest = DfareportingService.AdvertiserLandingPages.List(ProfileID)
                ListRequest.AdvertiserIds = AdvertiserId
                ListRequest.Archived = False
                ListRequest.PageToken = NextPageToken

                AdvertiserLandingPagesListResponse = ListRequest.Execute

                For Each LandingPage In AdvertiserLandingPagesListResponse.LandingPages

                    LandingPageList.Add(LandingPage)

                Next

                NextPageToken = AdvertiserLandingPagesListResponse.NextPageToken

            Loop While AdvertiserLandingPagesListResponse.LandingPages.Any AndAlso Not String.IsNullOrWhiteSpace(NextPageToken)

            GetAdvertiserLandingPages = LandingPageList

        End Function
        Private Function LandingPageAdd(ProfileID As Long, DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService, AdvertiserId As Long, Name As String, Url As String,
                                        ByRef ErrorMessage As String, ByRef LandingPageId As Long?) As Boolean

            'objects
            Dim LandingPage As Google.Apis.Dfareporting.v3_5.Data.LandingPage = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.LandingPage = Nothing
            Dim Added As Boolean = False

            Try

                LandingPage = New Google.Apis.Dfareporting.v3_5.Data.LandingPage

                LandingPage.AdvertiserId = AdvertiserId
                LandingPage.Kind = "dfareporting#landingPage"
                LandingPage.Name = Name
                LandingPage.Url = Url

                Result = DfareportingService.AdvertiserLandingPages.Insert(LandingPage, ProfileID).Execute

                LandingPageId = Result.Id

                Added = True

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                LandingPageAdd = Added
            End Try

        End Function

#Region " Public "

        Public Function GetAdvertisersCampaignsSitesPlacements(ProfileID As Long, ByRef DictionaryAdvertisers As Dictionary(Of Long, String),
                                                               ByRef DataTable As System.Data.DataTable,
                                                               ByRef DictionarySites As Dictionary(Of Long, String),
                                                               ByRef DictionaryPlacements As Dictionary(Of Long, Boolean),
                                                               AdServerPlacementIDs As IEnumerable(Of String), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        GetAdvertisers(ProfileID, DfareportingService, DictionaryAdvertisers)

                        GetCampaigns(ProfileID, DfareportingService, DataTable)

                        GetSites(ProfileID, DfareportingService, DictionarySites)

                        If AdServerPlacementIDs IsNot Nothing AndAlso AdServerPlacementIDs.Count > 0 Then

                            GetPlacements(ProfileID, DfareportingService, AdServerPlacementIDs, DictionaryPlacements)

                        End If

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                GetAdvertisersCampaignsSitesPlacements = Success
            End Try

        End Function
        Public Function GetAdvertisers(ProfileID As Long, ByRef ErrorMessage As String, ByRef DictionaryAdvertisers As Dictionary(Of Long, String)) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        GetAdvertisers(ProfileID, DfareportingService, DictionaryAdvertisers)

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                GetAdvertisers = Success
            End Try

        End Function
        Public Function GetCampaigns(ProfileID As Long, ByRef ErrorMessage As String, ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        GetCampaigns(ProfileID, DfareportingService, DataTable)

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                GetCampaigns = Success
            End Try

        End Function
        Public Function GetDefaultLandingPage(ProfileID As Long, ByRef ErrorMessage As String, ByRef LandingPageName As String, ByRef LandingPageURL As String,
                                              AdvertiserLandingPageID As Long) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim ListRequest As Google.Apis.Dfareporting.v3_5.AdvertiserLandingPagesResource.ListRequest = Nothing
            Dim AdvertiserLandingPagesListResponse As Google.Apis.Dfareporting.v3_5.Data.AdvertiserLandingPagesListResponse = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    ListRequest = DfareportingService.AdvertiserLandingPages.List(ProfileID)
                    ListRequest.Ids = AdvertiserLandingPageID

                    AdvertiserLandingPagesListResponse = ListRequest.Execute

                    If AdvertiserLandingPagesListResponse.LandingPages IsNot Nothing AndAlso AdvertiserLandingPagesListResponse.LandingPages.Count = 1 Then

                        LandingPageName = AdvertiserLandingPagesListResponse.LandingPages(0).Name
                        LandingPageURL = AdvertiserLandingPagesListResponse.LandingPages(0).Url

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
            Finally
                GetDefaultLandingPage = Success
            End Try

        End Function
        Public Function GetPlacements(ProfileID As Long, AdServerAdvertiserId As IEnumerable(Of String), AdServerSiteId As IEnumerable(Of String),
                                      ByRef DictionaryPlacements As Dictionary(Of Long, String), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim ListRequest As Google.Apis.Dfareporting.v3_5.PlacementsResource.ListRequest = Nothing
            Dim NextPageToken As String = Nothing
            Dim PlacementsListResponse As Google.Apis.Dfareporting.v3_5.Data.PlacementsListResponse = Nothing
            Dim Success As Boolean = False

            DictionaryPlacements = New Dictionary(Of Long, String)

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        Do

                            ListRequest = DfareportingService.Placements.List(ProfileID)
                            ListRequest.Archived = False
                            ListRequest.AdvertiserIds = New Google.Apis.Util.Repeatable(Of String)(AdServerAdvertiserId)
                            ListRequest.SiteIds = New Google.Apis.Util.Repeatable(Of String)(AdServerSiteId)

                            ListRequest.PageToken = NextPageToken

                            PlacementsListResponse = ListRequest.Execute

                            For Each Placement In PlacementsListResponse.Placements

                                DictionaryPlacements.Add(Placement.Id.Value, Placement.Name)

                            Next

                            NextPageToken = PlacementsListResponse.NextPageToken

                        Loop While PlacementsListResponse.Placements.Any AndAlso Not String.IsNullOrWhiteSpace(NextPageToken)

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                GetPlacements = Success
            End Try

        End Function
        Public Function GetSites(ProfileID As Long, ByRef ErrorMessage As String, ByRef DictionarySites As Dictionary(Of Long, String)) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        GetSites(ProfileID, DfareportingService, DictionarySites)

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                GetSites = Success
            End Try

        End Function
        Public Function GetSizes(ProfileID As Long, ByRef ErrorMessage As String, ByRef DictionarySizes As Dictionary(Of Long, String)) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim ListRequest As Google.Apis.Dfareporting.v3_5.SizesResource.ListRequest = Nothing
            Dim SizesListResponse As Google.Apis.Dfareporting.v3_5.Data.SizesListResponse = Nothing
            Dim Size As Google.Apis.Dfareporting.v3_5.Data.Size = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        ListRequest = DfareportingService.Sizes.List(ProfileID)
                        ListRequest.IabStandard = True

                        SizesListResponse = ListRequest.Execute

                        DictionarySizes = New Dictionary(Of Long, String)

                        For Each Size In SizesListResponse.Sizes

                            DictionarySizes.Add(Size.Id.Value, CStr(Size.Width.Value & " x " & Size.Height.Value))

                        Next

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                GetSizes = Success
            End Try

        End Function
        Public Function AdvertiserAdd(ProfileID As Long, AdvertiserName As String, ByRef ErrorMessage As String, ByRef AdServerAdvertiserID As Long?) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Advertiser As Google.Apis.Dfareporting.v3_5.Data.Advertiser = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.Advertiser = Nothing
            Dim Added As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        Advertiser = New Google.Apis.Dfareporting.v3_5.Data.Advertiser

                        Advertiser.Name = AdvertiserName
                        Advertiser.Status = "APPROVED"

                        Result = DfareportingService.Advertisers.Insert(Advertiser, ProfileID).Execute

                        AdServerAdvertiserID = Result.Id

                        Added = True

                    End If

                End Using

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                AdvertiserAdd = Added
            End Try

        End Function
        Public Function CampaignAdd(ProfileID As Long, AdvertiserID As Long, CampaignName As String, LandingPageName As String, URL As String, StartDate As Date, EndDate As Date,
                                    ByRef ErrorMessage As String, ByRef AdServerCampaignID As Long?) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Campaign As Google.Apis.Dfareporting.v3_5.Data.Campaign = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.Campaign = Nothing
            Dim Added As Boolean = False
            Dim LandingPageList As Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.LandingPage) = Nothing
            Dim LandingPage As Google.Apis.Dfareporting.v3_5.Data.LandingPage = Nothing
            Dim LandingPageId As Long? = Nothing

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        LandingPageList = GetAdvertiserLandingPages(ProfileID, DfareportingService, AdvertiserID)

                        LandingPage = (From Entity In LandingPageList
                                       Where Entity.Name = LandingPageName AndAlso
                                             Entity.Url = URL
                                       Select Entity).Distinct.FirstOrDefault

                        If LandingPage IsNot Nothing Then

                            LandingPageId = LandingPage.Id

                        Else

                            If LandingPageAdd(ProfileID, DfareportingService, AdvertiserID, LandingPageName, URL, ErrorMessage, LandingPageId) = False Then

                                Throw New Exception(ErrorMessage)

                            End If

                        End If

                        Campaign = New Google.Apis.Dfareporting.v3_5.Data.Campaign

                        Campaign.Name = CampaignName
                        Campaign.AdvertiserId = AdvertiserID
                        Campaign.Archived = False
                        Campaign.StartDate = StartDate.ToString("yyyy-MM-dd")
                        Campaign.EndDate = EndDate.ToString("yyyy-MM-dd")

                        Campaign.DefaultLandingPageId = LandingPageId

                        Result = DfareportingService.Campaigns.Insert(Campaign, ProfileID).Execute

                        AdServerCampaignID = Result.Id

                        Added = True

                    End If

                End Using

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                CampaignAdd = Added
            End Try

        End Function
        Public Function PackageAdd(ProfileID As Long, AdvertiserID As Long, PackageName As String, CampaignId As Long, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date,
                                   AdServerSiteID As Long, PricingType As String, StartDate As Date, EndDate As Date,
                                   Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal),
                                   ByRef ErrorMessage As String, ByRef PlacementGroupID As Long?) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim PlacementGroup As Google.Apis.Dfareporting.v3_5.Data.PlacementGroup = Nothing
            Dim PricingSchedule As Google.Apis.Dfareporting.v3_5.Data.PricingSchedule = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.PlacementGroup = Nothing
            Dim Added As Boolean = False
            Dim PricingPeriods As Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod) = Nothing
            Dim PricingSchedulePricingPeriod As Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod = Nothing

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        If Not CampaignUpdate(ProfileID, DfareportingService, CampaignId, CampaignName, CampaignStartDate, CampaignEndDate, ErrorMessage) Then

                            Throw New Exception(ErrorMessage)

                        End If

                        PlacementGroup = New Google.Apis.Dfareporting.v3_5.Data.PlacementGroup

                        PlacementGroup.Name = PackageName
                        PlacementGroup.AdvertiserId = AdvertiserID
                        PlacementGroup.Archived = False
                        PlacementGroup.CampaignId = CampaignId
                        PlacementGroup.SiteId = AdServerSiteID
                        PlacementGroup.Kind = "dfareporting#placementGroup" 'fixed string per spec
                        PlacementGroup.PlacementGroupType = "PLACEMENT_PACKAGE"

                        PricingSchedule = New Google.Apis.Dfareporting.v3_5.Data.PricingSchedule
                        PricingSchedule.CapCostOption = "CAP_COST_NONE" 'other options here
                        PricingSchedule.PricingType = PricingType
                        PricingSchedule.StartDate = StartDate.ToString("yyyy-MM-dd")
                        PricingSchedule.EndDate = EndDate.ToString("yyyy-MM-dd")

                        PricingPeriods = New List(Of Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod)

                        PricingSchedulePricingPeriod = New Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod
                        PricingSchedulePricingPeriod.StartDate = StartDate.ToString("yyyy-MM-dd")
                        PricingSchedulePricingPeriod.EndDate = EndDate.ToString("yyyy-MM-dd")
                        PricingSchedulePricingPeriod.Units = Quantity

                        If PricingType = "PRICING_TYPE_FLAT_RATE_CLICKS" Then

                            PricingSchedulePricingPeriod.RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                        ElseIf PricingType = "PRICING_TYPE_FLAT_RATE_IMPRESSIONS" Then

                            PricingSchedulePricingPeriod.RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                        ElseIf PricingType = "PRICING_TYPE_CPM" Then

                            PricingSchedulePricingPeriod.RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000 * 1000

                        Else

                            PricingSchedulePricingPeriod.RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000

                        End If

                        PricingPeriods.Add(PricingSchedulePricingPeriod)

                        PricingSchedule.PricingPeriods = PricingPeriods

                        PlacementGroup.PricingSchedule = PricingSchedule

                        Result = DfareportingService.PlacementGroups.Insert(PlacementGroup, ProfileID).Execute

                        PlacementGroupID = Result.Id

                        Added = True

                    End If

                End Using

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                PackageAdd = Added
            End Try

        End Function
        Public Function PlacementAdd(ProfileID As Long, AdServerCampaignID As Long, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date,
                                     InternetTypeDescription As String, AdServerSiteID As Long, Name As String, PaymentSource As String,
                                     PlacementStart As Date, PlacementEnd As Date, PricingType As String, AdServerSizeID As Long, TagFormats As IList(Of String),
                                     PlacementGroupID As Nullable(Of Long), AdditionalAdServerSizeIDs As IEnumerable(Of Long),
                                     Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal),
                                     ByRef ErrorMessage As String, ByRef AdServerPlacementID As Long?) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim PricingSchedule As Google.Apis.Dfareporting.v3_5.Data.PricingSchedule = Nothing
            Dim Size As Google.Apis.Dfareporting.v3_5.Data.Size = Nothing
            Dim Placement As Google.Apis.Dfareporting.v3_5.Data.Placement = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.Placement = Nothing
            Dim Added As Boolean = False
            Dim AdditionalSize As Google.Apis.Dfareporting.v3_5.Data.Size = Nothing
            Dim AdditionalSizes As Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.Size) = Nothing
            Dim PricingPeriods As Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod) = Nothing
            Dim PricingSchedulePricingPeriod As Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod = Nothing

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        If Not CampaignUpdate(ProfileID, DfareportingService, AdServerCampaignID, CampaignName, CampaignStartDate, CampaignEndDate, ErrorMessage) Then

                            Throw New Exception(ErrorMessage)

                        End If

                        PricingSchedule = New Google.Apis.Dfareporting.v3_5.Data.PricingSchedule
                        PricingSchedule.StartDate = PlacementStart.ToString("yyyy-MM-dd")
                        PricingSchedule.EndDate = PlacementEnd.ToString("yyyy-MM-dd")
                        PricingSchedule.PricingType = PricingType

                        If PlacementGroupID.HasValue = False Then

                            PricingPeriods = New List(Of Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod)

                            PricingSchedulePricingPeriod = New Google.Apis.Dfareporting.v3_5.Data.PricingSchedulePricingPeriod
                            PricingSchedulePricingPeriod.StartDate = PlacementStart.ToString("yyyy-MM-dd")
                            PricingSchedulePricingPeriod.EndDate = PlacementEnd.ToString("yyyy-MM-dd")
                            PricingSchedulePricingPeriod.Units = Quantity

                            If PricingType = "PRICING_TYPE_FLAT_RATE_CLICKS" Then

                                PricingSchedulePricingPeriod.RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                            ElseIf PricingType = "PRICING_TYPE_FLAT_RATE_IMPRESSIONS" Then

                                PricingSchedulePricingPeriod.RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                            ElseIf PricingType = "PRICING_TYPE_CPM" Then

                                PricingSchedulePricingPeriod.RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000 * 1000

                            Else

                                PricingSchedulePricingPeriod.RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000

                            End If

                            PricingPeriods.Add(PricingSchedulePricingPeriod)

                            PricingSchedule.PricingPeriods = PricingPeriods

                        End If

                        Size = New Google.Apis.Dfareporting.v3_5.Data.Size
                        Size.Id = AdServerSizeID

                        Placement = New Google.Apis.Dfareporting.v3_5.Data.Placement

                        Placement.CampaignId = AdServerCampaignID
                        Placement.Compatibility = InternetTypeDescription
                        Placement.SiteId = AdServerSiteID
                        Placement.Name = Name
                        Placement.PaymentSource = PaymentSource

                        Placement.PricingSchedule = PricingSchedule
                        Placement.Size = Size

                        If AdditionalAdServerSizeIDs IsNot Nothing AndAlso AdditionalAdServerSizeIDs.Count > 0 Then

                            AdditionalSizes = New Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.Size)

                            For Each AdditionalAdServerSizeID In AdditionalAdServerSizeIDs

                                AdditionalSize = New Google.Apis.Dfareporting.v3_5.Data.Size
                                AdditionalSize.Id = AdditionalAdServerSizeID

                                AdditionalSizes.Add(AdditionalSize)

                            Next

                            Placement.AdditionalSizes = AdditionalSizes

                        End If

                        Placement.TagFormats = TagFormats
                        Placement.PlacementGroupId = PlacementGroupID

                        Result = DfareportingService.Placements.Insert(Placement, ProfileID).Execute

                        AdServerPlacementID = Result.Id

                        Added = True

                    End If

                End Using

            Catch ex As Exception
                Added = False
                ErrorMessage = ex.Message
            Finally
                PlacementAdd = Added
            End Try

        End Function
        Public Function PlacementUpdate(ProfileID As Long, AdServerPlacementID As Long, Name As String, PlacementStart As Date, PlacementEnd As Date, PricingType As String, AdServerSizeID As Long,
                                        AdServerCampaignID As Long, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date, AdditionalAdServerSizeIDs As IEnumerable(Of Long),
                                        Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal),
                                        ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Placement As Google.Apis.Dfareporting.v3_5.Data.Placement = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.Placement = Nothing
            Dim Updated As Boolean = False
            Dim AdditionalSize As Google.Apis.Dfareporting.v3_5.Data.Size = Nothing
            Dim AdditionalSizes As Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.Size) = Nothing

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        If Not CampaignUpdate(ProfileID, DfareportingService, AdServerCampaignID, CampaignName, CampaignStartDate, CampaignEndDate, ErrorMessage) Then

                            Throw New Exception(ErrorMessage)

                        End If

                        Placement = DfareportingService.Placements.Get(ProfileID, AdServerPlacementID).Execute

                        If Placement IsNot Nothing Then

                            Placement.PricingSchedule.StartDate = PlacementStart.ToString("yyyy-MM-dd")
                            Placement.PricingSchedule.EndDate = PlacementEnd.ToString("yyyy-MM-dd")
                            Placement.PricingSchedule.PricingType = PricingType
                            Placement.PricingSchedule.TestingStartDate = PlacementStart.ToString("yyyy-MM-dd")

                            If Placement.PricingSchedule.PricingPeriods.Count = 1 Then

                                Placement.PricingSchedule.PricingPeriods(0).StartDate = Placement.PricingSchedule.StartDate
                                Placement.PricingSchedule.PricingPeriods(0).EndDate = Placement.PricingSchedule.EndDate

                                If Placement.PlacementGroupId.HasValue = False Then

                                    Placement.PricingSchedule.PricingPeriods(0).Units = Quantity

                                    If PricingType = "PRICING_TYPE_FLAT_RATE_CLICKS" Then

                                        Placement.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                                    ElseIf PricingType = "PRICING_TYPE_FLAT_RATE_IMPRESSIONS" Then

                                        Placement.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                                    ElseIf PricingType = "PRICING_TYPE_CPM" Then

                                        Placement.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000 * 1000

                                    Else

                                        Placement.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000

                                    End If

                                End If

                            End If

                            Placement.Size.Id = AdServerSizeID
                            Placement.Name = Name

                            If AdditionalAdServerSizeIDs IsNot Nothing AndAlso AdditionalAdServerSizeIDs.Count > 0 Then

                                AdditionalSizes = New Generic.List(Of Google.Apis.Dfareporting.v3_5.Data.Size)

                                For Each AdditionalAdServerSizeID In AdditionalAdServerSizeIDs

                                    AdditionalSize = New Google.Apis.Dfareporting.v3_5.Data.Size
                                    AdditionalSize.Id = AdditionalAdServerSizeID

                                    AdditionalSizes.Add(AdditionalSize)

                                Next

                                Placement.AdditionalSizes = AdditionalSizes

                            End If

                            Result = DfareportingService.Placements.Update(Placement, ProfileID).Execute

                            Updated = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                PlacementUpdate = Updated
            End Try

        End Function
        Public Function SetPackageArchived(ProfileID As Long, PlacementGroupID As Long, IsArchived As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim PlacementGroup As Google.Apis.Dfareporting.v3_5.Data.PlacementGroup = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.PlacementGroup = Nothing
            Dim Updated As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        PlacementGroup = DfareportingService.PlacementGroups.Get(ProfileID, PlacementGroupID).Execute

                        If PlacementGroup IsNot Nothing Then

                            PlacementGroup.Archived = IsArchived

                            Result = DfareportingService.PlacementGroups.Update(PlacementGroup, ProfileID).Execute

                            Updated = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                SetPackageArchived = Updated
            End Try

        End Function
        Public Function SetPlacementArchived(ProfileID As Long, AdServerPlacementID As Long, IsArchived As Boolean, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Placement As Google.Apis.Dfareporting.v3_5.Data.Placement = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.Placement = Nothing
            Dim Updated As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        Placement = DfareportingService.Placements.Get(ProfileID, AdServerPlacementID).Execute

                        If Placement IsNot Nothing Then

                            Placement.Archived = IsArchived

                            Result = DfareportingService.Placements.Update(Placement, ProfileID).Execute

                            Updated = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                SetPlacementArchived = Updated
            End Try

        End Function
        Public Function RunReport(ProfileID As Long, ReportID As Long, RelativeDateRange As String,
                                  ByRef MemoryStream As System.IO.MemoryStream,
                                  ByRef ErrorMessage As String)

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim Report As Google.Apis.Dfareporting.v3_5.Data.Report = Nothing
            Dim UpdatedReport As Google.Apis.Dfareporting.v3_5.Data.Report = Nothing
            Dim File As Google.Apis.Dfareporting.v3_5.Data.File = Nothing
            Dim FileID? As Long = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        Report = DfareportingService.Reports.Get(ProfileID, ReportID).Execute()

                        If Report IsNot Nothing Then

                            Report.Criteria.DateRange.RelativeDateRange = RelativeDateRange

                            UpdatedReport = DfareportingService.Reports.Update(Report, ProfileID, ReportID).Execute()

                            If UpdatedReport IsNot Nothing Then

                                File = DfareportingService.Reports.Run(ProfileID, ReportID).Execute()
                                FileID = File.Id

                                Do

                                    File = DfareportingService.Files.Get(ReportID, FileID).Execute()

                                Loop While File.Status = "PROCESSING"

                                If File.Status = "REPORT_AVAILABLE" Then

                                    MemoryStream = New System.IO.MemoryStream()

                                    DfareportingService.Files.Get(ReportID, FileID).Download(MemoryStream)

                                    Success = True

                                End If

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                RunReport = Success
            End Try

        End Function
        Public Sub New(ByVal ConnectionString As String, ByVal EmployeeCode As String, ByVal EmailAddress As String, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean, ClientCode As String)

            MyBase.New(ConnectionString, EmployeeCode, EmailAddress, IsWebvantage, UseWindowsAuthentication, ClientCode)

        End Sub
        Public Overrides Function GetScope() As IEnumerable(Of String)

            Return Scope

        End Function
        Public Function GetNonIabStandardSizes(ProfileID As Long, ByRef ErrorMessage As String, ByRef DictionarySizes As Dictionary(Of Long, String)) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim ListRequest As Google.Apis.Dfareporting.v3_5.SizesResource.ListRequest = Nothing
            Dim SizesListResponse As Google.Apis.Dfareporting.v3_5.Data.SizesListResponse = Nothing
            Dim Size As Google.Apis.Dfareporting.v3_5.Data.Size = Nothing
            Dim Success As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        ListRequest = DfareportingService.Sizes.List(ProfileID)
                        ListRequest.IabStandard = False

                        SizesListResponse = ListRequest.Execute

                        DictionarySizes = New Dictionary(Of Long, String)

                        For Each Size In SizesListResponse.Sizes

                            DictionarySizes.Add(Size.Id.Value, CStr(Size.Width.Value & " x " & Size.Height.Value))

                        Next

                        Success = True

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message
            Finally
                GetNonIabStandardSizes = Success
            End Try

        End Function
        Public Function PackageUpdate(ProfileID As Long, AdServerPlacementGroupID As Long, PackageName As String, CampaignId As Long, CampaignName As String, CampaignStartDate As Date, CampaignEndDate As Date,
                                      PricingType As String, StartDate As Date, EndDate As Date, Quantity As Nullable(Of Long), Rate As Nullable(Of Decimal), Cost As Nullable(Of Decimal),
                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DfareportingService As Google.Apis.Dfareporting.v3_5.DfareportingService = Nothing
            Dim PlacementGroup As Google.Apis.Dfareporting.v3_5.Data.PlacementGroup = Nothing
            Dim Result As Google.Apis.Dfareporting.v3_5.Data.PlacementGroup = Nothing
            Dim Updated As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                    DfareportingService = LoadService(ProfileID, DataContext, ErrorMessage)

                    If DfareportingService IsNot Nothing Then

                        If Not CampaignUpdate(ProfileID, DfareportingService, CampaignId, CampaignName, CampaignStartDate, CampaignEndDate, ErrorMessage) Then

                            Throw New Exception(ErrorMessage)

                        End If

                        PlacementGroup = DfareportingService.PlacementGroups.Get(ProfileID, AdServerPlacementGroupID).Execute

                        If PlacementGroup IsNot Nothing Then

                            PlacementGroup.Name = PackageName

                            'PlacementGroup.AdvertiserId = AdvertiserID
                            'PlacementGroup.Archived = False
                            'PlacementGroup.CampaignId = CampaignId
                            'PlacementGroup.Kind = "dfareporting#placementGroup" 'fixed string per spec
                            'PlacementGroup.PlacementGroupType = "PLACEMENT_PACKAGE"

                            PlacementGroup.PricingSchedule.CapCostOption = "CAP_COST_NONE" 'other options here
                            PlacementGroup.PricingSchedule.PricingType = PricingType
                            PlacementGroup.PricingSchedule.StartDate = StartDate.ToString("yyyy-MM-dd")
                            PlacementGroup.PricingSchedule.EndDate = EndDate.ToString("yyyy-MM-dd")

                            If PlacementGroup.PricingSchedule.PricingPeriods.Count = 1 Then

                                PlacementGroup.PricingSchedule.PricingPeriods(0).StartDate = StartDate.ToString("yyyy-MM-dd")
                                PlacementGroup.PricingSchedule.PricingPeriods(0).EndDate = EndDate.ToString("yyyy-MM-dd")
                                PlacementGroup.PricingSchedule.PricingPeriods(0).Units = Quantity

                                If PricingType = "PRICING_TYPE_FLAT_RATE_CLICKS" Then

                                    PlacementGroup.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                                ElseIf PricingType = "PRICING_TYPE_FLAT_RATE_IMPRESSIONS" Then

                                    PlacementGroup.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Cost.GetValueOrDefault(0) * 1000000000

                                ElseIf PricingType = "PRICING_TYPE_CPM" Then

                                    PlacementGroup.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000 * 1000

                                Else

                                    PlacementGroup.PricingSchedule.PricingPeriods(0).RateOrCostNanos = Rate.GetValueOrDefault(0) * 1000000000

                                End If

                            End If

                        End If

                        Result = DfareportingService.PlacementGroups.Update(PlacementGroup, ProfileID).Execute

                        Updated = True

                    End If

                End Using

            Catch ex As Exception
                Updated = False
                ErrorMessage = ex.Message
            Finally
                PackageUpdate = Updated
            End Try

        End Function

#End Region

#End Region

    End Class

End Namespace
