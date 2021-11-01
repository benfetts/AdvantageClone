


















CREATE PROCEDURE [dbo].[usp_wv_validate_sales_class_code_all] 
@SalesClassCode VarChar(6)

AS
SET NOCOUNT ON
 
	IF EXISTS(
			SELECT 
				DISTINCT SC_CODE
			FROM 
				SALES_CLASS
			WHERE 
				SC_CODE = @SalesClassCode
	)
		SELECT 1
	ELSE
		SELECT 0

















