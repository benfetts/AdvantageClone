IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_media_current_status_coop_breakout]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_media_current_status_coop_breakout]
GO

CREATE PROCEDURE [dbo].[advsp_media_current_status_coop_breakout]  ( 	
	@order_status					varchar(1), --A = all, O = open
	@start_date						datetime,
	@start_month					int,
	@start_year						int,
	@end_date						datetime,
	@end_month						int,
	@end_year						int,
	@include_internet				bit,
	@include_magazine				bit,
	@include_newspaper				bit,
	@include_outofhome				bit,
	@include_radio					bit,
	@include_television				bit,
	@OfficeCodeList					varchar(max),
	@ClientCodeList					varchar(max),
	@ClientDivisionCodeList			varchar(max),
	@ClientDivisionProductCodeList	varchar(max),
	@user_id varchar(100)
)
AS
BEGIN

	SET NOCOUNT ON;

	 /* IS USED IN .Net AT THIS POINT - \AdvantageFramework.BLogic\Reporting\Methods.vb(12269): MediaCurrentStatusCoopBreakouts = ... */

	-- Identify the current Advantage user
	IF ISNULL(@user_id, '') > '' BEGIN
		SET @user_id = UPPER(@user_id)
	END
	ELSE BEGIN
		SET @user_id = ''
		--SELECT @user_id = UPPER(dbo.78())
	END
		
	CREATE TABLE #order_header(
		OfficeCode varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OfficeName varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientName varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DivisionCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DivisionName varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ProductCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ProductDescription varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CoopDivisionCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CoopDivisionName varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CoopProductCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CoopProductDescription varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderNumber int NOT NULL,
		OrderDescription varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderComment varchar(MAX),
		VendorCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		VendorName varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CampaignCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		CampaignID int NULL,
		CampaignName varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS,
		SalesClassCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		SalesClassDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		MarketCode varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
		MarketDescription varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderDate smalldatetime NULL,
		OrderFlightFrom smalldatetime NULL,
		OrderFlightTo smalldatetime NULL,
		Buyer varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ClientPO varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
		NetGrossFlag smallint NULL,
		BillCoopCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		BillCoopDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		BillCoopPercent decimal(7,3) NULL,
		AcctExecCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AcctExecName varchar(63) COLLATE SQL_Latin1_General_CP1_CS_AS
	)

	CREATE TABLE #order_detail(
		OrderType						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderNumber						int NOT NULL,
		LineNumber						smallint NOT NULL,
		LineDescription					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderPeriod						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderMonth						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
		OrderYear						int NULL,
		InsertionDate					smalldatetime NULL, 
		OrderEndDate					smalldatetime NULL, 
		CloseDate						smalldatetime NULL, 
		MaterialCloseDate				smalldatetime NULL, 
		ExtendedMaterialCloseDate		smalldatetime NULL, 
		ExtendedSpaceCloseDate			smalldatetime NULL, 
		JobNumber						int NULL,
		JobDescription					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JobComponentNumber				smallint NULL, 
		JobComponentDescription			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		NetTotalAmount					decimal(15,2) NULL,
		LineTotalAmount					decimal(15,2) NULL,
		BillAmount						decimal(15,2) NULL,
		AdditionalChargeAmount			decimal(15,2) NULL,
		CommissionAmount				decimal(15,2) NULL,
		RebateAmount					decimal(15,2) NULL,
		ResaleTaxAmount					decimal(15,2) NULL,
		AdNumber						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AdNumberDescription				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		LineCancelled					bit NOT NULL,
		DateToBill						smalldatetime NULL
	)

	INSERT INTO #order_detail EXECUTE dbo.[advsp_media_current_status_coop_breakout_detail] @order_status,
		@start_date, @start_month, @start_year, @end_date, @end_month, @end_year, @include_internet, @include_magazine, @include_newspaper, @include_outofhome, @include_radio, @include_television

	IF @include_internet = 1 
	BEGIN
		INSERT INTO #order_header
		SELECT 
			OfficeCode = h.OFFICE_CODE,
			OfficeName = o.OFFICE_NAME,
			ClientCode = h.CL_CODE,
			ClientName = c.CL_NAME,
			DivisionCode = h.DIV_CODE,
			DivisionName = d.DIV_NAME,
			ProductCode = h.PRD_CODE,
			ProductDescription = p.PRD_DESCRIPTION,
			CoopDivisionCode = bc.DIV_CODE,
			CoopDivisionName = d2.DIV_NAME,
			CoopProductCode = bc.PRD_CODE,
			CoopProductDescription = p2.PRD_DESCRIPTION,
			OrderNumber = h.ORDER_NBR,
			OrderDescription = h.ORDER_DESC,
			OrderComment = h.ORDER_COMMENT,
			VendorCode = h.VN_CODE,
			VendorName = v.VN_NAME,
			CampaignCode = h.CMP_CODE,
			CampaignID = h.CMP_IDENTIFIER,
			CampaignName = cmp.CMP_NAME,
			SalesClassCode = h.MEDIA_TYPE,
			SalesClassDescription = sc.SC_DESCRIPTION,
			MarketCode = h.MARKET_CODE,
			MarketDescription = m.MARKET_DESC,
			OrderDate = h.ORDER_DATE,
			OrderFlightFrom = h.[START_DATE],
			OrderFlightTo = h.END_DATE,
			Buyer = h.BUYER,
			ClientPO = h.CLIENT_PO,
			NetGrossFlag = h.NET_GROSS,
			BillCoopCode = h.BILL_COOP_CODE,
			BillCoopDescription = bc.BILL_COOP_DESC,
			BillCoopPercent = bc.COOP_PCT,
			AcctExecCode = ae.EMP_CODE,
			AcctExecName = ISNULL(e.EMP_FNAME + ' ', '') + ISNULL(e.EMP_MI + '. ', ' ') + ISNULL(e.EMP_LNAME, '')
		FROM dbo.INTERNET_HEADER h
			LEFT OUTER JOIN dbo.OFFICE o ON h.OFFICE_CODE = o.OFFICE_CODE 
			LEFT OUTER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
			LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
			LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
			LEFT OUTER JOIN dbo.BILLING_COOP bc ON h.BILL_COOP_CODE = bc.BILL_COOP_CODE
			LEFT OUTER JOIN dbo.DIVISION d2 ON bc.CL_CODE = d2.CL_CODE AND bc.DIV_CODE = d2.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p2 ON bc.CL_CODE = p2.CL_CODE AND bc.DIV_CODE = p2.DIV_CODE AND bc.PRD_CODE = p2.PRD_CODE
			LEFT OUTER JOIN dbo.ACCOUNT_EXECUTIVE ae ON ae.CL_CODE = h.CL_CODE AND ae.DIV_CODE = h.DIV_CODE AND ae.PRD_CODE = h.PRD_CODE
														AND ae.DEFAULT_AE = 1 AND COALESCE(ae.INACTIVE_FLAG, 0) = 0 
			LEFT OUTER JOIN dbo.EMPLOYEE e ON ae.EMP_CODE = e.EMP_CODE
	END

	IF @include_magazine = 1 
	BEGIN
		INSERT INTO #order_header
		SELECT 
			OfficeCode = h.OFFICE_CODE,
			OfficeName = o.OFFICE_NAME,
			ClientCode = h.CL_CODE,
			ClientName = c.CL_NAME,
			DivisionCode = h.DIV_CODE,
			DivisionName = d.DIV_NAME,
			ProductCode = h.PRD_CODE,
			ProductDescription = p.PRD_DESCRIPTION,
			CoopDivisionCode = bc.DIV_CODE,
			CoopDivisionName = d2.DIV_NAME,
			CoopProductCode = bc.PRD_CODE,
			CoopProductDescription = p2.PRD_DESCRIPTION,
			OrderNumber = h.ORDER_NBR,
			OrderDescription = h.ORDER_DESC,
			OrderComment = h.ORDER_COMMENT,
			VendorCode = h.VN_CODE,
			VendorName = v.VN_NAME,
			CampaignCode = h.CMP_CODE,
			CampaignID = h.CMP_IDENTIFIER,
			CampaignName = cmp.CMP_NAME,
			SalesClassCode = h.MEDIA_TYPE,
			SalesClassDescription = sc.SC_DESCRIPTION,
			MarketCode = h.MARKET_CODE,
			MarketDescription = m.MARKET_DESC,
			OrderDate = h.ORDER_DATE,
			OrderFlightFrom = h.[START_DATE],
			OrderFlightTo = h.END_DATE,
			Buyer = h.BUYER,
			ClientPO = h.CLIENT_PO,
			NetGrossFlag = h.NET_GROSS,
			BillCoopCode = h.BILL_COOP_CODE,
			BillCoopDescription = bc.BILL_COOP_DESC,
			BillCoopPercent = bc.COOP_PCT,
			AcctExecCode = ae.EMP_CODE,
			AcctExecName = ISNULL(e.EMP_FNAME + ' ', '') + ISNULL(e.EMP_MI + '. ', ' ') + ISNULL(e.EMP_LNAME, '')
		FROM dbo.MAGAZINE_HEADER h
			LEFT OUTER JOIN dbo.OFFICE o ON h.OFFICE_CODE = o.OFFICE_CODE 
			LEFT OUTER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
			LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
			LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
			LEFT OUTER JOIN dbo.BILLING_COOP bc ON h.BILL_COOP_CODE = bc.BILL_COOP_CODE
			LEFT OUTER JOIN dbo.DIVISION d2 ON bc.CL_CODE = d2.CL_CODE AND bc.DIV_CODE = d2.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p2 ON bc.CL_CODE = p2.CL_CODE AND bc.DIV_CODE = p2.DIV_CODE AND bc.PRD_CODE = p2.PRD_CODE
			LEFT OUTER JOIN dbo.ACCOUNT_EXECUTIVE ae ON ae.CL_CODE = h.CL_CODE AND ae.DIV_CODE = h.DIV_CODE AND ae.PRD_CODE = h.PRD_CODE
														AND ae.DEFAULT_AE = 1 AND COALESCE(ae.INACTIVE_FLAG, 0) = 0 
			LEFT OUTER JOIN dbo.EMPLOYEE e ON ae.EMP_CODE = e.EMP_CODE
	END

	IF @include_newspaper = 1 
	BEGIN
		INSERT INTO #order_header
		SELECT 
			OfficeCode = h.OFFICE_CODE,
			OfficeName = o.OFFICE_NAME,
			ClientCode = h.CL_CODE,
			ClientName = c.CL_NAME,
			DivisionCode = h.DIV_CODE,
			DivisionName = d.DIV_NAME,
			ProductCode = h.PRD_CODE,
			ProductDescription = p.PRD_DESCRIPTION,
			CoopDivisionCode = bc.DIV_CODE,
			CoopDivisionName = d2.DIV_NAME,
			CoopProductCode = bc.PRD_CODE,
			CoopProductDescription = p2.PRD_DESCRIPTION,
			OrderNumber = h.ORDER_NBR,
			OrderDescription = h.ORDER_DESC,
			OrderComment = h.ORDER_COMMENT,
			VendorCode = h.VN_CODE,
			VendorName = v.VN_NAME,
			CampaignCode = h.CMP_CODE,
			CampaignID = h.CMP_IDENTIFIER,
			CampaignName = cmp.CMP_NAME,
			SalesClassCode = h.MEDIA_TYPE,
			SalesClassDescription = sc.SC_DESCRIPTION,
			MarketCode = h.MARKET_CODE,
			MarketDescription = m.MARKET_DESC,
			OrderDate = h.ORDER_DATE,
			OrderFlightFrom = h.[START_DATE],
			OrderFlightTo = h.END_DATE,
			Buyer = h.BUYER,
			ClientPO = h.CLIENT_PO,
			NetGrossFlag = h.NET_GROSS,
			BillCoopCode = h.BILL_COOP_CODE,
			BillCoopDescription = bc.BILL_COOP_DESC,
			BillCoopPercent = bc.COOP_PCT,
			AcctExecCode = ae.EMP_CODE,
			AcctExecName = ISNULL(e.EMP_FNAME + ' ', '') + ISNULL(e.EMP_MI + '. ', ' ') + ISNULL(e.EMP_LNAME, '')
		FROM dbo.NEWSPAPER_HEADER h
			LEFT OUTER JOIN dbo.OFFICE o ON h.OFFICE_CODE = o.OFFICE_CODE 
			LEFT OUTER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
			LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
			LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
			LEFT OUTER JOIN dbo.BILLING_COOP bc ON h.BILL_COOP_CODE = bc.BILL_COOP_CODE
			LEFT OUTER JOIN dbo.DIVISION d2 ON bc.CL_CODE = d2.CL_CODE AND bc.DIV_CODE = d2.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p2 ON bc.CL_CODE = p2.CL_CODE AND bc.DIV_CODE = p2.DIV_CODE AND bc.PRD_CODE = p2.PRD_CODE
			LEFT OUTER JOIN dbo.ACCOUNT_EXECUTIVE ae ON ae.CL_CODE = h.CL_CODE AND ae.DIV_CODE = h.DIV_CODE AND ae.PRD_CODE = h.PRD_CODE
														AND ae.DEFAULT_AE = 1 AND COALESCE(ae.INACTIVE_FLAG, 0) = 0 
			LEFT OUTER JOIN dbo.EMPLOYEE e ON ae.EMP_CODE = e.EMP_CODE
	END

	IF @include_outofhome = 1 
	BEGIN
		INSERT INTO #order_header
		SELECT 
			OfficeCode = h.OFFICE_CODE,
			OfficeName = o.OFFICE_NAME,
			ClientCode = h.CL_CODE,
			ClientName = c.CL_NAME,
			DivisionCode = h.DIV_CODE,
			DivisionName = d.DIV_NAME,
			ProductCode = h.PRD_CODE,
			ProductDescription = p.PRD_DESCRIPTION,
			CoopDivisionCode = bc.DIV_CODE,
			CoopDivisionName = d2.DIV_NAME,
			CoopProductCode = bc.PRD_CODE,
			CoopProductDescription = p2.PRD_DESCRIPTION,
			OrderNumber = h.ORDER_NBR,
			OrderDescription = h.ORDER_DESC,
			OrderComment = h.ORDER_COMMENT,
			VendorCode = h.VN_CODE,
			VendorName = v.VN_NAME,
			CampaignCode = h.CMP_CODE,
			CampaignID = h.CMP_IDENTIFIER,
			CampaignName = cmp.CMP_NAME,
			SalesClassCode = h.MEDIA_TYPE,
			SalesClassDescription = sc.SC_DESCRIPTION,
			MarketCode = h.MARKET_CODE,
			MarketDescription = m.MARKET_DESC,
			OrderDate = h.ORDER_DATE,
			OrderFlightFrom = h.[START_DATE],
			OrderFlightTo = h.END_DATE,
			Buyer = h.BUYER,
			ClientPO = h.CLIENT_PO,
			NetGrossFlag = h.NET_GROSS,
			BillCoopCode = h.BILL_COOP_CODE,
			BillCoopDescription = bc.BILL_COOP_DESC,
			BillCoopPercent = bc.COOP_PCT,
			AcctExecCode = ae.EMP_CODE,
			AcctExecName = ISNULL(e.EMP_FNAME + ' ', '') + ISNULL(e.EMP_MI + '. ', ' ') + ISNULL(e.EMP_LNAME, '')
		FROM dbo.OUTDOOR_HEADER h
			LEFT OUTER JOIN dbo.OFFICE o ON h.OFFICE_CODE = o.OFFICE_CODE 
			LEFT OUTER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
			LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
			LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
			LEFT OUTER JOIN dbo.BILLING_COOP bc ON h.BILL_COOP_CODE = bc.BILL_COOP_CODE
			LEFT OUTER JOIN dbo.DIVISION d2 ON bc.CL_CODE = d2.CL_CODE AND bc.DIV_CODE = d2.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p2 ON bc.CL_CODE = p2.CL_CODE AND bc.DIV_CODE = p2.DIV_CODE AND bc.PRD_CODE = p2.PRD_CODE
			LEFT OUTER JOIN dbo.ACCOUNT_EXECUTIVE ae ON ae.CL_CODE = h.CL_CODE AND ae.DIV_CODE = h.DIV_CODE AND ae.PRD_CODE = h.PRD_CODE
														AND ae.DEFAULT_AE = 1 AND COALESCE(ae.INACTIVE_FLAG, 0) = 0 
			LEFT OUTER JOIN dbo.EMPLOYEE e ON ae.EMP_CODE = e.EMP_CODE
	END

	IF @include_radio = 1 
	BEGIN
		INSERT INTO #order_header
		SELECT 
			OfficeCode = h.OFFICE_CODE,
			OfficeName = o.OFFICE_NAME,
			ClientCode = h.CL_CODE,
			ClientName = c.CL_NAME,
			DivisionCode = h.DIV_CODE,
			DivisionName = d.DIV_NAME,
			ProductCode = h.PRD_CODE,
			ProductDescription = p.PRD_DESCRIPTION,
			CoopDivisionCode = bc.DIV_CODE,
			CoopDivisionName = d2.DIV_NAME,
			CoopProductCode = bc.PRD_CODE,
			CoopProductDescription = p2.PRD_DESCRIPTION,
			OrderNumber = h.ORDER_NBR,
			OrderDescription = h.ORDER_DESC,
			OrderComment = h.ORDER_COMMENT,
			VendorCode = h.VN_CODE,
			VendorName = v.VN_NAME,
			CampaignCode = h.CMP_CODE,
			CampaignID = h.CMP_IDENTIFIER,
			CampaignName = cmp.CMP_NAME,
			SalesClassCode = h.MEDIA_TYPE,
			SalesClassDescription = sc.SC_DESCRIPTION,
			MarketCode = h.MARKET_CODE,
			MarketDescription = m.MARKET_DESC,
			OrderDate = h.ORDER_DATE,
			OrderFlightFrom = h.[START_DATE],
			OrderFlightTo = h.END_DATE,
			Buyer = h.BUYER,
			ClientPO = h.CLIENT_PO,
			NetGrossFlag = h.NET_GROSS,
			BillCoopCode = h.BILL_COOP_CODE,
			BillCoopDescription = bc.BILL_COOP_DESC,
			BillCoopPercent = bc.COOP_PCT,
			AcctExecCode = ae.EMP_CODE,
			AcctExecName = ISNULL(e.EMP_FNAME + ' ', '') + ISNULL(e.EMP_MI + '. ', ' ') + ISNULL(e.EMP_LNAME, '')
		FROM dbo.RADIO_HDR h
			LEFT OUTER JOIN dbo.OFFICE o ON h.OFFICE_CODE = o.OFFICE_CODE 
			LEFT OUTER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
			LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
			LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
			LEFT OUTER JOIN dbo.BILLING_COOP bc ON h.BILL_COOP_CODE = bc.BILL_COOP_CODE
			LEFT OUTER JOIN dbo.DIVISION d2 ON bc.CL_CODE = d2.CL_CODE AND bc.DIV_CODE = d2.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p2 ON bc.CL_CODE = p2.CL_CODE AND bc.DIV_CODE = p2.DIV_CODE AND bc.PRD_CODE = p2.PRD_CODE
			LEFT OUTER JOIN dbo.ACCOUNT_EXECUTIVE ae ON ae.CL_CODE = h.CL_CODE AND ae.DIV_CODE = h.DIV_CODE AND ae.PRD_CODE = h.PRD_CODE
														AND ae.DEFAULT_AE = 1 AND COALESCE(ae.INACTIVE_FLAG, 0) = 0 
			LEFT OUTER JOIN dbo.EMPLOYEE e ON ae.EMP_CODE = e.EMP_CODE
	END

	IF @include_television = 1 
	BEGIN
		INSERT INTO #order_header
		SELECT 
			OfficeCode = h.OFFICE_CODE,
			OfficeName = o.OFFICE_NAME,
			ClientCode = h.CL_CODE,
			ClientName = c.CL_NAME,
			DivisionCode = h.DIV_CODE,
			DivisionName = d.DIV_NAME,
			ProductCode = h.PRD_CODE,
			ProductDescription = p.PRD_DESCRIPTION,
			CoopDivisionCode = bc.DIV_CODE,
			CoopDivisionName = d2.DIV_NAME,
			CoopProductCode = bc.PRD_CODE,
			CoopProductDescription = p2.PRD_DESCRIPTION,
			OrderNumber = h.ORDER_NBR,
			OrderDescription = h.ORDER_DESC,
			OrderComment = h.ORDER_COMMENT,
			VendorCode = h.VN_CODE,
			VendorName = v.VN_NAME,
			CampaignCode = h.CMP_CODE,
			CampaignID = h.CMP_IDENTIFIER,
			CampaignName = cmp.CMP_NAME,
			SalesClassCode = h.MEDIA_TYPE,
			SalesClassDescription = sc.SC_DESCRIPTION,
			MarketCode = h.MARKET_CODE,
			MarketDescription = m.MARKET_DESC,
			OrderDate = h.ORDER_DATE,
			OrderFlightFrom = h.[START_DATE],
			OrderFlightTo = h.END_DATE,
			Buyer = h.BUYER,
			ClientPO = h.CLIENT_PO,
			NetGrossFlag = h.NET_GROSS,
			BillCoopCode = h.BILL_COOP_CODE,
			BillCoopDescription = bc.BILL_COOP_DESC,
			BillCoopPercent = bc.COOP_PCT,
			AcctExecCode = ae.EMP_CODE,
			AcctExecName = ISNULL(e.EMP_FNAME + ' ', '') + ISNULL(e.EMP_MI + '. ', ' ') + ISNULL(e.EMP_LNAME, '')
		FROM dbo.TV_HDR h
			LEFT OUTER JOIN dbo.OFFICE o ON h.OFFICE_CODE = o.OFFICE_CODE 
			LEFT OUTER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
			LEFT OUTER JOIN dbo.DIVISION d ON h.CL_CODE = d.CL_CODE AND h.DIV_CODE = d.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
			LEFT OUTER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
			LEFT OUTER JOIN dbo.CAMPAIGN cmp ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
			LEFT OUTER JOIN dbo.SALES_CLASS sc ON h.MEDIA_TYPE = sc.SC_CODE
			LEFT OUTER JOIN dbo.MARKET m ON h.MARKET_CODE = m.MARKET_CODE
			LEFT OUTER JOIN dbo.BILLING_COOP bc ON h.BILL_COOP_CODE = bc.BILL_COOP_CODE
			LEFT OUTER JOIN dbo.DIVISION d2 ON bc.CL_CODE = d2.CL_CODE AND bc.DIV_CODE = d2.DIV_CODE
			LEFT OUTER JOIN dbo.PRODUCT p2 ON bc.CL_CODE = p2.CL_CODE AND bc.DIV_CODE = p2.DIV_CODE AND bc.PRD_CODE = p2.PRD_CODE
			LEFT OUTER JOIN dbo.ACCOUNT_EXECUTIVE ae ON ae.CL_CODE = h.CL_CODE AND ae.DIV_CODE = h.DIV_CODE AND ae.PRD_CODE = h.PRD_CODE
														AND ae.DEFAULT_AE = 1 AND COALESCE(ae.INACTIVE_FLAG, 0) = 0 
			LEFT OUTER JOIN dbo.EMPLOYEE e ON ae.EMP_CODE = e.EMP_CODE
	END

	SELECT
		ID = NEWID(),
        UserCode = @user_id,
        OrderType = d.OrderType,
        h.OfficeCode,
        h.OfficeName,
        h.ClientCode,
        h.ClientName,
        h.DivisionCode,
        h.DivisionName,
        h.ProductCode,
        h.ProductDescription,
		h.CoopDivisionCode,
		h.CoopDivisionName,
		h.CoopProductCode,
		h.CoopProductDescription,
        h.OrderNumber,
        h.OrderDescription,
        h.OrderComment,
        h.VendorCode,
        h.VendorName,
        h.CampaignCode,
        h.CampaignID,
        h.CampaignName,
        h.SalesClassCode,
        h.SalesClassDescription,
        h.MarketCode,
        h.MarketDescription,
        h.OrderDate,
        h.OrderFlightFrom,
        h.OrderFlightTo,
        h.Buyer,
        h.ClientPO,
        h.NetGrossFlag,
        h.BillCoopCode,
        h.BillCoopDescription,
		h.BillCoopPercent,
        h.AcctExecCode,
        h.AcctExecName,

		d.LineNumber,
		d.LineDescription,
		d.OrderPeriod,
		d.OrderMonth,
		d.OrderYear,
		d.InsertionDate,
		d.OrderEndDate,
		d.CloseDate,
		d.MaterialCloseDate,
		d.ExtendedMaterialCloseDate,
		d.ExtendedSpaceCloseDate,
		d.JobNumber,
		d.JobDescription,
		d.JobComponentNumber,
		d.JobComponentDescription,

		NetTotalAmount = CASE WHEN h.BillCoopCode IS NOT NULL THEN d.NetTotalAmount * h.BillCoopPercent / 100 ELSE d.NetTotalAmount END,
		LineTotalAmount = CASE WHEN h.BillCoopCode IS NOT NULL THEN d.LineTotalAmount * h.BillCoopPercent / 100 ELSE d.LineTotalAmount END,
		BillAmount = CASE WHEN h.BillCoopCode IS NOT NULL THEN d.BillAmount * h.BillCoopPercent / 100 ELSE d.BillAmount END,
		AdditionalChargeAmount = CASE WHEN h.BillCoopCode IS NOT NULL THEN d.AdditionalChargeAmount * h.BillCoopPercent / 100 ELSE d.AdditionalChargeAmount END,
		CommissionAmount = CASE WHEN h.BillCoopCode IS NOT NULL THEN d.CommissionAmount * h.BillCoopPercent / 100 ELSE d.CommissionAmount END,
		RebateAmount = CASE WHEN h.BillCoopCode IS NOT NULL THEN d.RebateAmount * h.BillCoopPercent / 100 ELSE d.RebateAmount END,
		ResaleTaxAmount = CASE WHEN h.BillCoopCode IS NOT NULL THEN d.ResaleTaxAmount * h.BillCoopPercent / 100 ELSE d.ResaleTaxAmount END,

		d.AdNumber,
		d.AdNumberDescription,
		d.LineCancelled,
		d.DateToBill
	FROM #order_header h
		INNER JOIN #order_detail d ON h.OrderNumber = d.OrderNumber
	WHERE
			(@OfficeCodeList IS NULL OR (@OfficeCodeList IS NOT NULL AND OfficeCode IN (SELECT * FROM dbo.udf_split_list(@OfficeCodeList, ','))))
	AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND ClientCode IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode + '|' + ProductCode IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))

END
GO

GRANT EXECUTE ON [advsp_media_current_status_coop_breakout] TO PUBLIC AS dbo
GO