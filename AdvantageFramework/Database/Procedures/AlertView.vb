Namespace Database.Procedures.AlertView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AlertView)

            Load = From AlertView In DbContext.GetQuery(Of Database.Views.AlertView)
                   Select AlertView

        End Function

        Public Function LoadByAlertID(ByVal DbContext As Database.DbContext,
                                      ByVal AlertID As Integer) As AdvantageFramework.Email.Classes.Alert

            Dim Alert As AdvantageFramework.Email.Classes.Alert = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CDPContactIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SprintIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("AlertID", AlertID)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", "")
            CDPContactIDSqlParameter = New System.Data.SqlClient.SqlParameter("CDPContactID", 0)
            OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("Offset", 0)
            SprintIDSqlParameter = New System.Data.SqlClient.SqlParameter("SprintID", 0)

            Try

                Alert = DbContext.Database.SqlQuery(Of AdvantageFramework.Email.Classes.Alert)("EXEC [dbo].[advsp_alert_get] @AlertID, @EmployeeCode, @CDPContactID, @Offset, @SprintID",
                                                                                               AlertIDSqlParameter,
                                                                                               EmployeeCodeSqlParameter,
                                                                                               CDPContactIDSqlParameter,
                                                                                               OffsetSqlParameter,
                                                                                               SprintIDSqlParameter).SingleOrDefault

            Catch ex As Exception
                Alert = Nothing
            End Try

            Return Alert

            'LoadByAlertID = DbContext.Database.SqlQuery(Of AdvantageFramework.Email.Classes.Alert)(String.Format("", AlertID)).SingleOrDefault
            'Try

            '    Alert = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)("EXEC [dbo].[advsp_alert_get] @AlertID, @EmployeeCode, @CDPContactID, @Offset, @SprintID", AlertIDSqlParameter, EmployeeCodeSqlParameter, CDPContactIDSqlParameter, OffsetSqlParameter, SprintIDSqlParameter).SingleOrDefault

            'Catch ex As Exception
            '    LoadByAlertID = Nothing
            'End Try

        End Function

#End Region

    End Module

End Namespace
