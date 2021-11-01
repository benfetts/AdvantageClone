Namespace Timesheet.Settings

    <Serializable()> Public Class AgencyTimeEntryOptions

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum AllowSubmitForApprovalType

            None = 0
            ByDay = 1
            ByWeek = 2

        End Enum

#End Region

#Region " Variables "

        Private _ConnectionString As String = String.Empty
        Private _UserCode As String = String.Empty

#End Region

#Region " Properties "

        Public Property StopwatchMinimumTime As Decimal = 0.0
        Public Property StopwatchRoundToNextIncrement As Decimal = 0.0
        Public Property AllTimeEntryMinimumTime As Decimal = 0.0
        Public Property AllTimeEntryRoundToNextIncrement As Decimal = 0.0
        Public Property CommentsRequiredWhenSubmittingForApproval = False
        Public Property StartTimesheetOnDayOfWeek As DayOfWeek = DayOfWeek.Sunday
        Public Property RequireAssignment As Boolean = False
        Public Property RequiredHoursMetBeforeAllowSubmitForApproval As Boolean = False
        Public Property RequiredHoursMetBeforeAllowSubmitForApprovalType As AllowSubmitForApprovalType = AllowSubmitForApprovalType.None

#End Region

#Region " Methods "

        Public Function Save(Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                'Convert to decimal hours
                Me.StopwatchMinimumTime = Me.StopwatchMinimumTime / 60
                Me.StopwatchRoundToNextIncrement = Me.StopwatchRoundToNextIncrement / 60
                Me.AllTimeEntryMinimumTime = Me.AllTimeEntryMinimumTime / 60
                Me.AllTimeEntryRoundToNextIncrement = Me.AllTimeEntryRoundToNextIncrement / 60

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_SaveAgencyTimeEntryOptions"
                        .Connection = MyConn

                    End With

                    Dim pStopwatchMinimumTime As New System.Data.SqlClient.SqlParameter("@TS_STOP_MIN_TIME", SqlDbType.Decimal)
                    pStopwatchMinimumTime.Value = Me.StopwatchMinimumTime
                    MyCommand.Parameters.Add(pStopwatchMinimumTime)

                    Dim pStopwatchRoundToNextIncrement As New System.Data.SqlClient.SqlParameter("@TS_STOP_ROUND_TO", SqlDbType.Decimal)
                    pStopwatchRoundToNextIncrement.Value = Me.StopwatchRoundToNextIncrement
                    MyCommand.Parameters.Add(pStopwatchRoundToNextIncrement)

                    Dim pAllTimeEntryMinimumTime As New System.Data.SqlClient.SqlParameter("@TS_MIN_TIME", SqlDbType.Decimal)
                    pAllTimeEntryMinimumTime.Value = Me.AllTimeEntryMinimumTime
                    MyCommand.Parameters.Add(pAllTimeEntryMinimumTime)

                    Dim pAllTimeEntryRoundToNextIncrement As New System.Data.SqlClient.SqlParameter("@TS_ROUND_TO", SqlDbType.Decimal)
                    pAllTimeEntryRoundToNextIncrement.Value = Me.AllTimeEntryRoundToNextIncrement
                    MyCommand.Parameters.Add(pAllTimeEntryRoundToNextIncrement)

                    Dim pCommentsRequiredWhenSubmittingForApproval As New System.Data.SqlClient.SqlParameter("@TS_REQ_CMT_APPR", SqlDbType.Bit)
                    pCommentsRequiredWhenSubmittingForApproval.Value = Me.CommentsRequiredWhenSubmittingForApproval
                    MyCommand.Parameters.Add(pCommentsRequiredWhenSubmittingForApproval)

                    Dim pStartTimesheetOnDayOfWeek As New System.Data.SqlClient.SqlParameter("@TS_START_WEEK_ON", SqlDbType.SmallInt)
                    pStartTimesheetOnDayOfWeek.Value = CType(Me.StartTimesheetOnDayOfWeek, Integer)
                    MyCommand.Parameters.Add(pStartTimesheetOnDayOfWeek)

                    Dim pRequiredHoursMetBeforeAllowSubmitForApproval As New System.Data.SqlClient.SqlParameter("@TS_REQ_HRS_MET_APPR", SqlDbType.Bit)
                    pRequiredHoursMetBeforeAllowSubmitForApproval.Value = Me.RequiredHoursMetBeforeAllowSubmitForApproval
                    MyCommand.Parameters.Add(pRequiredHoursMetBeforeAllowSubmitForApproval)

                    Dim pRequiredHoursMetBeforeAllowSubmitForApprovalType As New System.Data.SqlClient.SqlParameter("@TS_REQ_HRS_APPR_TYPE", SqlDbType.SmallInt)
                    pRequiredHoursMetBeforeAllowSubmitForApprovalType.Value = CType(Me.RequiredHoursMetBeforeAllowSubmitForApprovalType, Short)
                    MyCommand.Parameters.Add(pRequiredHoursMetBeforeAllowSubmitForApprovalType)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                    If Me.RequireAssignment = True Then

                        DbContext.Database.ExecuteSqlCommand("UPDATE AGENCY SET TIME_REQ_ASSN = 1;")

                    Else

                        DbContext.Database.ExecuteSqlCommand("UPDATE AGENCY SET TIME_REQ_ASSN = 0;")

                    End If

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function
        Public Function Load(Optional ByRef ErrorMessage As String = "") As Boolean

            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_GetAgencyTimeEntryOptions"
                        .Connection = MyConn

                    End With

                    MyConn.Open()

                    Dim Reader As System.Data.SqlClient.SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            If Reader.IsDBNull(Reader.GetOrdinal("TS_MIN_TIME")) = False Then
                                Me.AllTimeEntryMinimumTime = Reader.GetValue(Reader.GetOrdinal("TS_MIN_TIME"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("TS_ROUND_TO")) = False Then
                                Me.AllTimeEntryRoundToNextIncrement = Reader.GetValue(Reader.GetOrdinal("TS_ROUND_TO"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("TS_STOP_MIN_TIME")) = False Then
                                Me.StopwatchMinimumTime = Reader.GetValue(Reader.GetOrdinal("TS_STOP_MIN_TIME"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("TS_STOP_ROUND_TO")) = False Then
                                Me.StopwatchRoundToNextIncrement = Reader.GetValue(Reader.GetOrdinal("TS_STOP_ROUND_TO"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("TS_REQ_CMT_APPR")) = False Then
                                Me.CommentsRequiredWhenSubmittingForApproval = Reader.GetValue(Reader.GetOrdinal("TS_REQ_CMT_APPR"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("TS_START_WEEK_ON")) = False Then
                                Me.StartTimesheetOnDayOfWeek = CType(Reader.GetValue(Reader.GetOrdinal("TS_START_WEEK_ON")), DayOfWeek)
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("TS_REQ_HRS_MET_APPR")) = False Then
                                Me.RequiredHoursMetBeforeAllowSubmitForApproval = Reader.GetValue(Reader.GetOrdinal("TS_REQ_HRS_MET_APPR"))
                            End If
                            Try
                                If Reader.IsDBNull(Reader.GetOrdinal("TS_REQ_HRS_APPR_TYPE")) = False Then
                                    Dim i As Short = 0
                                    i = Reader.GetValue(Reader.GetOrdinal("TS_REQ_HRS_APPR_TYPE"))
                                    Me.RequiredHoursMetBeforeAllowSubmitForApprovalType = CType(i, AllowSubmitForApprovalType)
                                End If
                            Catch ex As Exception
                                Me.RequiredHoursMetBeforeAllowSubmitForApprovalType = AllowSubmitForApprovalType.None
                            End Try
                        Loop

                        'convert from db decimal hours to friendly minutes
                        Me.AllTimeEntryMinimumTime = Me.AllTimeEntryMinimumTime * 60
                        Me.AllTimeEntryRoundToNextIncrement = Me.AllTimeEntryRoundToNextIncrement * 60
                        Me.StopwatchMinimumTime = Me.StopwatchMinimumTime * 60
                        Me.StopwatchRoundToNextIncrement = Me.StopwatchRoundToNextIncrement * 60

                    End If

                End Using

                Me.AllTimeEntryMinimumTime = Math.Round(Me.AllTimeEntryMinimumTime, 2)
                Me.AllTimeEntryRoundToNextIncrement = Math.Round(Me.AllTimeEntryRoundToNextIncrement, 2)
                Me.StopwatchMinimumTime = Math.Round(Me.StopwatchMinimumTime, 2)
                Me.StopwatchRoundToNextIncrement = Math.Round(Me.StopwatchRoundToNextIncrement, 2)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                        Me.RequireAssignment = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(ISNULL(TIME_REQ_ASSN, 0) AS BIT) FROM AGENCY WITH(NOLOCK);").FirstOrDefault

                    End Using

                Catch ex As Exception
                End Try


                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function

        Sub New(ByVal ConnectionString As String)

            _ConnectionString = ConnectionString

        End Sub
        Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            _ConnectionString = ConnectionString
            _UserCode = UserCode

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class HolidayHours
        Public Property Hours As Decimal = 0
        Public Property IsAllDay As Boolean = False
        Sub New()
        End Sub
    End Class

End Namespace
