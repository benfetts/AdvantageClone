CREATE FUNCTION [dbo].[advfn_ar_aged_amount](
	@invoice_date			smalldatetime,
	@due_date				smalldatetime,
	@aging_date				smalldatetime,
	@aging_opt				tinyint,
	@aging_interval			int,
	@amount					decimal(15,2))
	
-- advfn_ar_aging_interval
-- returns the invoice amount or "0" based on the aging interval
-- @aging_opt 1=Use Invoice Date, 2=Use Invoice Due Date
-- #00 12/03/12 - Initial release
		
RETURNS decimal(15,2)
AS
BEGIN
	DECLARE @aging_days int
	DECLARE @aged_amount decimal(15,2)
	SET @aged_amount = 0
	
	--Determine aging days
	IF @aging_opt = 1
		SET @aging_days = DATEDIFF(day, @invoice_date, @aging_date)
	IF @aging_opt = 2
		SET @aging_days = DATEDIFF(day, @due_date, @aging_date)
		
	--Determine aged amount
	IF @aging_interval = 0	
		IF @aging_days <= @aging_interval + 30
			SET @aged_amount = @amount
	IF @aging_interval > 0 AND @aging_interval < 120	
		IF @aging_days > @aging_interval AND @aging_days <= @aging_interval + 30
			SET @aged_amount = @amount
	IF @aging_interval = 120	
		IF @aging_days > @aging_interval
			SET @aged_amount = @amount
	
	--RETURN @aging_days		--optional return for testing		
	RETURN @aged_amount 	
END