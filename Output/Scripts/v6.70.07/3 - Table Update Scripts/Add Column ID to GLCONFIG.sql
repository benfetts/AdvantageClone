IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GLCONFIG' AND COLUMN_NAME = 'ID') BEGIN

	   ALTER TABLE dbo.GLCONFIG ADD	ID int NOT NULL IDENTITY (1, 1)
	
END
GO
