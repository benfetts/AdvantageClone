IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alerts_dataset]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alerts_dataset]
GO

CREATE PROCEDURE [dbo].[advsp_alerts_dataset]
	@DATE_TYPE AS int,
	@START_DATE AS smalldatetime,
	@END_DATE AS smalldatetime,
	@UserID varchar(100)
AS
BEGIN
	
	SELECT 
		[ID] = A.ALERT_ID,
		[AlertID] = A.ALERT_ID, 
		[SequenceNumber] = A.ALERT_SEQ_NBR, 
		[AlertType] = AT.ALERT_TYPE_DESC, 
		[Description] = AC.ALERT_DESC, 
		[Subject] = A.[SUBJECT], 
		[Body] = REPLACE(REPLACE(REPLACE(REPLACE(dbo.advfn_strip_html(SUBSTRING(A.BODY,0,DATALENGTH(A.BODY))), CHAR(13), ''), CHAR(10), ''), '&nbsp;',' '), '</p', ''), 
		[GeneratedDate] = A.[GENERATED], 
		[Priority] = A.[PRIORITY], 
		[ClientCode] = A.CL_CODE, 
		[DivisionCode] = A.DIV_CODE, 
		[ProductCode] = A.PRD_CODE, 
		[CampaignCode] = A.CMP_CODE, 
		[JobNumber] = A.JOB_NUMBER, 
        [JobDescription] = J.JOB_DESC,
		[ComponentNumber] = A.JOB_COMPONENT_NBR, 
        [ComponentDescription] = JC.JOB_COMP_DESC,
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
		[AssignedEmployee] = A.ASSIGNED_EMP_FML,
		--[AssignedEmployee] = CASE WHEN (SELECT COUNT(ALERT_ID) FROM ALERT_RCPT ARC WHERE ARC.ALERT_ID = A.ALERT_ID AND ARC.CURRENT_NOTIFY = 1) > 1 THEN 'Multi' ELSE (SELECT ARC.EMP_CODE FROM ALERT_RCPT ARC WHERE ARC.ALERT_ID = A.ALERT_ID AND ARC.CURRENT_NOTIFY = 1) END,
		[LastModifiedDate] = A.LAST_UPDATED,
		[LastModifiedByEmployee] = A.LAST_UPDATED_FML,
		[AssignmentCompleted] = CASE WHEN A.ASSIGN_COMPLETED = 1 THEN 'Yes' ELSE 'No' END,
		[WorkItem] = CASE WHEN A.IS_WORK_ITEM = 1 THEN 'Yes' ELSE 'No' END,
		[IsRouted] = CASE WHEN A.ALRT_NOTIFY_HDR_ID IS NOT NULL THEN 'Yes' ELSE 'No' END,
		[CSReview] = CASE WHEN A.IS_CS_REVIEW = 1 THEN 'Yes' ELSE 'No' END,
		[HoursAllowed] = ISNULL(HRS_ALLOWED,0),
		[BoardState] = BOARD_STATE.ALERT_STATE_NAME,
		[BacklogOrder] = A.BACKLOG_SEQ_NBR

	FROM 
		[dbo].[ALERT] AS A WITH(NOLOCK) INNER JOIN 
		[dbo].[ALERT_TYPE] AS AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
		[dbo].[ALERT_CATEGORY] AS AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
		[dbo].[ALERT_STATES] AS AST WITH(NOLOCK) ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
		[dbo].[ALERT_NOTIFY_HDR] AS ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
		[dbo].[SOFTWARE_VERSION] AS SV WITH(NOLOCK) ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
		[dbo].[SOFTWARE_BUILD] AS SB WITH(NOLOCK) ON SB.VERSION_ID = A.VER AND SB.BUILD_ID = A.BUILD LEFT OUTER JOIN
		[dbo].[ALERT_STATES] AS BOARD_STATE WITH(NOLOCK) ON A.BOARD_STATE_ID = BOARD_STATE.ALERT_STATE_ID LEFT OUTER JOIN
		[dbo].[JOB_LOG] AS J WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER LEFT OUTER JOIN
		[dbo].[JOB_COMPONENT] AS JC WITH(NOLOCK) ON JC.JOB_NUMBER = A.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
	WHERE A.[LAST_UPDATED] BETWEEN @START_DATE AND CONVERT(DATETIME, @END_DATE +' 23:59:00', 101)

END	

