CREATE TABLE [dbo].[NATIONAL_UNIVERSE](
	[NATIONAL_UNIVERSE_ID] [int] IDENTITY(1,1) NOT NULL,
	[YEAR] [int] NOT NULL,
	[IS_HISPANIC] [bit] NOT NULL,
	[MARKET_BREAK_ID] [int] NOT NULL,
	[HOUSEHOLD_UE] [int] NOT NULL,
	[FEMALES_2TO5_UE] [int] NOT NULL,
	[FEMALES_6TO8_UE] [int] NOT NULL,
	[FEMALES_9TO11_UE] [int] NOT NULL,
	[FEMALES_12TO14_UE] [int] NOT NULL,
	[FEMALES_15TO17_UE] [int] NOT NULL,
	[FEMALES_18TO20_UE] [int] NOT NULL,
	[FEMALES_21TO24_UE] [int] NOT NULL,
	[FEMALES_25TO29_UE] [int] NOT NULL,
	[FEMALES_30TO34_UE] [int] NOT NULL,
	[FEMALES_35TO39_UE] [int] NOT NULL,
	[FEMALES_40TO44_UE] [int] NOT NULL,
	[FEMALES_45TO49_UE] [int] NOT NULL,
	[FEMALES_50TO54_UE] [int] NOT NULL,
	[FEMALES_55TO64_UE] [int] NOT NULL,
	[FEMALES_65PLUS_UE] [int] NOT NULL,
	[MALES_2TO5_UE] [int] NOT NULL,
	[MALES_6TO8_UE] [int] NOT NULL,
	[MALES_9TO11_UE] [int] NOT NULL,
	[MALES_12TO14_UE] [int] NOT NULL,
	[MALES_15TO17_UE] [int] NOT NULL,
	[MALES_18TO20_UE] [int] NOT NULL,
	[MALES_21TO24_UE] [int] NOT NULL,
	[MALES_25TO29_UE] [int] NOT NULL,
	[MALES_30TO34_UE] [int] NOT NULL,
	[MALES_35TO39_UE] [int] NOT NULL,
	[MALES_40TO44_UE] [int] NOT NULL,
	[MALES_45TO49_UE] [int] NOT NULL,
	[MALES_50TO54_UE] [int] NOT NULL,
	[MALES_55TO64_UE] [int] NOT NULL,
	[MALES_65PLUS_UE] [int] NOT NULL,
	[WORKING_WOMEN_18TO20_UE] [int] NOT NULL,
	[WORKING_WOMEN_21TO24_UE] [int] NOT NULL,
	[WORKING_WOMEN_25TO34_UE] [int] NOT NULL,
	[WORKING_WOMEN_35TO44_UE] [int] NOT NULL,
	[WORKING_WOMEN_45TO49_UE] [int] NOT NULL,
	[WORKING_WOMEN_50TO54_UE] [int] NOT NULL,
	[WORKING_WOMEN_55PLUS_UE] [int] NOT NULL,
 CONSTRAINT [PK_NATIONAL_UNIVERSE] PRIMARY KEY CLUSTERED 
(
	[NATIONAL_UNIVERSE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [NATIONAL_UNIVERSE_UNIQUE] ON [dbo].[NATIONAL_UNIVERSE]
(
	[YEAR] ASC,
	[IS_HISPANIC] ASC,
	[MARKET_BREAK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

ALTER TABLE [dbo].[NATIONAL_UNIVERSE]  WITH CHECK ADD  CONSTRAINT [FK_NATIONAL_UNIVERSE_MARKET_BREAK] FOREIGN KEY([MARKET_BREAK_ID])
REFERENCES [dbo].[MARKET_BREAK] ([MARKET_BREAK_ID])
	
ALTER TABLE [dbo].[NATIONAL_UNIVERSE] CHECK CONSTRAINT [FK_NATIONAL_UNIVERSE_MARKET_BREAK]
