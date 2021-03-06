SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dto_project_view]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_dto_project_view]
GO
CREATE PROCEDURE [dbo].[usp_wv_dto_project_view] 
@AE 			char(1),	--> Y/N
@cdp_selection char(1),		--> 0-none; 1-c; 2-c/d; 3-c/d/p; 4-campaign
@start_date	varchar(12),
@end_date	varchar(12),
@closed_jobs	char(1),	--> Y/N
@UserID 	varchar(100),
@EmpCode	varchar(6),
@myProjects	char(1),		--> Y/N
@EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES BIT,
@PAGE_IDX INT,
@PAGE_SIZE INT,
@AS_COUNT BIT
AS
/*=========== QUERY ===========*/

	SET @EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES = ISNULL(@EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES, 0);

	DECLARE 
		@sql VARCHAR(MAX),
		@sql_from VARCHAR(MAX),
		@sql_where VARCHAR(MAX),
		@sql_group VARCHAR(MAX),
		@EMP_CODE AS VARCHAR(6),
		@COUNT AS INTEGER,
		@EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT
	
	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = UPPER(@UserID);
	SELECT @COUNT = COUNT(*) FROM EMP_OFFICE WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE;
	
    SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EMP_CODE, 5); 

	DECLARE @Restrictions INTEGER
	
	SELECT @Restrictions = COUNT(*) 
	FROM SEC_CLIENT WITH(NOLOCK)
	WHERE UPPER(USER_ID) = UPPER(@UserID);


	-- Gather Office filter data
	DECLARE @OfficeCount INTEGER
	DECLARE @OfficeCode VARCHAR(4)
	
	SELECT @OfficeCount = COUNT(*) 
	FROM APP_VARS  WITH(NOLOCK)
	WHERE UPPER(USERID) = UPPER(@UserID) 
	AND APPLICATION = 'PROJECTVIEWPOINT'
	AND VARIABLE_GROUP = 'OFFICE';

	IF @OfficeCount = 1
	BEGIN
	
		SELECT @OfficeCode = VARIABLE_VALUE 
		FROM APP_VARS  WITH(NOLOCK)
		WHERE UPPER(USERID) = UPPER(@UserID) 
		AND APPLICATION = 'PROJECTVIEWPOINT'
		AND VARIABLE_GROUP = 'OFFICE';
	
	END
	IF @OfficeCode = 'ALL'
	BEGIN
	
		SET @OfficeCount = 0;
		
	END
	IF @OfficeCount > 0 
	BEGIN
	 
		CREATE TABLE #OFFICE( 	
			OFFICE_CODE			VARCHAR(4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL);
	
		INSERT INTO #OFFICE
		SELECT ISNULL(VARIABLE_VALUE,'') 
		FROM APP_VARS 
		WHERE UPPER(USERID) = UPPER(@UserID) 
		AND APPLICATION = 'PROJECTVIEWPOINT'
		AND VARIABLE_GROUP = 'OFFICE';	
		
	END
 
	-- Gather Sales Class filter data
	DECLARE @SCCount INTEGER
	DECLARE @SCCode VARCHAR(4)
	
	SELECT @SCCount = COUNT(*) 
	FROM APP_VARS  WITH(NOLOCK)
	WHERE UPPER(USERID) = UPPER(@UserID) 
	AND APPLICATION = 'PROJECTVIEWPOINT'
	AND VARIABLE_GROUP = 'SC';

	IF @SCCount = 1
	BEGIN
	
		SELECT @SCCode = VARIABLE_VALUE 
		FROM APP_VARS  WITH(NOLOCK)
		WHERE UPPER(USERID) = UPPER(@UserID) 
		AND APPLICATION = 'PROJECTVIEWPOINT'
		AND VARIABLE_GROUP = 'SC';
		
	END
	IF @SCCode = 'ALL'
	BEGIN
	
		SET @SCCount = 0;
		
	END
	IF @SCCount > 0 
	 BEGIN
	 
		CREATE TABLE #SC( 	
			SC_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL);
	
		INSERT INTO #SC
		SELECT ISNULL(VARIABLE_VALUE,'') 
		FROM APP_VARS  WITH(NOLOCK)
		WHERE UPPER(USERID) = UPPER(@UserID) 
		AND APPLICATION = 'PROJECTVIEWPOINT'
		AND VARIABLE_GROUP = 'SC';	
		
	 END

	 -- Gather MANAGER filter data
 
	DECLARE @ManagerCount INTEGER
	DECLARE @ManagerCode VARCHAR(6)
	
	SELECT @ManagerCount = COUNT(*) 
	FROM APP_VARS  WITH(NOLOCK)
	WHERE UPPER(USERID) = UPPER(@UserID) 
	AND APPLICATION = 'PROJECTVIEWPOINT'
	AND VARIABLE_GROUP = 'MANAGER'

	IF @ManagerCount = 1
	BEGIN
	
		SELECT @ManagerCode = VARIABLE_VALUE 
		FROM APP_VARS  WITH(NOLOCK)
		WHERE UPPER(USERID) = UPPER(@UserID) 
		AND APPLICATION = 'PROJECTVIEWPOINT'
		AND VARIABLE_GROUP = 'MANAGER';
			
	END
	
	IF @ManagerCode = 'ALL'
	BEGIN
	
		SET @ManagerCount = 0;
		
	END

	IF @ManagerCount > 0 
	 BEGIN
	 
		CREATE TABLE #MANAGER( 	
			MANAGER_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL)
	
		INSERT INTO #MANAGER
		SELECT ISNULL(VARIABLE_VALUE,'') 
		FROM APP_VARS  WITH(NOLOCK)
		WHERE UPPER(USERID) = UPPER(@UserID) 
		AND APPLICATION = 'PROJECTVIEWPOINT'
		AND VARIABLE_GROUP = 'MANAGER';	
		
	 END

	DECLARE 
		@TIME_ONLY BIT, 
		@THRESHOLD DECIMAL (9,3), 
		@QVA_STATUS SMALLINT

		IF (SELECT UPPER(VARIABLE_VALUE) FROM APP_VARS WHERE UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = 'PROJECTVIEWPOINT' AND VARIABLE_NAME = 'PVQvAType') = 'TRUE'
		BEGIN
			SET @TIME_ONLY = 1;
		END
		ELSE
		BEGIN
			SET @TIME_ONLY = 0;
		END
		SELECT @THRESHOLD = (CAST(ISNULL(VARIABLE_VALUE, '0') AS decimal)/100) FROM APP_VARS WHERE USERID = @UserID AND [APPLICATION] = 'PROJECTVIEWPOINT' AND VARIABLE_NAME = 'PVQvAThreshold';
		
	CREATE TABLE #PV_QUERY(	
					[CL_CODE] [varchar](6) NULL,
					[DIV_CODE] [varchar](6) NULL,
					[PRD_CODE] [varchar](6) NULL,
					[JOB_NUMBER] [int] NULL,
					[JOB_DESC] [varchar](60) NULL,
					[JOB_COMPONENT_NBR] [smallint] NULL,
					[JOB_COMP_DESC] [varchar](60) NULL,
					[EMP_CODE] [varchar](6) NULL,
					[JOB_COMP_DATE] [smalldatetime] NULL,
					[JOB_PROCESS_CONTRL] [smallint] NULL,
					[PROCESS_DATE] [smalldatetime] NULL,
					[JOB_FIRST_USE_DATE] [smalldatetime] NULL,
					[COMPLETED_DATE] [smalldatetime] NULL,
					[CDP] [VARCHAR] (30) NULL,
					[JobAndComp] VARCHAR (200) NULL,
					[AcctExec] VARCHAR (300) NULL,
					[Status] VARCHAR(200) NULL,
					JC_START_DATE SMALLDATETIME NULL,
					OPEN_ASSIGNMENTS INT NULL,
					OPEN_TASKS INT NULL,
					QUOTED_AMT DECIMAL(14,3) NULL,
					ACTUAL_AMT DECIMAL(14,3) NULL,
					THRESHOLD DECIMAL(14,3) NULL,
					THRESHOLD_STATUS SMALLINT NULL,
					ESTIMATE_NUMBER INT NULL,
					HAS_JOB_VERSIONS BIT NULL,
					JOB_VERSIONS_LABEL VARCHAR(50) NULL,
					ID INT IDENTITY(1,1) NOT NULL
					)

  	SET @sql = 'INSERT INTO #PV_QUERY '

	SET @sql = @sql + 'SELECT A.*, 0, 0, 0, 0, 0, 0, ''Versions'' FROM ('

	SET @sql = @sql + 'SELECT JL.CL_CODE, JL.DIV_CODE, JL.PRD_CODE, JL.JOB_NUMBER, JL.JOB_DESC, JC.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC, 
						JC.EMP_CODE, JC.JOB_COMP_DATE, JC.JOB_PROCESS_CONTRL, MAX(JPL.PROCESS_DATE) AS PROCESS_DATE, JC.JOB_FIRST_USE_DATE, JT.COMPLETED_DATE, 
						JL.CL_CODE + ''/'' + JL.DIV_CODE + ''/'' + JL.PRD_CODE as CDP,
						( RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER),6) + ''/'' + RIGHT(REPLICATE(''0'', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR),3) + '' - '' + JC.JOB_COMP_DESC ) as JobAndComp,
						ISNULL(dbo.udf_get_empl_name(JC.EMP_CODE,''FML''),'''') as AcctExec, 
						TRAFFIC.TRF_DESCRIPTION AS Status, JC.START_DATE AS JC_START_DATE,
						dbo.wvfn_open_assignment_count(JL.JOB_NUMBER, JC.JOB_COMPONENT_NBR) AS OPEN_ASSIGNMENTS, 
						dbo.wvfn_open_task_count(JL.JOB_NUMBER, JC.JOB_COMPONENT_NBR, 1) AS OPEN_TASKS '

	SET @sql_from = ' 

			FROM         JOB_TRAFFIC AS JT WITH(NOLOCK) LEFT OUTER JOIN
								  TRAFFIC WITH(NOLOCK) ON JT.TRF_CODE = TRAFFIC.TRF_CODE FULL OUTER JOIN
								  JOB_COMPONENT AS JC WITH(NOLOCK) INNER JOIN
								  JOB_LOG AS JL WITH(NOLOCK) ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
								  JOB_PROCESS_LOG AS JPL WITH(NOLOCK) ON JC.JOB_NUMBER = JPL.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JPL.JOB_COMPONENT_NBR ON 
								  JT.JOB_NUMBER = JC.JOB_NUMBER AND JT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR	
		'

	SET @sql_where = ' WHERE 1 = 1 '		

	IF @Restrictions > 0 
		BEGIN
		
			SET @sql_from = @sql_from + '   INNER JOIN SEC_CLIENT WITH(NOLOCK) ON JL.CL_CODE = SEC_CLIENT.CL_CODE 
											AND JL.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND JL.PRD_CODE = SEC_CLIENT.PRD_CODE ';
			SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) ';
			
		END

	IF @AE = 'Y' 
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN PV_AE WITH(NOLOCK) ON PV_AE.EMP_CODE = JC.EMP_CODE AND UPPER(PV_AE.USERID) = UPPER(''' + @UserID + ''') ';

	END

	--IF @cdp_selection = '0'	 --none 0

	IF @cdp_selection = '1'	 --client
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN PV_CDP WITH(NOLOCK) ON PV_CDP.CL_CODE = JL.CL_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') ';
		
	END
	IF @cdp_selection = '2'	 --cl/div
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN PV_CDP WITH(NOLOCK) ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') ';

	END
	IF @cdp_selection = '3'	 --cl/div/prd
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN PV_CDP WITH(NOLOCK) ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND PV_CDP.PRD_CODE = JL.PRD_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') ';
	
	END
	IF @cdp_selection = '4'	 --campaign
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN PV_CMP WITH(NOLOCK) ON PV_CMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER AND UPPER(PV_CMP.USERID) = UPPER(''' + @UserID + ''') ';

	END
	IF @OfficeCount > 0 
		BEGIN
		
			SET @sql_from = @sql_from + ' INNER JOIN #OFFICE ON #OFFICE.OFFICE_CODE = JL.OFFICE_CODE ';
			
		END
	ELSE
		IF @COUNT > 0 
		BEGIN
		
			SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON JL.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
										AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + '''';
							
		END
	IF @SCCount > 0
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN #SC ON #SC.SC_CODE = JL.SC_CODE ';
		
	END
	IF @ManagerCount > 0
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN #MANAGER ON #MANAGER.MANAGER_CODE = JT.MGR_EMP_CODE ';
		
	END
	IF @closed_jobs <> 'Y' 
	BEGIN
	
	   SET @sql_where = @sql_where + ' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) ';
	   
    END
	IF @myProjects = 'Y'
	BEGIN
	 
		DECLARE
			@RESTRICT_ALERT_GROUP BIT,
			@RESTRICT_SCHEDULE_ASSIGNMENTS BIT,
			@RESTRICT_SCHEDULE_MANAGER BIT,
			@RESTRICT_TASK_ASSIGNEES BIT,
			@RESTRICT_ACCOUNT_EXECUTIVE BIT,
			@AGENCY_MANAGER_COLUMN VARCHAR(40),
			@JOB_TRAFFIC_MANAGER_COLUMN VARCHAR(40),
			@HAS_ACTIVE_RESTRICTION BIT,
			@NEEDS_OR BIT
			
		SELECT 
			@RESTRICT_ALERT_GROUP = A.ALERT_GROUP,
			@RESTRICT_SCHEDULE_ASSIGNMENTS = A.SCHEDULE_ASSIGNMENTS,
			@RESTRICT_SCHEDULE_MANAGER = A.SCHEDULE_MANAGER,
			@RESTRICT_TASK_ASSIGNEES = A.TASK_ASSIGNEES,
			@RESTRICT_ACCOUNT_EXECUTIVE = A.ACCOUNT_EXECUTIVE,
			@AGENCY_MANAGER_COLUMN = A.AGENCY_MANAGER_COLUMN,
			@JOB_TRAFFIC_MANAGER_COLUMN = A.JOB_TRAFFIC_MANAGER_COLUMN,
			@HAS_ACTIVE_RESTRICTION = A.HAS_ACTIVE_RESTRICTION
		FROM [dbo].[fn_my_objects_get_static_restrictions](5) AS A;
		
		IF @HAS_ACTIVE_RESTRICTION = 1
		BEGIN
		
			SET @sql_where = @sql_where + ' AND ( ';
			SET @NEEDS_OR = 0;
		
			IF @RESTRICT_ALERT_GROUP = 1
			BEGIN
			
				SET @sql_from = @sql_from + ' 
												LEFT OUTER JOIN EMAIL_GROUP ON EMAIL_GROUP.EMAIL_GR_CODE = JC.EMAIL_GR_CODE 
												AND (EMAIL_GROUP.INACTIVE_FLAG = 0 OR EMAIL_GROUP.INACTIVE_FLAG IS NULL) ';
			
				IF @NEEDS_OR = 1
				BEGIN
				
					SET @sql_where = @sql_where + ' OR ';
					
				END	
							
				SET @sql_where = @sql_where + '	(EMAIL_GROUP.EMP_CODE = ''' + @EmpCode + ''')';
				SET @NEEDS_OR = 1;
				
			END
			IF @RESTRICT_SCHEDULE_ASSIGNMENTS = 1
			BEGIN		
		
				IF @NEEDS_OR = 1
				BEGIN
				
					SET @sql_where = @sql_where + ' OR ';
					
				END				
				
				SET @sql_where = @sql_where + ' (
												JT.ASSIGN_1 = ''' + @EmpCode + '''
												OR JT.ASSIGN_2 = ''' + @EmpCode + '''
												OR JT.ASSIGN_3 = ''' + @EmpCode + '''
												OR JT.ASSIGN_4 = ''' + @EmpCode + '''
												OR JT.ASSIGN_5 = ''' + @EmpCode + ''') ';
				SET @NEEDS_OR = 1;
				
			END
			IF @RESTRICT_SCHEDULE_MANAGER = 1
			BEGIN
			
				IF @NEEDS_OR = 1
				BEGIN
				
					SET @sql_where = @sql_where + ' OR ';
					
				END				
				SET @sql_where = @sql_where + ' (JT.' + @JOB_TRAFFIC_MANAGER_COLUMN + ' = ''' + @EmpCode + ''') ';
				
				SET @NEEDS_OR = 1;
				
			END
			IF @RESTRICT_TASK_ASSIGNEES = 1
			BEGIN
			
 				SET @sql_from = @sql_from + '	LEFT OUTER JOIN JOB_TRAFFIC_DET WITH(NOLOCK) ON JOB_TRAFFIC_DET.JOB_NUMBER = JT.JOB_NUMBER  
												AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
												LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS WITH(NOLOCK) ON JOB_TRAFFIC_DET_EMPS.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER 
												AND JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
												AND JOB_TRAFFIC_DET_EMPS.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR
												 ';
			
				IF @NEEDS_OR = 1
				BEGIN
				
					SET @sql_where = @sql_where + ' OR ';
					
				END	
							
				SET @sql_where = @sql_where + ' (JOB_TRAFFIC_DET_EMPS.EMP_CODE = ''' + @EmpCode + ''') ';
				SET @NEEDS_OR = 1;
				
			END
			IF @RESTRICT_ACCOUNT_EXECUTIVE = 1
			BEGIN
	 	
				IF @NEEDS_OR = 1
				BEGIN
				
					SET @sql_where = @sql_where + ' OR ';
					
				END	
							
				SET @sql_where = @sql_where + ' (JC.EMP_CODE = ''' + @EmpCode + ''')'; 
				SET @NEEDS_OR = 1;
				
			END
			
	 		SET @sql_where = @sql_where + ' ) '
		
		END
		ELSE
		BEGIN

			SET @sql_where = @sql_where + ' AND (0=1) ';

		END

	 END
	IF @EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES = 1
	BEGIN
	 
	SET @sql_where = @sql_where + ' AND (JT.COMPLETED_DATE IS NULL) ';
		
	END
	 
	SET @sql_group = ' GROUP BY JL.CL_CODE, JL.DIV_CODE, JL.PRD_CODE, JL.JOB_NUMBER, JL.JOB_DESC, JC.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC, JC.EMP_CODE, JC.JOB_COMP_DATE, JC.JOB_PROCESS_CONTRL,JC.JOB_FIRST_USE_DATE, JT.COMPLETED_DATE,TRAFFIC.TRF_DESCRIPTION, JC.START_DATE';
	SET @sql = @sql + @sql_from + @sql_where + @sql_group;

	IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 AND @myProjects = 'Y'
	BEGIN
	
		SET @sql = @sql + ' UNION '

		SET @sql = @sql + 'SELECT JL.CL_CODE, JL.DIV_CODE, JL.PRD_CODE, JL.JOB_NUMBER, JL.JOB_DESC, JC.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC, 
							JC.EMP_CODE, JC.JOB_COMP_DATE, JC.JOB_PROCESS_CONTRL, MAX(JPL.PROCESS_DATE) AS PROCESS_DATE, JC.JOB_FIRST_USE_DATE, JT.COMPLETED_DATE, 
							JL.CL_CODE + ''/'' + JL.DIV_CODE + ''/'' + JL.PRD_CODE as CDP,
							( RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER),6) + ''/'' + RIGHT(REPLICATE(''0'', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR),3) + '' - '' + JC.JOB_COMP_DESC ) as JobAndComp,
							ISNULL(dbo.udf_get_empl_name(JC.EMP_CODE,''FML''),'''') as AcctExec, 
							TRAFFIC.TRF_DESCRIPTION AS Status, JC.START_DATE AS JC_START_DATE,
							dbo.wvfn_open_assignment_count(JL.JOB_NUMBER, JC.JOB_COMPONENT_NBR) AS OPEN_ASSIGNMENTS, 
							dbo.wvfn_open_task_count(JL.JOB_NUMBER, JC.JOB_COMPONENT_NBR, 1) AS OPEN_TASKS '
		SET @sql = @sql + ' 

				FROM         JOB_TRAFFIC AS JT WITH(NOLOCK) LEFT OUTER JOIN
									  TRAFFIC WITH(NOLOCK) ON JT.TRF_CODE = TRAFFIC.TRF_CODE FULL OUTER JOIN
									  JOB_COMPONENT AS JC WITH(NOLOCK) INNER JOIN
									  JOB_LOG AS JL WITH(NOLOCK) ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
									  JOB_PROCESS_LOG AS JPL WITH(NOLOCK) ON JC.JOB_NUMBER = JPL.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JPL.JOB_COMPONENT_NBR ON 
									  JT.JOB_NUMBER = JC.JOB_NUMBER AND JT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR	
			'
		SET @sql = @sql + '   INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](5, ''' + @EMP_CODE + ''') AS DR 
										ON DR.CL_CODE = JL.CL_CODE 
										AND ((DR.DIV_CODE = JL.DIV_CODE) OR (DR.DIV_CODE IS NULL)) 
										AND ((DR.PRD_CODE = JL.PRD_CODE) OR (DR.PRD_CODE IS NULL)) ';
		IF @AE = 'Y' 
		BEGIN
	
			SET @sql = @sql + ' INNER JOIN PV_AE WITH(NOLOCK) ON PV_AE.EMP_CODE = JC.EMP_CODE AND UPPER(PV_AE.USERID) = UPPER(''' + @UserID + ''') ';

		END

		--IF @cdp_selection = '0'	 --none 0

		IF @cdp_selection = '1'	 --client
		BEGIN
	
			SET @sql = @sql + ' INNER JOIN PV_CDP WITH(NOLOCK) ON PV_CDP.CL_CODE = JL.CL_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') ';
		
		END
		IF @cdp_selection = '2'	 --cl/div
		BEGIN
	
			SET @sql = @sql + ' INNER JOIN PV_CDP WITH(NOLOCK) ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') ';

		END
		IF @cdp_selection = '3'	 --cl/div/prd
		BEGIN
	
			SET @sql = @sql + ' INNER JOIN PV_CDP WITH(NOLOCK) ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND PV_CDP.PRD_CODE = JL.PRD_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') ';
	
		END
		IF @cdp_selection = '4'	 --campaign
		BEGIN
	
			SET @sql = @sql + ' INNER JOIN PV_CMP WITH(NOLOCK) ON PV_CMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER AND UPPER(PV_CMP.USERID) = UPPER(''' + @UserID + ''') ';

		END
		IF @OfficeCount > 0 
			BEGIN
		
				SET @sql = @sql + ' INNER JOIN #OFFICE ON #OFFICE.OFFICE_CODE = JL.OFFICE_CODE ';
			
			END
		ELSE
			IF @COUNT > 0 
			BEGIN
		
				SET @sql = @sql + ' INNER JOIN EMP_OFFICE ON JL.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
											AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + '''';
							
			END
		IF @SCCount > 0
		BEGIN
	
			SET @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = JL.SC_CODE ';
		
		END
		IF @ManagerCount > 0
		BEGIN
	
			SET @sql = @sql + ' INNER JOIN #MANAGER ON #MANAGER.MANAGER_CODE = JT.MGR_EMP_CODE ';
		
		END

		SET @sql = @sql + ' WHERE 1 = 1 '		

		IF @closed_jobs <> 'Y' 
		BEGIN
	
		   SET @sql = @sql + ' AND JC.JOB_PROCESS_CONTRL NOT IN (6, 12) ';
	   
		END

		IF @EXCLUDE_JOBS_WITH_COMPLETED_SCHEDULES = 1
		BEGIN
	 
		SET @sql = @sql + ' AND (JT.COMPLETED_DATE IS NULL) ';
		
		END
	 
		SET @sql = @sql + ' GROUP BY JL.CL_CODE, JL.DIV_CODE, JL.PRD_CODE, JL.JOB_NUMBER, JL.JOB_DESC, JC.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC, JC.EMP_CODE, JC.JOB_COMP_DATE, JC.JOB_PROCESS_CONTRL,JC.JOB_FIRST_USE_DATE, JT.COMPLETED_DATE,TRAFFIC.TRF_DESCRIPTION, JC.START_DATE';
											
	END


	SET @sql = @sql + ') AS A'
	SET @sql = @sql + ' ORDER BY A.CL_CODE ASC, A.DIV_CODE ASC, A.PRD_CODE ASC, A.JOB_NUMBER DESC, A.JOB_COMPONENT_NBR ASC';


	--PRINT(@sql)
	EXEC(@sql);

	IF @AS_COUNT = 0
	BEGIN

		DECLARE @MORE_THAN INT, @LESS_THAN INT;

		SET @LESS_THAN = @PAGE_SIZE * @PAGE_IDX;
		SET @MORE_THAN = (@PAGE_SIZE * @PAGE_IDX) + @PAGE_SIZE;

		DELETE FROM #PV_QUERY WHERE ID <= @LESS_THAN;

		IF @MORE_THAN > 0
		BEGIN
			DELETE FROM #PV_QUERY WHERE ID > @MORE_THAN;
		END

		DECLARE 
			@CURR_ID INT,
			@CURR_JOB_NUMBER INT, 
			@CURR_JOB_COMPONENT_NBR SMALLINT, 
			@TIME_ONLY_CHAR CHAR(1), 
			@CURR_AMT DECIMAL(14,3),
			@CURR_QUOTED DECIMAL(14,3);

		IF @TIME_ONLY = 1
		BEGIN
			SET @TIME_ONLY_CHAR = 'E';
		END

		DECLARE PV_CURSOR CURSOR FOR
		SELECT ID FROM #PV_QUERY WITH(NOLOCK);

		OPEN PV_CURSOR;
		FETCH NEXT FROM PV_CURSOR INTO @CURR_ID;

		WHILE (@@FETCH_STATUS = 0)
		BEGIN

			SELECT @CURR_JOB_NUMBER = JOB_NUMBER, @CURR_JOB_COMPONENT_NBR = JOB_COMPONENT_NBR FROM #PV_QUERY WHERE ID = @CURR_ID;

			SET @CURR_AMT = 0.00;
			EXEC @CURR_AMT = usp_wv_PVqva @CURR_JOB_NUMBER, @CURR_JOB_COMPONENT_NBR, @TIME_ONLY_CHAR, @UserID;
			UPDATE #PV_QUERY SET ACTUAL_AMT = @CURR_AMT WHERE JOB_NUMBER = @CURR_JOB_NUMBER AND JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR;

			SET @CURR_QUOTED = 0.00;
			IF @TIME_ONLY = 1
			BEGIN
				SELECT  @CURR_QUOTED = ISNULL(Sum(ESTIMATE_REV_DET.LINE_TOTAL), 0.00)
				FROM ESTIMATE_REV_DET 
				INNER JOIN ESTIMATE_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER 
				  AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR 
				  AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR 
				  AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR 
				INNER JOIN JOB_LOG ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
				INNER JOIN JOB_COMPONENT ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
				  AND ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR 
				Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
				And ESTIMATE_APPROVAL.JOB_NUMBER = @CURR_JOB_NUMBER And ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR
				AND ESTIMATE_REV_DET.EST_FNC_TYPE = 'E'
				Group By ESTIMATE_APPROVAL.JOB_NUMBER, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR
			
				if @CURR_QUOTED = 0
				Begin
					SELECT  @CURR_QUOTED = ISNULL(Sum(ESTIMATE_REV_DET.LINE_TOTAL), 0.00)
					FROM ESTIMATE_REV_DET 
					INNER JOIN ESTIMATE_INT_APPR ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_INT_APPR.ESTIMATE_NUMBER 
					  AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_INT_APPR.EST_COMPONENT_NBR 
					  AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_INT_APPR.EST_QUOTE_NBR 
					  AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_INT_APPR.EST_REVISION_NBR 
					INNER JOIN JOB_LOG ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
					INNER JOIN JOB_COMPONENT ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
					  AND ESTIMATE_INT_APPR.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR 
					Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
					And ESTIMATE_INT_APPR.JOB_NUMBER = @CURR_JOB_NUMBER And ESTIMATE_INT_APPR.JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR
					AND ESTIMATE_REV_DET.EST_FNC_TYPE = 'E'
					Group By ESTIMATE_INT_APPR.JOB_NUMBER, ESTIMATE_INT_APPR.JOB_COMPONENT_NBR
				End

			END
			ELSE
			BEGIN
				SELECT  @CURR_QUOTED = ISNULL(Sum(ESTIMATE_REV_DET.LINE_TOTAL), 0.00)
				FROM ESTIMATE_REV_DET 
				INNER JOIN ESTIMATE_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER 
				  AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR 
				  AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR 
				  AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR 
				INNER JOIN JOB_LOG ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
				INNER JOIN JOB_COMPONENT ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
				  AND ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR 
				Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
				And ESTIMATE_APPROVAL.JOB_NUMBER = @CURR_JOB_NUMBER And ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR
				Group By ESTIMATE_APPROVAL.JOB_NUMBER, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR
			
				if @CURR_QUOTED = 0
				Begin
					SELECT  @CURR_QUOTED = ISNULL(Sum(ESTIMATE_REV_DET.LINE_TOTAL), 0.00)
					FROM ESTIMATE_REV_DET 
					INNER JOIN ESTIMATE_INT_APPR ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_INT_APPR.ESTIMATE_NUMBER 
					  AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_INT_APPR.EST_COMPONENT_NBR 
					  AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_INT_APPR.EST_QUOTE_NBR 
					  AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_INT_APPR.EST_REVISION_NBR 
					INNER JOIN JOB_LOG ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
					INNER JOIN JOB_COMPONENT ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
					  AND ESTIMATE_INT_APPR.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR 
					Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
					And ESTIMATE_INT_APPR.JOB_NUMBER = @CURR_JOB_NUMBER And ESTIMATE_INT_APPR.JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR
					--AND ESTIMATE_REV_DET.EST_FNC_TYPE = 'E'
					Group By ESTIMATE_INT_APPR.JOB_NUMBER, ESTIMATE_INT_APPR.JOB_COMPONENT_NBR
				End

			END

			UPDATE #PV_QUERY SET QUOTED_AMT = @CURR_QUOTED WHERE JOB_NUMBER = @CURR_JOB_NUMBER AND JOB_COMPONENT_NBR = @CURR_JOB_COMPONENT_NBR;

			FETCH NEXT FROM PV_CURSOR INTO @CURR_ID;

		END

		CLOSE PV_CURSOR;
		DEALLOCATE PV_CURSOR;

		IF @THRESHOLD > 0
		BEGIN
			UPDATE #PV_QUERY SET THRESHOLD = @THRESHOLD;

			-- THRESHOLD STATUS 0 = NONE (YELLOW), 1 = OK (GREEN), 2 = OVER (RED)
			UPDATE #PV_QUERY SET THRESHOLD_STATUS = CASE
														WHEN ACTUAL_AMT > (@THRESHOLD * QUOTED_AMT) THEN 2
														ELSE 1
													END
			WHERE QUOTED_AMT > 0.00;
		END

		UPDATE #PV_QUERY SET ESTIMATE_NUMBER = ISNULL(JC.ESTIMATE_NUMBER, 0)
		FROM 
		 #PV_QUERY PV INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON PV.JOB_NUMBER = JC.JOB_NUMBER AND PV.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR;

		UPDATE #PV_QUERY SET HAS_JOB_VERSIONS = 1
		FROM
		#PV_QUERY PV INNER JOIN JOB_VER_HDR JVH WITH(NOLOCK) ON  PV.JOB_NUMBER = JVH.JOB_NUMBER AND PV.JOB_COMPONENT_NBR = JVH.JOB_COMPONENT_NBR;

		DECLARE @CUSTOM_LABEL VARCHAR(50)
		SELECT @CUSTOM_LABEL = COALESCE(CAST(AGY_SETTINGS_VALUE AS VARCHAR), CAST(AGY_SETTINGS_DEF AS VARCHAR), 'Versions') FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'JOB_VERSION_DESC'

		UPDATE #PV_QUERY SET JOB_VERSIONS_LABEL = @CUSTOM_LABEL;

		SELECT * FROM #PV_QUERY;

	END
	ELSE
	BEGIN
		SELECT COUNT(1) FROM #PV_QUERY;
	END


	IF @OfficeCount > 0 
	BEGIN
	
		DROP TABLE #OFFICE;
		
	END	
	IF @SCCount > 0 
	BEGIN
	
		DROP TABLE #SC;
		
	END	
	IF @ManagerCount > 0 
	BEGIN
	
		DROP TABLE #MANAGER;
		
	END	

	DROP TABLE #PV_QUERY;

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO