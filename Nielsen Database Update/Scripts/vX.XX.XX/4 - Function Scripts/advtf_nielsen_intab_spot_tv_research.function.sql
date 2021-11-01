IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_nielsen_intab_spot_tv_research]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_nielsen_intab_spot_tv_research]
GO

CREATE FUNCTION [dbo].[advtf_nielsen_intab_spot_tv_research](
	@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE READONLY,
	@NIELSEN_MARKET_NUM int,
	@BookIDs varchar(max)
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(6) NOT NULL,
	[avg_intab] decimal(21,2) NOT NULL,
	[nielsen_tv_book_id] int NOT NULL,
	[media_spot_tv_research_daytime_id] INT NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @tt TABLE (
		[hh] decimal(21,2) NOT NULL,
		[c2-5] decimal(21,2) NOT NULL,
		[c6-11] decimal(21,2) NOT NULL,
		[m12-14] decimal(21,2) NOT NULL,
		[m15-17] decimal(21,2) NOT NULL,
		[m18-20] decimal(21,2) NOT NULL,
		[m21-24] decimal(21,2) NOT NULL,
		[m25-34] decimal(21,2) NOT NULL,
		[m35-49] decimal(21,2) NOT NULL,
		[m50-54] decimal(21,2) NOT NULL,
		[m55-64] decimal(21,2) NOT NULL,
		[m65P] decimal(21,2) NOT NULL,
		[f12-14] decimal(21,2) NOT NULL,
		[f15-17] decimal(21,2) NOT NULL,
		[f18-20] decimal(21,2) NOT NULL,
		[f21-24] decimal(21,2) NOT NULL,
		[f25-34] decimal(21,2) NOT NULL,
		[f35-49] decimal(21,2) NOT NULL,
		[f50-54] decimal(21,2) NOT NULL,
		[f55-64] decimal(21,2) NOT NULL,
		[f65P] decimal(21,2) NOT NULL,
		[ww] decimal(21,2) NOT NULL,
		[nielsen_tv_book_id] int NOT NULL,
		[media_spot_tv_research_daytime_id] INT NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[hh] = AVG(a.HOUSEHOLD_INTAB),
		[c2-5] = AVG(a.CHILDREN_2TO5_INTAB),
		[c6-11] = AVG(a.CHILDREN_6TO11_INTAB),
		[m12-14] = AVG(a.MALES_12TO14_INTAB),
		[m15-17] = AVG(a.MALES_15TO17_INTAB),
		[m18-20] = AVG(a.MALES_18TO20_INTAB),
		[m21-24] = AVG(a.MALES_21TO24_INTAB),
		[m25-34] = AVG(a.MALES_25TO34_INTAB),
		[m35-49] = AVG(a.MALES_35TO49_INTAB),
		[m50-54] = AVG(a.MALES_50TO54_INTAB ),
		[m55-64] = AVG(a.MALES_55TO64_INTAB),
		[m65P] = AVG(a.MALES_65PLUS_INTAB),
		[f12-14] = AVG(a.FEMALES_12TO14_INTAB),
		[f15-17] = AVG(a.FEMALES_15TO17_INTAB),
		[f18-20] = AVG(a.FEMALES_18TO20_INTAB),
		[f21-24] = AVG(a.FEMALES_21TO24_INTAB),
		[f25-34] = AVG(a.FEMALES_25TO34_INTAB),
		[f35-49] = AVG(a.FEMALES_35TO49_INTAB),
		[f50-54] = AVG(a.FEMALES_50TO54_INTAB),
		[f55-64] = AVG(a.FEMALES_55TO64_INTAB),
		[f65P] = AVG(a.FEMALES_65PLUS_INTAB),
		[ww] = AVG(a.WORKING_WOMEN_INTAB),
		[nielsen_tv_book_id] = a.NIELSEN_TV_BOOK_ID,
		[media_spot_tv_research_daytime_id] = a.ID
	FROM
		(SELECT 
			HOUSEHOLD_INTAB = CAST(HOUSEHOLD_INTAB as decimal(21,2)),
			CHILDREN_2TO5_INTAB = CAST(CHILDREN_2TO5_INTAB as decimal(21,2)),
			CHILDREN_6TO11_INTAB = CAST(CHILDREN_6TO11_INTAB as decimal(21,2)),
			MALES_12TO14_INTAB = CAST(MALES_12TO14_INTAB as decimal(21,2)),
			MALES_15TO17_INTAB = CAST(MALES_15TO17_INTAB as decimal(21,2)),
			MALES_18TO20_INTAB = CAST(MALES_18TO20_INTAB as decimal(21,2)),
			MALES_21TO24_INTAB = CAST(MALES_21TO24_INTAB as decimal(21,2)),
			MALES_25TO34_INTAB = CAST(MALES_25TO34_INTAB as decimal(21,2)),
			MALES_35TO49_INTAB = CAST(MALES_35TO49_INTAB as decimal(21,2)),
			MALES_50TO54_INTAB = CAST(MALES_50TO54_INTAB as decimal(21,2)),
			MALES_55TO64_INTAB = CAST(MALES_55TO64_INTAB as decimal(21,2)),
			MALES_65PLUS_INTAB = CAST(MALES_65PLUS_INTAB as decimal(21,2)),
			FEMALES_12TO14_INTAB = CAST(FEMALES_12TO14_INTAB as decimal(21,2)),
			FEMALES_15TO17_INTAB = CAST(FEMALES_15TO17_INTAB as decimal(21,2)),
			FEMALES_18TO20_INTAB = CAST(FEMALES_18TO20_INTAB as decimal(21,2)),
			FEMALES_21TO24_INTAB = CAST(FEMALES_21TO24_INTAB as decimal(21,2)),
			FEMALES_25TO34_INTAB = CAST(FEMALES_25TO34_INTAB as decimal(21,2)),
			FEMALES_35TO49_INTAB = CAST(FEMALES_35TO49_INTAB as decimal(21,2)),
			FEMALES_50TO54_INTAB = CAST(FEMALES_50TO54_INTAB as decimal(21,2)),
			FEMALES_55TO64_INTAB = CAST(FEMALES_55TO64_INTAB as decimal(21,2)),
			FEMALES_65PLUS_INTAB = CAST(FEMALES_65PLUS_INTAB as decimal(21,2)),
			WORKING_WOMEN_INTAB = CAST(WORKING_WOMEN_INTAB as decimal(21,2)),
			INTAB_DATE,
			b.NIELSEN_TV_BOOK_ID,
			d.ID
		FROM dbo.NIELSEN_TV_INTAB a
			INNER JOIN dbo.NIELSEN_TV_BOOK b ON a.NIELSEN_TV_BOOK_ID = b.NIELSEN_TV_BOOK_ID
											 AND b.NIELSEN_TV_BOOK_ID IN (SELECT items FROM dbo.udf_split_list(@BookIDs, ','))
											 AND a.INTAB_DATE BETWEEN b.START_DATETIME AND b.END_DATETIME
			INNER JOIN @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE d ON d.ID > 0
																AND INTAB_DATE BETWEEN b.START_DATETIME AND b.END_DATETIME
		WHERE 
			(
			(d.Sunday = 1 AND DATEPART(dw, a.INTAB_DATE) = 1)
		OR	(d.Monday = 1 AND DATEPART(dw, a.INTAB_DATE) = 2)
		OR	(d.Tuesday = 1 AND DATEPART(dw, a.INTAB_DATE) = 3)
		OR	(d.Wednesday = 1 AND DATEPART(dw, a.INTAB_DATE) = 4)
		OR	(d.Thursday = 1 AND DATEPART(dw, a.INTAB_DATE) = 5)
		OR	(d.Friday = 1 AND DATEPART(dw, a.INTAB_DATE) = 6)
		OR	(d.Saturday = 1 AND DATEPART(dw, a.INTAB_DATE) = 7)
			)
		) a

	GROUP BY a.NIELSEN_TV_BOOK_ID, a.ID
	HAVING AVG(a.HOUSEHOLD_INTAB) IS NOT NULL

	INSERT INTO @RETURN_TABLE
	SELECT
			u.nielsen_demo_code, u.avg_intab, u.nielsen_tv_book_id, u.media_spot_tv_research_daytime_id
	FROM @tt
	UNPIVOT
	(
		avg_intab
		for nielsen_demo_code in ([hh], [c2-5],	[c6-11], [m12-14], [m15-17], [m18-20], [m21-24], [m25-34], [m35-49], [m50-54], [m55-64], [m65P],
								[f12-14], [f15-17], [f18-20], [f21-24], [f25-34], [f35-49], [f50-54], [f55-64],	[f65P],	[ww])
	) u

	RETURN
END
GO

GRANT SELECT ON [advtf_nielsen_intab_spot_tv_research] TO PUBLIC
GO
