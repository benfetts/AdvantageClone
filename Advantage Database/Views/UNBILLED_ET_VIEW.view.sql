﻿


/* ============================================================ */
/*   View: UNBILLED_ET_VIEW                                     */
/* ============================================================ */
CREATE VIEW dbo.UNBILLED_ET_VIEW ( AB_FLAG, AB_ID, ADJ_COMMENTS, BILLING_USER, BILL_HOLD_FLG, DATE_ENTERED, DP_TM_CODE,
	EDIT_FLAG, EMP_BILL_RATE, EMP_COMMENT, EMP_COMM_PCT, EMP_COST_RATE, EMP_HOURS, EMP_NON_BILL_FLAG, EMP_RATE_FROM,
	ET_ID, EXT_CITY_RESALE, EXT_COUNTY_RESALE, EXT_MARKUP_AMT, EXT_STATE_RESALE, FNC_CODE, JOB_COMPONENT_NBR, JOB_NUMBER,
	LINE_TOTAL, SEQ_NBR, TAX_CITY_PCT, TAX_CODE, TAX_COMM, TAX_COMM_ONLY, TAX_COUNTY_PCT, TAX_RESALE, TAX_STATE_PCT,
	TOTAL_BILL, TOTAL_COST, USER_ID) 
AS
 SELECT ALL AB_FLAG, 
	AB_ID, 
	ADJ_COMMENTS, 
	BILLING_USER, 
	BILL_HOLD_FLG, 
	DATE_ENTERED, 
	DP_TM_CODE, 
	EDIT_FLAG, 
	EMP_BILL_RATE, 
	EMP_COMMENT, 
	EMP_COMM_PCT, 
	EMP_COST_RATE, 
	EMP_HOURS, 
	EMP_NON_BILL_FLAG, 
	EMP_RATE_FROM, 
	ET_ID, 
	EXT_CITY_RESALE, 
	EXT_COUNTY_RESALE, 
	EXT_MARKUP_AMT, 
	EXT_STATE_RESALE, 
	FNC_CODE, 
	JOB_COMPONENT_NBR, 
	JOB_NUMBER, 
	LINE_TOTAL, 
	SEQ_NBR, 
	TAX_CITY_PCT, 
	TAX_CODE, 
	TAX_COMM, 
	TAX_COMM_ONLY, 
	TAX_COUNTY_PCT, 
	TAX_RESALE, 
	TAX_STATE_PCT, 
	TOTAL_BILL, 
	TOTAL_COST, 
	USER_ID 
   FROM EMP_TIME_DTL 
  WHERE AR_INV_NBR IS NULL 
    AND ( AB_FLAG IS NULL OR AB_FLAG !=3 ) 
    AND ( EMP_NON_BILL_FLAG IS NULL OR EMP_NON_BILL_FLAG=0 )



