IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_PRINT_DEF' AND COLUMN_NAME = 'SHOW_TOTALNET_ON_GROSS_ORDER') BEGIN

    ALTER TABLE [dbo].[MEDIA_PRINT_DEF] ADD [SHOW_TOTALNET_ON_GROSS_ORDER] [bit] NOT NULL DEFAULT(0);
	
END
GO