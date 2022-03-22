CREATE PROCEDURE [dbo].[advsp_update_billing_cmd_center_media] @bcc_id_in integer, @billing_user varchar(100), @m_select_by smallint, 
	@cmp_id_in_list varchar(max), @cl_code_in_list varchar(max), @cl_div_code_in_list varchar(max), @cl_div_prd_code_in_list varchar(max), @order_number_in_list varchar(max), 
	@order_line_number_in_list varchar(max), @client_po_in_list varchar(max), @market_code_in_list varchar(max), @incl_unbilled_only bit, @incl_zero_spots bit, 
	@date_to_use smallint, @newspaper bit, @magazine bit, @internet bit, @out_of_home bit, @radio bit, @radio_daily bit, @radio_monthly bit, 
	@television bit, @tv_daily bit, @tv_monthly bit, @m_start_date smalldatetime, @m_cutoff_date smalldatetime, @brdcast_date1 smalldatetime,
	@brdcast_date2 smalldatetime, @incl_legacy bit, @job_media_date_from smalldatetime, @job_media_date_to smalldatetime, @biller_emp_code_list varchar(max)
AS
--07/15/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @UserCode varchar(100), @EmployeeCode varchar(6), @HasCDPLimits bit

SELECT @UserCode = UPPER(SUBSTRING(BILLING_USER, 1, LEN(BILLING_USER) - 2))
FROM dbo.BILLING_CMD_CENTER
WHERE BCC_ID = @bcc_id_in

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserCode)

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SET @HasCDPLimits = 1
ELSE
	SEt @HasCDPLimits = 0

DECLARE @brd_mth1 smalldatetime, @brd_mth2 smalldatetime

IF ( ISDATE( @brdcast_date1 ) = 1 )
	SELECT @brd_mth1 = @brdcast_date1

IF ( ISDATE( @brdcast_date2 ) = 1 )
	SELECT @brd_mth2 = DATEADD(n, -1, DATEADD(mm, 1, @brdcast_date2))

