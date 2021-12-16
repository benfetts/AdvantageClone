IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MARKET' AND COLUMN_NAME = 'IS_PUERTO_RICO') BEGIN

	ALTER TABLE [dbo].[MARKET] ADD [IS_PUERTO_RICO] bit NOT NULL DEFAULT(0)
		
END
GO