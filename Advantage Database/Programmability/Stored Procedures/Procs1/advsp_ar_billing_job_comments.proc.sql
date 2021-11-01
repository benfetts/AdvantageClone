
CREATE PROCEDURE [dbo].[advsp_ar_billing_job_comments] @ar_inv_list varchar(4000)	
AS
BEGIN
	SET NOCOUNT ON;

	-- Creates job table, @list_option: 0=AR Invoice List, 1=Billing User List
	CREATE TABLE #ar_inv_joblist(
		JOB_NUMBER						integer null,
		JOB_COMPONENT_NBR				smallint null)

	INSERT INTO #ar_inv_joblist
	SELECT DISTINCT jobs.JOB_NUMBER, jobs.JOB_COMPONENT_NBR
	FROM fn_invoice_list_to_job_table(0, @ar_inv_list) jobs

	--SELECT * FROM #ar_inv_joblist

	SELECT
		c.INV_NBR,
		c.JOB_NUMBER,
		c.JOB_COMPONENT_NBR,
		c.JOB_COMMENT
	FROM dbo.BILL_COMMENTS_JOB AS c
	JOIN #ar_inv_joblist aij
		ON c.JOB_NUMBER = aij.JOB_NUMBER
		AND c.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
	WHERE c.JOB_COMMENT IS NOT NULL	
	
END
