






CREATE PROCEDURE [dbo].[usp_wv_dd_GetCampaignsMediaCal] 
@UserID varchar(100),
@ClientCode VarChar(6),
@DivisionCode Varchar(6),
@ProductCode VarChar(6)

AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
		
SELECT @Rescrictions = COUNT(*)  FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

IF @Rescrictions > 0
BEGIN
Select CMP_CODE as code, CMP_CODE + ' - ' + ISNULL(CMP_NAME, '') as description
From CAMPAIGN INNER JOIN
            SEC_CLIENT ON CAMPAIGN.CL_CODE = SEC_CLIENT.CL_CODE AND CAMPAIGN.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
            CAMPAIGN.PRD_CODE = SEC_CLIENT.PRD_CODE
Where CMP_TYPE = 2
AND CMP_CLOSED = 0
AND ACTIVE_FLAG IS NULL
AND CAMPAIGN.CL_CODE = @ClientCode
AND (CAMPAIGN.DIV_CODE = @DivisionCode OR CAMPAIGN.DIV_CODE IS NULL)
AND (CAMPAIGN.PRD_CODE = @ProductCode OR CAMPAIGN.PRD_CODE IS NULL)
AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
END
Else
BEGIN
Select CMP_CODE as code, CMP_CODE + ' - ' + ISNULL(CMP_NAME, '') as description
From CAMPAIGN
Where CMP_TYPE = 2
AND CMP_CLOSED = 0
AND ACTIVE_FLAG IS NULL
AND CL_CODE = @ClientCode
AND (DIV_CODE = @DivisionCode OR DIV_CODE IS NULL)
AND (PRD_CODE = @ProductCode OR PRD_CODE IS NULL)
END





--Select CMP_CODE as Code, CMP_CODE + ' - ' + CMP_NAME as Description
--from CAMPAIGN
--WHERE   (CAMPAIGN.PRD_CODE Like @ProductCode + '%') AND (CAMPAIGN.CL_CODE Like @ClientCode + '%') AND (CAMPAIGN.DIV_CODE Like @DivisionCode + '%')
--		AND ACTIVE_FLAG IS NULL AND CMP_CLOSED = 0 AND CMP_TYPE = 2
--Order By CMP_CODE

















