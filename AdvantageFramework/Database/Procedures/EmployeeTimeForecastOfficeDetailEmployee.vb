Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailEmployee

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

        Public Function LoadByEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee

            Try

                LoadByEmployeeCode = (From EmployeeTimeForecastOfficeDetailEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
                                      Where EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode = EmployeeCode
                                      Select EmployeeTimeForecastOfficeDetailEmployee).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailEmployeeID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailEmployeeID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee

            Try

                LoadByEmployeeTimeForecastOfficeDetailEmployeeID = (From EmployeeTimeForecastOfficeDetailEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
                                                                    Where EmployeeTimeForecastOfficeDetailEmployee.ID = EmployeeTimeForecastOfficeDetailEmployeeID
                                                                    Select EmployeeTimeForecastOfficeDetailEmployee).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastOfficeDetailEmployeeID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
                                                       Where EmployeeTimeForecastOfficeDetailEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailEmployee

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)

            Load = From EmployeeTimeForecastOfficeDetailEmployee In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
                   Select EmployeeTimeForecastOfficeDetailEmployee

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, _
                               ByVal EmployeeTimeForecastOfficeDetailID As Integer, ByVal EmployeeCode As String, _
                               ByVal BillRate As Decimal, ByVal CostRate As Decimal, _
                               ByRef EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailEmployee = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee

                EmployeeTimeForecastOfficeDetailEmployee.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailEmployee.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailEmployee.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode = EmployeeCode
                EmployeeTimeForecastOfficeDetailEmployee.BillRate = BillRate
                EmployeeTimeForecastOfficeDetailEmployee.CostRate = CostRate

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailEmployee)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailEmployees.Add(EmployeeTimeForecastOfficeDetailEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailEmployee)

                ErrorText = EmployeeTimeForecastOfficeDetailEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailEmployee)

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
        Public Function DeleteByEmployeeTimeForecastOfficeDetailEmployeeID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailEmployeeID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLEMP WHERE ETF_OFFDTLEMP_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailEmployeeID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByEmployeeTimeForecastOfficeDetailEmployeeID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
