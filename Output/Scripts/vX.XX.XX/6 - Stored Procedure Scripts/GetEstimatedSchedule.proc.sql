/****** Object:  StoredProcedure [dbo].[GetEstimatedSchedule]    Script Date: 12/18/2019 2:59:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- exec GetEstimatedSchedule 527,1,1

CREATE PROCEDURE [dbo].[GetEstimatedSchedule](
	@JobNum AS INT,
	@JobCompNum AS INT,
	@IncludeEmployee as bit = 0)
AS
BEGIN
	if @IncludeEmployee = 0
		select  a.JobNumber,a.JobCompenentNumber,a.FunctionCode,sum(a.Hours) Hours,FUNCTIONS.FNC_DESCRIPTION Description, isnull(avg(br.BILLING_RATE),0.0) Rate, isnull(sum(br.BILLING_RATE * a.Hours),0.0) Amount  
		from (select jtd.JOB_NUMBER JobNumber, jtd.JOB_COMPONENT_NBR JobCompenentNumber, isnull(FNC_EST,EMPLOYEE.DEF_FNC_CODE) FunctionCode, jtde.EMP_CODE ,EMP_FNAME + ' ' + ISNULL(EMP_MI,'') + CASE WHEN EMP_MI IS NULL THEN '' ELSE '. ' END +  EMP_LNAME EmployeeName ,SUM(ISNULL(jtde.HOURS_ALLOWED,0)) Hours 
				from dbo.JOB_TRAFFIC_DET jtd
				left join dbo.JOB_TRAFFIC_DET_EMPS jtde on jtde.JOB_NUMBER = jtd.JOB_NUMBER and jtde.JOB_COMPONENT_NBR = jtd.JOB_COMPONENT_NBR and jtde.SEQ_NBR = jtd.SEQ_NBR
				left join EMPLOYEE on EMPLOYEE.EMP_CODE = jtde.EMP_CODE
				where jtd.JOB_NUMBER = @JobNum and jtd.JOB_COMPONENT_NBR = @JobCompNum
				GROUP BY jtd.JOB_NUMBER, jtd.JOB_COMPONENT_NBR, FNC_EST,EMPLOYEE.DEF_FNC_CODE,jtde.EMP_CODE,EMP_LNAME,EMP_FNAME,EMP_MI) a
			--join TRAFFIC_FNC on TRAFFIC_FNC.TRF_CODE = a.FunctionCode
			left join FUNCTIONS on FUNCTIONS.FNC_CODE = a.FunctionCode--TRAFFIC_FNC.FNC_CODE
			join JOB_LOG ON JOB_LOG.JOB_NUMBER = a.JobNumber
			cross apply dbo.advtf_get_billing_rate_ps( a.EMP_CODE, null, a.FunctionCode, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.SC_CODE, FUNCTIONS.FNC_TYPE, @JobNum, @JobCompNum, null ) br
			where a.JobNumber = @JobNum and a.JobCompenentNumber = @JobCompNum
			GROUP BY a.JobNumber,a.JobCompenentNumber,a.FunctionCode, FUNCTIONS.FNC_DESCRIPTION
	else
	begin
		select a.*,FUNCTIONS.FNC_DESCRIPTION Description,isnull(br.BILLING_RATE,0.0) Rate, isnull(br.BILLING_RATE * a.Hours,0.0) Amount  
		from (select jtd.JOB_NUMBER JobNumber, jtd.JOB_COMPONENT_NBR JobCompenentNumber, isnull(FNC_EST,EMPLOYEE.DEF_FNC_CODE) FunctionCode, jtde.EMP_CODE ,EMP_FNAME + ' ' + ISNULL(EMP_MI,'') + CASE WHEN EMP_MI IS NULL THEN '' ELSE '. ' END +  EMP_LNAME EmployeeName ,SUM(ISNULL(jtde.HOURS_ALLOWED,0)) Hours 
				from dbo.JOB_TRAFFIC_DET jtd
				left join dbo.JOB_TRAFFIC_DET_EMPS jtde on jtde.JOB_NUMBER = jtd.JOB_NUMBER and jtde.JOB_COMPONENT_NBR = jtd.JOB_COMPONENT_NBR and jtde.SEQ_NBR = jtd.SEQ_NBR
				left join EMPLOYEE on EMPLOYEE.EMP_CODE = jtde.EMP_CODE
				where jtd.JOB_NUMBER = @JobNum and jtd.JOB_COMPONENT_NBR = @JobCompNum
				GROUP BY jtd.JOB_NUMBER, jtd.JOB_COMPONENT_NBR, FNC_EST,EMPLOYEE.DEF_FNC_CODE,jtde.EMP_CODE,EMP_LNAME,EMP_FNAME,EMP_MI) a
			--join TRAFFIC_FNC on TRAFFIC_FNC.TRF_CODE = a.FunctionCode
			left join FUNCTIONS on FUNCTIONS.FNC_CODE = a.FunctionCode--TRAFFIC_FNC.FNC_CODE
			join JOB_LOG ON JOB_LOG.JOB_NUMBER = a.JobNumber
			cross apply dbo.advtf_get_billing_rate_ps( a.EMP_CODE, null, a.FunctionCode, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.SC_CODE, FUNCTIONS.FNC_TYPE, @JobNum, @JobCompNum, null ) br
			where a.JobNumber = @JobNum and a.JobCompenentNumber = @JobCompNum
			--order by FunctionCode
	end
END

GO


