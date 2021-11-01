
CREATE PROCEDURE [dbo].[usp_wv_validate_CDPJC_IsViewable]
@ClientCode VARCHAR(6),
@DivisionCode VARCHAR(6),
@ProductCode VARCHAR(6),
@JobNum Int,
@JobCompNum Int	

AS
DECLARE @ThisReturn INT

If Exists(
SELECT JOB_LOG.JOB_NUMBER
FROM JOB_LOG INNER JOIN
     JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
Where JOB_LOG.CL_CODE LIKE @ClientCode + '%'
AND JOB_LOG.DIV_CODE LIKE @DivisionCode + '%'
AND JOB_LOG.PRD_CODE LIKE @ProductCode + '%'
AND JOB_COMPONENT.JOB_NUMBER = @JobNum
AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobCompNum
)
	Set @ThisReturn = 1
Else
	Set @ThisReturn = 0

SELECT ISNULL(@ThisReturn,0)

