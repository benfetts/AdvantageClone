IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_aam]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_aam]
GO
CREATE PROCEDURE [dbo].[advsp_alert_aam]
@UserCode AS VARCHAR(100) = NULL,
@EmployeeCode AS VARCHAR(140) = NULL,
@SearchCriteria AS VARCHAR(1000) = NULL,
@InboxType AS VARCHAR(50) = NULL,
 -- inbox "Current"
 -- dismissed "Dismissed/Completed"
--  all used to be  "Received" now "All"
 -- drafts
@ShowAssignmentType AS VARCHAR(50) = NULL, 
 -- myalertsandassignments (for job inbox, this shows ALL alerts & assignments)
 -- myalerts (for job inbox, this shows all alerts)
 -- myalertassignments
 -- myreviews
 -- allalertassignments
 -- unassigned
@IsJobAlertsPage AS BIT = NULL,
@JobNumber AS INT = NULL,
@JobComponentNumber AS SMALLINT = NULL,
@StartDate AS SMALLDATETIME = NULL,
@EndDate AS SMALLDATETIME = NULL,
@IncludeCompletedAssignments AS BIT = NULL,
@GroupBy AS VARCHAR(6) = NULL,
@RecordsToReturn AS Integer = NULL,
@IsCount AS BIT = NULL,
@RecordCount AS Integer = NULL,
@IncludeReviews AS BIT = NULL,
@IncludeBoardLevel AS BIT = NULL,
@IncludeBacklog AS BIT = NULL,
@ShowOnlyTempComp as BIT = NULL,
@EmployeeRole as VARCHAR(140) = NULL,
@Department as VARCHAR(100) = NULL

