CREATE FUNCTION [dbo].[advtf_get_billing_function_var] ( @billing_user varchar(100) )
RETURNS @VARIANCE TABLE ( 
	AR_FUNCTION_ID				integer NOT NULL,											-- BJL 11/21/2013
	JOB_NUMBER					integer NOT NULL, 
	JOB_COMPONENT_NBR			smallint NULL,
	FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		-- BJL 02/13/2013 - Changed to allow NULLs (for income recognition)
	TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RECONCILE_ROW				smallint NULL,												-- BJL 04/01/2013
	EMP_TIME_AMT				decimal(18,2) NULL,											-- Employee Time plus its markup
	INC_ONLY_AMT				decimal(18,2) NULL,											-- Income Only plus its markup
	COMMISSION_AMT				decimal(18,2) NULL,											-- Commission for the vendor amount
	NON_RESALE_AMT				decimal(18,2) NULL,											-- BJL 11/19/2013
	COST_AMT					decimal(18,2) NULL,											-- Cost Amount for Production or Media
	AB_COST_AMT					decimal(18,2) NULL,											-- AB Prod Cost Amount
	AB_INC_AMT					decimal(18,2) NULL,											-- AB Prod Income Amount (Time or Income Only plus their markup)
	AB_COMMISSION_AMT			decimal(18,2) NULL,											-- AB Prod Commission (for Vendor Functions)
	AB_SALE_AMT					decimal(18,2) NULL,											-- This will be for AB Flag of 5 entries only.  It will use the normal Sales Account.
	AB_NONRESALE_AMT			decimal(18,2) NULL,											-- BJL 11/20/2013
	CITY_TAX_AMT				decimal(18,2) NULL,											-- Resale City
	CNTY_TAX_AMT				decimal(18,2) NULL,											-- Resale County 
	STATE_TAX_AMT				decimal(18,2) NULL,											-- Resale State
	TOTAL_BILL					decimal(18,2) NULL											-- Total Billing Amount, should be all amounts totaled.
)
AS
-- MJC 11/17/2017 - Note: function in source repository did NOT match the function in production!
-- BJL 11/21/2013 - Changed joins as a result of the SUMMARY_ROW_ID addition
-- BJL 11/20/2013 - Added @VARIANCE.AB_NONRESALE_AMT
-- BJL 11/19/2013 - Added @VARIANCE.NON_RESALE_AMT
-- BJL 11/16/2012 - Added @VARIANCE.JOB_COMPONENT_NBR
-- BJL 11/15/2012 - Added @VARIANCE.FROM_ADV

BEGIN

	INSERT INTO @VARIANCE( AR_FUNCTION_ID, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, RECONCILE_ROW, TAX_CODE, EMP_TIME_AMT, INC_ONLY_AMT, COMMISSION_AMT, COST_AMT, 
				AB_COST_AMT, AB_INC_AMT, AB_COMMISSION_AMT, AB_SALE_AMT, AB_NONRESALE_AMT, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, NON_RESALE_AMT, TOTAL_BILL )
		 SELECT AR_FUNCTION_ID, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, RECONCILE_ROW, TAX_CODE, EMP_TIME_AMT, INC_ONLY_AMT, COMMISSION_AMT, COST_AMT, 
				AB_COST_AMT, AB_INC_AMT, AB_COMMISSION_AMT, AB_SALE_AMT, AB_NONRESALE_AMT, CITY_TAX_AMT, CNTY_TAX_AMT, STATE_TAX_AMT, NON_RESALE_AMT, TOTAL_BILL
		   FROM dbo.W_AR_FUNCTION
		  WHERE ( FNC_TYPE <> 'R' )
			AND ( BILLING_USER = @billing_user )
		    AND ( SUMMARY_FLAG = 1 )
		 
	 UPDATE @VARIANCE
	    SET EMP_TIME_AMT = ( v.EMP_TIME_AMT - ( SELECT COALESCE( SUM( COALESCE( af.EMP_TIME_AMT, 0.00 )), 0.00 )
												  FROM dbo.W_AR_FUNCTION af
												 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
												   AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v

	 UPDATE @VARIANCE
	    SET INC_ONLY_AMT = ( v.INC_ONLY_AMT - ( SELECT COALESCE( SUM( COALESCE( af.INC_ONLY_AMT, 0.00 )), 0.00 )
												  FROM dbo.W_AR_FUNCTION af
												 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
												   AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v												   

	 UPDATE @VARIANCE
	    SET COMMISSION_AMT = ( v.COMMISSION_AMT - ( SELECT COALESCE( SUM( COALESCE( af.COMMISSION_AMT, 0.00 )), 0.00 )
													  FROM dbo.W_AR_FUNCTION af
													 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
													   AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v
	   
	 UPDATE @VARIANCE
	    SET COST_AMT = ( v.COST_AMT - ( SELECT COALESCE( SUM( COALESCE( af.COST_AMT, 0.00 )), 0.00 )
										  FROM dbo.W_AR_FUNCTION af
										 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
										   AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v
	    
	 UPDATE @VARIANCE
	    SET AB_COST_AMT = ( v.AB_COST_AMT - ( SELECT COALESCE( SUM( COALESCE( af.AB_COST_AMT, 0.00 )), 0.00 )
												FROM dbo.W_AR_FUNCTION af
											   WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
												 AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v

	 UPDATE @VARIANCE
	    SET AB_INC_AMT = ( v.AB_INC_AMT - ( SELECT COALESCE( SUM( COALESCE( af.AB_INC_AMT, 0.00 )), 0.00 )
											  FROM dbo.W_AR_FUNCTION af
											 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
											   AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v

	 UPDATE @VARIANCE
	    SET AB_COMMISSION_AMT = ( v.AB_COMMISSION_AMT - ( SELECT COALESCE( SUM( COALESCE( af.AB_COMMISSION_AMT, 0.00 )), 0.00 )
															FROM dbo.W_AR_FUNCTION af
														   WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
															 AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v

	 UPDATE @VARIANCE
	    SET AB_SALE_AMT = ( v.AB_SALE_AMT - ( SELECT COALESCE( SUM( COALESCE( af.AB_SALE_AMT, 0.00 )), 0.00 )
												FROM dbo.W_AR_FUNCTION af
											   WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
												 AND ( af.SUMMARY_FLAG = 0 )))
	   FROM @VARIANCE v

	IF (SELECT INV_TAX_FLAG FROM dbo.AGENCY) = 1 BEGIN

		UPDATE @VARIANCE SET STATE_TAX_AMT = 0
		FROM @VARIANCE

		UPDATE @VARIANCE SET CNTY_TAX_AMT = 0
		FROM @VARIANCE

		UPDATE @VARIANCE SET CITY_TAX_AMT = 0
		FROM @VARIANCE

		UPDATE @VARIANCE SET TOTAL_BILL = 0
		FROM @VARIANCE

	END ELSE BEGIN

		UPDATE @VARIANCE
	    SET STATE_TAX_AMT = ( v.STATE_TAX_AMT - ( SELECT COALESCE( SUM( COALESCE( af.STATE_TAX_AMT, 0.00 )), 0.00 )
												    FROM dbo.W_AR_FUNCTION af
												   WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
													 AND ( af.SUMMARY_FLAG = 0 )))
		FROM @VARIANCE v

		UPDATE @VARIANCE
	    SET CNTY_TAX_AMT = ( v.CNTY_TAX_AMT - ( SELECT COALESCE( SUM( COALESCE( af.CNTY_TAX_AMT, 0.00 )), 0.00 )
												  FROM dbo.W_AR_FUNCTION af
												 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
												   AND ( af.SUMMARY_FLAG = 0 )))
		FROM @VARIANCE v

		UPDATE @VARIANCE
	    SET CITY_TAX_AMT = ( v.CITY_TAX_AMT - ( SELECT COALESCE( SUM( COALESCE( af.CITY_TAX_AMT, 0.00 )), 0.00 )
												  FROM dbo.W_AR_FUNCTION af
												 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
												   AND ( af.SUMMARY_FLAG = 0 )))
		FROM @VARIANCE v

		UPDATE @VARIANCE
	    SET TOTAL_BILL = ( v.TOTAL_BILL - ( SELECT COALESCE( SUM( COALESCE( af.TOTAL_BILL, 0.00 )), 0.00 )
											  FROM dbo.W_AR_FUNCTION af
											 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
											   AND ( af.SUMMARY_FLAG = 0 )))
		FROM @VARIANCE v

	END
	
		-- BJL 11/19/2013
		UPDATE @VARIANCE
	    SET NON_RESALE_AMT = ( v.NON_RESALE_AMT - ( SELECT COALESCE( SUM( COALESCE( af.NON_RESALE_AMT, 0.00 )), 0.00 )
													  FROM dbo.W_AR_FUNCTION af
													 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
													   AND ( af.SUMMARY_FLAG = 0 )))
		FROM @VARIANCE v

		-- BJL 11/20/2013
		UPDATE @VARIANCE
	    SET AB_NONRESALE_AMT = ( v.AB_NONRESALE_AMT - ( SELECT COALESCE( SUM( COALESCE( af.AB_NONRESALE_AMT, 0.00 )), 0.00 )
														  FROM dbo.W_AR_FUNCTION af
														 WHERE ( af.SUMMARY_ROW_ID = v.AR_FUNCTION_ID )
														   AND ( af.SUMMARY_FLAG = 0 )))
		FROM @VARIANCE v

	DELETE FROM @VARIANCE 
	 WHERE ( EMP_TIME_AMT IS NULL OR EMP_TIME_AMT = 0.00 ) 
	   AND ( INC_ONLY_AMT IS NULL OR INC_ONLY_AMT = 0.00 ) 
	   AND ( COMMISSION_AMT IS NULL OR COMMISSION_AMT = 0.00 ) 
	   AND ( COST_AMT IS NULL OR COST_AMT = 0.00 ) 	   
	   AND ( AB_COST_AMT IS NULL OR AB_COST_AMT = 0.00 ) 	   
	   AND ( AB_INC_AMT IS NULL OR AB_INC_AMT = 0.00 ) 	   
	   AND ( AB_COMMISSION_AMT IS NULL OR AB_COMMISSION_AMT = 0.00 ) 
	   AND ( AB_SALE_AMT IS NULL OR AB_SALE_AMT = 0.00 ) 	   
	   AND ( STATE_TAX_AMT IS NULL OR STATE_TAX_AMT = 0.00 ) 
	   AND ( CNTY_TAX_AMT IS NULL OR CNTY_TAX_AMT = 0.00 ) 
	   AND ( CITY_TAX_AMT IS NULL OR CITY_TAX_AMT = 0.00 ) 
	   AND ( NON_RESALE_AMT IS NULL OR NON_RESALE_AMT = 0.00 )
	   AND ( AB_NONRESALE_AMT IS NULL OR AB_NONRESALE_AMT = 0.00 )
	   AND ( TOTAL_BILL IS NULL OR TOTAL_BILL = 0.00 ) 	   

	RETURN
END

GO
