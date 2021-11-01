CREATE PROCEDURE [dbo].[advsp_bill_select_mark_items] 
	@billing_user varchar(100),	@inv_date_in smalldatetime, @post_period_in varchar(6), @ap_post_period_in varchar(8), 
	@emp_date_in smalldatetime, @io_date_in smalldatetime, @job_number_in integer, 
	@job_comp_in smallint, @batch_id_in integer, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @sql_upd_ap varchar(4000)
DECLARE @sql_upd_et varchar(4000)
DECLARE @sql_upd_io varchar(4000)
DECLARE @sql_upd_ab varchar(4000)
DECLARE @sql_upd_ir varchar(4000)
DECLARE @sql_upd_jc varchar(4000)
DECLARE @sql_del_0t varchar(4000)
DECLARE @sql_upd_billing varchar(4000)
DECLARE @select_by smallint, @ap_rows integer, @et_rows integer, @io_rows integer 
DECLARE @ab_rows integer, @ir_rows integer, @jc_rows integer, @bcc_flag smallint
DECLARE @selection smallint, @adjustments smallint, @inv_assign smallint, @inv_print smallint 
DECLARE	@inv_date smalldatetime, @post_period varchar(6), @production smallint, @reconcile_status tinyint
DECLARE @emp_date_cutoff smalldatetime, @ap_pp_cutoff varchar(8), @io_date_cutoff smalldatetime
DECLARE @ProductionSetupComplete smallint, @BillMediaType smallint, @IsProductionSelectionLocked bit
SELECT @ret_val = 0
SELECT @sql_upd_billing = ''

SELECT @IsProductionSelectionLocked = PROD_LOCK_SELECTION
FROM dbo.BILLING_CMD_CENTER
WHERE BILLING_USER = @billing_user

SELECT @reconcile_status = ( SELECT dbo.advfn_adv_bill_reconcile_status ( @job_number_in, @job_comp_in ))

DECLARE billing_cursor CURSOR FOR
 SELECT SELECTION, ADJUSTMENTS, INV_ASSIGN, INV_PRINT, INV_DATE, 
		POST_PERIOD, SELECT_BY, PRODUCTION, P_EMPTIME_DATE, 
		P_CUTOFF_PP, P_INCOMEONLY_DATE, BCC_FLAG 
   FROM dbo.BILLING 
  WHERE BILLING_USER = @billing_user
  FOR READ ONLY

OPEN billing_cursor
FETCH NEXT FROM billing_cursor INTO @selection, @adjustments, @inv_assign, @inv_print, 
	@inv_date, @post_period, @select_by, @production, @emp_date_cutoff, @ap_pp_cutoff,
	@io_date_cutoff, @bcc_flag 

IF ( @@FETCH_STATUS = 0 )
BEGIN
	IF ( @inv_assign = 1 )
		SELECT @ret_val = -3
	ELSE
	BEGIN
		IF ( @bcc_flag = 0 )
			SELECT @ret_val = -4
		ELSE
		BEGIN
			--IF ( @production = 0 OR @production IS NULL )
			--BEGIN
				-- If production is already selected, do not change those values
				SELECT @select_by = 7
				SELECT @emp_date_cutoff = @emp_date_in
				SELECT @ap_pp_cutoff = @ap_post_period_in
				SELECT @io_date_cutoff = @io_date_in
				SELECT @inv_date = @inv_date_in
				SELECT @post_period = @post_period_in
			--END				

			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + 'UPDATE dbo.BILLING '
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	SET SELECT_BY = ' + CAST( @select_by AS varchar(1)) + ', '
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		PRODUCTION = 1, '
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		P_EMPTIME_DATE = ''' + CONVERT( varchar(10), @emp_date_cutoff, 101 ) + ''', '
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		P_CUTOFF_PP = ''' + @ap_pp_cutoff + ''', '
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		P_INCOMEONLY_DATE = ''' + CONVERT( varchar(10), @io_date_cutoff, 101 ) + ''' '
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' '
			  
			--SELECT @ret_val = @@ERROR				
		END	
	END
