
CREATE FUNCTION [dbo].[advtf_emp_names]() 		  	
RETURNS @EMP_NAMES TABLE 
( 	
	EmployeeCode varchar(6),
	EmployeeName varchar(MAX)
)
WITH SCHEMABINDING 
BEGIN  

	INSERT INTO @EMP_NAMES
	SELECT
		EMP_CODE,
		COALESCE((RTRIM(EMP_FNAME) + ' '),'') + COALESCE((EMP_MI + '. '),'') + COALESCE(EMP_LNAME,'')
	FROM
		dbo.EMPLOYEE_CLOAK	
	
	RETURN
	
END	
