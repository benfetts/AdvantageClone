Namespace Database.Procedures.NotifyTaskDataComplexType

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

        Public Function Load(DbContext As Database.DbContext,
                             OverdueTasks As Boolean,
                             UpcomingStart As Integer,
                             UpcomingEnd As Integer) As System.Collections.Generic.List(Of Database.Classes.NotifyTaskData)

            'objects
            Dim SqlParameterOverdueTasks As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUpcomingStart As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUpcomingEnd As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOverdueTasks = New System.Data.SqlClient.SqlParameter("@overdue_tasks", SqlDbType.Bit)
            SqlParameterUpcomingStart = New System.Data.SqlClient.SqlParameter("@upcoming_start", SqlDbType.Int)
            SqlParameterUpcomingEnd = New System.Data.SqlClient.SqlParameter("@upcoming_end", SqlDbType.Int)

            SqlParameterOverdueTasks.Value = If(OverdueTasks, 1, 0)
            SqlParameterUpcomingStart.Value = UpcomingStart
            SqlParameterUpcomingEnd.Value = UpcomingEnd

            Load = DbContext.Database.SqlQuery(Of Database.Classes.NotifyTaskData)("EXEC dbo.advsp_notify_tasks @overdue_tasks, @upcoming_start, @upcoming_end",
                SqlParameterOverdueTasks, SqlParameterUpcomingStart, SqlParameterUpcomingEnd).ToList

        End Function

#End Region

    End Module

End Namespace
