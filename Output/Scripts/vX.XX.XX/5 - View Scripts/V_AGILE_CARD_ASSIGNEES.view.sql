--DROP VIEW [dbo].[V_AGILE_CARD_ASSIGNEES]
/*

advtf_alert_recipient_get.function.sql uses this view!
This view needs to be created/updated BEFORE the functions folder!

*/

CREATE VIEW [dbo].[V_AGILE_CARD_ASSIGNEES]
AS

	SELECT
		[AlertID] = R.AlertID,
		[ID] = ISNULL(R.[AlertRecipientID], -1),
		[EmployeeCode] = R.[EmployeeCode],
		[EmployeeEmail] = R.[EmployeeEmail],
		[EmployeeFullName] = ISNULL(E.EMP_FNAME, '') + ISNULL(' ' + E.EMP_MI + '. ', ' ') + ISNULL(E.EMP_LNAME, ''),
		[IsCurrentRecipient] = CONVERT(BIT, CASE ISNULL(CASE WHEN R.IsCurrentNotify = 1 THEN 1 ELSE R.[IsCurrentRecipient] END, 0)
												WHEN 1 THEN 0
												WHEN 0 THEN 1
											END),							
		[IsCurrentNotify] = CONVERT(BIT, ISNULL(R.[IsCurrentNotify], 0)),
		[IsTaskEmployee] = CONVERT(BIT, ISNULL(R.[IsTaskEmployee], 0)),
		[IsTaskTempComplete] = R.IsTaskTempComplete,
		[EmployeeImage] = EP.EMP_IMAGE,
		[IsRead] = CAST(ISNULL(R.[IsRead], 0) AS BIT),
		[IsCurrentAssignee] =	CASE
									WHEN R.IsTaskEmployee = 1 THEN CAST(1 AS BIT)
									WHEN A.ALRT_NOTIFY_HDR_ID IS NULL AND A.ALERT_STATE_ID IS NULL THEN CAST(1 AS BIT)
									WHEN A.ALRT_NOTIFY_HDR_ID = R.AlertTemplateID AND A.ALERT_STATE_ID = R.AlertStateID THEN CAST(1 AS BIT)
									ELSE CAST(0 AS BIT)
								END
	FROM
		(
		--SELECT
		--	[AlertID] = A.ALERT_ID,
		--	[AlertRecipientID] = AR.ALERT_RCPT_ID,
		--	[EmployeeCode] = A.ASSIGNED_EMP_CODE,
		--	[EmployeeEmail] = E.EMP_EMAIL,
		--	[IsCurrentRecipient] = 1, -- 1 = no, 0 = yes
		--	[IsCurrentNotify] = 1,
		--	[IsTaskEmployee] = 0,
		--	[IsTaskTempComplete] = CAST(0 AS BIT),
		--	[IsRead] = CAST(COALESCE(AR.READ_ALERT, ARD.READ_ALERT, 0) AS BIT),
		--	[AlertTemplateID] = A.ALRT_NOTIFY_HDR_ID,
		--	[AlertStateID] = A.ALERT_STATE_ID
		--FROM
		--	dbo.ALERT A
		--INNER JOIN
		--	dbo.EMPLOYEE E ON A.ASSIGNED_EMP_CODE = E.EMP_CODE
		--LEFT OUTER JOIN
		--	dbo.ALERT_RCPT AR ON A.ALERT_ID = AR.ALERT_ID AND
		--						 A.ASSIGNED_EMP_CODE = AR.EMP_CODE AND
		--						 AR.CURRENT_NOTIFY = 1
		--LEFT OUTER JOIN	
		--	dbo.ALERT_RCPT_DISMISSED ARD ON A.ALERT_ID = ARD.ALERT_ID AND
		--									A.ASSIGNED_EMP_CODE = ARD.EMP_CODE AND
		--									ARD.CURRENT_NOTIFY = 1
		--WHERE
		--	A.ASSIGNED_EMP_CODE IS NOT NULL AND
		--	AR.ALERT_RCPT_ID IS NULL AND
		--	ARD.ALERT_RCPT_ID IS NULL
	
		--UNION ALL

		SELECT
			[AlertID] = AR.ALERT_ID,
			[AlertRecipientID] = AR.ALERT_RCPT_ID,
			[EmployeeCode] = AR.EMP_CODE,
			[EmployeeEmail] = AR.EMAIL_ADDRESS,
			[IsCurrentRecipient] = AR.CURRENT_RCPT,
			[IsCurrentNotify] = AR.CURRENT_NOTIFY,
			[IsTaskEmployee] = 0,
			[IsTaskTempComplete] = CAST(0 AS BIT),
			[IsRead] = CAST(AR.READ_ALERT AS BIT),
			[AlertTemplateID] = AR.ALRT_NOTIFY_HDR_ID,
			[AlertStateID] = AR.ALERT_STATE_ID
		FROM
			dbo.ALERT_RCPT AR 

		UNION ALL

		SELECT
			[AlertID] = AR.ALERT_ID,
			[AlertRecipientID] = AR.ALERT_RCPT_ID,
			[EmployeeCode] = AR.EMP_CODE,
			[EmployeeEmail] = AR.EMAIL_ADDRESS,
			[IsCurrentRecipient] = AR.CURRENT_RCPT,
			[IsCurrentNotify] = AR.CURRENT_NOTIFY,
			[IsTaskEmployee] = 0,
			[IsTaskTempComplete] = CAST(0 AS BIT),
			[IsRead] = CAST(AR.READ_ALERT AS BIT),
			[AlertTemplateID] = AR.ALRT_NOTIFY_HDR_ID,
			[AlertStateID] = AR.ALERT_STATE_ID
		FROM
			dbo.ALERT_RCPT_DISMISSED AR 

		UNION ALL

		SELECT
			[AlertID] = A.ALERT_ID,
			[AlertRecipientID] = JTDE.ID,
			[EmployeeCode] = JTDE.EMP_CODE,
			[EmployeeEmail] = E.EMP_EMAIL,
			[IsCurrentRecipient] = 1, -- 1 = no, 0 = yes
			[IsCurrentNotify] = 1,
			[IsTaskEmployee] = 1,
			[IsTaskTempComplete] =	CASE
										WHEN JTDE.TEMP_COMP_DATE IS NULL THEN CAST(0 AS BIT)
										ELSE CAST(1 AS BIT)
									END,
			[IsRead] = CAST(JTDE.READ_ALERT AS BIT),
			[AlertTemplateID] = A.ALRT_NOTIFY_HDR_ID,
			[AlertStateID] = A.ALERT_STATE_ID
		FROM
			dbo.ALERT A
		INNER JOIN
			dbo.JOB_TRAFFIC_DET_EMPS JTDE ON A.JOB_NUMBER = JTDE.JOB_NUMBER AND
											 A.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND
											 A.TASK_SEQ_NBR = JTDE.SEQ_NBR AND
											 A.ALERT_CAT_ID = 71
		INNER JOIN
			dbo.EMPLOYEE E ON JTDE.EMP_CODE = E.EMP_CODE) AS R
		LEFT JOIN
			dbo.ALERT A ON R.AlertID = A.ALERT_ID
		LEFT JOIN
			dbo.EMPLOYEE E ON R.EmployeeCode = E.EMP_CODE
		LEFT OUTER JOIN
			 dbo.EMPLOYEE_PICTURE EP ON E.EMP_CODE = EP.EMP_CODE

	--WHERE
	--	1 = CASE WHEN A.ALRT_NOTIFY_HDR_ID IS NULL OR R.IsCurrentNotify <> 1 THEN 1 WHEN A.ASSIGNED_EMP_CODE = R.EmployeeCode THEN 1 ELSE 0 END



GO


