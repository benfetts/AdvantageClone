CREATE PROC advsp_media_manager_can_order_change_to_quote

	@OrderNumber	int,
	@MediaFrom		varchar(11),
	@Update			bit = 0

AS

BEGIN

	SET NOCOUNT ON

	DECLARE @PaidWithOrderAmount	decimal(18,2),
			@BilledAmount			decimal(18,2),
			@ApprovedForBilling		bit,
			@APAmount				decimal(18,2),
			@VendorCollected		decimal(18,2)
	
	SET @VendorCollected = (SELECT COALESCE(SUM(NET_AMOUNT), 0) FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = @OrderNumber)

	SELECT @PaidWithOrderAmount = (SELECT COALESCE(SUM(CARD_AMOUNT), 0) FROM dbo.VCC_CARD WHERE ORDER_NBR = @OrderNumber)

	IF @MediaFrom = 'Internet' BEGIN

		SELECT @BilledAmount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ) FROM dbo.INTERNET_DETAIL d WHERE d.ORDER_NBR = @OrderNumber AND d.AR_INV_NBR IS NOT NULL
		
		IF EXISTS(SELECT 1 FROM dbo.INTERNET_ORDER_STATUS WHERE ORDER_NBR = @OrderNumber AND STATUS = 11) SET @ApprovedForBilling = 1 ELSE SET @ApprovedForBilling = 0
		
		SELECT @APAmount = COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISCOUNT_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
		FROM dbo.AP_INTERNET ap WHERE ap.ORDER_NBR = @OrderNumber AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )

	END ELSE IF @MediaFrom = 'Magazine' BEGIN

		SELECT @BilledAmount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ) FROM dbo.MAGAZINE_DETAIL d WHERE d.ORDER_NBR = @OrderNumber AND d.AR_INV_NBR IS NOT NULL
		
		IF EXISTS(SELECT 1 FROM dbo.MAGAZINE_ORDER_STATUS WHERE ORDER_NBR = @OrderNumber AND STATUS = 11) SET @ApprovedForBilling = 1 ELSE SET @ApprovedForBilling = 0
		
		SELECT @APAmount = COALESCE( SUM( COALESCE( ap.DISBURSED_AMT, 0.00 )), 0.00 )
		FROM dbo.AP_MAGAZINE ap WHERE ap.ORDER_NBR = @OrderNumber AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )

	END ELSE IF @MediaFrom = 'Newspaper' BEGIN
		
		SELECT @BilledAmount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ) FROM dbo.NEWSPAPER_DETAIL d WHERE d.ORDER_NBR = @OrderNumber AND d.AR_INV_NBR IS NOT NULL
		
		IF EXISTS(SELECT 1 FROM dbo.NEWSPAPER_ORDER_STATUS WHERE ORDER_NBR = @OrderNumber AND STATUS = 11) SET @ApprovedForBilling = 1 ELSE SET @ApprovedForBilling = 0
		
		SELECT @APAmount = COALESCE( SUM( COALESCE( ap.DISBURSED_AMT, 0.00 )), 0.00 )
		FROM dbo.AP_NEWSPAPER ap WHERE ap.ORDER_NBR = @OrderNumber AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )

	END ELSE IF @MediaFrom = 'Out Of Home' BEGIN
	
		SELECT @BilledAmount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ) FROM dbo.OUTDOOR_DETAIL d WHERE d.ORDER_NBR = @OrderNumber AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.OUTDOOR_ORDER_STATUS WHERE ORDER_NBR = @OrderNumber AND STATUS = 11) SET @ApprovedForBilling = 1 ELSE SET @ApprovedForBilling = 0

		SELECT @APAmount = COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISCOUNT_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
		FROM dbo.AP_OUTDOOR ap WHERE ap.ORDER_NBR = @OrderNumber AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )

	END ELSE IF @MediaFrom = 'Radio' BEGIN
	
		SELECT @BilledAmount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ) FROM dbo.RADIO_DETAIL d WHERE d.ORDER_NBR = @OrderNumber AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.RADIO_ORDER_STATUS WHERE ORDER_NBR = @OrderNumber AND STATUS = 11) SET @ApprovedForBilling = 1 ELSE SET @ApprovedForBilling = 0

		SELECT @APAmount = COALESCE( SUM( COALESCE( ap.EXT_NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISC_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
		FROM dbo.AP_RADIO ap WHERE ap.ORDER_NBR = @OrderNumber AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )

	END ELSE IF @MediaFrom = 'TV' BEGIN
	
		SELECT @BilledAmount = COALESCE( SUM( d.BILLING_AMT ), 0.00 ) FROM dbo.TV_DETAIL d WHERE d.ORDER_NBR = @OrderNumber AND d.AR_INV_NBR IS NOT NULL

		IF EXISTS(SELECT 1 FROM dbo.TV_ORDER_STATUS WHERE ORDER_NBR = @OrderNumber AND STATUS = 11) SET @ApprovedForBilling = 1 ELSE SET @ApprovedForBilling = 0

		SELECT @APAmount = COALESCE( SUM( COALESCE( ap.EXT_NET_AMT, 0.00 )) - SUM(ABS(COALESCE(ap.DISC_AMT,0))) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
		FROM dbo.AP_TV ap WHERE ap.ORDER_NBR = @OrderNumber AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )

	END

	IF @BilledAmount = 0 AND @PaidWithOrderAmount = 0 AND @ApprovedForBilling = 0 AND @APAmount = 0 AND @VendorCollected = 0 BEGIN

		IF @Update = 1
		BEGIN
			UPDATE dbo.INTERNET_HEADER SET [STATUS] = 1 WHERE ORDER_NBR = @OrderNumber AND @MediaFrom = 'Internet'
			UPDATE dbo.MAGAZINE_HEADER SET [STATUS] = 1 WHERE ORDER_NBR = @OrderNumber AND @MediaFrom = 'Magazine'
			UPDATE dbo.NEWSPAPER_HEADER SET [STATUS] = 1 WHERE ORDER_NBR = @OrderNumber AND @MediaFrom = 'Newspaper'
			UPDATE dbo.OUTDOOR_HEADER SET [STATUS] = 1 WHERE ORDER_NBR = @OrderNumber AND @MediaFrom = 'Out Of Home'
			UPDATE dbo.RADIO_HDR SET [STATUS] = 1 WHERE ORDER_NBR = @OrderNumber AND @MediaFrom = 'Radio'
			UPDATE dbo.TV_HDR SET [STATUS] = 1 WHERE ORDER_NBR = @OrderNumber AND @MediaFrom = 'TV'
		END

		SELECT 1

	END ELSE BEGIN

		SELECT 0

	END

END

GO