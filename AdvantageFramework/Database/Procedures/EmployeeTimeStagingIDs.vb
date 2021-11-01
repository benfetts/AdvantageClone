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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeStagingID As Integer) As Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByID = (From EmployeeTimeStagingIDs In DbContext.GetQuery(Of Database.Entities.EmployeeTimeStagingIDs)
                            Where EmployeeTimeStagingIDs.ID = EmployeeTimeStagingID
                            Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByOutlookID(ByVal DbContext As Database.DbContext, ByVal OutlookID As String) As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByOutlookID = (From EmployeeTimeStagingIDs In DbContext.EmployeeTimeStagingsIDs
                                   Where EmployeeTimeStagingIDs.OutlookID = OutlookID
                                   Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByOutlookID = Nothing
            End Try

        End Function
        Public Function LoadByGoogleID(ByVal DbContext As Database.DbContext, ByVal GoogleID As String) As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByGoogleID = (From EmployeeTimeStagingIDs In DbContext.EmployeeTimeStagingsIDs
                                  Where EmployeeTimeStagingIDs.GoogleID = GoogleID
                                  Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByGoogleID = Nothing
            End Try

        End Function
        Public Function LoadByCalendarID(ByVal DbContext As Database.DbContext, ByVal CalendarID As String) As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByCalendarID = (From EmployeeTimeStagingIDs In DbContext.EmployeeTimeStagingsIDs
                                    Where EmployeeTimeStagingIDs.CalendarID = CalendarID
                                    Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByCalendarID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeStagingID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeStagingID As Long) As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs

            Try

                LoadByEmployeeTimeStagingID = (From EmployeeTimeStagingIDs In DbContext.EmployeeTimeStagingsIDs
                                               Where EmployeeTimeStagingIDs.ID = EmployeeTimeStagingID
                                               Select EmployeeTimeStagingIDs).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeStagingID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeStagingIDs)

            Load = From EmployeeTimeStagingIDs In DbContext.GetQuery(Of Database.Entities.EmployeeTimeStagingIDs)
                   Select EmployeeTimeStagingIDs


        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeStagingIDs As Database.Entities.EmployeeTimeStagingIDs) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeStagingsIDs.Add(EmployeeTimeStagingIDs)

                ErrorText = EmployeeTimeStagingIDs.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeStaging)

                ErrorText = EmployeeTimeStaging.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeStaging)

                    DbContext.SaveChanges()

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
