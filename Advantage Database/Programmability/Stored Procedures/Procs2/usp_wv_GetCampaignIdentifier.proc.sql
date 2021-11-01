
CREATE PROCEDURE [dbo].[usp_wv_GetCampaignIdentifier] 
@CampaignCode VARCHAR(6)
AS

SELECT     CMP_IDENTIFIER
FROM         CAMPAIGN
WHERE     (CMP_CODE = @CampaignCode)


