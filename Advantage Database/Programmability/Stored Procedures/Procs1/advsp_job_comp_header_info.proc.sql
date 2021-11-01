
CREATE PROCEDURE [dbo].[advsp_job_comp_header_info]
(
	@StartDate varchar(12) = NULL,
	@EndDate varchar(12) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;
	
	--Main data table #job_comp_header_info
	CREATE TABLE #job_comp_header_info(
		OFFICE_CODE								varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OFFICE_NAME								varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CL_CODE									varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CL_NAME									varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIV_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIV_NAME								varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PRD_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PRD_DESCRIPTION							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CMP_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CMP_IDENTIFIER							int NULL,
		CMP_NAME								varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CMP_BEG_DATE							smalldatetime,
		CMP_END_DATE							smalldatetime,
		CMP_BILL_BUDGET							decimal(18,2) NULL,
		CMP_INC_BUDGET							decimal(18,2) NULL,
		SC_CODE									varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		SC_DESCRIPTION							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_NUMBER								int NOT NULL,
		JOB_DESC								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_COMMENTS							text,
		JOB_BILL_COMMENT						varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CLI_REF								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV1_CODE							varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV1_DESC							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV2_CODE							varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV2_DESC							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV3_CODE							varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV3_DESC							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV4_CODE							varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV4_DESC							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV5_CODE							varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_UDV5_DESC							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_COMPONENT_NBR						smallint NULL,
		JOB_COMP_DESC								varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_COMP_DATE							smalldatetime,
		JOB_FIRST_USE_DATE						smalldatetime,
		JOB_COMP_COMMENTS						text,
		APPR_NOTES								text,
		EMP_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_LNAME								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_FNAME								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_MI									varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CL_PO_NBR							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DP_TM_CODE								varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DP_TM_DESC								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JT_CODE									varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JT_DESC									varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		BUDGET_AMT								decimal(18,2) NULL,
		APPR_REQ_TYPE							varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		APPR_TOTAL								decimal(18,2) NULL,
		JOB_CMP_UDV1_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV1_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV2_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV2_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV3_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV3_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV4_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV4_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV5_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_CMP_UDV5_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_PROCESS_CONTRL						smallint NULL,
		COMPLETED_DATE							smalldatetime)
		
		
	--MAIN DATA EXTRACTION QUERY======================================================================
	if @StartDate IS NULL OR @EndDate IS NULL
		Begin
			INSERT INTO #job_comp_header_info
			SELECT
				j.OFFICE_CODE,
				o.OFFICE_NAME,
				j.CL_CODE,
				c.CL_NAME,
				j.DIV_CODE,
				d.DIV_NAME,
				j.PRD_CODE,
				p.PRD_DESCRIPTION,
				j.CMP_CODE,
				j.CMP_IDENTIFIER,
				cmp.CMP_NAME,
				cmp.CMP_BEG_DATE,
				cmp.CMP_END_DATE,
				cmp.CMP_BILL_BUDGET,
				cmp.CMP_INC_BUDGET,
				j.SC_CODE,
				sc.SC_DESCRIPTION,
				j.JOB_NUMBER,
				j.JOB_DESC,
				j.JOB_COMMENTS,
				j.JOB_BILL_COMMENT,
				j.JOB_CLI_REF,
				j.UDV1_CODE,
				ju1.UDV_DESC,
				j.UDV2_CODE,
				ju2.UDV_DESC,
				j.UDV3_CODE,
				ju3.UDV_DESC,
				j.UDV4_CODE,
				ju4.UDV_DESC,
				j.UDV5_CODE,
				ju5.UDV_DESC,
				jc.JOB_COMPONENT_NBR,
				jc.JOB_COMP_DESC,
				jc.JOB_COMP_DATE,
				jc.JOB_FIRST_USE_DATE,
				jc.JOB_COMP_COMMENTS,
				ea.APPR_NOTES,
				jc.EMP_CODE,
				e.EMP_LNAME,
				e.EMP_FNAME,
				e.EMP_MI,
				jc.JOB_CL_PO_NBR,
				jc.DP_TM_CODE,
				dp.DP_TM_DESC,
				jc.JT_CODE,
				jt.JT_DESC,
				0 AS BUDGET_AMT,
				NULL AS APPR_REQ_TYPE,
				0 AS APPR_TOTAL,
				jc.UDV1_CODE,
				jcu1.UDV_DESC,
				jc.UDV2_CODE,
				jcu2.UDV_DESC,
				jc.UDV3_CODE,
				jcu3.UDV_DESC,
				jc.UDV4_CODE,
				jcu4.UDV_DESC,
				jc.UDV5_CODE,
				jcu5.UDV_DESC,
				jc.JOB_PROCESS_CONTRL,
				jtr.COMPLETED_DATE
			FROM dbo.JOB_LOG AS j
			JOIN dbo.OFFICE AS o
				ON j.OFFICE_CODE = o.OFFICE_CODE
			JOIN dbo.CLIENT AS c
				ON j.CL_CODE = c.CL_CODE
			JOIN dbo.DIVISION AS d
				ON j.CL_CODE = d.CL_CODE
				AND j.DIV_CODE = d.DIV_CODE
			JOIN dbo.PRODUCT AS p
				ON j.CL_CODE = p.CL_CODE
				AND j.DIV_CODE = p.DIV_CODE
				AND j.PRD_CODE = p.PRD_CODE
			LEFT JOIN dbo.CAMPAIGN AS cmp
				ON j.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			JOIN dbo.SALES_CLASS AS sc
				ON j.SC_CODE = sc.SC_CODE
			LEFT JOIN dbo.JOB_LOG_UDV1 AS ju1
				ON j.UDV1_CODE = ju1.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV2 AS ju2
				ON j.UDV2_CODE = ju2.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV3 AS ju3
				ON j.UDV3_CODE = ju3.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV4 AS ju4
				ON j.UDV4_CODE = ju4.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV4 AS ju5
				ON j.UDV5_CODE = ju5.UDV_CODE
			JOIN dbo.JOB_COMPONENT AS jc
				ON j.JOB_NUMBER = jc.JOB_NUMBER
			LEFT JOIN dbo.JOB_TRAFFIC AS jtr
				ON jc.JOB_NUMBER = jtr.JOB_NUMBER 
				AND jc.JOB_COMPONENT_NBR = jtr.JOB_COMPONENT_NBR
			LEFT JOIN dbo.ESTIMATE_APPROVAL AS ea
				ON jc.JOB_NUMBER = ea.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR = ea.JOB_COMPONENT_NBR
			JOIN dbo.EMPLOYEE AS e
				ON jc.EMP_CODE = e.EMP_CODE
			LEFT JOIN dbo.DEPT_TEAM AS dp
				ON jc.DP_TM_CODE = dp.DP_TM_CODE
			LEFT JOIN dbo.JOB_TYPE AS jt
				ON jc.JT_CODE = jt.JT_CODE
			LEFT JOIN dbo.JOB_CMP_UDV1 AS jcu1
				ON jc.UDV1_CODE = jcu1.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV2 AS jcu2
				ON jc.UDV2_CODE = jcu2.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV3 AS jcu3
				ON jc.UDV3_CODE = jcu3.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV4 AS jcu4
				ON jc.UDV4_CODE = jcu4.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV5 AS jcu5
				ON jc.UDV5_CODE = jcu5.UDV_CODE
			SELECT * FROM #job_comp_header_info	
			--SELECT * FROM #job_comp_header_info WHERE JOB_NUMBER = 37
		End
	Else
		Begin
			INSERT INTO #job_comp_header_info
			SELECT
				j.OFFICE_CODE,
				o.OFFICE_NAME,
				j.CL_CODE,
				c.CL_NAME,
				j.DIV_CODE,
				d.DIV_NAME,
				j.PRD_CODE,
				p.PRD_DESCRIPTION,
				j.CMP_CODE,
				j.CMP_IDENTIFIER,
				cmp.CMP_NAME,
				cmp.CMP_BEG_DATE,
				cmp.CMP_END_DATE,
				cmp.CMP_BILL_BUDGET,
				cmp.CMP_INC_BUDGET,
				j.SC_CODE,
				sc.SC_DESCRIPTION,
				j.JOB_NUMBER,
				j.JOB_DESC,
				j.JOB_COMMENTS,
				j.JOB_BILL_COMMENT,
				j.JOB_CLI_REF,
				j.UDV1_CODE,
				ju1.UDV_DESC,
				j.UDV2_CODE,
				ju2.UDV_DESC,
				j.UDV3_CODE,
				ju3.UDV_DESC,
				j.UDV4_CODE,
				ju4.UDV_DESC,
				j.UDV5_CODE,
				ju5.UDV_DESC,
				jc.JOB_COMPONENT_NBR,
				jc.JOB_COMP_DESC,
				jc.JOB_COMP_DATE,
				jc.JOB_FIRST_USE_DATE,
				jc.JOB_COMP_COMMENTS,
				ea.APPR_NOTES,
				jc.EMP_CODE,
				e.EMP_LNAME,
				e.EMP_FNAME,
				e.EMP_MI,
				jc.JOB_CL_PO_NBR,
				jc.DP_TM_CODE,
				dp.DP_TM_DESC,
				jc.JT_CODE,
				jt.JT_DESC,
				0 AS BUDGET_AMT,
				NULL AS APPR_REQ_TYPE,
				0 AS APPR_TOTAL,
				jc.UDV1_CODE,
				jcu1.UDV_DESC,
				jc.UDV2_CODE,
				jcu2.UDV_DESC,
				jc.UDV3_CODE,
				jcu3.UDV_DESC,
				jc.UDV4_CODE,
				jcu4.UDV_DESC,
				jc.UDV5_CODE,
				jcu5.UDV_DESC,
				jc.JOB_PROCESS_CONTRL,
				jtr.COMPLETED_DATE
			FROM dbo.JOB_LOG AS j
			JOIN dbo.OFFICE AS o
				ON j.OFFICE_CODE = o.OFFICE_CODE
			JOIN dbo.CLIENT AS c
				ON j.CL_CODE = c.CL_CODE
			JOIN dbo.DIVISION AS d
				ON j.CL_CODE = d.CL_CODE
				AND j.DIV_CODE = d.DIV_CODE
			JOIN dbo.PRODUCT AS p
				ON j.CL_CODE = p.CL_CODE
				AND j.DIV_CODE = p.DIV_CODE
				AND j.PRD_CODE = p.PRD_CODE
			LEFT JOIN dbo.CAMPAIGN AS cmp
				ON j.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			JOIN dbo.SALES_CLASS AS sc
				ON j.SC_CODE = sc.SC_CODE
			LEFT JOIN dbo.JOB_LOG_UDV1 AS ju1
				ON j.UDV1_CODE = ju1.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV2 AS ju2
				ON j.UDV2_CODE = ju2.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV3 AS ju3
				ON j.UDV3_CODE = ju3.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV4 AS ju4
				ON j.UDV4_CODE = ju4.UDV_CODE
			LEFT JOIN dbo.JOB_LOG_UDV4 AS ju5
				ON j.UDV5_CODE = ju5.UDV_CODE
			JOIN dbo.JOB_COMPONENT AS jc
				ON j.JOB_NUMBER = jc.JOB_NUMBER
			LEFT JOIN dbo.JOB_TRAFFIC AS jtr
				ON jc.JOB_NUMBER = jtr.JOB_NUMBER 
				AND jc.JOB_COMPONENT_NBR = jtr.JOB_COMPONENT_NBR
			LEFT JOIN dbo.ESTIMATE_APPROVAL AS ea
				ON jc.JOB_NUMBER = ea.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR = ea.JOB_COMPONENT_NBR
			JOIN dbo.EMPLOYEE AS e
				ON jc.EMP_CODE = e.EMP_CODE
			LEFT JOIN dbo.DEPT_TEAM AS dp
				ON jc.DP_TM_CODE = dp.DP_TM_CODE
			LEFT JOIN dbo.JOB_TYPE AS jt
				ON jc.JT_CODE = jt.JT_CODE
			LEFT JOIN dbo.JOB_CMP_UDV1 AS jcu1
				ON jc.UDV1_CODE = jcu1.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV2 AS jcu2
				ON jc.UDV2_CODE = jcu2.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV3 AS jcu3
				ON jc.UDV3_CODE = jcu3.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV4 AS jcu4
				ON jc.UDV4_CODE = jcu4.UDV_CODE
			LEFT JOIN dbo.JOB_CMP_UDV5 AS jcu5
				ON jc.UDV5_CODE = jcu5.UDV_CODE			 													
			WHERE (jc.JOB_COMP_DATE >= @StartDate AND jc.JOB_COMP_DATE <= @EndDate) OR
				  (jc.JOB_FIRST_USE_DATE >= @StartDate AND jc.JOB_FIRST_USE_DATE <= @EndDate) OR
				  (jtr.COMPLETED_DATE >= @StartDate AND jtr.COMPLETED_DATE <= @EndDate) OR
				  ((NOT (jc.JOB_PROCESS_CONTRL IN (6, 12))) AND (jtr.COMPLETED_DATE IS NULL))
			SELECT * FROM #job_comp_header_info	
			--SELECT * FROM #job_comp_header_info WHERE JOB_NUMBER = 37
		End

END
