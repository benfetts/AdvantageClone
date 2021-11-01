IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LEGACY_APP_CTRL') BEGIN

    DROP TABLE [dbo].[LEGACY_APP_CTRL]

END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LEGACY_APP_CTRL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_CODE] [varchar](100) NOT NULL,
	[APP_TYPE] [varchar](10) NOT NULL,
	[ITEM_NBR] [int] NOT NULL,
	[ITEM_SUB1_NBR] [int] NULL,
	[ITEM_SUB2_NBR] [int] NULL,
	[COMPLETE] [bit] NOT NULL

 CONSTRAINT [PK_LEGACY_APP_CTRL_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
