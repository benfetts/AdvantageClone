
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_pmt_mgr_arp]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_pmt_mgr_arp]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[advsp_pmt_mgr_arp] 
@is_chk_run varchar(50), @is_bank varchar(50)


AS

/*
Wells Fargo - STANDARD ARP FORMAT - POSITIVE PAY SERVICE

*/

DECLARE @as_chk_run varchar(50), @as_bank varchar(50)
DECLARE @is_pm_type varchar(50), @is_pm_acct varchar(50), @is_bank_desc varchar(50), @is_pm_id varchar(10)
DECLARE @is_pm_word varchar(50), @il_bk_routing_nbr bigint, @is_ach_company_id varchar(10)
DECLARE @is_pm_dir varchar(100), @is_pm_ftp varchar(254), @is_export_file varchar(max)
DECLARE @is_log varchar(max), @is_output_file varchar(100), @success int, @cnt int
/* Agency Vars */
DECLARE @is_currency_code varchar(50), @is_agy_name varchar(50), @is_agy_reply_to varchar(50)
DECLARE @is_agy_addr varchar(50), @is_agy_addr2 varchar(50), @is_agy_city varchar(50), @is_agy_state varchar(50)
DECLARE @is_agy_zip varchar(10), @is_agy_phone varchar(15)
DECLARE @il_asp int, @is_import_path varchar(254)

DECLARE @recid int, @rec_cnt int
DECLARE @file_create_date varchar(10), @is_pm_bank_id varchar(20)

SET @as_chk_run = @is_chk_run
SET @as_bank = @is_bank

--IF OBJECT_ID('tempdb..#pmt_mgr_invoices') IS NOT NULL
--DROP TABLE #pmt_mgr_invoices

