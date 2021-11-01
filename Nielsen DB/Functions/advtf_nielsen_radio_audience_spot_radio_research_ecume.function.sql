﻿CREATE FUNCTION [dbo].[advtf_nielsen_radio_audience_spot_radio_research_ecume](
	@NIELSEN_RADIO_SEGMENT_PARENT_IDs varchar(max),
	@NIELSEN_RADIO_DAYPART_IDs varchar(max),
	@LISTENING_LOCATION char(1),
	@NIELSEN_RADIO_STATION_COMBO_IDs varchar(max),
	@NIELSEN_RADIO_QUALITATIVE_ID int
)
RETURNS
@RETURN_TABLE TABLE (
	NIELSEN_DEMO_CODE varchar(7) NOT NULL,
	ECUME bigint NOT NULL,
	NIELSEN_RADIO_SEGMENT_PARENT_ID int NOT NULL,
	NIELSEN_RADIO_SEGMENT_CHILD_ID int NOT NULL,
	NIELSEN_RADIO_STATION_COMBO_ID int NOT NULL,
	NIELSEN_RADIO_DAYPART_ID int NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.ecume, NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_SEGMENT_CHILD_ID, NIELSEN_RADIO_STATION_COMBO_ID, NIELSEN_RADIO_DAYPART_ID
	FROM (
		SELECT
			[251] = a.[MALES_6TO11_ECUME],
			[42] = MALES_12TO17_ECUME + MALES_18TO20_ECUME + MALES_18TO24_ECUME + MALES_21TO24_ECUME + MALES_25TO34_ECUME + MALES_35TO44_ECUME + MALES_35TO49_ECUME + MALES_45TO49_ECUME + MALES_50TO54_ECUME + MALES_55TO64_ECUME + MALES_65PLUS_ECUME + 
				   FEMALES_12TO17_ECUME + FEMALES_18TO20_ECUME + FEMALES_18TO24_ECUME + FEMALES_21TO24_ECUME + FEMALES_25TO34_ECUME + FEMALES_35TO44_ECUME + FEMALES_35TO49_ECUME + FEMALES_45TO49_ECUME + FEMALES_50TO54_ECUME + FEMALES_55TO64_ECUME + FEMALES_65PLUS_ECUME,
			[1] = a.[MALES_12TO17_ECUME],
			[264] = a.[FEMALES_6TO11_ECUME],
			[8] = a.[FEMALES_12TO17_ECUME],
			[254] = a.[MALES_18TO20_ECUME] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.MALES_18TO24_ECUME ELSE 0 END,
			[255] = a.[MALES_21TO24_ECUME],
			[3] = a.[MALES_25TO34_ECUME],
			[4] = a.[MALES_35TO44_ECUME] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.MALES_35TO49_ECUME ELSE 0 END,
			[5] = a.[MALES_45TO49_ECUME],
			[6] = a.[MALES_50TO54_ECUME],
			[82] = a.[MALES_55TO64_ECUME],
			[7] = a.[MALES_65PLUS_ECUME],
			[267] = a.[FEMALES_18TO20_ECUME] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.FEMALES_18TO24_ECUME ELSE 0 END,
			[268] = a.[FEMALES_21TO24_ECUME],
			[10] = a.[FEMALES_25TO34_ECUME],
			[11] = a.[FEMALES_35TO44_ECUME] + CASE WHEN @NIELSEN_RADIO_QUALITATIVE_ID > 1 THEN a.FEMALES_35TO49_ECUME ELSE 0 END,
			[12] = a.[FEMALES_45TO49_ECUME],
			[13] = a.[FEMALES_50TO54_ECUME],
			[14] = a.[FEMALES_55TO64_ECUME],
			[15] = a.[FEMALES_65PLUS_ECUME],
			a.NIELSEN_RADIO_SEGMENT_PARENT_ID,
			a.NIELSEN_RADIO_SEGMENT_CHILD_ID,
			c.NIELSEN_RADIO_STATION_COMBO_ID,
			c.NIELSEN_RADIO_DAYPART_ID
		FROM dbo.NIELSEN_RADIO_AUDIENCE a
			INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_CHILD c ON a.NIELSEN_RADIO_SEGMENT_CHILD_ID = c.NIELSEN_RADIO_SEGMENT_CHILD_ID
														AND c.NIELSEN_RADIO_DAYPART_ID IN (SELECT items FROM dbo.udf_split_list(@NIELSEN_RADIO_DAYPART_IDs, ','))
														AND c.LISTENING_LOCATION = @LISTENING_LOCATION
														AND c.NIELSEN_RADIO_STATION_COMBO_ID IN (SELECT items FROM dbo.udf_split_list(@NIELSEN_RADIO_STATION_COMBO_IDs, ','))
		WHERE a.NIELSEN_RADIO_SEGMENT_PARENT_ID IN (SELECT items FROM dbo.udf_split_list(@NIELSEN_RADIO_SEGMENT_PARENT_IDs, ','))
	) AUDDATA
	UNPIVOT
	(
		ecume
		for nielsen_demo_code in ([251], [42], [1], [264], [8], [254], [255], [3], [4], [5], [6], [82], [7], [267], [268], [10], [11], [12], [13], [14], [15]) 
	) u
	RETURN
END
GO

GRANT SELECT ON [advtf_nielsen_radio_audience_spot_radio_research_ecume] TO PUBLIC
GO