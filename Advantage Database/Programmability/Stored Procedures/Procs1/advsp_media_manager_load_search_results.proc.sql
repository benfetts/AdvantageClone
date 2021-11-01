CREATE PROCEDURE [dbo].[advsp_media_manager_load_search_results]
	@user_id varchar(100), @select_by smallint,
	@newspaper bit, @magazine bit, @internet bit, @out_of_home bit,	@radio bit, @television bit,
	@include_order bit, @include_quote bit, @include_closed_orders bit,
	@order_line_start_date smalldatetime, @order_line_end_date smalldatetime,
	@job_media_start_date smalldatetime, @job_media_end_date smalldatetime,
	@media_month_start_date int, @media_month_end_date int, --YYYYMM format
	@filter_by smallint, @po bit
AS

SET NOCOUNT ON

DECLARE @EmployeeCode varchar(6),
		@HasCDPLimits bit,
		@include_order_line_dates bit,
		@include_job_media_date_to_bill bit,
		@include_media_month bit,
		@LimitedByOffice bit

SET @include_order_line_dates = 0
SET @include_job_media_date_to_bill = 0
SET @include_media_month = 0

IF @filter_by = 1
	SET @include_order_line_dates = 1
ELSE IF @filter_by = 2 
	SET @include_job_media_date_to_bill = 1
ELSE IF @filter_by = 3
	SET @include_media_month = 1

SET @HasCDPLimits = 0

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@user_id)

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@user_id)) > 0
	SET @HasCDPLimits = 1

SET @LimitedByOffice = 0

IF EXISTS (SELECT * FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode)
	SET @LimitedByOffice = 1

DECLARE @selection TABLE (
	selection_id		int identity( 1, 1 ) NOT NULL,
	ORDER_NBR			int NOT NULL,
	LINE_NBR			int NULL,
	BRDCAST_YEAR		int NULL,
	BRDCAST_MONTH		int NULL,
	CMP_IDENTIFIER		int NULL,
	CL_CODE				varchar(6) NULL,
	DIV_CODE			varchar(6) NULL,
	PRD_CODE			varchar(6) NULL,
	ORDER_DESC			varchar(40) NULL,
	MEDIA_FROM			varchar(11) NULL,
	JOB_NUMBER			int NULL,
	JOB_COMPONENT_NBR	smallint NULL,
	IsSelected			smallint,
	VN_CODE				varchar(6) NULL,
	BUYER_EMP_CODE		varchar(6) NULL,
	DISPLAY_PO_NUMBER	varchar(12) NULL
)

DECLARE @LoadLockedOrders bit

SELECT @LoadLockedOrders = Custom1
FROM dbo.V_SEC_PERMISSION
WHERE ApplicationID = (SELECT SEC_APPLICATION_ID FROM dbo.SEC_APPLICATION WHERE NAME = 'Advantage')
AND UserID = (SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE UPPER(USER_CODE) = UPPER(@user_id))
AND ModuleCode = 'Media_MediaManager'

