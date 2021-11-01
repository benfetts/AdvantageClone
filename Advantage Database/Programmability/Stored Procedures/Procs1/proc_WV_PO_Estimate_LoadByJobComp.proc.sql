CREATE PROCEDURE [dbo].[proc_WV_PO_Estimate_LoadByJobComp](@funct integer, @job_number integer, @job_component_nbr integer, @fnc_code varchar(6))
AS

-- exec  proc_WV_PO_Estimate_LoadByJobComp 1, 44, 1, ''
-- exec  proc_WV_PO_Estimate_LoadByJobComp 1, 44, 1, 'print'

	DECLARE
		@HAS_APPROVED_ESTIMATE BIT,
		@HAS_APPROVED_INT_ESTIMATE BIT

	SET @HAS_APPROVED_ESTIMATE = 0
	SET @HAS_APPROVED_INT_ESTIMATE = 0

-- SEE IF THERE IS A CLIENT APPROVAL
	IF EXISTS (SELECT JOB_NUMBER FROM ESTIMATE_APPROVAL WITH(NOLOCK) WHERE JOB_NUMBER =  @job_number AND JOB_COMPONENT_NBR = @job_component_nbr)
	BEGIN
		SET @HAS_APPROVED_ESTIMATE = 1;
	END

	-- IF NO CLIENT APPROVAL, LOOK FOR INTERNAL APPROVAL
	IF @HAS_APPROVED_ESTIMATE = 0
	BEGIN
		IF EXISTS (SELECT JOB_NUMBER FROM ESTIMATE_INT_APPR WITH(NOLOCK) WHERE JOB_NUMBER =  @job_number AND JOB_COMPONENT_NBR = @job_component_nbr)
		BEGIN
			SET @HAS_APPROVED_INT_ESTIMATE = 1;
		END
	END

