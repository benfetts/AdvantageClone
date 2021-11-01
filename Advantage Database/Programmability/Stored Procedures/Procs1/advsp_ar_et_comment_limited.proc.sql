if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_ar_et_comment_limited]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_ar_et_comment_limited]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_ar_et_comment_limited]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_ar_et_comment_limited]
GO

SET ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_ar_et_comment_limited] @list_option tinyint, @list varchar(max)	
AS
BEGIN
	SET NOCOUNT ON;
	-- advsp_ar_et_comment_limited ============================================================
	-- #1 06/09/08 - added [Item ID] and [Item Seq]
	-- #2 07/15/08 - added Max(SEQ_NBR) to prevent multiple entries
	-- #3 08/05/08 - corrected fix #2 to join comments on ET_ID, ET_DTL_ID and SEQ_NBR
	-- #4 11/01/08 - removed last join "AND etd.SEQ_NBR = etdc.SEQ_NBR"
	-- #5 11/01/08 - added GROUP BY
	-- #6 12/24/08 - changed prefix from sp to advsp
	-- #7 02/05/09 - changed CAST(etdc.EMP_COMMENT AS varchar) to CAST(etdc.EMP_COMMENT AS varchar(4000))
	-- #8 07/27/11 - redim @ar_inv_list varchar(4000) to @ar_inv_list varchar(max)
	-- #9 06/13/14 - added ET_SOURCE filter (2075-99)	

	-- Creates job table, @list_option: 0=AR Invoice List, 1=Billing User List
	CREATE TABLE #ar_inv_joblist(
		JOB_NUMBER						integer null,
		JOB_COMPONENT_NBR				smallint null)

	INSERT INTO #ar_inv_joblist
	SELECT DISTINCT jobs.JOB_NUMBER, jobs.JOB_COMPONENT_NBR
	FROM fn_invoice_list_to_job_table(@list_option, @list) jobs

	--SELECT * FROM #ar_inv_joblist

	SELECT
		etd.JOB_NUMBER AS [Job Number],
		etd.JOB_COMPONENT_NBR AS [Comp Number],
		etd.FNC_CODE AS [Std Function Code],
		et.EMP_CODE AS [Item Code],
		et.EMP_DATE AS [Item Date],
		etd.ET_ID AS [Item ID],
		CAST(etdc.EMP_COMMENT AS varchar(4000)) AS [ET Comment],
		etdc.ET_SOURCE													--#9
	FROM dbo.EMP_TIME_DTL etd
	JOIN #ar_inv_joblist aij
		ON etd.JOB_NUMBER = aij.JOB_NUMBER
		AND etd.JOB_COMPONENT_NBR = aij.JOB_COMPONENT_NBR
	JOIN dbo.EMP_TIME et
		ON etd.ET_ID = et.ET_ID
	JOIN dbo.EMP_TIME_DTL_CMTS etdc
		ON etd.ET_ID = etdc.ET_ID
		AND etd.ET_DTL_ID = etdc.ET_DTL_ID
	GROUP BY etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, etd.FNC_CODE, et.EMP_CODE, et.EMP_DATE, etd.ET_ID, 
		CAST(etdc.EMP_COMMENT AS varchar(4000)), etdc.ET_SOURCE			--#9
	HAVING etdc.ET_SOURCE = 'D'											--#9
	
END
GO

--PJH 06/16/14 - Added GRANT
GRANT EXECUTE ON [advsp_ar_et_comment_limited] TO PUBLIC AS dbo
GO

--IF @@ERROR = 0
--BEGIN
--	IF NOT EXISTS( SELECT * FROM dbo.DB_UPDATE WHERE FUNCTION_NAME = 'Create_advsp_ar_et_comment_limited_090209' )
--		INSERT INTO dbo.DB_UPDATE( VERSION_ID, PATCH, DESCRIPTION, FUNCTION_NAME )
--			 SELECT COALESCE( VERSION_ID, 'v5.83.30' ), 'Create_advsp_ar_et_comment_limited.sql', 'Recreates stored procedure advsp_ar_et_comment_limited', 'Create_advsp_ar_et_comment_limited_090209'
--			   FROM dbo.ADVAN_UPDATE

--	GRANT ALL ON advsp_ar_et_comment_limited TO PUBLIC AS dbo
--END
--GO