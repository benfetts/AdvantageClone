Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

<Serializable()> Public Class ARFocast
    Private mClient As String
    Private mDivision As String
    Private mProduct As String
    Private mAvgDays As Integer
    Private mOpenARAmt As Decimal
    Private mTotalARAmt As Decimal
    Private mMonth1 As Decimal
    Private mMonth2 As Decimal
    Private mMonth3 As Decimal
    Private mMonth4 As Decimal
    Public Property Client() As String
        Get
            Return mClient
        End Get
        Set(ByVal Value As String)
            mClient = Value
        End Set
    End Property
    Public Property Division() As String
        Get
            Return mDivision
        End Get
        Set(ByVal Value As String)
            mDivision = Value
        End Set
    End Property
    Public Property Product() As String
        Get
            Return mProduct
        End Get
        Set(ByVal Value As String)
            mProduct = Value
        End Set
    End Property
    Public Property AvgDays() As Integer
        Get
            Return mAvgDays
        End Get
        Set(ByVal Value As Integer)
            mAvgDays = Value
        End Set
    End Property
    Public Property OpenARAmt() As Decimal
        Get
            Return mOpenARAmt
        End Get
        Set(ByVal Value As Decimal)
            mOpenARAmt = Value
        End Set
    End Property
    'Modified by Sam Tran on 2006/06/16
    '	
    Public Property TotalARAmt() As Decimal
        Get
            Return mTotalARAmt
        End Get
        Set(ByVal Value As Decimal)
            mTotalARAmt = Value
        End Set
    End Property
    Public Property Month1() As Decimal
        Get
            Return mMonth1
        End Get
        Set(ByVal Value As Decimal)
            mMonth1 = Value
        End Set
    End Property
    Public Property Month2() As Decimal
        Get
            Return mMonth2
        End Get
        Set(ByVal Value As Decimal)
            mMonth2 = Value
        End Set
    End Property
    Public Property Month3() As Decimal
        Get
            Return mMonth3
        End Get
        Set(ByVal Value As Decimal)
            mMonth3 = Value
        End Set
    End Property
    Public Property Month4() As Decimal
        Get
            Return mMonth4
        End Get
        Set(ByVal Value As Decimal)
            mMonth4 = Value
        End Set
    End Property
End Class

<Serializable()> Public Class ARFocasts
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As ARFocast
        Get
            Return CType(List(index), ARFocast)
        End Get
        Set(ByVal Value As ARFocast)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As ARFocast) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As ARFocast) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ARFocast)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ARFocast)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As ARFocast) As Boolean
        Return List.Contains(value)
    End Function
End Class

