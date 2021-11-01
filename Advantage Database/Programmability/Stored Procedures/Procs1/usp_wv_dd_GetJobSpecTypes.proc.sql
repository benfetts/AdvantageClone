CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobSpecTypes] AS

Select SPEC_TYPE_CODE as Code, SPEC_TYPE_CODE + ' - ' + SPEC_TYPE_DESC as Description
from JOB_SPEC_TYPE
WHERE  (INACTIVE_FLAG = 0)
Order By SPEC_TYPE_CODE