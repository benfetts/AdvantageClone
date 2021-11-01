CREATE PROCEDURE [dbo].[advsp_media_manager_save_selections]
	@user_id varchar(100),
	@order_numbers_in_list varchar(max),
	@cmp_id_in_list varchar(max), @cl_code_in_list varchar(max), @cl_div_code_in_list varchar(max), @cl_div_prd_code_in_list varchar(max),
	@job_numbers_in_list varchar(max), @job_numbers_components_in_list varchar(max),
	@ae_emp_codes_executive_in_list varchar(max),
	@ae_emp_codes_executive_jobs_in_list varchar(max),
	@order_status_in_list varchar(max),
	@vendor_code_in_list varchar(max),
	@buyer_emp_codes_in_list varchar(max)
AS

SET NOCOUNT ON

DECLARE @select_by smallint,
		@newspaper bit, @magazine bit, @internet bit, @out_of_home bit,	@radio bit, @television bit, @po bit,
		@include_order bit, @include_quote bit, @include_closed_orders bit,
		@include_order_line_dates bit, @order_line_start_date smalldatetime, @order_line_end_date smalldatetime,
		@include_job_media_date_to_bill bit, @job_media_start_date smalldatetime, @job_media_end_date smalldatetime,
		@include_media_month bit,
		@media_month_start_date int, @media_month_end_date int --YYYYMM format

SELECT @select_by = SELECT_BY,
		@newspaper = SELECT_NEWSPAPER, @magazine = SELECT_MAGAZINE, @internet = SELECT_INTERNET, @out_of_home = SELECT_OUTOFHOME, @radio = SELECT_RADIO, @television = SELECT_TV,
		@include_order = CASE WHEN INCLUDE_ORDER_QUOTE_BOTH IN (1,3) THEN 1 ELSE 0 END,
		@include_quote = CASE WHEN INCLUDE_ORDER_QUOTE_BOTH IN (2,3) THEN 1 ELSE 0 END,
		@include_order_line_dates = CASE WHEN FILTER_BY = 1 THEN 1 ELSE 0 END,
		@order_line_start_date = ORDER_LINE_START_DATE, @order_line_end_date = ORDER_LINE_END_DATE,
		@include_job_media_date_to_bill = CASE WHEN FILTER_BY = 2 THEN 1 ELSE 0 END,
		@job_media_start_date = JOB_MEDIA_START_DATE, @job_media_end_date = JOB_MEDIA_END_DATE,
		@include_closed_orders = INCLUDE_CLOSED_ORDERS,
		@include_media_month = CASE WHEN FILTER_BY = 3 THEN 1 ELSE 0 END,
		@media_month_start_date = CASE WHEN FILTER_BY = 3 THEN CAST(YEAR(MEDIA_MONTH_START) as varchar(4)) + RIGHT('0' + CAST(MONTH(MEDIA_MONTH_START) as varchar),2) ELSE NULL END,
		@media_month_end_date = CASE WHEN FILTER_BY = 3 THEN CAST(YEAR(MEDIA_MONTH_END) as varchar(4)) + RIGHT('0' + CAST(MONTH(MEDIA_MONTH_END) as varchar),2) ELSE NULL END,
		@po = SELECT_PO
FROM dbo.MEDIA_MGR_SEARCH_SETTING 
WHERE UPPER(MEDIA_MGR_SEARCH_SETTING_USER_CODE) = UPPER(@user_id)

--DECLARE @selection TABLE (
--	selection_id		int identity( 1, 1 ) NOT NULL,
--	ORDER_NBR			int NOT NULL,
--	LINE_NBR			int NOT NULL
--)

