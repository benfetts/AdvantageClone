if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetHoursByLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetHoursByLevel]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetHoursByLevel]
(
	@EmpCode varchar(6),
	@StartDate varchar(12),
	@EndDate varchar(12),
	@Month int,
	@Office varchar(4000),
	@AE varchar(4000),
	@Client varchar(4000),	
	@Dept varchar(4000),
	@SalesClass varchar(4000),
	@JobType varchar(4000),
	@Period int,
	@YearValue varchar(2),
	@Level varchar(10),
	@UserID varchar(100),
	@CancelledCode VARCHAR(100),
	@IsCancelled VARCHAR(10),
	@Option varchar(20)
)
AS
Declare @sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @no_of_Days int, @NumberRecords int, @RowCount int, @average decimal(5,2), @comps1 int, @comps2 int, @comps3 int, @comps4 int,
		@ws datetime, @dpname varchar(50)

DECLARE @Restrictions INT
DECLARE @OfficeRestrictions INT
DECLARE @EMP_CODE AS VARCHAR(6)

--Check restrictions:
SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE


-- CLIENT
if @Level = 'C'
Begin
	SELECT @sql = 'SELECT JOB_LOG.CL_CODE, CLIENT.CL_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.EST_HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) - SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.FEE_TIME_HRS) AS HOURS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End	 
				SELECT @sql = @sql + ' FROM JOB_COMPONENT INNER JOIN
						 DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
						 JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
						 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
						 CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
		SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
End

-- CLIENT/DIVISION
if @Level = 'CD'
Begin
	SELECT @sql = 'SELECT JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.EST_HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) - SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.FEE_TIME_HRS) AS HOURS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End	 
				SELECT @sql = @sql + ' FROM DIVISION INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON DIVISION.CL_CODE = JOB_LOG.CL_CODE AND 
                      DIVISION.DIV_CODE = JOB_LOG.DIV_CODE INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
		SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME'
		SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
End

-- CLIENT/DIVISION/PRODUCT
if @Level = 'CDP'
Begin
	SELECT @sql = 'SELECT JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.EST_HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) - SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.FEE_TIME_HRS) AS HOURS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End	 
				SELECT @sql = @sql + ' FROM DIVISION INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN
                      PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
                      JOB_COMPONENT INNER JOIN
                      DASH_DATA_PROJ_DTL ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND 
                      PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
		SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION'
		SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
End

--Account Executive
if @Level = 'AE'
Begin
	SELECT @sql = 'SELECT JOB_COMPONENT.EMP_CODE AS ACCT_EXEC, dbo.udf_get_empl_name(JOB_COMPONENT.EMP_CODE, ''FML'') AS ACCT_NAME,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.EST_HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) AS HOURS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.HOURS_QTY) - SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.FEE_TIME_HRS) AS HOURS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End	 
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_DESC = j.vstr collate database_default'
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
		SELECT @sql = @sql + ' GROUP BY JOB_COMPONENT.EMP_CODE'
		SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
End

--DEPARTMENT
if @Level = 'dept'
Begin	
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = ' SELECT ISNULL(JOB_COMPONENT.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DEPT_TEAM.DP_TM_DESC, ''None'') AS DP_TM_DESC, ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_HOURS_QTY),0) AS HOURS'
					End
					Else
					Begin
						SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_DTL.ITEM_DEPT, ''None'') AS DP_TM_CODE, ISNULL(DEPT_TEAM.DP_TM_DESC, ''None'') AS DP_TM_DESC,'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.HOURS_QTY),0) AS HOURS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.HOURS_QTY),0) - SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.FEE_TIME_HRS) AS HOURS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
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
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' GROUP BY JOB_COMPONENT.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC'
					End
					Else
					Begin
						SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_DTL.ITEM_DEPT, DEPT_TEAM.DP_TM_DESC'
					End		
		SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType

End

--SALES CLASS
if @Level = 'SC'
Begin
	SELECT @sql = 'SELECT JOB_LOG.SC_CODE, SALES_CLASS.SC_DESCRIPTION,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_HOURS_QTY),0) AS HOURS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.HOURS_QTY),0) AS HOURS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.HOURS_QTY),0) - SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.FEE_TIME_HRS) AS HOURS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End	 
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      SALES_CLASS ON JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate) '
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
		SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType

End

--JOB TYPE
if @Level = 'JT'
Begin
	SELECT @sql = 'SELECT CASE WHEN JOB_COMPONENT.JT_CODE = '''' THEN ''None'' ELSE ISNULL(JOB_COMPONENT.JT_CODE, ''None'') END AS JT_CODE, CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END AS JT_DESC,'
				IF @Option = 'Estimated'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.EST_HOURS_QTY),0) AS HOURS'
					End
				IF @Option = 'Actual'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.HOURS_QTY),0) AS HOURS'
					End
				IF @Option = 'Billable'
					Begin
						SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_PROJ_DTL.HOURS_QTY),0) - SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End
				IF @Option = 'Fee'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.FEE_TIME_HRS) AS HOURS'
					End
				IF @Option = 'Non Billable'
					Begin
						SELECT @sql = @sql + ' SUM(DASH_DATA_PROJ_DTL.NB_QTY) AS HOURS'
					End	 
				SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_DTL INNER JOIN
                      JOB_COMPONENT ON DASH_DATA_PROJ_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                      DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER LEFT OUTER JOIN
                      JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
		SELECT @sql = @sql + ' GROUP BY CASE WHEN JOB_COMPONENT.JT_CODE = '''' THEN ''None'' ELSE ISNULL(JOB_COMPONENT.JT_CODE, ''None'') END, CASE WHEN JOB_TYPE.JT_DESC IS NULL THEN ISNULL(JOB_COMPONENT.JT_CODE, ''None'') ELSE ISNULL(JOB_TYPE.JT_DESC, ''None'') END'
		SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType

End




GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

