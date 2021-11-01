CREATE PROC [dbo].[advsp_clientcashreceipt_check_balanced] @client_cash_receipt_id int, @transaction_id int = NULL

AS

BEGIN
	SET NOCOUNT ON
	
	DECLARE @check_amount		decimal(14,2),
			@payment_sum		decimal(14,2),
			@on_account_amount	decimal(14,2),
			@transaction_amount decimal(16,2)
	
	SELECT	@check_amount = SUM(CR_CHECK_AMT)
	FROM	dbo.CR_CLIENT (NOLOCK)
	WHERE	REC_ID = @client_cash_receipt_id 

	SELECT	@payment_sum = ISNULL(SUM(CR_PAY_AMT), 0)
	FROM	dbo.CR_CLIENT_DTL (NOLOCK)
	WHERE	REC_ID = @client_cash_receipt_id 
	AND		(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

	SELECT	@on_account_amount = ISNULL(CR_OA_AMT, 0)
	FROM	dbo.CR_ON_ACCT (NOLOCK)
	WHERE	REC_ID = @client_cash_receipt_id 
	AND		CR_OA_DIST IS NULL

	SET @transaction_amount = 0

	IF @transaction_id IS NOT NULL
		SELECT	@transaction_amount = ISNULL(SUM(GLETAMT),-1)
		FROM	dbo.GLENTTRL (NOLOCK)
		WHERE	GLETXACT = @transaction_id
	
	--SELECT @check_amount, @payment_sum, @on_account_amount, @transaction_amount
		
	IF (@check_amount = (COALESCE(@payment_sum,0) + COALESCE(@on_account_amount,0))) AND @transaction_amount = 0
		SELECT 1
	ELSE
		SELECT 0
END
GO