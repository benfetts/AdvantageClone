CREATE FUNCTION [dbo].[udf_split_list](@String varchar(MAX), @Delimiter char(1))       
RETURNS @temptable TABLE (items varchar(8000)) WITH SCHEMABINDING       
AS     
BEGIN   
    
    DECLARE @idx int       
    DECLARE @slice varchar(8000)       
      
    SELECT @idx = 1
    
    IF @String IS NOT NULL AND LEN(@String) > 0 BEGIN
      
		WHILE @idx <> 0 BEGIN    
	          
			SET @idx = CHARINDEX(@Delimiter, @String)
	               
			IF @idx <> 0 BEGIN      
			
				SET @slice = LEFT(@String, @idx - 1) 
				      
			END ELSE BEGIN 
			    
				SET @slice = @String 
				      
			END
	        
			IF LEN(@slice) > 0 BEGIN
			
				INSERT INTO 
					@temptable(items) 
				VALUES(@slice)       
	  
			END 
				
			SET @String = RIGHT(@String, LEN(@String) - @idx)  
			     
			IF LEN(@String) = 0 BEGIN 
			
				BREAK       
	    
			END
			
		END 
    
    END 
        
	RETURN 
      
END
GO

GRANT SELECT ON [udf_split_list] TO PUBLIC
GO