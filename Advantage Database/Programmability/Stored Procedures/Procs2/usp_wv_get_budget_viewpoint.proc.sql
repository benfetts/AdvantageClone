
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_get_budget_viewpoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_get_budget_viewpoint]
GO

/*
 Purpose: Returns result set providing:	Budget Billing,			 Budget Gross Income
										Actual/Forecast Billing, Actual/Forecast Gross Income
										
		  by All, by Type or by Sales Class
		  
NOTE: The Actual/Forecast columns may consist of the following data:
		Actual Billed (Production & Media)
		Actual Posted (Production & Media)
		Forecasted - Approved Billing & Actual Media Posted
		Forecasted - Approved Estimate by Approved Date & Actual Media Posted
		Forecasted - Approved Estimate by Job Due Date & Actual Media Posted
		
==========================================================
 History:
==========================================================
jtg : 1/13/2009 - Created
jtg : 3/15/2009 - Added Forecasted Billing & GI columns
jtg : 3/18/2009 - Took out hardcoded Actuals & Forecast for dynamic creation of actual billed/Posted Or 
				  Forecasted - Appr Billing/Est by Approved Date OR Job Due Date & Actual Media Posted
jtg : 7/02/2009	- Added Userid to cdp filter for when there is more than one user in PV_CDP table
jtg : 8/07/2009	- Added Office/Employee Security

*/

CREATE PROCEDURE usp_wv_get_budget_viewpoint 
	@GroupLevel	INTEGER,		--> 1-All	2-Type (Production/Media)	3-Sales Class
	@UserID 	varchar(100)
AS

SET NOCOUNT ON

DECLARE @sql		VARCHAR(8000)
DECLARE @sql_from	VARCHAR(4000)
DECLARE @sql_where	VARCHAR(4000)
DECLARE @sql_cdp	VARCHAR(1000)
DECLARE @budget_period	VARCHAR(6)
DECLARE @budget_period_to VARCHAR(6)
DECLARE @count		INTEGER
DECLARE @cdpc_level INTEGER
DECLARE	@Mth		VARCHAR(2)
DECLARE	@Yr			VARCHAR(4)
DECLARE	@MthTo		VARCHAR(2)
DECLARE	@YrTo		VARCHAR(4)
DECLARE @ForecastLevel VARCHAR(3)
DECLARE @ACTUAL_GRP VARCHAR(10)
DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeEmpCt AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeEmpCt = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

Declare @Restrictions Int
Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

--Build @budget_period
SELECT @Mth = VARIABLE_VALUE FROM APP_VARS WHERE UPPER(USERID) = UPPER(@UserID) AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_NAME = 'PVMonth'
SELECT @Yr = VARIABLE_VALUE FROM APP_VARS WHERE UPPER(USERID) = UPPER(@UserID) AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_NAME = 'PVYear'
SELECT @MthTo = VARIABLE_VALUE FROM APP_VARS WHERE UPPER(USERID) = UPPER(@UserID) AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_NAME = 'PVMonth2'
SELECT @YrTo = VARIABLE_VALUE FROM APP_VARS WHERE UPPER(USERID) = UPPER(@UserID) AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_NAME = 'PVYear2'

If LEN(@Mth) > 0 And LEN(@MthTo) > 0
  Begin
	If LEN(@Mth) = 1
		Set @Mth = '0' + @Mth
	If LEN(@MthTo) = 1
		Set @MthTo = '0' + @MthTo

	Set @budget_period = @Yr + @Mth
	Set @budget_period_to = @YrTo + @MthTo
  End
  
