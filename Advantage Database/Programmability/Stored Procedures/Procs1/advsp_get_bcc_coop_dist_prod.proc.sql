IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_get_bcc_coop_dist_prod]' ) AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_get_bcc_coop_dist_prod]
GO

CREATE PROCEDURE [dbo].[advsp_get_bcc_coop_dist_prod] @billing_user_in varchar(100), @job_number int, @job_component_nbr smallint
AS

-- ****************************************************************************************************************************************************
-- advsp_get_bcc_coop_dist_prod - Retrieves rows currently in W_AR_FUNCTION table 
-- BJL 11/16/2012 - Restored JOB_COMPONENT and JOB_COMP_DESC
-- BJL 04/12/2013 - Added NP_COOP_SPLIT, CMP_IDENTIFIER
-- BJL 04/18/2013 - Exclude interim reconciliations	
-- BJL 11/19/2013 - Nonresale tax split from cost
-- BJL 11/20/2013 - Added AB_NONRESALE_AMT
-- MJC 07/23/2015 - removed variables & check for invoices already assigned and billing user exists before calling this procedure
-- ****************************************************************************************************************************************************

SET NOCOUNT ON

-- For an item to be editable in the co-op distribution screen, it must...
-- (1) be on a co-op job with more than 1 C/D/P 
-- (2) not be part of a taxed function (at the detail level)
-- (3) be on a job with an AB_FLAG of 0 or 2					<-- Remove?
-- (4) not be 'multi-row'

DECLARE @PROD_COOP_DIST TABLE ( 
	AR_FUNCTION_ID				integer NOT NULL,
	JOB_NUMBER					integer NOT NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	JOB_COMP_DESC				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,			-- BJL 02/12/2013 - Changed to allow for NULL (income recognition)
	FNC_DESC					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
	FNC_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,	
	COOP_PCT					decimal(9,4) NULL,
	CC_COOP_PCT					decimal(9,4) NULL,
	COST_AMT					decimal(18,2) NULL,		
	CC_COST_AMT					decimal(18,2) NULL,
	INC_AMT						decimal(18,2) NULL,			
	CC_INC_AMT					decimal(18,2) NULL,
	TAX_CODE					varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DTL_TAX_FLAG				bit NULL,
	INV_TAX_FLAG				bit NULL,														-- BJL 05/13/2013
	COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,	
	COST_PCT					decimal(9,4) NULL,
	INC_PCT						decimal(9,4) NULL,	
	JOB_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_AB_FLAG					tinyint NULL,
	SUMMARY_FLAG				bit NULL,
	FROM_ADV					bit NULL,
	EMP_TIME_AMT				decimal(18,2) NULL,
	INC_ONLY_AMT				decimal(18,2) NULL,
	AB_INC_AMT					decimal(18,2) NULL,
	AB_COST_AMT					decimal(18,2) NULL,
	COMMISSION_AMT				decimal(18,2) NULL,
	AB_COMMISSION_AMT			decimal(18,2) NULL,
	AB_SALE_AMT					decimal(18,2) NULL,
	AB_NONRESALE_AMT			decimal(18,2) NULL,												-- BJL 11/20/2013
	STATE_TAX_AMT				decimal(18,2) NULL,
	COUNTY_TAX_AMT				decimal(18,2) NULL,
	CITY_TAX_AMT				decimal(18,2) NULL,
	NON_RESALE_AMT				decimal(18,2) NULL,												-- BJL 11/19/2013
	TOTAL_BILL					decimal(18,2) NULL,
	MODIFIED_FLAG				bit NULL,
	CC_BALANCED_FLAG			bit NULL,
	CC_AMOUNT_MODIFIED			bit NULL,
	CC_VAR						decimal(18,2) NULL,
	CC_INTERIM_RECON			bit NULL,														-- BJL 04/18/2013 - Exclude interim reconciliations	
	FNC_ROW_COUNT				integer NULL,
	NP_COOP_SPLIT				smallint NULL,
	CMP_IDENTIFIER				integer NULL,
	SUMMARY_ROW_ID				integer NULL													-- BJL 11/21/2013
)

	INSERT INTO @PROD_COOP_DIST ( 
				AR_FUNCTION_ID, 
				JOB_NUMBER, 
				JOB_COMPONENT_NBR, 
				JOB_COMP_DESC, 
				CL_CODE, 
				DIV_CODE, 
				PRD_CODE,
				FNC_CODE, 
				FNC_DESC, 
				FNC_TYPE, 
				COOP_PCT, 
				CC_COOP_PCT, 
				COST_AMT, 
				CC_COST_AMT, 
				INC_AMT, 
				CC_INC_AMT, 
				TAX_CODE, 
				DTL_TAX_FLAG, 
				INV_TAX_FLAG,
				COOP_CODE, 
				COST_PCT, 
				INC_PCT, 
				JOB_DESC, 
				JOB_AB_FLAG, 
				SUMMARY_FLAG, 
				FROM_ADV, 
				EMP_TIME_AMT, 
				INC_ONLY_AMT, 
				AB_INC_AMT,
				AB_COST_AMT, 
				COMMISSION_AMT, 
				AB_COMMISSION_AMT, 
				AB_SALE_AMT,
				AB_NONRESALE_AMT, 
				STATE_TAX_AMT, 
				COUNTY_TAX_AMT, 
				CITY_TAX_AMT, 
				NON_RESALE_AMT,
				TOTAL_BILL,
				MODIFIED_FLAG, 
				CC_BALANCED_FLAG, 
				CC_AMOUNT_MODIFIED, 
				CC_VAR, 
				CC_INTERIM_RECON,
				NP_COOP_SPLIT, 
				CMP_IDENTIFIER,
				SUMMARY_ROW_ID )
		 SELECT af.AR_FUNCTION_ID, 
				af.JOB_NUMBER, 
				af.JOB_COMPONENT_NBR, 
				jc.JOB_COMP_DESC, 
				af.CL_CODE, 
				af.DIV_CODE, 
				af.PRD_CODE, 
				af.FNC_CODE, 
				CASE af.FNC_TYPE 
					WHEN 'R' THEN 'Income recognition'
					ELSE f.FNC_DESCRIPTION
				END, 
				af.FNC_TYPE, 
				af.COOP_PCT, 
				NULL, 
				af.COST_AMT, 
				--COALESCE( af.COST_AMT, af.AB_COST_AMT, NULL ), 
				CASE 
					WHEN ( af.COST_AMT = COALESCE( af.COST_AMT, 0.00 ) + COALESCE( af.AB_COST_AMT, 0.00 )) THEN ( af.COST_AMT + af.NON_RESALE_AMT )
					WHEN ( af.AB_COST_AMT = COALESCE( af.COST_AMT, 0.00 ) + COALESCE( af.AB_COST_AMT, 0.00 )) THEN ( af.AB_COST_AMT + af.AB_NONRESALE_AMT )
					ELSE NULL
				END,
				NULL, 
--				COALESCE( af.EMP_TIME_AMT, af.INC_ONLY_AMT, af.COMMISSION_AMT, af.AB_INC_AMT, af.AB_COMMISSION_AMT, NULL ), 
				CASE 
					WHEN ( af.EMP_TIME_AMT      = COALESCE( af.EMP_TIME_AMT, 0.00 ) 
												+ COALESCE( af.INC_ONLY_AMT, 0.00 ) 
												+ COALESCE( af.COMMISSION_AMT, 0.00 ) 
												+ COALESCE( af.AB_INC_AMT, 0.00 ) 
												+ COALESCE( af.AB_COMMISSION_AMT, 0.00 )) THEN af.EMP_TIME_AMT
					WHEN ( af.INC_ONLY_AMT      = COALESCE( af.EMP_TIME_AMT, 0.00 ) 
												+ COALESCE( af.INC_ONLY_AMT, 0.00 ) 
												+ COALESCE( af.COMMISSION_AMT, 0.00 ) 
												+ COALESCE( af.AB_INC_AMT, 0.00 ) 
												+ COALESCE( af.AB_COMMISSION_AMT, 0.00 )) THEN af.INC_ONLY_AMT
					WHEN ( af.COMMISSION_AMT    = COALESCE( af.EMP_TIME_AMT, 0.00 ) 
												+ COALESCE( af.INC_ONLY_AMT, 0.00 ) 
												+ COALESCE( af.COMMISSION_AMT, 0.00 ) 
												+ COALESCE( af.AB_INC_AMT, 0.00 ) 
												+ COALESCE( af.AB_COMMISSION_AMT, 0.00 )) THEN af.COMMISSION_AMT
					WHEN ( af.AB_INC_AMT        = COALESCE( af.EMP_TIME_AMT, 0.00 ) 
												+ COALESCE( af.INC_ONLY_AMT, 0.00 ) 
												+ COALESCE( af.COMMISSION_AMT, 0.00 ) 
												+ COALESCE( af.AB_INC_AMT, 0.00 ) 
												+ COALESCE( af.AB_COMMISSION_AMT, 0.00 )) THEN af.AB_INC_AMT
					WHEN ( af.AB_COMMISSION_AMT = COALESCE( af.EMP_TIME_AMT, 0.00 ) 
												+ COALESCE( af.INC_ONLY_AMT, 0.00 ) 
												+ COALESCE( af.COMMISSION_AMT, 0.00 ) 
												+ COALESCE( af.AB_INC_AMT, 0.00 ) 
												+ COALESCE( af.AB_COMMISSION_AMT, 0.00 )) THEN af.AB_COMMISSION_AMT
					ELSE NULL
				END,
				af.TAX_CODE, 
				CASE 
					-- BJL 11/20/2013
				  --WHEN ( af.INV_TAX_FLAG = 1 ) THEN 0  
				  --WHEN ( af.TAX_CODE IS NULL ) THEN 0
				  --ELSE 1 
					WHEN ( af.NON_RESALE_AMT <> 0.00 ) THEN 1
					WHEN ( af.AB_NONRESALE_AMT <> 0.00 ) THEN 1
					WHEN ( af.INV_TAX_FLAG = 0 AND af.STATE_TAX_AMT <> 0.00 ) THEN 1
					WHEN ( af.INV_TAX_FLAG = 0 AND af.CNTY_TAX_AMT <>  0.00 ) THEN 1
					WHEN ( af.INV_TAX_FLAG = 0 AND af.CITY_TAX_AMT <> 0.00 ) THEN 1
					ELSE 0
				END, 
				af.INV_TAX_FLAG,	
				af.COOP_CODE, 
				NULL, 
				NULL, 
				jl.JOB_DESC, 
				af.JOB_AB_FLAG, 
				af.SUMMARY_FLAG, 
				NULL, 
				af.EMP_TIME_AMT, 
				af.INC_ONLY_AMT, 
				af.AB_INC_AMT, 
				af.AB_COST_AMT, 
				af.COMMISSION_AMT, 
				af.AB_COMMISSION_AMT, 
				af.AB_SALE_AMT, 
				af.AB_NONRESALE_AMT,
				af.STATE_TAX_AMT, 
				af.CNTY_TAX_AMT, 
				af.CITY_TAX_AMT,
				af.NON_RESALE_AMT, 
				af.TOTAL_BILL, 
				af.MODIFIED_FLAG, 
				CAST( NULL AS smallint ) AS cc_balanced_flag, 
				CAST( 0 AS smallint ) AS cc_amount_modified, 
				CAST( 0 AS decimal(15,2)) AS cc_var,
				CASE WHEN ( af.SUMMARY_FLAG = 1 AND af.TOTAL_BILL = 0.00 ) THEN 1 ELSE 0 END,
				jl.NP_COOP_SPLIT, 
				af.CMP_IDENTIFIER,
				af.SUMMARY_ROW_ID
		   FROM dbo.W_AR_FUNCTION af 
	 INNER JOIN dbo.JOB_LOG jl
			 ON ( af.JOB_NUMBER = jl.JOB_NUMBER )
	 INNER JOIN dbo.JOB_COMPONENT jc
			 ON ( jl.JOB_NUMBER = jc.JOB_NUMBER )
			AND ( af.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR )
LEFT OUTER JOIN dbo.FUNCTIONS f
			 ON ( af.FNC_CODE = f.FNC_CODE /* OR ( af.FNC_CODE IS NULL AND f.FNC_CODE IS NULL ) */ )  	 
 		  WHERE af.BILLING_USER = @billing_user_in
		  AND	af.JOB_NUMBER = @job_number
		  AND	af.JOB_COMPONENT_NBR = @job_component_nbr
 		  	
	UPDATE p
	   SET FNC_ROW_COUNT = ( SELECT COUNT( p2.AR_FUNCTION_ID )
							   FROM @PROD_COOP_DIST p2
							  WHERE ( p.JOB_NUMBER = p2.JOB_NUMBER )
								AND ( p.JOB_COMPONENT_NBR = p2.JOB_COMPONENT_NBR )
								AND ( p.CL_CODE = p2.CL_CODE )
								AND ( p.DIV_CODE = p2.DIV_CODE )
								AND ( p.PRD_CODE = p2.PRD_CODE )
								AND ( p.FNC_TYPE = p2.FNC_TYPE )
								AND (( p.FNC_CODE = p2.FNC_CODE ) /* OR ( p.FNC_TYPE = 'R' AND p2.FNC_TYPE = 'R' ) */ )
								AND ( p2.SUMMARY_FLAG = 0 )
								AND ( p.COOP_CODE IS NOT NULL ))
      FROM @PROD_COOP_DIST p
     WHERE ( p.SUMMARY_FLAG = 0 )
       AND ( p.COOP_CODE IS NOT NULL )

	-- BJL 04/18/2013 - Exclude interim reconciliations	
	UPDATE p1
	   SET CC_INTERIM_RECON = 1
      FROM @PROD_COOP_DIST p1 INNER JOIN @PROD_COOP_DIST p2
        ON ( p1.JOB_NUMBER = p2.JOB_NUMBER )
       AND ( p1.JOB_COMPONENT_NBR = p2.JOB_COMPONENT_NBR )
       AND ( p1.FNC_CODE = p2.FNC_CODE )
       AND ( p1.FNC_TYPE = p2.FNC_TYPE )
     WHERE ( p1.SUMMARY_FLAG = 0 )
       AND ( p2.SUMMARY_FLAG = 1 )
       AND ( p1.COOP_CODE IS NOT NULL )
       AND ( p2.CC_INTERIM_RECON = 1 )

-- ******************************************************************************************************************************
--		OUTPUT
-- ******************************************************************************************************************************

	 SELECT [WorkARFunctionID] = AR_FUNCTION_ID, 
			[JobNumber] = PCD.JOB_NUMBER, 
			[JobComponentNumber] = PCD.JOB_COMPONENT_NBR, 
			[JobComponentDescription] = JOB_COMP_DESC, 
			[ClientCode] = PCD.CL_CODE, 
			[DivisionCode] = PCD.DIV_CODE, 
			[ProductCode] = PCD.PRD_CODE,
			[FunctionCode] = FNC_CODE, 
			[FunctionDescription] = FNC_DESC, 
			[FunctionType] = FNC_TYPE, 
			[CoopPercent] = COOP_PCT, 
			--[CCCoopPercent] = CC_COOP_PCT, 
			[CostAmount] = COST_AMT, 
			[CCCostAmount] = CC_COST_AMT, 
			[IncomeAmount] = INC_AMT, 
			[CCIncomeAmount] = CC_INC_AMT, 
			[SalesTaxCode] = TAX_CODE, 
			[DetailTaxFlag] = DTL_TAX_FLAG, 
			[InvoiceTaxFlag] = INV_TAX_FLAG, 
			[CoopCode] = COOP_CODE, 
			[CostPercent] = COST_PCT, 
			[IncomePercent] = INC_PCT, 
			[JobDescription] = JOB_DESC, 
			[JobAdvanceBillingFlag] = JOB_AB_FLAG, 
			[IsSummaryFlag] = SUMMARY_FLAG, 
			[FromAdv] = FROM_ADV, 
			[EmployeeTimeAmount] = EMP_TIME_AMT, 
			[IncomeOnlyAmount] = INC_ONLY_AMT, 
			[AdvanceBillIncomeAmount] = AB_INC_AMT, 
			[AdvanceBillCostAmount] = AB_COST_AMT, 
			[MarkupAmount] = COMMISSION_AMT, 
			[AdvanceBillMarkupAmount] = AB_COMMISSION_AMT, 
			[AdvanceBillSaleAmount] = AB_SALE_AMT, 
			[AdvanceBillNonResaleTaxAmount] = AB_NONRESALE_AMT,
			[StateTaxAmount] = STATE_TAX_AMT, 
			[CountyTaxAmount] = COUNTY_TAX_AMT, 
			[CityTaxAmount] = CITY_TAX_AMT, 
			[NonResaleTaxAmount] = NON_RESALE_AMT,
			[TotalBill] = TOTAL_BILL, 
			[IsModified] = MODIFIED_FLAG, 
			[CCBalancedFlag] = CC_BALANCED_FLAG, 
			[CCAmountModified] = CC_AMOUNT_MODIFIED, 
			[CCVariance] = CC_VAR, 
			[CCInterimReconcile] = CC_INTERIM_RECON,
			[FunctionRowCount] = FNC_ROW_COUNT, 
			[NewspaperCoopSplit] = NP_COOP_SPLIT, 
			[CampaignID] = PCD.CMP_IDENTIFIER,
			[SummaryRowId] = SUMMARY_ROW_ID,
			[ClientName] = C.CL_NAME,
			[DivisionName] = D.DIV_NAME,
			[ProductName] = P.PRD_DESCRIPTION,
			[CampaignCode] = CMP.CMP_CODE,
			[CampaignName] = CMP.CMP_NAME
	   FROM @PROD_COOP_DIST PCD
	    LEFT OUTER JOIN dbo.CLIENT C ON PCD.CL_CODE = C.CL_CODE
		LEFT OUTER JOIN dbo.DIVISION D ON PCD.CL_CODE = D.CL_CODE AND PCD.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON PCD.CL_CODE = P.CL_CODE AND PCD.DIV_CODE = P.DIV_CODE AND PCD.PRD_CODE = P.PRD_CODE
		LEFT OUTER JOIN dbo.CAMPAIGN CMP ON PCD.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER
GO