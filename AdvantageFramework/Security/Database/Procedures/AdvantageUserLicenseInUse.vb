Namespace Security.Database.Procedures.AdvantageUserLicenseInUse

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

        Public Function LoadByAdvantageUserLicenseInUseID(ByVal DbContext As Database.DbContext, ByVal AdvantageUserLicenseInUseID As Integer) As Security.Database.Entities.AdvantageUserLicenseInUse

            Try

                LoadByAdvantageUserLicenseInUseID = (From AdvantageUserLicenseInUse In DbContext.GetQuery(Of Database.Entities.AdvantageUserLicenseInUse)
                                                     Where AdvantageUserLicenseInUse.ID = AdvantageUserLicenseInUseID
                                                     Select AdvantageUserLicenseInUse).SingleOrDefault

            Catch ex As Exception
                LoadByAdvantageUserLicenseInUseID = Nothing
            End Try

        End Function
        Public Function LoadByType(ByVal DbContext As Database.DbContext, ByVal Type As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.AdvantageUserLicenseInUse)

            LoadByType = From AdvantageUserLicenseInUse In DbContext.GetQuery(Of Database.Entities.AdvantageUserLicenseInUse)
                         Where AdvantageUserLicenseInUse.Type = Type
                         Select AdvantageUserLicenseInUse

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.AdvantageUserLicenseInUse)

            Load = From AdvantageUserLicenseInUse In DbContext.GetQuery(Of Database.Entities.AdvantageUserLicenseInUse)
                   Select AdvantageUserLicenseInUse

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, _
                               ByVal LicenseKeyType As AdvantageFramework.Security.LicenseKey.Types, _
                               ByVal Assigned As String, _
                               ByRef AdvantageUserLicenseInUse As AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM AULU WHERE AULU_ASSIGN = '{0}';", Assigned))

            Catch ex As Exception
            End Try

            Try


                AdvantageUserLicenseInUse = New AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse

                AdvantageUserLicenseInUse.DbContext = DbContext
                AdvantageUserLicenseInUse.Type = LicenseKeyType
                AdvantageUserLicenseInUse.Assigned = Assigned

                Inserted = Insert(DbContext, AdvantageUserLicenseInUse)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal AdvantageUserLicenseInUse As AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AdvantageUserLicenseInUses.Add(AdvantageUserLicenseInUse)

                ErrorText = AdvantageUserLicenseInUse.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal AdvantageUserLicenseInUse As AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AdvantageUserLicenseInUse)

                ErrorText = AdvantageUserLicenseInUse.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal AdvantageUserLicenseInUse As AdvantageFramework.Security.Database.Entities.AdvantageUserLicenseInUse) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AdvantageUserLicenseInUse)

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
