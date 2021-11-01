if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_detail_analysis_qva_detail_load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_detail_analysis_qva_detail_load]
GO

CREATE PROCEDURE [dbo].[advsp_job_detail_analysis_qva_detail_load]
@JobNum Varchar(6),
@JobComp Varchar(6),
@FunctionCode Varchar(6)


AS
BEGIN

	DECLARE	@INCLUDE_SALES_TAX BIT
	SET @INCLUDE_SALES_TAX = 0


	DECLARE @HAS_EST_APPR   AS INTEGER,
			@HAS_EST_INT_APPR  AS INTEGER
	--IF EXISTS(SELECT JOB_NUMBER FROM ESTIMATE_APPROVAL WHERE JOB_NUMBER = @JobNum AND JOB_COMPONENT_NBR = @JobComp)
	--BEGIN
	--	SET @HAS_EST_APPR = 1
	--END
	--ELSE
	--BEGIN
	--	SET @HAS_EST_APPR = 0
	--END
	--IF EXISTS(SELECT JOB_NUMBER FROM ESTIMATE_INT_APPR WHERE JOB_NUMBER = @JobNum AND JOB_COMPONENT_NBR = @JobComp)
	--BEGIN
	--	SET @HAS_EST_INT_APPR = 1
	--END
	--ELSE
	--BEGIN
	--	SET @HAS_EST_INT_APPR = 0
	--END

