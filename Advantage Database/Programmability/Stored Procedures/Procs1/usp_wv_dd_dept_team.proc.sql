

























CREATE PROCEDURE [dbo].[usp_wv_dd_dept_team] 

AS
SELECT DISTINCT DP_TM_CODE as code, DP_TM_CODE + ' - ' + DP_TM_DESC as description
FROM DEPT_TEAM
WHERE
INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0

















