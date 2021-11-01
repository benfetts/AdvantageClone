IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AD_NUMBER' AND COLUMN_NAME = 'LENGTH') BEGIN

	ALTER TABLE [dbo].[AD_NUMBER] ADD [LENGTH] [int] NULL
	
END
GO