
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_pmt_mgr_paymodex]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_pmt_mgr_paymodex]
GO


/****** Object:  StoredProcedure [dbo].[advsp_pmt_mgr_paymodex]    Script Date: 12/03/2015 15:09:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[advsp_pmt_mgr_paymodex] 
@is_chk_run varchar(50), @is_bank varchar(50)

AS

/* PJH 04/11/17 - Added new Paymode-X format */
/* PJH 05/08/17 - Added Vendor Name - Position 11 */

DECLARE @as_chk_run varchar(50), @as_bank varchar(50)
DECLARE @is_pm_type varchar(50), @is_pm_acct varchar(50), @is_bank_desc varchar(50), @is_pm_id varchar(10)
DECLARE @is_pm_word varchar(50), @is_bk_routing_nbr varchar(50), @is_ach_company_id varchar(10)
DECLARE @is_pm_dir varchar(100), @is_pm_ftp varchar(254), @is_export_file varchar(max)
DECLARE @is_log varchar(max), @is_output_file varchar(100), @success int

/* Agency Vars */
DECLARE @il_asp int, @is_import_path varchar(254)

DECLARE @recid int, @rec_cnt int, @chl_del_flag varchar(2)

SET @as_chk_run = @is_chk_run
SET @as_bank = @is_bank

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
	[CHECK_DATE] [smalldatetime] NOT NULL,
	[CHECK_AMT] [decimal](14, 2) NULL,
	[DISC_AMT] [decimal](14, 2) NULL,
	[POST_PERIOD] [varchar](6) NULL,
	[CHECK_RUN_ID] [varchar](50) NOT NULL,
	[BK_CODE] [varchar](4) NOT NULL,
	[CHECK_NBR] [int] NOT NULL,
	/*  VENDOR   */
	[VN_ACCT_NBR] [varchar](30) NULL,
	[PYMT_MGR_EMAIL] [varchar](50) NULL,
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

	--SELECT * FROM BANK

	/* Get Bank Data */
	SELECT @is_pm_type=COALESCE(PYMT_MGR_TYPE, ''),	@is_pm_acct=COALESCE(BK_ACCOUNT_NO, ''), @is_bank_desc=COALESCE(BK_DESCRIPTION, ''), @is_pm_id=COALESCE(PYMT_MGR_ID, ''), 
			 @is_pm_word=COALESCE(PYMT_MGR_WORD, ''),	@is_bk_routing_nbr=COALESCE(BK_ROUTING_NBR, ''), @is_ach_company_id=COALESCE(ACH_COMPANY_ID, ''), 
			 @is_pm_dir=COALESCE(PYMT_MGR_DIR, ''), @is_pm_ftp=COALESCE(PYMT_MGR_FTP, '')
	FROM   BANK
	WHERE  BK_CODE = @as_bank;

	SELECT @is_pm_dir '@is_pm_dir' , @is_pm_type '@is_pm_type' , @is_pm_acct '@is_pm_acct' , @is_bk_routing_nbr '@is_bk_routing_nbr', @is_pm_id '@is_pm_id' , @is_pm_ftp '@is_pm_ftp', @is_pm_word '@is_pm_word'
	
	SET @is_pm_type = UPPER(RTRIM(@is_pm_type))
	SET @is_pm_acct = UPPER(RTRIM(@is_pm_acct))
	SET @is_pm_id = UPPER(RTRIM(@is_pm_id))

	/* PJH 02/26/14 - Added ASP support for export folder */
	SELECT @il_asp = ASP_ACTIVE, @is_import_path = IMPORT_PATH
	FROM   AGENCY;

	SELECT @il_asp = ISNULL(@il_asp, 0)

	IF (@il_asp = 1) BEGIN

		IF RIGHT(@is_import_path, 1) = '\' BEGIN
		
			SET @is_import_path = @is_import_path + 'payment\'
		
		END ELSE BEGIN 
		
			SET @is_import_path = @is_import_path + '\payment\'
		
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

	SET @is_pm_ftp = RTRIM(@is_pm_ftp)

	SET @is_pm_word = UPPER(RTRIM(@is_pm_word))

	SET @is_pm_dir = UPPER(RTRIM(@is_pm_dir))

	IF (@is_pm_dir='') --OR (@is_pm_word='') OR (@is_pm_id='')
	BEGIN
		SET @is_log = 'Unable to obtain Payment Manager directory for bank ' + @as_bank + '.' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF (@is_pm_word='') OR (@is_pm_word='') OR (LEN(@is_pm_word) > 25)
	BEGIN
		SET @is_log = 'Invalid or missing Account ID. ' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF (LEN(@is_bk_routing_nbr) <> 9)
	BEGIN
		SET @is_log = 'Bank Routing Number must be 9 digits.  ' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF LEN(@is_pm_acct) > 17 
	BEGIN
		SET @is_log = @is_log + 'Bank Account Number exceeds 17 digits.  ' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF (@is_pm_dir='') 
	BEGIN
		SET @is_log = @is_log + 'The File Output Directory in Bank Maintenance does not exist.'  + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	SET @is_output_file = @is_pm_type + '_' + REPLACE(CONVERT(VARCHAR(10), GETDATE(), 112), '/', '') +  '_' + REPLACE(CONVERT(VARCHAR(12), GETDATE(), 114), ':','') + '.txt'

	SELECT @is_output_file '@is_output_file'

	--SELECT '01: ' + @is_pm_dir + ' | ' + @is_pm_type + ' | ' + @is_pm_acct + ' | ' + @is_pm_id + ' | ' + @is_pm_ftp + ' | ' + @is_output_file

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
				   ,CHECK_DATE
				   ,EFILE_DATE
				   ,CHECK_AMT
				   ,DISC_AMT
				   ,POST_PERIOD
				   ,CHECK_RUN_ID
				   ,BK_CODE
				   ,CHECK_NBR
				   ,VN_ACCT_NBR
				   ,PYMT_MGR_EMAIL
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
					 CHECK_REGISTER.CHECK_DATE,
					 CHECK_REGISTER.EFILE_DATE,			
					 CHECK_REGISTER.CHECK_AMT,   
					 CHECK_REGISTER.DISC_AMT,   
					 COALESCE(CHECK_REGISTER.POST_PERIOD, ''),
					 CHECK_REGISTER.CHECK_RUN_ID,
					 CHECK_REGISTER.BK_CODE,
					 CHECK_REGISTER.CHECK_NBR, 
					 COALESCE(VN_ACCT_NBR, ''),
					 COALESCE(VENDOR.PYMT_MGR_EMAIL, ''),  
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
					 (CHECK_REGISTER.BK_CODE = @as_bank  )
				ORDER BY CHECK_REGISTER.PAY_TO_CODE, CHECK_REGISTER.CHECK_NBR, AP_HEADER.AP_INV_DATE;

		SET @rec_cnt = @@ROWCOUNT

		--SELECT 'Pmt Mgr Invoices' '*', * FROM @pmt_mgr_invoices;
	END

	DECLARE @ls_hdr varchar(max), @ls_output varchar(max)
	DECLARE @ap_desc varchar(50), @ls_mail varchar(50), @pymt_mgr_email varchar(50), @vn_email varchar(50), @vn_fax_number varchar(50)
	DECLARE @vn_acct_nbr varchar(30)
	DECLARE @vn_pay_to_address1 varchar(30), @vn_pay_to_address2 varchar(30), @vn_pay_to_address3 varchar(30), @vn_pay_to_city varchar(20)
	DECLARE @vn_pay_to_county varchar(30), @vn_pay_to_state varchar(2), @vn_pay_to_zip varchar(12), @vn_pay_to_country varchar(3)

	DECLARE @chk_amt decimal(14,2), @disc_amt decimal(14,2)
	DECLARE @pay_to_code varchar(50), @vn_name varchar(50), @ap_inv_vchr varchar(50), @ap_inv_date varchar(30), @payment_date varchar(30) 
	DECLARE @ap_chk_nbr varchar(50), @ap_chk_amt decimal(14,2), @ap_disc_amt decimal(14,2), @inv_gross_amt decimal(14,2), @ap_inv_amt decimal(14,2)
	DECLARE @amt_sign varchar(1), @str_amt varchar(20)

	DECLARE @cnt_p int, @cnt_r int

	DECLARE @chk_amt_total decimal(14,2), @paymode_type varchar(10)

	DECLARE @pay_to_code_last varchar(50), @ap_chk_nbr_last varchar(50)

	DECLARE  @chk_date varchar(30), @inv_cnt int, @chk_delivery_flag varchar (1)

	
	IF @success = 1 AND @rec_cnt > 0
		BEGIN


			SET @recid = 1
			SET @cnt_p = 0
			SET @cnt_r = 0
			SET @chk_amt_total = 0

			SET @ap_chk_nbr_last = 0

			--DECLARE db_cursor CURSOR FOR  
			SELECT @ap_desc=AP_DESC, @pymt_mgr_email=PYMT_MGR_EMAIL, @vn_email=VN_EMAIL, @pay_to_code=PAY_TO_CODE, @vn_name=VN_PAY_TO_NAME, @ap_inv_vchr=AP_INV_VCHR, 
				@ap_inv_date=REPLACE(CONVERT(VARCHAR(10), AP_INV_DATE, 112), '/', ''), @payment_date=REPLACE(CONVERT(VARCHAR(10), GETDATE(), 112), '/', ''), @ap_inv_amt=AP_INV_AMT,
				@ap_chk_nbr=AP_CHK_NBR, @ap_chk_amt=AP_CHK_AMT, @ap_disc_amt=AP_DISC_AMT, @vn_fax_number=VN_FAX_NUMBER, 
				@vn_acct_nbr=VN_ACCT_NBR,
				@vn_pay_to_address1=VN_PAY_TO_ADDRESS1, @vn_pay_to_address2=VN_PAY_TO_ADDRESS2,  @vn_pay_to_address3=VN_PAY_TO_ADDRESS3,
				@vn_pay_to_city=VN_PAY_TO_CITY, @vn_pay_to_county=VN_PAY_TO_COUNTY, @vn_pay_to_state=VN_PAY_TO_STATE, @vn_pay_to_zip=VN_PAY_TO_ZIP, @vn_pay_to_country=VN_PAY_TO_COUNTRY,
				@chk_amt=CHECK_AMT, @disc_amt=DISC_AMT,
				@chk_date=REPLACE(CONVERT(VARCHAR(10), CHECK_DATE, 112), '/', '')
			FROM @pmt_mgr_invoices
			WHERE [RECID] = @recid;

			--SET @ls_hdr = 'Payee Identifier,Payee Name,Email Address,Fax Number,Gross Amount,Discount Amount,Net Amount,Check Number,Invoice Number,Invoice Date,Payment Date,Description,Account Code,Customer ID,Address Line 1,Address Line 2,Address Line 3,Address Line 4,City,State,Zip,Country,Optional Data 1,Optional Data 2,Optional Data 3'
			
			--SET @is_export_file = @ls_hdr
			
			WHILE @recid <= @rec_cnt AND @success = 1
			BEGIN  
				IF @ap_chk_nbr_last <> @ap_chk_nbr BEGIN
					SET @ap_chk_nbr_last = @ap_chk_nbr 

					SET @ls_mail = @pymt_mgr_email
					IF (@ls_mail = '') SET @ls_mail = @vn_email

					SET @ls_output =  'P' 

					--IF COALESCE(@vn_acct_nbr, '') = '' 
					--BEGIN
					--	SET @is_log = @is_log + 'Vendor Bank Account Number is missing for vendor: ' + @pay_to_code + CHAR(13)
					--	SET @success = 0
					--END

					IF LEN(@vn_acct_nbr) > 25 
					BEGIN
						SET @is_log = @is_log + 'Vendor Bank Account Number exceeds 25 digits for vendor: ' + @pay_to_code + CHAR(13)
						SET @success = 0
					END

					--SET @ls_output =  @ls_output + '|' + 'CHK' 

					/*	PJH 04/24/17 - 
						If Vendor Acct field empty then the payment type should default to EPY
						If the Vendor Acct field has data in it then the payment type should default to ACH */

					IF COALESCE(@vn_acct_nbr, '') = '' 
						SET @paymode_type = 'EPY'
					ELSE
						SET @paymode_type = 'ACH'

					SET @ls_output =  @ls_output + '|' + @paymode_type

					SET @ls_output =  @ls_output + '|' + @is_pm_word  

					SET @ls_output =  @ls_output + '|' + @is_bk_routing_nbr  

					SET @ls_output =  @ls_output + '|' + @is_pm_acct  

					SET @ls_output =  @ls_output + '|' + @vn_acct_nbr  
				
					SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@ap_chk_nbr), 10)) + '' /** Check Nbr */

					--SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_name), 35)) + '' /** Vendor Name **/
					
					SET @ls_output =  @ls_output + '|' /** Check Amt left **/

					SET @str_amt = @chk_amt

					SET @chk_amt_total = @chk_amt_total + @chk_amt

					IF LEN(@str_amt) > 14
					BEGIN
						SELECT @str_amt '@str_amt'
						SET @is_log = 'The Check Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 14 characters in length.'
						SET @success = 0
						BREAK
					END
				
					SET @ls_output = @ls_output + @str_amt + ''  /** Check Amt right quote **/

					SET @ls_output = @ls_output + '|' + UPPER(LEFT((@pay_to_code), 23)) + ''/** Vendor Code **/

					SET @ls_output = @ls_output + '|'  /* Site Id - filler */ 
					
					/* PJH 05/08/17 - Added Vendor Name */
					SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_name), 40)) + '' /** Vendor Name - 40=DB field size **/
				
					BEGIN
						IF @vn_pay_to_address1 IS NULL SET @vn_pay_to_address1 = ''
						IF @vn_pay_to_address2 IS NULL SET @vn_pay_to_address2 = ''
						IF @vn_pay_to_address3 IS NULL SET @vn_pay_to_address3 = ''	
						
						IF @vn_pay_to_country IS NULL SET @vn_pay_to_city = ''		
						IF @vn_pay_to_country IS NULL SET @vn_pay_to_state = ''	
						IF @vn_pay_to_country IS NULL SET @vn_pay_to_zip = ''	

						IF @vn_pay_to_address1 = ''
							IF @vn_pay_to_address2 <> ''
								BEGIN
									SET @vn_pay_to_address1 = @vn_pay_to_address2
									SET @vn_pay_to_address2 = ''
									IF @vn_pay_to_address3 <> ''
										BEGIN
											SET @vn_pay_to_address2 = @vn_pay_to_address3
											SET @vn_pay_to_address3 = ''
										END
								END
							ELSE
								BEGIN
									SET @is_log = 'Missing Address for Vendor (' + @vn_name + ').'
									SET @success = 0
									BREAK
								END	
						
						--IF @vn_pay_to_address2 = ''
						--	IF @vn_pay_to_address3 <> ''
						--		BEGIN
						--			SET @vn_pay_to_address2 = @vn_pay_to_address3
						--			SET @vn_pay_to_address3 = ''
						--		END
						--	ELSE
						--		BEGIN
						--			SET @is_log = 'Missing Address for Vendor (' + @vn_name + ').'
						--			SET @success = 0
						--			BREAK
						--		END							
					END
					--SELECT @pay_to_code, @vn_pay_to_address1, @vn_pay_to_address2, @vn_pay_to_address3
					BEGIN
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_address1), 50)) + '' /** Vendor Addr 1 **/
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_address2), 50)) + '' /** Vendor Addr 2 **/
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_address3), 50)) + '' /** Vendor Addr 3 **/

						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_city), 35)) + ''/** Vendor City **/
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_state), 2)) + '' /** Vendor State **/
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_zip), 18)) + '' /** Vendor Zip **/	

						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_country), 18)) + '' /** Vendor Zip **/	

						SET @ls_output =  @ls_output + '|' + '' /**  Divert Code - optional **/

						--SELECT @is_export_file '@is_export_file H'

						SET @is_export_file = @ls_output
			
						INSERT INTO W_PMT_MGR_EXPORT
								   (BK_CODE
								   ,CHECK_RUN_ID
								   ,EXPORT_PATH
								   ,EXPORT_FILENAME
								   ,EXPORT_FILE
								   ,SUCCESS)
							 VALUES
								   (@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)		
			
						SET @cnt_p = @cnt_p + 1
					END
				END

				SET @ls_output = 'R' 
				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@ap_chk_nbr), 10)) + '' /** Check Nbr */
				
				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@ap_inv_vchr), 25)) + '' /** Invoice Nbr */
				SET @ls_output =  @ls_output + '|' +  LEFT((@ap_inv_date), 8) + '' /** Invoice Date **/

				/* PMT  AMOUNT */
				SET @ls_output =  @ls_output + '|'  /** Pmt Amt **/
			
				SET @str_amt = COALESCE(@ap_chk_amt,0)
				IF LEN(@str_amt) > 12
				BEGIN
					SET @is_log = 'The Pmt Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 12 characters in length.'
					SET @success = 0
					BREAK
				END				
				
				SET @ls_output = @ls_output + @str_amt + ''

				/* GROSS  AMOUNT */
				SET @inv_gross_amt = @ap_chk_amt + @ap_disc_amt /* Gross Amt */

				SET @ls_output =  @ls_output + '|' /** Gross Amt **/
			
				SET @str_amt = COALESCE(@inv_gross_amt,0)
				IF LEN(@str_amt) > 12
				BEGIN
					SELECT @str_amt '@str_amt'
					SET @is_log = 'The Gross Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 12 characters in length.'
					SET @success = 0
					BREAK
				END
				
				SET @ls_output = @ls_output + @str_amt + ''
				
				/* DISCOUNT  AMOUNT */
				SET @ls_output =  @ls_output + '|' /** Disc Amt **/	
			
				SET @str_amt = COALESCE(@ap_disc_amt,0)
				IF LEN(@str_amt) > 12
				BEGIN
					SET @is_log = 'The Discount Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 12 characters in length.'
					SET @success = 0
					BREAK
				END				
				
				SET @ls_output = @ls_output + @str_amt + ''

				--SET @ls_output =  @ls_output + '|' + LEFT((@payment_date), 8) + '' /** Pmt Date - Today **/

				SET @ls_output =  @ls_output + '|' + ''  /* Disc Pct 7 */
				SET @ls_output =  @ls_output + '|' + ''  /* Buyer Acct Nbr 30 */
				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@ap_desc ), 80)) + '' /** AP Desc - Comment **/
				SET @ls_output =  @ls_output + '|' + ''  /* Voucher Nbr 30 */
				SET @ls_output =  @ls_output + '|' + ''  /* PO Number 30 */
				SET @ls_output =  @ls_output + '|' + ''  /* Contract Nbr 30 */
				SET @ls_output =  @ls_output + '|' + ''  /* Tax Amt 10 */
				SET @ls_output =  @ls_output + '|' + ''  /* Tax Rate 10 */
			
				SET @is_export_file = @ls_output

				--SELECT @is_export_file '@is_export_file'
			
				INSERT INTO W_PMT_MGR_EXPORT
						   (BK_CODE
						   ,CHECK_RUN_ID
						   ,EXPORT_PATH
						   ,EXPORT_FILENAME
						   ,EXPORT_FILE
						   ,SUCCESS)
					 VALUES
						   (@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)		
			
				SET @cnt_r = @cnt_r + 1
				
				SET @recid = @recid + 1

				SELECT @ap_desc=AP_DESC, @pymt_mgr_email=PYMT_MGR_EMAIL, @vn_email=VN_EMAIL, @pay_to_code=PAY_TO_CODE, @vn_name=VN_PAY_TO_NAME, @ap_inv_vchr=AP_INV_VCHR, 
					@ap_inv_date=REPLACE(CONVERT(VARCHAR(10), AP_INV_DATE, 112), '/', ''), @payment_date=REPLACE(CONVERT(VARCHAR(10), GETDATE(), 112), '/', ''), 
					@ap_inv_amt=AP_INV_AMT,
					@ap_chk_nbr=AP_CHK_NBR, @ap_chk_amt=AP_CHK_AMT, @ap_disc_amt=AP_DISC_AMT, @vn_fax_number=VN_FAX_NUMBER, 
					@vn_acct_nbr=VN_ACCT_NBR,
					@vn_pay_to_address1=VN_PAY_TO_ADDRESS1, @vn_pay_to_address2=VN_PAY_TO_ADDRESS2,  @vn_pay_to_address3=VN_PAY_TO_ADDRESS3,
					@vn_pay_to_city=VN_PAY_TO_CITY, @vn_pay_to_county=VN_PAY_TO_COUNTY, @vn_pay_to_state=VN_PAY_TO_STATE, @vn_pay_to_zip=VN_PAY_TO_ZIP, @vn_pay_to_country=VN_PAY_TO_COUNTRY,
					@chk_amt=CHECK_AMT, @disc_amt=DISC_AMT,
					@chk_date=REPLACE(CONVERT(VARCHAR(10), CHECK_DATE, 112), '/', '')
				FROM @pmt_mgr_invoices
				WHERE [RECID] = @recid;

			END  /* LOOP */

			SET @ls_output =  'C' 

			SET @ls_output =  @ls_output + '|' /** Check Amt left **/
			
			SET @str_amt = @chk_amt_total

			IF LEN(@str_amt) > 10
			BEGIN
				SELECT @str_amt '@str_amt'
				SET @is_log = 'The Total Paymebnt Amount (' + @str_amt + ') exceeds 10 characters in length.'
				SET @success = 0
			END

			SET @ls_output = @ls_output + @str_amt + ''  /** Check Amt right **/

			SET @str_amt = @cnt_p

			SET @ls_output =  @ls_output + '|' + @str_amt 

			SET @str_amt = @cnt_r

			SET @ls_output =  @ls_output + '|' + @str_amt  

			SET @is_export_file = @ls_output
			
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


GRANT EXECUTE ON [advsp_pmt_mgr_paymodex] TO PUBLIC AS dbo