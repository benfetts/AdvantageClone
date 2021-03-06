Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports System.IO

Namespace wvTimeSheet


    Public Class cCulture
        Private _CultureName As String
        Public Property CultureName() As String
            Get
                Return _CultureName
            End Get
            Set(ByVal value As String)
                _CultureName = value
            End Set
        End Property
    End Class

    <Serializable()> Public Class TimeSheetTemplate
        Private mConnString As String = ""
        Private mUserCode As String = ""
        Private mEmpCode As String = ""
        Private oSQL As SqlHelper


        Public Function GetTemplate(Optional ByVal EmpCode As String = "", Optional ByVal UserCode As String = "") As DataTable
            If EmpCode = "" Then EmpCode = mEmpCode
            If UserCode = "" Then UserCode = mUserCode

            Dim arP(2) As SqlParameter

            Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEmpCode.Value = EmpCode
            arP(0) = pEmpCode

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = UserCode
            arP(1) = pUserCode

            Try
                Return oSQL.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_EMP_TIME_TMPLT_GET", "DatatableTimesheetTemplate", arP)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function SaveToTemplate(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal FncCode As String, ByVal DefaultComment As String,
                                       Optional ByVal EmpCode As String = "", Optional ByVal DpTmCode As String = "", Optional ByVal ProdCatCode As String = "", Optional ByVal EmpHours As Decimal = 0.0, Optional ByVal ApplyToDays As String = "") As String
            If EmpCode = "" Then EmpCode = mEmpCode

            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append("INSERT INTO EMP_TIME_TMPLT WITH(ROWLOCK)")
                .Append("(")
                .Append("	EMP_CODE,")
                .Append("	JOB_NUMBER,")
                .Append("	JOB_COMPONENT_NBR,")
                .Append("	FNC_CODE,")
                .Append("	DFLT_COMMENT,")
                .Append("	DP_TM_CODE,")
                .Append("	PROD_CAT_CODE,")
                .Append("	EMP_HOURS,")
                .Append("	APPLY_TO_DAYS")
                .Append(")")
                .Append(" VALUES")
                .Append("(")
                .Append("	@EMP_CODE,")
                .Append("	@JOB_NUMBER,")
                .Append("	@JOB_COMPONENT_NBR,")
                .Append("	@FNC_CODE,")
                .Append("	@DFLT_COMMENT,")
                .Append("	@DP_TM_CODE,")
                .Append("	@PROD_CAT_CODE,")
                .Append("	@EMP_HOURS,")
                .Append("	@APPLY_TO_DAYS")
                .Append(");SELECT SCOPE_IDENTITY();")
            End With
            Dim arP(9) As SqlParameter

            Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEmpCode.Value = EmpCode
            arP(0) = pEmpCode

            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            If JobNumber > 0 Then
                pJobNumber.Value = JobNumber
            Else
                pJobNumber.Value = System.DBNull.Value
            End If
            arP(1) = pJobNumber

            Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            If JobComponentNbr > 0 Then
                pJobComponentNbr.Value = JobComponentNbr
            Else
                pJobComponentNbr.Value = System.DBNull.Value
            End If
            arP(2) = pJobComponentNbr

            Dim pFncCode As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
            pFncCode.Value = FncCode
            arP(3) = pFncCode

            Dim pDfltComment As New SqlParameter("@DFLT_COMMENT", SqlDbType.Text)
            If DefaultComment.Trim() = "" Then
                pDfltComment.Value = System.DBNull.Value
            Else
                pDfltComment.Value = DefaultComment
            End If
            arP(4) = pDfltComment

            Dim pDpTmCode As New SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 4)
            If DpTmCode.Trim() = "" Then
                pDpTmCode.Value = System.DBNull.Value
            Else
                pDpTmCode.Value = DpTmCode
            End If
            arP(5) = pDpTmCode

            Dim pProdCatCode As New SqlParameter("@PROD_CAT_CODE", SqlDbType.VarChar, 10)
            If ProdCatCode.Trim() = "" Then
                pProdCatCode.Value = System.DBNull.Value
            Else
                pProdCatCode.Value = ProdCatCode
            End If
            arP(6) = pProdCatCode

            Dim pEmpHours As New SqlParameter("@EMP_HOURS", SqlDbType.Decimal)
            pEmpHours.Value = EmpHours
            arP(7) = pEmpHours

            Dim pApplyToDays As New SqlParameter("@APPLY_TO_DAYS", SqlDbType.VarChar, 30)
            If ApplyToDays.Trim() = "" Then
                pApplyToDays.Value = System.DBNull.Value
            Else
                pApplyToDays.Value = ApplyToDays
            End If
            arP(8) = pApplyToDays

            Try
                Return oSQL.ExecuteScalar(Me.mConnString, CommandType.Text, SQL.ToString(), arP)
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        End Function

        Public Function UpdateTemplateRecord(ByVal EmpTimeTmpltId As Integer, ByVal DefaultComment As String, ByVal FncCode As String,
                                             ByVal DeptTeam As String, ByVal ProdCat As String, ByVal EmpHours As Decimal, ByVal ApplyToDays As String) As String
            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append("UPDATE EMP_TIME_TMPLT WITH(ROWLOCK) ")
                .Append("SET ")
                .Append("	FNC_CODE = @FNC_CODE, ")
                .Append("	DP_TM_CODE = @DP_TM_CODE, ")
                .Append("	PROD_CAT_CODE = @PROD_CAT_CODE, ")
                .Append("	DFLT_COMMENT = @DFLT_COMMENT, ")
                .Append("	EMP_HOURS = @EMP_HOURS, ")
                .Append("	APPLY_TO_DAYS = @APPLY_TO_DAYS ")
                .Append("WHERE EMP_TIME_TMPLT_ID = @EMP_TIME_TMPLT_ID;")
            End With
            Dim arP(7) As SqlParameter

            Dim pEmpTimeTmpltId As New SqlParameter("@EMP_TIME_TMPLT_ID", SqlDbType.Int)
            pEmpTimeTmpltId.Value = EmpTimeTmpltId
            arP(0) = pEmpTimeTmpltId

            Dim pDefaultComment As New SqlParameter("@DFLT_COMMENT", SqlDbType.Text)
            If DefaultComment.Trim() = "" Then
                pDefaultComment.Value = System.DBNull.Value
            Else
                pDefaultComment.Value = DefaultComment
            End If
            arP(1) = pDefaultComment

            Dim pFncCode As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
            If FncCode.Trim() = "" Then
                pFncCode.Value = System.DBNull.Value
            Else
                pFncCode.Value = FncCode
            End If
            arP(2) = pFncCode

            Dim pDeptTeam As New SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 4)
            If DeptTeam.Trim() = "" Then
                pDeptTeam.Value = System.DBNull.Value
            Else
                pDeptTeam.Value = DeptTeam
            End If
            arP(3) = pDeptTeam

            Dim pProdCat As New SqlParameter("@PROD_CAT_CODE", SqlDbType.VarChar, 10)
            If ProdCat.Trim() = "" Then
                pProdCat.Value = System.DBNull.Value
            Else
                pProdCat.Value = ProdCat
            End If
            arP(4) = pProdCat

            Dim pEmpHours As New SqlParameter("@EMP_HOURS", SqlDbType.Decimal)
            pEmpHours.Value = EmpHours
            arP(5) = pEmpHours

            Dim pApplyToDays As New SqlParameter("@APPLY_TO_DAYS", SqlDbType.VarChar, 30)
            If ApplyToDays.Trim() = "" Then
                pApplyToDays.Value = System.DBNull.Value
            Else
                pApplyToDays.Value = ApplyToDays
            End If
            arP(6) = pApplyToDays


            Try
                oSQL.ExecuteNonQuery(Me.mConnString, CommandType.Text, SQL.ToString(), arP)
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        End Function

        Public Function DeleteFromTemplate(ByVal EmpTimeTmpltId As Integer) As String
            Dim SQL As String = "DELETE FROM EMP_TIME_TMPLT WITH(ROWLOCK) WHERE EMP_TIME_TMPLT_ID = @EMP_TIME_TMPLT_ID;"
            Dim arP(1) As SqlParameter

            Dim pEmpTimeTmpltId As New SqlParameter("@EMP_TIME_TMPLT_ID", SqlDbType.Int)
            pEmpTimeTmpltId.Value = EmpTimeTmpltId
            arP(0) = pEmpTimeTmpltId

            Try
                oSQL.ExecuteNonQuery(Me.mConnString, CommandType.Text, SQL, arP)
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        End Function

        Public Function SaveToTimesheet() As String

        End Function

        Public Sub New(Optional ByVal UserCode As String = "", Optional ByVal EmpCode As String = "")
            mConnString = HttpContext.Current.Session("ConnString")
            Try
                If UserCode <> "" Then
                    mUserCode = UserCode
                Else
                    mUserCode = HttpContext.Current.Session("UserCode")
                End If
            Catch ex As Exception
                mUserCode = ""
            End Try
            Try
                If EmpCode <> "" Then
                    mEmpCode = EmpCode
                Else
                    mEmpCode = HttpContext.Current.Session("EmpCode")
                End If
            Catch ex As Exception
                mEmpCode = ""
            End Try
        End Sub

    End Class

    <Serializable()>
    Public Class CommentViewStruct
        Public Property EditMessage As String = ""

        Public Property ClCode As String = ""
        Public Property DivCode As String = ""
        Public Property PrdCode As String = ""
        Public Property JobNumber As Integer = 0
        Public Property JobComponentNbr As Integer = 0

        Public Property JobDescription As String = ""
        Public Property JobComponentDescription As String = ""

        Public Property FuncCat As String = ""
        Public Property Dept As String = ""
        Public Property ProdCat As String = ""
        Public Property AlertID As Integer = 0

        Public Property SunDate As Date = Nothing
        Public Property MonDate As Date = Nothing
        Public Property TueDate As Date = Nothing
        Public Property WedDate As Date = Nothing
        Public Property ThuDate As Date = Nothing
        Public Property FriDate As Date = Nothing
        Public Property SatDate As Date = Nothing

        Public Property SunEtId As Integer = 0
        Public Property MonEtId As Integer = 0
        Public Property TueEtId As Integer = 0
        Public Property WedEtId As Integer = 0
        Public Property ThuEtId As Integer = 0
        Public Property FriEtId As Integer = 0
        Public Property SatEtId As Integer = 0

        Public Property SunEtDtlId As Integer = 0
        Public Property MonEtDtlId As Integer = 0
        Public Property TueEtDtlId As Integer = 0
        Public Property WedEtDtlId As Integer = 0
        Public Property ThuEtDtlId As Integer = 0
        Public Property FriEtDtlId As Integer = 0
        Public Property SatEtDtlId As Integer = 0

        Public Property SunTimeType As String = ""
        Public Property MonTimeType As String = ""
        Public Property TueTimeType As String = ""
        Public Property WedTimeType As String = ""
        Public Property ThuTimeType As String = ""
        Public Property FriTimeType As String = ""
        Public Property SatTimeType As String = ""

        Public Property SunEditFlag As Integer = 0
        Public Property MonEditFlag As Integer = 0
        Public Property TueEditFlag As Integer = 0
        Public Property WedEditFlag As Integer = 0
        Public Property ThuEditFlag As Integer = 0
        Public Property FriEditFlag As Integer = 0
        Public Property SatEditFlag As Integer = 0

        Public Property SunSavedHours As Decimal = 0.0
        Public Property MonSavedHours As Decimal = 0.0
        Public Property TueSavedHours As Decimal = 0.0
        Public Property WedSavedHours As Decimal = 0.0
        Public Property ThuSavedHours As Decimal = 0.0
        Public Property FriSavedHours As Decimal = 0.0
        Public Property SatSavedHours As Decimal = 0.0

        Public Property SunTextboxHours As Decimal = 0.0
        Public Property MonTextboxHours As Decimal = 0.0
        Public Property TueTextboxHours As Decimal = 0.0
        Public Property WedTextboxHours As Decimal = 0.0
        Public Property ThuTextboxHours As Decimal = 0.0
        Public Property FriTextboxHours As Decimal = 0.0
        Public Property SatTextboxHours As Decimal = 0.0

        Public Property SunHasStopWatch As Boolean = False
        Public Property MonHasStopWatch As Boolean = False
        Public Property TueHasStopWatch As Boolean = False
        Public Property WedHasStopWatch As Boolean = False
        Public Property ThuHasStopWatch As Boolean = False
        Public Property FriHasStopWatch As Boolean = False
        Public Property SatHasStopWatch As Boolean = False

        Public Sub New()

        End Sub

    End Class

    <Serializable()>
    Public Class TimesheetCommentView

        Private DataKey As String = ""
        Public CVData As New CommentViewStruct

        Public Sub FromSession()
            Try
                If DataKey <> "" Then
                    If Not HttpContext.Current.Session(DataKey) = Nothing Then
                        Dim formatter As LosFormatter = New LosFormatter
                        Dim reader As StringReader = New StringReader(HttpContext.Current.Session(DataKey).ToString())
                        CVData = CType(formatter.Deserialize(reader), CommentViewStruct)
                        'reader.Dispose()
                        'formatter = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Sub ToSession()
            Try
                If DataKey <> "" Then
                    Dim formatter As LosFormatter = New LosFormatter
                    Dim writer As StringWriter = New StringWriter
                    formatter.Serialize(writer, CVData)
                    'writer.Dispose()
                    'formatter = Nothing
                    Me.ClearSession()
                    HttpContext.Current.Session(DataKey) = writer.ToString()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Sub ClearSession()
            Try
                If DataKey <> "" Then
                    HttpContext.Current.Session(DataKey) = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Sub New()
            Try
                DataKey = "CommentViewEdit_" & HttpContext.Current.Session("UserCode").ToString() & "_" & HttpContext.Current.Session("EmpCode").ToString() '& "_" & Now.Hour.ToString()
            Catch ex As Exception
                DataKey = ""
            End Try
        End Sub

    End Class

    <Serializable()> Public Class cTimeSheet
        Dim mConnString As String
        Dim oSQL As SqlHelper

        Private _DaysToDisplay As Integer = 5
        Private _ShowCommentUsing As String = "textbox"
        Private _StartWeekOn As DayOfWeek = DayOfWeek.Sunday

        Public ReadOnly Property DaysToDisplay As Integer
            Get

                Return _DaysToDisplay





            End Get
        End Property
        Public ReadOnly Property ShowCommentsUsing As String
            Get

                Return _ShowCommentUsing

            End Get
        End Property
        Public Property StartWeekOn As DayOfWeek
            Get
                Return _StartWeekOn
            End Get
            Set(value As DayOfWeek)
                _StartWeekOn = value
            End Set
        End Property

        Public Function JobCommentRequired(ByVal JobNumber As Integer, Optional ByVal ErrorMessage As String = "") As Boolean

            Dim IsValid As Boolean = False
            Dim SessionKey As String = "JobCommentRequired" & JobNumber.ToString.PadLeft(6, "0")

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try

                    Dim m As New AdvantageFramework.Timesheet.TimesheetSettings(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                    IsValid = m.JobCommentRequired(JobNumber, ErrorMessage)

                Catch ex As Exception

                    IsValid = False

                End Try

                HttpContext.Current.Session(SessionKey) = IsValid

            Else

                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

            End If

            Return IsValid

        End Function
        Public Function GetSessionTimesheetSettings(ByVal UserCode As String) As AdvantageFramework.Timesheet.Settings.DisplaySettings

            Dim SessionKey As String = "GetTimesheetSettings" & UserCode
            Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings

            If HttpContext.Current.Session(SessionKey) Is Nothing Then

                Dim tm As New AdvantageFramework.Timesheet.TimesheetSettings(mConnString, UserCode)
                TsSettings = tm.GetSettings(UserCode)

                HttpContext.Current.Session(SessionKey) = TsSettings

            Else

                TsSettings = CType(HttpContext.Current.Session(SessionKey), AdvantageFramework.Timesheet.Settings.DisplaySettings)

            End If

            Return TsSettings

        End Function
        Public Function ClearSessionTimesheetSettings(ByVal UserCode As String) As Boolean
            Try
                Dim SessionKey As String = "GetTimesheetSettings" & UserCode
                HttpContext.Current.Session(SessionKey) = Nothing
                HttpContext.Current.Session("LOLT20150321") = Nothing
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Sub GetDayNameStrings(ByVal [Date] As Date, ByRef ShortDay As String, ByRef FullDay As String, ByVal StartWeekOn As DayOfWeek)
            Select Case StartWeekOn
                Case DayOfWeek.Saturday

                    FullDay = [Date].AddDays(1).DayOfWeek.ToString()

                Case DayOfWeek.Sunday

                    FullDay = [Date].DayOfWeek.ToString()

                Case DayOfWeek.Monday

                    FullDay = [Date].AddDays(-1).DayOfWeek.ToString()

            End Select

            ShortDay = FullDay.Substring(0, 3)

        End Sub
        Public Function GetCommentViewFromDetailId(ByVal EtId As Integer, ByVal EtDtlId As Integer,
                                       Optional ByRef ErrorMessage As String = "") As TimesheetCommentView
            Try
                Dim tcv As New TimesheetCommentView()

                Using MyConn As New SqlConnection(Me.mConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_GetTimesheetFromDetailId"
                        .Connection = MyConn
                    End With

                    Dim pEtId As New SqlParameter("@ET_ID", SqlDbType.Int)
                    pEtId.Value = EtId
                    Dim pEtDtlId As New SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                    pEtDtlId.Value = EtDtlId
                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pUserCode.Value = HttpContext.Current.Session("UserCode").ToString()

                    MyCommand.Parameters.Add(pEtId)
                    MyCommand.Parameters.Add(pEtDtlId)
                    MyCommand.Parameters.Add(pUserCode)

                    MyConn.Open()

                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then
                        Do While Reader.Read()
                            If Reader.GetInt32(Reader.GetOrdinal("EmployeeTimeID")) = EtId And Reader.GetInt32(Reader.GetOrdinal("EmployeeTimeDetailID")) = EtDtlId Then
                                With tcv.CVData
                                    If IsDBNull(Reader(Reader.GetOrdinal("ClientCode"))) = False Then
                                        .ClCode = Reader.GetValue(Reader.GetOrdinal("ClientCode"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("DivisionCode"))) = False Then
                                        .DivCode = Reader.GetString(Reader.GetOrdinal("DivisionCode"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("ProductCode"))) = False Then
                                        .PrdCode = Reader.GetString(Reader.GetOrdinal("ProductCode"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("JobNumber"))) = False Then
                                        .JobNumber = Reader.GetInt32(Reader.GetOrdinal("JobNumber"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("JobComponentNumber"))) = False Then
                                        .JobComponentNbr = Reader.GetValue(Reader.GetOrdinal("JobComponentNumber"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("NonEditMessage"))) = False Then
                                        .EditMessage = Reader.GetString(Reader.GetOrdinal("NonEditMessage"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("FunctionCategory"))) = False Then
                                        .FuncCat = Reader.GetString(Reader.GetOrdinal("FunctionCategory"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("DepartmentTeamCode"))) = False Then
                                        .Dept = Reader.GetString(Reader.GetOrdinal("DepartmentTeamCode"))
                                    End If
                                    If IsDBNull(Reader(Reader.GetOrdinal("ProductCategoryCode"))) = False Then
                                        .ProdCat = Reader.GetString(Reader.GetOrdinal("ProductCategoryCode"))
                                    End If
                                    Dim EmpDate As Date = Nothing
                                    If IsDBNull(Reader(Reader.GetOrdinal("EmployeeDate"))) = False Then
                                        EmpDate = Reader.GetDateTime(Reader.GetOrdinal("EmployeeDate"))
                                    End If
                                    Try

                                        If IsDBNull(Reader(Reader.GetOrdinal("AlertID"))) = False Then
                                            .AlertID = Reader.GetValue(Reader.GetOrdinal("AlertID"))
                                        End If

                                    Catch ex As Exception
                                    End Try
                                    'If IsDBNull(Reader(Reader.GetOrdinal(""))) = False Then
                                    'End If
                                    'If IsDBNull(Reader(Reader.GetOrdinal(""))) = False Then
                                    'End If

                                    Select Case EmpDate.DayOfWeek
                                        Case DayOfWeek.Sunday
                                            .SunDate = EmpDate
                                            .SunEtId = EtId
                                            .SunEtDtlId = EtDtlId
                                            .SunEditFlag = Reader.GetValue(Reader.GetOrdinal("EditFlag"))
                                            .SunTimeType = Reader.GetString(Reader.GetOrdinal("TimeType"))
                                            .SunSavedHours = Reader.GetDecimal(Reader.GetOrdinal("EmployeeHours"))
                                            If Reader.GetInt32(Reader.GetOrdinal("HasStopwatch")) = 1 Then
                                                .SunHasStopWatch = True
                                            End If
                                        Case DayOfWeek.Monday
                                            .MonDate = EmpDate
                                            .MonEtId = EtId
                                            .MonEtDtlId = EtDtlId
                                            .MonEditFlag = Reader.GetValue(Reader.GetOrdinal("EditFlag"))
                                            .MonTimeType = Reader.GetString(Reader.GetOrdinal("TimeType"))
                                            .MonSavedHours = Reader.GetDecimal(Reader.GetOrdinal("EmployeeHours"))
                                            If Reader.GetInt32(Reader.GetOrdinal("HasStopwatch")) = 1 Then
                                                .MonHasStopWatch = True
                                            End If
                                        Case DayOfWeek.Tuesday
                                            .TueDate = EmpDate
                                            .TueEtId = EtId
                                            .TueEtDtlId = EtDtlId
                                            .TueEditFlag = Reader.GetValue(Reader.GetOrdinal("EditFlag"))
                                            .TueTimeType = Reader.GetString(Reader.GetOrdinal("TimeType"))
                                            .TueSavedHours = Reader.GetDecimal(Reader.GetOrdinal("EmployeeHours"))
                                            If Reader.GetInt32(Reader.GetOrdinal("HasStopwatch")) = 1 Then
                                                .TueHasStopWatch = True
                                            End If
                                        Case DayOfWeek.Wednesday
                                            .WedDate = EmpDate
                                            .WedEtId = EtId
                                            .WedEtDtlId = EtDtlId
                                            .WedEditFlag = Reader.GetValue(Reader.GetOrdinal("EditFlag"))
                                            .WedTimeType = Reader.GetString(Reader.GetOrdinal("TimeType"))
                                            .WedSavedHours = Reader.GetDecimal(Reader.GetOrdinal("EmployeeHours"))
                                            If Reader.GetInt32(Reader.GetOrdinal("HasStopwatch")) = 1 Then
                                                .WedHasStopWatch = True
                                            End If
                                        Case DayOfWeek.Thursday
                                            .ThuDate = EmpDate
                                            .ThuEtId = EtId
                                            .ThuEtDtlId = EtDtlId
                                            .ThuEditFlag = Reader.GetValue(Reader.GetOrdinal("EditFlag"))
                                            .ThuTimeType = Reader.GetString(Reader.GetOrdinal("TimeType"))
                                            .ThuSavedHours = Reader.GetDecimal(Reader.GetOrdinal("EmployeeHours"))
                                            If Reader.GetInt32(Reader.GetOrdinal("HasStopwatch")) = 1 Then
                                                .ThuHasStopWatch = True
                                            End If
                                        Case DayOfWeek.Friday
                                            .FriDate = EmpDate
                                            .FriEtId = EtId
                                            .FriEtDtlId = EtDtlId
                                            .FriEditFlag = Reader.GetValue(Reader.GetOrdinal("EditFlag"))
                                            .FriTimeType = Reader.GetString(Reader.GetOrdinal("TimeType"))
                                            .FriSavedHours = Reader.GetDecimal(Reader.GetOrdinal("EmployeeHours"))
                                            If Reader.GetInt32(Reader.GetOrdinal("HasStopwatch")) = 1 Then
                                                .FriHasStopWatch = True
                                            End If
                                        Case DayOfWeek.Saturday
                                            .SatDate = EmpDate
                                            .SatEtId = EtId
                                            .SatEtDtlId = EtDtlId
                                            .SatEditFlag = Reader.GetValue(Reader.GetOrdinal("EditFlag"))
                                            .SatTimeType = Reader.GetString(Reader.GetOrdinal("TimeType"))
                                            .SatSavedHours = Reader.GetDecimal(Reader.GetOrdinal("EmployeeHours"))
                                            If Reader.GetInt32(Reader.GetOrdinal("HasStopwatch")) = 1 Then
                                                .SatHasStopWatch = True
                                            End If
                                    End Select
                                End With
                                Exit Do
                            End If
                        Loop
                    End If

                    If MyConn.State = ConnectionState.Open Then
                        MyConn.Close()
                        MyConn.Dispose()
                    End If

                End Using

                ErrorMessage = ""
                Return tcv

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return Nothing
            End Try
        End Function
        Public Function GetCommentViewFromTimesheetLine(ByVal ts As AdvantageFramework.Timesheet.TimeSheet, ByVal StartDate As Date, ByVal LineId As String) As TimesheetCommentView
            'Dim TsMeth As New AdvantageFramework.Timesheet.Methods(Me.mConnString, HttpContext.Current.Session("UserCode"))
            Dim cv As New TimesheetCommentView
            Dim line As AdvantageFramework.Timesheet.TimesheetLine

            line = AdvantageFramework.Timesheet.GetTimesheetLine(ts, LineId)

            If Not line Is Nothing Then

                With cv.CVData
                    Try
                        .ClCode = line.ClientCode
                    Catch ex As Exception
                        .ClCode = ""
                    End Try
                    Try
                        .DivCode = line.DivisionCode
                    Catch ex As Exception
                        .DivCode = ""
                    End Try
                    Try
                        .PrdCode = line.ProductCode
                    Catch ex As Exception
                        .PrdCode = ""
                    End Try
                    Try
                        .JobNumber = line.JobNumber
                    Catch ex As Exception
                        .JobNumber = 0
                    End Try
                    Try
                        .JobComponentNbr = line.JobComponentNbr
                    Catch ex As Exception
                        .JobComponentNbr = 0
                    End Try
                    Try
                        .EditMessage = line.NonEditMessage
                    Catch ex As Exception
                        .EditMessage = ""
                    End Try
                    Try
                        .FuncCat = line.FuncCat
                    Catch ex As Exception
                        .FuncCat = ""
                    End Try
                    Try
                        .Dept = line.Dept
                    Catch ex As Exception
                        .Dept = ""
                    End Try
                    Try
                        .ProdCat = line.ProductCategory
                    Catch ex As Exception
                        .ProdCat = ""
                    End Try
                    Try
                        .AlertID = line.AlertID
                    Catch ex As Exception
                        .AlertID = 0
                    End Try
                    If Not line.Sunday Is Nothing Then

                        .SunDate = line.Sunday.tDate
                        .SunEtId = line.Sunday.ETID
                        .SunEtDtlId = line.Sunday.ETDTLID
                        .SunEditFlag = line.Sunday.EditFlag
                        .SunSavedHours = line.Sunday.Hours
                        .SunHasStopWatch = line.Sunday.HasStopwatch
                        .SunTimeType = line.TimeType

                    Else

                        .SunDate = StartDate.AddDays(0)
                        .SunEtId = 0
                        .SunEtDtlId = 0
                        .SunEditFlag = CType(AdvantageFramework.Timesheet.TimesheetEditType.Edit, Integer)
                        .SunSavedHours = 0
                        .SunHasStopWatch = False
                        .SunTimeType = line.TimeType

                    End If
                    If Not line.Monday Is Nothing Then

                        .MonDate = line.Monday.tDate
                        .MonEtId = line.Monday.ETID
                        .MonEtDtlId = line.Monday.ETDTLID
                        .MonEditFlag = line.Monday.EditFlag
                        .MonSavedHours = line.Monday.Hours
                        .MonHasStopWatch = line.Monday.HasStopwatch
                        .MonTimeType = line.TimeType

                    Else

                        .MonDate = StartDate.AddDays(1)
                        .MonEtId = 0
                        .MonEtDtlId = 0
                        .MonEditFlag = CType(AdvantageFramework.Timesheet.TimesheetEditType.Edit, Integer)
                        .MonSavedHours = 0
                        .MonHasStopWatch = False
                        .MonTimeType = line.TimeType

                    End If
                    If Not line.Tuesday Is Nothing Then

                        .TueDate = line.Tuesday.tDate
                        .TueEtId = line.Tuesday.ETID
                        .TueEtDtlId = line.Tuesday.ETDTLID
                        .TueEditFlag = line.Tuesday.EditFlag
                        .TueSavedHours = line.Tuesday.Hours
                        .TueHasStopWatch = line.Tuesday.HasStopwatch
                        .TueTimeType = line.TimeType

                    Else

                        .TueDate = StartDate.AddDays(2)
                        .TueEtId = 0
                        .TueEtDtlId = 0
                        .TueEditFlag = CType(AdvantageFramework.Timesheet.TimesheetEditType.Edit, Integer)
                        .TueSavedHours = 0
                        .TueHasStopWatch = False
                        .TueTimeType = line.TimeType

                    End If
                    If Not line.Wednesday Is Nothing Then

                        .WedDate = line.Wednesday.tDate
                        .WedEtId = line.Wednesday.ETID
                        .WedEtDtlId = line.Wednesday.ETDTLID
                        .WedEditFlag = line.Wednesday.EditFlag
                        .WedSavedHours = line.Wednesday.Hours
                        .WedHasStopWatch = line.Wednesday.HasStopwatch
                        .WedTimeType = line.TimeType

                    Else

                        .WedDate = StartDate.AddDays(3)
                        .WedEtId = 0
                        .WedEtDtlId = 0
                        .WedEditFlag = CType(AdvantageFramework.Timesheet.TimesheetEditType.Edit, Integer)
                        .WedSavedHours = 0
                        .WedHasStopWatch = False
                        .WedTimeType = line.TimeType

                    End If
                    If Not line.Thursday Is Nothing Then

                        .ThuDate = line.Thursday.tDate
                        .ThuEtId = line.Thursday.ETID
                        .ThuEtDtlId = line.Thursday.ETDTLID
                        .ThuEditFlag = line.Thursday.EditFlag
                        .ThuSavedHours = line.Thursday.Hours
                        .ThuHasStopWatch = line.Thursday.HasStopwatch
                        .ThuTimeType = line.TimeType

                    Else

                        .ThuDate = StartDate.AddDays(4)
                        .ThuEtId = 0
                        .ThuEtDtlId = 0
                        .ThuEditFlag = CType(AdvantageFramework.Timesheet.TimesheetEditType.Edit, Integer)
                        .ThuSavedHours = 0
                        .ThuHasStopWatch = False
                        .ThuTimeType = line.TimeType

                    End If
                    If Not line.Friday Is Nothing Then

                        .FriDate = line.Friday.tDate
                        .FriEtId = line.Friday.ETID
                        .FriEtDtlId = line.Friday.ETDTLID
                        .FriEditFlag = line.Friday.EditFlag
                        .FriSavedHours = line.Friday.Hours
                        .FriHasStopWatch = line.Friday.HasStopwatch
                        .FriTimeType = line.TimeType

                    Else

                        .FriDate = StartDate.AddDays(5)
                        .FriEtId = 0
                        .FriEtDtlId = 0
                        .FriEditFlag = CType(AdvantageFramework.Timesheet.TimesheetEditType.Edit, Integer)
                        .FriSavedHours = 0
                        .FriHasStopWatch = False
                        .FriTimeType = line.TimeType

                    End If
                    If Not line.Saturday Is Nothing Then

                        .SatDate = line.Saturday.tDate
                        .SatEtId = line.Saturday.ETID
                        .SatEtDtlId = line.Saturday.ETDTLID
                        .SatEditFlag = line.Saturday.EditFlag
                        .SatSavedHours = line.Saturday.Hours
                        .SatHasStopWatch = line.Saturday.HasStopwatch
                        .SatTimeType = line.TimeType

                    Else

                        .SatDate = StartDate.AddDays(6)
                        .SatEtId = 0
                        .SatEtDtlId = 0
                        .SatEditFlag = CType(AdvantageFramework.Timesheet.TimesheetEditType.Edit, Integer)
                        .SatSavedHours = 0
                        .SatHasStopWatch = False
                        .SatTimeType = line.TimeType

                    End If

                End With

            End If

            Return cv

        End Function
        Public Function GetDateRange(ByVal TheDate As Date, ByRef StartDate As Date, ByRef EndDate As Date, Optional ByVal ErrorMessage As String = "") As Boolean
            Try

                StartDate = FirstDayOfWeek(TheDate)

                HttpContext.Current.Session("TimesheetStartDate") = StartDate

                EndDate = StartDate.AddDays(6)
                HttpContext.Current.Session("TimesheetEndDate") = EndDate

                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try
        End Function
        Public Function GetDateRangeCalendarTime(ByVal TheDate As Date, ByRef StartDate As Date, ByRef EndDate As Date, Optional ByVal ErrorMessage As String = "") As Boolean
            Try

                StartDate = FirstDayOfWeek(TheDate)

                HttpContext.Current.Session("TimesheetStartDate") = StartDate

                EndDate = StartDate.AddDays(6)
                HttpContext.Current.Session("TimesheetEndDate") = EndDate

                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try
        End Function

        Public Function FirstDayOfWeek(ByVal TheDate As Date) As Date
            Try

                Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                Dim FirstDayOfWeekDate As Date

                TsSettings = GetSessionTimesheetSettings(HttpContext.Current.Session("UserCode"))

                If TheDate = Nothing Then TheDate = Now.Date

                StartWeekOn = TsSettings.StartTimesheetOnDayOfWeek

                For i As Integer = 0 To 6 Step 1

                    FirstDayOfWeekDate = TheDate.AddDays(-i)

                    If FirstDayOfWeekDate.DayOfWeek = StartWeekOn Then

                        Exit For

                    End If

                Next

                Return FirstDayOfWeekDate

            Catch ex As Exception

                Return TheDate

            End Try
        End Function
        Public Overloads Function IsCurrentWeek(ByVal StartDate As Date, ByVal EndDate As Date) As Boolean
            Try

                Dim CurrentWeekStart As Date
                Dim CurrentWeekEnd As Date

                GetDateRange(Now.Date, CurrentWeekStart, CurrentWeekEnd)

                If StartDate = CurrentWeekStart AndAlso EndDate = CurrentWeekEnd Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Overloads Function IsCurrentWeek(ByVal TheDate As Date) As Boolean
            Try

                Dim CurrentWeekStart As Date
                Dim CurrentWeekEnd As Date

                GetDateRange(Now.Date, CurrentWeekStart, CurrentWeekEnd)

                If TheDate >= CurrentWeekStart AndAlso TheDate <= CurrentWeekEnd Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function IsInWeek(ByVal TheDate As Date, ByRef CurrentWeekStart As Date, ByRef CurrentWeekEnd As Date) As Boolean
            Try

                Dim TheDateWeekStart As Date
                Dim TheDateWeekEnd As Date

                GetDateRange(TheDate, TheDateWeekStart, TheDateWeekEnd)

                If TheDateWeekStart = CurrentWeekStart AndAlso TheDateWeekEnd = CurrentWeekEnd Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function GetTimesheetSettings(ByVal UserCode As String,
                                          Optional ByRef DaysToShow As Integer = 7, Optional ByRef StartWeekOn As String = "sun", Optional ByRef ShowCommentUsing As String = "",
                                          Optional ByRef DivisionLabel As String = "Division", Optional ByRef ProductLabel As String = "Product", Optional ByRef ProductCategoryLabel As String = "Prod Cat",
                                          Optional ByRef JobLabel As String = "Job", Optional ByRef JobComponentLabel As String = "Component", Optional ByRef FunctionCategoryLabel As String = "Func/Cat",
                                          Optional ByRef ErrorMessage As String = "") As Boolean

            Try

                Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                TsSettings = Me.GetSessionTimesheetSettings(UserCode)

                DaysToShow = TsSettings.DaysToDisplay
                StartWeekOn = TsSettings.StartTimesheetOnDayOfWeek
                ShowCommentUsing = TsSettings.ShowCommentsUsing
                DivisionLabel = TsSettings.Labels.Division
                ProductLabel = TsSettings.Labels.Product
                ProductCategoryLabel = TsSettings.Labels.ProdCat
                JobLabel = TsSettings.Labels.Job
                JobComponentLabel = TsSettings.Labels.JobComponent
                FunctionCategoryLabel = TsSettings.Labels.FuncCat

                Return True

            Catch ex As Exception

                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False

            End Try
        End Function

        Public Function GetAgencyTimesheetSettings(Optional ByRef DaysToShow As Integer = 7, Optional ByRef StartWeekOn As String = "sun", Optional ByRef ShowCommentUsing As String = "",
                                    Optional ByRef DivisionLabel As String = "Division", Optional ByRef ProductLabel As String = "Product", Optional ByRef ProductCategoryLabel As String = "Prod Cat",
                                    Optional ByRef JobLabel As String = "Job", Optional ByRef JobComponentLabel As String = "Component", Optional ByRef FunctionCategoryLabel As String = "Func/Cat",
                                    Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Dim SessionKey As String = "GetAgencyTimesheetSettings"
                If HttpContext.Current.Session(SessionKey) Is Nothing Then
                    Dim arP(1) As SqlParameter

                    'Create Stored Procedure Parameters
                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pUserCode.Value = System.DBNull.Value
                    arP(0) = pUserCode

                    Dim dt As New DataTable
                    dt = SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.StoredProcedure, "usp_wv_ts_get_settings", "DtTimesheetSettings", arP)
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        DaysToShow = dt.Rows(0)("DAYS_TO_DISPLAY")
                        StartWeekOn = dt.Rows(0)("START_WEEK_ON")
                        ShowCommentUsing = dt.Rows(0)("SHOW_COMMENT_USING")
                        DivisionLabel = dt.Rows(0)("DIVISION_LABEL")
                        ProductLabel = dt.Rows(0)("PRODUCT_LABEL")
                        ProductCategoryLabel = dt.Rows(0)("PROD_CAT_LABEL")
                        JobLabel = dt.Rows(0)("JOB_LABEL")
                        JobComponentLabel = dt.Rows(0)("JOB_COMP_LABEL")
                        FunctionCategoryLabel = dt.Rows(0)("FUNC_CAT_LABEL")
                    Else
                        DaysToShow = 7
                        StartWeekOn = "sun"
                        ShowCommentUsing = "icon"
                        DivisionLabel = "Division"
                        ProductLabel = "Product"
                        ProductCategoryLabel = "Prod Cat"
                        JobLabel = "Job"
                        JobComponentLabel = "Component"
                        FunctionCategoryLabel = "Func/Cat"
                    End If
                    HttpContext.Current.Session(SessionKey & "DaysToShow") = DaysToShow
                    HttpContext.Current.Session(SessionKey & "StartWeekOn") = StartWeekOn
                    HttpContext.Current.Session(SessionKey & "ShowCommentUsing") = ShowCommentUsing
                    HttpContext.Current.Session(SessionKey & "DivisionLabel") = DivisionLabel
                    HttpContext.Current.Session(SessionKey & "ProductLabel") = ProductLabel
                    HttpContext.Current.Session(SessionKey & "ProductCategoryLabel") = ProductCategoryLabel
                    HttpContext.Current.Session(SessionKey & "JobLabel") = JobLabel
                    HttpContext.Current.Session(SessionKey & "JobComponentLabel") = JobComponentLabel
                    HttpContext.Current.Session(SessionKey & "FunctionCategoryLabel") = FunctionCategoryLabel

                    HttpContext.Current.Session(SessionKey) = True
                Else

                    DaysToShow = HttpContext.Current.Session(SessionKey & "DaysToShow")
                    StartWeekOn = HttpContext.Current.Session(SessionKey & "StartWeekOn")
                    ShowCommentUsing = HttpContext.Current.Session(SessionKey & "ShowCommentUsing")
                    DivisionLabel = HttpContext.Current.Session(SessionKey & "DivisionLabel")
                    ProductLabel = HttpContext.Current.Session(SessionKey & "ProductLabel")
                    ProductCategoryLabel = HttpContext.Current.Session(SessionKey & "ProductCategoryLabel")
                    JobLabel = HttpContext.Current.Session(SessionKey & "JobLabel")
                    JobComponentLabel = HttpContext.Current.Session(SessionKey & "JobComponentLabel")
                    FunctionCategoryLabel = HttpContext.Current.Session(SessionKey & "FunctionCategoryLabel")

                End If
                Return True
            Catch ex As Exception
                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try
        End Function

        Public Function GetThisTimeSheetForSelection(ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As AdvantageFramework.Timesheet.TimeSheet
            Dim dr As SqlDataReader
            Dim strThisLine As String
            Dim ThisTimeSheet As AdvantageFramework.Timesheet.TimeSheet = New AdvantageFramework.Timesheet.TimeSheet
            Dim thisLine As AdvantageFramework.Timesheet.TimesheetLine
            Dim DayProcessed As Boolean
            Dim arParams(3) As SqlParameter

            'Create Stored Procedure Parameters
            Dim parameteremp_code As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
            parameteremp_code.Value = EmpCode
            arParams(0) = parameteremp_code
            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime, 0)
            parameterStartDate.Value = StartDate
            arParams(1) = parameterStartDate
            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime, 0)
            parameterEndDate.Value = EndDate
            arParams(2) = parameterEndDate
            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_ts_GetTimeSheetForSelection", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetThisTimeSheet", Err.Description)
            Finally

            End Try

            ThisTimeSheet.EmpCode = EmpCode
            ThisTimeSheet.StartDate = StartDate
            ThisTimeSheet.EndDate = EndDate

            If dr.HasRows = True Then

                Do While dr.Read

                    DayProcessed = False
                    Dim ThisDay As New AdvantageFramework.Timesheet.TimesheetEntry
                    Try
                        ThisDay.ETID = dr.GetValue(0)
                    Catch ex As Exception
                    End Try
                    Try
                        ThisDay.ETDTLID() = dr.GetValue(1)
                    Catch ex As Exception
                    End Try
                    Try
                        ThisDay.Hours = CDbl(dr.GetSqlDecimal(3).Value)
                    Catch ex As Exception
                    End Try
                    Try
                        ThisDay.TimeType = dr.GetString(11).ToString
                    Catch ex As Exception
                    End Try
                    Try
                        ThisDay.EditFlag = dr.GetSqlInt16(12).Value
                    Catch ex As Exception
                    End Try
                    Try
                        ThisDay.tDate = dr.GetDateTime(16)
                    Catch ex As Exception
                    End Try
                    Try
                        If dr.IsDBNull(17) = False Then
                            ThisDay.Comments = dr.GetString(17).ToString
                        End If
                    Catch ex As Exception
                    End Try

                    'Create Compare String
                    'strThisLine = dr.GetInt32(1).ToString()'ET_DTL_ID
                    Try
                        strThisLine = dr.GetSqlString(4).ToString() 'Client
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(5).ToString() 'Division
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(6).ToString() 'Product
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetValue(7).ToString() '& " - " & dr.GetString(19).ToString()'Job
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetValue(9).ToString() '& " - " & dr.GetString(21).ToString()'Job Comp
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(2).ToString() ' Func/Cat
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(10).ToString() 'Dept
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(24).ToString() 'product cat
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(25).ToString() ' client name
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(26).ToString() 'div name
                    Catch ex As Exception
                    End Try
                    Try
                        strThisLine &= dr.GetSqlString(27).ToString() 'prod name
                    Catch ex As Exception
                    End Try
                    'If dr.GetSqlString(20).IsNull = False Then
                    '    strThisLine &= dr.GetSqlString(20).ToString() 'ProductCat
                    'End If

                    'Search For a Line 
                    Dim TempLine As AdvantageFramework.Timesheet.TimesheetLine
                    For Each TempLine In ThisTimeSheet
                        If TempLine.LineIdentifier = strThisLine Then
                            Select Case ThisDay.tDate.DayOfWeek
                                Case DayOfWeek.Monday
                                    If TempLine.Monday Is Nothing Then
                                        TempLine.Monday = ThisDay
                                        TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                        DayProcessed = True
                                        Exit For
                                    End If
                                Case DayOfWeek.Tuesday
                                    If TempLine.Tuesday Is Nothing Then
                                        TempLine.Tuesday = ThisDay
                                        TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                        DayProcessed = True
                                        Exit For
                                    End If
                                Case DayOfWeek.Wednesday
                                    If TempLine.Wednesday Is Nothing Then
                                        TempLine.Wednesday = ThisDay
                                        TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                        DayProcessed = True
                                        Exit For
                                    End If
                                Case DayOfWeek.Thursday
                                    If TempLine.Thursday Is Nothing Then
                                        TempLine.Thursday = ThisDay
                                        TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                        DayProcessed = True
                                        Exit For
                                    End If
                                Case DayOfWeek.Friday
                                    If TempLine.Friday Is Nothing Then
                                        TempLine.Friday = ThisDay
                                        TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                        DayProcessed = True
                                        Exit For
                                    End If
                                Case DayOfWeek.Saturday
                                    If TempLine.Saturday Is Nothing Then
                                        TempLine.Saturday = ThisDay
                                        TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                        DayProcessed = True
                                        Exit For
                                    End If
                                Case DayOfWeek.Sunday
                                    If TempLine.Sunday Is Nothing Then
                                        TempLine.Sunday = ThisDay
                                        TempLine.TotalHours = TempLine.TotalHours + ThisDay.Hours
                                        DayProcessed = True
                                        Exit For
                                    End If
                            End Select
                        End If
                    Next

                    If DayProcessed = False Then
                        thisLine = New AdvantageFramework.Timesheet.TimesheetLine
                        Try
                            If dr.GetSqlString(4).IsNull = False Then
                                thisLine.ClientCode = dr.GetSqlString(4).ToString
                            Else
                                thisLine.ClientCode = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(5).IsNull = False Then
                                thisLine.DivisionCode = dr.GetSqlString(5).ToString
                            Else
                                thisLine.DivisionCode = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(6).IsNull = False Then
                                thisLine.ProductCode = dr.GetSqlString(6).ToString
                            Else
                                thisLine.ProductCode = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If IsDBNull(dr(7)) = False Then
                                thisLine.JobNumber = dr(7)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If IsDBNull(dr(9)) = False Then
                                thisLine.JobComponentNbr = dr(9)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(18).IsNull = False Then
                                thisLine.JobDesc = dr.GetSqlString(19).Value
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(19).IsNull = False Then
                                thisLine.JobCompDesc = dr.GetSqlString(21).Value
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(2).IsNull = False Then
                                thisLine.FuncCat = dr.GetSqlString(2).ToString
                            Else
                                thisLine.FuncCat = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(10).IsNull = False Then
                                thisLine.Dept = dr.GetSqlString(10).ToString
                            Else
                                thisLine.Dept = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(24).IsNull = False Then
                                thisLine.ProductCategory = dr.GetSqlString(24).ToString
                            Else
                                thisLine.ProductCategory = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(25).IsNull = False Then
                                thisLine.ClientName = dr.GetSqlString(25).ToString
                            Else
                                thisLine.ClientName = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(26).IsNull = False Then
                                thisLine.DivisionName = dr.GetSqlString(26).ToString
                            Else
                                thisLine.DivisionName = ""
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dr.GetSqlString(27).IsNull = False Then
                                thisLine.ProductDescription = dr.GetSqlString(27).ToString
                            Else
                                thisLine.ProductDescription = ""
                            End If
                        Catch ex As Exception
                        End Try

                        thisLine.LineIdentifier = strThisLine

                        Select Case ThisDay.tDate.DayOfWeek
                            Case DayOfWeek.Monday
                                thisLine.Monday = ThisDay
                            Case DayOfWeek.Tuesday
                                thisLine.Tuesday = ThisDay
                            Case DayOfWeek.Wednesday
                                thisLine.Wednesday = ThisDay
                            Case DayOfWeek.Thursday
                                thisLine.Thursday = ThisDay
                            Case DayOfWeek.Friday
                                thisLine.Friday = ThisDay
                            Case DayOfWeek.Saturday
                                thisLine.Saturday = ThisDay
                            Case DayOfWeek.Sunday
                                thisLine.Sunday = ThisDay
                        End Select
                        thisLine.TotalHours = thisLine.TotalHours + ThisDay.Hours

                        ThisTimeSheet.Add(thisLine)
                    End If

                Loop
            End If

            dr.Close()

            'Return
            Return ThisTimeSheet
        End Function

        Public Function GetThisTimeSheetPrint(ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date, Optional ByVal strSortColumn As String = "CL_CODE") As DataTable
            Dim dr As DataTable
            Dim strThisLine As String
            Dim ThisTimeSheet As AdvantageFramework.Timesheet.TimeSheet = New AdvantageFramework.Timesheet.TimeSheet
            Dim thisLine As AdvantageFramework.Timesheet.TimesheetLine
            Dim DayProcessed As Boolean
            Dim arParams(5) As SqlParameter

            'Create Stored Procedure Parameters
            Dim parameteremp_code As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
            parameteremp_code.Value = EmpCode
            arParams(0) = parameteremp_code

            Dim parameterStartDate As New SqlParameter("@StartDate", SqlDbType.SmallDateTime, 0)
            parameterStartDate.Value = StartDate
            arParams(1) = parameterStartDate

            Dim parameterEndDate As New SqlParameter("@EndDate", SqlDbType.SmallDateTime, 0)
            parameterEndDate.Value = EndDate
            arParams(2) = parameterEndDate

            Dim parameterSortColumn As New SqlParameter("@SortColumn", SqlDbType.VarChar, 35)
            parameterSortColumn.Value = strSortColumn
            arParams(3) = parameterSortColumn

            Dim pUserId As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserId.Value = HttpContext.Current.Session("UserCode")
            arParams(4) = pUserId

            Try
                dr = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ts_GetTimeSheetPrint", "test", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetThisTimeSheet", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function SetMissingTimeLabel(ByVal UserID As String) As String
            Try
                Dim oSQL As SqlHelper
                Dim arParams(0) As SqlParameter
                Dim dr As SqlDataReader
                Dim LabelText As String = ""

                Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
                paramUserID.Value = UserID
                arParams(0) = paramUserID

                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_missing_time_employee_ct_hours", arParams)

                Dim ct As Int32 = 0
                Dim weeklyTime As Int32 = 0
                Dim MissingHours As Decimal = 0.0

                If dr.HasRows Then
                    dr.Read()
                    If Not IsDBNull(dr.GetValue(0)) Then
                        weeklyTime = dr.GetInt32(0)
                    End If
                    If Not IsDBNull(dr.GetValue(1)) Then
                        ct = dr.GetInt32(1)
                    End If
                    If Not IsDBNull(dr.GetValue(2)) Then
                        MissingHours = dr.GetDecimal(2)
                    End If

                    If MissingHours > 0 Or ct > 0 Then
                        'If weeklyTime = 0 Then  'Daily
                        '    LabelText = "Missing time: " & CStr(ct) & " Days, " & CStr(MissingHours) & " Hrs."
                        'Else    'Weekly
                        '    LabelText = "Missing time: " & CStr(MissingHours) & " Hrs."
                        'End If
                        LabelText = "You have missing time!"

                    End If
                End If

                Return LabelText

            Catch ex As Exception
                Err.Raise(Err.Number, "Error cTimeSheet: setMissingTimeLabel!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            End Try
        End Function

        Public Function DeleteMissingTimeDtl(ByVal EmpCode As String) As Boolean
            Dim arParams(1) As SqlParameter

            'Create Stored Procedure Parameters
            Dim parameter_empCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            parameter_empCode.Value = EmpCode
            arParams(0) = parameter_empCode

            Try
                oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_delete_missing_time_dtl", arParams)
            Catch
                Return False
            End Try

            Return True

        End Function

        Public Function ValidateInfo(ByVal EmpCode As String,
                              ByVal ClCode As String, ByVal DivCode As String, ByVal PrdCode As String,
                              ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                              ByVal FunctionOrCategoryCode As String, ByVal DeptCode As String,
                              ByVal ProductCategory As String, Optional ByRef ReturnMessage As String = "") As Boolean
            Try
                If EmpCode = "" Then
                    ReturnMessage = "Employee code is required"
                    Return False
                End If

                Dim oTraffic As cTraffic = New cTraffic(Me.mConnString, CStr(HttpContext.Current.Session("UserCode")))
                If oTraffic.IsEmpTerminated(EmpCode) Then
                    ReturnMessage = "This Employee code is inactive"
                    Exit Function
                End If
                If oTraffic.ValidateEmpCode(EmpCode) = False Then
                    ReturnMessage = "Invalid Employee code"
                    Exit Function
                End If

                Dim oValidation As cValidations = New cValidations(Me.mConnString)
                If ClCode <> "" Then
                    If oValidation.ValidateCDPIsViewable("CL", HttpContext.Current.Session("UserCode"), ClCode, "", "", "ts") = False Then
                        ReturnMessage = "Access to this Client is denied"
                        Return False
                    End If
                End If
                If ClCode <> "" And DivCode <> "" Then
                    If oValidation.ValidateCDPIsViewable("DI", HttpContext.Current.Session("UserCode"), ClCode, DivCode, "", "ts") = False Then
                        ReturnMessage = "Access to this Division is denied"
                        Return False
                    End If
                End If
                If ClCode <> "" And DivCode <> "" And PrdCode <> "" Then
                    If oValidation.ValidateCDPIsViewable("PR", HttpContext.Current.Session("UserCode"), ClCode, DivCode, PrdCode, "ts") = False Then
                        ReturnMessage = "Access to this Product is denied"
                        Return False
                    End If
                End If
                If JobNumber > 0 And JobComponentNbr = 0 Then
                    ReturnMessage = "Job selected without a Component"
                    Return False
                End If
                If JobNumber > 0 Then
                    If oValidation.ValidateJobNumber(JobNumber) = False Then
                        ReturnMessage = "Invalid Job"
                    End If
                End If
                If JobNumber > 0 And JobComponentNbr > 0 Then
                    If oValidation.ValidateJobCompNumber(JobNumber, JobComponentNbr) = False Then
                        ReturnMessage = "This is not a valid Job/Component"
                        Return False
                    End If
                    If oValidation.ValidateJobCompIsEditable(JobNumber, JobComponentNbr) = False Then
                        ReturnMessage = "Job/Component process control does not allow access"
                        Return False
                    End If
                    If oValidation.ValidateJobCompIsViewable(HttpContext.Current.Session("UserCode"), JobNumber, JobComponentNbr, "ts") = False Then
                        ReturnMessage = "Access to this Job/Component is denied"
                        Return False
                    End If
                End If
                If FunctionOrCategoryCode.Trim() = "" Then
                    ReturnMessage = "Function/Category is required"
                End If

                If JobNumber = 0 And JobComponentNbr = 0 And FunctionOrCategoryCode <> "" Then 'it is a category and not a function
                    If oValidation.ValidateFunctionCategoryAll(EmpCode, FunctionOrCategoryCode, "V", True) = False Then
                        ReturnMessage = FunctionOrCategoryCode & " is an invalid Category"
                        Return False
                    End If
                End If

                Dim EmployeeDefaultFunction As String = Me.GetDefaultFunction(EmpCode)
                If FunctionOrCategoryCode = EmployeeDefaultFunction Then
                    If oValidation.ValidateFunctionTSAddNew(EmpCode, EmployeeDefaultFunction) = False Then
                        ReturnMessage = "This Employee does not have access to his/her own default Function"
                        Return False
                    End If
                End If

                If JobNumber > 0 And JobComponentNbr > 0 And FunctionOrCategoryCode <> "" And FunctionOrCategoryCode <> EmployeeDefaultFunction Then
                    If oValidation.ValidateFunctionTSAddNew(EmpCode, FunctionOrCategoryCode) = False Then
                        ReturnMessage = FunctionOrCategoryCode & " is an invalid Function"
                        Return False
                    End If
                End If

                If DeptCode <> "" Then
                    If oValidation.ValidateDeptTeam(DeptCode) = False Then
                        ReturnMessage = DeptCode & " is an invalid Department"
                        Return False
                    End If
                End If

                Dim ovisible As cVisible = New cVisible(Me.mConnString)
                If ovisible.ProductCategoryVisible() = True Then
                    If ProductCategory = "" Then
                        Dim oReq As cRequired = New cRequired(Me.mConnString)
                        If oReq.ProductCategoryRequired(ClCode) = True Then
                            ReturnMessage = "Product Category is required"
                            Return False
                        End If
                    Else
                        If oValidation.ValidateProductCategory(ProductCategory, ClCode, DivCode, PrdCode) = False Then
                            ReturnMessage = "Product Category is not valid"
                            Return False
                        End If
                    End If
                End If

                ReturnMessage = ""
                Return True

            Catch ex As Exception
                ReturnMessage = ex.Message.ToString()
                Return False
            End Try

        End Function

        Public Function ValidateInfoCalendarTime(ByVal EmpCode As String,
                              ByVal ClCode As String, ByVal DivCode As String, ByVal PrdCode As String,
                              ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                              ByVal FunctionOrCategoryCode As String, ByVal DeptCode As String,
                              ByVal ProductCategory As String, Optional ByRef ReturnMessage As String = "") As Boolean
            Try
                If EmpCode = "" Then
                    ReturnMessage = "Employee code is required"
                    Return False
                End If

                Dim oTraffic As cTraffic = New cTraffic(Me.mConnString, CStr(HttpContext.Current.Session("UserCode")))
                If oTraffic.IsEmpTerminated(EmpCode) Then
                    ReturnMessage = "This Employee code is inactive"
                    Exit Function
                End If
                If oTraffic.ValidateEmpCode(EmpCode) = False Then
                    ReturnMessage = "Invalid Employee code"
                    Exit Function
                End If

                Dim oValidation As cValidations = New cValidations(Me.mConnString)
                If ClCode <> "" Then
                    If oValidation.ValidateCDPIsViewable("CL", HttpContext.Current.Session("UserCode"), ClCode, "", "", "ts") = False Then
                        ReturnMessage = "Access to this Client is denied"
                        Return False
                    End If
                End If
                If ClCode <> "" And DivCode <> "" Then
                    If oValidation.ValidateCDPIsViewable("DI", HttpContext.Current.Session("UserCode"), ClCode, DivCode, "", "ts") = False Then
                        ReturnMessage = "Access to this Division is denied"
                        Return False
                    End If
                End If
                If ClCode <> "" And DivCode <> "" And PrdCode <> "" Then
                    If oValidation.ValidateCDPIsViewable("PR", HttpContext.Current.Session("UserCode"), ClCode, DivCode, PrdCode, "ts") = False Then
                        ReturnMessage = "Access to this Product is denied"
                        Return False
                    End If
                End If
                If JobNumber > 0 And JobComponentNbr = 0 Then
                    ReturnMessage = "Job selected without a Component"
                    Return False
                End If
                If JobNumber > 0 Then
                    If oValidation.ValidateJobNumber(JobNumber) = False Then
                        ReturnMessage = "Invalid Job"
                    End If
                End If
                If JobNumber > 0 And JobComponentNbr > 0 Then
                    If oValidation.ValidateJobCompNumber(JobNumber, JobComponentNbr) = False Then
                        ReturnMessage = "This is not a valid Job/Component"
                        Return False
                    End If
                    If oValidation.ValidateJobCompIsEditable(JobNumber, JobComponentNbr) = False Then
                        ReturnMessage = "Job/Component process control does not allow access"
                        Return False
                    End If
                    If oValidation.ValidateJobCompIsViewable(HttpContext.Current.Session("UserCode"), JobNumber, JobComponentNbr, "ts") = False Then
                        ReturnMessage = "Access to this Job/Component is denied"
                        Return False
                    End If
                End If
                If FunctionOrCategoryCode.Trim() = "" Then
                    ReturnMessage = "Function/Category is required"
                End If

                'If JobNumber = 0 And JobComponentNbr = 0 And FunctionOrCategoryCode <> "" Then 'it is a category and not a function
                '    If oValidation.ValidateFunctionCategoryAll(EmpCode, FunctionOrCategoryCode, "V", True) = False Then
                '        ReturnMessage = FunctionOrCategoryCode & " is an invalid Category"
                '        Return False
                '    End If
                'End If

                Dim EmployeeDefaultFunction As String = Me.GetDefaultFunction(EmpCode)
                If FunctionOrCategoryCode = EmployeeDefaultFunction Then
                    If oValidation.ValidateFunctionTSAddNew(EmpCode, EmployeeDefaultFunction) = False Then
                        ReturnMessage = "This Employee does not have access to his/her own default Function"
                        Return False
                    End If
                End If

                If JobNumber <> 0 And JobComponentNbr <> 0 And FunctionOrCategoryCode <> "" And FunctionOrCategoryCode <> EmployeeDefaultFunction Then
                    If oValidation.ValidateFunctionTSAddNew(EmpCode, FunctionOrCategoryCode) = False Then
                        ReturnMessage = FunctionOrCategoryCode & " is an invalid Function"
                        Return False
                    End If
                End If

                If DeptCode <> "" Then
                    If oValidation.ValidateDeptTeam(DeptCode) = False Then
                        ReturnMessage = DeptCode & " is an invalid Department"
                        Return False
                    End If
                End If

                Dim ovisible As cVisible = New cVisible(Me.mConnString)
                If ovisible.ProductCategoryVisible() = True Then
                    If ProductCategory = "" Then
                        'Dim oReq As cRequired = New cRequired(Me.mConnString)
                        'If oReq.ProductCategoryRequired(ClCode) = True Then
                        '    ReturnMessage = "Product Category is required"
                        '    Return False
                        'End If
                    Else
                        If oValidation.ValidateProductCategory(ProductCategory, ClCode, DivCode, PrdCode) = False Then
                            ReturnMessage = "Product Category is not valid"
                            Return False
                        End If
                    End If
                End If

                ReturnMessage = ""
                Return True

            Catch ex As Exception
                ReturnMessage = ex.Message.ToString()
                Return False
            End Try

        End Function

        'Used in new timesheet
        Public Overloads Function DeleteTime(ByVal ET_ID As Integer, ByVal ETD_ID As Integer, ByVal TimeType As String) As String
            Dim MyReturn As String = ""
            Dim arParams(4) As SqlParameter
            Dim strError As String

            'Create Stored Procedure Parameters
            Dim parameteret_id As New SqlParameter("@et_id", SqlDbType.Int, 4)
            parameteret_id.Value = ET_ID
            arParams(0) = parameteret_id

            Dim parameteretd_id As New SqlParameter("@etd_id", SqlDbType.Int, 4)
            parameteretd_id.Value = ETD_ID
            arParams(1) = parameteretd_id

            Dim parameterTimeType As New SqlParameter("@time_type", SqlDbType.Char, 1)
            parameterTimeType.Value = TimeType
            arParams(2) = parameterTimeType

            Dim parametererror_text As New SqlParameter("@error_text", SqlDbType.VarChar, 254)
            parametererror_text.Direction = ParameterDirection.Output
            arParams(3) = parametererror_text

            Try
                oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_delete", arParams)

                'MyReturn = parametererror_text.Value
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:DeleteTime", Err.Description)
            End Try
            Return MyReturn

        End Function

        'used in old timesheet
        Public Overloads Function DeleteTime(ByVal ThisDay As AdvantageFramework.Timesheet.TimesheetEntry) As String

            If ThisDay.ETID > 0 And ThisDay.ETDTLID > 0 Then
                Dim MyReturn As String = ""
                Dim arParams(4) As SqlParameter
                Dim strError As String

                'Create Stored Procedure Parameters
                Dim parameteret_id As New SqlParameter("@et_id", SqlDbType.Int, 4)
                parameteret_id.Value = ThisDay.ETID
                arParams(0) = parameteret_id

                Dim parameteretd_id As New SqlParameter("@etd_id", SqlDbType.Int, 4)
                parameteretd_id.Value = ThisDay.ETDTLID
                arParams(1) = parameteretd_id

                Dim parameterTimeType As New SqlParameter("@time_type", SqlDbType.Char, 1)
                parameterTimeType.Value = ThisDay.TimeType
                arParams(2) = parameterTimeType

                Dim parametererror_text As New SqlParameter("@error_text", SqlDbType.VarChar, 254)
                parametererror_text.Direction = ParameterDirection.Output
                arParams(3) = parametererror_text

                Try
                    oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_delete", arParams)
                Catch
                    'MyReturn = parametererror_text.Value
                    Err.Raise(Err.Number, "Class:cTimesheet Routine:DeleteTime", Err.Description)
                End Try

                Return MyReturn
            Else
                Return ""
            End If
        End Function

        Public Function DeleteLine(ByVal ThisLine As AdvantageFramework.Timesheet.TimesheetLine) As String
            Dim MyReturn As String
            Dim ThisEditStatus As AdvantageFramework.Timesheet.TimesheetEditType

            ThisEditStatus = CheckEditStatus(ThisLine.Monday.ETID, ThisLine.Monday.ETDTLID)
            If ThisEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                MyReturn = DeleteTime(ThisLine.Monday)
                If MyReturn.Trim.Length > 1 Then
                    Return "Monday: " & MyReturn
                End If
            Else
                Select Case ThisEditStatus
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billing
                        Return "Monday has been selected for Billing"
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billed
                        Return "Monday has been Billed already"
                    Case Else
                        Return "Monday could not be deleted"
                End Select
            End If

            ThisEditStatus = CheckEditStatus(ThisLine.Tuesday.ETID, ThisLine.Tuesday.ETDTLID)
            If ThisEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                MyReturn = DeleteTime(ThisLine.Tuesday)
                If MyReturn.Trim.Length > 1 Then
                    Return "Tuesday: " & MyReturn
                End If
            Else
                Select Case ThisEditStatus
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billing
                        Return "Tuesday has been selected for Billing"
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billed
                        Return "Tuesday has been Billed already"
                    Case Else
                        Return "Tuesday could not be deleted"
                End Select
            End If

            ThisEditStatus = CheckEditStatus(ThisLine.Wednesday.ETID, ThisLine.Wednesday.ETDTLID)
            If ThisEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                MyReturn = DeleteTime(ThisLine.Wednesday)
                If MyReturn.Trim.Length > 1 Then
                    Return "Wednesday: " & MyReturn
                End If
            Else
                Select Case ThisEditStatus
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billing
                        Return "Wednesday has been selected for Billing"
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billed
                        Return "Wednesday has been Billed already"
                    Case Else
                        Return "Wednesday could not be deleted"
                End Select
            End If

            ThisEditStatus = CheckEditStatus(ThisLine.Thursday.ETID, ThisLine.Thursday.ETDTLID)
            If ThisEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                MyReturn = DeleteTime(ThisLine.Thursday)
                If MyReturn.Trim.Length > 1 Then
                    Return "Thursday: " & MyReturn
                End If
            Else
                Select Case ThisEditStatus
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billing
                        Return "Thursday has been selected for Billing"
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billed
                        Return "Thursday has been Billed already"
                    Case Else
                        Return "Thursday could not be deleted"
                End Select
            End If

            ThisEditStatus = CheckEditStatus(ThisLine.Friday.ETID, ThisLine.Friday.ETDTLID)
            If ThisEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                MyReturn = DeleteTime(ThisLine.Friday)
                If MyReturn.Trim.Length > 1 Then
                    Return "Friday: " & MyReturn
                End If
            Else
                Select Case ThisEditStatus
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billing
                        Return "Friday has been selected for Billing"
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billed
                        Return "Friday has been Billed already"
                    Case Else
                        Return "Friday could not be deleted"
                End Select
            End If

            ThisEditStatus = CheckEditStatus(ThisLine.Saturday.ETID, ThisLine.Saturday.ETDTLID)
            If ThisEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                MyReturn = DeleteTime(ThisLine.Saturday)
                If MyReturn.Trim.Length > 1 Then
                    Return "Saturday: " & MyReturn
                End If
            Else
                Select Case ThisEditStatus
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billing
                        Return "Saturday has been selected for Billing"
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billed
                        Return "Saturday has been Billed already"
                    Case Else
                        Return "Saturday could not be deleted"
                End Select
            End If

            ThisEditStatus = CheckEditStatus(ThisLine.Sunday.ETID, ThisLine.Sunday.ETDTLID)
            If ThisEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                MyReturn = DeleteTime(ThisLine.Sunday)
                If MyReturn.Trim.Length > 1 Then
                    Return "Sunday: " & MyReturn
                End If
            Else
                Select Case ThisEditStatus
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billing
                        Return "Sunday has been selected for Billing"
                    Case AdvantageFramework.Timesheet.TimesheetEditType.Billed
                        Return "Sunday has been Billed already"
                    Case Else
                        Return "Sunday could not be deleted"
                End Select
            End If

            Return MyReturn

        End Function

        Public Function PostPeriodClosed(ByVal ThisDate As Date) As Boolean
            Dim IsValid As Boolean = False
            ''Dim SessionKey As String = "PostPeriodClosed" & ThisDate.ToShortDateString()

            ''If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter

            Dim parameterDate As New SqlParameter("@ThisDate", SqlDbType.SmallDateTime, 0)
            parameterDate.Value = ThisDate
            arParams(0) = parameterDate

            Dim parameterReturn As New SqlParameter("@Return", SqlDbType.Int, 4)
            parameterReturn.Direction = ParameterDirection.Output
            arParams(1) = parameterReturn

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_ts_check_postperiod", arParams)
            Catch
                IsValid = False
            End Try

            If parameterReturn.Value = 0 Then
                IsValid = True
            Else
                IsValid = False
            End If
            ''    HttpContext.Current.Session(SessionKey) = IsValid
            ''Else
            ''    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            ''End If

            Return IsValid

        End Function

        Public Function UserLimited(ByVal UserCode As String) As Boolean
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "UserLimited" & UserCode

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    ' Create Instance of Connection and Command Object
                    Dim myReturn As String = ""
                    Dim parameterUser As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
                    parameterUser.Value = UserCode
                    Try
                        myReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_check_emp", parameterUser).ToString
                    Catch
                        myReturn = ""
                    End Try
                    If myReturn.ToUpper().Trim() = "Y" Then
                        IsValid = True
                    Else
                        IsValid = False
                    End If
                Catch ex As Exception
                    IsValid = False
                End Try
                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End Function

        Public Overloads Function CheckEditStatus(ByVal ETID As Integer, ByVal ETDLTID As Integer) As AdvantageFramework.Timesheet.TimesheetEditType

            If ETID = 0 Or ETDLTID = 0 Then Return AdvantageFramework.Timesheet.TimesheetEditType.Edit

            Dim ReturnInteger As Integer = 0
            ''Dim SessionKey As String = "CheckEditStatus" & ETID.ToString() & ETDLTID.ToString()
            ''If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter

            Dim parameterETID As New SqlParameter("@ETID", SqlDbType.Int, 0)
            parameterETID.Value = ETID
            arParams(0) = parameterETID

            Dim parameterETDLTID As New SqlParameter("@ETDTLID", SqlDbType.Int, 0)
            parameterETDLTID.Value = ETDLTID
            arParams(1) = parameterETDLTID

            Try
                ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_Check_Edit_Status", arParams)
            Catch
                ReturnInteger = 0
            End Try

            ''    HttpContext.Current.Session(SessionKey) = ReturnInteger
            ''Else
            ''    ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
            ''End If

            Return CType(ReturnInteger, AdvantageFramework.Timesheet.TimesheetEditType)

        End Function
        Public Overloads Function CheckEditStatus(ByVal EmpCode As String, ByVal EmpDate As Date) As AdvantageFramework.Timesheet.TimesheetEditType
            Dim ReturnInteger As Integer = 0
            ''Dim SessionKey As String = "CheckEditStatus" & EmpCode.ToString() & EmpDate.ToShortDateString()
            ''If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter

            Dim parameterETID As New SqlParameter("@ETID", SqlDbType.Int, 0)
            parameterETID.Value = Me.GetETID(EmpCode, EmpDate)
            arParams(0) = parameterETID

            Dim parameterETDLTID As New SqlParameter("@ETDTLID", SqlDbType.Int, 0)
            parameterETDLTID.Value = 0
            arParams(1) = parameterETDLTID

            Try
                ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_Check_Edit_Status", arParams)
            Catch
                ReturnInteger = 0
            End Try

            ''    HttpContext.Current.Session(SessionKey) = ReturnInteger
            ''Else
            ''    ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
            ''End If

            Return CType(ReturnInteger, AdvantageFramework.Timesheet.TimesheetEditType)

        End Function

        Public Function GetEditType(ByVal EmpCode As String, ByVal EmpDate As Date) As AdvantageFramework.Timesheet.TimesheetEditType
            Dim ReturnString As String = ""
            ''Dim SessionKey As String = "SetSubmitLabel" & EmpCode & EmpDate.ToShortDateString()

            ''If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter

            Dim parameterEmpCode As New SqlParameter("@Empcode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(0) = parameterEmpCode

            Dim parameterEmpDate As New SqlParameter("@EmpDate", SqlDbType.SmallDateTime, 0)
            parameterEmpDate.Value = EmpDate
            arParams(1) = parameterEmpDate

            Try
                ReturnString = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_SetSubmitLabel", arParams)
            Catch
                ReturnString = ""
            End Try

            ''    HttpContext.Current.Session(SessionKey) = ReturnString
            ''Else
            ''    ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            ''End If

            Select Case ReturnString
                Case "0"
                    Return AdvantageFramework.Timesheet.TimesheetEditType.Edit
                Case "5"
                    Return AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval
                Case "6"
                    Return AdvantageFramework.Timesheet.TimesheetEditType.Approved
                Case "7"
                    Return AdvantageFramework.Timesheet.TimesheetEditType.Denied
                Case Else
                    Return AdvantageFramework.Timesheet.TimesheetEditType.Edit
            End Select

        End Function

        Public Function CheckApprovalStatus(ByVal EmpCode As String, ByVal EmpDate As Date) As Boolean
            Dim IsValid As Boolean = False
            ''Dim SessionKey As String = "CheckApprovalStatus" & EmpCode & EmpDate.ToShortDateString()

            ''If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try

                Dim arParams(2) As SqlParameter
                Dim myReturn As Integer

                Dim parameterEmpCode As New SqlParameter("@Empcode", SqlDbType.VarChar, 6)
                parameterEmpCode.Value = EmpCode
                arParams(0) = parameterEmpCode

                Dim parameterEmpDate As New SqlParameter("@EmpDate", SqlDbType.SmallDateTime, 0)
                parameterEmpDate.Value = EmpDate
                arParams(1) = parameterEmpDate

                Try
                    myReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_CheckApproval", arParams)
                Catch
                    myReturn = 0
                End Try

                If myReturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

            Catch ex As Exception

                IsValid = False

            End Try
            ''    HttpContext.Current.Session(SessionKey) = IsValid
            ''Else
            ''    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            ''End If

            Return IsValid

        End Function

        Public Function SubmitForApproval(ByVal EmpCode As String, ByVal ThisDate As Date, ByVal Submit As Boolean) As Boolean
            'Dim m As New AdvantageFramework.Timesheet.Methods(Me.mConnString, HttpContext.Current.Session("UserCode"))
            AdvantageFramework.Timesheet.DeleteZeroHours(HttpContext.Current.Session("ConnString"), EmpCode, ThisDate)

            Dim arParams(3) As SqlParameter
            Dim myReturn As Integer
            'Dim AdvantageFramework.Timesheet.TimesheetDays As Integer

            Dim parameter1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameter1.Value = EmpCode
            arParams(0) = parameter1

            Dim parameter2 As New SqlParameter("@EmpDate", SqlDbType.SmallDateTime, 0)
            parameter2.Value = ThisDate.ToShortDateString
            arParams(1) = parameter2

            Dim parameter3 As New SqlParameter("@Approve", SqlDbType.Int, 0)
            If Submit = True Then
                parameter3.Value = 1
            Else
                parameter3.Value = 0
            End If
            arParams(2) = parameter3

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_ts_submit_approval", arParams)
                Try
                    Dim SessionKeySuffix As String = EmpCode & ThisDate.ToShortDateString()
                    HttpContext.Current.Session("SetSubmitLabel" & SessionKeySuffix) = Nothing
                    HttpContext.Current.Session("CheckApprovalStatus" & SessionKeySuffix) = Nothing
                Catch ex As Exception
                End Try


                Return True

            Catch

                Return False

            End Try
        End Function

        Public Function IsApprovalActive(ByVal EmpCode As String) As Boolean

            Dim IsValid As Boolean = False
            Dim SessionKey As String = "IsApprovalActive" & EmpCode

            If HttpContext.Current.Session(SessionKey) Is Nothing Then

                Try

                    Dim m As New AdvantageFramework.Timesheet.TimesheetSettings(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                    IsValid = m.IsApprovalActive(EmpCode)

                Catch ex As Exception

                    IsValid = False

                End Try

                HttpContext.Current.Session(SessionKey) = IsValid

            Else

                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

            End If

            Return IsValid

        End Function

        Public Function GetTasksForSelection(ByVal UserID As String, ByVal EmpCode As String) As SqlDataReader
            Dim arParams(2) As SqlParameter

            'Create Stored Procedure Parameters
            Dim parameteruser As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameteruser.Value = UserID
            arParams(0) = parameteruser

            Dim parameteremp_code As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameteremp_code.Value = EmpCode
            arParams(1) = parameteremp_code

            Try
                Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_ts_select_tasks", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetThisTimeSheet", Err.Description)
            Finally

            End Try
        End Function

        Public Function GetETID(ByVal EmpCode As String, ByVal EmpDate As Date) As Integer
            'Dim SessionKey As String = "GetETID" & EmpCode & EmpDate.ToShortDateString()
            Dim ReturnInteger As Integer = 0
            'If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                ' Create Instance of Connection and Command Object
                Dim arParams(2) As SqlParameter

                Dim parameterEmpCode As New SqlParameter("@Empcode", SqlDbType.VarChar, 6)
                parameterEmpCode.Value = EmpCode
                arParams(0) = parameterEmpCode

                Dim parameterEmpDate As New SqlParameter("@EmpDate", SqlDbType.SmallDateTime, 0)
                parameterEmpDate.Value = EmpDate
                arParams(1) = parameterEmpDate

                Try
                    ReturnInteger = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_GetETID", arParams)
                Catch
                    ReturnInteger = 0
                End Try

            Catch ex As Exception
                ReturnInteger = 0
            End Try
            '    HttpContext.Current.Session(SessionKey) = ReturnInteger
            'Else
            '    ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
            'End If

            Return ReturnInteger

        End Function

        Public Function GetJobInfo(ByVal JobNo As Integer,
                                             Optional ByRef JobDesc As String = "",
                                             Optional ByRef OfficeCode As String = "",
                                             Optional ByRef ClCode As String = "",
                                             Optional ByRef DivCode As String = "",
                                             Optional ByRef PrdCode As String = "",
                                             Optional ByRef OfficeName As String = "",
                                             Optional ByRef ClDesc As String = "",
                                             Optional ByRef DivDesc As String = "",
                                             Optional ByRef PrdDesc As String = "",
                                             Optional ByRef ScCode As String = "",
                                             Optional ByRef ScDesc As String = "",
                                             Optional ByRef CmpCode As String = "",
                                             Optional ByRef CmpIdentifier As String = ""
                                         ) As Boolean

            Dim HasData As Boolean = False
            Dim SessionKey As String = "GetJobInfo" & JobNo.ToString().PadLeft(6, "0")

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim parameterJobNo As New SqlParameter("@JobNo", SqlDbType.Int, 0)
                    parameterJobNo.Value = JobNo
                    Dim dt As New DataTable
                    dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ts_popup_get_info", "dtdata", parameterJobNo)
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        Try
                            If IsDBNull(dt.Rows(0)("job_descript")) = False Then
                                JobDesc = dt.Rows(0)("job_descript").ToString()
                            Else
                                JobDesc = ""
                            End If
                        Catch ex As Exception
                            JobDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("office")) = False Then
                                OfficeCode = dt.Rows(0)("office").ToString()
                            Else
                                OfficeCode = ""
                            End If
                        Catch ex As Exception
                            OfficeCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("office_descript")) = False Then
                                OfficeName = dt.Rows(0)("office_descript").ToString()
                            Else
                                OfficeName = ""
                            End If
                        Catch ex As Exception
                            OfficeName = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("client")) = False Then
                                ClCode = dt.Rows(0)("client").ToString()
                            Else
                                ClCode = ""
                            End If
                        Catch ex As Exception
                            ClCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("division")) = False Then
                                DivCode = dt.Rows(0)("division").ToString()
                            Else
                                DivCode = ""
                            End If
                        Catch ex As Exception
                            DivCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("product")) = False Then
                                PrdCode = dt.Rows(0)("product").ToString()
                            Else
                                PrdCode = ""
                            End If
                        Catch ex As Exception
                            PrdCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("client_descript")) = False Then
                                ClDesc = dt.Rows(0)("client_descript").ToString()
                            Else
                                ClDesc = ""
                            End If
                        Catch ex As Exception
                            ClDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("division_descript")) = False Then
                                DivDesc = dt.Rows(0)("division_descript").ToString()
                            Else
                                DivDesc = ""
                            End If
                        Catch ex As Exception
                            DivDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("product_descript")) = False Then
                                PrdDesc = dt.Rows(0)("product_descript").ToString()
                            Else
                                PrdDesc = ""
                            End If
                        Catch ex As Exception
                            PrdDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("SC_CODE")) = False Then
                                ScCode = dt.Rows(0)("SC_CODE").ToString()
                            Else
                                ScCode = ""
                            End If
                        Catch ex As Exception
                            ScCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("SC_DESCRIPTION")) = False Then
                                ScDesc = dt.Rows(0)("SC_DESCRIPTION").ToString()
                            Else
                                ScDesc = ""
                            End If
                        Catch ex As Exception
                            ScDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                                CmpCode = dt.Rows(0)("CMP_CODE").ToString()
                            Else
                                CmpCode = ""
                            End If
                        Catch ex As Exception
                            CmpCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CMP_IDENTIFIER")) = False Then
                                CmpIdentifier = CType(dt.Rows(0)("CMP_IDENTIFIER"), Integer)
                            Else
                                CmpIdentifier = 0
                            End If
                        Catch ex As Exception
                            CmpIdentifier = 0
                        End Try

                        HasData = True

                    End If
                    Try
                        If Not dt Is Nothing Then
                            dt.Dispose()
                            dt = Nothing
                        End If
                    Catch ex As Exception
                    End Try
                Catch
                    HasData = False
                End Try

                HttpContext.Current.Session(SessionKey & "JobDesc") = JobDesc
                HttpContext.Current.Session(SessionKey & "OfficeCode") = OfficeCode
                HttpContext.Current.Session(SessionKey & "OfficeName") = OfficeName
                HttpContext.Current.Session(SessionKey & "ClCode") = ClCode
                HttpContext.Current.Session(SessionKey & "DivCode") = DivCode
                HttpContext.Current.Session(SessionKey & "PrdCode") = PrdCode
                HttpContext.Current.Session(SessionKey & "ClDesc") = ClDesc
                HttpContext.Current.Session(SessionKey & "DivDesc") = DivDesc
                HttpContext.Current.Session(SessionKey & "PrdDesc") = PrdDesc
                HttpContext.Current.Session(SessionKey & "ScCode") = ScCode
                HttpContext.Current.Session(SessionKey & "ScDesc") = ScDesc
                HttpContext.Current.Session(SessionKey & "CmpCode") = CmpCode
                If IsNumeric(CmpIdentifier) = True Then
                    HttpContext.Current.Session(SessionKey & "CmpIdentifier") = CmpIdentifier
                Else
                    HttpContext.Current.Session(SessionKey & "CmpIdentifier") = "0"
                End If
                HttpContext.Current.Session(SessionKey & "CmpIdentifier") = CmpIdentifier
                HttpContext.Current.Session(SessionKey & "HasData") = HasData
                HttpContext.Current.Session(SessionKey) = True

            Else

                JobDesc = HttpContext.Current.Session(SessionKey & "JobDesc")
                OfficeCode = HttpContext.Current.Session(SessionKey & "OfficeCode")
                OfficeName = HttpContext.Current.Session(SessionKey & "OfficeName")
                ClCode = HttpContext.Current.Session(SessionKey & "ClCode")
                DivCode = HttpContext.Current.Session(SessionKey & "DivCode")
                PrdCode = HttpContext.Current.Session(SessionKey & "PrdCode")
                ClDesc = HttpContext.Current.Session(SessionKey & "ClDesc")
                DivDesc = HttpContext.Current.Session(SessionKey & "DivDesc")
                PrdDesc = HttpContext.Current.Session(SessionKey & "PrdDesc")
                ScCode = HttpContext.Current.Session(SessionKey & "ScCode")
                ScDesc = HttpContext.Current.Session(SessionKey & "ScDesc")
                CmpCode = HttpContext.Current.Session(SessionKey & "CmpCode")
                Try
                    If IsNumeric(CmpIdentifier) = True Then
                        CmpIdentifier = CType(HttpContext.Current.Session(SessionKey & "CmpIdentifier"), Integer).ToString()
                    Else
                        CmpIdentifier = "0"
                    End If
                Catch ex As Exception
                    CmpIdentifier = "0"
                End Try
                HasData = CType(HttpContext.Current.Session(SessionKey & "HasData"), Boolean)

            End If

            Return HasData

        End Function

        Public Function GetJobComponentInfo(ByVal JobNo As Integer, ByVal JobCompNo As Integer,
                                             Optional ByRef JobDesc As String = "",
                                             Optional ByRef JobCompDesc As String = "",
                                             Optional ByRef OfficeCode As String = "",
                                             Optional ByRef ClCode As String = "",
                                             Optional ByRef DivCode As String = "",
                                             Optional ByRef PrdCode As String = "",
                                             Optional ByRef OfficeName As String = "",
                                             Optional ByRef ClDesc As String = "",
                                             Optional ByRef DivDesc As String = "",
                                             Optional ByRef PrdDesc As String = "",
                                             Optional ByRef ScCode As String = "",
                                             Optional ByRef CmpCode As String = "",
                                             Optional ByRef CmpIdentifier As String = "",
                                             Optional ByRef CdpContactId As String = "",
                                             Optional ByRef PrdContCode As String = "",
                                             Optional ByRef ContFML As String = "",
                                             Optional ByRef NextAlertSeqNbr As String = "",
                                             Optional ByRef JobComponentEmpCode As String = ""
                                        ) As Boolean

            If JobNo = 0 Or JobCompNo = 0 Then Exit Function

            Dim HasData As Boolean = False
            Dim SessionKey As String = "GetJobComponentInfo" & JobNo.ToString().PadLeft(6, "0") & JobCompNo.ToString.PadLeft(2, "0")
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim ar(2) As SqlParameter
                    Dim pJ As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                    pJ.Value = JobNo
                    ar(0) = pJ
                    Dim pJC As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                    pJC.Value = JobCompNo
                    ar(1) = pJC

                    Dim dt As New DataTable
                    dt = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_dd_popup_get_info_from_jc", "dtInfo", ar)

                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        Try
                            If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                                JobDesc = dt.Rows(0)("JOB_DESC").ToString()
                            Else
                                JobDesc = ""
                            End If
                        Catch ex As Exception
                            JobDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                                JobCompDesc = dt.Rows(0)("JOB_COMP_DESC").ToString()
                            Else
                                JobCompDesc = ""
                            End If
                        Catch ex As Exception
                            JobCompDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("OFFICE_CODE")) = False Then
                                OfficeCode = dt.Rows(0)("OFFICE_CODE").ToString()
                            Else
                                OfficeCode = ""
                            End If
                        Catch ex As Exception
                            OfficeCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("OFFICE_NAME")) = False Then
                                OfficeName = dt.Rows(0)("OFFICE_NAME").ToString()
                            Else
                                OfficeName = ""
                            End If
                        Catch ex As Exception
                            OfficeName = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                                ClCode = dt.Rows(0)("CL_CODE").ToString()
                            Else
                                ClCode = ""
                            End If
                        Catch ex As Exception
                            ClCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                                DivCode = dt.Rows(0)("DIV_CODE").ToString()
                            Else
                                DivCode = ""
                            End If
                        Catch ex As Exception
                            DivCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                                PrdCode = dt.Rows(0)("PRD_CODE").ToString()
                            Else
                                PrdCode = ""
                            End If
                        Catch ex As Exception
                            PrdCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                                ClDesc = dt.Rows(0)("CL_NAME").ToString()
                            Else
                                ClDesc = ""
                            End If
                        Catch ex As Exception
                            ClDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                                DivDesc = dt.Rows(0)("DIV_NAME").ToString()
                            Else
                                DivDesc = ""
                            End If
                        Catch ex As Exception
                            DivDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                                PrdDesc = dt.Rows(0)("PRD_DESCRIPTION").ToString()
                            Else
                                PrdDesc = ""
                            End If
                        Catch ex As Exception
                            PrdDesc = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("SC_CODE")) = False Then
                                ScCode = dt.Rows(0)("SC_CODE").ToString()
                            Else
                                ScCode = ""
                            End If
                        Catch ex As Exception
                            ScCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                                CmpCode = dt.Rows(0)("CMP_CODE").ToString()
                            Else
                                CmpCode = ""
                            End If
                        Catch ex As Exception
                            CmpCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CMP_IDENTIFIER")) = False Then
                                CmpIdentifier = CType(dt.Rows(0)("CMP_IDENTIFIER"), Integer)
                            Else
                                CmpIdentifier = 0
                            End If
                        Catch ex As Exception
                            CmpIdentifier = 0
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CDP_CONTACT_ID")) = False Then
                                CdpContactId = dt.Rows(0)("CDP_CONTACT_ID").ToString()
                            Else
                                CdpContactId = ""
                            End If
                        Catch ex As Exception
                            CdpContactId = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("PRD_CONT_CODE")) = False Then
                                PrdContCode = dt.Rows(0)("PRD_CONT_CODE").ToString()
                            Else
                                PrdContCode = ""
                            End If
                        Catch ex As Exception
                            PrdContCode = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("CONT_FML")) = False Then
                                ContFML = dt.Rows(0)("CONT_FML").ToString()
                            Else
                                ContFML = ""
                            End If
                        Catch ex As Exception
                            ContFML = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("NEXT_ALERT_SEQ_NBR")) = False Then
                                NextAlertSeqNbr = dt.Rows(0)("NEXT_ALERT_SEQ_NBR").ToString()
                            Else
                                NextAlertSeqNbr = ""
                            End If
                        Catch ex As Exception
                            NextAlertSeqNbr = ""
                        End Try
                        Try
                            If IsDBNull(dt.Rows(0)("EMP_CODE")) = False Then
                                JobComponentEmpCode = dt.Rows(0)("EMP_CODE").ToString()
                            Else
                                JobComponentEmpCode = ""
                            End If
                        Catch ex As Exception
                            JobComponentEmpCode = ""
                        End Try

                        HasData = True

                    End If
                    Try
                        If Not dt Is Nothing Then
                            dt.Dispose()
                            dt = Nothing
                        End If
                    Catch ex As Exception
                    End Try
                Catch ex As Exception
                    HasData = False
                End Try

                HttpContext.Current.Session(SessionKey & "JobDesc") = JobDesc
                HttpContext.Current.Session(SessionKey & "JobCompDesc") = JobCompDesc
                HttpContext.Current.Session(SessionKey & "OfficeCode") = OfficeCode
                HttpContext.Current.Session(SessionKey & "OfficeName") = OfficeName
                HttpContext.Current.Session(SessionKey & "ClCode") = ClCode
                HttpContext.Current.Session(SessionKey & "DivCode") = DivCode
                HttpContext.Current.Session(SessionKey & "PrdCode") = PrdCode
                HttpContext.Current.Session(SessionKey & "ClDesc") = ClDesc
                HttpContext.Current.Session(SessionKey & "DivDesc") = DivDesc
                HttpContext.Current.Session(SessionKey & "PrdDesc") = PrdDesc
                HttpContext.Current.Session(SessionKey & "ScCode") = ScCode
                HttpContext.Current.Session(SessionKey & "CmpCode") = CmpCode
                If IsNumeric(CmpIdentifier) = True Then
                    HttpContext.Current.Session(SessionKey & "CmpIdentifier") = CmpIdentifier
                Else
                    HttpContext.Current.Session(SessionKey & "CmpIdentifier") = "0"
                End If

                HttpContext.Current.Session(SessionKey & "CdpContactId") = CdpContactId
                HttpContext.Current.Session(SessionKey & "PrdContCode") = PrdContCode
                HttpContext.Current.Session(SessionKey & "ContFML") = ContFML
                HttpContext.Current.Session(SessionKey & "NextAlertSeqNbr") = NextAlertSeqNbr
                HttpContext.Current.Session(SessionKey & "JobComponentEmpCode") = JobComponentEmpCode

                HttpContext.Current.Session(SessionKey & "HasData") = HasData
                HttpContext.Current.Session(SessionKey) = True

            Else

                JobDesc = HttpContext.Current.Session(SessionKey & "JobDesc")
                JobCompDesc = HttpContext.Current.Session(SessionKey & "JobCompDesc")
                OfficeCode = HttpContext.Current.Session(SessionKey & "OfficeCode")
                OfficeName = HttpContext.Current.Session(SessionKey & "OfficeName")
                ClCode = HttpContext.Current.Session(SessionKey & "ClCode")
                DivCode = HttpContext.Current.Session(SessionKey & "DivCode")
                PrdCode = HttpContext.Current.Session(SessionKey & "PrdCode")
                ClDesc = HttpContext.Current.Session(SessionKey & "ClDesc")
                DivDesc = HttpContext.Current.Session(SessionKey & "DivDesc")
                PrdDesc = HttpContext.Current.Session(SessionKey & "PrdDesc")
                ScCode = HttpContext.Current.Session(SessionKey & "ScCode")
                CmpCode = HttpContext.Current.Session(SessionKey & "CmpCode")
                Try
                    If IsNumeric(CmpIdentifier) = True Then
                        CmpIdentifier = CType(HttpContext.Current.Session(SessionKey & "CmpIdentifier"), Integer).ToString()
                    Else
                        CmpIdentifier = "0"
                    End If
                Catch ex As Exception
                    CmpIdentifier = "0"
                End Try
                CdpContactId = HttpContext.Current.Session(SessionKey & "CdpContactId")
                PrdContCode = HttpContext.Current.Session(SessionKey & "PrdContCode")
                ContFML = HttpContext.Current.Session(SessionKey & "ContFML")
                NextAlertSeqNbr = HttpContext.Current.Session(SessionKey & "NextAlertSeqNbr")
                JobComponentEmpCode = HttpContext.Current.Session(SessionKey & "JobComponentEmpCode")
                Try

                    HasData = CType(HttpContext.Current.Session(SessionKey & "HasData"), Boolean)

                Catch ex As Exception

                    HasData = False

                End Try

            End If

            Return HasData

        End Function

        Public Function IsAsp() As Boolean

            Dim SessionKey As String = "IsAsp"
            Dim YesItIs As Boolean = False

            If HttpContext.Current.Session(SessionKey) Is Nothing Then

                Try

                    If SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, "SELECT ISNULL(ASP_ACTIVE, 0) FROM AGENCY WITH(NOLOCK);") = "1" Then

                        YesItIs = True

                    End If

                Catch ex As Exception
                End Try

                HttpContext.Current.Session(SessionKey) = YesItIs

            Else

                YesItIs = HttpContext.Current.Session(SessionKey)

            End If

            YesItIs = True
            Return YesItIs

        End Function
        Public Function GetOfficeCodeFromProduct(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As String
            Try
                Dim SessionKey As String = "GetOfficeCodeFromCDP" & ClientCode & DivisionCode & ProductCode
                Dim ReturnString As String = ""
                If HttpContext.Current.Session(SessionKey) Is Nothing Then
                    Try
                        ReturnString = SqlHelper.ExecuteScalar(Me.mConnString, CommandType.Text, "SELECT OFFICE_CODE FROM PRODUCT WITH(NOLOCK) WHERE CL_CODE = '" &
                                                               ClientCode.Trim() & "' AND DIV_CODE = '" & DivisionCode.Trim() & "' AND PRD_CODE = '" & ProductCode.Trim() & "';")
                    Catch ex As Exception
                        ReturnString = ""
                    End Try
                    HttpContext.Current.Session(SessionKey) = ReturnString
                Else
                    ReturnString = HttpContext.Current.Session(SessionKey).ToString()
                End If
                Return ReturnString
            Catch ex As Exception
                Return ""
            End Try
        End Function

        Public Function GetDefaultFunction(ByVal EmpCode As String) As String
            Dim SessionKey As String = "GetDefaultFunction" & EmpCode
            Dim ReturnString As String = ""
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim arParams(2) As SqlParameter
                    Dim myReturn As Integer

                    Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                    parameterEC.Value = EmpCode
                    arParams(0) = parameterEC

                    Dim parameterFunction As New SqlParameter("@Function", SqlDbType.VarChar, 100)
                    parameterFunction.Direction = ParameterDirection.Output
                    arParams(1) = parameterFunction

                    Try
                        oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_ts_get_default_function", arParams)
                    Catch
                        ReturnString = ""
                    End Try

                    ReturnString = parameterFunction.Value.ToString

                Catch ex As Exception
                    ReturnString = ""
                End Try
                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

            Return ReturnString
        End Function

        Public Function GetQuoteVsActualDD(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal functioncode As String, ByVal empcode As String, ByVal emponly As Boolean, ByVal view As Integer)
            Dim dr As SqlDataReader
            Dim arParams(5) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterFunctionCode As New SqlParameter("@FunctionCode", SqlDbType.VarChar, 6)
            parameterFunctionCode.Value = functioncode
            arParams(2) = parameterFunctionCode
            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = empcode
            arParams(3) = parameterEmpCode
            Dim parameterEmpOnly As New SqlParameter("@EmpOnly", SqlDbType.Bit, 1)
            If emponly = True Then
                parameterEmpOnly.Value = 1
            Else
                parameterEmpOnly.Value = 0
            End If
            arParams(4) = parameterEmpOnly

            Dim parameterView As New SqlParameter("@View", SqlDbType.Int)
            parameterView.Value = view
            arParams(5) = parameterView

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_ts_ddQuoteVsActual", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvA", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function GetQuoteVsActualDDdt(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal functioncode As String, ByVal empcode As String, ByVal emponly As Boolean, ByVal view As Integer)
            Dim dr As DataTable
            Dim arParams(5) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterFunctionCode As New SqlParameter("@FunctionCode", SqlDbType.VarChar, 6)
            parameterFunctionCode.Value = functioncode
            arParams(2) = parameterFunctionCode
            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = empcode
            arParams(3) = parameterEmpCode
            Dim parameterEmpOnly As New SqlParameter("@EmpOnly", SqlDbType.Bit, 1)
            If emponly = True Then
                parameterEmpOnly.Value = 1
            Else
                parameterEmpOnly.Value = 0
            End If
            arParams(4) = parameterEmpOnly

            Dim parameterView As New SqlParameter("@View", SqlDbType.Int)
            parameterView.Value = view
            arParams(5) = parameterView

            Try
                dr = oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ts_ddQuoteVsActual", "test", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvA", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function GetEstimateData(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal functioncode As String, ByVal empcode As String, ByVal emponly As Boolean)
            Dim dr As SqlDataReader
            Dim arParams(5) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterFunctionCode As New SqlParameter("@FunctionCode", SqlDbType.VarChar, 6)
            parameterFunctionCode.Value = functioncode
            arParams(2) = parameterFunctionCode
            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = empcode
            arParams(3) = parameterEmpCode
            Dim parameterEmpOnly As New SqlParameter("@EmpOnly", SqlDbType.Bit, 1)
            If emponly = True Then
                parameterEmpOnly.Value = 1
            Else
                parameterEmpOnly.Value = 0
            End If
            arParams(4) = parameterEmpOnly

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_ts_ddEstimate", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetEstimate", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function GetTrafficHours(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal functioncode As String, ByVal empcode As String, ByVal emponly As Boolean, Optional ByVal alertid As Integer = 0)
            Dim dr As SqlDataReader
            Dim arParams(6) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNumber", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobCompNumber", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterFunctionCode As New SqlParameter("@FunctionCode", SqlDbType.VarChar, 6)
            parameterFunctionCode.Value = functioncode
            arParams(2) = parameterFunctionCode
            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = empcode
            arParams(3) = parameterEmpCode
            Dim parameterEmpOnly As New SqlParameter("@EmpOnly", SqlDbType.Bit, 1)
            If emponly = True Then
                parameterEmpOnly.Value = 1
            Else
                parameterEmpOnly.Value = 0
            End If
            arParams(4) = parameterEmpOnly
            Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int, 0)
            parameterAlertID.Value = alertid
            arParams(5) = parameterAlertID

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_ts_ddTrafficHours", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetTrafficHours", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function GetQuoteVsActualSummary(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal usercode As String, ByVal group As String) As DataTable
            Dim arParams(5) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNum", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(2) = parameterUserCode
            Dim parameterEmps As New SqlParameter("@Emps", SqlDbType.VarChar, 2000)
            parameterEmps.Value = ""
            arParams(3) = parameterEmps
            Dim parameterDisplay As New SqlParameter("@Display", SqlDbType.VarChar, 20)
            parameterDisplay.Value = group
            arParams(4) = parameterDisplay

            Try

                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_qva_summary", "QvAData", arParams)

            Catch

                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvASummary", Err.Description)

            Finally

            End Try

        End Function

        Public Function GetQuoteVsActualSummaryDS(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal usercode As String, ByVal group As String) As DataSet
            Dim arParams(5) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNum", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(2) = parameterUserCode
            Dim parameterEmps As New SqlParameter("@Emps", SqlDbType.VarChar, 2000)
            parameterEmps.Value = ""
            arParams(3) = parameterEmps
            Dim parameterDisplay As New SqlParameter("@Display", SqlDbType.VarChar, 20)
            parameterDisplay.Value = group
            arParams(4) = parameterDisplay

            Try

                Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_qva_summary", arParams)

            Catch

                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvASummary", Err.Description)

            Finally

            End Try

        End Function

        Public Function GetQuoteVsActualSummaryJobDS(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal usercode As String, ByVal group As String) As DataSet
            Dim arParams(5) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNum", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(2) = parameterUserCode
            Dim parameterEmps As New SqlParameter("@Emps", SqlDbType.VarChar, 2000)
            parameterEmps.Value = ""
            arParams(3) = parameterEmps
            Dim parameterDisplay As New SqlParameter("@Display", SqlDbType.VarChar, 20)
            parameterDisplay.Value = group
            arParams(4) = parameterDisplay

            Try

                Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_qva_summary_job", arParams)

            Catch

                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvASummaryJob", Err.Description)

            Finally

            End Try

        End Function

        Public Function GetQuoteVsActualSummaryCampaignDS(ByVal CampaignID As Integer, ByVal usercode As String, ByVal group As String, ByVal grouptype As String, ByVal DesktopObject As String) As DataSet
            Dim arParams(6) As SqlParameter

            'Create Stored Procedure Parameters
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(0) = parameterUserCode
            Dim parameterCampaignID As New SqlParameter("@CampaignID", SqlDbType.Int, 0)
            parameterCampaignID.Value = CampaignID
            arParams(1) = parameterCampaignID
            Dim parameterGroupType As New SqlParameter("@grouptype", SqlDbType.VarChar, 20)
            parameterGroupType.Value = grouptype
            arParams(2) = parameterGroupType
            Dim parameterDisplay As New SqlParameter("@Display", SqlDbType.VarChar, 20)
            parameterDisplay.Value = group
            arParams(3) = parameterDisplay
            Dim parameterDesktopObject As New SqlParameter("@DesktopObject", SqlDbType.VarChar, 10)
            parameterDesktopObject.Value = DesktopObject
            arParams(4) = parameterDesktopObject

            Try

                Return oSQL.ExecuteDataset(mConnString, CommandType.StoredProcedure, "usp_wv_qva_summary_campaign", arParams)

            Catch

                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvASummaryJob", Err.Description)

            Finally

            End Try

        End Function

        Public Function GetQuoteVsActualSummaryJobHistory(ByVal jobnum As Integer, ByVal jobcompnum As Integer, ByVal usercode As String,
                                                          ByVal jobtype As String, ByVal fromdate As String, ByVal todate As String,
                                                          ByVal client As String, ByVal division As String, ByVal product As String,
                                                          ByVal closed As Integer, ByVal jobs As String, ByVal comps As String, ByVal count As Integer)
            Dim dr As SqlDataReader
            Dim arParams(14) As SqlParameter

            'Create Stored Procedure Parameters           
            Dim parameterJobNumber As New SqlParameter("@JobNum", SqlDbType.Int, 0)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.Int, 0)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(2) = parameterUserCode
            Dim parameterEmps As New SqlParameter("@Emps", SqlDbType.VarChar, 2000)
            parameterEmps.Value = ""
            arParams(3) = parameterEmps
            Dim parameterJobType As New SqlParameter("@JobType", SqlDbType.VarChar, 10)
            parameterJobType.Value = jobtype
            arParams(4) = parameterJobType
            Dim parameterFromDate As New SqlParameter("@FromDate", SqlDbType.VarChar, 12)
            parameterFromDate.Value = fromdate
            arParams(5) = parameterFromDate
            Dim parameterToDate As New SqlParameter("@ToDate", SqlDbType.VarChar, 12)
            parameterToDate.Value = todate
            arParams(6) = parameterToDate
            Dim paramClient As New SqlParameter("@Client", SqlDbType.VarChar)
            paramClient.Value = client
            arParams(7) = paramClient
            Dim paramDivision As New SqlParameter("@Division", SqlDbType.VarChar)
            paramDivision.Value = division
            arParams(8) = paramDivision
            Dim paramProduct As New SqlParameter("@Product", SqlDbType.VarChar)
            paramProduct.Value = product
            arParams(9) = paramProduct
            Dim paramClosed As New SqlParameter("@Closed", SqlDbType.Int)
            If closed = True Then
                paramClosed.Value = 1
            Else
                paramClosed.Value = 0
            End If
            arParams(10) = paramClosed
            Dim paramjobs As New SqlParameter("@jobs", SqlDbType.VarChar)
            paramjobs.Value = jobs
            arParams(11) = paramjobs
            Dim paramcomps As New SqlParameter("@comps", SqlDbType.VarChar)
            paramcomps.Value = comps
            arParams(12) = paramcomps
            Dim parameterJobCount As New SqlParameter("@JobCount", SqlDbType.Int, 0)
            If count = 0 Then
                parameterJobCount.Value = 1
            Else
                parameterJobCount.Value = count
            End If
            arParams(13) = parameterJobCount

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_qva_summary_jobhistory", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvASummaryJH", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        'use AdvantageFramework.ProjectManagement.GetQvABilling(DbContext, Me.JobNum, Me.JobCompNum, Request.QueryString("group"))
        'Public Function GetQvABilling(ByVal jobnum As String, ByVal jobcompnum As String, ByVal group As String)
        '    Dim dr As SqlDataReader
        '    Dim arParams(3) As SqlParameter

        '    Dim parameterJobNumber As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
        '    parameterJobNumber.Value = jobnum
        '    arParams(0) = parameterJobNumber
        '    Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
        '    parameterJobCompNumber.Value = jobcompnum
        '    arParams(1) = parameterJobCompNumber
        '    Dim parameterGroup As New SqlParameter("@Group", SqlDbType.VarChar, 6)
        '    parameterGroup.Value = group
        '    arParams(2) = parameterGroup

        '    Try
        '        dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getQvABillingSummary", arParams)
        '    Catch
        '        Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvABilling", Err.Description)
        '    Finally

        '    End Try

        '    Return dr
        'End Function

        Public Function GetQvADetail(ByVal jobnum As String, ByVal jobcompnum As String, ByVal usercode As String)
            Dim dr As SqlDataReader
            Dim arParams(2) As SqlParameter

            Dim parameterJobNumber As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(2) = parameterUserCode

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getQvADetail", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvADetail", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function GetQvADetailJob(ByVal jobnum As String, ByVal jobcompnum As String, ByVal usercode As String)
            Dim dr As SqlDataReader
            Dim arParams(2) As SqlParameter

            Dim parameterJobNumber As New SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            parameterJobNumber.Value = jobnum
            arParams(0) = parameterJobNumber
            Dim parameterJobCompNumber As New SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            parameterJobCompNumber.Value = jobcompnum
            arParams(1) = parameterJobCompNumber
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(2) = parameterUserCode

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getQvADetail_job", arParams)
            Catch
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvADetail", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function GetQvADetailCampaign(ByVal CampaignID As String, ByVal grouptype As String, ByVal usercode As String, ByVal DesktopObject As String)
            Dim dr As SqlDataReader
            Dim arParams(4) As SqlParameter

            Dim parameterCampaignID As New SqlParameter("@CampaignID", SqlDbType.Int)
            parameterCampaignID.Value = CampaignID
            arParams(0) = parameterCampaignID
            Dim parameterGroupType As New SqlParameter("@grouptype", SqlDbType.VarChar, 20)
            parameterGroupType.Value = grouptype
            arParams(1) = parameterGroupType
            Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserCode.Value = usercode
            arParams(2) = parameterUserCode
            Dim parameterDesktopObject As New SqlParameter("@DesktopObject", SqlDbType.VarChar, 20)
            parameterDesktopObject.Value = DesktopObject
            arParams(3) = parameterDesktopObject

            Try
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_getQvADetail_campaign", arParams)
            Catch ex As Exception
                Err.Raise(Err.Number, "Class:cTimesheet Routine:GetQvADetail", Err.Description)
            Finally

            End Try

            Return dr
        End Function

        Public Function GetQuickAddHeader(ByVal Task_JobNum As Integer, ByVal Task_JobCompNum As Integer, ByVal Task_SeqNum As Integer, ByVal EmpCode As String) As DataTable
            Try
                Dim arParams(4) As SqlParameter

                Dim paramTask_JobNum As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                paramTask_JobNum.Value = Task_JobNum
                arParams(0) = paramTask_JobNum

                Dim paramTask_JobCompNum As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                paramTask_JobCompNum.Value = Task_JobCompNum
                arParams(1) = paramTask_JobCompNum

                Dim paramTask_SeqNum As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                paramTask_SeqNum.Value = Task_SeqNum
                arParams(2) = paramTask_SeqNum

                Dim paramTask_EmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                paramTask_EmpCode.Value = EmpCode
                arParams(3) = paramTask_EmpCode

                Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_ts_QuickAdd_GetHeader", "dtHeader", arParams)
            Catch ex As Exception

            End Try
        End Function

        Public Function HasMissingOrDeniedTime() As Boolean

            Dim HasMissingTime As Boolean = False
            Dim HasDeniedTime As Boolean = False
            Dim TimeMessage As String = String.Empty

            LoadMissingDeniedTimeMessage(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HasMissingTime, HasDeniedTime, TimeMessage)

            If HasMissingTime = True OrElse HasDeniedTime = True Then

                Return True

            Else

                Return False

            End If

        End Function
        Public Function LoadTimeWarning(ByRef MissingDeniedTimeDivButton As HtmlControls.HtmlControl, ByRef MissingDeniedTimeImageButton As ImageButton) As Boolean

            Dim HasMissingTime As Boolean = False
            Dim HasDeniedTime As Boolean = False
            Dim TimeMessage As String = String.Empty
            Dim TimeJavascriptLink As String = "return false;"

            LoadMissingDeniedTimeMessage(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HasMissingTime, HasDeniedTime, TimeMessage)

            If HasMissingTime = True OrElse HasDeniedTime = True Then

                MissingDeniedTimeDivButton.Visible = True
                MissingDeniedTimeImageButton.OnClientClick = "OpenRadWindow('','Timesheet_MissingTime.aspx',0,0,false);return false;"

                MissingDeniedTimeImageButton.AlternateText = TimeMessage
                MissingDeniedTimeImageButton.ToolTip = TimeMessage
                MissingDeniedTimeDivButton.Attributes.Add("title", TimeMessage)

                MissingDeniedTimeDivButton.Visible = True
                MissingDeniedTimeImageButton.Visible = True

                Return True

            Else

                MissingDeniedTimeDivButton.Visible = False
                MissingDeniedTimeImageButton.Visible = False

                Return False

            End If

        End Function
        Public Sub LoadMissingDeniedTimeMessage(ByVal ConnectionString As String, ByVal UserCode As String,
                                                     ByRef HasMissingTime As Boolean, ByRef HasDeniedTime As Boolean, ByRef TimeMessage As String)

            HasMissingTime = False
            HasDeniedTime = False
            TimeMessage = String.Empty

            Dim DeniedTimesheetCount As Integer = 0

            TimeMessage = SetMissingTimeLabel(UserCode)

            If String.IsNullOrWhiteSpace(TimeMessage) = False Then

                HasMissingTime = True

            End If
            If Me.CheckDenied(UserCode) > 0 Then

                Dim dto As New cDesktopObjects(ConnectionString)
                Dim dt As DataTable = dto.GetDeniedTimeEmployee(UserCode).Tables(1)

                If dt IsNot Nothing Then

                    If Not IsDBNull(dt.Rows(0)("DENIED")) AndAlso IsNumeric(dt.Rows(0)("DENIED")) = True Then

                        HasDeniedTime = True
                        DeniedTimesheetCount = CType(dt.Rows(0)("DENIED"), Integer)

                    End If

                End If

            End If
            If HasMissingTime = True OrElse HasDeniedTime = True Then

                If HasMissingTime = True AndAlso HasDeniedTime = True Then

                    If DeniedTimesheetCount = 1 Then

                        TimeMessage &= " and one denied timesheet"

                    ElseIf DeniedTimesheetCount > 1 Then

                        TimeMessage &= String.Format(" and {0} denied timesheets", DeniedTimesheetCount)

                    End If

                ElseIf HasMissingTime = False AndAlso HasDeniedTime = True Then

                    If DeniedTimesheetCount = 1 Then

                        TimeMessage = "You have one denied timesheet"

                    ElseIf DeniedTimesheetCount > 1 Then

                        TimeMessage = String.Format("You have {0} denied timesheets", DeniedTimesheetCount)

                    End If

                End If

            End If

        End Sub

        Public Sub New(ByVal ConnectionString As String)
            mConnString = ConnectionString
        End Sub

        Public Function CheckDenied(ByVal userid As String) As Integer
            'Dim SessionKey As String = "CheckDenied" & userid
            Dim ReturnInteger As Integer = 0
            'If HttpContext.Current.Session(SessionKey) Is Nothing Then
            '    Try
            ' Create Instance of Connection and Command Object
            Dim arParams(2) As SqlParameter
            Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            paramUserID.Value = userid
            arParams(0) = paramUserID
            Try
                ReturnInteger = CType(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_ts_Check_Denied", arParams), Integer)
            Catch
                ReturnInteger = 0
            End Try

            '    Catch ex As Exception
            '        ReturnInteger = 0
            '    End Try
            '    HttpContext.Current.Session(SessionKey) = ReturnInteger
            'Else
            '    ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
            'End If

            Return ReturnInteger

        End Function

    End Class

End Namespace
