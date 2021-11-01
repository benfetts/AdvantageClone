
CREATE FUNCTION [dbo].[fn_task_all] ( @job_number integer, @job_component_nbr smallint, @list_type tinyint ) RETURNS varchar(4000)  	
AS  	
BEGIN  		
	DECLARE @id int, @job int, @comp smallint, @start_date date, @revised_date date, @task_description varchar(40), @task_list varchar(4000)
	
	DECLARE task_cursor CURSOR FOR 
	SELECT  
				[ID] = ROW_NUMBER() OVER(PARTITION BY JOB_NUMBER, JOB_COMPONENT_NBR ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR,	TASK_START_DATE, JOB_REVISED_DATE, SEQ_NBR),
				JOB_NUMBER, 
				JOB_COMPONENT_NBR,
				TASK_START_DATE,
				JOB_REVISED_DATE,
				TASK_DESCRIPTION
			FROM         
				[dbo].[JOB_TRAFFIC_DET]
			WHERE				  
				JOB_COMPLETED_DATE IS NULL  
		AND  JOB_NUMBER = @job_number  		    
	    AND JOB_COMPONENT_NBR = @job_component_nbr  		    
	    --AND SEQ_NBR = @seq_nbr   		
	FOR READ ONLY  	  		
	
	OPEN task_cursor     		
	FETCH NEXT FROM task_cursor INTO @id, @job, @comp, @start_date, @revised_date, @task_description		  		
	
	WHILE (@@FETCH_STATUS = 0)  		
	BEGIN  	  
		if @id > 1
		Begin
			SELECT @task_list = COALESCE( @task_list, '' ) + CONVERT(varchar, @start_date,1) + ' - ' + CONVERT(varchar, @revised_date,1) + ' ' + @task_description 
		End			
			
		FETCH NEXT FROM task_cursor INTO @id, @job, @comp, @start_date, @revised_date, @task_description 			  		    

		IF (@@FETCH_STATUS = 0)  	        	
			SELECT @task_list = @task_list + char(13) + char(10)		
	END     		
	
	CLOSE task_cursor   		
	DEALLOCATE task_cursor     	
	RETURN @task_list  	
END 