if @funct=1
begin
	if @fnc_code <> ''
	begin
		if @HAS_APPROVED_ESTIMATE = 1
		Begin
			select
				[EstimateNumber] = apv.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = rd.EST_COMPONENT_NBR,
				[EstimateQuoteNumber] = rd.EST_QUOTE_NBR,
				[EstimateRevisionNumber] = rd.EST_REV_NBR,
				[JobNumber] = apv.JOB_NUMBER,
				[JobComponentNumber] = apv.JOB_COMPONENT_NBR,
				[FunctionType] = f.FNC_TYPE,
				[FunctionDescription] = f.FNC_DESCRIPTION,
				[FunctionCode] = f.FNC_CODE,
				[EstimateApprovalQuoteNumber] = apv.EST_QUOTE_NBR,
				[EstimateRevisionQuantity] = isnull(rd.EST_REV_QUANTITY,0),
				[EstimateRevisionRate] = isnull(rd.EST_REV_RATE,0),
				[EstimateRevisionExtendedAmount] = case when rd.EST_REV_EXT_AMT is null then 0 else
														rd.EST_REV_EXT_AMT end, 
				[EstimateRevisionCommissionPercent] = isnull(rd.EST_REV_COMM_PCT,0),
				[VendorName] = isnull(vend.VN_NAME,'(any)'),
				[VendorCode] = isnull(vend.VN_CODE,''),
				[ClientCode] = isnull(j.CL_CODE,''),
				[DivisionCode] = isnull(j.DIV_CODE,''),
				[ProductCode] = isnull(PRD_CODE,''),
				[ExtendedMarkupAmount] = case when rd.EXT_MARKUP_AMT is null then 0 else
												rd.EXT_MARKUP_AMT end, 
				[LineTotal] = case when rd.LINE_TOTAL is null then 0 else
									rd.LINE_TOTAL end, 
				[PurchaseOrderExistingAmount] = isnull((select sum(PO_EXT_AMOUNT)
			from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0),
			[Balance]=		
			(select sum(EST_REV_EXT_AMT) from ESTIMATE_APPROVAL as apv2
			  join ESTIMATE_REV_DET as rd2 on rd2.ESTIMATE_NUMBER = apv2.ESTIMATE_NUMBER
			  and rd2.EST_COMPONENT_NBR=apv2.EST_COMPONENT_NBR
			  and rd2.EST_QUOTE_NBR = apv2.EST_QUOTE_NBR
			  and rd2.EST_REV_NBR = apv2.EST_REVISION_NBR
			  where apv2.JOB_NUMBER = apv.JOB_NUMBER 
			   and  apv2.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR
			   and apv2.EST_REVISION_NBR = rd.EST_REV_NBR
			   and  apv2.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			   and rd2.FNC_CODE= rd.FNC_CODE
			) -
			 (isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0)),
			  [UseCPM] = case when f.FNC_CPM_FLAG = 1 then 1 else 0 end
			 from ESTIMATE_APPROVAL as apv
			join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
			 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
			 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
			 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
			join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
			left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
			 where apv.JOB_NUMBER = @job_number and apv.JOB_COMPONENT_NBR=@job_component_nbr and rd.FNC_CODE=@fnc_code and f.FNC_TYPE = 'V'
			 order by f.FNC_CODE
		End
		Else if @HAS_APPROVED_INT_ESTIMATE = 1
		Begin
			select
				[EstimateNumber] = apv.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = rd.EST_COMPONENT_NBR,
				[EstimateQuoteNumber] = rd.EST_QUOTE_NBR,
				[EstimateRevisionNumber] = rd.EST_REV_NBR,
				[JobNumber] = apv.JOB_NUMBER,
				[JobComponentNumber] = apv.JOB_COMPONENT_NBR,
				[FunctionType] = f.FNC_TYPE,
				[FunctionDescription] = f.FNC_DESCRIPTION,
				[FunctionCode] = f.FNC_CODE,
				[EstimateApprovalQuoteNumber] = apv.EST_QUOTE_NBR,
				[EstimateRevisionQuantity] = isnull(rd.EST_REV_QUANTITY,0),
				[EstimateRevisionRate] = isnull(rd.EST_REV_RATE,0),
				[EstimateRevisionExtendedAmount] = case when rd.EST_REV_EXT_AMT is null then 0 else
														rd.EST_REV_EXT_AMT end, 
				[EstimateRevisionCommissionPercent] = isnull(rd.EST_REV_COMM_PCT,0),
				[VendorName] = isnull(vend.VN_NAME,'(any)'),
				[VendorCode] = isnull(vend.VN_CODE,''),
				[ClientCode] = isnull(j.CL_CODE,''),
				[DivisionCode] = isnull(j.DIV_CODE,''),
				[ProductCode] = isnull(PRD_CODE,''),
				[ExtendedMarkupAmount] = case when rd.EXT_MARKUP_AMT is null then 0 else
												rd.EXT_MARKUP_AMT end, 
				[LineTotal] = case when rd.LINE_TOTAL is null then 0 else
									rd.LINE_TOTAL end, 
				[PurchaseOrderExistingAmount] = isnull((select sum(PO_EXT_AMOUNT)
			from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0),
			[Balance]=		
			(select sum(EST_REV_EXT_AMT) from ESTIMATE_INT_APPR as apv2
			  join ESTIMATE_REV_DET as rd2 on rd2.ESTIMATE_NUMBER = apv2.ESTIMATE_NUMBER
			  and rd2.EST_COMPONENT_NBR=apv2.EST_COMPONENT_NBR
			  and rd2.EST_QUOTE_NBR = apv2.EST_QUOTE_NBR
			  and rd2.EST_REV_NBR = apv2.EST_REVISION_NBR
			  where apv2.JOB_NUMBER = apv.JOB_NUMBER 
			   and  apv2.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR
			   and apv2.EST_REVISION_NBR = rd.EST_REV_NBR
			   and  apv2.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			   and rd2.FNC_CODE= rd.FNC_CODE
			) -
			 (isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0)),
			  [UseCPM] = case when f.FNC_CPM_FLAG = 1 then 1 else 0 end
			 from ESTIMATE_INT_APPR as apv
			join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
			 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
			 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
			 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
			join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
			left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
			 where apv.JOB_NUMBER = @job_number and apv.JOB_COMPONENT_NBR=@job_component_nbr and rd.FNC_CODE=@fnc_code and f.FNC_TYPE = 'V'
			 order by f.FNC_CODE
		End		
		Else
		Begin
			select
				[EstimateNumber] = apv.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = rd.EST_COMPONENT_NBR,
				[EstimateQuoteNumber] = rd.EST_QUOTE_NBR,
				[EstimateRevisionNumber] = rd.EST_REV_NBR,
				[JobNumber] = apv.JOB_NUMBER,
				[JobComponentNumber] = apv.JOB_COMPONENT_NBR,
				[FunctionType] = f.FNC_TYPE,
				[FunctionDescription] = f.FNC_DESCRIPTION,
				[FunctionCode] = f.FNC_CODE,
				[EstimateApprovalQuoteNumber] = apv.EST_QUOTE_NBR,
				[EstimateRevisionQuantity] = isnull(rd.EST_REV_QUANTITY,0),
				[EstimateRevisionRate] = isnull(rd.EST_REV_RATE,0),
				[EstimateRevisionExtendedAmount] = case when rd.EST_REV_EXT_AMT is null then 0 else
														rd.EST_REV_EXT_AMT end, 
				[EstimateRevisionCommissionPercent] = isnull(rd.EST_REV_COMM_PCT,0),
				[VendorName] = isnull(vend.VN_NAME,'(any)'),
				[VendorCode] = isnull(vend.VN_CODE,''),
				[ClientCode] = isnull(j.CL_CODE,''),
				[DivisionCode] = isnull(j.DIV_CODE,''),
				[ProductCode] = isnull(PRD_CODE,''),
				[ExtendedMarkupAmount] = case when rd.EXT_MARKUP_AMT is null then 0 else
												rd.EXT_MARKUP_AMT end, 
				[LineTotal] = case when rd.LINE_TOTAL is null then 0 else
									rd.LINE_TOTAL end, 
				[PurchaseOrderExistingAmount] = isnull((select sum(PO_EXT_AMOUNT)
			from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0),
			[Balance]=		
			(select sum(EST_REV_EXT_AMT) from ESTIMATE_APPROVAL as apv2
			  join ESTIMATE_REV_DET as rd2 on rd2.ESTIMATE_NUMBER = apv2.ESTIMATE_NUMBER
			  and rd2.EST_COMPONENT_NBR=apv2.EST_COMPONENT_NBR
			  and rd2.EST_QUOTE_NBR = apv2.EST_QUOTE_NBR
			  and rd2.EST_REV_NBR = apv2.EST_REVISION_NBR
			  where apv2.JOB_NUMBER = apv.JOB_NUMBER 
			   and  apv2.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR
			   and apv2.EST_REVISION_NBR = rd.EST_REV_NBR
			   and  apv2.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			   and rd2.FNC_CODE= rd.FNC_CODE
			) -
			 (isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0)),
			  [UseCPM] = case when f.FNC_CPM_FLAG = 1 then 1 else 0 end
			 from ESTIMATE_APPROVAL as apv
			join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
			 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
			 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
			 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
			join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
			left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
			 where apv.JOB_NUMBER = @job_number and apv.JOB_COMPONENT_NBR=@job_component_nbr and rd.FNC_CODE=@fnc_code and f.FNC_TYPE = 'V'
			 order by f.FNC_CODE
		End
	end
