Namespace Controller.Media

    Public Class MediaRequestForProposalController
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

        Private Function GetSyscode(NCCTVSyscodeID As Integer) As Nullable(Of Integer)

            'objetcs
            Dim NCCTVSyscode As AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode = Nothing
            Dim Syscode As Nullable(Of Integer) = Nothing

            Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                NCCTVSyscode = NielsenDbContext.NCCTVSyscodes.Find(NCCTVSyscodeID)

                If NCCTVSyscode IsNot Nothing Then

                    Syscode = NCCTVSyscode.Syscode

                End If

            End Using

            GetSyscode = Syscode

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function GetMediaBroadcastWorksheetMediaType(MediaRFPHeaderID As Integer) As String

            'objects
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim MediaType As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaRFPHeader = DbContext.MediaRFPHeaders.Find(MediaRFPHeaderID)

                If MediaRFPHeader IsNot Nothing Then

                    MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaRFPHeader.MediaBroadcastWorksheetMarketID)

                    If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                        MediaType = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode

                    End If

                End If

            End Using

            GetMediaBroadcastWorksheetMediaType = MediaType

        End Function
        Public Function GetValidWorksheetDemographics(MediaRFPHeaderID As Integer) As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

            'objects
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim RepositoryMediaDemographicList As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic) = Nothing
            Dim MediaDemographicIDs As IEnumerable(Of Integer) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaRFPHeader = AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByID(DbContext, MediaRFPHeaderID)

                If MediaRFPHeader IsNot Nothing Then

                    MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaRFPHeader.MediaBroadcastWorksheetMarketID)

                    If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                        MediaDemographicIDs = {MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.GetValueOrDefault(0), MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID.GetValueOrDefault(0)}

                        RepositoryMediaDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode).
                                                          Where(Function(Entity) MediaDemographicIDs.Contains(Entity.ID)).ToList
                                                          Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                    End If

                End If

            End Using

            If RepositoryMediaDemographicList Is Nothing Then

                RepositoryMediaDemographicList = New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

            End If

            GetValidWorksheetDemographics = RepositoryMediaDemographicList

        End Function
        Public Function GetDaypartRepositoryByMediaTypeCode(DbContext As AdvantageFramework.Database.DbContext, MediaTypeCode As String) As Generic.List(Of AdvantageFramework.DTO.Daypart)

            'objects
            Dim DaypartList As Generic.List(Of AdvantageFramework.DTO.Daypart) = Nothing

            If MediaTypeCode = "T" Then

                DaypartList = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList
                               Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList

            ElseIf MediaTypeCode = "R" Then

                DaypartList = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList
                               Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList

            End If

            GetDaypartRepositoryByMediaTypeCode = DaypartList

        End Function
        Public Function GetRepositoryStatusList() As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            GetRepositoryStatusList = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus)).ToList
                                       Where (EnumObject.Code <> AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.T.ToString AndAlso
                                             EnumObject.Code <> AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.P.ToString)
                                       Select New AdvantageFramework.DTO.ComboBoxItem(EnumObject)).ToList

        End Function
        Public Function Load(MediaBroadcastWorksheetMarketID As Integer) As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel

            'objects
            Dim MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim AddedOrUpdated As Boolean = False

            MediaRequestForProposalViewModel = New AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel()
            MediaRequestForProposalViewModel.IsNielsenSetup = Session.IsNielsenSetup
            MediaRequestForProposalViewModel.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

            MediaRequestForProposalViewModel.RepositoryStatusList = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus)).ToList
                                                                     Select New AdvantageFramework.DTO.ComboBoxItem(EnumObject)).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaRequestForProposalViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)

                If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.HasValue Then

                        MediaRequestForProposalViewModel.WorksheetHasDemos = True

                    End If

                    MediaRequestForProposalViewModel.IsCanadianWorksheet = (MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.CountryID = AdvantageFramework.DTO.Countries.Canada)

                    MediaRequestForProposalViewModel.MediaTypeCode = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode

                    MediaRequestForProposalViewModel.ComscoreMarketNumber = MediaBroadcastWorksheetMarket.Market.ComscoreNewMarketNumber

                    MediaRequestForProposalViewModel.MediaBroadcastWorksheetRatingsServiceID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID

                    MediaRequestForProposalViewModel.RepositoryDaypartList = GetDaypartRepositoryByMediaTypeCode(DbContext, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode)

                    MediaRequestForProposalViewModel.RepositoryMediaDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode).ToList
                                                                                       Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                    MediaRequestForProposalViewModel.RepositoryMarketList = (From Entity In AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext).ToList
                                                                             Where Entity.CountryID = AdvantageFramework.DTO.Countries.Canada
                                                                             Select New AdvantageFramework.DTO.Market(Entity)).ToList

                    StandardComment = AdvantageFramework.Database.Procedures.StandardComment.LoadByOfficeCodeAndApplicationCode(DbContext, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Product.OfficeCode, "Media RFP")

                    If MediaBroadcastWorksheetMarket.RFPGuidelines Is Nothing AndAlso StandardComment IsNot Nothing Then

                        MediaBroadcastWorksheetMarket.RFPGuidelines = StandardComment.HtmlComment
                        DbContext.TryAttach(MediaBroadcastWorksheetMarket)
                        DbContext.Entry(MediaBroadcastWorksheetMarket).State = Entity.EntityState.Modified
                        DbContext.SaveChanges()

                        MediaRequestForProposalViewModel.RFPGuidelines = StandardComment.HtmlComment

                    Else

                        MediaRequestForProposalViewModel.RFPGuidelines = MediaBroadcastWorksheetMarket.RFPGuidelines

                    End If

                End If

                If MediaRequestForProposalViewModel.MediaBroadcastWorksheetRatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    'MediaRequestForProposalViewModel.RepositoryCableNetworkStations = AdvantageFramework.Database.Procedures.ComscoreTVStation.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity)).OrderBy(Function(Entity) Entity.Code).ToList

                    If Me.Session.IsNielsenSetup Then

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            NielsenDbContext.Database.Connection.Open()

                            If AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext).Any Then

                                MediaRequestForProposalViewModel.RepositoryCableNetworkStations = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.LoadWithComscoreStationCode(NielsenDbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity, True)).ToList

                            Else

                                MediaRequestForProposalViewModel.RepositoryCableNetworkStations = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

                            End If

                        End Using

                    Else

                        MediaRequestForProposalViewModel.RepositoryCableNetworkStations = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

                    End If

                Else

                    If MediaRequestForProposalViewModel.IsNielsenSetup Then

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            MediaRequestForProposalViewModel.RepositoryCableNetworkStations = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity, False)).ToList

                        End Using

                    Else

                        MediaRequestForProposalViewModel.RepositoryCableNetworkStations = AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity)).ToList

                    End If

                End If

                VendorCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                               Select Entity.VendorCode).Distinct.ToArray

                Vendors = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                           Where VendorCodes.Contains(Entity.Code)
                           Select Entity).ToArray

                For Each Vendor In Vendors

                    If Not (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.Load(DbContext)
                            Where Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID AndAlso
                                  Entity.VendorCode = Vendor.Code).Any Then

                        MediaRFPHeader = New AdvantageFramework.Database.Entities.MediaRFPHeader

                        MediaRFPHeader.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                        MediaRFPHeader.VendorCode = Vendor.Code

                        If MediaRequestForProposalViewModel.IsNielsenSetup AndAlso Vendor.NCCTVSyscodeID.HasValue Then

                            MediaRFPHeader.Syscode = GetSyscode(Vendor.NCCTVSyscodeID)

                        End If

                        DbContext.MediaRFPHeaders.Add(MediaRFPHeader)

                        AddedOrUpdated = True

                    Else

                        MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.Load(DbContext)
                                          Where Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID AndAlso
                                                Entity.VendorCode = Vendor.Code
                                          Select Entity).FirstOrDefault

                        If MediaRFPHeader IsNot Nothing Then

                            If MediaRequestForProposalViewModel.IsNielsenSetup AndAlso Vendor.NCCTVSyscodeID.HasValue AndAlso MediaRFPHeader.Syscode.HasValue = False Then

                                MediaRFPHeader.Syscode = GetSyscode(Vendor.NCCTVSyscodeID)

                                DbContext.Entry(MediaRFPHeader).State = Entity.EntityState.Modified

                                AddedOrUpdated = True

                            End If

                        End If

                    End If

                Next

                If AddedOrUpdated Then

                    DbContext.SaveChanges()

                End If

                MediaRequestForProposalViewModel.MediaRFPHeaders = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID).Include("MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet").Include("Vendor").ToList
                                                                    Where VendorCodes.Contains(Entity.VendorCode)
                                                                    Select New AdvantageFramework.DTO.Media.RFP.MediaRFPHeader(Entity)).ToList

                MediaRequestForProposalViewModel.BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

            End Using

            Load = MediaRequestForProposalViewModel

        End Function
        Public Sub LoadAvailLines(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            'objects
            Dim VendorName As String = Nothing
            Dim NCCTVSyscode As AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode = Nothing
            Dim IsComscore As Boolean = False

            If MediaRequestForProposalViewModel.SelectedMediaRFPHeader IsNot Nothing Then

                IsComscore = (MediaRequestForProposalViewModel.MediaBroadcastWorksheetRatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore)

                If MediaRequestForProposalViewModel.IsNielsenSetup AndAlso MediaRequestForProposalViewModel.SelectedMediaRFPHeader.NCCTVSyscodeID.HasValue Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        NCCTVSyscode = NielsenDbContext.NCCTVSyscodes.Find(MediaRequestForProposalViewModel.SelectedMediaRFPHeader.NCCTVSyscodeID.Value)

                        If NCCTVSyscode IsNot Nothing Then

                            VendorName = MediaRequestForProposalViewModel.SelectedMediaRFPHeader.VendorName & " / " & NCCTVSyscode.Syscode.ToString & " / " & NCCTVSyscode.SystemName

                        End If

                    End Using

                Else

                    VendorName = MediaRequestForProposalViewModel.SelectedMediaRFPHeader.VendorName

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        LoadDemos(MediaRequestForProposalViewModel)

                        MediaRequestForProposalViewModel.MediaRFPAvailLines.Clear()

                        MediaRequestForProposalViewModel.MediaRFPAvailLines.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLine.LoadByMediaRFPHeaderID(DbContext, MediaRequestForProposalViewModel.SelectedMediaRFPHeader.ID).Include("MediaRFPDemos").Include("MediaRFPAvailLineSpots").Include("MediaRFPHeader.Vendor").Include("MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet").ToList
                                                                                     Select New AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine(VendorName, Entity, IsComscore))

                        For Each MediaRFPAvailLine In MediaRequestForProposalViewModel.MediaRFPAvailLines

                            MediaRFPAvailLine.HasDemosFromImportFile = (MediaRequestForProposalViewModel.WorksheetHasDemos AndAlso MediaRequestForProposalViewModel.MediaRFPDemos.Count > 0)

                            SetRequiredFields(MediaRFPAvailLine)

                            Me.ValidateDTO(DbContext, DataContext, MediaRFPAvailLine, True)

                        Next

                        MediaRequestForProposalViewModel.SelectedMediaRFPHeader.RefreshStatus(DbContext)

                    End Using

                End Using

            End If

        End Sub
        Public Sub LoadDemos(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            If MediaRequestForProposalViewModel.SelectedMediaRFPHeader IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        MediaRequestForProposalViewModel.MediaRFPDemos.Clear()

                        MediaRequestForProposalViewModel.MediaRFPDemos = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)(String.Format("exec dbo.advsp_media_rfp_demos {0}", MediaRequestForProposalViewModel.SelectedMediaRFPHeader.ID)).ToList

                        For Each MediaRFPDemo In MediaRequestForProposalViewModel.MediaRFPDemos

                            MediaRFPDemo.WorksheetHasDemos = MediaRequestForProposalViewModel.WorksheetHasDemos

                            SetRequiredFields(MediaRFPDemo)

                            Me.ValidateDTO(DbContext, DataContext, MediaRFPDemo, True)

                        Next

                    End Using

                End Using

            End If

        End Sub
        Public Sub LoadHeaderStatuses(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            'objects
            Dim VendorName As String = Nothing

            If MediaRequestForProposalViewModel.SelectedMediaRFPHeader IsNot Nothing Then

                VendorName = MediaRequestForProposalViewModel.SelectedMediaRFPHeader.VendorName

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MediaRequestForProposalViewModel.MediaRFPHeaderStatuses.Clear()

                    MediaRequestForProposalViewModel.MediaRFPHeaderStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeaderStatus)(String.Format("exec dbo.advsp_media_rfp_header_statuses {0}", MediaRequestForProposalViewModel.SelectedMediaRFPHeader.ID)).ToList

                End Using

            End If

        End Sub
        Public Sub LoadMarkets(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            If MediaRequestForProposalViewModel.SelectedMediaRFPHeader IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        MediaRequestForProposalViewModel.MediaRFPMarkets.Clear()

                        MediaRequestForProposalViewModel.MediaRFPMarkets = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarket)(String.Format("exec dbo.advsp_media_rfp_markets {0}", MediaRequestForProposalViewModel.SelectedMediaRFPHeader.ID)).ToList

                        For Each MediaRFPMarket In MediaRequestForProposalViewModel.MediaRFPMarkets

                            Me.ValidateDTO(DbContext, DataContext, MediaRFPMarket, True)

                        Next

                    End Using

                End Using

            End If

        End Sub
        Public Sub RefreshMediaRFPHeaders(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            'objects
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim MediaBroadcastWorksheetMarketID As Integer = 0

            VendorCodes = (From Entity In MediaRequestForProposalViewModel.MediaRFPHeaders
                           Select Entity.VendorCode).Distinct.ToArray

            MediaBroadcastWorksheetMarketID = MediaRequestForProposalViewModel.MediaRFPHeaders.FirstOrDefault.MediaBroadcastWorksheetMarketID

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaRequestForProposalViewModel.MediaRFPHeaders = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID).Include("MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet").Include("Vendor").ToList
                                                                    Where VendorCodes.Contains(Entity.VendorCode)
                                                                    Select New AdvantageFramework.DTO.Media.RFP.MediaRFPHeader(Entity)).ToList

            End Using

        End Sub
        Public Sub UpdateDayparts(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel, MediaRFPAvailLineList As Generic.List(Of DTO.Media.RFP.MediaRFPAvailLine))

            'objects
            Dim MediaRFPVendorDaypartCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    MediaRFPVendorDaypartCrossReferences = AdvantageFramework.Database.Procedures.MediaRFPVendorDaypartCrossReference.LoadByVendorCode(DbContext, MediaRequestForProposalViewModel.SelectedMediaRFPHeader.VendorCode).ToList

                    For Each MediaRFPAvailLine In MediaRFPAvailLineList

                        If Not MediaRFPAvailLine.DaypartID.HasValue Then

                            If MediaRFPVendorDaypartCrossReferences.Where(Function(DCR) DCR.VendorDaypartCode.ToUpper = MediaRFPAvailLine.DaypartName.ToUpper AndAlso Not MediaRFPAvailLine.DaypartID.HasValue).Any Then

                                MediaRFPAvailLine.DaypartID = MediaRFPVendorDaypartCrossReferences.Where(Function(DCR) DCR.VendorDaypartCode.ToUpper = MediaRFPAvailLine.DaypartName.ToUpper).First.DaypartID

                                MediaRFPAvailLine.Modified = True

                                ValidateDTO(DbContext, DataContext, MediaRFPAvailLine, True)

                            End If

                        End If

                    Next

                End Using

            End Using

        End Sub
        Public Sub UpdateMarkets(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel, MediaRFPMarketList As Generic.List(Of DTO.Media.RFP.MediaRFPMarket))

            'objects
            Dim MediaRFPMarketCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    MediaRFPMarketCrossReferences = AdvantageFramework.Database.Procedures.MediaRFPMarketCrossReference.Load(DbContext).ToList

                    For Each MediaRFPMarket In MediaRFPMarketList

                        If String.IsNullOrWhiteSpace(MediaRFPMarket.MarketCode) Then

                            If MediaRFPMarketCrossReferences.Where(Function(DCR) DCR.SourceMarketCode = MediaRFPMarket.SourceMarketName AndAlso String.IsNullOrWhiteSpace(MediaRFPMarket.MarketCode)).Any Then

                                MediaRFPMarket.MarketCode = MediaRFPMarketCrossReferences.Where(Function(DCR) DCR.SourceMarketCode = MediaRFPMarket.SourceMarketName).First.MarketCode

                                MediaRFPMarket.Modified = True

                                ValidateDTO(DbContext, DataContext, MediaRFPMarket, True)

                            End If

                        End If

                    Next

                End Using

            End Using

        End Sub
        Public Sub SaveAvailLines(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            'objects
            Dim ModifiedMediaRFPAvailLines As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine) = Nothing
            Dim MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine = Nothing

            ModifiedMediaRFPAvailLines = MediaRequestForProposalViewModel.MediaRFPAvailLines.Where(Function(AL) AL.Modified = True).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                For Each ModifiedMediaRFPAvailLine In ModifiedMediaRFPAvailLines

                    MediaRFPAvailLine = AdvantageFramework.Database.Procedures.MediaRFPAvailLine.LoadByID(DbContext, ModifiedMediaRFPAvailLine.ID)

                    If MediaRFPAvailLine IsNot Nothing AndAlso DbContext.TryAttach(MediaRFPAvailLine) Then

                        If ModifiedMediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.D.ToString Then

                            DbContext.Database.ExecuteSqlCommand("DELETE dbo.MEDIA_RFP_AVAILABLE_LINE_SPOT WHERE MEDIA_RFP_AVAILABLE_LINE_ID = {0}", MediaRFPAvailLine.ID)

                            DbContext.Database.ExecuteSqlCommand("DELETE dbo.MEDIA_RFP_DEMO WHERE MEDIA_RFP_AVAILABLE_LINE_ID = {0}", MediaRFPAvailLine.ID)

                            DbContext.MediaRFPAvailLines.Remove(MediaRFPAvailLine)

                        Else

                            ModifiedMediaRFPAvailLine.SaveToEntity(MediaRFPAvailLine)

                            DbContext.Entry(MediaRFPAvailLine).State = Entity.EntityState.Modified

                        End If

                    End If

                Next

                DbContext.SaveChanges()

                DbContext.Configuration.AutoDetectChangesEnabled = True

            End Using

        End Sub
        Public Sub SaveDemos(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            'objects
            Dim ModifiedMediaRFPDemos As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) = Nothing

            ModifiedMediaRFPDemos = MediaRequestForProposalViewModel.MediaRFPDemos.Where(Function(AL) AL.Modified = True).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each ModifiedMediaRFPDemo In ModifiedMediaRFPDemos

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE d SET MEDIA_DEMO_ID = {0} " &
                                                                       "FROM dbo.MEDIA_RFP_DEMO d " &
                                                                       "INNER JOIN dbo.MEDIA_RFP_AVAILABLE_LINE al ON d.MEDIA_RFP_AVAILABLE_LINE_ID = al.MEDIA_RFP_AVAILABLE_LINE_ID AND al.MEDIA_RFP_HEADER_ID = {6} " &
                                                                       "WHERE ID_RANK = '{1}' AND [TYPE] = '{2}' AND [GROUP] = '{3}' AND AGE_FROM = {4} AND AGE_TO = {5}",
                        ModifiedMediaRFPDemo.MediaDemoID, ModifiedMediaRFPDemo.IDRank, ModifiedMediaRFPDemo.Type, ModifiedMediaRFPDemo.Group, ModifiedMediaRFPDemo.AgeFrom, ModifiedMediaRFPDemo.AgeTo, MediaRequestForProposalViewModel.SelectedMediaRFPHeader.ID))

                Next

            End Using

        End Sub
        Public Sub SaveMarkets(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            'objects
            Dim ModifiedMediaRFPMarkets As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarket) = Nothing

            ModifiedMediaRFPMarkets = MediaRequestForProposalViewModel.MediaRFPMarkets.Where(Function(AL) AL.Modified = True).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each ModifiedMediaRFPMarket In ModifiedMediaRFPMarkets

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE d SET MARKET_CODE = '{0}' " &
                                                                       "FROM dbo.MEDIA_RFP_DEMO d " &
                                                                       "INNER JOIN dbo.MEDIA_RFP_AVAILABLE_LINE al ON d.MEDIA_RFP_AVAILABLE_LINE_ID = al.MEDIA_RFP_AVAILABLE_LINE_ID AND al.MEDIA_RFP_HEADER_ID = {1} " &
                                                                       "WHERE d.SOURCE_MARKET_NAME = '{2}'",
                        ModifiedMediaRFPMarket.MarketCode, ModifiedMediaRFPMarket.MediaRFPHeaderID, ModifiedMediaRFPMarket.SourceMarketName))

                Next

            End Using

        End Sub
        Public Sub SaveMediaRFPHeaders(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            'objects
            Dim ModifiedMediaRFPHeaders As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader) = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing

            ModifiedMediaRFPHeaders = MediaRequestForProposalViewModel.MediaRFPHeaders.Where(Function(AL) AL.Modified = True).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each ModifiedMediaRFPHeader In ModifiedMediaRFPHeaders

                    MediaRFPHeader = DbContext.MediaRFPHeaders.Find(ModifiedMediaRFPHeader.ID)

                    If MediaRFPHeader IsNot Nothing Then

                        MediaRFPHeader.CommentToVendor = ModifiedMediaRFPHeader.CommentToVendor
                        MediaRFPHeader.RequestDate = ModifiedMediaRFPHeader.RequestDate
                        MediaRFPHeader.DueDate = ModifiedMediaRFPHeader.DueDate
                        MediaRFPHeader.TimeDue = ModifiedMediaRFPHeader.TimeDue

                        DbContext.TryAttach(MediaRFPHeader)

                        If DbContext.SaveChanges() = 1 Then

                            ModifiedMediaRFPHeader.Modified = False

                        End If

                    End If

                Next

            End Using

        End Sub
        Public Function SaveMediaBroadcastWorksheetMarketRFPGuidelines(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel) As Boolean

            'objects
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim Saved As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaRequestForProposalViewModel.MediaBroadcastWorksheetMarketID)

                If MediaBroadcastWorksheetMarket IsNot Nothing Then

                    MediaBroadcastWorksheetMarket.RFPGuidelines = MediaRequestForProposalViewModel.RFPGuidelines

                    DbContext.TryAttach(MediaBroadcastWorksheetMarket)
                    DbContext.Entry(MediaBroadcastWorksheetMarket).State = Entity.EntityState.Modified

                    If DbContext.SaveChanges() = 1 Then

                        Saved = True

                    End If

                End If

            End Using

            SaveMediaBroadcastWorksheetMarketRFPGuidelines = Saved

        End Function
        Private Sub SetRatings(DbContext As AdvantageFramework.Database.DbContext, MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer))

            'objects
            Dim MediaBroadcastWorksheetController As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
            Dim Program As String = Nothing
            Dim NielsenRadioMarketNumber As Integer = 0

            MediaBroadcastWorksheetController = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Session)

            For Each MediaBroadcastWorksheetMarketDetail In DbContext.MediaBroadcastWorksheetMarketDetails.Include("Vendor").Include("MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet").Include("MediaBroadcastWorksheetMarketDetailDates").Where(Function(Entity) MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.ID))

                Program = MediaBroadcastWorksheetMarketDetail.Program

                If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.HasValue AndAlso Me.Session.IsNielsenSetup Then

                    If String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketDetail.Days) = False AndAlso String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketDetail.StartTime) = False AndAlso
                            String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketDetail.EndTime) = False Then

                        If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypeCodes.T.ToString Then

                            If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue Then

                                If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.IsCable AndAlso
                                        MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioGeographyID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.CDMA Then

                                    MediaBroadcastWorksheetController.Edit_GetTVCableRatingAndShareData(DbContext, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.Value, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market.NielsenTVCode,
                                                                                                        MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID, MediaBroadcastWorksheetMarketDetail)

                                Else

                                    MediaBroadcastWorksheetController.Edit_GetTVRatingAndShareData(DbContext, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.Value, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market.NielsenTVCode,
                                                                                                   MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID, MediaBroadcastWorksheetMarketDetail)

                                End If

                            End If

                        ElseIf MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypeCodes.R.ToString Then

                            If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue Then

                                If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen AndAlso
                                        String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market.NielsenRadioCode) = False Then

                                    NielsenRadioMarketNumber = CInt(MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market.NielsenRadioCode)

                                ElseIf MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan AndAlso
                                        MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market.EastlanRadioCode.GetValueOrDefault(0) > 0 Then

                                    NielsenRadioMarketNumber = CInt(MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market.EastlanRadioCode.GetValueOrDefault(0))

                                End If

                                If NielsenRadioMarketNumber > 0 Then

                                    MediaBroadcastWorksheetController.Edit_GetRadioRatingAndShareData(DbContext, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.Value,
                                                                                                      NielsenRadioMarketNumber, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket, MediaBroadcastWorksheetMarketDetail)

                                End If

                            End If

                            'ElseIf MediaBroadcastWorksheetEditViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.NetworkTV Then

                            '	Edit_GetRatingAndShareData(DbContext, MediaBroadcastWorksheetEditViewModel.Worksheet.PrimaryMediaDemographicID.Value, MediaBroadcastWorksheetMarket.Market.NielsenTVDMACode,
                            '							   MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value, MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID, MediaBroadcastWorksheetMarketDetail)

                        End If

                    End If

                End If

                MediaBroadcastWorksheetMarketDetail.Program = Program

                DbContext.Entry(MediaBroadcastWorksheetMarketDetail).State = Entity.EntityState.Modified

            Next

            DbContext.SaveChanges()

        End Sub
        Public Function AddToWorksheet(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                       ByRef ErrorMessage As String, OmitSpots As Boolean) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim MediaBroadcastWorksheetController As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
            Dim MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Daypart As AdvantageFramework.DTO.Daypart = Nothing
            Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim MediaRFPAvailLineSpots As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailID As Integer? = Nothing
            Dim MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaRFPAvailLines As Dictionary(Of Integer, Integer) = Nothing
            Dim AllMediaRFPAvailLineIDs As IEnumerable(Of Integer) = Nothing
            Dim AllMediaRFPDemos As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPDemo) = Nothing
            Dim AllMediaRFPAvailLineSpots As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot) = Nothing
            Dim ComscoreTVStation As AdvantageFramework.Database.Entities.ComscoreTVStation = Nothing
            Dim RevisionNumber As Integer = 0
            Dim MediaBroadcastWorksheetMarketManageVendorsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketManageVendorsViewModel = Nothing
            Dim SelectedWorksheetMarketDetailVendors As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor) = Nothing
            Dim WorksheetMarketDetailVendor As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor = Nothing
            Dim MediaBroadcastWorksheetMarketSubmarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketSubmarket = Nothing
            Dim MediaBroadcastWorksheetMarketDetailSubmarketDemo As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo = Nothing
            Dim MediaRFPDemoImpressions As AdvantageFramework.Database.Entities.MediaRFPDemo = Nothing

            MediaRFPAvailLines = New Dictionary(Of Integer, Integer)

            SelectedWorksheetMarketDetailVendors = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    RowIndexes = New Generic.List(Of Integer)

                    MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaRequestForProposalViewModel.SelectedMediaRFPHeader.MediaBroadcastWorksheetMarketID)

                    MediaBroadcastWorksheetController = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

                    MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetController.MarketDetails_Load(MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ID, MediaBroadcastWorksheetMarket.ID)

                    AllMediaRFPAvailLineIDs = MediaRequestForProposalViewModel.MediaRFPAvailLines.Where(Function(AL) AL.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.P.ToString AndAlso
                                                                                                                     AL.HasError = False).Select(Function(Entity) Entity.ID).ToArray

                    AllMediaRFPDemos = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPDemo.Load(DbContext)
                                        Where AllMediaRFPAvailLineIDs.Contains(Entity.MediaRFPAvailLineID)
                                        Select Entity).ToList

                    AllMediaRFPAvailLineSpots = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLineSpot.Load(DbContext)
                                                 Where AllMediaRFPAvailLineIDs.Contains(Entity.MediaRFPAvailLineID)
                                                 Select Entity).ToList

                    If MediaBroadcastWorksheetMarketDetailsViewModel.IsMaxRevisionNumber Then

                        RevisionNumber = MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarketRevisionNumber

                    End If

                    For Each MediaRFPAvailLine In MediaRequestForProposalViewModel.MediaRFPAvailLines.Where(Function(AL) AL.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.P.ToString AndAlso
                                                                                                                         AL.HasError = False).ToList

                        If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = MediaRFPAvailLine.VendorCode).Any = False Then

                            If SelectedWorksheetMarketDetailVendors.Where(Function(V) V.VendorCode = MediaRFPAvailLine.VendorCode).Any = False Then

                                WorksheetMarketDetailVendor = New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor
                                WorksheetMarketDetailVendor.Selected = False
                                WorksheetMarketDetailVendor.VendorCode = MediaRFPAvailLine.VendorCode

                                SelectedWorksheetMarketDetailVendors.Add(WorksheetMarketDetailVendor)

                            End If

                        End If

                    Next

                    MediaBroadcastWorksheetMarketManageVendorsViewModel = MediaBroadcastWorksheetController.MarketManageVendors_Load(MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ID, MediaBroadcastWorksheetMarket.ID, RevisionNumber)

                    If SelectedWorksheetMarketDetailVendors.Count > 0 Then

                        MediaBroadcastWorksheetMarketManageVendorsViewModel.SelectedWorksheetMarketDetailVendors = SelectedWorksheetMarketDetailVendors

                        MediaBroadcastWorksheetController.MarketManageVendors_Add(MediaBroadcastWorksheetMarketManageVendorsViewModel, ErrorMessage)

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            Throw New Exception(ErrorMessage)

                        End If

                        MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetController.MarketDetails_Load(MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ID, MediaBroadcastWorksheetMarket.ID)

                    End If

                    For Each MediaRFPAvailLine In MediaRequestForProposalViewModel.MediaRFPAvailLines.Where(Function(AL) AL.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.P.ToString AndAlso
                                                                                                                         AL.HasError = False).ToList

                        If Not MediaRFPAvailLine.MediaBroadcastWorksheetMarketDetailID.HasValue Then

                            MediaBroadcastWorksheetController.MarketDetails_AddNewDataEntryRow(MediaBroadcastWorksheetMarketDetailsViewModel, MediaRFPAvailLine.VendorCode)

                            MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.BeginLoadData()

                            DataRow = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Last

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = MediaRFPAvailLine.VendorCode) Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).FirstOrDefault(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = MediaRFPAvailLine.VendorCode)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString)

                            '    If MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).FirstOrDefault(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = MediaRFPAvailLine.VendorCode)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString)
                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).FirstOrDefault(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = MediaRFPAvailLine.VendorCode)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString)
                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString) = 0
                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).FirstOrDefault(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = MediaRFPAvailLine.VendorCode)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString)

                            '    ElseIf MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString) = 0
                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString) = False
                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).FirstOrDefault(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorCode.ToString) = MediaRFPAvailLine.VendorCode)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString)
                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString) = 0

                            '        'ElseIf MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.NetworkTV Then

                            '        '	DataRow(MarketDetailsColumns.VendorNielsenTVStationCode.ToString) = 0
                            '        '	DataRow(MarketDetailsColumns.VendorIsCableSystem.ToString) = False
                            '        '	DataRow(MarketDetailsColumns.VendorNielsenRadioStationComboID.ToString) = 0
                            '        '	DataRow(MarketDetailsColumns.VendorNCCTVSyscodeID.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).FirstOrDefault(Function(DR) DR(MarketDetailsColumns.VendorCode.ToString) = VendorCode)(MarketDetailsColumns.VendorNCCTVSyscodeID.ToString)

                            '    End If

                            'Else

                            '    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaRFPAvailLine.VendorCode)

                            '    If Vendor IsNot Nothing Then

                            '        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorName.ToString) = Vendor.Name

                            '        If MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                            '            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString) = Vendor.NielsenTVStationCode.GetValueOrDefault(0)
                            '            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString) = Vendor.IsCableSystem
                            '            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString) = 0
                            '            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString) = If(Vendor.IsCableSystem, Vendor.NCCTVSyscodeID.GetValueOrDefault(0), 0)

                            '        ElseIf MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                            '            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNielsenTVStationCode.ToString) = 0
                            '            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorIsCableSystem.ToString) = False

                            '            If MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                            '                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString) = Vendor.NielsenRadioStationComboID.GetValueOrDefault(0)

                            '            Else

                            '                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorRadioStationComboID.ToString) = Vendor.EastlanRadioStationComboID.GetValueOrDefault(0)

                            '            End If

                            '            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.VendorNCCTVSyscodeID.ToString) = 0

                            '            'ElseIf MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.NetworkTV Then

                            '            '	DataRow(MarketDetailsColumns.VendorNielsenTVStationCode.ToString) = 0
                            '            '	DataRow(MarketDetailsColumns.VendorIsCableSystem.ToString) = False
                            '            '	DataRow(MarketDetailsColumns.VendorNielsenRadioStationComboID.ToString) = 0
                            '            '	DataRow(MarketDetailsColumns.VendorNCCTVSyscodeID.ToString) = Vendor.NCCTVSyscodeID.GetValueOrDefault(0)

                            '        End If

                            '    End If

                            'End If

                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString) = String.Empty
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString) = System.DBNull.Value
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookProgram.ToString) = String.Empty
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString) = String.Empty
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Product.ToString) = String.Empty
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Piggyback.ToString) = String.Empty

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.Length > 0 AndAlso MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarket.Length > 0 Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarket.Length

                            'ElseIf MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.Length > 0 AndAlso MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarket.Length = 0 Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.Length

                            'ElseIf MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.Length = 0 AndAlso MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarket.Length > 0 Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarket.Length

                            'Else

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = 0

                            'End If

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString) = If(String.IsNullOrWhiteSpace(MediaRFPAvailLine.Comments), String.Empty, MediaRFPAvailLine.Comments)
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString) = False
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString) = False
                            'DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderStatus.ToString) = CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered)
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.OrderComments.ToString) = String.Empty
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = MediaRFPAvailLine.SpotLength

                            If MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString) = If(Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.Program), MediaRFPAvailLine.Program, If(Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.AvailName), MediaRFPAvailLine.AvailName, ""))

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) = MediaRFPAvailLine.StartTime
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) = MediaRFPAvailLine.EndTime

                            If MediaRFPAvailLine.DaypartID.HasValue Then

                                Try

                                    Daypart = MediaBroadcastWorksheetMarketDetailsViewModel.Dayparts.FirstOrDefault(Function(DP) DP.ID = MediaRFPAvailLine.DaypartID.Value)

                                Catch ex As Exception
                                    Daypart = Nothing
                                End Try

                            Else

                                Daypart = Nothing

                            End If

                            If Daypart IsNot Nothing Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString) = Daypart.Code

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString) = String.Empty

                            End If

                            DaysAndTime = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString)

                            DaysAndTime.Sunday = MediaRFPAvailLine.Sunday
                            DaysAndTime.Monday = MediaRFPAvailLine.Monday
                            DaysAndTime.Tuesday = MediaRFPAvailLine.Tuesday
                            DaysAndTime.Wednesday = MediaRFPAvailLine.Wednesday
                            DaysAndTime.Thursday = MediaRFPAvailLine.Thursday
                            DaysAndTime.Friday = MediaRFPAvailLine.Friday
                            DaysAndTime.Saturday = MediaRFPAvailLine.Saturday
                            DaysAndTime.StartTime = MediaRFPAvailLine.StartTime
                            DaysAndTime.EndTime = MediaRFPAvailLine.EndTime

                            If String.IsNullOrWhiteSpace(MediaRFPAvailLine.Days) = False Then

                                DaysAndTime.Days = MediaRFPAvailLine.Days

                            End If

                            If MediaRFPAvailLine.IsComscore AndAlso String.IsNullOrWhiteSpace(MediaRFPAvailLine.ComscoreTVStationCallLetters) = False Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString) = MediaRFPAvailLine.ComscoreTVStationCallLetters

                            ElseIf Not String.IsNullOrWhiteSpace(MediaRFPAvailLine.CableNetworkStationCode) Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString) = MediaRFPAvailLine.CableNetworkStationCode

                            End If

                            If MediaRFPAvailLine.IsComscore Then

                                If MediaBroadcastWorksheetMarketDetailsViewModel.CableNetworkStations.Where(Function(Entity) Entity.Code = MediaRFPAvailLine.ComscoreTVStationCallLetters AndAlso Entity.IsInactive = False).Count = 1 Then

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.CableNetworkStations.Where(Function(Entity) Entity.Code = MediaRFPAvailLine.ComscoreTVStationCallLetters AndAlso Entity.IsInactive = False).First.NielsenTVStationCode

                                End If

                            ElseIf MediaRFPAvailLine.CableNetworkNielsenTVStationCode.HasValue Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString) = MediaRFPAvailLine.CableNetworkNielsenTVStationCode.Value

                            ElseIf MediaRFPAvailLine.CableNetworkNielsenTVStationCode.HasValue = False Then

                                If MediaBroadcastWorksheetMarketDetailsViewModel.CableNetworkStations.Where(Function(Entity) Entity.Code = MediaRFPAvailLine.CableNetworkStationCode AndAlso Entity.IsInactive = False).Count = 1 Then

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString) = MediaBroadcastWorksheetMarketDetailsViewModel.CableNetworkStations.Where(Function(Entity) Entity.Code = MediaRFPAvailLine.CableNetworkStationCode AndAlso Entity.IsInactive = False).First.NielsenTVStationCode

                                End If

                            End If

                            If MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.PrimaryMediaDemographicID.HasValue Then

                                If MediaBroadcastWorksheetMarketDetailsViewModel.DoesWorksheetAllowSubmarkets = True Then 'DoesWorksheetAllowSubmarkets is limited to just Canadian TV

                                    MediaRFPDemo = (From Entity In AllMediaRFPDemos
                                                    Where Entity.MediaDemoID = MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.PrimaryMediaDemographicID.Value AndAlso
                                                          Entity.Type.ToUpper.StartsWith("RATING") AndAlso
                                                          Entity.MediaRFPAvailLineID = MediaRFPAvailLine.ID AndAlso
                                                          Entity.MarketCode = MediaBroadcastWorksheetMarket.MarketCode
                                                    Select Entity).FirstOrDefault

                                Else

                                    MediaRFPDemo = (From Entity In AllMediaRFPDemos
                                                    Where Entity.MediaDemoID = MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.PrimaryMediaDemographicID.Value AndAlso
                                                          Entity.Type.ToUpper.StartsWith("RATING") AndAlso
                                                          Entity.MediaRFPAvailLineID = MediaRFPAvailLine.ID
                                                    Select Entity).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                                End If

                                If MediaRFPDemo IsNot Nothing Then

                                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                                        If MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString) = MediaRFPDemo.Value
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        End If

                                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                                        If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString) = Math.Round(MediaRFPDemo.Value, 1)
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        End If

                                    End If

                                End If

                                MediaRFPDemo = (From Entity In AllMediaRFPDemos
                                                Where Entity.MediaDemoID = MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.PrimaryMediaDemographicID.Value AndAlso
                                                      Entity.Type.ToUpper.StartsWith("IMPRESSION") AndAlso
                                                      Entity.MediaRFPAvailLineID = MediaRFPAvailLine.ID
                                                Select Entity).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                                If MediaRFPDemo IsNot Nothing Then

                                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                                        If MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString) = MediaRFPDemo.Value
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        End If

                                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                                        If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString) = MediaRFPDemo.Value
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        End If

                                    End If

                                End If

                            End If

                            If MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID.HasValue Then

                                If MediaBroadcastWorksheetMarketDetailsViewModel.DoesWorksheetAllowSubmarkets = True Then 'DoesWorksheetAllowSubmarkets is limited to just Canadian TV

                                    MediaRFPDemo = (From Entity In AllMediaRFPDemos
                                                    Where Entity.MediaDemoID = MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID.Value AndAlso
                                                          Entity.Type.ToUpper.StartsWith("RATING") AndAlso
                                                          Entity.MediaRFPAvailLineID = MediaRFPAvailLine.ID AndAlso
                                                          Entity.MarketCode = MediaBroadcastWorksheetMarket.MarketCode
                                                    Select Entity).FirstOrDefault

                                Else

                                    MediaRFPDemo = (From Entity In AllMediaRFPDemos
                                                    Where Entity.MediaDemoID = MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID.Value AndAlso
                                                          Entity.Type.ToUpper.StartsWith("RATING") AndAlso
                                                          Entity.MediaRFPAvailLineID = MediaRFPAvailLine.ID
                                                    Select Entity).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                                End If

                                If MediaRFPDemo IsNot Nothing Then

                                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                                        If MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryRating.ToString) = MediaRFPDemo.Value
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        End If

                                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                                        If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQHRating.ToString) = Math.Round(MediaRFPDemo.Value, 1)
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedRating.ToString) = MediaRFPDemo.Value

                                        End If

                                    End If

                                End If

                                MediaRFPDemo = (From Entity In AllMediaRFPDemos
                                                Where Entity.MediaDemoID = MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID.Value AndAlso
                                                      Entity.Type.ToUpper.StartsWith("IMPRESSION") AndAlso
                                                      Entity.MediaRFPAvailLineID = MediaRFPAvailLine.ID
                                                Select Entity).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                                If MediaRFPDemo IsNot Nothing Then

                                    If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "T" Then

                                        If MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryImpressions.ToString) = MediaRFPDemo.Value
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        End If

                                    ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode = "R" Then

                                        If MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue = False Then

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryAQH.ToString) = MediaRFPDemo.Value
                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        Else

                                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedImpressions.ToString) = MediaRFPDemo.Value

                                        End If

                                    End If

                                End If

                            End If

                            MediaRFPAvailLineSpots = (From Entity In AllMediaRFPAvailLineSpots
                                                      Where Entity.WeekDate >= MediaRFPAvailLine.StartDate.Value AndAlso
                                                            Entity.WeekDate <= MediaRFPAvailLine.EndDate.Value AndAlso
                                                            Entity.MediaRFPAvailLineID = MediaRFPAvailLine.ID
                                                      Select Entity).ToList

                            If MediaRFPAvailLineSpots IsNot Nothing AndAlso MediaRFPAvailLineSpots.Count > 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString) = MediaRFPAvailLineSpots.OrderBy(Function(Spot) Spot.WeekDate).First.Rate

                            End If

                            'MediaBroadcastWorksheetController.MarketDetails_DefaultRateChanging(MediaBroadcastWorksheetMarketDetailsViewModel, MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.IndexOf(DataRow), MediaRFPAvailLine.Rate, 0)

                            For Each AllowSpotsToBeEnteredDate In MediaBroadcastWorksheetMarketDetailsViewModel.AllowSpotsToBeEnteredDates.Keys.OfType(Of Date)

                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.AllowSpotsToBeEnteredDates.Item(AllowSpotsToBeEnteredDate)) = False

                            Next

                            For Each OrderStatusDate In MediaBroadcastWorksheetMarketDetailsViewModel.OrderStatusDates.Keys.OfType(Of Date)

                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.OrderStatusDates.Item(OrderStatusDate)) = CInt(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered)

                            Next

                            For Each MediaRFPAvailLineSpot In MediaRFPAvailLineSpots

                                If MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.ContainsKey(MediaRFPAvailLineSpot.WeekDate) Then

                                    If MediaBroadcastWorksheetMarketDetailsViewModel.HiatusDataTable.Rows(0).Item(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(MediaRFPAvailLineSpot.WeekDate)) = False Then

                                        DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(MediaRFPAvailLineSpot.WeekDate)) = If(OmitSpots, 0, MediaRFPAvailLineSpot.Quantity)

                                        DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.AllowSpotsToBeEnteredDates.Item(MediaRFPAvailLineSpot.WeekDate)) = True

                                    Else

                                        DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.AllowSpotsToBeEnteredDates.Item(MediaRFPAvailLineSpot.WeekDate)) = False

                                    End If

                                Else

                                    For Each Key In MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Keys

                                        If MediaRFPAvailLineSpot.WeekDate >= CDate(Key) AndAlso MediaRFPAvailLineSpot.WeekDate <= DateAdd(DateInterval.Day, 6, CDate(Key)) Then

                                            If MediaBroadcastWorksheetMarketDetailsViewModel.HiatusDataTable.Rows(0).Item(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(Key)) = False Then

                                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(Key)) = If(OmitSpots, 0, MediaRFPAvailLineSpot.Quantity)

                                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.AllowSpotsToBeEnteredDates.Item(Key)) = True

                                            End If

                                            Exit For

                                        ElseIf MediaRFPAvailLineSpot.WeekDate <= CDate(Key) AndAlso MediaRFPAvailLineSpot.WeekDate.AddDays(6) >= CDate(Key) Then

                                            If MediaBroadcastWorksheetMarketDetailsViewModel.HiatusDataTable.Rows(0).Item(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(Key)) = False Then

                                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(Key)) = If(OmitSpots, 0, MediaRFPAvailLineSpot.Quantity)

                                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.AllowSpotsToBeEnteredDates.Item(Key)) = True

                                            End If

                                            Exit For

                                        End If

                                    Next

                                    If MediaRFPAvailLineSpot.MediaRFPAvailLine.FileSource = Database.Entities.Methods.MediaRFPAvailLineFileSource.PRP AndAlso MediaRFPAvailLineSpot.MediaRFPAvailLine.EndDate.HasValue Then

                                        For Each Key In MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Keys

                                            If MediaRFPAvailLineSpot.MediaRFPAvailLine.EndDate.Value >= CDate(Key) AndAlso MediaRFPAvailLineSpot.MediaRFPAvailLine.EndDate.Value <= DateAdd(DateInterval.Day, 6, CDate(Key)) Then

                                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.AllowSpotsToBeEnteredDates.Item(Key)) = True

                                            End If

                                        Next

                                        For Each Key In MediaBroadcastWorksheetMarketDetailsViewModel.RateDates.Keys

                                            If MediaRFPAvailLineSpot.MediaRFPAvailLine.EndDate.Value >= CDate(Key) AndAlso MediaRFPAvailLineSpot.MediaRFPAvailLine.EndDate.Value <= DateAdd(DateInterval.Day, 6, CDate(Key)) Then

                                                DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.RateDates.Item(Key)) = MediaRFPAvailLineSpot.Rate

                                                Exit For

                                            End If

                                        Next

                                    End If

                                End If

                                If MediaBroadcastWorksheetMarketDetailsViewModel.RateDates.ContainsKey(MediaRFPAvailLineSpot.WeekDate) Then

                                    DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.RateDates.Item(MediaRFPAvailLineSpot.WeekDate)) = MediaRFPAvailLineSpot.Rate

                                Else

                                    For Each Key In MediaBroadcastWorksheetMarketDetailsViewModel.RateDates.Keys

                                        If MediaRFPAvailLineSpot.WeekDate >= CDate(Key) AndAlso MediaRFPAvailLineSpot.WeekDate <= DateAdd(DateInterval.Day, 6, CDate(Key)) Then

                                            DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.RateDates.Item(Key)) = MediaRFPAvailLineSpot.Rate

                                            Exit For

                                        End If

                                    Next

                                End If

                            Next

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVPVH.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVPVH.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryVPVH.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookPrimaryVPVH.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedVPVH.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryVendorSubmittedVPVH.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVPVH.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVPVH.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryVPVH.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.BookSecondaryVPVH.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedVPVH.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryVendorSubmittedVPVH.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvImpressions.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvImpressions.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvCPM.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvCPM.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvRating.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvRating.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvCPP.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvCPP.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvGRP.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvGRP.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvGrossImpressions.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvGrossImpressions.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvVendorRating.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvVendorRating.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvVendorImpressions.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryEqvVendorImpressions.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvImpressions.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvImpressions.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvCPM.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvCPM.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvRating.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvRating.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvCPP.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvCPP.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvGRP.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvGRP.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvGrossImpressions.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvGrossImpressions.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvVendorRating.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvVendorRating.ToString) = 0

                            'End If

                            'If MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvVendorImpressions.ToString) IsNot Nothing Then

                            '    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.SecondaryEqvVendorImpressions.ToString) = 0

                            'End If

                            RowIndexes.Add(MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.IndexOf(DataRow))

                            MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.EndLoadData()

                            MediaRFPAvailLines.Add(MediaRFPAvailLine.ID, MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.IndexOf(DataRow))

                        End If

                    Next

                    MediaBroadcastWorksheetController.MarketDetails_LoadPrimaryRatingAndShareData(MediaBroadcastWorksheetMarketDetailsViewModel, RowIndexes)
                    MediaBroadcastWorksheetController.MarketDetails_LoadSecondaryRatingAndShareData(MediaBroadcastWorksheetMarketDetailsViewModel, RowIndexes)

                    For Each RowIndex In RowIndexes

                        MediaBroadcastWorksheetController.MarketDetails_RefreshColumnTotalsDataTable(MediaBroadcastWorksheetMarketDetailsViewModel, RowIndex)

                    Next

                    MediaBroadcastWorksheetController.MarketDetails_Save(MediaBroadcastWorksheetMarketDetailsViewModel)

                    For Each KeyValuePair In MediaRFPAvailLines

                        DataRow = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.Item(KeyValuePair.Value)

                        MediaBroadcastWorksheetMarketDetailID = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_RFP_AVAILABLE_LINE SET MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = {0}, [STATUS] = '{2}' WHERE MEDIA_RFP_AVAILABLE_LINE_ID = {1}",
                                                                           MediaBroadcastWorksheetMarketDetailID, KeyValuePair.Key, AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.T.ToString))

                        If MediaBroadcastWorksheetMarketDetailsViewModel.DoesWorksheetAllowSubmarkets Then

                            If MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.PrimaryMediaDemographicID.HasValue Then

                                For Each MediaRFPDemo In (From Entity In AllMediaRFPDemos
                                                          Where Entity.MediaDemoID = MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.PrimaryMediaDemographicID.Value AndAlso
                                                                Entity.Type.ToUpper.StartsWith("RATING") AndAlso
                                                                Entity.MediaRFPAvailLineID = KeyValuePair.Key AndAlso
                                                                Entity.MarketCode IsNot Nothing
                                                          Select Entity)

                                    MediaBroadcastWorksheetMarketSubmarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketSubmarket.LoadByMediaBroadcastWorksheetMarketIDMarketCode(DbContext, MediaBroadcastWorksheetMarket.ID, MediaRFPDemo.MarketCode)

                                    If MediaBroadcastWorksheetMarketSubmarket Is Nothing Then

                                        MediaBroadcastWorksheetMarketSubmarket = New Database.Entities.MediaBroadcastWorksheetMarketSubmarket
                                        MediaBroadcastWorksheetMarketSubmarket.DbContext = DbContext

                                        MediaBroadcastWorksheetMarketSubmarket.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarket.ID
                                        MediaBroadcastWorksheetMarketSubmarket.MarketCode = MediaRFPDemo.MarketCode

                                        AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketSubmarket.Insert(DbContext, MediaBroadcastWorksheetMarketSubmarket)

                                    End If

                                    If MediaBroadcastWorksheetMarketSubmarket IsNot Nothing Then

                                        MediaBroadcastWorksheetMarketDetailSubmarketDemo = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailSubmarketDemo.LoadBySubmarketIDDetailIDMediaDemographicID(DbContext, MediaBroadcastWorksheetMarketSubmarket.ID, MediaBroadcastWorksheetMarketDetailID, MediaRFPDemo.MediaDemoID)

                                        If MediaBroadcastWorksheetMarketDetailSubmarketDemo Is Nothing Then

                                            MediaBroadcastWorksheetMarketDetailSubmarketDemo = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo
                                            MediaBroadcastWorksheetMarketDetailSubmarketDemo.DbContext = DbContext

                                        End If

                                        MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketSubmarketID = MediaBroadcastWorksheetMarketSubmarket.ID
                                        MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailID
                                        MediaBroadcastWorksheetMarketDetailSubmarketDemo.MediaDemographicID = MediaRFPDemo.MediaDemoID
                                        MediaBroadcastWorksheetMarketDetailSubmarketDemo.BookRating = 0
                                        MediaBroadcastWorksheetMarketDetailSubmarketDemo.Rating = MediaRFPDemo.Value
                                        MediaBroadcastWorksheetMarketDetailSubmarketDemo.BookImpressions = 0

                                        MediaRFPDemoImpressions = (From Entity In AllMediaRFPDemos
                                                                   Where Entity.MediaDemoID = MediaBroadcastWorksheetMarketDetailsViewModel.Worksheet.PrimaryMediaDemographicID.Value AndAlso
                                                                         Entity.Type.ToUpper.StartsWith("IMPRESSION") AndAlso
                                                                         Entity.MediaRFPAvailLineID = KeyValuePair.Key AndAlso
                                                                         Entity.MarketCode IsNot Nothing
                                                                   Select Entity).SingleOrDefault

                                        If MediaRFPDemoImpressions IsNot Nothing Then

                                            MediaBroadcastWorksheetMarketDetailSubmarketDemo.Impressions = MediaRFPDemoImpressions.Value

                                        Else

                                            MediaBroadcastWorksheetMarketDetailSubmarketDemo.Impressions = 0

                                        End If

                                        If MediaBroadcastWorksheetMarketDetailSubmarketDemo.IsEntityBeingAdded Then

                                            AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailSubmarketDemo.Insert(DbContext, MediaBroadcastWorksheetMarketDetailSubmarketDemo)

                                        Else

                                            AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailSubmarketDemo.Update(DbContext, MediaBroadcastWorksheetMarketDetailSubmarketDemo)

                                        End If

                                    End If

                                Next

                            End If

                            DbContext.SaveChanges()

                        End If

                    Next

                    DbTransaction.Commit()

                    Added = True

                Catch ex As Exception

                    DbTransaction.Rollback()

                    ErrorMessage = ex.Message

                End Try

            End Using

            AddToWorksheet = Added

        End Function
        Public Sub SetSelectedAvailLineModified(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                                MediaRFPAvailLine As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine, FieldName As String)

            MediaRFPAvailLine.Modified = True

            If FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString Then

                For Each Avail In MediaRequestForProposalViewModel.MediaRFPAvailLines.Where(Function(AL) AL.NetworkName = MediaRFPAvailLine.NetworkName)

                    Avail.ComscoreTVStationCallLetters = MediaRFPAvailLine.ComscoreTVStationCallLetters

                Next

            End If

        End Sub
        Public Sub SetSelectedAvailLinesStatus(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                               NewStatus As String,
                                               MediaRFPAvailLineList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine), ByRef InfoMessage As String)

            For Each MediaRFPAvailLine In MediaRFPAvailLineList

                If Not MediaRFPAvailLine.MediaBroadcastWorksheetMarketDetailID.HasValue Then

                    If NewStatus = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.P.ToString Then

                        If Not MediaRFPAvailLine.HasError Then

                            MediaRFPAvailLine.Status = NewStatus
                            MediaRFPAvailLine.Modified = True

                        Else

                            InfoMessage = "Some selected rows need additional data and cannot be marked as 'pending'."

                        End If

                    Else

                        MediaRFPAvailLine.Status = NewStatus
                        MediaRFPAvailLine.Modified = True

                    End If

                End If

            Next

        End Sub
        Public Sub SetSelectedDemoModified(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                           MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            MediaRFPDemo.Modified = True

        End Sub
        Public Sub SetSelectedMediaRFPHeader(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                             MediaRFPHeader As AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)

            MediaRequestForProposalViewModel.SelectedMediaRFPHeader = MediaRFPHeader

        End Sub
        Public Sub ClearSelectedMediaRFPHeader(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel)

            MediaRequestForProposalViewModel.SelectedMediaRFPHeader = Nothing

        End Sub
        Public Sub SetSelectedMediaRFPHeaderModified(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                                     MediaRFPHeader As AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)

            MediaRFPHeader.Modified = True

        End Sub
        Public Sub SetSelectedMarketModified(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                             MediaRFPMarket As AdvantageFramework.DTO.Media.RFP.MediaRFPMarket)

            MediaRFPMarket.Modified = True

        End Sub
        Public Sub SetSelectedStationModified(ByRef MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel,
                                              MediaRFPStation As AdvantageFramework.DTO.Media.RFP.MediaRFPStation)

            MediaRFPStation.Modified = True

        End Sub
        Public Function MediaRFPAvailLineValidateEntity(ByRef MediaRFPAvailLine As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine, ByRef IsValid As Boolean)

            'objects
            Dim ErrorText As String = String.Empty

            MediaRFPAvailLine.Modified = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SetRequiredFields(MediaRFPAvailLine)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaRFPAvailLine, IsValid)

                End Using

            End Using

            If Not IsValid Then

                MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

            End If

            MediaRFPAvailLineValidateEntity = ErrorText

        End Function
        Public Function MediaRFPAvailLineValidateEntityProperty(MediaRFPAvailLine As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaRFPAvailLine.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaRFPAvailLine, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            If Not IsValid Then

                MediaRFPAvailLine.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.H.ToString

            End If

            MediaRFPAvailLineValidateEntityProperty = ErrorText

        End Function
        Public Function MediaRFPDemoValidateEntity(ByRef MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo, ByRef IsValid As Boolean)

            'objects
            Dim ErrorText As String = String.Empty

            MediaRFPDemo.Modified = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaRFPDemo, IsValid)

                End Using

            End Using

            MediaRFPDemoValidateEntity = ErrorText

        End Function
        Public Function MediaRFPMarketValidateEntity(ByRef MediaRFPMarket As AdvantageFramework.DTO.Media.RFP.MediaRFPMarket, ByRef IsValid As Boolean)

            'objects
            Dim ErrorText As String = String.Empty

            MediaRFPMarket.Modified = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaRFPMarket, IsValid)

                End Using

            End Using

            MediaRFPMarketValidateEntity = ErrorText

        End Function
        Public Function MediaRFPStationValidateEntity(ByRef MediaRFPStation As AdvantageFramework.DTO.Media.RFP.MediaRFPStation, ByRef IsValid As Boolean)

            'objects
            Dim ErrorText As String = String.Empty

            MediaRFPStation.Modified = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaRFPStation, IsValid)

                End Using

            End Using

            MediaRFPStationValidateEntity = ErrorText

        End Function
        Public Function MediaRFPDemoValidateEntityProperty(MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaRFPDemo.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaRFPDemo, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            MediaRFPDemoValidateEntityProperty = ErrorText

        End Function
        Public Function MediaRFPMarketValidateEntityProperty(MediaRFPMarket As AdvantageFramework.DTO.Media.RFP.MediaRFPMarket, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaRFPMarket.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaRFPMarket, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            MediaRFPMarketValidateEntityProperty = ErrorText

        End Function
        Public Function MediaRFPStationValidateEntityProperty(MediaRFPStation As AdvantageFramework.DTO.Media.RFP.MediaRFPStation, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaRFPStation.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaRFPStation, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            MediaRFPStationValidateEntityProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyValue As Object = Nothing
            Dim MediaRFPAvailLine As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim MediaRFPDemo As AdvantageFramework.DTO.Media.RFP.MediaRFPDemo = Nothing
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If DTO.GetType Is GetType(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine) Then

                MediaRFPAvailLine = DTO

                If PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.StartDate.ToString Then

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If MediaRFPAvailLine.EndDate.HasValue AndAlso DirectCast(PropertyValue, System.DateTime) > MediaRFPAvailLine.EndDate.Value Then

                            ErrorText = "Start date must be before end date."
                            IsValid = False

                            'ElseIf MediaRFPAvailLine.IsWeeklyWorksheet AndAlso DirectCast(PropertyValue, System.DateTime).DayOfWeek <> MediaRFPAvailLine.MediaBroadcastWorksheetStartDate.DayOfWeek Then

                            '    ErrorText = "Date override must start on same day-of-week as the worksheet."
                            '    IsValid = False

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLineSpot.LoadByMediaRFPAvailLineID(DbContext, MediaRFPAvailLine.ID)
                                Where DirectCast(PropertyValue, System.DateTime) > Entity.WeekDate).Any Then

                            MediaRFPAvailLine.HasDetailDatesBeforeStartDate = True

                        Else

                            MediaRFPAvailLine.HasDetailDatesBeforeStartDate = False

                        End If

                    End If

                ElseIf PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.EndDate.ToString Then

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If MediaRFPAvailLine.StartDate.HasValue AndAlso DirectCast(PropertyValue, System.DateTime) < MediaRFPAvailLine.StartDate.Value Then

                            ErrorText = "End date must be after start date."
                            IsValid = False

                            'ElseIf MediaRFPAvailLine.IsWeeklyWorksheet AndAlso DirectCast(PropertyValue, System.DateTime).DayOfWeek <> MediaRFPAvailLine.MediaBroadcastWorksheetEndDate.DayOfWeek Then

                            '    ErrorText = "Date override must end on same day-of-week as the worksheet."
                            '    IsValid = False

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaRFPAvailLineSpot.LoadByMediaRFPAvailLineID(DbContext, MediaRFPAvailLine.ID)
                                Where DirectCast(PropertyValue, System.DateTime) < Entity.WeekDate).Any Then

                            MediaRFPAvailLine.HasDetailDatesAfterEndDate = True

                        Else

                            MediaRFPAvailLine.HasDetailDatesAfterEndDate = False

                        End If

                    End If

                ElseIf PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.MediaDemoID.ToString Then

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaRFPAvailLine.MediaBroadcastWorksheetMarketID)

                        If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing AndAlso
                                MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.GetValueOrDefault(0) <> DirectCast(PropertyValue, Integer) AndAlso MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID.GetValueOrDefault(0) <> DirectCast(PropertyValue, Integer) Then

                            ErrorText = "Invalid demographic."
                            IsValid = False

                        End If

                    End If

                ElseIf PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString Then

                    If MediaRFPAvailLine.IsComscore Then

                        PropertyValue = Value

                        If String.IsNullOrWhiteSpace(PropertyValue) = False Then

                            'If AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadByCallLetters(DbContext, DirectCast(PropertyValue, String)) Is Nothing Then

                            '    ErrorText = "Invalid cable network."
                            '    IsValid = False

                            'End If

                            If Me.Session.IsNielsenSetup Then

                                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                                    NielsenDbContext.Database.Connection.Open()

                                    If AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext).Any Then

                                        If (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.LoadWithComscoreStationCode(NielsenDbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity, True)).ToList
                                            Where Entity.Code = DirectCast(PropertyValue, String)
                                            Select Entity).Any = False Then

                                            ErrorText = "Invalid cable network."
                                            IsValid = False

                                        End If

                                        'Else

                                        '    MediaRequestForProposalViewModel.RepositoryCableNetworkStations = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

                                    End If

                                End Using

                            End If

                        End If

                    End If

                ElseIf PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ID.ToString Then

                    If (MediaRFPAvailLine.MediaTypeCode = "R" AndAlso MediaRFPAvailLine.IsCanadianWorksheet) = False Then

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPDemo.LoadByMediaRFPDetailLineID(DbContext, MediaRFPAvailLine.ID)
                            Where Entity.SourceMarketName IsNot Nothing AndAlso
                              Entity.MarketCode Is Nothing).Any Then

                            ErrorText = "One or more invalid markets."
                            IsValid = False

                        End If

                    End If

                End If

            ElseIf DTO.GetType Is GetType(AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) Then

                MediaRFPDemo = DTO

                If PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPDemo.Properties.MediaDemoID.ToString Then

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        MediaRFPHeader = AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByID(DbContext, MediaRFPDemo.MediaRFPHeaderID)

                        If MediaRFPHeader IsNot Nothing Then

                            MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaRFPHeader.MediaBroadcastWorksheetMarketID)

                            If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing AndAlso
                                    MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID.GetValueOrDefault(0) <> DirectCast(PropertyValue, Integer) AndAlso MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID.GetValueOrDefault(0) <> DirectCast(PropertyValue, Integer) Then

                                ErrorText = "Invalid demographic."
                                IsValid = False

                            End If

                        End If

                    End If

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Function LoadGuidelines(MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel) As String

            'objects
            Dim MediaBroadcastWorksheetMarketID As Integer = 0
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim Guidelines As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheetMarketID = MediaRequestForProposalViewModel.MediaRFPHeaders.FirstOrDefault.MediaBroadcastWorksheetMarketID

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)

                If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                    StandardComment = AdvantageFramework.Database.Procedures.StandardComment.LoadByOfficeCodeAndApplicationCode(DbContext, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Product.OfficeCode, "Media RFP")

                    If StandardComment IsNot Nothing Then

                        Guidelines = StandardComment.HtmlComment

                    End If

                End If

            End Using

            LoadGuidelines = Guidelines

        End Function
        Public Overrides Sub SetRequiredFields(ByRef DTO As AdvantageFramework.DTO.BaseClass)

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            If DTO.GetType Is GetType(AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine) Then

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(DTO).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each PropertyDescriptor In PropertyDescriptors

                    Select Case PropertyDescriptor.Name

                        Case AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.ComscoreTVStationCallLetters.ToString

                            If DirectCast(DTO, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).IsComscore AndAlso DirectCast(DTO, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).IsCableSystem Then

                                DTO.SetRequired(PropertyDescriptor, True)

                            Else

                                DTO.SetRequired(PropertyDescriptor, False)

                            End If

                        Case AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.MediaDemoID.ToString

                            If DirectCast(DTO, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).HasDemosFromImportFile Then

                                DTO.SetRequired(PropertyDescriptor, True)

                            Else

                                DTO.SetRequired(PropertyDescriptor, False)

                            End If

                    End Select

                Next

                'ElseIf DTO.GetType Is GetType(AdvantageFramework.DTO.Media.RFP.MediaRFPDemo) Then

                '    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(DTO).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                '    For Each PropertyDescriptor In PropertyDescriptors

                '        Select Case PropertyDescriptor.Name

                '            Case AdvantageFramework.DTO.Media.RFP.MediaRFPDemo.Properties.MediaDemoID.ToString

                '                If DirectCast(DTO, AdvantageFramework.DTO.Media.RFP.MediaRFPDemo).WorksheetHasDemos Then

                '                    DTO.SetRequired(PropertyDescriptor, True)

                '                Else

                '                    DTO.SetRequired(PropertyDescriptor, False)

                '                End If

                '        End Select

                '    Next

            End If

        End Sub
        Public Function GetRepositoryComscoreTVStationCallLetters(MediaRequestForProposalViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalViewModel) As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

            'Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '    If MediaRequestForProposalViewModel.ComscoreMarketNumber.HasValue Then

            '        GetRepositoryComscoreTVStationCallLetters = AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadByPrimaryMarketNumber(DbContext, MediaRequestForProposalViewModel.ComscoreMarketNumber.Value).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity)).OrderBy(Function(Entity) Entity.Code).ToList

            '    Else

            '        GetRepositoryComscoreTVStationCallLetters = AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadCableNetworks(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity)).OrderBy(Function(Entity) Entity.Code).ToList

            '    End If

            'End Using

            If Me.Session.IsNielsenSetup Then

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    NielsenDbContext.Database.Connection.Open()

                    If AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext).Any Then

                        GetRepositoryComscoreTVStationCallLetters = AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.LoadWithComscoreStationCode(NielsenDbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation(Entity, True)).ToList

                    Else

                        GetRepositoryComscoreTVStationCallLetters = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

                    End If

                End Using

            Else

                GetRepositoryComscoreTVStationCallLetters = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

            End If

        End Function

