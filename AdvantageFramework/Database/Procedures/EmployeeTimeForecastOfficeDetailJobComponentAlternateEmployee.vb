Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee

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

        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
                                                       Where EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailJobComponentID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

            LoadByEmployeeTimeForecastOfficeDetailJobComponentID = From EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
                                                                   Where EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponentID
                                                                   Select EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

            Load = From EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
                   Select EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer, _
                               ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer, ByVal Hours As Decimal, _
                               ByRef EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee

                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponentID
                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployeeID
                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours = Hours

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.Add(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

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
        Public Function DeleteFromEmployeeTimeForecastByJobComponent(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLJC_AE WHERE ETF_OFFDTLJC_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailJobComponentID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteFromEmployeeTimeForecastByJobComponent = Deleted
            End Try

        End Function
        Public Function DeleteFromEmployeeTimeForecastByAlternateEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLJC_AE WHERE ETF_OFFDTLAE_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailAlternateEmployeeID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteFromEmployeeTimeForecastByAlternateEmployee = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
