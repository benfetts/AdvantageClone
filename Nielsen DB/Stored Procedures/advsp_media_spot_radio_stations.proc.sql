CREATE PROCEDURE [dbo].[advsp_media_spot_radio_stations]
	@NIELSEN_RADIO_MARKET_NUMBER int,	
	@NIELSEN_RADIO_STATION_IDs varchar(max)
AS 
BEGIN
	
	SELECT
		[NielsenRadioStationID] = s.NIELSEN_RADIO_STATION_ID,
		[ComboID] = s.COMBO_ID,
        [Name] = s.[NAME],
        [CallLetters] = s.CALL_LETTERS,
        [Band] = s.BAND,
        [Frequency] = s.FREQUENCY,
		IsSelected = CAST(CASE WHEN IDs.items IS NULL THEN 0 ELSE 1 END as bit),
		[Format] = f.[NAME]
	FROM dbo.NIELSEN_RADIO_STATION s
		LEFT OUTER JOIN (SELECT items FROM dbo.udf_split_list(@NIELSEN_RADIO_STATION_IDs, ',')) IDs ON s.NIELSEN_RADIO_STATION_ID = IDs.items
		LEFT OUTER JOIN dbo.NIELSEN_RADIO_FORMAT f ON s.NIELSEN_RADIO_FORMAT_CODE = f.CODE
	WHERE NIELSEN_RADIO_MARKET_NUMBER = @NIELSEN_RADIO_MARKET_NUMBER

END
GO

GRANT EXEC ON [advsp_media_spot_radio_stations] TO PUBLIC
GO