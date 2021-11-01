
CREATE FUNCTION dbo.wvfn_timestring
(
	@INPUT AS datetime = NULL
)

RETURNS varchar(20)
AS
BEGIN


RETURN
     CONVERT(varchar(2),
          CASE
               WHEN DATEPART([hour], @INPUT) > 12 THEN CONVERT(varchar(2), (DATEPART([hour], @INPUT) - 12))
               WHEN DATEPART([hour], @INPUT) = 0 THEN '12'
               ELSE CONVERT(varchar(2), DATEPART([hour], @INPUT))
          END
     ) + ':' +
     CONVERT(char(2), SUBSTRING(CONVERT(char(5), @INPUT, 108), 4, 2)) + ' ' + 
     CONVERT(varchar(2),
          CASE
               WHEN DATEPART([hour], @INPUT) >= 12 THEN 'PM'
               ELSE 'AM'
          END
     )

END

