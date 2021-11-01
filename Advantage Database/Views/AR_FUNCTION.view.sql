CREATE VIEW [dbo].[AR_FUNCTION]

WITH SCHEMABINDING 
AS 

	SELECT 
		AR_FUNCTION_ID, 
		BILLING_USER,
		AR_INV_NBR,
		DRAFT_INV_NBR,
		DRAFT_INV_SEQ = AR_INV_SEQ,
		COOP_CODE,
		COOP_PCT,
		MANUAL_FLAG,
		ORDER_NBR,
		ORDER_LINE_NBR,
		MEDIA_TYPE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		JOB_AB_FLAG,
		AR_DESCRIPTION,
		CL_CODE,
		DIV_CODE,
		PRD_CODE,
		OFFICE_CODE,
		SC_CODE,
		CMP_IDENTIFIER,
		CLIENT_PO,
		FNC_CODE,
		FNC_TYPE,
		SALE_POST_PERIOD,
		TAX_CODE,
		INV_TAX_FLAG,
		INV_BY,
		BILL_COMM_NET,
		AB_REC_FLAG,
		MED_REC_FLAG,
		HRS_QTY,
		MARKET_CODE,
		MEDIA_MONTH,
		MEDIA_YEAR,
		[START_DATE],
		[END_DATE],
		EMP_TIME_AMT = COALESCE(EMP_TIME_AMT, 0.00),
		INC_ONLY_AMT = COALESCE(INC_ONLY_AMT, 0.00),
		COMMISSION_AMT = COALESCE(COMMISSION_AMT, 0.00),
		REBATE_AMT = COALESCE(REBATE_AMT, 0.00),
		COST_AMT = COALESCE(COST_AMT, 0.00),
		NET_CHARGE_AMT = COALESCE(NET_CHARGE_AMT, 0.00),
		NON_RESALE_AMT = COALESCE(NON_RESALE_AMT, 0.00),
		DISCOUNT_AMT = COALESCE(DISCOUNT_AMT, 0.00),
		ADDITIONAL_AMT = COALESCE(ADDITIONAL_AMT, 0.00),
		AB_COST_AMT = COALESCE(AB_COST_AMT, 0.00),
		AB_INC_AMT = COALESCE(AB_INC_AMT, 0.00),
		AB_COMMISSION_AMT = COALESCE(AB_COMMISSION_AMT, 0.00), 
		AB_SALE_AMT = COALESCE(AB_SALE_AMT, 0.00),
		AB_NONRESALE_AMT = COALESCE(AB_NONRESALE_AMT, 0.00),
		CITY_TAX_AMT = COALESCE(CITY_TAX_AMT, 0.00),
		CNTY_TAX_AMT = COALESCE(CNTY_TAX_AMT, 0.00),
		STATE_TAX_AMT = COALESCE(STATE_TAX_AMT, 0.00),
		TOTAL_BILL = COALESCE(TOTAL_BILL, 0.00),
		CURRENCY_CODE,
		CURRENCY_RATE
	FROM 
		dbo.W_AR_FUNCTION
	WHERE 
		SUMMARY_FLAG = 0


GO