WITH RECOMPILE
AS
/*************	QUERY  *************/
BEGIN
	-- TABLES / VARIABLES
	BEGIN		
		CREATE TABLE #ALERT (	ROW_ID INT IDENTITY, 
								ALERT_ID INT, 
								LAST_UPDATED SMALLDATETIME,
								ALERT_LEVEL VARCHAR(25),
								ALERT_CAT_ID INT,
								JOB_NUMBER INT,
								JOB_COMPONENT_NBR SMALLINT,
								TASK_SEQ_NBR SMALLINT,
								TASK_STATUS VARCHAR(1) DEFAULT '',
								IS_WORK_ITEM BIT,
								IS_ROUTED_ASSIGNMENT BIT,
								IS_NONROUTED_ASSIGNMENT BIT,
								IS_TASK_ASSIGNMENT BIT,
								IS_TASK_COMPLETED BIT,
								ALRT_NOTIFY_HDR_ID INT,
								ALERT_STATE_ID INT,
								BOARD_STATE_ID INT,
								ASSIGN_COMPLETED BIT,
								ATTACHMENT_COUNT INT,
								TASK_FNC_CODE VARCHAR(10),
								TASK_DESCRIPTION VARCHAR(100),
								CURRENT_NOTIFY BIT,
								CURRENT_NOTIFY_EMP_FML VARCHAR(1000)  COLLATE SQL_Latin1_General_CP1_CS_AS,
								CURRENT_NOTIFY_EMP_CODE VARCHAR(6)   COLLATE SQL_Latin1_General_CP1_CS_AS DEFAULT '',
								IS_CC BIT,
								IS_CC_DISMISSED BIT,
								IS_MY_ASSIGNMENT BIT,
								IS_MY_ASSIGNMENT_COMPLETED BIT,
								IS_MY_ALERT BIT,
								IS_MY_ALERT_COMPLETED BIT,
								IS_MY_TASK BIT,
								IS_ALERT BIT,
								COMPLETE_ASSIGNEES_CT SMALLINT,
								OPEN_ASSIGNEES_CT SMALLINT,
								DISMISSED_RECIPIENTS_CT SMALLINT,
								OPEN_RECIPIENTS_CT SMALLINT,
								IS_STANDARD_ALERT BIT,
								IS_UNASSIGNED BIT,
								USER_ORDER_SEQ_NBR INT,
								CHECKLIST_COUNT INT,
								CHECKLIST_COMPLETE_COUNT INT,
								IS_READ BIT,
								AE_CODE VARCHAR(6),
								AE_NAME VARCHAR(200),
								PM_CODE VARCHAR(6),
								PM_NAME VARCHAR(200),	
								IS_MY_TASK_TEMP_COMPLETE BIT,
								TEMP_COMPLETE_DATE SMALLDATETIME,
								[START_DATE] SMALLDATETIME,
								DUE_DATE SMALLDATETIME,
								GRP_DUE_DATE_DISPLAY VARCHAR(1000),
								GRP_DUE_DATE VARCHAR(1000),
								--EMP_ROLE_CODE VARCHAR(6),
								--EMP_ROLE_DESCRIPTION VARCHAR(40),
								EMP_IN_ROLE BIT,
								EMP_DEPARTMENT VARCHAR(40)  COLLATE SQL_Latin1_General_CP1_CS_AS,
								IS_OWNER_ASSIGNMENT_ALERT BIT,
								CC_EMPLOYEE_CODES VARCHAR(200),
								CC_EMPLOYEE_NAMES VARCHAR(1000),
								IS_BACKLOG_ITEM BIT,
								BOARD_NAME VARCHAR(50),
								BOARD_EXCLUDE_TASKS BIT
							  );
		CREATE TABLE #INACTIVE_WORK_ITEMS (	ROW_ID INT IDENTITY,
											ALERT_ID INT
										  );

		CREATE TABLE #EMPLOYEES (	EMP_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS	);
		CREATE TABLE #DEPARTMENTS (	DP_TM_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS	);
		CREATE TABLE #ROLES (	ROLE_CODE VARCHAR(6)	);
		--	TEMP TABLE INDICES
		BEGIN
			CREATE NONCLUSTERED INDEX IDX_ALERT_ID ON #ALERT (ALERT_ID);
			CREATE NONCLUSTERED INDEX IDX_JOB_JOB_COMPONENT ON #ALERT (JOB_NUMBER, JOB_COMPONENT_NBR);
			CREATE NONCLUSTERED INDEX IDX_TASK ON #ALERT (JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR);
			CREATE NONCLUSTERED INDEX IDX_ALERT_ID_LAST_UPDATED ON #ALERT (ALERT_ID, LAST_UPDATED);
			CREATE NONCLUSTERED INDEX IDX_IWW_ALERT_ID ON #INACTIVE_WORK_ITEMS (ALERT_ID);
		END
		DECLARE
			@DEBUG BIT,
			@INCL_ALERTS BIT,
			@INCL_ASSIGNMENTS BIT,
			@INCL_ONLY_ME BIT,
			@INCL_COMPLETED BIT,
			@INCL_TASKS BIT,
			@OFFSET DECIMAL,
			@RETURN_TYPE AS TINYINT,
			@HAS_EMP BIT,
			@LOAD_AAM_BASE AS BIT,
			@PM_FIELD AS VARCHAR(20),
			@IS_ALL_WITH_EMP AS BIT,
			@SHOW_TASKS as BIT,			
			@SHOW_ONLY_ALERTS as BIT,
			@SHOW_ONLY_UNASSIGNED as BIT,
			@TASK_VIEW as BIT,
			@Restrictions INT,
			@RestrictionsEmp INT,
			@EMP_CODE AS VARCHAR(6)

		-- SEC CLIENT
		BEGIN
			SELECT DISTINCT USER_ID, CL_CODE, DIV_CODE, PRD_CODE, TIME_ENTRY
					INTO #SEC_CLIENT
					FROM SEC_CLIENT
					WHERE USER_ID = @UserCode
		END
		
			SELECT @Restrictions = COUNT(*) FROM #SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserCode);

			SELECT @RestrictionsEmp = COUNT(*) FROM SEC_EMP WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserCode);
			SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserCode)		
			--SELECT @EMP_CODE,@UserCode
			--SELECT @EmployeeCode,@RestrictionsEmp,@ShowAssignmentType
			if @RestrictionsEmp > 0 AND @ShowAssignmentType = 'allalertassignments'
			BEGIN		
				if @EmployeeCode = '' OR @EmployeeCode IS NULL
				BEGIN				
					SELECT @EmployeeCode = STUFF((SELECT ', ' + EMP_CODE
					  FROM SEC_EMP
					WHERE UPPER(USER_ID) = UPPER(@UserCode)		
					FOR XML PATH('')),1 ,2 ,'')
				END
				

				--SELECT @EmployeeCode = COALESCE(@EmployeeCode + ', ', '') + EMP_CODE
				--FROM SEC_EMP
				--WHERE UPPER(USER_ID) = UPPER(@UserCode)				

		        --SELECT @EmployeeCode
			END
	END
	--	INIT
	BEGIN		
		SELECT
			@DEBUG = 0,
			@INCL_COMPLETED = 0,
			@INCL_TASKS = 1,
			@IsJobAlertsPage = ISNULL(@IsJobAlertsPage, 0),
			@RETURN_TYPE = 0,
			@LOAD_AAM_BASE = 0,
			@InboxType = RTRIM(LTRIM(LOWER(@InboxType))),
			@ShowAssignmentType = RTRIM(LTRIM(LOWER(@ShowAssignmentType))),
			@IS_ALL_WITH_EMP = 0
		;		

		IF @InboxType = 'task'
			BEGIN
				SET @TASK_VIEW = 1;
				SET @SHOW_TASKS = 1;
				SET @InboxType = 'inbox';				
			END
		ELSE
			BEGIN
				SET @TASK_VIEW = 0;
				SET @SHOW_TASKS = 0;
			END

		IF @ShowAssignmentType = 'myalerts' --and @IsJobAlertsPage = 0			
			SET @SHOW_ONLY_ALERTS = 1;							
		ELSE
			SET @SHOW_ONLY_ALERTS = 0;

		if @ShowAssignmentType = 'unassigned'			
			SET @SHOW_ONLY_UNASSIGNED = 1;			
		ELSE
			SET @SHOW_ONLY_UNASSIGNED = 0;


		IF @EmployeeCode IS NULL OR DATALENGTH(@EmployeeCode) = 0
		BEGIN
			SET @HAS_EMP = 0;
		END
		ELSE
		BEGIN
			SET @HAS_EMP = 1;
		END
		IF @EndDate IS NOT NULL
		BEGIN
			SELECT @EndDate = DATEADD(MINUTE, -1, DATEADD(DAY, 1, @EndDate));
		END
		-- OLD DATA
		IF @InboxType IN ('received', 'recieved')
		BEGIN
			SET @InboxType = 'all';
		END
		-- SCHEDULE MANAGER
		BEGIN
			SELECT 
				@PM_FIELD = CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 'TR_TITLE1') AS VARCHAR)
			FROM 
				AGY_SETTINGS AGY WITH(NOLOCK) 
			WHERE 
				AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL';
		END
		--	FORCE DATE RANGE FOR SOME FOLDERS
		IF @InboxType IN ('all', 'dismissed')
		BEGIN
			IF @StartDate IS NULL AND @EndDate IS NULL
			BEGIN
				SELECT 
					@EndDate = DATEADD(MINUTE, -1, DATEADD(DAY, 1, GETDATE())), -- TODAY MIDNIGHT'ISH
					@StartDate = DATEADD(wk, 0, DATEADD(DAY, 1-DATEPART(WEEKDAY, GETDATE()), DATEDIFF(dd, 0, GETDATE()))); -- FIRST OF THIS WEEK, NEED TO ACCOUNT FOR START OF WEEK?
			END
			IF @StartDate IS NOT NULL AND @EndDate IS NULL
			BEGIN
				SELECT
					@EndDate = DATEADD(wk, 2, DATEADD(DAY, 0-DATEPART(WEEKDAY, GETDATE()), DATEDIFF(dd, 0, GETDATE()))); -- LAST DAY OF CURRENT WEEK
				SELECT
					@EndDate = DATEADD(MINUTE, -1, DATEADD(DAY, 1, @EndDate)); -- MIDNIGHT'ISH
			END
			IF @StartDate IS NULL AND @EndDate IS NOT NULL
			BEGIN
				SELECT
					@StartDate = DATEADD(wk, 0, DATEADD(DAY, 1-DATEPART(WEEKDAY, @EndDate), DATEDIFF(dd, 0, @EndDate)));
			END
		END
	END
	--	BASE DATA
	BEGIN
		-- POPULATE TEMP EMPLOYEE TABLE WITH VALUES COMING IN FROM THE @EmployeeCode PARM



		BEGIN
			INSERT INTO #EMPLOYEES
			SELECT LTRIM(RTRIM(items)) AS EMP_CODE 
			FROM [dbo].udf_split_list(@EmployeeCode, ',');
		END

		-- POPULATE TEMP DEPARTMENT TABLE WITH VALUES COMING IN FROM THE @Department PARM
		BEGIN
			INSERT INTO #DEPARTMENTS
			SELECT LTRIM(RTRIM(items)) AS DP_TM_CODE 
			FROM [dbo].udf_split_list(@Department, ',');
		END

		-- POPULATE TEMP ROLE TABLE WITH VALUES COMING IN FROM THE @EmployeeRole PARM
		BEGIN
			INSERT INTO #ROLES
			SELECT LTRIM(RTRIM(items)) AS ROLE_CODE 
			FROM [dbo].udf_split_list(@EmployeeRole, ',');
		END

		--SELECT * FROM #EMPLOYEES
		--RETURN;

		-- BOARD RECS
		BEGIN
			INSERT INTO #INACTIVE_WORK_ITEMS
			SELECT ALERT_ID FROM [dbo].[advtf_alert_inactive_work_items]();
		END
		
		--SELECT @ShowAssignmentType, @InboxType, @HAS_EMP
		-- ALERT RECS
		IF @IsJobAlertsPage = 0
		BEGIN
			IF @ShowAssignmentType = 'allalertassignments'
			BEGIN
				IF @HAS_EMP = 0
				BEGIN
					SELECT @LOAD_AAM_BASE = 1;
				END
			END
			IF @ShowAssignmentType = 'unassigned'
			BEGIN
				SELECT @LOAD_AAM_BASE = 1;
			END
			--	REUSE DASH QUERY
			IF (@ShowAssignmentType IN ('myalerts', 'myalertassignments', 'myalertsandassignments')) OR (@ShowAssignmentType = 'allalertassignments' AND @HAS_EMP = 1)

			BEGIN
				IF (@ShowAssignmentType = 'allalertassignments' AND @HAS_EMP = 1)
				BEGIN
					SET @IS_ALL_WITH_EMP = 1;  -- NOT SURE THIS IS NEEDED...
				END
				IF @InboxType = 'inbox'
				BEGIN
					INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, IS_MY_TASK_TEMP_COMPLETE, IS_OWNER_ASSIGNMENT_ALERT, IS_BACKLOG_ITEM)
					SELECT
						X.AlertID,
						X.LastUpdated,
						X.IsMyTaskTempComplete,
						X.IsOwnerAssignmentAlert,
						CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
					FROM
						[dbo].[advtf_alert_dashboard] (@EmployeeCode, @InboxType, @GroupBy, @IncludeBacklog, @OFFSET) X
						LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON X.AlertID = IWI.ALERT_ID
					WHERE												
						1 = CASE
								WHEN @ShowAssignmentType = 'myalerts' AND X.IsAlertCC = 1 THEN 1
								WHEN @ShowAssignmentType = 'myalertassignments' AND X.IsAlertCC = 0 THEN 1
								WHEN @ShowAssignmentType = 'allalertassignments'AND X.IsAlertCC = 0 AND @IS_ALL_WITH_EMP = 1 THEN 1
								WHEN @ShowAssignmentType = 'myalertsandassignments' THEN 1
								ELSE 0
							END
				END				
				
				IF @InboxType = 'all'
				BEGIN
					INSERT INTO #ALERT (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_BACKLOG_ITEM)
					SELECT
						A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
						CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
					FROM
						ALERT A WITH(NOLOCK)
						INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON A.ALERT_ID = X.ALERT_ID
						LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
						LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
					WHERE
						1 = CASE WHEN @EmployeeCode <> '' AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) THEN 1
							     WHEN @EmployeeCode = '' THEN 1
								 ELSE 0 END
						AND ISNULL(A.IS_DRAFT, 0) = 0
						--AND IWI.ALERT_ID IS NULL
						AND A.[LAST_UPDATED] BETWEEN @StartDate AND @EndDate
							--AND
							--1 =	CASE
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
							--																							WHEN @ShowAssignmentType = 'unassigned' OR @ShowAssignmentType = 'myalerts'  THEN 1
							--																							WHEN @ShowAssignmentType = 'myalertsandassignments' AND ISNULL(X.CURRENT_NOTIFY, 0) = 0  THEN 1
							--																							WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
							--																							ELSE 0
							--																						END 
							--		ELSE 0
							--	END
						AND
						1 = CASE
								WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(X.CURRENT_NOTIFY, 0) = 0 THEN 1
								WHEN @ShowAssignmentType = 'myalertassignments' AND ISNULL(X.CURRENT_NOTIFY, 0) = 1 THEN 1
								WHEN @ShowAssignmentType = 'myalertsandassignments'  THEN 1
								WHEN @ShowAssignmentType = 'allalertassignments'  AND ISNULL(X.CURRENT_NOTIFY, 0) = 1 THEN 1
								ELSE 0
							END
					UNION
					SELECT
						A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
						CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
					FROM
						ALERT A WITH(NOLOCK)
						INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON A.ALERT_ID = X.ALERT_ID
						LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
						LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
					WHERE
						1 = CASE WHEN @EmployeeCode <> '' AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) THEN 1
							     WHEN @EmployeeCode = '' THEN 1
								 ELSE 0 END
						AND ISNULL(A.IS_DRAFT, 0) = 0
						--AND IWI.ALERT_ID IS NULL
						AND A.[LAST_UPDATED] BETWEEN @StartDate AND @EndDate
							--AND
							--1 =	CASE
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
							--																							WHEN @ShowAssignmentType = 'unassigned' OR @ShowAssignmentType = 'myalerts'  THEN 1
							--																							WHEN @ShowAssignmentType = 'myalertsandassignments' AND ISNULL(X.CURRENT_NOTIFY, 0) = 0  THEN 1
							--																							WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
							--																							ELSE 0
							--																						END 
							--		ELSE 0
							--	END
						AND
						1 = CASE
								WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(X.CURRENT_NOTIFY, 0) = 0 THEN 1
								WHEN @ShowAssignmentType = 'myalertassignments' AND ISNULL(X.CURRENT_NOTIFY, 0) = 1 THEN 1
								WHEN @ShowAssignmentType = 'myalertsandassignments'  THEN 1
								WHEN @ShowAssignmentType = 'allalertassignments'  AND ISNULL(X.CURRENT_NOTIFY, 0) = 1 THEN 1
								ELSE 0
							END
					  UNION
					SELECT
						A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
						CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
					FROM 
						JOB_TRAFFIC_DET JTD WITH(NOLOCK)
						INNER JOIN ALERT A WITH(NOLOCK) ON JTD.JOB_NUMBER = A.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = A.TASK_SEQ_NBR 
						INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON JTD.JOB_NUMBER = JT.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR 
						INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON JT.JOB_NUMBER = JC.JOB_NUMBER AND JT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
						INNER JOIN JOB_TRAFFIC_DET_EMPS JTDE WITH(NOLOCK) ON JTD.JOB_NUMBER = JTDE.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = JTDE.SEQ_NBR 
						LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
					WHERE
						1 = CASE WHEN @EmployeeCode <> '' AND JTDE.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) THEN 1
							     WHEN @EmployeeCode = '' THEN 1
								 ELSE 0 END
						AND A.ALERT_CAT_ID = 71
						AND JT.COMPLETED_DATE IS NULL
						AND JTD.JOB_COMPLETED_DATE IS NULL
						AND COALESCE(A.IS_CS_REVIEW, 0) = 0
						AND COALESCE(A.IS_DRAFT, 0) = 0
						AND A.[LAST_UPDATED] BETWEEN @StartDate AND @EndDate
							--AND
							--1 =	CASE
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
							--																							WHEN @ShowAssignmentType = 'unassigned' THEN 1
							--																							WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
							--																							ELSE 0
							--																						END 
							--		ELSE 0
							--	END
						--AND
						--1 = CASE
						--		WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(X.CURRENT_NOTIFY, 0) = 0 THEN 1
						--		WHEN @ShowAssignmentType = 'myalertassignments' AND ISNULL(X.CURRENT_NOTIFY, 0) = 1 THEN 1
						--		WHEN @ShowAssignmentType = 'myalertsandassignments'  THEN 1
						--		WHEN @ShowAssignmentType = 'allalertassignments'  THEN 1
						--		ELSE 0
						--	END
				END				

				IF @InboxType = 'drafts'
				BEGIN
					INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID)
					SELECT
						A.ALERT_ID
					FROM
						ALERT A WITH(NOLOCK)
					WHERE
						A.ALERT_USER = @UserCode
						AND ISNULL(A.IS_DRAFT, 0) = 1;
				END
				IF @InboxType = 'dismissed'
				BEGIN			

					INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_CC_DISMISSED, IS_BACKLOG_ITEM)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
                            CASE WHEN ISNULL(ARD.CURRENT_NOTIFY, 0) = 0 AND ISNULL(ARD.CURRENT_RCPT,0) = 0 THEN 1 ELSE 0 END,
							CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
						FROM
							ALERT A WITH(NOLOCK)
							INNER JOIN ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) ON A.ALERT_ID = ARD.ALERT_ID
							LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
							LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
						WHERE 1 = CASE WHEN @EmployeeCode <> '' AND ARD.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) THEN 1
									  WHEN @EmployeeCode = '' OR @EmployeeCode IS NULL THEN 1
									 ELSE 0 END
							AND ISNULL(A.IS_DRAFT, 0) = 0 AND
							--1 =	CASE
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
							--																							WHEN @ShowAssignmentType = 'unassigned' OR @ShowAssignmentType = 'myalerts'  THEN 1
							--																							WHEN @ShowAssignmentType = 'myalertsandassignments' AND ISNULL(ARD.CURRENT_NOTIFY, 0) = 0  THEN 1
							--																							WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
							--																							ELSE 0
							--																						END 
							--		ELSE 0
							--	END AND
							1 = CASE
									WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(ARD.CURRENT_NOTIFY, 0) = 0 THEN 1
									WHEN @ShowAssignmentType = 'myalertassignments' AND ISNULL(ARD.CURRENT_NOTIFY, 0) = 1 THEN 1
									WHEN @ShowAssignmentType = 'myalertsandassignments'  THEN 1
									WHEN @ShowAssignmentType = 'allalertassignments' AND ISNULL(ARD.CURRENT_NOTIFY, 0) = 1  THEN 1
									ELSE 0
								END
							AND
								A.[LAST_UPDATED] BETWEEN @StartDate AND @EndDate;

					INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_BACKLOG_ITEM)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
							CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
						FROM
							ALERT A WITH(NOLOCK)
							LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
							LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
						WHERE
							--IWI.ALERT_ID IS NULL
							A.LAST_UPDATED BETWEEN @StartDate AND @EndDate
							AND A.ASSIGN_COMPLETED = 1
							--AND
							--1 =	CASE
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
							--		WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
							--																							WHEN @ShowAssignmentType = 'unassigned' THEN 1
							--																							WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
							--																							ELSE 0
							--																						END 
							--		ELSE 0
							--	END
							AND ISNULL(A.IS_DRAFT, 0) = 0
                   

					--SELECT * FROM #ALERT
				END
			END
			ELSE
			BEGIN
				SELECT @LOAD_AAM_BASE = 1;
			END
		END
		ELSE
		BEGIN	--	JOB INBOX!			
			IF @ShowAssignmentType IN ('myalertassignments') --	REUSE DASH QUERY
			BEGIN
				INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, IS_MY_TASK_TEMP_COMPLETE, IS_OWNER_ASSIGNMENT_ALERT, IS_BACKLOG_ITEM)
				SELECT
					X.AlertID,
					X.LastUpdated,
					X.IsMyTaskTempComplete,
					X.IsOwnerAssignmentAlert,
					CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
				FROM
					[dbo].[advtf_alert_dashboard_jobjacket] (@EmployeeCode, @InboxType, @GroupBy, @IncludeBacklog, @OFFSET, @IncludeCompletedAssignments) X
					LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON X.AlertID = IWI.ALERT_ID
				WHERE
					--IWI.ALERT_ID IS NULL
					X.JobNumber = @JobNumber AND X.JobComponentNumber = @JobComponentNumber
			END
			ELSE
			BEGIN -- AAM
				SELECT @LOAD_AAM_BASE = 1;
			END
		END
		--  LOAD BASE (FOR ALL JOB INBOX AND FOR AAM WHEN NO EMPLOYEE CODE)       


        --SELECT * FROM #ALERT ORDER BY ALERT_ID
		
		
		BEGIN
			IF @LOAD_AAM_BASE = 1
			BEGIN
				--	BASE
				IF @IsJobAlertsPage = 1
				BEGIN
					--if @HAS_EMP = 1
					--BEGIN
					--	INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, IS_MY_TASK_TEMP_COMPLETE, IS_OWNER_ASSIGNMENT_ALERT)
					--	SELECT
					--		X.AlertID,
					--		X.LastUpdated,
					--		X.IsMyTaskTempComplete,
					--		X.IsOwnerAssignmentAlert
					--	FROM
					--		[dbo].[advtf_alert_dashboard_jobjacket] (@EmployeeCode, @InboxType, @GroupBy, @IncludeBacklog, @OFFSET, @IncludeCompletedAssignments) X
					--		LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON X.AlertID = IWI.ALERT_ID
					--	WHERE
					--	IWI.ALERT_ID IS NULL
					--	AND X.JobNumber = @JobNumber AND X.JobComponentNumber = @JobComponentNumber
					--END
					--ELSE
					--BEGIN
						-- JUST GET ALL FOR THE JOB
						INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_BACKLOG_ITEM)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
							CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
						FROM
							ALERT A WITH(NOLOCK)
							LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
						WHERE
							A.JOB_NUMBER = @JobNumber
							AND A.JOB_COMPONENT_NBR = @JobComponentNumber
							AND
							1 =	CASE
									WHEN @IncludeCompletedAssignments = 0 AND ISNULL(A.ASSIGN_COMPLETED, 0) = 0 THEN 1
									WHEN @IncludeCompletedAssignments = 1 THEN 1
									ELSE 0
								END
							AND ISNULL(A.IS_DRAFT, 0) = 0

                            --SELECT * FROM #ALERT
					--END
				END
				ELSE
				BEGIN -- NORMAL AAM BASE
					IF @InboxType = 'inbox'
					BEGIN
						INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_BACKLOG_ITEM)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
							CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
						FROM
							ALERT A WITH(NOLOCK)
							LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
							LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
						WHERE
							(@StartDate IS NULL OR (@StartDate IS NOT NULL AND A.LAST_UPDATED >= @StartDate)) AND (@EndDate IS NULL OR (@EndDate IS NOT NULL AND A.LAST_UPDATED <= @EndDate))
							--AND IWI.ALERT_ID IS NULL
							AND ISNULL(A.ASSIGN_COMPLETED, 0) = 0
							AND
							1 =	CASE
									WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
									WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
																														WHEN @ShowAssignmentType = 'unassigned' THEN 1
																														WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL IN (6, 12) AND A.ALERT_CAT_ID <> 71 THEN 1
                                                                                                                        WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1-- CHECK JOB PROC CTRL
																														ELSE 0
																													END 
									ELSE 0
								END
							AND
							1 = CASE
									WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(A.IS_WORK_ITEM, 0) = 0 THEN 1 -- ALL STANDARD ALERTS
									WHEN @ShowAssignmentType = 'allalertassignments' AND ISNULL(A.IS_WORK_ITEM, 0) = 1 THEN 1 -- ALL ASSIGNMENTS
									WHEN @ShowAssignmentType = 'myalertsandassignments' THEN 1 -- BOTH ALERT AND ASSIGNMENTS
									WHEN @ShowAssignmentType = 'unassigned' AND ISNULL(A.IS_WORK_ITEM, 0) = 1  THEN 1
									ELSE 0
								END
							AND ISNULL(A.IS_DRAFT, 0) = 0
					END
					IF @InboxType = 'all' -- 'ALL
					BEGIN						
						INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_BACKLOG_ITEM)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
							CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
						FROM
							ALERT A WITH(NOLOCK)
							LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
							LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
						WHERE
							--IWI.ALERT_ID IS NULL
							A.LAST_UPDATED BETWEEN @StartDate AND @EndDate
							AND
							1 =	CASE
									WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
									WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
																														WHEN @ShowAssignmentType = 'unassigned' THEN 1
																														WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL IN (6, 12) AND A.ALERT_CAT_ID <> 71 THEN 1
                                                                                                                        WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
																														ELSE 0
																													END 
									ELSE 0
								END
							AND
							1 = CASE
									WHEN @ShowAssignmentType = 'myalertsandassignments' THEN 1
									WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(A.IS_WORK_ITEM, 0) = 0  THEN 1
									WHEN @ShowAssignmentType = 'allalertassignments' AND ISNULL(A.IS_WORK_ITEM, 0) = 1 THEN 1
									WHEN @ShowAssignmentType = 'unassigned' AND ISNULL(A.IS_WORK_ITEM, 0) = 1 THEN 1
									ELSE 0
								END
							AND ISNULL(A.IS_DRAFT, 0) = 0
					END
					IF @InboxType = 'drafts'
					BEGIN
						INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_BACKLOG_ITEM)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
							CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
						FROM
							ALERT A WITH(NOLOCK)
							LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
							LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
						WHERE
							--IWI.ALERT_ID IS NULL
							ISNULL(A.IS_DRAFT, 0) = 1
							AND A.ALERT_USER = @UserCode
							AND
							1 =	CASE
									WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
									WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
																														WHEN @ShowAssignmentType = 'unassigned' THEN 1
																														WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
																														ELSE 0
																													END 
									ELSE 0
								END
							AND
							1 = CASE
									WHEN @ShowAssignmentType = 'myalertsandassignments' THEN 1
									WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(A.IS_WORK_ITEM, 0) = 0  THEN 1
									WHEN @ShowAssignmentType = 'allalertassignments' AND A.IS_WORK_ITEM = 1 THEN 1
									WHEN @ShowAssignmentType = 'unassigned' AND ISNULL(A.IS_WORK_ITEM, 0) = 1 THEN 1
									ELSE 0
								END
					END
					IF @InboxType = 'dismissed' --  DISMISSED/COMPLETED
					BEGIN
						INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, IS_BACKLOG_ITEM)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID,
							CASE WHEN IWI.ALERT_ID IS NULL THEN 0 ELSE 1 END
						FROM
							ALERT A WITH(NOLOCK)
							LEFT OUTER JOIN #INACTIVE_WORK_ITEMS IWI ON A.ALERT_ID = IWI.ALERT_ID
							LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
						WHERE
							--IWI.ALERT_ID IS NULL
							A.LAST_UPDATED BETWEEN @StartDate AND @EndDate
							AND A.ASSIGN_COMPLETED = 1
							AND
							1 =	CASE
									WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
									WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
																														WHEN @ShowAssignmentType = 'unassigned' THEN 1
																														WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL IN (6, 12) AND A.ALERT_CAT_ID <> 71 THEN 1
                                                                                                                        WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
																														ELSE 0
																													END 
									ELSE 0
								END
							AND ISNULL(A.IS_DRAFT, 0) = 0

							--SELECT * FROM #ALERT

						INSERT INTO #ALERT WITH(ROWLOCK) (ALERT_ID, LAST_UPDATED, JOB_NUMBER, JOB_COMPONENT_NBR, TASK_SEQ_NBR, ALERT_CAT_ID, ALERT_LEVEL, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID)
						SELECT
							A.ALERT_ID, A.LAST_UPDATED, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.TASK_SEQ_NBR, A.ALERT_CAT_ID, A.ALERT_LEVEL, A.ALRT_NOTIFY_HDR_ID, A.ALERT_STATE_ID
						FROM
							ALERT A WITH(NOLOCK)
							INNER JOIN ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) ON A.ALERT_ID = ARD.ALERT_ID
							LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
						WHERE 1 = CASE WHEN @EmployeeCode <> '' AND ARD.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) THEN 1
									  WHEN @EmployeeCode = '' OR @EmployeeCode IS NULL THEN 1
									 ELSE 0 END
							AND ISNULL(A.IS_DRAFT, 0) = 0 AND
							1 =	CASE
									WHEN ISNULL(JC.JOB_NUMBER, 0) = 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) = 0 THEN 1  -- NO NEED TO CHECK PROC CTRL IF NO JOB/COMP
									WHEN ISNULL(JC.JOB_NUMBER, 0) > 0 AND ISNULL(JC.JOB_COMPONENT_NBR, 0) > 0 THEN	CASE
																														WHEN @ShowAssignmentType = 'unassigned' THEN 1
																														WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL IN (6, 12) AND A.ALERT_CAT_ID <> 71 THEN 1
                                                                                                                        WHEN @ShowAssignmentType <> 'unassigned' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1  -- CHECK JOB PROC CTRL
																														ELSE 0
																													END 
									ELSE 0
								END AND
							1 = CASE
									WHEN @ShowAssignmentType = 'myalerts' AND ISNULL(ARD.CURRENT_NOTIFY, 0) = 0 THEN 1
									WHEN @ShowAssignmentType = 'myalertassignments' AND ISNULL(ARD.CURRENT_NOTIFY, 0) = 1 THEN 1
									WHEN @ShowAssignmentType = 'myalertsandassignments'  THEN 1
									WHEN @ShowAssignmentType = 'allalertassignments' AND ISNULL(ARD.CURRENT_NOTIFY, 0) = 1  THEN 1
									ELSE 0
								END
							AND
								A.[LAST_UPDATED] BETWEEN @StartDate AND @EndDate;
					END
				END
				--SELECT * FROM #ALERT
				--  REMOVE TASKS OF CLOSED (DELETE TO MINIMIZE OUTER JOINS)
				BEGIN
					IF @IsJobAlertsPage = 1 
                    BEGIN
                        IF @IncludeCompletedAssignments = 0
                        BEGIN
                            IF @InboxType = 'inbox'
					        BEGIN
						        DELETE #ALERT
						        FROM
							        #ALERT A
							        INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
							        INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON A.JOB_NUMBER = JT.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
							        INNER JOIN JOB_TRAFFIC_DET JD WITH(NOLOCK) ON A.JOB_NUMBER = JD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JD.SEQ_NBR
						        WHERE
							        JC.JOB_PROCESS_CONTRL IN (6, 12)
							        OR JT.COMPLETED_DATE IS NOT NULL
							        OR JD.JOB_COMPLETED_DATE IS NOT NULL
					        END
					        IF @InboxType = 'dismissed'
					        BEGIN
						        DELETE #ALERT
						        FROM
							        #ALERT A
							        INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
							        INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON A.JOB_NUMBER = JT.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
							        INNER JOIN JOB_TRAFFIC_DET JD WITH(NOLOCK) ON A.JOB_NUMBER = JD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JD.SEQ_NBR
						        WHERE
							        JC.JOB_PROCESS_CONTRL NOT IN (6, 12)
							        AND JT.COMPLETED_DATE IS NULL
							        AND JD.JOB_COMPLETED_DATE IS NULL
					        END
                        END                        
                    END
                    ELSE
                    BEGIN
                        IF @InboxType = 'inbox'
					    BEGIN
						    DELETE #ALERT
						    FROM
							    #ALERT A
							    INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
							    INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON A.JOB_NUMBER = JT.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
							    INNER JOIN JOB_TRAFFIC_DET JD WITH(NOLOCK) ON A.JOB_NUMBER = JD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JD.SEQ_NBR
						    WHERE
							    JC.JOB_PROCESS_CONTRL IN (6, 12)
							    OR JT.COMPLETED_DATE IS NOT NULL
							    OR JD.JOB_COMPLETED_DATE IS NOT NULL
					    END
					    IF @InboxType = 'dismissed'
					    BEGIN
						    DELETE #ALERT
						    FROM
							    #ALERT A
							    INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
							    INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON A.JOB_NUMBER = JT.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
							    INNER JOIN JOB_TRAFFIC_DET JD WITH(NOLOCK) ON A.JOB_NUMBER = JD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JD.SEQ_NBR
						    WHERE
							    JC.JOB_PROCESS_CONTRL NOT IN (6, 12)
							    AND JT.COMPLETED_DATE IS NULL
							    AND JD.JOB_COMPLETED_DATE IS NULL
					    END
                    END	
				END

                --SELECT * FROM #ALERT

				--	UNASSIGNED
				IF @ShowAssignmentType = 'unassigned'
				BEGIN
					--	REMOVE TASKS WITH ASSIGNEES
					BEGIN
						DELETE #ALERT WHERE ALERT_CAT_ID = 71 OR ALERT_LEVEL = 'BRD'
						--DELETE #ALERT
						--FROM
						--	(
						--		SELECT
						--			AA.ALERT_ID, E.JOB_NUMBER, E.JOB_COMPONENT_NBR, E.SEQ_NBR, COUNT(1) AS CT
						--		FROM
						--			#ALERT AA
						--			INNER JOIN JOB_TRAFFIC_DET_EMPS E ON AA.JOB_NUMBER = E.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = E.SEQ_NBR
						--		WHERE
						--			AA.ALERT_CAT_ID = 71 OR AA.ALERT_LEVEL = 'BRD'
						--		GROUP BY
						--			AA.ALERT_ID, E.JOB_NUMBER, E.JOB_COMPONENT_NBR, E.SEQ_NBR
						--		HAVING
						--			COUNT(1) > 0
						--	) AS X INNER JOIN #ALERT AA ON X.ALERT_ID = AA.ALERT_ID;
					END
					--  REMOVE NON-ROUTED WITH EMPS
					BEGIN
						DELETE #ALERT
						FROM
							(
								SELECT 
									X.ALERT_ID,
									COUNT(1) AS CT
								FROM 
									#ALERT A
									INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON A.ALERT_ID = X.ALERT_ID
								WHERE
									X.CURRENT_NOTIFY = 1
									AND A.ALRT_NOTIFY_HDR_ID IS NULL
									AND A.ALERT_STATE_ID IS NULL
									AND X.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL
								GROUP BY
									X.ALERT_ID
								HAVING	
									COUNT(1) > 0
							) AS A INNER JOIN #ALERT AA ON A.ALERT_ID = AA.ALERT_ID;
						DELETE #ALERT
						FROM
							(
								SELECT 
									X.ALERT_ID,
									COUNT(1) AS CT
								FROM 
									#ALERT A
									INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON A.ALERT_ID = X.ALERT_ID
								WHERE
									X.CURRENT_NOTIFY = 1
									AND A.ALRT_NOTIFY_HDR_ID IS NULL
									AND A.ALERT_STATE_ID IS NULL
									AND X.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL
								GROUP BY
									X.ALERT_ID
								HAVING	
									COUNT(1) > 0
							) AS A INNER JOIN #ALERT AA ON A.ALERT_ID = AA.ALERT_ID;
					END
					--  REMOVE ROUTED WITH EMPS
					BEGIN
						DELETE #ALERT
						FROM
							(
								SELECT 
									X.ALERT_ID,
									COUNT(1) AS CT
								FROM 
									#ALERT A
									INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON A.ALERT_ID = X.ALERT_ID AND A.ALRT_NOTIFY_HDR_ID = X.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = X.ALERT_STATE_ID
								WHERE
									X.CURRENT_NOTIFY = 1
								GROUP BY
									X.ALERT_ID
								HAVING	
									COUNT(1) > 0
							) AS A INNER JOIN #ALERT AA ON A.ALERT_ID = AA.ALERT_ID;
						DELETE #ALERT
						FROM
							(
								SELECT 
									X.ALERT_ID,
									COUNT(1) AS CT
								FROM 
									#ALERT A
									INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON A.ALERT_ID = X.ALERT_ID AND A.ALRT_NOTIFY_HDR_ID = X.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = X.ALERT_STATE_ID
								WHERE
									X.CURRENT_NOTIFY = 1
								GROUP BY
									X.ALERT_ID
								HAVING	
									COUNT(1) > 0
							) AS A INNER JOIN #ALERT AA ON A.ALERT_ID = AA.ALERT_ID;
					END
					----  REMOVE CLOSED JOBS ??
					--BEGIN
					--	DELETE AA
					--	FROM
					--		#ALERT AA
					--		INNER JOIN JOB_COMPONENT JC ON AA.JOB_NUMBER = JC.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
					--	WHERE
					--		JC.JOB_PROCESS_CONTRL IN (6, 12)
					--END
				END
				--	ATTACHMENT COUNT
				BEGIN
					UPDATE AA SET ATTACHMENT_COUNT = X.ATTACHMENT_COUNT
					FROM	(
								SELECT
									AAT.ALERT_ID, 
									COUNT(1) AS ATTACHMENT_COUNT
								FROM
									#ALERT AA
									INNER JOIN ALERT_ATTACHMENT AAT WITH(NOLOCK) ON AA.ALERT_ID = AAT.ALERT_ID
								GROUP BY
									AAT.ALERT_ID
							) AS X
						INNER JOIN #ALERT AA ON X.ALERT_ID = AA.ALERT_ID;			
				END
				--  CHECKLIST COUNT
				BEGIN
					UPDATE AA SET AA.CHECKLIST_COUNT = CTR.CheckListTotal 
					FROM #ALERT AA
						INNER JOIN	(
										SELECT 
											COUNT(1) AS CheckListTotal, 
											CH.ALERT_ID
										FROM 
											CHECKLIST_HDR CH WITH(NOLOCK)
											INNER JOIN CHECKLIST_DTL CD WITH(NOLOCK) ON CH.ID = CD.CHECKLIST_HDR_ID 
											INNER JOIN #ALERT AA ON AA.ALERT_ID = CH.ALERT_ID
										GROUP BY 
											CH.ALERT_ID) CTR ON AA.ALERT_ID = CTR.ALERT_ID;	
				END
				--  CHECKLIST COMPLETE COUNT
				BEGIN
					UPDATE AA SET AA.CHECKLIST_COMPLETE_COUNT = CTR.CheckListTotal 
					FROM #ALERT AA
						INNER JOIN (
							SELECT 
								COUNT(1) AS CheckListTotal, 
								CH.ALERT_ID
							FROM 
								CHECKLIST_HDR CH WITH(NOLOCK)
								INNER JOIN CHECKLIST_DTL CD WITH(NOLOCK) ON CH.ID = CD.CHECKLIST_HDR_ID 
								INNER JOIN #ALERT AA ON CH.ALERT_ID = AA.ALERT_ID
							GROUP BY 
								CH.ALERT_ID) CTR ON AA.ALERT_ID = CTR.ALERT_ID;	
				END
			END
		END
		--	408916
	END

    
	--  BASE FIELDS UPDATE
	BEGIN
        	--UPDATE EMPLOYEE DEPARTMENT INFORMATION
		--BEGIN
		--	UPDATE AA SET
		--		AA.EMP_DEPARTMENT = E.DP_TM_CODE					
		--	FROM #ALERT AA
		--		INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
		--		INNER JOIN ALERT_RCPT AR ON AA.ALERT_ID = AR.ALERT_ID
		--		INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE					
		--	WHERE A.ALERT_CAT_ID <> 71
		--END

		--Update emp_role_code and emp_role_description
		--NON-TASKS, NOT DISMISSED
		--IF @InboxType NOT IN ('dismissed') AND @TASK_VIEW != 1
		--	BEGIN
		--		UPDATE AA SET
		--			AA.EMP_ROLE_CODE = TR.ROLE_CODE,
		--			AA.EMP_ROLE_DESCRIPTION = TR.ROLE_DESC
		--		FROM #ALERT AA
		--			INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
		--			INNER JOIN ALERT_RCPT AR ON AA.ALERT_ID = AR.ALERT_ID
		--			INNER JOIN EMP_TRAFFIC_ROLE ETR ON AR.EMP_CODE = ETR.EMP_CODE
		--			INNER JOIN TRAFFIC_ROLE TR ON ETR.ROLE_CODE = TR.ROLE_CODE
		--		WHERE A.ALERT_CAT_ID <> 71
		--	END

		----NON-TASKS, DISMISSED
		--IF @InboxType = 'dismissed'
		--	BEGIN
		--		UPDATE AA SET
		--			AA.EMP_ROLE_CODE = TR.ROLE_CODE,
		--			AA.EMP_ROLE_DESCRIPTION = TR.ROLE_DESC
		--		FROM #ALERT AA
		--			INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
		--			INNER JOIN ALERT_RCPT_DISMISSED ARD ON AA.ALERT_ID = ARD.ALERT_ID
		--			INNER JOIN EMP_TRAFFIC_ROLE ETR ON ARD.EMP_CODE = ETR.EMP_CODE
		--			INNER JOIN TRAFFIC_ROLE TR ON ETR.ROLE_CODE = TR.ROLE_CODE
		--		WHERE A.ALERT_CAT_ID <> 71
		--	END

		----TASKS
		--IF @TASK_VIEW = 1
		--	BEGIN
		--		UPDATE AA SET
		--			AA.EMP_ROLE_CODE = TR.ROLE_CODE,
		--			AA.EMP_ROLE_DESCRIPTION = TR.ROLE_DESC
		--		FROM #ALERT AA
		--			INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
		--			INNER JOIN JOB_TRAFFIC_DET_EMPS JTDE ON AA.JOB_NUMBER = JTDE.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = JTDE.SEQ_NBR			
		--			INNER JOIN EMPLOYEE_CLOAK EC ON JTDE.EMP_CODE = EC.EMP_CODE
		--			INNER JOIN TASK_TRAFFIC_ROLE TTR ON EC.DEF_TRF_ROLE = TTR.ROLE_CODE
		--			INNER JOIN TRAFFIC_ROLE TR ON TTR.ROLE_CODE = TR.ROLE_CODE
		--		WHERE A.ALERT_CAT_ID = 71
		--	END

		--UPDATE EMP_IN_ROLE FLAG, USED FOR FILTERING RECORDS AT THE ROLE LEVEL
		--THE ABOVE SECTION THAT'S COMMENTED OUT ISN'T ACCURATE FOR MULTIPLE ROLES
		--AND THE EMP_ROLE AND EMP_ROLE_DESCRIPTION AREN'T UTILIZED
		--FOR NON TASKS
		
        --SELECT * FROM #ALERT
		--  ALERT FIELDS
		UPDATE AA SET
			AA.JOB_NUMBER = A.JOB_NUMBER,
			AA.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR,
			AA.TASK_SEQ_NBR = A.TASK_SEQ_NBR,			
			AA.[IS_ROUTED_ASSIGNMENT] =	CASE
											WHEN A.IS_WORK_ITEM = 1 AND A.ALRT_NOTIFY_HDR_ID IS NOT NULL AND A.ALERT_STATE_ID IS NOT NULL AND A.ALERT_CAT_ID <> 71 THEN 1
											ELSE 0
										END,
			AA.[IS_NONROUTED_ASSIGNMENT] =	CASE
												WHEN A.IS_WORK_ITEM = 1 AND A.ALRT_NOTIFY_HDR_ID IS NULL AND A.ALERT_STATE_ID IS NULL AND A.ALERT_CAT_ID <> 71 THEN 1
												ELSE 0
											END,
			AA.[IS_TASK_ASSIGNMENT] =	CASE
											WHEN A.IS_WORK_ITEM = 1 AND A.ALERT_CAT_ID = 71 AND A.JOB_NUMBER IS NOT NULL AND A.JOB_COMPONENT_NBR IS NOT NULL AND A.TASK_SEQ_NBR IS NOT NULL THEN 1
											ELSE 0
										END,
			AA.IS_WORK_ITEM = A.IS_WORK_ITEM,
			AA.IS_STANDARD_ALERT =	CASE
										WHEN A.IS_WORK_ITEM = 1 THEN 0
										ELSE 1
									END,
			AA.ALRT_NOTIFY_HDR_ID = A.ALRT_NOTIFY_HDR_ID,
			AA.ALERT_STATE_ID = A.ALERT_STATE_ID,
			AA.BOARD_STATE_ID = A.BOARD_STATE_ID,
			AA.ALERT_CAT_ID = A.ALERT_CAT_ID,
			AA.ASSIGN_COMPLETED = ISNULL(A.ASSIGN_COMPLETED, 0),
			AA.[START_DATE] = A.[START_DATE],
			AA.DUE_DATE = A.DUE_DATE,
			AA.GRP_DUE_DATE = CONVERT(CHAR(10), A.DUE_DATE, 23),
			AA.GRP_DUE_DATE_DISPLAY = DATENAME(dw, A.DUE_DATE) + ',' + SPACE(1) + DATENAME(m, A.DUE_DATE) + SPACE(1) + CAST(DAY(A.DUE_DATE) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(A.DUE_DATE) AS CHAR(4))
		FROM
			#ALERT AA
			INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID;
			
		--	TASKS
		UPDATE AA SET
			AA.[START_DATE] = J.TASK_START_DATE,
			AA.DUE_DATE = J.JOB_REVISED_DATE,
			AA.GRP_DUE_DATE = CONVERT(CHAR(10), J.JOB_REVISED_DATE, 23),
			AA.GRP_DUE_DATE_DISPLAY = DATENAME(dw, J.JOB_REVISED_DATE) + ',' + SPACE(1) + DATENAME(m, J.JOB_REVISED_DATE) + SPACE(1) + CAST(DAY(J.JOB_REVISED_DATE) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(J.JOB_REVISED_DATE) AS CHAR(4)),
			AA.IS_TASK_COMPLETED =	CASE
										WHEN J.JOB_COMPLETED_DATE IS NULL THEN 0
										WHEN J.JOB_COMPLETED_DATE IS NOT NULL THEN 1
									END,
			AA.TASK_STATUS = J.TASK_STATUS			
		FROM
			#ALERT AA
			INNER JOIN JOB_TRAFFIC_DET J ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
			INNER JOIN V_JOB_TRAFFIC_DET JV ON JV.JOB_NUMBER = J.JOB_NUMBER AND JV.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND JV.SEQ_NBR = J.SEQ_NBR			
		WHERE
			AA.ALERT_CAT_ID = 71;

        --IF @TASK_VIEW != 1
		--BEGIN
			UPDATE AA SET					
					AA.EMP_IN_ROLE = 1
				FROM #ALERT AA
					INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
					INNER JOIN ALERT_RCPT AR ON AA.ALERT_ID = AR.ALERT_ID
					INNER JOIN EMP_TRAFFIC_ROLE ETR ON AR.EMP_CODE = ETR.EMP_CODE
					INNER JOIN TRAFFIC_ROLE TR ON ETR.ROLE_CODE = TR.ROLE_CODE
				WHERE A.ALERT_CAT_ID <> 71
				AND TR.ROLE_CODE COLLATE DATABASE_DEFAULT IN (SELECT ROLE_CODE COLLATE DATABASE_DEFAULT FROM #ROLES)
		--END

		--FOR TASKS
		--IF @TASK_VIEW = 1
		--BEGIN       
			UPDATE AA SET
				AA.EMP_IN_ROLE = 1
			FROM #ALERT AA
				INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
				INNER JOIN JOB_TRAFFIC_DET_EMPS JTDE ON AA.JOB_NUMBER = JTDE.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = JTDE.SEQ_NBR	
				INNER JOIN EMP_TRAFFIC_ROLE TTR ON JTDE.EMP_CODE = TTR.EMP_CODE
				INNER JOIN TRAFFIC_ROLE TR ON TTR.ROLE_CODE = TR.ROLE_CODE
			WHERE A.ALERT_CAT_ID = 71
			AND TR.ROLE_CODE COLLATE DATABASE_DEFAULT IN (SELECT ROLE_CODE COLLATE DATABASE_DEFAULT FROM #ROLES)

			UPDATE AA SET
				AA.EMP_IN_ROLE = 1
			FROM #ALERT AA
				INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
				INNER JOIN JOB_TRAFFIC_DET_EMPS JTDE ON AA.JOB_NUMBER = JTDE.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = JTDE.SEQ_NBR			
				INNER JOIN EMPLOYEE_CLOAK EC ON JTDE.EMP_CODE = EC.EMP_CODE
				INNER JOIN TASK_TRAFFIC_ROLE TTR ON EC.DEF_TRF_ROLE = TTR.ROLE_CODE
				INNER JOIN TRAFFIC_ROLE TR ON TTR.ROLE_CODE = TR.ROLE_CODE
			WHERE A.ALERT_CAT_ID = 71 AND EMP_IN_ROLE IS NULL
			AND TR.ROLE_CODE COLLATE DATABASE_DEFAULT IN (SELECT ROLE_CODE COLLATE DATABASE_DEFAULT FROM #ROLES)
		--END

        --SELECT * FROM #ALERT

		--	ACCOUNT EXEC
		UPDATE #ALERT SET
			AE_CODE = JC.EMP_CODE,
			AE_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
		FROM
			#ALERT AA
			INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON AA.JOB_NUMBER = JC.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
			INNER JOIN EMPLOYEE E WITH(NOLOCK) ON JC.EMP_CODE = E.EMP_CODE;
		--	PROJECT MANAGER
		BEGIN
			IF @PM_FIELD = 'TR_TITLE1'
			BEGIN
				UPDATE #ALERT SET
					PM_CODE = JT.ASSIGN_1,
					PM_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
				FROM
					#ALERT AA
					INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON AA.JOB_NUMBER = JT.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
					INNER JOIN EMPLOYEE E WITH(NOLOCK) ON JT.ASSIGN_1 = E.EMP_CODE;
			END
			IF @PM_FIELD = 'TR_TITLE2'
			BEGIN
				UPDATE #ALERT SET
					PM_CODE = JT.ASSIGN_2,
					PM_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
				FROM
					#ALERT AA
					INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON AA.JOB_NUMBER = JT.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
					INNER JOIN EMPLOYEE E WITH(NOLOCK) ON JT.ASSIGN_2 = E.EMP_CODE;
			END
			IF @PM_FIELD = 'TR_TITLE3'
			BEGIN
				UPDATE #ALERT SET
					PM_CODE = JT.ASSIGN_3,
					PM_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
				FROM
					#ALERT AA
					INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON AA.JOB_NUMBER = JT.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
					INNER JOIN EMPLOYEE E WITH(NOLOCK) ON JT.ASSIGN_3 = E.EMP_CODE;
			END
			IF @PM_FIELD = 'TR_TITLE4'
			BEGIN
				UPDATE #ALERT SET
					PM_CODE = JT.ASSIGN_4,
					PM_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
				FROM
					#ALERT AA
					INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON AA.JOB_NUMBER = JT.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
					INNER JOIN EMPLOYEE E WITH(NOLOCK) ON JT.ASSIGN_4 = E.EMP_CODE;
			END
			IF @PM_FIELD = 'TR_TITLE5'
			BEGIN
				UPDATE #ALERT SET
					PM_CODE = JT.ASSIGN_5,
					PM_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
				FROM
					#ALERT AA
					INNER JOIN JOB_TRAFFIC JT WITH(NOLOCK) ON AA.JOB_NUMBER = JT.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
					INNER JOIN EMPLOYEE E WITH(NOLOCK) ON JT.ASSIGN_5 = E.EMP_CODE;
			END
		END

        
	END
	--SELECT * FROM #ALERT
	--  EMPLOYEE COUNTS
	BEGIN
		-- ROUTED
		BEGIN
			-- OPEN ASSIGNEES 
           
			UPDATE #ALERT WITH(ROWLOCK) SET OPEN_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
							AND A.ALRT_NOTIFY_HDR_ID IS NOT NULL AND A.ALERT_STATE_ID IS NOT NULL 
							AND A.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AR.ALERT_STATE_ID 
					WHERE
						A.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID <> 71
						AND AR.CURRENT_NOTIFY = 1
						AND AA.IS_ROUTED_ASSIGNMENT = 1
                        AND (AA.IS_OWNER_ASSIGNMENT_ALERT = 0 OR AA.IS_OWNER_ASSIGNMENT_ALERT IS NULL)
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
            
           
			UPDATE #ALERT WITH(ROWLOCK) SET OPEN_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
							AND A.ALRT_NOTIFY_HDR_ID IS NOT NULL AND A.ALERT_STATE_ID IS NOT NULL 
							AND A.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AR.ALERT_STATE_ID 
					WHERE
						A.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID <> 71
						AND AR.CURRENT_NOTIFY = 1
						AND AA.IS_ROUTED_ASSIGNMENT = 1
                        AND AA.IS_OWNER_ASSIGNMENT_ALERT = 1
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
			-- COMPLETED ASSIGNEES
			UPDATE #ALERT WITH(ROWLOCK) SET COMPLETE_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT_DISMISSED AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
							AND A.ALRT_NOTIFY_HDR_ID IS NOT NULL AND A.ALERT_STATE_ID IS NOT NULL 
							AND A.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AR.ALERT_STATE_ID 
					WHERE
						A.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID <> 71
						AND AR.CURRENT_NOTIFY = 1
						AND AA.IS_ROUTED_ASSIGNMENT = 1
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
		END
		-- NOT ROUTED
		BEGIN
			-- OPEN ASSIGNEES
			UPDATE #ALERT WITH(ROWLOCK) SET OPEN_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
							AND A.ALRT_NOTIFY_HDR_ID IS NULL AND A.ALERT_STATE_ID IS NULL 
							AND AR.ALRT_NOTIFY_HDR_ID IS NULL AND AR.ALERT_STATE_ID IS NULL 
					WHERE
						A.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID <> 71
						AND AR.CURRENT_NOTIFY = 1
						AND AA.IS_NONROUTED_ASSIGNMENT = 1
                        AND (AA.IS_OWNER_ASSIGNMENT_ALERT = 0 OR AA.IS_OWNER_ASSIGNMENT_ALERT IS NULL)
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
            UPDATE #ALERT WITH(ROWLOCK) SET OPEN_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
							AND A.ALRT_NOTIFY_HDR_ID IS NULL AND A.ALERT_STATE_ID IS NULL 
							AND AR.ALRT_NOTIFY_HDR_ID IS NULL AND AR.ALERT_STATE_ID IS NULL 
					WHERE
						A.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID <> 71
						AND AR.CURRENT_NOTIFY = 1
						AND AA.IS_NONROUTED_ASSIGNMENT = 1
                        AND AA.IS_OWNER_ASSIGNMENT_ALERT = 1
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
			-- COMPLETED ASSIGNEES
			UPDATE #ALERT WITH(ROWLOCK) SET COMPLETE_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT_DISMISSED AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
							AND A.ALRT_NOTIFY_HDR_ID IS NOT NULL AND A.ALERT_STATE_ID IS NOT NULL 
							AND AR.ALRT_NOTIFY_HDR_ID IS NULL AND AR.ALERT_STATE_ID IS NULL 
					WHERE
						A.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID <> 71
						AND AR.CURRENT_NOTIFY = 1
						AND AA.IS_NONROUTED_ASSIGNMENT = 1
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
		END
		-- TASKS
		BEGIN
			-- OPEN ASSIGNEES
			UPDATE #ALERT WITH(ROWLOCK) SET OPEN_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AA.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN JOB_TRAFFIC_DET_EMPS J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET JD WITH(NOLOCK) ON JD.JOB_NUMBER = J.JOB_NUMBER AND JD.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND JD.SEQ_NBR = J.SEQ_NBR
					WHERE
						AA.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID = 71
						AND AA.IS_TASK_ASSIGNMENT = 1
						AND J.TEMP_COMP_DATE IS NULL
						--AND JD.JOB_COMPLETED_DATE IS NULL
					GROUP BY
						AA.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
			-- COMPLETED ASSIGNEES
			UPDATE #ALERT WITH(ROWLOCK) SET COMPLETE_ASSIGNEES_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AA.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN JOB_TRAFFIC_DET_EMPS J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET JD WITH(NOLOCK) ON JD.JOB_NUMBER = J.JOB_NUMBER AND JD.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND JD.SEQ_NBR = J.SEQ_NBR
					WHERE
						AA.IS_WORK_ITEM = 1
						AND A.ALERT_CAT_ID = 71
						AND AA.IS_TASK_ASSIGNMENT = 1
						AND J.TEMP_COMP_DATE IS NOT NULL
						--AND JD.JOB_COMPLETED_DATE IS NOT NULL
					GROUP BY
						AA.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
		END
		--  CC'S
		BEGIN
			-- OPEN RECIPIENTS
			UPDATE #ALERT WITH(ROWLOCK) SET OPEN_RECIPIENTS_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
					WHERE
						ISNULL(AR.CURRENT_NOTIFY, 0) = 0
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
			-- DISMISSED RECIPIENTS
			UPDATE #ALERT WITH(ROWLOCK) SET DISMISSED_RECIPIENTS_CT = X.RCPT_COUNT
			FROM
				(
					SELECT
						AR.ALERT_ID, 
						COUNT(1) AS RCPT_COUNT
					FROM
						#ALERT AA
						INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
						INNER JOIN ALERT_RCPT_DISMISSED AR WITH(NOLOCK) ON AA.ALERT_ID = AR.ALERT_ID
					WHERE
						ISNULL(AR.CURRENT_NOTIFY, 0) = 0
					GROUP BY
						AR.ALERT_ID
				) X INNER JOIN #ALERT AAA ON X.ALERT_ID = AAA.ALERT_ID;
		END
	END
    --SELECT * FROM #ALERT WHERE ALERT_ID = 399626
	--  MULTI-FLAG
	BEGIN
		UPDATE AA SET CURRENT_NOTIFY_EMP_FML = 'Multi'
		FROM
			#ALERT AA
		WHERE
			AA.OPEN_ASSIGNEES_CT > 1
			OR AA.COMPLETE_ASSIGNEES_CT > 1

        UPDATE AA SET CURRENT_NOTIFY_EMP_FML = 'Multi'
		FROM
			#ALERT AA
		WHERE
			AA.OPEN_RECIPIENTS_CT > 1
			AND IS_STANDARD_ALERT = 1
            
	END


    --UPDATE EMPLOYEE DEPARTMENT INFORMATION
		BEGIN
        
        if @Department <> ''
        BEGIN
            UPDATE AA SET
				AA.EMP_DEPARTMENT = E.DP_TM_CODE					
			FROM #ALERT AA
				INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
				INNER JOIN ALERT_RCPT AR ON AA.ALERT_ID = AR.ALERT_ID AND AA.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND AA.ALERT_STATE_ID = AR.ALERT_STATE_ID
				INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE					
			WHERE A.ALERT_CAT_ID <> 71 AND AA.IS_ROUTED_ASSIGNMENT = 1 AND E.DP_TM_CODE IN (SELECT DP_TM_CODE FROM #DEPARTMENTS)

            UPDATE AA SET
				AA.EMP_DEPARTMENT = E.DP_TM_CODE					
			FROM #ALERT AA
				INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
				INNER JOIN ALERT_RCPT AR ON AA.ALERT_ID = AR.ALERT_ID AND AR.CURRENT_NOTIFY = 1
				INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE					
			WHERE A.ALERT_CAT_ID <> 71 AND AA.IS_NONROUTED_ASSIGNMENT = 1 AND E.DP_TM_CODE IN (SELECT DP_TM_CODE FROM #DEPARTMENTS)

            UPDATE AA SET
				AA.EMP_DEPARTMENT = E.DP_TM_CODE					
			FROM #ALERT AA
				INNER JOIN ALERT A WITH(NOLOCK) ON AA.ALERT_ID = A.ALERT_ID
				INNER JOIN JOB_TRAFFIC_DET_EMPS AR ON AA.JOB_NUMBER = AR.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = AR.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = AR.SEQ_NBR
				INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE					
			WHERE A.ALERT_CAT_ID = 71 AND E.DP_TM_CODE IN (SELECT DP_TM_CODE FROM #DEPARTMENTS)

   --   
        END

		END



	--	SINGLE ASSIGNEES
	BEGIN
		--  ROUTED ASSIGNMENT
		BEGIN
			UPDATE #ALERT SET
				CURRENT_NOTIFY_EMP_FML = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				CURRENT_NOTIFY_EMP_CODE = ISNULL(E.EMP_CODE, '')
			FROM
				#ALERT AA
				INNER JOIN	(
								SELECT 
									X.ALERT_ID, X.EMP_CODE
								FROM 
									#ALERT AA 
									INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID AND AA.ALRT_NOTIFY_HDR_ID = X.ALRT_NOTIFY_HDR_ID AND AA.ALERT_STATE_ID = X.ALERT_STATE_ID
								WHERE 
									ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 1 
									AND ISNULL(AA.ASSIGN_COMPLETED, 0) = 0
									AND ISNULL(X.CURRENT_NOTIFY, 0) = 1
									AND AA.ALRT_NOTIFY_HDR_ID IS NOT NULL
								--UNION
								--SELECT 
								--	X.ALERT_ID, X.EMP_CODE
								--FROM 
								--	#ALERT AA 
								--	INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID AND AA.ALRT_NOTIFY_HDR_ID = X.ALRT_NOTIFY_HDR_ID AND AA.ALERT_STATE_ID = X.ALERT_STATE_ID
								--WHERE 
								--	ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 1 
								--	AND ISNULL(AA.ASSIGN_COMPLETED, 0) = 0
								--	AND ISNULL(X.CURRENT_NOTIFY, 0) = 1
								--	AND AA.ALRT_NOTIFY_HDR_ID IS NOT NULL
							) Z ON AA.ALERT_ID = Z.ALERT_ID
				INNER JOIN EMPLOYEE E ON Z.EMP_CODE = E.EMP_CODE;
		END
		--  NON-ROUTED ASSIGNMENT
		BEGIN
			UPDATE #ALERT SET
				CURRENT_NOTIFY_EMP_FML = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				CURRENT_NOTIFY_EMP_CODE = ISNULL(E.EMP_CODE, '')
			FROM
				#ALERT AA
				INNER JOIN	(
								SELECT 
									X.ALERT_ID, X.EMP_CODE
								FROM 
									#ALERT AA 
									INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
								WHERE 
									ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 1 
									AND ISNULL(AA.ASSIGN_COMPLETED, 0) = 0
									AND ISNULL(X.CURRENT_NOTIFY, 0) = 1
									AND AA.ALERT_STATE_ID IS NULL AND X.ALERT_STATE_ID IS NULL
								--UNION
								--SELECT 
								--	X.ALERT_ID, X.EMP_CODE
								--FROM 
								--	#ALERT AA 
								--	INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
								--WHERE 
								--	ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 1 
								--	AND ISNULL(AA.ASSIGN_COMPLETED, 0) = 0
								--	AND ISNULL(X.CURRENT_NOTIFY, 0) = 1
								--	AND AA.ALERT_STATE_ID IS NULL AND X.ALERT_STATE_ID IS NULL
							) Z ON AA.ALERT_ID = Z.ALERT_ID
				INNER JOIN EMPLOYEE E ON Z.EMP_CODE = E.EMP_CODE;
		END
        --  TASK
		BEGIN
			UPDATE #ALERT SET
				CURRENT_NOTIFY_EMP_FML = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				CURRENT_NOTIFY_EMP_CODE = ISNULL(E.EMP_CODE, '')
			FROM
				#ALERT AA
				INNER JOIN JOB_TRAFFIC_DET_EMPS J WITH(NOLOCK) ON 
					AA.JOB_NUMBER = J.JOB_NUMBER 
					AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR 
					AND AA.TASK_SEQ_NBR = J.SEQ_NBR
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON J.EMP_CODE = E.EMP_CODE
			WHERE
				(ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 1 AND ISNULL(AA.COMPLETE_ASSIGNEES_CT, 0) = 0 AND J.TEMP_COMP_DATE IS NULL)
				OR 
				(ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 0 AND ISNULL(AA.COMPLETE_ASSIGNEES_CT, 1) = 0 AND J.TEMP_COMP_DATE IS NOT NULL)
				OR 
				(ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 1 AND ISNULL(AA.COMPLETE_ASSIGNEES_CT, 1) = 1 AND J.TEMP_COMP_DATE IS NULL)
                OR 
                (ISNULL(AA.OPEN_ASSIGNEES_CT, 0) = 0 AND ISNULL(AA.COMPLETE_ASSIGNEES_CT, 1) = 1 AND J.TEMP_COMP_DATE IS NOT NULL);
		END		
        --  ALERTS
        BEGIN
            UPDATE #ALERT SET
				CURRENT_NOTIFY_EMP_FML = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				CURRENT_NOTIFY_EMP_CODE = ISNULL(E.EMP_CODE, '')
			FROM
				#ALERT AA
				INNER JOIN	(
								SELECT 
									X.ALERT_ID, X.EMP_CODE
								FROM 
									#ALERT AA 
									INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID 
								WHERE 
									ISNULL(AA.OPEN_RECIPIENTS_CT, 0) = 1 
									AND ISNULL(X.CURRENT_NOTIFY, 0) = 0
                                    AND ISNULL(X.CURRENT_RCPT,0) = 0
                                    AND IS_STANDARD_ALERT = 1
								
							) Z ON AA.ALERT_ID = Z.ALERT_ID
				INNER JOIN EMPLOYEE E ON Z.EMP_CODE = E.EMP_CODE;

            UPDATE #ALERT SET
				CURRENT_NOTIFY_EMP_FML = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				CURRENT_NOTIFY_EMP_CODE = ISNULL(E.EMP_CODE, '')
			FROM
				#ALERT AA
				INNER JOIN	(
								SELECT 
									X.ALERT_ID, X.EMP_CODE
								FROM 
									#ALERT AA 
									INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID 
								WHERE 
									ISNULL(AA.DISMISSED_RECIPIENTS_CT, 0) = 1 
									AND ISNULL(X.CURRENT_NOTIFY, 0) = 0
                                    AND ISNULL(X.CURRENT_RCPT,0) = 0
                                    AND IS_STANDARD_ALERT = 1
								
							) Z ON AA.ALERT_ID = Z.ALERT_ID
				INNER JOIN EMPLOYEE E ON Z.EMP_CODE = E.EMP_CODE;
        END
	END

	

	--	SET OWNER/ASSIGNEE DISPLAY aka "IS MY"
	if @Restrictions > 0 AND @ShowAssignmentType = 'allalertassignments'
	BEGIN
		IF (@EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES)) OR @EmployeeCode = '' OR @EmployeeCode IS NULL
		BEGIN
			BEGIN
			--	ASSIGNMENTS
				BEGIN
					--	ROUTED
					BEGIN
			
						UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
						FROM
							#ALERT	AA
							INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
								AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
								AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
						WHERE
							AA.IS_STANDARD_ALERT = 0
							AND AA.IS_TASK_ASSIGNMENT = 0
							AND X.CURRENT_NOTIFY = 1
							AND X.EMP_CODE = @EMP_CODE

						UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 1
						FROM
							#ALERT	AA
							INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
								AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
								AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
						WHERE
							AA.IS_STANDARD_ALERT = 0
							AND AA.IS_TASK_ASSIGNMENT = 0
							AND X.CURRENT_NOTIFY = 1
							AND  X.EMP_CODE = @EMP_CODE

					END
					--  NON-ROUTED
					BEGIN
						UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
						FROM
							#ALERT	AA
							INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
								AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
								AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
						WHERE
							AA.IS_STANDARD_ALERT = 0
							AND AA.IS_TASK_ASSIGNMENT = 0
							AND X.CURRENT_NOTIFY = 1
							AND X.EMP_CODE = @EMP_CODE

						UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 1
						FROM
							#ALERT	AA
							INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
								AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
								AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
						WHERE
							AA.IS_STANDARD_ALERT = 0
							AND AA.IS_TASK_ASSIGNMENT = 0
							AND X.CURRENT_NOTIFY = 1
							AND X.EMP_CODE = @EMP_CODE
					END
				END
				--  TASK
				BEGIN
					UPDATE AA SET 
						IS_MY_TASK = 1, 
						IS_MY_TASK_TEMP_COMPLETE =	CASE
														WHEN J.TEMP_COMP_DATE IS NULL THEN 0
														WHEN J.TEMP_COMP_DATE IS NOT NULL THEN 1
													END,
						TEMP_COMPLETE_DATE = J.TEMP_COMP_DATE
					FROM
						#ALERT	AA
						INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET_EMPS E WITH(NOLOCK) ON J.JOB_NUMBER = E.JOB_NUMBER AND J.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND J.SEQ_NBR = E.SEQ_NBR
					WHERE
						AA.IS_STANDARD_ALERT = 0
						AND AA.IS_TASK_ASSIGNMENT = 1
						AND E.EMP_CODE = @EMP_CODE
				END
			END
		END
		--ELSE
		--BEGIN

		--END
		
	END
	ELSE
	BEGIN
		BEGIN
		--	ASSIGNMENTS
			BEGIN
				IF @EmployeeCode = '' OR @EmployeeCode IS NULL
					BEGIN
						--	ROUTED
						BEGIN
					
							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
									AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE

							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 1
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
									AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE

						END
						--  NON-ROUTED
						BEGIN
							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE

							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE
						END
					END
					ELSE
					BEGIN
						--	ROUTED
						BEGIN
					
							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
									AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) AND X.EMP_CODE = @EMP_CODE

							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 1
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
									AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND  X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) AND X.EMP_CODE = @EMP_CODE

                            --Multi
                            UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
									AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE AND CURRENT_NOTIFY_EMP_FML = 'Multi'

							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 1
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID = AA.ALRT_NOTIFY_HDR_ID 
									AND X.ALERT_STATE_ID = AA.ALERT_STATE_ID
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE AND CURRENT_NOTIFY_EMP_FML = 'Multi'

						END
						--  NON-ROUTED
						BEGIN
							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) AND X.EMP_CODE = @EMP_CODE

							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) AND X.EMP_CODE = @EMP_CODE

                            --Multi
                            UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE AND CURRENT_NOTIFY_EMP_FML = 'Multi'

							UPDATE AA SET IS_MY_ASSIGNMENT = 1, IS_MY_ASSIGNMENT_COMPLETED = 0
							FROM
								#ALERT	AA
								INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
									AND X.ALRT_NOTIFY_HDR_ID IS NULL AND AA.ALRT_NOTIFY_HDR_ID IS NULL
									AND X.ALERT_STATE_ID IS NULL AND AA.ALERT_STATE_ID IS NULL
							WHERE
								AA.IS_STANDARD_ALERT = 0
								AND AA.IS_TASK_ASSIGNMENT = 0
								AND X.CURRENT_NOTIFY = 1
								AND X.EMP_CODE = @EMP_CODE AND CURRENT_NOTIFY_EMP_FML = 'Multi'
						END
					END
				
			--  TASK
            
				IF @EmployeeCode = '' OR @EmployeeCode IS NULL
				BEGIN
					UPDATE AA SET 
						IS_MY_TASK = 1,
                        IS_MY_TASK_TEMP_COMPLETE =	CASE
														WHEN E.TEMP_COMP_DATE IS NULL THEN 0
														WHEN E.TEMP_COMP_DATE IS NOT NULL THEN 1
													END		    
						
					FROM
						#ALERT	AA
						INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET_EMPS E WITH(NOLOCK) ON J.JOB_NUMBER = E.JOB_NUMBER AND J.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND J.SEQ_NBR = E.SEQ_NBR
					WHERE
						AA.IS_STANDARD_ALERT = 0
						AND AA.IS_TASK_ASSIGNMENT = 1					
						AND E.EMP_CODE = @EMP_CODE

                    UPDATE AA SET 
                        IS_MY_TASK_TEMP_COMPLETE =	CASE
														WHEN E.TEMP_COMP_DATE IS NULL THEN 0
														WHEN E.TEMP_COMP_DATE IS NOT NULL THEN 1
													END		    
						
					FROM
						#ALERT	AA
						INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET_EMPS E WITH(NOLOCK) ON J.JOB_NUMBER = E.JOB_NUMBER AND J.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND J.SEQ_NBR = E.SEQ_NBR
					WHERE
						AA.IS_STANDARD_ALERT = 0
						AND AA.IS_TASK_ASSIGNMENT = 1					
						AND E.EMP_CODE <> @EMP_CODE AND CURRENT_NOTIFY_EMP_FML <> 'Multi'

                    UPDATE AA SET 		
						TEMP_COMPLETE_DATE = E.TEMP_COMP_DATE
					FROM
						#ALERT	AA
						INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET_EMPS E WITH(NOLOCK) ON J.JOB_NUMBER = E.JOB_NUMBER AND J.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND J.SEQ_NBR = E.SEQ_NBR
					WHERE
						AA.IS_STANDARD_ALERT = 0
						AND AA.IS_TASK_ASSIGNMENT = 1					
						--AND E.EMP_CODE = @EMP_CODE
				END
				ELSE
				BEGIN
					UPDATE AA SET 
						IS_MY_TASK = 1
					FROM
						#ALERT	AA
						INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET_EMPS E WITH(NOLOCK) ON J.JOB_NUMBER = E.JOB_NUMBER AND J.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND J.SEQ_NBR = E.SEQ_NBR
					WHERE
						AA.IS_STANDARD_ALERT = 0
						AND AA.IS_TASK_ASSIGNMENT = 1
						AND E.EMP_CODE = @EMP_CODE

                    UPDATE AA SET 
						IS_MY_TASK_TEMP_COMPLETE =	CASE
														WHEN E.TEMP_COMP_DATE IS NULL THEN 0
														WHEN E.TEMP_COMP_DATE IS NOT NULL THEN 1
													END,
						TEMP_COMPLETE_DATE = E.TEMP_COMP_DATE
					FROM
						#ALERT	AA
						INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET_EMPS E WITH(NOLOCK) ON J.JOB_NUMBER = E.JOB_NUMBER AND J.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND J.SEQ_NBR = E.SEQ_NBR
					WHERE
						AA.IS_STANDARD_ALERT = 0
						AND AA.IS_TASK_ASSIGNMENT = 1
						AND E.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES) --AND E.EMP_CODE = @EMP_CODE

                    UPDATE AA SET 
						IS_MY_TASK = 1, 
						IS_MY_TASK_TEMP_COMPLETE =	CASE
														WHEN E.TEMP_COMP_DATE IS NULL THEN 0
														WHEN E.TEMP_COMP_DATE IS NOT NULL THEN 1
													END,
						TEMP_COMPLETE_DATE = E.TEMP_COMP_DATE
					FROM
						#ALERT	AA
						INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON AA.JOB_NUMBER = J.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = J.SEQ_NBR
						INNER JOIN JOB_TRAFFIC_DET_EMPS E WITH(NOLOCK) ON J.JOB_NUMBER = E.JOB_NUMBER AND J.JOB_COMPONENT_NBR = E.JOB_COMPONENT_NBR AND J.SEQ_NBR = E.SEQ_NBR
					WHERE
						AA.IS_STANDARD_ALERT = 0
						AND AA.IS_TASK_ASSIGNMENT = 1
						AND E.EMP_CODE = @EMP_CODE AND CURRENT_NOTIFY_EMP_FML = 'Multi'

				END
			END
		END
	END
	
	--	IS CC
	BEGIN  

        IF @InboxType = 'dismissed'
		BEGIN	
             UPDATE #ALERT SET IS_OWNER_ASSIGNMENT_ALERT = 1
			        WHERE ALERT_ID IN (SELECT ALERT_ID FROM #ALERT
							        GROUP BY ALERT_ID
							        HAVING COUNT(1) > 1)
			        AND IS_CC_DISMISSED = 1;
        END
        
		UPDATE AA SET IS_CC = 1, IS_CC_DISMISSED = 0, IS_MY_ALERT = 1, IS_MY_ALERT_COMPLETED = 0 
		FROM
			#ALERT	AA
			INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
		WHERE
			ISNULL(X.CURRENT_NOTIFY, 0) = 0 AND ISNULL(X.CURRENT_RCPT,0) = 0
			AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES);


        IF @InboxType <> 'dismissed'
        BEGIN
            UPDATE AA SET IS_CC = 0, IS_CC_DISMISSED = 1, IS_MY_ALERT = 1, IS_MY_ALERT_COMPLETED = 1
		    FROM
			    #ALERT	AA
			    INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
		    WHERE
			    ISNULL(X.CURRENT_NOTIFY, 0) = 0 AND ISNULL(X.CURRENT_RCPT,0) = 0
			    AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES);
        END
		

        --SELECT * FROM #ALERT

		UPDATE AA
		SET AA.CC_EMPLOYEE_CODES = STUFF((SELECT ',' + CC.EmployeeCode
				FROM WV_AAM_ALERT_RCPT_CC CC
				WHERE CC.ALERT_ID = X.ALERT_ID 
				ORDER By CC.EmployeeCode
		FOR XML PATH('')), 1, 1, '')
		FROM #ALERT AA INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
		--WHERE AA.IS_CC = 1		

		UPDATE AA
		SET AA.CC_EMPLOYEE_NAMES = STUFF(
		(SELECT ',' + CC.EmployeeName
				FROM WV_AAM_ALERT_RCPT_CC CC
				WHERE CC.ALERT_ID = X.ALERT_ID 
				ORDER By CC.EmployeeCode
		FOR XML PATH('')), 1, 1, '')
		FROM #ALERT AA INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID

		--select * from #ALERT ORDER BY ALERT_ID
		--return;
		
