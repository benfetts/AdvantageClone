Imports System.Data
Imports System.Data.SqlClient
<Serializable()> Public Class cComments
    Dim mConnString As String
    Dim oSQL As SqlHelper
    Public Function GetTrafficDetailComments(ByVal RowID As System.Int32) As String
        Dim MyReturn As String

        Try
            'Create Stored Procedure Parameters
            Dim parameterRowID As New SqlParameter("@RowID", SqlDbType.Int, 0)
            parameterRowID.Value = RowID

            MyReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_comments_get_traffic_detail", parameterRowID)
        Catch
            Err.Raise(Err.Number, "Class:cComments Routine:GetTrafficDetailComments", Err.Description)
        End Try

        Return MyReturn

    End Function
    Public Function GetJobTrafficComments(ByVal RowID As System.Int32) As String
        Dim MyReturn As String

        Try

            'Create Stored Procedure Parameters
            Dim parameterRowID As New SqlParameter("@RowID", SqlDbType.Int, 0)
            parameterRowID.Value = RowID

            MyReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_comments_get_job_traffic", parameterRowID)
        Catch
            Err.Raise(Err.Number, "Class:cComments Routine:GetJobTrafficComments", Err.Description)
        End Try

        Return MyReturn

    End Function
    Public Function GetEmpTimeComments(ByVal TimeType As System.String, ByVal ETID As System.Int32, ByVal ETDTLID As System.Int16) As String
        Dim MyReturn As String
        Dim arParams(3) As SqlParameter

        Try

            'Create Stored Procedure Parameters
            Dim parameterETSource As New SqlParameter("@ETSource", SqlDbType.VarChar, 1)
            parameterETSource.Value = TimeType
            arParams(0) = parameterETSource
            Dim parameterETID As New SqlParameter("@ETID", SqlDbType.Int, 0)
            parameterETID.Value = ETID
            arParams(1) = parameterETID
            Dim parameterETDTLID As New SqlParameter("@ETDTLID", SqlDbType.SmallInt, 0)
            parameterETDTLID.Value = ETDTLID
            arParams(2) = parameterETDTLID

            MyReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_comments_get_emptime", arParams)
            Return MyReturn
        Catch
            'Err.Raise(Err.Number, "Class:cComments Routine:GetEmpTimeComments", Err.Description)
            Return ""
        End Try
    End Function
    Public Function GetTimeSheetApproveComments(ByVal EmpCode As String, ByVal EmpDate As Date) As String
        Dim MyReturn As String
        Dim arParams(2) As SqlParameter

        Try

            'Create Stored Procedure Parameters
            Dim parameter1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameter1.Value = EmpCode
            arParams(0) = parameter1
            Dim parameter2 As New SqlParameter("@EmpDate", SqlDbType.SmallDateTime)
            parameter2.Value = EmpDate
            arParams(1) = parameter2

            MyReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_comment_get_ts_approve", arParams).ToString
        Catch
            Err.Raise(Err.Number, "Class:cComments Routine:GetTimeSheetApproveComments", Err.Description)
        End Try

        Return MyReturn
    End Function

    Public Function GetSuperApprExpenseComment(ByVal InvNbr As Integer) As String
        Dim SQL_STRING, txt As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader

        txt = ""
        SQL_STRING = "SELECT DTL_DESC FROM EXPENSE_HEADER WHERE INV_NBR = " & CStr(InvNbr)

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cComments Routine:GetSuperApprExpenseComment", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            txt = dr.GetString(0)
        End If

        dr.Close()

        Return txt

    End Function

    Public Function SaveTrafficDetailComments(ByVal RowID As System.Int32, ByVal TaskComments As System.String) As Boolean
        Dim MyReturn As Integer
        Dim arParams(2) As SqlParameter

        Try

            'Create Stored Procedure Parameters
            Dim parameterRowID As New SqlParameter("@RowID", SqlDbType.Int, 0)
            parameterRowID.Value = RowID
            arParams(0) = parameterRowID
            Dim parameterTaskComments As New SqlParameter("@TaskComments", SqlDbType.NText, 1073741823)
            parameterTaskComments.Value = TaskComments
            arParams(1) = parameterTaskComments

            MyReturn = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_comments_update_traffic_detail", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cComments Routine:SaveTrafficDetailComments", Err.Description)
        End Try

        If MyReturn > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function SaveJobTrafficComments(ByVal RowID As System.Int32, ByVal TaskComments As System.String) As Boolean
        Dim MyReturn As Integer
        Dim arParams(2) As SqlParameter

        Try

            'Create Stored Procedure Parameters
            Dim parameterRowID As New SqlParameter("@RowID", SqlDbType.Int, 0)
            parameterRowID.Value = RowID
            arParams(0) = parameterRowID

            Dim parameterTaskComments As New SqlParameter("@Comments", SqlDbType.NText, 1073741823)
            parameterTaskComments.Value = TaskComments
            arParams(1) = parameterTaskComments

            MyReturn = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_comments_update_job_traffic", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cComments Routine:SaveJobTrafficComments", Err.Description)
        End Try

        If MyReturn > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function SaveEmpTimeComments(ByVal ETSource As System.String, ByVal ETID As System.Int32, ByVal ETDTLID As System.Int16, ByVal Comments As System.String, _
                                        Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim arParams(5) As SqlParameter
            Dim parameterETSource As New SqlParameter("@ETSource", SqlDbType.VarChar, 1)
            parameterETSource.Value = ETSource
            arParams(0) = parameterETSource
            Dim parameterETID As New SqlParameter("@ETID", SqlDbType.Int, 0)
            parameterETID.Value = ETID
            arParams(1) = parameterETID
            Dim parameterETDTLID As New SqlParameter("@ETDTLID", SqlDbType.SmallInt, 0)
            parameterETDTLID.Value = ETDTLID
            arParams(2) = parameterETDTLID
            Dim parameterComments As New SqlParameter("@Comments", SqlDbType.NText, 1073741823)
            parameterComments.Value = Comments
            arParams(3) = parameterComments

            Dim parameterReturnMessage As New SqlParameter("@ReturnMessage", SqlDbType.Bit)
            parameterReturnMessage.Value = True
            arParams(4) = parameterReturnMessage

            ErrorMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_comments_update_emptime", arParams)

        Catch ex As Exception

            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

        If ErrorMessage.IndexOf("SUCCESS") > 1 Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
End Class
