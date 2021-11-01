
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_load_drpt_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_load_drpt_expense]
GO


CREATE PROCEDURE [dbo].[advsp_load_drpt_expense]
	@DATE_TYPE AS int,
	@START_DATE AS smalldatetime,
	@END_DATE AS smalldatetime,
	@SHOW_JOBS_WO_DETAILS AS bit
AS

	SELECT 
			[ID] = NEWID(),
			[InvoiceNumber] = EH.INV_NBR,
			[InvoiceDate] = EH.INV_DATE,
			[EmployeeCode] = EH.EMP_CODE, 
			[Employee] = CASE WHEN E.EMP_MI IS NULL OR E.EMP_MI = '' THEN E.EMP_FNAME + ' ' + E.EMP_LNAME ELSE E.EMP_FNAME + ' ' + E.EMP_MI + '. ' + E.EMP_LNAME END, 
			[EmployeeOfficeCode] = E.OFFICE_CODE,
			[EmployeeOfficeDescription] = O.OFFICE_NAME,
			[VendorCode] = EH.VN_CODE,
			[VendorName] = V.VN_NAME,
			[ExpenseDescription] = ISNULL(EH.EXP_DESC,''),
			[ExpenseDetail] = ISNULL(DTL_DESC,''),
			[Status] = CASE WHEN ISNULL(EH.[STATUS],0) = 0 THEN 'Open'
			                WHEN ISNULL(EH.[STATUS],0) = 1 AND ISNULL(EH.SUBMITTED_FLAG,0) = 0 THEN 'Pending'
			                WHEN ISNULL(EH.[STATUS],0) = 1 AND ISNULL(EH.SUBMITTED_FLAG,0) = 1 AND ISNULL(EH.APPROVED_FLAG,0) = 2 THEN 'Approved by Supervisor, Pending Approval in Accounting'
			                WHEN ISNULL(EH.[STATUS],0) = 1 AND ISNULL(EH.APPROVED_FLAG,0) = 0 THEN 'Pending Approval'
			                WHEN ISNULL(EH.[STATUS],0) = 1 AND ISNULL(EH.APPROVED_FLAG,0) = 1 THEN 'Denied By Approver'
			                WHEN ISNULL(EH.[STATUS],0) = 1 AND ISNULL(EH.APPROVED_FLAG,0) > 1 THEN 'Approved By Approver'
			                WHEN ISNULL(EH.[STATUS],0) = 2 AND ISNULL(EH.APPROVED_FLAG,0) = 0 THEN 'Approved'
			                WHEN ISNULL(EH.[STATUS],0) = 2 AND ISNULL(EH.APPROVED_FLAG,0) > 0 THEN 'Approved In Accounting'
			                WHEN ISNULL(EH.[STATUS],0) = 4 THEN 'Pending Approval In Accounting'
			                WHEN ISNULL(EH.[STATUS],0) = 5 THEN 'Denied By Accounting'
							ELSE 'Open' END,
			[Approved] = CASE WHEN ISNULL(EH.APPROVED_FLAG,0) = 0 THEN ''
							  WHEN ISNULL(EH.APPROVED_FLAG,0) = 1 THEN 'Denied'
							  WHEN ISNULL(EH.APPROVED_FLAG,0) = 2 THEN 'Approved' ELSE '' END,
			[ApprovedDate] = EH.APPROVED_DATE,
			[ApprovedBy] = CASE WHEN EMPA.EMP_MI IS NULL OR EMPA.EMP_MI = '' THEN EMPA.EMP_FNAME + ' ' + EMPA.EMP_LNAME ELSE EMPA.EMP_FNAME + ' ' + EMPA.EMP_MI + '. ' + EMPA.EMP_LNAME END,
			[ApprovalNotes] = ISNULL(EH.APPR_NOTES,''), 
			[Submitted] = CASE WHEN ISNULL(EH.SUBMITTED_FLAG,0) = 0 THEN 'No' ELSE 'Yes' END,
			[SubmittedTo] = CASE WHEN EMP.EMP_MI IS NULL OR EMP.EMP_MI = '' THEN EMP.EMP_FNAME + ' ' + EMP.EMP_LNAME ELSE EMP.EMP_FNAME + ' ' + EMP.EMP_MI + '. ' + EMP.EMP_LNAME END,
			[CreatedDate] = EH.CREATE_DATE,
			[CreatedByUserCode] = EH.CREATE_USER_ID,
			[ModifiedDate] = EH.MOD_DATE,
			[ModifiedByUserCode] = EH.MOD_USER_ID,

			[LineNumber] = ED.LINE_NBR,
			[ItemDate] = ED.ITEM_DATE,
			[ItemDescription] = ED.ITEM_DESC,
			[ClientCode] = ED.CL_CODE,
			[ClientName] = C.CL_NAME,
			[DivisionCode] = ED.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = ED.PRD_CODE,
			[ProductName] = P.PRD_DESCRIPTION,
			[JobNumber] = ED.JOB_NBR,
			[JobDescription] = J.JOB_DESC,
			[JobComponentNumber] = ED.JOB_COMP_NBR,
			[JobComponentDescription] = JC.JOB_COMP_DESC,
			[FunctionCode] = ED.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[Quantity] = ED.QTY,
			[Rate] = ED.RATE,
			[Amount] = ED.AMOUNT,
			[PaymentType] = CASE WHEN ISNULL(ED.PAYMENT_TYPE,-1) = 0 THEN 'Corporate Credit Card'
							     WHEN ISNULL(ED.PAYMENT_TYPE,-1) = 1 THEN 'Personal Credit Card'
							     WHEN ISNULL(ED.PAYMENT_TYPE,-1) = 2 THEN 'Cash' ELSE '' END,
			[NonBillable] = (SELECT	CASE WHEN NOBILL_FLAG = 1 THEN 'Yes' ELSE 'No' END FROM dbo.advtf_get_billing_rate(NULL, ED.ITEM_DATE, ED.FNC_CODE, ED.CL_CODE, ED.DIV_CODE, ED.PRD_CODE, NULL, F.FNC_TYPE, ED.JOB_NBR, ED.JOB_COMP_NBR, NULL))						
			
		FROM
			[dbo].[EXPENSE_HEADER] AS EH LEFT OUTER JOIN
			[dbo].[EXPENSE_DETAIL] AS ED ON EH.INV_NBR = ED.INV_NBR AND ED.LINE_NBR > 0 LEFT OUTER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = ED.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = ED.CL_CODE AND
									 D.DIV_CODE = ED.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = ED.CL_CODE AND
									P.DIV_CODE = ED.DIV_CODE AND
									P.PRD_CODE = ED.PRD_CODE LEFT OUTER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = ED.JOB_NBR LEFT OUTER JOIN 
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ED.JOB_NBR AND
										   JC.JOB_COMPONENT_NBR = ED.JOB_COMP_NBR LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ED.FNC_CODE INNER JOIN 
			EMPLOYEE E ON EH.EMP_CODE = E.EMP_CODE LEFT OUTER JOIN
			VENDOR AS V ON EH.VN_CODE = V.VN_CODE LEFT OUTER JOIN
			EMPLOYEE EMP ON EH.SUBMITTED_TO = EMP.EMP_CODE LEFT OUTER JOIN
			EMPLOYEE EMPA ON EH.APPROVED_BY = EMPA.EMP_CODE LEFT OUTER JOIN
			OFFICE O ON O.OFFICE_CODE = E.OFFICE_CODE
		WHERE	
			1 = CASE WHEN @DATE_TYPE = 0 THEN CASE WHEN EH.INV_DATE >= @START_DATE AND EH.INV_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:59', 101) THEN 1 ELSE 0 END
				 WHEN @DATE_TYPE = 1 THEN CASE WHEN EH.CREATE_DATE >= @START_DATE AND EH.CREATE_DATE <= CONVERT(DATETIME, @END_DATE +' 23:59:59', 101) THEN 1 ELSE 0 END END