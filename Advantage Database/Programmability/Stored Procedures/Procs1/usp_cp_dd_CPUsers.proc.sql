






/*****************************************************************
Gets Depts for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_dd_CPUsers] 
@ClientCode as VarChar(6)
AS

Set NoCount On

if @ClientCode = ''
SELECT CP_USER.CDP_CONTACT_ID AS Code, CDP_CONTACT_HDR.CONT_FML AS Description
FROM CP_USER INNER JOIN
			CDP_CONTACT_HDR ON CP_USER.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
Order By Description

else
SELECT CP_USER.CDP_CONTACT_ID AS Code, CDP_CONTACT_HDR.CONT_FML AS Description
FROM CP_USER INNER JOIN
			CDP_CONTACT_HDR ON CP_USER.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
WHERE CP_USER.CL_CODE = @ClientCode
Order By Description

























