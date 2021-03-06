CREATE PROCEDURE [dbo].[advsp_mediaplan_exportdata]
	@MediaPlanID AS int,
	@MediaPlanDetailID AS int = NULL
AS
BEGIN 

	SET NOCOUNT ON
	
	SELECT 
		[ID] = NEWID(),
		[RowIndex] = MPDLLD.ROW_INDEX,
		[MediaPlanDetailLevelLineDataID] = MPDLLD.MEDIA_PLAN_DTL_LEVEL_LINE_DATA_ID,
		[OfficeCode] = P.OFFICE_CODE,
		[OfficeName] = O.OFFICE_NAME,
		[ClientCode] = MP.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = MP.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = MP.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[PlanID] = MP.MEDIA_PLAN_ID,
		[PlanDescription] = MP.[DESCRIPTION],
		[ClientContact] = COALESCE((RTRIM(CC.CONT_FNAME) + ' '),'') + COALESCE((CC.CONT_MI + '. '),'') + COALESCE(CC.CONT_LNAME,''),
		[PlanStartDate] = MP.[START_DATE],
		[PlanEndDate] = MP.END_DATE,
		[Budget] = MP.GROSS_BUDGET_AMT,
		[CreatedByUserCode] = MP.USER_CREATED,
		[CreatedDate] = MP.CREATED_DATE,
		[ModifiedByUserCode] = MP.USER_MODIFIED,
		[ModifiedDate] = MP.MODIFIED_DATE,
		[EstimateID] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), MPD.MEDIA_PLAN_DTL_ID), 6),
		[MediaType] = CASE WHEN MPD.SC_TYPE = 'M' THEN 'Magazine'
						   WHEN MPD.SC_TYPE = 'N' THEN 'Newspaper'
						   WHEN MPD.SC_TYPE = 'R' THEN 'Radio'
						   WHEN MPD.SC_TYPE = 'T' THEN 'Television'
						   WHEN MPD.SC_TYPE = 'O' THEN 'Out of Home'
						   WHEN MPD.SC_TYPE = 'I' THEN 'Internet' END,
		[SalesClassCode] = MPD.SC_CODE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[CampaignCode] = CAMP.CMP_CODE, 
		[CampaignName] = CAMP.CMP_NAME,
		[StartDate] = MPDLLD.[START_DATE],
		[EndDate] = MPDLLD.END_DATE,
		[Month] = DATEPART(M, MPDLLD.[START_DATE]),
		[Quarter] = DATEPART(Q, MPDLLD.[START_DATE]),
		[Year] = DATEPART(YEAR, MPDLLD.[START_DATE]),
		[VendorCode] = V.VendorCode,
		[VendorName] = V.[VendorName],
		[LineStartDate] = SD.[StartDate],
		[LineEndDate] = ED.[EndDate],
		[Demo1] = MPDLLD.DEMO1,
		[Demo2] = MPDLLD.DEMO2,
		[Units] = MPDLLD.UNITS,
		[Impressions] = MPDLLD.IMPRESSIONS,
		[Clicks] = MPDLLD.CLICKS,
		[Columns] = MPDLLD.[COLUMNS],
		[InchesLines] = MPDLLD.INCHES_LINES,
		[Rate] = MPDLLD.RATE,
		[Dollars] = MPDLLD.DOLLARS,
		[NetCharge] = MPDLLD.NET_CHARGE,
		[AgencyFee] = MPDLLD.AGENCY_FEE,
		[BillAmount] = MPDLLD.BILL_AMOUNT,
		[OrderID] = MPDLLD.ORDER_ID,
		[OrderLineID] = MPDLLD.ORDER_LINE_ID,
		[Monday] = MPDLLD.MONDAY,
		[Tuesday] = MPDLLD.TUESDAY,
		[Wednesday] = MPDLLD.WEDNESDAY,
		[Thursday] = MPDLLD.THURSDAY,
		[Friday] = MPDLLD.FRIDAY,
		[Saturday] = MPDLLD.SATURDAY,
		[Sunday] = MPDLLD.SUNDAY,
		[OrderNumber] = MPDLLD.ORDER_NBR,
		[OrderLineNumber] = MPDLLD.ORDER_LINE_NBR 
	FROM 
		[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] AS MPDLLD INNER JOIN
		[dbo].[MEDIA_PLAN] AS MP ON MP.MEDIA_PLAN_ID = MPDLLD.MEDIA_PLAN_ID INNER JOIN 
		[dbo].[MEDIA_PLAN_DTL] AS MPD ON MPD.MEDIA_PLAN_ID = MPDLLD.MEDIA_PLAN_ID AND
										 MPD.MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = MP.CL_CODE LEFT OUTER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = MP.CL_CODE AND
								 D.DIV_CODE = MP.DIV_CODE LEFT OUTER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = MP.CL_CODE AND
								P.DIV_CODE = MP.DIV_CODE AND
								P.PRD_CODE = MP.PRD_CODE LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = P.OFFICE_CODE LEFT OUTER JOIN
		[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = MP.CDP_CONTACT_ID LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = MPD.SC_CODE LEFT OUTER JOIN 
		[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = MPD.CMP_IDENTIFIER LEFT OUTER JOIN
		(SELECT 
			[MediaPlanID] = V.[MediaPlanID], 
			[MediaPlanDetailID] = V.[MediaPlanDetailID],
			[RowIndex] = V.[RowIndex],
			[VendorCode] = V.[VendorCode],
			[VendorName] = V.[VendorName]
		FROM
			(SELECT 
				[ID] = ROW_NUMBER() OVER (PARTITION BY MPDLLT.MEDIA_PLAN_ID, MPDLLT.MEDIA_PLAN_DTL_ID, MPDLL.ROW_INDEX ORDER BY MPDL.ORDER_NUMBER, MPDLL.ROW_INDEX DESC),
				[MediaPlanID] = MPDLLT.MEDIA_PLAN_ID, 
				[MediaPlanDetailID] = MPDLLT.MEDIA_PLAN_DTL_ID,
				[RowIndex] = MPDLL.ROW_INDEX,
				[VendorCode] = V.VN_CODE,
				[VendorName] = V.VN_NAME
			FROM 
				[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_TAG] AS MPDLLT INNER JOIN
				[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE] AS MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID INNER JOIN
				[dbo].[MEDIA_PLAN_DTL_LEVEL] AS MPDL ON MPDL.MEDIA_PLAN_DTL_LEVEL_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_ID INNER JOIN
				[dbo].[VENDOR] AS V ON V.VN_CODE = MPDLLT.VN_CODE
			WHERE
				MPDL.TAG_TYPE = 2 AND
				MPDLLT.VN_CODE IS NOT NULL) AS V
		WHERE
			V.[ID] = 1) AS V ON V.MediaPlanID  = MPDLLD.MEDIA_PLAN_ID AND
								V.[MediaPlanDetailID] = MPDLLD.MEDIA_PLAN_DTL_ID AND
								V.[RowIndex] = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		(SELECT 
			[MediaPlanID] = SD.[MediaPlanID], 
			[MediaPlanDetailID] = SD.[MediaPlanDetailID],
			[RowIndex] = SD.[RowIndex],
			[StartDate] = SD.[StartDate]
		FROM
			(SELECT 
				[ID] = ROW_NUMBER() OVER (PARTITION BY MPDLLT.MEDIA_PLAN_ID, MPDLLT.MEDIA_PLAN_DTL_ID, MPDLL.ROW_INDEX ORDER BY MPDL.ORDER_NUMBER, MPDLL.ROW_INDEX DESC),
				[MediaPlanID] = MPDLLT.MEDIA_PLAN_ID, 
				[MediaPlanDetailID] = MPDLLT.MEDIA_PLAN_DTL_ID,
				[RowIndex] = MPDLL.ROW_INDEX,
				[StartDate] = MPDLLT.[START_DATE]
			FROM 
				[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_TAG] AS MPDLLT INNER JOIN
				[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE] AS MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID INNER JOIN
				[dbo].[MEDIA_PLAN_DTL_LEVEL] AS MPDL ON MPDL.MEDIA_PLAN_DTL_LEVEL_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_ID
			WHERE
				MPDL.TAG_TYPE = 6 AND
				MPDLLT.[START_DATE] IS NOT NULL) AS SD
		WHERE
			SD.[ID] = 1) AS SD ON SD.MediaPlanID  = MPDLLD.MEDIA_PLAN_ID AND
								  SD.[MediaPlanDetailID] = MPDLLD.MEDIA_PLAN_DTL_ID AND
								  SD.[RowIndex] = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		(SELECT 
			[MediaPlanID] = ED.[MediaPlanID], 
			[MediaPlanDetailID] = ED.[MediaPlanDetailID],
			[RowIndex] = ED.[RowIndex],
			[EndDate] = ED.[EndDate]
		FROM
			(SELECT 
				[ID] = ROW_NUMBER() OVER (PARTITION BY MPDLLT.MEDIA_PLAN_ID, MPDLLT.MEDIA_PLAN_DTL_ID, MPDLL.ROW_INDEX ORDER BY MPDL.ORDER_NUMBER, MPDLL.ROW_INDEX DESC),
				[MediaPlanID] = MPDLLT.MEDIA_PLAN_ID, 
				[MediaPlanDetailID] = MPDLLT.MEDIA_PLAN_DTL_ID,
				[RowIndex] = MPDLL.ROW_INDEX,
				[EndDate] = MPDLLT.[END_DATE]
			FROM 
				[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_TAG] AS MPDLLT INNER JOIN
				[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE] AS MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID INNER JOIN
				[dbo].[MEDIA_PLAN_DTL_LEVEL] AS MPDL ON MPDL.MEDIA_PLAN_DTL_LEVEL_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_ID
			WHERE
				MPDL.TAG_TYPE = 7 AND
				MPDLLT.[END_DATE] IS NOT NULL) AS ED
		WHERE
			ED.[ID] = 1) AS ED ON ED.MediaPlanID  = MPDLLD.MEDIA_PLAN_ID AND
								  ED.[MediaPlanDetailID] = MPDLLD.MEDIA_PLAN_DTL_ID AND
								  ED.[RowIndex] = MPDLLD.ROW_INDEX
	WHERE 
		MPDLLD.MEDIA_PLAN_ID = @MediaPlanID AND
		1 = CASE WHEN @MediaPlanDetailID = 0 THEN 1 
				 WHEN MPDLLD.MEDIA_PLAN_DTL_ID = @MediaPlanDetailID THEN 1
				 ELSE 0 END
		
END

GO