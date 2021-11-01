





















CREATE PROCEDURE [dbo].[usp_wv_validate_emp_code] 
@EmpCode VarChar(30)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT EMP_CODE
FROM EMPLOYEE
WHERE EMP_CODE = @EmpCode
)
	 select 1
Else
	select  0





















