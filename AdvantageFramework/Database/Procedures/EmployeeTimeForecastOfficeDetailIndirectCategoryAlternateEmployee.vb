Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee

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

        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
                                                       Where EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

            LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID = From EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
                                                                       Where EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategoryID
                                                                       Select EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee

        End Function
        Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

            Load = From EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
                   Select EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer, _
                               ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer, ByVal Hours As Decimal, _
                               ByRef EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee

                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategoryID
                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployeeID
                EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours = Hours

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees.Add(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

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
        Public Function DeleteFromEmployeeTimeForecastByIndirectCategory(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLCAT_AE WHERE ETF_OFFDTLCAT_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailIndirectCategoryID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteFromEmployeeTimeForecastByIndirectCategory = Deleted
            End Try

        End Function
        Public Function DeleteFromEmployeeTimeForecastByAlternateEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLCAT_AE WHERE ETF_OFFDTLAE_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
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
