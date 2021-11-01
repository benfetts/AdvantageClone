
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetHoursPosted]
	@JOB_NUMBER int,
	@JOB_COMP_NUMBER int,
	@FNC_CODE VARCHAR(6),
	@EMP_CODE VARCHAR(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT     dbo.EMP_TIME_DTL.JOB_NUMBER, dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR, dbo.EMP_TIME_DTL.FNC_CODE, 
                      SUM(dbo.EMP_TIME_DTL.EMP_HOURS) AS SumOfEMP_HOURS, EMP_TIME.EMP_CODE
FROM         dbo.EMP_TIME_DTL INNER JOIN
                      dbo.EMP_TIME ON dbo.EMP_TIME_DTL.ET_ID = dbo.EMP_TIME.ET_ID
GROUP BY dbo.EMP_TIME_DTL.JOB_NUMBER, dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR, 
                      dbo.EMP_TIME_DTL.FNC_CODE, EMP_TIME.EMP_CODE
HAVING      (dbo.EMP_TIME_DTL.JOB_NUMBER = @JOB_NUMBER) AND (dbo.EMP_TIME_DTL.JOB_COMPONENT_NBR = @JOB_COMP_NUMBER) AND 
                      (dbo.EMP_TIME_DTL.FNC_CODE = @FNC_CODE) AND (EMP_TIME.EMP_CODE = @EMP_CODE)
                      
END

