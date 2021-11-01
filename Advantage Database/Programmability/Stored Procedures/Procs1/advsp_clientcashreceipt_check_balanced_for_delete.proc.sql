CREATE PROC [dbo].[advsp_clientcashreceipt_check_balanced_for_delete] @client_cash_receipt_id int, @transaction_id int

AS

BEGIN
	SET NOCOUNT ON

	DECLARE	@header_amount		DECIMAL(14,2),
			@payment_sum		DECIMAL(14,2),
			@on_account_amount	DECIMAL(14,2),
			@transaction_amount DECIMAL(16,2),
			@partial_sum		DECIMAL(14,2)

	SELECT	@header_amount = SUM(CR_CHECK_AMT)
	FROM	dbo.CR_CLIENT (NOLOCK)
	WHERE	REC_ID = @client_cash_receipt_id 

	SELECT	@on_account_amount = COALESCE(SUM(CR_OA_AMT), 0)
	FROM	dbo.CR_ON_ACCT (NOLOCK)
	WHERE	REC_ID = @client_cash_receipt_id 
	
	SELECT	@payment_sum = COALESCE(SUM(CR_PAY_AMT), 0)
	FROM	dbo.CR_CLIENT_DTL (NOLOCK)
	WHERE	REC_ID = @client_cash_receipt_id 

	SELECT	@partial_sum = COALESCE(SUM(PAYMENT_AMOUNT), 0)
	FROM	dbo.CR_CLIENT_DTL_PAYMENT (NOLOCK)
	WHERE	REC_ID = @client_cash_receipt_id 

	SELECT	@transaction_amount = ISNULL(SUM(GLETAMT),-1)
	FROM	dbo.GLENTTRL (NOLOCK)
	WHERE	GLETXACT = @transaction_id

	--SELECT @header_amount, @on_account_amount, @payment_sum, @partial_sum, @transaction_amount

	IF @header_amount = 0 AND @on_account_amount = 0 AND @payment_sum = 0 AND @partial_sum = 0 AND @transaction_amount = 0
		SELECT 1
	ELSE
		SELECT 0
END
GO