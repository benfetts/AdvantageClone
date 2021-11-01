
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_pmt_mgr_wf]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_pmt_mgr_wf]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[advsp_pmt_mgr_wf] 
@is_chk_run varchar(50), @is_bank varchar(50)


AS

/*
PJH 03/25/19 - 377-1-544 - Changes to custom Payment Manager - Wells Fargo FF
SYNOPSIS: Changes to custom Payment Manager - Wells Fargo FF
1) Position 79 in the file layout under the Payment section is not in position (pipe section) 79 it is off - Done
2) Can we Vendor Name to Position 87 in the payment section - Done
3) Can we hard code position 85 with PDF - Done
4) Can we change position 81 which is the ach id to allow for blanks?  Wells Fargo is going to auto populate this for them on their end - Done
5) Can we hard code position 86 with EMAIL? - Done
6) Can we for payment type of DAC to populate position 89 with the Payment Manager email address? - Done
7) Can we have vendors who will be receiving a check not require the vendor's ach/bank account information in the vendor account field in vendor maintenance?  
   Can we just populate the CHK in that field to designate?  They have 3000 vendors and this will make it a lot easier. 
   ("RoutingNumber|AccountNumber|PaymentMethod (DA)" or "PaymentMethod (CH) only")
PJH 04/05/19 - 377-1-544 - Changes to custom Payment Manager - Wells Fargo FF
1) Can we put a “U” flat needs to be passed in the file. It will need to be in position 97 after the e-mail information 
2) Strategic America’s address - (P record, fields 12—18)
PJH 04/15/19 - 377-1-544 - Originating Party Address is off one position according to Wells Fargo. The file had the address begin on position 11 when it should have been in position 12.
*/

DECLARE @as_chk_run varchar(50), @as_bank varchar(50)
DECLARE @file_control_nbr varchar(15), @min_rec_id int
DECLARE @is_pm_type varchar(50), @is_pm_acct varchar(50), @is_bank_desc varchar(50), @is_pm_id varchar(10)
DECLARE @is_pm_word varchar(50), @il_bk_routing_nbr varchar(20), @is_ach_company_id varchar(10), @is_ach_company_name varchar(30)
DECLARE @is_pm_dir varchar(100), @is_pm_ftp varchar(254), @is_export_file varchar(max), @il_chk_template_id varchar(20)
DECLARE @is_log varchar(max), @is_output_file varchar(100), @success int, @cnt int
/* Agency Vars */
DECLARE @is_currency_code varchar(50), @is_agy_name varchar(50), @is_agy_reply_to varchar(50)
DECLARE @is_agy_addr varchar(50), @is_agy_addr2 varchar(50), @is_agy_city varchar(50), @is_agy_state varchar(50)
DECLARE @is_agy_zip varchar(10), @is_agy_phone varchar(15)
DECLARE @il_asp int, @is_import_path varchar(254), @temp varchar(100)

DECLARE @recid int, @rec_cnt int, @payment_cnt int

DECLARE @ib_chk_template_id bit, @is_tmp varchar(max)

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
	[VN_CODE] [varchar](6) NULL,
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
	[VN_ACCT_NBR] [varchar](50) NULL,
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
	[VN_TAX_ID] [varchar](20) NULL,
	/*  FLAG   */
	[SELECTED_FLAG] [smallint] NULL)

DECLARE @vn_acct_data TABLE (
	/*  AP_HEADER   */
	[RECID] INT identity(1,1),
	[VN_ACCT_ITEM] varchar(25))
	--[VN_ROUTING_NBR] varchar(20) NOT NULL, /* length 9 only */
	--[VN_ACCT_NBR] varchar(20) NOT NULL,
	--[VN_PMT_TYPE] varchar(5) NOT NULL) /* length 3 only */

BEGIN TRY

	/* PJH 07/26/18 - changed to use Chk Nbr */

	BEGIN TRAN

	/* Clear any previous export data for this bank */
	DELETE FROM W_PMT_MGR_EXPORT
	WHERE 	BK_CODE = @as_bank --CHECK_RUN_ID = @as_chk_run AND BK_CODE = @as_bank

	/* Set Defaults */
	SET @success = 1
	SET @is_export_file = ''
	SET @is_log = ''
	SET @cnt = 0
	SET @ib_chk_template_id = 0

	/* Get Bank Data */
	SELECT @is_pm_type=COALESCE(PYMT_MGR_TYPE, ''),	@is_pm_acct=COALESCE(BK_ACCOUNT_NO, ''), @is_bank_desc=COALESCE(BK_DESCRIPTION, ''), @is_pm_id=COALESCE(PYMT_MGR_ID, ''), 
			 @is_pm_word=COALESCE(PYMT_MGR_WORD, ''),	@il_bk_routing_nbr=COALESCE(BK_ROUTING_NBR, ''), @is_ach_company_id=COALESCE(ACH_COMPANY_ID, ''), 
			 @is_pm_dir=COALESCE(PYMT_MGR_DIR, ''), @is_pm_ftp=COALESCE(PYMT_MGR_FTP, ''), @is_ach_company_name = ACH_COMPANY_NAME,
			 @il_chk_template_id = CHK_TEMPLATE_ID
	FROM   BANK
	WHERE  BK_CODE = @as_bank;

	--SELECT @is_pm_dir '@is_pm_dir' , @is_pm_type '@is_pm_type' , @is_pm_acct '@is_pm_acct' , @is_pm_id '@is_pm_id' , @is_pm_ftp '@is_pm_ftp', @il_bk_routing_nbr '@il_bk_routing_nbr', @il_chk_template_id '@il_chk_template_id'
	
	SET @il_bk_routing_nbr = @is_pm_word /* Use Origination ID */
	
	EXEC @il_bk_routing_nbr = advfn_clear_special_characters  @il_bk_routing_nbr, '0-9' 

	SET @il_bk_routing_nbr = COALESCE(@il_bk_routing_nbr, '')
	
	IF LEN(@il_bk_routing_nbr) NOT IN (9,10,11) BEGIN
			SET @is_log = @is_log + 'The Originating Bank Routing Number must be 9 to 11 digits. (' + @il_bk_routing_nbr + ').' + CHAR(13)
			SET @success = 0
	END			
	
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
	/********************************************/

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

	IF LEN(@is_pm_acct) > 20 
	BEGIN
		SET @is_log = @is_log + 'Bank Account Number exceeds 20 digits.  ' + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF LEN(@is_pm_word) > 20 
	BEGIN
		SET @is_log = @is_log + 'The Payment Manager "Word" on the bank record exceeds the maximum length of 20. Please correct and try again'  + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	IF (@is_pm_dir='') 
	BEGIN
		SET @is_log = @is_log + 'The File Output Directory in Bank Maintenance does not exist.'  + CHAR(13)
		SET @success = 0
		--RETURN FALSE
	END

	SET @is_output_file = @is_pm_acct + '.' + @is_pm_id + '.WF.' + REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') +  '.' + REPLACE(CONVERT(VARCHAR(12), GETDATE(), 114), ':','') + '0'
	--SET @is_output_file = @is_pm_acct + '.' + @is_pm_id + '.' + REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') +  '.' + REPLACE(CONVERT(VARCHAR(12), GETDATE(), 108), ':','') + '.csv'

	--SELECT '01: ' + @is_pm_dir + ' | ' + @is_pm_type + ' | ' + @is_pm_acct + ' | ' + @is_pm_id + ' | ' + @is_pm_ftp + ' | ' + @is_output_file

	/* Get Agency Data */
	SELECT @is_currency_code=HOME_CRNCY, @is_agy_name=NAME, @is_agy_reply_to=POP3_REPLY_TO,
		@is_agy_addr=COALESCE(RTRIM(ADDRESS1),''), @is_agy_addr2=	COALESCE(RTRIM(ADDRESS2),''), 
		@is_agy_city=COALESCE(RTRIM(CITY),''), @is_agy_state=COALESCE(RTRIM(STATE),''), @is_agy_zip=COALESCE(RTRIM(ZIP),''), @is_agy_phone=Replace(Replace(Replace(Replace(Replace(PHONE,'(',''),' ',''),'.',''),')',''),'-','')
	FROM   AGENCY;

	--SELECT @is_currency_code=HOME_CRNCY, @is_agy_name=NAME, @is_agy_reply_to=POP3_REPLY_TO,
	--	@is_agy_addr=COALESCE(RTRIM(ADDRESS1),'') + ', ', @is_agy_addr2=	COALESCE(RTRIM(ADDRESS2),'') + ', ', 
	--	@is_agy_city=COALESCE(RTRIM(CITY),'') + ', ', @is_agy_state=COALESCE(RTRIM(STATE),'') + ', ', @is_agy_zip=COALESCE(RTRIM(ZIP),''), @is_agy_phone=Replace(Replace(Replace(Replace(Replace(PHONE,'(',''),' ',''),'.',''),')',''),'-','')
	--FROM   AGENCY;

	--IF @is_agy_addr2 > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_addr2
	--IF @is_agy_city > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_city
	--IF @is_agy_state > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_state
	--IF @is_agy_zip > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_zip

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
				   ,VN_CODE 
				   ,VN_ACCT_NBR
				   ,VN_PAY_TO_NAME
				   ,VN_PAY_TO_ADDRESS1,	 VN_PAY_TO_ADDRESS2, VN_PAY_TO_ADDRESS3, VN_PAY_TO_CITY
				   ,VN_PAY_TO_COUNTY,	 VN_PAY_TO_STATE, VN_PAY_TO_ZIP, VN_PAY_TO_COUNTRY           
				   ,VN_FAX_NUMBER, VN_EMAIL, [VN_TAX_ID]
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
					 COALESCE(CHECK_REGISTER.DISC_AMT, 0.00) DSIC_AMT,   
					 COALESCE(CHECK_REGISTER.POST_PERIOD, ''),
					 CHECK_REGISTER.CHECK_RUN_ID,
					 CHECK_REGISTER.BK_CODE,
					 CHECK_REGISTER.CHECK_NBR, 
					 COALESCE(VENDOR.PYMT_MGR_EMAIL, ''),   --VN_PAY_TO_PHONE	VN_PAY_TO_EXT	VN_PAY_TO_FAX_NBR	VN_PAY_TO_FAX_EXT, VN_PAY_TO_ADDRESS3, VN_PAY_TO_EMAIL
					 VENDOR.VN_CODE,
					 VENDOR.VN_ACCT_NBR,
						 --COALESCE(VENDOR.VN_NAME, ''),   
						 --COALESCE(VENDOR.VN_ADDRESS1, '') VN_ADDRESS1, COALESCE(VENDOR.VN_ADDRESS2, '') VN_ADDRESS2, COALESCE(VENDOR.VN_CITY, '') VN_CITY,
						 --COALESCE(VENDOR.VN_COUNTY, '') VN_COUNTY, COALESCE(VENDOR.VN_STATE, '') VN_STATE, COALESCE(VENDOR.VN_ZIP, '') VN_ZIP, COALESCE(VENDOR.VN_COUNTRY, '') VN_COUNTRY,
						 --COALESCE(VENDOR.VN_FAX_NUMBER, '') VN_FAX_NUMBER, COALESCE(VENDOR.VN_EMAIL, '') VN_EMAIL,
					 COALESCE(VENDOR.VN_PAY_TO_NAME, '') VN_NAME,   
					 COALESCE(VENDOR.VN_PAY_TO_ADDRESS1, '') VN_ADDRESS1, COALESCE(VENDOR.VN_PAY_TO_ADDRESS2, '') VN_ADDRESS2, COALESCE(VENDOR.VN_PAY_TO_ADDRESS3, '') VN_ADDRESS3, COALESCE(VENDOR.VN_PAY_TO_CITY, '') VN_CITY,
					 COALESCE(VENDOR.VN_PAY_TO_COUNTY, '') VN_COUNTY, COALESCE(VENDOR.VN_PAY_TO_STATE, '') VN_STATE, COALESCE(VENDOR.VN_PAY_TO_ZIP, '') VN_ZIP, COALESCE(VENDOR.VN_PAY_TO_COUNTRY, '') VN_COUNTRY,
					 --COALESCE(VENDOR.VN_PAY_TO_FAX_NBR, '') VN_FAX_NUMBER, COALESCE(VENDOR.VN_PAY_TO_EMAIL, VENDOR.VN_EMAIL, '') VN_EMAIL,			 	 			 
					 COALESCE(VENDOR.VN_PAY_TO_PHONE, '') VN_PAY_TO_PHONE, COALESCE(VENDOR.VN_PAY_TO_EMAIL, VENDOR.VN_EMAIL, '') VN_EMAIL, [VN_TAX_ID],	 			 
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
				ORDER BY AP_PMT_HIST.AP_CHK_NBR;

		SET @rec_cnt = @@ROWCOUNT

		--SELECT 'Pmt Mgr Invoices' '*', * FROM @pmt_mgr_invoices;
	END

	DECLARE @ls_hdr varchar(max), @ls_output varchar(max)
	DECLARE @ap_desc varchar(50), @pymt_mgr_email varchar(50), @vn_email varchar(50), @vn_fax_number varchar(50)
	DECLARE @vn_pay_to_address1 varchar(30), @vn_pay_to_address2 varchar(30), @vn_pay_to_address3 varchar(30), @vn_pay_to_city varchar(20)
	DECLARE @vn_pay_to_county varchar(30), @vn_pay_to_state varchar(2), @vn_pay_to_zip varchar(12), @vn_pay_to_country varchar(3)
	DECLARE @vn_tax_id varchar(20)

	DECLARE @vn_code varchar(50), @pay_to_code varchar(50), @vn_name varchar(50), @ap_inv_vchr varchar(50), @ap_inv_date varchar(30), @payment_date varchar(30) 
	DECLARE @ap_chk_nbr varchar(50), @chk_amt decimal(14,2), @disc_amt decimal(14,2), @gross_amt decimal(14,2), @chk_amt_total decimal(18,2)
	DECLARE @chk_date varchar(30)

	DECLARE @ap_chk_amt decimal(14,2), @ap_disc_amt decimal(14,2), @inv_gross_amt decimal(14,2)
	DECLARE @amt_sign varchar(1), @str_amt varchar(20)
	DECLARE @vn_acct_nbr varchar(50), @vn_routing_nbr varchar(9), @vn_payment_method varchar(3)

	DECLARE @pmt_type_chk_amt varchar(20)

	DECLARE @prev_ap_chk_nbr varchar(50), @elements int

	SET @prev_ap_chk_nbr = 'NA'

	SET @file_control_nbr = LEFT(REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') +  REPLACE(CONVERT(VARCHAR(12), GETDATE(), 114), ':',''), 15)

	IF @success = 1 AND @rec_cnt > 0
		BEGIN

			SET @recid = 1

			SET @chk_amt_total = 0

			--DECLARE db_cursor CURSOR FOR  
			SELECT @ap_desc=AP_DESC, @pymt_mgr_email=PYMT_MGR_EMAIL, @vn_email=VN_EMAIL, @pay_to_code=PAY_TO_CODE, @vn_name=VN_PAY_TO_NAME, @ap_inv_vchr=AP_INV_VCHR, 
				@ap_inv_date=CONVERT(varchar(10), AP_INV_DATE, 120), @payment_date=CONVERT(varchar(10), GETDATE(), 120), 
				@ap_chk_nbr=AP_CHK_NBR, @ap_chk_amt=AP_CHK_AMT, @ap_disc_amt=AP_DISC_AMT, @vn_fax_number=VN_FAX_NUMBER, 
				@chk_amt=CHECK_AMT, @disc_amt=DISC_AMT, @gross_amt=CHECK_AMT+DISC_AMT,
				@vn_pay_to_address1=VN_PAY_TO_ADDRESS1, @vn_pay_to_address2=VN_PAY_TO_ADDRESS2,  @vn_pay_to_address3=VN_PAY_TO_ADDRESS3,
				@vn_pay_to_city=VN_PAY_TO_CITY, @vn_pay_to_county=VN_PAY_TO_COUNTY, @vn_pay_to_state=VN_PAY_TO_STATE, @vn_pay_to_zip=VN_PAY_TO_ZIP, @vn_pay_to_country=VN_PAY_TO_COUNTRY,
				@vn_tax_id=VN_TAX_ID, @vn_acct_nbr=COALESCE(VN_ACCT_NBR,''), @vn_code=VN_CODE,
				@chk_date=CONVERT(varchar(10), AP_CHK_DATE, 120)
			FROM @pmt_mgr_invoices
			WHERE [RECID] = @recid;

			IF COALESCE(@pymt_mgr_email, '') = ''
				SET @pymt_mgr_email = COALESCE(@vn_email, '')

			IF @vn_pay_to_country IS NULL SET @vn_pay_to_country = 'US'

			-- Write Header Record
			SET @ls_hdr = 'H' /* Record ID */
			SET @ls_hdr = @ls_hdr + '|' + @file_control_nbr /* File Ctrl Nbr YYYYMMDDHHMMSSS */
			SET @ls_hdr = @ls_hdr + '|' + @payment_date /* File Date */
			SET @ls_hdr = @ls_hdr + '|' + 'HH' /* End of Record */			
			
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
			
				--SET @ls_hdr = UPPER(LEFT((@is_pm_acct + SPACE(0)), 5)) /* Account Code */
				--SET @ls_hdr = @ls_hdr + '|' + UPPER(LEFT((@is_pm_id + SPACE(0)), 10)) /* Customer ID */
				--SET @ls_hdr = @ls_hdr + '|' + UPPER(LEFT((@is_pm_word + SPACE(0)), 20)) /* Word */	

				IF @prev_ap_chk_nbr <> @ap_chk_nbr
				BEGIN /* Payment Data */

					/* Vendor Routing Nbr, Account Nbr, Payment Method */
					SELECT @vn_routing_nbr = ''
					SELECT @vn_payment_method = ''

					BEGIN
						DELETE @vn_acct_data

						SET @vn_name = COALESCE(@vn_name, '')
						SET @vn_acct_nbr = COALESCE(@vn_acct_nbr, '')

						SET @elements = 0
						IF @vn_acct_nbr > '' BEGIN
							INSERT INTO @vn_acct_data
							SELECT * FROM dbo.udf_split_list(@vn_acct_nbr, '|')

							SET @elements = @@ROWCOUNT
						END

						IF @elements > 0
						BEGIN
							SELECT @min_rec_id = MIN(RECID) FROM @vn_acct_data 
							SELECT @vn_payment_method = VN_ACCT_ITEM FROM @vn_acct_data WHERE RECID = @min_rec_id AND (LEFT(VN_ACCT_ITEM, 2) = 'CH')
						END

						IF @elements < 3 AND COALESCE(@vn_payment_method, '') = '' /* Not CHK */
						BEGIN
							SET @is_log = @is_log + 'The Vendor Account Number format (' + @vn_acct_nbr + ') is not correct for vendor ' + @vn_name + '. The Account Number must be formated as "RoutingNumber|AccountNumber|PaymentMethod (DA)" or "PaymentMethod (CH) only".' + CHAR(13)
							SET @success = 0
						END						
					END 

					IF @elements = 3
					BEGIN

						SELECT @min_rec_id = MIN(RECID) FROM @vn_acct_data 
						SELECT @vn_routing_nbr = VN_ACCT_ITEM FROM @vn_acct_data WHERE RECID = @min_rec_id
						SELECT @vn_acct_nbr = VN_ACCT_ITEM FROM @vn_acct_data WHERE RECID = @min_rec_id + 1
						SELECT @vn_payment_method = VN_ACCT_ITEM FROM @vn_acct_data WHERE RECID = @min_rec_id + 2
						
						EXEC @vn_routing_nbr = advfn_clear_special_characters  @vn_routing_nbr, '0-9' 

						SET @vn_routing_nbr = COALESCE(@vn_routing_nbr, '')

						IF LEN(@vn_routing_nbr) NOT IN (9,10,11) BEGIN
								SET @is_log = @is_log + 'The Vendor Bank Routing Number must be 9 to 11 digits. (' + @vn_routing_nbr + ') is not valid for Vendor (' + @vn_name + ').' + CHAR(13)
								SET @success = 0
						END

						SET @vn_payment_method = COALESCE(@vn_payment_method, '')

						IF LEFT(@vn_payment_method, 2) = 'DA' SET @vn_payment_method = 'DAC'
						IF LEFT(@vn_payment_method, 2) = 'CH' SET @vn_payment_method = 'CHK'

						IF @vn_payment_method NOT IN ('CHK', 'DAC') BEGIN
								SET @is_log = @is_log + 'The Vendor Payment Type must be "CHK" or "DAC". Payment Type ' + @vn_payment_method + ' is not valid.' + CHAR(13)
								SET @success = 0
						END

						EXEC @vn_acct_nbr = advfn_clear_special_characters  @vn_acct_nbr, '0-9' 

						SET @vn_acct_nbr = COALESCE(@vn_acct_nbr, '')

						IF LEN(@vn_acct_nbr) > 17 BEGIN
								SET @is_log = @is_log + 'The Vendor Bank Account Number must be 17 digits or less. (' + @vn_acct_nbr + ') is not valid for Vendor (' + @vn_name + ').' + CHAR(13)
								SET @success = 0
						END
					END
				
					SET @ls_output = 'P' /* Record ID */		
			
					SET @ls_output =  @ls_output + '|'  + UPPER(LEFT((@vn_payment_method), 3)) + ''/* Pmt Method */

					SET @ls_output =  @ls_output + '|' + 'C' /* Credit only */
			
					SET @ls_output =  @ls_output + '|' + LEFT(LEFT(@file_control_nbr, 15 - LEN(@ap_chk_nbr)) + @ap_chk_nbr, 15) /* File Ctrl Nbr YYYYMMDDHHMMSSS + Check Number */

					SET @ls_output =  @ls_output + '|' + @chk_date /* Check Date/Effective Date */ /*PJH 06/26/19 changed from @ap_inv_date */

					SET @vn_payment_method = COALESCE(@vn_payment_method, '')

					IF @vn_payment_method IN ('CHK') BEGIN 
						SET @pmt_type_chk_amt = CAST(@chk_amt as varchar(20)) --15)
						IF LEN(@pmt_type_chk_amt) > 15 BEGIN
							SET @is_log = @is_log + 'The Vendor Payment Amount is greater than 15 digits for Payment Type ' + @vn_payment_method + '.' + CHAR(13)
							SET @success = 0
						END
					END
					ELSE BEGIN  
						SET @pmt_type_chk_amt = CAST(@chk_amt as varchar(20)) --11)
						IF LEN(@pmt_type_chk_amt) > 11 BEGIN
							SET @is_log = @is_log + 'The Vendor Payment Amount is greater than 11 digits for Payment Type ' + @vn_payment_method + '.' + CHAR(13)
							SET @success = 0
						END
					END

					SET @ls_output =  @ls_output + '|' + @pmt_type_chk_amt /* Check Amount */

					SET @ls_output =  @ls_output + '|' + 'USD' /* Currency */											/* 7 */

					SET @ls_output =  @ls_output + '|'  /* FX Contract Number -  Foreign exchange contract number for currency conversion.  */  /* 8 */
				
					EXEC @is_ach_company_name = advfn_clear_special_characters  @is_ach_company_name, 'A-Za-z0-9 @#$:.,'

					SET @is_ach_company_name = COALESCE(@is_ach_company_name, '')

					SET @ls_output =  @ls_output + '|' + LEFT(@is_ach_company_name, 30) /* Company Name */				/* 9 */
					SET @ls_output =  @ls_output + '|' /* Co Name 2 -Addl Name - blank */								/* 10 */
					SET @ls_output =  @ls_output + '|' /* Originating ID - Optional - blank */							/* 11 */
					SET @ls_output =  @ls_output + '|' + @is_agy_addr /* Originating Addr 1 - Optional - blank */		/* 12 */
					SET @ls_output =  @ls_output + '|' + @is_agy_addr2 /* Originating Addr 2 - Optional - blank */
					SET @ls_output =  @ls_output + '|' + @is_agy_city /* Originating City - Optional - blank */
					SET @ls_output =  @ls_output + '|' + @is_agy_state /* Originating St - Optional - blank */
					SET @ls_output =  @ls_output + '|' + @is_agy_zip /* Originating Zip - Optional - blank */
					SET @ls_output =  @ls_output + '|US' /* Originating Country Code - Optional - blank */
					SET @ls_output =  @ls_output + '|UNITED STATES' /* Originating Country Name - Optional - blank */

					SET @ls_output =  @ls_output + '|' /* Originating Bank Name - Optional - blank */					/* 19 */
					SET @ls_output =  @ls_output + '|' /* Originating Bank Addr 1 - Optional - blank */
					SET @ls_output =  @ls_output + '|' /* Originating Bank City - Optional - blank */
					SET @ls_output =  @ls_output + '|' /* Originating Bank St - Optional - blank */
					SET @ls_output =  @ls_output + '|' /* Originating Bank Zip - Optional - blank */
					SET @ls_output =  @ls_output + '|' /* Originating Bank Country Code - Optional - blank */

					SET @ls_output =  @ls_output + '|' + 'D' /* Originating Acct Type */								/* 25 */

					SET @ls_output =  @ls_output + '|' + LEFT(@is_pm_acct, 34) /* Originating Acct Num - Len max 20 in Advantage */ 

					SET @ls_output =  @ls_output + '|' + 'USD' /* Originating Acct Currency */

					SET @ls_output =  @ls_output + '|' + 'ABA' /* Originating Bank ID Type */							/* 28 */
					

					/*Bank Routing validation is above */
					SET @ls_output =  @ls_output + '|' + LEFT(@il_bk_routing_nbr, 11) /* Originating Bank Routing Number */
					
					EXEC @vn_name = advfn_clear_special_characters  @vn_name, 'A-Za-z0-9 @#$:.,'

					SET @vn_name = COALESCE(@vn_name, '')

					SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_name), 60)) + '' /* Recieving Party Name Vendor Name */
					SET @ls_output =  @ls_output + '|' /* Recieving Party Name Addl Name */

					SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@pay_to_code), 15)) + '' /* Recieving Party Name Vendor Code */  /* 32 */
				
					--SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@pymt_mgr_email), 50)) + ''/* Vendor Email */
					--SET @ls_output =  @ls_output + '|' /* Email 2 */

					IF @vn_payment_method IN ('CHK')  
					BEGIN
						IF @vn_pay_to_address1 IS NULL SET @vn_pay_to_address1 = ''
						IF @vn_pay_to_address2 IS NULL SET @vn_pay_to_address2 = ''
						IF @vn_pay_to_address3 IS NULL SET @vn_pay_to_address3 = ''
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
									SET @is_log = @is_log + 'Missing Address for Vendor Pay To Code (' + @pay_to_code + '). The Pay To Vendor may be set up with a Pay To Vendor of its own. This will not work for exporting payments.'  + CHAR(13)
									SET @success = 0
									--BREAK
								END							
					END
					
					EXEC @vn_pay_to_address1 = advfn_clear_special_characters  @vn_pay_to_address1, 'A-Za-z0-9 @#$:.,'
					EXEC @vn_pay_to_address2 = advfn_clear_special_characters  @vn_pay_to_address2, 'A-Za-z0-9 @#$:.,'
					EXEC @vn_pay_to_city = advfn_clear_special_characters  @vn_pay_to_city, 'A-Za-z0-9 @#$:.,'
					EXEC @vn_pay_to_state = advfn_clear_special_characters  @vn_pay_to_state, 'A-Za-z0-9 @#$:.,'

					SET @vn_pay_to_address1 = COALESCE(@vn_pay_to_address1, '')
					SET @vn_pay_to_address2 = COALESCE(@vn_pay_to_address2, '')
					SET @vn_pay_to_city = COALESCE(@vn_pay_to_city, '')
					SET @vn_pay_to_state = COALESCE(@vn_pay_to_state, '')
			
					--IF @vn_payment_method IN ('CHK')  
					BEGIN
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_address1), 55)) + '' /* Vendor Addr 1 */ /* 33 */
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_address2), 55)) + '' /* Vendor Addr 2 */

						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_city), 30)) + ''/* Vendor City */
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_state), 3)) + '' /* Vendor State */
						
						EXEC @vn_pay_to_zip = advfn_clear_special_characters  @vn_pay_to_zip, '0-9'
						
						SET @vn_pay_to_zip = COALESCE(@vn_pay_to_zip, '')
						
						IF LEN(@vn_pay_to_zip) NOT IN (5,9) BEGIN
								SET @is_log = @is_log + 'The Receiving Party Zip Code must be 5 or 9 digits (' + @vn_pay_to_zip + ') for Vendor (' + @pay_to_code + ').' + CHAR(13)
								SET @success = 0
						END							
						
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_zip), 9)) + '' /* Vendor Zip */		
						SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_pay_to_country), 2)) /* Country Code - if foreign addr */
						SET @ls_output =  @ls_output + '|'  /* Country Name  - if foreign addr */
					END				
				
					BEGIN
						SET @ls_output =  @ls_output + '|' /* Receiving Bank Name */ /* 40 */
						SET @ls_output =  @ls_output + '|' + '' /* Addr  */		
						SET @ls_output =  @ls_output + '|' + '' /* City */	
						SET @ls_output =  @ls_output + '|' + '' /* State*/
						SET @ls_output =  @ls_output + '|' + '' /* Zip */	
						SET @ls_output =  @ls_output + '|' + '' /* Country Code */																		
					END

					SET @ls_output =  @ls_output + '|' + 'D' /* Receiving Acct Type */

					IF @vn_payment_method IN ('DAC') BEGIN 
						SET @ls_output =  @ls_output + '|' + LEFT(@vn_acct_nbr, 17) /* Receiving Acct Num */
					END
					ELSE BEGIN 
						--SET @ls_output =  @ls_output + '|' /* CHK - Receiving Acct Num */
						SET @ls_output =  @ls_output + '|' + LEFT(@vn_acct_nbr, 17) /* Receiving Acct Num */
					END

					SET @ls_output =  @ls_output + '|' + 'USD' /* Receiving Acct Currency */  /* 48 */

					SET @ls_output =  @ls_output + '|' + 'ABA' /* Receiving Bank ID Type */
					
					SET @ls_output =  @ls_output + '|' + LEFT(@vn_routing_nbr, 11) /* Vendor Bank Routing Number */

					SET @ls_output =  @ls_output + '|' /* Receiving Bank ID 2 - blank */

					BEGIN
						SET @ls_output =  @ls_output + '|' /* Intermediary Bank Name - blank */  /* 52 */
						SET @ls_output =  @ls_output + '|' + '' /* Addr  */		
						SET @ls_output =  @ls_output + '|' + '' /* City */	
						SET @ls_output =  @ls_output + '|' + '' /* State*/
						SET @ls_output =  @ls_output + '|' + '' /* Zip */	
						SET @ls_output =  @ls_output + '|' + '' /* Bank Country Code */	
						SET @ls_output =  @ls_output + '|' + '' /* Bank ID type */					
						SET @ls_output =  @ls_output + '|' + '' /* Bank ID */			
					END

					BEGIN
						SET @ls_output =  @ls_output + '|' /* Second Intermediary Bank Name - blank */  /* 60 */
						SET @ls_output =  @ls_output + '|' + '' /* Addr  */		
						SET @ls_output =  @ls_output + '|' + '' /* City */	
						SET @ls_output =  @ls_output + '|' + '' /* State*/
						SET @ls_output =  @ls_output + '|' + '' /* Zip */	
						SET @ls_output =  @ls_output + '|' + '' /* Bank Country Code */	
						SET @ls_output =  @ls_output + '|' + '' /* Bank ID type */			
						SET @ls_output =  @ls_output + '|' + '' /* Bank ID */			
					END

					BEGIN
						SET @ls_output =  @ls_output + '|' /* Ordering Party Name - blank */  /* 68 */
						SET @ls_output =  @ls_output + '|' /* Ordering Party ID - blank */
						SET @ls_output =  @ls_output + '|' + '' /* Addr  */		
						SET @ls_output =  @ls_output + '|' + '' /* Addr  */	
						SET @ls_output =  @ls_output + '|' + '' /* City */	
						SET @ls_output =  @ls_output + '|' + '' /* State*/
						SET @ls_output =  @ls_output + '|' + '' /* Zip */	
						SET @ls_output =  @ls_output + '|' + '' /* Country Code */	
						SET @ls_output =  @ls_output + '|' + '' /* Country Name */	
					END

					SET @ls_output =  @ls_output + '|' + '' /* Orig Party Chg Desc - blank */  /* 77 */
					SET @ls_output =  @ls_output + '|' + '' /* Bank to Bank Info - blank */	

					IF @vn_payment_method IN ('DAC') BEGIN 
						SET @ls_output =  @ls_output + '|' + 'CCD' /* ACH Format Code - (CCD Corporate Credit or Debit) or (PPD Pre-Authorized Payment or Disbursement) */	
					END
					ELSE BEGIN /* CHK */
						SET @ls_output =  @ls_output + '|' + '000' /* ACH Format Code - (000 Standard mail) or (001 Overnight to payee ) */	
					END

					SET @ls_output =  @ls_output + '|' + '' /*  ACH international type code  - blank */	
					
					/* PJH 03/25/19 - Will be supplied by bank during processing */
					--IF LEN(@is_ach_company_id) NOT IN (10) BEGIN
					--		SET @is_log = @is_log + 'The ACH Company ID must be 10 digits. (' + @is_ach_company_id + ').' + CHAR(13)
					--		SET @success = 0
					--END	
					
					SET @is_ach_company_id = COALESCE(@is_ach_company_id , '')
					
					SET @ls_output =  @ls_output + '|' + LEFT(@is_ach_company_id, 10) /* ACH Company ID */
					
					SET @ls_output =  @ls_output + '|' + LEFT(@ap_chk_nbr, 15) /* Check Number */
					
					IF @vn_payment_method IN ('CHK')
						IF @il_chk_template_id IS NULL AND @ib_chk_template_id = 0 BEGIN
								SET @is_log = @is_log + 'Missing Bank Check Template ID.' + CHAR(13)
								SET @success = 0
								SET @ib_chk_template_id = 1
						END					

					IF @vn_payment_method IN ('DAC') BEGIN 
						SET @ls_output =  @ls_output + '|' /* Doc Template Num */	
					END
					ELSE BEGIN /* CHK */
						SET @ls_output =  @ls_output + '|' + LEFT(CAST(@il_chk_template_id AS varchar (20)), 10) /* Doc Template Num */	
					END					

					SET @ls_output =  @ls_output + '|' + '' /*  EDD Biller  - blank */	/* 84 */
					SET @ls_output =  @ls_output + '|' + 'PDF' /*  File Format  - blank */	
					SET @ls_output =  @ls_output + '|' + 'EMAIL' /*  Delivery Type  - blank */	
					SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@vn_name), 60)) + '' /* Del Name */
					SET @ls_output =  @ls_output + '|' + '' /*  Del Fax  - blank */	
					IF @vn_payment_method IN ('DAC') BEGIN 
						IF COALESCE(@pymt_mgr_email, '') = '' BEGIN  --@pay_to_code
								SET @is_log = @is_log + 'There must be a Vendor Email or Payment Manager Email address for Vendor (' + @pymt_mgr_email + ') DAC payments.' + CHAR(13)
								SET @success = 0
						END							
						SET @ls_output =  @ls_output + '|' + COALESCE(@pymt_mgr_email, '') /*  Del Email  - blank */  /* 89 */
					END
					ELSE BEGIN
						SET @ls_output =  @ls_output + '|' + '' /*  Del Email  - blank */  /* 89 */
					END
					SET @ls_output =  @ls_output + '|' + '' /*  Del User ID  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Del Company ID  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Secure Type  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Secure Question  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Secure Password  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Secure Question  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Secure Password  - blank */	
					SET @ls_output =  @ls_output + '|' + 'U' /*  EDD Handling Code  - blank */	/* 97 */
					SET @ls_output =  @ls_output + '|' + '' /*  CEO Template ID  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Batch ID  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Op ID  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  CEO Company ID  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  Reserved  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /*  PDP Handling Code  - blank */	
					SET @ls_output =  @ls_output + '|' + '' /* Addr  */		
					SET @ls_output =  @ls_output + '|' + '' /* Addr  */	
					SET @ls_output =  @ls_output + '|' + '' /* City */	
					SET @ls_output =  @ls_output + '|' + '' /* State*/
					SET @ls_output =  @ls_output + '|' + '' /* Zip */	
					SET @ls_output =  @ls_output + '|' + '' /* Country */	
					SET @ls_output =  @ls_output + '|' + '' /*  FX Type  - blank */	

					SET @is_export_file = @ls_output

					IF @success = 1
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

					SET @chk_amt_total = @chk_amt_total + ABS(@chk_amt)

				END /* Payment Data ====================================== */


				SET @prev_ap_chk_nbr = @ap_chk_nbr /* Only do Payment Data once per Check Number */

				SET @ls_output = 'I' /* Record ID */
				
				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@ap_inv_vchr), 15)) + '' /* Invoice Nbr */
				SET @ls_output =  @ls_output + '|' + @ap_inv_date /* Invoice Date */

				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@ap_desc ), 80)) + '' /* AP Desc */
								
				SET @str_amt = @ap_chk_amt
				IF LEN(@str_amt) > 15
				BEGIN
					SET @is_log = @is_log + 'The Net Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 15 characters in length.'
					SET @success = 0
				END				
				
				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@str_amt), 15)) + '' /* Net */

				SET @inv_gross_amt = @ap_chk_amt + @ap_disc_amt /* Gross Amt */
							
				SET @str_amt = @inv_gross_amt

				IF LEN(@str_amt) > 15
				BEGIN
					SELECT @str_amt '@str_amt'
					SET @is_log = @is_log + 'The Gross Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 15 characters in length.'
					SET @success = 0
				END
				
				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@str_amt), 15)) + '' /* Gross */
				
				SET @str_amt = @ap_disc_amt
				IF LEN(@str_amt) > 15
				BEGIN
					SET @is_log = @is_log + 'The Discount Amount (' + @str_amt + ') for Vendor (' + @vn_name + ') exceeds 15 characters in length.'
					SET @success = 0
				END				
				
				SET @ls_output =  @ls_output + '|' + UPPER(LEFT((@str_amt), 15)) + '' /*Discount*/
		
				SET @ls_output =  @ls_output + '|' + '' /* PO - blank */
				SET @ls_output =  @ls_output + '|' + '' /* Reserved - blank */
				SET @ls_output =  @ls_output + '|' + 'IV' /* Invoice Type */
				SET @ls_output =  @ls_output + '|' + 'II' /* End of record indicator */

				SET @is_export_file = @ls_output
			
				IF @success = 1
				INSERT INTO W_PMT_MGR_EXPORT
						   (BK_CODE
						   ,CHECK_RUN_ID
						   ,EXPORT_PATH
						   ,EXPORT_FILENAME
						   ,EXPORT_FILE
						   ,SUCCESS)
					 VALUES
						   (@as_bank, @as_chk_run, @is_pm_dir, @is_output_file, @is_export_file, @success)		
			
				SET @recid = @recid + 1
			
				SELECT @ap_desc=AP_DESC, @pymt_mgr_email=PYMT_MGR_EMAIL, @vn_email=VN_EMAIL, @pay_to_code=PAY_TO_CODE, @vn_name=VN_PAY_TO_NAME, @ap_inv_vchr=AP_INV_VCHR, 
					@ap_inv_date=CONVERT(varchar(10), AP_INV_DATE, 120), @payment_date=CONVERT(varchar(10), GETDATE(), 120), 
					@ap_chk_nbr=AP_CHK_NBR, @ap_chk_amt=AP_CHK_AMT, @ap_disc_amt=AP_DISC_AMT, @vn_fax_number=VN_FAX_NUMBER, 
					@chk_amt=CHECK_AMT, @disc_amt=DISC_AMT, @gross_amt=CHECK_AMT+DISC_AMT,
					@vn_pay_to_address1=VN_PAY_TO_ADDRESS1, @vn_pay_to_address2=VN_PAY_TO_ADDRESS2,  @vn_pay_to_address3=VN_PAY_TO_ADDRESS3,
					@vn_pay_to_city=VN_PAY_TO_CITY, @vn_pay_to_county=VN_PAY_TO_COUNTY, @vn_pay_to_state=VN_PAY_TO_STATE, @vn_pay_to_zip=VN_PAY_TO_ZIP, @vn_pay_to_country=VN_PAY_TO_COUNTRY,
					@vn_tax_id=VN_TAX_ID, @vn_acct_nbr=VN_ACCT_NBR
				FROM @pmt_mgr_invoices
				WHERE [RECID] = @recid;

				IF COALESCE(@pymt_mgr_email, '') = ''
					SET @pymt_mgr_email = COALESCE(@vn_email, '')

				IF @vn_pay_to_country IS NULL SET @vn_pay_to_country = 'US'

			END  /* LOOP */

			-- Write the Trailer record

			SET @ls_hdr = 'T' /* Record ID */

			SET @ls_hdr = @ls_hdr + '|' + UPPER(RIGHT('00000000' + (CAST((@cnt) AS varchar(8))), 8)) /* Record Count */		
			SET @ls_hdr = @ls_hdr + '|' + UPPER(RIGHT((CAST((@chk_amt_total) AS varchar(20)) + SPACE(0)), 15)) /* Total Pmt Amt */		
			SET @ls_hdr = @ls_hdr + '|' + 'TT' /* End of record indicator */
			
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
			SET @is_export_file = CHAR(13) + @is_log	

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

	/***********************************************************************************************************************/
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
		SET @is_export_file =  CHAR(13) + @is_log	

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

GRANT EXECUTE ON [advsp_pmt_mgr_wf] TO PUBLIC AS dbo
GO