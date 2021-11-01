if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_ar_production_jobcomp_comments2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_ar_production_jobcomp_comments2]
GO

set ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

set QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_ar_production_jobcomp_comments2] @list_option tinyint, @user_id varchar(100)

-- @list_option: 0=regular, 1=draft

-- advsp_ar_production_jobcomp_comments =======================================================
-- #1 06/02/08 - draft WHERE AR_INV_NBR IS NULL
-- #2 07/15/08 - selected max BA_ID to prevent multiple comment lines
-- #3 09/23/08 - Billing User Invoice List, changed WHERE
-- #4 12/24/08 - Changed prefix from sp to advsp
-- #5 03/16/09 - Changed join for draft invoices to table BILL_APPR_HDR on SELECTED_BA_ID
-- #6 07/27/11 - redim @ar_inv_list varchar(4000) to @ar_inv_list varchar(max)
-- #7 01/07/14 - v660 new version

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
		--FROM fn_invoice_list_to_inv_job_table(@list_option, @list) jobs
		FROM dbo.ARINV_JOB AS jobs
		JOIN dbo.JOB_COMPONENT AS jc 
			ON jobs.JOB_NUMBER = jc.JOB_NUMBER
			AND jobs.JOB_COMPONENT_NBR =jc.JOB_COMPONENT_NBR
		JOIN dbo.RPT_SEL_NBRS AS n
			ON jobs.AR_INV_NBR = n.AR_INV_NBR
		WHERE n.USER_ID = @user_id	
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
				arf.DRAFT_INV_NBR
			FROM dbo.JOB_COMPONENT jc
			JOIN dbo.AR_FUNCTION AS arf
				ON jc.JOB_NUMBER = arf.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR =arf.JOB_COMPONENT_NBR
			WHERE arf.BILLING_USER = @user_id		
		--SELECT * FROM #draft_joblist

		SELECT
			dj.BU_INV_NBR AS AR_INV_NBR_STR, 
			bah.JOB_NUMBER,
			bah.JOB_COMPONENT_NBR,
			bah.CLIENT_COMMENTS AS CLIENT_HDR_COMMENTS
		FROM dbo.BILL_APPR_HDR bah
		JOIN #draft_joblist dj
			ON bah.JOB_NUMBER = dj.JOB_NUMBER
			AND bah.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR
			AND bah.BA_ID = dj.SELECTED_BA_ID	
		WHERE bah.CLIENT_COMMENTS IS NOT NULL
	END

END
GO
