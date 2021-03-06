SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_cp_UseFavoritesGet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_cp_UseFavoritesGet]
GO

CREATE PROCEDURE [dbo].[usp_cp_UseFavoritesGet] /*WITH ENCRYPTION*/
@CPID INT,
@WORKSPACE_ID INT
AS
/*=========== QUERY ===========*/
	SELECT     
		CP_USER_QUICK_LAUNCH_APPS.CDP_CONTACT_ID AS USER_CODE, 
		CP_USER_QUICK_LAUNCH_APPS.TAB_ID AS WORKSPACE_ID, 
		CP_USER_QUICK_LAUNCH_APPS.APPLICATION_ID AS USER_FAVORITE_MODUE_ID, 
		SEC_MODULE.[DESCRIPTION], 
		CASE
			WHEN IS_APPLICATION = 1 THEN WV_URL
			WHEN IS_REPORT = 1 THEN WV_RPT_URL
			ELSE ''
		END AS [URL],
		CP_USER_QUICK_LAUNCH_APPS.[HEIGHT], 
		CP_USER_QUICK_LAUNCH_APPS.[WIDTH], 
		CP_USER_QUICK_LAUNCH_APPS.TOP_COORD, 
		CP_USER_QUICK_LAUNCH_APPS.LEFT_COORD
	FROM         
		CP_USER_QUICK_LAUNCH_APPS WITH(NOLOCK) INNER JOIN
		SEC_MODULE WITH(NOLOCK) ON CP_USER_QUICK_LAUNCH_APPS.APPLICATION_ID = SEC_MODULE.SEC_MODULE_ID INNER JOIN
		SEC_MODULE_INFO WITH(NOLOCK) ON SEC_MODULE.SEC_MODULE_INFO_ID = SEC_MODULE_INFO.SEC_MODULE_INFO_ID
	WHERE
		CDP_CONTACT_ID = @CPID
		AND TAB_ID = @WORKSPACE_ID
		AND (IS_INACTIVE = 0 OR IS_INACTIVE IS NULL);                      
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO