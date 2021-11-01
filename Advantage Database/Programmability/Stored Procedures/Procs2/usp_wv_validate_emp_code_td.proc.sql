





















CREATE PROCEDURE [dbo].[usp_wv_validate_emp_code_td] 
@EmpCode VarChar(30)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT EMP_CODE
FROM EMPLOYEE
WHERE EMP_CODE = @EmpCode AND EMP_TERM_DATE IS NULL
)
	 select 1
Else
	select  0





















