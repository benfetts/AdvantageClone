CREATE PROC [dbo].[advsp_media_manager_load_review_details]

	@CampaignIDList varchar(max),
	@ClientCodeList varchar(max),
	@ClientDivisionCodeList varchar(max),
	@ClientDivisionProductCodeList varchar(max),
	@JobNumberList varchar(max),
	@JobNumberComponentNumberList varchar(max),
	@OrderNumberList varchar(max),
	@OrderNumberLineNumberList varchar(max),
	@OrderStatusList varchar(max),
	@AEDefaultEmployeeCodeList varchar(max),
	@AEJobEmployeeCodeList varchar(max),
	@UserCode varchar(100),
	@LoadForProcessControl bit,
	@VendorCodeList varchar(max),
	@SelectForServiceRefresh bit = 0,
	@BuyerEmpCodeList varchar(max),
	@LoadLockedOrders bit = 0,
	@LoadForMediaPlanOrWorksheet bit = 0

AS

BEGIN

SET NOCOUNT ON

DECLARE @EmployeeCode varchar(6),
		@HasCDPLimits bit,
        @DCProfileID bigint,
        @DCReportID bigint,
		@debug bit

SET @debug = 0

SET @HasCDPLimits = 0

IF EXISTS(SELECT 1 FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'DC_ENABLED' AND AGY_SETTINGS_VALUE = 1)
BEGIN
    SELECT @DCProfileID = CAST(AGY_SETTINGS_VALUE as bigint) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'DC_PROFILE_ID' AND COALESCE(AGY_SETTINGS_VALUE,0) <> 0
    SELECT @DCReportID = CAST(AGY_SETTINGS_VALUE as bigint) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'DC_REPORT_ID' AND COALESCE(AGY_SETTINGS_VALUE,0) <> 0
END

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserCode)

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserCode)) > 0
	SET @HasCDPLimits = 1

DECLARE @Internet bit, @Magazine bit, @Newspaper bit, @OutOfHome bit, @Radio bit, @TV bit,
		@IncludeOrder bit, @IncludeQuote bit,
		@IncludeOrderLineDates bit, @OrderLineStartDate smalldatetime, @OrderLineEndDate smalldatetime,
		@IncludeJobMediaDateToBill bit, @JobMediaStartDate smalldatetime, @JobMediaEndDate smalldatetime,
		@IncludeClosedOrders bit,
		@include_media_month bit,
		@media_month_start_date int, @media_month_end_date int --YYYYMM format

IF @LoadLockedOrders = 0 BEGIN
	SELECT @LoadLockedOrders = Custom1
	FROM dbo.V_SEC_PERMISSION
	WHERE ApplicationID = (SELECT SEC_APPLICATION_ID FROM dbo.SEC_APPLICATION WHERE NAME = 'Advantage')
	AND UserID = (SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserCode))
	AND ModuleCode = 'Media_MediaManager'
END

IF @LoadForMediaPlanOrWorksheet = 1
	SELECT
		@Internet = 1, @Magazine = 1, @Newspaper = 1, @OutOfHome = 1, @Radio = 1, @TV = 1,
		@IncludeOrder = 1,
		@IncludeQuote = 0,
		@IncludeOrderLineDates = 0,
		@OrderLineStartDate = NULL, @OrderLineEndDate = NULL,
		@IncludeJobMediaDateToBill = 0,
		@JobMediaStartDate = NULL, @JobMediaEndDate  = NULL,
		@IncludeClosedOrders = 0,
		@include_media_month = 0,
		@media_month_start_date = NULL,
		@media_month_end_date = NULL
ELSE 
	SELECT
		@Internet = SELECT_INTERNET, @Magazine = SELECT_MAGAZINE, @Newspaper = SELECT_NEWSPAPER, @OutOfHome = SELECT_OUTOFHOME, @Radio = SELECT_RADIO, @TV = SELECT_TV,
		@IncludeOrder = CASE WHEN INCLUDE_ORDER_QUOTE_BOTH IN (1,3) THEN 1 ELSE 0 END,
		@IncludeQuote = CASE WHEN INCLUDE_ORDER_QUOTE_BOTH IN (2,3) THEN 1 ELSE 0 END,
		@IncludeOrderLineDates = CASE WHEN FILTER_BY = 1 THEN 1 ELSE 0 END,
		@OrderLineStartDate = ORDER_LINE_START_DATE, @OrderLineEndDate = ORDER_LINE_END_DATE,
		@IncludeJobMediaDateToBill = CASE WHEN FILTER_BY = 2 THEN 1 ELSE 0 END,
		@JobMediaStartDate = JOB_MEDIA_START_DATE, @JobMediaEndDate  = JOB_MEDIA_END_DATE,
		@IncludeClosedOrders = INCLUDE_CLOSED_ORDERS,
		@include_media_month = CASE WHEN FILTER_BY = 3 THEN 1 ELSE 0 END,
		@media_month_start_date = CASE WHEN FILTER_BY = 3 THEN CAST(YEAR(MEDIA_MONTH_START) as varchar(4)) + RIGHT('0' + CAST(MONTH(MEDIA_MONTH_START) as varchar),2) ELSE NULL END,
		@media_month_end_date = CASE WHEN FILTER_BY = 3 THEN CAST(YEAR(MEDIA_MONTH_END) as varchar(4)) + RIGHT('0' + CAST(MONTH(MEDIA_MONTH_END) as varchar),2) ELSE NULL END
	FROM dbo.MEDIA_MGR_SEARCH_SETTING
	WHERE UPPER(MEDIA_MGR_SEARCH_SETTING_USER_CODE) = UPPER(@UserCode)

IF @LoadForProcessControl = 1 BEGIN
	SET @IncludeOrder = 1
	SET @IncludeQuote = 1
	SET @IncludeOrderLineDates = 0
	SET @IncludeJobMediaDateToBill = 0
	SET @include_media_month = 0
END

if @debug = 1 
	select getdate() 'AS START'

DECLARE @media_summary TABLE (
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	ORDER_NBR			integer NOT NULL,
	LINE_NBR			integer NOT NULL,
	OFFICE_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	CMP_IDENTIFIER		integer NULL,
	CMP_NAME			varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MARKET_CODE			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	VN_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	VN_NAME				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	LINK_ID				integer NULL,
	CLIENT_PO			varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	BUYER				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MAX_REV				integer NULL,
	ORDER_DESC			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_TYPE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_DESC				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_FROM			varchar(11) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ORDER_DATE			smalldatetime NULL,
	BRDCAST_MONTH		smalldatetime NULL,
	CLOSE_DATE			smalldatetime NULL,
	DATE_TO_BILL		smalldatetime NULL,
	NET_AMT				decimal(15,2) NULL,
	COMM_AMT			decimal(15,2) NULL,
	REBATE_AMT			decimal(15,2) NULL,
	ADDTL_CHARGES		decimal(15,2) NULL,
	DISCOUNT_AMT		decimal(15,2) NULL,
	NET_CHARGES			decimal(15,2) NULL,
	VENDOR_TAX			decimal(15,2) NULL,
	RESALE_TAX			decimal(15,2) NULL,
	BILLABLE_AMT		decimal(15,2) NULL,
	BILLED_AMT			decimal(15,2) NULL,
	AP_POSTED_AMT		decimal(15,2) NULL,
	BILL_TYPE			smallint NULL,
	ORDER_PROC_CTL		smallint NULL,
	JOB_NUMBER			int NULL,
	JOB_COMPONENT_NBR	smallint NULL,
	LINK_DETID			int NULL,
	BILLED_RESALE_TAX	decimal(15,2) NULL,
	Spots					int NULL,
	AccountExecutiveJob		varchar(65) NULL,
	IsQuote					bit NOT NULL,
	NetGross				smallint NULL,
	Headline				varchar(60) NULL,
	LineCancelled			smallint NULL,
	Material				varchar(60) NULL,
	AdNumber				varchar(30) NULL,
	StartDate				smalldatetime NULL,
	EndDate					smalldatetime NULL,
	MaterialDate			smalldatetime NULL,
	AdSizeCode				varchar(6) NULL,
	AdSizeDescription		varchar(60) NULL,
	InternetCostType		varchar(3) NULL,
	Rate					decimal(16,4) NULL,
	ProjectedImpressions	int NULL,
	GuaranteedImpressions	int NULL,
	ActualImpressions		int NULL,
	JobMediaBillDate		smalldatetime NULL,
	JobDescription			varchar(60) NULL,
	JobCompDescription		varchar(60) NULL,
	ExtendedCloseDate		smalldatetime NULL,
	ExtendedMaterialDate	smalldatetime NULL,
	InternetType			varchar(6) NULL,
	InternetPlacement1		varchar(256) NULL,
	InternetPlacement2		varchar(160) NULL,
	InternetURL				varchar(60) NULL,
	InternetTargetAudience	varchar(60) NULL,
	Issue					varchar(30) NULL,
	ProductionSize			varchar(30) NULL,
	MagazineCirculationQTY	int NULL,
	NewspaperSection		varchar(30) NULL,
	NewspaperCirculationQTY decimal(11,2) NULL,
	NewspaperCirculation	int NULL,
	NewspaperColumns		decimal(6,2) NULL,
	NewspaperInches			decimal(6,2) NULL,
	OutdoorType				varchar(6) NULL,
	OutdoorLocation			varchar(60) NULL,
	OutdoorCopyArea			varchar(40) NULL,
	BroadcastStartTime		varchar(10) NULL,
	BroadcastEndTime		varchar(10) NULL,
	BroadcastProgramming	varchar(50) NULL,
	BroadcastNetworkCode	varchar(10) NULL,
	BroadcastLength			smallint NULL,
	BroadcastRemarks		varchar(254) NULL,
	BroadcastDaysofWeek		varchar(16) NULL,
	BroadcastSpotsbyWeek	varchar(100) NULL,
	BroadcastDatesbyWeek	varchar(100) NULL,
	GrossAmount				decimal(15,2) NULL,
	BillingUser				varchar(100) NULL,
	OrderLineIsBilled		bit NULL,
	MarkupPercent			decimal(7,3) NULL,
	RebatePercent			decimal(7,3) NULL,
	NewspaperCost			varchar(3) NULL,
	NewspaperRate			varchar(3) NULL,
	IsDailyNewspaper		bit NULL,
	PaymentMethod			varchar(25) NULL,
	JobOrMediaDateToBill	smalldatetime NULL,
	MonthYear				varchar(8) NULL,
	BuyerEmployeeCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	BillCoopCode			varchar(6),
	AdServerPlacementID		bigint NULL,
	PackageParent			bit NULL,
	OrderAccepted			bit NOT NULL,
	RevisedBy				varchar(100) NULL,
	AP_EXISTS				smallint NULL,
	WorksheetLineNumber		int NULL,
	AdServerPackageID		bigint NULL,
	MatCompDate				smalldatetime NULL,
    LineMarketCode  		varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    LineMarketDesc  		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    MediaChannelID  		int NULL,
    MediaTacticID   		int NULL
)

