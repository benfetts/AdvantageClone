Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailJobComponent

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

        Public Function LoadByEmployeeTimeForecastOfficeDetailJobComponentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent

            Try

                LoadByEmployeeTimeForecastOfficeDetailJobComponentID = (From EmployeeTimeForecastOfficeDetailJobComponent In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
                                                                        Where EmployeeTimeForecastOfficeDetailJobComponent.ID = EmployeeTimeForecastOfficeDetailJobComponentID
                                                                        Select EmployeeTimeForecastOfficeDetailJobComponent).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastOfficeDetailJobComponentID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailJobComponent In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
                                                       Where EmployeeTimeForecastOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailJobComponent

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)

            Load = From EmployeeTimeForecastOfficeDetailJobComponent In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
                   Select EmployeeTimeForecastOfficeDetailJobComponent

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, ByVal EmployeeTimeForecastOfficeDetailID As Integer, _
                               ByVal JobNumber As Integer, ByVal RevenueAmount As Decimal, ByVal JobComponentNumber As Short, ByVal ClientCode As String, _
                               ByVal DivisionCode As String, ByVal ProductCode As String, ByVal OfficeCode As String, _
                               ByRef EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailJobComponent = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent

                EmployeeTimeForecastOfficeDetailJobComponent.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailJobComponent.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailJobComponent.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailJobComponent.JobNumber = JobNumber
                EmployeeTimeForecastOfficeDetailJobComponent.RevenueAmount = RevenueAmount
                EmployeeTimeForecastOfficeDetailJobComponent.JobComponentNumber = JobComponentNumber
                EmployeeTimeForecastOfficeDetailJobComponent.ClientCode = ClientCode
                EmployeeTimeForecastOfficeDetailJobComponent.DivisionCode = DivisionCode
                EmployeeTimeForecastOfficeDetailJobComponent.ProductCode = ProductCode
                EmployeeTimeForecastOfficeDetailJobComponent.OfficeCode = OfficeCode

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailJobComponent)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailJobComponents.Add(EmployeeTimeForecastOfficeDetailJobComponent)

                ErrorText = EmployeeTimeForecastOfficeDetailJobComponent.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponent)

                ErrorText = EmployeeTimeForecastOfficeDetailJobComponent.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailJobComponent)

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
        Public Function DeleteByEmployeeTimeForecastOfficeDetailJobComponentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailJobComponentID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLJC WHERE ETF_OFFDTLJC_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailJobComponentID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByEmployeeTimeForecastOfficeDetailJobComponentID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
