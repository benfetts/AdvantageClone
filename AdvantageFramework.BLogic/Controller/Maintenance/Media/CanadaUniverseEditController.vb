Namespace Controller.Maintenance.Media

    Public Class CanadaUniverseEditController
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
        Public Function Load(CanadaUniverseID As Integer) As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseEditViewModel

            'objects
            Dim CanadaUniverseEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseEditViewModel = Nothing
            Dim CanadaUniverse As AdvantageFramework.Database.Entities.CanadaUniverse = Nothing

            CanadaUniverseEditViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseEditViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                CanadaUniverseEditViewModel.CanadaUniverseID = CanadaUniverseID

                CanadaUniverseEditViewModel.Markets = DbContext.Markets.Where(Function(Entity) Entity.CountryID = AdvantageFramework.DTO.Countries.Canada).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Market(Entity)).ToList

                CanadaUniverseEditViewModel.Markets = CanadaUniverseEditViewModel.Markets.Where(Function(Entity) Entity.IsInactive = False).ToList
                CanadaUniverseEditViewModel.Markets = CanadaUniverseEditViewModel.Markets.OrderBy(Function(Entity) Entity.Description).ToList

                If CanadaUniverseID > 0 Then

                    CanadaUniverse = DbContext.CanadaUniverses.Find(CanadaUniverseID)

                End If

                If CanadaUniverse IsNot Nothing Then

                    DbContext.Entry(CanadaUniverse).Reference("Market").Load()

                    CanadaUniverseEditViewModel.CanadaUniverse = New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse(CanadaUniverse)

                    CanadaUniverseEditViewModel.AddEnabled = False
                    CanadaUniverseEditViewModel.UpdateEnabled = True
                    CanadaUniverseEditViewModel.CancelEnabled = True

                Else

                    CanadaUniverseEditViewModel.CanadaUniverse = New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse()

                    CanadaUniverseEditViewModel.AddEnabled = True
                    CanadaUniverseEditViewModel.UpdateEnabled = False
                    CanadaUniverseEditViewModel.CancelEnabled = True

                    If CanadaUniverseEditViewModel.Markets IsNot Nothing AndAlso CanadaUniverseEditViewModel.Markets.Count > 0 Then

                        CanadaUniverseEditViewModel.CanadaUniverse.MarketCode = CanadaUniverseEditViewModel.Markets(0).Code

                    End If

                End If

            End Using

            Load = CanadaUniverseEditViewModel

        End Function
        Public Function Add(ByRef CanadaUniverseEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseEditViewModel,
                            ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim CanadaUniverseEntity As AdvantageFramework.Database.Entities.CanadaUniverse = Nothing
            Dim CanadaUniverse As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse = Nothing
            Dim Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Market) = Nothing
            Dim Year As Integer = 0

            If CanadaUniverseEditViewModel.AddAllMarkets Then

                Year = CanadaUniverseEditViewModel.CanadaUniverse.Year

                Markets = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Market)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    For Each Market In CanadaUniverseEditViewModel.Markets

                        If DbContext.CanadaUniverses.Any(Function(Entity) Entity.Year = Year AndAlso Entity.MarketCode = Market.Code) = False Then

                            Markets.Add(Market)

                        End If

                    Next

                End Using

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        For Each Market In Markets

                            CanadaUniverseEntity = New AdvantageFramework.Database.Entities.CanadaUniverse

                            CanadaUniverseEditViewModel.CanadaUniverse.SaveToEntity(CanadaUniverseEntity)

                            CanadaUniverseEntity.MarketCode = Market.Code

                            DbContext.CanadaUniverses.Add(CanadaUniverseEntity)

                        Next

                        Added = True

                    Catch ex As Exception
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        ErrorMessage += System.Environment.NewLine & ex.Message
                        Added = False
                    End Try

                    If Added Then

                        DbContext.Configuration.AutoDetectChangesEnabled = True
                        DbContext.SaveChanges()

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                End Using

            Else

                If IsDuplicate(CanadaUniverseEditViewModel.CanadaUniverse) = False Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()
                        DbContext.Configuration.AutoDetectChangesEnabled = False

                        Try

                            DbTransaction = DbContext.Database.BeginTransaction

                            CanadaUniverseEntity = New AdvantageFramework.Database.Entities.CanadaUniverse

                            CanadaUniverseEditViewModel.CanadaUniverse.SaveToEntity(CanadaUniverseEntity)

                            DbContext.CanadaUniverses.Add(CanadaUniverseEntity)

                            DbContext.Configuration.AutoDetectChangesEnabled = True
                            DbContext.SaveChanges()

                            DbTransaction.Commit()

                            Added = True

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += System.Environment.NewLine & ex.Message
                            Added = False
                        End Try

                        If Added Then

                            CanadaUniverseEditViewModel.CanadaUniverse.ID = CanadaUniverseEntity.ID
                            CanadaUniverseEditViewModel.CanadaUniverseID = CanadaUniverseEntity.ID

                        End If

                    End Using

                Else

                    ErrorMessage = "There is already a universe entered for that year and market."

                End If

            End If

            Add = Added

        End Function
        Public Function Update(ByRef CanadaUniverseEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseEditViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Updated As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim CanadaUniverse As AdvantageFramework.Database.Entities.CanadaUniverse = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    CanadaUniverse = DbContext.CanadaUniverses.Find(CanadaUniverseEditViewModel.CanadaUniverse.ID)

                    CanadaUniverseEditViewModel.CanadaUniverse.SaveToEntity(CanadaUniverse)

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
        Public Function IsDuplicate(CanadaUniverse As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse) As Boolean

            'objects
            Dim CanadaUniverseIsDuplicate As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                If DbContext.CanadaUniverses.Any(Function(Entity) Entity.Year = CanadaUniverse.Year AndAlso Entity.MarketCode = CanadaUniverse.MarketCode) Then

                    CanadaUniverseIsDuplicate = True

                End If

            End Using

            IsDuplicate = CanadaUniverseIsDuplicate

        End Function

#End Region

#End Region

    End Class

End Namespace
