/****** Object:  UserDefinedFunction [dbo].[charlist_to_table_int]    Script Date: 9/6/2018 2:25:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- SELECT 
CREATE FUNCTION [dbo].[charlist_to_table_int]
                    (@list      VARCHAR(4000),
                     @delimiter NCHAR(1) = ',')
         RETURNS @tbl TABLE (listpos INT IDENTITY(1, 1) NOT NULL,
                             vint     VARCHAR(6)) AS
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
            INSERT @tbl (vint) VALUES(CONVERT(int,@tmpval))
            SET @tmpstr = SUBSTRING(@tmpstr, @pos + 1, LEN(@tmpstr))
            SET @pos = CHARINDEX(@delimiter, @tmpstr)
         END
         SET @leftover = @tmpstr
      END
      INSERT @tbl(vint) VALUES (CONVERT(int,LTRIM(RTRIM(@leftover))))
   RETURN
   END

GO