IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRINT_ORDER' AND COLUMN_NAME = 'MEDIA_CHANNEL_ID') BEGIN

	    ALTER TABLE [dbo].[PRINT_ORDER] ADD [MEDIA_CHANNEL_ID] int NULL
			
END
GO


