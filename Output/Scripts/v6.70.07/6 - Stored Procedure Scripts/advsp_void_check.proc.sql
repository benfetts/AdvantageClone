IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.advsp_void_check') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.advsp_void_check
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.advsp_void_check 
	@bk_code varchar(10), 
	@check_nbr integer, 
	@check_list varchar(4000),
	@post_period varchar(6),
	@action varchar(10),
	@user_id varchar(100),
	@comment varchar(254),
	@ret_val integer OUTPUT, 
	@ret_val_s varchar(4000) OUTPUT

AS
/*
***********************************************************************************************************
PJH 05/10/17 - Created advsp_void_check - will accommodate +/- 500 check numbers
***********************************************************************************************************
*/

--DECLARE 	@ret_val integer, 
--	@ret_val_s varchar(4000) 


DECLARE @chk_nbr_list TABLE (
	CHECK_NBR integer
)

DECLARE @ap_pmt_hist TABLE (
	RowID int IDENTITY(1,1),
	AP_ID int NOT NULL,
	AP_SEQ smallint NOT NULL,
	BK_CODE varchar(4) NOT NULL,
	AP_CHK_NBR int NOT NULL,
	CHK_SEQ smallint NOT NULL,
	AP_CHK_DATE smalldatetime NOT NULL,
	AP_CHK_AMT decimal(14, 2) NULL,
	AP_DISC_AMT decimal(11, 2) NULL,
	AP_CHK_MAN smallint NULL,
	AP_CHK_HOLD_FLAG smallint NULL,
	AP_CHK_MAILED smalldatetime NULL,
	AP_CHK_CLEAR_FLAG smallint NULL,
	GLACODE_CASH varchar(30) NOT NULL,
	GLACODE_DISC varchar(30) NULL,
	GLACODE_AP varchar(30) NOT NULL,
	GLEXACT int NOT NULL,
	GLESEQ_CASH smallint NOT NULL,
	GLESEQ_DISC smallint NULL,
	GLESEQ_AP smallint NOT NULL,
	POST_PERIOD varchar(6) NOT NULL,
	CREATE_DATE smalldatetime NULL,
	USERID varchar(100) NULL,
	VENDOR_SERVICE_TAX_ID int NULL,
	VENDOR_TAXABLE_AMOUNT decimal(14, 2) NULL,
	VENDOR_SERVICE_TAX decimal(14, 2) NULL,
	SERVICE_TAX_RATE decimal(5, 3) NULL,
	VENDOR_YTD_TAXABLE decimal(14, 2) NULL,
	TAXABLE_THRESHOLD decimal(14, 2) NULL,
	GLACODE_WH varchar(30) NULL,
	GLESEQ_WH smallint NULL,

	EXCHANGE_AMOUNT_APPLIED decimal(14, 2) NULL,

	HOME_CURRENCY_CODE varchar(5) NULL,
	BANK_CURRENCY_CODE varchar(5) NULL,
	AP_CURRENCY_CODE varchar(5) NULL,
	EXCHANGE_AMOUNT decimal(14, 2) NULL,

	GLACODE_CRNCY_UNREALIZED varchar(30) NULL,
	
	FOREIGN_INV_AMOUNT decimal(14, 2) NULL,
	FOREIGN_SALES_TAX decimal(11, 2) NULL,

	EXCHANGE_DISC_AMOUNT decimal(14, 2) NULL,

	CURRENCY_RATE decimal(12, 6) NULL,
	
	NEW_ROW smallint
)

DECLARE @gl_header TABLE (
	GLEHXACT int NOT NULL,
	GLEHPOSTSUM smalldatetime NULL,
	GLEHSOURCETIME smalldatetime NULL,
	GLEHENTDATE smalldatetime NOT NULL,
	GLEHMODDATE smalldatetime NOT NULL,
	GLEHPP varchar(6) NULL,
	GLEHLPP varchar(6) NULL,
	GLEHREVFLG varchar(1) NULL,
	GLEHUSER varchar(100) NULL,
	GLEHCFF1 varchar(30) NULL,
	GLEHCFF2 varchar(30) NULL,
	GLEHCFF3 varchar(30) NULL,
	GLEHNFF1 decimal (20,8) NULL,
	GLEHNFF2 decimal (20,8) NULL,
	GLEHDTFF1 smalldatetime NULL,
	GLEHDTFF2 smalldatetime NULL,
	GLEHMOD varchar(1) NULL,
	GLEHDESC varchar(100) NULL,
	GLEHSOURCE varchar(2) NULL,
	GLEHREVENTRY smallint NULL,
	GLEHREVXACT int NULL,
	GLEHVOID smallint NULL,
	EXPORTED_DATE smalldatetime NULL,
	BATCH_DATE smalldatetime NULL
	)

