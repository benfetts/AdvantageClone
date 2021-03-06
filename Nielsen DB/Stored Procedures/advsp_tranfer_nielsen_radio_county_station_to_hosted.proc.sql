CREATE PROC [dbo].[advsp_tranfer_nielsen_radio_county_station_to_hosted]
AS

BEGIN TRAN

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_RADIO_COUNTY_STATION ON

INSERT INTO NIELSENHOSTED.dbo.NIELSEN_RADIO_COUNTY_STATION ( NIELSEN_RADIO_COUNTY_STATION_ID, [YEAR], CALL_LETTERS, BAND, 
CITY_LICENSE, COUNTY_LICENSE, STATE_LICENSE, AFFILIATION, OTHER_AFFILIATIONS, FREQUENCY )
SELECT NIELSEN_RADIO_COUNTY_STATION_ID, [YEAR], CALL_LETTERS, BAND, 
CITY_LICENSE, COUNTY_LICENSE, STATE_LICENSE, AFFILIATION, OTHER_AFFILIATIONS, FREQUENCY
FROM NIELSENDATASTORE.dbo.NIELSEN_RADIO_COUNTY_STATION
WHERE NIELSEN_RADIO_COUNTY_STATION_ID NOT IN (SELECT NIELSEN_RADIO_COUNTY_STATION_ID FROM NIELSENHOSTED.dbo.NIELSEN_RADIO_COUNTY_STATION)

SET IDENTITY_INSERT NIELSENHOSTED.dbo.NIELSEN_RADIO_COUNTY_STATION OFF

COMMIT TRAN

GO
