CREATE PROCEDURE [dbo].[advsp_load_drpt_alerts_recipients]

AS
BEGIN

	DELETE FROM [dbo].[DRPT_ALERTS_RECIPIENTS]
	
	DBCC CHECKIDENT (DRPT_ALERTS_RECIPIENTS, reseed, 0)
	
	INSERT INTO [dbo].[DRPT_ALERTS_RECIPIENTS]
	SELECT 
		[AlertID] = AWR.AlertID,
		[SequenceNumber] = AWR.SequenceNumber,
		[AlertType] = AWR.AlertType,
		[Description] = AWR.[Description],
		[Subject] = AWR.[Subject],
		[Body] = AWR.Body,
		[GeneratedDate] = AWR.GeneratedDate,
		[Priority] = AWR.[Priority],
		[ClientCode] = AWR.ClientCode,
		[DivisionCode] = AWR.DivisionCode,
		[ProductCode] = AWR.ProductCode,
		[CampaignCode] = AWR.CampaignCode,
		[JobNumber] = AWR.JobNumber,
		[ComponentNumber] = AWR.ComponentNumber,
		[EstimateNumber] = AWR.EstimateNumber,
		[EstimateComponentNumber] = AWR.EstimateComponentNumber,
		[EstimateQuoteNumber] = AWR.EstimateQuoteNumber,
		[EstimateRevisionNumber] = AWR.EstimateRevisionNumber,
		[VendorCode] = AWR.VendorCode,
		[EmployeeCode] = AWR.EmployeeCode,
		[PurchaseOrderNumber] = AWR.PurchaseOrderNumber,
		[PurchaseOrderRevisionNumber] = AWR.PurchaseOrderRevisionNumber,
		[OrderNumber] = AWR.OrderNumber,
		[RevisionNumber] = AWR.RevisionNumber,
		[UserCode] = AWR.UserCode,
		[PDFDirectory] = AWR.PDFDirectory,
		[AlertLevel] = AWR.AlertLevel,
		[CampaignIdentifier] = AWR.CampaignIdentifier,
		[OfficeCode] = AWR.OfficeCode,
		[GetsAlerts] = AWR.GetsAlerts,
		[BillingApprovalBatchID] = AWR.BillingApprovalBatchID,
		[TaskSequence] = AWR.TaskSequence,
		[TaskDueDate] = AWR.TaskDueDate,
		[AlertAssignmentID] = AWR.AlertAssignmentID,
		[AlertAssignmentTemplate] = AWR.AlertAssignmentTemplate,
		[AlertStateID] = AWR.AlertStateID,
		[AlertState] = AWR.AlertState,
		[TimeDue] = AWR.TimeDue,
		[Version] = AWR.[Version], 
		[VersionDescription] = AWR.VersionDescription,
		[Build] = AWR.Build, 
		[BuildDescription] = AWR.BuildDescription,
		[RecipientEmployeeCode] = AWR.RecipientEmployeeCode,
		[RecipientEmployee] = AWR.RecipientEmployee,
		[RecipientEmailAddress] = AWR.RecipientEmailAddress,
		[NewAlert] = AWR.NewAlert,
		[ReadAlert] = AWR.ReadAlert,
		[IsDismissed] = AWR.IsDismissed,
		[DismissedDate] = AWR.DismissedDate
	FROM
		(SELECT 
			[AlertID] = A.ALERT_ID, 
			[SequenceNumber] = A.ALERT_SEQ_NBR, 
			[AlertType] = AT.ALERT_TYPE_DESC, 
			[Description] = AC.ALERT_DESC, 
			[Subject] = A.[SUBJECT], 
			[Body] = A.BODY, 
			[GeneratedDate] = A.GENERATED, 
			[Priority] = A.[PRIORITY], 
			[ClientCode] = A.CL_CODE, 
			[DivisionCode] = A.DIV_CODE, 
			[ProductCode] = A.PRD_CODE, 
			[CampaignCode] = A.CMP_CODE, 
			[JobNumber] = A.JOB_NUMBER, 
			[ComponentNumber] = A.JOB_COMPONENT_NBR, 
			[EstimateNumber] = A.ESTIMATE_NUMBER, 
			[EstimateComponentNumber] = A.EST_COMPONENT_NBR, 
			[EstimateQuoteNumber] = A.EST_QUOTE_NBR, 
			[EstimateRevisionNumber] = A.ESTIMATE_REV_NBR, 
			[VendorCode] = A.VN_CODE, 
			[EmployeeCode] = A.EMP_CODE, 
			[PurchaseOrderNumber] = A.PO_NUMBER, 
			[PurchaseOrderRevisionNumber] = A.PO_REVISION, 
			[OrderNumber] = A.ORDER_NBR, 
			[RevisionNumber] = A.REV_NBR, 
			[UserCode] = A.ALERT_USER, 
			[PDFDirectory] = A.TEMP_PDF_PATH, 
			[AlertLevel] = A.ALERT_LEVEL, 
			[CampaignIdentifier] = A.CMP_IDENTIFIER, 
			[OfficeCode] = A.OFFICE_CODE, 
			[GetsAlerts] = CASE WHEN A.CP_ALERT = 1 THEN 'Yes' ELSE 'No' END, 
			[BillingApprovalBatchID] = A.BA_BATCH_ID, 
			[TaskSequence] = A.TASK_SEQ_NBR, 
			[TaskDueDate] = A.DUE_DATE, 
			[AlertAssignmentID] = A.ALRT_NOTIFY_HDR_ID, 
			[AlertAssignmentTemplate] = ANH.ALERT_NOTIFY_NAME, 
			[AlertStateID] = A.ALERT_STATE_ID, 
			[AlertState] = AST.ALERT_STATE_NAME, 
			[TimeDue] = A.TIME_DUE, 
			[Version] = SV.[VERSION], 
			[VersionDescription] = SV.VERSION_DESC,
			[Build] = SB.BUILD, 
			[BuildDescription] = SB.BUILD_DESC,
			[RecipientEmployeeCode] = AR.EMP_CODE,
			[RecipientEmployee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN LTRIM(RTRIM(ISNULL(EMP.EMP_FNAME, '') + ' ' + ISNULL(EMP.EMP_LNAME, ''))) ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END,
			[RecipientEmailAddress] =  AR.EMAIL_ADDRESS, 
			[NewAlert] = CASE WHEN AR.NEW_ALERT = 1 THEN 'Yes' ELSE 'No' END, 
			[ReadAlert] = CASE WHEN AR.READ_ALERT = 1 THEN 'Yes' ELSE 'No' END,
			[IsDismissed] = 'OPEN',
			[DismissedDate] = NULL
		FROM 
			[dbo].[ALERT] AS A INNER JOIN 
			[dbo].[ALERT_TYPE] AS AT ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
			[dbo].[ALERT_CATEGORY] AS AC ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
			[dbo].[ALERT_STATES] AS AST ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
			[dbo].[ALERT_NOTIFY_HDR] AS ANH ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID INNER JOIN 
			[dbo].[ALERT_RCPT] AS AR ON A.ALERT_ID = AR.ALERT_ID LEFT OUTER JOIN 
			[dbo].[EMPLOYEE] AS EMP ON AR.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN 
			[dbo].[SOFTWARE_VERSION] AS SV ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
			[dbo].[SOFTWARE_BUILD] AS SB ON SB.VERSION_ID = A.VER AND
											SB.BUILD_ID = A.BUILD
			
		UNION ALL
		
		SELECT 
			[AlertID] = A.ALERT_ID, 
			[SequenceNumber] = A.ALERT_SEQ_NBR, 
			[AlertType] = AT.ALERT_TYPE_DESC, 
			[Description] = AC.ALERT_DESC, 
			[Subject] = A.[SUBJECT], 
			[Body] = A.BODY, 
			[GeneratedDate] = A.GENERATED, 
			[Priority] = A.[PRIORITY], 
			[ClientCode] = A.CL_CODE, 
			[DivisionCode] = A.DIV_CODE, 
			[ProductCode] = A.PRD_CODE, 
			[CampaignCode] = A.CMP_CODE, 
			[JobNumber] = A.JOB_NUMBER, 
			[ComponentNumber] = A.JOB_COMPONENT_NBR, 
			[EstimateNumber] = A.ESTIMATE_NUMBER, 
			[EstimateComponentNumber] = A.EST_COMPONENT_NBR, 
			[EstimateQuoteNumber] = A.EST_QUOTE_NBR, 
			[EstimateRevisionNumber] = A.ESTIMATE_REV_NBR, 
			[VendorCode] = A.VN_CODE, 
			[EmployeeCode] = A.EMP_CODE, 
			[PurchaseOrderNumber] = A.PO_NUMBER, 
			[PurchaseOrderRevisionNumber] = A.PO_REVISION, 
			[OrderNumber] = A.ORDER_NBR, 
			[RevisionNumber] = A.REV_NBR, 
			[UserCode] = A.ALERT_USER, 
			[PDFDirectory] = A.TEMP_PDF_PATH, 
			[AlertLevel] = A.ALERT_LEVEL, 
			[CampaignIdentifier] = A.CMP_IDENTIFIER, 
			[OfficeCode] = A.OFFICE_CODE, 
			[GetsAlerts] = CASE WHEN A.CP_ALERT = 1 THEN 'Yes' ELSE 'No' END, 
			[BillingApprovalBatchID] = A.BA_BATCH_ID, 
			[TaskSequence] = A.TASK_SEQ_NBR, 
			[TaskDueDate] = A.DUE_DATE, 
			[AlertAssignmentID] = A.ALRT_NOTIFY_HDR_ID, 
			[AlertAssignmentTemplate] = ANH.ALERT_NOTIFY_NAME, 
			[AlertStateID] = A.ALERT_STATE_ID, 
			[AlertState] = AST.ALERT_STATE_NAME, 
			[TimeDue] = A.TIME_DUE, 
			[Version] = SV.[VERSION], 
			[VersionDescription] = SV.VERSION_DESC,
			[Build] = SB.BUILD, 
			[BuildDescription] = SB.BUILD_DESC,
			[RecipientEmployeeCode] = ARD.EMP_CODE,
			[RecipientEmployee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN LTRIM(RTRIM(ISNULL(EMP.EMP_FNAME, '') + ' ' + ISNULL(EMP.EMP_LNAME, ''))) ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END,
			[RecipientEmailAddress] = ARD.EMAIL_ADDRESS, 
			[NewAlert] = CASE WHEN ARD.NEW_ALERT = 1 THEN 'Yes' ELSE 'No' END, 
			[ReadAlert] = CASE WHEN ARD.READ_ALERT = 1 THEN 'Yes' ELSE 'No' END,
			[IsDismissed] = 'DISMISSED',
			[DismissedDate] = ARD.PROCESSED
		FROM 
			[dbo].[ALERT] AS A INNER JOIN 
			[dbo].[ALERT_TYPE] AS AT ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
			[dbo].[ALERT_CATEGORY] AS AC ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
			[dbo].[ALERT_STATES] AS AST ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
			[dbo].[ALERT_NOTIFY_HDR] AS ANH ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID INNER JOIN 
			[dbo].[ALERT_RCPT_DISMISSED] AS ARD ON A.ALERT_ID = ARD.ALERT_ID LEFT OUTER JOIN 
			[dbo].[EMPLOYEE] AS EMP ON ARD.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN 
			[dbo].[SOFTWARE_VERSION] AS SV ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
			[dbo].[SOFTWARE_BUILD] AS SB ON SB.VERSION_ID = A.VER AND
											SB.BUILD_ID = A.BUILD) AS AWR

END	

