























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpDtl_delete]

@InvNBR varchar(25)
 
AS

Set NOCOUNT ON

Delete From EXPENSE_DETAIL Where INV_NBR = @InvNBR























