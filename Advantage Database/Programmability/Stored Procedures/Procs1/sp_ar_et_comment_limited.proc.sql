
CREATE PROCEDURE [dbo].[sp_ar_et_comment_limited] @list_option tinyint, @list varchar(4000)	
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

	--SELECT * FROM #ar_inv_joblist

	SELECT
		etd.JOB_NUMBER AS [Job Number],
		etd.JOB_COMPONENT_NBR AS [Comp Number],
		etd.FNC_CODE AS [Std Function Code],
		et.EMP_CODE AS [Item Code],
		et.EMP_DATE AS [Item Date],
		etd.ET_ID AS [Item ID],
		CAST(etdc.EMP_COMMENT AS varchar(4000)) AS [ET Comment]
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
	
END