END
ELSE
BEGIN
	SELECT @select_by = 7
	SELECT @emp_date_cutoff = @emp_date_in
	SELECT @ap_pp_cutoff = @ap_post_period_in
	SELECT @io_date_cutoff = @io_date_in
	SELECT @inv_date = @inv_date_in
	SELECT @post_period = @post_period_in
	
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	INSERT INTO dbo.BILLING ( BILLING_USER, SELECTION, APPROVAL_OL, '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		APPROVAL_PRN, ADJUSTMENTS, INV_ASSIGN, INV_PRINT, INV_DATE, '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		POST_PERIOD, SELECT_BY, MEDIA, PRODUCTION, SERVICE_FEES, '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		FIRST_INV, LAST_INV, P_EMPTIME_DATE, P_CUTOFF_PP, M_SELECT_BY,'
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		M_CUTOFF_DATE, NEWSPAPER, MAGAZINE, RADIO, TELEVISION, OUTDOOR,'
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		M_CUTOFF_MONTH1, M_CUTOFF_MONTH2, P_INCOMEONLY_DATE, '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		INTERNET, INC_NO_DTL, AB_JOBS_ONLY, BCC_FLAG, INV_PROCESSED, COOP_SAVED ) '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	 VALUES ( ''' + @billing_user + ''', 1, NULL, NULL, NULL, NULL, NULL, '  
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + CONVERT( varchar(10), @inv_date, 101 ) + ''', '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + @post_period + ''', ' + CAST( @select_by AS varchar(1)) + ', 0, 1, 0, '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  NULL, NULL, ''' + CONVERT( varchar(10), @emp_date_cutoff, 101 ) + ''', '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + @ap_pp_cutoff + ''', 1, NULL, 1, 1, 1, 1, 1, NULL, NULL, '
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + CONVERT( varchar(10), @io_date_cutoff, 101 ) + ''', '	        
	SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  1, NULL, NULL, 1, 0, 0 ) '	        
	
	--SELECT @ret_val = @@ERROR							                          
END

CLOSE billing_cursor
DEALLOCATE billing_cursor

SELECT @ProductionSetupComplete = PROD_SETUP_COMPLETE, @BillMediaType = A.BILL_MEDIA_TYPE
FROM dbo.PRODUCT P
	INNER JOIN dbo.JOB_LOG J ON J.CL_CODE = P.CL_CODE AND J.DIV_CODE = P.DIV_CODE AND J.PRD_CODE = P.PRD_CODE
	INNER JOIN dbo.AGENCY A ON (1=1)
WHERE J.JOB_NUMBER = @job_number_in

IF @BillMediaType = 1 And @ProductionSetupComplete = 0
	SET @ret_val = -7

SELECT @select_by = 7

IF ( @ret_val = 0 )
BEGIN
	
	-- A/P *********************************************************************************************************************************************
	SELECT @sql_upd_ap = ''
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + 'UPDATE dbo.AP_PRODUCTION '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   SET BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + ' WHERE AR_INV_NBR IS NULL '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND ( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL ) '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND ( AP_PROD_BILL_HOLD = 0 OR AP_PROD_BILL_HOLD IS NULL ) '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND ( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL ) '

	IF @IsProductionSelectionLocked = 1
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND BCC_ID IS NOT NULL '
	
	IF ( @reconcile_status = 0 )
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND POST_PERIOD <= ''' + @ap_pp_cutoff + ''' '
		
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND EXISTS ( SELECT * ' 
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.AP_PRODUCTION.JOB_NUMBER '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.AP_PRODUCTION.JOB_COMPONENT_NBR '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND jc.JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.AP_PRODUCTION.AB_FLAG = 6 ) '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND ( jc.JOB_BILL_HOLD = 0 OR jc.JOB_BILL_HOLD IS NULL )) '

	-- Criteria that uses the BILL_APPR tables
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND EXISTS ( SELECT * '
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					 FROM dbo.BILL_APPR_HDR bah '
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '			   INNER JOIN dbo.BILL_APPR ba '
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					   ON ( bah.BA_ID = ba.BA_ID ) '
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					WHERE bah.JOB_NUMBER = dbo.AP_PRODUCTION.JOB_NUMBER '
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND bah.JOB_COMPONENT_NBR = dbo.AP_PRODUCTION.JOB_COMPONENT_NBR '
		SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '					  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' ) '
	END

	-- E/T *********************************************************************************************************************************************
	SELECT @sql_upd_et = ''
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + 'UPDATE dbo.EMP_TIME_DTL '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   SET BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + ' WHERE AR_INV_NBR IS NULL '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND ( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL ) '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND ( BILL_HOLD_FLG IS NULL OR BILL_HOLD_FLG = 0 ) '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND ( EMP_NON_BILL_FLAG IS NULL OR EMP_NON_BILL_FLAG = 0 ) '
	
	IF @IsProductionSelectionLocked = 1
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND BCC_ID IS NOT NULL '
	
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND EXISTS ( SELECT * ' 
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					 FROM dbo.EMP_TIME et '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '				    WHERE et.ET_ID = dbo.EMP_TIME_DTL.ET_ID '
	
	IF ( @reconcile_status = 0 )
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND EMP_DATE <= ''' + CONVERT( varchar(10), @emp_date_cutoff, 101 ) + ''' '
		
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + ' ) AND EXISTS ( SELECT * ' 
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.EMP_TIME_DTL.JOB_NUMBER '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND jc.JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.EMP_TIME_DTL.AB_FLAG = 6 ) '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND ( jc.JOB_BILL_HOLD = 0 OR jc.JOB_BILL_HOLD IS NULL )) '

	-- Criteria that uses the BILL_APPR tables
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND EXISTS ( SELECT * '
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					 FROM dbo.BILL_APPR_HDR bah '
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '			   INNER JOIN dbo.BILL_APPR ba '
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					   ON ( bah.BA_ID = ba.BA_ID ) '
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					WHERE bah.JOB_NUMBER = dbo.EMP_TIME_DTL.JOB_NUMBER '
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND bah.JOB_COMPONENT_NBR = dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR '
		SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '					  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' ) '
	END

	-- I/O *********************************************************************************************************************************************
	SELECT @sql_upd_io = ''
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + 'UPDATE dbo.INCOME_ONLY '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   SET BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + ' WHERE AR_INV_NBR IS NULL '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND ( AB_FLAG IN ( 0, 1, 6 ) OR AB_FLAG IS NULL ) '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND ( NON_BILL_FLAG IS NULL OR NON_BILL_FLAG = 0 ) ' 
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND ( BILL_HOLD_FLAG IS NULL OR BILL_HOLD_FLAG = 0 ) '
	
	IF @IsProductionSelectionLocked = 1
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND BCC_ID IS NOT NULL '
		
	IF ( @reconcile_status = 0 )
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND IO_INV_DATE <= ''' + CONVERT( varchar(10), @io_date_cutoff, 101 ) + ''' '
		
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND EXISTS ( SELECT * ' 
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.INCOME_ONLY.JOB_NUMBER '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.INCOME_ONLY.JOB_COMPONENT_NBR '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND jc.JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND ( jc.AB_FLAG <> 2 OR jc.AB_FLAG IS NULL OR dbo.INCOME_ONLY.AB_FLAG = 6 ) '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND ( JOB_BILL_HOLD = 0 OR JOB_BILL_HOLD IS NULL )) '

	-- Criteria that uses the BILL_APPR tables
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND EXISTS ( SELECT * '
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					 FROM dbo.BILL_APPR_HDR bah '
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '			   INNER JOIN dbo.BILL_APPR ba '
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					   ON ( bah.BA_ID = ba.BA_ID ) '
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					WHERE bah.JOB_NUMBER = dbo.INCOME_ONLY.JOB_NUMBER '
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND bah.JOB_COMPONENT_NBR = dbo.INCOME_ONLY.JOB_COMPONENT_NBR '
		SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '					  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' ) '
	END

	-- A/B *********************************************************************************************************************************************
	SELECT @sql_upd_ab = ''
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + 'UPDATE dbo.ADVANCE_BILLING '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   SET BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + ' WHERE AR_INV_NBR IS NULL '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND ( AB_FLAG <> 3 OR AB_FLAG IS NULL ) '
	
	--IF @IsProductionSelectionLocked = 1
	--	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND BCC_ID IS NOT NULL '
		
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND EXISTS ( SELECT * ' 
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.ADVANCE_BILLING.JOB_NUMBER '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.ADVANCE_BILLING.JOB_COMPONENT_NBR '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND jc.JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' )) '

	-- Criteria that uses the BILL_APPR tables
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND EXISTS ( SELECT * '
		SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					 FROM dbo.BILL_APPR_HDR bah '
		SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '			   INNER JOIN dbo.BILL_APPR ba '
		SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					   ON ( bah.BA_ID = ba.BA_ID ) '
		SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					WHERE bah.JOB_NUMBER = dbo.ADVANCE_BILLING.JOB_NUMBER '
		SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND bah.JOB_COMPONENT_NBR = dbo.ADVANCE_BILLING.JOB_COMPONENT_NBR '
		SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '					  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' ) '
	END

	-- I/R *********************************************************************************************************************************************
	SELECT @sql_upd_ir = ''
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + 'UPDATE dbo.INCOME_REC '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   SET BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + ' WHERE AR_INV_NBR IS NULL '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND AB_FLAG IN ( 6, 7 ) '
	
	IF @IsProductionSelectionLocked = 1
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND BCC_ID IS NOT NULL '

	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND EXISTS ( SELECT * ' 
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					 FROM dbo.JOB_COMPONENT jc '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					WHERE jc.JOB_NUMBER = dbo.INCOME_REC.JOB_NUMBER '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND jc.JOB_COMPONENT_NBR = dbo.INCOME_REC.JOB_COMPONENT_NBR '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND jc.JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND ( jc.BILLING_USER IS NULL OR jc.BILLING_USER = ''' + @billing_user + ''' )) '

	-- Criteria that uses the BILL_APPR tables
	IF ( @batch_id_in > 0 )
	BEGIN
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND EXISTS ( SELECT * '
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					 FROM dbo.BILL_APPR_HDR bah '
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '			   INNER JOIN dbo.BILL_APPR ba '
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					   ON ( bah.BA_ID = ba.BA_ID ) '
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					WHERE bah.JOB_NUMBER = dbo.INCOME_REC.JOB_NUMBER '
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND bah.JOB_COMPONENT_NBR = dbo.INCOME_REC.JOB_COMPONENT_NBR '
		SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '					  AND ba.BA_BATCH_ID = ' + CAST( @batch_id_in AS varchar(6)) + ' ) ' 
	END

	-- Job Component *********************************************************************************************************************************************
	SELECT @sql_upd_jc = ''
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + 'UPDATE dbo.JOB_COMPONENT '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   SET BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + ' WHERE JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	  AND ( BILLING_USER IS NULL OR BILLING_USER = ''' + @billing_user + ''' ) '

END

-- ***************************************************************************************************************************************
-- Execute the update statements
-- ***************************************************************************************************************************************
IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_ap )
	SELECT @ret_val = @@ERROR, @ap_rows = @@ROWCOUNT
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_et )
	SELECT @ret_val = @@ERROR, @et_rows = @@ROWCOUNT
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_io )
	SELECT @ret_val = @@ERROR, @io_rows = @@ROWCOUNT
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_ab )
	SELECT @ret_val = @@ERROR, @ab_rows = @@ROWCOUNT
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_ir )
	SELECT @ret_val = @@ERROR, @ir_rows = @@ROWCOUNT
END

IF ( @ret_val = 0 )
BEGIN
	IF (( @ap_rows + @et_rows + @io_rows + @ab_rows + @ir_rows ) > 0 )
	BEGIN
		EXECUTE ( @sql_upd_jc )
		SELECT @ret_val = @@ERROR, @jc_rows = @@ROWCOUNT
	END
	ELSE
		SELECT @ret_val = -1	
END

IF ( @ret_val = 0 )
BEGIN
	IF (( @ap_rows + @et_rows + @io_rows + @ab_rows + @ir_rows ) > 0 )
	BEGIN
		EXECUTE ( @sql_upd_billing )
		SELECT @ret_val = @@ERROR
	END
END

IF ( @ret_val = 0 )
BEGIN
	SELECT @sql_del_0t = ''
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	DELETE FROM dbo.EMP_TIME_DTL_CMTS '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	 WHERE ET_SOURCE = ''D'' '		
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	   AND EXISTS( SELECT * '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					 FROM dbo.EMP_TIME_DTL etd'	
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					WHERE etd.ET_ID = dbo.EMP_TIME_DTL_CMTS.ET_ID '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.SEQ_NBR = dbo.EMP_TIME_DTL_CMTS.SEQ_NBR '		
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.ET_DTL_ID = dbo.EMP_TIME_DTL_CMTS.ET_DTL_ID '			
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.BILLING_USER = ''' + @billing_user + ''' '	
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.AR_INV_NBR IS NULL '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.TOTAL_COST = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.TOTAL_BILL = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.EXT_MARKUP_AMT = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.EXT_STATE_RESALE = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.EXT_COUNTY_RESALE = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.EXT_CITY_RESALE = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND etd.LINE_TOTAL = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '					  AND ( etd.EMP_HOURS = 0 OR etd.EMP_HOURS IS NULL )) '	

	EXECUTE ( @sql_del_0t )
	SELECT @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	SELECT @sql_del_0t = ''
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	DELETE FROM dbo.EMP_TIME_DTL '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	 WHERE BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	   AND AR_INV_NBR IS NULL '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	   AND TOTAL_COST = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '    AND TOTAL_BILL = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '    AND EXT_MARKUP_AMT = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '    AND EXT_STATE_RESALE = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '    AND EXT_COUNTY_RESALE = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '    AND EXT_CITY_RESALE = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '    AND LINE_TOTAL = 0 '
	SELECT @sql_del_0t = @sql_del_0t + CHAR(13) + '	   AND ( EMP_HOURS = 0 OR EMP_HOURS IS NULL ) '	

	EXECUTE ( @sql_del_0t )
	SELECT @ret_val = @@ERROR
END

--SELECT @sql_upd_ap
--SELECT @sql_upd_et
--SELECT @sql_upd_io
--SELECT @sql_upd_ab
--SELECT @sql_upd_ir
--SELECT @sql_upd_jc
--SELECT @ret_val
