
CREATE PROCEDURE [dbo].[usp_wv_validate_JobIsViewable]
@JobNum INT,
@UserID VARCHAR(100)	
AS
	DECLARE @ThisReturn INT, @Restricted INT

	SELECT @Restricted = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

	SELECT @ThisReturn = 0

	IF @Restricted > 0	
	
		SELECT DISTINCT 
			@ThisReturn = ISNULL(JOB_LOG.JOB_NUMBER, 0)
		FROM JOB_LOG INNER JOIN
			JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
			SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
			JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
		WHERE     
			(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) 
			AND JOB_LOG.JOB_NUMBER = @JobNum 
 			AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) 

	ELSE
		SELECT DISTINCT 
			@ThisReturn = ISNULL(JOB_LOG.JOB_NUMBER,0)
		FROM         
			JOB_LOG INNER JOIN
			JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
		WHERE     
			(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12))
			-- IF ZERO IS RETURNED, THEN JOB IS CLOSED, if return value is same as 
			-- passed in value, job is open
			AND JOB_LOG.JOB_NUMBER = @JobNum

	
	SELECT ISNULL(@ThisReturn,0)

