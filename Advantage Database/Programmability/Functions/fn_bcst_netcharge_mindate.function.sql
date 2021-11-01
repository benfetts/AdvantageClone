
CREATE FUNCTION [dbo].[fn_bcst_netcharge_mindate] (	@order_nbr int, @order_type varchar(1))
RETURNS int
AS
BEGIN
	DECLARE @brdcast_per int

	--Radio
	IF @order_type = 'R'
	BEGIN
		SET @brdcast_per = (SELECT MIN(d.BRDCAST_PER)
		FROM dbo.V_RADIO_DETAIL1 AS d
		WHERE @order_nbr = d.ORDER_NBR)
	END

	--Television
	IF @order_type = 'T'
	BEGIN
		SET @brdcast_per = (SELECT MIN(d.BRDCAST_PER)
		FROM dbo.V_TV_DETAIL1 AS d
		WHERE @order_nbr = d.ORDER_NBR)
	END
	
	RETURN @brdcast_per

END
