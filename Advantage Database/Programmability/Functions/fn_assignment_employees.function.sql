
IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[fn_assignment_employees]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[fn_assignment_employees]
END
GO
CREATE FUNCTION [dbo].[fn_assignment_employees] ( @alertid integer, @job_number integer, @job_component_nbr smallint, @seq_nbr smallint, @list_type tinyint, @alrt_notify_hdr_id integer ) RETURNS varchar(4000)  	
AS  	
BEGIN  		
	DECLARE @emp_code varchar(6), @emp_fname varchar(30), @emp_mi varchar(1), @emp_lname varchar(30), @emp_list varchar(4000), @Hours_Allowed decimal(8,2)	  		

	
	if @alrt_notify_hdr_id = 0 
	BEGIN
		DECLARE emp_cursor CURSOR FOR 
		 SELECT AR.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, ISNULL(A.HRS_ALLOWED,0)
			FROM ALERT A LEFT OUTER JOIN 
				 ALERT_RCPT AR ON A.ALERT_ID = AR.ALERT_ID
				 LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = AR.EMP_CODE
			WHERE A.ALERT_ID = @alertid AND AR.CURRENT_NOTIFY = 1
		FOR READ ONLY  	  		
	
		OPEN emp_cursor     		
		FETCH NEXT FROM emp_cursor INTO @emp_code, @emp_fname, @emp_mi, @emp_lname, @Hours_Allowed  		  		
	
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
						  		    
			
			FETCH NEXT FROM emp_cursor INTO @emp_code, @emp_fname, @emp_mi, @emp_lname, @Hours_Allowed  			  		    

			IF (@@FETCH_STATUS = 0)  	        	
				SELECT @emp_list = @emp_list + ', '  		
		END     		
	
		CLOSE emp_cursor   		
		DEALLOCATE emp_cursor     
	END
	ELSE
	BEGIN
		DECLARE emp_cursor2 CURSOR FOR 
		 SELECT A.ASSIGNED_EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, ISNULL(A.HRS_ALLOWED,0)
			FROM ALERT A 
				 LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = A.ASSIGNED_EMP_CODE
			WHERE A.ALERT_ID = @alertid 
		FOR READ ONLY  	  		
	
		OPEN emp_cursor2     		
		FETCH NEXT FROM emp_cursor2 INTO @emp_code, @emp_fname, @emp_mi, @emp_lname, @Hours_Allowed  		  		
	
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
						  		    
			
			FETCH NEXT FROM emp_cursor2 INTO @emp_code, @emp_fname, @emp_mi, @emp_lname, @Hours_Allowed  			  		    

			IF (@@FETCH_STATUS = 0)  	        	
				SELECT @emp_list = @emp_list + ', '  		
		END     		
	
		CLOSE emp_cursor2  		
		DEALLOCATE emp_cursor2 
	END
	
	RETURN @emp_list  		
END 
