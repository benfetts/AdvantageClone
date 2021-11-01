Namespace Database.Procedures.TaskTemplateWithRolesComplexType

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

        Public Function Load(DbContext As Database.DbContext, TaskTemplateCode As String) As System.Collections.Generic.List(Of Database.Classes.TaskTemplateWithRoles)

            'objects
            Dim SqlParameterTaskTemplateCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterTaskTemplateCode = New System.Data.SqlClient.SqlParameter("@TRF_PRESET_CODE", SqlDbType.VarChar)
            SqlParameterTaskTemplateCode.Value = TaskTemplateCode

            Load = DbContext.Database.SqlQuery(Of Database.Classes.TaskTemplateWithRoles)("EXEC dbo.usp_get_task_template_with_roles @TRF_PRESET_CODE", SqlParameterTaskTemplateCode).ToList

        End Function

#End Region

    End Module

End Namespace
