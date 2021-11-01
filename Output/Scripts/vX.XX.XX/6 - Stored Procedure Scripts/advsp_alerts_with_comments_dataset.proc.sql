IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alerts_with_comments_dataset]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alerts_with_comments_dataset]
GO

CREATE PROCEDURE [dbo].[advsp_alerts_with_comments_dataset]
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
			[AlertID] = A.ALERT_ID, 
			[SequenceNumber] = CASE WHEN A.ALERT_SEQ_NBR IS NOT NULL THEN CAST(A.ALERT_SEQ_NBR AS INTEGER) ELSE A.ALERT_ID END, 
			[AlertType] = AT.ALERT_TYPE_DESC, 
			[Description] = AC.ALERT_DESC, 
			[Subject] = A.[SUBJECT], 
			[Body] = REPLACE(REPLACE(REPLACE(REPLACE(dbo.advfn_strip_html(SUBSTRING(A.BODY,0,DATALENGTH(A.BODY))), CHAR(13), ''), CHAR(10), ''), '&nbsp;',' '), '</p', ''),
			[GeneratedDate] = A.GENERATED, 
			[Priority] = A.[PRIORITY], 
			[ClientCode] = A.CL_CODE, 
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = A.DIV_CODE, 
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = A.PRD_CODE, 
			[ProductDescription] = P.PRD_DESCRIPTION,
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
			[CurrentState] = AST.ALERT_STATE_NAME, 
			[TimeDue] = A.TIME_DUE, 
			[Version] = SV.[VERSION], 
			[VersionDescription] = SV.VERSION_DESC,
			[Build] = SB.BUILD, 
			[BuildDescription] = SB.BUILD_DESC,
			[CommentUserCode] = ACOM.USER_CODE, 
			[CommentDate] = ACOM.GENERATED_DATE, 
			[State] = ASTC.ALERT_STATE_NAME,
			[Comment] = REPLACE(REPLACE(dbo.advfn_strip_html(ACOM.COMMENT), CHAR(13), ''), CHAR(10), ''),
			[AssignedEmployeeCode] = ACOM.ASSIGNED_EMP_CODE,
			[AssignedEmployee] = CASE WHEN ACOM.ASSIGNED_EMP_CODE IS NULL THEN NULL ELSE COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') END,
			[LastModifiedDate] = A.LAST_UPDATED,
			[LastModifiedByEmployee] = A.LAST_UPDATED_FML,
			[AssignmentCompleted] = CASE WHEN A.ASSIGN_COMPLETED = 1 THEN 'Yes' ELSE 'No' END,
			[WorkItem] = CASE WHEN A.IS_WORK_ITEM = 1 THEN 'Yes' ELSE 'No' END,
			[IsRouted] = CASE WHEN A.ALRT_NOTIFY_HDR_ID IS NOT NULL THEN 'Yes' ELSE 'No' END,
			[CSReview] = CASE WHEN A.IS_CS_REVIEW = 1 THEN 'Yes' ELSE 'No' END,
			[HoursAllowed] = ISNULL(HRS_ALLOWED,0),
			[BoardState] = BOARD_STATE.ALERT_STATE_NAME,
			[BacklogOrder] = A.BACKLOG_SEQ_NBR,
			[CustodyStartDate] = ACOM.GENERATED_DATE,
			[CustodyEndDate] = ACOM.CUSTODY_END,
			[DaysInCustody] = DATEDIFF(day,ACOM.GENERATED_DATE,ACOM.CUSTODY_END),
			[HoursInCustody] = DATEDIFF(minute,ACOM.GENERATED_DATE,ACOM.CUSTODY_END)/60.0,
			[MinutesInCustody] = DATEDIFF(minute,ACOM.GENERATED_DATE,ACOM.CUSTODY_END),
			[IsSystemGenerated] = CASE WHEN ACOM.IS_SYSTEM = 1 THEN 'Yes' ELSE 'No' END,
			[ClientContactCode] = CCH.CONT_CODE,
			[ClientContactName] = CCH.CONT_FML
		FROM
			[dbo].[ALERT] AS A WITH(NOLOCK) INNER JOIN 
			[dbo].[ALERT_TYPE] AS AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
			[dbo].[ALERT_CATEGORY] AS AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
			[dbo].[ALERT_STATES] AS AST WITH(NOLOCK) ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
			[dbo].[ALERT_NOTIFY_HDR] AS ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
			[dbo].[ALERT_COMMENT] AS ACOM WITH(NOLOCK) ON A.ALERT_ID = ACOM.ALERT_ID  LEFT OUTER JOIN 
			[dbo].[ALERT_STATES] AS ASTC WITH(NOLOCK) ON ACOM.ALERT_STATE_ID = ASTC.ALERT_STATE_ID LEFT OUTER JOIN 
			[dbo].[SOFTWARE_VERSION] AS SV WITH(NOLOCK) ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
			[dbo].[SOFTWARE_BUILD] AS SB WITH(NOLOCK) ON SB.VERSION_ID = A.VER AND
											SB.BUILD_ID = A.BUILD LEFT OUTER JOIN 
			[dbo].[EMPLOYEE_CLOAK] AS EMP WITH(NOLOCK) ON EMP.EMP_CODE = ACOM.ASSIGNED_EMP_CODE LEFT OUTER JOIN
			[dbo].[ALERT_STATES] AS BOARD_STATE WITH(NOLOCK) ON A.BOARD_STATE_ID = BOARD_STATE.ALERT_STATE_ID LEFT OUTER JOIN
			[dbo].[CLIENT] AS C WITH(NOLOCK) ON A.CL_CODE = C.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D WITH(NOLOCK) ON A.CL_CODE = D.CL_CODE AND A.DIV_CODE = D.DIV_CODE  LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P WITH(NOLOCK) ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
		    [dbo].[JOB_LOG] AS J WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[JOB_COMPONENT] AS JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
			[dbo].[CDP_CONTACT_HDR] AS CCH WITH(NOLOCK) ON JC.CDP_CONTACT_ID = CCH.CDP_CONTACT_ID
		WHERE A.[LAST_UPDATED] BETWEEN @START_DATE AND CONVERT(DATETIME, @END_DATE +' 23:59:00', 101)
			  AND A.ALERT_CAT_ID <> 71 AND A.ALERT_ID IN (SELECT ALERT_ID FROM ALERT_RCPT AR WHERE A.ALERT_ID = AR.ALERT_ID)
	End
