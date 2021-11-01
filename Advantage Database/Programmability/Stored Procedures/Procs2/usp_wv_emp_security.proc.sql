


/*****************************************************************
Check Security for Employees
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_emp_security] 
@UserID VarChar(100) 
AS
Declare @Rescrictions Int

Set NoCount on

Select Count(*) as secEmpCount
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)



