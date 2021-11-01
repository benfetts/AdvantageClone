
CREATE PROCEDURE [dbo].[advsp_update_billing_cmd_center_prod] @bcc_id_in integer, @billing_user varchar(100), @select_by smallint, 
	@cl_code_in varchar(6), @div_code_in varchar(6), @prd_code_in varchar(6), @sel_option smallint, 
	@emp_date_in varchar(10), @io_date_in varchar(10), @ab_date_in varchar(10), @ap_post_period_in varchar(6), 
	@cmp_id_in integer, @job_number_in integer, @job_comp_in smallint, @batch_id_in integer, @ba_id_in integer,
	@acct_exec_in varchar(6), @job_cli_ref_in varchar(30), @job_type smallint, @sc_code varchar(6), @selected_jobs integer OUTPUT, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @sql_upd_ap varchar(4000)
DECLARE @sql_upd_et varchar(4000)
DECLARE @sql_upd_io varchar(4000)
DECLARE @sql_upd_ab varchar(4000)
DECLARE @sql_upd_ir varchar(4000)
DECLARE @sql_upd_jc varchar(4000)

SELECT @ret_val = 0

-- Job Component *********************************************************************************************************************************************
SELECT @sql_upd_jc = ''

SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + 'UPDATE dbo.JOB_COMPONENT '
SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   SET BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ', '
IF ( @select_by = 8 ) AND ( @ba_id_in > 0 )
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   SELECTED_BA_ID = ' + CAST( @ba_id_in AS varchar(6)) + ' '
ELSE
BEGIN
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '		SELECTED_BA_ID = ( SELECT TOP 1 bah.BA_ID '		
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '						     FROM dbo.BILL_APPR_HDR bah '
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				   INNER JOIN dbo.BILL_APPR ba '		
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				           ON bah.BA_ID = ba.BA_ID '		
	END 
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					        WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER '		
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					          AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					          AND bah.AR_INV_NBR IS NULL '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					          AND bah.APPR_STATUS IS NULL '
	IF ( @batch_id_in > 0 )
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '						  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '						 ORDER BY bah.BA_ID DESC ) '
END	
SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + ' WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) '
SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) ' 
SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	  AND ( BCC_ID IS NULL ) '
IF ( @select_by = 6 ) OR ( @select_by = 7 ) OR ( @select_by = 8 )
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 

IF ( @select_by = 7 ) OR ( @select_by = 8 )
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 

IF ( @select_by = 10 )
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	  AND EMP_CODE = ''' + @acct_exec_in + ''' '

