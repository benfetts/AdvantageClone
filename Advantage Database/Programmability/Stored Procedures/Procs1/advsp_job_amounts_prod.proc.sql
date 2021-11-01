if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_amounts_prod]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_amounts_prod]
GO

CREATE PROCEDURE [dbo].[advsp_job_amounts_prod]
	@IncludeClientOOP bit = 1,
	@IncludeEmployeeTime bit = 1,
	@IncludeProduction bit = 1,
	@IncludeIncomeOnly bit = 1,
	@IncludeAdvanceBilling bit = 1,
	@IncludeEstimate bit = 1,
	@IncludeOpenPO bit = 1,
	@StartDate smalldatetime = NULL,
	@EndDate smalldatetime = NULL,
	@IsEntity bit = 0
AS
BEGIN
	SET NOCOUNT ON;
	
	--Main data table #job_detail_cost_and_billing
	CREATE TABLE #job_amounts_prod(
		REC_SOURCE								varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_NUMBER								int NULL,
		JOB_COMPONENT_NBR						smallint NULL,
		FNC_TYPE								varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FNC_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FNC_DESC								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ITEM_ID									int NULL,
		ITEM_SEQ								int NULL,
		ITEM_DATE								smalldatetime,
		POST_PERIOD								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ITEM_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ITEM_DESC								varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ITEM_COMMENT							text,
		ITEM_EXTRA1								varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ITEM_DEPT								varchar(6),
		FEE_TIME								tinyint NULL,
		HOURS_QTY								decimal(15,2) NULL,
		TOTAL_BILL								decimal(15,2) NULL,
		BILL_AMT								decimal(15,2) NULL,
		EXT_MARKUP_AMT							decimal(15,2) NULL,
		NONRESALE_TAX							decimal(15,2) NULL,
		RESALE_TAX								decimal(15,2) NULL,
		LINE_TOTAL								decimal(15,2) NULL,
		COST_AMT								decimal(15,2) NULL,
		AR_POST_PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_INV_NBR								int NULL,
		AR_TYPE									varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AB_FLAG									tinyint NULL,
		NON_BILL_FLAG							tinyint NULL,
		GLEXACT_BILL							int NULL,
		EST_HOURS_QTY							decimal(15,2) NULL,
		EST_AMT									decimal(15,2) NULL,
		EST_CONT_AMT							decimal(15,2) NULL,
		EST_NONRESALE_TAX						decimal(15,2) NULL,
		EST_RESALE_TAX							decimal(15,2) NULL,
		EST_MARKUP_AMT							decimal(15,2) NULL,
		EST_COST_AMT							decimal(15,2) NULL,
		EST_NON_BILL_FLAG						tinyint NULL,
		EST_FEE_TIME							tinyint NULL,
		APPR_HOURS_QTY							decimal(15,2) NULL,
		APPR_COST_AMT							decimal(15,2) NULL,
		APPR_EXT_NET_AMT						decimal(15,2) NULL,
		APPR_TOTAL_AMT							decimal(15,2) NULL,
		PO_NUMBER								int NULL,
		OPEN_PO_AMT								decimal(15,2) NULL,
		OPEN_PO_GROSS_AMT						decimal(15,2) NULL,
		BILLED_AMT								decimal(15,2) NULL,
		BILLED_AMT_RESALE						decimal(15,2) NULL,
		BILLED_HRS_QTY							decimal(15,2) NULL,
		FEE_TIME_AMT							decimal(15,2) NULL,
		FEE_TIME_HRS							decimal(15,2) NULL,
		UNBILLED_AMT							decimal(15,2) NULL,
		UNBILLED_AMT_RESALE						decimal(15,2) NULL,
		UNBILLED_HRS_QTY						decimal(15,2) NULL,
		NB_AMT									decimal(15,2) NULL,
		NB_QTY									decimal(15,2) NULL,
		NEW_BIZ									smallint NULL,
		AGENCY									smallint NULL,
		CL_CODE									varchar(6),
		CL_NAME									varchar(100))


