Namespace Database.Procedures.Affiliation

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Affiliation)

            Load = From Affiliation In DbContext.GetQuery(Of Database.Entities.Affiliation)
                   Select Affiliation

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Affiliation)

            LoadAllActive = From Affiliation In DbContext.GetQuery(Of Database.Entities.Affiliation)
                            Where Affiliation.IsInactive = False
                            Select Affiliation

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.Affiliation

            Try

                LoadByID = (From Affiliation In DbContext.GetQuery(Of Database.Entities.Affiliation)
                            Where Affiliation.ID = ID
                            Select Affiliation).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Affiliation As AdvantageFramework.Database.Entities.Affiliation) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Affiliations.Add(Affiliation)

                ErrorText = Affiliation.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Affiliation As AdvantageFramework.Database.Entities.Affiliation) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Affiliation)

                ErrorText = Affiliation.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Affiliation As AdvantageFramework.Database.Entities.Affiliation) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Load(DbContext).Where(Function(Entity) Entity.AffiliationID = Affiliation.ID).Any Then

                    IsValid = False
                    ErrorText = "This code is in use cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(Affiliation)

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
