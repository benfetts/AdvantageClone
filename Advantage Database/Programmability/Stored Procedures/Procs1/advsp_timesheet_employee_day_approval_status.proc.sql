IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_timesheet_employee_day_approval_status]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_timesheet_employee_day_approval_status]
GO

CREATE PROCEDURE [dbo].[advsp_timesheet_employee_day_approval_status] 
@EMP_CODE VARCHAR(6), 
@EMP_DATE SMALLDATETIME,
@RETURN_ONLY_TYPE BIT
AS
/*=========== QUERY ===========*/
BEGIN
    DECLARE @EDIT_TYPE INT; /* Edit type numbers below match wvfn_ts_can_edit */
    SET @EDIT_TYPE = 0;
    IF EXISTS ( SELECT *
                FROM AGENCY WITH (NOLOCK)
                WHERE TIME_APPR_ACTIVE = 1
              )
        BEGIN
            SELECT @EDIT_TYPE = 6 -- APPROVED
            WHERE EXISTS ( SELECT ET_ID
                           FROM EMP_TIME AS ET WITH (NOLOCK)
                           WHERE ET.EMP_CODE = @EMP_CODE
                                 AND ET.EMP_DATE = @EMP_DATE
                                 AND APPR_FLAG = 1
                         );
            SELECT @EDIT_TYPE = 5 -- PENDING
            WHERE EXISTS ( SELECT ET_ID
                           FROM EMP_TIME AS ET WITH (NOLOCK)
                           WHERE ET.EMP_CODE = @EMP_CODE
                                 AND ET.EMP_DATE = @EMP_DATE
                                 AND APPR_PENDING = 1
                         );
            SELECT @EDIT_TYPE = 7 -- DENIED
            WHERE EXISTS ( SELECT ET_ID
                           FROM EMP_TIME AS ET WITH (NOLOCK)
                           WHERE ET.EMP_CODE = @EMP_CODE
                                 AND ET.EMP_DATE = @EMP_DATE
                                 AND APPR_PENDING = 2
                         );
        END;
		IF @RETURN_ONLY_TYPE IS NULL OR @RETURN_ONLY_TYPE = 0
		BEGIN
			SELECT 
				[EditType] = @EDIT_TYPE,
				[Description] = CASE
									WHEN @EDIT_TYPE = 6 THEN 'Approved'
									WHEN @EDIT_TYPE = 7 THEN 'Pending'
									WHEN @EDIT_TYPE = 8 THEN 'Denied'
									ELSE 'Open'
								END
		END
		ELSE
		BEGIN
			SELECT 
				[EditType] = @EDIT_TYPE
		END
/*=========== QUERY ===========*/
END
GO