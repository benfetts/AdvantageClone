






CREATE PROCEDURE [dbo].[usp_wv_Job_Template_CheckDuplicateContacts]
@Client varchar(6),
@ContCode VarChar(6)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT CONT_CODE
FROM CDP_CONTACT_HDR
WHERE CL_CODE = @Client AND UPPER(CONT_CODE) = UPPER(@ContCode)
)
	 select 1
Else
	select  0





















