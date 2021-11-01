/****** Object:  Table [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA]    Script Date: 10/31/2012 08:03:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA](
	[MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID] [int] IDENTITY(1,1) NOT NULL,
	[MEDIA_PLAN_DTL_ID] [int] NOT NULL,
	[MEDIA_PLAN_ID] [int] NOT NULL,
	[ROW_INDEX] [int] NOT NULL,
	[ENTRY_DATE] [smalldatetime] NOT NULL,
	[DEMO1] [decimal](10, 2) NULL,
	[DEMO2] [decimal](10, 2) NULL,
	[DOLLARS] [decimal](10, 2) NULL,
	[UNITS] [decimal](10, 2) NULL,
	[RATE] [decimal](10, 2) NULL,
	[IMPRESSIONS] [decimal](10, 2) NULL,
	[CLICKS] [decimal](10, 2) NULL,
	[NOTE] [varchar](100) NULL,
	[COLOR] [int] NOT NULL,
 CONSTRAINT [PK_MEDIA_PLAN_DTL_LEVEL_LINE_DATA] PRIMARY KEY CLUSTERED 
(
	[MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_DTL_LEVEL_LINE_DATA_MEDIA_PLAN] FOREIGN KEY([MEDIA_PLAN_ID])
REFERENCES [dbo].[MEDIA_PLAN] ([MEDIA_PLAN_ID])
GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_DTL_LEVEL_LINE_DATA_MEDIA_PLAN]
GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_DTL_LEVEL_LINE_DATA_MEDIA_PLAN_DTL] FOREIGN KEY([MEDIA_PLAN_DTL_ID])
REFERENCES [dbo].[MEDIA_PLAN_DTL] ([MEDIA_PLAN_DTL_ID])
GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_DTL_LEVEL_LINE_DATA_MEDIA_PLAN_DTL]
GO





