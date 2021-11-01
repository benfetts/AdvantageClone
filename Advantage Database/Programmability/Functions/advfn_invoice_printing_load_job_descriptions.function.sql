CREATE FUNCTION [dbo].[advfn_invoice_printing_load_job_descriptions](
	@InvoiceNumber AS int,
	@SequenceNumber AS smallint,
	@IsDraft AS bit)	
RETURNS varchar(MAX)
WITH SCHEMABINDING
AS
BEGIN
	
	DECLARE @ROW_COUNT AS integer
	DECLARE @ROW_ID AS integer
	DECLARE @JobDescription AS varchar(MAX)
	DECLARE @FullJobDescription AS varchar(MAX)
	
	SET @FullJobDescription = ''

	DECLARE @JobDescriptions TABLE([ROW_ID] [int] NOT NULL IDENTITY,
								   [JobDescription] [varchar](MAX) NULL)

	IF @IsDraft = 1 BEGIN
	
		INSERT INTO @JobDescriptions
		SELECT 
			DISTINCT CAST(JL.JOB_DESC AS varchar(MAX))
		FROM 
			[dbo].[W_AR_FUNCTION] AS ARS LEFT OUTER JOIN
			[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ARS.JOB_NUMBER
		WHERE 
			ARS.AR_INV_NBR = @InvoiceNumber AND 
			ARS.AR_INV_SEQ = @SequenceNumber AND
			ARS.SUMMARY_FLAG = 0 AND
			JL.JOB_DESC IS NOT NULL

	END ELSE BEGIN
	
		INSERT INTO @JobDescriptions
		SELECT 
			DISTINCT CAST(JL.JOB_DESC AS varchar(MAX))
		FROM 
			[dbo].[AR_SUMMARY] AS ARS LEFT OUTER JOIN
			[dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ARS.JOB_NUMBER
		WHERE 
			ARS.AR_INV_NBR = @InvoiceNumber AND 
			ARS.AR_INV_SEQ = @SequenceNumber AND
			JL.JOB_DESC IS NOT NULL

	END

	SET @ROW_COUNT = @@ROWCOUNT
	SET @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN

		SET @JobDescription = ''

		SELECT
			@JobDescription = [JobDescription]
		FROM 
			@JobDescriptions
		WHERE
			ROW_ID = @ROW_ID

		IF LTRIM(RTRIM(ISNULL(@JobDescription, ''))) <> '' BEGIN
		
			IF @FullJobDescription = '' BEGIN

				SET @FullJobDescription = @JobDescription

			END ELSE BEGIN
			
				SET @FullJobDescription = @FullJobDescription + ', ' + @JobDescription

			END

		END

		SET @ROW_ID = @ROW_ID + 1
	
	END

	RETURN LTRIM(RTRIM(@FullJobDescription))

END




GO