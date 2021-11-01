


















CREATE PROCEDURE [dbo].[usp_wv_dd_GetStatus] AS

Select STATUS_CODE as Code, STATUS_CODE + ' - ' + STATUS_DESC as Description
from STATUS
WHERE  (ACTIVE = 1)
Order By STATUS_DESC

















