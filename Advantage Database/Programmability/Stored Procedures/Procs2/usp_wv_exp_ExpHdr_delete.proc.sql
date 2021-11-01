























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpHdr_delete]

@InvNBR varchar(25)
 
AS

Set NOCOUNT ON

Delete From EXPENSE_HEADER Where INV_NBR = @InvNBR























