
CREATE FUNCTION [dbo].[advtf_brdcast_month_table] ( @start_date smalldatetime, @end_date smalldatetime )
RETURNS @tbl TABLE ( listpos int IDENTITY(1, 1) NOT NULL, month_ind tinyint, month_short varchar(3), brdcast_yr integer ) 
AS
BEGIN
	DECLARE @i tinyint, @j tinyint, @brdcast_yr1 integer, @brdcast_yr2 integer
	
	SET @brdcast_yr1 = DATEPART( yyyy, @start_date )
	SET @brdcast_yr2 = DATEPART( yyyy, @end_date )
	
	SET @i = DATEPART( month, @start_date )
	
	IF ( @brdcast_yr1 + 1 = @brdcast_yr2 )
		SET @j = 12
	ELSE
		SET @j = DATEPART( month, @end_date )	
	
	WHILE ( @i <= @j )
	BEGIN
		INSERT INTO @tbl( month_ind, month_short, brdcast_yr ) 
			 VALUES ( @i, LEFT( UPPER( DATENAME( month, CAST( @brdcast_yr1 AS varchar(4)) + '-' + CAST( @i AS varchar(2)) + '-01' )), 3 ), @brdcast_yr1 )
		SET @i = @i + 1 
	END	

	IF ( @brdcast_yr1 + 1 = @brdcast_yr2 )
	BEGIN
		SET @i = 1		
		SET @j = DATEPART( month, @end_date )
		WHILE ( @i <= @j )
		BEGIN
			INSERT INTO @tbl( month_ind, month_short, brdcast_yr ) 
				 VALUES ( @i, LEFT( UPPER( DATENAME( month, CAST( @brdcast_yr2 AS varchar(4)) + '-' + CAST( @i AS varchar(2)) + '-01' )), 3 ), @brdcast_yr2 )
			SET @i = @i + 1 
		END	
	END

RETURN
END

