
/****** Object:  StoredProcedure [dbo].[advsp_ar_np_coop_splits]    Script Date: 04/21/2013 10:38:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_ar_np_coop_splits]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_ar_np_coop_splits]
GO

/****** Object:  StoredProcedure [dbo].[advsp_ar_np_coop_splits]    Script Date: 04/21/2013 10:38:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[advsp_ar_np_coop_splits] @campaign smallint, @job_number integer, @job_component_nbr smallint, 
	@estimate_number integer, @est_component_nbr smallint, @fold_fnc_code varchar(6), @coop_code varchar(6),
	@billing_ind smallint, @created_by varchar(100), @ret_val integer OUTPUT
AS

SET ANSI_WARNINGS OFF
SET NOCOUNT ON

/*
@campaign - from current job (not used at this time)
@job_number/@job_component_nbr - from current job
@estimate_number/@est_component_nbr - from current job (not used at this time)
@fold_fnc_code - user selected funtion matched with Vendor related to Orders related to matching campaigns
@coop_code - from current job (will be null if this is a dynamic coop split)
@billing_ind - "1" if called from billing (not used at this time)
@created_by - current user
@ret_val - OUTPUT - 0 (zero by default)
*/

/* @ret_val Values
*  0	Success
*  1	Failed
*/ 

DECLARE @total_print_qty decimal(15,2), @job_nobill_flag smallint, @cpm_flag smallint
DECLARE @fnc_code varchar(6), @ret_code smallint, @cmp_id int
DECLARE @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6)
DECLARE @seq_nbr int, @est_cmp_flag smallint, @est_nonbill_flag smallint
DECLARE @est_rev_qty decimal(15,2), @est_rev_ext_amt decimal(15,2)
DECLARE @est_markup_amt decimal(15,2), @est_resale_tax_amt decimal(15,2)
DECLARE @line_total decimal(15,2), @ext_contingemcy decimal(15,2), @line_total_cont decimal(15,2)
DECLARE @coop_pct decimal(8,5), @fold_pct decimal(8,5)
DECLARE @print_qty decimal(14,3), @fold_qty decimal(14,3)
DECLARE @coop_id int, @current_date smalldatetime
--Split calc variables
DECLARE @est_rev_qty2 decimal(15,2), @est_rev_ext_amt2 decimal(15,2)
DECLARE @est_markup_amt2 decimal(15,2), @est_resale_tax_amt2 decimal(15,2)
DECLARE @line_total2 decimal(15,2), @ext_contingemcy2 decimal(15,2), @line_total_cont2 decimal(15,2)

SELECT @ret_val = 0

--Clear old data
DELETE FROM dbo.AR_COOP_EST_TMP
	WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr
  
DELETE FROM dbo.AR_COOP_EST_SPLITS
	WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr
--	AND ESTIMATE_NUMBER = @estimate_number AND EST_COMPONENT_NBR = @est_component_nbr

IF (@coop_code IS NULL)
	BEGIN
		IF ( @ret_val = 0 )
		BEGIN
		CREATE TABLE #ar_coop_est_splits ( 
			CL_CODE				varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			DIV_CODE			varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			PRD_CODE			varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			JOB_NUMBER			int ,
			JOB_COMPONENT_NBR	smallint , 		
			CMP_IDENTIFIER		int ,
			PRINT_QUANTITY		decimal(14, 3) ,
			FOLD_FLAG			int )
			
		CREATE TABLE #ar_coop_est_splits2(
			CL_CODE				varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			DIV_CODE			varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			PRD_CODE			varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			JOB_NUMBER			int ,
			JOB_COMPONENT_NBR	smallint ,
			CMP_IDENTIFIER		int ,		
			PRINT_QUANTITY		decimal(14, 3) ,
			FOLD_QUANTITY		decimal(14, 3) ,
			TOTAL_QUANTITY		decimal(14, 3) ,
			TOTAL_FOLD_QUANTITY	decimal(14, 3) )
			
		CREATE TABLE #ar_coop_est_splits3(
			CL_CODE				varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			DIV_CODE			varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			PRD_CODE			varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS ,
			JOB_NUMBER			int ,
			JOB_COMPONENT_NBR	smallint ,	
			CMP_IDENTIFIER		int ,		
			PRINT_QUANTITY		decimal(14, 3) ,
			FOLD_QUANTITY		decimal(14, 3) ,
			TOTAL_QUANTITY		decimal(14, 3) ,
			TOTAL_FOLD_QUANTITY	decimal(14, 3) )		

		SELECT @ret_val = 0
		SELECT @created_by = LTRIM( RTRIM( @created_by ))
		END

		IF ( @ret_val = 0 )
		BEGIN
			--Some Vendors have NULL for FOLD_FLAG instead of 0 (Zero) 
			--From CP.CMP_CODE = @campaign to CMP_IDENTIFIER @campaign
			--@job_number  @job_component_nbr
			INSERT INTO #ar_coop_est_splits( CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER, PRINT_QUANTITY, FOLD_FLAG )
			SELECT	NH.CL_CODE, NH.DIV_CODE, NH.PRD_CODE, CP.JOB_NUMBER, CP.JOB_COMPONENT_NBR, CP.CMP_IDENTIFIER, SUM(PRINT_QUANTITY), 
					CASE 
						WHEN V.FOLD = 1
						   THEN 1
						   ELSE 0 
					END AS FOLD
				FROM CAMPAIGN CP, NEWSPAPER_HEADER NH, NEWSPAPER_DETAIL ND, VENDOR V
				WHERE CP.JOB_NUMBER = @job_number
					AND CP.JOB_COMPONENT_NBR = @job_component_nbr 
					AND CP.CMP_IDENTIFIER = NH.CMP_IDENTIFIER
					AND NH.ORDER_NBR = ND.ORDER_NBR
					AND NH.VN_CODE = V.VN_CODE
					AND ND.ACTIVE_REV = 1 AND ND.LINE_CANCELLED IS NULL			
				GROUP BY NH.CL_CODE, NH.DIV_CODE, NH.PRD_CODE, CP.JOB_NUMBER, CP.JOB_COMPONENT_NBR, CP.CMP_IDENTIFIER,
					CASE 
						WHEN V.FOLD = 1
						   THEN 1
						   ELSE 0 
					END
			IF @@ERROR <> 0 
			BEGIN
			   SELECT @ret_val = 1
			END
		END		

		IF ( @ret_val = 0 )
		BEGIN
			SELECT * FROM #ar_coop_est_splits --DEBUG DATA
			--Calculate Gtotals by C/D/P and FOLD Flag and Client
			INSERT INTO #ar_coop_est_splits2 ( CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
												PRINT_QUANTITY, FOLD_QUANTITY, TOTAL_QUANTITY, TOTAL_FOLD_QUANTITY )
			SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
				CASE 
					WHEN (0) = 0
					   THEN (SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs2
							 WHERE cs2.CL_CODE = cs1.CL_CODE AND cs2.DIV_CODE = cs1.DIV_CODE 
								AND cs2.PRD_CODE = cs1.PRD_CODE AND cs2.CMP_IDENTIFIER = cs1.CMP_IDENTIFIER )
					   ELSE 0 
				END AS PRINT_QTY,
				CASE 
					WHEN (FOLD_FLAG) = 1
					   THEN	(SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs3
							 WHERE FOLD_FLAG = 1 AND cs3.CL_CODE = cs1.CL_CODE AND cs3.DIV_CODE = cs1.DIV_CODE 
								AND cs3.PRD_CODE = cs1.PRD_CODE AND cs3.CMP_IDENTIFIER = cs1.CMP_IDENTIFIER )
					   ELSE 0 
				END AS FOLD_QTY,
				(SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs4
				 WHERE cs4.CL_CODE = cs1.CL_CODE),
				 (SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs5
				 WHERE cs5.CL_CODE = cs1.CL_CODE AND FOLD_FLAG = 1) 
			FROM #ar_coop_est_splits cs1
			
			IF @@ERROR <> 0 
			BEGIN
			   SELECT @ret_val = 1
			END
			
			--Calculate Gtotals by C/D/P and FOLD Flag and Client
			INSERT INTO #ar_coop_est_splits3 ( CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
												PRINT_QUANTITY, FOLD_QUANTITY, TOTAL_QUANTITY, TOTAL_FOLD_QUANTITY )
			SELECT CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
					MAX(PRINT_QUANTITY), MAX(FOLD_QUANTITY), MAX(TOTAL_QUANTITY), MAX(TOTAL_FOLD_QUANTITY)
			FROM #ar_coop_est_splits2 cs
			GROUP BY CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER
			
			IF @@ERROR <> 0 
			BEGIN
			   SELECT @ret_val = 1
			END		
		END

		SELECT * FROM #ar_coop_est_splits3 --DEBUG DATA

		IF ( @ret_val = 0 )
		BEGIN
			SELECT @coop_id = 1
			
			--Insert Coop PCTs
			INSERT INTO AR_COOP_EST_TMP( COOP_ID, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
								COOP_PCT, FOLD_PCT, PRINT_QUANTITY, FOLD_QUANTITY )
			SELECT 0, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
				CAST(SUM(PRINT_QUANTITY/TOTAL_QUANTITY*100) AS decimal(10,3)) AS COOP_PCT, 
				CAST(SUM(FOLD_QUANTITY/TOTAL_FOLD_QUANTITY*100) AS decimal(10,3)) AS FOLD_PCT,
				SUM(PRINT_QUANTITY), SUM(FOLD_QUANTITY)
			FROM #ar_coop_est_splits3
			GROUP BY CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER
			IF @@ERROR <> 0 
			   SELECT @ret_val = 1
		END

		SELECT @current_date = GETDATE()

	END
ELSE 
	BEGIN 
		--Will never equal if using BILLING_COOP
		SELECT @fold_fnc_code = '*SKIP*' 
	END

--Split Estimate Detail here if not called from billing
IF ( @ret_val = 0 )
	IF (@coop_code IS NULL)
		BEGIN
			SELECT * FROM AR_COOP_EST_TMP --DEBUG DATA
			--// AR_COOP_EST_TMP - Dynamic %'s from NP Quantities \\ 
			INSERT INTO AR_COOP_EST_SPLITS( CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR
				,ESTIMATE_NUMBER,EST_COMPONENT_NBR,SEQ_NBR,FNC_CODE
				,FOLD_FLAG,FNC_CPM_FLAG,EST_NONBILL_FLAG,CMP_IDENTIFIER
				,EST_REV_QUANTITY,EST_REV_EXT_AMT,TOT_MARKUP_AMT,TOT_TAX_AMT
				,LINE_TOTAL,TOT_CONT_AMT,LINE_TOTAL_CONT,CREATED_BY,CREATE_DATE )				
			SELECT	AR.CL_CODE, AR.DIV_CODE, AR.PRD_CODE, JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR, 
					ED.ESTIMATE_NUMBER, EA.EST_COMPONENT_NBR, ED.SEQ_NBR, ED.FNC_CODE, 
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
						   THEN 1
						   ELSE 0 
						END AS FOLD_FLAG,
					ED.EST_CPM_FLAG, ED.EST_NONBILL_FLAG, AR.CMP_IDENTIFIER,
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
							   THEN (ED.EST_REV_QUANTITY * FOLD_PCT * .01)
							   ELSE (ED.EST_REV_QUANTITY * COOP_PCT * .01)
						END AS EST_REV_QUANTITY	, 
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
							   THEN (ED.EST_REV_EXT_AMT * FOLD_PCT * .01)
							   ELSE (ED.EST_REV_EXT_AMT * COOP_PCT * .01)
						END AS EST_REV_EXT_AMT	, 
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
							   THEN (ED.EXT_MARKUP_AMT * FOLD_PCT * .01)
							   ELSE (ED.EXT_MARKUP_AMT * COOP_PCT * .01)
						END AS EXT_MARKUP_AMT	, 
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
							   THEN ((EXT_STATE_RESALE+EXT_COUNTY_RESALE+EXT_CITY_RESALE) * FOLD_PCT * .01)
							   ELSE ((EXT_STATE_RESALE+EXT_COUNTY_RESALE+EXT_CITY_RESALE) * COOP_PCT * .01)
						END AS RESALE_TAX	, 
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
							   THEN (ED.LINE_TOTAL * FOLD_PCT * .01)
							   ELSE (ED.LINE_TOTAL * COOP_PCT * .01)
						END AS LINE_TOTAL	, 
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
							   THEN (ED.EXT_CONTINGENCY * FOLD_PCT * .01)
							   ELSE (ED.EXT_CONTINGENCY * COOP_PCT * .01)
						END AS EXT_CONTINGENCY	, 
					CASE 
						WHEN UPPER(FNC_CODE) = UPPER(@fold_fnc_code)
							   THEN (ED.LINE_TOTAL_CONT * FOLD_PCT * .01)
							   ELSE (ED.LINE_TOTAL_CONT * COOP_PCT * .01)
						END AS LINE_TOTAL_CONT,
						'SYSADM',GETDATE()
			FROM ESTIMATE_LOG EL
			INNER JOIN ESTIMATE_REV_DET ED ON 
					(EL.ESTIMATE_NUMBER = ED.ESTIMATE_NUMBER)
			INNER JOIN V_ESTIMATEAPPR EA ON 
					(EA.ESTIMATE_NUMBER = ED.ESTIMATE_NUMBER AND EA.EST_COMPONENT_NBR = ED.EST_COMPONENT_NBR AND
					 EA.EST_QUOTE_NBR = ED.EST_QUOTE_NBR AND EA.EST_REVISION_NBR = ED.EST_REV_NBR)
			INNER JOIN JOB_COMPONENT JC ON
					(ED.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER AND ED.EST_COMPONENT_NBR = JC.EST_COMPONENT_NBR)	
			INNER JOIN AR_COOP_EST_TMP AR ON
					(AR.CL_CODE = EL.CL_CODE AND AR.JOB_NUMBER = JC.JOB_NUMBER AND AR.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR)	
			WHERE AR.JOB_NUMBER = @job_number
					AND AR.JOB_COMPONENT_NBR = @job_component_nbr					
		END
	ELSE
		BEGIN
			SELECT @cmp_id = 0
			BEGIN
				DECLARE coop_percents_cursor CURSOR FOR
				SELECT CL_CODE, DIV_CODE, PRD_CODE, COOP_PCT, 0 FROM BILLING_COOP 
					WHERE BILL_COOP_CODE=@coop_code 
				FOR READ ONLY
				--
				DECLARE tmp_cursor2 CURSOR FOR
				SELECT	EL.CL_CODE, EL.DIV_CODE, EL.PRD_CODE, 
						ED.ESTIMATE_NUMBER, EA.EST_COMPONENT_NBR, ED.SEQ_NBR, ED.FNC_CODE, 
						ED.EST_CPM_FLAG, ED.EST_NONBILL_FLAG, ED.EST_REV_QUANTITY, ED.EST_REV_EXT_AMT,
						ED.EXT_MARKUP_AMT, (EXT_STATE_RESALE+EXT_COUNTY_RESALE+EXT_CITY_RESALE) AS RESALE_TAX,
						ED.LINE_TOTAL, ED.EXT_CONTINGENCY, ED.LINE_TOTAL_CONT
				FROM ESTIMATE_LOG EL
				INNER JOIN ESTIMATE_REV_DET ED ON 
						(EL.ESTIMATE_NUMBER = ED.ESTIMATE_NUMBER)
				INNER JOIN V_ESTIMATEAPPR EA ON 
						(EA.ESTIMATE_NUMBER = ED.ESTIMATE_NUMBER 
					AND EA.EST_COMPONENT_NBR = ED.EST_COMPONENT_NBR)
					WHERE (EA.JOB_NUMBER = @job_number 
					AND EA.JOB_COMPONENT_NBR = @job_component_nbr)
				FOR READ ONLY		
			END		

			OPEN tmp_cursor2

			WHILE (@ret_val = 0)  	
			BEGIN
				FETCH tmp_cursor2 INTO @cl_code, @div_code, @prd_code,
					@estimate_number, @est_component_nbr, @seq_nbr, @fnc_code, 
					@est_cmp_flag, @est_nonbill_flag, @est_rev_qty, @est_rev_ext_amt,
					@est_markup_amt, @est_resale_tax_amt, 
					@line_total, @ext_contingemcy, @line_total_cont		
				
				IF ( @@FETCH_STATUS = 0 )
				BEGIN
					SELECT @ret_code = 0
					OPEN coop_percents_cursor
					WHILE (@ret_code = 0) 
					BEGIN				
						FETCH coop_percents_cursor INTO @cl_code, @div_code, @prd_code, @coop_pct, @fold_pct
						IF ( @@FETCH_STATUS = 0 )
						BEGIN
							SELECT @ret_val = 0 --REPEAT
							SELECT @coop_pct = (@coop_pct * .01)
							BEGIN
								SELECT @est_rev_qty2 = (@est_rev_qty * @coop_pct)
								SELECT @est_rev_ext_amt2 = (@est_rev_ext_amt * @coop_pct)
								SELECT @est_markup_amt2 = (@est_markup_amt * @coop_pct)
								SELECT @est_resale_tax_amt2 = (@est_resale_tax_amt * @coop_pct)
								SELECT @line_total2 = (@line_total * @coop_pct)
								SELECT @ext_contingemcy2 = (@ext_contingemcy * @coop_pct)
								SELECT @line_total_cont2 = (@line_total_cont * @coop_pct)
							END		
							INSERT INTO AR_COOP_EST_SPLITS( CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR
								,ESTIMATE_NUMBER,EST_COMPONENT_NBR,SEQ_NBR,FNC_CODE, CMP_IDENTIFIER
								,FOLD_FLAG,FNC_CPM_FLAG,EST_NONBILL_FLAG
								,EST_REV_QUANTITY,EST_REV_EXT_AMT,TOT_MARKUP_AMT,TOT_TAX_AMT
								,LINE_TOTAL,TOT_CONT_AMT,LINE_TOTAL_CONT,CREATED_BY,CREATE_DATE )
							VALUES (@cl_code, @div_code, @prd_code, @job_number, @job_component_nbr, 
								@estimate_number, @est_component_nbr, @seq_nbr, @fnc_code, @cmp_id,
								CASE 
								WHEN @fnc_code = @fold_fnc_code
								   THEN 1
								   ELSE 0 
								END, @est_cmp_flag, @est_nonbill_flag, 
								@est_rev_qty2, @est_rev_ext_amt2, @est_markup_amt2, @est_resale_tax_amt2, 
								@line_total2, @ext_contingemcy2, @line_total_cont2, @created_by, @current_date)
							IF @@ERROR <> 0 
							BEGIN
							   SELECT @ret_val = 1
							END								
						END
						ELSE
						BEGIN
							SELECT @ret_code = 100 --STOP
							CLOSE coop_percents_cursor
						END
					END
				END	
				ELSE
				BEGIN 			
					SELECT @ret_val = 100 --STOP
				END
				
			END

			DEALLOCATE coop_percents_cursor	
			
			CLOSE tmp_cursor2
			DEALLOCATE tmp_cursor2	
		END
--END IF
	
SELECT * FROM  AR_COOP_EST_SPLITS		

GO