IF ( @Internet = 1 OR @SelectForServiceRefresh = 1 )
BEGIN
	INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
		OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
		LINK_ID, LINK_DETID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
		MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL,	JOB_NUMBER, JOB_COMPONENT_NBR,
		AccountExecutiveJob, IsQuote, NetGross, JobMediaBillDate,
		JobDescription, JobCompDescription, ExtendedCloseDate, ExtendedMaterialDate,
		InternetType, InternetPlacement1, InternetPlacement2, InternetURL, InternetTargetAudience, MarkupPercent, RebatePercent, PaymentMethod, JobOrMediaDateToBill, BuyerEmployeeCode, BillCoopCode, AdServerPlacementID, PackageParent, OrderAccepted,
		RevisedBy, AdServerPackageID, MatCompDate, LineMarketCode, LineMarketDesc, MediaChannelID, MediaTacticID)
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, d.ORDER_NBR, d.LINE_NBR, 
		p.OFFICE_CODE, h.CMP_IDENTIFIER, c.CMP_NAME, h.MARKET_CODE, h.VN_CODE, v.VN_NAME,
		h.LINK_ID, d.LINK_DETID, h.CLIENT_PO, h.BUYER, d.REV_NBR, h.ORDER_DESC, h.MEDIA_TYPE, sc.SC_DESCRIPTION,
		'Internet', h.ORDER_DATE, h.ORD_PROCESS_CONTRL, d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME, COALESCE(h.[STATUS], 0), h.NET_GROSS, jc.MEDIA_BILL_DATE,
		JL.JOB_DESC, jc.JOB_COMP_DESC, d.EXT_CLOSE_DATE, d.EXT_MATL_DATE,
		d.INTERNET_TYPE, d.PLACEMENT_1, d.PLACEMENT_2, d.URL, d.TARGET_AUDIENCE, d.MARKUP_PCT, d.REBATE_PCT,
		CASE WHEN COALESCE(v.VCC_STATUS, 0) = 1 AND v.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Virtual CC' ELSE 'Check' END,
		COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL), h.BUYER_EMP_CODE, h.BILL_COOP_CODE, d.AD_SERVER_PLACEMENT_ID, d.PACKAGE_PARENT, CASE WHEN os.ORDER_NBR IS NOT NULL THEN 1 ELSE 0 END,
		os.REVISED_BY, d.AD_SERVER_PLACEMENT_GROUP_ID, d.MAT_COMP, d.MARKET_CODE, m.MARKET_DESC, d.MEDIA_CHANNEL_ID, d.MEDIA_TACTIC_ID
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON ( h.VN_CODE = v.VN_CODE )
		INNER JOIN dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE )
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( h.MEDIA_TYPE = sc.SC_CODE )
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( h.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EC ON jc.EMP_CODE = EC.EMP_CODE 
		LEFT OUTER JOIN dbo.JOB_LOG JL ON d.JOB_NUMBER = JL.JOB_NUMBER
		LEFT OUTER JOIN dbo.INTERNET_ORDER_STATUS os ON d.ORDER_NBR = os.ORDER_NBR AND d.LINE_NBR = os.LINE_NBR AND d.REV_NBR = os.REV_NBR AND os.[STATUS] = 5
        LEFT OUTER JOIN dbo.MARKET m ON m.MARKET_CODE = d.MARKET_CODE
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @IncludeOrder = 1 
		OR
			h.[STATUS] = 1 AND @IncludeQuote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @IncludeClosedOrders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @IncludeClosedOrders = 1)
		)
	AND	(h.LOCKED_BY = @UserCode OR @LoadLockedOrders = 1)
	AND ((
			( @IncludeOrderLineDates = 0 )
		OR
			( @IncludeOrderLineDates = 1 AND ( d.[START_DATE] BETWEEN @OrderLineStartDate AND @OrderLineEndDate ) )
		)
		AND
		(
			( @IncludeJobMediaDateToBill = 0 )
		OR
			( @IncludeJobMediaDateToBill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @JobMediaStartDate AND @JobMediaEndDate ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.[START_DATE]) as varchar(4)) + right('0'+ CAST(MONTH(d.[START_DATE]) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
	AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND (@JobNumberList IS NULL OR (@JobNumberList IS NOT NULL
									AND d.JOB_NUMBER IS NOT NULL 
									AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JobNumberList, ','))))
	AND (@JobNumberComponentNumberList IS NULL OR (@JobNumberComponentNumberList IS NOT NULL
													AND d.JOB_NUMBER IS NOT NULL AND d.JOB_COMPONENT_NBR IS NOT NULL
													AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@JobNumberComponentNumberList, ','))))
	AND (@OrderNumberList IS NULL OR (@OrderNumberList IS NOT NULL
										AND h.ORDER_NBR IS NOT NULL
										AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumberList, ','))))
	AND (@OrderNumberLineNumberList IS NULL OR (@OrderNumberLineNumberList IS NOT NULL
													AND d.ORDER_NBR IS NOT NULL AND d.LINE_NBR IS NOT NULL
													AND CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))))
	AND (@AEJobEmployeeCodeList IS NULL OR (@AEJobEmployeeCodeList IS NOT NULL AND jc.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEJobEmployeeCodeList, ','))))
	AND (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
	AND (@BuyerEmpCodeList IS NULL OR (@BuyerEmpCodeList IS NOT NULL AND h.BUYER_EMP_CODE IN (SELECT items FROM dbo.udf_split_list(@BuyerEmpCodeList, ','))))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	OR ( @SelectForServiceRefresh = 1 AND EXISTS (
													SELECT 1
													FROM dbo.VCC_CARD v
													WHERE v.ORDER_NBR = h.ORDER_NBR
													AND v.LINE_NBR = d.LINE_NBR
													AND v.[STATUS] = 'A'
												))
END

IF ( @Magazine = 1 OR @SelectForServiceRefresh = 1 )
BEGIN
	INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
		OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
		LINK_ID, LINK_DETID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
		MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL,	JOB_NUMBER, JOB_COMPONENT_NBR,
		AccountExecutiveJob, IsQuote, NetGross, JobMediaBillDate,
		JobDescription, JobCompDescription, ExtendedCloseDate, ExtendedMaterialDate,
		Issue, ProductionSize, MagazineCirculationQTY, MarkupPercent, RebatePercent, PaymentMethod, JobOrMediaDateToBill, BuyerEmployeeCode, BillCoopCode, OrderAccepted, RevisedBy, MatCompDate )
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, d.ORDER_NBR, d.LINE_NBR, 
		p.OFFICE_CODE, h.CMP_IDENTIFIER, c.CMP_NAME, h.MARKET_CODE, h.VN_CODE, v.VN_NAME,
		h.LINK_ID, d.LINK_DETID, h.CLIENT_PO, h.BUYER, d.REV_NBR, h.ORDER_DESC, h.MEDIA_TYPE, sc.SC_DESCRIPTION,
		'Magazine', h.ORDER_DATE, h.ORD_PROCESS_CONTRL, d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME, COALESCE(h.[STATUS], 0), h.NET_GROSS, jc.MEDIA_BILL_DATE,
		JL.JOB_DESC, jc.JOB_COMP_DESC, d.EXT_CLOSE_DATE, d.EXT_MATL_DATE,
		d.EDITION_ISSUE, d.PRODUCTION_SIZE, d.MG_CIRCULATION, d.MARKUP_PCT, d.REBATE_PCT,
		CASE WHEN COALESCE(v.VCC_STATUS, 0) = 1 AND v.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Virtual CC' ELSE 'Check' END,
		COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL), h.BUYER_EMP_CODE, h.BILL_COOP_CODE, CASE WHEN os.ORDER_NBR IS NOT NULL THEN 1 ELSE 0 END, os.REVISED_BY, d.MAT_COMP
	FROM dbo.MAGAZINE_HEADER h
		INNER JOIN dbo.MAGAZINE_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON ( h.VN_CODE = v.VN_CODE )
		INNER JOIN dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE )
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( h.MEDIA_TYPE = sc.SC_CODE )
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( h.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EC ON jc.EMP_CODE = EC.EMP_CODE 
		LEFT OUTER JOIN dbo.JOB_LOG JL ON d.JOB_NUMBER = JL.JOB_NUMBER
		LEFT OUTER JOIN dbo.MAGAZINE_ORDER_STATUS os ON d.ORDER_NBR = os.ORDER_NBR AND d.LINE_NBR = os.LINE_NBR AND d.REV_NBR = os.REV_NBR AND os.[STATUS] = 5
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @IncludeOrder = 1 
		OR
			h.[STATUS] = 1 AND @IncludeQuote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @IncludeClosedOrders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @IncludeClosedOrders = 1)
		)
	AND	(h.LOCKED_BY = @UserCode OR @LoadLockedOrders = 1)
	AND ((
			( @IncludeOrderLineDates = 0 )
		OR
			( @IncludeOrderLineDates = 1 AND ( d.[START_DATE] BETWEEN @OrderLineStartDate AND @OrderLineEndDate ) )
		)
		AND
		(
			( @IncludeJobMediaDateToBill = 0 )
		OR
			( @IncludeJobMediaDateToBill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @JobMediaStartDate AND @JobMediaEndDate ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.[START_DATE]) as varchar(4)) + right('0'+ CAST(MONTH(d.[START_DATE]) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
	AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND (@JobNumberList IS NULL OR (@JobNumberList IS NOT NULL
									AND d.JOB_NUMBER IS NOT NULL 
									AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JobNumberList, ','))))
	AND (@JobNumberComponentNumberList IS NULL OR (@JobNumberComponentNumberList IS NOT NULL
													AND d.JOB_NUMBER IS NOT NULL AND d.JOB_COMPONENT_NBR IS NOT NULL
													AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@JobNumberComponentNumberList, ','))))
	AND (@OrderNumberList IS NULL OR (@OrderNumberList IS NOT NULL
										AND h.ORDER_NBR IS NOT NULL
										AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumberList, ','))))
	AND (@OrderNumberLineNumberList IS NULL OR (@OrderNumberLineNumberList IS NOT NULL
													AND d.ORDER_NBR IS NOT NULL AND d.LINE_NBR IS NOT NULL
													AND CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))))
	AND (@AEJobEmployeeCodeList IS NULL OR (@AEJobEmployeeCodeList IS NOT NULL AND jc.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEJobEmployeeCodeList, ','))))
	AND (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
	AND (@BuyerEmpCodeList IS NULL OR (@BuyerEmpCodeList IS NOT NULL AND h.BUYER_EMP_CODE IN (SELECT items FROM dbo.udf_split_list(@BuyerEmpCodeList, ','))))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	OR ( @SelectForServiceRefresh = 1 AND EXISTS (
												SELECT 1
												FROM dbo.VCC_CARD v
												WHERE v.ORDER_NBR = h.ORDER_NBR
												AND v.LINE_NBR = d.LINE_NBR
												AND v.[STATUS] = 'A'
											))
END

IF ( @Newspaper = 1 OR @SelectForServiceRefresh = 1 )
BEGIN
	INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
		OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
		LINK_ID, LINK_DETID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
		MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL,	JOB_NUMBER, JOB_COMPONENT_NBR,
		AccountExecutiveJob, IsQuote, NetGross, JobMediaBillDate,
		JobDescription, JobCompDescription, ExtendedCloseDate, ExtendedMaterialDate,
		Issue, NewspaperSection, ProductionSize, NewspaperCirculationQTY, NewspaperCirculation, NewspaperColumns, NewspaperInches, MarkupPercent, RebatePercent, IsDailyNewspaper, PaymentMethod,
		JobOrMediaDateToBill, BuyerEmployeeCode, BillCoopCode, OrderAccepted, RevisedBy, MatCompDate )
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, d.ORDER_NBR, d.LINE_NBR, 
		p.OFFICE_CODE, h.CMP_IDENTIFIER, c.CMP_NAME, h.MARKET_CODE, h.VN_CODE, v.VN_NAME,
		h.LINK_ID, d.LINK_DETID, h.CLIENT_PO, h.BUYER, d.REV_NBR, h.ORDER_DESC, h.MEDIA_TYPE, sc.SC_DESCRIPTION,
		'Newspaper', h.ORDER_DATE, h.ORD_PROCESS_CONTRL, d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME, COALESCE(h.[STATUS], 0), h.NET_GROSS, jc.MEDIA_BILL_DATE,
		JL.JOB_DESC, jc.JOB_COMP_DESC, d.EXT_CLOSE_DATE, d.EXT_MATL_DATE,
		d.EDITION_ISSUE, d.SECTION, d.PRODUCTION_SIZE, d.PRINT_LINES, d.NP_CIRCULATION, d.PRINT_COLUMNS, d.PRINT_INCHES, d.MARKUP_PCT, d.REBATE_PCT,
		IsDailyNewspaper = CASE WHEN h.UNITS = 'D' THEN 1 ELSE 0 END,
		CASE WHEN COALESCE(v.VCC_STATUS, 0) = 1 AND v.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Virtual CC' ELSE 'Check' END,
		COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL), h.BUYER_EMP_CODE, h.BILL_COOP_CODE, CASE WHEN os.ORDER_NBR IS NOT NULL THEN 1 ELSE 0 END, os.REVISED_BY, d.MAT_COMP
	FROM dbo.NEWSPAPER_HEADER h
		INNER JOIN dbo.NEWSPAPER_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON ( h.VN_CODE = v.VN_CODE )
		INNER JOIN dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE )
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( h.MEDIA_TYPE = sc.SC_CODE )
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( h.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EC ON jc.EMP_CODE = EC.EMP_CODE 
		LEFT OUTER JOIN dbo.JOB_LOG JL ON d.JOB_NUMBER = JL.JOB_NUMBER
		LEFT OUTER JOIN dbo.NEWSPAPER_ORDER_STATUS os ON d.ORDER_NBR = os.ORDER_NBR AND d.LINE_NBR = os.LINE_NBR AND d.REV_NBR = os.REV_NBR AND os.[STATUS] = 5
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @IncludeOrder = 1 
		OR
			h.[STATUS] = 1 AND @IncludeQuote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @IncludeClosedOrders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @IncludeClosedOrders = 1)
		)
	AND	(h.LOCKED_BY = @UserCode OR @LoadLockedOrders = 1)
	AND ((
			( @IncludeOrderLineDates = 0 )
		OR
			( @IncludeOrderLineDates = 1 AND ( d.[START_DATE] BETWEEN @OrderLineStartDate AND @OrderLineEndDate ) )
		)
		AND
		(
			( @IncludeJobMediaDateToBill = 0 )
		OR
			( @IncludeJobMediaDateToBill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @JobMediaStartDate AND @JobMediaEndDate ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.[START_DATE]) as varchar(4)) + right('0'+ CAST(MONTH(d.[START_DATE]) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
	AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND (@JobNumberList IS NULL OR (@JobNumberList IS NOT NULL
									AND d.JOB_NUMBER IS NOT NULL 
									AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JobNumberList, ','))))
	AND (@JobNumberComponentNumberList IS NULL OR (@JobNumberComponentNumberList IS NOT NULL
													AND d.JOB_NUMBER IS NOT NULL AND d.JOB_COMPONENT_NBR IS NOT NULL
													AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@JobNumberComponentNumberList, ','))))
	AND (@OrderNumberList IS NULL OR (@OrderNumberList IS NOT NULL
										AND h.ORDER_NBR IS NOT NULL
										AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumberList, ','))))
	AND (@OrderNumberLineNumberList IS NULL OR (@OrderNumberLineNumberList IS NOT NULL
													AND d.ORDER_NBR IS NOT NULL AND d.LINE_NBR IS NOT NULL
													AND CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))))
	AND (@AEJobEmployeeCodeList IS NULL OR (@AEJobEmployeeCodeList IS NOT NULL AND jc.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEJobEmployeeCodeList, ','))))
	AND (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
	AND (@BuyerEmpCodeList IS NULL OR (@BuyerEmpCodeList IS NOT NULL AND h.BUYER_EMP_CODE IN (SELECT items FROM dbo.udf_split_list(@BuyerEmpCodeList, ','))))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	OR ( @SelectForServiceRefresh = 1 AND EXISTS (
													SELECT 1
													FROM dbo.VCC_CARD v
													WHERE v.ORDER_NBR = h.ORDER_NBR
													AND v.LINE_NBR = d.LINE_NBR
													AND v.[STATUS] = 'A'
												))
END

IF ( @OutOfHome = 1 OR @SelectForServiceRefresh = 1 )
BEGIN
	INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
		OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
		LINK_ID, LINK_DETID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
		MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL,	JOB_NUMBER, JOB_COMPONENT_NBR,
		AccountExecutiveJob, IsQuote, NetGross, JobMediaBillDate,
		JobDescription, JobCompDescription, ExtendedCloseDate, ExtendedMaterialDate,
		OutdoorType, OutdoorLocation, OutdoorCopyArea, MarkupPercent, RebatePercent, PaymentMethod, JobOrMediaDateToBill, BuyerEmployeeCode, BillCoopCode, OrderAccepted, RevisedBy, MatCompDate )
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, d.ORDER_NBR, d.LINE_NBR, 
		p.OFFICE_CODE, h.CMP_IDENTIFIER, c.CMP_NAME, h.MARKET_CODE, h.VN_CODE, v.VN_NAME,
		h.LINK_ID, d.LINK_DETID, h.CLIENT_PO, h.BUYER, d.REV_NBR, h.ORDER_DESC, h.MEDIA_TYPE, sc.SC_DESCRIPTION,
		'Out Of Home', h.ORDER_DATE, h.ORD_PROCESS_CONTRL, d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME, COALESCE(h.[STATUS], 0), h.NET_GROSS, jc.MEDIA_BILL_DATE,
		JL.JOB_DESC, jc.JOB_COMP_DESC, d.EXT_CLOSE_DATE, d.EXT_MATL_DATE,
		d.OUTDOOR_TYPE, d.LOCATION, d.COPY_AREA, d.MARKUP_PCT, d.REBATE_PCT,
		CASE WHEN COALESCE(v.VCC_STATUS, 0) = 1 AND v.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Virtual CC' ELSE 'Check' END,
		COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL), h.BUYER_EMP_CODE, h.BILL_COOP_CODE, CASE WHEN os.ORDER_NBR IS NOT NULL THEN 1 ELSE 0 END, os.REVISED_BY, d.MAT_COMP
	FROM dbo.OUTDOOR_HEADER h
		INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON ( h.VN_CODE = v.VN_CODE )
		INNER JOIN dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE )
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( h.MEDIA_TYPE = sc.SC_CODE )
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( h.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EC ON jc.EMP_CODE = EC.EMP_CODE 
		LEFT OUTER JOIN dbo.JOB_LOG JL ON d.JOB_NUMBER = JL.JOB_NUMBER
		LEFT OUTER JOIN dbo.OUTDOOR_ORDER_STATUS os ON d.ORDER_NBR = os.ORDER_NBR AND d.LINE_NBR = os.LINE_NBR AND d.REV_NBR = os.REV_NBR AND os.[STATUS] = 5
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @IncludeOrder = 1 
		OR
			h.[STATUS] = 1 AND @IncludeQuote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @IncludeClosedOrders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @IncludeClosedOrders = 1)
		)
	AND	(h.LOCKED_BY = @UserCode OR @LoadLockedOrders = 1)
	AND ((
			( @IncludeOrderLineDates = 0 )
		OR
			( @IncludeOrderLineDates = 1 AND ( d.POST_DATE BETWEEN @OrderLineStartDate AND @OrderLineEndDate ) )
		)
		AND
		(
			( @IncludeJobMediaDateToBill = 0 )
		OR
			( @IncludeJobMediaDateToBill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @JobMediaStartDate AND @JobMediaEndDate ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.POST_DATE) as varchar(4)) + right('0'+ CAST(MONTH(d.POST_DATE) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
	AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND (@JobNumberList IS NULL OR (@JobNumberList IS NOT NULL
									AND d.JOB_NUMBER IS NOT NULL 
									AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JobNumberList, ','))))
	AND (@JobNumberComponentNumberList IS NULL OR (@JobNumberComponentNumberList IS NOT NULL
													AND d.JOB_NUMBER IS NOT NULL AND d.JOB_COMPONENT_NBR IS NOT NULL
													AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@JobNumberComponentNumberList, ','))))
	AND (@OrderNumberList IS NULL OR (@OrderNumberList IS NOT NULL
										AND h.ORDER_NBR IS NOT NULL
										AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumberList, ','))))
	AND (@OrderNumberLineNumberList IS NULL OR (@OrderNumberLineNumberList IS NOT NULL
													AND d.ORDER_NBR IS NOT NULL AND d.LINE_NBR IS NOT NULL
													AND CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))))
	AND (@AEJobEmployeeCodeList IS NULL OR (@AEJobEmployeeCodeList IS NOT NULL AND jc.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEJobEmployeeCodeList, ','))))
	AND (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
	AND (@BuyerEmpCodeList IS NULL OR (@BuyerEmpCodeList IS NOT NULL AND h.BUYER_EMP_CODE IN (SELECT items FROM dbo.udf_split_list(@BuyerEmpCodeList, ','))))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	OR ( @SelectForServiceRefresh = 1 AND EXISTS (
													SELECT 1
													FROM dbo.VCC_CARD v
													WHERE v.ORDER_NBR = h.ORDER_NBR
													AND v.LINE_NBR = d.LINE_NBR
													AND v.[STATUS] = 'A'
												))
END

IF ( @Radio = 1 OR @SelectForServiceRefresh = 1 )
BEGIN
	INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
		OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
		LINK_ID, LINK_DETID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
		MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL,	JOB_NUMBER, JOB_COMPONENT_NBR,
		AccountExecutiveJob, IsQuote, NetGross, JobMediaBillDate,
		JobDescription, JobCompDescription, ExtendedCloseDate, ExtendedMaterialDate,
		BroadcastStartTime, BroadcastEndTime, BroadcastProgramming, BroadcastNetworkCode, BroadcastLength, BroadcastRemarks, 
		BroadcastDaysofWeek, BroadcastSpotsbyWeek, BroadcastDatesbyWeek, MarkupPercent, RebatePercent, PaymentMethod, 
		JobOrMediaDateToBill, BuyerEmployeeCode, BillCoopCode, OrderAccepted, RevisedBy, WorksheetLineNumber, MatCompDate )
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, d.ORDER_NBR, d.LINE_NBR, 
		p.OFFICE_CODE, h.CMP_IDENTIFIER, c.CMP_NAME, h.MARKET_CODE, h.VN_CODE, v.VN_NAME,
		h.LINK_ID, d.LINK_DETID, h.CLIENT_PO, h.BUYER, d.REV_NBR, h.ORDER_DESC, h.MEDIA_TYPE, sc.SC_DESCRIPTION,
		'Radio', h.ORDER_DATE, h.ORD_PROCESS_CONTRL, d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME, COALESCE(h.[STATUS], 0), h.NET_GROSS, jc.MEDIA_BILL_DATE,
		JL.JOB_DESC, jc.JOB_COMP_DESC, d.EXT_CLOSE_DATE, d.EXT_MATL_DATE,
		d.START_TIME, d.END_TIME, d.PROGRAMMING, d.NETWORK_ID, d.[LENGTH], d.REMARKS,
		BroadcastDatesbyWeek = (CASE WHEN d.MONDAY = 1 THEN 'M ' ELSE '' END +
								 CASE WHEN d.TUESDAY = 1 THEN 'T ' ELSE '' END +
								 CASE WHEN d.WEDNESDAY = 1 THEN 'W ' ELSE '' END +
								 CASE WHEN d.THURSDAY = 1 THEN 'TH ' ELSE '' END +
								 CASE WHEN d.FRIDAY = 1 THEN 'F ' ELSE '' END +
								 CASE WHEN d.SATURDAY = 1 THEN 'SA ' ELSE '' END +
								 CASE WHEN d.SUNDAY = 1 THEN 'SU ' ELSE '' END), NULL, NULL, d.MARKUP_PCT, d.REBATE_PCT,
		CASE WHEN COALESCE(v.VCC_STATUS, 0) = 1 AND v.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Virtual CC' ELSE 'Check' END,
		COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL), h.BUYER_EMP_CODE, h.BILL_COOP_CODE, 
		CASE WHEN os.ORDER_NBR IS NOT NULL THEN 1 ELSE 0 END, os.REVISED_BY, d.LINK_LINE_NUMBER, d.MAT_COMP
	FROM dbo.RADIO_HDR h
		INNER JOIN dbo.RADIO_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON ( h.VN_CODE = v.VN_CODE )
		INNER JOIN dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE )
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( h.MEDIA_TYPE = sc.SC_CODE )
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( h.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EC ON jc.EMP_CODE = EC.EMP_CODE 
		LEFT OUTER JOIN dbo.JOB_LOG JL ON d.JOB_NUMBER = JL.JOB_NUMBER
		LEFT OUTER JOIN dbo.RADIO_ORDER_STATUS os ON d.ORDER_NBR = os.ORDER_NBR AND d.LINE_NBR = os.LINE_NBR AND d.REV_NBR = os.REV_NBR AND os.[STATUS] = 5
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @IncludeOrder = 1 
		OR
			h.[STATUS] = 1 AND @IncludeQuote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @IncludeClosedOrders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @IncludeClosedOrders = 1)
		)
	AND	(h.LOCKED_BY = @UserCode OR @LoadLockedOrders = 1)
	AND ((
			( @IncludeOrderLineDates = 0 )
		OR
			( @IncludeOrderLineDates = 1 AND ( d.[START_DATE] BETWEEN @OrderLineStartDate AND @OrderLineEndDate ) )
		)
		AND
		(
			( @IncludeJobMediaDateToBill = 0 )
		OR
			( @IncludeJobMediaDateToBill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @JobMediaStartDate AND @JobMediaEndDate ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(d.[YEAR_NBR] as varchar(4)) + right('0'+ CAST(d.[MONTH_NBR] as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
	AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND (@JobNumberList IS NULL OR (@JobNumberList IS NOT NULL
									AND d.JOB_NUMBER IS NOT NULL 
									AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JobNumberList, ','))))
	AND (@JobNumberComponentNumberList IS NULL OR (@JobNumberComponentNumberList IS NOT NULL
													AND d.JOB_NUMBER IS NOT NULL AND d.JOB_COMPONENT_NBR IS NOT NULL
													AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@JobNumberComponentNumberList, ','))))
	AND (@OrderNumberList IS NULL OR (@OrderNumberList IS NOT NULL
										AND h.ORDER_NBR IS NOT NULL
										AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumberList, ','))))
	AND (@OrderNumberLineNumberList IS NULL OR (@OrderNumberLineNumberList IS NOT NULL
													AND d.ORDER_NBR IS NOT NULL AND d.LINE_NBR IS NOT NULL
													AND CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))))
	AND (@AEJobEmployeeCodeList IS NULL OR (@AEJobEmployeeCodeList IS NOT NULL AND jc.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEJobEmployeeCodeList, ','))))
	AND (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
	AND (@BuyerEmpCodeList IS NULL OR (@BuyerEmpCodeList IS NOT NULL AND h.BUYER_EMP_CODE IN (SELECT items FROM dbo.udf_split_list(@BuyerEmpCodeList, ','))))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	OR ( @SelectForServiceRefresh = 1 AND EXISTS (
													SELECT 1
													FROM dbo.VCC_CARD v
													WHERE v.ORDER_NBR = h.ORDER_NBR
													AND v.LINE_NBR = d.LINE_NBR
													AND v.[STATUS] = 'A'
												))
END

IF ( @TV = 1 OR @SelectForServiceRefresh = 1 )
BEGIN
	INSERT INTO @media_summary ( CL_CODE, DIV_CODE, PRD_CODE, ORDER_NBR, LINE_NBR,
		OFFICE_CODE, CMP_IDENTIFIER, CMP_NAME, MARKET_CODE, VN_CODE, VN_NAME, 
		LINK_ID, LINK_DETID, CLIENT_PO, BUYER, MAX_REV, ORDER_DESC, MEDIA_TYPE, SC_DESC, 
		MEDIA_FROM, ORDER_DATE, ORDER_PROC_CTL,	JOB_NUMBER, JOB_COMPONENT_NBR,
		AccountExecutiveJob, IsQuote, NetGross, JobMediaBillDate,
		JobDescription, JobCompDescription, ExtendedCloseDate, ExtendedMaterialDate,
		BroadcastStartTime, BroadcastEndTime, BroadcastProgramming, BroadcastNetworkCode, BroadcastLength, BroadcastRemarks, 
		BroadcastDaysofWeek, BroadcastSpotsbyWeek, BroadcastDatesbyWeek, MarkupPercent, RebatePercent, PaymentMethod, 
		JobOrMediaDateToBill, BuyerEmployeeCode, BillCoopCode, OrderAccepted, RevisedBy, WorksheetLineNumber, MatCompDate )
	SELECT h.CL_CODE, h.DIV_CODE, h.PRD_CODE, d.ORDER_NBR, d.LINE_NBR, 
		p.OFFICE_CODE, h.CMP_IDENTIFIER, c.CMP_NAME, h.MARKET_CODE, h.VN_CODE, v.VN_NAME,
		h.LINK_ID, d.LINK_DETID, h.CLIENT_PO, h.BUYER, d.REV_NBR, h.ORDER_DESC, h.MEDIA_TYPE, sc.SC_DESCRIPTION,
		'TV', h.ORDER_DATE, h.ORD_PROCESS_CONTRL, d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME, COALESCE(h.[STATUS], 0), h.NET_GROSS, jc.MEDIA_BILL_DATE,
		JL.JOB_DESC, jc.JOB_COMP_DESC, d.EXT_CLOSE_DATE, d.EXT_MATL_DATE,
		d.START_TIME, d.END_TIME, d.PROGRAMMING, d.NETWORK_ID, d.[LENGTH], d.REMARKS,
		BroadcastDatesbyWeek = (CASE WHEN d.MONDAY = 1 THEN 'M ' ELSE '' END +
								 CASE WHEN d.TUESDAY = 1 THEN 'T ' ELSE '' END +
								 CASE WHEN d.WEDNESDAY = 1 THEN 'W ' ELSE '' END +
								 CASE WHEN d.THURSDAY = 1 THEN 'TH ' ELSE '' END +
								 CASE WHEN d.FRIDAY = 1 THEN 'F ' ELSE '' END +
								 CASE WHEN d.SATURDAY = 1 THEN 'SA ' ELSE '' END +
								 CASE WHEN d.SUNDAY = 1 THEN 'SU ' ELSE '' END), NULL, NULL, d.MARKUP_PCT, d.REBATE_PCT,
		CASE WHEN COALESCE(v.VCC_STATUS, 0) = 1 AND v.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Virtual CC' ELSE 'Check' END,
		COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL), h.BUYER_EMP_CODE, h.BILL_COOP_CODE, 
		CASE WHEN os.ORDER_NBR IS NOT NULL THEN 1 ELSE 0 END, os.REVISED_BY, d.LINK_LINE_NUMBER, d.MAT_COMP
	FROM dbo.TV_HDR h
		INNER JOIN dbo.TV_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		INNER JOIN dbo.VENDOR v ON ( h.VN_CODE = v.VN_CODE )
		INNER JOIN dbo.PRODUCT p ON ( h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE )
		LEFT OUTER JOIN dbo.SALES_CLASS sc ON ( h.MEDIA_TYPE = sc.SC_CODE )
		LEFT OUTER JOIN dbo.CAMPAIGN c ON ( h.CMP_IDENTIFIER = c.CMP_IDENTIFIER )
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EC ON jc.EMP_CODE = EC.EMP_CODE 
		LEFT OUTER JOIN dbo.JOB_LOG JL ON d.JOB_NUMBER = JL.JOB_NUMBER
		LEFT OUTER JOIN dbo.TV_ORDER_STATUS os ON d.ORDER_NBR = os.ORDER_NBR AND d.LINE_NBR = os.LINE_NBR AND d.REV_NBR = os.REV_NBR AND os.[STATUS] = 5
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @IncludeOrder = 1 
		OR
			h.[STATUS] = 1 AND @IncludeQuote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @IncludeClosedOrders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @IncludeClosedOrders = 1)
		)
	AND	(h.LOCKED_BY = @UserCode OR @LoadLockedOrders = 1)
	AND ((
			( @IncludeOrderLineDates = 0 )
		OR
			( @IncludeOrderLineDates = 1 AND ( d.[START_DATE] BETWEEN @OrderLineStartDate AND @OrderLineEndDate ) )
		)
		AND
		(
			( @IncludeJobMediaDateToBill = 0 )
		OR
			( @IncludeJobMediaDateToBill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @JobMediaStartDate AND @JobMediaEndDate ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(d.[YEAR_NBR] as varchar(4)) + right('0'+ CAST(d.[MONTH_NBR] as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
	AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND (@JobNumberList IS NULL OR (@JobNumberList IS NOT NULL
									AND d.JOB_NUMBER IS NOT NULL 
									AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JobNumberList, ','))))
	AND (@JobNumberComponentNumberList IS NULL OR (@JobNumberComponentNumberList IS NOT NULL
													AND d.JOB_NUMBER IS NOT NULL AND d.JOB_COMPONENT_NBR IS NOT NULL
													AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@JobNumberComponentNumberList, ','))))
	AND (@OrderNumberList IS NULL OR (@OrderNumberList IS NOT NULL
										AND h.ORDER_NBR IS NOT NULL
										AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@OrderNumberList, ','))))
	AND (@OrderNumberLineNumberList IS NULL OR (@OrderNumberLineNumberList IS NOT NULL
													AND d.ORDER_NBR IS NOT NULL AND d.LINE_NBR IS NOT NULL
													AND CAST(d.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))))
	AND (@AEJobEmployeeCodeList IS NULL OR (@AEJobEmployeeCodeList IS NOT NULL AND jc.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEJobEmployeeCodeList, ','))))
	AND (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
	AND (@BuyerEmpCodeList IS NULL OR (@BuyerEmpCodeList IS NOT NULL AND h.BUYER_EMP_CODE IN (SELECT items FROM dbo.udf_split_list(@BuyerEmpCodeList, ','))))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@UserCode)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	OR ( @SelectForServiceRefresh = 1 AND EXISTS (
													SELECT 1
													FROM dbo.VCC_CARD v
													WHERE v.ORDER_NBR = h.ORDER_NBR
													AND v.LINE_NBR = d.LINE_NBR
													AND v.[STATUS] = 'A'
												))
