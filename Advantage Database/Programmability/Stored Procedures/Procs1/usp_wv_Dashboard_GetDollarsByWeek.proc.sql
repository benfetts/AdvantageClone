if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetDollarsByWeek]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetDollarsByWeek]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetDollarsByWeek]
(
	@EmpCode varchar(6),
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@Month int,
	@Office varchar(4000),
	@AE varchar(4000),
	@Client varchar(4000),	
	@Dept varchar(4000),
	@SalesClass varchar(4000),
	@JobType varchar(4000),
	@Period int,
	@YearValue varchar(2),
	@Level varchar(5),
	@UserID varchar(100),
	@CancelledCode VARCHAR(100),
	@IsCancelled VARCHAR(10),
	@Option varchar(20),
	@Division varchar(6),
	@Product varchar(6)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @no_of_days int, @NumberRecords int, @RowCount int, @OfficeRestrictions int, @EMP_CODE AS VARCHAR(6)

--Check restrictions:
SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE
		

set @no_of_days = datediff(dd,@StartDate,@EndDate) + 1
set rowcount @no_of_days
select identity(int,0,1) as dy into #temp from sysobjects a, sysobjects b
set rowcount 0

--select dateadd(dd,dy,@StartDate) as [days]
--,       datepart(dy, dateadd(dd,dy,@StartDate)) [day of year]
--,       datename(dw, dateadd(dd,dy,@StartDate)) [day]
--,       datepart(dw, dateadd(dd,dy,@StartDate)-1) [day of week]
--,       datepart(dd, dateadd(dd,dy,@StartDate)) [day of month]
--,       datepart(ww, dateadd(dd,dy,@StartDate)) [week]
--,       datepart(mm, dateadd(dd,dy,@StartDate)) [month]
--,       datename(mm, dateadd(dd,dy,@StartDate)) [month]
--,       datepart(qq, dateadd(dd,dy,@StartDate)) [quarter]
--,       datepart(yy, dateadd(dd,dy,@StartDate)) [year]
--from #temp


SELECT datepart(ww, dateadd(dd,dy,@StartDate)) AS DATE_OPENED, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6) AS WEEK_START,
		DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5) AS WEEK_END 
FROM #temp
GROUP BY datepart(ww, dateadd(dd,dy,@StartDate)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5)
ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate)) DESC

--Client
if @Level = 'C'
Begin
	SELECT @sql = 'SELECT DISTINCT JOB_LOG.CL_CODE, CLIENT.CL_NAME
					FROM JOB_COMPONENT INNER JOIN
						 DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
						 JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
						 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
						 CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End									
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End			
					SELECT @sql = @sql + ' ORDER BY JOB_LOG.CL_CODE'				

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''

				
	SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, JOB_LOG.CL_CODE, CLIENT.CL_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6) AS WEEK_START
					FROM JOB_COMPONENT INNER JOIN
						 DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
						 JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
						 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
						 CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, CLIENT.CL_NAME, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'
					
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT JOB_LOG.CL_CODE, CLIENT.CL_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ' FROM JOB_COMPONENT INNER JOIN
						 DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
						 JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
						 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
						 CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, CLIENT.CL_NAME'			
					SELECT @sql = @sql + ' ORDER BY JOB_LOG.CL_CODE'				
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
End

--Client/Division
if @Level = 'CD'
Begin
	SELECT @sql = 'SELECT DISTINCT JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME
					FROM DIVISION INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND 
                      DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End					
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.DIV_CODE = @Division'
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @Division varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @Division, @UserID
	SET @sql = ''

	
	SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6) AS WEEK_START
					 FROM DIVISION INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND 
                      DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End					
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.DIV_CODE = @Division'
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, CLIENT.CL_NAME, DIVISION.DIV_NAME
											, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'
					

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @Division varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @Division, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ' FROM DIVISION INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND 
                      DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End						
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.DIV_CODE = @Division'
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, CLIENT.CL_NAME, DIVISION.DIV_NAME'	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @Division varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @Division, @UserID
End

--Client/Division/Product
if @Level = 'CDP'
Begin
	SELECT @sql = 'SELECT DISTINCT JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION
					FROM DIVISION INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN
                      PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND 
                      PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End					
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.DIV_CODE = @Division'
						End	
					if @Product <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.PRD_CODE = @Product'
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @Division varchar(6), @Product varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @Division, @Product, @UserID
	SET @sql = ''
					
	SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6) AS WEEK_START
						FROM DIVISION INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN
                      PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND 
                      PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End						
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.DIV_CODE = @Division'
						End	
					if @Product <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.PRD_CODE = @Product'
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
											, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'
					
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @Division varchar(6), @Product varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @Division, @Product, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ' FROM DIVISION INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN
                      PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND 
                      PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End					
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.DIV_CODE = @Division'
						End	
					if @Product <> ''
						Begin
							SELECT @sql = @sql + ' AND JOB_LOG.PRD_CODE = @Product'
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION'	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Client varchar(4000), @AE varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @Division varchar(6), @Product varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Client, @AE, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @Division, @Product, @UserID
End

