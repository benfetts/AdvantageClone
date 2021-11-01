
CREATE PROCEDURE [dbo].[advsp_get_next_nbr] @column_name varchar(50), @next_nbr integer OUTPUT
AS

SET NOCOUNT ON

SELECT @next_nbr = ( SELECT LAST_NBR + 1 FROM dbo.ASSIGN_NBR WHERE COLUMNNAME = @column_name )
	
IF ( @next_nbr > 99999999 ) OR ( @next_nbr IS NULL )
	SELECT @next_nbr = 1

UPDATE dbo.ASSIGN_NBR
   SET LAST_NBR = @next_nbr
 WHERE COLUMNNAME = @column_name
