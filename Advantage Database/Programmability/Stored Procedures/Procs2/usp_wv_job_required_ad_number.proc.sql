























CREATE PROCEDURE [dbo].[usp_wv_job_required_ad_number] 
@ClientCode VarChar(4)
AS

Declare @ThisReturn as integer

Select @ThisReturn = AD_NBR_R 
FROM AGENCY

Select @ThisReturn = AD_NBR_R
From CLIENT
Where CL_CODE = @ClientCode
AND REQ_FLDS = 1

Select @ThisReturn





















