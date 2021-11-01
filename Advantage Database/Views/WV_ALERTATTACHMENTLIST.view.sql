﻿
CREATE VIEW [dbo].[WV_ALERTATTACHMENTLIST]
AS
SELECT     dbo.ALERT_ATTACHMENT.ATTACHMENT_ID AS AttachmentID, dbo.ALERT_ATTACHMENT.ALERT_ID AS AlertID, 
                      dbo.DOCUMENTS.FILENAME AS RealFileName, dbo.ALERT_ATTACHMENT.GENERATED_DATE AS AddedDate, 
                       dbo.DOCUMENTS.USER_CODE AS UserName, dbo.DOCUMENTS.MIME_TYPE AS MimeType, dbo.ALERT_ATTACHMENT.EMAILSENT, 
                      dbo.DOCUMENTS.REPOSITORY_FILENAME, dbo.DOCUMENTS.DOCUMENT_ID, dbo.DOCUMENTS.FILE_SIZE, dbo.DOCUMENTS.DESCRIPTION, 
                      dbo.ALERT_ATTACHMENT.USER_CODE, ISNULL(dbo.DOCUMENTS.PRIVATE_FLAG, 0) AS PRIVATE_FLAG
FROM         dbo.ALERT_ATTACHMENT INNER JOIN
                      dbo.DOCUMENTS ON dbo.ALERT_ATTACHMENT.DOCUMENT_ID = dbo.DOCUMENTS.DOCUMENT_ID
