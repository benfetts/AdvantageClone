IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_remove_external_reviewer_from_assignment]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_remove_external_reviewer_from_assignment];
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_remove_external_reviewer_from_assignment] 
@ALERT_ID INT,
@PROOFING_EXTERNAL_REVIEWER_ID INT
AS
/*=========== QUERY ===========*/
BEGIN
	DELETE FROM ALERT_RCPT_X_REVIEWER WITH(ROWLOCK)
	WHERE
		ALERT_ID = @ALERT_ID
		AND PROOFING_EXTERNAL_REVIEWER_ID = @PROOFING_EXTERNAL_REVIEWER_ID
	;
	DELETE FROM ALERT_RCPT_X_REVIEWER_DISMISSED WITH(ROWLOCK)
	WHERE
		ALERT_ID = @ALERT_ID
		AND PROOFING_EXTERNAL_REVIEWER_ID = @PROOFING_EXTERNAL_REVIEWER_ID
	;
END
/*=========== QUERY ===========*/