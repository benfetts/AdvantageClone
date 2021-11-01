





















CREATE PROCEDURE [dbo].[usp_wv_validate_dept_team] 
@DeptTeamCode VarChar(8)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT DP_TM_CODE, DP_TM_DESC 
FROM DEPT_TEAM
WHERE INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0
AND DP_TM_CODE = @DeptTeamCode
)
	 select 1
Else
	select  0






















