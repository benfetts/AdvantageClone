CREATE FUNCTION [dbo].[advfn_invoice_printing_load_coversheet_order_number](
	@InvoiceNumber AS int,
	@SequenceNumber AS smallint,
	@MediaType AS varchar(1),
	@MediaTypeDescription AS varchar(MAX),
	@IsDraft AS bit)	
RETURNS varchar(MAX)
WITH SCHEMABINDING
AS
BEGIN
	
	DECLARE @ROW_COUNT AS integer
	DECLARE @OrderNumber AS varchar(MAX)

	SET @OrderNumber = ''
	
	DECLARE @OrderDescriptions TABLE([ROW_ID] [int] NOT NULL IDENTITY,
									 [OrderNumber] [int] NOT NULL)

	IF @IsDraft = 1 BEGIN
	
		INSERT INTO @OrderDescriptions
		SELECT 
			DISTINCT
			ARS.ORDER_NBR
		FROM 
			[dbo].[W_AR_FUNCTION] AS ARS
		WHERE 
			ARS.AR_INV_NBR = @InvoiceNumber AND 
			ARS.AR_INV_SEQ = @SequenceNumber AND
			ARS.SUMMARY_FLAG = 0 AND
			ARS.ORDER_NBR IS NOT NULL

	END ELSE BEGIN
	
		INSERT INTO @OrderDescriptions
		SELECT 
			DISTINCT
			ARS.ORDER_NBR
		FROM 
			[dbo].[AR_SUMMARY] AS ARS
		WHERE 
			ARS.AR_INV_NBR = @InvoiceNumber AND 
			ARS.AR_INV_SEQ = @SequenceNumber AND
			ARS.ORDER_NBR IS NOT NULL

	END

	SET @ROW_COUNT = @@ROWCOUNT

	IF @ROW_COUNT = 0 BEGIN

		SET @OrderNumber = ''

	END ELSE IF @ROW_COUNT = 1 BEGIN

		SELECT
			@OrderNumber = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), OD.OrderNumber), 6)
		FROM
			@OrderDescriptions OD
		WHERE
			ROW_ID = 1

	END ELSE BEGIN
	
		SET @OrderNumber = @MediaTypeDescription

	END

	RETURN LTRIM(RTRIM(@OrderNumber))

END

GO


