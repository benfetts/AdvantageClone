
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advtf_med_get_prd_defaults]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[advtf_med_get_prd_defaults]
GO

/****** Object:  UserDefinedFunction [dbo].[advtf_med_get_prd_defaults]    Script Date: 05/15/2015 16:07:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--If (is_action = 'SETUP' Or is_action = 'NEW' Or is_action = 'COPY

/* 
advtf_med_get_prd_defaults( @cl_code, @div_code, @prd_code, @order_type, @action)

WHERE @action = 'SETUP' Or @action = 'NEW' Or @action = 'COPY
*/

CREATE FUNCTION [dbo].[advtf_med_get_prd_defaults] (
		@cl_code	varchar (6), 
		@div_code	varchar (6),
		@prd_code	varchar (6),
		@order_type varchar (2),
		@sc_code varchar(6),
		@action  varchar(10))
	RETURNS @med_billed TABLE ( 
		[PRD_COMM] [decimal](7, 3) NOT NULL,
		[SC_MARKUP] [decimal](7, 3) NULL, /*Not used at this time */
		[PRD_REBATE] [decimal](7, 3) NOT NULL,
		[PRD_BILL_NET] [smallint] NOT NULL,
		[PRD_VEN_DISC] [smallint] NULL,
		[PRD_COM_ONLY] [smallint] NOT NULL,
		[PRD_TAX_CODE] [varchar](4) NULL,
		[PRD_DAYS] [smallint] NULL,
		[PRD_PRE_POST] [smallint] NULL,
		[PRD_BF_AF] [smallint] NULL,
		[USE_TAX_FLAGS] [smallint] NULL,
		[PRD_BILL_TYPE] [smallint] NULL,
		[TAXAPPLYLN] [smallint] NULL,
		[TAXAPPLYND] [smallint] NULL,
		[TAXAPPLYNC] [smallint] NULL,
		[TAXAPPLYAI] [smallint] NULL,
		[TAXAPPLYC] [smallint] NULL,
		[TAXAPPLYR] [smallint] NULL,
		[OFFICE_CODE] varchar(6) NOT NULL
		)
AS
BEGIN
	--DECLARE @taxapplyln_p smallint, @taxapplynd_p smallint, @taxapplync_p smallint, @taxapplyai_p smallint, @taxapplyc_p smallint, @taxapplyr_p smallint
	--DECLARE @markup_pct_p decimal(7, 3), @comm_pct_p decimal(7, 3), @rebate_pct_p decimal(7, 3)
	--DECLARE @prd_bill_days smallint, @prd_bf_af smallint
	--DECLARE @tax_code_p varchar(4), @use_tax_flags_p smallint, @sales_tax_p varchar(6)

	IF @order_type =  'NP'
	BEGIN
	INSERT INTO @med_billed (PRD_REBATE,
						PRD_COMM,
						PRD_TAX_CODE, PRD_COM_ONLY,
						PRD_BILL_NET, OFFICE_CODE,
						PRD_BF_AF, PRD_DAYS, 
						USE_TAX_FLAGS , TAXAPPLYLN , 
						TAXAPPLYND , TAXAPPLYNC , 
						TAXAPPLYAI , TAXAPPLYC , TAXAPPLYR )
			Select	COALESCE(PRD_NEWS_REBATE, 0),
						COALESCE(PRD_NEWS_COMM, 0),
						PRD_NEWS_TAX_CODE, COALESCE(PRD_NEWS_COM_ONLY, 0),
						COALESCE(PRD_NEWS_BILL_NET,0), OFFICE_CODE,
						COALESCE(PRD_NEWS_BF_AF, 0), COALESCE(PRD_NEWS_DAYS, 0), 
						USE_TAX_FLAGS_N , TAXAPPLYLN_N , 
						TAXAPPLYND_N , TAXAPPLYNC_N , 
						TAXAPPLYAI_N , TAXAPPLYC_N , TAXAPPLYR_N 					
			From		PRODUCT
			Where		CL_CODE = @cl_code AND
						DIV_CODE = @div_code AND
						PRD_CODE = @prd_code;
	END					
	ELSE			
	IF @order_type =  'MA'
	BEGIN
	INSERT INTO @med_billed (PRD_REBATE,
						PRD_COMM,
						PRD_TAX_CODE, PRD_COM_ONLY,
						PRD_BILL_NET, OFFICE_CODE,
						PRD_BF_AF, PRD_DAYS, 
						USE_TAX_FLAGS , TAXAPPLYLN , 
						TAXAPPLYND , TAXAPPLYNC , 
						TAXAPPLYAI , TAXAPPLYC , TAXAPPLYR )
			Select	COALESCE(PRD_MAG_REBATE, 0),
						COALESCE(PRD_MAG_COMM, 0),
						PRD_MAG_TAX_CODE, COALESCE(PRD_MAG_COM_ONLY, 0),
						COALESCE(PRD_MAG_BILL_NET, 0), OFFICE_CODE,
						COALESCE(PRD_MAG_BF_AF, 0), COALESCE(PRD_MAG_DAYS, 0), 
						USE_TAX_FLAGS_M , TAXAPPLYLN_M , 
						TAXAPPLYND_M , TAXAPPLYNC_M , 
						TAXAPPLYAI_M , TAXAPPLYC_M , TAXAPPLYR_M 					
			From		PRODUCT
			Where		CL_CODE = @cl_code AND
						DIV_CODE = @div_code AND
						PRD_CODE = @prd_code;
	END				
	ELSE	
	IF @order_type =  'OD'
	BEGIN
	INSERT INTO @med_billed (PRD_REBATE,
						PRD_COMM,
						PRD_TAX_CODE, PRD_COM_ONLY,
						PRD_BILL_NET, OFFICE_CODE,
						PRD_BF_AF, PRD_DAYS, 
						USE_TAX_FLAGS , TAXAPPLYLN , 
						TAXAPPLYND , TAXAPPLYNC , 
						TAXAPPLYAI , TAXAPPLYC , TAXAPPLYR )
			Select	COALESCE(PRD_OTDR_REBATE, 0),
						COALESCE(PRD_OTDR_COMM, 0),
						PRD_OTDR_TAX_CODE, COALESCE(PRD_OTDR_COM_ONLY, 0),
						COALESCE(PRD_OTDR_BILL_NET, 0), OFFICE_CODE,
						COALESCE(PRD_OTDR_BF_AF, 0), COALESCE(PRD_OTDR_DAYS, 0), 
						USE_TAX_FLAGS_O , TAXAPPLYLN_O , 
						TAXAPPLYND_O , TAXAPPLYNC_O , 
						TAXAPPLYAI_O , TAXAPPLYC_O , TAXAPPLYR_O 					
			From		PRODUCT
			Where		CL_CODE = @cl_code AND
						DIV_CODE = @div_code AND
						PRD_CODE = @prd_code;
	END	
	ELSE			
	IF @order_type =  'IN'
	BEGIN
	INSERT INTO @med_billed (PRD_REBATE,
						PRD_COMM,
						PRD_TAX_CODE, PRD_COM_ONLY,
						PRD_BILL_NET, OFFICE_CODE,
						PRD_BF_AF, PRD_DAYS, 
						USE_TAX_FLAGS , TAXAPPLYLN , 
						TAXAPPLYND , TAXAPPLYNC , 
						TAXAPPLYAI , TAXAPPLYC , TAXAPPLYR )
			Select	COALESCE(PRD_MISC_REBATE, 0),
						COALESCE(PRD_MISC_COMM, 0),
						PRD_MISC_TAX_CODE, COALESCE(PRD_MISC_COM_ONLY, 0),
						COALESCE(PRD_MISC_BILL_NET, 0), OFFICE_CODE,
						COALESCE(PRD_MISC_BF_AF, 0), COALESCE(PRD_MISC_DAYS, 0), 
						USE_TAX_FLAGS_I , TAXAPPLYLN_I , 
						TAXAPPLYND_I , TAXAPPLYNC_I , 
						TAXAPPLYAI_I , TAXAPPLYC_I , TAXAPPLYR_I 					
			From		PRODUCT
			Where		CL_CODE = @cl_code AND
						DIV_CODE = @div_code AND
						PRD_CODE = @prd_code;
	END			
	ELSE			
	IF @order_type =  'RA'
	BEGIN
	INSERT INTO @med_billed (PRD_REBATE,
						PRD_COMM,
						PRD_TAX_CODE, PRD_COM_ONLY,
						PRD_BILL_NET, OFFICE_CODE,
						PRD_BF_AF, PRD_DAYS, 
						USE_TAX_FLAGS , TAXAPPLYLN , 
						TAXAPPLYND , TAXAPPLYNC , 
						TAXAPPLYAI , TAXAPPLYC , TAXAPPLYR )
			Select	COALESCE(PRD_RADIO_REBATE, 0),
						COALESCE(PRD_RADIO_COMM, 0),
						PRD_RADIO_TAX_CODE, COALESCE(PRD_RADIO_COM_ONLY, 0),
						COALESCE(PRD_RADIO_BILL_NET, 0), OFFICE_CODE,
						COALESCE(PRD_RADIO_BF_AF, 0), COALESCE(PRD_RADIO_DAYS, 0), 
						USE_TAX_FLAGS_R , TAXAPPLYLN_R , 
						TAXAPPLYND_R , TAXAPPLYNC_R , 
						TAXAPPLYAI_R , TAXAPPLYC_R , TAXAPPLYR_R 					
			From		PRODUCT
			Where		CL_CODE = @cl_code AND
						DIV_CODE = @div_code AND
						PRD_CODE = @prd_code;
	END					
	ELSE			
	IF @order_type =  'TV'
	BEGIN
	INSERT INTO @med_billed (PRD_REBATE,
						PRD_COMM,
						PRD_TAX_CODE, PRD_COM_ONLY,
						PRD_BILL_NET, OFFICE_CODE,
						PRD_BF_AF, PRD_DAYS, 
						USE_TAX_FLAGS , TAXAPPLYLN , 
						TAXAPPLYND , TAXAPPLYNC , 
						TAXAPPLYAI , TAXAPPLYC , TAXAPPLYR )
			Select	COALESCE(PRD_TV_REBATE, 0),
						COALESCE(PRD_TV_COMM, 0),
						PRD_TV_TAX_CODE, COALESCE(PRD_TV_COM_ONLY, 0),
						COALESCE(PRD_TV_BILL_NET, 0), OFFICE_CODE,
						COALESCE(PRD_TV_BF_AF, 0), COALESCE(PRD_TV_DAYS, 0), 
						USE_TAX_FLAGS_T , TAXAPPLYLN_T , 
						TAXAPPLYND_T , TAXAPPLYNC_T , 
						TAXAPPLYAI_T , TAXAPPLYC_T , TAXAPPLYR_T 					
			From		PRODUCT
			Where		CL_CODE = @cl_code AND
						DIV_CODE = @div_code AND
						PRD_CODE = @prd_code;
	END		

	DECLARE @prd_comm_only smallint
	DECLARE @prd_bill_net smallint		
	DECLARE @prd_bill_type smallint
	DECLARE @rebate decimal(14, 4), @markup decimal(14, 4)
	
	SELECT	@prd_comm_only = [PRD_COM_ONLY], 
					@prd_bill_net = [PRD_BILL_NET]
	FROM @med_billed
	
	--/* PJH 01/11/16 - Added */ /* MOVED TO SEPARATE FUNCTION */
	--IF @sc_code IS NOT NULL BEGIN
	--	SELECT	@rebate = REBATE, @markup = MARKUP 
	--	FROM PRODUCT_MEDIA_OVERRIDES
	--	WHERE CL_CODE = @cl_code AND
	--			DIV_CODE = @div_code AND
	--			PRD_CODE = @prd_code AND
	--			MEDIA_TYPE = LEFT(@order_type, 1) AND
	--			SC_CODE = @sc_code /* media type */;
				
	--	IF 	@rebate > 0 UPDATE @med_billed SET [PRD_REBATE] = @rebate
	--	IF 	@markup > 0 UPDATE @med_billed SET [SC_MARKUP] = @markup
	--END

	IF @action IN ('SETUP', 'NEW', 'COPY') 
		--1 = Comm Only, 2 = Net, 3 = Gross
		IF @prd_comm_only = 1 
			SET @prd_bill_type = 1
		ELSE
		IF @prd_bill_net = 1 
			SET @prd_bill_type = 2
		ELSE
			SET @prd_bill_type = 3

	UPDATE @med_billed
	SET [PRD_BILL_TYPE] = @prd_bill_type

	RETURN
END

GO