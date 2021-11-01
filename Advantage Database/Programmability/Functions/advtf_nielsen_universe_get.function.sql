CREATE FUNCTION [dbo].[advtf_nielsen_universe_get](
	@NIELSEN_SERVICE char(1),
	@NIELSEN_MARKET_NUM int,
	@SAMPLE_TYPE char(1),
	@BOOK_MONTH smallint,
	@BOOK_YEAR smallint
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[ue] bigint NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @tt TABLE (
		[hh] bigint NOT NULL,
		[c2-5] bigint NOT NULL,
		[c6-11] bigint NOT NULL,
		[m12-14] bigint NOT NULL,
		[m15-17] bigint NOT NULL,
		[m18-20] bigint NOT NULL,
		[m21-24] bigint NOT NULL,
		[m25-34] bigint NOT NULL,
		[m35-49] bigint NOT NULL,
		[m50-54] bigint NOT NULL,
		[m55-64] bigint NOT NULL,
		[m65P] bigint NOT NULL,
		[f12-14] bigint NOT NULL,
		[f15-17] bigint NOT NULL,
		[f18-20] bigint NOT NULL,
		[f21-24] bigint NOT NULL,
		[f25-34] bigint NOT NULL,
		[f35-49] bigint NOT NULL,
		[f50-54] bigint NOT NULL,
		[f55-64] bigint NOT NULL,
		[f65P] bigint NOT NULL,
		[ww] bigint NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[hh] = a.HOUSEHOLD_UE,
		[c2-5] = a.CHILDREN_2TO5_UE,
		[c6-11] = a.CHILDREN_6TO11_UE,
		[m12-14] = a.MALES_12TO14_UE,
		[m15-17] = a.MALES_15TO17_UE,
		[m18-20] = a.MALES_18TO20_UE,
		[m21-24] = a.MALES_21TO24_UE,
		[m25-34] = a.MALES_25TO34_UE,
		[m35-49] = a.MALES_35TO49_UE,
		[m50-54] = a.MALES_50TO54_UE,
		[m55-64] = a.MALES_55TO64_UE,
		[m65P] = a.MALES_65PLUS_UE,
		[f12-14] = a.FEMALES_12TO14_UE,
		[f15-17] = a.FEMALES_15TO17_UE,
		[f18-20] = a.FEMALES_18TO20_UE,
		[f21-24] = a.FEMALES_21TO24_UE,
		[f25-34] = a.FEMALES_25TO34_UE,
		[f35-49] = a.FEMALES_35TO49_UE,
		[f50-54] = a.FEMALES_50TO54_UE,
		[f55-64] = a.FEMALES_55TO64_UE,
		[f65P] = a.FEMALES_65PLUS_UE,
		[ww] = a.WORKING_WOMEN_UE
	FROM dbo.NIELSEN_TV_UNIVERSE a
	WHERE a.NIELSEN_SERVICE = @NIELSEN_SERVICE
	AND a.NIELSEN_MARKET_NUM = @NIELSEN_MARKET_NUM 
	AND a.SAMPLE_TYPE = @SAMPLE_TYPE
	AND a.[YEAR] = @BOOK_YEAR
	AND a.[MONTH] = @BOOK_MONTH

	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.ue
	FROM @tt
	UNPIVOT
	(
		ue
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END