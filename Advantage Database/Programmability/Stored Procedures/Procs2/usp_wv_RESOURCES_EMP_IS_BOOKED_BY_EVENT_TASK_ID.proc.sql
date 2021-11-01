﻿
CREATE PROCEDURE [dbo].[usp_wv_RESOURCES_EMP_IS_BOOKED_BY_EVENT_TASK_ID] /*WITH ENCRYPTION*/
@EMP_CODE           VARCHAR(6),
@EVENT_TASK_ID_NEEDED    INT
AS
/*=========== QUERY ===========*/
DECLARE @EVENT_TASK_DATE_NEEDED  SMALLDATETIME,
        @START_TIME_NEEDED       SMALLDATETIME,
        @END_TIME_NEEDED         SMALLDATETIME,
        @RETURN_COUNT_ONLY       BIT

SELECT @EVENT_TASK_DATE_NEEDED = [START_DATE],
       @START_TIME_NEEDED = START_TIME,
       @END_TIME_NEEDED = END_TIME
FROM   EVENT_TASK WITH(NOLOCK)
WHERE  EVENT_TASK_ID = @EVENT_TASK_ID_NEEDED;
EXEC usp_wv_RESOURCES_EMP_IS_BOOKED @EMP_CODE,
     @EVENT_TASK_ID_NEEDED,
     @EVENT_TASK_DATE_NEEDED,
     @START_TIME_NEEDED,
     @END_TIME_NEEDED,
     0;
/*=========== QUERY ===========*/
