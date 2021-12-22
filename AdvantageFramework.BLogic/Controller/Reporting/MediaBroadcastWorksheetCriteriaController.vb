Imports AdvantageFramework.BaseClasses

Namespace Controller.Reporting

    Public Class MediaBroadcastWorksheetCriteriaController
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

        Private Sub DynamicReports_SetSource(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel, SelectedValue As Nullable(Of Integer))

            'objects
            Dim ShareHPUTBookController As AdvantageFramework.Controller.Media.ShareHPUTBookController = Nothing
            Dim ClientCodes As IEnumerable(Of String) = Nothing

            If SelectedValue.HasValue Then

                If ViewModel.MediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                    ShareHPUTBookController = New AdvantageFramework.Controller.Media.ShareHPUTBookController(Me.Session)

                    If SelectedValue = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                        ViewModel.RepositoryNielsenTVBooks = ShareHPUTBookController.GetRepositoryAllNielsenTVBooks

                    ElseIf SelectedValue = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                        ViewModel.RepositoryNielsenTVBooks = ShareHPUTBookController.GetRepositoryAllComscoreTVBooks

                    ElseIf SelectedValue = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                        ViewModel.RepositoryNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

                    End If

                    ClientCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.LoadAllActive(DbContext)
                                   Where Entity.RatingsServiceID = SelectedValue.Value
                                   Select Entity.ClientCode).Distinct.ToArray

                ElseIf ViewModel.MediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                    ViewModel.RepositoryNielsenRadioBooks = GetRepositoryAllNielsenRadioPeriods()

                    ClientCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.Load(DbContext).Include("MediaBroadcastWorksheet")
                                   Where Entity.ExternalRadioSource = SelectedValue.Value
                                   Select Entity.MediaBroadcastWorksheet.ClientCode).Distinct.ToArray

                End If

                ViewModel.Clients = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext)
                                     Where ClientCodes.Contains(Entity.Code)
                                     Select New AdvantageFramework.Database.Core.Client(Entity)).ToList

                Dim c As New Database.Core.Client
                c.Code = "All Clients"
                c.Name = "All Clients"

                ViewModel.Clients.Insert(0, c)

            Else

                ViewModel.Clients = New Generic.List(Of AdvantageFramework.Database.Core.Client)

            End If

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function GetRepositoryNielsenTVBooks(MediaBroadcastWorksheetMarketBook As DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook, Optional ByVal ShareBookID As Nullable(Of Integer) = Nothing) As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            'objects
            Dim ShareHPUTBookController As AdvantageFramework.Controller.Media.ShareHPUTBookController = Nothing
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing

            ShareHPUTBookController = New AdvantageFramework.Controller.Media.ShareHPUTBookController(Me.Session)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheet = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetID)

            End Using

            If MediaBroadcastWorksheet IsNot Nothing AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                If MediaBroadcastWorksheetMarketBook.IsCable AndAlso MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketTVGeographyID.GetValueOrDefault(1) = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.CDMA Then

                    NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooksForCableCDMA(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber, ShareBookID).OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort).ThenBy(Function(NB) NB.ReportingService).ToList

                Else

                    NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooks(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber, ShareBookID:=ShareBookID).OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort).ThenBy(Function(NB) NB.ReportingService).ToList

                End If

            ElseIf MediaBroadcastWorksheet IsNot Nothing AndAlso MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooks(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber, Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore).OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort).ThenBy(Function(NB) NB.ReportingService).ToList

            End If

            GetRepositoryNielsenTVBooks = NielsenTVBooks

        End Function
        Public Function GetRepositorySecondaryDemographics(MediaBroadcastWorksheetMarketBook As DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

            'objects
            Dim SecondaryDemoIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaDemographics As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SecondaryDemoIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetSecondaryDemo.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetID)
                                    Select Entity.MediaDemographicID).ToArray

                If SecondaryDemoIDs.Count > 0 Then

                    MediaDemographics = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, "T").ToList
                                         Where SecondaryDemoIDs.Contains(Entity.ID)
                                         Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                Else

                    MediaDemographics = New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

                End If

            End Using

            GetRepositorySecondaryDemographics = MediaDemographics

        End Function
        Public Function GetMediaGroupingMetric() As Generic.List(Of AdvantageFramework.DTO.Media.MediaGroupingMetric)
            Dim MediaGroupinglist As Generic.List(Of AdvantageFramework.DTO.Media.MediaGroupingMetric) = Nothing

            MediaGroupinglist = New List(Of DTO.Media.MediaGroupingMetric)

            MediaGroupinglist.Add(New DTO.Media.MediaGroupingMetric(0, "GRP"))
            MediaGroupinglist.Add(New DTO.Media.MediaGroupingMetric(1, "IMP"))

            Return MediaGroupinglist
        End Function
        Public Function GetRepositoryYearMonths(MediaBroadcastWorksheetMarketBook As DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) As Generic.List(Of AdvantageFramework.DTO.YearMonth)

            'objects
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing
            Dim YearMonths As Generic.List(Of AdvantageFramework.DTO.YearMonth) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheet = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetID)

                If MediaBroadcastWorksheet IsNot Nothing Then

                    YearMonths = DbContext.Database.SqlQuery(Of DTO.YearMonth)(String.Format("SELECT DISTINCT BRD_YEAR as Year, BRD_MONTH as Month FROM dbo.fn_BroadcastCal2('01/01/1996') WHERE BRD_WEEK_START >= '{0}' AND BRD_WEEK_END <= '{1}'", MediaBroadcastWorksheet.StartDate, MediaBroadcastWorksheet.EndDate)).ToList

                Else

                    YearMonths = New Generic.List(Of AdvantageFramework.DTO.YearMonth)

                End If

            End Using

            GetRepositoryYearMonths = YearMonths

        End Function
        Public Function Load(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetPrePostReportCriteriaBuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType,
                             MediaBroadcastWorksheetPrePostReportCriteriaMediaType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType) As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel

            'objects
            Dim MediaBroadcastWorksheetCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel = Nothing
            Dim ShareHPUTBookController As AdvantageFramework.Controller.Media.ShareHPUTBookController = Nothing
            Dim IsAgencyASP As Boolean = False
            Dim BookIDs As IEnumerable(Of Integer) = Nothing
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim MediaBroadcastWorksheetMarkets As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket) = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim MaxDate As Date? = Nothing
            Dim LatestShareBookID As Integer? = Nothing
            Dim MediaBroadcastWorksheetPrePostReportCriteria As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteria = Nothing
            Dim PeriodEndDate As Date = Nothing

            MediaBroadcastWorksheetCriteriaViewModel = New AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel
            MediaBroadcastWorksheetCriteriaViewModel.MediaType = MediaBroadcastWorksheetPrePostReportCriteriaMediaType
            MediaBroadcastWorksheetCriteriaViewModel.BuyType = MediaBroadcastWorksheetPrePostReportCriteriaBuyType

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheet.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetID)

                MediaBroadcastWorksheetCriteriaViewModel.RepositoryYearMonths = DbContext.Database.SqlQuery(Of DTO.YearMonth)(String.Format("SELECT DISTINCT BRD_YEAR as Year, BRD_MONTH as Month FROM dbo.fn_BroadcastCal2('01/01/1996') WHERE BRD_WEEK_START >= '{0}' AND BRD_WEEK_END <= '{1}'", MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet.StartDate, MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet.EndDate)).ToList
                MediaBroadcastWorksheetCriteriaViewModel.BypassLoadingYearMonthRepository = True

                MediaBroadcastWorksheetCriteriaViewModel.RepositoryMediaDemographics = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, "T").ToList
                                                                                        Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                MediaBroadcastWorksheetCriteriaViewModel.RepositoryRadioMediaDemographics = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, "R").ToList
                                                                                             Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                MediaBroadcastWorksheetMarkets = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetID).Include("MediaBroadcastWorksheet").
                                                                                                                                                                                                            Include("MediaBroadcastWorksheetMarketDetails").
                                                                                                                                                                                                            Include("MediaBroadcastWorksheetMarketDetails.Vendor").
                                                                                                                                                                                                            Include("Market")
                                                  Select Entity).ToList

                MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)
                MediaBroadcastWorksheetCriteriaViewModel.WorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)

                If MediaBroadcastWorksheetCriteriaViewModel.MediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                    If MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                        MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy.AddRange(MediaBroadcastWorksheetMarkets.Select(Function(Entity) New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(Entity, MediaBroadcastWorksheetPrePostReportCriteriaBuyType)))

                        If DbContext.NPRUniverses.Any Then

                            PeriodEndDate = DbContext.GetQuery(Of Database.Entities.NPRUniverse).Max(Function(Entity) Entity.Date)

                            For Each MediaBroadcastWorksheetMarketBook In MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy

                                If MediaBroadcastWorksheetMarketBook.PeriodStart.HasValue = False Then

                                    MediaBroadcastWorksheetMarketBook.PeriodStart = PeriodEndDate.AddDays(-27)
                                    MediaBroadcastWorksheetMarketBook.PeriodEnd = PeriodEndDate

                                End If

                            Next

                        End If

                    Else

                        ShareHPUTBookController = New AdvantageFramework.Controller.Media.ShareHPUTBookController(Me.Session)

                        If MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                            MediaBroadcastWorksheetCriteriaViewModel.RepositoryNielsenTVBooks = ShareHPUTBookController.GetRepositoryAllNielsenTVBooks

                            MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy.AddRange(MediaBroadcastWorksheetMarkets.Select(Function(Entity) New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(Entity, MediaBroadcastWorksheetPrePostReportCriteriaBuyType)))

                        ElseIf MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                            MediaBroadcastWorksheetCriteriaViewModel.RepositoryNielsenTVBooks = ShareHPUTBookController.GetRepositoryAllComscoreTVBooks().OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort).ToList

                            MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy.AddRange(From Entity In MediaBroadcastWorksheetMarkets
                                                                                                                       Where Entity.Market.ComscoreNewMarketNumber IsNot Nothing
                                                                                                                       Select New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(Entity, MediaBroadcastWorksheetPrePostReportCriteriaBuyType))

                        End If

                    End If

                ElseIf MediaBroadcastWorksheetCriteriaViewModel.MediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                    MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy.AddRange(MediaBroadcastWorksheetMarkets.Select(Function(Entity) New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(Entity, MediaBroadcastWorksheetPrePostReportCriteriaBuyType)))

                    MediaBroadcastWorksheetCriteriaViewModel.RepositoryNielsenRadioBooks = GetRepositoryAllNielsenRadioPeriods()

                End If

                For Each MediaBroadcastWorksheetMarketBook In MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy

                    MediaBroadcastWorksheetMarket = MediaBroadcastWorksheetMarkets.SingleOrDefault(Function(Entity) Entity.ID = MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketID)

                    If MediaBroadcastWorksheetMarket IsNot Nothing Then

                        For Each VendorCode In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.Select(Function(Entity) Entity.VendorCode).Distinct.ToList

                            Try

                                MediaBroadcastWorksheetMarketDetail = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.FirstOrDefault(Function(Entity) Entity.VendorCode = VendorCode)

                            Catch ex As Exception
                                MediaBroadcastWorksheetMarketDetail = Nothing
                            End Try

                            If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                                If MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors.Any(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarket.ID AndAlso
                                                                                                                           Entity.MarketCode = MediaBroadcastWorksheetMarket.MarketCode AndAlso
                                                                                                                           Entity.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode) = False Then

                                    MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors.Add(New DTO.Reporting.WorksheetMarketVendor(MediaBroadcastWorksheetMarketDetail))

                                End If

                            End If

                        Next

                    End If

                    MediaBroadcastWorksheetPrePostReportCriteria = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetPrePostReportCriteria.Load(DbContext)
                                                                    Where Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketID AndAlso
                                                                          Entity.UserCode = Session.UserCode AndAlso
                                                                          Entity.BuyType = MediaBroadcastWorksheetPrePostReportCriteriaBuyType AndAlso
                                                                          Entity.MediaType = MediaBroadcastWorksheetPrePostReportCriteriaMediaType
                                                                    Select Entity).SingleOrDefault

                    If MediaBroadcastWorksheetPrePostReportCriteria IsNot Nothing Then

                        MediaBroadcastWorksheetMarketBook.ShareBookID = MediaBroadcastWorksheetPrePostReportCriteria.SharebookNielsenTVBookID
                        MediaBroadcastWorksheetMarketBook.HPUTBookID = MediaBroadcastWorksheetPrePostReportCriteria.HUTPUTNielsenTVBookID
                        MediaBroadcastWorksheetMarketBook.UsePrimaryDemo = MediaBroadcastWorksheetPrePostReportCriteria.UsePrimaryDemo
                        MediaBroadcastWorksheetMarketBook.UseImpressions = MediaBroadcastWorksheetPrePostReportCriteria.UseImpressions
                        MediaBroadcastWorksheetMarketBook.PrimaryMediaDemographicID = MediaBroadcastWorksheetPrePostReportCriteria.PrimaryMediaDemographicID
                        MediaBroadcastWorksheetMarketBook.SecondaryMediaDemographicID = MediaBroadcastWorksheetPrePostReportCriteria.SecondaryMediaDemographicID
                        MediaBroadcastWorksheetMarketBook.StartDate = MediaBroadcastWorksheetPrePostReportCriteria.StartDate.GetValueOrDefault(MediaBroadcastWorksheetMarketBook.StartDate)
                        MediaBroadcastWorksheetMarketBook.EndDate = MediaBroadcastWorksheetPrePostReportCriteria.EndDate.GetValueOrDefault(MediaBroadcastWorksheetMarketBook.EndDate)
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID1 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID1
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID2 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID2
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID3 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID3
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID4 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID4
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID5 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID5
                        MediaBroadcastWorksheetMarketBook.PeriodStart = MediaBroadcastWorksheetPrePostReportCriteria.PeriodStart
                        MediaBroadcastWorksheetMarketBook.PeriodEnd = MediaBroadcastWorksheetPrePostReportCriteria.PeriodEnd

                    ElseIf MediaBroadcastWorksheetCriteriaViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                        If MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                            If MediaBroadcastWorksheetMarketBook.IsCable AndAlso MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketTVGeographyID.GetValueOrDefault(1) = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.CDMA Then

                                NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooksForCableCDMA(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber)

                            Else

                                NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooks(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber)

                            End If

                        ElseIf MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                            NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooks(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber, Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore)

                        End If

                        MaxDate = Nothing

                        If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails IsNot Nothing Then

                            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails
                                                                      Select Entity.ID).Distinct.ToArray

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                      Entity.Spots > 0
                                Select Entity.Date).Any Then

                                MaxDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                           Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                 Entity.Spots > 0
                                           Select Entity.Date).Max

                            End If

                        End If

                        If NielsenTVBooks IsNot Nothing AndAlso NielsenTVBooks.Count > 0 AndAlso MaxDate.HasValue Then

                            If (From Entity In NielsenTVBooks
                                Where Entity.StartDateTime <= MaxDate.Value AndAlso Entity.EndDateTime >= MaxDate.Value
                                Select Entity.ID, Entity.Year, Entity.Month).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.Month).Any Then

                                LatestShareBookID = (From Entity In NielsenTVBooks
                                                     Where Entity.StartDateTime <= MaxDate.Value AndAlso Entity.EndDateTime >= MaxDate.Value
                                                     Select Entity.ID, Entity.Year, Entity.Month).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.Month).First.ID

                                MediaBroadcastWorksheetMarketBook.ShareBookID = LatestShareBookID

                            End If

                        End If

                    ElseIf MediaBroadcastWorksheetCriteriaViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                        MaxDate = Nothing

                        If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails IsNot Nothing Then

                            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails
                                                                      Select Entity.ID).Distinct.ToArray

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                      Entity.Spots > 0
                                Select Entity.Date).Any Then

                                MaxDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                           Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                 Entity.Spots > 0
                                           Select Entity.Date).Max

                            End If

                        End If

                        'If NielsenTVBooks IsNot Nothing AndAlso NielsenTVBooks.Count > 0 AndAlso MaxDate.HasValue Then

                        '    If (From Entity In NielsenTVBooks
                        '        Where Entity.StartDateTime <= MaxDate.Value AndAlso Entity.EndDateTime >= MaxDate.Value
                        '        Select Entity.ID, Entity.Year, Entity.Month).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.Month).Any Then

                        '        LatestShareBookID = (From Entity In NielsenTVBooks
                        '                             Where Entity.StartDateTime <= MaxDate.Value AndAlso Entity.EndDateTime >= MaxDate.Value
                        '                             Select Entity.ID, Entity.Year, Entity.Month).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.Month).First.ID

                        '        MediaBroadcastWorksheetMarketBook.ShareBookID = LatestShareBookID

                        '    End If

                        'End If

                    End If

                    MediaBroadcastWorksheetMarketBook.SetEntityError(Me.MediaBroadcastWorksheetMarketBookValidateEntity(MediaBroadcastWorksheetMarketBook, True))

                Next

                If MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors IsNot Nothing Then

                    MediaBroadcastWorksheetCriteriaViewModel.WorksheetMarketVendors = MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors.OrderBy(Function(Entity) Entity.MarketCode).ThenBy(Function(Entity) Entity.VendorCode).ToList

                End If

            End Using

            Load = MediaBroadcastWorksheetCriteriaViewModel

        End Function
        Public Function Load(MediaBroadcastWorksheetPrePostReportCriteriaBuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType,
                             MediaBroadcastWorksheetPrePostReportCriteriaMediaType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType) As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel

            'objects
            Dim MediaBroadcastWorksheetCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel = Nothing

            MediaBroadcastWorksheetCriteriaViewModel = New AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel
            MediaBroadcastWorksheetCriteriaViewModel.MediaType = MediaBroadcastWorksheetPrePostReportCriteriaMediaType
            MediaBroadcastWorksheetCriteriaViewModel.BuyType = MediaBroadcastWorksheetPrePostReportCriteriaBuyType

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                    MediaBroadcastWorksheetCriteriaViewModel.RatingsServiceList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID))
                                                                                   Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                    DynamicReports_SetSource(DbContext, MediaBroadcastWorksheetCriteriaViewModel, Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen)

                    MediaBroadcastWorksheetCriteriaViewModel.RepositoryMediaDemographics = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, "T").ToList
                                                                                            Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                ElseIf MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                    MediaBroadcastWorksheetCriteriaViewModel.RatingsServiceList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Nielsen.Database.Entities.RadioSource))
                                                                                   Where Entity.Code <> "2"
                                                                                   Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                    DynamicReports_SetSource(DbContext, MediaBroadcastWorksheetCriteriaViewModel, Nielsen.Database.Entities.RadioSource.Nielsen)

                    MediaBroadcastWorksheetCriteriaViewModel.RepositoryRadioMediaDemographics = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, "R").ToList
                                                                                                 Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                End If

                MediaBroadcastWorksheetCriteriaViewModel.RepositoryYearMonths = DbContext.Database.SqlQuery(Of DTO.YearMonth)("SELECT DISTINCT BRD_YEAR as Year, BRD_MONTH as Month FROM dbo.fn_BroadcastCal2('01/01/1996')").ToList

            End Using

            Load = MediaBroadcastWorksheetCriteriaViewModel

        End Function
        Public Sub GetMediaBroadcastWorksheetMarketBooks(ClientCode As String, StartDateFrom As Date, StartDateTo As Date, ByRef MediaBroadcastWorksheetCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel,
                                                         MediaBroadcastWorksheetPrePostReportCriteriaBuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType, RatingServiceID As Integer)

            'objects
            Dim IsAgencyASP As Boolean = False
            Dim BookIDs As IEnumerable(Of Integer) = Nothing
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim MediaBroadcastWorksheetMarkets As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket) = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim MaxDate As Date? = Nothing
            Dim LatestShareBookID As Integer? = Nothing
            Dim MediaBroadcastWorksheetPrePostReportCriteria As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteria = Nothing
            Dim ShareHPUTBookController As AdvantageFramework.Controller.Media.ShareHPUTBookController = Nothing
            Dim MediaBroadcastWorksheetPrePostReportCriteriaMediaType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV
            Dim MediaTypeCode As String = Nothing
            Dim ClientCodes As String() = Nothing
            Dim PeriodEndDate As Date = Nothing

            MediaBroadcastWorksheetPrePostReportCriteriaMediaType = MediaBroadcastWorksheetCriteriaViewModel.MediaType

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                    ShareHPUTBookController = New AdvantageFramework.Controller.Media.ShareHPUTBookController(Me.Session)

                    MediaTypeCode = "T"

                Else

                    MediaTypeCode = "R"

                End If

                If ClientCode = "All Clients" Then

                    ClientCodes = (From Entity In MediaBroadcastWorksheetCriteriaViewModel.Clients
                                   Select Entity.Code).ToArray

                    If MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                        MediaBroadcastWorksheetMarkets = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.Load(DbContext).Include("MediaBroadcastWorksheet").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails.Vendor").
                                                                                                                                                              Include("Market")
                                                          Where Entity.MediaBroadcastWorksheet.MediaTypeCode = MediaTypeCode AndAlso
                                                                Entity.MediaBroadcastWorksheet.IsInactive = False AndAlso
                                                                Entity.MediaBroadcastWorksheet.StartDate >= StartDateFrom AndAlso
                                                                Entity.MediaBroadcastWorksheet.StartDate <= StartDateTo AndAlso
                                                                ClientCodes.Contains(Entity.MediaBroadcastWorksheet.ClientCode) AndAlso
                                                                Entity.MediaBroadcastWorksheet.RatingsServiceID = RatingServiceID
                                                          Select Entity).ToList

                    ElseIf MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                        MediaBroadcastWorksheetMarkets = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.Load(DbContext).Include("MediaBroadcastWorksheet").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails.Vendor").
                                                                                                                                                              Include("Market")
                                                          Where Entity.MediaBroadcastWorksheet.MediaTypeCode = MediaTypeCode AndAlso
                                                                Entity.MediaBroadcastWorksheet.IsInactive = False AndAlso
                                                                Entity.MediaBroadcastWorksheet.StartDate >= StartDateFrom AndAlso
                                                                Entity.MediaBroadcastWorksheet.StartDate <= StartDateTo AndAlso
                                                                ClientCodes.Contains(Entity.MediaBroadcastWorksheet.ClientCode) AndAlso
                                                                Entity.ExternalRadioSource = RatingServiceID
                                                          Select Entity).ToList

                    End If

                Else

                    If MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                        MediaBroadcastWorksheetMarkets = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.Load(DbContext).Include("MediaBroadcastWorksheet").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails.Vendor").
                                                                                                                                                              Include("Market")
                                                          Where Entity.MediaBroadcastWorksheet.MediaTypeCode = MediaTypeCode AndAlso
                                                                    Entity.MediaBroadcastWorksheet.IsInactive = False AndAlso
                                                                    Entity.MediaBroadcastWorksheet.ClientCode = ClientCode AndAlso
                                                                    Entity.MediaBroadcastWorksheet.StartDate >= StartDateFrom AndAlso
                                                                    Entity.MediaBroadcastWorksheet.StartDate <= StartDateTo AndAlso
                                                                    Entity.MediaBroadcastWorksheet.RatingsServiceID = RatingServiceID
                                                          Select Entity).ToList

                    ElseIf MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                        MediaBroadcastWorksheetMarkets = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.Load(DbContext).Include("MediaBroadcastWorksheet").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails").
                                                                                                                                                              Include("MediaBroadcastWorksheetMarketDetails.Vendor").
                                                                                                                                                              Include("Market")
                                                          Where Entity.MediaBroadcastWorksheet.MediaTypeCode = MediaTypeCode AndAlso
                                                                    Entity.MediaBroadcastWorksheet.IsInactive = False AndAlso
                                                                    Entity.MediaBroadcastWorksheet.ClientCode = ClientCode AndAlso
                                                                    Entity.MediaBroadcastWorksheet.StartDate >= StartDateFrom AndAlso
                                                                    Entity.MediaBroadcastWorksheet.StartDate <= StartDateTo AndAlso
                                                                    Entity.ExternalRadioSource = RatingServiceID
                                                          Select Entity).ToList

                    End If

                End If

                MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)
                MediaBroadcastWorksheetCriteriaViewModel.WorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)

                If RatingServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                    MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy = MediaBroadcastWorksheetMarkets.Where(Function(Entity) Entity.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore AndAlso
                                                                                                                                                 Entity.Market.ComscoreNewMarketNumber IsNot Nothing).Select(Function(Entity) New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(Entity, MediaBroadcastWorksheetPrePostReportCriteriaBuyType)).OrderBy(Function(Entity) Entity.WorksheetName).ToList

                Else

                    MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy = MediaBroadcastWorksheetMarkets.Select(Function(Entity) New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(Entity, MediaBroadcastWorksheetPrePostReportCriteriaBuyType)).OrderBy(Function(Entity) Entity.WorksheetName).ToList

                End If

                IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                For Each MediaBroadcastWorksheetMarketBook In MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy

                    MediaBroadcastWorksheetMarket = MediaBroadcastWorksheetMarkets.SingleOrDefault(Function(Entity) Entity.ID = MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketID)

                    If MediaBroadcastWorksheetMarket IsNot Nothing Then

                        For Each VendorCode In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.Select(Function(Entity) Entity.VendorCode).Distinct.ToList

                            Try

                                MediaBroadcastWorksheetMarketDetail = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.FirstOrDefault(Function(Entity) Entity.VendorCode = VendorCode)

                            Catch ex As Exception
                                MediaBroadcastWorksheetMarketDetail = Nothing
                            End Try

                            If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                                If MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors.Any(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarket.ID AndAlso
                                                                                                                           Entity.MarketCode = MediaBroadcastWorksheetMarket.MarketCode AndAlso
                                                                                                                           Entity.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode) = False Then

                                    MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors.Add(New DTO.Reporting.WorksheetMarketVendor(MediaBroadcastWorksheetMarketDetail))

                                End If

                            End If

                        Next

                    End If

                    MediaBroadcastWorksheetPrePostReportCriteria = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetPrePostReportCriteria.Load(DbContext)
                                                                    Where Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketID AndAlso
                                                                          Entity.UserCode = Session.UserCode AndAlso
                                                                          Entity.BuyType = MediaBroadcastWorksheetPrePostReportCriteriaBuyType AndAlso
                                                                          Entity.MediaType = MediaBroadcastWorksheetPrePostReportCriteriaMediaType
                                                                    Select Entity).SingleOrDefault

                    If MediaBroadcastWorksheetPrePostReportCriteria IsNot Nothing Then

                        MediaBroadcastWorksheetMarketBook.ShareBookID = MediaBroadcastWorksheetPrePostReportCriteria.SharebookNielsenTVBookID
                        MediaBroadcastWorksheetMarketBook.HPUTBookID = MediaBroadcastWorksheetPrePostReportCriteria.HUTPUTNielsenTVBookID
                        MediaBroadcastWorksheetMarketBook.UsePrimaryDemo = MediaBroadcastWorksheetPrePostReportCriteria.UsePrimaryDemo
                        MediaBroadcastWorksheetMarketBook.UseImpressions = MediaBroadcastWorksheetPrePostReportCriteria.UseImpressions
                        MediaBroadcastWorksheetMarketBook.PrimaryMediaDemographicID = MediaBroadcastWorksheetPrePostReportCriteria.PrimaryMediaDemographicID
                        MediaBroadcastWorksheetMarketBook.SecondaryMediaDemographicID = MediaBroadcastWorksheetPrePostReportCriteria.SecondaryMediaDemographicID
                        MediaBroadcastWorksheetMarketBook.StartDate = MediaBroadcastWorksheetPrePostReportCriteria.StartDate.GetValueOrDefault(MediaBroadcastWorksheetMarketBook.StartDate)
                        MediaBroadcastWorksheetMarketBook.EndDate = MediaBroadcastWorksheetPrePostReportCriteria.EndDate.GetValueOrDefault(MediaBroadcastWorksheetMarketBook.EndDate)
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID1 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID1
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID2 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID2
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID3 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID3
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID4 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID4
                        MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID5 = MediaBroadcastWorksheetPrePostReportCriteria.NeilsenRadioPeriodID5
                        MediaBroadcastWorksheetMarketBook.PeriodStart = MediaBroadcastWorksheetPrePostReportCriteria.PeriodStart
                        MediaBroadcastWorksheetMarketBook.PeriodEnd = MediaBroadcastWorksheetPrePostReportCriteria.PeriodEnd

                    ElseIf MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                        If RatingServiceID = Nielsen.Database.Entities.RatingsServiceID.NielsenPuertoRico AndAlso Session.IsNielsenPuertoRicoSetup Then

                            If DbContext.NPRUniverses.Any Then

                                PeriodEndDate = DbContext.GetQuery(Of Database.Entities.NPRUniverse).Max(Function(Entity) Entity.Date)

                                MediaBroadcastWorksheetMarketBook.PeriodStart = PeriodEndDate.AddDays(-27)
                                MediaBroadcastWorksheetMarketBook.PeriodEnd = PeriodEndDate

                            End If

                        Else

                            If MediaBroadcastWorksheetMarketBook.IsCable AndAlso MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketTVGeographyID.GetValueOrDefault(1) = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.CDMA Then

                                NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooksForCableCDMA(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber)

                            Else

                                NielsenTVBooks = ShareHPUTBookController.GetRepositoryNielsenTVBooks(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber)

                            End If

                            MaxDate = Nothing

                            If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails IsNot Nothing Then

                                MediaBroadcastWorksheetMarketDetailIDs = (From Entity In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails
                                                                          Select Entity.ID).Distinct.ToArray

                                If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                    Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                      Entity.Spots > 0
                                    Select Entity.Date).Any Then

                                    MaxDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                               Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                 Entity.Spots > 0
                                               Select Entity.Date).Max

                                End If

                            End If

                            If NielsenTVBooks IsNot Nothing AndAlso NielsenTVBooks.Count > 0 AndAlso MaxDate.HasValue Then

                                If (From Entity In NielsenTVBooks
                                    Where Entity.StartDateTime <= MaxDate.Value AndAlso Entity.EndDateTime >= MaxDate.Value
                                    Select Entity.ID, Entity.Year, Entity.Month).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.Month).Any Then

                                    LatestShareBookID = (From Entity In NielsenTVBooks
                                                         Where Entity.StartDateTime <= MaxDate.Value AndAlso Entity.EndDateTime >= MaxDate.Value
                                                         Select Entity.ID, Entity.Year, Entity.Month).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.Month).First.ID

                                    MediaBroadcastWorksheetMarketBook.ShareBookID = LatestShareBookID

                                End If

                            End If

                        End If

                        'ElseIf MediaBroadcastWorksheetPrePostReportCriteriaMediaType = Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                    End If

                    MediaBroadcastWorksheetMarketBook.SetEntityError(Me.MediaBroadcastWorksheetMarketBookValidateEntity(MediaBroadcastWorksheetMarketBook, True))

                Next

                If MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors IsNot Nothing Then

                    MediaBroadcastWorksheetCriteriaViewModel.WorksheetMarketVendors = MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors.OrderBy(Function(Entity) Entity.MarketCode).ThenBy(Function(Entity) Entity.VendorCode).ToList

                End If

            End Using

        End Sub
        Public Sub GetVendors(ByRef MediaBroadcastWorksheetCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel,
                              MediaBroadcastWorksheetMarketIDs As Generic.List(Of Integer))

            'objects
            Dim MediaBroadcastWorksheetMarkets As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket) = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing

            If MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors IsNot Nothing Then

                MediaBroadcastWorksheetCriteriaViewModel.WorksheetMarketVendors = MediaBroadcastWorksheetCriteriaViewModel.AllWorksheetMarketVendors.Where(Function(Entity) MediaBroadcastWorksheetMarketIDs.Contains(Entity.MediaBroadcastWorksheetMarketID)).
                                                                                                                                                     OrderBy(Function(Entity) Entity.MarketCode).
                                                                                                                                                     ThenBy(Function(Entity) Entity.VendorCode).ToList

            Else

                MediaBroadcastWorksheetCriteriaViewModel.WorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)

            End If

        End Sub
        Public Sub UpdateMediaBroadcastWorksheetMarketBooks(ByRef MediaBroadcastWorksheetCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel,
                                                            MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

            For Each MBWMB In MediaBroadcastWorksheetCriteriaViewModel.MediaBroadcastWorksheetMarketBooksPreBuy.Where(Function(Entity) Entity.MediaBroadcastWorksheetID = MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetID).ToList

                MBWMB.UsePrimaryDemo = MediaBroadcastWorksheetMarketBook.UsePrimaryDemo
                MBWMB.SecondaryMediaDemographicID = MediaBroadcastWorksheetMarketBook.SecondaryMediaDemographicID
                MBWMB.UseImpressions = MediaBroadcastWorksheetMarketBook.UseImpressions

                MBWMB.StartDate = MediaBroadcastWorksheetMarketBook.StartDate
                MBWMB.EndDate = MediaBroadcastWorksheetMarketBook.EndDate

                'MBWMB.BroadcastStartYearMonth = MediaBroadcastWorksheetMarketBook.BroadcastStartYearMonth

                'If Not MediaBroadcastWorksheetMarketBook.BroadcastEndYearMonth.HasValue Then

                '    MBWMB.BroadcastEndYearMonth = MediaBroadcastWorksheetMarketBook.BroadcastStartYearMonth

                'ElseIf ColumnFieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.BroadcastStartYearMonth.ToString AndAlso MediaBroadcastWorksheetMarketBook.BroadcastStartYearMonth.HasValue AndAlso
                '        MediaBroadcastWorksheetMarketBook.BroadcastStartYearMonth.Value > MediaBroadcastWorksheetMarketBook.BroadcastEndYearMonth.Value Then

                '    MBWMB.BroadcastEndYearMonth = MediaBroadcastWorksheetMarketBook.BroadcastStartYearMonth

                'Else

                '    MBWMB.BroadcastEndYearMonth = MediaBroadcastWorksheetMarketBook.BroadcastEndYearMonth

                'End If

                MBWMB.SetEntityError(Me.MediaBroadcastWorksheetMarketBookValidateEntity(MBWMB, True))

            Next

        End Sub
        Public Overrides Sub SetRequiredFields(ByRef DTO As DTO.BaseClass)

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(DTO).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            If DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)) Then

                MediaBroadcastWorksheetMarketBook = DTO

                For Each PropertyDescriptor In PropertyDescriptors

                    Select Case PropertyDescriptor.Name

                        'Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PrimaryMediaDemographicID.ToString

                        '    DTO.SetRequired(PropertyDescriptor, DirectCast(DTO, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).UsePrimaryDemo)

                        'Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.SecondaryMediaDemographicID.ToString

                        '    DTO.SetRequired(PropertyDescriptor, Not DirectCast(DTO, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).UsePrimaryDemo)

                        Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString

                            DTO.SetRequired(PropertyDescriptor, True)

                        Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString

                            DTO.SetRequired(PropertyDescriptor, True)

                        Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString

                            DTO.SetRequired(PropertyDescriptor, MediaBroadcastWorksheetMarketBook.PeriodStart.HasValue OrElse MediaBroadcastWorksheetMarketBook.PeriodEnd.HasValue)

                        Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString

                            DTO.SetRequired(PropertyDescriptor, MediaBroadcastWorksheetMarketBook.PeriodStart.HasValue OrElse MediaBroadcastWorksheetMarketBook.PeriodEnd.HasValue)

                    End Select

                Next

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(DbContext As DbContext, DataContext As DataContext, ByRef DTO As DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            If DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)) Then

                MediaBroadcastWorksheetMarketBook = DTO

                Select Case PropertyName

                    Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing Then

                            If PropertyValue > DirectCast(DTO, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).EndDate Then

                                IsValid = False

                                ErrorText = "Dates must be in chronological order, please correct."

                            End If

                        End If

                    Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing Then

                            If PropertyValue < DirectCast(DTO, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).StartDate Then

                                IsValid = False

                                ErrorText = "Dates must be in chronological order, please correct."

                            End If

                        End If

                    Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing AndAlso MediaBroadcastWorksheetMarketBook.PeriodEnd.HasValue Then

                            If PropertyValue > MediaBroadcastWorksheetMarketBook.PeriodEnd.Value Then

                                IsValid = False

                                ErrorText = "Periods must be in chronological order, please correct."

                            ElseIf (From Entity In DbContext.GetQuery(Of Database.Entities.NPRUniverse)
                                    Where Entity.Date >= DirectCast(PropertyValue, Date) AndAlso
                                          Entity.Date <= MediaBroadcastWorksheetMarketBook.PeriodEnd.Value
                                    Select Entity).Count <> DateDiff(DateInterval.Day, DirectCast(PropertyValue, Date), MediaBroadcastWorksheetMarketBook.PeriodEnd.Value) + 1 Then

                                IsValid = False

                                ErrorText = "More than one universe record is missing for the period date range specified."

                            End If

                        End If


                    Case AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing AndAlso MediaBroadcastWorksheetMarketBook.PeriodStart.HasValue Then

                            If PropertyValue < MediaBroadcastWorksheetMarketBook.PeriodStart.Value Then

                                IsValid = False

                                ErrorText = "Periods must be in chronological order, please correct."

                            ElseIf (From Entity In DbContext.GetQuery(Of Database.Entities.NPRUniverse)
                                    Where Entity.Date >= MediaBroadcastWorksheetMarketBook.PeriodStart.Value AndAlso
                                          Entity.Date <= DirectCast(PropertyValue, Date)
                                    Select Entity).Count <> DateDiff(DateInterval.Day, MediaBroadcastWorksheetMarketBook.PeriodStart.Value, DirectCast(PropertyValue, Date)) + 1 Then

                                IsValid = False

                                ErrorText = "More than one universe record is missing for the period date range specified."

                            End If

                        End If

                End Select

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Function MediaBroadcastWorksheetMarketBookValidateEntity(ByRef MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = Nothing

            SetRequiredFields(MediaBroadcastWorksheetMarketBook)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaBroadcastWorksheetMarketBook, IsValid)

                End Using

            End Using

            MediaBroadcastWorksheetMarketBookValidateEntity = ErrorText

        End Function
        'Public Function MediaBroadcastWorksheetMarketBookPreBuyValidateEntity(ByRef MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook, ByRef IsValid As Boolean) As String

        '    'objects
        '    Dim ErrorText As String = Nothing

        '    SetRequiredFields(MediaBroadcastWorksheetMarketBook)

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '            ErrorText = ValidateDTO(DbContext, DataContext, MediaBroadcastWorksheetMarketBook, IsValid)

        '        End Using

        '    End Using

        '    MediaBroadcastWorksheetMarketBookPreBuyValidateEntity = ErrorText

        'End Function
        Public Function ValidateEntityProperty(MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaBroadcastWorksheetMarketBook.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaBroadcastWorksheetMarketBook, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateEntityProperty = ErrorText

        End Function
        Public Sub SaveCriteria(MediaBroadcastWorksheetMarketBooks As Generic.List(Of DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook),
                                MediaBroadcastWorksheetPrePostReportCriteriaBuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType,
                                MediaBroadcastWorksheetPrePostReportCriteriaMediaType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType)

            'objects
            Dim MediaBroadcastWorksheetPrePostReportCriteria As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteria = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each MediaBroadcastWorksheetMarketBook In MediaBroadcastWorksheetMarketBooks

                    MediaBroadcastWorksheetPrePostReportCriteria = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetPrePostReportCriteria.Load(DbContext)
                                                                    Where Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketID AndAlso
                                                                          Entity.UserCode = Session.UserCode AndAlso
                                                                          Entity.BuyType = MediaBroadcastWorksheetPrePostReportCriteriaBuyType AndAlso
                                                                          Entity.MediaType = MediaBroadcastWorksheetPrePostReportCriteriaMediaType
                                                                    Select Entity).SingleOrDefault

                    If MediaBroadcastWorksheetPrePostReportCriteria IsNot Nothing Then

                        MediaBroadcastWorksheetMarketBook.SaveToEntity(MediaBroadcastWorksheetPrePostReportCriteria)

                        DbContext.Entry(MediaBroadcastWorksheetPrePostReportCriteria).State = System.Data.Entity.EntityState.Modified

                    Else

                        MediaBroadcastWorksheetPrePostReportCriteria = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteria
                        MediaBroadcastWorksheetPrePostReportCriteria.UserCode = Session.UserCode
                        MediaBroadcastWorksheetPrePostReportCriteria.BuyType = MediaBroadcastWorksheetPrePostReportCriteriaBuyType
                        MediaBroadcastWorksheetPrePostReportCriteria.MediaType = MediaBroadcastWorksheetPrePostReportCriteriaMediaType

                        MediaBroadcastWorksheetMarketBook.SaveToEntity(MediaBroadcastWorksheetPrePostReportCriteria)

                        DbContext.MediaBroadcastWorksheetPrePostReportCriterias.Add(MediaBroadcastWorksheetPrePostReportCriteria)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub DynamicReports_SetSource(ByRef ViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel, SelectedValue As Nullable(Of Integer))

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DynamicReports_SetSource(DbContext, ViewModel, SelectedValue)

            End Using

        End Sub
        Public Function GetRepositoryAllNielsenRadioPeriods() As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

            'objects
            Dim NielsenRadioController As AdvantageFramework.Controller.Media.NielsenRadioController = Nothing
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing

            NielsenRadioController = New AdvantageFramework.Controller.Media.NielsenRadioController(Me.Session)

            NielsenRadioPeriods = NielsenRadioController.LoadAllNieslenRadioPeriods.OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.SortMonth).ToList

            GetRepositoryAllNielsenRadioPeriods = NielsenRadioPeriods

        End Function
        Public Function GetRepositoryNielsenRadioPeriods(MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook,
                                                         ExcludeNielsenRadioPeriodIDs As Generic.List(Of Integer)) As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

            'objects
            Dim NielsenRadioController As AdvantageFramework.Controller.Media.NielsenRadioController = Nothing
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing

            NielsenRadioController = New AdvantageFramework.Controller.Media.NielsenRadioController(Me.Session)

            NielsenRadioPeriods = NielsenRadioController.LoadNieslenRadioPeriods(MediaBroadcastWorksheetMarketBook.NielsenMarketNumber, MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketRadioEthnicityID,
                                                                                 MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketRadioGeographyID, ExcludeNielsenRadioPeriodIDs, MediaBroadcastWorksheetMarketBook.ExternalRadioSource).OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.SortMonth).ToList

            GetRepositoryNielsenRadioPeriods = NielsenRadioPeriods

        End Function
        Public Function GetRadioRepositorySecondaryDemographics(MediaBroadcastWorksheetMarketBook As DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

            'objects
            Dim SecondaryDemoIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaDemographics As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SecondaryDemoIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetSecondaryDemo.LoadByMediaBroadcastWorksheetID(DbContext, MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetID)
                                    Select Entity.MediaDemographicID).ToArray

                If SecondaryDemoIDs.Count > 0 Then

                    MediaDemographics = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByType(DbContext, "R").ToList
                                         Where SecondaryDemoIDs.Contains(Entity.ID)
                                         Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).ToList

                Else

                    MediaDemographics = New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

                End If

            End Using

            GetRadioRepositorySecondaryDemographics = MediaDemographics

        End Function

#End Region

#End Region

    End Class

End Namespace
