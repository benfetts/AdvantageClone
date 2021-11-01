



















CREATE PROCEDURE [dbo].[usp_wv_job_get_campaign_ident] 
@CampaignCode VarChar(6),
@ClientCode Varchar(6),
@DivisionCode Varchar(6),
@ProductCode Varchar(6)
AS
Select CMP_IDENTIFIER
FROM CAMPAIGN
WHERE CMP_CODE = @CampaignCode 
AND CL_CODE = @ClientCode
AND (DIV_CODE = @DivisionCode OR DIV_CODE IS NULL)
AND (PRD_CODE = @ProductCode OR PRD_CODE IS NULL)
AND (CMP_CLOSED = 0 OR CMP_CLOSED IS NULL) 



















