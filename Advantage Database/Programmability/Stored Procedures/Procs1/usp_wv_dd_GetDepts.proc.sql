

























/*****************************************************************
Gets Depts for Drop Downs
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetDepts] 
@EmpCode AS VARCHAR(6),
@ShowAll AS INT
AS

SET NOCOUNT ON

IF @ShowAll = 1
    BEGIN
    SELECT DP_TM_CODE AS Code, DP_TM_DESC  AS Description
    FROM EMP_DP_TM 
    WHERE EMP_CODE = @EmpCode
    ORDER BY Description
    END
ELSE
    BEGIN
        SELECT     EMP_DP_TM.DP_TM_CODE AS Code, EMP_DP_TM.DP_TM_DESC AS Description
        FROM         EMP_DP_TM INNER JOIN
                              DEPT_TEAM ON EMP_DP_TM.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE
        WHERE     ((DEPT_TEAM.INACTIVE_FLAG IS NULL) OR (DEPT_TEAM.INACTIVE_FLAG = 0)) AND EMP_CODE = @EmpCode
        ORDER BY Description
    END


























