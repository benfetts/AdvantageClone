


















CREATE PROCEDURE [dbo].[usp_wv_function_getrate] 
@FunctionCode as VarChar(6)
AS

SELECT     FNC_BILLING_RATE
FROM         FUNCTIONS
WHERE     (FNC_CODE = @FunctionCode)


















