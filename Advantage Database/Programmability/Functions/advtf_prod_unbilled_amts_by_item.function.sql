if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advtf_prod_unbilled_amts_by_item]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[advtf_prod_unbilled_amts_by_item]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

CREATE FUNCTION [dbo].[advtf_prod_unbilled_amts_by_item] ( @job_number integer, @job_component_nbr smallint, 
	@date_cutoff smalldatetime, @post_period varchar(6), @excl_nobill bit, @excl_fee bit )
RETURNS @prod_unbilled_item TABLE ( 
	ITEM_ID			integer NULL, 
	SEQ_NBR			int NULL,
	FNC_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
	FNC_TYPE		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
	SOURCE			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	[NAME]			varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ITEM_DATE		smalldatetime NULL,
	INV_NBR			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QTY_HRS			decimal(14,2) NULL,
	BA_ID			integer NULL,
	VERSION_SEQ		smallint NULL,
	COMMENTS		varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	UNBILLED_NET	decimal(15,2) NULL, 
	UNBILLED_MU		decimal(15,2) NULL, 	
	UNBILLED_TAX	decimal(15,2) NULL, 
	UNBILLED_NR		decimal(15,2) NULL, 
	UNBILLED_TOT	decimal(15,2) NULL, 
	PO				decimal(15,2) NULL,
	VAL_TYPE		varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- can be "Unbilled" or "Bill Hold"
	REC_DTL_ID      integer NULL)
AS
BEGIN
	-- Unbilled A/P
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled'
			AND FNC_TYPE = 'V'
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE, REC_DTL_ID

	-- Bill Hold A/P
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'V'
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE, REC_DTL_ID

	-- Unbilled I/O
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, MAX( REC_DTL_ID )
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled'
			AND FNC_TYPE = 'I'
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE

	-- Bill Hold I/O
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, MAX( REC_DTL_ID )
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'I'
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE

	-- Unbilled E/T without comments
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled'
			AND FNC_TYPE = 'E'
			AND NOT EXISTS ( SELECT * 
							   FROM dbo.EMP_TIME_DTL_CMTS etdc
							  WHERE etdc.ET_ID = apbabl.ITEM_ID
								AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE, REC_DTL_ID

	-- Bill Hold E/T without comments
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, MAX( SEQ_NBR ), FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'E'
			AND NOT EXISTS ( SELECT * 
							   FROM dbo.EMP_TIME_DTL_CMTS etdc
							  WHERE etdc.ET_ID = apbabl.ITEM_ID
								AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE, REC_DTL_ID

	-- Unbilled E/T with comments
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Unbilled', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Unbilled'
			AND FNC_TYPE = 'E'
			AND EXISTS ( SELECT * 
						   FROM dbo.EMP_TIME_DTL_CMTS etdc
						  WHERE etdc.ET_ID = apbabl.ITEM_ID
							AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE, REC_DTL_ID
	
	-- Bill Hold E/T with comments
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, QTY_HRS, BA_ID, VERSION_SEQ,
				UNBILLED_NET, UNBILLED_MU, UNBILLED_TAX, UNBILLED_NR, UNBILLED_TOT, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( QTY_HRS ), 0 ), MAX( BA_ID ), VERSION_SEQ,
				COALESCE( SUM( NET ), 0.00 ), COALESCE( SUM( COMMISSION ), 0.00 ), COALESCE( SUM( RESALE_TAX ), 0.00 ),
				COALESCE( SUM( VENDOR_TAX ), 0.00 ), COALESCE( SUM( LINE_TOTAL ), 0.00 ), VAL_TYPE, REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Bill Hold', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabl
		  WHERE SOURCE = 'Actual' 
			AND VAL_TYPE = 'Bill Hold'
			AND FNC_TYPE = 'E'
			AND EXISTS ( SELECT * 
						   FROM dbo.EMP_TIME_DTL_CMTS etdc
						  WHERE etdc.ET_ID = apbabl.ITEM_ID
							AND etdc.ET_SOURCE = 'D' )
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VERSION_SEQ, VAL_TYPE, REC_DTL_ID
	
	-- Puchase Orders
	INSERT INTO @prod_unbilled_item( ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, PO, VAL_TYPE, REC_DTL_ID )
		 SELECT ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, COALESCE( SUM( NET ), 0.00 ), VAL_TYPE, REC_DTL_ID
		   FROM dbo.advtf_prod_bill_amts_by_line( @job_number, @job_component_nbr, 'Open PO', @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
		  WHERE SOURCE = 'PO' 
		    AND VAL_TYPE = 'Open PO'
	   GROUP BY ITEM_ID, SEQ_NBR, FNC_CODE, FNC_TYPE, SOURCE, VAL_TYPE, REC_DTL_ID

	-- Get the extra information necessary based on the max seq
			UPDATE @prod_unbilled_item
			   SET NAME = ( COALESCE( RTRIM( e.EMP_FNAME ) + ' ', '' ) + COALESCE( e.EMP_MI + '. ', '' ) + COALESCE( e.EMP_LNAME, '' )), 
				   ITEM_DATE = et.EMP_DATE,
				   COMMENTS = etdc.EMP_COMMENT
			  FROM @prod_unbilled_item pui
		INNER JOIN dbo.EMP_TIME_DTL etd
			    ON ( pui.ITEM_ID = etd.ET_ID )
			   AND ( pui.SEQ_NBR = etd.SEQ_NBR )
		INNER JOIN dbo.EMP_TIME et
			    ON ( etd.ET_ID = et.ET_ID )
		INNER JOIN dbo.EMPLOYEE e
				ON ( et.EMP_CODE = e.EMP_CODE )
   LEFT OUTER JOIN dbo.EMP_TIME_DTL_CMTS etdc
				ON ( etd.ET_ID = etdc.ET_ID )
			   AND ( etd.ET_DTL_ID = etdc.ET_DTL_ID )
			   AND ( etdc.ET_SOURCE = 'D' )
			 WHERE SOURCE = 'Actual'
			   AND FNC_TYPE = 'E'

			UPDATE @prod_unbilled_item
			   SET NAME = VN_NAME,
				   ITEM_DATE = aph.AP_INV_DATE,
				   INV_NBR = aph.AP_INV_VCHR,
				   COMMENTS = appc.AP_COMMENT
			  FROM @prod_unbilled_item pui
		INNER JOIN dbo.AP_PRODUCTION app
			    ON ( pui.ITEM_ID = app.AP_ID )
			   AND ( pui.SEQ_NBR = app.LINE_NUMBER )
		INNER JOIN dbo.AP_HEADER aph
			    ON ( app.AP_ID = aph.AP_ID )
	    INNER JOIN dbo.VENDOR v
				ON ( aph.VN_FRL_EMP_CODE = v.VN_CODE )
   LEFT OUTER JOIN dbo.AP_PROD_COMMENTS appc
				ON ( app.AP_ID = appc.AP_ID )
			   AND ( app.LINE_NUMBER = appc.LINE_NUMBER )
			 WHERE SOURCE = 'Actual'
			   AND FNC_TYPE = 'V'

			UPDATE @prod_unbilled_item
			   SET NAME = COALESCE( io.IO_DESC, f.FNC_DESCRIPTION ),
				   ITEM_DATE = io.IO_INV_DATE,
				   INV_NBR = io.IO_INV_NBR,
				   COMMENTS = io.IO_COMMENT
			  FROM @prod_unbilled_item pui
		INNER JOIN dbo.INCOME_ONLY io
			    ON ( pui.ITEM_ID = io.IO_ID )
			   AND ( pui.SEQ_NBR = io.SEQ_NBR )
		INNER JOIN dbo.FUNCTIONS f
				ON ( io.FNC_CODE = f.FNC_CODE )
			 WHERE SOURCE = 'Actual'
			   AND pui.FNC_TYPE = 'I'

			UPDATE @prod_unbilled_item
			   SET NAME = ISNULL(ven.VN_NAME, po.PO_DESCRIPTION),
				   ITEM_DATE = po.PO_DATE,
				   INV_NBR = CONVERT( varchar(60), pod.PO_NUMBER ),
				   COMMENTS = pod.LINE_DESC
			  FROM @prod_unbilled_item pui
		INNER JOIN dbo.PURCHASE_ORDER_DET pod
			    ON ( pui.ITEM_ID = pod.PO_NUMBER )
			   AND ( pui.SEQ_NBR = pod.LINE_NUMBER )
		INNER JOIN dbo.PURCHASE_ORDER po
				ON ( pod.PO_NUMBER = po.PO_NUMBER )
		LEFT OUTER JOIN dbo.VENDOR ven
				ON ( po.VN_CODE = ven.VN_CODE )
			 WHERE SOURCE = 'PO'
			   AND pui.FNC_TYPE = 'V'

RETURN
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

