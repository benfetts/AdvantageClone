IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_cleanup_assignees]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_cleanup_assignees];
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_cleanup_assignees] 
@ALERT_ID INT
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE
		@IS_ROUTED BIT = 0,
		@IS_PROOF BIT = 0,
		@ALRT_NOTIFY_HDR_ID INT,
		@ALERT_STATE_ID INT
	;
	SELECT
		@IS_PROOF =	CASE
						WHEN A.ALERT_CAT_ID = 79 THEN 1
						ELSE 0
					END,
		@IS_ROUTED =	CASE
							WHEN A.ALRT_NOTIFY_HDR_ID > 0 AND A.ALERT_STATE_ID > 0 THEN 1
							ELSE 0
						END,
		@ALRT_NOTIFY_HDR_ID = A.ALRT_NOTIFY_HDR_ID,
		@ALERT_STATE_ID = A.ALERT_STATE_ID
	FROM
		ALERT A WITH(NOLOCK)
	WHERE 
		A.ALERT_ID = @ALERT_ID
	;
	IF @IS_PROOF = 1
	BEGIN
		-- Should never have assignees with no status in the dismissed table
		BEGIN
			DELETE FROM ALERT_RCPT_DISMISSED WITH(ROWLOCK)
			WHERE
				ALERT_ID = @ALERT_ID
				AND CURRENT_NOTIFY = 1
				AND PROOFING_STATUS_ID IS NULL
			;
		END
	END
END
/*=========== QUERY ===========*/
