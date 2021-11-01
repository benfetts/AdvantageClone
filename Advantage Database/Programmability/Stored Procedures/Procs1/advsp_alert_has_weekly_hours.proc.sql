IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_has_weekly_hours]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_has_weekly_hours]
GO
CREATE PROCEDURE [dbo].[advsp_alert_has_weekly_hours] 
@ALERT_ID INT
AS
BEGIN
	DECLARE 
		@HAS_WEEKLY_HRS BIT;
	IF EXISTS(SELECT 1 FROM SPRINT_EMPLOYEE WITH(NOLOCK) WHERE ALERT_ID = @ALERT_ID)
	BEGIN
		SET @HAS_WEEKLY_HRS = 1;
	END
	ELSE
	BEGIN
		SET @HAS_WEEKLY_HRS = 0;
	END
	SELECT CAST(ISNULL(@HAS_WEEKLY_HRS, 0) AS BIT);
END