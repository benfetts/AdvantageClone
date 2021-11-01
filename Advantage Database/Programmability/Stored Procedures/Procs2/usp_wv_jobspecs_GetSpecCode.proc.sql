





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetSpecCode] 
@JobNumber int,
@JobCompNumber int
AS


SELECT    DISTINCT SPEC_TYPE_CODE
FROM         JOB_SPECS
WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber)
























