

CREATE PROCEDURE [dbo].[usp_wv_DocumentManager_GetCampaignID]
@CampaignCode VarChar(6),
@ClientCode Varchar(6),
@DivisionCode Varchar(6),
@ProductCode Varchar(6)
AS

DECLARE @sql as varchar(4000)
				
set @sql = 'Select CMP_IDENTIFIER
			FROM CAMPAIGN
			WHERE CMP_CODE = ''' + @CampaignCode + ''' 
			AND CL_CODE = ''' + @ClientCode + ''''
			if @DivisionCode <> ''
			Begin
				set @sql = @sql + ' AND DIV_CODE = ''' + @DivisionCode + ''''
			End
			if @ProductCode <> ''
			Begin
				set @sql = @sql + ' AND PRD_CODE = ''' + @ProductCode + ''''
			End
 
 
EXEC(@sql)
print(@sql)

