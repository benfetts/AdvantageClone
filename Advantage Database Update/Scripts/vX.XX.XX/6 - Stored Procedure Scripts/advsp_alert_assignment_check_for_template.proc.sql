IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_alert_assignment_check_for_template]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_alert_assignment_check_for_template];
END
GO
CREATE PROCEDURE [dbo].[advsp_alert_assignment_check_for_template] 
@ALERT_ID INT,
@SOURCE_ALERT_ID INT = NULL
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE
		@ALRT_NOTIFY_HDR_ID INT,
		@SOURCE_ALRT_NOTIFY_HDR_ID INT
	SELECT
		@ALRT_NOTIFY_HDR_ID = A.ALRT_NOTIFY_HDR_ID
	FROM
		ALERT A WITH(NOLOCK)
	WHERE
		A.ALERT_ID = @ALERT_ID
	;
	SELECT
		@SOURCE_ALRT_NOTIFY_HDR_ID = S.ALRT_NOTIFY_HDR_ID
	FROM
		ALERT S WITH(NOLOCK)
	WHERE
		S.ALERT_ID = @SOURCE_ALERT_ID
	;
	IF @ALRT_NOTIFY_HDR_ID IS NOT NULL
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM ALERT_NOTIFY_EMPS_ASSIGNMENT A WITH(NOLOCK) WHERE A.ALERT_ID = @ALERT_ID)
		BEGIN
			IF @SOURCE_ALERT_ID IS NULL OR @SOURCE_ALERT_ID = 0
			BEGIN
				INSERT INTO ALERT_NOTIFY_EMPS_ASSIGNMENT WITH(ROWLOCK) (ALERT_STATE_ID, ALRT_NOTIFY_HDR_ID, EMP_CODE, IS_DEFAULT, ALERT_ID, IS_SELECTED)
				SELECT 
					A.ALERT_STATE_ID,
					A.ALRT_NOTIFY_HDR_ID,
					A.EMP_CODE,
					CAST(ISNULL(A.IS_DFLT, 0) AS BIT),
					@ALERT_ID,
					CAST(ISNULL(A.IS_DFLT, 0) AS BIT)
				FROM
					ALERT_NOTIFY_EMPS A WITH(NOLOCK)
				WHERE
					A.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
				;	
			END
			ELSE
			BEGIN
				-- IF COPYING ASSIGNMENT, AND TEMPLATE IS SAME, COPY THE EXACT SAME ASSIGNEES.
				IF @ALRT_NOTIFY_HDR_ID = @SOURCE_ALRT_NOTIFY_HDR_ID
				BEGIN
					INSERT INTO ALERT_NOTIFY_EMPS_ASSIGNMENT WITH(ROWLOCK) (ALERT_STATE_ID, ALRT_NOTIFY_HDR_ID, EMP_CODE, ALERT_ID, IS_DEFAULT,IS_SELECTED )
					SELECT
						ANEA.ALERT_STATE_ID,
						ANEA.ALRT_NOTIFY_HDR_ID,
						ANEA.EMP_CODE,
						@ALERT_ID,
						ANEA.IS_DEFAULT,
						ANEA.IS_SELECTED
					FROM
						ALERT_NOTIFY_EMPS_ASSIGNMENT ANEA WITH(NOLOCK)
					WHERE
						ANEA.ALERT_ID = @SOURCE_ALERT_ID
					;
				END
			END
		END	
	END
END
/*=========== QUERY ===========*/