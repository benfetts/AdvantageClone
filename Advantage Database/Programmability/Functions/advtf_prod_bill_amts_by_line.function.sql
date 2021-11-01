if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advtf_prod_bill_amts_by_line]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advtf_prod_bill_amts_by_line]
GO
CREATE FUNCTION dbo.advtf_prod_bill_amts_by_line ( 
	@job_number integer, 
	@job_component_nbr smallint, 
	@val_type varchar(20), 
	@date_cutoff smalldatetime, 
	@post_period varchar(6), 
	@excl_nobill bit, 
	@excl_fee bit 
)

RETURNS @prod_bill_line TABLE ( 
								ITEM_ID			integer NULL, 
								SEQ_NBR			int NULL,											
								FNC_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
								FNC_TYPE		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
								QTY_HRS			decimal(14,2) NULL,	
								BA_ID			integer NULL,									
								VERSION_SEQ		smallint NULL,
								SOURCE			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
								VAL_TYPE		varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL, 
								NET				decimal(15,2) NULL,
								COMMISSION		decimal(15,2) NULL,
								RESALE_TAX		decimal(15,2) NULL,
								VENDOR_TAX		decimal(15,2) NULL,
								LINE_TOTAL		decimal(15,2) NULL,
								QUOTE_QTY_HRS	decimal(14,2) NULL,
								REC_DTL_ID		integer NULL )

AS
BEGIN
	
	--	EMPLOYEE TIME
	BEGIN
	
		-- Billed employee time
		IF ( @val_type IS NULL ) OR ( @val_type = 'Billed' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ, 
						SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
				 SELECT etd.ET_ID, etd.SEQ_NBR, FNC_CODE, 'E', EMP_HOURS, etd.BA_ID, JOB_VER_SEQ_NBR, 'Actual', 'Billed', 
						COALESCE( etd.TOTAL_BILL, 0.00 ), COALESCE( etd.EXT_MARKUP_AMT, 0.00 ),  
						COALESCE( etd.EXT_CITY_RESALE, 0.00 ) + COALESCE( etd.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( etd.EXT_STATE_RESALE, 0.00 ),
						NULL, COALESCE( etd.LINE_TOTAL, 0.00 ), etd.ET_DTL_ID
				   FROM dbo.EMP_TIME et 
			 INNER JOIN dbo.EMP_TIME_DTL etd
					 ON ( et.ET_ID = etd.ET_ID )
		LEFT OUTER JOIN dbo.JOB_VER_HDR jvh
					 ON ( etd.JOB_NUMBER = jvh.JOB_NUMBER )
					AND ( etd.JOB_COMPONENT_NBR = jvh.JOB_COMPONENT_NBR )
					AND ( etd.JOB_VER_HDR_ID = jvh.JOB_VER_HDR_ID )
				  WHERE ( etd.JOB_NUMBER = @job_number ) 
					AND ( etd.JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( et.EMP_DATE <= @date_cutoff )
					AND ( AR_INV_NBR IS NOT NULL )
					AND ( etd.EDIT_FLAG <> 1 OR etd.EDIT_FLAG IS NULL );
		END

		-- Unbilled employee time
		IF ( @val_type IS NULL ) OR ( @val_type = 'Unbilled' )
		BEGIN
			IF ( @excl_fee = 1 )
			BEGIN
				INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ,  
							SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
					 SELECT etd.ET_ID, etd.SEQ_NBR, FNC_CODE, 'E', EMP_HOURS, etd.BA_ID, JOB_VER_SEQ_NBR, 'Actual', 'Unbilled', 
							COALESCE( etd.TOTAL_BILL, 0.00 ), COALESCE( etd.EXT_MARKUP_AMT, 0.00 ),  
							COALESCE( etd.EXT_CITY_RESALE, 0.00 ) + COALESCE( etd.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( etd.EXT_STATE_RESALE, 0.00 ),
							NULL, COALESCE( etd.LINE_TOTAL, 0.00 ), etd.ET_DTL_ID
					   FROM dbo.EMP_TIME et 
				 INNER JOIN dbo.EMP_TIME_DTL etd
						 ON ( et.ET_ID = etd.ET_ID )
			LEFT OUTER JOIN dbo.JOB_VER_HDR jvh
						 ON ( etd.JOB_NUMBER = jvh.JOB_NUMBER )
						AND ( etd.JOB_COMPONENT_NBR = jvh.JOB_COMPONENT_NBR )
						AND ( etd.JOB_VER_HDR_ID = jvh.JOB_VER_HDR_ID )
					  WHERE ( etd.JOB_NUMBER = @job_number ) 
						AND ( etd.JOB_COMPONENT_NBR = @job_component_nbr )
						AND ( et.EMP_DATE <= @date_cutoff )
						AND ( EMP_NON_BILL_FLAG IS NULL OR EMP_NON_BILL_FLAG = 0 )
						AND ( FEE_TIME = 0 OR FEE_TIME IS NULL )
						AND ( BILL_HOLD_FLG = 0 OR BILL_HOLD_FLG IS NULL )
						AND ( AR_INV_NBR IS NULL )
		     			AND ( etd.EDIT_FLAG <> 1 OR etd.EDIT_FLAG IS NULL );
			END
			ELSE
			BEGIN
				INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ,  
							SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID  )
					 SELECT etd.ET_ID, etd.SEQ_NBR, FNC_CODE, 'E', EMP_HOURS, etd.BA_ID, JOB_VER_SEQ_NBR, 'Actual', 'Unbilled', 
							COALESCE( etd.TOTAL_BILL, 0.00 ), COALESCE( etd.EXT_MARKUP_AMT, 0.00 ),  
							COALESCE( etd.EXT_CITY_RESALE, 0.00 ) + COALESCE( etd.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( etd.EXT_STATE_RESALE, 0.00 ),
							NULL, COALESCE( etd.LINE_TOTAL, 0.00 ), etd.ET_DTL_ID
					   FROM dbo.EMP_TIME et 
				 INNER JOIN dbo.EMP_TIME_DTL etd
						 ON ( et.ET_ID = etd.ET_ID )
			LEFT OUTER JOIN dbo.JOB_VER_HDR jvh
						 ON ( etd.JOB_NUMBER = jvh.JOB_NUMBER )
						AND ( etd.JOB_COMPONENT_NBR = jvh.JOB_COMPONENT_NBR )
						AND ( etd.JOB_VER_HDR_ID = jvh.JOB_VER_HDR_ID )
					  WHERE ( etd.JOB_NUMBER = @job_number ) 
						AND ( etd.JOB_COMPONENT_NBR = @job_component_nbr )
						AND ( et.EMP_DATE <= @date_cutoff )
						AND ( EMP_NON_BILL_FLAG IS NULL OR EMP_NON_BILL_FLAG = 0 )
						AND ( BILL_HOLD_FLG = 0 OR BILL_HOLD_FLG IS NULL )
						AND ( AR_INV_NBR IS NULL )
	    				AND ( etd.EDIT_FLAG <> 1 OR etd.EDIT_FLAG IS NULL );
			END
		END
  
		-- Employee time on bill hold
		IF ( @val_type IS NULL ) OR ( @val_type = 'Bill Hold' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ,  
						SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
				 SELECT etd.ET_ID, etd.SEQ_NBR, FNC_CODE, 'E', EMP_HOURS, etd.BA_ID, JOB_VER_SEQ_NBR, 'Actual', 'Bill Hold', 
						COALESCE( etd.TOTAL_BILL, 0.00 ), COALESCE( etd.EXT_MARKUP_AMT, 0.00 ),  
						COALESCE( etd.EXT_CITY_RESALE, 0.00 ) + COALESCE( etd.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( etd.EXT_STATE_RESALE, 0.00 ),
						NULL, COALESCE( etd.LINE_TOTAL, 0.00 ), etd.ET_DTL_ID
				   FROM dbo.EMP_TIME et 
			 INNER JOIN dbo.EMP_TIME_DTL etd
					 ON ( et.ET_ID = etd.ET_ID )
		LEFT OUTER JOIN dbo.JOB_VER_HDR jvh
					 ON ( etd.JOB_NUMBER = jvh.JOB_NUMBER )
					AND ( etd.JOB_COMPONENT_NBR = jvh.JOB_COMPONENT_NBR )
					AND ( etd.JOB_VER_HDR_ID = jvh.JOB_VER_HDR_ID )
				  WHERE ( etd.JOB_NUMBER = @job_number ) 
					AND ( etd.JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( et.EMP_DATE <= @date_cutoff )
					AND ( BILL_HOLD_FLG = 1 OR BILL_HOLD_FLG = 2 )
					AND ( AR_INV_NBR IS NULL )
	   				AND ( etd.EDIT_FLAG <> 1 OR etd.EDIT_FLAG IS NULL );
		END

		-- Nonbillable employee time
		IF ( (( @val_type IS NULL ) OR ( @val_type = 'Nonbillable' )) AND (( @excl_nobill = 0 ) OR ( @excl_nobill IS NULL )) )
		BEGIN
			IF ( @excl_fee = 1 )
			BEGIN
				INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ,  
							SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL,REC_DTL_ID )
 					 SELECT etd.ET_ID, etd.SEQ_NBR, FNC_CODE, 'E', EMP_HOURS, etd.BA_ID, JOB_VER_SEQ_NBR, 'Actual', 'Nonbillable', 
 							COALESCE( etd.TOTAL_BILL, 0.00 ), COALESCE( etd.EXT_MARKUP_AMT, 0.00 ),  
							COALESCE( etd.EXT_CITY_RESALE, 0.00 ) + COALESCE( etd.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( etd.EXT_STATE_RESALE, 0.00 ),
							NULL, COALESCE( etd.LINE_TOTAL, 0.00 ), etd.ET_DTL_ID
					   FROM dbo.EMP_TIME et 
				 INNER JOIN dbo.EMP_TIME_DTL etd
						 ON ( et.ET_ID = etd.ET_ID )
			LEFT OUTER JOIN dbo.JOB_VER_HDR jvh
						 ON ( etd.JOB_NUMBER = jvh.JOB_NUMBER )
						AND ( etd.JOB_COMPONENT_NBR = jvh.JOB_COMPONENT_NBR )
						AND ( etd.JOB_VER_HDR_ID = jvh.JOB_VER_HDR_ID )
					  WHERE ( etd.JOB_NUMBER = @job_number ) 
						AND ( etd.JOB_COMPONENT_NBR = @job_component_nbr )
						AND ( et.EMP_DATE <= @date_cutoff )
						AND ( EMP_NON_BILL_FLAG = 1 )
						AND ( FEE_TIME = 0 OR FEE_TIME IS NULL )
	    				AND ( etd.EDIT_FLAG <> 1 OR etd.EDIT_FLAG IS NULL );
			END
			ELSE
			BEGIN
				INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ,  
							SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
 					 SELECT etd.ET_ID, etd.SEQ_NBR, FNC_CODE, 'E', EMP_HOURS, etd.BA_ID, JOB_VER_SEQ_NBR, 'Actual', 'Nonbillable', 
 							COALESCE( etd.TOTAL_BILL, 0.00 ), COALESCE( etd.EXT_MARKUP_AMT, 0.00 ),  
							COALESCE( etd.EXT_CITY_RESALE, 0.00 ) + COALESCE( etd.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( etd.EXT_STATE_RESALE, 0.00 ),
							NULL, COALESCE( etd.LINE_TOTAL, 0.00 ), etd.ET_DTL_ID
					   FROM dbo.EMP_TIME et 
				 INNER JOIN dbo.EMP_TIME_DTL etd
						 ON ( et.ET_ID = etd.ET_ID )
			LEFT OUTER JOIN dbo.JOB_VER_HDR jvh
						 ON ( etd.JOB_NUMBER = jvh.JOB_NUMBER )
						AND ( etd.JOB_COMPONENT_NBR = jvh.JOB_COMPONENT_NBR )
						AND ( etd.JOB_VER_HDR_ID = jvh.JOB_VER_HDR_ID )
					  WHERE ( etd.JOB_NUMBER = @job_number ) 
						AND ( etd.JOB_COMPONENT_NBR = @job_component_nbr )
						AND ( et.EMP_DATE <= @date_cutoff )
						AND ( EMP_NON_BILL_FLAG = 1 )
	    				AND ( etd.EDIT_FLAG <> 1 OR etd.EDIT_FLAG IS NULL );
			END
		END
	END

	--	AP
	BEGIN

		-- Billed accounts payable
		IF ( @val_type IS NULL ) OR ( @val_type = 'Billed' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
				 SELECT app.AP_ID, app.LINE_NUMBER, app.FNC_CODE, 'V', app.AP_PROD_QUANTITY, app.BA_ID, 'Actual', 'Billed', 
						COALESCE( app.AP_PROD_EXT_AMT, 0.00 ), COALESCE( app.EXT_MARKUP_AMT, 0.00 ), 
						COALESCE( app.EXT_CITY_RESALE, 0.00 ) + COALESCE( app.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( app.EXT_STATE_RESALE, 0.00 ),
						COALESCE( app.EXT_NONRESALE_TAX, 0.00 ), COALESCE( app.LINE_TOTAL, 0.00 ), app.LINE_NUMBER
				   FROM dbo.AP_PRODUCTION app
				  WHERE ( app.JOB_NUMBER = @job_number ) 
					AND ( app.JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( app.POST_PERIOD <= @post_period )
					AND ( AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0 )
					AND ( AR_INV_NBR IS NOT NULL )
					AND ( app.MODIFY_DELETE <> 1 OR app.MODIFY_DELETE IS NULL);
		END

		-- Unbilled accounts payable
		IF ( @val_type IS NULL ) OR ( @val_type = 'Unbilled' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
				 SELECT app.AP_ID, app.LINE_NUMBER, app.FNC_CODE, 'V', app.AP_PROD_QUANTITY, app.BA_ID, 'Actual', 'Unbilled', 
						COALESCE( app.AP_PROD_EXT_AMT, 0.00 ), COALESCE( app.EXT_MARKUP_AMT, 0.00 ),
						COALESCE( app.EXT_CITY_RESALE, 0.00 ) + COALESCE( app.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( app.EXT_STATE_RESALE, 0.00 ),
						COALESCE( app.EXT_NONRESALE_TAX, 0.00 ), COALESCE( app.LINE_TOTAL, 0.00 ), app.LINE_NUMBER
				   FROM dbo.AP_PRODUCTION app
				  WHERE ( app.JOB_NUMBER = @job_number ) 
					AND ( app.JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( app.POST_PERIOD <= @post_period )
					AND ( AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0 )
					AND ( AP_PROD_BILL_HOLD = 0 OR AP_PROD_BILL_HOLD IS NULL )
					AND ( AR_INV_NBR IS NULL )
					AND ( app.MODIFY_DELETE <> 1 OR app.MODIFY_DELETE IS NULL);
		END

		-- Accounts payable bill hold
		IF ( @val_type IS NULL ) OR ( @val_type = 'Bill Hold' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
				 SELECT app.AP_ID, app.LINE_NUMBER, app.FNC_CODE, 'V', app.AP_PROD_QUANTITY, app.BA_ID, 'Actual', 'Bill Hold', 
						COALESCE( app.AP_PROD_EXT_AMT, 0.00 ), COALESCE( app.EXT_MARKUP_AMT, 0.00 ),
						COALESCE( app.EXT_CITY_RESALE, 0.00 ) + COALESCE( app.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( app.EXT_STATE_RESALE, 0.00 ),
						COALESCE( app.EXT_NONRESALE_TAX, 0.00 ), COALESCE( app.LINE_TOTAL, 0.00 ), app.LINE_NUMBER
				   FROM dbo.AP_PRODUCTION app
				  WHERE ( app.JOB_NUMBER = @job_number ) 
					AND ( app.JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( app.POST_PERIOD <= @post_period )
					AND ( AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0 )
					AND ( AP_PROD_BILL_HOLD = 1 OR AP_PROD_BILL_HOLD = 2 ) 
					AND ( AR_INV_NBR IS NULL )
					AND ( app.MODIFY_DELETE <> 1 OR app.MODIFY_DELETE IS NULL);
		END

		-- Nonbillable accounts payable
		IF ( (( @val_type IS NULL ) OR ( @val_type = 'Nonbillable' )) AND (( @excl_nobill = 0 ) OR ( @excl_nobill IS NULL )) )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
				 SELECT app.AP_ID, app.LINE_NUMBER, app.FNC_CODE, 'V', app.AP_PROD_QUANTITY, app.BA_ID, 'Actual', 'Nonbillable', 
						COALESCE( app.AP_PROD_EXT_AMT, 0.00 ), COALESCE( app.EXT_MARKUP_AMT, 0.00 ),
						COALESCE( app.EXT_CITY_RESALE, 0.00 ) + COALESCE( app.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( app.EXT_STATE_RESALE, 0.00 ),
						COALESCE( app.EXT_NONRESALE_TAX, 0.00 ), COALESCE( app.LINE_TOTAL, 0.00 ), app.LINE_NUMBER
				   FROM dbo.AP_PRODUCTION app
				  WHERE ( app.JOB_NUMBER = @job_number ) 
					AND ( app.JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( app.POST_PERIOD <= @post_period )
					AND ( AP_PROD_NOBILL_FLG = 1 )
					AND ( app.MODIFY_DELETE <> 1 OR app.MODIFY_DELETE IS NULL);
		END
	END

	--	INCOME ONLY
	BEGIN
		-- Billed income only
		IF ( @val_type IS NULL ) OR ( @val_type = 'Billed' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
				 SELECT IO_ID, SEQ_NBR, FNC_CODE, 'I', IO_QTY, BA_ID, 'Actual', 'Billed', COALESCE( IO_AMOUNT, 0.00 ), COALESCE( EXT_MARKUP_AMT, 0.00 ),
						COALESCE( EXT_CITY_RESALE, 0.00 ) + COALESCE( EXT_COUNTY_RESALE, 0.00 ) + COALESCE( EXT_STATE_RESALE, 0.00 ),
						NULL, COALESCE( LINE_TOTAL, 0.00 ), SEQ_NBR
				   FROM dbo.INCOME_ONLY
				  WHERE ( JOB_NUMBER = @job_number ) 
					AND ( JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( IO_INV_DATE <= @date_cutoff )
					AND ( AR_INV_NBR IS NOT NULL );
		END

		-- Unbilled income only
		IF ( @val_type IS NULL ) OR ( @val_type = 'Unbilled' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
					SELECT IO_ID AS ID, SEQ_NBR, FNC_CODE, 'I', IO_QTY, BA_ID, 'Actual', 'Unbilled', COALESCE( IO_AMOUNT, 0.00 ), COALESCE( EXT_MARKUP_AMT, 0.00 ),
						COALESCE( EXT_CITY_RESALE, 0.00 ) + COALESCE( EXT_COUNTY_RESALE, 0.00 ) + COALESCE( EXT_STATE_RESALE, 0.00 ),
						NULL, COALESCE( LINE_TOTAL, 0.00 ), SEQ_NBR
					FROM dbo.INCOME_ONLY
					WHERE ( JOB_NUMBER = @job_number ) 
					AND ( JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( IO_INV_DATE <= @date_cutoff )
					AND ( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL )
					AND ( BILL_HOLD_FLAG IS NULL OR BILL_HOLD_FLAG = 0 )
					AND ( AR_INV_NBR IS NULL );
		END

		-- Income only bill hold
		IF ( @val_type IS NULL ) OR ( @val_type = 'Bill Hold' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
					SELECT IO_ID, SEQ_NBR, FNC_CODE, 'I', IO_QTY, BA_ID, 'Actual', 'Bill Hold', COALESCE( IO_AMOUNT, 0.00 ), COALESCE( EXT_MARKUP_AMT, 0.00 ),
						COALESCE( EXT_CITY_RESALE, 0.00 ) + COALESCE( EXT_COUNTY_RESALE, 0.00 ) + COALESCE( EXT_STATE_RESALE, 0.00 ),
						NULL, COALESCE( LINE_TOTAL, 0.00 ), SEQ_NBR
					FROM dbo.INCOME_ONLY
					WHERE ( JOB_NUMBER = @job_number ) 
					AND ( JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( IO_INV_DATE <= @date_cutoff )
					AND ( BILL_HOLD_FLAG = 1 OR BILL_HOLD_FLAG = 2 )
					AND ( AR_INV_NBR IS NULL );
		END

		-- Nonbillable income only
		IF ( (( @val_type IS NULL ) OR ( @val_type = 'Nonbillable' )) AND (( @excl_nobill = 0 ) OR ( @excl_nobill IS NULL )) )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
					SELECT IO_ID, SEQ_NBR, FNC_CODE, 'I', IO_QTY, BA_ID, 'Actual', 'Nonbillable', COALESCE( IO_AMOUNT, 0.00 ), COALESCE( EXT_MARKUP_AMT, 0.00 ),
						COALESCE( EXT_CITY_RESALE, 0.00 ) + COALESCE( EXT_COUNTY_RESALE, 0.00 ) + COALESCE( EXT_STATE_RESALE, 0.00 ),
						NULL, COALESCE( LINE_TOTAL, 0.00 ), SEQ_NBR
					FROM dbo.INCOME_ONLY
					WHERE ( JOB_NUMBER = @job_number ) 
					AND ( JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( IO_INV_DATE <= @date_cutoff )
					AND ( NON_BILL_FLAG = 1 );
		END
	END

	--	BILLED ADVANCE BILL
	BEGIN
		IF ( @val_type IS NULL ) OR ( @val_type = 'Billed' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, REC_DTL_ID )
					SELECT AB_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, NULL, NULL, 'Advance', 'Billed', 
						COALESCE( ADV_BILL_NET_AMT, 0.00 ), COALESCE( EXT_MARKUP_AMT, 0.00 ), 
						COALESCE( EXT_CITY_RESALE, 0.00 ) + COALESCE( EXT_COUNTY_RESALE, 0.00 ) + COALESCE( EXT_STATE_RESALE, 0.00 ),
						COALESCE( EXT_NONRESALE_TAX, 0.00 ), COALESCE( LINE_TOTAL, 0.00 ), SEQ_NBR
					FROM dbo.ADVANCE_BILLING
					WHERE ( JOB_NUMBER = @job_number ) 
					AND ( JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( AR_INV_NBR IS NOT NULL );
		END
	END

	--	APPROVED ESTIMATE QUOTE
	BEGIN
		IF ( @val_type IS NULL ) OR ( @val_type = 'Quote' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, SOURCE, VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL, QUOTE_QTY_HRS, REC_DTL_ID )
					SELECT NULL, NULL, FNC_CODE, EST_FNC_TYPE, NULL, NULL, 'Quote', 'Quote', 
						COALESCE( erd.EST_REV_EXT_AMT, 0.00 ), COALESCE( erd.EXT_MARKUP_AMT, 0.00 ),
						COALESCE( erd.EXT_CITY_RESALE, 0.00 ) + COALESCE( erd.EXT_COUNTY_RESALE, 0.00 ) + COALESCE( erd.EXT_STATE_RESALE, 0.00 ),
						COALESCE( erd.EXT_NONRESALE_TAX, 0.00 ), COALESCE( erd.LINE_TOTAL, 0.00 ), COALESCE( erd.EST_REV_QUANTITY, 0.00 ), erd.EST_REV_NBR
					FROM dbo.ESTIMATE_REV_DET erd
				INNER JOIN dbo.ESTIMATE_APPROVAL ea
						ON erd.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER
					AND erd.EST_COMPONENT_NBR = ea.EST_COMPONENT_NBR
					AND erd.EST_QUOTE_NBR = ea.EST_QUOTE_NBR
					AND erd.EST_REV_NBR = ea.EST_REVISION_NBR
					WHERE ( JOB_NUMBER = @job_number ) 
					AND ( JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( EST_FNC_TYPE <> 'F' AND EST_FNC_TYPE <> 'C' );
		END
	END

	--	OPEN PO
	BEGIN
		IF ( @val_type IS NULL ) OR ( @val_type = 'Open PO' )
		BEGIN
			INSERT INTO @prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, SOURCE, VAL_TYPE, NET, REC_DTL_ID )
					SELECT pod.PO_NUMBER, LINE_NUMBER, FNC_CODE, 'V', NULL, 'PO', 'Open PO', 
						PO_EXT_AMOUNT - ( SELECT COALESCE( SUM( AP_PROD_EXT_AMT ), 0.00 )
											FROM dbo.AP_PRODUCTION
											WHERE JOB_NUMBER = pod.JOB_NUMBER
												AND JOB_COMPONENT_NBR = pod.JOB_COMPONENT_NBR
												AND PO_NUMBER = pod.PO_NUMBER
												AND PO_LINE_NUMBER = pod.LINE_NUMBER ), pod.LINE_NUMBER
					FROM dbo.PURCHASE_ORDER_DET pod
				INNER JOIN dbo.PURCHASE_ORDER po
						ON ( pod.PO_NUMBER = po.PO_NUMBER )
					WHERE ( JOB_NUMBER = @job_number ) 
					AND ( JOB_COMPONENT_NBR = @job_component_nbr )
					AND ( FNC_CODE IS NOT NULL )  
					AND ( pod.PO_COMPLETE IS NULL OR pod.PO_COMPLETE = 0 ) 
					AND ( VOID_FLAG IS NULL OR VOID_FLAG = 0 ); 
		END
	END
	
	--	CLEAN UP
	BEGIN
		UPDATE @prod_bill_line SET QUOTE_QTY_HRS = 0.00 WHERE QUOTE_QTY_HRS IS NULL;
	END			
RETURN
END