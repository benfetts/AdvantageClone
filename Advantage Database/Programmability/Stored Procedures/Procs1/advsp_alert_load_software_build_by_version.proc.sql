IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_load_software_build_by_version]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_load_software_build_by_version]
GO
CREATE PROCEDURE [dbo].[advsp_alert_load_software_build_by_version] 
@VERSION_ID INT
AS
BEGIN

	SELECT DISTINCT
		[ID] = SB.BUILD_ID,
		[VersionID] = SB.VERSION_ID,
		[Name] = SB.BUILD,
		[Description] = SB.BUILD_DESC,
		[IsActive] = CAST(ISNULL(SB.ACTIVE_FLAG, 0) AS BIT)
	FROM
		SOFTWARE_BUILD SB WITH(NOLOCK)
	WHERE
		SB.ACTIVE_FLAG = 1
		AND SB.VERSION_ID = @VERSION_ID
	ORDER BY
		SB.BUILD;

END