Namespace Controller.Maintenance.Media

    Public Class MarketGroupSetupController
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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel

            'objects
            Dim MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel = Nothing

            MarketGroupSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                MarketGroupSetupViewModel.MarketGroups = DbContext.MarketGroups.Include("Country").ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup(Entity)).ToList

                'MarketGroupSetupViewModel.Markets = DbContext.Markets.ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market(Entity)).ToList
                MarketGroupSetupViewModel.Countries = DbContext.Countries.ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Country(Entity)).ToList

            End Using

            Load = MarketGroupSetupViewModel

        End Function
        Public Function Save(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroup As AdvantageFramework.Database.Entities.MarketGroup = Nothing
            Dim MarketGroupMarket As AdvantageFramework.Database.Entities.MarketGroupMarket = Nothing
            Dim MarketGroupMarkets As Generic.List(Of AdvantageFramework.Database.Entities.MarketGroupMarket) = Nothing
            Dim MarketCodes As Generic.List(Of String) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    MarketGroup = DbContext.MarketGroups.Find(MarketGroupSetupViewModel.SelectedMarketGroup.ID)

                    MarketGroupSetupViewModel.SelectedMarketGroup.SaveToEntity(MarketGroup)

                    MarketGroupMarkets = DbContext.MarketGroupMarkets.Where(Function(Entity) Entity.MarketGroupID = MarketGroup.ID).ToList

                    MarketCodes = New Generic.List(Of String)

                    For Each MGMarket In MarketGroupSetupViewModel.MarketGroupMarkets

                        If MGMarket.ID = 0 Then

                            MarketGroupMarket = New AdvantageFramework.Database.Entities.MarketGroupMarket

                            MarketGroupMarket.MarketGroupID = MarketGroup.ID

                            DbContext.MarketGroupMarkets.Add(MarketGroupMarket)

                        Else

                            Try

                                MarketGroupMarket = MarketGroupMarkets.FirstOrDefault(Function(Entity) Entity.ID = MGMarket.ID)

                            Catch ex As Exception
                                MarketGroupMarket = Nothing
                            End Try

                            If MarketGroupMarket Is Nothing Then

                                Throw New Exception("Failed to find market group market.")

                            End If

                        End If

                        MGMarket.SaveToEntity(MarketGroupMarket)

                        MarketCodes.Add(MarketGroupMarket.MarketCode)

                    Next

                    For Each MGM In MarketGroupMarkets.ToList.Where(Function(Entity) MarketCodes.Contains(Entity.MarketCode) = False)

                        DbContext.MarketGroupMarkets.Remove(MGM)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Saved = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Saved = False
                End Try

            End Using

            Save = Saved

        End Function
        Public Function Delete(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroup As AdvantageFramework.Database.Entities.MarketGroup = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    MarketGroup = DbContext.MarketGroups.Find(MarketGroupSetupViewModel.SelectedMarketGroup.ID)

                    DbContext.Entry(MarketGroup).Collection("MarketGroupMarkets").Load()

                    If MarketGroup.MarketGroupMarkets IsNot Nothing AndAlso MarketGroup.MarketGroupMarkets.Count > 0 Then

                        For Each MGM In MarketGroup.MarketGroupMarkets.ToList

                            DbContext.MarketGroupMarkets.Remove(MGM)

                        Next

                    End If

                    DbContext.MarketGroups.Remove(MarketGroup)

                    DbContext.Configuration.AutoDetectChangesEnabled = True
                    DbContext.SaveChanges()

                    DbTransaction.Commit()

                    Deleted = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += System.Environment.NewLine & ex.Message
                    Deleted = False
                End Try

            End Using

            Delete = Deleted

        End Function
        Public Sub RefreshMarketGroups(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MarketGroupSetupViewModel.MarketGroups = DbContext.MarketGroups.Include("Country").ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup(Entity)).ToList

            End Using

        End Sub
        Public Sub MarketGroupSelectionChanged(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel,
                                               SelectedMarketGroup As AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup)

            MarketGroupSetupViewModel.SelectedMarketGroup = SelectedMarketGroup

            If SelectedMarketGroup IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MarketGroupSetupViewModel.MarketGroupMarkets = DbContext.MarketGroupMarkets.Include("Market.State").Where(Function(Entity) Entity.MarketGroupID = SelectedMarketGroup.ID).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket(Entity)).ToList

                    If MarketGroupSetupViewModel.MarketGroupMarkets IsNot Nothing Then

                        MarketGroupSetupViewModel.MarketGroupMarkets = MarketGroupSetupViewModel.MarketGroupMarkets.OrderBy(Function(Entity) Entity.Order).ToList

                    End If

                End Using

            Else

                MarketGroupSetupViewModel.MarketGroupMarkets = New Generic.List(Of DTO.Maintenance.Media.MarketGroup.MarketGroupMarket)

            End If

            MarketGroupSetupViewModel.UpdateEnabled = (MarketGroupSetupViewModel.SelectedMarketGroup IsNot Nothing)
            MarketGroupSetupViewModel.DeleteEnabled = (MarketGroupSetupViewModel.SelectedMarketGroup IsNot Nothing)

            MarketGroupSetupViewModel.AddMarketsEnabled = (MarketGroupSetupViewModel.SelectedMarketGroup IsNot Nothing)

        End Sub
        Public Sub MarketGroupMarketSelectionChanged(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel,
                                                     SelectedMarketGroupMarkets As Generic.List(Of DTO.Maintenance.Media.MarketGroup.MarketGroupMarket))

            MarketGroupSetupViewModel.SelectedMarketGroupMarkets = SelectedMarketGroupMarkets

            MarketGroupSetupViewModel.DeleteMarketsEnabled = (MarketGroupSetupViewModel.SelectedMarketGroupMarkets IsNot Nothing AndAlso MarketGroupSetupViewModel.SelectedMarketGroupMarkets.Count > 0)
            MarketGroupSetupViewModel.MoveUpMarketEnabled = (MarketGroupSetupViewModel.SelectedMarketGroupMarkets IsNot Nothing AndAlso MarketGroupSetupViewModel.SelectedMarketGroupMarkets.Count = 1)
            MarketGroupSetupViewModel.MoveDownMarketEnabled = (MarketGroupSetupViewModel.SelectedMarketGroupMarkets IsNot Nothing AndAlso MarketGroupSetupViewModel.SelectedMarketGroupMarkets.Count = 1)

        End Sub
        Public Function DeleteMarkets(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel,
                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroupMarket As AdvantageFramework.Database.Entities.MarketGroupMarket = Nothing

            If MarketGroupSetupViewModel.SelectedMarketGroupMarkets IsNot Nothing AndAlso
                    MarketGroupSetupViewModel.SelectedMarketGroupMarkets.Count > 0 Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        DbTransaction = DbContext.Database.BeginTransaction

                        For Each MGM In MarketGroupSetupViewModel.SelectedMarketGroupMarkets.ToList

                            MarketGroupMarket = DbContext.MarketGroupMarkets.Find(MGM.ID)

                            DbContext.MarketGroupMarkets.Remove(MarketGroupMarket)

                        Next

                        DbContext.Configuration.AutoDetectChangesEnabled = True
                        DbContext.SaveChanges()

                        DbTransaction.Commit()

                        Deleted = True

                    Catch ex As Exception
                        DbTransaction.Rollback()
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += System.Environment.NewLine & ex.Message
                        Deleted = False
                    End Try

                End Using

                If Deleted Then

                    For Each MGM In MarketGroupSetupViewModel.SelectedMarketGroupMarkets.ToList

                        MarketGroupSetupViewModel.MarketGroupMarkets.Remove(MGM)
                        MarketGroupSetupViewModel.SelectedMarketGroupMarkets.Remove(MGM)

                    Next

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        For Each MGM In MarketGroupSetupViewModel.MarketGroupMarkets.ToList

                            MGM.Order = MarketGroupSetupViewModel.MarketGroupMarkets.IndexOf(MGM)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[MARKET_GROUP_MARKET] SET [ORDER] = {0} WHERE MARKET_GROUP_MARKET_ID = {1}", MGM.Order, MGM.ID))

                        Next

                    End Using

                End If

            End If

            DeleteMarkets = Deleted

        End Function
        Public Function MoveUpMarkets(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel,
                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Moved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroupMarket As AdvantageFramework.Database.Entities.MarketGroupMarket = Nothing
            Dim SelectedMarketGroupMarket As AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket = Nothing
            Dim Index As Integer = 0

            If MarketGroupSetupViewModel.SelectedMarketGroupMarkets IsNot Nothing AndAlso
                    MarketGroupSetupViewModel.SelectedMarketGroupMarkets.Count = 1 Then

                SelectedMarketGroupMarket = MarketGroupSetupViewModel.SelectedMarketGroupMarkets(0)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        DbTransaction = DbContext.Database.BeginTransaction

                        If MarketGroupSetupViewModel.MarketGroupMarkets.Contains(SelectedMarketGroupMarket) Then

                            Index = MarketGroupSetupViewModel.MarketGroupMarkets.IndexOf(SelectedMarketGroupMarket)

                            MarketGroupSetupViewModel.MarketGroupMarkets.Remove(SelectedMarketGroupMarket)

                            If Index > 0 Then

                                MarketGroupSetupViewModel.MarketGroupMarkets.Insert(Index - 1, SelectedMarketGroupMarket)

                            Else

                                MarketGroupSetupViewModel.MarketGroupMarkets.Insert(0, SelectedMarketGroupMarket)

                            End If

                        End If

                        For Each MGM In MarketGroupSetupViewModel.MarketGroupMarkets.ToList

                            MGM.Order = MarketGroupSetupViewModel.MarketGroupMarkets.IndexOf(MGM)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[MARKET_GROUP_MARKET] SET [ORDER] = {0} WHERE MARKET_GROUP_MARKET_ID = {1}", MGM.Order, MGM.ID))

                        Next

                        DbContext.Configuration.AutoDetectChangesEnabled = True
                        DbContext.SaveChanges()

                        DbTransaction.Commit()

                        Moved = True

                    Catch ex As Exception
                        DbTransaction.Rollback()
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += System.Environment.NewLine & ex.Message
                        Moved = False
                    End Try

                End Using

            End If

            MoveUpMarkets = Moved

        End Function
        Public Function MoveDownMarkets(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel,
                                        ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Moved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroupMarket As AdvantageFramework.Database.Entities.MarketGroupMarket = Nothing
            Dim SelectedMarketGroupMarket As AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket = Nothing
            Dim Index As Integer = 0

            If MarketGroupSetupViewModel.SelectedMarketGroupMarkets IsNot Nothing AndAlso
                    MarketGroupSetupViewModel.SelectedMarketGroupMarkets.Count = 1 Then

                SelectedMarketGroupMarket = MarketGroupSetupViewModel.SelectedMarketGroupMarkets(0)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        DbTransaction = DbContext.Database.BeginTransaction

                        If MarketGroupSetupViewModel.MarketGroupMarkets.Contains(SelectedMarketGroupMarket) Then

                            Index = MarketGroupSetupViewModel.MarketGroupMarkets.IndexOf(SelectedMarketGroupMarket)

                            MarketGroupSetupViewModel.MarketGroupMarkets.Remove(SelectedMarketGroupMarket)

                            If Index < MarketGroupSetupViewModel.MarketGroupMarkets.Count - 1 Then

                                MarketGroupSetupViewModel.MarketGroupMarkets.Insert(Index + 1, SelectedMarketGroupMarket)

                            Else

                                MarketGroupSetupViewModel.MarketGroupMarkets.Insert(MarketGroupSetupViewModel.MarketGroupMarkets.Count, SelectedMarketGroupMarket)

                            End If

                        End If

                        For Each MGM In MarketGroupSetupViewModel.MarketGroupMarkets.ToList

                            MGM.Order = MarketGroupSetupViewModel.MarketGroupMarkets.IndexOf(MGM)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[MARKET_GROUP_MARKET] SET [ORDER] = {0} WHERE MARKET_GROUP_MARKET_ID = {1}", MGM.Order, MGM.ID))

                        Next

                        DbContext.Configuration.AutoDetectChangesEnabled = True
                        DbContext.SaveChanges()

                        DbTransaction.Commit()

                        Moved = True

                    Catch ex As Exception
                        DbTransaction.Rollback()
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += System.Environment.NewLine & ex.Message
                        Moved = False
                    End Try

                End Using

            End If

            MoveDownMarkets = Moved

        End Function
        'Public Sub UserEntryChanged(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel)

        '    MarketGroupSetupViewModel.SaveEnabled = True
        '    MarketGroupSetupViewModel.CancelEnabled = True

        'End Sub
        'Public Sub ClearChanged(ByRef MarketGroupSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel)

        '    MarketGroupSetupViewModel.SaveEnabled = False
        '    MarketGroupSetupViewModel.CancelEnabled = False

        'End Sub

#End Region

#End Region

    End Class

End Namespace
