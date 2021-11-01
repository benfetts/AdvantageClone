























CREATE PROCEDURE [dbo].[usp_wv_dd_job_sales_class_format] 
@SalesClass VarChar(6)
AS
SELECT DISTINCT FORMAT_CODE as code, FORMAT_CODE + ' - ' + ISNULL(FORMAT_DESC,'')  as description
FROM SC_FORMAT 
WHERE  SC_CODE LIKE @SalesClass+'%'
AND ACTIVE = 1


