-- Magazine *********************************************************************************************************************************************
IF ( @magazine = 1 )
BEGIN
	UPDATE h SET LOCKED_BY = @user_id 
	FROM dbo.MAGAZINE_HEADER h
		INNER JOIN dbo.MAGAZINE_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON jc.EMP_CODE = ec.EMP_CODE 
		LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) ae ON p.CL_CODE = ae.CL_CODE AND p.DIV_CODE = ae.DIV_CODE AND p.PRD_CODE = ae.PRD_CODE
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.MAGAZINE_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, [STATUS] = 0 FROM dbo.MAGAZINE_DETAIL WHERE @order_status_in_list <> '0'
						) o ON d.ORDER_NBR = o.ORDER_NBR AND d.LINE_NBR = o.LINE_NBR AND @order_status_in_list IS NOT NULL
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
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id)
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
	AND (
		(@select_by = 7 AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_numbers_in_list, ',')))
		OR
		(@select_by = 4 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')))
		OR
		(@select_by = 1 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')))
		OR
		(@select_by = 2 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')))
		OR
		(@select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')))
		OR
		(@select_by = 5 AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_numbers_in_list, ',')))
		OR
		(@select_by = 6 AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS VARCHAR(20)) IN (SELECT * FROM dbo.udf_split_list(@job_numbers_components_in_list, ',')))
		OR
		(@select_by = 0)
		OR
		(@select_by = 9 AND ae.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_in_list, ',')))
		OR
		(@select_by = 10 AND ec.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_jobs_in_list, ',')))
		OR
		(@select_by = 11 AND
							(
								(@order_status_in_list <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@order_status_in_list, ',')))
								OR
								(@order_status_in_list = '0' AND o.[STATUS] IS NULL)
								)
							)
		OR
		(@select_by = 12 AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@vendor_code_in_list, ',')))
		OR
		(@select_by = 8 AND h.BUYER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@buyer_emp_codes_in_list, ',')))
		)
END

-- Newspaper *********************************************************************************************************************************************
IF ( @newspaper = 1 )
BEGIN
	UPDATE h SET LOCKED_BY = @user_id 
	FROM dbo.NEWSPAPER_HEADER h
		INNER JOIN dbo.NEWSPAPER_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON jc.EMP_CODE = ec.EMP_CODE 
		LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) ae ON p.CL_CODE = ae.CL_CODE AND p.DIV_CODE = ae.DIV_CODE AND p.PRD_CODE = ae.PRD_CODE
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.NEWSPAPER_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, [STATUS] = 0 FROM dbo.NEWSPAPER_DETAIL WHERE @order_status_in_list <> '0'
						) o ON d.ORDER_NBR = o.ORDER_NBR AND d.LINE_NBR = o.LINE_NBR AND @order_status_in_list IS NOT NULL
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
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id)
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
	AND (
		(@select_by = 7 AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_numbers_in_list, ',')))
		OR
		(@select_by = 4 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')))
		OR
		(@select_by = 1 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')))
		OR
		(@select_by = 2 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')))
		OR
		(@select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')))
		OR
		(@select_by = 5 AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_numbers_in_list, ',')))
		OR
		(@select_by = 6 AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS VARCHAR(20)) IN (SELECT * FROM dbo.udf_split_list(@job_numbers_components_in_list, ',')))
		OR
		(@select_by = 0)
		OR
		(@select_by = 9 AND ae.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_in_list, ',')))
		OR
		(@select_by = 10 AND ec.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_jobs_in_list, ',')))
		OR
		(@select_by = 11 AND
							(
								(@order_status_in_list <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@order_status_in_list, ',')))
								OR
								(@order_status_in_list = '0' AND o.[STATUS] IS NULL)
								)
							)
		OR
		(@select_by = 12 AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@vendor_code_in_list, ',')))
		OR
		(@select_by = 8 AND h.BUYER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@buyer_emp_codes_in_list, ',')))
		)
END

