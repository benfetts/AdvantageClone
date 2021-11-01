Namespace Database.Procedures.EmployeeTimeStagingIDs

    <HideModuleName()>
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

        Public Function Load(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext) As IQueryable(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs)

            Load = From EmployeeTimeStagingIDs In DataContext.EmployeeTimeStagingsIDs
                   Select EmployeeTimeStagingIDs

        End Function
        Public Function LoadByGoogleID(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal GoogleID As String) As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByGoogleID = (From EmployeeTimeStagingIDs In DataContext.EmployeeTimeStagingsIDs
                                  Where EmployeeTimeStagingIDs.GoogleID = GoogleID
                                  Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByGoogleID = Nothing
            End Try

        End Function
        Public Function LoadByCalendarID(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal CalendarID As String) As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByCalendarID = (From EmployeeTimeStagingIDs In DataContext.EmployeeTimeStagingsIDs
                                    Where EmployeeTimeStagingIDs.CalendarID = CalendarID
                                    Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByCalendarID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeStagingID(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeTimeStagingID As Long) As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByEmployeeTimeStagingID = (From EmployeeTimeStagingIDs In DataContext.EmployeeTimeStagingsIDs
                                               Where EmployeeTimeStagingIDs.ID = EmployeeTimeStagingID
                                               Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeStagingID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeTimeStaging As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DataContext.EmployeeTimeStagingsIDs.InsertOnSubmit(EmployeeTimeStaging)

                DataContext.SubmitChanges()

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeTimeStaging As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DataContext.SubmitChanges()

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeTimeStaging As AdvantageFramework.GoogleServices.Database.Entities.EmployeeTimeStagingIDs) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DataContext.EmployeeTimeStagingsIDs.DeleteOnSubmit(EmployeeTimeStaging)

                DataContext.SubmitChanges()

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
