





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetVersions] 
@JobNumber int,
@JobCompNumber int
AS


SELECT DISTINCT SPEC_VER
FROM         JOB_SPECS
WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber)
























