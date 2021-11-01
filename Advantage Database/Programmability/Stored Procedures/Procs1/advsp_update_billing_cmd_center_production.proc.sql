CREATE PROCEDURE [dbo].[advsp_update_billing_cmd_center_production] @bcc_id_in integer, @billing_user varchar(100), @select_by smallint, 
	@cl_code_list varchar(max), @cl_div_code_list varchar(max), @cl_div_prd_code_list varchar(max), @sel_option smallint, 
	@emp_date_in smalldatetime, @io_date_in smalldatetime, @ap_post_period_in varchar(6), 
	@cmp_id_list varchar(max), @job_number_list varchar(max), @job_comp_rowid_list varchar(max), @batch_id_in integer, @ba_hdr_id_list varchar(max),
	@acct_exec_list varchar(max), @job_type smallint, @sc_code_list varchar(max), @biller_emp_code_list varchar(max),
    @job_media_date_from smalldatetime, @job_media_date_to smalldatetime
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

--select GETDATE() 'Start'

-- Job Component *********************************************************************************************************************************************
DECLARE @JC TABLE (
	JOB_NUMBER int NOT NULL,
	JOB_COMPONENT_NBR smallint NOT NULL,
	EMP_CODE varchar(6) NOT NULL,
	AB_FLAG smallint NULL,
	SERVICE_FEE_FLAG smallint NULL
)

declare @IncludeJobDates bit

IF @job_media_date_from IS NOT NULL AND @job_media_date_to IS NOT NULL
    SET @IncludeJobDates = 1
ELSE
    SET @IncludeJobDates = 0

IF ( @select_by = 8 AND @batch_id_in > 0 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND		EXISTS (
					SELECT 1
					FROM dbo.BILL_APPR_HDR bah
						INNER JOIN dbo.BILL_APPR ba ON bah.BA_ID = ba.BA_ID
					WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
					AND bah.BA_HDR_ID IN (SELECT * FROM dbo.udf_split_list(@ba_hdr_id_list, ','))
					AND ba.BA_BATCH_ID = @batch_id_in
				   )
ELSE IF ( @select_by = 8 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND		EXISTS (
					SELECT 1
					FROM dbo.BILL_APPR_HDR bah
					WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
					AND bah.BA_HDR_ID IN (SELECT * FROM dbo.udf_split_list(@ba_hdr_id_list, ','))
				   )
ELSE IF ( @select_by = 10 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@acct_exec_list, ','))
ELSE IF ( @select_by = 9 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND JOB_NUMBER IN (SELECT JOB_NUMBER FROM dbo.JOB_LOG WHERE SC_CODE IN (SELECT * FROM dbo.udf_split_list(@sc_code_list, ',')))
ELSE IF ( @select_by = 7 )
	IF ( @batch_id_in > 0 )
		INSERT @JC
		SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
		FROM dbo.JOB_COMPONENT 
		WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
		AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
		AND ( BCC_ID IS NULL )
		AND ROWID IN (SELECT * FROM dbo.udf_split_list(@job_comp_rowid_list, ','))
		AND		EXISTS (
					SELECT 1
					FROM dbo.BILL_APPR_HDR bah
						INNER JOIN dbo.BILL_APPR ba ON ( bah.BA_ID = ba.BA_ID )
					WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
					AND ba.BA_BATCH_ID = @batch_id_in 
				   )
	ELSE
		INSERT @JC
		SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
		FROM dbo.JOB_COMPONENT 
		WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
		AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
		AND ( BCC_ID IS NULL )
		AND ROWID IN (SELECT * FROM dbo.udf_split_list(@job_comp_rowid_list, ','))
ELSE IF ( @select_by = 6 )
	IF ( @batch_id_in > 0 )
		INSERT @JC
		SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
		FROM dbo.JOB_COMPONENT 
		WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
		AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
		AND ( BCC_ID IS NULL )
		AND JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_number_list, ','))
		AND		EXISTS (
					SELECT 1
					FROM dbo.BILL_APPR_HDR bah
						INNER JOIN dbo.BILL_APPR ba ON ( bah.BA_ID = ba.BA_ID )
					WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
					AND ba.BA_BATCH_ID = @batch_id_in 
				   )
	ELSE
		INSERT @JC
		SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
		FROM dbo.JOB_COMPONENT 
		WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
		AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
		AND ( BCC_ID IS NULL )
		AND JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@job_number_list, ','))
