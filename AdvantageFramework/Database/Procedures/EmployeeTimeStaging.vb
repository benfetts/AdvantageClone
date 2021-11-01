Namespace Database.Procedures.EmployeeTimeStaging

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

        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeStaging)

            Try

                LoadByEmployeeCode = From EmployeeTimeStaging In DbContext.GetQuery(Of Database.Entities.EmployeeTimeStaging)
                                     Where EmployeeTimeStaging.EmployeeCode = EmployeeCode
                                     Select EmployeeTimeStaging

            Catch ex As Exception
                LoadByEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeStagingID As Integer) As Database.Entities.EmployeeTimeStaging

            Try

                LoadByID = (From EmployeeTimeStaging In DbContext.GetQuery(Of Database.Entities.EmployeeTimeStaging)
                            Where EmployeeTimeStaging.ID = EmployeeTimeStagingID
                            Select EmployeeTimeStaging).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function

        Public Function LoadByOutLookID(ByVal DbContext As Database.DbContext, ByVal OutlookID As String) As Database.Entities.EmployeeTimeStaging

            Try

                LoadByOutLookID = (From EmployeeTimeStaging In DbContext.GetQuery(Of Database.Entities.EmployeeTimeStaging)
                                   Where EmployeeTimeStaging.OutlookID = OutlookID
                                   Select EmployeeTimeStaging).SingleOrDefault

            Catch ex As Exception
                LoadByOutLookID = Nothing
            End Try

        End Function

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeStaging)

            Load = From EmployeeTimeStaging In DbContext.GetQuery(Of Database.Entities.EmployeeTimeStaging)
                   Select EmployeeTimeStaging


        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeStaging As Database.Entities.EmployeeTimeStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeStagings.Add(EmployeeTimeStaging)

                ErrorText = EmployeeTimeStaging.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging) As Boolean

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging) As Boolean

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
