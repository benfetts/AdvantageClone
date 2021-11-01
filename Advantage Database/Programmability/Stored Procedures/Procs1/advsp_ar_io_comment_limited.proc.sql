
CREATE PROCEDURE [dbo].[advsp_ar_io_comment_limited] @list_option tinyint, @list varchar(max)	
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

	SELECT
		io.JOB_NUMBER AS [Job Number],
		io.JOB_COMPONENT_NBR AS [Comp Number],
		io.FNC_CODE [Std Function Code],
		io.IO_INV_DATE AS [Item Date],
		io.IO_INV_NBR AS [Item Detail],
		CAST(io.IO_COMMENT AS varchar(4000)) AS [IO Comment]
	FROM dbo.INCOME_ONLY io
	JOIN #ar_inv_joblist aij
		ON io.JOB_NUMBER = aij.JOB_NUMBER
		AND io.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
	WHERE io.IO_COMMENT IS NOT NULL	AND io.SEQ_NBR = (SELECT MAX(io2.SEQ_NBR) FROM dbo.INCOME_ONLY io2
		WHERE io.IO_ID = io2.IO_ID)
	
END
