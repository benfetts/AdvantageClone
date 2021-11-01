
CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetJobSpecsQtyDataRows] 
@JobNumber Int,
@JobCompNumber Int,
@Version Int,
@Revision Int
AS

Set NoCount On

SELECT JOB_NUMBER, JOB_COMPONENT_NBR, SPEC_VER, SPEC_REV, SEQ_NBR, ISNULL(JOB_QTY,'') AS JOB_QTY
				FROM JOB_SPEC_QTY
				   WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobCompNumber
					AND (SPEC_VER = @Version)
					AND (SPEC_REV = @Revision)			
ORDER BY SEQ_NBR			



	
