CREATE PROCEDURE [dbo].[advsp_media_manager_load_approve_invoice]
	@OrderNumberLineNumberList varchar(max),
	@debug as bit = 0
AS

--this is order/lines WITH AP
CREATE TABLE #INVOICE (
	ORDER_NBR int NOT NULL,
	LINE_NBR smallint NOT NULL
)

--this is order/lines WITHOUT AP
CREATE TABLE #INVOICE2 (
	ORDER_NBR int NOT NULL,
	LINE_NBR smallint NOT NULL
)

DECLARE @view TABLE (
	[DetailID] int NOT NULL,
	[MediaType] varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	[VendorCode] varchar(6) NOT NULL,
	[VendorName] varchar(40) NULL,
	[Vendor] varchar(50) NULL,
	[OrderNumber] int NOT NULL,
	[OrderLineNumber] smallint NULL,
	[RunDate] smalldatetime NOT NULL,
	[WeekOf] smalldatetime NULL,
	[WeekOfSpots] smallint NULL,
	[RunTime] time NOT NULL,
	[DayOfWeek] varchar(2) NULL,
	[DayOfWeekNumber] smallint NULL,
	[Length] smallint NOT NULL,
	[AdNumber] varchar(30) NULL,
	[NetworkID] varchar(10) NULL,
	[GrossRate] decimal NOT NULL,
	[Approved] smallint NULL,
	[Comment] varchar(254) NULL,
	[VariantCodes] varchar(254) NULL,
	[IsLineNumberVerified] bit NULL,
	[IsRateVerified] bit NULL,
	[IsNetworkVerified] bit NULL,
	[IsScheduleVerified] bit NULL,
	[IsDayOfWeekVerified] bit NULL,
	[IsTimeVerified] bit NULL,
	[IsTimeSeparationVerified] bit NULL,
	[IsAdNumberVerified] bit NULL,
	[IsLengthVerified] bit NULL,
	[IsSpotVerified] bit NULL,
	[IsBookendVerified] varchar(20) NULL,
	[OrderMonthNumber] smallint NULL,
	[OrderYearNumber] smallint NULL,
	[LinkLineNumber] int NULL,
	[ProgramName] varchar(40) NULL
)

CREATE TABLE #AP_NET_AMOUNT (
	ORDER_NBR int NOT NULL,
	LINE_NBR smallint NOT NULL,
	AP_NET_AMOUNT decimal(16,2) NULL,
	AP_GROSS_AMOUNT decimal(16,2) NULL,
	InvoiceNumber varchar(20) NOT NULL,
	InvoiceDate smalldatetime NOT NULL,
	AccountPayableID int NOT NULL,
	VendorCode varchar(6) NOT NULL,
	VendorName varchar(40) NULL,
	OrderGrossRate decimal(16,4) null,
	OrderNetRate decimal(16,4) null,
	InvoiceDetailMatching varchar(20) null,
	InvoiceQtySpots int null,
	MediaType varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientCode varchar(6) NULL, 
	DivisionCode varchar(6) NULL, 
	ProductCode varchar(6) NULL,
	LineCancelled bit NOT NULL,
	OrderQtySpots int NULL,
	GrossOrderAmount decimal(16,2) NULL,
	NetOrderAmount decimal(16,2) NULL,
	MonthYear	varchar(8) NULL,
	MonthNumber	smallint NULL,
	YearNumber	smallint NULL,
	DoesNotHaveAP bit NOT NULL DEFAULT(0)
)

INSERT #INVOICE (ORDER_NBR, LINE_NBR)
SELECT
	ORDER_NBR = SUBSTRING(items,1,CHARINDEX('|', items, 1)-1),
	LINE_NBR = SUBSTRING(items,CHARINDEX('|', items, 1)+1,20)
FROM dbo.udf_split_list(@OrderNumberLineNumberList, ',')

DECLARE @OrderNumbers varchar(MAX)

