IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'SEC_PWD_LOCK')
BEGIN
	CREATE TABLE [dbo].[SEC_PWD_LOCK](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[USER_CODE] [varchar](100) NOT NULL,
		[ATTEMPTS] [int] NULL,
		[LOCK_DATE] [smalldatetime] NULL,
	 CONSTRAINT [PK_SEC_PWD_LOCK] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT [name] FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_SEC_PWD_LOCK_SEC_USER') 
               AND parent_object_id = OBJECT_ID(N'dbo.SEC_PWD_LOCK')) 
BEGIN

	ALTER TABLE [dbo].[SEC_PWD_LOCK]  WITH CHECK ADD  CONSTRAINT [FK_SEC_PWD_LOCK_SEC_USER] FOREIGN KEY([USER_CODE])
	REFERENCES [dbo].[SEC_USER] ([USER_CODE])

	ALTER TABLE [dbo].[SEC_PWD_LOCK] CHECK CONSTRAINT [FK_SEC_PWD_LOCK_SEC_USER]

END
