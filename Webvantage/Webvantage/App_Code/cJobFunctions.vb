Imports System.Data
Imports System.Data.SqlClient
<Serializable()> Public Class cJobFunctions
    Dim mConnString As String
    Dim oSQL As SqlHelper
    Public Function GetCliDivProdFromJob(ByVal Job As Integer, ByVal JobComp As Integer, ByRef Client As String, ByRef Division As String, ByRef Product As String) As Boolean
        Dim arParams(6) As SqlParameter

        ' Add Parameters to SPROC
        Dim parameterJob As New SqlParameter("@Job", SqlDbType.Int, 0)
        parameterJob.Value = Job
        arParams(0) = parameterJob

        ' Add Parameters to SPROC
        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int, 0)
        parameterJobComp.Value = JobComp
        arParams(1) = parameterJobComp

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClient.Direction = ParameterDirection.Output
        arParams(2) = parameterClient

        Dim parameterDiv As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDiv.Direction = ParameterDirection.Output
        arParams(3) = parameterDiv

        Dim parameterProd As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProd.Direction = ParameterDirection.Output
        arParams(4) = parameterProd

        Dim parameterRowCount As New SqlParameter("@RowCount", SqlDbType.Int, 0)
        parameterRowCount.Direction = ParameterDirection.Output
        arParams(5) = parameterRowCount

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Job_GetCliDivProd", arParams)
        Catch
            Client = ""
            Division = ""
            Product = ""
            'Err.Raise(Err.Number, Err.Source, Err.Description)
        End Try

        If parameterRowCount.Value > 0 Then
            Client = parameterClient.Value
            Division = parameterDiv.Value
            Product = parameterProd.Value
            Return True
        Else
            Return False
        End If

    End Function

    Public Function IsJobOpen(ByVal Job As Integer, ByVal JobComp As Integer) As Boolean
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper

        SQL_STRING = " SELECT JOB_NUMBER, JOB_COMPONENT_NBR "
        SQL_STRING += " FROM(JOB_COMPONENT)"
        SQL_STRING += " WHERE JOB_COMPONENT.JOB_NUMBER = " & Job & " AND JOB_COMPONENT.JOB_COMPONENT_NBR = " & JobComp
        SQL_STRING += " AND JOB_PROCESS_CONTRL NOT IN (6,12) "

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cJobFunctions.vb Routine:LoadCurrentStatus", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function IsJobExpensible(ByVal Job As Integer, ByVal JobComp As Integer) As Boolean
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper

        SQL_STRING = " SELECT JOB_NUMBER, JOB_COMPONENT_NBR "
        SQL_STRING += " FROM JOB_COMPONENT "
        SQL_STRING += " WHERE JOB_COMPONENT.JOB_NUMBER = " & Job & " AND JOB_COMPONENT.JOB_COMPONENT_NBR = " & JobComp
        SQL_STRING += " AND JOB_PROCESS_CONTRL NOT IN (2,5,6,7,10,11,12) "

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cJobFunctions.vb Routine:LoadCurrentStatus", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function IsJobBillable(ByVal emp_code As String, ByVal fnc_code As String, ByVal Client As String, ByVal Division As String, ByVal Product As String, ByVal Job As Integer, ByVal JobComp As Integer) As Boolean
        Dim arParams(23) As SqlParameter
        Dim billable As Integer

        Dim parameterEmp As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
        parameterEmp.Value = emp_code
        arParams(0) = parameterEmp

        Dim parameterEffDate As New SqlParameter("@eff_date", SqlDbType.DateTime, 0)
        parameterEffDate.Value = Date.Today
        arParams(1) = parameterEffDate

        Dim parameterFnc As New SqlParameter("@fnc_code", SqlDbType.VarChar, 6)
        parameterFnc.Value = fnc_code
        arParams(2) = parameterFnc

        Dim parameterClient As New SqlParameter("@cl_code", SqlDbType.VarChar, 6)
        parameterClient.Value = Client
        arParams(3) = parameterClient

        Dim parameterDiv As New SqlParameter("@div_code", SqlDbType.VarChar, 6)
        parameterDiv.Value = Division
        arParams(4) = parameterDiv

        Dim parameterProd As New SqlParameter("@prd_code", SqlDbType.VarChar, 6)
        parameterProd.Value = Product
        arParams(5) = parameterProd

        Dim parameterSC As New SqlParameter("@sc_code", SqlDbType.VarChar, 6)
        parameterSC.Value = ""
        arParams(6) = parameterSC

        Dim parameterFncType As New SqlParameter("@fnc_type", SqlDbType.VarChar, 1)
        parameterFncType.Value = "V"
        arParams(7) = parameterFncType

        Dim parameterJob As New SqlParameter("@job_number", SqlDbType.Int, 0)
        parameterJob.Value = Job
        arParams(8) = parameterJob

        Dim parameterJobComp As New SqlParameter("@job_component_nbr", SqlDbType.Int, 0)
        parameterJobComp.Value = JobComp
        arParams(9) = parameterJobComp

        


        '@billing_rate decimal(9,2) OUTPUT
        Dim parameterbillrate As New SqlParameter("@billing_rate", SqlDbType.Decimal, 9)
        parameterbillrate.Direction = ParameterDirection.Output
        arParams(10) = parameterbillrate


        '@rate_level smallint OUTPUT, 
        Dim parameterratelevel As New SqlParameter("@rate_level", SqlDbType.Int, 0)
        parameterratelevel.Direction = ParameterDirection.Output
        arParams(11) = parameterratelevel

        '@tax_code varchar(4) OUTPUT, 
        Dim parametertaxcode As New SqlParameter("@tax_code", SqlDbType.VarChar, 4)
        parametertaxcode.Direction = ParameterDirection.Output
        arParams(12) = parametertaxcode

        '@tax_level smallint OUTPUT, 
        Dim parametertaxlevel As New SqlParameter("@tax_level", SqlDbType.Int, 0)
        parametertaxlevel.Direction = ParameterDirection.Output
        arParams(13) = parametertaxlevel

        '@nobill_flag smallint OUTPUT, 
        Dim parameternobill As New SqlParameter("@nobill_flag", SqlDbType.Int, 0)
        parameternobill.Direction = ParameterDirection.Output
        arParams(14) = parameternobill

        '@nobill_level smallint OUTPUT, 
        Dim parameternobilllevel As New SqlParameter("@nobill_level", SqlDbType.Int, 0)
        parameternobilllevel.Direction = ParameterDirection.Output
        arParams(15) = parameternobilllevel

        '@comm decimal(9,3) OUTPUT, 
        Dim parametercomm As New SqlParameter("@comm", SqlDbType.Decimal, 9)
        parametercomm.Direction = ParameterDirection.Output
        arParams(16) = parametercomm

        '@comm_level smallint OUTPUT, 
        Dim parametercomm_level As New SqlParameter("@comm_level", SqlDbType.Int, 0)
        parametercomm_level.Direction = ParameterDirection.Output
        arParams(17) = parametercomm_level

        '@tax_comm smallint OUTPUT, 
        Dim parametertax_comm As New SqlParameter("@tax_comm", SqlDbType.Int, 0)
        parametertax_comm.Direction = ParameterDirection.Output
        arParams(18) = parametertax_comm

        '@tax_comm_only smallint OUTPUT, 
        Dim parametertax_comm_only As New SqlParameter("@tax_comm_only", SqlDbType.Int, 0)
        parametertax_comm_only.Direction = ParameterDirection.Output
        arParams(19) = parametertax_comm_only

        '@tax_comm_flags_level smallint OUTPUT, 
        Dim parametertax_comm_flags_level As New SqlParameter("@tax_comm_flags_level", SqlDbType.Int, 0)
        parametertax_comm_flags_level.Direction = ParameterDirection.Output
        arParams(20) = parametertax_comm_flags_level

        '@fee_time_flag smallint OUTPUT, 
        Dim parameterfee_time_flag As New SqlParameter("@fee_time_flag", SqlDbType.Int, 0)
        parameterfee_time_flag.Direction = ParameterDirection.Output
        arParams(21) = parameterfee_time_flag

        '@fee_time_level smallint OUTPUT
        Dim parameterfee_time_level As New SqlParameter("@fee_time_level", SqlDbType.Int, 0)
        parameterfee_time_level.Direction = ParameterDirection.Output
        arParams(22) = parameterfee_time_level


        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "sp_get_billing_rates", arParams)
        Catch
            Err.Raise(9999, "Class:cJobFunctions Routine:IsJobBillable", Err.Description)
        End Try

        If parameternobill.Value = 1 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function GetCDPContactID(ByVal StrContCode As String, ByVal StrCliCode As String) As Integer
        Try
            Dim SbSQL As New System.Text.StringBuilder
            With SbSQL
                .Append("SELECT ")
                .Append("CASE ")
                .Append("	WHEN COUNT(1) = 0 THEN -1 ")
                .Append("	WHEN COUNT(1) > 0 THEN (SELECT TOP 1 CDP_CONTACT_ID FROM CDP_CONTACT_HDR WITH(NOLOCK) WHERE (CONT_CODE = @CONT_CODE) AND (CL_CODE = @CL_CODE)) ")
                .Append("END AS CDP_CONTACT_ID ")
                .Append("FROM CDP_CONTACT_HDR WITH(NOLOCK) ")
                .Append("WHERE (CONT_CODE = @CONT_CODE) AND (CL_CODE = @CL_CODE);")
            End With
            Using MyConn As New SqlConnection(mConnString)
                MyConn.Open()
                Dim MyCmd As New SqlCommand(SbSQL.ToString(), MyConn)
                With MyCmd.Parameters
                    Dim ParamCONT_CODE As New SqlParameter("@CONT_CODE", SqlDbType.VarChar, 6)
                    ParamCONT_CODE.Value = StrContCode
                    .Add(ParamCONT_CODE)
                    Dim ParamCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                    ParamCL_CODE.Value = StrCliCode
                    .Add(ParamCL_CODE)
                End With
                Try
                    Dim r As String
                    r = MyCmd.ExecuteScalar()
                    If IsNumeric(r) Then
                        Return CType(r, Integer)
                    Else
                        Return -1
                    End If
                Catch ex As Exception
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
        Catch ex As Exception
        End Try
    End Function

    Public Sub New(Optional ByVal ConnectionString As String = "")
        If ConnectionString = "" Then
            mConnString = HttpContext.Current.Session("ConnString")
        Else
            mConnString = ConnectionString
        End If
    End Sub
End Class
