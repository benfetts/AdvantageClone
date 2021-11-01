Namespace Database.Procedures.SalesTax

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

        Public Function IsResaleTax(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesTaxCode As String) As Boolean

            Try
			
                If String.IsNullOrWhiteSpace(SalesTaxCode) Then

                    IsResaleTax = False

                Else

                    IsResaleTax = CBool(LoadBySalesTaxCode(DbContext, SalesTaxCode).Resale.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                IsResaleTax = False
            End Try

        End Function
        Public Function LoadBySalesTaxCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesTaxCode As String) As AdvantageFramework.Database.Entities.SalesTax

            Try

                LoadBySalesTaxCode = (From SalesTax In DbContext.GetQuery(Of Database.Entities.SalesTax)
                                      Where SalesTax.TaxCode = SalesTaxCode
                                      Select SalesTax).SingleOrDefault

            Catch ex As Exception
                LoadBySalesTaxCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SalesTax)

            LoadAllActive = From SalesTax In DbContext.GetQuery(Of Database.Entities.SalesTax)
                            Where SalesTax.IsInactive = 0 OrElse
                                  SalesTax.IsInactive Is Nothing
                            Select SalesTax

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.SalesTax)

            Load = From SalesTax In DbContext.GetQuery(Of Database.Entities.SalesTax)
                   Select SalesTax

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesTax As AdvantageFramework.Database.Entities.SalesTax) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.SalesTaxes.Add(SalesTax)

                ErrorText = SalesTax.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesTax As AdvantageFramework.Database.Entities.SalesTax) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(SalesTax)

                ErrorText = SalesTax.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesTax As AdvantageFramework.Database.Entities.SalesTax) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(SalesTax)

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
