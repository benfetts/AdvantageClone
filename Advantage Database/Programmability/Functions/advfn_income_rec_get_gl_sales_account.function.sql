CREATE FUNCTION advfn_income_rec_get_gl_sales_account (@JobNumber int, @FunctionCode varchar(6))
RETURNS varchar(30) 
AS
BEGIN
	DECLARE @glacode_sales varchar(30)
				
	SELECT @glacode_sales = ( SELECT COALESCE( osfa.PGLACODE_SALES, osa.PGLACODE_SALES, o.PGLACODE_SALES ) 
								FROM dbo.JOB_LOG jl 
						  INNER JOIN dbo.OFFICE o 
								  ON ( jl.OFFICE_CODE = o.OFFICE_CODE )
					 LEFT OUTER JOIN dbo.OFF_SC_ACCTS osa 
								  ON ( jl.OFFICE_CODE = osa.OFFICE_CODE )
								 AND ( jl.SC_CODE = osa.SC_CODE ) 
					 LEFT OUTER JOIN dbo.OFF_SC_FNC_ACCTS osfa
								  ON jl.OFFICE_CODE = osfa.OFFICE_CODE 
								 AND jl.SC_CODE = osfa.SC_CODE 
								 AND osfa.FNC_CODE = @FunctionCode
							   WHERE JOB_NUMBER = @JobNumber )
	
	RETURN @glacode_sales
END
GO
