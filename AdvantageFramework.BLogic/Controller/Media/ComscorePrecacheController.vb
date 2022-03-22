Option Strict On

Namespace Controller.Media

    Public Class ComscorePrecacheController
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

        Private Sub LoadMarkets(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            ViewModel.Markets.Clear()
            ViewModel.Markets.AddRange((From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComscorePrecacheMarket).Include("Market").ToList
                                        Select New DTO.Media.ComscorePrecache.Market(Entity)).ToList)

        End Sub
        Private Sub LoadMarketStations(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            ViewModel.MarketStations.Clear()
            ViewModel.MarketStations.AddRange(DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.ComscorePrecache.Station)(String.Format("exec advsp_comscore_precache_stations {0},{1}", ViewModel.SelectedMarket.ComscorePrecacheMarketID, ViewModel.SelectedMarket.ComscoreNewMarketNumber)).ToList)

        End Sub
        Private Sub LoadMarketBooks(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            ViewModel.MarketBooks.Clear()
            ViewModel.MarketBooks.AddRange(DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.ComscorePrecache.Book)(String.Format("exec advsp_comscore_precache_books {0}", ViewModel.SelectedMarket.ComscorePrecacheMarketID)).ToList)

        End Sub
        Private Sub LoadMarketDemographics(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            ViewModel.MarketDemographics.Clear()
            ViewModel.MarketDemographics.AddRange(DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.ComscorePrecache.Demographic)(String.Format("exec advsp_comscore_precache_demographics {0}", ViewModel.SelectedMarket.ComscorePrecacheMarketID)).ToList)

        End Sub
        Private Sub LoadMarketCached(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            ViewModel.MarketCached.Clear()
            ViewModel.MarketCached.AddRange(DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.ComscorePrecache.Cache)(String.Format("exec advsp_comscore_cache_results {0}", ViewModel.SelectedMarket.ComscorePrecacheMarketID)).ToList)

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel

            'objects
            Dim ComscorePrecacheViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel = Nothing

            ComscorePrecacheViewModel = New AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMarkets(DbContext, ComscorePrecacheViewModel)

            End Using

            Load = ComscorePrecacheViewModel

        End Function
        Public Sub AddMarket(MarketCode As String, ByRef ComscorePrecacheViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.COMSCORE_PRECACHE_MARKET (MARKET_CODE) VALUES ('{0}')", MarketCode))

                Catch ex As Exception

                End Try

                LoadMarkets(DbContext, ComscorePrecacheViewModel)

            End Using

        End Sub
        Public Sub DeleteMarket(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.COMSCORE_PRECACHE_MARKET_STATION WHERE COMSCORE_PRECACHE_MARKET_ID = {0}", ViewModel.SelectedMarket.ComscorePrecacheMarketID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.COMSCORE_PRECACHE_MARKET_BOOK WHERE COMSCORE_PRECACHE_MARKET_ID = {0}", ViewModel.SelectedMarket.ComscorePrecacheMarketID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.COMSCORE_PRECACHE_MARKET_DEMOGRAPHIC WHERE COMSCORE_PRECACHE_MARKET_ID = {0}", ViewModel.SelectedMarket.ComscorePrecacheMarketID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.COMSCORE_PRECACHE_MARKET WHERE COMSCORE_PRECACHE_MARKET_ID = {0}", ViewModel.SelectedMarket.ComscorePrecacheMarketID))

                Catch ex As Exception

                End Try

                LoadMarkets(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub AddMarketStation(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel, StationNumber As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.COMSCORE_PRECACHE_MARKET_STATION (COMSCORE_PRECACHE_MARKET_ID, STATION_NUMBER) VALUES ({0}, {1})", ViewModel.SelectedMarket.ComscorePrecacheMarketID, StationNumber))

                Catch ex As Exception

                End Try

                LoadMarketStations(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub DeleteMarketStation(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel, MarketStationID As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.COMSCORE_PRECACHE_MARKET_STATION WHERE COMSCORE_PRECACHE_MARKET_STATION_ID = {0}", MarketStationID))

                Catch ex As Exception

                End Try

                LoadMarketStations(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub GetMarketStations(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMarketStations(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub AddMarketBook(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel, ComscoreTVBookID As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.COMSCORE_PRECACHE_MARKET_BOOK (COMSCORE_PRECACHE_MARKET_ID, COMSCORE_TV_BOOK_ID) VALUES ({0}, {1})", ViewModel.SelectedMarket.ComscorePrecacheMarketID, ComscoreTVBookID))

                Catch ex As Exception

                End Try

                LoadMarketBooks(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub DeleteMarketBook(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel, MarketBookID As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.COMSCORE_PRECACHE_MARKET_BOOK WHERE COMSCORE_PRECACHE_MARKET_BOOK_ID = {0}", MarketBookID))

                Catch ex As Exception

                End Try

                LoadMarketBooks(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub GetMarketBooks(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMarketBooks(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub AddMarketDemographic(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel, ComscoreDemoNumber As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.COMSCORE_PRECACHE_MARKET_DEMOGRAPHIC (COMSCORE_PRECACHE_MARKET_ID, COMSCORE_DEMO_NUMBER) VALUES ({0}, {1})", ViewModel.SelectedMarket.ComscorePrecacheMarketID, ComscoreDemoNumber))

                Catch ex As Exception

                End Try

                LoadMarketDemographics(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub DeleteMarketDemographic(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel, ComscorePrecacheMarketDemoID As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.COMSCORE_PRECACHE_MARKET_DEMOGRAPHIC WHERE COMSCORE_PRECACHE_MARKET_DEMOGRAPHIC_ID = {0}", ComscorePrecacheMarketDemoID))

                Catch ex As Exception

                End Try

                LoadMarketDemographics(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub GetMarketDemographics(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMarketDemographics(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub GetMarketCached(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMarketCached(DbContext, ViewModel)

            End Using

        End Sub
        Public Sub ClearMarketStations(ByRef ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel)

            ViewModel.MarketStations.Clear()

        End Sub

#End Region

#End Region

    End Class

End Namespace
