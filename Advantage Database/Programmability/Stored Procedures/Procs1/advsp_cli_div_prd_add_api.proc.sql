IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_cli_div_prd_add_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_cli_div_prd_add_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_cli_div_prd_add_api] 
	@user_id varchar(100), 
	@action varchar(10), 

	@CL_CODE varchar(6),
	@CL_NAME varchar(40),
	@DIV_CODE varchar(6) = NULL,
	@DIV_NAME varchar(40) = NULL,
	@PRD_CODE varchar(6) = NULL,
	@PRD_DESCRIPTION varchar(40) = NULL,	
	@OFFICE_CODE varchar(4),
    @USER_DEFINED1 varchar(50) = NULL,
    @USER_DEFINED2 varchar(50) = NULL,
    @USER_DEFINED3 varchar(50) = NULL,
    @USER_DEFINED4 varchar(50) = NULL,
	@CL_ADDRESS1 varchar(40) = NULL,
	@CL_ADDRESS2 varchar(40) = NULL,
	@CL_CITY varchar(30) = NULL,
	@CL_COUNTY varchar(20) = NULL,
	@CL_STATE varchar(10) = NULL,
	@CL_COUNTRY varchar(20) = NULL,
	@CL_ZIP varchar(10) = NULL,
	@CL_TYPE1 varchar(100),
	@CL_TYPE2 varchar(100),
	@CL_TYPE3 varchar(100),

	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT
AS

/* Non-Required fields */

IF @OFFICE_CODE IN ('', '*') 
	SET @OFFICE_CODE = NULL

IF @USER_DEFINED1 IN ('', '*') 
	SET @USER_DEFINED1 = NULL

IF @USER_DEFINED2 IN ('', '*') 
	SET @USER_DEFINED2 = NULL

IF @USER_DEFINED3 IN ('', '*') 
	SET @USER_DEFINED3 = NULL

IF @USER_DEFINED4 IN ('', '*') 
	SET @USER_DEFINED4 = NULL

IF @USER_DEFINED1 IN ('', '*') 
	SET @USER_DEFINED1 = NULL

IF @CL_ADDRESS1 IN ('', '*') 
	SET @CL_ADDRESS1 = NULL

IF @CL_ADDRESS2 IN ('', '*') 
	SET @CL_ADDRESS2 = NULL

IF @CL_CITY IN ('', '*') 
	SET @CL_CITY = NULL

IF @CL_COUNTY IN ('', '*') 
	SET @CL_COUNTY = NULL

IF @CL_STATE IN ('', '*') 
	SET @CL_STATE = NULL

IF @CL_COUNTRY IN ('', '*') 
	SET @CL_COUNTRY = NULL

IF @CL_ZIP IN ('', '*') 
	SET @CL_ZIP = NULL

IF @CL_TYPE1 IN ('', '*') 
	SET @CL_TYPE1 = NULL

IF @CL_TYPE2 IN ('', '*') 
	SET @CL_TYPE2 = NULL

IF @CL_TYPE3 IN ('', '*') 
	SET @CL_TYPE3 = NULL

SET NOCOUNT ON

DECLARE @error_msg_w varchar(200)
DECLARE @date_time_w smalldatetime

DECLARE @DEBUG integer
DECLARE @RC integer
	,@RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048)
	,@ErSeverity integer
	,@ErState integer

DECLARE @row_count integer

DECLARE @add_comp bit, 
	@alert_group varchar(50)

DECLARE 	@CL_TYPE1_ID int,
	@CL_TYPE2_ID int,
	@CL_TYPE3_ID int


