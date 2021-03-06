CREATE PROCEDURE [dbo].[advsp_hosted_spotradio_nielsen_get_county_years]
	@CLIENT_CODE varchar(6), @COUNTY_CODE int--, @WEIGHTING_FLAG varchar(1)
AS
BEGIN
	SELECT DISTINCT 
		[Year] = nrcp.[YEAR]
	FROM dbo.CLIENT c
		INNER JOIN dbo.CLIENT_ORDER co ON c.CLIENT_ID = co.CLIENT_ID AND co.IS_SUSPENDED = 0 AND co.ALL_STATES = 0
		INNER JOIN dbo.CLIENT_ORDER_STATE com ON co.CLIENT_ORDER_ID = com.CLIENT_ORDER_ID
		INNER JOIN dbo.NIELSEN_RADIO_COUNTY_PERIOD nrcp ON nrcp.[STATE] = com.[STATE] AND co.END_YEAR = nrcp.[YEAR] 
	WHERE co.ORDER_TYPE = 'C'
	AND c.CODE = @CLIENT_CODE
	AND nrcp.COUNTY_CODE = @COUNTY_CODE
	--AND nrcp.WEIGHTING_FLAG = @WEIGHTING_FLAG

	UNION

	SELECT
		[Year] = nrcp.[YEAR]
	FROM dbo.NIELSEN_RADIO_COUNTY_PERIOD nrcp
	WHERE nrcp.COUNTY_CODE = @COUNTY_CODE
	--AND nrcp.WEIGHTING_FLAG = @WEIGHTING_FLAG
	AND EXISTS (
		SELECT 1
		FROM dbo.CLIENT c
			INNER JOIN dbo.CLIENT_ORDER co ON c.CLIENT_ID = co.CLIENT_ID AND co.IS_SUSPENDED = 0 AND co.ALL_STATES = 1
			INNER JOIN dbo.NIELSEN_RADIO_COUNTY_PERIOD nrcp ON co.END_YEAR = nrcp.[YEAR] 
		WHERE co.ORDER_TYPE = 'C'
		AND c.CODE = @CLIENT_CODE)
END
GO
