CREATE TABLE [dbo].[AULU](
	[AULU_ID] [int] IDENTITY(1,1) NOT NULL,
	[AULU_TYPE] [tinyint] NOT NULL,
	[AULU_ASSIGN] [varchar](max) NOT NULL,
 CONSTRAINT [PK_AULU] PRIMARY KEY CLUSTERED 
(
	[AULU_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


