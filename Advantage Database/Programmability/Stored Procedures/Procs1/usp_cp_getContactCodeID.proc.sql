



















CREATE PROCEDURE [dbo].[usp_cp_getContactCodeID] 
@ContactCode VarChar(6),
@ClientCode Varchar(6)
AS
Select CDP_CONTACT_ID
FROM CDP_CONTACT_HDR
WHERE CONT_CODE = @ContactCode 
AND CL_CODE = @ClientCode
 



















