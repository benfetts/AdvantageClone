/**  Haversine Formula #1 **/
CREATE FUNCTION [dbo].[advfn_calculate_distance]
	(
	@LATITUDE1   FLOAT,
	@LONGITUDE1 FLOAT, 
	@LATITUDE2   FLOAT,
	@LONGITUDE2  FLOAT,
	@RETURNTYPE VARCHAR(10)
	)
RETURNS FLOAT

AS

BEGIN
	DECLARE @TEMP FLOAT
	DECLARE @EARTHRADIUSINMILES FLOAT, @RADIANSCALC FLOAT

   SET @EARTHRADIUSINMILES = 
            CASE @RETURNTYPE 
				WHEN 'MILES' THEN 3958.75586574 --3956.55 
				WHEN 'KILOMETERS' THEN 6367.45
				WHEN 'FEET' THEN 20890584
				WHEN 'METERS' THEN 6367450
				ELSE 3958.75586574 -- DEFAULT MILES
            END
	SET @RADIANSCALC = 57.2957795130823  --57.2957795130823

	SET @TEMP = SIN(@LATITUDE1/@RADIANSCALC) * SIN(@LATITUDE2/@RADIANSCALC) 
			+ COS(@LATITUDE1/@RADIANSCALC) * COS(@LATITUDE2/@RADIANSCALC) * COS(@LONGITUDE2/@RADIANSCALC - @LONGITUDE1/@RADIANSCALC)

	IF @TEMP > 1 
		SET @TEMP = 1
	ELSE IF @TEMP < -1
		SET @TEMP = -1

	RETURN  ROUND(@EARTHRADIUSINMILES * ACOS(@TEMP), 4)
END

GO