


















CREATE PROCEDURE [dbo].[usp_wv_dd_GetRegions] AS

Select REGION_CODE as Code, REGION_CODE + ' - ' + REGION_DESC as Description
from REGION
WHERE  (ACTIVE = 1)
Order By REGION_DESC

















