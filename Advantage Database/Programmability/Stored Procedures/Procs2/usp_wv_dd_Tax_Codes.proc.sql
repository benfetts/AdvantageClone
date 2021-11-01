



















CREATE PROCEDURE [dbo].[usp_wv_dd_Tax_Codes] 

AS
SELECT DISTINCT TAX_CODE as code, cast(TAX_CODE as VarChar(10)) + ' - ' + ISNULL(TAX_DESCRIPTION, '') as description
FROM SALES_TAX
WHERE INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0

















