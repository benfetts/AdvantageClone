IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[advsp_alert_system_delete_alert]')
          AND OBJECTPROPERTY(id, N'IsProcedure') = 1
)
    DROP PROCEDURE [dbo].[advsp_alert_system_delete_alert];
GO
CREATE PROCEDURE [dbo].[advsp_alert_system_delete_alert] 

/*WITH ENCRYPTION*/

@ALERT_ID     INT,
@CS_REVIEW_ID INT
AS
     BEGIN
         IF NOT @CS_REVIEW_ID IS NULL
            AND @CS_REVIEW_ID > 0
             BEGIN
                 SET @ALERT_ID =
                 (
                     SELECT TOP 1 ALERT_ID
                     FROM ALERT
                     WHERE CS_REVIEW_ID = @CS_REVIEW_ID
                 );
             END;
         IF NOT @ALERT_ID IS NULL
            AND @ALERT_ID > 0
             BEGIN
                 DECLARE @DOC_ID TABLE(DOCUMENT_ID INT);
                 INSERT INTO @DOC_ID
                        SELECT DOCUMENT_ID
                        FROM ALERT_ATTACHMENT
                        WHERE ALERT_ID = @ALERT_ID;
                 DELETE FROM @DOC_ID
                 WHERE DOCUMENT_ID IN
                 (
                     SELECT D.DOCUMENT_ID AS DOCUMENT_ID
                     FROM @DOC_ID D
                          LEFT OUTER JOIN JOB_COMPONENT_DOCUMENTS JCD ON D.DOCUMENT_ID = JCD.DOCUMENT_ID
                          LEFT OUTER JOIN JOB_DOCUMENTS JLD ON D.DOCUMENT_ID = JLD.DOCUMENT_ID
                     WHERE NOT JCD.DOCUMENT_ID IS NULL
                           AND NOT JLD.DOCUMENT_ID IS NULL
                 );
                 DELETE FROM ALERT_ATTACHMENT
                 WHERE DOCUMENT_ID IN
                 (
                     SELECT DOCUMENT_ID
                     FROM @DOC_ID
                 );
                 DELETE FROM DOCUMENTS
                 WHERE DOCUMENT_ID IN
                 (
                     SELECT DOCUMENT_ID
                     FROM @DOC_ID
                 );
                 DELETE FROM ALERT_RCPT_DISMISSED
                 WHERE ALERT_ID = @ALERT_ID;
                 DELETE FROM ALERT_RCPT
                 WHERE ALERT_ID = @ALERT_ID;
                 DELETE FROM CP_ALERT_RCPT_DISMISSED
                 WHERE ALERT_ID = @ALERT_ID;
                 DELETE FROM CP_ALERT_RCPT
                 WHERE ALERT_ID = @ALERT_ID;
                 DELETE FROM ALERT_COMMENT
                 WHERE ALERT_ID = @ALERT_ID;
                 IF EXISTS
                 (
                     SELECT TABLE_NAME
                     FROM INFORMATION_SCHEMA.TABLES
                     WHERE TABLE_NAME = 'ALERT_COMMENTS'
                 )
                     BEGIN
                         DELETE FROM ALERT_COMMENTS
                         WHERE ALERT_ID = @ALERT_ID;
                     END;
                 IF EXISTS
                 (
                     SELECT TABLE_NAME
                     FROM INFORMATION_SCHEMA.TABLES
                     WHERE TABLE_NAME = 'ALERT_DOCUMENT_KEYWORD'
                 )
                     BEGIN
						 DELETE FROM ALERT_DOCUMENT_KEYWORD
						 WHERE ALERT_ID = @ALERT_ID;
                     END;
                 IF EXISTS
                 (
                     SELECT TABLE_NAME
                     FROM INFORMATION_SCHEMA.TABLES
                     WHERE TABLE_NAME = 'ALERT_DOCUMENT'
                 )
                     BEGIN
						 DELETE FROM ALERT_DOCUMENT
						 WHERE ALERT_ID = @ALERT_ID;
                     END;
                 IF EXISTS
                 (
                     SELECT TABLE_NAME
                     FROM INFORMATION_SCHEMA.TABLES
                     WHERE TABLE_NAME IN ('SPRINT_DTL')
                 )
                     BEGIN
						 DELETE SE
						 FROM SPRINT_DTL SD
							  INNER JOIN SPRINT_EMPLOYEE SE ON SD.ID = SE.SPRINT_DTL_ID
							  INNER JOIN ALERT A ON SD.ALERT_ID = A.ALERT_ID
						 WHERE A.ALERT_ID = @ALERT_ID;
						 DELETE SD
						 FROM SPRINT_DTL SD
							  INNER JOIN ALERT A ON SD.ALERT_ID = A.ALERT_ID
						 WHERE A.ALERT_ID = @ALERT_ID;
                     END;

             END;
         DELETE FROM ALERT
         WHERE ALERT_ID = @ALERT_ID;
     END;