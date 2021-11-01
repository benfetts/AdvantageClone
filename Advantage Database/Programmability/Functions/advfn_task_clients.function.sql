
CREATE FUNCTION [dbo].[advfn_task_clients] ( @job_number integer, @job_component_nbr smallint, @seq_nbr smallint, @list_type tinyint )
RETURNS varchar(4000) AS
BEGIN
	DECLARE @client_code varchar(6), @client_fname varchar(30), @client_mi varchar(1), @client_lname varchar(30), @client_list varchar(4000)
        
	DECLARE client_cursor CURSOR FOR
	 SELECT CONT_CODE, CONT_FNAME, CONT_MI, CONT_LNAME
	   FROM dbo.JOB_TRAFFIC_DET_CNTS jtdc LEFT OUTER JOIN dbo.CDP_CONTACT_HDR c
		 ON ( jtdc.CDP_CONTACT_ID = c.CDP_CONTACT_ID )
	  WHERE JOB_NUMBER = @job_number
		AND JOB_COMPONENT_NBR = @job_component_nbr
		AND SEQ_NBR = @seq_nbr 
	FOR READ ONLY
  
	OPEN client_cursor
	
    FETCH NEXT FROM  client_cursor INTO @client_code, @client_fname, @client_mi, @client_lname
    
    WHILE ( @@FETCH_STATUS = 0 )
    BEGIN
		IF @list_type = 1
			SELECT @client_list = COALESCE( @client_list, '' ) + @client_code
		IF @list_type = 2
			SELECT @client_list = COALESCE( @client_list, '' ) + @client_lname
		FETCH NEXT FROM  client_cursor INTO @client_code, @client_fname, @client_mi, @client_lname                      
		IF ( @@FETCH_STATUS = 0 )
			SELECT @client_list   = @client_list + ', '
    END
    CLOSE client_cursor
    DEALLOCATE client_cursor
    RETURN @client_list
END

