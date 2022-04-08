CREATE PROCEDURE [dbo].[advsp_broadcast_invoice_summary_report]
	@StartPeriod int,
	@EndPeriod int,
	@IncludeTV bit,
	@IncludeRadio bit,
	@OrderStatus smallint,	
	@OfficeCodeList varchar(MAX) = NULL,
	@ClientCodeList varchar(MAX) = NULL,
	@ClientDivisionCodeList varchar(MAX) = NULL,
	@ClientDivisionProductCodeList varchar(MAX) = NULL
AS
BEGIN

	CREATE TABLE #InvoiceSummary 
	(
		Market varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		VendorCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		VendorName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		FlightStart date,
		FlightEnd date,
		OrderNumber int,
        OrderLineNumber smallint,
        OfficeCode varchar(4) COLLATE SQL_Latin1_General_CP1_CI_AS,
        OfficeName varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ClientName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		DivisionCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		DivisionName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ProductCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ProductName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		Media varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS,
		Calendar varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS,
		MonthOfService varchar(7) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ScheduleGross decimal(15,2),
		ScheduleNet decimal(15,2),
		InvoiceNumber varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS,
		InvoiceDate date,
		[Status] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS,
		InvoiceGross decimal(15,2),
		InvoiceNet decimal(15,2),
        YearMonth varchar(7),
        WorksheetName varchar(100)
	)
			
	IF @IncludeTV = 1 BEGIN
		
		INSERT INTO #InvoiceSummary
		SELECT
			M.MARKET_DESC,
			TV.VN_CODE,
			V.VN_NAME,
			CAST(TV.[START_DATE] AS date),
			CAST(TV.END_DATE AS date),
			TV.ORDER_NBR,
			TVD.LINE_NBR,
			TV.OFFICE_CODE,
			O.OFFICE_NAME,
			TV.CL_CODE,
			C.CL_NAME,
			TV.DIV_CODE,
			D.DIV_NAME,
			TV.PRD_CODE,
			P.PRD_DESCRIPTION,
			SC.SC_DESCRIPTION,
			CASE WHEN 
						ISNULL(MBW.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, 0) = 0 THEN ''
				 ELSE
						CASE WHEN MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID = 1 THEN 'Daily'
							 WHEN MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID = 2 THEN 'Weekly' 
							 ELSE '' END
						+ ' ' + 
						CASE WHEN MBW.MEDIA_CALENDAR_TYPE_ID = 1 THEN 'Calendar'
							 WHEN MBW.MEDIA_CALENDAR_TYPE_ID = 2 THEN 'Broadcast' 
							 ELSE '' END
			END,
			CASE WHEN TVD.END_DATE IS NOT NULL THEN RIGHT('0'+ CAST(MONTH(TVD.END_DATE) AS varchar(2)), 2) + '/' + RIGHT(CAST(YEAR(TVD.END_DATE) AS varchar(4)), 2)
				 ELSE '' END,
			TVD.EXT_GROSS_AMT,
			TVD.EXT_NET_AMT,
			AP.AP_INV_VCHR,
			AP.AP_INV_DATE,
			CASE WHEN ISNULL(AP.AP_INV_VCHR, '') = '' THEN 'No Invoice'
				 WHEN ISNULL(APMA.[STATUS], -1) = -1 THEN 'None' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 0 THEN 'Approval Not Required' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 1 THEN 'Pending Approval' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 2 THEN 'Approved' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 3 THEN 'Approved With Changes'
				 ELSE '' END,
			APTV.EXT_NET_AMT + APTV.COMM_AMT,
			APTV.EXT_NET_AMT,
            CASE WHEN TVD.END_DATE IS NOT NULL THEN CAST(YEAR(TVD.END_DATE) as varchar) + '|' + CAST(MONTH(TVD.END_DATE) AS varchar(2)) ELSE '' END,
            WorksheetName = MBW.[NAME]
		FROM
			dbo.TV_HDR TV 
			INNER JOIN (SELECT 
							TVD.ORDER_NBR,
							TVD.LINE_NBR,
							TVD.SEQ_NBR,
							TVD.REV_NBR,
							TVD.EXT_GROSS_AMT,
							TVD.EXT_NET_AMT,
							TVD.[MONTH_NBR],
							TVD.[YEAR_NBR],
							TVD.END_DATE
						FROM
							dbo.TV_DETAIL TVD
						WHERE
							TVD.ACTIVE_REV = 1) AS TVD ON TVD.ORDER_NBR = TV.ORDER_NBR
			LEFT OUTER JOIN dbo.AP_TV APTV ON APTV.ORDER_NBR = TVD.ORDER_NBR 
											  AND APTV.ORDER_LINE_NBR = TVD.LINE_NBR 
											  AND (APTV.MODIFY_DELETE IS NULL OR APTV.MODIFY_DELETE = 0)
			LEFT OUTER JOIN dbo.AP_HEADER AP ON AP.AP_ID = APTV.AP_ID
			INNER JOIN dbo.VENDOR V ON V.VN_CODE = TV.VN_CODE
			LEFT OUTER JOIN dbo.MARKET M ON M.MARKET_CODE = V.MARKET_CODE
			LEFT OUTER JOIN dbo.OFFICE O ON O.OFFICE_CODE = TV.OFFICE_CODE
			INNER JOIN dbo.CLIENT C ON C.CL_CODE = TV.CL_CODE
			INNER JOIN dbo.DIVISION D ON D.CL_CODE = TV.CL_CODE
										 AND D.DIV_CODE = TV.DIV_CODE
			INNER JOIN dbo.PRODUCT P ON P.CL_CODE = TV.CL_CODE
										AND P.DIV_CODE = TV.DIV_CODE
										AND P.PRD_CODE = TV.PRD_CODE
			LEFT OUTER JOIN dbo.SALES_CLASS SC ON SC.SC_CODE = TV.MEDIA_TYPE
			LEFT OUTER JOIN (
							SELECT DISTINCT MBWMDD.ORDER_NBR, MBW.[NAME], MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID, MBW.MEDIA_CALENDAR_TYPE_ID
							FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID
							WHERE MBWMDD.ORDER_NBR IS NOT NULL
							AND MBW.MEDIA_TYPE_CODE = 'T' 
							) MBW ON MBW.ORDER_NBR = TV.ORDER_NBR 
			LEFT OUTER JOIN (SELECT 
									APMA.AP_ID,
									APMA.ORDER_NBR,
									APMA.LINE_NBR,
									APMA.[STATUS]
								FROM
									dbo.AP_MEDIA_APPROVAL APMA
								WHERE
									APMA.ACTIVE_REV = 1) AS APMA ON APMA.AP_ID = APTV.AP_ID
																	AND APMA.ORDER_NBR = APTV.ORDER_NBR
																	AND APMA.LINE_NBR = APTV.ORDER_LINE_NBR
        WHERE
            CAST(CAST(TVD.[YEAR_NBR] AS varchar(4)) + RIGHT('0'+ CAST(TVD.[MONTH_NBR] AS varchar(2)), 2) AS int) BETWEEN @StartPeriod and @EndPeriod
            AND (@OrderStatus = 1
		         OR (@OrderStatus = 2 
                     AND TV.ORD_PROCESS_CONTRL NOT IN (6,12)))

	END
			
	IF @IncludeRadio = 1 BEGIN
	
		INSERT INTO #InvoiceSummary
		SELECT
			M.MARKET_DESC,
			R.VN_CODE,
			V.VN_NAME,
			CAST(R.[START_DATE] AS date),
			CAST(R.END_DATE AS date),
			R.ORDER_NBR,
			RD.LINE_NBR,
			R.OFFICE_CODE,
			O.OFFICE_NAME,
			R.CL_CODE,
			C.CL_NAME,
			R.DIV_CODE,
			D.DIV_NAME,
			R.PRD_CODE,
			P.PRD_DESCRIPTION,
			SC.SC_DESCRIPTION,
			CASE WHEN 
						ISNULL(MBW.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, 0) = 0 THEN ''
				 ELSE
						CASE WHEN MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID = 1 THEN 'Daily'
							 WHEN MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID = 2 THEN 'Weekly' 
							 ELSE '' END
						+ ' ' + 
						CASE WHEN MBW.MEDIA_CALENDAR_TYPE_ID = 1 THEN 'Calendar'
							 WHEN MBW.MEDIA_CALENDAR_TYPE_ID = 2 THEN 'Broadcast' 
							 ELSE '' END
			END,
			CASE WHEN RD.END_DATE IS NOT NULL THEN RIGHT('0'+ CAST(MONTH(RD.END_DATE) AS varchar(2)), 2) + '/' + RIGHT(CAST(YEAR(RD.END_DATE) AS varchar(4)), 2)
				 ELSE '' END,
			RD.EXT_GROSS_AMT,
			RD.EXT_NET_AMT,
			AP.AP_INV_VCHR,
			AP.AP_INV_DATE,
			CASE WHEN ISNULL(AP.AP_INV_VCHR, '') = '' THEN 'No Invoice'
				 WHEN ISNULL(APMA.[STATUS], -1) = -1 THEN 'None' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 0 THEN 'Approval Not Required' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 1 THEN 'Pending Approval' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 2 THEN 'Approved' 
				 WHEN ISNULL(APMA.[STATUS], -1) = 3 THEN 'Approved With Changes'
				 ELSE '' END,
			APR.EXT_NET_AMT + APR.COMM_AMT,
			APR.EXT_NET_AMT,
            CASE WHEN RD.END_DATE IS NOT NULL THEN CAST(YEAR(RD.END_DATE) as varchar) + '|' + CAST(MONTH(RD.END_DATE) AS varchar(2)) ELSE '' END,
            WorksheetName = MBW.[NAME]
		FROM
			dbo.RADIO_HDR R 
			INNER JOIN (SELECT 
							RD.ORDER_NBR,
							RD.LINE_NBR,
							RD.SEQ_NBR,
							RD.REV_NBR,
							RD.EXT_GROSS_AMT,
							RD.EXT_NET_AMT,
							RD.[MONTH_NBR],
							RD.[YEAR_NBR],
							RD.END_DATE
						FROM
							dbo.RADIO_DETAIL RD
						WHERE
							RD.ACTIVE_REV = 1) AS RD ON RD.ORDER_NBR = R.ORDER_NBR
			LEFT OUTER JOIN dbo.AP_RADIO APR ON APR.ORDER_NBR = RD.ORDER_NBR 
												AND APR.ORDER_LINE_NBR = RD.LINE_NBR 
												AND (APR.MODIFY_DELETE IS NULL OR APR.MODIFY_DELETE = 0)
			LEFT OUTER JOIN dbo.AP_HEADER AP ON AP.AP_ID = APR.AP_ID
			INNER JOIN dbo.VENDOR V ON V.VN_CODE = R.VN_CODE
			LEFT OUTER JOIN dbo.MARKET M ON M.MARKET_CODE = V.MARKET_CODE
			LEFT OUTER JOIN dbo.OFFICE O ON O.OFFICE_CODE = R.OFFICE_CODE
			INNER JOIN dbo.CLIENT C ON C.CL_CODE = R.CL_CODE
			INNER JOIN dbo.DIVISION D ON D.CL_CODE = R.CL_CODE
										 AND D.DIV_CODE = R.DIV_CODE
			INNER JOIN dbo.PRODUCT P ON P.CL_CODE = R.CL_CODE
										AND P.DIV_CODE = R.DIV_CODE
										AND P.PRD_CODE = R.PRD_CODE
			LEFT OUTER JOIN dbo.SALES_CLASS SC ON SC.SC_CODE = R.MEDIA_TYPE
			LEFT OUTER JOIN (
							SELECT DISTINCT MBWMDD.ORDER_NBR, MBW.[NAME], MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID, MBW.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID, MBW.MEDIA_CALENDAR_TYPE_ID
							FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE MBWMDD
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL MBWMD ON MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET_MARKET MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID 
								INNER JOIN dbo.MEDIA_BROADCAST_WORKSHEET MBW ON MBW.MEDIA_BROADCAST_WORKSHEET_ID = MBWM.MEDIA_BROADCAST_WORKSHEET_ID
							WHERE MBWMDD.ORDER_NBR IS NOT NULL
							AND MBW.MEDIA_TYPE_CODE = 'R' 
							) MBW ON MBW.ORDER_NBR = R.ORDER_NBR
			LEFT OUTER JOIN (SELECT 
									APMA.AP_ID,
									APMA.ORDER_NBR,
									APMA.LINE_NBR,
									APMA.[STATUS]
								FROM
									dbo.AP_MEDIA_APPROVAL APMA
								WHERE
									APMA.ACTIVE_REV = 1) AS APMA ON APMA.AP_ID = APR.AP_ID
																	AND APMA.ORDER_NBR = APR.ORDER_NBR
																	AND APMA.LINE_NBR = APR.ORDER_LINE_NBR
        WHERE
            CAST(CAST(RD.[YEAR_NBR] AS varchar(4)) + RIGHT('0'+ CAST(RD.[MONTH_NBR] AS varchar(2)), 2) AS int) BETWEEN @StartPeriod and @EndPeriod 
            AND (@OrderStatus = 1
		         OR (@OrderStatus = 2 
                     AND R.ORD_PROCESS_CONTRL NOT IN (6,12)))

	END

    IF @OfficeCodeList IS NOT NULL BEGIN

        DELETE FROM #InvoiceSummary WHERE OfficeCode NOT IN (SELECT items COLLATE DATABASE_DEFAULT FROM dbo.udf_split_list(@OfficeCodeList, ','))

    END
    
    IF @ClientCodeList IS NOT NULL BEGIN

        DELETE FROM #InvoiceSummary WHERE ClientCode NOT IN (SELECT items COLLATE DATABASE_DEFAULT FROM dbo.udf_split_list(@ClientCodeList, ','))

    END ELSE IF @ClientDivisionCodeList IS NOT NULL BEGIN
    
        DELETE FROM #InvoiceSummary WHERE ClientCode + '|' + DivisionCode NOT IN (SELECT items COLLATE DATABASE_DEFAULT FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))
        
    END ELSE IF @ClientDivisionProductCodeList IS NOT NULL BEGIN
    
        DELETE FROM #InvoiceSummary WHERE ClientCode + '|' + DivisionCode + '|' + ProductCode NOT IN (SELECT items COLLATE DATABASE_DEFAULT FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))

    END

	SELECT 
		Market,
		Media,
		VendorCode,
		VendorName,
		OrderNumber,
        OrderLineNumber,
		FlightStart,
		FlightEnd,
		MonthOfService,
		ClientCode,
		ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductName,
		InvoiceNumber,
		Calendar,
		ScheduleGross = SUM(ScheduleGross),
		ScheduleNet = SUM(ScheduleNet),
		InvoiceDate,
		[Status],
		InvoiceGross = SUM(InvoiceGross),
		InvoiceNet = SUM(InvoiceNet),
        YearMonth,
        WorksheetName
	FROM 
		#InvoiceSummary
    GROUP BY 
        Market,
		Media,
		VendorCode,
		VendorName,
		OrderNumber,
        OrderLineNumber,
		FlightStart,
		FlightEnd,
		MonthOfService,
		ClientCode,
		ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductName,
		InvoiceNumber,
		Calendar,
		InvoiceDate,
		[Status],
        YearMonth,
        WorksheetName
	ORDER BY
		Market,
		Media,
		VendorCode,
		VendorName,
		OrderNumber,
        OrderLineNumber,
		MonthOfService

	DROP TABLE #InvoiceSummary

END
GO