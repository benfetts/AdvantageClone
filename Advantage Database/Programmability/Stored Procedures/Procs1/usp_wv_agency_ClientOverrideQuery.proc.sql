


















CREATE PROCEDURE [dbo].[usp_wv_agency_ClientOverrideQuery] 
@Client Varchar(10)
AS

SELECT REQ_FLDS 
FROM CLIENT
WHERE CL_CODE = @Client


















