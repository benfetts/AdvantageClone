Namespace Database.Procedures.Location

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.Location)

            Load = From Location In DataContext.Locations
                   Select Location

        End Function
        Public Function LoadByLocationID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LocationID As String) As AdvantageFramework.Database.Entities.Location

            Try

                LoadByLocationID = (From Location In DataContext.Locations
                                    Where Location.ID = LocationID
                                    Select Location).SingleOrDefault

            Catch ex As Exception

                LoadByLocationID = Nothing

            End Try

        End Function

        Public Function LoadLogoPagePropertiesByLocationID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LocationID As String) As AdvantageFramework.Database.Entities.Location

            Try

                LoadLogoPagePropertiesByLocationID = (From Location In DataContext.Locations
                                                      Where Location.ID = LocationID
                                                      Select Location).SingleOrDefault

            Catch ex As Exception

                LoadLogoPagePropertiesByLocationID = Nothing

            End Try

        End Function

        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Location As AdvantageFramework.Database.Entities.Location) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Location.DataContext = DataContext

                Location.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.Locations.InsertOnSubmit(Location)

                ErrorText = Location.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception

                Inserted = False

            Finally

                Insert = Inserted

            End Try

        End Function

        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Location As AdvantageFramework.Database.Entities.Location) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Location.DataContext = DataContext

                Location.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = Location.ValidateEntity(IsValid)

                If IsValid Then

                    Location.DataContext.SubmitChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception

                Updated = False

            Finally

                Update = Updated

            End Try

            Return Update

        End Function
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Location As AdvantageFramework.Database.Entities.Location) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.Locations.DeleteOnSubmit(Location)

                    DataContext.SubmitChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception

                Deleted = False

            Finally

                Delete = Deleted

            End Try

        End Function

#End Region

    End Module

End Namespace