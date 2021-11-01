Namespace Database.Procedures.TrafficScheduleUserColumnComplexType

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

        Public Function Load(DbContext As Database.DbContext, HeaderCode As String, ShowAll As Boolean, IsSetup As Boolean, IsAddNew As Boolean) As System.Collections.Generic.List(Of Database.Classes.TrafficScheduleUserColumn)

            'objects
            Dim SqlParameterHeaderCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowAll As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsSetup As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsAddNew As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterHeaderCode = New System.Data.SqlClient.SqlParameter("@HDR_CODE", SqlDbType.VarChar)
            SqlParameterShowAll = New System.Data.SqlClient.SqlParameter("@SHOW_ALL", SqlDbType.Int)
            SqlParameterIsSetup = New System.Data.SqlClient.SqlParameter("@IS_SETUP", SqlDbType.Int)
            SqlParameterIsAddNew = New System.Data.SqlClient.SqlParameter("@IS_ADDNEW", SqlDbType.Int)

            SqlParameterHeaderCode.Value = HeaderCode
            SqlParameterShowAll.Value = If(ShowAll, -1, 0) ' -1 is correct for true!!
            SqlParameterIsSetup.Value = If(IsSetup, 1, 0)
            SqlParameterIsAddNew.Value = If(IsAddNew, 1, 0)

            Load = DbContext.Database.SqlQuery(Of Database.Classes.TrafficScheduleUserColumn)("EXEC dbo.usp_wv_Traffic_Schedule_GetScheduleUserColumns @HDR_CODE, @SHOW_ALL, @IS_SETUP, @IS_ADDNEW",
                SqlParameterHeaderCode, SqlParameterShowAll, SqlParameterIsSetup, SqlParameterIsAddNew).ToList

        End Function

#End Region

    End Module

End Namespace

