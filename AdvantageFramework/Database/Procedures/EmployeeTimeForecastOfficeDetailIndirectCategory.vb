Namespace Database.Procedures.EmployeeTimeForecastOfficeDetailIndirectCategory

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

        Public Function LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer) As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory

            Try

                LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID = (From EmployeeTimeForecastOfficeDetailIndirectCategory In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)
                                                                            Where EmployeeTimeForecastOfficeDetailIndirectCategory.ID = EmployeeTimeForecastOfficeDetailIndirectCategoryID
                                                                            Select EmployeeTimeForecastOfficeDetailIndirectCategory).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTimeForecastOfficeDetailIndirectCategoryID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTimeForecastOfficeDetailID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)

            LoadByEmployeeTimeForecastOfficeDetailID = From EmployeeTimeForecastOfficeDetailIndirectCategory In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)
                                                       Where EmployeeTimeForecastOfficeDetailIndirectCategory.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                                                       Select EmployeeTimeForecastOfficeDetailIndirectCategory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)

            Load = From EmployeeTimeForecastOfficeDetailIndirectCategory In DbContext.GetQuery(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)
                   Select EmployeeTimeForecastOfficeDetailIndirectCategory

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeForecastID As Integer, _
                               ByVal EmployeeTimeForecastOfficeDetailID As Integer, ByVal IndirectCategoryCode As String, _
                               ByRef EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeTimeForecastOfficeDetailIndirectCategory = New AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory

                EmployeeTimeForecastOfficeDetailIndirectCategory.DbContext = DbContext
                EmployeeTimeForecastOfficeDetailIndirectCategory.EmployeeTimeForecastID = EmployeeTimeForecastID
                EmployeeTimeForecastOfficeDetailIndirectCategory.EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID
                EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode = IndirectCategoryCode

                Inserted = Insert(DbContext, EmployeeTimeForecastOfficeDetailIndirectCategory)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeForecastOfficeDetailIndirectCategories.Add(EmployeeTimeForecastOfficeDetailIndirectCategory)

                ErrorText = EmployeeTimeForecastOfficeDetailIndirectCategory.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategory)

                ErrorText = EmployeeTimeForecastOfficeDetailIndirectCategory.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeForecastOfficeDetailIndirectCategory)

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
        Public Function DeleteByEmployeeTimeForecastOfficeDetailIndirectCategoryID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail, ByVal EmployeeTimeForecastOfficeDetailIndirectCategoryID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.ETF_OFFDTLCAT WHERE ETF_OFFDTLCAT_ID = {0} AND ETF_ID = {1} AND ETF_OFFDTL_ID = {2}", _
                                                                EmployeeTimeForecastOfficeDetailIndirectCategoryID, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID, _
                                                                EmployeeTimeForecastOfficeDetail.ID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByEmployeeTimeForecastOfficeDetailIndirectCategoryID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