DECLARE @gl_detail TABLE (
	GLETXACT int NOT NULL,
	GLETSEQ smallint NOT NULL,
	GLETCODE varchar(30) NOT NULL,
	GLETAMT decimal (20,8) NOT NULL,
	GLETFCAMT decimal (20,8) NOT NULL,
	GLETCUR varchar(3) NULL,
	GLETQTY decimal (20,8) NULL,
	GLETREM varchar(150) NULL,
	GLETJOBCOSTID int NULL,
	GLETSOURCE varchar(2) NULL,
	GLETCFF1 varchar(30) NULL,
	GLETNFF1 decimal (20,8) NULL,
	GLETDTFF1 smalldatetime NULL,
	GLETBASE varchar(20) NULL,
	GLETOFFICE varchar(20) NULL,
	GLETDEPT varchar(20) NULL,
	GLETOTHER varchar(20) NULL,
	CL_CODE varchar(6) NULL,
	DIV_CODE varchar(6) NULL,
	PRD_CODE varchar(6) NULL,
	CLEARED smallint NULL,
	REC_STMT_DATE smalldatetime NULL,
	RECON_FLAG smallint NULL,
	AR_INV_NBR int NULL,
	GLCODE_SRC varchar(2)
)

DECLARE @gl_detail_sum TABLE (
	GLETXACT int NOT NULL,
	GLETSEQ int identity (1,1) NOT NULL,
	GLETCODE varchar(30) NOT NULL,
	GLETAMT decimal (20,8) NOT NULL,
	GLETFCAMT decimal (20,8) NOT NULL,
	GLETCUR varchar(3) NULL,
	GLETQTY decimal (20,8) NULL,
	GLETREM varchar(150) NULL,
	GLETJOBCOSTID int NULL,
	GLETSOURCE varchar(2) NULL,
	GLETCFF1 varchar(30) NULL,
	GLETNFF1 decimal (20,8) NULL,
	GLETDTFF1 smalldatetime NULL,
	GLETBASE varchar(20) NULL,
	GLETOFFICE varchar(20) NULL,
	GLETDEPT varchar(20) NULL,
	GLETOTHER varchar(20) NULL,
	CL_CODE varchar(6) NULL,
	DIV_CODE varchar(6) NULL,
	PRD_CODE varchar(6) NULL,
	CLEARED smallint NULL,
	REC_STMT_DATE smalldatetime NULL,
	RECON_FLAG smallint NULL,
	AR_INV_NBR int NULL
)

DECLARE @ROW_COUNT int, @ROW_ID int, @DEBUG int
DECLARE @RC int, @RC_MSG varchar(max)
DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int

DECLARE @error_msg_w varchar(200)

DECLARE @gl_remark varchar(200)
DECLARE @bk_desc varchar(200)
DECLARE @gl_source varchar(6)

DECLARE @ap_chk_nbr integer
DECLARE @gletxact int
DECLARE @gletxact_orig int

DECLARE @gl_ap_code varchar(30)
DECLARE @gl_cash_code varchar(30)
DECLARE @gl_disc_code varchar(30)
DECLARE @gl_service_tax_code varchar(30)
DECLARE @gl_withholding_code varchar(30)
DECLARE @gl_exchange_code varchar(30)

DECLARE @ap_amt_paid decimal (20,8)
DECLARE @gl_ap_amt decimal (20,8)
DECLARE @gl_cash_amt decimal (20,8)
DECLARE @gl_disc_amt decimal (20,8)

DECLARE @home_currency_code varchar(5)
DECLARE @bank_currency_code varchar(5)
DECLARE @ap_currency_code varchar(5)
DECLARE @ap_bank_flag bit

DECLARE @gl_service_tax_amt decimal (20,8)
DECLARE @gl_exchange_amt decimal (20,8)
DECLARE @gl_exchange_ap_amt decimal (20,8)
DECLARE @gl_exchange_disc_amt decimal (20,8)
DECLARE @gl_exchange_wh_amt decimal (20,8)
DECLARE @gl_currency_rate decimal (20,8)

DECLARE @gleseq_cash int
DECLARE @gleseq_disc int
DECLARE @gleseq_ap int
DECLARE @gleseq_wh int

DECLARE @check_date smalldatetime
DECLARE @gl_check_amt decimal (20,8)
DECLARE @gl_wh_code varchar(30)
DECLARE @gl_wh_amt decimal (20,8)
DECLARE @gl_post_period varchar(6)

