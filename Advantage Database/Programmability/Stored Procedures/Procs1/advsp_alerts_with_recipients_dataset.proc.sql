IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alerts_with_recipients_dataset]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alerts_with_recipients_dataset]
GO

CREATE PROCEDURE [dbo].[advsp_alerts_with_recipients_dataset]
	@DATE_TYPE AS int,
	@START_DATE AS smalldatetime,
	@END_DATE AS smalldatetime,
	@UserID varchar(100),
	@IncludeDismissed bit

AS
BEGIN
	
	if @IncludeDismissed = 0
	Begin
		SELECT
			[ID] = NEWID(),
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
			[JobDescription] = AWR.JobDescription,
			[ComponentNumber] = AWR.ComponentNumber,
			[ComponentDescription] = AWR.ComponentDescription,
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
			[IsCC] = AWR.IsCC,
			[NewAlert] = AWR.NewAlert,
			[ReadAlert] = AWR.ReadAlert,
			[IsDismissed] = AWR.IsDismissed,
			[DismissedDate] = AWR.DismissedDate,
			[AssignedEmployee] = AWR.AssignedEmployee,
			[LastModifiedDate] = AWR.LastModifiedDate,
			[LastModifiedByEmployee] = AWR.LastModifiedByEmployee,
			[AssignmentCompleted] = AWR.AssignmentCompleted,
			[WorkItem] = AWR.WorkItem,
			[IsRouted] = AWR.IsRouted,
			[CSReview] = AWR.CSReview,
			[HoursAllowed] = AWR.HoursAllowed,
			[BoardState] = AWR.BoardState,
			[BacklogOrder] = AWR.BacklogOrder
		FROM
			(SELECT 
				[AlertID] = A.ALERT_ID, 
				[SequenceNumber] = CASE WHEN A.ALERT_SEQ_NBR IS NOT NULL THEN CAST(A.ALERT_SEQ_NBR AS INTEGER) ELSE A.ALERT_ID END,
				[AlertType] = AT.ALERT_TYPE_DESC, 
				[Description] = AC.ALERT_DESC, 
				[Subject] = A.[SUBJECT], 
				[Body] = REPLACE(REPLACE(REPLACE(REPLACE(dbo.advfn_strip_html(SUBSTRING(A.BODY,0,DATALENGTH(A.BODY))), CHAR(13), ''), CHAR(10), ''), '&nbsp;',' '), '</p', ''),
				[GeneratedDate] = A.GENERATED, 
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
				[RecipientEmployeeCode] = AR.EMP_CODE,
				[RecipientEmployee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN LTRIM(RTRIM(ISNULL(EMP.EMP_FNAME, '') + ' ' + ISNULL(EMP.EMP_LNAME, ''))) ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END,
				[RecipientEmailAddress] =  AR.EMAIL_ADDRESS, 
				[IsCC] = CASE WHEN AR.CURRENT_NOTIFY IS NULL OR AR.CURRENT_NOTIFY = 0 THEN 'Yes' ELSE 'No' END,
				[NewAlert] = CASE WHEN AR.NEW_ALERT = 1 THEN 'Yes' ELSE 'No' END, 
				[ReadAlert] = CASE WHEN AR.READ_ALERT = 1 THEN 'Yes' ELSE 'No' END,
				[IsDismissed] = 'OPEN',
				[DismissedDate] = NULL,
				[AssignedEmployee] = A.ASSIGNED_EMP_FML,
				--[AssignedEmployee] = CASE WHEN (SELECT COUNT(ALERT_ID) FROM ALERT_RCPT ARC WHERE ARC.ALERT_ID = A.ALERT_ID AND ARC.CURRENT_NOTIFY = 1) > 1 THEN 'Multi' ELSE AR.EMP_CODE END,
				[LastModifiedDate] = A.LAST_UPDATED,
				[LastModifiedByEmployee] = A.LAST_UPDATED_FML,
				[AssignmentCompleted] = CASE WHEN A.ASSIGN_COMPLETED = 1 THEN 'Yes' ELSE 'No' END,
				[WorkItem] = CASE WHEN A.IS_WORK_ITEM = 1 THEN 'Yes' ELSE 'No' END,
				[IsRouted] = CASE WHEN A.ALRT_NOTIFY_HDR_ID IS NOT NULL THEN 'Yes' ELSE 'No' END,
				[CSReview] = CASE WHEN A.IS_CS_REVIEW = 1 THEN 'Yes' ELSE 'No' END,
				[HoursAllowed] = ISNULL(HOURS_ALLOWED,0),
				[BoardState] = BOARD_STATE.ALERT_STATE_NAME,
				[BacklogOrder] = A.BACKLOG_SEQ_NBR
			FROM 
				[dbo].[ALERT] AS A WITH(NOLOCK) INNER JOIN 
				[dbo].[ALERT_TYPE] AS AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
				[dbo].[ALERT_CATEGORY] AS AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
				[dbo].[ALERT_STATES] AS AST WITH(NOLOCK) ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
				[dbo].[ALERT_NOTIFY_HDR] AS ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID INNER JOIN 
				[dbo].[ALERT_RCPT] AS AR WITH(NOLOCK) ON A.ALERT_ID = AR.ALERT_ID LEFT OUTER JOIN 
				[dbo].[EMPLOYEE_CLOAK] AS EMP WITH(NOLOCK) ON AR.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN 
				[dbo].[SOFTWARE_VERSION] AS SV WITH(NOLOCK) ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
				[dbo].[SOFTWARE_BUILD] AS SB WITH(NOLOCK) ON SB.VERSION_ID = A.VER AND
												SB.BUILD_ID = A.BUILD LEFT OUTER JOIN
				[dbo].[ALERT_STATES] AS BOARD_STATE WITH(NOLOCK) ON A.BOARD_STATE_ID = BOARD_STATE.ALERT_STATE_ID LEFT OUTER JOIN
		        [dbo].[JOB_LOG] AS J WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER LEFT OUTER JOIN
		        [dbo].[JOB_COMPONENT] AS JC WITH(NOLOCK) ON JC.JOB_NUMBER = A.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
			WHERE A.[LAST_UPDATED] BETWEEN @START_DATE AND CONVERT(DATETIME, @END_DATE +' 23:59:00', 101)
				  AND A.ALERT_CAT_ID <> 71 AND ((AR.ALRT_NOTIFY_HDR_ID IS NOT NULL AND AR.ALERT_STATE_ID IS NOT NULL) OR AR.ALRT_NOTIFY_HDR_ID IS NULL)) AS AWR
	End
	Else
	Begin
		SELECT
			[ID] = NEWID(),
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
			[JobDescription] = AWR.JobDescription,
			[ComponentNumber] = AWR.ComponentNumber,
			[ComponentDescription] = AWR.ComponentDescription,
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
			[IsCC] = AWR.IsCC,
			[NewAlert] = AWR.NewAlert,
			[ReadAlert] = AWR.ReadAlert,
			[IsDismissed] = AWR.IsDismissed,
			[DismissedDate] = AWR.DismissedDate,
			[AssignedEmployee] = AWR.AssignedEmployee,
			[LastModifiedDate] = AWR.LastModifiedDate,
			[LastModifiedByEmployee] = AWR.LastModifiedByEmployee,
			[AssignmentCompleted] = AWR.AssignmentCompleted,
			[WorkItem] = AWR.WorkItem,
			[IsRouted] = AWR.IsRouted,
			[CSReview] = AWR.CSReview,
			[HoursAllowed] = AWR.HoursAllowed,
			[BoardState] = AWR.BoardState,
			[BacklogOrder] = AWR.BacklogOrder
		FROM
			(SELECT 
				[AlertID] = A.ALERT_ID, 
				[SequenceNumber] = CASE WHEN A.ALERT_SEQ_NBR IS NOT NULL THEN CAST(A.ALERT_SEQ_NBR AS INTEGER) ELSE A.ALERT_ID END,
				[AlertType] = AT.ALERT_TYPE_DESC, 
				[Description] = AC.ALERT_DESC, 
				[Subject] = A.[SUBJECT], 
				[Body] = REPLACE(REPLACE(REPLACE(REPLACE(dbo.advfn_strip_html(SUBSTRING(A.BODY,0,DATALENGTH(A.BODY))), CHAR(13), ''), CHAR(10), ''), '&nbsp;',' '), '</p', ''),
				[GeneratedDate] = A.GENERATED, 
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
				[RecipientEmployeeCode] = AR.EMP_CODE,
				[RecipientEmployee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN LTRIM(RTRIM(ISNULL(EMP.EMP_FNAME, '') + ' ' + ISNULL(EMP.EMP_LNAME, ''))) ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END,
				[RecipientEmailAddress] =  AR.EMAIL_ADDRESS, 
				[IsCC] = CASE WHEN AR.CURRENT_NOTIFY IS NULL OR AR.CURRENT_NOTIFY = 0 THEN 'Yes' ELSE 'No' END,
				[NewAlert] = CASE WHEN AR.NEW_ALERT = 1 THEN 'Yes' ELSE 'No' END, 
				[ReadAlert] = CASE WHEN AR.READ_ALERT = 1 THEN 'Yes' ELSE 'No' END,
				[IsDismissed] = 'OPEN',
				[DismissedDate] = NULL,
				[AssignedEmployee] = A.ASSIGNED_EMP_FML,
				--[AssignedEmployee] = CASE WHEN (SELECT COUNT(ALERT_ID) FROM ALERT_RCPT ARC WHERE ARC.ALERT_ID = A.ALERT_ID AND ARC.CURRENT_NOTIFY = 1) > 1 THEN 'Multi' ELSE AR.EMP_CODE END,
				[LastModifiedDate] = A.LAST_UPDATED,
				[LastModifiedByEmployee] = A.LAST_UPDATED_FML,
				[AssignmentCompleted] = CASE WHEN A.ASSIGN_COMPLETED = 1 THEN 'Yes' ELSE 'No' END,
				[WorkItem] = CASE WHEN A.IS_WORK_ITEM = 1 THEN 'Yes' ELSE 'No' END,
				[IsRouted] = CASE WHEN A.ALRT_NOTIFY_HDR_ID IS NOT NULL THEN 'Yes' ELSE 'No' END,
				[CSReview] = CASE WHEN A.IS_CS_REVIEW = 1 THEN 'Yes' ELSE 'No' END,
				[HoursAllowed] = ISNULL(HOURS_ALLOWED,0),
				[BoardState] = BOARD_STATE.ALERT_STATE_NAME,
				[BacklogOrder] = A.BACKLOG_SEQ_NBR
			FROM 
				[dbo].[ALERT] AS A WITH(NOLOCK) INNER JOIN 
				[dbo].[ALERT_TYPE] AS AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
				[dbo].[ALERT_CATEGORY] AS AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
				[dbo].[ALERT_STATES] AS AST WITH(NOLOCK) ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
				[dbo].[ALERT_NOTIFY_HDR] AS ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID INNER JOIN 
				[dbo].[ALERT_RCPT] AS AR WITH(NOLOCK) ON A.ALERT_ID = AR.ALERT_ID LEFT OUTER JOIN 
				[dbo].[EMPLOYEE_CLOAK] AS EMP WITH(NOLOCK) ON AR.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN 
				[dbo].[SOFTWARE_VERSION] AS SV WITH(NOLOCK) ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
				[dbo].[SOFTWARE_BUILD] AS SB WITH(NOLOCK) ON SB.VERSION_ID = A.VER AND
												SB.BUILD_ID = A.BUILD LEFT OUTER JOIN
				[dbo].[ALERT_STATES] AS BOARD_STATE WITH(NOLOCK) ON A.BOARD_STATE_ID = BOARD_STATE.ALERT_STATE_ID LEFT OUTER JOIN
		        [dbo].[JOB_LOG] AS J WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER LEFT OUTER JOIN
		        [dbo].[JOB_COMPONENT] AS JC WITH(NOLOCK) ON JC.JOB_NUMBER = A.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
			WHERE A.[LAST_UPDATED] BETWEEN @START_DATE AND CONVERT(DATETIME, @END_DATE +' 23:59:00', 101) 
					AND A.ALERT_CAT_ID <> 71 AND ((AR.ALRT_NOTIFY_HDR_ID IS NOT NULL AND AR.ALERT_STATE_ID IS NOT NULL) OR AR.ALRT_NOTIFY_HDR_ID IS NULL)
			
			UNION ALL
		
			SELECT 
				[AlertID] = A.ALERT_ID, 
				[SequenceNumber] = CASE WHEN A.ALERT_SEQ_NBR IS NOT NULL THEN CAST(A.ALERT_SEQ_NBR AS INTEGER) ELSE A.ALERT_ID END,
				[AlertType] = AT.ALERT_TYPE_DESC, 
				[Description] = AC.ALERT_DESC, 
				[Subject] = A.[SUBJECT], 
				[Body] = REPLACE(REPLACE(REPLACE(REPLACE(dbo.advfn_strip_html(SUBSTRING(A.BODY,0,DATALENGTH(A.BODY))), CHAR(13), ''), CHAR(10), ''), '&nbsp;',' '), '</p', ''),
				[GeneratedDate] = A.GENERATED, 
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
				[RecipientEmployeeCode] = ARD.EMP_CODE,
				[RecipientEmployee] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN LTRIM(RTRIM(ISNULL(EMP.EMP_FNAME, '') + ' ' + ISNULL(EMP.EMP_LNAME, ''))) ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END,
				[RecipientEmailAddress] = ARD.EMAIL_ADDRESS, 
				[IsCC] = CASE WHEN ARD.CURRENT_NOTIFY IS NULL OR ARD.CURRENT_NOTIFY = 0 THEN 'Yes' ELSE 'No' END,
				[NewAlert] = CASE WHEN ARD.NEW_ALERT = 1 THEN 'Yes' ELSE 'No' END, 
				[ReadAlert] = CASE WHEN ARD.READ_ALERT = 1 THEN 'Yes' ELSE 'No' END,
				[IsDismissed] = 'DISMISSED',
				[DismissedDate] = ARD.PROCESSED,
				[AssignedEmployee] = A.ASSIGNED_EMP_FML,
				--[AssignedEmployee] = CASE WHEN (SELECT COUNT(ALERT_ID) FROM ALERT_RCPT_DISMISSED ARC WHERE ARC.ALERT_ID = A.ALERT_ID AND ARC.CURRENT_NOTIFY = 1) > 1 THEN 'Multi' ELSE ARD.EMP_CODE END,
				[LastModifiedDate] = A.LAST_UPDATED,
				[LastModifiedByEmployee] = A.LAST_UPDATED_FML,
				[AssignmentCompleted] = CASE WHEN A.ASSIGN_COMPLETED = 1 THEN 'Yes' ELSE 'No' END,
				[WorkItem] = CASE WHEN A.IS_WORK_ITEM = 1 THEN 'Yes' ELSE 'No' END,
				[IsRouted] = CASE WHEN A.ALRT_NOTIFY_HDR_ID IS NOT NULL THEN 'Yes' ELSE 'No' END,
				[CSReview] = CASE WHEN A.IS_CS_REVIEW = 1 THEN 'Yes' ELSE 'No' END,
				[HoursAllowed] = ISNULL(HOURS_ALLOWED,0),
				[BoardState] = BOARD_STATE.ALERT_STATE_NAME,
				[BacklogOrder] = A.BACKLOG_SEQ_NBR
			FROM 
				[dbo].[ALERT] AS A WITH(NOLOCK) INNER JOIN 
				[dbo].[ALERT_TYPE] AS AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
				[dbo].[ALERT_CATEGORY] AS AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
				[dbo].[ALERT_STATES] AS AST WITH(NOLOCK) ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
				[dbo].[ALERT_NOTIFY_HDR] AS ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID INNER JOIN 
				[dbo].[ALERT_RCPT_DISMISSED] AS ARD WITH(NOLOCK) ON A.ALERT_ID = ARD.ALERT_ID LEFT OUTER JOIN 
				[dbo].[EMPLOYEE_CLOAK] AS EMP WITH(NOLOCK) ON ARD.EMP_CODE = EMP.EMP_CODE LEFT OUTER JOIN 
				[dbo].[SOFTWARE_VERSION] AS SV WITH(NOLOCK) ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
				[dbo].[SOFTWARE_BUILD] AS SB WITH(NOLOCK) ON SB.VERSION_ID = A.VER AND
												SB.BUILD_ID = A.BUILD LEFT OUTER JOIN
				[dbo].[ALERT_STATES] AS BOARD_STATE WITH(NOLOCK) ON A.BOARD_STATE_ID = BOARD_STATE.ALERT_STATE_ID LEFT OUTER JOIN
		        [dbo].[JOB_LOG] AS J WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER LEFT OUTER JOIN
		        [dbo].[JOB_COMPONENT] AS JC WITH(NOLOCK) ON JC.JOB_NUMBER = A.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
			WHERE A.[LAST_UPDATED] BETWEEN @START_DATE AND CONVERT(DATETIME, @END_DATE +' 23:59:00', 101)
				AND A.ALERT_CAT_ID <> 71 AND ((ARD.ALRT_NOTIFY_HDR_ID IS NOT NULL AND ARD.ALERT_STATE_ID IS NOT NULL) OR ARD.ALRT_NOTIFY_HDR_ID IS NULL)) AS AWR
	End

	


END	