#Region " Generate "

        Private Sub SetStatus(GenerateRFP As AdvantageFramework.DTO.Media.RFP.GenerateRFP, MediaRFPHeaderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPHeaderStatus))

            'objects
            Dim MediaRFPHeaderStatus As AdvantageFramework.Database.Entities.MediaRFPHeaderStatus = Nothing

            If MediaRFPHeaderStatuses IsNot Nothing AndAlso MediaRFPHeaderStatuses.Count > 0 Then

                MediaRFPHeaderStatus = MediaRFPHeaderStatuses.OrderByDescending(Function(S) S.CreatedDate).FirstOrDefault

                If MediaRFPHeaderStatus IsNot Nothing Then

                    GenerateRFP.RFPStatus = MediaRFPHeaderStatus.MediaRFPStatus.StatusDescription

                End If

                MediaRFPHeaderStatus = MediaRFPHeaderStatuses.Where(Function(Entity) Entity.MediaRFPStatusID = Database.Entities.Methods.MediaRFPStatusID.Generated).OrderByDescending(Function(S) S.CreatedDate).FirstOrDefault

                If MediaRFPHeaderStatus IsNot Nothing Then

                    GenerateRFP.LastGeneratedDate = MediaRFPHeaderStatus.CreatedDate

                End If

                MediaRFPHeaderStatus = MediaRFPHeaderStatuses.Where(Function(Entity) Entity.MediaRFPStatusID = Database.Entities.Methods.MediaRFPStatusID.Generated).OrderBy(Function(S) S.CreatedDate).FirstOrDefault

                If MediaRFPHeaderStatus IsNot Nothing Then

                    GenerateRFP.CreatedDate = MediaRFPHeaderStatus.CreatedDate

                End If

            End If

        End Sub
        Public Function LoadRequestForProposalGenerateViewModel(MediaRFPHeaders As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)) As AdvantageFramework.ViewModels.Media.RequestForProposalGenerateViewModel

            'objects
            Dim RequestForProposalGenerateViewModel As AdvantageFramework.ViewModels.Media.RequestForProposalGenerateViewModel = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim GenerateRFP As AdvantageFramework.DTO.Media.RFP.GenerateRFP = Nothing
            Dim MediaRFPHeaderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPHeaderStatus) = Nothing
            Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            RequestForProposalGenerateViewModel = New AdvantageFramework.ViewModels.Media.RequestForProposalGenerateViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadContactTypes(RequestForProposalGenerateViewModel)

                RequestForProposalGenerateViewModel.ContactTypeList = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).ToList

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    For Each MediaRFPHeader In MediaRFPHeaders

                        Vendor = DbContext.Vendors.Find(MediaRFPHeader.VendorCode)

                        If RequestForProposalGenerateViewModel.ContactTypeIDs.Count > 0 Then

                            VendorRepresentatives = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaRFPHeader.VendorCode)
                                                     Where Entity.EmailAddress IsNot Nothing AndAlso
                                                           Entity.EmailAddress <> "" AndAlso
                                                           RequestForProposalGenerateViewModel.ContactTypeIDs.Contains(Entity.ContactTypeID.GetValueOrDefault(0))).ToList

                        Else

                            VendorRepresentatives = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, MediaRFPHeader.VendorCode)
                                                     Where Entity.EmailAddress IsNot Nothing AndAlso
                                                           Entity.EmailAddress <> "").ToList
                        End If

                        GenerateRFP = New AdvantageFramework.DTO.Media.RFP.GenerateRFP

                        If Vendor IsNot Nothing Then

                            GenerateRFP.DefaultCorrespondenceMethod = Vendor.DefaultCorrespondenceMethod.GetValueOrDefault(1)

                        End If

                        MediaRFPHeaderStatuses = AdvantageFramework.Database.Procedures.MediaRFPHeaderStatus.LoadByMediaRFPHeaderID(DbContext, MediaRFPHeader.ID).ToList

                        SetStatus(GenerateRFP, MediaRFPHeaderStatuses)

                        GenerateRFP.MediaRFPHeaderID = MediaRFPHeader.ID
                        GenerateRFP.VendorCode = MediaRFPHeader.VendorCode
                        GenerateRFP.VendorName = MediaRFPHeader.VendorName

                        If VendorRepresentatives IsNot Nothing AndAlso VendorRepresentatives.Count > 0 Then

                            GenerateRFP.Status = True

                        Else

                            GenerateRFP.Status = False

                        End If

                        GenerateRFP.RecipientCount = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.MediaManagerRFPVendorRecipient)(String.Format("exec dbo.advsp_media_manager_rfp_recipients '{0}'", MediaRFPHeader.ID)).Count

                        GenerateRFP.CommentToVendor = MediaRFPHeader.CommentToVendor

                        If MediaRFPHeader.AlertID.HasValue Then

                            AlertRecipients = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.AlertRecipient)("EXEC [dbo].[advsp_alert_recipient_get] {0}", MediaRFPHeader.AlertID.Value).ToList
                                               Where Entity.EmployeeCode <> Session.User.EmployeeCode AndAlso
                                                     Entity.IsCurrentRecipient = True
                                               Select Entity).ToList

                            GenerateRFP.AlertRecipientEmployeeCodes = AlertRecipients.Select(Function(AR) AR.EmployeeCode).ToList

                            GenerateRFP.AlertRecipients = String.Join(", ", AlertRecipients.Select(Function(AR) AR.FullName).ToArray)

                        End If

                        RequestForProposalGenerateViewModel.GenerateRFPList.Add(GenerateRFP)

                    Next

                End Using

            End Using

            LoadRequestForProposalGenerateViewModel = RequestForProposalGenerateViewModel

        End Function
        Private Sub LoadContactTypes(ByRef RequestForProposalGenerateViewModel As AdvantageFramework.ViewModels.Media.RequestForProposalGenerateViewModel)

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim ContactTypes As String = Nothing
            Dim ContactTypeIDs As Generic.List(Of String) = Nothing

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.RFPContactTypes.ToString)

                    If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                        ContactTypes = UserSetting.StringValue

                    End If

                    If String.IsNullOrWhiteSpace(ContactTypes) = False Then

                        ContactTypeIDs = Split(ContactTypes, ",").ToList

                    End If

                End Using

            Catch ex As Exception

            Finally

                If ContactTypeIDs Is Nothing Then

                    ContactTypeIDs = New Generic.List(Of String)

                End If

            End Try

            RequestForProposalGenerateViewModel.ContactTypeIDs = ContactTypeIDs

        End Sub
        Public Function SaveContactTypes(ContactTypes As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.RFPContactTypes.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = ContactTypes

                    Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.RFPContactTypes.ToString, ContactTypes, Nothing, Nothing, UserSetting)

                End If

            End Using

            SaveContactTypes = Saved

        End Function

