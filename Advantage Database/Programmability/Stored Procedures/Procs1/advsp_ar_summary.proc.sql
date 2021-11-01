--JR Initial script for testing, programming to refine if approved for Advantage use 10/28/16
if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'[dbo].[advsp_ar_summary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_ar_summary]
GO

CREATE PROCEDURE [dbo].[advsp_ar_summary] (@user_code varchar (100))

AS
BEGIN
	SET NOCOUNT ON;

--===================================
--MAIN DATA TABLE
--===================================
CREATE TABLE #ar_summary(
	AR_INV_NBR				int NULL,
	AR_INV_SEQ				smallint NULL,
	AR_TYPE					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COOP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COOP_PCT				decimal(10,4) NULL,
	MANUAL_FLAG				bit NULL,
	ORDER_NBR				int NULL,
	ORDER_LINE_NBR			smallint NULL,
	MEDIA_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER				int NULL,
	JOB_COMPONENT_NBR		smallint NULL,
	JOB_AB_FLAG				smallint NULL,
	AR_DESCRIPTION			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OFFICE_CODE				varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER			int NULL,
	CLIENT_PO				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	SALE_POST_PERIOD		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAX_CODE				varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	INV_TAX_FLAG			bit NULL,
	INV_BY					smallint NULL,
	BILL_COMM_NET			smallint NULL,
	AB_REC_FLAG				smallint NULL,
	MED_REC_FLAG			smallint NULL,
	HRS_QTY					decimal(18,2) NULL,
	GL_ACCT_AR				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_SALE			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_DEF_SALE		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_COS				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_DEF_COS			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_ACC_AP			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_ACC_COS			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_WIP				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_STATE			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_COUNTY			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GL_ACCT_CITY			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MARKET_CODE				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_MONTH				tinyint NULL,
	MEDIA_YEAR				smallint NULL,
	[START_DATE]			smalldatetime NULL,
	END_DATE				smalldatetime NULL,
	EMP_TIME_AMT			decimal(18,2) NULL,
	INC_ONLY_AMT			decimal(18,2) NULL,
	COMMISSION_AMT			decimal(18,2) NULL,
	REBATE_AMT				decimal(18,2) NULL,
	COST_AMT				decimal(18,2) NULL,
	NET_CHARGE_AMT			decimal(18,2) NULL,
	NON_RESALE_AMT			decimal(18,2) NULL,
	DISCOUNT_AMT			decimal(18,2) NULL,
	ADDITIONAL_AMT			decimal(18,2) NULL,
	AB_COST_AMT				decimal(18,2) NULL,
	AB_INC_AMT				decimal(18,2) NULL,
	AB_COMMISSION_AMT		decimal(18,2) NULL,
	AB_SALE_AMT				decimal(18,2) NULL,
	CITY_TAX_AMT			decimal(18,2) NULL,
	CNTY_TAX_AMT			decimal(18,2) NULL,
	STATE_TAX_AMT			decimal(18,2) NULL,
	TOTAL_BILL				decimal(18,2) NULL,
	GL_XACT					int NULL,
	GL_XACT_DEF				int NULL,
	MODIFIED_FLAG			bit NULL,
	DIFF_APPLIED			bit NULL,
	CONVERTED				bit NULL,
	STATE_TAX_PCT			decimal(9,4) NULL,
	CNTY_TAX_PCT			decimal(9,4) NULL,
	CITY_TAX_PCT			decimal(9,4) NULL,
	AB_NONRESALE_AMT		decimal(18,2) NULL,
	AVATAX_KEY				varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AVATAX_POSTED			bit NULL)
	
--=================================
--SECONDARY TABLES
--=================================
--Temp table #ar_invoices - stores table of invoices to be processed
CREATE TABLE #ar_invoices(
	[USRE_ID]			varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR			int NULL,
	AR_INV_SEQ			smallint NULL,
	AR_TYPE				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #ar_invoices
SELECT [USER_ID], AR_INV_NBR, AR_INV_SEQ, AR_TYPE
FROM dbo.AR_RPT_INVOICES AS ri
where UPPER(ri.[USER_ID]) = UPPER(@user_code)
--SELECT * FROM #ar_invoices-------------------------------------------
	
