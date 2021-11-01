Namespace Controller.Maintenance.Media

    Public Class NationalUniverseEditController
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
        Public Function Load(NationalUniverseID As Integer) As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseEditViewModel

            'objects
            Dim NationalUniverseEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseEditViewModel = Nothing
            Dim NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse = Nothing

            NationalUniverseEditViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseEditViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                NationalUniverseEditViewModel.NationalUniverseID = NationalUniverseID

                NationalUniverseEditViewModel.MarketBreaks = DbContext.MarketBreaks.ToList

                If NationalUniverseID > 0 Then

                    NationalUniverse = DbContext.NationalUniverses.Find(NationalUniverseID)

                End If

                If NationalUniverse IsNot Nothing Then

                    DbContext.Entry(NationalUniverse).Reference("Market").Load()

                    NationalUniverseEditViewModel.NationalUniverse = New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse(NationalUniverse)

                    NationalUniverseEditViewModel.AddEnabled = False
                    NationalUniverseEditViewModel.UpdateEnabled = True
                    NationalUniverseEditViewModel.CancelEnabled = True

                Else

                    NationalUniverseEditViewModel.NationalUniverse = New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse()

                    NationalUniverseEditViewModel.AddEnabled = True
                    NationalUniverseEditViewModel.UpdateEnabled = False
                    NationalUniverseEditViewModel.CancelEnabled = True

                    If NationalUniverseEditViewModel.MarketBreaks IsNot Nothing AndAlso NationalUniverseEditViewModel.MarketBreaks.Count > 0 Then

                        NationalUniverseEditViewModel.NationalUniverse.MarketBreakID = NationalUniverseEditViewModel.MarketBreaks(0).ID

                    End If

                End If

            End Using

            Load = NationalUniverseEditViewModel

        End Function
        Public Function Add(ByRef NationalUniverseEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseEditViewModel,
                            ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse = Nothing

            If IsDuplicate(NationalUniverseEditViewModel.NationalUniverse) = False Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        DbTransaction = DbContext.Database.BeginTransaction

                        NationalUniverse = New AdvantageFramework.Database.Entities.NationalUniverse

                        NationalUniverseEditViewModel.NationalUniverse.SaveToEntity(NationalUniverse)

                        DbContext.NationalUniverses.Add(NationalUniverse)

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

                        NationalUniverseEditViewModel.NationalUniverse.ID = NationalUniverse.ID
                        NationalUniverseEditViewModel.NationalUniverseID = NationalUniverse.ID

                    End If

                End Using

            Else

                ErrorMessage = "There is already a universe entered for that year, market break."

            End If

            Add = Added

        End Function
        Public Function Update(ByRef NationalUniverseEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseEditViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Updated As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    NationalUniverse = DbContext.NationalUniverses.Find(NationalUniverseEditViewModel.NationalUniverse.ID)

                    NationalUniverseEditViewModel.NationalUniverse.SaveToEntity(NationalUniverse)

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
        Public Function IsDuplicate(NationalUniverse As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse) As Boolean

            'objects
            Dim NationalUniverseIsDuplicate As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                If DbContext.NationalUniverses.Any(Function(Entity) Entity.Year = NationalUniverse.Year AndAlso Entity.MarketBreakID = NationalUniverse.MarketBreakID AndAlso Entity.IsHispanic = NationalUniverse.IsHispanic) Then

                    NationalUniverseIsDuplicate = True

                End If

            End Using

            IsDuplicate = NationalUniverseIsDuplicate

        End Function

#End Region

#End Region

    End Class

End Namespace