-- Out of home *********************************************************************************************************************************************
IF ( @out_of_home = 1 )
BEGIN
	UPDATE h SET LOCKED_BY = @user_id 
	FROM dbo.OUTDOOR_HEADER h
		INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON jc.EMP_CODE = ec.EMP_CODE 
		LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) ae ON p.CL_CODE = ae.CL_CODE AND p.DIV_CODE = ae.DIV_CODE AND p.PRD_CODE = ae.PRD_CODE
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.OUTDOOR_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, [STATUS] = 0 FROM dbo.OUTDOOR_DETAIL WHERE @order_status_in_list <> '0'
						) o ON d.ORDER_NBR = o.ORDER_NBR AND d.LINE_NBR = o.LINE_NBR AND @order_status_in_list IS NOT NULL
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
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id)
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
			( @include_media_month = 1 AND (CAST(CAST(YEAR(d.[POST_DATE]) as varchar(4)) + right('0'+ CAST(MONTH(d.[POST_DATE]) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
		))
	AND (
		(@select_by = 7 AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_numbers_in_list, ',')))
		OR
		(@select_by = 4 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')))
		OR
		(@select_by = 1 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')))
		OR
		(@select_by = 2 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')))
		OR
		(@select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')))
		OR
		(@select_by = 5 AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_numbers_in_list, ',')))
		OR
		(@select_by = 6 AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS VARCHAR(20)) IN (SELECT * FROM dbo.udf_split_list(@job_numbers_components_in_list, ',')))
		OR
		(@select_by = 0)
		OR
		(@select_by = 9 AND ae.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_in_list, ',')))
		OR
		(@select_by = 10 AND ec.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_jobs_in_list, ',')))
		OR
		(@select_by = 11 AND
							(
								(@order_status_in_list <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@order_status_in_list, ',')))
								OR
								(@order_status_in_list = '0' AND o.[STATUS] IS NULL)
								)
							)
		OR
		(@select_by = 12 AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@vendor_code_in_list, ',')))
		OR
		(@select_by = 8 AND h.BUYER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@buyer_emp_codes_in_list, ',')))
		)
END

-- Internet *********************************************************************************************************************************************
IF ( @internet = 1 )
BEGIN
	UPDATE h SET LOCKED_BY = @user_id 
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON jc.EMP_CODE = ec.EMP_CODE 
		LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) ae ON p.CL_CODE = ae.CL_CODE AND p.DIV_CODE = ae.DIV_CODE AND p.PRD_CODE = ae.PRD_CODE
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.INTERNET_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, [STATUS] = 0 FROM dbo.INTERNET_DETAIL WHERE @order_status_in_list <> '0'
						) o ON d.ORDER_NBR = o.ORDER_NBR AND d.LINE_NBR = o.LINE_NBR AND @order_status_in_list IS NOT NULL
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
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id)
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
	AND (
		(@select_by = 7 AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_numbers_in_list, ',')))
		OR
		(@select_by = 4 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')))
		OR
		(@select_by = 1 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')))
		OR
		(@select_by = 2 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')))
		OR
		(@select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')))
		OR
		(@select_by = 5 AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_numbers_in_list, ',')))
		OR
		(@select_by = 6 AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS VARCHAR(20)) IN (SELECT * FROM dbo.udf_split_list(@job_numbers_components_in_list, ',')))
		OR
		(@select_by = 0)
		OR
		(@select_by = 9 AND ae.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_in_list, ',')))
		OR
		(@select_by = 10 AND ec.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_jobs_in_list, ',')))
		OR
		(@select_by = 11 AND
							(
								(@order_status_in_list <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@order_status_in_list, ',')))
								OR
								(@order_status_in_list = '0' AND o.[STATUS] IS NULL)
								)
							)
		OR
		(@select_by = 12 AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@vendor_code_in_list, ',')))
		OR
		(@select_by = 8 AND h.BUYER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@buyer_emp_codes_in_list, ',')))
		)
END