--if @HAS_EST_APPR = 1
--BEGIN
--SELECT A.cc_fnc_code AS FunctionCode,
--	   A.cc_fnc_desc AS FunctionDescription,
--	   A.cc_fnc_type AS FunctionType,
--		A.cc_est AS Estimate,
--		A.cc_date AS ItemDate,
--		A.cc_dve_field AS ItemDescription,
--		A.cc_ref_invoice AS InvoiceReference,
--		A.cc_est_hrs AS EstimateQuantity,
--		A.cc_est_amount AS EstimateAmount,
--		A.cc_est_tax AS EstimateTax, 
--		A.cc_est_total AS EstimateTotal,
--		A.cc_est_mkp AS EstimateMarkup,
--		A.cc_actual_hrs AS ActualHours,
--		A.cc_actual_amount AS ActualAmount,
--		A.cc_actual_tax AS ActualTax,
--		A.cc_actual_total AS ActualTotal,
--		A.cc_actual_mkp AS ActualMarkup,
--		A.cc_billed AS Billed,
--		A.cc_open_po AS OpenPOAmount,
--		A.cc_ar_inv_nbr AS ARInvoiceNumber,
--		A.cc_supplier_code AS SuppliedByCode,
--		A.cc_nonbill_flag AS NonBillable,
--		A.cc_adj_date AS AdjustedDate,
--		A.cc_adj_comment AS AdjustedComment,
--		A.cc_rec_id AS RecID,
--		A.cc_seq AS SequenceNumber,
--		A.cc_group AS GroupDescription,
--		A.cc_fnc_name AS FunctionTypeDescription,
--		A.cc_fnc_headingid AS FunctionHeadingID,
--		A.cc_fnc_headingdesc AS FunctionHeadingDescription,
--		A.cc_fnc_consolidationcode AS FunctionConsolidationCode,
--		A.cc_fnc_consolidationname AS FunctionConsolidationDescription,
--		A.JOB_NUMBER AS JobNumber,
--		A.JOB_COMPONENT_NBR AS JobComponentNumber
--	 FROM
--(
--SELECT cc_fnc_code = ESTIMATE_REV_DET.FNC_CODE,  
--cc_fnc_desc = CAST( 'Estimate Total:' AS varchar(30)),   
--cc_fnc_type = ESTIMATE_REV_DET.EST_FNC_TYPE,
--cc_est = CAST( 1 AS integer ),   
--cc_date = CAST( NULL AS smalldatetime ),   
--cc_dve_field = CAST( NULL AS varchar(40)),   
--cc_ref_invoice = CAST( NULL AS varchar(30)),   
--cc_est_hrs = SUM( COALESCE( ESTIMATE_REV_DET.EST_REV_QUANTITY, 0 )),   
--cc_est_amount = SUM( COALESCE( ESTIMATE_REV_DET.EST_REV_EXT_AMT, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_NONRESALE_TAX, 0 )),   
--cc_est_tax = SUM( COALESCE( ESTIMATE_REV_DET.EXT_CITY_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_STATE_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_COUNTY_RESALE, 0 )),   
--cc_est_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN SUM( COALESCE( ESTIMATE_REV_DET.LINE_TOTAL, 0 )) ELSE 
--	SUM( COALESCE( ESTIMATE_REV_DET.LINE_TOTAL, 0 )) - (SUM( COALESCE( ESTIMATE_REV_DET.EXT_CITY_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_STATE_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_COUNTY_RESALE, 0 ))) END,
--cc_est_mkp = SUM( COALESCE( ESTIMATE_REV_DET.EXT_MARKUP_AMT, 0 )),   
--cc_actual_hrs = CAST( NULL AS decimal(15,2)),   
--cc_actual_amount = CAST( NULL AS decimal(15,2)),   
--cc_actual_tax = CAST( NULL AS decimal(15,2)),   
--cc_actual_total = CAST( NULL AS decimal(15,2)),   
--cc_actual_mkp = CAST( NULL AS decimal(15,2)),
--cc_billed = CAST( NULL AS decimal(15,2)),   
--cc_open_po = CAST( NULL AS decimal(15,2)),
--cc_ar_inv_nbr = CAST( NULL AS integer ),
--cc_supplier_code = CAST( '''' AS varchar(6)),
--cc_nonbill_flag = CAST( NULL AS integer ),
--cc_adj_date = CAST( NULL AS smalldatetime ),
--cc_adj_comment = '', 
--cc_rec_id = CAST( 0 AS integer ),
--cc_seq = CAST( 0 AS integer ),
--cc_group = FUNCTIONS.FNC_DESCRIPTION,
--cc_fnc_name = CASE WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'E' THEN 'Employee Time'
--				   WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'V' THEN 'Accounts Payable'
--				   WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = FUNCTIONS.FNC_HEADING_ID,
--cc_fnc_headingdesc = FNC_HEADING.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN ESTIMATE_REV_DET.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN FC.FNC_CONSOLIDATION IS NULL THEN FUNCTIONS.FNC_DESCRIPTION ELSE FC.FNC_DESCRIPTION END,
--JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
--FROM JOB_COMPONENT
--  INNER JOIN ESTIMATE_APPROVAL ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
--  	    AND ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
--  INNER JOIN ESTIMATE_REV_DET ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER
--  		AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR
--  		AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR
--  		AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR 
--  INNER JOIN FUNCTIONS ON FUNCTIONS.FNC_CODE = ESTIMATE_REV_DET.FNC_CODE LEFT OUTER JOIN
--		FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
--		FUNCTIONS FC ON FC.FNC_CODE = FUNCTIONS.FNC_CONSOLIDATION  	

--WHERE JOB_COMPONENT.JOB_NUMBER =  @JobNum  AND JOB_COMPONENT.JOB_COMPONENT_NBR =   @JobComp
--GROUP BY  ESTIMATE_REV_DET.EST_FNC_TYPE, ESTIMATE_REV_DET.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, FUNCTIONS.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FUNCTIONS.FNC_CONSOLIDATION, FC.FNC_CONSOLIDATION,FC.FNC_DESCRIPTION,
--		  JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR

--UNION 

--SELECT cc_fnc_code =  f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = aph.AP_INV_DATE ,
--	cc_dve_field = v.VN_NAME,
--	cc_ref_invoice = CASE WHEN aph.AP_DESC IS NULL OR aph.AP_DESC = '' THEN aph.AP_INV_VCHR ELSE aph.AP_INV_VCHR + ' / ' + aph.AP_DESC END,
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = AP_PROD_QUANTITY,
--	cc_actual_amount = AP_PROD_EXT_AMT + EXT_NONRESALE_TAX,
--	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
--	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE + EXT_NONRESALE_TAX) END,
--	cc_actual_mkp = EXT_MARKUP_AMT,
--	cc_billed = CASE 
--			WHEN AR_INV_NBR IS NULL THEN 0.00 
--			ELSE LINE_TOTAL 
--		END,
--	cc_open_po = NULL,
--	cc_ar_inv_nbr =AR_INV_NBR,
--	cc_supplier_code = aph.VN_FRL_EMP_CODE,
--	cc_nonbill_flag = AP_PROD_NOBILL_FLG,
--	cc_adj_date = CAST(ap.XFER_ADJ_DATE AS smalldatetime),
--	cc_adj_comment = CASE
--				WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
--				WHEN ap.WRITE_OFF = 1 THEN 'Write Off '+ COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '') + ' - ' + CAST(ap.ADJ_COMMENTS AS varchar(5000))
--				WHEN ap.XFER_ADJ_DATE IS NOT NULL THEN
--				CASE
--					WHEN RTRIM(LTRIM(SUBSTRING(ap.ADJ_COMMENTS, 1, 100))) = '' THEN
--						CASE WHEN ap.XFER_FROM_JOB IS NOT NULL THEN 'Transferred From Job ' + CAST(ap.XFER_FROM_JOB AS varchar(6)) + '-' + CAST(ap.XFER_FROM_JOB_COMP AS varchar(2))
--									+ ' ' +COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '')
--										ELSE
--										'Transfer/Adjustment/Write Off '+ COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '')
--										END
--					ELSE
--							CAST(ap.ADJ_COMMENTS AS VARCHAR(500))
--					END
--					WHEN ap.MODIFY_DELETE = 1 AND (ap.DELETE_FLAG = 0 or ap.DELETE_FLAG IS NULL) THEN 'Modified'
--						ELSE ''
--					END,
--	cc_rec_id = ap.AP_ID,
--	cc_seq = ap.LINE_NUMBER,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN ap.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM AP_PRODUCTION ap, 
--			FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION, 
--			AP_HEADER aph,
--			VENDOR v,
--			JOB_COMPONENT jc
--WHERE ap.JOB_NUMBER = jc.JOB_NUMBER
--	  AND ap.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--	  AND ap.FNC_CODE = f.FNC_CODE
--	  AND ap.AP_ID = aph.AP_ID
--	  AND ap.AP_SEQ = aph.AP_SEQ
--	  AND v.VN_CODE = aph.VN_FRL_EMP_CODE
--	  AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp
	  
--UNION

--SELECT f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = et.EMP_DATE,
--	cc_dve_field = COALESCE( RTRIM( EMP_FNAME ) + ' ', '' ) + COALESCE( EMP_MI + '. ', '' ) + COALESCE( EMP_LNAME, '' ),
--	cc_ref_invoice = '',
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = etd.EMP_HOURS,
--	cc_actual_amount = TOTAL_BILL,
--	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
--	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
--	cc_actual_mkp = EXT_MARKUP_AMT,
--	cc_billed = CASE 
--			WHEN AR_INV_NBR IS NULL THEN 0.00 
--			ELSE LINE_TOTAL 
--		    END,
--	cc_open_po = NULL, 
--	AR_INV_NBR,
--	emp.EMP_CODE,
--	EMP_NON_BILL_FLAG,
--	cc_adj_date = CAST(etd.XFER_ADJ_DATE AS smalldatetime),
--	cc_adj_comment = CASE
--						WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
--						WHEN etd.XFER_ADJ_DATE IS NOT NULL THEN
--							CASE WHEN CAST(etd.ADJ_COMMENTS AS VARCHAR(100)) = '' THEN 'Transferred ' + 
--									CASE WHEN etd.XFER_FROM_JOB IS NOT NULL THEN 'From Job ' + CAST( etd.XFER_FROM_JOB AS varchar(6)) + '-' + CAST( etd.XFER_FROM_JOB_COMP AS varchar(2)) + ' '
--										ELSE
--											''
--									END
--									+ CONVERT(varchar(11), etd.XFER_ADJ_DATE, 101) + ' by ' + etd.XFER_ADJ_USER
--								ELSE CAST(etd.ADJ_COMMENTS AS VARCHAR(500))
--								END
--							ELSE ''
--							END,
--	cc_rec_id = etd.ET_ID,
--	cc_seq = etd.SEQ_NBR,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN etd.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM EMP_TIME_DTL etd, 
--	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION, 
--	EMP_TIME et, 
--	EMPLOYEE emp,
--	JOB_COMPONENT jc
--WHERE etd.JOB_NUMBER = jc.JOB_NUMBER
--  AND etd.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--  AND etd.FNC_CODE = f.FNC_CODE
--  AND et.ET_ID = etd.ET_ID
--  AND et.EMP_CODE = emp.EMP_CODE 
--AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp

--UNION 

--SELECT f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = IO_INV_DATE,
--	cc_dve_field = IO_DESC,
--	cc_ref_invoice = IO_INV_NBR,
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = IO_QTY,
--	cc_actual_amount = IO_AMOUNT,
--	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
--	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
--	cc_actual_mkp = EXT_MARKUP_AMT,
--	cc_billed = CASE 
--			WHEN AR_INV_NBR IS NULL THEN 0.00 
--			ELSE LINE_TOTAL 
--		    END, 
--	cc_open_po = NULL,
--	AR_INV_NBR,
--	cc_supplier_code = '',
--	NON_BILL_FLAG,
--	cc_adj_date = CAST(io.XFER_ADJ_DATE AS smalldatetime),
--	cc_adj_comment = CASE
--						WHEN AR_TYPE = 'VO' THEN ' Void Invoice'
--						WHEN io.XFER_ADJ_USER IS NOT NULL THEN
--							CASE WHEN RTRIM(LTRIM(SUBSTRING(io.ADJ_COMMENTS, 1, 100))) = '' THEN
--								CASE WHEN io.XFER_FROM_JOB IS NOT NULL THEN 'Transferred From Job ' + CAST(io.XFER_FROM_JOB AS varchar(6)) + '-' + CAST(io.XFER_FROM_JOB_COMP AS varchar(2))
--									+ ' ' +COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '')
--								ELSE
--									'Transfer/Adjustment ' + COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '')
--								END
--							ELSE COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '') + CAST(io.ADJ_COMMENTS AS varchar(5000))
--							END
--						WHEN MODIFY_FLAG = 1 THEN 'Modified'
--					ELSE ''
--					END,
--	cc_rec_id = io.IO_ID,
--	cc_seq = io.SEQ_NBR,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN io.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM INCOME_ONLY io, 
--	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
--	JOB_COMPONENT jc
--WHERE jc.JOB_NUMBER = io.JOB_NUMBER
--  AND jc.JOB_COMPONENT_NBR = io.JOB_COMPONENT_NBR
--  AND io.FNC_CODE = f.FNC_CODE 
-- AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR =  @JobComp

--UNION 

--SELECT f.FNC_CODE,   
--    cc_fnc_desc = f.FNC_DESCRIPTION,   
--    cc_fnc_type = f.FNC_TYPE, 
--	cc_est = 0,
--    cc_date = co.INV_DATE,   
--    cc_dve_field = co.DESCRIPTION,   
--    cc_ref_invoice = co.INV_NBR,   
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = NULL,
--	cc_actual_amount = co.AMOUNT,
--	cc_actual_tax = NULL,
--	cc_actual_total = co.AMOUNT,
--	cc_actual_mkp = NULL,
--	cc_billed = NULL, 
--	cc_open_po = NULL,
--	cc_ar_inv_nbr = NULL,
--	cc_supplier_code = '',
--	cc_nonbill_flag = NULL,
--	cc_adj_date = CAST( NULL AS smalldatetime ),
--	cc_adj_comment = CASE
--						WHEN DELETE_FLAG = 1 THEN 'Deleted'
--						ELSE ''
--					END,
--	cc_rec_id = co.OOP_ID,
--	cc_seq = co.SEQ_NBR,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN co.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM CLIENT_OOP co,   
--     FUNCTIONS  f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
--     JOB_COMPONENT jc
--WHERE co.FNC_CODE = f.FNC_CODE 
--  AND co.JOB_NUMBER = jc.JOB_NUMBER
--  AND co.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
--AND jc.JOB_NUMBER =   @JobNum  AND jc.JOB_COMPONENT_NBR =  @JobComp

--UNION 

--SELECT f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = PO_DATE,
--	cc_dve_field = VN_NAME,
--	cc_ref_invoice = CASE WHEN ((po.PO_APPROVAL_FLAG = 1) OR (po.PO_APPROVAL_FLAG = 3)) 
--		AND ((po.EXCEED = 1) OR (po.EXCEED = 0) OR (po.EXCEED IS NULL)) 
--		AND ((po.PO_PRINTED = 0) OR (po.PO_PRINTED IS NULL)) 
--		AND (NOT(po.PO_APPR_RULE_CODE IS NULL)) THEN '(Pending)' 
--		WHEN (po.PO_APPROVAL_FLAG = 2) THEN 'PO# ' + CONVERT(varchar(8), pod.PO_NUMBER ) + '-LINE ' + CONVERT(varchar(3), pod.LINE_NUMBER) 
--		WHEN (NOT(po.PO_APPR_RULE_CODE IS NULL))
--		AND ((po.EXCEED = 1) OR (po.EXCEED = 0) OR (po.EXCEED IS NULL))
--		AND ((po.PO_PRINTED = 0) OR (po.PO_PRINTED IS NULL)) THEN '(Incomplete)'		
--		ELSE 'PO# ' + CONVERT(varchar(8), pod.PO_NUMBER ) + '-LINE ' + CONVERT(varchar(3), pod.LINE_NUMBER) END,
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = NULL,
--	cc_actual_amount = NULL,
--	cc_actual_tax = NULL,
--	cc_actual_total = NULL,
--	cc_actual_mkp = NULL,
--	cc_billed = NULL, 
--	cc_open_po = PO_EXT_AMOUNT - (SELECT ISNULL(SUM(dbo.AP_PRODUCTION.AP_PROD_EXT_AMT), 0.00) FROM AP_PRODUCTION WHERE pod.PO_NUMBER = AP_PRODUCTION.PO_NUMBER AND 
--							  pod.LINE_NUMBER = AP_PRODUCTION.PO_LINE_NUMBER),
--	cc_ar_inv_nbr = NULL,
--	v.VN_CODE,
--	cc_nonbill_flag = NULL,
--	cc_adj_date = CAST( NULL AS smalldatetime ),
--	cc_adj_comment = '', --CAST( NULL AS text ),
--	cc_rec_id = pod.PO_NUMBER,
--	cc_seq = pod.LINE_NUMBER,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN pod.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM PURCHASE_ORDER po, 
--	PURCHASE_ORDER_DET pod, 
--	VENDOR v, 
--	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
--	JOB_COMPONENT jc
--WHERE jc.JOB_NUMBER = pod.JOB_NUMBER
--  AND jc.JOB_COMPONENT_NBR = pod.JOB_COMPONENT_NBR
--  AND pod.FNC_CODE = f.FNC_CODE
--  AND po.PO_NUMBER = pod.PO_NUMBER
--  AND v.VN_CODE = po.VN_CODE
--  AND ( pod.PO_COMPLETE IS NULL OR pod.PO_COMPLETE = 0 ) 
--  AND ( po.VOID_FLAG IS NULL OR po.VOID_FLAG != 1 ) 
--AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp

--UNION 

--SELECT FUNCTIONS.FNC_CODE,
--	cc_fnc_desc = FUNCTIONS.FNC_DESCRIPTION,
--	cc_fnc_type = FUNCTIONS.FNC_TYPE,
--	cc_est = 0,
--	cc_date = CREATE_DATE,
--	cc_dve_field = 'Advance Billing',
--	cc_ref_invoice = '', 
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = NULL,
--	cc_actual_amount = NULL,
--	cc_actual_tax = NULL,
--	cc_actual_total = NULL,
--	cc_actual_mkp = NULL,
--	cc_billed = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
--	cc_open_po = NULL,
--	AR_INV_NBR, 
--	cc_supplier_code = '',
--	cc_nonbill_flag = NULL,
--	cc_adj_date = CAST( NULL AS smalldatetime ),
--	cc_adj_comment = CASE
--						WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
--						ELSE ''
--					END,
--	cc_rec_id = ADVANCE_BILLING.AB_ID,
--	cc_seq = ADVANCE_BILLING.SEQ_NBR,
--cc_group = FUNCTIONS.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN FUNCTIONS.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN FUNCTIONS.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN FUNCTIONS.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = FUNCTIONS.FNC_HEADING_ID,
--cc_fnc_headingdesc = FNC_HEADING.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN ADVANCE_BILLING.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN FC.FNC_CONSOLIDATION IS NULL THEN FUNCTIONS.FNC_DESCRIPTION ELSE FC.FNC_DESCRIPTION END,
--JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
--FROM JOB_COMPONENT
--	INNER JOIN ADVANCE_BILLING ON JOB_COMPONENT.JOB_NUMBER = ADVANCE_BILLING.JOB_NUMBER
--  				  AND JOB_COMPONENT.JOB_COMPONENT_NBR = ADVANCE_BILLING.JOB_COMPONENT_NBR
--	INNER JOIN FUNCTIONS ON ADVANCE_BILLING.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
--		FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
--		FUNCTIONS FC ON FC.FNC_CODE = FUNCTIONS.FNC_CONSOLIDATION  	
	
--WHERE JOB_COMPONENT.JOB_NUMBER =   @JobNum  AND JOB_COMPONENT.JOB_COMPONENT_NBR =  @JobComp
--	AND ( AR_INV_NBR IS NOT NULL OR ADVANCE_BILLING.AB_FLAG = 3 ) --AND LINE_TOTAL > 0
	
	

--) AS A
--WHERE ((NOT (A.cc_fnc_type = 'E' AND cc_actual_hrs = 0)) OR cc_actual_hrs IS NULL) AND A.cc_fnc_desc <> 'Estimate Total:'
--ORDER BY A.cc_fnc_type, A.cc_fnc_code, A.cc_est, A.cc_fnc_desc, A.cc_date DESC 
--END

--IF @HAS_EST_INT_APPR = 1
--BEGIN
--SELECT A.cc_fnc_code AS FunctionCode,
--	   A.cc_fnc_desc AS FunctionDescription,
--	   A.cc_fnc_type AS FunctionType,
--		A.cc_est AS Estimate,
--		A.cc_date AS ItemDate,
--		A.cc_dve_field AS ItemDescription,
--		A.cc_ref_invoice AS InvoiceReference,
--		A.cc_est_hrs AS EstimateQuantity,
--		A.cc_est_amount AS EstimateAmount,
--		A.cc_est_tax AS EstimateTax, 
--		A.cc_est_total AS EstimateTotal,
--		A.cc_est_mkp AS EstimateMarkup,
--		A.cc_actual_hrs AS ActualHours,
--		A.cc_actual_amount AS ActualAmount,
--		A.cc_actual_tax AS ActualTax,
--		A.cc_actual_total AS ActualTotal,
--		A.cc_actual_mkp AS ActualMarkup,
--		A.cc_billed AS Billed,
--		A.cc_open_po AS OpenPOAmount,
--		A.cc_ar_inv_nbr AS ARInvoiceNumber,
--		A.cc_supplier_code AS SuppliedByCode,
--		A.cc_nonbill_flag AS NonBillable,
--		A.cc_adj_date AS AdjustedDate,
--		A.cc_adj_comment AS AdjustedComment,
--		A.cc_rec_id AS RecID,
--		A.cc_seq AS SequenceNumber,
--		A.cc_group AS GroupDescription,
--		A.cc_fnc_name AS FunctionTypeDescription,
--		A.cc_fnc_headingid AS FunctionHeadingID,
--		A.cc_fnc_headingdesc AS FunctionHeadingDescription,
--		A.cc_fnc_consolidationcode AS FunctionConsolidationCode,
--		A.cc_fnc_consolidationname AS FunctionConsolidationDescription
--	 FROM
--(
--SELECT cc_fnc_code = ESTIMATE_REV_DET.FNC_CODE,  
--cc_fnc_desc = CAST( 'Estimate Total:' AS varchar(30)),   
--cc_fnc_type = ESTIMATE_REV_DET.EST_FNC_TYPE,
--cc_est = CAST( 1 AS integer ),   
--cc_date = CAST( NULL AS smalldatetime ),   
--cc_dve_field = CAST( NULL AS varchar(40)),   
--cc_ref_invoice = CAST( NULL AS varchar(30)),   
--cc_est_hrs = SUM( COALESCE( ESTIMATE_REV_DET.EST_REV_QUANTITY, 0 )),   
--cc_est_amount = SUM( COALESCE( ESTIMATE_REV_DET.EST_REV_EXT_AMT, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_NONRESALE_TAX, 0 )),   
--cc_est_tax = SUM( COALESCE( ESTIMATE_REV_DET.EXT_CITY_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_STATE_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_COUNTY_RESALE, 0 )),   
--cc_est_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN SUM( COALESCE( ESTIMATE_REV_DET.LINE_TOTAL, 0 )) ELSE 
--	SUM( COALESCE( ESTIMATE_REV_DET.LINE_TOTAL, 0 )) - (SUM( COALESCE( ESTIMATE_REV_DET.EXT_CITY_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_STATE_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_COUNTY_RESALE, 0 ))) END,
--cc_est_mkp = SUM( COALESCE( ESTIMATE_REV_DET.EXT_MARKUP_AMT, 0 )),   
--cc_actual_hrs = CAST( NULL AS decimal(15,2)),   
--cc_actual_amount = CAST( NULL AS decimal(15,2)),   
--cc_actual_tax = CAST( NULL AS decimal(15,2)),   
--cc_actual_total = CAST( NULL AS decimal(15,2)),   
--cc_actual_mkp = CAST( NULL AS decimal(15,2)),
--cc_billed = CAST( NULL AS decimal(15,2)),   
--cc_open_po = CAST( NULL AS decimal(15,2)),
--cc_ar_inv_nbr = CAST( NULL AS integer ),
--cc_supplier_code = CAST( '''' AS varchar(6)),
--cc_nonbill_flag = CAST( NULL AS integer ),
--cc_adj_date = CAST( NULL AS smalldatetime ),
--cc_adj_comment = '', 
--cc_rec_id = CAST( 0 AS integer ),
--cc_seq = CAST( 0 AS integer ),
--cc_group = FUNCTIONS.FNC_DESCRIPTION,
--cc_fnc_name = CASE WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'E' THEN 'Employee Time'
--				   WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'V' THEN 'Accounts Payable'
--				   WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = FUNCTIONS.FNC_HEADING_ID,
--cc_fnc_headingdesc = FNC_HEADING.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN ESTIMATE_REV_DET.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN FC.FNC_CONSOLIDATION IS NULL THEN FUNCTIONS.FNC_DESCRIPTION ELSE FC.FNC_DESCRIPTION END,
--JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
--FROM JOB_COMPONENT
--  INNER JOIN ESTIMATE_INT_APPR ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
--  	    AND ESTIMATE_INT_APPR.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
--  INNER JOIN ESTIMATE_REV_DET ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_INT_APPR.ESTIMATE_NUMBER
--  		AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_INT_APPR.EST_COMPONENT_NBR
--  		AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_INT_APPR.EST_QUOTE_NBR
--  		AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_INT_APPR.EST_REVISION_NBR 
--  INNER JOIN FUNCTIONS ON FUNCTIONS.FNC_CODE = ESTIMATE_REV_DET.FNC_CODE LEFT OUTER JOIN
--		FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
--		FUNCTIONS FC ON FC.FNC_CODE = FUNCTIONS.FNC_CONSOLIDATION  	

--WHERE JOB_COMPONENT.JOB_NUMBER =  @JobNum  AND JOB_COMPONENT.JOB_COMPONENT_NBR =   @JobComp
--GROUP BY  ESTIMATE_REV_DET.EST_FNC_TYPE, ESTIMATE_REV_DET.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, FUNCTIONS.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FUNCTIONS.FNC_CONSOLIDATION, FC.FNC_CONSOLIDATION,FC.FNC_DESCRIPTION,
--			JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR 

--UNION 

--SELECT cc_fnc_code =  f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = aph.AP_INV_DATE ,
--	cc_dve_field = v.VN_NAME,
--	cc_ref_invoice = CASE WHEN aph.AP_DESC IS NULL OR aph.AP_DESC = '' THEN aph.AP_INV_VCHR ELSE aph.AP_INV_VCHR + ' / ' + aph.AP_DESC END,
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = AP_PROD_QUANTITY,
--	cc_actual_amount = AP_PROD_EXT_AMT + EXT_NONRESALE_TAX,
--	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
--	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE + EXT_NONRESALE_TAX) END,
--	cc_actual_mkp = EXT_MARKUP_AMT,
--	cc_billed = CASE 
--			WHEN AR_INV_NBR IS NULL THEN 0.00 
--			ELSE LINE_TOTAL 
--		END,
--	cc_open_po = NULL,
--	cc_ar_inv_nbr =AR_INV_NBR,
--	cc_supplier_code = aph.VN_FRL_EMP_CODE,
--	cc_nonbill_flag = AP_PROD_NOBILL_FLG,
--	cc_adj_date = CAST(ap.XFER_ADJ_DATE AS smalldatetime),
--	cc_adj_comment = CASE
--				WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
--				WHEN ap.WRITE_OFF = 1 THEN 'Write Off '+ COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '') + ' - ' + CAST(ap.ADJ_COMMENTS AS varchar(5000))
--				WHEN ap.XFER_ADJ_DATE IS NOT NULL THEN
--				CASE
--					WHEN RTRIM(LTRIM(SUBSTRING(ap.ADJ_COMMENTS, 1, 100))) = '' THEN
--						CASE WHEN ap.XFER_FROM_JOB IS NOT NULL THEN 'Transferred From Job ' + CAST(ap.XFER_FROM_JOB AS varchar(6)) + '-' + CAST(ap.XFER_FROM_JOB_COMP AS varchar(2))
--									+ ' ' +COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '')
--										ELSE
--										'Transfer/Adjustment/Write Off '+ COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '')
--										END
--					ELSE
--							CAST(ap.ADJ_COMMENTS AS VARCHAR(500))
--					END
--					WHEN ap.MODIFY_DELETE = 1 AND (ap.DELETE_FLAG = 0 or ap.DELETE_FLAG IS NULL) THEN 'Modified'
--						ELSE ''
--					END,
--	cc_rec_id = ap.AP_ID,
--	cc_seq = ap.LINE_NUMBER,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN ap.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM AP_PRODUCTION ap, 
--			FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION, 
--			AP_HEADER aph,
--			VENDOR v,
--			JOB_COMPONENT jc
--WHERE ap.JOB_NUMBER = jc.JOB_NUMBER
--	  AND ap.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--	  AND ap.FNC_CODE = f.FNC_CODE
--	  AND ap.AP_ID = aph.AP_ID
--	  AND ap.AP_SEQ = aph.AP_SEQ
--	  AND v.VN_CODE = aph.VN_FRL_EMP_CODE
--	  AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp
	  
