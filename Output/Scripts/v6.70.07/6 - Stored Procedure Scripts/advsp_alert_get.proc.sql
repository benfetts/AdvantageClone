﻿IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_get]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_get]
GO
CREATE PROCEDURE [dbo].[advsp_alert_get] 
@ALERT_ID INT,
@EMP_CODE VARCHAR(6),
@CDP_CONTACT_ID INT,
@OFFSET [DECIMAL](9,3),
@SPRINT_ID INT
AS
BEGIN
			
	DECLARE
		@COMMENT_COUNT INT,
		@ATTACHMENT_COUNT INT,
		@IS_MY_ALERT_OPEN BIT,
		@IS_MY_ALERT_DISMISSED BIT,
		@MY_ALERT_DISMISSED_DATE SMALLDATETIME,
		@IS_MY_ASSIGNMENT_OPEN BIT,
		@IS_MY_ASSIGNMENT_COMPLETED BIT,
		@READ_STATUS SMALLINT,
		@WAS_MARKED_READ BIT,
		@IS_ACTIVE TINYINT,
		@IS_ACTIVE_CP TINYINT,
		@IS_MY_ASSIGNMENT BIT,
		@IS_MY_ALERT BIT,
		@IS_TASK BIT,
		@IS_MY_TASK BIT,
		@IS_MY_TASK_TEMP_COMPLETE BIT,
		@IS_WORK_ITEM BIT,
		@ALERT_LEVEL VARCHAR(50),
		@JOB_NUMBER INT,
		@JOB_COMPONENT_NBR SMALLINT,
		@TASK_SEQ_NBR SMALLINT,
		@TEMP_COMPLETE_DATE SMALLDATETIME,
		@ALRT_NOTIFY_HDR_ID INT,
		@ALERT_CAT_ID INT
	
	SET @IS_MY_ALERT = 0;
	SET @IS_MY_ASSIGNMENT = 0;
	SET @IS_MY_ALERT_OPEN = 0;
	SET @IS_MY_ALERT_DISMISSED = 0;
	SET @IS_MY_ASSIGNMENT_OPEN = 0;
	SET @IS_MY_ASSIGNMENT_COMPLETED = 0;
	SET @IS_TASK = 0
	SET @IS_MY_TASK = 0;
	SET @IS_MY_TASK_TEMP_COMPLETE = 0;
	SET @WAS_MARKED_READ = 0;
	SET @ALERT_CAT_ID = 0;
	
	SELECT @COMMENT_COUNT = COUNT(1) FROM ALERT_COMMENT WITH (NOLOCK) WHERE (ALERT_COMMENT.ALERT_ID = @ALERT_ID);
	SELECT @ATTACHMENT_COUNT = COUNT(1) FROM ALERT_ATTACHMENT WITH(NOLOCK) WHERE (ALERT_ATTACHMENT.ALERT_ID = @ALERT_ID);

	SELECT 
		@IS_WORK_ITEM = ISNULL(IS_WORK_ITEM, 0), 
		@ALERT_LEVEL = ALERT_LEVEL,
		@JOB_NUMBER = JOB_NUMBER,
		@JOB_COMPONENT_NBR = JOB_COMPONENT_NBR,
		@TASK_SEQ_NBR = TASK_SEQ_NBR,
		@ALRT_NOTIFY_HDR_ID = ALRT_NOTIFY_HDR_ID,
		@ALERT_CAT_ID = ALERT_CAT_ID
	FROM 
		ALERT WITH(NOLOCK)
	WHERE 
		ALERT_ID = @ALERT_ID;

	IF @CDP_CONTACT_ID IS NULL OR @CDP_CONTACT_ID = 0
		BEGIN
			IF EXISTS (SELECT 1 FROM ALERT_RCPT AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 0 OR AR.CURRENT_NOTIFY IS NULL) AND (AR.CURRENT_RCPT IS NULL OR AR.CURRENT_RCPT = 0))
			BEGIN
				SET @IS_MY_ALERT_OPEN = 1;
			END
			IF @IS_MY_ALERT_OPEN = 0
			BEGIN
				IF EXISTS (SELECT 1 FROM ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 0 OR AR.CURRENT_NOTIFY IS NULL) AND (AR.CURRENT_RCPT IS NULL OR AR.CURRENT_RCPT = 0))
				BEGIN
					SET @IS_MY_ALERT_DISMISSED = 1;
					SELECT @MY_ALERT_DISMISSED_DATE = PROCESSED FROM ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK) WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 0 OR AR.CURRENT_NOTIFY IS NULL)
				END
			END
			IF @IS_MY_ALERT_OPEN = 1 OR @IS_MY_ALERT_DISMISSED = 1
			BEGIN
				SET @IS_MY_ALERT = 1;
			END
			IF @IS_MY_ASSIGNMENT = 0
			BEGIN
				IF @IS_WORK_ITEM = 1 AND (@ALRT_NOTIFY_HDR_ID IS NULL OR @ALRT_NOTIFY_HDR_ID = 0)  
				BEGIN
					IF EXISTS (SELECT 1 FROM ALERT_RCPT AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 1))
					BEGIN
						SET @IS_MY_ASSIGNMENT = 1;
						SET @IS_MY_ASSIGNMENT_OPEN = 1;
					END
					IF EXISTS (SELECT 1 FROM ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 1))
					BEGIN
						SET @IS_MY_ASSIGNMENT = 1;
						SET @IS_MY_ASSIGNMENT_OPEN = 0;
					END
				END
			END
			IF @IS_MY_ASSIGNMENT = 0
			BEGIN
				IF @IS_WORK_ITEM = 1 AND (NOT @ALRT_NOTIFY_HDR_ID IS NULL AND @ALRT_NOTIFY_HDR_ID > 0) 
				BEGIN
					IF EXISTS (SELECT 1 FROM ALERT_RCPT AS AR WITH(NOLOCK) INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID AND A.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AR.ALERT_STATE_ID  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 1))
					BEGIN
						SET @IS_MY_ASSIGNMENT = 1;
						SET @IS_MY_ASSIGNMENT_OPEN = 1;
					END
					IF EXISTS (SELECT 1 FROM ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK)  INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID AND A.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AR.ALERT_STATE_ID   WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 1))
					BEGIN
						SET @IS_MY_ASSIGNMENT = 1;
						SET @IS_MY_ASSIGNMENT_OPEN = 0;
					END
				END
			END
			IF @IS_MY_ASSIGNMENT_OPEN = 0 AND @IS_MY_ASSIGNMENT = 1
			BEGIN
				IF EXISTS (SELECT 1 FROM ALERT_RCPT AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND (AR.CURRENT_NOTIFY = 1))
				BEGIN
					SET @IS_MY_ASSIGNMENT_OPEN = 1;
				END
			END
			IF @IS_MY_ASSIGNMENT_OPEN = 0 AND @IS_MY_ASSIGNMENT = 1
			BEGIN
				IF EXISTS (SELECT 1 FROM ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND (AR.CURRENT_NOTIFY = 1)) -- REMOVE EMP CODE TO ALLOW ALL
				BEGIN
					SET @IS_MY_ASSIGNMENT_COMPLETED = 1;
				END
			END
			IF @IS_MY_ALERT_OPEN = 1 OR @IS_MY_ASSIGNMENT_OPEN = 1
			BEGIN
				SELECT @READ_STATUS = COUNT(1) FROM ALERT_RCPT AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND ISNULL(AR.READ_ALERT, 0) = 0;
				IF @READ_STATUS >= 1
				BEGIN
					UPDATE ALERT_RCPT WITH(ROWLOCK) SET READ_ALERT = 1, NEW_ALERT = NULL WHERE ALERT_ID = @ALERT_ID AND EMP_CODE = @EMP_CODE;
					SET @WAS_MARKED_READ = 1;
				END
			END
			IF @IS_MY_ALERT_DISMISSED = 1 OR @IS_MY_ASSIGNMENT_COMPLETED = 1
			BEGIN
				SELECT @READ_STATUS = COUNT(1) FROM ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.EMP_CODE = @EMP_CODE AND ISNULL(AR.READ_ALERT, 0) = 0;
				IF @READ_STATUS >= 1
				BEGIN
					UPDATE ALERT_RCPT_DISMISSED WITH(ROWLOCK) SET READ_ALERT = 1, NEW_ALERT = NULL WHERE ALERT_ID = @ALERT_ID AND EMP_CODE = @EMP_CODE;
					SET @WAS_MARKED_READ = 1;
				END
			END
			IF @ALERT_CAT_ID = 71 OR @ALERT_LEVEL = 'BRD' OR @ALERT_LEVEL = 'PST'
			BEGIN
				SET @IS_TASK = 1;
				 IF EXISTS (SELECT 1 FROM JOB_TRAFFIC_DET_EMPS JTDE WHERE JTDE.JOB_NUMBER = @JOB_NUMBER AND JTDE.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND JTDE.SEQ_NBR = @TASK_SEQ_NBR AND JTDE.EMP_CODE = @EMP_CODE)
				 BEGIN
					SET @IS_MY_TASK = 1;
					SELECT @TEMP_COMPLETE_DATE = TEMP_COMP_DATE FROM JOB_TRAFFIC_DET_EMPS JTDE WHERE JTDE.JOB_NUMBER = @JOB_NUMBER AND JTDE.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND JTDE.SEQ_NBR = @TASK_SEQ_NBR AND JTDE.EMP_CODE = @EMP_CODE;
					IF NOT @TEMP_COMPLETE_DATE IS NULL
					BEGIN
						SET @IS_MY_TASK_TEMP_COMPLETE = 1;
					END
				 END
				 IF DATALENGTH(@EMP_CODE) > 0
				 BEGIN
					UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) 
					SET READ_ALERT = 1 
					WHERE 
						JOB_NUMBER = @JOB_NUMBER
						AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
						AND SEQ_NBR = @TASK_SEQ_NBR
						AND EMP_CODE = @EMP_CODE;
				 END
			END
		END
		ELSE
		BEGIN
			IF EXISTS (SELECT 1 FROM CP_ALERT_RCPT AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID AND (AR.CURRENT_NOTIFY = 0 OR AR.CURRENT_NOTIFY IS NULL))
			BEGIN
				SET @IS_MY_ALERT_OPEN = 1;
			END
			IF @IS_MY_ALERT_OPEN = 0
			BEGIN
				IF EXISTS (SELECT 1 FROM CP_ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID AND (AR.CURRENT_NOTIFY = 0 OR AR.CURRENT_NOTIFY IS NULL))
				BEGIN
					SET @IS_MY_ALERT_DISMISSED = 1;
					SELECT @MY_ALERT_DISMISSED_DATE = PROCESSED FROM CP_ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK) WHERE AR.ALERT_ID = @ALERT_ID AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID AND (AR.CURRENT_NOTIFY = 0 OR AR.CURRENT_NOTIFY IS NULL)
				END
			END
			IF @IS_MY_ALERT_OPEN = 1 
			BEGIN
				SELECT @READ_STATUS = READ_ALERT FROM CP_ALERT_RCPT AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID;
				IF @READ_STATUS IS NULL OR @READ_STATUS = 0
				BEGIN
					UPDATE CP_ALERT_RCPT WITH(ROWLOCK) SET READ_ALERT = 1 WHERE ALERT_ID = @ALERT_ID AND CDP_CONTACT_ID = @CDP_CONTACT_ID;
					SET @WAS_MARKED_READ = 1;
				END
			END
			IF @IS_MY_ALERT_DISMISSED = 1 
			BEGIN
				SELECT @READ_STATUS = READ_ALERT FROM CP_ALERT_RCPT_DISMISSED AS AR WITH(NOLOCK)  WHERE AR.ALERT_ID = @ALERT_ID AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID;
				IF @READ_STATUS IS NULL OR @READ_STATUS = 0
				BEGIN
					UPDATE CP_ALERT_RCPT_DISMISSED WITH(ROWLOCK) SET READ_ALERT = 1 WHERE ALERT_ID = @ALERT_ID AND CDP_CONTACT_ID = @CDP_CONTACT_ID;
					SET @WAS_MARKED_READ = 1;
				END
			END
		END

