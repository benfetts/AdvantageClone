IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_DTL_GRP_BUDGET') BEGIN

	CREATE TABLE [dbo].[MEDIA_PLAN_DTL_GRP_BUDGET](
		[MEDIA_PLAN_DTL_GRP_BUDGET_ID] [int] IDENTITY (1, 1) NOT NULL,
        [MEDIA_PLAN_DTL_ID] [int] NOT NULL,
		[ENTRY_DATE] [smalldatetime] NOT NULL,
		[GRP_BUDGET] [decimal](19,2) NOT NULL,
        [MARKET_CODE] [varchar](10) NULL,
        [SPOT_LENGTH] [smallint] NULL,
	 CONSTRAINT [PK_MEDIA_PLAN_DTL_GRP_BUDGET] PRIMARY KEY CLUSTERED 
	(
		[MEDIA_PLAN_DTL_GRP_BUDGET_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    
	ALTER TABLE [dbo].[MEDIA_PLAN_DTL_GRP_BUDGET]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_DTL_GRP_BUDGET_MEDIA_PLAN_DTL] FOREIGN KEY([MEDIA_PLAN_DTL_ID])
	REFERENCES [dbo].[MEDIA_PLAN_DTL] ([MEDIA_PLAN_DTL_ID])
	
	ALTER TABLE [dbo].[MEDIA_PLAN_DTL_GRP_BUDGET] CHECK CONSTRAINT [FK_MEDIA_PLAN_DTL_GRP_BUDGET_MEDIA_PLAN_DTL]

END
GO
