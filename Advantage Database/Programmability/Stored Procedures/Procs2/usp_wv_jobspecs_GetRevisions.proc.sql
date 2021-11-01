





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetRevisions] 
@JobNumber int,
@JobCompNumber int,
@Version int
AS


SELECT SPEC_REV
FROM         JOB_SPECS
WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber) AND (SPEC_VER = @Version)
























