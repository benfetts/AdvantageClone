
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetEmpListByID]
@ID INT
AS

        SELECT     
            JOB_TRAFFIC_DET_EMPS.ID, 
            JOB_TRAFFIC_DET_EMPS.JOB_NUMBER, 
            JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR, 
            JOB_TRAFFIC_DET_EMPS.SEQ_NBR, 
            JOB_TRAFFIC_DET_EMPS.EMP_CODE, 
            ISNULL(EMPLOYEE.EMP_FNAME + ' ', '')+ ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_NAME, 
            ISNULL(JOB_TRAFFIC_DET_EMPS.HOURS_ALLOWED, 0) AS HOURS_ALLOWED,
			JOB_TRAFFIC_DET_EMPS.TEMP_COMP_DATE, 
			JOB_TRAFFIC_DET_EMPS.COMPLETED_COMMENTS,
			JOB_TRAFFIC_DET_EMPS.PERCENT_COMPLETE
        FROM         
            JOB_TRAFFIC_DET_EMPS WITH(NOLOCK) LEFT OUTER JOIN
            EMPLOYEE WITH(NOLOCK) ON JOB_TRAFFIC_DET_EMPS.EMP_CODE = EMPLOYEE.EMP_CODE
        WHERE     
                    ((JOB_TRAFFIC_DET_EMPS.ID = @ID));


