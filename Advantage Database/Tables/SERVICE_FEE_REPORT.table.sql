/****** Object:  Table [dbo].[SERVICE_FEE_REPORT]    Script Date: 04/06/2012 11:50:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[SERVICE_FEE_REPORT](
	[SERVICE_FEE_REPORT_ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [varchar](50) NOT NULL,
	[CREATED_BY] [varchar](100) NOT NULL,
	[CREATED_DATE] [smalldatetime] NOT NULL,
	[ALLOW_CELL_MERGE] [bit] NOT NULL,
	[PRINT_AUTOSIZE_COL] [bit] NOT NULL,
	[PRINT_HEADER] [bit] NOT NULL,
	[PRINT_FOOTER] [bit] NOT NULL,
	[PRINT_GROUP_FOOTER] [bit] NOT NULL,
	[PRINT_SEL_ROWS] [bit] NOT NULL,
	[PRINT_FILTER_INFO] [bit] NOT NULL,
	[SHOW_VIEW_CAPTION] [bit] NOT NULL,
	[SHOW_GROUPBY_BOX] [bit] NOT NULL,
	[SHOW_AUTOFILTER_ROW] [bit] NOT NULL,
	[UPDATED_BY] [varchar](100) NOT NULL,
	[UPDATED_DATE] [smalldatetime] NOT NULL,
	[ACTIVE_FILTER] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_SERVICE_FEE_REPORT] PRIMARY KEY CLUSTERED 
(
	[SERVICE_FEE_REPORT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


