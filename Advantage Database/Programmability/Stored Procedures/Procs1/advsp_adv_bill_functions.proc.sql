
CREATE PROCEDURE [dbo].[advsp_adv_bill_functions] @job_number integer, @job_component_nbr smallint, @est_nbr integer, @est_comp_nbr smallint,
		@est_qte_nbr smallint, @est_rev_nbr smallint, @ab_id integer, @contingency bit, @ret_val integer OUTPUT
AS

SET NOCOUNT ON

DECLARE @po_fnc_code varchar(6), @po_fnc_type varchar(1), @po_fnc_desc varchar(30)
DECLARE @po_ext_amt decimal(15,2), @po_tax_code varchar(4), @po_tax_mu smallint
DECLARE @po_tax_mu_only smallint, @po_tax_resale smallint, @po_state_pct decimal(8,4)
DECLARE @po_county_pct decimal(8,4), @po_city_pct decimal(8,4), @po_mu_pct decimal(9,3)
DECLARE @po_state_amt decimal(15,2), @po_county_amt decimal(15,2), @po_city_amt decimal(15,2) 
DECLARE @po_nonresale_amt decimal(15,2), @po_mu_amt decimal(15,2), @po_est_exists bit	
DECLARE @po_applied_amt decimal(15,2), @po_line_total decimal(15,2)

CREATE TABLE #actuals (
	RECORD_ID			integer,
	SEQ_NBR				int,
	SEQ_NBR1			int,
	TABLE_FROM			smallint,
	INV_NBR				integer,
	INV_SEQ				smallint,
	FNC_TYPE			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_DESC			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OPEN_NET_AMT		decimal(15,2),
	OPEN_AMT			decimal(15,2),
	APPR_AMT			decimal(15,2),
	BILLED_TOTAL		decimal(15,2),
	BILLED_NET			decimal(15,2),
	FINAL_TOTAL			decimal(15,2),
	FINAL_NET			decimal(15,2),
	TAX_CODE			varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAX_MU				smallint,
	TAX_MU_ONLY			smallint,
	RESALE				smallint,
	STATE_PCT			decimal(8,4),
	COUNTY_PCT			decimal(8,4),
	CITY_PCT			decimal(8,4),
	STATE_AMT			decimal(15,2),
	COUNTY_AMT			decimal(15,2),
	CITY_AMT			decimal(15,2),
	NONRESALE_AMT		decimal(15,2),
	MARKUP_PCT			decimal(9,3),
	CONT_PCT			decimal(6,3),
	CONT_AMT			decimal(15,2),
	CONT_NET			decimal(15,2),
	CONT_STATE			decimal(15,2),
	CONT_COUNTY			decimal(15,2),
	CONT_CITY			decimal(15,2),
	CONT_NONRESALE		decimal(15,2),
	CONT_MARKUP			decimal(15,2),
	NO_CONT_AMT			decimal(15,2),
	NO_CONT_NET			decimal(15,2),
	METHOD				smallint,
	CALC_PCT			decimal(9,3),
	BILL_DATE			smalldatetime,
	AB_ID				integer,
	AB_SEQ				smallint,
	AB_FLAG				smallint,
	FINAL_TYPE			smallint,
	SALES_AMT			decimal(15,2),
	WIP_AMT				decimal(15,2),
	GLACODE_WIP			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_SALES		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_CITY		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_COUNTY		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLACODE_STATE		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	GLACODE_COS			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLESEQ_WIP			smallint,
	GLESEQ_SALES		smallint,
	GLESEQ_STATE		smallint,
	GLESEQ_CNTY			smallint,
	GLESEQ_CITY			smallint,
	GLESEQ_COS			smallint,		
	METHOD_TEXT			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MARKUP_AMT			decimal(15,2) )

