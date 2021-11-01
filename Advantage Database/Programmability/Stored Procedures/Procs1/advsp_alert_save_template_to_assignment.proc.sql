IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_alert_save_template_to_assignment]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_alert_save_template_to_assignment];
END
GO
CREATE PROCEDURE [dbo].[advsp_alert_save_template_to_assignment] 
@ALERT_ID INT,
@ALRT_NOTIFY_HDR_ID INT
AS
/*=========== QUERY ===========*/
BEGIN

	--	MAKE SURE IT'S CLEAN
	BEGIN
		DELETE FROM ALERT_NOTIFY_EMPS_ASSIGNMENT WITH(ROWLOCK) WHERE ALERT_ID = @ALERT_ID;
	END
	--	SAVE
	BEGIN

		INSERT INTO ALERT_NOTIFY_EMPS_ASSIGNMENT WITH(ROWLOCK) (ALERT_STATE_ID, ALRT_NOTIFY_HDR_ID, EMP_CODE, IS_DEFAULT, IS_SELECTED, ALERT_ID)
		SELECT 
			A.ALERT_STATE_ID,
			A.ALRT_NOTIFY_HDR_ID,
			A.EMP_CODE,
			CAST(ISNULL(A.IS_DFLT, 0) AS BIT),
			CAST(ISNULL(A.IS_DFLT, 0) AS BIT),
			@ALERT_ID
		FROM
			ALERT_NOTIFY_EMPS A WITH(NOLOCK)
		WHERE
			A.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
		;

	END

END
/*=========== QUERY ===========*/