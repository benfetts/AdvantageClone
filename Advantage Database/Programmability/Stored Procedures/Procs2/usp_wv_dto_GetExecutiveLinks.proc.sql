SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_GetExecutiveLinks]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_GetExecutiveLinks]
GO

CREATE PROCEDURE [dbo].[usp_wv_dto_GetExecutiveLinks] 
@UserID Varchar(100),
@EmpCode Varchar(6),
@Type int,
@Private int
AS

DECLARE @RESTRICTED_CLIENTS  INT,
        @SqlStmt       VARCHAR(8000),
        @OfficeCode    VARCHAR(4),
        @RESTRICTED_OFFICES INT

SET NOCOUNT ON
 
SELECT @RESTRICTED_CLIENTS = ISNULL(COUNT(1),0)
FROM   SEC_CLIENT WITH(NOLOCK)
WHERE  UPPER(USER_ID) = UPPER(@UserID);

SELECT @OfficeCode = ISNULL(OFFICE_CODE, '')
FROM   EMPLOYEE WITH(NOLOCK)
WHERE  EMP_CODE = @EmpCode;

SELECT @RESTRICTED_OFFICES = ISNULL(COUNT(1),0)
FROM   EMP_OFFICE WITH(NOLOCK)
WHERE  EMP_CODE = @EmpCode;

SET @SqlStmt = 
    '
		SELECT DISTINCT DOCUMENTS.DOCUMENT_ID,
			   ISNULL(DOCUMENTS.DESCRIPTION, DOCUMENTS.FILENAME) AS DESCRIPTION,
			   DOCUMENTS.FILENAME,
			   DOCUMENT_TYPE.DOCUMENT_TYPE_DESC,
			   DOCUMENTS.USER_CODE,
			   dbo.udf_get_empl_name(SEC_USER.EMP_CODE, ''FML'') AS USER_NAME,
			   DOCUMENTS.UPLOADED_DATE,
			   DOCUMENTS.MIME_TYPE,
			   DOCUMENTS.REPOSITORY_FILENAME,
			   ISNULL(ALERT_ATTACHMENT.ALERT_ID, 0) AS ALERT_ID, EXEC_DESKTOP_DOCUMENTS.OFFICE_CODE
		FROM   EXEC_DESKTOP_DOCUMENTS WITH(NOLOCK)
			   INNER JOIN DOCUMENTS WITH(NOLOCK)
					ON  EXEC_DESKTOP_DOCUMENTS.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID
			   INNER JOIN DOCUMENT_TYPE WITH(NOLOCK)
					ON  DOCUMENTS.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID
			   LEFT OUTER JOIN SEC_USER WITH(NOLOCK)
					ON  UPPER(DOCUMENTS.USER_CODE) = UPPER(SEC_USER.USER_CODE)
			   LEFT OUTER JOIN ALERT_ATTACHMENT WITH(NOLOCK)
					ON  EXEC_DESKTOP_DOCUMENTS.DOCUMENT_ID = ALERT_ATTACHMENT.DOCUMENT_ID
		      LEFT OUTER JOIN EMP_OFFICE WITH(NOLOCK)
		            ON  EXEC_DESKTOP_DOCUMENTS.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
		'
SET @SqlStmt = @SqlStmt +'
		WHERE  (
				   DOCUMENTS.DOCUMENT_ID IN (SELECT MAX(EXEC_DESKTOP_DOCUMENTS_1.DOCUMENT_ID) AS 
													DOCUMENT_ID
											 FROM   EXEC_DESKTOP_DOCUMENTS AS 
													EXEC_DESKTOP_DOCUMENTS_1 WITH(NOLOCK)
													INNER JOIN DOCUMENTS AS DOCUMENTS_1 WITH(NOLOCK)
														 ON  EXEC_DESKTOP_DOCUMENTS_1.DOCUMENT_ID = 
															 DOCUMENTS_1.DOCUMENT_ID
											 GROUP BY
													EXEC_DESKTOP_DOCUMENTS_1.OFFICE_CODE,
													DOCUMENTS_1.FILENAME)
		)
	 '
		 
IF @Type <> 0
BEGIN
    SET @SqlStmt = @SqlStmt + ' AND (DOCUMENTS.DOCUMENT_TYPE_ID = ''' + 
        CONVERT(VARCHAR(5), @Type) + ''') '
END

IF @OfficeCode <> '' AND @RESTRICTED_OFFICES = 0
BEGIN
    SET @SqlStmt = @SqlStmt + ' AND ((EXEC_DESKTOP_DOCUMENTS.OFFICE_CODE = ''' 
        + @OfficeCode + ''') OR (EXEC_DESKTOP_DOCUMENTS.OFFICE_CODE IS NULL)) '
END

SET @SqlStmt = @SqlStmt + ' AND (EXEC_DESKTOP_DOCUMENTS.EMP_CODE = ''' + @EmpCode + ''' OR EXEC_DESKTOP_DOCUMENTS.EMP_CODE IS NULL) '

IF @Private = 0
BEGIN
    SET @SqlStmt = @SqlStmt + 
        ' AND ((DOCUMENTS.PRIVATE_FLAG <> 1) OR (DOCUMENTS.PRIVATE_FLAG IS NULL))'
END

IF  @OfficeCode <> '' AND @RESTRICTED_OFFICES > 0 
BEGIN
		SET @SqlStmt = @SqlStmt +
        N' AND ((EXEC_DESKTOP_DOCUMENTS.OFFICE_CODE IS NULL) OR (EXEC_DESKTOP_DOCUMENTS.OFFICE_CODE IN (SELECT DISTINCT OFFICE_CODE FROM EMP_OFFICE WHERE EMP_CODE = ''' + @EmpCode + ''')))'
END		

--SET @SqlStmt = @SqlStmt + N'Order By V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, CDP, JobData '

--PRINT @SqlStmt

EXEC(@SqlStmt)









GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