END

if @debug = 1 
	select getdate(), count(1) from @media_summary

-- MAGAZINE
UPDATE @media_summary SET
		NET_AMT = 0.00,
		VENDOR_TAX = 0.00,
		RESALE_TAX = 0.00,
		COMM_AMT = 0.00,
		NET_CHARGES = 0.00,
		DISCOUNT_AMT = 0.00,
		ADDTL_CHARGES = 0.00,
		REBATE_AMT = 0.00,
		BILLABLE_AMT = 0.00,
		CLOSE_DATE = md.CLOSE_DATE,
		BILL_TYPE = md.BILL_TYPE_FLAG,
		DATE_TO_BILL = md.DATE_TO_BILL,
		--Qty = md.QUANTITY,
		Headline = md.HEADLINE,
		LineCancelled = md.LINE_CANCELLED,
		Material = md.MATERIAL,
		AdNumber = md.AD_NUMBER,
		StartDate = md.[START_DATE],
		EndDate = md.END_DATE,
		MaterialDate = md.MATL_CLOSE_DATE,
		AdSizeCode = md.SIZE_CODE,
		AdSizeDescription = CASE WHEN ads.SIZE_CODE IS NULL THEN md.SIZE ELSE ads.SIZE_DESC END,
		Rate = CASE ms.NetGross 
				WHEN 0 THEN md.NET_RATE
				WHEN 1 THEN md.GROSS_RATE
			   END
