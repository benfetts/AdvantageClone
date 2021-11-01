--A
IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_TEMPLATE_PRODUCT') BEGIN

	CREATE TABLE [dbo].[MEDIA_PLAN_TEMPLATE_PRODUCT](
		[MEDIA_PLAN_TEMPLATE_PRODUCT_ID] [int] IDENTITY(1,1) NOT NULL,
        [CL_CODE] [varchar](6) NOT NULL,
        [DIV_CODE] [varchar](6) NOT NULL,
        [PRD_CODE] [varchar](6) NOT NULL,
        [MEDIA_PLAN_TEMPLATE_HEADER_ID] [int] NOT NULL,
		[IS_DEFAULT] [bit] NOT NULL,
	CONSTRAINT [PK_MEDIA_PLAN_TEMPLATE_PRODUCT] PRIMARY KEY CLUSTERED 
	(
		[MEDIA_PLAN_TEMPLATE_PRODUCT_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_PRODUCT_PRODUCT] FOREIGN KEY([CL_CODE], [DIV_CODE], [PRD_CODE])
	REFERENCES [dbo].[PRODUCT] ([CL_CODE], [DIV_CODE], [PRD_CODE])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_PRODUCT] CHECK CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_PRODUCT_PRODUCT]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_PRODUCT_MEDIA_PLAN_TEMPLATE_HEADER] FOREIGN KEY([MEDIA_PLAN_TEMPLATE_HEADER_ID])
	REFERENCES [dbo].[MEDIA_PLAN_TEMPLATE_HEADER] ([MEDIA_PLAN_TEMPLATE_HEADER_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_PRODUCT] CHECK CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_PRODUCT_MEDIA_PLAN_TEMPLATE_HEADER]
    
    CREATE UNIQUE NONCLUSTERED INDEX [MEDIA_PLAN_TEMPLATE_PRODUCT_UNIQUE] ON [dbo].[MEDIA_PLAN_TEMPLATE_PRODUCT]
    (
	    [CL_CODE] ASC,
        [DIV_CODE] ASC,
        [PRD_CODE] ASC,
        [MEDIA_PLAN_TEMPLATE_HEADER_ID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)

END
GO