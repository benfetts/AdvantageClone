
/*****************************************************************
Webvantage
This Stored Procedure gets the names for all the codes
******************************************************************/
--EXEC [usp_wv_Get_Alert_Names] '','abc','','','',0,0
CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_Names] 

@Office VarChar(4),
@Client VarChar(6),
@Division VarChar(6),
@Product VarChar(6),
@Campaign VarChar(6),
@JobNumber Int,
@JobComponent int
 
AS

SET NOCOUNT ON

Declare @OfficeName as VarChar(150)
Declare @ClientName as VarChar(150)
Declare @DivisionName as VarChar(150)
Declare @ProductName as VarChar(150)
Declare @CampaignName as VarChar(150)
Declare @JobName as VarChar(150)
Declare @JobCompName as VarChar(150)
Declare @ClientCode as VarChar(6)
Declare @DivisionCode as Varchar(6)
Declare @ProductCode as Varchar(6)
Declare @CamaignCode as varchar(6)
DECLARE @CampaignIdentifier AS Int

SELECT     @CampaignName = CAMPAIGN.CMP_NAME, @ClientName = CLIENT.CL_NAME, @DivisionName = DIVISION.DIV_NAME, @ProductName = PRODUCT.PRD_DESCRIPTION,
			@ClientCode = CAMPAIGN.CL_CODE, @DivisionCode = CAMPAIGN.DIV_CODE, @ProductCode = CAMPAIGN.PRD_CODE, @CampaignIdentifier = CAMPAIGN.CMP_IDENTIFIER, @CamaignCode =CAMPAIGN.CMP_CODE 
FROM        CAMPAIGN
	     INNER JOIN CLIENT
                  ON CLIENT.CL_CODE = CAMPAIGN.CL_CODE
	     INNER JOIN DIVISION
	     ON DIVISION.DIV_CODE = CAMPAIGN.DIV_CODE and DIVISION.CL_CODE = CAMPAIGN.DIV_CODE
	     INNER JOIN PRODUCT
    	     ON PRODUCT.CL_CODE = CAMPAIGN.CL_CODE and PRODUCT.DIV_CODE = CAMPAIGN.DIV_CODE and PRODUCT.PRD_CODE = CAMPAIGN.PRD_CODE
WHERE     (CAMPAIGN.CMP_CODE = @Campaign)

SELECT     @OfficeName = OFFICE.OFFICE_NAME 
FROM        OFFICE 
WHERE     (OFFICE.OFFICE_CODE = @Office)


SELECT     @ClientName = CLIENT.CL_NAME , @ClientCode = CLIENT.CL_CODE
FROM        CLIENT 
WHERE     (CLIENT.CL_CODE = @Client)

SELECT     @DivisionName = DIVISION.DIV_NAME, @DivisionCode = DIVISION.DIV_CODE
FROM        DIVISION 
WHERE     (DIVISION.CL_CODE = @Client and DIVISION.DIV_CODE = @Division)

SELECT     @ProductName = PRODUCT.PRD_DESCRIPTION, @ProductCode = PRODUCT.PRD_CODE
FROM        PRODUCT 
WHERE     (PRODUCT.CL_CODE = @Client and PRODUCT.DIV_CODE = @Division and PRODUCT.PRD_CODE = @Product)

SELECT     @JobName = JOB_LOG.JOB_DESC
FROM        JOB_LOG
WHERE     (JOB_LOG.CL_CODE = @Client and JOB_LOG.DIV_CODE = @Division and JOB_LOG.PRD_CODE = @Product and JOB_LOG.JOB_NUMBER = @JobNumber)

SELECT     @JobCompName = JOB_COMPONENT.JOB_COMP_DESC
FROM        JOB_COMPONENT
WHERE     (JOB_COMPONENT.JOB_NUMBER = @JobNumber and JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComponent)


Set @OfficeName = isnull(@OfficeName, '')
Set @ClientName = isnull(@ClientName, '')
Set @DivisionName  = isnull(@DivisionName, '')
Set @ProductName  = isnull(@ProductName, '')
Set @CampaignName = isnull(@CampaignName, '')
Set @JobName  = isnull(@JobName, '')
Set @JobCompName  = isnull(@JobCompName, '')
Set @DivisionCode  = isnull(@DivisionCode, '')
Set @ClientCode  = isnull(@ClientCode, '')
Set @ProductCode  = isnull(@ProductCode, '')
Set @CamaignCode = isnull(@CamaignCode,'')
Select @OfficeName as OfficeName, @ClientName as ClientName, @DivisionName as DivisionName, @ProductName as ProductName, @CampaignName as CampaignName, @JobName as JobName, @JobCompName as JobCompName,
@ClientCode as ClientCode, @DivisionCode as DivisionCode, @ProductCode as ProductCode, @CampaignIdentifier as CampaignIdentifier,@CamaignCode as CamaignCode
