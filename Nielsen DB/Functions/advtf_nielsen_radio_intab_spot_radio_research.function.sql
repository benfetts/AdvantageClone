CREATE FUNCTION [dbo].[advtf_nielsen_radio_intab_spot_radio_research](
	@NIELSEN_RADIO_SEGMENT_PARENT_IDs varchar(max),
	@NIELSEN_RADIO_QUALITATIVE_ID int
)
RETURNS
@RETURN_TABLE TABLE (
	[NIELSEN_DEMO_CODE] varchar(7) NOT NULL,
	[INTAB] bigint NOT NULL,
	[NIELSEN_RADIO_SEGMENT_PARENT_ID] int NOT NULL,
	[NIELSEN_RADIO_QUALITATIVE_ID] int NOT NULL,
	[NIELSEN_RADIO_REPORT_TYPE_CODE] varchar(2) NOT NULL,
	[STANDARD_CONDENSED_INDICATOR] char(1) NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.intab, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_QUALITATIVE_ID, NIELSEN_RADIO_REPORT_TYPE_CODE, STANDARD_CONDENSED_INDICATOR
	FROM (
		SELECT
			[251] = a.[MALES_6TO11_INTAB],
			[42] = MALES_12TO17_INTAB + MALES_18TO20_INTAB + MALES_18TO24_INTAB + MALES_21TO24_INTAB + MALES_25TO34_INTAB + MALES_35TO44_INTAB + MALES_35TO49_INTAB + MALES_45TO49_INTAB + MALES_50TO54_INTAB + MALES_55TO64_INTAB + MALES_65PLUS_INTAB + 
				   FEMALES_12TO17_INTAB + FEMALES_18TO20_INTAB + FEMALES_18TO24_INTAB + FEMALES_21TO24_INTAB + FEMALES_25TO34_INTAB + FEMALES_35TO44_INTAB + FEMALES_35TO49_INTAB + FEMALES_45TO49_INTAB + FEMALES_50TO54_INTAB + FEMALES_55TO64_INTAB + FEMALES_65PLUS_INTAB,
			[1] = a.[MALES_12TO17_INTAB],
			[264] = a.[FEMALES_6TO11_INTAB],
			[8] = a.[FEMALES_12TO17_INTAB],
			[254] = a.[MALES_18TO20_INTAB] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.MALES_18TO24_INTAB ELSE 0 END,
			[255] = a.[MALES_21TO24_INTAB],
			[3] = a.[MALES_25TO34_INTAB],
			[4] = a.[MALES_35TO44_INTAB] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.MALES_35TO49_INTAB ELSE 0 END,
			[5] = a.[MALES_45TO49_INTAB],
			[6] = a.[MALES_50TO54_INTAB],
			[82] = a.[MALES_55TO64_INTAB],
			[7] = a.[MALES_65PLUS_INTAB],
			[267] = a.[FEMALES_18TO20_INTAB] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.FEMALES_18TO24_INTAB ELSE 0 END,
			[268] = a.[FEMALES_21TO24_INTAB],
			[10] = a.[FEMALES_25TO34_INTAB],
			[11] = a.[FEMALES_35TO44_INTAB] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.FEMALES_35TO49_INTAB ELSE 0 END,
			[12] = a.[FEMALES_45TO49_INTAB],
			[13] = a.[FEMALES_50TO54_INTAB],
			[14] = a.[FEMALES_55TO64_INTAB],
			[15] = a.[FEMALES_65PLUS_INTAB],
			p.NIELSEN_RADIO_SEGMENT_PARENT_ID,
			p.NIELSEN_RADIO_QUALITATIVE_ID,
			pe.NIELSEN_RADIO_REPORT_TYPE_CODE,
			pe.STANDARD_CONDENSED_INDICATOR 
		FROM dbo.NIELSEN_RADIO_INTAB a
			INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_PARENT p ON a.NIELSEN_RADIO_SEGMENT_PARENT_ID = p.NIELSEN_RADIO_SEGMENT_PARENT_ID
			INNER JOIN dbo.NIELSEN_RADIO_PERIOD pe ON p.NIELSEN_RADIO_PERIOD_ID = pe.NIELSEN_RADIO_PERIOD_ID
		WHERE a.NIELSEN_RADIO_SEGMENT_PARENT_ID IN (SELECT items FROM dbo.udf_split_list(@NIELSEN_RADIO_SEGMENT_PARENT_IDs, ','))
	) INTABDATA
	UNPIVOT
	(
		intab
		for nielsen_demo_code in ([251], [42], [1], [264], [8], [254], [255], [3], [4], [5], [6], [82], [7], [267], [268], [10], [11], [12], [13], [14], [15]) 
	) u
	RETURN
END
GO

GRANT SELECT ON [advtf_nielsen_radio_intab_spot_radio_research] TO PUBLIC
GO