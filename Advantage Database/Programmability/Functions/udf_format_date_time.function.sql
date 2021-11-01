

CREATE FUNCTION [dbo].[udf_format_date_time]
(
	@dt      DATETIME,
	@format  VARCHAR(16)
)
RETURNS VARCHAR(64)
AS
BEGIN
	DECLARE @dtVC VARCHAR(64) 
	SELECT @dtVC = CASE @format
	                    WHEN 'LONGDATE' THEN DATENAME(dw, @dt) 
	                         + ',' + SPACE(1) + DATENAME(m, @dt) 
	                         + SPACE(1) + CAST(DAY(@dt) AS VARCHAR(2)) 
	                         + ',' + SPACE(1) + CAST(YEAR(@dt) AS CHAR(4))
	                    WHEN 'LONGDATEANDTIME' THEN DATENAME(dw, @dt) 
	                         + ',' + SPACE(1) + DATENAME(m, @dt) 
	                         + SPACE(1) + CAST(DAY(@dt) AS VARCHAR(2)) 
	                         + ',' + SPACE(1) + CAST(YEAR(@dt) AS CHAR(4)) 
	                         + SPACE(1) + RIGHT(
	                             CONVERT(
	                                 CHAR(20),
	                                 @dt - CONVERT(DATETIME, CONVERT(CHAR(8), @dt, 112)),
	                                 22
	                             ),
	                             11
	                         )
	                    WHEN 'SHORTDATE' THEN LEFT(CONVERT(CHAR(19), @dt, 0), 11)
	                    WHEN 'SHORTDATEANDTIME' THEN REPLACE(
	                             REPLACE(CONVERT(CHAR(19), @dt, 0), 'AM', ' AM'),
	                             'PM',
	                             ' PM'
	                         )
	                    WHEN 'UNIXTIMESTAMP' THEN CAST(DATEDIFF(SECOND, '19700101', @dt) AS VARCHAR(64))
	                    WHEN 'YYYYMMDD' THEN CONVERT(CHAR(8), @dt, 112)
	                    WHEN 'YYYY-MM-DD' THEN CONVERT(CHAR(10), @dt, 23)
	                    WHEN 'YYMMDD' THEN CONVERT(VARCHAR(8), @dt, 12)
	                    WHEN 'YY-MM-DD' THEN STUFF(STUFF(CONVERT(VARCHAR(8), @dt, 12), 5, 0, '-'), 3, 0, '-')
	                    WHEN 'MMDDYY' THEN REPLACE(CONVERT(CHAR(8), @dt, 10), '-', SPACE(0))
	                    WHEN 'MM-DD-YY' THEN CONVERT(CHAR(8), @dt, 10)
	                    WHEN 'MM/DD/YY' THEN CONVERT(CHAR(8), @dt, 1)
	                    WHEN 'MM/DD/YYYY' THEN CONVERT(CHAR(10), @dt, 101)
	                    WHEN 'DDMMYY' THEN REPLACE(CONVERT(CHAR(8), @dt, 3), '/', SPACE(0))
	                    WHEN 'DD-MM-YY' THEN REPLACE(CONVERT(CHAR(8), @dt, 3), '/', '-')
	                    WHEN 'DD/MM/YY' THEN CONVERT(CHAR(8), @dt, 3)
	                    WHEN 'DD/MM/YYYY' THEN CONVERT(CHAR(10), @dt, 103)
	                    WHEN 'HH:MM:SS 24' THEN CONVERT(CHAR(8), @dt, 8)
	                    WHEN 'HH:MM 24' THEN LEFT(CONVERT(VARCHAR(8), @dt, 8), 5)
	                    WHEN 'HH:MM:SS 12' THEN LTRIM(RIGHT(CONVERT(VARCHAR(20), @dt, 22), 11))
	                    WHEN 'HH:MM 12' THEN LTRIM(
	                             SUBSTRING(CONVERT(VARCHAR(20), @dt, 22), 10, 5) 
	                             + RIGHT(CONVERT(VARCHAR(20), @dt, 22), 3)
	                         )
	                    ELSE 'Invalid format specified'
	               END
	
	RETURN @dtVC
END
