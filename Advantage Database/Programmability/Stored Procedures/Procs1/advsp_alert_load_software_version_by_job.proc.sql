IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_load_software_version_by_job]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_load_software_version_by_job]
GO
CREATE PROCEDURE [dbo].[advsp_alert_load_software_version_by_job] 
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@VERSION_ID INT
AS
BEGIN

	SET @VERSION_ID = ISNULL(@VERSION_ID, 0);

	SELECT DISTINCT
		[ID] = SV.VERSION_ID,
		[Name] = SV.[VERSION],
		[Description] = SV.VERSION_DESC,
		[IsActive] = CAST(ISNULL(SV.ACTIVE_FLAG, 0) AS BIT)
	FROM
		SOFTWARE_VERSION SV WITH(NOLOCK)
		INNER JOIN SOFTWARE_LEVEL SL WITH(NOLOCK) ON SV.VERSION_ID = SL.VERSION_ID
	WHERE
		(SV.ACTIVE_FLAG = 1
		AND (
				(SL.JOB_NUMBER = @JOB_NUMBER AND SL.JOB_COMPONENT_NBR IS NULL) 
				OR 
				(SL.JOB_NUMBER = @JOB_NUMBER AND SL.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
			))
		OR 1 = CASE WHEN @VERSION_ID > 0 AND SV.VERSION_ID = @VERSION_ID THEN 1
		       ELSE 0
			   END
	ORDER BY 
		SV.[VERSION];

END