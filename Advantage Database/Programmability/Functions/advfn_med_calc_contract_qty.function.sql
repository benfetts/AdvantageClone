CREATE FUNCTION [advfn_med_calc_contract_qty]
(
	-- Add the parameters for the function here
	@quantity integer,
	@columns decimal (6, 2),
	@inches decimal (6, 2),
	@lines decimal (11, 4),
	@order_type varchar (2),
	@rate_type varchar (3)
)
RETURNS decimal (14,4)
AS

BEGIN
	DECLARE @column_line_qty decimal (14,4)
	DECLARE @contract_qty decimal (14,4)
	
	IF @order_type =  'NP'
		BEGIN
			--SET @quantity = adw_dtl.Object.quantity[al_row]
			--SET @columns = adw_dtl.Object.print_columns[al_row]
			--SET @inches = adw_dtl.Object.print_inches[al_row]
			--SET @lines = adw_dtl.Object.print_lines[al_row]
			IF COALESCE(@columns, 0) <> 0 AND COALESCE(@inches, 0) <> 0 
				BEGIN
					SET @column_line_qty = (@columns * @inches)
					SET @contract_qty = @column_line_qty * @quantity
					SET @lines = (@columns * @inches)
				END
			ELSE
				BEGIN
					IF COALESCE(@lines, 0) <> 0 
						BEGIN
							SET @column_line_qty = @lines
							SET @contract_qty = @column_line_qty * @quantity
							IF @rate_type = 'CPM' 
								SET @contract_qty = @contract_qty / 1000
						END
				END
		END
	ELSE -- Other order types = quantity
		SET @contract_qty = @quantity

	IF @contract_qty > 0
		SET @contract_qty = @contract_qty /* Do Nothing */
	ELSE
		BEGIN
			SET @contract_qty = @quantity
		END


	RETURN(@contract_qty)
END
GO