--AE
if @Level = 'AE'
Begin
	SELECT @sql = 'SELECT DISTINCT JOB_COMPONENT.EMP_CODE AS ACCT_EXEC, dbo.udf_get_empl_name(JOB_COMPONENT.EMP_CODE, ''FML'') AS ACCT_NAME
					FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End						
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @AE varchar(4000), @Client varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @AE, @Client, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''

	SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, JOB_COMPONENT.EMP_CODE AS ACCT_EXEC, dbo.udf_get_empl_name(JOB_COMPONENT.EMP_CODE, ''FML'') AS ACCT_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6) AS WEEK_START
						 FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_COMPONENT.EMP_CODE, dbo.udf_get_empl_name(JOB_COMPONENT.EMP_CODE, ''FML'')	
					, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'
					
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @AE varchar(4000), @Client varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @AE, @Client, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT JOB_COMPONENT.EMP_CODE AS ACCT_EXEC, dbo.udf_get_empl_name(JOB_COMPONENT.EMP_CODE, ''FML'') AS ACCT_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End							
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_COMPONENT.EMP_CODE, dbo.udf_get_empl_name(JOB_COMPONENT.EMP_CODE, ''FML'')'	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @AE varchar(4000), @Client varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @AE, @Client, @Dept, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
End

--Department
if @Level = 'dept'
Begin
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = 'SELECT DISTINCT JOB_COMPONENT.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC'
					End
					Else
					Begin
						SELECT @sql = 'SELECT DISTINCT DASH_DATA_PROJ_DTL.ITEM_DEPT AS DP_TM_CODE, DEPT_TEAM.DP_TM_DESC'
					End
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER'
					IF @Option = 'Estimated'
						Begin
							SELECT @sql = @sql + ' LEFT OUTER JOIN DEPT_TEAM ON JOB_COMPONENT.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE'
						End
						Else
						Begin
							SELECT @sql = @sql + ' LEFT OUTER JOIN DEPT_TEAM ON DASH_DATA_PROJ_DTL.ITEM_DEPT = DEPT_TEAM.DP_TM_CODE'
						End
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND JOB_COMPONENT.DP_TM_CODE IS NOT NULL AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IS NOT NULL AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End									
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''
		
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, JOB_COMPONENT.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC,'
					End
					Else
					Begin
						SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, DASH_DATA_PROJ_DTL.ITEM_DEPT AS DP_TM_CODE, DEPT_TEAM.DP_TM_DESC,'
					End
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6) AS WEEK_START
					 FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER '
					IF @Option = 'Estimated'
						Begin
							SELECT @sql = @sql + ' LEFT OUTER JOIN DEPT_TEAM ON JOB_COMPONENT.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE'
						End
						Else
						Begin
							SELECT @sql = @sql + ' LEFT OUTER JOIN DEPT_TEAM ON DASH_DATA_PROJ_DTL.ITEM_DEPT = DEPT_TEAM.DP_TM_CODE'
						End	
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND JOB_COMPONENT.DP_TM_CODE IS NOT NULL AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IS NOT NULL AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
					
					IF @Option = 'Estimated'
						Begin
							SELECT @sql = @sql + ' GROUP BY JOB_COMPONENT.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC
					, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'
						End
						Else
						Begin
							SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_DTL.ITEM_DEPT, DEPT_TEAM.DP_TM_DESC
					, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'
						End			
					

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

			IF @Option = 'Estimated'
					Begin
						SELECT @sql = 'SELECT JOB_COMPONENT.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC,'
					End
					Else
					Begin
						SELECT @sql = 'SELECT DASH_DATA_PROJ_DTL.ITEM_DEPT AS DP_TM_CODE, DEPT_TEAM.DP_TM_DESC,'
					End	
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER '
					IF @Option = 'Estimated'
						Begin
							SELECT @sql = @sql + ' LEFT OUTER JOIN DEPT_TEAM ON JOB_COMPONENT.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE'
						End
						Else
						Begin
							SELECT @sql = @sql + ' LEFT OUTER JOIN DEPT_TEAM ON DASH_DATA_PROJ_DTL.ITEM_DEPT = DEPT_TEAM.DP_TM_CODE'
						End	
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND JOB_COMPONENT.DP_TM_CODE IS NOT NULL AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IS NOT NULL AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					IF @Option = 'Estimated'
						Begin
							SELECT @sql = @sql + ' GROUP BY JOB_COMPONENT.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC'
						End
						Else
						Begin
							SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_DTL.ITEM_DEPT, DEPT_TEAM.DP_TM_DESC'
						End		
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
End

