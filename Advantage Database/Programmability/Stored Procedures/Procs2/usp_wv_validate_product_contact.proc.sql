





















CREATE PROCEDURE [dbo].[usp_wv_validate_product_contact] 
@ClientCode as VarChar(6), 
@DivisionCode as VarChar(6), 
@ProductCode as VarChar(6),
@ProductContact VarChar(10)
AS
Set NoCount On
 
If Exists(
SELECT CONT_CODE 
FROM V_PRD_CONTACT 
WHERE CL_CODE = @ClientCode
AND DIV_CODE = @DivisionCode
AND PRD_CODE = @ProductCode
AND CONT_CODE = @ProductContact
)
	 select 1
Else
	select  0





