/*
SELECT AR.ALERT_ID, [EmployeeCode] = AR.EMP_CODE,
[EmployeeName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
FROM ALERT_RCPT AR WITH(NOLOCK) 
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON AR.EMP_CODE = E.EMP_CODE
WHERE ISNULL(AR.CURRENT_RCPT, 0) = 0
	AND ISNULL(AR.CURRENT_NOTIFY, 0) = 0
UNION
SELECT AR.ALERT_ID, [EmployeeCode] = CONVERT(VARCHAR(6), C.CDP_CONTACT_ID),
[EmployeeName] = C.CONT_FML
FROM
	CP_ALERT_RCPT AR WITH(NOLOCK) 
	INNER JOIN CDP_CONTACT_HDR C ON AR.CDP_CONTACT_ID = C.CDP_CONTACT_ID
WHERE ISNULL(AR.CURRENT_RCPT, 0) = 0
	AND ISNULL(AR.CURRENT_NOTIFY, 0) = 0
*/

		/*UPDATE AA
		SET AA.CC_EMPLOYEE_CODES = STUFF((SELECT ',' + AR.EMP_CODE FROM ALERT_RCPT AR WHERE AR.ALERT_ID = X.ALERT_ID	
			AND ISNULL(CURRENT_RCPT, 0) = 0
			AND ISNULL(CURRENT_NOTIFY, 0) = 0			
		ORDER BY AR.EMP_CODE
		FOR XML PATH('')), 1, 1, '')
		FROM #ALERT AA INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
		WHERE AA.IS_CC = 1		

		UPDATE AA
		SET AA.CC_EMPLOYEE_NAMES = STUFF(
		(SELECT ',' + ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
		FROM EMPLOYEE E LEFT JOIN ALERT_RCPT AR ON E.EMP_CODE = AR.EMP_CODE
		WHERE AR.ALERT_ID = X.ALERT_ID 
		AND ISNULL(CURRENT_RCPT, 0) = 0
		AND ISNULL(CURRENT_NOTIFY, 0) = 0
		ORDER BY AR.EMP_CODE
		FOR XML PATH('')), 1, 1, '')
		FROM #ALERT AA INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
		WHERE AA.IS_CC = 1		*/

	END
	--	USER'S CARD ORDER
	BEGIN
		IF @EmployeeCode IS NOT NULL
		BEGIN
			UPDATE AAA SET USER_ORDER_SEQ_NBR = A.CARD_SEQ_NBR
			FROM
				(
					SELECT
						AA.ALERT_ID,
						X.CARD_SEQ_NBR
					FROM
						#ALERT AA 
						INNER JOIN ALERT_RCPT X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
					WHERE
						X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES)
						AND X.CARD_SEQ_NBR IS NOT NULL
					UNION
					SELECT
						AA.ALERT_ID,
						X.CARD_SEQ_NBR
					FROM
						#ALERT AA 
						INNER JOIN ALERT_RCPT_DISMISSED X WITH(NOLOCK) ON AA.ALERT_ID = X.ALERT_ID
					WHERE
						X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES)
						AND X.CARD_SEQ_NBR IS NOT NULL
				) AS A
				INNER JOIN #ALERT AAA ON A.ALERT_ID = AAA.ALERT_ID;

			--  DO UPDATE FOR TASKS HERE BASED ON THE 
				--	UPDATE AAA SET USER_ORDER_SEQ_NBR = A.CARD_SEQ_NBR

			UPDATE AAA SET USER_ORDER_SEQ_NBR = A.CARD_SEQ_NBR
				FROM
				(
					SELECT
						AA.ALERT_ID,
						X.CARD_SEQ_NBR
					FROM
						#ALERT AA 
						INNER JOIN JOB_TRAFFIC_DET_EMPS X WITH(NOLOCK) ON AA.JOB_NUMBER = X.JOB_NUMBER AND
							AA.JOB_COMPONENT_NBR = X.JOB_COMPONENT_NBR AND
							AA.TASK_SEQ_NBR = X.SEQ_NBR
					WHERE
						X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES)
						AND X.CARD_SEQ_NBR IS NOT NULL					
				) AS A
			INNER JOIN #ALERT AAA ON A.ALERT_ID = AAA.ALERT_ID;
		END
	END
	--  READ FLAG
	BEGIN
		IF @EmployeeCode IS NOT NULL
		BEGIN
			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN ALERT_RCPT X ON AA.ALERT_ID = X.ALERT_ID
			WHERE
				ISNULL(X.READ_ALERT, 0) = 1
				AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES);
			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN ALERT_RCPT_DISMISSED X ON AA.ALERT_ID = X.ALERT_ID
			WHERE
				ISNULL(X.READ_ALERT, 0) = 1
				AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES);
			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN JOB_TRAFFIC_DET_EMPS X ON AA.JOB_NUMBER = X.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = X.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = X.SEQ_NBR
			WHERE
				AA.IS_TASK_ASSIGNMENT = 1
				AND ISNULL(X.READ_ALERT, 0) = 1
				AND X.EMP_CODE IN (SELECT EMP_CODE FROM #EMPLOYEES);
				END
		ELSE
		BEGIN
            --SELECT * FROM #ALERT

			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN ALERT_RCPT X ON AA.ALERT_ID = X.ALERT_ID
			WHERE
				ISNULL(X.READ_ALERT, 0) = 1 AND AA.CURRENT_NOTIFY_EMP_FML <> 'Multi' AND AA.CURRENT_NOTIFY_EMP_CODE = X.EMP_CODE		
                
            UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN ALERT_RCPT X ON AA.ALERT_ID = X.ALERT_ID
			WHERE
				ISNULL(X.READ_ALERT, 0) = 1 AND AA.CURRENT_NOTIFY_EMP_FML = 'Multi' 

			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN ALERT_RCPT_DISMISSED X ON AA.ALERT_ID = X.ALERT_ID
			WHERE
				ISNULL(X.READ_ALERT, 0) = 1 AND AA.CURRENT_NOTIFY_EMP_FML <> 'Multi' AND AA.CURRENT_NOTIFY_EMP_CODE = X.EMP_CODE				

			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN ALERT_RCPT_DISMISSED X ON AA.ALERT_ID = X.ALERT_ID
			WHERE
				ISNULL(X.READ_ALERT, 0) = 1 AND AA.CURRENT_NOTIFY_EMP_FML = 'Multi' 				

			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN JOB_TRAFFIC_DET_EMPS X ON AA.JOB_NUMBER = X.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = X.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = X.SEQ_NBR
			WHERE
				AA.IS_TASK_ASSIGNMENT = 1
				AND ISNULL(X.READ_ALERT, 0) = 1 AND AA.CURRENT_NOTIFY_EMP_FML <> 'Multi' AND AA.CURRENT_NOTIFY_EMP_CODE = X.EMP_CODE								

			UPDATE AA SET IS_READ = 1
			FROM
				#ALERT AA
				INNER JOIN JOB_TRAFFIC_DET_EMPS X ON AA.JOB_NUMBER = X.JOB_NUMBER AND AA.JOB_COMPONENT_NBR = X.JOB_COMPONENT_NBR AND AA.TASK_SEQ_NBR = X.SEQ_NBR
			WHERE
				AA.IS_TASK_ASSIGNMENT = 1
				AND ISNULL(X.READ_ALERT, 0) = 1	AND AA.CURRENT_NOTIFY_EMP_FML = 'Multi' 		
		END
	END	
	--	CLEAN UP
	BEGIN
		UPDATE #ALERT WITH(ROWLOCK) SET IS_UNASSIGNED =	CASE
															WHEN ASSIGN_COMPLETED = 0 AND ISNULL(IS_WORK_ITEM, 0) = 1 AND ISNULL(OPEN_ASSIGNEES_CT, 0) = 0 THEN 1
															ELSE 0
														END
									WHERE 
										ISNULL(IS_TASK_ASSIGNMENT, 0) = 0;
		UPDATE #ALERT WITH(ROWLOCK) SET IS_UNASSIGNED =	CASE
															WHEN ISNULL(OPEN_ASSIGNEES_CT, 0) = 0 AND ISNULL(COMPLETE_ASSIGNEES_CT, 0) = 0 THEN 1
															ELSE 0
														END
									WHERE 
										ISNULL(IS_TASK_ASSIGNMENT, 0) = 1;
		UPDATE #ALERT WITH(ROWLOCK) SET CURRENT_NOTIFY_EMP_FML = 'Unassigned' 
								    WHERE 
										CURRENT_NOTIFY_EMP_FML IS NULL AND IS_UNASSIGNED = 1; 
		UPDATE #ALERT WITH(ROWLOCK) SET JOB_NUMBER = NULL 
									WHERE 
										JOB_NUMBER <= 0;
		UPDATE #ALERT WITH(ROWLOCK) SET JOB_COMPONENT_NBR = NULL 
									WHERE 
										JOB_COMPONENT_NBR <= 0;
		UPDATE #ALERT WITH(ROWLOCK) SET TASK_SEQ_NBR = NULL 
									WHERE 
										TASK_SEQ_NBR <= -1;
		UPDATE #ALERT WITH(ROWLOCK) SET IS_WORK_ITEM = 0 
									WHERE 
										IS_WORK_ITEM IS NULL;
		UPDATE #ALERT WITH(ROWLOCK) SET CURRENT_NOTIFY_EMP_FML = 'Completed' 
									WHERE 
										ASSIGN_COMPLETED = 1;
	END


	--SELECT * FROM #ALERT --WHERE ALERT_ID = 5399
	--  MORE FILTER AFTER ALL FIELDS READY
	BEGIN
		IF @InboxType = 'inbox' AND @ShowAssignmentType = 'allalertassignments'
		BEGIN
			DELETE FROM #ALERT WHERE ISNULL(IS_UNASSIGNED, 0) = 1;
		END
		--SELECT * FROM #ALERT
		IF @IsJobAlertsPage = 1
		BEGIN
			IF @InboxType = 'inbox' AND @ShowAssignmentType = 'myalertsandassignments'
			BEGIN
				DELETE FROM #ALERT WHERE ISNULL(IS_UNASSIGNED, 0) = 1;
			END
			--REMOVE ALERTS FROM 'My Assignments' and 'All Assignments' Views
			IF @ShowAssignmentType IN ('myalertassignments', 'allalertassignments')
			BEGIN				
				DELETE AA 
				FROM #ALERT AA
				INNER JOIN ALERT A WITH(NOLOCK) 
					ON A.ALERT_ID = AA.ALERT_ID
				WHERE IS_CC = 1 OR IS_STANDARD_ALERT = 1
					  --AND AA.IS_OWNER_ASSIGNMENT_ALERT = 1 
				   --   AND 1 = CASE WHEN @EmployeeCode <> '' AND (AA.IS_MY_ASSIGNMENT IS NULL OR AA.IS_MY_ASSIGNMENT = 0) THEN 0 ELSE 1 END
					--0 = CASE 
					--		WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) 
					--		ELSE CAST(0 AS BIT) 
					--	END
			END			

            IF @ShowAssignmentType IN ('myalerts') AND @IncludeCompletedAssignments = 0
			BEGIN				
                DELETE FROM #ALERT 
                WHERE ISNULL(IS_CC_DISMISSED,0) = 1
            END
		END
        --SELECT * FROM #ALERT
        --SELECT @Restrictions
		/*BEGIN
			UPDATE #ALERT 
				SET IS_ALERT = CASE
								WHEN ALERT_CAT_ID != 71 AND ((ALERT_STATE_ID IS NULL AND ALRT_NOTIFY_HDR_ID IS NULL) OR (IS_WORK_ITEM = 0 OR IS_WORK_ITEM IS NULL)) THEN 0
								WHEN IS_OWNER_ASSIGNMENT_ALERT = 1 THEN 0
								ELSE 1
							END				
		END

		BEGIN
			UPDATE #ALERT 
				SET CC_EMPLOYEE_CODES = NULL,
					CC_EMPLOYEE_NAMES = NULL
			WHERE IS_ALERT = 1
		END*/
	END

	BEGIN
		--UPDATE BOARD NAME FOR NON-BACKLOG ITEMS
		UPDATE #ALERT
		SET #ALERT.BOARD_NAME = B.NAME
		FROM #ALERT A LEFT OUTER JOIN SPRINT_DTL SD WITH(NOLOCK) ON A.ALERT_ID = SD.ALERT_ID 	
					LEFT OUTER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID --AND COALESCE(SH.IS_COMPLETE, 0) = 0
                    LEFT OUTER JOIN BOARD B WITH (NOLOCK) ON SH.BOARD_ID = B.ID
		
		----UPDATE BOARD NAME FOR BACKLOG ITEMS
		--UPDATE #ALERT
		--SET #ALERT.BOARD_NAME = B.NAME
		--FROM #ALERT A JOIN BOARD_JOB BDJ WITH(NOLOCK) ON A.JOB_NUMBER = BDJ.JOB_NUMBER AND A.JOB_COMPONENT_NBR = BDJ.JOB_COMPONENT_NBR
		--			JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID --AND COALESCE(SH.IS_COMPLETE, 0) = 0
  --                  JOIN BOARD B WITH (NOLOCK) ON SH.BOARD_ID = B.ID
		UPDATE #ALERT
		SET #ALERT.BOARD_NAME = 
			STUFF(
			(SELECT ',' + B.NAME
			FROM BOARD_JOB BJ JOIN BOARD B ON BJ.BOARD_ID = B.ID
			WHERE BJ.JOB_NUMBER = X.JOB_NUMBER 
			AND BJ.JOB_COMPONENT_NBR = X.JOB_COMPONENT_NBR
			FOR XML PATH('')), 1, 1, '')
		FROM #ALERT X
		WHERE X.IS_BACKLOG_ITEM = 1

		UPDATE #ALERT
		SET BOARD_NAME = 'Multiple'
		WHERE BOARD_NAME LIKE '%,%'

		UPDATE #ALERT
		SET #ALERT.BOARD_EXCLUDE_TASKS = 1		
		FROM #ALERT A JOIN BOARD_JOB BJ ON BJ.JOB_NUMBER = A.JOB_NUMBER AND BJ.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
		JOIN BOARD B ON BJ.BOARD_ID = B.ID
		JOIN BOARD_HDR BH ON BH.ID = B.BOARD_HDR_ID
		JOIN ALERT_CATEGORY AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID 
		where BH.EXCLUDE_TASKS = 1 AND @IncludeBacklog = 1 AND AC.ALERT_DESC = 'Task' AND A.IS_BACKLOG_ITEM = 1	

	END

	BEGIN
		BEGIN			
			--ORDER BY ALERT_ID
			--RETURN;
			--SELECT * FROM #ALERT --WHERE ALERT_ID = 304279
			--SELECT @InboxType, @ShowAssignmentType, @IsJobAlertsPage, @IncludeCompletedAssignments, @INCL_ALERTS, @INCL_ASSIGNMENTS, @INCL_COMPLETED
            --SELECT * FROM #SEC_CLIENT
			if @Restrictions > 0 AND @ShowAssignmentType = 'allalertassignments'
			BEGIN
				SELECT DISTINCT															
					A.ALERT_ID,
					ID = COALESCE( A.ALERT_SEQ_NBR, A.ALERT_ID),
					AA.LAST_UPDATED,
					A.[GENERATED],
					A.[PRIORITY],
					A.ALERT_CAT_ID,
					[ALERT_STATE_NAME] = AAS.ALERT_STATE_NAME,
					ALERT_LEVEL = CASE WHEN DATALENGTH(A.ALERT_LEVEL) = 0 THEN NULL ELSE A.ALERT_LEVEL END,
					ALERT_LEVEL_TEXT =	CASE 
											WHEN A.ALERT_LEVEL = 'OF' THEN 'Office'
											WHEN A.ALERT_LEVEL = 'CL' THEN 'Client'
											WHEN A.ALERT_LEVEL = 'DI' THEN 'Division'
											WHEN A.ALERT_LEVEL = 'PR' THEN 'Product'
											WHEN A.ALERT_LEVEL = 'CM' THEN 'Campaign'
											WHEN A.ALERT_LEVEL = 'JO' THEN 'Job'
											WHEN A.ALERT_LEVEL = 'JC' THEN 'Job Component'
											WHEN A.ALERT_LEVEL = 'ES' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'EST' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'PS' THEN 'Schedule'
											WHEN A.ALERT_LEVEL = 'PST' THEN 'Schedule Task'
											WHEN A.ALERT_LEVEL = 'PO' THEN 'Purchase Order'
											WHEN A.ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'
											WHEN A.ALERT_LEVEL = 'AP' THEN 'Accounts Payable'
											WHEN A.ALERT_LEVEL = 'AD' THEN 'Agency Desktop'
											WHEN A.ALERT_LEVEL = 'AN' THEN 'Ad Number'
											WHEN A.ALERT_LEVEL = 'ED' THEN 'Employee Desktop'
											WHEN A.ALERT_LEVEL = 'NA' THEN 'Approval'
											WHEN A.ALERT_LEVEL = 'VN' THEN 'Vendor'
											WHEN A.ALERT_LEVEL = 'CT' THEN 'Contract'
											WHEN A.ALERT_LEVEL = 'BRD' THEN 'Task Assignment'
											ELSE NULL
										END,
					ISNULL(A.[SUBJECT],'') AS SUBJECT, --10
					[ATTACHMENTCOUNT] = ISNULL(A.ATTACHMENT_COUNT, 0),
					AA.[START_DATE],
					AA.DUE_DATE,
					A.TIME_DUE,
					[TYPE] = AT.ALERT_TYPE_DESC,
					CATEGORY = AC.ALERT_DESC,
					C.CL_NAME,
					SV.[VERSION],
					SB.BUILD,
					JOB_NUMBER = AA.JOB_NUMBER, --20
					JOB_COMPONENT_NBR = AA.JOB_COMPONENT_NBR,
					SPRINT_ID = ISNULL(SD.SPRINT_HDR_ID, 0),
					TASK_SEQ_NBR = A.TASK_SEQ_NBR,
					TASK_STATUS = AA.TASK_STATUS,
					GRP_OFFICE = O.OFFICE_NAME, --CASE WHEN @GroupBy = 'O' THEN O.OFFICE_NAME END,
					GRP_CLIENT = CASE WHEN @GroupBy = 'C' THEN C.CL_NAME END,
					GRP_DIVISION = D.DIV_NAME, --CASE WHEN @GroupBy = 'CD' THEN D.DIV_NAME END,
					GRP_PRODUCT = P.PRD_DESCRIPTION, --CASE WHEN @GroupBy = 'CDP' THEN P.PRD_DESCRIPTION END,
					GRP_JOB = CASE WHEN @GroupBy = 'CDPJ' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + ISNULL(JL.JOB_DESC, '') + ' | ' + C.CL_NAME END,
					GRP_COMPONENT = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6 ) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3) + ' - ' + ISNULL(JC.JOB_COMP_DESC, '') + ' | ' + C.CL_NAME,
					GRP_CAMPAIGN = ISNULL(CMP.CMP_NAME, ''), --CASE WHEN @GroupBy = 'CM' THEN ISNULL(CMP.CMP_NAME, '') END, --30
					GRP_TASK =	CASE 
									WHEN @GroupBy = 'PST' THEN 
										CASE 
											WHEN AA.TASK_FNC_CODE IS NULL OR AA.TASK_FNC_CODE = '' THEN AA.TASK_DESCRIPTION 
											ELSE AA.TASK_DESCRIPTION
										END
							   END,
					GRP_ESTIMATE = CASE WHEN @GroupBy = 'ES' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + ' - ' + ISNULL(EST.EST_LOG_DESC, '') END,
					GRP_ESTIMATE_COMPONENT = CASE WHEN @GroupBy = 'EST' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), A.EST_COMPONENT_NBR), 2) + ' - ' + ISNULL(EC.EST_COMP_DESC, '') END,
					GRP_DUE_DATE =	AA.GRP_DUE_DATE,
					GRP_DUE_DATE_DISPLAY =	AA.GRP_DUE_DATE_DISPLAY,
					GRP_PRIORITY =	CASE
										WHEN A.[PRIORITY] = 1 THEN 'Highest'
										WHEN A.[PRIORITY] = 2 THEN 'High'
										WHEN A.[PRIORITY] = 3 THEN 'Normal'
										WHEN A.[PRIORITY] = 4 THEN 'Low'
										WHEN A.[PRIORITY] = 5 THEN 'Lowest'
										ELSE 'Normal'
									END,
					ALERT_NOTIFY_NAME = ANH.ALERT_NOTIFY_NAME,
					A.CL_CODE, 
					A.DIV_CODE, 
					A.PRD_CODE,  --40
					A.CMP_CODE,
					[CURRENT_NOTIFY] = CAST(ISNULL(AA.CURRENT_NOTIFY, 0) AS BIT),
					AA.CURRENT_NOTIFY_EMP_FML,
					IS_ASSIGNMENT =	CASE 
										WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) 
										ELSE CAST(0 AS BIT) 
									END,
					[IS_WORK_ITEM] = ISNULL(A.IS_WORK_ITEM, 0),
					[IS_STANDARD_ALERT] = ISNULL(AA.IS_STANDARD_ALERT, 0),
					[IS_CC] = CAST(ISNULL(IS_CC, 0) AS BIT),
					[IS_ROUTED_ASSIGNMENT] = ISNULL(AA.IS_ROUTED_ASSIGNMENT, 0),
					[IS_NONROUTED_ASSIGNMENT] = ISNULL(AA.IS_NONROUTED_ASSIGNMENT, 0),
					[IS_TASK_ASSIGNMENT] = ISNULL(AA.IS_TASK_ASSIGNMENT, 0), --50
					[COMPLETE_ASSIGNEES_CT] = ISNULL(AA.COMPLETE_ASSIGNEES_CT, 0),
					[OPEN_ASSIGNEES_CT] = ISNULL(AA.OPEN_ASSIGNEES_CT, 0),
					[DISMISSED_RECIPIENTS_CT] = ISNULL(AA.DISMISSED_RECIPIENTS_CT, 0),
					[OPEN_RECIPIENTS_CT] = ISNULL(AA.OPEN_RECIPIENTS_CT, 0),
					[IS_MY_ASSIGNMENT] = ISNULL(IS_MY_ASSIGNMENT, 0),
					[IS_MY_ASSIGNMENT_COMPLETED] = ISNULL(IS_MY_ASSIGNMENT_COMPLETED, 0),
					[IS_MY_ALERT] = ISNULL(IS_MY_ALERT, 0),
					[IS_MY_ALERT_COMPLETED] = ISNULL(IS_MY_ALERT_COMPLETED, 0),
					[IS_MY_TASK] = ISNULL(IS_MY_TASK, 0),
					[IS_TASK_COMPLETED] = ISNULL(IS_TASK_COMPLETED, 0), --60
					AA.ASSIGN_COMPLETED,
					AA.USER_ORDER_SEQ_NBR,
					AA.IS_UNASSIGNED,
					[READ_ALERT] = AA.IS_READ,
					AA.AE_NAME, --65
					AA.PM_NAME,
					AA.IS_MY_TASK_TEMP_COMPLETE,	
					[JOB_DESC] = ISNULL(JL.JOB_DESC, ''),
					[JOB_COMP_DESC] = ISNULL(JC.JOB_COMP_DESC, ''),
					[TASK_COMMENTS] = ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)), ''),
					[HOURS_ALLOWED] = JTD.JOB_HRS,				


					[Subject] = A.[SUBJECT], --10
					[Generated] = A.GENERATED,
					[GeneratedNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, A.GENERATED)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, A.GENERATED)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, A.GENERATED)),2) + ' ' +
											 RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, A.GENERATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, A.GENERATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, A.GENERATED)),2) AS DATE),
					[LastUpdated] = AA.LAST_UPDATED,
					[LastUpdatedNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, AA.LAST_UPDATED)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, AA.LAST_UPDATED)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, AA.LAST_UPDATED)),2) + ' ' +
											   RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, AA.LAST_UPDATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, AA.LAST_UPDATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, AA.LAST_UPDATED)),2) AS DATE),
					[StartDate] = CASE WHEN AA.[START_DATE] IS NULL AND ISNULL(A.NON_TASK_ID,0) > 0 THEN EMP_NON_TASKS.[START_DATE] ELSE AA.[START_DATE] END,		
					[DueDate] = AA.DUE_DATE,				
					[TimeDue] = A.TIME_DUE,
					[AlertStateName] =	AAS.ALERT_STATE_NAME,
					[Priority] = A.[PRIORITY],
					[AssignedTo] = AA.CURRENT_NOTIFY_EMP_FML,	
					[AssignedToEmpCode] = AA.CURRENT_NOTIFY_EMP_CODE,
					[Category] = AC.ALERT_DESC,
					[ClientName] = C.CL_NAME,
					[ClientCode] = A.CL_CODE, 
					[GroupDivision] = D.DIV_NAME,				
					[DivisionCode] = A.DIV_CODE, 
					[GroupProduct] = P.PRD_DESCRIPTION,
					[ProductCode] = A.PRD_CODE,  --40
					[Job] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + ISNULL(JL.JOB_DESC, '') ELSE '' END,					
					[JobNumber] = ISNULL(JL.JOB_NUMBER, 0),
					[JobComponent] = CASE WHEN A.JOB_COMPONENT_NBR IS NOT NULL THEN RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) + ' - ' + ISNULL(JC.JOB_COMP_DESC, '') ELSE '' END,
					[ComponentNumber] = ISNULL(A.JOB_COMPONENT_NBR, 0),

					[JobComponentDetailed] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(VARCHAR(6), ISNULL(JL.JOB_NUMBER, 0)), 6) + '/' + RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) +
											' - ' + ISNULL(JL.JOB_DESC,'') + CASE WHEN ISNULL(JC.JOB_COMP_DESC, '') != ISNULL(JL.JOB_DESC,'') THEN ' | ' + ISNULL(JC.JOB_COMP_DESC, '') ELSE '' END ELSE '' END,

					[JobAndComponentNumber] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(VARCHAR(6), ISNULL(JL.JOB_NUMBER, 0)), 6) + '/' + RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) ELSE '' END,
					[JobDescription] = ISNULL(JL.JOB_DESC,''),	
					[ComponentDescription] = ISNULL(JC.JOB_COMP_DESC, ''),
					[ID] = COALESCE( A.ALERT_SEQ_NBR, A.ALERT_ID),							
					[SoftwareVersion] = SV.[VERSION],
					[SoftwareBuild] = SB.BUILD,			
					[AlertTypeText] = AT.ALERT_TYPE_DESC,				
					[AccountExecutive] = AA.AE_NAME, --65
					[ProjectManager] = AA.PM_NAME,
					[GroupOffice] = O.OFFICE_NAME,
					[GroupCampaign] = ISNULL(CMP.CMP_NAME, ''), 
					[GroupAlertTemplateName] = ANH.ALERT_NOTIFY_NAME,
					[IsRead] = ISNULL(AA.IS_READ, 0),
					[AlertCategoryID] = A.ALERT_CAT_ID,				
					[SprintID] = ISNULL(SD.SPRINT_HDR_ID, 0),
					[AlertID] = A.ALERT_ID,					
					[IsTaskAssignment] = ISNULL(AA.IS_TASK_ASSIGNMENT, 0), --50
					[AttachmentCount] = ISNULL(A.ATTACHMENT_COUNT, 0),				
					[IsRoutedAssignment] = ISNULL(AA.IS_ROUTED_ASSIGNMENT, 0),
					[IsRouted] =	CASE 
										WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) 
										ELSE CAST(0 AS BIT)									
									END,
					[IsWorkItem] = ISNULL(A.IS_WORK_ITEM, 0),
					[IsCurrentAssignee] = CAST(ISNULL(AA.CURRENT_NOTIFY, 0) AS BIT),			
					[IsDismissed] = /*iF RECORD IS AN ASSIGNMENT AND EXISTS IN THE DISMISSED TABLE, THEN IS_DISMISSED = TRUE*/
									CASE
										WHEN (ISNULL(ARD.ALERT_ID, 0) <> 0) AND AA.IS_CC_DISMISSED = 1 THEN CAST(1 AS BIT)
										--	((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1))
										--THEN CAST(1 AS BIT)
										ELSE CAST(0 AS BIT)									
									END,
					[IsNonRoutedAssignment] = ISNULL(AA.IS_NONROUTED_ASSIGNMENT, 0),
					[IsCC] = CAST(ISNULL(IS_CC, 0) AS BIT),
					[IsMyAssignment] = ISNULL(IS_MY_ASSIGNMENT, 0),
					[IsMyAlert] = ISNULL(IS_MY_ALERT, 0),
					[IsMyTask] = ISNULL(IS_MY_TASK, 0),
					[TaskStatus] = AA.TASK_STATUS,				
					[TaskComments] = ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)), ''),
					[HoursAllowed] = CAST(JTD.JOB_HRS AS VARCHAR),					
					[TaskDateDiff] = DATEDIFF(DAY, GETDATE(), AA.DUE_DATE),
					[TaskDateIsWeekend] = CAST(CASE 
										WHEN DATEPART(DW,A.DUE_DATE) = 1 OR DATEPART(DW,A.DUE_DATE) = 7 THEN 1
									ELSE 0 END AS BIT),				
					--DATE COLORING SHOULD BE EXTENDED ALL GRID ITEMS WITH A DUE DATE, NOT JUST TASKS
					/*[TaskDateDiff] = DATEDIFF(DAY, GETDATE(), JTD.JOB_REVISED_DATE),
					[TaskDateIsWeekend] = CAST(CASE 
										WHEN A.ALERT_CAT_ID = 71 AND (DATEPART(DW,JTD.JOB_REVISED_DATE) = 1 OR DATEPART(DW,JTD.JOB_REVISED_DATE) = 7) THEN 1
									ELSE 0 END AS BIT),				*/	
					--[EmployeeRoleCode] = AA.EMP_ROLE_CODE,
					--[EmployeeRoleDescription] = AA.EMP_ROLE_DESCRIPTION,					
					[GroupPriority] =	CASE
										WHEN A.[PRIORITY] = 1 THEN 'Highest'
										WHEN A.[PRIORITY] = 2 THEN 'High'
										WHEN A.[PRIORITY] = 3 THEN 'Normal'
										WHEN A.[PRIORITY] = 4 THEN 'Low'
										WHEN A.[PRIORITY] = 5 THEN 'Lowest'
										ELSE 'Normal'
									END,
					[CDPCodes] = CASE WHEN LEN(A.CL_CODE) > 0 THEN A.CL_CODE + '|' + A.DIV_CODE + '|' + A.PRD_CODE ELSE '' END,
					[TaskSequenceNumber] = A.TASK_SEQ_NBR,
					[IsMyTaskTempComplete] = ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0),						
					[IsOwnerAssignmentAlert] = ISNULL(AA.IS_OWNER_ASSIGNMENT_ALERT, 0),
					[UserName] = CASE
									WHEN A.CP_ALERT = 1 AND ISNUMERIC(A.ALERT_USER_CP) = 1 THEN (SELECT CONT_FML FROM CDP_CONTACT_HDR WITH (NOLOCK) WHERE  CDP_CONTACT_ID = CAST(A.ALERT_USER_CP AS INT))
									ELSE A.LAST_UPDATED_FML
									END,
					[IsDraft] = ISNULL(A.IS_DRAFT,0),  
					[TempCompleteDate] = AA.TEMP_COMPLETE_DATE,
					[TempCompleteDateNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, AA.TEMP_COMPLETE_DATE)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, AA.TEMP_COMPLETE_DATE)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, AA.TEMP_COMPLETE_DATE)),2) + ' ' +
													RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, AA.TEMP_COMPLETE_DATE)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, AA.TEMP_COMPLETE_DATE)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, AA.TEMP_COMPLETE_DATE)),2) AS DATE),
				
					[AlertLevel] = CASE WHEN DATALENGTH(A.ALERT_LEVEL) = 0 THEN NULL ELSE A.ALERT_LEVEL END,
					[AlertLevelText] =	CASE 
											WHEN A.ALERT_LEVEL = 'OF' THEN 'Office'
											WHEN A.ALERT_LEVEL = 'CL' THEN 'Client'
											WHEN A.ALERT_LEVEL = 'DI' THEN 'Division'
											WHEN A.ALERT_LEVEL = 'PR' THEN 'Product'
											WHEN A.ALERT_LEVEL = 'CM' THEN 'Campaign'
											WHEN A.ALERT_LEVEL = 'JO' THEN 'Job'
											WHEN A.ALERT_LEVEL = 'JC' THEN 'Job Component'
											WHEN A.ALERT_LEVEL = 'ES' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'EST' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'PS' THEN 'Schedule'
											WHEN A.ALERT_LEVEL = 'PST' THEN 'Schedule Task'
											WHEN A.ALERT_LEVEL = 'PO' THEN 'Purchase Order'
											WHEN A.ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'
											WHEN A.ALERT_LEVEL = 'AP' THEN 'Accounts Payable'
											WHEN A.ALERT_LEVEL = 'AD' THEN 'Agency Desktop'
											WHEN A.ALERT_LEVEL = 'AN' THEN 'Ad Number'
											WHEN A.ALERT_LEVEL = 'ED' THEN 'Employee Desktop'
											WHEN A.ALERT_LEVEL = 'NA' THEN 'Approval'
											WHEN A.ALERT_LEVEL = 'VN' THEN 'Vendor'
											WHEN A.ALERT_LEVEL = 'CT' THEN 'Contract'
											WHEN A.ALERT_LEVEL = 'BRD' THEN 'Task Assignment'
											ELSE NULL
										END,
					[GroupClient] = CASE WHEN @GroupBy = 'C' THEN C.CL_NAME END,				
					[GroupTask] =	CASE 
										WHEN @GroupBy = 'PST' THEN 
											CASE 
												WHEN AA.TASK_FNC_CODE IS NULL OR AA.TASK_FNC_CODE = '' THEN AA.TASK_DESCRIPTION 
												ELSE AA.TASK_DESCRIPTION
											END
									END,
					[GroupEstimate] = CASE WHEN @GroupBy = 'ES' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + ' - ' + ISNULL(EST.EST_LOG_DESC, '') END,
					[GroupEstimateComponent] = CASE WHEN @GroupBy = 'EST' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), A.EST_COMPONENT_NBR), 2) + ' - ' + ISNULL(EC.EST_COMP_DESC, '') END,
					[GroupDueDate] = AA.GRP_DUE_DATE,
					[GroupDueDateDisplay] =	AA.GRP_DUE_DATE_DISPLAY,
					[CampaignCode] = A.CMP_CODE,
					[IsStandardAlert] = ISNULL(AA.IS_STANDARD_ALERT, 0),
					[CompletedAssigneesCount] = ISNULL(AA.COMPLETE_ASSIGNEES_CT, 0),
					[OpenAssigneesCount] = ISNULL(AA.OPEN_ASSIGNEES_CT, 0),
					[DismissedRecipientsCount] = ISNULL(AA.DISMISSED_RECIPIENTS_CT, 0),
					[OpenRecipientsCount] = ISNULL(AA.OPEN_RECIPIENTS_CT, 0),				
					[IsMyAssignmentCompleted] = ISNULL(IS_MY_ASSIGNMENT_COMPLETED, 0),				
					[IsMyAlertCompleted] = ISNULL(IS_MY_ALERT_COMPLETED, 0),				
					[IsTaskCompleted] = ISNULL(IS_TASK_COMPLETED, 0),
					[AssignmentCompleted] = AA.ASSIGN_COMPLETED,
					[UserOrder] = AA.USER_ORDER_SEQ_NBR,
					[IsUnAssigned] = ISNULL(AA.IS_UNASSIGNED, 0),
					[AssignedEmpCode] = A.ASSIGNED_EMP_CODE,				
					[EmployeeDepartment] = AA.EMP_DEPARTMENT,							
					[CCEmployeeCodes] = CASE
								--WHEN A.ALERT_CAT_ID = 71 THEN NULL
								WHEN AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN NULL
								WHEN AA.IS_STANDARD_ALERT = 1 THEN NULL
								ELSE AA.CC_EMPLOYEE_CODES
							END,
					[CCEmployeeNames] = CASE
								--WHEN A.ALERT_CAT_ID = 71 THEN NULL
								WHEN AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN NULL
								WHEN AA.IS_STANDARD_ALERT = 1 THEN NULL
								ELSE AA.CC_EMPLOYEE_NAMES
							END,
                    [Board] = CASE WHEN AA.BOARD_EXCLUDE_TASKS = 1 THEN '' ELSE ISNULL(AA.BOARD_NAME,'') END,
                    [BoardState] = ISNULL(CASE WHEN AA.BOARD_EXCLUDE_TASKS = 1 THEN ''
									WHEN AA.IS_BACKLOG_ITEM = 1 THEN 'Backlog'
									WHEN SD.ALERT_ID IS NOT NULL AND BAS.ALERT_STATE_ID IS NOT NULL THEN CASE WHEN AA.ASSIGN_COMPLETED = 1 
									THEN 'Completed' ELSE BAS.ALERT_STATE_NAME END END,''),
                    [Sprint] = ISNULL(SH.[DESCRIPTION],''),
                    [SprintStartDate] = SH.[START_DATE],
					[IsBacklogItem] = AA.IS_BACKLOG_ITEM,
					[TaskStatusDescription] = CASE WHEN ISNULL(AA.IS_TASK_ASSIGNMENT, 0) = 1 AND AA.TASK_STATUS = 'A' THEN 'Active'
									WHEN ISNULL(AA.IS_TASK_ASSIGNMENT, 0) = 1 AND AA.TASK_STATUS = 'P' THEN 'Projected'					
									ELSE '' END					
				FROM 
					#ALERT AA
					INNER JOIN ALERT A WITH(NOLOCK) ON A.ALERT_ID = AA.ALERT_ID
					INNER JOIN ALERT_TYPE AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID 
					INNER JOIN ALERT_CATEGORY AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID 
					LEFT OUTER JOIN JOB_LOG JL WITH(NOLOCK) ON A.JOB_NUMBER = JL.JOB_NUMBER 
					LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
					LEFT OUTER JOIN JOB_TRAFFIC_DET JTD WITH(NOLOCK) ON A.JOB_NUMBER = JTD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTD.SEQ_NBR
					LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS JTDE WITH(NOLOCK) ON JTD.JOB_NUMBER = JTDE.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = JTDE.SEQ_NBR 
					LEFT OUTER JOIN CLIENT C WITH(NOLOCK) ON A.CL_CODE = C.CL_CODE
					LEFT OUTER JOIN DIVISION D WITH(NOLOCK) ON A.CL_CODE = D.CL_CODE AND A.DIV_CODE = D.DIV_CODE
					LEFT OUTER JOIN PRODUCT P WITH(NOLOCK) ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE
					LEFT OUTER JOIN CAMPAIGN CMP WITH(NOLOCK) ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
					LEFT OUTER JOIN OFFICE O WITH(NOLOCK) ON A.OFFICE_CODE = O.OFFICE_CODE 
					LEFT OUTER JOIN ALERT_STATES AAS WITH(NOLOCK) ON A.ALERT_STATE_ID = AAS.ALERT_STATE_ID 
					LEFT OUTER JOIN ALERT_STATES BAS WITH(NOLOCK) ON A.BOARD_STATE_ID = BAS.ALERT_STATE_ID 
					LEFT OUTER JOIN SOFTWARE_VERSION SV WITH(NOLOCK) ON A.VER = SV.VERSION_ID
					LEFT OUTER JOIN SOFTWARE_BUILD SB WITH(NOLOCK) ON A.BUILD = SB.BUILD_ID
					LEFT OUTER JOIN SPRINT_DTL SD WITH(NOLOCK) ON A.ALERT_ID = SD.ALERT_ID 	
					LEFT OUTER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID --AND COALESCE(SH.IS_COMPLETE, 0) = 0
                    LEFT OUTER JOIN BOARD WITH (NOLOCK) ON SH.BOARD_ID = BOARD.ID
					LEFT OUTER JOIN BOARD_HDR BH WITH (NOLOCK) ON BOARD.BOARD_HDR_ID = BH.ID
					LEFT OUTER JOIN ESTIMATE_COMPONENT EC WITH(NOLOCK) ON A.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND A.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR 
					LEFT OUTER JOIN ESTIMATE_LOG EST WITH(NOLOCK) ON A.ESTIMATE_NUMBER = EST.ESTIMATE_NUMBER  
					LEFT OUTER JOIN ALERT_NOTIFY_HDR ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID 
					LEFT OUTER JOIN ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) ON A.ALERT_ID = ARD.ALERT_ID
                    LEFT OUTER JOIN EMP_NON_TASKS WITH (NOLOCK) ON A.NON_TASK_ID = EMP_NON_TASKS.NON_TASK_ID
					INNER JOIN #SEC_CLIENT SEC WITH (NOLOCK) ON ((SEC.CL_CODE = A.CL_CODE) AND (SEC.DIV_CODE = A.DIV_CODE) AND (SEC.PRD_CODE = A.PRD_CODE)) OR (IS_MY_ASSIGNMENT = 1) OR (IS_MY_TASK = 1)
				WHERE
					(@StartDate IS NULL OR (@StartDate IS NOT NULL AND A.LAST_UPDATED >= @StartDate)) AND (@EndDate IS NULL OR (@EndDate IS NOT NULL AND A.LAST_UPDATED <= @EndDate))
					AND 1 =	CASE 
								WHEN @SearchCriteria IS NULL THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 1 AND (A.JOB_NUMBER = CAST(@SearchCriteria AS BIGINT) OR COALESCE(A.ALERT_SEQ_NBR, A.ALERT_ID) = CAST(@SearchCriteria AS BIGINT)) THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(A.[SUBJECT]) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(A.ALERT_USER) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(CAST(A.BODY AS VARCHAR(MAX))) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								ELSE 0
							END								
					--AND 1 = CASE				
					--			WHEN @SHOW_TASKS = 1 AND (A.ALERT_CAT_ID = 71 OR AA.[IS_ROUTED_ASSIGNMENT] = 1 OR AA.[IS_NONROUTED_ASSIGNMENT] = 1) THEN 1
					--			WHEN @SHOW_TASKS = 0 THEN 1
					--			ELSE 0
					--		END
					AND 1 = CASE 
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID <> 71 THEN 1
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 1 THEN 1
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 0 THEN 0							
								WHEN @ShowOnlyTempComp = 0 THEN 1
								ELSE 1
							END
					--AND 1 = CASE 
					--			WHEN @EmployeeRole IS NOT NULL AND AA.EMP_ROLE_CODE IN (SELECT ROLE_CODE FROM #ROLES) THEN 1
					--			WHEN @EmployeeRole IS NOT NULL AND AA.EMP_ROLE_CODE NOT IN (SELECT ROLE_CODE FROM #ROLES) THEN 0
					--			WHEN @EmployeeRole IS NULL THEN 1							
					--		END
					AND 1 = CASE
								WHEN @EmployeeRole IS NOT NULL AND COALESCE(AA.EMP_IN_ROLE, 0) = 1 THEN 1
								WHEN @EmployeeRole IS NOT NULL AND COALESCE(AA.EMP_IN_ROLE, 0) = 0 THEN 0
								WHEN @EmployeeRole IS NULL THEN 1
							END
					AND 1 = CASE 
								WHEN @Department IS NOT NULL AND AA.EMP_DEPARTMENT IN (SELECT DP_TM_CODE FROM #DEPARTMENTS) THEN 1
								WHEN @Department IS NOT NULL AND AA.EMP_DEPARTMENT NOT IN (SELECT DP_TM_CODE FROM #DEPARTMENTS) THEN 0
								WHEN @Department IS NULL THEN 1							
							END
					AND 1 = CASE
								WHEN @SHOW_ONLY_ALERTS = 1 AND A.ALERT_CAT_ID != 71 AND (IS_CC = 1) THEN 1
								WHEN @SHOW_ONLY_ALERTS = 1 AND A.ALERT_CAT_ID = 71 AND IS_CC = 1 THEN 1
								WHEN @SHOW_ONLY_ALERTS = 1 AND AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN 1
								WHEN @SHOW_ONLY_ALERTS = 0 THEN 1
								ELSE 0
							END
					AND 1 = CASE
								WHEN @SHOW_ONLY_UNASSIGNED = 1 AND IS_STANDARD_ALERT = 0 THEN 1
								WHEN @SHOW_ONLY_UNASSIGNED = 0 THEN 1
								ELSE 0
							END		
					AND 1 = CASE
								WHEN @TASK_VIEW = 1 AND @ShowOnlyTempComp = 0 AND (A.ALERT_CAT_ID = 71 OR AA.[IS_ROUTED_ASSIGNMENT] = 1 OR AA.[IS_NONROUTED_ASSIGNMENT] = 1 OR AA.[IS_TASK_ASSIGNMENT] = 1) THEN 1
								WHEN @TASK_VIEW = 1 AND @ShowOnlyTempComp = 1 AND (A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 1) THEN 1
								WHEN @TASK_VIEW = 0 THEN 1
								ELSE 0
							END		
					AND UPPER(SEC.USER_ID) = UPPER(@UserCode) AND (SEC.TIME_ENTRY = 0 OR SEC.TIME_ENTRY IS NULL)			
					AND 1 = CASE 
								WHEN @IncludeBacklog = 1 AND IS_BACKLOG_ITEM = 1 THEN 1
								WHEN @IncludeBacklog = 0 AND IS_BACKLOG_ITEM = 1 THEN 0
								ELSE 1 
							END
                UNION
                SELECT DISTINCT															
					A.ALERT_ID,
					ID = COALESCE( A.ALERT_SEQ_NBR, A.ALERT_ID),
					AA.LAST_UPDATED,
					A.[GENERATED],
					A.[PRIORITY],
					A.ALERT_CAT_ID,
					[ALERT_STATE_NAME] = AAS.ALERT_STATE_NAME,
					ALERT_LEVEL = CASE WHEN DATALENGTH(A.ALERT_LEVEL) = 0 THEN NULL ELSE A.ALERT_LEVEL END,
					ALERT_LEVEL_TEXT =	CASE 
											WHEN A.ALERT_LEVEL = 'OF' THEN 'Office'
											WHEN A.ALERT_LEVEL = 'CL' THEN 'Client'
											WHEN A.ALERT_LEVEL = 'DI' THEN 'Division'
											WHEN A.ALERT_LEVEL = 'PR' THEN 'Product'
											WHEN A.ALERT_LEVEL = 'CM' THEN 'Campaign'
											WHEN A.ALERT_LEVEL = 'JO' THEN 'Job'
											WHEN A.ALERT_LEVEL = 'JC' THEN 'Job Component'
											WHEN A.ALERT_LEVEL = 'ES' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'EST' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'PS' THEN 'Schedule'
											WHEN A.ALERT_LEVEL = 'PST' THEN 'Schedule Task'
											WHEN A.ALERT_LEVEL = 'PO' THEN 'Purchase Order'
											WHEN A.ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'
											WHEN A.ALERT_LEVEL = 'AP' THEN 'Accounts Payable'
											WHEN A.ALERT_LEVEL = 'AD' THEN 'Agency Desktop'
											WHEN A.ALERT_LEVEL = 'AN' THEN 'Ad Number'
											WHEN A.ALERT_LEVEL = 'ED' THEN 'Employee Desktop'
											WHEN A.ALERT_LEVEL = 'NA' THEN 'Approval'
											WHEN A.ALERT_LEVEL = 'VN' THEN 'Vendor'
											WHEN A.ALERT_LEVEL = 'CT' THEN 'Contract'
											WHEN A.ALERT_LEVEL = 'BRD' THEN 'Task Assignment'
											ELSE NULL
										END,
					ISNULL(A.[SUBJECT],'') AS SUBJECT, --10
					[ATTACHMENTCOUNT] = ISNULL(A.ATTACHMENT_COUNT, 0),
					AA.[START_DATE],
					AA.DUE_DATE,
					A.TIME_DUE,
					[TYPE] = AT.ALERT_TYPE_DESC,
					CATEGORY = AC.ALERT_DESC,
					C.CL_NAME,
					SV.[VERSION],
					SB.BUILD,
					JOB_NUMBER = AA.JOB_NUMBER, --20
					JOB_COMPONENT_NBR = AA.JOB_COMPONENT_NBR,
					SPRINT_ID = ISNULL(SD.SPRINT_HDR_ID, 0),
					TASK_SEQ_NBR = A.TASK_SEQ_NBR,
					TASK_STATUS = AA.TASK_STATUS,
					GRP_OFFICE = O.OFFICE_NAME, --CASE WHEN @GroupBy = 'O' THEN O.OFFICE_NAME END,
					GRP_CLIENT = CASE WHEN @GroupBy = 'C' THEN C.CL_NAME END,
					GRP_DIVISION = D.DIV_NAME, --CASE WHEN @GroupBy = 'CD' THEN D.DIV_NAME END,
					GRP_PRODUCT = P.PRD_DESCRIPTION, --CASE WHEN @GroupBy = 'CDP' THEN P.PRD_DESCRIPTION END,
					GRP_JOB = CASE WHEN @GroupBy = 'CDPJ' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + ISNULL(JL.JOB_DESC, '') + ' | ' + C.CL_NAME END,
					GRP_COMPONENT = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6 ) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3) + ' - ' + ISNULL(JC.JOB_COMP_DESC, '') + ' | ' + C.CL_NAME,
					GRP_CAMPAIGN = ISNULL(CMP.CMP_NAME, ''), --CASE WHEN @GroupBy = 'CM' THEN ISNULL(CMP.CMP_NAME, '') END, --30
					GRP_TASK =	CASE 
									WHEN @GroupBy = 'PST' THEN 
										CASE 
											WHEN AA.TASK_FNC_CODE IS NULL OR AA.TASK_FNC_CODE = '' THEN AA.TASK_DESCRIPTION 
											ELSE AA.TASK_DESCRIPTION
										END
							   END,
					GRP_ESTIMATE = CASE WHEN @GroupBy = 'ES' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + ' - ' + ISNULL(EST.EST_LOG_DESC, '') END,
					GRP_ESTIMATE_COMPONENT = CASE WHEN @GroupBy = 'EST' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), A.EST_COMPONENT_NBR), 2) + ' - ' + ISNULL(EC.EST_COMP_DESC, '') END,
					GRP_DUE_DATE =	AA.GRP_DUE_DATE,
					GRP_DUE_DATE_DISPLAY =	AA.GRP_DUE_DATE_DISPLAY,
					GRP_PRIORITY =	CASE
										WHEN A.[PRIORITY] = 1 THEN 'Highest'
										WHEN A.[PRIORITY] = 2 THEN 'High'
										WHEN A.[PRIORITY] = 3 THEN 'Normal'
										WHEN A.[PRIORITY] = 4 THEN 'Low'
										WHEN A.[PRIORITY] = 5 THEN 'Lowest'
										ELSE 'Normal'
									END,
					ALERT_NOTIFY_NAME = ANH.ALERT_NOTIFY_NAME,
					A.CL_CODE, 
					A.DIV_CODE, 
					A.PRD_CODE,  --40
					A.CMP_CODE,
					[CURRENT_NOTIFY] = CAST(ISNULL(AA.CURRENT_NOTIFY, 0) AS BIT),
					AA.CURRENT_NOTIFY_EMP_FML,
					IS_ASSIGNMENT =	CASE 
										WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) 
										ELSE CAST(0 AS BIT) 
									END,
					[IS_WORK_ITEM] = ISNULL(A.IS_WORK_ITEM, 0),
					[IS_STANDARD_ALERT] = ISNULL(AA.IS_STANDARD_ALERT, 0),
					[IS_CC] = CAST(ISNULL(IS_CC, 0) AS BIT),
					[IS_ROUTED_ASSIGNMENT] = ISNULL(AA.IS_ROUTED_ASSIGNMENT, 0),
					[IS_NONROUTED_ASSIGNMENT] = ISNULL(AA.IS_NONROUTED_ASSIGNMENT, 0),
					[IS_TASK_ASSIGNMENT] = ISNULL(AA.IS_TASK_ASSIGNMENT, 0), --50
					[COMPLETE_ASSIGNEES_CT] = ISNULL(AA.COMPLETE_ASSIGNEES_CT, 0),
					[OPEN_ASSIGNEES_CT] = ISNULL(AA.OPEN_ASSIGNEES_CT, 0),
					[DISMISSED_RECIPIENTS_CT] = ISNULL(AA.DISMISSED_RECIPIENTS_CT, 0),
					[OPEN_RECIPIENTS_CT] = ISNULL(AA.OPEN_RECIPIENTS_CT, 0),
					[IS_MY_ASSIGNMENT] = ISNULL(IS_MY_ASSIGNMENT, 0),
					[IS_MY_ASSIGNMENT_COMPLETED] = ISNULL(IS_MY_ASSIGNMENT_COMPLETED, 0),
					[IS_MY_ALERT] = ISNULL(IS_MY_ALERT, 0),
					[IS_MY_ALERT_COMPLETED] = ISNULL(IS_MY_ALERT_COMPLETED, 0),
					[IS_MY_TASK] = ISNULL(IS_MY_TASK, 0),
					[IS_TASK_COMPLETED] = ISNULL(IS_TASK_COMPLETED, 0), --60
					AA.ASSIGN_COMPLETED,
					AA.USER_ORDER_SEQ_NBR,
					AA.IS_UNASSIGNED,
					[READ_ALERT] = AA.IS_READ,
					AA.AE_NAME, --65
					AA.PM_NAME,
					AA.IS_MY_TASK_TEMP_COMPLETE,	
					[JOB_DESC] = ISNULL(JL.JOB_DESC, ''),
					[JOB_COMP_DESC] = ISNULL(JC.JOB_COMP_DESC, ''),
					[TASK_COMMENTS] = ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)), ''),
					[HOURS_ALLOWED] = JTD.JOB_HRS,				


					[Subject] = A.[SUBJECT], --10
					[Generated] = A.GENERATED,
					[GeneratedNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, A.GENERATED)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, A.GENERATED)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, A.GENERATED)),2) + ' ' +
											 RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, A.GENERATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, A.GENERATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, A.GENERATED)),2) AS DATE),
					[LastUpdated] = AA.LAST_UPDATED,
					[LastUpdatedNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, AA.LAST_UPDATED)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, AA.LAST_UPDATED)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, AA.LAST_UPDATED)),2) + ' ' +
											   RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, AA.LAST_UPDATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, AA.LAST_UPDATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, AA.LAST_UPDATED)),2) AS DATE),
					[StartDate] = CASE WHEN AA.[START_DATE] IS NULL AND ISNULL(A.NON_TASK_ID,0) > 0 THEN EMP_NON_TASKS.[START_DATE] ELSE AA.[START_DATE] END,		
					[DueDate] = AA.DUE_DATE,				
					[TimeDue] = A.TIME_DUE,
					[AlertStateName] =	AAS.ALERT_STATE_NAME,
					[Priority] = A.[PRIORITY],
					[AssignedTo] = AA.CURRENT_NOTIFY_EMP_FML,	
					[AssignedToEmpCode] = AA.CURRENT_NOTIFY_EMP_CODE,
					[Category] = AC.ALERT_DESC,
					[ClientName] = C.CL_NAME,
					[ClientCode] = A.CL_CODE, 
					[GroupDivision] = D.DIV_NAME,				
					[DivisionCode] = A.DIV_CODE, 
					[GroupProduct] = P.PRD_DESCRIPTION,
					[ProductCode] = A.PRD_CODE,  --40
					[Job] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + ISNULL(JL.JOB_DESC, '') ELSE '' END,					
					[JobNumber] = ISNULL(JL.JOB_NUMBER, 0),
					[JobComponent] = CASE WHEN A.JOB_COMPONENT_NBR IS NOT NULL THEN RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) + ' - ' + ISNULL(JC.JOB_COMP_DESC, '') ELSE '' END,
					[ComponentNumber] = ISNULL(A.JOB_COMPONENT_NBR, 0),

					[JobComponentDetailed] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(VARCHAR(6), ISNULL(JL.JOB_NUMBER, 0)), 6) + '/' + RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) +
											' - ' + ISNULL(JL.JOB_DESC,'') + CASE WHEN ISNULL(JC.JOB_COMP_DESC, '') != ISNULL(JL.JOB_DESC,'') THEN ' | ' + ISNULL(JC.JOB_COMP_DESC, '') ELSE '' END ELSE '' END,

					[JobAndComponentNumber] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(VARCHAR(6), ISNULL(JL.JOB_NUMBER, 0)), 6) + '/' + RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) ELSE '' END,
					[JobDescription] = ISNULL(JL.JOB_DESC,''),	
					[ComponentDescription] = ISNULL(JC.JOB_COMP_DESC, ''),
					[ID] = COALESCE( A.ALERT_SEQ_NBR, A.ALERT_ID),							
					[SoftwareVersion] = SV.[VERSION],
					[SoftwareBuild] = SB.BUILD,			
					[AlertTypeText] = AT.ALERT_TYPE_DESC,				
					[AccountExecutive] = AA.AE_NAME, --65
					[ProjectManager] = AA.PM_NAME,
					[GroupOffice] = O.OFFICE_NAME,
					[GroupCampaign] = ISNULL(CMP.CMP_NAME, ''), 
					[GroupAlertTemplateName] = ANH.ALERT_NOTIFY_NAME,
					[IsRead] = ISNULL(AA.IS_READ, 0),
					[AlertCategoryID] = A.ALERT_CAT_ID,				
					[SprintID] = ISNULL(SD.SPRINT_HDR_ID, 0),
					[AlertID] = A.ALERT_ID,					
					[IsTaskAssignment] = ISNULL(AA.IS_TASK_ASSIGNMENT, 0), --50
					[AttachmentCount] = ISNULL(A.ATTACHMENT_COUNT, 0),				
					[IsRoutedAssignment] = ISNULL(AA.IS_ROUTED_ASSIGNMENT, 0),
					[IsRouted] =	CASE 
										WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) 
										ELSE CAST(0 AS BIT)									
									END,
					[IsWorkItem] = ISNULL(A.IS_WORK_ITEM, 0),
					[IsCurrentAssignee] = CAST(ISNULL(AA.CURRENT_NOTIFY, 0) AS BIT),			
					[IsDismissed] = /*iF RECORD IS AN ASSIGNMENT AND EXISTS IN THE DISMISSED TABLE, THEN IS_DISMISSED = TRUE*/
									CASE
										WHEN (ISNULL(ARD.ALERT_ID, 0) <> 0) AND AA.IS_CC_DISMISSED = 1 THEN CAST(1 AS BIT)
										--	((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1))
										--THEN CAST(1 AS BIT)
										ELSE CAST(0 AS BIT)									
									END,
					[IsNonRoutedAssignment] = ISNULL(AA.IS_NONROUTED_ASSIGNMENT, 0),
					[IsCC] = CAST(ISNULL(IS_CC, 0) AS BIT),
					[IsMyAssignment] = ISNULL(IS_MY_ASSIGNMENT, 0),
					[IsMyAlert] = ISNULL(IS_MY_ALERT, 0),
					[IsMyTask] = ISNULL(IS_MY_TASK, 0),
					[TaskStatus] = AA.TASK_STATUS,				
					[TaskComments] = ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)), ''),
					[HoursAllowed] = CAST(JTD.JOB_HRS AS VARCHAR),					
					[TaskDateDiff] = DATEDIFF(DAY, GETDATE(), AA.DUE_DATE),
					[TaskDateIsWeekend] = CAST(CASE 
										WHEN DATEPART(DW,A.DUE_DATE) = 1 OR DATEPART(DW,A.DUE_DATE) = 7 THEN 1
									ELSE 0 END AS BIT),				
					--DATE COLORING SHOULD BE EXTENDED ALL GRID ITEMS WITH A DUE DATE, NOT JUST TASKS
					/*[TaskDateDiff] = DATEDIFF(DAY, GETDATE(), JTD.JOB_REVISED_DATE),
					[TaskDateIsWeekend] = CAST(CASE 
										WHEN A.ALERT_CAT_ID = 71 AND (DATEPART(DW,JTD.JOB_REVISED_DATE) = 1 OR DATEPART(DW,JTD.JOB_REVISED_DATE) = 7) THEN 1
									ELSE 0 END AS BIT),				*/	
					--[EmployeeRoleCode] = AA.EMP_ROLE_CODE,
					--[EmployeeRoleDescription] = AA.EMP_ROLE_DESCRIPTION,					
					[GroupPriority] =	CASE
										WHEN A.[PRIORITY] = 1 THEN 'Highest'
										WHEN A.[PRIORITY] = 2 THEN 'High'
										WHEN A.[PRIORITY] = 3 THEN 'Normal'
										WHEN A.[PRIORITY] = 4 THEN 'Low'
										WHEN A.[PRIORITY] = 5 THEN 'Lowest'
										ELSE 'Normal'
									END,
					[CDPCodes] = CASE WHEN LEN(A.CL_CODE) > 0 THEN A.CL_CODE + '|' + A.DIV_CODE + '|' + A.PRD_CODE ELSE '' END,
					[TaskSequenceNumber] = A.TASK_SEQ_NBR,
					[IsMyTaskTempComplete] = ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0),						
					[IsOwnerAssignmentAlert] = ISNULL(AA.IS_OWNER_ASSIGNMENT_ALERT, 0),
					[UserName] = CASE
									WHEN A.CP_ALERT = 1 AND ISNUMERIC(A.ALERT_USER_CP) = 1 THEN (SELECT CONT_FML FROM CDP_CONTACT_HDR WITH (NOLOCK) WHERE  CDP_CONTACT_ID = CAST(A.ALERT_USER_CP AS INT))
									ELSE A.LAST_UPDATED_FML
									END,
					[IsDraft] = ISNULL(A.IS_DRAFT,0),  
					[TempCompleteDate] = AA.TEMP_COMPLETE_DATE,
					[TempCompleteDateNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, AA.TEMP_COMPLETE_DATE)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, AA.TEMP_COMPLETE_DATE)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, AA.TEMP_COMPLETE_DATE)),2) + ' ' +
													RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, AA.TEMP_COMPLETE_DATE)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, AA.TEMP_COMPLETE_DATE)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, AA.TEMP_COMPLETE_DATE)),2) AS DATE),
				
					[AlertLevel] = CASE WHEN DATALENGTH(A.ALERT_LEVEL) = 0 THEN NULL ELSE A.ALERT_LEVEL END,
					[AlertLevelText] =	CASE 
											WHEN A.ALERT_LEVEL = 'OF' THEN 'Office'
											WHEN A.ALERT_LEVEL = 'CL' THEN 'Client'
											WHEN A.ALERT_LEVEL = 'DI' THEN 'Division'
											WHEN A.ALERT_LEVEL = 'PR' THEN 'Product'
											WHEN A.ALERT_LEVEL = 'CM' THEN 'Campaign'
											WHEN A.ALERT_LEVEL = 'JO' THEN 'Job'
											WHEN A.ALERT_LEVEL = 'JC' THEN 'Job Component'
											WHEN A.ALERT_LEVEL = 'ES' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'EST' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'PS' THEN 'Schedule'
											WHEN A.ALERT_LEVEL = 'PST' THEN 'Schedule Task'
											WHEN A.ALERT_LEVEL = 'PO' THEN 'Purchase Order'
											WHEN A.ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'
											WHEN A.ALERT_LEVEL = 'AP' THEN 'Accounts Payable'
											WHEN A.ALERT_LEVEL = 'AD' THEN 'Agency Desktop'
											WHEN A.ALERT_LEVEL = 'AN' THEN 'Ad Number'
											WHEN A.ALERT_LEVEL = 'ED' THEN 'Employee Desktop'
											WHEN A.ALERT_LEVEL = 'NA' THEN 'Approval'
											WHEN A.ALERT_LEVEL = 'VN' THEN 'Vendor'
											WHEN A.ALERT_LEVEL = 'CT' THEN 'Contract'
											WHEN A.ALERT_LEVEL = 'BRD' THEN 'Task Assignment'
											ELSE NULL
										END,
					[GroupClient] = CASE WHEN @GroupBy = 'C' THEN C.CL_NAME END,				
					[GroupTask] =	CASE 
										WHEN @GroupBy = 'PST' THEN 
											CASE 
												WHEN AA.TASK_FNC_CODE IS NULL OR AA.TASK_FNC_CODE = '' THEN AA.TASK_DESCRIPTION 
												ELSE AA.TASK_DESCRIPTION
											END
									END,
					[GroupEstimate] = CASE WHEN @GroupBy = 'ES' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + ' - ' + ISNULL(EST.EST_LOG_DESC, '') END,
					[GroupEstimateComponent] = CASE WHEN @GroupBy = 'EST' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), A.EST_COMPONENT_NBR), 2) + ' - ' + ISNULL(EC.EST_COMP_DESC, '') END,
					[GroupDueDate] = AA.GRP_DUE_DATE,
					[GroupDueDateDisplay] =	AA.GRP_DUE_DATE_DISPLAY,
					[CampaignCode] = A.CMP_CODE,
					[IsStandardAlert] = ISNULL(AA.IS_STANDARD_ALERT, 0),
					[CompletedAssigneesCount] = ISNULL(AA.COMPLETE_ASSIGNEES_CT, 0),
					[OpenAssigneesCount] = ISNULL(AA.OPEN_ASSIGNEES_CT, 0),
					[DismissedRecipientsCount] = ISNULL(AA.DISMISSED_RECIPIENTS_CT, 0),
					[OpenRecipientsCount] = ISNULL(AA.OPEN_RECIPIENTS_CT, 0),				
					[IsMyAssignmentCompleted] = ISNULL(IS_MY_ASSIGNMENT_COMPLETED, 0),				
					[IsMyAlertCompleted] = ISNULL(IS_MY_ALERT_COMPLETED, 0),				
					[IsTaskCompleted] = ISNULL(IS_TASK_COMPLETED, 0),
					[AssignmentCompleted] = AA.ASSIGN_COMPLETED,
					[UserOrder] = AA.USER_ORDER_SEQ_NBR,
					[IsUnAssigned] = ISNULL(AA.IS_UNASSIGNED, 0),
					[AssignedEmpCode] = A.ASSIGNED_EMP_CODE,				
					[EmployeeDepartment] = AA.EMP_DEPARTMENT,							
					[CCEmployeeCodes] = CASE
								--WHEN A.ALERT_CAT_ID = 71 THEN NULL
								WHEN AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN NULL
								WHEN AA.IS_STANDARD_ALERT = 1 THEN NULL
								ELSE AA.CC_EMPLOYEE_CODES
							END,
					[CCEmployeeNames] = CASE
								--WHEN A.ALERT_CAT_ID = 71 THEN NULL
								WHEN AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN NULL
								WHEN AA.IS_STANDARD_ALERT = 1 THEN NULL
								ELSE AA.CC_EMPLOYEE_NAMES
							END,
                    [Board] = CASE WHEN AA.BOARD_EXCLUDE_TASKS = 1 THEN '' ELSE ISNULL(AA.BOARD_NAME,'') END,
                    [BoardState] = ISNULL(CASE WHEN AA.BOARD_EXCLUDE_TASKS = 1 THEN ''
									WHEN AA.IS_BACKLOG_ITEM = 1 THEN 'Backlog'
									WHEN SD.ALERT_ID IS NOT NULL AND BAS.ALERT_STATE_ID IS NOT NULL THEN CASE WHEN AA.ASSIGN_COMPLETED = 1 
									THEN 'Completed' ELSE BAS.ALERT_STATE_NAME END END,''),
                    [Sprint] = ISNULL(SH.[DESCRIPTION],''),
                    [SprintStartDate] = SH.[START_DATE],
					[IsBacklogItem] = AA.IS_BACKLOG_ITEM,
					[TaskStatusDescription] = CASE WHEN ISNULL(AA.IS_TASK_ASSIGNMENT, 0) = 1 AND AA.TASK_STATUS = 'A' THEN 'Active'
									WHEN ISNULL(AA.IS_TASK_ASSIGNMENT, 0) = 1 AND AA.TASK_STATUS = 'P' THEN 'Projected'					
									ELSE '' END					
				FROM 
					#ALERT AA
					INNER JOIN ALERT A WITH(NOLOCK) ON A.ALERT_ID = AA.ALERT_ID
					INNER JOIN ALERT_TYPE AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID 
					INNER JOIN ALERT_CATEGORY AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID 
					LEFT OUTER JOIN JOB_LOG JL WITH(NOLOCK) ON A.JOB_NUMBER = JL.JOB_NUMBER 
					LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
					LEFT OUTER JOIN JOB_TRAFFIC_DET JTD WITH(NOLOCK) ON A.JOB_NUMBER = JTD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTD.SEQ_NBR
					LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS JTDE WITH(NOLOCK) ON JTD.JOB_NUMBER = JTDE.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = JTDE.SEQ_NBR 
					LEFT OUTER JOIN CLIENT C WITH(NOLOCK) ON A.CL_CODE = C.CL_CODE
					LEFT OUTER JOIN DIVISION D WITH(NOLOCK) ON A.CL_CODE = D.CL_CODE AND A.DIV_CODE = D.DIV_CODE
					LEFT OUTER JOIN PRODUCT P WITH(NOLOCK) ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE
					LEFT OUTER JOIN CAMPAIGN CMP WITH(NOLOCK) ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
					LEFT OUTER JOIN OFFICE O WITH(NOLOCK) ON A.OFFICE_CODE = O.OFFICE_CODE 
					LEFT OUTER JOIN ALERT_STATES AAS WITH(NOLOCK) ON A.ALERT_STATE_ID = AAS.ALERT_STATE_ID 
					LEFT OUTER JOIN ALERT_STATES BAS WITH(NOLOCK) ON A.BOARD_STATE_ID = BAS.ALERT_STATE_ID 
					LEFT OUTER JOIN SOFTWARE_VERSION SV WITH(NOLOCK) ON A.VER = SV.VERSION_ID
					LEFT OUTER JOIN SOFTWARE_BUILD SB WITH(NOLOCK) ON A.BUILD = SB.BUILD_ID
					LEFT OUTER JOIN SPRINT_DTL SD WITH(NOLOCK) ON A.ALERT_ID = SD.ALERT_ID 	
					LEFT OUTER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID --AND COALESCE(SH.IS_COMPLETE, 0) = 0
                    LEFT OUTER JOIN BOARD WITH (NOLOCK) ON SH.BOARD_ID = BOARD.ID
					LEFT OUTER JOIN BOARD_HDR BH WITH (NOLOCK) ON BOARD.BOARD_HDR_ID = BH.ID
					LEFT OUTER JOIN ESTIMATE_COMPONENT EC WITH(NOLOCK) ON A.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND A.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR 
					LEFT OUTER JOIN ESTIMATE_LOG EST WITH(NOLOCK) ON A.ESTIMATE_NUMBER = EST.ESTIMATE_NUMBER  
					LEFT OUTER JOIN ALERT_NOTIFY_HDR ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID 
					LEFT OUTER JOIN ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) ON A.ALERT_ID = ARD.ALERT_ID
                    LEFT OUTER JOIN EMP_NON_TASKS WITH (NOLOCK) ON A.NON_TASK_ID = EMP_NON_TASKS.NON_TASK_ID
					--INNER JOIN #SEC_CLIENT SEC WITH (NOLOCK) ON ((SEC.CL_CODE = A.CL_CODE) AND (SEC.DIV_CODE = A.DIV_CODE) AND (SEC.PRD_CODE = A.PRD_CODE)) OR (IS_MY_ASSIGNMENT = 1) OR (IS_MY_TASK = 1)
				WHERE
					(@StartDate IS NULL OR (@StartDate IS NOT NULL AND A.LAST_UPDATED >= @StartDate)) AND (@EndDate IS NULL OR (@EndDate IS NOT NULL AND A.LAST_UPDATED <= @EndDate))
					AND 1 =	CASE 
								WHEN @SearchCriteria IS NULL THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 1 AND (A.JOB_NUMBER = CAST(@SearchCriteria AS BIGINT) OR COALESCE(A.ALERT_SEQ_NBR, A.ALERT_ID) = CAST(@SearchCriteria AS BIGINT)) THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(A.[SUBJECT]) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(A.ALERT_USER) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(CAST(A.BODY AS VARCHAR(MAX))) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								ELSE 0
							END								
					--AND 1 = CASE				
					--			WHEN @SHOW_TASKS = 1 AND (A.ALERT_CAT_ID = 71 OR AA.[IS_ROUTED_ASSIGNMENT] = 1 OR AA.[IS_NONROUTED_ASSIGNMENT] = 1) THEN 1
					--			WHEN @SHOW_TASKS = 0 THEN 1
					--			ELSE 0
					--		END
					AND 1 = CASE 
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID <> 71 THEN 1
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 1 THEN 1
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 0 THEN 0							
								WHEN @ShowOnlyTempComp = 0 THEN 1
								ELSE 1
							END
					--AND 1 = CASE 
					--			WHEN @EmployeeRole IS NOT NULL AND AA.EMP_ROLE_CODE IN (SELECT ROLE_CODE FROM #ROLES) THEN 1
					--			WHEN @EmployeeRole IS NOT NULL AND AA.EMP_ROLE_CODE NOT IN (SELECT ROLE_CODE FROM #ROLES) THEN 0
					--			WHEN @EmployeeRole IS NULL THEN 1							
					--		END
					AND 1 = CASE
								WHEN @EmployeeRole IS NOT NULL AND COALESCE(AA.EMP_IN_ROLE, 0) = 1 THEN 1
								WHEN @EmployeeRole IS NOT NULL AND COALESCE(AA.EMP_IN_ROLE, 0) = 0 THEN 0
								WHEN @EmployeeRole IS NULL THEN 1
							END
					AND 1 = CASE 
								WHEN @Department IS NOT NULL AND AA.EMP_DEPARTMENT IN (SELECT DP_TM_CODE FROM #DEPARTMENTS) THEN 1
								WHEN @Department IS NOT NULL AND AA.EMP_DEPARTMENT NOT IN (SELECT DP_TM_CODE FROM #DEPARTMENTS) THEN 0
								WHEN @Department IS NULL THEN 1							
							END
					AND 1 = CASE
								WHEN @SHOW_ONLY_ALERTS = 1 AND A.ALERT_CAT_ID != 71 AND (IS_CC = 1) THEN 1
								WHEN @SHOW_ONLY_ALERTS = 1 AND A.ALERT_CAT_ID = 71 AND IS_CC = 1 THEN 1
								WHEN @SHOW_ONLY_ALERTS = 1 AND AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN 1
								WHEN @SHOW_ONLY_ALERTS = 0 THEN 1
								ELSE 0
							END
					AND 1 = CASE
								WHEN @SHOW_ONLY_UNASSIGNED = 1 AND IS_STANDARD_ALERT = 0 THEN 1
								WHEN @SHOW_ONLY_UNASSIGNED = 0 THEN 1
								ELSE 0
							END		
					AND 1 = CASE
								WHEN @TASK_VIEW = 1 AND @ShowOnlyTempComp = 0 AND (A.ALERT_CAT_ID = 71 OR AA.[IS_ROUTED_ASSIGNMENT] = 1 OR AA.[IS_NONROUTED_ASSIGNMENT] = 1 OR AA.[IS_TASK_ASSIGNMENT] = 1) THEN 1
								WHEN @TASK_VIEW = 1 AND @ShowOnlyTempComp = 1 AND (A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 1) THEN 1
								WHEN @TASK_VIEW = 0 THEN 1
								ELSE 0
							END		
					--AND UPPER(SEC.USER_ID) = UPPER(@UserCode) AND (SEC.TIME_ENTRY = 0 OR SEC.TIME_ENTRY IS NULL)			
					AND 1 = CASE 
								WHEN @IncludeBacklog = 1 AND IS_BACKLOG_ITEM = 1 THEN 1
								WHEN @IncludeBacklog = 0 AND IS_BACKLOG_ITEM = 1 THEN 0
								ELSE 1 
							END
                    AND A.CL_CODE IS NULL
				ORDER BY 
					AA.USER_ORDER_SEQ_NBR,
					AA.LAST_UPDATED DESC
			END
			ELSE
			BEGIN
				SELECT DISTINCT														
					A.ALERT_ID,
					ID = COALESCE( A.ALERT_SEQ_NBR, A.ALERT_ID),
					AA.LAST_UPDATED,
					A.[GENERATED],
					A.[PRIORITY],
					A.ALERT_CAT_ID,
					[ALERT_STATE_NAME] = AAS.ALERT_STATE_NAME,
					ALERT_LEVEL = CASE WHEN DATALENGTH(A.ALERT_LEVEL) = 0 THEN NULL ELSE A.ALERT_LEVEL END,
					ALERT_LEVEL_TEXT =	CASE 
											WHEN A.ALERT_LEVEL = 'OF' THEN 'Office'
											WHEN A.ALERT_LEVEL = 'CL' THEN 'Client'
											WHEN A.ALERT_LEVEL = 'DI' THEN 'Division'
											WHEN A.ALERT_LEVEL = 'PR' THEN 'Product'
											WHEN A.ALERT_LEVEL = 'CM' THEN 'Campaign'
											WHEN A.ALERT_LEVEL = 'JO' THEN 'Job'
											WHEN A.ALERT_LEVEL = 'JC' THEN 'Job Component'
											WHEN A.ALERT_LEVEL = 'ES' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'EST' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'PS' THEN 'Schedule'
											WHEN A.ALERT_LEVEL = 'PST' THEN 'Schedule Task'
											WHEN A.ALERT_LEVEL = 'PO' THEN 'Purchase Order'
											WHEN A.ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'
											WHEN A.ALERT_LEVEL = 'AP' THEN 'Accounts Payable'
											WHEN A.ALERT_LEVEL = 'AD' THEN 'Agency Desktop'
											WHEN A.ALERT_LEVEL = 'AN' THEN 'Ad Number'
											WHEN A.ALERT_LEVEL = 'ED' THEN 'Employee Desktop'
											WHEN A.ALERT_LEVEL = 'NA' THEN 'Approval'
											WHEN A.ALERT_LEVEL = 'VN' THEN 'Vendor'
											WHEN A.ALERT_LEVEL = 'CT' THEN 'Contract'
											WHEN A.ALERT_LEVEL = 'BRD' THEN 'Task Assignment'
											ELSE NULL
										END,
					ISNULL(A.[SUBJECT],'') AS SUBJECT, --10
					[ATTACHMENTCOUNT] = ISNULL(A.ATTACHMENT_COUNT, 0),
					AA.[START_DATE],
					AA.DUE_DATE,
					A.TIME_DUE,
					[TYPE] = AT.ALERT_TYPE_DESC,
					CATEGORY = AC.ALERT_DESC,
					C.CL_NAME,
					SV.[VERSION],
					SB.BUILD,
					JOB_NUMBER = AA.JOB_NUMBER, --20
					JOB_COMPONENT_NBR = AA.JOB_COMPONENT_NBR,
					SPRINT_ID = ISNULL(SD.SPRINT_HDR_ID, 0),
					TASK_SEQ_NBR = A.TASK_SEQ_NBR,
					TASK_STATUS = AA.TASK_STATUS,
					GRP_OFFICE = O.OFFICE_NAME, --CASE WHEN @GroupBy = 'O' THEN O.OFFICE_NAME END,
					GRP_CLIENT = CASE WHEN @GroupBy = 'C' THEN C.CL_NAME END,
					GRP_DIVISION = D.DIV_NAME, --CASE WHEN @GroupBy = 'CD' THEN D.DIV_NAME END,
					GRP_PRODUCT = P.PRD_DESCRIPTION, --CASE WHEN @GroupBy = 'CDP' THEN P.PRD_DESCRIPTION END,
					GRP_JOB = CASE WHEN @GroupBy = 'CDPJ' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + ISNULL(JL.JOB_DESC, '') + ' | ' + C.CL_NAME END,
					GRP_COMPONENT = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6 ) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3) + ' - ' + ISNULL(JC.JOB_COMP_DESC, '') + ' | ' + C.CL_NAME,
					GRP_CAMPAIGN = ISNULL(CMP.CMP_NAME, ''), --CASE WHEN @GroupBy = 'CM' THEN ISNULL(CMP.CMP_NAME, '') END, --30
					GRP_TASK =	CASE 
									WHEN @GroupBy = 'PST' THEN 
										CASE 
											WHEN AA.TASK_FNC_CODE IS NULL OR AA.TASK_FNC_CODE = '' THEN AA.TASK_DESCRIPTION 
											ELSE AA.TASK_DESCRIPTION
										END
							   END,
					GRP_ESTIMATE = CASE WHEN @GroupBy = 'ES' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + ' - ' + ISNULL(EST.EST_LOG_DESC, '') END,
					GRP_ESTIMATE_COMPONENT = CASE WHEN @GroupBy = 'EST' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), A.EST_COMPONENT_NBR), 2) + ' - ' + ISNULL(EC.EST_COMP_DESC, '') END,
					GRP_DUE_DATE =	AA.GRP_DUE_DATE,
					GRP_DUE_DATE_DISPLAY =	AA.GRP_DUE_DATE_DISPLAY,
					GRP_PRIORITY =	CASE
										WHEN A.[PRIORITY] = 1 THEN 'Highest'
										WHEN A.[PRIORITY] = 2 THEN 'High'
										WHEN A.[PRIORITY] = 3 THEN 'Normal'
										WHEN A.[PRIORITY] = 4 THEN 'Low'
										WHEN A.[PRIORITY] = 5 THEN 'Lowest'
										ELSE 'Normal'
									END,
					ALERT_NOTIFY_NAME = ANH.ALERT_NOTIFY_NAME,
					A.CL_CODE, 
					A.DIV_CODE, 
					A.PRD_CODE,  --40
					A.CMP_CODE,
					[CURRENT_NOTIFY] = CAST(ISNULL(AA.CURRENT_NOTIFY, 0) AS BIT),
					AA.CURRENT_NOTIFY_EMP_FML,
					IS_ASSIGNMENT =	CASE 
										WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) 
										ELSE CAST(0 AS BIT) 
									END,
					[IS_WORK_ITEM] = ISNULL(A.IS_WORK_ITEM, 0),
					[IS_STANDARD_ALERT] = ISNULL(AA.IS_STANDARD_ALERT, 0),
					[IS_CC] = CAST(ISNULL(IS_CC, 0) AS BIT),
					[IS_ROUTED_ASSIGNMENT] = ISNULL(AA.IS_ROUTED_ASSIGNMENT, 0),
					[IS_NONROUTED_ASSIGNMENT] = ISNULL(AA.IS_NONROUTED_ASSIGNMENT, 0),
					[IS_TASK_ASSIGNMENT] = ISNULL(AA.IS_TASK_ASSIGNMENT, 0), --50
					[COMPLETE_ASSIGNEES_CT] = ISNULL(AA.COMPLETE_ASSIGNEES_CT, 0),
					[OPEN_ASSIGNEES_CT] = ISNULL(AA.OPEN_ASSIGNEES_CT, 0),
					[DISMISSED_RECIPIENTS_CT] = ISNULL(AA.DISMISSED_RECIPIENTS_CT, 0),
					[OPEN_RECIPIENTS_CT] = ISNULL(AA.OPEN_RECIPIENTS_CT, 0),
					[IS_MY_ASSIGNMENT] = ISNULL(IS_MY_ASSIGNMENT, 0),
					[IS_MY_ASSIGNMENT_COMPLETED] = ISNULL(IS_MY_ASSIGNMENT_COMPLETED, 0),
					[IS_MY_ALERT] = ISNULL(IS_MY_ALERT, 0),
					[IS_MY_ALERT_COMPLETED] = ISNULL(IS_MY_ALERT_COMPLETED, 0),
					[IS_MY_TASK] = ISNULL(IS_MY_TASK, 0),
					[IS_TASK_COMPLETED] = ISNULL(IS_TASK_COMPLETED, 0), --60
					AA.ASSIGN_COMPLETED,
					AA.USER_ORDER_SEQ_NBR,
					AA.IS_UNASSIGNED,
					[READ_ALERT] = AA.IS_READ,
					AA.AE_NAME, --65
					AA.PM_NAME,
					AA.IS_MY_TASK_TEMP_COMPLETE,	
					[JOB_DESC] = ISNULL(JL.JOB_DESC, ''),
					[JOB_COMP_DESC] = ISNULL(JC.JOB_COMP_DESC, ''),
					[TASK_COMMENTS] = ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)), ''),
					[HOURS_ALLOWED] = JTD.JOB_HRS,				


					[Subject] = A.[SUBJECT], --10
					[Generated] = A.GENERATED,
					[GeneratedNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, A.GENERATED)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, A.GENERATED)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, A.GENERATED)),2) + ' ' +
											 RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, A.GENERATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, A.GENERATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, A.GENERATED)),2) AS DATE),
					[LastUpdated] = AA.LAST_UPDATED,
					[LastUpdatedNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, AA.LAST_UPDATED)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, AA.LAST_UPDATED)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, AA.LAST_UPDATED)),2) + ' ' +
											   RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, AA.LAST_UPDATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, AA.LAST_UPDATED)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, AA.LAST_UPDATED)),2) AS DATE),
					[StartDate] = CASE WHEN AA.[START_DATE] IS NULL AND ISNULL(A.NON_TASK_ID,0) > 0 THEN EMP_NON_TASKS.[START_DATE] ELSE AA.[START_DATE] END,				
					[DueDate] = AA.DUE_DATE,				
					[TimeDue] = A.TIME_DUE,
					[AlertStateName] =AAS.ALERT_STATE_NAME,
					[Priority] = A.[PRIORITY],
					[AssignedTo] = AA.CURRENT_NOTIFY_EMP_FML,	
					[AssignedToEmpCode] = AA.CURRENT_NOTIFY_EMP_CODE,
					[Category] = AC.ALERT_DESC,
					[ClientName] = C.CL_NAME,
					[ClientCode] = A.CL_CODE, 
					[GroupDivision] = D.DIV_NAME,				
					[DivisionCode] = A.DIV_CODE, 
					[GroupProduct] = P.PRD_DESCRIPTION,
					[ProductCode] = A.PRD_CODE,  --40
					[Job] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + ' - ' + ISNULL(JL.JOB_DESC, '') ELSE '' END,					
					[JobNumber] = ISNULL(JL.JOB_NUMBER, 0),
					[JobComponent] = CASE WHEN A.JOB_COMPONENT_NBR IS NOT NULL AND A.JOB_COMPONENT_NBR <> 0 THEN RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) + ' - ' + ISNULL(JC.JOB_COMP_DESC, '') ELSE '' END,
					[ComponentNumber] = ISNULL(A.JOB_COMPONENT_NBR, 0),

					[JobComponentDetailed] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(VARCHAR(6), ISNULL(JL.JOB_NUMBER, 0)), 6) + '/' + RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) +
											' - ' + ISNULL(JL.JOB_DESC,'') + CASE WHEN ISNULL(JC.JOB_COMP_DESC, '') != ISNULL(JL.JOB_DESC,'') THEN ' | ' + ISNULL(JC.JOB_COMP_DESC, '') ELSE '' END ELSE '' END,

					[JobAndComponentNumber] = CASE WHEN JL.JOB_NUMBER IS NOT NULL THEN RIGHT('000000' + CONVERT(VARCHAR(6), ISNULL(JL.JOB_NUMBER, 0)), 6) + '/' + RIGHT('000' + CONVERT(VARCHAR(3), ISNULL(A.JOB_COMPONENT_NBR, 0)), 3) ELSE '' END,
					[JobDescription] = ISNULL(JL.JOB_DESC,''),	
					[ComponentDescription] = ISNULL(JC.JOB_COMP_DESC, ''),
					[ID] = COALESCE( A.ALERT_SEQ_NBR, A.ALERT_ID),							
					[SoftwareVersion] = SV.[VERSION],
					[SoftwareBuild] = SB.BUILD,			
					[AlertTypeText] = AT.ALERT_TYPE_DESC,				
					[AccountExecutive] = AA.AE_NAME, --65
					[ProjectManager] = AA.PM_NAME,
					[GroupOffice] = O.OFFICE_NAME,
					[GroupCampaign] = ISNULL(CMP.CMP_NAME, ''), 
					[GroupAlertTemplateName] = ANH.ALERT_NOTIFY_NAME,
					[IsRead] = ISNULL(AA.IS_READ, 0),
					[AlertCategoryID] = A.ALERT_CAT_ID,				
					[SprintID] = ISNULL(SD.SPRINT_HDR_ID, 0),
					[AlertID] = A.ALERT_ID,					
					[IsTaskAssignment] = ISNULL(AA.IS_TASK_ASSIGNMENT, 0), --50
					[AttachmentCount] = ISNULL(A.ATTACHMENT_COUNT, 0),				
					[IsRoutedAssignment] = ISNULL(AA.IS_ROUTED_ASSIGNMENT, 0),
					[IsRouted] =	CASE 
										WHEN ((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) 
										ELSE CAST(0 AS BIT)									
									END,
					[IsWorkItem] = ISNULL(A.IS_WORK_ITEM, 0),
					[IsCurrentAssignee] = CAST(ISNULL(AA.CURRENT_NOTIFY, 0) AS BIT),			
					[IsDismissed] = /*iF RECORD IS AN ASSIGNMENT AND EXISTS IN THE DISMISSED TABLE, THEN IS_DISMISSED = TRUE*/
									CASE
										WHEN (ISNULL(ARD.ALERT_ID, 0) <> 0) AND AA.IS_CC_DISMISSED = 1 THEN CAST(1 AS BIT)
										--	((NOT A.ALERT_STATE_ID IS NULL AND NOT A.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT A.IS_WORK_ITEM IS NULL AND A.IS_WORK_ITEM = 1))
										--THEN CAST(1 AS BIT)
										ELSE CAST(0 AS BIT)									
									END,
					[IsNonRoutedAssignment] = ISNULL(AA.IS_NONROUTED_ASSIGNMENT, 0),
					[IsCC] = CAST(ISNULL(IS_CC, 0) AS BIT),
					[IsMyAssignment] = ISNULL(IS_MY_ASSIGNMENT, 0),
					[IsMyAlert] = ISNULL(IS_MY_ALERT, 0),
					[IsMyTask] = ISNULL(IS_MY_TASK, 0),
					[TaskStatus] = AA.TASK_STATUS,				
					[TaskComments] = ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)), ''),
					[HoursAllowed] = CAST(JTD.JOB_HRS AS VARCHAR),
					[TaskDateDiff] = DATEDIFF(DAY, GETDATE(), AA.DUE_DATE),					
					[TaskDateIsWeekend] = CAST(CASE 
										WHEN (DATEPART(DW,A.DUE_DATE) = 1 OR DATEPART(DW,A.DUE_DATE) = 7) THEN 1
									ELSE 0 END AS BIT),				
					--DATE COLORING SHOULD BE EXTENDED ALL GRID ITEMS WITH A DUE DATE, NOT JUST TASKS
					/*[TaskDateDiff] = DATEDIFF(DAY, GETDATE(), JTD.JOB_REVISED_DATE),
					[TaskDateIsWeekend] = CAST(CASE 
										WHEN A.ALERT_CAT_ID = 71 AND (DATEPART(DW,JTD.JOB_REVISED_DATE) = 1 OR DATEPART(DW,JTD.JOB_REVISED_DATE) = 7) THEN 1
									ELSE 0 END AS BIT),				*/	
					--[EmployeeRoleCode] = AA.EMP_ROLE_CODE,
					--[EmployeeRoleDescription] = AA.EMP_ROLE_DESCRIPTION,
					[GroupPriority] =	CASE
										WHEN A.[PRIORITY] = 1 THEN 'Highest'
										WHEN A.[PRIORITY] = 2 THEN 'High'
										WHEN A.[PRIORITY] = 3 THEN 'Normal'
										WHEN A.[PRIORITY] = 4 THEN 'Low'
										WHEN A.[PRIORITY] = 5 THEN 'Lowest'
										ELSE 'Normal'
									END,
					[CDPCodes] = CASE WHEN LEN(A.CL_CODE) > 0 THEN A.CL_CODE + '|' + A.DIV_CODE + '|' + A.PRD_CODE ELSE '' END,
					[TaskSequenceNumber] = A.TASK_SEQ_NBR,
					[IsMyTaskTempComplete] = ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0),						
					[IsOwnerAssignmentAlert] = ISNULL(AA.IS_OWNER_ASSIGNMENT_ALERT, 0),
					[UserName] = CASE
									WHEN A.CP_ALERT = 1 AND ISNUMERIC(A.ALERT_USER_CP) = 1 THEN (SELECT CONT_FML FROM CDP_CONTACT_HDR WITH (NOLOCK) WHERE  CDP_CONTACT_ID = CAST(A.ALERT_USER_CP AS INT))
									ELSE A.LAST_UPDATED_FML
									END,
					[IsDraft] = ISNULL(A.IS_DRAFT,0),
					[TempCompleteDate] = AA.TEMP_COMPLETE_DATE,
					[TempCompleteDateNoTime] = CAST(RIGHT('0000' + CONVERT(VARCHAR,DATEPART(YEAR, AA.TEMP_COMPLETE_DATE)),4) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MONTH, AA.TEMP_COMPLETE_DATE)),2) + '-' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(DAY, AA.TEMP_COMPLETE_DATE)),2) + ' ' +
													RIGHT('00' + CONVERT(VARCHAR,DATEPART(HOUR, AA.TEMP_COMPLETE_DATE)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(MINUTE, AA.TEMP_COMPLETE_DATE)),2) + ':' + RIGHT('00' + CONVERT(VARCHAR,DATEPART(SECOND, AA.TEMP_COMPLETE_DATE)),2) AS DATE),
					[AlertLevel] = CASE WHEN DATALENGTH(A.ALERT_LEVEL) = 0 THEN NULL ELSE A.ALERT_LEVEL END,
					[AlertLevelText] =	CASE 
											WHEN A.ALERT_LEVEL = 'OF' THEN 'Office'
											WHEN A.ALERT_LEVEL = 'CL' THEN 'Client'
											WHEN A.ALERT_LEVEL = 'DI' THEN 'Division'
											WHEN A.ALERT_LEVEL = 'PR' THEN 'Product'
											WHEN A.ALERT_LEVEL = 'CM' THEN 'Campaign'
											WHEN A.ALERT_LEVEL = 'JO' THEN 'Job'
											WHEN A.ALERT_LEVEL = 'JC' THEN 'Job Component'
											WHEN A.ALERT_LEVEL = 'ES' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'EST' THEN 'Estimate'
											WHEN A.ALERT_LEVEL = 'PS' THEN 'Schedule'
											WHEN A.ALERT_LEVEL = 'PST' THEN 'Schedule Task'
											WHEN A.ALERT_LEVEL = 'PO' THEN 'Purchase Order'
											WHEN A.ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'
											WHEN A.ALERT_LEVEL = 'AP' THEN 'Accounts Payable'
											WHEN A.ALERT_LEVEL = 'AD' THEN 'Agency Desktop'
											WHEN A.ALERT_LEVEL = 'AN' THEN 'Ad Number'
											WHEN A.ALERT_LEVEL = 'ED' THEN 'Employee Desktop'
											WHEN A.ALERT_LEVEL = 'NA' THEN 'Approval'
											WHEN A.ALERT_LEVEL = 'VN' THEN 'Vendor'
											WHEN A.ALERT_LEVEL = 'CT' THEN 'Contract'
											WHEN A.ALERT_LEVEL = 'BRD' THEN 'Task Assignment'
											ELSE NULL
										END,
					[GroupClient] = CASE WHEN @GroupBy = 'C' THEN C.CL_NAME END,				
					[GroupTask] =	CASE 
										WHEN @GroupBy = 'PST' THEN 
											CASE 
												WHEN AA.TASK_FNC_CODE IS NULL OR AA.TASK_FNC_CODE = '' THEN AA.TASK_DESCRIPTION 
												ELSE AA.TASK_DESCRIPTION
											END
									END,
					[GroupEstimate] = CASE WHEN @GroupBy = 'ES' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + ' - ' + ISNULL(EST.EST_LOG_DESC, '') END,
					[GroupEstimateComponent] = CASE WHEN @GroupBy = 'EST' THEN RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), A.ESTIMATE_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), A.EST_COMPONENT_NBR), 2) + ' - ' + ISNULL(EC.EST_COMP_DESC, '') END,
					[GroupDueDate] = AA.GRP_DUE_DATE,
					[GroupDueDateDisplay] =	AA.GRP_DUE_DATE_DISPLAY,
					[CampaignCode] = A.CMP_CODE,
					[IsStandardAlert] = ISNULL(AA.IS_STANDARD_ALERT, 0),
					[CompletedAssigneesCount] = ISNULL(AA.COMPLETE_ASSIGNEES_CT, 0),
					[OpenAssigneesCount] = ISNULL(AA.OPEN_ASSIGNEES_CT, 0),
					[DismissedRecipientsCount] = ISNULL(AA.DISMISSED_RECIPIENTS_CT, 0),
					[OpenRecipientsCount] = ISNULL(AA.OPEN_RECIPIENTS_CT, 0),				
					[IsMyAssignmentCompleted] = ISNULL(IS_MY_ASSIGNMENT_COMPLETED, 0),				
					[IsMyAlertCompleted] = ISNULL(IS_MY_ALERT_COMPLETED, 0),				
					[IsTaskCompleted] = ISNULL(IS_TASK_COMPLETED, 0),
					[AssignmentCompleted] = AA.ASSIGN_COMPLETED,
					[UserOrder] = AA.USER_ORDER_SEQ_NBR,
					[IsUnAssigned] = ISNULL(AA.IS_UNASSIGNED, 0),
					[AssignedEmpCode] = A.ASSIGNED_EMP_CODE,				
					[EmployeeDepartment] = AA.EMP_DEPARTMENT,
					[CCEmployeeCodes] = CASE
								--WHEN A.ALERT_CAT_ID = 71 THEN NULL
								WHEN AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN NULL
								WHEN AA.IS_STANDARD_ALERT = 1 THEN NULL
								ELSE AA.CC_EMPLOYEE_CODES
							END,
					[CCEmployeeNames] = CASE
								--WHEN A.ALERT_CAT_ID = 71 THEN NULL
								WHEN AA.IS_OWNER_ASSIGNMENT_ALERT = 1 THEN NULL
								WHEN AA.IS_STANDARD_ALERT = 1 THEN NULL
								ELSE AA.CC_EMPLOYEE_NAMES
							END,
					[Board] = CASE WHEN AA.BOARD_EXCLUDE_TASKS = 1 THEN '' ELSE ISNULL(AA.BOARD_NAME,'') END,
                    [BoardState] = ISNULL(CASE WHEN AA.BOARD_EXCLUDE_TASKS = 1 THEN ''
									WHEN AA.IS_BACKLOG_ITEM = 1 THEN 'Backlog'
									WHEN SD.ALERT_ID IS NOT NULL AND BAS.ALERT_STATE_ID IS NOT NULL THEN CASE WHEN AA.ASSIGN_COMPLETED = 1 
									THEN 'Completed' ELSE BAS.ALERT_STATE_NAME END END,''),
                    [Sprint] = ISNULL(SH.[DESCRIPTION],''),
                    [SprintStartDate] = SH.[START_DATE],
					[IsBacklogItem] = AA.IS_BACKLOG_ITEM,					
					[TaskStatusDescription] = CASE WHEN ISNULL(AA.IS_TASK_ASSIGNMENT, 0) = 1 AND AA.TASK_STATUS = 'A' THEN 'Active'
									WHEN ISNULL(AA.IS_TASK_ASSIGNMENT, 0) = 1 AND AA.TASK_STATUS = 'P' THEN 'Projected'					
									ELSE '' END					
				FROM 
					#ALERT AA
					INNER JOIN ALERT A WITH(NOLOCK) ON A.ALERT_ID = AA.ALERT_ID
					INNER JOIN ALERT_TYPE AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID 
					INNER JOIN ALERT_CATEGORY AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID 
					LEFT OUTER JOIN JOB_LOG JL WITH(NOLOCK) ON A.JOB_NUMBER = JL.JOB_NUMBER 
					LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
					LEFT OUTER JOIN JOB_TRAFFIC_DET JTD WITH(NOLOCK) ON A.JOB_NUMBER = JTD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTD.SEQ_NBR
					LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS JTDE WITH(NOLOCK) ON JTD.JOB_NUMBER = JTDE.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = JTDE.SEQ_NBR 
					LEFT OUTER JOIN CLIENT C WITH(NOLOCK) ON A.CL_CODE = C.CL_CODE
					LEFT OUTER JOIN DIVISION D WITH(NOLOCK) ON A.CL_CODE = D.CL_CODE AND A.DIV_CODE = D.DIV_CODE
					LEFT OUTER JOIN PRODUCT P WITH(NOLOCK) ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE
					LEFT OUTER JOIN CAMPAIGN CMP WITH(NOLOCK) ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
					LEFT OUTER JOIN OFFICE O WITH(NOLOCK) ON A.OFFICE_CODE = O.OFFICE_CODE 
					LEFT OUTER JOIN ALERT_STATES AAS WITH(NOLOCK) ON A.ALERT_STATE_ID = AAS.ALERT_STATE_ID 
					LEFT OUTER JOIN ALERT_STATES BAS WITH(NOLOCK) ON A.BOARD_STATE_ID = BAS.ALERT_STATE_ID 
					LEFT OUTER JOIN SOFTWARE_VERSION SV WITH(NOLOCK) ON A.VER = SV.VERSION_ID
					LEFT OUTER JOIN SOFTWARE_BUILD SB WITH(NOLOCK) ON A.BUILD = SB.BUILD_ID
					LEFT OUTER JOIN SPRINT_DTL SD WITH(NOLOCK) ON A.ALERT_ID = SD.ALERT_ID 	
					LEFT OUTER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID --AND COALESCE(SH.IS_COMPLETE, 0) = 0
                    LEFT OUTER JOIN BOARD WITH (NOLOCK) ON SH.BOARD_ID = BOARD.ID
					LEFT OUTER JOIN BOARD_HDR BH WITH (NOLOCK) ON BOARD.BOARD_HDR_ID = BH.ID
					LEFT OUTER JOIN ESTIMATE_COMPONENT EC WITH(NOLOCK) ON A.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND A.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR 
					LEFT OUTER JOIN ESTIMATE_LOG EST WITH(NOLOCK) ON A.ESTIMATE_NUMBER = EST.ESTIMATE_NUMBER  
					LEFT OUTER JOIN ALERT_NOTIFY_HDR ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID 
					LEFT OUTER JOIN ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) ON A.ALERT_ID = ARD.ALERT_ID
                    LEFT OUTER JOIN EMP_NON_TASKS WITH (NOLOCK) ON A.NON_TASK_ID = EMP_NON_TASKS.NON_TASK_ID
				WHERE
					(@StartDate IS NULL OR (@StartDate IS NOT NULL AND A.LAST_UPDATED >= @StartDate)) AND (@EndDate IS NULL OR (@EndDate IS NOT NULL AND A.LAST_UPDATED <= @EndDate))
					AND 1 =	CASE 
								WHEN @SearchCriteria IS NULL THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 1 AND (A.JOB_NUMBER = CAST(@SearchCriteria AS BIGINT) OR COALESCE(A.ALERT_SEQ_NBR, A.ALERT_ID) = CAST(@SearchCriteria AS BIGINT)) THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(A.[SUBJECT]) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(A.ALERT_USER) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								WHEN ISNUMERIC(@SearchCriteria) = 0 AND UPPER(CAST(A.BODY AS VARCHAR(MAX))) LIKE '%' + UPPER(@SearchCriteria) + '%' THEN 1
								ELSE 0
							END								
					--AND 1 = CASE				
					--			WHEN @SHOW_TASKS = 1 AND (A.ALERT_CAT_ID = 71 OR AA.[IS_ROUTED_ASSIGNMENT] = 1 OR AA.[IS_NONROUTED_ASSIGNMENT] = 1) THEN 1
					--			WHEN @SHOW_TASKS = 0 THEN 1
					--			ELSE 0
					--		END
					AND 1 = CASE 
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID <> 71 THEN 1
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 1 THEN 1
								WHEN @ShowOnlyTempComp = 1 AND A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 0 THEN 0							
								WHEN @ShowOnlyTempComp = 0 THEN 1
								ELSE 1
							END
					--AND 1 = CASE 
					--			WHEN @EmployeeRole IS NOT NULL AND AA.EMP_ROLE_CODE IN (SELECT ROLE_CODE FROM #ROLES) THEN 1
					--			WHEN @EmployeeRole IS NOT NULL AND AA.EMP_ROLE_CODE NOT IN (SELECT ROLE_CODE FROM #ROLES) THEN 0
					--			WHEN @EmployeeRole IS NULL THEN 1							
					--		END
					AND 1 = CASE
								WHEN @EmployeeRole IS NOT NULL AND COALESCE(AA.EMP_IN_ROLE, 0) = 1 THEN 1
								WHEN @EmployeeRole IS NOT NULL AND COALESCE(AA.EMP_IN_ROLE, 0) = 0 THEN 0
								WHEN @EmployeeRole IS NULL THEN 1
							END
					AND 1 = CASE 
								WHEN @Department IS NOT NULL AND AA.EMP_DEPARTMENT IN (SELECT DP_TM_CODE FROM #DEPARTMENTS) THEN 1
								WHEN @Department IS NOT NULL AND AA.EMP_DEPARTMENT NOT IN (SELECT DP_TM_CODE FROM #DEPARTMENTS) THEN 0
								WHEN @Department IS NULL THEN 1							
							END
					AND 1 = CASE
								WHEN @SHOW_ONLY_ALERTS = 1 AND A.ALERT_CAT_ID != 71 AND (IS_CC = 1 OR IS_CC_DISMISSED = 1) THEN 1
								WHEN @SHOW_ONLY_ALERTS = 1 AND A.ALERT_CAT_ID = 71 AND (IS_CC = 1 OR IS_CC_DISMISSED = 1) THEN 1
								WHEN @SHOW_ONLY_ALERTS = 1 AND ISNULL(AA.IS_OWNER_ASSIGNMENT_ALERT,0) = 1 THEN 1
								WHEN @SHOW_ONLY_ALERTS = 0 THEN 1
								ELSE 0
							END
					AND 1 = CASE
								WHEN @SHOW_ONLY_UNASSIGNED = 1 AND IS_STANDARD_ALERT = 0 THEN 1
								WHEN @SHOW_ONLY_UNASSIGNED = 0 THEN 1
								ELSE 0
							END		
					AND 1 = CASE
								WHEN @TASK_VIEW = 1 AND @ShowOnlyTempComp = 0 AND (A.ALERT_CAT_ID = 71 OR AA.[IS_ROUTED_ASSIGNMENT] = 1 OR AA.[IS_NONROUTED_ASSIGNMENT] = 1 OR AA.[IS_TASK_ASSIGNMENT] = 1) THEN 1
								WHEN @TASK_VIEW = 1 AND @ShowOnlyTempComp = 1 AND (A.ALERT_CAT_ID = 71 AND ISNULL(AA.IS_MY_TASK_TEMP_COMPLETE, 0) = 1) THEN 1
								WHEN @TASK_VIEW = 0 THEN 1
								ELSE 0
							END	
					AND 1 = CASE 
								WHEN @IncludeBacklog = 1 AND IS_BACKLOG_ITEM = 1 THEN 1
								WHEN @IncludeBacklog = 0 AND IS_BACKLOG_ITEM = 1 THEN 0
								ELSE 1 
							END						
				ORDER BY 
					AA.USER_ORDER_SEQ_NBR,
					AA.LAST_UPDATED DESC
			END
			
		END
	END
	--	CLEANUP
	BEGIN
		DROP TABLE #ALERT;
		DROP TABLE #INACTIVE_WORK_ITEMS;
		DROP TABLE #EMPLOYEES;
		DROP TABLE #ROLES;
		DROP TABLE #SEC_CLIENT;
	END
END
/*************	QUERY  *************/