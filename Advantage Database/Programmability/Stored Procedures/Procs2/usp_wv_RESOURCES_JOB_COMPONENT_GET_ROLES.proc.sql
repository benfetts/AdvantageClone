﻿
CREATE PROCEDURE [dbo].[usp_wv_RESOURCES_JOB_COMPONENT_GET_ROLES] 
        @JOB_NUMBER         AS INT,
        @JOB_COMPONENT_NBR  AS SMALLINT,
        @TASK_TYPE AS SMALLINT -- 0 = EVENT TASKS, 1 = PROJECT SCHEDULE (TRAFFIC) TASKS
AS

		--DISTINCT LIST OF ROLES FOR DROPDOWN:
		IF @TASK_TYPE = 0
		BEGIN
				SELECT     
					DISTINCT TASK_TRAFFIC_ROLE.ROLE_CODE AS TRF_ROLE_CODES, TRAFFIC_ROLE.ROLE_DESC
				FROM         
					TASK_TRAFFIC_ROLE WITH(NOLOCK) INNER JOIN
					TRAFFIC_ROLE WITH(NOLOCK) ON TASK_TRAFFIC_ROLE.ROLE_CODE = TRAFFIC_ROLE.ROLE_CODE
				WHERE     
					(TASK_TRAFFIC_ROLE.TRF_CODE IN (SELECT     DISTINCT EVENT_TASK.TASK_CODE
													FROM         EVENT_TASK WITH(NOLOCK) INNER JOIN
																		  EVENT WITH(NOLOCK) ON EVENT_TASK.EVENT_ID = EVENT.EVENT_ID
													WHERE     (EVENT.JOB_NUMBER = @JOB_NUMBER) AND (EVENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)))
				ORDER BY TASK_TRAFFIC_ROLE.ROLE_CODE
		END
        IF @TASK_TYPE = 1
        BEGIN
				SELECT     
					DISTINCT TASK_TRAFFIC_ROLE.ROLE_CODE AS TRF_ROLE_CODES, TRAFFIC_ROLE.ROLE_DESC
				FROM         
					TASK_TRAFFIC_ROLE WITH(NOLOCK) INNER JOIN
					TRAFFIC_ROLE WITH(NOLOCK) ON TASK_TRAFFIC_ROLE.ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = TRAFFIC_ROLE.ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
				WHERE     
					(TASK_TRAFFIC_ROLE.TRF_CODE IN (
													SELECT
														   DISTINCT
														   JOB_TRAFFIC_DET.FNC_CODE
													FROM   JOB_TRAFFIC_DET WITH(NOLOCK)
														   LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS WITH(NOLOCK)
																ON  JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER
																	AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR
																	AND JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR
													WHERE  (JOB_TRAFFIC_DET.JOB_NUMBER = @JOB_NUMBER)
														   AND (JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
														   AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  IS NULL)
					))
				ORDER BY TASK_TRAFFIC_ROLE.ROLE_CODE	
        END







