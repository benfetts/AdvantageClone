


















CREATE PROCEDURE [usp_wv_defaults_email_group] 

@Client VarChar(6),
@Division VarChar(6),
@Product VarChar(6)
 
AS

SET NOCOUNT ON

Select EMAIL_GR_CODE as EmailGroup From PRODUCT
Where CL_CODE = @Client and 
DIV_CODE = @Division and
PRD_CODE = @Product


















