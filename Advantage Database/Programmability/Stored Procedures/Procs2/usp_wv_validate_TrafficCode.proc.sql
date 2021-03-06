--DROP PROCEDURE [dbo].[usp_wv_validate_TrafficCode] 
CREATE PROCEDURE [dbo].[usp_wv_validate_TrafficCode] 
@TRF_CODE VARCHAR(10),
@IS_UPDATE BIT

AS

IF @IS_UPDATE = 1
BEGIN
	SELECT 
		COUNT(1) 
	FROM 
		TRAFFIC 
	WHERE 
		TRF_CODE = @TRF_CODE 
END
ELSE
BEGIN
	SELECT 
		COUNT(1) 
	FROM 
		TRAFFIC 
	WHERE 
		TRF_CODE = @TRF_CODE 
		AND ((INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG = 0))
END
