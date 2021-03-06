CREATE PROCEDURE [dbo].[advsp_ar_table_with_seq_number] @one_time tinyint, 
	@address_flag_overide smallint, @ar_inv_list varchar(max), @std_vs_cus tinyint

-- @one_time: 0=No, 1=Yes
-- @address_flag_overide (overide value if @one_time=1, see below for possible values)
-- @ar_inv_list: concatenated string of values based on AR Invoice list	
-- @std_vs_cus: 0=Standard, 2=Custom

AS
-- advsp_ar_table_with_seq_number =======================================================
-- #01 08/20/08 - added JOB_NUMBER and JOB_COMPONENT_NBR to join between dbo.ARINV_JOB and #ar_min_job to eliminate dup jobs
-- #02 12/24/08 - changed prefix from sp to advsp
-- #03 03/16/09 - set DIV_CODE and PRD_CODE to actual values for standard (all) invoices, not ZZ
-- #04 07/27/11 - redim @ar_inv_list varchar(4000) to @ar_inv_list varchar(max)
-- $05 11/20/12 - added standard comment
BEGIN
	SET NOCOUNT ON;
	
	-- Finds the min job/component for each invoice in [dbo].[ARINV_JOB]
	CREATE TABLE #ar_min_job( 
		[AR_INV_NBR] integer NULL,
		[JOB_NUMBER] integer NULL, 
		[JOB_COMPONENT_NBR] smallint NULL,
		[CL_CODE] varchar(6))

	INSERT INTO #ar_min_job	
	SELECT
		mj.AR_INV_NBR,
		mj.JOB_NUMBER,
		MIN(mj.JOB_COMPONENT_NBR),
		jl.CL_CODE
	FROM dbo.ARINV_JOB mj
		JOIN fn_intlist_to_table(@ar_inv_list) i
			ON mj.AR_INV_NBR = i.number
		JOIN dbo.JOB_LOG jl
			ON mj.JOB_NUMBER = jl.JOB_NUMBER
	WHERE mj.JOB_NUMBER = (SELECT MIN(mj2.JOB_NUMBER) FROM dbo.ARINV_JOB mj2
		WHERE mj.AR_INV_NBR = mj2.AR_INV_NBR)
	GROUP BY mj.AR_INV_NBR, mj.JOB_NUMBER, jl.CL_CODE

	-- Temporary table to hold a list of a single job for each selected invoice(s)
	CREATE TABLE #ar_inv_joblist( 
		[AR_INV_NBR] integer NULL,
		[JOB_NUMBER] integer NULL, 
		[JOB_COMPONENT_NBR] smallint NULL,
		[CL_CODE] varchar(6),
		[ADDRESS_FLAG] tinyint NULL)

	IF @one_time = 1
		BEGIN
			INSERT INTO #ar_inv_joblist
			SELECT DISTINCT 
				arj.AR_INV_NBR, 
				COALESCE(arj.JOB_NUMBER, mj.JOB_NUMBER),
				COALESCE(arj.JOB_COMPONENT_NBR, mj.JOB_COMPONENT_NBR),
				mj.CL_CODE,
				@address_flag_overide
			FROM dbo.ARINV_JOB arj
				JOIN #ar_min_job mj
					ON arj.AR_INV_NBR = mj.AR_INV_NBR
					AND arj.JOB_NUMBER = mj.JOB_NUMBER
					AND arj.JOB_COMPONENT_NBR = mj.JOB_COMPONENT_NBR
		END
	ELSE
		BEGIN
			INSERT INTO #ar_inv_joblist
			SELECT DISTINCT 
				arj.AR_INV_NBR, 
				COALESCE(arj.JOB_NUMBER, mj.JOB_NUMBER),
				COALESCE(arj.JOB_COMPONENT_NBR, mj.JOB_COMPONENT_NBR),
				mj.CL_CODE,
				dbo.fn_client_code_to_address_flag(mj.CL_CODE)
			FROM dbo.ARINV_JOB arj
				JOIN #ar_min_job mj
					ON arj.AR_INV_NBR = mj.AR_INV_NBR
					AND arj.JOB_NUMBER = mj.JOB_NUMBER
					AND arj.JOB_COMPONENT_NBR = mj.JOB_COMPONENT_NBR
		END

	-- Routine to select CDP codes from dbo.ACCT_REC, unless from dbo.JOB_LOG if @address_flag = 4
	-- Modified JP 3/16/09 to treat draft and regular invoices the same for DIV_CODE and PRD_CODE
	SELECT DISTINCT
		ar.AR_INV_NBR,
		AR_INV_NBR_STR = CONVERT( varchar(12), ar.AR_INV_NBR ), 
		ar.AR_INV_SEQ, 
		ar.AR_TYPE,
		-- modified JP 2/11/08 to set job contact info for std vs cus
		CL_CODE = CASE 
			WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.CL_CODE
			ELSE ar.CL_CODE
		END,
		DIV_CODE = CASE 
			WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.DIV_CODE
			ELSE COALESCE(ar.DIV_CODE, 'ZZ')
		END,
		PRD_CODE = CASE 
			WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0  THEN jl.PRD_CODE
			ELSE COALESCE(ar.PRD_CODE, 'ZZ')
		END,
		PRD_CONT_CODE = CASE 
			WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN COALESCE(jc.PRD_CONT_CODE, 'ZZ')
			ELSE 'ZZ'
		END,
		CDP_CONTACT_ID = CASE 
			WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN COALESCE(jc.CDP_CONTACT_ID, 0)
			ELSE 0
		END,
		dbo.advfn_std_comment_comment('Invoices', 'Standard Footer',			--#05
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.OFFICE_CODE
				ELSE ar.OFFICE_CODE
			END, 
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.CL_CODE
				ELSE ar.CL_CODE
			END, 
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.DIV_CODE
				ELSE ar.DIV_CODE
			END, 
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.PRD_CODE
				ELSE ar.PRD_CODE
			END) AS CL_FOOTER,
		dbo.advfn_std_comment_font_size('Invoices', 'Standard Footer',			--#05
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.OFFICE_CODE
				ELSE ar.OFFICE_CODE
			END, 
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.CL_CODE
				ELSE ar.CL_CODE
			END, 
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.DIV_CODE
				ELSE ar.DIV_CODE
			END, 
			CASE 
				WHEN arj.ADDRESS_FLAG = 4 AND ar.AR_INV_SEQ = 0 THEN jl.PRD_CODE
				ELSE ar.PRD_CODE
			END) AS FONT_SIZE	
	FROM dbo.ACCT_REC ar 
	INNER JOIN #ar_inv_joblist arj 
		ON ar.AR_INV_NBR = arj.AR_INV_NBR 
	INNER JOIN dbo.JOB_COMPONENT jc 
		ON arj.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		AND arj.JOB_NUMBER = jc.JOB_NUMBER 
	INNER JOIN dbo.JOB_LOG jl 
		ON jc.JOB_NUMBER = jl.JOB_NUMBER
		
	WHERE IsNull(ar.MANUAL_INV,0) = 0
	ORDER BY ar.AR_INV_NBR, ar.AR_INV_SEQ

END
