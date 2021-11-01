IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_proofing_load_latest_versions]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_proofing_load_latest_versions]
GO
CREATE PROCEDURE [dbo].[advsp_proofing_load_latest_versions] 
@ALERT_ID INT
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE
		@LATEST_VERSIONS TABLE (ID INT IDENTITY, DocumentID INT, Filename VARCHAR(MAX), Thumbnail IMAGE, VersionNumber INT)
	;
	INSERT INTO @LATEST_VERSIONS(DocumentID, Filename, Thumbnail, VersionNumber)
	SELECT
		[DocumentID] = X.DocumentID,
		[Filename] = X.[Filename],
		[Thumbnail] = DD.THUMBNAIL,
		[VersionNumber] = DD.VERSION_NUMBER
	FROM
		(
			SELECT
				[DocumentID] = MAX(D.DOCUMENT_ID),
				[Filename] = D.[FILENAME]
			FROM
				DOCUMENTS D WITH(NOLOCK)
				INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID
			WHERE
				AA.ALERT_ID = @ALERT_ID
			GROUP BY
				D.[FILENAME]
		) AS X
		INNER JOIN DOCUMENTS DD ON DD.DOCUMENT_ID = X.DocumentID
	;
	SELECT
		*
	FROM
		@LATEST_VERSIONS LV
	;
END
/*=========== QUERY ===========*/