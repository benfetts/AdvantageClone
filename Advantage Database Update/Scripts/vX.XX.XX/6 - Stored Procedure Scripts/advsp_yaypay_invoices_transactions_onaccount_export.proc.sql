IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_yaypay_invoices_transactions_onaccount_export]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_yaypay_invoices_transactions_onaccount_export]
GO

CREATE PROCEDURE [dbo].[advsp_yaypay_invoices_transactions_onaccount_export] 
( @StartDate AS smalldatetime,
  @EndDate AS smalldatetime)
AS
--Stored procedure to export invoice data

CREATE TABLE #cr (txId varchar(12), 
					txType varchar(10),
					customerId varchar(100),
					amount decimal(14,2),
					amountApplied decimal(14,2),
					currency varchar(3),
					txDate datetime,
					memo varchar(10),
					paid decimal(14,2),
					balance decimal(14,2),
					exchangeRate  decimal(14,2),
					refNum varchar(MAX),
					is_deleted varchar(5),
					paymentType varchar(1),
					glexact int,
					seqnbr int,
                    arinvnbr int);

BEGIN	

	INSERT INTO #cr
	SELECT A.* FROM (SELECT
		txId = CAST(CC.REC_ID AS varchar(12)),
		txType = 'OnAcct',
		customerId = CC.CL_CODE + ISNULL(CCD.DIV_CODE,CC.CL_CODE) + ISNULL(CCD.PRD_CODE,CC.CL_CODE),
		amount = SUM(COALESCE(CCD.CR_OA_AMT, 0)), --Original amount rec #1
		amountApplied = 0, -- Original amount - Balance rec #1 - very last rec id
		currency = 'USD',
		txDate = CC.CR_CHECK_DATE,
		memo = 'Payment',
		paid = CAST(0 AS decimal),
		balance = SUM(COALESCE(CCD.CR_OA_AMT, 0)),
		exchangeRate = CAST(1 AS decimal),
		refNum = CC.CR_CHECK_NBR,
		is_deleted = CASE WHEN [STATUS] = 'D' THEN 'True' ELSE 'False' END,
		paymentType = '',
		glexact = 0,
		seqnbr = 0,
        arinvnbr = 0
	FROM dbo.CR_ON_ACCT CCD
			INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
			INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT 
			--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101)
	GROUP BY CC.REC_ID, CC.CL_CODE, CCD.DIV_CODE, CCD.PRD_CODE, CC.CR_CHECK_DATE, [STATUS], CCD.OA_COMMENT, CC.CR_CHECK_NBR) AS A WHERE A.balance <> 0

 --   INSERT INTO #cr
	--SELECT A.* FROM (SELECT
	--	txId = CAST(CC.REC_ID AS varchar(12)) + '-CM',
	--	txType = 'CreditMemo',
	--	customerId = AR.CL_CODE + ISNULL(AR.DIV_CODE,'') + ISNULL(AR.PRD_CODE,''),
	--	amount = SUM(COALESCE(AR.AR_INV_AMOUNT, 0)),
	--	amountApplied = SUM(COALESCE(CCD.CR_PAY_AMT, 0)),
	--	currency = 'USD',
	--	txDate = CC.CR_CHECK_DATE,
	--	memo = 'CreditMemo',
	--	paid = CAST(0 AS decimal),
	--	balance = SUM(COALESCE(AR.AR_INV_AMOUNT, 0)) - SUM(COALESCE(CCD.CR_PAY_AMT, 0)),
	--	exchangeRate = CAST(1 AS decimal),
	--	refNum = CC.CR_CHECK_NBR,
	--	is_deleted = CASE WHEN [STATUS] = 'D' THEN 'True' ELSE 'False' END,
	--	paymentType = '',
	--	glexact = 0,
	--	seqnbr = 0
	--FROM dbo.CR_CLIENT_DTL CCD
	--		INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
	--		LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = CCD.AR_INV_SEQ
	--		--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	--WHERE GL.GLEHENTDATE BETWEEN '1/1/1950' AND CONVERT(DATETIME, '3/5/2021' +' 23:59:00', 101) AND AR.AR_INV_AMOUNT < 0 
	--GROUP BY CC.REC_ID, AR.CL_CODE, AR.DIV_CODE, AR.PRD_CODE, CC.CR_CHECK_DATE, CC.CR_CHECK_NBR, CC.CR_CHECK_AMT, [STATUS], CCD.REC_ITEM_ID) AS A WHERE A.balance <> 0

 --   INSERT INTO #cr
	--SELECT
	--	txId = CAST(AR.AR_INV_NBR AS varchar(12)) + '-CM',
	--	txType = 'CreditMemo',
	--	customerId = AR.CL_CODE + ISNULL(AR.DIV_CODE,AR.CL_CODE) + ISNULL(AR.PRD_CODE,AR.CL_CODE),
	--	amount = COALESCE(AR.AR_INV_AMOUNT, 0),
	--	amountApplied = 0,
	--	currency = 'USD',
	--	txDate = AR.AR_INV_DATE,
	--	memo = 'CreditMemo',
	--	paid = CAST(0 AS decimal),
	--	balance = 0,
	--	exchangeRate = CAST(1 AS decimal),
	--	refNum = '',
	--	is_deleted = '',
	--	paymentType = '',
	--	glexact = 0,
	--	seqnbr = AR.AR_INV_SEQ,
 --       arinvnbr = AR.AR_INV_NBR
	--FROM ACCT_REC AR			
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = AR.GLEXACT
	--		--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	--WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) AND AR.AR_INV_AMOUNT < 0 AND AR_INV_SEQ <> 99 AND AR.AR_INV_NBR NOT IN (SELECT AR_INV_NBR FROM ACCT_REC WHERE AR_TYPE = 'VO')-- AND AR.AR_TYPE <> 'VO' --AND AR.AR_INV_NBR NOT IN (SELECT AR_INV_NBR FROM CR_CLIENT_DTL CCD WHERE CCD.AR_INV_NBR = AR.AR_INV_NBR)

 --   -- SELECT * FROM #cr
 --   --WHERE txType = 'OnAcct'

 --   --UPDATE #cr
 --   --SET amount = (SELECT SUM(COALESCE(CR_ON_ACCT.CR_OA_AMT,0)) FROM CR_ON_ACCT WHERE #cr.txId = CR_ON_ACCT.REC_ID AND REC_ITEM_ID = 1 GROUP BY CR_ON_ACCT.REC_ID )
 --   --WHERE txType = 'OnAcct'

 --   --UPDATE #cr
 --   --SET amountApplied = amount - balance
 --   --WHERE txType = 'OnAcct'

 --   UPDATE #cr
 --   SET amountApplied = ISNULL((SELECT SUM(COALESCE(CCD.CR_PAY_AMT, 0)) + SUM(COALESCE(CCD.CR_ADJ_AMT, 0)) FROM dbo.CR_CLIENT_DTL CCD WHERE #cr.arinvnbr = CCD.AR_INV_NBR AND #cr.seqnbr = CCD.AR_INV_SEQ),0)
 --   WHERE txType = 'CreditMemo'

 --   UPDATE #cr
 --   SET balance = amount - amountapplied
 --   WHERE txType = 'CreditMemo'

    UPDATE #cr
    SET amount = CASE WHEN amount < 0 THEN amount * -1 ELSE amount END, amountApplied = CASE WHEN amountApplied < 0 THEN amountApplied * -1 ELSE amountApplied END, balance = CASE WHEN balance < 0 THEN balance * -1 ELSE balance END

    --UPDATE #cr
    --SET amount = amount * -1, amountApplied = amountApplied * -1, balance = balance * -1
    --WHERE txType = 'OnAcct'


    SELECT * FROM #cr
    WHERE balance <> 0
    ORDER BY txId

	--UPDATE #cr
	--SET amount = 0
	--WHERE glexact <> (SELECT GLEXACT FROM CR_CLIENT WHERE REC_ID = #cr.txId AND SEQ_NBR = #cr.seqnbr)

	--SELECT txId, txType, customerId, amount, SUM(amountApplied) AS amountApplied, currency, txDate, memo, paid, SUM(balance) AS balance,
	--	   exchangeRate, refNum, is_deleted, paymentType
	--FROM #cr
	--GROUP BY txId, txType, customerId, amount, currency, txDate, memo, paid, 
	--	   exchangeRate, refNum, is_deleted, paymentType

	--SELECT A.txId, A.txType, A.customerId, A.amount, SUM(A.amountApplied) AS amountApplied, A.currency, A.txDate, A.memo, A.paid, SUM(A.balance) AS balance,
	--	   A.exchangeRate, A.refNum, A.is_deleted, A.paymentType FROM (
	--SELECT
	--	txId = CAST(CC.REC_ID AS varchar(12)),
	--	txType = 'Payment',
	--	customerId = AR.CL_CODE + ISNULL(AR.DIV_CODE,'') + ISNULL(AR.PRD_CODE,''),
	--	amount = CC.CR_CHECK_AMT,
	--	amountApplied  = SUM(COALESCE(CCD.CR_PAY_AMT, 0)),
	--	currency = 'USD',
	--	txDate = CC.CR_CHECK_DATE,
	--	memo = '',
	--	paid = CAST(0 AS decimal),
	--	balance = 0,
	--	exchangeRate = CAST(0 AS decimal),
	--	refNum = CC.CR_CHECK_NBR,
	--	is_deleted = CASE WHEN [STATUS] = 'D' THEN 'True' ELSE 'False' END,
	--	paymentType = ''
	--FROM dbo.CR_CLIENT_DTL CCD
	--		INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT
	--		LEFT OUTER JOIN ACCT_REC AR ON AR.AR_INV_NBR = CCD.AR_INV_NBR AND AR.AR_INV_SEQ = AR.AR_INV_SEQ
	--		--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	--WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101)
	--GROUP BY CC.REC_ID, AR.CL_CODE, AR.DIV_CODE, AR.PRD_CODE, CC.CR_CHECK_DATE, CC.CR_CHECK_NBR, CC.CR_CHECK_AMT, [STATUS]

	--UNION

	--SELECT
	--	txId = CAST(CC.REC_ID AS varchar(12)),
	--	txType = 'Payment',
	--	customerId = CC.CL_CODE + ISNULL(CCD.DIV_CODE,'') + ISNULL(CCD.PRD_CODE,''),
	--	amount = CC.CR_CHECK_AMT,
	--	amountApplied  = 0,
	--	currency = 'USD',
	--	txDate = CC.CR_CHECK_DATE,
	--	memo = '',
	--	paid = CAST(0 AS decimal),
	--	balance = SUM(COALESCE(CCD.CR_OA_AMT, 0)),
	--	exchangeRate = CAST(0 AS decimal),
	--	refNum = CC.CR_CHECK_NBR,
	--	is_deleted = CASE WHEN [STATUS] = 'D' THEN 'True' ELSE 'False' END,
	--	paymentType = ''
	--FROM dbo.CR_ON_ACCT CCD
	--		INNER JOIN dbo.CR_CLIENT CC ON CCD.REC_ID = CC.REC_ID AND CCD.SEQ_NBR = CC.SEQ_NBR
	--		INNER JOIN dbo.GLENTHDR GL ON GL.GLEHXACT = CCD.GLEXACT 
	--		--INNER JOIN (SELECT REC_ID, MAX(SEQ_NBR) AS SEQ_NBR FROM CR_CLIENT GROUP BY REC_ID) AS CCMAX ON CCMAX.REC_ID = CC.REC_ID AND CCMAX.SEQ_NBR = CC.SEQ_NBR
	--WHERE GL.GLEHENTDATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101)
	--GROUP BY CC.REC_ID, CC.CL_CODE, CCD.DIV_CODE, CCD.PRD_CODE, CC.CR_CHECK_DATE, CC.CR_CHECK_NBR, CC.CR_CHECK_AMT, [STATUS]
	
	--) AS A
	--GROUP BY A.txId, A.txType, A.customerId, A.currency, A.txDate, A.memo, A.paid, A.exchangeRate, A.refNum, A.is_deleted, A.paymentType, A.amount

END
GO

GRANT ALL ON [advsp_yaypay_invoices_transactions_export] TO PUBLIC AS dbo
GO