-- Criteria that uses the JOB_LOG table
IF ( @select_by = 2 ) OR ( @select_by = 3 ) OR ( @select_by = 4 ) OR ( @select_by = 5 ) OR ( @select_by = 9 )
BEGIN
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND EXISTS ( SELECT * '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					 FROM dbo.JOB_LOG jl '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					WHERE jl.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER '
	IF ( @select_by = 9 )
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				   AND jl.SC_CODE = ''' + @sc_code + ''' '
	ELSE IF ( @select_by = 5 )
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				   AND jl.CMP_IDENTIFIER = ' + CAST( @cmp_id_in AS varchar(6)) + ' '
	ELSE
	BEGIN
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				   AND jl.CL_CODE = ''' + @cl_code_in + ''' '
		IF ( @select_by > 2 )
		BEGIN
			SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				   AND jl.DIV_CODE = ''' + @div_code_in + ''' '
			IF ( @select_by > 3 )
				SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				   AND jl.PRD_CODE = ''' + @prd_code_in + ''' '
		END
	END	
	-- Close paren for JOB_LOG subquery
	SELECT @sql_upd_jc = @sql_upd_jc + ' ) '
END

-- Criteria that uses the BILL_APPR_HDR table
IF ( @select_by = 8 )
BEGIN
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND EXISTS ( SELECT * '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					 FROM dbo.BILL_APPR_HDR bah '
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '		   INNER JOIN dbo.BILL_APPR ba '
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '		           ON ( bah.BA_ID = ba.BA_ID ) '
	END
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					  AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					  AND bah.BA_ID = ' + CAST( @ba_id_in AS varchar(6)) + ' '
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' '
	END
	SELECT @sql_upd_jc = @sql_upd_jc + '						  ) '
END

-- Criteria that uses the BILL_APPR table
IF ( @batch_id_in > 0 ) AND ( @select_by IN ( 0, 2, 6, 7 ))
BEGIN
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND EXISTS ( SELECT * '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					 FROM dbo.BILL_APPR_HDR bah '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '			   INNER JOIN dbo.BILL_APPR ba '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					   ON ( bah.BA_ID = ba.BA_ID ) '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '				    WHERE bah.JOB_NUMBER = dbo.JOB_COMPONENT.JOB_NUMBER '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					  AND bah.JOB_COMPONENT_NBR = dbo.JOB_COMPONENT.JOB_COMPONENT_NBR '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '					  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' '
	SELECT @sql_upd_jc = @sql_upd_jc + '						 ) '	 
END

IF ( @sel_option = 1 )
BEGIN
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	 AND ( dbo.advfn_job_has_qual_records( dbo.JOB_COMPONENT.JOB_NUMBER, dbo.JOB_COMPONENT.JOB_COMPONENT_NBR, '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '''' + CONVERT( varchar(10), @emp_date_in, 101 ) + ''', '		
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '''' + CONVERT( varchar(10), @io_date_in, 101 ) + ''', ' 
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '''' + @ap_post_period_in + ''' ) = 1 )'	
END 
	
IF ( @sel_option = 2 )
BEGIN
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	 AND ( dbo.advfn_is_job_billed_w_cutoffs( dbo.JOB_COMPONENT.JOB_NUMBER, dbo.JOB_COMPONENT.JOB_COMPONENT_NBR, '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '''' + CONVERT( varchar(10), @emp_date_in, 101 ) + ''', '		
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '''' + CONVERT( varchar(10), @io_date_in, 101 ) + ''', ' 
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '''' + @ap_post_period_in + ''' ) = 0 )'
END

IF ( @job_type = 2 )
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	 AND ( AB_FLAG <> 0 AND AB_FLAG IS NOT NULL ) '

IF ( @job_type = 3 )
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	 AND ( SERVICE_FEE_TYPE_ID <> 0 AND SERVICE_FEE_TYPE_ID IS NOT NULL ) '

-- A/P *********************************************************************************************************************************************
SELECT @sql_upd_ap = ''
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + 'UPDATE dbo.AP_PRODUCTION '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   SET BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ', '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '		  BILLING_USER = ( CASE BILLING_USER WHEN ''' + @billing_user + ''' THEN BILLING_USER ELSE NULL END ) '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + ' WHERE ( BCC_ID IS NULL ) '
--SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + ' AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND ( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL ) '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND ( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL ) '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND POST_PERIOD <= ''' + @ap_post_period_in + ''' '

-- Criteria that uses the JOB_COMPONENT table
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND EXISTS ( SELECT * ' 
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.AP_PRODUCTION.JOB_NUMBER '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.AP_PRODUCTION.JOB_COMPONENT_NBR '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND ( jc.BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ' ) '
SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.AP_PRODUCTION.AB_FLAG = 6 ) '
	
-- Close paren for JOB_COMPONENT subquery
SELECT @sql_upd_ap = @sql_upd_ap + ' ) '	 

-- E/T *********************************************************************************************************************************************
SELECT @sql_upd_et = ''
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + 'UPDATE dbo.EMP_TIME_DTL '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   SET BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ', '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '		  BILLING_USER = ( CASE BILLING_USER WHEN ''' + @billing_user + ''' THEN BILLING_USER ELSE NULL END ) '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + ' WHERE ( BCC_ID IS NULL ) '
--SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + ' AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND ( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL ) '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND ( EMP_NON_BILL_FLAG = 0 OR EMP_NON_BILL_FLAG IS NULL ) '
	
-- Criteria that uses the EMP_TIME table
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND EXISTS ( SELECT * ' 
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					 FROM dbo.EMP_TIME et '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					WHERE et.ET_ID = dbo.EMP_TIME_DTL.ET_ID '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND EMP_DATE <= ''' + @emp_date_in + ''' '

-- Close paren for EMP_TIME subquery
SELECT @sql_upd_et = @sql_upd_et + ' ) '	 

-- Criteria that uses the JOB_COMPONENT table
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND EXISTS ( SELECT * ' 
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.EMP_TIME_DTL.JOB_NUMBER '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND ( jc.BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ' ) '
SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.EMP_TIME_DTL.AB_FLAG = 6 ) '

-- Close paren for JOB_COMPONENT subquery
SELECT @sql_upd_et = @sql_upd_et + ' ) '	 

-- I/O *********************************************************************************************************************************************
SELECT @sql_upd_io = ''
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + 'UPDATE dbo.INCOME_ONLY '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   SET BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ', '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '		  BILLING_USER = ( CASE BILLING_USER WHEN ''' + @billing_user + ''' THEN BILLING_USER ELSE NULL END ) '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + ' WHERE ( BCC_ID IS NULL ) '
--SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + ' AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND ( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL ) '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND IO_INV_DATE <= ''' + @io_date_in + ''' '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND ( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL ) '

-- Criteria that uses the JOB_COMPONENT table
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND EXISTS ( SELECT * ' 
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.INCOME_ONLY.JOB_NUMBER '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.INCOME_ONLY.JOB_COMPONENT_NBR '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND ( jc.BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ' ) '
SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.INCOME_ONLY.AB_FLAG = 6 ) '

-- Close paren for JOB_COMPONENT subquery
SELECT @sql_upd_io = @sql_upd_io + ' ) '	 

-- A/B *********************************************************************************************************************************************
SELECT @sql_upd_ab = ''
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + 'UPDATE dbo.ADVANCE_BILLING '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   SET BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ', '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '		  BILLING_USER = ( CASE BILLING_USER WHEN ''' + @billing_user + ''' THEN BILLING_USER ELSE NULL END ) '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + ' WHERE ( BCC_ID IS NULL ) '
--SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + ' AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL ) '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND BILL_DATE <= ''' + @ab_date_in + ''' '

-- Criteria that uses the JOB_COMPONENT table
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND EXISTS ( SELECT * ' 
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.ADVANCE_BILLING.JOB_NUMBER '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.ADVANCE_BILLING.JOB_COMPONENT_NBR '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND ( jc.BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ' ) '
	
-- Close paren for JOB_COMPONENT subquery
SELECT @sql_upd_ab = @sql_upd_ab + ' ) '	 

-- I/R *********************************************************************************************************************************************
SELECT @sql_upd_ir = ''
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + 'UPDATE dbo.INCOME_REC '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   SET BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ', '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '		  BILLING_USER = ( CASE BILLING_USER WHEN ''' + @billing_user + ''' THEN BILLING_USER ELSE NULL END ) '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + ' WHERE ( BCC_ID IS NULL ) '
--SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + ' AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND AB_FLAG IN ( 6, 7 ) '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND BILL_DATE <= ''' + @ab_date_in + ''' '

-- Criteria that uses the JOB_COMPONENT table
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND EXISTS ( SELECT * ' 
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.INCOME_REC.JOB_NUMBER '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.INCOME_REC.JOB_COMPONENT_NBR '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND ( jc.BCC_ID = ' + CAST( @bcc_id_in AS varchar(8)) + ' ) '

-- Close paren for JOB_COMPONENT subquery
SELECT @sql_upd_ir = @sql_upd_ir + ' ) '	 

-- ***************************************************************************************************************************************
-- Execute the SQL statements
-- ***************************************************************************************************************************************

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_jc )
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_ap )
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_et )
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_io )
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_ab )
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_ir )
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	SELECT @selected_jobs = ( SELECT COUNT(*) FROM dbo.BILLING_CMD_CENTER WHERE BCC_ID = @bcc_id_in )
	SELECT @ret_val = @@ERROR
END

--SELECT @sql_upd_ap
--SELECT @sql_upd_et
--SELECT @sql_upd_io
--SELECT @sql_upd_ab
--SELECT @sql_upd_ir
--SELECT @sql_upd_jc
--SELECT @ret_val
