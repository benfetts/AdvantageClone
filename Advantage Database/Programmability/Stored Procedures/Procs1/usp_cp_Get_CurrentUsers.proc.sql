









------------------------------------------------------------------------------------------------
-- Gets the currently Logged In users for Client Portal
---------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_cp_Get_CurrentUsers] 
@LoggedCPUsers INT OUTPUT

AS

SET NOCOUNT ON

SELECT @LoggedCPUsers = Count(WEB_ID)
FROM CP_USER























