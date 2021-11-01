


















CREATE PROCEDURE [dbo].[usp_wv_validate_sales_class_code] 
@SalesClassCode VarChar(6)

AS
SET NOCOUNT ON
 
	IF EXISTS(
			SELECT 
				DISTINCT SC_CODE
			FROM 
				SALES_CLASS
			WHERE 
				(INACTIVE_FLAG = 0 
				OR INACTIVE_FLAG IS NULL)
				AND SC_CODE = @SalesClassCode
	)
		SELECT 1
	ELSE
		SELECT 0

















