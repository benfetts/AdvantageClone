EXEC advsp_sql_column_prepare 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL', 'PRIMARY_AQH_RATING'
GO

IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL' AND COLUMN_NAME = 'PRIMARY_AQH_RATING') BEGIN

	ALTER TABLE dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL ALTER COLUMN PRIMARY_AQH_RATING decimal(19,2) NOT NULL
	
END
GO

EXEC advsp_sql_column_prepare 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL', 'SECONDARY_AQH_RATING'
GO

IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL' AND COLUMN_NAME = 'SECONDARY_AQH_RATING') BEGIN

	ALTER TABLE dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL ALTER COLUMN SECONDARY_AQH_RATING decimal(19,2) NOT NULL
	
END
GO

EXEC advsp_sql_column_prepare 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL', 'BOOK_PRIMARY_AQH_RATING'
GO

IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL' AND COLUMN_NAME = 'BOOK_PRIMARY_AQH_RATING') BEGIN

	ALTER TABLE dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL ALTER COLUMN BOOK_PRIMARY_AQH_RATING decimal(19,2) NOT NULL
	
END
GO

EXEC advsp_sql_column_prepare 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL', 'BOOK_SECONDARY_AQH_RATING'
GO

IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL' AND COLUMN_NAME = 'BOOK_SECONDARY_AQH_RATING') BEGIN

	ALTER TABLE dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL ALTER COLUMN BOOK_SECONDARY_AQH_RATING decimal(19,2) NOT NULL
	
END
GO