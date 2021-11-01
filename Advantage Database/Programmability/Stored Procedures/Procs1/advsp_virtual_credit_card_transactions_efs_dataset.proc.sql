CREATE PROC [dbo].[advsp_virtual_credit_card_transactions_efs_dataset]
	@DateRangeType smallint, -- 1: VCC Transaction Date Range, 2: Order/Line date range
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@CardCTSList varchar(max),
	@IncludeTransactionDetail bit
AS

BEGIN

	SET NOCOUNT ON;

	SELECT
		[ClientCode] = h.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = h.DIV_CODE,
		[DivisionName] = div.DIV_NAME,
		[ProductCode] = h.PRD_CODE,
		[ProductName] = p.PRD_DESCRIPTION,
		[OrderNumber] = d.ORDER_NBR,
		[OrderDescription] = h.ORDER_DESC,
		[VendorCode] = h.VN_CODE,
		[VendorName] = v.VN_NAME,
		[LineNumber] = d.LINE_NBR,
		[JobNumber] = d.JOB_NUMBER,
		[ComponentNumber] = d.JOB_COMPONENT_NBR,
		[DateToBill] = d.DATE_TO_BILL,
		[JobMediaDateToBill] = jc.MEDIA_BILL_DATE,
		--[CreditCardNumberCVC] = vcc.CARD_NUMBER + ' / ' + vcc.CVC_CODE,
		[ExpirationDate] = vcc.EXPIRATION_DATE,
		vcc.[STATUS],
		[VendorCollected] = (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = d.ORDER_NBR AND LINE_NBR = d.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[TotalCostPayableToVendor] = COALESCE(d.EXT_NET_AMT, 0) + COALESCE(d.DISCOUNT_AMT, 0) + COALESCE(d.NETCHARGE, 0) + COALESCE(d.NON_RESALE_AMT, 0),
		[CardAmount] = vcc.CARD_AMOUNT,
		[TotalClearedInRange] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT SUM(AMOUNT) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastClearedDate] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT MAX(PROCESS_DATETIME) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastComment] = (SELECT TOP 1 NOTE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[LastCommentDate] = (SELECT TOP 1 CREATED_DATE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[CardCTS] = vcc.CARD_CTS,
		--[VCCLastFour] = RIGHT(vcc.CARD_NUMBER, 4),
		vcc.VCC_CARD_ID,
		[CardNumber] = vcc.CARD_NUMBER
	INTO #transactions
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1 AND COALESCE(d.LINE_CANCELLED, 0) = 0
		INNER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE
		COALESCE(h.[STATUS], 0) = 0 
	AND (
			( @DateRangeType = 1 AND vcc.CARD_CTS IN (SELECT * FROM dbo.udf_split_list(@CardCTSList, ',')) )
		OR
			( @DateRangeType = 2 AND ( d.[START_DATE] BETWEEN @StartDate AND @EndDate ) )
		)

	UNION
	
	SELECT
		[ClientCode] = h.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = h.DIV_CODE,
		[DivisionName] = div.DIV_NAME,
		[ProductCode] = h.PRD_CODE,
		[ProductName] = p.PRD_DESCRIPTION,
		[OrderNumber] = d.ORDER_NBR,
		[OrderDescription] = h.ORDER_DESC,
		[VendorCode] = h.VN_CODE,
		[VendorName] = v.VN_NAME,
		[LineNumber] = d.LINE_NBR,
		[JobNumber] = d.JOB_NUMBER,
		[ComponentNumber] = d.JOB_COMPONENT_NBR,
		[DateToBill] = d.DATE_TO_BILL,
		[JobMediaDateToBill] = jc.MEDIA_BILL_DATE,
		--[CreditCardNumberCVC] = vcc.CARD_NUMBER + ' / ' + vcc.CVC_CODE,
		[ExpirationDate] = vcc.EXPIRATION_DATE,
		vcc.[STATUS],
		[VendorCollected] = (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = d.ORDER_NBR AND LINE_NBR = d.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[TotalCostPayableToVendor] = COALESCE(d.EXT_NET_AMT, 0) + COALESCE(d.DISCOUNT_AMT, 0) + COALESCE(d.NETCHARGE, 0) + COALESCE(d.NON_RESALE_AMT, 0),
		[CardAmount] = vcc.CARD_AMOUNT,
		[TotalClearedInRange] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT SUM(AMOUNT) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastClearedDate] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT MAX(PROCESS_DATETIME) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastComment] = (SELECT TOP 1 NOTE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[LastCommentDate] = (SELECT TOP 1 CREATED_DATE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[CardCTS] = vcc.CARD_CTS,
		--[VCCLastFour] = RIGHT(vcc.CARD_NUMBER, 4),
		vcc.VCC_CARD_ID,
		[CardNumber] = vcc.CARD_NUMBER
	FROM dbo.MAGAZINE_HEADER h
		INNER JOIN dbo.MAGAZINE_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1 AND COALESCE(d.LINE_CANCELLED, 0) = 0
		INNER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE
		COALESCE(h.[STATUS], 0) = 0 
	AND (
			( @DateRangeType = 1 AND vcc.CARD_CTS IN (SELECT * FROM dbo.udf_split_list(@CardCTSList, ',')) )
		OR
			( @DateRangeType = 2 AND ( d.[START_DATE] BETWEEN @StartDate AND @EndDate ) )
		)

	UNION

	SELECT
		[ClientCode] = h.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = h.DIV_CODE,
		[DivisionName] = div.DIV_NAME,
		[ProductCode] = h.PRD_CODE,
		[ProductName] = p.PRD_DESCRIPTION,
		[OrderNumber] = d.ORDER_NBR,
		[OrderDescription] = h.ORDER_DESC,
		[VendorCode] = h.VN_CODE,
		[VendorName] = v.VN_NAME,
		[LineNumber] = d.LINE_NBR,
		[JobNumber] = d.JOB_NUMBER,
		[ComponentNumber] = d.JOB_COMPONENT_NBR,
		[DateToBill] = d.DATE_TO_BILL,
		[JobMediaDateToBill] = jc.MEDIA_BILL_DATE,
		--[CreditCardNumberCVC] = vcc.CARD_NUMBER + ' / ' + vcc.CVC_CODE,
		[ExpirationDate] = vcc.EXPIRATION_DATE,
		vcc.[STATUS],
		[VendorCollected] = (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = d.ORDER_NBR AND LINE_NBR = d.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[TotalCostPayableToVendor] = COALESCE(d.EXT_NET_AMT, 0) + COALESCE(d.DISCOUNT_AMT, 0) + COALESCE(d.NETCHARGE, 0) + COALESCE(d.NON_RESALE_AMT, 0),
		[CardAmount] = vcc.CARD_AMOUNT,
		[TotalClearedInRange] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT SUM(AMOUNT) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastClearedDate] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT MAX(PROCESS_DATETIME) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastComment] = (SELECT TOP 1 NOTE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[LastCommentDate] = (SELECT TOP 1 CREATED_DATE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[CardCTS] = vcc.CARD_CTS,
		--[VCCLastFour] = RIGHT(vcc.CARD_NUMBER, 4),
		vcc.VCC_CARD_ID,
		[CardNumber] = vcc.CARD_NUMBER
	FROM dbo.NEWSPAPER_HEADER h
		INNER JOIN dbo.NEWSPAPER_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1 AND COALESCE(d.LINE_CANCELLED, 0) = 0
		INNER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE
		COALESCE(h.[STATUS], 0) = 0 
	AND (
			( @DateRangeType = 1 AND vcc.CARD_CTS IN (SELECT * FROM dbo.udf_split_list(@CardCTSList, ',')) )
		OR
			( @DateRangeType = 2 AND ( d.[START_DATE] BETWEEN @StartDate AND @EndDate ) )
		)
		
	UNION

	SELECT
		[ClientCode] = h.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = h.DIV_CODE,
		[DivisionName] = div.DIV_NAME,
		[ProductCode] = h.PRD_CODE,
		[ProductName] = p.PRD_DESCRIPTION,
		[OrderNumber] = d.ORDER_NBR,
		[OrderDescription] = h.ORDER_DESC,
		[VendorCode] = h.VN_CODE,
		[VendorName] = v.VN_NAME,
		[LineNumber] = d.LINE_NBR,
		[JobNumber] = d.JOB_NUMBER,
		[ComponentNumber] = d.JOB_COMPONENT_NBR,
		[DateToBill] = d.DATE_TO_BILL,
		[JobMediaDateToBill] = jc.MEDIA_BILL_DATE,
		--[CreditCardNumberCVC] = vcc.CARD_NUMBER + ' / ' + vcc.CVC_CODE,
		[ExpirationDate] = vcc.EXPIRATION_DATE,
		vcc.[STATUS],
		[VendorCollected] = (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = d.ORDER_NBR AND LINE_NBR = d.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[TotalCostPayableToVendor] = COALESCE(d.EXT_NET_AMT, 0) + COALESCE(d.DISCOUNT_AMT, 0) + COALESCE(d.NETCHARGE, 0) + COALESCE(d.NON_RESALE_AMT, 0),
		[CardAmount] = vcc.CARD_AMOUNT,
		[TotalClearedInRange] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT SUM(AMOUNT) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastClearedDate] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT MAX(PROCESS_DATETIME) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastComment] = (SELECT TOP 1 NOTE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[LastCommentDate] = (SELECT TOP 1 CREATED_DATE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[CardCTS] = vcc.CARD_CTS,
		--[VCCLastFour] = RIGHT(vcc.CARD_NUMBER, 4),
		vcc.VCC_CARD_ID,
		[CardNumber] = vcc.CARD_NUMBER
	FROM dbo.OUTDOOR_HEADER h
		INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1 AND COALESCE(d.LINE_CANCELLED, 0) = 0
		INNER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE
		COALESCE(h.[STATUS], 0) = 0 
	AND (
			( @DateRangeType = 1 AND vcc.CARD_CTS IN (SELECT * FROM dbo.udf_split_list(@CardCTSList, ',')) )
		OR
			( @DateRangeType = 2 AND ( d.[POST_DATE] BETWEEN @StartDate AND @EndDate ) )
		)
		
	UNION

	SELECT
		[ClientCode] = h.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = h.DIV_CODE,
		[DivisionName] = div.DIV_NAME,
		[ProductCode] = h.PRD_CODE,
		[ProductName] = p.PRD_DESCRIPTION,
		[OrderNumber] = d.ORDER_NBR,
		[OrderDescription] = h.ORDER_DESC,
		[VendorCode] = h.VN_CODE,
		[VendorName] = v.VN_NAME,
		[LineNumber] = d.LINE_NBR,
		[JobNumber] = d.JOB_NUMBER,
		[ComponentNumber] = d.JOB_COMPONENT_NBR,
		[DateToBill] = d.DATE_TO_BILL,
		[JobMediaDateToBill] = jc.MEDIA_BILL_DATE,
		--[CreditCardNumberCVC] = vcc.CARD_NUMBER + ' / ' + vcc.CVC_CODE,
		[ExpirationDate] = vcc.EXPIRATION_DATE,
		vcc.[STATUS],
		[VendorCollected] = (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = d.ORDER_NBR AND LINE_NBR = d.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[TotalCostPayableToVendor] = COALESCE(d.EXT_NET_AMT, 0) + COALESCE(d.DISCOUNT_AMT, 0) + COALESCE(d.NETCHARGE, 0) + COALESCE(d.NON_RESALE_AMT, 0),
		[CardAmount] = vcc.CARD_AMOUNT,
		[TotalClearedInRange] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT SUM(AMOUNT) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastClearedDate] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT MAX(PROCESS_DATETIME) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastComment] = (SELECT TOP 1 NOTE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[LastCommentDate] = (SELECT TOP 1 CREATED_DATE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[CardCTS] = vcc.CARD_CTS,
		--[VCCLastFour] = RIGHT(vcc.CARD_NUMBER, 4),
		vcc.VCC_CARD_ID,
		[CardNumber] = vcc.CARD_NUMBER
	FROM dbo.RADIO_HDR h
		INNER JOIN dbo.RADIO_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1 AND COALESCE(d.LINE_CANCELLED, 0) = 0
		INNER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE
		COALESCE(h.[STATUS], 0) = 0 
	AND (
			( @DateRangeType = 1 AND vcc.CARD_CTS IN (SELECT * FROM dbo.udf_split_list(@CardCTSList, ',')) )
		OR
			( @DateRangeType = 2 AND ( d.[START_DATE] BETWEEN @StartDate AND @EndDate ) )
		)
		
	UNION

	SELECT
		[ClientCode] = h.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = h.DIV_CODE,
		[DivisionName] = div.DIV_NAME,
		[ProductCode] = h.PRD_CODE,
		[ProductName] = p.PRD_DESCRIPTION,
		[OrderNumber] = d.ORDER_NBR,
		[OrderDescription] = h.ORDER_DESC,
		[VendorCode] = h.VN_CODE,
		[VendorName] = v.VN_NAME,
		[LineNumber] = d.LINE_NBR,
		[JobNumber] = d.JOB_NUMBER,
		[ComponentNumber] = d.JOB_COMPONENT_NBR,
		[DateToBill] = d.DATE_TO_BILL,
		[JobMediaDateToBill] = jc.MEDIA_BILL_DATE,
		--[CreditCardNumberCVC] = vcc.CARD_NUMBER + ' / ' + vcc.CVC_CODE,
		[ExpirationDate] = vcc.EXPIRATION_DATE,
		vcc.[STATUS],
		[VendorCollected] = (SELECT TOP 1 NET_AMOUNT FROM dbo.COLLECTED_COST_INFO WHERE ORDER_NBR = d.ORDER_NBR AND LINE_NBR = d.LINE_NBR ORDER BY COLLECTED_COST_INFO_ID DESC),
		[TotalCostPayableToVendor] = COALESCE(d.EXT_NET_AMT, 0) + COALESCE(d.DISCOUNT_AMT, 0) + COALESCE(d.NETCHARGE, 0) + COALESCE(d.NON_RESALE_AMT, 0),
		[CardAmount] = vcc.CARD_AMOUNT,
		[TotalClearedInRange] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT SUM(AMOUNT) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastClearedDate] = CASE WHEN @DateRangeType = 1 THEN 0 ELSE (SELECT MAX(PROCESS_DATETIME) FROM dbo.VCC_CARD_DTL WHERE VCC_CARD_ID = vcc.VCC_CARD_ID AND [ACTION] = 4) END,
		[LastComment] = (SELECT TOP 1 NOTE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[LastCommentDate] = (SELECT TOP 1 CREATED_DATE FROM dbo.VCC_CARD_NOTE WHERE VCC_CARD_ID = vcc.VCC_CARD_ID ORDER BY CREATED_DATE DESC),
		[CardCTS] = vcc.CARD_CTS,
		--[VCCLastFour] = RIGHT(vcc.CARD_NUMBER, 4),
		vcc.VCC_CARD_ID,
		[CardNumber] = vcc.CARD_NUMBER
	FROM dbo.TV_HDR h
		INNER JOIN dbo.TV_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1 AND COALESCE(d.LINE_CANCELLED, 0) = 0
		INNER JOIN dbo.VCC_CARD vcc ON d.ORDER_NBR = vcc.ORDER_NBR AND d.LINE_NBR = vcc.LINE_NBR 
		INNER JOIN dbo.CLIENT c ON h.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION div ON h.CL_CODE = div.CL_CODE AND h.DIV_CODE = div.DIV_CODE 
		INNER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE
		COALESCE(h.[STATUS], 0) = 0 
	AND (
			( @DateRangeType = 1 AND vcc.CARD_CTS IN (SELECT * FROM dbo.udf_split_list(@CardCTSList, ',')) )
		OR
			( @DateRangeType = 2 AND ( d.[START_DATE] BETWEEN @StartDate AND @EndDate ) )
		)

	IF @IncludeTransactionDetail = 1 AND @DateRangeType = 2
		SELECT
			t.*,
			[CardStatus] = CASE t.[STATUS]
							WHEN 'A' THEN 'Active'
							WHEN 'C' THEN 'Cancelled'
							WHEN 'H' THEN 'Hold'
							WHEN 'I' THEN 'Inactive'
							WHEN 'S' THEN 'Stolen'
							END,
			[MerchantName] = d.MERCHANT_NAME,
            [Action] = CASE d.[ACTION] 
						--WHEN 1 THEN 'Credit Card Request'
						--WHEN 2 THEN 'Credit Card Update'
						--WHEN 3 THEN 'Pending Transaction'
						WHEN 4 THEN 'Cleared Transaction'
						WHEN 5 THEN 'Rejected Transaction'
						END,
            [Amount] = d.AMOUNT,
            [Reference] = d.REFERENCE_NUMBER,
            [ProcessedDateTime] = d.PROCESS_DATETIME
		FROM #transactions t
			INNER JOIN dbo.VCC_CARD_DTL d ON t.VCC_CARD_ID = d.VCC_CARD_ID AND d.[ACTION] IN (4,5)
	ELSE
		SELECT
			t.*,
			[CardStatus] = CASE t.[STATUS]
							WHEN 'A' THEN 'Active'
							WHEN 'C' THEN 'Cancelled'
							WHEN 'H' THEN 'Hold'
							WHEN 'I' THEN 'Inactive'
							WHEN 'S' THEN 'Stolen'
							END
		FROM #transactions t
END

GO