IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CLIENT' AND COLUMN_NAME = 'IS_NCC_SUBSCRIBED') 
BEGIN

	ALTER TABLE [dbo].[CLIENT] ADD [IS_NCC_SUBSCRIBED] bit DEFAULT(0) NOT NULL;
	
END
GO