Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailAlternateEmployee

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

        Public Function LoadByEmployeeTitleID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTitleID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee

            Try

                LoadByEmployeeTitleID = (From EmployeeTimeForecastOfficeDetailAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
                                         Where EmployeeTimeForecastOfficeDetailAlternateEmployee.EmployeeTitleID = EmployeeTitleID
                                         Select EmployeeTimeForecastOfficeDetailAlternateEmployee).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTitleID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee

            Try

                LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeID = (From EmployeeTimeForecastOfficeDetailAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
                                                                             Where EmployeeTimeForecastOfficeDetailAlternateEmployee.ID = EmployeeTimeForecastOfficeDetailAlternateEmployeeID
                                                                             Select EmployeeTimeForecastOfficeDetailAlternateEmployee).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployeeDescription As String) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee

            Try

                LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeDescription = (From EmployeeTimeForecastOfficeDetailAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
                                                                                      Where EmployeeTimeForecastOfficeDetailAlternateEmployee.Description = EmployeeTimeForecastOfficeDetailAlternateEmployeeDescription
                                                                                      Select EmployeeTimeForecastOfficeDetailAlternateEmployee).FirstOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastOfficeDetailAlternateEmployeeDescription = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
                                                       Where EmployeeTimeForecastOfficeDetailAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailAlternateEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)

            Load = From EmployeeTimeForecastOfficeDetailAlternateEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
                   Select EmployeeTimeForecastOfficeDetailAlternateEmployee

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, _
                               ByVal EmployeeTimeForecastOfficeDetailID As Integer, ByVal EmployeeTitleID As Integer, _
                               ByVal Description As String, ByVal OfficeCode As String, ByVal BillRate As Decimal, ByVal CostRate As Decimal, _
                               ByRef EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailAlternateEmployee = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee

                EmployeeTimeForecastOfficeDetailAlternateEmployee.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailAlternateEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailAlternateEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailAlternateEmployee.EmployeeTitleID = EmployeeTitleID
                EmployeeTimeForecastOfficeDetailAlternateEmployee.Description = Description
                EmployeeTimeForecastOfficeDetailAlternateEmployee.OfficeCode = OfficeCode
                EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate = BillRate
                EmployeeTimeForecastOfficeDetailAlternateEmployee.CostRate = CostRate

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailAlternateEmployee)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailAlternateEmployees.Add(EmployeeTimeForecastOfficeDetailAlternateEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailAlternateEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailAlternateEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailAlternateEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailAlternateEmployee)

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
        Public Function DeleteByEmployeeTimeForecastOfficeDetailAlternateEmployeeID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailAlternateEmployeeID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLAE WHERE ETF_OFFDTLAE_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailAlternateEmployeeID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByEmployeeTimeForecastOfficeDetailAlternateEmployeeID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
