

























/*****************************************************************
Timesheet
This Stored Procedure gets a User Record for Login Purposes
NOTE:  Perhaps change this to Output parameters for better speed.
******************************************************************/
CREATE PROCEDURE [dbo].[usp_GetUser] 
@UserID VarChar(100)
AS

SET NOCOUNT ON

SELECT SEC_EMP.USER_ID AS UID, 
	EMPLOYEE.EMP_LNAME AS LNAME, 
	EMPLOYEE.EMP_FNAME AS FNAME, 
	EMPLOYEE.EMP_CODE AS EMP_CODE
FROM SEC_EMP 
INNER JOIN EMPLOYEE 
	ON SEC_EMP.EMP_CODE = EMPLOYEE.EMP_CODE 
WHERE (UPPER(SEC_EMP.USER_ID) = UPPER(@UserID))

























