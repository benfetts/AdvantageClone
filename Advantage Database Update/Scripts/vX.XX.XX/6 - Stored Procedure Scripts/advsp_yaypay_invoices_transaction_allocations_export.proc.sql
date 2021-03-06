IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_yaypay_invoices_transaction_allocations_export]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_yaypay_invoices_transaction_allocations_export]
GO

CREATE PROCEDURE [dbo].[advsp_yaypay_invoices_transaction_allocations_export] 
( @StartDate AS smalldatetime,
  @EndDate AS smalldatetime)
AS
--Stored procedure to export invoice data test

BEGIN

CREATE TABLE #tr (txId int);

CREATE TABLE #ar (txId varchar(12),
                  invoiceId varchar(12));

CREATE TABLE #trans (txId varchar(12),
                      invoiceId varchar(12),
                      amount decimal(14,2),
                      [date] datetime,
                      paid decimal(14,2), 
                      arinvnbr int,
					  crtype varchar(5));


 --   INSERT INTO #tr
 --   SELECT DISTINCT CC.REC_ID
 --   FROM dbo.CR_ON_ACCT CCD
	--		INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT 
	--		--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	--WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101)

    INSERT INTO #ar
    SELECT DISTINCT CCD.REC_ID, CCD.AR_INV_NBR
    FROM dbo.CR_CLIENT_DTL CCD
			INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
			INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
			LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = CCD.AR_INV_SEQ
	WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101)

    --SELECT * FROM #ar    
    
 --   INSERT INTO #trans
 --   SELECT
	--	txId = CAST(CCD.REC_ID AS varchar(12)) + '-CM',
	--	invoiceId = CAST(CCD.AR_INV_NBR AS varchar(12)),
	--	amount = SUM(COALESCE(AR.AR_INV_AMOUNT, 0)) * -1,
	--	[date] = CR_CHECK_DATE,
	--	paid = CAST(0 AS decimal),
 --       arinvnbr = CCD.AR_INV_NBR
	--FROM dbo.CR_CLIENT_DTL CCD
	--		INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
	--		LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = CCD.AR_INV_SEQ
	--WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND AR.AR_INV_AMOUNT < 0
	--GROUP BY CCD.REC_ID, CCD.AR_INV_NBR, CCD.AR_INV_SEQ, CR_CHECK_DATE
    
 --   INSERT INTO #trans
 --   SELECT
	--	txId = CAST(AR.AR_INV_NBR AS varchar(12)) + '-CM',
	--	invoiceId = CAST(AR.AR_INV_NBR AS varchar(12)),
	--	amount = COALESCE(AR.AR_INV_AMOUNT, 0) * -1,
	--	[date] =  AR.AR_INV_DATE,
	--	paid = CAST(0 AS decimal),
 --       arinvnbr = AR.AR_INV_NBR
	--FROM ACCT_REC AR			
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = AR.GLEXACT
	--WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND AR.AR_INV_AMOUNT < 0 AND AR.AR_INV_NBR NOT IN (SELECT arinvnbr FROM #trans)

    INSERT INTO #trans
	SELECT
		txId = CAST(CCD.REC_ID AS varchar(12)) + '-P',
		invoiceId = CAST(CCD.AR_INV_NBR AS varchar(12)),
		amount = SUM(COALESCE(CR_PAY_AMT, 0)),
		[date] = CR_CHECK_DATE,
		paid = CAST(0 AS decimal),
        arinvnbr = CCD.AR_INV_NBR,
		crtype = 'P'
	FROM dbo.CR_CLIENT_DTL CCD
			INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
			INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
			LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = CCD.AR_INV_SEQ
	WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND CCD.CR_PAY_AMT <> 0 AND AR.AR_INV_NBR NOT IN (SELECT invoiceId FROM #trans WHERE #trans.txId LIKE '%CM%')
	GROUP BY CCD.REC_ID, CCD.AR_INV_NBR, CCD.AR_INV_SEQ, CR_CHECK_DATE
    
    INSERT INTO #trans
    SELECT
		txId = CAST(CCD.REC_ID AS varchar(12)) + '-A',
		invoiceId = CAST(CCD.AR_INV_NBR AS varchar(12)),
		amount = SUM(COALESCE(CR_ADJ_AMT, 0)) * -1,
		[date] = CR_CHECK_DATE,
		paid = CAST(0 AS decimal),
        arinvnbr = CCD.AR_INV_NBR,
		crtype = 'A'
	FROM dbo.CR_CLIENT_DTL CCD
			INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
			INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
			LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = CCD.AR_INV_SEQ
	WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND CCD.CR_ADJ_AMT <> 0
	GROUP BY CCD.REC_ID, CCD.AR_INV_NBR, CCD.AR_INV_SEQ, CR_CHECK_DATE

 --   INSERT INTO #trans
	--SELECT
	--	txId = CAST(CCD.REC_ID AS varchar(12)) + '-' + CAST(CCD.SEQ_NBR AS varchar(5)),
	--	invoiceId = '',
	--	amount = SUM(COALESCE(CCD.CR_OA_AMT, 0)),
	--	[date] = CR_CHECK_DATE,
	--	paid = CAST(0 AS decimal),
 --       arinvnbr = 0
	--FROM dbo.CR_ON_ACCT CCD
	--		INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
 --           INNER JOIN #tr ON #tr.txId = CC.REC_ID 
	----WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) 
	--GROUP BY CCD.REC_ID, CCD.SEQ_NBR, CR_CHECK_DATE    


    INSERT INTO #trans
    SELECT
		txId = CAST(CCD.REC_ID AS varchar(12)) + '-P',
		invoiceId = CAST(CCD.AR_INV_NBR AS varchar(12)),
		amount = SUM(COALESCE(CR_PAY_AMT, 0)),
		[date] = CR_CHECK_DATE,
		paid = CAST(0 AS decimal),
        arinvnbr = CCD.AR_INV_NBR,
		crtype = 'P'
	FROM dbo.CR_CLIENT_DTL CCD
			INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
			INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
			LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = CCD.AR_INV_SEQ
	WHERE GL.GLEHENTDATE < @StartDate AND GL.GLEHENTDATE > CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND CCD.REC_ID NOT IN (SELECT DISTINCT txId FROM #trans)
	GROUP BY CCD.REC_ID, CCD.AR_INV_NBR, CCD.AR_INV_SEQ, CR_CHECK_DATE
    UNION
    SELECT
		txId = CAST(CCD.REC_ID AS varchar(12)) + '-A',
		invoiceId = CAST(CCD.AR_INV_NBR AS varchar(12)),
		amount = SUM(COALESCE(CR_ADJ_AMT, 0)) * -1,
		[date] = CR_CHECK_DATE,
		paid = CAST(0 AS decimal),
        arinvnbr = CCD.AR_INV_NBR,
		crtype = 'A'
	FROM dbo.CR_CLIENT_DTL CCD
			INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
			INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
			LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = CCD.AR_INV_SEQ
	WHERE GL.GLEHENTDATE < @StartDate AND GL.GLEHENTDATE > CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND CCD.REC_ID NOT IN (SELECT DISTINCT txId FROM #trans)
	GROUP BY CCD.REC_ID, CCD.AR_INV_NBR, CCD.AR_INV_SEQ, CR_CHECK_DATE

    
    UPDATE #trans
    SET amount = CASE WHEN amount < 0 THEN amount * -1 ELSE amount END
	WHERE crtype = 'P'


    SELECT txId,
		invoiceId,
		amount,
		[date],
		paid,
        arinvnbr FROM #trans
    
    DROP TABLE #ar
    DROP TABLE #trans
		

END
GO

GRANT ALL ON [advsp_yaypay_invoices_transaction_allocations_export] TO PUBLIC AS dbo
GO