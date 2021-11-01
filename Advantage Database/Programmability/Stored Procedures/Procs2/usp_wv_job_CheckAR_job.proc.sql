


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_job_CheckAR_job]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_job_CheckAR_job]
GO



/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_job_CheckAR_job]
@JobNum INT

AS

SELECT COUNT(*)
FROM  ARINV_JOB
WHERE (JOB_NUMBER = @JobNum) 
















