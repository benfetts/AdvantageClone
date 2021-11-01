CREATE PROCEDURE [dbo].[advsp_ar_job_header_comments] 
(
	@list_option tinyint, @list varchar(max)
)
AS
-- advsp_ar_job_header_comments ========================================================
-- #01 04/29/08 - added MARKET_CODE and MARKET_DESC for combo reports
-- #02 12/05/08 - removed join on JOB_COMPONENT_NBR (#ar_inv_joblist) - see below (#152903)
-- #03 12/22/08 - reinstated join on JOB_COMPONENT_NBR (Ellen discovered problem on 12/19/08)
-- #04 12/24/08 - removed join above and split into job and job_comp header comments (#152903)
-- #04 12/24/08 - changed prefix from sp to advsp
-- #05 02/09/11 - added option for standard footer comment
-- #06 03/11/11 - added FONT_SIZE
-- #07 07/27/11 - redim @ar_inv_list varchar(4000) to @ar_inv_list varchar(max)
-- #08 11/13/12 - reworked standard comments to include office and CDP
-- #09 11/20/12 - removed standard comments and added them to "AR Table with Seq"
BEGIN
	SET NOCOUNT ON;

-- Parameters
-- Creates job table, @list_option: 0=AR Invoice List, 1=Billing User List
-- @list CSV of invoice numbers
	
--	TEMP TABLES===========================================================	
	CREATE TABLE #ar_inv_joblist(JOB_NUMBER	int null)
	INSERT INTO #ar_inv_joblist
	SELECT DISTINCT jobs.JOB_NUMBER
	FROM fn_invoice_list_to_job_table(@list_option, @list) jobs
	--SELECT * FROM #ar_inv_joblist

	--Create a job/component comments table
	SELECT 
		jl.JOB_NUMBER,
		jl.CL_CODE,
		jl.DIV_CODE,
		jl.PRD_CODE,
		jl.CMP_CODE,
		jl.CMP_IDENTIFIER,
		jl.SC_CODE,
		jl.JOB_DESC, 
		jl.JOB_COMMENTS,
		jl.JOB_CLI_REF,
		jl.COMPLEX_CODE,
		jl.PROMO_CODE,
		jl.JOB_BILL_COMMENT,
		sc.SC_DESCRIPTION,
		ISNULL(p.PRD_CONSOL_FUNC,0) AS PRD_CONSOL_FUNC,
		NULL AS CL_FOOTER,		--#09
		NULL AS FONT_SIZE		--#09
	FROM dbo.JOB_LOG AS jl
	JOIN #ar_inv_joblist aij
		ON jl.JOB_NUMBER = aij.JOB_NUMBER
	JOIN dbo.SALES_CLASS sc
		ON jl.SC_CODE = sc.SC_CODE
	JOIN dbo.PRODUCT p
		ON jl.CL_CODE = p.CL_CODE
		AND jl.DIV_CODE = p.DIV_CODE
		AND jl.PRD_CODE = p.PRD_CODE
	JOIN dbo.CLIENT AS c
		ON jl.CL_CODE = c.CL_CODE

END
