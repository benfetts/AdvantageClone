Namespace Security.Database.Procedures.UserPermissionView

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

        Public Function LoadByApplicationAndModuleAndUser(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserCode As String) As Security.Database.Views.UserPermission

            Try

                LoadByApplicationAndModuleAndUser = (From UserPermission In DbContext.GetQuery(Of Database.Views.UserPermission)
                                                     Where UserPermission.ApplicationID = ApplicationID AndAlso
                                                           UserPermission.ModuleCode = ModuleCode AndAlso
                                                           UserPermission.UserCode = UserCode
                                                     Select UserPermission).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationAndModuleAndUser = Nothing
            End Try

        End Function
        Public Function LoadByApplicationAndModuleAndUser(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserCode As String) As Security.Database.Views.UserPermission

            Try

                LoadByApplicationAndModuleAndUser = (From UserPermission In DbContext.GetQuery(Of Database.Views.UserPermission)
                                                     Where UserPermission.ApplicationID = ApplicationID AndAlso
                                                           UserPermission.ModuleID = ModuleID AndAlso
                                                           UserPermission.UserCode = UserCode
                                                     Select UserPermission).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationAndModuleAndUser = Nothing
            End Try

        End Function
        Public Function LoadByApplicationAndModuleAndUser(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleCode As String, ByVal UserID As Integer) As Security.Database.Views.UserPermission

            Try

                LoadByApplicationAndModuleAndUser = (From UserPermission In DbContext.GetQuery(Of Database.Views.UserPermission)
                                                     Where UserPermission.ApplicationID = ApplicationID AndAlso
                                                           UserPermission.ModuleCode = ModuleCode AndAlso
                                                           UserPermission.UserID = UserID
                                                     Select UserPermission).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationAndModuleAndUser = Nothing
            End Try

        End Function
        Public Function LoadByApplicationAndModuleAndUser(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, ByVal UserID As Integer) As Security.Database.Views.UserPermission

            Try

                LoadByApplicationAndModuleAndUser = (From UserPermission In DbContext.GetQuery(Of Database.Views.UserPermission)
                                                     Where UserPermission.ApplicationID = ApplicationID AndAlso
                                                           UserPermission.ModuleID = ModuleID AndAlso
                                                           UserPermission.UserID = UserID
                                                     Select UserPermission).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationAndModuleAndUser = Nothing
            End Try

        End Function
        Public Function LoadByApplicationAndUser(ByVal DbContext As Database.DbContext, ByVal ApplicationID As Integer, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.UserPermission)

            LoadByApplicationAndUser = From UserPermission In DbContext.GetQuery(Of Database.Views.UserPermission)
                                       Where UserPermission.ApplicationID = ApplicationID AndAlso
                                             UserPermission.UserID = UserID
                                       Select UserPermission

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.UserPermission)

            Load = From UserPermission In DbContext.GetQuery(Of Database.Views.UserPermission)
                   Select UserPermission

        End Function

#End Region

    End Module

End Namespace