--UNION

--SELECT f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = et.EMP_DATE,
--	cc_dve_field = COALESCE( RTRIM( EMP_FNAME ) + ' ', '' ) + COALESCE( EMP_MI + '. ', '' ) + COALESCE( EMP_LNAME, '' ),
--	cc_ref_invoice = '',
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = etd.EMP_HOURS,
--	cc_actual_amount = TOTAL_BILL,
--	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
--	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
--	cc_actual_mkp = EXT_MARKUP_AMT,
--	cc_billed = CASE 
--			WHEN AR_INV_NBR IS NULL THEN 0.00 
--			ELSE LINE_TOTAL 
--		    END,
--	cc_open_po = NULL, 
--	AR_INV_NBR,
--	emp.EMP_CODE,
--	EMP_NON_BILL_FLAG,
--	cc_adj_date = CAST(etd.XFER_ADJ_DATE AS smalldatetime),
--	cc_adj_comment = CASE
--						WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
--						WHEN etd.XFER_ADJ_DATE IS NOT NULL THEN
--							CASE WHEN CAST(etd.ADJ_COMMENTS AS VARCHAR(100)) = '' THEN 'Transferred ' + 
--									CASE WHEN etd.XFER_FROM_JOB IS NOT NULL THEN 'From Job ' + CAST( etd.XFER_FROM_JOB AS varchar(6)) + '-' + CAST( etd.XFER_FROM_JOB_COMP AS varchar(2)) + ' '
--										ELSE
--											''
--									END
--									+ CONVERT(varchar(11), etd.XFER_ADJ_DATE, 101) + ' by ' + etd.XFER_ADJ_USER
--								ELSE CAST(etd.ADJ_COMMENTS AS VARCHAR(500))
--								END
--							ELSE ''
--							END,
--	cc_rec_id = etd.ET_ID,
--	cc_seq = etd.SEQ_NBR,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN etd.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM EMP_TIME_DTL etd, 
--	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION, 
--	EMP_TIME et, 
--	EMPLOYEE emp,
--	JOB_COMPONENT jc
--WHERE etd.JOB_NUMBER = jc.JOB_NUMBER
--  AND etd.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--  AND etd.FNC_CODE = f.FNC_CODE
--  AND et.ET_ID = etd.ET_ID
--  AND et.EMP_CODE = emp.EMP_CODE 
--AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp

