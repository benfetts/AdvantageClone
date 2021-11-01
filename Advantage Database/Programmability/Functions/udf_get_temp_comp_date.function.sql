﻿  	CREATE FUNCTION [dbo].[udf_get_temp_comp_date] ( @job_number integer, @job_component_nbr smallint, @seq_nbr smallint )  		  	RETURNS smalldatetime AS  	BEGIN  		DECLARE @comp_date smalldatetime    		SELECT @comp_date = ( SELECT MAX( TEMP_COMP_DATE )  					FROM dbo.JOB_TRAFFIC_DET_EMPS jtde  				       WHERE JOB_NUMBER = @job_number  				         AND JOB_COMPONENT_NBR = @job_component_nbr  					 AND SEQ_NBR = @seq_nbr  				      	 AND NOT EXISTS ( SELECT *   							    FROM dbo.JOB_TRAFFIC_DET_EMPS  							   WHERE JOB_NUMBER = jtde.JOB_NUMBER  							     AND JOB_COMPONENT_NBR = jtde.JOB_COMPONENT_NBR  							     AND SEQ_NBR = jtde.SEQ_NBR  							     AND TEMP_COMP_DATE IS NULL ))    	RETURN @comp_date  	END