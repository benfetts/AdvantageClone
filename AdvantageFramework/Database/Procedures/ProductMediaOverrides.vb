Namespace Database.Procedures.ProductMediaOverrides

    <HideModuleName()>
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

        Public Function LoadByClientDivisionProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String, ProductCode As String) As IQueryable(Of Entities.ProductMediaOverrides)

            LoadByClientDivisionProduct = DbContext.Set(Of Entities.ProductMediaOverrides)().Where(Function(ProductMediaOverrides) ProductMediaOverrides.ClientCode = ClientCode AndAlso ProductMediaOverrides.DivisionCode = DivisionCode AndAlso ProductMediaOverrides.ProductCode = ProductCode)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of Entities.ProductMediaOverrides)

            Load = DbContext.Set(Of Entities.ProductMediaOverrides)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ProductMediaOverrides.Add(ProductMediaOverrides)

                ErrorText = ProductMediaOverrides.ValidateEntity(IsValid)

                If IsValid Then

                    ProductMediaOverrides.CreatedByUserCode = DbContext.UserCode
                    ProductMediaOverrides.CreatedDate = Now

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                ProductMediaOverrides.DbContext = DbContext

                DbContext.Entry(ProductMediaOverrides).State = Entity.EntityState.Modified

                ErrorMessage = ProductMediaOverrides.ValidateEntity(IsValid)

                If IsValid Then

                    ProductMediaOverrides.ModifiedByUserCode = DbContext.UserCode
                    ProductMediaOverrides.ModifiedDate = Now

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(ProductMediaOverrides).State = Entity.EntityState.Deleted

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
