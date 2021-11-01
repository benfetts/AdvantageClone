
CREATE PROCEDURE usp_wv_get_emp_avail_ass_all 
	@user_id	varchar(100),
	@emp_code	varchar(6),
	@start_date	varchar(12),
	@end_date	varchar(12),
	@sum_level	varchar(1),
	@actualize	varchar(1),
	@OfficeCode VARCHAR(4),
	@ClientCode 	Varchar(6),
	@DivisionCode 	Varchar(6),
	@ProductCode 	Varchar(6),
	@JobNum 	Varchar(6),
	@JobComp 	Varchar(6),
	@Role 		VarChar(6),
	@TaskStatus 	Varchar(1),
	@ExcludeTempComplete Char(1),
	@Depts		Varchar(1000),
	@Manager  varchar(6)

AS
SET NOCOUNT ON

if exists (select * from dbo.sysobjects where name = '##W_ASSIGNED_XREF')
	DROP TABLE ##W_ASSIGNED_XREF

DECLARE @WK_MAX 	INTEGER
DECLARE @WK_MIN 	INTEGER
DECLARE @WK_IDX  	INTEGER
DECLARE @sql 		nvarchar(4000)
DECLARE	@sql_where  nvarchar(1000)
DECLARE @sql_from	nvarchar(1000)
DECLARE @WKNBR 		VARCHAR(2)
DECLARE @EMP_CODE_CUR	VARCHAR(6)

DECLARE @MONTHS_NBR	INTEGER
DECLARE	@WEEKS_NBR	INTEGER
DECLARE	@DAYS_NBR	INTEGER
DECLARE @STARTDAY 	INTEGER
DECLARE @ENDDAY 	INTEGER
DECLARE @RestrictionsEmp INTEGER

DECLARE @startdate 	SMALLDATETIME
DECLARE @enddate 	SMALLDATETIME

If @OfficeCode IS NULL 
	set @OfficeCode = ''

If @ClientCode IS NULL 
	set @ClientCode = ''	

If	@DivisionCode IS NULL 
	set @DivisionCode = '' 	
	
If	@ProductCode  IS NULL 
	set @ProductCode = ''
		
If	@JobNum  IS NULL 
	set @JobNum = ''	
	
If	@JobComp  IS NULL 
	set @JobComp = ''	
	
If	@Role  IS NULL 
	set @Role = ''	
		
If	@TaskStatus  IS NULL 
	set @TaskStatus = ''	
	
If	@ExcludeTempComplete  IS NULL 
	set @ExcludeTempComplete = ''
	
If @Depts IS NULL Or @Depts = '%'
	set @Depts = ''
	
If	@Manager  IS NULL 
	set @Manager = ''
	

SELECT @startdate = CAST(@start_date AS SMALLDATETIME)
SELECT @enddate = CAST(@end_date AS SMALLDATETIME)


SELECT @DAYS_NBR   = DATEDIFF ( day , @startdate , @enddate )
SELECT @WEEKS_NBR  = DATEDIFF ( week , @startdate , @enddate )
SELECT @MONTHS_NBR = DATEDIFF ( month , @startdate , @enddate )

SELECT @STARTDAY = DATEPART(dayofyear, @startdate)
SELECT @ENDDAY = @STARTDAY + @DAYS_NBR

SELECT @WK_MIN =  1
SELECT @sql = 'CREATE TABLE ##W_ASSIGNED_XREF ( OFFICE_CODE VARCHAR(4) COLLATE SQL_Latin1_General_CP1_CS_AS, EMP_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, EMP_DESC VARCHAR(61) COLLATE SQL_Latin1_General_CP1_CS_AS, DP_TM_CODE VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CS_AS, DIRECT_HRS_PER DECIMAL(7,2), HOURS_AVAIL DECIMAL(9,2), DIR_HRS_GOAL DEC(9,2) ' 

If @sum_level = 'd'
	SELECT @WK_MAX =  @DAYS_NBR

If @sum_level = 'w'
	SELECT @WK_MAX =  @WEEKS_NBR

If @sum_level = 'm'
	SELECT @WK_MAX =  @MONTHS_NBR


SELECT @WK_IDX = @WK_MIN
WHILE @WK_IDX < @WK_MAX + 2
BEGIN
	SELECT @WKNBR = CAST(@WK_IDX AS VARCHAR(2))
	SELECT @sql = @sql + ', col' + @WKNBR + ' DECIMAL(9,2) '
	SELECT @WK_IDX = @WK_IDX + 1
END

SELECT @WK_IDX = @WK_MIN
WHILE @WK_IDX < @WK_MAX + 2
BEGIN
	SELECT @WKNBR = CAST(@WK_IDX AS VARCHAR(2))
	SELECT @sql = @sql + ', ass' + @WKNBR + ' DECIMAL(9,2) '
	SELECT @WK_IDX = @WK_IDX + 1
END

SELECT @sql = @sql + ')'


EXEC sp_executesql @sql

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
Where UPPER(USER_ID) = UPPER(@user_id)

If @emp_code = '%' 
BEGIN
	SELECT @sql = ' DECLARE employees_cursor CURSOR FOR '
	SELECT @sql = @sql + ' SELECT EMPLOYEE.EMP_CODE '
	SELECT @sql_from = ' FROM EMPLOYEE '
	SELECT @sql_where = ' Where EMP_TERM_DATE is NULL '

	If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @user_id + ''') AS SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE '
	  End
	  
    If @Role <> '' 
      Begin
        SELECT @sql_from = @sql_from + ' Inner JOIN EMP_TRAFFIC_ROLE ON EMPLOYEE.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
        SELECT @sql_where = @sql_where + ' AND EMP_TRAFFIC_ROLE.ROLE_CODE = ''' + @Role + ''''
      End

    If @Depts <> '' 
        SELECT @sql_where = @sql_where + ' And EMPLOYEE.DP_TM_CODE IN (' + @Depts + ') '


    SELECT @sql = @sql + @sql_from + @sql_where
	
	EXEC sp_executesql @sql

	OPEN employees_cursor
 
	FETCH NEXT FROM employees_cursor
	INTO @EMP_CODE_CUR


	WHILE @@FETCH_STATUS = 0
	BEGIN
   		exec usp_wv_get_emp_avail_ass @user_id, @EMP_CODE_CUR, @start_date, @end_date, @sum_level, @actualize, @OfficeCode, @ClientCode, @DivisionCode, @ProductCode, @JobNum, @JobComp, @Role, @TaskStatus, @ExcludeTempComplete, @Manager

   		FETCH NEXT FROM employees_cursor
   		INTO @EMP_CODE_CUR
	END

	CLOSE employees_cursor
	DEALLOCATE employees_cursor
END
Else
	exec usp_wv_get_emp_avail_ass @user_id, @emp_code, @start_date, @end_date, @sum_level, @actualize, @OfficeCode, @ClientCode, @DivisionCode, @ProductCode, @JobNum, @JobComp, @Role, @TaskStatus, @ExcludeTempComplete, @Manager

SELECT * FROM ##W_ASSIGNED_XREF

DROP TABLE ##W_ASSIGNED_XREF

SET QUOTED_IDENTIFIER ON 