SELECT
	A.[ID],
	A.[AlertLevel],
	A.[AlertLevelDisplay],
	A.[AlertTypeID],
	A.[AlertTypeDescription],
	A.[GeneratedDate],
	A.[OriginatedDate],
	A.[IsCPAlert],
	A.[UserName],
	A.[UserCode],
	A.[GeneratedByEmployeeCode],
	A.[GeneratedByEmployeeName],
	A.[EmployeeCode],
	A.[OfficeCode],
	A.[OfficeName],
	A.[ClientCode],
	A.[ClientName],
	A.[DivisionCode],
	A.[DivisionName],
	A.[ProductCode],
	A.[ProductName],
	A.[CampaignID],
	A.[CampaignCode],
	A.[CampaignName],
	A.[JobNumber],
	A.[JobDescription],
	A.[JobComponentNumber],
	A.[JobComponentDescription],
	A.[TaskFunctionDescription],
	A.[AlertCategoryID],
	A.[AlertCategoryDescription],
	A.[PriorityLevel],
	A.[PriorityDescription],
	A.[DueDate],
	A.[StartDate],
	A.[TimeDue],
	A.[Subject],
	A.[Body],
	A.[EmailBody],
	A.[AlertAssignmentTemplateID],
	A.[AlertAssignmentTemplateName],
	A.[AlertStateID],
	A.[AlertStateName],
	A.[AlertSequenceNumber],
	A.[DisplayID],
	A.[IsAlertAssignment],
	A.[CommentCount],
	A.[Version],
	A.[Build],
	A.[AttachmentCount],
	A.[VersionName],
	A.[BuildName],
	A.[TaskSequenceNumber],
	A.[AccountPayableID],
	A.[AccountPayableSequenceNumber],
	A.[IsCompleted],
	A.[IsMyAlertOpen],
	A.[IsMyAlertDismissed],
	A.[MyAlertDismissedDate],
	A.[IsMyAssignmentOpen],
	A.[IsMyAssignmentCompleted],
	A.[MediaATBRevisionID],
	A.[MediaATBNumber],
	A.[MediaATBRevisionNumber],
	A.[MediaATBDescription],
	A.[WasMarkedRead],
	A.[SprintID],
	A.[SprintDescription],
	A.[BoardID],
	A.[BoardHeaderID],
	A.[BoardHeaderDescription],
	A.[BoardName],
	A.[BoardStateID],
	A.[BoardStateName],
	A.[IsWorkItem],
	A.[AssignedEmployeeCode],
	A.[AssignedEmployeeName],
	A.[HoursAllowed],
	A.[HoursPosted],
	A.[HoursAllocated],
	[HoursBalance] = 0.00,
	[HoursAllocatedBalance] = 0.00,
	A.[IsMyAlert],
	A.[IsMyAssignment],
	A.[IsTask],
	A.[IsMyTask],
	A.[IsMyTaskTempComplete],
	A.[CompletedDate],
	A.[DueDateLocked],
	A.[IsMultiRoute],
	A.[IsRouted],
	A.[JobHours],
	A.[IsAutoRoute],
	A.[TaskStatusCode],
	A.[TaskStatusDescription]
