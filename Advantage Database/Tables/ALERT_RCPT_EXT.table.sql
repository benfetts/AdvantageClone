IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ALERT_RCPT_EXT')
BEGIN
	CREATE TABLE [dbo].[ALERT_RCPT_EXT](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[ALERT_ID] [int] NOT NULL,
		[PRF_EXT_ID] [int] NOT NULL,
		[IS_DISMISSED] [bit] NULL,
		[IS_COMPLETED] [bit] NULL,
		[IS_READ] [bit] NULL,
	 CONSTRAINT [PK_ALERT_RCPT_EXT] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
