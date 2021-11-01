


























CREATE PROCEDURE [dbo].[usp_wv_dto_ARForcast2] 
@ClientCode as VarChar(6)
AS

DECLARE @AvgDays integer
Declare @OpenAmt Decimal

CREATE TABLE #temp( 
	Days    	Integer, 
	OpenAmt         Decimal, 
	InvoiceNo	Integer, 
	InvoiceDate	DateTime)

Insert Into #temp (Days)
SELECT     DATEDIFF([Day], MAX(ACCT_REC.AR_INV_DATE), MAX(CR_CLIENT.CR_CHECK_DATE)) AS Days
FROM         CR_CLIENT_DTL INNER JOIN
                      CR_CLIENT ON CR_CLIENT_DTL.REC_ID = CR_CLIENT.REC_ID AND CR_CLIENT_DTL.SEQ_NBR = CR_CLIENT.SEQ_NBR INNER JOIN
                      ACCT_REC ON CR_CLIENT_DTL.AR_INV_NBR = ACCT_REC.AR_INV_NBR AND CR_CLIENT_DTL.AR_INV_SEQ = ACCT_REC.AR_INV_SEQ
GROUP BY CR_CLIENT.CL_CODE, CR_CLIENT_DTL.AR_INV_SEQ, CR_CLIENT_DTL.AR_TYPE, ACCT_REC.VOID_FLAG, ACCT_REC.AR_INV_NBR, DATEDIFF([day], 
                      ACCT_REC.AR_INV_DATE, GETDATE())
HAVING      (CR_CLIENT_DTL.AR_INV_SEQ <> 99) AND (CR_CLIENT_DTL.AR_TYPE = 'IN') AND (CR_CLIENT.CL_CODE Like @ClientCode) AND (ACCT_REC.VOID_FLAG <> 1 OR
                      ACCT_REC.VOID_FLAG IS NULL) AND (DATEDIFF([day], ACCT_REC.AR_INV_DATE, GETDATE()) < 365)

Insert Into #Temp (OpenAmt, InvoiceNo, InvoiceDate)
SELECT     SUM(DISTINCT ACCT_REC.AR_INV_AMOUNT) - SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)) 
                      AS OpenAmt, ACCT_REC.AR_INV_NBR as InvoiceNo, ACCT_REC.AR_INV_DATE as InvoiceDate
FROM         CR_CLIENT INNER JOIN
                      CR_CLIENT_DTL ON CR_CLIENT.REC_ID = CR_CLIENT_DTL.REC_ID AND CR_CLIENT.SEQ_NBR = CR_CLIENT_DTL.SEQ_NBR RIGHT OUTER JOIN
                      ACCT_REC ON CR_CLIENT_DTL.AR_INV_NBR = ACCT_REC.AR_INV_NBR AND CR_CLIENT_DTL.AR_INV_SEQ = ACCT_REC.AR_INV_SEQ
GROUP BY ACCT_REC.CL_CODE, CR_CLIENT_DTL.AR_INV_SEQ, CR_CLIENT_DTL.AR_TYPE, ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_DATE
HAVING      (CR_CLIENT_DTL.AR_INV_SEQ <> 99 OR
                      CR_CLIENT_DTL.AR_INV_SEQ IS NULL) AND (CR_CLIENT_DTL.AR_TYPE = 'IN' OR
                      CR_CLIENT_DTL.AR_TYPE IS NULL) AND (ACCT_REC.CL_CODE Like @ClientCode) AND (SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) 
                      + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)) < SUM(DISTINCT ACCT_REC.AR_INV_AMOUNT))

Select @AvgDays = Avg(days), @OpenAmt = Sum(OpenAmt) from #Temp


Select @AvgDays as AvgDays, @OpenAmt as TotalOpenAmt, Sum(OpenAmt) as OpenAmt, DateAdd(Day, @AvgDays, InvoiceDate) as ForcastDate from #Temp
Where InvoiceDate is not null
Group By InvoiceDate

DROP TABLE #temp


























