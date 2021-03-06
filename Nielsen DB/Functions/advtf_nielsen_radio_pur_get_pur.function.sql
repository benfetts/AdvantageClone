CREATE FUNCTION [dbo].[advtf_nielsen_radio_pur_get_pur](
	@NIELSEN_RADIO_SEGMENT_PARENT_ID int,
	@NIELSEN_RADIO_DAYPART_ID int,
	@LISTENING_LOCATION char(1),
	@SelectedMediaDemographicIDs varchar(max),
	@MEDIA_DEMO_DETAIL_TYPE dbo.MEDIA_DEMO_DETAIL_TYPE READONLY
)
RETURNS
@RETURN_TABLE TABLE (
	[nielsen_demo_code] varchar(7) NOT NULL,
	[pur] bigint NOT NULL,
	MEDIA_DEMO_ID int NOT NULL,
	NIELSEN_RADIO_SEGMENT_CHILD_ID int NOT NULL
)
WITH SCHEMABINDING
AS
BEGIN
	INSERT INTO @RETURN_TABLE
	SELECT
		u.nielsen_demo_code, u.pur, mdd.MediaDemographicID, NIELSEN_RADIO_SEGMENT_CHILD_ID
	FROM (
		SELECT
			[251] = a.[MALES_6TO11_PUR],
			[42] = MALES_12TO17_PUR + MALES_18TO20_PUR + MALES_18TO24_PUR + MALES_21TO24_PUR + MALES_25TO34_PUR + MALES_35TO44_PUR + MALES_35TO49_PUR + MALES_45TO49_PUR + MALES_50TO54_PUR + MALES_55TO64_PUR + MALES_65PLUS_PUR + 
				   FEMALES_12TO17_PUR + FEMALES_18TO20_PUR + FEMALES_18TO24_PUR + FEMALES_21TO24_PUR + FEMALES_25TO34_PUR + FEMALES_35TO44_PUR + FEMALES_35TO49_PUR + FEMALES_45TO49_PUR + FEMALES_50TO54_PUR + FEMALES_55TO64_PUR + FEMALES_65PLUS_PUR,
			[1] = a.[MALES_12TO17_PUR],
			[264] = a.[FEMALES_6TO11_PUR],
			[8] = a.[FEMALES_12TO17_PUR],
			[254] = a.[MALES_18TO20_PUR],
			[255] = a.[MALES_21TO24_PUR],
			[3] = a.[MALES_25TO34_PUR],
			[4] = a.[MALES_35TO44_PUR],
			[5] = a.[MALES_45TO49_PUR],
			[6] = a.[MALES_50TO54_PUR],
			[82] = a.[MALES_55TO64_PUR],
			[7] = a.[MALES_65PLUS_PUR],
			[267] = a.[FEMALES_18TO20_PUR],
			[268] = a.[FEMALES_21TO24_PUR],
			[10] = a.[FEMALES_25TO34_PUR],
			[11] = a.[FEMALES_35TO44_PUR],
			[12] = a.[FEMALES_45TO49_PUR],
			[13] = a.[FEMALES_50TO54_PUR],
			[14] = a.[FEMALES_55TO64_PUR],
			[15] = a.[FEMALES_65PLUS_PUR],
			a.NIELSEN_RADIO_SEGMENT_CHILD_ID
		FROM dbo.NIELSEN_RADIO_PUR a
			INNER JOIN dbo.NIELSEN_RADIO_SEGMENT_CHILD c ON a.NIELSEN_RADIO_SEGMENT_CHILD_ID = c.NIELSEN_RADIO_SEGMENT_CHILD_ID
														AND c.NIELSEN_RADIO_DAYPART_ID = @NIELSEN_RADIO_DAYPART_ID
														AND c.LISTENING_LOCATION = @LISTENING_LOCATION
														AND c.STATION_COMBO_TYPE IN (8, 9)
														AND c.NIELSEN_RADIO_STATION_COMBO_ID = 999999
		WHERE NIELSEN_RADIO_SEGMENT_PARENT_ID = @NIELSEN_RADIO_SEGMENT_PARENT_ID
	) PURDATA
	UNPIVOT
	(
		pur
		for nielsen_demo_code in ([251], [42], [1], [264], [8], [254], [255], [3], [4], [5], [6], [82], [7], [267], [268], [10], [11], [12], [13], [14], [15]) 
	) u
		INNER JOIN dbo.NIELSEN_DEMO nd ON u.nielsen_demo_code = nd.CODE
		INNER JOIN @MEDIA_DEMO_DETAIL_TYPE mdd ON nd.NIELSEN_DEMO_ID = mdd.NielsenDemographicID  
	WHERE mdd.MediaDemographicID IN (SELECT items FROM dbo.udf_split_list(@SelectedMediaDemographicIDs, ','))
	RETURN
END
GO

GRANT SELECT ON [advtf_nielsen_radio_pur_get_pur] TO PUBLIC
GO