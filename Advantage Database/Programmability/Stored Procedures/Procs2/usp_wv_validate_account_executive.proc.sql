





















CREATE PROCEDURE [dbo].[usp_wv_validate_account_executive] 
@Client as VarChar(6), 
@Division as VarChar(6), 
@Product as VarChar(6),
@EmpCode as VarChar(6)
AS
Set NoCount On
 
If Exists(
SELECT ae.EMP_CODE
FROM ACCOUNT_EXECUTIVE ae, V_ACTIVE_EMPLOYEE v
WHERE ae.EMP_CODE = v.EMP_CODE
AND CL_CODE = @Client
AND DIV_CODE = @Division
AND PRD_CODE = @Product
AND ae.EMP_CODE = @EmpCode 
AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 )
)
	 select 1
Else
	select  0





















