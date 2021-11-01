Namespace Database.Procedures.CompanyProfileAffiliation

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CompanyProfileAffiliation)

            Load = From CompanyProfileAffiliation In DbContext.GetQuery(Of Database.Entities.CompanyProfileAffiliation)
                   Select CompanyProfileAffiliation

        End Function
        Public Function LoadByCompanyProfileID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CompanyProfileID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CompanyProfileAffiliation)

            LoadByCompanyProfileID = From CompanyProfileAffiliation In DbContext.GetQuery(Of Database.Entities.CompanyProfileAffiliation)
                                     Where CompanyProfileAffiliation.CompanyProfileID = CompanyProfileID
                                     Select CompanyProfileAffiliation

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As Database.Entities.CompanyProfileAffiliation

            Try

                LoadByID = (From CompanyProfileAffiliation In DbContext.GetQuery(Of Database.Entities.CompanyProfileAffiliation)
                            Where CompanyProfileAffiliation.ID = ID
                            Select CompanyProfileAffiliation).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.CompanyProfileAffiliations.Add(CompanyProfileAffiliation)

                ErrorText = CompanyProfileAffiliation.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.CompanyProfileAffiliations.Any(Function(Entity) Entity.CompanyProfileID = CompanyProfileAffiliation.CompanyProfileID AndAlso _
                                                                                     Entity.AffiliationID = CompanyProfileAffiliation.AffiliationID) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique affiliation.")

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(CompanyProfileAffiliation)

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
