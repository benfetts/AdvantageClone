






/*****************************************************************
Gets Depts for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_CPUsersDataCDP] 
@CDPCode as int
AS

Set NoCount On

SELECT     dbo.CDP_CONTACT_HDR.CL_CODE, dbo.CDP_CONTACT_DTL.DIV_CODE, dbo.CDP_CONTACT_DTL.PRD_CODE
FROM         dbo.CDP_CONTACT_DTL INNER JOIN
                      dbo.CDP_CONTACT_HDR ON dbo.CDP_CONTACT_DTL.CDP_CONTACT_ID = dbo.CDP_CONTACT_HDR.CDP_CONTACT_ID
WHERE     (dbo.CDP_CONTACT_DTL.CDP_CONTACT_ID = @CDPCode)


























