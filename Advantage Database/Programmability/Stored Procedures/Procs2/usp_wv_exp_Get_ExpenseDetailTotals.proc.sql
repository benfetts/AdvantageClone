

























CREATE PROCEDURE [dbo].[usp_wv_exp_Get_ExpenseDetailTotals] 
@InvoiceNBR integer
AS

Declare @CCAmt as Decimal(14,2)

select @CCAmt = IsNull(sum(AMOUNT), 0)
from EXPENSE_DETAIL
where INV_NBR = @InvoiceNBR
AND CC_FLAG = 1
AND LINE_NBR > 0

select @CCAmt as CC_AMT_TOTAL,
 	IsNull(sum(AMOUNT), 0) as EXPENSE_AMOUNT,
	IsNUll(sum(AMOUNT), 0) - @CCAmt  as TOTAL_EXPENSE
from EXPENSE_DETAIL
where INV_NBR = @InvoiceNBR
AND LINE_NBR > 0



















