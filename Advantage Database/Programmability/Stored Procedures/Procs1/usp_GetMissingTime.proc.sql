


























--Timesheet
CREATE PROCEDURE [dbo].[usp_GetMissingTime] 
@EmpCode as VarChar(6),
@StartDate as SmallDateTime,
@EndDate as SmallDateTime
AS

/* Create a Temp table to hold Dates */
Declare @Counter int
Declare @Days int

SET NOCOUNT ON

Set @Days = DateDiff(d, @StartDate, @EndDate) + 1
Set @Counter = 0
Create Table #Dates(TDate DateTime)
While @Counter < @Days
	Begin
		Insert Into #Dates Values (DateAdd(d, @Counter, @StartDate))
		Set @Counter = @Counter + 1
	End

--Select * from #Dates

/* Create a Temp table to hold work hours */
CREATE TABLE #WorkHours(
	DayOfWeek  VarChar(20), 
	Hours Decimal(9,2))

Insert Into #WorkHours
Select 'Monday', MON_HRS from EMPLOYEE Where EMP_CODE = @EmpCode

Insert Into #WorkHours
Select 'Tuesday', TUE_HRS from EMPLOYEE Where EMP_CODE = @EmpCode

Insert Into #WorkHours
Select 'Wednesday', WED_HRS from EMPLOYEE Where EMP_CODE = @EmpCode

Insert Into #WorkHours
Select 'Thursday', THU_HRS from EMPLOYEE Where EMP_CODE = @EmpCode

Insert Into #WorkHours
Select 'Friday', FRI_HRS from EMPLOYEE Where EMP_CODE = @EmpCode

Insert Into #WorkHours
Select 'Saturday', SAT_HRS from EMPLOYEE Where EMP_CODE = @EmpCode

Insert Into #WorkHours
Select 'Sunday', SUN_HRS from EMPLOYEE Where EMP_CODE = @EmpCode

--Select * from #WorkHours


SELECT  #Dates.TDate AS WorkDate, #WorkHours.DayofWeek AS Weekday, isnull(EMP_TIME.EMP_TOT_HRS, 0) AS HoursWorked, 
                      #WorkHours.Hours AS HoursSched, #WorkHours.Hours - isnull(EMP_TIME.EMP_TOT_HRS, 0) AS HoursMissing
FROM         #Dates INNER JOIN
                      #WorkHours ON DATENAME(weekday, #Dates.TDate) = #WorkHours.DayofWeek LEFT OUTER JOIN
                      HOLIDAYS ON #Dates.TDate = LEFT(HOLIDAYS.HOLIDAY, 10) LEFT OUTER JOIN
                      EMP_TIME ON #Dates.TDate = EMP_TIME.EMP_DATE
WHERE (EMP_TIME.EMP_CODE = @EmpCode
OR EMP_TIME.EMP_CODE is NULL)
AND (HOLIDAYS.HOLIDAY IS NULL)
AND #WorkHours.Hours is NOT NULL
AND #WorkHours.Hours - isnull(EMP_TIME.EMP_TOT_HRS, 0) > 0
ORDER BY #Dates.TDate

























