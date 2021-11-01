CREATE PROCEDURE [dbo].[usp_wv_ts_check_postperiod] 
@ThisDate as DateTime,
@Return as Integer OUTPUT
AS
BEGIN
	DECLARE
		@PostPeriod INT;

	SELECT @PostPeriod = TS_PPERIOD_CHK FROM AGENCY WITH(NOLOCK);

	IF NOT @ThisDate IS NULL
	BEGIN
		SELECT @ThisDate = CAST(CONVERT(VARCHAR, @ThisDate, 1) AS SMALLDATETIME);
	END
	IF @PostPeriod = 1 -- ZERO IS CLOSED, 
	BEGIN
		SELECT 
		   @Return = COUNT(1) 
		FROM 
		   POSTPERIOD WITH (NOLOCK)
		WHERE	
		   PPSRTDATE <= @ThisDate
		   AND	PPENDDATE >= @ThisDate
		   AND (PPTECURMTH = 'C' OR PPTECURMTH IS NULL);
	END
	ELSE
	BEGIN
		SET @Return = 1;
	END
END