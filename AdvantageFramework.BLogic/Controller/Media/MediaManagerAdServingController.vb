Namespace Controller.Media

    Public Class MediaManagerAdServingController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "

        Const PAYMENT_SOURCE As String = "PLACEMENT_AGENCY_PAID"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OrderNumberLineNumbers As IEnumerable(Of String) = Nothing
        Private _AdServerID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub CreateAdvantageCampaignsFromAdServerCampaigns(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                                                  DbContext As AdvantageFramework.Database.DbContext)

            Dim MediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel = Nothing
            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim ClientCodes As IEnumerable(Of String) = Nothing
            Dim WebsiteType As AdvantageFramework.Database.Entities.WebsiteType = Nothing

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            ClientCodes = (From Entity In ViewModel.MediaManagerAdServingDetailViewModelList
                           Where Entity.HasAdServerCampaignID = False AndAlso
                                 Entity.AdServerCampaignID.HasValue AndAlso
                                 Entity.CampaignID.HasValue = False
                           Select Entity.ClientCode).Distinct.ToArray

            For Each ClientCode In ClientCodes

                MediaManagerAdServingDetailViewModel = ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Dtl) Dtl.HasAdServerCampaignID = False AndAlso
                                                                                                                              Dtl.AdServerCampaignID.HasValue AndAlso
                                                                                                                              Dtl.CampaignID.HasValue = False AndAlso
                                                                                                                              Dtl.ClientCode = ClientCode).Select(Function(Dtl) Dtl).FirstOrDefault

                If MediaManagerAdServingDetailViewModel IsNot Nothing Then

                    ClientWebsite = (From Entity In AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, MediaManagerAdServingDetailViewModel.ClientCode)
                                     Where Entity.IsInactive = False AndAlso
                                           Entity.WebsiteAddress = MediaManagerAdServingDetailViewModel.LandingPageURL).FirstOrDefault

                    If ClientWebsite Is Nothing Then

                        WebsiteType = DbContext.WebsiteTypes.Where(Function(WT) WT.IsInactive = False).FirstOrDefault

                        If WebsiteType IsNot Nothing Then

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                            ClientWebsite = New AdvantageFramework.Database.Entities.ClientWebsite
                            ClientWebsite.ClientCode = MediaManagerAdServingDetailViewModel.ClientCode
                            ClientWebsite.WebsiteTypeCode = WebsiteType.Code
                            ClientWebsite.WebsiteAddress = MediaManagerAdServingDetailViewModel.LandingPageURL
                            ClientWebsite.WebsiteName = MediaManagerAdServingDetailViewModel.LandingPageName
                            ClientWebsite.IsInactive = False

                            If Not AdvantageFramework.Database.Procedures.ClientWebsite.Insert(DbContext, ClientWebsite) Then

                                ClientWebsite = Nothing

                            End If

                            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        End If

                    End If

                    If ClientWebsite IsNot Nothing Then

                        Campaign = New AdvantageFramework.Database.Entities.Campaign
                        Campaign.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Any = False Then

                            Campaign.Code = "1"

                        Else

                            Campaign.Code = AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Select(Function(Entity) Entity.ID).Max + 1

                        End If

                        Campaign.Name = MediaManagerAdServingDetailViewModel.CampaignName
                        Campaign.ClientCode = MediaManagerAdServingDetailViewModel.ClientCode

                        Campaign.StartDate = MediaManagerAdServingDetailViewModel.CampaignStartDate
                        Campaign.EndDate = MediaManagerAdServingDetailViewModel.CampaignEndDate

                        Campaign.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.AssignedToJobsAndOrders
                        Campaign.IsClosed = 0

                        Campaign.AdServerID = AdvantageFramework.Database.Entities.AdServerID.DoubleClick
                        Campaign.ClientWebsiteID = ClientWebsite.ID
                        Campaign.AdServerCampaignID = MediaManagerAdServingDetailViewModel.AdServerCampaignID

                        If AdvantageFramework.Database.Procedures.Campaign.Insert(DbContext, Campaign) Then

                            For Each MMASDVM In ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Dtl) Dtl.HasAdServerCampaignID = False AndAlso
                                                                                                                       Dtl.AdServerCampaignID.HasValue AndAlso
                                                                                                                       Dtl.CampaignID.HasValue = False AndAlso
                                                                                                                       Dtl.ClientCode = ClientCode)

                                MMASDVM.ReviseUpdateOrder = True
                                MMASDVM.CampaignID = Campaign.ID

                            Next

                        End If

                    End If

                End If

            Next

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

        End Sub
        Private Function CreateCampaignDataTable() As System.Data.DataTable

            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing

            DataTable = New System.Data.DataTable

            DataColumn = DataTable.Columns.Add("Name")
            DataColumn.DataType = GetType(String)
            DataColumn.MaxLength = 128

            DataColumn = DataTable.Columns.Add("ID")
            DataColumn.DataType = GetType(Int64)

            DataColumn = DataTable.Columns.Add("StartDate")
            DataColumn.DataType = GetType(Date)

            DataColumn = DataTable.Columns.Add("EndDate")
            DataColumn.DataType = GetType(Date)

            DataColumn = DataTable.Columns.Add("AdvertiserID")
            DataColumn.DataType = GetType(Int64)

            DataColumn = DataTable.Columns.Add("DefaultLandingPageId")
            DataColumn.DataType = GetType(Int64)

            CreateCampaignDataTable = DataTable

        End Function
        Private Sub MapExistingAdServerAdvertisers(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                                   DbContext As AdvantageFramework.Database.DbContext)

            Dim DictionaryAdServerAdvertisers As Dictionary(Of String, Long) = Nothing
            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing
            Dim RecordSourceName As String = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing

            DictionaryAdServerAdvertisers = New Dictionary(Of String, Long)

            For Each ClientCode In ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(AD) AD.HasAdServerAdvertiserID = False AndAlso AD.AdServerAdvertiserID.HasValue).Select(Function(AD) AD.ClientCode).Distinct

                DictionaryAdServerAdvertisers.Add(ClientCode, ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(AD) AD.ClientCode = ClientCode AndAlso
                                                                                                                                    AD.HasAdServerAdvertiserID = False AndAlso
                                                                                                                                    AD.AdServerAdvertiserID.HasValue).First.AdServerAdvertiserID.Value)

            Next

            If DictionaryAdServerAdvertisers IsNot Nothing AndAlso DictionaryAdServerAdvertisers.Count > 0 Then

                RecordSourceName = AdvantageFramework.DoubleClick.GetRecordSourceName

                RecordSource = (From RS In AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)
                                Where RS.Name = RecordSourceName AndAlso
                                      RS.IsSystemSource
                                Select RS).FirstOrDefault

                If RecordSource IsNot Nothing Then

                    For Each KeyValuePair In DictionaryAdServerAdvertisers

                        ClientCrossReference = New AdvantageFramework.Database.Entities.ClientCrossReference()
                        ClientCrossReference.DbContext = DbContext

                        ClientCrossReference.RecordSourceID = RecordSource.ID
                        ClientCrossReference.ClientCode = KeyValuePair.Key
                        ClientCrossReference.SourceClientCode = KeyValuePair.Value

                        DbContext.ClientCrossReferences.Add(ClientCrossReference)

                    Next

                    DbContext.SaveChanges()

                End If

            End If

        End Sub
        Private Sub MapExistingAdServerSites(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                             DbContext As AdvantageFramework.Database.DbContext)

            Dim DictionaryAdServerSites As Dictionary(Of String, Long) = Nothing
            Dim VendorDCMMapping As AdvantageFramework.Database.Entities.VendorDCMMapping = Nothing

            DictionaryAdServerSites = New Dictionary(Of String, Long)

            For Each VendorCode In ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(AD) AD.HasAdServerSiteID = False AndAlso AD.AdServerSiteID.HasValue).Select(Function(AD) AD.VendorCode).Distinct

                DictionaryAdServerSites.Add(VendorCode, ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(AD) AD.VendorCode = VendorCode AndAlso
                                                                                                                              AD.HasAdServerSiteID = False AndAlso
                                                                                                                              AD.AdServerSiteID.HasValue).First.AdServerSiteID.Value)

            Next

            If DictionaryAdServerSites IsNot Nothing AndAlso DictionaryAdServerSites.Count > 0 Then

                For Each KeyValuePair In DictionaryAdServerSites

                    VendorDCMMapping = New AdvantageFramework.Database.Entities.VendorDCMMapping()
                    VendorDCMMapping.DbContext = DbContext

                    VendorDCMMapping.VendorCode = KeyValuePair.Key
                    VendorDCMMapping.DoubleClickSiteID = KeyValuePair.Value
                    VendorDCMMapping.DoubleClickProfileID = ViewModel.DCProfileID

                    DbContext.VendorDCMMappings.Add(VendorDCMMapping)

                Next

                DbContext.SaveChanges()

            End If

        End Sub
        Private Function GetTagFormats(InternetTypeDescription As String) As IList(Of String)

            Dim TagFormats As IList(Of String) = Nothing

            Select Case InternetTypeDescription

                Case "DISPLAY"

                    TagFormats = {"PLACEMENT_TAG_STANDARD", "PLACEMENT_TAG_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_IFRAME_ILAYER", "PLACEMENT_TAG_INTERNAL_REDIRECT",
                                    "PLACEMENT_TAG_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_INTERNAL_REDIRECT", "PLACEMENT_TAG_INTERSTITIAL_JAVASCRIPT",
                                    "PLACEMENT_TAG_CLICK_COMMANDS", "PLACEMENT_TAG_INSTREAM_VIDEO_PREFETCH", "PLACEMENT_TAG_TRACKING", "PLACEMENT_TAG_TRACKING_IFRAME", "PLACEMENT_TAG_TRACKING_JAVASCRIPT"}

                Case "DISPLAY_INTERSTITIAL"

                    TagFormats = {"PLACEMENT_TAG_STANDARD", "PLACEMENT_TAG_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_IFRAME_ILAYER", "PLACEMENT_TAG_INTERNAL_REDIRECT",
                                    "PLACEMENT_TAG_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_INTERNAL_REDIRECT", "PLACEMENT_TAG_INTERSTITIAL_JAVASCRIPT",
                                    "PLACEMENT_TAG_CLICK_COMMANDS", "PLACEMENT_TAG_INSTREAM_VIDEO_PREFETCH", "PLACEMENT_TAG_TRACKING", "PLACEMENT_TAG_TRACKING_IFRAME", "PLACEMENT_TAG_TRACKING_JAVASCRIPT"}

                Case "IN_STREAM_VIDEO"

                    TagFormats = {"PLACEMENT_TAG_STANDARD", "PLACEMENT_TAG_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_IFRAME_ILAYER", "PLACEMENT_TAG_INTERNAL_REDIRECT",
                                    "PLACEMENT_TAG_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_INTERNAL_REDIRECT", "PLACEMENT_TAG_INTERSTITIAL_JAVASCRIPT",
                                    "PLACEMENT_TAG_CLICK_COMMANDS", "PLACEMENT_TAG_INSTREAM_VIDEO_PREFETCH", "PLACEMENT_TAG_TRACKING", "PLACEMENT_TAG_TRACKING_IFRAME", "PLACEMENT_TAG_TRACKING_JAVASCRIPT"}

                Case "IN_STREAM_AUDIO"

                    TagFormats = {"PLACEMENT_TAG_STANDARD", "PLACEMENT_TAG_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_IFRAME_ILAYER", "PLACEMENT_TAG_INTERNAL_REDIRECT",
                                    "PLACEMENT_TAG_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_IFRAME_JAVASCRIPT", "PLACEMENT_TAG_INTERSTITIAL_INTERNAL_REDIRECT", "PLACEMENT_TAG_INTERSTITIAL_JAVASCRIPT",
                                    "PLACEMENT_TAG_CLICK_COMMANDS", "PLACEMENT_TAG_INSTREAM_VIDEO_PREFETCH", "PLACEMENT_TAG_TRACKING", "PLACEMENT_TAG_TRACKING_IFRAME", "PLACEMENT_TAG_TRACKING_JAVASCRIPT"}

            End Select

            GetTagFormats = TagFormats

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session, OrderNumberLineNumbers As IEnumerable(Of String), AdServerID As Integer)

            MyBase.New(Session)

            _OrderNumberLineNumbers = OrderNumberLineNumbers
            _AdServerID = AdServerID

        End Sub
        Public Sub SetValuesBasedOnRepositoryValue(PropertyName As String, Value As Object, MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If PropertyName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString Then

                    If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing AndAlso MediaManagerAdServingViewModel.AdSizeList.Where(Function(Entity) Entity.Code = Value).FirstOrDefault IsNot Nothing Then

                        MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerSizeID = MediaManagerAdServingViewModel.AdSizeList.Where(Function(Entity) Entity.Code = Value).FirstOrDefault.AdServerSizeID
                        MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.ReviseUpdateOrder = True

                    End If

                ElseIf PropertyName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetType.ToString Then

                    If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing AndAlso MediaManagerAdServingViewModel.InternetTypeList.Where(Function(Entity) Entity.Code = Value).FirstOrDefault IsNot Nothing Then

                        MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.InternetTypeDescription = MediaManagerAdServingViewModel.InternetTypeList.Where(Function(Entity) Entity.Code = Value).FirstOrDefault.Description
                        MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.ReviseUpdateOrder = True

                    End If

                ElseIf PropertyName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignID.ToString Then

                    If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                        For Each Detail In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.OrderNumber = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.OrderNumber)

                            Detail.DbContext = DbContext

                            If Value Is Nothing Then

                                Detail.AdServerCampaignID = Nothing
                                Detail.CampaignID = Nothing
                                Detail.CampaignName = Nothing
                                Detail.CampaignCode = Nothing
                                Detail.CampaignStartDate = Nothing
                                Detail.CampaignEndDate = Nothing

                            ElseIf MediaManagerAdServingViewModel.CampaignList.Where(Function(Entity) Entity.ID = Value).FirstOrDefault IsNot Nothing Then

                                Campaign = MediaManagerAdServingViewModel.CampaignList.Where(Function(Entity) Entity.ID = Value).FirstOrDefault

                                If Campaign IsNot Nothing Then

                                    Detail.AdServerCampaignID = Campaign.AdServerCampaignID
                                    Detail.CampaignID = Campaign.ID
                                    Detail.CampaignName = Campaign.Name
                                    Detail.CampaignCode = Campaign.Code
                                    Detail.CampaignStartDate = Campaign.StartDate
                                    Detail.CampaignEndDate = Campaign.EndDate

                                End If

                            End If

                            Detail.ReviseUpdateOrder = True
                            Detail.ValidateEntity(True)

                        Next

                    End If

                End If

            End Using

        End Sub
        Public Function Load(DCProfileID As Long, DCReportID As Nullable(Of Long)) As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel

            Dim SqlParameterOrderNumberLineNumberList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAdServerID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProfileID As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel = Nothing
            Dim AdServerPlacementIDs As IEnumerable(Of String) = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            MediaManagerAdServingViewModel = New AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel

            MediaManagerAdServingViewModel.AdServerCampaignDataTable = CreateCampaignDataTable()

            MediaManagerAdServingViewModel.AdServerReportID = DCReportID
            MediaManagerAdServingViewModel.DCProfileID = DCProfileID

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SqlParameterOrderNumberLineNumberList = New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumberList", SqlDbType.VarChar)
                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar)
                SqlParameterAdServerID = New System.Data.SqlClient.SqlParameter("@AdServerID", SqlDbType.Int)
                SqlParameterProfileID = New System.Data.SqlClient.SqlParameter("@DCProfileID", SqlDbType.BigInt)

                SqlParameterOrderNumberLineNumberList.Value = String.Join(",", _OrderNumberLineNumbers.ToArray)
                SqlParameterUserCode.Value = Session.UserCode
                SqlParameterAdServerID.Value = _AdServerID
                SqlParameterProfileID.Value = DCProfileID

                MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel)("EXEC advsp_media_manager_ad_serving_load_details @OrderNumberLineNumberList, @UserCode, @AdServerID, @DCProfileID",
                                                SqlParameterOrderNumberLineNumberList, SqlParameterUserCode, SqlParameterAdServerID, SqlParameterProfileID).ToList()

                For Each MediaManagerAdServingDetailViewModel In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList

                    'load additional sizes
                    MediaManagerAdServingDetailViewModel.LoadAdditionalAdSizes(DbContext)

                    If String.IsNullOrWhiteSpace(MediaManagerAdServingDetailViewModel.AdSizeCode) Then

                        If MediaManagerAdServingDetailViewModel.InternetPackageDetails IsNot Nothing AndAlso MediaManagerAdServingDetailViewModel.InternetPackageDetails.Count > 0 Then

                            MediaManagerAdServingDetailViewModel.AdSizeCode = MediaManagerAdServingDetailViewModel.InternetPackageDetails(0).InternetPackageDetail.AdSizeCode

                            AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(DbContext, MediaManagerAdServingDetailViewModel.AdSizeCode, "I")

                            If AdSize IsNot Nothing Then

                                MediaManagerAdServingDetailViewModel.AdServerSizeID = AdSize.AdServerSizeID

                            End If

                        End If

                    End If

                    MediaManagerAdServingDetailViewModel.DbContext = DbContext
                    MediaManagerAdServingDetailViewModel.ValidateEntity(True)

                Next

                MediaManagerAdServingViewModel.AdSizeList = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AdSize).Where(Function(Ad) Ad.AdServerSizeID.HasValue).ToList

                MediaManagerAdServingViewModel.InternetTypeList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.InternetType).ToList
                                                                   Where AdvantageFramework.DoubleClick.GetCompatibility.Contains(Entity.Description)
                                                                   Select Entity).ToList

                MediaManagerAdServingViewModel.CampaignList = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext)
                                                               Where (Entity.IsClosed Is Nothing OrElse
                                                                      Entity.IsClosed = 0) AndAlso
                                                                      Entity.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.AssignedToJobsAndOrders
                                                               Select Entity).ToList

                AdServerPlacementIDs = (From Entity In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList
                                        Where Entity.AdServerPlacementID.HasValue
                                        Select CStr(Entity.AdServerPlacementID.Value)).ToList

                If AdvantageFramework.GoogleServices.Service.DoubleClickGetAdvertisersCampaignsSitesPlacements(Session, False, DCProfileID,
                                                                                                               MediaManagerAdServingViewModel.DictionaryAdServerAdvertiserID, MediaManagerAdServingViewModel.AdServerCampaignDataTable,
                                                                                                               MediaManagerAdServingViewModel.DictionaryAdServerSiteID, MediaManagerAdServingViewModel.DictionaryAdServerPlacementID,
                                                                                                               AdServerPlacementIDs, MediaManagerAdServingViewModel.DoubleClickAPIErrorString) Then

                    For Each MediaManagerAdServingDetailViewModel In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList

                        If MediaManagerAdServingDetailViewModel.AdServerPlacementID.HasValue AndAlso MediaManagerAdServingViewModel.DictionaryAdServerPlacementID IsNot Nothing AndAlso
                                MediaManagerAdServingViewModel.DictionaryAdServerPlacementID.ContainsKey(MediaManagerAdServingDetailViewModel.AdServerPlacementID.Value) Then

                            MediaManagerAdServingDetailViewModel.IsPlacementArchived = MediaManagerAdServingViewModel.DictionaryAdServerPlacementID.Item(MediaManagerAdServingDetailViewModel.AdServerPlacementID)

                            If Not MediaManagerAdServingDetailViewModel.IsPlacementArchived AndAlso MediaManagerAdServingDetailViewModel.IsCancelled Then

                                MediaManagerAdServingDetailViewModel.RequiresUpdate = True

                            End If

                        End If

                    Next

                End If

                MediaManagerAdServingViewModel.ReportCriteria = New AdvantageFramework.DoubleClick.Classes.ReportCriteria

            End Using

            Load = MediaManagerAdServingViewModel

        End Function
        Public Sub RefreshCampaignList(ByRef MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MediaManagerAdServingViewModel.CampaignList = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadAllByClientDivisionAndProduct(DbContext, MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.ClientCode, MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.DivisionCode, MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.ProductCode).ToList
                                                                   Where Entity.IsClosed.GetValueOrDefault(0) = 0 AndAlso
                                                                         Entity.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.AssignedToJobsAndOrders
                                                                   Select Entity).ToList

                End Using

            End If

        End Sub
        Public Sub ClearPlacements(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each MediaManagerAdServingDetailViewModel In ViewModel.SelectedMediaManagerAdServingDetailViewModelList

                    If MediaManagerAdServingDetailViewModel.AdServerPlacementID.HasValue Then

                        MediaManagerAdServingDetailViewModel.DbContext = DbContext

                        MediaManagerAdServingDetailViewModel.ClearedPlacementID = MediaManagerAdServingDetailViewModel.AdServerPlacementID.Value
                        MediaManagerAdServingDetailViewModel.AdServerPlacementID = Nothing
                        MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID = Nothing

                        MediaManagerAdServingDetailViewModel.ClearAdditionalAdSizePlacements()

                        MediaManagerAdServingDetailViewModel.ValidateEntity(True)

                    ElseIf MediaManagerAdServingDetailViewModel.IsNewPackage Then

                        MediaManagerAdServingDetailViewModel.DbContext = DbContext

                        MediaManagerAdServingDetailViewModel.ClearAdditionalAdSizePlacements()

                        MediaManagerAdServingDetailViewModel.ValidateEntity(True)

                    End If

                Next

            End Using

        End Sub
        Public Function CreateAdvertisers(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                          ByRef ErrorString As String) As Boolean

            Dim Created As Boolean = True
            Dim ClientCodes As IEnumerable(Of String) = Nothing
            Dim MediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel = Nothing

            ClientCodes = (From Entity In ViewModel.SelectedMediaManagerAdServingDetailViewModelList
                           Where Entity.AdServerAdvertiserID.HasValue = False
                           Select Entity.ClientCode).Distinct.ToArray

            If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ClientCode In ClientCodes

                        MediaManagerAdServingDetailViewModel = ViewModel.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(MMASD) MMASD.ClientCode = ClientCode).FirstOrDefault

                        If Not AdvantageFramework.GoogleServices.Service.DoubleClickAdvertiserAdd(Session, False, ViewModel.DCProfileID,
                                MediaManagerAdServingDetailViewModel.ClientCode, MediaManagerAdServingDetailViewModel.ClientName, ErrorString) Then

                            Created = False
                            Exit For

                        End If

                    Next

                    AdvantageFramework.GoogleServices.Service.DoubleClickGetAdvertisers(Session, False, ViewModel.DCProfileID, ViewModel.DictionaryAdServerAdvertiserID, ErrorString)

                End Using

            End If

            CreateAdvertisers = Created

        End Function
        Public Function CreateCampaigns(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                        AdServerID As Integer, ByRef ErrorString As String) As Boolean

            Dim Created As Boolean = True
            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel = Nothing

            CampaignIDs = (From Entity In ViewModel.SelectedMediaManagerAdServingDetailViewModelList
                           Where Entity.AdServerAdvertiserID.HasValue AndAlso
                                 Entity.AdServerCampaignID Is Nothing AndAlso
                                 Entity.CampaignID IsNot Nothing
                           Select Entity.CampaignID.Value).Distinct.ToArray

            If CampaignIDs IsNot Nothing AndAlso CampaignIDs.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each CampaignID In CampaignIDs

                        MediaManagerAdServingDetailViewModel = ViewModel.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(MMASD) MMASD.CampaignID = CampaignID).FirstOrDefault

                        If Not AdvantageFramework.GoogleServices.Service.DoubleClickCampaignAdd(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.AdServerAdvertiserID.Value, AdServerID,
                                MediaManagerAdServingDetailViewModel.CampaignID, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.LandingPageName,
                                MediaManagerAdServingDetailViewModel.LandingPageURL, MediaManagerAdServingDetailViewModel.CampaignStartDate, MediaManagerAdServingDetailViewModel.CampaignEndDate, ErrorString) Then

                            Created = False
                            Exit For

                        End If

                    Next

                    AdvantageFramework.GoogleServices.Service.DoubleClickGetCampaigns(Session, False, ViewModel.DCProfileID, ViewModel.AdServerCampaignDataTable, ErrorString)

                End Using

            End If

            CreateCampaigns = Created

        End Function
        Public Function CreatePlacements(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                         ByRef ErrorString As String) As Boolean

            Dim Created As Boolean = True
            Dim TagFormats As IList(Of String) = Nothing
            Dim PlacementGroupID As Nullable(Of Long) = Nothing
            Dim PackageNames As Generic.List(Of PackageName) = Nothing
            Dim MediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel = Nothing
            Dim AdServerSizeID As Long = Nothing
            Dim CreateByPlacementName As Boolean = False
            Dim NewPlacements As Generic.List(Of ViewModels.Media.MediaManagerAdServingDetailViewModel) = Nothing

            NewPlacements = ViewModel.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.CreatePlacementEnabled = True).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            PackageNames = New Generic.List(Of PackageName)

                PackageNames.AddRange(From X In (From Entity In NewPlacements
                                                 Where (Entity.AdServerPlacementID Is Nothing AndAlso
                                                       Entity.IsCancelled = False AndAlso
                                                       Entity.AdServerPlacementGroupID Is Nothing AndAlso
                                                       String.IsNullOrWhiteSpace(Entity.PackageName) = False AndAlso
                                                       Entity.AdServerCampaignID.HasValue AndAlso
                                                       Entity.IsNewPackage = False)
                                                 Select Entity.AdServerCampaignID, Entity.PackageName).Distinct.ToList
                                      Select New PackageName(X.AdServerCampaignID, X.PackageName))

                For Each PackageName In PackageNames

                    MediaManagerAdServingDetailViewModel = (From Entity In NewPlacements
                                                            Where Entity.AdServerCampaignID = PackageName.AdServerCampaignID AndAlso
                                                                  Entity.PackageName = PackageName.PackageName AndAlso
                                                                  Entity.PackageParent = True).FirstOrDefault

                    If MediaManagerAdServingDetailViewModel Is Nothing Then

                        Created = False
                        ErrorString = "Lines part of a package cannot be placed without package parent line(s) included."

                        Exit For

                    End If

                    If Not AdvantageFramework.GoogleServices.Service.DoubleClickPackageAdd(Session, False, ViewModel.DCProfileID,
                                                       MediaManagerAdServingDetailViewModel.AdServerAdvertiserID.Value, MediaManagerAdServingDetailViewModel.AdServerSiteID.Value,
                                                       MediaManagerAdServingDetailViewModel.AdServerCampaignID.Value, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate, MediaManagerAdServingDetailViewModel.CampaignEndDate,
                                                       MediaManagerAdServingDetailViewModel.PackageName, MediaManagerAdServingDetailViewModel.PricingType,
                                                       MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.Quantity,
                                                       MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString, PlacementGroupID) Then

                        Created = False
                        Exit For

                    Else

                        MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID = PlacementGroupID

                        For Each MediaManagerAdServingDetailViewModel In NewPlacements.Where(Function(VM) VM.AdServerCampaignID = PackageName.AdServerCampaignID AndAlso
                                                                                                          VM.PackageName = PackageName.PackageName AndAlso
                                                                                                          Not VM.AdServerPlacementGroupID.HasValue)

                            MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID = PlacementGroupID

                        Next

                    End If

                Next

                If Created Then

                    PackageNames.Clear()

                    PackageNames.AddRange(From X In (From Entity In NewPlacements
                                                     Where (Entity.AdditionalAdSizePlacementCount = 0 AndAlso
                                                           Entity.IsCancelled = False AndAlso
                                                           Entity.AdServerPlacementGroupID Is Nothing AndAlso
                                                           String.IsNullOrWhiteSpace(Entity.PackageName) = False AndAlso
                                                           Entity.AdServerCampaignID.HasValue AndAlso
                                                           Entity.IsNewPackage = True)
                                                     Select Entity.AdServerCampaignID, Entity.PackageName).Distinct.ToList
                                          Select New PackageName(X.AdServerCampaignID, X.PackageName))

                    For Each PackageName In PackageNames

                        MediaManagerAdServingDetailViewModel = (From Entity In NewPlacements
                                                                Where Entity.AdServerCampaignID = PackageName.AdServerCampaignID AndAlso
                                                                      Entity.PackageName = PackageName.PackageName AndAlso
                                                                      Entity.IsNewPackage = True).FirstOrDefault

                        If Not AdvantageFramework.GoogleServices.Service.DoubleClickPackageAdd(Session, False, ViewModel.DCProfileID,
                                                           MediaManagerAdServingDetailViewModel.AdServerAdvertiserID.Value, MediaManagerAdServingDetailViewModel.AdServerSiteID.Value,
                                                           MediaManagerAdServingDetailViewModel.AdServerCampaignID.Value, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate, MediaManagerAdServingDetailViewModel.CampaignEndDate,
                                                           MediaManagerAdServingDetailViewModel.PackageName, MediaManagerAdServingDetailViewModel.PricingType,
                                                           MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.Quantity,
                                                           MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString, PlacementGroupID) Then

                            Created = False
                            Exit For

                        Else

                            MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID = PlacementGroupID

                            For Each MediaManagerAdServingDetailViewModel In NewPlacements.Where(Function(VM) VM.AdServerCampaignID = PackageName.AdServerCampaignID AndAlso
                                                                                                              VM.PackageName = PackageName.PackageName AndAlso
                                                                                                              Not VM.AdServerPlacementGroupID.HasValue)

                                MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID = PlacementGroupID

                            Next

                        End If

                    Next

                    If Created Then

                        For Each MediaManagerAdServingDetailViewModel In NewPlacements.Where(Function(MMASD) MMASD.IsNewPackage = True AndAlso
                                                                                                             MMASD.IsCancelled = False).ToList

                            TagFormats = GetTagFormats(MediaManagerAdServingDetailViewModel.InternetTypeDescription)

                            If MediaManagerAdServingDetailViewModel.InternetPackageDetails.Any(Function(VM) VM.InternetPackageDetail.MediaPlanDetailPackagePlacementNameID.HasValue) Then

                                CreateByPlacementName = True

                            Else

                                CreateByPlacementName = False

                            End If

                            AdServerSizeID = (From Entity In MediaManagerAdServingDetailViewModel.InternetPackageDetails
                                              Where Entity.InternetPackageDetail.AdSizeCode = MediaManagerAdServingDetailViewModel.AdSizeCode AndAlso
                                                    Entity.AdServerSizeID.HasValue
                                              Select Entity.AdServerSizeID.Value).FirstOrDefault

                            If Not AdvantageFramework.GoogleServices.Service.DoubleClickPlacementAdd(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.LineNumbers,
                                                       MediaManagerAdServingDetailViewModel.AdServerCampaignID.Value, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate.Value,
                                                       MediaManagerAdServingDetailViewModel.CampaignEndDate.Value, MediaManagerAdServingDetailViewModel.InternetTypeDescription, MediaManagerAdServingDetailViewModel.AdServerSiteID.Value,
                                                       MediaManagerAdServingDetailViewModel.PlacementName, MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID, PAYMENT_SOURCE, MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate,
                                                       MediaManagerAdServingDetailViewModel.PricingType, AdServerSizeID, TagFormats, MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID,
                                                       True, MediaManagerAdServingDetailViewModel.AdSizeCode, CreateByPlacementName, ViewModel.DictionaryAdServerPlacementIDNames,
                                                       MediaManagerAdServingDetailViewModel.Quantity, MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString) Then

                                Created = False
                                Exit For

                            End If

                        Next

                        For Each MediaManagerAdServingDetailViewModel In NewPlacements.Where(Function(MMASD) MMASD.IsNewPackage = False AndAlso
                                                                                                             MMASD.AdServerPlacementID Is Nothing AndAlso
                                                                                                             MMASD.IsCancelled = False).ToList

                            TagFormats = GetTagFormats(MediaManagerAdServingDetailViewModel.InternetTypeDescription)

                            If Not AdvantageFramework.GoogleServices.Service.DoubleClickPlacementAdd(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.LineNumbers,
                                                           MediaManagerAdServingDetailViewModel.AdServerCampaignID.Value, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate.Value,
                                                           MediaManagerAdServingDetailViewModel.CampaignEndDate.Value, MediaManagerAdServingDetailViewModel.InternetTypeDescription, MediaManagerAdServingDetailViewModel.AdServerSiteID.Value,
                                                           MediaManagerAdServingDetailViewModel.PlacementName, MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID, PAYMENT_SOURCE, MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate,
                                                           MediaManagerAdServingDetailViewModel.PricingType, MediaManagerAdServingDetailViewModel.AdServerSizeID.Value, TagFormats, MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID,
                                                           False, MediaManagerAdServingDetailViewModel.AdSizeCode, CreateByPlacementName, ViewModel.DictionaryAdServerPlacementIDNames,
                                                           MediaManagerAdServingDetailViewModel.Quantity, MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString) Then

                                Created = False
                                Exit For

                            End If

                        Next

                    End If

                End If

            End Using

            CreatePlacements = Created

        End Function
        Public Function UpdatePackageArchived(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                              IsArchived As Boolean, ByRef ErrorString As String) As Boolean

            'objects
            Dim InternetOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderDetail) = Nothing

            UpdatePackageArchived = AdvantageFramework.GoogleServices.Service.DoubleClickSetPackageArchived(Session, False, ViewModel.DCProfileID, ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value, IsArchived, ErrorString)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                InternetOrderDetails = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberPackageName(DbContext, ViewModel.SelectedMediaManagerAdServingDetailViewModel.OrderNumber, ViewModel.SelectedMediaManagerAdServingDetailViewModel.PackageName).ToList

                For Each InternetOrderDetail In InternetOrderDetails

                    If InternetOrderDetail.AdServerPlacementID.HasValue Then

                        AdvantageFramework.GoogleServices.Service.DoubleClickSetPlacementArchived(Session, False, ViewModel.DCProfileID, InternetOrderDetail.AdServerPlacementID.Value, IsArchived, ErrorString)

                    End If

                Next

            End Using

        End Function
        Public Function UpdatePlacementArchived(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                                IsArchived As Boolean, ByRef ErrorString As String) As Boolean

            UpdatePlacementArchived = AdvantageFramework.GoogleServices.Service.DoubleClickSetPlacementArchived(Session, False, ViewModel.DCProfileID, ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementID.Value, IsArchived, ErrorString)

        End Function
        Public Sub SetSelectedMediaManagerAdServingDetailAdServerCampaignDataTable(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                                                                   AdvertiserID As Long)

            If ViewModel.AdServerCampaignDataTable.AsEnumerable().Where(Function(row) row.Field(Of Long?)("AdvertiserID") = AdvertiserID).Any Then

                ViewModel.SelectedMediaManagerAdServingDetailAdServerCampaignDataTable = ViewModel.AdServerCampaignDataTable.AsEnumerable().Where(Function(row) row.Field(Of Long?)("AdvertiserID") = AdvertiserID).CopyToDataTable

            Else

                ViewModel.SelectedMediaManagerAdServingDetailAdServerCampaignDataTable = CreateCampaignDataTable()

            End If

        End Sub
        Public Sub SetSelectedMediaManagerAdServingDetailDictionaryAdServerPlacementIDNames(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                                                                            AdvertiserID As Long, AdServerSiteID As Long)

            Dim ErrorMessage As String = Nothing

            AdvantageFramework.GoogleServices.Service.DoubleClickGetPlacements(Me.Session, False, ViewModel.DCProfileID, {AdvertiserID}, {AdServerSiteID}, ViewModel.DictionaryAdServerPlacementIDNames, ErrorMessage)

        End Sub
        Public Function Save(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                             ByRef ErrorMessage As String) As Boolean


            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
            Dim SqlParameterUserId As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewCampaignID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewAdSizeCode As System.Data.SqlClient.SqlParameter = Nothing
            'Dim SqlParameterNewInternetPlacement1 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewInternetType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetval As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetvalString As System.Data.SqlClient.SqlParameter = Nothing
            Dim CommandText As String = Nothing
            Dim FailedOnce As Boolean = False
            Dim ErrorString As String = ""
            Dim InfoMessage As String = ""
            Dim LineNumber As String() = Nothing
            Dim LineNumbers As IEnumerable(Of Short) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MapExistingAdServerAdvertisers(ViewModel, DbContext)

                CreateAdvantageCampaignsFromAdServerCampaigns(ViewModel, DbContext)

                MapExistingAdServerSites(ViewModel, DbContext)

                For Each MediaManagerAdServingDetailViewModel In ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(ASD) ASD.AdServerPlacementID.HasValue AndAlso ASD.AdServerPlacementManual)

                    LineNumbers = Split(MediaManagerAdServingDetailViewModel.LineNumbers, ",").Select(Function(LN) CShort(LN)).ToArray

                    For Each LN In LineNumbers

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_DETAIL SET AD_SERVER_PLACEMENT_ID={2}, AD_SERVER_CREATED_BY='{3}', AD_SERVER_CREATED_DATETIME=getdate(), AD_SERVER_PLACEMENT_MANUAL=1 WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND AD_SERVER_PLACEMENT_ID IS NULL",
                                MediaManagerAdServingDetailViewModel.OrderNumber, LN, MediaManagerAdServingDetailViewModel.AdServerPlacementID.Value, DbContext.UserCode))

                    Next

                Next

                For Each MediaManagerAdServingDetailViewModel In ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(ASD) ASD.ClearedPlacementID.HasValue)

                    LineNumbers = Split(MediaManagerAdServingDetailViewModel.LineNumbers, ",").Select(Function(LN) CShort(LN)).ToArray

                    For Each LN In LineNumbers

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_PACKAGE_DETAIL SET AD_SERVER_ID=NULL, AD_SERVER_PLACEMENT_ID=NULL, AD_SERVER_CREATED_BY=NULL, AD_SERVER_CREATED_DATETIME=NULL, AD_SERVER_LAST_MODIFIED_BY=NULL, AD_SERVER_LAST_MODIFIED_DATETIME=NULL WHERE ORDER_NBR = {0} AND LINE_NBR = {1}",
                                MediaManagerAdServingDetailViewModel.OrderNumber, LN))

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_DETAIL SET AD_SERVER_ID=NULL, AD_SERVER_PLACEMENT_ID=NULL, AD_SERVER_CREATED_BY=NULL, AD_SERVER_CREATED_DATETIME=NULL, AD_SERVER_LAST_MODIFIED_BY=NULL, AD_SERVER_LAST_MODIFIED_DATETIME=NULL, AD_SERVER_PLACEMENT_MANUAL=NULL, AD_SERVER_PLACEMENT_GROUP_ID=NULL WHERE ORDER_NBR = {0} AND LINE_NBR = {1}",
                                MediaManagerAdServingDetailViewModel.OrderNumber, LN))

                    Next

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_DETAIL SET MODIFIED_DATE=getdate() WHERE ORDER_NBR = {0} AND AD_SERVER_PLACEMENT_ID = {1}",
                                MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.ClearedPlacementID.Value))

                Next

                For Each MediaManagerAdServingDetailViewModel In ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(ASD) ASD.IsNewPackage)

                    For Each InternetPackageDetail In MediaManagerAdServingDetailViewModel.InternetPackageDetails

                        If InternetPackageDetail.ClearedPlacementID.HasValue Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_PACKAGE_DETAIL SET AD_SERVER_ID=NULL, AD_SERVER_PLACEMENT_ID=NULL, AD_SERVER_CREATED_BY=NULL, AD_SERVER_CREATED_DATETIME=NULL, AD_SERVER_LAST_MODIFIED_BY=NULL, AD_SERVER_LAST_MODIFIED_DATETIME=NULL WHERE INTERNET_PACKAGE_DETAIL_ID = {0}",
                                InternetPackageDetail.InternetPackageDetail.ID))

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_DETAIL SET AD_SERVER_ID=NULL, AD_SERVER_PLACEMENT_ID=NULL, AD_SERVER_CREATED_BY=NULL, AD_SERVER_CREATED_DATETIME=NULL, AD_SERVER_LAST_MODIFIED_BY=NULL, AD_SERVER_LAST_MODIFIED_DATETIME=NULL, AD_SERVER_PLACEMENT_MANUAL=NULL, AD_SERVER_PLACEMENT_GROUP_ID=NULL WHERE ORDER_NBR = {0} AND LINE_NBR = {1}",
                                InternetPackageDetail.InternetPackageDetail.OrderNumber, InternetPackageDetail.InternetPackageDetail.LineNumber))

                        End If

                    Next

                Next

                CampaignIDs = (From Entity In ViewModel.MediaManagerAdServingDetailViewModelList
                               Where Entity.UpdateCampaignEntity = True
                               Select Entity.CampaignID.Value).Distinct.ToArray

                If CampaignIDs IsNot Nothing AndAlso CampaignIDs.Count > 0 Then

                    For Each CampaignID In CampaignIDs

                        Campaign = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Campaign).Where(Function(Entity) Entity.ID = CampaignID).FirstOrDefault

                        If Campaign IsNot Nothing Then

                            Campaign.DbContext = DbContext
                            Campaign.StartDate = ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.CampaignID.HasValue AndAlso Entity.CampaignID = CampaignID).FirstOrDefault.CampaignStartDate
                            Campaign.EndDate = ViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.CampaignID.HasValue AndAlso Entity.CampaignID = CampaignID).FirstOrDefault.CampaignEndDate

                            DbContext.UpdateObject(Campaign)
                            DbContext.SaveChanges()

                        End If

                    Next

                End If

                For Each MediaManagerAdServingDetailViewModel In ViewModel.MediaManagerAdServingDetailViewModelList

                    If MediaManagerAdServingDetailViewModel.ReviseUpdateOrder OrElse (MediaManagerAdServingDetailViewModel.HasCampaignID = False AndAlso MediaManagerAdServingDetailViewModel.CampaignID.HasValue) Then

                        LineNumber = MediaManagerAdServingDetailViewModel.LineNumbers.Split(",")

                        For LineCounter As Integer = 0 To UBound(LineNumber)

                            InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(DbContext, MediaManagerAdServingDetailViewModel.OrderNumber, CShort(LineNumber(LineCounter)))

                            If InternetOrderDetail IsNot Nothing AndAlso String.IsNullOrWhiteSpace(InternetOrderDetail.BillingUserCode) Then

                                SqlParameterUserId = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                                SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_nbr_in", SqlDbType.Int)
                                SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_nbr_in", SqlDbType.SmallInt)
                                SqlParameterOrderType = New System.Data.SqlClient.SqlParameter("@order_type_in", SqlDbType.VarChar)

                                SqlParameterNewCampaignID = New System.Data.SqlClient.SqlParameter("@new_campaign_id", SqlDbType.Int)
                                SqlParameterNewAdSizeCode = New System.Data.SqlClient.SqlParameter("@new_ad_size_code", SqlDbType.VarChar)
                                'SqlParameterNewInternetPlacement1 = New System.Data.SqlClient.SqlParameter("@new_internet_placement1", SqlDbType.VarChar)
                                SqlParameterNewInternetType = New System.Data.SqlClient.SqlParameter("@new_internet_type", SqlDbType.VarChar)

                                SqlParameterRetval = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                                SqlParameterRetval.Direction = ParameterDirection.Output
                                SqlParameterRetval.Value = 0

                                SqlParameterRetvalString = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar, -1)
                                SqlParameterRetvalString.Direction = ParameterDirection.Output
                                SqlParameterRetvalString.Value = ""

                                SqlParameterUserId.Value = Session.UserCode
                                SqlParameterOrderNumber.Value = MediaManagerAdServingDetailViewModel.OrderNumber
                                SqlParameterLineNumber.Value = CShort(LineNumber(LineCounter))
                                SqlParameterOrderType.Value = "IN"

                                If MediaManagerAdServingDetailViewModel.CampaignID.HasValue Then

                                    SqlParameterNewCampaignID.Value = MediaManagerAdServingDetailViewModel.CampaignID

                                Else

                                    SqlParameterNewCampaignID.Value = System.DBNull.Value

                                End If

                                If String.IsNullOrWhiteSpace(MediaManagerAdServingDetailViewModel.AdSizeCode) Then

                                    SqlParameterNewAdSizeCode.Value = System.DBNull.Value

                                Else

                                    SqlParameterNewAdSizeCode.Value = MediaManagerAdServingDetailViewModel.AdSizeCode

                                End If

                                'If String.IsNullOrWhiteSpace(MediaManagerAdServingDetailViewModel.InternetPlacement1) Then

                                '    SqlParameterNewInternetPlacement1.Value = System.DBNull.Value

                                'Else

                                '    SqlParameterNewInternetPlacement1.Value = MediaManagerAdServingDetailViewModel.InternetPlacement1

                                'End If


                                If String.IsNullOrWhiteSpace(MediaManagerAdServingDetailViewModel.InternetType) Then

                                    SqlParameterNewInternetType.Value = System.DBNull.Value

                                Else

                                    SqlParameterNewInternetType.Value = MediaManagerAdServingDetailViewModel.InternetType

                                End If

                                CommandText = "exec dbo.advsp_revise_order_ad_serving @user_id, @order_nbr_in, @line_nbr_in, @order_type_in, @new_campaign_id, @new_ad_size_code, @new_internet_type, @ret_val OUTPUT, @ret_val_s OUTPUT"

                                Try

                                    DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterUserId, SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterOrderType,
                                        SqlParameterNewCampaignID, SqlParameterNewAdSizeCode, SqlParameterNewInternetType, SqlParameterRetval, SqlParameterRetvalString)

                                    If SqlParameterRetval.Value <> 0 Then

                                        ErrorString += SqlParameterRetvalString.Value
                                        FailedOnce = True

                                    End If

                                Catch ex As Exception
                                    ErrorString += "Failed trying to save data to the database. Please contact software support."
                                    ErrorString += vbCrLf & ex.Message
                                    FailedOnce = True
                                End Try

                            Else

                                InfoMessage = "One or more orders could not be revised due to it being selected for billing."
                                FailedOnce = True

                            End If

                        Next

                    End If

                Next

            End Using

            If FailedOnce Then

                ErrorMessage += Trim(InfoMessage & "  " & ErrorString)

            End If

            Save = Not FailedOnce

        End Function
        Public Sub DeselectAllDetail(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            ViewModel.SelectedMediaManagerAdServingDetailViewModelList = Nothing

        End Sub
        Public Sub SelectAllDetail(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            ViewModel.SelectedMediaManagerAdServingDetailViewModelList = ViewModel.MediaManagerAdServingDetailViewModelList

        End Sub
        Public Sub SelectedMediaManagerAdServingDetailViewModelChanged(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                                                       MediaManagerAdServingDetailViewModelList As Generic.List(Of AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel))

            ViewModel.SelectedMediaManagerAdServingDetailViewModelList = MediaManagerAdServingDetailViewModelList

        End Sub
        Public Sub SelectedMediaManagerAdServingDetailViewModelChanged(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                                                       MediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel)

            Dim MediaManagerAdServingDetailViewModelList As Generic.List(Of AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel) = Nothing

            MediaManagerAdServingDetailViewModelList = New Generic.List(Of AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel)
            MediaManagerAdServingDetailViewModelList.Add(MediaManagerAdServingDetailViewModel)

            ViewModel.SelectedMediaManagerAdServingDetailViewModelList = MediaManagerAdServingDetailViewModelList

        End Sub
        Public Sub SetAdServingAdvertiserID(ByRef MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            Dim ClientCode As String = Nothing

            If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ClientCode = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.ClientCode

                    For Each Detail In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.ClientCode = ClientCode)

                        Detail.DbContext = DbContext
                        Detail.AdServerAdvertiserID = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerAdvertiserID
                        Detail.ValidateEntity(True)

                    Next

                End Using

            End If

        End Sub
        Public Sub SetAdServingCampaignID(ByRef MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            Dim OrderNumber As Integer = Nothing
            Dim AdServerCampaignID As Long? = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim LandingPageName As String = Nothing
            Dim LandingPageURL As String = Nothing
            Dim ErrorMessage As String = Nothing

            If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    OrderNumber = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.OrderNumber

                    AdServerCampaignID = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerCampaignID

                    If AdServerCampaignID.HasValue AndAlso MediaManagerAdServingViewModel.AdServerCampaignDataTable.AsEnumerable().Where(Function(row) row.Field(Of Long?)("ID") = AdServerCampaignID).Any Then

                        DataRow = MediaManagerAdServingViewModel.AdServerCampaignDataTable.AsEnumerable().Where(Function(row) row.Field(Of Long?)("ID") = AdServerCampaignID).FirstOrDefault

                        If DataRow IsNot Nothing Then

                            AdvantageFramework.GoogleServices.Service.DoubleClickGetDefaultLandingPage(Me.Session, False, MediaManagerAdServingViewModel.DCProfileID, CLng(DataRow("DefaultLandingPageId")), LandingPageName, LandingPageURL, ErrorMessage)

                            Campaign = MediaManagerAdServingViewModel.CampaignList.Where(Function(CL) CL.AdServerCampaignID IsNot Nothing AndAlso
                                                                                                      CL.AdServerCampaignID = AdServerCampaignID.Value).Select(Function(CL) CL).FirstOrDefault

                            For Each Detail In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.OrderNumber = OrderNumber)

                                Detail.DbContext = DbContext
                                Detail.AdServerCampaignID = AdServerCampaignID

                                If Campaign IsNot Nothing Then

                                    Detail.CampaignID = Campaign.ID
                                    Detail.CampaignCode = Campaign.Code

                                End If

                                Detail.CampaignName = DataRow("Name")
                                Detail.CampaignStartDate = DataRow("StartDate")
                                Detail.CampaignEndDate = DataRow("EndDate")
                                Detail.LandingPageName = LandingPageName
                                Detail.LandingPageURL = LandingPageURL

                                Detail.ValidateEntity(True)

                            Next

                        End If

                    Else

                        For Each Detail In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.OrderNumber = OrderNumber)

                            Detail.DbContext = DbContext
                            Detail.AdServerCampaignID = Nothing

                            Detail.CampaignID = Nothing
                            Detail.CampaignName = Nothing
                            Detail.CampaignStartDate = Nothing
                            Detail.CampaignEndDate = Nothing
                            Detail.LandingPageName = Nothing
                            Detail.LandingPageURL = Nothing

                            Detail.ValidateEntity(True)

                        Next

                    End If

                End Using

            End If

        End Sub
        Public Sub SetAdServingPlacementID(ByRef MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel, PlacementID As Long)

            MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementID = PlacementID
            MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementManual = True

        End Sub
        Public Sub SetAdServingSiteID(ByRef MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            Dim VendorCode As String = Nothing

            If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    VendorCode = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.VendorCode

                    For Each Detail In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.VendorCode = VendorCode)

                        Detail.DbContext = DbContext
                        Detail.AdServerSiteID = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerSiteID
                        Detail.ValidateEntity(True)

                    Next

                End Using

            End If

        End Sub
        'Public Sub SetOrderLinePlacement(ByRef MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel, Placement1 As String)

        '    MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.InternetPlacement1 = Placement1
        '    MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.ReviseUpdateOrder = True

        'End Sub
        Public Sub SetUpdateCampaignEntity(MediaManagerAdServingViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel)

            If MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                For Each Detail In MediaManagerAdServingViewModel.MediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.CampaignID.HasValue AndAlso Entity.CampaignID = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.CampaignID)

                    Detail.UpdateCampaignEntity = True
                    Detail.CampaignStartDate = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.CampaignStartDate
                    Detail.CampaignEndDate = MediaManagerAdServingViewModel.SelectedMediaManagerAdServingDetailViewModel.CampaignEndDate

                Next

            End If

        End Sub
        Public Function UpdatePlacements(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                         ByRef ErrorString As String) As Boolean

            Dim Updated As Boolean = True
            Dim AdSizeCodes As IEnumerable(Of String) = Nothing
            Dim AdServerSizeID As Long = 0
            Dim PlacementID As Nullable(Of Long) = Nothing
            Dim TagFormats As IList(Of String) = Nothing
            Dim AdServerPlacementGroupID As Long = 0
            Dim CreateByPlacementName As Boolean = False
            Dim UpdatedPlacementIDs As Generic.List(Of Long) = Nothing
            Dim UpdatedPackageIDs As Generic.List(Of Long) = Nothing
            Dim UpdatePlacementList As Generic.List(Of ViewModels.Media.MediaManagerAdServingDetailViewModel) = Nothing

            UpdatePlacementList = ViewModel.SelectedMediaManagerAdServingDetailViewModelList.Where(Function(Entity) Entity.UpdatePlacementEnabled = True).ToList

            UpdatedPlacementIDs = New Generic.List(Of Long)
            UpdatedPackageIDs = New Generic.List(Of Long)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each MediaManagerAdServingDetailViewModel In UpdatePlacementList.Where(Function(MMASD) MMASD.IsNewPackage = True).ToList

                    MediaManagerAdServingDetailViewModel.LoadAdditionalAdSizes(DbContext)

                    AdSizeCodes = MediaManagerAdServingDetailViewModel.InternetPackageDetails.Where(Function(Entity) Entity.InternetPackageDetail.AdServerPlacementID.HasValue).Select(Function(Entity) Entity.InternetPackageDetail.AdSizeCode).Distinct.ToArray

                    TagFormats = GetTagFormats(MediaManagerAdServingDetailViewModel.InternetTypeDescription)

                    If MediaManagerAdServingDetailViewModel.InternetPackageDetails.Any(Function(VM) VM.InternetPackageDetail.MediaPlanDetailPackagePlacementNameID.HasValue) Then

                        CreateByPlacementName = True

                    Else

                        CreateByPlacementName = False

                    End If

                    If CreateByPlacementName Then

                        If MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.HasValue Then

                            If UpdatedPackageIDs.Contains(MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value) = False Then

                                If Not AdvantageFramework.GoogleServices.Service.DoubleClickPackageUpdate(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value,
                                        MediaManagerAdServingDetailViewModel.AdServerCampaignID, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate,
                                        MediaManagerAdServingDetailViewModel.CampaignEndDate, MediaManagerAdServingDetailViewModel.PackageName, MediaManagerAdServingDetailViewModel.PricingType,
                                        MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.Quantity,
                                        MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString) Then

                                    Updated = False
                                    Exit For

                                Else

                                    UpdatedPackageIDs.Add(MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value)

                                End If

                            End If

                        End If

                        PlacementID = (From Entity In MediaManagerAdServingDetailViewModel.InternetPackageDetails
                                       Where Entity.InternetPackageDetail.MediaPlanDetailPackagePlacementNameID = MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID AndAlso
                                             Entity.InternetPackageDetail.AdServerPlacementID.HasValue
                                       Select Entity.InternetPackageDetail.AdServerPlacementID).FirstOrDefault

                        AdServerSizeID = (From Entity In MediaManagerAdServingDetailViewModel.InternetPackageDetails
                                          Where Entity.InternetPackageDetail.MediaPlanDetailPackagePlacementNameID = MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID AndAlso
                                                Entity.AdServerSizeID.HasValue
                                          Select Entity.AdServerSizeID.Value).FirstOrDefault

                        If PlacementID.HasValue Then

                            If Not AdvantageFramework.GoogleServices.Service.DoubleClickPlacementUpdate(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.LineNumbers,
                                                       PlacementID.Value, MediaManagerAdServingDetailViewModel.PlacementName, MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID,
                                                       MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.PricingType,
                                                       AdServerSizeID, MediaManagerAdServingDetailViewModel.AdServerCampaignID,
                                                       MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate.Value, MediaManagerAdServingDetailViewModel.CampaignEndDate.Value,
                                                       MediaManagerAdServingDetailViewModel.IsNewPackage, MediaManagerAdServingDetailViewModel.AdSizeCode, MediaManagerAdServingDetailViewModel.Quantity,
                                                       MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, CreateByPlacementName, ErrorString) Then

                                Updated = False
                                Exit For

                            End If

                        Else

                            If Not AdvantageFramework.GoogleServices.Service.DoubleClickPlacementAdd(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.LineNumbers,
                                                       MediaManagerAdServingDetailViewModel.AdServerCampaignID.Value, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate.Value,
                                                       MediaManagerAdServingDetailViewModel.CampaignEndDate.Value, MediaManagerAdServingDetailViewModel.InternetTypeDescription, MediaManagerAdServingDetailViewModel.AdServerSiteID.Value,
                                                       MediaManagerAdServingDetailViewModel.PlacementName, MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID, PAYMENT_SOURCE, MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate,
                                                       MediaManagerAdServingDetailViewModel.PricingType, AdServerSizeID, TagFormats, MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID,
                                                       True, MediaManagerAdServingDetailViewModel.AdSizeCode, CreateByPlacementName, ViewModel.DictionaryAdServerPlacementIDNames,
                                                       MediaManagerAdServingDetailViewModel.Quantity, MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString) Then

                                Updated = False
                                Exit For

                            End If

                        End If

                    Else

                        If MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.HasValue Then

                            If UpdatedPackageIDs.Contains(MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value) = False Then

                                If Not AdvantageFramework.GoogleServices.Service.DoubleClickPackageUpdate(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value,
                                    MediaManagerAdServingDetailViewModel.AdServerCampaignID, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate,
                                    MediaManagerAdServingDetailViewModel.CampaignEndDate, MediaManagerAdServingDetailViewModel.PackageName, MediaManagerAdServingDetailViewModel.PricingType,
                                    MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.Quantity,
                                    MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString) Then

                                    Updated = False
                                    Exit For

                                Else

                                    UpdatedPackageIDs.Add(MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value)

                                End If

                            End If

                        End If

                        For Each AdSizeCode In AdSizeCodes

                            AdServerSizeID = (From Entity In MediaManagerAdServingDetailViewModel.InternetPackageDetails
                                              Where Entity.InternetPackageDetail.AdSizeCode = AdSizeCode AndAlso
                                                    Entity.AdServerSizeID.HasValue
                                              Select Entity.AdServerSizeID.Value).FirstOrDefault

                            PlacementID = (From Entity In MediaManagerAdServingDetailViewModel.InternetPackageDetails
                                           Where Entity.InternetPackageDetail.AdSizeCode = AdSizeCode AndAlso
                                                 Entity.InternetPackageDetail.AdServerPlacementID.HasValue
                                           Select Entity.InternetPackageDetail.AdServerPlacementID.Value).FirstOrDefault

                            If UpdatedPlacementIDs.Contains(PlacementID) = False Then

                                If AdvantageFramework.GoogleServices.Service.DoubleClickPlacementUpdate(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.LineNumbers,
                                                       PlacementID.Value, MediaManagerAdServingDetailViewModel.PlacementName, MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID,
                                                       MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.PricingType,
                                                       AdServerSizeID, MediaManagerAdServingDetailViewModel.AdServerCampaignID,
                                                       MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate.Value, MediaManagerAdServingDetailViewModel.CampaignEndDate.Value,
                                                       MediaManagerAdServingDetailViewModel.IsNewPackage, AdSizeCode, MediaManagerAdServingDetailViewModel.Quantity, MediaManagerAdServingDetailViewModel.Rate,
                                                       MediaManagerAdServingDetailViewModel.Cost, CreateByPlacementName, ErrorString) = False Then

                                    Updated = False
                                    Exit For

                                Else

                                    UpdatedPlacementIDs.Add(PlacementID)

                                End If

                            End If

                        Next

                        AdSizeCodes = MediaManagerAdServingDetailViewModel.InternetPackageDetails.Where(Function(Entity) Entity.InternetPackageDetail.AdServerPlacementID Is Nothing).Select(Function(Entity) Entity.InternetPackageDetail.AdSizeCode).Distinct.ToArray

                        For Each AdSizeCode In AdSizeCodes

                            AdServerSizeID = (From Entity In MediaManagerAdServingDetailViewModel.InternetPackageDetails
                                              Where Entity.InternetPackageDetail.AdSizeCode = AdSizeCode AndAlso
                                                    Entity.AdServerSizeID.HasValue
                                              Select Entity.AdServerSizeID.Value).FirstOrDefault

                            If MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.HasValue Then

                                AdServerPlacementGroupID = MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value

                            Else

                                AdServerPlacementGroupID = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)
                                                            Where Entity.InternetOrderOrderNumber = MediaManagerAdServingDetailViewModel.OrderNumber AndAlso
                                                                  Entity.IsActiveRevision = True AndAlso
                                                                  Entity.AdServerPlacementGroupID.HasValue
                                                            Select Entity.AdServerPlacementGroupID.Value).FirstOrDefault

                                If UpdatedPackageIDs.Contains(AdServerPlacementGroupID) = False Then

                                    If AdServerPlacementGroupID Then

                                        If Not AdvantageFramework.GoogleServices.Service.DoubleClickPackageUpdate(Session, False, ViewModel.DCProfileID, AdServerPlacementGroupID,
                                            MediaManagerAdServingDetailViewModel.AdServerCampaignID, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate,
                                            MediaManagerAdServingDetailViewModel.CampaignEndDate, MediaManagerAdServingDetailViewModel.PackageName, MediaManagerAdServingDetailViewModel.PricingType,
                                            MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.Quantity,
                                            MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString) Then

                                            Updated = False
                                            Exit For

                                        Else

                                            UpdatedPackageIDs.Add(AdServerPlacementGroupID)

                                        End If

                                    End If

                                End If

                            End If

                            If Not AdvantageFramework.GoogleServices.Service.DoubleClickPlacementAdd(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.LineNumbers,
                                                           MediaManagerAdServingDetailViewModel.AdServerCampaignID.Value, MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate.Value,
                                                           MediaManagerAdServingDetailViewModel.CampaignEndDate.Value, MediaManagerAdServingDetailViewModel.InternetTypeDescription, MediaManagerAdServingDetailViewModel.AdServerSiteID.Value,
                                                           MediaManagerAdServingDetailViewModel.PlacementName, MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID, PAYMENT_SOURCE, MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate,
                                                           MediaManagerAdServingDetailViewModel.PricingType, AdServerSizeID, TagFormats, AdServerPlacementGroupID,
                                                           MediaManagerAdServingDetailViewModel.IsNewPackage, AdSizeCode, CreateByPlacementName, ViewModel.DictionaryAdServerPlacementIDNames,
                                                           MediaManagerAdServingDetailViewModel.Quantity, MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, ErrorString) Then

                                Updated = False
                                Exit For

                            End If

                        Next

                    End If

                Next

                For Each MediaManagerAdServingDetailViewModel In UpdatePlacementList.Where(Function(MMASD) MMASD.AdServerPlacementID.HasValue AndAlso
                                                                                                           MMASD.IsNewPackage = False).ToList

                    If Not AdvantageFramework.GoogleServices.Service.DoubleClickPlacementUpdate(Session, False, ViewModel.DCProfileID, MediaManagerAdServingDetailViewModel.OrderNumber, MediaManagerAdServingDetailViewModel.LineNumbers,
                                                       MediaManagerAdServingDetailViewModel.AdServerPlacementID.Value, MediaManagerAdServingDetailViewModel.PlacementName, MediaManagerAdServingDetailViewModel.MediaPlanDetailPackagePlacementNameID,
                                                       MediaManagerAdServingDetailViewModel.StartDate, MediaManagerAdServingDetailViewModel.EndDate, MediaManagerAdServingDetailViewModel.PricingType,
                                                       MediaManagerAdServingDetailViewModel.AdServerSizeID, MediaManagerAdServingDetailViewModel.AdServerCampaignID,
                                                       MediaManagerAdServingDetailViewModel.CampaignName, MediaManagerAdServingDetailViewModel.CampaignStartDate.Value, MediaManagerAdServingDetailViewModel.CampaignEndDate.Value,
                                                       MediaManagerAdServingDetailViewModel.IsNewPackage, MediaManagerAdServingDetailViewModel.AdSizeCode, MediaManagerAdServingDetailViewModel.Quantity,
                                                       MediaManagerAdServingDetailViewModel.Rate, MediaManagerAdServingDetailViewModel.Cost, CreateByPlacementName, ErrorString) Then

                        Updated = False
                        Exit For

                    End If

                Next

            End Using

            UpdatePlacements = Updated

        End Function
        Public Function ValidateEntity(MediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel, ByRef IsValid As Boolean) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerAdServingDetailViewModel.DbContext = DbContext

                ErrorText = MediaManagerAdServingDetailViewModel.ValidateEntity(IsValid)

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateEntityProperty(MediaManagerAdServingDetailViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel, PropertyName As String,
                                               ByRef IsValid As Boolean, ByRef Value As Object) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerAdServingDetailViewModel.DbContext = DbContext

                ErrorText = MediaManagerAdServingDetailViewModel.ValidateEntityProperty(PropertyName, IsValid, Value)

            End Using

            ValidateEntityProperty = ErrorText

        End Function
        Public Function RunReport(ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel,
                                  ByRef ErrorString As String) As Boolean

            RunReport = AdvantageFramework.DoubleClick.ProcessReport(Session, ViewModel, ErrorString)

        End Function

#End Region

#End Region

        Private Class PackageName

            Public AdServerCampaignID As Long
            Public PackageName As String

            Public Sub New(AdServerCampaignID As Long, PackageName As String)

                Me.AdServerCampaignID = AdServerCampaignID
                Me.PackageName = PackageName

            End Sub

        End Class

    End Class

End Namespace
