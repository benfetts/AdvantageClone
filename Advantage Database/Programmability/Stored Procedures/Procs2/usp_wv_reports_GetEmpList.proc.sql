

CREATE PROCEDURE [dbo].[usp_wv_reports_GetEmpList]
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR INT,
@SEQ SMALLINT
AS

        SELECT     
            JOB_NUMBER, 
            JOB_COMPONENT_NBR, 
            SEQ_NBR, 
            EMP_CODE_LIST, 
            EMP_LNAME_LIST, 
            EMP_LFI_LIST
        FROM         
            V_JOB_TRAFFIC_DET_EMPS 
        WHERE 
		      ((JOB_NUMBER = @JOB_NUMBER) 
                    AND (JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR) 
                    AND (SEQ_NBR = @SEQ))



