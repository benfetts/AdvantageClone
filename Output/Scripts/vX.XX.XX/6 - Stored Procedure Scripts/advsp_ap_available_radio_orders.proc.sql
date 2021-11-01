--force update
CREATE PROCEDURE [dbo].[advsp_ap_available_radio_orders] @vn_code varchar(6) = NULL, @office_code varchar(4) = NULL, 
			@cl_code varchar(6) = NULL, @div_code varchar(6) = NULL, @prd_code varchar(6) = NULL,
			@month varchar(3) = NULL, @year smallint = NULL, @batch_name varchar(50) = NULL,
			@source_code varchar(2) = NULL, @order_id int = NULL, @user_code varchar(100), @calendar_date smalldatetime = NULL
AS
-- 20160118 MJC do not allow QUOTEs to be selected
-- 20160721 MJC Apply office limits and CDP limits to Accounts Payable
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @EmployeeCode varchar(6),
			@HasCDPLimits bit,
			@HasOfficeLimits bit
	
	SET @HasCDPLimits = 0
	
	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@user_code)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@user_code)) > 0
		SET @HasCDPLimits = 1
	
	IF (SELECT COUNT(1) FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode) > 0
		SET @HasOfficeLimits = 1
	ELSE
		SET @HasOfficeLimits = 0

	DECLARE @BatchOrders TABLE (
		ORDER_NUMBER int NULL
	)
	
	IF @batch_name IS NOT NULL
		INSERT @BatchOrders 
		SELECT DISTINCT M.ORDER_NUMBER 
		FROM dbo.IMP_AP_HEADER H
			INNER JOIN dbo.IMP_AP_MEDIA M ON H.IMPORT_ID = M.IMPORT_ID 
		WHERE BATCH_NAME = @batch_name
		AND M.MEDIA_TYPE = 'R'

	DECLARE @MonthName TABLE (
		[MonthNumber] int NOT NULL,
		[MonthName] char(3) NOT NULL
		)

	insert @MonthName values (1, 'JAN')
	insert @MonthName values (2, 'FEB')
	insert @MonthName values (3, 'MAR')
	insert @MonthName values (4, 'APR')
	insert @MonthName values (5, 'MAY')
	insert @MonthName values (6, 'JUN')
	insert @MonthName values (7, 'JUL')
	insert @MonthName values (8, 'AUG')
	insert @MonthName values (9, 'SEP')
	insert @MonthName values (10, 'OCT')
	insert @MonthName values (11, 'NOV')
	insert @MonthName values (12, 'DEC')
	
	DECLARE @MonthYear TABLE (
		ORDER_NBR int NOT NULL,
		[MonthName] char(3) NOT NULL,
		[Year] smallint NOT NULL,
		[MonthNumber] smallint NOT NULL
		)
	
	INSERT @MonthYear (ORDER_NBR, [MonthName], [Year], [MonthNumber]) 
	SELECT DISTINCT A.ORDER_NBR, M.[MonthName], BRD_YEAR1, M.[MonthNumber] 
	FROM [dbo].RADIO_HEADER A
		INNER JOIN (SELECT MAX(REV_NBR) AS REV_NBR, ORDER_NBR
					FROM [dbo].RADIO_HEADER
					GROUP BY ORDER_NBR) AS C ON A.ORDER_NBR = C.ORDER_NBR AND A.REV_NBR = C.REV_NBR 
		CROSS JOIN @MonthName M
	WHERE M.MonthNumber between FIRST_MTH_YR1 and LAST_MTH_YR1 
	AND (@vn_code IS NULL OR A.VN_CODE = @vn_code)
	AND BRD_YEAR1 IS NOT NULL
	AND (@batch_name IS NULL OR (@batch_name IS NOT NULL AND A.ORDER_NBR IN (SELECT ORDER_NUMBER FROM @BatchOrders)))
	
	UNION

	SELECT A.ORDER_NBR, M.[MonthName], BRD_YEAR2, M.[MonthNumber] 
	FROM [dbo].RADIO_HEADER A
		INNER JOIN (SELECT MAX(REV_NBR) AS REV_NBR, ORDER_NBR
					FROM [dbo].RADIO_HEADER
					GROUP BY ORDER_NBR) AS C ON A.ORDER_NBR = C.ORDER_NBR AND A.REV_NBR = C.REV_NBR 
		CROSS JOIN @MonthName M
	WHERE M.MonthNumber between FIRST_MTH_YR2 and LAST_MTH_YR2 
	AND (@vn_code IS NULL OR A.VN_CODE = @vn_code)
	AND BRD_YEAR2 IS NOT NULL
	AND (@batch_name IS NULL OR (@batch_name IS NOT NULL AND A.ORDER_NBR IN (SELECT ORDER_NUMBER FROM @BatchOrders)))

	DECLARE @ORDERS TABLE (
		[ClientCode] varchar(6) NULL,
		[DivisionCode] varchar(6) NULL,
		[ProductCode] varchar(6) NULL,
		[OrderNumber] int NULL,
		[LineNumber] smallint NULL,
		[Month] char(3) NULL,
		[Year] smallint NULL,
		[StartDate] smalldatetime NULL,
		[EndDate] smalldatetime NULL,
		[Description] varchar(40) NULL,
		[LinkID] int NULL,
		[ClientPO] varchar(25) NULL,
		[MarketCode] varchar(10) NULL,
		[MonthNumber] smallint NULL,
		[IsOld] int NOT NULL,
		[VendorCode] varchar(6) NULL,
		[OfficeCode] varchar(4) NULL,
		[GrossRate] decimal(16,4) null,
		[Quantity] int NULL,
		[NetRate] decimal(16,4) null,
		[StartTime] varchar(10) NULL,
		[EndTime] varchar(10) NULL,
		[Monday] bit NOT NULL,
		[Tuesday] bit NOT NULL,
		[Wednesday] bit NOT NULL,
		[Thursday] bit NOT NULL,
		[Friday] bit NOT NULL,
		[Saturday] bit NOT NULL,
		[Sunday] bit NOT NULL,
		[Length] int NOT NULL
	)
	
	INSERT @ORDERS 
	SELECT DISTINCT
		[ClientCode] = A.CL_CODE,
		[DivisionCode] = A.DIV_CODE,
		[ProductCode] = A.PRD_CODE,
		[OrderNumber] = A.ORDER_NBR,
		[LineNumber] = NULL,
		[Month] = D.[MonthName],
		[Year] = D.[Year],
		[StartDate] = NULL,
		[EndDate] = NULL,
		[Description] = A.ORDER_DESC,
		[LinkID] = A.LINK_ID,
		[ClientPO] = A.CLIENT_PO,
		[MarketCode] = A.MARKET_CODE,
		[MonthNumber] = D.[MonthNumber],
		[IsOld] = 1,
		[VendorCode] = A.VN_CODE,
		[OfficeCode] = P.OFFICE_CODE,
		[GrossRate] = NULL,
		[Quantity] = NULL,
		[NetRate] = NULL,
		[StartTime] = NULL,
		[EndTime] = NULL,
		[Monday] = CAST(0 as bit),
		[Tuesday] = CAST(0 as bit),
		[Wednesday] = CAST(0 as bit),
		[Thursday] = CAST(0 as bit),
		[Friday] = CAST(0 as bit),
		[Saturday] = CAST(0 as bit),
		[Sunday] = CAST(0 as bit),
		[Length] = CAST(0 as int)
	FROM [dbo].RADIO_HEADER A
		INNER JOIN [dbo].VENDOR B ON A.VN_CODE = B.VN_CODE
		INNER JOIN [dbo].PRODUCT P ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE
		INNER JOIN (SELECT MAX(REV_NBR) AS REV_NBR, ORDER_NBR
					FROM [dbo].RADIO_HEADER
					GROUP BY ORDER_NBR) AS C ON A.ORDER_NBR = C.ORDER_NBR AND A.REV_NBR = C.REV_NBR 
		INNER JOIN @MonthYear D ON A.ORDER_NBR = D.ORDER_NBR
	WHERE
				MEDIA_TYPE IS NOT NULL
		AND  	(ORD_PROCESS_CONTRL != 6 AND RECONCILE_FLAG <> 1)
		--AND		A.BILL_TYPE_FLAG <> 1
		AND		(DELETE_FLAG IS NULL OR DELETE_FLAG=0)
		AND		(@office_code IS NULL OR P.OFFICE_CODE = @office_code)
		AND		(@vn_code IS NULL OR A.VN_CODE = @vn_code OR VN_PAY_TO_CODE= @vn_code)
		AND		(@cl_code IS NULL OR A.CL_CODE = @cl_code)
		AND		(@div_code IS NULL OR A.DIV_CODE = @div_code)
		AND		(@prd_code IS NULL OR A.PRD_CODE = @prd_code)
		AND		(@month IS NULL OR D.[MonthName] = @month)
		AND		(@year IS NULL OR D.[Year] = @year)
		AND		(@batch_name IS NULL OR (@batch_name IS NOT NULL AND A.ORDER_NBR IN (SELECT ORDER_NUMBER FROM @BatchOrders)))
		AND		(
					( @HasCDPLimits = 1 AND EXISTS (
													SELECT 1
													FROM dbo.SEC_CLIENT sc
													WHERE UPPER(sc.[USER_ID]) = UPPER(@user_code)
													AND sc.CL_CODE = A.CL_CODE
													AND sc.DIV_CODE = A.DIV_CODE
													AND sc.PRD_CODE = A.PRD_CODE)
													AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
												   )
					OR
					( @HasCDPLimits = 0 AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
				)
		AND
				(
					( @HasOfficeLimits = 1 AND B.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
				OR
					( @HasOfficeLimits = 0 )
				)

	UNION

	SELECT DISTINCT
		[ClientCode] = A.CL_CODE,
		[DivisionCode] = A.DIV_CODE,
		[ProductCode] = A.PRD_CODE,
		[OrderNumber] = A.ORDER_NBR,
		[LineNumber] = O.LINE_NBR,
		[Month] = UPPER(LEFT(DATENAME(m, str(O.MONTH_NBR) + '/1/2011'), 3)),
		[Year] = O.YEAR_NBR,
		[StartDate] = O.[START_DATE],
		[EndDate] = O.END_DATE,
		[Description] = A.ORDER_DESC,
		[LinkID] = A.LINK_ID,
		[ClientPO] = A.CLIENT_PO,
		[MarketCode] = A.MARKET_CODE,
		[MonthNumber] = O.MONTH_NBR,
		[IsOld] = 0,
		[VendorCode] = A.VN_CODE,
		[OfficeCode] = P.OFFICE_CODE,
		[GrossRate] = O.GROSS_RATE,
		[Quantity] = O.TOTAL_SPOTS,
		[NetRate] = O.NET_RATE,
		[StartTime] = O.START_TIME,
		[EndTime] = O.END_TIME,
		[Monday] = CAST(COALESCE(O.MONDAY, 0) as bit),
		[Tuesday] = CAST(COALESCE(O.TUESDAY, 0) as bit),
		[Wednesday] = CAST(COALESCE(O.WEDNESDAY, 0) as bit),
		[Thursday] = CAST(COALESCE(O.THURSDAY, 0) as bit),
		[Friday] = CAST(COALESCE(O.FRIDAY, 0) as bit),
		[Saturday] = CAST(COALESCE(O.SATURDAY, 0) as bit),
		[Sunday] = CAST(COALESCE(O.SUNDAY, 0) as bit),
		[Length] = CAST(COALESCE(O.[LENGTH], 0) as int)
	FROM
		[dbo].RADIO_HDR A
		INNER JOIN [dbo].VENDOR B ON A.VN_CODE = B.VN_CODE
		INNER JOIN [dbo].RADIO_DETAIL O ON A.ORDER_NBR = O.ORDER_NBR
		INNER JOIN [dbo].PRODUCT P ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE
	WHERE
				A.MEDIA_TYPE IS NOT NULL
		AND		COALESCE(A.[STATUS], 0) = 0 -- 20160118 MJC do not allow QUOTEs to be selected
		AND   	A.ORD_PROCESS_CONTRL NOT IN (5,6,12)
		AND		O.ACTIVE_REV = 1
		AND  	(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0)
		--AND		BILL_TYPE_FLAG <> 1
		AND		(@office_code IS NULL OR P.OFFICE_CODE = @office_code)
		AND		(@vn_code IS NULL OR A.VN_CODE = @vn_code OR B.VN_PAY_TO_CODE = @vn_code)
		AND		(@cl_code IS NULL OR P.CL_CODE = @cl_code)
		AND		(@div_code IS NULL OR P.DIV_CODE = @div_code)
		AND		(@prd_code IS NULL OR P.PRD_CODE = @prd_code)
		AND		(@month IS NULL OR UPPER(LEFT(DATENAME(m, str(O.MONTH_NBR) + '/1/2011'), 3)) = @month)
		AND		(@year IS NULL OR O.YEAR_NBR = @year)
		AND		(@batch_name IS NULL OR (@batch_name IS NOT NULL AND A.ORDER_NBR IN (SELECT ORDER_NUMBER FROM @BatchOrders)))
		AND		(
					( @HasCDPLimits = 1 AND EXISTS (
													SELECT 1
													FROM dbo.SEC_CLIENT sc
													WHERE UPPER(sc.[USER_ID]) = UPPER(@user_code)
													AND sc.CL_CODE = A.CL_CODE
													AND sc.DIV_CODE = A.DIV_CODE
													AND sc.PRD_CODE = A.PRD_CODE)
													AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
												   )
					OR
					( @HasCDPLimits = 0 AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
				)
		AND
				(
					( @HasOfficeLimits = 1 AND B.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
				OR
					( @HasOfficeLimits = 0 )
				)

	UNION

	SELECT DISTINCT
		[ClientCode] = A.CL_CODE,
		[DivisionCode] = A.DIV_CODE,
		[ProductCode] = A.PRD_CODE,
		[OrderNumber] = A.ORDER_NBR,
		[LineNumber] = O.LINE_NBR,
		[Month] = UPPER(LEFT(DATENAME(m, str(O.MONTH_NBR) + '/1/2011'), 3)),
		[Year] = O.YEAR_NBR,
		[StartDate] = O.[START_DATE],
		[EndDate] = O.END_DATE,
		[Description] = A.ORDER_DESC,
		[LinkID] = A.LINK_ID,
		[ClientPO] = A.CLIENT_PO,
		[MarketCode] = A.MARKET_CODE,
		[MonthNumber] = O.MONTH_NBR,
		[IsOld] = 0,
		[VendorCode] = A.VN_CODE,
		[OfficeCode] = P.OFFICE_CODE,
		[GrossRate] = O.GROSS_RATE,
		[Quantity] = O.TOTAL_SPOTS,
		[NetRate] = O.NET_RATE,
		[StartTime] = O.START_TIME,
		[EndTime] = O.END_TIME,
		[Monday] = CAST(COALESCE(O.MONDAY, 0) as bit),
		[Tuesday] = CAST(COALESCE(O.TUESDAY, 0) as bit),
		[Wednesday] = CAST(COALESCE(O.WEDNESDAY, 0) as bit),
		[Thursday] = CAST(COALESCE(O.THURSDAY, 0) as bit),
		[Friday] = CAST(COALESCE(O.FRIDAY, 0) as bit),
		[Saturday] = CAST(COALESCE(O.SATURDAY, 0) as bit),
		[Sunday] = CAST(COALESCE(O.SUNDAY, 0) as bit),
		[Length] = CAST(COALESCE(O.[LENGTH], 0) as int)
	FROM
		[dbo].RADIO_HDR A
		INNER JOIN [dbo].VENDOR B ON A.VN_CODE = B.VN_CODE
		INNER JOIN [dbo].RADIO_DETAIL O ON A.ORDER_NBR = O.ORDER_NBR
		INNER JOIN [dbo].PRODUCT P ON A.CL_CODE = P.CL_CODE AND A.DIV_CODE = P.DIV_CODE AND A.PRD_CODE = P.PRD_CODE
	WHERE
				A.MEDIA_TYPE IS NOT NULL
		AND		COALESCE(A.[STATUS], 0) = 0 -- 20160118 MJC do not allow QUOTEs to be selected
		AND   	A.ORD_PROCESS_CONTRL NOT IN (5,6,12)
		AND		O.ACTIVE_REV = 1
		AND  	(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0)
		--AND		BILL_TYPE_FLAG <> 1
		AND		(@office_code IS NULL OR P.OFFICE_CODE = @office_code)
		AND		(@vn_code IS NULL OR A.VN_CODE = @vn_code OR B.VN_PAY_TO_CODE = @vn_code)
		AND		(@cl_code IS NULL OR P.CL_CODE = @cl_code)
		AND		(@div_code IS NULL OR P.DIV_CODE = @div_code)
		AND		(@prd_code IS NULL OR P.PRD_CODE = @prd_code)
		AND		(@calendar_date IS NOT NULL AND (O.BUY_TYPE = 'CM' AND month(@calendar_date) = O.MONTH_NBR AND year(@calendar_date) = O.YEAR_NBR))
		AND		(@batch_name IS NULL OR (@batch_name IS NOT NULL AND A.ORDER_NBR IN (SELECT ORDER_NUMBER FROM @BatchOrders)))
		AND		(
					( @HasCDPLimits = 1 AND EXISTS (
													SELECT 1
													FROM dbo.SEC_CLIENT sc
													WHERE UPPER(sc.[USER_ID]) = UPPER(@user_code)
													AND sc.CL_CODE = A.CL_CODE
													AND sc.DIV_CODE = A.DIV_CODE
													AND sc.PRD_CODE = A.PRD_CODE)
													AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
												   )
					OR
					( @HasCDPLimits = 0 AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
				)
		AND
				(
					( @HasOfficeLimits = 1 AND B.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
				OR
					( @HasOfficeLimits = 0 )
				)

	IF @order_id IS NOT NULL AND @source_code IS NOT NULL
		SELECT O.*
		FROM @ORDERS O
			INNER JOIN dbo.BRD_IMPORT_XREF BIX ON O.OrderNumber = BIX.ORDER_NBR AND BIX.IMPORT_ORDER_NBR = @order_id
													AND O.LineNumber = BIX.LINE_NBR AND BIX.IMPORTED_FROM = @source_code
													AND BIX.MEDIA_TYPE IN ('RA','R')
		ORDER BY
			[OrderNumber], [Year], MonthNumber
	ELSE
		SELECT O.*
		FROM @ORDERS O
		ORDER BY
			[OrderNumber], [Year], MonthNumber
		
END


