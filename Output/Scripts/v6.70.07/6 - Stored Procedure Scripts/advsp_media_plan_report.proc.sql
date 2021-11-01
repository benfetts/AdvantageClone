IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_media_plan_report]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_media_plan_report]
GO

CREATE PROCEDURE [dbo].[advsp_media_plan_report]
	@OfficeCodeList					varchar(max),
	@ClientCodeList					varchar(max),
	@ClientDivisionCodeList			varchar(max),
	@ClientDivisionProductCodeList	varchar(max),
	@broadcast_dates				bit	= 0,				--#01
	@user_id varchar(100)
AS

/* IS USED IN .Net AT THIS POINT - \AdvantageFramework\Reporting\Database\Procedures\MediaPlanReport.vb(115): Load =  ... */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

SELECT 
		[ID] = NEWID(),
		[OfficeCode] = P.OFFICE_CODE,
		[OfficeDescription] = O.OFFICE_NAME,
		[ClientCode] = MP.CL_CODE,
		[ClientDescription] = C.CL_NAME,
		[DivisionCode] = MP.DIV_CODE,
		[DivisionDescription] = D.DIV_NAME,
		[ProductCode] = MP.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[PlanID] = MP.MEDIA_PLAN_ID,
		[PlanDescription] = MP.[DESCRIPTION],
		[ClientContact] = COALESCE((RTRIM(CC.CONT_FNAME) + ' '),'') + COALESCE((CC.CONT_MI + '. '),'') + COALESCE(CC.CONT_LNAME,''),
		[StartDate] = MP.[START_DATE],
		[EndDate] = MP.END_DATE,
		[GrossBudget] = MP.GROSS_BUDGET_AMT,
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
		[CampaignCode] = CASE WHEN CAMP.CMP_CODE IS NULL THEN MPCMP.CampaignCode ELSE CAMP.CMP_CODE END, 
		[CampaignName] = CASE WHEN CAMP.CMP_NAME IS NULL THEN MPCMP.CampaignName ELSE CAMP.CMP_NAME END,
		[Level1] = LL1.[DESCRIPTION],
		[Level2] = LL2.[DESCRIPTION],
		[Level3] = LL3.[DESCRIPTION],
		[Level4] = LL4.[DESCRIPTION],
		[Level5] = LL5.[DESCRIPTION],
		[Level6] = LL6.[DESCRIPTION],
		[Level7] = LL7.[DESCRIPTION],
		[Level8] = LL8.[DESCRIPTION],
		[Level9] = LL9.[DESCRIPTION],
		[Level10] = LL10.[DESCRIPTION],
		[Date] = MPDLLD.[START_DATE],
        [DateEnd] = MPDLLD.[END_DATE],
		[Month] = CASE WHEN (MPD.IS_CALENDAR_MONTH = 1 AND @broadcast_dates = 0) THEN MC.[MONTH] ELSE MC.BROADCAST_MONTH END,
		[MonthName] = CASE WHEN (MPD.IS_CALENDAR_MONTH = 1 AND @broadcast_dates = 0) THEN CASE WHEN MC.[MONTH] = 1 THEN 'January'
																    WHEN MC.[MONTH] = 2 THEN 'February'
																    WHEN MC.[MONTH] = 3 THEN 'March'
																    WHEN MC.[MONTH] = 4 THEN 'April'
																    WHEN MC.[MONTH] = 5 THEN 'May'
																    WHEN MC.[MONTH] = 6 THEN 'June'
																    WHEN MC.[MONTH] = 7 THEN 'July'
																    WHEN MC.[MONTH] = 8 THEN 'August'
																    WHEN MC.[MONTH] = 9 THEN 'September'
																    WHEN MC.[MONTH] = 10 THEN 'October'
																    WHEN MC.[MONTH] = 11 THEN 'November'
																    WHEN MC.[MONTH] = 12 THEN 'December' END ELSE CASE WHEN MC.BROADCAST_MONTH = 1 THEN 'January'
																													   WHEN MC.BROADCAST_MONTH = 2 THEN 'February'
																													   WHEN MC.BROADCAST_MONTH = 3 THEN 'March'
																													   WHEN MC.BROADCAST_MONTH = 4 THEN 'April'
																													   WHEN MC.BROADCAST_MONTH = 5 THEN 'May'
																													   WHEN MC.BROADCAST_MONTH = 6 THEN 'June'
																													   WHEN MC.BROADCAST_MONTH = 7 THEN 'July'
																													   WHEN MC.BROADCAST_MONTH = 8 THEN 'August'
																													   WHEN MC.BROADCAST_MONTH = 9 THEN 'September'
																													   WHEN MC.BROADCAST_MONTH = 10 THEN 'October'
																													   WHEN MC.BROADCAST_MONTH = 11 THEN 'November'
																													   WHEN MC.BROADCAST_MONTH = 12 THEN 'December' END END,
		[Quarter] = CASE WHEN (MPD.IS_CALENDAR_MONTH = 1 AND @broadcast_dates = 0) THEN MC.[QUARTER] ELSE MC.BROADCAST_QUARTER END,
		[Year] = CASE WHEN (MPD.IS_CALENDAR_MONTH = 1 AND @broadcast_dates = 0) THEN MC.[YEAR] ELSE MC.BROADCAST_YEAR END,
		[Demo1] = MPDLLD.DEMO1,
		[Demo2] = MPDLLD.DEMO2,
		[Units] = MPDLLD.UNITS,
		[Impressions] = MPDLLD.IMPRESSIONS,
		[Clicks] = MPDLLD.CLICKS,
		[Rate] = MPDLLD.RATE,
		[Dollars] = MPDLLD.DOLLARS,
		[AgencyFee] = MPDLLD.AGENCY_FEE,
		[BillAmount] = MPDLLD.BILL_AMOUNT,
		[OrderNumber] = MPDLLD.ORDER_NBR,
		[OrderLineNumber] = MPDLLD.ORDER_LINE_NBR,
		[MasterPlanID] = MPMP.MEDIA_PLAN_MASTER_PLAN_ID,
		[MasterPlanName] = MPMP.[DESCRIPTION]
	INTO #tmp_media
	FROM 
		[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] AS MPDLLD INNER JOIN
		[dbo].[MEDIA_CALENDAR] AS MC ON MC.[DATE] = MPDLLD.[START_DATE] INNER JOIN
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
		[dbo].[advtf_media_plan_level_line](0) AS LL1 ON LL1.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL1.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL1.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](1) AS LL2 ON LL2.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL2.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL2.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](2) AS LL3 ON LL3.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL3.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL3.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](3) AS LL4 ON LL4.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL4.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL4.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](4) AS LL5 ON LL5.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL5.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL5.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](5) AS LL6 ON LL6.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL6.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL6.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](6) AS LL7 ON LL7.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL7.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL7.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](7) AS LL8 ON LL8.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL8.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL8.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](8) AS LL9 ON LL9.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													     LL9.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													     LL9.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[advtf_media_plan_level_line](9) AS LL10 ON LL10.MEDIA_PLAN_ID = MPD.MEDIA_PLAN_ID AND 
													      LL10.MEDIA_PLAN_DTL_ID = MPD.MEDIA_PLAN_DTL_ID AND 
													      LL10.ROW_INDEX = MPDLLD.ROW_INDEX LEFT OUTER JOIN
		[dbo].[MEDIA_PLAN_MASTER_PLAN_DETAIL] MPMPD ON MPMPD.MEDIA_PLAN_ID = MP.MEDIA_PLAN_ID LEFT OUTER JOIN
		[dbo].[MEDIA_PLAN_MASTER_PLAN] MPMP ON MPMP.MEDIA_PLAN_MASTER_PLAN_ID = MPMPD.MEDIA_PLAN_MASTER_PLAN_ID LEFT OUTER JOIN
		(SELECT 
 			[MediaPlanID] = MPDL.MEDIA_PLAN_ID,
 			[EstimateID] = MPDL.MEDIA_PLAN_DTL_ID,
 			[RowIndex] = MPDLL.ROW_INDEX,
			[CampaignCode] = C.CMP_CODE,
			[CampaignName] = C.CMP_NAME
		 FROM
 			dbo.MEDIA_PLAN_DTL_LEVEL MPDL INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE MPDLL ON MPDLL.MEDIA_PLAN_DTL_LEVEL_ID = MPDL.MEDIA_PLAN_DTL_LEVEL_ID INNER JOIN
 			dbo.MEDIA_PLAN_DTL_LEVEL_LINE_TAG MPDLLT ON MPDLLT.MEDIA_PLAN_DTL_LEVEL_LINE_ID = MPDLL.MEDIA_PLAN_DTL_LEVEL_LINE_ID LEFT OUTER JOIN
			dbo.CAMPAIGN C ON C.CMP_IDENTIFIER = MPDLLT.CMP_IDENTIFIER
		 WHERE
 			MPDL.TAG_TYPE = 11) MPCMP ON MPDLLD.MEDIA_PLAN_ID = MPCMP.MediaPlanID AND
										MPDLLD.MEDIA_PLAN_DTL_ID = MPCMP.EstimateID AND
										MPDLLD.ROW_INDEX = MPCMP.RowIndex
    WHERE
	(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND P.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND MP.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND MP.CL_CODE + '|' + MP.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND MP.CL_CODE + '|' + MP.DIV_CODE + '|' + MP.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))

