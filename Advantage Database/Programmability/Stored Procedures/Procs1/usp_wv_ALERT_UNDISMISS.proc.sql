IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[usp_wv_ALERT_UNDISMISS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
    DROP PROCEDURE [dbo].[usp_wv_ALERT_UNDISMISS];
GO
CREATE PROCEDURE [dbo].[usp_wv_ALERT_UNDISMISS] 
@ALERT_ID                  INT,
@USER_CODE                 VARCHAR(100),
@EMP_CODE                  VARCHAR(6),
@CP                        INT,
@CPID                      INT,
@FORCE_ASSIGNMENT_COMPLETE BIT
AS
/*=========== QUERY ===========*/
BEGIN
	IF NOT @EMP_CODE IS NULL
	BEGIN
		EXEC [dbo].[usp_wv_ALERT_UNDISMISS_NOT_ASSIGNMENT] @ALERT_ID, @EMP_CODE;
	END
	ELSE
	BEGIN
		IF ISNULL(@CP, 0) = 1 AND ISNULL(@CPID, 0) > 0
		BEGIN
			EXEC [dbo].[usp_wv_ALERT_UNDISMISS_CP] @ALERT_ID, @CPID;
		END
	END
    --UPDATE ALERT
    UPDATE ALERT
      SET
          ASSIGN_COMPLETED = 0
    WHERE 
		ALERT_ID = @ALERT_ID;
END;
/*=========== QUERY ===========*/