

/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_check_appointments] 
@Allday INT,
@StartDate SmallDatetime,
@EndDate SmallDatetime,
@StartTime Datetime,
@EndTime Datetime,
@EmpCode Varchar(6),
@TaskID INT


AS
--Declare @Rescrictions Int
--
--Set NoCount On
--
--Select @Rescrictions = Count(*) 
--FROM SEC_CLIENT
--WHERE UPPER(USER_ID) = UPPER(@UserID)

IF @Allday = 0
    SELECT  
        COUNT(NON_TASK_ID) AS AppointmentCount
    FROM    
        EMP_NON_TASKS
    WHERE   
        ((NON_TASK_ID <> @TaskID) AND (TYPE = 'A') AND (EMP_CODE = @EmpCode))
        AND 
        (((@StartDate >= START_DATE) AND (@StartDate <= END_DATE) AND (@StartTime >= START_TIME) AND (@StartTime <= END_TIME))  
        OR
        ((@EndDate >= START_DATE) AND (@EndDate <= END_DATE) AND (@EndTime >= START_TIME) AND (@EndTime <= END_TIME)))
ELSE
    SELECT  
        COUNT(NON_TASK_ID) AS AppointmentCount
    FROM    
        EMP_NON_TASKS
    WHERE   
        ((NON_TASK_ID <> @TaskID) AND (TYPE = 'A') AND (EMP_CODE = @EmpCode))
        AND 
        (((@StartDate >= START_DATE) AND (@StartDate <= END_DATE)) 
        OR
        ((@EndDate >= START_DATE) AND (@EndDate <= END_DATE)))
