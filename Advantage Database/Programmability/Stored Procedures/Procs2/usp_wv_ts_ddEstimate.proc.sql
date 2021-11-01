--DROP PROCEDURE [dbo].[usp_wv_ts_ddEstimate]
CREATE PROCEDURE [dbo].[usp_wv_ts_ddEstimate]
@JobNumber int,
@JobCompNumber int,
@FunctionCode varchar(6),
@EmpCode varchar(6),
@EmpOnly bit
AS
/*=========== QUERY ===========*/
	IF @EmpOnly = 0
	BEGIN
		SELECT 
			[JobNumber] = JOB_NUMBER,
			[JobComponentNumber] = JOB_COMPONENT_NBR,
			[EstimateNumber] = ESTIMATE_NUMBER,
			[EstimateLogDescription] = EST_LOG_DESC,
			[EstimateComponentNumber] = EST_COMPONENT_NBR,
			[EstimateComponentDescription] = EST_COMP_DESC,
			[EstimateQuoteNumber] = EST_QUOTE_NBR,
			[EstimateRevisionNumber] = EST_REV_NBR,
			[FunctionCode] = FNC_CODE,
			[EstimateRevisionSuppliedByCode] = EST_REV_SUP_BY_CODE,
			[TotalEstimateQuantity] = SUM_EST_REV_QUANTITY,
			[EstimateAmount] = SUM_EST_AMOUNT,
			[Contingency] = EXT_CONTINGENCY
		FROM
			[dbo].[advtf_approved_estimate_job_info](@JobNumber, @JobCompNumber, @FunctionCode, @EmpCode, @EmpOnly);
	END
	ELSE
	BEGIN
		SELECT 
			[JobNumber] = JOB_NUMBER,
			[JobComponentNumber] = JOB_COMPONENT_NBR,
			[EstimateNumber] = ESTIMATE_NUMBER,
			[EstimateLogDescription] = EST_LOG_DESC,
			[EstimateComponentNumber] = EST_COMPONENT_NBR,
			[EstimateComponentDescription] = EST_COMP_DESC,
			[EstimateQuoteNumber] = EST_QUOTE_NBR,
			[EstimateRevisionNumber] = EST_REV_NBR,
			[FunctionCode] = FNC_CODE,
			EST_REV_SUP_BY_CODE AS CODE,
			[TotalEstimateQuantity] = SUM_EST_REV_QUANTITY,
			[EstimateAmount] = SUM_EST_AMOUNT,
			[Contingency] = EXT_CONTINGENCY
		FROM
			[dbo].[advtf_approved_estimate_job_info](@JobNumber, @JobCompNumber, @FunctionCode, @EmpCode, @EmpOnly);
	END
/*=========== QUERY ===========*/


