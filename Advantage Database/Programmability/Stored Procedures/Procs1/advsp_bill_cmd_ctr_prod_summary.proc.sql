CREATE PROCEDURE [dbo].[advsp_bill_cmd_ctr_prod_summary] @job_number_in integer, @job_component_nbr_in smallint, @et_date_cutoff_in smalldatetime, 
	@io_date_cutoff_in smalldatetime, @ab_date_cutoff_in smalldatetime, @ap_pp_cutoff_in varchar(6), @ret_val integer OUTPUT
AS

SET NOCOUNT ON
SET ARITHABORT OFF
SET ANSI_WARNINGS OFF

DECLARE @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6), @job_desc varchar(60), @job_comp_desc varchar(60) 
DECLARE @items_to_bill_ind smallint, @service_fee smallint, @recon_lock bit, @trf_code varchar(10), @appr_amt decimal(15,2)
DECLARE @adv_bill bit, @adv_unbilled decimal(15,2), @adv_billed decimal(15,2), @est_appr_date smalldatetime, @billing_user varchar(100)
DECLARE @est_nbr integer, @est_comp_nbr smallint, @est_qte_nbr smallint, @est_rev_nbr smallint, @job_comp_date smalldatetime
DECLARE @ab_id integer, @contingency bit, @ap_actuals_amt decimal(15,2), @ap_billed_amt decimal(15,2), @ap_unbilled_amt decimal(15,2)
DECLARE @et_actuals_amt decimal(15,2), @et_billed_amt decimal(15,2), @et_unbilled_amt decimal(15,2), @job_process_cntl smallint
DECLARE @et_bill_hold_amt decimal(15,2), @et_nonbill_amt decimal(15,2), @income_rec decimal(15,2), @trf_desc varchar(30)
DECLARE @io_actuals_amt decimal(15,2), @io_billed_amt decimal(15,2), @io_unbilled_amt decimal(15,2), @closeable_ind smallint
DECLARE @io_bill_hold_amt decimal(15,2), @io_nonbill_amt decimal(15,2), @job_bill_hold smallint, @bill_status_ind smallint
DECLARE @ap_bill_hold_amt decimal(15,2), @ap_nonbill_amt decimal(15,2), @ba_id integer, @bill_type smallint, @ba_hdr_id integer
DECLARE @actuals_amt decimal(15,2), @billed_amt decimal(15,2), @unbilled_amt decimal(15,2), @ab_flag smallint, @office_code varchar(4)
DECLARE @bill_hold_amt decimal(15,2), @nonbill_amt decimal(15,2), @quote_amt decimal(15,2), @open_po_amt decimal(15,2)
DECLARE @pending_count integer, @job_bill_hold_req smallint, @adv_bill_req smallint
DECLARE @selected_amt decimal(15,2), @pct_complete decimal(9,3), @etq_amt decimal(15,2), @ir_billed_amt decimal(15,2)
DECLARE @reconciled_amt decimal(15,2), @cli_ref varchar(30), @cli_po varchar(40)
DECLARE @cmp_id int, @cmp_code varchar(6), @cmp_name varchar(128), @billing_coop_code varchar(6), @job_process_desc varchar(40)

DECLARE @prod_bill_job TABLE ( 
	QUOTE					decimal(15,2) NULL,
	ACTUALS					decimal(15,2) NULL,
	BILLED					decimal(15,2) NULL, 
	UNBILLED				decimal(15,2) NULL, 
	BILL_HOLD				decimal(15,2) NULL,
	NONBILL					decimal(15,2) NULL,
	PO						decimal(15,2) NULL )

SELECT @ret_val = 0

