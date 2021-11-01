Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee

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

        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)
                                                       Where EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

            LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID = From EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)
                                                                       Where EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategoryID
                                                                       Select EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

            Load = From EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)
                   Select EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer, _
                               ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer, ByVal EmployeeTimeForecastOfficeDetailEmployeeID As Integer, ByVal Hours As Decimal, _
                               ByRef EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee

                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategoryID
                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployeeID
                EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours = Hours

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees.Add(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

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

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLCAT_EMP WHERE ETF_OFFDTLCAT_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailIndirectCategoryID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteFromEmployeeTimeForecastByIndirectCategory = Deleted
            End Try

        End Function
        Public Function DeleteFromEmployeeTimeForecastByEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailEmployeeID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLCAT_EMP WHERE ETF_OFFDTLEMP_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
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
