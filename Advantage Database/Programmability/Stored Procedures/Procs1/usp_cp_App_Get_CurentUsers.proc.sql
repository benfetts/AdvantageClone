






















---------------------------------------------------------------------------------------------------
-- Gets the currently Logged In users
---------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_cp_App_Get_CurentUsers] 
@LoggedCPUsers INT OUTPUT,
@DatabaseVersion VARCHAR(50) OUTPUT,
@ADvantageDatabaseVersion VARCHAR(50) OUTPUT,
@LastAdvantageUpdate VARCHAR(50) OUTPUT,
@LastWebvantageUpdate VARCHAR(50) OUTPUT
AS

--SET NOCOUNT ON


SELECT @LoggedCPUsers = COUNT(WEB_ID)
FROM CP_USER

SELECT @DatabaseVersion = '2.0' --WEBVAN_VERSION_ID FROM ADVAN_UPDATE

SELECT @ADvantageDatabaseVersion = VERSION_ID, @LastAdvantageUpdate = DB_UPDATE FROM ADVAN_UPDATE

SELECT     @LastWebvantageUpdate = MAX(DATE_APPLIED) 
FROM         DB_UPDATE
WHERE     (DESCRIPTION LIKE '%Webvantage%')






















