/****** Object:  UserDefinedFunction [dbo].[advfn_clear_special_characters]    Script Date: 05/20/2015 16:53:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advfn_clear_special_characters]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advfn_clear_special_characters]
GO

/****** Object:  UserDefinedFunction [dbo].[advfn_clear_special_characters]    Script Date: 05/20/2015 16:53:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- ==============================================
-- Description:	Removes "special" characters
-- Parameters: 
--		1) string1 that needs to have special characters removed
--		2) string2 that contains the allowable characters (uses [A-Za-z0-9 ] by default if not provided)
-- Returns: original string1 with special characters removed
-- Note: '-' is a special "special" character. If you supply it as an
--                allowed character it must be the first or last character.
-- ==============================================
CREATE FUNCTION [advfn_clear_special_characters]
(
	-- Add the parameters for the function here
	@BUFFER VARCHAR(MAX), @ALLOWED VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS

BEGIN
	DECLARE @s VARCHAR(MAX)
	DECLARE @p INT
	DECLARE @new VARCHAR(255)
	DECLARE @curr VARCHAR(1)
	DECLARE @prev VARCHAR(1)

	SET @p = 1
	SET @new = ''
	SET @curr = ''
	SET @prev = ''

	IF @ALLOWED IS NULL OR @ALLOWED = ''
		SET @ALLOWED = '[A-Za-z0-9 ]'
	ELSE
		SET @ALLOWED = '[' +@ALLOWED + ']'

	SET @s = @BUFFER

	WHILE @p <= LEN(@s)
	BEGIN
		SET @curr = SUBSTRING(@s, @p, 1)
		IF @curr COLLATE Latin1_General_100_BIN LIKE @ALLOWED
			BEGIN
				IF @curr = ' ' AND @prev = ' '
					SET @prev = @curr
				ELSE 
				BEGIN
					SET @new = @new + @curr
					SET @prev = @curr
				END
			END 
		SET @p = @p + 1;
	END
	RETURN(@new);
END
GO

GRANT EXECUTE ON [advfn_clear_special_characters] TO PUBLIC AS dbo
GO
