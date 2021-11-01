
CREATE PROCEDURE [dbo].[usp_wv_Get_WorkDays] 
@StartDate DATETIME,
@EndDate DATETIME,
@IncludeHolidays SMALLINT


AS
DECLARE @i INT 
DECLARE @WorkDays INT
DECLARE @Holidays INT
DECLARE @DaysNo INT
DECLARE @DatePivot DATETIME


--Test:
--SET @StartDate = '03/01/2008'
--SET @EndDate = '04/08/2008'
--SET @IncludeHolidays = 1

--Initialize:
SET @i = 0
SET @WorkDays = 0
SET @DaysNo = DATEDIFF(DD, @StartDate, @EndDate) + 1
IF (@IncludeHolidays IS NULL) SET @IncludeHolidays = 0
IF (@StartDate IS NULL) SET @StartDate = GETDATE()
IF (@EndDate IS NULL) SET @EndDate = GETDATE()

WHILE @i <= @DaysNo - 1
	BEGIN
		SET @DatePivot = DATEADD(DD, + @i, @StartDate)
		IF DATENAME(DW, @DatePivot) NOT IN ('Saturday', 'Sunday') SET @WorkDays = @WorkDays + 1
		SET @i = @i + 1
	END

IF @IncludeHolidays = 0
	BEGIN
		SELECT ISNULL(@WorkDays,0)
	END
ELSE
	BEGIN
		--Get number of holidays (whole days only)
		SELECT     
			@Holidays = COUNT(1) 
		FROM         
			EMP_NON_TASKS
		WHERE		
			(TYPE = 'H') 
			AND (ALL_DAY = 1) 
			AND (START_DATE >= @StartDate) 
			AND (END_DATE <= @EndDate)

		SELECT ISNULL(@WorkDays,0) - ISNULL(@Holidays,0)
	END

