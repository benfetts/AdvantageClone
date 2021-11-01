﻿IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_TRAFFIC_PRINT_DEF' AND COLUMN_NAME = 'INCLUDE_GUIDELINES') BEGIN

	ALTER TABLE [dbo].[MEDIA_TRAFFIC_PRINT_DEF] ADD [INCLUDE_GUIDELINES] bit NOT NULL DEFAULT(0)

END
GO
