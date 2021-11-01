




















CREATE PROCEDURE [dbo].[usp_wv_get_emp_restrictions] 
@UserID VarChar(100) 
AS

Select Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)




















