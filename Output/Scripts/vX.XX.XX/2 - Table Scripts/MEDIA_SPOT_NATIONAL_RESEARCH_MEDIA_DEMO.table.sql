CREATE TABLE [dbo].[MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO](
	[MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO_ID] [int] IDENTITY(1,1) NOT NULL,
	[MEDIA_SPOT_NATIONAL_RESEARCH_ID] [int] NOT NULL,
	[ORDER] [smallint] NOT NULL,
	[MEDIA_DEMO_ID] [int] NOT NULL,
CONSTRAINT [PK_MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO] PRIMARY KEY CLUSTERED 
(
	[MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO_MEDIA_SPOT_NATIONAL_RESEARCH] FOREIGN KEY([MEDIA_SPOT_NATIONAL_RESEARCH_ID])
REFERENCES [dbo].[MEDIA_SPOT_NATIONAL_RESEARCH] ([MEDIA_SPOT_NATIONAL_RESEARCH_ID])
GO

ALTER TABLE [dbo].[MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO] CHECK CONSTRAINT [FK_MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO_MEDIA_SPOT_NATIONAL_RESEARCH]
GO

ALTER TABLE [dbo].[MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO_MEDIA_DEMO] FOREIGN KEY([MEDIA_DEMO_ID])
REFERENCES [dbo].[MEDIA_DEMO] ([MEDIA_DEMO_ID])
GO

ALTER TABLE [dbo].[MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO] CHECK CONSTRAINT [FK_MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO_MEDIA_DEMO]
GO
