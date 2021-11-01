
CREATE PROCEDURE [dbo].[usp_cp_GetUserName] 
@CDPID int 
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
WHERE	  CDP_CONTACT_ID = @CDPID
 



	
