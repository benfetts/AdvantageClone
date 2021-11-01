CREATE FUNCTION [dbo].[advfn_invoice_printing_load_coversheet_order_description](
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
	DECLARE @FullOrderDescription AS varchar(MAX)

	SET @FullOrderDescription = ''
	
	DECLARE @OrderDescriptions TABLE([ROW_ID] [int] NOT NULL IDENTITY,
									 [OrderNumber] [int] NOT NULL,
									 [VendorName] [varchar](MAX) NOT NULL,
									 [OrderDescription] [varchar](MAX) NOT NULL,
									 [StartDate] [varchar](MAX) NOT NULL)

	IF @IsDraft = 1 BEGIN
	
		IF @MediaType = 'N' BEGIN
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS 
				INNER JOIN [dbo].[NEWSPAPER_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0 AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'M' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS 
				INNER JOIN [dbo].[MAGAZINE_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0 AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'I' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS 
				INNER JOIN [dbo].[INTERNET_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0 AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'O' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS 
				INNER JOIN [dbo].[OUTDOOR_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0 AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'R' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS 
				INNER JOIN [dbo].[RADIO_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0 AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'T' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS 
				INNER JOIN [dbo].[TV_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0 AND
				ARS.ORDER_NBR IS NOT NULL

		END
		
	END ELSE BEGIN
	
		IF @MediaType = 'N' BEGIN
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[AR_SUMMARY] AS ARS 
				INNER JOIN [dbo].[NEWSPAPER_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'M' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[AR_SUMMARY] AS ARS 
				INNER JOIN [dbo].[MAGAZINE_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'I' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[AR_SUMMARY] AS ARS 
				INNER JOIN [dbo].[INTERNET_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'O' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[AR_SUMMARY] AS ARS 
				INNER JOIN [dbo].[OUTDOOR_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'R' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[AR_SUMMARY] AS ARS 
				INNER JOIN [dbo].[RADIO_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.ORDER_NBR IS NOT NULL

		END ELSE IF @MediaType = 'T' BEGIN 
		
			INSERT INTO @OrderDescriptions
			SELECT 
				DISTINCT
				ARS.ORDER_NBR,
				V.VN_NAME,
				H.ORDER_DESC,
				CONVERT(varchar(10), ARS.START_DATE, 101)
			FROM 
				[dbo].[AR_SUMMARY] AS ARS 
				INNER JOIN [dbo].[TV_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
				INNER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = H.VN_CODE
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.ORDER_NBR IS NOT NULL

		END
		
	END

	SET @ROW_COUNT = @@ROWCOUNT

	IF @ROW_COUNT = 0 BEGIN

		SET @FullOrderDescription = ''

	END ELSE IF @ROW_COUNT = 1 BEGIN

		SELECT
			@FullOrderDescription = OD.VendorName + ' | ' + OD.OrderDescription + ' | ' + OD.StartDate
		FROM
			@OrderDescriptions OD
		WHERE
			ROW_ID = 1

	END ELSE BEGIN
	
		SET @FullOrderDescription = 'Various'

	END

	RETURN LTRIM(RTRIM(@FullOrderDescription))

END


GO