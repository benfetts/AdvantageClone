Namespace Security.Database.Procedures.ClientPortalUserWorkspace

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
        Public Function LoadByUserWorkspaceID(ByVal DbContext As Database.DbContext, ByVal UserWorkspaceID As Integer) As Security.Database.Entities.ClientPortalUserWorkspace

            Try

                LoadByUserWorkspaceID = (From ClientPortalUserWorkspace In DbContext.GetQuery(Of Database.Entities.ClientPortalUserWorkspace)
                                         Where ClientPortalUserWorkspace.ID = UserWorkspaceID
                                         Select ClientPortalUserWorkspace).SingleOrDefault

            Catch ex As Exception
                LoadByUserWorkspaceID = Nothing
            End Try

        End Function
        Public Function LoadByUserCodeAndName(ByVal DbContext As Database.DbContext, ByVal ClientContactID As Integer, ByVal Name As String) As Security.Database.Entities.ClientPortalUserWorkspace

            Try

                LoadByUserCodeAndName = (From ClientPortalUserWorkspace In DbContext.GetQuery(Of Database.Entities.ClientPortalUserWorkspace)
                                         Where ClientPortalUserWorkspace.ClientContactID = ClientContactID AndAlso
                                               ClientPortalUserWorkspace.Name = Name
                                         Select ClientPortalUserWorkspace).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeAndName = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientPortalUserWorkspace)

            Load = From ClientPortalUserWorkspace In DbContext.GetQuery(Of Database.Entities.ClientPortalUserWorkspace)
                   Select ClientPortalUserWorkspace

        End Function

        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal ClientContactID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientPortalUserWorkspace)

            LoadByUserID = From ClientPortalUserWorkspace In DbContext.GetQuery(Of Database.Entities.ClientPortalUserWorkspace)
                           Where ClientPortalUserWorkspace.ClientContactID = ClientContactID
                           Select ClientPortalUserWorkspace

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientContactID As Integer, _
                                ByVal Name As String, ByVal Description As String, ByVal SortOrder As Nullable(Of Integer), _
                                ByRef UserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserWorkspace = New AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace

                UserWorkspace.DbContext = DbContext
                UserWorkspace.ClientContactID = ClientContactID
                UserWorkspace.Name = Name
                UserWorkspace.Description = Description
                UserWorkspace.SortOrder = SortOrder

                Inserted = Insert(DbContext, UserWorkspace)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientPortalUserWorkspaces.Add(UserWorkspace)

                ErrorText = UserWorkspace.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserWorkspace)

                ErrorText = UserWorkspace.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject = Nothing

            Try

                'Don't validate on delete!
                'ErrorText = UserWorkspace.ValidateEntity(IsValid)

                If IsValid Then

                    If AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.DeleteUserWorkspaceObjects(DbContext, UserWorkspace.ID) Then

                        DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.CP_USER_WORKSPACE WHERE WORKSPACE_ID = " & UserWorkspace.ID)

                        Deleted = True

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByUserID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientContactID As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing

            Try

                For Each UserWorkspace In AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserID(DbContext, ClientContactID).ToList

                    AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Delete(DbContext, UserWorkspace)

                Next

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserID = Deleted
            End Try

        End Function


#End Region

    End Module

End Namespace