Else
  Begin
	Select @budget_period = CAST(AGY_SETTINGS_VALUE AS VARCHAR(6)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AGY_BLD_PPD_START'
	Select @budget_period_to = CAST(AGY_SETTINGS_VALUE AS VARCHAR(6)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AGY_BLD_PPD_END'
  End
  

SELECT @count = COUNT(*) FROM APP_VARS 
WHERE UPPER(USERID) = UPPER(@UserID) 
AND APPLICATION = 'PROJECTVIEWPOINT' 
AND VARIABLE_NAME = 'PVForecast'

If @count > 0 
  Begin
	SELECT @ForecastLevel = VARIABLE_VALUE FROM APP_VARS WHERE UPPER(USERID) = UPPER(@UserID) AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_NAME = 'PVForecast'

	Select @ACTUAL_GRP =
		Case LTRIM(@ForecastLevel)
			When '0'	Then '0'	-- Actual Billed
			When '1'	Then '0'	-- Actual Posted
			When '2'	Then '1,3'	-- Forecasted - Approved Billing & Actual Media Posted
			When '3'	Then '2,3'	-- Forecasted - Approved Estimate By Appr Date & Actual Media Posted
			When '4'	Then '2,3'	-- Forecasted - Approved Estimate By Job Due Date & Actual Media Posted
		End
  End
ELSE
	Select @ACTUAL_GRP = 0


-- Determine cdp_selection level 
-- Campaign is not permitted here because it would provide incomplete totals and is provided for in another SP 
----> 0-none; 1-c; 2-c/d; 3-c/d/p; 4-campaign
set @cdpc_level = 0
SELECT @count = COUNT(*) FROM PV_CDP WHERE UPPER(USERID) = UPPER(@UserID)
If @count > 0 
--	set @cdpc_level = 4	
--Else
	BEGIN
	SELECT @count = COUNT(*) FROM PV_CDP WHERE CL_CODE IS NOT NULL AND UPPER(USERID) = UPPER(@UserID)
	IF @count > 0
		BEGIN
		set @cdpc_level = 1
		SELECT @count = COUNT(*) FROM PV_CDP WHERE DIV_CODE IS NOT NULL AND UPPER(USERID) = UPPER(@UserID)
		IF @count > 0
			BEGIN
			set @cdpc_level = @cdpc_level + 1
			SELECT @count = COUNT(*) FROM PV_CDP WHERE PRD_CODE IS NOT NULL AND UPPER(USERID) = UPPER(@UserID)
			IF @count > 0
				set @cdpc_level = @cdpc_level + 1
			END
		END
	END


If @cdpc_level > 0	
	Set @sql_cdp = ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = BD.CL_CODE '
If @cdpc_level > 1
	Set @sql_cdp = @sql_cdp + ' AND PV_CDP.DIV_CODE = BD.DIV_CODE '
If @cdpc_level > 2
	Set @sql_cdp = @sql_cdp + ' AND PV_CDP.PRD_CODE = BD.PRD_CODE '
--If @cdpc_level = 4
--	Set @sql_cdp = @sql_cdp + ' INNER JOIN ON PV_CMP.CMP_IDENTIFIER = BD.PRD_CODE '

Set @sql_cdp = @sql_cdp + ' AND UPPER(USERID) = UPPER(''' + @UserID + ''')'


-- Gather Sales Class filter data
Declare @SCCount Integer
Declare @SCCode Varchar(4)
SELECT @SCCount = Count(*) 
FROM APP_VARS 
WHERE UPPER(USERID) = UPPER(@UserID) 
AND APPLICATION = 'PROJECTVIEWPOINT'
AND VARIABLE_GROUP = 'SC'

If @SCCount = 1
	SELECT @SCCode = VARIABLE_VALUE 
	FROM APP_VARS 
	WHERE UPPER(USERID) = UPPER(@UserID) 
	AND APPLICATION = 'PROJECTVIEWPOINT'
	AND VARIABLE_GROUP = 'SC'
	
If @SCCode = 'ALL'
	Set @SCCount = 0

If @SCCount > 0 
 Begin
	CREATE TABLE #SC( 	
		SC_CODE			varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL)
	
	INSERT INTO #SC
	SELECT ISNULL(VARIABLE_VALUE,'') 
	FROM APP_VARS 
	WHERE UPPER(USERID) = UPPER(@UserID) 
	AND APPLICATION = 'PROJECTVIEWPOINT'
	AND VARIABLE_GROUP = 'SC'	
 End


CREATE TABLE #BUDGET_VALUES( 	
	DESCRIPTION				VARCHAR(30) NULL,
	BUDGET_BILLING			Decimal (15,2),
	BUDGET_GI				Decimal (15,2),
	ACTUAL_APPROVED_BILLING	Decimal (15,2),
	ACTUAL_APPROVED_GI		Decimal (15,2),
	ACTUAL_BILLING			Decimal (15,2),
	ACTUAL_GI				Decimal (15,2),
	FORECASTED_BILLING		Decimal (15,2),
	FORECASTED_GI			Decimal (15,2),
	SORT					INTEGER
)

If @GroupLevel = 1
INSERT #BUDGET_VALUES 	VALUES('All',0,0,0,0,0,0,0,0,1)

If @GroupLevel = 2
Begin
	INSERT #BUDGET_VALUES 	VALUES('Production',0,0,0,0,0,0,0,0,2)
	INSERT #BUDGET_VALUES 	VALUES('Media',0,0,0,0,0,0,0,0,1)
	INSERT #BUDGET_VALUES 	VALUES('None',0,0,0,0,0,0,0,0,3)
End

--If @GroupLevel = 3
-- Just keep inserting new sales classes, AND duplicates, along the way. 
-- At the end, combine them and Sum together by DESCRIPTION.
-- This way won't have to determine whether a SC already exists, and whether have them all in the beginning.

--**********************************************
-- BUDGET (BILLING & GROSS INCOME)
--**********************************************
If @GroupLevel = 1	--ALL
Begin
	--BILLING
	Set @sql = 'UPDATE  #BUDGET_VALUES
	SET BUDGET_BILLING = (SELECT SUM(BD.BILLING_AMOUNT)
		FROM BUDGET B 
		INNER JOIN V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR '
		
	If @cdpc_level > 0
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON BD.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = BD.SC_CODE '
		
	Set @sql = @sql + '	WHERE  B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL '
	Set @sql = @sql + '	AND BD.BUDGET_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''')'
	
	EXEC(@sql)
	--print(@sql)

	--GROSS INCOME
	Set @sql = 'UPDATE  #BUDGET_VALUES
	SET BUDGET_GI = (SELECT SUM(BD.INCOME_AMOUNT) 
	FROM BUDGET B 
	INNER JOIN V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR '
			
	If @cdpc_level > 0
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON BD.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = BD.SC_CODE '
		
	Set @sql = @sql + '	WHERE  B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL '
	Set @sql = @sql + '	AND BD.BUDGET_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''')'
	
	EXEC(@sql)
	--print(@sql)
End

If @GroupLevel = 2	--TYPE
Begin 

	CREATE TABLE #BUDGET_SUMS(	
		DESCRIP		varchar(30),
		SUMA		Decimal (15,2) NULL)

