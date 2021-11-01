if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetFeeDataByClient]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetFeeDataByClient]
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetFeeDataByClient]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Office varchar(4000),
	@Dept varchar(4000),
	@Period int,
	@ClientCode varchar(6),
	@UserID varchar(100)
)
AS
DECLARE @TotalDirect as decimal(12,2), @Restrictions Int,
		@sql nvarchar(4000), @clcode varchar(6), @feetimeamount decimal(15,2), @client varchar(6),
		@paramlist nvarchar(4000), @NumberRecords int, @RowCount int, @StdFeeJobComp int, @ServiceFeeDefintion int

SELECT @ServiceFeeDefintion = COUNT(*) FROM SERVICE_FEE_DEF WHERE UPPER(USER_ID) = UPPER(@UserID)

if @ServiceFeeDefintion > 0
Begin
	SELECT @StdFeeJobComp = ISNULL(STD_FEE_JOB_COMP,0)
	FROM SERVICE_FEE_DEF
	WHERE UPPER(USER_ID) = UPPER(@UserID)
End
Else
Begin
	SELECT TOP(1) @StdFeeJobComp = ISNULL(STD_FEE_JOB_COMP,0)
	FROM SERVICE_FEE_DEF	
End



CREATE TABLE #client(
	RowID int IDENTITY(1, 1), 
	CLIENT varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_NAME varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FEE_AMOUNT decimal(15,2),
	FEE_TIME_AMOUNT decimal(15,2))

CREATE TABLE #clientTotal(
	RowID int IDENTITY(1, 1), 
	CLIENT varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_NAME varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FEE_AMOUNT decimal(15,2),
	FEE_TIME_AMOUNT decimal(15,2))


SELECT @sql = 'INSERT INTO #client
	SELECT ACCT_REC.CL_CODE, CLIENT.CL_NAME, SUM(ISNULL(INCOME_ONLY.IO_AMOUNT,0) + ISNULL(INCOME_ONLY.EXT_MARKUP_AMT,0)) AS FEE_AMOUNT, 0
	FROM POSTPERIOD INNER JOIN
          INCOME_ONLY INNER JOIN
          ACCT_REC ON INCOME_ONLY.AR_INV_NBR = ACCT_REC.AR_INV_NBR AND ACCT_REC.AR_INV_SEQ = INCOME_ONLY.AR_INV_SEQ AND ACCT_REC.AR_TYPE = INCOME_ONLY.AR_TYPE ON 
          POSTPERIOD.PPPERIOD = ACCT_REC.AR_POST_PERIOD LEFT OUTER JOIN
          CLIENT ON CLIENT.CL_CODE = ACCT_REC.CL_CODE
	WHERE ((INCOME_ONLY.FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_FUNC'')) 
				OR (INCOME_ONLY.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
												JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
												WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_SC''))'
			if @StdFeeJobComp = 1
				Begin
				   SELECT @sql = @sql + ' OR (INCOME_ONLY.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM JOB_LOG INNER JOIN
						JOB_COMPONENT ON dbo.JOB_LOG.JOB_NUMBER =JOB_COMPONENT.JOB_NUMBER
						WHERE JOB_COMPONENT.SERVICE_FEE_FLAG = 1)))'
				End
			Else
				Begin
					SELECT @sql = @sql + ') '
				End
			SELECT @sql = @sql + ' AND POSTPERIOD.PPSRTDATE >= @StartDate AND POSTPERIOD.PPENDDATE <= @EndDate '
--			if @EmpCode <> ''
--				Begin
--				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
--				End
--			if @Office <> ''
--				Begin
--					SELECT @sql = @sql + ' AND (EMPLOYEE.OFFICE_CODE = @Office)'
--				End
--			if @Dept <> ''
--				Begin
--					SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.DP_TM_CODE = @Dept)'
--				End			
SELECT @sql = @sql + ' GROUP BY ACCT_REC.CL_CODE, CLIENT.CL_NAME'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @UserID varchar(100)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @UserID
SET @sql = ''
--SELECT * FROM #client

SELECT @sql = 'INSERT INTO #client
	SELECT DASH_DATA_EMP_TIME.CLIENT, CLIENT.CL_NAME, 0, SUM(DASH_DATA_EMP_TIME.BILLED_AMT) AS FEE_TIME_AMOUNT
	FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
		 CLIENT ON CLIENT.CL_CODE = DASH_DATA_EMP_TIME.CLIENT
	WHERE (DASH_DATA_EMP_TIME.FEE_TIME = 1) AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate AND DASH_DATA_EMP_TIME.REC_TYPE = ''B'''
--			if @EmpCode <> ''
--				Begin
--				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
--				End
--			if @Office <> ''
--				Begin
--					SELECT @sql = @sql + ' AND (EMPLOYEE.OFFICE_CODE = @Office)'
--				End
--			if @Dept <> ''
--				Begin
--					SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.DP_TM_CODE = @Dept)'
--				End			
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.CLIENT, CLIENT.CL_NAME'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept
SET @sql = ''
--SELECT * FROM #client

INSERT INTO #clientTotal
SELECT CLIENT, CL_NAME, SUM(FEE_AMOUNT) AS FEE_AMOUNT, SUM(FEE_TIME_AMOUNT) AS FEE_TIME_AMOUNT 
FROM #client
GROUP BY CLIENT, CL_NAME
--SELECT * FROM #clientTotal

if @ClientCode = ''
Begin
	SELECT CLIENT, CL_NAME, ISNULL(SUM(FEE_AMOUNT),0) AS FEE_AMOUNT, ISNULL(SUM(FEE_TIME_AMOUNT),0) AS FEE_TIME_AMOUNT, (ISNULL(SUM(FEE_AMOUNT),0) - ISNULL(SUM(FEE_TIME_AMOUNT),0)) AS VARIANCE
	FROM #clientTotal
	--WHERE FEE_AMOUNT <> 0
	GROUP BY CLIENT, CL_NAME

	SELECT ISNULL(SUM(FEE_AMOUNT),0) AS FEE_AMOUNT, ISNULL(SUM(FEE_TIME_AMOUNT),0) AS FEE_TIME_AMOUNT 
	FROM #clientTotal
	--WHERE FEE_AMOUNT <> 0
End
Else
Begin
	SELECT CLIENT, CL_NAME, ISNULL(SUM(FEE_AMOUNT),0) AS FEE_AMOUNT, ISNULL(SUM(FEE_TIME_AMOUNT),0) AS FEE_TIME_AMOUNT, (ISNULL(SUM(FEE_AMOUNT),0) - ISNULL(SUM(FEE_TIME_AMOUNT),0)) AS VARIANCE  
	FROM #clientTotal 
	WHERE CLIENT = @ClientCode --AND FEE_AMOUNT <> 0
	GROUP BY CLIENT, CL_NAME
End





DROP TABLE #client
DROP TABLE #clientTotal




