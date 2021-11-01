
















CREATE PROCEDURE [dbo].[usp_wv_IsEmpTerminated] 
@EmpCode VarChar(6)
AS

SET NOCOUNT ON
 
IF EXISTS(
	SELECT 
		DISTINCT EMP_CODE
	FROM 
		EMPLOYEE WITH (NOLOCK)
	WHERE 
		(EMP_CODE = @EmpCode) 
		AND (
			(NOT(EMP_TERM_DATE IS NULL))	
			AND 
			EMP_TERM_DATE < GETDATE()
		)
)
	SELECT 1;
ELSE
	SELECT 0;















