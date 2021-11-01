



















CREATE PROCEDURE [dbo].[usp_wv_exp_delete_credit_line] 
@InvoiceNBR integer
AS

Delete from EXPENSE_DETAIL
where INV_NBR = @InvoiceNBR
AND LINE_NBR = 0



















