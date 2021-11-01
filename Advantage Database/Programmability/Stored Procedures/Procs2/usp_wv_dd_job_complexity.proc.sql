






















CREATE PROCEDURE [dbo].[usp_wv_dd_job_complexity] 

AS
SELECT DISTINCT COMPLEX_CODE as code, COMPLEX_CODE + ' - ' + COMPLEX_DESC as description
FROM COMPLEXITY
WHERE ACTIVE = 1






