/* CLIENT */
DECLARE
	@CL_ALPHA_SORT varchar(20) = LEFT(@PRD_DESCRIPTION, 20),
	--@CL_ADDRESS1 varchar(40) = NULL,
	--@CL_ADDRESS2 varchar(40) = NULL,
	--@CL_CITY varchar(30) = NULL,
	--@CL_COUNTY varchar(20) = NULL,
	--@CL_STATE varchar(10) = NULL,
	--@CL_COUNTRY varchar(20) = NULL,
	--@CL_ZIP varchar(10) = NULL,
	@CL_CREDIT_LIMIT decimal(15,2) = 0,

	@CL_INV_BY smallint = 1,  /* By Job */

	@CL_MINV_BY smallint = 1, /* By Sales Class */

	@ACTIVE_FLAG smallint = 1,
	@NEW_BUSINESS smallint = 0,
	@CMP_CODE_R smallint = 0,
	@ACCT_NBR_R smallint = 0,
	@JT_CODE_R smallint = 0,
	@PROMO_CODE_R smallint = 0,
	@REQ_FLDS smallint = 0,
	@JOB_FIRST_USE_DT_R smallint = 0,
	@COMPLEX_CODE_R smallint = 0,
	@FORMAT_SC_CODE_R smallint = 0,
	@DP_TM_CODE_R smallint = 0,
	@MARKET_CODE_R smallint = 0,
	@EMAIL_GR_CODE_R smallint = 0,
	@BILL_COOP_CODE_R smallint = 0,
	@AD_NBR_R smallint = 0,
	@JOB_CLI_REF_R smallint = 0,
	@JOB_DATE_OPENED_R smallint = 0,
	@JOB_AD_SIZE_R smallint = 0,
	@PROD_CONT_CODE_R smallint = 0,
	@JOB_COMP_BUDGET_R smallint = 0,

	@JOB_LOG_UDV1_R smallint = 0,
	@JOB_LOG_UDV2_R smallint = 0,
	@JOB_LOG_UDV3_R smallint = 0,
	@JOB_LOG_UDV4_R smallint = 0,
	@JOB_LOG_UDV5_R smallint = 0,
	@JOB_CMP_UDV1_R smallint = 0,
	@JOB_CMP_UDV2_R smallint = 0,
	@JOB_CMP_UDV3_R smallint = 0,
	@JOB_CMP_UDV4_R smallint = 0,
	@JOB_CMP_UDV5_R smallint = 0,

	@REQ_PROD_CAT smallint = 0,

	@FISCAL_PD_R smallint = 0,
	@BLACKPLATE_VER_R smallint = 0,
	@BLACKPLATE_VER2_R smallint = 0,
	@CL_P_PAYDAYS smallint = 0,
	@CL_M_PAYDAYS smallint = 0,
	@SERVICE_FEE_TYPE_R smallint = 0,
	@CONTRACT_EXP_DT smalldatetime = @date_time_w,
	@REQ_TIME_COMMENT bit = 0,

	@INV_BY_JOB_ON_NULL bit = 0,

	@AVALARA_TAX_EXEMPT bit = 0,
	@COMBO_INV_BY smallint = NULL,
	@COMBO_MEDIA_ONLY bit = 0

/* DIVISION */
DECLARE
	@DIV_ALPHA_SORT varchar(20) = LEFT(@DIV_NAME, 20),
	@DIV_ACTIVE_FLAG smallint = 1


