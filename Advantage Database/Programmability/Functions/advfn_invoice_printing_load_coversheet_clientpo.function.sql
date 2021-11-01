CREATE FUNCTION [dbo].[advfn_invoice_printing_load_coversheet_clientpo](
	@InvoiceNumber AS int,
	@SequenceNumber AS smallint,
	@RecordType AS varchar(1),
	@IsDraft AS bit)	
RETURNS varchar(MAX)
WITH SCHEMABINDING
AS
BEGIN
	
	DECLARE @ROW_COUNT AS integer
	DECLARE @DISTINCT_ROW_COUNT AS integer
	DECLARE @ClientPO AS varchar(MAX)

	SET @ClientPO = ''

	DECLARE @JobClientPOs TABLE([ROW_ID] [int] NOT NULL IDENTITY,
								[ClientPO] [varchar](MAX) NULL)

	IF @IsDraft = 1 BEGIN
	
		IF @RecordType= '' OR @RecordType = 'P' OR @RecordType = 'S' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(JC.JOB_CL_PO_NBR, '') AS varchar(MAX))
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ARS.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0

		END ELSE IF @RecordType = 'M' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
				[dbo].[MAGAZINE_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0

		END ELSE IF @RecordType = 'N' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
				[dbo].[NEWSPAPER_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0

		END ELSE IF @RecordType = 'I' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
				[dbo].[INTERNET_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0

		END ELSE IF @RecordType = 'O' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
				[dbo].[OUTDOOR_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0

		END ELSE IF @RecordType = 'R' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
				[dbo].[RADIO_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0

		END ELSE IF @RecordType = 'T' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
				[dbo].[TV_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber AND
				ARS.SUMMARY_FLAG = 0

		END

	END ELSE BEGIN
	
		IF @RecordType= '' OR @RecordType = 'P' OR @RecordType = 'S' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(JC.JOB_CL_PO_NBR, '') AS varchar(MAX))
			FROM 
				[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
				[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ARS.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber

		END ELSE IF @RecordType = 'M' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
				[dbo].[MAGAZINE_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber

		END ELSE IF @RecordType = 'N' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
				[dbo].[NEWSPAPER_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber

		END ELSE IF @RecordType = 'I' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
				[dbo].[INTERNET_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber

		END ELSE IF @RecordType = 'O' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
				[dbo].[OUTDOOR_HEADER] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber

		END ELSE IF @RecordType = 'R' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
				[dbo].[RADIO_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber

		END ELSE IF @RecordType = 'T' BEGIN
		
			INSERT INTO @JobClientPOs
			SELECT 
				DISTINCT CAST(ISNULL(H.CLIENT_PO, '') AS varchar(MAX))
			FROM 
				[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
				[dbo].[TV_HDR] AS H ON H.ORDER_NBR = ARS.ORDER_NBR
			WHERE 
				ARS.AR_INV_NBR = @InvoiceNumber AND 
				ARS.AR_INV_SEQ = @SequenceNumber

		END

	END

	SET @ROW_COUNT = @@ROWCOUNT
	
	IF @ROW_COUNT = 0 BEGIN
	
		SET @ClientPO = ''

	END ELSE IF @ROW_COUNT = 1 BEGIN
	
		SELECT
			@ClientPO = JCPO.ClientPO
		FROM
			@JobClientPOs JCPO
		WHERE
			ROW_ID = 1

	END ELSE BEGIN
	
		SET @ClientPO = ''

	END

	RETURN LTRIM(RTRIM(@ClientPO))

END






GO