DECLARE job_cursor CURSOR FOR
		 SELECT jl.CL_CODE, jl.DIV_CODE, jl.PRD_CODE, JOB_DESC, JOB_COMP_DESC, jl.OFFICE_CODE, ea.ESTIMATE_NUMBER, 
				ea.EST_COMPONENT_NBR, EST_QUOTE_NBR, ea.EST_REVISION_NBR, EST_APPR_DATE, jt.TRF_CODE, 
				TRF_DESCRIPTION, COALESCE( jc.JOB_BILL_HOLD, 0 ), COMPLETED_DATE, jc.JOB_PROCESS_CONTRL, 
				jc.AB_FLAG, jc.BILLING_USER, jc.SERVICE_FEE_FLAG, jc.SELECTED_BA_ID, jl.JOB_CLI_REF,
				jc.JOB_CL_PO_NBR, jl.BILL_COOP_CODE, c.CMP_IDENTIFIER, c.CMP_CODE, c.CMP_NAME, jpc.JOB_PROCESS_DESC 
		   FROM	dbo.JOB_LOG jl 
	 INNER JOIN dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = jl.JOB_NUMBER
	 INNER JOIN dbo.JOB_PROC_CONTROLS jpc ON jc.JOB_PROCESS_CONTRL = jpc.JOB_PROCESS_CONTRL 
LEFT OUTER JOIN dbo.ESTIMATE_APPROVAL ea ON ea.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR AND ea.JOB_NUMBER = jc.JOB_NUMBER
LEFT OUTER JOIN dbo.JOB_TRAFFIC jt ON jt.JOB_NUMBER = jc.JOB_NUMBER AND jt.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
LEFT OUTER JOIN dbo.TRAFFIC t ON t.TRF_CODE = jt.TRF_CODE
LEFT OUTER JOIN dbo.CAMPAIGN c ON jl.CMP_IDENTIFIER = c.CMP_IDENTIFIER 
		  WHERE jc.JOB_NUMBER = @job_number_in
		    AND jc.JOB_COMPONENT_NBR = @job_component_nbr_in

OPEN job_cursor

FETCH job_cursor INTO @cl_code, @div_code, @prd_code, @job_desc, @job_comp_desc, @office_code, @est_nbr, 
	@est_comp_nbr, @est_qte_nbr, @est_rev_nbr, @est_appr_date, @trf_code, @trf_desc, @job_bill_hold, 
	@job_comp_date, @job_process_cntl, @ab_flag, @billing_user, @service_fee, @ba_id, @cli_ref, @cli_po, @billing_coop_code, @cmp_id, @cmp_code, @cmp_name, @job_process_desc

IF ( @@FETCH_STATUS = 0 )
BEGIN
	IF ( @job_process_cntl = 5 )
		SELECT @recon_lock = ( SELECT TOP 1 BCC_FLAG  
								 FROM dbo.JOB_PROCESS_LOG 
								WHERE JOB_NUMBER = @job_number_in 
								  AND JOB_COMPONENT_NBR = @job_component_nbr_in 
							 ORDER BY JOB_PROCESS_LOG_ID DESC )
	ELSE
		SELECT @recon_lock = 0						 
	
	INSERT INTO @prod_bill_job( QUOTE, ACTUALS, BILLED, UNBILLED, BILL_HOLD, NONBILL, PO )
	EXECUTE dbo.advsp_prod_bill_amts_by_job_w_cutoffs @job_number_in, @job_component_nbr_in, 
			@et_date_cutoff_in,	@io_date_cutoff_in, @ap_pp_cutoff_in, @ret_val = @ret_val OUTPUT  

	DECLARE amts_cursor CURSOR FOR
	 SELECT pbj.QUOTE, pbj.ACTUALS, pbj.BILLED, pbj.UNBILLED, pbj.BILL_HOLD, pbj.NONBILL, pbj.PO
	   FROM @prod_bill_job pbj
	FOR READ ONLY   
	
	OPEN amts_cursor
	
	FETCH amts_cursor INTO @quote_amt, @actuals_amt, @billed_amt, @unbilled_amt, @bill_hold_amt, @nonbill_amt, @open_po_amt
	
	CLOSE amts_cursor
	DEALLOCATE amts_cursor
	
	DECLARE adv_bill_cursor CURSOR FOR
	 SELECT ADV_BILL, BILLED, UNBILLED, INCOME_REC  
	   FROM dbo.advtf_advance_bill_by_job( @job_number_in, @job_component_nbr_in )
	 FOR READ ONLY

	OPEN adv_bill_cursor

	FETCH adv_bill_cursor INTO @adv_bill, @adv_billed, @adv_unbilled, @income_rec
	
	CLOSE adv_bill_cursor
	DEALLOCATE adv_bill_cursor
	
	SELECT @ir_billed_amt = ( SELECT COALESCE( SUM( REC_AMT ), 0.00 )
							    FROM dbo.INCOME_REC
							   WHERE JOB_NUMBER = @job_number_in  
								 AND JOB_COMPONENT_NBR = @job_component_nbr_in
								 AND AR_INV_NBR IS NOT NULL )
	
	IF ( @est_qte_nbr > 0 )
	BEGIN
		SELECT @etq_amt = ( SELECT COALESCE( SUM( LINE_TOTAL ), 0.00 )  
							  FROM dbo.advtf_prod_bill_amts_by_line( @job_number_in, @job_component_nbr_in, NULL, @et_date_cutoff_in, NULL, 0, 0 )
							 WHERE FNC_TYPE = 'E'
							   AND SOURCE = 'Quote' )

		IF ( @etq_amt <> 0.00 ) AND ( @etq_amt IS NOT NULL )
		BEGIN
			SELECT @et_actuals_amt = ( SELECT COALESCE( SUM( LINE_TOTAL ), 0.00 )  
										 FROM dbo.advtf_prod_bill_amts_by_line( @job_number_in, @job_component_nbr_in, NULL, @et_date_cutoff_in, NULL, 0, 0 )
										WHERE FNC_TYPE = 'E'
										  AND SOURCE = 'Actual' )
			SET @pct_complete = ROUND( @et_actuals_amt / @etq_amt, 3 )										    
		END							     
	END 
	
	SELECT @appr_amt = 0.00

	DECLARE bill_appr_cursor CURSOR FOR
	 SELECT BA_ID, APPROVED_AMT, BILL_TYPE, BA_HDR_ID  
	   FROM dbo.BILL_APPR_HDR 
	  WHERE JOB_NUMBER = @job_number_in  
		AND JOB_COMPONENT_NBR = @job_component_nbr_in 
		AND AR_INV_NBR IS NULL 
		AND BA_ID = @ba_id 
   ORDER BY BA_HDR_ID DESC     
	FOR READ ONLY   
	
	OPEN bill_appr_cursor
	
	FETCH bill_appr_cursor INTO @ba_id, @appr_amt, @bill_type, @ba_hdr_id
	IF ( @ba_hdr_id IS NOT NULL ) AND ( @appr_amt IS NULL )
		SELECT @appr_amt = ( SELECT COALESCE( SUM( COALESCE( APPR_NET, APPROVED_AMT )), 0.00 ) 
							   FROM dbo.BILL_APPR_DTL 
							  WHERE BA_ID = @ba_id 
								AND JOB_NUMBER = @job_number_in
								AND JOB_COMPONENT_NBR = @job_component_nbr_in )

	CLOSE bill_appr_cursor
	DEALLOCATE bill_appr_cursor

	IF ( @ab_flag = 0 OR @ab_flag IS NULL ) AND ( @bill_type IN ( 2, 3 ))
		SELECT @adv_bill_req = 1
	ELSE	
		SELECT @adv_bill_req = 0
		
	SELECT @job_bill_hold_req = NULL	
	
	IF ( @ba_id > 0 )
	BEGIN
		IF ( @bill_type = 1 )
			SELECT @job_bill_hold_req = 1
		ELSE
		BEGIN
			IF ( @bill_type = 0 ) AND ( @job_bill_hold > 0 )
				SELECT @job_bill_hold_req = 0
		END	
	END	
		
	SELECT @pending_count = ( SELECT COUNT(*) 
							    FROM dbo.ADVANCE_BILLING 
							   WHERE JOB_NUMBER = @job_number_in
								 AND JOB_COMPONENT_NBR = @job_component_nbr_in
								 AND AR_INV_NBR IS NULL
								 AND AB_FLAG = 6 )
								 
	SELECT @ret_val = ( SELECT dbo.advfn_is_job_billed_w_cutoffs( @job_number_in, @job_component_nbr_in, @et_date_cutoff_in, 
																  @io_date_cutoff_in, @ap_pp_cutoff_in ))
																  
	IF ( @ret_val = 1 )
		SELECT @items_to_bill_ind = 0
	ELSE													   
		SELECT @items_to_bill_ind = 1
		
	SELECT @ret_val = 0	 							 
								 
	SELECT @closeable_ind = ( SELECT dbo.advfn_is_job_fully_billed( @job_number_in, @job_component_nbr_in ))							 

