/*****************************************************************
Gets Job Version Templates for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobVerTmplt] 
AS

Set NoCount On

SELECT  JV_TMPLT_CODE AS Code, JV_TMPLT_CODE + ' - ' + JV_TMPLT_DESC   AS Description
FROM  JOB_VER_TMPLT_HDR
WHERE  ( INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL )


