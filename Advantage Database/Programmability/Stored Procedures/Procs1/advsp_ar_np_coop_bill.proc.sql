IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_ar_np_coop_bill]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[advsp_ar_np_coop_bill]
GO

CREATE PROCEDURE [dbo].[advsp_ar_np_coop_bill] @billing_user varchar(100), @ret_val integer OUTPUT
AS

SET ANSI_WARNINGS OFF
SET NOCOUNT ON

/*
@billing_user - current billing user assigned to job/components
@ret_val - OUTPUT - 0 (zero by default)
*/

/* @ret_val Values
*  0	Success
*  1	Failed
*/ 

SELECT @ret_val = 0

--Clear old data for this billing user only in case other user data exists
DELETE FROM dbo.AR_COOP_TMP
	WHERE BILLING_USER = @billing_user
	IF @@ERROR <> 0 
    BEGIN
       SELECT @ret_val = 1
    END	

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
END

IF ( @ret_val = 0 )
BEGIN
	--Some Vendors have NULL for FOLD_FLAG instead of 0 (Zero) 
	INSERT INTO #ar_coop_est_splits( CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER, PRINT_QUANTITY, FOLD_FLAG )
	SELECT	NH.CL_CODE, NH.DIV_CODE, NH.PRD_CODE, CP.JOB_NUMBER, CP.JOB_COMPONENT_NBR, CP.CMP_IDENTIFIER, SUM(PRINT_QUANTITY), 
			CASE 
				WHEN V.FOLD = 1
				   THEN 1
				   ELSE 0 
			END AS FOLD
		FROM JOB_LOG JL, JOB_COMPONENT JC, CAMPAIGN CP, NEWSPAPER_HEADER NH, NEWSPAPER_DETAIL ND, VENDOR V
		WHERE JL.NP_COOP_SPLIT = 1
			AND JL.JOB_NUMBER = JC.JOB_NUMBER
			AND JC.BILLING_USER = @billing_user
			AND JC.JOB_NUMBER = CP.JOB_NUMBER
			AND JC.JOB_COMPONENT_NBR = CP.JOB_COMPONENT_NBR 
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
	SELECT * FROM #ar_coop_est_splits
	--Calculate Gtotals by C/D/P and FOLD Flag and Client
	INSERT INTO #ar_coop_est_splits2 ( CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
										PRINT_QUANTITY, FOLD_QUANTITY, TOTAL_QUANTITY, TOTAL_FOLD_QUANTITY )
	SELECT DISTINCT CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
		CASE 
			WHEN (0) = 0
			   THEN (SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs2
					 WHERE cs2.CL_CODE = cs1.CL_CODE AND cs2.DIV_CODE = cs1.DIV_CODE 
						AND cs2.PRD_CODE = cs1.PRD_CODE AND cs2.CMP_IDENTIFIER = cs1.CMP_IDENTIFIER 
						AND cs2.JOB_NUMBER = cs1.JOB_NUMBER AND cs2.JOB_COMPONENT_NBR = cs1.JOB_COMPONENT_NBR)
			   ELSE 0 
		END AS PRINT_QTY,
		CASE 
			WHEN (FOLD_FLAG) = 1
			   THEN	(SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs3
					 WHERE FOLD_FLAG = 1 AND cs3.CL_CODE = cs1.CL_CODE AND cs3.DIV_CODE = cs1.DIV_CODE 
						AND cs3.PRD_CODE = cs1.PRD_CODE AND cs3.CMP_IDENTIFIER = cs1.CMP_IDENTIFIER 
						AND cs3.JOB_NUMBER = cs1.JOB_NUMBER AND cs3.JOB_COMPONENT_NBR = cs1.JOB_COMPONENT_NBR)
			   ELSE 0 
		END AS FOLD_QTY,
		(SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs4
		 WHERE cs4.CL_CODE = cs1.CL_CODE  AND cs4.JOB_NUMBER = cs1.JOB_NUMBER AND cs4.JOB_COMPONENT_NBR = cs1.JOB_COMPONENT_NBR),
		 (SELECT SUM(PRINT_QUANTITY) AS TOTAL_PRINT_QTY FROM #ar_coop_est_splits cs5
		 WHERE cs5.CL_CODE = cs1.CL_CODE AND cs5.JOB_NUMBER = cs1.JOB_NUMBER AND cs5.JOB_COMPONENT_NBR = cs1.JOB_COMPONENT_NBR
			AND FOLD_FLAG = 1) 
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

SELECT * FROM #ar_coop_est_splits2
SELECT * FROM #ar_coop_est_splits3

IF ( @ret_val = 0 )
BEGIN
	--Insert Coop PCTs
	INSERT INTO AR_COOP_TMP( COOP_ID, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
						COOP_PCT, FOLD_PCT, PRINT_QUANTITY, FOLD_QUANTITY, BILLING_USER )
	SELECT 1, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER,
		CAST(SUM(PRINT_QUANTITY/TOTAL_QUANTITY*100) AS decimal(10,3)) AS COOP_PCT, 
		CAST(SUM(FOLD_QUANTITY/TOTAL_FOLD_QUANTITY*100) AS decimal(10,3)) AS FOLD_PCT,
		SUM(PRINT_QUANTITY), SUM(FOLD_QUANTITY), @billing_user
	FROM #ar_coop_est_splits3
	GROUP BY CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_IDENTIFIER
	IF @@ERROR <> 0 
	   SELECT @ret_val = 1
END

SELECT * FROM AR_COOP_TMP


GO

GRANT EXECUTE ON [advsp_ar_np_coop_bill] TO PUBLIC AS dbo
GO
