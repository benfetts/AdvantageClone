--DROP FUNCTION dbo.advtf_prod_bill_amts_by_fnc
CREATE FUNCTION dbo.advtf_prod_bill_amts_by_fnc
( @job_number integer, @job_component_nbr smallint, @date_cutoff smalldatetime, @post_period varchar(6), @excl_nobill bit, @excl_fee bit )
RETURNS @prod_bill_fnc TABLE ( 
	FNC_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
	FNC_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL, 
	QUOTE					decimal(15,2) NULL,
	ACTUALS					decimal(15,2) NULL,
	BILLED					decimal(15,2) NULL, 
	UNBILLED				decimal(15,2) NULL, 
	BILL_HOLD				decimal(15,2) NULL,
	NONBILL					decimal(15,2) NULL,
	PO						decimal(15,2) NULL,
	QUOTE_NET				decimal(15,2) NULL,
	QUOTE_MARKUP			decimal(15,2) NULL,
	QUOTE_RESALE_TAX		decimal(15,2) NULL,
	QUOTE_VENDOR_TAX		decimal(15,2) NULL,
	UNBILLED_NET			decimal(15,2) NULL,
	UNBILLED_MARKUP			decimal(15,2) NULL,
	UNBILLED_RESALE_TAX		decimal(15,2) NULL,
	UNBILLED_VENDOR_TAX		decimal(15,2) NULL,
	QTY_HRS					decimal(15,2) NULL,
	QUOTE_QTY_HRS			decimal(15,2) NULL )
AS
BEGIN

	INSERT INTO @prod_bill_fnc( FNC_CODE, FNC_TYPE, QUOTE, BILLED, UNBILLED, BILL_HOLD, NONBILL, PO, 
								QUOTE_NET, QUOTE_MARKUP, QUOTE_RESALE_TAX, QUOTE_VENDOR_TAX, 
								UNBILLED_NET, UNBILLED_MARKUP, UNBILLED_RESALE_TAX, UNBILLED_VENDOR_TAX, QTY_HRS, QUOTE_QTY_HRS )
		 SELECT FNC_CODE, FNC_TYPE, COALESCE( SUM( QUOTE_TOT ), 0.00 ), COALESCE( SUM( BILLED_TOT ), 0.00 ), COALESCE( SUM( UNBILLED_TOT ), 0.00 ), 
				COALESCE( SUM( BILL_HOLD_TOT ), 0.00 ), COALESCE( SUM( NONBILL_TOT ), 0.00 ), COALESCE( SUM( PO ), 0.00 ),
				COALESCE( SUM( QUOTE_NET ), 0.00 ), COALESCE( SUM( QUOTE_MU ), 0.00 ), 
				COALESCE( SUM( QUOTE_TAX ), 0.00 ), COALESCE( SUM( QUOTE_NR ), 0.00 ),
				COALESCE( SUM( UNBILLED_NET ), 0.00 ), COALESCE( SUM( UNBILLED_MU ), 0.00 ), 
				COALESCE( SUM( UNBILLED_TAX ), 0.00 ), COALESCE( SUM( UNBILLED_NR ), 0.00 ), 
				COALESCE( SUM( QTY_HRS ), 0.00 ), COALESCE( SUM( QUOTE_QTY_HRS ), 0.00 )
		   FROM dbo.advtf_prod_bill_amts_by_item( @job_number, @job_component_nbr, @date_cutoff, @post_period, @excl_nobill, @excl_fee ) 
	   GROUP BY FNC_CODE, FNC_TYPE

		 UPDATE @prod_bill_fnc
		    SET ACTUALS = ( SELECT COALESCE( SUM( apbabi.BILLED_TOT ), 0.00 ) + COALESCE( SUM( apbabi.UNBILLED_TOT ), 0.00 )
							  FROM dbo.advtf_prod_bill_amts_by_item( @job_number, @job_component_nbr, @date_cutoff, @post_period, @excl_nobill, @excl_fee ) apbabi
							 WHERE ( apbabi.FNC_TYPE = pbf.FNC_TYPE )
							   AND ( apbabi.FNC_CODE = pbf.FNC_CODE )
							   AND ( apbabi.SOURCE = 'Actual' ))
		  FROM @prod_bill_fnc pbf

RETURN
END
