

/*
ST, 20060614
Created to get markup from the product table.
Used in jobjacket when creating a new job comp and viewing existing job comp
if it is an exisiting job comp, it grabs it from the job comp first, only if it isn't there will this get called
*/

CREATE PROCEDURE [dbo].[usp_wv_job_component_GetDefaultMarkup] 
(@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6),
@markup_pct decimal(7,3) OUTPUT)
AS


SELECT	
 @markup_pct = ISNULL(PRD_PROD_MARKUP,0)
FROM	
	[PRODUCT]
WHERE     
	CL_CODE = @ClientCode and  DIV_CODE = @DivisionCode and PRD_CODE = @ProductCode      
	--(CL_CODE LIKE @ClientCode+'%') 
	--AND (DIV_CODE LIKE @DivisionCode+'%') 
	--AND (PRD_CODE LIKE @ProductCode+'%')