#End Region

#Region " Process Generate "

        Public Function LoadRequestForProposalProcessGenerateViewModel(GenerateRFPs As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFP), ContactTypeIDs As Generic.List(Of String)) As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel

            'objects
            Dim RequestForProposalProcessGenerateViewModel As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim GenerateRFPVendorRep As AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep = Nothing

            RequestForProposalProcessGenerateViewModel = New AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPCCSender.ToString)

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    RequestForProposalProcessGenerateViewModel.CCSender = If(UserSetting.StringValue = "Y", True, False)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPEmailBody.ToString)

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    RequestForProposalProcessGenerateViewModel.EmailBody = UserSetting.StringValue

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPEmailSubject.ToString)

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    RequestForProposalProcessGenerateViewModel.EmailSubject = UserSetting.StringValue

                End If

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                RequestForProposalProcessGenerateViewModel.ContactTypeList = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).ToList

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each GenerateRFP In GenerateRFPs

                    If ContactTypeIDs IsNot Nothing AndAlso ContactTypeIDs.Count > 0 Then

                        RequestForProposalProcessGenerateViewModel.GenerateRFPVendorReps.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, GenerateRFP.VendorCode).ToList
                                                                                                  Where ContactTypeIDs.Contains(Entity.ContactTypeID.GetValueOrDefault(0))
                                                                                                  Select New AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep(Entity, GenerateRFP))

                    Else

                        RequestForProposalProcessGenerateViewModel.GenerateRFPVendorReps.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, GenerateRFP.VendorCode).ToList
                                                                                                  Select New AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep(Entity, GenerateRFP))

                    End If

                Next

            End Using

            LoadRequestForProposalProcessGenerateViewModel = RequestForProposalProcessGenerateViewModel

        End Function
        Public Sub SaveEmailSettings(RequestForProposalProcessGenerateViewModel As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel)

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPCCSender.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = If(RequestForProposalProcessGenerateViewModel.CCSender, "Y", "N")

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPCCSender.ToString, If(RequestForProposalProcessGenerateViewModel.CCSender, "Y", "N"), Nothing, Nothing, UserSetting)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPEmailBody.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = RequestForProposalProcessGenerateViewModel.EmailBody

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPEmailBody.ToString, RequestForProposalProcessGenerateViewModel.EmailBody, Nothing, Nothing, UserSetting)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPEmailSubject.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = RequestForProposalProcessGenerateViewModel.EmailSubject

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.RFPEmailSubject.ToString, RequestForProposalProcessGenerateViewModel.EmailSubject, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Public Sub GenerateRFP_CheckUncheck(ByRef ViewNodel As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel, GenerateRFPVendorRep As AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep, Checked As Boolean)

            ViewNodel.GenerateRFPVendorReps.Where(Function(Entity) Entity.Equals(GenerateRFPVendorRep)).First.Process = Checked

        End Sub
        Public Function Email_Load(AlertID As Integer) As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel

            'objects
            Dim RequestForProposalProcessGenerateViewModel As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim VendorRepCodes As IEnumerable(Of String) = Nothing
            Dim VendorContactCodes As IEnumerable(Of String) = Nothing

            RequestForProposalProcessGenerateViewModel = New AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    RequestForProposalProcessGenerateViewModel.Email_AlertID = AlertID

                    VendorRepCodes = (From Entity In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, AlertID)
                                      Where Entity.VendorRepresentativeCode IsNot Nothing AndAlso
                                            Entity.VendorRepresentativeCode <> ""
                                      Select Entity.VendorRepresentativeCode).ToArray

                    VendorContactCodes = (From Entity In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, AlertID)
                                          Where Entity.VendorContactCode IsNot Nothing AndAlso
                                                Entity.VendorContactCode <> ""
                                          Select Entity.VendorContactCode).ToArray

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If VendorRepCodes IsNot Nothing AndAlso VendorRepCodes.Count > 0 Then

                            RequestForProposalProcessGenerateViewModel.EmailVendorRepContacts.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                                                                       Where VendorRepCodes.Contains(Entity.Code) AndAlso
                                                                                                             Entity.VendorCode = Alert.VendorCode
                                                                                                       Select New AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact(Entity))

                        End If

                        If VendorContactCodes IsNot Nothing AndAlso VendorContactCodes.Count > 0 Then

                            RequestForProposalProcessGenerateViewModel.EmailVendorRepContacts.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorContact.Load(DbContext)
                                                                                                       Where VendorContactCodes.Contains(Entity.Code) AndAlso
                                                                                                             Entity.VendorCode = Alert.VendorCode
                                                                                                       Select New AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact(Entity))

                        End If

                    End Using

                End If

            End Using

            Email_Load = RequestForProposalProcessGenerateViewModel

        End Function
        Public Sub Email_CheckUncheck(ByRef ViewNodel As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel, EmailVendorRepContact As AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact, Checked As Boolean)

            ViewNodel.EmailVendorRepContacts.Where(Function(Entity) Entity.Equals(EmailVendorRepContact)).First.Include = Checked

        End Sub
        Public Function Email_SendEmails(ViewModel As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim Sent As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Alert = DbContext.Alerts.Find(ViewModel.Email_AlertID)

                If Alert IsNot Nothing Then

                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment
                    AlertComment.DbContext = DbContext

                    AlertComment.AlertID = ViewModel.Email_AlertID
                    AlertComment.UserCode = DbContext.UserCode
                    AlertComment.GeneratedDate = Now
                    AlertComment.Comment = ViewModel.Email_Comment

                    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, Alert.Subject, IncludeOriginator:=True, ErrorMessage:=ErrorMessage)

                        End Using

                    Else

                        ErrorMessage = "Cannot insert alert comment. Please contact software support."

                    End If

                Else

                    ErrorMessage = "Cannot find alert. Please contact software support."

                End If

            End Using

            Email_SendEmails = Sent

        End Function

