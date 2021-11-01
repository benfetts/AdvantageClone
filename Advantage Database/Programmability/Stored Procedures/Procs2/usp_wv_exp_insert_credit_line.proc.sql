

















-- CTB, 20060619  Stripped the time out of the ITEM_DATE insertion value 
-- BJL, 20060621  Changed CC_FLAG to 1 for system generated record 
-- BJL, 20060622  Fixed rounding of amount 

CREATE PROCEDURE [dbo].[usp_wv_exp_insert_credit_line] 
@InvoiceNBR integer
AS

Declare @CCAmount Decimal(15,2)
DECLARE @intErrorCode INT

If Exists(
	SELECT LINE_NBR
	FROM EXPENSE_DETAIL
	WHERE LINE_NBR = 0
	AND INV_NBR = @InvoiceNBR)

	Select 0

else
	Begin
		
		Select @CCAmount = Sum(AMOUNT)
		FROM EXPENSE_DETAIL
		Where CC_FLAG = 1
		AND INV_NBR = @InvoiceNBR

		SELECT @intErrorCode = @@ERROR
		IF (@intErrorCode <> 0) GOTO PROBLEM

		Insert Into EXPENSE_DETAIL( INV_NBR  , 
                                            LINE_NBR , 
                                            ITEM_DATE, 
                                            ITEM_DESC, 
                                            AMOUNT,
					    CC_FLAG )
		                    Values( @InvoiceNBR, 
                                            0, 
                                            LEFT(CONVERT (datetime, CONVERT (int, CONVERT (float, CONVERT (datetime, GetDate())) * 10) / 10),11), 
                                            'System Generated', 
                                            -@CCAmount,
					    1 )

		SELECT @intErrorCode = @@ERROR
		IF (@intErrorCode <> 0) GOTO PROBLEM

		Select 1

	End

PROBLEM:
	ROLLBACK TRAN
	select 0

















