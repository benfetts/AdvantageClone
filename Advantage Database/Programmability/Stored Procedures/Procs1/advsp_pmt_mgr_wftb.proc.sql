
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_pmt_mgr_wftb]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_pmt_mgr_wftb]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[advsp_pmt_mgr_wftb] 
@is_chk_run varchar(50), @is_bank varchar(50)


AS

--DECLARE @is_chk_run varchar(50) = 'op-SYSADM-2016/04/01 09:17:10', 
--		@is_bank varchar(50) = 'op'

/*
PJH 11/01/21 - New Format - Wray Ward - Fifth Third Bank (Integrated Payables) format
*/

DECLARE @as_chk_run varchar(50), @as_bank varchar(50),  @is_bank_id varchar (50), @il_bk_routing_nbr bigint
DECLARE @is_ach_company_id varchar(10), @is_ach_company_name varchar(30), @is_bk_routing_nbr varchar(100)
DECLARE @is_ach_std_entry_class varchar(3)
DECLARE @is_pm_type varchar(50), @is_pm_acct varchar(50), @is_bank_desc varchar(50), @is_pm_id varchar(10)
DECLARE @is_pm_word varchar(50),@is_pm_dir varchar(100), @is_pm_ftp varchar(254)
DECLARE @is_export_file varchar(max), @is_output_file varchar(100), @il_file_num int
DECLARE @is_log varchar(max), @success int, @cnt int
/* Agency Vars */
DECLARE @is_currency_code varchar(50), @is_agy_name varchar(50), @is_agy_reply_to varchar(50)
DECLARE @is_agy_addr varchar(50), @is_agy_addr2 varchar(50), @is_agy_city varchar(50), @is_agy_state varchar(50)
DECLARE @is_agy_zip varchar(10), @is_agy_phone varchar(15)
DECLARE @il_asp int, @is_import_path varchar(254)

DECLARE @id_create_date smalldatetime
DECLARE @is_create_date varchar(10)
DECLARE @is_create_time varchar(10)

DECLARE @recid int, @rec_cnt int

SET @id_create_date = GetDate()

SET @is_create_date = (CONVERT(VARCHAR(10), @id_create_date, 101)) 
--SET @id_create_date = LEFT(REPLACE(CONVERT(VARCHAR(12), @id_create_date, 108), ':',''), 4)

SET @as_chk_run = @is_chk_run
SET @as_bank = @is_bank

--IF OBJECT_ID('tempdb..#pmt_mgr_invoices') IS NOT NULL
--DROP TABLE #pmt_mgr_invoices

DECLARE @pmt_mgr_invoices TABLE (
	/*  AP_HEADER   */
	[RECID] INT identity(1,1),
	[AP_ID] [int] NOT NULL,
	[VN_FRL_EMP_CODE] [varchar](6) NOT NULL,
	[AP_INV_VCHR] [varchar](20) NOT NULL,
	[AP_DESC] [varchar](30) NULL,
	[AP_INV_DATE] [smalldatetime] NOT NULL,
	[AP_DATE_PAY] [smalldatetime] NOT NULL,
	[AP_INV_AMT] [decimal](14, 2) NOT NULL,
	[AP_GROSS_AMT] [decimal](14, 2) NOT NULL,
	/*  AP_PMT_HIST   */
	[AP_CHK_NBR] [int] NOT NULL,
	[AP_CHK_DATE] [smalldatetime] NOT NULL,
	[AP_CHK_AMT] [decimal](14, 2) NULL,
	[AP_DISC_AMT] [decimal](11, 2) NULL,
	[GLEXACT] [int] NOT NULL,
	/*  CHECK_REGISTER   */
	[PAY_TO_CODE] [varchar](6) NULL,
	[EMAIL_DATE] [smalldatetime] NULL,
	[EXPORT_DATE] [smalldatetime] NULL,
	[EFILE_DATE] [smalldatetime] NULL,
	[CHECK_AMT] [decimal](14, 2) NULL,
	[DISC_AMT] [decimal](14, 2) NULL,
	[POST_PERIOD] [varchar](6) NULL,
	[CHECK_RUN_ID] [varchar](50) NOT NULL,
	[BK_CODE] [varchar](4) NOT NULL,
	[CHECK_NBR] [int] NOT NULL,
	/*  VENDOR   */
	[PYMT_MGR_EMAIL] [varchar](50) NULL,
	[VN_ACCT_NBR] [varchar](30) NULL,
	[VN_PAY_TO_NAME] [varchar](40) NULL,
	[VN_PAY_TO_ADDRESS1] [varchar](40) NULL,
	[VN_PAY_TO_ADDRESS2] [varchar](40) NULL,
	[VN_PAY_TO_ADDRESS3] [varchar](40) NULL,
	[VN_PAY_TO_CITY] [varchar](25) NULL,
	[VN_PAY_TO_COUNTY] [varchar](20) NULL,
	[VN_PAY_TO_STATE] [varchar](10) NULL,
	[VN_PAY_TO_COUNTRY] [varchar](20) NULL,
	[VN_PAY_TO_ZIP] [varchar](10) NULL,
	[VN_FAX_NUMBER] [varchar](13) NULL,
	[VN_EMAIL] [varchar](50) NULL,
	/*  FLAG   */
	[SELECTED_FLAG] [smallint] NULL)

BEGIN TRY

	--SELECT 'TRY'

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
	SELECT	@is_pm_type=COALESCE(PYMT_MGR_TYPE, ''),	@is_pm_acct=COALESCE(BK_ACCOUNT_NO, ''), @is_bank_desc=COALESCE(BK_DESCRIPTION, ''), @is_pm_id=COALESCE(PYMT_MGR_ID, ''), 
			@is_pm_word=COALESCE(PYMT_MGR_WORD, ''), @is_bk_routing_nbr=COALESCE(CAST(BK_ROUTING_NBR AS varchar(100)), ''), @is_ach_company_id=COALESCE(ACH_COMPANY_ID, ''), 
			@is_pm_dir=COALESCE(PYMT_MGR_DIR, ''), @is_pm_ftp=COALESCE(PYMT_MGR_FTP, ''), @is_ach_company_name=COALESCE(ACH_COMPANY_NAME, ''),
			@is_bank_id=COALESCE(B.BANK_ID, ''), @is_ach_std_entry_class=COALESCE(ACH_STD_ENTRY_CLASS_CODE, '')
	FROM	BANK A LEFT JOIN BANK_EXP_SPEC B ON A.BK_CODE = B.BK_CODE 
	WHERE	A.BK_CODE = @as_bank;

	SELECT @il_file_num = LAST_NBR + 1
	FROM ASSIGN_NBR
	WHERE COLUMNNAME = 'PYMT_MGR_NBR';

	UPDATE ASSIGN_NBR
		SET LAST_NBR = @il_file_num
		WHERE COLUMNNAME = 'PYMT_MGR_NBR'
		AND LAST_NBR = @il_file_num - 1;
				
	IF @@ERROR > 0 OR @@ROWCOUNT = 0 BEGIN
		SELECT @@ERROR 'ERROR NO'
		RETURN
	END	

	--SELECT @is_pm_dir '@is_pm_dir' , @is_pm_type '@is_pm_type' , @is_pm_acct '@is_pm_acct' , @is_pm_id '@is_pm_id' , @is_pm_ftp '@is_pm_ftp', @il_file_num '@il_file_num'
	
	SET @is_pm_type = UPPER(RTRIM(@is_pm_type))
	SET @is_pm_acct = UPPER(RTRIM(@is_pm_acct))
	SET @is_pm_id = UPPER(RTRIM(@is_pm_id))

	SELECT @il_asp = ASP_ACTIVE, @is_import_path = IMPORT_PATH, @is_agy_name = NAME
	FROM   AGENCY;

	SELECT @il_asp = ISNULL(@il_asp, 0)

	IF (@il_asp = 1) BEGIN

		IF @is_pm_type = 'WFTB' BEGIN  /* Wray Ward Fifth Third Bank */
	
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

	SET @is_pm_dir = UPPER(RTRIM(@is_pm_dir))

	IF (@is_pm_dir='') 
	BEGIN
		SET @is_log = @is_log + 'The File Output Directory in Bank Maintenance does not exist.'  + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	EXEC @is_create_date = advfn_clear_special_characters  @is_create_date, '0-9'
	SET @is_create_time = CONVERT(VARCHAR(10), @id_create_date, 114)
	EXEC @is_create_time = advfn_clear_special_characters  @is_create_time, '0-9'

	SET @is_output_file = @is_pm_acct + '_IP_' + @is_create_date + '_' + CAST(@il_file_num AS varchar(20)) + '.csv'
	
	--SELECT '01: ' + @is_pm_dir + ' | ' + @is_pm_type + ' | ' + @is_pm_acct + ' | ' + @is_pm_id + ' | ' + @is_pm_ftp + ' | ' + @is_output_file

	/* Get Agency Data */
	/*
	SELECT @is_currency_code=HOME_CRNCY, @is_agy_name=NAME, @is_agy_reply_to=POP3_REPLY_TO,
		@is_agy_addr=COALESCE(RTRIM(ADDRESS1),'') + ', ', @is_agy_addr2=	COALESCE(RTRIM(ADDRESS2),'') + ', ', 
		@is_agy_city=COALESCE(RTRIM(CITY),'') + ', ', @is_agy_state=COALESCE(RTRIM(STATE),'') + ', ', @is_agy_zip=COALESCE(RTRIM(ZIP),''), @is_agy_phone=Replace(Replace(Replace(Replace(Replace(PHONE,'(',''),' ',''),'.',''),')',''),'-','')
	FROM   AGENCY;

	IF @is_agy_addr2 > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_addr2
	IF @is_agy_city > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_city
	IF @is_agy_state > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_state
	IF @is_agy_zip > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_zip
	*/

	BEGIN
		INSERT INTO @pmt_mgr_invoices
				   (AP_ID
				   ,VN_FRL_EMP_CODE
				   ,AP_INV_VCHR
				   ,AP_DESC
				   ,AP_INV_DATE
				   ,AP_DATE_PAY
				   ,AP_INV_AMT
				   ,AP_GROSS_AMT
				   ,AP_CHK_NBR
				   ,AP_CHK_DATE
				   ,AP_CHK_AMT
				   ,AP_DISC_AMT
				   ,GLEXACT
				   ,PAY_TO_CODE
				   ,EMAIL_DATE
				   ,EXPORT_DATE
				   ,EFILE_DATE
				   ,CHECK_AMT
				   ,DISC_AMT
				   ,POST_PERIOD
				   ,CHECK_RUN_ID
				   ,BK_CODE
				   ,CHECK_NBR
				   ,PYMT_MGR_EMAIL
				   ,VN_ACCT_NBR
				   ,VN_PAY_TO_NAME
				   ,VN_PAY_TO_ADDRESS1,	 VN_PAY_TO_ADDRESS2, VN_PAY_TO_ADDRESS3, VN_PAY_TO_CITY
				   ,VN_PAY_TO_COUNTY,	 VN_PAY_TO_STATE, VN_PAY_TO_ZIP, VN_PAY_TO_COUNTRY           
				   ,VN_FAX_NUMBER, VN_EMAIL
				   ,SELECTED_FLAG)
    			  SELECT AP_HEADER.AP_ID,
    				 AP_HEADER.VN_FRL_EMP_CODE, 
					 AP_HEADER.AP_INV_VCHR,
					 COALESCE(AP_HEADER.AP_DESC, ''),
					 AP_HEADER.AP_INV_DATE,
					 COALESCE(AP_HEADER.AP_DATE_PAY, ''), 
					 AP_HEADER.AP_INV_AMT,  	  
					 COALESCE(AP_HEADER.AP_INV_AMT, 0.00) + COALESCE(AP_HEADER.AP_SHIPPING, 0.00) + COALESCE(AP_HEADER.AP_SALES_TAX, 0.00) AS AP_GROSS_AMT,						 
    				 AP_PMT_HIST.AP_CHK_NBR,
					 AP_PMT_HIST.AP_CHK_DATE,
					 AP_PMT_HIST.AP_CHK_AMT,
					 COALESCE(AP_PMT_HIST.AP_DISC_AMT, 0.00) AS AP_DISC_AMT,   
					 COALESCE(AP_PMT_HIST.GLEXACT, 0),
					 COALESCE(CHECK_REGISTER.PAY_TO_CODE, ''),   
					 CHECK_REGISTER.EMAIL_DATE,
					 CHECK_REGISTER.EXPORT_DATE,
					 CHECK_REGISTER.EFILE_DATE,			
					 CHECK_REGISTER.CHECK_AMT,   
					 CHECK_REGISTER.DISC_AMT,   
					 COALESCE(CHECK_REGISTER.POST_PERIOD, ''),
					 CHECK_REGISTER.CHECK_RUN_ID,
					 CHECK_REGISTER.BK_CODE,
					 CHECK_REGISTER.CHECK_NBR, 
					 COALESCE(VENDOR.PYMT_MGR_EMAIL, ''),   
					 VENDOR.VN_ACCT_NBR,
					 COALESCE(VENDOR.VN_PAY_TO_NAME, '') VN_NAME,   
					 COALESCE(VENDOR.VN_PAY_TO_ADDRESS1, '') VN_ADDRESS1, COALESCE(VENDOR.VN_PAY_TO_ADDRESS2, '') VN_ADDRESS2, COALESCE(VENDOR.VN_PAY_TO_ADDRESS3, '') VN_ADDRESS3, COALESCE(VENDOR.VN_PAY_TO_CITY, '') VN_CITY,
					 COALESCE(VENDOR.VN_PAY_TO_COUNTY, '') VN_COUNTY, COALESCE(VENDOR.VN_PAY_TO_STATE, '') VN_STATE, COALESCE(VENDOR.VN_PAY_TO_ZIP, '') VN_ZIP, COALESCE(VENDOR.VN_PAY_TO_COUNTRY, '') VN_COUNTRY,
					 COALESCE(VENDOR.VN_PAY_TO_FAX_NBR, '') VN_FAX_NUMBER, COALESCE(VENDOR.VN_PAY_TO_EMAIL, VENDOR.VN_EMAIL, '') VN_EMAIL,	
					 1
				FROM CHECK_REGISTER,   
					 AP_PMT_HIST,   
					 AP_HEADER,   
					 VENDOR  
			   WHERE ( CHECK_REGISTER.BK_CODE = AP_PMT_HIST.BK_CODE ) and  
					 ( CHECK_REGISTER.CHECK_NBR = AP_PMT_HIST.AP_CHK_NBR ) and  
					 ( CHECK_REGISTER.PAY_TO_CODE = VENDOR.VN_CODE ) and  
					 ( AP_HEADER.AP_ID = AP_PMT_HIST.AP_ID ) and  
					 ( AP_HEADER.AP_SEQ = AP_PMT_HIST.AP_SEQ ) and  
					 ( CHECK_REGISTER.CHECK_RUN_ID = @as_chk_run ) AND  
					 ( CHECK_REGISTER.VOID_FLAG = 0 OR CHECK_REGISTER.VOID_FLAG is NULL ) AND  
					 (CHECK_REGISTER.BK_CODE = @as_bank  );

		SET @rec_cnt = @@ROWCOUNT

		--SELECT 'Pmt Mgr Invoices' '*', * FROM @pmt_mgr_invoices;
	END

	DECLARE @ls_hdr varchar(max), @ls_output varchar(max)
	DECLARE @ap_desc varchar(50), @ls_mail varchar(50)

	DECLARE @pay_to_code varchar(50), @vn_name varchar(50), @pay_to_code_prev varchar(100)
	DECLARE @vn_routing_nbr varchar(20), @vn_acct_nbr_full varchar(30), @vn_acct_nbr varchar(30)
	DECLARE @vn_rec_id int
	DECLARE @vn_pay_to_address1 varchar(30), @vn_pay_to_address2 varchar(30), @vn_pay_to_address3 varchar(30), @vn_pay_to_city varchar(20)
	DECLARE @vn_pay_to_county varchar(30), @vn_pay_to_state varchar(2), @vn_pay_to_zip varchar(12), @vn_pay_to_country varchar(3)
	DECLARE @pymt_mgr_email varchar(50), @vn_email varchar(50), @vn_fax_number varchar(50)

	DECLARE @ap_inv_vchr varchar(50), @ap_inv_date varchar(30), @payment_date varchar(30) 
	DECLARE @ap_chk_nbr varchar(50), @ap_chk_amt decimal(14,2), @ap_disc_amt decimal(14,2)
	DECLARE @ap_inv_amt decimal(14,2), @inv_gross_amt decimal(14,2), @check_amt decimal(14,2)
	DECLARE @amt_sign varchar(1), @str_amt varchar(20)

	DECLARE @chk_cnt int = 0 /* Trasaction Nbr */
	DECLARE @inv_cnt int = 0 /* Sequence Nbr within Transaction Nbr */
	DECLARE @ap_chk_amt_total decimal(14,2) = 0

	DECLARE @ap_chk_nbr_prev varchar(50)

	DECLARE @bank_lvl_msg bit = 0

	DECLARE @elements int

	DECLARE @vn_acct_data TABLE (
		[RECID] INT identity(1,1),
		[VALUE] varchar(100)
		)
	SET @pay_to_code_prev = ''

	SET @id_create_date = [dbo].[fn_get_nth_workday](@id_create_date, + 1)
	SET @is_create_date = CONVERT(VARCHAR(10), @id_create_date, 101)
	SET @is_create_time = CONVERT(VARCHAR(10), @id_create_date, 114)
	EXEC @is_create_time = advfn_clear_special_characters  @is_create_time, '0-9'
	SET @is_create_time = LEFT(@is_create_time, 4)

	IF @success = 1 AND @rec_cnt > 0
		BEGIN

			SET @recid = 1

			--DECLARE db_cursor CURSOR FOR  
			SELECT @ap_desc=AP_DESC, @pymt_mgr_email=PYMT_MGR_EMAIL, @vn_email=VN_EMAIL, @pay_to_code=PAY_TO_CODE, @vn_name=VN_PAY_TO_NAME, @ap_inv_vchr=AP_INV_VCHR, 
				@ap_inv_date=REPLACE(CONVERT(VARCHAR(10), AP_INV_DATE, 101), '/', ''), 
				@ap_chk_nbr=AP_CHK_NBR, @ap_chk_amt=AP_CHK_AMT, @ap_disc_amt=AP_DISC_AMT, @vn_fax_number=VN_FAX_NUMBER, 
				@vn_pay_to_address1=VN_PAY_TO_ADDRESS1, @vn_pay_to_address2=VN_PAY_TO_ADDRESS2,  @vn_pay_to_address3=VN_PAY_TO_ADDRESS3,
				@vn_pay_to_city=VN_PAY_TO_CITY, @vn_pay_to_county=VN_PAY_TO_COUNTY, @vn_pay_to_state=VN_PAY_TO_STATE, @vn_pay_to_zip=VN_PAY_TO_ZIP, @vn_pay_to_country=VN_PAY_TO_COUNTRY,
				@vn_acct_nbr_full=VN_ACCT_NBR, @ap_inv_amt=AP_INV_AMT, @check_amt=CHECK_AMT 
			FROM @pmt_mgr_invoices
			WHERE [RECID] = @recid;


			/* Uncomment if we need column headers */

			--SET @ls_hdr = 'Payee Identifier,Payee Name,Email Address,Fax Number,Gross Amount,Discount Amount,Net Amount,Check Number,Invoice Number,Invoice Date,Payment Date,Description,Account Code,Customer ID,Address Line 1,Address Line 2,Address Line 3,Address Line 4,City,State,Zip,Country,Optional Data 1,Optional Data 2,Optional Data 3'

			IF @bank_lvl_msg = 0 BEGIN

				IF LEN(@is_ach_company_id) > 6 
				BEGIN
					SET @is_log = @is_log + 'The Payment Manager ACH Company ID on the bank record exceeds the maximum length of 6.'  + CHAR(13)
					SET @success = 0
				END

				IF LEFT(@is_ach_company_id, 1) <> 'Q'
				BEGIN
					SET @is_log = @is_log + 'The Payment Manager ACH Company ID on the bank record must be 6 characters and start with "Q".'  + CHAR(13)
					SET @success = 0
				END

				IF LEN(@is_ach_company_name) > 15
				BEGIN
					SET @is_log = @is_log + 'The Payment Manager ACH Company Name on the bank record exceeds the maximum length of 15.'  + CHAR(13)
					SET @success = 0
				END

				IF LEN(@is_bank_id) > 10
				BEGIN
					SET @is_log = @is_log + 'The Payment Manager Bank ID on the bank record exceeds the maximum length of 10.'  + CHAR(13)
					SET @success = 0
				END

				IF LEN(@is_bk_routing_nbr) <> 9
				BEGIN
					SET @is_log = @is_log + 'The bank Routing Number on the bank record must be 9 numeric characters.'  + CHAR(13)
					SET @success = 0
				END

				IF LEN(@is_pm_acct) > 35
				BEGIN
					SET @is_log = @is_log + 'The bank Account Number on the bank record exceeds the maximum length of 35.'  + CHAR(13)
					SET @success = 0
				END

				SET @bank_lvl_msg = 1

			END

			EXEC @is_ach_company_name = advfn_clear_special_characters  @is_ach_company_name, 'A-Za-z0-9 @#$:.-'

			-- Write Header Record
			SET @ls_hdr = 'HEADER' /* Record ID */
			SET @ls_hdr = @ls_hdr + ',' + @is_ach_company_id /* CLient ID */
			SET @ls_hdr = @ls_hdr + ',' /* Not Used */	
			SET @ls_hdr = @ls_hdr + ',' + @is_create_date /* File Date */
			SET @ls_hdr = @ls_hdr + ',' + @is_create_time 	
			SET @ls_hdr = @ls_hdr + ',' + @is_ach_company_name /* Sender Identifier Name */ /* @is_bank_id */
			SET @ls_hdr = @ls_hdr + ',' + CONVERT(VARCHAR(6), @id_create_date, 12) /* File Sequence Number YYMMDD */
			SET @ls_hdr = @ls_hdr + RIGHT('000' + CAST(@il_file_num AS varchar(20)), 3) /* File Sequence Number ### */
			SET @ls_hdr = @ls_hdr + ',,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,'
			SET @ls_hdr = @ls_hdr + 'X'  /* Line Terminator ) */
			
			SET @is_export_file = @ls_hdr

			IF @success = 1 BEGIN

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
			
			WHILE @recid <= @rec_cnt
			BEGIN

				IF @ap_chk_nbr <> @ap_chk_nbr_prev OR @chk_cnt = 0 BEGIN

					SET @ap_chk_nbr_prev = @ap_chk_nbr
					SET @chk_cnt = @chk_cnt + 1
					SET @inv_cnt = 1
				--END

					SET @ls_mail = @pymt_mgr_email
					IF (@ls_mail = '') SET @ls_mail = @vn_email

					IF @pay_to_code <> @pay_to_code_prev BEGIN

						DELETE @vn_acct_data

						SET @vn_name = COALESCE(@vn_name, '')
						SET @vn_acct_nbr_full = COALESCE(@vn_acct_nbr_full, '')

						SET @elements = 0
						IF @vn_acct_nbr_full > '' BEGIN
							INSERT INTO @vn_acct_data
							SELECT * FROM dbo.udf_split_list(@vn_acct_nbr_full, '|')

							SET @elements = @@ROWCOUNT
							SELECT @vn_rec_id = MIN(RECID) FROM @vn_acct_data
						END

						/*
							[VN_BK_ROUTING_NBR] varchar(9),
							[VN_ACCT_ITEM] varchar(25)
						*/

						IF @elements = 2 BEGIN
							SELECT @vn_routing_nbr = VALUE FROM @vn_acct_data WHERE RECID = @vn_rec_id
							SELECT @vn_acct_nbr = VALUE FROM @vn_acct_data WHERE RECID = (@vn_rec_id + 1)
						END
						ELSE BEGIN
							IF @pay_to_code <> @pay_to_code_prev BEGIN
								SET @success = 0
							END
						END

						IF LEN(ISNULL(@vn_routing_nbr, '')) <> 9
						BEGIN
							SET @is_log = @is_log + 'The vendor Routing Number for vendor (' + @pay_to_code + ') must be 9 numeric characters. Sample (Vendor Account: Routing Nbr|Account Nbr) or (Vendor Account: 999999999|112233445566).'  + CHAR(13)
							SET @success = 0
						END

						IF LEN(@vn_acct_nbr) > 35
						BEGIN
							SET @is_log = @is_log + 'The vendor Account Number for vendor (' + @pay_to_code + ') exceeds the maximum length of 35. Sample (Vendor Account: Routing Nbr|Account Nbr) or (Vendor Account: 999999999|112233445566).'  + CHAR(13)
							SET @success = 0
						END			

						SET @pay_to_code_prev = @pay_to_code

					END

					EXEC @is_bk_routing_nbr = advfn_clear_special_characters  @is_bk_routing_nbr, '0-9' 
					EXEC @vn_routing_nbr = advfn_clear_special_characters  @vn_routing_nbr, '0-9' 		
					EXEC @vn_name = advfn_clear_special_characters  @vn_name, 'A-Za-z0-9 @#$:.-'
					EXEC @is_agy_name = advfn_clear_special_characters  @is_agy_name, 'A-Za-z0-9 @#$:.-'
					EXEC @is_bank_desc = advfn_clear_special_characters  @is_bank_desc, 'A-Za-z0-9 @#$:.-'

					IF LEN(@str_amt) > 18
					BEGIN
						SET @is_log = 'The Net Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 18 characters in length.'
						SET @success = 0
						BREAK
					END	

					IF @chk_cnt > 999 
					BEGIN
						SET @is_log = @is_log + 'The export Transaction Number has exceeded 999 checks. The export can not continue.' + CHAR(13)
						SET @success = 0
					END

					IF @inv_cnt > 999 
					BEGIN
						SET @is_log = @is_log + 'The export Sequence Number has exceeded 999 invoices. The export can not continue.' + CHAR(13)
						SET @success = 0
					END

					-- Write ACH Detail Record
					SET @ls_output = 'ACH' /* Record ID */
					SET @ls_output = @ls_output + ',' + RIGHT('000' + CAST(@chk_cnt AS varchar(9)), 3) /* Sequence Number ### */ /* Transaction Nbr */
					SET @ls_output = @ls_output + ',' + RIGHT('000' + CAST(@inv_cnt AS varchar(6)), 3) /* Sequence Number ### */ /* Sequence Nbr */
					SET @ls_output = @ls_output + ',' + @is_bk_routing_nbr /* Bank Routing Nbr */
					SET @ls_output = @ls_output + ',' + @is_pm_acct /* Bank Acct Nbr */  
					SET @ls_output = @ls_output + ',' + LEFT(@is_agy_name, 35) /* Originator Name - Bank Desc */  --@is_bank_desc
					SET @ls_output = @ls_output + ',,,,,,,' /* Not Used (G-M) */	
					SET @ls_output = @ls_output + ',' + UPPER(LEFT((@vn_name), 22)) + ''/** Vendor Name **/
					SET @ls_output = @ls_output + ',,,,,,,' /* Not Used (O-U) */
				
					SET @str_amt = RIGHT(CAST(@check_amt AS varchar(18)), 18) /* or @ap_inv_amt */

					SET @ap_chk_amt_total = @ap_chk_amt_total + @check_amt

					--SET @ls_output = @ls_output + ',' + @ap_chk_amt /* Pmt Amt */
					SET @ls_output = @ls_output + ',' + @str_amt --RIGHT(CAST(@ap_chk_amt AS varchar(18)), 18)
					--SET @ls_output =  @ls_output + ',' + LEFT((@payment_date), 2) + '/' + SUBSTRING((@payment_date), 3, 2) + '/' + RIGHT((@payment_date), 4) + '' /** Pmt Date - Today **/
					SET @ls_output =  @ls_output + ',' +  CONVERT(VARCHAR(10), @id_create_date, 1)

					SET @ls_output = @ls_output + ',,,,,,,' /* Not Used (X-AD) */

					SET @ls_output = @ls_output + ',' + @is_ach_std_entry_class /* Pmt Fmt Code - CCD, PPD, etc. */ 

					SET @ls_output = @ls_output + ',' + @vn_routing_nbr /* Vendor Routing Nbr */
					SET @ls_output = @ls_output + ',' + @vn_acct_nbr /* Vendor Acct Nbr */  
				
					SET @ls_output = @ls_output + ',' + @is_bank_id /* Company ID */  /* @is_ach_company_name */

					SET @ls_output = @ls_output + ',' + 'C' /* Credit 'C' or Debit 'D' */
				
					SET @ls_output =  @ls_output + ',' + UPPER(LEFT((@ap_chk_nbr), 15)) + '' /** Check Nbr */

					--SET @ls_output =  @ls_output + ',' + UPPER(LEFT((@ap_inv_vchr), 15)) + '' /** Invoice Nbr */
				
					SET @ls_output = @ls_output + ',,,,,,,,,,,,' /* Not Used (AK-AU) */

					SET @ls_output = @ls_output + 'X'  /* Line Terminator ) */
				
					SET @is_export_file = @ls_output
			
					IF @success = 1 BEGIN
					
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
						   
				END	
			
				SET @cnt = @cnt + 1
				
				SET @recid = @recid + 1

				SET @inv_cnt = @inv_cnt + 1
			
				SELECT @ap_desc=AP_DESC, @pymt_mgr_email=PYMT_MGR_EMAIL, @vn_email=VN_EMAIL, @pay_to_code=PAY_TO_CODE, @vn_name=VN_PAY_TO_NAME, @ap_inv_vchr=AP_INV_VCHR, 
					@ap_inv_date=REPLACE(CONVERT(VARCHAR(10), AP_INV_DATE, 101), '/', ''),
					@ap_chk_nbr=AP_CHK_NBR, @ap_chk_amt=AP_CHK_AMT, @ap_disc_amt=AP_DISC_AMT, @vn_fax_number=VN_FAX_NUMBER, 
					@vn_pay_to_address1=VN_PAY_TO_ADDRESS1, @vn_pay_to_address2=VN_PAY_TO_ADDRESS2,  @vn_pay_to_address3=VN_PAY_TO_ADDRESS3,
					@vn_pay_to_city=VN_PAY_TO_CITY, @vn_pay_to_county=VN_PAY_TO_COUNTY, @vn_pay_to_state=VN_PAY_TO_STATE, @vn_pay_to_zip=VN_PAY_TO_ZIP, @vn_pay_to_country=VN_PAY_TO_COUNTRY,
					@vn_acct_nbr_full=VN_ACCT_NBR, @ap_inv_amt=AP_INV_AMT, @check_amt=CHECK_AMT 
				FROM @pmt_mgr_invoices
				WHERE [RECID] = @recid;

			END  /* LOOP */

			IF @chk_cnt > 0 --Detail rows exist
			BEGIN

				-- Write Trailer Record
				SET @ls_output = 'TRAILER' /* Record ID */
				SET @ls_output = @ls_output + ',,' /* Not USed (B-C) */
				SET @ls_output = @ls_output + ',' + CAST(@chk_cnt AS varchar(8)) /* Nbr of Pmts */
				SET @ls_output = @ls_output + ',,,,,,,,,,,,,,,,,' /* Not USed (E-U) */
				SET @ls_output = @ls_output + ',' + CAST(@ap_chk_amt_total AS varchar(18)) /* Total Check Amt */
				SET @ls_output = @ls_output + ',' /* Paid Amt */
				SET @ls_output = @ls_output + ',' /* Gross Amt */
				SET @ls_output = @ls_output + ',' /* Adjustment Amt */
				SET @ls_output = @ls_output + ',,,,,,,,,,,,,,,,,,,,,,,' /* Not USed (AB-AU) */
				SET @ls_output = @ls_output + 'X'  /* Line Terminator ) */

				SET @is_export_file = @ls_output

				IF @success = 1 BEGIN
			
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
						   			   
			END
				   
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

	RETURN @success       -----<<<<<<<<<<<<******************

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
   
   --RETURN 0 /* Failed */
    
END CATCH

SELECT * FROM W_PMT_MGR_EXPORT

GO

GRANT EXECUTE ON [advsp_pmt_mgr_wftb] TO PUBLIC AS dbo
GO
