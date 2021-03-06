SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_App_Get_CurentUsers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_App_Get_CurentUsers]
GO























---------------------------------------------------------------------------------------------------
-- Gets the currently Logged In users
---------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_wv_App_Get_CurentUsers] 
@LoggedWebUsers INT OUTPUT,
@LoggedPowerUsers INT OUTPUT,
@DatabaseVersion VARCHAR(50) OUTPUT,
@ADvantageDatabaseVersion VARCHAR(50) OUTPUT,
@LastAdvantageUpdate VARCHAR(50) OUTPUT,
@LastWebvantageUpdate VARCHAR(50) OUTPUT
AS

--SET NOCOUNT ON

--SELECT @LoggedWebUsers = COUNT(WEB_ID) + COUNT(MENU_HWND)
--FROM SEC_USER
--WHERE USER_CODE IN (SELECT U.USER_CODE FROM dbo.SEC_USER U INNER JOIN dbo.SEC_USER_SETTING US ON U.SEC_USER_ID = US.SEC_USER_ID WHERE US.SETTING_CODE = 'TIME_ENTRY_ONLY' AND US.STRING_VALUE = 'Y')

SELECT @LoggedWebUsers = COUNT(*)
  FROM dbo.SEC_USER su
 WHERE ( su.WEB_ID IS NOT NULL OR su.TIME_HWND IS NOT NULL )
   AND EXISTS ( SELECT * 
                  FROM dbo.SEC_USER_SETTING sus 
                 WHERE sus.SEC_USER_ID = su.SEC_USER_ID 
				   AND sus.SETTING_CODE = 'TIME_ENTRY_ONLY' 
				   AND sus.STRING_VALUE = 'Y' )
					   
--SELECT @LoggedPowerUsers = COUNT(WEB_ID) + COUNT(MENU_HWND)
--FROM SEC_USER
--WHERE (TIME_ENTRY_ONLY <> 1
--OR TIME_ENTRY_ONLY IS NULL)

SELECT @LoggedPowerUsers = COUNT(*)
  FROM dbo.SEC_USER su
 WHERE ( su.WEB_ID IS NOT NULL OR su.MENU_HWND IS NOT NULL OR su.TIME_HWND IS NOT NULL )
   AND NOT EXISTS ( SELECT * 
                      FROM dbo.SEC_USER_SETTING sus 
                     WHERE sus.SEC_USER_ID = su.SEC_USER_ID 
					   AND sus.SETTING_CODE = 'TIME_ENTRY_ONLY' 
					   AND sus.STRING_VALUE = 'Y' )


SELECT @DatabaseVersion = WEBVAN_VERSION_ID FROM ADVAN_UPDATE

SELECT @ADvantageDatabaseVersion = VERSION_ID, @LastAdvantageUpdate = DB_UPDATE FROM ADVAN_UPDATE

	SELECT @LastWebvantageUpdate = ISNULL(MAX(DATE_APPLIED),GETDATE())
	FROM   DB_UPDATE
	WHERE  (DESCRIPTION LIKE '%Webvantage%')
	       OR (DESCRIPTION LIKE '%WV%')






















GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

