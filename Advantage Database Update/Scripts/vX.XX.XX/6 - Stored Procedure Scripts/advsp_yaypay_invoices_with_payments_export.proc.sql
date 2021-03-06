IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_yaypay_invoices_with_payments_export]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_yaypay_invoices_with_payments_export]
GO

CREATE PROCEDURE [dbo].[advsp_yaypay_invoices_with_payments_export] 
( @StartDate AS smalldatetime,
  @EndDate AS smalldatetime)
AS
--Stored procedure to export invoice data -test

CREATE TABLE #invoice (rowid int IDENTITY(1, 1), 
                    invoiceId varchar(12), 
					customerId varchar(100),
                    invoiceNumber varchar(12),
                    dateCreated datetime,
                    dateUpdated varchar(12),
                    dueDate datetime,
                    terms varchar(60),
                    poNumber varchar(10),
					amount decimal(14,2),
					paid decimal(14,2),
                    currency varchar(5),
					exchangeRate decimal(14,2),
					discount decimal(14,2),
					taxTotal decimal(14,2),
					subTotal decimal(14,2),
					notes varchar(5),
		            billingCompanyName varchar(5),
		            billingEmail varchar(5),
		            billingPhone varchar(5),
		            billingAddress1 varchar(5),
		            billingAddress2 varchar(5),
		            billingCity varchar(5),
		            billingState varchar(5),
		            billingZip varchar(5),
					taxAmount decimal(14,2),
                    customFields varchar(100),
					is_deleted varchar(5));

CREATE TABLE #invoiceCash (invoiceNumber INT, invoiceSequence SMALLINT);

BEGIN

    INSERT INTO #invoiceCash
	SELECT DISTINCT
		CCD.AR_INV_NBR, CCD.AR_INV_SEQ
	FROM dbo.CR_CLIENT_DTL CCD
			INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
			INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
			LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = AR.AR_INV_SEQ
			--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) 

    --SELECT * FROM #invoiceCash

 --   UNION	
	
	--SELECT
	--	txId = CAST(CC.REC_ID AS varchar(12)),
	--	txType = 'Payment',
	--	customerId = CC.CL_CODE + ISNULL(CCD.DIV_CODE,'') + ISNULL(CCD.PRD_CODE,''),
	--	amount = CC.CR_CHECK_AMT,
	--	amountApplied  = 0,
	--	currency = 'USD',
	--	txDate = CC.CR_CHECK_DATE,
	--	memo = 'Payment',
	--	paid = CAST(0 AS decimal),
	--	balance = SUM(COALESCE(CCD.CR_OA_AMT, 0)),
	--	exchangeRate = CAST(0 AS decimal),
	--	refNum = CC.CR_CHECK_NBR,
	--	is_deleted = CASE WHEN [STATUS] = 'D' THEN 'True' ELSE 'False' END,
	--	paymentType = '',
	--	glexact = CCD.GLEXACT,
	--	seqnbr = CCD.SEQ_NBR
	--FROM dbo.CR_ON_ACCT CCD
	--		INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT 
	--		--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	--WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101)
	--GROUP BY CC.REC_ID, CC.CL_CODE, CCD.DIV_CODE, CCD.PRD_CODE, CC.CR_CHECK_DATE, CC.CR_CHECK_NBR, CC.CR_CHECK_AMT, [STATUS],CCD.GLEXACT,CCD.SEQ_NBR

    INSERT INTO #invoice 
	SELECT
		invoiceId = CAST(AR.AR_INV_NBR AS varchar(12)),
		customerId = AR.CL_CODE + ISNULL(AR.DIV_CODE,AR.CL_CODE) + ISNULL(AR.PRD_CODE,AR.CL_CODE),
		invoiceNumber = CAST(AR.AR_INV_NBR AS varchar(12)),
		dateCreated = AR.AR_INV_DATE,
		dateUpdated = '',
		dueDate = CASE 
						WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE 
						WHEN AR.REC_TYPE IN('P','S') AND AR.DUE_DATE IS NULL THEN AR.AR_INV_DATE + ISNULL(C.CL_P_PAYDAYS,0)
						ELSE AR.AR_INV_DATE + ISNULL(C.CL_M_PAYDAYS,0)
					END,
		terms = CASE WHEN ISNULL(AR.REC_TYPE, 'P') <> 'P'THEN ISNULL(C.CL_MFOOTER,'') ELSE ISNULL(C.CL_FOOTER,'') END,
		poNumber = '',
		amount = ISNULL(AR_INV_AMOUNT,0),
		paid = ISNULL(P.Paid,0) + ISNULL(P.Writeoff,0),
		currency = 'USD',
		exchangeRate = CAST(1 AS decimal),
		discount = CAST(0 AS decimal),
		taxTotal = ISNULL(AR.AR_STATE_AMT,0) + ISNULL(AR.AR_COUNTY_AMT,0) + ISNULL(AR_CITY_AMT,0),
		subTotal = ISNULL(AR_INV_AMOUNT,0) - (ISNULL(AR.AR_STATE_AMT,0) + ISNULL(AR.AR_COUNTY_AMT,0) + ISNULL(AR_CITY_AMT,0)),
		notes = '',
		billingCompanyName = '',
		billingEmail = '',
		billingPhone = '',
		billingAddress1 = '',
		billingAddress2 = '',
		billingCity = '',
		billingState = '',
		billingZip = '',
		taxAmount = CAST(0 AS decimal),
		customFields = '',
		is_deleted = CASE WHEN VOID_FLAG = 1 THEN 'True' ELSE 'False' END
	FROM 
		dbo.ACCT_REC AR 
		LEFT OUTER JOIN (SELECT SUM(COALESCE(CR_PAY_AMT, 0)) AS Paid, SUM(COALESCE(CR_ADJ_AMT, 0)) AS Writeoff, AR_INV_NBR, AR_INV_SEQ 
								 FROM	dbo.CR_CLIENT_DTL INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CR_CLIENT_DTL.GLEXACT
                                 WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND (CR_CLIENT_DTL.CR_PAY_AMT <> 0 OR CR_CLIENT_DTL.CR_ADJ_AMT <> 0)
								 GROUP BY AR_INV_NBR, AR_INV_SEQ) P ON AR.AR_INV_NBR = P.AR_INV_NBR AND AR.AR_INV_SEQ = P.AR_INV_SEQ 
		LEFT OUTER JOIN dbo.CLIENT C ON AR.CL_CODE = C.CL_CODE
	WHERE 
		1 = CASE WHEN AR.VOID_DATE IS NOT NULL AND AR.VOID_DATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND AR_TYPE <> 'VO' THEN 1 
		         WHEN AR.CREATE_DATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END AND AR.AR_INV_SEQ <> 99 --AND ISNULL(AR_INV_AMOUNT,0) > 0    

    --SELECT * FROM #invoice
                 
    INSERT INTO #invoice 
	SELECT
		invoiceId = CAST(AR.AR_INV_NBR AS varchar(12)),
		customerId = AR.CL_CODE + ISNULL(AR.DIV_CODE,AR.CL_CODE) + ISNULL(AR.PRD_CODE,AR.CL_CODE),
		invoiceNumber = CAST(AR.AR_INV_NBR AS varchar(12)),
		dateCreated = AR.AR_INV_DATE,
		dateUpdated = '',
		dueDate = CASE 
						WHEN AR.DUE_DATE IS NOT NULL THEN AR.DUE_DATE 
						WHEN AR.REC_TYPE IN('P','S') AND AR.DUE_DATE IS NULL THEN AR.AR_INV_DATE + ISNULL(C.CL_P_PAYDAYS,0)
						ELSE AR.AR_INV_DATE + ISNULL(C.CL_M_PAYDAYS,0)
					END,
		terms = CASE WHEN ISNULL(AR.REC_TYPE, 'P') <> 'P'THEN ISNULL(C.CL_MFOOTER,'') ELSE ISNULL(C.CL_FOOTER,'') END,
		poNumber = '',
		amount = ISNULL(AR_INV_AMOUNT,0),
		paid = ISNULL(P.Paid,0) + ISNULL(P.Writeoff,0),
		currency = 'USD',
		exchangeRate = CAST(1 AS decimal),
		discount = CAST(0 AS decimal),
		taxTotal = ISNULL(AR.AR_STATE_AMT,0) + ISNULL(AR.AR_COUNTY_AMT,0) + ISNULL(AR_CITY_AMT,0),
		subTotal = ISNULL(AR_INV_AMOUNT,0) - (ISNULL(AR.AR_STATE_AMT,0) + ISNULL(AR.AR_COUNTY_AMT,0) + ISNULL(AR_CITY_AMT,0)),
		notes = '',
		billingCompanyName = '',
		billingEmail = '',
		billingPhone = '',
		billingAddress1 = '',
		billingAddress2 = '',
		billingCity = '',
		billingState = '',
		billingZip = '',
		taxAmount = CAST(0 AS decimal),
		customFields = '',
		is_deleted = CASE WHEN VOID_FLAG = 1 THEN 'True' ELSE 'False' END
	FROM 
		dbo.ACCT_REC AR INNER JOIN #invoiceCash ON AR.AR_INV_NBR = #invoiceCash.invoiceNumber AND AR.AR_INV_SEQ = #invoiceCash.invoiceSequence 
		LEFT OUTER JOIN (SELECT SUM(COALESCE(CR_PAY_AMT, 0)) AS Paid, SUM(COALESCE(CR_ADJ_AMT, 0)) AS Writeoff, AR_INV_NBR, AR_INV_SEQ 
								 FROM	dbo.CR_CLIENT_DTL INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CR_CLIENT_DTL.GLEXACT
                                 WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND (CR_CLIENT_DTL.CR_PAY_AMT <> 0 OR CR_CLIENT_DTL.CR_ADJ_AMT <> 0)
								 GROUP BY AR_INV_NBR, AR_INV_SEQ) P ON AR.AR_INV_NBR = P.AR_INV_NBR AND AR.AR_INV_SEQ = P.AR_INV_SEQ 
		LEFT OUTER JOIN dbo.CLIENT C ON AR.CL_CODE = C.CL_CODE
	WHERE 
		 CAST(AR.AR_INV_NBR AS varchar(12)) NOT IN (SELECT invoiceNumber FROM #invoice) --AND ISNULL(AR_INV_AMOUNT,0) > 0
                 
   


    SELECT * FROM #invoice

END
GO

GRANT ALL ON [advsp_yaypay_invoices_with_payments_export] TO PUBLIC AS dbo
GO