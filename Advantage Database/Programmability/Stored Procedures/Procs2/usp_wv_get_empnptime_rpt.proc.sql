if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_get_empnptime_rpt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_get_empnptime_rpt]
GO

CREATE PROCEDURE usp_wv_get_empnptime_rpt
	@sort		varchar(1),
	@user_id	varchar(100),
	@office		varchar(100),
	@super		varchar(100),
	@emp_codes 	varchar(100),
	@depts		varchar(100),
	@start_date	varchar(12),
	@end_date	varchar(12),
	@inclTermEmp varchar(1),
	@by_type smallint,
	@exclude_freelance smallint
	

AS

SET NOCOUNT ON

DECLARE @sql 			nvarchar(4000)
DECLARE	@sql_where  	nvarchar(2000)
DECLARE @sql_from		nvarchar(1000)
DECLARE @RestrictionsEmp INTEGER
DECLARE @RestrictionsOffice INTEGER
DECLARE @officelist		Varchar(200)
DECLARE @emplist		Varchar(200)
DECLARE @superlist		Varchar(200)
DECLARE @deptlist		Varchar(200)
DECLARE @pos        int,
        @nextpos    int,
        @valuelen   int, @EMP_CODE VARCHAR(6)


set @officelist	= ''
set @emplist = ''
set @superlist = ''
set @deptlist = ''

-- Parse out list into string that can be added to dynamic SQL
If @office <> '%' 
BEGIN

	SELECT @pos = 0, @nextpos = 1, @officelist = ''

	WHILE @nextpos > 0
	BEGIN
		SELECT @nextpos = charindex(',', @office, @pos + 1)
		SELECT @valuelen = CASE WHEN @nextpos > 0
							  THEN @nextpos
							  ELSE len(@office) + 1
						 END - @pos - 1
		If @pos > 0 
			set @officelist = @officelist + ','
		
		set @officelist = @officelist + '''' + substring(@office, @pos + 1, @valuelen) + ''''
		SELECT @pos = @nextpos
	END
END

If @super <> '%' 
BEGIN

	SELECT @pos = 0, @nextpos = 1, @superlist = ''

	WHILE @nextpos > 0
	BEGIN
		SELECT @nextpos = charindex(',', @super, @pos + 1)
		SELECT @valuelen = CASE WHEN @nextpos > 0
							  THEN @nextpos
							  ELSE len(@super) + 1
						 END - @pos - 1
		If @pos > 0 
			set @superlist = @superlist + ','
		
		set @superlist = @superlist + '''' + substring(@super, @pos + 1, @valuelen) + ''''
		SELECT @pos = @nextpos
	END
END

If @emp_codes <> '%' 
BEGIN

	SELECT @pos = 0, @nextpos = 1, @emplist = ''

	WHILE @nextpos > 0
	BEGIN
		SELECT @nextpos = charindex(',', @emp_codes, @pos + 1)
		SELECT @valuelen = CASE WHEN @nextpos > 0
							  THEN @nextpos
							  ELSE len(@emp_codes) + 1
						 END - @pos - 1
		If @pos > 0 
			set @emplist = @emplist + ','
		
		set @emplist = @emplist + '''' + substring(@emp_codes, @pos + 1, @valuelen) + ''''
		SELECT @pos = @nextpos
	END
END

If @depts <> '%' 
BEGIN

	SELECT @pos = 0, @nextpos = 1, @deptlist = ''

	WHILE @nextpos > 0
	BEGIN
		SELECT @nextpos = charindex(',', @depts, @pos + 1)
		SELECT @valuelen = CASE WHEN @nextpos > 0
							  THEN @nextpos
							  ELSE len(@depts) + 1
						 END - @pos - 1
		If @pos > 0 
			set @deptlist = @deptlist + ','
		
		set @deptlist = @deptlist + '''' + substring(@depts, @pos + 1, @valuelen) + ''''
		SELECT @pos = @nextpos
	END
END


Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
Where UPPER(USER_ID) = UPPER(@user_id)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = UPPER(@user_id);
SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

CREATE TABLE #EMP_STUFF (
	SORT varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	OFFICE_NAME VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EMP_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EMPLOYEE_NAME VARCHAR(61) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VAC_SICK_FLAG SMALLINT, 
	DESCRIPTION VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DATE_STRING VARCHAR(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AVAIL_HRS DECIMAL(9,2),
	HRS_USED DECIMAL(8,2),
	VARIANCE DECIMAL(9,2) 
)

set @sql = 'INSERT INTO #EMP_STUFF 
SELECT DISTINCT 1, dbo.udf_get_office_name(E.OFFICE_CODE), E.EMP_CODE, dbo.udf_get_empl_name(E.EMP_CODE, ''FML''), 1, ''Vacation'', CONVERT(VARCHAR(20), VAC_FROM_DATE, 1) + '' - '' +  CONVERT(VARCHAR(20), VAC_TO_DATE , 1), ISNULL(VAC_HRS,0), 0, 0 '

set @sql_from = ' FROM EMPLOYEE E INNER JOIN EMP_DP_TM ED ON E.EMP_CODE = ED.EMP_CODE'

set @sql_where = ' WHERE 1=1 '


If @office <> '%' 
	set @sql_where = @sql_where + ' AND E.OFFICE_CODE IN (' + @officelist + ')'

If @emp_codes <> '%' 
	set @sql_where = @sql_where + ' AND E.EMP_CODE IN (' + @emplist + ')'

If @super <> '%' 
	set @sql_where = @sql_where + ' AND E.SUPERVISOR_CODE IN (' + @superlist + ')'

If @depts <> '%' 
	set @sql_where = @sql_where + ' AND ED.DP_TM_CODE IN (' + @deptlist + ')'
	
If @inclTermEmp <> '1'
	set @sql_where = @sql_where + ' AND E.EMP_TERM_DATE IS NULL '

if @exclude_freelance = 1
	set @sql_where = @sql_where + ' AND (E.FREELANCE IS NULL OR E.FREELANCE = 0) '

If @RestrictionsOffice > 0
Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN	EMP_OFFICE ON E.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '
End

If @RestrictionsEmp > 0
	  Begin
	    SELECT @sql_from = @sql_from + ' ,SEC_EMP '
		--SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @user_id + ''')'
	  End

set @sql = @sql + @sql_from + @sql_where

EXEC(@sql)


set @sql = ' UPDATE #EMP_STUFF SET HRS_USED = (SELECT ISNULL(SUM(ETN.EMP_HOURS),0) '
set @sql_from = ' FROM  EMPLOYEE E
  	INNER JOIN EMP_TIME ET ON E.EMP_CODE = ET.EMP_CODE
  	INNER JOIN EMP_TIME_NP ETN ON ET.ET_ID = ETN.ET_ID
  	INNER JOIN TIME_CATEGORY TC ON ETN.CATEGORY = TC.CATEGORY
	LEFT OUTER JOIN TIME_CATEGORY_TYPE AS TCT ON TC.VAC_SICK_FLAG = TCT.[TYPE_ID] '
  	--INNER JOIN EMP_DP_TM ED ON E.EMP_CODE = ED.EMP_CODE '
set @sql_where = ' WHERE TC.VAC_SICK_FLAG = 1
AND TC.VAC_SICK_FLAG = #EMP_STUFF.VAC_SICK_FLAG
AND E.EMP_CODE = #EMP_STUFF.EMP_CODE  ' 

If @office <> '%' 
	set @sql_where = @sql_where + ' AND E.OFFICE_CODE IN (' + @officelist + ')'

If @emp_codes <> '%' 
	set @sql_where = @sql_where + ' AND E.EMP_CODE IN (' + @emplist + ')'

If @super <> '%' 
	set @sql_where = @sql_where + ' AND E.SUPERVISOR_CODE IN (' + @superlist + ')'

If @depts <> '%' 
	set @sql_where = @sql_where + ' AND (E.DP_TM_CODE IN (' + @deptlist + ') OR E.DP_TM_CODE IS NULL)'
	
If @inclTermEmp <> '1'
	set @sql_where = @sql_where + ' AND E.EMP_TERM_DATE IS NULL '

if @exclude_freelance = 1
	set @sql_where = @sql_where + ' AND (E.FREELANCE IS NULL OR E.FREELANCE = 0) '
	
set @sql_where = @sql_where + ' AND ET.EMP_DATE BETWEEN VAC_FROM_DATE AND VAC_TO_DATE'

If @RestrictionsOffice > 0
Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN	EMP_OFFICE ON E.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '
End

If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' ,SEC_EMP '
		--SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @user_id + ''')'
	  End

set @sql_where = @sql_where + ')'

set @sql = @sql + @sql_from + @sql_where
set @sql = @sql + ' where #EMP_STUFF.DESCRIPTION = ''Vacation'' ' 

EXEC(@sql)


set @sql = 'INSERT INTO #EMP_STUFF 
SELECT DISTINCT 1, dbo.udf_get_office_name(E.OFFICE_CODE), E.EMP_CODE, dbo.udf_get_empl_name(E.EMP_CODE, ''FML''), 2, ''Sick'', CONVERT(VARCHAR(20), SICK_FROM_DATE, 1) + '' - '' +  CONVERT(VARCHAR(20), SICK_TO_DATE, 1), ISNULL(SICK_HRS,0), 0, 0 '
set @sql_from = ' FROM EMPLOYEE E INNER JOIN EMP_DP_TM ED ON E.EMP_CODE = ED.EMP_CODE'

set @sql_where = ' WHERE 1=1 '


If @office <> '%' 
	set @sql_where = @sql_where + ' AND E.OFFICE_CODE IN (' + @officelist + ')'

If @emp_codes <> '%' 
	set @sql_where = @sql_where + ' AND E.EMP_CODE IN (' + @emplist + ')'

If @super <> '%' 
	set @sql_where = @sql_where + ' AND E.SUPERVISOR_CODE IN (' + @superlist + ')'

If @depts <> '%' 
	set @sql_where = @sql_where + ' AND ED.DP_TM_CODE IN (' + @deptlist + ')'
	
If @inclTermEmp <> '1'
	set @sql_where = @sql_where + ' AND E.EMP_TERM_DATE IS NULL '

if @exclude_freelance = 1
	set @sql_where = @sql_where + ' AND (E.FREELANCE IS NULL OR E.FREELANCE = 0) '

If @RestrictionsOffice > 0
Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN	EMP_OFFICE ON E.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '
End

If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' ,SEC_EMP '
		--SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @user_id + ''')'
	  End

set @sql = @sql + @sql_from + @sql_where

EXEC(@sql)


set @sql = ' UPDATE #EMP_STUFF SET HRS_USED = (SELECT ISNULL(SUM(ETN.EMP_HOURS),0) '
set @sql_from = ' FROM  EMPLOYEE E
  	INNER JOIN EMP_TIME ET ON E.EMP_CODE = ET.EMP_CODE
  	INNER JOIN EMP_TIME_NP ETN ON ET.ET_ID = ETN.ET_ID
  	INNER JOIN TIME_CATEGORY TC ON ETN.CATEGORY = TC.CATEGORY
	LEFT OUTER JOIN TIME_CATEGORY_TYPE AS TCT ON TC.VAC_SICK_FLAG = TCT.[TYPE_ID] '
  	--INNER JOIN EMP_DP_TM ED ON E.EMP_CODE = ED.EMP_CODE '
set @sql_where = ' WHERE TC.VAC_SICK_FLAG = 2
AND TC.VAC_SICK_FLAG = #EMP_STUFF.VAC_SICK_FLAG
AND E.EMP_CODE = #EMP_STUFF.EMP_CODE  ' 

If @office <> '%' 
	set @sql_where = @sql_where + ' AND E.OFFICE_CODE IN (' + @officelist + ')'

If @emp_codes <> '%' 
	set @sql_where = @sql_where + ' AND E.EMP_CODE IN (' + @emplist + ')'

If @super <> '%' 
	set @sql_where = @sql_where + ' AND E.SUPERVISOR_CODE IN (' + @superlist + ')'

If @depts <> '%' 
	set @sql_where = @sql_where + ' AND (E.DP_TM_CODE IN (' + @deptlist + ') OR E.DP_TM_CODE IS NULL)'
	
If @inclTermEmp <> '1'
	set @sql_where = @sql_where + ' AND E.EMP_TERM_DATE IS NULL '

if @exclude_freelance = 1
	set @sql_where = @sql_where + ' AND (E.FREELANCE IS NULL OR E.FREELANCE = 0) '
	
set @sql_where = @sql_where + ' AND ET.EMP_DATE BETWEEN SICK_FROM_DATE AND SICK_TO_DATE'

If @RestrictionsOffice > 0
Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN	EMP_OFFICE ON E.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '
End

If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' ,SEC_EMP '
		--SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @user_id + ''')'
	  End

set @sql_where = @sql_where + ')'

set @sql = @sql + @sql_from + @sql_where
set @sql = @sql + ' where #EMP_STUFF.DESCRIPTION = ''Sick'' ' 

EXEC(@sql)


set @sql = 'INSERT INTO #EMP_STUFF 
SELECT DISTINCT 1, dbo.udf_get_office_name(E.OFFICE_CODE), E.EMP_CODE, dbo.udf_get_empl_name(E.EMP_CODE, ''FML''), 3, ''Personal'', CONVERT(VARCHAR(20), PERS_FROM_DATE, 1) + '' - '' +  CONVERT(VARCHAR(20), PERS_TO_DATE, 1), ISNULL(PERS_HRS,0), 0, 0 '
set @sql_from = ' FROM EMPLOYEE E INNER JOIN EMP_DP_TM ED ON E.EMP_CODE = ED.EMP_CODE'

set @sql_where = ' WHERE 1=1 '


If @office <> '%' 
	set @sql_where = @sql_where + ' AND E.OFFICE_CODE IN (' + @officelist + ')'

If @emp_codes <> '%' 
	set @sql_where = @sql_where + ' AND E.EMP_CODE IN (' + @emplist + ')'

If @super <> '%' 
	set @sql_where = @sql_where + ' AND E.SUPERVISOR_CODE IN (' + @superlist + ')'

If @depts <> '%' 
	set @sql_where = @sql_where + ' AND ED.DP_TM_CODE IN (' + @deptlist + ')'
	
If @inclTermEmp <> '1'
	set @sql_where = @sql_where + ' AND E.EMP_TERM_DATE IS NULL '

if @exclude_freelance = 1
	set @sql_where = @sql_where + ' AND (E.FREELANCE IS NULL OR E.FREELANCE = 0) '

If @RestrictionsOffice > 0
Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN	EMP_OFFICE ON E.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '
End

If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' ,SEC_EMP '
		--SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @user_id + ''')'
	  End

set @sql = @sql + @sql_from + @sql_where

EXEC(@sql)


set @sql = ' UPDATE #EMP_STUFF SET HRS_USED = (SELECT ISNULL(SUM(ETN.EMP_HOURS),0) '
set @sql_from = ' FROM  EMPLOYEE E
  	INNER JOIN EMP_TIME ET ON E.EMP_CODE = ET.EMP_CODE
  	INNER JOIN EMP_TIME_NP ETN ON ET.ET_ID = ETN.ET_ID
  	INNER JOIN TIME_CATEGORY TC ON ETN.CATEGORY = TC.CATEGORY
	LEFT OUTER JOIN TIME_CATEGORY_TYPE AS TCT ON TC.VAC_SICK_FLAG = TCT.[TYPE_ID] '
  	--INNER JOIN EMP_DP_TM ED ON E.EMP_CODE = ED.EMP_CODE '
set @sql_where = ' WHERE TC.VAC_SICK_FLAG = 3
AND TC.VAC_SICK_FLAG = #EMP_STUFF.VAC_SICK_FLAG
AND E.EMP_CODE = #EMP_STUFF.EMP_CODE  ' 

If @office <> '%' 
	set @sql_where = @sql_where + ' AND E.OFFICE_CODE IN (' + @officelist + ')'

If @emp_codes <> '%' 
	set @sql_where = @sql_where + ' AND E.EMP_CODE IN (' + @emplist + ')'

If @super <> '%' 
	set @sql_where = @sql_where + ' AND E.SUPERVISOR_CODE IN (' + @superlist + ')'

If @depts <> '%' 
	set @sql_where = @sql_where + ' AND (E.DP_TM_CODE IN (' + @deptlist + ') OR E.DP_TM_CODE IS NULL)'
	
If @inclTermEmp <> '1'
	set @sql_where = @sql_where + ' AND E.EMP_TERM_DATE IS NULL '

if @exclude_freelance = 1
	set @sql_where = @sql_where + ' AND (E.FREELANCE IS NULL OR E.FREELANCE = 0) '
	
set @sql_where = @sql_where + ' AND ET.EMP_DATE BETWEEN PERS_FROM_DATE AND PERS_TO_DATE'

If @RestrictionsOffice > 0
Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN	EMP_OFFICE ON E.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '
End

If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' ,SEC_EMP '
		--SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @user_id + ''')'
	  End

set @sql_where = @sql_where + ')'

set @sql = @sql + @sql_from + @sql_where
set @sql = @sql + ' where #EMP_STUFF.DESCRIPTION = ''Personal'' ' 

EXEC(@sql)

UPDATE #EMP_STUFF SET VARIANCE = AVAIL_HRS - HRS_USED
UPDATE #EMP_STUFF SET [DESCRIPTION] = (SELECT TCT.TYPE_DESC FROM TIME_CATEGORY_TYPE AS TCT WHERE #EMP_STUFF.VAC_SICK_FLAG = TCT.[TYPE_ID])


set @sql = ' INSERT INTO #EMP_STUFF 
	SELECT 2, dbo.udf_get_office_name(E.OFFICE_CODE), ET.EMP_CODE, dbo.udf_get_empl_name(ET.EMP_CODE, ''FML''), TC.VAC_SICK_FLAG, CASE WHEN TCT.TYPE_DESC IS NULL THEN TC.[DESCRIPTION] ELSE TCT.TYPE_DESC END, '''', NULL, ISNULL(SUM(ETN.EMP_HOURS),0), NULL '

set @sql_from = ' FROM  EMPLOYEE E
  	INNER JOIN EMP_TIME ET ON E.EMP_CODE = ET.EMP_CODE
  	INNER JOIN EMP_TIME_NP ETN ON ET.ET_ID = ETN.ET_ID
  	INNER JOIN TIME_CATEGORY TC ON ETN.CATEGORY = TC.CATEGORY
	LEFT OUTER JOIN TIME_CATEGORY_TYPE AS TCT ON TC.VAC_SICK_FLAG = TCT.[TYPE_ID] '
--If @depts <> '%' 
--Begin
--	set @sql_from = @sql_from + ' , EMP_DP_TM ED'
--End

set @sql_where = ' WHERE 1=1'
--If @depts <> '%' 
--Begin
--	set @sql_where = @sql_where + ' AND ET.EMP_CODE = ED.EMP_CODE'
--End

set @sql_where = @sql_where + ' AND ( TC.VAC_SICK_FLAG NOT IN (1,2,3) OR TC.VAC_SICK_FLAG IS NULL ) '

If @office <> '%' 
	set @sql_where = @sql_where + ' AND E.OFFICE_CODE IN (' + @officelist + ')'

If @emp_codes <> '%' 
	set @sql_where = @sql_where + ' AND E.EMP_CODE IN (' + @emplist + ')'

If @super <> '%' 
	set @sql_where = @sql_where + ' AND E.SUPERVISOR_CODE IN (' + @superlist + ')'

If @depts <> '%' 
	set @sql_where = @sql_where + ' AND (E.DP_TM_CODE IN (' + @deptlist + ') OR E.DP_TM_CODE IS NULL)'
	
If @inclTermEmp <> '1'
	set @sql_where = @sql_where + ' AND E.EMP_TERM_DATE IS NULL '

if @exclude_freelance = 1
	set @sql_where = @sql_where + ' AND (E.FREELANCE IS NULL OR E.FREELANCE = 0) '


set @sql_where = @sql_where + ' AND ET.EMP_DATE BETWEEN ''' +Cast(@start_date as varchar) + ''' AND ''' +  Cast(@end_date as varchar) + ''''

If @RestrictionsOffice > 0
Begin
	SELECT @sql_from = @sql_from + ' INNER JOIN	EMP_OFFICE ON E.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '
End

If @RestrictionsEmp > 0
	  Begin
		SELECT @sql_from = @sql_from + ' ,SEC_EMP '
		--SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND E.EMP_CODE = SEC_EMP.EMP_CODE '
		SELECT @sql_where = @sql_where + ' AND UPPER(SEC_EMP.USER_ID) = UPPER(''' +  @user_id + ''')'
	  End

set @sql = @sql + @sql_from + @sql_where
set @sql = @sql + ' GROUP BY dbo.udf_get_office_name(E.OFFICE_CODE), ET.EMP_CODE, TC.VAC_SICK_FLAG,TC.DESCRIPTION, TCT.TYPE_DESC'

EXEC(@sql)
--SELECT * FROM #EMP_STUFF
if @by_type = 1
Begin
	if @sort = '1' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,SUM(AVAIL_HRS) AS AVAIL_HRS,SUM(HRS_USED) AS HRS_USED,(SUM(AVAIL_HRS) - SUM(HRS_USED)) AS VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL
		GROUP BY OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING, SORT
		ORDER BY OFFICE_NAME, EMP_CODE, SORT, DESCRIPTION
	
	if @sort = '2' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,SUM(AVAIL_HRS) AS AVAIL_HRS,SUM(HRS_USED) AS HRS_USED,(SUM(AVAIL_HRS) - SUM(HRS_USED)) AS VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL
		GROUP BY OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING, SORT
		ORDER BY OFFICE_NAME, EMPLOYEE_NAME, SORT, DESCRIPTION

	if @sort = '3' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,SUM(AVAIL_HRS) AS AVAIL_HRS,SUM(HRS_USED) AS HRS_USED,(SUM(AVAIL_HRS) - SUM(HRS_USED)) AS VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL
		GROUP BY OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING, SORT
		ORDER BY EMPLOYEE_NAME, SORT, DESCRIPTION

	if @sort = '4' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,SUM(AVAIL_HRS) AS AVAIL_HRS,SUM(HRS_USED) AS HRS_USED,(SUM(AVAIL_HRS) - SUM(HRS_USED)) AS VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL
		GROUP BY OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING, SORT
		ORDER BY EMP_CODE, SORT, DESCRIPTION
End
Else
Begin
	if @sort = '1' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,AVAIL_HRS,HRS_USED,VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL ORDER BY OFFICE_NAME, EMP_CODE, SORT, DESCRIPTION
	
	if @sort = '2' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,AVAIL_HRS,HRS_USED,VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL ORDER BY OFFICE_NAME, EMPLOYEE_NAME , SORT, DESCRIPTION

	if @sort = '3' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,AVAIL_HRS,HRS_USED,VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL ORDER BY EMPLOYEE_NAME, SORT, DESCRIPTION

	if @sort = '4' 
		SELECT OFFICE_NAME,EMP_CODE,EMPLOYEE_NAME,DESCRIPTION,DATE_STRING,AVAIL_HRS,HRS_USED,VARIANCE  
		FROM #EMP_STUFF
		WHERE DATE_STRING IS NOT NULL ORDER BY EMP_CODE, SORT, DESCRIPTION
End






SET QUOTED_IDENTIFIER ON 