#End Region

#Region " Responses "

        Public Function Response_Load(MediaRFPHeaders As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)) As AdvantageFramework.ViewModels.Media.MediaRequestForProposalResponseViewModel

            'objects
            Dim MediaRequestForProposalResponseViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalResponseViewModel = Nothing
            Dim MediaRFPHeaderIDs As IEnumerable(Of Integer) = Nothing
            Dim AlertIDs As IEnumerable(Of Integer) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient) = Nothing

            MediaRequestForProposalResponseViewModel = New AdvantageFramework.ViewModels.Media.MediaRequestForProposalResponseViewModel
            MediaRequestForProposalResponseViewModel.MediaRFPHeaders = MediaRFPHeaders

            MediaRFPHeaderIDs = MediaRFPHeaders.Select(Function(RFP) RFP.ID).ToArray

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaRequestForProposalResponseViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                MediaRequestForProposalResponseViewModel.AlertComments = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.RFP.AlertComment)(String.Format("exec dbo.advsp_media_manager_rfp_alert_comments '{0}'", String.Join(",", MediaRFPHeaderIDs.ToArray))).ToList

                MediaRequestForProposalResponseViewModel.MediaBroadcastWorksheetMarketID = AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByID(DbContext, MediaRFPHeaderIDs.First).MediaBroadcastWorksheetMarketID

                If Session.User IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session.User.EmployeeCode) Then

                    AlertIDs = (From Entity In MediaRFPHeaders
                                Where Entity.AlertID.HasValue
                                Select Entity.AlertID.Value).ToArray

                    AlertRecipients = (From Entity In AdvantageFramework.Database.Procedures.AlertRecipient.Load(DbContext)
                                       Where Entity.EmployeeCode = Session.User.EmployeeCode AndAlso
                                             AlertIDs.Contains(Entity.AlertID) AndAlso
                                             Entity.HasBeenRead <> 1
                                       Select Entity).ToList

                    For Each AlertRecipient In AlertRecipients

                        AlertRecipient.HasBeenRead = 1
                        DbContext.Entry(AlertRecipient).State = Entity.EntityState.Modified

                    Next

                    DbContext.SaveChanges()

                End If

            End Using

            Response_Load = MediaRequestForProposalResponseViewModel

        End Function
        Public Function Response_ImportFiles(ViewModel As AdvantageFramework.ViewModels.Media.MediaRequestForProposalResponseViewModel, SaveToLocation As String, DocumentIDs As IEnumerable(Of Integer),
                                             ByRef InfoMessage As String) As Boolean

            'objects
            Dim Imported As Boolean = False
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim NewFileName As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Documents = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                             Where DocumentIDs.Contains(Entity.ID)
                             Select Entity).ToList

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If ViewModel.IsAgencyASP Then

                    SaveToLocation = AdvantageFramework.FileSystem.LoadHostedClientDownloadLocation(Agency)

                End If

            End Using

            For Each Document In Documents

                If AdvantageFramework.FileSystem.Download(Agency, Documents.FirstOrDefault, SaveToLocation, NewFileName) Then

                    Imported = AdvantageFramework.Importing.ImportMediaRFPFile(Me.Session, {NewFileName}, ViewModel.MediaBroadcastWorksheetMarketID, InfoMessage)

                End If

            Next

            Response_ImportFiles = Imported

        End Function

