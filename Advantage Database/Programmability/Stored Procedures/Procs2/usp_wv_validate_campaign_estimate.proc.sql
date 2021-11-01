
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_validate_campaign_estimate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_validate_campaign_estimate]
GO




CREATE PROCEDURE [dbo].[usp_wv_validate_campaign_estimate] 
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6), 
@CampaignCode VarChar(6)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

SELECT @sql = 'SELECT COUNT(CMP_CODE)
				   FROM CAMPAIGN
				   WHERE CMP_TYPE = 2 AND ISNULL(CMP_CLOSED,0) = 0 AND CMP_CODE = @CampaignCode AND CL_CODE = @ClientCode
				    AND DIV_CODE = @DivisionCode AND PRD_CODE = @ProductCode'
				
SELECT @paramlist = '@CampaignCode VarChar(6), @ClientCode VarChar(6), @DivisionCode Varchar(6), @ProductCode VarChar(6)'

EXEC sp_executesql @sql, @paramlist, @CampaignCode, @ClientCode, @DivisionCode, @ProductCode
 
/*If Exists(Select CMP_CODE
From CAMPAIGN
Where CMP_TYPE = 2
AND CMP_CLOSED = 0
AND CL_CODE = @ClientCode
AND DIV_CODE = @DivisionCode
AND PRD_CODE = @ProductCode
AND CMP_CODE = @CampaignCode)
	 select 1
Else
	select  0*/




















