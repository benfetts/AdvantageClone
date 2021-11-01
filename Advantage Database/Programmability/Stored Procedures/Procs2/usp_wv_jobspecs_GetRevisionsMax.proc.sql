





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetRevisionsMax] 
@JobNumber int,
@JobCompNumber int,
@Version int
AS


SELECT MAX(SPEC_REV) AS SPEC_REV_MAX
FROM         JOB_SPECS
WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber) AND (SPEC_VER = @Version)
























