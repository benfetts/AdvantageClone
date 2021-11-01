Namespace Database.Procedures.ProductCategory

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

        Public Function LoadAvailableToCopy(ByVal DbContext As Database.DbContext, Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "", Optional ByVal ProductCode As String = "") As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductCategory)

            Try

                LoadAvailableToCopy = From ProductCategory In DbContext.GetQuery(Of Database.Entities.ProductCategory)
                                      Where ProductCategory.ClientCode <> ClientCode AndAlso
                                            ProductCategory.DivisionCode <> DivisionCode AndAlso
                                            ProductCategory.ProductCode <> ProductCode
                                      Select ProductCategory
            Catch ex As Exception
                LoadAvailableToCopy = Nothing
            End Try

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductCategory)

            Try

                LoadByClientAndDivisionCode = From ProductCategory In DbContext.GetQuery(Of Database.Entities.ProductCategory)
                                              Where ProductCategory.ClientCode = ClientCode AndAlso
                                                    ProductCategory.DivisionCode = DivisionCode
                                              Select ProductCategory

            Catch ex As Exception
                LoadByClientAndDivisionCode = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductCategory)

            Try

                LoadByClientCode = From ProductCategory In DbContext.GetQuery(Of Database.Entities.ProductCategory)
                                   Where ProductCategory.ClientCode = ClientCode
                                   Select ProductCategory

            Catch ex As Exception
                LoadByClientCode = Nothing
            End Try

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductCategory)

            Try

                LoadByClientAndDivisionAndProductCode = From ProductCategory In DbContext.GetQuery(Of Database.Entities.ProductCategory)
                                                        Where ProductCategory.ClientCode = ClientCode AndAlso
                                                                ProductCategory.DivisionCode = DivisionCode AndAlso
                                                                ProductCategory.ProductCode = ProductCode
                                                        Select ProductCategory
            Catch ex As Exception
                LoadByClientAndDivisionAndProductCode = Nothing
            End Try

        End Function
        Public Function LoadByClientAndDivisionAndProductAndProductCategoryCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal ProductCategoryCode As String) As Database.Entities.ProductCategory

            Try

                LoadByClientAndDivisionAndProductAndProductCategoryCode = (From ProductCategory In DbContext.GetQuery(Of Database.Entities.ProductCategory)
                                                                           Where ProductCategory.ClientCode = ClientCode AndAlso
                                                                                            ProductCategory.DivisionCode = DivisionCode AndAlso
                                                                                            ProductCategory.ProductCode = ProductCode AndAlso
                                                                                            ProductCategory.Code = ProductCategoryCode
                                                                           Select ProductCategory).SingleOrDefault
            Catch ex As Exception

                LoadByClientAndDivisionAndProductAndProductCategoryCode = Nothing

            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ProductCategory)

            LoadAllActive = From ProductCategory In DbContext.GetQuery(Of Database.Entities.ProductCategory)
                            Where ProductCategory.IsInactive Is Nothing OrElse
                                  ProductCategory.IsInactive = 0
                            Select ProductCategory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductCategory)

            Load = From ProductCategory In DbContext.GetQuery(Of Database.Entities.ProductCategory)
                   Select ProductCategory

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, _
                               ByVal Code As String, ByVal Description As String, ByVal IsInactive As Short, _
                               ByRef ProductCategory As AdvantageFramework.Database.Entities.ProductCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ProductCategory = New AdvantageFramework.Database.Entities.ProductCategory

                ProductCategory.DbContext = DbContext
                ProductCategory.ClientCode = ClientCode
                ProductCategory.DivisionCode = DivisionCode
                ProductCategory.ProductCode = ProductCode
                ProductCategory.Code = Code
                ProductCategory.Description = Description
                ProductCategory.IsInactive = IsInactive

                Inserted = Insert(DbContext, ProductCategory)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductCategory As AdvantageFramework.Database.Entities.ProductCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ProductCategories.Add(ProductCategory)

                ErrorText = ProductCategory.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.ProductCategories.Any(Function(PrdSrtKey) PrdSrtKey.ProductCode = ProductCategory.ProductCode AndAlso _
                                                                               PrdSrtKey.DivisionCode = ProductCategory.DivisionCode AndAlso _
                                                                               PrdSrtKey.ClientCode = ProductCategory.ClientCode AndAlso _
                                                                               PrdSrtKey.Code = ProductCategory.Code) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique product category code.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductCategory As AdvantageFramework.Database.Entities.ProductCategory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ProductCategory)

                ErrorText = ProductCategory.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductCategory As AdvantageFramework.Database.Entities.ProductCategory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.EMP_TIME_DTL ETL " &
                                                                             "JOIN JOB_LOG JL on JL.JOB_NUMBER = ETL.JOB_NUMBER " &
                                                                             "WHERE ETL.PROD_CAT_CODE = '{0}' AND JL.CL_CODE = '{1}'",
                                                                             ProductCategory.Code.Replace("'", "''"),
                                                                             ProductCategory.ClientCode.Replace("'", "''"))).FirstOrDefault > 0 Then

                    ErrorText = "The product category is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(ProductCategory)

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