























CREATE PROCEDURE [dbo].[usp_wv_job_required_market] 
@ClientCode VarChar(4)
AS

Declare @ThisReturn as integer

Select @ThisReturn = MARKET_CODE_R 
FROM AGENCY

Select @ThisReturn = MARKET_CODE_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn




















