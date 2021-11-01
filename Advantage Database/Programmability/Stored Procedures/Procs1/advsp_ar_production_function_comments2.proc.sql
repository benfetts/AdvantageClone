if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_ar_production_function_comments2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_ar_production_function_comments2]
GO

set ANSI_NULLS ON
GO

set ANSI_PADDING OFF
GO

set QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_ar_production_function_comments2] @list_option tinyint, @user_id varchar(100)	

-- @list_option: 0=regular, 1=draft

-- #00 01/08/14 - Initial, copied from v650
-- #01 11/14/15 - Select NULL AR_INV_NBR for draft invoices, otherwise duplicates exist (735-1465)

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
		FROM dbo.ARINV_JOB AS jobs
		JOIN dbo.JOB_COMPONENT AS jc 
			ON jobs.JOB_NUMBER = jc.JOB_NUMBER
			AND jobs.JOB_COMPONENT_NBR =jc.JOB_COMPONENT_NBR
		JOIN dbo.RPT_SEL_NBRS AS n
			ON jobs.AR_INV_NBR = n.AR_INV_NBR
		WHERE n.USER_ID = @user_id	
		--SELECT * FROM #ar_inv_jobl

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
			[BU_INV_NBR] varchar(100) NULL)
		INSERT INTO #draft_joblist
			SELECT DISTINCT jc.JOB_NUMBER, 
				jc.JOB_COMPONENT_NBR,
				arf.DRAFT_INV_NBR
			FROM dbo.JOB_COMPONENT jc
			JOIN dbo.AR_FUNCTION AS arf
				ON jc.JOB_NUMBER = arf.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR =arf.JOB_COMPONENT_NBR
			WHERE arf.BILLING_USER = @user_id		
		--SELECT * FROM #draft_joblist

		SELECT
			dj.BU_INV_NBR AR_INV_NBR_STR, 
			bah.JOB_NUMBER,
			bah.JOB_COMPONENT_NBR,
			bad.FNC_CODE,
			bad.CLIENT_COMMENTS AS CLIENT_FNC_COMMENTS
		FROM dbo.BILL_APPR_HDR bah
		JOIN #draft_joblist dj
			ON bah.JOB_NUMBER = dj.JOB_NUMBER
			AND bah.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR
		JOIN dbo.BILL_APPR_DTL bad
			ON bah.JOB_NUMBER = bad.JOB_NUMBER
			AND bah.JOB_COMPONENT_NBR = bad.JOB_COMPONENT_NBR
			AND bah.BA_ID = bad.BA_ID
		WHERE bah.AR_INV_NBR IS NULL								--#01
			AND bad.CLIENT_COMMENTS IS NOT NULL
			AND CAST(bad.CLIENT_COMMENTS AS varchar(1)) <> ''		--to suppress '' values
	END
END
GO