Else
	Begin
		SELECT 
			[ID] = NEWID(),
			[AlertID] = A.ALERT_ID, 
			[SequenceNumber] = CASE WHEN A.ALERT_SEQ_NBR IS NOT NULL THEN CAST(A.ALERT_SEQ_NBR AS INTEGER) ELSE A.ALERT_ID END, 
			[AlertType] = AT.ALERT_TYPE_DESC, 
			[Description] = AC.ALERT_DESC, 
			[Subject] = A.[SUBJECT], 
			[Body] = REPLACE(REPLACE(REPLACE(REPLACE(dbo.advfn_strip_html(SUBSTRING(A.BODY,0,DATALENGTH(A.BODY))), CHAR(13), ''), CHAR(10), ''), '&nbsp;',' '), '</p', ''),
			[GeneratedDate] = A.GENERATED, 
			[Priority] = A.[PRIORITY], 
			[ClientCode] = A.CL_CODE, 
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = A.DIV_CODE, 
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = A.PRD_CODE, 
			[ProductDescription] = P.PRD_DESCRIPTION,
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
			[CurrentState] = AST.ALERT_STATE_NAME, 
			[TimeDue] = A.TIME_DUE, 
			[Version] = SV.[VERSION], 
			[VersionDescription] = SV.VERSION_DESC,
			[Build] = SB.BUILD, 
			[BuildDescription] = SB.BUILD_DESC,
			[CommentUserCode] = ACOM.USER_CODE, 
			[CommentDate] = ACOM.GENERATED_DATE, 
			[State] = ASTC.ALERT_STATE_NAME,
			[Comment] = REPLACE(REPLACE(dbo.advfn_strip_html(ACOM.COMMENT), CHAR(13), ''), CHAR(10), ''),
			[AssignedEmployeeCode] = ACOM.ASSIGNED_EMP_CODE,
			[AssignedEmployee] = CASE WHEN ACOM.ASSIGNED_EMP_CODE IS NULL THEN NULL ELSE COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,'') END,
			[LastModifiedDate] = A.LAST_UPDATED,
			[LastModifiedByEmployee] = A.LAST_UPDATED_FML,
			[AssignmentCompleted] = CASE WHEN A.ASSIGN_COMPLETED = 1 THEN 'Yes' ELSE 'No' END,
			[WorkItem] = CASE WHEN A.IS_WORK_ITEM = 1 THEN 'Yes' ELSE 'No' END,
			[IsRouted] = CASE WHEN A.ALRT_NOTIFY_HDR_ID IS NOT NULL THEN 'Yes' ELSE 'No' END,
			[CSReview] = CASE WHEN A.IS_CS_REVIEW = 1 THEN 'Yes' ELSE 'No' END,
			[HoursAllowed] = ISNULL(HRS_ALLOWED,0),
			[BoardState] = BOARD_STATE.ALERT_STATE_NAME,
			[BacklogOrder] = A.BACKLOG_SEQ_NBR,
			[CustodyStartDate] = ACOM.GENERATED_DATE,
			[CustodyEndDate] = ACOM.CUSTODY_END,
			[DaysInCustody] = DATEDIFF(day,ACOM.GENERATED_DATE,ACOM.CUSTODY_END),
			[HoursInCustody] = DATEDIFF(minute,ACOM.GENERATED_DATE,ACOM.CUSTODY_END)/60.0,
			[MinutesInCustody] = DATEDIFF(minute,ACOM.GENERATED_DATE,ACOM.CUSTODY_END),
			[IsSystemGenerated] = CASE WHEN ACOM.IS_SYSTEM = 1 THEN 'Yes' ELSE 'No' END,
			[ClientContactCode] = CCH.CONT_CODE,
			[ClientContactName] = CCH.CONT_FML
		FROM
			[dbo].[ALERT] AS A WITH(NOLOCK) INNER JOIN 
			[dbo].[ALERT_TYPE] AS AT WITH(NOLOCK) ON A.ALERT_TYPE_ID = AT.ALERT_TYPE_ID INNER JOIN 
			[dbo].[ALERT_CATEGORY] AS AC WITH(NOLOCK) ON A.ALERT_CAT_ID = AC.ALERT_CAT_ID LEFT OUTER JOIN 
			[dbo].[ALERT_STATES] AS AST WITH(NOLOCK) ON A.ALERT_STATE_ID = AST.ALERT_STATE_ID LEFT OUTER JOIN 
			[dbo].[ALERT_NOTIFY_HDR] AS ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN 
			[dbo].[ALERT_COMMENT] AS ACOM WITH(NOLOCK) ON A.ALERT_ID = ACOM.ALERT_ID  LEFT OUTER JOIN 
			[dbo].[ALERT_STATES] AS ASTC WITH(NOLOCK) ON ACOM.ALERT_STATE_ID = ASTC.ALERT_STATE_ID LEFT OUTER JOIN 
			[dbo].[SOFTWARE_VERSION] AS SV WITH(NOLOCK) ON SV.VERSION_ID = A.VER LEFT OUTER JOIN 
			[dbo].[SOFTWARE_BUILD] AS SB WITH(NOLOCK) ON SB.VERSION_ID = A.VER AND
											SB.BUILD_ID = A.BUILD LEFT OUTER JOIN 
			[dbo].[EMPLOYEE_CLOAK] AS EMP WITH(NOLOCK) ON EMP.EMP_CODE = ACOM.ASSIGNED_EMP_CODE LEFT OUTER JOIN
			[dbo].[ALERT_STATES] AS BOARD_STATE WITH(NOLOCK) ON A.BOARD_STATE_ID = BOARD_STATE.ALERT_STATE_ID LEFT OUTER JOIN
			[dbo].[CLIENT] AS C WITH(NOLOCK) ON A.CL_CODE = C.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D WITH(NOLOCK) ON A.CL_CODE = D.CL_CODE AND A.DIV_CODE = D.DIV_CODE  LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P WITH(NOLOCK) ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE LEFT OUTER JOIN
		    [dbo].[JOB_LOG] AS J WITH(NOLOCK) ON J.JOB_NUMBER = A.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[JOB_COMPONENT] AS JC WITH(NOLOCK) ON A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN
			[dbo].[CDP_CONTACT_HDR] AS CCH WITH(NOLOCK) ON JC.CDP_CONTACT_ID = CCH.CDP_CONTACT_ID
		WHERE A.[LAST_UPDATED] BETWEEN @START_DATE AND CONVERT(DATETIME, @END_DATE +' 23:59:00', 101)
			  AND A.ALERT_CAT_ID <> 71
	End
	
	

END	

