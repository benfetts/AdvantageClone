IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PRODUCT' AND COLUMN_NAME = 'CDP_GROUP_ID') BEGIN

	ALTER TABLE [dbo].[PRODUCT] ADD [CDP_GROUP_ID] int NULL
		
	ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_CDP_GROUP] FOREIGN KEY([CDP_GROUP_ID])
	REFERENCES [dbo].[CDP_GROUP] ([CDP_GROUP_ID])
	
	ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_CDP_GROUP]

END
GO