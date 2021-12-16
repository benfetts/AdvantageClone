IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'VENDOR' AND COLUMN_NAME = 'NPR_STATION_ID') BEGIN

	ALTER TABLE [dbo].[VENDOR] ADD [NPR_STATION_ID] [int] NULL
	
END
GO