IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_cs_get_repository_thumbnails]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_cs_get_repository_thumbnails]
GO
CREATE PROCEDURE [dbo].[advsp_cs_get_repository_thumbnails] /*WITH ENCRYPTION*/
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT
AS
/*=========== QUERY ===========*/
	SELECT 
		DOCUMENT_ID AS DocumentID,
		[FILENAME] AS [Filename],
		MIME_TYPE AS MimeType,
		REPOSITORY_FILENAME AS RepositoryFilename,
		NULL AS FileBytes,
		NULL AS Base64ImageURL,
		CASE
			WHEN LOWER(MIME_TYPE) LIKE '%image%' THEN CAST(1 AS BIT)
			ELSE CAST(0 AS BIT)
		END AS IsImage,
		THUMBNAIL AS Thumbnail,
		CASE
			WHEN THUMBNAIL IS NULL THEN CAST(0 AS BIT)
			ELSE CAST(1 AS BIT)
		END AS HasThumbnail
	FROM 
		WV_CURRENT_JOB_COMPONENT_DOCUMENTS 
	WHERE
		JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NUMBER = @JOB_COMPONENT_NBR;
/*=========== QUERY ===========*/