--Sales Class
if @Level = 'SC'
Begin
	SELECT @sql = 'SELECT DISTINCT JOB_LOG.SC_CODE, SALES_CLASS.SC_DESCRIPTION
					FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      SALES_CLASS ON JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE JOB_LOG.SC_CODE IS NOT NULL AND (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @AE varchar(4000), @Client varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @SalesClass, @AE, @Client, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''
	
	SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, JOB_LOG.SC_CODE, SALES_CLASS.SC_DESCRIPTION,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6) AS WEEK_START
					 FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      SALES_CLASS ON JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE JOB_LOG.SC_CODE IS NOT NULL AND (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.SC_CODE, SALES_CLASS.SC_DESCRIPTION
					, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'
					
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @AE varchar(4000), @Client varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @SalesClass, @AE, @Client, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT JOB_LOG.SC_CODE, SALES_CLASS.SC_DESCRIPTION,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      SALES_CLASS ON JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE JOB_LOG.SC_CODE IS NOT NULL AND (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY JOB_LOG.SC_CODE, SALES_CLASS.SC_DESCRIPTION'	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @SalesClass varchar(4000), @AE varchar(4000), @Client varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @SalesClass, @AE, @Client, @JobType, @CancelledCode, @EMP_CODE, @UserID
End

--Job Type
if @Level = 'JT'
Begin
	SELECT @sql = 'SELECT DISTINCT CASE WHEN JOB_COMPONENT.JT_CODE = '''' THEN ''None'' ELSE ISNULL(JOB_COMPONENT.JT_CODE, ''None'') END AS JT_CODE, CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END AS JT_DESC
					FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE JOB_COMPONENT.JT_CODE IS NOT NULL AND JOB_COMPONENT.JT_CODE <> '''' AND (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End							
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End		
					SELECT @sql = @sql + ' ORDER BY CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END'

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @JobType varchar(4000), @SalesClass varchar(4000), @AE varchar(4000), @Client varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @JobType, @SalesClass, @AE, @Client, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''

	SELECT @sql = 'SELECT DATEPART(week,DASH_DATA_PROJ_DTL.DATE) AS DATE_OPENED, CASE WHEN JOB_COMPONENT.JT_CODE = '''' THEN ''None'' ELSE ISNULL(JOB_COMPONENT.JT_CODE, ''None'') END AS JT_CODE, CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END AS JT_DESC,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6) AS WEEK_START
					 FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE JOB_COMPONENT.JT_CODE IS NOT NULL AND JOB_COMPONENT.JT_CODE <> '''' AND (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End							
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY CASE WHEN JOB_COMPONENT.JT_CODE = '''' THEN ''None'' ELSE ISNULL(JOB_COMPONENT.JT_CODE, ''None'') END, CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END
					, DATEPART(week,DASH_DATA_PROJ_DTL.DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_DTL.DATE), 6)'	
					SELECT @sql = @sql + ' ORDER BY CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END'
					

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @JobType varchar(4000), @SalesClass varchar(4000), @AE varchar(4000), @Client varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @JobType, @SalesClass, @AE, @Client, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT CASE WHEN JOB_COMPONENT.JT_CODE = '''' THEN ''None'' ELSE ISNULL(JOB_COMPONENT.JT_CODE, ''None'') END AS JT_CODE, CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END AS JT_DESC,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_TOTAL),0) AS DOLLARS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) AS DOLLARS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.TOTAL_BILL),0) - SUM(DASH_DATA_PROJ_DTL.NB_AMT) AS DOLLARS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.FEE_TIME_AMT),0) AS DOLLARS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.NB_AMT),0) AS DOLLARS'
					End	 
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE'
					if @Office <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
						End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_CODE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE JOB_COMPONENT.JT_CODE IS NOT NULL AND JOB_COMPONENT.JT_CODE <> '''' AND (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
					IF @Option = 'Estimated'
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'') AND JOB_COMPONENT.DP_TM_CODE IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_DTL.REC_SOURCE = ''EI'' OR DASH_DATA_PROJ_DTL.REC_SOURCE = ''ES'')'
							End						
						End
					Else
						Begin
							if @Dept <> ''
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'' AND DASH_DATA_PROJ_DTL.ITEM_DEPT IN (' + @Dept + ')'
							End
							Else
							Begin
								SELECT @sql = @sql + ' AND DASH_DATA_PROJ_DTL.REC_SOURCE = ''E'''
							End						
						End								
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End	
					SELECT @sql = @sql + ' GROUP BY CASE WHEN JOB_COMPONENT.JT_CODE = '''' THEN ''None'' ELSE ISNULL(JOB_COMPONENT.JT_CODE, ''None'') END, CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END'		
					SELECT @sql = @sql + ' ORDER BY CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END'
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @JobType varchar(4000), @SalesClass varchar(4000), @AE varchar(4000), @Client varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE varchar(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @JobType, @SalesClass, @AE, @Client, @CancelledCode, @EMP_CODE, @UserID
End


drop table #temp

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

