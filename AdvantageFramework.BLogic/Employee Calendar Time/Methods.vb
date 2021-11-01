Namespace EmployeeCalendarTime

    <HideModuleName()>
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

        Public Function LoadEmployeeTimeStaging(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String) As Generic.List(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging)

            Try

                Dim EmployeeCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", EmployeeCode)

                LoadEmployeeTimeStaging = DbContext.Database.SqlQuery(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging)("EXEC [dbo].[advsp_employee_timesheet_staging] @EMP_CODE", EmployeeCodeParameter).ToList

            Catch ex As Exception
                LoadEmployeeTimeStaging = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace