
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_pmt_mgr_key]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_pmt_mgr_key]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[advsp_pmt_mgr_key] 
@is_chk_run varchar(50), @is_bank varchar(50)


AS

/*
KeyBank - ARP & Positive Pay Transmission Toolkit

*/

DECLARE @as_chk_run varchar(50), @as_bank varchar(50)
DECLARE @is_pm_type varchar(50), @is_pm_acct varchar(50), @is_bank_desc varchar(50), @is_pm_id varchar(10)
DECLARE @is_pm_word varchar(50), @il_bk_routing_nbr bigint, @is_ach_company_id varchar(10)
DECLARE @is_pm_dir varchar(100), @is_pm_ftp varchar(254), @is_export_file varchar(max)
DECLARE @is_log varchar(max), @is_output_file varchar(100), @success int, @cnt int
/* Agency Vars */
DECLARE @is_currency_code varchar(50), @is_agy_name varchar(50), @is_agy_reply_to varchar(50)
--DECLARE @is_agy_addr varchar(50), @is_agy_addr2 varchar(50), @is_agy_city varchar(50), @is_agy_state varchar(50)
--DECLARE @is_agy_zip varchar(10), @is_agy_phone varchar(15)
DECLARE @il_asp int, @is_import_path varchar(254)

DECLARE @recid int, @rec_cnt int
DECLARE @file_create_date varchar(6), @is_pm_bank_id varchar(20)

SET @as_chk_run = @is_chk_run
SET @as_bank = @is_bank

--IF OBJECT_ID('tempdb..#pmt_mgr_invoices') IS NOT NULL
--DROP TABLE #pmt_mgr_invoices

DECLARE @check_register TABLE (
	[RECID] [int] IDENTITY(1, 1),
	[BK_CODE] [varchar](4) NOT NULL,
	[CHECK_NBR] [int] NOT NULL,
	[CHK_SEQ] [smallint] NOT NULL,
	[CHECK_DATE] [smalldatetime] NOT NULL,
	[CHECK_AMT] [decimal](14, 2) NULL,
	[DISC_AMT] [decimal](14, 2) NULL,
	[PAY_TO] [varchar](40) NULL,
	[MANUAL] [smallint] NULL,
	[VOID_FLAG] [smallint] NULL,
	[CLEARED] [smallint] NULL,
	[POST_PERIOD] [varchar](6) NULL,
	[VOIDED_BY] [varchar](100) NULL,
	[VOID_DATE] [smalldatetime] NULL,
	[VOID_POST_PERIOD] [varchar](6) NULL,
	[WH_AMT] [decimal](14, 2) NULL,
	[VOL_DISC_AMT] [decimal](14, 2) NULL,
	[PAY_TO_CODE] [varchar](6) NULL,
	[GLACODE_WH] [varchar](30) NULL,
	[GLEXACT] [int] NULL,
	[REC_STMT_DATE] [smalldatetime] NULL,
	[RECON_FLAG] [smallint] NULL,
	[CHECK_RUN_ID] [varchar](50) NULL,
	[VO_COMMENT] [varchar](254) NULL,
	[EMAIL_DATE] [smalldatetime] NULL,
	[EXPORT_DATE] [smalldatetime] NULL,
	[EFILE_DATE] [smalldatetime] NULL,
	[CHECK_CLEARED_DATE] [datetime] NULL,
	[VN_ACCT_NBR] [varchar](30))

