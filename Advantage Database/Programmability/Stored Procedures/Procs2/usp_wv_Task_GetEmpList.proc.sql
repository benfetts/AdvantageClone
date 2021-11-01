﻿

CREATE PROCEDURE [dbo].[usp_wv_Task_GetEmpList]
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR INT,
@SEQ_NBR SMALLINT,
@EMP_CODE varchar(6)
AS

        SELECT     
            JOB_TRAFFIC_DET_EMPS.ID, 
            JOB_TRAFFIC_DET_EMPS.JOB_NUMBER, 
            JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR, 
            JOB_TRAFFIC_DET_EMPS.SEQ_NBR, 
            JOB_TRAFFIC_DET_EMPS.EMP_CODE, 
            ISNULL(EMPLOYEE.EMP_FNAME + ' ', '')+ ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_NAME, 
            ISNULL(JOB_TRAFFIC_DET_EMPS.HOURS_ALLOWED, 0) AS HOURS_ALLOWED, ISNULL(JOB_TRAFFIC_DET_EMPS.TEMP_COMP_DATE, '') AS TEMP_COMP_DATE
        FROM         
            JOB_TRAFFIC_DET_EMPS LEFT OUTER JOIN
            EMPLOYEE ON JOB_TRAFFIC_DET_EMPS.EMP_CODE = EMPLOYEE.EMP_CODE
        WHERE     
                    ((JOB_TRAFFIC_DET_EMPS.JOB_NUMBER = @JOB_NUMBER) 
                    AND (JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR) 
                    AND (JOB_TRAFFIC_DET_EMPS.SEQ_NBR = @SEQ_NBR))
					AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE <> @EMP_CODE)



