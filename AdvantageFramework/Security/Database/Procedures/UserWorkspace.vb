Namespace Security.Database.Procedures.UserWorkspace

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

        Public Function LoadByUserWorkspaceID(ByVal DbContext As Database.DbContext, ByVal UserWorkspaceID As Integer) As Security.Database.Entities.UserWorkspace

            Try

                LoadByUserWorkspaceID = (From UserWorkspace In DbContext.GetQuery(Of Database.Entities.UserWorkspace)
                                         Where UserWorkspace.ID = UserWorkspaceID
                                         Select UserWorkspace).SingleOrDefault

            Catch ex As Exception
                LoadByUserWorkspaceID = Nothing
            End Try

        End Function
        Public Function LoadByUserCodeAndName(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal Name As String) As Security.Database.Entities.UserWorkspace

            Try

                LoadByUserCodeAndName = (From UserWorkspace In DbContext.GetQuery(Of Database.Entities.UserWorkspace)
                                         Where UserWorkspace.UserCode = UserCode AndAlso
                                               UserWorkspace.Name = Name AndAlso
                                               (UserWorkspace.IsClientPortal Is Nothing Or UserWorkspace.IsClientPortal = 0)
                                         Select UserWorkspace).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeAndName = Nothing
            End Try

        End Function
        Public Function LoadByUserCodeAndNameCP(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal Name As String, ByVal IsClientPortal As Integer) As Security.Database.Entities.UserWorkspace

            Try

                LoadByUserCodeAndNameCP = (From UserWorkspace In DbContext.GetQuery(Of Database.Entities.UserWorkspace)
                                           Where UserWorkspace.UserCode = UserCode AndAlso
                                               UserWorkspace.Name = Name AndAlso
                                               UserWorkspace.IsClientPortal = IsClientPortal
                                           Select UserWorkspace).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeAndNameCP = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserWorkspace)

            LoadByUserCode = From UserWorkspace In DbContext.GetQuery(Of Database.Entities.UserWorkspace)
                             Where UserWorkspace.UserCode = UserCode
                             Select UserWorkspace

        End Function
        Public Function LoadByUserCodeCP(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal IsClientPortal As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserWorkspace)

            LoadByUserCodeCP = From UserWorkspace In DbContext.GetQuery(Of Database.Entities.UserWorkspace)
                               Where UserWorkspace.UserCode = UserCode AndAlso
                                   UserWorkspace.IsClientPortal = IsClientPortal
                               Select UserWorkspace

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserWorkspace)

            Load = From UserWorkspace In DbContext.GetQuery(Of Database.Entities.UserWorkspace)
                   Select UserWorkspace

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, _
                               ByVal Name As String, ByVal Description As String, ByVal SortOrder As Nullable(Of Integer), ByVal IsClientPortal As Nullable(Of Integer), _
                               ByRef UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserWorkspace = New AdvantageFramework.Security.Database.Entities.UserWorkspace

                UserWorkspace.DbContext = DbContext
                UserWorkspace.UserCode = UserCode
                UserWorkspace.Name = Name
                UserWorkspace.Description = Description
                UserWorkspace.SortOrder = SortOrder
                UserWorkspace.IsClientPortal = IsClientPortal

                Inserted = Insert(DbContext, UserWorkspace)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserWorkspaces.Add(UserWorkspace)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace) As Boolean

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
         Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = AdvantageFramework.Security.Database.Procedures.WorkspaceObject.DeleteUserWorkspaceObjects(DbContext, UserWorkspace.ID)

                If IsValid Then
                    
                    Try

                        DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.WV_USER_WORKSPACE WHERE WORKSPACE_ID = " & UserWorkspace.ID)

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByUserCode(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing

            Try

                For Each UserWorkspace In AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(DbContext, UserCode).ToList

                    AdvantageFramework.Security.Database.Procedures.UserWorkspace.Delete(DbContext, UserWorkspace)

                Next

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
