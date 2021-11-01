




/*****************************************************************
Gets All UserCodes 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_GetUserCodes] 
--@UserID VarChar(100) 
AS
--Declare @Rescrictions Int
--
--Set NoCount on
--
--Select @Rescrictions = Count(*) 
--FROM SEC_EMP
--WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT    CDP_CONTACT_ID as Code
FROM         CP_USER






