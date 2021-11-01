SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_User_Get_Menu_Handle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_User_Get_Menu_Handle]
GO



























CREATE PROCEDURE [dbo].[usp_wv_User_Get_Menu_Handle] 
@UserID VarChar(100), 
@MenuHandle Numeric OUTPUT
AS
SELECT @MenuHandle = IsNull(MENU_HWND, 0)
FROM SEC_USER 
Where UPPER(USER_CODE) = UPPER(@UserID)


























GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

