CREATE PROCEDURE [dbo].[usp_wv_get_emp_np_time_all] 
	@USER_ID	varchar(100),
	@EMP_CODE 	varchar(6),
	@START_DATE	smalldatetime,
	@END_DATE	smalldatetime,
	@VIEW		varchar(3)  -- emp. sup, all

AS


SET NOCOUNT ON

DECLARE @sql 		nvarchar(4000)
DECLARE	@sql_where  	nvarchar(1000)
DECLARE @sql_from	nvarchar(1000)
DECLARE @RestrictionsEmp INTEGER
DECLARE @EMP_CODE_CUR	VARCHAR(6)



If @EMP_CODE IS NULL Or @EMP_CODE = 'All' 
	set @EMP_CODE = ''

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
Where UPPER(USER_ID) = UPPER(@USER_ID)

CREATE TABLE ##EMP_STUFF (
	EMP_CODE 	VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EMPLOYEE_NAME VARCHAR(61) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VAC_SICK_FLAG 	SMALLINT, 
	DESCRIPTION 	VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DATE_STRING 	VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AVAIL_HRS 	DECIMAL(9,2),
	HRS_USED 	DECIMAL(8,2),
	VARIANCE 	DECIMAL(9,2),
	CATEGORY	VARCHAR(15) COLLATE SQL_Latin1_General_CP1_CS_AS,
)

If @VIEW = 'emp'
	exec usp_wv_get_emp_np_time @USER_ID, @EMP_CODE, @START_DATE, @END_DATE

Else
     Begin
	SELECT @sql = ' DECLARE employees_cursor CURSOR FOR '
	SELECT @sql = @sql + ' SELECT EMPLOYEE.EMP_CODE '
	SELECT @sql_from = ' FROM EMPLOYEE '
	SELECT @sql_where = ' Where EMP_TERM_DATE is NULL '

	If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @USER_ID + ''')'
	  End

	If @VIEW = 'sup'
		SELECT @sql_where = @sql_where + ' AND EMPLOYEE.SUPERVISOR_CODE = ''' + @EMP_CODE + ''''

	SELECT @sql = @sql + @sql_from + @sql_where
	
	EXEC sp_executesql @sql

	OPEN employees_cursor
 
	FETCH NEXT FROM employees_cursor
	INTO @EMP_CODE_CUR


	WHILE @@FETCH_STATUS = 0
	BEGIN
   		exec usp_wv_get_emp_np_time @USER_ID, @EMP_CODE_CUR, @START_DATE, @END_DATE

   		FETCH NEXT FROM employees_cursor
   		INTO @EMP_CODE_CUR
	END

	CLOSE employees_cursor
	DEALLOCATE employees_cursor
    END


UPDATE ##EMP_STUFF SET VARIANCE = AVAIL_HRS - HRS_USED WHERE VAC_SICK_FLAG IN (1,2,3)

SELECT ES.EMP_CODE, ES.EMPLOYEE_NAME, ES.DESCRIPTION, ES.DATE_STRING, ES.AVAIL_HRS, ES.HRS_USED, ES.VARIANCE, ES.CATEGORY, ES.VAC_SICK_FLAG
FROM ##EMP_STUFF ES

DROP TABLE ##EMP_STUFF

SET QUOTED_IDENTIFIER ON
