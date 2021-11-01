
CREATE  FUNCTION [dbo].[udf_get_expense_totals] (@inv_nbr integer, @type varchar(5))  		  	
RETURNS DECIMAL(15,2) AS  	
BEGIN  
	Declare @CCAmt as Decimal(15,2)
	Declare @TOTAL_DUE as Decimal(15,2)
	Declare @TOTAL as Decimal(15,2)
	Declare @RETURN as Decimal(15,2)

	select @CCAmt = IsNull(sum(AMOUNT), 0)
	from EXPENSE_DETAIL
	where INV_NBR = @inv_nbr
	AND CC_FLAG = 1
	AND LINE_NBR > 0

	select	@TOTAL_DUE = IsNUll(sum(AMOUNT), 0) - @CCAmt, 
 			@TOTAL = IsNull(sum(AMOUNT), 0)
	from EXPENSE_DETAIL
	where INV_NBR = @inv_nbr
	AND LINE_NBR > 0


	SELECT @RETURN = 
	CASE @type
		WHEN 'CC' THEN @CCAmt
		WHEN 'TOTAL' THEN @TOTAL
		WHEN 'DUE' THEN @TOTAL_DUE
	END
	
	RETURN @RETURN
END	