/* PRODUCT */
DECLARE
	@PRD_ALPHA_SORT varchar(20) = LEFT(@PRD_DESCRIPTION, 20),
	--@OFFICE_CODE varchar(4),
	@PRD_CONSOL_FUNC smallint = 0,
	@PRD_CONT_PCT decimal(7,3) = 0,
	@PRD_PROD_MARKUP decimal(7,3) = 0,

	@PRD_PROD_BILL_NET smallint = 0,
	@PRD_PROD_VEN_DISC smallint = 0,
	@PRD_PROD_ESTIMATE smallint = 0,

	@PRD_RADIO_REBATE decimal(7,3) = 0,
	@PRD_RADIO_BILL_NET smallint = 0,
	@PRD_RADIO_VEN_DISC smallint = 0,
	@PRD_RADIO_COM_ONLY smallint = 0,

	@PRD_RADIO_DAYS smallint = 0,
	@PRD_RADIO_PRE_POST smallint = 1,
	@PRD_RADIO_BF_AF smallint = 1,
	@PRD_TV_REBATE decimal(7,3) = 0,
	@PRD_TV_BILL_NET smallint = 0,
	@PRD_TV_VEN_DISC smallint = 0,
	@PRD_TV_COM_ONLY smallint = 0,

	@PRD_TV_DAYS smallint = 0,
	@PRD_TV_PRE_POST smallint = 1,
	@PRD_TV_BF_AF smallint = 1,
	@PRD_MAG_REBATE decimal(7,3) = 0,
	@PRD_MAG_BILL_NET smallint = 0,
	@PRD_MAG_VEN_DISC smallint = 0,
	@PRD_MAG_COM_ONLY smallint = 0,

	@PRD_MAG_DAYS smallint = 0,
	@PRD_MAG_PRE_POST smallint = 1,
	@PRD_MAG_BF_AF smallint = 1,
	@PRD_NEWS_COMM decimal(7,3) = 0,
	@PRD_NEWS_BILL_NET smallint = 0,
	@PRD_NEWS_VEN_DISC smallint = 0,
	@PRD_NEWS_COM_ONLY smallint = 0,

	@PRD_NEWS_DAYS smallint = 0,
	@PRD_NEWS_PRE_POST smallint = 1,
	@PRD_NEWS_BF_AF smallint = 1,

	@PRD_NEWS_REBATE decimal(7,3) = 0,
	@PRD_OTDR_REBATE decimal(7,3) = 0,
	@PRD_MISC_REBATE decimal(7,3) = 0,
	@PRD_RADIO_COMM decimal(7,3) = 0,
	@PRD_TV_COMM decimal(7,3) = 0,
	@PRD_MAG_COMM decimal(7,3) = 0,
	@PRD_OTDR_COMM decimal(7,3) = 0,
	@PRD_MISC_COMM decimal(7,3) = 0,
	@PRD_OTDR_BF_AF smallint = 2,
	@PRD_OTDR_BILL_NET smallint = 0,
	@PRD_OTDR_COM_ONLY smallint = 0,
	@PRD_OTDR_DAYS smallint = 0,
	@PRD_OTDR_PRE_POST smallint = 1,

	@PRD_OTDR_VEN_DISC smallint = 0,
	@PRD_MISC_BF_AF smallint = 1,
	@PRD_MISC_BILL_NET smallint = 0,
	@PRD_MISC_COM_ONLY smallint = 0,
	@PRD_MISC_DAYS smallint = 0,
	@PRD_MISC_PRE_POST smallint = 1,

	@PRD_MISC_VEN_DISC smallint = 0,

	@INACTIVE smallint = NULL,
	@PRD_ACTIVE_FLAG smallint = 1,
    --@USER_DEFINED1 varchar(50),
    --@USER_DEFINED2 varchar(50),
    --@USER_DEFINED3 varchar(50),
    --@USER_DEFINED4 varchar(50),

	@USE_TAX_FLAGS_R smallint = 0,
	@TAXAPPLYLN_R smallint = 0,
	@TAXAPPLYND_R smallint = 0,
	@TAXAPPLYNC_R smallint = 0,
	@TAXAPPLYAI_R smallint = 0,
	@TAXAPPLYC_R smallint = 0,
	@TAXAPPLYR_R smallint = 0,
	@USE_TAX_FLAGS_T smallint = 0,
	@TAXAPPLYLN_T smallint = 0,
	@TAXAPPLYND_T smallint = 0,
	@TAXAPPLYNC_T smallint = 0,
	@TAXAPPLYAI_T smallint = 0,
	@TAXAPPLYC_T smallint = 0,
	@TAXAPPLYR_T smallint = 0,
	@USE_TAX_FLAGS_M smallint = 0,
	@TAXAPPLYLN_M smallint = 0,
	@TAXAPPLYND_M smallint = 0,
	@TAXAPPLYNC_M smallint = 0,
	@TAXAPPLYAI_M smallint = 0,
	@TAXAPPLYC_M smallint = 0,
	@TAXAPPLYR_M smallint = 0,
	@USE_TAX_FLAGS_N smallint = 0,
	@TAXAPPLYLN_N smallint = 0,
	@TAXAPPLYND_N smallint = 0,
	@TAXAPPLYNC_N smallint = 0,
	@TAXAPPLYAI_N smallint = 0,
	@TAXAPPLYC_N smallint = 0,
	@TAXAPPLYR_N smallint = 0,
	@USE_TAX_FLAGS_O smallint = 0,
	@TAXAPPLYLN_O smallint = 0,
	@TAXAPPLYND_O smallint = 0,
	@TAXAPPLYNC_O smallint = 0,
	@TAXAPPLYAI_O smallint = 0,
	@TAXAPPLYC_O smallint = 0,
	@TAXAPPLYR_O smallint = 0,
	@USE_TAX_FLAGS_I smallint = 0,
	@TAXAPPLYLN_I smallint = 0,
	@TAXAPPLYND_I smallint = 0,
	@TAXAPPLYNC_I smallint = 0,
	@TAXAPPLYAI_I smallint = 0,
	@TAXAPPLYC_I smallint = 0,
	@TAXAPPLYR_I smallint = 0,

	@PRD_BILL_EMP_TIME smallint = 0,
	@PROD_SETUP_COMPLETE smallint = 0,
	@RADIO_SETUP_COMPLETE smallint = 0,
	@TV_SETUP_COMPLETE smallint = 0,
	@MAG_SETUP_COMPLETE smallint = 0,
	@NEWS_SETUP_COMPLETE smallint = 0,
	@OOH_SETUP_COMPLETE smallint = 0,
	@INET_SETUP_COMPLETE smallint = 0,
	@USE_EST_BILL_RATE smallint = 0

/* COMPANY_PROFILE */
DECLARE 
	@CASE_STUDY bit = 0,
	@REFERENCE  bit = 0

DECLARE
	@new_client bit = 0,
	@new_division bit = 0,
	@new_product bit = 0

SET @add_comp = 1

BEGIN TRAN

BEGIN TRY
	IF @action = 'DEBUG'
		SET @DEBUG = 1
	ELSE
		SET @DEBUG = 0

	IF @user_id IS NULL
	BEGIN
		SET @error_msg_w = 'Invalid User ID.'

		GOTO ERROR_MSG
	END

	SELECT @date_time_w = GETDATE()

	SET @ret_val = 0
	SET @ret_val_s = 'Success...'

SELECT @date_time_w = GETDATE()

	IF @CL_CODE IS NULL
	BEGIN
		-- Invalid/Closed Client
		SET @error_msg_w = 'Invalid Client Code.'
		GOTO ERROR_MSG
	END	

	IF @CL_NAME IS NULL
	BEGIN
		-- Invalid/Closed Client
		SET @error_msg_w = 'Invalid Client Name.'
		GOTO ERROR_MSG
	END	

	IF @DIV_CODE IS NULL
		SET @DIV_CODE = @CL_CODE

	IF @DIV_NAME IS NULL
		SET @DIV_NAME = @CL_NAME

	IF @PRD_CODE IS NULL
		SET @PRD_CODE = @CL_CODE

	IF @PRD_DESCRIPTION IS NULL
		SET @PRD_DESCRIPTION = @CL_NAME



	BEGIN
		-- Validate Office
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.OFFICE WHERE OFFICE_CODE = @office_code AND ( INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0 ))

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Office
			SET @error_msg_w = 'Invalid Office Code.'
			GOTO ERROR_MSG
		END	
	END

	/* AND ( ACTIVE_FLAG = 1 ) */

	BEGIN
		-- Validate Client
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.CLIENT WHERE CL_CODE = @CL_CODE )

		IF @row_count = 0
		BEGIN
			SET @new_client = 1
			SET @new_division = 1
			SET @new_product = 1
		END

	END

	IF @new_division = 0
	BEGIN
		-- Validate Division
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.DIVISION WHERE CL_CODE = @CL_CODE AND DIV_CODE = @DIV_CODE )

		IF @row_count = 0
		BEGIN
			SET @new_division = 1
			SET @new_product = 1
		END

	END

	IF @new_product = 0
	BEGIN
		-- Validate Product
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.PRODUCT WHERE  CL_CODE = @CL_CODE AND DIV_CODE = @DIV_CODE AND PRD_CODE = @PRD_CODE )

		IF @row_count = 0
			SET @new_product = 1
		ELSE
		BEGIN
			SET @error_msg_w = 'Duplicate Client/Division/Product.'
			GOTO ERROR_MSG
		END	
	END

	IF @new_client = 1
	INSERT INTO [dbo].[CLIENT]
			   ( [CL_CODE]
				,[CL_NAME]
				,[CL_ADDRESS1]
				,[CL_ADDRESS2]
				,[CL_CITY]
				,[CL_COUNTY]
				,[CL_STATE]
				,[CL_COUNTRY]
				,[CL_ZIP]

				,[CL_BADDRESS1]
				,[CL_BADDRESS2]
				,[CL_BCITY]
				,[CL_BCOUNTY]
				,[CL_BSTATE]
				,[CL_BCOUNTRY]
				,[CL_BZIP]

				,[CL_ALPHA_SORT]
				,[CL_CREDIT_LIMIT]
				,[CL_INV_BY] 
				,[CL_MINV_BY]  
				,[ACTIVE_FLAG]
				,[NEW_BUSINESS]
				,[CMP_CODE_R]
				,[ACCT_NBR_R]
				,[JT_CODE_R]
				,[PROMO_CODE_R]
				,[REQ_FLDS]
				,[JOB_FIRST_USE_DT_R]
				,[COMPLEX_CODE_R]
				,[FORMAT_SC_CODE_R]
				,[DP_TM_CODE_R]
				,[MARKET_CODE_R]
				,[EMAIL_GR_CODE_R]
				,[BILL_COOP_CODE_R]
				,[AD_NBR_R]
				,[JOB_CLI_REF_R]
				,[JOB_DATE_OPENED_R]
				,[JOB_AD_SIZE_R]
				,[PROD_CONT_CODE_R]
				,[JOB_COMP_BUDGET_R]
				,[JOB_LOG_UDV1_R]
				,[JOB_LOG_UDV2_R]
				,[JOB_LOG_UDV3_R]
				,[JOB_LOG_UDV4_R]
				,[JOB_LOG_UDV5_R]
				,[JOB_CMP_UDV1_R]
				,[JOB_CMP_UDV2_R]
				,[JOB_CMP_UDV3_R]
				,[JOB_CMP_UDV4_R]
				,[JOB_CMP_UDV5_R]  
				,[REQ_PROD_CAT]   
				,[FISCAL_PD_R]
				,[BLACKPLATE_VER_R]
				,[BLACKPLATE_VER2_R]
				,[CL_P_PAYDAYS]
				,[CL_M_PAYDAYS]
				,[SERVICE_FEE_TYPE_R]
				,[CONTRACT_EXP_DT]
				,[REQ_TIME_COMMENT]  
				,[INV_BY_JOB_ON_NULL]
				,[AVALARA_TAX_EXEMPT]
				,[COMBO_INV_BY]
				,[COMBO_MEDIA_ONLY]
				)
		 VALUES
				(
				@CL_CODE,
				@CL_NAME,
				@CL_ADDRESS1,
				@CL_ADDRESS2,
				@CL_CITY,
				@CL_COUNTY,
				@CL_STATE,
				@CL_COUNTRY,
				@CL_ZIP,

				@CL_ADDRESS1,
				@CL_ADDRESS2,
				@CL_CITY,
				@CL_COUNTY,
				@CL_STATE,
				@CL_COUNTRY,
				@CL_ZIP,

				@CL_ALPHA_SORT,
				@CL_CREDIT_LIMIT,
				@CL_INV_BY,  /* By Job */
				@CL_MINV_BY, /* By Sales Class */
				@ACTIVE_FLAG,
				@NEW_BUSINESS,
				@CMP_CODE_R,
				@ACCT_NBR_R,
				@JT_CODE_R,
				@PROMO_CODE_R,
				@REQ_FLDS,
				@JOB_FIRST_USE_DT_R,
				@COMPLEX_CODE_R,
				@FORMAT_SC_CODE_R,
				@DP_TM_CODE_R,
				@MARKET_CODE_R,
				@EMAIL_GR_CODE_R,
				@BILL_COOP_CODE_R,
				@AD_NBR_R,
				@JOB_CLI_REF_R,
				@JOB_DATE_OPENED_R,
				@JOB_AD_SIZE_R,
				@PROD_CONT_CODE_R,
				@JOB_COMP_BUDGET_R,
				@JOB_LOG_UDV1_R,
				@JOB_LOG_UDV2_R,
				@JOB_LOG_UDV3_R,
				@JOB_LOG_UDV4_R,
				@JOB_LOG_UDV5_R,
				@JOB_CMP_UDV1_R,
				@JOB_CMP_UDV2_R,
				@JOB_CMP_UDV3_R,
				@JOB_CMP_UDV4_R,
				@JOB_CMP_UDV5_R,
				@REQ_PROD_CAT,
				@FISCAL_PD_R,
				@BLACKPLATE_VER_R,
				@BLACKPLATE_VER2_R,
				@CL_P_PAYDAYS,
				@CL_M_PAYDAYS,
				@SERVICE_FEE_TYPE_R,
				@CONTRACT_EXP_DT,
				@REQ_TIME_COMMENT,
				@INV_BY_JOB_ON_NULL,
				@AVALARA_TAX_EXEMPT,
				@COMBO_INV_BY,
				@COMBO_MEDIA_ONLY
				)

	IF @new_division = 1
	INSERT INTO [dbo].[DIVISION]
			   (
				CL_CODE,
				DIV_CODE,
				DIV_NAME,
				DIV_ALPHA_SORT,
				ACTIVE_FLAG,

				DIV_BADDRESS1,
				DIV_BADDRESS2,
				DIV_BCITY,
				DIV_BCOUNTY,
				DIV_BSTATE,
				DIV_BCOUNTRY,
				DIV_BZIP,

				DIV_SADDRESS1,
				DIV_SADDRESS2,
				DIV_SCITY,
				DIV_SCOUNTY,
				DIV_SSTATE,
				DIV_SCOUNTRY,
				DIV_SZIP

			   )
	VALUES
				(
				@CL_CODE,
				@DIV_CODE,
				@DIV_NAME,
				@DIV_ALPHA_SORT,
				@DIV_ACTIVE_FLAG,

				@CL_ADDRESS1,
				@CL_ADDRESS2,
				@CL_CITY,
				@CL_COUNTY,
				@CL_STATE,
				@CL_COUNTRY,
				@CL_ZIP,

				@CL_ADDRESS1,
				@CL_ADDRESS2,
				@CL_CITY,
				@CL_COUNTY,
				@CL_STATE,
				@CL_COUNTRY,
				@CL_ZIP
				)

	IF @new_product = 1
	INSERT INTO [dbo].[PRODUCT]
				([CL_CODE]
				,[DIV_CODE]
				,[PRD_CODE]
				,[PRD_DESCRIPTION]

				,[PRD_BILL_ADDRESS1]
				,[PRD_BILL_ADDRESS2]
				,[PRD_BILL_CITY]
				,[PRD_BILL_COUNTY]
				,[PRD_BILL_STATE]
				,[PRD_BILL_COUNTRY]
				,[PRD_BILL_ZIP]

				,[PRD_STATE_ADDR1]
				,[PRD_STATE_ADDR2]
				,[PRD_STATE_CITY]
				,[PRD_STATE_COUNTY]
				,[PRD_STATE_STATE]
				,[PRD_STATE_COUNTRY]
				,[PRD_STATE_ZIP]

				,[PRD_ALPHA_SORT]
				,[OFFICE_CODE]
				,[PRD_CONSOL_FUNC]
				,[PRD_CONT_PCT]
				,[PRD_PROD_MARKUP]

				,[PRD_PROD_BILL_NET]
				,[PRD_PROD_VEN_DISC]
				,[PRD_PROD_ESTIMATE]

				,[PRD_RADIO_REBATE]
				,[PRD_RADIO_BILL_NET]
				,[PRD_RADIO_VEN_DISC]
				,[PRD_RADIO_COM_ONLY]

				,[PRD_RADIO_DAYS]
				,[PRD_RADIO_PRE_POST]
				,[PRD_RADIO_BF_AF]
				,[PRD_TV_REBATE]
				,[PRD_TV_BILL_NET]
				,[PRD_TV_VEN_DISC]
				,[PRD_TV_COM_ONLY]

				,[PRD_TV_DAYS]
				,[PRD_TV_PRE_POST]
				,[PRD_TV_BF_AF]
				,[PRD_MAG_REBATE]
				,[PRD_MAG_BILL_NET]
				,[PRD_MAG_VEN_DISC]
				,[PRD_MAG_COM_ONLY]

				,[PRD_MAG_DAYS]
				,[PRD_MAG_PRE_POST]
				,[PRD_MAG_BF_AF]
				,[PRD_NEWS_COMM]
				,[PRD_NEWS_BILL_NET]
				,[PRD_NEWS_VEN_DISC]
				,[PRD_NEWS_COM_ONLY]

				,[PRD_NEWS_DAYS]
				,[PRD_NEWS_PRE_POST]
				,[PRD_NEWS_BF_AF]

				,[PRD_NEWS_REBATE]
				,[PRD_OTDR_REBATE]
				,[PRD_MISC_REBATE]
				,[PRD_RADIO_COMM]
				,[PRD_TV_COMM]
				,[PRD_MAG_COMM]
				,[PRD_OTDR_COMM]
				,[PRD_MISC_COMM]
				,[PRD_OTDR_BF_AF]
				,[PRD_OTDR_BILL_NET]
				,[PRD_OTDR_COM_ONLY]
				,[PRD_OTDR_DAYS]
				,[PRD_OTDR_PRE_POST]

				,[PRD_OTDR_VEN_DISC]
				,[PRD_MISC_BF_AF]
				,[PRD_MISC_BILL_NET]
				,[PRD_MISC_COM_ONLY]
				,[PRD_MISC_DAYS]
				,[PRD_MISC_PRE_POST]

				,[PRD_MISC_VEN_DISC]

				,[INACTIVE]
				,[ACTIVE_FLAG]
				,[USER_DEFINED1]
				,[USER_DEFINED2]
				,[USER_DEFINED3]
				,[USER_DEFINED4]

				,[USE_TAX_FLAGS_R]
				,[TAXAPPLYLN_R]
				,[TAXAPPLYND_R]
				,[TAXAPPLYNC_R]
				,[TAXAPPLYAI_R]
				,[TAXAPPLYC_R]
				,[TAXAPPLYR_R]
				,[USE_TAX_FLAGS_T]
				,[TAXAPPLYLN_T]
				,[TAXAPPLYND_T]
				,[TAXAPPLYNC_T]
				,[TAXAPPLYAI_T]
				,[TAXAPPLYC_T]
				,[TAXAPPLYR_T]
				,[USE_TAX_FLAGS_M]
				,[TAXAPPLYLN_M]
				,[TAXAPPLYND_M]
				,[TAXAPPLYNC_M]
				,[TAXAPPLYAI_M]
				,[TAXAPPLYC_M]
				,[TAXAPPLYR_M]
				,[USE_TAX_FLAGS_N]
				,[TAXAPPLYLN_N]
				,[TAXAPPLYND_N]
				,[TAXAPPLYNC_N]
				,[TAXAPPLYAI_N]
				,[TAXAPPLYC_N]
				,[TAXAPPLYR_N]
				,[USE_TAX_FLAGS_O]
				,[TAXAPPLYLN_O]
				,[TAXAPPLYND_O]
				,[TAXAPPLYNC_O]
				,[TAXAPPLYAI_O]
				,[TAXAPPLYC_O]
				,[TAXAPPLYR_O]
				,[USE_TAX_FLAGS_I]
				,[TAXAPPLYLN_I]
				,[TAXAPPLYND_I]
				,[TAXAPPLYNC_I]
				,[TAXAPPLYAI_I]
				,[TAXAPPLYC_I]
				,[TAXAPPLYR_I]
				,[PROD_SETUP_COMPLETE]
				,[RADIO_SETUP_COMPLETE]
				,[TV_SETUP_COMPLETE]
				,[MAG_SETUP_COMPLETE]
				,[NEWS_SETUP_COMPLETE]
				,[OOH_SETUP_COMPLETE]
				,[INET_SETUP_COMPLETE]
				,[USE_EST_BILL_RATE]
				)
	  VALUES
			   (
				@CL_CODE,
				@DIV_CODE,
				@PRD_CODE,
				@PRD_DESCRIPTION,

				@CL_ADDRESS1,
				@CL_ADDRESS2,
				@CL_CITY,
				@CL_COUNTY,
				@CL_STATE,
				@CL_COUNTRY,
				@CL_ZIP,

				@CL_ADDRESS1,
				@CL_ADDRESS2,
				@CL_CITY,
				@CL_COUNTY,
				@CL_STATE,
				@CL_COUNTRY,
				@CL_ZIP,

				@PRD_ALPHA_SORT,
				@OFFICE_CODE,
				@PRD_CONSOL_FUNC,
				@PRD_CONT_PCT,
				@PRD_PROD_MARKUP,

				@PRD_PROD_BILL_NET,
				@PRD_PROD_VEN_DISC,
				@PRD_PROD_ESTIMATE,

				@PRD_RADIO_REBATE,
				@PRD_RADIO_BILL_NET,
				@PRD_RADIO_VEN_DISC,
				@PRD_RADIO_COM_ONLY,

				@PRD_RADIO_DAYS,
				@PRD_RADIO_PRE_POST,
				@PRD_RADIO_BF_AF,
				@PRD_TV_REBATE,
				@PRD_TV_BILL_NET,
				@PRD_TV_VEN_DISC,
				@PRD_TV_COM_ONLY,

				@PRD_TV_DAYS,
				@PRD_TV_PRE_POST,
				@PRD_TV_BF_AF,
				@PRD_MAG_REBATE,
				@PRD_MAG_BILL_NET,
				@PRD_MAG_VEN_DISC,
				@PRD_MAG_COM_ONLY,

				@PRD_MAG_DAYS,
				@PRD_MAG_PRE_POST,
				@PRD_MAG_BF_AF,
				@PRD_NEWS_COMM,
				@PRD_NEWS_BILL_NET,
				@PRD_NEWS_VEN_DISC,
				@PRD_NEWS_COM_ONLY,

				@PRD_NEWS_DAYS,
				@PRD_NEWS_PRE_POST,
				@PRD_NEWS_BF_AF,

				@PRD_NEWS_REBATE,
				@PRD_OTDR_REBATE,
				@PRD_MISC_REBATE,
				@PRD_RADIO_COMM,
				@PRD_TV_COMM,
				@PRD_MAG_COMM,
				@PRD_OTDR_COMM,
				@PRD_MISC_COMM,
				@PRD_OTDR_BF_AF,
				@PRD_OTDR_BILL_NET,
				@PRD_OTDR_COM_ONLY,
				@PRD_OTDR_DAYS,
				@PRD_OTDR_PRE_POST,

				@PRD_OTDR_VEN_DISC,
				@PRD_MISC_BF_AF,
				@PRD_MISC_BILL_NET,
				@PRD_MISC_COM_ONLY,
				@PRD_MISC_DAYS,
				@PRD_MISC_PRE_POST,

				@PRD_MISC_VEN_DISC,

				@INACTIVE,
				@ACTIVE_FLAG,
				@USER_DEFINED1,
				@USER_DEFINED2,
				@USER_DEFINED3,
				@USER_DEFINED4,

				@USE_TAX_FLAGS_R,
				@TAXAPPLYLN_R,
				@TAXAPPLYND_R,
				@TAXAPPLYNC_R,
				@TAXAPPLYAI_R,
				@TAXAPPLYC_R,
				@TAXAPPLYR_R,
				@USE_TAX_FLAGS_T,
				@TAXAPPLYLN_T,
				@TAXAPPLYND_T,
				@TAXAPPLYNC_T,
				@TAXAPPLYAI_T,
				@TAXAPPLYC_T,
				@TAXAPPLYR_T,
				@USE_TAX_FLAGS_M,
				@TAXAPPLYLN_M,
				@TAXAPPLYND_M,
				@TAXAPPLYNC_M,
				@TAXAPPLYAI_M,
				@TAXAPPLYC_M,
				@TAXAPPLYR_M,
				@USE_TAX_FLAGS_N,
				@TAXAPPLYLN_N,
				@TAXAPPLYND_N,
				@TAXAPPLYNC_N,
				@TAXAPPLYAI_N,
				@TAXAPPLYC_N,
				@TAXAPPLYR_N,
				@USE_TAX_FLAGS_O,
				@TAXAPPLYLN_O,
				@TAXAPPLYND_O,
				@TAXAPPLYNC_O,
				@TAXAPPLYAI_O,
				@TAXAPPLYC_O,
				@TAXAPPLYR_O,
				@USE_TAX_FLAGS_I,
				@TAXAPPLYLN_I,
				@TAXAPPLYND_I,
				@TAXAPPLYNC_I,
				@TAXAPPLYAI_I,
				@TAXAPPLYC_I,
				@TAXAPPLYR_I,
				@PROD_SETUP_COMPLETE,
				@RADIO_SETUP_COMPLETE,
				@TV_SETUP_COMPLETE,
				@MAG_SETUP_COMPLETE,
				@NEWS_SETUP_COMPLETE,
				@OOH_SETUP_COMPLETE,
				@INET_SETUP_COMPLETE,
				@USE_EST_BILL_RATE
			   )
	
	/* Client Types */
	IF @CL_TYPE1 IS NOT NULL
	BEGIN
		SELECT @CL_TYPE1_ID = ( SELECT CLIENT_TYPE1_ID FROM dbo.CLIENT_TYPE1 WHERE [DESCRIPTION] = @CL_TYPE1)

		IF @CL_TYPE1_ID IS NULL
		BEGIN
			SET @error_msg_w = 'Invalid Type 1.'
			GOTO ERROR_MSG
		END	
	END

	IF @CL_TYPE2 IS NOT NULL
	BEGIN
		SELECT @CL_TYPE2_ID = ( SELECT CLIENT_TYPE2_ID FROM dbo.CLIENT_TYPE2 WHERE [DESCRIPTION] = @CL_TYPE2)

		IF @CL_TYPE2_ID IS NULL
		BEGIN
			SET @error_msg_w = 'Invalid Type 2.'
			GOTO ERROR_MSG
		END	
	END

	IF @CL_TYPE3 IS NOT NULL
	BEGIN
		SELECT @CL_TYPE3_ID = ( SELECT CLIENT_TYPE3_ID FROM dbo.CLIENT_TYPE3 WHERE [DESCRIPTION] = @CL_TYPE3)

		IF @CL_TYPE3_ID IS NULL
		BEGIN
			SET @error_msg_w = 'Invalid Type 3.'
			GOTO ERROR_MSG
		END	
	END

	SELECT @CL_TYPE1 '@CL_TYPE1', @CL_TYPE2 '@CL_TYPE2', @CL_TYPE3 '@CL_TYPE3'

	SELECT @row_count = ( SELECT COUNT(*) FROM dbo.COMPANY_PROFILE 
										WHERE  CL_CODE = @CL_CODE AND DIV_CODE = @DIV_CODE AND PRD_CODE = @PRD_CODE AND INDUSTRY_ID IS NULL AND SPECIALTY_ID IS NULL )

	/* Should not exist already since this we must have at least a new Product */
	IF @row_count = 0
	INSERT INTO dbo.COMPANY_PROFILE
			   ([CL_CODE]
			   ,[DIV_CODE]
			   ,[PRD_CODE]
			   --,[INDUSTRY_ID]
			   --,[SPECIALTY_ID]
			   --,[REGION_CODE]
			   --,[REVENUE]
			   --,[NUM_EMPLOYEES]
			   ,[CASE_STUDY]
			   ,[REFERENCE]
			   ,[NOTES]
			   ,[CREATED_BY]
			   ,[CREATE_DATE]
			   ,[MODIFIED_BY]
			   ,[MODIFIED_DATE]
			   --,[TURNOVER_PERCENT]
			   ,[CLIENT_TYPE1_ID]
			   ,[CLIENT_TYPE2_ID]
			   ,[CLIENT_TYPE3_ID])
		 VALUES
			   (@CL_CODE
			   ,@DIV_CODE
			   ,@PRD_CODE
			   --,@INDUSTRY_ID
			   --,@SPECIALTY_ID
			   --,@REGION_CODE
			   --,@REVENUE
			   --,@NUM_EMPLOYEES
			   ,@CASE_STUDY
			   ,@REFERENCE
			   ,'Inserted from API' --@NOTES
			   ,@user_id --@CREATED_BY
			   ,@date_time_w
			   ,@user_id
			   ,@date_time_w
			   --,@TURNOVER_PERCENT
			   ,@CL_TYPE1_ID
			   ,@CL_TYPE2_ID
			   ,@CL_TYPE3_ID)

	IF @@TRANCOUNT > 0
		IF @DEBUG = 1
		BEGIN
			SELECT 'DEBUG' 'DESC'
				,@user_id '@user_id'
				,@date_time_w '@date_time_w'

			SET @error_msg_w = 'DEBUG - ROLLBACK'

			GOTO ERROR_MSG
		END
	GOTO ENDIT

	/**************************** ERROR PROCESSING ***************************/
	ERROR_MSG:

	BEGIN
		SET @ret_val = - 1

		RAISERROR (
				@error_msg_w
				,16
				,1
				)
	END

	ENDIT: --Do Nothing
