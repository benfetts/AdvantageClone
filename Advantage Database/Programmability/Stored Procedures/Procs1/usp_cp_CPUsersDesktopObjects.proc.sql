






/*****************************************************************
Gets Depts for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_CPUsersDesktopObjects] 
@CDPCode as int
AS

Set NoCount On

SELECT  CDP_CONTACT_ID, DESKTOP_OBJECT_ID 
FROM  CP_USER_TAB_DESKTOP_OBJECT 
WHERE CDP_CONTACT_ID = @CDPCode


