--UNION 

--SELECT f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = IO_INV_DATE,
--	cc_dve_field = IO_DESC,
--	cc_ref_invoice = IO_INV_NBR,
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = IO_QTY,
--	cc_actual_amount = IO_AMOUNT,
--	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
--	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
--	cc_actual_mkp = EXT_MARKUP_AMT,
--	cc_billed = CASE 
--			WHEN AR_INV_NBR IS NULL THEN 0.00 
--			ELSE LINE_TOTAL 
--		    END, 
--	cc_open_po = NULL,
--	AR_INV_NBR,
--	cc_supplier_code = '',
--	NON_BILL_FLAG,
--	cc_adj_date = CAST(io.XFER_ADJ_DATE AS smalldatetime),
--	cc_adj_comment = CASE
--						WHEN AR_TYPE = 'VO' THEN ' Void Invoice'
--						WHEN io.XFER_ADJ_USER IS NOT NULL THEN
--							CASE WHEN RTRIM(LTRIM(SUBSTRING(io.ADJ_COMMENTS, 1, 100))) = '' THEN
--								CASE WHEN io.XFER_FROM_JOB IS NOT NULL THEN 'Transferred From Job ' + CAST(io.XFER_FROM_JOB AS varchar(6)) + '-' + CAST(io.XFER_FROM_JOB_COMP AS varchar(2))
--									+ ' ' +COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '')
--								ELSE
--									'Transfer/Adjustment ' + COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '')
--								END
--							ELSE COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '') + CAST(io.ADJ_COMMENTS AS varchar(5000))
--							END
--						WHEN MODIFY_FLAG = 1 THEN 'Modified'
--					ELSE ''
--					END,
--	cc_rec_id = io.IO_ID,
--	cc_seq = io.SEQ_NBR,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN io.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM INCOME_ONLY io, 
--	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
--	JOB_COMPONENT jc
--WHERE jc.JOB_NUMBER = io.JOB_NUMBER
--  AND jc.JOB_COMPONENT_NBR = io.JOB_COMPONENT_NBR
--  AND io.FNC_CODE = f.FNC_CODE 
-- AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR =  @JobComp

