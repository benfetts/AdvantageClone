--9
IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET') BEGIN

	CREATE TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET](
		[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_ID] [int] IDENTITY(1,1) NOT NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] [int] NOT NULL,
		[MARKET_CODE] [varchar](10) NOT NULL,
	CONSTRAINT [PK_MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET] PRIMARY KEY CLUSTERED 
	(
		[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_MEDIA_PLAN_ESTIMATE_TEMPLATE] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_MEDIA_PLAN_ESTIMATE_TEMPLATE]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_MARKET] FOREIGN KEY([MARKET_CODE])
	REFERENCES [dbo].[MARKET] ([MARKET_CODE])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_MARKET]

    CREATE UNIQUE NONCLUSTERED INDEX [MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_UNIQUE] ON [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET]
    (
	    [MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] ASC,
	    [MARKET_CODE] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)

END
GO