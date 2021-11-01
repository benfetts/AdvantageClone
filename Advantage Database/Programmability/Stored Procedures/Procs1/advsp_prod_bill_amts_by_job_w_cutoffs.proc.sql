
CREATE PROCEDURE [dbo].[advsp_prod_bill_amts_by_job_w_cutoffs] @job_number integer, @job_component_nbr smallint, 
	@et_date_cutoff smalldatetime, @io_date_cutoff smalldatetime, @post_period varchar(6), @ret_val integer OUTPUT
AS

CREATE TABLE #prod_bill_line ( 
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
	LINE_TOTAL		decimal(15,2) NULL )	
	
CREATE TABLE #prod_bill_job ( 
	QUOTE			decimal(15,2) NULL,
	ACTUALS			decimal(15,2) NULL,
	BILLED			decimal(15,2) NULL, 
	UNBILLED		decimal(15,2) NULL, 
	BILL_HOLD		decimal(15,2) NULL,
	NONBILL			decimal(15,2) NULL,
	PO				decimal(15,2) NULL )

SELECT @ret_val = 0

INSERT INTO #prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ, SOURCE, 
			VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL )
	 SELECT apbabl.ITEM_ID, apbabl.SEQ_NBR, apbabl.FNC_CODE, apbabl.FNC_TYPE, apbabl.QTY_HRS, apbabl.BA_ID, 
			apbabl.VERSION_SEQ, apbabl.SOURCE, apbabl.VAL_TYPE, apbabl.NET, apbabl.COMMISSION, apbabl.RESALE_TAX,
	        apbabl.VENDOR_TAX, apbabl.LINE_TOTAL
	   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, NULL, @et_date_cutoff, NULL, 0, 0 ) apbabl 
	  WHERE apbabl.FNC_TYPE = 'E' 
	    AND apbabl.SOURCE IN ( 'Actual', 'Quote' )

INSERT INTO #prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ, SOURCE, 
			VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL )
	 SELECT apbabl.ITEM_ID, apbabl.SEQ_NBR, apbabl.FNC_CODE, apbabl.FNC_TYPE, apbabl.QTY_HRS, apbabl.BA_ID, 
			apbabl.VERSION_SEQ, apbabl.SOURCE, apbabl.VAL_TYPE, apbabl.NET, apbabl.COMMISSION, apbabl.RESALE_TAX,
	        apbabl.VENDOR_TAX, apbabl.LINE_TOTAL
	   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, NULL, NULL, @post_period, 0, 0 ) apbabl 
	  WHERE apbabl.FNC_TYPE = 'V' 
	    AND apbabl.SOURCE IN ( 'Actual', 'Quote', 'PO' )

INSERT INTO #prod_bill_line( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, QTY_HRS, BA_ID, VERSION_SEQ, SOURCE, 
			VAL_TYPE, NET, COMMISSION, RESALE_TAX, VENDOR_TAX, LINE_TOTAL )
	 SELECT apbabl.ITEM_ID, apbabl.SEQ_NBR, apbabl.FNC_CODE, apbabl.FNC_TYPE, apbabl.QTY_HRS, apbabl.BA_ID, 
			apbabl.VERSION_SEQ, apbabl.SOURCE, apbabl.VAL_TYPE, apbabl.NET, apbabl.COMMISSION, apbabl.RESALE_TAX,
	        apbabl.VENDOR_TAX, apbabl.LINE_TOTAL
	   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, NULL, @io_date_cutoff, NULL, 0, 0 ) apbabl 
	  WHERE apbabl.FNC_TYPE = 'I'
	    AND apbabl.SOURCE IN ( 'Actual', 'Quote' ) 

INSERT INTO #prod_bill_job( QUOTE, ACTUALS, BILLED, UNBILLED, BILL_HOLD, NONBILL, PO )
	 VALUES ( NULL, NULL, NULL, NULL, NULL, NULL, NULL ) 

	 UPDATE #prod_bill_job
	    SET QUOTE = ( SELECT COALESCE( SUM( pbl.LINE_TOTAL ), 0.00 ) FROM #prod_bill_line pbl WHERE pbl.SOURCE = 'Quote' AND pbl.VAL_TYPE = 'Quote' )

	 UPDATE #prod_bill_job
	    SET BILLED = ( SELECT COALESCE( SUM( pbl.LINE_TOTAL ), 0.00 ) FROM #prod_bill_line pbl WHERE pbl.SOURCE = 'Actual' AND pbl.VAL_TYPE = 'Billed' )
	    
	 UPDATE #prod_bill_job
	    SET UNBILLED = ( SELECT COALESCE( SUM( pbl.LINE_TOTAL ), 0.00 ) FROM #prod_bill_line pbl WHERE pbl.SOURCE = 'Actual' AND pbl.VAL_TYPE = 'Unbilled' )
	       
	 UPDATE #prod_bill_job
	    SET BILL_HOLD = ( SELECT COALESCE( SUM( pbl.LINE_TOTAL ), 0.00 ) FROM #prod_bill_line pbl WHERE pbl.SOURCE = 'Actual' AND pbl.VAL_TYPE = 'Bill Hold' )

	 UPDATE #prod_bill_job
	    SET NONBILL = ( SELECT COALESCE( SUM( pbl.LINE_TOTAL ), 0.00 ) FROM #prod_bill_line pbl WHERE pbl.SOURCE = 'Actual' AND pbl.VAL_TYPE = 'Nonbillable' )

	 UPDATE #prod_bill_job
	    SET ACTUALS = COALESCE( BILLED + UNBILLED, 0.00 )

	 UPDATE #prod_bill_job
	    SET PO = ( SELECT COALESCE( SUM( pbl.NET ), 0.00 ) FROM #prod_bill_line pbl WHERE pbl.SOURCE = 'PO' AND pbl.VAL_TYPE = 'Open PO' )

 SELECT pbj.QUOTE, pbj.ACTUALS, pbj.BILLED, pbj.UNBILLED, pbj.BILL_HOLD, pbj.NONBILL, pbj.PO
   FROM	#prod_bill_job pbj
