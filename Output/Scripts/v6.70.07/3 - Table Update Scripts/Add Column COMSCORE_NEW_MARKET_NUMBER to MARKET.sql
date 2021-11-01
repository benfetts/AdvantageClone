IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MARKET' AND COLUMN_NAME = 'COMSCORE_NEW_MARKET_NUMBER') BEGIN

	ALTER TABLE [dbo].[MARKET] ADD [COMSCORE_NEW_MARKET_NUMBER] smallint NULL

END
GO

