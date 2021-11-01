
CREATE PROCEDURE [dbo].[advsp_ar_production_function_comments] @list_option tinyint, @list varchar(max)	
AS
BEGIN
	SET NOCOUNT ON;

	IF @list_option = 0
	BEGIN
		CREATE TABLE #ar_inv_joblist(
			JOB_NUMBER						integer null,
			JOB_COMPONENT_NBR				smallint null,
			AR_INV_NBR						int)

		INSERT INTO #ar_inv_joblist
		SELECT DISTINCT 
			jobs.JOB_NUMBER, 
			jobs.JOB_COMPONENT_NBR,
			jobs.AR_INV_NBR
		FROM fn_invoice_list_to_inv_job_table(@list_option, @list) jobs

		SELECT
			CAST(bah.AR_INV_NBR AS varchar) AR_INV_NBR_STR, 
			bah.JOB_NUMBER,
			bah.JOB_COMPONENT_NBR,
			bad.FNC_CODE,
			bad.CLIENT_COMMENTS AS CLIENT_FNC_COMMENTS
		FROM dbo.BILL_APPR_HDR bah
		JOIN #ar_inv_joblist aij
			ON bah.JOB_NUMBER = aij.JOB_NUMBER
			AND bah.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
			AND bah.AR_INV_NBR = aij.AR_INV_NBR		
		JOIN dbo.BILL_APPR_DTL bad
			ON bah.JOB_NUMBER = bad.JOB_NUMBER
			AND bah.JOB_COMPONENT_NBR = bad.JOB_COMPONENT_NBR
			AND bah.BA_ID = bad.BA_ID
		WHERE bad.CLIENT_COMMENTS IS NOT NULL
			AND CAST(bad.CLIENT_COMMENTS AS varchar(1)) <> ''		--to suppress '' values
	END
	--Billing User Invoice List
	ELSE
	BEGIN
		CREATE TABLE #draft_joblist( 
			[JOB_NUMBER] integer NULL, 
			[JOB_COMPONENT_NBR] smallint NULL,
			[SELECTED_BA_ID] int NULL,							-- JP 4/27/09
			[BU_INV_NBR] varchar(100) NULL)
		INSERT INTO #draft_joblist
			SELECT DISTINCT jc.JOB_NUMBER, 
				jc.JOB_COMPONENT_NBR,
				jc.SELECTED_BA_ID,								-- JP 4/27/09
				dbo.fn_billing_user_invoice_number(c.CL_INV_BY, jl.CL_CODE, jl.DIV_CODE, jl.PRD_CODE,
					jl.SC_CODE, jl.CMP_CODE, jc.JOB_CL_PO_NBR, jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR)
			FROM dbo.JOB_COMPONENT jc
			JOIN fn_charlist_to_table2(@list) bu
				ON jc.BILLING_USER COLLATE SQL_Latin1_General_CP1_CS_AS = bu.vstr
			JOIN dbo.JOB_LOG jl
				ON jc.JOB_NUMBER = jl.JOB_NUMBER
			JOIN dbo.CLIENT c
				ON jl.CL_CODE = c.CL_CODE
		--SELECT * FROM #draft_joblist

		SELECT
			dj.BU_INV_NBR AR_INV_NBR_STR, 
			dj.JOB_NUMBER,
			dj.JOB_COMPONENT_NBR,
			bad.FNC_CODE,
			bad.CLIENT_COMMENTS AS CLIENT_FNC_COMMENTS
		FROM #draft_joblist dj
		JOIN dbo.BILL_APPR_DTL bad
			ON dj.JOB_NUMBER = bad.JOB_NUMBER
			AND dj.JOB_COMPONENT_NBR = bad.JOB_COMPONENT_NBR
			AND dj.SELECTED_BA_ID = bad.BA_ID						-- JP 4/27/09
		WHERE bad.CLIENT_COMMENTS IS NOT NULL
			AND CAST(bad.CLIENT_COMMENTS AS varchar(1)) <> ''		--to suppress '' values
	END
END
