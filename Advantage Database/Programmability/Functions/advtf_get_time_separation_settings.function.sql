CREATE FUNCTION [dbo].[advtf_get_time_separation_settings] (
	@BRDCAST_DTL_VERIFICATION_SETTING_ID int,
	@MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID int
)
RETURNS @time_settings TABLE (
	TIME_LENGTH int,
	TIME_SEPARATION int
)
AS
BEGIN

	IF @BRDCAST_DTL_VERIFICATION_SETTING_ID IS NOT NULL 
		IF (SELECT COUNT(1) FROM dbo.TIME_SEPARATION_SETTING WHERE BRDCAST_DTL_VERIFICATION_SETTING_ID = @BRDCAST_DTL_VERIFICATION_SETTING_ID AND CROSS_LENGTH_SEPARATION_ENABLED = 1) = 1
			INSERT INTO @time_settings (TIME_LENGTH, TIME_SEPARATION)
			SELECT NULL, CROSS_LENGTH_SEPARATION_VALUE 
			FROM dbo.TIME_SEPARATION_SETTING 
			WHERE BRDCAST_DTL_VERIFICATION_SETTING_ID = @BRDCAST_DTL_VERIFICATION_SETTING_ID
		ELSE
			INSERT INTO @time_settings (TIME_LENGTH, TIME_SEPARATION)
			SELECT TIME_LENGTH, TIME_SEPARATION
			FROM dbo.TIME_SEPARATION_SETTING 
			WHERE BRDCAST_DTL_VERIFICATION_SETTING_ID = @BRDCAST_DTL_VERIFICATION_SETTING_ID
	ELSE IF @MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID IS NOT NULL 
		IF (SELECT COUNT(1) FROM dbo.MEDIA_BROADCAST_WORKSHEET_TIME_SEPARATION_SETTING WHERE MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID = @MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID AND CROSS_LENGTH_SEPARATION_ENABLED = 1) = 1
			INSERT INTO @time_settings (TIME_LENGTH, TIME_SEPARATION)
			SELECT NULL, CROSS_LENGTH_SEPARATION_VALUE 
			FROM dbo.MEDIA_BROADCAST_WORKSHEET_TIME_SEPARATION_SETTING 
			WHERE MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID = @MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID
		ELSE
			INSERT INTO @time_settings (TIME_LENGTH, TIME_SEPARATION)
			SELECT TIME_LENGTH, TIME_SEPARATION
			FROM dbo.MEDIA_BROADCAST_WORKSHEET_TIME_SEPARATION_SETTING 
			WHERE MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID = @MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID
	RETURN

END
GO
