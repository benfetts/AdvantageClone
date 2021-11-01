Namespace Controller.Maintenance.Media

    Public Class MarketGroupEditController
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
        Public Function Load(MarketGroupID As Integer) As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupEditViewModel

            'objects
            Dim MarketGroupEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupEditViewModel = Nothing
            Dim MarketGroup As AdvantageFramework.Database.Entities.MarketGroup = Nothing

            MarketGroupEditViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupEditViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                MarketGroupEditViewModel.MarketGroupID = MarketGroupID

                If MarketGroupID > 0 Then

                    MarketGroup = DbContext.MarketGroups.Find(MarketGroupID)

                End If

                If MarketGroup IsNot Nothing Then

                    DbContext.Entry(MarketGroup).Reference("Country").Load()

                    MarketGroupEditViewModel.MarketGroup = New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup(MarketGroup)

                    MarketGroupEditViewModel.AddEnabled = False
                    MarketGroupEditViewModel.UpdateEnabled = True
                    MarketGroupEditViewModel.CancelEnabled = True

                Else

                    MarketGroupEditViewModel.MarketGroup = New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup()

                    MarketGroupEditViewModel.AddEnabled = True
                    MarketGroupEditViewModel.UpdateEnabled = False
                    MarketGroupEditViewModel.CancelEnabled = True

                End If

                MarketGroupEditViewModel.Countries = DbContext.Countries.ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Country(Entity)).ToList

                MarketGroupEditViewModel.MediaTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

                MarketGroupEditViewModel.MediaTypes.Add(New DTO.ComboBoxItem("TV", "T"))
                MarketGroupEditViewModel.MediaTypes.Add(New DTO.ComboBoxItem("Radio", "R"))

            End Using

            Load = MarketGroupEditViewModel

        End Function
        Public Function Add(ByRef MarketGroupEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupEditViewModel,
                            ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroup As AdvantageFramework.Database.Entities.MarketGroup = Nothing
            Dim MediaType As String = String.Empty
            Dim Name As String = String.Empty
            Dim CountryID As Integer = 0
            Dim HasUniqueName As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try


                    MediaType = MarketGroupEditViewModel.MarketGroup.MediaType
                    CountryID = MarketGroupEditViewModel.MarketGroup.CountryID
                    Name = MarketGroupEditViewModel.MarketGroup.Name

                    If DbContext.MarketGroups.Any(Function(Entity) Entity.MediaType = MediaType AndAlso Entity.CountryID = CountryID AndAlso Entity.Name.ToUpper = Name.ToUpper) = False Then

                        HasUniqueName = True

                    Else

                        HasUniqueName = False
                        ErrorMessage = "Please enter a unique name."

                    End If

                Catch ex As Exception
                    HasUniqueName = False
                End Try

                If HasUniqueName Then

                    Try

                        DbTransaction = DbContext.Database.BeginTransaction

                        MarketGroup = New AdvantageFramework.Database.Entities.MarketGroup

                        MarketGroupEditViewModel.MarketGroup.SaveToEntity(MarketGroup)

                        DbContext.MarketGroups.Add(MarketGroup)

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

                End If

                If Added Then

                    MarketGroupEditViewModel.MarketGroup.ID = MarketGroup.ID
                    MarketGroupEditViewModel.MarketGroupID = MarketGroup.ID

                End If

            End Using

            Add = Added

        End Function
        Public Function Update(ByRef MarketGroupEditViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupEditViewModel,
                               ByRef ErrorMessage As String) As Boolean

            Dim Updated As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MarketGroup As AdvantageFramework.Database.Entities.MarketGroup = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    MarketGroup = DbContext.MarketGroups.Find(MarketGroupEditViewModel.MarketGroup.ID)

                    MarketGroupEditViewModel.MarketGroup.SaveToEntity(MarketGroup)

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

#End Region

#End Region

    End Class

End Namespace
