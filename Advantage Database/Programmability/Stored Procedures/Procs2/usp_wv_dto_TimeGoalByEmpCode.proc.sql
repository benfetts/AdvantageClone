


























CREATE PROCEDURE [dbo].[usp_wv_dto_TimeGoalByEmpCode] 
@EmpCode VarChar(6),
@StartDate SmallDateTime, 
@EndDate SmallDateTime
AS

Set NoCount On
 
SELECT    
    ISNULL(SUM(EMP_TIME_DTL.EMP_HOURS), 0) AS Hours,  
    ISNULL(ISNULL(AVG(EMPLOYEE.MTH_HRS_GOAL), 
    SUM(EMP_TIME_DTL.EMP_HOURS)) - SUM(EMP_TIME_DTL.EMP_HOURS), 0) AS Missing
FROM         
    EMPLOYEE WITH(NOLOCK) INNER JOIN
    EMP_TIME WITH(NOLOCK) ON EMPLOYEE.EMP_CODE = EMP_TIME.EMP_CODE INNER JOIN
    EMP_TIME_DTL WITH(NOLOCK) ON EMP_TIME.ET_ID = EMP_TIME_DTL.ET_ID
WHERE     
    (
        (EMP_TIME.EMP_CODE =@EmpCode) 
        AND (EMP_TIME_DTL.EMP_NON_BILL_FLAG = 0 OR EMP_TIME_DTL.EMP_NON_BILL_FLAG IS NULL) 
        AND (EMP_TIME.EMP_DATE <= @EndDate) 
        AND (EMP_TIME.EMP_DATE >= @StartDate)
    ) 
    OR
    (
        (EMP_TIME.EMP_CODE = @EmpCode) 
        AND (EMP_TIME_DTL.FEE_TIME IN (1,2,3)) 
        AND (EMP_TIME.EMP_DATE <= @EndDate) AND (EMP_TIME.EMP_DATE >= @StartDate)
    )
                    
                    



