--UNION 

--SELECT f.FNC_CODE,   
--    cc_fnc_desc = f.FNC_DESCRIPTION,   
--    cc_fnc_type = f.FNC_TYPE, 
--	cc_est = 0,
--    cc_date = co.INV_DATE,   
--    cc_dve_field = co.DESCRIPTION,   
--    cc_ref_invoice = co.INV_NBR,   
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = NULL,
--	cc_actual_amount = co.AMOUNT,
--	cc_actual_tax = NULL,
--	cc_actual_total = co.AMOUNT,
--	cc_actual_mkp = NULL,
--	cc_billed = NULL, 
--	cc_open_po = NULL,
--	cc_ar_inv_nbr = NULL,
--	cc_supplier_code = '',
--	cc_nonbill_flag = NULL,
--	cc_adj_date = CAST( NULL AS smalldatetime ),
--	cc_adj_comment = CASE
--						WHEN DELETE_FLAG = 1 THEN 'Deleted'
--						ELSE ''
--					END,
--	cc_rec_id = co.OOP_ID,
--	cc_seq = co.SEQ_NBR,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN co.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM CLIENT_OOP co,   
--     FUNCTIONS  f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
--     JOB_COMPONENT jc
--WHERE co.FNC_CODE = f.FNC_CODE 
--  AND co.JOB_NUMBER = jc.JOB_NUMBER
--  AND co.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
--AND jc.JOB_NUMBER =   @JobNum  AND jc.JOB_COMPONENT_NBR =  @JobComp

--UNION 

--SELECT f.FNC_CODE,
--	cc_fnc_desc = f.FNC_DESCRIPTION,
--	cc_fnc_type = f.FNC_TYPE,
--	cc_est = 0,
--	cc_date = PO_DATE,
--	cc_dve_field = VN_NAME,
--	cc_ref_invoice = CASE WHEN ((po.PO_APPROVAL_FLAG = 1) OR (po.PO_APPROVAL_FLAG = 3)) 
--		AND ((po.EXCEED = 1) OR (po.EXCEED = 0) OR (po.EXCEED IS NULL)) 
--		AND ((po.PO_PRINTED = 0) OR (po.PO_PRINTED IS NULL)) 
--		AND (NOT(po.PO_APPR_RULE_CODE IS NULL)) THEN '(Pending)' 
--		WHEN (po.PO_APPROVAL_FLAG = 2) THEN 'PO# ' + CONVERT(varchar(8), pod.PO_NUMBER ) + '-LINE ' + CONVERT(varchar(3), pod.LINE_NUMBER) 
--		WHEN (NOT(po.PO_APPR_RULE_CODE IS NULL))
--		AND ((po.EXCEED = 1) OR (po.EXCEED = 0) OR (po.EXCEED IS NULL))
--		AND ((po.PO_PRINTED = 0) OR (po.PO_PRINTED IS NULL)) THEN '(Incomplete)'		
--		ELSE 'PO# ' + CONVERT(varchar(8), pod.PO_NUMBER ) + '-LINE ' + CONVERT(varchar(3), pod.LINE_NUMBER) END,
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = NULL,
--	cc_actual_amount = NULL,
--	cc_actual_tax = NULL,
--	cc_actual_total = NULL,
--	cc_actual_mkp = NULL,
--	cc_billed = NULL, 
--	cc_open_po = PO_EXT_AMOUNT - (SELECT ISNULL(SUM(dbo.AP_PRODUCTION.AP_PROD_EXT_AMT), 0.00) FROM AP_PRODUCTION WHERE pod.PO_NUMBER = AP_PRODUCTION.PO_NUMBER AND 
--							  pod.LINE_NUMBER = AP_PRODUCTION.PO_LINE_NUMBER),
--	cc_ar_inv_nbr = NULL,
--	v.VN_CODE,
--	cc_nonbill_flag = NULL,
--	cc_adj_date = CAST( NULL AS smalldatetime ),
--	cc_adj_comment = '', --CAST( NULL AS text ),
--	cc_rec_id = pod.PO_NUMBER,
--	cc_seq = pod.LINE_NUMBER,
--cc_group = f.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = f.FNC_HEADING_ID,
--cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN pod.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
--jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR
--FROM PURCHASE_ORDER po, 
--	PURCHASE_ORDER_DET pod, 
--	VENDOR v, 
--	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
--	JOB_COMPONENT jc
--WHERE jc.JOB_NUMBER = pod.JOB_NUMBER
--  AND jc.JOB_COMPONENT_NBR = pod.JOB_COMPONENT_NBR
--  AND pod.FNC_CODE = f.FNC_CODE
--  AND po.PO_NUMBER = pod.PO_NUMBER
--  AND v.VN_CODE = po.VN_CODE
--  AND ( pod.PO_COMPLETE IS NULL OR pod.PO_COMPLETE = 0 ) 
--  AND ( po.VOID_FLAG IS NULL OR po.VOID_FLAG != 1 ) 
--AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp

--UNION 

--SELECT FUNCTIONS.FNC_CODE,
--	cc_fnc_desc = FUNCTIONS.FNC_DESCRIPTION,
--	cc_fnc_type = FUNCTIONS.FNC_TYPE,
--	cc_est = 0,
--	cc_date = CREATE_DATE,
--	cc_dve_field = 'Advance Billing',
--	cc_ref_invoice = '', 
--	cc_est_hrs = NULL,
--	cc_est_amount = NULL,
--	cc_est_tax = NULL, 
--	cc_est_total = NULL,
--	cc_est_mkp = NULL,
--	cc_actual_hrs = NULL,
--	cc_actual_amount = NULL,
--	cc_actual_tax = NULL,
--	cc_actual_total = NULL,
--	cc_actual_mkp = NULL,
--	cc_billed = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
--	cc_open_po = NULL,
--	AR_INV_NBR, 
--	cc_supplier_code = '',
--	cc_nonbill_flag = NULL,
--	cc_adj_date = CAST( NULL AS smalldatetime ),
--	cc_adj_comment = CASE
--						WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
--						ELSE ''
--					END,
--	cc_rec_id = ADVANCE_BILLING.AB_ID,
--	cc_seq = ADVANCE_BILLING.SEQ_NBR,
--cc_group = FUNCTIONS.FNC_DESCRIPTION,
--	cc_fnc_name = CASE WHEN FUNCTIONS.FNC_TYPE = 'E' THEN 'Employee Time'
--					   WHEN FUNCTIONS.FNC_TYPE = 'V' THEN 'Accounts Payable'
--					   WHEN FUNCTIONS.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = FUNCTIONS.FNC_HEADING_ID,
--cc_fnc_headingdesc = FNC_HEADING.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN ADVANCE_BILLING.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN FC.FNC_CONSOLIDATION IS NULL THEN FUNCTIONS.FNC_DESCRIPTION ELSE FC.FNC_DESCRIPTION END,
--JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
--FROM JOB_COMPONENT
--	INNER JOIN ADVANCE_BILLING ON JOB_COMPONENT.JOB_NUMBER = ADVANCE_BILLING.JOB_NUMBER
--  				  AND JOB_COMPONENT.JOB_COMPONENT_NBR = ADVANCE_BILLING.JOB_COMPONENT_NBR
--	INNER JOIN FUNCTIONS ON ADVANCE_BILLING.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
--		FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
--		FUNCTIONS FC ON FC.FNC_CODE = FUNCTIONS.FNC_CONSOLIDATION  	
	
--WHERE JOB_COMPONENT.JOB_NUMBER =   @JobNum  AND JOB_COMPONENT.JOB_COMPONENT_NBR =  @JobComp
--	AND ( AR_INV_NBR IS NOT NULL OR ADVANCE_BILLING.AB_FLAG = 3 ) --AND LINE_TOTAL > 0
	
	

--) AS A
--WHERE ((NOT (A.cc_fnc_type = 'E' AND cc_actual_hrs = 0)) OR cc_actual_hrs IS NULL) AND A.cc_fnc_desc <> 'Estimate Total:'
--ORDER BY A.cc_fnc_type, A.cc_fnc_code, A.cc_est, A.cc_fnc_desc, A.cc_date DESC 
--END