#End Region

#Region " Print Settings "

        Private Function GetRFPPrintSetting(MediaType As String) As AdvantageFramework.DTO.Media.RFP.PrintSetting

            'objects
            Dim MediaRFPPrintSetting As AdvantageFramework.Database.Entities.MediaRFPPrintSetting = Nothing
            Dim PrintSetting As AdvantageFramework.DTO.Media.RFP.PrintSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaRFPPrintSetting = AdvantageFramework.Database.Procedures.MediaRFPPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, MediaType)

                If MediaRFPPrintSetting IsNot Nothing Then

                    PrintSetting = New AdvantageFramework.DTO.Media.RFP.PrintSetting(MediaRFPPrintSetting)

                Else

                    PrintSetting = New AdvantageFramework.DTO.Media.RFP.PrintSetting(Session.UserCode, MediaType)

                    MediaRFPPrintSetting = New AdvantageFramework.Database.Entities.MediaRFPPrintSetting

                    PrintSetting.SaveToEntity(MediaRFPPrintSetting)

                    MediaRFPPrintSetting.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.MediaRFPPrintSetting.Insert(DbContext, MediaRFPPrintSetting, Nothing)

                    PrintSetting = New AdvantageFramework.DTO.Media.RFP.PrintSetting(MediaRFPPrintSetting)

                End If

            End Using

            GetRFPPrintSetting = PrintSetting

        End Function
        Public Function PrintSettings_Load(MediaType As String) As AdvantageFramework.ViewModels.Media.MediaRFPPrintSettingViewModel

            Dim MediaRFPPrintSettingViewModel As AdvantageFramework.ViewModels.Media.MediaRFPPrintSettingViewModel = Nothing

            MediaRFPPrintSettingViewModel = New AdvantageFramework.ViewModels.Media.MediaRFPPrintSettingViewModel

            MediaRFPPrintSettingViewModel.PrintSettings.Add(GetRFPPrintSetting(MediaType))

            PrintSettings_Load = MediaRFPPrintSettingViewModel

        End Function
        Public Function PrintSettings_Save(ViewModel As AdvantageFramework.ViewModels.Media.MediaRFPPrintSettingViewModel) As Boolean

            Dim Saved As Boolean = False
            Dim PrintSetting As AdvantageFramework.DTO.Media.RFP.PrintSetting = Nothing
            Dim MediaRFPPrintSetting As AdvantageFramework.Database.Entities.MediaRFPPrintSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ViewModel.PrintSettings IsNot Nothing AndAlso ViewModel.PrintSettings.Count > 0 Then

                    PrintSetting = ViewModel.PrintSettings.Item(0)

                    MediaRFPPrintSetting = DbContext.MediaRFPPrintSettings.Find(PrintSetting.ID)

                    If MediaRFPPrintSetting IsNot Nothing Then

                        PrintSetting.SaveToEntity(MediaRFPPrintSetting)

                        DbContext.Entry(MediaRFPPrintSetting).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                        Saved = True

                    End If

                End If

            End Using

            PrintSettings_Save = Saved

        End Function

#End Region

#End Region

#End Region

    End Class

End Namespace
