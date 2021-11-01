









------------------------------------------------------------------------------------------------
-- Gets the Logo Path for Client Portal
---------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_cp_getLogoPath] 
@CDPCode int

AS

SET NOCOUNT ON

SELECT ISNULL(LOGO_PATH, '') AS LOGO_PATH 
FROM CP_LOGO























