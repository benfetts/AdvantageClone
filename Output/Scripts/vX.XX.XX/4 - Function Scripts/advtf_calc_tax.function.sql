CREATE FUNCTION [dbo].[advtf_calc_tax] (
	@TAXAPPLYAI smallint,
	@TAXAPPLYC smallint,
	@TAXAPPLYLN smallint,
	@TAXAPPLYNC smallint,
	@TAXAPPLYND smallint,
	@TAXAPPLYR smallint,
	@ADDL_CHARGE decimal(15,2),
	@COMMISSION_AMT decimal(15,2),
	@NET_AMT decimal(15,2),
	@NET_CHARGE decimal(15,2),
	@DISCOUNT decimal(15,2),
	@REBATE_AMT decimal(15,2),
	@STATE_PCT decimal(7,3),
	@COUNTY_PCT decimal(7,3),
	@CITY_PCT decimal(7,3))
RETURNS 
@TAX_TABLE TABLE (
	STATE_TAX decimal(14,2),
	COUNTY_TAX decimal(14,2),
	CITY_TAX decimal(14,2)
)
AS
BEGIN  		
	DECLARE @taxable_amt decimal(15,2),
			@STATE_TAX decimal(14,2),
			@COUNTY_TAX decimal(14,2),
			@CITY_TAX decimal(14,2)

	set @taxable_amt = 0

	IF @TAXAPPLYAI = 1
		set @taxable_amt = @taxable_amt + COALESCE(@ADDL_CHARGE,0) 
	IF @TAXAPPLYLN = 1
		set @taxable_amt = @taxable_amt + COALESCE(@NET_AMT,0)
	IF @TAXAPPLYND = 1
		set @taxable_amt = @taxable_amt + COALESCE(@DISCOUNT,0)
	IF @TAXAPPLYNC = 1
		set @taxable_amt = @taxable_amt + COALESCE(@NET_CHARGE,0)
	IF @TAXAPPLYC = 1
		set @taxable_amt = @taxable_amt + COALESCE(@COMMISSION_AMT,0)
	IF @TAXAPPLYR = 1
		set @taxable_amt = @taxable_amt + COALESCE(@REBATE_AMT,0)

	SET @STATE_TAX = ROUND( COALESCE(@STATE_PCT,0)/100 * @taxable_amt, 2 )
	SET @COUNTY_TAX = ROUND( COALESCE(@COUNTY_PCT,0)/100 * @taxable_amt, 2 )
	SET @CITY_TAX = ROUND( COALESCE(@CITY_PCT,0)/100 * @taxable_amt, 2 )
	
	INSERT INTO @TAX_TABLE (STATE_TAX, COUNTY_TAX, CITY_TAX) VALUES (@STATE_TAX, @COUNTY_TAX, @CITY_TAX)

	RETURN
END
GO