<Serializable()> Public Class cDesktopObjects
    Private mConnString As String
    Dim oSQL As SqlHelper

    Public Function GetCurrentRatio(ByVal StartDate As String, ByVal EndDate As String, ByVal Office As String, ByVal userid As String) As SqlDataReader
        Dim arParams(3) As SqlParameter

        Dim parameterStartDate As New SqlParameter("@startPP", SqlDbType.VarChar)
        parameterStartDate.Value = StartDate
        arParams(0) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@endPP", SqlDbType.VarChar)
        parameterEndDate.Value = EndDate
        arParams(1) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = Office
        arParams(2) = parameterOffice

        Dim parameteruserid As New SqlParameter("@USER_ID", SqlDbType.VarChar)
        parameteruserid.Value = userid
        arParams(3) = parameteruserid

        Try
            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_current_ratio", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetCurrentRatio", Err.Description)
        End Try

    End Function

    Public Function GetAgencyGoals(ByVal StartDate As String, ByVal EndDate As String, ByVal Office As String, ByVal userid As String) As DataTable
        Dim arParams(3) As SqlParameter

        Dim parameterStartDate As New SqlParameter("@startPP", SqlDbType.VarChar)
        parameterStartDate.Value = StartDate
        arParams(0) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@endPP", SqlDbType.VarChar)
        parameterEndDate.Value = EndDate
        arParams(1) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = Office
        arParams(2) = parameterOffice

        Dim parameteruserid As New SqlParameter("@USER_ID", SqlDbType.VarChar)
        parameteruserid.Value = userid
        arParams(3) = parameteruserid

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_get_agency_goals", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetAgencyGoals", Err.Description)
        End Try

    End Function

    Public Function GetAgencySetting(ByVal AgySettingsCode) As Integer
        Dim SessionKey As String = "GetAgencySetting" & AgySettingsCode
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim oSQL As SqlHelper
            Dim SQL_STRING As String

            SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,0) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '" & AgySettingsCode & "'"

            Try
                ReturnInteger = CType(oSQL.ExecuteScalar(mConnString, CommandType.Text, SQL_STRING), Integer)
            Catch
                ReturnInteger = 0
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnInteger
        Else
            ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
        End If

        Return ReturnInteger

    End Function

    Public Function getEndPeriod() As String
        Dim SessionKey As String = "getEndPeriod"
        Dim ReturnString As String = "0"
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim oSQL As SqlHelper
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim curdate As Date
            Dim monnbr, yrnbr As Integer

            curdate = Today
            monnbr = DatePart(DateInterval.Month, curdate)
            yrnbr = DatePart(DateInterval.Year, curdate)

            'Get End (or Current) postperiod
            SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE, 0) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AGY_BLD_PPD_END'"

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:cDesktopObjects Routine:getEndPeriod", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                ReturnString = CType(dr.GetValue(0), String)
            End If

            If ReturnString = "0" Then
                SQL_STRING = "SELECT PPPERIOD FROM POSTPERIOD WHERE PPGLCURMTH = 'C'"

                Try
                    dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
                Catch
                    Err.Raise(Err.Number, "Class:cDesktopObjects Routine:getEndPeriod", Err.Description)
                Finally
                End Try

                If dr.HasRows Then
                    dr.Read()
                    ReturnString = dr.GetString(0)
                Else
                    ReturnString = CStr(yrnbr) & monnbr.ToString("0#")
                End If
            End If

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString
    End Function

    Public Function getStartPeriod() As String
        Dim SessionKey As String = "getStartPeriod"
        Dim ReturnString As String = "0"
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim oSQL As SqlHelper
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim currentYear As String
            Dim curdate As Date
            Dim monnbr, yrnbr As Integer

            curdate = Today
            monnbr = DatePart(DateInterval.Month, curdate)
            yrnbr = DatePart(DateInterval.Year, curdate)

            yrnbr = DatePart(DateInterval.Year, Today)

            'Get Start (Or first fiscal) postperiod
            SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE, 0) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AGY_BLD_PPD_START'"

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:cDesktopObjects Routine:getStartPeriod", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                ReturnString = CType(dr.GetValue(0), String)
            End If

            If ReturnString = "0" Then
                'Get year of current period
                SQL_STRING = "SELECT PPGLYEAR FROM POSTPERIOD WHERE PPGLCURMTH = 'C'"
                Try
                    dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
                Catch
                    Err.Raise(Err.Number, "Class:cDesktopObjects Routine:getStartPeriod", Err.Description)
                Finally
                End Try

                If dr.HasRows Then
                    dr.Read()
                    currentYear = dr.GetString(0)
                Else
                    currentYear = CType(yrnbr, String)
                End If

                'Find first fiscal period
                SQL_STRING = "SELECT PPPERIOD FROM POSTPERIOD WHERE PPGLMONTH = 1 AND PPGLYEAR = '" & currentYear & "'"

                Try
                    dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
                Catch
                    Err.Raise(Err.Number, "Class:cDesktopObjects Routine:getStartPeriod", Err.Description)
                Finally
                End Try

                If dr.HasRows Then
                    dr.Read()
                    ReturnString = dr.GetString(0)
                Else
                    ReturnString = CStr(yrnbr) & monnbr.ToString("0#")
                End If

            End If

            dr.Close()

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

    Public Function GetNPTime(ByVal userid As String, ByVal empcode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal view As String) As DataTable

        Dim arParams(4) As SqlParameter

        Dim parameteruserid As New SqlParameter("@USER_ID", SqlDbType.VarChar)
        parameteruserid.Value = userid
        arParams(0) = parameteruserid

        Dim parameterempcode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar)
        parameterempcode.Value = empcode
        arParams(1) = parameterempcode

        Dim parameterStartDate As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
        parameterStartDate.Value = StartDate
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
        parameterEndDate.Value = EndDate
        arParams(3) = parameterEndDate

        Dim parameterview As New SqlParameter("@VIEW", SqlDbType.VarChar)
        parameterview.Value = view
        arParams(4) = parameterview

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_get_emp_np_time_all", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetNPTime", Err.Description)
        End Try

    End Function

    Public Function GetNPTimeData(ByVal userid As String, ByVal empcode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal flag As Integer, ByVal cat As String) As DataTable

        Dim arParams(5) As SqlParameter

        Dim parameteruserid As New SqlParameter("@user_id", SqlDbType.VarChar)
        parameteruserid.Value = userid
        arParams(0) = parameteruserid

        Dim parameterempcode As New SqlParameter("@emp_code", SqlDbType.VarChar)
        parameterempcode.Value = empcode
        arParams(1) = parameterempcode

        Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.SmallDateTime)
        parameterStartDate.Value = StartDate
        arParams(2) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.SmallDateTime)
        parameterEndDate.Value = EndDate
        arParams(3) = parameterEndDate

        Dim parameterview As New SqlParameter("@sick_flag", SqlDbType.SmallInt)
        parameterview.Value = flag
        arParams(4) = parameterview

        Dim parametercategory As New SqlParameter("@category", SqlDbType.VarChar)
        parametercategory.Value = cat
        arParams(5) = parametercategory

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_get_emp_np_time_data", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetNPTimeData", Err.Description)
        End Try

    End Function

    Public Function GetDirectExpense(ByVal StartDate As String, ByVal EndDate As String, ByVal Office As String, ByVal Amount As String, ByVal userid As String, ByVal fromapp As String) As DataTable
        Dim arParams(5) As SqlParameter

        Dim parameterStartDate As New SqlParameter("@startPP", SqlDbType.VarChar)
        parameterStartDate.Value = StartDate
        arParams(0) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@endPP", SqlDbType.VarChar)
        parameterEndDate.Value = EndDate
        arParams(1) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar)
        parameterOffice.Value = Office
        arParams(2) = parameterOffice

        Dim parameteramount As New SqlParameter("@alert_amt", SqlDbType.Decimal)
        parameteramount.Value = Amount
        arParams(3) = parameteramount

        Dim parameteruserid As New SqlParameter("@USER_ID", SqlDbType.VarChar)
        parameteruserid.Value = userid
        arParams(4) = parameteruserid

        Dim parameterFrom As New SqlParameter("@From", SqlDbType.VarChar)
        parameterFrom.Value = fromapp
        arParams(5) = parameterFrom

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_get_direct_exp", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetDirectExpense", Err.Description)
        End Try

    End Function

    Public Function GetDirectExpenseDet(ByVal StartDate As String, ByVal EndDate As String, ByVal Inv As String) As DataTable
        Dim arParams(2) As SqlParameter

        Dim parameterStartDate As New SqlParameter("@startPP", SqlDbType.VarChar)
        parameterStartDate.Value = StartDate
        arParams(0) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@endPP", SqlDbType.VarChar)
        parameterEndDate.Value = EndDate
        arParams(1) = parameterEndDate

        Dim parameterInv As New SqlParameter("@invoice", SqlDbType.VarChar)
        parameterInv.Value = Inv
        arParams(2) = parameterInv


        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_get_direct_exp_det", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetDirectExpenseDet", Err.Description)
        End Try

    End Function

    Public Function GetTimeGraph(ByVal EmpCode As String) As DataTable

        Dim arParams(2) As SqlParameter
        Dim ts As New wvTimeSheet.cTimeSheet(mConnString)

        ' Create parameters for stored procedure
        Dim parameterUserID As New SqlParameter("@empcode", SqlDbType.VarChar, 100)
        parameterUserID.Value = CStr(EmpCode)
        arParams(0) = parameterUserID

        Dim parameterStartDate As New SqlParameter("@startdate", SqlDbType.SmallDateTime)
        parameterStartDate.Value = ts.FirstDayOfWeek(Now.Date)
        arParams(1) = parameterStartDate

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_dt_week_graph", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetTimeGraph", Err.Description)
        End Try


    End Function

    Public Function GetJobStatistics(ByVal UserID As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal ae As String, ByVal manager As String) As DataTable
        Dim ds As New DataSet
        Dim arParams(7) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime)
        parameterStartDate.Value = StartDate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.DateTime)
        parameterEndDate.Value = EndDate
        arParams(2) = parameterEndDate

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(3) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(4) = parameterIsCancelledStatus

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar, 6)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = manager
        arParams(6) = parameterManager

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_dto_JobStatistics", arParams)
            Return ds.Tables(0)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetJobStatistics", Err.Description)
        End Try
    End Function

    Public Function GetJobStatisticsCP(ByVal CPID As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal ae As String, ByVal manager As String) As DataTable
        Dim ds As New DataSet
        Dim arParams(7) As SqlParameter

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(0) = parameterCPID

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime)
        parameterStartDate.Value = StartDate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.DateTime)
        parameterEndDate.Value = EndDate
        arParams(2) = parameterEndDate

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(3) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(4) = parameterIsCancelledStatus

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar, 6)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = manager
        arParams(6) = parameterManager

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_cp_dto_JobStatistics", arParams)
            Return ds.Tables(0)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetJobStatistics", Err.Description)
        End Try
    End Function

    Public Function GetOfficeStatistics(ByVal UserID As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CancelledCode As String, ByVal IsCancelledStatus As Boolean, ByVal ae As String, ByVal manager As String) As DataTable
        Dim ds As New DataSet
        Dim arParams(7) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime)
        parameterStartDate.Value = StartDate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.DateTime)
        parameterEndDate.Value = EndDate
        arParams(2) = parameterEndDate

        Dim parameterCancelledCode As New SqlParameter("@CancelledCode", SqlDbType.VarChar, 100)
        parameterCancelledCode.Value = CancelledCode
        arParams(3) = parameterCancelledCode

        Dim parameterIsCancelledStatus As New SqlParameter("@IsCancelled", SqlDbType.VarChar, 10)
        parameterIsCancelledStatus.Value = IsCancelledStatus.ToString.ToLower.Trim
        arParams(4) = parameterIsCancelledStatus

        Dim parameterAE As New SqlParameter("@AE", SqlDbType.VarChar, 6)
        parameterAE.Value = ae
        arParams(5) = parameterAE

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
        parameterManager.Value = manager
        arParams(6) = parameterManager

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_dto_OfficeStatistics", arParams)
            Return ds.Tables(0)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetOfficeStatistics", Err.Description)
        End Try
    End Function

    Public Function GetInvoiceARBalanceGraph(ByVal UserID As String, Optional ByVal ClientCode As String = "%", Optional ByVal OfficeCode As String = "%", _
                                             Optional ByVal DivisionCode As String = "%", Optional ByVal ProductCode As String = "%", Optional ByVal ShowMyARBalance As Boolean = False, _
                                             Optional ByVal InvCats As String = "") As DataTable
        Dim arParams(7) As SqlParameter

        ' Create parameters for store procedure
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        If ClientCode = "" Then
            parameterClientCode.Value = "%"
        Else
            parameterClientCode.Value = CStr(ClientCode)
        End If
        arParams(1) = parameterClientCode

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        If OfficeCode = "" Then
            parameterOfficeCode.Value = "%"
        Else
            parameterOfficeCode.Value = CStr(OfficeCode)
        End If
        arParams(2) = parameterOfficeCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If DivisionCode = "" Then
            parameterDivisionCode.Value = "%"
        Else
            parameterDivisionCode.Value = CStr(DivisionCode)
        End If
        arParams(3) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If ProductCode = "" Then
            parameterProductCode.Value = "%"
        Else
            parameterProductCode.Value = CStr(ProductCode)
        End If
        arParams(4) = parameterProductCode

        Dim parameterFrom As New SqlParameter("@From", SqlDbType.VarChar, 6)
        If ShowMyARBalance = True Then
            parameterFrom.Value = "mca"
        Else
            parameterFrom.Value = ""
        End If
        arParams(5) = parameterFrom

        Dim parameterInvCats As New SqlParameter("@InvCats", SqlDbType.VarChar)
        parameterInvCats.Value = InvCats
        arParams(6) = parameterInvCats

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetInvoiceBalance", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetInvoiceARBalanceGraph", Err.Description)
        End Try

    End Function

    Public Function GetInvoices(ByVal UserID As String, Optional ByVal ClientCode As String = "%", Optional ByVal OfficeCode As String = "%", _
                                Optional ByVal Group As Integer = 0, Optional ByVal DivisionCode As String = "%", Optional ByVal ProductCode As String = "%", _
                                Optional ByVal fromDO As String = "", Optional ByVal InvCats As String = "") As DataTable
        Dim arParams(8) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = CStr(ClientCode)
        arParams(1) = parameterClientCode

        Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
        parameterOfficeCode.Value = CStr(OfficeCode)
        arParams(2) = parameterOfficeCode

        Dim parameterGroup As New SqlParameter("@Group", SqlDbType.Int)
        parameterGroup.Value = Group
        arParams(3) = parameterGroup

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = CStr(DivisionCode)
        arParams(4) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = CStr(ProductCode)
        arParams(5) = parameterProductCode

        Dim parameterFrom As New SqlParameter("@From", SqlDbType.VarChar, 6)
        parameterFrom.Value = fromDO
        arParams(6) = parameterFrom

        Dim parameterInvCats As New SqlParameter("@InvCats", SqlDbType.VarChar)
        parameterInvCats.Value = InvCats
        arParams(7) = parameterInvCats

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetInvoices", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetInvoices", Err.Description)
        End Try

    End Function

    Public Function GetInvoiceComment(ByVal InvoiceNum As Integer, ByVal InvoiceSeq As Integer) As String
        Dim SessionKey As String = "GetInvoiceComment" & InvoiceNum.ToString().PadLeft(6) & InvoiceSeq.ToString().PadLeft(2)
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter

            Dim parameterInvoiceNum As New SqlParameter("@InvoiceNum", SqlDbType.Int)
            parameterInvoiceNum.Value = InvoiceNum
            arParams(0) = parameterInvoiceNum

            Dim parameterInvoiceSeq As New SqlParameter("@InvoiceSeq", SqlDbType.Int)
            parameterInvoiceSeq.Value = InvoiceSeq
            arParams(1) = parameterInvoiceSeq


            Try
                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetInvoiceComment", arParams)
            Catch
                ReturnString = ""
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

    Public Function GetTimeGoalPieGraph(ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As DataTable
        Dim arParams(3) As SqlParameter

        Dim parameterUserID As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterUserID.Value = EmpCode
        arParams(0) = parameterUserID

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
        parameterStartDate.Value = StartDate
        arParams(1) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
        parameterEndDate.Value = EndDate
        arParams(2) = parameterEndDate

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_TimeGoalByEmpCode", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetTimeGoalPieGraph", Err.Description)
        End Try

    End Function

    Public Function GetMontlyGoal(ByVal EmpCode As String) As DataTable
        Dim parameterUserID As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterUserID.Value = EmpCode

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_emp_GetMonthlyGoal", "DtData", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetMontlyGoal", Err.Description)
        End Try

    End Function

    Public Function GetCategories() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetCategories")
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetCategories", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetARForecast(ByVal UserId As String, Optional ByVal ClientCode As String = "%", Optional ByVal OfficeCode As String = "%") As ARFocasts
        Dim dr As SqlClient.SqlDataReader
        Dim InvoiceDate As Date
        Dim LastClient As String
        Dim ThisARForcast As ARFocast
        Dim TheseArForcast As ARFocasts
        Dim NoOfClient As Integer
        Dim AvgDays As Integer
        Dim TotalARAmt As Decimal
        Dim Month1 As Decimal
        Dim Month2 As Decimal
        Dim Month3 As Decimal
        Dim Month4 As Decimal
        Dim arParams(3) As SqlParameter

        ' Create parameter for stored procedure
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserId
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = CStr(ClientCode)
        arParams(1) = parameterClientCode

        Dim parameterOfficeCodes As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 6)
        parameterOfficeCodes.Value = CStr(OfficeCode)
        arParams(2) = parameterOfficeCodes

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_ARForcast", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetARForecast", Err.Description)
        End Try


        ThisARForcast = New ARFocast
        TheseArForcast = New ARFocasts
        LastClient = ""
        NoOfClient = 0
        Dim sumTotalOpenARAmt As Double = 0.0
        Do While dr.Read
            If LastClient <> "" And LastClient <> dr.GetString(0) Then
                NoOfClient += 1
                AvgDays += ThisARForcast.AvgDays
                TotalARAmt += ThisARForcast.OpenARAmt
                Month1 += ThisARForcast.Month1
                Month2 += ThisARForcast.Month2
                Month3 += ThisARForcast.Month3
                Month4 += ThisARForcast.Month4
                TheseArForcast.Add(ThisARForcast)
                ThisARForcast = New ARFocast
            End If
            ThisARForcast.Client = dr.GetString(0)
            If dr.IsDBNull(1) Then
                ThisARForcast.AvgDays = 0
            Else
                ThisARForcast.AvgDays = CStr(dr.GetInt32(1))
            End If
            ThisARForcast.OpenARAmt = CDec(dr.GetDecimal(2))
            If dr.IsDBNull(4) Then
                InvoiceDate = Date.Today
            Else
                InvoiceDate = CDate(dr.GetDateTime(4))
            End If
            If InvoiceDate.Month = Date.Today.Month Then
                ThisARForcast.Month1 += CDec(dr.GetDecimal(2))
            End If
            If InvoiceDate.Month = Date.Today.AddMonths(1).Month Then
                ThisARForcast.Month2 += CDec(dr.GetDecimal(2))
            End If
            If InvoiceDate.Month = Date.Today.AddMonths(2).Month Then
                ThisARForcast.Month3 += CDec(dr.GetDecimal(2))
            End If
            If InvoiceDate.Month = Date.Today.AddMonths(3).Month Then
                ThisARForcast.Month4 += CDec(dr.GetDecimal(2))
            End If

            'If InvoiceDate.Month = Date.Today.Month Then
            '    ThisARForcast.Month1 += CDec(dr.GetDecimal(3))
            'End If
            'If InvoiceDate.Month = Date.Today.AddMonths(1).Month Then
            '    ThisARForcast.Month2 += CDec(dr.GetDecimal(3))
            'End If
            'If InvoiceDate.Month = Date.Today.AddMonths(2).Month Then
            '    ThisARForcast.Month3 += CDec(dr.GetDecimal(3))
            'End If
            'If InvoiceDate.Month = Date.Today.AddMonths(3).Month Then
            '    ThisARForcast.Month4 += CDec(dr.GetDecimal(3))
            'End If
            ThisARForcast.TotalARAmt = dr.GetDecimal(3)
            If ThisARForcast.Client <> LastClient Then sumTotalOpenARAmt += ThisARForcast.TotalARAmt
            LastClient = dr.GetString(0)
        Loop

        NoOfClient += 1
        AvgDays += ThisARForcast.AvgDays
        TotalARAmt += ThisARForcast.OpenARAmt
        Month1 += ThisARForcast.Month1
        Month2 += ThisARForcast.Month2
        Month3 += ThisARForcast.Month3
        Month4 += ThisARForcast.Month4
        TheseArForcast.Add(ThisARForcast)
        ThisARForcast = New ARFocast

        ThisARForcast.Client = "Total"
        If AvgDays < 1 Or NoOfClient < 1 Then
            ThisARForcast.AvgDays = 0
        Else
            ThisARForcast.AvgDays = AvgDays / NoOfClient
        End If
        With ThisARForcast
            .OpenARAmt = TotalARAmt
            .TotalARAmt = sumTotalOpenARAmt ' Month1 + Month2 + Month3 + Month4
            .Month1 = Month1
            .Month2 = Month2
            .Month3 = Month3
            .Month4 = Month4
        End With
        TheseArForcast.Add(ThisARForcast)


        dr.Close()

        Return TheseArForcast

    End Function

    Public Function GetARForecastProduct(ByVal UserId As String, Optional ByVal ClientCode As String = "%", Optional ByVal OfficeCode As String = "%", _
                                         Optional ByVal DivisionCode As String = "%", Optional ByVal ProductCode As String = "%", Optional ByVal From As String = "") As ARFocasts
        Dim dr As SqlClient.SqlDataReader
        Dim InvoiceDate As Date
        Dim LastClient As String
        Dim LastDivision As String
        Dim LastProduct As String
        Dim ThisARForcast As ARFocast
        Dim TheseArForcast As ARFocasts
        Dim NoOfClient As Integer
        Dim AvgDays As Integer
        Dim TotalARAmt As Decimal
        Dim Month1 As Decimal
        Dim Month2 As Decimal
        Dim Month3 As Decimal
        Dim Month4 As Decimal
        Dim arParams(6) As SqlParameter

        ' Create parameter for stored procedure
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserId
        arParams(0) = parameterUserID

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = CStr(ClientCode)
        arParams(1) = parameterClientCode

        Dim parameterOfficeCodes As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 6)
        parameterOfficeCodes.Value = CStr(OfficeCode)
        arParams(2) = parameterOfficeCodes

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = CStr(DivisionCode)
        arParams(3) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = CStr(ProductCode)
        arParams(4) = parameterProductCode

        Dim parameterFrom As New SqlParameter("@From", SqlDbType.VarChar, 3)
        parameterFrom.Value = CStr(From)
        arParams(5) = parameterFrom

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_ARForcastProduct", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetARForecastProduct", Err.Description)
        End Try


        ThisARForcast = New ARFocast
        TheseArForcast = New ARFocasts
        LastClient = ""
        LastDivision = ""
        LastProduct = ""
        NoOfClient = 0
        Dim sumTotalOpenARAmt As Double = 0.0
        Do While dr.Read
            If (LastClient <> "" And LastClient <> dr.GetString(0)) Or (LastDivision <> "" And LastDivision <> dr.GetString(1)) Or (LastProduct <> "" And LastProduct <> dr.GetString(2)) Then
                NoOfClient += 1
                AvgDays += ThisARForcast.AvgDays
                TotalARAmt += ThisARForcast.OpenARAmt
                Month1 += ThisARForcast.Month1
                Month2 += ThisARForcast.Month2
                Month3 += ThisARForcast.Month3
                Month4 += ThisARForcast.Month4
                TheseArForcast.Add(ThisARForcast)
                ThisARForcast = New ARFocast
            End If
            ThisARForcast.Client = dr.GetString(0)
            ThisARForcast.Division = dr.GetString(1)
            ThisARForcast.Product = dr.GetString(2)
            If dr.IsDBNull(3) Then
                ThisARForcast.AvgDays = 0
            Else
                ThisARForcast.AvgDays = CStr(dr.GetInt32(3))
            End If
            ThisARForcast.OpenARAmt = CDec(dr.GetDecimal(4))
            If dr.IsDBNull(6) Then
                InvoiceDate = Date.Today
            Else
                InvoiceDate = CDate(dr.GetDateTime(6))
            End If
            If InvoiceDate.Month = Date.Today.Month Then
                ThisARForcast.Month1 += CDec(dr.GetDecimal(4))
            End If
            If InvoiceDate.Month = Date.Today.AddMonths(1).Month Then
                ThisARForcast.Month2 += CDec(dr.GetDecimal(4))
            End If
            If InvoiceDate.Month = Date.Today.AddMonths(2).Month Then
                ThisARForcast.Month3 += CDec(dr.GetDecimal(4))
            End If
            If InvoiceDate.Month = Date.Today.AddMonths(3).Month Then
                ThisARForcast.Month4 += CDec(dr.GetDecimal(4))
            End If

            'If InvoiceDate.Month = Date.Today.Month Then
            '    ThisARForcast.Month1 += CDec(dr.GetDecimal(3))
            'End If
            'If InvoiceDate.Month = Date.Today.AddMonths(1).Month Then
            '    ThisARForcast.Month2 += CDec(dr.GetDecimal(3))
            'End If
            'If InvoiceDate.Month = Date.Today.AddMonths(2).Month Then
            '    ThisARForcast.Month3 += CDec(dr.GetDecimal(3))
            'End If
            'If InvoiceDate.Month = Date.Today.AddMonths(3).Month Then
            '    ThisARForcast.Month4 += CDec(dr.GetDecimal(3))
            'End If
            ThisARForcast.TotalARAmt = dr.GetDecimal(5)
            If ThisARForcast.Client <> LastClient Or ThisARForcast.Division <> LastDivision Or ThisARForcast.Product <> LastProduct Then sumTotalOpenARAmt += ThisARForcast.TotalARAmt
            LastClient = dr.GetString(0)
            LastDivision = dr.GetString(1)
            LastProduct = dr.GetString(2)
        Loop

        NoOfClient += 1
        AvgDays += ThisARForcast.AvgDays
        TotalARAmt += ThisARForcast.OpenARAmt
        Month1 += ThisARForcast.Month1
        Month2 += ThisARForcast.Month2
        Month3 += ThisARForcast.Month3
        Month4 += ThisARForcast.Month4
        TheseArForcast.Add(ThisARForcast)
        ThisARForcast = New ARFocast

        ThisARForcast.Client = "Total"
        If AvgDays < 1 Or NoOfClient < 1 Then
            ThisARForcast.AvgDays = 0
        Else
            ThisARForcast.AvgDays = AvgDays / NoOfClient
        End If
        With ThisARForcast
            .OpenARAmt = TotalARAmt
            .TotalARAmt = sumTotalOpenARAmt ' Month1 + Month2 + Month3 + Month4
            .Month1 = Month1
            .Month2 = Month2
            .Month3 = Month3
            .Month4 = Month4
        End With
        TheseArForcast.Add(ThisARForcast)


        dr.Close()

        Return TheseArForcast

    End Function

    Public Function GetTasks(ByVal UserID As String, ByVal EmpCode As String, ByVal StartDate As Date, ByVal TaskStatus As String,
                             Optional ByVal TaskShow As String = "",
                             Optional ByVal search As String = "",
                             Optional ByVal CP As Boolean = False,
                             Optional ByVal CPID As Integer = 0,
                             Optional ByVal Sort As String = "") As DataTable

        Dim arParams(9) As SqlParameter

        ' Create parameters for stored procedures
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(1) = parameterEmpCode

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 0)
        parameterStartDate.Value = StartDate
        arParams(2) = parameterStartDate

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 10)
        parameterTaskStatus.Value = TaskStatus
        arParams(3) = parameterTaskStatus

        Dim parameterTaskShow As New SqlParameter("@TaskShow", SqlDbType.VarChar, 10)
        parameterTaskShow.Value = TaskShow
        arParams(4) = parameterTaskShow

        Dim parameterSearch As New SqlParameter("@Search", SqlDbType.VarChar, 500)
        parameterSearch.Value = search
        arParams(5) = parameterSearch

        Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            parameterCP.Value = 1
        Else
            parameterCP.Value = 0
        End If
        arParams(6) = parameterCP

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(7) = parameterCPID

        Dim parameterSort As New SqlParameter("@SORT", SqlDbType.VarChar, 50)
        If Sort = "" Then
            parameterSort.Value = System.DBNull.Value
        Else
            parameterSort.Value = Sort
        End If
        arParams(8) = parameterSort

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "advsp_tasks_get_by_employee", "DtTasks", arParams)
        Catch
            Return Nothing
        End Try

    End Function

    Public Function GetTasksNew(ByVal UserID As String, ByVal EmpCode As String, ByVal Role As String, ByVal StartDate As DateTime, ByVal DueDate As DateTime, _
                                ByVal ManagerCode As String, ByVal Office As String, ByVal TaskStatus As String, ByVal search As String, ByVal AccountExecutive As String) As DataTable
        Dim arParams(10) As SqlParameter

        ' Create parameters for stored procedures
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(1) = parameterEmpCode

        Dim parameterRole As New SqlParameter("@Role", SqlDbType.VarChar, 10)
        parameterRole.Value = Role
        arParams(2) = parameterRole

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 0)
        parameterStartDate.Value = StartDate
        arParams(3) = parameterStartDate

        Dim parameterDueDate As New SqlParameter("@DueDate", SqlDbType.DateTime, 0)
        parameterDueDate.Value = DueDate
        arParams(4) = parameterDueDate

        Dim parameterManager As New SqlParameter("@ManagerCode", SqlDbType.VarChar, 6)
        parameterManager.Value = ManagerCode
        arParams(5) = parameterManager

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar, 4)
        parameterOffice.Value = Office
        arParams(6) = parameterOffice

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 10)
        parameterTaskStatus.Value = TaskStatus
        arParams(7) = parameterTaskStatus

        Dim parameterSearch As New SqlParameter("@Search", SqlDbType.VarChar, 500)
        parameterSearch.Value = search
        arParams(8) = parameterSearch

        Dim parameterAcctExec As New SqlParameter("@AcctExec", SqlDbType.VarChar, 6)
        parameterAcctExec.Value = AccountExecutive
        arParams(9) = parameterAcctExec

        Try

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_tasks_new", "DtData", arParams)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function MarkNewTasksComplete(ByVal UserID As String, ByVal EmpCode As String, ByVal Role As String, ByVal StartDate As DateTime, _
                                    ByVal DueDate As DateTime, ByVal ManagerCode As String, ByVal Office As String, ByVal TaskStatus As String, ByVal search As String) As DataTable

        Dim dt As New DataTable
        Dim arParams(9) As SqlParameter

        ' Create parameters for stored procedures
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 140)
        parameterEmpCode.Value = EmpCode
        arParams(1) = parameterEmpCode

        Dim parameterRole As New SqlParameter("@Role", SqlDbType.VarChar, 140)
        parameterRole.Value = Role
        arParams(2) = parameterRole

        Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.DateTime, 0)
        parameterStartDate.Value = StartDate
        arParams(3) = parameterStartDate

        Dim parameterDueDate As New SqlParameter("@DueDate", SqlDbType.DateTime, 0)
        parameterDueDate.Value = DueDate
        arParams(4) = parameterDueDate

        Dim parameterManager As New SqlParameter("@ManagerCode", SqlDbType.VarChar, 6)
        parameterManager.Value = ManagerCode
        arParams(5) = parameterManager

        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar, 4)
        parameterOffice.Value = Office
        arParams(6) = parameterOffice

        Dim parameterTaskStatus As New SqlParameter("@TaskStatus", SqlDbType.VarChar, 10)
        parameterTaskStatus.Value = TaskStatus
        arParams(7) = parameterTaskStatus

        Dim parameterSearch As New SqlParameter("@Search", SqlDbType.VarChar, 500)
        parameterSearch.Value = search
        arParams(8) = parameterSearch

        Try

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_tasks_new_mark_complete", "dt", arParams)

        Catch

            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetTasksNew", Err.Description)

        End Try

        Return dt

    End Function

    Public Function GetInOutBoard() As DataTable
        Try

            Dim TimeZoneOffset As Decimal = 0.0
            Dim cEmployee As New cEmployee(mConnString)

            TimeZoneOffset = cEmployee.GetTimeZoneOffset(False)

            Dim arParams(3) As SqlParameter

            Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = HttpContext.Current.Session("EmpCode")
            arParams(0) = parameterEmpCode

            Dim parameterUserID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            parameterUserID.Value = HttpContext.Current.Session("UserCode")
            arParams(1) = parameterUserID

            Dim parameterTimeZoneOffSet As New SqlParameter("@OFFSET", SqlDbType.Decimal)
            parameterTimeZoneOffSet.Value = TimeZoneOffset
            arParams(2) = parameterTimeZoneOffSet

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_inoutboard", "DtIOB", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:DesktopObject_GetInOutBoard", Err.Description)
        End Try

    End Function

    Public Function tInOutBoardSaveComment(ByVal empcode As String, ByVal comment As String, ByVal reference As Integer) As DataTable
        Try

            Dim arParams(3) As SqlParameter

            Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = empcode
            arParams(0) = parameterEmpCode

            Dim parameterComment As New SqlParameter("@Comment", SqlDbType.VarChar, 50)
            parameterComment.Value = comment
            arParams(1) = parameterComment

            Dim parameterReference As New SqlParameter("@Reference", SqlDbType.Int)
            parameterReference.Value = reference
            arParams(2) = parameterReference

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_inoutboard_save_comment", "DtIOB", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:DesktopObject_GetInOutBoard", Err.Description)
        End Try

    End Function

    Public Function DesktopObject_GetAllProjectsSort(ByVal EmpCode As String, ByVal SortVal As String, ByVal search As String) As DataTable
        Try
            Dim arParams(4) As SqlParameter

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(0) = parameterEmpCode

            Dim parameterSortVal As New SqlParameter("@SortVal", SqlDbType.VarChar, 15)
            parameterSortVal.Value = SortVal
            arParams(1) = parameterSortVal

            Dim parameterSearch As New SqlParameter("@Search", SqlDbType.VarChar, 500)
            parameterSearch.Value = search
            arParams(2) = parameterSearch

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = HttpContext.Current.Session("UserCode")
            arParams(3) = parameterUserID

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_DesktopObject_GetAllProjectsSort", "DtAllProjectSorted", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:DesktopObject_GetMyProjectsSort", Err.Description)
        End Try
    End Function

    Public Function DesktopObject_GetMyProjectsSort(ByVal EmpCode As String, ByVal SortVal As String, ByVal search As String, Optional ByVal CP As Boolean = False, _
                                                    Optional ByVal CPID As Integer = 0) As DataTable
        Try
            Dim arParams(5) As SqlParameter

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(0) = parameterEmpCode

            Dim parameterSortVal As New SqlParameter("@SortVal", SqlDbType.VarChar, 15)
            parameterSortVal.Value = SortVal
            arParams(1) = parameterSortVal

            Dim parameterSearch As New SqlParameter("@Search", SqlDbType.VarChar, 500)
            parameterSearch.Value = search
            arParams(2) = parameterSearch

            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(3) = parameterCP

            Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCPID.Value = CPID
            arParams(4) = parameterCPID

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_DesktopObject_GetMyProjectsSort", "DtMyProjectsSorted", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:DesktopObject_GetMyProjectsSort", Err.Description)
        End Try
    End Function

    Public Function GetMyProjects(ByVal EmpCode As String, Optional ByVal Sort As String = "") As DataTable
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode

        Try
            Select Case Sort
                Case "c"
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetMyProjects1", "DtMyProjectsSorted", parameterEmpCode)
                Case "j"
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetMyProjects2", "DtMyProjectsSorted", parameterEmpCode)
                Case "a"
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetMyProjects3", "DtMyProjectsSorted", parameterEmpCode)
                Case Else
                    Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetMyProjects1", "DtMyProjectsSorted", parameterEmpCode)
            End Select

        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetMyProjects", Err.Description)
        End Try

    End Function

    Public Function GetMyProjectDrillDown(ByVal EmpCode As String, ByVal JobNo As Integer, ByVal JobCompNo As Integer) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter

        ' Create parameter for Stored Procedure
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(0) = parameterEmpCode

        Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int, 4)
        parameterJobNo.Value = JobNo
        arParams(1) = parameterJobNo

        Dim parameterJobCompNo As New SqlParameter("@JobComp", SqlDbType.Int, 4)
        parameterJobCompNo.Value = JobCompNo
        arParams(2) = parameterJobCompNo

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetMyProject_DrillDown", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetMyProjectDrillDown", Err.Description)
        End Try

        Return dr
    End Function

    Public Function GetMyProjectDrillDownHeader(ByVal EmpCode As String, ByVal JobNo As Integer, ByVal JobCompNo As Integer) As DataTable
        Dim arParams(3) As SqlParameter

        ' Create parameters for stored procedure
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(0) = parameterEmpCode

        Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int, 4)
        parameterJobNo.Value = JobNo
        arParams(1) = parameterJobNo

        Dim parameterJobCompNo As New SqlParameter("@JobComp", SqlDbType.Int, 4)
        parameterJobCompNo.Value = JobCompNo
        arParams(2) = parameterJobCompNo

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetMyProject_DrillDown_Header", "DtData", arParams)
        Catch
            Return Nothing
        End Try

    End Function

    Public Function GetQVA(ByVal AE As String, ByVal Client As String, ByVal Division As String, ByVal Product As String, ByVal TimeOnly As Boolean, _
                           ByVal UserID As String, ByVal search As String, ByVal doType As String, ByVal office As String, ByVal salesclass As String, _
                           ByVal manager As String, ByVal job As String, ByVal comp As String, ByVal campaigns As String, ByVal group As String, _
                           ByVal quotetype As String) As DataTable
        Dim arParams(15) As SqlParameter

        Dim parameterEmpCode As New SqlParameter("@AE", SqlDbType.VarChar)
        parameterEmpCode.Value = AE
        arParams(0) = parameterEmpCode

        Dim parameterClient As New SqlParameter("@client", SqlDbType.VarChar)
        parameterClient.Value = Client
        arParams(1) = parameterClient

        Dim parameterDivision As New SqlParameter("@division", SqlDbType.VarChar)
        parameterDivision.Value = Division
        arParams(2) = parameterDivision

        Dim parameterProduct As New SqlParameter("@product", SqlDbType.VarChar)
        parameterProduct.Value = Product
        arParams(3) = parameterProduct

        Dim parameterTimeOnly As New SqlParameter("@TimeOnly", SqlDbType.Char, 1)
        If TimeOnly = True Then
            parameterTimeOnly.Value = "E"
        Else
            parameterTimeOnly.Value = ""
        End If
        arParams(4) = parameterTimeOnly

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(5) = parameterUserID

        Dim parameterSearch As New SqlParameter("@Search", SqlDbType.VarChar, 500)
        parameterSearch.Value = search
        arParams(6) = parameterSearch

        Dim parameterDO As New SqlParameter("@DO", SqlDbType.VarChar, 3)
        parameterDO.Value = doType
        arParams(7) = parameterDO

        Dim parameterOffice As New SqlParameter("@office", SqlDbType.VarChar)
        parameterOffice.Value = office
        arParams(8) = parameterOffice

        Dim parameterSalesClass As New SqlParameter("@salesclass", SqlDbType.VarChar)
        parameterSalesClass.Value = salesclass
        arParams(9) = parameterSalesClass

        Dim parameterManager As New SqlParameter("@manager", SqlDbType.VarChar)
        parameterManager.Value = manager
        arParams(10) = parameterManager

        Dim parameterJob As New SqlParameter("@job", SqlDbType.VarChar)
        parameterJob.Value = job
        arParams(11) = parameterJob

        Dim parameterComp As New SqlParameter("@comp", SqlDbType.VarChar)
        parameterComp.Value = comp
        arParams(12) = parameterComp

        Dim parameterCampaign As New SqlParameter("@campaign", SqlDbType.VarChar)
        parameterCampaign.Value = campaigns
        arParams(13) = parameterCampaign

        Dim parameterGroup As New SqlParameter("@group", SqlDbType.VarChar)
        parameterGroup.Value = group
        arParams(14) = parameterGroup

        Dim parameterQuoteType As New SqlParameter("@quotetype", SqlDbType.VarChar)
        parameterQuoteType.Value = quotetype
        arParams(15) = parameterQuoteType

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_qva", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetQVA", Err.Description)
        End Try

    End Function

    Public Function GetQVAByJobComp(ByVal TimeOnly As Boolean, ByVal UserID As String, ByVal job As Int32, ByVal comp As Int16) As SqlDataReader
        Dim arParams(4) As SqlParameter

        ' Create parameter for stored procedure
        Dim parameterTimeOnly As New SqlParameter("@TimeOnly", SqlDbType.Char, 1)
        If TimeOnly = True Then
            parameterTimeOnly.Value = "E"
        Else
            parameterTimeOnly.Value = ""
        End If
        arParams(0) = parameterTimeOnly

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(1) = parameterUserID

        Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int)
        parameterJobNo.Value = job
        arParams(2) = parameterJobNo

        Dim parameterJobCompNo As New SqlParameter("@JobComp", SqlDbType.Int)
        parameterJobCompNo.Value = comp
        arParams(3) = parameterJobCompNo


        Try
            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_qva_JobComp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetQVA", Err.Description)
        End Try

    End Function

    Public Function GetCashBalance() As DataSet
        Try
            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_dto_CashBalance")
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetCashBalance", Err.Description)
        End Try
    End Function

    Public Function LoadAlerts(ByVal strEmpCode As String) As SqlDataReader
        Dim dr As SqlClient.SqlDataReader
        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = strEmpCode

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_dt_alerts_last5", parameterEmpCode)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:LoadAlerts", Err.Description)
        End Try

        Return dr

    End Function

    'Old Timesheet Object:
    Public Function GetTimeSheets(ByVal strEmpCode As String) As SqlDataReader
        Dim dr As SqlClient.SqlDataReader
        Dim arParams(2) As SqlParameter

        Dim parameterEmpCode As New SqlParameter("@empcode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = strEmpCode
        arParams(0) = parameterEmpCode
        Dim parameterStartDate As New SqlParameter("@startdate", SqlDbType.DateTime)
        parameterStartDate.Value = Today.AddDays(-Today.DayOfWeek)
        arParams(1) = parameterStartDate

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_dt_week_hours", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetTimeSheets", Err.Description)
        End Try

        Return dr
    End Function
    'New Timesheet Object:
    Public Function GetTimesheetDTO(ByVal strEmpCode As String) As DataTable

        Dim ar(3) As SqlParameter
        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        Dim parameterDaysToDisplay As New SqlParameter("@DAYS_TO_DISPLAY", SqlDbType.SmallInt)
        Dim parameterStartDate As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)

        parameterEmpCode.Value = strEmpCode
        ar(0) = parameterEmpCode
        parameterDaysToDisplay.Value = System.DBNull.Value
        ar(1) = parameterDaysToDisplay
        parameterStartDate.Value = System.DBNull.Value
        ar(2) = parameterStartDate

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_Get_Current_Weekly_Time_Total", "dtTimesheet", ar)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetHoursByTypeDTO(ByVal strEmpCode As String) As DataTable

        Dim ar(3) As SqlParameter
        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        Dim parameterDaysToDisplay As New SqlParameter("@DAYS_TO_DISPLAY", SqlDbType.SmallInt)
        Dim parameterStartDate As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)

        parameterEmpCode.Value = strEmpCode
        ar(0) = parameterEmpCode
        parameterDaysToDisplay.Value = System.DBNull.Value
        ar(1) = parameterDaysToDisplay
        parameterStartDate.Value = System.DBNull.Value
        ar(2) = parameterStartDate

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_Get_Current_Weekly_Time_ByType", "dtByType", ar)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetBillingTrends(ByVal strClient As String, ByVal strRecType As String, ByVal sales As String, ByVal userid As String,
                                     ByVal office As String, ByVal division As String, ByVal product As String, ByVal year1 As String, ByVal year2 As String) As SqlDataReader
        Dim dr As SqlClient.SqlDataReader
        Dim aParams(9) As SqlParameter
        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 10)
        parameterClient.Value = strClient
        aParams(0) = parameterClient
        Dim parameterRecType As New SqlParameter("@RecType", SqlDbType.VarChar, 5)
        parameterRecType.Value = strRecType
        aParams(1) = parameterRecType
        Dim parameterYear1 As New SqlParameter("@Year1", SqlDbType.VarChar, 4)
        parameterYear1.Value = year1 'Today.Year.ToString
        aParams(2) = parameterYear1
        Dim parameterYear2 As New SqlParameter("@Year2", SqlDbType.VarChar, 4)
        parameterYear2.Value = year2 'Today.AddYears(-1).Year.ToString
        aParams(3) = parameterYear2
        Dim parameterSales As New SqlParameter("@Sales", SqlDbType.VarChar, 6)
        parameterSales.Value = sales
        aParams(4) = parameterSales
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = userid
        aParams(5) = parameterUserID
        Dim parameterOffice As New SqlParameter("@Office", SqlDbType.VarChar, 6)
        parameterOffice.Value = office
        aParams(6) = parameterOffice
        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivision.Value = division
        aParams(7) = parameterDivision
        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProduct.Value = product
        aParams(8) = parameterProduct
        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_billing_trends", aParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetBillingTrends", Err.Description)
        End Try

        Return dr

    End Function

    Public Function LoadAgencyLinks(ByVal UserID As String, ByVal EmpCode As String, ByVal type As Integer, ByVal privateflag As Integer) As SqlDataReader
        Dim dr As SqlClient.SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(1) = parameterEmpCode

        Dim parameterType As New SqlParameter("@Type", SqlDbType.Int)
        parameterType.Value = type
        arParams(2) = parameterType

        Dim parameterPrivate As New SqlParameter("@Private", SqlDbType.Int)
        parameterPrivate.Value = privateflag
        arParams(3) = parameterPrivate

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetAgencyLinks", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:LoadAgencyLinks", Err.Description)
        End Try

        Return dr

    End Function

    Public Function LoadExecutiveLinks(ByVal UserID As String, ByVal EmpCode As String, ByVal type As Integer, ByVal privateflag As Integer) As SqlDataReader
        Dim dr As SqlClient.SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = EmpCode
        arParams(1) = parameterEmpCode

        Dim parameterType As New SqlParameter("@Type", SqlDbType.Int)
        parameterType.Value = type
        arParams(2) = parameterType

        Dim parameterPrivate As New SqlParameter("@Private", SqlDbType.Int)
        parameterPrivate.Value = privateflag
        arParams(3) = parameterPrivate

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GetExecutiveLinks", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:LoadExecutiveLinks", Err.Description)
        End Try

        Return dr

    End Function

    Public Function GetDeniedTimeEmployee(ByVal userid As String) As DataSet
        Try
            Dim oSQL As SqlHelper
            Dim arParams(0) As SqlParameter

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = userid
            arParams(0) = paramUserID

            Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_get_denied_time_employee", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetDeniedTimeEmployee!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetGrossIncome(ByVal StartDate As String, ByVal EndDate As String, ByVal Office As String, ByVal SalesClass As String, ByVal level As Integer, ByVal userid As String, _
                                   ByVal group As String, ByVal DesktopObject As Integer, ByVal IncludeManualInvoices As Boolean, ByVal IncludeGLEntries As Boolean) As DataTable
        Dim arParams(9) As SqlParameter

        Dim parameterStartDate As New SqlParameter("@StartPeriod", SqlDbType.VarChar)
        parameterStartDate.Value = StartDate
        arParams(0) = parameterStartDate

        Dim parameterEndDate As New SqlParameter("@EndPeriod", SqlDbType.VarChar)
        parameterEndDate.Value = EndDate
        arParams(1) = parameterEndDate

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar)
        parameterOffice.Value = Office
        arParams(2) = parameterOffice

        Dim parameterSalesClass As New SqlParameter("@SalesClassCode", SqlDbType.VarChar)
        parameterSalesClass.Value = SalesClass
        arParams(3) = parameterSalesClass

        Dim parameterLevel As New SqlParameter("@Level", SqlDbType.SmallInt)
        parameterLevel.Value = level
        arParams(4) = parameterLevel

        Dim parameteruserid As New SqlParameter("@USER_ID", SqlDbType.VarChar)
        parameteruserid.Value = userid
        arParams(5) = parameteruserid

        Dim parameterGroup As New SqlParameter("@Group", SqlDbType.VarChar)
        parameterGroup.Value = group
        arParams(6) = parameterGroup

        Dim parameterDesktop As New SqlParameter("@DesktopObject", SqlDbType.SmallInt)
        parameterDesktop.Value = DesktopObject
        arParams(7) = parameterDesktop

        Dim parameterManualInvoices As New SqlParameter("@IncludeManualInvoices", SqlDbType.Bit)
        parameterManualInvoices.Value = IncludeManualInvoices
        arParams(8) = parameterManualInvoices

        Dim parameterGLEntries As New SqlParameter("@IncludeGLEntries", SqlDbType.Bit)
        parameterGLEntries.Value = IncludeGLEntries
        arParams(9) = parameterGLEntries

        Try
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dto_GrossIncome", "DtData", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDesktopObjects Routine:GetGrossIncome", Err.Description)
        End Try

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

End Class
