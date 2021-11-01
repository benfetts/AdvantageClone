
CREATE FUNCTION [dbo].[fn_charlist_to_table2] (@list nvarchar(4000))
   RETURNS @tbl TABLE (vstr varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS) AS
BEGIN
   DECLARE @pos        int,
           @nextpos    int,
           @valuelen   int

   SELECT @pos = 0, @nextpos = 1

   WHILE @nextpos > 0
   BEGIN
      SELECT @nextpos = charindex(',', @list, @pos + 1)
      SELECT @valuelen = CASE WHEN @nextpos > 0
                              THEN @nextpos
                              ELSE len(@list) + 1
                         END - @pos - 1
      INSERT @tbl (vstr)
         VALUES (substring(@list, @pos + 1, @valuelen))
      SELECT @pos = @nextpos
   END
  RETURN
END
