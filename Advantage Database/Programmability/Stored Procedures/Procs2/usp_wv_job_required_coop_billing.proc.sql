




















CREATE PROCEDURE [dbo].[usp_wv_job_required_coop_billing] 
@ClientCode VarChar(6)
AS

Declare @ThisReturn as integer

Select @ThisReturn = BILL_COOP_CODE_R 
FROM AGENCY

Select @ThisReturn = BILL_COOP_CODE_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn




















