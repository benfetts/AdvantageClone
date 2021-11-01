/****** Object:  StoredProcedure [dbo].[advsp_acct_rec_amounts]    Script Date: 03/15/2016 09:08:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_acct_rec_amounts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_acct_rec_amounts]
GO


CREATE PROCEDURE [dbo].[advsp_acct_rec_amounts](@UserID varchar(100), @PeriodCutoff varchar(6))
-- Stored procedure to extract ACCT_REC_AMOUNTS information
-- #00 12/03/12 - initial release
-- #01 12/20/12 - added columns from ACCT_REC
-- #02 01/12/13 - added SUM and GROUP BY in final SELECT similar to AR shell
-- #03 01/17/13 - modified HAVING clause - was backwards
AS
BEGIN
SET NOCOUNT ON;

-- Identify the current Advantage user
--DECLARE @user_id varchar(100)
--SELECT @user_id = dbo.78()
--SELECT @user_id 

--Clear ACCT_REC_AMOUNTS for the current user
DELETE dbo.ACCT_REC_AMOUNTS WHERE UPPER([USER_ID]) = UPPER(@UserID)

-- Get the cutoff period from table RPT_RUNTIME_SPECS and convert to string
DECLARE @end_period int
--SELECT @end_period = (SELECT TO_PERIOD FROM dbo.RPT_RUNTIME_SPECS
--	WHERE APP_TYPE = 'AR' AND [USER_ID] = @user_id)
--SELECT @end_period
DECLARE @str_cutoff AS varchar(6)
SET @str_cutoff	= @PeriodCutoff

-- ======================================================================
-- RUN EXISTING SPROC "advsp_aged_ar" AND LOAD INTO TABLE "ACCT_REC_AMOUNTS"
-- ======================================================================
	CREATE TABLE #ar_amounts(
		CUTOFF_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_INV_NBR						int NULL,
		AR_INV_SEQ						smallint NULL,
		OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_INV_DATE						smalldatetime,
		INVOICE_DUE_DATE				smalldatetime,
		CL_PAYDAYS						smallint NULL,
		PART_PMT_IND					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_DESCRIPTION					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		REC_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_INV_AMOUNT					decimal(15,2) NULL,
		CR_PAY_AMT						decimal(15,2) NULL,
		CR_ADJ_AMT						decimal(15,2) NULL,
		CR_TOT_AMT						decimal(15,2) NULL,
		CR_CHK_NBR						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CR_OA_AMT						decimal(15,2) NULL,
		BAL_AMOUNT						decimal(15,2) NULL,
		GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		INV_CAT							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
	INSERT INTO #ar_amounts EXECUTE dbo.advsp_aged_ar NULL, @str_cutoff
	--SELECT * FROM #ar_amounts

	INSERT INTO dbo.ACCT_REC_AMOUNTS(	
		[USER_ID],
		CUTOFF_PERIOD,
		AR_INV_NBR,
		AR_INV_SEQ,
		AR_TYPE,
		CL_CODE,
		DIV_CODE,
		PRD_CODE,
		OFFICE_CODE,
		AR_DESCRIPTION,
		AR_INV_AMOUNT,
		GLACODE,
		REC_TYPE,
		CR_PAY_AMT,
		CR_ADJ_AMT,
		CR_TOT_AMT,
		CR_OA_AMT)	
	SELECT
		@UserID,
		a.CUTOFF_PERIOD,
		a.AR_INV_NBR,
		a.AR_INV_SEQ,
		'IN' AS AR_TYPE,
		a.CL_CODE,
		a.DIV_CODE,
		a.PRD_CODE,
		ISNULL(a.OFFICE_CODE, p.OFFICE_CODE),
		AR_DESCRIPTION,
		SUM(ISNULL(a.AR_INV_AMOUNT,0)),
		a.GLACODE,
		a.REC_TYPE,
		SUM(ISNULL(a.CR_PAY_AMT,0)),
		SUM(ISNULL(a.CR_ADJ_AMT,0)),
		SUM(ISNULL(a.CR_TOT_AMT,0)),
		SUM(ISNULL(a.CR_OA_AMT,0))
	FROM #ar_amounts AS a
	LEFT JOIN dbo.PRODUCT AS p
		ON a.CL_CODE = p.CL_CODE
		AND a.DIV_CODE = p.DIV_CODE
		AND a.PRD_CODE = p.PRD_CODE
	GROUP BY a.CUTOFF_PERIOD, a.AR_INV_NBR, a.AR_INV_SEQ, a.CL_CODE,
		a.DIV_CODE, a.PRD_CODE, a.OFFICE_CODE, p.OFFICE_CODE, AR_DESCRIPTION,
		a.GLACODE, a.REC_TYPE
	HAVING ABS(SUM(ISNULL(a.AR_INV_AMOUNT,0) - ISNULL(a.CR_TOT_AMT,0))) >= .01
		OR	ABS(SUM(ISNULL(a.CR_OA_AMT,0))) >= .01

END

GO

