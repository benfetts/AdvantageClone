﻿
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_NotifyGetTasksEmps] /*WITH ENCRYPTION*/
@JOB_NUMBER         INT,
@JOB_COMPONENT_NBR  SMALLINT,
@SEQ_NBR            SMALLINT
AS
IF @SEQ_NBR IS NULL
BEGIN
	SET @SEQ_NBR = -1;
END
/*=========== QUERY ===========*/
IF @SEQ_NBR > -1
	BEGIN
		SELECT DISTINCT EMP_CODE
		FROM   JOB_TRAFFIC_DET_EMPS WITH (NOLOCK)
		WHERE  JOB_NUMBER = @JOB_NUMBER
			   AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
			   AND SEQ_NBR = @SEQ_NBR
		ORDER BY
			   EMP_CODE;
	END
ELSE
	BEGIN
		SELECT DISTINCT EMP_CODE
		FROM   JOB_TRAFFIC_DET_EMPS WITH (NOLOCK)
		WHERE  JOB_NUMBER = @JOB_NUMBER
			   AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
		ORDER BY
			   EMP_CODE;
	END
/*=========== QUERY ===========*/
