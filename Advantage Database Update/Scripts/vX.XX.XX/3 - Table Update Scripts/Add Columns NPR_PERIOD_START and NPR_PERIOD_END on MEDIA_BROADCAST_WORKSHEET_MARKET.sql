IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_MARKET' AND COLUMN_NAME = 'PERIOD_START') BEGIN

	ALTER TABLE [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] ADD [PERIOD_START] [smalldatetime] NULL
		
END
GO

IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_MARKET' AND COLUMN_NAME = 'PERIOD_END') BEGIN

	ALTER TABLE [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] ADD [PERIOD_END] [smalldatetime] NULL
		
END
GO
