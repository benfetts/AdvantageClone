
CREATE PROCEDURE [dbo].[advsp_billing_user_client_invoices] @list varchar(4000)
AS
BEGIN
	SET NOCOUNT ON;
	
	CREATE TABLE #bu_job_list (
		CL_INV_BY tinyint, 
		CL_CODE varchar(6), 
		DIV_CODE varchar(6), 
		PRD_CODE varchar(6),
		SC_CODE varchar(6), 
		CMP_CODE varchar(6), 
		JOB_CL_PO_NBR varchar(40), 
		JOB_NUMBER int, 
		JOB_COMPONENT_NBR smallint)

	INSERT INTO #bu_job_list
	SELECT
		cl.CL_INV_BY,
		jl.CL_CODE,
		jl.DIV_CODE,
		jl.PRD_CODE,
		jl.SC_CODE,
		jl.CMP_CODE,
		jc.JOB_CL_PO_NBR,
		jc.JOB_NUMBER,
		jc.JOB_COMPONENT_NBR
	FROM fn_charlist_to_table2(@list) bu
	JOIN dbo.JOB_COMPONENT jc
		ON bu.vstr = jc.BILLING_USER
	JOIN dbo.JOB_LOG jl
		ON jc.JOB_NUMBER = jl.JOB_NUMBER
	JOIN dbo.CLIENT cl
		ON jl.CL_CODE = cl.CL_CODE

--SELECT * FROM #bu_job_list

	SELECT 
		CL_CODE,
		dbo.fn_billing_user_invoice_number(CL_INV_BY, CL_CODE, DIV_CODE, PRD_CODE,
			SC_CODE, CMP_CODE, JOB_CL_PO_NBR, JOB_NUMBER, JOB_COMPONENT_NBR) AR_INV_NBR
	FROM #bu_job_list
		

END