-- Magazine *********************************************************************************************************************************************
IF ( @magazine = 1 )
BEGIN
	
	INSERT INTO dbo.BCC_ORDER_LINE ( ORDER_NBR, LINE_NBR, BCC_ID )
	SELECT r.ORDER_NBR, r.LINE_NBR, r.BCC_ID
	FROM
		(
		SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, @bcc_id_in AS BCC_ID,
			[OK] = CASE 
					WHEN @m_select_by = 0 THEN 1
					WHEN @m_select_by = 1 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')) THEN 1
					WHEN @m_select_by = 2 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 4 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 5 AND d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 6 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ',')) THEN 1
					WHEN @m_select_by = 7 AND h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 8 AND CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 9 AND h.CL_CODE IN (SELECT CL_CODE FROM dbo.CLIENT WHERE BILLER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@biller_emp_code_list, ','))) THEN 1
					ELSE 0 END
		FROM dbo.MAGAZINE_HEADER h
			INNER JOIN dbo.MAGAZINE_DETAIL d ON ( h.ORDER_NBR = d.ORDER_NBR )
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
        AND d.ACTIVE_REV = 1
		AND	COALESCE(h.[STATUS], 0) = 0
		AND ( h.ORD_PROCESS_CONTRL IN ( 1, 5 ))
		AND (
			(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 2 AND ( d.START_DATE BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 3 AND d.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
			)
		AND NOT EXISTS ( SELECT 1
						 FROM dbo.BCC_ORDER_LINE bol 
						 WHERE bol.ORDER_NBR = d.ORDER_NBR 
						 AND bol.LINE_NBR = d.LINE_NBR )
		AND (
			( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
		AND (
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = @UserCode
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
			OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)
		) r
	WHERE
		r.OK = 1

	UPDATE dbo.MAGAZINE_HEADER
		SET BCC_ID = @bcc_id_in
	WHERE BCC_ID IS NULL
	AND EXISTS (SELECT 1
				FROM dbo.BCC_ORDER_LINE bol
				WHERE bol.ORDER_NBR = dbo.MAGAZINE_HEADER.ORDER_NBR)
END

-- Newspaper *********************************************************************************************************************************************
IF ( @newspaper = 1 )
BEGIN
	INSERT INTO dbo.BCC_ORDER_LINE ( ORDER_NBR, LINE_NBR, BCC_ID )
	SELECT r.ORDER_NBR, r.LINE_NBR, r.BCC_ID
	FROM
		(
		SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, @bcc_id_in AS BCC_ID,
			[OK] = CASE 
					WHEN @m_select_by = 0 THEN 1
					WHEN @m_select_by = 1 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')) THEN 1
					WHEN @m_select_by = 2 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 4 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 5 AND d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 6 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ',')) THEN 1
					WHEN @m_select_by = 7 AND h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 8 AND CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 9 AND h.CL_CODE IN (SELECT CL_CODE FROM dbo.CLIENT WHERE BILLER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@biller_emp_code_list, ','))) THEN 1
					ELSE 0 END
		FROM dbo.NEWSPAPER_HEADER h
			INNER JOIN dbo.NEWSPAPER_DETAIL d ON ( h.ORDER_NBR = d.ORDER_NBR )
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
        AND d.ACTIVE_REV = 1
		AND	COALESCE(h.[STATUS], 0) = 0
		AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
		AND (
			(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 2 AND ( d.START_DATE BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 3 AND d.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
			)
		AND NOT EXISTS (SELECT 1
						FROM dbo.BCC_ORDER_LINE bol
						WHERE bol.ORDER_NBR = d.ORDER_NBR
						AND bol.LINE_NBR = d.LINE_NBR )
		AND (
			( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
		AND (
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = @UserCode
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
			OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)
		) r
	WHERE
		r.OK = 1

	UPDATE dbo.NEWSPAPER_HEADER
		SET BCC_ID = @bcc_id_in
	WHERE BCC_ID IS NULL
	AND EXISTS (SELECT 1
				FROM dbo.BCC_ORDER_LINE bol
				WHERE bol.ORDER_NBR = dbo.NEWSPAPER_HEADER.ORDER_NBR )
END

-- Out of home *********************************************************************************************************************************************
IF ( @out_of_home = 1 )
BEGIN
	INSERT INTO dbo.BCC_ORDER_LINE ( ORDER_NBR, LINE_NBR, BCC_ID )
	SELECT r.ORDER_NBR, r.LINE_NBR, r.BCC_ID
	FROM
		(
		SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, @bcc_id_in AS BCC_ID,
			[OK] = CASE 
					WHEN @m_select_by = 0 THEN 1
					WHEN @m_select_by = 1 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')) THEN 1
					WHEN @m_select_by = 2 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 4 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 5 AND d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 6 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ',')) THEN 1
					WHEN @m_select_by = 7 AND h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 8 AND CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 9 AND h.CL_CODE IN (SELECT CL_CODE FROM dbo.CLIENT WHERE BILLER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@biller_emp_code_list, ','))) THEN 1
					ELSE 0 END
		FROM dbo.OUTDOOR_HEADER h
			INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
        AND d.ACTIVE_REV = 1
		AND	COALESCE(h.[STATUS], 0) = 0
		AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
		AND (
			(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 2 AND ( d.POST_DATE BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 3 AND d.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
			)
		AND NOT EXISTS (SELECT 1
						FROM dbo.BCC_ORDER_LINE bol
						WHERE bol.ORDER_NBR = d.ORDER_NBR
						AND bol.LINE_NBR = d.LINE_NBR )
		AND (
			( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
		AND (
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = @UserCode
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
			OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)
		) r
	WHERE
		r.OK = 1

	UPDATE dbo.OUTDOOR_HEADER
		SET BCC_ID = @bcc_id_in
	WHERE BCC_ID IS NULL
	AND EXISTS (SELECT 1
				FROM dbo.BCC_ORDER_LINE bol
				WHERE bol.ORDER_NBR = dbo.OUTDOOR_HEADER.ORDER_NBR )
END

-- Internet *********************************************************************************************************************************************
IF ( @internet = 1 )
BEGIN
	INSERT INTO dbo.BCC_ORDER_LINE ( ORDER_NBR, LINE_NBR, BCC_ID )
	SELECT r.ORDER_NBR, r.LINE_NBR, r.BCC_ID
	FROM
		(
		SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, @bcc_id_in AS BCC_ID,
			[OK] = CASE 
					WHEN @m_select_by = 0 THEN 1
					WHEN @m_select_by = 1 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')) THEN 1
					WHEN @m_select_by = 2 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 4 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 5 AND d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 6 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ',')) THEN 1
					WHEN @m_select_by = 7 AND h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 8 AND CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 9 AND h.CL_CODE IN (SELECT CL_CODE FROM dbo.CLIENT WHERE BILLER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@biller_emp_code_list, ','))) THEN 1
					ELSE 0 END
		FROM dbo.INTERNET_HEADER h
			INNER JOIN dbo.INTERNET_DETAIL d ON ( h.ORDER_NBR = d.ORDER_NBR )
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
        AND d.ACTIVE_REV = 1
		AND	COALESCE(h.[STATUS], 0) = 0
		AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
		AND (
			(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 2 AND ( d.START_DATE BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@date_to_use = 3 AND d.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
			)
		AND NOT EXISTS (SELECT 1
						FROM dbo.BCC_ORDER_LINE bol
						WHERE bol.ORDER_NBR = d.ORDER_NBR
						AND bol.LINE_NBR = d.LINE_NBR )
		AND (
			( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
		AND (
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = @UserCode
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
			OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)
		) r
	WHERE
		r.OK = 1

	UPDATE dbo.INTERNET_HEADER
		SET BCC_ID = @bcc_id_in
	WHERE BCC_ID IS NULL
	AND EXISTS (SELECT 1
				FROM dbo.BCC_ORDER_LINE bol
				WHERE bol.ORDER_NBR = dbo.INTERNET_HEADER.ORDER_NBR )
END

-- Radio *********************************************************************************************************************************************
IF ( @radio = 1 )
BEGIN
	--IF ( @radio_monthly = 1 AND @incl_legacy = 1 )
	--BEGIN
	--	INSERT INTO dbo.BCC_ORDER_BRDCAST ( ORDER_NBR, LINE_NBR, BRDCAST_YEAR, BRDCAST_MONTH, BCC_ID )
	--	SELECT DISTINCT h.ORDER_NBR, CASE WHEN @m_select_by = 8 THEN vd.LINE_NBR ELSE 0 END, vd.BRDCAST_YEAR, vd.MONTH_IND, @bcc_id_in
	--	FROM dbo.RADIO_DETAIL1 d
	--		INNER JOIN dbo.V_RADIO_DETAIL1 vd ON ( d.ORDER_NBR = vd.ORDER_NBR )
	--											AND ( d.LINE_NBR = vd.LINE_NBR )
	--											AND ( d.SEQ_NBR = vd.SEQ_NBR )
	--											AND ( d.BRDCAST_YEAR = vd.BRDCAST_YEAR )
	--		INNER JOIN dbo.RADIO_HEADER h ON ( d.ORDER_NBR = h.ORDER_NBR )
	--											AND ( h.REV_NBR = ( SELECT vmomrs.MAX_REV
	--																FROM (
	--																	SELECT d.ORDER_NBR, d.LINE_NBR, d.REV_NBR as MAX_REV, MAX(d.SEQ_NBR) as MAX_SEQ
	--																	FROM dbo.RADIO_DETAIL1 AS d
	--																	WHERE d.REV_NBR = ( SELECT MAX(d2.REV_NBR) 
	--																						FROM dbo.RADIO_DETAIL1 AS d2
	--																						WHERE d.ORDER_NBR = d2.ORDER_NBR 
	--																						AND d.LINE_NBR = d2.LINE_NBR )
	--																	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR) vmomrs
	--																WHERE vmomrs.ORDER_NBR = h.ORDER_NBR
	--																AND vmomrs.LINE_NBR = d.LINE_NBR ))
	--	WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
	--	AND	COALESCE(h.[STATUS], 0) = 0
	--	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
	--	AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
	--	AND	( CAST( CAST( vd.MONTH_IND AS varchar(2)) + '/01/' + CAST( vd.BRDCAST_YEAR AS varchar(4)) AS smalldatetime ) BETWEEN @brd_mth1 AND @brd_mth2 )
	--	AND NOT EXISTS (SELECT 1
	--					FROM dbo.BCC_ORDER_BRDCAST bob
	--					WHERE bob.ORDER_NBR = vd.ORDER_NBR
	--					AND (
	--						( @m_select_by = 8 AND bob.LINE_NBR = vd.LINE_NBR)
	--						OR
	--						( @m_select_by <> 8 )
	--						)
	--					AND bob.BRDCAST_YEAR = vd.BRDCAST_YEAR
	--					AND bob.BRDCAST_MONTH = vd.MONTH_IND )
	--	AND (
	--		(( @m_select_by = 5 ) AND ( d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ','))))
	--		OR
	--		(( @m_select_by = 8 ) AND ( CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ','))))
	--		OR
	--		(( @m_select_by = 1 ) AND ( h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ','))))
	--		OR
	--		(( @m_select_by = 2 ) AND ( h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ','))))
	--		OR
	--		(( @m_select_by = 3 ) AND ( h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ','))))
	--		OR
	--		(( @m_select_by = 4 ) AND ( h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ','))))
	--		OR
	--		(( @m_select_by = 6 ) AND ( h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ','))))
	--		OR
	--		(( @m_select_by = 7 ) AND ( h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ','))))
	--		OR
	--		( @m_select_by = 0 )
	--		)
	--	AND (
	--		( @incl_unbilled_only = 1 AND vd.AR_INV_NBR IS NULL )
	--		OR
	--		( @incl_unbilled_only = 0 )
	--		)
		
	--	UPDATE dbo.RADIO_HEADER
	--		SET BCC_ID = @bcc_id_in
	--	WHERE BCC_ID IS NULL
	--	AND EXISTS (SELECT 1
	--				FROM dbo.BCC_ORDER_BRDCAST bob
	--				WHERE bob.ORDER_NBR = dbo.RADIO_HEADER.ORDER_NBR )
	--END
		
	-- Radio (New)
	INSERT INTO dbo.BCC_ORDER_LINE ( ORDER_NBR, LINE_NBR, BCC_ID )
	SELECT r.ORDER_NBR, r.LINE_NBR, r.BCC_ID
	FROM
		(
		SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, @bcc_id_in AS BCC_ID,
			[OK] = CASE 
					WHEN @m_select_by = 0 THEN 1
					WHEN @m_select_by = 1 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')) THEN 1
					WHEN @m_select_by = 2 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 4 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 5 AND d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 6 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ',')) THEN 1
					WHEN @m_select_by = 7 AND h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 8 AND CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 9 AND h.CL_CODE IN (SELECT CL_CODE FROM dbo.CLIENT WHERE BILLER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@biller_emp_code_list, ','))) THEN 1
					ELSE 0 END
		FROM dbo.RADIO_HDR h
			INNER JOIN dbo.RADIO_DETAIL d	ON ( h.ORDER_NBR = d.ORDER_NBR )
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
        AND d.ACTIVE_REV = 1
		AND	COALESCE(h.[STATUS], 0) = 0
		AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
		AND ( d.BILLING_AMT <> 0.00 OR ( @incl_zero_spots = 1 AND d.TOTAL_SPOTS <> 0 ))
		-- BEGIN Date criteria
		AND 
			(
			(@radio_daily = 1 AND @date_to_use = 1 AND ( h.UNITS = 'DB' AND d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@radio_daily = 1 AND @date_to_use = 2 AND ( h.UNITS = 'DB' AND d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@radio_monthly = 1 AND @date_to_use = 1 AND h.UNITS IN ( 'BM', 'CM' ) AND d.DATE_TO_BILL BETWEEN @brd_mth1 AND @brd_mth2)
			OR
			(@radio_monthly = 1 AND @date_to_use = 2 AND ( h.UNITS IN ( 'BM', 'CM' ) AND ( CAST(CAST( d.MONTH_NBR as varchar(2)) + '/01/' + CAST( d.YEAR_NBR as varchar(4)) as smalldatetime) BETWEEN @brd_mth1 AND @brd_mth2)))
			OR
			(@date_to_use = 3 AND d.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ) AND ( (@radio_daily = 1 AND h.UNITS = 'DB') OR (@radio_monthly = 1 AND h.UNITS IN ( 'BM', 'CM' ))))
			)
		-- END Date criteria
	
		AND NOT EXISTS (SELECT 1
						FROM dbo.BCC_ORDER_LINE bol
						WHERE bol.ORDER_NBR = d.ORDER_NBR
						AND bol.LINE_NBR = d.LINE_NBR )
		AND (
			( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
		AND (
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = @UserCode
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
			OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)
		) r
	WHERE
		r.OK = 1

	UPDATE dbo.RADIO_HDR
		SET BCC_ID = @bcc_id_in
	WHERE BCC_ID IS NULL
	AND EXISTS (SELECT 1
				FROM dbo.BCC_ORDER_LINE bol
				WHERE bol.ORDER_NBR = dbo.RADIO_HDR.ORDER_NBR )
END

-- Television *********************************************************************************************************************************************
IF ( @television = 1 )
BEGIN
	--IF ( @tv_monthly = 1 AND @incl_legacy = 1 )
	--BEGIN
	--	INSERT INTO dbo.BCC_ORDER_BRDCAST ( ORDER_NBR, LINE_NBR, BRDCAST_YEAR, BRDCAST_MONTH, BCC_ID )
	--	SELECT DISTINCT h.ORDER_NBR, CASE WHEN @m_select_by = 8 THEN vd.LINE_NBR ELSE 0 END, vd.BRDCAST_YEAR, vd.MONTH_IND, @bcc_id_in
	--	FROM dbo.TV_DETAIL1 d
	--		INNER JOIN dbo.V_TV_DETAIL1 vd ON ( d.ORDER_NBR = vd.ORDER_NBR )
	--										AND ( d.LINE_NBR = vd.LINE_NBR )
	--										AND ( d.SEQ_NBR = vd.SEQ_NBR )
	--										AND ( d.BRDCAST_YEAR = vd.BRDCAST_YEAR )
	--		INNER JOIN dbo.TV_HEADER h ON ( d.ORDER_NBR = h.ORDER_NBR )
	--										AND ( h.REV_NBR = ( SELECT vmomrs.MAX_REV
	--															FROM (
	--																SELECT d.ORDER_NBR, d.LINE_NBR, d.REV_NBR as MAX_REV, MAX(d.SEQ_NBR) as MAX_SEQ
	--																FROM dbo.TV_DETAIL1 AS d
	--																WHERE d.REV_NBR = ( SELECT MAX(d2.REV_NBR) 
	--																					FROM dbo.TV_DETAIL1 AS d2
	--																					WHERE d.ORDER_NBR = d2.ORDER_NBR 
	--																					AND d.LINE_NBR = d2.LINE_NBR )	
	--																GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR) vmomrs
	--															WHERE vmomrs.ORDER_NBR = h.ORDER_NBR
	--															AND vmomrs.LINE_NBR = d.LINE_NBR ))
	--	WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
	--	AND	COALESCE(h.[STATUS], 0) = 0
	--	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
	--	AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
	--	AND	( CAST( CAST( vd.MONTH_IND AS varchar(2)) + '/01/' + CAST( vd.BRDCAST_YEAR AS varchar(4)) AS smalldatetime ) BETWEEN @brd_mth1 AND @brd_mth2 )
	--	AND NOT EXISTS (SELECT 1
	--					FROM dbo.BCC_ORDER_BRDCAST bob
	--					WHERE bob.ORDER_NBR = vd.ORDER_NBR
	--					AND (
	--						( @m_select_by = 8 AND bob.LINE_NBR = vd.LINE_NBR)
	--						OR
	--						( @m_select_by <> 8 )
	--						)
	--					AND bob.BRDCAST_YEAR = vd.BRDCAST_YEAR
	--					AND bob.BRDCAST_MONTH = vd.MONTH_IND )
	--	AND (
	--		(( @m_select_by = 5 ) AND ( d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ','))))
	--		OR
	--		(( @m_select_by = 8 ) AND ( CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ','))))
	--		OR
	--		(( @m_select_by = 1 ) AND ( h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ','))))
	--		OR
	--		(( @m_select_by = 2 ) AND ( h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ','))))
	--		OR
	--		(( @m_select_by = 3 ) AND ( h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ','))))
	--		OR
	--		(( @m_select_by = 4 ) AND ( h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ','))))
	--		OR
	--		(( @m_select_by = 6 ) AND ( h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ','))))
	--		OR
	--		(( @m_select_by = 7 ) AND ( h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ','))))
	--		OR
	--		( @m_select_by = 0 )
	--		)
	--	AND (
	--		( @incl_unbilled_only = 1 AND vd.AR_INV_NBR IS NULL )
	--		OR
	--		( @incl_unbilled_only = 0 )
	--		)

	--	UPDATE dbo.TV_HEADER
	--		SET BCC_ID = @bcc_id_in
	--	WHERE BCC_ID IS NULL
	--	AND EXISTS (SELECT 1
	--				FROM dbo.BCC_ORDER_BRDCAST bob
	--				WHERE bob.ORDER_NBR = dbo.TV_HEADER.ORDER_NBR )
	--END
	
	-- TV (New)
	INSERT INTO dbo.BCC_ORDER_LINE ( ORDER_NBR, LINE_NBR, BCC_ID )
	SELECT r.ORDER_NBR, r.LINE_NBR, r.BCC_ID
	FROM
		(
		SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, @bcc_id_in AS BCC_ID,
			[OK] = CASE 
					WHEN @m_select_by = 0 THEN 1
					WHEN @m_select_by = 1 AND h.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_in_list, ',')) THEN 1
					WHEN @m_select_by = 2 AND h.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 3 AND h.CL_CODE + '|' + h.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 4 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 5 AND d.ORDER_NBR IN (SELECT * FROM dbo.udf_split_list(@order_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 6 AND h.CL_CODE + '|' + h.DIV_CODE + '|' + h.PRD_CODE + '|' + h.CLIENT_PO IN (SELECT * FROM dbo.udf_split_list(@client_po_in_list, ',')) THEN 1
					WHEN @m_select_by = 7 AND h.MARKET_CODE IN (SELECT * FROM dbo.udf_split_list(@market_code_in_list, ',')) THEN 1
					WHEN @m_select_by = 8 AND CAST(d.ORDER_NBR as varchar(20)) + '|' + CAST(d.LINE_NBR as varchar(10)) IN (SELECT * FROM dbo.udf_split_list(@order_line_number_in_list, ',')) THEN 1
					WHEN @m_select_by = 9 AND h.CL_CODE IN (SELECT CL_CODE FROM dbo.CLIENT WHERE BILLER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@biller_emp_code_list, ','))) THEN 1
					ELSE 0 END
		FROM dbo.TV_HDR h
			INNER JOIN dbo.TV_DETAIL d  ON ( h.ORDER_NBR = d.ORDER_NBR )
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
		WHERE ( h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in )
        AND d.ACTIVE_REV = 1
		AND	COALESCE(h.[STATUS], 0) = 0
		AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
		AND ( d.BILLING_AMT <> 0.00 OR ( @incl_zero_spots = 1 AND d.TOTAL_SPOTS <> 0 ))
		-- BEGIN Date criteria
		AND 
			(
			(@tv_daily = 1 AND @date_to_use = 1 AND ( h.UNITS = 'DB' AND d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@tv_daily = 1 AND @date_to_use = 2 AND ( h.UNITS = 'DB' AND d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
			OR
			(@tv_monthly = 1 AND @date_to_use = 1 AND h.UNITS IN ( 'BM', 'CM' ) AND d.DATE_TO_BILL BETWEEN @brd_mth1 AND @brd_mth2)
			OR
			(@tv_monthly = 1 AND @date_to_use = 2 AND ( h.UNITS IN ( 'BM', 'CM' ) AND ( CAST(CAST( d.MONTH_NBR as varchar(2)) + '/01/' + CAST( d.YEAR_NBR as varchar(4)) as smalldatetime) BETWEEN @brd_mth1 AND @brd_mth2)))
			OR
			(@date_to_use = 3 AND d.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ) AND ( (@tv_daily = 1 AND h.UNITS = 'DB') OR (@tv_monthly = 1 AND h.UNITS IN ( 'BM', 'CM' ))))
			)
		-- END Date criteria
		AND NOT EXISTS (SELECT 1
						FROM dbo.BCC_ORDER_LINE bol
						WHERE bol.ORDER_NBR = d.ORDER_NBR
						AND bol.LINE_NBR = d.LINE_NBR )
		AND (
			( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
		AND (
			( @HasCDPLimits = 1 AND EXISTS (
											SELECT 1
											FROM dbo.SEC_CLIENT sc
											WHERE UPPER(sc.[USER_ID]) = @UserCode
											AND sc.CL_CODE = h.CL_CODE
											AND sc.DIV_CODE = h.DIV_CODE
											AND sc.PRD_CODE = h.PRD_CODE
											AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
										   ))
			OR
			( @HasCDPLimits = 0 AND h.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)
		) r
	WHERE
		r.OK = 1

	UPDATE dbo.TV_HDR
		SET BCC_ID = @bcc_id_in
	WHERE BCC_ID IS NULL
	AND EXISTS (SELECT 1
				FROM dbo.BCC_ORDER_LINE bol
				WHERE bol.ORDER_NBR = dbo.TV_HDR.ORDER_NBR )
END
