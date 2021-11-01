CREATE VIEW [dbo].[V_DRPT_ALERTS_COMMENT_LIVE]

WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
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
		[CommentUserCode] = ACOM.USER_CODE, 
		[CommentDate] = ACOM.GENERATED_DATE, 
		[Comment] = ACOM.COMMENT,
		[AssignedEmployeeCode] = ACOM.ASSIGNED_EMP_CODE,
		[AssignedEmployeeName] = CASE WHEN ACOM.ASSIGNED_EMP_CODE IS NULL THEN NULL ELSE COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') END
	FROM
		[dbo].[ALERT] AS A INNER JOIN 
		[dbo].[ALERT_TYPE] AS AT ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
		[dbo].[ALERT_CATEGORY] AS AC ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
		[dbo].[ALERT_STATES] AS AST ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
		[dbo].[ALERT_NOTIFY_HDR] AS ANH ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
		[dbo].[ALERT_COMMENT] AS ACOM ON A.ALERT_ID = ACOM.ALERT_ID LEFT OUTER JOIN 
		[dbo].[SOFTWARE_VERSION] AS SV ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
		[dbo].[SOFTWARE_BUILD] AS SB ON SB.VERSION_ID = A.VER AND
										SB.BUILD_ID = A.BUILD LEFT OUTER JOIN 
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = ACOM.ASSIGNED_EMP_CODE
