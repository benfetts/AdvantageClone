


















CREATE PROCEDURE [dbo].[usp_wv_GetEmailGroupFromProduct] 
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6)

AS
SET NOCOUNT ON
	SELECT 
		ISNULL(EMAIL_GR_CODE,'') AS EMAIL_GR_CODE
	FROM 
		PRODUCT 
	WHERE     
		(CL_CODE LIKE @ClientCode+'%') 
		AND (DIV_CODE LIKE @DivisionCode+'%') 
		AND (PRD_CODE LIKE @ProductCode+'%')


















