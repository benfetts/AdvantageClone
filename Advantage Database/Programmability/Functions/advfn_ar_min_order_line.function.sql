CREATE FUNCTION [dbo].[advfn_ar_min_order_line](
	@invoice_number		int,
	@order_nbr			int)
	
--insert the next (3) statements at the top of the script while debugging
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advfn_ar_min_order_line]') and xtype in (N'FN', N'IF', N'TF'))
--drop function [dbo].[advfn_ar_min_order_line]
--GO

-- returns the minimum line number for an order number on an invoice
-- #00 12/18/12 - Initial release
		
RETURNS int
AS
BEGIN
	DECLARE @line_number int
	SELECT @line_number = (
		SELECT MIN(LINE_NBR)
		FROM dbo.ARINV_MEDIA
		WHERE AR_INV_NBR = @invoice_number
			AND ORDER_NBR = @order_nbr)
	
	RETURN @line_number
END
GO