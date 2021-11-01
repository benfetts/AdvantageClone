





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetVersionsMax] 
@JobNumber int,
@JobCompNumber int
AS


SELECT ISNULL(MAX(SPEC_VER), 0) AS SPEC_VER
FROM         JOB_SPECS
WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber)
























