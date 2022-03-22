CREATE PROCEDURE [dbo].[advsp_broadcast_invoice_detail_report]
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

	CREATE TABLE #InvDtlRptInvoiceSummary 
	(
		Market varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		Media varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS,
        VendorCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		VendorName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		OrderNumber int,
        OrderLineNumber smallint,
        FlightStart smalldatetime,
		FlightEnd smalldatetime,
        MonthOfService varchar(7) COLLATE SQL_Latin1_General_CP1_CI_AS,
        ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ClientName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		DivisionCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		DivisionName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ProductCode varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS,
		ProductName varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
        InvoiceNumber varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS,
        Calendar varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS,
        ScheduleGross decimal(15,2),
		ScheduleNet decimal(15,2),
        InvoiceDate smalldatetime,
		[Status] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS,
		InvoiceGross decimal(15,2),
		InvoiceNet decimal(15,2),
        YearMonth varchar(7),
        WorksheetName varchar(100)
	)
	INSERT INTO #InvDtlRptInvoiceSummary  
    EXEC [dbo].[advsp_broadcast_invoice_summary_report] @StartPeriod, @EndPeriod, @IncludeTV, @IncludeRadio, @OrderStatus, @OfficeCodeList, @ClientCodeList, 
        @ClientDivisionCodeList, @ClientDivisionProductCodeList

    DELETE #InvDtlRptInvoiceSummary 
    WHERE NULLIF(InvoiceNumber,'') IS NULL

    CREATE TABLE #orderdetail (
	    [MediaType] varchar(5),
	    [VendorCode] varchar(6),
	    [VendorName] varchar(40),
	    [Vendor] varchar(49),
	    [OrderNumber] int,
 	    [OrderLineNumber] smallint,
	    [WeekOf] smalldatetime,
	    [RevisionNumber] smallint,
	    [SequenceNumber] smallint,
 	    [StartDate] smalldatetime,
 	    [EndDate] smalldatetime,
	    [StartTime] varchar(10),
	    [EndTime] varchar(10),
 	    [Days] varchar(100),
 	    [Length] smallint,
 	    [AdNumber] varchar(30),
 	    [NetworkID] varchar(10),
 	    [GrossRate] decimal(16,4),
 	    [Spots] int,
	    [ActualSpots] int,
	    [MatchedSpots] int,
 	    [VariantCodes] varchar(100),
	    [OrderMonthNumber] smallint,
	    [OrderYearNumber] smallint,
	    [IsBookend] bit,
	    [IsHiatus] bit,
	    [AllowSpotsToBeEntered] bit,
	    [Daypart] int,
	    [Program] varchar(100),
	    [EstimatedGRP] decimal(10,2),
	    [EstimatedImpressions] bigint,
	    [WorksheetLineNumber] int,
	    [IsDaily] bit,
	    [CanEdit] bit,
        [Monday] bit,
	    [Tuesday] bit,
	    [Wednesday] bit,
	    [Thursday] bit,
	    [Friday] bit,
	    [Saturday] bit,
	    [Sunday] bit,
        [WorksheetMakegoodNumber] smallint
    )

    DECLARE @view TABLE (
	    [DetailID] int NOT NULL,
	    [MediaType] varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
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

    DECLARE @OrderNumberLineNumbers varchar(MAX),
	        @OrderYearMonths varchar(MAX),
	        @OrderNumbers varchar(MAX),
	        @ShowWeekOf bit,
            @MatchAdditionalParameters bit
    	
    SELECT @OrderNumberLineNumbers = COALESCE(@OrderNumberLineNumbers + ',','') + CAST(OrderNumber AS VARCHAR) + '|' + CAST(OrderLineNumber AS VARCHAR)
    FROM (SELECT DISTINCT OrderNumber, OrderLineNumber FROM #InvDtlRptInvoiceSummary ) d
    
    SELECT @OrderYearMonths = COALESCE(@OrderYearMonths + ',','') + CAST(OrderNumber AS VARCHAR) + '|' + YearMonth
    FROM (SELECT DISTINCT OrderNumber, YearMonth FROM #InvDtlRptInvoiceSummary ) d

    SELECT @OrderNumbers = COALESCE(@OrderNumbers + ',','') + CAST(OrderNumber AS VARCHAR)
    FROM (SELECT DISTINCT OrderNumber FROM #InvDtlRptInvoiceSummary ) d

    SET @ShowWeekOf = 1
	SET @MatchAdditionalParameters = 1
    --SELECT @OrderNumberLineNumbers AS '@OrderNumberLineNumbers'
    --SELECT @OrderYearMonths as '@OrderYearMonths'
    --SELECT @OrderNumbers as '@OrderNumbers'

    INSERT into #orderdetail 
    EXEC advsp_broadcast_order_verification @OrderNumberLineNumbers, @OrderYearMonths, @OrderNumbers, @ShowWeekOf
    --SELECT * from #orderdetail 

    INSERT INTO @view
    SELECT * FROM dbo.advtf_broadcast_order_dtl_verification (@OrderNumberLineNumbers, @MatchAdditionalParameters, @OrderYearMonths, @OrderNumbers, @ShowWeekOf)
    --select * from @view

    SELECT
        [is].Market,
        [is].Media,
        [is].VendorCode,
        [is].VendorName,
        [is].OrderNumber,
        [is].OrderLineNumber,
        [is].FlightStart,
        [is].FlightEnd,
        [is].MonthOfService,
        [is].ClientCode,
        [is].ClientName,
        [is].DivisionCode,
        [is].DivisionName,
        [is].ProductCode,
        [is].ProductName,
        [is].InvoiceNumber,
        [is].Calendar,
        [is].ScheduleGross,
        [is].ScheduleNet,
        [is].InvoiceDate,
        [is].[Status],
        [is].InvoiceGross,
        [is].InvoiceNet,
        [is].YearMonth,
        od.WeekOf,
        od.[Days],
        Times = od.StartTime + '-' + od.EndTime,
        od.NetworkID,
        od.Program,
        od.AdNumber,
        DayPart = dp.DAY_PART_CODE,
        od.[Length],
        [Rate] = od.GrossRate,
        GrossTotal = od.GrossRate * od.Spots,
        od.Spots,
        [ActualSpotsTotal] = od.ActualSpots,
        Variance = od.ActualSpots - [od].Spots,
        od.MatchedSpots,
        od.VariantCodes,
        SpotDayOfWeek = dtl.[DayOfWeek],
        SpotDate = dtl.RunDate,
        SpotRunTime = convert(char(20),dtl.RunTime,0),
        SpotNetworkID = dtl.NetworkID,
        SpotProgramName = dtl.ProgramName,
        SpotAdNumber = dtl.AdNumber,
        SpotLength = dtl.[Length],
        SpotRate = dtl.GrossRate,
        SpotGrossTotal = dtl.GrossRate,
        SpotSpots = CAST(CASE WHEN dtl.WeekOf IS NOT NULL THEN 1 ELSE NULL END as smallint),
        SpotVariantCode = dtl.VariantCodes,
        SpotUnmatched = CAST(CASE WHEN dtl.OrderLineNumber IS NULL THEN 1 ELSE 0 END as bit),
        SpotApproved = CAST(COALESCE(dtl.Approved,0) as bit),
        [is].WorksheetName
    FROM #InvDtlRptInvoiceSummary  [is]
        INNER JOIN #orderdetail [od] ON [is].OrderNumber = [od].OrderNumber AND [is].OrderLineNumber = [od].OrderLineNumber
        LEFT OUTER JOIN @view dtl
            ON od.WeekOf = dtl.WeekOf AND od.OrderNumber = dtl.OrderNumber AND od.OrderLineNumber = dtl.OrderLineNumber
		LEFT OUTER JOIN dbo.DAY_PART dp ON od.Daypart = dp.DAY_PART_ID 

	UNION ALL

	SELECT
        summary.Market,
        summary.Media,
        summary.VendorCode,
        summary.VendorName,
        summary.OrderNumber,
        OrderLineNumber = NULL,
        summary.FlightStart,
        summary.FlightEnd,
        summary.MonthOfService,
        summary.ClientCode,
        summary.ClientName,
        summary.DivisionCode,
        summary.DivisionName,
        summary.ProductCode,
        summary.ProductName,
        summary.InvoiceNumber,
        summary.Calendar,
        ScheduleGross = NULL,	--by line number
        ScheduleNet = NULL,		--by line number
        summary.InvoiceDate,
        [Status] = NULL,		--by line number
        InvoiceGross = NULL,	--by AP invoice line number
        InvoiceNet=NULL,		--by AP invoice line number
        YearMonth=NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        SpotDayOfWeek = dtl.[DayOfWeek],
        SpotDate = dtl.RunDate,
        SpotRunTime = convert(char(20),dtl.RunTime,0),
        SpotNetworkID = dtl.NetworkID,
        SpotProgramName = dtl.ProgramName,
        SpotAdNumber = dtl.AdNumber,
        SpotLength = dtl.[Length],
        SpotRate = dtl.GrossRate,
        SpotGrossTotal = dtl.GrossRate,
        SpotSpots = CAST(CASE WHEN dtl.WeekOf IS NOT NULL THEN 1 ELSE NULL END as smallint),
        SpotVariantCode = dtl.VariantCodes,
        SpotUnmatched = CAST(CASE WHEN dtl.OrderLineNumber IS NULL THEN 1 ELSE 0 END as bit),
        SpotApproved = CAST(COALESCE(dtl.Approved,0) as bit),
        summary.WorksheetName
	FROM @view dtl
		INNER JOIN (
					SELECT
						Market = MAX([is].Market),
						Media = MAX([is].Media),
						VendorCode = MAX([is].VendorCode),
						VendorName = MAX([is].VendorName),
						OrderNumber = MAX([is].OrderNumber),
						FlightStart = MAX([is].FlightStart),
						FlightEnd = MAX([is].FlightEnd),
						MonthOfService = MAX([is].MonthOfService),
						ClientCode = MAX([is].ClientCode),
						ClientName = MAX([is].ClientName),
						DivisionCode = MAX([is].DivisionCode),
						DivisionName = MAX([is].DivisionName),
						ProductCode = MAX([is].ProductCode),
						ProductName = MAX([is].ProductName),
						InvoiceNumber = MAX([is].InvoiceNumber),
						Calendar = MAX([is].Calendar),
						ScheduleGross = MAX([is].ScheduleGross),
						ScheduleNet = MAX([is].ScheduleNet),
						InvoiceDate = MAX([is].InvoiceDate),
						[Status] = NULL, --this is by line number
                        WorksheetName = MAX([is].WorksheetName)
						--[is].InvoiceGross,
						--[is].InvoiceNet,
						--[is].YearMonth,
						--these need to be null as they come from order detail :(
						--od.WeekOf,
						--od.[Days],
						--Times = od.StartTime + '-' + od.EndTime,
						--od.NetworkID,
						--od.Program,
						--od.AdNumber,
						--DayPart = dp.DAY_PART_CODE,
						--od.[Length],
						--[Rate] = od.GrossRate,
						--GrossTotal = od.GrossRate * od.Spots,
						--od.Spots,
						--[ActualSpotsTotal] = od.ActualSpots,
						--Variance = od.ActualSpots - [od].Spots,
						--od.MatchedSpots,
						--od.VariantCodes
					FROM #InvDtlRptInvoiceSummary  [is]
						--INNER JOIN #orderdetail [od] ON [is].OrderNumber = [od].OrderNumber AND [is].OrderLineNumber = [od].OrderLineNumber
					GROUP BY [is].OrderNumber 
					) summary ON dtl.OrderNumber = summary.OrderNumber 
	WHERE dtl.OrderLineNumber IS NULL
    ORDER BY InvoiceNumber, OrderNumber, MonthOfService

    DROP TABLE #orderdetail 
	DROP TABLE #InvDtlRptInvoiceSummary 

END
GO