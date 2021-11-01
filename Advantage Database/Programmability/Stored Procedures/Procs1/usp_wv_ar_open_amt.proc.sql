





















CREATE PROCEDURE [dbo].[usp_wv_ar_open_amt] 

AS

CREATE TABLE #invamt( 
	Amount         Decimal(20,2)
)

Declare @CRAmount	Decimal(20,2)

Insert Into #invamt
SELECT SUM(ACCT_REC.AR_INV_AMOUNT)
FROM   ACCT_REC 
Where (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL)
Group By ACCT_REC.CL_CODE, ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_DATE


SELECT @CRAmount = SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0))
FROM CR_CLIENT_DTL 
Where (CR_CLIENT_DTL.AR_INV_SEQ <> 99 OR CR_CLIENT_DTL.AR_INV_SEQ IS NULL)

Select SUM(Amount) - @CRAmount From #invamt

Drop Table #invamt





















