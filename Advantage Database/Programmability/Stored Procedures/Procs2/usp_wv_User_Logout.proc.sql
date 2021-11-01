SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_User_Logout]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_User_Logout]
GO



























CREATE PROCEDURE [dbo].[usp_wv_User_Logout] 
@UserID VarChar(100)
AS

Update SEC_USER
Set WEB_ID = NULL
Where UPPER(USER_CODE) = UPPER(@UserID)

























GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