DECLARE @chkeck_register TABLE (
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
	[CHECK_CLEARED_DATE] [datetime] NULL)

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

		IF @is_pm_type = 'ARP' BEGIN
	
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
	
	SET @is_log = ''

	--SELECT @as_bank '@as_bank'

	/* Do not UPPER the FTP Client - it is causing problems for CSI users */
	SET @is_pm_ftp = RTRIM(@is_pm_ftp)

	SET @is_pm_word = UPPER(RTRIM(@is_pm_word))

	SET @is_pm_dir = UPPER(RTRIM(@is_pm_dir))

	IF (@is_pm_dir='') --OR (@is_pm_word='')
	BEGIN
		SET @is_log = @is_log + 'Unable to obtain Payment Manager data for bank ' + @as_bank + '.' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF LEN(@is_pm_acct) <> 15 
	BEGIN
		SET @is_log = @is_log + 'Bank Account Number must be 15 digits or less.  ' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	SET @is_pm_bank_id = 'R12' /* Hard Coded as "R12" - Paid Check Report */

	/* Must be 'TEST' or spaces */
	IF @is_ach_company_id IS NULL
		SET @is_ach_company_id = SPACE(4)
	ELSE
		IF @is_ach_company_id <> 'TEST'
			SET @is_ach_company_id = SPACE(4)

	IF (@is_pm_dir='') 
	BEGIN
		SET @is_log = @is_log + 'The File Output Directory in Bank Maintenance does not exist.'  + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	SET @file_create_date = CONVERT(VARCHAR(10), GETDATE(), 101)

	SET @file_create_date = LEFT(REPLACE(@file_create_date, '/', ''), 8) /* mmddyyyy */

	SET @file_create_date = LEFT(@file_create_date, 4) + RIGHT(@file_create_date, 2) /* mmddyy */

	SET @is_output_file = 'ARP.' + @is_pm_acct + '.' + REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') +  '.' + REPLACE(CONVERT(VARCHAR(12), GETDATE(), 114), ':','') + '0' + '.txt'

	--SELECT '01: ' + @is_pm_dir + ' | ' + @is_pm_type + ' | ' + @is_pm_acct + ' | ' + @is_pm_id + ' | ' + @is_pm_ftp + ' | ' + @is_output_file

	/* Get Agency Data */
	SELECT @is_currency_code=HOME_CRNCY, @is_agy_name=NAME, @is_agy_reply_to=POP3_REPLY_TO,
		@is_agy_addr=COALESCE(RTRIM(ADDRESS1),'') + ', ', @is_agy_addr2=	COALESCE(RTRIM(ADDRESS2),'') + ', ', 
		@is_agy_city=COALESCE(RTRIM(CITY),'') + ', ', @is_agy_state=COALESCE(RTRIM(STATE),'') + ', ', @is_agy_zip=COALESCE(RTRIM(ZIP),''), @is_agy_phone=Replace(Replace(Replace(Replace(Replace(PHONE,'(',''),' ',''),'.',''),')',''),'-','')
	FROM   AGENCY;

	--IF @is_agy_addr2 > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_addr2
	--IF @is_agy_city > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_city
	--IF @is_agy_state > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_state
	--IF @is_agy_zip > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_zip

	DECLARE @min_check_date varchar(20)
	DECLARE @max_check_date varchar(20)

	BEGIN
		INSERT INTO @chkeck_register
				(BK_CODE
				, CHECK_NBR, CHK_SEQ, CHECK_DATE, CHECK_AMT, DISC_AMT, PAY_TO, [MANUAL], VOID_FLAG, CLEARED
				, POST_PERIOD, VOIDED_BY, VOID_DATE, VOID_POST_PERIOD, WH_AMT, VOL_DISC_AMT, PAY_TO_CODE, GLACODE_WH
				, GLEXACT, REC_STMT_DATE, RECON_FLAG, CHECK_RUN_ID, VO_COMMENT, EMAIL_DATE, EXPORT_DATE, EFILE_DATE
				, CHECK_CLEARED_DATE)
		SELECT CR.BK_CODE
				, CHECK_NBR, CHK_SEQ, CHECK_DATE, CHECK_AMT, DISC_AMT, PAY_TO, [MANUAL], VOID_FLAG, CLEARED
				, COALESCE(POST_PERIOD, ''), VOIDED_BY, VOID_DATE, VOID_POST_PERIOD, WH_AMT, VOL_DISC_AMT, COALESCE(PAY_TO_CODE, ''), GLACODE_WH
				, GLEXACT, REC_STMT_DATE, RECON_FLAG, CHECK_RUN_ID, VO_COMMENT, EMAIL_DATE, EXPORT_DATE, EFILE_DATE
				, CHECK_CLEARED_DATE
		FROM CHECK_REGISTER CR JOIN VENDOR V ON CR.PAY_TO_CODE = V.VN_CODE
		WHERE 	 ( CR.CHECK_RUN_ID = @as_chk_run ) AND  
					 --( CR.VOID_FLAG = 0 OR CR.VOID_FLAG is NULL ) AND  
					 ( CR.BK_CODE = @as_bank  );

		SET @rec_cnt = @@ROWCOUNT

		--SELECT '@chkeck_register' '*', * FROM @chkeck_register;
	END

	SELECT @min_check_date = MIN(CONVERT(VARCHAR(10), CHECK_DATE, 101)), @max_check_date = MAX(CONVERT(VARCHAR(10), CHECK_DATE, 101)) 
	FROM @chkeck_register;

	DECLARE @ls_hdr varchar(max), @ls_output varchar(max)

	DECLARE @pay_to varchar(50), @void_flag varchar(50), @check_date varchar(30)
	DECLARE @check_nbr varchar(50), @check_amt decimal(14,2)
	DECLARE @amt_sign varchar(1), @str_amt varchar(20)
	DECLARE @total_amt decimal(14,2), @total_amt_str varchar(20)
	DECLARE @check_amt_str varchar(20), @chk_amt_length int

	SET @min_check_date = LEFT(REPLACE(CONVERT(VARCHAR(10), @min_check_date, 101), '/', ''), 8) /* mmddyyyy */
	SET @min_check_date = LEFT(@min_check_date, 4) + RIGHT(@min_check_date, 2) /* mmddyy */

	SET @max_check_date = LEFT(REPLACE(CONVERT(VARCHAR(10), @max_check_date, 101), '/', ''), 8) /* mmddyyyy */
	SET @max_check_date = LEFT(@max_check_date, 4) + RIGHT(@max_check_date, 2) /* mmddyy */

	--SELECT @min_check_date, @max_check_date, @file_create_date

	--SELECT @is_pm_bank_id '@is_pm_bank_id', LEN(@is_pm_bank_id)

	IF @success = 1 AND @rec_cnt > 0
		BEGIN

			/* HEADER RECORD */
			SET @ls_output = 'H1'
			SET @ls_output = @ls_output + SPACE(1)
			SET @ls_output = @ls_output + RIGHT(('00000000000000' + @is_pm_acct), 15) /** Bank Account **/
			SET @ls_output = @ls_output + LEFT(@is_pm_bank_id, 3) /* Default to R12 if not provided in Bank ID */
			SET @ls_output = @ls_output + @file_create_date
			SET @ls_output = @ls_output + @min_check_date --LEFT(REPLACE(CONVERT(VARCHAR(10), @min_check_date, 101), '/', ''), 6) /* mmddyy */
			SET @ls_output = @ls_output + @max_check_date --LEFT(REPLACE(CONVERT(VARCHAR(10), @max_check_date, 101), '/', ''), 6) /* mmddyy */
			SET @ls_output = @ls_output + SPACE(41) + '|'

			IF LEN(@ls_output) <> 81
				BEGIN
					SET @is_log = @is_log + 'The Header Record must be 80 characters. ' + CAST(LEN(@ls_output) AS varchar(10)) + CHAR(13)
					SET @success = 0
					--RETURN FALSE
				END

			SET @is_export_file = LEFT(@ls_output,80)

			INSERT INTO W_PMT_MGR_EXPORT
						(BK_CODE
						,CHECK_RUN_ID
						,EXPORT_PATH
						,EXPORT_FILENAME
						,EXPORT_FILE
						,SUCCESS)
					VALUES
						(@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)	

			SET @recid = 1

			--DECLARE db_cursor CURSOR FOR  
			SELECT 			
				@check_nbr=CHECK_NBR, 
				@check_amt=CHECK_AMT, 
				@check_date=CONVERT(VARCHAR(10), CHECK_DATE, 101), 
				@pay_to=PAY_TO, 
				@void_flag=VOID_FLAG
				
			FROM @chkeck_register
			WHERE [RECID] = @recid;

			SET @total_amt = 0

			IF @success = 1
				WHILE @recid <= @rec_cnt
				BEGIN  

					--SELECT @check_date '@check_date'

					SET @check_date = LEFT(REPLACE(@check_date, '/', ''), 8) /* mmddyyyy */
					SET @check_date = LEFT(@check_date, 4) + RIGHT(@check_date, 2) /* mmddyy */

					--SELECT @check_date '@check_date'

					SET @ls_output = @is_pm_bank_id /* Default to R12 if not provided in Bank ID */

					--SET @ls_output = LEFT((@is_pm_acct), 13) /** Bank Account **/
				
					SET @ls_output =  @ls_output + RIGHT('0000000000' + @check_nbr, 10) /** Check Nbr */

					SET @ls_output =  @ls_output +  '057'  /**Transaction Type = Check */
				
					SET @ls_output =  @ls_output +  @check_date /** Issue Date */

					SET @total_amt = @total_amt + @check_amt

					SET @check_amt_str = CAST(@check_amt AS varchar(20))

					SET @chk_amt_length = LEN(@check_amt_str)
				
					SET @str_amt = RIGHT(  '00000000000' + (LEFT(@check_amt, @chk_amt_length - 3) + RIGHT(@check_amt, 2)), 10  ) /* Implied Decimal */

					SET @ls_output =  @ls_output + @str_amt

					SET @ls_output =  @ls_output +  @check_date /** Paid Date */
				
					SET @ls_output =  @ls_output +(LEFT((@pay_to + SPACE(41)), 41)) /** Vendor Name **/		
				
					SET @ls_output =  @ls_output +  SPACE(1) + '|'	 /* Filler */
			
					IF LEN(@ls_output) <> 81
						BEGIN
							SET @is_log = @is_log + 'The Detail Record must be 80 characters.' + CAST(LEN(@ls_output) AS varchar(10)) + CHAR(13)
							SET @success = 0
							--RETURN FALSE
						END

					SET @is_export_file = LEFT(@ls_output,80)
			
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
						@check_date=CONVERT(VARCHAR(10), CHECK_DATE, 101),
						@pay_to=PAY_TO, 
						@void_flag=VOID_FLAG
				
					FROM @chkeck_register
					WHERE [RECID] = @recid;

				END  /* LOOP */

			/* TRAILER RECORD */
			SET @ls_output = 'T1'

			SET @ls_output = @ls_output + SPACE(1) 
			SET @ls_output = @ls_output + '00000000' /* 8 - Credit Cnt */
			SET @ls_output = @ls_output + SPACE(1) 
			SET @ls_output = @ls_output + '00000000000' /* 11 - Credit Amt */

			SET @ls_output = @ls_output + SPACE(2) 

			SET @ls_output = @ls_output + RIGHT('0000000' + CAST(@cnt AS varchar(7)), 7)
			SET @ls_output = @ls_output + SPACE(1) 

			SET @total_amt_str = CAST(@total_amt as varchar(20))
			SET @chk_amt_length = LEN(@total_amt_str)

			SET @ls_output = @ls_output + RIGHT(  '00000000000' + (LEFT(@total_amt_str, @chk_amt_length - 3) + RIGHT(@total_amt_str, 2)), 11  ) /* Implied Decimal */

			SET @ls_output = @ls_output + SPACE(36) + '|'

			IF LEN(@ls_output) <> 81
				BEGIN
					SET @is_log = @is_log + 'The Trailer Record must be 80 characters.' + CAST(LEN(@ls_output) AS varchar(10)) + CHAR(13)
					SET @success = 0
					--RETURN FALSE
				END

			SET @is_export_file = LEFT(@ls_output,80)
			
			INSERT INTO W_PMT_MGR_EXPORT
						(BK_CODE
						,CHECK_RUN_ID
						,EXPORT_PATH
						,EXPORT_FILENAME
						,EXPORT_FILE
						,SUCCESS)
					VALUES
						(@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)		

			-- UPDATE EXPORT DATE FOR ALL ROWS	in Client code	   
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
		
			SELECT @is_log
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


