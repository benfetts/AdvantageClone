CREATE FUNCTION [dbo].[advfn_nielsen_spot_tv_program_rowcount](
	@NIELSEN_TV_PROGRAM_BOOK_ID int
)
RETURNS bigint
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @totalrows bigint

	SELECT @totalrows = COALESCE(COUNT(1), 0) 
	FROM dbo.NIELSEN_TV_PROGRAM 
	WHERE NIELSEN_TV_PROGRAM_BOOK_ID = @NIELSEN_TV_PROGRAM_BOOK_ID

	RETURN @totalrows
END
GO

GRANT EXEC ON [advfn_nielsen_spot_tv_program_rowcount] TO PUBLIC
GO
