IF NOT EXISTS (SELECT [name] FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_JOB_TRAFFIC_TMPLT_SEC_USER') 
														 AND parent_object_id = OBJECT_ID(N'dbo.JOB_TRAFFIC_TMPLT')) BEGIN

	ALTER TABLE [dbo].[JOB_TRAFFIC_TMPLT]  WITH CHECK ADD  CONSTRAINT [FK_JOB_TRAFFIC_TMPLT_SEC_USER] FOREIGN KEY([CREATED_BY])
	REFERENCES [dbo].[SEC_USER] ([USER_CODE])

	ALTER TABLE [dbo].[JOB_TRAFFIC_TMPLT] CHECK CONSTRAINT [FK_JOB_TRAFFIC_TMPLT_SEC_USER]

END
GO


IF NOT EXISTS (SELECT [name] FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_DOCUMENT_CHECKOUT_SEC_USER') 
														 AND parent_object_id = OBJECT_ID(N'dbo.DOCUMENT_CHECKOUT')) BEGIN

	ALTER TABLE [dbo].[DOCUMENT_CHECKOUT]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENT_CHECKOUT_SEC_USER] FOREIGN KEY([USER_CODE])
	REFERENCES [dbo].[SEC_USER] ([USER_CODE])

	ALTER TABLE [dbo].[DOCUMENT_CHECKOUT] CHECK CONSTRAINT [FK_DOCUMENT_CHECKOUT_SEC_USER]

END
GO

IF NOT EXISTS (SELECT [name] FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_LABEL_SEC_USER') 
														 AND parent_object_id = OBJECT_ID(N'dbo.LABEL')) BEGIN

	ALTER TABLE [dbo].[LABEL]  WITH CHECK ADD  CONSTRAINT [FK_LABEL_SEC_USER] FOREIGN KEY([CREATED_BY])
	REFERENCES [dbo].[SEC_USER] ([USER_CODE])

	ALTER TABLE [dbo].[LABEL] CHECK CONSTRAINT [FK_LABEL_SEC_USER]

END
GO

IF NOT EXISTS (SELECT [name] FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_WV_USER_WORKSPACE_SEC_USER') 
														 AND parent_object_id = OBJECT_ID(N'dbo.WV_USER_WORKSPACE')) BEGIN

	ALTER TABLE [dbo].[WV_USER_WORKSPACE]  WITH CHECK ADD  CONSTRAINT [FK_WV_USER_WORKSPACE_SEC_USER] FOREIGN KEY([USER_CODE])
	REFERENCES [dbo].[SEC_USER] ([USER_CODE])

	ALTER TABLE [dbo].[WV_USER_WORKSPACE] CHECK CONSTRAINT [FK_WV_USER_WORKSPACE_SEC_USER]

END
GO