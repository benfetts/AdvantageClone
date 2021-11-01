SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_hours_viewpoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_hours_viewpoint]
GO


CREATE PROCEDURE [dbo].[usp_wv_dto_hours_viewpoint] 
@grp_level		char(1),	--> 0-none; 1-Function; 2-Job/Comp; 3-Employee
@UserID 	varchar(100),
@ClosedJobs	varchar(1)		--> Y/N

AS

DECLARE @sql varchar(8000)
DECLARE @sql_from varchar(4000)
DECLARE @sql_where varchar(4000)
DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @COUNT AS INTEGER

Declare @Restrictions Int
Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

--Declare @RestrictionsEmp Int
--Select @RestrictionsEmp = Count(*) 
--FROM SEC_EMP
--WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @COUNT = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

-- Determine CDP level
Declare @cl_ct as Int
Declare @div_ct as Int
Declare @prd_ct as Int
Declare @cdp_selection as Int		--> 0-none; 1-c; 2-c/d; 3-c/d/p; 4-campaign

SELECT @cl_ct = COUNT(CL_CODE), @div_ct = COUNT(DIV_CODE), @prd_ct = COUNT(PRD_CODE) FROM PV_CDP WHERE UPPER(USERID) = UPPER(@UserID)
If @cl_ct = 0 
	Set @cdp_selection = 0
If @cl_ct > 0 
	Set @cdp_selection = 1
If @div_ct > 0 
	Set @cdp_selection = 2
If @prd_ct > 0 
	Set @cdp_selection = 3
	
	
-- Determine Emp_Code Filter Level
Declare @AE char(1)	--> Y/N
Declare @emp as varchar(100)

SELECT @emp = EMP_CODE FROM PV_AE WHERE UPPER(USERID) = UPPER(@UserID)

Set @AE = 'N' -- SET @AE to 'N' to take filter out of use for now.
Set @cdp_selection = 0
If @emp = 'ALL' Or @emp Is Null
	Set @AE = 'N'

-- DETERMINE TO INCLUDE CLOSED JOBS (IF GROUPING BY JOB/COMP)
Declare @closed_jobs as varchar(5)	--> True/False

SELECT @closed_jobs = VARIABLE_VALUE
FROM APP_VARS
WHERE VARIABLE_NAME = 'PVInclClosedJobs'	

If @closed_jobs Is Null
	Set @closed_jobs = 'False'

-- Get Start/End Periods
Declare @start_period as varchar(6)
Declare @end_period as varchar(6)
DECLARE @start_month AS varchar(2)
DECLARE @end_month AS varchar(2)
DECLARE @start_year AS varchar(4)
DECLARE @end_year AS varchar(4)

SELECT @start_month = VARIABLE_VALUE
FROM APP_VARS
WHERE VARIABLE_NAME = 'PVMonth'

SELECT @end_month = VARIABLE_VALUE
FROM APP_VARS
WHERE VARIABLE_NAME = 'PVMonth2'

SELECT @start_year = VARIABLE_VALUE
FROM APP_VARS
WHERE VARIABLE_NAME = 'PVYear'

SELECT @end_year = VARIABLE_VALUE
FROM APP_VARS
WHERE VARIABLE_NAME = 'PVYear2'

Set @start_period = @start_year + @start_month
Set @end_period = @end_year + @end_month

