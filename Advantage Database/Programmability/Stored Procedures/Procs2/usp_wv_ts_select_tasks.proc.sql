--DROP PROCEDURE [dbo].[usp_wv_ts_select_tasks] 
CREATE PROCEDURE [dbo].[usp_wv_ts_select_tasks] 
@UserID Varchar(100),
@EmpCode Varchar(6)
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE @Restrictions INT

	SET NOCOUNT ON

	DECLARE @EMP_CDE AS VARCHAR(6)
	DECLARE @RestrictionsOffice AS INT

	SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @RestrictionsOffice = COUNT(1) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE
 
	SELECT @Restrictions = COUNT(1) 
	FROM SEC_CLIENT WITH (NOLOCK)
	WHERE UPPER(USER_ID) = UPPER(@UserID)

	DECLARE @TASKS TABLE  (	
		Client VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Division VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Product VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Task VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		FuncCat VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DueDate SMALLDATETIME,
		JobAndDesc VARCHAR(2000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JobCompAndDesc VARCHAR(2000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Job INT NULL,
		JobComp SMALLINT NULL,
		JobDesc VARCHAR(2000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JobCompDesc VARCHAR(2000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		HoursAllowed DECIMAL(14,2) NULL,
		SeqNo SMALLINT NULL,
		TASK_DESCRIPTION VARCHAR(1000),	
		FNC_INACTIVE SMALLINT,
		ClientName VARCHAR(50),
		AlertID INT
	)

	If @Restrictions > 0
		If @RestrictionsOffice = 0
		BEGIN
			INSERT @TASKS
			SELECT     JOB_LOG.CL_CODE AS Client, JOB_LOG.DIV_CODE AS Division, JOB_LOG.PRD_CODE AS Product, ISNULL(JOB_TRAFFIC_DET.TASK_DESCRIPTION, 
									  '') + ' (' + ISNULL(JOB_TRAFFIC_DET.FNC_EST, '') + ')' AS Task, ISNULL(JOB_TRAFFIC_DET.FNC_EST,'') AS FuncCat, 
									  JOB_TRAFFIC_DET.JOB_REVISED_DATE AS DueDate, '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC AS JobAndDesc,
									   '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS JobCompAndDesc, 
									  JOB_TRAFFIC_DET.JOB_NUMBER AS Job, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS JobComp, JOB_LOG.JOB_DESC AS JobDesc, 
									  JOB_COMPONENT.JOB_COMP_DESC AS JobCompDesc, JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, JOB_TRAFFIC_DET.SEQ_NBR AS SeqNo, 
									  JOB_TRAFFIC_DET.TASK_DESCRIPTION, FUNCTIONS.FNC_INACTIVE, CLIENT.CL_NAME, NULL
				FROM         JOB_LOG WITH (NOLOCK) INNER JOIN
									  CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
									  JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
									  JOB_TRAFFIC_DET WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
									  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
									  SEC_CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
									  JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE INNER JOIN
									  JOB_TRAFFIC ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
									  JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND 
									  JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR  LEFT OUTER JOIN
									  FUNCTIONS WITH (NOLOCK) ON JOB_TRAFFIC_DET.FNC_EST = FUNCTIONS.FNC_CODE
				WHERE	(NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (JOB_TRAFFIC_DET.TASK_START_DATE <= GETDATE() OR
									  JOB_TRAFFIC_DET.TASK_START_DATE IS NULL) AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL) AND 
									  (FUNCTIONS.FNC_INACTIVE IS NULL OR
									  FUNCTIONS.FNC_INACTIVE = 0) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE = @EmpCode) AND 
									  (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
				ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, 
									  JOB_TRAFFIC_DET.FNC_EST, JOB_TRAFFIC_DET.SEQ_NBR

		   INSERT @TASKS
			SELECT  [Client] = JOB_LOG.CL_CODE,
					[Division] = JOB_LOG.DIV_CODE,
					[Product] = JOB_LOG.PRD_CODE,
					[Task] = '',
					[FuncCat] = (SELECT DEF_FNC_CODE FROM EMPLOYEE WHERE EMP_CODE = @EmpCode),
					[DueDate] = NULL,
					[JobAndDesc] = '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC,
					[JobCompAndDesc] = '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC,
					[Job] = JOB_LOG.JOB_NUMBER,
					[JobComp] = JOB_COMPONENT.JOB_COMPONENT_NBR,
					[JobDesc] = JOB_LOG.JOB_DESC,
					[JobCompDesc] = JOB_COMPONENT.JOB_COMP_DESC,
					[HoursAllowed] = 0,
					[SeqNo] = 0,
					'',
					[FNC_INACTIVE] = 0, CLIENT.CL_NAME, NULL
			FROM dbo.JOB_LOG WITH (NOLOCK) INNER JOIN
				 dbo.CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
				 dbo.DIVISION WITH (NOLOCK) ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
				 dbo.PRODUCT WITH (NOLOCK) ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
				 dbo.JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
				 dbo.SEC_CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND 
												 JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
												 JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE INNER JOIN			 
				 dbo.JOB_TRAFFIC ON JOB_LOG.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
			WHERE 	JOB_TRAFFIC.COMPLETED_DATE IS NULL AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(10)) NOT IN (SELECT CAST(Job AS VARCHAR(10)) + '|' + CAST(JobComp AS VARCHAR(10)) FROM @TASKS)) AND
				  (JOB_TRAFFIC.ASSIGN_1 = @EmpCode OR JOB_TRAFFIC.ASSIGN_2 = @EmpCode OR JOB_TRAFFIC.ASSIGN_3 = @EmpCode OR JOB_TRAFFIC.ASSIGN_4 = @EmpCode OR JOB_TRAFFIC.ASSIGN_5 = @EmpCode)
			ORDER BY JOB_LOG.CL_CODE, 
					 JOB_LOG.DIV_CODE, 
					 JOB_LOG.PRD_CODE, 
					 JOB_LOG.JOB_NUMBER

		
		END
		ELSE
		BEGIN
			INSERT @TASKS
			SELECT     JOB_LOG.CL_CODE AS Client, JOB_LOG.DIV_CODE AS Division, JOB_LOG.PRD_CODE AS Product, ISNULL(JOB_TRAFFIC_DET.TASK_DESCRIPTION, 
									  '') + ' (' + ISNULL(JOB_TRAFFIC_DET.FNC_EST, '') + ')' AS Task, ISNULL(JOB_TRAFFIC_DET.FNC_EST,'') AS FuncCat, 
									  JOB_TRAFFIC_DET.JOB_REVISED_DATE AS DueDate, '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC AS JobAndDesc,
									   '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS JobCompAndDesc, 
									  JOB_TRAFFIC_DET.JOB_NUMBER AS Job, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS JobComp, JOB_LOG.JOB_DESC AS JobDesc, 
									  JOB_COMPONENT.JOB_COMP_DESC AS JobCompDesc, JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, JOB_TRAFFIC_DET.SEQ_NBR AS SeqNo, 
									  JOB_TRAFFIC_DET.TASK_DESCRIPTION, FUNCTIONS.FNC_INACTIVE, CLIENT.CL_NAME, NULL
				FROM         JOB_LOG WITH (NOLOCK) INNER JOIN
									  CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
									  JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
									  JOB_TRAFFIC_DET WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
									  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
									  SEC_CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
									  JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE INNER JOIN
									  JOB_TRAFFIC ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
									  JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND 
									  JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR  LEFT OUTER JOIN
									  FUNCTIONS WITH (NOLOCK) ON JOB_TRAFFIC_DET.FNC_EST = FUNCTIONS.FNC_CODE INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CDE
				WHERE   	(NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (JOB_TRAFFIC_DET.TASK_START_DATE <= GETDATE() OR
									  JOB_TRAFFIC_DET.TASK_START_DATE IS NULL) AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL) AND 
									  (FUNCTIONS.FNC_INACTIVE IS NULL OR
									  FUNCTIONS.FNC_INACTIVE = 0) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE = @EmpCode) AND 
									  (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
				ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, 
									  JOB_TRAFFIC_DET.FNC_EST, JOB_TRAFFIC_DET.SEQ_NBR
		

		   INSERT @TASKS
			SELECT  [Client] = JOB_LOG.CL_CODE,
					[Division] = JOB_LOG.DIV_CODE,
					[Product] = JOB_LOG.PRD_CODE,
					[Task] = '',
					[FuncCat] = (SELECT DEF_FNC_CODE FROM EMPLOYEE WHERE EMP_CODE = @EmpCode),
					[DueDate] = NULL,
					[JobAndDesc] = '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC,
					[JobCompAndDesc] = '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC,
					[Job] = JOB_LOG.JOB_NUMBER,
					[JobComp] = JOB_COMPONENT.JOB_COMPONENT_NBR,
					[JobDesc] = JOB_LOG.JOB_DESC,
					[JobCompDesc] = JOB_COMPONENT.JOB_COMP_DESC,
					[HoursAllowed] = 0,
					[SeqNo] = 0,
					'',
					[FNC_INACTIVE] = 0, CLIENT.CL_NAME, NULL
			FROM dbo.JOB_LOG WITH (NOLOCK) INNER JOIN
				 dbo.CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
				 dbo.DIVISION WITH (NOLOCK) ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
				 dbo.PRODUCT WITH (NOLOCK) ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
				 dbo.JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
				 dbo.SEC_CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND 
												 JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
												 JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE INNER JOIN			 
				 dbo.JOB_TRAFFIC ON JOB_LOG.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER INNER JOIN
				 EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CDE
			WHERE 	JOB_TRAFFIC.COMPLETED_DATE IS NULL AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(10)) NOT IN (SELECT CAST(Job AS VARCHAR(10)) + '|' + CAST(JobComp AS VARCHAR(10)) FROM @TASKS)) AND
				  (JOB_TRAFFIC.ASSIGN_1 = @EmpCode OR JOB_TRAFFIC.ASSIGN_2 = @EmpCode OR JOB_TRAFFIC.ASSIGN_3 = @EmpCode OR JOB_TRAFFIC.ASSIGN_4 = @EmpCode OR JOB_TRAFFIC.ASSIGN_5 = @EmpCode)
			ORDER BY JOB_LOG.CL_CODE, 
					 JOB_LOG.DIV_CODE, 
					 JOB_LOG.PRD_CODE, 
					 JOB_LOG.JOB_NUMBER

		END
            
                                            
	ELSE
		If @RestrictionsOffice = 0
		BEGIN
			INSERT @TASKS
			SELECT     JOB_LOG.CL_CODE AS Client, JOB_LOG.DIV_CODE AS Division, JOB_LOG.PRD_CODE AS Product, ISNULL(JOB_TRAFFIC_DET.TASK_DESCRIPTION, 
									  '') + ' (' + ISNULL(JOB_TRAFFIC_DET.FNC_EST, '') + ')' AS Task, ISNULL(JOB_TRAFFIC_DET.FNC_EST,'') AS FuncCat, 
									  JOB_TRAFFIC_DET.JOB_REVISED_DATE AS DueDate, '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC AS JobAndDesc,
									   '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS JobCompAndDesc, 
									  JOB_TRAFFIC_DET.JOB_NUMBER AS Job, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS JobComp, JOB_LOG.JOB_DESC AS JobDesc, 
									  JOB_COMPONENT.JOB_COMP_DESC AS JobCompDesc, JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, JOB_TRAFFIC_DET.SEQ_NBR AS SeqNo, 
									  JOB_TRAFFIC_DET.TASK_DESCRIPTION, FUNCTIONS.FNC_INACTIVE, CLIENT.CL_NAME, NULL
				FROM         JOB_LOG WITH (NOLOCK) INNER JOIN
									  CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
									  JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
									  JOB_TRAFFIC_DET WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
									  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
									  JOB_TRAFFIC ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
									  JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND 
									  JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR LEFT OUTER JOIN
									  FUNCTIONS WITH (NOLOCK) ON JOB_TRAFFIC_DET.FNC_EST = FUNCTIONS.FNC_CODE
				WHERE  	(NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (JOB_TRAFFIC_DET.TASK_START_DATE <= GETDATE() OR
									  JOB_TRAFFIC_DET.TASK_START_DATE IS NULL) AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL) AND 
									  (FUNCTIONS.FNC_INACTIVE IS NULL OR
									  FUNCTIONS.FNC_INACTIVE = 0) AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE = @EmpCode) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
				ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, 
									  JOB_TRAFFIC_DET.FNC_EST, JOB_TRAFFIC_DET.SEQ_NBR
		

		   INSERT @TASKS
			SELECT  [Client] = JOB_LOG.CL_CODE,
					[Division] = JOB_LOG.DIV_CODE,
					[Product] = JOB_LOG.PRD_CODE,
					[Task] = '',
					[FuncCat] = (SELECT DEF_FNC_CODE FROM EMPLOYEE WHERE EMP_CODE = @EmpCode),
					[DueDate] = NULL,
					[JobAndDesc] = '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC,
					[JobCompAndDesc] = '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC,
					[Job] = JOB_LOG.JOB_NUMBER,
					[JobComp] = JOB_COMPONENT.JOB_COMPONENT_NBR,
					[JobDesc] = JOB_LOG.JOB_DESC,
					[JobCompDesc] = JOB_COMPONENT.JOB_COMP_DESC,
					[HoursAllowed] = 0,
					[SeqNo] = 0,
					'',
					[FNC_INACTIVE] = 0, CLIENT.CL_NAME, NULL
			FROM dbo.JOB_LOG WITH (NOLOCK) INNER JOIN
				 dbo.CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
				 dbo.DIVISION WITH (NOLOCK) ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
				 dbo.PRODUCT WITH (NOLOCK) ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
				 dbo.JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN			 
				 dbo.JOB_TRAFFIC ON JOB_LOG.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
			WHERE 	JOB_TRAFFIC.COMPLETED_DATE IS NULL AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(10)) NOT IN (SELECT CAST(Job AS VARCHAR(10)) + '|' + CAST(JobComp AS VARCHAR(10)) FROM @TASKS)) AND
				  (JOB_TRAFFIC.ASSIGN_1 = @EmpCode OR JOB_TRAFFIC.ASSIGN_2 = @EmpCode OR JOB_TRAFFIC.ASSIGN_3 = @EmpCode OR JOB_TRAFFIC.ASSIGN_4 = @EmpCode OR JOB_TRAFFIC.ASSIGN_5 = @EmpCode)
			ORDER BY JOB_LOG.CL_CODE, 
					 JOB_LOG.DIV_CODE, 
					 JOB_LOG.PRD_CODE, 
					 JOB_LOG.JOB_NUMBER
		END
		ELSE
		BEGIN
			INSERT @TASKS
			SELECT     JOB_LOG.CL_CODE AS Client, JOB_LOG.DIV_CODE AS Division, JOB_LOG.PRD_CODE AS Product, ISNULL(JOB_TRAFFIC_DET.TASK_DESCRIPTION, 
									  '') + ' (' + ISNULL(JOB_TRAFFIC_DET.FNC_EST, '') + ')' AS Task, ISNULL(JOB_TRAFFIC_DET.FNC_EST,'') AS FuncCat, 
									  JOB_TRAFFIC_DET.JOB_REVISED_DATE AS DueDate, '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC AS JobAndDesc,
									   '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC AS JobCompAndDesc, 
									  JOB_TRAFFIC_DET.JOB_NUMBER AS Job, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS JobComp, JOB_LOG.JOB_DESC AS JobDesc, 
									  JOB_COMPONENT.JOB_COMP_DESC AS JobCompDesc, JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, JOB_TRAFFIC_DET.SEQ_NBR AS SeqNo, 
									  JOB_TRAFFIC_DET.TASK_DESCRIPTION, FUNCTIONS.FNC_INACTIVE, CLIENT.CL_NAME, NULL
				FROM         JOB_LOG WITH (NOLOCK) INNER JOIN
									  CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
									  JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
									  JOB_TRAFFIC_DET WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
									  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
									  JOB_TRAFFIC ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
									  JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND 
									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND 
									  JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR LEFT OUTER JOIN
									  FUNCTIONS WITH (NOLOCK) ON JOB_TRAFFIC_DET.FNC_EST = FUNCTIONS.FNC_CODE INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CDE
				WHERE   	(NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (JOB_TRAFFIC_DET.TASK_START_DATE <= GETDATE() OR
									  JOB_TRAFFIC_DET.TASK_START_DATE IS NULL) AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL) AND 
									  (FUNCTIONS.FNC_INACTIVE IS NULL OR
									  FUNCTIONS.FNC_INACTIVE = 0) AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE = @EmpCode) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
				ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, 
									  JOB_TRAFFIC_DET.FNC_EST, JOB_TRAFFIC_DET.SEQ_NBR
		

			INSERT @TASKS
			SELECT  [Client] = JOB_LOG.CL_CODE,
					[Division] = JOB_LOG.DIV_CODE,
					[Product] = JOB_LOG.PRD_CODE,
					[Task] = '',
					[FuncCat] = (SELECT DEF_FNC_CODE FROM EMPLOYEE WHERE EMP_CODE = @EmpCode),
					[DueDate] = NULL,
					[JobAndDesc] = '' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) + ' - ' + JOB_LOG.JOB_DESC,
					[JobCompAndDesc] = '' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC,
					[Job] = JOB_LOG.JOB_NUMBER,
					[JobComp] = JOB_COMPONENT.JOB_COMPONENT_NBR,
					[JobDesc] = JOB_LOG.JOB_DESC,
					[JobCompDesc] = JOB_COMPONENT.JOB_COMP_DESC,
					[HoursAllowed] = 0,
					[SeqNo] = 0,
					'',
					[FNC_INACTIVE] = 0, CLIENT.CL_NAME, NULL
			FROM dbo.JOB_LOG WITH (NOLOCK) INNER JOIN
				 dbo.CLIENT WITH (NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
				 dbo.DIVISION WITH (NOLOCK) ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
				 dbo.PRODUCT WITH (NOLOCK) ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
				 dbo.JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN			 
				 dbo.JOB_TRAFFIC ON JOB_LOG.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EmpCode
			WHERE 	JOB_TRAFFIC.COMPLETED_DATE IS NULL AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12, 10, 9, 6, 5, 3, 2))) AND (CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(10)) + '|' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(10)) NOT IN (SELECT CAST(Job AS VARCHAR(10)) + '|' + CAST(JobComp AS VARCHAR(10)) FROM @TASKS)) AND
				  (JOB_TRAFFIC.ASSIGN_1 = @EmpCode OR JOB_TRAFFIC.ASSIGN_2 = @EmpCode OR JOB_TRAFFIC.ASSIGN_3 = @EmpCode OR JOB_TRAFFIC.ASSIGN_4 = @EmpCode OR JOB_TRAFFIC.ASSIGN_5 = @EmpCode)
			ORDER BY JOB_LOG.CL_CODE, 
					 JOB_LOG.DIV_CODE, 
					 JOB_LOG.PRD_CODE, 
					 JOB_LOG.JOB_NUMBER
		END

	UPDATE @TASKS
	SET TASK_DESCRIPTION = (SELECT FNC_DESCRIPTION FROM FUNCTIONS WHERE FUNCTIONS.FNC_CODE = FuncCat)
	WHERE [DueDate] IS NULL;

	UPDATE @TASKS
	SET Task = TASK_DESCRIPTION + ' (' + FuncCat + ')' 
	WHERE [DueDate] IS NULL;
            
	UPDATE @TASKS
	SET Task = J.TASK_DESCRIPTION, TASK_DESCRIPTION = J.TASK_DESCRIPTION
	FROM @TASKS T INNER JOIN JOB_TRAFFIC_DET J ON T.Job = J.JOB_NUMBER AND T.JobComp = J.JOB_COMPONENT_NBR AND T.SeqNo = J.SEQ_NBR
	WHERE T.Task IS NULL OR DATALENGTH(T.Task) = 0;

	UPDATE @TASKS
	SET AlertID = A.ALERT_ID
	FROM @TASKS T INNER JOIN ALERT A ON T.Job = A.JOB_NUMBER AND T.JobComp = A.JOB_COMPONENT_NBR AND T.SeqNo = A.TASK_SEQ_NBR
	WHERE
		A.ALERT_LEVEL = 'BRD';

	UPDATE @TASKS SET FuncCat = NULL WHERE DATALENGTH(FuncCat) = 0;

	SELECT DISTINCT
		T.*,
		AlertSubject = A.[SUBJECT],
		ClientCode = T.Client,
		DivisionCode = T.Division,
		ProductCode = T.Product,
		FunctionCategory = T.FuncCat,
		JobWithDescription = T.JobAndDesc,
		JobComponentWithDescription = T.JobCompAndDesc,
		JobNumber = T.Job,
		JobComponentNumber = T.JobComp,
		JobDescription = T.JobDesc,
		JobComponentDescription = T.JobCompDesc,
		TaskSequenceNumber = T.SeqNo,
		TaskDescription = T.TASK_DESCRIPTION,
		IsFunctionInactive = CASE
								WHEN T.FNC_INACTIVE = 1 THEN CAST(1 AS BIT)
								ELSE CAST(0 AS BIT)
							 END,
		ClientName = T.ClientName
	FROM 
		@TASKS T
		LEFT OUTER JOIN ALERT A ON T.AlertID = A.ALERT_ID
		LEFT OUTER JOIN [dbo].[advtf_alert_inactive_work_items]() IWI ON A.ALERT_ID = IWI.ALERT_ID
	WHERE
		1 = CASE WHEN NOT A.ALERT_ID IS NULL AND IWI.ALERT_ID IS NULL THEN 1
		WHEN A.ALERT_ID IS NULL THEN 1
		ELSE 0 END
	ORDER BY 
		Client,
		Division,
		Product,
		Job,
		JobComp;

END
/*=========== QUERY ===========*/
