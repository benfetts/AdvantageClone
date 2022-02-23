CREATE FUNCTION [dbo].[advfn_makegood_get_order_status] ( 
	@order_number integer,
	@media_type char(1)
)
RETURNS varchar(100)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @order_line_status varchar(100),
            @status smallint

	DECLARE @STATII TABLE (
		REV_NBR int NOT NULL,
		LINE_NBR smallint NOT NULL,
		REVISED_DATE datetime,
		[STATUS] smallint
	)

	IF @media_type = 'T' BEGIN
		INSERT @STATII (REV_NBR, LINE_NBR)
		SELECT MAX(REV_NBR) AS REV_NBR, LINE_NBR
		FROM dbo.TV_ORDER_STATUS 
		WHERE ORDER_NBR = @order_number 
		AND [STATUS] IN (19, 20, 15, 4, 5, 16, 17, 18)
		GROUP BY LINE_NBR

		UPDATE s SET REVISED_DATE = (SELECT MAX(os.REVISED_DATE) FROM dbo.TV_ORDER_STATUS os 
									WHERE os.[STATUS] IN (19, 20, 15, 4, 5, 16, 17, 18)
									AND os.ORDER_NBR = @order_number AND os.LINE_NBR = s.LINE_NBR AND os.REV_NBR = s.REV_NBR)
		FROM @STATII s
		
		UPDATE s SET [STATUS] = (SELECT TOP 1 [STATUS] FROM dbo.TV_ORDER_STATUS os 
									WHERE os.[STATUS] IN (19, 20, 15, 4, 5, 16, 17, 18)
									AND os.ORDER_NBR = @order_number AND os.LINE_NBR = s.LINE_NBR AND os.REV_NBR = s.REV_NBR AND os.REVISED_DATE = s.REVISED_DATE)
		FROM @STATII s
	END
	ELSE IF @media_type = 'R' BEGIN
		INSERT @STATII (REV_NBR, LINE_NBR)
		SELECT MAX(REV_NBR) AS REV_NBR, LINE_NBR
		FROM dbo.RADIO_ORDER_STATUS 
		WHERE ORDER_NBR = @order_number 
		AND [STATUS] IN (19, 20, 15, 4, 5, 16, 17, 18)
		GROUP BY LINE_NBR

		UPDATE s SET REVISED_DATE = (SELECT MAX(os.REVISED_DATE) FROM dbo.RADIO_ORDER_STATUS os 
									WHERE os.[STATUS] IN (19, 20, 15, 4, 5, 16, 17, 18)
									AND os.ORDER_NBR = @order_number AND os.LINE_NBR = s.LINE_NBR AND os.REV_NBR = s.REV_NBR)
		FROM @STATII s
		
		UPDATE s SET [STATUS] = (SELECT TOP 1 [STATUS] FROM dbo.RADIO_ORDER_STATUS os 
									WHERE os.[STATUS] IN (19, 20, 15, 4, 5, 16, 17, 18)
									AND os.ORDER_NBR = @order_number AND os.LINE_NBR = s.LINE_NBR AND os.REV_NBR = s.REV_NBR AND os.REVISED_DATE = s.REVISED_DATE)
		FROM @STATII s
	END
	
    SELECT TOP 1 @status = [STATUS] FROM @STATII ORDER BY REVISED_DATE DESC

    IF @status = 19 or @status = 20 
        SELECT @order_line_status = 'Pending Buyer Action'
    ELSE IF @status = 15
		SELECT @order_line_status = 'Pending Buyer Action'
	ELSE IF @status = 4
		SELECT @order_line_status = 'New/Revised Order'
	ELSE IF @status = 17
		SELECT @order_line_status = 'Makegood Offer Rejected'
	ELSE IF @status = 18
		SELECT @order_line_status = 'Makegood Offer Accepted'
	ELSE IF @status = 16
		SELECT @order_line_status = 'Makegood Offer Submitted'
	ELSE
		SELECT @order_line_status = 'Order Accepted'

	--IF EXISTS(SELECT 1 FROM @STATII WHERE [STATUS] = 19 OR [STATUS] = 20)
	--	SELECT @order_line_status = 'Pending Buyer Action'
	--ELSE IF EXISTS(SELECT 1 FROM @STATII WHERE [STATUS] = 15)
	--	SELECT @order_line_status = 'Pending Buyer Action'
	--ELSE IF EXISTS(SELECT 1 FROM @STATII WHERE [STATUS] = 4)
	--	SELECT @order_line_status = 'New/Revised Order'
	--ELSE IF EXISTS(SELECT 1 FROM @STATII WHERE [STATUS] = 17)
	--	SELECT @order_line_status = 'Makegood Offer Rejected'
	--ELSE IF EXISTS(SELECT 1 FROM @STATII WHERE [STATUS] = 18)
	--	SELECT @order_line_status = 'Makegood Offer Accepted'
	--ELSE IF EXISTS(SELECT 1 FROM @STATII WHERE [STATUS] = 16)
	--	SELECT @order_line_status = 'Makegood Offer Submitted'
	--ELSE
	--	SELECT @order_line_status = 'Order Accepted'

	RETURN @order_line_status
END
GO