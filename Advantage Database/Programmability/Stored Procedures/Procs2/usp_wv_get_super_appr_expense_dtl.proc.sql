--DROP PROCEDURE usp_wv_get_super_appr_expense_dtl
CREATE PROCEDURE usp_wv_get_super_appr_expense_dtl
@INV_NBR INTEGER
AS
BEGIN
	SELECT 
		ED.ITEM_DATE,
		CDP = JL.CL_CODE + '/' + JL.DIV_CODE + '/' +  JL.PRD_CODE,
		JOBCOMPDESC = STR(JL.JOB_NUMBER) + ' - ' + JL.JOB_DESC + '<br />' + str(JC.JOB_COMPONENT_NBR) + ' - ' + JC.JOB_COMP_DESC, 
		FUNCTIONS.FNC_DESCRIPTION,
		ED.QTY, 
		ED.RATE, 
		ED.AMOUNT, 
		CASE WHEN ED.CC_FLAG IS NULL THEN CASE WHEN PAYMENT_TYPE = 0 THEN 1 ELSE 0 END ELSE ED.CC_FLAG END AS CC_FLAG, 
		CASE
			WHEN ED.CC_FLAG IS NULL THEN CASE WHEN PAYMENT_TYPE = 1 THEN ED.AMOUNT ELSE 0 END
			WHEN ED.CC_FLAG = 0 THEN ED.AMOUNT 
			ELSE 0.00 
		END AS PAYABLE,
		ED.ITEM_DESC, 
		ISNULL(ED.FNC_CODE, '') AS FNC_CODE,
		ISNULL(ED.JOB_NBR, 0) AS JOB_NBR,
		ISNULL(ED.JOB_COMP_NBR, 0) AS JOB_COMP_NBR,
		ID = ED.EXPDETAILID,
		ExpenseDetailID = ED.EXPDETAILID,
		LineNumber = ED.LINE_NBR,
		ItemDate = ED.ITEM_DATE,
		CDPDisplay = JL.CL_CODE + '/' + JL.DIV_CODE + '/' +  JL.PRD_CODE,
		JobDisplay = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JL.JOB_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3) + ' - ' + JC.JOB_COMP_DESC,
		FunctionDescription = FUNCTIONS.FNC_DESCRIPTION,
		Quantity = ISNULL(ED.QTY, 0), 
		Rate = ISNULL(ED.RATE, 0.00), 
		Amount = ISNULL(ED.AMOUNT, 0.00), 
		IsCcYN = CASE 
					  WHEN ED.CC_FLAG IS NULL THEN CASE WHEN PAYMENT_TYPE = 0 THEN 'Yes' ELSE 'No' END
					  WHEN ED.CC_FLAG = 1 THEN 'Yes'
					  ELSE 'No'
				 END, 
		Payable = CASE 
					WHEN ED.CC_FLAG IS NULL THEN CASE WHEN PAYMENT_TYPE = 1 THEN ED.AMOUNT ELSE 0 END
					WHEN ED.CC_FLAG = 0 THEN ED.AMOUNT 
					ELSE 0.00 
				  END,
		[Description] = ED.ITEM_DESC, 
		FunctionCode = ISNULL(ED.FNC_CODE, ''),
		JobNumber = ISNULL(ED.JOB_NBR, 0),
		JobComponentNumber = ISNULL(ED.JOB_COMP_NBR, 0)
	FROM 
		EXPENSE_DETAIL ED WITH(NOLOCK)
		LEFT OUTER JOIN JOB_LOG JL WITH(NOLOCK) ON JL.JOB_NUMBER = ED.JOB_NBR
		LEFT OUTER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON JC.JOB_NUMBER = ED.JOB_NBR AND JC.JOB_COMPONENT_NBR = ED.JOB_COMP_NBR 
		LEFT OUTER JOIN FUNCTIONS WITH(NOLOCK) ON ED.FNC_CODE = FUNCTIONS.FNC_CODE
	WHERE 
		ED.INV_NBR = @INV_NBR
		AND ED.CREATE_USER_ID IS NOT NULL;
END
