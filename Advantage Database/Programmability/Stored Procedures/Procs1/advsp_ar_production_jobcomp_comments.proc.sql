
CREATE PROCEDURE [dbo].[advsp_ar_production_jobcomp_comments] @list_option tinyint, @list varchar(max)
AS

BEGIN
	SET NOCOUNT ON;

	--AR Invoice List
	IF @list_option = 0	
	BEGIN
		CREATE TABLE #ar_inv_joblist(
		JOB_NUMBER						integer null,
		JOB_COMPONENT_NBR				smallint null,
		AR_INV_NBR						integer)
	
		INSERT INTO #ar_inv_joblist
		SELECT DISTINCT 
			jobs.JOB_NUMBER, 
			jobs.JOB_COMPONENT_NBR, 
			jobs.AR_INV_NBR
		FROM fn_invoice_list_to_inv_job_table(@list_option, @list) jobs
		--SELECT * FROM #ar_inv_joblist

		SELECT
			CAST(bah.AR_INV_NBR as varchar) AR_INV_NBR_STR, 
			bah.JOB_NUMBER,
			bah.JOB_COMPONENT_NBR,
			bah.CLIENT_COMMENTS AS CLIENT_HDR_COMMENTS
		FROM dbo.BILL_APPR_HDR bah
		JOIN #ar_inv_joblist aij
			ON bah.JOB_NUMBER = aij.JOB_NUMBER
			AND bah.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
			AND bah.AR_INV_NBR = aij.AR_INV_NBR
		WHERE bah.CLIENT_COMMENTS IS NOT NULL
			AND bah.BA_ID = (SELECT MAX(bah2.BA_ID) FROM dbo.BILL_APPR_HDR bah2
				WHERE bah.JOB_NUMBER = bah2.JOB_NUMBER
				AND bah.JOB_COMPONENT_NBR = bah2.JOB_COMPONENT_NBR
				AND bah.AR_INV_NBR = bah2.AR_INV_NBR)
	END

	--Billing User Invoice List
	ELSE
	BEGIN
		CREATE TABLE #draft_joblist( 
			[JOB_NUMBER] integer NULL, 
			[JOB_COMPONENT_NBR] smallint NULL,
			[SELECTED_BA_ID] int NULL,					-- JP 3/16/09
			[BU_INV_NBR] varchar(100) NULL)
		INSERT INTO #draft_joblist
			SELECT DISTINCT jc.JOB_NUMBER, 
				jc.JOB_COMPONENT_NBR,
				jc.SELECTED_BA_ID,
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
			bah.JOB_NUMBER,
			bah.JOB_COMPONENT_NBR,
			bah.CLIENT_COMMENTS AS CLIENT_HDR_COMMENTS
		FROM dbo.BILL_APPR_HDR bah
		JOIN #draft_joblist dj
			ON bah.JOB_NUMBER = dj.JOB_NUMBER
			AND bah.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR
			AND bah.BA_ID = dj.SELECTED_BA_ID					-- JP 3/16/09
		WHERE bah.CLIENT_COMMENTS IS NOT NULL
	END

END
