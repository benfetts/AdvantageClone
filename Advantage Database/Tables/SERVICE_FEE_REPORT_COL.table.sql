/****** Object:  Table [dbo].[SERVICE_FEE_REPORT_COL]    Script Date: 04/06/2012 11:51:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[SERVICE_FEE_REPORT_COL](
	[SERVICE_FEE_REPORT_COL_ID] [int] IDENTITY(1,1) NOT NULL,
	[SERVICE_FEE_REPORT_ID] [int] NOT NULL,
	[FIELD_NAME] [varchar](50) NOT NULL,
	[HEADER_TEXT] [varchar](50) NOT NULL,
	[IS_VISIBLE] [bit] NOT NULL,
	[SORT_ORDER] [int] NOT NULL,
	[SORT_INDEX] [int] NOT NULL,
	[GROUP_INDEX] [int] NOT NULL,
	[WIDTH] [int] NOT NULL,
	[VISIBLE_INDEX] [int] NOT NULL,
 CONSTRAINT [PK_SERVICE_FEE_REPORT_COL] PRIMARY KEY CLUSTERED 
(
	[SERVICE_FEE_REPORT_COL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SERVICE_FEE_REPORT_COL]  WITH CHECK ADD  CONSTRAINT [FK_SERVICE_FEE_REPORT_COL] FOREIGN KEY([SERVICE_FEE_REPORT_ID])
REFERENCES [dbo].[SERVICE_FEE_REPORT] ([SERVICE_FEE_REPORT_ID])
GO

ALTER TABLE [dbo].[SERVICE_FEE_REPORT_COL] CHECK CONSTRAINT [FK_SERVICE_FEE_REPORT_COL]
GO