--===================================
--EXTRACTION ROUTINE
--===================================
BEGIN
	INSERT INTO #ar_summary
	SELECT ar.AR_INV_NBR,
		ar.AR_INV_SEQ,
		ar.AR_TYPE,
		ar.COOP_CODE,
		ar.COOP_PCT,
		ar.MANUAL_FLAG,
		ar.ORDER_NBR,
		ar.ORDER_LINE_NBR,
		ar.MEDIA_TYPE,
		ar.JOB_NUMBER,
		ar.JOB_COMPONENT_NBR,
		ar.JOB_AB_FLAG,
		ar.AR_DESCRIPTION,
		ar.CL_CODE,
		ar.DIV_CODE,
		ar.PRD_CODE,
		ar.OFFICE_CODE,
		ar.SC_CODE,
		ar.CMP_IDENTIFIER,
		ar.CLIENT_PO,
		ar.FNC_CODE,
		ar.FNC_TYPE,
		ar.SALE_POST_PERIOD,
		ar.TAX_CODE,
		ar.INV_TAX_FLAG,
		ar.INV_BY,
		ar.BILL_COMM_NET,
		ar.AB_REC_FLAG,
		ar.MED_REC_FLAG,
		ar.HRS_QTY,
		ar.GL_ACCT_AR,
		ar.GL_ACCT_SALE,
		ar.GL_ACCT_DEF_SALE,
		ar.GL_ACCT_COS,
		ar.GL_ACCT_DEF_COS,
		ar.GL_ACCT_ACC_AP,
		ar.GL_ACCT_ACC_COS,
		ar.GL_ACCT_WIP,
		ar.GL_ACCT_STATE,
		ar.GL_ACCT_COUNTY,
		ar.GL_ACCT_CITY,
		ar.MARKET_CODE,
		ar.MEDIA_MONTH,
		ar.MEDIA_YEAR,
		ar.[START_DATE],
		ar.END_DATE,
		IsNull(ar.EMP_TIME_AMT,0) AS EMP_TIME_AMT,
		IsNull(ar.INC_ONLY_AMT,0) AS INC_ONLY_AMT,
		IsNull(ar.COMMISSION_AMT,0) AS COMMISSION_AMT,
		IsNull(ar.REBATE_AMT,0) AS REBATE_AMT,
		IsNull(ar.COST_AMT,0) AS COST_AMT,
		IsNull(ar.NET_CHARGE_AMT,0) AS NET_CHARGE_AMT,
		IsNull(ar.NON_RESALE_AMT,0) AS NON_RESALE_AMT,
		IsNull(ar.DISCOUNT_AMT,0) AS DISCOUNT_AMT,
		IsNull(ar.ADDITIONAL_AMT,0) AS ADDITIONAL_AMT,
		IsNull(ar.AB_COST_AMT,0) AS AB_COST_AMT,
		IsNull(ar.AB_INC_AMT,0) AS AB_INC_AMT,
		IsNull(ar.AB_COMMISSION_AMT,0) AS AB_COMMISSION_AMT,
		ISNull(ar.AB_SALE_AMT,0) AS AB_SALE_AMT,
		IsNull(ar.CITY_TAX_AMT,0) AS CITY_TAX_AMT,
		IsNull(ar.CNTY_TAX_AMT,0) AS CNTY_TAX_AMT,
		IsNull(ar.STATE_TAX_AMT,0) AS STATE_TAX_AMT,
		IsNull(ar.TOTAL_BILL,0) AS TOTAL_BILL,
		ar.GL_XACT,
		ar.GL_XACT_DEF,
		ar.MODIFIED_FLAG,
		ar.DIFF_APPLIED,
		ar.CONVERTED,
		ar.STATE_TAX_PCT,
		ar.CNTY_TAX_PCT,
		ar.CITY_TAX_PCT,
		IsNull(ar.AB_NONRESALE_AMT,0) AS AB_NONRESALE_AMT,
		ar.AVATAX_KEY,
		ar.AVATAX_POSTED
	FROM #ar_invoices AS ri
	JOIN dbo.AR_SUMMARY AS ar
		ON (ri.AR_INV_NBR = ar.AR_INV_NBR AND ri.AR_INV_SEQ = ar.AR_INV_SEQ AND ri.AR_TYPE = ar.AR_TYPE	)
END

SELECT * FROM #ar_summary

END