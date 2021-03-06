IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_alert_dismiss_alert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_alert_dismiss_alert];
END
GO
CREATE PROCEDURE [dbo].[advsp_alert_dismiss_alert] 
@ALERT_ID INT,
@EMP_CODE VARCHAR(6)
AS
BEGIN
     /*=========== QUERY ===========*/
	DECLARE
		@HAS_RECIPIENT_REC BIT,
		@HAS_DISMISSED_REC BIT

	IF EXISTS (SELECT ALERT_ID FROM ALERT_RCPT WITH (NOLOCK) WHERE ALERT_ID = @ALERT_ID AND EMP_CODE = @EMP_CODE AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0))
	BEGIN
		SET @HAS_RECIPIENT_REC = 1;
	END
	ELSE
	BEGIN
		SET @HAS_RECIPIENT_REC = 0;
	END
	IF EXISTS (SELECT ALERT_ID FROM ALERT_RCPT_DISMISSED WITH (NOLOCK) WHERE ALERT_ID = @ALERT_ID AND EMP_CODE = @EMP_CODE AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0))
	BEGIN
		SET @HAS_DISMISSED_REC = 1;
	END
	ELSE
	BEGIN
		SET @HAS_DISMISSED_REC = 0;
	END

	IF @HAS_RECIPIENT_REC = 1 OR @HAS_DISMISSED_REC = 1
	BEGIN
		IF @HAS_RECIPIENT_REC = 1 --  DISMISS
		BEGIN
			INSERT INTO ALERT_RCPT_DISMISSED (
				ALERT_ID, 
				ALERT_RCPT_ID, 
				EMP_CODE, 
				EMAIL_ADDRESS, 
				PROCESSED, 
				NEW_ALERT, 
				READ_ALERT, 
				CURRENT_RCPT, 
				CURRENT_NOTIFY, 
				CARD_SEQ_NBR, 
				CS_IS_REVIEWER, 
				IS_DELETED, 
				ALRT_NOTIFY_HDR_ID, 
				ALERT_STATE_ID, 
				PERC_COMPLETE, 
				COMPLETED_DATE, 
				TEMP_COMP_DATE, 
				HOURS_ALLOWED, 
				LAST_ASSIGNED
			)
			SELECT
				ALERT_ID, 
				ALERT_RCPT_ID, 
				EMP_CODE, 
				EMAIL_ADDRESS, 
				GETDATE(), 
				0, 
				1, 
				CURRENT_RCPT, 
				0, 
				CARD_SEQ_NBR, 
				CS_IS_REVIEWER, 
				IS_DELETED, 
				ALRT_NOTIFY_HDR_ID, 
				ALERT_STATE_ID, 
				PERC_COMPLETE, 
				COMPLETED_DATE, 
				TEMP_COMP_DATE, 
				HOURS_ALLOWED, 
				LAST_ASSIGNED
			FROM 
				ALERT_RCPT
			WHERE 
				ALERT_ID = @ALERT_ID
				AND EMP_CODE = @EMP_CODE
				AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0);
			DELETE FROM ALERT_RCPT
			WHERE 
				ALERT_ID = @ALERT_ID
				AND EMP_CODE = @EMP_CODE
				AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0);
		END
		IF @HAS_DISMISSED_REC = 1 -- RE-OPEN
		BEGIN
			INSERT INTO ALERT_RCPT (
				ALERT_ID, 
				ALERT_RCPT_ID, 
				EMP_CODE, 
				EMAIL_ADDRESS, 
				PROCESSED, 
				NEW_ALERT, 
				READ_ALERT, 
				CURRENT_RCPT, 
				CURRENT_NOTIFY, 
				CARD_SEQ_NBR, 
				CS_IS_REVIEWER, 
				IS_DELETED, 
				ALRT_NOTIFY_HDR_ID, 
				ALERT_STATE_ID, 
				PERC_COMPLETE, 
				COMPLETED_DATE, 
				TEMP_COMP_DATE, 
				HOURS_ALLOWED, 
				LAST_ASSIGNED

			)
			SELECT 
				ALERT_ID, 
				ALERT_RCPT_ID, 
				EMP_CODE, 
				EMAIL_ADDRESS, 
				NULL, 
				1, 
				0, 
				CURRENT_RCPT, 
				0, 
				NULL, 
				CS_IS_REVIEWER, 
				IS_DELETED, 
				ALRT_NOTIFY_HDR_ID, 
				ALERT_STATE_ID, 
				PERC_COMPLETE, 
				COMPLETED_DATE, 
				TEMP_COMP_DATE, 
				HOURS_ALLOWED, 
				LAST_ASSIGNED
			FROM 
				ALERT_RCPT_DISMISSED
			WHERE 
				ALERT_ID = @ALERT_ID
				AND EMP_CODE = @EMP_CODE
				AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0);
			DELETE FROM ALERT_RCPT_DISMISSED
			WHERE 
				ALERT_ID = @ALERT_ID
				AND EMP_CODE = @EMP_CODE
				AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0);
		END
	END
	ELSE
	BEGIN --This seems to happen when a user created an alert (Diary) with no recipients
		INSERT INTO ALERT_RCPT (ALERT_ID, ALERT_RCPT_ID, EMP_CODE, PROCESSED
		)
		VALUES (
			@ALERT_ID,
			1,
			@EMP_CODE,
			GETDATE()
		);
	END;
     /*=========== QUERY ===========*/
END