if @StartDate IS NULL OR @EndDate IS NULL
	Begin
			--PRODUCTION======================================================================================
			
			--Client OOP--------------------------------------------------------------------------------------
			IF @IncludeClientOOP = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY)
				
				SELECT
					'C',
					a.JOB_NUMBER,
					a.JOB_COMPONENT_NBR,
					f.FNC_TYPE,
					a.FNC_CODE,
					f.FNC_DESCRIPTION,
					NULL,
					NULL,
					a.INV_DATE,
					NULL,
					NULL,
					a.[DESCRIPTION],
					NULL AS ITEM_COMMENT,
					0,
					0,
					0,
					0,
					0,
					0,
					ISNULL(a.AMOUNT,0),
					ISNULL(a.AMOUNT,0),
					NULL,
					NULL,
					NULL,
					0,
					NULL,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				FROM dbo.CLIENT_OOP AS a
				INNER JOIN dbo.FUNCTIONS AS f
					ON a.FNC_CODE = f.FNC_CODE

			END
			
			--Employee Time-----------------------------------------------------------------------------------
			IF @IncludeEmployeeTime = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					FEE_TIME,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY,
					ITEM_DEPT,
					CL_CODE,
					CL_NAME)
				
				SELECT
					'E',
					e.JOB_NUMBER,
					e.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					e.FNC_CODE,
					f.FNC_DESCRIPTION,
					e.ET_ID,
					e.ET_DTL_ID,
					et.EMP_DATE,
					'',
					et.EMP_CODE,
					emp.EMP_FNAME + ' ' + emp.EMP_LNAME + ' (' + et.EMP_CODE + ')',
					ISNULL(ec.EMP_COMMENT,''),
					ISNULL(e.FEE_TIME,0),
					ISNULL(e.EMP_HOURS,0),
					ISNULL(e.LINE_TOTAL,0) - ISNULL(e.EXT_STATE_RESALE,0) - ISNULL(e.EXT_COUNTY_RESALE,0) - ISNULL(e.EXT_CITY_RESALE,0),  	
					ISNULL(e.LINE_TOTAL,0), 	
					ISNULL(e.EXT_MARKUP_AMT,0),
					0,
					ISNULL(e.EXT_STATE_RESALE,0) + ISNULL(e.EXT_COUNTY_RESALE,0) + ISNULL(e.EXT_CITY_RESALE,0),
					ISNULL(e.LINE_TOTAL,0),
					ISNULL(e.TOTAL_COST,0),
					dbo.advfn_invoice_post_period(ISNULL(e.AR_INV_NBR,0),ISNULL(e.AR_TYPE,'')),
					e.AR_INV_NBR,
					e.AR_TYPE,
					e.AB_FLAG,
					ISNULL(e.EMP_NON_BILL_FLAG,0),
					e.GLEXACT_BILL,
					CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.TOTAL_BILL,0) + ISNULL(e.EXT_MARKUP_AMT,0) ELSE 0 END,
					CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.TOTAL_BILL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END,
					e.DP_TM_CODE,
					jl.CL_CODE,
					c.CL_NAME
				FROM dbo.EMP_TIME_DTL AS e
				INNER JOIN dbo.EMP_TIME AS et
					ON e.ET_ID = et.ET_ID	
				INNER JOIN dbo.FUNCTIONS AS f
					ON e.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.EMPLOYEE AS emp
					ON et.EMP_CODE = emp.EMP_CODE
				LEFT JOIN dbo.EMP_TIME_DTL_CMTS AS ec
					ON e.ET_ID = ec.ET_ID
					AND e.ET_DTL_ID = ec.ET_DTL_ID	
					AND ec.ET_SOURCE = 'D'
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = e.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE		
					
			END
					
			--Production--------------------------------------------------------------------------------------
			IF @IncludeProduction = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					ITEM_EXTRA1,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'V',
					a.JOB_NUMBER,
					a.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					a.FNC_CODE,
					f.FNC_DESCRIPTION,
					a.AP_ID,
					a.AP_SEQ,
					ah.AP_INV_DATE,
					a.POST_PERIOD,
					ah.VN_FRL_EMP_CODE,
					v.VN_NAME + ' (' + ah.VN_FRL_EMP_CODE + ')',
					NULL,	--ac.AP_COMMENT,
					ah.AP_INV_VCHR,
					ISNULL(a.AP_PROD_QUANTITY,0),
					ISNULL(a.LINE_TOTAL,0) - ISNULL(a.EXT_STATE_RESALE,0) - ISNULL(a.EXT_COUNTY_RESALE,0) - ISNULL(a.EXT_CITY_RESALE,0),	--JP 1/12/11
					ISNULL(a.LINE_TOTAL,0),
					ISNULL(a.EXT_MARKUP_AMT,0),
					ISNULL(a.EXT_NONRESALE_TAX,0),
					ISNULL(a.EXT_STATE_RESALE,0) + ISNULL(a.EXT_COUNTY_RESALE,0) + ISNULL(a.EXT_CITY_RESALE,0),
					ISNULL(a.LINE_TOTAL,0),
					a.AP_PROD_EXT_AMT,		--a.AP_PROD_EXT_AMT + a.EXT_NONRESALE_TAX, --JP 11/11/10
					dbo.advfn_invoice_post_period(ISNULL(a.AR_INV_NBR,0), ISNULL(a.AR_TYPE,'')),
					a.AR_INV_NBR,
					a.AR_TYPE,
					a.AB_FLAG,
					ISNULL(a.AP_PROD_NOBILL_FLG,0),
					a.GLEXACT_BILL,
					CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL,0) - ISNULL(a.EXT_STATE_RESALE,0) - ISNULL(a.EXT_COUNTY_RESALE,0) - ISNULL(a.EXT_CITY_RESALE,0) ELSE 0 END,
					CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.AP_PROD_QUANTITY,0) ELSE 0 END,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.AP_PRODUCTION AS a
				INNER JOIN dbo.AP_HEADER AS ah
					ON a.AP_ID = ah.AP_ID
					AND a.AP_SEQ = ah.AP_SEQ	
				INNER JOIN dbo.FUNCTIONS AS f
					ON a.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.VENDOR AS v
					ON ah.VN_FRL_EMP_CODE = v.VN_CODE
				LEFT JOIN dbo.AP_PROD_COMMENTS AS ac
					ON a.AP_ID = ac.AP_ID
					AND a.LINE_NUMBER = ac.LINE_NUMBER	
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = a.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE				

			END
				
			--Income Only--------------------------------------------------------------------------------------
			IF @IncludeIncomeOnly = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'I',
					io.JOB_NUMBER,
					io.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					io.FNC_CODE,
					f.FNC_DESCRIPTION,
					io.IO_ID,
					io.SEQ_NBR,
					io.IO_INV_DATE,
					NULL,
					NULL,
					io.IO_DESC,
					io.IO_COMMENT,
					0,
					ISNULL(io.LINE_TOTAL,0) - ISNULL(io.EXT_STATE_RESALE,0) - ISNULL(io.EXT_COUNTY_RESALE,0) - ISNULL(io.EXT_CITY_RESALE,0),		--JP 1/12/11
					ISNULL(io.LINE_TOTAL,0),
					ISNULL(io.EXT_MARKUP_AMT,0),
					0,
					ISNULL(io.EXT_STATE_RESALE,0) + ISNULL(io.EXT_COUNTY_RESALE,0) + ISNULL(io.EXT_CITY_RESALE,0),
					ISNULL(io.LINE_TOTAL,0),
					0,
					dbo.advfn_invoice_post_period(ISNULL(io.AR_INV_NBR,0), ISNULL(io.AR_TYPE,'')),
					io.AR_INV_NBR,
					io.AR_TYPE,
					io.AB_FLAG,
					ISNULL(io.NON_BILL_FLAG,0),
					io.GLEXACT_BILL,
					CASE WHEN io.AR_INV_NBR IS NOT NULL THEN ISNULL(io.LINE_TOTAL,0) - ISNULL(io.EXT_STATE_RESALE,0) - ISNULL(io.EXT_COUNTY_RESALE,0) - ISNULL(io.EXT_CITY_RESALE,0) ELSE 0 END,
					CASE WHEN io.AR_INV_NBR IS NOT NULL THEN ISNULL(io.LINE_TOTAL,0) ELSE 0 END,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.INCOME_ONLY AS io
				INNER JOIN dbo.FUNCTIONS AS f
					ON io.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = io.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE			

						
			END 
			
			--Advance Billing----------------------------------------------------------------------------------
			IF @IncludeAdvanceBilling = 1 BEGIN
				
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'A',
					ab.JOB_NUMBER,
					ab.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					ab.FNC_CODE,
					f.FNC_DESCRIPTION,
					ab.AB_ID,
					ab.SEQ_NBR,
					ab.BILL_DATE,
					NULL,
					NULL,
					'Advance Billing',
					NULL AS ITEM_COMMENT,
					0,
					0,
					ISNULL(ab.LINE_TOTAL,0),
					ISNULL(ab.EXT_MARKUP_AMT,0),
					0,
					ISNULL(ab.EXT_STATE_RESALE,0) + ISNULL(ab.EXT_COUNTY_RESALE,0) + ISNULL(ab.EXT_CITY_RESALE,0),
					ISNULL(ab.LINE_TOTAL,0),
					0,
					dbo.advfn_invoice_post_period(ISNULL(ab.AR_INV_NBR,0), ISNULL(ab.AR_TYPE,'')),
					ab.AR_INV_NBR,
					ab.AR_TYPE,
					ab.AB_FLAG,
					0,
					ab.GLEXACT,
					0,
					CASE WHEN ab.AR_INV_NBR IS NOT NULL THEN ISNULL(ab.LINE_TOTAL,0) ELSE 0 END,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.ADVANCE_BILLING AS ab
				INNER JOIN dbo.FUNCTIONS f
					ON ab.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = ab.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE	
				--WHERE ab.AR_INV_NBR IS NOT NULL	

			END 
			
			--Estimate/Quote----------------------------------------------------------------------------------
			IF @IncludeEstimate = 1 BEGIN

				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_DATE,
					ITEM_CODE,
					ITEM_DESC,
					EST_HOURS_QTY,
					EST_AMT,
					EST_CONT_AMT,
					EST_NONRESALE_TAX,
					EST_RESALE_TAX,
					EST_MARKUP_AMT,
					EST_COST_AMT,
					EST_NON_BILL_FLAG,
					EST_FEE_TIME,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY,
					ITEM_DEPT)
				
				SELECT
					'ES',
					ea.JOB_NUMBER,
					ea.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					ed.FNC_CODE,
					f.FNC_DESCRIPTION,
					ea.EST_APPR_DATE,
					NULL,
					'Estimate Amount',
					ISNULL(ed.EST_REV_QUANTITY,0),
					ISNULL(ed.LINE_TOTAL,0),
					ISNULL(ed.LINE_TOTAL_CONT,0),
					ISNULL(ed.EXT_NONRESALE_TAX,0),
					ISNULL(ed.EXT_STATE_RESALE,0) + ISNULL(ed.EXT_COUNTY_RESALE,0) + ISNULL(ed.EXT_CITY_RESALE,0),
					ISNULL(ed.EXT_MARKUP_AMT,0),
					ISNULL(ed.EST_REV_EXT_AMT,0),
					0 AS EST_NON_BILL_FLAG,
					0 AS EST_FEE_TIME,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END,
					NULL					
				FROM dbo.ESTIMATE_APPROVAL AS ea
				INNER JOIN dbo.ESTIMATE_REV_DET AS ed
					ON ea.ESTIMATE_NUMBER =ed.ESTIMATE_NUMBER
					AND ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR
					AND ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR
					AND ea.EST_REVISION_NBR = ed.EST_REV_NBR
				INNER JOIN dbo.FUNCTIONS f
					ON ed.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = ea.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE	

			--Estimate/Quote (Internal) Not Used ----------------------------------------
				--Temp table to store estimate "id's" where internal approval exists w/o client approval
				CREATE TABLE #estimate_int_appr(
					ESTIMATE_NUMBER							int NOT NULL,
					EST_COMPONENT_NBR						smallint NOT NULL,
					EST_QUOTE_NBR							smallint NOT NULL,
					EST_REVISION_NBR						smallint NOT NULL)
				INSERT INTO #estimate_int_appr
				SELECT
					ei.ESTIMATE_NUMBER,
					ei.EST_COMPONENT_NBR,
					ei.EST_QUOTE_NBR,
					ei.EST_REVISION_NBR
				FROM dbo.ESTIMATE_INT_APPR AS ei
				LEFT JOIN dbo.ESTIMATE_APPROVAL AS ea
					ON ei.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER
					AND ei.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR
					AND ei.EST_QUOTE_NBR = ea.EST_QUOTE_NBR	
					AND ei.EST_REVISION_NBR = ea.EST_REVISION_NBR
				WHERE ea.EST_APPR_BY IS NULL			

				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_DATE,
					ITEM_CODE,
					ITEM_DESC,
					EST_HOURS_QTY,
					EST_AMT,
					EST_CONT_AMT,
					EST_NONRESALE_TAX,
					EST_RESALE_TAX,
					EST_MARKUP_AMT,
					EST_COST_AMT,
					EST_NON_BILL_FLAG,
					EST_FEE_TIME,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'EI',
					ea.JOB_NUMBER,
					ea.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					ed.FNC_CODE,
					f.FNC_DESCRIPTION,
					ea.EST_APPR_DATE,
					NULL,
					'Estimate Amount',
					ISNULL(ed.EST_REV_QUANTITY,0),
					ISNULL(ed.LINE_TOTAL,0),
					ISNULL(ed.LINE_TOTAL_CONT,0),
					ISNULL(ed.EXT_NONRESALE_TAX,0),
					ISNULL(ed.EXT_STATE_RESALE,0) + ISNULL(ed.EXT_COUNTY_RESALE,0) + ISNULL(ed.EXT_CITY_RESALE,0),
					ISNULL(ed.EXT_MARKUP_AMT,0),
					ISNULL(ed.EST_REV_EXT_AMT,0),
					0 AS EST_NON_BILL_FLAG,
					0 AS EST_FEE_TIME,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.ESTIMATE_INT_APPR AS ea
				INNER JOIN #estimate_int_appr AS ei
					ON ea.ESTIMATE_NUMBER = ei.ESTIMATE_NUMBER
					AND ea.EST_COMPONENT_NBR = ei.EST_COMPONENT_NBR
					AND ea.EST_QUOTE_NBR = ei.EST_QUOTE_NBR
					AND ea.EST_REVISION_NBR = ei.EST_REVISION_NBR	
				INNER JOIN dbo.ESTIMATE_REV_DET AS ed
					ON ea.ESTIMATE_NUMBER = ed.ESTIMATE_NUMBER
					AND ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR
					AND ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR
					AND ea.EST_REVISION_NBR = ed.EST_REV_NBR
				INNER JOIN dbo.FUNCTIONS f
					ON ed.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = ea.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE	

			END

			--Open POs----------------------------------------------------------------------------------
			IF @IncludeOpenPO = 1 BEGIN
				--Temp table to store AP amounts
				CREATE TABLE #ap_amounts(
					PO_NUMBER								int NULL,
					PO_LINE_NUMBER							int NULL,
					PO_COMPLETE								smallint NULL,
					AP_NET_AMT								decimal(15,2),
					AP_GROSS_AMT							decimal(15,2))
				INSERT INTO #ap_amounts(PO_NUMBER, PO_LINE_NUMBER, PO_COMPLETE, AP_NET_AMT, AP_GROSS_AMT)
				SELECT
					ap.PO_NUMBER,
					ap.PO_LINE_NUMBER,
					MAX(ISNULL(ap.PO_COMPLETE,0)),
					SUM(ap.AP_PROD_EXT_AMT),
					SUM(ap.AP_PROD_EXT_AMT) + SUM(ap.EXT_MARKUP_AMT)
				FROM dbo.AP_PRODUCTION ap
				WHERE ISNULL(ap.PO_NUMBER,0) <> 0 AND ISNULL(ap.DELETE_FLAG,0) = 0 
				GROUP BY ap.PO_NUMBER, ap.PO_LINE_NUMBER 
				HAVING SUM(ap.AP_PROD_EXT_AMT) <> 0

				--SELECT * FROM #ap_amounts

				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					ITEM_DATE,
					--ITEM_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					PO_NUMBER,
					OPEN_PO_AMT,
					OPEN_PO_GROSS_AMT,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY)
					
				SELECT
					'PO',
					pd.JOB_NUMBER,
					pd.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					pd.FNC_CODE,
					p.PO_DATE,
					--NULL,
					p.VN_CODE,
					p.VN_CODE,
					p.PO_NUMBER,
					ISNULL(pd.PO_EXT_AMOUNT,0) - ISNULL(ap.AP_NET_AMT,0),
					ISNULL(pd.PO_EXT_AMOUNT,0) + ISNULL(pd.EXT_MARKUP_AMT,0) - ISNULL(ap.AP_GROSS_AMT,0),
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				FROM dbo.PURCHASE_ORDER p
				INNER JOIN dbo.PURCHASE_ORDER_DET pd
					ON p.PO_NUMBER = pd.PO_NUMBER
				LEFT JOIN #ap_amounts ap
					ON pd.PO_NUMBER = ap.PO_NUMBER
					AND pd.LINE_NUMBER = ap.PO_LINE_NUMBER
				INNER JOIN dbo.FUNCTIONS f
					ON pd.FNC_CODE = f.FNC_CODE
				--WHERE ISNULL(p.VOID_FLAG,0) = 0 AND (pd.PO_COMPLETE <> 1 OR pd.PO_COMPLETE IS NULL)	
				--	AND ISNULL(pd.PO_EXT_AMOUNT,0) - ISNULL(ap.AP_NET_AMT,0) > 0
				WHERE ISNULL(p.VOID_FLAG,0) = 0 AND ISNULL(pd.PO_COMPLETE,0) <> 1 	
					AND ISNULL(pd.PO_EXT_AMOUNT,0) - ISNULL(ap.AP_NET_AMT,0) > 0
					AND ISNULL(ap.PO_COMPLETE,0) <> 1				--JP 11/11/10

			END
			
			
			if @IsEntity = 1
			BEGIN
				SELECT
					[JobAmountType] = REC_SOURCE,
					[JobNumber] = JOB_NUMBER,
					[JobComponentNumber] = JOB_COMPONENT_NBR,
					[FunctionType] = FNC_TYPE,
					[FunctionCode] = FNC_CODE,
					[FunctionDescription] = FNC_DESC,
					[JobAmountID] = ITEM_ID,
					[JobAmountSequenceNumber] = ITEM_SEQ,
					[JobAmountDate] = ITEM_DATE,
					[PostPeriodCode] = POST_PERIOD,
					[JobAmountCode] = ITEM_CODE,
					[JobAmountDescription] = ITEM_DESC,
					[JobAmountComment] = ITEM_COMMENT,
					[JobAmountExtra] = ITEM_EXTRA1,
					[JobAmountDepartment] = ITEM_DEPT,
					[FeeTime] = FEE_TIME,
					[Hours] = HOURS_QTY,
					[TotalBillAmount] = TOTAL_BILL,
					[BillAmount] = BILL_AMT,
					[ExtMarkupAmount] = EXT_MARKUP_AMT,
					[NonResaleTaxAmount] = NONRESALE_TAX,
					[ResaleTaxAmount] = RESALE_TAX,
					[JobAmountTotal] = LINE_TOTAL,
					[CostAmount] = COST_AMT,
					[AccountsRecievablePostPeriodCode] = AR_POST_PERIOD,
					[AccountsRecievableInvoiceNumber] = AR_INV_NBR,
					[AccountsRecievableType] = AR_TYPE,
					[IsAdvanceBilling] = AB_FLAG,
					[IsNonBillable] = NON_BILL_FLAG,
					[GlexActBill] = GLEXACT_BILL,
					[EstimateHours] = EST_HOURS_QTY,
					[EstimateTotalAmount] = EST_AMT,
					[EstimateContTotalAmount] = EST_CONT_AMT,
					[EstimateNonResaleTaxAmount] = EST_NONRESALE_TAX,
					[EstimateResaleTaxAmount] = EST_RESALE_TAX,
					[EstimateMarkupAmount] = EST_MARKUP_AMT,
					[EstimateCostAmount] = EST_COST_AMT,
					[IsEstimateNonBillable] = EST_NON_BILL_FLAG,
					[EstimateFeeTime] = EST_FEE_TIME,
					[ApproximateHours] = APPR_HOURS_QTY,
					[ApproximateCostAmount] = APPR_COST_AMT,
					[ApproximateExtNetAmount] = APPR_EXT_NET_AMT,
					[ApproximateTotalAmount] = APPR_TOTAL_AMT,
					[PurchaseOrderNumber] = PO_NUMBER,
					[OpenPurchaseOrderAmount] = OPEN_PO_AMT,
					[OpenPurchaseOrderGrossAmount] = OPEN_PO_GROSS_AMT,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY
				FROM #job_amounts_prod
			END
			ELSE
			BEGIN
				SELECT REC_SOURCE,		
					JOB_NUMBER,			
					JOB_COMPONENT_NBR,	
					FNC_TYPE,			
					FNC_CODE,			
					FNC_DESC,			
					ITEM_ID,				
					ITEM_SEQ,			
					ITEM_DATE,			
					POST_PERIOD,			
					ITEM_CODE,			
					ITEM_DESC,			
					ITEM_COMMENT,		
					ITEM_EXTRA1,			
					ITEM_DEPT,			
					FEE_TIME,			
					HOURS_QTY,			
					TOTAL_BILL,			
					BILL_AMT,			
					EXT_MARKUP_AMT,		
					NONRESALE_TAX,		
					RESALE_TAX,			
					LINE_TOTAL,			
					COST_AMT,			
					AR_POST_PERIOD,		
					AR_INV_NBR,			
					AR_TYPE,				
					AB_FLAG,				
					NON_BILL_FLAG,		
					GLEXACT_BILL,		
					EST_HOURS_QTY,		
					EST_AMT,				
					EST_CONT_AMT,		
					EST_NONRESALE_TAX,	
					EST_RESALE_TAX,		
					EST_MARKUP_AMT,		
					EST_COST_AMT,		
					EST_NON_BILL_FLAG,	
					EST_FEE_TIME,		
					APPR_HOURS_QTY,		
					APPR_COST_AMT,		
					APPR_EXT_NET_AMT,	
					APPR_TOTAL_AMT,		
					PO_NUMBER,			
					OPEN_PO_AMT,			
					OPEN_PO_GROSS_AMT,	
					BILLED_AMT,			
					BILLED_AMT_RESALE,	
					BILLED_HRS_QTY,		
					FEE_TIME_AMT,		
					FEE_TIME_HRS,		
					UNBILLED_AMT,		
					UNBILLED_AMT_RESALE,	
					UNBILLED_HRS_QTY,	
					NB_AMT,				
					NB_QTY,				
					NEW_BIZ,				
					AGENCY FROM #job_amounts_prod
			END
			 --WHERE REC_SOURCE = 'V' AND JOB_NUMBER = 181
			
		
	End
