Namespace Database.Procedures.MyObjectDefinitionComplexType

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

        Public Function Load(DbContext As Database.DbContext, ByVal ObjectID As Integer, ByVal ShowOnlyCheckedDefinitions As Boolean) As System.Collections.Generic.List(Of Database.Classes.MyObjectDefinition)

            'objects
            Dim SqlParameterObjectID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowOnlyCheckedDefinitions As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterObjectID = New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
            SqlParameterShowOnlyCheckedDefinitions = New System.Data.SqlClient.SqlParameter("@SHOW_ONLY_CHECKED_DEFINITIONS", SqlDbType.Bit)

            SqlParameterObjectID.Value = ObjectID
            SqlParameterShowOnlyCheckedDefinitions.Value = ShowOnlyCheckedDefinitions

            Load = DbContext.Database.SqlQuery(Of Database.Classes.MyObjectDefinition)("EXEC dbo.usp_wv_MyObjectDef_LoadObjectDefinitions @OBJECT_ID, @SHOW_ONLY_CHECKED_DEFINITIONS",
                SqlParameterObjectID, SqlParameterShowOnlyCheckedDefinitions).ToList

        End Function

#End Region

    End Module

End Namespace
