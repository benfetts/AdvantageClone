


















CREATE PROCEDURE [dbo].[usp_wv_GetStatusDesc]
@ST_CODE VarChar(20) 
AS

Select TRF_DESCRIPTION
from TRAFFIC
WHERE TRF_CODE = @ST_CODE


















