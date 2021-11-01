
CREATE FUNCTION [dbo].[fn_task_employees_all] ( @job_number integer, @job_component_nbr smallint, @list_type tinyint ) RETURNS varchar(4000)  	
AS  	
BEGIN  		
	DECLARE @emp_code varchar(6), @emp_fname varchar(30), @emp_mi varchar(1), @emp_lname varchar(30), @emp_list varchar(4000), @Hours_Allowed decimal(8,2)  		  		
	
	DECLARE emp_cursor CURSOR FOR 
	 SELECT DISTINCT jtde.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME   		   
	   FROM dbo.JOB_TRAFFIC_DET_EMPS jtde LEFT OUTER JOIN dbo.EMPLOYEE e  		     
	     ON  (jtde.EMP_CODE = e.EMP_CODE)  		  
	  WHERE  JOB_NUMBER = @job_number  		    
	    AND JOB_COMPONENT_NBR = @job_component_nbr  		    
	    --AND SEQ_NBR = @seq_nbr   		
	FOR READ ONLY  	  		
	
	OPEN emp_cursor     		
	FETCH NEXT FROM emp_cursor INTO @emp_code, @emp_fname, @emp_mi, @emp_lname		  		
	
	WHILE (@@FETCH_STATUS = 0)  		
	BEGIN  		    
		IF @list_type = 1  		        
			SELECT @emp_list = COALESCE( @emp_list, '' ) + @emp_code
			  	      		    
		IF @list_type = 2  		        
			SELECT @emp_list = COALESCE( @emp_list, '' ) + @emp_lname  	      		    
			
		IF @list_type = 3  		        
			SELECT @emp_list = COALESCE( @emp_list, '' ) + @emp_lname + COALESCE( ' ' + LEFT( @emp_fname, 1 ) + '.', '' )  	          	   	    
			
		IF @list_type = 4      			
			SELECT @emp_list = COALESCE( @emp_list, '' ) + @emp_code + ' - ' + COALESCE( @emp_fname + ' ', '' ) + COALESCE( @emp_mi + '. ', '' ) + @emp_lname  	          	   	    
			
		IF @list_type = 5      			
			SELECT @emp_list = COALESCE( @emp_list, '' ) + @emp_code + '(' + CAST(@Hours_Allowed AS VARCHAR) + ')'

		IF @list_type = 6      			
			SELECT @emp_list = COALESCE( @emp_list, '' ) + COALESCE( @emp_fname + ' ', '' ) + COALESCE( @emp_mi + '. ', '' ) + @emp_lname + '(' + CAST(@Hours_Allowed AS VARCHAR) + ')'             	   	    
			
		IF @list_type = 7      			
			SELECT @emp_list = COALESCE( @emp_list, '' ) + COALESCE( @emp_fname + ' ', '' ) + COALESCE( @emp_mi + '. ', '' ) + @emp_lname  	          	   	               	   	    
			
		IF @list_type = 8      			
			SELECT @emp_list = COALESCE( @emp_list, '' ) + COALESCE( @emp_fname + ' ', '' ) + @emp_lname	          	   	    
						  		    
			
		FETCH NEXT FROM emp_cursor INTO @emp_code, @emp_fname, @emp_mi, @emp_lname  			  		    

		IF (@@FETCH_STATUS = 0)  	        
		Begin
			IF @list_type = 8 
			Begin
				SELECT @emp_list = @emp_list + CHAR(13)+CHAR(10)  
			End
			Else
			Begin
				SELECT @emp_list = @emp_list + ', '  
			End
		End
					
	END     		
	
	CLOSE emp_cursor   		
	DEALLOCATE emp_cursor     	
	RETURN @emp_list  	
END 
