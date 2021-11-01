IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_PLAN' AND COLUMN_NAME = 'MEDIA_PLAN_TEMPLATE_HEADER_ID') BEGIN

	ALTER TABLE [dbo].[MEDIA_PLAN] ADD [MEDIA_PLAN_TEMPLATE_HEADER_ID] [int] NULL
		
END
GO