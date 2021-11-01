Namespace Database.Procedures.OfficeInterCompany

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeInterCompany)

            Load = From OfficeInterCompany In DbContext.GetQuery(Of Database.Entities.OfficeInterCompany)
                   Select OfficeInterCompany

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeInterCompany)

            LoadByOfficeCode = From OfficeInterCompany In DbContext.GetQuery(Of Database.Entities.OfficeInterCompany)
                               Where OfficeInterCompany.OfficeCode = OfficeCode
                               Select OfficeInterCompany

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OfficeInterCompanies.Add(OfficeInterCompany)

                ErrorText = OfficeInterCompany.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OfficeInterCompany)

                ErrorText = OfficeInterCompany.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(OfficeInterCompany)

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