BEGIN TRY

	SELECT 'TRY'

	BEGIN TRAN

	/* Clear any previous export data for this bank */
	DELETE FROM W_PMT_MGR_EXPORT
	WHERE 	BK_CODE = @as_bank --CHECK_RUN_ID = @as_chk_run AND BK_CODE = @as_bank

	/* Set Defaults */
	SET @success = 1
	SET @is_export_file = ''
	SET @is_log = ''
	SET @cnt = 0

	/* Get Bank Data */
	SELECT @is_pm_type=COALESCE(PYMT_MGR_TYPE, ''),	@is_pm_acct=COALESCE(BK_ACCOUNT_NO, ''), @is_bank_desc=COALESCE(BK_DESCRIPTION, ''), @is_pm_id=COALESCE(PYMT_MGR_ID, ''), 
			 @is_pm_word=COALESCE(PYMT_MGR_WORD, ''),	@il_bk_routing_nbr=COALESCE(BK_ROUTING_NBR, ''), @is_ach_company_id=COALESCE(ACH_COMPANY_ID, ''), 
			 @is_pm_dir=COALESCE(PYMT_MGR_DIR, ''), @is_pm_ftp=COALESCE(PYMT_MGR_FTP, '')
	FROM   BANK
	WHERE  BK_CODE = @as_bank;

	SELECT @is_pm_bank_id = BANK_ID FROM BANK_EXP_SPEC
	WHERE  BK_CODE = @as_bank;

	SELECT @is_pm_dir '@is_pm_dir' , @is_pm_type '@is_pm_type' , @is_pm_acct '@is_pm_acct' , @is_pm_id '@is_pm_id' , @is_pm_ftp '@is_pm_ftp'
	
	SET @is_pm_type = UPPER(RTRIM(@is_pm_type))
	SET @is_pm_acct = UPPER(RTRIM(@is_pm_acct))
	SET @is_pm_id = UPPER(RTRIM(@is_pm_id))

	/* PJH 02/26/14 - Added ASP support for export folder */
	SELECT @il_asp = ASP_ACTIVE, @is_import_path = IMPORT_PATH
	FROM   AGENCY;

	SELECT @il_asp = ISNULL(@il_asp, 0)

	IF (@il_asp = 1) BEGIN

		IF @is_pm_type = 'KEY' BEGIN
	
			IF RIGHT(@is_import_path, 1) = '\' BEGIN
		
				SET @is_import_path = @is_import_path + 'payment\'
		
			END ELSE BEGIN 
		
				SET @is_import_path = @is_import_path + '\payment\'
		
			END
		
		END	
	
		SET @is_pm_dir = @is_import_path
	
	END
	/**********************************************/

	IF @is_pm_ftp <> ''
	BEGIN
		IF (RIGHT( @is_pm_ftp, 1 ) = '\')  SET @is_pm_ftp = LEFT( @is_pm_ftp, LEN( @is_pm_ftp ) - 1 )
	END

	IF @is_pm_dir <> '' 
	BEGIN
		IF (RIGHT(@is_pm_dir, 1) <> '\') SET @is_pm_dir = @is_pm_dir + '\'
	END

	/* Do not UPPER the FTP Client - it is causing problems for CSI users */
	SET @is_pm_ftp = RTRIM(@is_pm_ftp)

	SET @is_pm_word = UPPER(RTRIM(@is_pm_word))

	SET @is_pm_dir = UPPER(RTRIM(@is_pm_dir))

	IF (@is_pm_id='') OR (@is_pm_dir='') --OR (@is_pm_word='')
	BEGIN
		SET @is_log = 'Unable to obtain Payment Manager data for bank ' + @as_bank + '.' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	--IF LEN(@is_pm_acct) <> 13 
	--BEGIN
	--	SET @is_log = @is_log + 'Bank Account Number must be 13 digits.  ' + CHAR(13)
	--	SET @success = 0
	--	--RETURN FALSE
	--END

	IF @is_pm_acct IS NULL
		SET @is_pm_acct = ''

	IF (@is_pm_dir='') 
	BEGIN
		SET @is_log = @is_log + 'The File Output Directory in Bank Maintenance does not exist.'  + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	SET @file_create_date = RIGHT(CONVERT(VARCHAR(6), GETDATE(), 12), 6) /* yymmdd */

	SET @is_output_file = 'KEY.' + @is_pm_acct + '.' + REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') +  '.' + REPLACE(CONVERT(VARCHAR(12), GETDATE(), 114), ':','') + '0' + '.txt'

	BEGIN
		INSERT INTO @check_register
				(BK_CODE
				, CHECK_NBR, CHK_SEQ, CHECK_DATE, CHECK_AMT, DISC_AMT, PAY_TO, [MANUAL], VOID_FLAG, CLEARED
				, POST_PERIOD, VOIDED_BY, VOID_DATE, VOID_POST_PERIOD, WH_AMT, VOL_DISC_AMT, PAY_TO_CODE, GLACODE_WH
				, GLEXACT, REC_STMT_DATE, RECON_FLAG, CHECK_RUN_ID, VO_COMMENT, EMAIL_DATE, EXPORT_DATE, EFILE_DATE
				, CHECK_CLEARED_DATE, VN_ACCT_NBR)
		SELECT CR.BK_CODE
				, CHECK_NBR, CHK_SEQ, CHECK_DATE, CHECK_AMT, DISC_AMT, PAY_TO, [MANUAL], VOID_FLAG, CLEARED
				, COALESCE(POST_PERIOD, ''), VOIDED_BY, VOID_DATE, VOID_POST_PERIOD, WH_AMT, VOL_DISC_AMT, COALESCE(PAY_TO_CODE, ''), GLACODE_WH
				, GLEXACT, REC_STMT_DATE, RECON_FLAG, CHECK_RUN_ID, VO_COMMENT, EMAIL_DATE, EXPORT_DATE, EFILE_DATE
				, CHECK_CLEARED_DATE, VN_ACCT_NBR
		FROM CHECK_REGISTER CR JOIN VENDOR V ON CR.PAY_TO_CODE = V.VN_CODE
		WHERE 	 ( CR.CHECK_RUN_ID = @as_chk_run ) AND  
					 --( CR.VOID_FLAG = 0 OR CR.VOID_FLAG is NULL ) AND  
					 ( CR.BK_CODE = @as_bank  );

		SET @rec_cnt = @@ROWCOUNT

		SELECT '@check_register' '*', * FROM @check_register;
	END

	DECLARE @ls_hdr varchar(max), @ls_output varchar(max)

	DECLARE @pay_to varchar(50), @void_flag varchar(50), @check_date varchar(30)
	DECLARE @check_nbr varchar(50), @check_amt decimal(14,2)
	DECLARE @vn_acct_nbr varchar(30)
	DECLARE @amt_sign varchar(1), @str_amt varchar(20)
	DECLARE @total_amt decimal(14,2), @total_amt_str varchar(20)
	DECLARE @check_amt_str varchar(20), @chk_amt_length int
	
	IF @success = 1 AND @rec_cnt > 0
		BEGIN

			--SET @ls_output = @ls_output + LEFT((@is_pm_acct), 13) /** Bank Account **/

			SET @recid = 1

			SELECT 			
				@check_nbr=CHECK_NBR, 
				@check_amt=CHECK_AMT, 
				@check_date=RIGHT(CONVERT(VARCHAR(8), CHECK_DATE, 112), 8),  
				@pay_to=PAY_TO, 
				@void_flag=VOID_FLAG,
				@vn_acct_nbr=VN_ACCT_NBR
				
			FROM @check_register
			WHERE [RECID] = @recid;

			SET @total_amt = 0

			IF @success = 1
				WHILE @recid <= @rec_cnt
				BEGIN  

					SET @ls_output = '00'

					SET @ls_output =  @ls_output + RIGHT(('000000000000000' + @is_pm_acct), 15) /** Bank Account Nbr **/
				
					SET @ls_output =  @ls_output + RIGHT('0000000000' + @check_nbr, 10) /** Check Nbr */

					SET @ls_output =  @ls_output +  (@check_date) /** Check Date */

					SET @total_amt = @total_amt + @check_amt

					SET @check_amt_str = CAST(@check_amt AS varchar(20))

					SET @chk_amt_length = LEN(@check_amt_str)

					SET @str_amt = RIGHT(  '0000000000' + (LEFT(@check_amt, @chk_amt_length - 3) + RIGHT(@check_amt, 2)), 10  ) /* Implied Decimal */
				
					SET @ls_output =  @ls_output + @str_amt

					IF @void_flag = 1 
						SET @void_flag = 'C'
					ELSE
						SET @void_flag = ' '
					
					SET @ls_output =  @ls_output + @void_flag	

					SET @ls_output =  @ls_output +  SPACE(15)
				
					SET @ls_output =  @ls_output + UPPER(LEFT((@pay_to + SPACE(75)), 75)) /** Vendor Name **/		

					SET @ls_output =  @ls_output +  SPACE(75)	 /* Filler */

					SET @ls_output =  @ls_output +  SPACE(9)
			
					SET @is_export_file = @ls_output

					SET @ls_output =  @ls_output + '|' /* Use this for length validation */

					IF LEN(@ls_output) <> 221
						BEGIN
							SET @is_log = @is_log + 'The Detail Record must be 220 characters.' + CAST(LEN(@ls_output) AS varchar(10)) + CHAR(13)
							SET @success = 0
							--RETURN FALSE
						END
			
					INSERT INTO W_PMT_MGR_EXPORT
							   (BK_CODE
							   ,CHECK_RUN_ID
							   ,EXPORT_PATH
							   ,EXPORT_FILENAME
							   ,EXPORT_FILE
							   ,SUCCESS)
						 VALUES
							   (@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)		
			
					SET @cnt = @cnt + 1
				
					SET @recid = @recid + 1
			
				SELECT 			
					@check_nbr=CHECK_NBR, 
					@check_amt=CHECK_AMT, 
					@check_date=RIGHT(CONVERT(VARCHAR(8), CHECK_DATE, 112), 8),  
					@pay_to=PAY_TO, 
					@void_flag=VOID_FLAG,
					@vn_acct_nbr=VN_ACCT_NBR				
				
				FROM @check_register
				WHERE [RECID] = @recid;

				END  /* LOOP */	

			-- UPDATE EXPORT DATE FOR ALL ROWS in Client code (i.e. legacy app)	   
		END 
	ELSE
		BEGIN
			/* Either experienced an error in data or no rows found to process */
			IF @success = 1 /* then no rows found to process */
			BEGIN
				SET @is_log = 'No Rows matched your bank code and check run ID!'
				SET @success = 0
			END
			/* Drop into error routine */
		END

	/* If error(s) then set flag and write error log to work table */
	IF @success = 0
		BEGIN
			/*	@is_log = is set where error occured */
			SELECT 'ERROR' 'ERROR'
		
			/* Clear partial data */
			DELETE FROM W_PMT_MGR_EXPORT
			WHERE 	BK_CODE = @as_bank --CHECK_RUN_ID = @as_chk_run AND BK_CODE = @as_bank
		
			PRINT @is_log
			SET @is_export_file = @is_log	

			INSERT INTO W_PMT_MGR_EXPORT
					   (BK_CODE
					   ,CHECK_RUN_ID
					   ,EXPORT_PATH
					   ,EXPORT_FILENAME
					   ,EXPORT_FILE
					   ,SUCCESS)
				 VALUES
					   (@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)	
		END

	/*************************************************************************************************************************/
	SELECT @is_log AS ErrorMessage

	PRINT 'COMMIT'
	COMMIT TRAN

	RETURN @success

END TRY
BEGIN CATCH

	PRINT 'ROLLBACK'
	ROLLBACK TRAN
	
	SELECT 
    --ERROR_NUMBER() as ErrorNumber,
    ERROR_MESSAGE() as ErrorMessage, @is_log AS ERROR_LOG;
   
	BEGIN
		/*	@is_log = is set where error occured */
	
		SET @is_log = ERROR_MESSAGE() 
		SET @success = 0
	
		/* Clear partial data */
		DELETE FROM W_PMT_MGR_EXPORT
		WHERE 	BK_CODE = @as_bank --CHECK_RUN_ID = @as_chk_run AND BK_CODE = @as_bank
	
		PRINT @is_log
		SET @is_export_file = @is_log	

		INSERT INTO W_PMT_MGR_EXPORT
				   (BK_CODE
				   ,CHECK_RUN_ID
				   ,EXPORT_PATH
				   ,EXPORT_FILENAME
				   ,EXPORT_FILE
				   ,SUCCESS)
			 VALUES
				   (@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)	    
	END 
   
   RETURN 0 /* Failed */
    
END CATCH

GO

GRANT EXECUTE ON [advsp_pmt_mgr_key] TO PUBLIC
GO