-- Radio *********************************************************************************************************************************************
IF ( @radio = 1 )
BEGIN
	-- Radio (New)
	UPDATE h SET LOCKED_BY = @user_id 
	FROM dbo.RADIO_HDR h
		INNER JOIN dbo.RADIO_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON jc.EMP_CODE = ec.EMP_CODE 
		LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) ae ON p.CL_CODE = ae.CL_CODE AND p.DIV_CODE = ae.DIV_CODE AND p.PRD_CODE = ae.PRD_CODE
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.RADIO_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, [STATUS] = 0 FROM dbo.RADIO_DETAIL WHERE @order_status_in_list <> '0'
						) o ON d.ORDER_NBR = o.ORDER_NBR AND d.LINE_NBR = o.LINE_NBR AND @order_status_in_list IS NOT NULL
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
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id)
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
	AND (
		(@select_by = 7 AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_numbers_in_list, ',')))
		OR
		(@select_by = 4 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')))
		OR
		(@select_by = 1 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')))
		OR
		(@select_by = 2 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')))
		OR
		(@select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')))
		OR
		(@select_by = 5 AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_numbers_in_list, ',')))
		OR
		(@select_by = 6 AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS VARCHAR(20)) IN (SELECT * FROM dbo.udf_split_list(@job_numbers_components_in_list, ',')))
		OR
		(@select_by = 0)
		OR
		(@select_by = 9 AND ae.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_in_list, ',')))
		OR
		(@select_by = 10 AND ec.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_jobs_in_list, ',')))
		OR
		(@select_by = 11 AND
							(
								(@order_status_in_list <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@order_status_in_list, ',')))
								OR
								(@order_status_in_list = '0' AND o.[STATUS] IS NULL)
								)
							)
		OR
		(@select_by = 12 AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@vendor_code_in_list, ',')))
		OR
		(@select_by = 8 AND h.BUYER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@buyer_emp_codes_in_list, ',')))
		)
END

-- Television *********************************************************************************************************************************************
IF ( @television = 1 )
BEGIN
	-- TV (New)
	UPDATE h SET LOCKED_BY = @user_id 
	FROM dbo.TV_HDR h
		INNER JOIN dbo.TV_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND d.ACTIVE_REV = 1
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON jc.EMP_CODE = ec.EMP_CODE 
		LEFT OUTER JOIN dbo.PRODUCT p ON h.CL_CODE = p.CL_CODE AND h.DIV_CODE = p.DIV_CODE AND h.PRD_CODE = p.PRD_CODE
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) ae ON p.CL_CODE = ae.CL_CODE AND p.DIV_CODE = ae.DIV_CODE AND p.PRD_CODE = ae.PRD_CODE
		LEFT OUTER JOIN (
						SELECT ORDER_NBR, LINE_NBR, [STATUS] FROM dbo.TV_ORDER_STATUS 
						UNION
						SELECT ORDER_NBR, LINE_NBR, [STATUS] = 0 FROM dbo.TV_DETAIL WHERE @order_status_in_list <> '0'
						) o ON d.ORDER_NBR = o.ORDER_NBR AND d.LINE_NBR = o.LINE_NBR AND @order_status_in_list IS NOT NULL
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
	AND	(h.LOCKED_BY IS NULL OR h.LOCKED_BY = @user_id)
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
	AND (
		(@select_by = 7 AND h.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_numbers_in_list, ',')))
		OR
		(@select_by = 4 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')))
		OR
		(@select_by = 1 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')))
		OR
		(@select_by = 2 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')))
		OR
		(@select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')))
		OR
		(@select_by = 5 AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_numbers_in_list, ',')))
		OR
		(@select_by = 6 AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS VARCHAR(20)) IN (SELECT * FROM dbo.udf_split_list(@job_numbers_components_in_list, ',')))
		OR
		(@select_by = 0)
		OR
		(@select_by = 9 AND ae.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_in_list, ',')))
		OR
		(@select_by = 10 AND ec.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_jobs_in_list, ',')))
		OR
		(@select_by = 11 AND
							(
								(@order_status_in_list <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@order_status_in_list, ',')))
								OR
								(@order_status_in_list = '0' AND o.[STATUS] IS NULL)
								)
							)
		OR
		(@select_by = 12 AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@vendor_code_in_list, ',')))
		OR
		(@select_by = 8 AND h.BUYER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@buyer_emp_codes_in_list, ',')))
		)
