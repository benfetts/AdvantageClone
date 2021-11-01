
CREATE FUNCTION [dbo].[advfn_remove_char] ( @string_in varchar(254), @remove_char varchar(1) )
RETURNS varchar(254)
AS
BEGIN
	DECLARE @pos integer, @string_out varchar(254), @len integer
	
	SELECT @string_out = @string_in
	SELECT @pos = CHARINDEX( @remove_char, @string_out )
	SELECT @len = LEN( @string_out )
	 
	WHILE ( @pos > 0 )
	BEGIN
		IF ( @pos > 1 ) AND ( @pos < @len )
			SELECT @string_out = SUBSTRING( @string_out, 1, @pos - 1 ) + SUBSTRING( @string_out, @pos + 1, @len - @pos )
		ELSE
		BEGIN
			IF ( @len = 1 )
				SELECT @string_out = ''
			ELSE
			BEGIN
				IF ( @pos = 1 )
					SELECT @string_out = SUBSTRING( @string_out, @pos + 1, @len - @pos )
					
				IF ( @pos = @len )
					SELECT @string_out = SUBSTRING( @string_out, 1, @pos - 1 )
			END		
		END
		
		SELECT @pos = CHARINDEX( @remove_char, @string_out )
		SELECT @len = LEN( @string_out )
	END
	   
RETURN ( @string_out )
END
