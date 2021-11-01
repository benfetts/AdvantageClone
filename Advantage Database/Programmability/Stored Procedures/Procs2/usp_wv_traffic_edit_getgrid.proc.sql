﻿



/* CHANGE LOG:
==========================================================
BJL, 20060622: Do not require dates on tasks
*/

CREATE PROCEDURE [dbo].[usp_wv_traffic_edit_getgrid] 
@UserID as VarChar(100),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobCode VarChar(6), 
@JobComp VarChar(6),
@EmpCode VarChar(6), 
@AE VarChar(6), 
@Role VarChar(6),
@TaskCode VarChar(10), 
@TaskCompDate VarChar(10), 
@TaskTempDate VarChar(10),
@DueDate VarChar(10),
@Type VarChar(1)
/*,@SortOrder Int*/
AS

Declare @Rescrictions Int

Set NoCount on

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	Begin
	SELECT JOB_TRAFFIC.ROWID as ROWID,
		JOB_LOG.CL_CODE + ' - ' + CLIENT.CL_NAME as Client, 
		JOB_LOG.DIV_CODE + ' - ' + DIVISION.DIV_NAME as Division, 
		JOB_LOG.PRD_CODE + ' - ' + PRODUCT.PRD_DESCRIPTION as Product, 
		JOB_LOG.JOB_NUMBER as JOB_NUMBER, 
	 	'(' + Cast(JOB_LOG.JOB_NUMBER as VarChar(10)) + ') ' + JOB_LOG.JOB_DESC as Job, 
		JOB_TRAFFIC.JOB_COMPONENT_NBR as JOB_COMPONENT_NBR, 
		'(' + Cast(JOB_TRAFFIC.JOB_COMPONENT_NBR as VarChar(10)) + ') ' + JOB_COMPONENT.JOB_COMP_DESC as [Job Comp],
		JOB_TRAFFIC.TRF_CODE as [Status Code],
		JOB_COMPONENT.EMP_CODE as [AE],
		Convert(char,   JOB_TRAFFIC.COMPLETED_DATE, 101)  as [Job Completed],
		Cast(JOB_TRAFFIC.TRF_COMMENTS as VarChar(2000)) as Comments
		--,ISNULL(JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,0) AS TRAFFIC_PHASE_ID
	FROM    JOB_COMPONENT 
		INNER JOIN JOB_TRAFFIC 
	 	  ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN JOB_TRAFFIC_DET 
		  ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		INNER JOIN JOB_LOG 
		  ON  JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER
		INNER JOIN CLIENT 
	 	  ON CLIENT.CL_CODE = JOB_LOG.CL_CODE 
		INNER JOIN PRODUCT 
		  ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE 
		  AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE 
		  AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
		INNER JOIN DIVISION 
		  ON JOB_LOG.DIV_CODE = DIVISION.DIV_CODE 
		  AND JOB_LOG.CL_CODE = DIVISION.CL_CODE
		INNER JOIN SEC_CLIENT 
		ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	LEFT OUTER JOIN TASK_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE 
	LEFT OUTER JOIN EMP_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
	Where  
		 (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
		And JOB_TRAFFIC.COMPLETED_DATE IS NULL
		and JOB_LOG.CL_CODE Like '%' + @ClientCode
		And JOB_LOG.DIV_CODE Like '%' + @DivCode
		And JOB_LOG.PRD_CODE Like '%' + @ProdCode
		And JOB_LOG.JOB_NUMBER Like @JobCode
		And JOB_TRAFFIC.JOB_COMPONENT_NBR Like @JobComp
		And ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') Like '%' + @EmpCode
		AND ISNULL(JOB_COMPONENT.EMP_CODE, '') Like '%' + @AE
		And ISNULL(JOB_TRAFFIC_DET.FNC_CODE, '') Like '%' + @TaskCode
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, '') > @TaskCompDate OR JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE, '') = @TaskTempDate OR JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, '') <= @DueDate OR JOB_TRAFFIC_DET.JOB_REVISED_DATE IS NULL )
		AND (CLIENT.ACTIVE_FLAG = 1) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		AND ISNULL(JOB_TRAFFIC_DET.TASK_STATUS, '') Like 
		Case @Type
			When 'P' Then 'A'
			When '' Then '%'
		End
		AND (ISNULL(TASK_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role OR ISNULL(EMP_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role)
	Group By JOB_TRAFFIC.ROWID, JOB_LOG.CL_CODE, 
		CLIENT.CL_NAME, 
		JOB_LOG.DIV_CODE, 
		DIVISION.DIV_NAME, 
		JOB_LOG.PRD_CODE, 
		PRODUCT.PRD_DESCRIPTION, 
		JOB_LOG.JOB_NUMBER, 
		JOB_LOG.JOB_DESC, 
		JOB_TRAFFIC.JOB_COMPONENT_NBR,
		JOB_COMPONENT.EMP_CODE,
		JOB_COMPONENT.JOB_COMP_DESC, 
		JOB_TRAFFIC.TRF_CODE, 
		JOB_TRAFFIC .COMPLETED_DATE,
		Cast(JOB_TRAFFIC.TRF_COMMENTS as VarChar(2000))
		--,ISNULL(JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,0)
	Order By JOB_LOG.CL_CODE,JOB_LOG.DIV_CODE,JOB_LOG.PRD_CODE,JOB_LOG.JOB_NUMBER,JOB_TRAFFIC.JOB_COMPONENT_NBR
	
	SELECT JOB_TRAFFIC_DET.ROWID as ROWID,
		 JOB_TRAFFIC_DET.JOB_NUMBER,
		JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
		 JOB_TRAFFIC_DET.FNC_CODE as [Task Code], 
		JOB_TRAFFIC_DET.TASK_DESCRIPTION as [Task Description], 
		JOB_TRAFFIC_DET.TASK_STATUS as [Task Status], 
		JOB_TRAFFIC_DET.EMP_CODE as [Emp Code], 
		Convert(char,   JOB_TRAFFIC_DET.TASK_START_DATE, 101) as [StartDate],
		Convert(char,  JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101) as [Date Due], 
		JOB_TRAFFIC_DET.REVISED_DUE_TIME as [Time Due], 
		Convert(char,   JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101)  as [Task Completed], 
	        	Convert(char,   JOB_TRAFFIC_DET.TEMP_COMP_DATE, 101)  as [Temp Completed],
		Cast(JOB_TRAFFIC_DET.FNC_COMMENTS as VarChar(1000)) as [Task Comments],
		ISNULL(JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,0) AS TRAFFIC_PHASE_ID,TRAFFIC_PHASE.PHASE_ORDER
/*		
FROM    JOB_COMPONENT 
		INNER JOIN JOB_TRAFFIC 
	 	  ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		INNER JOIN JOB_TRAFFIC_DET 
		  ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		INNER JOIN JOB_LOG 
		  ON  JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER
		INNER JOIN CLIENT 
	 	  ON CLIENT.CL_CODE = JOB_LOG.CL_CODE 
		INNER JOIN SEC_CLIENT 
		ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	LEFT OUTER JOIN TASK_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE 
	LEFT OUTER JOIN EMP_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
*/
	FROM  JOB_COMPONENT INNER JOIN
		  JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
		  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
		  JOB_TRAFFIC_DET ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
		  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
		  JOB_LOG ON JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
		  CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
		  SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
		  JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE LEFT OUTER JOIN
		  TRAFFIC_PHASE ON JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID LEFT OUTER JOIN
		  TASK_TRAFFIC_ROLE ON JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE LEFT OUTER JOIN
		  EMP_TRAFFIC_ROLE ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
	  
	Where  
		 (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
		And JOB_TRAFFIC.COMPLETED_DATE IS NULL
		And JOB_LOG.CL_CODE Like '%' + @ClientCode
		And JOB_LOG.DIV_CODE Like '%' + @DivCode
		And JOB_LOG.PRD_CODE Like '%' + @ProdCode
		And JOB_LOG.JOB_NUMBER Like @JobCode
		And JOB_TRAFFIC.JOB_COMPONENT_NBR Like @JobComp
		And ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') Like '%' + @EmpCode
		AND ISNULL(JOB_COMPONENT.EMP_CODE, '') Like '%' + @AE
		And ISNULL(JOB_TRAFFIC_DET.FNC_CODE, '') Like '%' + @TaskCode
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, '') > @TaskCompDate OR JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE, '') = @TaskTempDate OR JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, '') <= @DueDate OR JOB_TRAFFIC_DET.JOB_REVISED_DATE IS NULL )
		AND (CLIENT.ACTIVE_FLAG = 1) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		AND ISNULL(JOB_TRAFFIC_DET.TASK_STATUS, '') Like 
		Case @Type
			When 'P' Then 'A'
			When '' Then '%'
		End
		AND (ISNULL(TASK_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role OR ISNULL(EMP_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role)
	Group By JOB_TRAFFIC_DET.ROWID,
		JOB_TRAFFIC_DET.JOB_NUMBER,
		JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
		 JOB_TRAFFIC_DET.FNC_CODE, 
		JOB_TRAFFIC_DET.TASK_DESCRIPTION , 
		JOB_TRAFFIC_DET.TASK_STATUS, 
		JOB_TRAFFIC_DET.EMP_CODE, 
		JOB_TRAFFIC_DET.TASK_START_DATE, 
		JOB_TRAFFIC_DET.JOB_REVISED_DATE,   
		JOB_TRAFFIC_DET.REVISED_DUE_TIME,
		JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,  
	        	JOB_TRAFFIC_DET.TEMP_COMP_DATE,
		Cast(JOB_TRAFFIC_DET.FNC_COMMENTS as VarChar(1000)),
		JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,TRAFFIC_PHASE.PHASE_ORDER
	ORDER BY 
		TRAFFIC_PHASE.PHASE_ORDER,JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID ASC,
		JOB_TRAFFIC_DET.TASK_START_DATE,JOB_TRAFFIC_DET.JOB_REVISED_DATE
	/*
		CASE
		WHEN @SortOrder = 0 THEN
			TRAFFIC_PHASE.PHASE_ORDER, 
			JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,
			CAST(JOB_TRAFFIC_DET.FNC_CODE AS VARCHAR(20))
			+CAST(JOB_TRAFFIC_DET.TASK_START_DATE AS VARCHAR(15))
			+CAST(JOB_TRAFFIC_DET.JOB_REVISED_DATE AS VARCHAR(15))
		WHEN @SortOrder = 1 THEN
			TRAFFIC_PHASE.PHASE_ORDER, 
			JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,
			CAST(JOB_TRAFFIC_DET.TASK_START_DATE AS VARCHAR(15))
			+CAST(JOB_TRAFFIC_DET.JOB_REVISED_DATE AS VARCHAR(15))
		WHEN @SortOrder = 2 THEN
			TRAFFIC_PHASE.PHASE_ORDER, 
			JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID
		END
	*/
	
	End
else
	Begin
	SELECT JOB_TRAFFIC.ROWID as ROWID,
		JOB_LOG.CL_CODE +' - ' + CLIENT.CL_NAME as Client, 
		JOB_LOG.DIV_CODE +' - ' + DIVISION.DIV_NAME as Division, 
		JOB_LOG.PRD_CODE +' - ' + PRODUCT.PRD_DESCRIPTION as Product, 
		JOB_LOG.JOB_NUMBER as JOB_NUMBER, 
	 	'(' + Cast(JOB_LOG.JOB_NUMBER as VarChar(10)) + ') ' + JOB_LOG.JOB_DESC as Job, 
		JOB_TRAFFIC.JOB_COMPONENT_NBR as JOB_COMPONENT_NBR, 
		'(' + Cast(JOB_TRAFFIC.JOB_COMPONENT_NBR as VarChar(10)) + ') ' + JOB_COMPONENT.JOB_COMP_DESC as [Job Comp],
		JOB_TRAFFIC.TRF_CODE as [Status Code],
		JOB_COMPONENT.EMP_CODE as [AE],
		--''  as [Job Completed]
		Convert(char,   JOB_TRAFFIC.COMPLETED_DATE, 101)  as [Job Completed],
		Cast(JOB_TRAFFIC.TRF_COMMENTS as VarChar(2000)) as Comments
		--,ISNULL(JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,0) AS TRAFFIC_PHASE_ID
	FROM    JOB_COMPONENT 
		INNER JOIN JOB_TRAFFIC 
	 	  ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN JOB_TRAFFIC_DET 
		  ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		INNER JOIN JOB_LOG 
		  ON  JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER
		INNER JOIN CLIENT 
	 	  ON CLIENT.CL_CODE = JOB_LOG.CL_CODE 
		INNER JOIN PRODUCT 
		  ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE 
		  AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE 
		  AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
		INNER JOIN DIVISION 
		  ON JOB_LOG.DIV_CODE = DIVISION.DIV_CODE 
		  AND JOB_LOG.CL_CODE = DIVISION.CL_CODE
	LEFT OUTER JOIN TASK_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE 
	LEFT OUTER JOIN EMP_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
	Where  
		 (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))

		And JOB_TRAFFIC.COMPLETED_DATE IS NULL
		and JOB_LOG.CL_CODE Like '%' + @ClientCode
		And JOB_LOG.DIV_CODE Like '%' + @DivCode
		And JOB_LOG.PRD_CODE Like '%' + @ProdCode
		And JOB_LOG.JOB_NUMBER Like @JobCode
		And JOB_TRAFFIC.JOB_COMPONENT_NBR Like @JobComp
		And ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') Like '%' + @EmpCode
		AND ISNULL(JOB_COMPONENT.EMP_CODE, '') Like '%' + @AE
		And ISNULL(JOB_TRAFFIC_DET.FNC_CODE, '') Like '%' + @TaskCode
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, '') > @TaskCompDate OR JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE, '') = @TaskTempDate OR JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, '') <= @DueDate OR JOB_TRAFFIC_DET.JOB_REVISED_DATE IS NULL )
		AND ISNULL(JOB_TRAFFIC_DET.TASK_STATUS, '') Like 
		Case @Type
			When 'P' Then 'A'
			When '' Then '%'
		End
		AND (ISNULL(TASK_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role OR ISNULL(EMP_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role)
	Group By JOB_TRAFFIC.ROWID, JOB_LOG.CL_CODE, 
		CLIENT.CL_NAME, 
		JOB_LOG.DIV_CODE, 
		DIVISION.DIV_NAME, 
		JOB_LOG.PRD_CODE, 
		PRODUCT.PRD_DESCRIPTION, 
		JOB_LOG.JOB_NUMBER, 
		JOB_LOG.JOB_DESC, 
		JOB_TRAFFIC.JOB_COMPONENT_NBR, 
		JOB_COMPONENT.EMP_CODE,
		JOB_COMPONENT.JOB_COMP_DESC, 
		JOB_TRAFFIC.TRF_CODE, 
		JOB_TRAFFIC .COMPLETED_DATE,
		Cast(JOB_TRAFFIC.TRF_COMMENTS as VarChar(2000))
		--,ISNULL(JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,0)
	Order By JOB_LOG.CL_CODE,JOB_LOG.DIV_CODE,JOB_LOG.PRD_CODE,JOB_LOG.JOB_NUMBER,JOB_TRAFFIC.JOB_COMPONENT_NBR
	
	SELECT	JOB_TRAFFIC_DET.ROWID as ROWID,
			JOB_TRAFFIC_DET.JOB_NUMBER,
			JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
			JOB_TRAFFIC_DET.FNC_CODE as [Task Code], 
			JOB_TRAFFIC_DET.TASK_DESCRIPTION as [Task Description], 
			JOB_TRAFFIC_DET.TASK_STATUS as [Task Status], 
			JOB_TRAFFIC_DET.EMP_CODE as [Emp Code], 
			Convert(char,   JOB_TRAFFIC_DET.TASK_START_DATE, 101) as [StartDate],
			Convert(char,  JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101) as [Date Due], 
			JOB_TRAFFIC_DET.REVISED_DUE_TIME as [Time Due], 
			Convert(char,   JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101)  as [Task Completed], 
				Convert(char,   JOB_TRAFFIC_DET.TEMP_COMP_DATE, 101)  as [Temp Completed],
			Cast(JOB_TRAFFIC_DET.FNC_COMMENTS as VarChar(1000)) as [Task Comments],
			ISNULL(JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,0) AS TRAFFIC_PHASE_ID ,TRAFFIC_PHASE.PHASE_ORDER
	FROM  JOB_COMPONENT INNER JOIN
          JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
          JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
          JOB_TRAFFIC_DET ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
          JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
          JOB_LOG ON JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
          TRAFFIC_PHASE ON JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID LEFT OUTER JOIN
          TASK_TRAFFIC_ROLE ON JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE LEFT OUTER JOIN
          EMP_TRAFFIC_ROLE ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
	/*FROM    JOB_COMPONENT 
		INNER JOIN JOB_TRAFFIC 
	 	  ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		INNER JOIN JOB_TRAFFIC_DET 
		  ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		  AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
		INNER JOIN JOB_LOG 
		  ON  JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER
	LEFT OUTER JOIN TASK_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE 
	LEFT OUTER JOIN EMP_TRAFFIC_ROLE
	  ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
	  */
	WHERE  
		(NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
		AND JOB_TRAFFIC.COMPLETED_DATE IS NULL
		AND JOB_LOG.CL_CODE Like '%' + @ClientCode
		AND JOB_LOG.DIV_CODE Like '%' + @DivCode
		AND JOB_LOG.PRD_CODE Like '%' + @ProdCode
		AND JOB_LOG.JOB_NUMBER Like @JobCode
		AND JOB_TRAFFIC.JOB_COMPONENT_NBR Like @JobComp
		AND ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') Like '%' + @EmpCode
		AND ISNULL(JOB_COMPONENT.EMP_CODE, '') Like '%' + @AE
		AND ISNULL(JOB_TRAFFIC_DET.FNC_CODE, '') Like '%' + @TaskCode
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, '') > @TaskCompDate OR JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE, '') = @TaskTempDate OR JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL)
		AND (ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, '') <= @DueDate OR JOB_TRAFFIC_DET.JOB_REVISED_DATE IS NULL )
		AND ISNULL(JOB_TRAFFIC_DET.TASK_STATUS, '') Like 
		Case @Type
			When 'P' Then 'A'
			When '' Then '%' 
		End
		AND (ISNULL(TASK_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role OR ISNULL(EMP_TRAFFIC_ROLE.ROLE_CODE, '') Like '%' + @Role)
	Group By JOB_TRAFFIC_DET.ROWID,
		JOB_TRAFFIC_DET.JOB_NUMBER,
		JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
		 JOB_TRAFFIC_DET.FNC_CODE, 
		JOB_TRAFFIC_DET.TASK_DESCRIPTION , 
		JOB_TRAFFIC_DET.TASK_STATUS, 
		JOB_TRAFFIC_DET.EMP_CODE, 
		JOB_TRAFFIC_DET.TASK_START_DATE, 
		JOB_TRAFFIC_DET.JOB_REVISED_DATE,   
		JOB_TRAFFIC_DET.REVISED_DUE_TIME,
		JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,  
	        	JOB_TRAFFIC_DET.TEMP_COMP_DATE,
		Cast(JOB_TRAFFIC_DET.FNC_COMMENTS as VarChar(1000)),
		JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,TRAFFIC_PHASE.PHASE_ORDER
		ORDER BY
			TRAFFIC_PHASE.PHASE_ORDER,JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID ASC,
			JOB_TRAFFIC_DET.TASK_START_DATE,JOB_TRAFFIC_DET.JOB_REVISED_DATE
		/*		

			CASE
			WHEN @SortOrder = 0 THEN
				TRAFFIC_PHASE.PHASE_ORDER, 
				JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,
				CAST(JOB_TRAFFIC_DET.FNC_CODE AS VARCHAR(20))
				+CAST(JOB_TRAFFIC_DET.TASK_START_DATE AS VARCHAR(15))
				+CAST(JOB_TRAFFIC_DET.JOB_REVISED_DATE AS VARCHAR(15))
			WHEN @SortOrder = 1 THEN
				TRAFFIC_PHASE.PHASE_ORDER, 
				JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID,
				CAST(JOB_TRAFFIC_DET.TASK_START_DATE AS VARCHAR(15))
				+CAST(JOB_TRAFFIC_DET.JOB_REVISED_DATE AS VARCHAR(15))
			WHEN @SortOrder = 2 THEN
				TRAFFIC_PHASE.PHASE_ORDER, 
				JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID
			END
		*/
End






