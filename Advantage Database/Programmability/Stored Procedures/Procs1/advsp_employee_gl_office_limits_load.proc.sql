CREATE PROCEDURE [dbo].[advsp_employee_gl_office_limits_load] (
	@EmployeeCode AS varchar(6)
)
AS
BEGIN

	SELECT 
		GLO.GLOXGLOFFICE
	FROM 
		[dbo].[GLOXREF] AS GLO INNER JOIN
		(SELECT
				O.OFFICE_CODE
			FROM 
				[dbo].[EMPLOYEE] AS E CROSS JOIN 
				[dbo].[OFFICE] AS O LEFT OUTER JOIN 
				[dbo].[EMP_OFFICE] AS EO ON EO.EMP_CODE = E.EMP_CODE
			WHERE
				E.EMP_CODE = @EmployeeCode AND
				(EO.OFFICE_CODE = O.OFFICE_CODE OR
				 (O.OFFICE_CODE IS NOT NULL AND 
				  EO.OFFICE_CODE IS NULL))) AS OL ON OL.OFFICE_CODE = GLO.GLOXOFFICE


END
GO