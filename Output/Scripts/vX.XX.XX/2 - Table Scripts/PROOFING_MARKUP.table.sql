IF EXISTS (SELECT * 
			   FROM sys.foreign_keys 
			   WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROOFING_MARKUP_ALERT]') 
				 AND parent_object_id = OBJECT_ID(N'[dbo].[PROOFING_MARKUP]'))
BEGIN

	ALTER TABLE [dbo].[PROOFING_MARKUP]  DROP CONSTRAINT [FK_PROOFING_MARKUP_ALERT]

END
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PROOFING_MARKUP')
BEGIN

	DROP TABLE [dbo].[PROOFING_MARKUP]

END
/******************************************************************************************************************/
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PROOFING_MARKUP')
BEGIN

	CREATE TABLE [dbo].[PROOFING_MARKUP](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[MARKUP_XML] [xml] NULL,
		[MARKUP] [varchar](max) NULL,
		[EMP_CODE] [varchar](6) NULL,
		[DOCUMENT_ID] [int] NULL,
		[GENERATED_DATE] [smalldatetime] NULL,
		[MARKUP_TYPE_ID] [int] NULL,
		[COMMENT_ID] [int] NULL,
		[THUMBNAIL] [image] NULL,
	 CONSTRAINT [PK_PROOFING_MARKUP] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END

IF NOT EXISTS (SELECT * 
			   FROM sys.foreign_keys 
			   WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROOFING_MARKUP_ALERT]') 
				 AND parent_object_id = OBJECT_ID(N'[dbo].[PROOFING_MARKUP]'))
BEGIN

	ALTER TABLE [dbo].[PROOFING_MARKUP]  WITH CHECK ADD  CONSTRAINT [FK_PROOFING_MARKUP_COMMENT] FOREIGN KEY([COMMENT_ID])
	REFERENCES [dbo].[ALERT_COMMENT] ([COMMENT_ID])
	ALTER TABLE [dbo].[PROOFING_MARKUP] CHECK CONSTRAINT [FK_PROOFING_MARKUP_COMMENT]

END

IF NOT EXISTS (SELECT * 
			   FROM sys.foreign_keys 
			   WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROOFING_MARKUP_DOCUMENTS]') 
				 AND parent_object_id = OBJECT_ID(N'[dbo].[PROOFING_MARKUP]'))
BEGIN

	ALTER TABLE [dbo].[PROOFING_MARKUP]  WITH CHECK ADD  CONSTRAINT [FK_PROOFING_MARKUP_DOCUMENTS] FOREIGN KEY([DOCUMENT_ID])
	REFERENCES [dbo].[DOCUMENTS] ([DOCUMENT_ID])
	ALTER TABLE [dbo].[PROOFING_MARKUP] CHECK CONSTRAINT [FK_PROOFING_MARKUP_DOCUMENTS]

END

IF NOT EXISTS (SELECT * 
			   FROM sys.foreign_keys 
			   WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROOFING_MARKUP_EMPLOYEE_CLOAK]') 
				 AND parent_object_id = OBJECT_ID(N'[dbo].[PROOFING_MARKUP]'))
BEGIN

	ALTER TABLE [dbo].[PROOFING_MARKUP]  WITH CHECK ADD  CONSTRAINT [FK_PROOFING_MARKUP_EMPLOYEE_CLOAK] FOREIGN KEY([EMP_CODE])
	REFERENCES [dbo].[EMPLOYEE_CLOAK] ([EMP_CODE])
	ALTER TABLE [dbo].[PROOFING_MARKUP] CHECK CONSTRAINT [FK_PROOFING_MARKUP_EMPLOYEE_CLOAK]

END

IF NOT EXISTS (SELECT * 
			   FROM sys.foreign_keys 
			   WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROOFING_MARKUP_EMPLOYEE_CLOAK]') 
				 AND parent_object_id = OBJECT_ID(N'[dbo].[PROOFING_MARKUP]'))
BEGIN

	ALTER TABLE [dbo].[PROOFING_MARKUP]  WITH CHECK ADD  CONSTRAINT [FK_PROOFING_MARKUP_EMPLOYEE_CLOAK] FOREIGN KEY([EMP_CODE])
	REFERENCES [dbo].[EMPLOYEE_CLOAK] ([EMP_CODE])
	ALTER TABLE [dbo].[PROOFING_MARKUP] CHECK CONSTRAINT [FK_PROOFING_MARKUP_EMPLOYEE_CLOAK]

END



