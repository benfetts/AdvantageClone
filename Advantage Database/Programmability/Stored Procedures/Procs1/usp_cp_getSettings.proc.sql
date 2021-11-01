









------------------------------------------------------------------------------------------------
-- Gets the Settings for Client Portal
---------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_cp_getSettings] 

AS

SET NOCOUNT ON

SELECT ISNULL(WV_APPLICATION_FOLDER, '') AS WV_APPLICATION_FOLDER, ISNULL(CP_APPLICATION_FOLDER, '') AS CP_APPLICATION_FOLDER
FROM CP_SETTINGS























