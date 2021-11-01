




















CREATE PROCEDURE [dbo].[usp_wv_get_client_restrictions] 
@UserID VarChar(100) 
AS

Select Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)




