else
	begin		
		if @HAS_APPROVED_ESTIMATE = 1
		Begin
			select
				[EstimateNumber] = apv.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = rd.EST_COMPONENT_NBR,
				[EstimateQuoteNumber] = rd.EST_QUOTE_NBR, 
				[EstimateRevisionNumber] = rd.EST_REV_NBR,
				[JobNumber] = apv.JOB_NUMBER, 
				[JobComponentNumber] = apv.JOB_COMPONENT_NBR,
				[FunctionType] = f.FNC_TYPE,
				[FunctionDescription] = f.FNC_DESCRIPTION,
				[FunctionCode] = f.FNC_CODE,
				[EstimateApprovalQuoteNumber] = apv.EST_QUOTE_NBR,
				[EstimateRevisionQuantity] = isnull(rd.EST_REV_QUANTITY,0),
				[EstimateRevisionRate] = isnull(rd.EST_REV_RATE,0),
				[EstimateRevisionExtendedAmount] = case when rd.EST_REV_EXT_AMT is null then 0 else
														rd.EST_REV_EXT_AMT end, 
				[EstimateRevisionCommissionPercent] = isnull(rd.EST_REV_COMM_PCT,0),
				[VendorName] = isnull(vend.VN_NAME,'(any)'),
				[VendorCode] = isnull(vend.VN_CODE,''),
				[ClientCode] = isnull(j.CL_CODE,''),
				[DivisionCode] = isnull(j.DIV_CODE,''),
				[ProductCode] = isnull(PRD_CODE,''),
				[ExtendedMarkupAmount] = case when rd.EXT_MARKUP_AMT is null then 0 else
										rd.EXT_MARKUP_AMT end,
				[LineTotal] = case when rd.LINE_TOTAL is null then 0 else
									rd.LINE_TOTAL end,
				[PurchaseOrderExistingAmount] = isnull((select sum(PO_EXT_AMOUNT)
			from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0),
			[Balance]=
			(select sum(EST_REV_EXT_AMT) from ESTIMATE_APPROVAL as apv2
			  join ESTIMATE_REV_DET as rd2 on rd2.ESTIMATE_NUMBER = apv2.ESTIMATE_NUMBER
			  and rd2.EST_COMPONENT_NBR=apv2.EST_COMPONENT_NBR
			  and rd2.EST_QUOTE_NBR = apv2.EST_QUOTE_NBR
			  and rd2.EST_REV_NBR = apv2.EST_REVISION_NBR
			  where apv2.JOB_NUMBER = apv.JOB_NUMBER 
			   and  apv2.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR
			   and apv2.EST_REVISION_NBR = rd.EST_REV_NBR
			   and  apv2.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			   and rd2.FNC_CODE= rd.FNC_CODE
			) -
			 (isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0)),
			  [UseCPM] = case when f.FNC_CPM_FLAG = 1 then 1 else 0 end
			 from ESTIMATE_APPROVAL as apv
			join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
			 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
			 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
			 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
			join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
			left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
			 where apv.JOB_NUMBER = @job_number and apv.JOB_COMPONENT_NBR=@job_component_nbr and f.FNC_TYPE = 'V'
			  order by apv.ESTIMATE_NUMBER, rd.EST_COMPONENT_NBR, rd.EST_QUOTE_NBR, rd.EST_REV_NBR, f.FNC_DESCRIPTION
		End
		Else if @HAS_APPROVED_INT_ESTIMATE = 1
		Begin
			select
				[EstimateNumber] = apv.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = rd.EST_COMPONENT_NBR,
				[EstimateQuoteNumber] = rd.EST_QUOTE_NBR, 
				[EstimateRevisionNumber] = rd.EST_REV_NBR,
				[JobNumber] = apv.JOB_NUMBER, 
				[JobComponentNumber] = apv.JOB_COMPONENT_NBR,
				[FunctionType] = f.FNC_TYPE,
				[FunctionDescription] = f.FNC_DESCRIPTION,
				[FunctionCode] = f.FNC_CODE,
				[EstimateApprovalQuoteNumber] = apv.EST_QUOTE_NBR,
				[EstimateRevisionQuantity] = isnull(rd.EST_REV_QUANTITY,0),
				[EstimateRevisionRate] = isnull(rd.EST_REV_RATE,0),
				[EstimateRevisionExtendedAmount] = case when rd.EST_REV_EXT_AMT is null then 0 else
														rd.EST_REV_EXT_AMT end, 
				[EstimateRevisionCommissionPercent] = isnull(rd.EST_REV_COMM_PCT,0),
				[VendorName] = isnull(vend.VN_NAME,'(any)'),
				[VendorCode] = isnull(vend.VN_CODE,''),
				[ClientCode] = isnull(j.CL_CODE,''),
				[DivisionCode] = isnull(j.DIV_CODE,''),
				[ProductCode] = isnull(PRD_CODE,''),
				[ExtendedMarkupAmount] = case when rd.EXT_MARKUP_AMT is null then 0 else
										rd.EXT_MARKUP_AMT end,
				[LineTotal] = case when rd.LINE_TOTAL is null then 0 else
									rd.LINE_TOTAL end,
				[PurchaseOrderExistingAmount] = isnull((select sum(PO_EXT_AMOUNT)
			from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0),
			[Balance]=
			(select sum(EST_REV_EXT_AMT) from ESTIMATE_INT_APPR as apv2
			  join ESTIMATE_REV_DET as rd2 on rd2.ESTIMATE_NUMBER = apv2.ESTIMATE_NUMBER
			  and rd2.EST_COMPONENT_NBR=apv2.EST_COMPONENT_NBR
			  and rd2.EST_QUOTE_NBR = apv2.EST_QUOTE_NBR
			  and rd2.EST_REV_NBR = apv2.EST_REVISION_NBR
			  where apv2.JOB_NUMBER = apv.JOB_NUMBER 
			   and  apv2.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR
			   and apv2.EST_REVISION_NBR = rd.EST_REV_NBR
			   and  apv2.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			   and rd2.FNC_CODE= rd.FNC_CODE
			) -
			 (isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0)),
			  [UseCPM] = case when f.FNC_CPM_FLAG = 1 then 1 else 0 end
			 from ESTIMATE_INT_APPR as apv
			join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
			 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
			 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
			 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
			join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
			left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
			 where apv.JOB_NUMBER = @job_number and apv.JOB_COMPONENT_NBR=@job_component_nbr and f.FNC_TYPE = 'V'
			  order by apv.ESTIMATE_NUMBER, rd.EST_COMPONENT_NBR, rd.EST_QUOTE_NBR, rd.EST_REV_NBR, f.FNC_DESCRIPTION	
		End		
		Else
		Begin
			select
				[EstimateNumber] = apv.ESTIMATE_NUMBER,
				[EstimateComponentNumber] = rd.EST_COMPONENT_NBR,
				[EstimateQuoteNumber] = rd.EST_QUOTE_NBR, 
				[EstimateRevisionNumber] = rd.EST_REV_NBR,
				[JobNumber] = apv.JOB_NUMBER, 
				[JobComponentNumber] = apv.JOB_COMPONENT_NBR,
				[FunctionType] = f.FNC_TYPE,
				[FunctionDescription] = f.FNC_DESCRIPTION,
				[FunctionCode] = f.FNC_CODE,
				[EstimateApprovalQuoteNumber] = apv.EST_QUOTE_NBR,
				[EstimateRevisionQuantity] = isnull(rd.EST_REV_QUANTITY,0),
				[EstimateRevisionRate] = isnull(rd.EST_REV_RATE,0),
				[EstimateRevisionExtendedAmount] = case when rd.EST_REV_EXT_AMT is null then 0 else
														rd.EST_REV_EXT_AMT end, 
				[EstimateRevisionCommissionPercent] = isnull(rd.EST_REV_COMM_PCT,0),
				[VendorName] = isnull(vend.VN_NAME,'(any)'),
				[VendorCode] = isnull(vend.VN_CODE,''),
				[ClientCode] = isnull(j.CL_CODE,''),
				[DivisionCode] = isnull(j.DIV_CODE,''),
				[ProductCode] = isnull(PRD_CODE,''),
				[ExtendedMarkupAmount] = case when rd.EXT_MARKUP_AMT is null then 0 else
										rd.EXT_MARKUP_AMT end,
				[LineTotal] = case when rd.LINE_TOTAL is null then 0 else
									rd.LINE_TOTAL end,
				[PurchaseOrderExistingAmount] = isnull((select sum(PO_EXT_AMOUNT)
			from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0),
			[Balance]=
			(select sum(EST_REV_EXT_AMT) from ESTIMATE_APPROVAL as apv2
			  join ESTIMATE_REV_DET as rd2 on rd2.ESTIMATE_NUMBER = apv2.ESTIMATE_NUMBER
			  and rd2.EST_COMPONENT_NBR=apv2.EST_COMPONENT_NBR
			  and rd2.EST_QUOTE_NBR = apv2.EST_QUOTE_NBR
			  and rd2.EST_REV_NBR = apv2.EST_REVISION_NBR
			  where apv2.JOB_NUMBER = apv.JOB_NUMBER 
			   and  apv2.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR
			   and apv2.EST_REVISION_NBR = rd.EST_REV_NBR
			   and  apv2.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			   and rd2.FNC_CODE= rd.FNC_CODE
			) -
			 (isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
			 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
			 where pd.JOB_NUMBER=apv.JOB_NUMBER
			  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
			  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0)),
			  [UseCPM] = case when f.FNC_CPM_FLAG = 1 then 1 else 0 end
			 from ESTIMATE_APPROVAL as apv
			join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
			 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
			 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
			 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
			join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
			join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
			left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
			 where apv.JOB_NUMBER = @job_number and apv.JOB_COMPONENT_NBR=@job_component_nbr and f.FNC_TYPE = 'V'
			  order by apv.ESTIMATE_NUMBER, rd.EST_COMPONENT_NBR, rd.EST_QUOTE_NBR, rd.EST_REV_NBR, f.FNC_DESCRIPTION
		End			

	end

end




