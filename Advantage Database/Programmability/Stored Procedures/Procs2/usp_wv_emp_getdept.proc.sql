








CREATE PROCEDURE [dbo].[usp_wv_emp_getdept] 
@EmpCode as VarChar(6),
@EmpDept as Varchar(4) OUTPUT
AS

SELECT  @EmpDept =   ISNull(DP_TM_CODE, '')
FROM         EMPLOYEE
WHERE     (EMP_CODE = @EmpCode)























