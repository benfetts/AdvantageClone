CREATE PROCEDURE [dbo].[advsp_ar_invoice_balanced] @ar_inv_nbr int, @ar_inv_seq smallint, @ar_type varchar(3), @transaction_id int
AS
BEGIN

DECLARE	@cos_amount DECIMAL(14,2),
		@sale_amount DECIMAL(13,2),
		@offset_amount DECIMAL(13,2),
		@def_amount DECIMAL(13,2),
		@ar_amount DECIMAL(15,2),
		@tax_amount DECIMAL(15,2),
		@transaction_amount DECIMAL(16,2)
		
	SELECT	@cos_amount = ISNULL(AR_COS_AMT,0),
			@sale_amount = ISNULL(AR_SALE_AMT,0),
			@offset_amount = ISNULL(AR_OFFSET_AMT,0),
			@def_amount = ISNULL(AR_DEF_SALE_AMT,0),
			@ar_amount = ISNULL(AR_INV_AMOUNT,0),
			@tax_amount = ISNULL(AR_STATE_AMT,0) + ISNULL(AR_COUNTY_AMT,0) + ISNULL(AR_CITY_AMT,0)
	FROM dbo.ACCT_REC (NOLOCK)
	WHERE	AR_INV_NBR = @ar_inv_nbr 
	AND		AR_INV_SEQ = @ar_inv_seq 
	AND		AR_TYPE = @ar_type 
	
	SELECT @transaction_amount = ISNULL(SUM(GLETAMT),-1)
	FROM dbo.GLENTTRL (NOLOCK)
	WHERE GLETXACT = @transaction_id

	IF (@sale_amount + @def_amount) = (@ar_amount - @tax_amount)
		AND (@offset_amount = @cos_amount)
		AND (@ar_amount + @cos_amount) = (@sale_amount + @def_amount + @offset_amount + @tax_amount)
		AND @transaction_amount = 0
			SELECT 1
	ELSE
			SELECT 0
	
END


GO


