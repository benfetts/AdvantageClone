

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetJobs_JobHistory]
@Client varchar(6),
@Division varchar(6),
@Product varchar(6),
@JobType varchar(10),
@FromDate smalldatetime,
@ToDate smalldatetime,
@Closed int,
@UserID varchar(100)

AS
DECLARE @Restrictions Int,
	@sql nvarchar(4000),
	@paramlist nvarchar(4000)

	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @OfficeCount AS INTEGER

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE


SELECT @sql = 'SELECT     JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, 
                      JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_COMP_DATE, JOB_COMPONENT.JT_CODE,
				        JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
FROM         JOB_LOG INNER JOIN
                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
			 CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE'
if @OfficeCount > 0
	Begin
		SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
	End

SELECT @sql = @sql + ' WHERE JOB_COMPONENT.JT_CODE = @JobType AND JOB_COMPONENT.JOB_COMP_DATE >= @FromDate AND JOB_COMPONENT.JOB_COMP_DATE <= @ToDate'

if @Client <> ''
	Begin
		SELECT @sql = @sql + ' AND JOB_LOG.CL_CODE = @Client'
	End
if @Division <> ''
	Begin
		SELECT @sql = @sql + ' AND JOB_LOG.DIV_CODE = @Division'
	End
if @Product <> ''
	Begin
		SELECT @sql = @sql + ' AND JOB_LOG.PRD_CODE = @Product'
	End
if @Closed = 1
	Begin
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6,12))'
	End

SELECT @sql = @sql + ' ORDER BY JOB_LOG.JOB_NUMBER DESC'

SELECT @paramlist = '@Client varchar(6), @Division varchar(6), @Product varchar(6), @JobType varchar(10), @FromDate smalldatetime, @ToDate smalldatetime'
print @sql
EXEC sp_executesql @sql, @paramlist, @Client, @Division, @Product, @JobType, @FromDate, @ToDate

	
















