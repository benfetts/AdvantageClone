
CREATE PROCEDURE [dbo].[advsp_bill_select_unmark_items] 
	@billing_user varchar(100),	@job_number_in integer,	@job_comp_in smallint, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @sql_upd_ap varchar(4000)
DECLARE @sql_upd_et varchar(4000)
DECLARE @sql_upd_io varchar(4000)
DECLARE @sql_upd_ab varchar(4000)
DECLARE @sql_upd_ir varchar(4000)
DECLARE @sql_upd_jc varchar(4000)
DECLARE @sql_upd_ar varchar(4000)

DECLARE @select_by smallint, @ap_rows integer, @et_rows integer, @io_rows integer 
DECLARE @ab_rows integer, @ir_rows integer, @jc_rows integer, @bcc_flag smallint
DECLARE @inv_assign smallint 

SELECT @ret_val = 0

DECLARE billing_cursor CURSOR FOR
 SELECT INV_ASSIGN 
   FROM dbo.BILLING 
  WHERE BILLING_USER = @billing_user
  FOR READ ONLY

OPEN billing_cursor
FETCH NEXT FROM billing_cursor INTO @inv_assign 

IF ( @@FETCH_STATUS = 0 )
BEGIN
	IF ( @inv_assign = 1 )
		SELECT @ret_val = -3
END

CLOSE billing_cursor
DEALLOCATE billing_cursor

IF ( @ret_val = 0 )
BEGIN
	
	-- A/P *********************************************************************************************************************************************
	SELECT @sql_upd_ap = ''
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + 'UPDATE dbo.AP_PRODUCTION '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   SET BILLING_USER = NULL '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ap = @sql_upd_ap + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 

	-- E/T *********************************************************************************************************************************************
	SELECT @sql_upd_et = ''
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + 'UPDATE dbo.EMP_TIME_DTL '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   SET BILLING_USER = NULL '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_et = @sql_upd_et + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 

	-- I/O *********************************************************************************************************************************************
	SELECT @sql_upd_io = ''
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + 'UPDATE dbo.INCOME_ONLY '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   SET BILLING_USER = NULL '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_io = @sql_upd_io + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 

	-- A/B *********************************************************************************************************************************************
	SELECT @sql_upd_ab = ''
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + 'UPDATE dbo.ADVANCE_BILLING '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   SET BILLING_USER = NULL '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ab = @sql_upd_ab + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 

	-- I/R *********************************************************************************************************************************************
	SELECT @sql_upd_ir = ''
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + 'UPDATE dbo.INCOME_REC '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   SET BILLING_USER = NULL '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' '
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' ' 
	SELECT @sql_upd_ir = @sql_upd_ir + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' ' 

	-- Job Component *********************************************************************************************************************************************
	SELECT @sql_upd_jc = ''
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + 'UPDATE dbo.JOB_COMPONENT '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   SET BILLING_USER = NULL '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' ' 
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '	  AND JOB_NUMBER = ' + CAST( @job_number_in AS varchar(6)) + ' '
	SELECT @sql_upd_jc = @sql_upd_jc + CHAR(13) + '   AND JOB_COMPONENT_NBR = ' + CAST( @job_comp_in AS varchar(6)) + ' '

	-- A/R Function *********************************************************************************************************************************************
	SELECT @sql_upd_ar = ''
	SELECT @sql_upd_ar = @sql_upd_ar + CHAR(13) + 'DELETE FROM dbo.AR_FUNCTION '
	SELECT @sql_upd_ar = @sql_upd_ar + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' ' 

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
	EXECUTE ( @sql_upd_jc )
	SELECT @ret_val = @@ERROR, @jc_rows = @@ROWCOUNT
END

IF ( @ret_val = 0 )
BEGIN
	DECLARE @ret_val_arg integer
	EXECUTE dbo.advsp_delete_ar_function @bill_user_in = @billing_user, @ret_val = @ret_val_arg OUTPUT
	SET @ret_val = @@ERROR
END	  
GO
