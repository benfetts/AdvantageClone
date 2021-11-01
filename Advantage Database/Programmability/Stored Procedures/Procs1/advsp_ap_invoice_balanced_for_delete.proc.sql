CREATE PROCEDURE [dbo].[advsp_ap_invoice_balanced_for_delete] @ap_id int, @transaction_id int
AS
BEGIN

DECLARE	@header_amount DECIMAL(14,2),
		@detail_amount DECIMAL(16,2),
		@internet_amount DECIMAL(16,2),
		@magazine_amount DECIMAL(16,2),
		@newspaper_amount DECIMAL(16,2),
		@outdoor_amount DECIMAL(16,2),
		@radio_amount DECIMAL(16,2),
		@tv_amount DECIMAL(16,2),
		@nonclient_amount DECIMAL(16,2),
		@production_amount DECIMAL(16,2),
		@transaction_amount DECIMAL(16,2),
		@production_line_total DECIMAL(16,2),
		@production_line_total_fields DECIMAL(16,2),
		@internet_line_total DECIMAL(16,2),
		@internet_line_total_fields DECIMAL(16,2),
		@magazine_line_total DECIMAL(16,2),
		@magazine_line_total_fields DECIMAL(16,2),
		@newspaper_line_total DECIMAL(16,2),
		@newspaper_line_total_fields DECIMAL(16,2),
		@outdoor_line_total DECIMAL(16,2),
		@outdoor_line_total_fields DECIMAL(16,2),
		@radio_line_total DECIMAL(16,2),
		@radio_line_total_fields DECIMAL(16,2),
		@tv_line_total DECIMAL(16,2),
		@tv_line_total_fields DECIMAL(16,2)
		
	SELECT @header_amount = SUM(ISNULL(AP_INV_AMT,0) + ISNULL(AP_SALES_TAX,0))
	FROM dbo.AP_HEADER (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @internet_amount = ISNULL(SUM(NET_AMT),0) + ISNULL(SUM(DISCOUNT_AMT),0) + ISNULL(SUM(NETCHARGES),0) + ISNULL(SUM(VENDOR_TAX),0)
	FROM dbo.AP_INTERNET (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @magazine_amount = ISNULL(SUM(DISBURSED_AMT),0)
	FROM dbo.AP_MAGAZINE (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @newspaper_amount = ISNULL(SUM(DISBURSED_AMT),0)
	FROM dbo.AP_NEWSPAPER (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @outdoor_amount = ISNULL(SUM(NET_AMT),0) + ISNULL(SUM(DISCOUNT_AMT),0) + ISNULL(SUM(NETCHARGES),0) + ISNULL(SUM(VENDOR_TAX),0)
	FROM dbo.AP_OUTDOOR (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @radio_amount = ISNULL(SUM(EXT_NET_AMT),0) + ISNULL(SUM(DISC_AMT),0) + ISNULL(SUM(NETCHARGES),0) + ISNULL(SUM(VENDOR_TAX),0)
	FROM dbo.AP_RADIO (NOLOCK)
	WHERE AP_ID=@ap_id

	SELECT @tv_amount = ISNULL(SUM(EXT_NET_AMT),0) + ISNULL(SUM(DISC_AMT),0) + ISNULL(SUM(NETCHARGES),0) + ISNULL(SUM(VENDOR_TAX),0)
	FROM dbo.AP_TV (NOLOCK)
	WHERE AP_ID=@ap_id

	SELECT @nonclient_amount = ISNULL(SUM(AP_GL_AMT),0)
	FROM dbo.AP_GL_DIST (NOLOCK)
	WHERE AP_ID=@ap_id

	SELECT @production_amount = ISNULL(SUM(AP_PROD_EXT_AMT),0) + ISNULL(SUM(EXT_NONRESALE_TAX),0)
	FROM dbo.AP_PRODUCTION (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @transaction_amount = ISNULL(SUM(GLETAMT),-1)
	FROM dbo.GLENTTRL (NOLOCK)
	WHERE GLETXACT = @transaction_id

	SELECT @production_line_total_fields = ISNULL(SUM(AP_PROD_EXT_AMT),0) + ISNULL(SUM(EXT_MARKUP_AMT),0) + ISNULL(SUM(EXT_NONRESALE_TAX),0) +
										   ISNULL(SUM(EXT_STATE_RESALE),0) + ISNULL(SUM(EXT_COUNTY_RESALE),0) + ISNULL(SUM(EXT_CITY_RESALE),0) 
	FROM dbo.AP_PRODUCTION (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @production_line_total = ISNULL(SUM(LINE_TOTAL),0)
	FROM dbo.AP_PRODUCTION (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @internet_line_total_fields = ISNULL(SUM(NET_AMT),0) + ISNULL(SUM(DISCOUNT_AMT),0) + ISNULL(SUM(NETCHARGES),0) +
										 ISNULL(SUM(VENDOR_TAX),0) + ISNULL(SUM(REBATE_AMT),0) + ISNULL(SUM(COMM_AMT),0) +
										 ISNULL(SUM(STATE_TAX),0) + ISNULL(SUM(COUNTY_TAX),0) + ISNULL(SUM(CITY_TAX),0) 
	FROM dbo.AP_INTERNET (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @internet_line_total = ISNULL(SUM(LINE_TOTAL),0)
	FROM dbo.AP_INTERNET (NOLOCK)
	WHERE AP_ID=@ap_id
	
	
	SELECT @magazine_line_total_fields = ISNULL(SUM(NET_PLUS),0) + ISNULL(SUM(DISCOUNT_LN),0) + ISNULL(SUM(NETCHARGES),0) +
										 ISNULL(SUM(VENDOR_TAX),0) + ISNULL(SUM(REBATE_AMT),0) + ISNULL(SUM(COMM_AMT),0) +
										 ISNULL(SUM(STATE_TAX),0) + ISNULL(SUM(COUNTY_TAX),0) + ISNULL(SUM(CITY_TAX),0) 
	FROM dbo.AP_MAGAZINE (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @magazine_line_total = ISNULL(SUM(LINE_TOTAL),0)
	FROM dbo.AP_MAGAZINE (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @newspaper_line_total_fields = ISNULL(SUM(NET_PLUS),0) + ISNULL(SUM(DISCOUNT_LN),0) + ISNULL(SUM(NETCHARGES),0) +
									 	  ISNULL(SUM(VENDOR_TAX),0) + ISNULL(SUM(REBATE_AMT),0) + ISNULL(SUM(COMM_AMT),0) +
								 		  ISNULL(SUM(STATE_TAX),0) + ISNULL(SUM(COUNTY_TAX),0) + ISNULL(SUM(CITY_TAX),0) 
	FROM dbo.AP_NEWSPAPER (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @newspaper_line_total = ISNULL(SUM(LINE_TOTAL),0)
	FROM dbo.AP_NEWSPAPER (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @outdoor_line_total_fields = ISNULL(SUM(NET_AMT),0) + ISNULL(SUM(DISCOUNT_AMT),0) + ISNULL(SUM(NETCHARGES),0) +
										ISNULL(SUM(VENDOR_TAX),0) + ISNULL(SUM(REBATE_AMT),0) + ISNULL(SUM(COMM_AMT),0) +
										ISNULL(SUM(STATE_TAX),0) + ISNULL(SUM(COUNTY_TAX),0) + ISNULL(SUM(CITY_TAX),0) 
	FROM dbo.AP_OUTDOOR (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @outdoor_line_total = ISNULL(SUM(LINE_TOTAL),0)
	FROM dbo.AP_OUTDOOR (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @radio_line_total_fields = ISNULL(SUM(EXT_NET_AMT),0) + ISNULL(SUM(DISC_AMT),0) + ISNULL(SUM(NETCHARGES),0) +
									  ISNULL(SUM(VENDOR_TAX),0) + ISNULL(SUM(REBATE_AMT),0) + ISNULL(SUM(COMM_AMT),0) +
									  ISNULL(SUM(STATE_TAX),0) + ISNULL(SUM(COUNTY_TAX),0) + ISNULL(SUM(CITY_TAX),0) 
	FROM dbo.AP_RADIO (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @radio_line_total = ISNULL(SUM(LINE_TOTAL),0)
	FROM dbo.AP_RADIO (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @tv_line_total_fields = ISNULL(SUM(EXT_NET_AMT),0) + ISNULL(SUM(DISC_AMT),0) + ISNULL(SUM(NETCHARGES),0) +
								   ISNULL(SUM(VENDOR_TAX),0) + ISNULL(SUM(REBATE_AMT),0) + ISNULL(SUM(COMM_AMT),0) +
								   ISNULL(SUM(STATE_TAX),0) + ISNULL(SUM(COUNTY_TAX),0) + ISNULL(SUM(CITY_TAX),0) 
	FROM dbo.AP_TV (NOLOCK)
	WHERE AP_ID=@ap_id
	
	SELECT @tv_line_total = ISNULL(SUM(LINE_TOTAL),0)
	FROM dbo.AP_TV (NOLOCK)
	WHERE AP_ID=@ap_id
	
	--select @header_amount 
	--select (@internet_amount + @magazine_amount + @newspaper_amount + @outdoor_amount + @radio_amount + @tv_amount + @nonclient_amount + @production_amount)
	--select @transaction_amount 
	--select @production_line_total_fields 
	--select @production_line_total

	IF @header_amount = (@internet_amount + @magazine_amount + @newspaper_amount + @outdoor_amount + @radio_amount + @tv_amount + @nonclient_amount + @production_amount) AND
		@transaction_amount = 0 AND (@production_line_total_fields = @production_line_total) 
		AND (@internet_line_total_fields = @internet_line_total) AND (@magazine_line_total_fields = @magazine_line_total) 
		AND (@newspaper_line_total_fields = @newspaper_line_total) AND (@outdoor_line_total_fields = @outdoor_line_total)
		AND (@radio_line_total_fields = @radio_line_total) AND (@tv_line_total_fields = @tv_line_total)
		
			SELECT 1
	ELSE
			SELECT 0
	
END

GO
