CREATE PROCEDURE [dbo].[advsp_media_manager_update_order_vendor_rep]
	
	@OrderNumber	int,
	@VendorRepCode	varchar(4),
	@Rep1			bit

AS

BEGIN

	DECLARE @MediaType char(1)

	SELECT @MediaType = oh.MediaType 
	FROM (
			SELECT ORDER_NBR, 'I' as MediaType FROM dbo.INTERNET_HEADER 
			UNION
			SELECT ORDER_NBR, 'M' as MediaType FROM dbo.MAGAZINE_HEADER
			UNION
			SELECT ORDER_NBR, 'N' as MediaType FROM dbo.NEWSPAPER_HEADER
			UNION
			SELECT ORDER_NBR, 'O' as MediaType FROM dbo.OUTDOOR_HEADER
			UNION
			SELECT ORDER_NBR, 'R' as MediaType FROM dbo.RADIO_HDR
			UNION
			SELECT ORDER_NBR, 'T' as MediaType FROM dbo.TV_HDR
		) oh
	WHERE oh.ORDER_NBR = @OrderNumber 

	IF @Rep1 = 1 BEGIN
		
		UPDATE dbo.INTERNET_HEADER SET VR_CODE = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'I'
		UPDATE dbo.MAGAZINE_HEADER SET VR_CODE = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'M' 
		UPDATE dbo.NEWSPAPER_HEADER SET VR_CODE = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'N'
		UPDATE dbo.OUTDOOR_HEADER SET VR_CODE = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'O'
		UPDATE dbo.RADIO_HDR SET VR_CODE = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'R'
		UPDATE dbo.TV_HDR SET VR_CODE = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'T'

	END ELSE BEGIN

		UPDATE dbo.INTERNET_HEADER SET VR_CODE2 = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'I'
		UPDATE dbo.MAGAZINE_HEADER SET VR_CODE2 = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'M' 
		UPDATE dbo.NEWSPAPER_HEADER SET VR_CODE2 = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'N'
		UPDATE dbo.OUTDOOR_HEADER SET VR_CODE2 = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'O'
		UPDATE dbo.RADIO_HDR SET VR_CODE2 = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'R'
		UPDATE dbo.TV_HDR SET VR_CODE2 = @VendorRepCode WHERE ORDER_NBR = @OrderNumber AND @MediaType = 'T'

	END

END
GO