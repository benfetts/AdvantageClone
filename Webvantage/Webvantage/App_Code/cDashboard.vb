Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Text
Imports System.Collections.Generic

<Serializable()> Public Class cDashboard
    Private mConnString As String
    Private mUserID As String
    Private oSQL As SqlHelper

    Public Sub New(ByVal ConnectionString As String, ByVal UserID As String)
        mConnString = ConnectionString
        mUserID = UserID
    End Sub

#Region "Selection "

    Public Function GetData()
        Dim dt As DataTable
        Dim arParams(5) As SqlParameter

        Dim parameter1 As New SqlParameter("@sel_dp_tm_opt", SqlDbType.Int)
        parameter1.Value = 1
        arParams(0) = parameter1
        Dim parameter2 As New SqlParameter("@dp_tm_opt", SqlDbType.Int)
        parameter2.Value = 1
        arParams(1) = parameter2
        Dim parameter3 As New SqlParameter("@dp_tm_list", SqlDbType.VarChar, 6)
        parameter3.Value = ""
        arParams(2) = parameter3
        Dim parameter4 As New SqlParameter("@start_period", SqlDbType.Int)
        parameter4.Value = 200801
        arParams(3) = parameter4
        Dim parameter5 As New SqlParameter("@end_period", SqlDbType.Int)
        parameter5.Value = 200812
        arParams(4) = parameter5

        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "advsp_employee_time_util", "table", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetData", Err.Description)
        End Try
        Return dt
    End Function

    Public Function GetDepts(ByVal officecode As String, ByVal userid As String)
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar)
        parameterOfficeCode.Value = officecode
        arParams(0) = parameterOfficeCode

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(1) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDepts", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDepts", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetEmps(ByVal deptcode As String, ByVal officecode As String, ByVal includeemp As Boolean, ByVal filter As String, ByVal userid As String)
        Dim ds As DataSet
        Dim arParams(5) As SqlParameter

        Dim parameterDeptCode As New SqlParameter("@DeptCode", SqlDbType.VarChar)
        parameterDeptCode.Value = deptcode
        arParams(0) = parameterDeptCode

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar)
        parameterOfficeCode.Value = officecode
        arParams(1) = parameterOfficeCode

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(2) = parameterInclude

        Dim parameterFilter As New SqlParameter("@Filter", SqlDbType.VarChar)
        parameterFilter.Value = filter
        arParams(3) = parameterFilter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(4) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetEmps", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetEmps", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetOffices(ByVal userid As String)
        Dim ds As DataSet
        Dim arParams(1) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(0) = parameterUserID
        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetOffices", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetOffices", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDeptData(ByVal officecode As String, ByVal month As String, ByVal year As String, ByVal deptcode As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(5) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime
        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If


        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar)
        parameterOfficeCode.Value = officecode
        arParams(0) = parameterOfficeCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterDeptCode As New SqlParameter("@DeptCode", SqlDbType.VarChar)
        parameterDeptCode.Value = deptcode
        arParams(3) = parameterDeptCode

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(4) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDeptData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDeptData", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetEmpData(ByVal deptcode As String)
        Dim ds As DataSet
        Dim arParams(1) As SqlParameter

        Dim parameterDeptCode As New SqlParameter("@DeptCode", SqlDbType.VarChar)
        parameterDeptCode.Value = deptcode
        arParams(0) = parameterDeptCode
        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetEmpData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetEmpData", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetOfficeData(ByVal officecode As String, ByVal month As String, ByVal year As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If


        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar)
        parameterOfficeCode.Value = officecode
        arParams(0) = parameterOfficeCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(3) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetOfficeData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetOfficeData", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetTime()
        Dim ds As String
        Try
            ds = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetUpdateTime")
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetUpdateTime", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetPostPeriods(ByVal year As String)
        Try
            Dim ds As DataSet
            Dim arParams(2) As SqlParameter
            Dim startdate As String
            'If startdate = Now.Date.Year Then
            '    startdate = Now.Date.ToShortDateString
            'Else
            '    startdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & Now.Date.Year
            'End If
            Dim ly As Boolean = Date.IsLeapYear(year)
            If ly = False Then
                If Now.Date.Month = 2 And Now.Date.Day = 29 Then
                    startdate = Now.Date.Month.ToString() & "/" & Now.Date.AddDays(-1).Day.ToString & "/" & year
                Else
                    startdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & year
                End If
            Else
                startdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & year
            End If


            Dim parameterStartDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
            parameterStartDate.Value = startdate
            arParams(0) = parameterStartDate

            Dim parameterYear As New SqlParameter("@CurrentYear", SqlDbType.Int)
            parameterYear.Value = CInt(year)
            arParams(1) = parameterYear

            Try
                ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetPostPeriods", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cDashboard Routine:GetPostPeriods", Err.Description)
            End Try
            Return ds
        Catch ex As Exception

        End Try
    End Function

    Public Function GetYearDescriptions()
        Try
            Dim dt As DataTable
            Try
                dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetYearDescriptions", "dt")
            Catch
                Err.Raise(Err.Number, "Class:cDashboard Routine:GetYearDescriptions", Err.Description)
            End Try
            Return dt
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region "Production "

    Public Function GetDataRefresh(ByVal year1 As String, ByVal year2 As String, ByVal userid As String)
        Dim ds As DataSet
        Dim arParams(3) As SqlParameter

        Dim parameterStart As New SqlParameter("@Start", SqlDbType.Int)
        parameterStart.Value = CInt(year1)
        arParams(0) = parameterStart

        Dim parameterEnd As New SqlParameter("@End", SqlDbType.Int)
        parameterEnd.Value = CInt(year2)
        arParams(1) = parameterEnd

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(2) = parameterUserID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetData", arParams)
            Return True
        Catch
            Return False
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetData", Err.Description)
        End Try
        Return True
    End Function

    Public Function GetNonDirectHours(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(6) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(5) = parameterUserID


        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetNonDirectHours", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetNonDirectHours", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursWithTotal(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal userid As String, ByVal office As String, ByVal dept As String, ByVal includeemp As Boolean, ByVal yearValue As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(11) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(4) = parameterUserID

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(5) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(6) = parameterDept

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(7) = parameterInclude

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(8) = parameterMonth

        Dim currentdate As String
        currentdate = Now.Date.ToShortDateString

        Dim parameterCurrentDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
        parameterCurrentDate.Value = currentdate
        arParams(9) = parameterCurrentDate

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(10) = parameterYearValue

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursWithTotal", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursWithTotal", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetNonDirectHoursWithTotal(ByVal empcode As String)
        Dim ds As DataSet
        Dim arParams(1) As SqlParameter

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode
        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetNonDirectHoursWithTotal", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetNonDirectHoursWithTotal", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursWithNonBillable(ByVal empcode As String)
        Dim ds As DataSet
        Dim arParams(1) As SqlParameter

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode
        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursWithNonBillable", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursWithNonBillable", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursWithBillable(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(7) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(6) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursWithBillable", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursWithBillable", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetRequiredHoursWithTotal(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal userid As String, ByVal office As String, ByVal dept As String, ByVal includeemp As Boolean, ByVal yearValue As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(11) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(4) = parameterUserID

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(5) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(6) = parameterDept

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(7) = parameterInclude

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(8) = parameterMonth

        Dim currentdate As String
        currentdate = Now.Date.ToShortDateString

        Dim parameterCurrentDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
        parameterCurrentDate.Value = currentdate
        arParams(9) = parameterCurrentDate

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(10) = parameterYearValue

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetRequiredHoursWithTotal", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetRequiredHoursWithTotal", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetGoalHoursWithBillable(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal includeemp As Boolean, ByVal office As String, ByVal dept As String, ByVal yearValue As String, ByVal userid As String, Optional ByVal month2 As String = "", Optional ByVal monthcount As Integer = 0)
        Dim ds As DataSet
        Dim arParams(10) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" And month2 <> "" Then
            parameterMonth.Value = monthcount
        ElseIf month <> "" And month2 = "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(4) = parameterMonth

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(5) = parameterInclude

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(6) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(8) = parameterYearValue

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(9) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetGoalHoursWithBillable", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetGoalHoursWithBillable", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursByClient(ByVal empcode As String, ByVal month As String, ByVal year As String)
        Dim ds As DataSet
        Dim arParams(3) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        GetPPDates(month, year, startdate, enddate)

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursByClient", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursByClient", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetBillableHoursByClient(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(6) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(5) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetBillableHoursByClient", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetBillableHoursByClient", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetProductivityData(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal userid As String, ByVal office As String, ByVal dept As String, ByVal yearValue As String, ByVal includeemp As Boolean, Optional ByVal month2 As String = "", Optional ByVal monthcount As Integer = 0)
        Dim ds As DataSet
        Dim arParams(10) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" And month2 <> "" Then
            parameterMonth.Value = monthcount
        ElseIf month <> "" And month2 = "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(4) = parameterUserID

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(5) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(6) = parameterDept

        Dim currentdate As String
        currentdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & Now.Date.Year

        Dim parameterCurrentDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
        parameterCurrentDate.Value = currentdate
        arParams(7) = parameterCurrentDate

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(8) = parameterYearValue

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(9) = parameterInclude

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetProductivityData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetProductivityData", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursWithAgency(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String)
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        GetPPDates(month, year, startdate, enddate)

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursWithAgency", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursWithAgency", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursWithNewBusiness(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String)
        Dim ds As DataSet
        Dim arParams(4) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        GetPPDates(month, year, startdate, enddate)

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursWithNewBusiness", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursWithNewBusiness", Err.Description)
        End Try
        Return ds
    End Function

#End Region

#Region "Realization "

    Public Function GetDirectWithNonDirect(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(7) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(6) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectWithNonDirect", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursWithTotal", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetClientTimeData(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal client As String, ByVal division As String, ByVal product As String)
        Dim ds As DataSet
        Dim arParams(6) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        GetPPDates(month, year, startdate, enddate)

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(3) = parameterClient

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(4) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(5) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetClientTimeData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetClientTimeData", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetAvgHourlyRateByClient(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(7) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(5) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(6) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetAvgHourlyRateByClient", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetAvgHourlyRateByClient", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetAvgHourlyRateByProduct(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(7) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(5) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(6) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetAvgHourlyRateByProduct", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetAvgHourlyRateByProduct", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetRealizationData(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal yearValue As String, ByVal includeemp As Boolean, ByVal userid As String, Optional ByVal month2 As String = "", Optional ByVal monthcount As Integer = 0)
        Dim ds As DataSet
        Dim arParams(11) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" And month2 <> "" Then
            parameterMonth.Value = monthcount
        ElseIf month <> "" And month2 = "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(6) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(7) = parameterYearValue

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(8) = parameterInclude

        Dim currentdate As String
        currentdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & Now.Date.Year

        Dim parameterCurrentDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
        parameterCurrentDate.Value = currentdate
        arParams(9) = parameterCurrentDate

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(10) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetRealizationData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetRealizationData", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetClientTimeByJob(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal client As String, ByVal division As String, ByVal product As String, ByVal job As Integer, ByVal comp As Integer, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(12) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(3) = parameterClient

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(4) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(5) = parameterProduct

        Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJobNumber.Value = job
        arParams(6) = parameterJobNumber

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int)
        parameterJobComp.Value = comp
        arParams(7) = parameterJobComp

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(8) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(9) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(11) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetClientTimeByJob", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetClientTimeByJob", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetJobTimeByEmp(ByVal month As String, ByVal year As String, ByVal client As String, ByVal division As String, ByVal product As String, ByVal job As Integer, ByVal comp As Integer, ByVal empcode As String, ByVal dept As String, ByVal office As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(12) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(0) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(1) = parameterEndDate

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(2) = parameterClient

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(3) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(4) = parameterProduct

        Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJobNumber.Value = job
        arParams(5) = parameterJobNumber

        Dim parameterJobComp As New SqlParameter("@JobComp", SqlDbType.Int)
        parameterJobComp.Value = comp
        arParams(6) = parameterJobComp

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(7) = parameterEmpCode

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(8) = parameterDept

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(9) = parameterOffice

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(11) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetJobTimeByEmp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetJobTimeByEmp", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetPercentBilledByClient(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(7) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(5) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(6) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_PercentBilledByClient", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:PercentBilledByClient", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetClientTotals(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal client As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(8) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(3) = parameterClient

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(6) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(7) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetClientTotals", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetClientTotals", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDetailHours(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(6) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(5) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDetailHours", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDetailHours", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursWithBilled(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(8) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(6) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(7) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursWithBilled", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetDirectHoursWithBilled", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDirectHoursGoalWithBilled(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal userid As String, ByVal includeemp As Boolean, ByVal office As String, ByVal dept As String, ByVal yearValue As String, ByVal period As Integer, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(12) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(4) = parameterMonth

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(5) = parameterUserID

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(6) = parameterInclude

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(7) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(8) = parameterDept

        Dim currentdate As String
        currentdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & Now.Date.Year

        Dim parameterCurrentDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
        parameterCurrentDate.Value = currentdate
        arParams(9) = parameterCurrentDate

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(10) = parameterYearValue

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(11) = parameterPeriod

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDirectHoursGoalWithBilled", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetDirectHoursGoalWithBilled", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetBilledHoursWithBillable(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(8) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(6) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(7) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetBilledHoursWithBillable", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetBilledHoursWithBillable", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetBillableHoursGoalWithStandard(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal userid As String, ByVal includeemp As Boolean, ByVal office As String, ByVal dept As String, ByVal yearValue As String)
        Dim ds As DataSet
        Dim arParams(11) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        GetPPDates(month, year, startdate, enddate)

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(4) = parameterMonth

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(5) = parameterUserID

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(6) = parameterInclude

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(7) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(8) = parameterDept

        Dim currentdate As String
        currentdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & Now.Date.Year

        Dim parameterCurrentDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
        parameterCurrentDate.Value = currentdate
        arParams(9) = parameterCurrentDate

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(10) = parameterYearValue

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetBillableHoursGoalWithStandard", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetBillableHoursGoalWithStandard", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetBilledHoursWithGoal(ByVal empcode As String, ByVal isgauge As Integer, ByVal month As String, ByVal year As String, ByVal includeemp As Boolean, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal yearValue As String, ByVal userid As String, Optional ByVal month2 As String = "", Optional ByVal monthcount As Integer = 0)
        Dim ds As DataSet
        Dim arParams(11) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterIsGauge As New SqlParameter("@IsGauge", SqlDbType.TinyInt)
        parameterIsGauge.Value = isgauge
        arParams(1) = parameterIsGauge

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(3) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" And month2 <> "" Then
            parameterMonth.Value = monthcount
        ElseIf month <> "" And month2 = "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(4) = parameterMonth

        Dim parameterInclude As New SqlParameter("@Include", SqlDbType.Int)
        If includeemp = True Then
            parameterInclude.Value = 1
        Else
            parameterInclude.Value = 0
        End If
        arParams(5) = parameterInclude

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(6) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(8) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(9) = parameterYearValue

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(10) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetBilledHoursWithGoal", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetBilledHoursWithGoal", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetClientDetail(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal client As String, ByVal division As String, ByVal product As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(10) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(3) = parameterClient

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(4) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(5) = parameterProduct

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(6) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(8) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(9) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetClientDetail", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetClientDetail", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetCliDetail(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal client As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(8) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(3) = parameterClient

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(6) = parameterPeriod

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(7) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetCliDetail", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetCliDetail", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetFeeDataByClient(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal client As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(8) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(5) = parameterPeriod

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(7) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetFeeDataByClient", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetFeeDataByClient", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetFeeDataByProduct(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal client As String, ByVal division As String, ByVal product As String, ByVal userid As String, Optional ByVal month2 As String = "")
        Dim ds As DataSet
        Dim arParams(10) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        Dim startdate2 As DateTime
        Dim enddate2 As DateTime

        If month2 = "" Then
            GetPPDates(month, year, startdate, enddate)
        Else
            GetPPDates(month, year, startdate, enddate)
            GetPPDates(month2, year, startdate2, enddate2)
            enddate = enddate2
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        If startdate.ToShortDateString = "1/1/0001" Then
            parameterStartDate.Value = ""
        Else
            parameterStartDate.Value = startdate.ToShortDateString
        End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        If enddate.ToShortDateString = "1/1/0001" Then
            parameterEndDate.Value = ""
        Else
            parameterEndDate.Value = enddate.ToShortDateString
        End If
        arParams(2) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(3) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(4) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(5) = parameterPeriod

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDivision As New SqlParameter("@DivisionCode", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(7) = parameterDivision

        Dim parameterProduct As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(8) = parameterProduct

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
        parameterUserID.Value = userid
        arParams(9) = parameterUserID

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetFeeDataByProduct", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetFeeDataByProduct", Err.Description)
        End Try
        Return ds
    End Function

#End Region

#Region "Chart "

#Region " --- NEW CHARTS --- "

#Region " Pie "

    Public Sub InitializePieChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String)

        RadHtmlChart.Legend.Appearance.Visible = False

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub
    Public Sub GetPieChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal NameField As String, ValueField As String, Optional ByVal Caption As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim PieSeriesItem As Telerik.Web.UI.PieSeriesItem = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.TooltipsAppearance.DataFormatString = "Hours: {0}"
            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#=dataItem." & NameField & "#, #= kendo.format(\'{0:P2}\', percentage)#"
            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            DataTable = DataSet.Tables(0).Copy()

            DataTable.Rows.Clear()

            For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                If DataRow.Item(ValueField) <> 0 Then

                    DataTable.ImportRow(DataRow)

                End If

            Next

            DataTable.Columns.Add("Color")

            For Each row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                row.Item("Color") = StandardColors(DataTable.Rows.IndexOf(row) Mod StandardColors.Count)
            Next

            RadHtmlChart.DataSource = DataTable
            RadHtmlChart.DataBind()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub GetPieChart_DirectHours(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal Caption As String)

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim PieSeriesItem As Telerik.Web.UI.PieSeriesItem = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ListItems As IEnumerable = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.DataSource = ""
            RadHtmlChart.PlotArea.Series.Clear()

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.TooltipsAppearance.DataFormatString = "Hours: {0}"
            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#=dataItem.Name#, #= kendo.format(\'{0:P2}\', percentage)#"
            PieSeries.NameField = "Name"
            PieSeries.DataFieldY = "Value"
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            DataTable = DataSet.Tables(0)

            ListItems = (From Item In DataTable.Columns.OfType(Of System.Data.DataColumn)()
                         Select [Name] = Item.ColumnName,
                                [Value] = GetDataRowCellValue(DataTable.Rows(0)(Item.ColumnName)),
                                [Color] = StandardColors(DataTable.Columns.IndexOf(Item) Mod StandardColors.Count)).ToList.Where(Function(Item) CDec(Item.Value) <> 0).ToList

            RadHtmlChart.DataSource = ListItems
            RadHtmlChart.DataBind()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub GetPieChart_Realization(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal NameField As String,
                                       ByVal ValueField As String, Optional ByVal Caption As String = "", Optional ByVal Month As String = "",
                                       Optional ByVal Year As String = "", Optional ByVal EmployeeCode As String = "", Optional ByVal Month2 As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim PieSeriesItem As Telerik.Web.UI.PieSeriesItem = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ClickURL As String = Nothing
        Dim VarString As String = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()

            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.TooltipsAppearance.DataFormatString = "Billed Amount: {0:C}"
            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#=dataItem." & NameField & "#, #= kendo.format(\'{0:P2}\', percentage)#"
            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            DataTable = DataSet.Tables(0).Copy()

            DataTable.Rows.Clear()

            For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                If DataRow.Item(ValueField) <> 0 Then

                    DataTable.ImportRow(DataRow)

                End If

            Next

            DataTable.Columns.Add("Color")

            For Each row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                row.Item("Color") = StandardColors(DataTable.Rows.IndexOf(row) Mod StandardColors.Count)
            Next

            RadHtmlChart.DataSource = DataTable
            RadHtmlChart.DataBind()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub GetPieChart_ByLevelClient(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal NameField As String, ByVal ValueField As String, Optional ByVal Caption As String = "", Optional ByVal ToolTip As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#= dataItem." & NameField & "#, #= kendo.format(\'{0:P}\', percentage)#"

            If Not [String].IsNullOrWhiteSpace(ToolTip) Then

                If ToolTip.ToUpper.Contains("AMOUNT") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:C2}\', value)#"

                ElseIf ToolTip.ToUpper.Contains("HOURS") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                Else

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                End If

            Else

                PieSeries.TooltipsAppearance.ClientTemplate = "#= kendo.format(\'{0:P2}\', percentage)#"

            End If

            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            DataTable = DataSet.Tables(0).Copy

            DataTable.Rows.Clear()

            For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                If DataRow.Item(ValueField) <> 0 Then

                    DataTable.ImportRow(DataRow)

                End If

            Next

            DataTable.Columns.Add("Color")

            For Each row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                row.Item("Color") = StandardColors(DataTable.Rows.IndexOf(row) Mod StandardColors.Count)
            Next

            RadHtmlChart.DataSource = DataTable
            RadHtmlChart.DataBind()

            'For i = 0 To DataSet.Tables(0).Rows.Count - 1
            '    If DataSet.Tables(0).Rows(i).Item(ValueField) <> 0 Then
            '        sbFCXMLData.Append("<set label='" & DataSet.Tables(0).Rows(i).Item(NameField).ToString.Replace("'", "") & "' value='" & DataSet.Tables(0).Rows(i).Item(ValueField) & "' color='" & strColor(i Mod 10) & "' tooltext='" & ToolTip & String.Format("{0:#,##0.00}", DataSet.Tables(0).Rows(i).Item(ValueField)) & "' />" & vbCrLf)
            '    End If
            'Next

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Public Sub GetPieChart_ByLevelClientETF(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), ByVal NameField As String, ByVal ValueField As String, Optional ByVal Caption As String = "", Optional ByVal ToolTip As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#= dataItem." & NameField & "#, #= kendo.format(\'{0:P}\', percentage)#"

            If Not [String].IsNullOrWhiteSpace(ToolTip) Then

                If ToolTip.ToUpper.Contains("AMOUNT") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:C2}\', value)#"

                ElseIf ToolTip.ToUpper.Contains("HOURS") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                Else

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                End If

            Else

                PieSeries.TooltipsAppearance.ClientTemplate = "#= kendo.format(\'{0:P2}\', percentage)#"

            End If

            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            Dim EmployeeTimeForecastDashboard As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeTimeForcastDashboard) = Nothing

            EmployeeTimeForecastDashboard = (From Entity In EmployeeTimeForecastDetail
                                             Group Entity By Entity.ClientCode,
                                                       Entity.ClientName Into ETFD = Group
                                             Select New AdvantageFramework.Dashboard.Classes.EmployeeTimeForcastDashboard(
                                                        ClientCode,
                                                        ClientName,
                                                        ETFD.Sum(Function(MPC) MPC.ForecastedHours),
                                                        ETFD.Sum(Function(MPC) MPC.ForecastedAmount),
                                                        ETFD.Sum(Function(MPC) MPC.ActualHours),
                                                        ETFD.Sum(Function(MPC) MPC.ActualAmount), 0)).ToList

            'Dim NewDataRow As DataRow = Nothing
            'Dim i As Integer = 0

            'DataTable = New DataTable

            'DataTable.Columns.Add("ClientCode")
            'DataTable.Columns.Add("ClientName")
            'DataTable.Columns.Add("ActualHours")
            'DataTable.Columns.Add("ActualAmount")
            'DataTable.Columns.Add("Color")

            'For Each ET In EmployeeTimeForecastDashboard

            '    NewDataRow = DataTable.Rows.Add()

            '    NewDataRow(0) = ET.ClientCode
            '    NewDataRow(1) = ET.ClientName
            '    NewDataRow(2) = ET.ActualHours
            '    NewDataRow(3) = ET.ActualAmount
            '    NewDataRow(4) = StandardColors(i)

            '    i += 1

            '    If i = 11 Then
            '        i = 0
            '    End If

            'Next

            RadHtmlChart.DataSource = (From Entity In EmployeeTimeForecastDetail
                                       Where Entity.ClientCode IsNot Nothing
                                       Group Entity By Entity.ClientCode,
                                                       Entity.ClientName Into ETFD = Group
                                       Select ClientCode,
                                              ClientName,
                                              Hours = ETFD.Sum(Function(MPC) MPC.ActualHours),
                                              Amount = ETFD.Sum(Function(MPC) MPC.ActualAmount)
                                       Order By ClientCode)
            RadHtmlChart.DataBind()

            'For i = 0 To DataSet.Tables(0).Rows.Count - 1
            '    If DataSet.Tables(0).Rows(i).Item(ValueField) <> 0 Then
            '        sbFCXMLData.Append("<set label='" & DataSet.Tables(0).Rows(i).Item(NameField).ToString.Replace("'", "") & "' value='" & DataSet.Tables(0).Rows(i).Item(ValueField) & "' color='" & strColor(i Mod 10) & "' tooltext='" & ToolTip & String.Format("{0:#,##0.00}", DataSet.Tables(0).Rows(i).Item(ValueField)) & "' />" & vbCrLf)
            '    End If
            'Next

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Public Sub GetPieChart_ByEmployeeETF(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), ByVal NameField As String, ByVal ValueField As String, Optional ByVal Caption As String = "", Optional ByVal ToolTip As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#= dataItem." & NameField & "#, #= kendo.format(\'{0:P}\', percentage)#"

            If Not [String].IsNullOrWhiteSpace(ToolTip) Then

                If ToolTip.ToUpper.Contains("AMOUNT") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:C2}\', value)#"

                ElseIf ToolTip.ToUpper.Contains("HOURS") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                Else

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                End If

            Else

                PieSeries.TooltipsAppearance.ClientTemplate = "#= kendo.format(\'{0:P2}\', percentage)#"

            End If

            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            'DataTable = DataSet.Tables(0).Copy

            'DataTable.Rows.Clear()

            'For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

            '    If DataRow.Item(ValueField) <> 0 Then

            '        DataTable.ImportRow(DataRow)

            '    End If

            'Next

            'DataTable.Columns.Add("Color")

            'For Each row In DataTable.Rows.OfType(Of System.Data.DataRow)()
            '    row.Item("Color") = StandardColors(DataTable.Rows.IndexOf(row) Mod StandardColors.Count)
            'Next

            RadHtmlChart.DataSource = (From Entity In EmployeeTimeForecastDetail
                                       Group Entity By Entity.Employee,
                                                       Entity.EmployeeCode Into ETFD = Group
                                       Select Employee,
                                              EmployeeCode,
                                              Hours = ETFD.Sum(Function(MPC) MPC.ActualHours),
                                              Amount = ETFD.Sum(Function(MPC) MPC.ActualAmount)
                                       Order By Employee)
            RadHtmlChart.DataBind()

            'For i = 0 To DataSet.Tables(0).Rows.Count - 1
            '    If DataSet.Tables(0).Rows(i).Item(ValueField) <> 0 Then
            '        sbFCXMLData.Append("<set label='" & DataSet.Tables(0).Rows(i).Item(NameField).ToString.Replace("'", "") & "' value='" & DataSet.Tables(0).Rows(i).Item(ValueField) & "' color='" & strColor(i Mod 10) & "' tooltext='" & ToolTip & String.Format("{0:#,##0.00}", DataSet.Tables(0).Rows(i).Item(ValueField)) & "' />" & vbCrLf)
            '    End If
            'Next

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Public Sub GetPieChart_ByLevel(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal NameField As String, ByVal ValueField As String,
                                   Optional ByVal Caption As String = "", Optional ByVal week As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "",
                                   Optional ByVal range As String = "", Optional ByVal level As String = "", Optional ByVal ToolTip As String = "")

        Dim DataTable As System.Data.DataTable = Nothing
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim ChartType As String = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try
            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            Select Case NameField

                Case "CL_NAME"

                    ChartType = "cli"

                Case "DIV_NAME"

                    ChartType = "div"

                Case "PRD_DESCRIPTION"

                    ChartType = "prd"

                Case "ACCT_NAME"

                    ChartType = "acc"

                Case "DP_TM_DESC"

                    ChartType = "dept"

                Case "SC_DESCRIPTION"

                    ChartType = "sc"

                Case "JT_DESC"

                    ChartType = "jt"

            End Select

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#= dataItem." & NameField & "#, #= kendo.format(\'{0:P2}\', percentage)#"

            If Not [String].IsNullOrWhiteSpace(ToolTip) Then

                PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & ": #= value #"

            Else

                PieSeries.TooltipsAppearance.ClientTemplate = "#= value #"

            End If

            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            DataTable = DataSet.Tables(0).Copy

            DataTable.Rows.Clear()

            For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                If GetDataRowCellValue(DataRow.Item(ValueField)) <> 0 Then

                    DataTable.ImportRow(DataRow)

                End If

            Next

            DataTable.Columns.Add("Color")

            For Each row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                row.Item("Color") = StandardColors(DataTable.Rows.IndexOf(row) Mod StandardColors.Count)
            Next

            RadHtmlChart.DataSource = DataTable
            RadHtmlChart.DataBind()

            For Each DataColumn In DataTable.Columns.OfType(Of System.Data.DataColumn)()

                RadHtmlChart.Attributes("COL_" & (DataTable.Columns.IndexOf(DataColumn) + 1).ToString) = DataColumn.ColumnName



            Next

            Dim URLString As String

            Select Case ChartType

                Case "div"

                    URLString = "DashboardProjectList.aspx?Group=0&code=[" & DataTable.Columns(0).ColumnName & "],&name=[" & DataTable.Columns(1).ColumnName & "]&divcode=[" & DataTable.Columns(2).ColumnName & "]&divname=[" & DataTable.Columns(3).ColumnName & "]&prdcode=&month=" & month & "&year=" & year & "&type=" & ChartType & "&rang=" & range & "&week=" & week & "&project=" & ValueField & "&level=" & level
                    RadHtmlChart.Attributes("FIELDS") = String.Join(",", {DataTable.Columns(0).ColumnName, DataTable.Columns(1).ColumnName, DataTable.Columns(2).ColumnName, DataTable.Columns(3).ColumnName})

                Case "prd"

                    URLString = "DashboardProjectList.aspx?Group=0&code=[" & DataTable.Columns(0).ColumnName & "],&name=[" & DataTable.Columns(1).ColumnName & "]&divcode=[" & DataTable.Columns(2).ColumnName & "]&divname=[" & DataTable.Columns(3).ColumnName & "]&prdcode=[" & DataTable.Columns(4).ColumnName & "]&prdname=[" & DataTable.Columns(5).ColumnName & "]&month=" & month & "&year=" & year & "&type=" & ChartType & "&range=" & range & "&week=" & week & "&project=" & ValueField & "&level=" & level
                    RadHtmlChart.Attributes("FIELDS") = String.Join(",", {DataTable.Columns(0).ColumnName, DataTable.Columns(1).ColumnName, DataTable.Columns(2).ColumnName, DataTable.Columns(3).ColumnName, DataTable.Columns(4).ColumnName, DataTable.Columns(5).ColumnName})

                Case Else

                    URLString = "DashboardProjectList.aspx?Group=0&code=[" & DataTable.Columns(0).ColumnName & "],&name=[" & DataTable.Columns(1).ColumnName & "]&divcode=&prdcode=&month=" & month & "&year=" & year & "&type=" & ChartType & "&range=" & range & "&week=" & week & "&project=" & ValueField & "&level=" & level
                    RadHtmlChart.Attributes("FIELDS") = String.Join(",", {DataTable.Columns(0).ColumnName, DataTable.Columns(1).ColumnName})

            End Select

            RadHtmlChart.Attributes("SERIES_CLICK_URL") = URLString

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetPieChart_ByLevelClientEmployeeUtilization(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), ByVal NameField As String, ByVal ValueField As String, Optional ByVal Caption As String = "", Optional ByVal ToolTip As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#= dataItem." & NameField & "#, #= kendo.format(\'{0:P}\', percentage)#"

            If Not [String].IsNullOrWhiteSpace(ToolTip) Then

                If ToolTip.ToUpper.Contains("AMOUNT") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:C2}\', value)#"

                ElseIf ToolTip.ToUpper.Contains("HOURS") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                Else

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                End If

            Else

                PieSeries.TooltipsAppearance.ClientTemplate = "#= kendo.format(\'{0:P2}\', percentage)#"

            End If

            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            Dim EmployeeTimeForecastDashboard As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeTimeForcastDashboard) = Nothing

            RadHtmlChart.DataSource = EmployeeTimeForecastDetail
            RadHtmlChart.DataBind()

            'For i = 0 To DataSet.Tables(0).Rows.Count - 1
            '    If DataSet.Tables(0).Rows(i).Item(ValueField) <> 0 Then
            '        sbFCXMLData.Append("<set label='" & DataSet.Tables(0).Rows(i).Item(NameField).ToString.Replace("'", "") & "' value='" & DataSet.Tables(0).Rows(i).Item(ValueField) & "' color='" & strColor(i Mod 10) & "' tooltext='" & ToolTip & String.Format("{0:#,##0.00}", DataSet.Tables(0).Rows(i).Item(ValueField)) & "' />" & vbCrLf)
            '    End If
            'Next

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Public Sub GetPieChart_ByLevelTypeEmployeeUtilization(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), ByVal NameField As String, ByVal ValueField As String, Optional ByVal Caption As String = "", Optional ByVal ToolTip As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.DataSource = ""

            InitializePieChart(RadHtmlChart, Caption)

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#= dataItem." & NameField & "#, #= kendo.format(\'{0:P}\', percentage)#"

            If Not [String].IsNullOrWhiteSpace(ToolTip) Then

                If ToolTip.ToUpper.Contains("AMOUNT") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:C2}\', value)#"

                ElseIf ToolTip.ToUpper.Contains("HOURS") Then

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                Else

                    PieSeries.TooltipsAppearance.ClientTemplate = ToolTip & "#= kendo.format(\'{0:N2}\', value)#"

                End If

            Else

                PieSeries.TooltipsAppearance.ClientTemplate = "#= kendo.format(\'{0:P2}\', percentage)#"

            End If

            PieSeries.DataFieldY = ValueField
            PieSeries.NameField = NameField
            PieSeries.ColorField = "Color"

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            Dim EmployeeTimeForecastDashboard As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeTimeForcastDashboard) = Nothing

            RadHtmlChart.DataSource = EmployeeTimeForecastDetail
            RadHtmlChart.DataBind()

            'For i = 0 To DataSet.Tables(0).Rows.Count - 1
            '    If DataSet.Tables(0).Rows(i).Item(ValueField) <> 0 Then
            '        sbFCXMLData.Append("<set label='" & DataSet.Tables(0).Rows(i).Item(NameField).ToString.Replace("'", "") & "' value='" & DataSet.Tables(0).Rows(i).Item(ValueField) & "' color='" & strColor(i Mod 10) & "' tooltext='" & ToolTip & String.Format("{0:#,##0.00}", DataSet.Tables(0).Rows(i).Item(ValueField)) & "' />" & vbCrLf)
            '    End If
            'Next

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub


#End Region

#Region " Radial Gauge "

    Public Sub InitializeRadialGauge(ByVal RadRadialGauge As Telerik.Web.UI.RadRadialGauge, ByVal Caption As String)

        Dim Colors As AdvantageFramework.Web.Presentation.Colors = Nothing

        Colors = New AdvantageFramework.Web.Presentation.Colors

        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        RadRadialGauge.Scale.Ranges.Clear()

        With RadRadialGauge.Scale

            .Min = 0
            .Max = 100
            .Labels.Format = "{0}%"
            .Ranges.Add(New Telerik.Web.UI.GaugeRange With {.From = 0, .To = 30, .Color = Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Red, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)})
            .Ranges.Add(New Telerik.Web.UI.GaugeRange With {.From = 30, .To = 70, .Color = Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Yellow, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)})
            .Ranges.Add(New Telerik.Web.UI.GaugeRange With {.From = 70, .To = 100, .Color = Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Green, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)})

        End With

    End Sub
    Public Sub GetRadialGauge(ByVal RadRadialGauge As Telerik.Web.UI.RadRadialGauge, ByVal DataSet As System.Data.DataSet, Optional ByVal Caption As String = "", Optional ByVal Type As String = "")

        'objects
        Dim Total As Object = Nothing
        Dim Direct As Object = Nothing
        Dim TotalAsInteger As Integer = Nothing
        Dim DirectAsInteger As Integer = Nothing
        Dim PointerValue As Integer = 0

        RadRadialGauge.Pointers.Clear()
        RadRadialGauge.Pointer.Value = Nothing

        InitializeRadialGauge(RadRadialGauge, Caption)

        If DataSet.Tables(0).Rows.Count > 0 Then

            For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                Total = Nothing
                Direct = Nothing

                Select Case Type.ToLower

                    Case "direct"
                        Total = DataRow.Item("TOTAL_HOURS")
                        Direct = DataRow.Item("DIRECT")

                    Case "goal"
                        Total = DataRow.Item("GOAL")
                        Direct = DataRow.Item("BILLABLE")

                    Case "required"
                        Total = DataRow.Item("REQUIRED")
                        Direct = DataRow.Item("TOTAL_HOURS")

                    Case "billable"
                        Total = DataRow.Item("DIRECT")
                        Direct = DataRow.Item("BILLABLE")

                    Case "directbilled", "directgoal"
                        Total = DataRow.Item("DIRECT")
                        Direct = DataRow.Item("BILLED")

                    Case "billedbillable"
                        Total = DataRow.Item("BILLABLE")
                        Direct = DataRow.Item("BILLED")

                    Case "goalstandard"
                        Total = DataRow.Item("REQUIRED")
                        Direct = DataRow.Item("GOAL")

                    Case "billedgoal"
                        Total = DataRow.Item("GOAL")
                        Direct = DataRow.Item("BILLED")

                End Select

                TotalAsInteger = GetDataRowCellValue(Total)
                DirectAsInteger = GetDataRowCellValue(Direct)

                If TotalAsInteger > 0 Then

                    PointerValue = CInt((DirectAsInteger / TotalAsInteger) * 100)

                Else

                    PointerValue = 0

                End If

                RadRadialGauge.Pointers.Add(New Telerik.Web.UI.RadialPointer With {.Value = PointerValue})
                RadRadialGauge.ToolTip = PointerValue.ToString() & "%"

            Next

        End If

    End Sub

#End Region

#Region " Linear Gauge "

    Public Function GetLinearGauge(ByVal DataSet As System.Data.DataSet, ByVal RenderAt As String, Optional ByVal Caption As String = "") As String

        '
        ' this function returns a JSON string
        ' renderAt = HTML control ID to render chart
        '

        'objects
        Dim JSONString As String = Nothing
        Dim IsClient As Boolean = False
        Dim DataTable As System.Data.DataTable = Nothing
        Dim GoodRange As Integer = Nothing
        Dim OkRange As Integer = Nothing
        Dim BadRange As Integer = Nothing
        Dim PointerValue As Decimal = Nothing
        Dim FusionLinearGauge As AdvantageFramework.Web.FusionLinearGauge.Gauge = Nothing
        Dim Colors As AdvantageFramework.Web.Presentation.Colors = Nothing

        Colors = New AdvantageFramework.Web.Presentation.Colors

        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            If DataSet IsNot Nothing Then

                If DataSet.Tables.Count > 1 Then

                    DataTable = DataSet.Tables(1)
                    IsClient = True

                Else

                    DataTable = DataSet.Tables(0)

                End If

                If DataTable.Rows.Count > 0 Then

                    If IsClient Then

                        GoodRange = CInt(GetDataRowCellValue(DataTable.Rows(0)(0))) - (CInt(GetDataRowCellValue(DataTable.Rows(0)(0))) / 4)
                        OkRange = CInt(GetDataRowCellValue(DataTable.Rows(0)(0)))
                        BadRange = OkRange + OkRange

                    Else

                        GoodRange = CInt(GetDataRowCellValue(DataTable.Rows(0)(2))) - (CInt(GetDataRowCellValue(DataTable.Rows(0)(2))) / 4)
                        OkRange = CInt(GetDataRowCellValue(DataTable.Rows(0)(2)))
                        BadRange = OkRange + OkRange

                    End If

                    If IsClient Then

                        If Not IsDBNull(DataTable.Rows(0)(1)) Then

                            PointerValue = DataTable.Rows(0)(1)

                        End If

                    Else

                        If Not IsDBNull(DataTable.Rows(0)(3)) Then

                            PointerValue = DataTable.Rows(0)(3)

                        End If

                    End If

                End If

            End If

            FusionLinearGauge = New AdvantageFramework.Web.FusionLinearGauge.Gauge
            Colors = New AdvantageFramework.Web.Presentation.Colors

            With FusionLinearGauge

                .renderAt = RenderAt
                .width = 800
                .height = 100

            End With

            With FusionLinearGauge.dataSource.chart

                .manageresize = 1
                .showborder = 0
                .upperlimit = BadRange
                .lowerlimit = 0
                .gaugeroundradius = 5
                .chartbottommargin = 10
                .ticksbelowgauge = 0
                .showgaugelabels = 1
                .valueabovepointer = 0
                .pointerontop = 1
                .pointerradius = 9
                .numberprefix = System.Globalization.RegionInfo.CurrentRegion.CurrencySymbol
                .majorTMNumber = 5
                .bgColor = "#fff"
                .bgAlpha = 0
                .canvasBgColor = "#fff"
                .canvasBgAlpha = 0
                .forceTickValueDecimals = 1
                .adjustTM = 0
                .decimalSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
                .thousandSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator

            End With

            With FusionLinearGauge.dataSource.colorRange

                .color = {New AdvantageFramework.Web.FusionLinearGauge.Color With {.minValue = 0, .maxValue = GoodRange, .label = "", .code = Colors.LoadHex(AdvantageFramework.Web.Presentation.Colors.Color.Green, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)},
                          New AdvantageFramework.Web.FusionLinearGauge.Color With {.minValue = GoodRange, .maxValue = OkRange, .label = "", .code = Colors.LoadHex(AdvantageFramework.Web.Presentation.Colors.Color.Yellow, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)},
                          New AdvantageFramework.Web.FusionLinearGauge.Color With {.minValue = OkRange, .maxValue = BadRange, .label = "", .code = Colors.LoadHex(AdvantageFramework.Web.Presentation.Colors.Color.Red, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)}}

            End With

            With FusionLinearGauge.dataSource.pointers

                .pointer = {New AdvantageFramework.Web.FusionLinearGauge.Pointer With {.value = PointerValue}}

            End With

            With FusionLinearGauge.dataSource.trendpoints

                .point = {New AdvantageFramework.Web.FusionLinearGauge.Point With {.startvalue = OkRange, .displayvalue = "Fee Amount", .dashed = 0, .color = "#000", .thickness = 1, .useMarker = 1, .markerBorderColor = "#666", .markerColor = "#fff", .markerTooltext = [String].Format("Fee Amount: {0:C}", OkRange)}}

            End With

            JSONString = FusionLinearGauge.SerializeAsJson()

        Catch ex As Exception
            JSONString = Nothing
        Finally
            GetLinearGauge = JSONString
        End Try

    End Function

#End Region

#Region " Column "

    Public Sub InitializeDirectAndNonDirectColumnChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String)

        RadHtmlChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom
        RadHtmlChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -45
        RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
        RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub
    Public Sub GetDirectAndNonDirectColumnChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, Optional ByVal Caption As String = "")

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DirectColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim NonDirectColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim DirectSeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim NonDirectSeriesItem As Telerik.Web.UI.SeriesItem = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            InitializeDirectAndNonDirectColumnChart(RadHtmlChart, Caption)

            DataTable = New System.Data.DataTable

            If DataSet IsNot Nothing Then

                DataTable = DataSet.Tables(0)

            End If

            If DataTable.Rows.Count > 0 Then

                DirectColumnSeries = New Telerik.Web.UI.ColumnSeries
                DirectColumnSeries.Name = "Direct"
                DirectColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"

                NonDirectColumnSeries = New Telerik.Web.UI.ColumnSeries
                NonDirectColumnSeries.Name = "Non Direct"
                NonDirectColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                    RadHtmlChart.PlotArea.XAxis.Items.Add(DataRow(1))

                    DirectSeriesItem = New Telerik.Web.UI.SeriesItem
                    DirectSeriesItem.YValue = GetDataRowCellValue(DataRow(2))
                    DirectSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", DirectColumnSeries.Name, GetDataRowCellValue(DataRow(1)), DirectSeriesItem.YValue)
                    DirectSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                    DirectColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                    DirectColumnSeries.Items.Add(DirectSeriesItem)

                    NonDirectSeriesItem = New Telerik.Web.UI.SeriesItem
                    NonDirectSeriesItem.YValue = GetDataRowCellValue(DataRow(3))
                    NonDirectSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", NonDirectColumnSeries.Name, GetDataRowCellValue(DataRow(1)), NonDirectSeriesItem.YValue)
                    NonDirectSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                    NonDirectColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                    NonDirectColumnSeries.Items.Add(NonDirectSeriesItem)

                Next

                RadHtmlChart.PlotArea.Series.Add(DirectColumnSeries)
                RadHtmlChart.PlotArea.Series.Add(NonDirectColumnSeries)

                For Each ColumnSeries In RadHtmlChart.PlotArea.Series.OfType(Of Telerik.Web.UI.ColumnSeries)()

                    ColumnSeries.Stacked = False
                    'ColumnSeries.LabelsAppearance.Visible = False
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= category #, #= kendo.format(\'{0:N2}\', value) #"

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub InitializeTotalsColumnChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String)

        RadHtmlChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom
        RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
        RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub
    Public Sub GetTotalsColumnChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, Optional ByVal Caption As String = "", Optional ByVal Type As String = "")

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ColumnSeries1 As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ColumnSeries2 As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ColumnSeries1Name As String = Nothing
        Dim ColumnSeries2Name As String = Nothing
        Dim ColumnSeries1SeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim ColumnSeries2SeriesItem As Telerik.Web.UI.SeriesItem = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            InitializeTotalsColumnChart(RadHtmlChart, Caption)

            If DataSet IsNot Nothing Then

                DataTable = DataSet.Tables(0)

            End If

            If DataTable.Rows.Count > 0 Then

                Select Case Type.ToLower

                    Case "direct"
                        ColumnSeries1Name = "Total"

                    Case "bill", "agency", "newbusiness", "billed"
                        ColumnSeries1Name = "Direct"

                    Case "nondirect"
                        ColumnSeries1Name = "Non Direct"

                    Case "required"
                        ColumnSeries1Name = "Required"

                    Case "goal", "billedgoal"
                        ColumnSeries1Name = "Goal"

                    Case "client", "billable"
                        ColumnSeries1Name = "Billable"

                    Case "standard"
                        ColumnSeries1Name = "Standard"

                    Case "directgoalbilled"
                        ColumnSeries1Name = "Goal"

                End Select

                Select Case Type.ToLower

                    Case "nonbill", "client"
                        ColumnSeries2Name = "Non Billable"

                    Case "goal", "bill"
                        ColumnSeries2Name = "Billable"

                    Case "agency"
                        ColumnSeries2Name = "Agency"

                    Case "newbusiness"
                        ColumnSeries2Name = "New Business"

                    Case "billed", "billable", "billedgoal", "directgoalbilled"
                        ColumnSeries2Name = "Billed"

                    Case "standard"
                        ColumnSeries2Name = "Goal"

                    Case "direct"
                        ColumnSeries2Name = "Direct"

                    Case Else
                        ColumnSeries2Name = "Total"

                End Select

                If Not [String].IsNullOrWhiteSpace(ColumnSeries1Name) Then

                    ColumnSeries1 = New Telerik.Web.UI.ColumnSeries
                    ColumnSeries1.Name = ColumnSeries1Name

                End If

                If Not [String].IsNullOrWhiteSpace(ColumnSeries2Name) Then

                    ColumnSeries2 = New Telerik.Web.UI.ColumnSeries
                    ColumnSeries2.Name = ColumnSeries2Name

                End If

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                    RadHtmlChart.PlotArea.XAxis.Items.Add(GetDataRowCellValue(DataRow(1)))

                    If ColumnSeries1 IsNot Nothing Then

                        ColumnSeries1SeriesItem = New Telerik.Web.UI.SeriesItem
                        ColumnSeries1SeriesItem.YValue = GetDataRowCellValue(DataRow(2))
                        ColumnSeries1SeriesItem.TooltipValue = [String].Format("{0}, {1:N2}", ColumnSeries1.Name, ColumnSeries1SeriesItem.YValue)
                        ColumnSeries1SeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                        ColumnSeries1.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                        ColumnSeries1.Items.Add(ColumnSeries1SeriesItem)

                    End If

                    If ColumnSeries2 IsNot Nothing Then

                        ColumnSeries2SeriesItem = New Telerik.Web.UI.SeriesItem
                        ColumnSeries2SeriesItem.YValue = GetDataRowCellValue(DataRow(3))
                        ColumnSeries2SeriesItem.TooltipValue = [String].Format("{0}, {1:N2}", ColumnSeries2.Name, ColumnSeries2SeriesItem.YValue)
                        ColumnSeries2SeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                        ColumnSeries2.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                        ColumnSeries2.Items.Add(ColumnSeries2SeriesItem)

                    End If

                Next

                If ColumnSeries1 IsNot Nothing Then

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries1)

                End If

                If ColumnSeries2 IsNot Nothing Then

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries2)

                End If

                For Each ColumnSeries In RadHtmlChart.PlotArea.Series.OfType(Of Telerik.Web.UI.ColumnSeries)()

                    ColumnSeries.Stacked = False
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub InitializeColumnChart_ClientTotals(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String)

        RadHtmlChart.Legend.Appearance.Visible = False
        RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MinorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.XAxis.MajorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:C0}"

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub
    Public Sub GetColumnChart_ClientTotals(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, Optional ByVal Caption As String = "")

        'objects
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ChartColors As AdvantageFramework.Web.Presentation.Colors = Nothing
        Dim Colors As AdvantageFramework.Web.Presentation.Colors.Color() = Nothing

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            Colors = {AdvantageFramework.Web.Presentation.Colors.Color.Red,
                      AdvantageFramework.Web.Presentation.Colors.Color.Yellow,
                      AdvantageFramework.Web.Presentation.Colors.Color.Orange,
                      AdvantageFramework.Web.Presentation.Colors.Color.Green,
                      AdvantageFramework.Web.Presentation.Colors.Color.Blue}

            InitializeColumnChart_ClientTotals(RadHtmlChart, Caption)

            If DataSet IsNot Nothing Then

                ColumnSeries = New Telerik.Web.UI.ColumnSeries
                ColumnSeries.Name = "ColumnSeries1"
                ColumnSeries.Stacked = False
                ColumnSeries.LabelsAppearance.DataFormatString = "{0:C0}"
                ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:C0}\', value) #"

                ChartColors = New AdvantageFramework.Web.Presentation.Colors

                For Each DataColumn In DataSet.Tables(0).Columns.OfType(Of System.Data.DataColumn)()

                    If Not IsDBNull(DataSet.Tables(0).Rows(0).Item(DataColumn.ColumnName)) AndAlso DataSet.Tables(0).Rows(0).Item(DataColumn.ColumnName) <> 0 Then

                        ColumnSeries.SeriesItems.Add(GetDataRowCellValue(DataSet.Tables(0).Rows(0).Item(DataColumn.ColumnName)), ChartColors.LoadColor(Colors(DataSet.Tables(0).Columns.IndexOf(DataColumn.ColumnName) Mod Colors.Count), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        RadHtmlChart.PlotArea.XAxis.Items.Add(DataColumn.ColumnName)

                    End If

                Next

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub InitializeColumnChart_CompsClient(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String, ByVal DataType As String)

        'objects
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim LineSeries As Telerik.Web.UI.LineSeries = Nothing
        Dim TooltipClientTemplate As String = Nothing

        RadHtmlChart.Legend.Appearance.Visible = True
        RadHtmlChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom
        RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MinorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.XAxis.MajorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

        If RadHtmlChart.PlotArea.Series.Count > 0 Then

            If TypeOf RadHtmlChart.PlotArea.Series(0) Is Telerik.Web.UI.ColumnSeries Then

                ColumnSeries = RadHtmlChart.PlotArea.Series(0)

                ColumnSeries.LabelsAppearance.Visible = False

            End If

            If RadHtmlChart.PlotArea.Series.Count > 1 Then

                If TypeOf RadHtmlChart.PlotArea.Series(1) Is Telerik.Web.UI.LineSeries Then

                    LineSeries = RadHtmlChart.PlotArea.Series(1)
                    LineSeries.LabelsAppearance.Visible = False

                End If

            End If

        End If

        If DataType = "Hours" Then

            RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:N2}"
            TooltipClientTemplate = "#= series.name #, #= category #, #= kendo.format(\'{0:N2}\', value) #"

        ElseIf DataType = "Dollars" Then

            RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:C2}"
            TooltipClientTemplate = "#= series.name #, #= category #, #= kendo.format(\'{0:C2}\', value) #"

        End If

        If ColumnSeries IsNot Nothing Then

            ColumnSeries.TooltipsAppearance.ClientTemplate = TooltipClientTemplate

        End If

        If LineSeries IsNot Nothing Then

            LineSeries.TooltipsAppearance.ClientTemplate = TooltipClientTemplate

        End If

        RadHtmlChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub
    Public Function GetColumnChart_CompsClient(ByVal DataTable As System.Data.DataTable, Optional ByVal Caption As String = "", Optional ByVal Range As String = "",
                                               Optional ByVal DataType As String = "", Optional ByVal Page As String = "") As Telerik.Web.UI.RadHtmlChart

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim LineSeries As Telerik.Web.UI.LineSeries = Nothing

        Dim ColumnSeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim LineSeriesItem As Telerik.Web.UI.SeriesItem = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            If DataTable.Rows.Count > 0 Then

                RadHtmlChart = New Telerik.Web.UI.RadHtmlChart

                ColumnSeries = New Telerik.Web.UI.ColumnSeries

                If DataType = "Hours" Then

                    ColumnSeries.Name = "Hours"

                ElseIf DataType = "Dollars" Then

                    ColumnSeries.Name = "Dollars"

                End If

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                If Range = "" Then

                    LineSeries = New Telerik.Web.UI.LineSeries

                    LineSeries.Name = "4 Week Avg"

                    RadHtmlChart.PlotArea.Series.Add(LineSeries)

                End If

                InitializeColumnChart_CompsClient(RadHtmlChart, Caption, DataType)

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                    If Range = "month" Then

                        RadHtmlChart.PlotArea.XAxis.Items.Add(DataRow(0))

                        If Page = "year" Then

                            ColumnSeriesItem = New Telerik.Web.UI.SeriesItem
                            If GetDataRowCellValue(DataRow(2)) Is Nothing Then
                                ColumnSeriesItem.YValue = 0
                            Else
                                ColumnSeriesItem.YValue = CDec(DataRow(2))
                            End If
                            ColumnSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                            ColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                            ColumnSeries.Items.Add(ColumnSeriesItem)

                        ElseIf Page = "month" Then

                            ColumnSeriesItem = New Telerik.Web.UI.SeriesItem
                            If GetDataRowCellValue(DataRow(4)) Is Nothing Then
                                ColumnSeriesItem.YValue = 0
                            Else
                                ColumnSeriesItem.YValue = CDec(DataRow(4))
                            End If
                            ColumnSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                            ColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                            ColumnSeries.Items.Add(ColumnSeriesItem)

                        End If

                    Else

                        RadHtmlChart.PlotArea.XAxis.Items.Add(DataRow(1))

                        ColumnSeriesItem = New Telerik.Web.UI.SeriesItem
                        If GetDataRowCellValue(DataRow(4)) Is Nothing Then
                            ColumnSeriesItem.YValue = 0
                        Else
                            ColumnSeriesItem.YValue = CDec(DataRow(4))
                        End If
                        ColumnSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                        ColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                        ColumnSeries.Items.Add(ColumnSeriesItem)

                        If Range = "" Then

                            LineSeriesItem = New Telerik.Web.UI.SeriesItem
                            If GetDataRowCellValue(DataRow(4)) Is Nothing Then
                                LineSeriesItem.YValue = 0
                            Else
                                LineSeriesItem.YValue = CDec(DataRow(4))
                            End If
                            LineSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                            LineSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                            LineSeries.Items.Add(LineSeriesItem)

                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            RadHtmlChart = Nothing
        Finally
            GetColumnChart_CompsClient = RadHtmlChart
        End Try

    End Function
    Public Function GetColumnChart_Hours(ByVal DataTable As System.Data.DataTable, Optional ByVal Caption As String = "", Optional ByVal DataType As String = "") As Telerik.Web.UI.RadHtmlChart

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing

        Try

            If DataTable.Rows.Count > 0 Then

                RadHtmlChart = New Telerik.Web.UI.RadHtmlChart
                ColumnSeries = New Telerik.Web.UI.ColumnSeries

                ColumnSeries.Name = DataType

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                InitializeColumnChart_CompsClient(RadHtmlChart, Caption, DataType)

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                    RadHtmlChart.PlotArea.XAxis.Items.Add(GetDataRowCellValue(DataRow(1)))
                    ColumnSeries.SeriesItems.Add(GetDataRowCellValue(DataRow(3)))

                Next

            End If

        Catch ex As Exception
            RadHtmlChart = Nothing
        Finally
            GetColumnChart_Hours = RadHtmlChart
        End Try
    End Function
    Public Sub InitializeColumnChart_Comps(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String)

        'objects
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim LineSeries As Telerik.Web.UI.LineSeries = Nothing
        Dim TooltipClientTemplate As String = Nothing

        RadHtmlChart.Legend.Appearance.Visible = True
        RadHtmlChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom
        RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MinorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.XAxis.MajorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

        If RadHtmlChart.PlotArea.Series.Count > 0 Then

            If TypeOf RadHtmlChart.PlotArea.Series(0) Is Telerik.Web.UI.ColumnSeries Then

                ColumnSeries = RadHtmlChart.PlotArea.Series(0)
                ColumnSeries.LabelsAppearance.Visible = False

            End If

            If RadHtmlChart.PlotArea.Series.Count > 1 Then

                If TypeOf RadHtmlChart.PlotArea.Series(1) Is Telerik.Web.UI.LineSeries Then

                    LineSeries = RadHtmlChart.PlotArea.Series(1)
                    LineSeries.LabelsAppearance.Visible = False

                End If

            End If

        End If

        RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:N2}"
        TooltipClientTemplate = "#= series.name #, #= category #, #= kendo.format(\'{0:N2}\', value) #"

        If ColumnSeries IsNot Nothing Then

            ColumnSeries.TooltipsAppearance.ClientTemplate = TooltipClientTemplate

        End If

        If LineSeries IsNot Nothing Then

            LineSeries.TooltipsAppearance.ClientTemplate = TooltipClientTemplate

        End If

        RadHtmlChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -90

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub
    Public Function GetColumnChart_Comps(ByVal DataTable As System.Data.DataTable, Optional ByVal Caption As String = "", Optional ByVal Range As String = "", Optional ByVal Project As String = "",
                                         Optional ByVal Level As String = "", Optional ByVal Week As String = "", Optional ByVal Month As String = "", Optional ByVal Year As String = "",
                                         Optional ByVal Code As String = "", Optional ByVal DateRange As String = "", Optional ByVal Page As String = "", Optional ByVal Name As String = "") As Telerik.Web.UI.RadHtmlChart

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim LineSeries As Telerik.Web.UI.LineSeries = Nothing
        Dim ChartType As String
        Dim BaseURL As String = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Select Case Level

            Case "C"
                ChartType = "cli"

            Case "CD"
                ChartType = "div"

            Case "CDP"
                ChartType = "prd"

            Case "AE"
                ChartType = "acc"

            Case "dept"
                ChartType = "dept"

            Case "SC"
                ChartType = "sc"

            Case "JT"
                ChartType = "jt"

        End Select

        Try

            If DataTable.Rows.Count > 0 Then

                CleanDataTable(DataTable)

                RadHtmlChart = New Telerik.Web.UI.RadHtmlChart
                ColumnSeries = New Telerik.Web.UI.ColumnSeries
                ColumnSeries.Name = "Projects " & Project

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                If Range = "" Then

                    LineSeries = New Telerik.Web.UI.LineSeries
                    LineSeries.Name = "4 Week Avg"

                    RadHtmlChart.PlotArea.Series.Add(LineSeries)

                End If

                InitializeColumnChart_Comps(RadHtmlChart, Caption)

                If Range = "month" Then

                    RadHtmlChart.PlotArea.XAxis.DataLabelsField = DataTable.Columns(0).ColumnName

                    If Page = "year" Then

                        ColumnSeries.DataFieldY = DataTable.Columns(2).ColumnName

                    ElseIf Page = "month" Then

                        ColumnSeries.DataFieldY = DataTable.Columns(4).ColumnName

                    End If

                Else

                    RadHtmlChart.PlotArea.XAxis.DataLabelsField = DataTable.Columns(1).ColumnName
                    ColumnSeries.DataFieldY = DataTable.Columns(4).ColumnName

                End If

                If LineSeries IsNot Nothing Then

                    LineSeries.DataFieldY = DataTable.Columns(6).ColumnName
                    LineSeries.ColorField = "LineColor"

                End If

                ColumnSeries.ColorField = "Color"

                If Range = "month" Then

                    If Page = "year" Then

                        BaseURL = "DashboardProjectList.aspx?Group=0&code=" & Code.ToString.Replace("&", "andcode") & "&name=" & Name.ToString.Replace("&", "andcode").Replace("'", "") & "&month=" & Month & "&year=" & Year & "&type=" & ChartType & "&range=" & DateRange & "&week=" & Week & "&project=" & Project & "&level=" & Level & "&ddvalue=[" & DataTable.Columns(0).ColumnName & "]&page=" & Page

                        RadHtmlChart.Attributes("FIELDS") = DataTable.Columns(0).ColumnName

                    ElseIf Page = "month" Then

                        BaseURL = "DashboardProjectList.aspx?Group=0&code=" & Code.ToString.Replace("&", "andcode") & "&name=" & Name.ToString.Replace("&", "andcode").Replace("'", "") & "&month=" & Month & "&year=" & Year & "&type=" & ChartType & "&range=" & DateRange & "&week=" & Week & "&project=" & Project & "&level=" & Level & "&ddstart=[" & DataTable.Columns(1).ColumnName & "]&ddend=[" & DataTable.Columns(2).ColumnName & "]&page=" & Page

                        RadHtmlChart.Attributes("FIELDS") = DataTable.Columns(1).ColumnName & "," & DataTable.Columns(2).ColumnName

                    End If

                Else

                    BaseURL = "DashboardProjectList.aspx?Group=0&code=" & Code.ToString.Replace("&", "andcode") & "&name=" & Name.ToString.Replace("&", "andcode").Replace("'", "") & "&month=" & Month & "&year=" & Year & "&type=" & ChartType & "&range=" & DateRange & "&week=" & Week & "&project=" & Project & "&level=" & Level & "&ddstart=[" & DataTable.Columns(2).ColumnName & "]&ddend=[" & DataTable.Columns(3).ColumnName & "]&page=" & Page

                    RadHtmlChart.Attributes("FIELDS") = DataTable.Columns(2).ColumnName & "," & DataTable.Columns(3).ColumnName

                End If

                RadHtmlChart.Attributes("SERIES_CLICK_URL") = BaseURL

                DataTable.Columns.Add("Color")
                DataTable.Columns.Add("LineColor")


                For Each row In DataTable.Rows.OfType(Of System.Data.DataRow)()
                    row.Item("Color") = StandardColors(1)
                    row.Item("LineColor") = StandardColors(4)
                Next

                RadHtmlChart.DataSource = DataTable
                RadHtmlChart.DataBind()

            End If

        Catch ex As Exception
            RadHtmlChart = Nothing
        Finally
            GetColumnChart_Comps = RadHtmlChart
        End Try

    End Function

    Public Sub GetColumnChart_EmployeeByMonth(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), Optional ByVal Caption As String = "")

        'objects
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ChartColors As AdvantageFramework.Web.Presentation.Colors = Nothing
        Dim Colors As AdvantageFramework.Web.Presentation.Colors.Color() = Nothing
        Dim i As Integer = 0
        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            Colors = {AdvantageFramework.Web.Presentation.Colors.Color.Red,
                      AdvantageFramework.Web.Presentation.Colors.Color.Yellow,
                      AdvantageFramework.Web.Presentation.Colors.Color.Orange,
                      AdvantageFramework.Web.Presentation.Colors.Color.Green,
                      AdvantageFramework.Web.Presentation.Colors.Color.Blue}

            InitializeColumnChart_ClientTotals(RadHtmlChart, "")

            If EmployeeTimeForecastDetail IsNot Nothing Then

                If Caption = "DirectHours" Then

                End If
                If Caption = "ClientHours" Then

                End If
                If Caption = "AgencyHours" Then

                End If
                If Caption = "NewBusinessHours" Then

                End If
                If Caption = "IndirectHours" Then

                End If

                ColumnSeries = New Telerik.Web.UI.ColumnSeries
                ColumnSeries.Name = "ColumnSeries1"
                ColumnSeries.Stacked = False
                ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                ChartColors = New AdvantageFramework.Web.Presentation.Colors

                For Each EMT In EmployeeTimeForecastDetail

                    ColumnSeries.SeriesItems.Add(EMT.ActualHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                    i += 1
                Next

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                ColumnSeries = New Telerik.Web.UI.ColumnSeries
                ColumnSeries.Name = "ColumnSeries2"
                ColumnSeries.Stacked = False
                ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                ChartColors = New AdvantageFramework.Web.Presentation.Colors

                For Each EMT In EmployeeTimeForecastDetail

                    ColumnSeries.SeriesItems.Add(EMT.ClientHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                    i += 1
                Next

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                ColumnSeries = New Telerik.Web.UI.ColumnSeries
                ColumnSeries.Name = "ColumnSeries3"
                ColumnSeries.Stacked = False
                ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                ChartColors = New AdvantageFramework.Web.Presentation.Colors

                For Each EMT In EmployeeTimeForecastDetail

                    ColumnSeries.SeriesItems.Add(EMT.AgencyHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                    i += 1
                Next

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                ColumnSeries = New Telerik.Web.UI.ColumnSeries
                ColumnSeries.Name = "ColumnSeries4"
                ColumnSeries.Stacked = False
                ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                ChartColors = New AdvantageFramework.Web.Presentation.Colors

                For Each EMT In EmployeeTimeForecastDetail

                    ColumnSeries.SeriesItems.Add(EMT.NewBusinessHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                    i += 1
                Next

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                ColumnSeries = New Telerik.Web.UI.ColumnSeries
                ColumnSeries.Name = "ColumnSeries5"
                ColumnSeries.Stacked = False
                ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                ChartColors = New AdvantageFramework.Web.Presentation.Colors

                For Each EMT In EmployeeTimeForecastDetail

                    ColumnSeries.SeriesItems.Add(EMT.IndirectHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                    i += 1
                Next

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub GetDirectIndirectColumnChartETF(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), Optional ByVal Caption As String = "", Optional ByVal Type As String = "")

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ColumnSeries1 As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ColumnSeries2 As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ColumnSeries1Name As String = Nothing
        Dim ColumnSeries2Name As String = Nothing
        Dim ColumnSeries1SeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim ColumnSeries2SeriesItem As Telerik.Web.UI.SeriesItem = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()
            RadHtmlChart.Legend.Appearance.Visible = False

            InitializeTotalsColumnChart(RadHtmlChart, Caption)
            Dim i As Integer = 0

            If EmployeeTimeForecastDetail IsNot Nothing Then

                RadHtmlChart.PlotArea.XAxis.Items.Add("Direct vs. Indirect")

                'ColumnSeries1 = New Telerik.Web.UI.ColumnSeries
                'ColumnSeries1.Name = "Client"
                'ColumnSeries1.GroupName = "Direct"
                'ColumnSeries1.Stacked = True
                'ColumnSeries1.LabelsAppearance.DataFormatString = "{0:N2}"
                'ColumnSeries1.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                'For Each EMT In EmployeeTimeForecastDetail.Where(Function(Entity) Entity.Employee = "TotalsRow")
                '    ColumnSeries1.SeriesItems.Add(EMT.ClientHours, Drawing.ColorTranslator.FromHtml(StandardColors(i)))
                'Next

                'RadHtmlChart.PlotArea.Series.Add(ColumnSeries1)

                'i += 1
                'ColumnSeries1 = New Telerik.Web.UI.ColumnSeries
                'ColumnSeries1.Name = "Agency"
                'ColumnSeries1.GroupName = "Direct"
                'ColumnSeries1.Stacked = True
                'ColumnSeries1.LabelsAppearance.DataFormatString = "{0:N2}"
                'ColumnSeries1.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                'For Each EMT In EmployeeTimeForecastDetail.Where(Function(Entity) Entity.Employee = "TotalsRow")
                '    ColumnSeries1.SeriesItems.Add(EMT.AgencyHours, Drawing.ColorTranslator.FromHtml(StandardColors(i)))
                'Next

                'RadHtmlChart.PlotArea.Series.Add(ColumnSeries1)

                'i += 1
                'ColumnSeries1 = New Telerik.Web.UI.ColumnSeries
                'ColumnSeries1.Name = "New Business"
                'ColumnSeries1.GroupName = "Direct"
                'ColumnSeries1.Stacked = True
                'ColumnSeries1.LabelsAppearance.DataFormatString = "{0:N2}"
                'ColumnSeries1.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                'For Each EMT In EmployeeTimeForecastDetail.Where(Function(Entity) Entity.Employee = "TotalsRow")
                '    ColumnSeries1.SeriesItems.Add(EMT.NewBusinessHours, Drawing.ColorTranslator.FromHtml(StandardColors(i)))
                'Next

                'RadHtmlChart.PlotArea.Series.Add(ColumnSeries1)


                i += 1
                ColumnSeries1 = New Telerik.Web.UI.ColumnSeries
                ColumnSeries1.Name = "Direct"
                ColumnSeries1.GroupName = "Direct"
                ColumnSeries1.Stacked = True
                ColumnSeries1.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries1.LabelsAppearance.Visible = False
                ColumnSeries1.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                For Each EMT In EmployeeTimeForecastDetail.Where(Function(Entity) Entity.Employee = "TotalsRow")
                    ColumnSeries1.SeriesItems.Add(EMT.ActualHours, Drawing.ColorTranslator.FromHtml(StandardColors(i)))
                Next

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries1)

                i += 1
                For Each EMT In EmployeeTimeForecastDetail.Where(Function(Entity) Entity.Employee <> "TotalsRow")
                    ColumnSeries2 = New Telerik.Web.UI.ColumnSeries
                    ColumnSeries2.Name = EMT.Employee
                    ColumnSeries2.GroupName = "Indirect"
                    ColumnSeries2.Stacked = True
                    ColumnSeries2.LabelsAppearance.Visible = False
                    ColumnSeries2.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries2.LabelsAppearance.Visible = False
                    ColumnSeries2.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                    ColumnSeries2.SeriesItems.Add(EMT.IndirectHours, Drawing.ColorTranslator.FromHtml(StandardColors(i)))

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries2)
                    i += 1

                    If i = 11 Then
                        i = 0
                    End If

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub GetRequiredActualColumnChartETF(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), Optional ByVal Caption As String = "", Optional ByVal Type As String = "")

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ColumnSeries1 As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ColumnSeries2 As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ColumnSeries1Name As String = Nothing
        Dim ColumnSeries2Name As String = Nothing
        Dim ColumnSeries1SeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim ColumnSeries2SeriesItem As Telerik.Web.UI.SeriesItem = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            InitializeTotalsColumnChart(RadHtmlChart, Caption)

            If EmployeeTimeForecastDetail IsNot Nothing Then

                ColumnSeries1 = New Telerik.Web.UI.ColumnSeries
                ColumnSeries1.Name = "Required"
                ColumnSeries1.Stacked = False
                ColumnSeries1.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries1.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                For Each EMT In EmployeeTimeForecastDetail.Where(Function(Entity) Entity.Employee = "TotalsRow")
                    ColumnSeries1.SeriesItems.Add(EMT.RequiredHours, Drawing.ColorTranslator.FromHtml(StandardColors(1)))
                Next

                ColumnSeries1.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries1)

                ColumnSeries2 = New Telerik.Web.UI.ColumnSeries
                ColumnSeries2.Name = "Actual"
                ColumnSeries2.Stacked = False
                ColumnSeries2.LabelsAppearance.DataFormatString = "{0:N2}"
                ColumnSeries2.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                For Each EMT In EmployeeTimeForecastDetail.Where(Function(Entity) Entity.Employee = "TotalsRow")
                    ColumnSeries2.SeriesItems.Add(EMT.TotalHours, Drawing.ColorTranslator.FromHtml(StandardColors(4)))
                Next

                ColumnSeries2.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries2)

            End If

        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region " Bar "

    Public Sub InitializeDirectAndNonDirectBarChart(ByRef RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String)

        RadHtmlChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom
        'RadHtmlChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -45
        RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
        RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub
    Public Sub GetDirectAndNonDirectBarChart(ByRef RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, Optional ByVal Caption As String = "", Optional ByVal Type As String = "")

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DirectColumnSeries As Telerik.Web.UI.BarSeries = Nothing
        Dim NonDirectColumnSeries As Telerik.Web.UI.BarSeries = Nothing
        Dim DirectSeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim NonDirectSeriesItem As Telerik.Web.UI.SeriesItem = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            InitializeDirectAndNonDirectBarChart(RadHtmlChart, Caption)

            DataTable = New System.Data.DataTable

            If DataSet IsNot Nothing Then

                DataTable = DataSet.Tables(0)

            End If

            If DataTable.Rows.Count > 0 Then

                DirectColumnSeries = New Telerik.Web.UI.BarSeries
                NonDirectColumnSeries = New Telerik.Web.UI.BarSeries

                Select Case Type.ToLower

                    Case "fee"

                        DirectColumnSeries.Name = "Fee Amount"
                        NonDirectColumnSeries.Name = "Fee Time Amount"

                    Case "dept"

                        DirectColumnSeries.Name = "Direct"
                        NonDirectColumnSeries.Name = "Non Direct"

                End Select

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                    RadHtmlChart.PlotArea.XAxis.Items.Add(GetDataRowCellValue(DataRow(1)))

                    DirectSeriesItem = New Telerik.Web.UI.SeriesItem
                    DirectSeriesItem.YValue = GetDataRowCellValue(DataRow(2))
                    DirectSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", DirectColumnSeries.Name, GetDataRowCellValue(DataRow(1)), DirectSeriesItem.YValue)
                    DirectSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                    DirectColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                    DirectColumnSeries.Items.Add(DirectSeriesItem)

                    NonDirectSeriesItem = New Telerik.Web.UI.SeriesItem
                    NonDirectSeriesItem.YValue = GetDataRowCellValue(DataRow(3))
                    NonDirectSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", NonDirectColumnSeries.Name, GetDataRowCellValue(DataRow(1)), NonDirectSeriesItem.YValue)
                    NonDirectSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                    NonDirectColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                    NonDirectColumnSeries.Items.Add(NonDirectSeriesItem)

                Next

                RadHtmlChart.PlotArea.Series.Add(DirectColumnSeries)
                RadHtmlChart.PlotArea.Series.Add(NonDirectColumnSeries)

                For Each BarSeries In RadHtmlChart.PlotArea.Series.OfType(Of Telerik.Web.UI.BarSeries)()

                    BarSeries.Stacked = False
                    BarSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= category #, #= kendo.format(\'{0:N2}\', value) #"
                    BarSeries.LabelsAppearance.DataFormatString = "{0:N2}"


                Next

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub GetBudgetComparsionStackChart(ByRef RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ForcastedColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ActualColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim ForcastedSeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim ActualSeriesItem As Telerik.Web.UI.SeriesItem = Nothing
        Dim EmployeeTimeForecastDashboard As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeTimeForcastDashboard) = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()
            RadHtmlChart.Legend.Appearance.Visible = False

            InitializeDirectAndNonDirectBarChart(RadHtmlChart, "")

            'DataTable = New System.Data.DataTable

            'If DataSet IsNot Nothing Then

            '    DataTable = DataSet.Tables(0)

            'End If

            If EmployeeTimeForecastDetail.Count > 0 Then

                EmployeeTimeForecastDashboard = (From Entity In EmployeeTimeForecastDetail
                                                 Group Entity By Entity.ClientCode,
                                                       Entity.ClientName Into ETFD = Group
                                                 Select New AdvantageFramework.Dashboard.Classes.EmployeeTimeForcastDashboard(
                                                        ClientCode,
                                                        ClientName,
                                                        ETFD.Sum(Function(MPC) MPC.ForecastedHours),
                                                        ETFD.Sum(Function(MPC) MPC.ForecastedAmount),
                                                        ETFD.Sum(Function(MPC) MPC.ActualHours),
                                                        ETFD.Sum(Function(MPC) MPC.ActualAmount), 0)).ToList

                RadHtmlChart.PlotArea.XAxis.Items.Add("Budget vs. Actual Hours")

                Dim i As Integer = 0

                For Each ET In EmployeeTimeForecastDashboard

                    ForcastedColumnSeries = New Telerik.Web.UI.ColumnSeries
                    ForcastedColumnSeries.Name = ET.ClientName
                    ForcastedColumnSeries.GroupName = "Forecast"
                    ForcastedColumnSeries.LabelsAppearance.Visible = False

                    ForcastedSeriesItem = New Telerik.Web.UI.SeriesItem
                    ForcastedSeriesItem.YValue = ET.ForecastHours
                    ForcastedSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", ForcastedColumnSeries.Name, "Forecast", ForcastedSeriesItem.YValue)
                    ForcastedSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(i))

                    ForcastedColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(i))

                    i += 1

                    If i = 11 Then
                        i = 0
                    End If

                    ForcastedColumnSeries.Items.Add(ForcastedSeriesItem)
                    RadHtmlChart.PlotArea.Series.Add(ForcastedColumnSeries)

                Next

                'RadHtmlChart.PlotArea.XAxis.Items.Add("Actual")
                i = 0
                For Each ET In EmployeeTimeForecastDashboard

                    ActualColumnSeries = New Telerik.Web.UI.ColumnSeries
                    ActualColumnSeries.Name = ET.ClientName
                    ActualColumnSeries.GroupName = "Actual"
                    ActualColumnSeries.LabelsAppearance.Visible = False

                    ActualSeriesItem = New Telerik.Web.UI.SeriesItem
                    ActualSeriesItem.YValue = ET.ActualHours
                    ActualSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", ActualColumnSeries.Name, "Actual", ActualSeriesItem.YValue)
                    ActualSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(i))

                    ActualColumnSeries.Appearance.FillStyle.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(i))

                    i += 1

                    If i = 11 Then
                        i = 0
                    End If

                    ActualColumnSeries.Items.Add(ActualSeriesItem)
                    RadHtmlChart.PlotArea.Series.Add(ActualColumnSeries)

                Next

                'For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                '    'RadHtmlChart.PlotArea.XAxis.Items.Add(GetDataRowCellValue(DataRow(1)))

                '    DirectSeriesItem = New Telerik.Web.UI.SeriesItem
                '    DirectSeriesItem.YValue = GetDataRowCellValue(DataRow(2))
                '    DirectSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", DirectColumnSeries.Name, GetDataRowCellValue(DataRow(1)), DirectSeriesItem.YValue)
                '    DirectSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))

                '    DirectColumnSeries.Items.Add(DirectSeriesItem)

                '    NonDirectSeriesItem = New Telerik.Web.UI.SeriesItem
                '    NonDirectSeriesItem.YValue = GetDataRowCellValue(DataRow(3))
                '    NonDirectSeriesItem.TooltipValue = [String].Format("{0}, {1}, {2}", NonDirectColumnSeries.Name, GetDataRowCellValue(DataRow(1)), NonDirectSeriesItem.YValue)
                '    NonDirectSeriesItem.BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))

                '    NonDirectColumnSeries.Items.Add(NonDirectSeriesItem)

                'Next




                For Each ColumnSeries In RadHtmlChart.PlotArea.Series.OfType(Of Telerik.Web.UI.ColumnSeries)()

                    ColumnSeries.Stacked = True
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, " & ColumnSeries.GroupName & ", #= kendo.format(\'{0:N2}\', value) #"
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Line "

    Public Sub InitializeLineChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal Caption As String, Optional ByVal chartoption As String = "")

        If chartoption = "RiskAnalysis" Then
            RadHtmlChart.Legend.Appearance.Visible = True
            RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:N2}"
        Else
            RadHtmlChart.Legend.Appearance.Visible = False
            RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:N0}"
        End If

        RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
        RadHtmlChart.PlotArea.XAxis.MinorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.XAxis.MajorTickType = Telerik.Web.UI.HtmlChart.TickType.None
        RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

        If Not [String].IsNullOrWhiteSpace(Caption) Then

            RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

        Else

            RadHtmlChart.ChartTitle.Appearance.Visible = False

        End If

    End Sub

    Public Sub GetLineChart_EmployeeByMonth(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), Optional ByVal Caption As String = "")

        'objects
        Dim ColumnSeries As Telerik.Web.UI.LineSeries = Nothing
        Dim ChartColors As AdvantageFramework.Web.Presentation.Colors = Nothing
        Dim Colors As AdvantageFramework.Web.Presentation.Colors.Color() = Nothing
        Dim i As Integer = 0
        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            Colors = {AdvantageFramework.Web.Presentation.Colors.Color.Red,
                      AdvantageFramework.Web.Presentation.Colors.Color.Yellow,
                      AdvantageFramework.Web.Presentation.Colors.Color.Orange,
                      AdvantageFramework.Web.Presentation.Colors.Color.Green,
                      AdvantageFramework.Web.Presentation.Colors.Color.Blue}

            InitializeColumnChart_ClientTotals(RadHtmlChart, Caption)

            If EmployeeTimeForecastDetail IsNot Nothing Then

                If Caption = "DirectHours" Then
                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Stacked = False
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.ActualHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                        i += 1
                    Next

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                End If
                If Caption = "ClientHours" Then
                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "ColumnSeries2"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.ClientHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                        i += 1
                    Next

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                End If
                If Caption = "AgencyHours" Then
                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "ColumnSeries3"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.AgencyHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                        i += 1
                    Next

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                End If
                If Caption = "NewBusinessHours" Then
                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "ColumnSeries4"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.NewBusinessHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                        i += 1
                    Next

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                End If
                If Caption = "IndirectHours" Then
                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "ColumnSeries5"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.IndirectHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                        i += 1
                    Next

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetChart_EmployeeByMonth(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard), Optional ByVal Caption As String = "")

        'objects
        Dim ColumnSeries As Telerik.Web.UI.LineSeries = Nothing
        Dim ChartColors As AdvantageFramework.Web.Presentation.Colors = Nothing
        Dim Colors As AdvantageFramework.Web.Presentation.Colors.Color() = Nothing
        Dim i As Integer = 0
        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            Colors = {AdvantageFramework.Web.Presentation.Colors.Color.Red,
                      AdvantageFramework.Web.Presentation.Colors.Color.Yellow,
                      AdvantageFramework.Web.Presentation.Colors.Color.Orange,
                      AdvantageFramework.Web.Presentation.Colors.Color.Green,
                      AdvantageFramework.Web.Presentation.Colors.Color.Blue,
                      AdvantageFramework.Web.Presentation.Colors.Color.Teal}

            InitializeLineChart(RadHtmlChart, Caption)

            Dim month As String = ""

            For Each EMT In EmployeeTimeForecastDetail

                If month = "" Or month <> EMT.Month Then
                    RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)
                End If

                month = EMT.Month

            Next

            If Caption = "All" Then

                If EmployeeTimeForecastDetail IsNot Nothing Then

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Stacked = False
                    ColumnSeries.Name = "Total"
                    ColumnSeries.LineAppearance.Width = 2
                    ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.ActualHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        'RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)

                    Next

                    i += 1

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Stacked = False
                    ColumnSeries.Name = "Direct"
                    ColumnSeries.LineAppearance.Width = 2
                    ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.DirectHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        'RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)

                    Next

                    i += 1

                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "Client"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LineAppearance.Width = 2
                    ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.ClientHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        'RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)

                    Next

                    i += 1


                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "Agency"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LineAppearance.Width = 2
                    ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.AgencyHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        'RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)

                    Next

                    i += 1


                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "New Business"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LineAppearance.Width = 2
                    ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.NewBusinessHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        'RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)

                    Next

                    i += 1


                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    ColumnSeries = New Telerik.Web.UI.LineSeries
                    ColumnSeries.Name = "Indirect"
                    ColumnSeries.Stacked = False
                    ColumnSeries.LineAppearance.Width = 2
                    ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                    ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                    For Each EMT In EmployeeTimeForecastDetail

                        ColumnSeries.SeriesItems.Add(EMT.IndirectHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        ' RadHtmlChart.PlotArea.XAxis.Items.Add(EMT.Month)

                    Next

                    i += 1


                    RadHtmlChart.PlotArea.Series.Add(ColumnSeries)






                End If

            Else

                If EmployeeTimeForecastDetail IsNot Nothing Then

                    ChartColors = New AdvantageFramework.Web.Presentation.Colors

                    If Caption = "DirectHours" Then
                        ColumnSeries = New Telerik.Web.UI.LineSeries
                        ColumnSeries.Name = "Direct"
                        ColumnSeries.Stacked = False
                        ColumnSeries.LineAppearance.Width = 2
                        ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                        ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                        ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                        For Each EMT In EmployeeTimeForecastDetail

                            ColumnSeries.SeriesItems.Add(EMT.DirectHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                        Next

                        RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                    End If
                    If Caption = "ClientHours" Then
                        ColumnSeries = New Telerik.Web.UI.LineSeries
                        ColumnSeries.Name = "Client"
                        ColumnSeries.Stacked = False
                        ColumnSeries.LineAppearance.Width = 2
                        ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                        ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                        ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                        For Each EMT In EmployeeTimeForecastDetail

                            ColumnSeries.SeriesItems.Add(EMT.ClientHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                        Next

                        RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                    End If
                    If Caption = "AgencyHours" Then
                        ColumnSeries = New Telerik.Web.UI.LineSeries
                        ColumnSeries.Name = "Agency"
                        ColumnSeries.Stacked = False
                        ColumnSeries.LineAppearance.Width = 2
                        ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                        ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                        ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                        For Each EMT In EmployeeTimeForecastDetail

                            ColumnSeries.SeriesItems.Add(EMT.AgencyHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                        Next

                        RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                    End If
                    If Caption = "NewBusinessHours" Then
                        ColumnSeries = New Telerik.Web.UI.LineSeries
                        ColumnSeries.Name = "New Business"
                        ColumnSeries.Stacked = False
                        ColumnSeries.LineAppearance.Width = 2
                        ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                        ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                        ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                        For Each EMT In EmployeeTimeForecastDetail

                            ColumnSeries.SeriesItems.Add(EMT.NewBusinessHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                        Next

                        RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                    End If
                    If Caption = "IndirectHours" Then
                        ColumnSeries = New Telerik.Web.UI.LineSeries
                        ColumnSeries.Name = "Indirect"
                        ColumnSeries.Stacked = False
                        ColumnSeries.LineAppearance.Width = 2
                        ColumnSeries.Appearance.FillStyle.BackgroundColor = ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base)
                        ColumnSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                        ColumnSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= kendo.format(\'{0:N2}\', value) #"

                        For Each EMT In EmployeeTimeForecastDetail

                            ColumnSeries.SeriesItems.Add(EMT.IndirectHours, ChartColors.LoadColor(Colors(i), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                        Next

                        RadHtmlChart.PlotArea.Series.Add(ColumnSeries)
                    End If

                End If

            End If




        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetLineChart_Status(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal ds As DataSet, Optional ByVal Caption As String = "", Optional ByVal chartoption As Integer = 0, Optional ByVal chartdata As String = "",
    Optional ByVal charthours As String = "", Optional ByVal charttype As String = "", Optional ByVal burn As String = "", Optional ByVal group As String = "")

        'objects
        Dim LineSeries As Telerik.Web.UI.LineSeries = Nothing
        Dim LineSeries2 As Telerik.Web.UI.LineSeries = Nothing
        Dim LineSeries3 As Telerik.Web.UI.LineSeries = Nothing
        Dim ChartColors As AdvantageFramework.Web.Presentation.Colors = Nothing
        Dim Colors As AdvantageFramework.Web.Presentation.Colors.Color() = Nothing
        Dim i As Integer = 0
        Dim sum As Decimal = 0
        Dim sum2 As Decimal = 0
        Dim sum3 As Decimal = 0
        Dim sump As Decimal = 0
        Dim burnrate As Decimal = 0
        Dim burnrateMax As Decimal = 2

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            Colors = {AdvantageFramework.Web.Presentation.Colors.Color.Red,
                      AdvantageFramework.Web.Presentation.Colors.Color.Yellow,
                      AdvantageFramework.Web.Presentation.Colors.Color.Orange,
                      AdvantageFramework.Web.Presentation.Colors.Color.Green,
                      AdvantageFramework.Web.Presentation.Colors.Color.Blue}

            InitializeLineChart(RadHtmlChart, Caption, "RiskAnalysis")



            If ds.Tables(0).Rows.Count > 0 Then

                If chartoption = 0 Then
                    LineSeries = New Telerik.Web.UI.LineSeries
                    LineSeries.Name = "Quoted"
                    LineSeries.Stacked = False
                    LineSeries.LabelsAppearance.Visible = False
                    LineSeries.Appearance.FillStyle.BackgroundColor = Drawing.Color.Blue
                    LineSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    LineSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"
                    LineSeries.LineAppearance.Width = Unit.Pixel(5)

                    LineSeries2 = New Telerik.Web.UI.LineSeries
                    LineSeries2.Name = "Planned/Adjusted"
                    LineSeries2.Stacked = False
                    LineSeries2.LabelsAppearance.Visible = False
                    LineSeries2.Appearance.FillStyle.BackgroundColor = Drawing.Color.Red
                    LineSeries2.LabelsAppearance.DataFormatString = "{0:N2}"
                    LineSeries2.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"
                    LineSeries2.LineAppearance.Width = Unit.Pixel(5)

                    LineSeries3 = New Telerik.Web.UI.LineSeries
                    LineSeries3.Name = "Actual"
                    LineSeries3.Stacked = False
                    LineSeries3.LabelsAppearance.Visible = False
                    LineSeries3.Appearance.FillStyle.BackgroundColor = Drawing.Color.Green
                    LineSeries3.LabelsAppearance.DataFormatString = "{0:N2}"
                    LineSeries3.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"
                    LineSeries3.LineAppearance.Width = Unit.Pixel(5)
                ElseIf chartoption = 1 Then

                    LineSeries = New Telerik.Web.UI.LineSeries
                    LineSeries.Name = "Burn Rate"
                    LineSeries.Stacked = False
                    LineSeries.LabelsAppearance.Visible = False
                    LineSeries.Appearance.FillStyle.BackgroundColor = Drawing.Color.Blue
                    LineSeries.LabelsAppearance.DataFormatString = "{0:N2}"
                    LineSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"
                    LineSeries.LineAppearance.Width = Unit.Pixel(5)

                End If

                For i = 0 To ds.Tables(0).Rows.Count - 1

                    If chartdata = "Hours" Then
                        If chartoption = 0 Then
                            'Quoted
                            If charttype = "Monthly" Then
                                LineSeries.SeriesItems.Add(ds.Tables(0).Rows(i)(4), Drawing.Color.Blue)
                            ElseIf charttype = "Cumulative" Then
                                sum += CDec(ds.Tables(0).Rows(i)(4))
                                LineSeries.SeriesItems.Add(sum, Drawing.Color.Blue)
                            End If
                            'Planned/Adjusted
                            If charthours = "ETF" Then
                                If charttype = "Monthly" Then
                                    LineSeries2.SeriesItems.Add(ds.Tables(0).Rows(i)(6), Drawing.Color.Red)
                                ElseIf charttype = "Cumulative" Then
                                    sum2 += CDec(ds.Tables(0).Rows(i)(6))
                                    LineSeries2.SeriesItems.Add(sum2, Drawing.Color.Yellow)
                                End If
                            ElseIf charthours = "Allowed" Then
                                If charttype = "Monthly" Then
                                    LineSeries2.SeriesItems.Add(ds.Tables(0).Rows(i)(8), Drawing.Color.Red)
                                ElseIf charttype = "Cumulative" Then
                                    sum2 += CDec(ds.Tables(0).Rows(i)(8))
                                    LineSeries2.SeriesItems.Add(sum2, Drawing.Color.Yellow)
                                End If
                            End If
                            'Actual
                            If charttype = "Monthly" Then
                                LineSeries3.SeriesItems.Add(ds.Tables(0).Rows(i)(10), Drawing.Color.Green)
                            ElseIf charttype = "Cumulative" Then
                                sum3 += CDec(ds.Tables(0).Rows(i)(10))
                                LineSeries3.SeriesItems.Add(sum3, Drawing.Color.Green)
                            End If
                        ElseIf chartoption = 1 Then
                            If burn = "Planned" Then
                                If charthours = "ETF" Then
                                    If charttype = "Monthly" Then
                                        LineSeries.SeriesItems.Add(ds.Tables(0).Rows(i)(12), Drawing.Color.Blue)
                                        burnrate = CDec(ds.Tables(0).Rows(i)(12))
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(ds.Tables(0).Rows(i)(10))
                                        sump += CDec(ds.Tables(0).Rows(i)(6))
                                        If sump > 0 Then
                                            LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                            burnrate = sum / sump
                                        Else
                                            LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                        End If
                                    End If
                                ElseIf charthours = "Allowed" Then
                                    If charttype = "Monthly" Then
                                        LineSeries.SeriesItems.Add(ds.Tables(0).Rows(i)(14), Drawing.Color.Blue)
                                        burnrate = CDec(ds.Tables(0).Rows(i)(14))
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(ds.Tables(0).Rows(i)(10))
                                        sump += CDec(ds.Tables(0).Rows(i)(8))
                                        If sump > 0 Then
                                            LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                            burnrate = sum / sump
                                        Else
                                            LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                        End If
                                    End If
                                End If
                            ElseIf burn = "Quoted" Then
                                If charttype = "Monthly" Then
                                    sum = CDec(ds.Tables(0).Rows(i)(10))
                                    sump = CDec(ds.Tables(0).Rows(i)(4))
                                    If sump > 0 Then
                                        LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                        burnrate = sum / sump
                                    Else
                                        LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                    End If
                                ElseIf charttype = "Cumulative" Then
                                    sum += CDec(ds.Tables(0).Rows(i)(10))
                                    sump += CDec(ds.Tables(0).Rows(i)(4))
                                    If sump > 0 Then
                                        LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                        burnrate = sum / sump
                                    Else
                                        LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                    End If
                                End If
                            End If
                        End If
                    ElseIf chartdata = "Dollars" Then
                        If chartoption = 0 Then
                            'QUoted
                            If charttype = "Monthly" Then
                                LineSeries.SeriesItems.Add(ds.Tables(0).Rows(i)(5), Drawing.Color.Blue)
                            ElseIf charttype = "Cumulative" Then
                                sum += CDec(ds.Tables(0).Rows(i)(5))
                                LineSeries.SeriesItems.Add(sum, Drawing.Color.Blue)
                            End If
                            'Planned/Adjusted
                            If charthours = "ETF" Then
                                If charttype = "Monthly" Then
                                    LineSeries2.SeriesItems.Add(ds.Tables(0).Rows(i)(7), Drawing.Color.Red)
                                ElseIf charttype = "Cumulative" Then
                                    sum2 += CDec(ds.Tables(0).Rows(i)(7))
                                    LineSeries2.SeriesItems.Add(sum2, Drawing.Color.Yellow)
                                End If
                            ElseIf charthours = "Allowed" Then
                                If charttype = "Monthly" Then
                                    LineSeries2.SeriesItems.Add(ds.Tables(0).Rows(i)(9), Drawing.Color.Red)
                                ElseIf charttype = "Cumulative" Then
                                    sum2 += CDec(ds.Tables(0).Rows(i)(9))
                                    LineSeries2.SeriesItems.Add(sum2, Drawing.Color.Yellow)
                                End If
                            End If
                            'Actual
                            If charttype = "Monthly" Then
                                LineSeries3.SeriesItems.Add(ds.Tables(0).Rows(i)(11), Drawing.Color.Green)
                            ElseIf charttype = "Cumulative" Then
                                sum3 += CDec(ds.Tables(0).Rows(i)(11))
                                LineSeries3.SeriesItems.Add(sum3, Drawing.Color.Green)
                            End If
                        ElseIf chartoption = 1 Then
                            If burn = "Planned" Then
                                If charthours = "ETF" Then
                                    If charttype = "Monthly" Then
                                        LineSeries.SeriesItems.Add(ds.Tables(0).Rows(i)(13), Drawing.Color.Blue)
                                        burnrate = CDec(ds.Tables(0).Rows(i)(13))
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(ds.Tables(0).Rows(i)(11))
                                        sump += CDec(ds.Tables(0).Rows(i)(7))
                                        If sump > 0 Then
                                            LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                            burnrate = sum / sump
                                        Else
                                            LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                        End If
                                    End If
                                ElseIf charthours = "Allowed" Then
                                    If charttype = "Monthly" Then
                                        LineSeries.SeriesItems.Add(ds.Tables(0).Rows(i)(15), Drawing.Color.Blue)
                                        burnrate = CDec(ds.Tables(0).Rows(i)(15))
                                    ElseIf charttype = "Cumulative" Then
                                        sum += CDec(ds.Tables(0).Rows(i)(11))
                                        sump += CDec(ds.Tables(0).Rows(i)(9))
                                        If sump > 0 Then
                                            LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                            burnrate = sum / sump
                                        Else
                                            LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                        End If
                                    End If
                                End If
                            ElseIf burn = "Quoted" Then
                                If charttype = "Monthly" Then
                                    sum = CDec(ds.Tables(0).Rows(i)(11))
                                    sump = CDec(ds.Tables(0).Rows(i)(5))
                                    If sump > 0 Then
                                        LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                        burnrate = sum / sump
                                    Else
                                        LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                    End If
                                ElseIf charttype = "Cumulative" Then
                                    sum += CDec(ds.Tables(0).Rows(i)(11))
                                    sump += CDec(ds.Tables(0).Rows(i)(5))
                                    If sump > 0 Then
                                        LineSeries.SeriesItems.Add(String.Format("{0:#,##0.00}", sum / sump), Drawing.Color.Blue)
                                        burnrate = sum / sump
                                    Else
                                        LineSeries.SeriesItems.Add(0.00, Drawing.Color.Blue)
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If group = "Month" Then
                        RadHtmlChart.PlotArea.XAxis.Items.Add(MonthName(ds.Tables(0).Rows(i)(2)))
                    ElseIf group = "Week" Then
                        RadHtmlChart.PlotArea.XAxis.Items.Add(CDate(ds.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString)
                    End If

                    If burnrate > burnrateMax Then
                        burnrateMax = burnrate
                    End If

                Next

                If chartoption = 0 Then
                    RadHtmlChart.PlotArea.Series.Add(LineSeries)
                    RadHtmlChart.PlotArea.Series.Add(LineSeries2)
                    RadHtmlChart.PlotArea.Series.Add(LineSeries3)
                ElseIf chartoption = 1 Then
                    RadHtmlChart.PlotArea.Series.Add(LineSeries)

                    Dim plotband As Telerik.Web.UI.PlotBand
                    plotband = New Telerik.Web.UI.PlotBand

                    plotband.From = 1
                    plotband.To = 1.01
                    plotband.Color = Drawing.Color.Red
                    RadHtmlChart.PlotArea.YAxis.PlotBands.Add(plotband)
                    RadHtmlChart.PlotArea.YAxis.MaxValue = burnrateMax + 2
                End If



            End If

        Catch ex As Exception

        End Try

    End Sub


#End Region


    ''' <summary>
    ''' Removes special characters from Column Names
    ''' Use when databinding to RadHTMLChart
    ''' </summary>
    ''' <param name="DataTable"></param>
    ''' <remarks></remarks>
    Private Sub CleanDataTable(ByRef DataTable As System.Data.DataTable)

        Dim BadChars As Char() = {"(", ")", "[", "]", ".", "/", "\", " ", ",", "&", "-", "'"}

        For Each GridColumn In DataTable.Columns.OfType(Of System.Data.DataColumn)()

            GridColumn.ColumnName = String.Concat(GridColumn.ColumnName.Split(BadChars, System.StringSplitOptions.RemoveEmptyEntries))

        Next

    End Sub
    Private Function GetDataRowCellValue(ByVal Value As Object) As Object

        If IsDBNull(Value) Then

            Return Nothing

        Else

            Return Value

        End If

    End Function

#End Region

    Public Shared Function getFCXMLData_MultiColumn3D_Departments(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "") As String
        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                dt = dsForGraph.Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' numDivLines='4' legendPosition='BOTTOM' labelDisplay='Rotate' slantLabels='1' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                    ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' numDivLines='4' legendPosition='BOTTOM' labelDisplay='Rotate' slantLabels='1' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                    Else
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' numDivLines='4' legendPosition='BOTTOM' labelDisplay='Rotate' slantLabels='1'>")
                    End If

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<category label='" & dt.Rows(i)(1) & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    .Append("<dataset seriesName='Direct'>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(2) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Completed:
                    .Append("<dataset seriesName='Non Direct'>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function getFCXMLData_MultiColumn3D_Totals(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String

        '
        ' If converting this Chart, use GetTotalsColumnChart()
        ' 

        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                dt = dsForGraph.Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' decimalPrecision='2' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='0' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                    ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' decimalPrecision='2' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='0' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                    Else
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' decimalPrecision='2' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='0'>")
                    End If

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<category label='" & dt.Rows(i)(1) & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    If type = "direct" Then
                        .Append("<dataset seriesName='Total'>")
                    End If
                    If type = "bill" Or type = "agency" Or type = "newbusiness" Or type = "billed" Then
                        .Append("<dataset seriesName='Direct'>")
                    End If
                    If type = "nondirect" Then
                        .Append("<dataset seriesName='Non Direct'>")
                    End If
                    If type = "required" Then
                        .Append("<dataset seriesName='Required'>")
                    End If
                    If type = "Goal" Or type = "billedgoal" Then
                        .Append("<dataset seriesName='Goal'>")
                    End If
                    If type = "client" Or type = "billable" Then
                        .Append("<dataset seriesName='Billable'>")
                    End If
                    If type = "standard" Then
                        .Append("<dataset seriesName='Standard'>")
                    End If
                    If type = "directgoalbilled" Then
                        .Append("<dataset seriesName='Goal'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(2) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Completed:
                    If type = "nonbill" Or type = "client" Then
                        .Append("<dataset seriesName='Non Billable'>")
                    ElseIf type = "Goal" Or type = "bill" Then
                        .Append("<dataset seriesName='Billable'>")
                    ElseIf type = "agency" Then
                        .Append("<dataset seriesName='Agency'>")
                    ElseIf type = "newbusiness" Then
                        .Append("<dataset seriesName='New Business'>")
                    ElseIf type = "billed" Or type = "billable" Or type = "billedgoal" Or type = "directgoalbilled" Then
                        .Append("<dataset seriesName='Billed'>")
                    ElseIf type = "standard" Then
                        .Append("<dataset seriesName='Goal'>")
                    ElseIf type = "direct" Then
                        .Append("<dataset seriesName='Direct'>")
                    Else
                        .Append("<dataset seriesName='Total'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function getFCXMLData_MultiColumn3D_TotalHours(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String
        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                dt = dsForGraph.Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='0'>")

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<category label='" & dt.Rows(i)(1) & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    If type = "direct" Then
                        .Append("<dataset seriesName='Total'>")
                    End If
                    If type = "bill" Or type = "agency" Or type = "newbusiness" Or type = "billed" Then
                        .Append("<dataset seriesName='Direct'>")
                    End If
                    If type = "nondirect" Then
                        .Append("<dataset seriesName='Non Direct'>")
                    End If
                    If type = "required" Then
                        .Append("<dataset seriesName='Required'>")
                    End If
                    If type = "Goal" Or type = "billedgoal" Then
                        .Append("<dataset seriesName='Goal'>")
                    End If
                    If type = "client" Or type = "billable" Then
                        .Append("<dataset seriesName='Billable'>")
                    End If
                    If type = "standard" Then
                        .Append("<dataset seriesName='Standard'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(2) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Completed:
                    If type = "nonbill" Or type = "client" Then
                        .Append("<dataset seriesName='Non Billable'>")
                    ElseIf type = "Goal" Or type = "bill" Then
                        .Append("<dataset seriesName='Billable'>")
                    ElseIf type = "agency" Then
                        .Append("<dataset seriesName='Agency'>")
                    ElseIf type = "newbusiness" Then
                        .Append("<dataset seriesName='New Business'>")
                    ElseIf type = "billed" Or type = "billable" Or type = "billedgoal" Then
                        .Append("<dataset seriesName='Billed'>")
                    ElseIf type = "standard" Then
                        .Append("<dataset seriesName='Goal'>")
                    ElseIf type = "direct" Then
                        .Append("<dataset seriesName='Direct'>")
                    Else
                        .Append("<dataset seriesName='Total'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function getFCXMLData_Bar3D_Totals(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String
        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                dt = dsForGraph.Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='1' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                    ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='1' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                    Else
                        .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='1'>")
                    End If

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<category label='" & dt.Rows(i)(1) & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    If type = "fee" Then
                        .Append("<dataset seriesName='Fee Amount'>")
                    End If
                    If type = "Dept" Then
                        .Append("<dataset seriesName='Direct'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(2) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Completed:
                    If type = "fee" Then
                        .Append("<dataset seriesName='Fee Time Amount'>")
                    End If
                    If type = "Dept" Then
                        .Append("<dataset seriesName='Non Direct'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function getFCXMLData_BarPie(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String
                If isPie = False Then
                    sbFCXMLData.Append("<graph bgcolor='FFFFFF' caption='" & strCaption & "' shownames='0' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix=''>" & vbCrLf)
                Else
                    sbFCXMLData.Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' showLabels='1' showNames='1' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35'>" & vbCrLf)
                End If

                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                    If dsForGraph.Tables(0).Rows(i).Item(strValueField) <> 0 Then
                        sbFCXMLData.Append("<set name='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString() & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "'/>" & vbCrLf)
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</graph>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_Pie(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False, Optional ByVal client As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal emp As String = "") As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String                
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' animation='0' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' animation='0' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' animation='0' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35'>" & vbCrLf)
                End If


                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                    If dsForGraph.Tables(0).Rows(i).Item(strValueField) <> 0 Then
                        sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString().Replace("'", "") & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "' tooltext='Hours: " & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "'/>" & vbCrLf)
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Pie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_PieRealization(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False, Optional ByVal client As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal emp As String = "", Optional ByVal month2 As String = "", Optional ByVal period As Integer = 0) As String

        '
        ' use new pie = GetPieChart_Realization()
        '

        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String                
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35'>" & vbCrLf)
                End If


                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                    If dsForGraph.Tables(0).Rows(i).Item(strValueField) <> 0 Then
                        sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString.Replace("'", "") & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "' link='DashboardRealizationClient.aspx%3FGroup%3D0%26client%3D" & dsForGraph.Tables(0).Rows(i).Item("CLIENT") & "%26month%3D" & month & "%26year%3D" & year & "%26emp%3D" & emp & "%26month2%3D" & month2 & "%26billed%3D" & period & "' tooltext='Billed Amount: $" & String.Format("{0:#,##0.00}", dsForGraph.Tables(0).Rows(i).Item(strValueField)) & "'/>" & vbCrLf)
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Pie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_PieDirectHours(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False, Optional ByVal client As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal emp As String = "") As String
        '
        ' New Chart = GetPieChart_DirectHours()
        '

        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String                

                If LoGlo.UserCultureGet() = "fr-FR" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35'>" & vbCrLf)
                End If


                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Columns.Count - 1
                    If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                        sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Columns(i).ColumnName & "' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "' tooltext='Hours: " & dsForGraph.Tables(0).Rows(0).Item(i) & "'/>" & vbCrLf)
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Pie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_PieProjects(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False, Optional ByVal client As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal emp As String = "") As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String                
                sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35'>" & vbCrLf)


                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 1 To dsForGraph.Tables(0).Columns.Count - 1
                    If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                        sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Columns(i).ColumnName & "' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "' tooltext='Projects: " & dsForGraph.Tables(0).Rows(0).Item(i) & "'/>" & vbCrLf)
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Pie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_PieByLevel(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False, Optional ByVal week As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal range As String = "", Optional ByVal level As String = "", Optional ByVal toolstr As String = "") As String

        '
        ' use new chart = GetPieChart_ByLevel()
        '

        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue

            Dim type As String
            If strNameField = "CL_NAME" Then
                type = "cli"
            End If
            If strNameField = "DIV_NAME" Then
                type = "div"
            End If
            If strNameField = "PRD_DESCRIPTION" Then
                type = "prd"
            End If
            If strNameField = "ACCT_NAME" Then
                type = "acc"
            End If
            If strNameField = "DP_TM_DESC" Then
                type = "dept"
            End If
            If strNameField = "SC_DESCRIPTION" Then
                type = "sc"
            End If
            If strNameField = "JT_DESC" Then
                type = "jt"
            End If

            With sbFCXMLData
                'Initialize the XML String                
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    .Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' formatNumber='1' exportEnabled='1' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    .Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' formatNumber='1' exportEnabled='1' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    .Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' formatNumber='1' exportEnabled='1'>" & vbCrLf)
                End If

                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                    If dsForGraph.Tables(0).Rows(i).Item(strValueField) <> 0 Then
                        If type = "div" Then
                            sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString.Replace("'", "") & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "' link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & dsForGraph.Tables(0).Rows(i).Item(0).ToString.Replace("&", "andcode") & ",%26name%3D" & dsForGraph.Tables(0).Rows(i).Item(1).ToString.Replace("&", "andcode").Replace("'", "") & "%26divcode%3D" & dsForGraph.Tables(0).Rows(i).Item(2).ToString.Replace("&", "andcode") & "%26divname%3D" & dsForGraph.Tables(0).Rows(i).Item(3).ToString.Replace("&", "andcode").Replace("'", "") & "%26prdcode%3D%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & range & "%26week%3D" & week & "%26project%3D" & strValueField & "%26level%3D" & level & "'  tooltext='" & toolstr & ": " & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "'/>")
                        ElseIf type = "prd" Then
                            sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString.Replace("'", "") & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "' link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & dsForGraph.Tables(0).Rows(i).Item(0).ToString.Replace("&", "andcode") & ",%26name%3D" & dsForGraph.Tables(0).Rows(i).Item(1).ToString.Replace("&", "andcode").Replace("'", "") & "%26divcode%3D" & dsForGraph.Tables(0).Rows(i).Item(2).ToString.Replace("&", "andcode") & "%26divname%3D" & dsForGraph.Tables(0).Rows(i).Item(3).ToString.Replace("&", "andcode").Replace("'", "") & "%26prdcode%3D" & dsForGraph.Tables(0).Rows(i).Item(4).ToString.Replace("&", "andcode") & "%26prdname%3D" & dsForGraph.Tables(0).Rows(i).Item(5).ToString.Replace("&", "andcode").Replace("'", "") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & range & "%26week%3D" & week & "%26project%3D" & strValueField & "%26level%3D" & level & "'  tooltext='" & toolstr & ": " & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "'/>")
                        Else
                            sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString.Replace("'", "") & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "' link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & dsForGraph.Tables(0).Rows(i).Item(0).ToString.Replace("&", "andcode") & ",%26name%3D" & dsForGraph.Tables(0).Rows(i).Item(1).ToString.Replace("&", "andcode").Replace("'", "") & "%26divcode%3D%26prdcode%3D%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & range & "%26week%3D" & week & "%26project%3D" & strValueField & "%26level%3D" & level & "'  tooltext='" & toolstr & ": " & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "'/>" & vbCrLf)
                        End If

                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "<chart></chart>"
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_PieByLevelClient(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False, Optional ByVal week As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal range As String = "", Optional ByVal level As String = "", Optional ByVal toolstr As String = "", Optional ByVal datatype As String = "") As String

        '
        ' use new chart = GetPieChart_ByLevelClient()
        '


        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue

            Dim type As String
            If strNameField = "CL_NAME" Then
                type = "cli"
            End If
            If strNameField = "DIV_NAME" Then
                type = "div"
            End If
            If strNameField = "PRD_DESCRIPTION" Then
                type = "prd"
            End If
            If strNameField = "ACCT_NAME" Then
                type = "acc"
            End If
            If strNameField = "DP_TM_DESC" Then
                type = "dept"
            End If
            If strNameField = "SC_DESCRIPTION" Then
                type = "sc"
            End If
            If strNameField = "JT_DESC" Then
                type = "jt"
            End If

            With sbFCXMLData
                'Initialize the XML String    
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' formatNumber='1' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' formatNumber='1' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    sbFCXMLData.Append("<chart caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' formatNumber='1'>" & vbCrLf)
                End If


                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                    If dsForGraph.Tables(0).Rows(i).Item(strValueField) <> 0 Then
                        sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString.Replace("'", "") & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "' tooltext='" & toolstr & String.Format("{0:#,##0.00}", dsForGraph.Tables(0).Rows(i).Item(strValueField)) & "' />" & vbCrLf)
                    End If
                Next
                'link='DashboardClientList.aspx%3FGroup%3D0%26code%3D" & dsForGraph.Tables(0).Rows(i).Item(0).ToString.Replace("&", "andcode") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & range & "%26week%3D" & week & "%26project%3D" & strValueField & "%26level%3D" & level & "%26datatype%3D" & datatype & "'
                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Pie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_Bar(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String                
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    sbFCXMLData.Append("<chart bgcolor='FFFFFF' caption='" & strCaption & "' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix='' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    sbFCXMLData.Append("<chart bgcolor='FFFFFF' caption='" & strCaption & "' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix='' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    sbFCXMLData.Append("<chart bgcolor='FFFFFF' caption='" & strCaption & "' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix=''>" & vbCrLf)
                End If


                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                    If dsForGraph.Tables(0).Rows(i).Item(strValueField) <> 0 Then
                        sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString() & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "'/>" & vbCrLf)
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Pie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_BarClientTotals(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String

        '
        ' new chart = GetColumnChart_ClientTotals()
        '

        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String                
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    sbFCXMLData.Append("<chart bgcolor='FFFFFF' caption='" & strCaption & "' formatNumberScale='0' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix='' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    sbFCXMLData.Append("<chart bgcolor='FFFFFF' caption='" & strCaption & "' formatNumberScale='0' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix='' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    sbFCXMLData.Append("<chart bgcolor='FFFFFF' caption='" & strCaption & "' formatNumberScale='0' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix=''>" & vbCrLf)
                End If


                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Columns.Count - 1
                    If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                        sbFCXMLData.Append("<set label='" & dsForGraph.Tables(0).Columns(i).ColumnName() & "' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'/>" & vbCrLf)
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</chart>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Pie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_Gauge(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String

        '
        ' If converting this Chart, use GetGauge()
        '

        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue


            With sbFCXMLData
                'Initialize the XML String                
                'sbFCXMLData.Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='0' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35'>" & vbCrLf)
                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                If dsForGraph.Tables(0).Rows.Count > 0 Then
                    For i = 0 To dsForGraph.Tables(0).Rows.Count - 1 '
                        Dim total As Integer
                        Dim direct As Integer
                        If type = "direct" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("TOTAL_HOURS")
                            direct = dsForGraph.Tables(0).Rows(i).Item("DIRECT")
                        End If
                        If type = "goal" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("GOAL")
                            direct = dsForGraph.Tables(0).Rows(i).Item("BILLABLE")
                        End If
                        If type = "required" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("REQUIRED")
                            direct = dsForGraph.Tables(0).Rows(i).Item("TOTAL_HOURS")
                        End If
                        If type = "billable" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("DIRECT")
                            direct = dsForGraph.Tables(0).Rows(i).Item("BILLABLE")
                        End If
                        If type = "directbilled" Or type = "directgoal" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("DIRECT")
                            direct = dsForGraph.Tables(0).Rows(i).Item("BILLED")
                        End If
                        If type = "billedbillable" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("BILLABLE")
                            direct = dsForGraph.Tables(0).Rows(i).Item("BILLED")
                        End If
                        If type = "goalstandard" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("REQUIRED")
                            direct = dsForGraph.Tables(0).Rows(i).Item("GOAL")
                        End If
                        If type = "billedgoal" Then
                            total = dsForGraph.Tables(0).Rows(i).Item("GOAL")
                            direct = dsForGraph.Tables(0).Rows(i).Item("BILLED")
                        End If
                        If LoGlo.UserCultureGet() = "fr-FR" Then
                            sbFCXMLData.Append("<chart upperLimit='100' lowerLimit='0' numberSuffix='%25' decimalPrecision='0' gaugeInnerRadius='0' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                        ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                            sbFCXMLData.Append("<chart upperLimit='100' lowerLimit='0' numberSuffix='%25' decimalPrecision='0' gaugeInnerRadius='0' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                        Else
                            sbFCXMLData.Append("<chart upperLimit='100' lowerLimit='0' numberSuffix='%25' decimalPrecision='0' gaugeInnerRadius='0' >" & vbCrLf)
                        End If
                        sbFCXMLData.Append("<colorRange>" & vbCrLf)
                        sbFCXMLData.Append("<color minValue='0' maxValue='30' name='Bad' code='AA0000' />" & vbCrLf)
                        sbFCXMLData.Append("<color minValue='30' maxValue='70' name='Average' code='F6BD0F' />" & vbCrLf)
                        sbFCXMLData.Append("<color minValue='70' maxValue='100' name='Average' code='005500' />" & vbCrLf)
                        sbFCXMLData.Append("</colorRange>" & vbCrLf)
                        sbFCXMLData.Append("<dials>" & vbCrLf)
                        sbFCXMLData.Append("<dial value='" & (direct / total) * 100 & "' />" & vbCrLf)
                        sbFCXMLData.Append("</dials>" & vbCrLf)
                        'sbFCXMLData.Append("<chart upperLimit='" & total.ToString()& "' lowerLimit='0' numberSuffix='%25' decimalPrecision='0'>" & vbCrLf)
                        'sbFCXMLData.Append("<colorRange>" & vbCrLf)
                        'sbFCXMLData.Append("<color minValue='0' maxValue='" & (total / 3).ToString()& "' name='Bad' code='FF0000' />" & vbCrLf)
                        'sbFCXMLData.Append("<color minValue='" & (total / 3).ToString()& "' maxValue='" & ((total / 3) + (total / 3)).ToString()& "' name='Average' code='FFFF00' />" & vbCrLf)
                        'sbFCXMLData.Append("<color minValue='" & ((total / 3) + (total / 3)).ToString()& "' maxValue='" & total.ToString()& "' name='Average' code='00FF00' />" & vbCrLf)
                        'sbFCXMLData.Append("</colorRange>" & vbCrLf)
                        'sbFCXMLData.Append("<dials>" & vbCrLf)
                        'sbFCXMLData.Append("<dial value='" & dsForGraph.Tables(0).Rows(i).Item("DIRECT").ToString()& "' />" & vbCrLf)
                        'sbFCXMLData.Append("</dials>" & vbCrLf)
                    Next
                    'End the XML data by adding the closing </graph> element
                    sbFCXMLData.Append("</chart>")
                Else
                    sbFCXMLData.Append("<chart upperLimit='100' lowerLimit='0' numberSuffix='%25' decimalPrecision='0' gaugeInnerRadius='0'>" & vbCrLf)
                    sbFCXMLData.Append("</chart>")
                End If
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_Gauge Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function getFCXMLData_LinearGauge(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String

        '
        ' use new gauge = GetLinearGauge()
        '

        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim good As Integer
        Dim ok As Integer
        Dim bad As Integer
        Dim client As Integer = 0
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                If dsForGraph.Tables.Count > 1 Then
                    dt = dsForGraph.Tables(1)
                    client = 1
                Else
                    dt = dsForGraph.Tables(0)
                End If
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    Dim tick As Integer
                    If client = 1 Then
                        ok = CInt(dt.Rows(0)(0)) - (CInt(dt.Rows(0)(0)) / 4)
                        bad = CInt(dt.Rows(0)(0))
                        tick = bad + bad
                    Else
                        ok = CInt(dt.Rows(0)(2)) - (CInt(dt.Rows(0)(2)) / 4)
                        bad = CInt(dt.Rows(0)(2))
                        tick = bad + bad
                    End If

                    'Open chart:
                    '.Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='1' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='1'>")
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<chart bgColor='FFFFFF' bgAlpha='0' showBorder='0' upperLimit='" & tick.ToString() & "' lowerLimit='0' gaugeRoundRadius='5' chartBottomMargin='10' ticksBelowGauge='0' showGaugeLabels='0' valueAbovePointer='0' pointerOnTop='1' pointerRadius='9' animation='1' showTickMarks='1' showTickValues='1' numberPrefix='$' formatNumber='1' formatNumberScale='0' chartRightMargin='50' chartLeftMargin='50' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                    ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<chart bgColor='FFFFFF' bgAlpha='0' showBorder='0' upperLimit='" & tick.ToString() & "' lowerLimit='0' gaugeRoundRadius='5' chartBottomMargin='10' ticksBelowGauge='0' showGaugeLabels='0' valueAbovePointer='0' pointerOnTop='1' pointerRadius='9' animation='1' showTickMarks='1' showTickValues='1' numberPrefix='$' formatNumber='1' formatNumberScale='0' chartRightMargin='50' chartLeftMargin='50' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                    Else
                        .Append("<chart bgColor='FFFFFF' bgAlpha='0' showBorder='0' upperLimit='" & tick.ToString() & "' lowerLimit='0' gaugeRoundRadius='5' chartBottomMargin='10' ticksBelowGauge='0' showGaugeLabels='0' valueAbovePointer='0' pointerOnTop='1' pointerRadius='9' animation='1' showTickMarks='1' showTickValues='1' numberPrefix='$' formatNumber='1' formatNumberScale='0' chartRightMargin='50' chartLeftMargin='50'>")
                    End If
                    'Add Clients:

                    i = 0
                    'For i = 0 To dt.Rows.Count - 1
                    .Append("<value>")
                    If client = 1 Then
                        .Append(dt.Rows(0)(1))
                    Else
                        .Append(dt.Rows(0)(3))
                    End If
                    .Append("</value>")
                    'Next

                    .Append("<colorRange>")
                    .Append("<color minValue='0' maxValue='" & ok.ToString() & "' alpha='GOOD' /> ")
                    .Append("<color minValue='" & ok.ToString() & "' maxValue='" & bad.ToString() & "' name='WEAK' /> ")
                    .Append("<color minValue='" & bad.ToString() & "' maxValue='" & (bad + bad).ToString() & "' name='BAD' /> ")
                    .Append("</colorRange>")
                    '.Append("<annotations>")
                    ''The circle which makes for the arc shape above the gauge
                    ''
                    '.Append("<annotationGroup id='Grp1' showBelow='0' x='210' y='-160' xScale='200'>")
                    '.Append("<annotation type='circle' radius='200' color='FFFFFF' />")
                    '.Append("</annotationGroup>")
                    ''The gradient rectangle which is usd as the gauge
                    ''
                    '.Append("<annotationGroup id='Grp2' showBelow='1'>")
                    '.Append("<annotation type='rectangle' x='15' y='10' toX='406' toY='59' color='678000,FCEF27,E00000' /> ")
                    '.Append("</annotationGroup>")
                    ''The labels Good and Bad
                    '' 
                    '.Append("<annotationGroup id='Grp3' showBelow='0'>")
                    '.Append("<annotation type='text' x='40' y='40' size='10' color='FFFFFF' bold='1' label='Good' />")
                    '.Append("<annotation type='text' x='385' y='40' size='10' color='FFFFFF' bold='1' label='Bad' />")
                    '.Append("</annotationGroup>")
                    '.Append("</annotations>")
                    .Append("<trendpoints>")
                    '.Append("<point startValue='" & bad.ToString()& "' displayValue='Fee' color='666666' thickness='2' alpha='100' />")
                    .Append("<point startValue='" & bad.ToString() & "' displayValue='Fee Amount' color='666666' useMarker='1' markerColor='F1f1f1' markerBorderColor='666666' markerRadius='7' markerTooltext='Fee Amount: $" & String.Format("{0:#,##0.00}", bad) & "'/>")
                    .Append("</trendpoints>")
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style name='ValueFont' type='Font' bgColor='333333' size='10' color='FFFFFF' /> ")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='VALUE' styles='valueFont' /> ")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")


                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function getFCXMLData_Area(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String
        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                dt = dsForGraph.Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    .Append("<chart caption='" & strCaption & "' bgColor='E9E9E9' outCnvBaseFontColor='666666' xAxisName='' yAxisName='' numberPrefix='' showNames='0' showValues='0' plotFillAlpha='70' numVDivLines='10' showAlternateVGridColor='1' AlternateVGridColor='e1f5ff' divLineColor='e1f5ff' vdivLineColor='e1f5ff' baseFontColor='666666' canvasBorderThickness='1' showPlotBorder='0' plotBorderThickness='0' startAngX='7' endAngX='7' startAngY='-18' endAngY='-18' zgapplot='20' zdepth='60' exeTime='2'>")

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<category label='" & dt.Rows(i)(1) & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    If type = "fee" Then
                        .Append("<dataset seriesName='Fee Amount'>")
                    End If

                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(2) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Completed:
                    If type = "fee" Then
                        .Append("<dataset seriesName='Fee Time Amount'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function cleanString(ByVal str As String) As String
        str = str.Replace("&", " and ")
        str = str.Replace("n's", "ns")
        str = str.Replace("12:00:00 AM", "")
        Return str
    End Function

    Public Function GetPPDates(ByVal month As String, ByVal year As String, ByRef startdate As DateTime, ByRef enddate As DateTime)
        Try
            Dim ds As DataSet
            Dim arParams(1) As SqlParameter

            Dim parameterPP As New SqlParameter("@PP", SqlDbType.VarChar)
            parameterPP.Value = month
            arParams(0) = parameterPP

            Dim parameterYear As New SqlParameter("@Year", SqlDbType.VarChar)
            parameterYear.Value = year
            arParams(1) = parameterYear

            Try
                ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetPostPeriodDates", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetPostPeriodDates", Err.Description)
            End Try

            If month = "" Then
                startdate = ds.Tables(1).Rows(0)("PPSRTDATE")
                enddate = ds.Tables(2).Rows(0)("PPENDDATE")
            Else
                If ds.Tables(0).Rows.Count > 0 Then
                    startdate = ds.Tables(0).Rows(0)("PPSRTDATE")
                    enddate = ds.Tables(0).Rows(0)("PPENDDATE")
                End If
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Shared Function getFCXMLData_Bar3D_Comps(ByVal dsForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal range As String = "", Optional ByVal project As String = "", Optional ByVal level As String = "", Optional ByVal week As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal code As String = "", Optional ByVal daterange As String = "", Optional ByVal page As String = "", Optional ByVal name As String = "") As String

        '
        ' use new chart = GetColumnChart_Comps()
        '

        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Dim type As String
        If level = "C" Then
            type = "cli"
        End If
        If level = "CD" Then
            type = "div"
        End If
        If level = "CDP" Then
            type = "prd"
        End If
        If level = "AE" Then
            type = "acc"
        End If
        If level = "dept" Then
            type = "dept"
        End If
        If level = "SC" Then
            type = "sc"
        End If
        If level = "JT" Then
            type = "jt"
        End If
        Try
            If dsForGraph.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' exportEnabled='1'>")

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dsForGraph.Rows.Count - 1
                        If range = "month" Then
                            .Append("<category label='" & dsForGraph.Rows(i)(0) & "' />")
                        Else
                            .Append("<category label='" & dsForGraph.Rows(i)(1) & "' />")
                        End If
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    'If type = "" Then
                    .Append("<dataset seriesName='Projects " & project & "'>")
                    'End If
                    i = 0
                    For i = 0 To dsForGraph.Rows.Count - 1
                        If range = "month" Then
                            If page = "year" Then
                                .Append("<set value='" & dsForGraph.Rows(i)(2) & "' link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & code.ToString.Replace("&", "andcode") & "%26name%3D" & name.ToString.Replace("&", "andcode").Replace("'", "") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & daterange & "%26week%3D" & week & "%26project%3D" & project & "%26level%3D" & level & "%26ddvalue%3D" & dsForGraph.Rows(i)(0) & "%26page%3D" & page & "' />")
                            End If
                            If page = "month" Then
                                .Append("<set value='" & dsForGraph.Rows(i)(4) & "' link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & code.ToString.Replace("&", "andcode") & "%26name%3D" & name.ToString.Replace("&", "andcode").Replace("'", "") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & daterange & "%26week%3D" & week & "%26project%3D" & project & "%26level%3D" & level & "%26ddstart%3D" & dsForGraph.Rows(i)(1) & "%26ddend%3D" & dsForGraph.Rows(i)(2) & "%26page%3D" & page & "' />")
                            End If
                        Else
                            .Append("<set value='" & dsForGraph.Rows(i)(4) & "' link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & code.ToString.Replace("&", "andcode") & "%26name%3D" & name.ToString.Replace("&", "andcode").Replace("'", "") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & daterange & "%26week%3D" & week & "%26project%3D" & project & "%26level%3D" & level & "%26ddstart%3D" & dsForGraph.Rows(i)(2) & "%26ddend%3D" & dsForGraph.Rows(i)(3) & "%26page%3D" & page & "' />")
                        End If
                    Next
                    .Append("</dataset>")
                    '''Completed:
                    If range = "" Then
                        .Append("<dataset seriesName='4 Week Avg' renderAs='Line'>")
                        i = 0
                        For i = 0 To dsForGraph.Rows.Count - 1
                            .Append("<set value='" & dsForGraph.Rows(i)(6) & "' />")
                        Next
                        .Append("</dataset>")
                    End If

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return "<chart></chart>"
        End Try
    End Function

    Public Shared Function getFCXMLData_Bar3D_CompsClient(ByVal dsForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal range As String = "", Optional ByVal datatype As String = "", Optional ByVal level As String = "", Optional ByVal week As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "", Optional ByVal code As String = "", Optional ByVal daterange As String = "", Optional ByVal page As String = "", Optional ByVal name As String = "") As String

        '
        'use new chart = GetColumnChart_CompsClient()
        '

        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Dim type As String
        If level = "C" Then
            type = "cli"
        End If
        If level = "CD" Then
            type = "div"
        End If
        If level = "CDP" Then
            type = "prd"
        End If
        If level = "AE" Then
            type = "acc"
        End If
        If level = "dept" Then
            type = "dept"
        End If
        If level = "SC" Then
            type = "sc"
        End If
        If level = "JT" Then
            type = "jt"
        End If
        Try

            strCaption = strCaption.Replace("'", "")

            If dsForGraph.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    If datatype = "Hours" Then
                        If LoGlo.UserCultureGet() = "fr-FR" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                        ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                        Else
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE'>")
                        End If
                    End If
                    If datatype = "Dollars" Then
                        If LoGlo.UserCultureGet() = "fr-FR" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='$' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                        ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='$' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                        Else
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='$' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE'>")
                        End If
                    End If
                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dsForGraph.Rows.Count - 1
                        If range = "month" Then
                            .Append("<category label='" & dsForGraph.Rows(i)(0) & "' />")
                        Else
                            .Append("<category label='" & dsForGraph.Rows(i)(1) & "' />")
                        End If
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    If datatype = "Hours" Then
                        .Append("<dataset seriesName='Hours'>")
                    End If
                    If datatype = "Dollars" Then
                        .Append("<dataset seriesName='Dollars'>")
                    End If
                    i = 0
                    For i = 0 To dsForGraph.Rows.Count - 1
                        If range = "month" Then
                            If page = "year" Then
                                .Append("<set value='" & dsForGraph.Rows(i)(2) & "'  />")
                            End If
                            'link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & code.ToString.Replace("&", "andcode") & "%26name%3D" & name.ToString.Replace("&", "andcode") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & daterange & "%26week%3D" & week & "%26project%3D" & project & "%26level%3D" & level & "%26ddvalue%3D" & dsForGraph.Rows(i)(0) & "%26page%3D" & page & "'
                            If page = "month" Then
                                .Append("<set value='" & dsForGraph.Rows(i)(4) & "'  />")
                            End If
                            'link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & code.ToString.Replace("&", "andcode") & "%26name%3D" & name.ToString.Replace("&", "andcode") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & daterange & "%26week%3D" & week & "%26project%3D" & project & "%26level%3D" & level & "%26ddstart%3D" & dsForGraph.Rows(i)(1) & "%26ddend%3D" & dsForGraph.Rows(i)(2) & "%26page%3D" & page & "'
                        Else
                            .Append("<set value='" & dsForGraph.Rows(i)(4) & "'  />")
                            'link='DashboardProjectList.aspx%3FGroup%3D0%26code%3D" & code.ToString.Replace("&", "andcode") & "%26name%3D" & name.ToString.Replace("&", "andcode") & "%26month%3D" & month & "%26year%3D" & year & "%26type%3D" & type & "%26range%3D" & daterange & "%26week%3D" & week & "%26project%3D" & project & "%26level%3D" & level & "%26ddstart%3D" & dsForGraph.Rows(i)(2) & "%26ddend%3D" & dsForGraph.Rows(i)(3) & "%26page%3D" & page & "'
                        End If
                    Next
                    .Append("</dataset>")
                    '''Completed:
                    If range = "" Then
                        .Append("<dataset seriesName='4 Week Avg' renderAs='Line'>")
                        i = 0
                        For i = 0 To dsForGraph.Rows.Count - 1
                            .Append("<set value='" & dsForGraph.Rows(i)(5) & "' />")
                        Next
                        .Append("</dataset>")
                    End If

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return "<chart></chart>"
        End Try
    End Function

    Public Shared Function getFCXMLData_Bar3D_Hours(ByVal dsForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String

        '
        ' use new chart = GetColumnChart_Hours()
        '

        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If dsForGraph.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    If type = "Hours" Then
                        If LoGlo.UserCultureGet() = "fr-FR" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                        ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                        Else
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE'>")
                        End If
                    End If
                    If type = "Dollars" Then
                        If LoGlo.UserCultureGet() = "fr-FR" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>")
                        ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>")
                        Else
                            .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='0' legendPosition='BOTTOM' showLabels='1' labelDisplay='ROTATE'>")
                        End If
                    End If
                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dsForGraph.Rows.Count - 1
                        .Append("<category label='" & dsForGraph.Rows(i)(1) & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    If type = "Hours" Then
                        .Append("<dataset seriesName='Hours'>")
                    End If
                    If type = "Dollars" Then
                        .Append("<dataset seriesName='Dollars'>")
                    End If
                    i = 0
                    For i = 0 To dsForGraph.Rows.Count - 1
                        .Append("<set value='" & dsForGraph.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")
                    '''Completed:
                    'If type = "" Then
                    '    .Append("<dataset seriesName='4 Week Avg' renderAs='Line'>")
                    'End If
                    'i = 0
                    'For i = 0 To dsForGraph.Rows.Count - 1
                    '    .Append("<set value='" & dsForGraph.Rows(i)(5) & "' />")
                    'Next
                    '.Append("</dataset>")

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return "<chart></chart>"
        End Try
    End Function

    Public Shared Function getFCXMLData_MultiColumn3D_Comps(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal type As String = "") As String
        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                dt = dsForGraph.Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM' showLabels='0'>")

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<category label='" & dt.Rows(i)(1) & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    If type = "" Then
                        .Append("<dataset seriesName='Projects'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(2) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Completed:
                    If type = "nonbill" Then
                        .Append("<dataset seriesName='Total'>")
                    End If
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function getFCXMLData_MultiColumn3D_JobStatistics(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal level As String = "") As String
        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If dsForGraph.Tables(0).Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='0' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM'>")

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dsForGraph.Tables(1).Rows.Count - 1
                        If level = "CD" Then
                            .Append("<category label='" & dsForGraph.Tables(1).Rows(i)(1) & "/" & dsForGraph.Tables(1).Rows(i)(3) & "' />")
                        ElseIf level = "CDP" Then
                            .Append("<category label='" & dsForGraph.Tables(1).Rows(i)(1) & "/" & dsForGraph.Tables(1).Rows(i)(3) & "/" & dsForGraph.Tables(1).Rows(i)(5) & "' />")
                        Else
                            .Append("<category label='" & dsForGraph.Tables(1).Rows(i)(1) & "' />")
                        End If
                    Next
                    .Append("</categories>")

                    'Add columns:

                    i = 0
                    For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                        .Append("<dataset seriesName='" & dsForGraph.Tables(0).Rows(i)(0) & "'>")
                        For j As Integer = 0 To dsForGraph.Tables(2).Rows.Count - 1
                            If dsForGraph.Tables(2).Rows(j)(0).ToString() = dsForGraph.Tables(0).Rows(i)(0).ToString() Then
                                If level = "CD" Then
                                    .Append("<set value='" & dsForGraph.Tables(2).Rows(j)(5) & "' />")
                                ElseIf level = "CDP" Then
                                    .Append("<set value='" & dsForGraph.Tables(2).Rows(j)(7) & "' />")
                                Else
                                    .Append("<set value='" & dsForGraph.Tables(2).Rows(j)(3) & "' />")
                                End If
                            End If
                        Next
                        .Append("</dataset>")
                    Next

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

#Region "Dashboard Project "

    Public Function GetDataRefreshProject(ByVal year1 As String, ByVal year2 As String)
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        Dim parameterStart As New SqlParameter("@Start", SqlDbType.VarChar)
        parameterStart.Value = year1
        arParams(0) = parameterStart

        Dim parameterEnd As New SqlParameter("@End", SqlDbType.VarChar)
        parameterEnd.Value = year2
        arParams(1) = parameterEnd

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_Project_GetData", arParams)
            Return True
        Catch
            Return False
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetData", Err.Description)
        End Try
        Return True
    End Function

    Public Function GetDataRefreshClient(ByVal year1 As String, ByVal year2 As String)
        Dim ds As DataSet
        Dim arParams(2) As SqlParameter

        Dim parameterStart As New SqlParameter("@Start", SqlDbType.Int)
        parameterStart.Value = year1
        arParams(0) = parameterStart

        Dim parameterEnd As New SqlParameter("@End", SqlDbType.Int)
        parameterEnd.Value = year2
        arParams(1) = parameterEnd

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_ClientTime_GetData", arParams)
            Return True
        Catch
            Return False
            Err.Raise(Err.Number, "Class:cDashboard Routine:GetData", Err.Description)
        End Try
        Return True
    End Function

    Public Function GetDashboardData(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                       ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                       ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                       ByVal project As String, ByVal count As Integer, ByVal dash As String)
        Dim ds As DataSet
        Dim arParams(18) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If dash = "Client" Then
            If type = "Month" Then
                GetPPDates(month, year, startdate, enddate)
                enddate = CDate(weekending)
            Else
                If count > 1 Then
                    startdate = CDate(weekending).AddYears(-1)
                    enddate = CDate(weekending)
                Else
                    startdate = "1/1/" & year
                    enddate = CDate(weekending)
                End If
            End If
        Else
            If type = "Month" Then
                ' GetPPDates(month, year, startdate, enddate)
                startdate = month & "/1/" & year
                enddate = CDate(weekending)
            Else
                If count > 1 Then
                    startdate = CDate(weekending).AddYears(-1)
                    enddate = CDate(weekending)
                Else
                    startdate = "1/1/" & year
                    enddate = CDate(weekending)
                End If
            End If
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Dim parameterDash As New SqlParameter("@Dash", SqlDbType.VarChar)
        parameterDash.Value = dash
        arParams(17) = parameterDash

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetRawData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetRawData", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetCompsByWeekByDept(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                         ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                         ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                         ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        parameterStartDate.Value = startdate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        parameterEndDate.Value = enddate
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetCompsByWeekByDept", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetCompsByWeekByDept", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetCompsByMonthByDept(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                          ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                          ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                          ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetCompsByMonthByDept", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetCompsByMonthByDept", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetCompsByYearByDept(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                         ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                         ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                         ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetCompsByYearByDept", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetCompsByYearByDept", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetCompsByWeekByDeptAvg(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                            ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                            ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                            ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetCompsByWeekByDeptAvg", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetCompsByWeekByDeptAvg", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetWeeks(ByVal month As Integer, ByVal year As Integer, ByVal pp As Integer, Optional ByVal format As String = "en-US")
        Try
            Dim ds As DataSet
            Dim arParams(4) As SqlParameter
            Dim startdate As String

            Dim parameterMonth As New SqlParameter("@Month", SqlDbType.VarChar)
            parameterMonth.Value = month
            arParams(0) = parameterMonth

            Dim parameterYear As New SqlParameter("@Year", SqlDbType.VarChar)
            parameterYear.Value = year
            arParams(1) = parameterYear

            Dim parameterPP As New SqlParameter("@PP", SqlDbType.SmallInt)
            parameterPP.Value = pp
            arParams(2) = parameterPP

            Dim parameterformat As New SqlParameter("@format", SqlDbType.VarChar)
            parameterformat.Value = format
            arParams(3) = parameterformat

            Try
                ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetWeeks", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cDashboard Routine:GetWeeks", Err.Description)
            End Try
            Return ds
        Catch ex As Exception

        End Try
    End Function

    Public Function GetPostPeriodsProject(ByVal year As String)
        Try
            Dim ds As DataSet
            Dim arParams(2) As SqlParameter
            Dim startdate As String
            If startdate = Now.Date.Year Then
                startdate = Now.Date.ToShortDateString
            Else
                startdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & Now.Date.Year
            End If
            startdate = Now.Date.Month.ToString() & "/" & Now.Date.Day.ToString() & "/" & year

            Dim parameterStartDate As New SqlParameter("@CurrentDate", SqlDbType.VarChar)
            parameterStartDate.Value = startdate
            arParams(0) = parameterStartDate

            Dim parameterYear As New SqlParameter("@CurrentYear", SqlDbType.Int)
            parameterYear.Value = CInt(year)
            arParams(1) = parameterYear

            Try
                ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetPostPeriods", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cDashboard Routine:GetPostPeriods", Err.Description)
            End Try
            Return ds
        Catch ex As Exception

        End Try
    End Function

    Public Function GetProjectsByWeek(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal dept As String, ByVal period As Integer, ByVal yearValue As String)
        Dim ds As DataSet
        Dim arParams(8) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        'GetPPDates(month, year, startdate, enddate)

        startdate = "1/1/" & year
        enddate = CDate(weekending)
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate.ToShortDateString
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate.ToShortDateString
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(5) = parameterDept

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(6) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(7) = parameterYearValue

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetProjectsByWeek", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetProjectsByWeek", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetProjects(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String,
                                ByVal period As Integer, ByVal yearValue As String, ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String, ByVal count As Integer)
        Dim ds As DataSet
        Dim arParams(15) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate.ToShortDateString
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate.ToShortDateString
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetProjects", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetProjects", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetJobStatistics(ByVal UserID As String, ByVal year As String, ByVal weekending As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean) As DataTable
        Dim ds As New DataSet
        Dim arParams(5) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        'GetPPDates(month, year, startdate, enddate)

        startdate = "1/1/" & year
        enddate = CDate(weekending)
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime)
        parameterStartDate.Value = startdate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.DateTime)
        parameterEndDate.Value = enddate
        arParams(2) = parameterEndDate

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(3) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(4) = parameterIsCancelledStatus

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_dto_JobStatistics", arParams)
            Return ds.Tables(0)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetJobStatistics", Err.Description)
        End Try
    End Function

    Public Function GetProjectsByLevel(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                       ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                       ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                       ByVal project As String, ByVal count As Integer)
        Dim ds As DataSet
        Dim arParams(17) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetProjectsByLevel", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetProjectsByLevel", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetProjectsList(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                       ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                       ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                       ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "", Optional ByVal ddstart As String = "",
                                       Optional ByVal ddend As String = "", Optional ByVal page As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        If page = "year" Then
            If ddstart <> "" And ddend <> "" Then
                startdate = ddstart
                enddate = ddend
            End If
        End If
        If page = "month" Then
            If ddstart <> "" And ddend <> "" Then
                startdate = ddstart
                enddate = ddend
            End If
        End If
        If page = "week" Then
            If ddstart <> "" And ddend <> "" Then
                startdate = ddstart
                enddate = ddend
            End If
        End If

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetProjectsList", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetProjectsList", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetComps(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                         ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                         ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                         ByVal project As String, ByVal count As Integer)
        Dim ds As DataSet
        Dim arParams(17) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        parameterStartDate.Value = startdate.ToShortDateString
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        parameterEndDate.Value = enddate.ToShortDateString
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetComps", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetComps", Err.Description)
        End Try
        Return ds
    End Function


#End Region

#Region "Dashboard Client Time "

    Public Function GetHoursByLevel(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                      ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                      ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                      ByVal project As String, ByVal count As Integer)
        Dim ds As DataSet
        Dim arParams(17) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetHoursByLevel", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetHoursByLevel", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDollarsByLevel(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                       ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                       ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                       ByVal project As String, ByVal count As Integer)
        Dim ds As DataSet
        Dim arParams(17) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetAmountByLevel", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetAmountByLevel", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetHours(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                         ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                         ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                         ByVal project As String, ByVal count As Integer)
        Dim ds As DataSet
        Dim arParams(17) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        parameterStartDate.Value = startdate.ToShortDateString
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        parameterEndDate.Value = enddate.ToShortDateString
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetHours", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetHours", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetHoursByWeek(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                        ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                        ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                        ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        parameterStartDate.Value = startdate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        parameterEndDate.Value = enddate
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetHoursByWeek", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetHoursByWeek", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetHoursByMonth(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                          ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                          ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                          ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetHoursByMonth", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetHoursByMonth", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetHoursByYear(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                         ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                         ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                         ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetHoursByYear", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetHoursByYear", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDollarsByWeek(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                        ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                        ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                        ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        parameterStartDate.Value = startdate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        parameterEndDate.Value = enddate
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDollarsByWeek", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetDollarsByWeek", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDollarsByMonth(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                          ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                          ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                          ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDollarsByMonth", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetDollarsByMonth", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetDollarsByYear(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                         ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                         ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                         ByVal project As String, ByVal count As Integer, Optional ByVal division As String = "", Optional ByVal product As String = "")
        Dim ds As DataSet
        Dim arParams(19) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            GetPPDates(month, year, startdate, enddate)
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterOption As New SqlParameter("@Option", SqlDbType.VarChar)
        parameterOption.Value = project
        arParams(16) = parameterOption

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar)
        parameterDivision.Value = division
        arParams(17) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar)
        parameterProduct.Value = product
        arParams(18) = parameterProduct

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetDollarsByYear", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetDollarsByYear", Err.Description)
        End Try
        Return ds
    End Function

    Public Function GetClientList(ByVal empcode As String, ByVal month As String, ByVal year As String, ByVal weekending As String, ByVal office As String, ByVal ae As String,
                                       ByVal client As String, ByVal dept As String, ByVal salesclass As String, ByVal jobtype As String, ByVal period As Integer, ByVal yearValue As String,
                                       ByVal level As String, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal UserID As String, ByVal type As String,
                                       ByVal project As String, ByVal count As Integer)
        Dim ds As DataSet
        Dim arParams(17) As SqlParameter
        Dim startdate As DateTime
        Dim enddate As DateTime
        If type = "Month" Then
            ' GetPPDates(month, year, startdate, enddate)
            startdate = month & "/1/" & year
            enddate = CDate(weekending)
        Else
            If count > 1 Then
                startdate = CDate(weekending).AddYears(-1)
                enddate = CDate(weekending)
            Else
                startdate = "1/1/" & year
                enddate = CDate(weekending)
            End If
        End If
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
        parameterEmpCode.Value = empcode
        arParams(0) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar)
        Dim str As String = startdate.ToShortDateString
        'If startdate.ToShortDateString = "1/1/0001" Then
        '    parameterStartDate.Value = ""
        'Else
        parameterStartDate.Value = startdate.ToShortDateString
        'End If
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar)
        'If enddate.ToShortDateString = "1/1/0001" Then
        '    parameterEndDate.Value = ""
        'Else
        parameterEndDate.Value = enddate.ToShortDateString
        'End If
        arParams(2) = parameterEndDate

        Dim parameterMonth As New SqlParameter("@Month", SqlDbType.Int)
        If month <> "" Then
            parameterMonth.Value = 1
        Else
            parameterMonth.Value = 0
        End If
        arParams(3) = parameterMonth

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(4) = parameterOffice

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
        parameterClient.Value = client
        arParams(6) = parameterClient

        Dim parameterDept As New SqlParameter("@Dept", SqlDbType.VarChar)
        parameterDept.Value = dept
        arParams(7) = parameterDept

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(8) = parameterSalesClass

        Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar)
        parameterJobType.Value = jobtype
        arParams(9) = parameterJobType

        Dim parameterPeriod As New SqlParameter("@Period", SqlDbType.Int)
        parameterPeriod.Value = period
        arParams(10) = parameterPeriod

        Dim parameterYearValue As New SqlParameter("@YearValue", SqlDbType.VarChar)
        parameterYearValue.Value = yearValue
        arParams(11) = parameterYearValue

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.VarChar)
        parameterLevel.Value = level
        arParams(12) = parameterLevel

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(13) = parameterUserID

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(14) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(15) = parameterIsCancelledStatus

        Dim parameterProject As New SqlParameter("@Project", SqlDbType.VarChar)
        parameterProject.Value = project
        arParams(16) = parameterProject

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Dashboard_GetClientList", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDashboard Routine:usp_wv_Dashboard_GetClientList", Err.Description)
        End Try
        Return ds
    End Function

#End Region



End Class

