IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING') BEGIN

	CREATE TABLE [dbo].[MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING](
		[MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID] [int] IDENTITY(1,1) NOT NULL,
		[MEDIA_BROADCAST_WORKSHEET_ID] [int] NOT NULL,
		[VERIFY_RATE] [bit] NOT NULL,
		[VERIFY_NETWORK] [bit] NOT NULL,
		[VERIFY_SCHEDULE] [bit] NOT NULL,
		[VERIFY_DAY] [bit] NOT NULL,
		[VERIFY_TIME] [bit] NOT NULL,
		[VERIFY_TIME_SEP] [bit] NOT NULL,
		[VERIFY_AD_NUMBER] [bit] NOT NULL,
		[VERIFY_LENGTH] [bit] NOT NULL,
		[ADJACENCY_BEFORE] [smallint] NOT NULL,
		[ADJACENCY_AFTER] [smallint] NOT NULL,
		[BOOKEND_MAX_SEPARATION] [smallint] NOT NULL,
	 CONSTRAINT [PK_MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING] PRIMARY KEY CLUSTERED 
	(
		[MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
	
	ALTER TABLE [dbo].[MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_MEDIA_BROADCAST_WORKSHEET] FOREIGN KEY([MEDIA_BROADCAST_WORKSHEET_ID])
	REFERENCES [dbo].[MEDIA_BROADCAST_WORKSHEET] ([MEDIA_BROADCAST_WORKSHEET_ID])

	ALTER TABLE [dbo].[MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING] CHECK CONSTRAINT [FK_MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_MEDIA_BROADCAST_WORKSHEET]

	CREATE UNIQUE NONCLUSTERED INDEX [UNIQUE_MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_MEDIA_BROADCAST_WORKSHEET_ID] ON [dbo].[MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING]
	(
		[MEDIA_BROADCAST_WORKSHEET_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
	
END
GO
