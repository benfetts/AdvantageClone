

























CREATE PROCEDURE [dbo].[usp_wv_Job_GetCliDivProd] 
@Job Int,
@JobComp Int, 
@Client VarChar(6) OUTPUT, 
@Division VarChar(6) OUTPUT, 
@Product VarChar(6) OUTPUT, 
@RowCount as INT OUTPUT
AS
SELECT    @Client = JOB_LOG.CL_CODE, @Division = JOB_LOG.DIV_CODE, @Product = JOB_LOG.PRD_CODE
FROM         JOB_COMPONENT  WITH (NOLOCK) INNER JOIN
                      JOB_LOG WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
WHERE     (JOB_COMPONENT.JOB_NUMBER = @Job) AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)

Select @RowCount = @@RowCount

























