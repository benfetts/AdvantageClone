
CREATE FUNCTION [dbo].[advfn_date_to_post_period] ( @date smalldatetime )
RETURNS varchar(6)
AS
BEGIN
	DECLARE @post_period varchar(6)
	DECLARE @period_temp AS int	

SET @post_period =	
	(SELECT TOP 1 a.PPPERIOD
	FROM dbo.POSTPERIOD AS a
	WHERE a.PPSRTDATE > @date)
	
SET @period_temp = CAST(@post_period AS int) - 1

SET @post_period = 
	CASE
		WHEN @period_temp % 100 <> 0 THEN CAST(@period_temp AS varchar)
		ELSE CAST((CEILING(@period_temp / 100)- 1) * 100 + 12 AS varchar)
	END
	
	RETURN @post_period
END