DECLARE @current_date smalldatetime
DECLARE @gl_seq_tmp int
DECLARE @hdr bit

DECLARE @rowcount int


/*********** S T A R T *****************/

SET NOCOUNT ON

BEGIN TRY

SET @ret_val = 0

SET @current_date = GETDATE()

DELETE @chk_nbr_list

IF @check_list > '' BEGIN
	INSERT INTO @chk_nbr_list   /* Convert Comma Separated String to table */
	SELECT CAST(vstr AS integer) FROM dbo.fn_charlist_to_table2 (
	   @check_list
	)
	ORDER BY CAST(vstr AS integer)
END ELSE BEGIN
	INSERT INTO @chk_nbr_list /* Single Check Nbr */
	SELECT @check_nbr
END

IF @action = 'DEBUG'
	SELECT * FROM @chk_nbr_list

BEGIN TRAN

--SET @error_msg_w = 'TEST ERROR'
--GOTO ERROR_MSG

IF @bk_code IS NOT NULL AND @check_nbr IS NOT NULL
	INSERT INTO @ap_pmt_hist 
	SELECT 
			A.AP_ID,
			A.AP_SEQ,
			BK_CODE,
			AP_CHK_NBR,
			CHK_SEQ,
			AP_CHK_DATE,
			AP_CHK_AMT,
			AP_DISC_AMT,
			AP_CHK_MAN,
			AP_CHK_HOLD_FLAG,
			AP_CHK_MAILED,
			AP_CHK_CLEAR_FLAG,
			GLACODE_CASH,
			GLACODE_DISC,
			GLACODE_AP,
			A.GLEXACT,
			GLESEQ_CASH,
			GLESEQ_DISC,
			GLESEQ_AP,
			A.POST_PERIOD,
			A.CREATE_DATE,
			USERID,
			A.VENDOR_SERVICE_TAX_ID,
			A.VENDOR_TAXABLE_AMOUNT,
			VENDOR_SERVICE_TAX,
			SERVICE_TAX_RATE,
			VENDOR_YTD_TAXABLE,
			TAXABLE_THRESHOLD,
			GLACODE_WH,
			GLESEQ_WH,

			EXCHANGE_AMOUNT_APPLIED,

			HOME_CURRENCY_CODE,
			BANK_CURRENCY_CODE,
			AP_CURRENCY_CODE,
			A.EXCHANGE_AMOUNT,

			GLACODE_CRNCY_UNREALIZED,

			A.FOREIGN_INV_AMOUNT,
			A.FOREIGN_SALES_TAX,

			EXCHANGE_DISC_AMOUNT,

			CURRENCY_RATE,

			0 /* NEW_ROW */
	FROM AP_PMT_HIST A 
			JOIN @chk_nbr_list B ON B.CHECK_NBR = A.AP_CHK_NBR
			JOIN AP_HEADER H ON H.AP_ID = A.AP_ID AND H.AP_SEQ = A.AP_SEQ
	WHERE BK_CODE = @bk_code AND CHK_SEQ = 0
			AND EXISTS (SELECT * FROM CHECK_REGISTER WHERE BK_CODE = A.BK_CODE AND CHECK_NBR = A.AP_CHK_NBR AND VOID_FLAG IS NULL AND CLEARED IS NULL)
	ORDER BY AP_CHK_NBR

SET @ROW_COUNT = @@ROWCOUNT

IF @action = 'DEBUG'
	SELECT NEW_ROW, * FROM @ap_pmt_hist

SET @ROW_ID = 1

IF @action = 'DEBUG'
	SELECT A.* 
	FROM CHECK_REGISTER A
		INNER JOIN @ap_pmt_hist B 
		ON A.CHECK_NBR = B.AP_CHK_NBR AND A.BK_CODE=@bk_code

SELECT @bk_desc = BK_DESCRIPTION  FROM BANK WHERE BK_CODE = @bk_code

IF ( @ret_val = 0 )
BEGIN
		UPDATE IDS
		SET @gletxact = COALESCE( IDSXACT, 0 ) + 1,
		IDSXACT = COALESCE( IDSXACT, 0 ) + 1
		FROM IDS WHERE IDSTABLE = 'GLENTHDR'
				
		SET @ret_val = @@ERROR
END

SET @gletxact = @gletxact - 0 --<<<<<<<<<<<<<<<<<<< Test PK Error <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

SET @hdr = 0

IF ( @ret_val = 0 ) 
BEGIN
	WHILE @ROW_ID <= @ROW_COUNT AND @ret_val = 0 BEGIN
		
		IF @action = 'DEBUG'
			SELECT * FROM @ap_pmt_hist WHERE RowID = @ROW_ID

		SET @gl_seq_tmp = 1

		SELECT @ap_chk_nbr = AP_CHK_NBR,
			@gl_ap_code = GLACODE_AP,
			@gl_cash_code = GLACODE_CASH,
			@gl_disc_code = GLACODE_DISC,
			@gl_service_tax_code = GLACODE_WH,
			@gl_exchange_code = GLACODE_CRNCY_UNREALIZED,
			@ap_amt_paid = COALESCE(AP_CHK_AMT,0),
			@gl_disc_amt = COALESCE(AP_DISC_AMT,0),
			@gl_service_tax_amt = COALESCE(VENDOR_SERVICE_TAX,0),
			@gl_exchange_amt = COALESCE(EXCHANGE_AMOUNT_APPLIED,0),	
			@gl_exchange_disc_amt = COALESCE(EXCHANGE_DISC_AMOUNT,0),
			@gl_currency_rate = COALESCE(CURRENCY_RATE,0),
			@home_currency_code = HOME_CURRENCY_CODE,
			@bank_currency_code = BANK_CURRENCY_CODE,
			@ap_currency_code = AP_CURRENCY_CODE,
			@gletxact_orig = GLEXACT
		FROM @ap_pmt_hist 
		WHERE RowID = @ROW_ID

		SELECT @gl_check_amt = COALESCE(CHECK_AMT,0), 
			@check_date = CHECK_DATE, 
			@gl_wh_amt = COALESCE(WH_AMT,0), 
			@gl_wh_code = GLACODE_WH, 
			@gl_post_period = POST_PERIOD
		FROM CHECK_REGISTER 
		WHERE BK_CODE = @bk_code AND CHECK_NBR = @ap_chk_nbr 

		SET @ret_val = @@ERROR

		IF @bank_currency_code = @ap_currency_code BEGIN
			SET @ap_bank_flag = 1
		END

		SET @gl_remark = 'Check voided - # ' + CAST(@ap_chk_nbr AS varchar(30)) + '  Bank: ' + @bk_desc

		IF @comment IS NULL OR @comment = ''
			SET @comment = @gl_remark

		--SET @gl_ap_amt = (@ap_amt_paid + @gl_disc_amt + @gl_service_tax_amt) * (-1)

		--SET @gl_cash_amt = @ap_amt_paid - @gl_wh_amt + @gl_service_tax_amt

		IF @gl_currency_rate <> 0 AND @ap_bank_flag = 1 BEGIN
			SET @gl_exchange_ap_amt = ROUND(@ap_amt_paid * @gl_currency_rate,2)
			SET @gl_exchange_disc_amt = ROUND(@gl_disc_amt * @gl_currency_rate,2)
			SET @gl_exchange_wh_amt = ROUND(@gl_service_tax_amt,2) --* @gl_currency_rate

			SET @gl_exchange_ap_amt = (@gl_exchange_ap_amt + @gl_exchange_disc_amt + @gl_exchange_wh_amt)
		END
		ELSE BEGIN
			SET @gl_ap_amt = ROUND(@ap_amt_paid + @gl_disc_amt + @gl_service_tax_amt,2)
		END

		SET @gl_cash_amt = @ap_amt_paid -- (- @gl_wh_amt + @gl_service_tax_amt)

		IF COALESCE(@gl_exchange_ap_amt,0) <> 0 BEGIN
			SET @gl_ap_amt = @gl_exchange_ap_amt * -1
			SET @gl_exchange_amt = @gl_exchange_amt * -1
			SET @gl_disc_amt = @gl_exchange_disc_amt --* -1
			SET @gl_service_tax_amt = @gl_exchange_wh_amt --* -1
		END
		ELSE BEGIN
			SET @gl_ap_amt = @gl_ap_amt * -1
			SET @gl_disc_amt = @gl_disc_amt --* -1
			SET @gl_service_tax_amt = @gl_service_tax_amt --* -1
		END

		SET @gl_source = 'VC'

		IF @ret_val = 0 AND @hdr <> 1 BEGIN
				INSERT INTO @gl_header (
				GLEHXACT, 
				GLEHPP, 
				GLEHUSER, 
				GLEHENTDATE, 
				GLEHMODDATE, 
				GLEHDESC, 
				GLEHSOURCE )
			VALUES ( 
				@gletxact, 
				@post_period, 
				@user_id, 
				@current_date, 
				@current_date, 
				@gl_remark, 
				@gl_source )

			SET @hdr = 1
			IF @action = 'DEBUG' BEGIN
				SELECT 'HEADER' 'ORG', * FROM GLENTHDR WHERE GLEHXACT = @gletxact_orig
				SELECT 'HEADER' 'NEW', * FROM @gl_header
			END
		END

		/* AP Amount */
		IF @ret_val = 0 BEGIN
			SET @gleseq_ap = @gl_seq_tmp
			INSERT INTO @gl_detail (
				GLETXACT,
				GLETSEQ,
				GLETCODE,
				GLETAMT,
				GLETFCAMT,
				GLETREM,
				GLETSOURCE,
				GLCODE_SRC )
			SELECT
				@gletxact,
				@gl_seq_tmp,
				@gl_ap_code,
				@gl_ap_amt,
				@gl_ap_amt,
				@gl_remark,
				@gl_source,
				'2'
		END

		SET @ret_val = @@ERROR

		/* Cash Amount */
		IF @ret_val = 0 BEGIN
			SET @gl_seq_tmp = @gl_seq_tmp + 1
			SET @gleseq_cash = @gl_seq_tmp
			INSERT INTO @gl_detail (
				GLETXACT,
				GLETSEQ,
				GLETCODE,
				GLETAMT,
				GLETFCAMT,
				GLETREM,
				GLETSOURCE,
				GLCODE_SRC )
			SELECT
				@gletxact,
				@gl_seq_tmp,
				@gl_cash_code,
				@gl_cash_amt,
				@gl_cash_amt,
				@gl_remark,
				@gl_source,
				'1'
		END

		SET @ret_val = @@ERROR

		/* Discount Amount */
		IF @ret_val = 0 BEGIN
			IF @gl_disc_code > '' BEGIN
				SET @gl_seq_tmp = @gl_seq_tmp + 1
				SET @gleseq_disc = @gl_seq_tmp
				IF @gl_disc_amt <> 0 BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_disc_code,
						@gl_disc_amt,
						@gl_disc_amt,
						@gl_remark,
						@gl_source,
						'3'
				END 
				ELSE BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_disc_code,
						0,
						0,
						@gl_remark,
						@gl_source,
						'3'
				END	
			END
		END

		SET @ret_val = @@ERROR

		/* Service Tax Amount */
		IF @ret_val = 0 BEGIN
			IF @gl_service_tax_code > '' BEGIN 
				SET @gl_seq_tmp = @gl_seq_tmp + 1
				SET @gleseq_wh = @gl_seq_tmp
				IF @gl_service_tax_amt <> 0 BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_service_tax_code,
						@gl_service_tax_amt,
						@gl_service_tax_amt,
						@gl_remark,
						@gl_source,
						'5'
				END
				ELSE BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_service_tax_code,
						0,
						0,
						@gl_remark,
						@gl_source,
						'5'
				END
			END
		END

		SET @ret_val = @@ERROR

		/* Exchange Tax Amount */
		IF @ret_val = 0 BEGIN
			IF @gl_exchange_code > '' BEGIN 
				SET @gl_seq_tmp = @gl_seq_tmp + 1
				--SET @gleseq_wh = N/A
				IF @gl_exchange_amt <> 0 BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_exchange_code,
						@gl_exchange_amt,
						@gl_exchange_amt,
						@gl_remark,
						@gl_source,
						'4'
				END 
				ELSE BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_exchange_code,
						0,
						0,
						@gl_remark,
						@gl_source,
						'4'
				END
			END
		END

		SET @ret_val = @@ERROR

		/* WH Amount */
		IF @ret_val = 0 BEGIN
			IF @gl_wh_code > '' BEGIN 
				SET @gl_seq_tmp = @gl_seq_tmp + 1
				IF @gl_wh_amt <> 0 BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_wh_code,
						@gl_wh_amt,
						@gl_wh_amt,
						@gl_remark,
						@gl_source,
						'6'
				END
				ELSE BEGIN
					INSERT INTO @gl_detail (
						GLETXACT,
						GLETSEQ,
						GLETCODE,
						GLETAMT,
						GLETFCAMT,
						GLETREM,
						GLETSOURCE,
						GLCODE_SRC )
					SELECT
						@gletxact,
						@gl_seq_tmp,
						@gl_wh_code,
						0,
						0,
						@gl_remark,
						@gl_source,
						'6'
				END
			END
		END

		SET @ret_val = @@ERROR

		IF @ret_val = 0 BEGIN
			INSERT INTO @ap_pmt_hist
				(AP_ID,
				AP_SEQ,
				BK_CODE,
				AP_CHK_NBR,
				CHK_SEQ,
				AP_CHK_DATE,
				AP_CHK_AMT,
				AP_DISC_AMT,
				AP_CHK_MAN,
				AP_CHK_HOLD_FLAG,
				AP_CHK_MAILED,
				AP_CHK_CLEAR_FLAG,
				GLACODE_CASH,
				GLACODE_DISC,
				GLACODE_AP,
				GLEXACT,
				GLESEQ_CASH,
				GLESEQ_DISC,
				GLESEQ_AP,
				POST_PERIOD,
				CREATE_DATE,
				USERID,
				VENDOR_SERVICE_TAX_ID,
				VENDOR_TAXABLE_AMOUNT,
				VENDOR_SERVICE_TAX,
				SERVICE_TAX_RATE,
				VENDOR_YTD_TAXABLE,
				TAXABLE_THRESHOLD,
				GLACODE_WH,
				GLESEQ_WH,

				EXCHANGE_AMOUNT_APPLIED,

				HOME_CURRENCY_CODE,
				BANK_CURRENCY_CODE,
				AP_CURRENCY_CODE,
				A.EXCHANGE_AMOUNT,

				GLACODE_CRNCY_UNREALIZED,

				A.FOREIGN_INV_AMOUNT,
				A.FOREIGN_SALES_TAX,

				EXCHANGE_DISC_AMOUNT,

				CURRENCY_RATE,
				NEW_ROW)
			SELECT 	AP_ID,
				AP_SEQ,
				BK_CODE,
				AP_CHK_NBR,
				CHK_SEQ + 1,
				AP_CHK_DATE,
				AP_CHK_AMT * (-1),
				AP_DISC_AMT * (-1),
				AP_CHK_MAN,
				AP_CHK_HOLD_FLAG,
				AP_CHK_MAILED,
				AP_CHK_CLEAR_FLAG,
				GLACODE_CASH,
				GLACODE_DISC,
				GLACODE_AP,
				@gletxact,
				@gleseq_cash,
				@gleseq_disc,
				@gleseq_ap,
				@post_period,
				@current_date, /* CREATE_DATE */
				@user_id,
				VENDOR_SERVICE_TAX_ID,
				VENDOR_TAXABLE_AMOUNT * (-1),
				VENDOR_SERVICE_TAX * (-1),
				SERVICE_TAX_RATE,
				VENDOR_YTD_TAXABLE,
				TAXABLE_THRESHOLD,
				GLACODE_WH,
				@gleseq_wh,

				EXCHANGE_AMOUNT_APPLIED * (-1),

				HOME_CURRENCY_CODE,
				BANK_CURRENCY_CODE,
				AP_CURRENCY_CODE,
				EXCHANGE_AMOUNT * (-1),

				GLACODE_CRNCY_UNREALIZED,

				FOREIGN_INV_AMOUNT * (-1),
				FOREIGN_SALES_TAX,

				EXCHANGE_DISC_AMOUNT * (-1),

				CURRENCY_RATE,


				1 /* NEW_ROW */
				FROM @ap_pmt_hist WHERE RowID = @ROW_ID
			END

			SET @ret_val = @@ERROR

		SET @ROW_ID = @ROW_ID + 1

	END /* While */
END

IF @action = 'DEBUG'
	SELECT NEW_ROW, * FROM @ap_pmt_hist WHERE NEW_ROW = 1

INSERT INTO @gl_detail_sum (
	GLETXACT,
	GLETCODE,
	GLETAMT,
	GLETFCAMT,
	GLETREM,
	GLETSOURCE )
SELECT 
	GLETXACT,
	--GLETSEQ,
	GLETCODE,
	SUM(COALESCE(GLETAMT,0)),
	SUM(COALESCE(GLETFCAMT,0)),
	MAX(GLETREM),
	MAX(GLETSOURCE) 
FROM @gl_detail
GROUP BY 
	GLCODE_SRC,
	GLETXACT,
	GLETSEQ,
	GLETCODE
HAVING SUM(COALESCE(GLETAMT,0)) <> 0
ORDER BY GLCODE_SRC, GLETXACT

UPDATE A
SET A.GLESEQ_AP = B.GLETSEQ
FROM @ap_pmt_hist A
    INNER JOIN @gl_detail_sum B ON
        A.GLACODE_AP = B.GLETCODE

UPDATE A
SET A.GLESEQ_CASH = B.GLETSEQ
FROM @ap_pmt_hist A
    INNER JOIN @gl_detail_sum B ON
        A.GLACODE_CASH = B.GLETCODE

UPDATE A
SET A.GLESEQ_DISC = B.GLETSEQ
FROM @ap_pmt_hist A
    INNER JOIN @gl_detail_sum B ON
        A.GLACODE_DISC = B.GLETCODE

UPDATE A
SET A.GLESEQ_WH = B.GLETSEQ
FROM @ap_pmt_hist A
    INNER JOIN @gl_detail_sum B ON
        A.GLACODE_WH = B.GLETCODE

/*

GLACODE_CASH,
GLACODE_DISC,
GLACODE_AP,
GLACODE_WH,
GLACODE_CRNCY_UNREALIZED

GLESEQ_CASH,
GLESEQ_DISC,
GLESEQ_AP,
GLESEQ_WH

*/

SET @ret_val = @@ERROR

IF @action = 'DEBUG'
	SELECT '*' 'OOB GL', GLETXACT FROM @gl_detail GROUP BY GLETXACT 
	HAVING SUM(CAST(COALESCE(GLETAMT,0) AS decimal(14,2))) <> 0

IF @action = 'DEBUG'
	SELECT '*' 'OOB GL SUM', GLETXACT FROM @gl_detail_sum GROUP BY GLETXACT 
	HAVING SUM(CAST(COALESCE(GLETAMT,0) AS decimal(14,2))) <> 0

IF @@ROWCOUNT > 0 BEGIN
	SET @error_msg_w = 'Out of balance Journal Entries!'
	GOTO ERROR_MSG
END 

IF @action = 'DEBUG'
	SELECT '*' 'OOB AP', AP_ID,AP_SEQ,	BK_CODE,AP_CHK_NBR  FROM @ap_pmt_hist GROUP BY AP_ID,AP_SEQ,BK_CODE,AP_CHK_NBR
	HAVING SUM(CAST(COALESCE(AP_CHK_AMT,0) AS decimal(14,2))) <> 0

IF @@ROWCOUNT > 0 BEGIN
	SET @error_msg_w = 'Out of balance AP Payment History Entries!'
	GOTO ERROR_MSG
END 

UPDATE A
	SET VOID_FLAG=1, 
		VOIDED_BY=@user_id, 
		VOID_DATE=@current_date, 
		VOID_POST_PERIOD=@post_period, 
		VO_COMMENT=@comment
	FROM CHECK_REGISTER A
		INNER JOIN @ap_pmt_hist B 
		ON A.CHECK_NBR = B.AP_CHK_NBR AND A.BK_CODE=@bk_code

IF @@ROWCOUNT <> 1
	SET @ret_val = 99999

SET @ret_val = @@ERROR

IF @action = 'DEBUG'
	SELECT A.* 
	FROM CHECK_REGISTER A
		INNER JOIN (
			SELECT AP_CHK_NBR, NEW_ROW FROM @ap_pmt_hist 
			WHERE NEW_ROW = 1 
			GROUP BY AP_CHK_NBR, NEW_ROW
		) B 
		ON A.CHECK_NBR = B.AP_CHK_NBR AND A.BK_CODE=@bk_code AND B.NEW_ROW = 1

IF @ret_val = 0 BEGIN
		INSERT INTO GLENTHDR (
		GLEHXACT, 
		GLEHPP, 
		GLEHUSER, 
		GLEHENTDATE, 
		GLEHMODDATE, 
		GLEHDESC, 
		GLEHSOURCE, 
		CREATE_DATE )
	SELECT 
		GLEHXACT, 
		GLEHPP, 
		GLEHUSER, 
		GLEHENTDATE, 
		GLEHMODDATE, 
		GLEHDESC, 
		GLEHSOURCE,
		GETDATE() FROM @gl_header
END

SET @ret_val = @@ERROR

SELECT @rowcount = COUNT(*) FROM GLENTHDR WHERE GLEHXACT = @gletxact

IF @rowcount < 1 BEGIN
	SET @error_msg_w = 'Missing GL Header record!'
	GOTO ERROR_MSG
END 

IF @ret_val = 0 BEGIN
	INSERT INTO GLENTTRL (
		GLETXACT,
		GLETSEQ,
		GLETCODE,
		GLETAMT,
		GLETFCAMT,
		GLETREM,
		GLETSOURCE )
	SELECT 
		GLETXACT,
		GLETSEQ,
		GLETCODE,
		GLETAMT,
		GLETFCAMT,
		GLETREM,
		GLETSOURCE 
	FROM @gl_detail_sum
END

SET @ret_val = @@ERROR

IF @ret_val = 0 BEGIN
	INSERT INTO AP_PMT_HIST
		(AP_ID,
		AP_SEQ,
		BK_CODE,
		AP_CHK_NBR,
		CHK_SEQ,
		AP_CHK_DATE,
		AP_CHK_AMT,
		AP_DISC_AMT,
		AP_CHK_MAN,
		AP_CHK_HOLD_FLAG,
		AP_CHK_MAILED,
		AP_CHK_CLEAR_FLAG,
		GLACODE_CASH,
		GLACODE_DISC,
		GLACODE_AP,
		GLEXACT,
		GLESEQ_CASH,
		GLESEQ_DISC,
		GLESEQ_AP,
		POST_PERIOD,
		CREATE_DATE,
		USERID,
		VENDOR_SERVICE_TAX_ID,
		VENDOR_TAXABLE_AMOUNT,
		VENDOR_SERVICE_TAX,
		SERVICE_TAX_RATE,
		VENDOR_YTD_TAXABLE,
		TAXABLE_THRESHOLD,
		GLACODE_WH,
		GLESEQ_WH,

		EXCHANGE_AMOUNT_APPLIED,

		HOME_CURRENCY_CODE,
		BANK_CURRENCY_CODE,
		AP_CURRENCY_CODE,
		EXCHANGE_AMOUNT,

		GLACODE_CRNCY_UNREALIZED,

		FOREIGN_INV_AMOUNT,
		FOREIGN_SALES_TAX,

		EXCHANGE_DISC_AMOUNT	)
	SELECT 	AP_ID,
		AP_SEQ,
		BK_CODE,
		AP_CHK_NBR,
		CHK_SEQ,
		AP_CHK_DATE,
		AP_CHK_AMT,
		AP_DISC_AMT,
		AP_CHK_MAN,
		AP_CHK_HOLD_FLAG,
		AP_CHK_MAILED,
		AP_CHK_CLEAR_FLAG,
		GLACODE_CASH,
		GLACODE_DISC,
		GLACODE_AP,
		GLEXACT,
		GLESEQ_CASH,
		GLESEQ_DISC,
		GLESEQ_AP,
		POST_PERIOD,
		CREATE_DATE,
		USERID,
		VENDOR_SERVICE_TAX_ID,
		VENDOR_TAXABLE_AMOUNT,
		VENDOR_SERVICE_TAX,
		SERVICE_TAX_RATE,
		VENDOR_YTD_TAXABLE,
		TAXABLE_THRESHOLD,
		GLACODE_WH,
		GLESEQ_WH,

		EXCHANGE_AMOUNT_APPLIED,

		HOME_CURRENCY_CODE,
		BANK_CURRENCY_CODE,
		AP_CURRENCY_CODE,
		EXCHANGE_AMOUNT,

		GLACODE_CRNCY_UNREALIZED,

		FOREIGN_INV_AMOUNT,
		FOREIGN_SALES_TAX,

		EXCHANGE_DISC_AMOUNT
	FROM @ap_pmt_hist WHERE NEW_ROW = 1
END

IF @action = 'DEBUG' BEGIN
	SELECT DISTINCT '*GLH', A.* FROM GLENTHDR A JOIN (SELECT GLETXACT FROM @gl_detail_sum GROUP BY GLETXACT) B ON A.GLEHXACT = B.GLETXACT  
	SELECT '*GLD', * FROM GLENTTRL A JOIN (SELECT GLETXACT FROM @gl_detail_sum GROUP BY GLETXACT) B ON A.GLETXACT = B.GLETXACT  
END

IF @action = 'DEBUG'
	SELECT DISTINCT '*AP', A.CREATE_DATE, A.* FROM AP_PMT_HIST A 
			JOIN @ap_pmt_hist B ON A.AP_ID = B.AP_ID  AND A.AP_SEQ = B.AP_SEQ AND A.AP_CHK_NBR = B.AP_CHK_NBR --AND NEW_ROW = 1
	ORDER BY 3,4,5,6,7,8

IF @action = 'DEBUG'
	SELECT DISTINCT '*CHKR', A.* FROM CHECK_REGISTER A
		JOIN @ap_pmt_hist B ON A.BK_CODE = B.BK_CODE AND A.CHECK_NBR = B.AP_CHK_NBR --AND NEW_ROW = 1

--SELECT @ret_val, @ret_val_s

SET @ret_val = 0
SET @ret_val_s = 'ok'

IF @action = 'DEBUG'
	ROLLBACK TRAN 
ELSE
	COMMIT TRAN 
	--ROLLBACK TRAN 
	
GOTO ENDIT		

/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		ROLLBACK TRAN
	END
	
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	IF @error_msg_w IS NULL BEGIN
		SET @ret_val = @ErState
		SET @ret_val_s = @ErMessage
	END	

END CATCH

--SELECT @ret_val, @ret_val_s

RETURN

           
