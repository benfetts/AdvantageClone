
CREATE PROCEDURE [dbo].[usp_wv_ALERT_DISMISS_CP] /*WITH ENCRYPTION*/
@ALERT_ID  INT,
@CDP_CONTACT_ID INT
AS
/*=========== QUERY ===========*/
	IF EXISTS (
	       SELECT *
	       FROM   CP_ALERT_RCPT
	       WHERE  ALERT_ID = @ALERT_ID
	              AND CDP_CONTACT_ID = @CDP_CONTACT_ID
	              AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0)
	   )
	BEGIN
	    UPDATE CP_ALERT_RCPT
	    SET    PROCESSED = GETDATE()
	    WHERE  ALERT_ID = @ALERT_ID
	           AND CDP_CONTACT_ID = @CDP_CONTACT_ID
	           AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0);
	END
	ELSE
	    --This seems to happen when a user created an alert (Diary) with no recipients
	BEGIN
	    INSERT INTO CP_ALERT_RCPT
	      (
	        ALERT_ID,
	        ALERT_RCPT_ID,
	        CDP_CONTACT_ID,
	        PROCESSED
	      )
	    VALUES
	      (
	        @ALERT_ID,
	        1,
	        @CDP_CONTACT_ID,
	        GETDATE()
	      );
	END
	
	DECLARE @ALERT_LEVEL        VARCHAR(50),
	        @JOB_NUMBER         INT,
	        @JOB_COMPONENT_NBR  SMALLINT,
	        @TASK_SEQ_NBR       SMALLINT
	
	SELECT @ALERT_LEVEL = ISNULL(ALERT_LEVEL, ''),
	       @JOB_NUMBER = ISNULL(JOB_NUMBER, 0),
	       @JOB_COMPONENT_NBR = ISNULL(JOB_COMPONENT_NBR, 0),
	       @TASK_SEQ_NBR = ISNULL(TASK_SEQ_NBR, -1)
	FROM   ALERT WITH(NOLOCK)
	WHERE  ALERT_ID = @ALERT_ID;
	
	
	--MOVE DIMISSED TO DISMISSED TABLE
	INSERT INTO CP_ALERT_RCPT_DISMISSED
	SELECT *
	FROM   CP_ALERT_RCPT
	WHERE  ALERT_ID = @ALERT_ID
	       AND CDP_CONTACT_ID = @CDP_CONTACT_ID
	       AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0);
	
	--DELETE DISMISSED FROM MAIN TABLE
	DELETE 
	FROM   CP_ALERT_RCPT
	WHERE  ALERT_ID = @ALERT_ID
	       AND CDP_CONTACT_ID = @CDP_CONTACT_ID
	       AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0);
/*=========== QUERY ===========*/
