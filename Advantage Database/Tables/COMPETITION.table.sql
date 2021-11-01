--GO
--GO
--GO
CREATE TABLE [dbo].[COMPETITION](
	[COMPETITION_ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [varchar](100) NOT NULL,
	[INACTIVE_FLAG] [bit] NOT NULL DEFAULT(0)
 CONSTRAINT [PK_COMPETITION] PRIMARY KEY CLUSTERED 
(
	[COMPETITION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
