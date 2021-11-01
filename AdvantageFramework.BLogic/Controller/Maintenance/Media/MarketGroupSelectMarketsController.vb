Namespace Controller.Maintenance.Media

    Public Class MarketGroupSelectMarketsController
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
        Public Function Load(MarketGroupID As Integer) As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSelectMarketsViewModel

            'objects
            Dim MarketGroupSelectMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSelectMarketsViewModel = Nothing
            Dim MarketGroup As AdvantageFramework.Database.Entities.MarketGroup = Nothing

            MarketGroupSelectMarketsViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSelectMarketsViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                MarketGroupSelectMarketsViewModel.MarketGroupID = MarketGroupID

                MarketGroup = DbContext.MarketGroups.Find(MarketGroupID)

                DbContext.Entry(MarketGroup).Reference("Country").Load()

                MarketGroupSelectMarketsViewModel.MarketGroup = New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup(MarketGroup)

                MarketGroupSelectMarketsViewModel.MarketGroupMarkets = DbContext.MarketGroupMarkets.Include("Market.State").Where(Function(Entity) Entity.MarketGroupID = MarketGroupID).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket(Entity)).ToList

                MarketGroupSelectMarketsViewModel.SelectEnabled = True
                MarketGroupSelectMarketsViewModel.CancelEnabled = True

                MarketGroupSelectMarketsViewModel.Markets = DbContext.Markets.Include("Country").Include("State").ToList.Where(Function(Entity) Entity.CountryID.GetValueOrDefault(1) = MarketGroup.CountryID).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market(Entity)).ToList

                For Each Market In MarketGroupSelectMarketsViewModel.Markets.ToList

                    If MarketGroupSelectMarketsViewModel.MarketGroupMarkets.Any(Function(Entity) Entity.MarketCode = Market.Code) Then

                        MarketGroupSelectMarketsViewModel.Markets.Remove(Market)

                    End If

                Next

            End Using

            Load = MarketGroupSelectMarketsViewModel

        End Function
        Public Function Update(ByRef MarketGroupSelectMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSelectMarketsViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Updated As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroupMarket As AdvantageFramework.Database.Entities.MarketGroupMarket = Nothing
            Dim Index As Integer = 0

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    Index = MarketGroupSelectMarketsViewModel.MarketGroupMarkets.Count

                    For Each Market In MarketGroupSelectMarketsViewModel.Markets.ToList

                        If Market.Select Then

                            MarketGroupMarket = New AdvantageFramework.Database.Entities.MarketGroupMarket

                            MarketGroupMarket.MarketGroupID = MarketGroupSelectMarketsViewModel.MarketGroupID
                            MarketGroupMarket.MarketCode = Market.Code
                            MarketGroupMarket.Order = Index

                            DbContext.MarketGroupMarkets.Add(MarketGroupMarket)

                            Index += 1

                        End If

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Updated = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Updated = False
                End Try

            End Using

            Update = Updated

        End Function
        Public Sub SelectAll(ByRef MarketGroupSelectMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSelectMarketsViewModel,
                             Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market))

            For Each Market In Markets

                Market.Select = True

            Next

        End Sub
        Public Sub DeselectAll(ByRef MarketGroupSelectMarketsViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSelectMarketsViewModel,
                               Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market))

            For Each Market In Markets

                Market.Select = False

            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace
