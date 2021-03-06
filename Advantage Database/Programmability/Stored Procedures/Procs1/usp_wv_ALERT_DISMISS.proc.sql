IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[usp_wv_ALERT_DISMISS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[usp_wv_ALERT_DISMISS];
END;
GO
CREATE PROCEDURE [dbo].[usp_wv_ALERT_DISMISS] 
@ALERT_ID                  INT,
@USER_CODE                 VARCHAR(100),
@EMP_CODE                  VARCHAR(6),
@CP                        INT,
@CPID                      INT,
@FORCE_ASSIGNMENT_COMPLETE BIT
AS
BEGIN
/*=========== QUERY ===========*/

    DECLARE 
		@ALERT_LEVEL VARCHAR(50), 
		@IS_DISMISSING_PROJECT_SCHEDULE_TASK BIT,
		@IS_PROJECT_SCHEDULE_ALERT BIT;

    SET @IS_DISMISSING_PROJECT_SCHEDULE_TASK = 0;
    SET @FORCE_ASSIGNMENT_COMPLETE = ISNULL(@FORCE_ASSIGNMENT_COMPLETE, 0);

    SELECT 
		@ALERT_LEVEL = A.ALERT_LEVEL,
		@IS_PROJECT_SCHEDULE_ALERT = CASE
										 WHEN A.ALERT_CAT_ID = 71 OR A.ALERT_LEVEL = 'BRD' OR A.ALERT_LEVEL = 'PST' THEN CAST(1 AS BIT)
										 ELSE CAST(0 AS BIT)
									 END
    FROM 
		ALERT AS A WITH(NOLOCK)
    WHERE 
		A.ALERT_ID = @ALERT_ID;

	IF NOT @EMP_CODE IS NULL AND DATALENGTH(@EMP_CODE) > 0
	BEGIN
        EXEC [dbo].[advsp_alert_dismiss_alert] @ALERT_ID, @EMP_CODE;
	END
    IF @CP = 1 AND NOT @CPID IS NULL
    BEGIN
        EXEC [dbo].[usp_wv_ALERT_DISMISS_CP] @ALERT_ID, @CPID;
    END;

    SELECT 
		ISNULL(@IS_PROJECT_SCHEDULE_ALERT, 0);

/*=========== QUERY ===========*/
END