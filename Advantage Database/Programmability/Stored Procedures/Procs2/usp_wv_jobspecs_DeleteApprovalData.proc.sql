





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_DeleteApprovalData] 
@JobNumber int,
@JobCompNumber int
AS


DELETE  FROM JOB_SPEC_APPR
WHERE (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber)























