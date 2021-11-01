
CREATE PROCEDURE [dbo].[usp_wv_validate_campaign_isViewable] 
@UserID VARCHAR(100),
@ClientCode VARCHAR(6), 
@DivisionCode VARCHAR(6), 
@ProductCode VARCHAR(6), 
@CampaignCode VARCHAR(6)
AS

DECLARE @Restricted INT,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

SELECT @Restricted = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

IF @Restricted > 0
	BEGIN
	SELECT @sql = 'SELECT COUNT(CMP_CODE)
					FROM CAMPAIGN 
					   INNER JOIN SEC_CLIENT ON CAMPAIGN.CL_CODE = SEC_CLIENT.CL_CODE 
											AND ( CAMPAIGN.DIV_CODE = SEC_CLIENT.DIV_CODE OR CAMPAIGN.DIV_CODE IS NULL ) 
											AND ( CAMPAIGN.PRD_CODE = SEC_CLIENT.PRD_CODE OR CAMPAIGN.PRD_CODE IS NULL )
					   WHERE UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND CAMPAIGN.CMP_CODE = @CampaignCode '
				if @ClientCode <> '' 
					   SELECT @sql = @sql + ' AND CAMPAIGN.CL_CODE = @ClientCode'
				if @DivisionCode <> '' 
					   SELECT @sql = @sql + ' AND (CAMPAIGN.DIV_CODE = @DivisionCode OR CAMPAIGN.DIV_CODE IS NULL)'
				if @ProductCode <> '' 
					   SELECT @sql = @sql + ' AND (CAMPAIGN.PRD_CODE = @ProductCode OR CAMPAIGN.PRD_CODE IS NULL)'
					
	SELECT @paramlist = '@UserID VarChar(100), @ClientCode VarChar(6), @DivisionCode Varchar(6), @ProductCode VarChar(6), @CampaignCode VarChar(6)'

	EXEC sp_executesql @sql, @paramlist, @UserID, @ClientCode, @DivisionCode, @ProductCode, @CampaignCode 
	
	END
Else
	BEGIN
	SELECT @sql = 'SELECT COUNT(CMP_CODE)
					   FROM CAMPAIGN
					   WHERE CAMPAIGN.CMP_CODE = @CampaignCode '
				if @ClientCode <> '' 
					   SELECT @sql = @sql + ' AND CAMPAIGN.CL_CODE = @ClientCode'
				if @DivisionCode <> '' 
					   SELECT @sql = @sql + ' AND (DIV_CODE = @DivisionCode OR DIV_CODE IS NULL)'
				if @ProductCode <> '' 
					   SELECT @sql = @sql + ' AND (PRD_CODE = @ProductCode OR PRD_CODE IS NULL)'
					
	SELECT @paramlist = '@ClientCode VarChar(6), @DivisionCode Varchar(6), @ProductCode VarChar(6), @CampaignCode VarChar(6)'
	
	EXEC sp_executesql @sql, @paramlist, @ClientCode, @DivisionCode, @ProductCode, @CampaignCode

	END


--    BEGIN
--        IF EXISTS (
--            SELECT     
--                CAMPAIGN.CMP_CODE
--            FROM         
--                CAMPAIGN INNER JOIN
--                SEC_CLIENT ON CAMPAIGN.CL_CODE = SEC_CLIENT.CL_CODE AND CAMPAIGN.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
--                CAMPAIGN.PRD_CODE = SEC_CLIENT.PRD_CODE            
--            WHERE 
--                CAMPAIGN.CL_CODE = @ClientCode
--                AND CAMPAIGN.DIV_CODE = @DivisionCode
--                AND CAMPAIGN.PRD_CODE = @ProductCode
--                AND CAMPAIGN.CMP_CODE = @CampaignCode
--                AND CAMPAIGN.CMP_TYPE = 2
--                AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)
--        )
--	            SELECT 1
--        ELSE
--	            SELECT 0
--    END
--ELSE
--    BEGIN
--        IF EXISTS (
--            SELECT 
--                CMP_CODE
--            FROM 
--                CAMPAIGN
--            WHERE 
--                CL_CODE = @ClientCode
--                AND DIV_CODE = @DivisionCode
--                AND PRD_CODE = @ProductCode
--                AND CMP_CODE = @CampaignCode
--                AND CMP_TYPE = 2
--        )
--            SELECT 1
--        ELSE
--            SELECT 0
--    END