CREATE TABLE #functions (
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AB_FLAG				smallint,
	SEQ_NBR				int,
	FROM_ACTUALS		smallint,
	FNC_TYPE			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ACTUAL_AMT			decimal(15,2),
	PO_AMT				decimal(15,2),
	PREV_AMT			decimal(15,2),
	ADV_AMT				decimal(15,2),
	ADV_MARKUP_PCT		decimal(9,3),
	ADV_TAX_CODE		varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADV_TOTAL			decimal(15,2),
	PREV_NET			decimal(15,2),
	ACTUAL_NET			decimal(15,2),
	MARKUP_AMT			decimal(15,2),
	STATE_AMT			decimal(15,2),
	COUNTY_AMT			decimal(15,2),
	CITY_AMT			decimal(15,2),
	NONRESALE_AMT		decimal(15,2),
	TAX_AMT				decimal(15,2),
	ACT_TO_BILL			decimal(15,2),
	ACT_TO_BILL_NET		decimal(15,2),
	ACT_TO_BILL_MU		decimal(15,2),
	ACT_TO_BILL_STATE	decimal(15,2),
	ACT_TO_BILL_COUNTY	decimal(15,2),
	ACT_TO_BILL_CITY	decimal(15,2),
	ACT_TO_BILL_NR		decimal(15,2),
	ACT_BILLED_AMT		decimal(15,2),
	ACT_BILLED_NET		decimal(15,2),
	ACT_BILLED_MU		decimal(15,2),
	ACT_BILLED_STATE	decimal(15,2),
	ACT_BILLED_COUNTY	decimal(15,2),
	ACT_BILLED_CITY		decimal(15,2),
	ACT_BILLED_NR		decimal(15,2),
	ADV_NET_AMT			decimal(15,2),
	ADV_MARKUP_AMT		decimal(15,2),
	ADV_STATE_AMT		decimal(15,2),
	ADV_COUNTY_AMT		decimal(15,2),
	ADV_CITY_AMT		decimal(15,2),
	ADV_NONRESALE_AMT	decimal(15,2),
	ADV_TAX_AMT			decimal(15,2),
	METHOD_TEXT			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADV_NONBILL_FLAG	smallint,
	ADV_MARKUP_FLAG		smallint,
	ADV_TAX_FLAG		smallint,
	ADV_TAX_MU			smallint,
	ADV_TAX_MU_ONLY		smallint,
	ADV_RESALE			smallint,
	ADV_STATE_PCT		decimal(8,4),
	ADV_COUNTY_PCT		decimal(8,4),
	ADV_CITY_PCT		decimal(8,4),
	ADV_BILLED_NET		decimal(15,2),
	ADV_BILLED_TOTAL	decimal(15,2),
	ADV_BILLED_STATE	decimal(15,2),
	ADV_BILLED_COUNTY	decimal(15,2),
	ADV_BILLED_CITY		decimal(15,2),
	ADV_BILLED_NR		decimal(15,2),
	ADV_BILLED_MU		decimal(15,2),
	FINAL_TOTAL			decimal(15,2),
	FINAL_NET			decimal(15,2),
	FINAL_MARKUP		decimal(15,2),
	FINAL_STATE			decimal(15,2),
	FINAL_COUNTY		decimal(15,2),
	FINAL_CITY			decimal(15,2),
	FINAL_NONRESALE		decimal(15,2),
	PO_NET_AMT			decimal(15,2),
	PO_STATE_AMT		decimal(15,2),
	PO_COUNTY_AMT		decimal(15,2),
	PO_CITY_AMT			decimal(15,2),
	PO_NONRESALE_AMT	decimal(15,2),
	PO_TAX_AMT			decimal(15,2),
	PO_RESALE			smallint,
	PO_STATE_PCT		decimal(8,4),
	PO_COUNTY_PCT		decimal(8,4),
	PO_CITY_PCT			decimal(8,4),
	PO_MARKUP_AMT		decimal(15,2),
	PO_MARKUP_PCT		decimal(9,3),
	PO_MARKUP_FLAG		smallint,
	PO_NONBILL_FLAG		smallint,
	PO_TAX_CODE			varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PO_TAX_FLAG			smallint,
	PO_TAX_MU			smallint,
	PO_TAX_MU_ONLY		smallint,
	QTE_NET				decimal(15,2),
	QTE_AMT				decimal(15,2),
	QTE_CITY_AMT		decimal(15,2),
	QTE_CITY_PCT		decimal(8,4),
	QTE_COUNTY_AMT		decimal(15,2),
	QTE_COUNTY_PCT		decimal(8,4),
	QTE_STATE_AMT		decimal(15,2),
	QTE_NONRESALE_AMT	decimal(15,2),
	QTE_MARKUP_AMT		decimal(15,2),
	QTE_MARKUP_FLAG		smallint,
	QTE_MARKUP_PCT		decimal(9,3),
	QTE_NONBILL_FLAG	smallint,
	QTE_RESALE			smallint,
	QTE_STATE_PCT		decimal(8,4),
	QTE_TAX_AMT			decimal(15,2),
	QTE_TAX_CODE		varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	QTE_TAX_FLAG		smallint,
	QTE_TAX_MU			smallint,
	QTE_TAX_MU_ONLY		smallint,
	QTE_CT_CITY_AMT		decimal(15,2),
	QTE_CT_COUNTY_AMT	decimal(15,2),
	QTE_CT_STATE_AMT	decimal(15,2),
	QTE_CT_NR_AMT		decimal(15,2),
	QTE_CT_MU_AMT		decimal(15,2),
	QTE_NOCT_CITY_AMT	decimal(15,2),
	QTE_NOCT_COUNTY_AMT	decimal(15,2),
	QTE_NOCT_STATE_AMT	decimal(15,2),
	QTE_NOCT_NR_AMT		decimal(15,2),
	QTE_NOCT_MU_AMT		decimal(15,2),
	CT_PCT				decimal(9,3),
	CT_AMT				decimal(15,2),
	CT_NET				decimal(15,2),
	NOCT_AMT			decimal(15,2),
	NOCT_NET			decimal(15,2),
	BA_AMT				decimal(15,2) )	

SELECT @ret_val = 0

