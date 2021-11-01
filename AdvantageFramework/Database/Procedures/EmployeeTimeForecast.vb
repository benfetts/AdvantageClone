Namespace Database.Procedures.EmployeeTimeForecast

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

        Public Function LoadByPostPeriodCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriodCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecast)

            LoadByPostPeriodCode = From EmployeeTimeForecast In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecast)
                                   Where EmployeeTimeForecast.PostPeriodCode = PostPeriodCode
                                   Select EmployeeTimeForecast

        End Function
        Public Function LoadByEmployeeTimeForecastID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecast

            Try

                LoadByEmployeeTimeForecastID = (From EmployeeTimeForecast In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecast)
                                                Where EmployeeTimeForecast.ID = EmployeeTimeForecastID
                                                Select EmployeeTimeForecast).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecast)

            Load = From EmployeeTimeForecast In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecast)
                   Select EmployeeTimeForecast

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Description As String, ByVal PostPeriodCode As String, _
                               ByRef EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecast = New AdvantageFramework.Database.Entities.EmployeeTimeForecast

                EmployeeTimeForecast.DbContext = DbContext
                EmployeeTimeForecast.Description = Description
                EmployeeTimeForecast.PostPeriodCode = PostPeriodCode

                Inserted = Insert(DbContext, EmployeeTimeForecast)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecasts.Add(EmployeeTimeForecast)

                ErrorText = EmployeeTimeForecast.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecast)

                ErrorText = EmployeeTimeForecast.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecast)

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