ELSE IF ( @select_by = 5 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND JOB_NUMBER IN (SELECT JOB_NUMBER FROM dbo.JOB_LOG WHERE CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@cmp_id_list, ',')))
ELSE IF ( @select_by = 4 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND JOB_NUMBER IN (SELECT JOB_NUMBER 
						FROM dbo.JOB_LOG 
						WHERE CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_prd_code_list, ',')))
ELSE IF ( @select_by = 3 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND JOB_NUMBER IN (SELECT JOB_NUMBER 
						FROM dbo.JOB_LOG 
						WHERE CL_CODE + '|' + DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_div_code_list, ',')))
ELSE IF ( @select_by = 2 )
	IF ( @batch_id_in > 0 )
		INSERT @JC
		SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
		FROM dbo.JOB_COMPONENT 
		WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
		AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
		AND ( BCC_ID IS NULL )
		AND JOB_NUMBER IN (SELECT JOB_NUMBER 
							FROM dbo.JOB_LOG 
							WHERE CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_list, ',')))
		AND		EXISTS (
					SELECT 1
					FROM dbo.BILL_APPR_HDR bah
						INNER JOIN dbo.BILL_APPR ba ON ( bah.BA_ID = ba.BA_ID )
					WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
					AND ba.BA_BATCH_ID = @batch_id_in 
				   )
	ELSE
		INSERT @JC
		SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
		FROM dbo.JOB_COMPONENT 
		WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
		AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
		AND ( BCC_ID IS NULL )
		AND JOB_NUMBER IN (SELECT JOB_NUMBER 
							FROM dbo.JOB_LOG 
							WHERE CL_CODE IN (SELECT * FROM dbo.udf_split_list(@cl_code_list, ',')))
ELSE IF ( @select_by = 0 ) AND ( @batch_id_in > 0 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND		EXISTS (
					SELECT 1
					FROM dbo.BILL_APPR_HDR bah
						INNER JOIN dbo.BILL_APPR ba ON ( bah.BA_ID = ba.BA_ID )
					WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
					AND ba.BA_BATCH_ID = @batch_id_in 
				   )
ELSE IF ( @select_by = 11 )
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	AND JOB_NUMBER IN (SELECT JOB_NUMBER 
						FROM dbo.JOB_LOG 
						WHERE CL_CODE IN (SELECT CL_CODE FROM dbo.CLIENT 
										  WHERE BILLER_EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@biller_emp_code_list, ','))))
ELSE
	INSERT @JC
	SELECT JOB_NUMBER, JOB_COMPONENT_NBR, EMP_CODE, AB_FLAG, SERVICE_FEE_FLAG
	FROM dbo.JOB_COMPONENT 
	WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
	AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
	AND ( BCC_ID IS NULL )
	
DECLARE @UserCode varchar(100), @EmployeeCode varchar(6)

SELECT @UserCode = UPPER(SUBSTRING(BILLING_USER, 1, LEN(BILLING_USER) - 2))
FROM dbo.BILLING_CMD_CENTER
WHERE BCC_ID = @bcc_id_in

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserCode)

CREATE TABLE #Jobs (
	JOB_NUMBER int NOT NULL
)

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	INSERT #Jobs
	SELECT jl.JOB_NUMBER
	FROM dbo.JOB_LOG jl
		INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
										AND jl.CL_CODE = sc.CL_CODE
										AND jl.DIV_CODE = sc.DIV_CODE
										AND jl.PRD_CODE = sc.PRD_CODE
	WHERE jl.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
ELSE
	INSERT #Jobs
	SELECT jl.JOB_NUMBER
	FROM dbo.JOB_LOG jl
	WHERE jl.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))