--BILLING	(Need to take into consideration data might not have Type)
	Set @sql = 'INSERT INTO #BUDGET_SUMS
	SELECT CASE BD.BUDGET_TYPE WHEN ''P'' THEN ''Production'' WHEN ''M'' THEN ''Media'' ELSE ''None'' END,
		SUM(BD.BILLING_AMOUNT) 
	FROM BUDGET B 
	INNER JOIN V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR '
			
	If @cdpc_level > 0
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON BD.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = BD.SC_CODE '
			
	Set @sql = @sql + '	WHERE  B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL '
	Set @sql = @sql + '	AND BD.BUDGET_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''''
	Set @sql = @sql + '	GROUP BY BD.BUDGET_TYPE '
	
	EXEC(@sql)

	UPDATE  #BUDGET_VALUES
	SET BUDGET_BILLING = (SELECT ISNULL(#BUDGET_SUMS.SUMA,0) FROM #BUDGET_SUMS WHERE #BUDGET_VALUES.DESCRIPTION = #BUDGET_SUMS.DESCRIP)

	DELETE #BUDGET_SUMS

--GROSS INCOME
	Set @sql = 'INSERT INTO #BUDGET_SUMS
	SELECT CASE BD.BUDGET_TYPE WHEN ''P'' THEN ''Production'' WHEN ''M'' THEN ''Media'' ELSE ''None'' END,
		SUM(BD.INCOME_AMOUNT) 
	FROM BUDGET B 
	INNER JOIN V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR '
			
	If @cdpc_level > 0
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON BD.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = BD.SC_CODE '
			
	Set @sql = @sql + '	WHERE  B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL '
	Set @sql = @sql + '	AND BD.BUDGET_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''''
	Set @sql = @sql + '	GROUP BY BD.BUDGET_TYPE '
	
	EXEC(@sql)

	UPDATE  #BUDGET_VALUES
	SET BUDGET_GI = (SELECT ISNULL(#BUDGET_SUMS.SUMA,0) FROM #BUDGET_SUMS WHERE #BUDGET_VALUES.DESCRIPTION = #BUDGET_SUMS.DESCRIP)
	
	DROP TABLE #BUDGET_SUMS
End

If @GroupLevel = 3	--SALES CLASS
Begin
	CREATE TABLE #SC_SUMS(	
		SC_DESCRIPTION	Varchar(30),
		SC_SUM			Decimal (15,2) NULL)
		
	--BILLING
	Set @sql = 'INSERT INTO #SC_SUMS
		SELECT ISNULL(SALES_CLASS.SC_DESCRIPTION, ''None''), SUM(BD.BILLING_AMOUNT)  
		FROM BUDGET B 
		INNER JOIN V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR 
		LEFT OUTER JOIN SALES_CLASS ON SALES_CLASS.SC_CODE = BD.SC_CODE '
	
	If @cdpc_level > 0
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON BD.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = BD.SC_CODE '
			
	Set @sql = @sql + '	WHERE  B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL '
	Set @sql = @sql + '	AND BD.BUDGET_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''''
	Set @sql = @sql + '	GROUP BY SALES_CLASS.SC_DESCRIPTION '
	
	EXEC(@sql)

	INSERT INTO #BUDGET_VALUES (DESCRIPTION, BUDGET_BILLING, SORT)
	SELECT SC_DESCRIPTION, SUM(SC_SUM),
		CASE SC_DESCRIPTION WHEN 'None' THEN 0 ELSE 1 END  
	FROM #SC_SUMS GROUP BY SC_DESCRIPTION 

	DELETE #SC_SUMS

	--GROSS INCOME
	Set @sql = 'INSERT INTO #SC_SUMS
		SELECT ISNULL(SALES_CLASS.SC_DESCRIPTION, ''None''), SUM(BD.INCOME_AMOUNT)  
		FROM BUDGET B 
		INNER JOIN V_BUDGET_SUMMARY BD ON B.BUDGET_CODE = BD.BUDGET_CODE AND B.REV_NBR = BD.REV_NBR
		LEFT OUTER JOIN SALES_CLASS ON SALES_CLASS.SC_CODE = BD.SC_CODE  '
	
	If @cdpc_level > 0
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON BD.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = BD.SC_CODE '
			
	Set @sql = @sql + '	WHERE  B.REV_NBR = B.APPROVED_REV_NBR AND B.APPROVED_REV_NBR IS NOT NULL '
	Set @sql = @sql + '	AND BD.BUDGET_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''''
	Set @sql = @sql + '	GROUP BY SALES_CLASS.SC_DESCRIPTION '
	
	EXEC(@sql)

	INSERT INTO #BUDGET_VALUES (DESCRIPTION, BUDGET_GI, SORT)
	SELECT SC_DESCRIPTION, SUM(SC_SUM),
		CASE SC_DESCRIPTION WHEN 'None' THEN 0 ELSE 1 END
	FROM #SC_SUMS GROUP BY SC_DESCRIPTION
	
	--DROP TABLE #SC_SUMS
	DELETE #SC_SUMS
End

--*******************************************************************************************************************************************
--ACTUAL BILLING
--*******************************************************************************************************************************************
--Add code to determine what filter level to use:
--C/D/P or None (Cannot properly (fully) calculate campaign)

Set @sql_cdp = ''
If @cdpc_level > 0	
	Set @sql_cdp = @sql_cdp + ' INNER JOIN PV_CDP ON PV_CDP.CL_CODE = ACTUALS_ACC.CL_CODE '
If @cdpc_level > 1
	Set @sql_cdp = @sql_cdp + ' AND PV_CDP.DIV_CODE = ACTUALS_ACC.DIV_CODE '
If @cdpc_level > 2
	Set @sql_cdp = @sql_cdp + ' AND PV_CDP.PRD_CODE = ACTUALS_ACC.PRD_CODE '
--If @cdpc_level = 4
--	Set @sql_cdp = @sql_cdp + ' INNER JOIN ON PV_CMP.CMP_IDENTIFIER = BD.PRD_CODE '
Set @sql_cdp = @sql_cdp + ' AND UPPER(USERID) = UPPER(''' + @UserID + ''')'

If @GroupLevel = 2 Or @GroupLevel = 3
	CREATE TABLE #ACTUAL_SUMS( 	
		DESCRIP		Varchar(30) NULL,
		SUMA		Decimal (15,2) NULL)


If @GroupLevel = 1	 --ALL
Begin
	Set @sql = 'UPDATE  #BUDGET_VALUES
		SET ACTUAL_BILLING = ( SELECT SUM(ACTUALS_ACC.AMOUNT) FROM ACTUALS_ACC '
		
	If @cdpc_level > 0 AND @cdpc_level < 4
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACTUALS_ACC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	--Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'',''cos'') AND ((PPERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' ) OR  (BILL_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' )) '
	Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'',''cos'') AND ((BILL_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' )) '
	Set @sql = @sql + ' AND ACTUAL_GRP IN (' + @ACTUAL_GRP + '))'
	
	EXEC(@sql)
	--print(@sql)
End

If @GroupLevel = 2	 --TYPE 
Begin
	Set @sql = 'INSERT INTO #ACTUAL_SUMS
		SELECT CASE ACTUALS_ACC.ACTUALS_TYPE WHEN ''P'' THEN ''Production'' WHEN ''M'' THEN ''Media'' ELSE ''None'' END,
 			SUM(ACTUALS_ACC.AMOUNT) 
		FROM ACTUALS_ACC '
		
	If @cdpc_level > 0 AND @cdpc_level < 4
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACTUALS_ACC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	--Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'',''cos'') AND ((PPERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' ) OR  (BILL_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' ))'
	Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'',''cos'') AND ((BILL_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' )) '
	Set @sql = @sql + ' AND ACTUAL_GRP IN (' + @ACTUAL_GRP + ')'
	set @sql = @sql + ' GROUP BY ACTUALS_ACC.ACTUALS_TYPE'
	
	EXEC(@sql)
	--print(@sql)

	UPDATE  #BUDGET_VALUES
	SET ACTUAL_BILLING = (SELECT ISNULL(SUM(#ACTUAL_SUMS.SUMA),0) FROM #ACTUAL_SUMS WHERE #BUDGET_VALUES.DESCRIPTION = #ACTUAL_SUMS.DESCRIP)

	DELETE #ACTUAL_SUMS
End

 
If @GroupLevel = 3	 --SALES CLASS
Begin
	Set @sql = 'INSERT INTO #ACTUAL_SUMS
		SELECT ISNULL(SALES_CLASS.SC_DESCRIPTION, ''None''), SUM(ACTUALS_ACC.AMOUNT) 
		FROM ACTUALS_ACC
		LEFT OUTER JOIN SALES_CLASS ON SALES_CLASS.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	If @cdpc_level > 0 AND @cdpc_level < 4
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACTUALS_ACC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	--Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'',''cos'') 	AND ((PPERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' ) OR (BILL_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' ))'
	Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'',''cos'') AND ((BILL_PERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''' )) '
	Set @sql = @sql + ' AND ACTUAL_GRP IN (' + @ACTUAL_GRP + ')'
	set @sql = @sql +  ' GROUP BY SALES_CLASS.SC_DESCRIPTION'
	
	EXEC(@sql)
	
	INSERT INTO #BUDGET_VALUES (DESCRIPTION, ACTUAL_BILLING, SORT)
	SELECT DESCRIP, SUM(SUMA),
		CASE DESCRIP WHEN 'None' THEN 0 ELSE 1 END 
	FROM #ACTUAL_SUMS GROUP BY DESCRIP

	--UPDATE  #BUDGET_VALUES
	--SET ACTUAL_BILLING = (SELECT ISNULL(SUM(#ACTUAL_SUMS.SUMA),0) FROM #ACTUAL_SUMS WHERE #BUDGET_VALUES.DESCRIPTION = #ACTUAL_SUMS.DESCRIP)

	DELETE #ACTUAL_SUMS
End

--*******************************************************************************************************************************************
--ACTUAL GROSS INCOME
--*******************************************************************************************************************************************
If @GroupLevel = 1	 --ALL
Begin
	Set @sql = 'UPDATE #BUDGET_VALUES
			SET ACTUAL_GI = ( SELECT SUM(ACTUALS_ACC.AMOUNT) FROM ACTUALS_ACC '
		
	If @cdpc_level > 0 AND @cdpc_level < 4
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACTUALS_ACC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'') AND PPERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''''
	Set @sql = @sql + ' AND ACTUAL_GRP IN (' + @ACTUAL_GRP + '))'		
	
	EXEC(@sql)
	--print(@sql)
End

 
If @GroupLevel = 2	 --TYPE
Begin
	Set @sql = 'INSERT INTO #ACTUAL_SUMS
		SELECT CASE ACTUALS_ACC.ACTUALS_TYPE WHEN ''P'' THEN ''Production'' WHEN ''M'' THEN ''Media'' ELSE ''None'' END,
 			SUM(ACTUALS_ACC.AMOUNT) 
		FROM ACTUALS_ACC '
		
	If @cdpc_level > 0 AND @cdpc_level < 4
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACTUALS_ACC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'') AND PPERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''''
	Set @sql = @sql + ' AND ACTUAL_GRP IN (' + @ACTUAL_GRP + ')'
	set @sql = @sql +  ' GROUP BY ACTUALS_ACC.ACTUALS_TYPE'
	
	EXEC(@sql)

	UPDATE  #BUDGET_VALUES
	SET ACTUAL_GI = (SELECT ISNULL(SUM(#ACTUAL_SUMS.SUMA),0) FROM #ACTUAL_SUMS WHERE #BUDGET_VALUES.DESCRIPTION = #ACTUAL_SUMS.DESCRIP)

	DROP TABLE #ACTUAL_SUMS
End

 
If @GroupLevel = 3	 --SALES CLASS
Begin
	Set @sql = 'INSERT INTO #ACTUAL_SUMS
		SELECT  ISNULL(SALES_CLASS.SC_DESCRIPTION, ''None''), SUM(ACTUALS_ACC.AMOUNT) 
		FROM ACTUALS_ACC
		LEFT OUTER JOIN SALES_CLASS ON SALES_CLASS.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	If @cdpc_level > 0 AND @cdpc_level < 4
		Set @sql = @sql + @sql_cdp
		
	If @OfficeEmpCt > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACTUALS_ACC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
						
	If @SCCount > 0
		Set @sql = @sql + ' INNER JOIN #SC ON #SC.SC_CODE = ACTUALS_ACC.SC_CODE '
		
	Set @sql = @sql + ' Where CATEGORY_CODE IN (''fee'',''lab'',''com'') AND PPERIOD BETWEEN ''' + @budget_period + ''' AND ''' + @budget_period_to + ''''
	Set @sql = @sql + ' AND ACTUAL_GRP IN (' + @ACTUAL_GRP + ')'
	set @sql = @sql +  ' GROUP BY  SALES_CLASS.SC_DESCRIPTION '
	
	EXEC(@sql)
	
	INSERT INTO #BUDGET_VALUES (DESCRIPTION, ACTUAL_GI, SORT)
	SELECT DESCRIP, SUM(SUMA) ,
		CASE DESCRIP WHEN 'None' THEN 0 ELSE 1 END
	FROM #ACTUAL_SUMS GROUP BY DESCRIP

	--UPDATE  #BUDGET_VALUES
	--SET ACTUAL_GI = (SELECT ISNULL(SUM(#ACTUAL_SUMS.SUMA),0) FROM #ACTUAL_SUMS WHERE #BUDGET_VALUES.DESCRIPTION = #ACTUAL_SUMS.DESCRIP)

	DROP TABLE #ACTUAL_SUMS
End

UPDATE #BUDGET_VALUES SET SORT = 0 WHERE DESCRIPTION = 'None'


--************************************************
--Sum by DESCRIPTION
--************************************************
SELECT SORT, DESCRIPTION, 
	ISNULL(SUM(BUDGET_BILLING),0) AS BUDGET_BILLING, 
	ISNULL(SUM(BUDGET_GI),0) AS BUDGET_GI, 
	ISNULL(SUM(ACTUAL_BILLING),0) AS ACTUAL_BILLING, 
	ISNULL(SUM(ACTUAL_GI),0) AS ACTUAL_GI,
	ISNULL(SUM(BUDGET_BILLING),0) - ISNULL(SUM(ACTUAL_BILLING),0) AS VARIANCE_BILLING,
	ISNULL(SUM(BUDGET_GI),0) - ISNULL(SUM(ACTUAL_GI),0) AS VARIANCE_GI
FROM #BUDGET_VALUES
GROUP BY SORT, DESCRIPTION	
ORDER BY SORT desc, DESCRIPTION ASC


DROP TABLE #BUDGET_VALUES
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


GRANT EXEC ON dbo.usp_wv_get_budget_viewpoint TO PUBLIC
GO