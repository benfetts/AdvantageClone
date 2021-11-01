


















CREATE PROCEDURE [dbo].[usp_wv_job_required_clientref] 
@ClientCode VarChar(6)
AS

Declare @ThisReturn as integer

Select @ThisReturn = JOB_CLI_REF_R
FROM AGENCY

Select @ThisReturn = JOB_CLI_REF_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn


