DELETE @JC WHERE JOB_NUMBER NOT IN (SELECT JOB_NUMBER FROM #Jobs)

IF ( @job_type = 2 )
	DELETE @JC
	WHERE COALESCE(AB_FLAG, 0) = 0

IF ( @job_type = 3 )
	DELETE @JC
	WHERE COALESCE(SERVICE_FEE_FLAG, 0) <> 1

--select GETDATE() 'before qual'

IF ( @sel_option = 1 )
	DELETE @JC WHERE dbo.advfn_job_has_qual_records( JOB_NUMBER, JOB_COMPONENT_NBR, @emp_date_in, @io_date_in, @ap_post_period_in) <> 1
	
IF ( @sel_option = 2 )
	DELETE @JC WHERE dbo.advfn_is_job_billed_w_cutoffs( JOB_NUMBER, JOB_COMPONENT_NBR, @emp_date_in, @io_date_in, @ap_post_period_in) <> 0

--select GETDATE() 'after qual'
IF @IncludeJobDates = 1
    DELETE jc
    FROM @JC jc INNER JOIN dbo.JOB_COMPONENT J ON jc.JOB_NUMBER = J.JOB_NUMBER AND jc.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR
    WHERE J.MEDIA_BILL_DATE < @job_media_date_from 
    OR J.MEDIA_BILL_DATE > @job_media_date_to
    OR J.MEDIA_BILL_DATE IS NULL

UPDATE dbo.JOB_COMPONENT
		SET BCC_ID = @bcc_id_in,
			SELECTED_BA_ID = CASE
								WHEN @select_by = 8 AND @ba_hdr_id_list IS NOT NULL THEN
										(
										SELECT MIN(bah.BA_ID)
										FROM dbo.BILL_APPR_HDR bah
											INNER JOIN dbo.BILL_APPR ba ON bah.BA_ID = ba.BA_ID
											LEFT OUTER JOIN dbo.BILL_APPR_BATCH bab ON ba.BA_BATCH_ID = bab.BA_BATCH_ID
										WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
										AND bah.AR_INV_NBR IS NULL
										AND bah.APPR_STATUS IS NULL
										AND (bab.BA_BATCH_ID IS NULL OR bab.APPROVED = 1)
										AND BA_HDR_ID IN (SELECT * FROM dbo.udf_split_list(@ba_hdr_id_list, ','))
										)
								WHEN @batch_id_in > 0 THEN
										(
										SELECT MIN(bah.BA_ID)
										FROM dbo.BILL_APPR_HDR bah
											INNER JOIN dbo.BILL_APPR ba ON bah.BA_ID = ba.BA_ID
											LEFT OUTER JOIN dbo.BILL_APPR_BATCH bab ON ba.BA_BATCH_ID = bab.BA_BATCH_ID
										WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
										AND bah.AR_INV_NBR IS NULL
										AND bah.APPR_STATUS IS NULL
										AND ba.BA_BATCH_ID = @batch_id_in
										AND (bab.BA_BATCH_ID IS NULL OR bab.APPROVED = 1)
										)
								ELSE
										(
										SELECT MIN(bah.BA_ID)
										FROM dbo.BILL_APPR_HDR bah
											INNER JOIN dbo.BILL_APPR ba ON bah.BA_ID = ba.BA_ID
											LEFT OUTER JOIN dbo.BILL_APPR_BATCH bab ON ba.BA_BATCH_ID = bab.BA_BATCH_ID
										WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR AND bah.PROCESSED = 0
										AND bah.AR_INV_NBR IS NULL
										AND bah.APPR_STATUS IS NULL
										AND (bab.BA_BATCH_ID IS NULL OR bab.APPROVED = 1)
										)
								END
WHERE	EXISTS (
				SELECT 1
				FROM @JC
				WHERE JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER AND JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR
				)
--select GETDATE() 'after update JC'

-- A/P *********************************************************************************************************************************************
UPDATE dbo.AP_PRODUCTION
	SET BCC_ID = @bcc_id_in,
		BILLING_USER = ( CASE BILLING_USER WHEN @billing_user THEN BILLING_USER ELSE NULL END )
WHERE	( BCC_ID IS NULL )
--AND		( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL )
--AND		( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL )
AND		EXISTS (SELECT 1
				FROM dbo.JOB_COMPONENT jc
				WHERE	jc.JOB_NUMBER = dbo.AP_PRODUCTION.JOB_NUMBER
				AND		jc.JOB_COMPONENT_NBR = dbo.AP_PRODUCTION.JOB_COMPONENT_NBR
				AND		( jc.BILLING_USER IS NULL OR jc.BILLING_USER = @billing_user )
				AND		( jc.BCC_ID = @bcc_id_in )
				--AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.AP_PRODUCTION.AB_FLAG = 6 )
				)
