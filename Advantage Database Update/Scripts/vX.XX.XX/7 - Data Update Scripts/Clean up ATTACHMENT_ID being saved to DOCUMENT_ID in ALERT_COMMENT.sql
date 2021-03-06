BEGIN TRY
	UPDATE ALERT_COMMENT WITH(ROWLOCK) SET DOCUMENT_ID = AA.DOCUMENT_ID
	FROM
		ALERT_COMMENT AC
		LEFT OUTER JOIN DOCUMENTS D WITH(NOLOCK) ON AC.DOCUMENT_ID = D.DOCUMENT_ID
		INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON AA.ATTACHMENT_ID = AC.DOCUMENT_ID
	WHERE
		AC.DOCUMENT_ID IS NOT NULL
		AND D.DOCUMENT_ID IS NULL
	;
END TRY
BEGIN CATCH
END CATCH
BEGIN TRY
	IF NOT EXISTS (	SELECT * 
					FROM sys.foreign_keys 
					WHERE object_id = OBJECT_ID(N'FK_ALERT_COMMENT_DOCUMENTS')
						AND parent_object_id = OBJECT_ID(N'ALERT_COMMENT')
	)
	BEGIN

		ALTER TABLE [dbo].[ALERT_COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_ALERT_COMMENT_DOCUMENTS] FOREIGN KEY([DOCUMENT_ID])
		REFERENCES [dbo].[DOCUMENTS] ([DOCUMENT_ID])

		ALTER TABLE [dbo].[ALERT_COMMENT] CHECK CONSTRAINT [FK_ALERT_COMMENT_DOCUMENTS]

	END
END TRY
BEGIN CATCH
END CATCH