END

-- PO *********************************************************************************************************************************************
IF ( @po = 1 )
BEGIN
	UPDATE h SET LOCK_USER = @user_id 
	FROM dbo.PURCHASE_ORDER h
		INNER JOIN dbo.PURCHASE_ORDER_DET d ON h.PO_NUMBER = d.PO_NUMBER AND @include_order = 1
		LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER 
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc on jc.JOB_NUMBER = d.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = d.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON jc.EMP_CODE = ec.EMP_CODE 
		LEFT OUTER JOIN dbo.PRODUCT p ON jl.CL_CODE = p.CL_CODE AND jl.DIV_CODE = p.DIV_CODE AND jl.PRD_CODE = p.PRD_CODE
		LEFT OUTER JOIN (
						SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME  
						FROM dbo.ACCOUNT_EXECUTIVE AE
							INNER JOIN dbo.EMPLOYEE E ON AE.EMP_CODE = E.EMP_CODE 
						WHERE AE.DEFAULT_AE  = 1
						AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
						) ae ON p.CL_CODE = ae.CL_CODE AND p.DIV_CODE = ae.DIV_CODE AND p.PRD_CODE = ae.PRD_CODE
		LEFT OUTER JOIN (
						SELECT PO_NUMBER, [STATUS] FROM dbo.PURCHASE_ORDER_STATUS
						UNION
						SELECT PO_NUMBER, [STATUS] = 0 FROM dbo.PURCHASE_ORDER WHERE @order_status_in_list <> '0'
						) o ON d.PO_NUMBER = o.PO_NUMBER AND @order_status_in_list IS NOT NULL
	WHERE
		COALESCE(h.VOID_FLAG, 0) = 0
	AND	(h.PO_COMPLETE IS NULL OR h.PO_COMPLETE = 0)
	AND	(h.LOCK_USER IS NULL OR h.LOCK_USER = @user_id)
	AND ((
			( @include_order_line_dates = 0 )
		OR
			( @include_order_line_dates = 1 AND ( h.[PO_DATE] BETWEEN @order_line_start_date AND @order_line_end_date ) )
		)
		AND
		(
			( @include_job_media_date_to_bill = 0 )
		OR
			( @include_job_media_date_to_bill = 1 AND ( jc.MEDIA_BILL_DATE between @job_media_start_date AND @job_media_end_date ) )
		))
	AND (
		(@select_by = 7 AND h.PO_NUMBER IN (SELECT * FROM dbo.udf_split_list(@order_numbers_in_list, ',')))
		OR
		(@select_by = 4 AND jl.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')))
		OR
		(@select_by = 1 AND jl.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')))
		OR
		(@select_by = 2 AND jl.CL_CODE + '|' + jl.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')))
		OR
		(@select_by = 3 AND jl.CL_CODE + '|' + jl.DIV_CODE + '|' + jl.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')))
		OR
		(@select_by = 5 AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_numbers_in_list, ',')))
		OR
		(@select_by = 6 AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS VARCHAR(20)) IN (SELECT * FROM dbo.udf_split_list(@job_numbers_components_in_list, ',')))
		OR
		(@select_by = 0)
		OR
		(@select_by = 9 AND ae.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_in_list, ',')))
		OR
		(@select_by = 10 AND ec.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ae_emp_codes_executive_jobs_in_list, ',')))
		OR
		(@select_by = 11 AND
							(
								(@order_status_in_list <> '0' AND o.[STATUS] IN (SELECT * FROM dbo.udf_split_list(@order_status_in_list, ',')))
								OR
								(@order_status_in_list = '0' AND o.[STATUS] IS NULL)
								)
							)
		OR
		(@select_by = 12 AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@vendor_code_in_list, ',')))
		OR
		(@select_by = 8 AND h.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@buyer_emp_codes_in_list, ',')))
		)
END

GO
