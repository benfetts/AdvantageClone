





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetSeqNumMax] 
@JobNumber int,
@JobCompNumber int,
@Version int,
@Revision int
AS


SELECT ISNULL(MAX(SEQ_NBR),-1) AS SEQ_NBR_MAX
FROM         JOB_SPEC_QTY
WHERE     (JOB_NUMBER = @JobNumber) AND (JOB_COMPONENT_NBR = @JobCompNumber) AND (SPEC_VER = @Version) AND (SPEC_REV = @Revision) 
























