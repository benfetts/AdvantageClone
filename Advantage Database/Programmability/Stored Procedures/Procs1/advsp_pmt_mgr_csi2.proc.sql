
/****** Object:  StoredProcedure [dbo].[advsp_pmt_mgr_csi2]    Script Date: 10/24/2014 15:36:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_pmt_mgr_csi2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_pmt_mgr_csi2]
GO

/****** Object:  StoredProcedure [dbo].[advsp_pmt_mgr_csi2]    Script Date: 10/24/2014 15:36:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_pmt_mgr_csi2] 
@is_chk_run varchar(50), @is_bank varchar(50)

/* PJH 01/10/14 - Use AP_DESC for both @is_pm_type = 'CSI' was SPACE(60) */
/* PJH 02/26/14 - Added ASP support for export folder */

AS

DECLARE @as_chk_run varchar(50), @as_bank varchar(50)
DECLARE @is_pm_type varchar(50), @is_pm_acct varchar(50), @is_bank_desc varchar(50), @is_pm_id varchar(10)
DECLARE @is_pm_word varchar(50), @il_bk_routing_nbr bigint, @is_ach_company_id varchar(10)
DECLARE @is_pm_dir varchar(100), @is_pm_ftp varchar(254), @is_export_file varchar(max)
DECLARE @is_log varchar(max), @is_output_file varchar(50), @success int, @cnt int
/* Agency Vars */
DECLARE @is_currency_code varchar(50), @is_agy_name varchar(50), @is_agy_reply_to varchar(50)
DECLARE @is_agy_addr varchar(50), @is_agy_addr2 varchar(50), @is_agy_city varchar(50), @is_agy_state varchar(50)
DECLARE @is_agy_zip varchar(10), @is_agy_phone varchar(15)
DECLARE @il_asp int, @is_import_path varchar(254)

SET @as_chk_run = @is_chk_run
SET @as_bank = @is_bank

IF OBJECT_ID('tempdb..#pmt_mgr_invoices') IS NOT NULL
DROP TABLE #pmt_mgr_invoices

CREATE TABLE #pmt_mgr_invoices(
	/*  AP_HEADER   */
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
	[SELECTED_FLAG] [smallint] NULL,
 CONSTRAINT [PK_W_PMT_MGR_INV_tmp] PRIMARY KEY CLUSTERED 
(
	[BK_CODE] ASC,
	[CHECK_RUN_ID] ASC,
	[CHECK_NBR] ASC,
	[VN_FRL_EMP_CODE] ASC,
	[AP_INV_VCHR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]	

BEGIN TRY

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

SET @is_pm_type = UPPER(RTRIM(@is_pm_type))
SET @is_pm_acct = UPPER(RTRIM(@is_pm_acct))
SET @is_pm_id = UPPER(RTRIM(@is_pm_id))

/* PJH 02/26/14 - Added ASP support for export folder */
SELECT @il_asp = ASP_ACTIVE, @is_import_path = IMPORT_PATH
FROM   AGENCY;

SELECT @il_asp = ISNULL(@il_asp, 0)

IF (@il_asp = 1) BEGIN

	IF @is_pm_type = 'CSI' OR @is_pm_type = 'CSI2' BEGIN
	
		IF RIGHT(@is_import_path, 1) = '\' BEGIN
		
			SET @is_import_path = @is_import_path + 'csi\'
		
		END ELSE BEGIN 
		
			SET @is_import_path = @is_import_path + '\csi\'
			
		END
		
	END ELSE BEGIN
	
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

IF (@is_pm_id='') OR (@is_pm_word='') OR (@is_pm_dir='') 
BEGIN
	SET @is_log = 'Unable to obtain Payment Manager data for bank ' +@as_bank + '.' + CHAR(13)
	SET @success = 0
	--RETURN FALSE
END

IF LEN(@is_pm_acct) > 5 
BEGIN
	SET @is_log = @is_log + 'Bank Account Number exceeds 5 digits.  ' + CHAR(13)
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

SET @is_output_file = @is_pm_acct + '.' + @is_pm_id + '.PS00016.' + REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') +  '.' + REPLACE(CONVERT(VARCHAR(12), GETDATE(), 114), ':','') + '0'

--PRINT '01: ' + @is_pm_dir + ' | ' + @is_pm_type + ' | ' + @is_pm_acct + ' | ' + @is_pm_id + ' | ' + @is_pm_ftp + ' | ' + @is_output_file

/* Get Agency Data */
SELECT @is_currency_code=HOME_CRNCY, @is_agy_name=NAME, @is_agy_reply_to=POP3_REPLY_TO,
	@is_agy_addr=COALESCE(RTRIM(ADDRESS1),'') + ', ', @is_agy_addr2=	COALESCE(RTRIM(ADDRESS2),'') + ', ', 
	@is_agy_city=COALESCE(RTRIM(CITY),'') + ', ', @is_agy_state=COALESCE(RTRIM(STATE),'') + ', ', @is_agy_zip=COALESCE(RTRIM(ZIP),''), @is_agy_phone=Replace(Replace(Replace(Replace(Replace(PHONE,'(',''),' ',''),'.',''),')',''),'-','')
FROM   AGENCY;

IF @is_agy_addr2 > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_addr2
IF @is_agy_city > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_city
IF @is_agy_state > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_state
IF @is_agy_zip > ',' SET @is_agy_addr = @is_agy_addr + @is_agy_zip

--PRINT '02: ' + @is_agy_addr + ' | ' + @is_agy_phone

BEGIN

INSERT INTO #pmt_mgr_invoices
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
			 COALESCE(VENDOR.PYMT_MGR_EMAIL, ''),   --VN_PAY_TO_PHONE	VN_PAY_TO_EXT	VN_PAY_TO_FAX_NBR	VN_PAY_TO_FAX_EXT, VN_PAY_TO_ADDRESS3, VN_PAY_TO_EMAIL
				 --COALESCE(VENDOR.VN_NAME, ''),   
				 --COALESCE(VENDOR.VN_ADDRESS1, '') VN_ADDRESS1, COALESCE(VENDOR.VN_ADDRESS2, '') VN_ADDRESS2, COALESCE(VENDOR.VN_CITY, '') VN_CITY,
				 --COALESCE(VENDOR.VN_COUNTY, '') VN_COUNTY, COALESCE(VENDOR.VN_STATE, '') VN_STATE, COALESCE(VENDOR.VN_ZIP, '') VN_ZIP, COALESCE(VENDOR.VN_COUNTRY, '') VN_COUNTRY,
				 --COALESCE(VENDOR.VN_FAX_NUMBER, '') VN_FAX_NUMBER, COALESCE(VENDOR.VN_EMAIL, '') VN_EMAIL,
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


--SELECT @as_chk_run, @as_bank
SELECT * FROM #pmt_mgr_invoices;

END

DECLARE @ls_hdr varchar(max), @ls_output varchar(max)
DECLARE @ap_desc varchar(50), @ls_mail varchar(50), @pymt_mgr_email varchar(50), @vn_email varchar(50), @vn_fax_number varchar(50)
DECLARE @vn_pay_to_address1 varchar(30), @vn_pay_to_address2 varchar(30), @vn_pay_to_address3 varchar(30), @vn_pay_to_city varchar(20)
DECLARE @vn_pay_to_county varchar(30), @vn_pay_to_state varchar(2), @vn_pay_to_zip varchar(12), @vn_pay_to_country varchar(3)

DECLARE @pay_to_code varchar(50), @vn_name varchar(50), @ap_inv_vchr varchar(50), @ap_inv_date varchar(30), @payment_date varchar(30) 
DECLARE @ap_chk_nbr varchar(50), @ap_chk_amt decimal(14,2), @ap_disc_amt decimal(14,2), @inv_gross_amt decimal(14,2)
DECLARE @amt_sign varchar(1), @str_amt varchar(20)

IF @success = 1 AND @@ROWCOUNT > 0
	BEGIN

		/* The first 35 bytes are the same for each line - account + id + word */
		SET @ls_hdr = UPPER(LEFT((@is_pm_acct + SPACE(5)), 5)) /** Account Code **/
		SET @ls_hdr = @ls_hdr + UPPER(LEFT((@is_pm_id + SPACE(10)), 10)) /** Customer ID **/
		SET @ls_hdr = @ls_hdr + UPPER(LEFT((@is_pm_word + SPACE(20)), 20)) /** Word **/

		DECLARE db_cursor CURSOR FOR  
		SELECT AP_DESC, PYMT_MGR_EMAIL, VN_EMAIL, PAY_TO_CODE, VN_PAY_TO_NAME, AP_INV_VCHR, REPLACE(CONVERT(VARCHAR(10), AP_INV_DATE, 101), '/', '') AS MMDDYYYY,
			REPLACE(CONVERT(VARCHAR(10), GETDATE(), 101), '/', '') AS MMDDYYYY, AP_CHK_NBR, AP_CHK_AMT, AP_DISC_AMT, VN_FAX_NUMBER, VN_PAY_TO_ADDRESS1, VN_PAY_TO_ADDRESS2,  VN_PAY_TO_ADDRESS3,
			VN_PAY_TO_CITY, 	VN_PAY_TO_COUNTY, VN_PAY_TO_STATE, VN_PAY_TO_ZIP, VN_PAY_TO_COUNTRY
		FROM #pmt_mgr_invoices
		WHERE CHECK_RUN_ID = @as_chk_run AND BK_CODE = @as_bank;

		OPEN db_cursor  
		FETCH NEXT FROM db_cursor 
		INTO @ap_desc, @pymt_mgr_email,  @vn_email, @pay_to_code, @vn_name, @ap_inv_vchr, @ap_inv_date,
			@payment_date, @ap_chk_nbr, @ap_chk_amt, @ap_disc_amt, @vn_fax_number, @vn_pay_to_address1, @vn_pay_to_address2, @vn_pay_to_address3, 
			@vn_pay_to_city, @vn_pay_to_county, @vn_pay_to_state, @vn_pay_to_zip, @vn_pay_to_country;
			
		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			PRINT 'IN'
			SET @ls_mail = @pymt_mgr_email
			IF (@ls_mail = '') SET @ls_mail = @vn_email
			
			SET @ls_output = @ls_hdr /** from above */
			SET @ls_output = @ls_output + UPPER(LEFT((@pay_to_code + SPACE(25)), 25)) /** Vendor Code **/
			SET @ls_output = @ls_output + UPPER(LEFT((@vn_name + SPACE(50)), 50)) /** Vendor Name **/
			SET @ls_output = @ls_output + UPPER(LEFT((@ls_mail + SPACE(50)), 50)) /** Vendor Email **/
			SET @ls_output = @ls_output + SPACE(50) /** Vendor Email 2 **/
			SET @ls_output = @ls_output + UPPER(LEFT((@ap_inv_vchr + SPACE(15)), 15)) /** Invoice Nbr */
			SET @ls_output = @ls_output + UPPER(LEFT((@ap_inv_date + SPACE(8)), 8)) /** Invoice Date **/
			SET @ls_output = @ls_output + UPPER(LEFT((@ap_inv_date + SPACE(8)), 8)) /** Due Date **/
			SET @ls_output = @ls_output + UPPER(LEFT((@payment_date + SPACE(8)), 8)) /** Pmt Date - Today **/
			SET @ls_output = @ls_output + UPPER(LEFT((@ap_chk_nbr + SPACE(10)), 10)) /** Pmt Nbr **/
			/* PJH 01/10/14 - Use AP_DESC for both @is_pm_type = 'CSI' was SPACE(60) */
			SET @ls_output = @ls_output + UPPER(LEFT((@ap_desc + SPACE(60)), 60)) /** Invoice Cmts - AP Desc **/

			SET @ls_output = @ls_output + SPACE(15)	 /** PO Nbr **/
			
			SET @inv_gross_amt = @ap_chk_amt + @ap_disc_amt

			SET @amt_sign = '+'
			IF @inv_gross_amt < 0 SET @amt_sign = '-'
			
			SET @ls_output = @ls_output + @amt_sign /** Gross Amt Sign - 1 **/
			
			SET @str_amt = CAST(ABS(@inv_gross_amt * 100) AS varchar(20))
			SET @str_amt = LEFT(@str_amt, LEN(@str_amt)-3)
			
			SET @ls_output = @ls_output + RIGHT('0000000000' + @str_amt, 10) /** Gross Amt - 10 **/
			
			SET @amt_sign = '+'
			IF @ap_chk_amt < 0 SET @amt_sign = '-'
			
			SET @ls_output = @ls_output + @amt_sign /** Net Amt Sign - 1 **/
			
			SET @str_amt = CAST(ABS(@ap_chk_amt * 100) AS varchar(20))
			SET @str_amt = LEFT(@str_amt, LEN(@str_amt)-3)
			
			SET @ls_output = @ls_output + RIGHT('0000000000' + @str_amt, 10)  /** Net Amt - 10 **/
			
			SET @amt_sign = '+'
			IF @ap_disc_amt < 0 SET @amt_sign = '-'
			
			SET @ls_output = @ls_output + @amt_sign /** Disc Amt Sign - 1 **/	
			
			SET @str_amt = CAST(ABS(@ap_disc_amt * 100) AS varchar(20))
			SET @str_amt = LEFT(@str_amt, LEN(@str_amt)-3)
			
			SET @ls_output = @ls_output + RIGHT('0000000000' + @str_amt, 10) /** Discount Amt - 10 **/		
			
			SET @ls_output = @ls_output + UPPER(LEFT((@ap_chk_nbr + SPACE(15)), 15)) /***/
			
			SET @ls_output = @ls_output + SPACE(60)	 /** GL Acct Nbr **/	
			
			SET @ls_output = @ls_output + UPPER(LEFT((@vn_fax_number + SPACE(10)), 10)) /** Vendor Fax **/
			SET @ls_output = @ls_output + SPACE(10)	 /** Optional Data **/	
			SET @ls_output = @ls_output + SPACE(17)	 /** Optional Data **/		
			SET @ls_output = @ls_output + SPACE(17)	 /** Optional Data **/	
			IF @is_pm_type = 'CSI2' 
			BEGIN
				SET @ls_output = @ls_output + UPPER(LEFT((@vn_pay_to_address1 + SPACE(30)), 30)) /** Vendor Addr 1 **/
				SET @ls_output = @ls_output + UPPER(LEFT((@vn_pay_to_address2 + SPACE(30)), 30)) /** Vendor Addr 2 **/
				SET @ls_output = @ls_output + UPPER(LEFT((@vn_pay_to_city + SPACE(20)), 20)) /** Vendor City **/
				SET @ls_output = @ls_output + UPPER(LEFT((@vn_pay_to_state + SPACE(2)), 2)) /** Vendor State **/
				SET @ls_output = @ls_output + UPPER(LEFT((@vn_pay_to_zip + SPACE(12)), 12)) /** Vendor Zip **/		
				/** Country Code - Defaults to 3 spaces '   ' if not provided or invalid format **/
				IF ISNUMERIC(@vn_pay_to_country) = 1 SET @vn_pay_to_country = SPACE(3)
				IF LEN(@vn_pay_to_country) > 3 SET @vn_pay_to_country = LEFT(@vn_pay_to_country, 3)
				SET @ls_output = @ls_output + UPPER(LEFT((@vn_pay_to_country + SPACE(3)), 3)) /** Country Code **/	
			END
			
			--PRINT @ls_output
			
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
			
			SET @cnt = @cnt + 1
			
			FETCH NEXT FROM db_cursor 
			INTO @ap_desc, @pymt_mgr_email,  @vn_email, @pay_to_code, @vn_name, @ap_inv_vchr, @ap_inv_date,
				@payment_date, @ap_chk_nbr, @ap_chk_amt, @ap_disc_amt, @vn_fax_number, @vn_pay_to_address1, @vn_pay_to_address2, @vn_pay_to_address3, 
				@vn_pay_to_city, @vn_pay_to_county, @vn_pay_to_state, @vn_pay_to_zip, @vn_pay_to_country
		END  

		CLOSE db_cursor  
		DEALLOCATE db_cursor 

		-- Write the Trailer record

		IF @cnt > 0 --Detail rows exist
		BEGIN
			SET @is_export_file = '**FTP'
			
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
IF @success = 0
	BEGIN
		/*	@is_log = is set where error occured */
		
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

IF OBJECT_ID('tempdb..#pmt_mgr_invoices') IS NOT NULL
DROP TABLE #pmt_mgr_invoices

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
   
   RETURN 0 /* Failed */
    
END CATCH

GO

GRANT EXECUTE ON advsp_pmt_mgr_csi2 TO PUBLIC AS dbo


GO