Else
	Begin
			--PRODUCTION======================================================================================
			
			--Client OOP--------------------------------------------------------------------------------------
			IF @IncludeClientOOP = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY)
				
				SELECT
					'C',
					a.JOB_NUMBER,
					a.JOB_COMPONENT_NBR,
					f.FNC_TYPE,
					a.FNC_CODE,
					f.FNC_DESCRIPTION,
					NULL,
					NULL,
					a.INV_DATE,
					NULL,
					NULL,
					a.[DESCRIPTION],
					NULL AS ITEM_COMMENT,
					0,
					0,
					0,
					0,
					0,
					0,
					ISNULL(a.AMOUNT,0),
					ISNULL(a.AMOUNT,0),
					NULL,
					NULL,
					NULL,
					0,
					NULL,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				FROM dbo.CLIENT_OOP AS a
				INNER JOIN dbo.FUNCTIONS AS f
					ON a.FNC_CODE = f.FNC_CODE
				WHERE (a.INV_DATE >= @StartDate AND a.INV_DATE <= @EndDate)

			END
			
			--Employee Time-----------------------------------------------------------------------------------
			IF @IncludeEmployeeTime = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					FEE_TIME,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY,
					ITEM_DEPT,
					CL_CODE,
					CL_NAME)
				
				SELECT
					'E',
					e.JOB_NUMBER,
					e.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					e.FNC_CODE,
					f.FNC_DESCRIPTION,
					e.ET_ID,
					e.ET_DTL_ID,
					et.EMP_DATE,
					NULL,
					et.EMP_CODE,
					emp.EMP_FNAME + ' ' + emp.EMP_LNAME + ' (' + et.EMP_CODE + ')',
					ec.EMP_COMMENT,
					ISNULL(e.FEE_TIME,0),
					ISNULL(e.EMP_HOURS,0),
					ISNULL(e.LINE_TOTAL,0) - ISNULL(e.EXT_STATE_RESALE,0) - ISNULL(e.EXT_COUNTY_RESALE,0) - ISNULL(e.EXT_CITY_RESALE,0),  	
					ISNULL(e.LINE_TOTAL,0),		
					ISNULL(e.EXT_MARKUP_AMT,0),
					0,
					ISNULL(e.EXT_STATE_RESALE,0) + ISNULL(e.EXT_COUNTY_RESALE,0) + ISNULL(e.EXT_CITY_RESALE,0),
					ISNULL(e.LINE_TOTAL,0),
					ISNULL(e.TOTAL_COST,0),
					dbo.advfn_invoice_post_period(ISNULL(e.AR_INV_NBR,0),ISNULL(e.AR_TYPE,'')),
					e.AR_INV_NBR,
					e.AR_TYPE,
					e.AB_FLAG,
					ISNULL(e.EMP_NON_BILL_FLAG,0),
					e.GLEXACT_BILL,
					CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.TOTAL_BILL,0) ELSE 0 END,
					CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.TOTAL_BILL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.EMP_HOURS,0) ELSE 0 END,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END,
					e.DP_TM_CODE,
					jl.CL_CODE,
					c.CL_NAME
				FROM dbo.EMP_TIME_DTL AS e
				INNER JOIN dbo.EMP_TIME AS et
					ON e.ET_ID = et.ET_ID	
				INNER JOIN dbo.FUNCTIONS AS f
					ON e.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.EMPLOYEE AS emp
					ON et.EMP_CODE = emp.EMP_CODE
				LEFT JOIN dbo.EMP_TIME_DTL_CMTS AS ec
					ON e.ET_ID = ec.ET_ID
					AND e.ET_DTL_ID = ec.ET_DTL_ID	
					AND ec.ET_SOURCE = 'D'
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = e.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE
				WHERE (et.EMP_DATE >= @StartDate AND et.EMP_DATE <= @EndDate)		
					
			END
					
			--Production--------------------------------------------------------------------------------------
			IF @IncludeProduction = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					ITEM_EXTRA1,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'V',
					a.JOB_NUMBER,
					a.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					a.FNC_CODE,
					f.FNC_DESCRIPTION,
					a.AP_ID,
					a.AP_SEQ,
					ah.AP_INV_DATE,
					a.POST_PERIOD,
					ah.VN_FRL_EMP_CODE,
					v.VN_NAME + ' (' + ah.VN_FRL_EMP_CODE + ')',
					NULL,	--ac.AP_COMMENT,
					ah.AP_INV_VCHR,
					ISNULL(a.AP_PROD_QUANTITY,0),
					ISNULL(a.LINE_TOTAL,0) - ISNULL(a.EXT_STATE_RESALE,0) - ISNULL(a.EXT_COUNTY_RESALE,0) - ISNULL(a.EXT_CITY_RESALE,0),	--JP 1/12/11
					ISNULL(a.LINE_TOTAL,0),
					ISNULL(a.EXT_MARKUP_AMT,0),
					ISNULL(a.EXT_NONRESALE_TAX,0),
					ISNULL(a.EXT_STATE_RESALE,0) + ISNULL(a.EXT_COUNTY_RESALE,0) + ISNULL(a.EXT_CITY_RESALE,0),
					ISNULL(a.LINE_TOTAL,0),
					a.AP_PROD_EXT_AMT,		--a.AP_PROD_EXT_AMT + a.EXT_NONRESALE_TAX, --JP 11/11/10
					dbo.advfn_invoice_post_period(ISNULL(a.AR_INV_NBR,0), ISNULL(a.AR_TYPE,'')),
					a.AR_INV_NBR,
					a.AR_TYPE,
					a.AB_FLAG,
					ISNULL(a.AP_PROD_NOBILL_FLG,0),
					a.GLEXACT_BILL,
					CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL,0) - ISNULL(a.EXT_STATE_RESALE,0) - ISNULL(a.EXT_COUNTY_RESALE,0) - ISNULL(a.EXT_CITY_RESALE,0) ELSE 0 END,
					CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL,0) ELSE 0 END,
					CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.AP_PROD_QUANTITY,0) ELSE 0 END,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.AP_PRODUCTION AS a
				INNER JOIN dbo.AP_HEADER AS ah
					ON a.AP_ID = ah.AP_ID
					AND a.AP_SEQ = ah.AP_SEQ	
				INNER JOIN dbo.FUNCTIONS AS f
					ON a.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.VENDOR AS v
					ON ah.VN_FRL_EMP_CODE = v.VN_CODE
				LEFT JOIN dbo.AP_PROD_COMMENTS AS ac
					ON a.AP_ID = ac.AP_ID
					AND a.LINE_NUMBER = ac.LINE_NUMBER	
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = a.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE
				WHERE (ah.AP_INV_DATE >= @StartDate AND ah.AP_INV_DATE <= @EndDate)				

			END
				
			--Income Only--------------------------------------------------------------------------------------
			IF @IncludeIncomeOnly = 1 BEGIN
			
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'I',
					io.JOB_NUMBER,
					io.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					io.FNC_CODE,
					f.FNC_DESCRIPTION,
					io.IO_ID,
					io.SEQ_NBR,
					io.IO_INV_DATE,
					NULL,
					NULL,
					io.IO_DESC,
					io.IO_COMMENT,
					0,
					ISNULL(io.LINE_TOTAL,0) - ISNULL(io.EXT_STATE_RESALE,0) - ISNULL(io.EXT_COUNTY_RESALE,0) - ISNULL(io.EXT_CITY_RESALE,0),		--JP 1/12/11
					ISNULL(io.LINE_TOTAL,0),
					ISNULL(io.EXT_MARKUP_AMT,0),
					0,
					ISNULL(io.EXT_STATE_RESALE,0) + ISNULL(io.EXT_COUNTY_RESALE,0) + ISNULL(io.EXT_CITY_RESALE,0),
					ISNULL(io.LINE_TOTAL,0),
					0,
					dbo.advfn_invoice_post_period(ISNULL(io.AR_INV_NBR,0), ISNULL(io.AR_TYPE,'')),
					io.AR_INV_NBR,
					io.AR_TYPE,
					io.AB_FLAG,
					ISNULL(io.NON_BILL_FLAG,0),
					io.GLEXACT_BILL,
					CASE WHEN io.AR_INV_NBR IS NOT NULL THEN ISNULL(io.LINE_TOTAL,0) - ISNULL(io.EXT_STATE_RESALE,0) - ISNULL(io.EXT_COUNTY_RESALE,0) - ISNULL(io.EXT_CITY_RESALE,0) ELSE 0 END,
					CASE WHEN io.AR_INV_NBR IS NOT NULL THEN ISNULL(io.LINE_TOTAL,0) ELSE 0 END,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.INCOME_ONLY AS io
				INNER JOIN dbo.FUNCTIONS AS f
					ON io.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = io.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE
				WHERE (io.IO_INV_DATE >= @StartDate AND io.IO_INV_DATE <= @EndDate)				

						
			END 
			
			--Advance Billing----------------------------------------------------------------------------------
			IF @IncludeAdvanceBilling = 1 BEGIN
				
				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_ID,
					ITEM_SEQ,
					ITEM_DATE,
					POST_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					ITEM_COMMENT,
					HOURS_QTY,
					TOTAL_BILL,
					BILL_AMT,
					EXT_MARKUP_AMT,
					NONRESALE_TAX,
					RESALE_TAX,
					LINE_TOTAL,
					COST_AMT,
					AR_POST_PERIOD,
					AR_INV_NBR,
					AR_TYPE,
					AB_FLAG,
					NON_BILL_FLAG,
					GLEXACT_BILL,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'A',
					ab.JOB_NUMBER,
					ab.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					ab.FNC_CODE,
					f.FNC_DESCRIPTION,
					ab.AB_ID,
					ab.SEQ_NBR,
					ab.BILL_DATE,
					NULL,
					NULL,
					'Advance Billing',
					NULL AS ITEM_COMMENT,
					0,
					0,
					ISNULL(ab.LINE_TOTAL,0),
					ISNULL(ab.EXT_MARKUP_AMT,0),
					0,
					ISNULL(ab.EXT_STATE_RESALE,0) + ISNULL(ab.EXT_COUNTY_RESALE,0) + ISNULL(ab.EXT_CITY_RESALE,0),
					ISNULL(ab.LINE_TOTAL,0),
					0,
					dbo.advfn_invoice_post_period(ISNULL(ab.AR_INV_NBR,0), ISNULL(ab.AR_TYPE,'')),
					ab.AR_INV_NBR,
					ab.AR_TYPE,
					ab.AB_FLAG,
					0,
					ab.GLEXACT,
					0,
					CASE WHEN ab.AR_INV_NBR IS NOT NULL THEN ISNULL(ab.LINE_TOTAL,0) ELSE 0 END,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.ADVANCE_BILLING AS ab
				INNER JOIN dbo.FUNCTIONS f
					ON ab.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = ab.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE
				WHERE (ab.BILL_DATE >= @StartDate AND ab.BILL_DATE <= @EndDate)		
				--WHERE ab.AR_INV_NBR IS NOT NULL	

			END 
			
			--Estimate/Quote----------------------------------------------------------------------------------
			IF @IncludeEstimate = 1 BEGIN

				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_DATE,
					ITEM_CODE,
					ITEM_DESC,
					EST_HOURS_QTY,
					EST_AMT,
					EST_CONT_AMT,
					EST_NONRESALE_TAX,
					EST_RESALE_TAX,
					EST_MARKUP_AMT,
					EST_COST_AMT,
					EST_NON_BILL_FLAG,
					EST_FEE_TIME,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'ES',
					ea.JOB_NUMBER,
					ea.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					ed.FNC_CODE,
					f.FNC_DESCRIPTION,
					ea.EST_APPR_DATE,
					NULL,
					'Estimate Amount',
					ISNULL(ed.EST_REV_QUANTITY,0),
					ISNULL(ed.LINE_TOTAL,0),
					ISNULL(ed.LINE_TOTAL_CONT,0),
					ISNULL(ed.EXT_NONRESALE_TAX,0),
					ISNULL(ed.EXT_STATE_RESALE,0) + ISNULL(ed.EXT_COUNTY_RESALE,0) + ISNULL(ed.EXT_CITY_RESALE,0),
					ISNULL(ed.EXT_MARKUP_AMT,0),
					ISNULL(ed.EST_REV_EXT_AMT,0),
					0 AS EST_NON_BILL_FLAG,
					0 AS EST_FEE_TIME,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
					
				FROM dbo.ESTIMATE_APPROVAL AS ea
				INNER JOIN dbo.ESTIMATE_REV_DET AS ed
					ON ea.ESTIMATE_NUMBER =ed.ESTIMATE_NUMBER
					AND ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR
					AND ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR
					AND ea.EST_REVISION_NBR = ed.EST_REV_NBR
				INNER JOIN dbo.FUNCTIONS f
					ON ed.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = ea.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE
				WHERE (ea.EST_APPR_DATE >= @StartDate AND ea.EST_APPR_DATE <= @EndDate)		

			--Estimate/Quote (Internal) Not Used ----------------------------------------
				--Temp table to store estimate "id's" where internal approval exists w/o client approval
				CREATE TABLE #estimate_int_appr2(
					ESTIMATE_NUMBER							int NOT NULL,
					EST_COMPONENT_NBR						smallint NOT NULL,
					EST_QUOTE_NBR							smallint NOT NULL,
					EST_REVISION_NBR						smallint NOT NULL)
				INSERT INTO #estimate_int_appr2
				SELECT
					ei.ESTIMATE_NUMBER,
					ei.EST_COMPONENT_NBR,
					ei.EST_QUOTE_NBR,
					ei.EST_REVISION_NBR
				FROM dbo.ESTIMATE_INT_APPR AS ei
				LEFT JOIN dbo.ESTIMATE_APPROVAL AS ea
					ON ei.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER
					AND ei.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR
					AND ei.EST_QUOTE_NBR = ea.EST_QUOTE_NBR	
					AND ei.EST_REVISION_NBR = ea.EST_REVISION_NBR
				WHERE ea.EST_APPR_BY IS NULL			

				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					FNC_DESC,
					ITEM_DATE,
					ITEM_CODE,
					ITEM_DESC,
					EST_HOURS_QTY,
					EST_AMT,
					EST_CONT_AMT,
					EST_NONRESALE_TAX,
					EST_RESALE_TAX,
					EST_MARKUP_AMT,
					EST_COST_AMT,
					EST_NON_BILL_FLAG,
					EST_FEE_TIME,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY,
					NEW_BIZ,
					AGENCY)
				
				SELECT
					'EI',
					ea.JOB_NUMBER,
					ea.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					ed.FNC_CODE,
					f.FNC_DESCRIPTION,
					ea.EST_APPR_DATE,
					NULL,
					'Estimate Amount',
					ISNULL(ed.EST_REV_QUANTITY,0),
					ISNULL(ed.LINE_TOTAL,0),
					ISNULL(ed.LINE_TOTAL_CONT,0),
					ISNULL(ed.EXT_NONRESALE_TAX,0),
					ISNULL(ed.EXT_STATE_RESALE,0) + ISNULL(ed.EXT_COUNTY_RESALE,0) + ISNULL(ed.EXT_CITY_RESALE,0),
					ISNULL(ed.EXT_MARKUP_AMT,0),
					ISNULL(ed.EST_REV_EXT_AMT,0),
					0 AS EST_NON_BILL_FLAG,
					0 AS EST_FEE_TIME,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					c.NEW_BUSINESS,
					CASE WHEN c.CL_CODE IN (SELECT CL_CODE FROM AGENCY_CLIENTS) THEN 1 ELSE 0 END
				FROM dbo.ESTIMATE_INT_APPR AS ea
				INNER JOIN #estimate_int_appr2 AS ei
					ON ea.ESTIMATE_NUMBER = ei.ESTIMATE_NUMBER
					AND ea.EST_COMPONENT_NBR = ei.EST_COMPONENT_NBR
					AND ea.EST_QUOTE_NBR = ei.EST_QUOTE_NBR
					AND ea.EST_REVISION_NBR = ei.EST_REVISION_NBR	
				INNER JOIN dbo.ESTIMATE_REV_DET AS ed
					ON ea.ESTIMATE_NUMBER = ed.ESTIMATE_NUMBER
					AND ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR
					AND ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR
					AND ea.EST_REVISION_NBR = ed.EST_REV_NBR
				INNER JOIN dbo.FUNCTIONS f
					ON ed.FNC_CODE = f.FNC_CODE
				INNER JOIN dbo.JOB_LOG AS jl
					ON jl.JOB_NUMBER = ea.JOB_NUMBER
				INNER JOIN dbo.CLIENT AS c
					ON c.CL_CODE = jl.CL_CODE
				WHERE (ea.EST_APPR_DATE >= @StartDate AND ea.EST_APPR_DATE <= @EndDate)	

			END

			--Open POs----------------------------------------------------------------------------------
			IF @IncludeOpenPO = 1 BEGIN
				--Temp table to store AP amounts
				CREATE TABLE #ap_amounts2(
					PO_NUMBER								int NULL,
					PO_LINE_NUMBER							int NULL,
					PO_COMPLETE								smallint NULL,
					AP_NET_AMT								decimal(15,2),
					AP_GROSS_AMT							decimal(15,2))
				INSERT INTO #ap_amounts2(PO_NUMBER, PO_LINE_NUMBER, PO_COMPLETE, AP_NET_AMT, AP_GROSS_AMT)
				SELECT
					ap.PO_NUMBER,
					ap.PO_LINE_NUMBER,
					MAX(ISNULL(ap.PO_COMPLETE,0)),
					SUM(ap.AP_PROD_EXT_AMT),
					SUM(ap.AP_PROD_EXT_AMT) + SUM(ap.EXT_MARKUP_AMT)
				FROM dbo.AP_PRODUCTION ap
				WHERE ISNULL(ap.PO_NUMBER,0) <> 0 AND ISNULL(ap.DELETE_FLAG,0) = 0 
				GROUP BY ap.PO_NUMBER, ap.PO_LINE_NUMBER 
				HAVING SUM(ap.AP_PROD_EXT_AMT) <> 0

				--SELECT * FROM #ap_amounts

				INSERT INTO #job_amounts_prod(
					REC_SOURCE,
					JOB_NUMBER,
					JOB_COMPONENT_NBR,
					FNC_TYPE,
					FNC_CODE,
					ITEM_DATE,
					--ITEM_PERIOD,
					ITEM_CODE,
					ITEM_DESC,
					PO_NUMBER,
					OPEN_PO_AMT,
					OPEN_PO_GROSS_AMT,
					BILLED_AMT,
					BILLED_AMT_RESALE,
					BILLED_HRS_QTY,
					FEE_TIME_AMT,
					FEE_TIME_HRS,
					UNBILLED_AMT,
					UNBILLED_AMT_RESALE,
					UNBILLED_HRS_QTY,
					NB_AMT,
					NB_QTY)
					
				SELECT
					'PO',
					pd.JOB_NUMBER,
					pd.JOB_COMPONENT_NBR,
					f.FNC_TYPE,	
					pd.FNC_CODE,
					p.PO_DATE,
					--NULL,
					p.VN_CODE,
					p.VN_CODE,
					p.PO_NUMBER,
					ISNULL(pd.PO_EXT_AMOUNT,0) - ISNULL(ap.AP_NET_AMT,0),
					ISNULL(pd.PO_EXT_AMOUNT,0) + ISNULL(pd.EXT_MARKUP_AMT,0) - ISNULL(ap.AP_GROSS_AMT,0),
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				FROM dbo.PURCHASE_ORDER p
				INNER JOIN dbo.PURCHASE_ORDER_DET pd
					ON p.PO_NUMBER = pd.PO_NUMBER
				LEFT JOIN #ap_amounts2 ap
					ON pd.PO_NUMBER = ap.PO_NUMBER
					AND pd.LINE_NUMBER = ap.PO_LINE_NUMBER
				INNER JOIN dbo.FUNCTIONS f
					ON pd.FNC_CODE = f.FNC_CODE
				--WHERE ISNULL(p.VOID_FLAG,0) = 0 AND (pd.PO_COMPLETE <> 1 OR pd.PO_COMPLETE IS NULL)	
				--	AND ISNULL(pd.PO_EXT_AMOUNT,0) - ISNULL(ap.AP_NET_AMT,0) > 0
				WHERE ISNULL(p.VOID_FLAG,0) = 0 AND ISNULL(pd.PO_COMPLETE,0) <> 1 	
					AND ISNULL(pd.PO_EXT_AMOUNT,0) - ISNULL(ap.AP_NET_AMT,0) > 0
					AND ISNULL(ap.PO_COMPLETE,0) <> 1				--JP 11/11/10
					AND (p.PO_DATE >= @StartDate AND p.PO_DATE <= @EndDate)	

			END
			
			

			if @IsEntity = 1
			BEGIN
				SELECT
				[JobAmountType] = REC_SOURCE,
				[JobNumber] = JOB_NUMBER,
				[JobComponentNumber] = JOB_COMPONENT_NBR,
				[FunctionType] = FNC_TYPE,
				[FunctionCode] = FNC_CODE,
				[FunctionDescription] = FNC_DESC,
				[JobAmountID] = ITEM_ID,
				[JobAmountSequenceNumber] = ITEM_SEQ,
				[JobAmountDate] = ITEM_DATE,
				[PostPeriodCode] = POST_PERIOD,
				[JobAmountCode] = ITEM_CODE,
				[JobAmountDescription] = ITEM_DESC,
				[JobAmountComment] = ITEM_COMMENT,
				[JobAmountExtra] = ITEM_EXTRA1,
				[JobAmountDepartment] = ITEM_DEPT,
				[FeeTime] = FEE_TIME,
				[Hours] = HOURS_QTY,
				[TotalBillAmount] = TOTAL_BILL,
				[BillAmount] = BILL_AMT,
				[ExtMarkupAmount] = EXT_MARKUP_AMT,
				[NonResaleTaxAmount] = NONRESALE_TAX,
				[ResaleTaxAmount] = RESALE_TAX,
				[JobAmountTotal] = LINE_TOTAL,
				[CostAmount] = COST_AMT,
				[AccountsRecievablePostPeriodCode] = AR_POST_PERIOD,
				[AccountsRecievableInvoiceNumber] = AR_INV_NBR,
				[AccountsRecievableType] = AR_TYPE,
				[IsAdvanceBilling] = AB_FLAG,
				[IsNonBillable] = NON_BILL_FLAG,
				[GlexActBill] = GLEXACT_BILL,
				[EstimateHours] = EST_HOURS_QTY,
				[EstimateTotalAmount] = EST_AMT,
				[EstimateContTotalAmount] = EST_CONT_AMT,
				[EstimateNonResaleTaxAmount] = EST_NONRESALE_TAX,
				[EstimateResaleTaxAmount] = EST_RESALE_TAX,
				[EstimateMarkupAmount] = EST_MARKUP_AMT,
				[EstimateCostAmount] = EST_COST_AMT,
				[IsEstimateNonBillable] = EST_NON_BILL_FLAG,
				[EstimateFeeTime] = EST_FEE_TIME,
				[ApproximateHours] = APPR_HOURS_QTY,
				[ApproximateCostAmount] = APPR_COST_AMT,
				[ApproximateExtNetAmount] = APPR_EXT_NET_AMT,
				[ApproximateTotalAmount] = APPR_TOTAL_AMT,
				[PurchaseOrderNumber] = PO_NUMBER,
				[OpenPurchaseOrderAmount] = OPEN_PO_AMT,
				[OpenPurchaseOrderGrossAmount] = OPEN_PO_GROSS_AMT,
				BILLED_AMT,
				BILLED_AMT_RESALE,
				BILLED_HRS_QTY,
				FEE_TIME_AMT,
				FEE_TIME_HRS,
				UNBILLED_AMT,
				UNBILLED_AMT_RESALE,
				UNBILLED_HRS_QTY,
				NB_AMT,
				NB_QTY,
				NEW_BIZ,
				AGENCY,				
				[ClientCode] = CL_CODE,
				[ClientName] = CL_NAME
			FROM #job_amounts_prod
			END
			ELSE
			BEGIN
				SELECT REC_SOURCE,		
					JOB_NUMBER,			
					JOB_COMPONENT_NBR,	
					FNC_TYPE,			
					FNC_CODE,			
					FNC_DESC,			
					ITEM_ID,				
					ITEM_SEQ,			
					ITEM_DATE,			
					POST_PERIOD,			
					ITEM_CODE,			
					ITEM_DESC,			
					ITEM_COMMENT,		
					ITEM_EXTRA1,			
					ITEM_DEPT,			
					FEE_TIME,			
					HOURS_QTY,			
					TOTAL_BILL,			
					BILL_AMT,			
					EXT_MARKUP_AMT,		
					NONRESALE_TAX,		
					RESALE_TAX,			
					LINE_TOTAL,			
					COST_AMT,			
					AR_POST_PERIOD,		
					AR_INV_NBR,			
					AR_TYPE,				
					AB_FLAG,				
					NON_BILL_FLAG,		
					GLEXACT_BILL,		
					EST_HOURS_QTY,		
					EST_AMT,				
					EST_CONT_AMT,		
					EST_NONRESALE_TAX,	
					EST_RESALE_TAX,		
					EST_MARKUP_AMT,		
					EST_COST_AMT,		
					EST_NON_BILL_FLAG,	
					EST_FEE_TIME,		
					APPR_HOURS_QTY,		
					APPR_COST_AMT,		
					APPR_EXT_NET_AMT,	
					APPR_TOTAL_AMT,		
					PO_NUMBER,			
					OPEN_PO_AMT,			
					OPEN_PO_GROSS_AMT,	
					BILLED_AMT,			
					BILLED_AMT_RESALE,	
					BILLED_HRS_QTY,		
					FEE_TIME_AMT,		
					FEE_TIME_HRS,		
					UNBILLED_AMT,		
					UNBILLED_AMT_RESALE,	
					UNBILLED_HRS_QTY,	
					NB_AMT,				
					NB_QTY,				
					NEW_BIZ,				
					AGENCY FROM #job_amounts_prod
			END
			--SELECT * FROM #job_amounts_prod WHERE REC_SOURCE = 'V' AND JOB_NUMBER = 181
	End
END
