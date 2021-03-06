IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_Get_Alert_EmailRecipients]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_Get_Alert_EmailRecipients]
GO
CREATE PROCEDURE [dbo].[usp_Get_Alert_EmailRecipients] 
@AlertID INT
AS
/*=========== QUERY ===========*/
BEGIN
   
	DECLARE @RECIPIENTS TABLE (RecipientAlertID INT, 
							   RecipientID INT,
							   RecipientEmployeeCode VARCHAR(6),
							   RecipientEmailAddress VARCHAR(500),
						 	   RecipientEmployeeName VARCHAR(1000),
							   EmployeeCode VARCHAR(6),
							   EmployeeEmail VARCHAR(1500),
							   MailBeeTitle VARCHAR(5000),
							   IsAssignee BIT,
							   IsCC BIT,
							   IsClientPortal BIT,
							   IsCurrentRecipient BIT,
							   SendEmail BIT,
							   IsTaskEmployee BIT)

	DECLARE
	  @IS_TASK BIT,
	  @IS_ROUTED BIT,
	  @IS_WORK_ITEM BIT,
	  @IS_PROOF BIT

	SELECT
		@IS_WORK_ITEM = ISNULL(A.IS_WORK_ITEM, 0),
		@IS_PROOF =	CASE
						WHEN A.ALERT_CAT_ID = 79 THEN CAST(1 AS BIT)
						ELSE CAST(0 AS BIT)	
					END,
		@IS_TASK =	CASE
						WHEN NOT JOB_NUMBER IS NULL AND NOT JOB_COMPONENT_NBR IS NULL AND NOT TASK_SEQ_NBR IS NULL AND ALERT_LEVEL = 'BRD' AND IS_WORK_ITEM = 1 THEN CAST(1 AS BIT)
						ELSE CAST(0 AS BIT)	
					END,
		@IS_ROUTED =	CASE
							WHEN NOT A.ALRT_NOTIFY_HDR_ID IS NULL AND A.ALRT_NOTIFY_HDR_ID > 0 THEN CAST(1 AS BIT)
							ELSE CAST(0 AS BIT)	
						END
	FROM
		ALERT A WITH(NOLOCK)
	WHERE
		A.ALERT_ID = @AlertID;

	INSERT INTO @RECIPIENTS
	SELECT
		RecipientAlertID = A.Rcpt_AlertID,
		RecipientID = A.Rcpt_RcptID,
		RecipientEmployeeCode = A.Rcpt_EmpCodeName,
		RecipientEmailAddress = A.Rcpt_EmailAddress,
		RecipientEmployeeName = A.Rcpt_EmpName,
		EmployeeCode = A.EMP_CODE,
		EmployeeEmail = A.EMP_EMAIL,
		MailBeeTitle = A.MAILBEE_TITLE,
		IsAssignee = CAST(A.CURRENT_NOTIFY AS BIT),
		IsCC = NULL,
		IsClientPortal = A.IsClientPortalUser,
		IsCurrentRecipient = A.CurrentRecipient,
		SendEmail = A.SendEmail,
		ISNULL(A.IsTaskEmployee, 0)
	FROM
	(
		SELECT 
			 ALERT_RCPT.ALERT_ID AS Rcpt_AlertID,
			 ALERT_RCPT.ALERT_RCPT_ID AS Rcpt_RcptID,
			 ALERT_RCPT.EMP_CODE AS Rcpt_EmpCodeName,
			 EMPLOYEE.EMP_EMAIL AS Rcpt_EmailAddress,
			 ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS Rcpt_EmpName,
			 ALERT_RCPT.EMP_CODE, 
			 EMPLOYEE.EMP_EMAIL,
			 ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + EMPLOYEE.EMP_EMAIL + '>' AS MAILBEE_TITLE,
			 ISNULL(ALERT_RCPT.CURRENT_NOTIFY, 0) AS CURRENT_NOTIFY,
			 CAST(0 AS BIT) AS IsClientPortalUser,
			 CASE
				WHEN CURRENT_RCPT = 1 THEN CAST(0 AS BIT)
				ELSE CAST(1 AS BIT)
			 END AS CurrentRecipient,
			 CASE
				WHEN EMPLOYEE.ALERT_EMAIL = 3 THEN CAST(1 AS BIT)
				ELSE CAST(0 AS BIT)
			 END AS SendEmail,
			 0 AS IsTaskEmployee
		FROM  
			ALERT_RCPT WITH(NOLOCK)
			LEFT OUTER JOIN EMPLOYEE WITH(NOLOCK) ON ALERT_RCPT.EMP_CODE = EMPLOYEE.EMP_CODE
		WHERE 
			(EMPLOYEE.ALERT_EMAIL = 1 OR EMPLOYEE.ALERT_EMAIL = 2 OR EMPLOYEE.ALERT_EMAIL = 3)
			AND (EMPLOYEE.EMP_TERM_DATE IS NULL)
			AND (ALERT_RCPT.ALERT_ID = @AlertID)
			AND (ALERT_RCPT.CURRENT_RCPT = 0 OR ALERT_RCPT.CURRENT_RCPT IS NULL)
	UNION
		SELECT 
			 ALERT_RCPT_DISMISSED.ALERT_ID AS Rcpt_AlertID,
			 ALERT_RCPT_DISMISSED.ALERT_RCPT_ID AS Rcpt_RcptID,
			 ALERT_RCPT_DISMISSED.EMP_CODE AS Rcpt_EmpCodeName,
			 EMPLOYEE.EMP_EMAIL AS Rcpt_EmailAddress,
			 ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS Rcpt_EmpName,
			 ALERT_RCPT_DISMISSED.EMP_CODE, 
			 EMPLOYEE.EMP_EMAIL,
			 ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + EMPLOYEE.EMP_EMAIL + '>' AS MAILBEE_TITLE,
			 ISNULL(ALERT_RCPT_DISMISSED.CURRENT_NOTIFY, 0) AS CURRENT_NOTIFY,
			 CAST(0 AS BIT) AS IsClientPortalUser,
			 CASE
				WHEN CURRENT_RCPT = 1 THEN CAST(0 AS BIT)
				ELSE CAST(1 AS BIT)
			 END AS CurrentRecipient,
			 CASE
				WHEN EMPLOYEE.ALERT_EMAIL = 3 THEN CAST(1 AS BIT)
				ELSE CAST(0 AS BIT)
			 END AS SendEmail,
			 0 AS IsTaskEmployee
		FROM  
			ALERT_RCPT_DISMISSED WITH(NOLOCK)
			LEFT OUTER JOIN EMPLOYEE WITH(NOLOCK) ON ALERT_RCPT_DISMISSED.EMP_CODE = EMPLOYEE.EMP_CODE
		WHERE 
			(EMPLOYEE.ALERT_EMAIL = 1 OR EMPLOYEE.ALERT_EMAIL = 2 OR EMPLOYEE.ALERT_EMAIL = 3)
			AND (EMPLOYEE.EMP_TERM_DATE IS NULL)
			AND (ALERT_RCPT_DISMISSED.ALERT_ID = @AlertID)
			AND (ALERT_RCPT_DISMISSED.CURRENT_RCPT = 0 OR ALERT_RCPT_DISMISSED.CURRENT_RCPT IS NULL)
	UNION
		SELECT 
			 A.ALERT_ID AS Rcpt_AlertID,
			 0 AS Rcpt_RcptID,
			 JTDE.EMP_CODE AS Rcpt_EmpCodeName,
			 E.EMP_EMAIL AS Rcpt_EmailAddress,
			 ISNULL(E.EMP_FNAME+' ', '') + ISNULL(E.EMP_MI+'. ', '') + ISNULL(E.EMP_LNAME, '') AS Rcpt_EmpName,
			 JTDE.EMP_CODE, 
			 E.EMP_EMAIL,
			 ISNULL(E.EMP_FNAME+' ', '') + ISNULL(E.EMP_MI+'. ', '') + ISNULL(E.EMP_LNAME, '') + ' <' + E.EMP_EMAIL + '>' AS MAILBEE_TITLE,
			 1 AS CURRENT_NOTIFY,
			 CAST(0 AS BIT) AS IsClientPortalUser,
			 CAST(1 AS BIT) AS CurrentRecipient,
			 CASE
				WHEN E.ALERT_EMAIL = 3 THEN CAST(1 AS BIT)
				ELSE CAST(0 AS BIT)
			 END AS SendEmail,
			 1 AS IsTaskEmployee
		FROM  
			JOB_TRAFFIC_DET_EMPS JTDE WITH(NOLOCK)
			INNER JOIN ALERT A WITH(NOLOCK) ON JTDE.JOB_NUMBER = A.JOB_NUMBER AND JTDE.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR AND JTDE.SEQ_NBR = A.TASK_SEQ_NBR
			INNER JOIN EMPLOYEE E WITH(NOLOCK) ON JTDE.EMP_CODE = E.EMP_CODE
		WHERE 
			(E.ALERT_EMAIL = 1 OR E.ALERT_EMAIL = 2 OR E.ALERT_EMAIL = 3)
			AND (E.EMP_TERM_DATE IS NULL)
			AND (A.ALERT_ID = @AlertID)
			AND (@IS_TASK = 1)
  UNION
		SELECT 
			CP_ALERT_RCPT.ALERT_ID AS Rcpt_AlertID,
			CP_ALERT_RCPT.ALERT_RCPT_ID AS Rcpt_RcptID,
			CAST(CP_ALERT_RCPT.CDP_CONTACT_ID AS VARCHAR) AS Rcpt_EmpCodeName,
			CDP_CONTACT_HDR.EMAIL_ADDRESS AS Rcpt_EmailAddress,
			CDP_CONTACT_HDR.CONT_FML AS Rcpt_EmpName,
			CAST(CP_ALERT_RCPT.CDP_CONTACT_ID AS VARCHAR),
			CDP_CONTACT_HDR.EMAIL_ADDRESS,
			CDP_CONTACT_HDR.CONT_FML + ' <' + CDP_CONTACT_HDR.EMAIL_ADDRESS + '>' AS MAILBEE_TITLE,
			CAST(0 AS BIT) AS CURRENT_NOTIFY,
			CAST(1 AS BIT) AS IsClientPortalUser,
			CASE
				WHEN CURRENT_RCPT = 1 THEN CAST(0 AS BIT)
				ELSE CAST(1 AS BIT)
			END AS CurrentRecipient,
			CASE  
				WHEN CDP_CONTACT_HDR.EMAIL_RCPT = 1 THEN CAST(1 AS BIT)
				ELSE CAST(0 AS BIT)
			END AS SendEmail,
			0 AS IsTaskEmployee
		FROM  
			CP_ALERT_RCPT WITH(NOLOCK)
			INNER JOIN CDP_CONTACT_HDR WITH(NOLOCK) ON CP_ALERT_RCPT.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
		WHERE 
			(CP_ALERT_RCPT.ALERT_ID = @AlertID)
			AND (CDP_CONTACT_HDR.CP_USER = 1)
			AND (CDP_CONTACT_HDR.EMAIL_RCPT = 1)
			AND (NOT (CDP_CONTACT_HDR.EMAIL_ADDRESS IS NULL))
			AND (CP_ALERT_RCPT.CURRENT_RCPT = 0 OR CP_ALERT_RCPT.CURRENT_RCPT IS NULL)
	UNION
		SELECT 
			CP_ALERT_RCPT_DISMISSED.ALERT_ID AS Rcpt_AlertID,
			CP_ALERT_RCPT_DISMISSED.ALERT_RCPT_ID AS Rcpt_RcptID,
			CAST(CP_ALERT_RCPT_DISMISSED.CDP_CONTACT_ID AS VARCHAR) AS Rcpt_EmpCodeName,
			CDP_CONTACT_HDR.EMAIL_ADDRESS AS Rcpt_EmailAddress,
			CDP_CONTACT_HDR.CONT_FML AS Rcpt_EmpName,
			CAST(CP_ALERT_RCPT_DISMISSED.CDP_CONTACT_ID AS VARCHAR),
			CDP_CONTACT_HDR.EMAIL_ADDRESS,
			CDP_CONTACT_HDR.CONT_FML + ' <' + CDP_CONTACT_HDR.EMAIL_ADDRESS + '>' AS MAILBEE_TITLE,
			CAST(0 AS BIT) AS CURRENT_NOTIFY,
			CAST(1 AS BIT) AS IsClientPortalUser,
			CASE
				WHEN CURRENT_RCPT = 1 THEN CAST(0 AS BIT)
				ELSE CAST(1 AS BIT)
			END AS CurrentRecipient,
			CASE  
				WHEN CDP_CONTACT_HDR.EMAIL_RCPT = 1 THEN CAST(1 AS BIT)
				ELSE CAST(0 AS BIT)
			END AS SendEmail,
		    0 AS IsTaskEmployee
		FROM  
			CP_ALERT_RCPT_DISMISSED WITH(NOLOCK)
			INNER JOIN CDP_CONTACT_HDR WITH(NOLOCK) ON CP_ALERT_RCPT_DISMISSED.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
		WHERE 
			(CP_ALERT_RCPT_DISMISSED.ALERT_ID = @AlertID)
			AND (CDP_CONTACT_HDR.CP_USER = 1)
			AND (CDP_CONTACT_HDR.EMAIL_RCPT = 1)
			AND (NOT (CDP_CONTACT_HDR.EMAIL_ADDRESS IS NULL))
			AND (CP_ALERT_RCPT_DISMISSED.CURRENT_RCPT = 0 OR CP_ALERT_RCPT_DISMISSED.CURRENT_RCPT IS NULL)		
	) AS A
	INNER JOIN ALERT ON A.Rcpt_AlertID = ALERT.ALERT_ID
	ORDER BY 
	  IsAssignee DESC, 
	  IsCC, 
	  IsClientPortal, 
	  RecipientEmployeeName ASC;

	IF @IS_ROUTED IS NULL OR @IS_ROUTED = 0
	BEGIN
		UPDATE @RECIPIENTS SET IsAssignee = CAST(1 AS BIT)
		FROM
			@RECIPIENTS R
			INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON R.RecipientAlertID = AR.ALERT_ID AND R.EmployeeCode = AR.EMP_CODE AND AR.ALERT_RCPT_ID = R.RecipientID
		WHERE
			AR.CURRENT_NOTIFY = 1;
		IF @IS_PROOF = 1
		BEGIN
			DELETE @RECIPIENTS
			FROM
				ALERT_RCPT_DISMISSED ARD WITH(NOLOCK)
				INNER JOIN @RECIPIENTS R ON ARD.EMP_CODE = R.EmployeeCode
			WHERE
				ARD.ALERT_ID = @AlertID
				AND ARD.PROOFING_STATUS_ID IS NOT NULL
				AND ARD.CURRENT_NOTIFY = 1
			;
		END
	END
	ELSE
	BEGIN
		UPDATE @RECIPIENTS SET IsAssignee = 0;
		UPDATE @RECIPIENTS SET IsAssignee = CAST(1 AS BIT)
		FROM
			@RECIPIENTS R
			INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON R.RecipientAlertID = AR.ALERT_ID AND R.EmployeeCode = AR.EMP_CODE AND AR.ALERT_RCPT_ID = R.RecipientID
			INNER JOIN ALERT A WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = AR.ALRT_NOTIFY_HDR_ID AND A.ALERT_STATE_ID = AR.ALERT_STATE_ID
		WHERE
			AR.CURRENT_NOTIFY = 1;
	END	
	UPDATE @RECIPIENTS SET IsAssignee = 0 WHERE IsAssignee IS NULL;

	UPDATE @RECIPIENTS SET IsCC = CAST(1 AS BIT)
	FROM
		@RECIPIENTS R
		INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON R.RecipientAlertID = AR.ALERT_ID AND R.EmployeeCode = AR.EMP_CODE AND AR.ALERT_RCPT_ID = R.RecipientID
	WHERE
		(AR.CURRENT_NOTIFY IS NULL OR AR.CURRENT_NOTIFY = 0);
	UPDATE @RECIPIENTS SET IsCC = 0 WHERE IsCC IS NULL;

	SELECT 
		RecipientAlertID, 
		RecipientID,
		RecipientEmployeeCode,
		RecipientEmailAddress,
		RecipientEmployeeName,
		EmployeeCode,
		EmployeeEmail,
		MailBeeTitle,
		IsAssignee,
		IsCC,
		IsClientPortal,
		IsCurrentRecipient,
		SendEmail,
		IsTaskEmployee 		
	FROM
		@RECIPIENTS;

END
/*=========== QUERY ===========*/

