SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_User_Get_WebID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_User_Get_WebID]
GO



























CREATE PROCEDURE [dbo].[usp_wv_User_Get_WebID] 
@UserID VARCHAR(100), 
@WebID VARCHAR(50) OUTPUT,
@NTAuth_User_IgnoreCase BIT
AS

IF @NTAuth_User_IgnoreCase = 0
BEGIN
    SELECT @WebID = IsNull(WEB_ID, 0)
    FROM SEC_USER WITH(NOLOCK)
    WHERE UPPER(USER_CODE) = UPPER(@UserID);
END

IF @NTAuth_User_IgnoreCase = 1
BEGIN
    SELECT @WebID = IsNull(WEB_ID, 0)
    FROM SEC_USER WITH(NOLOCK)
	WHERE (UPPER(SEC_USER.USER_CODE) = UPPER(@UserID));
END

























GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

