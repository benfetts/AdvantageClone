CREATE TABLE [dbo].[COMSCORE_TV_BOOK](
	[COMSCORE_TV_BOOK_ID] [int] IDENTITY(1,1) NOT NULL,
	[YEAR] [smallint] NOT NULL,
	[MONTH] [smallint] NOT NULL,
	[STREAM] [char](2) NOT NULL,
	[START_DATETIME] [smalldatetime] NOT NULL,
	[END_DATETIME] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_COMSCORE_TV_BOOK] PRIMARY KEY CLUSTERED 
(
	[COMSCORE_TV_BOOK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO