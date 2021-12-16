IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'NIELSEN_DEMO' AND COLUMN_NAME = 'MEDIA_DEMO_SOURCE_ID') BEGIN

	ALTER TABLE dbo.NIELSEN_DEMO ADD [MEDIA_DEMO_SOURCE_ID] INT NOT NULL DEFAULT(0)
	
END
GO