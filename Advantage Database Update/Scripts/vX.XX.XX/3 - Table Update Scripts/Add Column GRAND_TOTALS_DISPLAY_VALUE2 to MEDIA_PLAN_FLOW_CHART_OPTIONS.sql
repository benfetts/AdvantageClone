IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_PLAN_DTL_LEVEL_LINE_DATA' AND COLUMN_NAME = 'GRAND_TOTALS_DISPLAY_VALUE2') BEGIN

	ALTER TABLE [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] ADD [GRAND_TOTALS_DISPLAY_VALUE2] int NOT NULL DEFAULT(0)
		
END
GO