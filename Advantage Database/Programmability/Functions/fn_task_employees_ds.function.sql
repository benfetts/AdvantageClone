DROP FUNCTION [dbo].[fn_task_employees_ds]
GO


CREATE FUNCTION [dbo].[fn_task_employees_ds] 
( @job_number integer, @job_component_nbr smallint, @seq_nbr smallint, @list_type tinyint ) RETURNS varchar(4000)  	
WITH SCHEMABINDING	
AS  
BEGIN  		

	DECLARE @listStr VARCHAR(MAX)

	SELECT
		@listStr = COALESCE(@listStr + ', ', '') + 
		CASE 
			WHEN @list_type = 1 THEN JTDE.EMP_CODE
			WHEN @list_type = 2 THEN E.EMP_LNAME
			WHEN @list_type = 3 THEN E.EMP_LNAME + COALESCE( ' ' + LEFT( E.EMP_FNAME, 1 ) + '.', '' )
			WHEN @list_type = 4 THEN JTDE.EMP_CODE + ' - ' + COALESCE( E.EMP_FNAME + ' ', '' ) + COALESCE( E.EMP_MI + '. ', '' ) + E.EMP_LNAME
			WHEN @list_type = 5 THEN JTDE.EMP_CODE + '(' + CAST(JTDE.HOURS_ALLOWED AS VARCHAR) + ')'
			WHEN @list_type = 6 THEN COALESCE( E.EMP_FNAME + ' ', '' ) + COALESCE( E.EMP_MI + '. ', '' ) + E.EMP_LNAME + '(' + CAST(JTDE.HOURS_ALLOWED AS VARCHAR) + ')'  
			WHEN @list_type = 7 THEN COALESCE( E.EMP_FNAME + ' ', '' ) + COALESCE( E.EMP_MI + '. ', '' ) + E.EMP_LNAME
		END
	FROM
		dbo.JOB_TRAFFIC_DET_EMPS JTDE
	INNER JOIN
		dbo.EMPLOYEE_CLOAK E ON JTDE.EMP_CODE = E.EMP_CODE
	WHERE
		JOB_NUMBER = @job_number AND
		JOB_COMPONENT_NBR = @job_component_nbr AND
		SEQ_NBR = @seq_nbr 

	RETURN @listStr
	
END

GO