FROM
	(SELECT TOP (1) 
		[ID] = ALERT.ALERT_ID, 
		[AlertLevel] = ALERT.ALERT_LEVEL, 
		[AlertLevelDisplay] = CASE 
									WHEN ALERT_LEVEL = 'OF' THEN 'Office' 
									WHEN ALERT_LEVEL = 'CL' THEN 'Client' 
									WHEN ALERT_LEVEL = 'DI' THEN 'Division' 
									WHEN ALERT_LEVEL = 'PR' THEN 'Product' 
									WHEN ALERT_LEVEL = 'CM' THEN 'Campaign' 
									WHEN ALERT_LEVEL = 'JO' THEN 'Job' 
									WHEN (ALERT_LEVEL = 'JJ' OR ALERT_LEVEL = 'JC') THEN 'Job Component' 
									WHEN ALERT_LEVEL = 'PS' THEN 'Project Schedule' 
									WHEN ALERT_LEVEL = 'PST' THEN 'Project Schedule Task' 
									WHEN ALERT_LEVEL = 'ES' THEN 'Estimate' 
									WHEN ALERT_LEVEL = 'EST' THEN 'Estimate Component'
									WHEN ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'  
									ELSE '' 
								END, 
		[AlertTypeID] = ALERT.ALERT_TYPE_ID, 
		[AlertTypeDescription] = ALERT_TYPE.ALERT_TYPE_DESC, 
		[GeneratedDate] = CASE @OFFSET
								WHEN 0 THEN ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)
								ELSE ISNULL(DATEADD(mi, (CONVERT(INT, @OFFSET) * 60) + (@OFFSET - CONVERT(INT, @OFFSET)), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED))
							END, 
		[OriginatedDate] = CASE @OFFSET
							WHEN 0 THEN ALERT.GENERATED
							ELSE ISNULL(DATEADD(mi, (CONVERT(INT, @OFFSET) * 60) + (@OFFSET - CONVERT(INT, @OFFSET)), ALERT.GENERATED), ALERT.GENERATED)
						END,
		[IsCPAlert] = ALERT.CP_ALERT, 
		[UserName] = CASE 
						WHEN ((ALERT.EMP_CODE IS NULL)) AND (ALERT.ALERT_USER_CP IS NOT NULL) THEN (SELECT CONT_FML	FROM CDP_CONTACT_HDR WITH (NOLOCK) WHERE CDP_CONTACT_ID = CAST(ALERT.ALERT_USER AS INT)) 
						ELSE SEC_USER.[USER_NAME] 
					 END, 
		[UserCode] = ALERT.ALERT_USER,
		[GeneratedByEmployeeCode] = SU2.EMP_CODE, 		
		[GeneratedByEmployeeName] = EMPLOYEE.EMP_FNAME + ISNULL(' ' + EMPLOYEE.EMP_MI + '. ', ' ') + EMPLOYEE.EMP_LNAME, 
		[EmployeeCode] = ALERT.EMP_CODE, 
		[OfficeCode] = ALERT.OFFICE_CODE, 
		[OfficeName] = OFFICE.OFFICE_NAME, 
		[ClientCode] = ALERT.CL_CODE, 
		[ClientName] = CLIENT.CL_NAME, 
		[DivisionCode] = ALERT.DIV_CODE, 
		[DivisionName] = DIVISION.DIV_NAME,
		[ProductCode] = ALERT.PRD_CODE, 
		[ProductName] = PRODUCT.PRD_DESCRIPTION, 
		[CampaignID] = ALERT.CMP_IDENTIFIER, 
		[CampaignCode] = CAMPAIGN.CMP_CODE, 
		[CampaignName] = CAMPAIGN.CMP_NAME, 
		[JobNumber] = ALERT.JOB_NUMBER, 
		[JobDescription] = JOB_LOG.JOB_DESC, 
		[JobComponentNumber] = ALERT.JOB_COMPONENT_NBR, 
		[JobComponentDescription] = JOB_COMPONENT.JOB_COMP_DESC,
		[TaskFunctionDescription] = CASE WHEN JOB_TRAFFIC_DET.FNC_CODE IS NULL THEN JOB_TRAFFIC_DET.TASK_DESCRIPTION ELSE TRAFFIC_FNC.TRF_DESC END,			
		[AlertCategoryID] = ALERT.ALERT_CAT_ID, 
		[AlertCategoryDescription] = ALERT_CATEGORY.ALERT_DESC, 
		[PriorityLevel] = ISNULL(ALERT.[PRIORITY], 2), 
		[PriorityDescription] = CASE ALERT.[PRIORITY]
									WHEN 1 THEN 'Highest' 
									WHEN 2 THEN 'High' 
									WHEN 3 THEN 'Normal' 
									WHEN 4 THEN 'Low' 
									WHEN 5 THEN 'Lowest' 
									ELSE 'Normal' 
								END, 
		[StartDate] = CASE 
						WHEN ALERT.ALERT_CAT_ID = 71 THEN JOB_TRAFFIC_DET.TASK_START_DATE
                        WHEN ISNULL(ALERT.NON_TASK_ID,0) > 0 AND ALERT.[START_DATE] IS NULL THEN EMP_NON_TASKS.[START_DATE]
						ELSE ALERT.[START_DATE]
					END, 
		[DueDate] = CASE 
						WHEN ALERT.ALERT_CAT_ID = 71 THEN JOB_TRAFFIC_DET.JOB_REVISED_DATE
						ELSE ALERT.DUE_DATE
					END, 
		[TimeDue] = CASE 
						WHEN ALERT.ALERT_CAT_ID = 71 THEN JOB_TRAFFIC_DET.REVISED_DUE_TIME
						ELSE ALERT.TIME_DUE 
					END, 
		[Subject] = CASE 
						WHEN ALERT.ALERT_CAT_ID = 71 THEN ISNULL(TRAFFIC_FNC.TRF_DESC, JOB_TRAFFIC_DET.TASK_DESCRIPTION)
						ELSE ALERT.[SUBJECT] 
					END,
		[Body] = ALERT.BODY,
		[EmailBody] = ALERT.BODY_HTML, 
		[AlertAssignmentTemplateID] = ALERT.ALRT_NOTIFY_HDR_ID, 
		[AlertAssignmentTemplateName] = ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,
		[AlertStateID] = ALERT.ALERT_STATE_ID, 
		[AlertStateName] = ALERT_STATES.ALERT_STATE_NAME, 
		[AlertSequenceNumber] = ALERT.ALERT_SEQ_NBR, 
		[DisplayID] = COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID), 
		[IsAlertAssignment] = CONVERT(BIT, CASE 
											WHEN (ALERT.ALRT_NOTIFY_HDR_ID > 0) AND (ALERT.ALERT_STATE_ID > 0) THEN 1 
											ELSE 0 
										  END), 
		[CommentCount] = ISNULL(@COMMENT_COUNT, 0), 
		[Version] = ALERT.VER, 
		[Build] = ALERT.BUILD, 
		[AttachmentCount] = ISNULL(@ATTACHMENT_COUNT, 0), 
		[VersionName] = SOFTWARE_VERSION.[VERSION], 
		[BuildName] = SOFTWARE_BUILD.BUILD, 
		[TaskSequenceNumber] = ALERT.TASK_SEQ_NBR,
		[AccountPayableID] = ALERT.AP_ID, 
		[AccountPayableSequenceNumber] = ALERT.AP_SEQ,
		[IsCompleted] = CONVERT(BIT, ISNULL(ALERT.ASSIGN_COMPLETED, 0)),
		[IsMyAlertOpen] = ISNULL(@IS_MY_ALERT_OPEN, 0), 
		[IsMyAlertDismissed] = ISNULL(@IS_MY_ALERT_DISMISSED, 0), 
		[MyAlertDismissedDate] = @MY_ALERT_DISMISSED_DATE,
		[IsMyAssignmentOpen] = ISNULL(@IS_MY_ASSIGNMENT_OPEN, 0), 
		[IsMyAssignmentCompleted] = ISNULL(@IS_MY_ASSIGNMENT_COMPLETED, 0),
		[MediaATBRevisionID] = ALERT.ATB_REV_ID,
		[MediaATBNumber] = ATB_REV.ATB_NUMBER,
		[MediaATBRevisionNumber] = ATB_REV.REV_NBR,
		[MediaATBDescription] = ATB_REV.ATB_DESCRIPTION,
		[WasMarkedRead] = ISNULL(@WAS_MARKED_READ, 0),
		[SprintID] = SPRINT_HDR.ID,
		[SprintDescription] = SPRINT_HDR.[DESCRIPTION],
		[BoardID] = SPRINT_HDR.BOARD_ID,
		[BoardHeaderID] = BOARD_HDR.ID,
		[BoardHeaderDescription] = BOARD_HDR.[DESCRIPTION],
		[BoardName] = BOARD.NAME,
		[BoardStateID] = CASE WHEN ISNULL(SPRINT_HDR.ID, 0) = 0 THEN NULL ELSE ISNULL(ALERT.BOARD_STATE_ID, -1) END,
		[BoardStateName] = CASE WHEN ISNULL(SPRINT_HDR.ID, 0) = 0 THEN '' ELSE ISNULL(BOARD_STATE.ALERT_STATE_NAME, 'Backlog') END,
		[IsWorkItem] = CONVERT(BIT, ISNULL(ALERT.IS_WORK_ITEM, 0)),
		[AssignedEmployeeCode] = NULL,
		[AssignedEmployeeName] = NULL,
		[HoursAllowed] = 0.00,
		[HoursPosted] = 0.00,
		[HoursAllocated] = 0.00,
		[IsMyAssignment] = ISNULL(@IS_MY_ASSIGNMENT, 0),
		[IsMyAlert] = ISNULL(@IS_MY_ALERT, 0),
		[IsTask] = ISNULL(@IS_TASK, 0),
		[IsMyTask] = ISNULL(@IS_MY_TASK, 0),
		[IsMyTaskTempComplete] = ISNULL(@IS_MY_TASK_TEMP_COMPLETE, 0),
		[CompletedDate] = JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,
		[JobHours] = JOB_TRAFFIC_DET.JOB_HRS,
		[DueDateLocked] = CASE WHEN JOB_TRAFFIC_DET.DUE_DATE_LOCK = 1 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END,
		[IsMultiRoute] = CASE WHEN ALERT_NOTIFY_HDR.[TYPE] = 1 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END,
		[IsRouted] = CASE WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALRT_NOTIFY_HDR_ID > 0 AND NOT ALERT.ALERT_STATE_ID IS NULL AND ALERT.ALERT_STATE_ID > 0 THEN CAST(1 AS BIT)
					 ELSE CAST(0 AS BIT)
					 END,
		[IsAutoRoute] = ISNULL(ALERT_NOTIFY_HDR.AUTO_NXT_STATE, 0),
		[TaskStatusCode] = JOB_TRAFFIC_DET.TASK_STATUS,
		[TaskStatusDescription] =	CASE
										WHEN UPPER(RTRIM(LTRIM(JOB_TRAFFIC_DET.TASK_STATUS))) = 'A' THEN 'Active'
										ELSE 'Projected'
									END
	FROM         
		dbo.CLIENT WITH (NOLOCK) 
	RIGHT OUTER JOIN
		dbo.ALERT_NOTIFY_HDR WITH (NOLOCK) 
	RIGHT OUTER JOIN
		dbo.SEC_USER WITH (NOLOCK) 
	RIGHT OUTER JOIN
		dbo.SOFTWARE_VERSION WITH (NOLOCK) 
	RIGHT OUTER JOIN
		dbo.SOFTWARE_BUILD WITH (NOLOCK) 
	RIGHT OUTER JOIN
		dbo.ALERT WITH (NOLOCK) 
	LEFT OUTER JOIN
		dbo.JOB_TRAFFIC_DET WITH (NOLOCK) ON ALERT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND
											 ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND
											 ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR
	LEFT OUTER JOIN
		dbo.TRAFFIC_FNC WITH(NOLOCK) ON JOB_TRAFFIC_DET.FNC_CODE = TRAFFIC_FNC.TRF_CODE
	INNER JOIN
		dbo.ALERT_TYPE WITH (NOLOCK) ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID 
	INNER JOIN
		dbo.ALERT_CATEGORY WITH (NOLOCK) ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID ON SOFTWARE_BUILD.VERSION_ID = ALERT.VER AND 
											SOFTWARE_BUILD.BUILD_ID = ALERT.BUILD ON SOFTWARE_VERSION.VERSION_ID = ALERT.VER ON 
											SEC_USER.EMP_CODE = ALERT.EMP_CODE 
	LEFT OUTER JOIN
		dbo.ALERT_STATES WITH (NOLOCK) ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID ON 
										  ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID = ALERT.ALRT_NOTIFY_HDR_ID 
	LEFT OUTER JOIN
		dbo.JOB_COMPONENT WITH (NOLOCK) ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
										   ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR 
	LEFT OUTER JOIN
		dbo.PRODUCT WITH (NOLOCK) ON ALERT.CL_CODE = PRODUCT.CL_CODE AND ALERT.DIV_CODE = PRODUCT.DIV_CODE AND 
									 ALERT.PRD_CODE = PRODUCT.PRD_CODE 
	LEFT OUTER JOIN
		dbo.JOB_LOG WITH (NOLOCK) ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
	LEFT OUTER JOIN
		dbo.CAMPAIGN WITH (NOLOCK) ON ALERT.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER 
	LEFT OUTER JOIN
		dbo.OFFICE WITH (NOLOCK) ON ALERT.OFFICE_CODE = OFFICE.OFFICE_CODE 
	LEFT OUTER JOIN
		dbo.DIVISION WITH (NOLOCK) ON ALERT.CL_CODE = DIVISION.CL_CODE AND 
									  ALERT.DIV_CODE = DIVISION.DIV_CODE ON CLIENT.CL_CODE = ALERT.CL_CODE 
	LEFT OUTER JOIN
		dbo.ATB_REV WITH(NOLOCK) ON ALERT.ATB_REV_ID = ATB_REV.ATB_REV_ID
	LEFT OUTER JOIN
	   SPRINT_DTL SD WITH (NOLOCK) ON SD.ALERT_ID = ALERT.ALERT_ID
	LEFT OUTER JOIN
		dbo.SPRINT_HDR WITH (NOLOCK) ON SD.SPRINT_HDR_ID = SPRINT_HDR.ID OR SPRINT_HDR.ID = @SPRINT_ID
	LEFT OUTER JOIN
		dbo.BOARD WITH (NOLOCK) ON SPRINT_HDR.BOARD_ID = BOARD.ID
	LEFT OUTER JOIN
		dbo.BOARD_HDR WITH (NOLOCK) ON BOARD.BOARD_HDR_ID = BOARD_HDR.ID
	LEFT OUTER JOIN
		dbo.ALERT_STATES BOARD_STATE WITH (NOLOCK) ON ALERT.BOARD_STATE_ID = BOARD_STATE.ALERT_STATE_ID
	LEFT OUTER JOIN
		dbo.SEC_USER SU2 WITH (NOLOCK) ON UPPER(ALERT.ALERT_USER) = UPPER(SU2.USER_CODE)
	LEFT OUTER JOIN
		dbo.EMPLOYEE WITH (NOLOCK) ON SU2.EMP_CODE = EMPLOYEE.EMP_CODE
    LEFT OUTER JOIN
        dbo.EMP_NON_TASKS WITH (NOLOCK) ON ALERT.NON_TASK_ID = EMP_NON_TASKS.NON_TASK_ID
	WHERE  
		(ALERT.ALERT_ID = @ALERT_ID) AND
		1 = CASE WHEN ISNULL(@SPRINT_ID, 0) = 0 THEN 1 WHEN SPRINT_HDR.ID = @SPRINT_ID THEN 1 ELSE 0 END) AS A
			
END
GO
