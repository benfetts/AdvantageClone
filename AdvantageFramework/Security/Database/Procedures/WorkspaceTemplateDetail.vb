Namespace Security.Database.Procedures.WorkspaceTemplateDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.WorkspaceTemplateDetail)

            Load = From WorkspaceTemplateDetail In DbContext.GetQuery(Of Database.Entities.WorkspaceTemplateDetail)
                   Select WorkspaceTemplateDetail

        End Function

#End Region

    End Module

End Namespace
