CREATE PROCEDURE advsp_media_rfp_header_delete
	@VN_CODE varchar(6),
	@MEDIA_BROADCAST_WORKSHEET_MARKET_ID int
AS

DECLARE @MEDIA_RFP_HEADER_ID int

SELECT @MEDIA_RFP_HEADER_ID = MEDIA_RFP_HEADER_ID 
FROM dbo.MEDIA_RFP_HEADER
WHERE VN_CODE = @VN_CODE 
AND MEDIA_BROADCAST_WORKSHEET_MARKET_ID = @MEDIA_BROADCAST_WORKSHEET_MARKET_ID

DELETE dbo.MEDIA_RFP_AVAILABLE_LINE_SPOT 
WHERE MEDIA_RFP_AVAILABLE_LINE_ID IN (
	SELECT MEDIA_RFP_AVAILABLE_LINE_ID FROM dbo.MEDIA_RFP_AVAILABLE_LINE 
	WHERE MEDIA_RFP_HEADER_ID = @MEDIA_RFP_HEADER_ID
)

DELETE dbo.MEDIA_RFP_DEMO 
WHERE MEDIA_RFP_AVAILABLE_LINE_ID IN (
	SELECT MEDIA_RFP_AVAILABLE_LINE_ID FROM dbo.MEDIA_RFP_AVAILABLE_LINE 
	WHERE MEDIA_RFP_HEADER_ID = @MEDIA_RFP_HEADER_ID
)

DELETE dbo.MEDIA_RFP_AVAILABLE_LINE
WHERE MEDIA_RFP_AVAILABLE_LINE_ID IN (
	SELECT MEDIA_RFP_AVAILABLE_LINE_ID FROM dbo.MEDIA_RFP_AVAILABLE_LINE 
	WHERE MEDIA_RFP_HEADER_ID = @MEDIA_RFP_HEADER_ID
)

DELETE dbo.MEDIA_RFP_HEADER_STATUS
WHERE MEDIA_RFP_HEADER_ID = @MEDIA_RFP_HEADER_ID

DELETE dbo.MEDIA_RFP_HEADER
WHERE MEDIA_RFP_HEADER_ID = @MEDIA_RFP_HEADER_ID

GO