Namespace Controller.Maintenance.Media

    Public Class CanadaUniverseSetupController
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

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel

            Dim CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel = Nothing

            CanadaUniverseSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                RefreshCanadaUniverses(DbContext, CanadaUniverseSetupViewModel)

                CanadaUniverseSetupViewModel.AddEnabled = True
                CanadaUniverseSetupViewModel.SaveEnabled = False
                CanadaUniverseSetupViewModel.CancelEnabled = False
                CanadaUniverseSetupViewModel.DeleteEnabled = False

            End Using

            Load = CanadaUniverseSetupViewModel

        End Function
        Public Function Save(ByRef CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim CanadaUniverse As AdvantageFramework.Database.Entities.CanadaUniverse = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    CanadaUniverse = DbContext.CanadaUniverses.Find(CanadaUniverseSetupViewModel.SelectedCanadaUniverse.ID)

                    For Each CUD In CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.ToList

                        CUD.SaveToEntity(CanadaUniverseSetupViewModel.SelectedCanadaUniverse)

                    Next

                    CanadaUniverseSetupViewModel.SelectedCanadaUniverse.SaveToEntity(CanadaUniverse)

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
        Public Function Delete(ByRef CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim CanadaUniverse As AdvantageFramework.Database.Entities.CanadaUniverse = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    CanadaUniverse = DbContext.CanadaUniverses.Find(CanadaUniverseSetupViewModel.SelectedCanadaUniverse.ID)

                    DbContext.CanadaUniverses.Remove(CanadaUniverse)

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
        Private Sub RefreshCanadaUniverses(DbContext As AdvantageFramework.Database.DbContext, ByRef CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel)

            CanadaUniverseSetupViewModel.CanadaUniverses = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse)

            CanadaUniverseSetupViewModel.CanadaUniverses.AddRange(From Entity In DbContext.CanadaUniverses.Include("Market").ToList
                                                                  Select New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse(Entity))

        End Sub
        Public Sub RefreshCanadaUniverses(ByRef CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                RefreshCanadaUniverses(DbContext, CanadaUniverseSetupViewModel)

            End Using

        End Sub
        Public Sub CanadaUniverseSelectionChanged(ByRef CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel,
                                                  SelectedCanadaUniverse As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse)

            CanadaUniverseSetupViewModel.SelectedCanadaUniverse = SelectedCanadaUniverse

            CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail)

            If SelectedCanadaUniverse IsNot Nothing Then

                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males2Plus, SelectedCanadaUniverse.Males2Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males12Plus, SelectedCanadaUniverse.Males12Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males18Plus, SelectedCanadaUniverse.Males18Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males25Plus, SelectedCanadaUniverse.Males25Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males35Plus, SelectedCanadaUniverse.Males35Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males50Plus, SelectedCanadaUniverse.Males50Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males55Plus, SelectedCanadaUniverse.Males55Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males60Plus, SelectedCanadaUniverse.Males60Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males65Plus, SelectedCanadaUniverse.Males65Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females2Plus, SelectedCanadaUniverse.Females2Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females12Plus, SelectedCanadaUniverse.Females12Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females18Plus, SelectedCanadaUniverse.Females18Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females25Plus, SelectedCanadaUniverse.Females25Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females35Plus, SelectedCanadaUniverse.Females35Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females50Plus, SelectedCanadaUniverse.Females50Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females55Plus, SelectedCanadaUniverse.Females55Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females60Plus, SelectedCanadaUniverse.Females60Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(SelectedCanadaUniverse, AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females65Plus, SelectedCanadaUniverse.Females65Plus))

            Else

                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males2Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males12Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males18Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males25Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males35Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males50Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males55Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males60Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males65Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females2Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females12Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females18Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females25Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females35Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females50Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females55Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females60Plus))
                CanadaUniverseSetupViewModel.SelectedCanadaUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females65Plus))

            End If

            CanadaUniverseSetupViewModel.DeleteEnabled = (CanadaUniverseSetupViewModel.SelectedCanadaUniverse IsNot Nothing)

        End Sub
        Public Sub UserEntryChanged(ByRef CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel)

            CanadaUniverseSetupViewModel.SaveEnabled = True
            CanadaUniverseSetupViewModel.CancelEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef CanadaUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CanadaUniverseSetupViewModel)

            CanadaUniverseSetupViewModel.SaveEnabled = False
            CanadaUniverseSetupViewModel.CancelEnabled = False

        End Sub

#End Region

    End Class

End Namespace
