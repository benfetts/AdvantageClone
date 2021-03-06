
CREATE PROCEDURE [dbo].[usp_cp_dd_GetAllCampaignsWithCDP] 

	@CPID Int

AS

DECLARE
    @RESTRICTIONS SMALLINT
        

SELECT @RESTRICTIONS = COUNT(*) FROM CP_SEC_CLIENT WHERE CDP_CONTACT_ID = @CPID;

IF @RESTRICTIONS > 0
	BEGIN
		SELECT     
			CAMPAIGN.CL_CODE+ ':' +ISNULL(CAMPAIGN.DIV_CODE,'')+ ':' +ISNULL(CAMPAIGN.PRD_CODE,'')+ ':' +CAMPAIGN.CMP_CODE+':' +CAST(CAMPAIGN.CMP_IDENTIFIER AS VARCHAR) AS Code, 
			CAMPAIGN.CL_CODE+ ' | ' +ISNULL(CAMPAIGN.DIV_CODE,'')+ ' | ' +ISNULL(CAMPAIGN.PRD_CODE,'')+ ' | '  +CMP_CODE + ' - ' + ISNULL(CMP_NAME, '') AS Description, 
			CP_SEC_CLIENT.CL_CODE, 
			CP_SEC_CLIENT.DIV_CODE, CP_SEC_CLIENT.PRD_CODE
		FROM        
			CAMPAIGN WITH(NOLOCK) INNER JOIN
			CP_SEC_CLIENT WITH(NOLOCK) ON CAMPAIGN.CL_CODE = CP_SEC_CLIENT.CL_CODE AND CAMPAIGN.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
			CAMPAIGN.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
		WHERE     
			CAMPAIGN.CMP_TYPE = 2
			AND (CMP_CLOSED = 0 OR CMP_CLOSED IS NULL )
			AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)
		ORDER BY 
			CAMPAIGN.CL_CODE, CAMPAIGN.DIV_CODE, CAMPAIGN.PRD_CODE, CAMPAIGN.CMP_CODE;
	END
ELSE
	BEGIN
		SELECT     
			CL_CODE+ ':' +ISNULL(DIV_CODE,'')+ ':' +ISNULL(PRD_CODE,'')+ ':' +CMP_CODE+':' +CAST(CMP_IDENTIFIER AS VARCHAR) AS Code, 
			CAMPAIGN.CL_CODE+ ' | ' +ISNULL(CAMPAIGN.DIV_CODE,'')+ ' | ' +ISNULL(CAMPAIGN.PRD_CODE,'')+ ' | '  +CMP_CODE + ' - ' + ISNULL(CMP_NAME, '') AS Description, 
			CL_CODE, DIV_CODE, PRD_CODE, CMP_IDENTIFIER
		FROM         
			CAMPAIGN WITH(NOLOCK)
		WHERE     
			CMP_TYPE = 2
		AND (CMP_CLOSED = 0 OR CMP_CLOSED IS NULL )
		ORDER BY
			CAMPAIGN.CL_CODE, CAMPAIGN.DIV_CODE, CAMPAIGN.PRD_CODE, CAMPAIGN.CMP_CODE;
	END

