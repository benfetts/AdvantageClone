




















CREATE PROCEDURE [dbo].[usp_wv_job_required_job_type] 
@ClientCode VarChar(6)
AS

Declare @ThisReturn as integer

Select @ThisReturn = JT_CODE_R 
FROM AGENCY

Select @ThisReturn = JT_CODE_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn




















