Namespace Database.Procedures.ProductSortKey

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


        Public Function LoadByClientAndDivisionAndProductCodeAndSortKey(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal SortKey As String) As AdvantageFramework.Database.Entities.ProductSortKey

            Try

                LoadByClientAndDivisionAndProductCodeAndSortKey = (From ProductSortKey In DbContext.GetQuery(Of Database.Entities.ProductSortKey)
                                                                   Where ProductSortKey.ClientCode = ClientCode AndAlso
                                                                         ProductSortKey.DivisionCode = DivisionCode AndAlso
                                                                         ProductSortKey.ProductCode = ProductCode AndAlso
                                                                         ProductSortKey.SortKey = SortKey
                                                                   Select ProductSortKey).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndDivisionAndProductCodeAndSortKey = Nothing
            End Try

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductSortKey)

            LoadByClientAndDivisionAndProductCode = From ProductSortKey In DbContext.GetQuery(Of Database.Entities.ProductSortKey)
                                                    Where ProductSortKey.ClientCode = ClientCode AndAlso
                                                          ProductSortKey.DivisionCode = DivisionCode AndAlso
                                                          ProductSortKey.ProductCode = ProductCode
                                                    Select ProductSortKey

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductSortKey)

            Load = From ProductSortKey In DbContext.GetQuery(Of Database.Entities.ProductSortKey)
                   Select ProductSortKey

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                       ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal SortKey As String, _
                       ByRef ProductSortKey As AdvantageFramework.Database.Entities.ProductSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ProductSortKey = New AdvantageFramework.Database.Entities.ProductSortKey

                ProductSortKey.DbContext = DbContext
                ProductSortKey.ClientCode = ClientCode
                ProductSortKey.DivisionCode = DivisionCode
                ProductSortKey.ProductCode = ProductCode
                ProductSortKey.SortKey = SortKey

                Inserted = Insert(DbContext, ProductSortKey)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductSortKey As AdvantageFramework.Database.Entities.ProductSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ProductSortKeys.Add(ProductSortKey)

                ErrorText = ProductSortKey.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.ProductSortKeys.Any(Function(PrdSrtKey) PrdSrtKey.ProductCode = ProductSortKey.ProductCode AndAlso _
                                                                             PrdSrtKey.DivisionCode = ProductSortKey.DivisionCode AndAlso _
                                                                             PrdSrtKey.ClientCode = ProductSortKey.ClientCode AndAlso _
                                                                             PrdSrtKey.SortKey = ProductSortKey.SortKey) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique product sort key.")

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductSortKey As AdvantageFramework.Database.Entities.ProductSortKey) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ProductSortKey)

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
