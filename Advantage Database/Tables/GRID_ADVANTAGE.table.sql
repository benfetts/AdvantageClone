CREATE TABLE [dbo].[GRID_ADVANTAGE](
	[GRID_ID] [int] IDENTITY(1,1) NOT NULL,
	[GRID_TYPE] [int] NOT NULL,
	[USER_CODE] [varchar](100) NOT NULL,
	[XML_LAYOUT] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_GRID_ADVANTAGE] PRIMARY KEY CLUSTERED 
(
	[GRID_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
