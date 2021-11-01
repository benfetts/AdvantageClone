







CREATE PROCEDURE [dbo].[usp_wv_GetJobTemplateDesc]
@JobTemplateCode Varchar(100)
AS

SELECT     JOB_TMPLT_DESC
FROM         JOB_TMPLT_HDR
WHERE     (JOB_TMPLT_CODE = @JobTemplateCode)



















