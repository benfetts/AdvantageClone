IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dto_dashboard_alert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dto_dashboard_alert]
GO
CREATE PROCEDURE [dbo].[usp_wv_dto_dashboard_alert]
@EMP_CODE varchar(6),
@START_DATE_AS_OF_TODAY bit = 0,
@START_AND_DUE_DATE_NOT_NULL bit = 0,
@TASK_STATUS char(1) = '', --(P)rojected, (A)ctive, ''=All
@GROUP_BY varchar(20) = 'XXX',
@INCLUDE_BACKLOG bit = 0,
@GET_NOTIFICATION_COUNT_ONLY bit = 0,
@OFFSET decimal = 0
AS

IF @GET_NOTIFICATION_COUNT_ONLY = 1
	SET @INCLUDE_BACKLOG = 1

CREATE TABLE #Cards (
	ALERT_ID int not null,
	[START_DATE] smalldatetime null,
	DUE_DATE smalldatetime null,
	READ_ALERT smallint null,
	CheckListCompleted int not null DEFAULT(0),
	CheckListTotal int not null DEFAULT(0),
	TaskFunctionDescription varchar(40) null,
	TaskComment varchar(MAX) null,
	IsAlertCC bit NOT NULL,
	IsMyTaskTempComplete bit NOT NULL DEFAULT(0),
	TaskStatus varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CARD_SEQ_NBR int NULL,
	JobIsOnBoard bit NOT NULL DEFAULT(0),
	BOARD_ID int NULL,
	EXCLUDE_TASKS bit NOT NULL DEFAULT(0),
	IsProof BIT DEFAULT(0)
)

INSERT INTO #Cards (ALERT_ID, START_DATE, DUE_DATE, READ_ALERT, CheckListCompleted, CheckListTotal, TaskFunctionDescription, TaskComment, IsAlertCC, IsMyTaskTempComplete, TaskStatus, CARD_SEQ_NBR, JobIsOnBoard, BOARD_ID, EXCLUDE_TASKS, IsProof)
SELECT
	X.AlertID,
	X.StartDate,
	X.DueDate,
	X.ReadAlert,
	X.CheckListCompleted,
	X.CheckListTotal,
	X.TaskFunctionDescription,
	X.TaskComment,
	X.IsAlertCC,
	X.IsMyTaskTempComplete,
	X.TaskStatus,
	X.CardSequenceNumber,
	X.JobIsOnBoard,
	X.BoardID,
	X.ExcludeTasks,
	X.IsProof
FROM
	[dbo].[advtf_alert_dashboard] (@EMP_CODE, 'inbox', @GROUP_BY, @INCLUDE_BACKLOG, @OFFSET) AS X

