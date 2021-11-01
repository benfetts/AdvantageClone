﻿CREATE TABLE [dbo].[SERVICE_SETTING](
	[SERVICE_SETTING_ID] [int] NOT NULL,
	[NATIONAL_PATH] [varchar](max) NOT NULL,
	[TIMER_MINUTES] [int] NOT NULL,
	CONSTRAINT [PK_SERVICE_SETTING] PRIMARY KEY CLUSTERED ([SERVICE_SETTING_ID] ASC)WITH (FILLFACTOR = 90)
);