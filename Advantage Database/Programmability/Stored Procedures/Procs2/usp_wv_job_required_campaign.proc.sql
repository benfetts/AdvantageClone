




















CREATE PROCEDURE [dbo].[usp_wv_job_required_campaign] 
@ClientCode VarChar(6)
AS

Declare @ThisReturn as integer

Select @ThisReturn = CMP_CODE_R 
FROM AGENCY

Select @ThisReturn = CMP_CODE_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn




















