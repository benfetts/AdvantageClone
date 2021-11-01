Imports System.Data
Imports System
Imports System.Data.SqlClient
<Serializable()> Public Class RptSideMenu
#Region "Internal Variables"
    Inherits CollectionBase
    Private _MenuItem As String
#End Region
    Public Property MenuItem() As String
        Get
            Return _MenuItem
        End Get
        Set(ByVal Value As String)
            _MenuItem = Value
        End Set
    End Property
End Class
<Serializable()> Public Class cReports
    Dim oSQL As SqlHelper
    Public Enum ARStatementsType
        Client = 1
        Product = 2
    End Enum
    Private mConnString As String
    Public Function GetCategories() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Reports_GetCategories")
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetCategories", Err.Description)
        End Try

        Return dr
        dr.Close()
    End Function
    Public Function GetByCatID(ByVal CatID As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        ' Add Parameters to SPROC
        Dim parameterCatID As New SqlParameter("@CatID", SqlDbType.VarChar, 100)
        parameterCatID.Value = CatID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Reports_GetByCategory", parameterCatID)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetByCatID", Err.Description)
        End Try

        Return dr
        dr.Close()
    End Function
    'st, 20060425: added optional var to this function to handle filter in sproc 
    Public Function TrafficScheduleSA(ByVal ClientCodes As String,
                                      ByVal Status As String, ByVal TheseParams() As String,
                                      ByVal CompletedDates As Boolean,
                                      ByVal TrafficClosed As Boolean,
                                      ByVal OnlyProjected As Boolean,
                                      ByVal Offices As String,
                                      ByVal DueDate As Boolean,
                                      ByVal OrigDueDate As Boolean,
                                      ByVal OrigDueDateCompDate As Boolean,
                                      ByVal DueDateCompDate As Boolean,
                                      ByVal EmpCode As Boolean,
                                      ByVal Sort1 As String,
                                      ByVal Sort2 As String,
                                      ByVal ForJobDueDate As Boolean,
                                      ByVal ForJobStartDate As DateTime,
                                      ByVal ForJobEndDate As DateTime,
                                      ByVal IncludeClosedStartDate As DateTime,
                                      ByVal IncludeClosedEndDate As DateTime,
                                      ByVal Manager As String,
                                      ByVal DueTime As Boolean,
                                      ByVal AEs As String,
                                      ByVal UserID As String,
                                      ByVal Roles As String,
                                      Optional ByVal CP As Boolean = False,
                                      Optional ByVal CPID As Integer = 0) As DataSet
        Dim ds As DataSet = New DataSet
        Dim i As Integer
        Dim arParams(55) As SqlParameter

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 4000)
        parameterClient.Value = ClientCodes
        arParams(0) = parameterClient

        For i = 1 To 30
            Dim parameterReport As New SqlParameter("@Task" & CStr(i), SqlDbType.VarChar, 40)
            If TheseParams(i) = "" Then
                parameterReport.Value = ""
            Else
                parameterReport.Value = TheseParams(i)
            End If
            arParams(i) = parameterReport
        Next i

        Dim parameterClosedJobs As New SqlParameter("@ClosedJobs", SqlDbType.Char, 1)
        If TrafficClosed = True Then
            parameterClosedJobs.Value = "Y"
        Else
            parameterClosedJobs.Value = "N"
        End If
        arParams(31) = parameterClosedJobs

        Dim parameterCompleted As New SqlParameter("@CompletedDates", SqlDbType.Char, 1)
        If CompletedDates = True Then
            parameterCompleted.Value = "Y"
        Else
            parameterCompleted.Value = "N"
        End If
        arParams(32) = parameterCompleted

        'st, 20060425:
        Dim parameterOnlyProjected As New SqlParameter("@OnlyProjected", SqlDbType.Char, 1)
        If OnlyProjected = True Then
            parameterOnlyProjected.Value = "Y"
        Else
            parameterOnlyProjected.Value = "N"
        End If
        arParams(33) = parameterOnlyProjected

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4000)
        If Offices = "" Then
            parameterOffice.Value = DBNull.Value
        ElseIf Offices.EndsWith(",") Then
            parameterOffice.Value = Offices.Substring(0, Offices.Length - 1)
        Else
            parameterOffice.Value = Offices
        End If
        arParams(34) = parameterOffice

        Dim parameterStatus As New SqlParameter("@StatusCodes", SqlDbType.VarChar, 4000)
        If Status = "" Then
            parameterStatus.Value = DBNull.Value
        ElseIf Status.EndsWith(",") Then
            parameterStatus.Value = Status.Substring(0, Status.Length - 1)
        Else
            parameterStatus.Value = Status
        End If
        arParams(35) = parameterStatus

        Dim parameterDueDate As New SqlParameter("@DueDate", SqlDbType.Char, 1)
        If DueDate = True Then
            parameterDueDate.Value = "Y"
        Else
            parameterDueDate.Value = "N"
        End If
        arParams(36) = parameterDueDate

        Dim parameterOriginalDueDate As New SqlParameter("@OriginalDueDate", SqlDbType.Char, 1)
        If OrigDueDate = True Then
            parameterOriginalDueDate.Value = "Y"
        Else
            parameterOriginalDueDate.Value = "N"
        End If
        arParams(37) = parameterOriginalDueDate

        Dim parameterOrigDueDateCompDate As New SqlParameter("@OrigDueDateCompDate", SqlDbType.Char, 1)
        If OrigDueDateCompDate = True Then
            parameterOrigDueDateCompDate.Value = "Y"
        Else
            parameterOrigDueDateCompDate.Value = "N"
        End If
        arParams(38) = parameterOrigDueDateCompDate

        Dim parameterDueDateCompDate As New SqlParameter("@DueDateCompDate", SqlDbType.Char, 1)
        If DueDateCompDate = True Then
            parameterDueDateCompDate.Value = "Y"
        Else
            parameterDueDateCompDate.Value = "N"
        End If
        arParams(39) = parameterDueDateCompDate

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.Char, 1)
        If EmpCode = True Then
            parameterEmpCode.Value = "Y"
        Else
            parameterEmpCode.Value = "N"
        End If
        arParams(40) = parameterEmpCode

        Dim parameterSort1 As New SqlParameter("@Sort1", SqlDbType.VarChar)
        parameterSort1.Value = Sort1
        arParams(41) = parameterSort1

        Dim parameterSort2 As New SqlParameter("@Sort2", SqlDbType.VarChar)
        parameterSort2.Value = Sort2
        arParams(42) = parameterSort2

        Dim parameterForJobDueDate As New SqlParameter("@ForJobDueDate", SqlDbType.Char, 1)
        If ForJobDueDate = True Then
            parameterForJobDueDate.Value = "Y"
        Else
            parameterForJobDueDate.Value = "N"
        End If
        arParams(43) = parameterForJobDueDate
        Dim sd As String = ForJobStartDate.ToString
        Dim parameterForJobStartDate As New SqlParameter("@ForJobStartDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(ForJobStartDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterForJobStartDate.Value = DBNull.Value
        Else
            parameterForJobStartDate.Value = ForJobStartDate
        End If
        arParams(44) = parameterForJobStartDate

        Dim parameterForJobEndDate As New SqlParameter("@ForJobEndDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(ForJobEndDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterForJobEndDate.Value = DBNull.Value
        Else
            parameterForJobEndDate.Value = ForJobEndDate
        End If
        arParams(45) = parameterForJobEndDate

        Dim parameterIncludeClosedStartDate As New SqlParameter("@IncludeClosedStartDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(IncludeClosedStartDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterIncludeClosedStartDate.Value = DBNull.Value
        Else
            parameterIncludeClosedStartDate.Value = IncludeClosedStartDate
        End If
        arParams(46) = parameterIncludeClosedStartDate

        Dim parameterIncludeClosedEndDate As New SqlParameter("@IncludeClosedEndDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(IncludeClosedEndDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterIncludeClosedEndDate.Value = DBNull.Value
        Else
            parameterIncludeClosedEndDate.Value = IncludeClosedEndDate
        End If

        arParams(47) = parameterIncludeClosedEndDate

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar)
        parameterManager.Value = Manager
        arParams(48) = parameterManager

        Dim parameterDueTime As New SqlParameter("@DueTime", SqlDbType.Char, 1)
        If DueTime = True Then
            parameterDueTime.Value = "Y"
        Else
            parameterDueTime.Value = "N"
        End If
        arParams(49) = parameterDueTime

        Dim parameterAE As New SqlParameter("@AEs", SqlDbType.VarChar, 4000)
        If AEs = "" Then
            parameterAE.Value = "%"
        ElseIf AEs.EndsWith(",") Then
            parameterAE.Value = AEs.Substring(0, AEs.Length - 1)
        Else
            parameterAE.Value = AEs
        End If
        arParams(50) = parameterAE

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(51) = parameterUserID

        Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            parameterCP.Value = 1
        Else
            parameterCP.Value = 0
        End If
        arParams(52) = parameterCP

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(53) = parameterCPID

        'Dim parameterFirstJobStatus As New SqlParameter("@FirstJobStatus", SqlDbType.Bit)
        'parameterFirstJobStatus.Value = FirstJobStatus
        'arParams(54) = parameterFirstJobStatus

        'Dim parameterRlCodes As New SqlParameter("@RlCodes", SqlDbType.VarChar, 4000)
        'If Roles = "" Then
        '    parameterRlCodes.Value = "%"
        'ElseIf Roles.EndsWith(",") Then
        '    parameterRlCodes.Value = Roles.Substring(0, Roles.Length - 1)
        'Else
        '    parameterRlCodes.Value = Roles
        'End If
        'arParams(52) = parameterRlCodes


        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_reports_traffic_schedule_sa_getTasks", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:TrafficScheduleSA", Err.Description)
        End Try

        Return ds

    End Function
    Public Function TrafficScheduleSARoles(ByVal ClientCodes As String, _
                                      ByVal Status As String, ByVal TheseParams() As String, _
                                      ByVal CompletedDates As Boolean, _
                                      ByVal TrafficClosed As Boolean, _
                                      ByVal OnlyProjected As Boolean, _
                                      ByVal Offices As String, _
                                      ByVal DueDate As Boolean, _
                                      ByVal OrigDueDate As Boolean, _
                                      ByVal OrigDueDateCompDate As Boolean, _
                                      ByVal DueDateCompDate As Boolean, _
                                      ByVal EmpCode As Boolean, _
                                      ByVal Sort1 As String, _
                                      ByVal Sort2 As String, _
                                      ByVal ForJobDueDate As Boolean, _
                                      ByVal ForJobStartDate As DateTime, _
                                      ByVal ForJobEndDate As DateTime, _
                                      ByVal IncludeClosedStartDate As DateTime, _
                                      ByVal IncludeClosedEndDate As DateTime, _
                                      ByVal Manager As String, _
                                      ByVal DueTime As Boolean, _
                                      ByVal AEs As String, _
                                      ByVal UserID As String, _
                                      ByVal Roles As String, _
                                      Optional ByVal CP As Boolean = False, _
                                      Optional ByVal CPID As Integer = 0) As DataSet
        Dim ds As DataSet = New DataSet
        Dim i As Integer
        Dim arParams(55) As SqlParameter

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 4000)
        parameterClient.Value = ClientCodes
        arParams(0) = parameterClient

        For i = 1 To 30
            Dim parameterReport As New SqlParameter("@Task" & CStr(i), SqlDbType.VarChar, 40)
            If TheseParams(i) = "" Then
                parameterReport.Value = ""
            Else
                parameterReport.Value = TheseParams(i)
            End If
            arParams(i) = parameterReport
        Next i

        Dim parameterClosedJobs As New SqlParameter("@ClosedJobs", SqlDbType.Char, 1)
        If TrafficClosed = True Then
            parameterClosedJobs.Value = "Y"
        Else
            parameterClosedJobs.Value = "N"
        End If
        arParams(31) = parameterClosedJobs

        Dim parameterCompleted As New SqlParameter("@CompletedDates", SqlDbType.Char, 1)
        If CompletedDates = True Then
            parameterCompleted.Value = "Y"
        Else
            parameterCompleted.Value = "N"
        End If
        arParams(32) = parameterCompleted

        'st, 20060425:
        Dim parameterOnlyProjected As New SqlParameter("@OnlyProjected", SqlDbType.Char, 1)
        If OnlyProjected = True Then
            parameterOnlyProjected.Value = "Y"
        Else
            parameterOnlyProjected.Value = "N"
        End If
        arParams(33) = parameterOnlyProjected

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4000)
        If Offices = "" Then
            parameterOffice.Value = DBNull.Value
        ElseIf Offices.EndsWith(",") Then
            parameterOffice.Value = Offices.Substring(0, Offices.Length - 1)
        Else
            parameterOffice.Value = Offices
        End If
        arParams(34) = parameterOffice

        Dim parameterStatus As New SqlParameter("@StatusCodes", SqlDbType.VarChar, 4000)
        If Status = "" Then
            parameterStatus.Value = DBNull.Value
        ElseIf Status.EndsWith(",") Then
            parameterStatus.Value = Status.Substring(0, Status.Length - 1)
        Else
            parameterStatus.Value = Status
        End If
        arParams(35) = parameterStatus

        Dim parameterDueDate As New SqlParameter("@DueDate", SqlDbType.Char, 1)
        If DueDate = True Then
            parameterDueDate.Value = "Y"
        Else
            parameterDueDate.Value = "N"
        End If
        arParams(36) = parameterDueDate

        Dim parameterOriginalDueDate As New SqlParameter("@OriginalDueDate", SqlDbType.Char, 1)
        If OrigDueDate = True Then
            parameterOriginalDueDate.Value = "Y"
        Else
            parameterOriginalDueDate.Value = "N"
        End If
        arParams(37) = parameterOriginalDueDate

        Dim parameterOrigDueDateCompDate As New SqlParameter("@OrigDueDateCompDate", SqlDbType.Char, 1)
        If OrigDueDateCompDate = True Then
            parameterOrigDueDateCompDate.Value = "Y"
        Else
            parameterOrigDueDateCompDate.Value = "N"
        End If
        arParams(38) = parameterOrigDueDateCompDate

        Dim parameterDueDateCompDate As New SqlParameter("@DueDateCompDate", SqlDbType.Char, 1)
        If DueDateCompDate = True Then
            parameterDueDateCompDate.Value = "Y"
        Else
            parameterDueDateCompDate.Value = "N"
        End If
        arParams(39) = parameterDueDateCompDate

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.Char, 1)
        If EmpCode = True Then
            parameterEmpCode.Value = "Y"
        Else
            parameterEmpCode.Value = "N"
        End If
        arParams(40) = parameterEmpCode

        Dim parameterSort1 As New SqlParameter("@Sort1", SqlDbType.VarChar)
        parameterSort1.Value = Sort1
        arParams(41) = parameterSort1

        Dim parameterSort2 As New SqlParameter("@Sort2", SqlDbType.VarChar)
        parameterSort2.Value = Sort2
        arParams(42) = parameterSort2

        Dim parameterForJobDueDate As New SqlParameter("@ForJobDueDate", SqlDbType.Char, 1)
        If ForJobDueDate = True Then
            parameterForJobDueDate.Value = "Y"
        Else
            parameterForJobDueDate.Value = "N"
        End If
        arParams(43) = parameterForJobDueDate
        Dim sd As String = ForJobStartDate.ToString
        Dim parameterForJobStartDate As New SqlParameter("@ForJobStartDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(ForJobStartDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterForJobStartDate.Value = DBNull.Value
        Else
            parameterForJobStartDate.Value = ForJobStartDate
        End If
        arParams(44) = parameterForJobStartDate

        Dim parameterForJobEndDate As New SqlParameter("@ForJobEndDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(ForJobEndDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterForJobEndDate.Value = DBNull.Value
        Else
            parameterForJobEndDate.Value = ForJobEndDate
        End If
        arParams(45) = parameterForJobEndDate

        Dim parameterIncludeClosedStartDate As New SqlParameter("@IncludeClosedStartDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(IncludeClosedStartDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterIncludeClosedStartDate.Value = DBNull.Value
        Else
            parameterIncludeClosedStartDate.Value = IncludeClosedStartDate
        End If
        arParams(46) = parameterIncludeClosedStartDate

        Dim parameterIncludeClosedEndDate As New SqlParameter("@IncludeClosedEndDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(IncludeClosedEndDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterIncludeClosedEndDate.Value = DBNull.Value
        Else
            parameterIncludeClosedEndDate.Value = IncludeClosedEndDate
        End If

        arParams(47) = parameterIncludeClosedEndDate

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar)
        parameterManager.Value = Manager
        arParams(48) = parameterManager

        Dim parameterDueTime As New SqlParameter("@DueTime", SqlDbType.Char, 1)
        If DueTime = True Then
            parameterDueTime.Value = "Y"
        Else
            parameterDueTime.Value = "N"
        End If
        arParams(49) = parameterDueTime

        Dim parameterAE As New SqlParameter("@AEs", SqlDbType.VarChar, 4000)
        If AEs = "" Then
            parameterAE.Value = "%"
        ElseIf AEs.EndsWith(",") Then
            parameterAE.Value = AEs.Substring(0, AEs.Length - 1)
        Else
            parameterAE.Value = AEs
        End If
        arParams(50) = parameterAE

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(51) = parameterUserID

        Dim parameterRlCodes As New SqlParameter("@RlCodes", SqlDbType.VarChar, 4000)
        If Roles = "" Then
            parameterRlCodes.Value = "%"
        ElseIf Roles.EndsWith(",") Then
            parameterRlCodes.Value = Roles.Substring(0, Roles.Length - 1)
        Else
            parameterRlCodes.Value = Roles
        End If
        arParams(52) = parameterRlCodes

        Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            parameterCP.Value = 1
        Else
            parameterCP.Value = 0
        End If
        arParams(53) = parameterCP

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(54) = parameterCPID


        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_reports_traffic_schedule_sa_getRoles", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:TrafficScheduleSA", Err.Description)
        End Try

        Return ds

    End Function
    Public Function TrafficScheduleCompletedSA(ByVal ClientCodes As String, _
                                      ByVal Status As String, ByVal TheseParams() As String, _
                                      ByVal CompletedDates As Boolean, _
                                      ByVal TrafficClosed As Boolean, _
                                      ByVal OnlyProjected As Boolean, _
                                      ByVal Offices As String, _
                                      ByVal DueDate As Boolean, _
                                      ByVal OrigDueDate As Boolean, _
                                      ByVal OrigDueDateCompDate As Boolean, _
                                      ByVal DueDateCompDate As Boolean, _
                                      ByVal EmpCode As Boolean, _
                                      ByVal Sort1 As String, _
                                      ByVal Sort2 As String, _
                                      ByVal ForJobDueDate As Boolean, _
                                      ByVal ForJobStartDate As DateTime, _
                                      ByVal ForJobEndDate As DateTime, _
                                      ByVal IncludeClosedStartDate As DateTime, _
                                      ByVal IncludeClosedEndDate As DateTime, _
                                      ByVal Manager As String, _
                                      ByVal DueTime As Boolean, _
                                      ByVal AEs As String,
                                      ByVal UserID As String, _
                                      Optional ByVal CP As Boolean = False, _
                                      Optional ByVal CPID As Integer = 0) As DataSet
        Dim ds As DataSet = New DataSet
        Dim i As Integer
        Dim arParams(54) As SqlParameter

        Dim parameterClient As New SqlParameter("@ClientCode", SqlDbType.VarChar, 4000)
        parameterClient.Value = ClientCodes
        arParams(0) = parameterClient

        'For i = 1 To 30
        '    Dim parameterReport As New SqlParameter("@Task" & CStr(i), SqlDbType.VarChar, 40)
        '    If TheseParams(i) = "" Then
        '        parameterReport.Value = ""
        '    Else
        '        parameterReport.Value = TheseParams(i)
        '    End If
        '    arParams(i) = parameterReport
        'Next i

        Dim parameterClosedJobs As New SqlParameter("@ClosedJobs", SqlDbType.Char, 1)
        If TrafficClosed = True Then
            parameterClosedJobs.Value = "Y"
        Else
            parameterClosedJobs.Value = "N"
        End If
        arParams(31) = parameterClosedJobs

        Dim parameterCompleted As New SqlParameter("@CompletedDates", SqlDbType.Char, 1)
        If CompletedDates = True Then
            parameterCompleted.Value = "Y"
        Else
            parameterCompleted.Value = "N"
        End If
        arParams(32) = parameterCompleted

        'st, 20060425:
        Dim parameterOnlyProjected As New SqlParameter("@OnlyProjected", SqlDbType.Char, 1)
        If OnlyProjected = True Then
            parameterOnlyProjected.Value = "Y"
        Else
            parameterOnlyProjected.Value = "N"
        End If
        arParams(33) = parameterOnlyProjected

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4000)
        If Offices = "" Then
            parameterOffice.Value = DBNull.Value
        ElseIf Offices.EndsWith(",") Then
            parameterOffice.Value = Offices.Substring(0, Offices.Length - 1)
        Else
            parameterOffice.Value = Offices
        End If
        arParams(34) = parameterOffice

        Dim parameterStatus As New SqlParameter("@StatusCodes", SqlDbType.VarChar, 4000)
        If Status = "" Then
            parameterStatus.Value = DBNull.Value
        ElseIf Status.EndsWith(",") Then
            parameterStatus.Value = Status.Substring(0, Status.Length - 1)
        Else
            parameterStatus.Value = Status
        End If
        arParams(35) = parameterStatus

        Dim parameterDueDate As New SqlParameter("@DueDate", SqlDbType.Char, 1)
        If DueDate = True Then
            parameterDueDate.Value = "Y"
        Else
            parameterDueDate.Value = "N"
        End If
        arParams(36) = parameterDueDate

        Dim parameterOriginalDueDate As New SqlParameter("@OriginalDueDate", SqlDbType.Char, 1)
        If OrigDueDate = True Then
            parameterOriginalDueDate.Value = "Y"
        Else
            parameterOriginalDueDate.Value = "N"
        End If
        arParams(37) = parameterOriginalDueDate

        Dim parameterOrigDueDateCompDate As New SqlParameter("@OrigDueDateCompDate", SqlDbType.Char, 1)
        If OrigDueDateCompDate = True Then
            parameterOrigDueDateCompDate.Value = "Y"
        Else
            parameterOrigDueDateCompDate.Value = "N"
        End If
        arParams(38) = parameterOrigDueDateCompDate

        Dim parameterDueDateCompDate As New SqlParameter("@DueDateCompDate", SqlDbType.Char, 1)
        If DueDateCompDate = True Then
            parameterDueDateCompDate.Value = "Y"
        Else
            parameterDueDateCompDate.Value = "N"
        End If
        arParams(39) = parameterDueDateCompDate

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.Char, 1)
        If EmpCode = True Then
            parameterEmpCode.Value = "Y"
        Else
            parameterEmpCode.Value = "N"
        End If
        arParams(40) = parameterEmpCode

        Dim parameterSort1 As New SqlParameter("@Sort1", SqlDbType.VarChar)
        parameterSort1.Value = Sort1
        arParams(41) = parameterSort1

        Dim parameterSort2 As New SqlParameter("@Sort2", SqlDbType.VarChar)
        parameterSort2.Value = Sort2
        arParams(42) = parameterSort2

        Dim parameterForJobDueDate As New SqlParameter("@ForJobDueDate", SqlDbType.Char, 1)
        If ForJobDueDate = True Then
            parameterForJobDueDate.Value = "Y"
        Else
            parameterForJobDueDate.Value = "N"
        End If
        arParams(43) = parameterForJobDueDate
        Dim sd As String = ForJobStartDate.ToString
        Dim parameterForJobStartDate As New SqlParameter("@ForJobStartDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(ForJobStartDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterForJobStartDate.Value = DBNull.Value
        Else
            parameterForJobStartDate.Value = ForJobStartDate
        End If
        arParams(44) = parameterForJobStartDate

        Dim parameterForJobEndDate As New SqlParameter("@ForJobEndDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(ForJobEndDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterForJobEndDate.Value = DBNull.Value
        Else
            parameterForJobEndDate.Value = ForJobEndDate
        End If
        arParams(45) = parameterForJobEndDate

        Dim parameterIncludeClosedStartDate As New SqlParameter("@IncludeClosedStartDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(IncludeClosedStartDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterIncludeClosedStartDate.Value = DBNull.Value
        Else
            parameterIncludeClosedStartDate.Value = IncludeClosedStartDate
        End If
        arParams(46) = parameterIncludeClosedStartDate

        Dim parameterIncludeClosedEndDate As New SqlParameter("@IncludeClosedEndDate", SqlDbType.DateTime)
        If LoGlo.FormatDate(IncludeClosedEndDate.ToString()) = LoGlo.FormatDate("1/1/0001 12:00:00 AM") Then
            parameterIncludeClosedEndDate.Value = DBNull.Value
        Else
            parameterIncludeClosedEndDate.Value = IncludeClosedEndDate
        End If

        arParams(47) = parameterIncludeClosedEndDate

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar)
        parameterManager.Value = Manager
        arParams(48) = parameterManager

        Dim parameterDueTime As New SqlParameter("@DueTime", SqlDbType.Char, 1)
        If DueTime = True Then
            parameterDueTime.Value = "Y"
        Else
            parameterDueTime.Value = "N"
        End If
        arParams(49) = parameterDueTime

        Dim parameterAE As New SqlParameter("@AEs", SqlDbType.VarChar, 4000)
        If AEs = "" Then
            parameterAE.Value = "%"
        ElseIf AEs.EndsWith(",") Then
            parameterAE.Value = AEs.Substring(0, AEs.Length - 1)
        Else
            parameterAE.Value = AEs
        End If
        arParams(50) = parameterAE

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(51) = parameterUserID

        Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            parameterCP.Value = 1
        Else
            parameterCP.Value = 0
        End If
        arParams(52) = parameterCP

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(53) = parameterCPID


        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_reports_traffic_schedule_sa_getCompTasks", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:TrafficScheduleCompletedSA", Err.Description)
        End Try

        Return ds

    End Function
    Public Function GetARStatements(ByVal Type As ARStatementsType, ByVal UserID As String, Optional ByVal OfficeList As String = "", Optional ByVal AEList As String = "") As DataTable
        Dim arP(3) As SqlParameter
        Dim p0 As New SqlParameter("@OFFICE_CODES", SqlDbType.VarChar, 8000)
        p0.Value = OfficeList
        arP(0) = p0

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arP(1) = parameterUserID

        Dim p2 As New SqlParameter("@AE_CODES", SqlDbType.VarChar, 8000)
        p2.Value = AEList
        arP(2) = p2

        Try
            If Type = ARStatementsType.Client Then
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_setupscreen_client", "DtClientAR", arP)
            ElseIf Type = ARStatementsType.Product Then
                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_setupscreen_product", "DTProductAR", arP)
            End If
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetARStatements", Err.Description)
        End Try
    End Function

    Public Function GetARStatementsDS(ByVal Type As ARStatementsType, Optional ByVal OfficeList As String = "") As DataSet
        Dim arP(1) As SqlParameter
        Dim p0 As New SqlParameter("@OFFICE_CODES", SqlDbType.VarChar, 8000)
        p0.Value = OfficeList
        arP(0) = p0
        Dim ds As DataSet
        Try
            If Type = ARStatementsType.Client Then
                ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_setupscreen_client", arP)
            ElseIf Type = ARStatementsType.Product Then
                ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_setupscreen_product", arP)
            End If
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetARStatements", Err.Description)
        End Try
        Return ds
    End Function

    Public Overloads Function GetCCList(ByVal ClientCode As String, ByVal CurrentContactCode As String) As SqlDataReader
        Try
            Dim oSQL As SqlHelper
            Dim arParams(2) As SqlParameter
            Dim StrReturn As String = ""

            Dim parameterClientCode As New SqlParameter("@CLI_CODE", SqlDbType.VarChar, 6)
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterContactCode As New SqlParameter("@CONTACT_CODE", SqlDbType.VarChar, 6)
            parameterContactCode.Value = CurrentContactCode
            arParams(1) = parameterContactCode


            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_client_CC", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "cReports:GetCCList_Client", Err.Description)
        End Try
    End Function

    Public Overloads Function GetCCList(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal CurrentContactCode As String) As SqlDataReader
        Try
            Dim oSQL As SqlHelper
            Dim arParams(4) As SqlParameter
            Dim StrReturn As String = ""

            Dim parameterClientCode As New SqlParameter("@CLI_CODE", SqlDbType.VarChar, 6)
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterContactCode As New SqlParameter("@CONTACT_CODE", SqlDbType.VarChar, 6)
            parameterContactCode.Value = CurrentContactCode
            arParams(3) = parameterContactCode

            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_product_CC", arParams)

        Catch ex As Exception
            Err.Raise(Err.Number, "cReports:GetCCList_Product", Err.Description)
        End Try
    End Function


    Public Function GetReports(ByVal intCatID As Integer, ByVal blnNewOnly As Boolean) As SqlDataReader
        Dim dr As SqlDataReader

        Dim arParams(2) As SqlParameter

        Dim parameterCatID As New SqlParameter("@CatID", SqlDbType.Int)
        parameterCatID.Value = intCatID
        arParams(0) = parameterCatID
        Dim parameterNewOnly As New SqlParameter("@NewOnly", SqlDbType.Bit)
        parameterNewOnly.Value = blnNewOnly
        arParams(1) = parameterNewOnly

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Reports_Unlock_GetByCategory", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetReports", Err.Description)
        End Try

        Return dr
        dr.Close()
    End Function
    Public Function GetReportCategories() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_Reports_Unlock_GetCategories")
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetReports", Err.Description)
        End Try

        Return dr
        dr.Close()
    End Function
    Public Function UpdateReportLock(ByVal ReportID As Integer, ByVal Locked As Boolean) As Boolean
        Dim arParams(2) As SqlParameter

        Dim parameterReportID As New SqlParameter("@ReportID", SqlDbType.Int)
        parameterReportID.Value = ReportID
        arParams(0) = parameterReportID
        Dim parameterLocked As New SqlParameter("@Locked", SqlDbType.Bit)
        parameterLocked.Value = Locked
        arParams(1) = parameterLocked

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_Reports_Update_Locking", arParams)
            Return True
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:UpdateReportLock", Err.Description)
            Return False
        End Try


    End Function
    Public Function GetLocationPO() As SqlDataReader
        Return oSQL.ExecuteReader(mConnString, CommandType.Text, "SELECT ID+' - '+NAME AS ID,ID+'|'+ISNULL(LOGO_PATH,'') AS LOGO_PATH FROM LOCATIONS")
    End Function

    Public Function GetLocation() As SqlDataReader
        Return oSQL.ExecuteReader(mConnString, CommandType.Text, "SELECT ID,LOGO_PATH, ID+' - '+NAME AS DESCRIPTION FROM LOCATIONS")
    End Function

    Public Function GetLocationByID(ByVal LogoID As String)
        Return oSQL.ExecuteScalar(mConnString, CommandType.Text, "SELECT NAME FROM LOCATIONS WHERE ID='" & LogoID & "'")
    End Function
    Public Function GetLocationLogoPathByID(ByVal LogoID As String)
        Return oSQL.ExecuteScalar(mConnString, CommandType.Text, "SELECT LOGO_PATH FROM LOCATIONS WHERE ID='" & LogoID & "'")
    End Function
    Public Function GetUserIDJobOrderFormSettings(ByVal userid As String) As SqlDataReader
        Return oSQL.ExecuteReader(mConnString, CommandType.Text, "SELECT USER_ID FROM PRINT_JOB_ORDER_DEF WHERE USER_ID='" & userid & "'")
    End Function

    Public Function GetReportTaskEmp(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Try
            Dim str As String
            Dim arParams(3) As SqlParameter

            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum

            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum

            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum

            Dim dr As SqlDataReader
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_reports_GetEmpList", arParams)
            If dr.HasRows Then
                Do While dr.Read
                    Try
                        str &= dr("EMP_LNAME_LIST").ToString() & ", "
                    Catch ex As Exception

                    End Try
                Loop
                If str <> "" Then
                    Return MiscFN.RemoveTrailingDelimiter(str, ",")
                End If
            Else
                Return ""
            End If
        Catch ex As Exception

        End Try
    End Function
    Public Function GetReportScheduleTasks(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal Sort As String, ByVal milestone As Boolean, Optional ByVal completed As Boolean = True) As DataSet
        Try
            Dim arParams(5) As SqlParameter

            Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Dim paramSort As New SqlParameter("@Sort", SqlDbType.VarChar, 10)
            paramSort.Value = Sort
            arParams(2) = paramSort

            Dim paramMS As New SqlParameter("@MS", SqlDbType.Int)
            If milestone = True Then
                paramMS.Value = 1
            Else
                paramMS.Value = 0
            End If
            arParams(3) = paramMS

            Dim paramCompleted As New SqlParameter("@Completed", SqlDbType.Int)
            If completed = True Then
                paramCompleted.Value = 1
            Else
                paramCompleted.Value = 0
            End If
            arParams(4) = paramCompleted

            Dim ds As New DataSet
            Dim dt As New DataTable
            ds = oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_Traffic_Schedule_GetTasks_Report", arParams)
            'dt = ds.Tables(0)
            Return ds
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GetTrafficScheduleTasksReport!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Function

    Public Function GetManagerLabel(ByVal UserID As String) As String

        ' Create parameter for stored procedure
        Dim parameterUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
        parameterUSER_ID.Value = UserID

        Try
            Return oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_GetManagerLabel", parameterUSER_ID)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetManagerLabel", Err.Description)
        End Try

    End Function
    Public Function GetAgencyName() As String

        ' Create parameter for stored procedure
        Dim parameterAgencyName As New SqlParameter("@AgencyName", SqlDbType.VarChar, 50)
        parameterAgencyName.Direction = ParameterDirection.Output

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_rpt_GetAgencyName", parameterAgencyName)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetAgencyName", Err.Description)
        End Try

        Return CStr(parameterAgencyName.Value)
    End Function
    Public Function GetAgencyFooter(ByVal strLocation As String) As String
        Dim strFooter As String
        Dim dr As SqlDataReader
        ' Create parameter for stored procedure
        Dim parameterLocation As New SqlParameter("@Location", SqlDbType.VarChar, 6)
        parameterLocation.Value = strLocation

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_getfooter", parameterLocation)

            If dr.HasRows Then
                Do While dr.Read
                    If IsDBNull(dr("Footer")) Then
                        strFooter = ""
                    Else
                        strFooter = CStr(dr("Footer"))
                    End If
                Loop
            End If

            dr.Close()

        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetAgencyFooter", Err.Description)
        End Try
        Return strFooter
    End Function
    Public Function CheckForRecordPostPeriod(ByVal strID As String, ByVal strPostPeriod As String, ByVal strLocation As String, ByVal strAgedDate As String, ByVal strClientProductCHK As String) As Boolean
        Dim intRecords As Integer
        Dim strStoredProcedure As String
        Dim arParams(4) As SqlParameter

        Dim parameterID As New SqlParameter("@ID", SqlDbType.VarChar, 2000)
        parameterID.Value = strID
        arParams(0) = parameterID
        Dim parameterPostPeriod As New SqlParameter("@PostPeriod", SqlDbType.VarChar, 6)
        parameterPostPeriod.Value = strPostPeriod
        arParams(1) = parameterPostPeriod
        Dim parameterLocation As New SqlParameter("@Location", SqlDbType.VarChar, 6)
        parameterLocation.Value = strLocation
        arParams(2) = parameterLocation
        Dim parameterAgedDate As New SqlParameter("@AgedDate", SqlDbType.VarChar, 10)
        parameterAgedDate.Value = strAgedDate
        arParams(3) = parameterAgedDate

        If strClientProductCHK = "C" Then
            strStoredProcedure = "usp_wv_reports_ar_statements_client_count"
        Else
            strStoredProcedure = "usp_wv_reports_ar_statements_product_count"
        End If

        Try
            intRecords = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, strStoredProcedure, arParams))
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:CheckForRecordPostPeriod", Err.Description)
        End Try

        If intRecords > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function GetReportSideMenu(ByVal strUserID As String, ByVal intCategory As Integer) As RptSideMenu
        Dim dr As SqlDataReader, strURL As String, strImagePath As String, strImagePathActive As String
        Dim strReportName As String
        Dim colRptSideMenu As RptSideMenu = New RptSideMenu

        Dim arParams(2) As SqlParameter

        ' Create parameters for stored procedure
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = strUserID
        arParams(0) = parameterUserID
        Dim parameterCatID As New SqlParameter("@CATID", SqlDbType.Int)
        parameterCatID.Value = intCategory
        arParams(1) = parameterCatID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_menu_reports", arParams)

            If dr.HasRows Then
                Do While dr.Read
                    If IsDBNull(dr("URL")) Then
                        strURL = ""
                    Else
                        strURL = CStr(dr("URL"))
                    End If
                    If IsDBNull(dr("IMAGEPATH")) Then
                        strImagePath = ""
                    Else
                        strImagePath = CStr(dr("IMAGEPATH"))
                    End If
                    If IsDBNull(dr("IMAGEPATHACTIVE")) Then
                        strImagePathActive = ""
                    Else
                        strImagePathActive = CStr(dr("IMAGEPATHACTIVE"))
                    End If
                    If IsDBNull(dr("REPORTNAME")) Then
                        strReportName = ""
                    Else
                        strReportName = CStr(dr("REPORTNAME"))
                    End If

                    colRptSideMenu.MenuItem = colRptSideMenu.MenuItem & "<A href=""" & strURL & """   ><IMG  alt=""" & Replace(strReportName, "<br />", "") & """  height=""24"" width=""24"" src=""Images/" & strImagePath & """ border=""0"" name=""" & Replace(strReportName, "<br />", "") & """><br /><span class=""SuperSmallFont"">" & strReportName & "</span></A><br /><br />"
                Loop

            End If

        Catch
            Err.Raise(9999, , Err.Description)
        End Try

        dr.Close()

        GetReportSideMenu = colRptSideMenu

    End Function
    Public Function UpdateProductEmail(ByVal ClientID As String, ByVal DivisionID As String, ByVal ProductID As String, ByVal ContactID As String) As Boolean
        Dim arParams(4) As SqlParameter

        Dim parameterClientID As New SqlParameter("@ClientID", SqlDbType.VarChar, (6))
        parameterClientID.Value = ClientID
        arParams(0) = parameterClientID
        Dim parameterDivisionID As New SqlParameter("@DivisionID", SqlDbType.VarChar, (6))
        parameterDivisionID.Value = DivisionID
        arParams(1) = parameterDivisionID
        Dim parameterProductID As New SqlParameter("@ProductID", SqlDbType.VarChar, (6))
        parameterProductID.Value = ProductID
        arParams(2) = parameterProductID
        Dim parameterContactID As New SqlParameter("@ContactCode", SqlDbType.VarChar, (6))
        parameterContactID.Value = ContactID
        arParams(3) = parameterContactID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_updateemailed_product", arParams)
            Return True
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:UpdateProductEmail", Err.Description)
            Return False
        End Try

    End Function
    Public Function UpdateProductPrint(ByVal ClientID As String, ByVal DivisionID As String, ByVal ProductID As String, ByVal ContactID As String) As Boolean
        Dim arParams(4) As SqlParameter

        Dim parameterClientID As New SqlParameter("@ClientID", SqlDbType.VarChar, (6))
        parameterClientID.Value = ClientID
        arParams(0) = parameterClientID
        Dim parameterDivisionID As New SqlParameter("@DivisionID", SqlDbType.VarChar, (6))
        parameterDivisionID.Value = DivisionID
        arParams(1) = parameterDivisionID
        Dim parameterProductID As New SqlParameter("@ProductID", SqlDbType.VarChar, (6))
        parameterProductID.Value = ProductID
        arParams(2) = parameterProductID
        Dim parameterContactID As New SqlParameter("@ContactCode", SqlDbType.VarChar, (6))
        parameterContactID.Value = ContactID
        arParams(3) = parameterContactID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_updateprinted_product", arParams)
            Return True
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:UpdateProductPrint", Err.Description)
            Return False
        End Try

    End Function
    Public Function UpdateClientEmail(ByVal ClientID As String, ByVal ContactID As String) As Boolean
        Dim arParams(2) As SqlParameter

        Dim parameterClientID As New SqlParameter("@ClientID", SqlDbType.VarChar, (6))
        parameterClientID.Value = ClientID
        arParams(0) = parameterClientID
        Dim parameterContactID As New SqlParameter("@ContactCode", SqlDbType.VarChar, (6))
        parameterContactID.Value = ContactID
        arParams(1) = parameterContactID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_updateemailed_client", arParams)
            Return True
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:UpdateClientEmail", Err.Description)
            Return False
        End Try

    End Function
    Public Function UpdateClientPrint(ByVal ClientID As String, ByVal ContactID As String) As Boolean
        Dim arParams(2) As SqlParameter

        Dim parameterClientID As New SqlParameter("@ClientID", SqlDbType.VarChar, (6))
        parameterClientID.Value = ClientID
        arParams(0) = parameterClientID
        Dim parameterContactID As New SqlParameter("@ContactCode", SqlDbType.VarChar, (6))
        parameterContactID.Value = ContactID
        arParams(1) = parameterContactID

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_updateprinted_client", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:UpdateClientPrint", Err.Description)
            Return False
        End Try

        Return True

    End Function
    'Public Function CreateCCEmailsClient(ByVal oSendEmailCol As SendEmailCol, ByVal strCCopyEmail As String)
    '    Dim oWebServices As cWebServices = New cWebServices(mConnString)
    '    Dim oSendEmailDetail As New SendEmailDetail
    '    Dim oEmailCCDetail As EmailCCDetail
    '    Dim oEmailCCCol As New EmailCCCol
    '    Dim strCombinedCCandBody As String, strCombinedCC As String = ""
    '    Dim intCount As Integer = 0, intTotalCount As Integer = 0, i As Integer = 0
    '    Dim strPreviousClientID As String = "", strPreviousDivisionID As String = "", strPreviousProductID As String = ""
    '    Dim strClientID As String = "", strDivisionID As String = "", strProductID As String = ""
    '    'append the cc line in the body
    '    For Each oSendEmailDetail In oSendEmailCol
    '        intTotalCount = intTotalCount + 1
    '        If strPreviousClientID = "" Then
    '            strPreviousClientID = oSendEmailDetail.ClientID
    '            strPreviousDivisionID = oSendEmailDetail.DivisionID
    '            strPreviousProductID = oSendEmailDetail.ProductID
    '        End If

    '        If strPreviousClientID = oSendEmailDetail.ClientID And strPreviousDivisionID = oSendEmailDetail.DivisionID And strPreviousProductID = oSendEmailDetail.ProductID Then
    '            If strCombinedCC = "" Then
    '                strCombinedCC = oSendEmailDetail.ContactEmail
    '            Else
    '                strCombinedCC += ", " & oSendEmailDetail.ContactEmail
    '            End If
    '            strClientID = oSendEmailDetail.ClientID
    '            strDivisionID = oSendEmailDetail.DivisionID
    '            strProductID = oSendEmailDetail.ProductID
    '            intCount = intCount + 1
    '        Else
    '            'Needs to multiple records.
    '            If intCount > 1 Then
    '                strCombinedCCandBody = strCCopyEmail & vbCrLf & strCombinedCC & vbCrLf & vbCrLf & oSendEmailDetail.Body

    '                oEmailCCDetail = New EmailCCDetail
    '                oEmailCCDetail.ClientID = strClientID
    '                oEmailCCDetail.DivisionID = strDivisionID
    '                oEmailCCDetail.ProductID = strProductID
    '                oEmailCCDetail.Body = strCombinedCCandBody
    '                oEmailCCCol.Add(oEmailCCDetail)
    '                'intialize the temp values
    '                strCombinedCC = oSendEmailDetail.ContactEmail
    '                intCount = 1
    '            Else
    '                strCombinedCC = oSendEmailDetail.ContactEmail
    '                intCount = 1
    '            End If

    '        End If

    '        'Update the last record.
    '        If intTotalCount = (oSendEmailCol.Count) Then
    '            'Needs to multiple records.
    '            If intCount > 1 Then
    '                strCombinedCCandBody = strCCopyEmail & vbCrLf & strCombinedCC & vbCrLf & vbCrLf & oSendEmailDetail.Body

    '                oEmailCCDetail = New EmailCCDetail
    '                oEmailCCDetail.ClientID = strClientID
    '                oEmailCCDetail.DivisionID = strDivisionID
    '                oEmailCCDetail.ProductID = strProductID
    '                oEmailCCDetail.Body = strCombinedCCandBody
    '                oEmailCCCol.Add(oEmailCCDetail)
    '            End If
    '        End If
    '        strPreviousClientID = oSendEmailDetail.ClientID
    '        strPreviousDivisionID = oSendEmailDetail.DivisionID
    '        strPreviousProductID = oSendEmailDetail.ProductID
    '    Next

    '    'update the new body field for the multiple records.
    '    For Each oEmailCCDetail In oEmailCCCol
    '        For Each oSendEmailDetail In oSendEmailCol
    '            If oEmailCCDetail.ClientID = oSendEmailDetail.ClientID And oEmailCCDetail.ProductID = oSendEmailDetail.ProductID And oEmailCCDetail.DivisionID = oSendEmailDetail.DivisionID Then
    '                oSendEmailDetail.Body = oEmailCCDetail.Body
    '            End If
    '        Next
    '    Next

    '    'create PDF and send emails with new cc in the body.
    '    For Each oSendEmailDetail In oSendEmailCol
    '        oWebServices.RenderPDF(oSendEmailDetail.FileName, oSendEmailDetail.Report, oSendEmailDetail.ID, oSendEmailDetail.PostPeriod, oSendEmailDetail.Location, oSendEmailDetail.AgedDate, oSendEmailDetail.footer)
    '        oWebServices.SendEmail(oSendEmailDetail.FileName, oSendEmailDetail.ContactEmail, oSendEmailDetail.Subject, oSendEmailDetail.Body)
    '        If oSendEmailDetail.FileName <> "" Then
    '            Kill(oSendEmailDetail.FileName)
    '        End If

    '        UpdateClientEmail(oSendEmailDetail.ClientID, oSendEmailDetail.ContactCode)
    '    Next

    'End Function
    Public Function GetDSfromSQL(ByVal SQL As String)
        Dim ds As DataSet

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.Text, SQL)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetCategories", Err.Description)
        End Try

        Return ds
    End Function
    Public Function GetDSfromSQLDT(ByVal SQL As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime)
        Dim ds As DataSet

        Dim arParams(2) As SqlParameter

        Dim parameterSDate As New SqlParameter("@Startdate", SqlDbType.SmallDateTime)
        parameterSDate.Value = StartDate
        arParams(0) = parameterSDate

        Dim parameterEDate As New SqlParameter("@Enddate", SqlDbType.SmallDateTime)
        parameterEDate.Value = EndDate
        arParams(1) = parameterEDate

        Try
            ds = oSQL.ExecuteDataset(mConnString, CommandType.Text, SQL, arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetCategories", Err.Description)
        End Try

        Return ds
    End Function
    Public Function TrafficScheduleByDay(ByVal Clients As String, ByVal StartingDate As Date, ByVal Days As Integer, ByVal ClosedJobs As Boolean, ByVal ColSort As String, ByVal Weekends As Boolean, ByVal EmpName As Boolean, ByVal TaskOption As Integer,
                                         Optional ByVal offices As String = "", Optional ByVal usercode As String = "", Optional ByVal manager As String = "", Optional ByVal completed As String = "", Optional ByVal AE As String = "", Optional ByVal UserID As String = "") As DataSet
        Dim I As Integer
        Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim arParams(9) As SqlParameter

        Dim parameterClientCodes As New SqlParameter("@ClientCode", SqlDbType.VarChar, 4000)
        parameterClientCodes.Value = Clients
        arParams(0) = parameterClientCodes

        Dim parameterSDate As New SqlParameter("@StartingDate", SqlDbType.DateTime, 12)
        parameterSDate.Value = StartingDate
        arParams(1) = parameterSDate

        Dim parameterEDate As New SqlParameter("@EndingDate", SqlDbType.DateTime, 12)
        parameterEDate.Value = StartingDate.AddDays(Days)
        arParams(2) = parameterEDate

        Dim parameterCD As New SqlParameter("@ClosedJobs", SqlDbType.Char, 1)
        If ClosedJobs = True Then
            parameterCD.Value = "Y"
        Else
            parameterCD.Value = "N"
        End If
        arParams(3) = parameterCD

        Dim parameterColSort As New SqlParameter("@ColSort", SqlDbType.VarChar, 10)
        parameterColSort.Value = ColSort
        arParams(4) = parameterColSort

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4000)
        If offices = "" Then
            parameterOffice.Value = offices
        ElseIf offices.EndsWith(",") Then
            parameterOffice.Value = offices.Substring(0, offices.Length - 1)
        Else
            parameterOffice.Value = offices
        End If
        arParams(5) = parameterOffice

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar)
        parameterManager.Value = manager
        arParams(6) = parameterManager

        Dim parameterCompleted As New SqlParameter("@CompletedIncl", SqlDbType.Char, 1)
        parameterCompleted.Value = completed
        arParams(7) = parameterCompleted

        Dim parameterAEs As New SqlParameter("@AE", SqlDbType.VarChar, 4000)
        parameterAEs.Value = AE
        arParams(8) = parameterAEs

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = usercode
        arParams(9) = parameterUserID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_reports_traffic_schedule_byday", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetReports", Err.Description)
        End Try

        'Create DataSet
        Dim RetDS As DataSet = New DataSet
        Dim ThisTable As DataTable = New DataTable
        Dim ThisDataRow As DataRow
        Dim ThisID As String
        Dim Cols(1) As DataColumn

        ThisTable.Columns.Add("ID", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Manager", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Start Date", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Client Code", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Client Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Division Code", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Division Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Product Code", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Product Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Number", System.Type.GetType("System.Int32"))
        ThisTable.Columns.Add("Job Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Comp Number", System.Type.GetType("System.Int32"))
        ThisTable.Columns.Add("Job Comp Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Client Reference", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Account Executive", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Type", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Type Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Traffic Status", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Traffic Comments", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Phase", System.Type.GetType("System.String"))
        'CTB: 05/26/2006 - QA ID: 3607
        ThisTable.Columns.Add("Client Division Product", System.Type.GetType("System.String"))
        For I = 0 To Days
            If Weekends = True Then
                If StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Saturday And StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Sunday Then
                    ThisTable.Columns.Add(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString, System.Type.GetType("System.String"))
                End If
            Else
                ThisTable.Columns.Add(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString, System.Type.GetType("System.String"))
            End If
        Next
        Cols(0) = ThisTable.Columns("ID")
        ThisTable.PrimaryKey() = Cols

        Do While dr.Read
            ThisID = CStr(dr("JOB_NUMBER")) & CStr(dr("JOB_COMPONENT_NBR"))
            If ThisTable.Rows.Contains(ThisID) = True Then
                ThisDataRow = ThisTable.Rows.Find(ThisID)
                For I = 0 To Days
                    If Weekends = True Then
                        If StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Saturday And StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Sunday Then
                            If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                                ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= " - " & GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                            End If
                        End If
                    Else
                        If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                            ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= " - " & GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                        End If
                    End If
                Next
            Else
                ThisDataRow = ThisTable.NewRow
                ThisDataRow("ID") = CStr(dr("JOB_NUMBER")) & CStr(dr("JOB_COMPONENT_NBR"))
                ThisDataRow("Manager") = DBStr(dr, "Manager")
                ThisDataRow("Job Start Date") = CDate(dr("JOB_REVISED_DATE")).ToShortDateString
                ThisDataRow("Client Code") = DBStr(dr, "CL_CODE")
                ThisDataRow("Client Description") = DBStr(dr, "CL_NAME")
                ThisDataRow("Division Code") = DBStr(dr, "DIV_CODE")
                ThisDataRow("Division Description") = DBStr(dr, "DIV_NAME")
                ThisDataRow("Product Code") = DBStr(dr, "PRD_CODE")
                ThisDataRow("Product Description") = DBStr(dr, "PRD_DESCRIPTION")
                ThisDataRow("Job Number") = CInt(dr("JOB_NUMBER"))
                ThisDataRow("Job Description") = DBStr(dr, ("JOB_DESC"))
                ThisDataRow("Job Comp Number") = CInt(dr("JOB_COMPONENT_NBR"))
                ThisDataRow("Job Comp Description") = DBStr(dr, "JOB_COMP_DESC")
                ThisDataRow("Client Reference") = DBStr(dr, "JOB_CLI_REF")
                ThisDataRow("Account Executive") = DBStr(dr, "AE")
                ThisDataRow("Job Type") = DBStr(dr, "JT_CODE")
                ThisDataRow("Job Type Description") = DBStr(dr, "JT_DESC")
                ThisDataRow("Traffic Status") = DBStr(dr, "TRF_DESC")
                ThisDataRow("Traffic Comments") = DBStr(dr, "TRF_COMMENTS")
                ThisDataRow("Phase") = DBStr(dr, "PHASE_DESC")
                'CTB: 05/26/2006 - QA ID: 3607
                ThisDataRow("Client Division Product") = DBStr(dr, "CLI_DIV_PROD")
                For I = 0 To Days
                    If Weekends = True Then
                        If StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Saturday And StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Sunday Then
                            If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                                ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                            End If
                        End If
                    Else
                        If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                            ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                        End If
                    End If
                Next
                ThisTable.Rows.Add(ThisDataRow)
            End If
        Loop

        dr.Close()

        ThisTable.PrimaryKey = Nothing
        ThisTable.Columns.Remove("ID")

        ds = New DataSet
        ds.Tables.Add(ThisTable)

        Return ds

    End Function
    Public Function TrafficScheduleByDayCP(ByVal Clients As String, ByVal StartingDate As Date, ByVal Days As Integer, ByVal ClosedJobs As Boolean, ByVal ColSort As String, ByVal Weekends As Boolean, ByVal EmpName As Boolean, ByVal TaskOption As Integer, Optional ByVal offices As String = "", Optional ByVal usercode As String = "", Optional ByVal manager As String = "", Optional ByVal completed As String = "", Optional ByVal AE As String = "", Optional ByVal CPID As Integer = 0) As DataSet
        Dim I As Integer
        Dim dr As SqlDataReader
        Dim ds As DataSet
        Dim arParams(9) As SqlParameter

        Dim parameterClientCodes As New SqlParameter("@ClientCode", SqlDbType.VarChar, 4000)
        parameterClientCodes.Value = Clients
        arParams(0) = parameterClientCodes

        Dim parameterSDate As New SqlParameter("@StartingDate", SqlDbType.DateTime, 12)
        parameterSDate.Value = StartingDate
        arParams(1) = parameterSDate

        Dim parameterEDate As New SqlParameter("@EndingDate", SqlDbType.DateTime, 12)
        parameterEDate.Value = StartingDate.AddDays(Days)
        arParams(2) = parameterEDate

        Dim parameterCD As New SqlParameter("@ClosedJobs", SqlDbType.Char, 1)
        If ClosedJobs = True Then
            parameterCD.Value = "Y"
        Else
            parameterCD.Value = "N"
        End If
        arParams(3) = parameterCD

        Dim parameterColSort As New SqlParameter("@ColSort", SqlDbType.VarChar, 10)
        parameterColSort.Value = ColSort
        arParams(4) = parameterColSort

        Dim parameterOffice As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4000)
        If offices = "" Then
            parameterOffice.Value = offices
        ElseIf offices.EndsWith(",") Then
            parameterOffice.Value = offices.Substring(0, offices.Length - 1)
        Else
            parameterOffice.Value = offices
        End If
        arParams(5) = parameterOffice

        Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar)
        parameterManager.Value = manager
        arParams(6) = parameterManager

        Dim parameterCompleted As New SqlParameter("@CompletedIncl", SqlDbType.Char, 1)
        parameterCompleted.Value = completed
        arParams(7) = parameterCompleted

        Dim parameterAEs As New SqlParameter("@AE", SqlDbType.VarChar, 4000)
        parameterAEs.Value = AE
        arParams(8) = parameterAEs

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(9) = parameterCPID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_reports_traffic_schedule_byday", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetReports", Err.Description)
        End Try

        'Create DataSet
        Dim RetDS As DataSet = New DataSet
        Dim ThisTable As DataTable = New DataTable
        Dim ThisDataRow As DataRow
        Dim ThisID As String
        Dim Cols(1) As DataColumn

        ThisTable.Columns.Add("ID", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Start Date", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Client Code", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Client Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Division Code", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Division Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Product Code", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Product Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Number", System.Type.GetType("System.Int32"))
        ThisTable.Columns.Add("Job Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Comp Number", System.Type.GetType("System.Int32"))
        ThisTable.Columns.Add("Job Comp Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Client Reference", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Account Executive", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Type", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Job Type Description", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Traffic Status", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Traffic Comments", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Phase", System.Type.GetType("System.String"))
        'CTB: 05/26/2006 - QA ID: 3607
        ThisTable.Columns.Add("Client Division Product", System.Type.GetType("System.String"))
        For I = 0 To Days
            If Weekends = True Then
                If StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Saturday And StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Sunday Then
                    ThisTable.Columns.Add(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString, System.Type.GetType("System.String"))
                End If
            Else
                ThisTable.Columns.Add(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString, System.Type.GetType("System.String"))
            End If
        Next
        Cols(0) = ThisTable.Columns("ID")
        ThisTable.PrimaryKey() = Cols

        Do While dr.Read
            ThisID = CStr(dr("JOB_NUMBER")) & CStr(dr("JOB_COMPONENT_NBR"))
            If ThisTable.Rows.Contains(ThisID) = True Then
                ThisDataRow = ThisTable.Rows.Find(ThisID)
                For I = 0 To Days
                    If Weekends = True Then
                        If StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Saturday And StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Sunday Then
                            If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                                ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= " - " & GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                            End If
                        End If
                    Else
                        If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                            ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= " - " & GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                        End If
                    End If
                Next
            Else
                ThisDataRow = ThisTable.NewRow
                ThisDataRow("ID") = CStr(dr("JOB_NUMBER")) & CStr(dr("JOB_COMPONENT_NBR"))
                ThisDataRow("Job Start Date") = CDate(dr("JOB_REVISED_DATE")).ToShortDateString
                ThisDataRow("Client Code") = DBStr(dr, "CL_CODE")
                ThisDataRow("Client Description") = DBStr(dr, "CL_NAME")
                ThisDataRow("Division Code") = DBStr(dr, "DIV_CODE")
                ThisDataRow("Division Description") = DBStr(dr, "DIV_NAME")
                ThisDataRow("Product Code") = DBStr(dr, "PRD_CODE")
                ThisDataRow("Product Description") = DBStr(dr, "PRD_DESCRIPTION")
                ThisDataRow("Job Number") = CInt(dr("JOB_NUMBER"))
                ThisDataRow("Job Description") = DBStr(dr, ("JOB_DESC"))
                ThisDataRow("Job Comp Number") = CInt(dr("JOB_COMPONENT_NBR"))
                ThisDataRow("Job Comp Description") = DBStr(dr, "JOB_COMP_DESC")
                ThisDataRow("Client Reference") = DBStr(dr, "JOB_CLI_REF")
                ThisDataRow("Account Executive") = DBStr(dr, "AE")
                ThisDataRow("Job Type") = DBStr(dr, "JT_CODE")
                ThisDataRow("Job Type Description") = DBStr(dr, "JT_DESC")
                ThisDataRow("Traffic Status") = DBStr(dr, "TRF_DESC")
                ThisDataRow("Traffic Comments") = DBStr(dr, "TRF_COMMENTS")
                ThisDataRow("Phase") = DBStr(dr, "PHASE_DESC")
                'CTB: 05/26/2006 - QA ID: 3607
                ThisDataRow("Client Division Product") = DBStr(dr, "CLI_DIV_PROD")
                For I = 0 To Days
                    If Weekends = True Then
                        If StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Saturday And StartingDate.AddDays(I).DayOfWeek <> DayOfWeek.Sunday Then
                            If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                                ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                            End If
                        End If
                    Else
                        If StartingDate.AddDays(I) = CDate(dr("JOB_REVISED_DATE")) Then
                            ThisDataRow(StartingDate.AddDays(I).DayOfWeek.ToString.ToUpper.Substring(0, 3) & " - " & StartingDate.AddDays(I).ToShortDateString) &= GetEmpName(dr, EmpName, usercode) & ":" & GetTaskOption(dr, TaskOption)
                        End If
                    End If
                Next
                ThisTable.Rows.Add(ThisDataRow)
            End If
        Loop

        dr.Close()

        ThisTable.PrimaryKey = Nothing
        ThisTable.Columns.Remove("ID")

        ds = New DataSet
        ds.Tables.Add(ThisTable)

        Return ds

    End Function
    Private Function GetEmpName(ByRef dr As SqlDataReader, ByVal EmpName As Boolean, Optional ByVal user As String = "") As String
        If EmpName = True Then
            Dim test2 As String = DBStr(dr, "EmpName")
            If DBStr(dr, "EmpName") = "" Then
                Dim oReports As cReports = New cReports(Me.mConnString)
                Dim strEmps As String = oReports.GetEmpListStringName(CInt(DBStr(dr, "JOB_NUMBER")), CInt(DBStr(dr, "JOB_COMPONENT_NBR")), CInt(DBStr(dr, "SEQ_NBR")))
                Return strEmps
            Else
                Return DBStr(dr, "EmpName")
            End If

        Else
            Dim test As String = DBStr(dr, "EMP_CODE")
            If DBStr(dr, "EMP_CODE").Trim = "..." Then
                Dim oTrafficSchedule As cSchedule = New cSchedule(Me.mConnString, user)
                Dim strEmps As String = oTrafficSchedule.GetTaskEmpListString(CInt(DBStr(dr, "JOB_NUMBER")), CInt(DBStr(dr, "JOB_COMPONENT_NBR")), CInt(DBStr(dr, "SEQ_NBR")))
                Return strEmps
            Else
                Return DBStr(dr, "EMP_CODE")
            End If
        End If
    End Function
    Public Function GetEmpListStringName(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer) As String
        Try
            Dim str As String
            Dim arParams(3) As SqlParameter

            Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramTask_JobNum.Value = Task_JobNum
            arParams(0) = paramTask_JobNum

            Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            paramTask_JobCompNum.Value = Task_JobCompNum
            arParams(1) = paramTask_JobCompNum

            Dim paramTask_SeqNum As New SqlParameter("@SEQ", SqlDbType.SmallInt)
            paramTask_SeqNum.Value = Task_SeqNum
            arParams(2) = paramTask_SeqNum

            Dim dr As SqlDataReader
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_reports_traffic_schedule_GetEmpNames", arParams)
            If dr.HasRows Then
                Do While dr.Read
                    Try
                        str &= dr("EmpName").ToString() & ", "
                    Catch ex As Exception

                    End Try
                Loop
                If str <> "" Then
                    Return MiscFN.RemoveTrailingDelimiter(str, ",")
                End If
            Else
                Return ""
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function GetTaskOption(ByRef dr As SqlDataReader, ByVal TaskOption As Integer) As String
        Select Case TaskOption
            Case 1
                Return DBStr(dr, "FNC_CODE1")
            Case 2
                Return DBStr(dr, "FNC_CODE2")
            Case 3
                Return DBStr(dr, "TASK_DESCRIPTION")
        End Select
    End Function
    Public Function DBStr(ByRef dr As SqlDataReader, ByVal Name As String) As String
        Try
            If IsDBNull(dr(Name)) = True Then
                Return ""
            Else
                Return CStr(dr(Name))
            End If

        Catch ex As Exception
            Return ""

        End Try

    End Function
    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

    Public Function GetOpenJobsDS(ByVal strUserID As String, ByVal strClientCode As String, Optional ByVal offices As String = "", Optional ByVal start_date As String = "01/01/1950", Optional ByVal end_date As String = "01/01/2050", Optional ByVal isSchedIncluded As Boolean = False, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As DataTable
        Dim dt As DataTable
        Dim arParams(8) As SqlParameter

        If strUserID = "" Then strUserID = "%"
        If strClientCode = "" Then strClientCode = "%"


        Try
            Dim parameterClient As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterClient.Value = strUserID
            arParams(0) = parameterClient

            Dim parameterDivision As New SqlParameter("@ClientCode", SqlDbType.VarChar, 4000)
            If strClientCode = "" Then
                parameterDivision.Value = DBNull.Value
            ElseIf strClientCode.EndsWith(",") Then
                parameterDivision.Value = strClientCode.Substring(0, strClientCode.Length - 1)
            End If
            'parameterDivision.Value = strClientCode
            arParams(1) = parameterDivision

            Dim parameterOffice As New SqlParameter("@OfficeCodes", SqlDbType.VarChar, 4000)
            If offices = "" Then
                parameterOffice.Value = DBNull.Value
            ElseIf offices.EndsWith(",") Then
                parameterOffice.Value = offices.Substring(0, offices.Length - 1)
            End If
            arParams(2) = parameterOffice

            Dim parameterSDate As New SqlParameter("@start_date", SqlDbType.SmallDateTime)
            parameterSDate.Value = start_date
            arParams(3) = parameterSDate

            Dim parameterEDate As New SqlParameter("@end_date", SqlDbType.SmallDateTime)
            parameterEDate.Value = end_date
            arParams(4) = parameterEDate

            Dim parameterSchIncl As New SqlParameter("@sch_included", SqlDbType.Bit, 1)
            parameterSchIncl.Value = isSchedIncluded
            arParams(5) = parameterSchIncl

            'If CP = True Then
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

            'End If

            'dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_OpenJobsReport", "test", arParams)
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_OpenJobsRpt", "test", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetOpenJobsDS", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetARClientStatement(ByVal strID As String, ByVal strPostPeriod As String, ByVal strLocation As String, ByVal strAgedDate As String, ByVal strFooter As String, ByVal num As String, Optional ByVal OfficeCodes As String = "", Optional ByVal AgingDateType As Integer = 1) As DataTable
        Dim dt As DataTable
        Dim arParams(7) As SqlParameter

        Try
            Dim parameterID As New SqlParameter("@ID", SqlDbType.VarChar, 4000)
            parameterID.Value = strID
            arParams(0) = parameterID

            Dim parameterPP As New SqlParameter("@PostPeriod", SqlDbType.VarChar, 10)
            parameterPP.Value = strPostPeriod
            arParams(1) = parameterPP

            Dim parameterLoc As New SqlParameter("@Location", SqlDbType.VarChar, 100)
            parameterLoc.Value = strLocation
            arParams(2) = parameterLoc

            Dim parameterAD As New SqlParameter("@AgedDate", SqlDbType.SmallDateTime)
            parameterAD.Value = strAgedDate
            arParams(3) = parameterAD

            Dim parameterFooter As New SqlParameter("@Footer", SqlDbType.VarChar, 200)
            parameterFooter.Value = strFooter
            arParams(4) = parameterFooter

            Dim parameterOfficeCodes As New SqlParameter("@OFFICE_CODES", SqlDbType.VarChar, 8000)
            parameterOfficeCodes.Value = OfficeCodes
            arParams(5) = parameterOfficeCodes

            Dim parameterAgingDateType As New SqlParameter("@AgingDateType", SqlDbType.SmallInt)
            parameterAgingDateType.Value = AgingDateType
            arParams(6) = parameterAgingDateType

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_client_00" & num, "test" & Now.Millisecond.ToString(), arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetARClientDS", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetARProductStatement(ByVal strID As String, ByVal strPostPeriod As String, ByVal strLocation As String, ByVal strAgedDate As String, ByVal strFooter As String, ByVal num As String, Optional ByVal OfficeCodes As String = "", Optional ByVal AgingDateType As Integer = 1) As DataTable
        Dim dt As DataTable
        Dim arParams(7) As SqlParameter

        Try
            Dim parameterID As New SqlParameter("@ID", SqlDbType.VarChar, 4000)
            parameterID.Value = strID
            arParams(0) = parameterID

            Dim parameterPP As New SqlParameter("@PostPeriod", SqlDbType.VarChar, 10)
            parameterPP.Value = strPostPeriod
            arParams(1) = parameterPP

            Dim parameterLoc As New SqlParameter("@Location", SqlDbType.VarChar, 100)
            parameterLoc.Value = strLocation
            arParams(2) = parameterLoc

            Dim parameterAD As New SqlParameter("@AgedDate", SqlDbType.SmallDateTime)
            parameterAD.Value = strAgedDate
            arParams(3) = parameterAD

            Dim parameterFooter As New SqlParameter("@Footer", SqlDbType.VarChar, 200)
            parameterFooter.Value = strFooter
            arParams(4) = parameterFooter

            Dim parameterOfficeCodes As New SqlParameter("@OFFICE_CODES", SqlDbType.VarChar, 8000)
            parameterOfficeCodes.Value = OfficeCodes
            arParams(5) = parameterOfficeCodes

            Dim parameterAgingDateType As New SqlParameter("@AgingDateType", SqlDbType.SmallInt)
            parameterAgingDateType.Value = AgingDateType
            arParams(6) = parameterAgingDateType

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_ar_statements_product_00" & num, "test" & Now.Millisecond.ToString(), arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetARProductDS", Err.Description)
        End Try

        Return dt
    End Function


    Public Function GetNextDue() As DataTable
        Dim dt As DataTable
        Try
            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_next_due", "nextdue")
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetNextDue", Err.Description)
        End Try

        Return dt

    End Function
    Public Function GetSumRepByClient(ByVal strUserId As String, ByVal sdate As String, ByVal edate As String, ByVal includeCS As Boolean, ByVal AEs As String, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As DataTable
        Dim dt As DataTable
        Dim arParams(7) As SqlParameter

        Try
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = strUserId
            arParams(0) = parameterUserID

            Dim parameterStartDate As New SqlParameter("@Start_Date", SqlDbType.SmallDateTime)
            parameterStartDate.Value = sdate
            arParams(1) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@End_Date", SqlDbType.SmallDateTime)
            parameterEndDate.Value = edate
            arParams(2) = parameterEndDate

            Dim parameterIncludeCS As New SqlParameter("@IncludeCS", SqlDbType.Char)
            If includeCS = True Then
                parameterIncludeCS.Value = "1"
            Else
                parameterIncludeCS.Value = "0"
            End If
            arParams(3) = parameterIncludeCS

            Dim parameterAEs As New SqlParameter("@AEs", SqlDbType.VarChar, 4000)
            parameterAEs.Value = AEs
            arParams(4) = parameterAEs

            'If CP = True Then
            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(5) = parameterCP

            Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCPID.Value = CPID
            arParams(6) = parameterCPID


            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_sum_rep_by_client", "test", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetSumRepByClient", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetCampaignSummarybyJobBudgetVariance(ByVal CmpCode As Integer, ByVal StartPeriod As String, ByVal EndPeriod As String, ByVal StartDate As String, ByVal EndDate As String) As DataTable
        Dim dt As DataTable
        Dim arParams(4) As SqlParameter

        Try
            Dim parameterCmpCode As New SqlParameter("@CmpCode", SqlDbType.Int)
            parameterCmpCode.Value = CmpCode
            arParams(0) = parameterCmpCode

            Dim parameterStartPeriod As New SqlParameter("@StartPeriod", SqlDbType.VarChar, 6)
            parameterStartPeriod.Value = StartPeriod
            arParams(1) = parameterStartPeriod

            Dim parameterEndPeriod As New SqlParameter("@EndPeriod", SqlDbType.VarChar, 6)
            parameterEndPeriod.Value = EndPeriod
            arParams(2) = parameterEndPeriod

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.VarChar, 10)
            parameterStartDate.Value = StartDate
            arParams(3) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.VarChar, 10)
            parameterEndDate.Value = EndDate
            arParams(4) = parameterEndDate

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_campaign001", "Cmp", arParams)
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetCampaignSummarybyJobBudgetVariance", Err.Description)
        End Try

        Return dt

    End Function

    Public Function GetSumRepByClientSalesClass(ByVal strUserId As String, ByVal sdate As String, ByVal edate As String, ByVal includeCS As Boolean, ByVal AEs As String, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As DataTable
        Dim dt As DataTable
        Dim arParams(7) As SqlParameter

        Try
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = strUserId
            arParams(0) = parameterUserID

            Dim parameterStartDate As New SqlParameter("@Start_Date", SqlDbType.SmallDateTime)
            parameterStartDate.Value = sdate
            arParams(1) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@End_Date", SqlDbType.SmallDateTime)
            parameterEndDate.Value = edate
            arParams(2) = parameterEndDate

            Dim parameterIncludeCS As New SqlParameter("@IncludeCS", SqlDbType.Char)
            If includeCS = True Then
                parameterIncludeCS.Value = "1"
            Else
                parameterIncludeCS.Value = "0"
            End If
            arParams(3) = parameterIncludeCS

            Dim parameterAEs As New SqlParameter("@AEs", SqlDbType.VarChar, 4000)
            parameterAEs.Value = AEs
            arParams(4) = parameterAEs

            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(5) = parameterCP

            Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCPID.Value = CPID
            arParams(6) = parameterCPID


            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_sum_rep_by_client_sc_jdd", "test", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetSumRepByClient", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetTaskData(ByVal strUserID As String, ByVal strEmpCode As String, ByVal strClientCode As String, ByVal strDivCode As String, ByVal strProdCode As String, ByVal strJobNumber As String, ByVal strSortOrder As String, ByVal strStartDate As String, ByVal strEndDate As String, ByVal strCompleted As String, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As DataTable
        Dim dt As DataTable
        Dim arParams(12) As SqlParameter

        Try
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 20)
            parameterUserID.Value = strUserID
            arParams(0) = parameterUserID

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 100)
            parameterEmpCode.Value = strEmpCode
            arParams(1) = parameterEmpCode

            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 100)
            parameterClientCode.Value = strClientCode
            arParams(2) = parameterClientCode

            Dim parameterDivCode As New SqlParameter("@DivCode", SqlDbType.VarChar, 100)
            parameterDivCode.Value = strDivCode
            arParams(3) = parameterDivCode

            Dim parameterProdCode As New SqlParameter("@ProdCode", SqlDbType.VarChar, 100)
            parameterProdCode.Value = strProdCode
            arParams(4) = parameterProdCode

            Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.VarChar, 20)
            parameterJobNumber.Value = strJobNumber
            arParams(5) = parameterJobNumber

            Dim parameterSortOrder As New SqlParameter("@SortOrder", SqlDbType.VarChar, 100)
            parameterSortOrder.Value = strSortOrder
            arParams(6) = parameterSortOrder

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            parameterStartDate.Value = strStartDate
            arParams(7) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            parameterEndDate.Value = strEndDate
            arParams(8) = parameterEndDate

            Dim parameterCompleted As New SqlParameter("@Completed", SqlDbType.SmallDateTime)
            parameterCompleted.Value = strCompleted
            arParams(9) = parameterCompleted

            Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
            If CP = True Then
                parameterCP.Value = 1
            Else
                parameterCP.Value = 0
            End If
            arParams(10) = parameterCP

            Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
            parameterCPID.Value = CPID
            arParams(11) = parameterCPID

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_rpt_TaskList", "test", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetTaskDS", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetMyTaskData(ByVal strUserID As String, ByVal strEmpCodes As String, ByVal strClientCodes As String, ByVal strSortOrder As String, ByVal strStartDate As String, ByVal strEndDate As String, ByVal strOfficeCodes As String, ByVal strCompleted As String, ByVal EmpOrRole As Integer, ByVal Manager As String, ByVal strAECodes As String) As DataTable
        Dim dt As DataTable
        Dim arParams(11) As SqlParameter

        Try
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 20)
            parameterUserID.Value = strUserID
            arParams(0) = parameterUserID

            Dim parameterEmpCode As SqlParameter
            If EmpOrRole = 1 Then
                parameterEmpCode = New SqlParameter("@EmpCodes", SqlDbType.VarChar, 4000)
                parameterEmpCode.Value = strEmpCodes
                arParams(1) = parameterEmpCode
            Else
                parameterEmpCode = New SqlParameter("@RlCodes", SqlDbType.VarChar, 4000)
                parameterEmpCode.Value = strEmpCodes
                arParams(1) = parameterEmpCode
            End If
            Dim parameterClientCode As New SqlParameter("@ClientCodes", SqlDbType.VarChar, 4000)
            parameterClientCode.Value = strClientCodes
            arParams(2) = parameterClientCode

            Dim parameterOfficeCode As New SqlParameter("@OfficeCodes", SqlDbType.VarChar, 4000)
            parameterOfficeCode.Value = strOfficeCodes
            arParams(3) = parameterOfficeCode

            Dim parameterSortOrder As New SqlParameter("@SortOrder", SqlDbType.VarChar, 100)
            parameterSortOrder.Value = strSortOrder
            arParams(4) = parameterSortOrder

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            parameterStartDate.Value = strStartDate
            arParams(5) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            parameterEndDate.Value = strEndDate
            arParams(6) = parameterEndDate

            Dim parameterCompleted As New SqlParameter("@Completed", SqlDbType.SmallDateTime)
            parameterCompleted.Value = strCompleted
            arParams(7) = parameterCompleted

            Dim parameterManager As New SqlParameter("@Manager", SqlDbType.VarChar, 6)
            parameterManager.Value = Manager
            arParams(8) = parameterManager

            Dim parameterAE As New SqlParameter("@AECodes", SqlDbType.VarChar, 4000)
            parameterAE.Value = strAECodes
            arParams(9) = parameterAE

            If EmpOrRole = 1 Then
                dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_rpt_MyTaskListByEmps", "test", arParams)
            Else
                dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_rpt_MyTaskListByRoles", "test", arParams)
            End If
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetTaskDS", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetEmpNPTimeData(ByVal strUserID As String, ByVal sort As String, ByVal office As String, ByVal super As String, ByVal emp As String, ByVal dept As String, ByVal StartDate As String, ByVal EndDate As String, ByVal inclTermEmp As String, ByVal ByType As Integer, ByVal excludefreelance As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(10) As SqlParameter

        Try

            Dim parameterSort As New SqlParameter("@sort", SqlDbType.VarChar, 1)
            parameterSort.Value = sort
            arParams(0) = parameterSort

            Dim parameterUserID As New SqlParameter("@user_id", SqlDbType.VarChar, 100)
            parameterUserID.Value = strUserID
            arParams(1) = parameterUserID

            Dim parameterOffice As New SqlParameter("@office", SqlDbType.VarChar, 100)
            parameterOffice.Value = office
            arParams(2) = parameterOffice

            Dim parameterSuper As New SqlParameter("@super", SqlDbType.VarChar, 100)
            parameterSuper.Value = super
            arParams(3) = parameterSuper

            Dim parameterEmpCodes As New SqlParameter("@emp_codes", SqlDbType.VarChar, 100)
            parameterEmpCodes.Value = emp
            arParams(4) = parameterEmpCodes

            Dim parameterDepts As New SqlParameter("@depts", SqlDbType.VarChar, 100)
            parameterDepts.Value = dept
            arParams(5) = parameterDepts

            Dim parameterStartDate As New SqlParameter("@start_date", SqlDbType.VarChar, 100)
            parameterStartDate.Value = StartDate
            arParams(6) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@end_date", SqlDbType.VarChar, 100)
            parameterEndDate.Value = EndDate
            arParams(7) = parameterEndDate

            Dim parameterEmpTerm As New SqlParameter("@inclTermEmp", SqlDbType.VarChar, 1)
            parameterEmpTerm.Value = inclTermEmp
            arParams(8) = parameterEmpTerm

            Dim parameterByType As New SqlParameter("@by_type", SqlDbType.SmallInt)
            parameterByType.Value = ByType
            arParams(9) = parameterByType

            Dim parameterExcludeFreelance As New SqlParameter("@exclude_freelance", SqlDbType.SmallInt)
            parameterExcludeFreelance.Value = excludefreelance
            arParams(10) = parameterExcludeFreelance

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_get_empnptime_rpt", "dtEmpNPTime", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetTaskDS", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetJobTemplateDS(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataTable
        Try
            Dim MyJobTemplate As Job_Template = New Job_Template(mConnString)
            Return MyJobTemplate.GetJobTemplateDetails(JobNum, JobCompNum).Tables(0)

            'Dim arParams(2) As SqlParameter
            'Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            'paramJobNumber.Value = JobNum
            'arParams(0) = paramJobNumber

            'Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            'paramJobCompNumber.Value = JobCompNum
            'arParams(1) = paramJobCompNumber

            'return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Job_Template_GetTemplate_ByJobAndComp", "dtJobTemplate", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobTemplateDS", Err.Description)
        End Try
    End Function

    Public Function GetJobTrafficAssignments(ByVal JobNum As Integer, ByVal JobCompNum As Integer) As DataTable
        Try
            Dim arParams(2) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_job_GetTrafficAssignments", "dtJobAssignments", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobTrafficAssignments", Err.Description)
        End Try
    End Function

    Public Function GetJobTrafficSchedule(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal EmpCode As String) As DataTable
        Try
            Dim arParams(6) As SqlParameter
            Dim paramJobNumber As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNumber.Value = JobNum
            arParams(0) = paramJobNumber

            Dim paramJobCompNumber As New SqlParameter("@JobCompNum", SqlDbType.Int)
            paramJobCompNumber.Value = JobCompNum
            arParams(1) = paramJobCompNumber

            Dim paramEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
            paramEmpCode.Value = EmpCode
            arParams(2) = paramEmpCode

            'Dim paramDueDateOnly As New SqlParameter("@DueDateOnly", SqlDbType.Bit)
            'paramDueDateOnly.Value = JobNum
            'arParams(3) = paramDueDateOnly

            'Dim paramMilestoneOnly As New SqlParameter("@MilestoneOnly", SqlDbType.Bit)
            'paramMilestoneOnly.Value = JobCompNum
            'arParams(4) = paramMilestoneOnly

            'Dim paramEmployeeAssigned As New SqlParameter("@EmployeeAssigned", SqlDbType.Bit)
            'paramEmployeeAssigned.Value = EmpCode
            'arParams(5) = paramEmployeeAssigned

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_job_GetTrafficSchedule", "dtJobSchedule", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobTrafficSchedule", Err.Description)
        End Try
    End Function

    Public Function GetAgencyInfoJobTemplate(ByVal location As String) As DataTable
        Try
            Dim arParams(1) As SqlParameter
            Dim paramLocation As New SqlParameter("@Location", SqlDbType.VarChar)
            paramLocation.Value = location
            arParams(0) = paramLocation

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_job_GetAgencyInfo", "dtJobSchedule", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobAgencyInfo", Err.Description)
        End Try
    End Function


    Public Function GetAgencyHeaderStr(ByVal location As String) As String
        Try
            Dim str As String = ""
            Dim cityStZip As String = ""
            Dim arParams(1) As SqlParameter
            Dim paramLocation As New SqlParameter("@Location", SqlDbType.VarChar)
            Dim dtAgency As DataTable

            paramLocation.Value = location
            arParams(0) = paramLocation

            dtAgency = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_job_GetAgencyInfo", "dtTemp", arParams)

            If dtAgency.Rows.Count > 0 And dtAgency.Rows(0)("PRT_HDR").ToString() = "1" Then

                If dtAgency.Rows(0)("PRT_ADDR1").ToString() = "1" And dtAgency.Rows(0)("ADDRESS1").ToString() <> "" Then
                    str = dtAgency.Rows(0)("ADDRESS1").ToString
                End If

                If dtAgency.Rows(0)("PRT_ADDR2").ToString() = "1" And dtAgency.Rows(0)("ADDRESS2").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("ADDRESS2").ToString
                End If

                If dtAgency.Rows(0)("PRT_CITY").ToString() = "1" And dtAgency.Rows(0)("CITY").ToString() <> "" Then
                    cityStZip = dtAgency.Rows(0)("CITY").ToString() & "  "
                End If
                If dtAgency.Rows(0)("PRT_STATE").ToString() = "1" And dtAgency.Rows(0)("STATE").ToString() <> "" Then
                    cityStZip = cityStZip & dtAgency.Rows(0)("STATE").ToString() & "  "
                End If
                If dtAgency.Rows(0)("PRT_ZIP").ToString() = "1" And dtAgency.Rows(0)("ZIP").ToString() <> "" Then
                    cityStZip = cityStZip & dtAgency.Rows(0)("ZIP").ToString
                End If
                If cityStZip > "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & cityStZip
                End If

                If dtAgency.Rows(0)("PRT_PHONE").ToString() = "1" And dtAgency.Rows(0)("PHONE").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("PHONE").ToString
                End If
                If dtAgency.Rows(0)("PRT_FAX").ToString() = "1" And dtAgency.Rows(0)("FAX").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("FAX").ToString() & " Fax "
                End If
                If dtAgency.Rows(0)("PRT_EMAIL").ToString() = "1" And dtAgency.Rows(0)("EMAIL").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("EMAIL").ToString
                End If

            End If

            Return str

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetAgencyHeader", Err.Description)
        End Try
    End Function

    Public Function GetAgencyFooterStr(ByVal location As String) As String
        Try
            Dim str As String = ""
            Dim cityStZip As String = ""
            Dim arParams(1) As SqlParameter
            Dim paramLocation As New SqlParameter("@Location", SqlDbType.VarChar)
            Dim dtAgency As DataTable

            paramLocation.Value = location
            arParams(0) = paramLocation

            dtAgency = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_job_GetAgencyInfo", "dtTemp", arParams)

            If dtAgency.Rows.Count > 0 And dtAgency.Rows(0)("PRT_FOOTER").ToString() = "1" Then

                If dtAgency.Rows(0)("PRT_ADDR1_FTR").ToString() = "1" And dtAgency.Rows(0)("ADDRESS1").ToString() <> "" Then
                    str = dtAgency.Rows(0)("ADDRESS1").ToString
                End If

                If dtAgency.Rows(0)("PRT_ADDR2_FTR").ToString() = "1" And dtAgency.Rows(0)("ADDRESS2").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("ADDRESS2").ToString
                End If

                If dtAgency.Rows(0)("PRT_CITY_FTR").ToString() = "1" And dtAgency.Rows(0)("CITY").ToString() <> "" Then
                    cityStZip = dtAgency.Rows(0)("CITY").ToString() & "  "
                End If
                If dtAgency.Rows(0)("PRT_STATE_FTR").ToString() = "1" And dtAgency.Rows(0)("STATE").ToString() <> "" Then
                    cityStZip = cityStZip & dtAgency.Rows(0)("STATE").ToString() & "  "
                End If
                If dtAgency.Rows(0)("PRT_ZIP_FTR").ToString() = "1" And dtAgency.Rows(0)("ZIP").ToString() <> "" Then
                    cityStZip = cityStZip & dtAgency.Rows(0)("ZIP").ToString
                End If
                If cityStZip > "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & cityStZip
                End If

                If dtAgency.Rows(0)("PRT_PHONE_FTR").ToString() = "1" And dtAgency.Rows(0)("PHONE").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("PHONE").ToString
                End If
                If dtAgency.Rows(0)("PRT_FAX_FTR").ToString() = "1" And dtAgency.Rows(0)("FAX").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("FAX").ToString() & " Fax "
                End If
                If dtAgency.Rows(0)("PRT_EMAIL_FTR").ToString() = "1" And dtAgency.Rows(0)("EMAIL").ToString() <> "" Then
                    If str > "" Then
                        str = str & " • "
                    End If
                    str = str & dtAgency.Rows(0)("EMAIL").ToString
                End If

            End If

            Return str

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetAgencyFooter", Err.Description)
        End Try
    End Function


    Public Function GetJobOrderFormSettings(ByVal userid As String) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = userid
            arParams(0) = paramUserID

            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetJobOrderFormSettings", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobOrderFormSettings", Err.Description)
        End Try
    End Function

    Public Function SaveJobOrderFormSettings(ByVal userid As String, _
                                             ByVal locationid As String, _
                                             ByVal reportTitlePlacement As Integer, _
                                             ByVal jobOrderForm As Boolean, _
                                             ByVal omitEmptyFields As Boolean, _
                                             ByVal trafficAssignments As Boolean, _
                                             ByVal sectionTitleTA As String, _
                                             ByVal trafficSchedule As Boolean, _
                                             ByVal sectionTitleTS As String, _
                                             ByVal dueDateOnly As Boolean, _
                                             ByVal milestonesOnly As Boolean, _
                                             ByVal milestonesTitle As String, _
                                             ByVal employeeAssignments As Boolean, _
                                             ByVal creativeBrief As Boolean, _
                                             ByVal approvedByCB As Boolean, _
                                             ByVal reportTitleCB As String, _
                                             ByVal jobSpecs As Boolean, _
                                             ByVal approvedByJS As Boolean, _
                                             ByVal reportTitleJS As String, _
                                             ByVal schedComments As Boolean, _
                                             ByVal vendorSpecs As Boolean, _
                                             ByVal mediaSpecs As Boolean, _
                                             ByVal jobVersions As Boolean, _
                                             ByVal omitEmptyFieldsCB As Boolean, _
                                             ByVal omitEmptyFieldsJV As Boolean, _
                                             ByVal omitEmptyFieldsJS As Boolean) As Boolean
        Try
            Dim arParams(25) As SqlParameter

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = userid
            arParams(0) = paramUserID

            Dim paramJobOrderForm As New SqlParameter("@JobOrderForm", SqlDbType.SmallInt)
            If jobOrderForm = True Then
                paramJobOrderForm.Value = 1
            Else
                paramJobOrderForm.Value = 0
            End If
            arParams(1) = paramJobOrderForm

            Dim paramOmitEmptyFields As New SqlParameter("@OmitEmptyFields", SqlDbType.SmallInt)
            If omitEmptyFields = True Then
                paramOmitEmptyFields.Value = 1
            Else
                paramOmitEmptyFields.Value = 0
            End If
            arParams(2) = paramOmitEmptyFields

            Dim paramTrafficAssignments As New SqlParameter("@TrafficAssignments", SqlDbType.SmallInt)
            If trafficAssignments = True Then
                paramTrafficAssignments.Value = 1
            Else
                paramTrafficAssignments.Value = 0
            End If
            arParams(3) = paramTrafficAssignments

            Dim paramTitleTA As New SqlParameter("@TitleTA", SqlDbType.VarChar)
            paramTitleTA.Value = sectionTitleTA
            arParams(4) = paramTitleTA

            Dim paramTrafficSchedule As New SqlParameter("@TrafficSchedule", SqlDbType.SmallInt)
            If trafficSchedule = True Then
                paramTrafficSchedule.Value = 1
            Else
                paramTrafficSchedule.Value = 0
            End If
            arParams(5) = paramTrafficSchedule

            Dim paramTitleTS As New SqlParameter("@TitleTS", SqlDbType.VarChar)
            paramTitleTS.Value = sectionTitleTS
            arParams(6) = paramTitleTS

            Dim paramDueDateOnly As New SqlParameter("@DueDateOnly", SqlDbType.SmallInt)
            If dueDateOnly = True Then
                paramDueDateOnly.Value = 1
            Else
                paramDueDateOnly.Value = 0
            End If
            arParams(7) = paramDueDateOnly

            Dim paramMilestonesOnly As New SqlParameter("@MilestonesOnly", SqlDbType.SmallInt)
            If milestonesOnly = True Then
                paramMilestonesOnly.Value = 1
            Else
                paramMilestonesOnly.Value = 0
            End If
            arParams(8) = paramMilestonesOnly

            Dim paramMilestoneTitle As New SqlParameter("@MilestoneTitle", SqlDbType.VarChar)
            paramMilestoneTitle.Value = milestonesTitle
            arParams(9) = paramMilestoneTitle

            Dim paramEmployAssignments As New SqlParameter("@EmployAssignments", SqlDbType.SmallInt)
            If employeeAssignments = True Then
                paramEmployAssignments.Value = 1
            Else
                paramEmployAssignments.Value = 0
            End If
            arParams(10) = paramEmployAssignments

            Dim paramLocationID As New SqlParameter("@LocationID", SqlDbType.VarChar)
            paramLocationID.Value = locationid
            arParams(11) = paramLocationID

            Dim paramReportPlacement As New SqlParameter("@ReportPlacement", SqlDbType.VarChar)
            paramReportPlacement.Value = reportTitlePlacement
            arParams(12) = paramReportPlacement

            Dim paramCreativeBrief As New SqlParameter("@CreativeBrief", SqlDbType.SmallInt)
            paramCreativeBrief.Value = 0
            arParams(13) = paramCreativeBrief

            Dim paramApprovedByCB As New SqlParameter("@ApprovedByCB", SqlDbType.SmallInt)
            paramApprovedByCB.Value = 0
            arParams(14) = paramApprovedByCB

            Dim paramTitleCB As New SqlParameter("@TitleCB", SqlDbType.VarChar)
            paramTitleCB.Value = ""
            arParams(15) = paramTitleCB

            Dim paramJobSpecs As New SqlParameter("@JobSpecs", SqlDbType.SmallInt)
            paramJobSpecs.Value = 0
            arParams(16) = paramJobSpecs

            Dim paramApprovedByJS As New SqlParameter("@ApprovedByJS", SqlDbType.SmallInt)
            paramApprovedByJS.Value = 0
            arParams(17) = paramApprovedByJS

            Dim paramTitleJS As New SqlParameter("@TitleJS", SqlDbType.VarChar)
            paramTitleJS.Value = ""
            arParams(18) = paramTitleJS

            Dim paramSchedComments As New SqlParameter("@SchedComments", SqlDbType.SmallInt)
            If schedComments = True Then
                paramSchedComments.Value = 1
            Else
                paramSchedComments.Value = 0
            End If
            arParams(19) = paramSchedComments

            Dim paramVendorSpecs As New SqlParameter("@VendorSpecs", SqlDbType.SmallInt)
            If vendorSpecs = True Then
                paramVendorSpecs.Value = 1
            Else
                paramVendorSpecs.Value = 0
            End If
            arParams(20) = paramVendorSpecs

            Dim paramMediaSpecs As New SqlParameter("@MediaSpecs", SqlDbType.SmallInt)
            If mediaSpecs = True Then
                paramMediaSpecs.Value = 1
            Else
                paramMediaSpecs.Value = 0
            End If
            arParams(21) = paramMediaSpecs

            Dim paramJobVersions As New SqlParameter("@JobVersions", SqlDbType.SmallInt)
            If jobVersions = True Then
                paramJobVersions.Value = 1
            Else
                paramJobVersions.Value = 0
            End If
            arParams(22) = paramJobVersions

            Dim paramOmitEmptyFieldsCB As New SqlParameter("@OmitEmptyFieldsCB", SqlDbType.SmallInt)
            If omitEmptyFieldsCB = True Then
                paramOmitEmptyFieldsCB.Value = 1
            Else
                paramOmitEmptyFieldsCB.Value = 0
            End If
            arParams(23) = paramOmitEmptyFieldsCB

            Dim paramOmitEmptyFieldsJV As New SqlParameter("@OmitEmptyFieldsJV", SqlDbType.SmallInt)
            If omitEmptyFieldsJV = True Then
                paramOmitEmptyFieldsJV.Value = 1
            Else
                paramOmitEmptyFieldsJV.Value = 0
            End If
            arParams(24) = paramOmitEmptyFieldsJV

            Dim paramOmitEmptyFieldsJS As New SqlParameter("@OmitEmptyFieldsJS", SqlDbType.SmallInt)
            If omitEmptyFieldsJS = True Then
                paramOmitEmptyFieldsJS.Value = 1
            Else
                paramOmitEmptyFieldsJS.Value = 0
            End If
            arParams(25) = paramOmitEmptyFieldsJS

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_SaveJobOrderFormSettings", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cReports Routine:JobOrderSettingsSave", Err.Description)
                Return False
            End Try

            Return True

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobOrderFormSettings", Err.Description)
        End Try
    End Function

    Public Function UpdateJobOrderFormSettings(ByVal userid As String, _
                                               ByVal locationid As String, _
                                               ByVal reportTitlePlacement As Integer, _
                                               ByVal jobOrderForm As Boolean, _
                                               ByVal omitEmptyFields As Boolean, _
                                               ByVal trafficAssignments As Boolean, _
                                               ByVal sectionTitleTA As String, _
                                               ByVal trafficSchedule As Boolean, _
                                               ByVal sectionTitleTS As String, _
                                               ByVal dueDateOnly As Boolean, _
                                               ByVal milestonesOnly As Boolean, _
                                               ByVal milestonesTitle As String, _
                                               ByVal employeeAssignments As Boolean, _
                                               ByVal creativeBrief As Boolean, _
                                               ByVal approvedByCB As Boolean, _
                                               ByVal reportTitleCB As String, _
                                               ByVal jobSpecs As Boolean, _
                                               ByVal approvedByJS As Boolean, _
                                               ByVal reportTitleJS As String, _
                                               ByVal schedComments As Boolean, _
                                               ByVal vendorSpecs As Boolean, _
                                               ByVal mediaSpecs As Boolean, _
                                               ByVal jobVersions As Boolean, _
                                               ByVal omitEmptyFieldsCB As Boolean, _
                                               ByVal omitEmptyFieldsJV As Boolean, _
                                               ByVal omitEmptyFieldsJS As Boolean) As Boolean

        Try
            Dim arParams(25) As SqlParameter

            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
            paramUserID.Value = userid
            arParams(0) = paramUserID

            Dim paramJobOrderForm As New SqlParameter("@JobOrderForm", SqlDbType.SmallInt)
            If jobOrderForm = True Then
                paramJobOrderForm.Value = 1
            Else
                paramJobOrderForm.Value = 0
            End If
            arParams(1) = paramJobOrderForm

            Dim paramOmitEmptyFields As New SqlParameter("@OmitEmptyFields", SqlDbType.SmallInt)
            If omitEmptyFields = True Then
                paramOmitEmptyFields.Value = 1
            Else
                paramOmitEmptyFields.Value = 0
            End If
            arParams(2) = paramOmitEmptyFields

            Dim paramTrafficAssignments As New SqlParameter("@TrafficAssignments", SqlDbType.SmallInt)
            If trafficAssignments = True Then
                paramTrafficAssignments.Value = 1
            Else
                paramTrafficAssignments.Value = 0
            End If
            arParams(3) = paramTrafficAssignments

            Dim paramTitleTA As New SqlParameter("@TitleTA", SqlDbType.VarChar)
            paramTitleTA.Value = sectionTitleTA
            arParams(4) = paramTitleTA

            Dim paramTrafficSchedule As New SqlParameter("@TrafficSchedule", SqlDbType.SmallInt)
            If trafficSchedule = True Then
                paramTrafficSchedule.Value = 1
            Else
                paramTrafficSchedule.Value = 0
            End If
            arParams(5) = paramTrafficSchedule

            Dim paramTitleTS As New SqlParameter("@TitleTS", SqlDbType.VarChar)
            paramTitleTS.Value = sectionTitleTS
            arParams(6) = paramTitleTS

            Dim paramDueDateOnly As New SqlParameter("@DueDateOnly", SqlDbType.SmallInt)
            If dueDateOnly = True Then
                paramDueDateOnly.Value = 1
            Else
                paramDueDateOnly.Value = 0
            End If
            arParams(7) = paramDueDateOnly

            Dim paramMilestonesOnly As New SqlParameter("@MilestonesOnly", SqlDbType.SmallInt)
            If milestonesOnly = True Then
                paramMilestonesOnly.Value = 1
            Else
                paramMilestonesOnly.Value = 0
            End If
            arParams(8) = paramMilestonesOnly

            Dim paramMilestoneTitle As New SqlParameter("@MilestoneTitle", SqlDbType.VarChar)
            paramMilestoneTitle.Value = milestonesTitle
            arParams(9) = paramMilestoneTitle

            Dim paramEmployAssignments As New SqlParameter("@EmployAssignments", SqlDbType.SmallInt)
            If employeeAssignments = True Then
                paramEmployAssignments.Value = 1
            Else
                paramEmployAssignments.Value = 0
            End If
            arParams(10) = paramEmployAssignments

            Dim paramLocationID As New SqlParameter("@LocationID", SqlDbType.VarChar)
            paramLocationID.Value = locationid
            arParams(11) = paramLocationID

            Dim paramReportPlacement As New SqlParameter("@ReportPlacement", SqlDbType.VarChar)
            paramReportPlacement.Value = reportTitlePlacement
            arParams(12) = paramReportPlacement

            Dim paramCreativeBrief As New SqlParameter("@CreativeBrief", SqlDbType.SmallInt)
            paramCreativeBrief.Value = creativeBrief
            arParams(13) = paramCreativeBrief

            Dim paramApprovedByCB As New SqlParameter("@ApprovedByCB", SqlDbType.SmallInt)
            paramApprovedByCB.Value = approvedByCB
            arParams(14) = paramApprovedByCB

            Dim paramTitleCB As New SqlParameter("@TitleCB", SqlDbType.VarChar)
            paramTitleCB.Value = reportTitleCB
            arParams(15) = paramTitleCB

            Dim paramJobSpecs As New SqlParameter("@JobSpecs", SqlDbType.SmallInt)
            paramJobSpecs.Value = jobSpecs
            arParams(16) = paramJobSpecs

            Dim paramApprovedByJS As New SqlParameter("@ApprovedByJS", SqlDbType.SmallInt)
            paramApprovedByJS.Value = approvedByJS
            arParams(17) = paramApprovedByJS

            Dim paramTitleJS As New SqlParameter("@TitleJS", SqlDbType.VarChar)
            paramTitleJS.Value = reportTitleJS
            arParams(18) = paramTitleJS

            Dim paramSchedComments As New SqlParameter("@SchedComments", SqlDbType.SmallInt)
            If schedComments = True Then
                paramSchedComments.Value = 1
            Else
                paramSchedComments.Value = 0
            End If
            arParams(19) = paramSchedComments

            Dim paramVendorSpecs As New SqlParameter("@VendorSpecs", SqlDbType.SmallInt)
            If vendorSpecs = True Then
                paramVendorSpecs.Value = 1
            Else
                paramVendorSpecs.Value = 0
            End If
            arParams(20) = paramVendorSpecs

            Dim paramMediaSpecs As New SqlParameter("@MediaSpecs", SqlDbType.SmallInt)
            If mediaSpecs = True Then
                paramMediaSpecs.Value = 1
            Else
                paramMediaSpecs.Value = 0
            End If
            arParams(21) = paramMediaSpecs

            Dim paramJobVersions As New SqlParameter("@JobVersions", SqlDbType.SmallInt)
            If jobVersions = True Then
                paramJobVersions.Value = 1
            Else
                paramJobVersions.Value = 0
            End If
            arParams(22) = paramJobVersions

            Dim paramOmitEmptyFieldsCB As New SqlParameter("@OmitEmptyFieldsCB", SqlDbType.SmallInt)
            If omitEmptyFieldsCB = True Then
                paramOmitEmptyFieldsCB.Value = 1
            Else
                paramOmitEmptyFieldsCB.Value = 0
            End If
            arParams(23) = paramOmitEmptyFieldsCB

            Dim paramOmitEmptyFieldsJV As New SqlParameter("@OmitEmptyFieldsJV", SqlDbType.SmallInt)
            If omitEmptyFieldsJV = True Then
                paramOmitEmptyFieldsJV.Value = 1
            Else
                paramOmitEmptyFieldsJV.Value = 0
            End If
            arParams(24) = paramOmitEmptyFieldsJV

            Dim paramOmitEmptyFieldsJS As New SqlParameter("@OmitEmptyFieldsJS", SqlDbType.SmallInt)
            If omitEmptyFieldsJS = True Then
                paramOmitEmptyFieldsJS.Value = 1
            Else
                paramOmitEmptyFieldsJS.Value = 0
            End If
            arParams(25) = paramOmitEmptyFieldsJS

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_UpdateJobOrderFormSettings", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cReports Routine:JobOrderSettingsUpdate", Err.Description)
                Return False
            End Try

            Return True

        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobOrderFormSettings", Err.Description)
        End Try
    End Function

    Public Function GetJobOrderEmailAddresses(ByVal empcodes As String) As SqlDataReader
        Try
            Dim arParams(1) As SqlParameter
            'Dim paramEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar)
            'paramEmpCode.Value = empcode
            'arParams(0) = paramEmpCode

            Dim paramEmpCodes As New SqlParameter("@EmpCodes", SqlDbType.VarChar)
            paramEmpCodes.Value = empcodes
            arParams(0) = paramEmpCodes

            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetJobOrderEmailAddresses", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetJobTrafficAssignments", Err.Description)
        End Try
    End Function

    Public Function GetCDPAddressInfo(ByVal level As String, ByVal client As String, Optional ByVal division As String = "", Optional ByVal product As String = "", Optional ByVal jobcontact As String = "")
        Try
            Dim arParams(5) As SqlParameter
            Dim paramLEVEL As New SqlParameter("@LEVEL", SqlDbType.VarChar)
            paramLEVEL.Value = level
            arParams(0) = paramLEVEL

            Dim paramCLIENT As New SqlParameter("@CLIENT", SqlDbType.VarChar)
            paramCLIENT.Value = client
            arParams(1) = paramCLIENT

            Dim paramDIVISION As New SqlParameter("@DIVISION", SqlDbType.VarChar)
            paramDIVISION.Value = division
            arParams(2) = paramDIVISION

            Dim paramPRODUCT As New SqlParameter("@PRODUCT", SqlDbType.VarChar)
            paramPRODUCT.Value = product
            arParams(3) = paramPRODUCT

            Dim paramCONTACT As New SqlParameter("@CONTACT", SqlDbType.VarChar)
            paramCONTACT.Value = jobcontact
            arParams(4) = paramCONTACT


            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_getCDPInfo", "dtCDP", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetCDPAddressInfo", Err.Description)
        End Try
    End Function

    Public Function GetCDPAddressInfoAll(ByVal level As String, ByVal client As String, Optional ByVal division As String = "", Optional ByVal product As String = "", Optional ByVal jobcontact As String = "")
        Try
            Dim arParams(5) As SqlParameter
            Dim paramLEVEL As New SqlParameter("@LEVEL", SqlDbType.VarChar)
            paramLEVEL.Value = level
            arParams(0) = paramLEVEL

            Dim paramCLIENT As New SqlParameter("@CLIENT", SqlDbType.VarChar)
            paramCLIENT.Value = client
            arParams(1) = paramCLIENT

            Dim paramDIVISION As New SqlParameter("@DIVISION", SqlDbType.VarChar)
            paramDIVISION.Value = division
            arParams(2) = paramDIVISION

            Dim paramPRODUCT As New SqlParameter("@PRODUCT", SqlDbType.VarChar)
            paramPRODUCT.Value = product
            arParams(3) = paramPRODUCT

            Dim paramCONTACT As New SqlParameter("@CONTACT", SqlDbType.VarChar)
            paramCONTACT.Value = jobcontact
            arParams(4) = paramCONTACT


            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_getCDPInfoAll", "dtCDP", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetCDPAddressInfo", Err.Description)
        End Try
    End Function

    Public Function GetCDPAddressInfoEstimate(ByVal level As String, ByVal client As String, Optional ByVal division As String = "", Optional ByVal product As String = "", Optional ByVal jobcontact As String = "")
        Try
            Dim arParams(5) As SqlParameter
            Dim paramLEVEL As New SqlParameter("@LEVEL", SqlDbType.VarChar)
            paramLEVEL.Value = level
            arParams(0) = paramLEVEL

            Dim paramCLIENT As New SqlParameter("@CLIENT", SqlDbType.VarChar)
            paramCLIENT.Value = client
            arParams(1) = paramCLIENT

            Dim paramDIVISION As New SqlParameter("@DIVISION", SqlDbType.VarChar)
            paramDIVISION.Value = division
            arParams(2) = paramDIVISION

            Dim paramPRODUCT As New SqlParameter("@PRODUCT", SqlDbType.VarChar)
            paramPRODUCT.Value = product
            arParams(3) = paramPRODUCT

            Dim paramCONTACT As New SqlParameter("@CONTACT", SqlDbType.VarChar)
            paramCONTACT.Value = jobcontact
            arParams(4) = paramCONTACT


            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_Estimate_getCDPInfo", "dtCDP", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetCDPAddressInfo", Err.Description)
        End Try
    End Function

    Public Function GetTasks(ByVal template As String, ByVal milestone As Boolean) As DataTable
        Try
            Dim arParams(2) As SqlParameter
            Dim parammilestone As New SqlParameter("@Milestone", SqlDbType.SmallInt)
            If milestone = True Then
                parammilestone.Value = 1
            Else
                parammilestone.Value = 0
            End If
            arParams(0) = parammilestone

            Dim paramtemplate As New SqlParameter("@TaskTemplate", SqlDbType.VarChar)
            paramtemplate.Value = template
            arParams(1) = paramtemplate

            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_reports_traffic_schedule_GetTasks", "dtTasks", arParams)


        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cReports Routine:GetTasks", Err.Description)
        End Try
    End Function

    Public Function GetAgencyEstComment() As String

        Try
            Return oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_agency_EstCommentQuery")
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetAgencyEstComment", Err.Description)
        End Try

    End Function

    Public Function GetProjectHoursUsed(ByVal strUserId As String, ByVal sdate As String, ByVal edate As String, ByVal sortorder As String, ByVal OpenJobsOnly As Integer, ByVal group As Integer) As DataTable
        Dim dt As DataTable
        Dim arParams(6) As SqlParameter

        Try
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = strUserId
            arParams(0) = parameterUserID

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            parameterStartDate.Value = sdate
            arParams(1) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            parameterEndDate.Value = edate
            arParams(2) = parameterEndDate

            Dim parameterSortOrder As New SqlParameter("@SortOrder", SqlDbType.VarChar)
            parameterSortOrder.Value = sortorder
            arParams(3) = parameterSortOrder

            Dim parameterOpenJobsOnly As New SqlParameter("@OpenJobsOnly", SqlDbType.SmallInt)
            parameterOpenJobsOnly.Value = OpenJobsOnly
            arParams(4) = parameterOpenJobsOnly

            Dim parameterGroup As New SqlParameter("@Group", SqlDbType.SmallInt)
            parameterGroup.Value = group
            arParams(5) = parameterGroup

            dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_rpt_ProjectHours", "test", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cReports Routine:GetProjectHoursUsed", Err.Description)
        End Try

        Return dt
    End Function
End Class
