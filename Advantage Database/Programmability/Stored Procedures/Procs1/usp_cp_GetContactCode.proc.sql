
CREATE PROCEDURE [dbo].[usp_cp_GetContactCode] 
@CDPID int 
AS
--Declare @Rescrictions Int
--
--Set NoCount on
--
--Select @Rescrictions = Count(*) 
--FROM SEC_EMP
--WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT    CONT_CODE
FROM         CDP_CONTACT_HDR
WHERE	  CDP_CONTACT_ID = @CDPID
 



	
