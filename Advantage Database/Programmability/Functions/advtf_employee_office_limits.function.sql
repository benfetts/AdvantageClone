CREATE FUNCTION [dbo].[advtf_employee_office_limits] (
	@EmployeeCode VARCHAR(6)
) RETURNS TABLE
RETURN (
	SELECT
		O.OFFICE_CODE
	FROM 
		[dbo].[EMPLOYEE] AS E CROSS JOIN 
		[dbo].[OFFICE] AS O LEFT OUTER JOIN 
		[dbo].[EMP_OFFICE] AS EO ON EO.EMP_CODE = E.EMP_CODE
	WHERE
		E.EMP_CODE = @EmployeeCode AND
		(EO.OFFICE_CODE = O.OFFICE_CODE OR
			(O.OFFICE_CODE IS NOT NULL AND 
			EO.OFFICE_CODE IS NULL))
)