-- advtf_std_invoice_comment
-- #00 09/12/12 - Initial release
-- To test - SELECT * FROM dbo.advtf_std_invoice_comment('main','abc','abc','abc')

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advtf_std_invoice_comment]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advtf_std_invoice_comment]
GO

CREATE FUNCTION [dbo].[advtf_std_invoice_comment](
	@office_code varchar(6), 
	@client_code varchar(6), 
	@division_code varchar(6),
	@product_code varchar(6))
		
RETURNS @table TABLE (
	--std_comment varchar(4000),
	std_comment text,
	font_size smallint)
AS
BEGIN
	--COMMENT
	--O = Office
	--C = Client
	--D = Division	
	--P = Product
	--Comment for OCDP
	DECLARE @comment_ocdp varchar(4000)
	SELECT @comment_ocdp = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code)
	--Comment for OCDP2 (null office)
	DECLARE @comment_ocdp2 varchar(4000)
	SELECT @comment_ocdp2 = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code)
	--Comment for OCD	
	DECLARE @comment_ocd varchar(4000)
	SELECT @comment_ocd = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL)
	--Comment for OCD2 (null office)	
	DECLARE @comment_ocd2 varchar(4000)
	SELECT @comment_ocd2 = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL)
	--Comment for OC	
	DECLARE @comment_oc varchar(4000)
	SELECT @comment_oc = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	--Comment for OC2 (null office)	
	DECLARE @comment_oc2 varchar(4000)
	SELECT @comment_oc2 = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	--Comment for O
	DECLARE @comment_o varchar(4000)
	SELECT @comment_o = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	--Comment for O2 (null office - default)
	DECLARE @comment_o2 varchar(4000)
	SELECT @comment_o2 = (SELECT STD_COMMENT FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	
	--FONT SIZE	
	--Font Size for OCDP
	DECLARE @font_size_ocdp varchar(4000)
	SELECT @font_size_ocdp = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code)
	--Font Size for OCDP2 (null office)
	DECLARE @font_size_ocdp2 varchar(4000)
	SELECT @font_size_ocdp2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE = @product_code)
	--Font Size for OCD	
	DECLARE @font_size_ocd varchar(4000)
	SELECT @font_size_ocd = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL)
	--Font Size for OCD2	 (null office)
	DECLARE @font_size_ocd2 varchar(4000)
	SELECT @font_size_ocd2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE = @division_code
		AND PRODUCT_CODE IS NULL)
	--Font Size for OC	
	DECLARE @font_size_oc varchar(4000)
	SELECT @font_size_oc = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	--Font Size for OC2 (null office)	
	DECLARE @font_size_oc2 varchar(4000)
	SELECT @font_size_oc2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE = @client_code
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	--Font Size for O
	DECLARE @font_size_o varchar(4000)
	SELECT @font_size_o = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE = @office_code
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL)
	--Font Size for O2 (null office - default)
	DECLARE @font_size_o2 varchar(4000)
	SELECT @font_size_o2 = (SELECT FONT_SIZE FROM dbo.STD_COMMENT 
		WHERE APP_CODE = 'Invoices'
		AND COMMENT_TYPE = 'Standard Footer'
		AND OFFICE_CODE IS NULL
		AND CLIENT_CODE IS NULL
		AND DIVISION_CODE IS NULL
		AND PRODUCT_CODE IS NULL
		AND STD_COMMENT IS NOT NULL)	
	
	INSERT INTO @table
	SELECT 
		COALESCE(@comment_ocdp, @comment_ocdp2, @comment_ocd, @comment_ocd2, @comment_oc, @comment_oc2, @comment_o, @comment_o2),		
		COALESCE(@font_size_ocdp, @font_size_ocdp2, @font_size_ocd, @font_size_ocd2, @font_size_oc, @font_size_oc2, @font_size_o, @font_size_o2)

	RETURN
END





