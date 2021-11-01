
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'[dbo].[advsp_pmt_mgr_bnz]')
			AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE [dbo].[advsp_pmt_mgr_bnz]
GO

CREATE PROCEDURE [dbo].[advsp_pmt_mgr_bnz] 
@is_chk_run varchar(50), @is_bank varchar(50)

/* PJH 03/08/17 - Created advsp_pmt_mgr_bnz  */
/* PJH 07/13/17 - Removed @is_pm_id validation */

AS

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
DECLARE @curr_date varchar(12)

SET @as_chk_run = @is_chk_run
SET @as_bank = @is_bank

--IF OBJECT_ID('tempdb..#pmt_mgr_invoices') IS NOT NULL
--DROP TABLE #pmt_mgr_invoices

DECLARE @pmt_mgr_invoices TABLE (
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
	[VN_ACCT_NBR] [varchar](30) NULL )

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

	SET @curr_date = CONVERT(VARCHAR(10), GETDATE(), 12)

	/* Get Bank Data */
	SELECT @is_pm_type=COALESCE(PYMT_MGR_TYPE, ''),	@is_pm_acct=COALESCE(BK_ACCOUNT_NO, ''), @is_bank_desc=COALESCE(BK_DESCRIPTION, ''), @is_pm_id=COALESCE(PYMT_MGR_ID, ''), 
			 @is_pm_word=COALESCE(PYMT_MGR_WORD, ''),	@il_bk_routing_nbr=COALESCE(BK_ROUTING_NBR, ''), @is_ach_company_id=COALESCE(ACH_COMPANY_ID, ''), 
			 @is_pm_dir=COALESCE(PYMT_MGR_DIR, ''), @is_pm_ftp=COALESCE(PYMT_MGR_FTP, '')
	FROM   BANK
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

		IF @is_pm_type = 'BNZ' BEGIN
	
		--	IF RIGHT(@is_import_path, 1) = '\' BEGIN		
		--		SET @is_import_path = @is_import_path + 'csi\'		
		--	END ELSE BEGIN 		
		--		SET @is_import_path = @is_import_path + '\csi\'			
		--	END		
		--END ELSE BEGIN
	
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

	IF (@is_pm_dir='') --OR (@is_pm_word='') OR (@is_pm_id='')
	BEGIN
		SET @is_log = 'Unable to obtain Payment Manager directory for bank ' + @as_bank + '.' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF LEN(@is_pm_acct) < 15 OR LEN(@is_pm_acct) > 16 
	BEGIN
		SET @is_log = @is_log + 'Bank Account/Credit Card Number is (' + @is_pm_acct + '). It must be 15 or 16 digits.  ' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	--IF LEN(@is_pm_word) > 20 
	--BEGIN
	--	SET @is_log = @is_log + 'The Payment Manager "Word" on the bank record exceeds the maximum length of 20. Please correct and try again'  + CHAR(13)
	--	SET @success = 0
	--	--RETURN FALSE
	--END

	IF (@is_pm_dir='') 
	BEGIN
		SET @is_log = @is_log + 'The File Output Directory in Bank Maintenance does not exist.'  + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	SET @is_output_file = @is_pm_acct + '_' + REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') +  '_' + REPLACE(CONVERT(VARCHAR(12), GETDATE(), 114), ':','') + '0' + '.txt'
	
	--SELECT '01: ' + @is_pm_dir + ' | ' + @is_pm_type + ' | ' + @is_pm_acct + ' | ' + @is_pm_id + ' | ' + @is_pm_ftp + ' | ' + @is_output_file

	/* Get Agency Data */
	SELECT @is_currency_code=HOME_CRNCY, @is_agy_name=NAME, @is_agy_reply_to=POP3_REPLY_TO,
		@is_agy_addr=COALESCE(RTRIM(ADDRESS1),'') + ', ', @is_agy_addr2=	COALESCE(RTRIM(ADDRESS2),'') + ', ', 
		@is_agy_city=COALESCE(RTRIM(CITY),'') + ', ', @is_agy_state=COALESCE(RTRIM(STATE),'') + ', ', @is_agy_zip=COALESCE(RTRIM(ZIP),''), @is_agy_phone=Replace(Replace(Replace(Replace(Replace(PHONE,'(',''),' ',''),'.',''),')',''),'-','')
	FROM   AGENCY;

	IF @is_agy_addr2 > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_addr2
	IF @is_agy_city > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_city
	IF @is_agy_state > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_state
	IF @is_agy_zip > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_zip

	SET @is_agy_name =  REPLACE(@is_agy_name, ',', '')
	SET @is_agy_addr =  REPLACE(@is_agy_addr, ',', '')

	BEGIN
		INSERT INTO @pmt_mgr_invoices
				   (BK_CODE
				  ,CHECK_NBR
				  ,CHK_SEQ
				  ,CHECK_DATE
				  ,CHECK_AMT
				  ,DISC_AMT
				  ,PAY_TO
				  ,[MANUAL]
				  ,VOID_FLAG
				  ,CLEARED
				  ,POST_PERIOD
				  ,VOIDED_BY
				  ,VOID_DATE
				  ,VOID_POST_PERIOD
				  ,WH_AMT
				  ,VOL_DISC_AMT
				  ,PAY_TO_CODE
				  ,GLACODE_WH
				  ,GLEXACT
				  ,REC_STMT_DATE
				  ,RECON_FLAG
				  ,CHECK_RUN_ID
				  ,VO_COMMENT
				  ,EMAIL_DATE
				  ,EXPORT_DATE
				  ,EFILE_DATE
				  ,CHECK_CLEARED_DATE
				  ,VN_ACCT_NBR)
			SELECT CR.BK_CODE
				  ,CHECK_NBR
				  ,CHK_SEQ
				  ,CHECK_DATE
				  ,CHECK_AMT
				  ,DISC_AMT
				  ,PAY_TO
				  ,[MANUAL]
				  ,VOID_FLAG
				  ,CLEARED
				  ,COALESCE(POST_PERIOD, '')
				  ,VOIDED_BY
				  ,VOID_DATE
				  ,VOID_POST_PERIOD
				  ,WH_AMT
				  ,VOL_DISC_AMT
				  ,COALESCE(PAY_TO_CODE, '')
				  ,GLACODE_WH
				  ,GLEXACT
				  ,REC_STMT_DATE
				  ,RECON_FLAG
				  ,CHECK_RUN_ID
				  ,VO_COMMENT
				  ,EMAIL_DATE
				  ,EXPORT_DATE
				  ,EFILE_DATE
				  ,CHECK_CLEARED_DATE
				  ,VN_ACCT_NBR
				FROM CHECK_REGISTER CR JOIN VENDOR V ON CR.PAY_TO_CODE = V.VN_CODE
			   WHERE 
					 ( CR.CHECK_RUN_ID = @as_chk_run ) AND  
					 --( CR.VOID_FLAG = 0 OR CR.VOID_FLAG is NULL ) AND  
					 ( CR.BK_CODE = @as_bank  );

		SET @rec_cnt = @@ROWCOUNT

		SELECT 'Pmt Mgr Invoices' '*', * FROM @pmt_mgr_invoices;
	END

	DECLARE @ls_hdr varchar(max), @ls_output varchar(max)
	--DECLARE @ap_desc varchar(50)
	DECLARE @ls_mail varchar(50), @pymt_mgr_email varchar(50), @vn_email varchar(50), @vn_fax_number varchar(50)
	DECLARE @vn_pay_to_address1 varchar(30), @vn_pay_to_address2 varchar(30), @vn_pay_to_address3 varchar(30), @vn_pay_to_city varchar(20)
	DECLARE @vn_pay_to_county varchar(30), @vn_pay_to_state varchar(2), @vn_pay_to_zip varchar(12), @vn_pay_to_country varchar(3)
	
	/* Vendor Vars */
	DECLARE @pay_to_code varchar(50), @vn_name varchar(50), @ap_inv_vchr varchar(50), @ap_inv_date varchar(30), @payment_date varchar(30) 
	DECLARE @vn_acct_nbr varchar(50), @vn_acct_prefix varchar(50), @vn_acct_suffix varchar(50)

	DECLARE @ap_chk_nbr varchar(50), @ap_chk_amt decimal(14,2), @ap_disc_amt decimal(14,2), @inv_gross_amt decimal(14,2)
	DECLARE @amt_sign varchar(1), @str_amt varchar(50)

	DECLARE @ctrl_total_pmt_amt decimal(14,2), @ctrl_rec_cnt int, @ctrl_hash_total dec(18)

	SELECT @ctrl_total_pmt_amt = 0, @ctrl_hash_total = 0, @ctrl_rec_cnt = 0
	
	IF @success = 1 AND @rec_cnt > 0
		BEGIN
		
			SET @recid = 1

			--DECLARE db_cursor CURSOR FOR  
			SELECT @pay_to_code=PAY_TO_CODE, @vn_name=PAY_TO, 
				@ap_inv_date=REPLACE(CONVERT(VARCHAR(10), CHECK_DATE, 101), '/', ''), 
				@payment_date=REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', ''), 
				@ap_chk_nbr=CHECK_NBR, 
				@ap_chk_amt=CHECK_AMT, 
				@ap_disc_amt=DISC_AMT, 
				@vn_acct_nbr=VN_ACCT_NBR
			FROM @pmt_mgr_invoices
			WHERE [RECID] = @recid;

			SET @is_pm_acct =  REPLACE(@is_pm_acct, ',', '')

			SET @ls_hdr = '1' /* Record Type */
			SET @ls_hdr = @ls_hdr + ',,,' /* Fields 2,3,4 */
			SET @ls_hdr = @ls_hdr + ',' + @is_pm_acct		/* Bank Acct */
			SET @ls_hdr = @ls_hdr + ',' + '7'						/* File Type */
			SET @ls_hdr = @ls_hdr + ',' + @curr_date		/* Fille Due Date */
			SET @ls_hdr = @ls_hdr + ',' + @curr_date		/* File Create Date */
			SET @ls_hdr = @ls_hdr + ',' + 'I'						/* I - Individual listing */
			
			SET @is_export_file = @ls_hdr
		
			INSERT INTO W_PMT_MGR_EXPORT
					   (BK_CODE
					   ,CHECK_RUN_ID
					   ,EXPORT_PATH
					   ,EXPORT_FILENAME
					   ,EXPORT_FILE
					   ,SUCCESS)
				 VALUES
					   (@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)							
			
			WHILE @recid <= @rec_cnt
			BEGIN  

				SET @pymt_mgr_email =  REPLACE(@pymt_mgr_email, ',', '')
				SET @vn_email =  REPLACE(@vn_email, ',', '')
				SET @pay_to_code =  REPLACE(@pay_to_code, ',', '')
				SET @vn_name =  REPLACE(@vn_name, ',', '')
				SET @ap_inv_vchr =  REPLACE(@ap_inv_vchr, ',', '')
				SET @vn_acct_nbr =  REPLACE(@vn_acct_nbr, ',', '')

				--SELECT *
				--FROM @pmt_mgr_invoices
				--WHERE [RECID] = @recid;

				SET @ls_mail = @pymt_mgr_email
				IF (@ls_mail = '') SET @ls_mail = @vn_email
			
				SET @ls_output = '2' /* Record Type */

				IF @vn_acct_nbr = ''
					SET @vn_acct_nbr = NULL

				SET @vn_acct_nbr = LEFT(@vn_acct_nbr, 16)

				IF @vn_acct_nbr IS NULL
				BEGIN
					SET @is_log = 'The Vendor Account Number for Vendor (' + @vn_name + ') is missing.'
					SET @success = 0
					BREAK
				END	

				IF ISNUMERIC(@vn_acct_nbr) = 0 OR LEN(@vn_acct_nbr) < 15 OR LEN(@vn_acct_nbr) > 16
				BEGIN
					SET @is_log = 'The Vendor Account Number for Vendor (' + @vn_name + ') must be a 15 or 16 digit numeric value.'
					SET @success = 0
					BREAK
				END	

				SET @ls_output = @ls_output + ',' + @vn_acct_nbr /** Vendor Acct No **/

				--SET @vn_acct_prefix = LEFT(@vn_acct_nbr, CHARINDEX('|', @vn_acct_nbr))
				--SET @vn_acct_suffix = RIGHT(@vn_acct_nbr, LEN(@vn_acct_nbr) - CHARINDEX('|', @vn_acct_nbr) - 1)

				SET @ls_output = @ls_output + ',' + '50'  /** Trans Code **/

				SET @str_amt = CAST((@ap_chk_amt * 100) AS varchar(12))

				SET @str_amt = LEFT(@str_amt, LEN(@str_amt) - 3) /* remove decimal */

				IF LEN(@str_amt) > 12
				BEGIN
					SET @is_log = 'The Net Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 12 characters in length.'
					SET @success = 0
					BREAK
				END		
				
				SET @ctrl_total_pmt_amt = @ctrl_total_pmt_amt + @ap_chk_amt
				
				SET @ls_output = @ls_output + ',' + @str_amt /* Trans (Chk) Amt */

				SET @ls_output = @ls_output + ',' + LEFT((@vn_name), 20) /** Vendor Name **/

				SET @ls_output = @ls_output + ',' + LEFT((@ap_chk_nbr), 12) /** Chk Nbr **/
				
				SET @ls_output = @ls_output + ',,,'  /* Fields 7,8,9 */

				SET @ls_output = @ls_output + ',' + LEFT((@is_agy_name), 20) /** Agy Name **/
				
				SET @ls_output = @ls_output + ',,,'  /* Fields 11,12,13 */

				--PRINT @ls_output
			
				SET @is_export_file = @ls_output

				SET @ctrl_hash_total = @ctrl_hash_total + CAST(SUBSTRING(@vn_acct_nbr, 3, 11) AS dec(18))
			
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
					@pay_to_code=PAY_TO_CODE, @vn_name=PAY_TO, 
					@ap_inv_date=REPLACE(CONVERT(VARCHAR(10), CHECK_DATE, 101), '/', ''), 
					@payment_date=@payment_date, --Keep original
					@ap_chk_nbr=CHECK_NBR, 
					@ap_chk_amt=CHECK_AMT, 
					@ap_disc_amt=DISC_AMT, 
					@vn_acct_nbr=VN_ACCT_NBR
				FROM @pmt_mgr_invoices
				WHERE [RECID] = @recid;

			END  /* LOOP */

			SET @ctrl_rec_cnt = @cnt	

			IF @ctrl_rec_cnt > 49999 BEGIN
				SET @is_log = 'Transaction record count exceeds the 49,999 limit for individualised payments.'
				SET @success = 0
				GOTO FINISH_IT
			END

			--SELECT @recid '@recid', @rec_cnt '@rec_cnt'

			-- Write the Trailer record

			--SELECT @ctrl_total_pmt_amt, @ctrl_rec_cnt, @ctrl_hash_total

			SET @str_amt = CAST((@ctrl_total_pmt_amt * 100) AS varchar(50))
			SET @str_amt = LEFT(@str_amt, LEN(@str_amt) - 3) 

			SET @ls_hdr = '3' /* Record Type */
			SET @ls_hdr = @ls_hdr + ',' + @str_amt  /* Total Pmt Amt */
			SET @ls_hdr = @ls_hdr + ',' + CAST((@ctrl_rec_cnt) AS varchar(50))

			SELECT 'HT', @ctrl_hash_total, CAST((@ctrl_hash_total) AS varchar(50))

			SET @str_amt = CAST((@ctrl_hash_total) AS varchar(50))
			SET @str_amt = '00000000000' + @str_amt /* left fill */
			SET @str_amt = RIGHT(@str_amt, 11) /* keep right,ost 11 digits */

			SET @ls_hdr = @ls_hdr + ',' + @str_amt  /* Hash Amt */

			SET @is_export_file = @ls_hdr

			IF @cnt > 0 --Detail rows exist
			BEGIN
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
	FINISH_IT:
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

GRANT EXECUTE ON [advsp_pmt_mgr_bnz] TO PUBLIC AS dbo
GO