IF ( @ret_val = 0 )
BEGIN
	-- Gather the actuals
	-- A/P
	INSERT INTO #actuals ( FNC_CODE, FNC_DESC, FNC_TYPE, TABLE_FROM, BILLED_NET, BILLED_TOTAL, FINAL_NET, FINAL_TOTAL,
			OPEN_NET_AMT, OPEN_AMT, INV_NBR, INV_SEQ, TAX_CODE, TAX_MU, TAX_MU_ONLY, RESALE, STATE_PCT, COUNTY_PCT, 
			CITY_PCT, MARKUP_PCT, STATE_AMT, COUNTY_AMT, CITY_AMT, NONRESALE_AMT, MARKUP_AMT  )
		 SELECT A.FNC_CODE, FNC_DESCRIPTION, FNC_TYPE, 53, 
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN NULL
					ELSE AP_PROD_EXT_AMT
				END,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN NULL
					ELSE LINE_TOTAL
				END,
				NULL, NULL,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN AP_PROD_EXT_AMT
					ELSE NULL
				END,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN LINE_TOTAL
					ELSE NULL
				END,
				A.AR_INV_NBR, A.AR_INV_SEQ, TAX_CODE, TAX_COMMISSIONS, A.TAX_COMM_ONLY, TAX_RESALE, 
				TAX_STATE_PCT, TAX_COUNTY_PCT, TAX_CITY_PCT, AP_PROD_COMM_PCT,	
				EXT_STATE_RESALE, EXT_COUNTY_RESALE, EXT_CITY_RESALE, EXT_NONRESALE_TAX, EXT_MARKUP_AMT
		   FROM dbo.AP_PRODUCTION A INNER JOIN dbo.FUNCTIONS B
		     ON ( A.FNC_CODE = B.FNC_CODE ) LEFT OUTER JOIN dbo.ACCT_REC C
		     ON ( A.AR_INV_NBR = C.AR_INV_NBR AND A.AR_INV_SEQ = C.AR_INV_SEQ ) 
		  WHERE A.JOB_NUMBER = @job_number 
			AND A.JOB_COMPONENT_NBR = @job_component_nbr 
			AND ( AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0 )
	   ORDER BY A.FNC_CODE, AP_ID, AP_SEQ
   	
   	-- E/T	     
	INSERT INTO #actuals ( FNC_CODE, FNC_DESC, FNC_TYPE, TABLE_FROM, BILLED_NET, BILLED_TOTAL, FINAL_NET, FINAL_TOTAL,
			OPEN_NET_AMT, OPEN_AMT, INV_NBR, INV_SEQ, TAX_CODE, TAX_MU, TAX_MU_ONLY, RESALE, STATE_PCT, COUNTY_PCT, 
			CITY_PCT, MARKUP_PCT, STATE_AMT, COUNTY_AMT, CITY_AMT, MARKUP_AMT )
		 SELECT A.FNC_CODE, FNC_DESCRIPTION, FNC_TYPE, 54,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN NULL
					ELSE TOTAL_BILL
				END,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN NULL
					ELSE LINE_TOTAL
				END,
				NULL, NULL,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN TOTAL_BILL
					ELSE NULL
				END,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN LINE_TOTAL
					ELSE NULL
				END,
				A.AR_INV_NBR, A.AR_INV_SEQ, TAX_CODE, A.TAX_COMM, A.TAX_COMM_ONLY, TAX_RESALE, 
				A.TAX_STATE_PCT, A.TAX_COUNTY_PCT, A.TAX_CITY_PCT, A.EMP_COMM_PCT, 
				A.EXT_STATE_RESALE, A.EXT_COUNTY_RESALE, A.EXT_CITY_RESALE, A.EXT_MARKUP_AMT
		   FROM dbo.EMP_TIME_DTL A INNER JOIN dbo.FUNCTIONS B
		     ON ( A.FNC_CODE = B.FNC_CODE ) LEFT OUTER JOIN dbo.ACCT_REC C
		     ON ( A.AR_INV_NBR = C.AR_INV_NBR AND A.AR_INV_SEQ = C.AR_INV_SEQ )
		  WHERE A.JOB_NUMBER = @job_number 
			AND A.JOB_COMPONENT_NBR = @job_component_nbr 
			AND ( EMP_NON_BILL_FLAG IS NULL OR EMP_NON_BILL_FLAG = 0 ) 
	   ORDER BY A.FNC_CODE, ET_ID
	   			     
	-- I/O
	INSERT INTO #actuals ( FNC_CODE, FNC_DESC, FNC_TYPE, TABLE_FROM, BILLED_NET, BILLED_TOTAL, FINAL_NET, FINAL_TOTAL,
			OPEN_NET_AMT, OPEN_AMT, INV_NBR, INV_SEQ, TAX_CODE, TAX_MU, TAX_MU_ONLY, RESALE, STATE_PCT, COUNTY_PCT, 
			CITY_PCT, MARKUP_PCT, STATE_AMT, COUNTY_AMT, CITY_AMT, MARKUP_AMT )
		 SELECT A.FNC_CODE, FNC_DESCRIPTION, FNC_TYPE, 56,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN NULL
					ELSE IO_AMOUNT 
				END,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN NULL
					ELSE LINE_TOTAL
				END,
				NULL, NULL,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN IO_AMOUNT
					ELSE NULL 
				END,
				CASE 
					WHEN A.AR_INV_NBR IS NULL THEN LINE_TOTAL
					ELSE NULL
				END,
				A.AR_INV_NBR, A.AR_INV_SEQ, TAX_CODE, A.TAX_COMM, A.TAX_COMM_ONLY, A.TAX_RESALE, 
				TAX_STATE_PCT, TAX_COUNTY_PCT, TAX_CITY_PCT, IO_COMM_PCT, 
				EXT_STATE_RESALE, EXT_COUNTY_RESALE, EXT_CITY_RESALE, EXT_MARKUP_AMT 
		   FROM dbo.INCOME_ONLY A INNER JOIN dbo.FUNCTIONS B
		     ON ( A.FNC_CODE = B.FNC_CODE ) LEFT OUTER JOIN dbo.ACCT_REC C
			 ON ( A.AR_INV_NBR = C.AR_INV_NBR AND A.AR_INV_SEQ = C.AR_INV_SEQ )
	 	  WHERE A.JOB_NUMBER = @job_number 
		    AND A.JOB_COMPONENT_NBR = @job_component_nbr 
		    AND ( A.NON_BILL_FLAG = 0 OR A.NON_BILL_FLAG IS NULL )
	   ORDER BY A.FNC_CODE, IO_ID, SEQ_NBR
	   
	-- P/O   
	DECLARE po_cursor CURSOR FOR 		   
	 SELECT A.FNC_CODE, B.FNC_TYPE, B.FNC_DESCRIPTION, A.PO_EXT_AMOUNT, verds.TAX_CODE,
			verds.TAX_COMM, verds.TAX_COMM_ONLY, verds.TAX_RESALE, verds.TAX_STATE_PCT,
			verds.TAX_COUNTY_PCT, verds.TAX_CITY_PCT, verds.EST_REV_COMM_PCT,
			( SELECT SUM( AP_PROD_EXT_AMT ) 
			    FROM dbo.AP_PRODUCTION ap 
			   WHERE A.PO_NUMBER = ap.PO_NUMBER
			     AND A.LINE_NUMBER = ap.PO_LINE_NUMBER
			     AND A.JOB_NUMBER = ap.JOB_NUMBER
			     AND A.JOB_COMPONENT_NBR = ap.JOB_COMPONENT_NBR
			     AND A.FNC_CODE = ap.FNC_CODE ),
			CASE verds.FNC_CODE WHEN NULL THEN 0 ELSE 1 END
	   FROM dbo.PURCHASE_ORDER_DET A INNER JOIN dbo.FUNCTIONS B
	     ON ( A.FNC_CODE = B.FNC_CODE ) INNER JOIN dbo.PURCHASE_ORDER C
	     ON ( A.PO_NUMBER = C.PO_NUMBER ) LEFT OUTER JOIN dbo.V_EST_REV_DET_SUM verds
	     ON ( A.FNC_CODE = verds.FNC_CODE )
	    AND ( verds.ESTIMATE_NUMBER = @est_nbr )
	    AND ( verds.EST_COMPONENT_NBR = @est_comp_nbr )
	    AND ( verds.EST_QUOTE_NBR = @est_qte_nbr )
	    AND ( verds.EST_REV_NBR = @est_rev_nbr )
	  WHERE JOB_NUMBER = @job_number
		AND JOB_COMPONENT_NBR = @job_component_nbr 
		AND ( A.PO_COMPLETE IS NULL OR A.PO_COMPLETE = 0 ) 
		AND ( VOID_FLAG <> 1 OR VOID_FLAG IS NULL ) 
		AND NOT EXISTS ( SELECT * 
		                   FROM dbo.AP_PRODUCTION D INNER JOIN dbo.AP_HEADER E
		                     ON ( D.AP_ID = E.AP_ID AND D.AP_SEQ = E.AP_SEQ )
		                  WHERE D.PO_NUMBER = A.PO_NUMBER
		                    AND D.PO_LINE_NUMBER = A.LINE_NUMBER
							AND D.PO_COMPLETE = 1 )
		FOR READ ONLY
		
	OPEN po_cursor
	
	FETCH po_cursor INTO @po_fnc_code, @po_fnc_type, @po_fnc_desc, @po_ext_amt,
		@po_tax_code, @po_tax_mu, @po_tax_mu_only, @po_tax_resale, @po_state_pct,
		@po_county_pct, @po_city_pct, @po_mu_pct, @po_applied_amt, @po_est_exists	

	IF( @@FETCH_STATUS = 0 )
	BEGIN
		IF ( @po_est_exists = 0 )
		BEGIN
			-- DEBUG Get rates & pct's through hierarchy
			SELECT 0
		END
		
		-- Get the open PO amount
		SELECT @po_ext_amt = COALESCE(( @po_ext_amt - @po_applied_amt ), 0.00 )  
		
		IF ( @po_ext_amt > 0.00 )
			INSERT INTO #actuals( FNC_CODE, FNC_TYPE, FNC_DESC, TABLE_FROM, OPEN_NET_AMT, OPEN_AMT,
						TAX_CODE, TAX_MU, TAX_MU_ONLY, RESALE, STATE_PCT, COUNTY_PCT, CITY_PCT, MARKUP_PCT,
						STATE_AMT, COUNTY_AMT, CITY_AMT, NONRESALE_AMT, MARKUP_AMT ) 
				VALUES( @po_fnc_code, @po_fnc_type, @po_fnc_desc, 33, @po_ext_amt, @po_line_total,
						@po_tax_code, @po_tax_mu, @po_tax_mu_only, @po_tax_resale, @po_state_pct,
						@po_county_pct, @po_city_pct, @po_mu_pct, @po_state_amt, @po_county_amt,
						@po_city_amt, @po_nonresale_amt, @po_mu_amt )		 
			
	END  

	CLOSE po_cursor
	DEALLOCATE po_cursor	
	
	-- Estimating
	-- DEBUG Flags: SUMMZARIZED? TAXES?
	INSERT INTO #actuals ( FNC_CODE, FNC_DESC, FNC_TYPE, TABLE_FROM, NO_CONT_NET, NO_CONT_AMT, 
				CONT_AMT, CONT_NET, CONT_MARKUP, CONT_STATE, CONT_COUNTY, CONT_CITY, CONT_NONRESALE,
				TAX_CODE, TAX_MU, TAX_MU_ONLY, RESALE, STATE_PCT, COUNTY_PCT,
				CITY_PCT, MARKUP_PCT, STATE_AMT, COUNTY_AMT, CITY_AMT, NONRESALE_AMT,
				MARKUP_AMT )
		 SELECT A.FNC_CODE, A.FNC_DESCRIPTION, A.FNC_TYPE, 8, EST_REV_EXT_AMT, LINE_TOTAL,
				COALESCE( EXT_CONTINGENCY, 0.00 ) + COALESCE( EST_REV_EXT_AMT, 0.00 ),
				COALESCE( LINE_TOTAL_CONT, 0.00 ) + COALESCE( LINE_TOTAL, 0.00 ),
				COALESCE( EXT_MU_CONT, 0.00 ) + COALESCE( EXT_MARKUP_AMT, 0.00 ),
				COALESCE( EXT_STATE_CONT, 0.00 ) + COALESCE( EXT_STATE_RESALE, 0.00 ),
				COALESCE( EXT_COUNTY_CONT, 0.00 ) + COALESCE( EXT_COUNTY_RESALE, 0.00 ),
				COALESCE( EXT_CITY_CONT, 0.00 ) + COALESCE( EXT_CITY_RESALE, 0.00 ),
				COALESCE( EXT_NR_CONT, 0.00 ) + COALESCE( EXT_NONRESALE_TAX, 0.00 ),
				TAX_CODE, A.TAX_COMM, A.TAX_COMM_ONLY, TAX_RESALE, TAX_STATE_PCT, TAX_COUNTY_PCT,
				TAX_CITY_PCT, EST_REV_COMM_PCT, EXT_STATE_RESALE, EXT_COUNTY_RESALE,
				EXT_CITY_RESALE, EXT_NONRESALE_TAX, EXT_MARKUP_AMT 
		   FROM dbo.V_EST_REV_DET_SUM A INNER JOIN dbo.FUNCTIONS B
		     ON ( A.FNC_CODE = B.FNC_CODE ) 
		  WHERE ESTIMATE_NUMBER = @est_nbr 
			AND EST_COMPONENT_NBR = @est_comp_nbr
			AND EST_QUOTE_NBR = @est_qte_nbr 
			AND EST_REV_NBR = @est_rev_nbr 
		    AND ( FNC_NONBILL_FLAG IS NULL OR FNC_NONBILL_FLAG = 0 )

	-- A/B
	INSERT INTO #actuals ( FNC_CODE, FNC_DESC, FNC_TYPE, TABLE_FROM, BILLED_NET, BILLED_TOTAL, FINAL_NET, FINAL_TOTAL,
			OPEN_NET_AMT, OPEN_AMT, INV_NBR, INV_SEQ, TAX_CODE, TAX_MU, TAX_MU_ONLY, RESALE, STATE_PCT, COUNTY_PCT, 
			CITY_PCT, MARKUP_PCT, STATE_AMT, COUNTY_AMT, CITY_AMT, MARKUP_AMT, NONRESALE_AMT, SEQ_NBR,
			METHOD, CALC_PCT, BILL_DATE )
	 SELECT A.FNC_CODE, FNC_DESCRIPTION, A.FNC_TYPE, 58,  
			CASE 
				WHEN AR_INV_NBR IS NULL THEN NULL
				ELSE ADV_BILL_NET_AMT 
			END,
			CASE 
				WHEN AR_INV_NBR IS NULL THEN NULL
				ELSE LINE_TOTAL
			END,
			CASE 
				WHEN ( AR_INV_NBR IS NULL ) AND ( AB_FLAG = 3 )THEN ADV_BILL_NET_AMT
				ELSE NULL
			END,
			CASE 
				WHEN ( AR_INV_NBR IS NULL ) AND ( AB_FLAG = 3 )THEN LINE_TOTAL
				ELSE NULL
			END,
			CASE 
				WHEN ( AR_INV_NBR IS NULL ) AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL )THEN ADV_BILL_NET_AMT
				ELSE NULL
			END,
			CASE 
				WHEN ( AR_INV_NBR IS NULL ) AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL )THEN LINE_TOTAL
				ELSE NULL
			END,
			AR_INV_NBR, AR_INV_SEQ, A.TAX_CODE, A.TAX_COMM, A.TAX_COMM_ONLY, A.TAX_RESALE, 
			TAX_STATE_PCT, TAX_COUNTY_PCT, TAX_CITY_PCT, COMMISSION_PCT, EXT_STATE_RESALE,
			EXT_COUNTY_RESALE, EXT_CITY_RESALE, EXT_MARKUP_AMT, EXT_NONRESALE_TAX,
			CASE
				WHEN ( AR_INV_NBR IS NULL ) 
				 AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL )
				 AND ( LINE_TOTAL <> 0.00 ) 
				 AND ( LINE_TOTAL IS NOT NULL ) 
				THEN SEQ_NBR
				ELSE NULL
			END,
			CALC_METHOD, CALC_PERCENT, BILL_DATE	
	   FROM dbo.ADVANCE_BILLING A INNER JOIN dbo.FUNCTIONS B
	     ON ( A.FNC_CODE = B.FNC_CODE )  
	  WHERE JOB_NUMBER = @job_number
	    AND JOB_COMPONENT_NBR = @job_component_nbr 
   ORDER BY A.FNC_CODE, AB_ID, SEQ_NBR
   
   -- Billing Approval
   -- DEBUG Need the BA_HDR_ID to include
   /*
	INSERT INTO #actuals ( FNC_CODE, FNC_DESC, FNC_TYPE, TABLE_FROM, APPR_AMT )
		  SELECT A.FNC_CODE, FNC_DESCRIPTION, FNC_TYPE, 107, COALESCE( A.APPR_NET, A.APPROVED_AMT )
		    FROM dbo.BILL_APPR_DTL A INNER JOIN FUNCTIONS B
		      ON ( A.FNC_CODE = B.FNC_CODE ) INNER JOIN dbo.BILL_APPR_HDR D
			  ON ( A.BA_ID = D.BA_ID )
			 AND A.JOB_NUMBER = D.JOB_NUMBER
			 AND A.JOB_COMPONENT_NBR = D.JOB_COMPONENT_NBR
		   WHERE D.BA_HDR_ID = :a_nBA_HDR_ID 
		     AND D.JOB_NUMBER = @job_number 
			 AND D.JOB_COMPONENT_NBR = @job_component_nbr
    */
    
