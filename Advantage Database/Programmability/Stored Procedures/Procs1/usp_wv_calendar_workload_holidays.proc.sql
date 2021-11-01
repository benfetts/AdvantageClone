

/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_workload_holidays] 
@UserID VarChar(100),
@start_date SmallDatetime,
@end_date SmallDatetime

AS
--Declare @Rescrictions Int
--
--Set NoCount On
--
--Select @Rescrictions = Count(*) 
--FROM SEC_CLIENT
--WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT  START_DATE, CASE WHEN HOURS = 0.00 THEN (SELECT TRF_HRS FROM AGENCY) ELSE HOURS END AS HOURS
FROM    EMP_NON_TASKS
WHERE   (START_DATE >= @start_date) AND (END_DATE <= @end_date) AND 
									  (TYPE = 'H')