END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
		SELECT 'PROCESS ERROR ROLLBACK'
			,@@TRANCOUNT '@@TRANCOUNT' /* DEBUG */
	END

	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	SELECT @ErMessage = ERROR_MESSAGE()
		,@ErSeverity = ERROR_SEVERITY()
		,@ErState = ERROR_STATE();

	SELECT @ErMessage 'ERROR_MESSAGE'
		,@ErSeverity 'ERROR_SEVERITY'
		,@ErState 'ERROR_SATE' /* DEBUG */

	--IF @ret_val <> 0
	IF @ErMessage IS NOT NULL
	BEGIN
		SET @ret_val = 1
		SET @ret_val_s = @ErMessage
	END

END CATCH

IF @DEBUG = 1 
BEGIN
	SELECT 'CLIENT' 'SRC', * FROM CLIENT WHERE CL_CODE = @CL_CODE
	SELECT 'DIVISION' 'SRC', * FROM DIVISION WHERE CL_CODE = @CL_CODE
	SELECT 'PRODUCT' 'SRC', * FROM PRODUCT WHERE CL_CODE = @CL_CODE
	SELECT 'COMPANY_PROFILE' 'SRC', * FROM COMPANY_PROFILE WHERE  CL_CODE = @CL_CODE AND DIV_CODE = @DIV_CODE AND PRD_CODE = @PRD_CODE 
END


/**************************************************/
--ROLLBACK TRANSACTION - Handle in Calling process
/**************************************************/

IF @ret_val = 0
	COMMIT TRAN
ELSE
	ROLLBACK TRAN

RETURN
GO

GRANT EXECUTE ON [advsp_cli_div_prd_add_api] TO PUBLIC AS dbo
GO