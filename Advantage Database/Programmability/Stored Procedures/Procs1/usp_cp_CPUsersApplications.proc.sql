






/*****************************************************************
Gets Depts for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_CPUsersApplications] 
@CDPCode as Int
AS

Set NoCount On

SELECT  CDP_CONTACT_ID, APPID 
FROM  CP_USER_SEC_APP 
WHERE CDP_CONTACT_ID = @CDPCode


























