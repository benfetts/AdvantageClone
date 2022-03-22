if exists (select * from sysobjects where id = object_id(N'[dbo].[usp_wv_DocumentManager_GetCurrentAdNumberDocument]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_DocumentManager_GetCurrentAdNumberDocument]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE [dbo].[usp_wv_DocumentManager_GetCurrentAdNumberDocument]
@AD_NBR VARCHAR(30),
@CL_CODE VARCHAR(6),
@Private Int
AS
DECLARE @Restrictions Int,
	@sql nvarchar(4000),
	@paramlist nvarchar(4000)

SELECT @sql = 'SELECT ''Ad Number'' AS LEVEL, AD_NUMBER.AD_NBR, AD_NUMBER.AD_NBR_DESC, DOCUMENTS.DOCUMENT_ID, DOCUMENTS.FILENAME, 
                      DOCUMENTS.MIME_TYPE, DOCUMENTS.DESCRIPTION, DOCUMENTS.KEYWORDS, DOCUMENTS.UPLOADED_DATE, 
                      DOCUMENTS.USER_CODE, DOCUMENTS.FILE_SIZE, SEC_USER.USER_NAME, DOCUMENTS.REPOSITORY_FILENAME, 
                      DOCUMENT_TYPE.DOCUMENT_TYPE_DESC, ISNULL(DOCUMENTS.PRIVATE_FLAG,0) AS PRIVATE_FLAG, 
                      DOCUMENTS.PROOFHQ_URL
			   FROM		AD_NUMBER 
			     INNER JOIN		DOCUMENTS ON AD_NUMBER.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID AND ( DOCUMENTS.PRIVATE_FLAG = 0 OR DOCUMENTS.PRIVATE_FLAG IS NULL '
			     
If @Private = 1	-- Has access to private files  
	set @sql = @sql + ' OR DOCUMENTS.PRIVATE_FLAG = 1 ' 
	
set @sql = @sql + ' ) '
  
 set @sql = @sql + ' INNER JOIN		DOCUMENT_TYPE ON DOCUMENTS.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID 
                 LEFT OUTER JOIN	SEC_USER ON UPPER(DOCUMENTS.USER_CODE) = UPPER(SEC_USER.USER_CODE)
				WHERE AD_NUMBER.AD_NBR = @AD_NBR'

if @CL_CODE <> ''
Begin
	SELECT @sql = @sql + ' AND AD_NUMBER.CL_CODE = @CL_CODE'
End

SELECT @sql = @sql + ' ORDER BY DOCUMENTS.UPLOADED_DATE DESC'

SELECT @paramlist = '@AD_NBR varchar(30), @CL_CODE varchar(6)'
--print @sql
EXEC sp_executesql @sql, @paramlist, @AD_NBR, @CL_CODE

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
