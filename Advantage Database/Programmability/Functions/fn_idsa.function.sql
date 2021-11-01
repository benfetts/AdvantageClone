
CREATE FUNCTION [dbo].[fn_idsa] ( @data sql_variant, @is_alpha bit, @is_last bit )
RETURNS varchar(8000)
AS 
BEGIN
	DECLARE @return_value varchar(8000)
	
	SET @return_value = CAST( @data AS varchar(8000))
	
	SET @return_value = REPLACE(@return_value, '|', '\char(124)\')
	SET @return_value = REPLACE(@return_value, char(13) + char(10), '\char(13) + char(10)\')
	SET @return_value = REPLACE(@return_value, char(13), '\char(13)\')
	SET @return_value = REPLACE(@return_value, char(10), '\char(10)\')
	
	IF ( @return_value IS NULL )
		SET @return_value = ''
	
	--IF ( @is_alpha = 1 )
	--BEGIN
	--	IF ( @return_value IS NULL )
	--		SET @return_value = '""'
	--	ELSE
	--		SET @return_value = '"' + @return_value + '"'	
	--END

	IF ( @is_last = 0 )		
		SET @return_value = @return_value + '|'

	RETURN @return_value;	
END
