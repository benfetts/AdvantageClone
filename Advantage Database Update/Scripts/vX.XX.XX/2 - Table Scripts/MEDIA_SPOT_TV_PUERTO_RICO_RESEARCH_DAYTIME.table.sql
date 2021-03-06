IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME') BEGIN
    CREATE TABLE [dbo].[MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME](
	    [MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID] [int] IDENTITY(1,1) NOT NULL,
	    [MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID] [int] NOT NULL,
	    [MONDAY] [bit] NOT NULL,
	    [TUESDAY] [bit] NOT NULL,
	    [WEDNESDAY] [bit] NOT NULL,
	    [THURSDAY] [bit] NOT NULL,
	    [FRIDAY] [bit] NOT NULL,
	    [SATURDAY] [bit] NOT NULL,
	    [SUNDAY] [bit] NOT NULL,
	    [START_TIME] [varchar](10) NOT NULL,
	    [END_TIME] [varchar](10) NOT NULL,
	    [START_HOUR] [smallint] NOT NULL,
	    [END_HOUR] [smallint] NOT NULL,
	    [DAYS] [varchar](100) NOT NULL,
     CONSTRAINT [PK_MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME] PRIMARY KEY CLUSTERED 
    (
	    [MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    ALTER TABLE [dbo].[MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH] FOREIGN KEY([MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID])
    REFERENCES [dbo].[MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH] ([MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID])

    ALTER TABLE [dbo].[MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME] CHECK CONSTRAINT [FK_MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH]
END
GO