-- Magazine *********************************************************************************************************************************************
IF ( @magazine = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, JOB_NUMBER, JOB_COMPONENT_NBR, IsSelected, VN_CODE, BUYER_EMP_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Magazine', d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		CASE WHEN h.LOCKED_BY IS NOT NULL THEN 1 ELSE 0 END, h.VN_CODE, h.BUYER_EMP_CODE
	FROM dbo.MAGAZINE_HEADER h
		INNER JOIN dbo.MAGAZINE_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @include_order = 1 
		OR
			h.[STATUS] = 1 AND @include_quote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @include_closed_orders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @include_closed_orders = 1)
		)
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id OR @LoadLockedOrders = 1)
	AND
		((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( d.[START_DATE] BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @job_media_start_date AND @job_media_end_date ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.[START_DATE]) as varchar(4)) + right('0'+ CAST(MONTH(d.[START_DATE]) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@user_id)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
END

-- Newspaper *********************************************************************************************************************************************
IF ( @newspaper = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, JOB_NUMBER, JOB_COMPONENT_NBR, IsSelected, VN_CODE, BUYER_EMP_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Newspaper', d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		CASE WHEN h.LOCKED_BY IS NOT NULL THEN 1 ELSE 0 END, h.VN_CODE, h.BUYER_EMP_CODE
	FROM dbo.NEWSPAPER_HEADER h
		INNER JOIN dbo.NEWSPAPER_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @include_order = 1 
		OR
			h.[STATUS] = 1 AND @include_quote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @include_closed_orders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @include_closed_orders = 1)
		)
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id OR @LoadLockedOrders = 1)
	AND ((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( d.[START_DATE] BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @job_media_start_date AND @job_media_end_date ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.[START_DATE]) as varchar(4)) + right('0'+ CAST(MONTH(d.[START_DATE]) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@user_id)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
END

-- Out of home *********************************************************************************************************************************************
IF ( @out_of_home = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, JOB_NUMBER, JOB_COMPONENT_NBR, IsSelected, VN_CODE, BUYER_EMP_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Out of Home', d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		CASE WHEN h.LOCKED_BY IS NOT NULL THEN 1 ELSE 0 END, h.VN_CODE, h.BUYER_EMP_CODE
	FROM dbo.OUTDOOR_HEADER h
		INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @include_order = 1 
		OR
			h.[STATUS] = 1 AND @include_quote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @include_closed_orders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @include_closed_orders = 1)
		)
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id OR @LoadLockedOrders = 1)
	AND ((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( d.POST_DATE BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @job_media_start_date AND @job_media_end_date ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.POST_DATE) as varchar(4)) + right('0'+ CAST(MONTH(d.POST_DATE) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@user_id)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
END

-- Internet *********************************************************************************************************************************************
IF ( @internet = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, JOB_NUMBER, JOB_COMPONENT_NBR, IsSelected, VN_CODE, BUYER_EMP_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Internet', d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		CASE WHEN h.LOCKED_BY IS NOT NULL THEN 1 ELSE 0 END, h.VN_CODE, h.BUYER_EMP_CODE
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @include_order = 1 
		OR
			h.[STATUS] = 1 AND @include_quote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @include_closed_orders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @include_closed_orders = 1)
		)
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id OR @LoadLockedOrders = 1)
	AND ((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( d.[START_DATE] BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @job_media_start_date AND @job_media_end_date ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.[START_DATE]) as varchar(4)) + right('0'+ CAST(MONTH(d.[START_DATE]) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@user_id)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
END

-- Radio *********************************************************************************************************************************************
IF ( @radio = 1 )
BEGIN
	-- Radio (New)
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, JOB_NUMBER, JOB_COMPONENT_NBR, IsSelected, VN_CODE, BUYER_EMP_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Radio', d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		CASE WHEN h.LOCKED_BY IS NOT NULL THEN 1 ELSE 0 END, h.VN_CODE, h.BUYER_EMP_CODE
	FROM dbo.RADIO_HDR h
		INNER JOIN dbo.RADIO_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @include_order = 1 
		OR
			h.[STATUS] = 1 AND @include_quote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @include_closed_orders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @include_closed_orders = 1)
		)
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id OR @LoadLockedOrders = 1)
	AND ((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( d.[START_DATE] BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @job_media_start_date AND @job_media_end_date ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(d.[YEAR_NBR] as varchar(4)) + right('0'+ CAST(d.[MONTH_NBR] as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@user_id)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
END

-- Television *********************************************************************************************************************************************
IF ( @television = 1 )
BEGIN
	-- TV (New)
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, JOB_NUMBER, JOB_COMPONENT_NBR, IsSelected, VN_CODE, BUYER_EMP_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'TV', d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		CASE WHEN h.LOCKED_BY IS NOT NULL THEN 1 ELSE 0 END, h.VN_CODE, h.BUYER_EMP_CODE
	FROM dbo.TV_HDR h
		INNER JOIN dbo.TV_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
	WHERE
		(
			COALESCE(h.[STATUS], 0) = 0 AND @include_order = 1 
		OR
			h.[STATUS] = 1 AND @include_quote = 1
		)
	AND (
		(h.ORD_PROCESS_CONTRL = 1 AND @include_closed_orders = 0)
		OR
		(h.ORD_PROCESS_CONTRL IN ( 1, 6) AND @include_closed_orders = 1)
		)
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id OR @LoadLockedOrders = 1)
	AND ((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( d.[START_DATE] BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) between @job_media_start_date AND @job_media_end_date ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(d.[YEAR_NBR] as varchar(4)) + right('0'+ CAST(d.[MONTH_NBR] as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND
		(
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = UPPER(@user_id)
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
		OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
END

-- PO *********************************************************************************************************************************************
IF ( @po = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, JOB_NUMBER, JOB_COMPONENT_NBR, IsSelected, VN_CODE, BUYER_EMP_CODE, DISPLAY_PO_NUMBER )
	SELECT DISTINCT h.PO_NUMBER, NULL, jl.CMP_IDENTIFIER, jl.CL_CODE, jl.DIV_CODE, jl.PRD_CODE, h.PO_DESCRIPTION, 'PO', d.JOB_NUMBER, d.JOB_COMPONENT_NBR,
		CASE WHEN h.LOCK_USER IS NOT NULL THEN 1 ELSE 0 END, h.VN_CODE, h.EMP_CODE,
			CASE
			WHEN h.PO_APPROVAL_FLAG IS NOT NULL THEN
				CASE
					WHEN h.PO_APPROVAL_FLAG = 0 OR h.PO_APPROVAL_FLAG IS NULL THEN '(Pending)'
					WHEN h.PO_APPROVAL_FLAG = 1 THEN '(Pending)'
					WHEN h.PO_APPROVAL_FLAG = 2 THEN CONVERT(VARCHAR(12), h.PO_NUMBER)
					WHEN h.PO_APPROVAL_FLAG = 3 THEN '(Denied)'
					ELSE CONVERT(VARCHAR(12), h.PO_NUMBER)
				END 
			ELSE
				CASE
					WHEN h.PO_APPR_RULE_CODE IS NULL OR h.PO_APPR_RULE_CODE = '' OR EMPLOYEE.PO_LIMIT IS NULL THEN CONVERT(VARCHAR(12), h.PO_NUMBER)
					WHEN h.EXCEED = 0 AND (h.PO_PRINTED = 0 OR h.PO_PRINTED IS NULL) THEN '(Incomplete)'
					WHEN h.EXCEED = 0 AND h.PO_PRINTED = 1 THEN CONVERT(VARCHAR(12), h.PO_NUMBER)
					WHEN h.EXCEED = 1 THEN '(Incomplete)'
					ELSE CONVERT(VARCHAR(12), h.PO_NUMBER)
				END
			END
	FROM dbo.PURCHASE_ORDER h
		INNER JOIN dbo.PURCHASE_ORDER_DET d ON h.PO_NUMBER = d.PO_NUMBER AND @include_order = 1 
		INNER JOIN dbo.VENDOR v ON h.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER 
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		INNER JOIN dbo.EMPLOYEE ON EMPLOYEE.EMP_CODE = h.EMP_CODE
		LEFT OUTER JOIN
			(SELECT
				DISTINCT
				PO_NUMBER
			FROM
				dbo.PURCHASE_ORDER_DET) PURCHASE_ORDER_DET ON h.PO_NUMBER = PURCHASE_ORDER_DET.PO_NUMBER
	WHERE
		COALESCE(h.VOID_FLAG, 0) = 0
	AND	(h.PO_COMPLETE IS NULL OR h.PO_COMPLETE = 0)
	AND	(h.LOCK_USER IS NULL OR h.LOCK_USER = @user_id OR @LoadLockedOrders = 1)
	AND ((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( h.PO_DATE BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( jc.MEDIA_BILL_DATE between @job_media_start_date AND @job_media_end_date ) )
		)
		AND
		(
			( @include_media_month = 0 )
		OR
			( @include_media_month = 1 AND (CAST(CAST(YEAR(COALESCE(h.PO_DATE, '1/1/1900')) as varchar(4)) + right('0'+ CAST(MONTH(COALESCE(h.PO_DATE, '1/1/1900')) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND
		(
			( @LimitedByOffice = 0 )
		OR
			( @LimitedByOffice = 1 AND v.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
END

IF @select_by = 0  -- AllOpenOrders = 0

	SELECT
		[IsSelected] = CAST(IsSelected AS bit),
		[OrderNumber] = s.ORDER_NBR,
		[OrderDescription] = s.ORDER_DESC,
		[LineNumber] = s.LINE_NBR,
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[VendorCode] = s.VN_CODE,
		[VendorName] = V.VN_NAME
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
		INNER JOIN dbo.VENDOR V ON s.VN_CODE = V.VN_CODE
	ORDER BY s.ORDER_NBR DESC, s.LINE_NBR
	OPTION (RECOMPILE)

ELSE IF @select_by = 1  --Client = 1

	SELECT
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
	GROUP BY s.CL_CODE, C.CL_NAME 
	ORDER BY s.CL_CODE, C.CL_NAME 
	OPTION (RECOMPILE)

ELSE IF @select_by = 2  --ClientDivision = 2

	SELECT
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
	GROUP BY s.CL_CODE, C.CL_NAME, s.DIV_CODE, D.DIV_NAME
	ORDER BY s.CL_CODE, s.DIV_CODE, D.DIV_NAME
	OPTION (RECOMPILE)

ELSE IF @select_by = 3  --ClientDivisionProduct = 3

	SELECT
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
	GROUP BY s.CL_CODE, C.CL_NAME, s.DIV_CODE, D.DIV_NAME, s.PRD_CODE, P.PRD_DESCRIPTION
	ORDER BY s.CL_CODE, s.DIV_CODE, s.PRD_CODE, P.PRD_DESCRIPTION
	OPTION (RECOMPILE)

ELSE IF @select_by = 4  --Campaign = 4

	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[ClientCode] = CMP.CL_CODE,
		[ClientName] = C.CL_NAME,
        [DivisionCode] = CMP.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = CMP.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
        [CampaignID] = s.CMP_IDENTIFIER,
        [CampaignCode] = CMP.CMP_CODE,
        [CampaignName] = CMP.CMP_NAME
	FROM @selection s
		INNER JOIN dbo.CAMPAIGN CMP ON s.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
		INNER JOIN dbo.CLIENT C ON CMP.CL_CODE = C.CL_CODE
		LEFT OUTER JOIN dbo.DIVISION D ON CMP.CL_CODE = D.CL_CODE AND CMP.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON CMP.CL_CODE = P.CL_CODE AND CMP.DIV_CODE = P.DIV_CODE AND CMP.PRD_CODE = P.PRD_CODE
	GROUP BY CMP.CL_CODE, C.CL_NAME, CMP.DIV_CODE, D.DIV_NAME, CMP.PRD_CODE, P.PRD_DESCRIPTION, s.CMP_IDENTIFIER, CMP.CMP_CODE, CMP.CMP_NAME
	ORDER BY CMP.CL_CODE, CMP.DIV_CODE, CMP.PRD_CODE, CMP.CMP_CODE
	OPTION (RECOMPILE)

ELSE IF @select_by = 5  --Job = 5
	
	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.JOB_LOG JL ON s.JOB_NUMBER = JL.JOB_NUMBER
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
	GROUP BY s.CL_CODE, C.CL_NAME, s.DIV_CODE, D.DIV_NAME, s.PRD_CODE, P.PRD_DESCRIPTION, s.JOB_NUMBER, JL.JOB_DESC
	ORDER BY s.JOB_NUMBER DESC 
	OPTION (RECOMPILE)

ELSE IF @select_by = 6  --JobComponent = 6
    
	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC,
		[JobComponentNumber] = s.JOB_COMPONENT_NBR,
		[JobComponentDescription] = JC.JOB_COMP_DESC
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.JOB_LOG JL ON s.JOB_NUMBER = JL.JOB_NUMBER 
		INNER JOIN dbo.JOB_COMPONENT JC ON s.JOB_NUMBER = JC.JOB_NUMBER AND s.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
	GROUP BY s.CL_CODE, C.CL_NAME, s.DIV_CODE, D.DIV_NAME, s.PRD_CODE, P.PRD_DESCRIPTION, s.JOB_NUMBER, JL.JOB_DESC, s.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC
	ORDER BY s.JOB_NUMBER DESC, s.JOB_COMPONENT_NBR
	OPTION (RECOMPILE)

ELSE IF @select_by = 7  --Order = 7

	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[OrderNumber] = s.ORDER_NBR,
		[OrderDescription] = s.ORDER_DESC,
		[MediaFrom] = s.MEDIA_FROM,
		[VendorCode] = s.VN_CODE,
		[VendorName] = V.VN_NAME,
		[DisplayPONumber] = s.DISPLAY_PO_NUMBER
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
		INNER JOIN dbo.VENDOR V ON s.VN_CODE = V.VN_CODE
	GROUP BY s.CL_CODE, C.CL_NAME, s.DIV_CODE, D.DIV_NAME, s.PRD_CODE, P.PRD_DESCRIPTION, s.ORDER_NBR, s.ORDER_DESC, s.MEDIA_FROM, s.VN_CODE, V.VN_NAME, s.DISPLAY_PO_NUMBER
	ORDER BY s.ORDER_NBR DESC 
	OPTION (RECOMPILE)

ELSE IF @select_by = 8  --Buyer = 8

	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[EmployeeCode] = E.EMP_CODE,
        [Buyer] = E.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(E.EMP_MI, '') + ' ') + E.EMP_LNAME
	FROM @selection s
		INNER JOIN dbo.EMPLOYEE E ON s.BUYER_EMP_CODE = E.EMP_CODE 
	GROUP BY E.EMP_CODE, E.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(E.EMP_MI, '') + ' ') + E.EMP_LNAME
	ORDER BY 3
	OPTION (RECOMPILE)

ELSE IF @select_by = 9  --AccountExecutiveDefault = 9

	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[EmployeeCode] = AE.EMP_CODE,
        [AccountExecutive] = AE.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(AE.EMP_MI, '') + ' ') + AE.EMP_LNAME
	FROM @selection s
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
		INNER JOIN (
					SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
					FROM dbo.ACCOUNT_EXECUTIVE AE
						INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
					WHERE AE.DEFAULT_AE = 1
					AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
					) AE ON s.CL_CODE = AE.CL_CODE AND s.DIV_CODE = AE.DIV_CODE AND s.PRD_CODE = AE.PRD_CODE 
	GROUP BY AE.EMP_CODE, AE.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(AE.EMP_MI, '') + ' ') + AE.EMP_LNAME
	ORDER BY 3
	OPTION (RECOMPILE)

ELSE IF @select_by = 10  --AccountExecutiveJob = 10
   
	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[EmployeeCode] = JC.EMP_CODE,
        [AccountExecutive] = EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME
	FROM @selection s
		INNER JOIN dbo.JOB_COMPONENT JC ON s.JOB_NUMBER = JC.JOB_NUMBER AND s.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		INNER JOIN dbo.EMPLOYEE_CLOAK EC ON JC.EMP_CODE = EC.EMP_CODE 
	GROUP BY JC.EMP_CODE,EC.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(EC.EMP_MI, '') + ' ') + EC.EMP_LNAME
	ORDER BY 3
	OPTION (RECOMPILE)

ELSE IF @select_by = 11  --OrderStatus = 11
	
	BEGIN
		DECLARE @OrderStatus TABLE (
			IsSelected smallint NOT NULL,
			OrderStatusDescription varchar(100) NOT NULL,
			OrderStatus smallint NOT NULL
		)

		INSERT @OrderStatus
		SELECT DISTINCT
			[IsSelected] = s.IsSelected,
			[OrderStatusDescription] = OS.STATUS_DESC,
			[OrderStatus] = o.[STATUS]
		FROM @selection s
			LEFT OUTER JOIN (
							SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.INTERNET_ORDER_STATUS 
							UNION
							SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.MAGAZINE_ORDER_STATUS 
							UNION
							SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.NEWSPAPER_ORDER_STATUS 
							UNION
							SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.OUTDOOR_ORDER_STATUS 
							UNION
							SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.RADIO_ORDER_STATUS 
							UNION
							SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.TV_ORDER_STATUS 
							) o ON s.ORDER_NBR = o.ORDER_NBR AND s.LINE_NBR = o.LINE_NBR
			INNER JOIN dbo.ORDER_STATUS OS ON o.[STATUS] = OS.[STATUS]
		WHERE
			o.[STATUS] <> 0 
		OPTION (RECOMPILE)

		INSERT @OrderStatus 
		SELECT 0, STATUS_DESC, [STATUS]
		FROM dbo.ORDER_STATUS 
		WHERE [STATUS] NOT IN (SELECT OrderStatus FROM @OrderStatus)
		AND [STATUS] <> 0 

		SELECT
			IsSelected = CAST(MAX(IsSelected) AS bit),
			OrderStatusDescription,
			OrderStatus
		FROM @OrderStatus
		GROUP BY OrderStatusDescription, OrderStatus
		ORDER BY OrderStatus
	END

ELSE IF @select_by = 12  --Vendor = 12
   
	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[VendorCode] = s.VN_CODE,
		[VendorName] = V.VN_NAME
	FROM @selection s
		INNER JOIN dbo.VENDOR V ON s.VN_CODE = V.VN_CODE
	GROUP BY s.VN_CODE, V.VN_NAME
	ORDER BY s.VN_CODE, V.VN_NAME
	OPTION (RECOMPILE)
	
ELSE IF @select_by = 13  --VCC Last Four = 13
   
	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[MediaFrom] = s.MEDIA_FROM,
		[VendorCode] = s.VN_CODE,
		[VendorName] = V.VN_NAME,
		[OrderNumber] = s.ORDER_NBR,
		[LineNumber] = s.LINE_NBR,
		[VCCCardNumber] = C.CARD_NUMBER,
		[DisplayPONumber] = s.DISPLAY_PO_NUMBER
	FROM @selection s
		INNER JOIN dbo.VENDOR V ON s.VN_CODE = V.VN_CODE
		INNER JOIN dbo.VCC_CARD C ON s.ORDER_NBR =  C.ORDER_NBR AND s.LINE_NBR = C.LINE_NBR AND s.MEDIA_FROM <> 'PO'
	GROUP BY s.MEDIA_FROM, s.VN_CODE, V.VN_NAME, s.ORDER_NBR, s.LINE_NBR, C.CARD_NUMBER, s.DISPLAY_PO_NUMBER

	UNION

	SELECT 
		[IsSelected] = CAST(MAX(IsSelected) AS bit),
		[MediaFrom] = s.MEDIA_FROM,
		[VendorCode] = s.VN_CODE,
		[VendorName] = V.VN_NAME,
		[OrderNumber] = s.ORDER_NBR,
		[LineNumber] = s.LINE_NBR,
		[VCCCardNumber] = CPO.CARD_NUMBER,
		[DisplayPONumber] = s.DISPLAY_PO_NUMBER
	FROM @selection s
		INNER JOIN dbo.VENDOR V ON s.VN_CODE = V.VN_CODE
		INNER JOIN dbo.VCC_CARD_PO CPO ON s.ORDER_NBR = CPO.PO_NUMBER AND s.MEDIA_FROM = 'PO'
	GROUP BY s.MEDIA_FROM, s.VN_CODE, V.VN_NAME, s.ORDER_NBR, s.LINE_NBR, CPO.CARD_NUMBER, s.DISPLAY_PO_NUMBER
	ORDER BY 2, 3, 4, 5, 6, 7

	OPTION (RECOMPILE)

GO
