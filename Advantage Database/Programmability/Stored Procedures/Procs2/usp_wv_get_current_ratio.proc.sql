SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_get_current_ratio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_get_current_ratio]
GO


CREATE PROCEDURE [dbo].[usp_wv_get_current_ratio] 
@startPP	varchar(6),
@endPP	varchar(6),
@Office varchar(4),
@USER_ID VARCHAR(100)
AS

Set NoCount On

DECLARE @sql varchar(4000)
DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @COUNT AS INTEGER
DECLARE @sql_where as varchar(2000)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@USER_ID)
SELECT @COUNT = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

CREATE TABLE #ASSETS( OFFICE_CODE VARCHAR(4), OFFICE_NAME VARCHAR(30), SumOfGLETAMT FLOAT, ASSETS FLOAT )

SET @sql = 'INSERT INTO #ASSETS '

If @Office <> ''
	set @sql = @sql + ' SELECT OFFICE.OFFICE_CODE, OFFICE.OFFICE_NAME, '
	
Else
	set @sql = @sql + ' SELECT ''ALL'' AS OFFICE_CODE, ''ALL'' AS OFFICE_NAME, '
	
	
set @sql = @sql + '  Sum(ISNULL((GLSCREDIT + GLSDEBIT),0)) AS SumOfGLETAMT, 
  Sum(Case When GLABALTYPE=0 Then ISNULL((GLSCREDIT + GLSDEBIT),0) * -1 Else ISNULL((GLSCREDIT + GLSDEBIT),0) End) AS ASSETS
FROM GLSUMMARY 
  INNER JOIN GLACCOUNT ON GLSUMMARY.GLSCODE = GLACCOUNT.GLACODE 
  LEFT OUTER JOIN GLOXREF ON GLACCOUNT.GLAOFFICE = GLOXREF.GLOXGLOFFICE 
  LEFT OUTER JOIN OFFICE ON GLOXREF.GLOXOFFICE = OFFICE.OFFICE_CODE '
  
set @sql_where = ' WHERE GLSUMMARY.GLSPP Between  ''' + @startPP + ''' AND ''' + @endPP + '''
  AND GLACCOUNT.GLATYPE = ''2'' '
  
If @Office <> ''
	  Begin
		set @sql_where = @sql_where + ' AND OFFICE.OFFICE_CODE = ''' + @Office + ''''
		set @sql_where = @sql_where + ' GROUP BY OFFICE.OFFICE_CODE, OFFICE.OFFICE_NAME '
	  End
  
Else
	IF @COUNT > 0 
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

set @sql = @sql + @sql_where

EXEC (@sql)
--PRINT (@sql)


CREATE TABLE #LIAB( OFFICE_CODE VARCHAR(4), OFFICE_NAME VARCHAR(30), SumOfGLETAMT FLOAT, LIAB FLOAT )

SET @sql = ' INSERT INTO #LIAB '

If @Office <> ''
	set @sql = @sql + ' SELECT OFFICE.OFFICE_CODE, OFFICE.OFFICE_NAME, '
Else
	set @sql = @sql + ' SELECT ''ALL'' AS OFFICE_CODE, ''ALL'' AS OFFICE_NAME, '


set @sql = @sql + '  Sum(ISNULL((GLSCREDIT + GLSDEBIT),0)) AS SumOfGLETAMT, 
Sum(Case When GLABALTYPE=0 Then ISNULL((GLSCREDIT + GLSDEBIT),0) * -1 Else ISNULL((GLSCREDIT + GLSDEBIT),0) End) AS LIAB
FROM GLSUMMARY 
  INNER JOIN GLACCOUNT ON GLSUMMARY.GLSCODE = GLACCOUNT.GLACODE 
  LEFT OUTER JOIN GLOXREF ON GLACCOUNT.GLAOFFICE = GLOXREF.GLOXGLOFFICE 
  LEFT OUTER JOIN OFFICE ON GLOXREF.GLOXOFFICE = OFFICE.OFFICE_CODE '


set @sql_where = ' WHERE GLSUMMARY.GLSPP Between ''' + @startPP + ''' AND ''' + @endPP + '''
				AND GLACCOUNT.GLATYPE = ''5'' '

If @Office <> ''
	Begin
		set @sql_where = @sql_where + ' AND OFFICE.OFFICE_CODE = ''' + @Office + ''''
		set @sql_where = @sql_where + ' GROUP BY OFFICE.OFFICE_CODE, OFFICE.OFFICE_NAME '
	End

Else
	IF @COUNT > 0
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

set @sql = @sql + @sql_where

EXEC (@sql)
--PRINT (@sql)

SELECT #ASSETS.OFFICE_CODE, #ASSETS.OFFICE_NAME, ISNULL(#ASSETS.ASSETS,0) AS ASSETS, ISNULL(#LIAB.LIAB,0) AS LIAB, 
Case #LIAB.LIAB When 0 Then 0 Else ISNULL(#ASSETS.ASSETS/#LIAB.LIAB,0) End AS RATIO
FROM #ASSETS 
  INNER JOIN #LIAB ON #ASSETS.OFFICE_CODE = #LIAB.OFFICE_CODE

DROP TABLE #ASSETS
DROP TABLE #LIAB


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO