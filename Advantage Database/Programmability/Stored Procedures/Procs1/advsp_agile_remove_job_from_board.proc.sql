IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_remove_job_from_board]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_remove_job_from_board]
GO

CREATE PROCEDURE [dbo].[advsp_agile_remove_job_from_board]
@BOARD_ID INT,
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT
AS
/*=========== QUERY ===========*/
BEGIN

	DELETE SE
	FROM
		SPRINT_EMPLOYEE SE
		INNER JOIN SPRINT_DTL SD ON SE.SPRINT_DTL_ID = SD.ID AND SD.ALERT_ID = SE.ALERT_ID
		INNER JOIN ALERT A ON SD.ALERT_ID = A.ALERT_ID
		INNER JOIN SPRINT_HDR SH ON SH.ID = SD.SPRINT_HDR_ID
	WHERE		
		SH.BOARD_ID = @BOARD_ID
		AND A.JOB_NUMBER = @JOB_NUMBER
		AND A.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
		AND (A.ASSIGN_COMPLETED IS NULL OR A.ASSIGN_COMPLETED = 0);

	DELETE SD
	FROM
		SPRINT_DTL SD
		INNER JOIN ALERT A ON SD.ALERT_ID = A.ALERT_ID
		INNER JOIN SPRINT_HDR SH ON SH.ID = SD.SPRINT_HDR_ID
	WHERE		
		SH.BOARD_ID = @BOARD_ID
		AND A.JOB_NUMBER = @JOB_NUMBER
		AND A.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
		AND (A.ASSIGN_COMPLETED IS NULL OR A.ASSIGN_COMPLETED = 0);

	DELETE 
	FROM BOARD_JOB 
	WHERE 
		BOARD_ID = @BOARD_ID 
		AND JOB_NUMBER = @JOB_NUMBER 
		AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;

END
/*=========== QUERY ===========*/
