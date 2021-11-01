--A
IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_TEMPLATE_DETAIL') BEGIN

	CREATE TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL](
		[MEDIA_PLAN_TEMPLATE_DETAIL_ID] [int] IDENTITY(1,1) NOT NULL,
        [MEDIA_PLAN_TEMPLATE_HEADER_ID] [int] NOT NULL,
		[MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] [int] NOT NULL,
        [PERCENTAGE] [decimal](5,2) NOT NULL,
        [SC_CODE] [varchar](6) NOT NULL,
        [PERIOD_TYPE] [int] NOT NULL
	CONSTRAINT [PK_MEDIA_PLAN_TEMPLATE_DETAIL] PRIMARY KEY CLUSTERED 
	(
		[MEDIA_PLAN_TEMPLATE_DETAIL_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_DETAIL_MEDIA_PLAN_TEMPLATE_HEADER] FOREIGN KEY([MEDIA_PLAN_TEMPLATE_HEADER_ID])
	REFERENCES [dbo].[MEDIA_PLAN_TEMPLATE_HEADER] ([MEDIA_PLAN_TEMPLATE_HEADER_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL] CHECK CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_DETAIL_MEDIA_PLAN_TEMPLATE_HEADER]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_DETAIL_MEDIA_PLAN_ESTIMATE_TEMPLATE] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL] CHECK CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_DETAIL_MEDIA_PLAN_ESTIMATE_TEMPLATE]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_DETAIL_SALES_CLASS] FOREIGN KEY([SC_CODE])
	REFERENCES [dbo].[SALES_CLASS] ([SC_CODE])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL] CHECK CONSTRAINT [FK_MEDIA_PLAN_TEMPLATE_DETAIL_SALES_CLASS]
   
    CREATE UNIQUE NONCLUSTERED INDEX [MEDIA_PLAN_TEMPLATE_DETAIL_UNIQUE] ON [dbo].[MEDIA_PLAN_TEMPLATE_DETAIL]
    (
	    [MEDIA_PLAN_TEMPLATE_HEADER_ID] ASC,
	    [MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)

END
GO