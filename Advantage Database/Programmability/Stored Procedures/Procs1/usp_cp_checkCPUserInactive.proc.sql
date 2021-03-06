
CREATE PROCEDURE [dbo].[usp_cp_checkCPUserInactive] 
@UserName varchar(100)
AS

Set NoCount On

SELECT     ISNULL(CDP_CONTACT_HDR.INACTIVE_FLAG,0) as INACTIVE_FLAG
FROM         CDP_CONTACT_HDR INNER JOIN
                     CP_USER ON dbo.CDP_CONTACT_HDR.CDP_CONTACT_ID = CP_USER.CDP_CONTACT_ID
WHERE     (CP_USER.USER_NAME = @UserName)	
	