SELECT @OrderNumbers = COALESCE(@OrderNumbers + ', ','') + CAST(ORDER_NBR as varchar)
FROM (SELECT DISTINCT ORDER_NBR FROM #INVOICE) orders

INSERT INTO @view
SELECT * FROM dbo.advtf_broadcast_order_dtl_verification (@OrderNumberLineNumberList, 0, NULL, @OrderNumbers, 1)

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber)
SELECT 
	AP_NET_AMOUNT = COALESCE (SUM(AP.NET_AMT), 0), -- + COALESCE(SUM(AP.NETCHARGES), 0) + COALESCE(SUM(AP.VENDOR_TAX), 0) + COALESCE(SUM(AP.DISCOUNT_AMT), 0),
	I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID, 
	[OrderGrossRate] = OD.GROSS_RATE, 
	[OrderNetRate] = OD.NET_RATE,
	[InvoiceQtySpots] = SUM(IMPRESSIONS),
	SUM(AP_GROSS_AMT),
	MediaType = 'Internet', OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, COALESCE(OD.LINE_CANCELLED, 0),
	OD.GUARANTEED_IMPRESS,
	OD.EXT_GROSS_AMT,
	OD.EXT_NET_AMT,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), OD.[START_DATE], 0)) + ' ' + CAST(YEAR(OD.[START_DATE]) as varchar(4)) ELSE NULL END,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN datepart(mm, OD.[START_DATE]) ELSE NULL END,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN datepart(yyyy, OD.[START_DATE]) ELSE NULL END
FROM #INVOICE I 
	INNER JOIN (SELECT 
				 	AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.MODIFY_DELETE, AP.AP_ID,
					AP.NET_AMT, AP.NETCHARGES, AP.VENDOR_TAX, AP.DISCOUNT_AMT, AP.IMPRESSIONS,
					AP_GROSS_AMT = CASE WHEN NET_GROSS = 1 THEN 
                                        CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							            ELSE
								            CAST(NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							            END
                                   ELSE CAST(NET_AMT + (NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
                                   END
				FROM dbo.AP_INTERNET AP) AP	ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	INNER JOIN dbo.AP_HEADER H ON AP.AP_ID = H.AP_ID AND H.MODIFY_FLAG IS NULL
	INNER JOIN dbo.VENDOR VN ON H.VN_FRL_EMP_CODE = VN.VN_CODE
	INNER JOIN dbo.INTERNET_HEADER OH ON I.ORDER_NBR = OH.ORDER_NBR 
	LEFT OUTER JOIN dbo.INTERNET_DETAIL OD ON AP.ORDER_NBR = OD.ORDER_NBR AND AP.ORDER_LINE_NBR = OD.LINE_NBR AND OD.ACTIVE_REV = 1
GROUP BY I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID,  OD.GROSS_RATE, OD.NET_RATE,
	OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, OD.LINE_CANCELLED, OD.GUARANTEED_IMPRESS, OD.EXT_GROSS_AMT, OD.EXT_NET_AMT, OD.[START_DATE]

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber)
SELECT 
	AP_NET_AMOUNT = COALESCE (SUM(AP.NET_PLUS), 0), -- + COALESCE(SUM(AP.NETCHARGES), 0) + COALESCE(SUM(AP.VENDOR_TAX), 0) + COALESCE(SUM(AP.DISCOUNT_LN), 0),
	I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID, 
	[OrderGrossRate] = OD.GROSS_RATE, 
	[OrderNetRate] = OD.NET_RATE,
	[InvoiceQtySpots] = NULL,
	SUM(AP_GROSS_AMT),
	MediaType = 'Magazine', OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, COALESCE(OD.LINE_CANCELLED, 0),
	0,
	OD.EXT_GROSS_AMT,
	OD.EXT_NET_AMT,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), OD.[START_DATE], 0)) + ' ' + CAST(YEAR(OD.[START_DATE]) as varchar(4)) ELSE NULL END,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN datepart(mm, OD.[START_DATE]) ELSE NULL END,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN datepart(yyyy, OD.[START_DATE]) ELSE NULL END
