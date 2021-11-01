CREATE FUNCTION [dbo].[advfn_invoice_printing_comment_font_size](
	@app_code varchar(50),				--'Invoices'...
	@comment_type varchar(50),			--'Standard Footer'...
	@office_code varchar(6),			--'o'
	@client_code varchar(6),			--'c'
	@division_code varchar(6),			--'d'
	@product_code varchar(6))			--'p'
RETURNS smallint
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @font_size smallint
		
	--Comment for OCDP (when a comment exists for the specified, office, client, division and product)
	DECLARE @comment_ocdp smallint
	SELECT @comment_ocdp = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code)
		
	--Comment for OCDP2 (null office)
	DECLARE @comment_ocdp2 smallint
	SELECT @comment_ocdp2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code)
		
	--Comment for OCD	
	DECLARE @comment_ocd smallint
	SELECT @comment_ocd = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL)
		
	--Comment for OCD2 (null office)	
	DECLARE @comment_ocd2 smallint
	SELECT @comment_ocd2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL)
		
	--Comment for OC	
	DECLARE @comment_oc smallint
	SELECT @comment_oc = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
		
	--Comment for OC2 (null office)	
	DECLARE @comment_oc2 smallint
	SELECT @comment_oc2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
		
	--Comment for O	
	DECLARE @comment_o smallint
	SELECT @comment_o = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
		
	--Comment for O2 (null office - default)
	DECLARE @comment_o2 smallint
	SELECT @comment_o2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = @app_code
		AND COMMENT_TYPE = @comment_type
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	
	SELECT @font_size = 		
	CASE
		WHEN @division_code IS NOT NULL AND @product_code IS NOT NULL THEN
			COALESCE(@comment_ocdp, @comment_ocdp2, @comment_ocd, @comment_ocd2, @comment_oc, @comment_oc2, @comment_o, @comment_o2)
		WHEN @division_code IS NOT NULL AND @product_code IS NULL THEN
			COALESCE(@comment_ocd, @comment_ocd2, @comment_oc, @comment_oc2, @comment_o, @comment_o2)
		WHEN @division_code IS NULL AND @product_code IS NULL THEN	
			COALESCE(@comment_oc, @comment_oc2, @comment_o, @comment_o2)	
	END	
	
	RETURN @font_size
END
GO


