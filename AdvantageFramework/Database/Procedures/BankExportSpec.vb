Namespace Database.Procedures.BankExportSpec

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

        Public Function LoadByBankCode(ByVal DbContext As Database.DbContext, ByVal BankCode As String) As Database.Entities.BankExportSpec

            Try

                LoadByBankCode = (From BankExportSpec In DbContext.GetQuery(Of Database.Entities.BankExportSpec)
                                  Where BankExportSpec.BankCode = BankCode
                                  Select BankExportSpec).SingleOrDefault

            Catch ex As Exception
                LoadByBankCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BankExportSpec)

            Load = From BankExportSpec In DbContext.GetQuery(Of Database.Entities.BankExportSpec)
                   Select BankExportSpec

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.BankExportSpecs.Add(BankExportSpec)

                ErrorText = BankExportSpec.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BankExportSpec)

                ErrorText = BankExportSpec.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(BankExportSpec)

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
