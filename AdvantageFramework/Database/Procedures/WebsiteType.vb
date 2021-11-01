Namespace Database.Procedures.WebsiteType

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.WebsiteType)

            LoadAllActive = From WebsiteType In DbContext.GetQuery(Of Database.Entities.WebsiteType)
                            Where WebsiteType.IsInactive = False
                            Select WebsiteType

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.WebsiteType)

            Load = From WebsiteType In DbContext.GetQuery(Of Database.Entities.WebsiteType)
                   Select WebsiteType

        End Function
        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal Code As String) As Database.Entities.WebsiteType

            Try

                LoadByCode = (From WebsiteType In DbContext.GetQuery(Of Database.Entities.WebsiteType)
                              Where WebsiteType.Code = Code
                              Select WebsiteType).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal WebsiteType As AdvantageFramework.Database.Entities.WebsiteType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.WebsiteTypes.Add(WebsiteType)

                ErrorText = WebsiteType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal WebsiteType As AdvantageFramework.Database.Entities.WebsiteType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(WebsiteType)

                ErrorText = WebsiteType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal WebsiteType As AdvantageFramework.Database.Entities.WebsiteType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.ClientWebsite)
                        Where Entity.WebsiteTypeCode.ToUpper = WebsiteType.Code.ToUpper
                        Select Entity).Any Then

                        IsValid = False

                        ErrorText = "Code is in use and cannot be deleted."

                    End If

                Catch ex As Exception
                    ErrorText = "Failed deleting website type."
                    IsValid = False
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(WebsiteType)

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
