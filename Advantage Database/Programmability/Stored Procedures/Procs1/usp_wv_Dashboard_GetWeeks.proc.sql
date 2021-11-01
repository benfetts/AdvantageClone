

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetWeeks]
(
	@Month varchar(6),
	@Year varchar(4),
	@PP smallint,
	@format varchar(10)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @StartDate smalldatetime, @EndDate smalldatetime, @no_of_days int

if @PP = 1
Begin
	SELECT @StartDate = PPSRTDATE, @EndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @Month
End
Else
Begin
	SET @StartDate = @Month + '/1/' + @Year
	SET @EndDate = DateAdd(day, -1, DateAdd(month, DateDiff(month, 0, @StartDate)+1, 0))
End

 
--SELECT @StartDate, @EndDate

set @no_of_days = datediff(dd,@StartDate,@EndDate) + 1
set rowcount @no_of_days
select identity(int,0,1) as dy into #temp from sysobjects a, sysobjects b
set rowcount 0

--SELECT * from #temp

CREATE TABLE #weeks(
	WEEK_START varchar(12) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	WEEK_END varchar(12) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	WEEK_DATE datetime,
	WEEK_NUM smallint)


if @format = 'en-US'
Begin
	INSERT #weeks
	SELECT DISTINCT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),110) AS WEEK_START,
			CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5),110) AS WEEK_END, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate))  
	FROM #temp
	GROUP BY datepart(ww, dateadd(dd,dy,@StartDate)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5), dy
	--ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate)) DESC
	SELECT * FROM #weeks ORDER BY WEEK_NUM
	SELECT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, getdate()), 5),110) AS WEEK_END 
End

if @format = 'fr-FR' or @format = 'es-ES'
Begin
	INSERT #weeks
	SELECT DISTINCT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),103) AS WEEK_START,
			CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5),103) AS WEEK_END, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate))  
	FROM #temp
	GROUP BY datepart(ww, dateadd(dd,dy,@StartDate)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5), dy
	--ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate)) DESC
	SELECT * FROM #weeks ORDER BY WEEK_NUM
	SELECT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, getdate()), 5),103) AS WEEK_END 
End

if @format = 'de'
Begin
	INSERT #weeks
	SELECT DISTINCT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),104) AS WEEK_START,
			CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5),104) AS WEEK_END, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate))  
	FROM #temp
	GROUP BY datepart(ww, dateadd(dd,dy,@StartDate)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5), dy
	--ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate)) DESC
	SELECT * FROM #weeks ORDER BY WEEK_NUM
	SELECT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, getdate()), 5),104) AS WEEK_END 
End

if @format = 'zh-CN'
Begin
	INSERT #weeks
	SELECT DISTINCT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),111) AS WEEK_START,
			CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5),111) AS WEEK_END, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate))  
	FROM #temp
	GROUP BY datepart(ww, dateadd(dd,dy,@StartDate)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5), dy
	--ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate)) DESC
	SELECT * FROM #weeks ORDER BY WEEK_NUM
	SELECT CONVERT(VARCHAR(12),DATEADD(wk, DATEDIFF(wk, 0, getdate()), 5),111) AS WEEK_END 
End


drop table #temp


