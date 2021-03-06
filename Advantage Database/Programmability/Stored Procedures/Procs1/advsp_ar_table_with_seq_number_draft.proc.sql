CREATE PROCEDURE [dbo].[advsp_ar_table_with_seq_number_draft] @one_time tinyint, 
	@address_flag_overide tinyint, @billing_user_list varchar(max), @std_vs_cus tinyint

-- @one_time: 0=No, 1=Yes
-- @address_flag_overide (overide value if @one_time=1, see below for possible values)
-- @billing_user_list: concatenated string of values based on Billing User list
-- @std_vs_cus: 0=Standard, 1=Custom

AS
-- advsp_ar_table_with_seq_number_draft =======================================================
-- #01 12/24/08 - modified CDP code selection - see notes (McNeil Wilson #153891)
-- #01 12/24/08 - Changed prefix from sp to advsp
-- #02 03/16/09 - Set DIV_CODE and PRD_CODE to actual values for standard (all) invoices, not ZZ
-- #03 07/27/11 - redim @ar_inv_list varchar(4000) to @ar_inv_list varchar(max)
-- #04 04/16/12 - changed AR_INV_NBR to BU_INV_NBR in last statement (AR_INV_NBR does not exist)
-- #05 11/20/12 - added standard comment
BEGIN
	SET NOCOUNT ON;
	-- Temporary table to hold a list of all jobs for selected draft invoice(s)
	-- Creates invoice number based on setting in [dbo].[CLIENT].[CL_INV_BY]
	CREATE TABLE #draft_alljobs(
		[BU_INV_NBR] varchar(100) NULL,
		[JOB_NUMBER] integer NULL, 
		[JOB_COMPONENT_NBR] smallint NULL,
		[CL_CODE] varchar(6),
		[CL_INV_BY] tinyint)		

	INSERT INTO #draft_alljobs
	SELECT DISTINCT 
		dbo.fn_billing_user_invoice_number(c.CL_INV_BY, jl.CL_CODE, jl.DIV_CODE, jl.PRD_CODE,
			jl.SC_CODE, jl.CMP_CODE, jc.JOB_CL_PO_NBR, jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR),
		jc.JOB_NUMBER, 
		jc.JOB_COMPONENT_NBR,
		c.CL_CODE,
		c.CL_INV_BY
	FROM dbo.JOB_COMPONENT jc
		JOIN fn_charlist_to_table2(@billing_user_list) bu
			ON jc.BILLING_USER COLLATE SQL_Latin1_General_CP1_CS_AS = bu.vstr
		JOIN dbo.JOB_LOG jl
			ON jc.JOB_NUMBER = jl.JOB_NUMBER
		JOIN dbo.CLIENT c
			ON jl.CL_CODE = c.CL_CODE
	
	--Temporary table to store the min job/component for each draft invoice
	CREATE TABLE #draft_joblist(
		[BU_INV_NBR] varchar(100) NULL,
		[JOB_NUMBER] integer NULL, 
		[JOB_COMPONENT_NBR] smallint NULL,
		[CL_CODE] varchar(6),
		[CL_INV_BY] tinyint,
		[ADDRESS_FLAG] tinyint)

	IF @one_time <> 1
		BEGIN
			INSERT INTO #draft_joblist
			SELECT
				da.BU_INV_NBR,
				da.JOB_NUMBER,
				MIN(da.JOB_COMPONENT_NBR),
				da.CL_CODE,
				da.CL_INV_BY,
				dbo.fn_client_code_to_address_flag(da.CL_CODE)
			FROM #draft_alljobs da
			WHERE da.JOB_NUMBER = (SELECT MIN(da2.JOB_NUMBER) FROM #draft_alljobs da2
				WHERE da.BU_INV_NBR = da2.BU_INV_NBR)
			GROUP BY da.BU_INV_NBR, da.JOB_NUMBER, da.CL_CODE, da.CL_INV_BY
		END
	ELSE
		BEGIN
			INSERT INTO #draft_joblist
			SELECT
				da.BU_INV_NBR,
				da.JOB_NUMBER,
				MIN(da.JOB_COMPONENT_NBR),
				da.CL_CODE,
				da.CL_INV_BY,
				@address_flag_overide
			FROM #draft_alljobs da
			WHERE da.JOB_NUMBER = (SELECT MIN(da2.JOB_NUMBER) FROM #draft_alljobs da2
				WHERE da.BU_INV_NBR = da2.BU_INV_NBR)
			GROUP BY da.BU_INV_NBR, da.JOB_NUMBER, da.CL_CODE, da.CL_INV_BY
		END

	-- Routine to select CDP codes from dbo.JOB_LOG
	-- Modified JP 3/16/09 to set DIV_CODE and PRD_CODE to actual values instead of ZZ for reg (all) invoices
	SELECT DISTINCT
		AR_INV_NBR = 0,
		AR_INV_NBR_STR = dj.BU_INV_NBR, 
		AR_INV_SEQ = 0, 
		AR_TYPE = 'IN',
		CL_CODE = jl.CL_CODE,
		DIV_CODE = jl.DIV_CODE,
		PRD_CODE = jl.PRD_CODE,
		PRD_CONT_CODE = CASE dj.ADDRESS_FLAG
			WHEN 4 THEN COALESCE(jc.PRD_CONT_CODE, 'ZZ')
			ELSE 'ZZ'
		END,
		CDP_CONTACT_ID = CASE 
			WHEN dj.ADDRESS_FLAG = 4 THEN COALESCE(jc.CDP_CONTACT_ID, 0)
			ELSE 0
		END,
		CASE dj.CL_INV_BY			--#05
			WHEN 6 THEN dbo.advfn_std_comment_comment('Invoices', 'Standard Footer', jl.OFFICE_CODE, jl.CL_CODE, NULL, NULL)
			WHEN 7 THEN dbo.advfn_std_comment_comment('Invoices', 'Standard Footer', jl.OFFICE_CODE, jl.CL_CODE, jl.DIV_CODE, NULL)
			ELSE dbo.advfn_std_comment_comment('Invoices', 'Standard Footer', jl.OFFICE_CODE, jl.CL_CODE, jl.DIV_CODE, jl.PRD_CODE)
		END AS CL_FOOTER,
		CASE dj.CL_INV_BY			--#05
			WHEN 6 THEN dbo.advfn_std_comment_font_size('Invoices', 'Standard Footer', jl.OFFICE_CODE, jl.CL_CODE, NULL, NULL)
			WHEN 7 THEN dbo.advfn_std_comment_font_size('Invoices', 'Standard Footer', jl.OFFICE_CODE, jl.CL_CODE, jl.DIV_CODE, NULL)
			ELSE dbo.advfn_std_comment_font_size('Invoices', 'Standard Footer', jl.OFFICE_CODE, jl.CL_CODE, jl.DIV_CODE, jl.PRD_CODE)
		END AS FONT_SIZE	
		--NULL AS CL_FOOTER,
		--NULL AS FONT_SIZE	
	FROM #draft_joblist dj 
		JOIN dbo.JOB_COMPONENT jc
			ON dj.JOB_NUMBER = jc.JOB_NUMBER
			AND dj.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		JOIN dbo.JOB_LOG jl 
			ON jc.JOB_NUMBER = jl.JOB_NUMBER
	ORDER BY dj.BU_INV_NBR

END
