﻿
CREATE FUNCTION dbo.wvfn_normalize_date
(
	@THE_DATE SMALLDATETIME,
	@THE_TIME SMALLDATETIME
)

RETURNS SMALLDATETIME
AS
BEGIN
	DECLARE @NORMALIZED SMALLDATETIME;
	
	SET @NORMALIZED = CONVERT(
	        DATETIME,
	        CONVERT(CHAR(10), DATEPART(yyyy, @THE_DATE), 101) 
	        +
	        '-' +
	        CONVERT(CHAR(10), DATEPART(mm, @THE_DATE), 101) +
	        '-' +
	        CONVERT(CHAR(10), DATEPART(dd, @THE_DATE), 101) +
	        ' ' +
	        CONVERT(CHAR(10), DATEPART(hh, @THE_TIME), 101) +
	        ':' +
	        CONVERT(CHAR(10), DATEPART(mi, @THE_TIME), 101) +
	        ':' +
	        CONVERT(CHAR(10), DATEPART(ss, @THE_TIME), 101)
	); 
	
	
	RETURN @NORMALIZED;
END

