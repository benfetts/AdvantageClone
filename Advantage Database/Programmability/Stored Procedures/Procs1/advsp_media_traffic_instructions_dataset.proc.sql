CREATE PROCEDURE [dbo].[advsp_media_traffic_instructions_dataset]
	@MEDIA_BROADCAST_WORKSHEET_MARKET_IDs varchar(max),
	@INCLUDE_ALL_MEDIA_TRAFFIC_REVISIONS bit
AS

BEGIN

	--DECLARE @CableVendorWithoutCreativeGroupAssigned bit = 0
		
	--SELECT @MediaType = MBW.MEDIA_TYPE_CODE 
	--FROM dbo.MEDIA_TRAFFIC_VENDOR MTV
	--	INNER JOIN dbo.MEDIA_TRAFFIC_REVISION MTR ON MTV.MEDIA_TRAFFIC_REVISION_ID = MTR.MEDIA_TRAFFIC_REVISION_ID 
	--	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC MBWMT ON MTR.MEDIA_TRAFFIC_ID = MBWMT.MEDIA_TRAFFIC_ID 
	--	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWMT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
	--	INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID

	--IF (SELECT 1 FROM dbo.MEDIA_TRAFFIC_VENDOR MTV INNER JOIN dbo.VENDOR V ON MTV.VN_CODE = V.VN_CODE WHERE MTV.MEDIA_TRAFFIC_VENDOR_ID = @MEDIA_TRAFFIC_VENDOR_ID AND V.IS_CABLE_SYSTEM = 1) = 1
	--BEGIN
	--	SELECT @CableVendorWithoutCreativeGroupAssigned = CASE WHEN COUNT(1) = 0 THEN 1 ELSE 0 END
	--	FROM dbo.MEDIA_TRAFFIC_VENDOR MTV
	--		INNER JOIN dbo.VENDOR V ON MTV.VN_CODE = V.VN_CODE 
	--		INNER JOIN dbo.MEDIA_TRAFFIC_CREATIVE_GROUP MTCG ON MTV.MEDIA_TRAFFIC_REVISION_ID = MTCG.MEDIA_TRAFFIC_REVISION_ID AND (MTCG.IS_DEFAULT = 1 OR V.IS_CABLE_SYSTEM = 1)
	--		LEFT OUTER JOIN dbo.MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP MTVCG ON MTVCG.MEDIA_TRAFFIC_CREATIVE_GROUP_ID = MTCG.MEDIA_TRAFFIC_CREATIVE_GROUP_ID AND MTV.MEDIA_TRAFFIC_VENDOR_ID = MTVCG.MEDIA_TRAFFIC_VENDOR_ID 
	--	WHERE MTVCG.MEDIA_TRAFFIC_VENDOR_ID = @MEDIA_TRAFFIC_VENDOR_ID 
	--END
	
	--SELECT @CableVendorWithoutCreativeGroupAssigned as '@CableVendorWithoutCreativeGroupAssigned'
	
	SELECT
		[ID] = NEWID(),
		[InstructionDescription] = MTR.[DESCRIPTION],
		[InstructionNumber] = MTR.MEDIA_TRAFFIC_ID,
		[RevisionNumber] = MTR.REVISION_NUMBER,
		[Schedule] = cast(MBW.MEDIA_BROADCAST_WORKSHEET_ID as  varchar) + ' - ' + MBW.[NAME],
		[ScheduleFlightRange] = CONVERT(char(10), MBW.[START_DATE], 101) + ' - ' + CONVERT(char(10), MBW.[END_DATE], 101),
		[InstructionDates] = CONVERT(char(10), MTR.[START_DATE], 101) + ' - ' + CONVERT(char(10), MTR.[END_DATE], 101),
		[AgencyName] = (SELECT [NAME] FROM dbo.AGENCY),
		[Buyer] = [dbo].[advfn_get_emp_name](MBWM.BUYER_EMP_CODE, 'FML'),
		[ClientDivision] = CASE 
								WHEN UPPER(C.CL_NAME) = UPPER(D.DIV_NAME) THEN C.CL_NAME
								ELSE C.CL_NAME + ' / ' + D.DIV_NAME 
								END,
		[Product] = P.PRD_DESCRIPTION,
		[Market] = M.MARKET_DESC + ' / ' + V.VN_NAME,
		[OrderNumber] = (SELECT TOP 1 ORDER_NBR 
						 FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
							INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
						 WHERE MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
						 AND MBWMD.VN_CODE = MTV.VN_CODE
						 AND MBWMDD.ORDER_NBR IS NOT NULL),
		[CableNetworkGroup] = MTVCG.CABLE_NETWORK_STATION_CODES,
		[CreativeGroupName] = MTCG.[NAME],
		[DetailDayPart] = DP.[DESCRIPTION],
		[DetailStartTime] = MTD.START_TIME,
		[DetailEndTime] = MTD.END_TIME,
		[DetailAdNumber] = MTD.AD_NBR,
		[DetailCreativeTitle] = MTD.CREATIVE_TITLE,
		[DetailLocation] = MTD.[LOCATION],
		[DetailBookendName] = MTD.BOOKEND_NAME,
		[DetailPosition] = MTD.POSITION,
		[DetailLength] = MTD.[LENGTH],
		[DetailRotation] = MTD.ROTATION,
		[DetailComment] = MTD.COMMENT,
		MTD.MEDIA_TRAFFIC_DETAIL_ID,
		[LastStatus] = COALESCE(
						(
						SELECT TOP 1 MTS.STATUS_DESCRIPTION
						FROM dbo.MEDIA_TRAFFIC_VENDOR_STATUS MTVS
							INNER JOIN dbo.MEDIA_TRAFFIC_STATUS MTS ON MTVS.MEDIA_TRAFFIC_STATUS_ID = MTS.MEDIA_TRAFFIC_STATUS_ID
						WHERE MEDIA_TRAFFIC_VENDOR_ID = MTV.MEDIA_TRAFFIC_VENDOR_ID
						AND MTS.MEDIA_TRAFFIC_STATUS_ID IN (1,2,3)
						ORDER BY CREATED_DATE DESC
						), 'Pending'),
		[HasDocuments] = CAST(CASE WHEN (SELECT COUNT(1) FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT WHERE MEDIA_TRAFFIC_DETAIL_ID = MTD.MEDIA_TRAFFIC_DETAIL_ID) > 0 THEN 1 ELSE 0 END as bit),
		[Documents] = [dbo].[advfn_get_media_traffic_document_list](MTD.MEDIA_TRAFFIC_DETAIL_ID),
		[AdNumberDescription] = AD.AD_NBR_DESC,
		[AdNumberExpirationDate] = AD.EXP_DT,
		[AdNumberIsInactive] = CAST(CASE WHEN AD.ACTIVE = 0 THEN 1 ELSE 0 END AS BIT),
		[LastCommentReply] = ''
	FROM dbo.MEDIA_TRAFFIC_VENDOR MTV
		INNER JOIN dbo.VENDOR V ON MTV.VN_CODE = V.VN_CODE 
		INNER JOIN dbo.MEDIA_TRAFFIC_CREATIVE_GROUP MTCG ON MTV.MEDIA_TRAFFIC_REVISION_ID = MTCG.MEDIA_TRAFFIC_REVISION_ID AND (MTCG.IS_DEFAULT = 1 OR V.IS_CABLE_SYSTEM = 1)
		LEFT OUTER JOIN dbo.MEDIA_TRAFFIC_DETAIL MTD ON MTCG.MEDIA_TRAFFIC_CREATIVE_GROUP_ID = MTD.MEDIA_TRAFFIC_CREATIVE_GROUP_ID 
		LEFT OUTER JOIN dbo.MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP MTVCG ON MTVCG.MEDIA_TRAFFIC_CREATIVE_GROUP_ID = MTCG.MEDIA_TRAFFIC_CREATIVE_GROUP_ID AND MTV.MEDIA_TRAFFIC_VENDOR_ID = MTVCG.MEDIA_TRAFFIC_VENDOR_ID 
		LEFT OUTER JOIN dbo.DAY_PART DP ON MTD.DAY_PART_ID = DP.DAY_PART_ID 
		INNER JOIN dbo.MEDIA_TRAFFIC_REVISION MTR ON MTV.MEDIA_TRAFFIC_REVISION_ID = MTR.MEDIA_TRAFFIC_REVISION_ID 
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC MBWMT ON MTR.MEDIA_TRAFFIC_ID = MBWMT.MEDIA_TRAFFIC_ID 
		LEFT OUTER JOIN (
						SELECT MAX(REVISION_NUMBER) as MAXREV, MEDIA_TRAFFIC_ID
						FROM dbo.MEDIA_TRAFFIC_REVISION MTR
						GROUP BY MEDIA_TRAFFIC_ID
						) maxrev ON maxrev.MEDIA_TRAFFIC_ID = MTR.MEDIA_TRAFFIC_ID AND maxrev.MAXREV = MTR.REVISION_NUMBER
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWMT.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
		INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID
		INNER JOIN dbo.CLIENT C ON MBW.CL_CODE = C.CL_CODE 
		INNER JOIN dbo.DIVISION D ON MBW.CL_CODE = D.CL_CODE AND MBW.DIV_CODE = D.DIV_CODE 
		INNER JOIN dbo.PRODUCT P ON MBW.CL_CODE = P.CL_CODE AND MBW.DIV_CODE = P.DIV_CODE AND MBW.PRD_CODE = P.PRD_CODE
		INNER JOIN dbo.MARKET M ON MBWM.MARKET_CODE = M.MARKET_CODE 
		LEFT OUTER JOIN dbo.AD_NUMBER AD ON MTD.AD_NBR = AD.AD_NBR
	WHERE MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_MARKET_IDs, ','))
	AND (
			@INCLUDE_ALL_MEDIA_TRAFFIC_REVISIONS = 1
		OR
			(@INCLUDE_ALL_MEDIA_TRAFFIC_REVISIONS = 0 AND maxrev.MEDIA_TRAFFIC_ID = MTR.MEDIA_TRAFFIC_ID AND maxrev.MAXREV = MTR.REVISION_NUMBER)
		)
	--AND (
	--		@CableVendorWithoutCreativeGroupAssigned = 0
	--	OR
	--		(@CableVendorWithoutCreativeGroupAssigned = 1 AND MTCG.IS_DEFAULT = 1)
	--	)
	--ORDER BY MTD.BOOKEND_SEQ_NBR
END