FROM #INVOICE I
	INNER JOIN (SELECT 
				 	AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.MODIFY_DELETE, AP.AP_ID,
					AP.NET_PLUS, AP.NETCHARGES, AP.VENDOR_TAX, AP.DISCOUNT_LN, 
					AP_GROSS_AMT = CASE WHEN NET_GROSS = 1 THEN
                                        CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							            ELSE
								            CAST(NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							            END
                                   ELSE CAST(NET_PLUS + (NET_PLUS * AP.MARKUP_PCT / 100) as decimal(16,2))
                                   END
				FROM dbo.AP_MAGAZINE AP) AP	ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	INNER JOIN dbo.AP_HEADER H ON AP.AP_ID = H.AP_ID AND H.MODIFY_FLAG IS NULL
	INNER JOIN dbo.VENDOR VN ON H.VN_FRL_EMP_CODE = VN.VN_CODE
	INNER JOIN dbo.MAGAZINE_HEADER OH ON I.ORDER_NBR = OH.ORDER_NBR 
	LEFT OUTER JOIN dbo.MAGAZINE_DETAIL OD ON AP.ORDER_NBR = OD.ORDER_NBR AND AP.ORDER_LINE_NBR = OD.LINE_NBR AND OD.ACTIVE_REV = 1
GROUP BY I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID,  OD.GROSS_RATE, OD.NET_RATE,
	OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, OD.LINE_CANCELLED, OD.EXT_GROSS_AMT, OD.EXT_NET_AMT, OD.[START_DATE]

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber)
SELECT 
	AP_NET_AMOUNT = COALESCE (SUM(AP.NET_AMT), 0), -- + COALESCE(SUM(AP.NETCHARGES), 0) + COALESCE(SUM(AP.VENDOR_TAX), 0) + COALESCE(SUM(AP.DISCOUNT_LN), 0),
	I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID, 
	[OrderGrossRate] = OD.GROSS_RATE, 
	[OrderNetRate] = OD.NET_RATE,
	[InvoiceQtySpots] = NULL,
	SUM(AP_GROSS_AMT),
	MediaType = 'Newspaper', OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, COALESCE(OD.LINE_CANCELLED, 0),
	0,
	OD.EXT_GROSS_AMT,
	OD.EXT_NET_AMT,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN UPPER(convert(char(3), OD.[START_DATE], 0)) + ' ' + CAST(YEAR(OD.[START_DATE]) as varchar(4)) ELSE NULL END,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN datepart(mm, OD.[START_DATE]) ELSE NULL END,
	CASE WHEN OD.[START_DATE] IS NOT NULL THEN datepart(yyyy, OD.[START_DATE]) ELSE NULL END
