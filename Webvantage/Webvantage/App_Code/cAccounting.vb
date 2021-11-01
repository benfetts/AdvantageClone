' THIS COMMENT IS A TEST OF SOURCESAFE
Imports System.Data
Imports System.Data.SqlClient
<Serializable()> Public Class cAccounting
    Dim oSQL As SqlHelper
    Dim mConnString As String
    Public Function GetPostingPeriods() As SqlDataReader
        Return oSQL.ExecuteReader(mConnString, CommandType.Text, "SELECT PPPERIOD FROM POSTPERIOD")
    End Function

    Public Function GetPostingPeriodMax() As String
        Return oSQL.ExecuteScalar(mConnString, CommandType.Text, "SELECT MAX(PPPERIOD) FROM POSTPERIOD WHERE PPGLMONTH <> 99")
    End Function

    Public Function GetCurrentPostingPeriod() As String
        ' Create parameter for stored procedure
        Dim parameterPostPeriod As New SqlParameter("@PostPeriod", SqlDbType.VarChar, 6)
        parameterPostPeriod.Direction = ParameterDirection.Output

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_App_Get_CurrentPostPeriod", parameterPostPeriod)
            Return parameterPostPeriod.Value
        Catch
            Return ""
        End Try


    End Function


    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
End Class
