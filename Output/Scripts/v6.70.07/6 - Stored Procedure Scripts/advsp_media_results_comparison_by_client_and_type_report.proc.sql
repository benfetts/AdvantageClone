IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_media_results_comparison_by_client_and_type_report]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_media_results_comparison_by_client_and_type_report]
GO

CREATE PROCEDURE [dbo].[advsp_media_results_comparison_by_client_and_type_report]
	@start_date			datetime,
	@end_date			datetime,
	@include_vendor		bit,
	@include_salesclass	bit,
	@include_period		bit,
	@include_ad			bit,	
	@OfficeCodeList  varchar(max)=null,
	@ClientCodeList varchar(max)=null,
	@ClientDivisionCodeList varchar(max)=null,
	@ClientDivisionProductCodeList varchar(max)=null,
	@user_id varchar(100)

AS 

/* IS USED IN .Net AT THIS POINT - \AdvantageFramework\Reporting\Database\Procedures\MediaResultsComparisonByClientAndTypeReport.vb(151): Load =  ... */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

BEGIN
	DECLARE @sql varchar(max)

	CREATE TABLE #RAWDATA (
		ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DivisionCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ProductCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		VendorCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		SalesClassCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		MediaOrderGrossDollars decimal(18,2),
		MediaOrderNetDollars decimal(18,2),
		[Period] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
		MediaType varchar(1),
		[GrossDollars] decimal(18,2),
		[NetDollars] decimal(18,2),
		[Units] decimal(18,2),
		[Leads1] decimal(18,2),
		[Leads2] decimal(18,2),
		[Impressions] int,
		[Clicks] decimal(18,2),
		[ClickRate] decimal(18,2),
		[Calls] decimal(18,2),
		[Conversions] decimal(18,2),
		[ConversionsB] decimal(18,2),
		[ConversionsC] decimal(18,2),
		[LikesOrganic] decimal(18,2),
		[LikesPaid] decimal(18,2),
		[Visits] decimal(18,2),
		[UniqueVisitors] decimal(18,2),
		[ReachOrganic] decimal(18,2),
		[ReachPaid] decimal(18,2),
		[PageViews] decimal(18,2),
		[PageEngagement] decimal(18,2),
		[ClientSales] decimal(18,2),
		[Placement] varchar(400),
		[AdNumber] varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[AdNumberDescription] varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		[DaypartCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL
	)

	--DECLARE @PlacementFlag int

	--SELECT @PlacementFlag = CASE WHEN PLACE1_FLAG = 1 THEN 1 
	--							WHEN PLACE2_FLAG = 1 THEN 2 ELSE 1 END
	--FROM MEDIA_PRINT_DEF mpd WHERE mpd.[USER_ID] = 'SYSADM' AND mpd.MEDIA_TYPE = 'I' 

	INSERT #RAWDATA (ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, MediaOrderGrossDollars, MediaOrderNetDollars, [Period], MediaType, Placement, AdNumber)
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, SUM(COALESCE(d.EXT_GROSS_AMT,0) + COALESCE(d.REBATE_AMT,0) + COALESCE(d.ADDL_CHARGE,0) + COALESCE(d.NETCHARGE,0) + COALESCE(d.DISCOUNT_AMT,0)),
		SUM(COALESCE(d.EXT_NET_AMT,0)) + SUM(COALESCE(d.DISCOUNT_AMT,0)) + SUM(COALESCE(d.NETCHARGE,0)) + SUM(COALESCE(d.NON_RESALE_AMT,0)),
		CONVERT(char(4), YEAR(d.[START_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[START_DATE])), 2), 'I', ISNULL(d.PLACEMENT_1,''), ISNULL(d.AD_NUMBER,'')
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR 
	WHERE d.[START_DATE] BETWEEN @start_date AND @end_date 
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND h.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list (@ClientDivisionProductCodeList, ','))))	
	GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, CONVERT(char(4), YEAR(d.[START_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[START_DATE])), 2), ISNULL(d.PLACEMENT_1,''), ISNULL(d.AD_NUMBER,'')
	
	INSERT #RAWDATA (ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, MediaOrderGrossDollars, MediaOrderNetDollars, [Period], MediaType, Placement, AdNumber)
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, SUM(COALESCE(d.EXT_GROSS_AMT,0) + COALESCE(d.REBATE_AMT,0) + COALESCE(d.ADDL_CHARGE,0) + COALESCE(d.NETCHARGE,0) + COALESCE(d.DISCOUNT_AMT,0)),
		SUM(COALESCE(d.EXT_NET_AMT,0)) + SUM(COALESCE(d.DISCOUNT_AMT,0)) + SUM(COALESCE(d.NETCHARGE,0)) + SUM(COALESCE(d.NON_RESALE_AMT,0)),
		CONVERT(char(4), YEAR(d.[START_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[START_DATE])), 2), 'M','', ISNULL(d.AD_NUMBER,'')
	FROM dbo.MAGAZINE_HEADER h
		INNER JOIN dbo.MAGAZINE_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR 
	WHERE d.[START_DATE] BETWEEN @start_date AND @end_date 
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND h.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list (@ClientDivisionProductCodeList, ','))))	
	GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, CONVERT(char(4), YEAR(d.[START_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[START_DATE])), 2), ISNULL(d.AD_NUMBER,'')
	
	INSERT #RAWDATA (ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, MediaOrderGrossDollars, MediaOrderNetDollars, [Period], MediaType, Placement, AdNumber)
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, SUM(COALESCE(d.EXT_GROSS_AMT,0) + COALESCE(d.REBATE_AMT,0) + COALESCE(d.ADDL_CHARGE,0) + COALESCE(d.NETCHARGE,0) + COALESCE(d.DISCOUNT_AMT,0)),
		SUM(COALESCE(d.EXT_NET_AMT,0)) + SUM(COALESCE(d.DISCOUNT_AMT,0)) + SUM(COALESCE(d.NETCHARGE,0)) + SUM(COALESCE(d.NON_RESALE_AMT,0)),
		CONVERT(char(4), YEAR(d.[START_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[START_DATE])), 2), 'N','', ISNULL(d.AD_NUMBER,'')
	FROM dbo.NEWSPAPER_HEADER h
		INNER JOIN dbo.NEWSPAPER_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR 
	WHERE d.[START_DATE] BETWEEN @start_date AND @end_date 
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND h.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list (@ClientDivisionProductCodeList, ','))))	
	GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, CONVERT(char(4), YEAR(d.[START_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[START_DATE])), 2), ISNULL(d.AD_NUMBER,'')
	
	INSERT #RAWDATA (ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, MediaOrderGrossDollars, MediaOrderNetDollars, [Period], MediaType, Placement, AdNumber)
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, SUM(COALESCE(d.EXT_GROSS_AMT,0) + COALESCE(d.REBATE_AMT,0) + COALESCE(d.ADDL_CHARGE,0) + COALESCE(d.NETCHARGE,0) + COALESCE(d.DISCOUNT_AMT,0)),
		SUM(COALESCE(d.EXT_NET_AMT,0)) + SUM(COALESCE(d.DISCOUNT_AMT,0)) + SUM(COALESCE(d.NETCHARGE,0)) + SUM(COALESCE(d.NON_RESALE_AMT,0)),
		CONVERT(char(4), YEAR(d.[POST_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[POST_DATE])), 2), 'O','', ISNULL(d.AD_NUMBER,'')
	FROM dbo.OUTDOOR_HEADER h
		INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR 
	WHERE d.[POST_DATE] BETWEEN @start_date AND @end_date 
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND h.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list (@ClientDivisionProductCodeList, ','))))	
	GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, CONVERT(char(4), YEAR(d.[POST_DATE])) + RIGHT('00' + CONVERT(varchar(2), MONTH(d.[POST_DATE])), 2), ISNULL(d.AD_NUMBER,'')
	
	INSERT #RAWDATA (ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, MediaOrderGrossDollars, MediaOrderNetDollars, [Period], MediaType, Placement, AdNumber, [DaypartCode])
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, SUM(COALESCE(d.EXT_GROSS_AMT,0) + COALESCE(d.REBATE_AMT,0) + COALESCE(d.ADDL_CHARGE,0) + COALESCE(d.NETCHARGE,0) + COALESCE(d.DISCOUNT_AMT,0)),
		SUM(COALESCE(d.EXT_NET_AMT,0)) + SUM(COALESCE(d.DISCOUNT_AMT,0)) + SUM(COALESCE(d.NETCHARGE,0)) + SUM(COALESCE(d.NON_RESALE_AMT,0)),
		CONVERT(char(4), [YEAR_NBR]) + RIGHT('00' + CONVERT(varchar(2), [MONTH_NBR]), 2), 'R','', ISNULL(d.AD_NUMBER,''), ISNULL(dp.DAY_PART_CODE,'')
	FROM dbo.RADIO_HDR h
		INNER JOIN dbo.RADIO_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR 
		LEFT OUTER JOIN dbo.DAY_PART dp ON dp.DAY_PART_ID = d.DAY_PART_ID
	WHERE d.[MONTH_NBR] BETWEEN MONTH(@start_date) AND MONTH(@end_date)
		AND	d.[YEAR_NBR] BETWEEN YEAR(@start_date) AND YEAR(@end_date)
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND h.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list (@ClientDivisionProductCodeList, ','))))	
	GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, CONVERT(char(4), [YEAR_NBR]) + RIGHT('00' + CONVERT(varchar(2), [MONTH_NBR]), 2), ISNULL(d.AD_NUMBER,''), ISNULL(dp.DAY_PART_CODE,'')
	
	INSERT #RAWDATA (ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, MediaOrderGrossDollars, MediaOrderNetDollars, [Period], MediaType, Placement, AdNumber, [DaypartCode])
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, SUM(COALESCE(d.EXT_GROSS_AMT,0) + COALESCE(d.REBATE_AMT,0) + COALESCE(d.ADDL_CHARGE,0) + COALESCE(d.NETCHARGE,0) + COALESCE(d.DISCOUNT_AMT,0)),
		SUM(COALESCE(d.EXT_NET_AMT,0)) + SUM(COALESCE(d.DISCOUNT_AMT,0)) + SUM(COALESCE(d.NETCHARGE,0)) + SUM(COALESCE(d.NON_RESALE_AMT,0)),
		CONVERT(char(4), [YEAR_NBR]) + RIGHT('00' + CONVERT(varchar(2), [MONTH_NBR]), 2), 'T','', ISNULL(d.AD_NUMBER,''), ISNULL(dp.DAY_PART_CODE,'')
	FROM dbo.TV_HDR h
		INNER JOIN dbo.TV_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR 
		LEFT OUTER JOIN dbo.DAY_PART dp ON dp.DAY_PART_ID = d.DAY_PART_ID
	WHERE d.[MONTH_NBR] BETWEEN MONTH(@start_date) AND MONTH(@end_date)
		AND	d.[YEAR_NBR] BETWEEN YEAR(@start_date) AND YEAR(@end_date)
		AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND h.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
		AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list (@ClientDivisionProductCodeList, ','))))	
	GROUP BY h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.VN_CODE, h.MEDIA_TYPE, CONVERT(char(4), [YEAR_NBR]) + RIGHT('00' + CONVERT(varchar(2), [MONTH_NBR]), 2), ISNULL(d.AD_NUMBER,''), ISNULL(dp.DAY_PART_CODE,'')
	
	INSERT #RAWDATA (ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, MediaOrderGrossDollars, MediaOrderNetDollars, [Period], MediaType,
			[NetDollars], [GrossDollars], [Units], [Leads1], [Leads2], [Impressions], [Clicks], [ClickRate], [Calls], [Conversions], [ConversionsB], [ConversionsC], [LikesOrganic], [LikesPaid], [Visits],
			[UniqueVisitors], [ReachOrganic], [ReachPaid], [PageViews], [PageEngagement], [ClientSales], [Placement], [AdNumber], [DaypartCode])
	SELECT
		ClientCode,
		DivisionCode,
		ProductCode,
		VendorCode,
		SalesClassCode,
		0,
		0,
		[Period] = CONVERT(char(4), YEAR(vdr.StartDate)) + RIGHT('00' + CONVERT(varchar(2), MONTH(vdr.StartDate)), 2),
		MediaType,
		[NetDollars] = SUM(NetDollars),
		[GrossDollars] = SUM(GrossDollars),
		[Units] = SUM(Units),
		[Leads1] = SUM(Leads1),
		[Leads2] = SUM(Leads2),
		[Impressions] = SUM(Impressions),
		[Clicks] = SUM(Clicks),
		[ClickRate] = SUM(ClickRate),
		[Calls] = SUM(Calls),
		[Conversions] = SUM(COALESCE(TotalConversions, 0)),
		[ConversionsB] = SUM(COALESCE(TotalConversionsB, 0)),
		[ConversionsC] = SUM(COALESCE(TotalConversionsC, 0)),
		[LikesOrganic] = SUM(LikesOrganic),
		[LikesPaid] = SUM(LikesPaid),
		[Visits] = SUM(Visits),
		[UniqueVisitors] = SUM(UniqueVisitors),
		[ReachOrganic] = SUM(ReachOrganic),
		[ReachPaid] = SUM(ReachPaid),
		[PageViews] = SUM(PageViews),
		[PageEngagement] = SUM(PageEngagement),
		[ClientSales] = SUM([ClientSales]),
		[Placement] = ISNULL(Placement,''),
		[AdNumber] = ISNULL(AdNumber,''),
		[DaypartCode] = ISNULL(DaypartCode,'')
	FROM dbo.V_DIGITAL_RESULTS vdr
	WHERE StartDate BETWEEN @start_date AND @end_date
		--AND		(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND vdr.OfficeCode IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
	    AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND vdr.ClientCode IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND vdr.ClientCode + '|' + vdr.DivisionCode IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND vdr.ClientCode + '|' + vdr.DivisionCode + '|' + vdr.ProductCode IN (SELECT * FROM dbo.udf_split_list (@ClientDivisionProductCodeList, ','))))	
	GROUP BY 
		ClientCode, DivisionCode, ProductCode, VendorCode, SalesClassCode, CONVERT(char(4), YEAR(vdr.StartDate)) + RIGHT('00' + CONVERT(varchar(2), MONTH(vdr.StartDate)), 2), MediaType, Placement, AdNumber,[AdNumberDescription], [DaypartCode]

	
	/* PJH 09/30/2019 - Add CDP Security - BEG */

	DECLARE @Restrictions int

	SELECT
			@Restrictions = COUNT(*) 
	FROM 
		dbo.SEC_CLIENT
	WHERE 
		UPPER([USER_ID]) = UPPER(@user_id)
		
	CREATE TABLE #UniqueProducts(CDPCode varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL)

	IF @Restrictions > 0 BEGIN /* Only allow valid CDP for current user */

		INSERT INTO #UniqueProducts(CDPCode)
		SELECT
			DISTINCT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE
		FROM
			dbo.SEC_CLIENT
		WHERE 
			UPPER([USER_ID]) = UPPER(@user_id)

	END
	ELSE BEGIN /* All Qualify */

		INSERT INTO #UniqueProducts(CDPCode)
		SELECT
			DISTINCT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE
		FROM
			dbo.PRODUCT

	END

	/* PJH 09/30/2019 - Add CDP Security - END */


	SET @sql = 
	'SELECT
		[ID] = NEWID(),
		dr.ClientCode,
		ClientName = c.CL_NAME,
		dr.DivisionCode,
		DivisionName = d.DIV_NAME,
		dr.ProductCode,
		ProductName = p.PRD_DESCRIPTION,'

	IF @include_vendor = 1
	Begin
		SET @sql = @sql + ' 
							dr.VendorCode,
							VendorName = v.VN_NAME,'
	End
	SET @sql = @sql + ' dr.Placement,'

	IF @include_salesclass = 1
		SET @sql = @sql + '
						dr.SalesClassCode,
						[SalesClassDescription] = sc.SC_DESCRIPTION,'

	IF @include_period = 1
		SET @sql = @sql + '
			dr.[Period],
			[Year] = substring(dr.[Period], 1, 4),
			[Month] = substring(dr.[Period], 5, 2),
			[MonthName] = DateName( month , DateAdd( month , convert(int, substring(dr.[Period], 5, 2)) , 0 ) - 1 ),
			[MonthAbbreviation] = substring( DateName( month , DateAdd( month , convert(int, substring(dr.[Period], 5, 2)) , 0 ) - 1 ), 1, 3 ),
			'

	SET @sql = @sql + '
		[ClientState] = c.CL_STATE,
		[Region] = cp.REGION_CODE,
		[NumberOfEmployees] = cp.NUM_EMPLOYEES,
		[TurnoverPercent] = cp.TURNOVER_PERCENT,
		[Revenue] = cp.REVENUE,
		[Type1] = ct1.[DESCRIPTION],
		[Type2] = ct2.[DESCRIPTION],
		[Type3] = ct3.[DESCRIPTION],
		MediaType,
		[MediaTypeDescription] = CASE MediaType
									WHEN ''I'' THEN ''Internet''
									WHEN ''M'' THEN ''Magazine''
									WHEN ''N'' THEN ''Newspaper''
									WHEN ''O'' THEN ''Out of Home''
									WHEN ''R'' THEN ''Radio''
									WHEN ''T'' THEN ''Television''
									ELSE NULL
									END,
		NetDollars = ISNULL(SUM( dr.[NetDollars] ),0),
		GrossDollars = ISNULL(SUM( dr.[GrossDollars] ),0),
		Units = ISNULL(SUM( dr.[Units] ),0),
		Leads1 = ISNULL(SUM( dr.[Leads1] ),0),
		Leads2 = ISNULL(SUM( dr.[Leads2] ),0),
		Impressions = ISNULL(SUM( dr.[Impressions] ),0),
		Clicks = ISNULL(SUM( dr.[Clicks] ),0),
		ClickRate = ISNULL(SUM( dr.[ClickRate] ),0),
		Calls = ISNULL(SUM( dr.[Calls] ),0),
		Conversions = ISNULL(SUM( dr.[Conversions] ),0),
		ConversionsB = ISNULL(SUM( dr.[ConversionsB] ),0),
		ConversionsC = ISNULL(SUM( dr.[ConversionsC] ),0),
		LikesOrganic = ISNULL(SUM( dr.[LikesOrganic] ),0),
		LikesPaid = ISNULL(SUM( dr.[LikesPaid] ),0),
		Visits = ISNULL(SUM( dr.[Visits] ),0),
		UniqueVisitors = ISNULL(SUM( dr.[UniqueVisitors] ),0),
		ReachOrganic = ISNULL(SUM( dr.[ReachOrganic] ),0),
		ReachPaid = ISNULL(SUM( dr.[ReachPaid] ),0),
		PageViews = ISNULL(SUM( dr.[PageViews] ),0),
		PageEngagement = ISNULL(SUM( dr.[PageEngagement] ),0),
		MediaOrderNetDollars = ISNULL(SUM( MediaOrderNetDollars ),0),
		MediaOrderGrossDollars = ISNULL(SUM( MediaOrderGrossDollars ),0),
		ClientSales = ISNULL(SUM( dr.[ClientSales] ),0),
		DaypartCode'

		IF @include_ad = 1
		Begin
			SET @sql = @sql + ' , AdNumber = ISNULL(dr.[AdNumber],''''),
								AdNumberDescription = ISNULL(ad.AD_NBR_DESC,'''')'
		End
	SET @sql = @sql + ' FROM
		#RAWDATA dr
			INNER JOIN #UniqueProducts AS B ON B.CDPCode = CAST(dr.[ClientCode] + ''|'' + dr.[DivisionCode] + ''|'' + dr.[ProductCode] AS varchar(30))
			LEFT OUTER JOIN dbo.CLIENT c ON dr.ClientCode = c.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION d ON dr.ClientCode = d.CL_CODE AND dr.DivisionCode = d.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p ON dr.ClientCode = p.CL_CODE AND dr.DivisionCode = p.DIV_CODE AND dr.ProductCode = p.PRD_CODE
			LEFT OUTER JOIN dbo.VENDOR v ON dr.VendorCode = v.VN_CODE

			LEFT OUTER JOIN dbo.COMPANY_PROFILE cp ON dr.ClientCode = cp.CL_CODE AND dr.DivisionCode = cp.DIV_CODE AND dr.ProductCode = cp.PRD_CODE 		
			LEFT OUTER JOIN dbo.CLIENT_TYPE1 ct1 ON cp.CLIENT_TYPE1_ID = ct1.CLIENT_TYPE1_ID 
			LEFT OUTER JOIN dbo.CLIENT_TYPE2 ct2 ON cp.CLIENT_TYPE2_ID = ct2.CLIENT_TYPE2_ID 
			LEFT OUTER JOIN dbo.CLIENT_TYPE3 ct3 ON cp.CLIENT_TYPE3_ID = ct3.CLIENT_TYPE3_ID 
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON dr.SalesClassCode = sc.SC_CODE 
			LEFT OUTER JOIN dbo.AD_NUMBER ad ON dr.AdNumber = ad.AD_NBR
	GROUP BY
		dr.ClientCode,
		c.CL_NAME,
		dr.DivisionCode,
		d.DIV_NAME,
		dr.ProductCode,
		p.PRD_DESCRIPTION,
		c.CL_STATE,
		cp.REGION_CODE,
		cp.NUM_EMPLOYEES,
		cp.TURNOVER_PERCENT,
		cp.REVENUE,
		ct1.[DESCRIPTION],
		ct2.[DESCRIPTION],
		ct3.[DESCRIPTION],
		MediaType,
		Placement,
		DaypartCode'

	IF @include_vendor = 1
		SET @sql = @sql + ' ,
							dr.VendorCode,
							v.VN_NAME'

	IF @include_salesclass = 1
		SET @sql = @sql + ' ,
							dr.SalesClassCode,
							sc.SC_DESCRIPTION'
	IF @include_period = 1
		SET @sql = @sql + ' ,
							dr.[Period],
							substring(dr.[Period], 1, 4),
							substring(dr.[Period], 5, 2)'
	IF @include_ad = 1
		SET @sql = @sql + ' , 
							dr.AdNumber,
							ad.AD_NBR_DESC'


	--print @sql
	execute (@sql)

END

GO

GRANT EXECUTE ON [advsp_media_results_comparison_by_client_and_type_report] TO PUBLIC AS dbo
GO