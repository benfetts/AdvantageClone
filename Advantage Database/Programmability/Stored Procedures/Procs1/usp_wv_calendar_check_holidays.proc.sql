

/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_check_holidays] 
--@Allday int,
@StartDate SmallDatetime,
@EndDate SmallDatetime


AS
--Declare @Rescrictions Int
--
--Set NoCount On
--
--Select @Rescrictions = Count(*) 
--FROM SEC_CLIENT
--WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT  Count(NON_TASK_ID) as HolidayCount
FROM    EMP_NON_TASKS
WHERE   (@StartDate >= START_DATE) AND (@StartDate <= END_DATE) AND (TYPE = 'H')  OR
		(@EndDate >= START_DATE) AND (@EndDate <= END_DATE) AND (TYPE = 'H')


