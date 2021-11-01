if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advtf_prod_bill_amts_by_item]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advtf_prod_bill_amts_by_item]
GO
CREATE FUNCTION dbo.advtf_prod_bill_amts_by_item
( @job_number integer, @job_component_nbr smallint, @date_cutoff smalldatetime, @post_period varchar(6), @excl_nobill bit, @excl_fee bit )
RETURNS @prod_bill_item TABLE ( 
	ITEM_ID			integer NULL, 
	SEQ_NBR			int NULL,
	FNC_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
	FNC_TYPE		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
	SOURCE			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	NAME			varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ITEM_DATE		smalldatetime NULL,
	INV_NBR			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QTY_HRS			decimal(14,2) NULL,
	BA_ID			integer NULL,
	VERSION_SEQ		smallint NULL,
	COMMENTS		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QUOTE_NET		decimal(15,2) NULL,
	QUOTE_MU		decimal(15,2) NULL,
	QUOTE_TAX		decimal(15,2) NULL,
	QUOTE_NR		decimal(15,2) NULL,
	QUOTE_TOT		decimal(15,2) NULL,
	BILLED_NET		decimal(15,2) NULL, 
	BILLED_MU		decimal(15,2) NULL,
	BILLED_TAX		decimal(15,2) NULL,
	BILLED_NR		decimal(15,2) NULL,
	BILLED_TOT		decimal(15,2) NULL,
	UNBILLED_NET	decimal(15,2) NULL, 
	UNBILLED_MU		decimal(15,2) NULL,
	UNBILLED_TAX	decimal(15,2) NULL,
	UNBILLED_NR		decimal(15,2) NULL,
	UNBILLED_TOT	decimal(15,2) NULL,
	BILL_HOLD_NET	decimal(15,2) NULL, 
	BILL_HOLD_MU	decimal(15,2) NULL,
	BILL_HOLD_TAX	decimal(15,2) NULL,
	BILL_HOLD_NR	decimal(15,2) NULL,
	BILL_HOLD_TOT	decimal(15,2) NULL,
	NONBILL_NET		decimal(15,2) NULL,
	NONBILL_MU		decimal(15,2) NULL,
	NONBILL_TAX		decimal(15,2) NULL,
	NONBILL_NR		decimal(15,2) NULL,
	NONBILL_TOT		decimal(15,2) NULL,
	PO				decimal(15,2) NULL,
	QUOTE_QTY_HRS	decimal(14,2) NULL,
	REC_DTL_ID		integer NULL )
AS
BEGIN

	-- Unbilled A/P
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled' 
			AND FNC_TYPE = 'V'
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Unbilled I/O
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), 
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ),  MAX( REC_DTL_ID )	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled' 
			AND FNC_TYPE = 'I'
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ

	-- Unbilled E/T without comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), 
				COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled'
			AND FNC_TYPE = 'E'
			AND NOT EXISTS ( SELECT * 
							   FROM dbo.EMP_TIME_DTL_CMTS etdc
							  WHERE etdc.ET_ID = apbabl.ITEM_ID
								AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Unbilled E/T with comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), 
				COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled'
			AND FNC_TYPE = 'E'
			AND EXISTS ( SELECT * 
						   FROM dbo.EMP_TIME_DTL_CMTS etdc
						  WHERE etdc.ET_ID = apbabl.ITEM_ID
							AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Bill Hold A/P
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				BILL_HOLD_NET, BILL_HOLD_MU, BILL_HOLD_TAX, BILL_HOLD_NR, BILL_HOLD_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'V'
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID
	   
	-- Bill Hold I/O
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				BILL_HOLD_NET, BILL_HOLD_MU, BILL_HOLD_TAX, BILL_HOLD_NR, BILL_HOLD_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), 
				COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ),  MAX( REC_DTL_ID )	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'I'
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ	   

	-- Bill Hold E/T without comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				BILL_HOLD_NET, BILL_HOLD_MU, BILL_HOLD_TAX, BILL_HOLD_NR, BILL_HOLD_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), 
				COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'E'
			AND NOT EXISTS ( SELECT * 
							   FROM dbo.EMP_TIME_DTL_CMTS etdc
							  WHERE etdc.ET_ID = apbabl.ITEM_ID
								AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Bill Hold E/T with comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				BILL_HOLD_NET, BILL_HOLD_MU, BILL_HOLD_TAX, BILL_HOLD_NR, BILL_HOLD_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'E'
			AND EXISTS ( SELECT * 
						   FROM dbo.EMP_TIME_DTL_CMTS etdc
						  WHERE etdc.ET_ID = apbabl.ITEM_ID
							AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Nonbillable A/P
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				NONBILL_NET, NONBILL_MU, NONBILL_TAX, NONBILL_NR, NONBILL_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID			 
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Nonbillable', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Nonbillable' 
			AND FNC_TYPE = 'V'
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID
	
	-- Nonbillable A/P & I/O 
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				NONBILL_NET, NONBILL_MU, NONBILL_TAX, NONBILL_NR, NONBILL_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), 
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ),  MAX( REC_DTL_ID )			 
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Nonbillable', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Nonbillable' 
			AND FNC_TYPE = 'I'
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ

	-- Nonbillable E/T without comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				NONBILL_NET, NONBILL_MU, NONBILL_TAX, NONBILL_NR, NONBILL_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), 
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID		 
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Nonbillable', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Nonbillable' 
			AND FNC_TYPE = 'E'
			AND NOT EXISTS ( SELECT * 
							   FROM dbo.EMP_TIME_DTL_CMTS etdc
							  WHERE etdc.ET_ID = apbabl.ITEM_ID
								AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Nonbillable E/T with comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				NONBILL_NET, NONBILL_MU, NONBILL_TAX, NONBILL_NR, NONBILL_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID			 
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Nonbillable', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Nonbillable' 
			AND FNC_TYPE = 'E'
			AND EXISTS ( SELECT * 
						   FROM dbo.EMP_TIME_DTL_CMTS etdc
						  WHERE etdc.ET_ID = apbabl.ITEM_ID
							AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Billed A/P
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				BILLED_NET, BILLED_MU, BILLED_TAX, BILLED_NR, BILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ),	MAX( BA_ID ), VERSION_SEQ,	
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Billed', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual'
		    AND VAL_TYPE = 'Billed'
		    AND FNC_TYPE = 'V'
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Billed I/O
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				BILLED_NET, BILLED_MU, BILLED_TAX, BILLED_NR, BILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ),	MAX( BA_ID ), VERSION_SEQ,	
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), 
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ),  MAX( REC_DTL_ID )	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Billed', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual'
		    AND VAL_TYPE = 'Billed'
		    AND FNC_TYPE = 'I'
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ

	-- Billed E/T without comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				BILLED_NET, BILLED_MU, BILLED_TAX, BILLED_NR, BILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,	
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), 
				COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Billed', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual'
		    AND VAL_TYPE = 'Billed'
			AND FNC_TYPE = 'E'
			AND NOT EXISTS ( SELECT * 
							   FROM dbo.EMP_TIME_DTL_CMTS etdc
							  WHERE etdc.ET_ID = apbabl.ITEM_ID
								AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Billed E/T with comments
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ, 
				BILLED_NET, BILLED_MU, BILLED_TAX, BILLED_NR, BILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,	
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), 
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Billed', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
		    AND VAL_TYPE = 'Billed'
			AND FNC_TYPE = 'E'
			AND EXISTS ( SELECT * 
						   FROM dbo.EMP_TIME_DTL_CMTS etdc
						  WHERE etdc.ET_ID = apbabl.ITEM_ID
							AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, REC_DTL_ID

	-- Billed A/B
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, BA_ID, VERSION_SEQ, 
				BILLED_NET, BILLED_MU, BILLED_TAX, BILLED_NR, BILLED_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, MAX( BA_ID ), VERSION_SEQ,	
 				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), 
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), MAX( REC_DTL_ID )	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Billed', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE ( SOURCE = 'Advance' )
		    AND ( VAL_TYPE = 'Billed' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ

--	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BILLED_NET, BILLED_MU, BILLED_TAX, BILLED_TOT, REC_DTL_ID )
--		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, NULL,
--				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), REC_DTL_ID		 		 
--		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
--		  WHERE ( SOURCE = 'Advance' AND VAL_TYPE = 'Billed' )
--	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, REC_DTL_ID

	-- Purchase Orders
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, PO, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID	
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Open PO', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE ( SOURCE = 'PO' AND VAL_TYPE = 'Open PO' )
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, REC_DTL_ID

	-- Quote
	INSERT INTO @prod_bill_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QUOTE_NET, QUOTE_MU, QUOTE_TAX, QUOTE_NR, QUOTE_TOT, QUOTE_QTY_HRS, REC_DTL_ID )
		 SELECT ITEM_ID, NULL, FNC_CODE, FNC_TYPE, SOURCE, 
  				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ), COALESCE( SUM( VENDOR_TAX ), 0.00 ), 
				COALESCE( SUM( LINE_TOTAL ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 ), REC_DTL_ID		 
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Quote', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE ( SOURCE = 'Quote' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, REC_DTL_ID

			UPDATE @prod_bill_item
			   SET NAME = ( COALESCE( RTRIM( e.EMP_FNAME ) + ' ', '' ) + COALESCE( e.EMP_MI + '. ', '' ) + COALESCE( e.EMP_LNAME, '' )), 
				   ITEM_DATE = et.EMP_DATE,
				   COMMENTS = etdc.EMP_COMMENT
			  FROM @prod_bill_item pbi
		INNER JOIN dbo.EMP_TIME_DTL etd
			    ON ( pbi.ITEM_ID = etd.ET_ID )
			   AND ( pbi.SEQ_NBR = etd.SEQ_NBR )
		INNER JOIN dbo.EMP_TIME et
			    ON ( etd.ET_ID = et.ET_ID )
		INNER JOIN dbo.EMPLOYEE e
				ON ( et.EMP_CODE = e.EMP_CODE )
   LEFT OUTER JOIN dbo.EMP_TIME_DTL_CMTS etdc
				ON ( etd.ET_ID = etdc.ET_ID )
			   AND ( etd.SEQ_NBR = etdc.SEQ_NBR )
			   AND ( etdc.ET_SOURCE = 'D' )
			 WHERE pbi.SOURCE = 'Actual'
			   AND pbi.FNC_TYPE = 'E'

			UPDATE @prod_bill_item
			   SET NAME = VN_NAME,
				   ITEM_DATE = aph.AP_INV_DATE,
				   INV_NBR = aph.AP_INV_VCHR,
				   COMMENTS = appc.AP_COMMENT
			  FROM @prod_bill_item pbi
		INNER JOIN dbo.AP_PRODUCTION app
			    ON ( pbi.ITEM_ID = app.AP_ID )
			   AND ( pbi.SEQ_NBR = app.LINE_NUMBER )
		INNER JOIN dbo.AP_HEADER aph
			    ON ( app.AP_ID = aph.AP_ID )
	    INNER JOIN dbo.VENDOR v
				ON ( aph.VN_FRL_EMP_CODE = v.VN_CODE )
   LEFT OUTER JOIN dbo.AP_PROD_COMMENTS appc
				ON ( app.AP_ID = appc.AP_ID )
			   AND ( app.LINE_NUMBER = appc.LINE_NUMBER )
			 WHERE pbi.SOURCE = 'Actual'
			   AND pbi.FNC_TYPE = 'V'

			UPDATE @prod_bill_item
			   SET NAME = COALESCE( io.IO_DESC, f.FNC_DESCRIPTION ),
				   ITEM_DATE = io.IO_INV_DATE,
				   INV_NBR = io.IO_INV_NBR,
				   COMMENTS = io.IO_COMMENT
			  FROM @prod_bill_item pbi
		INNER JOIN dbo.INCOME_ONLY io
			    ON ( pbi.ITEM_ID = io.IO_ID )
			   AND ( pbi.SEQ_NBR = io.SEQ_NBR )
		INNER JOIN dbo.FUNCTIONS f
				ON ( io.FNC_CODE = f.FNC_CODE )
			 WHERE pbi.SOURCE = 'Actual'
			   AND pbi.FNC_TYPE = 'I'

			UPDATE @prod_bill_item
			   SET NAME = po.PO_DESCRIPTION,
				   ITEM_DATE = po.PO_DATE,
				   INV_NBR = CONVERT( varchar(60), pod.PO_NUMBER ),
				   COMMENTS = pod.LINE_DESC
			  FROM @prod_bill_item pbi
		INNER JOIN dbo.PURCHASE_ORDER_DET pod
			    ON ( pbi.ITEM_ID = pod.PO_NUMBER )
			   AND ( pbi.SEQ_NBR = pod.LINE_NUMBER )
		INNER JOIN dbo.PURCHASE_ORDER po
				ON ( pod.PO_NUMBER = po.PO_NUMBER )
			 WHERE pbi.SOURCE = 'PO'
			   AND pbi.FNC_TYPE = 'V'

RETURN
END
