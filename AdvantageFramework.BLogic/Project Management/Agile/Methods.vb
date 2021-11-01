Namespace ProjectManagement.Agile

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum JobComponentLookupObjectLevel

            Component = 0
            Job = 1
            Product = 2
            Division = 3
            Client = 4
            Office = 5

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function ClearAllocatedHours(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal JobNumber As Integer,
                                            ByVal JobComponentNumber As Short,
                                            ByVal TaskSequenceNumber As Short,
                                            ByVal EmployeeCode As String,
                                            ByVal IsTempComplete As Boolean) As Boolean

            Try

                Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing

                Parameters = {New SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber},
                              New SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) With {.Value = JobComponentNumber},
                              New SqlClient.SqlParameter("@TASK_SEQ_NBR", SqlDbType.SmallInt) With {.Value = TaskSequenceNumber},
                              New SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6) With {.Value = EmployeeCode},
                              New SqlClient.SqlParameter("@IS_TEMP_COMPLETE", SqlDbType.Bit) With {.Value = IsTempComplete}}

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_agile_clear_allocated_hours] NULL, @JOB_NUMBER, @JOB_COMPONENT_NBR, @TASK_SEQ_NBR, @EMP_CODE, @IS_TEMP_COMPLETE;", Parameters)

                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function ClearAllocatedHours(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal AlertID As Integer,
                                            ByVal EmployeeCode As String,
                                            ByVal IsTempComplete As Boolean) As Boolean

            Try

                Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing

                Parameters = {New SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) With {.Value = AlertID},
                              New SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6) With {.Value = EmployeeCode},
                              New SqlClient.SqlParameter("@IS_TEMP_COMPLETE", SqlDbType.Bit) With {.Value = IsTempComplete}}

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_agile_clear_allocated_hours] @ALERT_ID, NULL, NULL, NULL, @EMP_CODE, @IS_TEMP_COMPLETE;", Parameters)

                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function


        Public Function LoadJobsForBoard(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal BoardID As Integer,
                                         ByVal UserCode As String) As IEnumerable(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob)

            Try

                If BoardID > 0 Then

                    LoadJobsForBoard = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob)(String.Format("EXEC [dbo].[advsp_agile_load_board_jobs] {0}, '{1}';",
                                                                                                                                         BoardID, UserCode)).ToList

                Else

                    LoadJobsForBoard = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob)(String.Format("EXEC [dbo].[advsp_agile_load_board_jobs] NULL, '{0}';",
                                                                                                                                         UserCode)).ToList

                End If

            Catch ex As Exception
                LoadJobsForBoard = New Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardJob)
            End Try

        End Function
        Public Function LoadEmployeeSimple(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal UserCode As String,
                                            ByVal EmployeeCode As String,
                                            ByVal DepartmentTeamCode As String,
                                            ByVal EmailGroupCode As String,
                                            ByVal JobNumber As Integer,
                                            ByVal JobComponentNumber As Short,
                                            ByVal TaskSequenceNumber As Short,
                                            ByVal IsLookingUpAccountExecutive As Boolean,
                                            ByVal FilterByTaskRoles As Boolean,
                                            ByVal FilterByJobEmailGroup As Boolean,
                                            ByVal OnlyShowActive As Boolean) As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.EmployeeSimple)

            Try

                Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 10)
                Dim SqlParameterEmployeeCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterDepartmentTeamCode As New System.Data.SqlClient.SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterEmailGroupCode As New System.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
                Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                Dim SqlParameterTaskSequenceNumber As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                Dim SqlParameterIsLookingUpAccountExecutive As New System.Data.SqlClient.SqlParameter("@IS_AE", SqlDbType.Bit)
                Dim SqlParameterFilterByTaskRoles As New System.Data.SqlClient.SqlParameter("@IS_ROLE", SqlDbType.Bit)
                Dim SqlParameterFilterByJobEmailGroup As New System.Data.SqlClient.SqlParameter("@IS_EMAIL_GROUP", SqlDbType.Bit)
                Dim SqlParameterOnlyShowActive As New System.Data.SqlClient.SqlParameter("@ONLY_ACTIVE", SqlDbType.Bit)

                SqlParameterUserCode.Value = UserCode

                If EmployeeCode = "" Then

                    SqlParameterEmployeeCode.Value = System.DBNull.Value

                Else

                    SqlParameterEmployeeCode.Value = EmployeeCode

                End If
                If DepartmentTeamCode = "" Then

                    SqlParameterDepartmentTeamCode.Value = System.DBNull.Value

                Else

                    SqlParameterDepartmentTeamCode.Value = DepartmentTeamCode

                End If
                If EmailGroupCode = "" Then

                    SqlParameterEmailGroupCode.Value = System.DBNull.Value

                Else

                    SqlParameterEmailGroupCode.Value = EmailGroupCode

                End If
                If JobNumber = 0 Then

                    SqlParameterJobNumber.Value = System.DBNull.Value

                Else

                    SqlParameterJobNumber.Value = JobNumber

                End If
                If JobComponentNumber = 0 Then

                    SqlParameterJobComponentNumber.Value = System.DBNull.Value

                Else

                    SqlParameterJobComponentNumber.Value = JobComponentNumber

                End If
                If TaskSequenceNumber = -1 Then

                    SqlParameterTaskSequenceNumber.Value = System.DBNull.Value

                Else

                    SqlParameterTaskSequenceNumber.Value = TaskSequenceNumber

                End If

                SqlParameterIsLookingUpAccountExecutive.Value = IsLookingUpAccountExecutive
                SqlParameterFilterByTaskRoles.Value = FilterByTaskRoles
                SqlParameterFilterByJobEmailGroup.Value = FilterByJobEmailGroup
                SqlParameterOnlyShowActive.Value = OnlyShowActive

                LoadEmployeeSimple = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.EmployeeSimple)("EXEC advsp_load_employee_simple @USER_CODE, @EMP_CODE, @DP_TM_CODE, @EMAIL_GR_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR, @IS_AE, @IS_ROLE, @IS_EMAIL_GROUP, @ONLY_ACTIVE",
                                                                                                                         SqlParameterUserCode,
                                                                                                                         SqlParameterEmployeeCode,
                                                                                                                         SqlParameterDepartmentTeamCode,
                                                                                                                         SqlParameterEmailGroupCode,
                                                                                                                         SqlParameterJobNumber,
                                                                                                                         SqlParameterJobComponentNumber,
                                                                                                                         SqlParameterTaskSequenceNumber,
                                                                                                                         SqlParameterIsLookingUpAccountExecutive,
                                                                                                                         SqlParameterFilterByTaskRoles,
                                                                                                                         SqlParameterFilterByJobEmailGroup,
                                                                                                                         SqlParameterOnlyShowActive).ToList


            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Enum BacklogSort

            None = 0
            CreateDateDescending = 1
            CreateDateAscending = 2

        End Enum
        Public Function LoadBoardTaskAssignmentCards(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal SprintHeaderID As Integer,
                                                     ByVal UserCode As String,
                                                     ByVal SortBacklog As BacklogSort) As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)

            Dim Cards As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing

            Try

                Cards = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)(String.Format("EXEC [dbo].[advsp_agile_get_sprint_details] {0}, '{1}', 0, 0, {2};",
                                                                                                                                            SprintHeaderID, UserCode, CType(SortBacklog, Short))).ToList

            Catch ex As Exception
                Cards = Nothing
            End Try

            If Cards IsNot Nothing Then

                Try

                    LoadTaskAssignmentCardsAssignees(DbContext, Cards, True)

                Catch ex As Exception

                End Try

            End If

            If Cards Is Nothing Then Cards = New List(Of Classes.TaskAssignmentCard)

            Return Cards

        End Function
        Public Function LoadBoardTaskAssignmentCard(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal SprintHeaderID As Integer,
                                                    ByVal UserCode As String,
                                                    ByVal SprintDetailID As Integer) As AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard

            Try

                LoadBoardTaskAssignmentCard = (From Entity In LoadBoardTaskAssignmentCards(DbContext, SprintHeaderID, UserCode, BacklogSort.None)
                                               Where Entity.SprintDetailID = SprintDetailID
                                               Select Entity).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function LoadBoardTaskAssignmentCardBySprintHeaderIDAndAlertID(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                              ByVal UserCode As String,
                                                                              ByVal SprintHeaderID As Integer,
                                                                              ByVal AlertID As Integer) As AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard

            Try

                'LoadBoardTaskAssignmentCard = (From Entity In LoadBoardTaskAssignmentCards(DbContext, SprintDetailID, UserCode)
                '                               Where Entity.SprintDetailID = SprintDetailID
                '                               Select Entity).SingleOrDefault

            Catch ex As Exception

            End Try

            Return Nothing

        End Function
        Public Sub LoadTaskAssignmentCardsAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal TaskAssignmentCards As Generic.List(Of Classes.TaskAssignmentCard),
                                                    Optional ByVal ClearImages As Boolean = False)

            'objects
            Dim CardAssignees As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardAssignee) = Nothing

            Try

                CardAssignees = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardAssignee)(String.Format("SELECT * FROM dbo.V_AGILE_CARD_ASSIGNEES WHERE AlertID IN ({0}) AND IsCurrentAssignee = 1;", String.Join(",", TaskAssignmentCards.Select(Function(t) t.AlertID).ToList))).ToList

            Catch ex As Exception

            End Try

            If CardAssignees IsNot Nothing AndAlso CardAssignees.Count > 0 Then

                'If ClearImages = True Then

                For Each CardAssignee In CardAssignees

                    CardAssignee.EmployeeImage = Nothing

                Next

                'End If

                For Each AlertID In CardAssignees.Select(Function(ca) ca.AlertID).Distinct.ToList

                    For Each TaskAssignmentCard In TaskAssignmentCards.Where(Function(tac) tac.AlertID = AlertID).ToList

                        If TaskAssignmentCard.BoardColumnID = -2 Then

                            TaskAssignmentCard.Assignees = Nothing

                        Else

                            TaskAssignmentCard.Assignees = CardAssignees.Where(Function(ca) ca.AlertID = AlertID).ToList

                        End If

                    Next

                Next

            End If

        End Sub
        Public Sub LoadTaskAssignmentCardAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal TaskAssignmentCard As Classes.TaskAssignmentCard)

            LoadTaskAssignmentCardsAssignees(DbContext, {TaskAssignmentCard}.ToList)

        End Sub
        Public Function MoveBoardItem(ByVal Session As AdvantageFramework.Security.Session,
                                       ByVal TargetAlertStateID As Integer,
                                       ByRef SprintDetail As AdvantageFramework.Database.Entities.SprintDetail,
                                       ByVal CurrentBoardColumnID As Integer) As Boolean

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim AlertCompletedBeforeMoving As Boolean = False
            Dim FromColumnName As String = String.Empty
            Dim ToColumnName As String = String.Empty
            Dim NewStateID As Integer? = Nothing

            Dim BoardID As Integer = 0
            Dim BoardHeaderID As Integer = 0
            Dim TargetBoardColumnID As Integer = 0
            Dim BoardDetailID As Integer = 0

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing
            'Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing
            Dim BoardHeader As AdvantageFramework.Database.Entities.BoardHeader = Nothing
            Dim TargetBoardDetail As AdvantageFramework.Database.Entities.BoardDetail = Nothing
            Dim UpdatedCard As AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard = New AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard
            Dim AlertComment As New AdvantageFramework.Database.Entities.AlertComment
            Dim TargetAlertState As AdvantageFramework.Database.Entities.AlertState = Nothing
            Dim StartingAlertState As AdvantageFramework.Database.Entities.AlertState = Nothing
            Dim Cards As List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing

            Dim AlertIsWorkItem As Boolean = False
            Dim AlertIsRealAssignment As Boolean = False
            Dim AlertIsBoardTask As Boolean = False

            Dim AlertIsCompleted As Boolean = False
            Dim IsSequential As Boolean = False
            Dim ForceAllColumns As Boolean = False
            Dim IsCompleting As Boolean = False
            Dim IsBackToBacklog As Boolean = False
            Dim IsReOpening As Boolean = False
            Dim IsUpdatingCompletedToCompleted As Boolean = False

            Dim CheckForEmployeeRecords As Boolean = False
            Dim TrackChanges As Boolean = False
            Dim EmailOnChange As Boolean = False
            Dim EmailSent As Boolean = False

            Try

                If TargetAlertStateID = -1 Then

                    IsBackToBacklog = True
                    TargetBoardColumnID = TargetAlertStateID

                End If
                If TargetAlertStateID = -2 Then

                    IsCompleting = True
                    TargetBoardColumnID = TargetAlertStateID

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintDetailID(DbContext, SprintDetail.ID)

                    If SprintHeader IsNot Nothing AndAlso SprintHeader.BoardID IsNot Nothing AndAlso SprintHeader.BoardID > 0 Then

                        BoardID = SprintHeader.BoardID

                        Try

                            BoardHeaderID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(B.BOARD_HDR_ID AS INT) FROM SPRINT_HDR SH INNER JOIN BOARD B ON SH.BOARD_ID = B.ID WHERE SH.ID = {0};", SprintHeader.ID)).SingleOrDefault

                        Catch ex As Exception
                            BoardHeaderID = 0
                        End Try
                        If BoardHeaderID > 0 Then

                            If IsBackToBacklog = False AndAlso IsCompleting = False Then

                                Try

                                    TargetBoardColumnID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(ISNULL(BOARD_COL_ID, 0) AS INT) FROM BOARD_DTL WHERE BOARD_HDR_ID = {0} AND ALERT_STATE_ID = {1};", BoardHeaderID, TargetAlertStateID)).SingleOrDefault

                                Catch ex As Exception
                                    TargetBoardColumnID = 0
                                End Try

                            End If

                            BoardHeader = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardHeaderID)

                            If BoardHeader IsNot Nothing Then

                                IsSequential = BoardHeader.IsSequential IsNot Nothing AndAlso BoardHeader.IsSequential = True
                                ForceAllColumns = BoardHeader.ForceAllColumns IsNot Nothing AndAlso BoardHeader.ForceAllColumns = True
                                TrackChanges = BoardHeader.TrackChanges IsNot Nothing AndAlso BoardHeader.TrackChanges = True
                                EmailOnChange = BoardHeader.EmailOnChange IsNot Nothing AndAlso BoardHeader.EmailOnChange = True

                            End If

                        End If

                    End If

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, SprintDetail.AlertID)

                    If Alert IsNot Nothing Then

                        If Alert.IsWorkItem IsNot Nothing AndAlso Alert.IsWorkItem = True Then

                            If Alert.AlertLevel = "BRD" = True Then

                                AlertIsBoardTask = True

                            Else

                                AlertIsWorkItem = True

                                If (Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID > 0) AndAlso
                                   (Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID > 0) Then

                                    AlertIsRealAssignment = True

                                End If

                            End If

                        End If

                        If (Alert.AssignmentCompleted IsNot Nothing AndAlso Alert.AssignmentCompleted = True) OrElse CurrentBoardColumnID = -2 Then

                            AlertIsCompleted = True

                        End If

                        AlertComment.AlertID = SprintDetail.AlertID
                        AlertComment.UserCode = Session.UserCode
                        AlertComment.BoardID = BoardID
                        AlertComment.BoardHeaderID = BoardHeaderID

                        If IsBackToBacklog = False Then

                            AlertComment.BoardColumnID = TargetBoardColumnID

                        Else

                            AlertComment.BoardColumnID = Nothing

                        End If

                        If Alert.BoardStateID IsNot Nothing Then

                            StartingAlertState = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, Alert.BoardStateID)

                            If StartingAlertState IsNot Nothing Then

                                FromColumnName = StartingAlertState.Name

                            End If

                        End If

                        If Alert.AssignmentCompleted IsNot Nothing AndAlso Alert.AssignmentCompleted = True Then

                            FromColumnName = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Completed.ToString
                            AlertCompletedBeforeMoving = True

                        End If

                        If String.IsNullOrWhiteSpace(FromColumnName) = True Then

                            FromColumnName = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Backlog.ToString

                        End If

                        Select Case TargetAlertStateID
                            Case -1 'Backlog

                                Success = AdvantageFramework.Database.Procedures.SprintDetail.Delete(DbContext, SprintDetail)

                                If Success = True Then

                                    SprintDetail = Nothing
                                    ToColumnName = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Backlog.ToString

                                    If AlertIsCompleted = True Then

                                        If AlertIsBoardTask = False Then

                                            AdvantageFramework.AlertSystem.UnCompleteAssignment(DbContext, Alert, Session.User.EmployeeCode, Session.UserCode)

                                        End If

                                    End If

                                    If AlertIsBoardTask = True Then

                                        AdvantageFramework.ProjectSchedule.UnCompleteBoardTask(DbContext, Session.UserCode, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                                    End If

                                    Alert.BoardStateID = Nothing
                                    Alert.AssignmentCompleted = False

                                    UpdatedCard.BoardColumnID = CType(AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Backlog, Integer)

                                End If

                            Case -2 'Completed

                                If Alert.AssignmentCompleted Is Nothing OrElse Alert.AssignmentCompleted = False Then

                                    ToColumnName = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Completed.ToString
                                    Alert.AssignmentCompleted = True

                                    'AdvantageFramework.AlertSystem.CreateCompletedChangedComment(DbContext, Alert, Session.User.EmployeeCode)

                                    If AlertIsBoardTask = False Then

                                        Try

                                            Dim PromptForFullCompleteTask As Boolean = False
                                            Dim PromptForTempCompleteTask As Boolean = False
                                            Dim s As String = String.Empty

                                            AdvantageFramework.AlertSystem.DismissAlert(DbContext, Alert.ID, "", Session.UserCode, 0, True,
                                                                                        PromptForFullCompleteTask, PromptForTempCompleteTask, s)

                                        Catch ex As Exception
                                        End Try

                                    End If
                                    If AlertIsBoardTask = True Then

                                        AdvantageFramework.ProjectSchedule.CompleteBoardTask(DbContext, Session.UserCode, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)
                                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 0;", Alert.ID, Session.UserCode))

                                        ClearAllocatedHours(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Session.User.EmployeeCode, False)

                                    Else

                                        ClearAllocatedHours(DbContext, Alert.ID, Session.User.EmployeeCode, False)

                                    End If

                                    UpdatedCard.BoardColumnID = CType(AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Completed, Integer)

                                Else

                                    IsUpdatingCompletedToCompleted = True

                                End If

                            Case > 0 'Real column

                                If AlertIsCompleted = True Then

                                    IsReOpening = True

                                End If

                                Alert.AssignmentCompleted = False

                                TargetBoardDetail = AdvantageFramework.Database.Procedures.BoardDetail.LoadByBoardHeaderIDandBoardColumnIDandAlertStateID(DbContext, BoardHeaderID, TargetBoardColumnID, TargetAlertStateID)

                                If TargetBoardDetail IsNot Nothing Then

                                    Alert.BoardStateID = TargetBoardDetail.AlertStateID
                                    UpdatedCard.BoardColumnID = TargetBoardDetail.AlertStateID

                                    TargetAlertState = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, TargetBoardDetail.AlertStateID)

                                    If TargetAlertState IsNot Nothing Then

                                        ToColumnName = TargetAlertState.Name

                                    End If

                                    If AlertIsCompleted = True Then

                                        If AlertIsBoardTask = False Then

                                            AdvantageFramework.AlertSystem.UnCompleteAssignment(DbContext, Alert, Session.User.EmployeeCode, Session.UserCode)

                                        Else

                                            DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_auto_comment] {0}, '{1}', NULL, 1, 1;", Alert.ID, Session.UserCode))

                                        End If

                                    Else

                                        If CurrentBoardColumnID = -1 Then

                                            CheckForEmployeeRecords = True

                                        End If

                                    End If
                                    If AlertIsBoardTask = True Then

                                        AdvantageFramework.ProjectSchedule.UnCompleteBoardTask(DbContext, Session.UserCode, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                                        If CurrentBoardColumnID = -1 Then

                                            AdvantageFramework.ProjectSchedule.ActivateBoardTask(DbContext, Alert.ID, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                                        End If

                                    End If

                                End If

                        End Select

                        'If AlertIsRealAssignment = False Then

                        '    Alert.AlertAssignmentTemplateID = Nothing

                        'End If
                        Alert.LastUpdated = Now
                        Alert.LastUpdatedUserCode = Session.UserCode
                        Alert.LastUpdatedFullName = Session.EmployeeName
                        Success = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                    Else

                        Success = False

                        If Alert Is Nothing Then

                            ErrorMessage = "Could not get assignment ID"

                        End If

                    End If

                    If Success = True Then

                        If CheckForEmployeeRecords = True Then

                            Dim BackgroundWork As New AdvantageFramework.ProjectManagement.Agile.Classes.WorkItemAsync(Session)
                            BackgroundWork.SprintHeaderID = SprintHeader.ID
                            BackgroundWork.AlertID = Alert.ID
                            BackgroundWork.CheckSprintEmployeeRecords()

                        End If

                        If TrackChanges = True AndAlso IsCompleting = False AndAlso IsReOpening = False Then

                            Dim CurrentTime As DateTime = CType(Now, DateTime)

                            AlertComment.Comment = String.Format("Moved from <i>{0}</i> to <i>{1}</i>", FromColumnName, ToColumnName)
                            AlertComment.GeneratedDate = CurrentTime
                            AlertComment.IsSystem = True
                            AlertComment.CustodyStart = CurrentTime

                            If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) = True Then

                                Dim LastCustodyStartCommentID As Integer = 0

                                Try

                                    LastCustodyStartCommentID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 CAST(COMMENT_ID AS INT) FROM ALERT_COMMENT WHERE ALERT_ID = {0} AND (NOT CUSTODY_START IS NULL AND CUSTODY_END IS NULL) AND COMMENT_ID < {1} ORDER BY COMMENT_ID DESC;", Alert.ID, AlertComment.ID)).SingleOrDefault

                                Catch ex As Exception
                                    LastCustodyStartCommentID = 0
                                End Try
                                If LastCustodyStartCommentID > 0 Then

                                    Dim LastCustodyComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

                                    LastCustodyComment = AdvantageFramework.Database.Procedures.AlertComment.LoadByCommentID(DbContext, LastCustodyStartCommentID)

                                    If LastCustodyComment IsNot Nothing Then

                                        LastCustodyComment.CustodyEnd = CurrentTime

                                        If AdvantageFramework.Database.Procedures.AlertComment.Update(DbContext, LastCustodyComment) = True Then

                                            If LastCustodyComment.CustodyStart IsNot Nothing AndAlso LastCustodyComment.CustodyEnd IsNot Nothing Then

                                                AlertComment.Comment &= String.Format("<br />Time in <i>{0}</i>:  {1}", FromColumnName, AdvantageFramework.DateUtilities.FriendlyDateDiff(LastCustodyComment.CustodyStart, LastCustodyComment.CustodyEnd))

                                                AdvantageFramework.Database.Procedures.AlertComment.Update(DbContext, AlertComment)

                                            End If

                                        End If

                                    End If

                                End If

                                If EmailOnChange = True Then

                                    With New AdvantageFramework.AlertSystem.Classes.AlertEmail(DbContext.ConnectionString, DbContext.UserCode)

                                        .AlertID = SprintDetail.AlertID
                                        .Subject = "[Assignment Updated]"

                                        .Send()

                                    End With

                                    EmailSent = True

                                End If

                            End If

                        End If

                        If EmailSent = False AndAlso EmailOnChange = True AndAlso IsUpdatingCompletedToCompleted = False Then

                            With New AdvantageFramework.AlertSystem.Classes.AlertEmail(DbContext.ConnectionString, DbContext.UserCode)

                                .AlertID = SprintDetail.AlertID
                                .Subject = "[Assignment Updated]"

                                .Send()

                            End With

                            EmailSent = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            Return Success

        End Function
        Public Function LoadSprintJobComponents(ByVal Session As AdvantageFramework.Security.Session,
                                                ByVal SprintID As Integer,
                                                ByVal AlertID As Integer,
                                                ByVal Level As JobComponentLookupObjectLevel) As Generic.List(Of AdvantageFramework.DTO.JobComponent)

            'objects
            Dim BaseJobComponents As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            Try

                Dim SprintIDSqlParameter = New System.Data.SqlClient.SqlParameter("SprintID", SprintID)
                Dim UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("UserCode", Session.UserCode)
                Dim LevelSqlParameter = New System.Data.SqlClient.SqlParameter("Level", CType(Level, Short))
                Dim IsTask As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        If AlertID > 0 Then

                            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                            If Alert IsNot Nothing AndAlso Alert.AlertLevel = "BRD" Then

                                IsTask = True

                            End If

                        End If

                        BaseJobComponents = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.JobComponent)("EXEC [dbo].[advsp_agile_get_sprint_job_components] @SprintID, @UserCode, @Level;",
                                                                                                                SprintIDSqlParameter,
                                                                                                                UserCodeSqlParameter,
                                                                                                                LevelSqlParameter).ToList

                        If IsTask = False Then

                            JobComponents = BaseJobComponents

                        Else

                            Dim Schedules As Generic.List(Of AdvantageFramework.Database.Entities.JobTraffic) = Nothing

                            Schedules = AdvantageFramework.Database.Procedures.JobTraffic.Load(DbContext).ToList

                            If Schedules IsNot Nothing Then

                                JobComponents = (From Entity In BaseJobComponents
                                                 Join Sched In Schedules On Entity.JobNumber Equals Sched.JobNumber And Entity.JobComponentNumber Equals Sched.JobComponentNumber
                                                 Select Entity).ToList

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                End Using

            Catch ex As Exception
                If JobComponents Is Nothing Then JobComponents = New List(Of DTO.JobComponent)
            End Try

            LoadSprintJobComponents = JobComponents

        End Function

        Public Function LoadWorkItemHoursBySprintHeaderIDandAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                    ByVal SprintHeaderID As Integer, ByVal AlertID As Integer,
                                                                    ByVal IncludePast As Boolean, ByVal IncludeFuture As Boolean, ByVal ShowAvailability As Boolean) As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)


            Dim WorkItemHoursList As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel) = Nothing
            'Dim StartDate As String = String.Empty
            'Dim EndDate As String = String.Empty

            Try

                'If IncludePast = True Then
                '    StartDate = "NULL"
                'End If
                'If IncludeFuture = True Then
                '    EndDate = "NULL"
                'End If

                WorkItemHoursList = DbContext.Database.SqlQuery(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)(String.Format("EXEC [dbo].[advsp_agile_load_workitemhours] {0}, {1}, NULL, NULL, NULL, '{2}', {3};",
                                                                                                                                            SprintHeaderID, AlertID, DbContext.UserCode, ShowAvailability)).ToList

            Catch ex As Exception
                WorkItemHoursList = Nothing
            End Try

            If WorkItemHoursList Is Nothing Then WorkItemHoursList = New List(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)
            Return WorkItemHoursList

        End Function
        Public Function LoadWorkItemHoursBySprintHeaderID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintHeaderID As Integer) As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)

            Dim WorkItemHoursList As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel) = Nothing

            Try

                WorkItemHoursList = DbContext.Database.SqlQuery(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)(String.Format("EXEC [dbo].[advsp_agile_load_workitemhours] {0}, NULL, NULL, NULL, NULL;", SprintHeaderID)).ToList

            Catch ex As Exception
                WorkItemHoursList = Nothing
            End Try

            If WorkItemHoursList Is Nothing Then WorkItemHoursList = New List(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)
            Return WorkItemHoursList

        End Function
        Public Function LoadWorkItemEmployeeHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal ShowAvailability As Boolean) As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)

            Dim WorkItemHoursList As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel) = Nothing

            Try

                WorkItemHoursList = DbContext.Database.SqlQuery(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)(String.Format("EXEC [dbo].[advsp_agile_load_workitemhours_emp] {0}, '{1}', {2};", AlertID, DbContext.UserCode, ShowAvailability)).ToList

            Catch ex As Exception
                WorkItemHoursList = Nothing
            End Try

            If WorkItemHoursList Is Nothing Then WorkItemHoursList = New List(Of ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)
            Return WorkItemHoursList

        End Function

#End Region

    End Module

End Namespace


