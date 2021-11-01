
CREATE FUNCTION [dbo].[charlist_to_table_tsa]
                    (@list      VARCHAR(4000),
                     @delimiter NCHAR(1) = ',')
         RETURNS @tbl TABLE (listpos INT IDENTITY(1, 1) NOT NULL,
                             vstr     VARCHAR(10)) AS
BEGIN
      DECLARE @pos      INT,
              @textpos  INT,
              @chunklen SMALLINT,
              @tmpstr   NVARCHAR(4000),
              @leftover NVARCHAR(4000),
              @tmpval   NVARCHAR(4000)
      SET @textpos = 1
      SET @leftover = ''
      WHILE @textpos <= DATALENGTH(@list) / 2
      BEGIN
         SET @chunklen = 4000 - DATALENGTH(@leftover) / 2
         SET @tmpstr = @leftover + SUBSTRING(@list, @textpos, @chunklen)
         SET @textpos = @textpos + @chunklen
         SET @pos = CHARINDEX(@delimiter, @tmpstr)
         WHILE @pos > 0
         BEGIN
            SET @tmpval = LTRIM(RTRIM(LEFT(@tmpstr, @pos - 1)))
            INSERT @tbl (vstr) VALUES(@tmpval)
            SET @tmpstr = SUBSTRING(@tmpstr, @pos + 1, LEN(@tmpstr))
            SET @pos = CHARINDEX(@delimiter, @tmpstr)
         END
         SET @leftover = @tmpstr
      END
      INSERT @tbl(vstr) VALUES (LTRIM(RTRIM(@leftover)))
   RETURN
   END