FROM #INVOICE I 
	INNER JOIN (SELECT 
				 	AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.MODIFY_DELETE, AP.AP_ID,
					AP.NET_AMT, AP.NETCHARGES, AP.VENDOR_TAX, AP.DISCOUNT_LN, 
					AP_GROSS_AMT = CASE WHEN NET_GROSS = 1 THEN 
                                        CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							            ELSE
								            CAST(NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							            END
                                   ELSE CAST(NET_AMT + (NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
                                   END
				FROM dbo.AP_NEWSPAPER AP) AP ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	INNER JOIN dbo.AP_HEADER H ON AP.AP_ID = H.AP_ID AND H.MODIFY_FLAG IS NULL
	INNER JOIN dbo.VENDOR VN ON H.VN_FRL_EMP_CODE = VN.VN_CODE
	INNER JOIN dbo.NEWSPAPER_HEADER OH ON I.ORDER_NBR = OH.ORDER_NBR 
	LEFT OUTER JOIN dbo.NEWSPAPER_DETAIL OD ON AP.ORDER_NBR = OD.ORDER_NBR AND AP.ORDER_LINE_NBR = OD.LINE_NBR AND OD.ACTIVE_REV = 1
GROUP BY I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID,  OD.GROSS_RATE, OD.NET_RATE,
	OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, OD.LINE_CANCELLED, OD.EXT_GROSS_AMT, OD.EXT_NET_AMT, OD.[START_DATE]

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber)
SELECT 
	AP_NET_AMOUNT = COALESCE (SUM(AP.NET_AMT), 0), -- + COALESCE(SUM(AP.NETCHARGES), 0) + COALESCE(SUM(AP.VENDOR_TAX), 0) + COALESCE(SUM(AP.DISCOUNT_AMT), 0),
	I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID, 
	[OrderGrossRate] = OD.GROSS_RATE, 
	[OrderNetRate] = OD.NET_RATE,
	[InvoiceQtySpots] = NULL,
	SUM(AP_GROSS_AMT),
	MediaType = 'Out Of Home', OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, COALESCE(OD.LINE_CANCELLED, 0),
	0,
	OD.EXT_GROSS_AMT,
	OD.EXT_NET_AMT,
	CASE WHEN OD.POST_DATE IS NOT NULL THEN UPPER(convert(char(3), OD.POST_DATE, 0)) + ' ' + CAST(YEAR(OD.POST_DATE) as varchar(4)) ELSE NULL END,
	CASE WHEN OD.POST_DATE IS NOT NULL THEN datepart(mm, OD.POST_DATE) ELSE NULL END,
	CASE WHEN OD.POST_DATE IS NOT NULL THEN datepart(yyyy, OD.POST_DATE) ELSE NULL END
FROM #INVOICE I 
	INNER JOIN (SELECT 
				 	AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.MODIFY_DELETE, AP.AP_ID,
					AP.NET_AMT, AP.NETCHARGES, AP.VENDOR_TAX, AP.DISCOUNT_AMT,
					AP_GROSS_AMT = CASE WHEN NET_GROSS = 1 THEN 
                                        CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							            ELSE
								            CAST(NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							            END
                                   ELSE CAST(NET_AMT + (NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
                                   END
				FROM dbo.AP_OUTDOOR AP) AP ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	INNER JOIN dbo.AP_HEADER H ON AP.AP_ID = H.AP_ID AND H.MODIFY_FLAG IS NULL
	INNER JOIN dbo.VENDOR VN ON H.VN_FRL_EMP_CODE = VN.VN_CODE
	INNER JOIN dbo.OUTDOOR_HEADER OH ON I.ORDER_NBR = OH.ORDER_NBR 
	LEFT OUTER JOIN dbo.OUTDOOR_DETAIL OD ON AP.ORDER_NBR = OD.ORDER_NBR AND AP.ORDER_LINE_NBR = OD.LINE_NBR AND OD.ACTIVE_REV = 1
GROUP BY I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID,  OD.GROSS_RATE, OD.NET_RATE,
	OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, OD.LINE_CANCELLED, OD.EXT_GROSS_AMT, OD.EXT_NET_AMT, OD.POST_DATE

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber)
SELECT 
	AP_NET_AMOUNT = COALESCE (SUM(AP.EXT_NET_AMT), 0), -- + COALESCE(SUM(AP.NETCHARGES), 0) + COALESCE(SUM(AP.VENDOR_TAX), 0) + COALESCE(SUM(AP.DISC_AMT), 0),
	I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID, 
	[OrderGrossRate] = OD.GROSS_RATE, 
	[OrderNetRate] = OD.NET_RATE,
	[InvoiceQtySpots] = (SELECT COUNT(1) FROM dbo.AP_RADIO_BROADCAST_DTL WHERE AP_ID = H.AP_ID AND ORDER_NBR = I.ORDER_NBR AND ORDER_LINE_NBR = I.LINE_NBR),
	SUM(AP_GROSS_AMT),
	[InvoiceDetailMatching] = CASE
								WHEN V.OrderNumber IS NULL THEN
									CASE WHEN EXISTS(SELECT 1 FROM dbo.AP_RADIO_BROADCAST_DTL WHERE ORDER_NBR = I.ORDER_NBR) THEN 'Needs Review' ELSE 'No Detail' END
								WHEN V.Variant = 0 THEN 'OK'
								ELSE 'Needs Review'
							  END,
	MediaType = 'Radio', OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, COALESCE(OD.LINE_CANCELLED, 0),
	OD.TOTAL_SPOTS,
	OD.EXT_GROSS_AMT,
	OD.EXT_NET_AMT,
	SUBSTRING(UPPER(DateName( month , DateAdd( month , OD.MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(OD.YEAR_NBR as varchar(4)),
	OD.MONTH_NBR,
	OD.YEAR_NBR
FROM #INVOICE I
	INNER JOIN (SELECT 
				 	AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.MODIFY_DELETE, AP.AP_ID,
					AP.EXT_NET_AMT, AP.NETCHARGES, AP.VENDOR_TAX, AP.DISC_AMT, --AP.TOTAL_SPOTS,
					AP_GROSS_AMT = CASE WHEN NET_GROSS = 1 THEN
                                        CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							            ELSE
								            CAST(EXT_NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							            END
                                   ELSE CAST(EXT_NET_AMT + (EXT_NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
                                   END
				FROM dbo.AP_RADIO AP) AP ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	INNER JOIN dbo.AP_HEADER H ON AP.AP_ID = H.AP_ID AND H.MODIFY_FLAG IS NULL
	INNER JOIN dbo.VENDOR VN ON H.VN_FRL_EMP_CODE = VN.VN_CODE
	INNER JOIN dbo.RADIO_HDR OH ON I.ORDER_NBR = OH.ORDER_NBR 
	LEFT OUTER JOIN dbo.RADIO_DETAIL OD ON AP.ORDER_NBR = OD.ORDER_NBR AND AP.ORDER_LINE_NBR = OD.LINE_NBR AND OD.ACTIVE_REV = 1	
	LEFT OUTER JOIN 
		(SELECT	
			OrderNumber,
			OrderLineNumber,
			Variant = CASE WHEN COUNT(CASE WHEN ISNULL(VariantCodes, '') <> '' AND ISNULL(Approved, 0) <> 1 THEN 1 END) > 0 THEN 1 ELSE 0 END
		 FROM
			@view
		 WHERE
			MediaType = 'Radio'
		 GROUP BY
			OrderNumber,
			OrderLineNumber,
			MediaType) V ON AP.ORDER_NBR = V.OrderNumber AND AP.ORDER_LINE_NBR = V.OrderLineNumber
GROUP BY I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID,  V.OrderNumber, OD.GROSS_RATE, OD.NET_RATE, V.Variant,
	OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, OD.LINE_CANCELLED, OD.TOTAL_SPOTS, OD.EXT_GROSS_AMT, OD.EXT_NET_AMT, OD.MONTH_NBR, OD.YEAR_NBR

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber)
SELECT 
	AP_NET_AMOUNT = COALESCE (SUM(AP.EXT_NET_AMT), 0), -- + COALESCE(SUM(AP.NETCHARGES), 0) + COALESCE(SUM(AP.VENDOR_TAX), 0) + COALESCE(SUM(AP.DISC_AMT), 0),
	I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID, 
	[OrderGrossRate] = OD.GROSS_RATE, 
	[OrderNetRate] = OD.NET_RATE,
	[InvoiceQtySpots] = (SELECT COUNT(1) FROM dbo.AP_TV_BROADCAST_DTL WHERE AP_ID = H.AP_ID AND ORDER_NBR = I.ORDER_NBR AND ORDER_LINE_NBR = I.LINE_NBR),
	SUM(AP_GROSS_AMT),
	[InvoiceDetailMatching] = CASE
								WHEN V.OrderNumber IS NULL THEN
									CASE WHEN EXISTS(SELECT 1 FROM dbo.AP_TV_BROADCAST_DTL WHERE ORDER_NBR = I.ORDER_NBR) THEN 'Needs Review' ELSE 'No Detail' END
								WHEN V.Variant = 0 THEN 'OK'
								ELSE 'Needs Review'
							  END,
	MediaType = 'TV', OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, COALESCE(OD.LINE_CANCELLED, 0),
	OD.TOTAL_SPOTS,
	OD.EXT_GROSS_AMT,
	OD.EXT_NET_AMT,
	SUBSTRING(UPPER(DateName( month , DateAdd( month , OD.MONTH_NBR , -1 ) )),1,3) + ' ' + CAST(OD.YEAR_NBR as varchar(4)),
	OD.MONTH_NBR,
	OD.YEAR_NBR
FROM #INVOICE I 
	INNER JOIN (SELECT 
				 	AP.ORDER_NBR, AP.ORDER_LINE_NBR, AP.MODIFY_DELETE, AP.AP_ID,
					AP.EXT_NET_AMT, AP.NETCHARGES, AP.VENDOR_TAX, AP.DISC_AMT, --AP.TOTAL_SPOTS,
					AP_GROSS_AMT = CASE WHEN NET_GROSS = 1 THEN 
                                        CASE WHEN (1 - AP.COMM_PCT/100) = 0 THEN 0
							            ELSE
								            CAST(EXT_NET_AMT / (1 - AP.COMM_PCT/100) as decimal(16,2))
							            END
                                   ELSE CAST(EXT_NET_AMT + (EXT_NET_AMT * AP.MARKUP_PCT / 100) as decimal(16,2))
                                   END
				FROM dbo.AP_TV AP) AP ON AP.ORDER_NBR = I.ORDER_NBR AND AP.ORDER_LINE_NBR = I.LINE_NBR AND COALESCE(AP.MODIFY_DELETE, 0) = 0
	INNER JOIN dbo.AP_HEADER H ON AP.AP_ID = H.AP_ID AND H.MODIFY_FLAG IS NULL
	INNER JOIN dbo.VENDOR VN ON H.VN_FRL_EMP_CODE = VN.VN_CODE
	INNER JOIN dbo.TV_HDR OH ON I.ORDER_NBR = OH.ORDER_NBR 
	LEFT OUTER JOIN dbo.TV_DETAIL OD ON AP.ORDER_NBR = OD.ORDER_NBR AND AP.ORDER_LINE_NBR = OD.LINE_NBR AND OD.ACTIVE_REV = 1	
	LEFT OUTER JOIN 
		(SELECT	
			OrderNumber,
			OrderLineNumber,
			Variant = CASE WHEN COUNT(CASE WHEN ISNULL(VariantCodes, '') <> '' AND ISNULL(Approved, 0) <> 1 THEN 1 END) > 0 THEN 1 ELSE 0 END
		 FROM
			@view
		 WHERE
			MediaType = 'TV'
		 GROUP BY
			OrderNumber,
			OrderLineNumber,
			MediaType) V ON AP.ORDER_NBR = V.OrderNumber AND AP.ORDER_LINE_NBR = V.OrderLineNumber
GROUP BY I.ORDER_NBR, I.LINE_NBR, H.AP_INV_VCHR, H.VN_FRL_EMP_CODE, VN.VN_NAME, H.AP_INV_DATE, H.AP_ID,  V.OrderNumber, OD.GROSS_RATE, OD.NET_RATE, V.Variant,
	OH.CL_CODE, OH.DIV_CODE, OH.PRD_CODE, OD.LINE_CANCELLED, OD.TOTAL_SPOTS, OD.EXT_GROSS_AMT, OD.EXT_NET_AMT, OD.MONTH_NBR, OD.YEAR_NBR
		
IF @debug = 1
	select * from #AP_NET_AMOUNT

INSERT INTO #INVOICE2
SELECT i.ORDER_NBR, i.LINE_NBR
FROM #INVOICE i
	LEFT OUTER JOIN #AP_NET_AMOUNT a ON a.ORDER_NBR = i.ORDER_NBR AND a.LINE_NBR = i.LINE_NBR 
WHERE a.LINE_NBR IS NULL

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber, DoesNotHaveAP)
SELECT DISTINCT 0, d.ORDER_NBR, d.LINE_NBR, a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, 0, 0, 0, 0, NULL,
	a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, 0, COALESCE(d.QUANTITY, 0), COALESCE(d.EXT_GROSS_AMT, 0), COALESCE(d.EXT_NET_AMT, 0), UPPER(SUBSTRING(DATENAME(month, d.[START_DATE]), 1, 3)) + ' ' + CAST(YEAR(d.[START_DATE]) as varchar), MONTH(d.[START_DATE]), YEAR(d.[START_DATE]), 1
FROM dbo.INTERNET_DETAIL d
	INNER JOIN #INVOICE2 i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN #AP_NET_AMOUNT na ON na.ORDER_NBR = d.ORDER_NBR AND na.MonthNumber = MONTH(d.[START_DATE]) AND na.YearNumber = YEAR(d.[START_DATE])
	INNER JOIN (SELECT DISTINCT a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, a.ORDER_NBR
				FROM #AP_NET_AMOUNT a) a ON a.ORDER_NBR = d.ORDER_NBR

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber, DoesNotHaveAP)
SELECT DISTINCT 0, d.ORDER_NBR, d.LINE_NBR, a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, 0, 0, 0, 0, NULL,
	a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, 0, 0, COALESCE(d.EXT_GROSS_AMT, 0), COALESCE(d.EXT_NET_AMT, 0), UPPER(SUBSTRING(DATENAME(month, d.[START_DATE]), 1, 3)) + ' ' + CAST(YEAR(d.[START_DATE]) as varchar), MONTH(d.[START_DATE]), YEAR(d.[START_DATE]), 1
FROM dbo.MAGAZINE_DETAIL d
	INNER JOIN #INVOICE2 i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN #AP_NET_AMOUNT na ON na.ORDER_NBR = d.ORDER_NBR AND na.MonthNumber = MONTH(d.[START_DATE]) AND na.YearNumber = YEAR(d.[START_DATE])
	INNER JOIN (SELECT DISTINCT a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, a.ORDER_NBR
				FROM #AP_NET_AMOUNT a) a ON a.ORDER_NBR = d.ORDER_NBR

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber, DoesNotHaveAP)
SELECT DISTINCT 0, d.ORDER_NBR, d.LINE_NBR, a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, 0, 0, 0, 0, NULL,
	a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, 0, 0, COALESCE(d.EXT_GROSS_AMT, 0), COALESCE(d.EXT_NET_AMT, 0), UPPER(SUBSTRING(DATENAME(month, d.[START_DATE]), 1, 3)) + ' ' + CAST(YEAR(d.[START_DATE]) as varchar), MONTH(d.[START_DATE]), YEAR(d.[START_DATE]), 1
FROM dbo.NEWSPAPER_DETAIL d
	INNER JOIN #INVOICE2 i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN #AP_NET_AMOUNT na ON na.ORDER_NBR = d.ORDER_NBR AND na.MonthNumber = MONTH(d.[START_DATE]) AND na.YearNumber = YEAR(d.[START_DATE])
	INNER JOIN (SELECT DISTINCT a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, a.ORDER_NBR
				FROM #AP_NET_AMOUNT a) a ON a.ORDER_NBR = d.ORDER_NBR

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber, DoesNotHaveAP)
SELECT DISTINCT 0, d.ORDER_NBR, d.LINE_NBR, a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, 0, 0, 0, 0, NULL,
	a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, 0, 0, COALESCE(d.EXT_GROSS_AMT, 0), COALESCE(d.EXT_NET_AMT, 0), UPPER(SUBSTRING(DATENAME(month, d.[POST_DATE]), 1, 3)) + ' ' + CAST(YEAR(d.[POST_DATE]) as varchar), MONTH(d.[POST_DATE]), YEAR(d.[POST_DATE]), 1
FROM dbo.OUTDOOR_DETAIL d
	INNER JOIN #INVOICE2 i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN #AP_NET_AMOUNT na ON na.ORDER_NBR = d.ORDER_NBR AND na.MonthNumber = MONTH(d.[POST_DATE]) AND na.YearNumber = YEAR(d.[POST_DATE])
	INNER JOIN (SELECT DISTINCT a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, a.ORDER_NBR
				FROM #AP_NET_AMOUNT a) a ON a.ORDER_NBR = d.ORDER_NBR

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots, 
	AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber, DoesNotHaveAP)
SELECT DISTINCT 0, d.ORDER_NBR, d.LINE_NBR, a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, 0, 0, (SELECT COUNT(1) FROM dbo.AP_RADIO_BROADCAST_DTL WHERE AP_ID = na.AccountPayableID AND ORDER_NBR = d.ORDER_NBR AND ORDER_LINE_NBR = d.LINE_NBR),
	0, NULL,
	a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, 0, COALESCE(TOTAL_SPOTS, 0), COALESCE(d.EXT_GROSS_AMT, 0), COALESCE(d.EXT_NET_AMT, 0), UPPER(SUBSTRING(DateName( month , DateAdd( month , d.MONTH_NBR , 0 ) - 1 ), 1, 3)) + ' ' + CAST(d.YEAR_NBR as varchar), MONTH_NBR, YEAR_NBR, 1
FROM dbo.RADIO_DETAIL d
	INNER JOIN #INVOICE2 i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN #AP_NET_AMOUNT na ON na.ORDER_NBR = d.ORDER_NBR AND na.MonthNumber = d.MONTH_NBR AND na.YearNumber = d.YEAR_NBR
	INNER JOIN (SELECT DISTINCT a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, a.ORDER_NBR
				FROM #AP_NET_AMOUNT a) a ON a.ORDER_NBR = d.ORDER_NBR
	INNER JOIN dbo.AP_HEADER aph ON na.AccountPayableID = aph.AP_ID AND COALESCE(aph.MODIFY_FLAG, 0) = 0 AND aph.DELETE_FLAG IS NULL

INSERT #AP_NET_AMOUNT (AP_NET_AMOUNT, ORDER_NBR, LINE_NBR, InvoiceNumber, VendorCode, VendorName, InvoiceDate, AccountPayableID, OrderGrossRate, OrderNetRate, InvoiceQtySpots,
	AP_GROSS_AMOUNT, InvoiceDetailMatching,
	MediaType, ClientCode, DivisionCode, ProductCode, LineCancelled, OrderQtySpots, GrossOrderAmount, NetOrderAmount, MonthYear, MonthNumber, YearNumber, DoesNotHaveAP)
SELECT DISTINCT 0, d.ORDER_NBR, d.LINE_NBR, a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, 0, 0, (SELECT COUNT(1) FROM dbo.AP_TV_BROADCAST_DTL WHERE AP_ID = na.AccountPayableID AND ORDER_NBR = d.ORDER_NBR AND ORDER_LINE_NBR = d.LINE_NBR),
	0, NULL,
	a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, 0, COALESCE(TOTAL_SPOTS, 0), COALESCE(d.EXT_GROSS_AMT, 0), COALESCE(d.EXT_NET_AMT, 0), UPPER(SUBSTRING(DateName( month , DateAdd( month , d.MONTH_NBR , 0 ) - 1 ), 1, 3)) + ' ' + CAST(d.YEAR_NBR as varchar), MONTH_NBR, YEAR_NBR, 1
FROM dbo.TV_DETAIL d
	INNER JOIN #INVOICE2 i ON d.ORDER_NBR = i.ORDER_NBR AND d.LINE_NBR = i.LINE_NBR AND d.ACTIVE_REV = 1
	INNER JOIN #AP_NET_AMOUNT na ON na.ORDER_NBR = d.ORDER_NBR AND na.MonthNumber = d.MONTH_NBR AND na.YearNumber = d.YEAR_NBR
	INNER JOIN (SELECT DISTINCT a.InvoiceNumber, a.VendorCode, a.VendorName, a.InvoiceDate, a.AccountPayableID, a.MediaType, a.ClientCode, a.DivisionCode, a.ProductCode, a.ORDER_NBR
				FROM #AP_NET_AMOUNT a) a ON a.ORDER_NBR = d.ORDER_NBR
	INNER JOIN dbo.AP_HEADER aph ON na.AccountPayableID = aph.AP_ID AND COALESCE(aph.MODIFY_FLAG, 0) = 0 AND aph.DELETE_FLAG IS NULL
				
--UPDATE #AP_NET_AMOUNT SET InvoiceDetailMatching = CASE
--													WHEN v.[OrderNumber] IS NULL THEN 'No Detail'
--													WHEN (SELECT COUNT(1) 
--															FROM @view 
--															WHERE [OrderNumber] = a.ORDER_NBR
--															AND [OrderLineNumber] = a.LINE_NBR
--															AND NULLIF([VariantCodes],'') IS NOT NULL 
--															AND COALESCE([Approved], 0) <> 1) > 0 THEN 'Needs Review'
--													ELSE 'OK'
--													END
--FROM #AP_NET_AMOUNT a
--	LEFT OUTER JOIN @view v ON a.ORDER_NBR = v.[OrderNumber] AND a.LINE_NBR = v.[OrderLineNumber] AND a.MediaType = v.MediaType
	
IF @debug = 1
	select * from #AP_NET_AMOUNT

CREATE TABLE #UNMATCHED (
	MediaType varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	AP_ID int NOT NULL,
	ORDER_NBR int NOT NULL,
	LINE_NBR smallint NOT NULL,
	UNMATCHED int NULL
)

INSERT INTO #UNMATCHED (MediaType, AP_ID, ORDER_NBR, LINE_NBR)
SELECT 
	MediaType,
	AccountPayableID,
	ORDER_NBR,
	MIN(LINE_NBR)
FROM #AP_NET_AMOUNT
GROUP BY
	MediaType,
	AccountPayableID,
	ORDER_NBR

UPDATE U SET UNMATCHED = CASE
							WHEN MediaType = 'Radio' THEN (SELECT COUNT(1) FROM dbo.AP_RADIO_BROADCAST_DTL WHERE AP_ID = U.AP_ID AND ORDER_NBR = U.ORDER_NBR AND ORDER_LINE_NBR IS NULL)
							WHEN MediaType = 'TV' THEN (SELECT COUNT(1) FROM dbo.AP_TV_BROADCAST_DTL WHERE AP_ID = U.AP_ID AND ORDER_NBR = U.ORDER_NBR AND ORDER_LINE_NBR IS NULL)
							ELSE NULL
						 END
FROM #UNMATCHED U

SELECT 
	AP.MediaType,
	ClientCode,
	DivisionCode,
	ProductCode,
	[Vendor] = VendorCode + ' - ' + VendorName,
	[OrderNumber] = AP.ORDER_NBR,
	[LineNumber] = AP.LINE_NBR,
	InvoiceNumber,
	InvoiceDate,
	InvoiceQtySpots,
	Unmatched = U.UNMATCHED,
	APGrossAmount = AP_GROSS_AMOUNT,
	APNetAmount = AP_NET_AMOUNT,
	AccountPayableID,
	LineCancelled,
	ApprovalStatus = AMA.[STATUS],
	ApprovalNotes = AMA.COMMENTS,
	OrderGrossRate,
	OrderNetRate,
	InvoiceDetailMatching,
	OrderQtySpots = COALESCE(OrderQtySpots, 0),
	GrossOrderAmount = COALESCE(GrossOrderAmount, 0),
	NetOrderAmount = COALESCE(NetOrderAmount, 0),
	MonthYear,
	MonthNumber,
	YearNumber
FROM
	#AP_NET_AMOUNT AP
	LEFT OUTER JOIN dbo.AP_MEDIA_APPROVAL AMA ON AMA.AP_ID = AP.AccountPayableID AND AMA.ORDER_NBR = AP.ORDER_NBR AND AMA.LINE_NBR = AP.LINE_NBR AND AMA.ACTIVE_REV = 1
	LEFT OUTER JOIN #UNMATCHED U ON U.AP_ID = AP.AccountPayableID AND U.ORDER_NBR = AP.ORDER_NBR AND U.LINE_NBR = AP.LINE_NBR

DROP TABLE #INVOICE
DROP TABLE #INVOICE2
DROP TABLE #AP_NET_AMOUNT
DROP TABLE #UNMATCHED
GO
