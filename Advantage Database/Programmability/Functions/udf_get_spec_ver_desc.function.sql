﻿

CREATE  FUNCTION [dbo].[udf_get_spec_ver_desc] ( @job_nbr integer, @job_comp integer, @spec_ver integer )  		  	
RETURNS VARCHAR(60) AS  

BEGIN  
	DECLARE @MAX_REV INTEGER
	DECLARE @SPEC_VER_DESC VARCHAR(60)
	
	SELECT @MAX_REV = MAX(SPEC_REV) FROM JOB_SPECS
WHERE JOB_NUMBER = @job_nbr
	AND JOB_COMPONENT_NBR = @job_comp
	AND SPEC_VER = @spec_ver
	
	SELECT @SPEC_VER_DESC = ISNULL(SPEC_VER_DESC,'')
	FROM JOB_SPECS
	WHERE JOB_NUMBER = @job_nbr
		AND JOB_COMPONENT_NBR = @job_comp
		AND SPEC_VER = @spec_ver
		AND SPEC_REV = @MAX_REV


	RETURN @SPEC_VER_DESC

END	
