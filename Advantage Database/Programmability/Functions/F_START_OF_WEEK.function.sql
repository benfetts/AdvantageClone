
CREATE FUNCTION dbo.F_START_OF_WEEK
(
	@DATE			DATETIME,
	-- Sun = 1, Mon = 2, Tue = 3, Wed = 4
	-- Thu = 5, Fri = 6, Sat = 7
	-- Default to Sunday
	@WEEK_START_DAY		INT	= 1	
)
/*
Find the fisrt date on or before @DATE that matches 
day of week of @WEEK_START_DAY.
*/
RETURNS		DATETIME
AS
BEGIN
DECLARE	 @START_OF_WEEK_DATE	DATETIME
DECLARE	 @FIRST_BOW		DATETIME

-- Check for valid day of week
IF @WEEK_START_DAY BETWEEN 1 AND 7
	BEGIN
	-- Find first day on or after 1753/1/1 (-53690)
	-- matching day of week of @WEEK_START_DAY
	-- 1753/1/1 is earliest possible SQL Server date.
	SELECT @FIRST_BOW = CONVERT(DATETIME,-53690+((@WEEK_START_DAY+5)%7))
	-- Verify beginning of week not before 1753/1/1
	IF @DATE >= @FIRST_BOW
		BEGIN
		SELECT @START_OF_WEEK_DATE = 
		DATEADD(dd,(DATEDIFF(dd,@FIRST_BOW,@DATE)/7)*7,@FIRST_BOW)
		END
	END

RETURN @START_OF_WEEK_DATE

END

