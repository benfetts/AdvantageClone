CREATE FUNCTION [dbo].[advfn_invoice_printing_estimate_function_comment](
	@ESTIMATE_NUMBER int,
	@EST_COMPONENT_NBR smallint,
	@EST_QUOTE_NBR smallint,
	@EST_REV_NBR smallint,
	@FNC_CODE varchar(6),
	@GET_HTML bit)			
RETURNS varchar(MAX)
WITH SCHEMABINDING
AS
BEGIN
	
	DECLARE @ROW_COUNT AS integer
	DECLARE @ROW_ID AS integer
	DECLARE @COMMENT AS varchar(MAX)
	DECLARE @EstimateFunctionComment AS varchar(MAX)
	
	SET @EstimateFunctionComment = ''

	DECLARE @FUNCTION_COMMENTS TABLE([ROW_ID] [int] NOT NULL IDENTITY,
									 [COMMENTS] [varchar](MAX) NULL)

	IF @GET_HTML = 1 BEGIN
	
		INSERT INTO @FUNCTION_COMMENTS
		SELECT 
			CAST(ERD.EST_FNC_COMMENT_HTML AS varchar(MAX))
		FROM 
			[dbo].[ESTIMATE_REV_DET] AS ERD 
		WHERE 
			ERD.ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND 
			ERD.EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND 
			ERD.EST_QUOTE_NBR = @EST_QUOTE_NBR AND 
			ERD.EST_REV_NBR = @EST_REV_NBR AND
			ERD.FNC_CODE = @FNC_CODE AND
			ERD.EST_FNC_COMMENT IS NOT NULL

	END ELSE BEGIN

		INSERT INTO @FUNCTION_COMMENTS
		SELECT 
			CAST(ERD.EST_FNC_COMMENT AS varchar(MAX))
		FROM 
			[dbo].[ESTIMATE_REV_DET] AS ERD 
		WHERE 
			ERD.ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND 
			ERD.EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND 
			ERD.EST_QUOTE_NBR = @EST_QUOTE_NBR AND 
			ERD.EST_REV_NBR = @EST_REV_NBR AND
			ERD.FNC_CODE = @FNC_CODE AND
			ERD.EST_FNC_COMMENT IS NOT NULL
	END
	
	SET @ROW_COUNT = @@ROWCOUNT
	SET @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN

		SET @COMMENT = ''

		SELECT
			@COMMENT = [COMMENTS]
		FROM 
			@FUNCTION_COMMENTS
		WHERE
			ROW_ID = @ROW_ID

		IF LTRIM(RTRIM(ISNULL(@COMMENT, ''))) <> '' BEGIN
		
			IF @EstimateFunctionComment = '' BEGIN

				SET @EstimateFunctionComment = @COMMENT

			END ELSE BEGIN
			
				SET @EstimateFunctionComment = @EstimateFunctionComment + '</br>' + @COMMENT

			END

		END

		SET @ROW_ID = @ROW_ID + 1
	
	END

	RETURN LTRIM(RTRIM(@EstimateFunctionComment))

END


GO