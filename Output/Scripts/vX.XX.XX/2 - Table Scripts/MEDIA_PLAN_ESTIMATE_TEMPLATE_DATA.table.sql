--9
IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA') BEGIN

    CREATE TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA](
	    [MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_ID] [int] IDENTITY(1,1) NOT NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] [int] NOT NULL,
	    [MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE_ID] [int] NULL,
        [MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE_ID] [int] NULL,
        [INTERNET_TYPE_CODE] [varchar](6) NULL,
        [PERCENTAGE] [decimal](6,2) NOT NULL,
        [RATE] [decimal](10,4) NOT NULL,
     CONSTRAINT [PK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] PRIMARY KEY CLUSTERED 
    (
	    [MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_ID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
    ) ON [PRIMARY]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR]

	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_MARKET]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_DAYPART]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_SPOTLENGTH]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_DEMOGRAPHIC]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_OUTDOOR_TYPE]

	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_AD_SIZE_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE] FOREIGN KEY([MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE_ID])
	REFERENCES [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE] ([MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_INTERNET_TYPE] FOREIGN KEY([INTERNET_TYPE_CODE])
	REFERENCES [dbo].[INTERNET_TYPE] ([OD_CODE])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA] CHECK CONSTRAINT [FK_MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_INTERNET_TYPE]
    
    CREATE NONCLUSTERED INDEX [MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA_MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] ON [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE_DATA]
    (
	    [MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)

END
GO
