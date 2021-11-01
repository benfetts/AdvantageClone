
CREATE PROCEDURE [dbo].[usp_cp_GetUserNames] 
--@UserID VarChar(100) 
AS
--Declare @Rescrictions Int
--
--Set NoCount on
--
--Select @Rescrictions = Count(*) 
--FROM SEC_EMP
--WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT    USER_NAME as Name
FROM         CP_USER
 



	
