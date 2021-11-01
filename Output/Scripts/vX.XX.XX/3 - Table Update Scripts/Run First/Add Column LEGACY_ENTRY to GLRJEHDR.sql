CREATE TABLE #COLUMN_ADDED (ROW_ID INT IDENTITY, INSERTED BIT NOT NULL)

IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GLRJEHDR' AND COLUMN_NAME = 'LEGACY_ENTRY') BEGIN

	ALTER TABLE [dbo].[GLRJEHDR] ADD [LEGACY_ENTRY] [bit] NOT NULL DEFAULT(0)
	
	INSERT INTO #COLUMN_ADDED
	VALUES(1)

END
GO

IF EXISTS(SELECT ROW_ID FROM #COLUMN_ADDED WHERE INSERTED = 1) BEGIN

	UPDATE [dbo].[GLRJEHDR] SET [LEGACY_ENTRY] = 1

END
GO

DROP TABLE #COLUMN_ADDED
GO