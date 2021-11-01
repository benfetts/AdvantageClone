CREATE FUNCTION [dbo].[advfn_spot_separation_policy](
	@OrderNumber int,
	@MediaType char(1)
)
RETURNS varchar(max)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @separation varchar(max),
			@setting_id int
	
	IF @MediaType = 'R' BEGIN
		SELECT @setting_id = SETTING_ID FROM dbo.BRDCAST_DTL_VERIFICATION_SETTING WHERE MEDIA_TYPE_CODE = 'R' AND CL_CODE = (SELECT CL_CODE FROM dbo.RADIO_HDR WHERE ORDER_NBR = @OrderNumber)
		IF @setting_id IS NULL
			SELECT @setting_id = SETTING_ID FROM dbo.BRDCAST_DTL_VERIFICATION_SETTING WHERE MEDIA_TYPE_CODE = 'R' AND NULLIF(CL_CODE,'') IS NULL

		SELECT @separation = COALESCE(@separation + ',', '') + ' Length ' + CAST(tss.TIME_LENGTH as varchar) + ' / ' + CAST(tss.TIME_SEPARATION as varchar) + ' min'
		FROM dbo.RADIO_HDR h
			LEFT OUTER JOIN dbo.TIME_SEPARATION_SETTING tss ON tss.BRDCAST_DTL_VERIFICATION_SETTING_ID = @setting_id
		WHERE ORDER_NBR = @OrderNumber
	END ELSE BEGIN
		SELECT @setting_id = SETTING_ID FROM dbo.BRDCAST_DTL_VERIFICATION_SETTING WHERE MEDIA_TYPE_CODE = 'T' AND CL_CODE = (SELECT CL_CODE FROM dbo.TV_HDR WHERE ORDER_NBR = @OrderNumber)
		IF @setting_id IS NULL
			SELECT @setting_id = SETTING_ID FROM dbo.BRDCAST_DTL_VERIFICATION_SETTING WHERE MEDIA_TYPE_CODE = 'T' AND NULLIF(CL_CODE,'') IS NULL

		SELECT @separation = COALESCE(@separation + ',', '') + ' Length ' + CAST(tss.TIME_LENGTH as varchar) + ' / ' + CAST(tss.TIME_SEPARATION as varchar) + ' min'
		FROM dbo.TV_HDR h
			LEFT OUTER JOIN dbo.TIME_SEPARATION_SETTING tss ON tss.BRDCAST_DTL_VERIFICATION_SETTING_ID = @setting_id
		WHERE ORDER_NBR = @OrderNumber
	END
	-- Spot Separation:  Length 15 / 20 min., Length 30 / 30 min
	RETURN LTRIM(@separation)
END
