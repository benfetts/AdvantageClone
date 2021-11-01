SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[USER_DEF_TYPE_VALUE](
	[USER_DEF_TYPE_VALUE_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_DEF_TYPE_ID] [int] NOT NULL,
	[CODE] [varchar](MAX) NOT NULL,
	[DESCRIPTION] [varchar](MAX) NOT NULL,
	[ENABLED] [bit] NOT NULL,
 CONSTRAINT [PK_USER_DEF_TYPE_VALUE] PRIMARY KEY CLUSTERED 
(
	[USER_DEF_TYPE_VALUE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


ALTER TABLE [dbo].[USER_DEF_TYPE_VALUE]  WITH CHECK ADD  CONSTRAINT [FK_USER_DEF_TYPE_VALUE_USER_DEF_TYPE] FOREIGN KEY([USER_DEF_TYPE_ID])
REFERENCES [dbo].[USER_DEF_TYPE] ([USER_DEF_TYPE_ID])
GO

ALTER TABLE [dbo].[USER_DEF_TYPE_VALUE] CHECK CONSTRAINT [FK_USER_DEF_TYPE_VALUE_USER_DEF_TYPE]
GO