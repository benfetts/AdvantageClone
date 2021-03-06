--DROP PROCEDURE [dbo].[usp_wv_dd_GetAccExecCodes_BillingApprovalBatch]
CREATE PROCEDURE [dbo].[usp_wv_dd_GetAccExecCodes_BillingApprovalBatch]
@UserID VarChar(100)
AS
/*=========== QUERY ===========*/
	DECLARE 
		@OfficeRestrictions AS INT,	
		@EMP_CODE AS VARCHAR(6)

	SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserID);
	SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;

	IF @OfficeRestrictions > 0
	BEGIN
		SELECT DISTINCT
			AE.EMP_CODE AS Code,
			E.EMP_CODE + ' - ' + ISNULL(E.EMP_LNAME, E.EMP_CODE) + ', ' + ISNULL(E.EMP_FNAME, '') AS [Description]
		FROM 
			ACCOUNT_EXECUTIVE AE 
			INNER JOIN EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE
			INNER JOIN PRODUCT P ON AE.CL_CODE = P.CL_CODE AND AE.DIV_CODE = P.DIV_CODE AND AE.PRD_CODE = P.PRD_CODE
			INNER JOIN EMP_OFFICE EO ON P.OFFICE_CODE = EO.OFFICE_CODE
		WHERE 
			EO.EMP_CODE = @EMP_CODE
			AND (AE.INACTIVE_FLAG IS NULL OR AE.INACTIVE_FLAG = 0)
			AND (E.EMP_TERM_DATE IS NULL OR E.EMP_TERM_DATE > GETDATE())          
		ORDER BY
			AE.EMP_CODE;
	END
	ELSE
	BEGIN
		SELECT DISTINCT 
			ACCOUNT_EXECUTIVE.EMP_CODE AS Code,
			EMPLOYEE.EMP_CODE + ' - ' + ISNULL(EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_CODE) + ', ' + ISNULL(EMPLOYEE.EMP_FNAME, '') AS [Description]
		FROM   
			ACCOUNT_EXECUTIVE WITH(NOLOCK)
			INNER JOIN EMPLOYEE WITH(NOLOCK) ON  ACCOUNT_EXECUTIVE.EMP_CODE = EMPLOYEE.EMP_CODE
		WHERE
			(ACCOUNT_EXECUTIVE.INACTIVE_FLAG IS NULL OR ACCOUNT_EXECUTIVE.INACTIVE_FLAG = 0)
			AND (EMPLOYEE.EMP_TERM_DATE IS NULL OR EMPLOYEE.EMP_TERM_DATE > GETDATE())          
		ORDER BY
			ACCOUNT_EXECUTIVE.EMP_CODE;
	END
/*=========== QUERY ===========*/