--if @HAS_EST_APPR = 0 AND @HAS_EST_INT_APPR = 0
--BEGIN
SELECT A.cc_fnc_code AS FunctionCode,
	   A.cc_fnc_desc AS FunctionDescription,
	   A.cc_fnc_type AS FunctionType,
		A.cc_est AS Estimate,
		A.cc_date AS ItemDate,
		A.cc_dve_field AS ItemDescription,
		A.cc_ref_invoice AS InvoiceReference,
		A.cc_est_hrs AS EstimateQuantity,
		A.cc_est_amount AS EstimateAmount,
		A.cc_est_tax AS EstimateTax, 
		A.cc_est_total AS EstimateTotal,
		A.cc_est_mkp AS EstimateMarkup,
		A.cc_actual_hrs AS ActualHours,
		A.cc_actual_amount AS ActualAmount,
		A.cc_actual_tax AS ActualTax,
		A.cc_actual_total AS ActualTotal,
		A.cc_actual_mkp AS ActualMarkup,
		A.cc_billed AS Billed,
		A.cc_open_po AS OpenPOAmount,
		A.cc_ar_inv_nbr AS ARInvoiceNumber,
		A.cc_supplier_code AS SuppliedByCode,
		A.cc_nonbill_flag AS NonBillable,
		A.cc_adj_date AS AdjustedDate,
		A.cc_adj_comment AS AdjustedComment,
		A.cc_rec_id AS RecID,
		A.cc_seq AS SequenceNumber,
		A.cc_group AS GroupDescription,
		A.cc_fnc_name AS FunctionTypeDescription,
		A.cc_fnc_headingid AS FunctionHeadingID,
		A.cc_fnc_headingdesc AS FunctionHeadingDescription,
		A.cc_fnc_consolidationcode AS FunctionConsolidationCode,
		A.cc_fnc_consolidationname AS FunctionConsolidationDescription,
		A.JOB_NUMBER AS JobNumber,
		A.JOB_COMPONENT_NBR AS JobComponentNumber,
		A.DueDate,
		A.StartDate
	 FROM