FROM @media_summary ms 
	INNER JOIN dbo.MAGAZINE_DETAIL md
					ON ( ms.ORDER_NBR = md.ORDER_NBR )
				   AND ( ms.LINE_NBR = md.LINE_NBR )
				   AND ( md.ACTIVE_REV = 1 )
				   AND ( ms.MEDIA_FROM = 'Magazine' )
	LEFT OUTER JOIN dbo.AD_SIZE ads ON md.SIZE_CODE = ads.SIZE_CODE 
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after MAGAZINE update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( md.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( md.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( md.STATE_AMT, 0.00 ) + COALESCE( md.COUNTY_AMT, 0.00 ) + COALESCE( md.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( md.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( md.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( md.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( md.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( md.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( md.BILLING_AMT, 0.00 ),
		   GrossAmount = COALESCE( md.EXT_GROSS_AMT, 0.00 ),
		   BillingUser = md.BILLING_USER,
		   OrderLineIsBilled = CASE WHEN md.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END
	FROM @media_summary ms 
			INNER JOIN dbo.MAGAZINE_DETAIL md
					ON ( ms.ORDER_NBR = md.ORDER_NBR )
				   AND ( ms.LINE_NBR = md.LINE_NBR )
				   AND ( md.ACTIVE_REV = 1 )
  				   AND ( md.LINE_CANCELLED = 0 OR md.LINE_CANCELLED IS NULL )
				   AND ( ms.MEDIA_FROM = 'Magazine' )
	OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after MAGAZINE update2'

UPDATE @media_summary	 
	SET BILLED_AMT = (SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						FROM dbo.MAGAZINE_DETAIL d   
						WHERE ms.ORDER_NBR = d.ORDER_NBR
						AND ms.LINE_NBR = d.LINE_NBR
						AND d.AR_INV_NBR IS NOT NULL),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.MAGAZINE_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms
   WHERE	( ms.MEDIA_FROM = 'Magazine' )
   OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after MAGAZINE update4'

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.DISBURSED_AMT, 0.00 )), 0.00 ) 
                            FROM dbo.AP_MAGAZINE ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
							 AND ms.MEDIA_FROM = 'Magazine')
   FROM @media_summary ms                             
   WHERE ms.MEDIA_FROM = 'Magazine'
   OPTION (RECOMPILE)

UPDATE @media_summary
SET AP_EXISTS = 1
FROM @media_summary ms
	INNER JOIN dbo.AP_MAGAZINE ap ON ms.ORDER_NBR = ap.ORDER_NBR AND ms.LINE_NBR = ap.ORDER_LINE_NBR AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
WHERE ms.MEDIA_FROM = 'Magazine'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after MAGAZINE update6'

UPDATE @media_summary SET
		NET_AMT = 0.00,
		VENDOR_TAX = 0.00,
		RESALE_TAX = 0.00,
		COMM_AMT = 0.00,
		NET_CHARGES = 0.00,
		DISCOUNT_AMT = 0.00,
		ADDTL_CHARGES = 0.00,
		REBATE_AMT = 0.00,
		BILLABLE_AMT = 0.00,
		CLOSE_DATE = nd.CLOSE_DATE,
		BILL_TYPE = nd.BILL_TYPE_FLAG,
		DATE_TO_BILL = nd.DATE_TO_BILL,
		--Qty = nd.QUANTITY,
		Headline = nd.HEADLINE,
		LineCancelled = nd.LINE_CANCELLED,
		Material = nd.MATERIAL,
		AdNumber = nd.AD_NUMBER,
		StartDate = nd.[START_DATE],
		EndDate = nd.END_DATE,
		MaterialDate = nd.MATL_CLOSE_DATE,
		AdSizeCode = nd.SIZE_CODE,
		AdSizeDescription = CASE WHEN ads.SIZE_CODE IS NULL THEN nd.SIZE ELSE ads.SIZE_DESC END,
		NewspaperCost = nd.COST_TYPE,
		NewspaperRate = nd.RATE_TYPE,
		Rate = CASE ms.NetGross 
				WHEN 0 THEN nd.EXT_NET_AMT / CASE WHEN COALESCE(nd.CONTRACT_QTY, 0) = 0 THEN 1 ELSE nd.CONTRACT_QTY END  -- nd.NET_RATE
				WHEN 1 THEN nd.EXT_GROSS_AMT / CASE WHEN COALESCE(nd.CONTRACT_QTY, 0) = 0 THEN 1 ELSE nd.CONTRACT_QTY END  -- nd.GROSS_RATE
			   END
FROM @media_summary ms 
	INNER JOIN dbo.NEWSPAPER_DETAIL nd
		ON ( ms.ORDER_NBR = nd.ORDER_NBR )
		AND ( ms.LINE_NBR = nd.LINE_NBR )
		AND ( nd.ACTIVE_REV = 1 )
		AND ( ms.MEDIA_FROM = 'Newspaper' ) 
	LEFT OUTER JOIN dbo.AD_SIZE ads ON nd.SIZE_CODE = ads.SIZE_CODE 
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after NEWS update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( nd.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( nd.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( nd.STATE_AMT, 0.00 ) + COALESCE( nd.COUNTY_AMT, 0.00 ) + COALESCE( nd.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( nd.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( nd.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( nd.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( nd.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( nd.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( nd.BILLING_AMT, 0.00 ),
		   GrossAmount = COALESCE( nd.EXT_GROSS_AMT, 0.00 ),
		   BillingUser = nd.BILLING_USER,
		   OrderLineIsBilled = CASE WHEN nd.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END
	  FROM @media_summary ms 
INNER JOIN dbo.NEWSPAPER_DETAIL nd
	    ON ( ms.ORDER_NBR = nd.ORDER_NBR )
	   AND ( ms.LINE_NBR = nd.LINE_NBR )
	   AND ( nd.ACTIVE_REV = 1 )
  	   AND ( nd.LINE_CANCELLED = 0 OR nd.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Newspaper' )
	   OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after NEWS update2'

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.NEWSPAPER_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.NEWSPAPER_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'Newspaper'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after NEWS update4'

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.DISBURSED_AMT, 0.00 )), 0.00 ) 
                            FROM dbo.AP_NEWSPAPER ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
							 AND ms.MEDIA_FROM = 'Newspaper')
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'Newspaper'
OPTION (RECOMPILE)

UPDATE @media_summary
SET AP_EXISTS = 1
FROM @media_summary ms
	INNER JOIN dbo.AP_NEWSPAPER ap ON ms.ORDER_NBR = ap.ORDER_NBR AND ms.LINE_NBR = ap.ORDER_LINE_NBR AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
WHERE ms.MEDIA_FROM = 'Newspaper'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after NEWS update6'

UPDATE @media_summary SET
		NET_AMT = 0.00,
		VENDOR_TAX = 0.00,
		RESALE_TAX = 0.00,
		COMM_AMT = 0.00,
		NET_CHARGES = 0.00,
		DISCOUNT_AMT = 0.00,
		ADDTL_CHARGES = 0.00,
		REBATE_AMT = 0.00,
		BILLABLE_AMT = 0.00,
		CLOSE_DATE = id.CLOSE_DATE,
		BILL_TYPE = id.BILL_TYPE_FLAG,
		DATE_TO_BILL = id.DATE_TO_BILL,
		Headline = id.HEADLINE,
		LineCancelled = id.LINE_CANCELLED,
		Material = NULL,
		AdNumber = id.AD_NUMBER,
		StartDate = id.[START_DATE],
		EndDate = id.END_DATE,
		MaterialDate = id.MATL_CLOSE_DATE,
		AdSizeCode = id.SIZE,
		AdSizeDescription = CASE WHEN ads.SIZE_CODE IS NULL THEN id.CREATIVE_SIZE ELSE ads.SIZE_DESC END,
		InternetCostType = id.COST_TYPE,
		Rate = CASE
				WHEN ms.NetGross = 0 THEN id.NET_BASE_RATE
				WHEN ms.NetGross = 1 THEN id.GROSS_BASE_RATE
			   END,
		ProjectedImpressions = id.PROJ_IMPRESSIONS,
		GuaranteedImpressions = id.GUARANTEED_IMPRESS,
		ActualImpressions = id.ACT_IMPRESSIONS
FROM @media_summary ms 
	INNER JOIN dbo.INTERNET_DETAIL id
	    ON ( ms.ORDER_NBR = id.ORDER_NBR )
	   AND ( ms.LINE_NBR = id.LINE_NBR )
	   AND ( id.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'Internet' )
	LEFT OUTER JOIN dbo.AD_SIZE ads ON id.SIZE = ads.SIZE_CODE 
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after INTERNET update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( id.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( id.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( id.STATE_AMT, 0.00 ) + COALESCE( id.COUNTY_AMT, 0.00 ) + COALESCE( id.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( id.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( id.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( id.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( id.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( id.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( id.BILLING_AMT, 0.00 ),
		   GrossAmount = COALESCE( id.EXT_GROSS_AMT, 0.00 ),
		   BillingUser = id.BILLING_USER,
		   OrderLineIsBilled = CASE WHEN id.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END
	  FROM @media_summary ms 
INNER JOIN dbo.INTERNET_DETAIL id
	    ON ( ms.ORDER_NBR = id.ORDER_NBR )
	   AND ( ms.LINE_NBR = id.LINE_NBR )
	   AND ( id.ACTIVE_REV = 1 )	  
  	   AND ( id.LINE_CANCELLED = 0 OR id.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Internet' ) 
	OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after INTERNET update2'

	UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.INTERNET_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.INTERNET_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
	FROM @media_summary ms 
	WHERE ms.MEDIA_FROM = 'Internet'
	OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after INTERNET update4'

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )) + SUM(COALESCE(ap.DISCOUNT_AMT,0)) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_INTERNET ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
							 AND ms.MEDIA_FROM = 'Internet')
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'Internet'
OPTION (RECOMPILE)

UPDATE @media_summary
SET AP_EXISTS = 1
FROM @media_summary ms
	INNER JOIN dbo.AP_INTERNET ap ON ms.ORDER_NBR = ap.ORDER_NBR AND ms.LINE_NBR = ap.ORDER_LINE_NBR AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
WHERE ms.MEDIA_FROM = 'Internet'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after INTERNET update6'

UPDATE @media_summary SET 
		NET_AMT = 0.00,
		VENDOR_TAX = 0.00,
		RESALE_TAX = 0.00,
		COMM_AMT = 0.00,
		NET_CHARGES = 0.00,
		DISCOUNT_AMT = 0.00,
		ADDTL_CHARGES = 0.00,
		REBATE_AMT = 0.00,
		BILLABLE_AMT = 0.00,
		CLOSE_DATE = od.CLOSE_DATE,
		BILL_TYPE = od.BILL_TYPE_FLAG,
		DATE_TO_BILL = od.DATE_TO_BILL,
		--Qty = od.QUANTITY,
		Headline = od.HEADLINE,
		LineCancelled = od.LINE_CANCELLED,
		Material = NULL,
		AdNumber = od.AD_NUMBER,
		StartDate = od.POST_DATE,
		EndDate = od.END_DATE,
		MaterialDate = od.MATL_CLOSE_DATE,
		AdSizeCode = od.SIZE,
		AdSizeDescription = ads.SIZE_DESC,
		Rate = CASE ms.NetGross 
				WHEN 0 THEN od.NET_RATE
				WHEN 1 THEN od.GROSS_RATE
			   END,
		GuaranteedImpressions = od.IMPRESSIONS,
		ActualImpressions = od.ACTUAL_IMPRESSIONS
FROM @media_summary ms 
	INNER JOIN dbo.OUTDOOR_DETAIL od
	    ON ( ms.ORDER_NBR = od.ORDER_NBR )
	   AND ( ms.LINE_NBR = od.LINE_NBR )
	   AND ( od.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'Out Of Home' )
	LEFT OUTER JOIN dbo.AD_SIZE ads ON od.SIZE = ads.SIZE_CODE 
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after OUTDOOR update1'

	UPDATE @media_summary
	   SET NET_AMT = COALESCE( od.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( od.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( od.STATE_AMT, 0.00 ) + COALESCE( od.COUNTY_AMT, 0.00 ) + COALESCE( od.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( od.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( od.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( od.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( od.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( od.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( od.BILLING_AMT, 0.00 ),
		   GrossAmount = COALESCE( od.EXT_GROSS_AMT, 0.00 ),
		   BillingUser = od.BILLING_USER,
		   OrderLineIsBilled = CASE WHEN od.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END
	  FROM @media_summary ms 
INNER JOIN dbo.OUTDOOR_DETAIL od
	    ON ( ms.ORDER_NBR = od.ORDER_NBR )
	   AND ( ms.LINE_NBR = od.LINE_NBR )
	   AND ( od.ACTIVE_REV = 1 )
  	   AND ( od.LINE_CANCELLED = 0 OR od.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'Out Of Home' ) 
	   OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after OUTDOOR update2'

 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.OUTDOOR_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.OUTDOOR_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'Out Of Home'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after OUTDOOR update4'

 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.NET_AMT, 0.00 )) + SUM(COALESCE(ap.DISCOUNT_AMT,0)) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_OUTDOOR ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
							 AND ms.MEDIA_FROM = 'Out Of Home')
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'Out Of Home'
OPTION (RECOMPILE)

UPDATE @media_summary
SET AP_EXISTS = 1
FROM @media_summary ms
	INNER JOIN dbo.AP_OUTDOOR ap ON ms.ORDER_NBR = ap.ORDER_NBR AND ms.LINE_NBR = ap.ORDER_LINE_NBR AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
WHERE ms.MEDIA_FROM = 'Out Of Home'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after OUTDOOR update6'


-- BEGIN NEW RADIO
UPDATE @media_summary SET
		NET_AMT = 0.00,
		VENDOR_TAX = 0.00,
		RESALE_TAX = 0.00,
		COMM_AMT = 0.00,
		NET_CHARGES = 0.00,
		DISCOUNT_AMT = 0.00,
		ADDTL_CHARGES = 0.00,
		REBATE_AMT = 0.00,
		BILLABLE_AMT = 0.00,
		CLOSE_DATE = rd.CLOSE_DATE, 
		BRDCAST_MONTH = ( CAST( CAST( rd.MONTH_NBR AS varchar(2)) + '/01/' + CAST( rd.YEAR_NBR AS varchar(4)) AS smalldatetime )),
		BILL_TYPE = rd.BILL_TYPE_FLAG,
		DATE_TO_BILL = rd.DATE_TO_BILL,
		Spots = rd.TOTAL_SPOTS,
		Headline = NULL,
		LineCancelled = rd.LINE_CANCELLED,
		Material = NULL,
		AdNumber = rd.AD_NUMBER,
		StartDate = rd.[START_DATE],
		EndDate = rd.END_DATE,
		MaterialDate = rd.MATL_CLOSE_DATE,
		AdSizeCode = NULL,
		AdSizeDescription = NULL,
		Rate = CASE ms.NetGross 
				WHEN 0 THEN rd.NET_RATE
				WHEN 1 THEN rd.GROSS_RATE
			   END,
		MonthYear = SUBSTRING(UPPER(DateName( month , DateAdd( month , rd.MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(rd.YEAR_NBR as varchar(4))
FROM @media_summary ms 
	INNER JOIN dbo.RADIO_DETAIL rd
	    ON ( ms.ORDER_NBR = rd.ORDER_NBR )
	   AND ( ms.LINE_NBR = rd.LINE_NBR )
	   AND ( rd.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'Radio' )
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after Radio update1'
	
	UPDATE @media_summary
	   SET NET_AMT = COALESCE( rd.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( rd.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( rd.STATE_AMT, 0.00 ) + COALESCE( rd.COUNTY_AMT, 0.00 ) + COALESCE( rd.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( rd.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( rd.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( rd.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( rd.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( rd.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( rd.BILLING_AMT, 0.00 ),
		   GrossAmount = COALESCE( rd.EXT_GROSS_AMT, 0.00 ),
		   BillingUser = rd.BILLING_USER,
		   OrderLineIsBilled = CASE WHEN rd.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END
	  FROM @media_summary ms 
INNER JOIN dbo.RADIO_DETAIL rd
	    ON ( ms.ORDER_NBR = rd.ORDER_NBR )
	   AND ( ms.LINE_NBR = rd.LINE_NBR )
	   AND ( rd.ACTIVE_REV = 1 )	  
  	   AND ( rd.LINE_CANCELLED = 0 OR rd.LINE_CANCELLED IS NULL )
	   AND ( ms.MEDIA_FROM = 'Radio' ) 
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after Radio update2'
	
 UPDATE @media_summary	 
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.RADIO_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.RADIO_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'Radio'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after Radio update4'
	
 UPDATE @media_summary
	SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.EXT_NET_AMT, 0.00 )) + SUM(COALESCE(ap.DISC_AMT,0)) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_RADIO ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
							 AND ms.MEDIA_FROM = 'Radio')
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'Radio'
OPTION (RECOMPILE)

UPDATE @media_summary
SET AP_EXISTS = 1
FROM @media_summary ms
	INNER JOIN dbo.AP_RADIO ap ON ms.ORDER_NBR = ap.ORDER_NBR AND ms.LINE_NBR = ap.ORDER_LINE_NBR AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
WHERE ms.MEDIA_FROM = 'Radio'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after Radio update6'
	
-- BEGIN NEW TV
UPDATE @media_summary SET
		NET_AMT = 0.00,
		VENDOR_TAX = 0.00,
		RESALE_TAX = 0.00,
		COMM_AMT = 0.00,
		NET_CHARGES = 0.00,
		DISCOUNT_AMT = 0.00,
		ADDTL_CHARGES = 0.00,
		REBATE_AMT = 0.00,
		BILLABLE_AMT = 0.00,
		BRDCAST_MONTH = ( CAST( CAST( td.MONTH_NBR AS varchar(2)) + '/01/' + CAST( td.YEAR_NBR AS varchar(4)) AS smalldatetime )),
		CLOSE_DATE = td.CLOSE_DATE,
		BILL_TYPE = td.BILL_TYPE_FLAG,
		DATE_TO_BILL = td.DATE_TO_BILL,
		Spots = td.TOTAL_SPOTS,
		Headline = NULL,
		LineCancelled = td.LINE_CANCELLED,
		Material = NULL,
		AdNumber = td.AD_NUMBER,
		StartDate = td.[START_DATE],
		EndDate = td.END_DATE,
		MaterialDate = td.MATL_CLOSE_DATE,
		AdSizeCode = NULL,
		AdSizeDescription = NULL,
		Rate = CASE ms.NetGross 
				WHEN 0 THEN td.NET_RATE
				WHEN 1 THEN td.GROSS_RATE
			   END,
		MonthYear = SUBSTRING(UPPER(DateName( month , DateAdd( month , td.MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(td.YEAR_NBR as varchar(4))
FROM @media_summary ms 
	INNER JOIN dbo.TV_DETAIL td
	    ON ( ms.ORDER_NBR = td.ORDER_NBR )
	   AND ( ms.LINE_NBR = td.LINE_NBR )
	   AND ( td.ACTIVE_REV = 1 )
	   AND ( ms.MEDIA_FROM = 'TV' ) 
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after TV update1'
	
	UPDATE @media_summary
	   SET NET_AMT = COALESCE( td.EXT_NET_AMT, 0.00 ),
		   VENDOR_TAX = COALESCE( td.NON_RESALE_AMT, 0.00 ),
		   RESALE_TAX = COALESCE( td.STATE_AMT, 0.00 ) + COALESCE( td.COUNTY_AMT, 0.00 ) + COALESCE( td.CITY_AMT, 0.00 ),
		   COMM_AMT = COALESCE( td.COMM_AMT, 0.00 ),
		   NET_CHARGES = COALESCE( td.NETCHARGE, 0.00 ),
		   DISCOUNT_AMT = COALESCE( td.DISCOUNT_AMT, 0.00 ),
		   ADDTL_CHARGES = COALESCE( td.ADDL_CHARGE, 0.00 ),
		   REBATE_AMT = COALESCE( td.REBATE_AMT, 0.00 ),
		   BILLABLE_AMT = COALESCE( td.BILLING_AMT, 0.00 ),
		   GrossAmount = COALESCE( td.EXT_GROSS_AMT, 0.00 ),
		   BillingUser = td.BILLING_USER,
		   OrderLineIsBilled = CASE WHEN td.AR_INV_NBR IS NOT NULL THEN 1 ELSE 0 END
	  FROM @media_summary ms 
INNER JOIN dbo.TV_DETAIL td
	    ON ( ms.ORDER_NBR = td.ORDER_NBR )
	   AND ( ms.LINE_NBR = td.LINE_NBR )
	   AND ( td.ACTIVE_REV = 1 )
  	   AND ( td.LINE_CANCELLED = 0 OR td.LINE_CANCELLED IS NULL )	   
	   AND ( ms.MEDIA_FROM = 'TV' )
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after TV update2'
	
 UPDATE @media_summary
    SET BILLED_AMT = ( SELECT COALESCE( SUM( d.BILLING_AMT ), 0.00 )
						 FROM dbo.TV_DETAIL d   
						WHERE ( ms.ORDER_NBR = d.ORDER_NBR )
						  AND ( ms.LINE_NBR = d.LINE_NBR )
						  AND ( d.AR_INV_NBR IS NOT NULL )),
		BILLED_RESALE_TAX = (SELECT COALESCE(SUM( COALESCE(d.STATE_AMT, 0) + COALESCE(d.COUNTY_AMT, 0) + COALESCE(d.CITY_AMT, 0)), 0)
							FROM dbo.TV_DETAIL d   
							WHERE ms.ORDER_NBR = d.ORDER_NBR
							AND ms.LINE_NBR = d.LINE_NBR
							AND d.AR_INV_NBR IS NOT NULL)
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'TV'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after TV update4'
	
 UPDATE @media_summary
    SET AP_POSTED_AMT = ( SELECT COALESCE( SUM( COALESCE( ap.EXT_NET_AMT, 0.00 )) + SUM(COALESCE(ap.DISC_AMT,0)) + SUM(COALESCE(ap.NETCHARGES,0)) + SUM(COALESCE(ap.VENDOR_TAX,0)), 0.00 )
                            FROM dbo.AP_TV ap 
                           WHERE ms.ORDER_NBR = ap.ORDER_NBR
                             AND ms.LINE_NBR = ap.ORDER_LINE_NBR
                             AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
							 AND ms.MEDIA_FROM = 'TV')
   FROM @media_summary ms 
   WHERE ms.MEDIA_FROM = 'TV'
OPTION (RECOMPILE)

UPDATE @media_summary
SET AP_EXISTS = 1
FROM @media_summary ms
	INNER JOIN dbo.AP_TV ap ON ms.ORDER_NBR = ap.ORDER_NBR AND ms.LINE_NBR = ap.ORDER_LINE_NBR AND ( ap.DELETE_FLAG IS NULL OR ap.DELETE_FLAG = 0 )
WHERE ms.MEDIA_FROM = 'TV'
OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'after TV update6'

if @debug = 1 
	select getdate() AS 'after last MS update'

	 SELECT DISTINCT
		[Buyer] = BUYER,
		[AccountExecutiveDefault] = AE.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(AE.EMP_MI, '') + ' ') + AE.EMP_LNAME,
		[AccountExecutiveJob] = ms.AccountExecutiveJob,
		[OfficeCode] = ms.OFFICE_CODE,
		[OfficeDescription] = O.OFFICE_NAME,
		[ClientCode] = ms.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = ms.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = ms.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[CampaignCode] = CMP.CMP_CODE,
		[CampaignID] = ms.CMP_IDENTIFIER,
		[CampaignName] = ms.CMP_NAME,
		[OrderProcessControl] = JPC.JOB_PROCESS_DESC,
		[OrderNumber] = ms.ORDER_NBR,
		[OrderDescription] = ORDER_DESC,
		[Quote] = ms.IsQuote,
		[NetGross] = CASE WHEN ms.NetGross = 1 THEN 'Gross' ELSE 'Net' END,
		[SalesClassCode] = ms.MEDIA_TYPE,
		[SalesClassDescription] = ms.SC_DESC,
		[LinkID] = LINK_ID,
		[ClientPO] = CLIENT_PO,
		[VendorCode] = ms.VN_CODE,
		[VendorName] = ms.VN_NAME,
		[MarketCode] = ms.MARKET_CODE,
		[MarketDescription] = M.MARKET_DESC,
		[LineNumber] = ms.LINE_NBR,
		[LinkLineID] = ms.LINK_DETID,
		[RevisionNumber] = ms.MAX_REV,
		[Cancelled] = CAST(COALESCE(ms.LineCancelled, 0) as bit),
		[OrderLineStatus] = (
							SELECT TOP 1 OS.STATUS_DESC 
							FROM
								(
								SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.INTERNET_ORDER_STATUS WHERE [STATUS] <> 11
								UNION
								SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.MAGAZINE_ORDER_STATUS WHERE [STATUS] <> 11
								UNION
								SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.NEWSPAPER_ORDER_STATUS WHERE [STATUS] <> 11
								UNION
								SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.OUTDOOR_ORDER_STATUS WHERE [STATUS] <> 11
								UNION
								SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.RADIO_ORDER_STATUS WHERE [STATUS] <> 11
								UNION
								SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.TV_ORDER_STATUS WHERE [STATUS] <> 11
								) Statuses
									INNER JOIN dbo.ORDER_STATUS OS ON Statuses.[STATUS] = OS.[STATUS] 
							WHERE ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR AND REV_NBR = ms.MAX_REV
							ORDER BY REVISED_DATE DESC, REC_ID DESC
							),
		[AcceptanceDetails] = (
								SELECT TOP 1 'Rev ' + CAST(Statuses.REV_NBR as varchar) + ' - ' + convert(varchar, Statuses.REVISED_DATE, 101) + ' ' + ltrim(right(convert(varchar(32),Statuses.REVISED_DATE,100),8)) + ' - by ' + Statuses.REVISED_BY_NAME
								FROM
									(
									SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.INTERNET_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR
									UNION
									SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.MAGAZINE_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR
									UNION
									SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.NEWSPAPER_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR
									UNION
									SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.OUTDOOR_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR
									UNION
									SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.RADIO_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR
									UNION
									SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.TV_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR
									) Statuses
								--WHERE ORDER_NBR = ms.ORDER_NBR and LINE_NBR = ms.LINE_NBR
								ORDER BY REVISED_DATE DESC
								),
		[JobNumber] = ms.JOB_NUMBER,
		[JobDescription] = ms.JobDescription,
		[JobComponentNumber] = ms.JOB_COMPONENT_NBR,
		[JobCompDescription] = ms.JobCompDescription,
		[Headline] = ms.Headline,
		[Material] = ms.Material,
		[AdNumber] = ms.AdNumber,
		[AdSizeCode] = ms.AdSizeCode,
		[AdSizeDescription] = ms.AdSizeDescription,
		[JobMediaBillDate] = ms.JobMediaBillDate,
		[StartDate] = ms.StartDate,
		[EndDate] = ms.EndDate,
		[MonthYear] = CASE WHEN ms.MEDIA_FROM IN ('Radio','TV') THEN ms.MonthYear
						   WHEN ms.StartDate IS NOT NULL THEN UPPER(convert(char(3), ms.StartDate, 0)) + ' ' + CAST(YEAR(ms.StartDate) as varchar(4))
						   ELSE NULL END,
		[CloseDate] = CLOSE_DATE,
		[MaterialDate] = ms.MaterialDate,
		[DateToBill] = DATE_TO_BILL,
		[Spots] = ms.Spots,
		[BillType] = CASE BILL_TYPE
						WHEN 1 THEN 'Comm Only'
						WHEN 2 THEN 'Net'
						WHEN 3 THEN 'Gross'
						ELSE '' END,
		[NetAmount] = NET_AMT,
		[CommissionAmount] = COMM_AMT,
		[RebateAmount] = REBATE_AMT,
		[AdditionalChargeAmount] = ADDTL_CHARGES,
		[DiscountAmount] = DISCOUNT_AMT,
		[NetChargeAmount] = NET_CHARGES,
		[NonResaleTax] = VENDOR_TAX,
		[BillableAmount] = COALESCE(ms.BILLABLE_AMT, 0) - COALESCE(ms.RESALE_TAX, 0),
		[BillableAmountWithResaleTax] = COALESCE(ms.BILLABLE_AMT, 0),
		[ResaleTax] = COALESCE(ms.RESALE_TAX, 0),
		[ActualAmountPosted] =  ms.AP_POSTED_AMT,
		[VendorCollected]		= (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = ms.ORDER_NBR AND LINE_NBR = ms.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[VendorCollectedCopy]	= (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = ms.ORDER_NBR AND LINE_NBR = ms.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[VendorCollectedQuote] = (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = ms.ORDER_NBR AND LINE_NBR = ms.LINE_NBR AND IS_QUOTE = 1 ORDER BY COLLECTED_COST_INFO_ID DESC),
		[PaidWithOrderAmount] = CASE WHEN COALESCE(cleared.CLEARED_AMOUNT, 0) <> 0 THEN cleared.CLEARED_AMOUNT
									 WHEN COALESCE(cleared.CLEARED_AMOUNT, 0) = 0 AND COALESCE(pending.PENDING_AMOUNT, 0) <> 0 THEN pending.PENDING_AMOUNT
									 WHEN COALESCE(cleared.CLEARED_AMOUNT, 0) = 0 AND COALESCE(pending.PENDING_AMOUNT, 0) = 0 THEN 
										(SELECT CARD_AMOUNT FROM dbo.VCC_CARD WHERE ORDER_NBR = ms.ORDER_NBR AND LINE_NBR = ms.LINE_NBR)
								END,
		[BilledAmount] = COALESCE(ms.BILLED_AMT, 0) - COALESCE(ms.BILLED_RESALE_TAX, 0),
		[UnbilledTotal] = (COALESCE( ms.BILLABLE_AMT, 0) - COALESCE( ms.RESALE_TAX, 0)) - (COALESCE( ms.BILLED_AMT, 0) - COALESCE( ms.BILLED_RESALE_TAX, 0 )),
		[CashReceived] = (
							SELECT SUM(COALESCE(CCD.CR_PAY_AMT,0)) --[WriteoffAmount] = SUM(COALESCE(CCD.CR_ADJ_AMT,0))
							FROM dbo.CR_CLIENT CR
								INNER JOIN dbo.CR_CLIENT_DTL CCD ON CR.REC_ID = CCD.REC_ID AND CR.SEQ_NBR = CCD.SEQ_NBR 
							WHERE
									(CR.[STATUS] IS NULL OR CR.[STATUS] <> 'D')
							AND		CCD.AR_INV_NBR IN (
														SELECT AR_INV_NBR FROM dbo.AR_SUMMARY 
														WHERE ORDER_NBR = ms.ORDER_NBR
														AND ORDER_LINE_NBR = ms.LINE_NBR
													  )
						),
		[MediaFrom] = MEDIA_FROM,
		[InternetCostType],
		[Rate],
		[ProjectedImpressions],
		[GuaranteedImpressions],
		[ActualImpressions],
		[HasBillingApprovalStatus] = CASE WHEN ApprovedStatus.[ApprovedDateBy] IS NOT NULL THEN CAST(1 as bit) ELSE CAST(0 as bit) END,
		[BillingApprovedDateBy] = ApprovedStatus.[ApprovedDateBy],
		[ExtendedCloseDate],
		[ExtendedMaterialDate],
		InternetType,
		InternetPlacement1,
		InternetPlacement2,
		InternetURL,
		InternetTargetAudience,
		Issue,
		ProductionSize,
		MagazineCirculationQTY,
		NewspaperSection,
		NewspaperCirculationQTY, 
		NewspaperCirculation,
		NewspaperColumns,
		NewspaperInches,
		OutdoorType,
		OutdoorLocation,
		OutdoorCopyArea,
		BroadcastStartTime,
		BroadcastEndTime,
		BroadcastProgramming,
		BroadcastNetworkCode,
		BroadcastLength,
		BroadcastRemarks,
		BroadcastDaysofWeek,
		BroadcastSpotsbyWeek,
		BroadcastDatesbyWeek,
		ms.GrossAmount,
		ms.BillingUser,
		OrderLineIsBilled = CAST(COALESCE(ms.OrderLineIsBilled, 0) as bit),
		VCCCardID = (SELECT VCC_CARD_ID FROM dbo.VCC_CARD WHERE ORDER_NBR = ms.ORDER_NBR AND LINE_NBR = ms.LINE_NBR),
		MarkupPercent,
		RebatePercent,
		NewspaperCost,
		NewspaperRate,
		IsDailyNewspaper = CAST(COALESCE(IsDailyNewspaper,0) as bit),
		ProcessControl = ms.ORDER_PROC_CTL,
		ms.PaymentMethod,
		VCCClearedAmount = cleared.CLEARED_AMOUNT,
		JobOrMediaDateToBill,
		BuyerEmployeeCode,
		BillCoopCode,
		CampaignStartDate = CMP.CMP_BEG_DATE,
		CampaignEndDate = CMP.CMP_END_DATE,
		AdServerName = CASE 
						WHEN MEDIA_FROM = 'Internet' AND Ad.AD_SERVER_ID IS NOT NULL THEN Ad.[DESCRIPTION]
						WHEN MEDIA_FROM = 'Internet' AND Ad.AD_SERVER_ID IS NULL AND ms.AdServerPlacementID IS NOT NULL THEN 'DoubleClick'
						ELSE NULL END,
		AdServerPlacementID = ms.AdServerPlacementID,
		PackageParent = CAST(COALESCE(ms.PackageParent, 0) as bit),
		OrderAccepted,
		RevisedBy,
		BillTypeFlag = BILL_TYPE,
		[APExists] =  CAST(COALESCE(ms.AP_EXISTS, 0) as bit),
		WorksheetLineNumber,
		ms.AdServerPackageID,
		[SourceCode] = CASE WHEN BIX.IMPORTED_FROM IS NOT NULL THEN BIX.IMPORTED_FROM
							WHEN PIX.IMPORTED_FROM IS NOT NULL THEN PIX.IMPORTED_FROM END,
		WorksheetID = MBW.MEDIA_BROADCAST_WORKSHEET_ID,
		WorksheetName = MBW.NAME,
		PlanID = MP.MEDIA_PLAN_ID,
		PlanName = MP.[DESCRIPTION],
		EstimateID = MP.MEDIA_PLAN_DTL_ID,
		EstimateName = MP.[NAME],
		MatCompDate,
        DCProfileID = CASE WHEN C.DC_ENABLED = 1 THEN C.DC_PROFILE_ID ELSE @DCProfileID END,
        DCReportID = CASE WHEN C.DC_ENABLED = 1 THEN C.DC_REPORT_ID ELSE @DCReportID END,
        ms.LineMarketCode,
        LineMarketDescription = ms.LineMarketDesc,
        ms.MediaChannelID,
        ms.MediaTacticID,
        MediaPlanID = (SELECT TOP 1 MEDIA_PLAN_ID FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = ms.ORDER_NBR AND ORDER_LINE_NBR = ms.LINE_NBR),
        MediaPlanDetailID = (SELECT TOP 1 MEDIA_PLAN_DTL_ID FROM dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = ms.ORDER_NBR AND ORDER_LINE_NBR = ms.LINE_NBR)
	FROM @media_summary ms
		INNER JOIN dbo.JOB_PROC_CONTROLS JPC ON ms.ORDER_PROC_CTL = JPC.JOB_PROCESS_CONTRL 
		LEFT OUTER JOIN dbo.OFFICE O ON ms.OFFICE_CODE = O.OFFICE_CODE
		LEFT OUTER JOIN dbo.CLIENT C ON ms.CL_CODE = C.CL_CODE
		LEFT OUTER JOIN dbo.DIVISION D ON ms.CL_CODE = D.CL_CODE AND ms.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON ms.CL_CODE = P.CL_CODE AND ms.DIV_CODE = P.DIV_CODE AND ms.PRD_CODE = P.PRD_CODE
		LEFT OUTER JOIN dbo.CAMPAIGN CMP ON ms.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER
		LEFT OUTER JOIN dbo.AD_SERVER Ad ON CMP.AD_SERVER_ID = Ad.AD_SERVER_ID
		LEFT OUTER JOIN dbo.MARKET M ON ms.MARKET_CODE = M.MARKET_CODE 
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) AE ON ms.CL_CODE = AE.CL_CODE AND ms.DIV_CODE = AE.DIV_CODE AND ms.PRD_CODE = AE.PRD_CODE
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.INTERNET_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.MAGAZINE_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.NEWSPAPER_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.OUTDOOR_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.RADIO_ORDER_STATUS
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], [ApprovedDateBy] = CONVERT(varchar(10), REVISED_DATE, 101) + ' ' + REVISED_BY FROM dbo.TV_ORDER_STATUS
						) ApprovedStatus ON ApprovedStatus.ORDER_NBR = ms.ORDER_NBR AND ApprovedStatus.LINE_NBR = ms.LINE_NBR AND ApprovedStatus.REV_NBR = ms.MAX_REV AND ApprovedStatus.[STATUS] = 11
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS] FROM dbo.INTERNET_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS] FROM dbo.MAGAZINE_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS] FROM dbo.NEWSPAPER_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS] FROM dbo.OUTDOOR_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS] FROM dbo.RADIO_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, REV_NBR, [STATUS] FROM dbo.TV_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, MAX_REV, [STATUS] = 0 FROM @media_summary WHERE @OrderStatusList <> '0'
						) o ON ms.ORDER_NBR = o.ORDER_NBR AND ms.LINE_NBR = o.LINE_NBR AND ms.MAX_REV = o.REV_NBR AND @OrderStatusList IS NOT NULL
		LEFT OUTER JOIN (
						SELECT SUM(vcd.AMOUNT) AS CLEARED_AMOUNT, vc.ORDER_NBR, vc.LINE_NBR
						FROM dbo.VCC_CARD_DTL vcd
							INNER JOIN dbo.VCC_CARD vc ON vcd.VCC_CARD_ID = vc.VCC_CARD_ID
						WHERE [ACTION] = 4
						GROUP BY vc.ORDER_NBR, vc.LINE_NBR
						) cleared ON cleared.ORDER_NBR = ms.ORDER_NBR AND cleared.LINE_NBR = ms.LINE_NBR
		LEFT OUTER JOIN (
						SELECT SUM(vcd.AMOUNT) AS PENDING_AMOUNT, vc.ORDER_NBR, vc.LINE_NBR
						FROM dbo.VCC_CARD_DTL vcd
							INNER JOIN dbo.VCC_CARD vc ON vcd.VCC_CARD_ID = vc.VCC_CARD_ID
						WHERE [ACTION] = 3
						GROUP BY vc.ORDER_NBR, vc.LINE_NBR
						) pending ON pending.ORDER_NBR = ms.ORDER_NBR AND pending.LINE_NBR = ms.LINE_NBR
		LEFT OUTER JOIN dbo.BRD_IMPORT_XREF BIX ON BIX.ORDER_NBR = ms.ORDER_NBR AND BIX.LINE_NBR = ms.LINE_NBR
		LEFT OUTER JOIN dbo.PRINT_IMPORT_XREF PIX ON PIX.ORDER_NBR = ms.ORDER_NBR AND PIX.LINE_NBR = ms.LINE_NBR
		LEFT OUTER JOIN (SELECT 
								DISTINCT
								MBW.MEDIA_BROADCAST_WORKSHEET_ID,
								MBW.NAME,
								MBWMDD.ORDER_NBR,
								MBWMDD.ORDER_LINE_NBR
							FROM 
								dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD 
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID
							WHERE
								MBWMDD.ORDER_NBR IS NOT NULL) AS MBW ON MBW.ORDER_NBR = ms.ORDER_NBR AND MBW.ORDER_LINE_NBR = ms.LINE_NBR
		LEFT OUTER JOIN (SELECT 
								DISTINCT
								MP.MEDIA_PLAN_ID,
								MP.[DESCRIPTION],
								MPD.MEDIA_PLAN_DTL_ID,
								MPD.[NAME],
								MPDLLD.ORDER_NBR,
								MPDLLD.ORDER_LINE_NBR
							FROM 
								dbo.MEDIA_PLAN_DTL_LEVEL_LINE_DATA MPDLLD 
								INNER JOIN dbo.MEDIA_PLAN_DTL MPD ON MPD.MEDIA_PLAN_DTL_ID = MPDLLD.MEDIA_PLAN_DTL_ID
								INNER JOIN dbo.MEDIA_PLAN MP ON MP.MEDIA_PLAN_ID = MPDLLD.MEDIA_PLAN_ID
							WHERE
								MPDLLD.ORDER_LINE_NBR IS NOT NULL) AS MP ON MP.ORDER_NBR = ms.ORDER_NBR AND MP.ORDER_LINE_NBR = ms.LINE_NBR
	WHERE
		(
			@OrderStatusList IS NULL
		OR
			(@OrderStatusList IS NOT NULL AND @OrderStatusList <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@OrderStatusList, ',')))
		OR
			(@OrderStatusList IS NOT NULL AND @OrderStatusList = '0' AND o.[STATUS] IS NULL)
		)
	AND (@AEDefaultEmployeeCodeList IS NULL OR (@AEDefaultEmployeeCodeList IS NOT NULL AND AE.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEDefaultEmployeeCodeList, ','))))
	OPTION (RECOMPILE)

if @debug = 1 
	select getdate() AS 'finish'
		
END
GO