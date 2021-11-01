
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Revenue_Forecast_Dates]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Revenue_Forecast_Dates]
GO

CREATE PROCEDURE [dbo].[usp_wv_Revenue_Forecast_Dates] 
	@START_PERIOD varchar(6),
	@END_PERIOD varchar(6),
	@CURRENT_PERIOD varchar(6),
	@DISPLAY_OPTION smallint

AS

    SET ANSI_NULLS ON
    SET ANSI_WARNINGS OFF
    SET ARITHABORT OFF
    SET ARITHIGNORE ON
		DECLARE @START_DATE smalldatetime, @END_DATE smalldatetime, @no_of_days int

		SELECT @START_DATE = PPSRTDATE
		FROM POSTPERIOD
		WHERE PPPERIOD = @START_PERIOD

		SELECT @END_DATE = PPENDDATE
		FROM POSTPERIOD
		WHERE PPPERIOD = @END_PERIOD

		CREATE TABLE #weeks(
			RowID int IDENTITY(1, 1), 
			[WEEK] int,
			WEEK_START Datetime,
			WEEK_END Datetime)

		set @no_of_days = datediff(dd,@START_DATE,@END_DATE) + 1
		set rowcount @no_of_days
		select identity(int,0,1) as dy into #temp from sysobjects a, sysobjects b
		set rowcount 0

		if @DISPLAY_OPTION = 1
		BEGIN
			INSERT INTO #weeks
			SELECT datepart(ww, dateadd(dd,dy,@START_DATE)) AS DATE_OPENED, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@START_DATE)), 6) AS WEEK_START,
					DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@START_DATE)), 5) AS WEEK_END 
			FROM #temp
			GROUP BY datepart(ww, dateadd(dd,dy,@START_DATE)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@START_DATE)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@START_DATE)), 5)
			ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@START_DATE)), 6), datepart(ww, dateadd(dd,dy,@START_DATE)) DESC
		
			SELECT * FROM #weeks	
		END
		IF @DISPLAY_OPTION = 2
		BEGIN
			SELECT CAST(datename(mm, dateadd(dd,dy,@START_DATE)) AS varchar(3)) AS MONTH_OPENED, DATEADD(mm, DATEDIFF(mm, 0, dateadd(dd,dy,@START_DATE)), 0) AS MONTH_START,
					DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,dateadd(dd,dy,@START_DATE))+1,0)) AS MONTH_END, datepart(m, dateadd(dd,dy,@START_DATE)) AS MTH  
			FROM #temp
			GROUP BY CAST(datename(mm, dateadd(dd,dy,@START_DATE)) AS varchar(3)), DATEADD(mm, DATEDIFF(mm, 0, dateadd(dd,dy,@START_DATE)), 0), DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,dateadd(dd,dy,@START_DATE))+1,0)),datepart(m, dateadd(dd,dy,@START_DATE)) 
			ORDER BY DATEADD(mm, DATEDIFF(mm, 0, dateadd(dd,dy,@START_DATE)), 0)
		END

				

        DROP TABLE #weeks;
        
                




        




                
                
                
                
      



