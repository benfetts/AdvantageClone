
CREATE PROCEDURE [dbo].[advsp_job_emp_time]

AS
BEGIN
	SET NOCOUNT ON;
		
	--Main data table #job_amounts==========================================================
	CREATE TABLE #job_amounts(
		JOB_NUMBER								int NULL,
		JOB_COMPONENT_NBR						smallint NULL,
		FNC_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		EMP_DATE								smalldatetime,
		POST_PERIOD								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		LINE_TOTAL								decimal(15,2) NULL,
		LINE_TOTAL_BILLED						decimal(15,2) NULL,
		LINE_TOTAL_NONBILL						decimal(15,2) NULL,
		TOTAL_BILL								decimal(15,2) NULL,
		TOTAL_BILL_BILLED						decimal(15,2) NULL,
		TOTAL_BILL_NONBILL						decimal(15,2) NULL,
		EMP_HOURS								decimal(15,2) NULL,
		EMP_HOURS_BILLED						decimal(15,2) NULL,
		EMP_HOURS_NONBILL						decimal(15,2) NULL,
		FEE_TIME								tinyint NULL,
		AR_INV_NBR								int NULL,
		AR_POST_PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
	
	--MAIN EXTRACTION ROUTINE===================================================================
					
	--Employee Time Amounts-------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		e.EMP_DATE,
		dbo.advfn_date_to_post_period(e.EMP_DATE),
		ISNULL(a.LINE_TOTAL,0),
		CASE
			WHEN ISNULL(a.AR_INV_NBR,0)=0 THEN 0
			ELSE ISNULL(a.LINE_TOTAL,0)
		END,
		CASE a.EMP_NON_BILL_FLAG
			WHEN 1 THEN ISNULL(a.LINE_TOTAL,0)
			ELSE 0
		END,
		ISNULL(a.TOTAL_BILL,0),
		CASE
			WHEN ISNULL(a.AR_INV_NBR,0)=0 THEN 0
			ELSE ISNULL(a.TOTAL_BILL,0)
		END,
		CASE a.EMP_NON_BILL_FLAG
			WHEN 1 THEN ISNULL(a.TOTAL_BILL,0)
			ELSE 0
		END,
		ISNULL(a.EMP_HOURS,0),
		CASE
			WHEN ISNULL(a.AR_INV_NBR,0)=0 THEN 0
			ELSE ISNULL(a.EMP_HOURS,0)
		END,
		CASE a.EMP_NON_BILL_FLAG
			WHEN 1 THEN ISNULL(a.EMP_HOURS,0)
			ELSE 0
		END,
		a.FEE_TIME,	
		a.AR_INV_NBR,
		d.AR_POST_PERIOD		
	FROM dbo.EMP_TIME_DTL AS a
	JOIN dbo.EMP_TIME AS e
		ON a.ET_ID=e.ET_ID
	LEFT JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR=d.AR_INV_NBR
		AND a.AR_TYPE=d.AR_TYPE
		
	--SELECT * FROM #job_amounts
			
	--Group and summarize the data	
	SELECT
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		a.POST_PERIOD,
		SUM(a.LINE_TOTAL) AS LINE_TOTAL,
		SUM(a.LINE_TOTAL_BILLED) AS LINE_TOTAL_BILLED,
		SUM(a.LINE_TOTAL_NONBILL) AS LINE_TOTAL_NONBILL,
		SUM(a.TOTAL_BILL) AS TOTAL_BILL,
		SUM(a.TOTAL_BILL_BILLED) AS TOTAL_BILL_BILLED,
		SUM(a.TOTAL_BILL_NONBILL) AS TOTAL_BILL_NONBILL,
		SUM(a.EMP_HOURS) AS EMP_HOURS,
		SUM(a.EMP_HOURS_BILLED) AS EMP_HOURS_BILLED,
		SUM(a.EMP_HOURS_NONBILL) AS EMP_HOURS_NONBILL,
		ISNULL(a.FEE_TIME,0) AS FEE_TIME,
		a.AR_POST_PERIOD						
	FROM #job_amounts AS a
	GROUP BY a.JOB_NUMBER, a.JOB_COMPONENT_NBR, a.FNC_CODE, ISNULL(a.FEE_TIME,0), a.POST_PERIOD, a.AR_POST_PERIOD
				
END
