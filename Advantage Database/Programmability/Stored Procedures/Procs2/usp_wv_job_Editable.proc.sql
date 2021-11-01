






CREATE PROCEDURE [dbo].[usp_wv_job_Editable] 
@UserField Varchar(50)
AS



Select ISNULL(EDITABLE,0) AS EDITABLE
FROM UDV_LABEL
WHERE UDV_TABLE_NAME = @UserField

















