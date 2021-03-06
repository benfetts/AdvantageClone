IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'SEC_PWD_HIST')
BEGIN
	CREATE TABLE [dbo].[SEC_PWD_HIST](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[USER_CODE] [varchar](100) NOT NULL,
		[START_DATE] [smalldatetime] NOT NULL,
		[PASSWORD] [varchar](max) NOT NULL,
	 CONSTRAINT [PK_SEC_PWD_HIST] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
