--DROP PROCEDURE [dbo].[usp_wv_ts_ddQuoteVsActual]
CREATE PROCEDURE [dbo].[usp_wv_ts_ddQuoteVsActual]
@JobNumber int,
@JobCompNumber int,
@FunctionCode varchar(6),
@EmpCode varchar(6),
@EmpOnly bit,
@View int
AS
BEGIN

	SELECT
		[JobNumber] = JOB_NUMBER,
        [JobComponentNumber] = JOB_COMPONENT_NBR,
        [EmployeeCode] = EMP_CODE,
        [EmployeeDate] = EMP_DATE,
        [FunctionCode] = FNC_CODE,
        [FunctionDescription] = FNC_DESCRIPTION,
        [TotalEmployeeHours] = SUM_EMP_TIME_DTL_EMP_HOURS,
        [Amount] = SUM_AMOUNT,
        [Comments] = COMMENTS,
		[EmployeeName] = FULL_NAME,
		[AlertID] = ALERT_ID
	FROM
		[dbo].[advtf_qva_actuals_job_info](@JobNumber, @JobCompNumber, @FunctionCode, @EmpCode, @EmpOnly, 1, @View);

END
