Namespace Timesheet

    Public Class TimesheetSettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum DaysToShow
            One = 1
            Five = 5
            Seven = 7
        End Enum

#End Region

#Region " Variables "

        Private _ConnectionString As String = ""
        Private _UserCode As String = ""

#End Region

#Region " Properties "

        Public ReadOnly Property CommentsRequired() As Boolean
            Get
                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_required_timesheet_comments"
                        .Connection = MyConn
                    End With

                    MyConn.Open()

                    Return CType(MyCommand.ExecuteScalar(), Integer) = 1

                End Using
            End Get
        End Property

#End Region

#Region " Methods "


        Public Function SaveAgencySettings(ByVal DaysToShow As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("UPDATE AGENCY WITH(ROWLOCK) SET TS_DAYS_PER_WK = @TS_DAYS_TO_DISPLAY;")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_DAYS_TO_DISPLAY WHERE AGY_SETTINGS_CODE = 'TS_DAYS_TO_DISPLAY';")
                End With
                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = SQL.ToString()
                        .Connection = MyConn
                    End With

                    Dim pTS_DAYS_TO_DISPLAY As New System.Data.SqlClient.SqlParameter("@TS_DAYS_TO_DISPLAY", SqlDbType.Int)
                    pTS_DAYS_TO_DISPLAY.Value = DaysToShow

                    MyCommand.Parameters.Add(pTS_DAYS_TO_DISPLAY)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                    If MyConn.State = ConnectionState.Open Then
                        MyConn.Close()
                        MyConn.Dispose()
                    End If

                End Using

                ErrorMessage = ""
                Return True
            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function
        Public Function SaveAgencySettings(ByRef Settings As AdvantageFramework.Timesheet.Settings.DisplaySettings, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Dim SQL As New System.Text.StringBuilder
                With SQL

                    .Append("UPDATE AGENCY WITH(ROWLOCK) SET TS_DAYS_PER_WK = @TS_DAYS_TO_DISPLAY;")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_DAYS_TO_DISPLAY WHERE AGY_SETTINGS_CODE = 'TS_DAYS_TO_DISPLAY';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_SHOW_CMNT_USING WHERE AGY_SETTINGS_CODE = 'TS_SHOW_CMNT_USING';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_START_WEEK_ON WHERE AGY_SETTINGS_CODE = 'TS_START_WEEK_ON';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_DIVISION WHERE AGY_SETTINGS_CODE = 'TS_DIVISION';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_PRODUCT WHERE AGY_SETTINGS_CODE = 'TS_PRODUCT';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_PROD_CAT WHERE AGY_SETTINGS_CODE = 'TS_PROD_CAT';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_JOB WHERE AGY_SETTINGS_CODE = 'TS_JOB';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_JOB_COMP WHERE AGY_SETTINGS_CODE = 'TS_JOB_COMP';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_FUNC_CAT WHERE AGY_SETTINGS_CODE = 'TS_FUNC_CAT';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_START_WEEK_ON WHERE AGY_SETTINGS_CODE = 'TS_START_WEEK_ON';")
                    .Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @TS_AGY_OVRRDE WHERE AGY_SETTINGS_CODE = 'TS_AGY_OVRRDE';")

                End With
                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()

                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = SQL.ToString()
                        .Connection = MyConn

                    End With

                    Dim pTS_DAYS_TO_DISPLAY As New System.Data.SqlClient.SqlParameter("@TS_DAYS_TO_DISPLAY", SqlDbType.Int)
                    pTS_DAYS_TO_DISPLAY.Value = Settings.DaysToDisplay
                    Dim pTS_SHOW_CMNT_USING As New System.Data.SqlClient.SqlParameter("@TS_SHOW_CMNT_USING", SqlDbType.VarChar, 10)
                    pTS_SHOW_CMNT_USING.Value = Settings.ShowCommentsUsing
                    Dim pTS_START_WEEK_ON As New System.Data.SqlClient.SqlParameter("@TS_START_WEEK_ON", SqlDbType.SmallInt)
                    pTS_START_WEEK_ON.Value = Settings.StartTimesheetOnDayOfWeek
                    Dim pTS_DIVISION As New System.Data.SqlClient.SqlParameter("@TS_DIVISION", SqlDbType.VarChar, 100)
                    pTS_DIVISION.Value = Settings.Labels.Division
                    Dim pTS_PRODUCT As New System.Data.SqlClient.SqlParameter("@TS_PRODUCT", SqlDbType.VarChar, 100)
                    pTS_PRODUCT.Value = Settings.Labels.Product
                    Dim pTS_PROD_CAT As New System.Data.SqlClient.SqlParameter("@TS_PROD_CAT", SqlDbType.VarChar, 100)
                    pTS_PROD_CAT.Value = Settings.Labels.ProdCat
                    Dim pTS_JOB As New System.Data.SqlClient.SqlParameter("@TS_JOB", SqlDbType.VarChar, 100)
                    pTS_JOB.Value = Settings.Labels.Job
                    Dim pTS_JOB_COMP As New System.Data.SqlClient.SqlParameter("@TS_JOB_COMP", SqlDbType.VarChar, 100)
                    pTS_JOB_COMP.Value = Settings.Labels.JobComponent
                    Dim pTS_FUNC_CAT As New System.Data.SqlClient.SqlParameter("@TS_FUNC_CAT", SqlDbType.VarChar, 100)
                    pTS_FUNC_CAT.Value = Settings.Labels.FuncCat
                    Dim pTS_AGY_OVRRDE As New System.Data.SqlClient.SqlParameter("@TS_AGY_OVRRDE", SqlDbType.Bit)
                    pTS_AGY_OVRRDE.Value = Settings.AgencyOverride

                    MyCommand.Parameters.Add(pTS_DAYS_TO_DISPLAY)
                    MyCommand.Parameters.Add(pTS_SHOW_CMNT_USING)
                    MyCommand.Parameters.Add(pTS_START_WEEK_ON)
                    MyCommand.Parameters.Add(pTS_DIVISION)
                    MyCommand.Parameters.Add(pTS_PRODUCT)
                    MyCommand.Parameters.Add(pTS_PROD_CAT)
                    MyCommand.Parameters.Add(pTS_JOB)
                    MyCommand.Parameters.Add(pTS_JOB_COMP)
                    MyCommand.Parameters.Add(pTS_FUNC_CAT)
                    MyCommand.Parameters.Add(pTS_AGY_OVRRDE)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                    If MyConn.State = ConnectionState.Open Then
                        MyConn.Close()
                        MyConn.Dispose()
                    End If

                End Using

                ErrorMessage = ""
                Return True
            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function

        Public Function GetSettings(Optional ByVal UserCode As String = "", Optional ByRef ErrorMessage As String = "") As AdvantageFramework.Timesheet.Settings.DisplaySettings
            Try
                Dim ds As New AdvantageFramework.Timesheet.Settings.DisplaySettings()

                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_get_settings"
                        .Connection = MyConn
                    End With

                    Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    If UserCode = "" Then
                        pUserCode.Value = System.DBNull.Value
                    Else
                        pUserCode.Value = UserCode
                    End If

                    MyCommand.Parameters.Add(pUserCode)

                    MyConn.Open()

                    Dim Reader As System.Data.SqlClient.SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then
                        Do While Reader.Read()

                            With ds

                                .DaysToDisplay = CType(Reader.GetValue(Reader.GetOrdinal("DAYS_TO_DISPLAY")), Integer)
                                .StartTimesheetOnDayOfWeek = Reader.GetValue(Reader.GetOrdinal("START_WEEK_ON"))
                                .ShowCommentsUsing = Reader.GetString(Reader.GetOrdinal("SHOW_COMMENT_USING"))
                                .DisablePagingOnMainGrid = Reader.GetValue(Reader.GetOrdinal("MAIN_TS_NO_PAGING"))
                                .RepeatRowForAllDays = Reader.GetValue(Reader.GetOrdinal("REPEAT_ROWS"))
                                .OnlyShowMyProgress = Reader.GetValue(Reader.GetOrdinal("ONLY_SHOW_MY_PROGRESS"))
                                .AgencyOverride = Reader.GetValue(Reader.GetOrdinal("AGY_OVERRIDE"))

                                .Labels.Division = Reader.GetString(Reader.GetOrdinal("DIVISION_LABEL"))
                                .Labels.Product = Reader.GetString(Reader.GetOrdinal("PRODUCT_LABEL"))
                                .Labels.ProdCat = Reader.GetString(Reader.GetOrdinal("PROD_CAT_LABEL"))
                                .Labels.Job = Reader.GetString(Reader.GetOrdinal("JOB_LABEL"))
                                .Labels.JobComponent = Reader.GetString(Reader.GetOrdinal("JOB_COMP_LABEL"))
                                .Labels.FuncCat = Reader.GetString(Reader.GetOrdinal("FUNC_CAT_LABEL"))

                            End With

                        Loop

                    End If

                End Using

                Return ds

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return Nothing
            End Try
        End Function

        Public Function ClientCommentRequired(ByVal ClientCode As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT ISNULL(REQ_TIME_COMMENT, 0) AS REQ_TIME_COMMENT FROM CLIENT WITH(ROWLOCK) WHERE CL_CODE = @CL_CODE;"
                        .Connection = MyConn
                    End With

                    Dim pClCode As New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                    pClCode.Value = ClientCode
                    MyCommand.Parameters.Add(pClCode)

                    MyConn.Open()

                    Return CType(MyCommand.ExecuteScalar(), Boolean)

                End Using

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function
        Public Function JobCommentRequired(ByVal JobNumber As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                If JobNumber = 0 Then Return False

                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_DetailRequireComment"
                        .Connection = MyConn
                    End With

                    Dim pJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                    pJobNumber.Value = JobNumber
                    MyCommand.Parameters.Add(pJobNumber)

                    Dim pEtId As New System.Data.SqlClient.SqlParameter("@ET_ID", SqlDbType.Int)
                    pEtId.Value = System.DBNull.Value
                    MyCommand.Parameters.Add(pEtId)

                    Dim pEtDtlId As New System.Data.SqlClient.SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                    pEtDtlId.Value = System.DBNull.Value
                    MyCommand.Parameters.Add(pEtDtlId)

                    MyConn.Open()

                    Return CType(MyCommand.ExecuteScalar(), Boolean)

                End Using

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function
        Public Function TimeEntryCommentRequired(ByVal EtId As Integer, ByVal EtDtlId As Integer, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Dim IsRequired As Boolean = False
                Dim val As Object = Nothing

                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_DetailRequireComment"
                        .Connection = MyConn
                    End With

                    Dim pJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                    pJobNumber.Value = System.DBNull.Value
                    MyCommand.Parameters.Add(pJobNumber)

                    Dim pEtId As New System.Data.SqlClient.SqlParameter("@ET_ID", SqlDbType.Int)
                    pEtId.Value = EtId
                    MyCommand.Parameters.Add(pEtId)

                    Dim pEtDtlId As New System.Data.SqlClient.SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                    pEtDtlId.Value = EtDtlId
                    MyCommand.Parameters.Add(pEtDtlId)

                    MyConn.Open()

                    val = MyCommand.ExecuteScalar()

                    If Not val Is Nothing Then

                        IsRequired = CType(val, Boolean)

                    End If

                End Using

                Return IsRequired

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function

        Public Function IsApprovalActive(Optional ByVal EmpCode As String = "") As Boolean

            Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_ts_IsApprovalActive"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                If EmpCode <> "" Then
                    pEmpCode.Value = EmpCode
                Else
                    pEmpCode.Value = System.DBNull.Value
                End If
                MyCommand.Parameters.Add(pEmpCode)

                MyConn.Open()

                Return CType(MyCommand.ExecuteScalar(), Boolean)

            End Using

        End Function

        Public Function AgencyCommentsRequired() As Boolean
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT CONVERT(BIT, ISNULL(AGENCY.TIME_COMMENTS_REQ, 0)) FROM AGENCY WITH(NOLOCK);"
                        .Connection = MyConn
                    End With

                    MyConn.Open()

                    Return MyCommand.ExecuteScalar()

                End Using

            Catch ex As Exception

                Return False

            End Try
        End Function
        Public Function CommentsRequiredWhenSubmittingForApproval() As Boolean
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(_ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT CONVERT(BIT, ISNULL(AGY_SETTINGS.AGY_SETTINGS_VALUE, AGY_SETTINGS.AGY_SETTINGS_DEF)) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_REQ_CMT_APPR';"
                        .Connection = MyConn
                    End With

                    MyConn.Open()

                    Return MyCommand.ExecuteScalar()

                End Using

            Catch ex As Exception

                Return False

            End Try
        End Function

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)
            _ConnectionString = ConnectionString
            _UserCode = UserCode
        End Sub


#End Region

    End Class

End Namespace
