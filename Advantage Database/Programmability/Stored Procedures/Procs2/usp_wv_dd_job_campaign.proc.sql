
CREATE PROCEDURE [dbo].[usp_wv_dd_job_campaign] 
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6)
AS

Select CMP_CODE as code, CMP_CODE + ' - ' + ISNULL(CMP_NAME, '') as description
From CAMPAIGN
Where CMP_TYPE = 2
AND ISNULL(CMP_CLOSED,0) = 0
AND CL_CODE = @ClientCode
AND (DIV_CODE = @DivisionCode OR DIV_CODE IS NULL)
AND (PRD_CODE = @ProductCode OR PRD_CODE IS NULL)




















