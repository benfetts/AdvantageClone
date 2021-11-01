﻿
CREATE VIEW dbo.WV_PRODUCT_DOCUMENTS
AS

SELECT     dbo.PRODUCT_DOCUMENTS.CL_CODE, dbo.PRODUCT_DOCUMENTS.DIV_CODE, dbo.PRODUCT_DOCUMENTS.PRD_CODE, 
                      dbo.DOCUMENTS.DOCUMENT_ID, dbo.DOCUMENTS.FILENAME, dbo.DOCUMENTS.MIME_TYPE, dbo.DOCUMENTS.DESCRIPTION, 
                      dbo.DOCUMENTS.KEYWORDS, dbo.DOCUMENTS.UPLOADED_DATE, dbo.DOCUMENTS.USER_CODE, dbo.DOCUMENTS.FILE_SIZE, 
                       dbo.DOCUMENTS.USER_CODE AS [USER_NAME], dbo.DOCUMENTS.REPOSITORY_FILENAME,
                      dbo.DOCUMENTS.PROOFHQ_URL
FROM         dbo.DOCUMENTS INNER JOIN
                      dbo.PRODUCT_DOCUMENTS ON dbo.DOCUMENTS.DOCUMENT_ID = dbo.PRODUCT_DOCUMENTS.DOCUMENT_ID
                      