SELECT
	ID = A.ALERT_ID,
	--AlertLevel 
	--AlertLevelDisplay = A.ALERT_LEVEL_TEXT,
	AlertTypeID = A.ALERT_TYPE_ID,
	AlertTypeDescription = [AT].ALERT_TYPE_DESC, 
	GeneratedDate = CASE WHEN @OFFSET = 0 THEN A.[GENERATED]
					ELSE DATEADD(mi, (CONVERT(INT, @OFFSET) * 60) + (@OFFSET - CONVERT(INT, @OFFSET)), A.[GENERATED])
					END,
	LastUpdatedDateTime = CASE WHEN @OFFSET = 0 THEN ISNULL(A.LAST_UPDATED, A.[GENERATED])
							ELSE ISNULL(DATEADD(mi, (CONVERT(INT, @OFFSET) * 60) + (@OFFSET - CONVERT(INT, @OFFSET)), ISNULL(A.LAST_UPDATED, A.[GENERATED])), ISNULL(A.LAST_UPDATED, A.[GENERATED]))
							END,
	--OriginatedDate 
	--IsCPAlert 
	--UserName 
	--UserCode 
	--GeneratedByEmployeeCode 
	--GeneratedByEmployeeName 
	EmployeeCode = A.EMP_CODE,
	LastUpdatedFullName = A.LAST_UPDATED_FML,
	OfficeCode = JL.OFFICE_CODE,
	--OfficeName 
	ClientCode = A.CL_CODE,
	ClientName = CL.CL_NAME,
	DivisionCode = A.DIV_CODE,
	DivisionName = D.DIV_NAME,
	ProductCode = A.PRD_CODE,
	ProductName = P.PRD_DESCRIPTION,
	CampaignID = JL.CMP_IDENTIFIER,
	CampaignCode = JL.CMP_CODE,
	CampaignName = CMP.CMP_NAME,
	JobNumber = A.JOB_NUMBER,
	JobDescription = JL.JOB_DESC,
	JobComponentNumber = JC.JOB_COMPONENT_NBR,
	JobComponentDescription = JC.JOB_COMP_DESC,
	TaskFunctionDescription = C.TaskFunctionDescription, 
	IsAlertCC = C.IsAlertCC,
	AlertCategoryID = A.ALERT_CAT_ID,
	AlertCategoryDescription = AC.ALERT_DESC,
	PriorityLevel = CAST(COALESCE(A.[PRIORITY], 3) as smallint),
	--PriorityDescription 
	DueDate = C.DUE_DATE,
	TimeDue = A.TIME_DUE,
	[Subject] = A.[SUBJECT],
	--Body 
	--EmailBody 
	--AlertAssignmentTemplateID 
	--AlertAssignmentTemplateName 
	AlertStateID = ALS.ALERT_STATE_ID,
	AlertStateName = CASE WHEN ALS.ALERT_STATE_ID IS NULL THEN 'None' ELSE ALS.ALERT_STATE_NAME END,
	--AlertSequenceNumber 
	--DisplayID 
	IsAlertAssignment = CAST(CASE WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN 1 ELSE 0 END as BIT),
	--CommentCount 
	--Version 
	--VersionName 
	--Build 
	--BuildName 
	--AttachmentCount 
	--TaskCode 
	TaskSequenceNumber = A.TASK_SEQ_NBR,
	TaskStatus = C.TaskStatus,
	--AccountPayableID 
	--AccountPayableSequenceNumber 
	--IsCompleted
	--CompletedDate 
	--DueDateLocked
	--IsTask
	--IsMyTask
	--IsMyAlert
	--IsMyAlertOpen
	--IsMyAlertDismissed
	--MyAlertDismissedDate As Date?
	--IsMyAssignment
	--IsMyAssignmentOpen
	--IsMyAssignmentCompleted
	--MediaATBRevisionID 
	--MediaATBNumber 
	--MediaATBDescription 
	--WasMarkedRead
	--WvPermaLink 
	--CpPermaLink 
	SprintID = COALESCE(SD.SPRINT_HDR_ID, 0),
	--SprintDescription 
	BoardID = C.BOARD_ID,
	--BoardName 
	--BoardHeaderID ?
	--BoardHeaderDescription 
	--BoardStateID 
	--BoardStateName 
	IsWorkItem = CAST(COALESCE(A.IS_WORK_ITEM, 0) AS BIT),
	--AssignedEmployeeCode 
	--AssignedEmployeeName 
	--HoursAllowed
	--HoursPosted
	--HoursAllocated
	--HoursAllocatedBalance
	--HoursBalance
	--SendAssignmentComment 
	--UploadedFiles ()
	--Recipients ()
	--Assignees ()
	--LinkedDocuments ()
	--CardGroupingPriorityText = CASE
	--							WHEN A.[PRIORITY] = 1 THEN '1,Highest'
	--							WHEN A.[PRIORITY] = 2 THEN '2,High'
	--							WHEN A.[PRIORITY] = 3 THEN '3,Normal'
	--							WHEN A.[PRIORITY] = 4 THEN '4,Low'
	--							WHEN A.[PRIORITY] = 5 THEN '5,Lowest'
	--							ELSE '3,Normal' END,
	ReadAlert = C.READ_ALERT,
	ReadAlertText = CASE WHEN C.READ_ALERT = 1 THEN 'Read' ELSE 'Not Read' END,
	CardSequenceNumber = C.CARD_SEQ_NBR,
	StartDate = C.[START_DATE],
    TaskComment = C.TaskComment,
    CheckListCompleted = C.CheckListCompleted,
    CheckListTotal = C.CheckListTotal,
	IsCSReview = CAST(ISNULL(A.IS_CS_REVIEW, 0) AS BIT),
	CSProjectID = ISNULL(A.CS_PROJECT_ID, 0),
	CSReviewID = ISNULL(A.CS_REVIEW_ID, 0),
--    ShowChecklistsOnCards = '',
    IsMyTaskTempComplete = C.IsMyTaskTempComplete,
