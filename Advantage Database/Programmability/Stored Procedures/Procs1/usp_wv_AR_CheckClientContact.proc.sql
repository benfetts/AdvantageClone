
CREATE PROCEDURE [dbo].[usp_wv_AR_CheckClientContact] 
@EmailAddress VARCHAR(50),
@ClientCode VARCHAR(6)


AS
DECLARE 
@Return INT

SELECT 	@Return = COUNT(*)
FROM 
	CL_CONTACT 
WHERE  
	CL_CODE = @ClientCode
	AND EMAIL_ADDRESS = @EmailAddress

SELECT ISNULL(@Return,0)

