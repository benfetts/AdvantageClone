
CREATE FUNCTION dbo.advfn_get_service_months ( @start_date smalldatetime, @end_date smalldatetime )
RETURNS smallint
AS
BEGIN
	DECLARE @month_count smallint
	DECLARE @sign tinyint

	SET @month_count = 0
	
	IF ( @start_date < '1900-01-01' OR @start_date > '2076-06-06' OR @start_date IS NULL )
		SET @month_count = NULL

	IF ( @end_date < '1900-01-01' OR @end_date > '2076-06-06' OR @end_date IS NULL )
		SET @month_count = NULL
		
	IF ( @month_count = 0 )
	BEGIN
		SET @month_count = (( YEAR( @end_date ) - YEAR( @start_date )) * 12 )
		SET @month_count = @month_count + ( MONTH( @end_date ) - MONTH( @start_date ))
		
		--IF ( SIGN( @month_count ) = 1 AND ( DAY( @start_date ) > DAY( @end_date )))
		--	SET @month_count = @month_count - 1
		--IF ( SIGN( @month_count ) = -1 AND ( DAY( @start_date ) < DAY( @end_date )))
		--	SET @month_count = @month_count + 1
	END	
	RETURN COALESCE( @month_count, 0 )
END