--    TempCompleteString ='',
	EstimateNumber = 0,
	EstimateComponentNumber = CAST(0 as smallint),
	CheckListComplete = CASE WHEN C.CheckListCompleted = C.CheckListTotal THEN 1 ELSE 0 END,
	GroupKey = CASE WHEN @GROUP_BY = 'XXX' THEN ''
					WHEN @GROUP_BY = 'NEW_UNREAD' THEN
						CASE WHEN C.READ_ALERT = 1 THEN 'Read' ELSE 'Not Read' END
					WHEN @GROUP_BY = 'CAT' THEN AC.ALERT_DESC
					WHEN @GROUP_BY = 'PRIORITY' THEN
						CASE
						WHEN A.[PRIORITY] = 1 THEN '1,Highest'
						WHEN A.[PRIORITY] = 2 THEN '2,High'
						WHEN A.[PRIORITY] = 3 THEN '3,Normal'
						WHEN A.[PRIORITY] = 4 THEN '4,Low'
						WHEN A.[PRIORITY] = 5 THEN '5,Lowest'
						ELSE '3,Normal' END
					WHEN @GROUP_BY = 'DUE_DATE' THEN DATENAME(dw, C.DUE_DATE) + ',' + SPACE(1) + DATENAME(m, C.DUE_DATE) + SPACE(1) + CAST(DAY(C.DUE_DATE) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(C.DUE_DATE) AS CHAR(4))
					WHEN @GROUP_BY = 'DUE_DATE_ASC' THEN DATENAME(dw, C.DUE_DATE) + ',' + SPACE(1) + DATENAME(m, C.DUE_DATE) + SPACE(1) + CAST(DAY(C.DUE_DATE) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(C.DUE_DATE) AS CHAR(4))
					WHEN @GROUP_BY = 'VER_BLD' THEN SV.[VERSION] + '.' + SB.BUILD
					WHEN @GROUP_BY = 'STATE' THEN 
						CASE WHEN ALS.ALERT_STATE_ID IS NULL THEN 'None' ELSE ALS.ALERT_STATE_NAME END
					WHEN @GROUP_BY = 'LAST_UPD' THEN DATENAME(dw, A.LAST_UPDATED) + ',' + SPACE(1) + DATENAME(m, A.LAST_UPDATED) + SPACE(1) + CAST(DAY(A.LAST_UPDATED) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(A.LAST_UPDATED) AS CHAR(4))
					WHEN @GROUP_BY = 'C' THEN CL.CL_NAME
					WHEN @GROUP_BY = 'CD' THEN D.DIV_NAME
					WHEN @GROUP_BY = 'CDP' THEN P.PRD_DESCRIPTION
					WHEN @GROUP_BY = 'CDPJ' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + ISNULL(JL.JOB_DESC, '') + ' | ' + CL.CL_NAME
					WHEN @GROUP_BY = 'CDPJC' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6 ) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3) + ' - ' + ISNULL(JC.JOB_COMP_DESC, '') + ' | ' + CL.CL_NAME
					WHEN @GROUP_BY = 'CM' THEN ISNULL(CMP.CMP_NAME, '')
					WHEN @GROUP_BY = 'TS' THEN CASE WHEN C.TaskStatus = 'P' THEN 'Projected' WHEN C.TaskStatus = 'A' THEN 'Active' ELSE NULL END
					ELSE ''
				END,
	IsAutoRoute = ISNULL(ANH.AUTO_NXT_STATE, 0),
	IsProof = ISNULL(C.IsProof, 0)
FROM #Cards C
	INNER JOIN dbo.ALERT A WITH(NOLOCK) ON C.ALERT_ID = A.ALERT_ID 
	INNER JOIN dbo.ALERT_TYPE [AT] WITH(NOLOCK) ON A.ALERT_TYPE_ID = [AT].ALERT_TYPE_ID 
	INNER JOIN dbo.ALERT_CATEGORY AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID 
	LEFT OUTER JOIN dbo.JOB_LOG JL WITH(NOLOCK) ON A.JOB_NUMBER = JL.JOB_NUMBER 
	LEFT OUTER JOIN dbo.JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
	LEFT OUTER JOIN dbo.CLIENT CL WITH(NOLOCK) ON A.CL_CODE = CL.CL_CODE
	LEFT OUTER JOIN dbo.DIVISION D WITH(NOLOCK) ON A.CL_CODE = D.CL_CODE AND A.DIV_CODE = D.DIV_CODE
	LEFT OUTER JOIN dbo.PRODUCT P WITH(NOLOCK) ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE
	LEFT OUTER JOIN dbo.CAMPAIGN CMP WITH(NOLOCK) ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
	LEFT OUTER JOIN dbo.ALERT_STATES ALS WITH(NOLOCK) ON A.ALERT_STATE_ID = ALS.ALERT_STATE_ID 
	LEFT OUTER JOIN dbo.SOFTWARE_VERSION SV WITH(NOLOCK) ON A.VER = SV.VERSION_ID
	LEFT OUTER JOIN dbo.SOFTWARE_BUILD SB WITH(NOLOCK) ON A.BUILD = SB.BUILD_ID
	LEFT OUTER JOIN dbo.SPRINT_DTL SD WITH(NOLOCK) ON A.ALERT_ID = SD.ALERT_ID 	
	LEFT OUTER JOIN dbo.SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID AND COALESCE(SH.IS_COMPLETE, 0) = 0
	LEFT OUTER JOIN dbo.ALERT_NOTIFY_HDR ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID
WHERE 
	(@INCLUDE_BACKLOG = 0 AND (
								C.JobIsOnBoard = 0
							 OR
								(C.JobIsOnBoard = 1 AND SD.ALERT_ID IS NOT NULL AND SH.IS_ACTIVE = 1)
							 OR
								(C.JobIsOnBoard = 1 AND SD.ALERT_ID IS NULL AND A.ALERT_CAT_ID = 71 AND COALESCE(C.EXCLUDE_TASKS, 0) = 1)
							 OR
								(C.IsAlertCC = 1 AND COALESCE(A.IS_WORK_ITEM, 0) = 0)
							  )
	)
	OR @INCLUDE_BACKLOG = 1

DROP TABLE #Cards;

GO