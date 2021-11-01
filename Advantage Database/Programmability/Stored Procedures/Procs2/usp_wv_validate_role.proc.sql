





















CREATE PROCEDURE [dbo].[usp_wv_validate_role] 
@RoleCode VarChar(6)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT ROLE_CODE, ROLE_DESC
from TRAFFIC_ROLE
WHERE (INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG <> 1)
AND ROLE_CODE = @RoleCode
)
	 select 1
Else
	select  0





















