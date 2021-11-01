
CREATE FUNCTION [dbo].[advfn_get_fk_name] ( @table_name varchar(50), @column_names varchar(4000))
RETURNS varchar(50)
AS
BEGIN
	DECLARE @fk_name varchar(50), @key_col varchar(50), @countvar smallint, @const_col varchar(50)
	
	DECLARE key_cursor CURSOR FOR
	 SELECT DISTINCT rc.CONSTRAINT_NAME
	   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc,   
			INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
	  WHERE ( rc.CONSTRAINT_NAME = tc.CONSTRAINT_NAME ) 
		AND ( tc.CONSTRAINT_TYPE = 'FOREIGN KEY' ) 
		AND ( tc.TABLE_NAME = @table_name )
	FOR READ ONLY
		
	OPEN key_cursor

	FETCH key_cursor INTO @fk_name

	WHILE ( @@FETCH_STATUS = 0 )
	BEGIN
		DECLARE keycol_cursor CURSOR FOR
		 SELECT kcu.COLUMN_NAME
		   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc,   
				INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc,   
		       	INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu  
		  WHERE ( rc.CONSTRAINT_NAME = tc.CONSTRAINT_NAME ) 
			AND ( kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME ) 
			AND ( tc.CONSTRAINT_TYPE = 'FOREIGN KEY' )    
			AND ( tc.CONSTRAINT_NAME = @fk_name )    
	    ORDER BY kcu.ORDINAL_POSITION ASC		
		FOR READ ONLY
			
		OPEN keycol_cursor
		
		SET @countvar = 0
		FETCH keycol_cursor INTO @const_col
		
		WHILE ( @@FETCH_STATUS = 0 )
		BEGIN
			SET @countvar = @countvar + 1
			SELECT @key_col = ( SELECT vstr FROM dbo.advtf_charlist_to_table( @column_names, ',' ) WHERE listpos = @countvar ) 
			IF ( @key_col = @const_col )
				FETCH keycol_cursor INTO @const_col
			ELSE
			BEGIN
				SET @fk_name = NULL				
				BREAK
			END	
		END
		
		CLOSE keycol_cursor
		DEALLOCATE keycol_cursor
		
		IF ( @fk_name IS NOT NULL )
			BREAK

		FETCH key_cursor INTO @fk_name
	END

	CLOSE key_cursor
	DEALLOCATE key_cursor
		
	RETURN @fk_name
END