END	
ELSE
	SELECT @ret_val = @@ERROR

CLOSE job_cursor
DEALLOCATE job_cursor

IF ( @job_bill_hold IN ( 1, 2 ))
	SELECT @bill_status_ind = 3
ELSE
BEGIN
	IF ( @bill_hold_amt <> 0.00 )
		SELECT @bill_status_ind = 4
	ELSE
	BEGIN
		IF ( @ab_flag IS NOT NULL AND @ab_flag <> 0 )
			SELECT @bill_status_ind = 2
		ELSE
			SELECT @bill_status_ind = 1
	END		
END	

IF ( @bill_status_ind = 2 )
	SELECT @reconciled_amt = COALESCE( @billed_amt, 0.00 )
ELSE
	SELECT @reconciled_amt = NULL
		
SELECT @selected_amt = ( SELECT dbo.advfn_get_prod_sel_amt( @job_number_in, @job_component_nbr_in )
                           FROM dbo.AGENCY ) 

 SELECT [ClientCode] = @cl_code,
		[DivisionCode] = @div_code,
		[ProductCode] = @prd_code, 
		[JobNumber] = @job_number_in, 
		[JobDescription] = @job_desc, 
		[JobComponentNumber] = @job_component_nbr_in, 
		[JobComponentDescription] = @job_comp_desc, 
		[OfficeCode] = @office_code, 
		[EstimateNumber] = @est_nbr, 
		[EstimateComponentNumber] = @est_comp_nbr, 
		[EstimateQuoteNumber] = @est_qte_nbr, 
		[EstimateApproveDate] = @est_appr_date, 
		[JobTrafficCode] = @trf_code, 
		[JobTrafficDescription] = @trf_desc, 
		[JobBillHold] = @job_bill_hold, 
		[JobCompleteDate] = @job_comp_date, 
		[QuoteAmount] = @quote_amt, 
		[ActualBillableAmount] = @actuals_amt, 
		[NonbillableAmount] = @nonbill_amt, 
		[BillHoldAmount] = @bill_hold_amt, 
		[OpenPOAMount] = @open_po_amt, 
		[BilledAmount] = @billed_amt, 
		[UnbilledAmount] = @unbilled_amt, 
		[ApprovalAmount] = @appr_amt, 
		[PendingCount] = CASE @pending_count WHEN 0 THEN 0 ELSE 1 END, 
		[AdvanceBillRequested] = @adv_bill_req, 
		[JobBillHoldRequested] = @job_bill_hold_req, 
		[BillStatusIndicator] = @bill_status_ind, 
		[JobProcessControl] = @job_process_cntl, 
		[IsClosable] = @closeable_ind, 
		[AdvanceBilledLessIncomeReconciledAmount] = COALESCE( @adv_billed - @income_rec, 0.00 ), 
		[ItemsToBillIndicator] = @items_to_bill_ind, 
		[UnbilledAdvanceAmount] = @adv_unbilled, 
		[IncomeReconciledBilledAmount] = @ir_billed_amt, 
		[ReconciledAmount] = @reconciled_amt, 
		[IncomeReconciledAmount] = CAST( CASE @bill_status_ind WHEN 2 THEN @income_rec ELSE NULL END AS decimal(15,2)), 
		[SelectedAmount] = @selected_amt, 
		[BillingApprovalID] = @ba_id, 
		[BillingUserCode] = @billing_user, 
		[IsReconLock] = @recon_lock, 
		[ServiceFee] = @service_fee, 
		[ApprovalComments] = bah.APPR_COMMENTS, 
		[PercentComplete] = @pct_complete, 
		[ClientReferance] = @cli_ref, 
		[ClientPO] = @cli_po,
		[BillingCoopCode] = @billing_coop_code,
		[CampaignID] = @cmp_id, 
		[CampaignCode] = @cmp_code, 
		[CampaignName] = @cmp_name,
		[JobProcessDescription] = @job_process_desc
   FROM dbo.AGENCY LEFT OUTER JOIN dbo.BILL_APPR_HDR bah ON ( bah.BA_HDR_ID = @ba_hdr_id )

GO
