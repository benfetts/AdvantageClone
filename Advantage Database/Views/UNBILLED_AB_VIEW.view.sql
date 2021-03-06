


/* ============================================================ */
/*   View: UNBILLED_AB_VIEW                                     */
/* ============================================================ */
CREATE VIEW dbo.UNBILLED_AB_VIEW ( AB_FLAG, AB_ID, ADV_BILL_NET_AMT, BILLING_USER, BILL_DATE, CALC_METHOD, CALC_PERCENT,
	COMMISSION_PCT, CREATE_DATE, ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, EST_REVISION_NBR, EXT_CITY_RESALE,
	EXT_COUNTY_RESALE, EXT_MARKUP_AMT, EXT_NONRESALE_TAX, EXT_STATE_RESALE, FINAL_AB_FLAG, FINAL_AB_ID, FINAL_DATE,
	FINAL_SEQ_NBR, FINAL_USER, FNC_CODE, FNC_TYPE, JOB_COMPONENT_NBR, JOB_NUMBER, LINE_TOTAL, METHOD_DESC, SEQ_NBR,
	TAX_CITY_PCT, TAX_CODE, TAX_COMM, TAX_COMM_ONLY, TAX_COUNTY_PCT, TAX_RESALE, TAX_STATE_PCT, USER_ID, USE_CONTINGENCY) 
AS
 SELECT ALL AB_FLAG, 
	AB_ID, 
	ADV_BILL_NET_AMT, 	
	BILLING_USER, 
	BILL_DATE, 
	CALC_METHOD, 
	CALC_PERCENT, 
	COMMISSION_PCT, 
	CREATE_DATE, 
	ESTIMATE_NUMBER, 
	EST_COMPONENT_NBR, 
	EST_QUOTE_NBR, 
	EST_REVISION_NBR, 
	EXT_CITY_RESALE, 
	EXT_COUNTY_RESALE, 
	EXT_MARKUP_AMT, 
	EXT_NONRESALE_TAX, 
	EXT_STATE_RESALE, 
	FINAL_AB_FLAG, 
	FINAL_AB_ID, 
	FINAL_DATE, 
	FINAL_SEQ_NBR, 
	FINAL_USER, 
	FNC_CODE, 
	FNC_TYPE, 
	JOB_COMPONENT_NBR, 
	JOB_NUMBER, 
	LINE_TOTAL, 
	METHOD_DESC, 
	SEQ_NBR, 
	TAX_CITY_PCT, 
	TAX_CODE, 
	TAX_COMM, 
	TAX_COMM_ONLY, 
	TAX_COUNTY_PCT, 
	TAX_RESALE, 
	TAX_STATE_PCT, 
	USER_ID, 
	USE_CONTINGENCY 
   FROM ADVANCE_BILLING 
  WHERE AR_INV_NBR IS NULL 
    AND ( AB_FLAG IS NULL OR AB_FLAG !=3 )



