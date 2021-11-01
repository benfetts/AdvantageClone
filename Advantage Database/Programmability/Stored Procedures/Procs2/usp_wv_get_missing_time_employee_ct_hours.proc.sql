SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_get_missing_time_employee_ct_hours]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_get_missing_time_employee_ct_hours]
GO

CREATE PROCEDURE [dbo].[usp_wv_get_missing_time_employee_ct_hours] 
@UserID			VARCHAR(100)
AS

    DECLARE @WK_TIME   AS INTEGER
    DECLARE @CT        AS INTEGER
    DECLARE @EMP_CODE  AS VARCHAR(6)
    DECLARE @HOURS     AS DECIMAL(10, 2)

    SELECT @EMP_CODE = EMP_CODE
    FROM   SEC_USER WITH(NOLOCK)
    WHERE  UPPER(USER_CODE) = UPPER(@UserID);

    SELECT @WK_TIME = ISNULL(WEEKLY_TIME, 2)
    FROM   EMPLOYEE WITH(NOLOCK)
    WHERE  EMP_CODE = @EMP_CODE;

    IF @WK_TIME = 2
	BEGIN
        SELECT @WK_TIME = ISNULL(WEEKLY_TIME, 0)
        FROM   AGENCY WITH(NOLOCK);
    END	
    	
    IF @WK_TIME = 1 --WEEKLY
    BEGIN
        SELECT ISNULL(@WK_TIME, 0) AS WEEKLY,
               0 AS CT,
               ISNULL(SUM(VARIANCE), 0) AS HOURS
        FROM   MISSING_TIME_DTL WITH(NOLOCK)
        WHERE  EMP_CODE = @EMP_CODE;
    END
    ELSE
        --DAILY
    BEGIN
        SELECT @CT = ISNULL(COUNT(1), 0)
        FROM   MISSING_TIME_DTL WITH(NOLOCK)
        WHERE  EMP_CODE = @EMP_CODE
               AND HOURS_WORKED = 0 AND
			   STANDARD_HRS > 0;
        
        
        SELECT @HOURS = ISNULL(SUM(VARIANCE), 0)
        FROM   MISSING_TIME_DTL WITH(NOLOCK)
        WHERE  EMP_CODE = @EMP_CODE
               AND HOURS_WORKED <> 0
               AND STANDARD_HRS > HOURS_WORKED;
        
        
        SELECT ISNULL(@WK_TIME, 0) AS WEEKLY,
               ISNULL(@CT, 0) AS CT,
               ISNULL(@HOURS, 0) AS HOURS;
    END

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO