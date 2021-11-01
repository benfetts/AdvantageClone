Namespace Security.Database.Procedures.WorkspaceTemplate

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

        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.WorkspaceTemplate)

            Try

                LoadByUserID = (From WorkspaceTemplate In DbContext.GetQuery(Of Database.Entities.WorkspaceTemplate)
                                Where WorkspaceTemplate.CreatedByUserID = UserID
                                Select WorkspaceTemplate)

            Catch ex As Exception
                LoadByUserID = Nothing
            End Try

        End Function
        Public Function LoadByWorkspaceTemplateID(ByVal DbContext As Database.DbContext, ByVal WorkspaceTemplateID As Integer) As Security.Database.Entities.WorkspaceTemplate

            Try

                LoadByWorkspaceTemplateID = (From WorkspaceTemplate In DbContext.GetQuery(Of Database.Entities.WorkspaceTemplate)
                                             Where WorkspaceTemplate.ID = WorkspaceTemplateID
                                             Select WorkspaceTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByWorkspaceTemplateID = Nothing
            End Try

        End Function
        Public Function LoadClientPortalWorkspaceTemplates(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.WorkspaceTemplate)

            LoadClientPortalWorkspaceTemplates = From WorkspaceTemplate In DbContext.GetQuery(Of Database.Entities.WorkspaceTemplate)
                                                 Where WorkspaceTemplate.IsClientPortal = 1
                                                 Select WorkspaceTemplate

        End Function
        Public Function LoadNonClientPortalWorkspaceTemplates(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.WorkspaceTemplate)

            LoadNonClientPortalWorkspaceTemplates = From WorkspaceTemplate In DbContext.GetQuery(Of Database.Entities.WorkspaceTemplate)
                                                    Where WorkspaceTemplate.IsClientPortal Is Nothing OrElse
                                                          WorkspaceTemplate.IsClientPortal = 0
                                                    Select WorkspaceTemplate

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.WorkspaceTemplate)

            Load = From WorkspaceTemplate In DbContext.GetQuery(Of Database.Entities.WorkspaceTemplate)
                   Select WorkspaceTemplate

        End Function

#End Region

    End Module

End Namespace