/* PJH 09/30/2019 - Add CDP Security - BEG */

DECLARE @Restrictions int

SELECT
		@Restrictions = COUNT(*) 
FROM 
	dbo.SEC_CLIENT
WHERE 
	UPPER([USER_ID]) = UPPER(@user_id)
		
CREATE TABLE #Orders([ID] varchar(max) NOT NULL)
CREATE TABLE #UniqueProducts(CDPCode varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL)

IF @Restrictions > 0 BEGIN /* Only allow valid CDP for current user */

	INSERT INTO #UniqueProducts(CDPCode)
	SELECT
		DISTINCT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE
	FROM
		dbo.SEC_CLIENT
	WHERE 
		UPPER([USER_ID]) = UPPER(@user_id)

	INSERT INTO #Orders
	SELECT [ID] FROM #tmp_media A  
	INNER JOIN #UniqueProducts AS B ON B.CDPCode = CAST(A.[ClientCode] + '|' + A.[DivisionCode] + '|' + A.[ProductCode] AS varchar(30))

END
ELSE BEGIN /* All Qualify */

	INSERT INTO #Orders
	SELECT DISTINCT [ID] FROM #tmp_media
END

/* PJH 09/30/2019 - Add CDP Security - END */

SELECT A.* 
FROM #tmp_media A JOIN #Orders B ON A.ID = B.ID


GO

GRANT EXECUTE ON [advsp_media_plan_report] TO PUBLIC AS dbo
GO