CREATE FUNCTION [dbo].[advfn_nielsen_radio_county_rowcount_by_period](
	@NIELSEN_RADIO_COUNTY_PERIOD_ID int
)
RETURNS bigint
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @totalrows bigint
	
	SELECT @totalrows = COALESCE(COUNT(1), 0)
	FROM dbo.NIELSEN_RADIO_COUNTY_AUDIENCE
	WHERE NIELSEN_RADIO_COUNTY_PERIOD_ID = @NIELSEN_RADIO_COUNTY_PERIOD_ID
	
	SELECT @totalrows = @totalrows + COALESCE(COUNT(1), 0)
	FROM dbo.NIELSEN_RADIO_COUNTY_CLUSTER
	WHERE NIELSEN_RADIO_COUNTY_PERIOD_ID = @NIELSEN_RADIO_COUNTY_PERIOD_ID
	
	SELECT @totalrows = @totalrows + COALESCE(COUNT(1), 0)
	FROM dbo.NIELSEN_RADIO_COUNTY_INTAB
	WHERE NIELSEN_RADIO_COUNTY_PERIOD_ID = @NIELSEN_RADIO_COUNTY_PERIOD_ID
		
	SELECT @totalrows = @totalrows + COALESCE(COUNT(1), 0)
	FROM dbo.NIELSEN_RADIO_COUNTY_UNIVERSE
	WHERE NIELSEN_RADIO_COUNTY_PERIOD_ID = @NIELSEN_RADIO_COUNTY_PERIOD_ID
		
	SELECT @totalrows = @totalrows + COALESCE(COUNT(1), 0)
	FROM dbo.NIELSEN_RADIO_COUNTY_STATION
	WHERE [YEAR] = (SELECT [YEAR] FROM dbo.NIELSEN_RADIO_COUNTY_PERIOD WHERE NIELSEN_RADIO_COUNTY_PERIOD_ID = @NIELSEN_RADIO_COUNTY_PERIOD_ID)

	RETURN @totalrows
END
GO

GRANT EXEC ON [advfn_nielsen_radio_county_rowcount_by_period] TO PUBLIC
GO
