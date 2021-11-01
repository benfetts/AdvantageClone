CREATE PROCEDURE [dbo].[advsp_po_export]

	@DATE_START smalldatetime,
	@DATE_END smalldatetime,
	@DATE_TYPE smallint -- 0 = Create Date, 1 = PO Date, 2 = PO Due Date
	
AS

BEGIN

	SET NOCOUNT ON
	
	SELECT
		[Number] = po.PO_NUMBER,
		[CreateDate] = po.PO_CREATE_DATE,
		[UserID] = po.[USER_ID],
		[VendorCode] = po.VN_CODE,
		[EmployeeCode] = po.EMP_CODE,
		[PODate] = po.PO_DATE,
		[PODueDate] = po.PO_DUE_DATE,
		[Description] = po.PO_DESCRIPTION,
		[MainInstruction] = po.PO_MAIN_INSTRUCT,
		[IsComplete] = CAST(COALESCE(po.PO_COMPLETE,0) as bit),
		[DeliveryInstruction] = po.DEL_INSTRUCT,
		[IsVoided] = CAST(COALESCE(po.VOID_FLAG,0) as bit),
		[VoidBy] = po.VOIDED_BY,
		[VoidDate] = po.VOID_DATE,
		[Revision] = po.PO_REVISION,
		[IsWorkComplete] = CAST(COALESCE(po.PO_WORK_COMPLETE,0) as bit),
		[VendorContactCode] = po.VN_CONT_CODE,
		[Footer] = po.PO_FOOTER,
		[WVFlag] = po.WV_FLAG,
		[ApprovalFlag] = po.PO_APPROVAL_FLAG,
		[IsPrinted] = CAST(COALESCE(po.PO_PRINTED,0) as bit),
		[PurchaseOrderApprovalRuleCode] = po.PO_APPR_RULE_CODE,
		[ExceedFlag] = CAST(COALESCE(po.EXCEED,0) as bit),
		[ModifiedByUserCode] = po.USER_MODIFIED,
		[ModifiedDate] = po.MODIFIED_DATE,
		[DetailDescription] = pod.DET_DESC,
		[LineNumber] = pod.LINE_NUMBER,
		[LineDescription] = pod.LINE_DESC,
		[Instructions] = pod.DET_INSTRUCT,
		[Quantity] = pod.PO_QTY,
		[Rate] = pod.PO_RATE,
		[ExtendedAmount] = pod.PO_EXT_AMOUNT,
		[TaxPercent] = pod.PO_TAX_PCT,
		[DetailIsComplete] = CAST(COALESCE(pod.PO_COMPLETE,0) as bit),
		[JobNumber] = pod.JOB_NUMBER,
		[JobComponentNumber] = pod.JOB_COMPONENT_NBR,
		[FunctionCode] = pod.FNC_CODE,
		[CommissionPercent] = pod.PO_COMM_PCT,
		[ExtendedMarkupAmount] = pod.EXT_MARKUP_AMT,
		[GLACode] = pod.GLACODE
	FROM dbo.PURCHASE_ORDER po
		INNER JOIN dbo.PURCHASE_ORDER_DET pod ON po.PO_NUMBER = pod.PO_NUMBER 
	WHERE
		( @DATE_TYPE = 0 AND po.PO_CREATE_DATE BETWEEN @DATE_START AND @DATE_END )
	OR	( @DATE_TYPE = 1 AND po.PO_DATE BETWEEN @DATE_START AND @DATE_END )
	OR	( @DATE_TYPE = 2 AND po.PO_DUE_DATE BETWEEN @DATE_START AND @DATE_END )

END

GO