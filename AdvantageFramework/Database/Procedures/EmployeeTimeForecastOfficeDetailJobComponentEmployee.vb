Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponentEmployee

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

        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailJobComponentEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)
                                                       Where EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailJobComponentEmployee

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailJobComponentID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)

            LoadByEmployeeTimeForecastOfficeDetailJobComponentID = From EmployeeTimeForecastOfficeDetailJobComponentEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)
                                                                   Where EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponentID
                                                                   Select EmployeeTimeForecastOfficeDetailJobComponentEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)

            Load = From EmployeeTimeForecastOfficeDetailJobComponentEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)
                   Select EmployeeTimeForecastOfficeDetailJobComponentEmployee

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer, _
                               ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer, ByVal EmployeeTimeForecastOfficeDetailEmployeeID As Integer, ByVal Hours As Decimal, _
                               ByRef EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailJobComponentEmployee = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee

                EmployeeTimeForecastOfficeDetailJobComponentEmployee.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponentID
                EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployeeID
                EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours = Hours

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailJobComponentEmployee)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailJobComponentEmployees.Add(EmployeeTimeForecastOfficeDetailJobComponentEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailJobComponentEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailJobComponentEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailJobComponentEmployee)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLJC_EMP WHERE ETF_OFFDTLJC_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailJobComponentID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteFromEmployeeTimeForecastByJobComponent = Deleted
            End Try

        End Function
        Public Function DeleteFromEmployeeTimeForecastByEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailEmployeeID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLJC_EMP WHERE ETF_OFFDTLEMP_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailEmployeeID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteFromEmployeeTimeForecastByEmployee = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