(
--SELECT cc_fnc_code = ESTIMATE_REV_DET.FNC_CODE,  
--cc_fnc_desc = CAST( 'Estimate Total:' AS varchar(30)),   
--cc_fnc_type = ESTIMATE_REV_DET.EST_FNC_TYPE,
--cc_est = CAST( 1 AS integer ),   
--cc_date = CAST( NULL AS smalldatetime ),   
--cc_dve_field = CAST( NULL AS varchar(40)),   
--cc_ref_invoice = CAST( NULL AS varchar(30)),   
--cc_est_hrs = SUM( COALESCE( ESTIMATE_REV_DET.EST_REV_QUANTITY, 0 )),   
--cc_est_amount = SUM( COALESCE( ESTIMATE_REV_DET.EST_REV_EXT_AMT, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_NONRESALE_TAX, 0 )),   
--cc_est_tax = SUM( COALESCE( ESTIMATE_REV_DET.EXT_CITY_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_STATE_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_COUNTY_RESALE, 0 )),   
--cc_est_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN SUM( COALESCE( ESTIMATE_REV_DET.LINE_TOTAL, 0 )) ELSE 
--	SUM( COALESCE( ESTIMATE_REV_DET.LINE_TOTAL, 0 )) - (SUM( COALESCE( ESTIMATE_REV_DET.EXT_CITY_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_STATE_RESALE, 0 ) + COALESCE( ESTIMATE_REV_DET.EXT_COUNTY_RESALE, 0 ))) END,
--cc_est_mkp = SUM( COALESCE( ESTIMATE_REV_DET.EXT_MARKUP_AMT, 0 )),   
--cc_actual_hrs = CAST( NULL AS decimal(15,2)),   
--cc_actual_amount = CAST( NULL AS decimal(15,2)),   
--cc_actual_tax = CAST( NULL AS decimal(15,2)),   
--cc_actual_total = CAST( NULL AS decimal(15,2)),   
--cc_actual_mkp = CAST( NULL AS decimal(15,2)),
--cc_billed = CAST( NULL AS decimal(15,2)),   
--cc_open_po = CAST( NULL AS decimal(15,2)),
--cc_ar_inv_nbr = CAST( NULL AS integer ),
--cc_supplier_code = CAST( '''' AS varchar(6)),
--cc_nonbill_flag = CAST( NULL AS integer ),
--cc_adj_date = CAST( NULL AS smalldatetime ),
--cc_adj_comment = '', 
--cc_rec_id = CAST( 0 AS integer ),
--cc_seq = CAST( 0 AS integer ),
--cc_group = FUNCTIONS.FNC_DESCRIPTION,
--cc_fnc_name = CASE WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'E' THEN 'Employee Time'
--				   WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'V' THEN 'Accounts Payable'
--				   WHEN ESTIMATE_REV_DET.EST_FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
--cc_fnc_headingid = FUNCTIONS.FNC_HEADING_ID,
--cc_fnc_headingdesc = FNC_HEADING.FNC_HEADING_DESC,
--cc_fnc_consolidationcode = CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN ESTIMATE_REV_DET.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END,
--cc_fnc_consolidationname = CASE WHEN FC.FNC_CONSOLIDATION IS NULL THEN FUNCTIONS.FNC_DESCRIPTION ELSE FC.FNC_DESCRIPTION END,
--JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR
--FROM JOB_COMPONENT
--  INNER JOIN ESTIMATE_APPROVAL ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
--  	    AND ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
--  INNER JOIN ESTIMATE_REV_DET ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER
--  		AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR
--  		AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR
--  		AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR 
--  INNER JOIN FUNCTIONS ON FUNCTIONS.FNC_CODE = ESTIMATE_REV_DET.FNC_CODE LEFT OUTER JOIN
--		FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
--		FUNCTIONS FC ON FC.FNC_CODE = FUNCTIONS.FNC_CONSOLIDATION  	

--WHERE JOB_COMPONENT.JOB_NUMBER =  @JobNum  AND JOB_COMPONENT.JOB_COMPONENT_NBR =   @JobComp
--GROUP BY  ESTIMATE_REV_DET.EST_FNC_TYPE, ESTIMATE_REV_DET.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, FUNCTIONS.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FUNCTIONS.FNC_CONSOLIDATION, FC.FNC_CONSOLIDATION,FC.FNC_DESCRIPTION ,
--			JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR

--UNION 

SELECT cc_fnc_code =  f.FNC_CODE,
	cc_fnc_desc = f.FNC_DESCRIPTION,
	cc_fnc_type = f.FNC_TYPE,
	cc_est = 0,
	cc_date = aph.AP_INV_DATE ,
	cc_dve_field = v.VN_CODE + '     ' + v.VN_NAME,
	--cc_ref_invoice = CASE WHEN aph.AP_DESC IS NULL OR aph.AP_DESC = '' THEN aph.AP_INV_VCHR ELSE aph.AP_INV_VCHR + ' / ' + aph.AP_DESC END,
	cc_ref_invoice = 'A/P Invoice: ' + aph.AP_INV_VCHR,
	cc_est_hrs = NULL,
	cc_est_amount = NULL,
	cc_est_tax = NULL, 
	cc_est_total = NULL,
	cc_est_mkp = NULL,
	cc_actual_hrs = AP_PROD_QUANTITY,
	cc_actual_amount = AP_PROD_EXT_AMT + EXT_NONRESALE_TAX,
	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE + EXT_NONRESALE_TAX) END,
	cc_actual_mkp = EXT_MARKUP_AMT,
	cc_billed = CASE 
			WHEN AR_INV_NBR IS NULL THEN 0.00 
			ELSE LINE_TOTAL 
		END,
	cc_open_po = NULL,
	cc_ar_inv_nbr =AR_INV_NBR,
	cc_supplier_code = aph.VN_FRL_EMP_CODE,
	cc_nonbill_flag = AP_PROD_NOBILL_FLG,
	cc_adj_date = CAST(ap.XFER_ADJ_DATE AS smalldatetime),
	cc_adj_comment = CASE
				WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
				WHEN ap.WRITE_OFF = 1 THEN 'Write Off '+ COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '') + ' - ' + CAST(ap.ADJ_COMMENTS AS varchar(5000))
				WHEN ap.XFER_ADJ_DATE IS NOT NULL THEN
				CASE
					WHEN RTRIM(LTRIM(SUBSTRING(ap.ADJ_COMMENTS, 1, 100))) = '' THEN
						CASE WHEN ap.XFER_FROM_JOB IS NOT NULL THEN 'Transferred From Job ' + CAST(ap.XFER_FROM_JOB AS varchar(6)) + '-' + CAST(ap.XFER_FROM_JOB_COMP AS varchar(2))
									+ ' ' +COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '')
										ELSE
										'Transfer/Adjustment/Write Off '+ COALESCE(CONVERT(varchar(11), ap.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(ap.XFER_ADJ_USER), '')
										END
					ELSE
							CAST(ap.ADJ_COMMENTS AS VARCHAR(500))
					END
					WHEN ap.MODIFY_DELETE = 1 AND (ap.DELETE_FLAG = 0 or ap.DELETE_FLAG IS NULL) THEN 'Modified'
						ELSE ''
					END,
	cc_rec_id = ap.AP_ID,
	cc_seq = ap.LINE_NUMBER,
	cc_group = f.FNC_DESCRIPTION,
	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
cc_fnc_headingid = f.FNC_HEADING_ID,
cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN ap.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR,
DueDate = jc.JOB_FIRST_USE_DATE,
StartDate = jc.[START_DATE]
FROM AP_PRODUCTION ap, 
			FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION, 
			AP_HEADER aph,
			VENDOR v,
			JOB_COMPONENT jc
WHERE ap.JOB_NUMBER = jc.JOB_NUMBER
	  AND ap.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	  AND ap.FNC_CODE = f.FNC_CODE
	  AND ap.AP_ID = aph.AP_ID
	  AND ap.AP_SEQ = aph.AP_SEQ
	  AND v.VN_CODE = aph.VN_FRL_EMP_CODE
	  AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp
	  AND ap.FNC_CODE = @FunctionCode
	  
UNION

SELECT f.FNC_CODE,
	cc_fnc_desc = f.FNC_DESCRIPTION,
	cc_fnc_type = f.FNC_TYPE,
	cc_est = 0,
	cc_date = et.EMP_DATE,
	cc_dve_field = emp.EMP_CODE + '     ' +COALESCE( RTRIM( EMP_FNAME ) + ' ', '' ) + COALESCE( EMP_MI + '. ', '' ) + COALESCE( EMP_LNAME, '' ),
	cc_ref_invoice = 'Time Entry:',
	cc_est_hrs = NULL,
	cc_est_amount = NULL,
	cc_est_tax = NULL, 
	cc_est_total = NULL,
	cc_est_mkp = NULL,
	cc_actual_hrs = etd.EMP_HOURS,
	cc_actual_amount = TOTAL_BILL,
	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
	cc_actual_mkp = EXT_MARKUP_AMT,
	cc_billed = CASE 
			WHEN AR_INV_NBR IS NULL THEN 0.00 
			ELSE LINE_TOTAL 
		    END,
	cc_open_po = NULL, 
	AR_INV_NBR,
	emp.EMP_CODE,
	EMP_NON_BILL_FLAG,
	cc_adj_date = CAST(etd.XFER_ADJ_DATE AS smalldatetime),
	cc_adj_comment = CASE
						WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
						WHEN etd.XFER_ADJ_DATE IS NOT NULL THEN
							CASE WHEN CAST(etd.ADJ_COMMENTS AS VARCHAR(100)) = '' THEN 'Transferred ' + 
									CASE WHEN etd.XFER_FROM_JOB IS NOT NULL THEN 'From Job ' + CAST( etd.XFER_FROM_JOB AS varchar(6)) + '-' + CAST( etd.XFER_FROM_JOB_COMP AS varchar(2)) + ' '
										ELSE
											''
									END
									+ CONVERT(varchar(11), etd.XFER_ADJ_DATE, 101) + ' by ' + etd.XFER_ADJ_USER
								ELSE CAST(etd.ADJ_COMMENTS AS VARCHAR(500))
								END
							ELSE ''
							END,
	cc_rec_id = etd.ET_ID,
	cc_seq = etd.SEQ_NBR,
cc_group = f.FNC_DESCRIPTION,
	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
cc_fnc_headingid = f.FNC_HEADING_ID,
cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN etd.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR,
DueDate = jc.JOB_FIRST_USE_DATE,
StartDate = jc.[START_DATE]
FROM EMP_TIME_DTL etd, 
	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION, 
	EMP_TIME et, 
	EMPLOYEE emp,
	JOB_COMPONENT jc
WHERE etd.JOB_NUMBER = jc.JOB_NUMBER
  AND etd.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
  AND etd.FNC_CODE = f.FNC_CODE
  AND et.ET_ID = etd.ET_ID
  AND et.EMP_CODE = emp.EMP_CODE 
  AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp
  AND etd.FNC_CODE = @FunctionCode

UNION 

SELECT f.FNC_CODE,
	cc_fnc_desc = f.FNC_DESCRIPTION,
	cc_fnc_type = f.FNC_TYPE,
	cc_est = 0,
	cc_date = IO_INV_DATE,
	cc_dve_field = IO_DESC,
	cc_ref_invoice = 'Reference: ' + IO_INV_NBR,
	cc_est_hrs = NULL,
	cc_est_amount = NULL,
	cc_est_tax = NULL, 
	cc_est_total = NULL,
	cc_est_mkp = NULL,
	cc_actual_hrs = IO_QTY,
	cc_actual_amount = IO_AMOUNT,
	cc_actual_tax = EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE,
	cc_actual_total = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN LINE_TOTAL ELSE LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE) END,
	cc_actual_mkp = EXT_MARKUP_AMT,
	cc_billed = CASE 
			WHEN AR_INV_NBR IS NULL THEN 0.00 
			ELSE LINE_TOTAL 
		    END, 
	cc_open_po = NULL,
	AR_INV_NBR,
	cc_supplier_code = '',
	NON_BILL_FLAG,
	cc_adj_date = CAST(io.XFER_ADJ_DATE AS smalldatetime),
	cc_adj_comment = CASE
						WHEN AR_TYPE = 'VO' THEN ' Void Invoice'
						WHEN io.XFER_ADJ_USER IS NOT NULL THEN
							CASE WHEN RTRIM(LTRIM(SUBSTRING(io.ADJ_COMMENTS, 1, 100))) = '' THEN
								CASE WHEN io.XFER_FROM_JOB IS NOT NULL THEN 'Transferred From Job ' + CAST(io.XFER_FROM_JOB AS varchar(6)) + '-' + CAST(io.XFER_FROM_JOB_COMP AS varchar(2))
									+ ' ' +COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '')
								ELSE
									'Transfer/Adjustment ' + COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '')
								END
							ELSE COALESCE(CONVERT(varchar(11), io.XFER_ADJ_DATE, 101), '') + ' by ' + COALESCE(RTRIM(io.XFER_ADJ_USER), '') + CAST(io.ADJ_COMMENTS AS varchar(5000))
							END
						WHEN MODIFY_FLAG = 1 THEN 'Modified'
					ELSE ''
					END,
	cc_rec_id = io.IO_ID,
	cc_seq = io.SEQ_NBR,
cc_group = f.FNC_DESCRIPTION,
	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
cc_fnc_headingid = f.FNC_HEADING_ID,
cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN io.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR,
DueDate = jc.JOB_FIRST_USE_DATE,
StartDate = jc.[START_DATE]
FROM INCOME_ONLY io, 
	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
	JOB_COMPONENT jc
WHERE jc.JOB_NUMBER = io.JOB_NUMBER
  AND jc.JOB_COMPONENT_NBR = io.JOB_COMPONENT_NBR
  AND io.FNC_CODE = f.FNC_CODE 
  AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR =  @JobComp
  AND io.FNC_CODE = @FunctionCode

UNION 

SELECT f.FNC_CODE,   
    cc_fnc_desc = f.FNC_DESCRIPTION,   
    cc_fnc_type = f.FNC_TYPE, 
	cc_est = 0,
    cc_date = co.INV_DATE,   
    cc_dve_field = co.DESCRIPTION,   
    cc_ref_invoice = co.INV_NBR,   
	cc_est_hrs = NULL,
	cc_est_amount = NULL,
	cc_est_tax = NULL, 
	cc_est_total = NULL,
	cc_est_mkp = NULL,
	cc_actual_hrs = NULL,
	cc_actual_amount = co.AMOUNT,
	cc_actual_tax = NULL,
	cc_actual_total = co.AMOUNT,
	cc_actual_mkp = NULL,
	cc_billed = NULL, 
	cc_open_po = NULL,
	cc_ar_inv_nbr = NULL,
	cc_supplier_code = '',
	cc_nonbill_flag = NULL,
	cc_adj_date = CAST( NULL AS smalldatetime ),
	cc_adj_comment = CASE
						WHEN DELETE_FLAG = 1 THEN 'Deleted'
						ELSE ''
					END,
	cc_rec_id = co.OOP_ID,
	cc_seq = co.SEQ_NBR,
cc_group = f.FNC_DESCRIPTION,
	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
cc_fnc_headingid = f.FNC_HEADING_ID,
cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN co.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR,
DueDate = jc.JOB_FIRST_USE_DATE,
StartDate = jc.[START_DATE]
FROM CLIENT_OOP co,   
     FUNCTIONS  f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
     JOB_COMPONENT jc
WHERE co.FNC_CODE = f.FNC_CODE 
  AND co.JOB_NUMBER = jc.JOB_NUMBER
  AND co.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
  AND jc.JOB_NUMBER =   @JobNum  AND jc.JOB_COMPONENT_NBR =  @JobComp
  AND co.FNC_CODE = @FunctionCode

UNION 

SELECT f.FNC_CODE,
	cc_fnc_desc = f.FNC_DESCRIPTION,
	cc_fnc_type = f.FNC_TYPE,
	cc_est = 0,
	cc_date = PO_DATE,
	cc_dve_field = v.VN_CODE + '     ' + VN_NAME,
	cc_ref_invoice = CASE WHEN ((po.PO_APPROVAL_FLAG = 1) OR (po.PO_APPROVAL_FLAG = 3)) 
		AND ((po.EXCEED = 1) OR (po.EXCEED = 0) OR (po.EXCEED IS NULL)) 
		AND ((po.PO_PRINTED = 0) OR (po.PO_PRINTED IS NULL)) 
		AND (NOT(po.PO_APPR_RULE_CODE IS NULL)) THEN '(Pending)' 
		WHEN (po.PO_APPROVAL_FLAG = 2) THEN 'PO# ' + CONVERT(varchar(8), pod.PO_NUMBER ) + '-LINE ' + CONVERT(varchar(3), pod.LINE_NUMBER) 
		WHEN (NOT(po.PO_APPR_RULE_CODE IS NULL))
		AND ((po.EXCEED = 1) OR (po.EXCEED = 0) OR (po.EXCEED IS NULL))
		AND ((po.PO_PRINTED = 0) OR (po.PO_PRINTED IS NULL)) THEN '(Incomplete)'		
		ELSE 'PO# ' + CONVERT(varchar(8), pod.PO_NUMBER ) + '-LINE ' + CONVERT(varchar(3), pod.LINE_NUMBER) END,
	cc_est_hrs = NULL,
	cc_est_amount = NULL,
	cc_est_tax = NULL, 
	cc_est_total = NULL,
	cc_est_mkp = NULL,
	cc_actual_hrs = NULL,
	cc_actual_amount = PO_EXT_AMOUNT,
	cc_actual_tax = NULL,
	cc_actual_total = NULL,
	cc_actual_mkp = NULL,
	cc_billed = NULL, 
	cc_open_po = PO_EXT_AMOUNT - (SELECT ISNULL(SUM(dbo.AP_PRODUCTION.AP_PROD_EXT_AMT), 0.00) FROM AP_PRODUCTION WHERE pod.PO_NUMBER = AP_PRODUCTION.PO_NUMBER AND 
							  pod.LINE_NUMBER = AP_PRODUCTION.PO_LINE_NUMBER),
	cc_ar_inv_nbr = NULL,
	v.VN_CODE,
	cc_nonbill_flag = NULL,
	cc_adj_date = CAST( NULL AS smalldatetime ),
	cc_adj_comment = '', --CAST( NULL AS text ),
	cc_rec_id = pod.PO_NUMBER,
	cc_seq = pod.LINE_NUMBER,
cc_group = f.FNC_DESCRIPTION,
	cc_fnc_name = CASE WHEN f.FNC_TYPE = 'E' THEN 'Employee Time'
					   WHEN f.FNC_TYPE = 'V' THEN 'Accounts Payable'
					   WHEN f.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
cc_fnc_headingid = f.FNC_HEADING_ID,
cc_fnc_headingdesc = fh.FNC_HEADING_DESC,
cc_fnc_consolidationcode = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN pod.FNC_CODE ELSE f.FNC_CONSOLIDATION END,
cc_fnc_consolidationname = CASE WHEN f.FNC_CONSOLIDATION IS NULL THEN f.FNC_DESCRIPTION ELSE cf.FNC_DESCRIPTION END,
jc.JOB_NUMBER,jc.JOB_COMPONENT_NBR,
DueDate = jc.JOB_FIRST_USE_DATE,
StartDate = jc.[START_DATE]
FROM PURCHASE_ORDER po, 
	PURCHASE_ORDER_DET pod, 
	VENDOR v, 
	FUNCTIONS f LEFT OUTER JOIN FNC_HEADING fh ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID LEFT OUTER JOIN FUNCTIONS cf ON cf.FNC_CODE = f.FNC_CONSOLIDATION,
	JOB_COMPONENT jc
WHERE jc.JOB_NUMBER = pod.JOB_NUMBER
  AND jc.JOB_COMPONENT_NBR = pod.JOB_COMPONENT_NBR
  AND pod.FNC_CODE = f.FNC_CODE
  AND po.PO_NUMBER = pod.PO_NUMBER
  AND v.VN_CODE = po.VN_CODE
  AND ( pod.PO_COMPLETE IS NULL OR pod.PO_COMPLETE = 0 ) 
  AND ( po.VOID_FLAG IS NULL OR po.VOID_FLAG != 1 ) 
  AND jc.JOB_NUMBER =  @JobNum  AND jc.JOB_COMPONENT_NBR = @JobComp
  AND pod.FNC_CODE = @FunctionCode

UNION 

SELECT FUNCTIONS.FNC_CODE,
	cc_fnc_desc = FUNCTIONS.FNC_DESCRIPTION,
	cc_fnc_type = FUNCTIONS.FNC_TYPE,
	cc_est = 0,
	cc_date = CREATE_DATE,
	cc_dve_field = '',
	cc_ref_invoice = 'Advance Billing', 
	cc_est_hrs = NULL,
	cc_est_amount = NULL,
	cc_est_tax = NULL, 
	cc_est_total = NULL,
	cc_est_mkp = NULL,
	cc_actual_hrs = NULL,
	cc_actual_amount = NULL,
	cc_actual_tax = NULL,
	cc_actual_total = NULL,
	cc_actual_mkp = NULL,
	cc_billed = CASE WHEN @INCLUDE_SALES_TAX = 1 THEN SUM(LINE_TOTAL) ELSE SUM(LINE_TOTAL - (EXT_CITY_RESALE + EXT_STATE_RESALE + EXT_COUNTY_RESALE)) END,
	cc_open_po = NULL,
	AR_INV_NBR, 
	cc_supplier_code = '',
	cc_nonbill_flag = NULL,
	cc_adj_date = NULL,--BILL_DATE,
	cc_adj_comment = CASE
						WHEN AR_TYPE = 'VO' THEN 'Void Invoice'
						ELSE ''
					END,
	cc_rec_id = NULL,--ADVANCE_BILLING.AB_ID,
	cc_seq = NULL,--ADVANCE_BILLING.SEQ_NBR,
cc_group = FUNCTIONS.FNC_DESCRIPTION,
	cc_fnc_name = CASE WHEN FUNCTIONS.FNC_TYPE = 'E' THEN 'Employee Time'
					   WHEN FUNCTIONS.FNC_TYPE = 'V' THEN 'Accounts Payable'
					   WHEN FUNCTIONS.FNC_TYPE = 'I' THEN 'Income Only' ELSE '' END,
cc_fnc_headingid = FUNCTIONS.FNC_HEADING_ID,
cc_fnc_headingdesc = FNC_HEADING.FNC_HEADING_DESC,
cc_fnc_consolidationcode = CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN ADVANCE_BILLING.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END,
cc_fnc_consolidationname = CASE WHEN FC.FNC_CONSOLIDATION IS NULL THEN FUNCTIONS.FNC_DESCRIPTION ELSE FC.FNC_DESCRIPTION END,
JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR,
DueDate = JOB_FIRST_USE_DATE,
StartDate = [START_DATE]
FROM JOB_COMPONENT
	INNER JOIN ADVANCE_BILLING ON JOB_COMPONENT.JOB_NUMBER = ADVANCE_BILLING.JOB_NUMBER
  				  AND JOB_COMPONENT.JOB_COMPONENT_NBR = ADVANCE_BILLING.JOB_COMPONENT_NBR
	INNER JOIN FUNCTIONS ON ADVANCE_BILLING.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
		FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN
		FUNCTIONS FC ON FC.FNC_CODE = FUNCTIONS.FNC_CONSOLIDATION  	
	
WHERE JOB_COMPONENT.JOB_NUMBER = @JobNum AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp	AND FUNCTIONS.FNC_CODE = @FunctionCode AND
( AR_INV_NBR IS NOT NULL OR ADVANCE_BILLING.AB_FLAG = 3 ) --AND LINE_TOTAL > 0
GROUP BY JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR, FUNCTIONS.FNC_CODE,ADVANCE_BILLING.FNC_CODE,FUNCTIONS.FNC_DESCRIPTION,FUNCTIONS.FNC_TYPE,CREATE_DATE,AR_INV_NBR,AR_TYPE,
			FUNCTIONS.FNC_HEADING_ID,FNC_HEADING.FNC_HEADING_DESC,FUNCTIONS.FNC_CONSOLIDATION,FC.FNC_DESCRIPTION,FC.FNC_CONSOLIDATION,JOB_COMPONENT.JOB_NUMBER,JOB_COMPONENT.JOB_COMPONENT_NBR,
			JOB_FIRST_USE_DATE, [START_DATE]
	

) AS A
WHERE ((NOT (A.cc_fnc_type = 'E' AND cc_actual_hrs = 0)) OR cc_actual_hrs IS NULL) AND A.cc_fnc_desc <> 'Estimate Total:'
ORDER BY A.cc_fnc_type, A.cc_fnc_code, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.cc_date  
--END

END