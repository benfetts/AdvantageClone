Namespace Security.Database.Procedures.UserFavoriteModule

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

        Public Function LoadByUserCodeAndWorkspaceIDAndModuleID(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal WorkspaceID As Integer, ByVal ModuleID As Integer) As Security.Database.Entities.UserFavoriteModule

            Try

                LoadByUserCodeAndWorkspaceIDAndModuleID = (From UserFavoriteModule In DbContext.GetQuery(Of Database.Entities.UserFavoriteModule)
                                                           Where UserFavoriteModule.UserCode = UserCode AndAlso
                                                                 UserFavoriteModule.WorkspaceID = WorkspaceID AndAlso
                                                                 UserFavoriteModule.ModuleID = ModuleID
                                                           Select UserFavoriteModule).SingleOrDefault

            Catch ex As Exception
                LoadByUserCodeAndWorkspaceIDAndModuleID = Nothing
            End Try

        End Function
        Public Function LoadByUserCodeAndWorkspaceID(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal WorkspaceID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserFavoriteModule)

            LoadByUserCodeAndWorkspaceID = From UserFavoriteModule In DbContext.GetQuery(Of Database.Entities.UserFavoriteModule)
                                           Where UserFavoriteModule.UserCode = UserCode AndAlso
                                                 UserFavoriteModule.WorkspaceID = WorkspaceID
                                           Select UserFavoriteModule

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserFavoriteModule)

            Load = From UserFavoriteModule In DbContext.GetQuery(Of Database.Entities.UserFavoriteModule)
                   Select UserFavoriteModule

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, _
                               ByVal UserCode As String, ByVal WorkspaceID As Integer, ByVal ModuleID As Integer, _
                               ByRef UserFavoriteModule As AdvantageFramework.Security.Database.Entities.UserFavoriteModule) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserFavoriteModule = New AdvantageFramework.Security.Database.Entities.UserFavoriteModule

                UserFavoriteModule.DbContext = DbContext
                UserFavoriteModule.UserCode = UserCode
                UserFavoriteModule.WorkspaceID = WorkspaceID
                UserFavoriteModule.ModuleID = ModuleID

                Inserted = Insert(DbContext, UserFavoriteModule)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserFavoriteModule As AdvantageFramework.Security.Database.Entities.UserFavoriteModule) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserFavoriteModules.Add(UserFavoriteModule)

                ErrorText = UserFavoriteModule.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserFavoriteModule As AdvantageFramework.Security.Database.Entities.UserFavoriteModule) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserFavoriteModule)

                ErrorText = UserFavoriteModule.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserFavoriteModule As AdvantageFramework.Security.Database.Entities.UserFavoriteModule) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserFavoriteModule)

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
