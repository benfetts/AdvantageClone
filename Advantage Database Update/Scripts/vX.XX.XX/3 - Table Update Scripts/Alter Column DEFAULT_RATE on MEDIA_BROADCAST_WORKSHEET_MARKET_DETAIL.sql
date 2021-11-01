EXEC advsp_sql_column_prepare 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL', 'DEFAULT_RATE'
GO

IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL' AND COLUMN_NAME = 'DEFAULT_RATE') BEGIN

	ALTER TABLE dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL ALTER COLUMN DEFAULT_RATE decimal(16,4) NOT NULL
	
END
GO