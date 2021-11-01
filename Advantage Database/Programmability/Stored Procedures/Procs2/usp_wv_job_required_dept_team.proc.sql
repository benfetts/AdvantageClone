























CREATE PROCEDURE [dbo].[usp_wv_job_required_dept_team] 
@ClientCode VarChar(4)
AS

Declare @ThisReturn as integer

Select @ThisReturn = DP_TM_CODE_R 
FROM AGENCY

Select @ThisReturn = DP_TM_CODE_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn





















