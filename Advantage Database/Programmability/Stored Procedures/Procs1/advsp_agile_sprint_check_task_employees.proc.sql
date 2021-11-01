IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_sprint_check_task_employees]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_sprint_check_task_employees]
GO

CREATE PROCEDURE [dbo].[advsp_agile_sprint_check_task_employees] 
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@TASK_SEQ_NBR SMALLINT
AS
/*=========== QUERY ===========*/
BEGIN

    DECLARE
	   @ALERT_ID INT,
	   @SPRINT_HDR_ID INT

    SELECT TOP 1
	   @ALERT_ID = SD.ALERT_ID,
	   @SPRINT_HDR_ID = SD.SPRINT_HDR_ID
    FROM
	   ALERT A
	   INNER JOIN SPRINT_DTL SD ON A.ALERT_ID = SD.ALERT_ID
	   INNER JOIN SPRINT_HDR SH ON SH.ID = SD.SPRINT_HDR_ID
    WHERE
	   A.JOB_NUMBER = @JOB_NUMBER
	   AND A.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
	   AND A.TASK_SEQ_NBR = @TASK_SEQ_NBR
	   AND A.ALERT_LEVEL = 'BRD'
	   AND (SH.IS_COMPLETE IS NULL OR SH.IS_COMPLETE = 0);

    IF NOT @ALERT_ID IS NULL AND NOT @SPRINT_HDR_ID IS NULL
    BEGIN
	   EXEC [dbo].[advsp_agile_sprint_check_employee_records] @SPRINT_HDR_ID, @ALERT_ID;
    END

END
/*=========== QUERY ===========*/