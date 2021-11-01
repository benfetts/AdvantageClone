
CREATE PROCEDURE [dbo].[sp_ar_ap_comment_limited] @list_option tinyint, @list varchar(4000)	
AS
BEGIN
	SET NOCOUNT ON;

	-- Creates job table, @list_option: 0=AR Invoice List, 1=Billing User List
	CREATE TABLE #ar_inv_joblist(
		JOB_NUMBER						integer null,
		JOB_COMPONENT_NBR				smallint null)

	INSERT INTO #ar_inv_joblist
	SELECT DISTINCT jobs.JOB_NUMBER, jobs.JOB_COMPONENT_NBR
	FROM fn_invoice_list_to_job_table(@list_option, @list) jobs

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
	   AND ah.AP_SEQ = am.AP_SEQ            --needed to add this to join to remove multiple entries 11/8/08

-- Creates table #ap_comments
	CREATE TABLE #ap_comments(
		AP_ID						integer NULL,
		JOB_NUMBER					integer NULL,
		JOB_COMPONENT_NBR			smallint NULL,
		FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AP_COMMENT					varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS)

	INSERT INTO #ap_comments
	SELECT
		apc.AP_ID,
		apc.JOB_NUMBER,
		apc.JOB_COMPONENT_NBR,
		apc.FNC_CODE,
		CAST(apc.AP_COMMENT AS varchar(4000))
	FROM dbo.AP_PROD_COMMENTS apc
	JOIN #ar_inv_joblist aij
		ON apc.JOB_NUMBER = aij.JOB_NUMBER
		AND apc.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
	WHERE apc.AP_COMMENT IS NOT NULL
	GROUP BY apc.AP_ID,	apc.JOB_NUMBER,	apc.JOB_COMPONENT_NBR, apc.FNC_CODE, CAST(apc.AP_COMMENT AS varchar(4000))

	SELECT
		ac.AP_ID AS [Item ID],
		ac.JOB_NUMBER AS [Job Number],
		ac.JOB_COMPONENT_NBR AS [Comp Number],
		ac.FNC_CODE AS [Std Function Code],
		ah.VN_FRL_EMP_CODE AS [Item Code],
		ah.AP_INV_DATE AS [Item Date],
		ah.AP_INV_VCHR AS [Item Detail],ac.AP_COMMENT AS [AP Comment]
	FROM #ap_comments ac
	JOIN #ap_header ah
		ON ac.AP_ID = ah.AP_ID
END
