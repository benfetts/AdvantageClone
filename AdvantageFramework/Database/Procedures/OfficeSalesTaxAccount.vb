Namespace Database.Procedures.OfficeSalesTaxAccount

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeSalesTaxAccount)

            Load = From OfficeSalesTaxAccount In DbContext.GetQuery(Of Database.Entities.OfficeSalesTaxAccount)
                   Select OfficeSalesTaxAccount

        End Function
        Public Function LoadByOfficeCodeTaxCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String, ByVal SalesTaxCode As String) As Database.Entities.OfficeSalesTaxAccount

            LoadByOfficeCodeTaxCode = (From OfficeSalesTaxAccount In DbContext.GetQuery(Of Database.Entities.OfficeSalesTaxAccount)
                                       Where OfficeSalesTaxAccount.OfficeCode = OfficeCode AndAlso
                                       OfficeSalesTaxAccount.SalesTaxCode = SalesTaxCode
                                       Select OfficeSalesTaxAccount).SingleOrDefault

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeSalesTaxAccount)

            LoadByOfficeCode = From OfficeSalesTaxAccount In DbContext.GetQuery(Of Database.Entities.OfficeSalesTaxAccount)
                               Where OfficeSalesTaxAccount.OfficeCode = OfficeCode
                               Select OfficeSalesTaxAccount

        End Function
        Public Function InsertFromExistingOffice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CopyFromOfficeCode As String, ByVal CopyToOfficeCode As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim InsertSQL As String = Nothing

            Try

                InsertSQL = "insert OFF_TAX_ACCTS (OFFICE_CODE, TAX_CODE, GLACODE_TAX_STATE, GLACODE_TAX_CNTY, GLACODE_TAX_CITY) " & _
                            "select '{0}', TAX_CODE, GLACODE_TAX_STATE, GLACODE_TAX_CNTY, GLACODE_TAX_CITY " & _
                            "from OFF_TAX_ACCTS where OFFICE_CODE = '{1}'"

                DbContext.Database.ExecuteSqlCommand(String.Format(InsertSQL, CopyToOfficeCode, CopyFromOfficeCode))

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertFromExistingOffice = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeSalesTaxAccount As AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OfficeSalesTaxAccounts.Add(OfficeSalesTaxAccount)

                ErrorText = OfficeSalesTaxAccount.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeSalesTaxAccount As AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OfficeSalesTaxAccount)

                ErrorText = OfficeSalesTaxAccount.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeSalesTaxAccount As AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(OfficeSalesTaxAccount)

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
