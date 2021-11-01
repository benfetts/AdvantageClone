IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CDN_UNIVERSE') BEGIN

	CREATE TABLE [dbo].[CDN_UNIVERSE](
		[CDN_UNIVERSE_ID] [int] IDENTITY(1,1) NOT NULL,
		[YEAR] [int] NOT NULL,
		[MARKET_CODE] [varchar](10) NOT NULL,
		[MALES_2_PLUS_UE] [int] NOT NULL,
		[MALES_12_PLUS_UE] [int] NOT NULL,
		[MALES_18_PLUS_UE] [int] NOT NULL,
		[MALES_25_PLUS_UE] [int] NOT NULL,
		[MALES_35_PLUS_UE] [int] NOT NULL,
		[MALES_50_PLUS_UE] [int] NOT NULL,
		[MALES_55_PLUS_UE] [int] NOT NULL,
		[MALES_60_PLUS_UE] [int] NOT NULL,
		[MALES_65_PLUS_UE] [int] NOT NULL,
		[FEMALES_2_PLUS_UE] [int] NOT NULL,
		[FEMALES_12_PLUS_UE] [int] NOT NULL,
		[FEMALES_18_PLUS_UE] [int] NOT NULL,
		[FEMALES_25_PLUS_UE] [int] NOT NULL,
		[FEMALES_35_PLUS_UE] [int] NOT NULL,
		[FEMALES_50_PLUS_UE] [int] NOT NULL,
		[FEMALES_55_PLUS_UE] [int] NOT NULL,
		[FEMALES_60_PLUS_UE] [int] NOT NULL,
		[FEMALES_65_PLUS_UE] [int] NOT NULL,
	CONSTRAINT [PK_CDN_UNIVERSE] PRIMARY KEY CLUSTERED 
	(
		[CDN_UNIVERSE_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[CDN_UNIVERSE]  WITH CHECK ADD  CONSTRAINT [FK_CDN_UNIVERSE_MARKET] FOREIGN KEY([MARKET_CODE])
	REFERENCES [dbo].[MARKET] ([MARKET_CODE])
	
	ALTER TABLE [dbo].[CDN_UNIVERSE] CHECK CONSTRAINT [FK_CDN_UNIVERSE_MARKET]

END
GO