CREATE FUNCTION [dbo].[advtf_npr_intab_spot_tv_research](
    @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID int,
	@START_DATE smalldatetime,
    @END_DATE smalldatetime
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(7) NOT NULL,
	[avg_intab] decimal(15,5) NOT NULL,
    [media_spot_tv_research_daytime_id] int NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @tt TABLE (
		[homes] decimal(15,5) NOT NULL,
		[pp2P] decimal(15,5) NOT NULL,
		[pm2P] decimal(15,5) NOT NULL,
		[pm2-5] decimal(15,5) NOT NULL,
		[pm6-11] decimal(15,5) NOT NULL,
		[pm12-14] decimal(15,5) NOT NULL,
		[pm15-17] decimal(15,5) NOT NULL,
		[pm18-20] decimal(15,5) NOT NULL,
		[pm21-24] decimal(15,5) NOT NULL,
		[pm25-34] decimal(15,5) NOT NULL,
		[pm35-44] decimal(15,5) NOT NULL,
		[pm45-49] decimal(15,5) NOT NULL,
		[pm50-54] decimal(15,5) NOT NULL,
		[pm55-64] decimal(15,5) NOT NULL,
		[pm65P] decimal(15,5) NOT NULL,
		[pf2P] decimal(15,5) NOT NULL,
		[pf2-5] decimal(15,5) NOT NULL,
		[pf6-11] decimal(15,5) NOT NULL,
		[pf12-14] decimal(15,5) NOT NULL,
		[pf15-17] decimal(15,5) NOT NULL,
		[pf18-20] decimal(15,5) NOT NULL,
		[pf21-24] decimal(15,5) NOT NULL,
		[pf25-34] decimal(15,5) NOT NULL,
		[pf35-44] decimal(15,5) NOT NULL,
		[pf45-49] decimal(15,5) NOT NULL,
		[pf50-54] decimal(15,5) NOT NULL,
		[pf55-64] decimal(15,5) NOT NULL,
		[pf65P] decimal(15,5) NOT NULL,
		[pww] decimal(15,5) NOT NULL,
        [media_spot_tv_research_daytime_id] int NOT NULL
	)

	INSERT INTO @tt
	SELECT
		[homes] = AVG(CAST([HOMES_INTAB] as decimal(15,5))),
        [pp2P] = AVG(CAST([PEOPLE_2PLUS_INTAB] as decimal(15,5))),
        [pm2P] = AVG(CAST([MALES_2PLUS_INTAB] as decimal(15,5))),
        [pm2-5] = AVG(CAST([MALES_2TO5_INTAB] as decimal(15,5))),
        [pm6-11] = AVG(CAST([MALES_6TO11_INTAB] as decimal(15,5))),
        [pm12-14] = AVG(CAST([MALES_12TO14_INTAB] as decimal(15,5))),
        [pm15-17] = AVG(CAST([MALES_15TO17_INTAB] as decimal(15,5))),
        [pm18-20] = AVG(CAST([MALES_18TO20_INTAB] as decimal(15,5))),
        [pm21-24] = AVG(CAST([MALES_21TO24_INTAB] as decimal(15,5))),
        [pm25-34] = AVG(CAST([MALES_25TO34_INTAB] as decimal(15,5))),
        [pm35-44] = AVG(CAST([MALES_35TO44_INTAB] as decimal(15,5))),
        [pm45-49] = AVG(CAST([MALES_45TO49_INTAB] as decimal(15,5))),
        [pm50-54] = AVG(CAST([MALES_50TO54_INTAB] as decimal(15,5))),
        [pm55-64] = AVG(CAST([MALES_55TO64_INTAB] as decimal(15,5))),
        [pm65P] = AVG(CAST([MALES_65PLUS_INTAB] as decimal(15,5))),
        [pf2P] = AVG(CAST([FEMALES_2PLUS_INTAB] as decimal(15,5))),
        [pf2-5] = AVG(CAST([FEMALES_2TO5_INTAB] as decimal(15,5))),
        [pf6-11] = AVG(CAST([FEMALES_6TO11_INTAB] as decimal(15,5))),
        [pf12-14] = AVG(CAST([FEMALES_12TO14_INTAB] as decimal(15,5))),
        [pf15-17] = AVG(CAST([FEMALES_15TO17_INTAB] as decimal(15,5))),
        [pf18-20] = AVG(CAST([FEMALES_18TO20_INTAB] as decimal(15,5))),
        [pf21-24] = AVG(CAST([FEMALES_21TO24_INTAB] as decimal(15,5))),
        [pf25-34] = AVG(CAST([FEMALES_25TO34_INTAB] as decimal(15,5))),
        [pf35-44] = AVG(CAST([FEMALES_35TO44_INTAB] as decimal(15,5))),
        [pf45-49] = AVG(CAST([FEMALES_45TO49_INTAB] as decimal(15,5))),
        [pf50-54] = AVG(CAST([FEMALES_50TO54_INTAB] as decimal(15,5))),
        [pf55-64] = AVG(CAST([FEMALES_55TO64_INTAB] as decimal(15,5))),
        [pf65P] = AVG(CAST([FEMALES_65PLUS_INTAB] as decimal(15,5))),
        [pww] = AVG(CAST([WORKING_WOMEN_INTAB] as decimal(15,5))),
        [media_spot_tv_research_daytime_id] = d.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID
	FROM dbo.NPR_INTAB i
        INNER JOIN dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME d ON d.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = @MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID 
	WHERE i.[DATE] BETWEEN @START_DATE AND @END_DATE
    AND (
		(d.SUNDAY = 1 AND DATEPART(dw, i.[DATE]) = 1)
	OR	(d.MONDAY = 1 AND DATEPART(dw, i.[DATE]) = 2)
	OR	(d.TUESDAY = 1 AND DATEPART(dw, i.[DATE]) = 3)
	OR	(d.WEDNESDAY = 1 AND DATEPART(dw, i.[DATE]) = 4)
	OR	(d.THURSDAY = 1 AND DATEPART(dw, i.[DATE]) = 5)
	OR	(d.FRIDAY = 1 AND DATEPART(dw, i.[DATE]) = 6)
	OR	(d.SATURDAY = 1 AND DATEPART(dw, i.[DATE]) = 7)
		)
    GROUP BY d.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID

	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.[avg_intab], [media_spot_tv_research_daytime_id]
	FROM @tt
	UNPIVOT
	(
		[avg_intab]
		for nielsen_demo_code in ([homes],[pp2P],[pm2P],[pm2-5],[pm6-11],[pm12-14],[pm15-17],[pm18-20],[pm21-24],[pm25-34],[pm35-44],[pm45-49],[pm50-54],[pm55-64],[pm65P],
            [pf2P],[pf2-5],[pf6-11],[pf12-14],[pf15-17],[pf18-20],[pf21-24],[pf25-34],[pf35-44],[pf45-49],[pf50-54],[pf55-64],[pf65P],[pww])
	) u

	RETURN
END
GO
