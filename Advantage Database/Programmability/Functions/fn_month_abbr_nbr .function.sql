
CREATE FUNCTION [dbo].[fn_month_abbr_nbr ] ( @month_abbr varchar(3) )
RETURNS tinyint
AS
BEGIN
	DECLARE @month_nbr tinyint

	SELECT @month_nbr =
		CASE @month_abbr
			WHEN 'JAN' THEN 1
			WHEN 'FEB' THEN 2
			WHEN 'MAR' THEN 3
			WHEN 'APR' THEN 4
			WHEN 'MAY' THEN 5
			WHEN 'JUN' THEN 6
			WHEN 'JUL' THEN 7
			WHEN 'AUG' THEN 8
			WHEN 'SEP' THEN 9
			WHEN 'OCT' THEN 10
			WHEN 'NOV' THEN 11
			WHEN 'DEC' THEN 12
		END
	
	RETURN @month_nbr

END
