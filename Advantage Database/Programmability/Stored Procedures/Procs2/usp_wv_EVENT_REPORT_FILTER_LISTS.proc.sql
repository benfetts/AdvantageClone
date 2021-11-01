﻿
CREATE PROCEDURE [dbo].[usp_wv_EVENT_REPORT_FILTER_LISTS] 
	@USER_CODE AS VARCHAR(100)

AS
    DECLARE
	    @RESTRICTED AS INT, @OfficeCount AS INTEGER, @EMP_CODE VARCHAR(6), @RESTRICTED_EMP AS INT;
	
	    SELECT @RESTRICTED = ISNULL(COUNT(1),0) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@USER_CODE);
		SELECT @RESTRICTED_EMP = ISNULL(COUNT(1),0) FROM SEC_EMP WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@USER_CODE);

		SELECT @EMP_CODE = EMP_CODE
		FROM SEC_USER WITH(NOLOCK)
		WHERE UPPER(USER_CODE) = UPPER(@USER_CODE);

		SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;

	    --OFFICES THAT HAVE JOBS THAT HAVE EVENTS
		If @OfficeCount > 0
		BEGIN
			SELECT
				DISTINCT OFFICE.OFFICE_CODE AS CODE, OFFICE.OFFICE_CODE+' - '+ISNULL(OFFICE.OFFICE_NAME,'N/A') AS DESCRIPTION
			FROM
				OFFICE INNER JOIN
				JOB_LOG ON OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE INNER JOIN
				EVENT ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			WHERE (OFFICE.INACTIVE_FLAG IS NULL OR OFFICE.INACTIVE_FLAG = 0)
			ORDER BY
				OFFICE.OFFICE_CODE;				
		END
		ELSE
		BEGIN
			SELECT
				DISTINCT OFFICE.OFFICE_CODE AS CODE, OFFICE.OFFICE_CODE+' - '+ISNULL(OFFICE.OFFICE_NAME,'N/A') AS DESCRIPTION
			FROM
				OFFICE INNER JOIN
				JOB_LOG ON OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE INNER JOIN
				EVENT ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER
			WHERE (OFFICE.INACTIVE_FLAG IS NULL OR OFFICE.INACTIVE_FLAG = 0)
			ORDER BY
				OFFICE.OFFICE_CODE;	

		END
	    

	    --CDP'S THAT HAVE JOBS THAT HAVE EVENTS
		    IF @RESTRICTED > 0
			    BEGIN
					If @OfficeCount > 0
					BEGIN
						SELECT 
							ISNULL(A.CL_CODE, '') +'|'+ ISNULL(A.DIV_CODE, '')  +'|'+  ISNULL(A.PRD_CODE, '') AS CODE,
							ISNULL(A.CL_CODE+' | ', '') + ISNULL(A.DIV_CODE+' | ', '')  +  ISNULL(A.PRD_CODE, '') + ' - ' + ISNULL(A.PRD_DESCRIPTION,'N/A') AS DESCRIPTION
						FROM
						(
							SELECT 
								DISTINCT TOP 100 PERCENT
								ISNULL(CLIENT.CL_CODE, '') + ISNULL(DIVISION.DIV_CODE, '') + ISNULL(PRODUCT.PRD_CODE, '') AS DISTINCTION, 
								CLIENT.CL_CODE, CLIENT.CL_NAME, DIVISION.DIV_CODE, DIVISION.DIV_NAME, PRODUCT.PRD_CODE, PRODUCT.PRD_DESCRIPTION
							FROM         
								JOB_LOG INNER JOIN
								CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
								DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
								PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
								JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE AND DIVISION.CL_CODE = PRODUCT.CL_CODE AND 
								DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
								EVENT ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER INNER JOIN
								SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
								JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
							WHERE     
								(UPPER(SEC_CLIENT.USER_ID) = UPPER(@USER_CODE)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
								AND (CLIENT.ACTIVE_FLAG = 1 OR CLIENT.ACTIVE_FLAG IS NULL)
								AND (DIVISION.ACTIVE_FLAG = 1 OR DIVISION.ACTIVE_FLAG IS NULL)
								AND (PRODUCT.ACTIVE_FLAG = 1 OR PRODUCT.ACTIVE_FLAG IS NULL)
							ORDER BY
								CLIENT.CL_CODE,DIVISION.DIV_CODE,PRODUCT.PRD_CODE
						) AS A					
					END
					ELSE
					BEGIN
						SELECT 
							ISNULL(A.CL_CODE, '') +'|'+ ISNULL(A.DIV_CODE, '')  +'|'+  ISNULL(A.PRD_CODE, '') AS CODE,
							ISNULL(A.CL_CODE+' | ', '') + ISNULL(A.DIV_CODE+' | ', '')  +  ISNULL(A.PRD_CODE, '') + ' - ' + ISNULL(A.PRD_DESCRIPTION,'N/A') AS DESCRIPTION
						FROM
						(
							SELECT 
								DISTINCT TOP 100 PERCENT
								ISNULL(CLIENT.CL_CODE, '') + ISNULL(DIVISION.DIV_CODE, '') + ISNULL(PRODUCT.PRD_CODE, '') AS DISTINCTION, 
								CLIENT.CL_CODE, CLIENT.CL_NAME, DIVISION.DIV_CODE, DIVISION.DIV_NAME, PRODUCT.PRD_CODE, PRODUCT.PRD_DESCRIPTION
							FROM         
								JOB_LOG INNER JOIN
								CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
								DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
								PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
								JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE AND DIVISION.CL_CODE = PRODUCT.CL_CODE AND 
								DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
								EVENT ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER INNER JOIN
								SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
								JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
							WHERE     
								(UPPER(SEC_CLIENT.USER_ID) = UPPER(@USER_CODE)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
								AND (CLIENT.ACTIVE_FLAG = 1 OR CLIENT.ACTIVE_FLAG IS NULL)
								AND (DIVISION.ACTIVE_FLAG = 1 OR DIVISION.ACTIVE_FLAG IS NULL)
								AND (PRODUCT.ACTIVE_FLAG = 1 OR PRODUCT.ACTIVE_FLAG IS NULL)
							ORDER BY
								CLIENT.CL_CODE,DIVISION.DIV_CODE,PRODUCT.PRD_CODE
						) AS A		

					END				    
			    END	
		    ELSE
			    BEGIN
					If @OfficeCount > 0
					BEGIN
						SELECT 
							ISNULL(A.CL_CODE, '') +'|'+ ISNULL(A.DIV_CODE, '')  +'|'+  ISNULL(A.PRD_CODE, '') AS CODE,
							ISNULL(A.CL_CODE+' | ', '') + ISNULL(A.DIV_CODE+' | ', '')  +  ISNULL(A.PRD_CODE, '') + ' - ' + ISNULL(A.PRD_DESCRIPTION,'N/A') AS DESCRIPTION
						FROM
						(
							SELECT 
								DISTINCT TOP 100 PERCENT
								ISNULL(CLIENT.CL_CODE, '') + ISNULL(DIVISION.DIV_CODE, '') + ISNULL(PRODUCT.PRD_CODE, '') AS DISTINCTION, 
								CLIENT.CL_CODE, CLIENT.CL_NAME, DIVISION.DIV_CODE, DIVISION.DIV_NAME, PRODUCT.PRD_CODE, PRODUCT.PRD_DESCRIPTION
							FROM         
								JOB_LOG WITH(NOLOCK) INNER JOIN
								CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
								DIVISION WITH(NOLOCK) ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
								PRODUCT WITH(NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
								JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE AND DIVISION.CL_CODE = PRODUCT.CL_CODE AND 
								DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
								EVENT WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
							WHERE (CLIENT.ACTIVE_FLAG = 1 OR CLIENT.ACTIVE_FLAG IS NULL)
								AND (DIVISION.ACTIVE_FLAG = 1 OR DIVISION.ACTIVE_FLAG IS NULL)
								AND (PRODUCT.ACTIVE_FLAG = 1 OR PRODUCT.ACTIVE_FLAG IS NULL)
							ORDER BY
								CLIENT.CL_CODE,DIVISION.DIV_CODE,PRODUCT.PRD_CODE
						) AS A				
					END
					ELSE
					BEGIN
						SELECT 
							ISNULL(A.CL_CODE, '') +'|'+ ISNULL(A.DIV_CODE, '')  +'|'+  ISNULL(A.PRD_CODE, '') AS CODE,
							ISNULL(A.CL_CODE+' | ', '') + ISNULL(A.DIV_CODE+' | ', '')  +  ISNULL(A.PRD_CODE, '') + ' - ' + ISNULL(A.PRD_DESCRIPTION,'N/A') AS DESCRIPTION
						FROM
						(
							SELECT 
								DISTINCT TOP 100 PERCENT
								ISNULL(CLIENT.CL_CODE, '') + ISNULL(DIVISION.DIV_CODE, '') + ISNULL(PRODUCT.PRD_CODE, '') AS DISTINCTION, 
								CLIENT.CL_CODE, CLIENT.CL_NAME, DIVISION.DIV_CODE, DIVISION.DIV_NAME, PRODUCT.PRD_CODE, PRODUCT.PRD_DESCRIPTION
							FROM         
								JOB_LOG WITH(NOLOCK) INNER JOIN
								CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
								DIVISION WITH(NOLOCK) ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
								PRODUCT WITH(NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
								JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE AND DIVISION.CL_CODE = PRODUCT.CL_CODE AND 
								DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
								EVENT WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER
							WHERE (CLIENT.ACTIVE_FLAG = 1 OR CLIENT.ACTIVE_FLAG IS NULL)
								AND (DIVISION.ACTIVE_FLAG = 1 OR DIVISION.ACTIVE_FLAG IS NULL)
								AND (PRODUCT.ACTIVE_FLAG = 1 OR PRODUCT.ACTIVE_FLAG IS NULL)
							ORDER BY
								CLIENT.CL_CODE,DIVISION.DIV_CODE,PRODUCT.PRD_CODE
						) AS A			
					END			
				    
			    END

	    --RESOURCES THAT HAVE EVENTS
	    SELECT
		    B.RESOURCE_CODE AS CODE, B.RESOURCE_CODE+' - '+ISNULL(B.RESOURCE_DESC,'N/A') AS DESCRIPTION
	    FROM
	    (	
			    SELECT     
				    DISTINCT TOP 100 PERCENT
					    RESOURCE_TYPE.RESOURCE_TYPE_CODE+RESOURCE.RESOURCE_CODE AS DISTINCTION, 
					    RESOURCE.RESOURCE_CODE, RESOURCE.RESOURCE_DESC
			    FROM         
				    RESOURCE_TYPE WITH(NOLOCK) INNER JOIN
				    RESOURCE WITH(NOLOCK) ON RESOURCE_TYPE.RESOURCE_TYPE_CODE = RESOURCE.RESOURCE_TYPE_CODE LEFT OUTER JOIN
				    EVENT WITH(NOLOCK) ON RESOURCE.RESOURCE_CODE = EVENT.RESOURCE_CODE
			    WHERE
					(RESOURCE.INACTIVE_FLAG = 0 OR RESOURCE.INACTIVE_FLAG IS NULL)   
	    ) AS B;			


	    --Event TASK level uses TRAFFIC_FNC
	    SELECT     
		    DISTINCT TRAFFIC_FNC.TRF_CODE AS CODE, TRAFFIC_FNC.TRF_CODE+' - '+ISNULL(TRAFFIC_FNC.TRF_DESC,'N/A') AS DESCRIPTION
	    FROM         
		    TRAFFIC_FNC WITH(NOLOCK) INNER JOIN
		    EVENT_TASK WITH(NOLOCK) ON TRAFFIC_FNC.TRF_CODE = EVENT_TASK.TASK_CODE	
	    WHERE
			(TRAFFIC_FNC.TRF_INACTIVE = 0 OR TRAFFIC_FNC.TRF_INACTIVE IS NULL)    
	    ORDER BY
		    TRF_CODE;	

	    --Event level uses FUNCTION
    	SELECT 
			FNC_CODE AS CODE, 
			FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') AS [DESCRIPTION]
		FROM
			FUNCTIONS WITH(NOLOCK)
		WHERE 
			((FNC_INACTIVE IS NULL ) OR (FNC_INACTIVE = 0)) AND (FNC_TYPE = 'I')
		ORDER BY FNC_CODE;    
		
	    --EMPLOYEES THAT HAVE EVENTS (TASKS)	
	    IF @RESTRICTED_EMP > 0
		    BEGIN
				If @OfficeCount > 0
					BEGIN
						 SELECT     
							DISTINCT EMPLOYEE.EMP_CODE AS CODE, 
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'')
								ELSE EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'') + ' (Terminated)'
							END AS [DESCRIPTION],
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN 1
								ELSE 0
							END AS ACTIVE_EMP
						FROM         
							EMPLOYEE WITH(NOLOCK) INNER JOIN
							EVENT_TASK WITH(NOLOCK) ON EMPLOYEE.EMP_CODE = EVENT_TASK.EMP_CODE INNER JOIN
							[dbo].[advtf_sec_emp] (@USER_CODE) AS SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
						WHERE     
							(EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE())
						ORDER BY
							ACTIVE_EMP DESC,
							[DESCRIPTION];
					END
					ELSE
					BEGIN
						 SELECT     
							DISTINCT EMPLOYEE.EMP_CODE AS CODE, 
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'')
								ELSE EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'') + ' (Terminated)'
							END AS [DESCRIPTION],
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN 1
								ELSE 0
							END AS ACTIVE_EMP
						FROM         
							EMPLOYEE WITH(NOLOCK) INNER JOIN
							EVENT_TASK WITH(NOLOCK) ON EMPLOYEE.EMP_CODE = EVENT_TASK.EMP_CODE INNER JOIN
							[dbo].[advtf_sec_emp] (@USER_CODE) AS SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE
						WHERE     
							(EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE())
						ORDER BY
							ACTIVE_EMP DESC,
							[DESCRIPTION];
					END
			   
		    END
	    ELSE
		    BEGIN
				If @OfficeCount > 0
					BEGIN
						SELECT     
							DISTINCT EMPLOYEE.EMP_CODE AS CODE, 
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'')
								ELSE EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'') + ' (Terminated)'
							END AS [DESCRIPTION],
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN 1
								ELSE 0
							END AS ACTIVE_EMP
						FROM         
							EMPLOYEE WITH(NOLOCK) INNER JOIN
							EVENT_TASK WITH(NOLOCK) ON EMPLOYEE.EMP_CODE = EVENT_TASK.EMP_CODE INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
						WHERE  (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE())
						ORDER BY
							ACTIVE_EMP DESC,
							[DESCRIPTION];
					END
					ELSE
					BEGIN
						SELECT     
							DISTINCT EMPLOYEE.EMP_CODE AS CODE, 
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'')
								ELSE EMPLOYEE.EMP_CODE+' - '+ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'') + ' (Terminated)'
							END AS [DESCRIPTION],
							CASE
								WHEN (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE()) THEN 1
								ELSE 0
							END AS ACTIVE_EMP
						FROM         
							EMPLOYEE WITH(NOLOCK) INNER JOIN
							EVENT_TASK WITH(NOLOCK) ON EMPLOYEE.EMP_CODE = EVENT_TASK.EMP_CODE
						WHERE  (EMPLOYEE.EMP_TERM_DATE IS NULL) OR (EMPLOYEE.EMP_TERM_DATE > GETDATE())
						ORDER BY
							ACTIVE_EMP DESC,
							[DESCRIPTION];
					END
			    
		    END	
