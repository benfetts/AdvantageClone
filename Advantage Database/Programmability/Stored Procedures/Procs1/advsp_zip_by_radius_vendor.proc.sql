IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_zip_by_radius_vendor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_zip_by_radius_vendor]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
********************************************************************************************************

********************************************************************************************************
*/

/*
*********************** Tasks to Do ***********************************************************************
 --UPDATE ZIP_CODE_RADIUS SET LATITUDE = LATITUDE + 56, LONGITUDE = LONGITUDE - 56 /* SET */
 --UPDATE ZIP_CODE_RADIUS SET LATITUDE = LATITUDE - 56, LONGITUDE = LONGITUDE + 56 /* RESET */
*********************************************************************************************************
*/

CREATE PROCEDURE [dbo].[advsp_zip_by_radius_vendor] 
	@zip_in nvarchar(5),
	@max_distance DEC (14,2),
	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT
AS

DECLARE
	@Longitude1 FLOAT, 
	@Latitude1   FLOAT

DECLARE 
	@ErMessage nvarchar(2048), 
	@ErSeverity int, 
	@ErState int

BEGIN TRY

SELECT @ret_val = 0, @ret_val_s = 'Success'

SELECT @Longitude1 = LONGITUDE, @Latitude1 = LATITUDE FROM ZIP_CODE_RADIUS WHERE ZIP_CODE = @zip_in

--SELECT ROUND(DISTANCE,0) MILES, ZIP_CODE , CITY_NAME, STATE_ABBR   FROM (
--SELECT [dbo].[advfn_calculate_distance] (@Longitude1, @Latitude1, LONGITUDE, LATITUDE ) DISTANCE, ZIP_CODE , CITY_NAME, STATE_ABBR  
--FROM ZIP_CODE_RADIUS
--WHERE [dbo].[advfn_calculate_distance] (
--	@Longitude1,
--	@Latitude1,
--	LONGITUDE,
--	LATITUDE ) < @max_distance
--) B ORDER BY 1, 2, 3

SELECT DISTINCT ROUND(DISTANCE,0) MILES, ZIP_CODE, STATE_ABBR FROM (
SELECT [dbo].[advfn_calculate_distance] (@Latitude1, @Longitude1, LATITUDE, LONGITUDE, 'MILES' ) + 0 DISTANCE, ZIP_CODE, STATE_ABBR 
	FROM ZIP_CODE_RADIUS
	WHERE ([dbo].[advfn_calculate_distance] (@Latitude1, @Longitude1, LATITUDE, LONGITUDE, 'MILES' ) + 0) < @max_distance
) B 
JOIN VENDOR ON VN_ZIP = B.ZIP_CODE 
WHERE VN_ACTIVE_FLAG = 1

	   
END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		SELECT 'PROCESS ERROR ROLLBACK', @@TRANCOUNT '@@TRANCOUNT'  /* DEBUG */	
		ROLLBACK TRAN --TP1
	END
	
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE(),
					@ret_val=ERROR_NUMBER();
					
	SET @ret_val_s = @ErMessage
	
	SELECT 	@ret_val 'ERROR_NBR', @ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */	

END CATCH

RETURN