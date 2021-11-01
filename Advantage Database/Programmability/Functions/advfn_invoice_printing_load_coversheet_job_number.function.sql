CREATE FUNCTION [dbo].[advfn_invoice_printing_load_coversheet_job_number](
	@InvoiceNumber AS int,
	@SequenceNumber AS smallint,
	@IsDraft AS bit)	
RETURNS varchar(MAX)
WITH SCHEMABINDING
AS
BEGIN
	
	DECLARE @ROW_COUNT AS integer
	DECLARE @JobNumber AS varchar(MAX)

	SET @JobNumber = ''
	
	DECLARE @JobDescriptions TABLE([ROW_ID] [int] NOT NULL IDENTITY,
								   [JobNumber] [int] NOT NULL,
								   [JobDescription] [varchar](MAX) NOT NULL,
								   [JobComponentNumber] [smallint] NOT NULL,
								   [JobComponentDescription] [varchar](MAX) NOT NULL)


	IF @IsDraft = 1 BEGIN
	
		INSERT INTO @JobDescriptions
		SELECT 
			DISTINCT
			ARS.JOB_NUMBER,
			JL.JOB_DESC,
			ARS.JOB_COMPONENT_NBR,
			JC.JOB_COMP_DESC
		FROM 
			[dbo].[W_AR_FUNCTION] AS ARS 
			INNER JOIN [dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ARS.JOB_NUMBER
			INNER JOIN [dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ARS.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR
		WHERE 
			ARS.AR_INV_NBR = @InvoiceNumber AND 
			ARS.AR_INV_SEQ = @SequenceNumber AND
			ARS.SUMMARY_FLAG = 0 AND
			ARS.JOB_NUMBER IS NOT NULL

	END ELSE BEGIN
	
		INSERT INTO @JobDescriptions
		SELECT 
			DISTINCT
			ARS.JOB_NUMBER,
			JL.JOB_DESC,
			ARS.JOB_COMPONENT_NBR,
			JC.JOB_COMP_DESC
		FROM 
			[dbo].[AR_SUMMARY] AS ARS 
			INNER JOIN [dbo].[JOB_LOG] AS JL ON JL.JOB_NUMBER = ARS.JOB_NUMBER
			INNER JOIN [dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ARS.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = ARS.JOB_COMPONENT_NBR
		WHERE 
			ARS.AR_INV_NBR = @InvoiceNumber AND 
			ARS.AR_INV_SEQ = @SequenceNumber AND
			ARS.JOB_NUMBER IS NOT NULL

	END

	SET @ROW_COUNT = @@ROWCOUNT

	IF @ROW_COUNT = 0 BEGIN

		SET @JobNumber = ''

	END ELSE IF @ROW_COUNT = 1 BEGIN

		SELECT
			@JobNumber = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JD.JobNumber), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JD.JobComponentNumber), 3)
		FROM
			@JobDescriptions JD
		WHERE
			ROW_ID = 1

	END ELSE BEGIN
	
		SET @JobNumber = 'Various'

	END

	RETURN LTRIM(RTRIM(@JobNumber))

END
GO