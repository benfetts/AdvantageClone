
CREATE FUNCTION [dbo].[advfn_get_gl_acct]
	( @acct_type smallint, @pm_type varchar(1), @office_code varchar(4), @sc_code varchar(6), @fnc_code varchar(6), @tax_code varchar(4) ) RETURNS varchar(30)
AS
BEGIN
	-- @acct_type:  40 = SALES
	--				42 = COS		
	--				50 = STATE		
	--				51 = COUNTY
	--				52 = CITY	
	DECLARE @gl_acct_sales varchar(30), @gl_acct_cos varchar(30), @gl_acct varchar(30), @rc integer, @row_ct integer
	
	SELECT @pm_type = ( UPPER( @pm_type ))
	SET @rc = 0
		
	IF ( @rc = 0 ) 
	BEGIN
		IF ( @acct_type IN ( 50, 51, 52 ))
		BEGIN
			 SELECT @gl_acct =  CASE @acct_type 
									WHEN 50 THEN GLACODE_TAX_STATE
									WHEN 51 THEN GLACODE_TAX_CNTY
									WHEN 52 THEN GLACODE_TAX_CITY
									ELSE NULL
								END
			   FROM dbo.OFF_TAX_ACCTS
			  WHERE OFFICE_CODE = @office_code
			    AND TAX_CODE = @tax_code 
			
			SET @row_ct = @@ROWCOUNT
			SET @rc = @@ERROR
		END
		
		IF ( @acct_type IN ( 40, 42 ))
		BEGIN			

			IF ( @pm_type = 'P' )
			BEGIN
				IF ( @row_ct = 0 OR @gl_acct IS NULL )	
				BEGIN
					 SELECT @gl_acct = CASE @acct_type WHEN 40 THEN PGLACODE_SALES WHEN 42 THEN PGLACODE_COS ELSE NULL END	
					   FROM dbo.OFF_SC_FNC_ACCTS
					  WHERE FNC_CODE = @fnc_code
						AND SC_CODE = @sc_code
						AND OFFICE_CODE = @office_code
					
					SET @row_ct = @@ROWCOUNT
					SET @rc = @@ERROR
				END
				
				IF ( @row_ct = 0 OR @gl_acct IS NULL )
				BEGIN
					 SELECT @gl_acct =  CASE @acct_type WHEN 40 THEN PGLACODE_SALES WHEN 42 THEN PGLACODE_COS ELSE NULL END
					   FROM dbo.OFF_SC_ACCTS
					  WHERE SC_CODE = @sc_code
						AND OFFICE_CODE = @office_code
			
					SET @row_ct = @@ROWCOUNT
					SET @rc = @@ERROR
				END	

				IF ( @row_ct = 0 OR @gl_acct IS NULL )	
				BEGIN
					 SELECT @gl_acct =  CASE @acct_type WHEN 40 THEN PGLACODE_SALES WHEN 42 THEN PGLACODE_COS ELSE NULL	END	
					   FROM dbo.OFF_FNC_ACCTS
					  WHERE FNC_CODE = @fnc_code
						AND OFFICE_CODE = @office_code

					SET @row_ct = @@ROWCOUNT
					SET @rc = @@ERROR
				END
				
				IF ( @row_ct = 0 OR @gl_acct IS NULL )	
				BEGIN
					 SELECT @gl_acct = CASE @acct_type WHEN 40 THEN PGLACODE_SALES WHEN 42 THEN PGLACODE_COS ELSE NULL END	
					   FROM dbo.OFFICE
					  WHERE OFFICE_CODE = @office_code
					
					SET @row_ct = @@ROWCOUNT
					SET @rc = @@ERROR
				END 					
			END
			
			IF ( @pm_type = 'M' )
			BEGIN		
				IF ( @row_ct = 0 OR @gl_acct IS NULL )
				BEGIN
					 SELECT @gl_acct =  CASE @acct_type WHEN 40 THEN MGLACODE_SALES WHEN 42 THEN MGLACODE_COS ELSE NULL END
					   FROM dbo.OFF_SC_ACCTS
					  WHERE SC_CODE = @sc_code
						AND OFFICE_CODE = @office_code
			
					SET @row_ct = @@ROWCOUNT
					SET @rc = @@ERROR
				END	
				
				IF ( @row_ct = 0 OR @gl_acct IS NULL )	
				BEGIN
					 SELECT @gl_acct = CASE @acct_type WHEN 40 THEN MGLACODE_SALES WHEN 42 THEN MGLACODE_COS ELSE NULL END	
					   FROM dbo.OFFICE
					  WHERE OFFICE_CODE = @office_code
					
					SET @row_ct = @@ROWCOUNT
					SET @rc = @@ERROR
				END 	

			END	 

		END	

	END	

	RETURN @gl_acct
END
GO	
