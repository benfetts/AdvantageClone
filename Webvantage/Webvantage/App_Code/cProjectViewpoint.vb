Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web

Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports Microsoft.VisualBasic

<Serializable()> Public Class cProjectViewpoint
    Private mConnString As String
    Private mUserID As String
    Private mEmpCode As String
    Private oSQL As SqlHelper

    Public Function getCDPDescriptions(ByVal cl As String, ByVal div As String, ByVal prd As String) As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim cl_desc, div_desc, prd_desc As String

        'Get Client description
        SQL_STRING = "SELECT CL_NAME FROM CLIENT WHERE CL_CODE = '" & cl & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(mConnString), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getCDPDescriptions", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            cl_desc = dr.GetString(0)
        End If

        dr.Close()

        'Get Division description
        SQL_STRING = "SELECT DIV_NAME FROM DIVISION WHERE CL_CODE = '" & cl & "' AND DIV_CODE = '" & div & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(mConnString), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getCDPDescriptions", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            div_desc = dr.GetString(0)
        End If

        dr.Close()

        'Get Product description
        SQL_STRING = "SELECT PRD_DESCRIPTION FROM PRODUCT WHERE CL_CODE = '" & cl & "' AND DIV_CODE = '" & div & "' AND PRD_CODE = '" & prd & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(mConnString), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getCDPDescriptions", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            prd_desc = dr.GetString(0)
        End If

        dr.Close()

        Return cl_desc & "/br" & div_desc & "/br" & prd_desc


    End Function

    Public Function getBudgetViewpoint(ByVal GroupLevel As Integer) As SqlDataReader
        '@GroupLevel	INTEGER,		--> 1-All	2-Type	3-Sales Class

        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter


        Dim parameterGroupLevel As New SqlParameter("@GroupLevel", SqlDbType.Int)
        parameterGroupLevel.Value = GroupLevel
        arParams(0) = parameterGroupLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = mUserID
        arParams(1) = parameterUserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_budget_viewpoint", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getbudgetViewpoint", Err.Description)
        End Try

        Return dr

    End Function

    Public Function getBudgetViewpointDS(ByVal GroupLevel As Integer)
        '@GroupLevel	INTEGER,		--> 1-All	2-Type	3-Sales Class

        Dim ds As DataSet
        Dim arParams(4) As SqlParameter


        Dim parameterGroupLevel As New SqlParameter("@GroupLevel", SqlDbType.Int)
        parameterGroupLevel.Value = GroupLevel
        arParams(0) = parameterGroupLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = mUserID
        arParams(1) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_get_budget_viewpoint", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getbudgetViewpoint", Err.Description)
        End Try

        Return ds

    End Function

    Public Function getHoursViewpoint(ByVal groupLevel As String) As SqlDataReader
        '@GroupLevel	char(1),		--> 0-none; 1-Function; 2-Job/Comp; 3-Employee

        Dim YN As String
        Dim dr As SqlDataReader
        Dim arParams(2) As SqlParameter
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, mUserID, mEmpCode)

        appVars.getAllAppVars()

        Dim parameterGroupLevel As New SqlParameter("@grp_level", SqlDbType.Char)
        parameterGroupLevel.Value = groupLevel
        arParams(0) = parameterGroupLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = mUserID
        arParams(1) = parameterUserID

        YN = BoolToYN(CType(appVars.getAppVar("PVInclClosedJobs", "Boolean", "False"), Boolean))
        Dim parameterClosedJobs As New SqlParameter("@ClosedJobs", SqlDbType.VarChar, 1)
        parameterClosedJobs.Value = YN
        arParams(2) = parameterClosedJobs

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_hours_viewpoint", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getHoursViewpoint", Err.Description)
        End Try

        Return dr
    End Function

    Public Function getHoursViewpointDS(ByVal groupLevel As String)
        '@GroupLevel	char(1),		--> 0-none; 1-Function; 2-Job/Comp; 3-Employee

        Dim YN As String
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, mUserID, mEmpCode)
        appVars.getAllAppVars()

        Dim parameterGroupLevel As New SqlParameter("@grp_level", SqlDbType.Char)
        parameterGroupLevel.Value = groupLevel
        arParams(0) = parameterGroupLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = mUserID
        arParams(1) = parameterUserID

        YN = BoolToYN(CType(appVars.getAppVar("PVInclClosedJobs", "Boolean", "False"), Boolean))
        Dim parameterClosedJobs As New SqlParameter("@ClosedJobs", SqlDbType.VarChar, 1)
        parameterClosedJobs.Value = YN
        arParams(2) = parameterClosedJobs

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_dto_hours_viewpoint", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getHoursViewpoint", Err.Description)
        End Try

        Return ds
    End Function

    Public Function GetAEList(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal userId As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = userId
        arParams(3) = parameterUserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getAEList", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetAEList", Err.Description)
        End Try

        Return dr
    End Function

    Public Function getPVList(ByVal ae As String, ByVal cdpSelection As String, ByVal startDate As String,
                              ByVal endDate As String, ByVal closedJobs As String,
                              ByVal myProjects As String, ByVal ExcludeJobsWithCompletedSchedules As Boolean,
                              ByVal PageIndex As Integer, ByVal PageSize As Integer, Optional ByVal AsCount As Boolean = False) As DataTable

        Dim dr As SqlDataReader
        Dim arParams(12) As SqlParameter

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.Char, 1)
        parameterAE.Value = ae
        arParams(0) = parameterAE

        Dim parameterCDPSelection As New SqlParameter("@cdp_selection", SqlDbType.Char, 1)
        parameterCDPSelection.Value = cdpSelection
        arParams(1) = parameterCDPSelection

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.VarChar, 12)
        parameterStartDate.Value = startDate
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.VarChar, 12)
        parameterEndDate.Value = endDate
        arParams(3) = parameterEndDate

        Dim parameterClosedJobs As New SqlParameter("@closed_jobs", SqlDbType.Char, 1)
        parameterClosedJobs.Value = closedJobs
        arParams(4) = parameterClosedJobs

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = mUserID
        arParams(5) = parameterUserID

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = mEmpCode
        arParams(6) = parameterEmpCode

        Dim parameterMyProjects As New SqlParameter("@myProjects", SqlDbType.Char, 1)
        parameterMyProjects.Value = myProjects
        arParams(7) = parameterMyProjects

        Dim parameterExcludeJobsWithCompletedSchedules As New SqlParameter("@EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES", SqlDbType.Bit)
        parameterExcludeJobsWithCompletedSchedules.Value = ExcludeJobsWithCompletedSchedules
        arParams(8) = parameterExcludeJobsWithCompletedSchedules

        Dim parameterPageIndex As New SqlParameter("@PAGE_IDX", SqlDbType.Int)
        parameterPageIndex.Value = PageIndex
        arParams(9) = parameterPageIndex

        Dim parameterPageSize As New SqlParameter("@PAGE_SIZE", SqlDbType.Int)
        parameterPageSize.Value = PageSize
        arParams(10) = parameterPageSize

        Dim parameterAsCount As New SqlParameter("@AS_COUNT", SqlDbType.Int)
        parameterAsCount.Value = AsCount
        arParams(11) = parameterAsCount

        'Dim parameterpageindex As New SqlParameter("@pageindex", SqlDbType.Int)
        'parameterpageindex.Value = pageindex
        'arParams(8) = parameterpageindex

        'Dim parametergridsize As New SqlParameter("@gridsize", SqlDbType.Int)
        'parametergridsize.Value = gridsize
        'arParams(9) = parametergridsize


        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_project_view", "dtPV", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getPVList", Err.Description)
        End Try


    End Function

    Public Function getPVListCP(ByVal ae As String, ByVal cdpSelection As String, ByVal startDate As String, ByVal endDate As String, ByVal closedJobs As String, ByVal myProjects As String, ByVal cpid As Integer, ByVal ExcludeJobsWithCompletedSchedules As Boolean) As DataTable
        Dim dr As SqlDataReader
        Dim arParams(10) As SqlParameter

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.Char, 1)
        parameterAE.Value = ae
        arParams(0) = parameterAE

        Dim parameterCDPSelection As New SqlParameter("@cdp_selection", SqlDbType.Char, 1)
        parameterCDPSelection.Value = cdpSelection
        arParams(1) = parameterCDPSelection

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.VarChar, 12)
        parameterStartDate.Value = startDate
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.VarChar, 12)
        parameterEndDate.Value = endDate
        arParams(3) = parameterEndDate

        Dim parameterClosedJobs As New SqlParameter("@closed_jobs", SqlDbType.Char, 1)
        parameterClosedJobs.Value = closedJobs
        arParams(4) = parameterClosedJobs

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = mUserID
        arParams(5) = parameterUserID

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = mEmpCode
        arParams(6) = parameterEmpCode

        Dim parameterMyProjects As New SqlParameter("@myProjects", SqlDbType.Char, 1)
        parameterMyProjects.Value = myProjects
        arParams(7) = parameterMyProjects

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = cpid
        arParams(8) = parameterCPID

        Dim parameterExcludeJobsWithCompletedSchedules As New SqlParameter("@EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES", SqlDbType.Bit)
        parameterExcludeJobsWithCompletedSchedules.Value = ExcludeJobsWithCompletedSchedules
        arParams(9) = parameterExcludeJobsWithCompletedSchedules


        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_cp_dto_project_view", "dtPV", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:getPVListCP", Err.Description)
        End Try


    End Function

    Public Function refreshData(ByVal startPP As String, ByVal endPP As String) As Integer
        Dim arParams(1) As SqlParameter

        Dim parameterStartDate As New SqlParameter("@period1", SqlDbType.VarChar, 6)
        parameterStartDate.Value = startPP
        arParams(0) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@period2", SqlDbType.VarChar, 6)
        parameterEndDate.Value = endPP
        arParams(1) = parameterEndDate

        Try
            Return oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "advsp_collect_actuals", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cProjectViewpoint Routine:refreshData", Err.Description)
        End Try

    End Function

    Public Function GetPVQvA(ByVal job As Int32, ByVal comp As Int16, ByVal TimeOnly As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim jobStr, compStr As String

        Try
            Dim arParams(3) As SqlParameter
            jobStr = CType(job, String)
            compStr = CType(comp, String)

            Dim paramJob As New SqlParameter("@job", SqlDbType.VarChar)
            paramJob.Value = jobStr
            arParams(0) = paramJob

            Dim paramComp As New SqlParameter("@comp", SqlDbType.VarChar)
            paramComp.Value = compStr
            arParams(1) = paramComp

            Dim parameterTimeOnly As New SqlParameter("@TimeOnly", SqlDbType.Char, 1)
            If TimeOnly = "True" Then
                parameterTimeOnly.Value = "E"
            Else
                parameterTimeOnly.Value = ""
            End If
            arParams(2) = parameterTimeOnly

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = mUserID
            arParams(3) = parameterUserID

            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_PVqva", arParams)
            Return dr
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetPVQvA!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Private Function BoolToYN(ByVal input As Boolean) As String
        If input = True Then
            Return "Y"
        Else
            Return "N"
        End If
    End Function

    Public Sub New(Optional ByVal UserID As String = "", Optional ByVal EmpCode As String = "")
        mConnString = HttpContext.Current.Session("ConnString")
        If UserID <> "" Then
            mUserID = UserID
        Else
            mUserID = HttpContext.Current.Session("UserCode")
        End If
        If EmpCode <> "" Then
            mEmpCode = EmpCode
        Else
            mEmpCode = HttpContext.Current.Session("EmpCode")
        End If
    End Sub

    'Public Function getAppVars(ByVal VariableName As String) As String
    '    '******************************************************************************
    '    '*** PLEASE USE cAppVars.getAppVars function instead of this one
    '    '******************************************************************************
    '    '***
    '    Dim value As String = ""
    '    Dim SbSQL As New System.Text.StringBuilder
    '    Dim StrSQL As String = ""
    '    Dim dr As SqlDataReader
    '    Dim oSQL As SqlHelper

    '    With SbSQL
    '        .Append("SELECT ISNULL(VARIABLE_VALUE,'') FROM APP_VARS WHERE USERID = '")
    '        .Append(mUserID)
    '        .Append("' AND APPLICATION = 'PROJECTVIEWPOINT'")
    '        .Append(" AND VARIABLE_NAME = '")
    '        .Append(VariableName)
    '        .Append("';")
    '    End With

    '    StrSQL = SbSQL.ToString()

    '    Try
    '        dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
    '    Catch
    '        Err.Raise(Err.Number, "Class:dt_ProjectViewpointMultiview.ascx Routine:getAppVars", Err.Description)
    '    Finally
    '    End Try

    '    If dr.HasRows Then
    '        dr.Read()
    '        value = dr.GetString(0)
    '    Else
    '        value = ""
    '    End If

    '    Return value

    'End Function

    'Public Function getAppVarsbyGroup(ByVal VariableGroup As String) As SqlDataReader
    '    Dim SbSQL As New System.Text.StringBuilder
    '    Dim StrSQL As String = ""
    '    Dim dr As SqlDataReader
    '    Dim oSQL As SqlHelper

    '    With SbSQL
    '        .Append("SELECT ISNULL(VARIABLE_VALUE,'') FROM APP_VARS WHERE USERID = '")
    '        .Append(mUserID)
    '        .Append("' AND APPLICATION = 'PROJECTVIEWPOINT'")
    '        .Append(" AND VARIABLE_GROUP = '")
    '        .Append(VariableGroup)
    '        .Append("';")
    '    End With

    '    StrSQL = SbSQL.ToString()

    '    Try
    '        dr = oSQL.ExecuteReader(mConnString, CommandType.Text, StrSQL)
    '    Catch
    '        Err.Raise(Err.Number, "Class:dt_ProjectViewpointMultiview.ascx Routine:getAppVarsbyGroup", Err.Description)
    '    Finally
    '    End Try

    '    Return dr

    'End Function

    'Public Function setAppVars(ByVal VariableName As String, ByVal varType As String, ByVal varValue As String) As String
    '    Try
    '        Dim SbSQL As New System.Text.StringBuilder
    '        Dim SbSQLDelete As New System.Text.StringBuilder
    '        Dim StrSQL As String = ""

    '        ' clear out existing data first:
    '        With SbSQLDelete
    '            .Append("DELETE FROM APP_VARS WITH(ROWLOCK) WHERE USERID = '")
    '            .Append(mUserID)
    '            .Append("' AND APPLICATION = 'PROJECTVIEWPOINT'")
    '            .Append(" AND VARIABLE_NAME = '")
    '            .Append(VariableName)
    '            .Append("';")
    '        End With

    '        StrSQL = SbSQLDelete.ToString()

    '        'Save:
    '        If StrSQL.Trim() <> "" Then
    '            Using MyConn As New SqlConnection(mConnString)
    '                MyConn.Open()
    '                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
    '                Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
    '                Try
    '                    MyCmd.ExecuteNonQuery()
    '                    MyTrans.Commit()
    '                Catch ex As Exception
    '                    MyTrans.Rollback()
    '                    Return "Error running selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()
    '                Finally
    '                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
    '                End Try
    '            End Using
    '        End If

    '        StrSQL = ""

    '        With SbSQL
    '            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES ('")
    '            .Append(mUserID)
    '            .Append("','PROJECTVIEWPOINT','0','")
    '            .Append(VariableName)
    '            .Append("','")
    '            .Append(varType)
    '            .Append("','")
    '            .Append(varValue)
    '            .Append("');")
    '        End With

    '        StrSQL = SbSQL.ToString()

    '        'Save:
    '        If StrSQL.Trim() <> "" Then
    '            Using MyConn As New SqlConnection(mConnString)
    '                MyConn.Open()
    '                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
    '                Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
    '                Try
    '                    MyCmd.ExecuteNonQuery()
    '                    MyTrans.Commit()
    '                Catch ex As Exception
    '                    MyTrans.Rollback()
    '                    Return "Error running selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()
    '                Finally
    '                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
    '                End Try
    '            End Using
    '        End If

    '        Return ""

    '    Catch ex As Exception
    '        Return "Error saving " & VariableName & ":&nbsp;&nbsp;" & ex.Message.ToString()
    '    End Try
    'End Function

    Public Function getForecastOption() As String
        Dim forcastInx, forcastValue As String
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, mUserID)
        appVars.getAllAppVars()

        forcastInx = appVars.getAppVar("PVForecast", "Number")

        Select Case forcastInx
            Case "0"
                forcastValue = "Actual Billed"
            Case "1"
                forcastValue = "Actual Posted"
            Case "2"
                forcastValue = "Forecasted - Approved Billing & Actual Media Posted"
            Case "3"
                forcastValue = "Forecasted - Approved Estimate By Approved Date & Actual Media Posted"
            Case "4"
                forcastValue = "Forecasted - Approved Estimate By Job Due Date & Actual Media Posted"
        End Select

        Return forcastValue

    End Function

End Class


