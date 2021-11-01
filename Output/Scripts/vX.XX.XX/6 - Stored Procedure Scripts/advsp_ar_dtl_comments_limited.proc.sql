IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[advsp_ar_dtl_comments_limited]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_dtl_comments_limited]
GO

SET ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_ar_dtl_comments_limited]	
	@user_id varchar(100)

AS

-- =====================================================================
-- advsp_ar_dtl_comments_limited
-- #07 03/05/13 - used AP comment version #6 1/9/12 as base, along with other comment sprocs
-- #08 03/20/13 - v650 modified SET statement for @user_id for 2005 compatability
-- #09 04/10/14 - v660 added join to AP_PRODUCTION and select comment only when MODIFY_DELETE <> 1 (735-1136)
-- =====================================================================

/* NOT USED IN .Net AT THIS POINT */

BEGIN
	SET NOCOUNT ON;
	
	-- MAIN DATA TABLE==================================================
		CREATE TABLE #dtl_comments(
		[USER_ID]					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DTL_TYPE					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
		TABLE_ID					integer NULL,
		LINE_NUMBER					smallint NULL,
		JOB_NUMBER					integer NULL,
		JOB_COMPONENT_NBR			smallint NULL,
		FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DATE]						smalldatetime,
		DETAIL						varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DTL_COMMENT					varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS)
	
	-- Identify the current Advantage user
	--DECLARE @user_id varchar(100)

	IF ISNULL(@user_id, '') > '' BEGIN
		SET @user_id = UPPER(@user_id)
	END
	ELSE BEGIN
		SET @user_id = ''
		--SELECT @user_id = UPPER(dbo.78())
	END
	
	-- Creates table of distinct job/comps, nust populate PROD_BILLING_DATA first
	CREATE TABLE #ar_inv_joblist(
		JOB_NUMBER						integer null,
		JOB_COMPONENT_NBR				smallint null)

	INSERT INTO #ar_inv_joblist
	SELECT DISTINCT jobs.JOB_NUMBER, jobs.JOB_COMPONENT_NBR
	FROM dbo.PROD_BILLING_DATA AS jobs
	WHERE jobs.[USER_ID] = @user_id
	--SELECT * FROM #ar_inv_joblist

	-- AP Comments==============================================
	-- Creates table #ap_maxseq
	CREATE TABLE #ap_maxseq(
		AP_ID						integer NULL,
		AP_SEQ						smallint NULL)

	INSERT INTO #ap_maxseq	
	SELECT
		ah.AP_ID,
		MAX(ah.AP_SEQ)
	FROM dbo.AP_HEADER ah
	GROUP BY
		ah.AP_ID

	-- Creates table #ap_header
	CREATE TABLE #ap_header(
		AP_ID						integer NULL,
		AP_SEQ						smallint NULL,
		VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AP_INV_VCHR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AP_INV_DATE					smalldatetime)

	INSERT INTO #ap_header
	SELECT
		ah.AP_ID,
		ah.AP_SEQ,
		ah.VN_FRL_EMP_CODE,
		ah.AP_INV_VCHR,
		ah.AP_INV_DATE
	FROM dbo.AP_HEADER ah
	JOIN #ap_maxseq am
		ON ah.AP_ID = am.AP_ID
	   AND ah.AP_SEQ = am.AP_SEQ    

	-- Creates table #ap_comments
	CREATE TABLE #ap_comments(
		AP_ID						integer NULL,
		LINE_NUMBER					smallint NULL,
		JOB_NUMBER					integer NULL,
		JOB_COMPONENT_NBR			smallint NULL,
		FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AP_COMMENT					varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS)

	INSERT INTO #ap_comments
	SELECT
		apc.AP_ID,
		apc.LINE_NUMBER,
		apc.JOB_NUMBER,
		apc.JOB_COMPONENT_NBR,
		apc.FNC_CODE,
		CAST(apc.AP_COMMENT AS varchar(4000))
	FROM dbo.AP_PROD_COMMENTS apc
	JOIN #ar_inv_joblist aij
		ON apc.JOB_NUMBER = aij.JOB_NUMBER
		AND apc.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
	JOIN dbo.AP_PRODUCTION ap										--#09
		ON apc.AP_ID = ap.AP_ID
		AND apc.LINE_NUMBER = ap.LINE_NUMBER	
	WHERE apc.AP_COMMENT IS NOT NULL
		AND ISNULL(ap.MODIFY_DELETE,0) <> 1							--#09
	GROUP BY apc.AP_ID,	apc.LINE_NUMBER, apc.JOB_NUMBER, apc.JOB_COMPONENT_NBR, apc.FNC_CODE, CAST(apc.AP_COMMENT AS varchar(4000))
	
	-- Insert AP comments into main data table
	INSERT INTO #dtl_comments
	SELECT
		@user_id,
		'AP',
		ac.AP_ID AS [Item ID],
		ac.LINE_NUMBER AS [Item Line Nbr],
		ac.JOB_NUMBER AS [Job Number],
		ac.JOB_COMPONENT_NBR AS [Comp Number],
		ac.FNC_CODE AS [Std Function Code],
		ah.VN_FRL_EMP_CODE AS [Item Code],
		ah.AP_INV_DATE AS [Item Date],
		ah.AP_INV_VCHR AS [Item Detail],
		ac.AP_COMMENT AS [AP Comment]
	FROM #ap_comments ac
	JOIN #ap_header ah
		ON ac.AP_ID = ah.AP_ID		
		
	-- ET Comments===================================================
	INSERT INTO #dtl_comments
	SELECT
		@user_id,
		'ET',
		etd.ET_ID,
		NULL,
		etd.JOB_NUMBER,
		etd.JOB_COMPONENT_NBR,
		etd.FNC_CODE,
		et.EMP_CODE,
		et.EMP_DATE,
		NULL,
		CAST(etdc.EMP_COMMENT AS varchar(4000))
	FROM dbo.EMP_TIME_DTL etd
	JOIN #ar_inv_joblist aij
		ON etd.JOB_NUMBER = aij.JOB_NUMBER
		AND etd.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
	JOIN dbo.EMP_TIME et
		ON etd.ET_ID = et.ET_ID
	JOIN dbo.EMP_TIME_DTL_CMTS etdc
		ON etd.ET_ID = etdc.ET_ID
		AND etd.ET_DTL_ID = etdc.ET_DTL_ID
	GROUP BY etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, etd.FNC_CODE, et.EMP_CODE, et.EMP_DATE, etd.ET_ID, 
		CAST(etdc.EMP_COMMENT AS varchar(4000))
		
	-- IO Comments===================================================
	INSERT INTO #dtl_comments
	SELECT
		@user_id,
		'IO',
		io.IO_ID,
		NULL,
		io.JOB_NUMBER,
		io.JOB_COMPONENT_NBR,
		io.FNC_CODE,
		NULL,
		io.IO_INV_DATE,
		io.IO_INV_NBR,
		CAST(io.IO_COMMENT AS varchar(4000))
	FROM dbo.INCOME_ONLY io
	JOIN #ar_inv_joblist aij
		ON io.JOB_NUMBER = aij.JOB_NUMBER
		AND io.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
	WHERE io.IO_COMMENT IS NOT NULL	AND io.SEQ_NBR = (SELECT MAX(io2.SEQ_NBR) FROM dbo.INCOME_ONLY io2
		WHERE io.IO_ID = io2.IO_ID)		
	
	SELECT * FROM #dtl_comments	
END
GO