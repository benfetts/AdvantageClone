



























/*****************************************************************
This Stored Procedure gets a User Information for Profile
******************************************************************/
CREATE PROCEDURE [dbo].[usp_GetUserInfo] 
@EmpCode VarChar(100) 
AS

SET NOCOUNT ON

SELECT     EMP_ADDRESS1, EMP_ADDRESS2, EMP_CITY, EMP_STATE, EMP_ZIP, EMP_PHONE, EMP_EMAIL
FROM         EMPLOYEE
WHERE     (EMP_CODE = @EmpCode)

























