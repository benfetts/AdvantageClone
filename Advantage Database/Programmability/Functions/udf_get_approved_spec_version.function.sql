
CREATE  FUNCTION [dbo].[udf_get_approved_spec_version] ( @job_nbr integer, @job_comp integer )  		  	
RETURNS INTEGER AS  

BEGIN  
	DECLARE @APPROVED_VER INTEGER
	
	SELECT @APPROVED_VER = APPR_SPEC_VER
	FROM JOB_SPEC_APPR
		WHERE JOB_NUMBER = @job_nbr
		AND JOB_COMPONENT_NBR = @job_comp

	RETURN @APPROVED_VER
END	