AND		POST_PERIOD <= @ap_post_period_in
--select GETDATE() 'after update AP'
-- E/T *********************************************************************************************************************************************
UPDATE dbo.EMP_TIME_DTL
	SET BCC_ID = @bcc_id_in,
		BILLING_USER = ( CASE BILLING_USER WHEN @billing_user THEN BILLING_USER ELSE NULL END )
WHERE	( BCC_ID IS NULL )
--AND		( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL )
--AND		( EMP_NON_BILL_FLAG = 0 OR EMP_NON_BILL_FLAG IS NULL )
-- Criteria that uses the EMP_TIME table
AND		EXISTS (
				SELECT 1
				FROM dbo.EMP_TIME et
				WHERE et.ET_ID = dbo.EMP_TIME_DTL.ET_ID
				AND EMP_DATE <= @emp_date_in
				)
-- Criteria that uses the JOB_COMPONENT table
AND		EXISTS (
				SELECT 1
				FROM dbo.JOB_COMPONENT jc
				WHERE jc.JOB_NUMBER = dbo.EMP_TIME_DTL.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR = dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR
				AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = @billing_user )
				AND ( jc.BCC_ID = @bcc_id_in )
				--AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.EMP_TIME_DTL.AB_FLAG = 6 )
				)
--select GETDATE() 'after update ET'
-- I/O *********************************************************************************************************************************************
UPDATE dbo.INCOME_ONLY
	SET BCC_ID = @bcc_id_in,
		BILLING_USER = ( CASE BILLING_USER WHEN @billing_user THEN BILLING_USER ELSE NULL END )
WHERE	( BCC_ID IS NULL )
--AND		( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL )
AND		IO_INV_DATE <= @io_date_in
--AND		( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL )
-- Criteria that uses the JOB_COMPONENT table
AND		EXISTS (
				SELECT 1
				FROM dbo.JOB_COMPONENT jc
				WHERE jc.JOB_NUMBER = dbo.INCOME_ONLY.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR = dbo.INCOME_ONLY.JOB_COMPONENT_NBR
				AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = @billing_user )
				AND ( jc.BCC_ID = @bcc_id_in )
				--AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.INCOME_ONLY.AB_FLAG = 6 )
				)
--select GETDATE() 'after update IO'
-- A/B *********************************************************************************************************************************************
UPDATE dbo.ADVANCE_BILLING
	SET BCC_ID = @bcc_id_in,
		BILLING_USER = ( CASE BILLING_USER WHEN @billing_user THEN BILLING_USER ELSE NULL END )
WHERE	( BCC_ID IS NULL )
--AND		( AB_FLAG <> 3 OR AB_FLAG IS NULL )
-- Criteria that uses the JOB_COMPONENT table
AND		EXISTS (
				SELECT 1
				FROM dbo.JOB_COMPONENT jc
				WHERE jc.JOB_NUMBER = dbo.ADVANCE_BILLING.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR = dbo.ADVANCE_BILLING.JOB_COMPONENT_NBR
				AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = @billing_user )
				AND ( jc.BCC_ID = @bcc_id_in )
				)
--select GETDATE() 'after update AB'
-- I/R *********************************************************************************************************************************************
UPDATE dbo.INCOME_REC
	SET BCC_ID = @bcc_id_in,
		BILLING_USER = ( CASE BILLING_USER WHEN @billing_user THEN BILLING_USER ELSE NULL END )
WHERE	( BCC_ID IS NULL )
--AND		AB_FLAG IN ( 6, 7 )
-- Criteria that uses the JOB_COMPONENT table
AND		EXISTS (
				SELECT 1
				FROM dbo.JOB_COMPONENT jc
				WHERE jc.JOB_NUMBER = dbo.INCOME_REC.JOB_NUMBER
				AND jc.JOB_COMPONENT_NBR = dbo.INCOME_REC.JOB_COMPONENT_NBR
				AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = @billing_user )
				AND ( jc.BCC_ID = @bcc_id_in )
				)
--select GETDATE() 'after update IR'


