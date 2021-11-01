























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpDtl_deleteline]

@InvNBR varchar(25),
@InvLine int
 
AS

Set NOCOUNT ON

Delete From EXPENSE_DETAIL Where INV_NBR = @InvNBR and LINE_NBR = @InvLine























