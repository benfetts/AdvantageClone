CREATE FUNCTION [dbo].[advtf_nielsen_national_tv_universe_get](
	@MEDIA_MARKET_BREAK_ID int
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(7) NOT NULL,
	[start_date] smalldatetime,
	[end_date] smalldatetime,
	[ue] bigint NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @tt TABLE (
		[nhh] bigint NOT NULL,
		[nf2-5] bigint NOT NULL,
		[nf6-8] bigint NOT NULL,
		[nf9-11] bigint NOT NULL,
		[nf12-14] bigint NOT NULL,
		[nf15-17] bigint NOT NULL,
		[nf18-20] bigint NOT NULL,
		[nf21-24] bigint NOT NULL,
		[nf25-29] bigint NOT NULL,
		[nf30-34] bigint NOT NULL,
		[nf35-39] bigint NOT NULL,
		[nf40-44] bigint NOT NULL,
		[nf45-49] bigint NOT NULL,
		[nf50-54] bigint NOT NULL,
		[nf55-64] bigint NOT NULL,
		[nf65P] bigint NOT NULL,
		[nm2-5] bigint NOT NULL,
		[nm6-8] bigint NOT NULL,
		[nm9-11] bigint NOT NULL,
		[nm12-14] bigint NOT NULL,
		[nm15-17] bigint NOT NULL,
		[nm18-20] bigint NOT NULL,
		[nm21-24] bigint NOT NULL,
		[nm25-29] bigint NOT NULL,
		[nm30-34] bigint NOT NULL,
		[nm35-39] bigint NOT NULL,
		[nm40-44] bigint NOT NULL,
		[nm45-49] bigint NOT NULL,
		[nm50-54] bigint NOT NULL,
		[nm55-64] bigint NOT NULL,
		[nm65P] bigint NOT NULL,
		[ww18-20] bigint NOT NULL,
		[ww21-24] bigint NOT NULL,
		[ww25-34] bigint NOT NULL,
		[ww35-44] bigint NOT NULL,
		[ww45-49] bigint NOT NULL,
		[ww50-54] bigint NOT NULL,
		[ww55P] bigint NOT NULL,
		[start_date] smalldatetime NOT NULL,
		[end_date] smalldatetime NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[nhh] = a.HOUSEHOLD_UE,
		[nf2_5] = a.FEMALES_2TO5_UE,
		[nf6_8] = a.FEMALES_6TO8_UE,
		[nf9_11] = a.FEMALES_9TO11_UE,
		[nf12_14] = a.FEMALES_12TO14_UE,
		[nf15_17] = a.FEMALES_15TO17_UE,
		[nf18_20] = a.FEMALES_18TO20_UE,
		[nf21_24] = a.FEMALES_21TO24_UE,
		[nf25_29] = a.FEMALES_25TO29_UE,
		[nf30_34] = a.FEMALES_30TO34_UE,
		[nf35_39] = a.FEMALES_35TO39_UE,
		[nf40_44] = a.FEMALES_40TO44_UE,
		[nf45_49] = a.FEMALES_45TO49_UE,
		[nf50_54] = a.FEMALES_50TO54_UE,
		[nf55_64] = a.FEMALES_55TO64_UE,
		[nf65p] = a.FEMALES_65PLUS_UE,
		[nm2_5] = a.MALES_2TO5_UE,
		[nm6_8] = a.MALES_6TO8_UE,
		[nm9_11] = a.MALES_9TO11_UE,
		[nm12_14] = a.MALES_12TO14_UE,
		[nm15_17] = a.MALES_15TO17_UE,
		[nm18_20] = a.MALES_18TO20_UE,
		[nm21_24] = a.MALES_21TO24_UE,
		[nm25_29] = a.MALES_25TO29_UE,
		[nm30_34] = a.MALES_30TO34_UE,
		[nm35_39] = a.MALES_35TO39_UE,
		[nm40_44] = a.MALES_40TO44_UE,
		[nm45_49] = a.MALES_45TO49_UE,
		[nm50_54] = a.MALES_50TO54_UE,
		[nm55_64] = a.MALES_55TO64_UE,
		[nm65p] = a.MALES_65PLUS_UE,
		[nww18_20] = a.WORKING_WOMEN_18TO20_UE,
		[nww21_24] = a.WORKING_WOMEN_21TO24_UE,
		[nww25_34] = a.WORKING_WOMEN_25TO34_UE,
		[nww35_44] = a.WORKING_WOMEN_35TO44_UE,
		[nww45_49] = a.WORKING_WOMEN_45TO49_UE,
		[nww50_54] = a.WORKING_WOMEN_50TO54_UE,
		[nww55p] = a.WORKING_WOMEN_55PLUS_UE,
		[start_date] = a.[START_DATE],
		[end_date] = a.END_DATE 
	FROM dbo.NIELSEN_NATIONAL_TV_UNIVERSE a
	WHERE a.MEDIA_MARKET_BREAK_ID = @MEDIA_MARKET_BREAK_ID
	
	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.[start_date], u.end_date, u.ue
	FROM @tt
	UNPIVOT
	(
		ue
		for nielsen_demo_code in ([nhh], [nf2-5], [nf6-8], [nf9-11], [nf12-14], [nf15-17], [nf18-20], [nf21-24], [nf25-29], [nf30-34], [nf35-39], [nf40-44],
			[nf45-49], [nf50-54], [nf55-64], [nf65P], [nm2-5], [nm6-8], [nm9-11], [nm12-14], [nm15-17], [nm18-20], [nm21-24], [nm25-29], [nm30-34], [nm35-39],
			[nm40-44], [nm45-49], [nm50-54], [nm55-64], [nm65P], [ww18-20], [ww21-24], [ww25-34], [ww35-44], [ww45-49], [ww50-54], [ww55P]) 
	) u

	RETURN
END
GO