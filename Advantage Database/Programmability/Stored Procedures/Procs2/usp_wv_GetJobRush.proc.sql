







CREATE PROCEDURE [dbo].[usp_wv_GetJobRush]
@JobNum INT
AS
DECLARE 
@RUSH_CODE int

SELECT     ISNULL(JOB_RUSH_CHARGES, 0)
FROM         dbo.JOB_LOG
WHERE     (JOB_NUMBER = @JobNum)



















