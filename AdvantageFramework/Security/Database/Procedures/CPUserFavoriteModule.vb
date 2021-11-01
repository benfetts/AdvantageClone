Namespace Security.Database.Procedures.CPUserFavoriteModule

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

        Public Function LoadByIDAndWorkspaceIDAndModuleID(ByVal DbContext As Database.DbContext, ByVal ID As Integer, ByVal WorkspaceID As Integer, ByVal ModuleID As Integer) As Security.Database.Entities.CPUserFavoriteModule

            Try

                LoadByIDAndWorkspaceIDAndModuleID = (From CPUserFavoriteModule In DbContext.GetQuery(Of Database.Entities.CPUserFavoriteModule)
                                                     Where CPUserFavoriteModule.ID = ID AndAlso
                                                                 CPUserFavoriteModule.WorkspaceID = WorkspaceID AndAlso
                                                                 CPUserFavoriteModule.ModuleID = ModuleID
                                                     Select CPUserFavoriteModule).SingleOrDefault

            Catch ex As Exception
                LoadByIDAndWorkspaceIDAndModuleID = Nothing
            End Try

        End Function
        Public Function LoadByIDAndWorkspaceID(ByVal DbContext As Database.DbContext, ByVal ID As Integer, ByVal WorkspaceID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.CPUserFavoriteModule)

            LoadByIDAndWorkspaceID = From CPUserFavoriteModule In DbContext.GetQuery(Of Database.Entities.CPUserFavoriteModule)
                                     Where CPUserFavoriteModule.ID = ID AndAlso
                                                 CPUserFavoriteModule.WorkspaceID = WorkspaceID
                                     Select CPUserFavoriteModule

        End Function

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.CPUserFavoriteModule)

            Load = From CPUserFavoriteModule In DbContext.GetQuery(Of Database.Entities.CPUserFavoriteModule)
                   Select CPUserFavoriteModule

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, _
                               ByVal ID As Integer, ByVal WorkspaceID As Integer, ByVal ModuleID As Integer, _
                               ByRef CPUserFavoriteModule As AdvantageFramework.Security.Database.Entities.CPUserFavoriteModule) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                CPUserFavoriteModule = New AdvantageFramework.Security.Database.Entities.CPUserFavoriteModule

                CPUserFavoriteModule.DbContext = DbContext
                CPUserFavoriteModule.ID = ID
                CPUserFavoriteModule.WorkspaceID = WorkspaceID
                CPUserFavoriteModule.ModuleID = ModuleID

                Inserted = Insert(DbContext, CPUserFavoriteModule)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal CPUserFavoriteModule As AdvantageFramework.Security.Database.Entities.CPUserFavoriteModule) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.CPUserFavoriteModules.Add(CPUserFavoriteModule)

                ErrorText = CPUserFavoriteModule.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal CPUserFavoriteModule As AdvantageFramework.Security.Database.Entities.CPUserFavoriteModule) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CPUserFavoriteModule)

                ErrorText = CPUserFavoriteModule.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal CPUserFavoriteModule As AdvantageFramework.Security.Database.Entities.CPUserFavoriteModule) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(CPUserFavoriteModule)

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
