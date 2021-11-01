
/*****************************************************************
Webvantage
This Stored Procedure gets the email address for the Alert Generated User
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert_UserEmail] 

@UserName VarChar(6)

 
AS

SET NOCOUNT ON

SELECT    EMP_EMAIL
FROM       EMPLOYEE
WHERE     EMP_CODE = @UserName
