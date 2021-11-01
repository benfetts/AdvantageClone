CREATE PROCEDURE [dbo].[advsp_nielsen_tv_book_replace]
       @OldNielsenTVBookID AS int,
       @NewNielsenTVBookID AS int
AS
BEGIN

	UPDATE 
		dbo.MEDIA_BROADCAST_WORKSHEET_MARKET 
	SET 
		SHAREBOOK_NIELSEN_TV_BOOK_ID = @NewNielsenTVBookID 
	WHERE 
		SHAREBOOK_NIELSEN_TV_BOOK_ID = @OldNielsenTVBookID

	UPDATE 
		dbo.MEDIA_BROADCAST_WORKSHEET_MARKET 
	SET 
		HUTPUT_NIELSEN_TV_BOOK_ID = @NewNielsenTVBookID 
	WHERE 
		HUTPUT_NIELSEN_TV_BOOK_ID = @OldNielsenTVBookID
		
	UPDATE 
		dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_NIELSEN_TV_BOOK 
	SET 
		NIELSEN_TV_BOOK_ID = @NewNielsenTVBookID 
	WHERE 
		NIELSEN_TV_BOOK_ID = @OldNielsenTVBookID
		
	UPDATE 
		dbo.MEDIA_BROADCAST_WORKSHEET_PRE_POST_REPORT_CRITERIA 
	SET 
		SHAREBOOK_NIELSEN_TV_BOOK_ID = @NewNielsenTVBookID 
	WHERE 
		SHAREBOOK_NIELSEN_TV_BOOK_ID = @OldNielsenTVBookID
		
	UPDATE 
		dbo.MEDIA_BROADCAST_WORKSHEET_PRE_POST_REPORT_CRITERIA 
	SET 
		HUTPUT_NIELSEN_TV_BOOK_ID = @NewNielsenTVBookID 
	WHERE 
		HUTPUT_NIELSEN_TV_BOOK_ID = @OldNielsenTVBookID
		
	UPDATE 
		dbo.MEDIA_SPOT_TV_RESEARCH_BOOK 
	SET 
		SHARE_BOOK_ID = @NewNielsenTVBookID 
	WHERE 
		SHARE_BOOK_ID = @OldNielsenTVBookID

	UPDATE 
		dbo.MEDIA_SPOT_TV_RESEARCH_BOOK 
	SET 
		HPUT_BOOK_ID = @NewNielsenTVBookID 
	WHERE 
		HPUT_BOOK_ID = @OldNielsenTVBookID

END
GO


