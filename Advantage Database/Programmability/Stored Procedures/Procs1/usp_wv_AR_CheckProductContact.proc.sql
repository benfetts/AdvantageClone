
CREATE PROCEDURE [dbo].[usp_wv_AR_CheckProductContact] 
@EmailAddress VARCHAR(50),
@ClientCode VARCHAR(6),
@DivisionCode VARCHAR(6),
@ProductCode VARCHAR(6)


AS
DECLARE 
@Return INT

SELECT 	@Return = COUNT(*)
FROM 
	PRD_CONTACT 
WHERE  
	CL_CODE = @ClientCode
	AND DIV_CODE = @DivisionCode
	AND PRD_CODE = @ProductCode
	AND EMAIL_ADDRESS = @EmailAddress

SELECT ISNULL(@Return,0)

