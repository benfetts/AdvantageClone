﻿
CREATE PROCEDURE [dbo].[usp_wv_dto_GetMyProject_DrillDown] 
@EmpCode as VarChar(6),
@JobNo Int, 
@JobComp Int
AS

Set NoCount On
 
	SELECT ISNULL(JOB_TRAFFIC_DET.TASK_DESCRIPTION, '') + '(' + ISNULL(JOB_TRAFFIC_DET.FNC_CODE, '') + ')' AS Task,
		   JOB_TRAFFIC_DET.JOB_DUE_DATE AS [DueDate],
		   JOB_TRAFFIC_DET.JOB_REVISED_DATE AS [RevDueDate],
		   JOB_TRAFFIC_DET.TEMP_COMP_DATE AS TempCompDate,
		   ISNULL(JOB_TRAFFIC_DET.JOB_DUE_DATE, '') AS [DueDateString],
		   ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, '') AS [RevDueDateString],
		   ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE, '') AS TempCompDateString,
		   JOB_TRAFFIC_DET.EMP_CODE AS EmpCode,
		   CASE 
				WHEN JOB_TRAFFIC_DET.HOURS_ASSIGNED IS NULL OR JOB_TRAFFIC_DET.HOURS_ASSIGNED = 0 THEN JOB_TRAFFIC_DET.JOB_HRS
				ELSE JOB_TRAFFIC_DET.HOURS_ASSIGNED
		   END AS HoursAllowed,
		   JOB_TRAFFIC_DET.SEQ_NBR,
		   JOB_TRAFFIC_DET.JOB_NUMBER,
		   JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
	FROM   JOB_TRAFFIC_DET WITH(NOLOCK)
		   INNER JOIN JOB_TRAFFIC WITH(NOLOCK)
				ON  JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
				AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
		   INNER JOIN JOB_LOG WITH(NOLOCK)
				ON  JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER
		   INNER JOIN JOB_COMPONENT WITH(NOLOCK)
				ON  JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
		   INNER JOIN TRAFFIC WITH(NOLOCK)
				ON  JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE
	WHERE  (
			   (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
			   AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
		   )
		   AND JOB_LOG.JOB_NUMBER = @JobNo
		   AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp;


