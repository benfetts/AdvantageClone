CREATE PROC [dbo].[advsp_othercashreceipt_check_balanced] @other_cash_receipt_id int, @other_cash_receipt_seq_number smallint, @transaction_id int

AS

BEGIN

DECLARE	@check_amount		DECIMAL(14,2),
		@payment_sum		DECIMAL(14,2),
		@gl_sum				DECIMAL(14,2),
		@transaction_amount DECIMAL(16,2)

SELECT	@check_amount = CR_CHECK_AMT
FROM	dbo.CR_OTHER (NOLOCK)
WHERE	REC_ID = @other_cash_receipt_id 
AND		SEQ_NBR = @other_cash_receipt_seq_number 

SELECT	@payment_sum = SUM(COALESCE(CR_AMOUNT, 0))
FROM	dbo.CR_OTHER_DTL (NOLOCK)
WHERE	REC_ID = @other_cash_receipt_id 
AND		SEQ_NBR = @other_cash_receipt_seq_number

SELECT	@gl_sum = ISNULL(SUM(GLETAMT),-1)
FROM	dbo.GLENTTRL (NOLOCK)
WHERE	GLETXACT = @transaction_id 

SELECT @transaction_amount = ISNULL(SUM(GLETAMT),-1)
FROM dbo.GLENTTRL (NOLOCK)
WHERE GLETXACT = @transaction_id

--SELECT @check_amount, @payment_sum, @gl_sum, @transaction_amount

IF (@check_amount = COALESCE(@payment_sum,0)) AND (@gl_sum = 0) AND @transaction_amount = 0
	SELECT 1
ELSE
	SELECT 0

END

GO