If @start_period Is Null --Try getting agency defaults
	Begin
		Select @start_period = CAST(AGY_SETTINGS_VALUE AS VARCHAR(6)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AGY_BLD_PPD_START'
		Select @end_period = CAST(AGY_SETTINGS_VALUE AS VARCHAR(6)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AGY_BLD_PPD_END'
		
		If @start_period Is Not NULL
			Begin
				Select @start_month = LEFT(@start_period, 4)
				Select @end_month = RIGHT(@start_period, 2)
				Select @start_year = LEFT(@end_period, 4)
				Select @end_year = RIGHT(@end_period, 2)
			End
	End
	
If @start_period Is Null --No defaults set, just set to current year
	Begin
		Select @start_month = '01'
		Select @end_month = '12'
		Select @start_year = DATEPART(year, GETDATE())
		Select @end_year = DATEPART(year, GETDATE())
		
		Set @start_period = @start_year + @start_month
		Set @end_period = @end_year + @end_month
	End

-- Get/Set Start/End Dates
Declare @start_date as varchar(12)
Declare @end_date as Varchar(12)
Declare @days as int

Set @start_date = @start_month + '/1/' + @start_year
Set @end_date = @end_month + '/1/' + @end_year
SET @days = DateDiff(day, @end_date, DATEADD(month, 1, @end_date ))
SET @end_date = @end_month + '/' + Cast(@days AS varchar(2)) + '/' + @end_year


CREATE TABLE #HR_VIEWPOINT(
	SORT			INTEGER,
	GROUPING		VARCHAR(80)		COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	HOURS_POSTED	DECIMAL(15,2),
	BILLED_AMT		DECIMAL(15,2),
	UNBILLED_AMT	DECIMAL(15,2),
	NON_BILLABLE	DECIMAL(15,2),
	ADJUSTED_AMT	DECIMAL(15,2),
	QUOTED_HRS		DECIMAL(15,2),
	QVA_VARIANCE	DECIMAL(15,2),
	HRS_ALLOWED		DECIMAL(9,2),
	HRS_VARIANCE	DECIMAL(9,2)
)

--Gather Employee Time Data
--@grp_level		char(1),	--> 0-none; 1-Function; 2-Job/Comp; 3-Employee
Declare @sql_select as varchar(1000)
Declare @sql_group as varchar(1000)
Declare @sql_insert as varchar(1000)

Set @sql_insert = 'INSERT INTO #HR_VIEWPOINT (GROUPING, HOURS_POSTED, BILLED_AMT, UNBILLED_AMT, NON_BILLABLE, ADJUSTED_AMT, QUOTED_HRS, QVA_VARIANCE, HRS_ALLOWED, HRS_VARIANCE) '

If @grp_level = '0' 
	Begin
		Set @sql_select = 'Select NULL, '
		Set @sql_group = ''
	End
If @grp_level = '1' 
	Begin
		Set @sql_select = 'Select F.FNC_DESCRIPTION, '
		Set @sql_group = ' GROUP BY F.FNC_DESCRIPTION '
	End
If @grp_level = '2' 
	Begin
		Set @sql_select = 'Select RIGHT(''00000'' + CAST(ETD.JOB_NUMBER AS VARCHAR(10)),6) + '' / '' + RIGHT(''0'' + CAST(ETD.JOB_COMPONENT_NBR AS VARCHAR(3)),2) + '' - '' + JC.JOB_COMP_DESC, '
		Set @sql_group = ' GROUP BY ETD.JOB_NUMBER, ETD.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC '
	End
If @grp_level = '3' 
	Begin
		Set @sql_select = 'Select ISNULL(dbo.udf_get_empl_name(ET.EMP_CODE,''FML''),''None''), ' 
		Set @sql_group = ' GROUP BY ET.EMP_CODE '
	End

Set @sql = @sql_select + 'ISNULL(SUM(ETD.EMP_HOURS),0), ' 
Set @sql = @sql + 'SUM( (CASE WHEN AR_INV_NBR IS NULL THEN 0 ELSE 1 END) * (TOTAL_BILL + EXT_MARKUP_AMT) ), '
Set @sql = @sql + 'SUM( (TOTAL_BILL + EXT_MARKUP_AMT) - ((CASE WHEN AR_INV_NBR IS NULL THEN 0 ELSE 1 END) * (TOTAL_BILL + EXT_MARKUP_AMT)) ), '
Set @sql = @sql + 'SUM( ISNULL(ETD.EMP_NON_BILL_FLAG,0) * (TOTAL_BILL + EXT_MARKUP_AMT) ), '
Set @sql = @sql + 'SUM( ISNULL(ETD.EXT_MARKUP_AMT,0)), '
Set @sql = @sql + '0,0,0,0 '

Set @sql_from = ' FROM EMP_TIME ET
	INNER JOIN EMP_TIME_DTL ETD ON ET.ET_ID = ETD.ET_ID
	INNER JOIN JOB_LOG JL ON JL.JOB_NUMBER = ETD.JOB_NUMBER 
	INNER JOIN JOB_COMPONENT JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR '

Set @sql_where = ' WHERE ET.EMP_DATE BETWEEN ''' + @start_date + ''' AND ''' + @end_date + ''''

If @ClosedJobs <> 'Y'
	Set @sql_where = @sql_where + ' AND NOT (JC.JOB_PROCESS_CONTRL IN (6, 12)) '

If @grp_level = '1' 
		Set @sql_from = @sql_from + ' INNER JOIN FUNCTIONS F ON F.FNC_CODE = ETD.FNC_CODE '

if @cdp_selection = '0'	 --none 0 (Use Security if any)
	Begin
		If @Restrictions > 0 
		Begin
			Set @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JL.CL_CODE = SEC_CLIENT.CL_CODE 
				AND JL.DIV_CODE = SEC_CLIENT.DIV_CODE 
				AND JL.PRD_CODE = SEC_CLIENT.PRD_CODE 
				And UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
		End
	End

if @cdp_selection = '1'	 --client
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '2'	 --cl/div
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '3'	 --cl/div/prd
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND PV_CDP.PRD_CODE = JL.PRD_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '4'	 --campaign
	Set @sql_from = @sql_from + ' INNER JOIN PV_CMP ON PV_CMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER AND UPPER(PV_CMP.USERID) = UPPER(''' + @UserID + ''') '

If @AE = 'Y' 
	Set @sql_from = @sql_from + ' INNER JOIN PV_AE ON PV_AE.EMP_CODE = ET.EMP_CODE AND UPPER(PV_AE.USERID) = UPPER(''' + @UserID + ''') '


IF @COUNT > 0 
		set @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON JL.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

Set @sql = @sql + @sql_from + @sql_where
Set @sql = @sql_insert + @sql + @sql_group

EXEC(@sql)
--print(@sql)
	

--QUOTED_HRS		
--QVA_VARIANCE = QUOTED_HRS - HOURS_POSTED
--0-none; 1-Function; 2-Job/Comp; 3-Employee
set @sql = ''
If @grp_level = '0' 
	Begin
		Set @sql_select = 'Select NULL, '
		Set @sql_group = ''
	End
If @grp_level = '1' 
	Begin
		Set @sql_select = 'Select F.FNC_DESCRIPTION, '
		Set @sql_group = ' GROUP BY F.FNC_DESCRIPTION '
	End
If @grp_level = '2' 
	Begin		
		Set @sql_select = 'Select RIGHT(''00000'' + CAST(JC.JOB_NUMBER AS VARCHAR(10)),6) + '' / '' + RIGHT(''0'' + CAST(JC.JOB_COMPONENT_NBR AS VARCHAR(3)),2) + '' - '' + JC.JOB_COMP_DESC, '
		Set @sql_group = ' GROUP BY JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC '
	End
If @grp_level = '3' 
	Begin
		Set @sql_select = 'Select ISNULL(dbo.udf_get_empl_name(ERD.EST_REV_SUP_BY_CDE,''FML''), ''None''), ' 
		Set @sql_group = ' GROUP BY ERD.EST_REV_SUP_BY_CDE '
	End

Set @sql = @sql + @sql_select + '0, 0, 0, 0, 0, SUM(ISNULL(ERD.EST_REV_QUANTITY,0)) ,0,0,0 '

Set @sql_from = ' FROM ESTIMATE_REV_DET ERD 
	INNER JOIN JOB_COMPONENT JC ON JC.ESTIMATE_NUMBER = ERD.ESTIMATE_NUMBER
			AND JC.EST_COMPONENT_NBR = ERD.EST_COMPONENT_NBR 
	INNER JOIN JOB_LOG JL ON JC.JOB_NUMBER = JL.JOB_NUMBER  
	INNER JOIN ESTIMATE_APPROVAL EA ON ERD.ESTIMATE_NUMBER = EA.ESTIMATE_NUMBER 
		AND ERD.EST_COMPONENT_NBR = EA.EST_COMPONENT_NBR 
		AND ERD.EST_QUOTE_NBR = EA.EST_QUOTE_NBR
		AND ERD.EST_REV_NBR = EA.EST_REVISION_NBR
	INNER JOIN FUNCTIONS F ON F.FNC_CODE = ERD.FNC_CODE AND F.FNC_TYPE = ''E'''

--If @grp_level = '1' 
	--Set @sql_from = @sql_from + ' INNER JOIN FUNCTIONS F ON F.FNC_CODE = ERD.FNC_CODE AND F.FNC_TYPE = ''E'''
	
if @cdp_selection = '0'	 --none 0 (Use Security if any)
	Begin
		If @Restrictions > 0 
		Begin
			Set @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JL.CL_CODE = SEC_CLIENT.CL_CODE 
				AND JL.DIV_CODE = SEC_CLIENT.DIV_CODE 
				AND JL.PRD_CODE = SEC_CLIENT.PRD_CODE 
				And UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
		End
	End

if @cdp_selection = '1'	 --client
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '2'	 --cl/div
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '3'	 --cl/div/prd
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND PV_CDP.PRD_CODE = JL.PRD_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '4'	 --campaign
	Set @sql_from = @sql_from + ' INNER JOIN PV_CMP ON PV_CMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER AND UPPER(PV_CMP.USERID) = UPPER(''' + @UserID + ''') '


If @AE = 'Y' 
	Set @sql_from = @sql_from + ' INNER JOIN PV_AE ON PV_AE.EMP_CODE = ERD.EST_REV_SUP_BY_CDE AND UPPER(PV_AE.USERID) = UPPER(''' + @UserID + ''') '

IF @COUNT > 0 
		set @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON JL.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

Set @sql_where = ''
If @ClosedJobs <> 'Y'
	Set @sql_where = ' Where NOT (JC.JOB_PROCESS_CONTRL IN (6, 12)) '

Set @sql = @sql + @sql_from + @sql_where
Set @sql = @sql_insert + @sql + @sql_group

EXEC(@sql)
--print(@sql)


--HRS_ALLOWED		
--HRS_VARIANCE = HRS_ALLOWED - HOURS_POSTED
set @sql = ''
If @grp_level = '0' 
	Begin
		Set @sql_select = 'Select NULL, '
		Set @sql_group = ''
	End
If @grp_level = '1' 
	Begin
		Set @sql_select = 'Select F.FNC_DESCRIPTION, '
		Set @sql_group = ' GROUP BY F.FNC_DESCRIPTION '
	End
If @grp_level = '2' 
	Begin
		Set @sql_select = 'Select RIGHT(''00000'' + CAST(JTD.JOB_NUMBER AS VARCHAR(10)),6) + '' / '' + RIGHT(''0'' + CAST(JTD.JOB_COMPONENT_NBR AS VARCHAR(3)),2) + '' - '' + JC.JOB_COMP_DESC, '
		Set @sql_group = ' GROUP BY JTD.JOB_NUMBER, JTD.JOB_COMPONENT_NBR, JC.JOB_COMP_DESC '
	End
If @grp_level = '3' 
	Begin
		Set @sql_select = 'Select ISNULL(dbo.udf_get_empl_name(JTDE.EMP_CODE,''FML''),''None''), ' 
		Set @sql_group = ' GROUP BY JTDE.EMP_CODE '
	End

Set @sql = @sql + @sql_select + '0, 0, 0, 0, 0, 0, 0, SUM(ISNULL(JTDE.HOURS_ALLOWED,0)), 0 '

Set @sql_from = ' FROM  JOB_TRAFFIC_DET JTD
	INNER JOIN JOB_TRAFFIC_DET_EMPS JTDE ON JTDE.JOB_NUMBER = JTD.JOB_NUMBER 
			AND JTDE.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR 
			AND JTDE.SEQ_NBR = JTD.SEQ_NBR 
	INNER JOIN JOB_LOG JL ON JL.JOB_NUMBER = JTD.JOB_NUMBER 
	INNER JOIN JOB_COMPONENT JC ON JC.JOB_NUMBER = JTD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR '


If @grp_level = '1' 
	Set @sql_from = @sql_from + ' INNER JOIN FUNCTIONS F ON F.FNC_CODE = JTD.FNC_EST ' 
	
if @cdp_selection = '0'	 --none 0 (Use Security if any)
	Begin
		If @Restrictions > 0 
		Begin
			Set @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JL.CL_CODE = SEC_CLIENT.CL_CODE 
				AND JL.DIV_CODE = SEC_CLIENT.DIV_CODE 
				AND JL.PRD_CODE = SEC_CLIENT.PRD_CODE 
				And UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
		End
	End

if @cdp_selection = '1'	 --client
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '2'	 --cl/div
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '3'	 --cl/div/prd
	Set @sql_from = @sql_from + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = JL.CL_CODE AND PV_CDP.DIV_CODE = JL.DIV_CODE AND PV_CDP.PRD_CODE = JL.PRD_CODE AND UPPER(PV_CDP.USERID) = UPPER(''' + @UserID + ''') '

if @cdp_selection = '4'	 --campaign
	Set @sql_from = @sql_from + ' INNER JOIN PV_CMP ON PV_CMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER AND UPPER(PV_CMP.USERID) = UPPER(''' + @UserID + ''') '


If @AE = 'Y' 
	Set @sql_from = @sql_from + ' INNER JOIN PV_AE ON PV_AE.EMP_CODE = JTDE.EMP_CODE AND UPPER(PV_AE.USERID) = UPPER(''' + @UserID + ''') '

IF @COUNT > 0 
		set @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON JL.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

Set @sql_where = ''
If @ClosedJobs <> 'Y'
	Set @sql_where = ' Where NOT (JC.JOB_PROCESS_CONTRL IN (6, 12)) '

Set @sql = @sql + @sql_from + @sql_where
Set @sql = @sql_insert + @sql + @sql_group

EXEC(@sql)
--print(@sql)

UPDATE #HR_VIEWPOINT SET SORT = 0

IF @grp_level = '3'
	UPDATE #HR_VIEWPOINT SET SORT = 1 WHERE GROUPING = 'None'


IF @grp_level = '2'
	SELECT GROUPING, SUM(HOURS_POSTED) AS HOURS_POSTED, SUM(BILLED_AMT) AS BILLED_AMT, SUM(UNBILLED_AMT) AS UNBILLED_AMT, SUM(NON_BILLABLE) AS NON_BILLABLE, SUM(ADJUSTED_AMT) AS ADJUSTED_AMT, SUM(QUOTED_HRS) AS QUOTED_HRS, SUM(QUOTED_HRS) - SUM(HOURS_POSTED) AS QVA_VARIANCE, SUM(HRS_ALLOWED) AS HRS_ALLOWED, SUM(HRS_ALLOWED) - SUM(HOURS_POSTED) AS  HRS_VARIANCE
	FROM #HR_VIEWPOINT
	GROUP BY SORT, GROUPING 
	ORDER BY SORT, GROUPING DESC

Else
	SELECT GROUPING, SUM(HOURS_POSTED) AS HOURS_POSTED, SUM(BILLED_AMT) AS BILLED_AMT, SUM(UNBILLED_AMT) AS UNBILLED_AMT, SUM(NON_BILLABLE) AS NON_BILLABLE, SUM(ADJUSTED_AMT) AS ADJUSTED_AMT, SUM(QUOTED_HRS) AS QUOTED_HRS, SUM(QUOTED_HRS) - SUM(HOURS_POSTED) AS QVA_VARIANCE, SUM(HRS_ALLOWED) AS HRS_ALLOWED, SUM(HRS_ALLOWED) - SUM(HOURS_POSTED) AS  HRS_VARIANCE
	FROM #HR_VIEWPOINT
	GROUP BY SORT, GROUPING 
	ORDER BY SORT






GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO