CREATE PROCEDURE [dbo].[advsp_spotradiocounty_get_counties]
AS
BEGIN
	SELECT DISTINCT 
		[CountyCode] = nrcp.COUNTY_CODE,
		[Name] = nrcp.[NAME],
		[State] = nrcp.[STATE],
		[MarketNumber] = nrcp.NIELSEN_RADIO_MARKET_NUMBER,
		[MarketName] = nrm.[NAME] 
	FROM dbo.NIELSEN_RADIO_COUNTY_PERIOD nrcp
		INNER JOIN dbo.NIELSEN_RADIO_MARKET nrm ON nrcp.NIELSEN_RADIO_MARKET_NUMBER = nrm.NUMBER AND nrm.[SOURCE] = 2
	WHERE nrcp.VALIDATED = 1

END
GO
