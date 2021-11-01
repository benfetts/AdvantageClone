CREATE FUNCTION [dbo].[advfn_makegood_get_order_status_date] ( 
	@order_number integer
)
RETURNS datetime
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @status_datetime datetime

	SELECT TOP 1 @status_datetime = REVISED_DATE 
	FROM
		(
		SELECT TOP 1 REVISED_DATE FROM dbo.RADIO_ORDER_STATUS
		WHERE ORDER_NBR = @order_number
		AND REV_NBR = (
						SELECT MAX(REV_NBR)
						FROM dbo.RADIO_DETAIL
						WHERE ORDER_NBR = @order_number
						AND ACTIVE_REV = 1)
		ORDER BY REVISED_DATE DESC, REC_ID DESC
		UNION
		SELECT TOP 1 REVISED_DATE FROM dbo.TV_ORDER_STATUS
		WHERE ORDER_NBR = @order_number
		AND REV_NBR = (
						SELECT MAX(REV_NBR)
						FROM dbo.TV_DETAIL
						WHERE ORDER_NBR = @order_number
						AND ACTIVE_REV = 1)
		ORDER BY REVISED_DATE DESC, REC_ID DESC
		) Statuses

	RETURN @status_datetime
END

GO
