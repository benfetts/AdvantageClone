CREATE FUNCTION [dbo].[advfn_nielsen_ignore_intab_check](
	@NIELSEN_RADIO_QUALITATIVE_ID int,
	@NIELSEN_RADIO_REPORT_TYPE_CODE varchar(2),
	@STANDARD_CONDENSED_INDICATOR char(1),
	@MIN_AGE smallint,
	@MAX_AGE smallint
)
RETURNS smallint
AS
BEGIN

	DECLARE @result smallint

	IF @NIELSEN_RADIO_QUALITATIVE_ID = 1 BEGIN
		IF @NIELSEN_RADIO_REPORT_TYPE_CODE IN ('1','5') AND @STANDARD_CONDENSED_INDICATOR = 'S' BEGIN
			IF @MIN_AGE = 12 AND @MAX_AGE = 17 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 34 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 44 SET @result = 1
			IF @MIN_AGE = 45 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 50 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 55 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 65 AND @MAX_AGE = 99 SET @result = 1
		END ELSE IF @NIELSEN_RADIO_REPORT_TYPE_CODE = '5' AND @STANDARD_CONDENSED_INDICATOR = 'C' BEGIN
			IF @MIN_AGE = 6 AND @MAX_AGE = 11 SET @result = 1
		END ELSE IF @NIELSEN_RADIO_REPORT_TYPE_CODE IN ('1','5') AND @STANDARD_CONDENSED_INDICATOR = 'C' BEGIN
			IF @MIN_AGE = 12 AND @MAX_AGE = 34 SET @result = 1
			IF @MIN_AGE = 12 AND @MAX_AGE = 44 SET @result = 1
			IF @MIN_AGE = 12 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 12 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 12 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 12 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 34 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 44 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 21 AND @MAX_AGE = 44 SET @result = 1
			IF @MIN_AGE = 21 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 21 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 21 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 21 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 44 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 45 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 45 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 50 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 55 AND @MAX_AGE = 99 SET @result = 1
		END
	END ELSE IF @NIELSEN_RADIO_QUALITATIVE_ID > 1 BEGIN
		IF @NIELSEN_RADIO_REPORT_TYPE_CODE NOT IN ('1','5') AND @STANDARD_CONDENSED_INDICATOR = 'S' BEGIN
			IF @MIN_AGE = 18 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 64 SET @result = 1
		END ELSE IF @NIELSEN_RADIO_REPORT_TYPE_CODE NOT IN ('1','5') AND @STANDARD_CONDENSED_INDICATOR = 'C' BEGIN
			IF @MIN_AGE = 18 AND @MAX_AGE = 34 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 49 SET @result = 1
			IF @MIN_AGE = 18 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 54 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 25 AND @MAX_AGE = 99 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 64 SET @result = 1
			IF @MIN_AGE = 35 AND @MAX_AGE = 99 SET @result = 1
		END
	END

	RETURN @result
END
GO

GRANT EXEC ON [advfn_nielsen_ignore_intab_check] TO PUBLIC
GO
