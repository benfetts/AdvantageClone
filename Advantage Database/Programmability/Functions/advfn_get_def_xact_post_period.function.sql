CREATE  FUNCTION [dbo].[advfn_get_def_xact_post_period] ( @sale_post_period_code varchar(6), @post_period_code varchar(6) )  		  	
RETURNS VARCHAR(6) AS  	
BEGIN  
	DECLARE @valid_post_period_code varchar(6),
			@current_pp varchar(6),
			@sale_pp_closed bit
	
	SELECT @sale_pp_closed = CASE WHEN PPARCURMTH = 'X' THEN 1 ELSE 0 END
	FROM dbo.POSTPERIOD
	WHERE PPPERIOD = @sale_post_period_code 
	
	SELECT @current_pp = PPPERIOD
	FROM dbo.POSTPERIOD
	WHERE PPARCURMTH = 'C'

	IF @current_pp IS NULL
		SET @current_pp = @post_period_code
	
	IF ( @sale_post_period_code < @current_pp AND @sale_pp_closed = 0 )
		SET @valid_post_period_code = @sale_post_period_code 
	ELSE IF ( @sale_post_period_code < @current_pp AND @sale_pp_closed = 1 )
		SET @valid_post_period_code = @post_period_code 
	ELSE
		SET @valid_post_period_code = @sale_post_period_code 
		
	RETURN @valid_post_period_code 
END	
GO