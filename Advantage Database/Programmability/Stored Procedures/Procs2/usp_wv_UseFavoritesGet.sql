SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_UseFavoritesGet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_UseFavoritesGet]
GO

CREATE PROCEDURE [dbo].[usp_wv_UseFavoritesGet] /*WITH ENCRYPTION*/
@USER_CODE VARCHAR(100),
@WORKSPACE_ID INT
AS
/*=========== QUERY ===========*/
	SELECT     
		WV_USER_QUICK_LAUNCH_APPS.USERID AS USER_CODE, 
		WV_USER_QUICK_LAUNCH_APPS.TABNO AS WORKSPACE_ID, 
		WV_USER_QUICK_LAUNCH_APPS.APPID AS USER_FAVORITE_MODUE_ID, 
		SEC_MODULE.[DESCRIPTION], 
		CASE
			WHEN IS_APPLICATION = 1 THEN WV_URL
			WHEN IS_REPORT = 1 THEN WV_RPT_URL
			ELSE ''
		END AS [URL],
		WV_USER_QUICK_LAUNCH_APPS.[HEIGHT], 
		WV_USER_QUICK_LAUNCH_APPS.[WIDTH], 
		WV_USER_QUICK_LAUNCH_APPS.TOP_COORD, 
		WV_USER_QUICK_LAUNCH_APPS.LEFT_COORD
	FROM         
		WV_USER_QUICK_LAUNCH_APPS WITH(NOLOCK) INNER JOIN
		SEC_MODULE WITH(NOLOCK) ON WV_USER_QUICK_LAUNCH_APPS.APPID = SEC_MODULE.SEC_MODULE_ID INNER JOIN
		SEC_MODULE_INFO WITH(NOLOCK) ON SEC_MODULE.SEC_MODULE_INFO_ID = SEC_MODULE_INFO.SEC_MODULE_INFO_ID
	WHERE
		USERID = @USER_CODE
		AND TABNO = @WORKSPACE_ID
		AND (IS_INACTIVE = 0 OR IS_INACTIVE IS NULL);                      
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO