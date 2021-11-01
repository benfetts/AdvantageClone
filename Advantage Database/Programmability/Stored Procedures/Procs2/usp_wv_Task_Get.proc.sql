﻿













CREATE PROCEDURE [dbo].[usp_wv_Task_Get] 
@JobNo Int, 
@JobComp Int, 
@SeqNo Int,
@EmpCode Varchar(6)
AS

Set NoCount On
if @EmpCode <> ''
	SELECT     '(' + JOB_LOG.CL_CODE + ') ' + CLIENT.CL_NAME AS CLIENT, '(' + JOB_LOG.DIV_CODE + ') ' + DIVISION.DIV_NAME AS DIVISION, 
						  '(' + JOB_LOG.PRD_CODE + ') ' + PRODUCT.PRD_DESCRIPTION AS PRODUCT, '(' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) 
						  + ') ' + JOB_LOG.JOB_DESC AS Job, '(' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) 
						  + ') ' + JOB_COMPONENT.JOB_COMP_DESC AS JobComp, '(' + ISNULL(V_JOB_TRAFFIC_DET.FNC_CODE, '') 
						  + ') ' + ISNULL(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '') AS Task, ISNULL(CONVERT(char, V_JOB_TRAFFIC_DET.JOB_DUE_DATE, 101), '') AS DueDate, 
						  ISNULL(CONVERT(char, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101), '') AS RevDueDate, ISNULL(V_JOB_TRAFFIC_DET.DUE_TIME, '') AS DueTime, ISNULL(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
						  AS RevDueTime, ISNULL(CONVERT(char, V_JOB_TRAFFIC_DET.TASK_START_DATE, 101), '') AS TaskStartDate, 
						  ISNULL(V_JOB_TRAFFIC_DET.FNC_COMMENTS,'') AS Comments, ISNULL(V_JOB_TRAFFIC_DET.TEMP_COMP_DATE, '') AS TempCompDate, 
						  V_JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, ISNULL(V_JOB_TRAFFIC_DET.TASK_STATUS,'P') AS TaskStatus, 
						  TRAFFIC_PHASE.PHASE_DESC AS Phase, ISNULL(CONVERT(char, JOB_COMPONENT.START_DATE, 101),'') AS JobStartDate, ISNULL(CONVERT(char, 
						  JOB_COMPONENT.JOB_FIRST_USE_DATE, 101), '') AS JobDueDate, '(' + ISNULL(TRAFFIC.TRF_CODE, '') 
						  + ') ' + ISNULL(TRAFFIC.TRF_DESCRIPTION, '') AS TrafficStatus, JOB_TRAFFIC.TRF_COMMENTS AS TrafficComments, 
						  '('+JOB_COMPONENT.EMP_CODE+') '+ ISNULL(EMPLOYEE.EMP_FNAME,'')+' '+ISNULL(EMPLOYEE.EMP_MI,'')+' '+ISNULL(EMPLOYEE.EMP_LNAME,'') AS AE,
		                  '('+V_JOB_TRAFFIC_DET.EMP_CODE+') '+ dbo.udf_get_empl_name(V_JOB_TRAFFIC_DET.EMP_CODE, 'FML') AS Employee, ISNULL(V_JOB_TRAFFIC_DET.COMPLETED_COMMENTS,'') AS CompletedComments,
		                  ISNULL(V_JOB_TRAFFIC_DET.DUE_DATE_COMMENTS,'') AS DueDateComments, ISNULL(V_JOB_TRAFFIC_DET.REV_DATE_COMMENTS,'') AS RevDateComments
	FROM         JOB_LOG INNER JOIN
						  CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
						  DIVISION ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE AND DIVISION.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
						  PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND 
						  PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
						  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
						  V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER AND 
						  JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR LEFT OUTER JOIN
						  TRAFFIC_PHASE ON V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID INNER JOIN
						  JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
						  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
						  TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN
						  EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
	/*
	SELECT '(' + JOB_LOG.CL_CODE + ') ' + CLIENT.CL_NAME as CLIENT,
		   '(' + JOB_LOG.DIV_CODE + ') ' + DIVISION.DIV_NAME as DIVISION,
		   '(' + JOB_LOG.PRD_CODE + ') ' + PRODUCT.PRD_DESCRIPTION as PRODUCT,
		   '(' + Cast(JOB_LOG.JOB_NUMBER as VarChar(10)) + ') ' + JOB_LOG.JOB_DESC as Job,
		   '(' + Cast(JOB_COMPONENT.JOB_COMPONENT_NBR as VarChar(10)) + ') ' + JOB_COMPONENT.JOB_COMP_DESC as JobComp,
		   '(' + isnull(V_JOB_TRAFFIC_DET.FNC_CODE, '') + ')'  + isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '') as Task,
		   convert(char, V_JOB_TRAFFIC_DET.JOB_DUE_DATE, 101) as [DueDate],
		   convert(char, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101) as [RevDueDate],
		   isnull(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME,'') as [RevDueTime],
		   convert(char, V_JOB_TRAFFIC_DET.TASK_START_DATE, 101) as [TaskStartDate],
		   V_JOB_TRAFFIC_DET.FNC_COMMENTS as Comments,
		   Convert(char, V_JOB_TRAFFIC_DET.TEMP_COMP_DATE, 101) as TempCompDate,
		   V_JOB_TRAFFIC_DET.JOB_HRS as HoursAllowed,
		   V_JOB_TRAFFIC_DET.TASK_STATUS as TaskStatus,
		   TRAFFIC_PHASE.PHASE_DESC as Phase, 
		   Convert(char, JOB_COMPONENT.START_DATE, 101)  as JobStartDate, 
		   Convert(char, JOB_COMPONENT.JOB_FIRST_USE_DATE, 101)  as JobDueDate, 
		   '(' + isnull(TRAFFIC.TRF_CODE, '') + ') ' + isnull(TRAFFIC.TRF_DESCRIPTION, '') as TrafficStatus, 
		   JOB_TRAFFIC.TRF_COMMENTS as TrafficComments
	  FROM JOB_LOG INNER JOIN CLIENT          ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				   INNER JOIN DIVISION        ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE AND 
												 DIVISION.CL_CODE = JOB_LOG.CL_CODE
				   INNER JOIN PRODUCT         ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND
												 PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND
												 PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				   INNER JOIN JOB_COMPONENT   ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				   INNER JOIN V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER AND
							  JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			  LEFT OUTER JOIN TRAFFIC_PHASE   ON V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID
				   INNER JOIN JOB_TRAFFIC     ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
												 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
				   INNER JOIN TRAFFIC         ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE 
	*/
	 WHERE (V_JOB_TRAFFIC_DET.JOB_NUMBER = @JobNo) AND
		   (V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobComp) AND
		   (V_JOB_TRAFFIC_DET.SEQ_NBR = @SeqNo) AND
		   (V_JOB_TRAFFIC_DET.EMP_CODE = @EmpCode)
Else
		SELECT     '(' + JOB_LOG.CL_CODE + ') ' + CLIENT.CL_NAME AS CLIENT, '(' + JOB_LOG.DIV_CODE + ') ' + DIVISION.DIV_NAME AS DIVISION, 
								  '(' + JOB_LOG.PRD_CODE + ') ' + PRODUCT.PRD_DESCRIPTION AS PRODUCT, '(' + CAST(JOB_LOG.JOB_NUMBER AS VarChar(10)) 
								  + ') ' + JOB_LOG.JOB_DESC AS Job, '(' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VarChar(10)) 
								  + ') ' + JOB_COMPONENT.JOB_COMP_DESC AS JobComp, '(' + ISNULL(JOB_TRAFFIC_DET.FNC_CODE, '') 
								  + ') ' + ISNULL(JOB_TRAFFIC_DET.TASK_DESCRIPTION, '') AS Task, ISNULL(CONVERT(char, JOB_TRAFFIC_DET.JOB_DUE_DATE, 101),'') AS DueDate, 
								  ISNULL(CONVERT(char, JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101),'') AS RevDueDate, ISNULL(JOB_TRAFFIC_DET.DUE_TIME, '') AS DueTime, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
								  AS RevDueTime, ISNULL(CONVERT(char, JOB_TRAFFIC_DET.TASK_START_DATE, 101),'') AS TaskStartDate, 
								  ISNULL(JOB_TRAFFIC_DET.FNC_COMMENTS,'') AS Comments, ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE, '') AS TempCompDate, 
								  JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, ISNULL(JOB_TRAFFIC_DET.TASK_STATUS,'P') AS TaskStatus, 
								  TRAFFIC_PHASE.PHASE_DESC AS Phase, ISNULL(CONVERT(char, JOB_COMPONENT.START_DATE, 101),'') AS JobStartDate, ISNULL(CONVERT(char, 
								  JOB_COMPONENT.JOB_FIRST_USE_DATE, 101),'') AS JobDueDate, '(' + ISNULL(TRAFFIC.TRF_CODE, '') 
								  + ') ' + ISNULL(TRAFFIC.TRF_DESCRIPTION, '') AS TrafficStatus, JOB_TRAFFIC.TRF_COMMENTS AS TrafficComments, 
								  '('+JOB_COMPONENT.EMP_CODE+') '+ ISNULL(EMPLOYEE.EMP_FNAME,'')+' '+ISNULL(EMPLOYEE.EMP_MI,'')+' '+ISNULL(EMPLOYEE.EMP_LNAME,'') AS AE,
				                  ISNULL(JOB_TRAFFIC_DET.EMP_CODE,'') AS Employee, '' AS CompletedComments, ISNULL(JOB_TRAFFIC_DET.DUE_DATE_COMMENTS,'') AS DueDateComments, ISNULL(JOB_TRAFFIC_DET.REV_DATE_COMMENTS,'') AS RevDateComments
			FROM         JOB_LOG INNER JOIN
								  CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
								  DIVISION ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE AND DIVISION.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
								  PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND 
								  PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
								  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
								  JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
								  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR LEFT OUTER JOIN
								  TRAFFIC_PHASE ON JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID INNER JOIN
								  JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
								  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR INNER JOIN
								  TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN
								  EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
			/*
			SELECT '(' + JOB_LOG.CL_CODE + ') ' + CLIENT.CL_NAME as CLIENT,
				   '(' + JOB_LOG.DIV_CODE + ') ' + DIVISION.DIV_NAME as DIVISION,
				   '(' + JOB_LOG.PRD_CODE + ') ' + PRODUCT.PRD_DESCRIPTION as PRODUCT,
				   '(' + Cast(JOB_LOG.JOB_NUMBER as VarChar(10)) + ') ' + JOB_LOG.JOB_DESC as Job,
				   '(' + Cast(JOB_COMPONENT.JOB_COMPONENT_NBR as VarChar(10)) + ') ' + JOB_COMPONENT.JOB_COMP_DESC as JobComp,
				   '(' + isnull(V_JOB_TRAFFIC_DET.FNC_CODE, '') + ')'  + isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '') as Task,
				   convert(char, V_JOB_TRAFFIC_DET.JOB_DUE_DATE, 101) as [DueDate],
				   convert(char, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101) as [RevDueDate],
				   isnull(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME,'') as [RevDueTime],
				   convert(char, V_JOB_TRAFFIC_DET.TASK_START_DATE, 101) as [TaskStartDate],
				   V_JOB_TRAFFIC_DET.FNC_COMMENTS as Comments,
				   Convert(char, V_JOB_TRAFFIC_DET.TEMP_COMP_DATE, 101) as TempCompDate,
				   V_JOB_TRAFFIC_DET.JOB_HRS as HoursAllowed,
				   V_JOB_TRAFFIC_DET.TASK_STATUS as TaskStatus,
				   TRAFFIC_PHASE.PHASE_DESC as Phase, 
				   Convert(char, JOB_COMPONENT.START_DATE, 101)  as JobStartDate, 
				   Convert(char, JOB_COMPONENT.JOB_FIRST_USE_DATE, 101)  as JobDueDate, 
				   '(' + isnull(TRAFFIC.TRF_CODE, '') + ') ' + isnull(TRAFFIC.TRF_DESCRIPTION, '') as TrafficStatus, 
				   JOB_TRAFFIC.TRF_COMMENTS as TrafficComments
			  FROM JOB_LOG INNER JOIN CLIENT          ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
						   INNER JOIN DIVISION        ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE AND 
														 DIVISION.CL_CODE = JOB_LOG.CL_CODE
						   INNER JOIN PRODUCT         ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND
														 PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND
														 PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
						   INNER JOIN JOB_COMPONENT   ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
						   INNER JOIN V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER AND
									  JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
					  LEFT OUTER JOIN TRAFFIC_PHASE   ON V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID
						   INNER JOIN JOB_TRAFFIC     ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
														 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
						   INNER JOIN TRAFFIC         ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE 
			*/
			 WHERE (JOB_TRAFFIC_DET.JOB_NUMBER = @JobNo) AND
				   (JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobComp) AND
				   (JOB_TRAFFIC_DET.SEQ_NBR = @SeqNo)












