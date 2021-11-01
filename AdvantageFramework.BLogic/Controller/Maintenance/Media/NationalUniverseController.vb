Namespace Controller.Maintenance.Media

    Public Class NationalUniverseController
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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel

            Dim NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel = Nothing

            NationalUniverseSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                RefreshNationalUniverses(DbContext, NationalUniverseSetupViewModel)

                NationalUniverseSetupViewModel.AddEnabled = True
                NationalUniverseSetupViewModel.SaveEnabled = False
                NationalUniverseSetupViewModel.CancelEnabled = False
                NationalUniverseSetupViewModel.DeleteEnabled = False

            End Using

            Load = NationalUniverseSetupViewModel

        End Function
        Public Function Save(ByRef NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel,
                             ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    NationalUniverse = DbContext.NationalUniverses.Find(NationalUniverseSetupViewModel.SelectedNationalUniverse.ID)

                    For Each CUD In NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.ToList

                        CUD.SaveToEntity(NationalUniverseSetupViewModel.SelectedNationalUniverse)

                    Next

                    NationalUniverseSetupViewModel.SelectedNationalUniverse.SaveToEntity(NationalUniverse)

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
        Public Function Delete(ByRef NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    NationalUniverse = DbContext.NationalUniverses.Find(NationalUniverseSetupViewModel.SelectedNationalUniverse.ID)

                    DbContext.NationalUniverses.Remove(NationalUniverse)

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
        Private Sub RefreshNationalUniverses(DbContext As AdvantageFramework.Database.DbContext, ByRef NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel)

            NationalUniverseSetupViewModel.NationalUniverses = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse)

            NationalUniverseSetupViewModel.NationalUniverses.AddRange(From Entity In DbContext.NationalUniverses.Include("MarketBreak").ToList
                                                                      Select New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse(Entity))

        End Sub
        Public Sub RefreshNationalUniverses(ByRef NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                RefreshNationalUniverses(DbContext, NationalUniverseSetupViewModel)

            End Using

        End Sub
        Public Sub NationalUniverseSelectionChanged(ByRef NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel,
                                                    SelectedNationalUniverse As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse)

            NationalUniverseSetupViewModel.SelectedNationalUniverse = SelectedNationalUniverse

            NationalUniverseSetupViewModel.SelectedNationalUniverseDetails = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail)

            If SelectedNationalUniverse IsNot Nothing Then

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Household, SelectedNationalUniverse.Household))

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females2to5, SelectedNationalUniverse.Females2to5))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females6to8, SelectedNationalUniverse.Females6to8))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females9to11, SelectedNationalUniverse.Females9to11))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females12to14, SelectedNationalUniverse.Females12to14))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females15to17, SelectedNationalUniverse.Females15to17))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females18to20, SelectedNationalUniverse.Females18to20))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females21to24, SelectedNationalUniverse.Females21to24))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females25to29, SelectedNationalUniverse.Females25to29))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females30to34, SelectedNationalUniverse.Females30to34))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females35to39, SelectedNationalUniverse.Females35to39))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females40to44, SelectedNationalUniverse.Females40to44))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females45to49, SelectedNationalUniverse.Females45to49))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females50to54, SelectedNationalUniverse.Females50to54))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females55to64, SelectedNationalUniverse.Females55to64))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females65Plus, SelectedNationalUniverse.Females65Plus))

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males2to5, SelectedNationalUniverse.Males2to5))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males6to8, SelectedNationalUniverse.Males6to8))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males9to11, SelectedNationalUniverse.Males9to11))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males12to14, SelectedNationalUniverse.Males12to14))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males15to17, SelectedNationalUniverse.Males15to17))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males18to20, SelectedNationalUniverse.Males18to20))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males21to24, SelectedNationalUniverse.Males21to24))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males25to29, SelectedNationalUniverse.Males25to29))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males30to34, SelectedNationalUniverse.Males30to34))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males35to39, SelectedNationalUniverse.Males35to39))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males40to44, SelectedNationalUniverse.Males40to44))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males45to49, SelectedNationalUniverse.Males45to49))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males50to54, SelectedNationalUniverse.Males50to54))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males55to64, SelectedNationalUniverse.Males55to64))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males65Plus, SelectedNationalUniverse.Males65Plus))

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen18to20, SelectedNationalUniverse.WorkingWomen18to20))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen21to24, SelectedNationalUniverse.WorkingWomen21to24))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen25to34, SelectedNationalUniverse.WorkingWomen25to34))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen35to44, SelectedNationalUniverse.WorkingWomen35to44))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen45to49, SelectedNationalUniverse.WorkingWomen45to49))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen50to54, SelectedNationalUniverse.WorkingWomen50to54))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(SelectedNationalUniverse, AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen55Plus, SelectedNationalUniverse.WorkingWomen55Plus))

            Else

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Household))

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females2to5))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females6to8))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females9to11))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females12to14))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females15to17))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females18to20))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females21to24))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females25to29))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females30to34))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females35to39))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females40to44))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females45to49))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females50to54))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females55to64))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females65Plus))

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males2to5))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males6to8))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males9to11))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males12to14))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males15to17))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males18to20))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males21to24))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males25to29))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males30to34))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males35to39))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males40to44))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males45to49))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males50to54))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males55to64))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males65Plus))

                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen18to20))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen21to24))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen25to34))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen35to44))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen45to49))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen50to54))
                NationalUniverseSetupViewModel.SelectedNationalUniverseDetails.Add(New AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail(AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen55Plus))

            End If

            NationalUniverseSetupViewModel.DeleteEnabled = (NationalUniverseSetupViewModel.SelectedNationalUniverse IsNot Nothing)

        End Sub
        Public Sub UserEntryChanged(ByRef NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel)

            NationalUniverseSetupViewModel.SaveEnabled = True
            NationalUniverseSetupViewModel.CancelEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef NationalUniverseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.NationalUniverseSetupViewModel)

            NationalUniverseSetupViewModel.SaveEnabled = False
            NationalUniverseSetupViewModel.CancelEnabled = False

        End Sub

#End Region

#End Region

    End Class

End Namespace