/****************************************************************************************************************************************/
--	#functions 	    
/****************************************************************************************************************************************/ 	  
	-- DEBUG Add prev amts to next SQL stmt
	INSERT INTO #functions ( FNC_CODE, FNC_TYPE, FROM_ACTUALS )
		 SELECT FNC_CODE, FNC_TYPE, 1
		   FROM #actuals
	   GROUP BY FNC_CODE, FNC_TYPE 
	
	-- Update #functions table with PO data
     UPDATE #functions
        SET PO_AMT = (				SELECT SUM( COALESCE( #actuals.OPEN_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_NET_AMT = (			SELECT SUM( COALESCE( #actuals.OPEN_NET_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_STATE_AMT = (		SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_COUNTY_AMT = (		SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_CITY_AMT = (			SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_MARKUP_AMT = (		SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_NONRESALE_AMT = (	SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 ))
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_MARKUP_PCT = (		SELECT CASE WHEN MAX( #actuals.MARKUP_PCT ) = MIN( #actuals.MARKUP_PCT ) THEN MAX( #actuals.MARKUP_PCT ) ELSE NULL END  
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
							 		   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_STATE_PCT = (		SELECT CASE WHEN MAX( #actuals.STATE_PCT ) = MIN( #actuals.STATE_PCT ) THEN MAX( #actuals.STATE_PCT ) ELSE NULL END 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_COUNTY_PCT = (		SELECT CASE WHEN MAX( #actuals.COUNTY_PCT ) = MIN( #actuals.COUNTY_PCT ) THEN MAX( #actuals.COUNTY_PCT ) ELSE NULL END
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
							 		   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_CITY_PCT = (			SELECT CASE WHEN MAX( #actuals.CITY_PCT ) = MIN( #actuals.CITY_PCT ) THEN MAX( #actuals.CITY_PCT ) ELSE NULL END 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_TAX_MU = (			SELECT CASE WHEN MAX( #actuals.TAX_MU ) = MIN( #actuals.TAX_MU ) THEN MAX( #actuals.TAX_MU ) ELSE NULL END 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
						  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_TAX_MU_ONLY = (		SELECT CASE WHEN MAX( #actuals.TAX_MU_ONLY ) = MIN( #actuals.TAX_MU_ONLY ) THEN MAX( #actuals.TAX_MU_ONLY ) ELSE NULL END 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_TAX_CODE = (			SELECT CASE WHEN MAX( #actuals.TAX_CODE ) = MIN( #actuals.TAX_CODE ) THEN MAX( #actuals.TAX_CODE ) ELSE NULL END 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_RESALE = (			SELECT CASE WHEN MAX( #actuals.RESALE ) = MIN( #actuals.RESALE ) THEN MAX( #actuals.RESALE ) ELSE NULL END 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 ),
			PO_TAX_AMT = (			SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 ) + COALESCE( #actuals.COUNTY_AMT, 0.00 ) + COALESCE( #actuals.CITY_AMT , 0.00 ) + COALESCE( #actuals.NONRESALE_AMT, 0.00 ))  
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 33 )
	
    -- Update #functions table with estimate data
     UPDATE #functions
        SET CT_PCT = (				SELECT CASE	WHEN MAX( CONT_PCT ) = MIN( CONT_PCT ) THEN MAX( CONT_PCT )	ELSE NULL END 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ),
			CT_AMT = (				SELECT SUM( COALESCE( #actuals.CONT_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			CT_NET = (				SELECT SUM( COALESCE( #actuals.CONT_NET, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_CT_MU_AMT = (		SELECT SUM( COALESCE( #actuals.CONT_MARKUP, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_CT_STATE_AMT = (	SELECT SUM( COALESCE( #actuals.CONT_STATE, 0.00 ))  
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_CT_COUNTY_AMT = (	SELECT SUM( COALESCE( #actuals.CONT_COUNTY, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ),  
			QTE_CT_CITY_AMT = (		SELECT SUM( COALESCE( #actuals.CONT_CITY, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ),
			QTE_CT_NR_AMT = (		SELECT SUM( COALESCE( #actuals.CONT_NONRESALE, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			NOCT_AMT = (			SELECT SUM( COALESCE( #actuals.NO_CONT_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			NOCT_NET = (			SELECT SUM( COALESCE( #actuals.NO_CONT_NET, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_NOCT_MU_AMT = (		SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_NOCT_STATE_AMT = (	SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_NOCT_COUNTY_AMT = ( SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_NOCT_CITY_AMT = (	SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 )) 
									  FROM #actuals 
								     WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ),
			QTE_NOCT_NR_AMT = (		SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 )) 
									  FROM #actuals 
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE  
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_AMT = (				SELECT CASE WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_AMT, 0.00 )) ELSE SUM( COALESCE( #actuals.NO_CONT_AMT, 0.00 )) END 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_NET = (				SELECT CASE WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_NET, 0.00 )) ELSE SUM( COALESCE( #actuals.NO_CONT_NET, 0.00 )) END  
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_MARKUP_AMT = (		SELECT CASE WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_MARKUP, 0.00 )) ELSE SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 )) END  
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_STATE_AMT = (		SELECT CASE WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_STATE, 0.00 )) ELSE SUM( COALESCE( #actuals.STATE_AMT, 0.00 )) END 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_COUNTY_AMT = (		SELECT CASE WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_COUNTY, 0.00 )) ELSE SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 )) END 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_CITY_AMT = (		SELECT CASE WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_CITY, 0.00 )) ELSE SUM( COALESCE( #actuals.CITY_AMT, 0.00 )) END 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_NONRESALE_AMT = (	SELECT CASE WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_NONRESALE, 0.00 )) ELSE SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 )) END 
									  FROM #actuals
								     WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ),
			QTE_TAX_AMT = (			SELECT
										CASE 
											WHEN @contingency = 1 THEN SUM( COALESCE( #actuals.CONT_STATE, 0.00 ) + COALESCE( #actuals.CONT_COUNTY, 0.00 )
																		  + COALESCE( #actuals.CONT_CITY, 0.00 ) + COALESCE( #actuals.CONT_NONRESALE, 0.00 ))
	 										ELSE SUM( COALESCE( #actuals.STATE_AMT, 0.00 ) + COALESCE( #actuals.COUNTY_AMT, 0.00 ) 
	 												+ COALESCE( #actuals.CITY_AMT, 0.00 ) + COALESCE( #actuals.NONRESALE_AMT, 0.00 ))						  
										END 
								      FROM #actuals
								     WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_TAX_CODE = (		SELECT CASE WHEN MAX( #actuals.TAX_CODE ) = MIN( #actuals.TAX_CODE ) THEN MAX( #actuals.TAX_CODE ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_STATE_PCT = (		SELECT CASE WHEN MAX( #actuals.STATE_PCT ) = MIN( #actuals.STATE_PCT ) THEN MAX( #actuals.STATE_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_COUNTY_PCT = (		SELECT CASE WHEN MAX( #actuals.COUNTY_PCT ) = MIN( #actuals.COUNTY_PCT ) THEN MAX( #actuals.COUNTY_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_CITY_PCT = (		SELECT CASE WHEN MAX( #actuals.CITY_PCT ) = MIN( #actuals.CITY_PCT ) THEN MAX( #actuals.CITY_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_TAX_MU = (			SELECT CASE WHEN MAX( #actuals.TAX_MU ) = MIN( #actuals.TAX_MU ) THEN MAX( #actuals.TAX_MU ) ELSE NULL END
									  FROM #actuals	
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_TAX_MU_ONLY = (		SELECT CASE WHEN MAX( #actuals.TAX_MU_ONLY ) = MIN( #actuals.TAX_MU_ONLY ) THEN MAX( #actuals.TAX_MU_ONLY ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_RESALE = (			SELECT CASE WHEN MAX( #actuals.RESALE ) = MIN( #actuals.RESALE ) THEN MAX( #actuals.RESALE ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ), 
			QTE_MARKUP_PCT = (		SELECT CASE WHEN MAX( #actuals.MARKUP_PCT ) = MIN( #actuals.MARKUP_PCT ) THEN MAX( #actuals.MARKUP_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 8 ) 

    -- Update #functions table with advance billing data
     UPDATE #functions
		SET ADV_BILLED_TOTAL = (	SELECT SUM( COALESCE( #actuals.BILLED_TOTAL, 0.00 )) 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
								       AND #actuals.TABLE_FROM = 58
								       AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ADV_BILLED_NET = (		SELECT SUM( COALESCE( #actuals.BILLED_NET, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ADV_BILLED_STATE = (	SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
								       AND #actuals.TABLE_FROM = 58
								       AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ADV_BILLED_COUNTY = (	SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ADV_BILLED_CITY = (		SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 ))
									  FROM #actuals
								     WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
								       AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ADV_BILLED_MU = (		SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ADV_BILLED_NR = (		SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			FINAL_TOTAL = (			SELECT SUM( COALESCE( #actuals.FINAL_TOTAL, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NOT NULL ),
			ADV_AMT = (				SELECT SUM( COALESCE( #actuals.OPEN_NET_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_TOTAL = (			SELECT SUM( COALESCE( #actuals.OPEN_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_STATE_AMT = (		SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_COUNTY_AMT = (		SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_CITY_AMT = (		SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_MARKUP_AMT = (		SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_NONRESALE_AMT = (	SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 ))
									  FROM #actuals
								     WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_MARKUP_PCT = (		SELECT CASE WHEN MAX( #actuals.MARKUP_PCT ) = MIN( #actuals.MARKUP_PCT ) THEN MAX( #actuals.MARKUP_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_STATE_PCT = (		SELECT CASE WHEN MAX( #actuals.STATE_PCT ) = MIN( #actuals.STATE_PCT ) THEN MAX( #actuals.STATE_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_COUNTY_PCT = (		SELECT CASE WHEN MAX( #actuals.COUNTY_PCT ) = MIN( #actuals.COUNTY_PCT ) THEN MAX( #actuals.COUNTY_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_CITY_PCT = (		SELECT CASE WHEN MAX( #actuals.CITY_PCT ) = MIN( #actuals.CITY_PCT ) THEN MAX( #actuals.CITY_PCT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_RESALE = (			SELECT CASE WHEN MAX( #actuals.RESALE ) = MIN( #actuals.RESALE ) THEN MAX( #actuals.RESALE ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_TAX_MU = (			SELECT CASE WHEN MAX( #actuals.TAX_MU ) = MIN( #actuals.TAX_MU ) THEN MAX( #actuals.TAX_MU ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_TAX_MU_ONLY = (		SELECT CASE WHEN MAX( #actuals.TAX_MU_ONLY ) = MIN( #actuals.TAX_MU_ONLY ) THEN MAX( #actuals.TAX_MU_ONLY ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
 									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_TAX_CODE = (		SELECT CASE WHEN MAX( #actuals.TAX_CODE ) = MIN( #actuals.TAX_CODE ) THEN MAX( #actuals.TAX_CODE ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ADV_TAX_AMT = (			SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 ) + COALESCE( #actuals.COUNTY_AMT, 0.00 ) 
											  + COALESCE( #actuals.CITY_AMT , 0.00 ) + COALESCE( #actuals.NONRESALE_AMT, 0.00 )) 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL ),
			METHOD_TEXT = (			SELECT CASE WHEN MAX( #actuals.METHOD_TEXT ) = MIN( #actuals.METHOD_TEXT ) THEN MAX( #actuals.METHOD_TEXT ) ELSE NULL END
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE 
									   AND #actuals.TABLE_FROM = 58
									   AND #actuals.BILLED_TOTAL IS NULL 
									   AND #actuals.FINAL_TOTAL IS NULL )								    									 

	-- Update #functions table with billing approval data
     UPDATE #functions
        SET BA_AMT = (				SELECT SUM( COALESCE( #actuals.APPR_AMT, 0.00 )) 
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM = 107 )
		 	 
	-- Update #functions table with billed actual data
	 UPDATE #functions
	    SET ACT_BILLED_AMT = (		SELECT SUM( COALESCE( #actuals.BILLED_TOTAL, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ACT_BILLED_NET = (		SELECT SUM( COALESCE( #actuals.BILLED_NET, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ACT_BILLED_STATE = (	SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 ))
								      FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
								       AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
								       AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ACT_BILLED_COUNTY = (	SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 ))
								      FROM #actuals
								     WHERE #functions.FNC_CODE = #actuals.FNC_CODE
								       AND #functions.FNC_TYPE = #actuals.FNC_TYPE
								       AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
								       AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ACT_BILLED_CITY = (		SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ACT_BILLED_MU = (		SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NOT NULL ),
			ACT_BILLED_NR = (		SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NOT NULL )
	
	-- Update #functions table with final actual data
	 UPDATE #functions
	    SET FINAL_TOTAL = (			SELECT SUM( COALESCE( #actuals.FINAL_TOTAL, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NOT NULL ),
			FINAL_NET = (			SELECT SUM( COALESCE( #actuals.FINAL_NET, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NOT NULL ),
			FINAL_STATE = (			SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NOT NULL ),
			FINAL_COUNTY = (		SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NOT NULL ),
			FINAL_CITY = (			SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NOT NULL ),
			FINAL_MARKUP = (		SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NOT NULL ),
			FINAL_NONRESALE = (		SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NOT NULL ) 

	-- Update #functions table with open actual data
	 UPDATE #functions
		SET	ACT_TO_BILL_NET = (		SELECT SUM( COALESCE( #actuals.OPEN_NET_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ACT_TO_BILL_STATE = (	SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 ))
									  FROM #actuals
								     WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ACT_TO_BILL_COUNTY = (  SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ACT_TO_BILL_CITY = (	SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ACT_TO_BILL_MU = (		SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NULL ),
			ACT_TO_BILL_NR = (		SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 ))
									  FROM #actuals
									 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
									   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
									   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )
									   AND #actuals.BILLED_TOTAL IS NULL
									   AND #actuals.FINAL_TOTAL IS NULL )
	
	-- Update #functions table with rest of actual data
	 UPDATE #functions
		SET ACTUAL_NET = (		    SELECT SUM( COALESCE( #actuals.OPEN_NET_AMT, 0.00 ) + COALESCE( #actuals.BILLED_NET, 0.00 ) + COALESCE( #actuals.FINAL_NET, 0.00 ))
		                  			  FROM #actuals
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
		                  			   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )),
			ACTUAL_AMT = (			SELECT SUM( COALESCE( #actuals.OPEN_AMT, 0.00 ) + COALESCE( #actuals.BILLED_TOTAL, 0.00 ) + COALESCE( #actuals.FINAL_TOTAL, 0.00 )) 
									  FROM #actuals
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
		                  			   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )),							                  	      
			STATE_AMT = (			SELECT SUM( COALESCE( #actuals.STATE_AMT, 0.00 )) 
									  FROM #actuals
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
		                  			   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )),
			COUNTY_AMT = (			SELECT SUM( COALESCE( #actuals.COUNTY_AMT, 0.00 ))
									  FROM #actuals
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
		                  			   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )),
			CITY_AMT = (			SELECT SUM( COALESCE( #actuals.CITY_AMT, 0.00 ))
									  FROM #actuals
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
		                  			   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )),
			NONRESALE_AMT = (		SELECT SUM( COALESCE( #actuals.NONRESALE_AMT, 0.00 ))
									  FROM #actuals			                  	      
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
		                  			   AND #actuals.TABLE_FROM IN ( 53, 54, 56 )),
			MARKUP_AMT = (			SELECT SUM( COALESCE( #actuals.MARKUP_AMT, 0.00 ))
									  FROM #actuals			                  	      
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE
		                  			   AND #actuals.TABLE_FROM IN ( 53, 54, 56 ))

	-- Update #functions table with rest of actual data
	 UPDATE #functions
	    SET PREV_NET = (			SELECT SUM( COALESCE( #actuals.BILLED_NET, 0.00 ))
									  FROM #actuals			                  	      
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE ),
			PREV_AMT = (			SELECT SUM( COALESCE( #actuals.BILLED_TOTAL, 0.00 ))
									  FROM #actuals			                  	      
		                  			 WHERE #functions.FNC_CODE = #actuals.FNC_CODE
		                  			   AND #functions.FNC_TYPE = #actuals.FNC_TYPE )

	-- Update #functions table with actuals to bill
	 UPDATE #functions
		SET ACT_TO_BILL =			COALESCE( ACTUAL_AMT, 0.00 ) - COALESCE( ACT_BILLED_AMT, 0.00 )

END

SELECT * FROM #functions
