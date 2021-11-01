if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_cs_load_basic_job_info]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_cs_load_basic_job_info]
GO

CREATE PROCEDURE [dbo].[advsp_cs_load_basic_job_info] /*WITH ENCRYPTION*/
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@ALERT_ID INT,
@CS_PROJECT_ID INT,
@CS_REVIEW_ID INT
AS
BEGIN

	SET @JOB_NUMBER = ISNULL(@JOB_NUMBER, 0);
	SET @JOB_COMPONENT_NBR = ISNULL(@JOB_COMPONENT_NBR, 0);
	SET @ALERT_ID = ISNULL(@ALERT_ID, 0);
	SET @CS_PROJECT_ID = ISNULL(@CS_PROJECT_ID, 0);
	SET @CS_REVIEW_ID = ISNULL(@CS_REVIEW_ID, 0);

	DECLARE
		@JobNumber INT,
		@JobComponentNumber SMALLINT,
		@ClientCode VARCHAR(6),
		@ClientName VARCHAR(500),
		@ClientDisplay VARCHAR(500),
		@DivisionCode VARCHAR(6),
		@DivisionName VARCHAR(500),
		@DivisionDisplay VARCHAR(500),
		@ProductCode VARCHAR(6),
		@ProductName VARCHAR(500),
		@ProductDisplay VARCHAR(500),
		@JobDescription VARCHAR(500),
		@JobComponentDescription VARCHAR(500),
		@JobDisplay VARCHAR(500),
		@JobComponentDisplay VARCHAR(500),
		@JobAndComponentDisplay VARCHAR(1000);

	IF @JOB_NUMBER = 0 AND @JOB_COMPONENT_NBR = 0 
	BEGIN

		IF @ALERT_ID > 0
		BEGIN
			SELECT @JOB_NUMBER = ISNULL(JOB_NUMBER, 0), @JOB_COMPONENT_NBR = ISNULL(JOB_COMPONENT_NBR, 0) FROM ALERT WHERE ALERT_ID = @ALERT_ID;
		END
		IF @JOB_NUMBER = 0 AND @JOB_COMPONENT_NBR = 0 
		BEGIN

			IF @CS_PROJECT_ID > 0
			BEGIN
				SELECT @JOB_NUMBER = ISNULL(JOB_NUMBER, 0), @JOB_COMPONENT_NBR = ISNULL(JOB_COMPONENT_NBR, 0) FROM JOB_COMPONENT WHERE @CS_PROJECT_ID = @CS_PROJECT_ID;
			END

		END
		IF @JOB_NUMBER = 0 AND @JOB_COMPONENT_NBR = 0 
		BEGIN

			IF @CS_REVIEW_ID > 0
			BEGIN
				SELECT @JOB_NUMBER = ISNULL(JOB_NUMBER, 0), @JOB_COMPONENT_NBR = ISNULL(JOB_COMPONENT_NBR, 0) FROM ALERT WHERE CS_REVIEW_ID = @CS_REVIEW_ID;
			END

		END

	END

	IF @JOB_NUMBER > 0
	BEGIN

		SELECT        
			@JobNumber = JL.JOB_NUMBER, 
			@JobDescription = JL.JOB_DESC,
			@ClientCode = C.CL_CODE, 
			@ClientName = C.CL_NAME, 
			@DivisionCode = D.DIV_CODE, 
			@DivisionName = D.DIV_NAME, 
			@ProductCode = P.PRD_CODE, 
			@ProductName = P.PRD_DESCRIPTION
		FROM            
			JOB_LOG JL
			INNER JOIN CLIENT C ON JL.CL_CODE = C.CL_CODE 
			INNER JOIN DIVISION D ON JL.CL_CODE = D.CL_CODE AND JL.DIV_CODE = D.DIV_CODE
			INNER JOIN PRODUCT P ON JL.CL_CODE = P.CL_CODE AND JL.DIV_CODE = P.DIV_CODE AND JL.PRD_CODE = P.PRD_CODE
		WHERE
			JL.JOB_NUMBER = @JOB_NUMBER;

		SELECT
			@JobDisplay = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), @JobNumber), 6) + ' - ' + @JobDescription,
			@ClientDisplay = @ClientCode + ' - ' + @ClientName,
			@DivisionDisplay = @DivisionCode + ' - ' + @DivisionName,
			@ProductDisplay = @ProductCode + ' - ' + @ProductName

	END
	IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0 
	BEGIN

		SELECT
			@JobComponentNumber = JC.JOB_COMPONENT_NBR,
			@JobComponentDescription = JC.JOB_COMP_DESC
		FROM
			JOB_COMPONENT JC
		WHERE
			JC.JOB_NUMBER = @JOB_NUMBER
			AND JC.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;

		SELECT
			@JobComponentDisplay = RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), @JobComponentNumber), 2)  + ' - ' + @JobComponentDescription,
			@JobAndComponentDisplay = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), @JobNumber), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), @JobComponentNumber), 2)  + ' - ' + @JobComponentDescription

	END

	SELECT
		ISNULL(@JobNumber, 0) AS JobNumber,
		ISNULL(@JobComponentNumber, 0) AS JobComponentNumber,
		ISNULL(@ClientCode, '') AS ClientCode,
		ISNULL(@ClientName, '') AS ClientName,
		ISNULL(@ClientDisplay, '') AS ClientDisplay,
		ISNULL(@DivisionCode, '') AS DivisionCode,
		ISNULL(@DivisionName, '') AS DivisionName,
		ISNULL(@DivisionDisplay, '') AS DivisionDisplay,
		ISNULL(@ProductCode, '') AS ProductCode,
		ISNULL(@ProductName, '') AS ProductName,
		ISNULL(@ProductDisplay, '') AS ProductDisplay,
		ISNULL(@JobDescription, '') AS JobDescription,
		ISNULL(@JobComponentDescription, '') AS JobComponentDescription,
		ISNULL(@JobDisplay, '') AS JobDisplay,
		ISNULL(@JobComponentDisplay, '') AS JobComponentDisplay,
		ISNULL(@JobAndComponentDisplay, '') AS JobAndComponentDisplay;


END