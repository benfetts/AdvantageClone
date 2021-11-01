CREATE PROCEDURE [dbo].[advsp_job_detail_adv_bill_hist]
AS
BEGIN
	SET NOCOUNT ON;
	
	--Temp data table #job_status_det_adv_hist
	CREATE TABLE #job_status_det_adv_hist(
		JOB_NUMBER								int NULL,
		JOB_COMPONENT_NBR						smallint NULL,
		AR_INV_NBR								int NULL,
		AR_TYPE									varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		LINE_TOTAL								decimal(15,2) NULL,
		BILLED									decimal(15,2) NULL,
		InterimRec								tinyint NULL,
		InterimFlg								varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ADV_TYPE								tinyint NULL,
		BILL_TYPE								varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		BillTypeDesc							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		BillTypeSort							tinyint NULL,
		DatePaid								datetime)
		
	INSERT INTO	#job_status_det_adv_hist
	SELECT
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.AR_INV_NBR,
		a.AR_TYPE,
		a.LINE_TOTAL,
		CASE
			WHEN a.AR_INV_NBR IS NOT NULL OR a.AB_FLAG = 3 THEN a.LINE_TOTAL
			ELSE 0
		END,
		CASE a.AB_FLAG
			WHEN 6 THEN 1
			ELSE 0
		END,
		CASE a.AB_FLAG
			WHEN 6 THEN 'X'
			ELSE NULL
		END,	
		1,
		CASE a.AB_FLAG
			WHEN 1 THEN 'A'
			WHEN 2 THEN 'A'
			WHEN 5 THEN 'F'
			ELSE 'R'
		END,
		CASE a.AB_FLAG
			WHEN 1 THEN 'Advance Bill'
			WHEN 2 THEN 'Advance Bill'
			WHEN 5 THEN 'Final Adj'
			WHEN 6 THEN 'Reconcile*'
			ELSE 'Reconcile'
		END,	
		CASE a.AB_FLAG
			WHEN 1 THEN 1
			WHEN 2 THEN 1
			WHEN 5 THEN 4
			WHEN 6 THEN 2
			ELSE 3
		END,
		NULL
	FROM dbo.ADVANCE_BILLING AS a
	LEFT OUTER JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR = d.AR_INV_NBR
		AND a.AR_TYPE = d.AR_TYPE	

	UPDATE #job_status_det_adv_hist
	SET DatePaid = (SELECT TOP 1 CC.CR_CHECK_DATE FROM CR_CLIENT_DTL CCD INNER JOIN CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID
					WHERE CCD.AR_INV_NBR = #job_status_det_adv_hist.AR_INV_NBR)
	
	--SELECT * FROM #job_status_det_adv_hist
	
	--Final select statement summing amounts
	SELECT
		[JobNumber] = a.JOB_NUMBER,
		[JobComponentNumber] = a.JOB_COMPONENT_NBR,
		[ARInvoiceNumber] = a.AR_INV_NBR,
		[ARType] = a.AR_TYPE,
		[TotalAmount] = SUM(a.LINE_TOTAL),
		[TotalBilledAmount] = SUM(a.BILLED),
		[AdvancedType] = a.ADV_TYPE,
		[InterimRec] = a.InterimRec,
		[InterimFlag] = a.InterimFlg,
		[BillTypeCode] = CASE WHEN a.AR_INV_NBR IS NULL THEN 'P' ELSE a.BILL_TYPE END,
		[BillTypeDescription] = CASE WHEN a.AR_INV_NBR IS NULL THEN 'Pending' ELSE a.BillTypeDesc END,
		[BillTypeSort] = a.BillTypeSort,
		[DatePaid] = a.DatePaid
	FROM #job_status_det_adv_hist AS a	
	--WHERE a.BillTypeSort = 1
	GROUP BY a.JOB_NUMBER, a.JOB_COMPONENT_NBR, a.AR_INV_NBR, a.AR_TYPE, a.ADV_TYPE,
		a.InterimRec, a.InterimFlg, a.BILL_TYPE, a.BillTypeDesc, a.BillTypeSort, a.DatePaid
END	
