

/*****************************************************************
Gets All EmpCodes by FML format
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetEmpsByFML] 
@UserID VarChar(100) 
AS
Declare @Restrictions Int

Set NoCount on

Select @Restrictions = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)

DECLARE @OfficeRestrictions AS INTEGER	
DECLARE @EMP_CODE AS varchar(6)

SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

If @Restrictions > 0
Begin
	if @OfficeRestrictions > 0
	Begin
		SELECT    EMPLOYEE.EMP_CODE as Code, dbo.udf_get_empl_name(EMPLOYEE.EMP_CODE, 'FML') AS Description
		FROM         EMPLOYEE
			Inner JOIN [dbo].[advtf_sec_emp] (@UserID) AS SEC_EMP
			On EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE INNER JOIN
						EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		Where (EMP_TERM_DATE IS NULL OR EMP_TERM_DATE > GETDATE())
		Order By  EMPLOYEE.EMP_CODE
	End
	Else 
	Begin
		SELECT    EMPLOYEE.EMP_CODE as Code, dbo.udf_get_empl_name(EMPLOYEE.EMP_CODE, 'FML') AS Description
		FROM         EMPLOYEE
			Inner JOIN [dbo].[advtf_sec_emp] (@UserID) AS SEC_EMP
			On EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE
		Where (EMP_TERM_DATE IS NULL OR EMP_TERM_DATE > GETDATE()) 
		Order By  EMPLOYEE.EMP_CODE
	End
End
ELSE
Begin
	if @OfficeRestrictions > 0
	Begin
		SELECT    EMPLOYEE.EMP_CODE as Code, dbo.udf_get_empl_name(EMPLOYEE.EMP_CODE, 'FML') AS Description
		FROM         EMPLOYEE INNER JOIN
						EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		Where (EMP_TERM_DATE IS NULL OR EMP_TERM_DATE > GETDATE())
		Order By EMPLOYEE.EMP_CODE
	End
	Else
	Begin
		SELECT    EMP_CODE as Code, dbo.udf_get_empl_name(EMPLOYEE.EMP_CODE, 'FML') AS Description
		FROM         EMPLOYEE
		Where (EMP_TERM_DATE IS NULL OR EMP_TERM_DATE > GETDATE())
		Order By EMP_CODE
	End
End

	



