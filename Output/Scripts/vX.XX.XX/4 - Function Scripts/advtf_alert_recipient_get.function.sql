IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advtf_alert_recipient_get]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advtf_alert_recipient_get]
END
GO

CREATE FUNCTION [dbo].[advtf_alert_recipient_get] (
@ALERT_ID INT
)
RETURNS
@RETURN_TABLE TABLE (
    [AlertID] INT,
    [ID] INT,
    [EmployeeCode] VARCHAR(6),
    [EmployeeEmail] VARCHAR(50),
    [EmployeeFullName] VARCHAR(80),
    [IsCurrentRecipient] BIT,
    [IsCurrentNotify] BIT,
    [IsTaskEmployee] BIT,
    [IsTaskTempComplete] BIT,
    [EmployeeImage] IMAGE,
	[ClientContactID] INT,
	[IsClientContact] BIT,
	[CompletedDismissed] BIT,
	[AlertTemplateID] INT,
	[AlertStateID] INT,
	[CurrentStateCompleted] BIT,
	[IsCurrentAssignee] BIT
)
AS
BEGIN
    /***** QUERY *****/
    BEGIN

		DECLARE
			@ALERT_CAT_ID INT,
			@ROUTED_SINGLE_ASSIGNEE_EMP_CODE VARCHAR(6),
			@CURR_ALRT_NOTIFY_HDR_ID INT,
			@CURR_ALERT_STATE_ID INT

		SELECT
			@ALERT_CAT_ID = ISNULL(ALERT_CAT_ID, 0),
			@ROUTED_SINGLE_ASSIGNEE_EMP_CODE = ASSIGNED_EMP_CODE,
			@CURR_ALRT_NOTIFY_HDR_ID = ALRT_NOTIFY_HDR_ID,
			@CURR_ALERT_STATE_ID = ALERT_STATE_ID
		FROM 
			ALERT A WITH(NOLOCK) 
		WHERE 
			ALERT_ID = @ALERT_ID;

		-- EMPLOYEES:  ASSIGNMENT OR TASK
		IF @ALERT_CAT_ID <> 71
		BEGIN
			--	GET ALL
			INSERT INTO @RETURN_TABLE(AlertID, ID, EmployeeCode, EmployeeEmail, IsCurrentRecipient, IsCurrentNotify, IsTaskEmployee, CompletedDismissed, EmployeeFullName, AlertTemplateID, AlertStateID)
			SELECT
				[AlertID] = AR.ALERT_ID,
				[AlertRecipientID] = AR.ALERT_RCPT_ID,
				[EmployeeCode] = AR.EMP_CODE,
				[EmployeeEmail] = E.EMP_EMAIL,
				[IsCurrentRecipient] = AR.CURRENT_RCPT, -- 1 = no, 0 = yes
				[IsCurrentNotify] = ISNULL(AR.CURRENT_NOTIFY, 0),
				[IsTaskEmployee] = 0,
				[CompletedDismissed] = 0,
				[EmployeeFullName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				[AlertTemplateID] = AR.ALRT_NOTIFY_HDR_ID,
				[AlertStateID] = AR.ALERT_STATE_ID
			FROM
				ALERT_RCPT AR WITH(NOLOCK) 
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON AR.EMP_CODE = E.EMP_CODE
			WHERE
				AR.ALERT_ID = @ALERT_ID
			UNION
			SELECT
				[AlertID] = AR.ALERT_ID,
				[AlertRecipientID] = AR.ALERT_RCPT_ID,
				[EmployeeCode] = AR.EMP_CODE,
				[EmployeeEmail] = E.EMP_EMAIL,
				[IsCurrentRecipient] = AR.CURRENT_RCPT, -- 1 = no, 0 = yes
				[IsCurrentNotify] = ISNULL(AR.CURRENT_NOTIFY, 0),
				[IsTaskEmployee] = 0,
				[CompletedDismissed] = 1,
				[EmployeeFullName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				[AlertTemplateID] = AR.ALRT_NOTIFY_HDR_ID,
				[AlertStateID] = AR.ALERT_STATE_ID
			FROM
				ALERT_RCPT_DISMISSED AR WITH(NOLOCK) 
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON AR.EMP_CODE = E.EMP_CODE
			WHERE
				AR.ALERT_ID = @ALERT_ID	
		END
		ELSE
		BEGIN -- TASK
			INSERT INTO @RETURN_TABLE(AlertID, ID, EmployeeCode, EmployeeEmail, IsCurrentRecipient, IsCurrentNotify, IsTaskEmployee, CompletedDismissed, IsTaskTempComplete, EmployeeFullName)
			SELECT	--	ASSIGNEES ARE THE TASK EMPLOYEES
				[AlertID] = A.ALERT_ID,
				[AlertRecipientID] = -1,
				[EmployeeCode] = J.EMP_CODE,
				[EmployeeEmail] = E.EMP_EMAIL,
				[IsCurrentRecipient] = 1, -- 1 = no, 0 = yes
				[IsCurrentNotify] = 1,
				[IsTaskEmployee] = 1,
				[CompletedDismissed] = CASE
										  WHEN J.TEMP_COMP_DATE IS NULL THEN 0
										  ELSE 1
									   END,
				[IsTaskTempComplete] = CASE
										  WHEN J.TEMP_COMP_DATE IS NULL THEN 0
										  ELSE 1
									   END,
				[EmployeeFullName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM
				JOB_TRAFFIC_DET_EMPS J WITH(NOLOCK)
				INNER JOIN ALERT A WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER AND J.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR AND J.SEQ_NBR = A.TASK_SEQ_NBR
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON J.EMP_CODE = E.EMP_CODE
			WHERE
				A.ALERT_ID = @ALERT_ID     
			
			-- ONLY CC'S FROM THE RECIPIENT TABLES
			UNION
			SELECT
				[AlertID] = AR.ALERT_ID,
				[AlertRecipientID] = AR.ALERT_RCPT_ID,
				[EmployeeCode] = AR.EMP_CODE,
				[EmployeeEmail] = E.EMP_EMAIL,
				[IsCurrentRecipient] = AR.CURRENT_RCPT, -- 1 = no, 0 = yes
				[IsCurrentNotify] = ISNULL(AR.CURRENT_NOTIFY, 0),
				[IsTaskEmployee] = 0,
				[CompletedDismissed] = 0,
				[IsTaskTempComplete] = 0,
				[EmployeeFullName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM
				ALERT_RCPT AR WITH(NOLOCK) 
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON AR.EMP_CODE = E.EMP_CODE
			WHERE
				AR.ALERT_ID = @ALERT_ID
				AND (AR.CURRENT_NOTIFY IS NULL OR AR.CURRENT_NOTIFY = 0)
			UNION
			SELECT
				[AlertID] = AR.ALERT_ID,
				[AlertRecipientID] = AR.ALERT_RCPT_ID,
				[EmployeeCode] = AR.EMP_CODE,
				[EmployeeEmail] = E.EMP_EMAIL,
				[IsCurrentRecipient] = AR.CURRENT_RCPT, -- 1 = no, 0 = yes
				[IsCurrentNotify] = ISNULL(AR.CURRENT_NOTIFY, 0),
				[IsTaskEmployee] = 0,
				[CompletedDismissed] = 1,
				[IsTaskTempComplete] = 0,
				[EmployeeFullName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM
				ALERT_RCPT_DISMISSED AR WITH(NOLOCK) 
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON AR.EMP_CODE = E.EMP_CODE
			WHERE
				AR.ALERT_ID = @ALERT_ID	
		END

		UPDATE @RETURN_TABLE SET IsClientContact = 0;

		-- CLIENT CONTACTS
		BEGIN
			INSERT INTO @RETURN_TABLE(AlertID, ID, ClientContactID, EmployeeEmail, IsCurrentRecipient, IsCurrentNotify, IsTaskEmployee, CompletedDismissed, EmployeeFullName)
			SELECT
				[AlertID] = AR.ALERT_ID,
				[AlertRecipientID] = AR.ALERT_RCPT_ID,
				[ClientContactID] = C.CDP_CONTACT_ID,
				[EmployeeEmail] = C.EMAIL_ADDRESS,
				[IsCurrentRecipient] = AR.CURRENT_RCPT, -- 1 = no, 0 = yes
				[IsCurrentNotify] = ISNULL(AR.CURRENT_NOTIFY, 0),
				[IsTaskEmployee] = 0,
				[CompletedDismissed] = 0,
				[EmployeeFullName] = C.CONT_FML
			FROM
				CP_ALERT_RCPT AR WITH(NOLOCK) 
				INNER JOIN CDP_CONTACT_HDR C ON AR.CDP_CONTACT_ID = C.CDP_CONTACT_ID
			WHERE
				AR.ALERT_ID = @ALERT_ID
			UNION
			SELECT
				[AlertID] = AR.ALERT_ID,
				[AlertRecipientID] = AR.ALERT_RCPT_ID,
				[ClientContactID] = C.CDP_CONTACT_ID,
				[EmployeeEmail] = C.EMAIL_ADDRESS,
				[IsCurrentRecipient] = AR.CURRENT_RCPT, -- 1 = no, 0 = yes
				[IsCurrentNotify] = ISNULL(AR.CURRENT_NOTIFY, 0),
				[IsTaskEmployee] = 0,
				[CompletedDismissed] = 1,
				[EmployeeFullName] = C.CONT_FML
			FROM
				CP_ALERT_RCPT_DISMISSED AR WITH(NOLOCK) 
				INNER JOIN CDP_CONTACT_HDR C ON AR.CDP_CONTACT_ID = C.CDP_CONTACT_ID
			WHERE
				AR.ALERT_ID = @ALERT_ID	
            UNION            
			SELECT	--	ASSIGNEES ARE THE TASK EMPLOYEES
				[AlertID] = A.ALERT_ID,
				[AlertRecipientID] = -1,
				[ClientContactID] = J.CDP_CONTACT_ID,
				[EmployeeEmail] = C.EMAIL_ADDRESS,
				[IsCurrentRecipient] = 0, -- 1 = no, 0 = yes
				[IsCurrentNotify] = 0,
				[IsTaskEmployee] = 0,
				[CompletedDismissed] = 0,   
				[EmployeeFullName] = C.CONT_FML
			FROM
				JOB_TRAFFIC_DET_CNTS J WITH(NOLOCK)
				INNER JOIN ALERT A WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER AND J.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR AND J.SEQ_NBR = A.TASK_SEQ_NBR
				INNER JOIN CDP_CONTACT_HDR C WITH(NOLOCK) ON J.CDP_CONTACT_ID = C.CDP_CONTACT_ID
			WHERE
				A.ALERT_ID = @ALERT_ID


			UPDATE @RETURN_TABLE SET IsClientContact = 1 WHERE NOT ClientContactID IS NULL;
		END

		-- CURRENT RECIPIENT
		BEGIN
			UPDATE @RETURN_TABLE
			SET IsCurrentRecipient = CONVERT(BIT, CASE ISNULL(CASE WHEN IsCurrentNotify = 1 THEN 1 ELSE IsCurrentRecipient END, 0)
																   WHEN 1 THEN 0
																   WHEN 0 THEN 1
															  END)
		END

		-- MULTI ROUTE CURRENT STATE COMPLETED
		BEGIN
			UPDATE @RETURN_TABLE SET CurrentStateCompleted = 1
			FROM
				@RETURN_TABLE RT
				INNER JOIN ALERT A ON RT.AlertID = A.ALERT_ID AND RT.AlertTemplateID = A.ALRT_NOTIFY_HDR_ID AND RT.AlertStateID = A.ALERT_STATE_ID
			WHERE
				RT.CompletedDismissed = 1;
		END

		--	CURRENT ASSIGNEE
		BEGIN
			UPDATE @RETURN_TABLE SET IsCurrentAssignee = 1
			FROM
				@RETURN_TABLE RT
				INNER JOIN ALERT A ON RT.AlertID = A.ALERT_ID AND RT.AlertTemplateID = A.ALRT_NOTIFY_HDR_ID AND RT.AlertStateID = A.ALERT_STATE_ID;
		END

		-- CLEAN UP
		BEGIN
			UPDATE @RETURN_TABLE 
			SET 
				[IsTaskTempComplete] = CASE WHEN [IsTaskTempComplete] IS NULL THEN 0 ELSE [IsTaskTempComplete] END,
				[IsCurrentRecipient] = CASE WHEN [IsCurrentRecipient] IS NULL THEN 0 ELSE [IsCurrentRecipient] END,
				[IsClientContact] = CASE WHEN [IsClientContact] IS NULL THEN 0 ELSE [IsClientContact] END,
				[ClientContactID] = CASE WHEN [ClientContactID] IS NULL THEN 0 ELSE [ClientContactID] END,
				[AlertTemplateID] = CASE WHEN [AlertTemplateID] IS NULL THEN 0 ELSE [AlertTemplateID] END,
				[AlertStateID] = CASE WHEN [AlertStateID] IS NULL THEN 0 ELSE [AlertStateID] END,
				[CurrentStateCompleted] = CASE WHEN [CurrentStateCompleted] IS NULL THEN 0 ELSE [CurrentStateCompleted] END,
				[IsCurrentAssignee] = CASE WHEN [IsCurrentAssignee] IS NULL THEN 0 ELSE [IsCurrentAssignee] END
		END

		--  ONLY CURRENT
		BEGIN
			DELETE FROM @RETURN_TABLE WHERE ID NOT IN (
			SELECT
				ID
			FROM
				@RETURN_TABLE
			WHERE
				(AlertTemplateID = 0 AND AlertStateID = 0)
				OR (AlertTemplateID = @CURR_ALRT_NOTIFY_HDR_ID AND AlertStateID = @CURR_ALERT_STATE_ID))
		END

    END
    /***** QUERY *****/
    RETURN

END
GO
