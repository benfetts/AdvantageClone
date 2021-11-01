


























CREATE PROCEDURE [dbo].[usp_wv_emp_GetMonthlyGoal] 
@EmpCode VarChar(6)
AS

Set NoCount On
 
SELECT    ISNULL(EMPLOYEE.MTH_HRS_GOAL, 0)  AS Goal
FROM       EMPLOYEE 
WHERE    EMPLOYEE.EMP_CODE = @EmpCode

























