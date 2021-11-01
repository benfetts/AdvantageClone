

























CREATE PROCEDURE [dbo].[usp_wv_exp_GetMaxLineNBR]
 
@INV_NBR VarChar(25)

AS

SET NOCOUNT ON

SELECT MAX(LINE_NBR) as LINE_NBR
FROM EXPENSE_DETAIL 
WHERE INV_NBR = @INV_NBR

























