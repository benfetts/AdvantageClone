
CREATE  FUNCTION [dbo].[udf_get_empl_name] ( @emp_code varchar(6), @name_format varchar(3) )  		  	
RETURNS VARCHAR(61) AS  	
BEGIN  
	DECLARE @EMP_NAME	VARCHAR(61)
	BEGIN	
	IF ( @name_format = 'FML' )   
		SELECT @EMP_NAME = (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') AS EMP_NAME FROM EMPLOYEE WHERE EMP_CODE = @emp_code )
	ELSE
		SELECT @EMP_NAME = (SELECT coalesce((EMP_LNAME + ', '),'') + coalesce((rtrim(EMP_FNAME)),'') AS EMP_NAME FROM EMPLOYEE WHERE EMP_CODE = @emp_code )
	END
	RETURN @EMP_NAME 
END	
