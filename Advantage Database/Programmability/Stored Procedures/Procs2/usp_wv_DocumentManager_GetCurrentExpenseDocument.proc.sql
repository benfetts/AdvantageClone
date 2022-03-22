if exists (select * from sysobjects where id = object_id(N'[dbo].[usp_wv_DocumentManager_GetCurrentExpenseDocument]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_DocumentManager_GetCurrentExpenseDocument]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE [dbo].[usp_wv_DocumentManager_GetCurrentExpenseDocument]
@INV_NBR VARCHAR(20),
@EMP VARCHAR(6),
@Filter VARCHAR(30),
@History smallint,
@Private Int
AS

DECLARE @sql as varchar(4000)

If @History = 1 --Do not show history, only most recent
BEGIN
	CREATE TABLE #TMP_INV (
	FILENAME VARCHAR(300),
	DOCUMENT_ID INT ,
	)

	INSERT INTO #TMP_INV
	SELECT DOCUMENTS.FILENAME, MAX(DOCUMENTS.DOCUMENT_ID) AS DOCUMENT_ID
	FROM DOCUMENTS
	INNER JOIN EXPENSE_DOCS ON EXPENSE_DOCS.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID
	WHERE EXPENSE_DOCS.INV_NBR = @INV_NBR
	GROUP BY DOCUMENTS.FILENAME
END
				
set @sql = 'SELECT ''Expense Receipt'' AS LEVEL, EXPENSE_DOCS.INV_NBR, EXPENSE_HEADER.EXP_DESC, DOCUMENTS.DOCUMENT_ID, DOCUMENTS.FILENAME, 
  DOCUMENTS.MIME_TYPE, DOCUMENTS.DESCRIPTION, DOCUMENTS.KEYWORDS, DOCUMENTS.UPLOADED_DATE, 
  DOCUMENTS.USER_CODE, DOCUMENTS.FILE_SIZE, SEC_USER.USER_NAME, DOCUMENTS.REPOSITORY_FILENAME, 
  DOCUMENT_TYPE.DOCUMENT_TYPE_DESC, ISNULL(DOCUMENTS.PRIVATE_FLAG,0) AS PRIVATE_FLAG, 
  DOCUMENTS.PROOFHQ_URL, DOCUMENTS.THUMBNAIL
FROM EXPENSE_DOCS 
  INNER JOIN EXPENSE_HEADER ON EXPENSE_DOCS.INV_NBR = EXPENSE_HEADER.INV_NBR
  INNER JOIN DOCUMENTS ON EXPENSE_DOCS.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID AND ( DOCUMENTS.PRIVATE_FLAG = 0 OR DOCUMENTS.PRIVATE_FLAG IS NULL '
 
 If @Private = 1	-- Has access to private files  
	set @sql = @sql + ' OR DOCUMENTS.PRIVATE_FLAG = 1 ' 
	
 set @sql = @sql + ' ) '
  
 set @sql = @sql + ' INNER JOIN DOCUMENT_TYPE ON DOCUMENTS.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID 
  LEFT OUTER JOIN SEC_USER ON UPPER(DOCUMENTS.USER_CODE) = UPPER(SEC_USER.USER_CODE) '
  
If @History = 1 
  set @sql = @sql + ' INNER JOIN #TMP_INV ON #TMP_INV.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID '
  
  
set @sql = @sql + ' WHERE EXPENSE_DOCS.INV_NBR = ' + @INV_NBR

If @EMP <> ''	
	set @sql = @sql + ' AND EXPENSE_HEADER.EMP_CODE = ''' + @EMP + ''''

--If @INVDATE <> ''
--	set @sql = @sql + ' AND EXPENSE_HEADER.INV_DATE = ''' + @INVDATE + ''''
	
IF @Filter <> ''
	set @sql = @sql + ' AND (LOWER(DOCUMENTS.KEYWORDS) LIKE ''%' + @Filter + '%'' OR  LOWER(DOCUMENTS.FILENAME) LIKE ''%' + @Filter + '%'' OR LOWER(DOCUMENTS.DESCRIPTION) LIKE ''%' + @Filter + '%'')'

SELECT @sql = @sql + ' ORDER BY DOCUMENTS.UPLOADED_DATE DESC'

EXEC(@sql)
--print(@sql)

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
