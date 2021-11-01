
/*****************************************************************
Webvantage
This Stored Procedure gets the names for all the codes
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert_Names] 

@Client VarChar(6),
@Division VarChar(6),
@Product VarChar(6),
@JobNumber Int,
@JobComponent int
 
AS

SET NOCOUNT ON

Declare @ClientName as VarChar(150)
Declare @DivisionName as VarChar(150)
Declare @ProductName as VarChar(150)
Declare @JobName as VarChar(150)
Declare @JobCompName as VarChar(150)

SELECT     @ClientName = CLIENT.CL_NAME 
FROM        CLIENT 
WHERE     (CLIENT.CL_CODE = @Client)

SELECT     @DivisionName = DIVISION.DIV_NAME
FROM        DIVISION 
WHERE     (DIVISION.CL_CODE = @Client and DIVISION.DIV_CODE = @Division)

SELECT     @ProductName = PRODUCT.PRD_DESCRIPTION 
FROM        PRODUCT 
WHERE     (PRODUCT.CL_CODE = @Client and PRODUCT.DIV_CODE = @Division and PRODUCT.PRD_CODE = @Product)

SELECT     @JobName = JOB_LOG.JOB_DESC
FROM        JOB_LOG
WHERE     (JOB_LOG.CL_CODE = @Client and JOB_LOG.DIV_CODE = @Division and JOB_LOG.PRD_CODE = @Product and JOB_LOG.JOB_NUMBER = @JobNumber)

SELECT     @JobCompName = JOB_COMPONENT.JOB_COMP_DESC
FROM        JOB_COMPONENT
WHERE     (JOB_COMPONENT.JOB_NUMBER = @JobNumber and JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComponent)

Set @ClientName = isnull(@ClientName, ' ')
Set @DivisionName  = isnull(@DivisionName, ' ')
Set @ProductName  = isnull(@ProductName, ' ')
Set @JobName  = isnull(@JobName, ' ')
Set @JobCompName  = isnull(@JobCompName, ' ')

Select @ClientName as ClientName, @DivisionName as DivisionName, @ProductName as ProductName, @JobName as JobName, @JobCompName as JobCompName
